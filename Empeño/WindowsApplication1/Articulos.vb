Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Articulos
    Dim CN As conexion = New conexion()
    Dim op As Integer = 0

    Public Sub limpiar()
        txtDepartamento.Clear()
        txtPrestamo.Clear()
        txtInteres.Clear()
    End Sub

    Private Sub rdbNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNuevo.CheckedChanged
        op = 1
        Call limpiar()
        btnBuscar.Visible = False
    End Sub

    Private Sub rdbModificar_CheckedChanged(sender As Object, e As EventArgs) Handles rdbModificar.CheckedChanged
        op = 2
        Call limpiar()
        btnBuscar.Visible = True
    End Sub

    Private Sub rdbEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEliminar.CheckedChanged
        op = 3
        Call limpiar()
        btnBuscar.Visible = True
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtDepartamento.Text = "" Or txtPrestamo.Text = "" Or txtInteres.Text = "" Then
            MsgBox("Ingrese los datos correspondientes")
        Else
            Try
                Select Case op
                    Case 1
                        CN.abrir()
                        CN.movimientos("INSERT INTO articulos VALUES(null, '" & txtDepartamento.Text & "', '" & txtPrestamo.Text & "', '" & txtInteres.Text & "');")
                        MsgBox("Articulo registrado!")
                        CN.cerrar()
                    Case 2
                        CN.abrir()
                        CN.movimientos("UPDATE articulos SET prestamo = '" & txtPrestamo.Text & "', interes = '" & txtInteres.Text & "' WHERE departamento = '" & txtDepartamento.Text & "';")
                        MsgBox("Articulo actualizado!")
                        CN.cerrar()
                    Case 3
                        CN.abrir()
                        CN.movimientos("DELETE FROM articulos WHERE departamento = '" & txtDepartamento.Text & "';")
                        MsgBox("Articulo eliminado!")
                        CN.cerrar()
                End Select
                Call limpiar()
                Me.Hide()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            CN.abrir()
            CN.consulta("SELECT * FROM articulos WHERE departamento = '" & txtDepartamento.Text & "';")
            If (CN.dr.Read()) Then
                txtPrestamo.Text = Convert.ToString(CN.dr("prestamo"))
                txtInteres.Text = Convert.ToString(CN.dr("interes"))
            Else
                MsgBox("El departamento no existe!")
            End If
            CN.cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Hide()
        Call limpiar()
    End Sub

    Private Sub Articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CheckForIllegalCrossThreadCalls = False
        Call limpiar()
        btnBuscar.Visible = False
    End Sub
End Class