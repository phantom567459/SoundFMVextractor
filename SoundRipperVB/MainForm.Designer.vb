<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnXBOX = New System.Windows.Forms.RadioButton()
        Me.btnPS2 = New System.Windows.Forms.RadioButton()
        Me.btnPC = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBF2 = New System.Windows.Forms.RadioButton()
        Me.btnBF1 = New System.Windows.Forms.RadioButton()
        Me.textFilename = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnRip = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateSampleRatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.labelStatus = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnXBOX)
        Me.GroupBox1.Controls.Add(Me.btnPS2)
        Me.GroupBox1.Controls.Add(Me.btnPC)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(287, 89)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Platform"
        '
        'btnXBOX
        '
        Me.btnXBOX.AutoSize = True
        Me.btnXBOX.Location = New System.Drawing.Point(191, 35)
        Me.btnXBOX.Name = "btnXBOX"
        Me.btnXBOX.Size = New System.Drawing.Size(79, 24)
        Me.btnXBOX.TabIndex = 2
        Me.btnXBOX.Text = "XBOX"
        Me.btnXBOX.UseVisualStyleBackColor = True
        '
        'btnPS2
        '
        Me.btnPS2.AutoSize = True
        Me.btnPS2.Location = New System.Drawing.Point(104, 35)
        Me.btnPS2.Name = "btnPS2"
        Me.btnPS2.Size = New System.Drawing.Size(64, 24)
        Me.btnPS2.TabIndex = 1
        Me.btnPS2.Text = "PS2"
        Me.btnPS2.UseVisualStyleBackColor = True
        '
        'btnPC
        '
        Me.btnPC.AutoSize = True
        Me.btnPC.Checked = True
        Me.btnPC.Location = New System.Drawing.Point(26, 35)
        Me.btnPC.Name = "btnPC"
        Me.btnPC.Size = New System.Drawing.Size(55, 24)
        Me.btnPC.TabIndex = 0
        Me.btnPC.TabStop = True
        Me.btnPC.Text = "PC"
        Me.btnPC.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBF2)
        Me.GroupBox2.Controls.Add(Me.btnBF1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 185)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(287, 89)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Version"
        '
        'btnBF2
        '
        Me.btnBF2.AutoSize = True
        Me.btnBF2.Location = New System.Drawing.Point(104, 35)
        Me.btnBF2.Name = "btnBF2"
        Me.btnBF2.Size = New System.Drawing.Size(64, 24)
        Me.btnBF2.TabIndex = 1
        Me.btnBF2.Text = "BF2"
        Me.btnBF2.UseVisualStyleBackColor = True
        '
        'btnBF1
        '
        Me.btnBF1.AutoSize = True
        Me.btnBF1.Checked = True
        Me.btnBF1.Location = New System.Drawing.Point(26, 35)
        Me.btnBF1.Name = "btnBF1"
        Me.btnBF1.Size = New System.Drawing.Size(64, 24)
        Me.btnBF1.TabIndex = 0
        Me.btnBF1.TabStop = True
        Me.btnBF1.Text = "BF1"
        Me.btnBF1.UseVisualStyleBackColor = True
        '
        'textFilename
        '
        Me.textFilename.AllowDrop = True
        Me.textFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textFilename.Location = New System.Drawing.Point(52, 44)
        Me.textFilename.Name = "textFilename"
        Me.textFilename.Size = New System.Drawing.Size(428, 26)
        Me.textFilename.TabIndex = 4
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(486, 43)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 34)
        Me.btnBrowse.TabIndex = 5
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnRip
        '
        Me.btnRip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRip.Location = New System.Drawing.Point(432, 225)
        Me.btnRip.Name = "btnRip"
        Me.btnRip.Size = New System.Drawing.Size(129, 59)
        Me.btnRip.TabIndex = 6
        Me.btnRip.Text = "Rip"
        Me.btnRip.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(585, 33)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateSampleRatesToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(54, 29)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'UpdateSampleRatesToolStripMenuItem
        '
        Me.UpdateSampleRatesToolStripMenuItem.Name = "UpdateSampleRatesToolStripMenuItem"
        Me.UpdateSampleRatesToolStripMenuItem.Size = New System.Drawing.Size(284, 34)
        Me.UpdateSampleRatesToolStripMenuItem.Text = "&Update Sample Rates"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(284, 34)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem1, Me.WebsiteToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(78, 29)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(177, 34)
        Me.AboutToolStripMenuItem1.Text = "About"
        '
        'WebsiteToolStripMenuItem
        '
        Me.WebsiteToolStripMenuItem.Name = "WebsiteToolStripMenuItem"
        Me.WebsiteToolStripMenuItem.Size = New System.Drawing.Size(177, 34)
        Me.WebsiteToolStripMenuItem.Text = "Website"
        '
        'btnConvert
        '
        Me.btnConvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConvert.Enabled = False
        Me.btnConvert.Location = New System.Drawing.Point(432, 170)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(129, 34)
        Me.btnConvert.TabIndex = 9
        Me.btnConvert.Text = "Convert"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'labelStatus
        '
        Me.labelStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.labelStatus.AutoSize = True
        Me.labelStatus.Location = New System.Drawing.Point(12, 295)
        Me.labelStatus.Name = "labelStatus"
        Me.labelStatus.Size = New System.Drawing.Size(0, 20)
        Me.labelStatus.TabIndex = 10
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 324)
        Me.Controls.Add(Me.labelStatus)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.btnRip)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.textFilename)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(485, 355)
        Me.Name = "MainForm"
        Me.Text = "Sound Ripper"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents btnXBOX As Windows.Forms.RadioButton
    Friend WithEvents btnPS2 As Windows.Forms.RadioButton
    Friend WithEvents btnPC As Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents btnBF2 As Windows.Forms.RadioButton
    Friend WithEvents btnBF1 As Windows.Forms.RadioButton
    Friend WithEvents textFilename As Windows.Forms.TextBox
    Friend WithEvents btnBrowse As Windows.Forms.Button
    Friend WithEvents btnRip As Windows.Forms.Button
    Friend WithEvents MenuStrip1 As Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateSampleRatesToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebsiteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnConvert As Windows.Forms.Button
    Friend WithEvents labelStatus As Windows.Forms.Label
End Class
