Public Class Tablas
    Public num As Integer

    Private Sub Tablas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Multiplicar()
    End Sub

    Public Sub Multiplicar()
        Dim res As Integer
        Dim i As Integer

        For i = 1 To 10
            res = num * i
            lblnum.Text = lblnum.Text & num & " X " & i & " = " & res & vbCrLf
        Next
    End Sub

    Private Sub btncalc_Click(sender As Object, e As EventArgs) Handles btncalc.Click
        Calculadora.Show()
        Me.Hide()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub
End Class