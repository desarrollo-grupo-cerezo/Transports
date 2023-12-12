Imports System.IO
Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmDocumentos
    Dim CADENA As String
    Dim MULTIALMACEN As Integer
    Dim TIPO_VENTA_LOCAL As String
    Dim TOP_REG As String
    Dim CARPORT As Boolean
    Private ReadOnly BindingSource1 As New BindingSource
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
    End Sub
    Sub CARGAR_DATOS1()
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
                    LkEdit.Text = "Consultar"
                Case "V"
                    LtCompras.Text = "Nota de venta"
                    LkEdit.Text = "Consultar"
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

            CARGA_PARAM_INVENT()

            Fg.Rows.Count = 2
            Fg.Rows(0).Height = 40
            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - 100
            Fg.Dock = DockStyle.Fill

            CADENA = "" '" WHERE FECHA_DOC = '" & FSQL(Date.Now) & "'"
            TOP_REG = " TOP 500 "

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DERECHOS()
        Dim z As Integer

        If pwPoder Then
            Try
                BarNuevo.Visible = True
                BarEdit.Visible = True
                BarExcel.Visible = True
            Catch ex As Exception
            End Try
        Else
            Try
                BarNuevo.Visible = False
                BarEdit.Visible = False
                BarExcel.Visible = False
            Catch ex As Exception
            End Try
            Try
                Select Case TIPO_VENTA_LOCAL
                    Case "F"
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE > 60100 AND CLAVE < 70000"
                    Case "R"
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE > 60500 AND CLAVE < 66000"
                    Case "C"
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE > 60100 AND CLAVE < 60200"
                End Select

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case TIPO_VENTA_LOCAL
                                Case "C"
                                    Select Case dr("CLAVE")
                                        Case 60101
                                            BarNuevo.Visible = True
                                        Case 60130
                                            BarEdit.Visible = True
                                        Case 60160
                                            BarExcel.Visible = True
                                    End Select
                                Case "R"
                                    Select Case dr("CLAVE")
                                        Case 60501
                                            BarNuevo.Visible = True
                                        Case 60530
                                            BarEdit.Visible = True
                                        Case 60560
                                            BarExcel.Visible = True
                                    End Select
                            End Select

                            z += 1
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
        Dim CADENA_CAP As String

        Try
            If CARPORT Then
                If CADENA.Trim.Length = 0 Then
                    CADENA = "WHERE CVE_PEDI = 'CARTA PORTE'"
                Else
                    CADENA &= " AND CVE_PEDI = 'CARTA PORTE'"
                End If
                CADENA_CAP = "ISNULL(STUFF((SELECT ' ' + CVE_FOLIO + '  ' FROM GCCARTA_PORTE S WHERE S.CVE_DOCR = C.CVE_DOC FOR XML PATH ('')),1,1, ''),'') AS 'Carta porte', "
            Else
                If TIPO_VENTA_LOCAL.ToUpper = "V" Then
                    CADENA = ""
                Else
                    If CADENA.Trim.Length = 0 Then
                        CADENA = "WHERE CVE_PEDI <> 'CARTA PORTE'"
                    Else
                        CADENA &= " AND CVE_PEDI <> 'CARTA PORTE'"
                    End If
                End If

                CADENA_CAP = "CVE_PEDI, "
            End If

            If TIPO_VENTA_LOCAL = "D" Then

                CADENA = ""

                SQL = "SELECT " & TOP_REG & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, 
                    CASE C.STATUS WHEN 'E' THEN 'Emitida' WHEN 'O' THEN 'Emitida' WHEN 'C' THEN 'Cancelada' END AS ST, CVE_PEDI,
                    (SELECT TOP 1 CASE WHEN ISNULL(TIMBRADO,'') = 'S' THEN 'Pendiente' WHEN ISNULL(TIMBRADO,'') = 'N' THEN 'Timbrada' ELSE '' END 
                    FROM CFDI_COM_PAGO FD WHERE TDOC = 'NC' AND DOCUMENTO = C.CVE_DOC) AS 'Factura digital',
                    C.FECHA_DOC, C.FECHA_ENT, C.FECHA_VEN, C.FECHA_CANCELA, C.CAN_TOT, C.IMP_TOT1, C.IMP_TOT2,
                    C.IMP_TOT3, C.IMP_TOT4, C.IMPORTE, C.DES_TOT, C.DES_FIN, C.NUM_ALMA, C.FECHAELAB, ISNULL(C.DOC_ANT,'') AS D_ANT
                    FROM FACT" & TIPO_VENTA_LOCAL.ToUpper & Empresa & " C                
                    LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV
                    LEFT JOIN FACT" & TIPO_VENTA_LOCAL.ToUpper & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = C.CVE_DOC " &
                    CADENA & " ORDER BY FECHAELAB DESC"
            Else
                SQL = "SELECT " & TOP_REG & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, 
                    CASE C.STATUS WHEN 'E' THEN 'Emitida' WHEN 'O' THEN 'Emitida' WHEN 'C' THEN 'Cancelada' END AS ST, " & CADENA_CAP &
                    "ISNULL(C.DOC_SIG,'') AS D_SIG, C.FECHA_DOC, C.FECHA_ENT, C.FECHA_VEN, C.FECHA_CANCELA, C.CAN_TOT, C.IMP_TOT1, C.IMP_TOT2,
                    C.IMP_TOT3, C.IMP_TOT4, C.IMPORTE, C.DES_TOT, C.DES_FIN, C.NUM_ALMA, C.FECHAELAB, ISNULL(C.DOC_ANT,'') AS D_ANT
                    FROM FACT" & TIPO_VENTA_LOCAL.ToUpper & Empresa & " C
                    LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV
                    LEFT JOIN FACT" & TIPO_VENTA_LOCAL.ToUpper & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = C.CVE_DOC " &
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

            If TIPO_VENTA_LOCAL = "D" Or TIPO_VENTA_LOCAL = "V" Then
                Fg(0, 5) = "cve. pedido"
            Else
                Fg(0, 5) = "Referencia carta porte"
            End If
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            If TIPO_VENTA_LOCAL = "D" Then
                Fg(0, 6) = "Documento digital"
            Else
                Fg(0, 6) = "Orden de trabajo"
            End If

            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Fecha"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(DateTime)

            Fg(0, 8) = "Fecha rec."
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(DateTime)

            Fg(0, 9) = "Fecha pag."
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(DateTime)

            Fg(0, 10) = "Fecha cancelada"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(DateTime)

            Fg(0, 11) = "Subtotal"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "IEPS"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Retención ISR"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 14) = "Retención IVA"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "IVA"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Importe"
            Dim c20 As Column = Fg.Cols(16)
            c20.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "Descuento"
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "Des. fin."
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(Decimal)
            Fg.Cols(18).Format = "###,###,##0.00"

            Fg(0, 19) = "Almacen"
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(Int32)

            Fg(0, 20) = "Fecha elab."
            Dim c19 As Column = Fg.Cols(20)
            c19.DataType = GetType(DateTime)
            c19.Format = "G"

            Fg(0, 21) = "Documento anterior"
            Dim c21 As Column = Fg.Cols(21)
            c21.DataType = GetType(String)

            Fg.Cols(1).Width = 110 : Fg.Cols(2).Width = 50 : Fg.Cols(4).Width = 60 : Fg.Cols(5).Width = 100 : Fg.Cols(6).Width = 90 : Fg.Cols(7).Width = 70 : Fg.Cols(8).Width = 70
            Fg.Cols(9).Width = 70 : Fg.Cols(11).Width = 70 : Fg.Cols(12).Width = 70 : Fg.Cols(13).Width = 70 : Fg.Cols(14).Width = 70 : Fg.Cols(15).Width = 65
            Fg.Cols(16).Width = 40 : Fg.Cols(17).Width = 40 : Fg.Cols(18).Width = 90
            Fg.Cols(20).Width = 60 ': Fg.Cols(21).Width = 80 : Fg.Cols(22).Width = 60 : Fg.Cols(23).Width = 80
            Fg.Cols(5).TextAlign = TextAlignEnum.LeftCenter

            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            Fg.Subtotal(AggregateEnum.Clear)
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 16, "Grand Total")

            Fg.AutoSizeCols()

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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
    Private Sub FrmDocumentos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Documentos")
            Me.Dispose()
        Catch ex As Exception
            MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub REFRESCAR()
        Try
            CADENA = ""
            TOP_REG = " TOP 2500 "
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
            PassData8 = "DOCUMENTOS"
            CREA_TAB(FrmTPV, "Fr")
        Catch ex As Exception
            Bitacora("75. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        CADENA = ""
        TOP_REG = " TOP 2500 "
        DESPLEGAR()
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then

                Var11 = "edit"
                Var12 = Fg(Fg.Row, 1)
                Var16 = Fg(Fg.Row, 21)
                PassData8 = "DOCUMENTOS"

                Var18 = ""
                If TIPO_VENTA_LOCAL = "D" Then
                    Var18 = Fg(Fg.Row, 6)
                End If

                CREA_TAB(FrmTPV, "Punto de venta")
            End If
        Catch ex As Exception
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEnviarcorreo_Click(sender As Object, e As ClickEventArgs)
        Dim XML As String = "", FILE_XML As String = "", CVE_DOC As String, PDF As String = ""
        Dim CALLE_DESTINO As String, NUMEROEXTERIOR_DESTINO As String, COLONIA_DESTINO As String, Err As Boolean = False
        Dim LOCALIDAD_DESTINO As String, CODIGOPOSTAL_DESTINO As String, ESTADO_DESTINO As String, MUNICIPIO_DESTINO As String
        Dim ENVIAR_MAIL As String = "", CORREO_CLIENTE As String = "", RAZON_SOCIAL As String = "", NOMBRE_CLIENTE As String = ""

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        PassData6 = dr("CALLE") & ", Num. ext. " & dr("NUMEXT") & ", CP " & dr("CP")
                        RAZON_SOCIAL = dr("EMISOR_RAZON_SOCIAL")

                        If CP_IMPRIME_IMPORTES Then
                            'CON PRECIOS CARAJO
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO_CONPRECIOS")
                        Else
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO")
                        End If

                        gRutaCertificado = dr("FILE_CER") 'CERTIFICADO
                        gRutaPFX = dr("FILE_PFX").ToString '.KEY
                        gContraPFX = dr("PASS_PFX").ToString  'contrasena del certificado
                    End If
                End Using
            End Using
        Catch ex As Exception
            Err = True
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Err Then
            MsgBox("Problema detectado verifique las rutas por favor")
            Return
        End If

        Try
            CVE_DOC = Fg(Fg.Row, 2)
            Try
                SQL = "SELECT TDOC, DOCUMENT, DOCUMENT2, XML, FILE_XML FROM CFDI WHERE FACTURA = '" & CVE_DOC & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            XML = dr("XML")
                            CTA_PORT1 = dr("DOCUMENT")
                            CTA_PORT2 = dr("DOCUMENT2")
                        End If
                    End Using
                End Using

                Try
                    SQL = "SELECT C.CVE_DOCR, C.CLIENTE, C.CVE_TRACTOR, C.CVE_TANQUE1, C.CVE_TANQUE2, C.CVE_DOLLY, C.RECOGER_EN, C.ENTREGAR_EN, 
                        CVE_DOCP, C.ORDEN_DE, C.EMBARQUE, ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TRACTOR, ISNULL(U2.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE1,
                        ISNULL(U2.SUBTIPOREM,'') AS SUTIREM1, ISNULL(U3.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE2, ISNULL(U3.SUBTIPOREM,'') AS SUTIREM2,
                        ISNULL(U.ANO_MODELO,'') AS ANO_MOD, A.POLIZARESPCIVIL, A.ASEGURARESPCIVIL, C.CVE_ART, ISNULL(P.DESCR,'') AS DESCR_MAT, 
                        ISNULL(CAMPLIB1,'') AS LIB1, ISNULL(PEDIMENTO,'') AS CP_PEDIMENTO, ISNULL(C.OBSER_CFDI,'') AS OBS_CFDI, 
                        R1.DESCR AS DESCR_RECOGER_EN, R2.DESCR AS DESCR_ENTREGAR_EN, SC.NOMBRE, SC.CALLE, SC.NUMEXT, SC.COLONIA, SC.LOCALIDAD, SC.MUNICIPIO, SC.CODIGO,
                        SC.ESTADO, ISNULL(SC.MAIL,'') AS ENVIAR_CORREO, ISNULL(SC.EMAILPRED,'') AS CORREO
                        FROM GCCARTA_PORTE C 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R1 ON R1.CVE_REG = C.RECOGER_EN
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R2 ON R2.CVE_REG = C.ENTREGAR_EN
                        LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = C.CVE_TRACTOR
                        LEFT JOIN GCUNIDADES U2 ON U2.CLAVEMONTE = C.CVE_TANQUE1
                        LEFT JOIN GCUNIDADES U3 ON U3.CLAVEMONTE = C.CVE_TANQUE2
                        LEFT JOIN GCASEGURADORAS A ON A.CLAVE = U.SE_ASEGURADORA
                        LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = CAST(C.CVE_ART AS INT)
                        LEFT JOIN CLIE" & Empresa & " SC ON SC.CLAVE =  C.CLIENTE
                        LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE =  SC.CLAVE
                        WHERE CVE_FOLIO = '" & CTA_PORT1 & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                CP_ORDEN_DE = dr.ReadNullAsEmptyString("ORDEN_DE")
                                CP_EMBARQUE = dr.ReadNullAsEmptyString("EMBARQUE")

                                CP_RECOGER_EN = dr.ReadNullAsEmptyString("DESCR_RECOGER_EN")
                                CP_ENTREGAR_EN = dr.ReadNullAsEmptyString("DESCR_ENTREGAR_EN")

                                CP_TRACTOR = dr.ReadNullAsEmptyString("CVE_TRACTOR")
                                CP_TANQUE1 = dr.ReadNullAsEmptyString("CVE_TANQUE1")
                                CP_TANQUE2 = dr.ReadNullAsEmptyString("CVE_TANQUE2")
                                CP_PLACAS_TRACTOR = dr.ReadNullAsEmptyString("PLACAS_MEX_TRACTOR")
                                CP_PLACAS_TANQUE1 = dr.ReadNullAsEmptyString("PLACAS_MEX_TANQUE1")
                                CP_PLACAS_TANQUE2 = dr.ReadNullAsEmptyString("PLACAS_MEX_TANQUE2")

                                CP_POLIZARESPCIVIL = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
                                CP_ASEGURARESPCIVIL = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")
                                CP_NUM_PROV = dr.ReadNullAsEmptyString("LIB1")
                                CP_PEDIMENTO = dr.ReadNullAsEmptyString("CP_PEDIMENTO")
                                If CP_PEDIMENTO = "0" Then CP_PEDIMENTO = ""
                                CP_OBSER_CFDI = dr.ReadNullAsEmptyString("OBS_CFDI")

                                CALLE_DESTINO = dr.ReadNullAsEmptyString("CALLE")
                                NUMEROEXTERIOR_DESTINO = dr.ReadNullAsEmptyString("NUMEXT")
                                COLONIA_DESTINO = dr.ReadNullAsEmptyString("COLONIA")
                                LOCALIDAD_DESTINO = dr.ReadNullAsEmptyString("LOCALIDAD")
                                CODIGOPOSTAL_DESTINO = dr.ReadNullAsEmptyString("CODIGO")
                                ESTADO_DESTINO = dr.ReadNullAsEmptyString("ESTADO")
                                MUNICIPIO_DESTINO = dr.ReadNullAsEmptyString("MUNICIPIO")


                                PassData7 = CALLE_DESTINO
                                If NUMEROEXTERIOR_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Num. ext. " & NUMEROEXTERIOR_DESTINO
                                End If
                                If CODIGOPOSTAL_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", CP " & CODIGOPOSTAL_DESTINO
                                End If
                                If COLONIA_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Colonia " & COLONIA_DESTINO
                                End If
                                If LOCALIDAD_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Localidad " & LOCALIDAD_DESTINO
                                End If
                                If MUNICIPIO_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Municipio " & MUNICIPIO_DESTINO
                                End If
                                If ESTADO_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Estado " & ESTADO_DESTINO
                                End If

                                ENVIAR_MAIL = dr("ENVIAR_CORREO")
                                CORREO_CLIENTE = dr("CORREO")
                                NOMBRE_CLIENTE = "(" & dr("CLIENTE") & ") " & dr.ReadNullAsEmptyString("NOMBRE")
                            Else
                                CP_ORDEN_DE = "" : CP_EMBARQUE = "" : CP_RECOGER_EN = "" : CP_ENTREGAR_EN = "" : CP_TRACTOR = "" : CP_TANQUE1 = ""
                                CP_TANQUE2 = "" : CP_PLACAS_TRACTOR = "" : CP_PLACAS_TANQUE1 = "" : CP_PLACAS_TANQUE2 = ""
                                CP_POLIZARESPCIVIL = "" : CP_ASEGURARESPCIVIL = "" : CP_NUM_PROV = "" : CP_PEDIMENTO = "" : CP_OBSER_CFDI = ""
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Err = True
                    BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("12. " & ex.Message)
                End Try
                If Err Then
                    MsgBox("Problema detectado verifique las rutas por favor")
                    Return
                End If

                Var4 = ""
                Var5 = CORREO_CLIENTE
                Var6 = NOMBRE_CLIENTE
                Var7 = ""
                Var8 = ""
                Var9 = ""
                Var10 = ""

                FrmCorreo.ShowDialog()

                If Var4 = "NO" Then
                    Return
                End If

                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT * FROM CFDI_CFG"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then

                                CP_PERMSCT = dr.ReadNullAsEmptyString("PERMSCT")
                                CP_NUMPERMISOSCT = dr.ReadNullAsEmptyString("NUMPERMISOSCT")

                                CP_POLIZAMEDAMBIENTE = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
                                CP_ASEGURAMEDAMBIENTE = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
                    Err = True

                End Try
                If Err Then
                    MsgBox("Problema detectado verifique las rutas por favor")
                    Return
                End If

                FILE_XML = gRutaXML_TIMBRADO & "\" & CTA_PORT1 & "-" & CVE_DOC & ".xml"
                Dim rutaPDF As String = gRutaXML_TIMBRADO & "\" & CTA_PORT1 & "-" & CVE_DOC & ".pdf"

                PDF = rutaPDF

                File.WriteAllText(FILE_XML, XML)
                '                                   String.Empty
                CreaPDF.Generar(FILE_XML, rutaPDF, Application.StartupPath & "\logo.jpg", False)
                'Process.Start(rutaPDF)

            Catch ex As Exception
                Err = True
                BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & FILE_XML & vbNewLine & "PDF:" & PDF)
            End Try
            If Err Then
                MsgBox("Problema detectado verifique las rutas por favor")
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

    Private Sub BarEstatusCFDI_Click(sender As Object, e As ClickEventArgs)

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "DOCUMENTOS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
