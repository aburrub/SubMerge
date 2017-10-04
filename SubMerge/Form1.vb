Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Speech.Synthesis
Imports System.Threading
Imports Microsoft.Office.Interop.Excel

Public Class Form1
    Public Files As New List(Of TranscriptFile)
    Private TempResult As New List(Of List(Of Transcript))
    Private Result As New List(Of Transcript)
    Private OutputTypes As New Dictionary(Of String, String)
    Private LanguageRanges As New Dictionary(Of String, LanguageRange)
    Private xmlOutput As String = Nothing

    Private Sub LoadFileButton_Click(sender As Object, e As EventArgs) Handles LoadFileButton.Click
        Me.MyFileOpenFileDialog.Filter = "Text Files (.srt)|*.srt|All Files (*.*)|*.*"
        Me.MyFileOpenFileDialog.FilterIndex = 1
        Me.MyFileOpenFileDialog.ShowDialog()
        If Not Me.MyFileOpenFileDialog.FileName = "" Then
            If Not findInFilesGrid(Me.MyFileOpenFileDialog.FileName) Then
                'Dim dgvcc As New DataGridViewComboBoxColumn

                ''Dim dgvcc As New DataGridViewComboBoxCell
                'dgvcc.DataSource = New BindingSource(LanguageRanges, Nothing)
                'dgvcc.DisplayMember = "Key"
                'dgvcc.ValueMember = "Value"

                Me.FilesDataGridView.Rows.Add(New Object() {Me.MyFileOpenFileDialog.SafeFileName, Me.MyFileOpenFileDialog.FileName})
                Dim charsetColumnIndex As Integer = Me.FilesDataGridView.Columns("CharactersGroup").Index
                CType(Me.FilesDataGridView.Rows(Me.FilesDataGridView.Rows.Count - 1).Cells(charsetColumnIndex), DataGridViewComboBoxCell).DataSource = New BindingSource(LanguageRanges, Nothing)
                CType(Me.FilesDataGridView.Rows(Me.FilesDataGridView.Rows.Count - 1).Cells(charsetColumnIndex), DataGridViewComboBoxCell).DropDownWidth = 400
                CType(Me.FilesDataGridView.Rows(Me.FilesDataGridView.Rows.Count - 1).Cells(charsetColumnIndex), DataGridViewComboBoxCell).DisplayMember = "Key"
                CType(Me.FilesDataGridView.Rows(Me.FilesDataGridView.Rows.Count - 1).Cells(charsetColumnIndex), DataGridViewComboBoxCell).ValueMember = "Value"
                CType(Me.FilesDataGridView.Rows(Me.FilesDataGridView.Rows.Count - 1).Cells(charsetColumnIndex), DataGridViewComboBoxCell).Value = "All Char Sets"


                Dim TrascriptsObject As New List(Of Transcript)
                Me.ReadFromFileIntoTranscript(TrascriptsObject, Me.MyFileOpenFileDialog.FileName, Me.EncodingComboBox.SelectedValue.ToString)
                Dim File As New TranscriptFile(Me.MyFileOpenFileDialog.SafeFileName, Me.MyFileOpenFileDialog.FileName, TrascriptsObject, Me.EncodingComboBox.SelectedValue.ToString, Me.LanguageRanges, "All Char Sets")
                Me.Files.Add(File)
            End If
        End If

        Me.ControlsAppearance()
    End Sub

    Private Function findInFilesGrid(ByVal FilePath As String) As Boolean
        For Each r As DataGridViewRow In Me.FilesDataGridView.Rows
            If r.Cells("File").Value.ToString = FilePath Then
                Return True
            End If
        Next
        Return False
    End Function



    Private Sub MergeFiles(ByVal trimFlag As Boolean, ByVal ignoreComma As Boolean, ByVal IgnoreSlash As Boolean, ByVal ignoreDash As Boolean, ByVal ignoreDot As Boolean)
        Me.Result.Clear()
        Me.TempResult.Clear()

        Dim Source As List(Of Transcript) = Me.Files(0).Transcripts
        Dim counter As Integer = 1

        For Each File As TranscriptFile In Me.Files
            counter = 1
            Dim Res As New List(Of Transcript)
            For Each source_transcript As Transcript In Source
                Dim minTimeValue As Double = Double.MaxValue
                Dim minTranscript As Transcript = Nothing

                For Each target_transcript As Transcript In File.Transcripts
                    Dim diff As Double = Math.Abs(((source_transcript.StartTime - target_transcript.StartTime).TotalMilliseconds) + ((source_transcript.EndTime - target_transcript.EndTime).TotalMilliseconds))
                    If diff < minTimeValue Then
                        minTimeValue = diff
                        minTranscript = target_transcript
                    End If
                Next

                Dim tt As New Transcript
                tt.order = source_transcript.order
                tt.StartTime = source_transcript.StartTime
                tt.EndTime = source_transcript.EndTime
                tt.Sentence = source_transcript.Sentence

                tt.OtherSentences.Add(minTranscript.Sentence)

                Res.Add(tt)
            Next
            Me.TempResult.Add(Res)
        Next

        For i As Integer = 0 To Me.TempResult(0).Count - 1
            Dim ft As New Transcript
            ft.order = Me.TempResult(0)(i).order
            ft.StartTime = Me.TempResult(0)(i).StartTime
            ft.EndTime = Me.TempResult(0)(i).EndTime
            ft.Sentence = Me.TempResult(0)(i).Sentence

            For j As Integer = 0 To Me.TempResult.Count - 1
                Dim tempSentence As String = Me.TempResult(j)(i).OtherSentences(0)
                tempSentence = If(Not trimFlag, tempSentence, TrimString(tempSentence))
                tempSentence = RefineString(tempSentence, ignoreComma, IgnoreSlash, ignoreDot, ignoreDash, If(Not Files(j).CharSet.RangeName = "All Char Sets", True, False), Files(j).CharSet)

                ft.OtherSentences.Add(tempSentence)
            Next

            Me.Result.Add(ft)
        Next

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ResultDataGridView.Rows.Clear()
        Me.LineNumbersCheckBox.Checked = True
        Me.SeparatorComboBox.SelectedIndex = 0
        Me.ResultLocationTextBox.Visible = False
        Me.OpenFileButton.Visible = False
        Me.ResultDataGridView.Visible = False
        Me.ClearButton.Visible = False
        Me.CopyLocationButton.Visible = False
        Me.ResultLabel.Text = ""
        Me.SplitLinesCheckBox.Checked = False
        Me.SplitLinesCheckBox.Visible = False
        Me.MergeBtn.Text = "Convert"
        Me.FillInEncodingCombobox()
        exec.FillOutputFileTypes(Me.OutputTypes, Me.ExportedFileTypeComboBox)
        Me.ExportedFileTypeComboBox.SelectedIndex = 0
        For Each ctr As Control In Me.Controls
            If ctr.Name = "FilesDataGridView" Then
                AddHandler ctr.KeyUp, AddressOf HandleFilesGridPressUp
            Else
                AddHandler ctr.KeyUp, AddressOf HandleKeyUp
            End If

        Next

        Me.InitiateAndRepositionFrameControls()
        Me.InitializeTimingControls()
        Me.IntializeMatchGroupControls()
        Me.RemoveFileButton.Enabled = False
        Me.EnableDisableIncludeLineNumbers(False)
        Me.SaveButton.Enabled = False
    End Sub

    Private Sub IntializeMatchGroupControls()
        Language.LanguageRangesInit(Me.LanguageRanges)
    End Sub

    Private Sub InitializeTimingControls()
        Me.TimingComboBox.SelectedIndex = 1
        Me.TimingTextBox.Text = 0
    End Sub
    Private Sub InitiateAndRepositionFrameControls()
        'reposition frame controls
        Me.FramesRateLabel.Location = New System.Drawing.Point(301, 252)
        Me.FramesRateTextBox.Location = New System.Drawing.Point(461, 249)
        Me.FramesRateTextBox.Text = My.Settings.NumberOfFramesPerSecond
        ShowHideFrameControls(False)
    End Sub

    Private Sub ShowHideFrameControls(ByVal flg As Boolean)
        Me.FramesRateLabel.Visible = flg
        Me.FramesRateTextBox.Visible = flg
    End Sub
    Private Sub FillInEncodingCombobox()
        Dim ens1 As New Dictionary(Of String, String)
        Dim ens2 As New Dictionary(Of String, String)
        Dim ens4 As New Dictionary(Of String, String)

        For Each ei As EncodingInfo In Encoding.GetEncodings
            If Not ens1.ContainsKey(ei.DisplayName) And ei.DisplayName.Contains("Windows") Then
                ens1.Add(ei.DisplayName, ei.Name)
            End If
        Next

        For Each ei As EncodingInfo In Encoding.GetEncodings
            If Not ens2.ContainsKey(ei.DisplayName) And Not ei.DisplayName.Contains("Windows") Then
                ens2.Add(ei.DisplayName, ei.Name)
            End If
        Next

        Dim r1 = From itm In ens1
                 Order By itm.Key
                 Select itm

        Dim r2 = From itm In ens2
                 Order By itm.Key
                 Select itm

        ens4.Add("Default Encoding", "Default Encoding")

        For Each v As KeyValuePair(Of String, String) In r1
            ens4.Add(v.Key, v.Value)

        Next

        ens4.Add("----------------------------------------------------------", "")

        For Each v As KeyValuePair(Of String, String) In r2
            ens4.Add(v.Key, v.Value)
        Next

        Me.EncodingComboBox.DataSource = New BindingSource(ens4, Nothing)
        Me.EncodingComboBox.DisplayMember = "Key"
        Me.EncodingComboBox.ValueMember = "Value"
        Me.EncodingComboBox.SelectedIndex = 0
    End Sub

    Private Sub ReadFromFileIntoTranscript(ByRef Transcripts As List(Of Transcript), ByVal FileName As String, ByVal EncodingName As String)
        Try
            Dim CurrentEncoding As Encoding = Nothing
            If EncodingName = "" Or EncodingName = "Default Encoding" Then
                CurrentEncoding = Encoding.Default
            Else
                CurrentEncoding = Encoding.GetEncoding(EncodingName)
            End If

            Dim Reader As New StreamReader(FileName, CurrentEncoding)
            Dim ic As Integer = 0
            Dim msg As String = ""
            Dim trascript As Transcript = Nothing
            Dim passNumeric As Boolean = True
            While Not Reader.EndOfStream

                Dim l As String = Reader.ReadLine
                If IsNumeric(l) And passNumeric Then
                    trascript = New Transcript()
                    trascript.order = Integer.Parse(l)
                    msg = ""
                    passNumeric = False
                ElseIf l.Contains("-->") Then
                    exec.ParseTranscriptTime(l, trascript)
                    msg = ""
                ElseIf l = "" Then
                    trascript.Sentence = msg
                    Transcripts.Add(trascript)
                    passNumeric = True
                Else
                    msg = exec.StripHTML(String.Format("{0} {1}", msg, l))
                End If

            End While
            Reader.Close()
            Reader.Dispose()
        Catch ex As Exception
            Me.clearResult()
            Me.ResultLabel.Text = String.Format("Err:{0}", ex.Message)
        End Try

    End Sub

    Private Sub LineNumbersCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles LineNumbersCheckBox.CheckedChanged
        If Me.LineNumbersCheckBox.Checked Then
            Me.SeparatorComboBox.Enabled = True
        Else
            Me.SeparatorComboBox.Enabled = False
        End If
    End Sub

    Private Sub ControlsAppearance()
        If Me.FilesDataGridView.Rows.Count > 0 Then
            Me.SplitLinesCheckBox.Enabled = True
            Me.MergeBtn.Enabled = True
            Me.SeparatorComboBox.Enabled = True
            Me.LineNumbersCheckBox.Enabled = True
        Else
            Me.SplitLinesCheckBox.Enabled = False
            Me.MergeBtn.Enabled = False
            Me.SeparatorComboBox.Enabled = False
            Me.LineNumbersCheckBox.Enabled = False
        End If

    End Sub

    Private Sub clearResult()
        Me.ResultLabel.Text = ""
        Me.ResultLocationTextBox.Visible = False
        Me.CopyLocationButton.Visible = False
        Me.OpenFileButton.Visible = False
        Me.ResultDataGridView.Visible = False
    End Sub

    Private Sub CopyLocationButton_Click(sender As Object, e As EventArgs) Handles CopyLocationButton.Click
        My.Computer.Clipboard.SetText(Me.ResultLocationTextBox.Text)
    End Sub

    Private Sub OpenFileButton_Click(sender As Object, e As EventArgs) Handles OpenFileButton.Click
        exec.ShellExecute(Me.ResultLocationTextBox.Text)
    End Sub





    Private Sub HelpButton_Click(sender As Object, e As EventArgs) Handles HelpButton.Click
        HelpDialog.ShowDialog()
    End Sub

    Private Sub HandleKeyUp(sender As Object, e As KeyEventArgs)

        If e.Modifiers = Keys.Control And e.KeyCode = Keys.L Then
            LoadFileButton_Click(sender, e)
        End If

        If e.Modifiers = Keys.Control And e.KeyCode = Keys.C And Me.ClearButton.Visible Then
            ClearButton_Click(sender, e)
        End If

        If e.KeyCode = Keys.F1 Then 'f1 button
            HelpButton_Click(Nothing, Nothing)
        End If

        If e.Modifiers = Keys.Control And e.KeyCode = Keys.M And Me.MergeBtn.Enabled Then
            MergeBtn_Click(sender, e)
        End If

    End Sub

    Private Sub ResultDataGridView_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ResultDataGridView.CellEnter
        Try
            Dim sentence As String = Me.ResultDataGridView.Item(e.ColumnIndex, e.RowIndex).FormattedValue.ToString
            Dim th As New Threading.Thread(AddressOf PronounceMe)
            th.Start(sentence)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PronounceMe(ByVal sentence As String)
        Try
            If Me.GetEnableVoiceValue() Then
                Dim synth As SpeechSynthesizer = New SpeechSynthesizer()
                synth.SetOutputToDefaultAudioDevice()

                synth.Speak(sentence)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DisplayItemsAfterMerge()
        If Me.Result IsNot Nothing AndAlso Me.Result.Count > 0 Then
            Me.ResultDataGridView.Columns.Clear()
            Me.ResultDataGridView.Rows.Clear()

            ' insert grid columns
            For Each tf As TranscriptFile In Me.Files
                Me.ResultDataGridView.Columns.Add(tf.SafeFileName, tf.SafeFileName)
            Next

            For i As Integer = 0 To Me.Result.Count - 1
                Dim t As Transcript = Me.Result(i)
                Dim objs As New List(Of Object)
                For Each sentence As String In t.OtherSentences
                    objs.Add(sentence)
                Next
                Me.ResultDataGridView.Rows.Add(objs.ToArray)

                Dim s As New DataGridViewCellStyle()
                s.Alignment = DataGridViewContentAlignment.MiddleCenter
                Dim h As New DataGridViewRowHeaderCell()
                h.Style = s
                h.Value = String.Format("{0}", i + 1)
                Me.ResultDataGridView.Rows(i).HeaderCell = h
            Next

            Me.ResultDataGridView.Visible = True
            Dim nd As DateTime = DateTime.Now
            Me.ResultLabel.Text = String.Format("Subtitles have been merged on [{0}] at [{1}]", nd.ToString("MMM dd,yyyy"), nd.ToString("HH:mm:ss\_ff"))
            Me.ResultLabel.Visible = True
            Me.ResultLocationTextBox.Visible = True
            Me.CopyLocationButton.Visible = True
            Me.OpenFileButton.Visible = True
            Me.ClearButton.Visible = True
        End If



    End Sub

    Private Function GetTrimValue() As Boolean
        Return My.Settings.SubMergeSetting_Trim
    End Function

    Private Function GetCommaValue() As Boolean
        Return My.Settings.SubMergeSetting_IgnoreComma
    End Function

    Private Function GetSlashValue() As Boolean
        Return My.Settings.SubMergeSetting_IgnoreSlash
    End Function

    Private Function GetDotValue() As Boolean
        Return My.Settings.SubMergeSetting_IgnoreDot
    End Function

    Private Function GetDashValue() As Boolean
        Return My.Settings.SubMergeSetting_IgnoreDash
    End Function

    Private Function GetEnableVoiceValue() As Boolean
        Return Me.EnableVoiceCheckBox.Checked
    End Function


    Private Sub MergeBtn_Click(sender As Object, e As EventArgs) Handles MergeBtn.Click
        Try
            MergeFiles(Me.GetTrimValue, Me.GetCommaValue, Me.GetSlashValue, Me.GetDashValue, Me.GetDotValue)

            If Me.TimingTextBox.Text <> "" Then
                Dim TimeLength As Double = Double.Parse(Me.TimingTextBox.Text)
                Dim addTime As TimeSpan = Nothing
                Select Case Me.TimingComboBox.Text
                    Case "Milliseconds (MS)"
                        addTime = New TimeSpan(0, 0, 0, 0, TimeLength)

                    Case "Seconds (Sec)"
                        addTime = New TimeSpan(0, 0, 0, TimeLength, 0)

                    Case "Minutes (Min)"
                        addTime = New TimeSpan(0, 0, TimeLength, 0, 0)

                    Case "Hours (Hrs)"
                        addTime = New TimeSpan(0, TimeLength, 0, 0, 0)
                End Select

                If TimeLength <> 0 Then
                    For k As Integer = 0 To Me.Result.Count - 1
                        Me.Result(k).StartTime = Me.Result(k).StartTime.Add(addTime)
                        Me.Result(k).EndTime = Me.Result(k).EndTime.Add(addTime)
                    Next
                End If


            End If

            Me.SaveButton.Enabled = True

            Me.DisplayItemsAfterMerge()
        Catch ex As Exception
            Me.SaveButton.Enabled = False
        End Try

    End Sub

    Private Sub ExportedFileTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ExportedFileTypeComboBox.SelectionChangeCommitted
        If Me.ExportedFileTypeComboBox.Text = "Text File (.txt)" Then
            EnableDisableIncludeLineNumbers(True)
        Else
            EnableDisableIncludeLineNumbers(False)
        End If

        If Me.ExportedFileTypeComboBox.Text = "MicroDVD (.SUB)" Then
            Me.ShowHideFrameControls(True)
        Else
            Me.ShowHideFrameControls(False)
        End If
    End Sub

    Private Sub EnableDisableIncludeLineNumbers(ByVal showFlag As Boolean)
        Me.LineNumbersCheckBox.Visible = showFlag
        Me.SeparatorLabel.Visible = showFlag
        Me.SeparatorComboBox.Visible = showFlag
        Me.SplitLinesCheckBox.Visible = showFlag
    End Sub


    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Me.ResultDataGridView.Visible = False
        Me.ResultDataGridView.Rows.Clear()
        Me.ResultDataGridView.Columns.Clear()
        Me.Result.Clear()
        Me.TempResult.Clear()
        Me.FilesDataGridView.Rows.Clear()
        Me.MergeBtn.Enabled = False
        Me.Files.Clear()
        Me.ResultLocationTextBox.Text = ""
        Me.ResultLocationTextBox.Visible = False
        Me.ResultLabel.Text = ""
        Me.ResultLabel.Visible = False
        Me.ClearButton.Visible = False
        Me.CopyLocationButton.Visible = False
        Me.OpenFileButton.Visible = False
        Me.SaveButton.Enabled = False
    End Sub




    Private Sub FilesDataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles FilesDataGridView.RowsAdded
        Me.ChangeMergeBtnText()
      
    End Sub

    Private Sub FilesDataGridView_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles FilesDataGridView.RowsRemoved
        Me.ChangeMergeBtnText()
    End Sub

    Private Sub ChangeMergeBtnText()
        If Me.FilesDataGridView.Rows.Count = 0 Then
            Me.MergeBtn.Text = "Convert"
            Me.MergeBtn.Enabled = False
        ElseIf Me.FilesDataGridView.Rows.Count <= 1 Then
            Me.MergeBtn.Text = "Convert"
        Else
            Me.MergeBtn.Text = "Merge & Convert"
        End If

        If Me.FilesDataGridView.Rows.Count > 0 Then
            Me.RemoveFileButton.Enabled = True
        Else
            Me.RemoveFileButton.Enabled = False
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        OptionsDialog.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub OptionsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem1.Click
        OptionsDialog.ShowDialog()
    End Sub


    Private Sub HandleFilesGridPressUp(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Delete Then
            Me.RemoveSelectedDataGridItems()
        End If


    End Sub

    Private Sub EncodingComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EncodingComboBox.SelectionChangeCommitted
        For Each oneCell As DataGridViewCell In Me.FilesDataGridView.SelectedCells
            If oneCell.Selected And oneCell.GetType.Name = "DataGridViewTextBoxCell" Then
                Dim FileColumnIndex As Integer = Me.FilesDataGridView.Columns("File").Index
                oneCell = Me.FilesDataGridView.Rows(oneCell.RowIndex).Cells(FileColumnIndex)
                Dim tmpFile As TranscriptFile = Nothing
                For Each File As TranscriptFile In Me.Files
                    If File.FileName = oneCell.Value.ToString Then
                        tmpFile = File
                    End If
                Next
                If tmpFile IsNot Nothing Then
                    tmpFile.Transcripts.Clear()
                    Me.ReadFromFileIntoTranscript(tmpFile.Transcripts, tmpFile.FileName, Me.EncodingComboBox.SelectedValue.ToString)
                    tmpFile.FileEncoding = Me.EncodingComboBox.SelectedValue.ToString
                    'If Me.Result.Count > 0 Then 'only if the user clicked on Merge before updating encoding
                    '    Me.MergeBtn_Click(sender, e)
                    'End If

                End If

            End If
        Next
    End Sub

    Private Sub FilesDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles FilesDataGridView.SelectionChanged
        For Each oneCell As DataGridViewCell In Me.FilesDataGridView.SelectedCells
            Dim FileColumnIndex As Integer = Me.FilesDataGridView.Columns("File").Index
            oneCell = Me.FilesDataGridView.Rows(oneCell.RowIndex).Cells(FileColumnIndex)
            If oneCell.GetType.Name = "DataGridViewTextBoxCell" Then
                Dim tmpFile As TranscriptFile = Nothing
                For Each File As TranscriptFile In Me.Files
                    If File.FileName = oneCell.Value.ToString Then
                        tmpFile = File
                    End If
                Next
                If tmpFile IsNot Nothing Then
                    Me.EncodingComboBox.SelectedValue = tmpFile.FileEncoding
                End If

            End If
        Next
    End Sub

    Private Sub FramesRateTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles FramesRateTextBox.KeyUp
        exec.AllowOnlyDecimalNumbersInTextbox(Me.FramesRateTextBox, e)
    End Sub

    Private Sub TimingTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles TimingTextBox.KeyUp
        exec.AllowOnlyDecimalNumbersInTextbox(Me.TimingTextBox, e)
    End Sub

    Private Sub RemoveFileButton_Click(sender As Object, e As EventArgs) Handles RemoveFileButton.Click
        Me.RemoveSelectedDataGridItems()
        Me.SaveButton.Enabled = False
    End Sub


    Private Sub RemoveSelectedDataGridItems()
        Dim FileColumnIndex As Integer = Me.FilesDataGridView.Columns("File").Index
        For Each oneCell As DataGridViewCell In Me.FilesDataGridView.SelectedCells
            oneCell = Me.FilesDataGridView.Rows(oneCell.RowIndex).Cells(FileColumnIndex)
            If oneCell.GetType.Name = "DataGridViewTextBoxCell" Then
                Dim tmpFile As TranscriptFile = Nothing
                For Each File As TranscriptFile In Me.Files
                    If File.FileName = oneCell.Value.ToString Then
                        tmpFile = File
                    End If
                Next
                If tmpFile IsNot Nothing Then
                    Me.Files.Remove(tmpFile)
                End If
                Me.FilesDataGridView.Rows.RemoveAt(oneCell.RowIndex)
            End If
        Next

        If Me.FilesDataGridView.Rows.Count < 0 Then
            Me.MergeBtn.Enabled = False
        End If

        'reset everything, in case we don't have any files
        If Me.FilesDataGridView.Rows.Count = 0 Then
            Me.ClearButton_Click(Nothing, Nothing)
        End If
    End Sub

  
    Private Sub FilesDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles FilesDataGridView.DataError

    End Sub

    Private Sub FilesDataGridView_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles FilesDataGridView.EditingControlShowing
        Dim c As ComboBox = TryCast(e.Control, ComboBox)
        If c IsNot Nothing Then
            AddHandler c.SelectionChangeCommitted, AddressOf HandleDataGridViewComboboxItemCommitSelectionChangeFunction
        End If
    End Sub

    Private Sub HandleDataGridViewComboboxItemCommitSelectionChangeFunction(sender As Object, e As EventArgs)
        Dim FileColumnIndex As Integer = Me.FilesDataGridView.Columns("File").Index
        For Each oneCell As DataGridViewCell In Me.FilesDataGridView.SelectedCells
            Dim firstCell As DataGridViewCell = Me.FilesDataGridView.Rows(oneCell.RowIndex).Cells(FileColumnIndex)
            If firstCell.GetType.Name = "DataGridViewTextBoxCell" Then
                Dim tmpFile As TranscriptFile = Nothing
                For Each File As TranscriptFile In Me.Files
                    If File.FileName = firstCell.Value.ToString Then
                        tmpFile = File
                    End If
                Next
                If tmpFile IsNot Nothing Then
                    tmpFile.CharSet = sender.SelectedValue()
                End If

            End If
        Next
    End Sub

    Private Function GetFileNameWithoutAnyExtension(ByVal FileName As String)
        Try
            While FileName.Contains(".")
                FileName = FileName.Substring(0, FileName.LastIndexOf("."))
            End While
            Return FileName
        Catch ex As Exception
            Return FileName
        End Try
    End Function
    Private Sub SaveFileDialogDefaults(ByRef FSD As SaveFileDialog, ByRef GeneratedOutputPath As String)
        FSD.FilterIndex = 1
        FSD.FileName = GetFileNameWithoutAnyExtension(Path.GetFileName(FSD.FileName))
        FSD.ShowDialog()
        GeneratedOutputPath = FSD.FileName
    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim GeneratedOutputPath As String = ""

        Select Case Me.ExportedFileTypeComboBox.Text
            Case "SRT"
                Me.MySaveFileDialog.Filter = "SRT Files (.srt)|*.srt|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsSRT(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "Text File (.txt)"
                Me.MySaveFileDialog.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsTextFile(Me.Files, Me.Result, GeneratedOutputPath, Me.LineNumbersCheckBox.Checked, Me.SeparatorComboBox.Text, Me.SplitLinesCheckBox.Checked)
                End If



            Case "XML"
                Me.MySaveFileDialog.Filter = "XML Files (.xml)|*.xml|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsXML(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "JSON"
                Me.MySaveFileDialog.Filter = "JSON Files (.json)|*.json|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsJson(Me.Files, Me.Result, GeneratedOutputPath)
                End If


            Case "Netflix Timed Text (.DFXP)"
                Me.MySaveFileDialog.Filter = "Netflix Timed Text Files (.dfxp)|*.dfxp|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsDFXP(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "Spruce Subtitle File (.STL)"
                Me.MySaveFileDialog.Filter = "Spruce Subtitle Files (.stl)|*.stl|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsSTL(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "Advanced Sub Station Alpha (.ASS/.SSA)"
                Me.MySaveFileDialog.Filter = "Advanced Sub Station Alpha Files (.ass)|*.ass|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsSSA(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "TimedText 1.0 (.XML/.TTML)"
                Me.MySaveFileDialog.Filter = "TimedText 1.0 Files (.ttml)|*.ttml|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsTTML(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "Quick Time Text (.QT.TXT)"
                Me.MySaveFileDialog.Filter = "Quick Time Files (.qt.txt)|*.qt.txt|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsQT(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "SAMI(.SMI)"
                Me.MySaveFileDialog.Filter = "SAMI Files (.smi)|*.smi|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsSMI(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "CSV"
                Me.MySaveFileDialog.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsCSV(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "MicroDVD (.SUB)"
                Me.MySaveFileDialog.Filter = "MicroDVD Files (.sub)|*.sub|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsMicroDvd(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "SubViewer (.SUB)"
                Me.MySaveFileDialog.Filter = "SubViewer Files (.sub)|*.sub|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsSubViewer(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "Real Time (.RT)"
                Me.MySaveFileDialog.Filter = "Real Time Files (.rt)|*.rt|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsRT(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "YouTube (.SBV)"
                Me.MySaveFileDialog.Filter = "YouTube Files (.sbv)|*.sbv|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsSbv(Me.Files, Me.Result, GeneratedOutputPath)
                End If



            Case "Excel Text File (.CSV)"
                Me.MySaveFileDialog.Filter = "Excel Text Files (.csv)|*.csv|All Files (*.*)|*.*"
                Me.SaveFileDialogDefaults(Me.MySaveFileDialog, GeneratedOutputPath)
                If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
                    Language.ExportResultAsExcelCsv(Me.Files, Me.Result, GeneratedOutputPath)
                End If


        End Select

        'fill the textbox with the generated file name 
        If GeneratedOutputPath IsNot Nothing AndAlso GeneratedOutputPath <> "" Then
            Me.ResultLocationTextBox.Text = GeneratedOutputPath
        Else
            Me.ResultLocationTextBox.Text = "Error: File Path"
        End If


    End Sub
End Class




