Imports System.IO
Public Class CLIForm
    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListBox1.Items.Add("")
            ListBox1.Items.Add("CLI: " + ComboBox1.Text)
            ComboBox1.Items.Add(ComboBox1.Text)
            ListBox1.Items.Add("")
            If ComboBox1.Text = "help" Then
                Try
                    ListBox1.Items.AddRange(File.ReadAllLines(Environment.CurrentDirectory & "/Open_Shell/CLI/help"))
                Catch ex As Exception
                    ListBox1.Items.Add("File for help is missing or currupted!")
                End Try
            ElseIf ComboBox1.Text = "exit" Then
                Close()
            ElseIf ComboBox1.Text = "fastfail" Then
                Environment.FailFast("Crash started with command from console ignore error")
            ElseIf ComboBox1.Text = "dosboxcomp" Then
                DOSBOXCOMP.Show()
            ElseIf ComboBox1.Text.Length > 0 Then
                Try
                    Process.Start(Environment.CurrentDirectory & "/Open_shell/CLI/Apps/" & ComboBox1.Text)
                Catch ex As Exception
                    ListBox1.Items.Add("File or Command Cannot be found!")
                End Try
            End If
            ComboBox1.Text = ""
        End If
    End Sub

    Private Sub CLIForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Items.Add("Open Shell Version: " + My.Resources.Version)
        ListBox1.Items.Add("Welcome to the Command Console")
        ListBox1.Items.Add("Type (exit) to exit and (help) for help")
        ComboBox1.Select()
        ComboBox1.Items.Add("help")
        ComboBox1.Items.Add("exit")
    End Sub
End Class