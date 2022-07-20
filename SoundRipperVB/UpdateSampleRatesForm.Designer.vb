<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateSampleRatesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateSampleRatesForm))
        Me.textFolderName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textSfxFileName = New System.Windows.Forms.TextBox()
        Me.btnUpdateRates = New System.Windows.Forms.Button()
        Me.btnBrowseSoundFolder = New System.Windows.Forms.Button()
        Me.btnBrowseSfx = New System.Windows.Forms.Button()
        Me.checkSfx = New System.Windows.Forms.CheckBox()
        Me.checkStm = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommandLineUsageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'textFolderName
        '
        Me.textFolderName.AllowDrop = True
        Me.textFolderName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textFolderName.Location = New System.Drawing.Point(24, 63)
        Me.textFolderName.Name = "textFolderName"
        Me.textFolderName.Size = New System.Drawing.Size(494, 26)
        Me.textFolderName.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Sound Folder To Update"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(263, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = ".sfx/.stm file containing sample rates"
        '
        'textSfxFileName
        '
        Me.textSfxFileName.AllowDrop = True
        Me.textSfxFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textSfxFileName.Location = New System.Drawing.Point(24, 141)
        Me.textSfxFileName.Name = "textSfxFileName"
        Me.textSfxFileName.Size = New System.Drawing.Size(494, 26)
        Me.textSfxFileName.TabIndex = 7
        '
        'btnUpdateRates
        '
        Me.btnUpdateRates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateRates.Location = New System.Drawing.Point(317, 228)
        Me.btnUpdateRates.Name = "btnUpdateRates"
        Me.btnUpdateRates.Size = New System.Drawing.Size(302, 59)
        Me.btnUpdateRates.TabIndex = 9
        Me.btnUpdateRates.Text = "&Update Sample Rates"
        Me.btnUpdateRates.UseVisualStyleBackColor = True
        '
        'btnBrowseSoundFolder
        '
        Me.btnBrowseSoundFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseSoundFolder.Location = New System.Drawing.Point(536, 62)
        Me.btnBrowseSoundFolder.Name = "btnBrowseSoundFolder"
        Me.btnBrowseSoundFolder.Size = New System.Drawing.Size(75, 34)
        Me.btnBrowseSoundFolder.TabIndex = 10
        Me.btnBrowseSoundFolder.Text = "..."
        Me.btnBrowseSoundFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrowseSoundFolder.UseVisualStyleBackColor = True
        '
        'btnBrowseSfx
        '
        Me.btnBrowseSfx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseSfx.Location = New System.Drawing.Point(536, 140)
        Me.btnBrowseSfx.Name = "btnBrowseSfx"
        Me.btnBrowseSfx.Size = New System.Drawing.Size(75, 34)
        Me.btnBrowseSfx.TabIndex = 11
        Me.btnBrowseSfx.Text = "..."
        Me.btnBrowseSfx.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrowseSfx.UseVisualStyleBackColor = True
        '
        'checkSfx
        '
        Me.checkSfx.AutoSize = True
        Me.checkSfx.Checked = True
        Me.checkSfx.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkSfx.Location = New System.Drawing.Point(24, 189)
        Me.checkSfx.Name = "checkSfx"
        Me.checkSfx.Size = New System.Drawing.Size(170, 24)
        Me.checkSfx.TabIndex = 12
        Me.checkSfx.Text = "Replace in .sfx files"
        Me.checkSfx.UseVisualStyleBackColor = True
        '
        'checkStm
        '
        Me.checkStm.AutoSize = True
        Me.checkStm.Location = New System.Drawing.Point(24, 228)
        Me.checkStm.Name = "checkStm"
        Me.checkStm.Size = New System.Drawing.Size(176, 24)
        Me.checkStm.TabIndex = 13
        Me.checkStm.Text = "Replace in .stm files"
        Me.checkStm.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(631, 33)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CommandLineUsageToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(54, 29)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'CommandLineUsageToolStripMenuItem
        '
        Me.CommandLineUsageToolStripMenuItem.Name = "CommandLineUsageToolStripMenuItem"
        Me.CommandLineUsageToolStripMenuItem.Size = New System.Drawing.Size(288, 34)
        Me.CommandLineUsageToolStripMenuItem.Text = "Command Line Usage"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(288, 34)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsageToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(78, 29)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'UsageToolStripMenuItem
        '
        Me.UsageToolStripMenuItem.Name = "UsageToolStripMenuItem"
        Me.UsageToolStripMenuItem.Size = New System.Drawing.Size(164, 34)
        Me.UsageToolStripMenuItem.Text = "About"
        '
        'UpdateSampleRatesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 299)
        Me.Controls.Add(Me.checkStm)
        Me.Controls.Add(Me.checkSfx)
        Me.Controls.Add(Me.btnBrowseSfx)
        Me.Controls.Add(Me.btnBrowseSoundFolder)
        Me.Controls.Add(Me.btnUpdateRates)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.textSfxFileName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textFolderName)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(653, 335)
        Me.Name = "UpdateSampleRatesForm"
        Me.Text = "Update Sample Rates"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textFolderName As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents textSfxFileName As Windows.Forms.TextBox
    Friend WithEvents btnUpdateRates As Windows.Forms.Button
    Friend WithEvents btnBrowseSoundFolder As Windows.Forms.Button
    Friend WithEvents btnBrowseSfx As Windows.Forms.Button
    Friend WithEvents checkSfx As Windows.Forms.CheckBox
    Friend WithEvents checkStm As Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommandLineUsageToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsageToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
