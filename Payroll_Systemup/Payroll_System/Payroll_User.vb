Public Class Payroll_User

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Attendance_Records.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        User_Profile.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Login.Show()
        Me.Hide()
    End Sub
End Class