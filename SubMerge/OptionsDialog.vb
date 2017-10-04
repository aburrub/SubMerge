Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class OptionsDialog
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Settings.NumberOfFramesPerSecond = Double.Parse(Me.NumberOfFramesTextBox.Text)

        'save flags
        My.Settings.SubMergeSetting_Trim = Me.TrimCheckBox.Checked
        My.Settings.SubMergeSetting_IgnoreComma = Me.IgnoreCommaCheckBox.Checked
        My.Settings.SubMergeSetting_IgnoreDot = Me.IgnoreDotCheckBox.Checked
        My.Settings.SubMergeSetting_IgnoreDash = Me.IgnoreDashCheckBox.Checked
        My.Settings.SubMergeSetting_IgnoreSlash = Me.IgnoreSlashCheckBox.Checked
        My.Settings.SubMergeSetting_IgnoreSpecial = Me.IgnoreSpecialCheckBox.Checked

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OptionsDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.NumberOfFramesTextBox.Text = String.Format("{0}", My.Settings.NumberOfFramesPerSecond)
        If My.Settings.SubMergeSetting_SpecialLetters Is Nothing Then
            My.Settings.SubMergeSetting_SpecialLetters = New ArrayList
        End If

        refreshComboBox()


        Me.TrimCheckBox.Checked = My.Settings.SubMergeSetting_Trim
        Me.IgnoreCommaCheckBox.Checked = My.Settings.SubMergeSetting_IgnoreComma
        Me.IgnoreDashCheckBox.Checked = My.Settings.SubMergeSetting_IgnoreDash
        Me.IgnoreDotCheckBox.Checked = My.Settings.SubMergeSetting_IgnoreDot
        Me.IgnoreSlashCheckBox.Checked = My.Settings.SubMergeSetting_IgnoreSlash
        Me.IgnoreSpecialCheckBox.Checked = My.Settings.SubMergeSetting_IgnoreSpecial

        Me.enableDisable(Me.IgnoreSpecialCheckBox.Checked)
    End Sub


    Private Sub NumberOfFramesTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles NumberOfFramesTextBox.KeyUp
        exec.AllowOnlyDecimalNumbersInTextbox(Me.NumberOfFramesTextBox, e)
    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        If Not My.Settings.SubMergeSetting_SpecialLetters.Contains(Me.SpecialLetterTextBox.Text) Then
            My.Settings.SubMergeSetting_SpecialLetters.Add(Me.SpecialLetterTextBox.Text)
            refreshComboBox()
            Me.SpecialLettersComboBox.Text = Me.SpecialLetterTextBox.Text
        End If
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Try
            My.Settings.SubMergeSetting_SpecialLetters.Remove(Me.SpecialLettersComboBox.Text)
        Catch ex As Exception

        End Try
        refreshComboBox()

    End Sub

    Private Sub refreshComboBox()
        Me.SpecialLettersComboBox.Items.Clear()
        For Each s As String In My.Settings.SubMergeSetting_SpecialLetters
            Me.SpecialLettersComboBox.Items.Add(s)
        Next
        If Me.SpecialLettersComboBox.Items.Count > 0 Then
            Me.SpecialLettersComboBox.SelectedIndex = 0
        End If
    End Sub


    Private Sub IgnoreSpecialCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles IgnoreSpecialCheckBox.CheckedChanged
        enableDisable(IgnoreSpecialCheckBox.Checked)

    End Sub

    Private Sub enableDisable(ByVal flg As Boolean)
        Me.AddButton.Enabled = flg
        Me.RemoveButton.Enabled = flg
        Me.SpecialLettersComboBox.Enabled = flg
        Me.SpecialLetterTextBox.Enabled = flg
    End Sub
End Class
