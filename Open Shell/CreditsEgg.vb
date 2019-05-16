
Public Class CreditsEgg
    Dim Current As Integer = 2
    Private Sub CreditsEgg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = Current.ToString
        Try
            My.Computer.Audio.Play(Environment.CurrentDirectory & "\Open_Shell\Sounds\Test.wav")
        Catch ex As Exception
            Close()
        End Try
        Me.BackgroundImage = My.Resources.CreditsEgg
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Current.ToString
        If Label1.Text = "1" Then
            Me.BackgroundImage = My.Resources.CreditsEgg2
        End If
        Current = Current - 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Audio.Stop()
        Close()
    End Sub
End Class
