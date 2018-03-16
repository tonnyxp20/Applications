Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Threading

Public Class Clientes
    Dim CN As conexion = New conexion()
    Dim TP As temporal = New temporal()
    Dim op As Integer = 0
    Public hilo As Thread
    Public hilo1 As Thread

    Public Sub conectar()
        Thread.Sleep(500)
        Try
            CN.abrir()
            lblConexion.Text = "Conectado Servidor"
            Call habilitar()
            CN.cerrar()
        Catch ex As MySqlException
            CN.cerrar()
            Try
                TP.abrir()
                lblConexion.Text = "Conectado Local"
                Call deshabilitar()
                TP.cerrar()
            Catch x As MySqlException
                TP.cerrar()
                lblConexion.Text = "Desconectado Local"
            End Try
        End Try
        conectar()
    End Sub

    Public Sub control()
        Thread.Sleep(500)
        If lblConexion.Text = "Conectado Servidor" Then
            Call temporal()
        End If
        control()
    End Sub

    Public Sub tabla()
        Try
            Dim consulta As String = "SELECT * FROM clientes"
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(consulta, TP.cn)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds, "clientes")
            dg1.DataSource = ds.Tables("clientes")
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub temporal()
        Dim nombre As String
        Dim telefono As String
        Dim email As String
        Dim i As Integer
        Dim filas = dg1.RowCount

        For i = 0 To filas - 1
            nombre = Convert.ToString(dg1(0, i).Value)
            telefono = Convert.ToString(dg1(1, i).Value)
            email = Convert.ToString(dg1(2, i).Value)

            Try
                CN.abrir()
                CN.movimientos("INSERT INTO clientes VALUES(null, '" & nombre & "', '" & telefono & "', '" & email & "');")
                CN.cerrar()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try

            Try
                TP.abrir()
                TP.movimientos("DELETE FROM clientes WHERE nombre = '" & nombre & "'")
                TP.cerrar()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        Next
        tabla()
    End Sub

    Public Sub habilitar()
        rdbModificar.Visible = True
        rdbEliminar.Visible = True
    End Sub

    Public Sub deshabilitar()
        rdbModificar.Visible = False
        rdbEliminar.Visible = False
    End Sub

    Public Sub limpiar()
        txtNombre.Clear()
        txtTelefono.Clear()
        txtEmail.Clear()
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
        If txtNombre.Text = "" Or txtTelefono.Text = "" Then
            MsgBox("Ingrese los datos correspondientes")
        Else
            Try
                Select Case op
                    Case 1
                        If lblConexion.Text = "Conectado Servidor" Then
                            CN.abrir()
                            CN.movimientos("INSERT INTO clientes VALUES(null, '" & txtNombre.Text & "', '" & txtTelefono.Text & "', '" & txtEmail.Text & "');")
                            MsgBox("Cliente registrado!")
                            CN.cerrar()
                        ElseIf lblConexion.Text = "Conectado Local" Then
                            TP.abrir()
                            TP.movimientos("INSERT INTO clientes VALUES('" & txtNombre.Text & "', '" & txtTelefono.Text & "', '" & txtEmail.Text & "');")
                            MsgBox("Cliente registrado!")
                            TP.cerrar()
                        End If
                    Case 2
                        CN.abrir()
                        CN.movimientos("UPDATE clientes SET telefono = '" & txtTelefono.Text & "', email = '" & txtEmail.Text & "' WHERE nombre = '" & txtNombre.Text & "';")
                        MsgBox("Cliente actualizado!")
                        CN.cerrar()
                    Case 3
                        CN.abrir()
                        CN.movimientos("DELETE FROM clientes WHERE nombre = '" & txtNombre.Text & "';")
                        MsgBox("Cliente eliminado!")
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
            CN.consulta("SELECT * FROM clientes WHERE nombre = '" & txtNombre.Text & "';")
            If (CN.dr.Read()) Then
                txtTelefono.Text = Convert.ToString(CN.dr("telefono"))
                txtEmail.Text = Convert.ToString(CN.dr("email"))
            Else
                MsgBox("El cliente no existe!")
            End If
            CN.cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call limpiar()
        Me.Hide()
    End Sub

    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Visible = False
        rdbNuevo.Checked = True

        hilo = New Thread(New ThreadStart(AddressOf conectar))
        hilo.Start()
        CheckForIllegalCrossThreadCalls = False

        hilo1 = New Thread(New ThreadStart(AddressOf control))
        hilo1.Start()
        CheckForIllegalCrossThreadCalls = False
    End Sub
End Class