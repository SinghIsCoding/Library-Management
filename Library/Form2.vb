Imports MySql.Data.MySqlClient
Public Class Form2

    Dim connection As New MySqlConnection("server=localhost;userid=root;password=proggobird;database=college")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim COMMAND As New MySqlCommand("Insert INTO `library_management`(`SN_NO`,`Name`,`Gender`,`Book_Name`,`Author_Name`,`DateOfIssue`,`Book_code`,`StreamAndYear`) VALUES (@fln,@adds,@brd,@kk,@rks,@bts,@ll,@ks)", connection)

        COMMAND.Parameters.Add("@fln", MySqlDbType.Int16).Value = TextBox1.Text
        COMMAND.Parameters.Add("@adds", MySqlDbType.VarChar).Value = TextBox2.Text
        COMMAND.Parameters.Add("@brd", MySqlDbType.VarChar).Value = ComboBox1.Text
        COMMAND.Parameters.Add("@kk", MySqlDbType.VarChar).Value = TextBox3.Text
        COMMAND.Parameters.Add("@rks", MySqlDbType.VarChar).Value = TextBox4.Text
        COMMAND.Parameters.Add("@bts", MySqlDbType.Date).Value = DateTimePicker1.Value
        COMMAND.Parameters.Add("@ll", MySqlDbType.Int16).Value = TextBox5.Text
        COMMAND.Parameters.Add("@ks", MySqlDbType.VarChar).Value = TextBox6.Text + " " + ComboBox2.Text

        connection.Open()


        If COMMAND.ExecuteNonQuery() = 1 Then

            MessageBox.Show("Data Inserted")
        Else
            MessageBox.Show("ERROR")

        End If
        connection.Close()
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.Text = "select"
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        ComboBox2.Text = "select"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim COMMAND As MySqlCommand

        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource

        Try
            connection.Open()
            Dim query As String
            query = "select *from college.library_management"
            COMMAND = New MySqlCommand(query, connection)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)

            connection.Close()


        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            connection.Dispose()
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim COMMAND As New MySqlCommand("Update `library_management` set `Name` =@adds, `Gender` =@brd, `Book_Name` =@kk, `Author_Name` =@rks,`DateOfIssue` =@bts, `Book_code` =@ll , `StreamAndYear` =@ks  WHERE `SN_NO`= @fln", connection)

        COMMAND.Parameters.Add("@fln", MySqlDbType.Int16).Value = TextBox1.Text
        COMMAND.Parameters.Add("@adds", MySqlDbType.VarChar).Value = TextBox2.Text
        COMMAND.Parameters.Add("@brd", MySqlDbType.VarChar).Value = ComboBox1.Text
        COMMAND.Parameters.Add("@kk", MySqlDbType.VarChar).Value = TextBox3.Text
        COMMAND.Parameters.Add("@rks", MySqlDbType.VarChar).Value = TextBox4.Text
        COMMAND.Parameters.Add("@bts", MySqlDbType.Date).Value = DateTimePicker1.Value
        COMMAND.Parameters.Add("@ll", MySqlDbType.Int16).Value = TextBox5.Text
        COMMAND.Parameters.Add("@ks", MySqlDbType.VarChar).Value = TextBox6.Text + " " + ComboBox2.Text

        connection.Open()


        If COMMAND.ExecuteNonQuery() = 1 Then

            MessageBox.Show("Data Updated")
        Else
            MessageBox.Show("ERROR")

        End If
        connection.Close()





    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Text = InputBox("Enter the Serial number")

        Dim COMMAND As New MySqlCommand("Delete from `library_management` where `SN_NO`=@fln", connection)
        COMMAND.Parameters.Add("@fln", MySqlDbType.Int16).Value = TextBox1.Text




        connection.Open()
        TextBox1.Clear()


        If COMMAND.ExecuteNonQuery() = 1 Then

            MessageBox.Show("Data Deleted")
        Else
            MessageBox.Show("ERROR")

        End If
        connection.Close()

    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox2.Select()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            ComboBox1.Select()
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox3.Select()
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox4.Select()
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            DateTimePicker1.Select()
        End If
    End Sub

    Private Sub DateTimePicker1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox5.Select()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox6.Select()
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = Chr(13) Then
            ComboBox2.Select()
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.Select()
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()

    End Sub


End Class