Public Class AboutOpenShell
    Private Sub PictureBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        CreditsEgg.Show()
    End Sub

    Private Sub AboutOpenShell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Open Shell " & My.Resources.Version
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        CreditsEgg.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LicenseForm.Show()
    End Sub
End Class