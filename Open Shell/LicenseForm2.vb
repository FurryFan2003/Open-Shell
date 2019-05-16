Public Class LicenseForm2
    Private Sub LicenseForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.LoadFile(Environment.CurrentDirectory & "\Open_Shell\Other\gpl.rtf")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class