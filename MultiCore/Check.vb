Imports System.Net, System.IO
Public Class Check
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        If (ListBox2.Items.Count > 0) Then
            Dim fs As New SaveFileDialog
            fs.RestoreDirectory = True
            fs.Filter = "txt files (*.txt)|*.txt"
            fs.FilterIndex = 1
            fs.ShowDialog()
            If Not (fs.FileName = Nothing) Then
                Using sw As New StreamWriter(fs.FileName)
                    For Each line As String In ListBox2.Items
                        sw.WriteLine(line)
                    Next
                End Using
            End If
        End If
    End Sub

    Private Sub btn_Scrape_Click(sender As Object, e As EventArgs) Handles btn_Import.Click
        Dim fo As New OpenFileDialog
        fo.RestoreDirectory = True
        fo.Multiselect = False
        fo.Filter = "txt files (*.txt)|*.txt"
        fo.FilterIndex = 1
        fo.ShowDialog()
        If (Not fo.FileName = Nothing) Then
            Dim proxies As New List(Of String)
            Dim myfile As String = fo.FileName
            Dim reader As New System.IO.StreamReader(myfile)
            Do Until reader.EndOfStream
                ListBox1.Items.Add(reader.ReadLine)
            Loop
            Using sr As New StreamReader(fo.FileName)
                While sr.Peek <> -1
                    proxies.Add(sr.ReadLine())

                End While
            End Using
        End If
    End Sub

    Private Sub btn_Check_Click(sender As Object, e As EventArgs) Handles btn_Check.Click
        Dim myProxy As WebProxy

        For Each proxy As String In ListBox1.Items
            Try
                myProxy = New WebProxy(ListBox1.Text)
                Dim r As HttpWebRequest = WebRequest.Create("http://www.google.com/")
                r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36"
                r.Timeout = 3000
                r.Proxy = myProxy

                Dim re As HttpWebResponse = r.GetResponse()
                ListBox2.Items.Add(proxy)
            Catch ex As Exception
                ListBox3.Items.Add(proxy)
            End Try

        Next
    End Sub
End Class
