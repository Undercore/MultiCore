Imports System.IO, System.Text.RegularExpressions, System.Net
Public Class Parse
    Dim links, proxies As New List(Of String)()
    Dim ParseProxiesOfPage As New ArrayList
    Private Sub btn_Import_Click(sender As Object, e As EventArgs)
        Dim IMPORT As New OpenFileDialog
        IMPORT.RestoreDirectory = True
        IMPORT.Multiselect = False
        IMPORT.Filter = "txt files (*.txt)|*.txt"
        IMPORT.FilterIndex = 1
        IMPORT.ShowDialog()
        If (Not IMPORT.FileName = Nothing) Then
            Dim proxies As New List(Of String)
            Dim myfile As String = IMPORT.FileName
            Dim reader As New StreamReader(myfile)
            Do Until reader.EndOfStream
                LB_ParsedProxies.Items.Add(reader.ReadLine)
            Loop
            Using sr As New StreamReader(IMPORT.FileName)
                While sr.Peek <> -1
                    proxies.Add(sr.ReadLine())

                End While
            End Using
        End If
    End Sub
    Private Sub btn_Parse_Click(sender As Object, e As EventArgs) Handles btn_Parse.Click
        Using wc As New WebClient
            Try
                Dim source As String = wc.DownloadString(TB_ParseFromPage.Text)
                Dim expression As New Regex("(\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\:[0-9]{1,5}\b)")
                Dim mtac As MatchCollection = expression.Matches(source)

                For Each item As Match In mtac
                    Dim capt As String = item.Groups(1).Value
                    Debug.WriteLine(capt)
                    LB_ParsedProxies.Items.Add(capt)
                    If Not proxies.Contains(capt) Then
                        proxies.Add(capt)
                        Name = "Proxies Parsed: " & LB_ParsedProxies.Items.Count.ToString()

                        If LB_ParsedProxies.InvokeRequired = True Then
                            LB_ParsedProxies.Invoke(Sub()
                                                        LB_ParsedProxies.Items.Add(capt)
                                                    End Sub)
                        End If
                    End If
                Next
            Catch
                MessageBox.Show("There was an error when parsing proxies from the page.", "MultiCore", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
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
End Class