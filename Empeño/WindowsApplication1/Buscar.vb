Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Buscar
    Dim CN As conexion = New conexion()

    Private Sub Buscar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim consulta As String = "SELECT nombre, telefono FROM clientes"
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(consulta, CN.cn)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "clientes")
            dg1.DataSource = ds.Tables("clientes")
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Panel.txtCliente.Text = txtBuscar.Text
    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick
        txtBuscar.Text = dg1.CurrentRow.Cells(0).Value.ToString().TrimEnd()
    End Sub

    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim control As New Panel()
        control.txtCliente.Text = txtBuscar.Text
        Me.Hide()
    End Sub
End Class