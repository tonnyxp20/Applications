Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Usuarios
    Dim CN As conexion = New conexion()
    Dim op As Integer = 0

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Visible = False
        Me.CheckForIllegalCrossThreadCalls = False
    End Sub

    Public Sub limpiar()
        txtUsuario.Clear()
        txtContrasena.Clear()
        txtConfirmar.Clear()
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
        If txtUsuario.Text = "" Or txtContrasena.Text = "" Or cmbTipo.Text = "" Then
            MsgBox("Ingrese los datos correspondientes")
        Else
            If txtContrasena.Text = txtConfirmar.Text Then
                Try
                    Select Case op
                        Case 1
                            CN.abrir()
                            CN.movimientos("INSERT INTO usuarios VALUES(null, '" & txtUsuario.Text & "', '" & txtConfirmar.Text & "', '" & cmbTipo.Text & "');")
                            MsgBox("Usuario registrado!")
                            CN.cerrar()
                        Case 2
                            CN.abrir()
                            CN.movimientos("UPDATE usuarios SET contrasena = '" & txtConfirmar.Text & "', tipo = '" & cmbTipo.Text & "' WHERE nombre = '" & txtUsuario.Text & "';")
                            MsgBox("Usuario actualizado!")
                            CN.cerrar()
                        Case 3
                            CN.abrir()
                            CN.movimientos("DELETE FROM usuarios WHERE nombre = '" & txtUsuario.Text & "';")
                            MsgBox("Usuario eliminado!")
                            CN.cerrar()
                    End Select
                    Call limpiar()
                    Me.Hide()
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try
            Else
                MsgBox("Las contraseñas no coinciden!")
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            CN.abrir()
            CN.consulta("SELECT * FROM usuarios WHERE nombre = '" & txtUsuario.Text & "';")
            If (CN.dr.Read()) Then
                txtContrasena.Text = Convert.ToString(CN.dr("contrasena"))
                cmbTipo.Text = Convert.ToString(CN.dr("tipo"))
            Else
                MsgBox("El cliente no existe!")
            End If
            CN.cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call limpiar()
        Me.Hide()
    End Sub
End Class