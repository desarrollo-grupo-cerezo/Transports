Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmGastoRenovado
    Private Sub FrmGastoRenovado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 8

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int16)

            Fg(0, 2) = "Servicio"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Unidad"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Almacen"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Int16)

            Fg(0, 5) = "Importe"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Fecha"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Date)

            Fg(0, 7) = "Observaciones"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New sqlcommand
            Dim dr As sqldatareader
            cmd.connection = cnSAE

            SQL = "SELECT CVE_GASTO, MAX(CVE_ART) AS CVEART, MAX(CVE_UNI) AS CVEUNI, MAX(NUM_ALM) AS NUMALM, 
                sum(COSTO) AS COST, MAX(FECHA) AS FECH, MAX(O1.DESCR) AS DES_DOC
                FROM GCGASTOS_RENOVADO G
                LEFT JOIN GCOBS O1 ON O1.CVE_OBS = G.CVE_OBS_DOC
                WHERE ISNULL(G.STATUS,'A') = 'A' GROUP BY CVE_GASTO ORDER BY CVE_GASTO"

            cmd.commandtext = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_GASTO") & vbTab & dr("CVEART") & vbTab & dr("CVEUNI") & vbTab & dr("NUMALM") & vbTab &
                            dr("COST") & vbTab & dr("FECH") & vbTab & dr("DES_DOC"))
            Loop
            dr.close
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmGastoRenovado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Gasto renovado")
        Me.Dispose()
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            FrmGastoRenovadoAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            FrmGastoRenovadoAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCGASTOS_RENOVADO SET STATUS = 'B' WHERE CVE_GASTO = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se elimino satisfactoriamente")
                        DESPLEGAR()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "GASTOS RENOVADO")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit

    End Sub

    Private Sub barActualizar_Click(sender As Object, e As EventArgs) Handles barActualizar.Click
        DESPLEGAR()
    End Sub
End Class
