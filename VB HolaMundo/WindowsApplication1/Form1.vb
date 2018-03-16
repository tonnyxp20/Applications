Public Class Form1
    Dim x As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        x = "hola mundo"
        'Call nombre()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Form2.lbltexto.Text = x
        'Form2.BackColor = Color.Cyan
        'Form2.Show()
        'ActiveForm
        'Me.Hide()

        Dim n As Integer
        n = InputBox("Ingrese un numero", "Numero")

        If n >= 10 Then
            Form2.Show()
        ElseIf n = 7 Then
            MsgBox("Tu dato es el " & n)
        Else
            MsgBox("Dato menor a 10")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Application.Exit()
        End
    End Sub

    Public Sub nombre()
        MsgBox("Hello word")
    End Sub

    Private Sub Input_Click(sender As Object, e As EventArgs) Handles Input.Click
        x = InputBox("Ingrese un texto", "Variable")
    End Sub
End Class
