Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmMinveR

    Private Sub frmMinveR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Try
                If Not Valida_Conexion() Then
                    Me.Close()
                    Return
                End If
            Catch ex As Exception
                MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Catch ex As Exception
            End Try

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 14

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Articulo"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripcion"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Linea"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Cliente/Prov"
            Dim c5 As Column = Fg.Cols(5)
            c2.DataType = GetType(String)

            Fg(0, 6) = "Almacen"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Int32)

            Fg(0, 7) = "Concepto"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Int32)

            Fg(0, 8) = "Decripcion"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Int32)

            Fg(0, 9) = "Fecha"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(DateTime)

            Fg(0, 10) = "Cantidad"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            'Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 11) = "Costo"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Costo prom."
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Folio"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(String)

            SQL = "SELECT M.REFER, M.CVE_ART, I.DESCR, I.LIN_PROD, M.CLAVE_CLPV, M.ALMACEN, M.CVE_CPTO, C.DESCR AS DES_CON, M.FECHA_DOCU, M.CANT, M.COSTO, " &
                "I.COSTO_PROM, M.CVE_FOLIO " &
                "FROM GCMINVER" & Empresa & " M " &
                "LEFT JOIN GCINVER I ON I.CVE_ART = M.CVE_ART " &
                "LEFT JOIN CONM" & Empresa & " C ON C.CVE_CPTO = M.CVE_CPTO " &
                "WHERE FECHA_DOCU = '" & FSQL(Now) & "' AND TIPO_DOC = 'M'"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
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

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("REFER") & vbTab & dr("CVE_ART") & vbTab & dr("DESCR") & vbTab & dr("LIN_PROD") & vbTab &
                           dr("CLAVE_CLPV") & vbTab & dr("ALMACEN") & vbTab & dr("CVE_CPTO") & vbTab & dr("DES_CON") & vbTab & dr("FECHA_DOCU") & vbTab &
                           dr("CANT") & vbTab & dr("COSTO") & vbTab & dr("COSTO_PROM") & vbTab & dr("CVE_FOLIO"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmMinveR_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Movimientos al Inventario")
        Me.Dispose()
    End Sub

    Private Sub frmMinveR_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmMinveRAE.ShowDialog()

            SQL = "SELECT M.REFER, M.CVE_ART, I.DESCR, I.LIN_PROD, M.CLAVE_CLPV, M.ALMACEN, M.CVE_CPTO, C.DESCR AS DES_CON, M.FECHA_DOCU, M.CANT, M.COSTO, " &
                "I.COSTO_PROM, M.CVE_FOLIO " &
                "FROM GCMINVER" & Empresa & " M " &
                "LEFT JOIN GCINVER I ON I.CVE_ART = M.CVE_ART " &
                "LEFT JOIN CONM" & Empresa & " C ON C.CVE_CPTO = M.CVE_CPTO " &
                "WHERE FECHA_DOCU = '" & FSQL(Now) & "' AND TIPO_DOC = 'M'"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub mnuReimprimir_Click(sender As Object, e As EventArgs) Handles mnuReimprimir.Click
        Try
            Dim REFER As String

            If Fg.Row > 0 Then
                REFER = Fg(Fg.Row, 1)
                Dim RUTA_FORMATOS As String

                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportMinve" & Empresa & ".mrt"
                If Not File.Exists(RUTA_FORMATOS) Then

                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportMinve.mrt"
                    If Not File.Exists(RUTA_FORMATOS) Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                End If

                StiReport1.Load(RUTA_FORMATOS)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("REFER") = REFER
                StiReport1.Render()
                StiReport1.Show()
                'StiReport1.Design()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barHoy_Click(sender As Object, e As EventArgs) Handles barHoy.Click
        Try
            SQL = "SELECT M.REFER, M.CVE_ART, I.DESCR, I.LIN_PROD, M.CLAVE_CLPV, M.ALMACEN, M.CVE_CPTO, C.DESCR AS DES_CON, M.FECHA_DOCU, M.CANT, M.COSTO, " &
                "I.COSTO_PROM, M.CVE_FOLIO " &
                "FROM GCMINVER" & Empresa & " M " &
                "LEFT JOIN GCINVER I ON I.CVE_ART = M.CVE_ART " &
                "LEFT JOIN CONM" & Empresa & " C ON C.CVE_CPTO = M.CVE_CPTO " &
                "WHERE FECHA_DOCU = '" & FSQL(Now) & "' AND TIPO_DOC = 'M'"

            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barEsteMes_Click(sender As Object, e As EventArgs) Handles barEsteMes.Click
        Try
            SQL = "SELECT M.REFER, M.CVE_ART, I.DESCR, I.LIN_PROD, M.CLAVE_CLPV, M.ALMACEN, M.CVE_CPTO, C.DESCR AS DES_CON, M.FECHA_DOCU, M.CANT, M.COSTO, " &
                "I.COSTO_PROM, M.CVE_FOLIO " &
                "FROM GCMINVER" & Empresa & " M " &
                "LEFT JOIN GCINVER I ON I.CVE_ART = M.CVE_ART " &
                "LEFT JOIN CONM" & Empresa & " C ON C.CVE_CPTO = M.CVE_CPTO " &
                "WHERE YEAR(FECHA_DOCU) = " & Year(Now) & " AND MONTH(FECHA_DOCU) = " & Month(Now) & " AND TIPO_DOC = 'M'"
            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barMesAnterior_Click(sender As Object, e As EventArgs) Handles barMesAnterior.Click
        Try
            SQL = "SELECT M.REFER, M.CVE_ART, I.DESCR, I.LIN_PROD, M.CLAVE_CLPV, M.ALMACEN, M.CVE_CPTO, C.DESCR AS DES_CON, M.FECHA_DOCU, M.CANT, M.COSTO, " &
                "I.COSTO_PROM, M.CVE_FOLIO " &
                "FROM GCMINVER" & Empresa & " M " &
                "LEFT JOIN GCINVER I ON I.CVE_ART = M.CVE_ART " &
                "LEFT JOIN CONM" & Empresa & " C ON C.CVE_CPTO = M.CVE_CPTO " &
                "WHERE YEAR(FECHA_DOCU) = " & Year(Now) & " AND MONTH(FECHA_DOCU) = " & Month(DateAdd("m", -1, Now)) & " AND TIPO_DOC = 'M'"
            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barTodos_Click(sender As Object, e As EventArgs) Handles barTodos.Click
        Try
            SQL = "SELECT M.REFER, M.CVE_ART, I.DESCR, I.LIN_PROD, M.CLAVE_CLPV, M.ALMACEN, M.CVE_CPTO, C.DESCR AS DES_CON, M.FECHA_DOCU, M.CANT, M.COSTO, " &
                "I.COSTO_PROM, M.CVE_FOLIO " &
                "FROM GCMINVER" & Empresa & " M " &
                "LEFT JOIN GCINVER I ON I.CVE_ART = M.CVE_ART " &
                "LEFT JOIN CONM" & Empresa & " C ON C.CVE_CPTO = M.CVE_CPTO " &
                "WHERE TIPO_DOC = 'M'"
            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
End Class
