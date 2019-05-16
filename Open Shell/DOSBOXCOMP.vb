Imports System.IO

Public Class DOSBOXCOMP
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                If File.Exists(Environment.CurrentDirectory + "\Open_Shell\DOSBOXCOMP\DOSBox.exe") Then
                    Exec()
                Else
                    panic()
                End If

            End If
        Catch
            MsgBox("The fact you got this far means i want to die")
        End Try
    End Sub

    Private Sub Exec()
        Dim pHelp As New ProcessStartInfo
        pHelp.FileName = Environment.CurrentDirectory + "\Open_Shell\DOSBOXCOMP\DOSBox.exe"
        pHelp.Arguments = Chr(34) + OpenFileDialog1.FileName + Chr(34) + "-noconsole -userconf"
        pHelp.UseShellExecute = True
        pHelp.WindowStyle = ProcessWindowStyle.Normal
        Dim proc As Process = Process.Start(pHelp)
    End Sub

    Private Sub dos16dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub

    Private Sub panic()
        MsgBox("dos16 subsystem missing")
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("feature not implemented")
    End Sub
End Class