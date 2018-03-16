
Public Class Calculadora
    Dim n1 As Double = Nothing
    Dim n2 As Double = Nothing
    Dim R As Double = Nothing
    Dim op As String = ""
    Dim secuencia As Boolean = True
    Dim punto As Boolean = True
    Dim cadena As String = ""
    Dim substring As String = ""

    Private Sub Calculadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Pantalla.Enabled = False
        Pantalla.Text = "0."

        Dim culture As New System.Globalization.CultureInfo("es-ES")
        culture.NumberFormat.CurrencyDecimalSeparator = "."
        culture.NumberFormat.CurrencyGroupSeparator = ","
        culture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = culture

        Me.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "1."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "1."
            Else
                Pantalla.Text += "1"
                punto = False
            End If
        End If
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "2."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "2."
            Else
                Pantalla.Text += "2"
                punto = False
            End If
        End If
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "3."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "3."
            Else
                Pantalla.Text += "3"
                punto = False
            End If
        End If
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "4."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "4."
            Else
                Pantalla.Text += "4"
                punto = False
            End If
        End If
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "5."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "5."
            Else
                Pantalla.Text += "5"
                punto = False
            End If
        End If
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "6."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "6."
            Else
                Pantalla.Text += "6"
                punto = False
            End If
        End If
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "7."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "7."
            Else
                Pantalla.Text += "7"
                punto = False
            End If
        End If
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "8."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "8."
            Else
                Pantalla.Text += "8"
                punto = False
            End If
        End If
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "9."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "9."
            Else
                Pantalla.Text += "9"
                punto = False
            End If
        End If
    End Sub

    Private Sub btnPunto_Click(sender As Object, e As EventArgs) Handles btnPunto.Click
        If secuencia = True Then
            Pantalla.Text = "0."
            secuencia = False
        End If
        punto = False
    End Sub

    Private Sub btnSuma_Click(sender As Object, e As EventArgs) Handles btnSuma.Click
        op = "+"
        n1 = Val(Pantalla.Text)
        secuencia = True
        punto = True
    End Sub

    Private Sub btnResta_Click(sender As Object, e As EventArgs) Handles btnResta.Click
        op = "-"
        n1 = Val(Pantalla.Text)
        secuencia = True
        punto = True
    End Sub

    Private Sub btnMult_Click(sender As Object, e As EventArgs) Handles btnMult.Click
        op = "*"
        n1 = Val(Pantalla.Text)
        secuencia = True
        punto = True
    End Sub

    Private Sub btnDiv_Click(sender As Object, e As EventArgs) Handles btnDiv.Click
        op = "/"
        n1 = Val(Pantalla.Text)
        secuencia = True
        punto = True
    End Sub

    Private Sub btnIgual_Click(sender As Object, e As EventArgs) Handles btnIgual.Click
        n2 = Val(Pantalla.Text)
        punto = True
        secuencia = True

        Select Case op
            Case "+"
                R = n1 + n2
            Case "-"
                R = n1 - n2
            Case "*"
                R = n1 * n2
            Case "/"
                R = n1 / n2
        End Select

        Dim aux As Boolean = R.ToString().Contains(".")

        If aux = False Then
            Pantalla.Text = R & "."
        Else
            Pantalla.Text = R
        End If

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Pantalla.Text = "0."
        n1 = 0
        n2 = 0
        R = 0
        secuencia = True
        punto = True
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        If secuencia = True Then
            Pantalla.Clear()
            Pantalla.Text = "0."
            secuencia = False
        Else
            If punto = True Then
                cadena = Pantalla.Text
                substring = cadena.Substring(0, cadena.Length - 1)
                Pantalla.Text = substring & "0."
            Else
                Pantalla.Text += "0"
                punto = False
            End If
        End If
    End Sub
End Class