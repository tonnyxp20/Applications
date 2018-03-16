Imports MySql.Data.MySqlClient
Imports System.Data

Public Class conexion
    Public cn As MySqlConnection = New MySqlConnection("Server=192.168.56.101; Database=Empeno; Uid=usuario; Pwd=123;")
    Public dr As MySqlDataReader

    Public Sub abrir()
        cn.Open()
    End Sub

    Public Sub cerrar()
        cn.Close()
    End Sub

    Public Sub consulta(ByVal query As String)
        Dim cmd As MySqlCommand = New MySqlCommand(query, cn)
        dr = cmd.ExecuteReader()
    End Sub

    Public Sub movimientos(ByVal query As String)
        Dim cmd As MySqlCommand = New MySqlCommand(query, cn)
        cmd.ExecuteNonQuery()
    End Sub
End Class
