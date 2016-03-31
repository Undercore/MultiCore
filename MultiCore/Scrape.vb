Imports System.Text.RegularExpressions, System.IO
Public Class Scrape
    Dim proxies As List(Of String)
    Private Sub btn_Parse_Click(sender As Object, e As EventArgs) Handles btn_Parse.Click
        Scrape()
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim S_W As StreamWriter
        Dim itms() As String = {LB_ParsedProxies.Items.ToString}
        Dim save As New SaveFileDialog With {.FileName = "Parsed Proxies", .Filter = "Grabbed Proxies (*.txt)|*.txt|ALL Files (*.*)|*.*", .CheckPathExists = True}
        save.ShowDialog(Me)
        S_W = New StreamWriter(save.FileName)
        For it As Integer = 0 To LB_ParsedProxies.Items.Count - 1
            S_W.WriteLine(LB_ParsedProxies.Items.Item(it))
        Next
        S_W.Close()
        MessageBox.Show("Proxies Saved: " & LB_ParsedProxies.Items.Count.ToString())
    End Sub

    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Close()
    End Sub

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        LB_ParsedProxies.ClearSelected()
    End Sub

    Private Sub Scrape()
        Dim source As String = RTB_UnParsed.Text

        ' Dim expression As New Regex("(\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\:[0-9]{1,5}\b)")
        'wait 
        Dim expression As New Regex("\b((\d{1,3}\.){3}\d{1,3})(?:.{1,}?)(\d{1,5})\b")
        Dim MatchCollection As MatchCollection = expression.Matches(source)

        For Each item As Match In MatchCollection
            Dim Unparsed As String = item.Groups(1).Value + ":" + item.Groups(3).Value
            LB_ParsedProxies.Items.Add(Unparsed)
            Try
                If Not proxies.Contains(Unparsed) Then
                    proxies.Add(Unparsed)
                    Name = "Proxies Parsed: " & LB_ParsedProxies.Items.Count.ToString()
                    If LB_ParsedProxies.InvokeRequired = True Then
                        LB_ParsedProxies.Invoke(Sub()
                                                    LB_ParsedProxies.Items.Add(Unparsed)
                                                End Sub)
                    End If
                End If
            Catch ex As Exception
                'Do not put anything here as it will spam the output.
            End Try
        Next
    End Sub

End Class