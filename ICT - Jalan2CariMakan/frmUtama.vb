Imports System.Data.SqlClient

Public Class frmUtama
    Private Sub btnCart_Click(sender As Object, e As EventArgs) Handles btnCart.Click
        Dim connectionString As String = "Data Source=Z4P5-NB003; Initial Catalog=JJCM;User Id=sa;Password=p@ssw0rd"
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        Dim sqlQuery As String = "INSERT INTO meal(name,price,quantity,totalPrice,VAT) VALUES(@name,@price,@quantity,@totalPrice,@VAT)"
        Dim sqlCommand As New SqlCommand(sqlQuery, connection)

        sqlCommand.Parameters.AddWithValue("@name", txtProductName.Text)
        sqlCommand.Parameters.AddWithValue("@price", txtProductPrice.Text)
        sqlCommand.Parameters.AddWithValue("@quantity", txtQuantity.Text)
        sqlCommand.Parameters.AddWithValue("@totalPrice", txtTotalPrice.Text)

        sqlCommand.Parameters.AddWithValue("@VAT", txtVAT.Text)

        sqlCommand.ExecuteNonQuery()
        MsgBox("Operasi Berjaya")
        connection.Close()

    End Sub

    Function kiraVAT(ByVal x As String)
        Dim taxVAT As Decimal = 12 / 100 * x
        Return taxVAT
    End Function

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        Dim productPrice As Decimal = txtProductPrice.Text
        txtProductPrice.Text = productPrice.ToString("C2")

        txtTotalPrice.Text = productPrice * Val(txtQuantity.Text)
        txtTotalPrice.Text = Val(txtTotalPrice.Text).ToString("C2")

        txtVAT.Text = kiraVAT(Val(txtTotalPrice.Text))
        txtVAT.Text = Val(txtVAT.Text).ToString("C2")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim connectionString As String = "Data Source=Z4P5-NB003; Initial Catalog=JJCM;User Id=sa;Password=p@ssw0rd"
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        Dim sqlQuery As String = "SELECT * FROM voucher WHERE name = @name"
        Dim sqlCommand As New SqlCommand(sqlQuery, connection)
        sqlCommand.Parameters.AddWithValue("@name", txtSearch.Text)

        Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()

        If sqlDataReader.HasRows Then
            While sqlDataReader.Read()
                txtVoucherName.Text = sqlDataReader("name")
                txtVoucherSerial.Text = sqlDataReader("serialno")
                txtVoucherDiscount.Text = sqlDataReader("discount")
            End While

        Else
            MsgBox("No Data Found!!")
        End If

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim connectionString As String = "Data Source=Z4P5-NB003; Initial Catalog=JJCM;User Id=sa;Password=p@ssw0rd"
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        Dim sqlQuery As String = "INSERT INTO voucher(name,serialno,discount) VALUES(@name,@serialno,@discount)"
        Dim sqlCommand As New SqlCommand(sqlQuery, connection)

        sqlCommand.Parameters.AddWithValue("@name", txtVoucherName.Text)
        sqlCommand.Parameters.AddWithValue("@serialno", txtVoucherSerial.Text)
        sqlCommand.Parameters.AddWithValue("@discount", txtVoucherDiscount.Text)

        sqlCommand.ExecuteNonQuery()
        MsgBox("Operasi Berjaya")
        connection.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim connectionString As String = "Data Source=Z4P5-NB003; Initial Catalog=JJCM;User Id=sa;Password=p@ssw0rd"
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        Dim sqlQuery As String = "DELETE FROM voucher WHERE name=@name"
        Dim sqlCommand As New SqlCommand(sqlQuery, connection)
        sqlCommand.Parameters.AddWithValue("@name", txtVoucherName.Text)
        Dim rowsAffected As Integer = sqlCommand.ExecuteNonQuery
        If rowsAffected > 0 Then
            MsgBox("Data Dipadam dengan jaya")
        Else
            MsgBox("Tiada Data")
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim connectionString As String = "Data Source=Z4P5-NB003; Initial Catalog=JJCM;User Id=sa;Password=p@ssw0rd"
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        Dim sqlQuery As String = "UPDATE voucher SET name=@name,serialno=@serialno,discount=@discount"
        Dim sqlCommand As New SqlCommand(sqlQuery, connection)

        sqlCommand.Parameters.AddWithValue("@name", txtVoucherName.Text)
        sqlCommand.Parameters.AddWithValue("@serialno", txtVoucherSerial.Text)
        sqlCommand.Parameters.AddWithValue("@discount", txtVoucherDiscount.Text)

        sqlCommand.ExecuteNonQuery()
        MsgBox("Operasi  Berjaya")
        connection.Close()
    End Sub
End Class