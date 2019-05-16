Public Class PowerManagementForm
    Private Sub BatteryStatus2()

        If SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            Label3.Text = "Battery Life Left: Data Unavailable"
        Else
            Label3.Text = "Battery Life: " & Format(SystemInformation.PowerStatus.BatteryLifeRemaining / 60 / 60, "#.## Hours Left")
        End If

        If SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            Label4.Text = "Battery Health: Data Unavailable"
        Else
            Label4.Text = "Battery Health: " & Format(SystemInformation.PowerStatus.BatteryFullLifetime / 60 / 60, "#.## Hours Left")
        End If

        'i lost my will to live
        If SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            PictureBox1.Image = My.Resources.BigBat_no
            Label2.Text = "Battery Percentage: On AC Power / No Battery"
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.100" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            PictureBox1.Image = My.Resources.BigBat_full
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.80" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            PictureBox1.Image = My.Resources.BigBat_good
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.60" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            PictureBox1.Image = My.Resources.BigBat_mid
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.40" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            PictureBox1.Image = My.Resources.BigBat_low
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.20" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            PictureBox1.Image = My.Resources.BigBat_EXlow
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.100" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            PictureBox1.Image = My.Resources.BigBat_full_charge
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.80" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            PictureBox1.Image = My.Resources.BigBat_good_charge
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.60" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            PictureBox1.Image = My.Resources.BigBat_mid_charge
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.40" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            PictureBox1.Image = My.Resources.BigBat_low_charge
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.20" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            PictureBox1.Image = My.Resources.BigBat_EXlow_charge
            Label2.Text = "Battery Percentage: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BatteryStatus2()
        GC.Collect()
    End Sub

    Private Sub PowerManagementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.PowerPlan = "1" Then
            TrackBar1.Value = "1"
        ElseIf My.Settings.PowerPlan = "2" Then
            TrackBar1.Value = "2"
        ElseIf My.Settings.PowerPlan = "3" Then
            TrackBar1.Value = "3"
        End If

        BatteryStatus2()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TrackBar1.Value = 2 Then
            My.Settings.PowerPlan = "2"
            Try
                Dim pHelp As New ProcessStartInfo
                pHelp.FileName = "powercfg"
                pHelp.Arguments = "-SETACTIVE 381b4222-f694-41f0-9685-ff5bb260df2e"
                pHelp.UseShellExecute = True
                pHelp.WindowStyle = ProcessWindowStyle.Hidden
                Dim proc As Process = Process.Start(pHelp)
            Catch ex As Exception
                ErrorPowerCFG.ShowDialog()
            End Try
        End If

        If TrackBar1.Value = 1 Then
            My.Settings.PowerPlan = "1"
            Try
                Dim pHelp As New ProcessStartInfo
                pHelp.FileName = "powercfg"
                pHelp.Arguments = "-SETACTIVE 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c"
                pHelp.UseShellExecute = True
                pHelp.WindowStyle = ProcessWindowStyle.Hidden
                Dim proc As Process = Process.Start(pHelp)
            Catch ex As Exception
                ErrorPowerCFG.ShowDialog()
            End Try
        End If

        If TrackBar1.Value = 3 Then
            My.Settings.PowerPlan = "3"
            Try
                Dim pHelp As New ProcessStartInfo
                pHelp.FileName = "powercfg"
                pHelp.Arguments = "-SETACTIVE a1841308-3541-4fab-bc81-f71556f20b4a"
                pHelp.UseShellExecute = True
                pHelp.WindowStyle = ProcessWindowStyle.Hidden
                Dim proc As Process = Process.Start(pHelp)
            Catch ex As Exception
                ErrorPowerCFG.ShowDialog()
            End Try

        End If
    End Sub
End Class