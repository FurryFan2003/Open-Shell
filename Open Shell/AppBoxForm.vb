Public Class AppBoxForm
    Private Sub BackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub ForwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForwardToolStripMenuItem.Click
        WebBrowser1.GoForward()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        WebBrowser1.Navigate(Environment.CurrentDirectory & "\Open_Shell\Apps")
    End Sub

    Private Sub AppBoxForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate(Environment.CurrentDirectory & "\Open_Shell\Apps")
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        WebBrowser1.Refresh()
    End Sub
End Class