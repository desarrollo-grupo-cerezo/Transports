Imports System.Xml
Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Command
Public Class FrmCartaPorteTraslado
    Dim CADENA As String
    Dim MULTIALMACEN As Integer
    Dim TIPO_VENTA_LOCAL As String '= TIPO_VENTA
    Dim TOP_REG As String
    Dim CARPORT As Boolean
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private OpenTea As Integer = -1

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmCartaPorteTraslado_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Sub CARGAR_DATOS1()
        Dim SERVIDOR_TEA As String = "", BASE_TEA As String = "", USUARIO_TEA As String = "", PASS_TEA As String = ""
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
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            SplitM1.Dock = DockStyle.Fill
            SplitM1.SplitterWidth = 1

            'BarraAbajo.Dock = DockStyle.None
            Dim SPOR1 As Decimal

            SPOR1 = (C1ToolBar1.Height / Me.Height) * 100
            Split1.SizeRatio = SPOR1 + 1

            SPOR1 = (BarraAbajo.Height / Me.Height) * 100
            Split3.SizeRatio = SPOR1

            Split2.SizeRatio = 100 - Split1.SizeRatio - SPOR1

            Fg.Dock = DockStyle.Fill
            'Fg.Rows.Count = 1 : Fg.Cols.Count = 8
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
            Fg.Rows(0).Height = 40
            Fg.Styles.Fixed.WordWrap = True

            'Fg(0, 0) = ""
            'Fg(0, 1) = "Folio TEA"
            'Fg(0, 2) = "Estatus timbrado"
            'Fg(0, 3) = "Sucursal Origen"
            'Fg(0, 4) = "Sucursal Destino"
            'Fg(0, 5) = "Fecha"
            'Fg(0, 6) = "Estatus envio"
            'Fg(0, 7) = "Almacen"
            'Fg.Cols(0).Width = 40 : Fg.Cols(1).Width = 120 : Fg.Cols(2).Width = 100 : Fg.Cols(3).Width = 170 : Fg.Cols(4).Width = 170
            'Fg.Cols(5).Width = 100 : Fg.Cols(6).Width = 90 : Fg.Cols(7).Width = 90
            'Fg.Width = Fg.Cols(0).Width + Fg.Cols(1).Width + Fg.Cols(2).Width + Fg.Cols(3).Width +
            'Fg.Cols(4).Width + Fg.Cols(5).Width + Fg.Cols(6).Width + Fg.Cols(7).Width + 30
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                SQL = "SELECT SERVIDOR, BASE, USUARIO, PASS FROM TEA"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SERVIDOR_TEA = dr("SERVIDOR")
                        BASE_TEA = dr("BASE")
                        USUARIO_TEA = dr("USUARIO")
                        PASS_TEA = dr("PASS")
                    End If
                End Using
            End Using
            If SERVIDOR_TEA.Trim.Length = 0 Or BASE_TEA.Trim.Length = 0 Or USUARIO_TEA.Trim.Length = 0 Or PASS_TEA.Trim.Length = 0 Then
                OpenTea = 0
            End If

            CADENA = ""

            DESPLEGAR()

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Fg.Redraw = False

        Try
            SQL = "SELECT " & TOP_REG & " F.CVE_DOC, F.CVE_CLPV, C.NOMBRE, 
                    CASE CFD.ESTATUS WHEN 'C' THEN 'Cancelada' ELSE 'Emitida' END AS ST, 
                    CASE WHEN ISNULL(ESTATUS,'N') = 'C' THEN 'CANCELADA' WHEN ISNULL(TIMBRADO,'N') = 'S' THEN 'TIMBRADA' WHEN ISNULL(TIMBRADO,'N') = 'N' THEN 'Pendiente' ELSE 'Cancelada' END AS FACT_CFDI, 
                    F.RFC, C.CODIGO, F.FECHA_DOC, F.CAN_TOT, F.IMP_TOT1, F.IMP_TOT2, F.IMP_TOT3, F.IMP_TOT4, F.IMPORTE, 
                    F.NUM_ALMA, F.FECHA_CANCELA, F.FECHAELAB, C.USO_CFDI, C.REG_FISC, FECHA_CARGA, FECHA_DESCARGA, KMS_RECORRIDOS, CVE_UNI, CONFIGVEHICULAR, PESOBRUTOTOTAL
                    FROM CFDI_CPT F
                    LEFT JOIN CFDI CFD ON CFD.FACTURA = F.CVE_DOC
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE  = F.CVE_CLPV " &
                    CADENA & " ORDER BY FECHAELAB DESC"

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

            Fg(0, 5) = "Documento digital"
            Dim c6 As Column = Fg.Cols(5)
            c6.DataType = GetType(String)

            Fg(0, 6) = "RFC"
            Dim c66 As Column = Fg.Cols(6)
            c66.DataType = GetType(String)

            Fg(0, 7) = "CP"
            Dim c67 As Column = Fg.Cols(7)
            c67.DataType = GetType(String)

            Fg(0, 8) = "Fecha"
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(DateTime)

            Fg(0, 9) = "Subtotal"
            Dim c11 As Column = Fg.Cols(9)
            c11.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "IEPS"
            Dim c12 As Column = Fg.Cols(10)
            c12.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Retención ISR"
            Dim c13 As Column = Fg.Cols(11)
            c13.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Retención IVA"
            Dim c14 As Column = Fg.Cols(12)
            c14.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "IVA"
            Dim c15 As Column = Fg.Cols(13)
            c15.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Importe"
            Dim c20 As Column = Fg.Cols(14)
            c20.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Almacen"
            Dim c18 As Column = Fg.Cols(15)
            c18.DataType = GetType(Int32)

            Fg(0, 16) = "Fecha cancelada"
            Dim c10 As Column = Fg.Cols(16)
            c10.DataType = GetType(DateTime)

            Fg(0, 17) = "Fecha elab."
            Dim c19 As Column = Fg.Cols(17)
            c19.DataType = GetType(DateTime)
            c19.Format = "G"

            Fg(0, 18) = "Uso cfdi"
            Dim c25 As Column = Fg.Cols(18)
            c25.DataType = GetType(String)

            Fg(0, 19) = "Regimen fiscal"
            Dim c26 As Column = Fg.Cols(19)
            c26.DataType = GetType(String)

            Fg(0, 20) = "Fecha de carga"
            Dim c28 As Column = Fg.Cols(20)
            c28.DataType = GetType(String)

            Fg(0, 21) = "Fecha de descarga"
            Dim c29 As Column = Fg.Cols(21)
            c29.DataType = GetType(String)

            Fg(0, 22) = "Kms. recorridos"
            Dim c30 As Column = Fg.Cols(22)
            c30.DataType = GetType(String)

            Fg(0, 23) = "Unidad"
            Dim c31 As Column = Fg.Cols(23)
            c31.DataType = GetType(String)

            Fg(0, 24) = "Configuración vehicular"
            Dim c32 As Column = Fg.Cols(24)
            c32.DataType = GetType(String)

            Fg(0, 25) = "Peso bruto total"
            Dim c33 As Column = Fg.Cols(25)
            c33.DataType = GetType(Decimal)
            Fg.Cols(25).Format = "###,###,##0.00"

            'FECHA_CARGA, FECHA_DESCARGA, KM_RECORRIDOS, CVE_UNI, CONFIGVEHICULAR, PESOGRUTOTOTAL
            'Fg.Cols(1).Width = 110 : Fg.Cols(2).Width = 50 : Fg.Cols(4).Width = 60 : Fg.Cols(5).Width = 100 : Fg.Cols(6).Width = 90 : Fg.Cols(7).Width = 70
            'Fg.Cols(8).Width = 70
            'Fg.Cols(9).Width = 70 : Fg.Cols(11).Width = 70 : Fg.Cols(12).Width = 70 : Fg.Cols(13).Width = 70 : Fg.Cols(14).Width = 70 : Fg.Cols(15).Width = 65
            'Fg.Cols(20).Width = 60
            Fg.Cols(4).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(5).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(6).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(7).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(8).TextAlign = TextAlignEnum.CenterCenter

            Fg.Cols(15).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(16).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(17).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(18).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(19).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(20).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(21).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(22).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(23).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(24).TextAlign = TextAlignEnum.CenterCenter

            'Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            'Fg.Subtotal(AggregateEnum.Clear)
            'Fg.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
            'Fg.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
            'Fg.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
            'Fg.Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
            'Fg.Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
            'Fg.Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")

            Fg.AutoSizeCols()

            Fg.Cols(19).Width = 50
            Fg.Cols(22).Width = 60
            Fg.Cols(24).Width = 80


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

    Sub DESPLEGAR_TEA()
        Dim s As String

        Fg.Redraw = False
        Me.Cursor = Cursors.WaitCursor

        SQL = "SELECT TOP 1000 MAX(succamion) AS folio_tea, ISNULL(MAX(pag),'') as timbrado, MAX(sucentrega) AS suce, MAX(sucsolicita) AS sucs, 
            MAX(f_entrega) as f_ent, MAX(f_recepcion) as f_rec, MAX(alm1) as num_alm, SUM(estatus) AS st
            FROM movs 
            WHERE isnull(cancelado,'N') = 'N'
            GROUP BY serie, folio ORDER BY max(f_entrega) DESC"
        Try
            Using cmd As SqlCommand = cnSQL.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        s = dr("folio_tea") & vbTab '1
                        s &= dr("timbrado") & vbTab '2
                        s &= dr("suce") & vbTab     '3
                        s &= dr("sucs") & vbTab     '4
                        s &= dr("f_ent") & vbTab    '5
                        s &= IIf(dr("st") > 0, "Enviado", "") & vbTab      '6
                        s &= dr("num_alm") & vbTab  '7

                        Fg.AddItem("" & vbTab & s)
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Private Sub FrmCartaPorteTraslado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Cartas porte  traslado")
            cnSQL.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click

        Try
            Var2 = "Nuevo"
            Var12 = ""

            CREA_TAB(FrmCartaPorteTrasladoAE, "Carta porte traslado")
        Catch ex As Exception
            MsgBox("325. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("325. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then
                Var2 = "Edit"
                Var12 = Fg(Fg.Row, 1)

                CREA_TAB(FrmCartaPorteTrasladoAE, "Carta porte traslado")
            End If
        Catch ex As Exception
            MsgBox("325. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("325. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarEdit_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("325. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("325. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        CADENA = ""
        TOP_REG = " TOP 500 "
        DESPLEGAR()
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

                    Var4 = "CARTA PORTE TRASLADO" '"FACTURAS"
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

        PassData1 = "CARTA PORTE TRASLADO"

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
    Private Sub BarImpresionMasiva_Click(sender As Object, e As ClickEventArgs) Handles BarImpresionMasiva.Click
        Try
            FrmFiltroReimpMasiva.ShowDialog()

        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            If Fg.Row > 0 Then
                IMPRIMIR_CFDI_40(Fg(Fg.Row, 1), "CARTA PORTE TRASLADO")
            Else
                MsgBox("Por favor seleccione el documento a timbrar")
            End If

        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
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
                    Fg.SetCellStyle(e.Row, 5, cs2)
            End Select

            Select Case Fg(e.Row, 5)
                Case "Pendiente"
                    Fg.SetCellStyle(e.Row, 5, cs1)
                Case "Cancelada"
                    Fg.SetCellStyle(e.Row, 5, cs2)
                Case "TIMBRADA"
                    Fg.SetCellStyle(e.Row, 5, cs3)
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
                If MsgBox("Realmente desea timbrar el documento " & Fg(Fg.Row, 1) & "?", vbYesNo) = vbYes Then

                    PassData1 = "CARTA PORTE TRASLADO"
                    Var4 = Fg(Fg.Row, 1)
                    CVE_DOC = Fg(Fg.Row, 1)
                    Var5 = Fg(Fg.Row, 27)  'CORREO
                    Var18 = ""
                    Var16 = ""
                    'Fg(0, 25) = "Uso cfdi"
                    'Fg(0, 26) = "Regimen fiscal"
                    'Fg(0, 27) = "Correo"
                    ' INICA PROCESO DE TIMBRAR 

                    FrmTimbrarCdeP.LtNombre.Text = Fg(Fg.Row, 3)
                    FrmTimbrarCdeP.LtRFC.Text = Fg(Fg.Row, 6)
                    FrmTimbrarCdeP.LtUSO_CFDI.Text = Fg(Fg.Row, 18)
                    FrmTimbrarCdeP.LtRegimenReceptor.Text = Fg(Fg.Row, 19)
                    FrmTimbrarCdeP.LtCP.Text = Fg(Fg.Row, 7)

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
            MsgBox("12. " & ex.Message)
        End Try
    End Sub

    Private Sub btnDesplegar_Click(sender As Object, e As EventArgs) Handles btnDesplegar.Click
        Try
            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarDiseñador_Click(sender As Object, e As ClickEventArgs) Handles BarDiseñador.Click
        PrinterMRT("ReportCFDICPT", "CFDI Carta porte traslado")
    End Sub
End Class
