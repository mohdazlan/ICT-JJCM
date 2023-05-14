Imports System.Data.SqlClient

Public Class frmLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim connectionString As String = "Data Source=Z4P5-NB003; Initial Catalog=JJCM;User Id=sa;Password=p@ssw0rd"
        Dim connection As New SqlConnection(connectionString)

        Dim sqlQuery As String = "SELECT * FROM login WHERE username=@username AND password=@password"

        Dim sqlcommand As New SqlCommand(sqlQuery, connection)
        sqlcommand.Parameters.AddWithValue("@username", txtUserName.Text)
        sqlcommand.Parameters.AddWithValue("@password", txtPassword.Text)

        connection.Open()

        Dim reader As SqlDataReader = sqlcommand.ExecuteReader

        If reader.HasRows Then
            frmCustomers.Show()
            frmUtama.Show()
            Me.Hide()

        Else
            MsgBox("Gagal")
        End If

    End Sub
End Class