Imports System.IO, System.Net, System.Text.RegularExpressions, System.Threading
Public Class Multicore
    Dim links, proxies As New List(Of String)()
    Dim proxies2 As List(Of String)
    Dim ParseProxiesOfPage As New ArrayList
    Dim t_list As New List(Of Thread)
    Dim done As Integer
    Dim thread_status As Boolean
    Private client As WebClient


    Public Sub Multicore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        client = New WebClient
        Dim FileName As String = Application.StartupPath & "\sources.txt"
        For Each item In File.ReadAllLines(FileName)
            item = item.Replace(" ", "")
            links.Add(item)
        Next
        Using client As New WebClient
            TB_Update.ReadOnly = True
            TB_Changelog.ReadOnly = True
            TB_Update.Text = client.DownloadString("http://pastebin.com/raw/Ra7Jme13")
            TB_Changelog.Text = client.DownloadString("http://pastebin.com/raw/FXXd8Jrg")
        End Using
    End Sub

    Private Sub btn_Scrape_Click(sender As Object, e As EventArgs) Handles btn_Scrape.Click
        thread_status = True
        Dim threads As Integer = Threadcount.Value
        ThreadPool.SetMinThreads(threads, threads)
        ThreadPool.SetMaxThreads(threads, threads)
        ServicePointManager.DefaultConnectionLimit = threads
        ServicePointManager.Expect100Continue = True
        For Each link In links
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf scraper), link)
        Next
    End Sub

    Private Sub btn_Save2_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
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

    Private Function scraper(ByVal link As String) As String
        Try
            CheckForIllegalCrossThreadCalls = False
            Dim source As String = (New WebClient).DownloadString(link)
            Dim expression As New Regex("\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\:[0-9]{1,5}\b")
            Dim mtac As MatchCollection = expression.Matches(source)
            For Each itemcode As Match In mtac
                If Not proxies.Contains(itemcode.ToString) Then
                    proxies.Add(itemcode.ToString)
                    If LB_Grab.InvokeRequired = True Then
                        LB_Grab.Invoke(Sub()
                                           If (CheckBox1.Checked = True) Then
                                               If (LB_Progress.Items.Contains("[&] " & link)) Then
                                                   MyBase.Update()
                                                   'MessageBox.Show("Link has already been added!", "Multicore", MessageBoxIcon.Information, MessageBoxButtons.OK)
                                               Else
                                                   LB_Progress.Items.Add("[%] " & link)
                                               End If
                                           End If
                                           LB_Grab.Items.Add(itemcode.ToString)
                                           MyBase.Update()
                                       End Sub)
                    End If
                End If
            Next
            Me.Text = "| Multicore | Proxies Scraped: " & LB_Grab.Items.Count
            MyBase.Update()
        Catch ex As Exception
        End Try
        Return 0
    End Function

    Private Sub btn_Import_Click(sender As Object, e As EventArgs)
        Dim ParseProxiesOfPage As New ArrayList
        Dim IMPORT As New OpenFileDialog
        IMPORT.RestoreDirectory = True
        IMPORT.Multiselect = False
        IMPORT.Filter = "txt files (*.txt)|*.txt"
        IMPORT.FilterIndex = 1
        If (IMPORT.ShowDialog() = DialogResult.OK) Then
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
                Dim source As String = wc.DownloadString(TB_Website.Text)
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
    Private Sub btn_Close3_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Close()
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

    Private Sub btn_Save2_Click_1(sender As Object, e As EventArgs) Handles btn_Save2.Click
        Dim S_W As StreamWriter
        Dim itms() As String = {LB_ParsedProxies3.Items.ToString}
        Dim save As New SaveFileDialog With {.FileName = "Parsed Proxies", .Filter = "Grabbed Proxies (*.txt)|*.txt|ALL Files (*.*)|*.*", .CheckPathExists = True}
        save.ShowDialog(Me)
        S_W = New StreamWriter(save.FileName)
        For it As Integer = 0 To LB_ParsedProxies3.Items.Count - 1
            S_W.WriteLine(LB_ParsedProxies.Items.Item(it))
        Next
        S_W.Close()
        MessageBox.Show("Proxies Saved: " & LB_ParsedProxies3.Items.Count.ToString())
    End Sub


    Private Sub Scrape()
        Dim source As String = RTB_UnparsedProxies.Text

        ' Dim expression As New Regex("(\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\:[0-9]{1,5}\b)")
        'wait 
        Dim expression As New Regex("\b((\d{1,3}\.){3}\d{1,3})(?:.{1,}?)(\d{1,5})\b")
        Dim MatchCollection As MatchCollection = expression.Matches(source)

        For Each item As Match In MatchCollection
            Dim Unparsed As String = item.Groups(1).Value + ":" + item.Groups(3).Value
            LB_ParsedProxies.Items.Add(Unparsed)
            Try
                If Not proxies2.Contains(Unparsed) Then
                    proxies2.Add(Unparsed)
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

    Private Sub LabelMulticoreversion_Click(sender As Object, e As EventArgs) Handles LabelMulticoreversion.Click
        MessageBox.Show("Thanks for using Multicore! This project is developed by dopepizza from Hackforums", "Multicore", MessageBoxButtons.OK, MessageBoxIcon.Information)
        MessageBox.Show("Also, who in the world clicks a label, you must me special! ;)", "Multicore", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Multicore_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        client.Dispose()
    End Sub

    Private Sub btn_Get_Click(sender As Object, e As EventArgs)
        LB_WorkingProxies.Items.Add(LB_Grab.Items.ToString)
    End Sub

    Private Sub btn_Export_Click(sender As Object, e As EventArgs) Handles btn_Export.Click
        If (LB_WorkingProxies.Items.Count > 0) Then
            Dim fs As New SaveFileDialog
            fs.RestoreDirectory = True
            fs.Filter = "txt files (*.txt)|*.txt"
            fs.FilterIndex = 1
            fs.ShowDialog()
            If Not (fs.FileName = Nothing) Then
                Using sw As New StreamWriter(fs.FileName)
                    For Each line As String In LB_WorkingProxies.Items
                        If (line.StartsWith("Responsive: ")) Then sw.WriteLine(line)
                    Next
                End Using
            End If
        End If
    End Sub

    Private Sub btn_ImportProxiesToCheck_Click(sender As Object, e As EventArgs) Handles btn_ImportProxiesToCheck.Click
        thread_status = True
        Dim threads As Integer = CheckingTimeout.Value
        ThreadPool.SetMinThreads(threads, threads)
        ThreadPool.SetMaxThreads(threads, threads)
        ServicePointManager.DefaultConnectionLimit = threads
        ServicePointManager.Expect100Continue = True
        For Each Proxy In proxies
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf CheckProxies), Proxy)
        Next
    End Sub


    Public Function CheckProxies() Handles btn_ImportProxiesToCheck.Click
        Dim fo As New OpenFileDialog
        fo.RestoreDirectory = True
        fo.Multiselect = False
        fo.Filter = "txt files (*.txt)|*.txt"
        fo.FilterIndex = 1
        fo.ShowDialog()
        If (Not fo.FileName = Nothing) Then
            Dim proxies As New List(Of String)
            Using sr As New StreamReader(fo.FileName)
                While sr.Peek <> -1
                    proxies.Add(sr.ReadLine())
                End While
            End Using
            MyBase.Update()
            Dim myProxy As WebProxy
            For Each proxy As String In proxies
                Try
                    myProxy = New WebProxy(proxy)
                    Dim r As HttpWebRequest = WebRequest.Create("http://www.google.com")
                    r.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.2 Safari/537.36"
                    r.Timeout = Timeout.Value
                    r.Proxy = myProxy
                    Dim re As HttpWebResponse = r.GetResponse()
                    LB_WorkingProxies.Items.Add("Responsive: " & proxy)
                    MyBase.Update()
                Catch ex As Exception
                    LB_WorkingProxies.Items.Add("Unresponsive: " & proxy)
                    MyBase.Update()
                End Try
            Next
        End If
    End Function

    Private Sub button_Scrape3_Click(sender As Object, e As EventArgs) Handles button_Scrape3.Click
        Dim source As String = RTB_UnparsedProxies.Text

        Dim expression As New Regex("\b((\d{1,3}\.){3}\d{1,3})(?:.{1,}?)(\d{1,5})\b")
        Dim MatchCollection As MatchCollection = expression.Matches(source)

        For Each item As Match In MatchCollection
            Dim Unparsed As String = item.Groups(1).Value + ":" + item.Groups(3).Value
            LB_ParsedProxies3.Items.Add(Unparsed)
            Try
                If Not proxies2.Contains(Unparsed) Then
                    proxies2.Add(Unparsed)
                    If LB_ParsedProxies3.InvokeRequired = True Then
                        LB_ParsedProxies3.Invoke(Sub()
                                                     LB_ParsedProxies.Items.Add(Unparsed)
                                                 End Sub)
                    End If
                End If
            Catch ex As Exception
                'Do not put anything here, it will spam the output
            End Try
        Next
    End Sub


End Class

