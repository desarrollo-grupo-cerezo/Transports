Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports Stimulsoft.Report

Public Class frmReportePrecioCostos
    Private BindingSource1 As BindingSource = New BindingSource
    Private Sub frmReportePrecioCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Fg.Rows.Count = 1

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 50
            Fg.Height = Me.Height - C1ToolBar1.Height - C1FlexGridSearchPanel1.Height - 100
            Fg.Rows(0).Height = 50
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim COSTO_CONIVA As Decimal, PRECIO_CONIVA As Decimal, z As Long

        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Red
        NewStyle1.ForeColor = Color.White
        'Fg.SetCellStyle(0, 0, NewStyle1)

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor
        Fg.Redraw = False

        Try
            Fg.Rows.Count = 1
            SQL = "SELECT CVE_ART, DESCR, LIN_PROD, COSTO_PROM, DESCRIPESQ, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "ORDER BY DESCR"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.CommandTimeout = 300
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()

                        Try
                            COSTO_CONIVA = dr.ReadNullAsEmptyDecimal("COSTO_PROM") + (dr.ReadNullAsEmptyDecimal("COSTO_PROM") * 0.16)
                            PRECIO_CONIVA = dr("P1") + (dr("P1") * 0.16)
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        End Try


                        Fg.AddItem(z & vbTab & dr.ReadNullAsEmptyString("CVE_ART") & vbTab & dr.ReadNullAsEmptyString("DESCR") & vbTab &
                                   dr.ReadNullAsEmptyString("LIN_PROD") & vbTab & dr.ReadNullAsEmptyDecimal("COSTO_PROM") & vbTab &
                                   dr.ReadNullAsEmptyDecimal("P1") & vbTab & dr.ReadNullAsEmptyString("DESCRIPESQ") & vbTab &
                                   COSTO_CONIVA & vbTab & PRECIO_CONIVA)
                        z = z + 1
                    End While
                End Using
            End Using

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Private Sub frmReportePrecioCostos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Reporte precio costos")
    End Sub

    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Desplegar"
                    DESPLEGAR()
                Case "Excel"
                    EXPORTAR_EXCEL_TRANSPORT(Fg, "Reporte precio de costo")
                Case "Imprimir"
                    Imprimir()
                Case "Salir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub Imprimir()
        Dim Rreporte_MRT As String = ""
        Dim RUTA_FORMATOS As String
        Dim Reporte As New StiReport

        RUTA_FORMATOS = GET_RUTA_FORMATOS()
        Try
            Rreporte_MRT = "ReportPrecioCosto.mrt"
            If Not File.Exists(RUTA_FORMATOS & "\" & Rreporte_MRT) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\" & Rreporte_MRT & ", verifique por favor")
                Return
            End If
            Reporte.Load(RUTA_FORMATOS & "\" & Rreporte_MRT)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            For k = 1 To Fg.Rows.Count - 1
                'StiUserData1.a.Columns.Item(0) = Fg(k, 1)

            Next
            Reporte.Dictionary.Databases.Clear()
            Reporte.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            Reporte.Compile()
            Reporte.Dictionary.Synchronize()
            Reporte.ReportName = Me.Text
            Reporte.Render()
            'Reporte.Show()
            VisualizaReporte(Reporte)

        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
