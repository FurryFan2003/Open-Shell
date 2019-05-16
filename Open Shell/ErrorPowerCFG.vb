Public Class ErrorPowerCFG
    Private Sub ErrorPowerCFG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            My.Computer.Audio.Play(Environment.CurrentDirectory & "\Open_Shell\Sounds\Error.wav")
        Catch ex As Exception
            Console.Beep()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class