Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.IO
Imports System.Xml

Public Module exec

    Public SPECIAL As String = "46;63;33;58;59;40;41;91;93;46;8217;34;34;47;44;39;48;49;50;51;52;53;54;55;56;57"
    Dim skipcharacters As String = " .-""_?!"
    Dim DoubleRegex As String = "^[0-9]([.,][0-9]{1,3})?$"

    Public Sub FillOutputFileTypes(ByRef list As Dictionary(Of String, String), ByRef combo As ComboBox)
        list.Add("SRT", "SRT")
        list.Add("Excel Text File (.CSV)", "CSV")
        list.Add("Text File (.txt)", "TXT")
        list.Add("XML", "XML")
        list.Add("JSON", "JSON")
        list.Add("Netflix Timed Text (.DFXP)", "DFXP")
        list.Add("Spruce Subtitle File (.STL)", "STL")
        list.Add("Advanced Sub Station Alpha (.ASS/.SSA)", "SSA")
        list.Add("TimedText 1.0 (.XML/.TTML)", "TTML")
        list.Add("Quick Time Text (.QT.TXT)", "QT.TXT")
        list.Add("WebVit (.vtt)", "VTT")
        list.Add("SAMI (.SMI)", "SMI")
        list.Add("CSV", "CSV")
        list.Add("MicroDVD (.SUB)", "SUB")
        list.Add("SubViewer (.SUB)", "SUB")
        list.Add("Real Time (.RT)", "RT")
        list.Add("YouTube (.SBV)", "SBV")

        combo.DataSource = New BindingSource(list, Nothing)
        combo.DisplayMember = "Key"
        combo.ValueMember = "Value"
        combo.SelectedIndex = 0
    End Sub

    Function isMatchManual(ByVal ch As String, ByVal comma As Boolean, ByVal Slash As Boolean, ByVal dot As Boolean, ByVal dash As Boolean, ByVal MatchGroup As Boolean, ByRef Group As LanguageRange) As Boolean
        If My.Settings.SubMergeSetting_IgnoreSpecial Then
            If My.Settings.SubMergeSetting_SpecialLetters.Contains(ch) Then
                Return False
            End If
        End If

        If ch = "," And comma Then
            Return False
        End If

        If (ch = "\" Or ch = "/") And Slash Then
            Return False
        End If

        If ch = "-" And dash Then
            Return False
        End If

        If ch = "." And dot Then
            Return False
        End If

        ' to include all letters except the ignore list
        If Not MatchGroup Then
            Return True
        End If



        If ch = " " Then
            Return True
        End If

        'faster for English
        If (Regex.IsMatch(ch.ToString, "[0-9]")) Then
            Return True
        End If

        For Each w As String In SPECIAL.Split(";")
            If w = AscW(ch).ToString.ToString Then
                Return True
            End If
        Next

        'Match Only Letters in this group
        If AscW(ch) >= Group.StartPosition And AscW(ch) <= Group.EndPosition Then
            Return True
        End If

        Return False
    End Function

    Public Function RefineString(ByVal l As String, ByVal comma As Boolean, ByVal Slash As Boolean, ByVal dot As Boolean, ByVal dash As Boolean, ByVal MatchGroup As Boolean, ByRef Group As LanguageRange) As String
        Dim r As String = ""
        For Each ch As Char In l
            'If Not MatchGroup Then
            '    r = r + ch
            'ElseIf isMatchManual(ch, comma, dot, dash, MatchGroup, Group) Then
            '    r = r + ch
            'End If

            If isMatchManual(ch, comma, Slash, dot, dash, MatchGroup, Group) Then
                r = r + ch
            End If

        Next
        Return r
    End Function

    Public Sub ParseTranscriptTime(ByVal line As String, ByRef transcript As Transcript)
        Dim p1 As String = LTrim(RTrim(line.Substring(0, line.IndexOf("-->"))))
        Dim p2 As String = LTrim(RTrim(Right(line, line.IndexOf("-->"))))
        transcript.StartTime = convertTranscriptTextToTimeSpan(p1)
        transcript.EndTime = convertTranscriptTextToTimeSpan(p2)

    End Sub

    Public Function convertTranscriptTextToTimeSpan(ByVal txt As String) As TimeSpan
        '00:00:2,00
        Try
            Return TimeSpan.ParseExact(txt, "h\:m\:s\,fff", CultureInfo.InvariantCulture)
        Catch ex1 As Exception

            Try
                Dim milliSeconds As String = txt.Substring(txt.IndexOf(",") + 1, txt.Length - txt.IndexOf(",") - 1)
                If milliSeconds.Length <= 3 Then
                    For i As Integer = milliSeconds.Length + 1 To 3
                        milliSeconds = "0" + milliSeconds
                    Next
                End If
                txt = String.Format("{0},{1}", txt.Substring(0, txt.LastIndexOf(",")), milliSeconds)

                Return TimeSpan.ParseExact(txt, "h\:m\:s\,fff", CultureInfo.InvariantCulture)
            Catch ex2 As Exception
                Return New TimeSpan
            End Try

        End Try

    End Function



    Public Function TrimString(ByVal str As String) As String
        For Each ch As Char In str
            If skipcharacters.Contains(ch) Then
                str = str.Substring(1)
            Else
                Exit For
            End If
        Next
        For i As Integer = str.Length - 1 To 0 Step -1
            If skipcharacters.Contains(str(i)) Then
                str = str.Substring(0, str.Length - 1)
            Else
                Exit For
            End If
        Next
        Return str
    End Function

    Public Sub ShellExecute(ByVal File As String)
        Try
            Dim myProcess As New Process
            myProcess.StartInfo.FileName = File
            myProcess.StartInfo.UseShellExecute = True
            myProcess.StartInfo.RedirectStandardOutput = False
            myProcess.Start()
            myProcess.Dispose()
        Catch ex As Exception

        End Try

    End Sub


    Public Function StripHTML(ByVal sourcestring As String)
        Dim replacementstring As String = ""
        Dim matchpattern As String = "<(?:[^>=]|='[^']*'|=""[^""]*""|=[^'""][^\s>]*)*>"
        Return Regex.Replace(sourcestring, matchpattern, replacementstring, RegexOptions.IgnoreCase Or RegexOptions.IgnorePatternWhitespace Or RegexOptions.Multiline Or RegexOptions.Singleline)
    End Function

    Public Function GetUniqueToken(ByVal prefix As String, ByVal separator As String) As String
        Dim d As DateTime = Now
        Dim unique_number As String = ConvertNumberToBase36(ULong.Parse(d.ToString(SubMerge_DEFAULTS.TokenDateFormat)))
        Dim token As String = String.Format("{0}{1}{2}", prefix, separator, unique_number)
        Return token
    End Function
    Public Function GetUniqueToken(ByVal prefix As String, ByVal separator As String, ByVal baseInt As Integer) As String
        Dim d As DateTime = Now
        Dim unique_number As String = ConvertNumberToBaseN(ULong.Parse(d.ToString(SubMerge_DEFAULTS.TokenDateFormat)), baseInt)
        Dim token As String = String.Format("{0}{1}{2}", prefix, separator, unique_number)
        Return token
    End Function


    Public Function ConvertNumberToBase36(ByVal n As ULong) As String
        Return ConvertNumberToBaseN(n, SubMerge_DEFAULTS.NumberRepresentationBase36)
    End Function

    Public Function ConvertNumberToBaseN(ByVal n As ULong, ByVal modValue As Integer) As String
        Dim res As String = Nothing
        Do

            Dim r As Integer = n Mod modValue
            n = Math.Floor(n / modValue)
            res = res + MapNumberIntoChar(r)
        Loop Until n <= 0

        Return StrReverse(res)
    End Function

    Public Function MapNumberIntoChar(ByVal n As UInt16) As Char

        Try
            Select Case n
                Case 0 : Return "0" : Case 1 : Return "1"
                Case 2 : Return "2" : Case 3 : Return "3"
                Case 4 : Return "4" : Case 5 : Return "5"
                Case 6 : Return "6" : Case 7 : Return "7"
                Case 8 : Return "8" : Case 9 : Return "9"
                Case 10 : Return "A" : Case 11 : Return "B"
                Case 12 : Return "C" : Case 13 : Return "D"
                Case 14 : Return "E" : Case 15 : Return "F"
                Case 16 : Return "G" : Case 17 : Return "H"
                Case 18 : Return "I" : Case 19 : Return "J"
                Case 20 : Return "K" : Case 21 : Return "L"
                Case 22 : Return "M" : Case 23 : Return "N"
                Case 24 : Return "O" : Case 25 : Return "P"
                Case 26 : Return "Q" : Case 27 : Return "R"
                Case 28 : Return "S" : Case 29 : Return "T"
                Case 30 : Return "U" : Case 31 : Return "V"
                Case 32 : Return "W" : Case 33 : Return "X"
                Case 34 : Return "Y" : Case 35 : Return "Z"
                Case 36 : Return "a" : Case 37 : Return "b"
                Case 38 : Return "c" : Case 39 : Return "d"
                Case 40 : Return "e" : Case 41 : Return "f"
                Case 42 : Return "g" : Case 43 : Return "h"
                Case 44 : Return "i" : Case 45 : Return "j"
                Case 46 : Return "k" : Case 47 : Return "l"
                Case 48 : Return "m" : Case 49 : Return "n"
                Case 50 : Return "o" : Case 51 : Return "p"
                Case 52 : Return "q" : Case 53 : Return "r"
                Case 54 : Return "s" : Case 55 : Return "t"
                Case 56 : Return "u" : Case 57 : Return "v"
                Case 58 : Return "w" : Case 59 : Return "x"
                Case 60 : Return "y" : Case 61 : Return "z"

                Case 62 : Return "-" : Case 63 : Return "_"
                Case 64 : Return "."
            End Select
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Class SubMerge_DEFAULTS
        Public Const NumberRepresentationBase36 As Integer = 36
        Public Const Separator As String = "-"
        Public Const TokenDateFormat As String = "yyMMddhhmmss"
    End Class


    Public Sub AllowOnlyDecimalNumbersInTextbox(ByRef txtbox As TextBox, ByRef e As KeyEventArgs)
        Dim r As New Regex(DoubleRegex)

        Dim m As Match = r.Match(txtbox.Text)
        If Not m.Success Then
            txtbox.Text = txtbox.Text.Replace(e.KeyData.ToString.ToLower, "")
            txtbox.Text = txtbox.Text.Replace(e.KeyData.ToString.ToUpper, "")
        End If
    End Sub

    Private Sub SaveDictionaryIntoFile(ByVal FileName As String, ByRef obj As Dictionary(Of String, String))
        Dim F As Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim s As IO.Stream
        F = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        s = New IO.FileStream(FileName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
        F.Serialize(s, obj)
        s.Close()

    End Sub

    Private Function LoadDictionaryFromFile(ByVal FileName As String) As Dictionary(Of String, String)
        Dim obj As Dictionary(Of String, String)
        Dim f As Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim s As IO.Stream
        f = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        s = New IO.FileStream(FileName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
        obj = DirectCast(f.Deserialize(s), Dictionary(Of String, String))
        s.Close()
        Return obj
    End Function

    Public Sub SaveListntoFile(ByVal FileName As String, ByRef obj As List(Of String))
        Dim F As Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim s As IO.Stream
        F = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        s = New IO.FileStream(FileName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
        F.Serialize(s, obj)
        s.Close()
        s.Dispose()
    End Sub

    Public Function LoadListFromFile(ByVal FileName As String) As List(Of String)
        Dim obj As List(Of String)
        Dim f As Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim s As IO.Stream
        f = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        s = New IO.FileStream(FileName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
        obj = DirectCast(f.Deserialize(s), List(Of String))
        s.Close()
        s.Dispose()
        Return obj
    End Function

End Module
