Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports System.Text

Public Class HashHelper
    ' Methods
    Private Shared Sub AddHashedString(ByVal value As String)

        Try
            Dim key As UInt32 = HashHelper.HashString(value)
            If Not HashHelper.sHashes.ContainsKey(key) Then
                HashHelper.sHashes.Add(key, value)
            End If
        Catch exception As Exception
            Console.WriteLine("AddHashedString: Could not add " & value)
        End Try

    End Sub

    Public Shared Function GetStringFromHash(ByVal hash As UInt32) As String
        Dim str As String = Nothing
        If IsNothing(HashHelper.sHashes) Then
            HashHelper.ReadDictionary()
        End If
        If HashHelper.sHashes.ContainsKey(hash) Then
            str = HashHelper.sHashes(hash)
        Else
            Console.WriteLine("Could not find string for: 0x{0:x}", hash)
        End If
        Return str
    End Function

    ' For this function to work, we need to disable the 'integer overflow checks' in the VB project compile options
    ' https://www.daniweb.com/programming/software-development/threads/261401/overflow-exception-very-large-numbers
    Public Shared Function HashString(ByVal input As String) As UInt32
        Dim FNV_prime As UInt32 = 16777619
        Dim offset_basis As UInt32 = 2166136261
        Dim hash As UInt32 = offset_basis
        Dim c As Byte = 0
        Dim ch As Char
        For Each ch In input
            c = Convert.ToByte(ch)
            c = c Or &H20
            hash = hash Xor c
            hash = hash * FNV_prime
        Next
        Return hash
    End Function

    Private Shared Sub ReadDictionary()
        Dim reader As StreamReader = Nothing
        Dim line As String = ""
        Dim fileName As String = My.Application.Info.DirectoryPath & "\" & DictionaryFile
        HashHelper.sHashes = New Dictionary(Of UInt32, String)(500)
        Try
            If (File.Exists(fileName)) Then 'use the dictionary if present, otherwise use the embedded dictionary.
                Console.WriteLine("  Reading dictionary " & fileName)
                reader = My.Computer.FileSystem.OpenTextFileReader(fileName, Encoding.ASCII)
            Else
                Console.WriteLine("  .\Dictionary.txt not found, Using internal dictionary ")
                Dim assembly As Assembly = Assembly.GetExecutingAssembly()
                ' when debugging use the line below to look through the different resources in 'resourceNames' to see the name of the target resource
                'Dim resourceNames As String() = assembly.GetManifestResourceNames() 
                reader = New StreamReader(assembly.GetManifestResourceStream("SoundRipperVB.dictionary.txt"))
            End If

            Do
                line = reader.ReadLine
                If Not String.IsNullOrEmpty(line) Then
                    HashHelper.AddHashedString(line)
                End If
            Loop Until line Is Nothing

        Catch exception As Exception
            Console.WriteLine(("Error processing file " & fileName & "\n" & exception.Message))
        Finally
            If Not IsNothing(reader) Then
                reader.Close()
            End If
        End Try
        Console.WriteLine("Done Reading dictionary.")
    End Sub


    ' Fields
    Private Const DictionaryFile As String = "Dictionary.txt"
    Private Shared sHashes As Dictionary(Of UInt32, String) = Nothing
End Class
