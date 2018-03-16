Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnentrar_Click(sender As Object, e As EventArgs) Handles btnentrar.Click
        Dim n As Integer
        Try
            If txtus.Text = "admin" And txtpass.Text = "123" Then
                n = InputBox("Tablas de Multiplicar", "Ingrese un numero")
                If n > 0 Then
                    Tablas.lbltabla.Text = "Tabla del " & n
                    Tablas.num = n
                    Tablas.Show()
                    Me.Hide()
                End If
            Else
                MsgBox("¡Acceso denegado!")
                txtus.Clear()
                txtpass.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        End
    End Sub
End Class
