<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.LoadFileButton = New System.Windows.Forms.Button()
        Me.MergeBtn = New System.Windows.Forms.Button()
        Me.LineNumbersCheckBox = New System.Windows.Forms.CheckBox()
        Me.SeparatorLabel = New System.Windows.Forms.Label()
        Me.SeparatorComboBox = New System.Windows.Forms.ComboBox()
        Me.ResultLabel = New System.Windows.Forms.Label()
        Me.ResultLocationTextBox = New System.Windows.Forms.TextBox()
        Me.CopyLocationButton = New System.Windows.Forms.Button()
        Me.OpenFileButton = New System.Windows.Forms.Button()
        Me.HelpButton = New System.Windows.Forms.Button()
        Me.ResultDataGridView = New System.Windows.Forms.DataGridView()
        Me.FilesDataGridView = New System.Windows.Forms.DataGridView()
        Me.SafeFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.File = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CharactersGroup = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MyFileOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ExportedFileTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitLinesCheckBox = New System.Windows.Forms.CheckBox()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.EncodingComboBox = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FILEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FramesRateTextBox = New System.Windows.Forms.TextBox()
        Me.FramesRateLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimingTextBox = New System.Windows.Forms.TextBox()
        Me.TimingComboBox = New System.Windows.Forms.ComboBox()
        Me.RemoveFileButton = New System.Windows.Forms.Button()
        Me.MySaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.EnableVoiceCheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.ResultDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LoadFileButton
        '
        Me.LoadFileButton.Location = New System.Drawing.Point(12, 31)
        Me.LoadFileButton.Name = "LoadFileButton"
        Me.LoadFileButton.Size = New System.Drawing.Size(75, 23)
        Me.LoadFileButton.TabIndex = 1
        Me.LoadFileButton.Text = "Load File"
        Me.LoadFileButton.UseVisualStyleBackColor = True
        '
        'MergeBtn
        '
        Me.MergeBtn.Enabled = False
        Me.MergeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MergeBtn.Location = New System.Drawing.Point(12, 291)
        Me.MergeBtn.Name = "MergeBtn"
        Me.MergeBtn.Size = New System.Drawing.Size(219, 30)
        Me.MergeBtn.TabIndex = 5
        Me.MergeBtn.Text = "Merge"
        Me.MergeBtn.UseVisualStyleBackColor = True
        '
        'LineNumbersCheckBox
        '
        Me.LineNumbersCheckBox.AutoSize = True
        Me.LineNumbersCheckBox.Location = New System.Drawing.Point(304, 228)
        Me.LineNumbersCheckBox.Name = "LineNumbersCheckBox"
        Me.LineNumbersCheckBox.Size = New System.Drawing.Size(129, 17)
        Me.LineNumbersCheckBox.TabIndex = 3
        Me.LineNumbersCheckBox.Text = "Include Line Numbers"
        Me.LineNumbersCheckBox.UseVisualStyleBackColor = True
        '
        'SeparatorLabel
        '
        Me.SeparatorLabel.AutoSize = True
        Me.SeparatorLabel.Location = New System.Drawing.Point(384, 254)
        Me.SeparatorLabel.Name = "SeparatorLabel"
        Me.SeparatorLabel.Size = New System.Drawing.Size(53, 13)
        Me.SeparatorLabel.TabIndex = 4
        Me.SeparatorLabel.Text = "Separator"
        '
        'SeparatorComboBox
        '
        Me.SeparatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SeparatorComboBox.FormattingEnabled = True
        Me.SeparatorComboBox.Items.AddRange(New Object() {"()", "[]", "-", ".", ")"})
        Me.SeparatorComboBox.Location = New System.Drawing.Point(443, 249)
        Me.SeparatorComboBox.Name = "SeparatorComboBox"
        Me.SeparatorComboBox.Size = New System.Drawing.Size(93, 21)
        Me.SeparatorComboBox.TabIndex = 4
        '
        'ResultLabel
        '
        Me.ResultLabel.AutoSize = True
        Me.ResultLabel.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultLabel.ForeColor = System.Drawing.Color.Red
        Me.ResultLabel.Location = New System.Drawing.Point(12, 552)
        Me.ResultLabel.Name = "ResultLabel"
        Me.ResultLabel.Size = New System.Drawing.Size(49, 19)
        Me.ResultLabel.TabIndex = 6
        Me.ResultLabel.Text = "#####"
        '
        'ResultLocationTextBox
        '
        Me.ResultLocationTextBox.Enabled = False
        Me.ResultLocationTextBox.Location = New System.Drawing.Point(15, 577)
        Me.ResultLocationTextBox.Name = "ResultLocationTextBox"
        Me.ResultLocationTextBox.Size = New System.Drawing.Size(664, 20)
        Me.ResultLocationTextBox.TabIndex = 11
        '
        'CopyLocationButton
        '
        Me.CopyLocationButton.Location = New System.Drawing.Point(16, 603)
        Me.CopyLocationButton.Name = "CopyLocationButton"
        Me.CopyLocationButton.Size = New System.Drawing.Size(88, 23)
        Me.CopyLocationButton.TabIndex = 12
        Me.CopyLocationButton.Text = "Copy Location"
        Me.CopyLocationButton.UseVisualStyleBackColor = True
        '
        'OpenFileButton
        '
        Me.OpenFileButton.Location = New System.Drawing.Point(110, 603)
        Me.OpenFileButton.Name = "OpenFileButton"
        Me.OpenFileButton.Size = New System.Drawing.Size(75, 23)
        Me.OpenFileButton.TabIndex = 13
        Me.OpenFileButton.Text = "Open File"
        Me.OpenFileButton.UseVisualStyleBackColor = True
        '
        'HelpButton
        '
        Me.HelpButton.Location = New System.Drawing.Point(621, 27)
        Me.HelpButton.Name = "HelpButton"
        Me.HelpButton.Size = New System.Drawing.Size(35, 23)
        Me.HelpButton.TabIndex = 14
        Me.HelpButton.Text = "?"
        Me.HelpButton.UseVisualStyleBackColor = True
        '
        'ResultDataGridView
        '
        Me.ResultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ResultDataGridView.Location = New System.Drawing.Point(15, 341)
        Me.ResultDataGridView.Name = "ResultDataGridView"
        Me.ResultDataGridView.ReadOnly = True
        Me.ResultDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.ResultDataGridView.Size = New System.Drawing.Size(664, 201)
        Me.ResultDataGridView.TabIndex = 16
        '
        'FilesDataGridView
        '
        Me.FilesDataGridView.AllowUserToAddRows = False
        Me.FilesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FilesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SafeFileName, Me.File, Me.CharactersGroup})
        Me.FilesDataGridView.Location = New System.Drawing.Point(15, 60)
        Me.FilesDataGridView.Name = "FilesDataGridView"
        Me.FilesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.FilesDataGridView.Size = New System.Drawing.Size(664, 155)
        Me.FilesDataGridView.TabIndex = 20
        '
        'SafeFileName
        '
        Me.SafeFileName.HeaderText = "File"
        Me.SafeFileName.Name = "SafeFileName"
        Me.SafeFileName.ReadOnly = True
        Me.SafeFileName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SafeFileName.Width = 410
        '
        'File
        '
        Me.File.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.File.HeaderText = "File"
        Me.File.Name = "File"
        Me.File.ReadOnly = True
        Me.File.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.File.Visible = False
        '
        'CharactersGroup
        '
        Me.CharactersGroup.HeaderText = "Chars Group"
        Me.CharactersGroup.Name = "CharactersGroup"
        Me.CharactersGroup.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CharactersGroup.Width = 207
        '
        'ExportedFileTypeComboBox
        '
        Me.ExportedFileTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ExportedFileTypeComboBox.DropDownWidth = 300
        Me.ExportedFileTypeComboBox.FormattingEnabled = True
        Me.ExportedFileTypeComboBox.Location = New System.Drawing.Point(113, 224)
        Me.ExportedFileTypeComboBox.Name = "ExportedFileTypeComboBox"
        Me.ExportedFileTypeComboBox.Size = New System.Drawing.Size(182, 21)
        Me.ExportedFileTypeComboBox.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 227)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Exported File Type"
        '
        'SplitLinesCheckBox
        '
        Me.SplitLinesCheckBox.AutoSize = True
        Me.SplitLinesCheckBox.Location = New System.Drawing.Point(304, 251)
        Me.SplitLinesCheckBox.Name = "SplitLinesCheckBox"
        Me.SplitLinesCheckBox.Size = New System.Drawing.Size(74, 17)
        Me.SplitLinesCheckBox.TabIndex = 24
        Me.SplitLinesCheckBox.Text = "Split Lines"
        Me.SplitLinesCheckBox.UseVisualStyleBackColor = True
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(581, 548)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(98, 23)
        Me.ClearButton.TabIndex = 26
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'EncodingComboBox
        '
        Me.EncodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EncodingComboBox.DropDownWidth = 300
        Me.EncodingComboBox.FormattingEnabled = True
        Me.EncodingComboBox.Location = New System.Drawing.Point(93, 31)
        Me.EncodingComboBox.Name = "EncodingComboBox"
        Me.EncodingComboBox.Size = New System.Drawing.Size(160, 21)
        Me.EncodingComboBox.TabIndex = 27
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 54)
        Me.ContextMenuStrip1.Text = "SubMerge"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(113, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FILEToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(724, 24)
        Me.MenuStrip1.TabIndex = 28
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FILEToolStripMenuItem
        '
        Me.FILEToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem1, Me.ExitToolStripMenuItem1})
        Me.FILEToolStripMenuItem.Name = "FILEToolStripMenuItem"
        Me.FILEToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.FILEToolStripMenuItem.Text = "FILE"
        '
        'OptionsToolStripMenuItem1
        '
        Me.OptionsToolStripMenuItem1.Name = "OptionsToolStripMenuItem1"
        Me.OptionsToolStripMenuItem1.Size = New System.Drawing.Size(116, 22)
        Me.OptionsToolStripMenuItem1.Text = "Options"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(116, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'FramesRateTextBox
        '
        Me.FramesRateTextBox.Location = New System.Drawing.Point(528, 315)
        Me.FramesRateTextBox.MaxLength = 5
        Me.FramesRateTextBox.Name = "FramesRateTextBox"
        Me.FramesRateTextBox.Size = New System.Drawing.Size(75, 20)
        Me.FramesRateTextBox.TabIndex = 29
        '
        'FramesRateLabel
        '
        Me.FramesRateLabel.AutoSize = True
        Me.FramesRateLabel.Location = New System.Drawing.Point(478, 301)
        Me.FramesRateLabel.Name = "FramesRateLabel"
        Me.FramesRateLabel.Size = New System.Drawing.Size(154, 13)
        Me.FramesRateLabel.TabIndex = 30
        Me.FramesRateLabel.Text = "Number Of Frames Per Second"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 252)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Shift Timing By"
        '
        'TimingTextBox
        '
        Me.TimingTextBox.Location = New System.Drawing.Point(113, 250)
        Me.TimingTextBox.MaxLength = 5
        Me.TimingTextBox.Name = "TimingTextBox"
        Me.TimingTextBox.Size = New System.Drawing.Size(103, 20)
        Me.TimingTextBox.TabIndex = 32
        '
        'TimingComboBox
        '
        Me.TimingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TimingComboBox.DropDownWidth = 100
        Me.TimingComboBox.FormattingEnabled = True
        Me.TimingComboBox.Items.AddRange(New Object() {"Milliseconds (MS)", "Seconds (Sec)", "Minutes (Min)", "Hours (Hrs)"})
        Me.TimingComboBox.Location = New System.Drawing.Point(222, 249)
        Me.TimingComboBox.Name = "TimingComboBox"
        Me.TimingComboBox.Size = New System.Drawing.Size(73, 21)
        Me.TimingComboBox.TabIndex = 33
        '
        'RemoveFileButton
        '
        Me.RemoveFileButton.Location = New System.Drawing.Point(604, 217)
        Me.RemoveFileButton.Name = "RemoveFileButton"
        Me.RemoveFileButton.Size = New System.Drawing.Size(75, 23)
        Me.RemoveFileButton.TabIndex = 37
        Me.RemoveFileButton.Text = "Remove File"
        Me.RemoveFileButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.SaveButton.Location = New System.Drawing.Point(237, 292)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(219, 29)
        Me.SaveButton.TabIndex = 38
        Me.SaveButton.Text = "Save to Disk"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'EnableVoiceCheckBox
        '
        Me.EnableVoiceCheckBox.AutoSize = True
        Me.EnableVoiceCheckBox.Location = New System.Drawing.Point(259, 33)
        Me.EnableVoiceCheckBox.Name = "EnableVoiceCheckBox"
        Me.EnableVoiceCheckBox.Size = New System.Drawing.Size(89, 17)
        Me.EnableVoiceCheckBox.TabIndex = 39
        Me.EnableVoiceCheckBox.Text = "Enable Voice"
        Me.EnableVoiceCheckBox.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 631)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.EnableVoiceCheckBox)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.RemoveFileButton)
        Me.Controls.Add(Me.TimingComboBox)
        Me.Controls.Add(Me.TimingTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FramesRateLabel)
        Me.Controls.Add(Me.FramesRateTextBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.EncodingComboBox)
        Me.Controls.Add(Me.ClearButton)
        Me.Controls.Add(Me.SplitLinesCheckBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ExportedFileTypeComboBox)
        Me.Controls.Add(Me.FilesDataGridView)
        Me.Controls.Add(Me.ResultDataGridView)
        Me.Controls.Add(Me.HelpButton)
        Me.Controls.Add(Me.OpenFileButton)
        Me.Controls.Add(Me.CopyLocationButton)
        Me.Controls.Add(Me.ResultLocationTextBox)
        Me.Controls.Add(Me.ResultLabel)
        Me.Controls.Add(Me.SeparatorComboBox)
        Me.Controls.Add(Me.SeparatorLabel)
        Me.Controls.Add(Me.LineNumbersCheckBox)
        Me.Controls.Add(Me.MergeBtn)
        Me.Controls.Add(Me.LoadFileButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SubMerge - Convert & Merge Subtitles"
        CType(Me.ResultDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LoadFileButton As System.Windows.Forms.Button
    Friend WithEvents MergeBtn As System.Windows.Forms.Button
    Friend WithEvents LineNumbersCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SeparatorLabel As System.Windows.Forms.Label
    Friend WithEvents SeparatorComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ResultLabel As System.Windows.Forms.Label
    Friend WithEvents ResultLocationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CopyLocationButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileButton As System.Windows.Forms.Button
    Friend WithEvents HelpButton As System.Windows.Forms.Button
    Friend WithEvents ResultDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents FilesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents MyFileOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ExportedFileTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitLinesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents EncodingComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FILEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FramesRateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FramesRateLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TimingTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TimingComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RemoveFileButton As System.Windows.Forms.Button
    Friend WithEvents MySaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents EnableVoiceCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SafeFileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents File As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CharactersGroup As System.Windows.Forms.DataGridViewComboBoxColumn

End Class
