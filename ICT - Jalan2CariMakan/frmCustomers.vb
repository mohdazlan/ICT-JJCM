Public Class frmCustomers
    Private Sub frmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'JJCMDataSet.customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.JJCMDataSet.customers)

    End Sub
End Class