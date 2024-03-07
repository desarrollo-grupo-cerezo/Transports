Imports System.IO
Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports System.Xml

Public Class FrmDocumentos
    Private _c As Comprobante

    Private FTP_CFDI_DEV As String = ""
    Private gUSUARIO_PAC As String
    Private gPASS_PAC As String
    Private MOSTRAR_LP_PV As Integer
    Private LISTA_PREC_CLIE As String
    Private SEBLOQUEA As String = "N"
    Private MONEDA As String
    Private TIPOCAMBIO As Decimal
    Private VALIDAR_EXIST_PED As String
    Private USO_CFDI As String
    Private REG_FISC As String
    Private METODODEPAGO As String
    Private FORMAPAGO As String

    Private DOCUMENT_ENLAZADO As String = ""
    Private TIMBRADO_DEMO As String = "No"
    Private EMISORRFC As String = ""
    Private CVE_ART_NC As String = ""
    Private NUM_CPTO_NC As Integer

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
                    LtCompras.Text = "Notas de Crédito"
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
                SQL = "SELECT " & TOP_REG & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, CASE C.STATUS WHEN 'E' THEN 'Emitida' WHEN 'O' THEN 'Emitida' WHEN 'C' THEN 'Cancelada' END AS ST, CVE_PEDI, 
                    (CASE WHEN ISNULL(ESCFD,'') = 'T' or ISNULL(ESCFD,'') = 'S' THEN 'Timbrada' WHEN ISNULL(ESCFD,'') = 'C' THEN 'Cancelada' WHEN ISNULL(ESCFD,'') = 'N' THEN 'Pendiente' ELSE '' END) AS 'Factura digital', 
                    C.FECHA_DOC, C.FECHA_ENT, C.FECHA_VEN, C.FECHA_CANCELA, C.CAN_TOT, C.IMP_TOT1, C.IMP_TOT2, C.IMP_TOT3, C.IMP_TOT4, C.IMPORTE, C.DES_TOT, C.DES_FIN, 
                    C.NUM_ALMA, C.FECHAELAB, ISNULL(C.DOC_ANT,'') AS D_ANT
                    FROM FACT" & TIPO_VENTA_LOCAL.ToUpper & Empresa & " C                
                    LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV
                    LEFT JOIN FACT" & TIPO_VENTA_LOCAL.ToUpper & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = C.CVE_DOC " & CADENA & " 
                    ORDER BY FECHAELAB DESC"
            Else
                SQL = "SELECT " & TOP_REG & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, CASE C.STATUS WHEN 'E' THEN 'Emitida' WHEN 'O' THEN 'Emitida' WHEN 'C' THEN 'Cancelada' END AS ST, " &
                    CADENA_CAP & "ISNULL(C.DOC_SIG,'') AS D_SIG, C.FECHA_DOC, C.FECHA_ENT, C.FECHA_VEN, C.FECHA_CANCELA, C.CAN_TOT, C.IMP_TOT1, C.IMP_TOT2, C.IMP_TOT3, C.IMP_TOT4, 
                    C.IMPORTE, C.DES_TOT, C.DES_FIN, C.NUM_ALMA, C.FECHAELAB, ISNULL(C.DOC_ANT,'') AS D_ANT
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
                    If IsNothing(Fg(Fg.Row, 6)) OrElse IsDBNull(Fg(Fg.Row, 6)) Then
                        Var18 = ""
                    Else
                        Var18 = Fg(Fg.Row, 6)
                    End If
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

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            If TIPO_VENTA_LOCAL = "D" And Fg(Fg.Row, 6) = "Timbrada" Then

                PassData1 = "CFDI Nota de crédito"
                IMPRIMIR_CFDI_40(Fg(Fg.Row, 1), "NOTA DE CREDITO")
            Else
                GEN_IMPRIMIR_TICKET(TIPO_VENTA_LOCAL, LETRA_VENTA, Fg(Fg.Row, 1), "FrmTPV", CDec(Fg(Fg.Row, 16)))
            End If

        Catch ex As Exception
            BITACORATPV("210. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("210. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTimbrar_Click(sender As Object, e As ClickEventArgs) Handles BarTimbrar.Click
        Dim CLAVE As String, RFC As String
        Dim d1 As DateTime = F1.Value
        Dim FECHA_CERT As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")


        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT F.CAN_TOT, F.IMP_TOT1, F.IMP_TOT2, F.IMP_TOT3, F.IMP_TOT4, F.IMPORTE, CVE_CLPV, C.NOMBRE,
                    C.RFC, CODIGO, REG_FISC, M.CVE_MONED AS MONEDA, ISNULL(TIPCAMB,0) AS TCAMB, F.USO_CFDI, F.METODODEPAGO, F.FORMADEPAGOSAT AS FORMAPAGO
                    FROM FACTD" & Empresa & " F 
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CVE_CLPV
                    LEFT JOIN MONED" & Empresa & " M ON M.NUM_MONED = F.NUM_MONED
                    WHERE CVE_DOC = '" & Fg(Fg.Row, 1) & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        CLAVE = dr("CVE_CLPV")
                        RFC = dr("RFC")
                        CP_ASEGURAMEDAMBIENTE = dr("CODIGO")
                        REG_FISC = dr("REG_FISC")
                        USO_CFDI = dr("USO_CFDI")
                        MONEDA = dr("MONEDA")
                        TIPOCAMBIO = dr("TCAMB")
                        If TIPOCAMBIO = 0 Then TIPOCAMBIO = 1
                        METODODEPAGO = dr("METODODEPAGO")

                        FORMAPAGO = dr("FORMAPAGO")

                        TimbrarDigiBoxNC(Fg(Fg.Row, 1), "", dr("CAN_TOT"), dr("IMP_TOT1"), dr("IMP_TOT2"), dr("IMP_TOT3"), dr("IMP_TOT4"),
                                         dr("IMPORTE"), CLAVE, dr("NOMBRE"), FECHA_CERT, RFC, dr("CODIGO"), TIPOCAMBIO)
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub TimbrarDigiBoxNC(FCVE_DOC As String, FDOC_ENLAZADO As String, FCAN_TOT As Decimal, FIMP_TOT1 As Decimal,
                                 FIMP_TOT2 As Decimal, FIMP_TOT3 As Decimal, FIMP_TOT4 As Decimal, FIMPORTE As Decimal,
                                 FCLIENTE As String, FNOMBRE As String, BFECHA As String, BRFC_CTE As String, BCP_CTE As String, FTIPOCAMBIO As Decimal)

        Dim USUAARIO_TIMB As String, PASS_TIMB As String, TimbreOK As Boolean = False
        Dim DETEC_ERROR_VIOLATION_KEY As Boolean, UUID_TIMBRADO As String
        Dim FECHA_T1 As DateTime
        Dim d1 As DateTime = F1.Value
        Dim FECHA_T2 As String '= d1.ToString("yyyy/MM/ddTHH:mm:ss")

        Dim SerieT As String = ""
        Dim FolioT As Long = 0
        Dim FOLIOI As String = ""

        If Fg(Fg.Row, 6) = "Timbrada" Then
            MsgBox("Documento ya timbrado verifique por favor")
            Return
        End If

        Using frmSerie As FrmSelSerieTimbrado = New FrmSelSerieTimbrado()
            frmSerie.TipoDocumento = "D"
            If frmSerie.ShowDialog() <> DialogResult.OK Then
                Return
            End If
            SerieT = frmSerie.SerieTimbrado
        End Using

        Me.Cursor = Cursors.WaitCursor

        _c = New Comprobante()


        LETRA_VENTA = GET_ONLY_LETTER(FCVE_DOC)
        FOLIO_VENTA = GetNumeric(FCVE_DOC)

        GET_PARAM_CFDI("E", BFECHA, LETRA_VENTA, FOLIO_VENTA, REG_FISC, USO_CFDI, MONEDA, METODODEPAGO, FORMAPAGO, FNOMBRE, BRFC_CTE, BCP_CTE, FTIPOCAMBIO)

        If Not CARGAR_CONCEPTOS_NC(FCVE_DOC) Then
            MsgBox("No se encontraron partidas verifique por favor")
            Return
        End If

        FolioT = ObtieneFolioTimbrado("D", SerieT, FCVE_DOC)
        If FolioT < 1 Then
            MsgBox("No existen configuradas series para Timbrado")
            Return
        End If

        FOLIOI = SerieT & FolioT

        _c.Serie = SerieT
        _c.Folio = FolioT.ToString()

        AGREGA_CFDIRELACIONADOS(FCVE_DOC)

        Try
            Dim aCORREOS(0) As String
            Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\" & EMISORRFC & "_NC_" & FOLIOI & ".xml"
            Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\" & EMISORRFC & "_NC_" & FOLIOI & ".xml"
            Dim rutaPFX As String = gRutaPFX
            Dim rutaCertificado As String = gRutaCertificado
            Dim rutaPDF As String = gRutaXML_TIMBRADO & "\" & EMISORRFC & "_NC_" & FOLIOI & ".pdf"
            Dim errorC As CError = _c.EsInfoCorrecta()

            If TIMBRADO_DEMO = "Si" Then
                USUAARIO_TIMB = "demo2"
                PASS_TIMB = "123456789"
            Else
                USUAARIO_TIMB = gUSUARIO_PAC
                PASS_TIMB = gPASS_PAC
            End If
            Var8 = ""
            Try
                If File.Exists(RutaXML_NO_TIMBRADO) = True Then
                    File.Delete(RutaXML_NO_TIMBRADO)
                End If
                If File.Exists(RutaXML_TIMBRADO) = True Then
                    File.Delete(RutaXML_TIMBRADO)
                End If
                If File.Exists(rutaPDF) = True Then
                    File.Delete(rutaPDF)
                End If


                'Dim userDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                'Dim fullPath = Path.Combine(userDesktop, RutaXML_NO_TIMBRADO)

                If Not Directory.Exists(gRutaXML_TIMBRADO) Then
                    Directory.CreateDirectory(gRutaXML_TIMBRADO)
                End If

            Catch ex As Exception
            End Try

            If Not File.Exists(rutaPFX) Then
                MsgBox("No se logro cargar el archivo key " & rutaPFX & ", verifique por favor")
                Return
            End If

            If Not File.Exists(rutaCertificado) Then
                MsgBox("No se logro cargar el certificado " & rutaCertificado & ", verifique por favor")
                Return
            End If

            Var46 = "NOCERTIFICADO"


            Dim xml As XmlDocument = GenerarXML.ObtenerXML(_c, rutaPFX, gContraPFX, rutaCertificado)
            xml.Save(RutaXML_NO_TIMBRADO)

            If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUAARIO_TIMB, PASS_TIMB) Then
                TimbreOK = True

                Var7 = "" : Var8 = "" : Var9 = "" : Var10 = "" : Var11 = "" : Var12 = "" : Var13 = "" : Var14 = "" : Var15 = ""
                UUID_TIMBRADO = BUSCAR_CAMPOS_CFDI40(RutaXML_TIMBRADO)
                Try
                    Var7 = Var10.Substring(8, 2) & "/" & Var10.Substring(5, 2) & "/" & Var10.Substring(0, 4) & " " & Var10.Substring(11, Var10.Length - 11)
                    Var8 = Var10.Substring(0, 4) & Var10.Substring(5, 2) & Var10.Substring(8, 2) & " " & Var10.Substring(11, Var10.Length - 11)
                    Dim oDate1 As DateTime = DateTime.ParseExact(Var7, "dd/MM/yyyy HH:mm:ss", Nothing)

                    FECHA_T1 = oDate1
                    FECHA_T2 = Var8

                Catch ex As Exception
                    MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                    BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try

                If Var10.Trim.Length < 10 Then
                    FECHA_T2 = d1.ToString("yyyy/MM/ddTHH:mm:ss")
                End If
                'Var9 = NO_CERTIFICADO
                'Var10 = FECHA_TIMBRADO
                'Var11 = FECHA_EXP
                'Var12 = SELLO_SAT
                'Var13 = NO_CERTIFICADO_SAT
                'Var14 = SELLO_CFD
                'Var15 = RfcProvCertif

                If Not Valida_Conexion() Then
                End If


                SQL = "INSERT INTO CFDI (FACTURA, TDOC, DOCUMENT, DOCUMENT2, VERSION, SERIE, FECHA_CERT, XML, TIMBRADO, USUARIO, 
                        CLIENTE,SUBTOTAL, RETENCION, IVA, IMPORTE, USO_CFDI, MONEDA, METODODEPAGO, FORMADEPAGOSAT, FECHAELAB, UUID, 
                        NO_CERTIFICADO, SELLO_SAT, SELLO_CFD, NO_CERTIFICADO_SAT, RFCPROVCERTIF, UUID_CFDI, FECHA_TIMBRADO, FECHA_CFDI, FOLIOI) 
                        VALUES (
                        @FACTURA, @TDOC, @DOCUMENT, @DOCUMENT2, @VERSION, @SERIE, @FECHA_CERT, @XML, @TIMBRADO, @USUARIO, @CLIENTE,
                        @SUBTOTAL, @RETENCION, @IVA, @IMPORTE, @USO_CFDI, @MONEDA, @METODODEPAGO, @FORMADEPAGOSAT, GETDATE(), NEWID(), 
                        @NO_CERTIFICADO, @SELLO_SAT, @SELLO_CFD, @NO_CERTIFICADO_SAT, @RFCPROVCERTIF, @UUID_CFDI, @FECHA_TIMBRADO, @FECHA_CFDI, @FOLIOI)"

                For k = 1 To 5
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = FCVE_DOC
                            cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "D"
                            cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = "@"
                            cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = "@"
                            cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "4.0"
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = LETRA_VENTA
                            cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = Var10
                            cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = CFDI_XML_DIGIBOX
                            cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "S"
                            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = FCLIENTE
                            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(FCAN_TOT, 6)
                            cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = Math.Round(FIMP_TOT3, 6)
                            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(FIMP_TOT4, 6)
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(FIMPORTE, 6)
                            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                            cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = METODODEPAGO
                            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FORMAPAGO
                            cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = MONEDA
                            cmd.Parameters.Add("@NO_CERTIFICADO", SqlDbType.VarChar).Value = Var9
                            cmd.Parameters.Add("@SELLO_SAT", SqlDbType.VarChar).Value = Var12
                            cmd.Parameters.Add("@SELLO_CFD", SqlDbType.VarChar).Value = Var14
                            cmd.Parameters.Add("@NO_CERTIFICADO_SAT", SqlDbType.VarChar).Value = Var13
                            cmd.Parameters.Add("@RFCPROVCERTIF", SqlDbType.VarChar).Value = Var15
                            cmd.Parameters.Add("@UUID_CFDI", SqlDbType.VarChar).Value = UUID_TIMBRADO
                            cmd.Parameters.Add("@FECHA_TIMBRADO", SqlDbType.VarChar).Value = Var10
                            cmd.Parameters.Add("@FECHA_CFDI", SqlDbType.DateTime).Value = FECHA_T1
                            cmd.Parameters.Add("@FOLIOI", SqlDbType.VarChar).Value = FOLIOI
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If

                        End Using
                    Catch ex As SqlException
                        ' Log the original exception here
                        For Each sqlError As SqlError In ex.Errors
                            Debug.Print(sqlError.Number & ", " & sqlError.ToString)
                            Select Case sqlError.Number
                                Case 207 ' 207 = InvalidColumn
                                    'do your Stuff here
                                    Exit Select
                                Case 547 ' 547 = (Foreign) Key violation
                                    'do your Stuff here
                                    DETEC_ERROR_VIOLATION_KEY = True
                                    Exit Select
                                Case 2601, 2627 ' 2601 = (Primary) key violation
                                    'do your Stuff here
                                    DETEC_ERROR_VIOLATION_KEY = True
                                    Exit Select
                                Case 3621
                                    'The statement has been terminated.
                                Case Else                        'do your Stuff here
                                    Exit Select
                            End Select
                        Next
                    Catch ex As Exception
                        BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                    If Not Valida_Conexion() Then
                    End If

                Next
                Var8 = ""

                SQL = "UPDATE FACTD" & Empresa & " SET ESCFD = 'T', FOLIOI = '" & FOLIOI & "' WHERE CVE_DOC = '" & FCVE_DOC & "'"
                ReturnBool = EXECUTE_QUERY_NET(SQL)


                MsgBox("Documento timbrado")

                PassData1 = "DEVOLUCION CFDI"
                IMPRIMIR_CFDI_DIRECTO(FCVE_DOC, "PDF", "", EMISORRFC, FOLIOI)

            Else
                MsgBox("!!! Documento no timbrado !!!")
            End If
        Catch ex As Exception
            BITACORATPV("970. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("970. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Me.Cursor = Cursors.Default


    End Sub

    Sub AGREGA_CFDIRELACIONADOS(FCVE_DOC As String)
        Dim TIPO_REL As String = ""
        Dim _cfdiRelacionados As New CfdiRelacionados
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT UUID, TIP_REL FROM CFDI_REL" & Empresa & " WHERE CVE_DOC = '" & FCVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        TIPO_REL = dr("TIP_REL")
                        Dim c As New CfdiRelacionado With {.UUID = dr("UUID")}
                        _cfdiRelacionados.CfdiRelacionado.Add(c)
                    End While
                End Using
                _cfdiRelacionados.TipoRelacion = TIPO_REL
                _c.CfdiRelacionados = _cfdiRelacionados
            End Using
        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub GET_PARAM_CFDI(FTIPO_COMPROBANTE As String, FECHA As String, FSERIE As String, FFOLIO As Long, FREGIMEN_FISCAL As String, FUSO_CFDI As String, FMONEDA As String,
                       FMETODODEPAGO As String, FFORMAPAGO As String, FNOMBRE As String, FRFC As String, FCP As String, FTTIPOCAMBIO As Decimal)

        Dim CALLE As String, NUMEXT As String, NUMINT As String, COLONIA As String, LOCALIDAD As String, CP As String, ESTADO As String
        Dim PAIS As String, MUNICIPIO As String, RAZONSOCIALEMISOR As String = "", LUGAREXPEDICION As String = ""
        Dim EMISOR_REGIMEN_FISCAL As String = "", CORREO1 As String, CORREO2 As String

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        gUSUARIO_PAC = dr("USUARIO")
                        gPASS_PAC = Desencriptar(dr("PASS"))
                        '0 - NO 1 - SI
                        If dr.ReadNullAsEmptyInteger("TIMBRADO_DEMO") = 0 Then
                            TIMBRADO_DEMO = "No"
                            TIMBRADO_SAT = "No"
                        Else
                            TIMBRADO_DEMO = "Si"
                            TIMBRADO_SAT = "Si"
                        End If

                        If CP_IMPRIME_IMPORTES Then
                            'CON PORCIOS CARAJO
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO_CONPRECIOS")
                        Else
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO")
                        End If

                        Try
                            If gRutaXML_TIMBRADO.Trim.Length = 0 Then
                                gRutaXML_TIMBRADO = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                            End If
                            If gRutaXML_NO_TIMBRADO.Trim.Length = 0 Then
                                gRutaXML_NO_TIMBRADO = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                            End If
                        Catch ex As Exception

                        End Try

                        gRutaPFX = dr("FILE_PFX")
                        gContraPFX = Desencriptar(dr("PASS_PFX").ToString)  'contrasena del certificado
                        gRutaCertificado = dr("FILE_CER")

                        CALLE = dr.ReadNullAsEmptyString("CALLE")
                        NUMEXT = dr.ReadNullAsEmptyString("NUMEXT")
                        NUMINT = dr.ReadNullAsEmptyString("NUMINT")
                        COLONIA = dr.ReadNullAsEmptyString("COLONIA")
                        LOCALIDAD = dr.ReadNullAsEmptyString("LOCALIDAD")
                        CP = dr.ReadNullAsEmptyString("CP")
                        ESTADO = dr.ReadNullAsEmptyString("ESTADO")
                        MUNICIPIO = dr.ReadNullAsEmptyString("MUNICIPIO")
                        PAIS = dr.ReadNullAsEmptyString("PAIS")
                        EMISORRFC = dr("EMISOR_RFC")
                        RAZONSOCIALEMISOR = dr("EMISOR_RAZON_SOCIAL")

                        LUGAREXPEDICION = dr("EMISOR_LUGAR_EXPEDICION")
                        EMISOR_REGIMEN_FISCAL = dr("EMISOR_REGIMEN_FISCAL")
                        CORREO1 = dr.ReadNullAsEmptyString("CORREO1")
                        CORREO2 = dr.ReadNullAsEmptyString("CORREO2")
                        FTP_CFDI_DEV = dr.ReadNullAsEmptyString("FTODEV")
                    End If
                End Using
            End Using

            Dim d1 As DateTime = Now
            Dim FECHA_CERT As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")

            _c.Emisor.Nombre = RAZONSOCIALEMISOR
            _c.Emisor.Rfc = EMISORRFC
            _c.LugarExpedicion = LUGAREXPEDICION
            _c.Fecha = FECHA_CERT
            _c.Serie = LETRA_VENTA
            _c.Folio = FOLIO_VENTA
            _c.Emisor.RegimenFiscal = EMISOR_REGIMEN_FISCAL

            'Moneda="MXN" TipoCambio="1"

            _c.TipoDeComprobante = FTIPO_COMPROBANTE
            _c.Moneda = FMONEDA
            If FMONEDA = "MXN" Then
                _c.TipoCambio = "1"
            Else
                _c.TipoCambio = FTTIPOCAMBIO
            End If
            _c.MetodoPago = FMETODODEPAGO
            _c.FormaPago = FFORMAPAGO

            _c.Exportacion = "01"

            _c.Receptor.Nombre = FNOMBRE
            _c.Receptor.Rfc = FRFC

            _c.Receptor.DomicilioFiscalReceptor = FCP
            _c.Receptor.RegimenFiscalReceptor = FREGIMEN_FISCAL
            _c.Receptor.UsoCFDI = USO_CFDI


        Catch ex As Exception
            BITACORATPV("1000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function CARGAR_CONCEPTOS_NC(ByVal FCVE_DOC As String) As Boolean

        Dim DESC1 As Decimal, PRECIO As Decimal, IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal
        Dim IMPU4 As Decimal, CVE_PRODSERV As String, CVE_UNIDAD As String, DESCR As String, UNI_MED As String
        Dim q As Integer = 0, ObjetoImp As String

        Try
            SQL = "SELECT P.CVE_ART, P.CANT, P.PREC, DESC1, ISNULL(DESCR_ART,'') AS DES, UNI_MED, P.IMPU1, P.IMPU2, 
                P.IMPU3, P.IMPU4, P.TOT_PARTIDA, I.CVE_PRODSERV, I.CVE_UNIDAD
                FROM PAR_FACTD" & Empresa & " P
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                LEFT JOIN IMPU" & Empresa & " T ON T.CVE_ESQIMPU = I.CVE_ESQIMPU
                WHERE CVE_DOC = '" & FCVE_DOC & "'"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        DESCR = dr("DES")
                        UNI_MED = dr.ReadNullAsEmptyString("UNI_MED")
                        IMPU1 = dr("IMPU1")
                        IMPU2 = dr("IMPU2")
                        IMPU3 = dr("IMPU3")
                        IMPU4 = dr("IMPU4")
                        CVE_PRODSERV = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                        CVE_UNIDAD = dr.ReadNullAsEmptyString("CVE_UNIDAD")

                        DESC1 = dr("DESC1")
                        PRECIO = dr("PREC")

                        If IMPU1 = 0 And IMPU2 = 0 And IMPU3 = 0 And IMPU4 = 0 Then
                            ObjetoImp = "01"
                        Else
                            ObjetoImp = "02"
                        End If

                        Dim c As New Concepto With {
                                .Cantidad = dr("CANT"),
                                .ClaveProdServ = CVE_PRODSERV,
                                .ClaveUnidad = CVE_UNIDAD,
                                .Descripcion = DESCR,
                                .Descuento = DESC1,
                                .Importe = dr("TOT_PARTIDA"),
                                .NoIdentificacion = dr("CVE_ART"),
                                .Unidad = UNI_MED,
                                .ValorUnitario = PRECIO,
                                .Impuestos = GetImpuestosConcepto(PRECIO, 1, DESC1, IMPU1, IMPU2, IMPU3, IMPU4),
                                .ObjetoImp = ObjetoImp}

                        _c.Conceptos.Concepto.Add(c)
                        q += 1
                    End While
                End Using
            End Using

            If q > 0 Then
                CalculaTotales()
            End If

        Catch ex As Exception
            MsgBox("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORATPV("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        If q = 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    Private Function GetImpuestosConcepto(FPRECIO As Decimal, FCANT As Decimal, FDESC As Decimal,
                                          FIMPU1 As Decimal, FIMPU2 As Decimal, FIMPU3 As Decimal, FIMPU4 As Decimal) As ImpuestosC
        Dim impuesto As New ImpuestosC()
        Try
            If FIMPU1 > 0 Then
                FIMPU1 /= 100
                impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU1, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU1, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU2 < 0 Then
                FIMPU2 = Math.Abs(FIMPU2)
                FIMPU2 /= 100
                impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU2, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU2, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU3 < 0 Then
                FIMPU3 = Math.Abs(FIMPU3)
                FIMPU3 /= 100
                impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU3, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU3, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU4 > 0 Then
                FIMPU4 /= 100
                impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU4, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU4, 2), .TipoFactor = "Tasa"})
            End If
        Catch ex As Exception
            BITACORATPV("1750. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1750. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return impuesto

    End Function
    Private Sub CalculaTotales()
        _c.Impuestos = GetImpuestos(_c.Conceptos.Concepto)
        Dim subtotal As Decimal = 0D
        Dim descuento As Decimal = 0D

        For Each c As Concepto In _c.Conceptos.Concepto
            subtotal += subtotal + c.Importe
            descuento = c.Descuento
        Next

        _c.SubTotal = subtotal
        _c.Descuento = descuento
        _c.Total = subtotal - _c.Impuestos.TotalImpuestosRetenidos + _c.Impuestos.TotalImpuestosTrasladados
        _c.TotalLetra = New Numalet().ToCustomString(_c.Total)

    End Sub
    Private Function GetImpuestos(ByVal conceptos As List(Of Concepto)) As Impuestos
        Dim index As Integer
        Dim traslado As New Traslado()
        Dim retencion As New Retencion()
        Dim traslados As New List(Of Traslado)()

        Dim retenciones As New List(Of Retencion)()
        Dim totalImpuestosRetenidos As Decimal = 0
        Dim totalImpuestosTrasladados As Decimal = 0
        Dim impuestos As New Impuestos()

        For Each c As Concepto In conceptos
            For Each t As TrasladoC In c.Impuestos.Traslados
                If (traslados.Exists(Function(x) (x.Impuesto = t.Impuesto) AndAlso (x.TasaOCuota = t.TasaOCuota))) Then
                    index = traslados.FindIndex(Function(x) x.Impuesto = t.Impuesto)
                    traslados(index).Importe = traslados(index).Importe + t.Importe
                Else
                    traslado = New Traslado With {
                        .Importe = t.Importe,
                        .Impuesto = t.Impuesto,
                        .TasaOCuota = t.TasaOCuota,
                        .TipoFactor = t.TipoFactor,
                        .Base = t.Base
                    }
                    traslados.Add(traslado)
                End If
            Next

            For Each r As RetencionC In c.Impuestos.Retenciones
                If (retenciones.Exists(Function(x) (x.Impuesto = r.Impuesto))) Then
                    index = traslados.FindIndex(Function(x) x.Impuesto = r.Impuesto)
                    retenciones(index).Importe = retenciones(index).Importe + r.Importe
                Else
                    retencion = New Retencion With {
                        .Importe = r.Importe,
                        .Impuesto = r.Impuesto
                    }

                    retenciones.Add(retencion)
                End If
            Next
        Next

        For Each r As Retencion In retenciones
            totalImpuestosRetenidos += r.Importe
        Next

        For Each t As Traslado In traslados
            totalImpuestosTrasladados += t.Importe
        Next

        impuestos.TotalImpuestosRetenidos = totalImpuestosRetenidos
        impuestos.TotalImpuestosTrasladados = totalImpuestosTrasladados
        impuestos.Traslados = traslados
        impuestos.Retenciones = retenciones
        Return impuestos
    End Function

    Private Sub BarCancNC_Click(sender As Object, e As ClickEventArgs) Handles BarCancNC.Click
        Try

            Var2 = Fg(Fg.Row, 1) ' Fg(Fg.Row, 2) 'FACTURA
            Var3 = "N"  'CATA PORTE 1
            Var4 = "N"  'CATA PORTE 2
            Var10 = "4.0" 'VERSION

            Var5 = ""

            FrmCFDICancFAC.ShowDialog()
            If Var5 = "ok" Then
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
