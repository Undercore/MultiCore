Imports System.IO, System.Net, System.Text.RegularExpressions, System.Threading
Public Class Multicore
    Dim links, proxies As New List(Of String)()
    Dim t_list As New List(Of Thread)
    Dim done As Integer
    Dim thread_status As Boolean


    Private Sub Multicore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FileName As String = Application.StartupPath & "\sources.txt"
        For Each item In File.ReadAllLines(FileName)
            item = item.Replace(" ", "")
            links.Add(item)
        Next
    End Sub

    Private Sub btn_Scrape_Click(sender As Object, e As EventArgs) Handles btn_Scrape.Click
        thread_status = True
        Dim threads As Integer = ThreadCOUNT.Value
        ThreadPool.SetMinThreads(threads, threads)
        ThreadPool.SetMaxThreads(threads, threads)
        ServicePointManager.DefaultConnectionLimit = threads
        ServicePointManager.Expect100Continue = True
        For Each link In links
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf scraper), link)
        Next
    End Sub

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        LB_Grab.ClearSelected()
        proxies.Clear()
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If LB_Grab.Items.Count = (0) Then MessageBox.Show("Please Scrape Proxies First.", "ALERT!", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        Dim S_W As IO.StreamWriter
        Dim itms() As String = {LB_Grab.Items.ToString}
        Dim save As New SaveFileDialog With {.FileName = "Grabbed Proxies", .Filter = "Grabbed Proxies (*.txt)|*.txt|ALL Files (*.*)|*.*", .CheckPathExists = True}
        save.ShowDialog(Me)
        S_W = New StreamWriter(save.FileName)
        For it As Integer = 0 To LB_Grab.Items.Count - 1
            S_W.WriteLine(LB_Grab.Items.Item(it))
        Next
        S_W.Close()
        MessageBox.Show("Proxies Saved: " & LB_Grab.Items.Count.ToString())
    End Sub

    Private Sub btn_Parse_Click(sender As Object, e As EventArgs) Handles btn_Parse.Click
        Dim P As New Parse()
        P.Show()
    End Sub

    Private Sub btn_Check_Click(sender As Object, e As EventArgs) Handles btn_Check.Click
        Dim c As New Check()
        c.Show()
    End Sub

    Private Sub scrape_Click(sender As Object, e As EventArgs) Handles scrape.Click
        Dim scrape As New Scrape()
        scrape.Show()
    End Sub

    Public Function scraper(ByVal link As String) As String
        Try
            Dim source As String = (New WebClient).DownloadString(link)
            Dim expression As New Regex("\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\:[0-9]{1,5}\b")
            Dim mtac As MatchCollection = expression.Matches(source)
            For Each itemcode As Match In mtac
                If Not proxies.Contains(itemcode.ToString) Then
                    proxies.Add(itemcode.ToString)
                    If LB_Grab.InvokeRequired = True Then
                        LB_Grab.Invoke(Sub()
                                           LB_Grab.Items.Add(itemcode.ToString)

                                           Name = "Proxies Scraped: " & proxies.Count
                                       End Sub)
                    End If
                End If
            Next
        Catch ex As Exception
            ' MessageBox.Show(link)
        End Try
        Return 0
    End Function

End Class
