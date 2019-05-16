Public Class PanelForm
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        PictureBox1.Image = My.Resources.bottom
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        PictureBox1.Image = My.Resources.right
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        PictureBox1.Image = My.Resources.top
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        PictureBox1.Image = My.Resources.left
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton3.Checked = True Then
            MainForm.ToolStrip1.Dock = DockStyle.Bottom
            My.Settings.PanelPlacement = "Bottom"
        ElseIf RadioButton2.Checked = True Then
            MainForm.ToolStrip1.Dock = DockStyle.Right
            My.Settings.PanelPlacement = "Right"
        ElseIf RadioButton1.Checked = True Then
            MainForm.ToolStrip1.Dock = DockStyle.Top
            My.Settings.PanelPlacement = "Top"
        ElseIf RadioButton4.Checked = True Then
            MainForm.ToolStrip1.Dock = DockStyle.Left
            My.Settings.PanelPlacement = "Left"
        End If
    End Sub

    Private Sub PanelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.PanelPlacement = "Bottom" Then
            RadioButton3.Checked = True
            PictureBox1.Image = My.Resources.bottom
        ElseIf My.Settings.PanelPlacement = "Right" Then
            RadioButton2.Checked = True
            PictureBox1.Image = My.Resources.right
        ElseIf My.Settings.PanelPlacement = "Top" Then
            RadioButton1.Checked = True
            PictureBox1.Image = My.Resources.top
        ElseIf My.Settings.PanelPlacement = "Left" Then
            RadioButton4.Checked = True
            PictureBox1.Image = My.Resources.left
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class