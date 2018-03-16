Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Imports System.Threading

Public Class Panel

    Dim CN As conexion = New conexion()
    Dim TP As temporal = New temporal()

    Dim escritor As StreamWriter 'escritura
    Dim lector As StreamReader 'lectura

    Public hilo As Thread
    Public acceso As String

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

    Public Sub habilitar()
        btnBuscar.Enabled = True
        btnCalcular.Enabled = True
        RegistrarUsuariosToolStripMenuItem.Enabled = True
        DepartamentosToolStripMenuItem.Enabled = True
    End Sub

    Public Sub deshabilitar()
        btnBuscar.Enabled = False
        btnCalcular.Enabled = False
        RegistrarUsuariosToolStripMenuItem.Enabled = False
        DepartamentosToolStripMenuItem.Enabled = False
    End Sub

    Public Sub registrar()
        Try
            CN.abrir()
            CN.movimientos("INSERT INTO registros VALUES('" & txtFolio.Text & "', '" & dtpFecha.Text & "', '" & cmbArticulo.Text & "', '" & txtValor.Text & "', '" & txtPrestamo.Text & "', '" & txtImporte.Text & "');")
            CN.cerrar()

            dg1.Rows.Add(txtFolio.Text, dtpFecha.Text, cmbArticulo.Text, txtValor.Text, txtPrestamo.Text, txtImporte.Text)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub llenar(cmb As ComboBox)
        Try
            CN.abrir()
            CN.consulta("SELECT departamento FROM articulos;")
            While CN.dr.Read()
                cmb.Items.Add(Convert.ToString(CN.dr("departamento")))
            End While
            CN.cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub cargar(cmb As ComboBox)
        Try
            CN.abrir()
            CN.consulta("SELECT nombre FROM clientes;")
            While CN.dr.Read()
                cmb.Items.Add(Convert.ToString(CN.dr("nombre")))
            End While
            CN.cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub generarTicket()
        Dim nombre As String = "folio.txt"
        Dim direccion As String = "C:\\Archivo\\"

        If File.Exists(direccion & nombre) Then
            escritor = File.AppendText(direccion & nombre)

            Dim num = Convert.ToInt32(txtFolio.Text)
            Dim nuevo = num + 1

            escritor.WriteLine("Fecha: " & dtpFecha.Text)
            escritor.WriteLine("Vendedor: " & txtVendedor.Text)
            escritor.WriteLine("Cliente: " & txtCliente.Text)
            escritor.WriteLine("Prestamo: $ " & txtPrestamo.Text)
            escritor.WriteLine("Importe: $ " & txtImporte.Text)
            escritor.WriteLine("-------------------------------")
            escritor.WriteLine("Folio: " & nuevo)
            txtFolio.Text = nuevo.ToString()
            escritor.Close()
        End If
    End Sub

    Public Sub ticket()
        Dim nombre As String = "folio.txt"
        Dim direccion As String = "C:\\Archivo\\"
        Dim lector(2) As String
        Dim datos(2) As String

        If File.Exists(direccion & nombre) Then
            lector = File.ReadAllLines(direccion & nombre)
            Dim linea = lector(lector.Length - 1)
            datos = linea.Split(":")
            txtFolio.Text = datos(1)
        Else
            escritor = File.CreateText(direccion & nombre)
            escritor.WriteLine("Folio: 1")
            txtFolio.Text = "1"
            escritor.Close()
        End If
    End Sub

    Private Sub Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case acceso
            Case "Gerente"
                RegistrarUsuariosToolStripMenuItem.Enabled = False
            Case "Cajero"
                RegistrarUsuariosToolStripMenuItem.Enabled = False
                DepartamentosToolStripMenuItem.Enabled = False
        End Select

        Dim culture As New System.Globalization.CultureInfo("es-ES")
        culture.NumberFormat.CurrencyDecimalSeparator = "."
        culture.NumberFormat.CurrencyGroupSeparator = ","
        culture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = culture

        Call llenar(cmbArticulo)
        Call cargar(cmbCliente)
        Call ticket()

        hilo = New Thread(New ThreadStart(AddressOf conectar))
        hilo.Start()
        Me.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub CalculadoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculadoraToolStripMenuItem.Click
        Calculadora.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Clientes.Show()
        'Me.Hide()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar.Show()
    End Sub

    Private Sub DepartamentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartamentosToolStripMenuItem.Click
        Articulos.Show()
        'Me.Hide()
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        If cmbCliente.Text = "" Then
            MsgBox("Seleccione primero al cliente")
        Else
            Try
                If cmbArticulo.Text = "" Then
                    MsgBox("Seleccione el tipo de articulo")
                Else
                    Dim prestamo As Double
                    Dim interes As Double

                    CN.abrir()
                    CN.consulta("SELECT prestamo, interes FROM articulos WHERE departamento = '" & cmbArticulo.Text & "';")
                    While CN.dr.Read()
                        prestamo = Convert.ToInt32(CN.dr("prestamo"))
                        interes = Convert.ToInt32(CN.dr("interes"))
                    End While
                    CN.cerrar()

                    Dim porc_prestamo As Double = prestamo / 100
                    Dim porc_interes As Double = interes / 100
                    If txtValor.Text = "" Then
                        MsgBox("Ingrese el valor de la prenda")
                    Else
                        Dim valor As Double = Convert.ToDouble(txtValor.Text)
                        txtPrestamo.Text = valor * porc_prestamo
                        Dim prestacion As Double = Convert.ToDouble(txtPrestamo.Text)
                        txtImporte.Text = (prestacion * porc_interes) + prestacion

                        Call registrar()
                        Call generarTicket()
                        btnEstadisticas.Enabled = True

                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub cmbArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbArticulo.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtCliente.Clear()
        cmbArticulo.Items.Clear()

        txtValor.Clear()
        txtPrestamo.Clear()
        txtImporte.Clear()
    End Sub

    Private Sub btnEstadisticas_Click(sender As Object, e As EventArgs) Handles btnEstadisticas.Click
        Dim i As Integer
        Dim total = dg1.Rows.Count
        Dim suma As Double = 0
        Dim valorMax As Double = 0
        Dim valorMin As Double = Double.MaxValue

        For i = 0 To total - 1
            suma = suma + Double.Parse(dg1(5, i).Value)

            If Double.Parse(dg1(5, i).Value) > valorMax Then
                valorMax = Double.Parse(dg1(5, i).Value)
            End If
            If Double.Parse(dg1(5, i).Value) < valorMin Then
                valorMin = Double.Parse(dg1(5, i).Value)
            End If
        Next

        Dim promedio = (suma / total)
        txtPromedio.Text = promedio.ToString()

        txtMax.Text = valorMax.ToString()
        txtMin.Text = valorMin.ToString()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub RegistrarUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarUsuariosToolStripMenuItem.Click
        Usuarios.Show()
        'Me.Hide()
    End Sub

End Class
