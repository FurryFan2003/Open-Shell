Public Class SystemPerfMonitorForm
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Meter()
        If CheckBox1.Checked = True Then
            RefreshProcessList()
        End If
        GC.Collect()
    End Sub

    Private Sub Meter()
        ProgressBar1.Value = CInt(PerformanceCounter1.NextValue)
        ProgressBar2.Value = CInt(PerformanceCounter2.NextValue)

        Label1.Text = ProgressBar1.Value & "%"
        Label2.Text = ProgressBar2.Value & "%"
    End Sub

    Private Sub RefreshProcessList()
        Me.Text = "System Monitor - Refreshing"
        ListBox1.Items.Clear()
        Dim pro As System.Diagnostics.Process
        For Each pro In System.Diagnostics.Process.GetProcesses()
            ListBox1.Items.Add(pro.ProcessName)
        Next
        Me.Text = "System Monitor"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RefreshProcessList()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName(ListBox1.SelectedItem.ToString)
            For Each p As Process In pProcess
                KillProcessSelected.Label2.Text = "Process Name: " & ListBox1.SelectedItem.ToString
                DialogResult = KillProcessSelected.ShowDialog
                If DialogResult = Windows.Forms.DialogResult.Yes Then
                    p.Kill()
                Else
                    ProcessKilledSuccessfully.ShowDialog()
                    RefreshProcessList()
                End If
            Next
        Catch ex As Exception
            ProcessKillError.ShowDialog()
        End Try
    End Sub

    Private Sub SystemPerfMonitorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Meter()
        RefreshProcessList()
        CheckBox1.Checked = True
    End Sub
End Class