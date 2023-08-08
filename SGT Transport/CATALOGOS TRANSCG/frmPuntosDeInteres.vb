
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.C1Excel

Public Class frmPuntosDeInteres
    Private Sub frmPuntosDeInteres_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If


            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 11

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "ID"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int32)

            Fg(0, 2) = "NOMBRE"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "LONGITUD"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "LATITUD"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "TIPO"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "CIUDAD"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "ESTADO"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "PAIS"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "CATEGORIA"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)


            Fg.Cols(1).AllowEditing = False
            Fg.Cols(2).AllowEditing = False
            Fg.Cols(3).AllowEditing = False
            Fg.Cols(4).AllowEditing = False
            Fg.Cols(5).AllowEditing = False
            Fg.Cols(6).AllowEditing = False
            Fg.Cols(7).AllowEditing = False
            Fg.Cols(8).AllowEditing = False
            Fg.Cols(9).AllowEditing = False
            Fg.Cols(10).AllowEditing = False

            DESPLEGAR()

        Catch ex As Exception
            msgbox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT ID, NOMBRE, LONGITUD, LATITUD, TIPO, CIUDAD, ESTADO, PAIS, CATEGORIA, GUID FROM GCPUNTOS_INTERES"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("ID") & vbTab & dr("NOMBRE") & vbTab & dr("LONGITUD") & vbTab & dr("LATITUD") & vbTab & dr("TIPO") & vbTab & dr("CIUDAD") & vbTab & dr("ESTADO") & vbTab & dr("PAIS") & vbTab & dr("CATEGORIA") & vbTab & dr("GUID"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmPuntosDeInteres_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Puntos de Interes")
        Me.Dispose()
    End Sub
    Private Sub frmPuntosDeInteres_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub
    Private Sub barImportarExcel_Click(sender As Object, e As EventArgs) Handles barImportarExcel.Click
        Try
            Dim ofd As OpenFileDialog = New OpenFileDialog
            ofd.DefaultExt = "jpg"
            ofd.FileName = ""
            'ofd.InitialDirectory = "c:\"
            ofd.Filter = "Excel|*.xls;*.xlsx"
            ofd.Title = "Seleccione archivo"
            If ofd.ShowDialog() <> DialogResult.Cancel Then
                Extraer_Excel(ofd.FileName)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Extraer_Excel(fFile As String)
        Dim row As Integer, col As Integer
        Dim Cadena As String

        Try
            Fg.Rows.Count = 1

            Me.Cursor = Cursors.WaitCursor
            Fg.Cursor = Cursors.WaitCursor

            C1XLBook1.Clear()
            C1XLBook1.Load(fFile)
            Dim source As XLSheet = C1XLBook1.Sheets(0)

            For row = 1 To source.Rows.Count - 1
                Application.DoEvents()

                Cadena = ""
                For col = 0 To source.Columns.Count - 1
                    If Not IsNothing(source(row, col).Value) Then
                        Cadena = Cadena & vbTab & source(row, col).Value
                    Else
                        Cadena = Cadena & vbTab & ""
                    End If
                Next col

                Fg.AddItem(Cadena)

            Next row
            Fg.AutoSizeCols()
            Me.Cursor = Cursors.Default
            Fg.Cursor = Cursors.Default
            MsgBox("Proceso terminado")

        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
