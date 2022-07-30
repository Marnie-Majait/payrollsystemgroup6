Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Attendance_Records
    Dim CONSTRING As String = "DATA SOURCE = localhost; USER id= root; DATABASE = payroll_database"
    Dim CMD As MySqlCommand
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = DateAndTime.Now.ToString("MMMM dd, yyyy HH:ss:tt")
    End Sub

    Private Sub Attendance_Records_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Refresh()
        Timer1.Start()
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        User_Profile.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Payroll_User.Show()
        Me.Hide()
    End Sub

End Class