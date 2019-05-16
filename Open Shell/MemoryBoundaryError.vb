Public Class MemoryBoundaryError
    Dim Current As Integer = 10
    Private Sub MemoryBoundaryError_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            My.Computer.Audio.Play(Environment.CurrentDirectory & "\Open_Shell\Sounds\Error.wav")
        Catch ex As Exception
            Console.Beep()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Current = Current - 1
        Label2.Text = "Closing in: " & Current.ToString & " Sec..."
        If Label2.Text = "Closing in: 0 Sec..." Then
            Timer1.Stop()
            Environment.FailFast("Reason for Crash: Memory Leak Protection Shutdown")
        End If
    End Sub
End Class