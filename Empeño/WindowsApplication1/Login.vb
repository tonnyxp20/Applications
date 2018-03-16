Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Threading

Public Class Login
    Dim CN As conexion1 = New conexion1()
    Dim TP As temporal = New temporal()

    Public hilo As Thread
    Public pwd As String
    Public tipo As String

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hilo = New Thread(New ThreadStart(AddressOf conectar))
        hilo.Start()
        Me.CheckForIllegalCrossThreadCalls = False
    End Sub

    Public Sub conectar()
        Thread.Sleep(500)
        Try
            CN.abrir()
            lblConexion.Text = "Conectado Servidor"
            pbEntrar.Enabled = True
            CN.cerrar()
        Catch ex As MySqlException
            CN.cerrar()
            Try
                TP.abrir()
                lblConexion.Text = "Conectado Local"
                pbEntrar.Enabled = False
                TP.cerrar()
            Catch x As MySqlException
                TP.cerrar()
                lblConexion.Text = "Desconectado Local"
            End Try
        End Try
        conectar()
    End Sub

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub pbEntrar_Click(sender As Object, e As EventArgs) Handles pbEntrar.Click
        Try
            If txtUser.Text = "" Or txtPassword.Text = "" Then
                MsgBox("Acceso denegado!")
            Else
                CN.abrir()
                CN.consulta("SELECT * FROM usuarios WHERE contrasena = '" & txtPassword.Text & "';")
                If CN.dr.Read() Then
                    pwd = Convert.ToString(CN.dr("contrasena"))
                End If
                CN.cerrar()
            End If
        Catch ex As MySqlException
            'MsgBox(ex.ToString())
        End Try

        Try
            If pwd = txtPassword.Text Then
                CN.abrir()
                CN.consulta("SELECT * FROM usuarios WHERE nombre = '" & txtUser.Text & "' AND contrasena = '" & pwd & "';")
                Dim cont As Integer = 0
                If CN.dr.Read() Then
                    cont = cont + 1
                    tipo = Convert.ToString(CN.dr("tipo"))
                End If

                If cont = 1 Then
                    Dim control As Panel = New Panel()
                    control.acceso = tipo
                    control.txtVendedor.Text = txtUser.Text
                    control.Show()
                    Me.Hide()
                    txtUser.Clear()
                    txtPassword.Clear()
                Else
                    MsgBox("Acceso denegado!")
                    txtUser.Clear()
                    txtPassword.Clear()
                End If
                CN.cerrar()
            Else
                txtPassword.Clear()
            End If
        Catch ex As MySqlException
            MsgBox(ex.ToString())
        End Try
    End Sub
End Class