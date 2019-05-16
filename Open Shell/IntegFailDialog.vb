Public Class IntegFailDialog
    Private Sub IntegFailDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            My.Computer.Audio.Play(Environment.CurrentDirectory & "\Open_Shell\Sounds\Error.wav")
        Catch ex As Exception
            Console.Beep()
        End Try
        BringToFront()
        TopMost = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Environment.FailFast("Private Key Doesn't match key in Exec")
    End Sub
End Class