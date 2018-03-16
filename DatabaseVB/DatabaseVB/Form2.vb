Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Form2
    Dim CN As conexion = New conexion()

    Public Sub cargar()
        Try
            Dim consulta As String = "SELECT * FROM usuarios"
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(consulta, CN.cn)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "usuarios")
            dg1.DataSource = ds.Tables("usuarios")
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call cargar()
    End Sub
End Class