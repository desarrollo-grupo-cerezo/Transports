

Public Class frmGoogleMaps1
    Dim dt As DataTable
    Dim selection As Integer = 0

    Dim Lat As Double = 18.04173
    Dim Lng As Double = -92.90129

    Private Sub frmGoogleMaps1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt = GetTable()
        For Each dr As DataRow In dt.Rows
            'Tạo marker position map
        Next


    End Sub
    Function GetTable() As DataTable
        Dim table As New DataTable

        table.Columns.Add("Name", GetType(String))
        table.Columns.Add("Lat", GetType(Double))
        table.Columns.Add("Lng", GetType(Double))

        table.Rows.Add("Lugar 1 ", 18.90343, -92.90129)
        table.Rows.Add("Lugar 2 ", 18.04173, -92.90194)
        table.Rows.Add("Lugar 3 ", 18.04101, -92.90192)
        table.Rows.Add("Lugar 4 ", 18.04101, -92.90192)
        table.Rows.Add("Lugar 5 ", 18.04099, -92.90193)
        Return table
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Public Shared Function DegreesToRadians(ByVal degrees As Double) As Double
        Const degToRadFactor As Double = Math.PI / 180
        Return degrees * degToRadFactor
    End Function

    Public Shared Function RadiansToDegrees(ByVal radians As Double) As Double
        Const radToDegFactor As Double = 180 / Math.PI
        Return radians * radToDegFactor
    End Function


End Class
