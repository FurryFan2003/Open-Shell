Public Class AdvancedSettingsPanel
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainForm.ApplicationsToolStripMenuItem.DropDownItems.Clear()
        MainForm.GenAppMenu()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainForm.GenDocMenu()
    End Sub
End Class