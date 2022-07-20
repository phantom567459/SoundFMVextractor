Imports System.IO
Imports System.Text.RegularExpressions

Module SampleRateHelper
    ''' <summary>
    ''' Populates A Dictionary of String - SampleRateMapping pairs from the Given File.
    ''' </summary>
    ''' <param name="fileName">The .sfx/.stm file to get sample rates from</param>
    Public Sub GetSampleRates(fileName As String, rates As Dictionary(Of String, SampleRateMapping))
        If File.Exists(fileName) Then
            Dim regex As Regex = New Regex("([a-zA-Z0-9_]+)(.wav|.vag)\s+-resample\s+(xbox|ps2|pc)\s+([0-9]+)", RegexOptions.IgnoreCase)
            Dim contents As String = File.ReadAllText(fileName)
            Dim matches As MatchCollection = regex.Matches(contents)
            For Each match As Match In matches
                Dim dude As SampleRateMapping = New SampleRateMapping()
                dude.SoundName = match.Groups(1).Value ' make sure this doesn't include the .wav or .vag part
                dude.Platform = match.Groups(3).Value
                dude.SampleRate = Int32.Parse(match.Groups(4).Value)
                If Not rates.ContainsKey(dude.SoundName) Then
                    rates.Add(dude.SoundName, dude)
                    'Console.WriteLine("{0}   {1}   {2}", dude.SoundName, dude.Platform, dude.SampleRate)
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Applies the passed in sample rates to the files under the target folder.
    ''' </summary>
    ''' <param name="directoryName">The target of the replacement sample rates (also works on a filename).</param>
    ''' <param name="rates">The dictionary of sample rates to use.</param>
    ''' <param name="includeSfx">Replace in .sfx files.</param>
    ''' <param name="includeStm">Replace in .stm files.</param>
    Public Sub ApplySampleRatesToFiles(directoryName As String, rates As Dictionary(Of String, SampleRateMapping), includeSfx As Boolean, includeStm As Boolean)
        If Directory.Exists(directoryName) Then
            Dim files As List(Of String) = New List(Of String)()
            If includeSfx Then
                files.AddRange(Directory.GetFiles(directoryName, "*.sfx", SearchOption.AllDirectories))
            End If

            If includeStm Then
                files.AddRange(Directory.GetFiles(directoryName, "*.stm", SearchOption.AllDirectories))
            End If

            For Each file As String In files
                ApplySampleRatesToFile(file, rates)
            Next
        ElseIf File.Exists(directoryName) Then
            ApplySampleRatesToFile(directoryName, rates)
        End If
    End Sub

    ''' <summary>
    ''' Applies the passed in sample rates to the specified file.
    ''' </summary>
    ''' <param name="fileName">The file to apply the sample rates to.</param>
    ''' <param name="rates">The rates to use.</param>
    Public Sub ApplySampleRatesToFile(fileName As String, rates As Dictionary(Of String, SampleRateMapping))
        If File.Exists(fileName) Then
            Dim line As String
            Dim soundName As String
            Dim lines As String() = File.ReadAllText(fileName).Replace(vbCrLf, vbCr).Split(vbCr)
            Dim regex As Regex = New Regex("([\\a-zA-Z0-9_\.]+)[\\]([\\a-zA-Z0-9_\.]+).wav(\s+([a-zA-Z0-9_]+)?\s*(-resample\s+(.*))?)?", RegexOptions.IgnoreCase)
            Dim aliasRegex As Regex = New Regex("-alias\s+(ps2|pc|xbox)")
            Dim specificPlatform As String = ""

            For i As Int32 = 0 To lines.Length - 1
                If lines(i).Trim().StartsWith("//") Then
                    Continue For 'ignore comments
                End If
                line = lines(i)
                Dim match As Match = regex.Match(line)
                If match.Length > 0 Then
                    If match.Groups(4).Value.Length > 0 Then
                        soundName = match.Groups(4).Value
                    Else
                        soundName = match.Groups(2).Value
                    End If
                    If rates.ContainsKey(soundName) Then
                        Dim mapping = rates(soundName)
                        If specificPlatform <> "" And specificPlatform.IndexOf(mapping.Platform) = -1 Then
                            Continue For
                        End If
                        If match.Groups(5).Value.Length > 0 Then
                            ' it already has a -resample directive
                            If match.Groups(5).Value.Contains(mapping.Platform) Then
                                ' it already has a sample rate for this platform, replace it
                                Dim resampleReg = GetPlatformReg(mapping.Platform)
                                line = resampleReg.Replace(line, String.Format("{0} {1}", mapping.Platform, mapping.SampleRate))
                            Else
                                ' the line has a -resample directive, tack one at the end for this platform
                                line = String.Format("{0} {1} {2}", line, mapping.Platform, mapping.SampleRate)
                            End If
                        ElseIf aliasRegex.Match(line).Groups(1).Value <> mapping.Platform Then
                            ' There is no -resample directive, tack one on
                            line = String.Format("{0}    -resample {1} {2}", line, mapping.Platform, mapping.SampleRate)
                        End If
                        lines(i) = line
                    End If
                    ' Handle specific platform
                ElseIf line.IndexOf("#ifplatform") > -1 Then
                    specificPlatform = line.Substring(11)
                ElseIf line.IndexOf("#endifplatform") > -1 Then
                    specificPlatform = ""
                End If
            Next
            Dim content As String = String.Join(vbCrLf, lines)
            Console.WriteLine("Updating File '{0}'", fileName)
            File.WriteAllText(fileName, content)
        Else
            Console.WriteLine("File '{0}' does not exist", fileName)
        End If
    End Sub

    Private Function GetPlatformReg(platform As String)
        If PlatFormReges.Count = 0 Then
            PlatFormReges.Add("pc", New Regex("pc\s+([0-9]+)", RegexOptions.Compiled))
            PlatFormReges.Add("ps2", New Regex("ps2\s+([0-9]+)", RegexOptions.Compiled))
            PlatFormReges.Add("xbox", New Regex("xbox\s+([0-9]+)", RegexOptions.Compiled))
        End If
        Return PlatFormReges(platform)
    End Function

    ' Fields
    Dim PlatFormReges As Dictionary(Of String, Regex) = New Dictionary(Of String, Regex)

End Module

Public Class SampleRateMapping
    ' Fields
    Public SoundName As String = ""
    Public SampleRate As Int32 = 0
    Public Platform As String = ""
End Class