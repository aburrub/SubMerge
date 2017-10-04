<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumberOfFramesTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TrimCheckBox = New System.Windows.Forms.CheckBox()
        Me.IgnoreCommaCheckBox = New System.Windows.Forms.CheckBox()
        Me.IgnoreDotCheckBox = New System.Windows.Forms.CheckBox()
        Me.IgnoreDashCheckBox = New System.Windows.Forms.CheckBox()
        Me.IgnoreSlashCheckBox = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.SpecialLettersComboBox = New System.Windows.Forms.ComboBox()
        Me.AddButton = New System.Windows.Forms.Button()
        Me.SpecialLetterTextBox = New System.Windows.Forms.TextBox()
        Me.IgnoreSpecialCheckBox = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(482, 274)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.63458!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.36542!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.NumberOfFramesTextBox, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.TrimCheckBox, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.IgnoreCommaCheckBox, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.IgnoreDotCheckBox, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.IgnoreDashCheckBox, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.IgnoreSlashCheckBox, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.IgnoreSpecialCheckBox, 0, 6)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 7
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(613, 256)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 36)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Number Of Frames Per Second"
        '
        'NumberOfFramesTextBox
        '
        Me.NumberOfFramesTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NumberOfFramesTextBox.Location = New System.Drawing.Point(294, 3)
        Me.NumberOfFramesTextBox.MaxLength = 5
        Me.NumberOfFramesTextBox.Name = "NumberOfFramesTextBox"
        Me.NumberOfFramesTextBox.Size = New System.Drawing.Size(316, 20)
        Me.NumberOfFramesTextBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(3, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Trim"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(3, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ignore Commas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(3, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ignore Dots"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(3, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Ignore Dashes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(3, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Ignore Slashes"
        '
        'TrimCheckBox
        '
        Me.TrimCheckBox.AutoSize = True
        Me.TrimCheckBox.Location = New System.Drawing.Point(294, 39)
        Me.TrimCheckBox.Name = "TrimCheckBox"
        Me.TrimCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.TrimCheckBox.TabIndex = 10
        Me.TrimCheckBox.UseVisualStyleBackColor = True
        '
        'IgnoreCommaCheckBox
        '
        Me.IgnoreCommaCheckBox.AutoSize = True
        Me.IgnoreCommaCheckBox.Location = New System.Drawing.Point(294, 75)
        Me.IgnoreCommaCheckBox.Name = "IgnoreCommaCheckBox"
        Me.IgnoreCommaCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.IgnoreCommaCheckBox.TabIndex = 11
        Me.IgnoreCommaCheckBox.UseVisualStyleBackColor = True
        '
        'IgnoreDotCheckBox
        '
        Me.IgnoreDotCheckBox.AutoSize = True
        Me.IgnoreDotCheckBox.Location = New System.Drawing.Point(294, 111)
        Me.IgnoreDotCheckBox.Name = "IgnoreDotCheckBox"
        Me.IgnoreDotCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.IgnoreDotCheckBox.TabIndex = 12
        Me.IgnoreDotCheckBox.UseVisualStyleBackColor = True
        '
        'IgnoreDashCheckBox
        '
        Me.IgnoreDashCheckBox.AutoSize = True
        Me.IgnoreDashCheckBox.Location = New System.Drawing.Point(294, 147)
        Me.IgnoreDashCheckBox.Name = "IgnoreDashCheckBox"
        Me.IgnoreDashCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.IgnoreDashCheckBox.TabIndex = 13
        Me.IgnoreDashCheckBox.UseVisualStyleBackColor = True
        '
        'IgnoreSlashCheckBox
        '
        Me.IgnoreSlashCheckBox.AutoSize = True
        Me.IgnoreSlashCheckBox.Location = New System.Drawing.Point(294, 183)
        Me.IgnoreSlashCheckBox.Name = "IgnoreSlashCheckBox"
        Me.IgnoreSlashCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.IgnoreSlashCheckBox.TabIndex = 14
        Me.IgnoreSlashCheckBox.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RemoveButton)
        Me.Panel1.Controls.Add(Me.SpecialLettersComboBox)
        Me.Panel1.Controls.Add(Me.AddButton)
        Me.Panel1.Controls.Add(Me.SpecialLetterTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(294, 219)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(316, 34)
        Me.Panel1.TabIndex = 15
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(250, 1)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.Size = New System.Drawing.Size(42, 21)
        Me.RemoveButton.TabIndex = 3
        Me.RemoveButton.Text = "Del"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'SpecialLettersComboBox
        '
        Me.SpecialLettersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SpecialLettersComboBox.FormattingEnabled = True
        Me.SpecialLettersComboBox.Location = New System.Drawing.Point(122, 1)
        Me.SpecialLettersComboBox.Name = "SpecialLettersComboBox"
        Me.SpecialLettersComboBox.Size = New System.Drawing.Size(124, 21)
        Me.SpecialLettersComboBox.TabIndex = 2
        '
        'AddButton
        '
        Me.AddButton.Location = New System.Drawing.Point(59, 1)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(40, 21)
        Me.AddButton.TabIndex = 1
        Me.AddButton.Text = "Add"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'SpecialLetterTextBox
        '
        Me.SpecialLetterTextBox.Location = New System.Drawing.Point(12, 2)
        Me.SpecialLetterTextBox.MaxLength = 1
        Me.SpecialLetterTextBox.Name = "SpecialLetterTextBox"
        Me.SpecialLetterTextBox.Size = New System.Drawing.Size(42, 20)
        Me.SpecialLetterTextBox.TabIndex = 0
        '
        'IgnoreSpecialCheckBox
        '
        Me.IgnoreSpecialCheckBox.AutoSize = True
        Me.IgnoreSpecialCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.IgnoreSpecialCheckBox.Location = New System.Drawing.Point(3, 219)
        Me.IgnoreSpecialCheckBox.Name = "IgnoreSpecialCheckBox"
        Me.IgnoreSpecialCheckBox.Size = New System.Drawing.Size(212, 24)
        Me.IgnoreSpecialCheckBox.TabIndex = 16
        Me.IgnoreSpecialCheckBox.Text = "Ignore Special Characters"
        Me.IgnoreSpecialCheckBox.UseVisualStyleBackColor = True
        '
        'OptionsDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(640, 315)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionsDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OptionsDialog"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumberOfFramesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TrimCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IgnoreCommaCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IgnoreDotCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IgnoreDashCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IgnoreSlashCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SpecialLettersComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents SpecialLetterTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RemoveButton As System.Windows.Forms.Button
    Friend WithEvents IgnoreSpecialCheckBox As System.Windows.Forms.CheckBox

End Class
