Imports System.IO
Public Class FileManagerForm
    Private Sub FileManagerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'drives
        Dim drives As DriveInfo() = DriveInfo.GetDrives()
        For i As Integer = 0 To drives.Length - 1
            ToolStripComboBox1.Items.Add(drives(i).Name)
            ToolStripComboBox1.SelectedIndex = -1
        Next

        WebBrowser1.Navigate(Environment.CurrentDirectory & "\Open_Shell\User")
        'Treeview
        TreeView1.Nodes.Clear()
        Dim path As New DirectoryInfo(Directory.GetDirectoryRoot(Environment.CurrentDirectory))
        Try
            For Each dir As DirectoryInfo In path.GetDirectories()
                Dim node As TreeNode = TreeView1.Nodes.Add(dir.Name)
                node.Nodes.Add(".")
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            WebBrowser1.Navigate(ToolStripComboBox1.Text)

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        WebBrowser1.Navigate(ToolStripComboBox1.Text)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        WebBrowser1.GoForward()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        WebBrowser1.Navigate(WebBrowser1.Url.ToString + "/..")
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        WebBrowser1.Refresh()
        TreeView1.Refresh()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If ToolStripTextBox1.Text = "Search" Or ToolStripTextBox1.Text = "" Then
            WebBrowser1.Refresh()
        Else
            Dim searchbase As String = My.Resources.SearchDoc.ToString.ToString.ToString.ToString
            Dim searh As String = searchbase.Replace("abcdefg", ToolStripTextBox1.Text)
            If My.Computer.FileSystem.FileExists(Application.UserAppDataPath + "\tempsearch.search-ms") = False Then
                File.Create(Application.UserAppDataPath + "\tempsearch.search-ms").Dispose()
            End If
            Dim objWriter As New System.IO.StreamWriter(Application.UserAppDataPath + "\tempsearch.search-ms")
            objWriter.Write(searh)
            objWriter.Close()
            WebBrowser1.Navigate(Application.UserAppDataPath + "\tempsearch.search-ms")
            Me.Text = "File Manager - Search Results for " + ToolStripTextBox1.Text + " in C:\"
            ToolStripComboBox1.Text = "search://" + ToolStripTextBox1.Text
        End If
    End Sub

    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Me.Text = "File Manager - " & WebBrowser1.DocumentTitle
        ToolStripComboBox1.Text = WebBrowser1.Url.AbsoluteUri.ToString()

    End Sub

    Private Sub TreeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        Try

            Dim courentNode As TreeNode = e.Node
            Dim folderPaht As New DirectoryInfo(ToolStripComboBox1.SelectedItem + courentNode.FullPath)

            For Each dir As DirectoryInfo In folderPaht.GetDirectories()
                Dim fileName As String = dir.Name
                Dim node As TreeNode = courentNode.Nodes.Add(fileName)
                node.Nodes.Add(".")
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        TreeView1.Nodes.Clear()
        Dim path As New DirectoryInfo(ToolStripComboBox1.SelectedItem.ToString())
        Try
            For Each dir As DirectoryInfo In path.GetDirectories()
                Dim node As TreeNode = TreeView1.Nodes.Add(dir.Name)
                node.Nodes.Add(".")
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        'WebBrowser1.Navigate(TreeView1.Nodes.Item)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AboutFileManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutFileManagerToolStripMenuItem.Click
        AboutFileManager.ShowDialog()
    End Sub
End Class