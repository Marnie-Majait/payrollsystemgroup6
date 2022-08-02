Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Attendance_Records
    Dim results As String
    Dim CONNECT As MySqlConnection
    Dim CONSTRING As String = "DATA SOURCE = localhost; USER id= root; DATABASE = payroll_database"
    Dim CMD As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As New DataTable
    Dim ds As New DataSet


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'display to ng date 
        Dateandtime.Text = DateTime.Now.ToString("MMMM dd, yyyy")
    End Sub

    Private Sub Attendance_Records_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Refresh()
        Timer1.Start()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
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
    Public Sub refreshtxt(ByVal sql As String)
        'eto yung pang display ng attendance logs sa mismong datagrid
        Try
            CONNECT.Open()
            With CMD
                .Connection = CONNECT
                .CommandText = sql
            End With
            da = New MySqlDataAdapter(sql, CONNECT)
            dt = New DataTable
            da.Fill(dt)
        Catch ex As Exception
        Finally
            CONNECT.Close()
            da.Dispose()
        End Try
    End Sub
    Public Sub createlog(ByVal sql As String)
        'pang add ng logs sa data grid view
        Try
            CONNECT.Open()
            With CMD
                .Connection = CONNECT
                .CommandText = sql
                results = CMD.ExecuteNonQuery

            End With
        Catch ex As Exception
        Finally
            CONNECT.Close()
        End Try
    End Sub
    Public Sub updatelog(ByVal sql As String)
        'pang update ng logs sa data grid view
        Try
            CONNECT.Open()
            With CMD
                .Connection = CONNECT
                .CommandText = sql
                results = CMD.ExecuteNonQuery

            End With
        Catch ex As Exception
        Finally
            CONNECT.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If EMPIDTXT.Text = "" Then
                MessageBox.Show("Please Enter your Employee ID", "Admin", MessageBoxButtons.OK)
            Else
                refreshtxt("SELECT * FROM employee_information WHERE Employee_Id = '" & EMPIDTXT.Text & "'") 'kaninong employee id ilalagay ang log na gagawin mo?
                If dt.Rows.Count > 0 Then
                    refreshtxt("SELECT * FROM time_record WHERE Employee_Id = '" & EMPIDTXT.Text & "' AND Log_Date = '" & Dateandtime.Text & "' AND Before_Status = 'Time In' AND After_Status = 'Time Out'")
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("You've already timed in and timed out for today", "Admin", MessageBoxButtons.OK)
                    Else
                        refreshtxt("SELECT * from time_record WHERE Employee_Id = '" & EMPIDTXT.Text & "'AND Log_Date = '" & Dateandtime.Text & "' AND Before_Status = 'Time In'")
                        'Pag nagtime in si user, at wala pa syang time out, maglalog sya ng time out
                        If dt.Rows.Count > 0 Then
                            updatelog("UPDATE time_record SET Time_Out = '" & TimeOfDay & "', After_Status = 'Time Out' WHERE Employee_Id = '" & EMPIDTXT.Text & "' AND Log_Date = '" & Dateandtime.Text & "'")
                            MessageBox.Show("Successfully Timed out", "Admin", MessageBoxButtons.OK)
                        Else
                            createlog("INSERT INTO time_record(Employee_Id, Log_date, Time_in, Before_Status)VALUES('" & EMPIDTXT.Text & "', '" & Dateandtime.Text & "', '" & TimeOfDay & "', 'Time In' )")
                            MessageBox.Show("Successfully Timed in", "Admin", MessageBoxButtons.OK)
                            'etong code sa taas nito, pang add ng time in if wala pa syang time in record
                        End If
                    End If
                Else
                    MessageBox.Show("Employee ID not found", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'display to ng time 
        Time.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

   
End Class