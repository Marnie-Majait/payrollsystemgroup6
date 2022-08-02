Imports MySql.Data.MySqlClient
Public Class Login
    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=payroll_database")

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If PassTxt.UseSystemPasswordChar = True Then
            PassTxt.UseSystemPasswordChar = False

        Else
            PassTxt.UseSystemPasswordChar = True

        End If

    End Sub

    Private Sub Loginbtn_Click(sender As Object, e As EventArgs) Handles Loginbtn.Click
        If UserTxt.Text = "admin" And PassTxt.Text = "admin" Then
            Payroll_Admin.Show()
            UserTxt.Clear()
            PassTxt.Clear()
        Else
            Dim command As New MySqlCommand("SELECT `Emp_Id`, `Password` FROM `employee_information` WHERE `Emp_Id` = @username AND `Password` = @password", connection)

            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = UserTxt.Text
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PassTxt.Text

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()

            adapter.Fill(table)

            If table.Rows.Count = 0 Then

                MessageBox.Show("Invalid Username Or Password")
                UserTxt.Clear()
                PassTxt.Clear()

            Else

                MessageBox.Show("Logged In")


                Payroll_User.Show()
                Me.Hide()
                UserTxt.Clear()
                PassTxt.Clear()

            End If
        End If
    End Sub

   
End Class
