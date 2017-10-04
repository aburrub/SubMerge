Imports System.IO
Imports System.Xml

Public Module Language
    Public Class LanguageRange
        Public RangeName As String
        Public StartPosition As Integer
        Public EndPosition As Integer

        Public Sub New(ByVal RangeName As String, ByVal StartPosition As String, ByVal EndPosition As String)
            Me.RangeName = RangeName
            Me.StartPosition = ConvertHex(StartPosition)
            Me.EndPosition = ConvertHex(EndPosition)
        End Sub
        Private Function ConvertHex(ByVal s As String) As Integer
            Dim sum As Integer = 0
            For i As Integer = s.Length - 1 To 0 Step -1
                sum += GetHexNumber(s(i)) * Math.Pow(16, s.Length - i - 1)
            Next
            Return sum
        End Function

        Private Function GetHexNumber(ByVal ch As Char) As Integer
            If ch.ToString.ToLower = "a" Then
                Return 10
            End If

            If ch.ToString.ToLower = "b" Then
                Return 11
            End If

            If ch.ToString.ToLower = "c" Then
                Return 12
            End If

            If ch.ToString.ToLower = "d" Then
                Return 13
            End If

            If ch.ToString.ToLower = "e" Then
                Return 14
            End If

            If ch.ToString.ToLower = "f" Then
                Return 15
            End If

            Try
                If Integer.Parse(ch.ToString) >= 0 And Integer.Parse(ch.ToString) <= 9 Then
                    Return Integer.Parse(ch.ToString)
                End If
                Return 0
            Catch ex As Exception
                Return 0
            End Try
        End Function
    End Class
    Public Sub LanguageRangesInit(ByRef Ranges As Dictionary(Of String, LanguageRange))
        Ranges.Add("All Char Sets", New LanguageRange("All Char Sets", "0", "0"))
        Ranges.Add("Aegean Numbers", New LanguageRange("Aegean Numbers", "1010", "013F"))
        Ranges.Add("Alphabetic Presentation Forms", New LanguageRange("Alphabetic Presentation Forms", "FB00", "FB4F"))
        Ranges.Add("Arabic", New LanguageRange("Arabic", "0600", "06FF"))
        Ranges.Add("Arabic Presentation Forms-A", New LanguageRange("Arabic Presentation Forms-A", "FB50", "FDFF"))
        Ranges.Add("Arabic Presentation Forms-B", New LanguageRange("Arabic Presentation Forms-B", "FE70", "FEFF"))
        Ranges.Add("Armenian", New LanguageRange("Armenian", "0530", "058F"))
        Ranges.Add("Arrows", New LanguageRange("Arrows", "2190", "21FF"))
        Ranges.Add("Basic Latin", New LanguageRange("Basic Latin", "0020", "007F"))
        Ranges.Add("Bengali", New LanguageRange("Bengali", "0980", "09FF"))
        Ranges.Add("Block Elements", New LanguageRange("Block Elements", "2580", "259F"))
        Ranges.Add("Bopomofo", New LanguageRange("Bopomofo", "3100", "312F"))
        Ranges.Add("Bopomofo Extended", New LanguageRange("Bopomofo Extended", "31A0", "31BF"))
        Ranges.Add("Box Drawing", New LanguageRange("Box Drawing", "2500", "257F"))
        Ranges.Add("Braille Patterns", New LanguageRange("Braille Patterns", "2800", "28FF"))
        Ranges.Add("Buhid", New LanguageRange("Buhid", "1740", "175F"))
        Ranges.Add("Byzantine Musical Symbols", New LanguageRange("Byzantine Musical Symbols", "1D00", "D0FF"))
        Ranges.Add("Cherokee", New LanguageRange("Cherokee", "13A0", "13FF"))
        Ranges.Add("CJK Compatibility", New LanguageRange("CJK Compatibility", "3300", "33FF"))
        Ranges.Add("CJK Compatibility Forms", New LanguageRange("CJK Compatibility Forms", "FE30", "FE4F"))
        Ranges.Add("CJK Compatibility Ideographs", New LanguageRange("CJK Compatibility Ideographs", "F900", "FAFF"))
        Ranges.Add("CJK Compatibility Ideographs Supplement", New LanguageRange("CJK Compatibility Ideographs Supplement", "2F80", "FA1F"))
        Ranges.Add("CJK Radicals Supplement", New LanguageRange("CJK Radicals Supplement", "2E80", "2EFF"))
        Ranges.Add("CJK Symbols and Punctuation", New LanguageRange("CJK Symbols and Punctuation", "3000", "303F"))
        Ranges.Add("CJK Unified Ideographs", New LanguageRange("CJK Unified Ideographs", "4E00", "9FFF"))
        Ranges.Add("CJK Unified Ideographs Extension A", New LanguageRange("CJK Unified Ideographs Extension A", "3400", "4DBF"))
        Ranges.Add("CJK Unified Ideographs Extension B", New LanguageRange("CJK Unified Ideographs Extension B", "2000", "A6DF"))
        Ranges.Add("Combining Diacritical Marks", New LanguageRange("Combining Diacritical Marks", "0300", "036F"))
        Ranges.Add("Combining Diacritical Marks for Symbols", New LanguageRange("Combining Diacritical Marks for Symbols", "20D0", "20FF"))
        Ranges.Add("Combining Half Marks", New LanguageRange("Combining Half Marks", "FE20", "FE2F"))
        Ranges.Add("Control Pictures", New LanguageRange("Control Pictures", "2400", "243F"))
        Ranges.Add("Currency Symbols", New LanguageRange("Currency Symbols", "20A0", "20CF"))
        Ranges.Add("Cypriot Syllabary", New LanguageRange("Cypriot Syllabary", "1080", "083F"))
        Ranges.Add("Cyrillic", New LanguageRange("Cyrillic", "0400", "04FF"))
        Ranges.Add("Cyrillic Supplementary", New LanguageRange("Cyrillic Supplementary", "0500", "052F"))
        Ranges.Add("Deseret", New LanguageRange("Deseret", "1040", "044F"))
        Ranges.Add("Devanagari", New LanguageRange("Devanagari", "0900", "097F"))
        Ranges.Add("Dingbats", New LanguageRange("Dingbats", "2700", "27BF"))
        Ranges.Add("Enclosed Alphanumerics", New LanguageRange("Enclosed Alphanumerics", "2460", "24FF"))
        Ranges.Add("Enclosed CJK Letters and Months", New LanguageRange("Enclosed CJK Letters and Months", "3200", "32FF"))
        Ranges.Add("Ethiopic", New LanguageRange("Ethiopic", "1200", "137F"))
        Ranges.Add("General Punctuation", New LanguageRange("General Punctuation", "2000", "206F"))
        Ranges.Add("Geometric Shapes", New LanguageRange("Geometric Shapes", "25A0", "25FF"))
        Ranges.Add("Georgian", New LanguageRange("Georgian", "10A0", "10FF"))
        Ranges.Add("Gothic", New LanguageRange("Gothic", "1033", "034F"))
        Ranges.Add("Greek and Coptic", New LanguageRange("Greek and Coptic", "0370", "03FF"))
        Ranges.Add("Greek Extended", New LanguageRange("Greek Extended", "1F00", "1FFF"))
        Ranges.Add("Gujarati", New LanguageRange("Gujarati", "0A80", "0AFF"))
        Ranges.Add("Gurmukhi", New LanguageRange("Gurmukhi", "0A00", "0A7F"))
        Ranges.Add("Halfwidth and Fullwidth Forms", New LanguageRange("Halfwidth and Fullwidth Forms", "FF00", "FFEF"))
        Ranges.Add("Hangul Compatibility Jamo", New LanguageRange("Hangul Compatibility Jamo", "3130", "318F"))
        Ranges.Add("Hangul Jamo", New LanguageRange("Hangul Jamo", "1100", "11FF"))
        Ranges.Add("Hangul Syllables", New LanguageRange("Hangul Syllables", "AC00", "D7AF"))
        Ranges.Add("Hanunoo", New LanguageRange("Hanunoo", "1720", "173F"))
        Ranges.Add("Hebrew", New LanguageRange("Hebrew", "0590", "05FF"))
        Ranges.Add("High Private Use Surrogates", New LanguageRange("High Private Use Surrogates", "DB80", "DBFF"))
        Ranges.Add("High Surrogates", New LanguageRange("High Surrogates", "D800", "DB7F"))
        Ranges.Add("Hiragana", New LanguageRange("Hiragana", "3040", "309F"))
        Ranges.Add("Ideographic Description Characters", New LanguageRange("Ideographic Description Characters", "2FF0", "2FFF"))
        Ranges.Add("IPA Extensions", New LanguageRange("IPA Extensions", "0250", "02AF"))
        Ranges.Add("Kanbun", New LanguageRange("Kanbun", "3190", "319F"))
        Ranges.Add("Kangxi Radicals", New LanguageRange("Kangxi Radicals", "2F00", "2FDF"))
        Ranges.Add("Kannada", New LanguageRange("Kannada", "0C80", "0CFF"))
        Ranges.Add("Katakana", New LanguageRange("Katakana", "30A0", "30FF"))
        Ranges.Add("Katakana Phonetic Extensions", New LanguageRange("Katakana Phonetic Extensions", "31F0", "31FF"))
        Ranges.Add("Khmer", New LanguageRange("Khmer", "1780", "17FF"))
        Ranges.Add("Khmer Symbols", New LanguageRange("Khmer Symbols", "19E0", "19FF"))
        Ranges.Add("Lao", New LanguageRange("Lao", "0E80", "0EFF"))
        Ranges.Add("Latin Extended Additional", New LanguageRange("Latin Extended Additional", "1E00", "1EFF"))
        Ranges.Add("Latin Extended-A", New LanguageRange("Latin Extended-A", "0100", "017F"))
        Ranges.Add("Latin Extended-B", New LanguageRange("Latin Extended-B", "0180", "024F"))
        Ranges.Add("Latin-1 Supplement", New LanguageRange("Latin-1 Supplement", "00A0", "00FF"))
        Ranges.Add("Letterlike Symbols", New LanguageRange("Letterlike Symbols", "2100", "214F"))
        Ranges.Add("Limbu", New LanguageRange("Limbu", "1900", "194F"))
        Ranges.Add("Linear B Ideograms", New LanguageRange("Linear B Ideograms", "1008", "00FF"))
        Ranges.Add("Linear B Syllabary", New LanguageRange("Linear B Syllabary", "1000", "007F"))
        Ranges.Add("Low Surrogates", New LanguageRange("Low Surrogates", "DC00", "DFFF"))
        Ranges.Add("Malayalam", New LanguageRange("Malayalam", "0D00", "0D7F"))
        Ranges.Add("Mathematical Alphanumeric Symbols", New LanguageRange("Mathematical Alphanumeric Symbols", "1D40", "D7FF"))
        Ranges.Add("Mathematical Operators", New LanguageRange("Mathematical Operators", "2200", "22FF"))
        Ranges.Add("Miscellaneous Mathematical Symbols-A", New LanguageRange("Miscellaneous Mathematical Symbols-A", "27C0", "27EF"))
        Ranges.Add("Miscellaneous Mathematical Symbols-B", New LanguageRange("Miscellaneous Mathematical Symbols-B", "2980", "29FF"))
        Ranges.Add("Miscellaneous Symbols", New LanguageRange("Miscellaneous Symbols", "2600", "26FF"))
        Ranges.Add("Miscellaneous Symbols and Arrows", New LanguageRange("Miscellaneous Symbols and Arrows", "2B00", "2BFF"))
        Ranges.Add("Miscellaneous Technical", New LanguageRange("Miscellaneous Technical", "2300", "23FF"))
        Ranges.Add("Mongolian", New LanguageRange("Mongolian", "1800", "18AF"))
        Ranges.Add("Musical Symbols", New LanguageRange("Musical Symbols", "1D10", "D1FF"))
        Ranges.Add("Myanmar", New LanguageRange("Myanmar", "1000", "109F"))
        Ranges.Add("Number Forms", New LanguageRange("Number Forms", "2150", "218F"))
        Ranges.Add("Ogham", New LanguageRange("Ogham", "1680", "169F"))
        Ranges.Add("Old Italic", New LanguageRange("Old Italic", "1030", "032F"))
        Ranges.Add("Optical Character Recognition", New LanguageRange("Optical Character Recognition", "2440", "245F"))
        Ranges.Add("Oriya", New LanguageRange("Oriya", "0B00", "0B7F"))
        Ranges.Add("Osmanya", New LanguageRange("Osmanya", "1048", "04AF"))
        Ranges.Add("Phonetic Extensions", New LanguageRange("Phonetic Extensions", "1D00", "1D7F"))
        Ranges.Add("Private Use Area", New LanguageRange("Private Use Area", "E000", "F8FF"))
        Ranges.Add("Runic", New LanguageRange("Runic", "16A0", "16FF"))
        Ranges.Add("Shavian", New LanguageRange("Shavian", "1045", "047F"))
        Ranges.Add("Sinhala", New LanguageRange("Sinhala", "0D80", "0DFF"))
        Ranges.Add("Small Form Variants", New LanguageRange("Small Form Variants", "FE50", "FE6F"))
        Ranges.Add("Spacing Modifier Letters", New LanguageRange("Spacing Modifier Letters", "02B0", "02FF"))
        Ranges.Add("Specials", New LanguageRange("Specials", "FFF0", "FFFF"))
        Ranges.Add("Superscripts and Subscripts", New LanguageRange("Superscripts and Subscripts", "2070", "209F"))
        Ranges.Add("Supplemental Arrows-A", New LanguageRange("Supplemental Arrows-A", "27F0", "27FF"))
        Ranges.Add("Supplemental Arrows-B", New LanguageRange("Supplemental Arrows-B", "2900", "297F"))
        Ranges.Add("Supplemental Mathematical Operators", New LanguageRange("Supplemental Mathematical Operators", "2A00", "2AFF"))
        Ranges.Add("Syriac", New LanguageRange("Syriac", "0700", "074F"))
        Ranges.Add("Tagalog", New LanguageRange("Tagalog", "1700", "171F"))
        Ranges.Add("Tagbanwa", New LanguageRange("Tagbanwa", "1760", "177F"))
        Ranges.Add("Tags", New LanguageRange("Tags", "E000", "007F"))
        Ranges.Add("Tai Le", New LanguageRange("Tai Le", "1950", "197F"))
        Ranges.Add("Tai Xuan Jing Symbols", New LanguageRange("Tai Xuan Jing Symbols", "1D30", "D35F"))
        Ranges.Add("Tamil", New LanguageRange("Tamil", "0B80", "0BFF"))
        Ranges.Add("Telugu", New LanguageRange("Telugu", "0C00", "0C7F"))
        Ranges.Add("Thaana", New LanguageRange("Thaana", "0780", "07BF"))
        Ranges.Add("Thai", New LanguageRange("Thai", "0E00", "0E7F"))
        Ranges.Add("Tibetan", New LanguageRange("Tibetan", "0F00", "0FFF"))
        Ranges.Add("Ugaritic", New LanguageRange("Ugaritic", "1038", "039F"))
        Ranges.Add("Unified Canadian Aboriginal Syllabics", New LanguageRange("Unified Canadian Aboriginal Syllabics", "1400", "167F"))
        Ranges.Add("Variation Selectors", New LanguageRange("Variation Selectors", "FE00", "FE0F"))
        Ranges.Add("Yi Radicals", New LanguageRange("Yi Radicals", "A490", "A4CF"))
        Ranges.Add("Yi Syllables", New LanguageRange("Yi Syllables", "A000", "A48F"))
        Ranges.Add("Yijing Hexagram Symbols", New LanguageRange("Yijing Hexagram Symbols", "4DC0", "4DFF"))

    End Sub




    Public Function ExportResultAsSRT(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        For Each t As Transcript In Result
            writer.WriteLine(orderIndex)
            writer.WriteLine("{0} --> {1}", t.StartTime.ToString("hh\:mm\:ss\,fff"), t.EndTime.ToString("hh\:mm\:ss\,fff"))
            For Each tr As String In t.OtherSentences
                writer.WriteLine(tr)
            Next
            writer.WriteLine("")
            orderIndex += 1
        Next

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function




    Public Function ExportResultAsTextFile(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String, ByVal IncludeLineNumbers As Boolean, ByVal Separater As String, ByVal SplitTwoLines As Boolean) As String

        Dim fi As New FileInfo(Files(0).FileName)



        If SplitTwoLines Then
            Dim orderFormat As String = "{0}{1}"
            If Separater = "()" Then
                orderFormat = "({0})"
            End If

            If Separater = "[]" Then
                orderFormat = "[{0}]"
            End If


            Dim writer As New StreamWriter(SaveDialogFilePath)
            Dim orderIndex As Integer = 1
            For Each t As Transcript In Result
                Dim FullSentence As String = ""
                For Each tr As String In t.OtherSentences
                    FullSentence = String.Format("{0}[{1}]{2}", FullSentence, tr, Environment.NewLine)
                Next

                If Not IncludeLineNumbers Then
                    writer.WriteLine("{0}", FullSentence)
                Else
                    writer.WriteLine(orderFormat + Environment.NewLine + "{2}", orderIndex, Separater, FullSentence)
                End If

                orderIndex += 1
            Next

            writer.Close()
            writer.Dispose()
        Else
            Dim orderFormat As String = "{0}{1}"
            If Separater = "()" Then
                orderFormat = "({0})"
            End If

            If Separater = "[]" Then
                orderFormat = "[{0}]"
            End If


            Dim writer As New StreamWriter(SaveDialogFilePath)
            Dim orderIndex As Integer = 1
            For Each t As Transcript In Result
                Dim FullSentence As String = ""
                For Each tr As String In t.OtherSentences
                    If IncludeLineNumbers Then
                        FullSentence = String.Format("{0} [{1}]", FullSentence, tr)
                    Else
                        FullSentence = String.Format("{0}[{1}]", FullSentence, tr)
                    End If

                Next

                If Not IncludeLineNumbers Then
                    writer.WriteLine("{0}", FullSentence)
                Else
                    writer.WriteLine(orderFormat + "{2}", orderIndex, Separater, FullSentence)
                End If

                orderIndex += 1
            Next

            writer.Close()
            writer.Dispose()
        End If

        Return SaveDialogFilePath
    End Function


    Public Function ExportResultAsXML(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        writer.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        writer.WriteLine("<Captions>")
        For Each t As Transcript In Result
            writer.WriteLine(String.Format(Chr(9) + "<Caption Order=""{0}"" StartTime=""{1}"" EndTime=""{2}"">", orderIndex, t.StartTime.ToString("hh\:mm\:ss\,fff"), t.EndTime.ToString("hh\:mm\:ss\,fff")))
            writer.WriteLine(Chr(9) + Chr(9) + "<Sentences>")
            For i As Integer = 0 To t.OtherSentences.Count - 1
                writer.WriteLine(String.Format(Chr(9) + Chr(9) + Chr(9) + "<Sentence{1}>{0}</Sentence{1}>", t.OtherSentences(i), i + 1))
            Next
            writer.WriteLine(Chr(9) + Chr(9) + "</Sentences>")
            writer.WriteLine(Chr(9) + "</Caption>")
            orderIndex += 1
        Next
        writer.WriteLine("</Captions>")
        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

    Public Function ExportResultAsJson(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        writer.WriteLine("{")
        writer.WriteLine(Chr(9) + """Captions"": {")

        For i As Integer = 0 To Result.Count - 1
            Dim t As Transcript = Result(i)
            If i = 0 Then
                writer.WriteLine(Chr(9) + Chr(9) + """Caption"": [")
            End If
            writer.WriteLine(Chr(9) + Chr(9) + Chr(9) + "{")
            writer.WriteLine(String.Format(Chr(9) + Chr(9) + Chr(9) + Chr(9) + """Order"": ""{0}"",", t.order))
            writer.WriteLine(String.Format(Chr(9) + Chr(9) + Chr(9) + Chr(9) + """StartTime"": ""{0}"",", t.StartTime.ToString("hh\:mm\:ss\,fff")))
            writer.WriteLine(String.Format(Chr(9) + Chr(9) + Chr(9) + Chr(9) + """EndTime"": ""{0}"",", t.EndTime.ToString("hh\:mm\:ss\,fff")))
            writer.WriteLine(Chr(9) + Chr(9) + Chr(9) + Chr(9) + """Sentences"": {")
            For j As Integer = 0 To t.OtherSentences.Count - 1
                writer.WriteLine(String.Format(Chr(9) + Chr(9) + Chr(9) + Chr(9) + Chr(9) + """Sentence{1}"": ""{0}"",", t.OtherSentences(j), j + 1))
            Next
            writer.WriteLine(Chr(9) + Chr(9) + Chr(9) + Chr(9) + "}")
            writer.WriteLine(Chr(9) + Chr(9) + Chr(9) + "}" + If(i = Result.Count - 1, "", ","))

            orderIndex += 1
        Next
        writer.WriteLine(Chr(9) + Chr(9) + "]")
        writer.WriteLine(Chr(9) + "}")
        writer.WriteLine("}")
        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function



    Public Function ExportResultAsDFXP(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        writer.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        writer.WriteLine("<tt xml:lang='en' xmlns='http://www.w3.org/2006/10/ttaf1' xmlns:tts='http://www.w3.org/2006/10/ttaf1#style'>")
        writer.WriteLine(Chr(9) + "<head></head>")
        writer.WriteLine(Chr(9) + "<body>")
        writer.WriteLine(Chr(9) + Chr(9) + "<div xml:id=""captions"">")
        For Each t As Transcript In Result
            writer.Write(String.Format(Chr(9) + Chr(9) + Chr(9) + "<p begin=""{0}"" end=""{1}"">", t.StartTime.ToString("hh\:mm\:ss\.fff"), t.EndTime.ToString("hh\:mm\:ss\.fff")))
            For i As Integer = 0 To t.OtherSentences.Count - 1
                If i = t.OtherSentences.Count - 1 Then
                    writer.Write(String.Format("{0}", t.OtherSentences(i)))
                Else
                    writer.Write(String.Format("{0}<br />", t.OtherSentences(i)))
                End If

            Next
            writer.WriteLine("</p>")
            orderIndex += 1
        Next
        writer.WriteLine(Chr(9) + Chr(9) + "</div>")
        writer.WriteLine(Chr(9) + "</body>")
        writer.WriteLine("</tt>")
        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function


    Public Function ExportResultAsSTL(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        writer.WriteLine("//Font select and font size")
        writer.WriteLine("$FontName       = Arial")
        writer.WriteLine("$FontSize       = 30")
        writer.WriteLine("")
        writer.WriteLine("//Character attributes (global)")
        writer.WriteLine("$Bold           = FALSE")
        writer.WriteLine("$UnderLined     = FALSE")
        writer.WriteLine("$Italic         = FALSE")
        writer.WriteLine("")
        writer.WriteLine("//Position Control")
        writer.WriteLine("$HorzAlign      = Center")
        writer.WriteLine("$VertAlign      = Bottom")
        writer.WriteLine("$XOffset        = 0")
        writer.WriteLine("$YOffset        = 0")
        writer.WriteLine("")
        writer.WriteLine("//Contrast Control")
        writer.WriteLine("$TextContrast           = 15")
        writer.WriteLine("$Outline1Contrast       = 8")
        writer.WriteLine("$Outline2Contrast       = 15")
        writer.WriteLine("$BackgroundContrast     = 0")
        writer.WriteLine("")
        writer.WriteLine("//Effects Control")
        writer.WriteLine("$ForceDisplay   = FALSE")
        writer.WriteLine("$FadeIn         = 0")
        writer.WriteLine("$FadeOut        = 0")
        writer.WriteLine("")
        writer.WriteLine("//Other Controls")
        writer.WriteLine("$TapeOffset          = FALSE")
        writer.WriteLine("//$SetFilePathToken  = <<:>>")
        writer.WriteLine("")
        writer.WriteLine("//Colors")
        writer.WriteLine("$ColorIndex1    = 0")
        writer.WriteLine("$ColorIndex2    = 1")
        writer.WriteLine("$ColorIndex3    = 2")
        writer.WriteLine("$ColorIndex4    = 3")
        writer.WriteLine("")
        writer.WriteLine("//Subtitles")
        For Each t As Transcript In Result
            writer.Write(String.Format("{0},{1},", t.StartTime.ToString("hh\:mm\:ss\:ff"), t.EndTime.ToString("hh\:mm\:ss\:ff")))
            For i As Integer = 0 To t.OtherSentences.Count - 1
                If i = t.OtherSentences.Count - 1 Then
                    writer.Write(String.Format("{0}{1}", t.OtherSentences(i), Environment.NewLine))
                Else
                    writer.Write(String.Format("{0}|", t.OtherSentences(i)))
                End If

            Next
            orderIndex += 1
        Next
        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

    Public Function ExportResultAsSSA(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        writer.WriteLine("[Script Info]")
        writer.WriteLine("; This is an Advanced Sub Station Alpha v4+ script.")
        writer.WriteLine("Title: phpRxY3Br")
        writer.WriteLine("ScriptType: v4.00+")
        writer.WriteLine("Collisions: Normal")
        writer.WriteLine("PlayDepth: 0")
        writer.WriteLine("")
        writer.WriteLine("[V4+ Styles]")
        writer.WriteLine("Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding")
        writer.WriteLine("Style: Default,Arial,20,&H00FFFFFF,&H0300FFFF,&H00000000,&H02000000,0,0,0,0,100,100,0,0,1,2,1,2,10,10,10,1")
        writer.WriteLine("")
        writer.WriteLine("[Events]")
        writer.WriteLine("Format: Layer, Start, End, Style, Actor, MarginL, MarginR, MarginV, Effect, Text")

        For Each t As Transcript In Result
            writer.Write(String.Format("Dialogue: 0,{0},{1},Default,,0,0,0,,", t.StartTime.ToString("hh\:mm\:ss\.ff"), t.EndTime.ToString("hh\:mm\:ss\.ff")))
            For i As Integer = 0 To t.OtherSentences.Count - 1
                If i = t.OtherSentences.Count - 1 Then
                    writer.Write(String.Format("{0}{1}", t.OtherSentences(i), Environment.NewLine))
                Else
                    writer.Write(String.Format("{0}\", t.OtherSentences(i)))
                End If

            Next
            orderIndex += 1
        Next
        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function


    Public Function ExportResultAsTTML(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1

        writer.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
        writer.WriteLine("<tt xmlns=""http://www.w3.org/ns/ttml"" xmlns:ttp=""http://www.w3.org/ns/ttml#parameter"" ttp:timeBase=""media"" xmlns:tts=""http://www.w3.org/ns/ttml#style"" xml:lang=""en"" xmlns:ttm=""http://www.w3.org/ns/ttml#metadata"">")
        writer.WriteLine(Chr(9) + "<head>")
        writer.WriteLine(Chr(9) + "<metadata>")
        writer.WriteLine(Chr(9) + Chr(9) + "<ttm:title></ttm:title>")
        writer.WriteLine(Chr(9) + "</metadata>")
        writer.WriteLine(Chr(9) + "<styling>")
        writer.WriteLine(Chr(9) + Chr(9) + "<style id=""s0"" tts:backgroundColor=""black"" tts:fontStyle=""normal"" tts:fontSize=""16"" tts:fontFamily=""sansSerif"" tts:color=""white"" />")
        writer.WriteLine(Chr(9) + "</styling>")
        writer.WriteLine(Chr(9) + "</head>")
        writer.WriteLine(Chr(9) + "<body style=""s0"">")
        writer.WriteLine(Chr(9) + Chr(9) + "<div>")

        For Each t As Transcript In Result
            writer.Write(String.Format(Chr(9) + Chr(9) + Chr(9) + "<p begin=""{0}s"" id=""p{2}"" end=""{1}s""></p>", t.StartTime.TotalSeconds, t.EndTime.TotalSeconds, orderIndex - 1))
            For i As Integer = 0 To t.OtherSentences.Count - 1
                If i = t.OtherSentences.Count - 1 Then
                    writer.Write(String.Format("{0}</p>{1}", t.OtherSentences(i), Environment.NewLine))
                Else
                    writer.Write(String.Format("{0}<br />", t.OtherSentences(i)))
                End If
            Next
            orderIndex += 1
        Next
        writer.WriteLine(Chr(9) + Chr(9) + "</div>")
        writer.WriteLine(Chr(9) + "</body>")
        writer.WriteLine("</tt>")

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

    Public Function ExportResultAsQT(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1

        writer.WriteLine("{QTtext} {font:Tahoma}")
        writer.WriteLine("{plain} {size:20}")
        writer.WriteLine("{timeScale:30}")
        writer.WriteLine("{width:160} {height:32}")
        writer.WriteLine("{timestamps:absolute} {language:0}")

        For Each t As Transcript In Result
            writer.WriteLine(String.Format("[{0}]", t.StartTime.ToString("hh\:mm\:ss\.ff")))
            For Each sentence As String In t.OtherSentences
                writer.WriteLine(sentence)
            Next
            writer.WriteLine(String.Format("[{0}]", t.EndTime.ToString("hh\:mm\:ss\.ff")))
            writer.WriteLine("")
            orderIndex += 1
        Next

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

    Public Function ExportResultAsVTT(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        writer.WriteLine("WEBVTT" + Environment.NewLine)
        Dim orderIndex As Integer = 1
        For Each t As Transcript In Result
            writer.WriteLine(orderIndex)
            writer.WriteLine("{0} --> {1}", t.StartTime.ToString("hh\:mm\:ss\.fff"), t.EndTime.ToString("hh\:mm\:ss\.fff"))
            For Each tr As String In t.OtherSentences
                writer.WriteLine(tr)
            Next
            writer.WriteLine("")
            orderIndex += 1
        Next

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

    Public Function ExportResultAsSMI(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        writer.WriteLine("<SAMI>")
        writer.WriteLine("<HEAD>")
        writer.WriteLine("<TITLE>phpLSVQ13</TITLE>")
        writer.WriteLine("<SAMIParam>")
        writer.WriteLine("Metrics {time:ms;}")
        writer.WriteLine("Spec {MSFT:1.0;}")
        writer.WriteLine("</SAMIParam>")
        writer.WriteLine("<STYLE TYPE=""text/css"">")
        writer.WriteLine("<!--")
        writer.WriteLine("P { font-family: Arial; font-weight: normal; color: white; background-color: black; text-align: center; }")
        writer.WriteLine(".ENUSCC { name: English; lang: en-US ; SAMIType: CC ; }")
        writer.WriteLine("-->")
        writer.WriteLine("</STYLE>")
        writer.WriteLine("</HEAD>")
        writer.WriteLine("<BODY>")
        writer.WriteLine("<-- Open play menu, choose Captions and Subtiles, On if available -->")
        writer.WriteLine("<-- Open tools menu, Security, Show local captions when present -->")
        Dim orderIndex As Integer = 1

        For Each t As Transcript In Result
            writer.Write(String.Format("<SYNC Start={0}><P Class=ENUSCC>", t.StartTime.TotalMilliseconds))
            For i As Integer = 0 To t.OtherSentences.Count - 1
                If i = t.OtherSentences.Count - 1 Then
                    writer.WriteLine(String.Format("{0}", t.OtherSentences(i)))
                Else
                    writer.Write(String.Format("{0}<br>", t.OtherSentences(i)))
                End If
            Next
            orderIndex += 1
        Next

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

    Public Function ExportResultAsCSV(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        writer.WriteLine("Number;Start time in milliseconds;End time in milliseconds;""Text""")
        Dim orderIndex As Integer = 1
        For Each t As Transcript In Result
            writer.Write(String.Format("{0};{1};{2};", orderIndex, t.StartTime.TotalMilliseconds, t.EndTime.TotalMilliseconds))
            For Each tr As String In t.OtherSentences
                writer.Write(String.Format("[{0}]", tr))
            Next
            writer.WriteLine("")
            orderIndex += 1
        Next

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

    Public Function ExportResultAsMicroDvd(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1

        For Each t As Transcript In Result
            writer.Write(String.Format("{{{0}}}{{{1}}}", Math.Round(t.StartTime.TotalSeconds * My.Settings.NumberOfFramesPerSecond), Math.Round(t.EndTime.TotalSeconds * My.Settings.NumberOfFramesPerSecond)))
            For i As Integer = 0 To t.OtherSentences.Count - 1
                If i = t.OtherSentences.Count - 1 Then
                    writer.WriteLine(String.Format("{0}", t.OtherSentences(i)))
                Else
                    writer.Write(String.Format("{0}|", t.OtherSentences(i)))
                End If
            Next
            orderIndex += 1
        Next

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

    Public Function ExportResultAsSubViewer(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        writer.WriteLine("[INFORMATION]")
        writer.WriteLine("[TITLE]phpHgySsK")
        writer.WriteLine("[AUTHOR]")
        writer.WriteLine("[SOURCE]")
        writer.WriteLine("[PRG]")
        writer.WriteLine("[FILEPATH]")
        writer.WriteLine("[DELAY]0")
        writer.WriteLine("[CD TRACK]0")
        writer.WriteLine("[COMMENT]")
        writer.WriteLine("[END INFORMATION]")
        writer.WriteLine("[SUBTITLE]")
        writer.WriteLine("[COLF]&H000000,[STYLE]bd,[SIZE]25,[FONT]Arial")
        For Each t As Transcript In Result
            writer.WriteLine(String.Format("{0},{1}", t.StartTime.ToString("hh\:mm\:ss\.ff"), t.EndTime.ToString("hh\:mm\:ss\.ff")))
            For i As Integer = 0 To t.OtherSentences.Count - 1
                If i = t.OtherSentences.Count - 1 Then
                    writer.Write(String.Format("{0}" + Environment.NewLine + Environment.NewLine, t.OtherSentences(i)))
                Else
                    writer.Write(String.Format("{0}<br>", t.OtherSentences(i)))
                End If

            Next
            orderIndex += 1
        Next

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function


    Public Function ExportResultAsRT(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        writer.WriteLine("<Window")
        writer.WriteLine("  Width    = ""640""")
        writer.WriteLine("  Height   = ""480""")
        writer.WriteLine("  WordWrap = ""true""")
        writer.WriteLine("  Loop     = ""true""")
        writer.WriteLine("  bgcolor  = ""black""")
        writer.WriteLine(">")
        writer.WriteLine("<Font")
        writer.WriteLine("  Color = ""white""")
        writer.WriteLine("  Face  = ""Arial""")
        writer.WriteLine("  Size  = ""+2""")
        writer.WriteLine(">")
        writer.WriteLine("<center>")
        writer.WriteLine("<b>")
        For Each t As Transcript In Result
            writer.Write(String.Format("<Time begin=""{0}"" end=""{1}"" /><clear/>", t.StartTime.ToString("hh\:mm\:ss\.f"), t.EndTime.ToString("hh\:mm\:ss\.f")))
            For i As Integer = 0 To t.OtherSentences.Count - 1
                If i = t.OtherSentences.Count - 1 Then
                    writer.Write(String.Format("{0}" + Environment.NewLine, t.OtherSentences(i)))
                Else
                    writer.Write(String.Format("{0} ", t.OtherSentences(i)))
                End If

            Next
            orderIndex += 1
        Next
        writer.WriteLine("</b>")
        writer.WriteLine("</center>")

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function


    Public Function ExportResultAsSbv(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        For Each t As Transcript In Result
            writer.WriteLine("{0},{1}", t.StartTime.ToString("hh\:mm\:ss\.fff"), t.EndTime.ToString("hh\:mm\:ss\.fff"))
            For Each tr As String In t.OtherSentences
                writer.WriteLine(tr)
            Next
            writer.WriteLine("")
            orderIndex += 1
        Next

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

    Public Function ExportResultAsExcelCsv(ByRef Files As List(Of TranscriptFile), ByRef Result As List(Of Transcript), ByRef SaveDialogFilePath As String) As String
        Dim fi As New FileInfo(Files(0).FileName)

        Dim writer As New StreamWriter(SaveDialogFilePath)
        Dim orderIndex As Integer = 1
        For i As Integer = 0 To Files.Count - 1
            If i = Files.Count - 1 Then
                writer.WriteLine(String.Format("{0}", Files(i).SafeFileName))
            Else
                writer.Write(String.Format("{0};", Files(i).SafeFileName))
            End If
        Next

        For Each t As Transcript In Result
            For j As Integer = 0 To t.OtherSentences.Count - 1
                If j = t.OtherSentences.Count - 1 Then
                    writer.WriteLine(String.Format("{0}", t.OtherSentences(j)))
                Else
                    writer.Write(String.Format("{0};", t.OtherSentences(j)))
                End If
            Next

            orderIndex += 1
        Next

        writer.Close()
        writer.Dispose()

        Return SaveDialogFilePath
    End Function

End Module
