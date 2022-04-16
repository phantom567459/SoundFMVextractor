Imports System.IO
Imports System.Text

' wav reference:
' http://soundfile.sapp.org/doc/WaveFormat/

Module main

    'globals
    Dim addlinetoprojectlog As String
    Dim databankcount As Integer

    'Header for str files:
    'emo_ (stream head followed by size of files in bank)
    '0x0507b40f - ?
    '


    Function FindDataStart(ByVal sndfileloc As String, ByVal dataWrap As Byte())
        'This function is to find the start of a data bank
        'The way munged video and sound files are structured is "header info, empty space, all data"
        'It stores the positions of all data banks in an array for usage later

        Dim w() As Byte = IO.File.ReadAllBytes(sndfileloc) 'read file as array of bytes
        Dim wFound As Boolean = True
        Dim fsloc As New IO.FileStream(sndfileloc, IO.FileMode.Open) 'filestream local variable
        Dim binary_readerloc As New IO.BinaryReader(fsloc) 'binary
        Dim wrapByte As Byte()
        Dim wrapSize, bankcount As Integer
        Dim strDataWrap As String = dataWrap.ToString()
        Dim wavdatastart As Integer() = New Integer() {}


        bankcount = -1 'initalize

        For i As Integer = 0 To w.Length - dataWrap.Length - 1
            If w(i) = dataWrap(0) Then
                wFound = True
                For j As Integer = 0 To dataWrap.Length - 1
                    If w(i + j) <> dataWrap(j) Then
                        wFound = False
                        Exit For
                    End If
                Next
                If wFound Then
                    bankcount += 1

                    'Read datasize, convert to uint32
                    fsloc.Position = i + 4
                    wrapByte = binary_readerloc.ReadBytes(4)
                    wrapSize = BitConverter.ToUInt32(wrapByte, 0)

                    'Redefine the array, add the next value
                    ReDim Preserve wavdatastart(bankcount)
                    wavdatastart(bankcount) = i + 8


                    'Logging
                    addlinetoprojectlog = strDataWrap & " data found at byte: " & i & " Size: " & wrapSize & vbCr
                    'addlinetoprojectlog = "Wrap data found at byte: " & i + 8 & " Size: " & wrapSize & vbCr
                    addlinetoprojectlog = String.Format("Wrap data found at byte: 0x{0:x}  Size: {1}", i + 8, wrapSize) & vbCr
                    UpdateProjectLog(addlinetoprojectlog)

                    'I hope there's only one bank.  Oh wait, there isn't.  I had to rewrite this function at one point

                End If
            End If
        Next


        'File Cleanup
        fsloc.Close()
        binary_readerloc.Close()

        databankcount = bankcount
        Return wavdatastart 'returns exact array of position of wav data 
    End Function

    Function AddHeader(ByVal HeaderType As String, ByVal Size As UInt32, ByVal SampleRate As UInt32, ByVal Channel As UInt16, ByVal Name As String)
        If HeaderType = "wavPCM16" Then 'standard bank

            'File header structure is as follows:
            'RIFF, size of file - 8 bytes (uint32)
            'WAVEfmt + 0x20
            'chunk size (generally 16 (0x10) for regular PCM, 20(0x14 for IMA ADPCM) --(uint32)
            'format (1 (0x01) for PCM16, 17 (0x11) for IMA ADPCM) (ushort)
            'channels (1 for mono (default here), 2 for stereo) (ushort)
            'Sample Rate (44100hz or 22050hz are most common) (uint32)
            'Bits/sample (sample rate * block align, but IMA ADPCM generally is samplerate / 2 because i don't understand (uint32)
            'block align (2048 (0x0008) for streams, otherwise just 2 (0x02) (ushort)
            'bits/sample (varies, default 4 for IMA ADPCM, 16 for PCM16, however I can only get some streams to work when I use 1...
            'there's some bytes here in sample files called format chunk that I have no clue what they are

            'optional chunks (IMA ADPCM)
            'fact
            '4byte (or more if you have more info) (0x04) (uint32)
            'uncompressed size (uint32)



            'Generate wav header
            Dim bufsize As UInt32 = Size + 28 'size of header+file
            Dim SampleRatex2 As UInt32 = SampleRate * 2 '? theoretical bits/sample
            Dim RIFFsize As Byte() = BitConverter.GetBytes(bufsize) 'size of file in bytes
            Dim ByteSize As Byte() = BitConverter.GetBytes(Size) 'size of data in bytes
            Dim ByteSampleRate As Byte() = BitConverter.GetBytes(SampleRate)
            Dim ByteSampleRatex2 As Byte() = BitConverter.GetBytes(SampleRatex2)

            'VB doesn't like byte() to byte, so we're just going to eat up more memory here and make more variables, read up above to know what this means
            Dim wavHeader As Byte() = {82, 73, 70, 70} ', RIFFsize, 87, 65, 86, 69, 102, 109, 116, 16, 0, 0, 0, 1, 0, 1, 0, ByteSampleRate, ByteSampleRatex2, 2, 0, 1, 0, 100, 97, 116, 97, ByteSize}
            Dim wavHeader2 As Byte() = {87, 65, 86, 69, 102, 109, 116, 32, 16, 0, 0, 0, 1, 0, 1, 0}
            Dim wavHeader3 As Byte() = {2, 0, 16, 0, 100, 97, 116, 97}

            'rawr concatentation - RIP readability
            Dim totalHeader As Byte() = wavHeader.Concat(RIFFsize).Concat(wavHeader2).Concat(ByteSampleRate).Concat(ByteSampleRatex2).Concat(wavHeader3).Concat(ByteSize).ToArray()

            Return totalHeader 'return byte array
        ElseIf HeaderType = "wavIPCM" Or HeaderType = "wavxPCM" Then 'ima adpcm for stream files, xbox adpcm is REALLY close to this

            'Generate wav header
            Dim bufsize As UInt32 = Size + 40
            Dim SampleRatediv2 As UInt32 = SampleRate / 2
            'Dim resampleSize As UInt32 = SampleRate * 4 'Currently janking this at *4, but technically it's somewhere - it's ima adpcm so it's *4, but I removed as not necessary
            Dim RIFFsize As Byte() = BitConverter.GetBytes(bufsize)
            Dim ByteSize As Byte() = BitConverter.GetBytes(Size)
            Dim ByteSampleRate As Byte() = BitConverter.GetBytes(SampleRate)
            Dim ByteSampleRatediv2 As Byte() = BitConverter.GetBytes(SampleRatediv2)
            Dim wavHeader2, wavheader3 As Byte()

            'Dim factSize As Byte() = BitConverter.GetBytes(resampleSize)

            'VB doesn't like byte() to byte, so we're just going to eat up more memory here and make more variables
            Dim wavHeader As Byte() = {82, 73, 70, 70} ', RIFFsize, 87, 65, 86, 69, 102, 109, 116, 16, 0, 0, 0, 1, 0, 1, 0, ByteSampleRate, ByteSampleRatex2, 2, 0, 1, 0, 100, 97, 116, 97, ByteSize}
            If Channel = 2 Then 'stereo
                If HeaderType = "wavxPCM" Then
                    wavHeader2 = {87, 65, 86, 69, 102, 109, 116, 32, 20, 0, 0, 0, 105, 0, 2, 0}
                Else
                    wavHeader2 = {87, 65, 86, 69, 102, 109, 116, 32, 20, 0, 0, 0, 17, 0, 2, 0} 'stereo
                End If
                wavheader3 = {72, 0, 4, 0, 2, 0, 64, 0} 'blocksize to 72
            Else 'theoretically mono, but we'll be safe for now
                If HeaderType = "wavxPCM" Then
                    wavHeader2 = {87, 65, 86, 69, 102, 109, 116, 32, 20, 0, 0, 0, 105, 0, 1, 0}
                Else
                    wavHeader2 = {87, 65, 86, 69, 102, 109, 116, 32, 20, 0, 0, 0, 17, 0, 1, 0}
                End If
                wavheader3 = {36, 0, 4, 0, 2, 0, 64, 0}
            End If
            Dim wavHeader4 As Byte() = {100, 97, 116, 97} 'DATA

            'rawr concatentation - RIP readability
            Dim totalHeader As Byte() =
                       wavHeader.
                Concat(RIFFsize).
                Concat(wavHeader2).
                Concat(ByteSampleRate).
                Concat(ByteSampleRatediv2).
                Concat(wavheader3).
                Concat(wavHeader4).
                Concat(ByteSize).ToArray()

            Return totalHeader 'return byte array
        ElseIf HeaderType = "bik" Then
            'RIP this. biks stored byte for byte.

            'bik header info, copied from wiki.multimedia.cx
            'bytes 0-2     file signature ('BIK', or 'KB2' for Bink Video 2)
            'Byte 3        Bink Video codec revision (0x69, version i for BF1)
            ' bytes 4 - 7     file size Not including the first 8 bytes
            'bytes 8 - 11    number of frames (600 in ATAT_screen, 712 bes1fly)
            'bytes 12 - 15   largest frame size in bytes (63804, 62204)
            'bytes 16 - 19   number of frames again? (same as above)
            'bytes 20 - 23   video width (less than Or equal to 32767)  (800, like in 800x600)
            'bytes 24 - 27   video height (less than Or equal to 32767) (600, like in 800x600)
            'bytes 28 - 31   video frames per second dividend (2997 for both)
            'bytes 32 - 35   video frames per second divider (100 for both)
            'bytes 36 - 39   video flags (all 0)
            '  bits 28 - 31: width And height scaling  (last byte)
            '1 = 2x height doubled
            '2 = 2x height interlaced
            '3 = 2x width doubled
            '4 = 2x width And height-doubled
            '5 = 2x width And height-interlaced
            '        bit 20: has alpha plane
            '  bit 17: grayscale
            '  bytes 40 - 43   number of audio tracks (less than Or equal to 256) (01 for audio

            'Generate bik header
            Return 0
        ElseIf HeaderType = "vag" Or HeaderType = "tcwvag" Then
            'Generate wav header
            Dim wavHeader2, wavheader3 As Byte()

            'Dim factSize As Byte() = BitConverter.GetBytes(resampleSize)

            'VB doesn't like byte() to byte, so we're just going to eat up more memory here and make more variables
            Dim wavHeader As Byte() = {86, 65, 71, 112, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 24, 144, 0, 0, 86, 34, 255, 255, 255, 255, 0, 16, 0, 0, 0, 0, 0, 0} ', VAG, then file name
            wavHeader2 = {65, 73, 67, 79, 77, 50, 48, 52}
            wavheader3 = {46, 118, 97, 103, 0, 0, 0, 0}

            Dim filename As String = Name

            'rawr concatentation - RIP readability
            'Dim totalHeader As Byte() = wavHeader.Concat(Name).Concat(wavHeader2)
            Dim totalHeader As Byte() = wavHeader.Concat(wavHeader2).Concat(wavheader3).ToArray()

            Return totalHeader 'return byte array
        Else
            Return 0
            Exit Function
        End If
    End Function

    Sub UpdateProjectLog(ByVal projlog As String)
        'this updates the project log.  new log is generated on run
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("log.txt", True)
        file.Write(projlog)
        file.Close()
    End Sub
    Public Sub Main()

#Region "CommandLineParameters"
        'Get the values of the command line in an array
        ' Index  Discription
        ' 0      Full path of executing prograsm with program name
        ' 1      First switch in command in your example -t
        ' 2      First value in command in your example text1
        ' 3      Second switch in command in your example -s
        ' 4      Second value in command in your example text2
        Dim clArgs() As String = Environment.GetCommandLineArgs()
        Dim sndfile As String ' = "shell.lvl" 'lvl to extract sound/fmv
        Dim platform As String = "pc" 'pc/ps2/xbox
        Dim version As String = "bf1" 'bf1/bf2
        ' Hold the command line values
        ' Dim type As String = String.Empty
        ' Test to see if two switchs and two values were passed in
        ' if yes parse the array
        If clArgs.Count() > 2 Then
            If clArgs(1) = "-i" Then
                sndfile = clArgs(2).ToLower()
                If sndfile = Nothing Then
                    Console.WriteLine("You didn't enter a file")
                    Exit Sub
                End If
                If Not My.Computer.FileSystem.FileExists(sndfile) Then
                    Console.WriteLine("File does not exist.  Please make sure you have the file name with extension (e.g. shell.lvl)")
                    Exit Sub
                End If
            Else
                Console.WriteLine("Please enter the correct argument")
                Exit Sub
            End If

            If clArgs.Count > 4 Then
                If clArgs(3) = "-p" Then
                    platform = clArgs(4).ToLower()
                    If platform <> "pc" And platform <> "ps2" And platform <> "xbox" Then
                        Console.WriteLine("Please select a valid platform: pc, ps2, xbox")
                        Exit Sub
                    End If
                ElseIf clArgs(3) = "-v" Then
                    version = clArgs(4).ToLower()
                    If version <> "bf1" And version <> "bf2" And version <> "tcw" Then
                        Console.WriteLine("Please select a valid game: bf1, bf2, tcw")
                        Exit Sub
                    End If
                Else
                    Console.WriteLine("Please enter the correct argument")
                    Exit Sub
                End If
            End If

            If clArgs.Count > 6 Then
                If clArgs(5) = "-v" Then
                    version = clArgs(6).ToLower()
                    If version <> "bf1" And version <> "bf2" And version <> "tcw" Then
                        Console.WriteLine("Please select a valid game: bf1, bf2, tcw")
                        Exit Sub
                    End If
                Else
                    Console.WriteLine("Please enter the correct argument")
                    Exit Sub
                End If
            End If
        Else
            Console.WriteLine("
This program was designed to extract raw sound and full motion videos from Pandemic's BF1 and BF2 and The Clone Wars.
Options are -i *filename* -p *pc/ps2/xbox* -v *bf1/bf2/tcw* currently
All switches must be in order -i -p -v, but only i is required.  Defaults are pc and bf1.

Use Example: SoundRipperVB.exe -i cw.lvl -p ps2 -v bf1

To convert extracted sound files into a usable sound format use 'ffmpeg.exe' like this:

 ffmpeg.exe -y -i file_name.vag file_name.wav 

You can download binary releases of 'ffmpeg.exe' at https://github.com/BtbN/FFmpeg-Builds/releases

Please read the included readme for various file extraction types")


            Exit Sub
        End If
        'Next
        'End If

        ' Console.WriteLine(type)
        ' Console.ReadLine()
#End Region


#Region "Body"
#Region "variables"
        System.IO.File.WriteAllText("log.txt", "")
        addlinetoprojectlog = "Parsing " & sndfile & " for " & platform & vbCr
        UpdateProjectLog(addlinetoprojectlog)



        'Credit Sleepkiller for Dictionary
        Dim wavtype, filelistext As String
        Dim filetype As String = sndfile.Substring(sndfile.Length - 4).ToLower()
        Dim sndfilewoext As String = sndfile.Substring(0, sndfile.Length - 4) 'sound file without extension
        System.IO.File.WriteAllText(sndfilewoext & ".sfx", "")

        'TCW - default file
        If filetype = ".msb" Then
            filetype = ".msh"
            sndfile = sndfile.Substring(0, sndfile.Length - 4) & ".msh"
            UpdateProjectLog("Corrected msb to msh for " & sndfile)
        End If

        UpdateProjectLog("Filetype " & filetype & vbCr)
        'This code is pretty arbitrary with what it picks for the dissection type.  It's good enough for now
        If filetype = ".lvl" Or filetype = ".str" Then
            If platform = "ps2" Then
                wavtype = "vag"
            ElseIf platform = "xbox" Then
                wavtype = "wavxPCM"
            Else
                wavtype = "wavIPCM"
            End If
            filelistext = ".stm"
        ElseIf filetype = ".mvs" Then
            If platform = "ps2" Then
                wavtype = "pss"
            ElseIf platform = "xbox" Then
                wavtype = "xmv"
            Else
                wavtype = "bik"
            End If
            filelistext = ".mlst"
        ElseIf filetype = ".msh" Then 'or msb
            'TCW code, only support PS2 currently
            If platform = "ps2" Then
                wavtype = "tcwvag"
            Else
                wavtype = "tcwvag"
            End If
            filelistext = ".tcwsfx"
        Else
            wavtype = "wavPCM16"
            filelistext = ".sfx"
        End If

        Dim SearchStart As Byte()
        Dim dataWrapper As Byte()

        'give us a starting search point
        'Looks for the "Size" header for each one specifically then goes from there
        If wavtype = "bik" Then
            SearchStart = {66, 73, 75, 105}
            dataWrapper = {}
        ElseIf wavtype = "pss" Then
            SearchStart = {21, 54, 208, 131}
            dataWrapper = {165, 226, 114, 216}
        ElseIf wavtype = "xmv" Then
            SearchStart = {21, 54, 208, 131}
            dataWrapper = {165, 226, 114, 216}
        ElseIf wavtype = "tcwvag" And filetype = ".msh" Then
            SearchStart = {34, 86, 0, 0} 'not really correct but ah well.  Only one file for wavs i see
            dataWrapper = {0}
        Else
            SearchStart = {92, 217, 160, 35}
            dataWrapper = {165, 226, 114, 216}
        End If

        'variable inits
        Dim Startindex = 0
        Dim Endindex = 1
        Dim bFound As Boolean = True

        Dim fileCounter As Integer = 0
        Dim pos As Integer = 0
        Dim encoding As New System.Text.ASCIIEncoding

        Dim wavByte(), sampleByte() As Byte
        Dim nameHash As UInt32
        Dim wavSize, sampleRate, wavinbankint, channel As Integer
        Dim header, newWavFile, bytedata, wavinbankbyte, channelbyte As Byte()
        Dim wavname, extractedname As New String("")
        Dim overallcounter = 0
        Dim savePosition(databankcount) As Integer

        Console.WriteLine("Processing file: " & sndfile)

        'dataPosition for later, not needed for bik since they are stored with their header intact
        If wavtype <> "bik" And wavtype <> "tcwvag" Then
            savePosition = FindDataStart(sndfile, dataWrapper)
        End If


        'file functions
        If (Not System.IO.Directory.Exists(sndfilewoext)) Then
            My.Computer.FileSystem.CreateDirectory(sndfilewoext)
        End If
        Dim b() As Byte = IO.File.ReadAllBytes(sndfile) 'read file as array of bytes 
        Dim fs As New IO.FileStream(sndfile, IO.FileMode.Open)
        Dim binary_reader As New IO.BinaryReader(fs)

#End Region
        If wavtype = "bik" Then
#Region "PC Movie File"
            For i As Integer = 0 To b.Length - SearchStart.Length - 1
                If b(i) = SearchStart(0) Then
                    bFound = True
                    For j As Integer = 0 To SearchStart.Length - 1
                        If b(i + j) <> SearchStart(j) Then
                            bFound = False
                            Exit For
                        End If
                    Next
                    If bFound Then
                        'Check to make sure it really is what we want
                        'bugfix created 2/4/20 - shell.mvs BF1 gave a false positive in one video, generating an outlandish garbage file.
                        fs.Position = i - 1
                        If binary_reader.ReadByte() <> 0 And fileCounter > 0 Then
                            UpdateProjectLog("False Positive" & vbCr)
                        Else

                            fileCounter += 1 'start at 1, count up
                            'Read size of bik, convert to Uint32
                            fs.Position = i + 4
                            wavByte = binary_reader.ReadBytes(4)
                            wavSize = BitConverter.ToUInt32(wavByte, 0)
                            wavSize += 8

                            'Read raw bik data
                            fs.Position = i
                            bytedata = binary_reader.ReadBytes(wavSize)

                            addlinetoprojectlog = wavtype & " video header found at byte: " & i & " Size: " & wavSize & vbCr
                            UpdateProjectLog(addlinetoprojectlog)

                            wavname = sndfile.Substring(0, sndfile.Length - 4) & "\movie" + fileCounter.ToString() + "." + wavtype

                            'write said file
                            My.Computer.FileSystem.WriteAllBytes(wavname, bytedata, False)

                            Startindex = i
                        End If
                    End If
                End If
                'End If
            Next
#End Region
#Region "TCW Files"
        ElseIf wavtype = "tcwvag" Then
            For i As Integer = 0 To b.Length - SearchStart.Length - 1 'if it doesn't find searchstart, keep going
                If b(i) = SearchStart(0) Then
                    bFound = True
                    For j As Integer = 0 To SearchStart.Length - 1
                        If b(i + j) <> SearchStart(j) Then
                            bFound = False
                            Exit For
                        End If
                    Next
                    If bFound Then 'when it finds search start
                        fileCounter += 1 'start at 1, count up

                        'Read size of wave, convert to Uint32
                        fs.Position = i - 12
                        wavByte = binary_reader.ReadBytes(4)
                        wavSize = BitConverter.ToUInt32(wavByte, 0)

                        'store save position, probably meh
                        fs.Position = i - 4
                        ReDim Preserve savePosition(fileCounter)
                        savePosition(fileCounter) = BitConverter.ToUInt32(binary_reader.ReadBytes(4), 0) 'i got lazy And combined the two things up above

                        UpdateProjectLog(String.Format("Data start at byte 0x{0:x} for file {1}" & vbCr, savePosition(fileCounter), fileCounter))
                        'UpdateProjectLog("Data start at byte " & savePosition(fileCounter) & " for file " & fileCounter & vbCr)


                        'addlinetoprojectlog = wavtype & " header found at byte: " & i & " Size: " & wavSize & vbCr
                        addlinetoprojectlog = String.Format("{0} header found at byte: 0x{1:x} Size: {2}", wavtype, i, wavSize) & vbCr
                        UpdateProjectLog(addlinetoprojectlog)

                        'Future me: Please fix this, I'm tired and this is really, really not efficient. 1/21/20
                        'I would prefer array storage of the values (opening each file only once), but that really doesn't fit in the current framework. Gonna have to rewrite some stuff
                        'I feel like a real programmer now.
                        fs.Close()
                        binary_reader.Close()
                        fs = New IO.FileStream(sndfile.Substring(0, sndfile.Length - 4) & ".msb", IO.FileMode.Open)
                        binary_reader = New IO.BinaryReader(fs)
                        fs.Position = savePosition(fileCounter) 'This was not the original intent of this variable, but it's wasted otherwise...
                        bytedata = binary_reader.ReadBytes(wavSize)
                        fs.Close()
                        binary_reader.Close()
                        fs = New IO.FileStream(sndfile, IO.FileMode.Open)
                        binary_reader = New IO.BinaryReader(fs)

                        'What that code just did was close the first file (.msh) with all the info, open the .msb file, rip out the data it needs, then re-open the old file.
                        'END bad code section.

                        'file generator code
                        'put some defaults in here to avoid null exceptions
                        extractedname = "tcwwav"
                        sampleRate = 22050
                        channel = 1

                        header = AddHeader(wavtype, wavSize, sampleRate, channel, extractedname)
                        newWavFile = header.Concat(bytedata).ToArray()
                        If wavtype = "tcwvag" Then
                            wavname = sndfile.Substring(0, sndfile.Length - 4) & "\tcwsound" & fileCounter & ".vag"
                        Else
                            wavname = sndfile.Substring(0, sndfile.Length - 4) & "\tcwsound" & fileCounter & ".vag"
                        End If

                        'write said file
                        My.Computer.FileSystem.WriteAllBytes(wavname, newWavFile, False)
                        'End If
                        Startindex = i
                    End If
                End If
            Next
#End Region
        Else
#Region "Sound Code (And pss)"
            For i As Integer = 0 To b.Length - SearchStart.Length - 1 'if it doesn't find searchstart, keep going
                If b(i) = SearchStart(0) Then
                    bFound = True
                    For j As Integer = 0 To SearchStart.Length - 1
                        If b(i + j) <> SearchStart(j) Then
                            bFound = False
                            Exit For
                        End If
                    Next
                    If bFound Then 'when it finds search start
                        fileCounter += 1 'start at 1, count up
                        overallcounter += 1
                        If fileCounter = 1 And wavtype <> "pss" And wavtype <> "xmv" Then
                            'skip 1, its the loneliest number
                            'Actually, the first number in a bank is the overall size of the bank with the amount of wavs in it
                            fs.Position = i - 4
                            wavinbankbyte = binary_reader.ReadBytes(4) ' there are files with two banks.  darn coding
                            wavinbankint = BitConverter.ToUInt32(wavinbankbyte, 0) 'read amount of wavs in bank

                            'read channel
                            fs.Position = i - 20 'channel pos
                            channelbyte = binary_reader.ReadBytes(2) 'ushort
                            channel = BitConverter.ToUInt16(channelbyte, 0)

                            UpdateProjectLog(wavinbankint & " " & wavtype & " in bank at " & i & " Num channels: " & channel & vbCr)
                        Else

                            'Read samplerate, convert to uint32
                            If wavtype <> "pss" And wavtype <> "xmv" Then
                                fs.Position = i - 4
                                sampleByte = binary_reader.ReadBytes(4)
                                sampleRate = BitConverter.ToUInt32(sampleByte, 0)
                            End If

                            'Read size of wave, convert to Uint32
                            fs.Position = i + 4
                            wavByte = binary_reader.ReadBytes(4)
                            wavSize = BitConverter.ToUInt32(wavByte, 0)

                            'ghetto byte storage for reverse hash
                            fs.Position = i - 12
                            nameHash = binary_reader.ReadUInt32()

                            extractedname = HashHelper.GetStringFromHash(nameHash)
                            If String.IsNullOrEmpty(extractedname) Then
                                extractedname = Hex(nameHash)
                            End If

                            UpdateProjectLog("Name: " & extractedname & vbCr)

                            Dim skip As Boolean = False
                            ' 2 values seem to tell us if we should skip the sound entry.
                            ' if value at i+0x18 == 0x7d268157, we skip (on common.bnk or  console files )
                            ' if value at i+0x14 == 0x00000000, we skip (on platform==pc And Not common.bnk)
                            ' -BAD_AL
                            fs.Position = (i + &H14)
                            Dim skipCheck2 As UInt32 = binary_reader.ReadUInt32()
                            Dim skipCheck1 As UInt32 = binary_reader.ReadUInt32()


                            If skipCheck1 = &H7D268157 And platform <> "pc" Then
                                skip = True
                            ElseIf platform = "pc" Then
                                If sndfile.EndsWith("common.bnk", StringComparison.OrdinalIgnoreCase) Then
                                    If skipCheck1 = &H7D268157 Then
                                        skip = True
                                    End If
                                ElseIf sndfile.EndsWith("global.lvl", StringComparison.OrdinalIgnoreCase) Then
                                    ' global.lvl doesn't seem to do the skip thing (but does have some files where skipCheck2 == 0 and the sound is in there)
                                ElseIf skipCheck2 = 0 Then
                                    skip = True
                                End If
                            End If

                            'Read raw data
                            'If wavtype = "xmv" Then
                            'fs.Position = savePosition(pos) - 12 'xobX twelve after start
                            'Else
                            fs.Position = savePosition(pos)
                            'End If

                            If wavtype = "pss" And overallcounter > 1 Then
                                fs.Position += 2044 'buffer for pss files
                            ElseIf (wavtype = "wavIPCM" Or (wavtype = "wavxPCM" And channel <= 2)) And overallcounter > 1 Then 'not in bnk?  .lvl aligned by block size
                                'This mess above accounts for PC compressed streams AND xbox compressed streams (and discounts the ones that aren't streams because of channel)
                                Dim blocksize = 2048  'defined in req
                                'UpdateProjectLog(((savePosition(pos) + wavSize) Mod blocksize) & vbCr)  'reactivate if block size seems goofy
                                If ((savePosition(pos) + wavSize) Mod blocksize) <> 0 Then
                                    'if a file falls right on a multiple of 2048, we don't run this code.  Think about it 2048 - (2048Mod2048) or 0 = 2048, arbitrarily adding 2048 bytes when not needed.
                                    wavSize += (blocksize - ((savePosition(pos) + wavSize) Mod blocksize))
                                End If
                            ElseIf wavtype = "vag" And overallcounter > 1 And channel <= 2 Then 'channel > 2 = not a stream
                                Dim blocksize = 16384 'defined 49152
                                If wavSize Mod blocksize <> 0 Then
                                    wavSize += (blocksize - ((wavSize) Mod blocksize)) 'PS2 vag is NOT relative to the overall file like PC
                                End If
                            End If

                            If skip = False Then
                                If ((fs.Position + wavSize) > binary_reader.BaseStream.Length) Then
                                    Dim msg As String = String.Format(
                                            "Attempt to read past the end of the data:0x{0:x8}, length:0x{1:x8} bytes on '{2}'",
                                            (fs.Position + wavSize), binary_reader.BaseStream.Length, extractedname)
                                    UpdateProjectLog(msg)
                                    Console.WriteLine(msg)
                                    Return
                                End If
                                UpdateProjectLog(String.Format("Data start at byte 0x{0:x} for file {1}" & vbCr, fs.Position, overallcounter))
                                'UpdateProjectLog("Data start at byte " & fs.Position & " for file " & overallcounter & vbCr)
                                bytedata = binary_reader.ReadBytes(wavSize) 'read wav data
                                savePosition(pos) = fs.Position 'save position in wav for later
                                'addlinetoprojectlog = wavtype & " header found at byte: " & i & " Size: " & wavSize & " Sample Rate: " & sampleRate & vbCr
                                addlinetoprojectlog = String.Format("{0} header found at byte: 0x{1:x}  Size: {2}  Sample Rate: {3} ", wavtype, i, wavSize, sampleRate) & vbCr
                                UpdateProjectLog(addlinetoprojectlog)
                            Else
                                bytedata = {}
                                UpdateProjectLog(String.Format("I think we need to skip this one: {0}", extractedname) & vbCr)
                            End If

                            'file generator code
                            'PSS and XMV do not need a header
                            If wavtype = "pss" Then
                                newWavFile = bytedata
                                wavname = sndfilewoext & "\ps2movie" + overallcounter.ToString() + ".pss"
                            ElseIf wavtype = "xmv" Then
                                newWavFile = bytedata
                                wavname = sndfilewoext & "\xboxmovie" + overallcounter.ToString() + ".xmv"
                            Else
                                header = AddHeader(wavtype, wavSize, sampleRate, channel, extractedname) 'I pass extracted name through but may ignore it because it doesn't matter for vag...
                                newWavFile = header.Concat(bytedata).ToArray()
                                If wavtype = "vag" Then
                                    wavname = sndfilewoext & "\" + extractedname + ".vag"
                                Else
                                    wavname = sndfilewoext & "\" + extractedname + ".wav"
                                End If
                            End If

                            'Useless code, dupes are weird.
                            'If (System.IO.File.Exists(wavname)) Then
                            'If (wavtype = "wavIPCM" Or wavtype = "wavxPCM") Then
                            'wavname = wavname.Substring(0, wavname.Length - 4) + overallcounter.ToString() + ".wav"
                            'Else
                            'wavname = wavname.Substring(0, wavname.Length - 4) + overallcounter.ToString() + "." + wavtype
                            'End If
                            'End If
                            'write said file
                            If skip = False Then
                                My.Computer.FileSystem.WriteAllBytes(wavname, newWavFile, False)
                                'write .sfx file
                                Dim entry As String
                                entry = String.Format("{0}   -resample {1} {2} {3} ", wavname, platform, RoundSampleRate(sampleRate), vbCr)
                                My.Computer.FileSystem.WriteAllText(sndfilewoext & filelistext, entry, True)
                                'End If
                            End If

                            Startindex = i

                            If fileCounter - 1 = wavinbankint Then
                                fileCounter = 0  'reset file counter for bank
                                If databankcount > pos Then
                                    pos = pos + 1    'for our saveposition bank array
                                End If
                            End If

                        End If

                    End If
                End If
            Next

            Dim newlength = Endindex - Startindex
            For i = Startindex To Endindex
                'currently just grabs the position numbers, want character at that position number
                Dim ss As String = System.Text.Encoding.GetEncoding(1252).GetString(encoding.GetBytes(i))
                addlinetoprojectlog = ss & vbCr
                UpdateProjectLog(addlinetoprojectlog)
            Next
#End Region
        End If

        fs.Close()
        binary_reader.Close()
#End Region
        WriteConvertBatchFile(sndfilewoext)
    End Sub

    Private Sub WriteConvertBatchFile(ByVal extractDir As String)
        Dim dinfo As DirectoryInfo = New DirectoryInfo(extractDir)
        Dim fileInfos As FileInfo() = dinfo.GetFiles("*.wav")

        If (fileInfos.Count = 0) Then
            fileInfos = dinfo.GetFiles("*.vag")
        End If
        If (fileInfos.Count > 0) Then
            Dim outDir = extractDir & "_PCM16\\"
            Dim outName As String

            Dim builder As StringBuilder = New StringBuilder(30 * fileInfos.Count)
            builder.Append(":: Converts your output to PCM16" & vbCrLf)
            builder.Append(":: see more ffmpg commands at: https://ostechnix.com/20-ffmpeg-commands-beginners/" & vbCrLf)
            builder.Append(":: get ffmpeg at: https://github.com/BtbN/FFmpeg-Builds/releases " & vbCrLf)
            builder.Append(":: Create the Convert Folder" & vbCrLf)
            builder.Append(String.Format("mkdir {0} {1}", outDir, vbCrLf))
            builder.Append(":: Convert Files " & vbCrLf & vbCrLf)


            For i = 0 To fileInfos.Count - 1
                outName = fileInfos(i).Name.Replace(".vag", ".wav")
                builder.Append(String.Format("ffmpeg.exe -y -i {0} {1}{2} {3}",
                            fileInfos(i).FullName, outDir, outName, vbCrLf))
            Next
            Dim batchFileName = String.Format("{0}_Convert_PCM.bat", extractDir)
            batchFileName = batchFileName.Replace("\", "_")
            File.WriteAllText(batchFileName, builder.ToString())
            Console.WriteLine("You can run the generated file: {1}  {0}{1}to convert your sound files (ffmpeg.exe required)", Path.GetFullPath(batchFileName), vbCrLf)
        End If


    End Sub

    Private Function RoundSampleRate(ByVal sampleRate As Int32) As Int32
        Dim numbers = New Int32() {8000, 11025, 16000, 22050, 44100, 48000} ' in Hz
        Dim retVal As Int32 = sampleRate
        Dim closest As Int32 = 100000
        Dim test As Int32 = 100000
        For i = 0 To numbers.Length - 1
            test = Math.Abs(numbers(i) - sampleRate)
            If test < closest Then
                retVal = numbers(i)
                closest = test
            End If
        Next
        Return retVal

    End Function
End Module

