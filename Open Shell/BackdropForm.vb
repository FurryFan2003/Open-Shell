

Public Class BackdropForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = Environment.CurrentDirectory & "\Open_Shell\Backdrops\"
        OpenFileDialog1.ShowDialog()

        Try
            PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(OpenFileDialog1.FileName.ToString)
        Catch ex As Exception
            PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(My.Settings.Backdrop)
        End Try

        If RadioButton1.Checked Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Tile
        End If

        If RadioButton2.Checked Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Center
        End If

        If RadioButton3.Checked Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        End If

        If RadioButton4.Checked Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainForm.BackgroundImage = System.Drawing.Image.FromFile(OpenFileDialog1.FileName.ToString)
        My.Settings.Backdrop = OpenFileDialog1.FileName.ToString

        If RadioButton1.Checked Then
            My.Settings.BackdropLayout = "Tile"
            MainForm.BackgroundImageLayout = ImageLayout.Tile
        End If

        If RadioButton2.Checked Then
            My.Settings.BackdropLayout = "Center"
            MainForm.BackgroundImageLayout = ImageLayout.Center
        End If

        If RadioButton3.Checked Then
            My.Settings.BackdropLayout = "Stretch"
            MainForm.BackgroundImageLayout = ImageLayout.Stretch
        End If

        If RadioButton4.Checked Then
            My.Settings.BackdropLayout = "Zoom"
            MainForm.BackgroundImageLayout = ImageLayout.Zoom
        End If
    End Sub

    Private Sub BackdropForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(My.Settings.Backdrop)
        Catch ex As Exception
            'MsgBox("Image could not be loaded!")
        End Try

        If My.Settings.BackdropLayout = "Tile" Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Tile
            RadioButton1.Checked = True
        End If

        If My.Settings.BackdropLayout = "Center" Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Center
            RadioButton2.Checked = True
        End If

        If My.Settings.BackdropLayout = "Stretch" Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
            RadioButton3.Checked = True
        End If

        If My.Settings.BackdropLayout = "Zoom" Then
            PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
            RadioButton4.Checked = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        PictureBox1.BackgroundImageLayout = ImageLayout.Tile
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub
End Class