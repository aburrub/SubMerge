Imports System.Windows.Forms

Public Class HelpDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub HelpDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextBox5.Text = "Step 01: Load files into the system by clicking on 'Load File' button"
        Me.TextBox5.Text += Environment.NewLine + "Step 02: Select the ouput format "
        Me.TextBox5.Text += Environment.NewLine + "Step 03: You have the option to change the timing"
        Me.TextBox5.Text += Environment.NewLine + "Step 04: Click on 'Convert' or 'Merge and Convert', the application will populate the data in the grid"
        Me.TextBox5.Text += Environment.NewLine + "Step 05: Click on 'Save to Dish' button to export your file"
        Me.TextBox5.Text += Environment.NewLine + "SubMerge Shortcuts:"
        Me.TextBox5.Text += Environment.NewLine + "(F1) : Help"
        Me.TextBox5.Text += Environment.NewLine + "(Ctrl-L) : Load File"
        Me.TextBox5.Text += Environment.NewLine + "(Ctrl-M) : Merge"
        Me.TextBox5.Text += Environment.NewLine + "(Ctrl-C) : Clear"

    End Sub
End Class
