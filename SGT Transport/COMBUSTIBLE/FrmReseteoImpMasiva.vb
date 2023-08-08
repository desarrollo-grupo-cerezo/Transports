Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports Stimulsoft
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Components

Partial Public Class FrmReseteoImpMasiva
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmReseteoImpMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Fg.Dock = DockStyle.Fill
        DESPLEGAR()

    End Sub
    Sub DESPLEGAR()

        Fg.Redraw = False
        Fg.BeginUpdate()
        Me.Cursor = Cursors.WaitCursor

        SQL = "SELECT TOP 1000 ISNULL(R.AJUST_TAB,0), R.CVE_RES, R.ESTADO, R.FECHA, NOMBRE
            FROM GCRESETEO R 
            LEFT JOIN GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
            WHERE R.STATUS <> 'B' AND ESTADO = 'FINALIZADO'
            ORDER BY R.FECHAELAB DESC"

        Dim da As SqlDataAdapter
        Dim dt As DataTable

        da = New SqlDataAdapter(SQL, cnSAE)
        dt = New DataTable
        da.SelectCommand.CommandTimeout = 120
        da.Fill(dt)

        BindingSource1.DataSource = dt
        Fg.DataSource = BindingSource1.DataSource

        Fg(0, 1) = "Seleccione"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(Boolean)

        Fg(0, 2) = "Reseteo"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(Int64)
        c2.TextAlign = TextAlignEnum.CenterCenter

        Fg(0, 3) = "Estado"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)
        c3.TextAlign = TextAlignEnum.CenterCenter

        Fg(0, 4) = "Fecha"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(Date)
        c4.TextAlign = TextAlignEnum.CenterCenter

        Fg(0, 5) = "Operador"
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)


        Fg.Cols(1).StarWidth = "*"
        Fg.Cols(2).StarWidth = "*"
        Fg.Cols(3).StarWidth = "*"
        Fg.Cols(4).StarWidth = "*"
        Fg.Cols(5).StarWidth = "2*"

        Fg.Redraw = True
        Fg.EndUpdate()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FrmReseteoImpMasiva_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            For K = 1 To Fg.Rows.Count - 1
                If Fg(K, 1) Then
                    IMPRIMIR(Fg(K, 2))
                End If
            Next
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub IMPRIMIR(FCVE_RES As Long)
        Dim RUTA_FORMATOS As String = ""
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportReseteo.mrt"

            If Not IO.File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If

            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            'StiReport1.Compile()
            'StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text


            Dim reportAll As New StiReport()
            reportAll.Render()
            reportAll.RenderedPages.Clear()

            For k = 1 To Fg.Rows.Count - 1

                If Fg(k, 1) Then
                    StiReport1.Item("CVE_RES") = Fg(k, 2)
                    StiReport1.Render(False)

                    For Each page As StiPage In StiReport1.RenderedPages
                        reportAll.RenderedPages.Add(page)
                    Next page

                End If
            Next

            reportAll.Print() ' .Show()



            'StiReport1.Item("CVE_RES") = FCVE_RES
            'StiReport1.Render()
            'StiReport1.Print(True)

            'StiReport1.Show()
        Catch ex As Exception
            Bitacora("840. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
            MsgBox("840. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If e.Row > 0 Then
                If e.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
