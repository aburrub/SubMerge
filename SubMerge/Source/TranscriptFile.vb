Public Class TranscriptFile
    Public FileName As String
    Public SafeFileName As String
    Public Transcripts As New List(Of Transcript)
    Public FileEncoding As String
    Public CharSet As LanguageRange
    Public LanguageRanges As Dictionary(Of String, LanguageRange)


    Public Sub New(ByVal SafeFileName As String, ByVal FileName As String, ByRef Transcripts As List(Of Transcript), ByVal EncodingName As String, ByRef LanguageRanges As Dictionary(Of String, LanguageRange), ByVal charSet As String)
        Me.SafeFileName = SafeFileName
        Me.FileName = FileName
        Me.Transcripts = Transcripts
        Me.FileEncoding = EncodingName
        If LanguageRanges IsNot Nothing And LanguageRanges.Count > 0 Then
            Me.LanguageRanges = LanguageRanges
            Me.CharSet = Me.LanguageRanges(charSet)
        End If

    End Sub

End Class
