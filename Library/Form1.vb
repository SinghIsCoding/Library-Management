Public Class Form1
    Dim username As String
    Dim password As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        username = "riya"
        password = "1234"

        If (TextBox1.Text = username) And (TextBox2.Text = password) Then
            Form2.Show()
            Me.Hide()
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            MessageBox.Show("incorrect username and password")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()
    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox2.Select()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.Select()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
End Class
