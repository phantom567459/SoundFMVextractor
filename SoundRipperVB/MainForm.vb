Imports System.IO
Imports System.Windows.Forms

Public Class MainForm

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        Dim tip As New ToolTip()
        tip.SetToolTip(textFilename, "Drag a file onto this text box or browse to a file with the '...' button")
    End Sub

    Private Sub textFilename_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles textFilename.DragDrop
        Dim tb As Control = sender
        Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
        If files IsNot Nothing And files.Length = 1 And tb IsNot Nothing Then
            tb.Text = files(0)
        End If
    End Sub

    Private Sub textFilename_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles textFilename.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim dlg As OpenFileDialog = New OpenFileDialog()
        dlg.RestoreDirectory = True
        If dlg.ShowDialog() = DialogResult.OK Then
            textFilename.Text = dlg.FileName
        End If
        dlg.Dispose()
    End Sub

    Private Sub btnRip_Click(sender As Object, e As EventArgs) Handles btnRip.Click
        If Not File.Exists(textFilename.Text) Then
            MessageBox.Show("File Does Not Exist: " & textFilename.Text, "Error")
        Else
            main.sndfile = textFilename.Text

            ' Version
            If btnBF1.Checked Then
                main.version = "bf1"
            ElseIf btnBF2.Checked Then
                main.version = "bf2"
            End If
            ' Platform
            If btnPC.Checked Then
                main.platform = "pc"
            ElseIf btnPS2.Checked Then
                main.platform = "ps2"
            ElseIf btnXBOX.Checked Then
                main.platform = "xbox"
            End If
            'show the equivlent command line
            Console.WriteLine(" SoundRipperVB.exe -i {0} -p {1} -v {2}", main.sndfile, main.platform, main.version)
            Dim convertFile As String = main.Rip()

            ' enable the convert button
            btnConvert.Tag = convertFile
            Dim tip As New ToolTip()
            tip.SetToolTip(btnConvert, "Run batch file: " & convertFile)
            btnConvert.Enabled = True
        End If
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        Dim message As String = "SoundRipperVB
For extracting sounds and FMV from Pandemic's 
  Star Wars Battlefront (2004)
  Star Wars Battlefront II (2005) 
  The Clone Wars (PS2)
Sound files are in .lvl or .bnk format, and are located in 
Gamedata\Data_LVL_platform\Sound. For TCW PS2, file names are .msh/msb. 
Both are accepted, the program figures out what it needs.

This also works on FMVs for PC/PS2/XBOX. All FMVs are located in 
   Gamedata\Data_LVL_platform\Movies.

GitHub: https://github.com/phantom567459/SoundFMVextractor

This program can also be used from the command line. 
Use: SoundRipperVB.exe -help for the command line usage.
"
        MessageBox.Show(message, "About")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub UpdateSampleRatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateSampleRatesToolStripMenuItem.Click
        Dim form As UpdateSampleRatesForm = New UpdateSampleRatesForm()
        form.Show()
    End Sub

    Private Sub WebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebsiteToolStripMenuItem.Click
        Process.Start("https://github.com/phantom567459/SoundFMVextractor")
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        Dim batchFile As String = btnConvert.Tag
        If batchFile <> Nothing Then
            Dim p As Process = New Process()
            p.StartInfo.FileName = batchFile
            p.StartInfo.UseShellExecute = True
            Try
                p.Start()
            Catch ex As Exception
                MessageBox.Show("Exception while starting convert batch file, " & ex.Message)
            End Try
        Else
            MessageBox.Show("Error, 'Convert to PCM' batch file not set, run 'Rip' to set the batch file")
        End If
    End Sub

End Class