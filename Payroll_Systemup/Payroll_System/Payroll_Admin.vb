Imports MySql.Data.MySqlClient
Public Class Payroll_Admin
    Dim CONNECT As MySqlConnection
    Dim CONSTRING As String = "DATA SOURCE = localhost; USER id= root; DATABASE = payroll_database"
    Dim CMD As MySqlCommand
    Dim itemcoll(999) As String
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim i As Integer


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call LOADLV()
        Call cleardata()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call LOADLV()
        Call cleardata()
        Button6.Visible = True
        Button7.Visible = False
        Button8.Visible = False
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call LOADLV()

        Button7.Visible = True
        Button6.Visible = False
        Button8.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call LOADLV()

        Button8.Visible = True
        Button6.Visible = False
        Button7.Visible = False
    End Sub
    Public Sub LOADLV()
        Try
            ListView1.Items.Clear()
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim sql As String = "select * from employee_information"
            CMD = New MySqlCommand(sql, CONNECT)
            da = New MySqlDataAdapter(CMD)
            ds = New DataSet
            da.Fill(ds, "Tables")
            For r = 0 To ds.Tables(0).Rows.Count - 1
                For c = 0 To ds.Tables(0).Columns.Count - 1
                    itemcoll(c) = ds.Tables(0).Rows(r)(c).ToString
                Next
                Dim lvitm As New ListViewItem(itemcoll)
                ListView1.Items.Add(lvitm)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CONNECT.Close()
    End Sub
    Public Sub cleardata()
        EMPTXT.Clear()
        FTXT.Clear()
        MTXT.Clear()
        LTXT.Clear()
        CNTXT.Clear()
        ADDTXT.Clear()
        EATXT.Clear()
        HRTXT.Clear()
        PTXT.Clear()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            EMPTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text
            FTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text
            MTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text
            LTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text
            CNTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(4).Text
            ADDTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(5).Text
            EATXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(6).Text
            PTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(7).Text
            HRTXT.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(8).Text
        End If
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim SQL As String = "INSERT INTO employee_information (First_Name, Middle_Name,  Last_Name, Address, Contact_Num, Email_Add, Password, Hourly_rate) values ('" & FTXT.Text & "','" & MTXT.Text & "','" & LTXT.Text & "','" & ADDTXT.Text & "','" & CNTXT.Text & "','" & EATXT.Text & "','" & PTXT.Text & "','" & HRTXT.Text & "')"
            CMD = New MySqlCommand(SQL, CONNECT)
            Dim i As Integer = CMD.ExecuteNonQuery
            If i <> 0 Then
                MsgBox("Record Saved", vbInformation, "Admin")
            Else
                MsgBox("Record Not Saved", vbCritical, "Admin")
            End If
            Call LOADLV()
            Call cleardata()
            CONNECT.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim SQL As String = "Update employee_information set First_name = '" & FTXT.Text & "', Last_name = '" & LTXT.Text & "',  Middle_name = '" & MTXT.Text & "', Address = '" & ADDTXT.Text & "', Contact_Num = '" & CNTXT.Text & "', Email_Add = '" & EATXT.Text & "', Password = '" & PTXT.Text & "', Hourly_Rate = '" & HRTXT.Text & "' where EMP_Id = '" & EMPTXT.Text & "'"
            CMD = New MySqlCommand(SQL, CONNECT)
            Dim i As Integer = CMD.ExecuteNonQuery
            If i <> 0 Then
                MsgBox("Record Updated", vbInformation, "Admin")
            Else
                MsgBox("Record cannot be updated", vbCritical, "Admin")
            End If
            Call LOADLV()
            Call cleardata()
            CONNECT.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            CONNECT = New MySqlConnection(CONSTRING)
            CONNECT.Open()
            Dim SQL As String = "Delete from employee_information where Emp_Id = '" & EMPTXT.Text & "'"
            CMD = New MySqlCommand(SQL, CONNECT)
            Dim i As Integer = CMD.ExecuteNonQuery
            If i <> 0 Then
                MsgBox("The record was deleted successfully", vbInformation, "Admin")
            Else
                MsgBox("The record cannot be deleted", vbCritical, "Admin")
            End If
            Call LOADLV()
            Call cleardata()
            CONNECT.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
