Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Form1

    Dim CN As conexion = New conexion()
    Dim op As Integer = 0

    Public Sub limpiar()
        txtUsuario.Clear()
        txtContrasena.Clear()
        cmbTipo.SelectedIndex = 0
    End Sub

    Public Sub habilitar()
        txtUsuario.Enabled = True
        txtContrasena.Enabled = True
        cmbTipo.Enabled = True
    End Sub

    Public Sub deshabilitar()
        txtUsuario.Enabled = False
        txtContrasena.Enabled = False
        cmbTipo.Enabled = False
    End Sub

    Private Sub btnConexion_Click(sender As Object, e As EventArgs) Handles btnConexion.Click
        Try
            CN.abrir()
            MsgBox("Conexion exitosa")
            CN.cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub rdbAgregar_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAgregar.CheckedChanged
        op = 1
        btnBuscar.Visible = False
        Call habilitar()
    End Sub

    Private Sub rdbModificar_CheckedChanged(sender As Object, e As EventArgs) Handles rdbModificar.CheckedChanged
        op = 2
        btnBuscar.Visible = True
        Call habilitar()
    End Sub

    Private Sub rdbEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEliminar.CheckedChanged
        op = 3
        btnBuscar.Visible = True
        Call habilitar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Select Case op
                Case 1
                    CN.abrir()
                    CN.movimientos("INSERT INTO usuarios VALUES(null, '" & txtUsuario.Text & "', '" & txtContrasena.Text & "', '" & cmbTipo.Text & "');")
                    MsgBox("Registro exitoso!")
                    CN.cerrar()
                Case 2
                    CN.abrir()
                    CN.movimientos("UPDATE usuarios SET contrasena = '" & txtContrasena.Text & "', tipo = '" & cmbTipo.Text & "' WHERE usuario = '" & txtUsuario.Text & "';")
                    MsgBox("Registro actualizado!")
                    CN.cerrar()
                Case 3
                    CN.abrir()
                    CN.movimientos("DELETE FROM usuarios WHERE usuario = '" & txtUsuario.Text & "';")
                    MsgBox("Registro eliminado!")
                    CN.cerrar()
            End Select

            Call limpiar()
            Call deshabilitar()

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ''Form2.Show()

        Try
            CN.abrir()
            CN.consulta("SELECT * FROM usuarios WHERE usuario = '" & txtUsuario.Text & "';")
            If (CN.dr.Read()) Then
                txtContrasena.Text = Convert.ToString(CN.dr("contrasena"))
                cmbTipo.Text = Convert.ToString(CN.dr("tipo"))
            Else
                MsgBox("El usuario no existe!")
            End If
            CN.cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        End
    End Sub
End Class
