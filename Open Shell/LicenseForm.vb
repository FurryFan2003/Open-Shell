Public Class LicenseForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub LicenseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.LoadFile(Environment.CurrentDirectory & "\Open_Shell\Other\License.rtf")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LicenseForm2.Show()
    End Sub
End Class