Public Class SettingsForm

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        AdvancedSettingsPanel.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DialogResult = ResetSettingsDialog.ShowDialog()
        If DialogResult = DialogResult.Yes Then
            My.Settings.Reset()
            MessageBox.Show("Settings have been reset closing Open Shell")
            Application.Exit()
        ElseIf DialogResult = DialogResult.No Then

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Shell("control screen.cpl")
        Catch ex As Exception
            MissingSettingsError.ShowDialog()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Shell("control desk.cpl,screensaver,@screensaver")
        Catch ex As Exception
            MissingSettingsError.ShowDialog()
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        MissingSettingsError.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            Shell("control mmsys.cpl sounds")
        Catch ex As Exception
            MissingSettingsError.ShowDialog()
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            Shell("control TimeDate.cpl")
        Catch ex As Exception
            MissingSettingsError.ShowDialog()
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            Shell("control main.cpl")
        Catch ex As Exception
            MissingSettingsError.ShowDialog()
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            Shell("control")
        Catch ex As Exception
            MissingSettingsError.ShowDialog()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BackdropForm.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PowerManagementForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PanelForm.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Shell("control userpasswords2")
        Catch ex As Exception
            MissingSettingsError.ShowDialog()
        End Try
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        MissingSettingsError.ShowDialog()
    End Sub
End Class