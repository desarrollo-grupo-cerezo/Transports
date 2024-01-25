Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class frmFACTURAS
    Dim CADENA As String
    Dim MULTIALMACEN As Integer
    Dim TIPO_VENTA_LOCAL As String '= TIPO_VENTA
    Dim TOP_REG As String
    Dim CARPORT As Boolean
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            TIPO_VENTA_LOCAL = TIPO_VENTA

            Select Case TIPO_VENTA_LOCAL
                Case "F"
                    LtCompras.Text = "Facturación"
                Case "V"
                    LtCompras.Text = "Nota de venta"
                Case "P"
                    LtCompras.Text = "Pedido"
                Case "R"
                    LtCompras.Text = "Remisión"
                Case "C"
                    LtCompras.Text = "Cotización"
                Case "D"
                    LtCompras.Text = "Devoluciones"
            End Select

            If Var4 = "CARTA PORTE" Then
                CARPORT = True
                REM_CARTA_PORTE = True
            Else
                CARPORT = False
                REM_CARTA_PORTE = False
            End If

            DERECHOS()

            CARGA_PARAM_INVENT()

            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue

            Fg.FocusRect = FocusRectEnum.Solid
            Fg.SelectionMode = SelectionModeEnum.ListBox
            Fg.AutoClipboard = True
            Fg.ClipboardCopyMode = ClipboardCopyModeEnum.DataAndColumnHeaders

            Fg.Styles("Alternate").BackColor = Color.PowderBlue
            Fg.Styles("Highlight").BackColor = Color.CornflowerBlue

            Fg.Styles("Focus").BackColor = Color.CornflowerBlue
            Fg.Styles("Focus").ForeColor = Color.Black
            Fg.Styles("Focus").Border.Color = Color.Red
            Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg.Rows.Count = 2
            Fg.Rows(0).Height = 40
            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - C1ToolBar1.Height - 250

            Fg.Dock = DockStyle.Fill

            CADENA = "" '" WHERE FECHA_DOC = '" & FSQL(Date.Now) & "'"
            TOP_REG = " TOP 500 "

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmFACTURAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
    End Sub
    Sub DERECHOS()
        Dim z As Integer

        If pwPoder Then
            Try
                BarNuevo.Visible = True
                BarEdit.Visible = True
                BarExcel.Visible = True
                BarEstatusCFDI.Visible = True
                BarTimbrar.Visible = True
                BarImprimir.Visible = True
                BarSendMail.Visible = True
            Catch ex As Exception
            End Try
        Else
            Try
                BarNuevo.Visible = False
                BarEdit.Visible = False
                BarExcel.Visible = False
                BarEstatusCFDI.Visible = False
                BarTimbrar.Visible = False
                BarImprimir.Visible = False
                BarSendMail.Visible = False
            Catch ex As Exception
            End Try
            Try

                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE > 61000 AND CLAVE < 70000"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 61100
                                    BarNuevo.Visible = True
                                Case 60150
                                    BarEdit.Visible = True
                                Case 60200
                                    BarEstatusCFDI.Visible = True
                                Case 60250
                                    BarTimbrar.Visible = True
                                Case 60300
                                    BarImprimir.Visible = True
                                Case 60350
                                    BarSendMail.Visible = True
                                Case 60400
                                    BarExcel.Visible = True
                            End Select
                            z = z + 1
                        End While
                    End Using
                End Using
                If z = 0 Then
                End If
                Try
                    'C1FlexGridSearchPanel1.ActiveControl.Text = ""
                Catch ex As Exception
                End Try
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Fg.Redraw = False

        Try
            If TIPO_VENTA_LOCAL = "D" Then
                CADENA = ""
                SQL = "SELECT " & TOP_REG & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, 
                    CASE C.STATUS WHEN 'E' THEN 'Emitida' WHEN 'O' THEN 'Emitida' WHEN 'C' THEN 'Cancelada' END AS ST, CVE_PEDI,
                    (SELECT TOP 1 CASE WHEN ISNULL(F.TIMBRADO,'') = 'S' THEN 'Pendiente' WHEN ISNULL(TIMBRADO,'') = 'N' THEN 'Timbrada' ELSE '' END 
                    FROM CFDI_COM_PAGO FD WHERE TDOC = 'NC' AND DOCUMENTO = C.CVE_DOC) AS 'Factura digital', C.FECHA_DOC, C.FECHA_ENT, 
                    C.FECHA_VEN, C.FECHA_CANCELA, C.CAN_TOT, C.IMP_TOT1, C.IMP_TOT2, C.IMP_TOT3, C.IMP_TOT4, C.DES_TOT, C.DES_FIN, 
                    C.NUM_ALMA, C.FECHAELAB, C.IMPORTE, ISNULL(C.DOC_ANT,'') AS D_ANT, C.USO_CFDI, C.REG_FISC, ISNULL(C.EMAILPRED,'') AS CORREO
                    FROM FACT" & TIPO_VENTA_LOCAL.ToUpper & Empresa & " C                
                    LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV
                    LEFT JOIN FACT" & TIPO_VENTA_LOCAL.ToUpper & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = C.CVE_DOC " &
                    CADENA & " ORDER BY FECHAELAB DESC"
            Else
                SQL = "SELECT " & TOP_REG & " F.CVE_DOC, F.CVE_CLPV, C.NOMBRE, 
                    CASE CFD.ESTATUS WHEN 'C' THEN 'Cancelada' ELSE 'Emitida' END AS ST, F.CVE_PEDI,
                    CASE WHEN ISNULL(ESTATUS,'N') = 'C' THEN 'CANCELADA' WHEN ISNULL(F.TIMBRADO,'N') = 'S' THEN 'TIMBRADA' WHEN ISNULL(F.TIMBRADO,'N') = 'N' THEN 'Pendiente' ELSE 'Cancelada' END AS FACT_CFDI, 
                    F.RFC, C.CODIGO, F.FECHA_DOC, F.CAN_TOT, F.IMP_TOT1, F.IMP_TOT2, F.IMP_TOT3, F.IMP_TOT4, F.IMPORTE, F.DES_TOT, F.DES_FIN, 
                    F.NUM_ALMA, F.FECHA_ENT, F.FECHA_VEN, F.FECHA_CANCELA, F.FECHAELAB, ISNULL(F.DOC_ANT,'') AS D_ANT, ISNULL(F.DOC_SIG,'') AS D_SIG, 
                    C.USO_CFDI, C.REG_FISC, ISNULL(C.EMAILPRED,'') AS CORREO
                    FROM FACT" & TIPO_VENTA_LOCAL.ToUpper & Empresa & " F
                    LEFT JOIN CFDI CFD ON CFD.FACTURA = F.CVE_DOC
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE  = F.CVE_CLPV " &
                    CADENA & " ORDER BY FECHAELAB DESC"
            End If

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg(0, 1) = "Documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)
            'c1.TextAlign = TextAlignEnum.CenterCenter

            Fg(0, 2) = "Cliente"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Estatus"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Pedido"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Documento digital"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "RFC"
            Dim c66 As Column = Fg.Cols(7)
            c66.DataType = GetType(String)

            Fg(0, 8) = "CP"
            Dim c67 As Column = Fg.Cols(8)
            c67.DataType = GetType(String)

            Fg(0, 9) = "Fecha"
            Dim c7 As Column = Fg.Cols(9)
            c7.DataType = GetType(DateTime)

            Fg(0, 10) = "Subtotal"
            Dim c11 As Column = Fg.Cols(10)
            c11.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "IEPS"
            Dim c12 As Column = Fg.Cols(11)
            c12.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Retención ISR"
            Dim c13 As Column = Fg.Cols(12)
            c13.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Retención IVA"
            Dim c14 As Column = Fg.Cols(13)
            c14.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "IVA"
            Dim c15 As Column = Fg.Cols(14)
            c15.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Importe"
            Dim c20 As Column = Fg.Cols(15)
            c20.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Descuento"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "Des. fin."
            Dim c17 As Column = Fg.Cols(17)
            c17.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "Almacen"
            Dim c18 As Column = Fg.Cols(18)
            c18.DataType = GetType(Int32)

            Fg(0, 19) = "Fecha rec."
            Dim c8 As Column = Fg.Cols(19)
            c8.DataType = GetType(DateTime)

            Fg(0, 20) = "Fecha pag."
            Dim c9 As Column = Fg.Cols(20)
            c9.DataType = GetType(DateTime)

            Fg(0, 21) = "Fecha cancelada"
            Dim c10 As Column = Fg.Cols(21)
            c10.DataType = GetType(DateTime)

            Fg(0, 22) = "Fecha elab."
            Dim c19 As Column = Fg.Cols(22)
            c19.DataType = GetType(DateTime)
            c19.Format = "G"

            Fg(0, 23) = "Documento anterior"
            Dim c21 As Column = Fg.Cols(23)
            c21.DataType = GetType(String)

            Fg(0, 24) = "Documento siguiente"
            Dim c22 As Column = Fg.Cols(24)
            c22.DataType = GetType(String)

            Fg(0, 25) = "Uso cfdi"
            Dim c25 As Column = Fg.Cols(25)
            c25.DataType = GetType(String)

            Fg(0, 26) = "Regimen fiscal"
            Dim c26 As Column = Fg.Cols(26)
            c26.DataType = GetType(String)

            Fg(0, 27) = "Correo"
            Dim c27 As Column = Fg.Cols(27)
            c27.DataType = GetType(String)


            'Fg.Cols(1).Width = 110 : Fg.Cols(2).Width = 50 : Fg.Cols(4).Width = 60 : Fg.Cols(5).Width = 100 : Fg.Cols(6).Width = 90 : Fg.Cols(7).Width = 70
            'Fg.Cols(8).Width = 70
            'Fg.Cols(9).Width = 70 : Fg.Cols(11).Width = 70 : Fg.Cols(12).Width = 70 : Fg.Cols(13).Width = 70 : Fg.Cols(14).Width = 70 : Fg.Cols(15).Width = 65
            'Fg.Cols(16).Width = 40 : Fg.Cols(17).Width = 40 : Fg.Cols(18).Width = 90
            'Fg.Cols(20).Width = 60
            Fg.Cols(4).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(6).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(7).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(8).TextAlign = TextAlignEnum.CenterCenter

            Fg.Cols(9).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(18).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(19).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(20).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(21).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(22).TextAlign = TextAlignEnum.CenterCenter

            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            Fg.Subtotal(AggregateEnum.Clear)
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")

            Fg.AutoSizeCols()

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.Redraw = True
    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        Try
            TOP_REG = ""
            CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-1)
            TOP_REG = " "
            CADENA = " WHERE FECHA_DOC = '" & FSQL(dt) & "'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Try
            Dim dt As DateTime = Date.Today
            TOP_REG = " "
            CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddMonths(-1)
            TOP_REG = ""
            CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        Try
            CADENA = ""
            TOP_REG = ""
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs)
        Try
            BarEdit_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("325. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("325. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmFACTURAS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Facturas")
            Me.Dispose()
        Catch ex As Exception
            MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub REFRESCAR()
        Try
            CADENA = ""
            TOP_REG = " TOP 500 "
            DESPLEGAR()

        Catch ex As Exception
            MsgBox("340. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnDesplegar_Click(sender As Object, e As EventArgs) Handles btnDesplegar.Click
        Try
            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarNuevo.Click
        Try
            Var11 = "nueva"
            PassData8 = "FACTURAS"
            CREA_TAB(FrmTPV, "Punto de venta")
        Catch ex As Exception
            Bitacora("75. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        CADENA = ""
        TOP_REG = " TOP 500 "
        DESPLEGAR()
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then

                Var11 = "edit"
                Var12 = Fg(Fg.Row, 1)
                Var16 = Fg(Fg.Row, 23) 'DOCUMENTO ANTERIORIOR
                PassData9 = Fg(Fg.Row, 6) 'TIMBRADA CANCELADA PENDIENTE
                PassData8 = "FACTURAS"

                CREA_TAB(FrmTPV, "Punto de venta")
            End If
        Catch ex As Exception
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEstatusCFDI_Click(sender As Object, e As ClickEventArgs) Handles BarEstatusCFDI.Click
        If Fg.Row = 0 Then
            MsgBox("Por favor seleccione un documento")
            Return
        End If
        Dim EMISOR_RAZON_SOCIAL As String = "", EMISOR_RFC As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        EMISOR_RAZON_SOCIAL = dr("EMISOR_RAZON_SOCIAL")
                        EMISOR_RFC = dr("EMISOR_RFC")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
        End Try

        PassData1 = "FACTURA"

        Var2 = Fg(Fg.Row, 1) 'DOCUMENTO
        Var3 = EMISOR_RAZON_SOCIAL
        Var4 = EMISOR_RFC
        Var5 = Fg(Fg.Row, 7) 'RFC RECEPTOR
        Var6 = Fg(Fg.Row, 3) 'NOMBRE RECEPTOR

        FrmEstatusCFDI.ShowDialog()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "FACTURAS")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs)
        Try
            BarTimbrar.Visible = True
            Select Case Fg(Fg.Row, 6)
                Case "Pendiente"
                    BarTimbrar.Visible = True
                Case "Cancelada"
                    BarTimbrar.Visible = False
                Case "TIMBRADA"
                    BarTimbrar.Visible = False
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs)
        Dim cs1 As CellStyle
        cs1 = Fg.Styles.Add("CS1")
        cs1.BackColor = Color.LightGreen

        Dim cs2 As CellStyle
        cs2 = Fg.Styles.Add("CS2")
        cs2.BackColor = Color.Red
        cs2.ForeColor = Color.White
        cs2.Font = New Font("Tahoma", 9, FontStyle.Bold)

        Dim cs3 As CellStyle
        cs3 = Fg.Styles.Add("CS3")
        cs3.BackColor = Color.Blue
        cs3.ForeColor = Color.White

        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

            Select Case Fg(e.Row, 4)
                Case "Cancelada"
                    Fg.SetCellStyle(e.Row, 6, cs2)
            End Select
            Select Case Fg(e.Row, 6)
                Case "Pendiente"
                    Fg.SetCellStyle(e.Row, 6, cs1)
                Case "Cancelada"
                    Fg.SetCellStyle(e.Row, 6, cs2)
                Case "TIMBRADA"
                    Fg.SetCellStyle(e.Row, 6, cs3)
            End Select
        End If
    End Sub

    Private Sub BarTimbrar_Click(sender As Object, e As ClickEventArgs) Handles BarTimbrar.Click
        Dim CVE_DOC As String
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 6) = "TIMBRADA" Then
                    MsgBox("El documento ya se encuentra timbrado verifique por favor")
                    Return
                End If
                If MsgBox("Realmente desea timbrar  el documento " & Fg(Fg.Row, 1) & "?", vbYesNo) = vbYes Then

                    Dim CLIENTE_MOSTRADOR As String = ""

                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT CLIE_MOSTR, CVE_ART_FG FROM GCPARAMVENTAS"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    CLIENTE_MOSTRADOR = dr.ReadNullAsEmptyString("CLIE_MOSTR")
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try

                    If CLIENTE_MOSTRADOR = Fg(Fg.Row, 2) Then
                        PassData1 = "FACTURA GLOBAL"
                    Else
                        PassData1 = "FACTURA"
                    End If

                    Var4 = Fg(Fg.Row, 1)
                    CVE_DOC = Fg(Fg.Row, 1)
                    Var5 = Fg(Fg.Row, 27)  'CORREO
                    Var18 = ""
                    Var16 = ""

                    FrmTimbrarCdeP.LtNombre.Text = Fg(Fg.Row, 3)
                    FrmTimbrarCdeP.LtRFC.Text = Fg(Fg.Row, 7)
                    FrmTimbrarCdeP.LtUSO_CFDI.Text = Fg(Fg.Row, 25)
                    FrmTimbrarCdeP.LtRegimenReceptor.Text = Fg(Fg.Row, 26)
                    FrmTimbrarCdeP.LtCP.Text = Fg(Fg.Row, 8)

                    Var2 = ""

                    FrmTimbrarCdeP.ShowDialog()
                    If Var18 = "SI" Then
                        Fg(Fg.Row, 6) = "TIMBRADA"
                        FILE_PDF = Var16
                        FrmOPenPDFGrapecity.Show()
                    End If
                End If
            Else
                MsgBox("Por favor seleccione el documento a timbrar")
            End If

        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim RFC As String
        Try
            If Fg.Row > 0 Then
                Dim EXIST_DOC As Boolean = False
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT FACTURA FROM CFDI                             
                            WHERE FACTURA = '" & Fg(Fg.Row, 1) & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                EXIST_DOC = True
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try

                PassData1 = "FACTURA"
                If EXIST_DOC Then
                    IMPRIMIR_CFDI_40(Fg(Fg.Row, 1), "FACTURA")
                Else

                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT RFC FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & Fg(Fg.Row, 1) & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    RFC = dr("RFC")
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try

                    IMPRIMIR_CFDI_DIRECTO(Fg(Fg.Row, 1), "PDF", "", RFC)
                End If

            Else
                MsgBox("Por favor seleccione el documento a timbrar")
            End If

        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message)
        End Try


    End Sub

    Private Sub BarSendMail_Click(sender As Object, e As ClickEventArgs) Handles BarSendMail.Click
        Dim FILE_XML As String = "", PDF As String = ""
        Dim Err As Boolean = False
        Dim ENVIAR_MAIL As String = "", CORREO_CLIENTE As String = "", RAZON_SOCIAL As String = "", NOMBRE_CLIENTE As String = ""

        Try
            Var2 = Fg(Fg.Row, 1) 'CVE_DOC
            Var4 = ""
            Var5 = ""
            Var6 = Fg(Fg.Row, 3) 'NOMBRE_CLIENTE
            Var7 = Fg(Fg.Row, 7) 'RFC
            Var8 = ""
            Var9 = Fg(Fg.Row, 27) 'CORREO_CLIENTE
            Var10 = ""

            FrmCorreo.ShowDialog()

            If Var4 = "NO" Then
                Return
            End If
        Catch ex As Exception
            Err = True
            BITACORACFDI("360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If Err Then
            MsgBox("Problema detectado verifique las rutas por favor")
            Return
        End If

        Try
            Dim aCorreo As New ArrayList From {PDF, FILE_XML}
            Dim horaActual As String, SALUDO As String, MensaDia As String = ""

            Try
                horaActual = DateTime.Now.ToString("HH:mm")

                If horaActual >= "24:00" And horaActual <= "12:00" Then
                    SALUDO = "Buenos Días"
                ElseIf horaActual >= "12:01" And horaActual <= "19:00" Then
                    SALUDO = "Buenas Tardes"
                ElseIf horaActual >= "19:01" And horaActual <= "23:59" Then
                    SALUDO = "Buenas Noches"
                End If
                MensaDia = horaActual
            Catch ex As Exception
                BITACORACFDI("960. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If CORREO_CLIENTE.Trim.Length > 0 Or Var7.Trim.Length > 0 Or Var8.Trim.Length > 0 Or Var9.Trim.Length > 0 Or Var10.Trim.Length > 0 Then
                SendEmail(CORREO_CLIENTE, "CFDI Carta porte",
                        MensaDia & vbCrLf & vbCrLf &
                        "CFDI Carta porte " & CTA_PORT1 & vbCrLf &
                        "Adjunto se envia representación CFDI Carta porte en formato PDF" & vbCrLf & vbCrLf &
                         RAZON_SOCIAL,
                        aCorreo, Var7, Var8, Var9, Var10)

                MsgBox("Correo enviado")
            Else
                MsgBox("El cliente " & NOMBRE_CLIENTE & " no tiene correo capturado")
            End If
        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarDescargarXMLyPDF_Click(sender As Object, e As ClickEventArgs) Handles BarDescargarXMLyPDF.Click
        Try
            If Fg.Rows.Selected.Count > 0 Then
                Try
                    Dim r_ As Row
                    For k = 0 To Fg.Rows.Selected.Count - 1
                        r_ = Fg.Rows.Selected(k)

                        FrmDescargarXmlPDF.C1List1.AddItem(Fg(r_.Index, 1) & ";" & Fg(r_.Index, 4))
                    Next

                    Var4 = "FACTURAS"
                    FrmDescargarXmlPDF.ShowDialog()

                Catch ex As Exception
                    Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                MsgBox("Por favor seleccione al menos un documento")
            End If

        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImpresionMasiva_Click(sender As Object, e As ClickEventArgs) Handles BarImpresionMasiva.Click
        Try
            FrmFiltroReimpMasiva.ShowDialog()

        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
End Class
