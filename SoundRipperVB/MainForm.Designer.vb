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
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
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
        Me.textFilename.Location = New System.Drawing.Point(52, 30)
        Me.textFilename.Name = "textFilename"
        Me.textFilename.Size = New System.Drawing.Size(428, 26)
        Me.textFilename.TabIndex = 4
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(486, 22)
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
        Me.btnRip.Location = New System.Drawing.Point(432, 215)
        Me.btnRip.Name = "btnRip"
        Me.btnRip.Size = New System.Drawing.Size(129, 59)
        Me.btnRip.TabIndex = 6
        Me.btnRip.Text = "Rip"
        Me.btnRip.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbout.Location = New System.Drawing.Point(432, 90)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(129, 34)
        Me.btnAbout.TabIndex = 7
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 299)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnRip)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.textFilename)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(485, 355)
        Me.Name = "MainForm"
        Me.Text = "Sound Ripper"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents btnAbout As Windows.Forms.Button
End Class
