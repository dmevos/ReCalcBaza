Imports System.IO
'Imports System.Text

Public Class Form1

    Dim DeltaLat, DeltaLon, DeltaEll As String
    'DeltaLat = "0"
    'DeltaLon = 0
    'DeltaEll = 0

    Function DeltaCalc(ByVal s1 As String, ByVal s2 As String) As String ' Расчитаем дельту в грудыусы_Минуты_Секунды между положениями базы (s1 и s2)
        Dim PosDegree, PosMinute, PosSec As Integer
        Dim GradInSec, MinInSec, SecInSec As Double
        Dim A1, A2 As Double
        Dim dGradus As Integer
        Dim dMinute, dSecunda As Double

        PosDegree = InStr(1, s1, "°")
        If PosDegree <> 0 Then
            'PosDegree = InStr(1, s1, "°")
            PosMinute = InStr(PosDegree + 1, s1, "'")
            PosSec = InStr(PosMinute + 1, s1, """")

            ' GradInSec = Mid(s1, 1, PosMinute - PosDegree - 1) * 60 * 60
            GradInSec = Mid(s1, 1, PosDegree - 1) * 60 * 60

            MinInSec = Mid(s1, PosDegree + 1, PosMinute - PosDegree - 1) * 60
            SecInSec = Mid(s1, PosMinute + 1, PosSec - PosMinute - 1)
            A1 = GradInSec + MinInSec + SecInSec

            PosDegree = InStr(1, s2, "°")
            PosMinute = InStr(PosDegree + 1, s2, "'")
            PosSec = InStr(PosMinute + 1, s2, """")

            GradInSec = Mid(s2, 1, PosMinute - PosDegree - 1) * 60 * 60
            MinInSec = Mid(s2, PosDegree + 1, PosMinute - PosDegree - 1) * 60
            SecInSec = Mid(s2, PosMinute + 1, PosSec - PosMinute - 1)
            A2 = GradInSec + MinInSec + SecInSec

            dSecunda = A1 - A2
            dGradus = dSecunda \ 3600
            dSecunda = dSecunda - dGradus * 3600
            dMinute = dSecunda \ 60
            dSecunda = dSecunda - dMinute * 60

            Return CStr(dGradus) + "°" + CStr(dMinute) + "'" + CStr(Math.Round(dSecunda, 7)) + """"
        Else
            Return s1 - s2
        End If

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "57°45'55,15695""N"
        TextBox2.Text = "40°57'02,13750""E"
        TextBox3.Text = "57°45'55,14656""N"
        TextBox4.Text = "40°57'02,12629""E"
        TextBox5.Text = "149,065"
        TextBox6.Text = "148,286"

        DeltaLat = DeltaCalc(TextBox1.Text, TextBox3.Text)
        DeltaLon = DeltaCalc(TextBox2.Text, TextBox4.Text)
        DeltaEll = DeltaCalc(TextBox5.Text, TextBox6.Text)

        Label1.Text = "Смещение базы на север: " + DeltaLat
        Label2.Text = "Смещение базы на восток: " + DeltaLon
        Label3.Text = "Смещение отметки базы: " + DeltaEll
        Label4.Text = " "


    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        e.KeyChar = If("0123456789".Contains(e.KeyChar) OrElse e.KeyChar = vbBack, e.KeyChar, Nothing)
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        DeltaLat = DeltaCalc(TextBox1.Text, TextBox3.Text)
        Label1.Text = "Смещение базы на север: " + DeltaLat
        Label1.ForeColor = Color.Red
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        e.KeyChar = If("0123456789".Contains(e.KeyChar) OrElse e.KeyChar = vbBack, e.KeyChar, Nothing)
    End Sub
    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        DeltaLon = DeltaCalc(TextBox2.Text, TextBox4.Text)
        Label2.Text = "Смещение базы на восток: " + DeltaLon
        Label2.ForeColor = Color.Red
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        e.KeyChar = If("0123456789".Contains(e.KeyChar) OrElse e.KeyChar = vbBack, e.KeyChar, Nothing)
    End Sub
    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        DeltaLat = DeltaCalc(TextBox1.Text, TextBox3.Text)
        Label1.Text = "Смещение базы на север: " + DeltaLat
        Label1.ForeColor = Color.Red
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        e.KeyChar = If("0123456789".Contains(e.KeyChar) OrElse e.KeyChar = vbBack, e.KeyChar, Nothing)
    End Sub
    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        DeltaLon = DeltaCalc(TextBox2.Text, TextBox4.Text)
        Label2.Text = "Смещение базы на восток: " + DeltaLon
        Label2.ForeColor = Color.Red
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        e.KeyChar = If("0123456789".Contains(e.KeyChar) OrElse e.KeyChar = vbBack, e.KeyChar, Nothing)
    End Sub
    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        DeltaEll = DeltaCalc(TextBox5.Text, TextBox6.Text)
        Label3.Text = "Смещение отметки базы: " + DeltaEll
        Label3.ForeColor = Color.Red
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        e.KeyChar = If("0123456789".Contains(e.KeyChar) OrElse e.KeyChar = vbBack, e.KeyChar, Nothing)
    End Sub
    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        DeltaEll = DeltaCalc(TextBox5.Text, TextBox6.Text)
        Label3.Text = "Смещение отметки базы: " + DeltaEll
        Label3.ForeColor = Color.Red
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Close()
    End Sub

    Private Sub BtnReNewLabel_Click(sender As Object, e As EventArgs) Handles BtnReNewLabel.Click
        DeltaLat = DeltaCalc(TextBox1.Text, TextBox3.Text)
        DeltaLon = DeltaCalc(TextBox2.Text, TextBox4.Text)
        DeltaEll = DeltaCalc(TextBox5.Text, TextBox6.Text)

        Label1.Text = "Смещение базы на север: " + DeltaLat
        Label2.Text = "Смещение базы на восток: " + DeltaLon
        Label3.Text = "Смещение отметки базы: " + DeltaEll
        Label4.Text = " "

        Label1.ForeColor = Color.MediumBlue
        Label2.ForeColor = Color.MediumBlue
        Label3.ForeColor = Color.MediumBlue
    End Sub

    Private Sub BtnFileOpen_Click(sender As Object, e As EventArgs) Handles BtnFileOpen.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog With {
            .InitialDirectory = "D:\пересчитай\",
            .Filter = "loc files (*.loc)|*.loc|All files (*.*)|*.*",
            .FilterIndex = 1,
            .RestoreDirectory = True
        }

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Label4.Text = "Файл для пересчета: " + openFileDialog1.FileName
                Calc(openFileDialog1.FileName)
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    ' Insert code to read the stream here.
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If

    End Sub

    Function ConvertDeg(ByVal s As String) As Double
        Dim Deg As Double
        Dim SecToSec, MinToSec, DegToSec As Double
        SecToSec = Mid(s, InStrRev(s, "'") + 1, (InStrRev(s, Chr(34)) - InStrRev(s, "'")) - 1)
        MinToSec = 60 * Mid(s, InStrRev(s, "°") + 1, (InStrRev(s, "'") - InStrRev(s, "°")) - 1)
        DegToSec = 60 * 60 * Mid(s, 1, InStrRev(s, "°") - 1)
        Deg = (SecToSec + MinToSec + DegToSec) / 3600
        Return Deg
    End Function

    Sub Calc(ByVal f As String)
        Dim PosLat, PosLon, PosEllipsoid_Elv As Integer

        Dim fileReader As New StreamReader(f, System.Text.Encoding.GetEncoding(1251))
        'Dim fileReaderPlus As New StreamReader(f)
        Dim fileReaderMinus As New StreamReader(f, System.Text.Encoding.GetEncoding(1251))

        Dim sLine As String = ""

        Dim arrText As New ArrayList()
        Do
            sLine = fileReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        fileReader.Close()

        'Dim arrTextPlus As New ArrayList()
        'Do
        ' sLine = fileReaderPlus.ReadLine()
        'If Not sLine Is Nothing Then
        'arrTextPlus.Add(sLine)
        'End If
        'Loop Until sLine Is Nothing
        'fileReaderPlus.Close()

        Dim arrTextMinus As New ArrayList()
        Do
            sLine = fileReaderMinus.ReadLine()
            If Not sLine Is Nothing Then
                arrTextMinus.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        fileReaderMinus.Close()

        Dim NumStr As Integer
        NumStr = 0

        For Each sLine In arrText

            PosLat = InStr(1, sLine, "Lat")
            PosLon = InStr(1, sLine, "Lon")
            PosEllipsoid_Elv = InStr(1, sLine, "Ellipsoid_Elv")

            Dim a As Integer
            a = InStrRev(sLine, Chr(34)) 'найдем последние кавычки в строке sLine 

            If PosLat <> 0 Then
                Dim ReplaceStr As Double
                'ReplaceStr = CDbl(Replace(Mid(sLine, PosLat + 12, a - PosLat - 12), ".", ",")) + ConvertDeg(DeltaLat)
                'arrTextPlus.Item(NumStr) = Replace(arrTextPlus.Item(NumStr), Mid(sLine, PosLat + 12, a - PosLat - 12), ReplaceStr)
                'arrTextPlus.Item(NumStr) = Replace(arrTextPlus.Item(NumStr), ",", ".")

                ReplaceStr = CDbl(Replace(Mid(sLine, PosLat + 12, a - PosLat - 12), ".", ",")) - ConvertDeg(DeltaLat)
                arrTextMinus.Item(NumStr) = Replace(arrTextMinus.Item(NumStr), Mid(sLine, PosLat + 12, a - PosLat - 12), ReplaceStr)
                arrTextMinus.Item(NumStr) = Replace(arrTextMinus.Item(NumStr), ",", ".")

                'MsgBox(arrTextPlus.Item(NumStr))
            End If
            If PosLon <> 0 Then
                Dim ReplaceStr As Double
                'ReplaceStr = CDbl(Replace(Mid(sLine, PosLon + 12, a - PosLon - 12), ".", ",")) + ConvertDeg(DeltaLon)
                'arrTextPlus.Item(NumStr) = Replace(arrTextPlus.Item(NumStr), Mid(sLine, PosLon + 12, a - PosLon - 12), ReplaceStr)
                'arrTextPlus.Item(NumStr) = Replace(arrTextPlus.Item(NumStr), ",", ".")

                ReplaceStr = CDbl(Replace(Mid(sLine, PosLon + 12, a - PosLon - 12), ".", ",")) - ConvertDeg(DeltaLon)
                arrTextMinus.Item(NumStr) = Replace(arrTextMinus.Item(NumStr), Mid(sLine, PosLon + 12, a - PosLon - 12), ReplaceStr)
                arrTextMinus.Item(NumStr) = Replace(arrTextMinus.Item(NumStr), ",", ".")

                ' MsgBox(arrTextPlus.Item(NumStr))
            End If
            If PosEllipsoid_Elv <> 0 Then
                Dim ReplaceStr As Double
                'ReplaceStr = CDbl(Replace(Mid(sLine, PosEllipsoid_Elv + 22, a - PosEllipsoid_Elv - 22), ".", ",")) + DeltaEll
                'arrTextPlus.Item(NumStr) = Replace(arrTextPlus.Item(NumStr), Mid(sLine, PosEllipsoid_Elv + 22, a - PosEllipsoid_Elv - 22), ReplaceStr)
                'arrTextPlus.Item(NumStr) = Replace(arrTextPlus.Item(NumStr), ",", ".")

                ReplaceStr = CDbl(Replace(Mid(sLine, PosEllipsoid_Elv + 22, a - PosEllipsoid_Elv - 22), ".", ",")) - DeltaEll
                arrTextMinus.Item(NumStr) = Replace(arrTextMinus.Item(NumStr), Mid(sLine, PosEllipsoid_Elv + 22, a - PosEllipsoid_Elv - 22), ReplaceStr)
                arrTextMinus.Item(NumStr) = Replace(arrTextMinus.Item(NumStr), ",", ".")

                'MsgBox(arrTextPlus.Item(NumStr))
            End If
            NumStr = NumStr + 1
        Next


        Dim newFileName As String

        newFileName = Mid(f, 1, InStrRev(f, ".") - 1)

        'Using sw As StreamWriter = New StreamWriter(newFileName & "_Plus.loc")
        ' For Each sLine In arrTextPlus
        ' sw.WriteLine(sLine)
        ' Next
        'End Using

        Using sw As StreamWriter = New StreamWriter(newFileName & "_Minus.loc", False, System.Text.Encoding.GetEncoding(1251))
            For Each sLine In arrTextMinus
                sw.WriteLine(sLine)
            Next
        End Using

        MsgBox("Готово")

    End Sub

End Class