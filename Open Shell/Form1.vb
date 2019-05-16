Imports System.Linq
Imports System.Environment
Imports System.IO

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IntegCheck()
        Clock.Text = Format(Now, "HH:mm")
        OpenShell10ToolStripMenuItem.Text = "Open Shell " & My.Resources.Version
        GenAppMenu()
        GenDocMenu()
        Backdrop()
        PanelPlacement()
        BatteryStatus()
        VolumeStatus()
        ClockToolTip()
    End Sub

    Private Sub IntegCheck()
        Try
            If File.ReadAllText(Environment.CurrentDirectory & "\Open_Shell\Security\StartUpCheck\IntegKey") = My.Resources.PrivateIntegKey Then

            Else
                If IntegFailDialog.Visible = False Then
                    IntegFailDialog.ShowDialog()
                End If
            End If
        Catch ex As Exception
            IntegFailDialog.ShowDialog()
        End Try

    End Sub

    Public Sub GenDocMenu()
        DocumentsToolStripMenuItem.DropDownItems.Clear()

        If (Not System.IO.Directory.Exists(Environment.CurrentDirectory & "\Open_Shell\User\Documents\")) Then
            MsgBox("System folder was missing, new one has been created!")
            System.IO.Directory.CreateDirectory(Environment.CurrentDirectory & "\Open_Shell\User\Documents\")
        End If
        For Each ex As String In System.IO.Directory.GetFiles(Environment.CurrentDirectory & "\Open_Shell\User\Documents\")

            Dim itea = DocumentsToolStripMenuItem.DropDownItems.Add(ex.Replace(Environment.CurrentDirectory & "\Open_Shell\User\Documents\", ""))
            itea.Image = Icon.ExtractAssociatedIcon(ex).ToBitmap
            itea.ImageScaling = ToolStripItemImageScaling.SizeToFit

        Next
        For Each go As ToolStripItem In DocumentsToolStripMenuItem.DropDownItems
            AddHandler go.Click, AddressOf ClickOnItem2
        Next
    End Sub

    Sub ClickOnItem2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MyHandle As IntPtr
        Dim p As New Process
        p.StartInfo.FileName = Environment.CurrentDirectory & "\Open_Shell\User\Documents\" & sender.Text
        p.StartInfo.UseShellExecute = True
        p.Start()
    End Sub

    Private Sub ClockToolTip()
        If Calendar.Visible = False Then
            Clock.ToolTipText = DateTime.Now.ToString("dd MMM yyyy")
        Else
            Clock.ToolTipText = "Press ""Esc"" to close Calender"
        End If
    End Sub

    Public Sub GenAppMenu()
        ApplicationsToolStripMenuItem.DropDownItems.Clear()

        If (Not System.IO.Directory.Exists(Environment.CurrentDirectory & "/Open_Shell/Apps/")) Then
            MsgBox("System folder was missing, new one has been created!")
            System.IO.Directory.CreateDirectory(Environment.CurrentDirectory & "/Open_Shell/Apps/")
        End If
        For Each exe As String In System.IO.Directory.GetFiles(Environment.CurrentDirectory & "/Open_Shell/Apps/", "*.exe")

            Dim itea = ApplicationsToolStripMenuItem.DropDownItems.Add(exe.Replace(Environment.CurrentDirectory & "/Open_Shell/Apps/", "").Replace(".exe", ""))
            itea.Image = Icon.ExtractAssociatedIcon(exe).ToBitmap
            itea.ImageScaling = ToolStripItemImageScaling.SizeToFit

        Next
        For Each go As ToolStripItem In ApplicationsToolStripMenuItem.DropDownItems
            AddHandler go.Click, AddressOf ClickOnItem
        Next
    End Sub
    Sub ClickOnItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MyHandle As IntPtr
        Dim p As New Process
        p.StartInfo.FileName = Environment.CurrentDirectory & "/Open_Shell/Apps/" & sender.Text
        p.StartInfo.UseShellExecute = True
        p.Start()
    End Sub

    Private Sub PanelPlacement()
        If My.Settings.PanelPlacement = "Bottom" Then
            ToolStrip1.Dock = DockStyle.Bottom
        ElseIf My.Settings.PanelPlacement = "Right" Then
            ToolStrip1.Dock = DockStyle.Right
        ElseIf My.Settings.PanelPlacement = "Top" Then
            ToolStrip1.Dock = DockStyle.Top
        ElseIf My.Settings.PanelPlacement = "Left" Then
            ToolStrip1.Dock = DockStyle.Left
        End If
    End Sub

    Private Sub Backdrop()
        Try
            BackgroundImage = System.Drawing.Image.FromFile(My.Settings.Backdrop)
        Catch ex As Exception
            ImgError.ShowDialog()
        End Try

        If My.Settings.BackdropLayout = "Tile" Then
            BackgroundImageLayout = ImageLayout.Tile
        End If

        If My.Settings.BackdropLayout = "Center" Then
            BackgroundImageLayout = ImageLayout.Center
        End If

        If My.Settings.BackdropLayout = "Stretch" Then
            BackgroundImageLayout = ImageLayout.Stretch
        End If

        If My.Settings.BackdropLayout = "Zoom" Then
            BackgroundImageLayout = ImageLayout.Zoom
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        LoginForm.Close()
        Application.Exit()
    End Sub

    Private Sub FileManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileManagerToolStripMenuItem.Click
        FileManagerForm.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MemoryCheckup()
        Clock.Text = Format(Now, "HH:mm")
        'GenAppMenu()
        BatteryStatus()
        VolumeStatus()
        ClockToolTip()
        GC.Collect()
        'check if mainform is alive
        If Application.OpenForms().OfType(Of MainForm).Any Then

        Else
            Application.Exit()
        End If
    End Sub

    Private Sub MemoryCheckup()
        If Process.GetCurrentProcess.PrivateMemorySize64 >= "100000000" Then
            If MemoryBoundaryError.Visible = False Then
                MemoryBoundaryError.ShowDialog()
            End If
        End If
    End Sub

    Private Sub VolumeStatus()
        ToolStripButton2.ToolTipText = "Volume Level: ?"
        'ToolStripButton2.ToolTipText = Process.GetCurrentProcess.PrivateMemorySize64
    End Sub

    Private Sub BatteryStatus()
        'i lost my will to live
        If SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.NoSystemBattery Then
            ToolStripButton1.Image = My.Resources.Bat_no
            ToolStripButton1.ToolTipText = "On AC Power / No Battery"
        End If


        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.100" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            ToolStripButton1.Image = My.Resources.Bat_full
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.80" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            ToolStripButton1.Image = My.Resources.Bat_good
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.60" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            ToolStripButton1.Image = My.Resources.Bat_mid
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.40" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            ToolStripButton1.Image = My.Resources.Bat_low
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.20" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" Then
            ToolStripButton1.Image = My.Resources.Bat_EXlow
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.100" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            ToolStripButton1.Image = My.Resources.Bat_full_charge
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.80" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            ToolStripButton1.Image = My.Resources.Bat_good_charge
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.60" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            ToolStripButton1.Image = My.Resources.Bat_mid_charge
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.40" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            ToolStripButton1.Image = My.Resources.Bat_low_charge
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")
        End If

        If SystemInformation.PowerStatus.BatteryLifePercent <= "0.20" & SystemInformation.PowerStatus.BatteryChargeStatus.NoSystemBattery = "128" & SystemInformation.PowerStatus.BatteryChargeStatus = BatteryChargeStatus.Charging Then
            ToolStripButton1.Image = My.Resources.Bat_EXlow_charge
            ToolStripButton1.ToolTipText = "Battery Level: " & Format(SystemInformation.PowerStatus.BatteryLifePercent, "#%")

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Process.Start("SndVol.exe")
    End Sub

    Private Sub ApplicationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplicationsToolStripMenuItem.Click
        'AppBoxForm.Show()
    End Sub

    Private Sub SystemMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemMonitorToolStripMenuItem.Click
        SystemPerfMonitorForm.Show()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        PowerManagementForm.Show()
    End Sub

    Private Sub PanelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PanelToolStripMenuItem.Click
        PanelForm.Show()
    End Sub

    Private Sub AllSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllSettingsToolStripMenuItem.Click
        SettingsForm.Show()
    End Sub

    Private Sub PanelSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PanelSettingsToolStripMenuItem.Click
        PanelForm.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutOpenShell.Show()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        SettingsForm.Show()
    End Sub

    Private Sub Clock_Click(sender As Object, e As EventArgs) Handles Clock.Click
        Calendar.Visible = True
        ClockToolTip()
    End Sub

    Private Sub Calendar_KeyDown(sender As Object, e As KeyEventArgs) Handles Calendar.KeyDown
        If e.KeyCode = Keys.Escape Then
            Calendar.Visible = False
        End If
    End Sub

    Private Sub DocumentsToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles DocumentsToolStripMenuItem.MouseHover
        GenDocMenu()
    End Sub

    Private Sub ApplicationsToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles ApplicationsToolStripMenuItem.MouseHover
        GenAppMenu()
    End Sub

    Private Sub CommandConsoleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CommandConsoleToolStripMenuItem1.Click
        CLIForm.Show()
    End Sub

    Private Sub ChangeBackdropToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeBackdropToolStripMenuItem.Click
        BackdropForm.Show()
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Calendar.Visible = False
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        MissingSettingsError.ShowDialog()
    End Sub

    Private Sub BackdropToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackdropToolStripMenuItem.Click
        BackdropForm.Show()
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LoginForm.Close()
    End Sub
End Class
