Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmSelItem2
    Dim Proceso As String
    Private PARAM_VAR As String = ""
    Private TipoUnidad As Integer
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.SuspendLayout()

        CARGAR_DATOS1()

        Me.ResumeLayout()

    End Sub
    Private Sub FrmSelItem2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        If Fg.Rows.Count = 1 Then

            If Proceso = "FACTURA" Then
                MsgBox("No se encontraron registros a mostrar, por favor verifique que estes capturada " &
                       "la ó las lineas en la pestaña ""Lines Factura CFDI"" en parámetros del sistema-Ventas")
                '""

                'INNER JOIN GCPARAMVENTAS_LIN_FAC L ON L.LINEA = I.LIN_PROD
            Else
                MsgBox("No se encontraron registros a mostrar")
            End If
            Me.Close()
        End If

        If Not IsNothing(PassData) Then
            If PassData = "TOP" Then
                Me.TopMost = True
            End If
        End If

        If Proceso = "PedidosProg" Then
            Me.WindowState = FormWindowState.Maximized
        End If

        Me.CenterToScreen()

    End Sub
    Sub CARGAR_DATOS1()
        Dim CADENA_UNIDAD As String
        Try
            Proceso = Var2
            If IsNumeric(Var4) Then
                TipoUnidad = Var4
            Else
                TipoUnidad = 0
            End If
            PARAM_VAR = Var5

            Select Case Proceso
                Case "GCCLASIFIC_SERVICIOS"
                    SQL = "SELECT CVE_CLA, DESCR FROM GCCLASIFIC_SERVICIOS WHERE STATUS = 'A'"
                    Fg.Cols.Count = 3
                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "3*"
                    Fg.Cols(1).TextAlign = TextAlignEnum.LeftCenter
                Case "GCSERVICIOS"
                    SQL = "SELECT S.CVE_SER, S.DESCR, S.COSTO_MO, 
                        CASE S.TIPO_SERVICIO WHEN 0 THEN 'Preventivo' ELSE 'Correctivo' END AS 'Tipo de servicio' 
                        FROM GCSERVICIOS S 
                        ORDER BY TRY_PARSE(CVE_SER AS INT) DESC"
                    Fg.Cols.Count = 5
                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "2*"
                    Fg.Cols(3).StarWidth = "*"
                    Fg.Cols(4).StarWidth = "*"
                    Fg.Cols(1).TextAlign = TextAlignEnum.LeftCenter
                Case "GCSERVICIOS_MANTE"
                    SQL = "SELECT CVE_SER, DESCR 
                        FROM GCSERVICIOS_MANTE WHERE STATUS = 'A' ORDER BY TRY_PARSE(CVE_SER AS INT)"
                    Fg.Cols.Count = 3
                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "3*"
                    Fg.Cols(1).TextAlign = TextAlignEnum.LeftCenter
                Case "tblcclaveunidad"
                    SQL = "SELECT claveUnidad, nombre FROM tblcclaveunidad ORDER BY claveUnidad"
                    Fg.Cols.Count = 3
                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "4*"
                    Fg.Cols(1).TextAlign = TextAlignEnum.LeftCenter
                Case "Embalaje"
                    SQL = "SELECT CLAVE, DESCR FROM GCEMBALAJE WHERE STATUS = 'A' ORDER BY TRY_PARSE(CLAVE AS INT)"
                    Fg.Cols.Count = 3
                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "8*"
                Case "Cargas"
                    SQL = "SELECT CLAVE, DESCR FROM GCCARGAS WHERE STATUS = 'A' ORDER BY TRY_PARSE(CLAVE AS INT)"
                    Fg.Cols.Count = 3
                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "8*"
                Case "GCConc"
                    SQL = "SELECT CVE_GAS, DESCR FROM GCCONC_GASTOS WHERE STATUS = 'A' ORDER BY CVE_GAS"
                    Fg.Cols.Count = 3
                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "8*"

                Case "Marca reno"
                    SQL = "SELECT CVE_MARCA, DESCR
                        FROM GCMARCAS_RENOVADO WHERE STATUS = 'A'
                        ORDER BY TRY_PARSE(CVE_MARCA AS INT)"
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Decripción"
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "2*"

                    Me.Width = 400

                Case "Prov reno"
                    SQL = "SELECT CVE_PRE, DESCR
                        FROM GCPROVRENOVADO WHERE STATUS = 'A'
                        ORDER BY TRY_PARSE(CVE_PRE AS INT)"
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Decripción"
                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "2*"

                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 60
                    Fg.Cols(2).Width = 200
                    Me.Width = 400

                Case "Metodo de pago"
                    SQL = "SELECT metodoPago, descripcion FROM tblcmetodopago ORDER BY id"
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Decripción"
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 60
                    Fg.Cols(2).Width = 200
                    Me.Width = 300
                    Me.Height = 200
                Case "Flujo"
                    SQL = "SELECT CLAVE, DESCR
                        FROM SOENTRADADINERO
                        WHERE TIPO = '" & Var5 & "' ORDER BY CLAVE"
                    Fg.Cols.Count = 4
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Decripción"
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 60
                    Fg.Cols(2).Width = 200
                    Me.Width = 300
                Case "ListaPrec"
                    SQL = "SELECT CVE_PRECIO, DESCRIPCION
                        FROM PRECIOS" & Empresa & "
                        WHERE STATUS = 'A'
                        ORDER BY CVE_PRECIO"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 200
                    Me.MinimizeBox = False
                    Me.MaximizeBox = False
                    Me.Width = 600
                    Fg.Width = Me.Width - 30

                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "2*"

                Case "MinveEnt", "MinveSal"
                    SQL = "SELECT CVE_CPTO, DESCR
                        FROM CONM" & Empresa & "
                        WHERE STATUS = 'A' " & Var7 & "
                        ORDER BY CVE_CPTO"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Concepto"
                    Fg(0, 2) = "Descripción"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 200
                    Me.MinimizeBox = False
                    Me.MaximizeBox = False
                    Me.Width = 600
                    Fg.Width = Me.Width - 30

                    AJUSTA_COLUMNAS_FG3(Me, Fg, 0, 1)
                Case "Depto"
                    SQL = "SELECT CVE_DEPTO, DESCR
                        FROM GCDEPTOS 
                        WHERE STATUS = 'A'
                        ORDER BY TRY_PARSE(CVE_DEPTO AS INT)"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 200
                    Me.MinimizeBox = False
                    Me.MaximizeBox = False
                    Me.Width = 600
                    Fg.Width = Me.Width - 30
                Case "TipoActivo"
                    SQL = "SELECT CLAVE, DESCRIP
                        FROM GCTIPACTIV ORDER BY CLAVE"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 200
                    Me.MinimizeBox = False
                    Me.MaximizeBox = False
                    Me.Width = 600
                    Fg.Width = Me.Width - 30
                Case "Gastos"
                    SQL = "SELECT G.CVE_ART, G.DESCR, COSTO, DESC_LIN, DESCRIPESQ
                        FROM GCCATGASTOS G
                        LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = G.LINEA
                        LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = G.CVE_ESQIMPU
                        WHERE G.STATUS = 'A'    
                        ORDER BY CVE_ART"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 6
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg(0, 3) = "Costo"
                    Fg(0, 4) = "Linea"
                    Fg(0, 5) = "Esquema impuesto"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 200
                    Fg.Cols(3).Width = 90
                    Fg.Cols(4).Width = 150
                    Fg.Cols(5).Width = 150
                    Me.MinimizeBox = False
                    Me.MaximizeBox = False
                    Me.Width = 775
                    Fg.Width = Me.Width - 30
                Case "NumGen"
                    SQL = "SELECT CVE_GEN, DESCR
                        FROM GCHORAS_GEN 
                        ORDER BY CVE_GEN"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Generador"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 200
                    Me.MinimizeBox = False
                    Me.MaximizeBox = False
                    Me.Width = 475
                    Fg.Width = Me.Width - 30
                Case "GCCATEVA"
                    SQL = "SELECT E.CVE_EVA, E.DESCR AS DES, 
                        CASE WHEN E.TIPO_VIAJE = 1 THEN 'FULL' ELSE 'SENCILLO' END AS TIPVIAJE
                        FROM GCCATEVA E
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = E.CVE_MOT
                        WHERE E.STATUS = 'A' ORDER BY E.CVE_EVA"

                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 4
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave eva."
                    Fg(0, 2) = "Descripción"
                    Fg(0, 3) = "Tipo viaje"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 250
                    Fg.Cols(3).Width = 70

                    Me.MinimizeBox = False
                    Me.MaximizeBox = False


                    Me.Width = 475
                    Fg.Width = Me.Width - 30
                Case "tblcformapago"
                    SQL = "SELECT formaPago, descripcion FROM tblcformapago ORDER BY formaPago"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 350

                    Me.MinimizeBox = False
                    Me.MaximizeBox = False


                    Me.Width = 475
                    Fg.Width = Me.Width - 30

                Case "PagoComplementoDocCte"
                    'Var48 = IMPORTE_M
                    'Var49 = ABONOS
                    'Var47 = TXT.Text
                    'Var46 = TCLIENTE.Text
                    SQL = "SELECT M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.NO_FACTURA, M.DOCTO, M.IMPORTE, 
                        ISNULL(M.NO_PARTIDA,1) AS NO_PAR, N.CVE_MONED, M.TCAMBIO, F.METODODEPAGO, F.FORMADEPAGOSAT
                        FROM CUEN_DET" & Empresa & " M
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE 
                        LEFT JOIN CFDI F ON F.FACTURA = M.REFER
                        LEFT JOIN MONED" & Empresa & " N ON N.NUM_MONED = M.NUM_MONED 
                        WHERE ISNULL(F.METODODEPAGO,'PPD') = 'PPD' AND ISNULL(F.FORMADEPAGOSAT,'99') = 99 AND ISNULL(CVE_DOC_COMPPAGO,'') = '' AND 
                        M.CVE_CLIE = '" & Var46 & "' AND M.REFER = '" & Var5 & "' ORDER BY M.CVE_CLIE, M.REFER"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 13
                    Fg(0, 1) = "Documento"
                    Fg(0, 2) = "Cliente"
                    Fg(0, 3) = "Nombre"
                    Fg(0, 4) = "Fecha"
                    Fg(0, 5) = "No. factura"
                    Fg(0, 6) = "Docto."
                    Fg(0, 7) = "Importe"
                    Fg(0, 8) = "NO_PARTIDA"  'NO_PARTIDA
                    Fg(0, 9) = "CVE_MONED"  'MXN
                    Fg(0, 10) = "TCAMBIO" 'US = 19.87 MXN = 1
                    Fg(0, 11) = "Metodo de pago"
                    Fg(0, 12) = "Forma de pago"
                    Dim c As Column = Fg.Cols(7)
                    c.DataType = GetType(Double)
                    c.Format = "###,##0.00"

                    Me.Width = 680
                    'Me.Height = 200
                    Fg.Width = Me.Width - 30

                    Fg.Cols(5).Visible = False
                    Fg.Cols(9).Visible = False
                    Fg.Cols(10).Visible = False
                    Fg.Cols(11).Visible = False
                    Fg.Cols(12).Visible = False

                    'Me.MaximizeBox = False
                    'Me.MinimizeBox = False
                    'Label1.Visible = False
                    'tBox.Visible = False

                    barBuscar.ImageScaling = ToolStripItemImageScaling.SizeToFit
                    barSalir.ImageScaling = ToolStripItemImageScaling.SizeToFit

                    'barRefresh.Visible = False
                Case "PAGO CFDI"
                    SQL = "SELECT TOP 2000 CVE_DOC, CLIENTE, NOMBRE, FECHA, IMPORTE
                        FROM CFDI_COMPAGO PC 
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = PC.CLIENTE
                        WHERE PC.CLIENTE = '" & Var25 & "' 
                        ORDER BY FECHAELAB DESC"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 6
                    Fg(0, 1) = "Documento"
                    Fg(0, 2) = "Cliente"
                    Fg(0, 3) = "Nombre"
                    Fg(0, 4) = "Fecha"
                    Fg(0, 5) = "Importe"

                    Me.Width = 510
                    Fg.Width = Me.Width - 30

                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "*"
                    Fg.Cols(3).StarWidth = "2*"
                    Fg.Cols(4).StarWidth = "*"
                    Fg.Cols(5).StarWidth = "*"

                    Fg.Cols(4).TextAlign = TextAlignEnum.CenterCenter

                    Dim c As Column = Fg.Cols(5)
                    c.DataType = GetType(Double)
                    c.Format = "###,###,##0.00"

                    barBuscar.ImageScaling = ToolStripItemImageScaling.SizeToFit
                    barSalir.ImageScaling = ToolStripItemImageScaling.SizeToFit
                Case "PagoComplemento"
                    'Var48 = IMPORTE_M
                    'Var49 = ABONOS
                    'Var47 = TXT.Text
                    'Var46 = TCLIENTE.Text
                    SQL = "SELECT M.DOCTO , M.CVE_CLIE AS CLIENTE, MAX(P.NOMBRE) AS NOMB
                        FROM CUEN_DET" & Empresa & " M
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE 
                        LEFT JOIN CFDI F ON F.FACTURA = M.REFER
                        LEFT JOIN MONED" & Empresa & " N ON N.NUM_MONED = M.NUM_MONED 
                        WHERE ISNULL(F.METODODEPAGO, 'PPD') = 'PPD' AND ISNULL(F.FORMADEPAGOSAT,'99') = 99 AND ISNULL(CVE_DOC_COMPPAGO,'') = '' AND 
                        M.CVE_CLIE = '" & Var5 & "' 
                        GROUP BY M.CVE_CLIE, M.DOCTO
                        ORDER BY M.CVE_CLIE, M.DOCTO"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 4
                    Fg(0, 1) = "Documento"
                    Fg(0, 2) = "Cliente"
                    Fg(0, 3) = "Nombre"

                    Me.Width = 450
                    Fg.Width = Me.Width - 30

                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "*"
                    Fg.Cols(3).StarWidth = "3*"

                    barBuscar.ImageScaling = ToolStripItemImageScaling.SizeToFit
                    barSalir.ImageScaling = ToolStripItemImageScaling.SizeToFit
                Case "Tarifas"
                    SQL = "SELECT DESCRIPCION, PRECIO, ISNULL(CVE_TIPO_OPE,0) AS C_T_OPE, ISNULL(TP.DESCR,'') AS DES, 
                        ISNULL(PRECIO_X_TANQUE,0) AS PRE_X_TANQUE, R.CVE_ART
                        FROM GCTARIFAS T 
                        LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_TAB = T.CVE_RUTA
                        LEFT JOIN GCTIPO_OPERACION TP ON TP.CVE_TIPO = R.CVE_TIPO_OPE
                        LEFT JOIN PRECIOS" & Empresa & " P ON P.CVE_PRECIO = T.CVE_PRECIO
                        WHERE CVE_CON = '" & Var3 & "' ORDER BY T.CVE_PRECIO"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 7
                    Fg(0, 1) = "Descripción"
                    Fg(0, 2) = "Precio"
                    Fg(0, 3) = "Tipo operación"
                    Fg(0, 4) = "Descripción Tipo operación"
                    Fg(0, 5) = "Precio x tanque"
                    Fg(0, 6) = "Artículo"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 170
                    Fg.Cols(2).Width = 100
                    Fg.Cols(3).Width = 0
                    Fg.Cols(4).Width = 0
                    Fg.Cols(5).Width = 0
                    Fg.Cols(6).Width = 70

                    Dim c As Column = Fg.Cols(2)
                    c.DataType = GetType(Double)
                    c.Format = "###,##0.00"

                    Me.Width = 400
                    Me.Height = 180
                    Fg.Width = Me.Width - 30

                    Fg.AutoSizeRows()
                    Me.MaximizeBox = False
                    Me.MinimizeBox = False
                    Label1.Visible = False
                    tBox.Visible = False

                    barBuscar.ImageScaling = ToolStripItemImageScaling.SizeToFit
                    barSalir.ImageScaling = ToolStripItemImageScaling.SizeToFit

                    barRefresh.Visible = False

                Case "GCCASETAS_X_RUTA"
                    SQL = "SELECT C.CVE_CXR, C.CVE_PLAZA, C.CVE_PLAZA2, P1.CIUDAD AS CIUDAD1, P2.CIUDAD AS CIUDAD2, 
                        ISNULL(IMPORTE_CASETAS,0) AS IMPORTE, OP.NOMBRE, C.IAVE
                        FROM GCCASETAS_X_RUTA C 
                        LEFT JOIN GCCLIE_OP OP On OP.CLAVE = C.CLAVE_OP
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA 
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = C.CVE_PLAZA2
                        WHERE C.STATUS = 'A' ORDER BY CVE_CXR"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 9
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Cve. plaza1"
                    Fg(0, 3) = "Cve. plaza2"
                    Fg(0, 4) = "Ciudad plaza1"
                    Fg(0, 5) = "Ciudad plaza2"
                    Fg(0, 6) = "Importe"
                    Fg(0, 7) = "Cliente operativos"
                    Fg(0, 8) = "IAVE"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 50
                    Fg.Cols(2).Width = 0
                    Fg.Cols(3).Width = 0
                    Fg.Cols(4).Width = 220
                    Fg.Cols(5).Width = 220
                    Fg.Cols(6).Width = 80
                    Fg.Cols(7).Width = 150
                    Fg.Cols(8).Width = 60

                    Dim c As Column = Fg.Cols(6)
                    c.DataType = GetType(Double)
                    c.Format = "###,##0.00"

                    Me.Width = 750
                    Fg.Width = Me.Width - 30
                    Fg.AutoSizeRows()

                Case "FACTURA CFDI"
                    SQL = "SELECT TOP 2000 CFDI.FACTURA, P.CLAVE, P.NOMBRE, FECHA_DOC, F.IMPORTE,
                        CFDI.FECHAELAB, CFDI.CLIENTE, P2.NOMBRE AS NOMBRE2, CFDI.IMPORTE
                        FROM CFDI 
                        LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = CFDI.FACTURA
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                        LEFT JOIN CLIE" & Empresa & " P2 ON P2.CLAVE = CFDI.CLIENTE
                        WHERE ISNULL(F.STATUS,'') <> 'C' AND ISNULL(CFDI.ESTATUS,'') <> 'C'
                        ORDER BY F.FECHAELAB DESC"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 6
                    Fg(0, 1) = "Factura"
                    Fg(0, 2) = "Cliente"
                    Fg(0, 3) = "Nombre"
                    Fg(0, 4) = "Fecha"
                    Fg(0, 5) = "Importe"

                    Dim c As Column = Fg.Cols(4)
                    c.DataType = GetType(Date)
                    c.Format = "d"

                    Dim c2 As Column = Fg.Cols(5)
                    c2.DataType = GetType(Decimal)
                    c2.Format = "N2"

                    Me.Width = 650
                    Fg.Width = Me.Width - 30

                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "*"
                    Fg.Cols(3).StarWidth = "4*"
                    Fg.Cols(4).StarWidth = "*"
                    Fg.Cols(5).StarWidth = "*"

                    Fg.Cols(1).MinWidth = 50

                Case "FAC CFDI"
                    SQL = "SELECT F.FACTURA, F.DOCUMENT, F.DOCUMENT2, F.CLIENTE, C.NOMBRE, F.FECHAELAB
                        FROM CFDI F
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE
                        Order By FECHAELAB DESC"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 7
                    Fg(0, 1) = "Factura"
                    Fg(0, 2) = "Carta porte"
                    Fg(0, 3) = "Carta porte 2"
                    Fg(0, 4) = "Cliente"
                    Fg(0, 5) = "Nombre"
                    Fg(0, 6) = "Fecha"
                    Me.Width = 750
                    Fg.Width = Me.Width - 30
                    Fg.AutoSizeRows()
                Case "Carta porte"
                    SQL = "SELECT FACTURA, DOCUMENT, DOCUMENT2, CLIENTE, FECHAELAB
                         FROM CFDI 
                         Order By FECHAELAB DESC"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 7
                    Fg(0, 1) = "Factura"
                    Fg(0, 2) = "Carta porte"
                    Fg(0, 3) = "Carta porte 2"
                    Fg(0, 4) = "Cliente"
                    Fg(0, 5) = "Fecha"
                    Me.Width = 650
                    Fg.Width = Me.Width - 30
                    Fg.AutoSizeRows()

                Case "PedidosProg"
                    SQL = "Select P.CVE_DOC, C3.NOMBRE, I.DESCR, P.FECHA_CARGA, P.FECHA_DESCARGA, RE.DESCR As RECIBIR_E, EE.DESCR As RECOGER_E
                        FROM GCPEDIDOSPROG P
                        LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                        LEFT JOIN GCCONTRATO CT ON CT.CVE_CON = P.CVE_CON 
                        LEFT JOIN GCCLIE_OP C3 ON C3.CLAVE = CT.NO_CONTRATO 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN
                        WHERE P.STATUS = 'A' AND ISNULL(CVE_VIAJE,'') = '' AND 
                        NOT EXISTS (SELECT PED_ENLAZADO FROM GCPEDIDOS WHERE PED_ENLAZADO = P.CVE_DOC)
                        ORDER BY P.FECHAELAB DESC"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 8
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Documento"
                    Fg(0, 2) = "Nombre"
                    Fg(0, 3) = "Decripcion"
                    Fg(0, 4) = "Fecha carga"
                    Fg(0, 5) = "Fecha descarga"
                    Fg(0, 6) = "Origen"
                    Fg(0, 7) = "Destino"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 100
                    Fg.Cols(2).Width = 350
                    Fg.Cols(3).Width = 250
                    Fg.Cols(4).Width = 90
                    Fg.Cols(5).Width = 90
                    Fg.Cols(6).Width = 120
                    Fg.Cols(7).Width = 120
                    Me.Width = 950
                    Fg.Width = Me.Width - 30

                    Fg.AutoSizeCols()
                Case "Vend"
                    SQL = "SELECT CVE_VEND, NOMBRE FROM VEND" & Empresa & "  WHERE STATUS = 'A' ORDER BY NOMBRE"

                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 400
                Case "InveR", "InvenRS", "InvenRP", "Inventario"
                    ' --------------------               MULTIALMACEN      -----------------------
                    ' --------------------               MULTIALMACEN      -----------------------
                    ' --------------------               MULTIALMACEN      -----------------------
                    If G_ALM = 0 Then G_ALM = 1
                    If MULTIALMACEN = 0 Then
                        SQL = "SELECT I.CVE_ART, DESCR, I.EXIST, TIPO_ELE, STATUS, 
                            (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS NUM_PARTE
                            FROM INVE" & Empresa & " I 
                            WHERE I.STATUS = 'A' AND I.TIPO_ELE <> 'K' ORDER BY I.DESCR"
                    Else
                        SQL = "SELECT M.CVE_ART, DESCR, M.EXIST, I.TIPO_ELE, M.STATUS, 
                            (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = M.CVE_ART) AS NUM_PARTE                            
                            FROM MULT" & Empresa & " M 
                            LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                            WHERE I.STATUS = 'A' AND M.STATUS = 'A' AND I.TIPO_ELE <> 'K' AND CVE_ALM = " & G_ALM & " ORDER BY I.DESCR"
                    End If
                    ' --------------------               MULTIALMACEN      -----------------------
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 7
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg(0, 3) = "No. parte"
                    Fg(0, 4) = "Exist. " & IIf(MULTIALMACEN = 1, " almacén " & G_ALM, "")

                    Fg(0, 5) = "Tipo"
                    Fg(0, 6) = "Estatus"
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 120
                    Fg.Cols(2).Width = 300
                    Fg.Cols(3).Width = 100
                    Fg.Cols(4).Width = 110
                    Me.Width = 700
                    Fg.Width = Me.Width - 30

                Case "Prov"
                    SQL = "SELECT CLAVE, NOMBRE, RFC, CALLE FROM PROV" & Empresa & " WHERE STATUS = 'A' ORDER BY CLAVE"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 5
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Nombre"
                    Fg(0, 3) = "R.F.C."
                    Fg(0, 4) = "Domicilio"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 400
                    Fg.Cols(3).Width = 70
                    Fg.Cols(4).Width = 120

                    Me.Width = 600
                    Fg.Width = Me.Width - 30
                Case "FACTURA"
                    SQL = "SELECT I.CVE_ART, ISNULL(I.DESCR,'') AS DES, ISNULL(I.EXIST,0) AS EXI, LIN_PROD
                        FROM INVE" & Empresa & " I
                        INNER JOIN GCPARAMVENTAS_LIN_FAC L ON L.LINEA = I.LIN_PROD
                        WHERE STATUS = 'A' AND TIPO_ELE <> 'K' AND CVE_ART <> 'TOT' 
                        ORDER BY DESCR"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 5
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg(0, 3) = "Exist."
                    Fg(0, 4) = "Linea"
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 120
                    Fg.Cols(2).Width = 300
                    Fg.Cols(3).Width = 100
                    Fg.Cols(4).Width = 90
                    Me.Width = 600
                    Fg.Width = Me.Width - 30
                Case "Articulo"

                    If PARAM_VAR.Trim.Length > 0 Then
                        PARAM_VAR = "AND LIN_PROD = '" & PARAM_VAR & "'"
                    End If

                    SQL = "SELECT CVE_ART, ISNULL(DESCR,'') AS DES, ISNULL(EXIST,0) AS EXI 
                        FROM INVE" & Empresa & " 
                        WHERE STATUS = 'A' AND TIPO_ELE <> 'K' AND CVE_ART <> 'TOT' " & PARAM_VAR & "
                        ORDER BY DESCR"

                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 4
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg(0, 3) = "Exist."
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 120
                    Fg.Cols(2).Width = 300
                    Fg.Cols(3).Width = 100
                    Me.Width = 600
                    Fg.Width = Me.Width - 30
                Case "InveS"
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, 
                        EXIST, TIPO_ELE, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I 
                        LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'S' ORDER BY CVE_ART"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 8
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg(0, 3) = "Precio"
                    Fg(0, 4) = "Alterna"
                    Fg(0, 5) = "Exist."
                    Fg(0, 6) = "Tipo prod."
                    Fg(0, 7) = "Costo prom"
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 120
                    Fg.Cols(2).Width = 300
                    Fg.Cols(3).Width = 90
                    Fg.Cols(4).Width = 100
                    Fg.Cols(5).Width = 90
                    Fg.Cols(6).Width = 90
                    Fg.Cols(7).Width = 90
                    Me.Width = 800
                    Fg.Width = Me.Width - 30

                    Dim c As Column = Fg.Cols(3)
                    c.DataType = GetType(Double)
                    c.Format = "###,##0.00"

                    Dim c7 As Column = Fg.Cols(7)
                    c7.DataType = GetType(Double)
                    c7.Format = "###,##0.00"
                Case "InveP", "InveLiq"
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, 
                        EXIST, TIPO_ELE, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I 
                        LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'P' ORDER BY CVE_ART"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 8
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg(0, 3) = "Precio"
                    Fg(0, 4) = "Alterna"
                    Fg(0, 5) = "Exist."
                    Fg(0, 6) = "Tipo prod."
                    Fg(0, 7) = "Costo prom"
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 120
                    Fg.Cols(2).Width = 300
                    Fg.Cols(3).Width = 90
                    Fg.Cols(4).Width = 100
                    Fg.Cols(5).Width = 90
                    Fg.Cols(6).Width = 90
                    Fg.Cols(7).Width = 90
                    Me.Width = 800
                    Fg.Width = Me.Width - 30

                    Dim c As Column = Fg.Cols(3)
                    c.DataType = GetType(Double)
                    c.Format = "###,##0.00"

                    Dim c7 As Column = Fg.Cols(7)
                    c7.DataType = GetType(Double)
                    c7.Format = "###,##0.00"

                Case "Clientes", "Clie01", "Clie"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, ISNULL(CAMPLIB5,0) AS LIB5, ISNULL(CAMPLIB6,0) AS LIB6, 
                        USO_CFDI, ISNULL(REG_FISC,'') AS REGFISC
                        FROM CLIE" & Empresa & " C
                        LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = C.CLAVE
                        WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 9
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Nombre"
                    Fg(0, 3) = "R.F.C."
                    Fg(0, 4) = "Domicilio"
                    Fg(0, 5) = "%Porc., utilidad"
                    Fg(0, 6) = "Porc. o monto"
                    Fg(0, 7) = "Uso CFDI"
                    Fg(0, 8) = "Régimen fiscal"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 400
                    Fg.Cols(3).Width = 70
                    Fg.Cols(4).Width = 120
                    Fg.Cols(5).Width = 100
                    Fg.Cols(6).Width = 0
                    Fg.Cols(7).Width = 90
                    Fg.Cols(8).Width = 90
                    Me.Width = 600
                    Fg.Width = Me.Width - 30
                Case "CTE_CREDITO"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, USO_CFDI, ISNULL(REG_FISC,'') AS REGFISC
                        FROM CLIE" & Empresa & " C
                        WHERE C.STATUS = 'A' AND ISNULL(CON_CREDITO,'') = 'S' ORDER BY C.CLAVE"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 7
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Nombre"
                    Fg(0, 3) = "R.F.C."
                    Fg(0, 4) = "Domicilio"
                    Fg(0, 5) = "Uso CFDI"
                    Fg(0, 6) = "Régimen fiscal"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 250
                    Fg.Cols(3).Width = 90
                    Fg.Cols(4).Width = 250
                    Fg.Cols(5).Width = 60
                    Fg.Cols(6).Width = 90
                    Me.Width = 800
                    Fg.Width = Me.Width - 30
                Case "CTE_POS"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, CASE WHEN ISNULL(LISTA_PREC,0) < 1 THEN 1 ELSE LISTA_PREC END AS LISTAPREC, 
                        C.DESCUENTO, C.CALLE, USO_CFDI, ISNULL(REG_FISC,'') AS REGFISC, 
                        CASE WHEN ISNULL(CON_CREDITO,'') = 'S' THEN 'Si' ELSE 'No' END AS CONCRED
                        FROM CLIE" & Empresa & " C
                        WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 10
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Nombre"
                    Fg(0, 3) = "R.F.C."
                    Fg(0, 4) = "Lista prec."
                    Fg(0, 5) = "Desc."
                    Fg(0, 6) = "Domicilio"
                    Fg(0, 7) = "Uso CFDI"
                    Fg(0, 8) = "Régimen fiscal"
                    Fg(0, 9) = "Con crédito"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 60
                    Fg.Cols(2).Width = 250
                    Fg.Cols(3).Width = 95
                    Fg.Cols(4).Width = 60
                    Fg.Cols(5).Width = 50
                    Fg.Cols(6).Width = 200
                    Fg.Cols(7).Width = 70
                    Fg.Cols(8).Width = 80
                    Fg.Cols(9).Width = 80
                    Me.Width = 800
                    Fg.Width = Me.Width - 30
                Case "RUTAS FLORES"
                    SQL = "SELECT T.CVE_TAB, '(' + LTRIM(RTRIM(OP1.CLAVE)) + ') - ' + ISNULL(OP1.NOMBRE,'') AS NOM_OP1, T.DESCR AS NOMBRE_RUTA, T.DESCR2 AS NOMBRE_RUTA2, T.KMS, T.TAR_X_VIA_FULL AS TARIFA_VIAJE_FULL, 
                        T.TAR_X_VIA_SENC AS TARIFA_VIAJE_SENCILLO, T.TAR_OPER_FULL, TAR_X_TON_SENC AS TARIFA_OPER_SENCILLO, SUELDO_FULL, SUELDO_SENC,
                        PORC_SUELDO_FULL, PORC_SUELDO_SENC, (OP2.MUNICIPIO + ', ' + OP2.ESTADO) as PLANTA_ORIGEN, (OP3.MUNICIPIO + ', ' + OP3.ESTADO) AS PLANTA_DESTINO
                        FROM GCTAB_RUTAS_F T
                        LEFT JOIN CLIE" & Empresa & " OP1 ON OP1.CLAVE = T.CLIE_OP
                        LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = T.CLIE_OP_O
                        LEFT JOIN GCCLIE_OP OP3 ON OP3.CLAVE = T.CLIE_OP_D
                        LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = T.CVE_PROD
                        WHERE T.STATUS = 'A' ORDER BY TRY_PARSE(T.CVE_TAB AS INT)"

                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 16
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave tab."
                    Fg(0, 2) = "Cliente operativo"
                    Fg(0, 3) = "Nombre ruta"
                    Fg(0, 4) = "Nombre ruta 2"
                    Fg(0, 5) = "Kms"
                    Fg(0, 6) = "Tarifa viaje full"
                    Fg(0, 7) = "Tarifa viaje sencillo"
                    Fg(0, 8) = "Tarifa oper. full"
                    Fg(0, 9) = "Tarifa oper. sencillo"
                    Fg(0, 10) = "Sueldo full"
                    Fg(0, 11) = "Sueldo sencillo"
                    Fg(0, 12) = "Porc. de sueldo full"
                    Fg(0, 13) = "Porc. sueldo sencillo"
                    Fg(0, 14) = "Planta origen "
                    Fg(0, 15) = "Planta destino"

                    Dim cc1 As Column = Fg.Cols(5)
                    cc1.DataType = GetType(Decimal)
                    cc1.Format = "###,###,##0.00"

                    Dim c2 As Column = Fg.Cols(6)
                    c2.DataType = GetType(Decimal)
                    c2.Format = "###,###,##0.00"

                    Dim c3 As Column = Fg.Cols(7)
                    c3.DataType = GetType(Decimal)
                    c3.Format = "###,###,##0.00"

                    Dim c4 As Column = Fg.Cols(8)
                    c4.DataType = GetType(Decimal)
                    c4.Format = "###,###,##0.00"

                    Dim c5 As Column = Fg.Cols(9)
                    c5.Format = "###,###,##0.00"

                    Dim c6 As Column = Fg.Cols(10)
                    c6.DataType = GetType(Decimal)
                    c6.Format = "###,###,##0.00"

                    Dim c7 As Column = Fg.Cols(11)
                    c7.DataType = GetType(Decimal)
                    c7.Format = "###,###,##0.00"

                    Dim c8 As Column = Fg.Cols(12)
                    c8.DataType = GetType(Decimal)
                    c8.Format = "###,###,##0.00"

                    Dim c9 As Column = Fg.Cols(13)
                    c9.DataType = GetType(Decimal)
                    c9.Format = "###,###,##0.00"

                    Dim c10 As Column = Fg.Cols(14)
                    c10.DataType = GetType(Decimal)
                    c10.Format = "###,###,##0.00"

                    Dim c11 As Column = Fg.Cols(15)
                    c11.DataType = GetType(Decimal)
                    c11.Format = "###,###,##0.00"


                    Me.Width = Screen.PrimaryScreen.Bounds.Width - 350
                    Fg.Width = Me.Width - 30

                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "3*"
                    Fg.Cols(3).StarWidth = "3*"
                    Fg.Cols(4).StarWidth = "4*"
                    Fg.Cols(5).StarWidth = "*"
                    Fg.Cols(6).StarWidth = "*"
                    Fg.Cols(7).StarWidth = "*"
                    Fg.Cols(8).StarWidth = "*"
                    Fg.Cols(9).StarWidth = "*"
                    Fg.Cols(10).StarWidth = "*"
                    Fg.Cols(11).StarWidth = "*"
                    Fg.Cols(12).StarWidth = "*"
                    Fg.Cols(13).StarWidth = "*"
                    Fg.Cols(14).StarWidth = "2*"
                    Fg.Cols(15).StarWidth = "2*"


                Case "GCTAB_RUTAS"
                    SQL = "SELECT T.CVE_TAB, T.FECHA, (CASE T.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, P1.CIUDAD AS ORIG, 
                        P2.CIUDAD AS DEST, NOMBRE AS NOMB, T.KM_RECO, T.COSTO_CASETAS, T.SUELDO_OPER, T.P_X_LITRO, T.OBSER
                        FROM GCTAB_RUTAS T
                        LEFT JOIN GCDETALLE_RUTAS D ON D.CVE_RUTA = T.CVE_RUTA
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.ORIGEN
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.DESTINO
                        LEFT JOIN GCCLIE_OP C ON C.CLAVE = LTRIM(RTRIM(T.CLIENTE))
                        WHERE T.STATUS = 'A' ORDER BY CVE_TAB DESC"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 12
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Fecha"
                    Fg(0, 3) = "Tipo unidad"
                    Fg(0, 4) = "Origen"
                    Fg(0, 5) = "Destino"
                    Fg(0, 6) = "Decripcion"
                    Fg(0, 7) = "Kms. recorridos"
                    Fg(0, 8) = "Costo casetas"
                    Fg(0, 9) = "Sueldo operador"
                    Fg(0, 10) = "Precio x litro"
                    Fg(0, 11) = "Observaciones"
                    Me.Width = 950
                    Fg.Width = Me.Width - 30

                Case "Pedidos"
                    SQL = "SELECT TOP 300 P.CVE_DOC, P.CVE_CON, O.NOMBRE, CO1.NOMBRE AS ORIGEN, CO2.NOMBRE AS DESTINO, I.DESCR, P.FECHA, 
                        P1.CIUDAD AS ORIGEN, P2.CIUDAD AS DESTINO, P.FECHA_CARGA, P.FECHA_DESCARGA
                        FROM GCPEDIDOS P
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                        LEFT JOIN GCCLIE_OP CO1 ON CO1.CLAVE = P.CLAVE_O
                        LEFT JOIN GCCLIE_OP CO2 ON CO2.CLAVE = P.CLAVE_D
                        LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = P.CVE_PLAZA1
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = P.CVE_PLAZA2
                        WHERE P.STATUS = 'A' AND ISNULL(CVE_VIAJE,'') = '' ORDER BY P.FECHAELAB DESC"
                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 12
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Documento"
                    Fg(0, 2) = "Contrato"
                    Fg(0, 3) = "Operador"
                    Fg(0, 4) = "Cliente origen"
                    Fg(0, 5) = "Cliente destino"
                    Fg(0, 6) = "Decripcion"
                    Fg(0, 7) = "Fecha"
                    Fg(0, 8) = "Origen"
                    Fg(0, 9) = "Destino"
                    Fg(0, 10) = "Fecha carga"
                    Fg(0, 11) = "Fecha descarga"
                    Me.Width = 950
                    Fg.Width = Me.Width - 30

                    Dim c As Column = Fg.Cols(2)
                    c.DataType = GetType(Double)
                    c.Format = "######"
                Case "Reseteo"

                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 31
                    TITULOS()
                    SQL = "SELECT TOP 1000 R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, NOMBRE, R.CVE_UNI, U.CLAVEMONTE, M.DESCR AS NOMBREMOTOR, 
                        R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, CAL_GLO_EVA, BONO_RES, R.ODOMETRO, 
                        KM_ECM, LTS_ECM, LTS_REAL, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI, LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI, 
                        PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL, REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB
                        FROM GCRESETEO R 
                        Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
                        Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT 
                        WHERE R.STATUS = 'A' AND ESTADO = 'FINALIZADO' " & PARAM_VAR & "
                        ORDER BY R.CVE_RES DESC"
                    Me.Width = 950
                    Fg.Width = Me.Width - 30
                Case "ReseteoVikingos"

                    Fg.Rows.Count = 1
                    Fg.Cols.Count = 31
                    TITULOS()
                    SQL = "SELECT TOP 1000 R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, NOMBRE, R.CVE_UNI, U.CLAVEMONTE, M.DESCR AS NOMBREMOTOR, 
                        R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, CAL_GLO_EVA, BONO_RES, R.ODOMETRO, 
                        KM_ECM, LTS_ECM, LTS_REAL, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI, LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI, 
                        PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL, REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB
                        FROM GCRESETEO R 
                        Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
                        Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT 
                        WHERE R.STATUS = 'A'
                        ORDER BY R.CVE_RES DESC"
                    Me.Width = 950
                    Fg.Width = Me.Width - 30
                Case "Sueldo operadores"
                    SQL = "Select S.CVE_SUOP, ISNULL(C.NOMBRE,'') AS ORIGEN, ISNULL(P1.CIUDAD,'') AS PLAZA1, ISNULL(P2.CIUDAD,'') AS PLAZA2, 
                        CASE WHEN TIPO_FULL_SENCILLO = 0 THEN 'Full' ELSE 'Sencillo' END AS TIPO1, 
                        CASE WHEN TIPO_CARGADO_VACIO = 0 THEN 'Cargado' ELSE 'Vacio' END AS TIPO2, S.SUELDO 
                        FROM GCSUELDO_OPER S 
                        LEFT JOIN GCCLIE_OP C ON C.CLAVE = S.CLAVE_O
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = S.PLAZA_O
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = S.PLAZA_D
                        WHERE S.STATUS = 'A' ORDER BY CVE_SUOP"
                    Fg.Cols.Count = 8
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Cliente"
                    Fg(0, 3) = "Origen"
                    Fg(0, 4) = "Destino"
                    Fg(0, 5) = "Full/Sencillo"
                    Fg(0, 6) = "Cargado/Vacio"
                    Fg(0, 7) = "Sueldo"
                    Fg.Rows(0).Height = 50
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 50
                    Fg.Cols(2).Width = 120
                    Fg.Cols(3).Width = 120
                    Fg.Cols(4).Width = 120
                    Fg.Cols(5).Width = 50
                    Fg.Cols(6).Width = 50
                    Fg.Cols(7).Width = 90
                    Dim c As Column = Fg.Cols(7)
                    c.DataType = GetType(Decimal)
                    c.Format = "###,###,##0.00"

                    Me.Width = 950
                    Fg.Width = Me.Width - 30
                Case "ReseteoTab"
                    SQL = "SELECT CVE_TAB, CVE_ORI, ISNULL(P1.CIUDAD,'') AS DESCR_ORI, CVE_DES, ISNULL(P2.CIUDAD,'') AS DESCR_DES, 
                        CASE ISNULL(CARGADO_VACIO,0) WHEN 0 THEN 'Vacio' ELSE 'Cargado' END AS CAR_VAC, ISNULL(TIPO_VIAJE,'') AS VIAJE, 
                        CLIENTE, C.NOMBRE, ISNULL(KMS,0) As KM, ISNULL(RENDIMIENTO,0) As LTS, T.OBSER
                        FROM GCTABULADOR_PAR T 
                        LEFT JOIN GCCLIE_OP C On C.CLAVE = CLIENTE 
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = CVE_ORI 
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = CVE_DES 
                        WHERE T.STATUS = 'A' ORDER BY CVE_TAB DESC"
                    Fg.Cols.Count = 14
                    Fg(0, 1) = "Clave tab."
                    Fg(0, 2) = "Origen"
                    Fg(0, 3) = "Cliente origen"
                    Fg(0, 4) = "Destino"
                    Fg(0, 5) = "Cliente destino"
                    Fg(0, 6) = "Cargado/Vacio"
                    Fg(0, 7) = "Full/Sencillo"
                    Fg(0, 8) = "Cliente"
                    Fg(0, 9) = "Nombre"
                    Fg(0, 10) = "KMS"
                    Fg(0, 11) = "Rendimiento"
                    Fg(0, 12) = "Litros"
                    Fg(0, 13) = "Observaciones"
                    Fg.Rows(0).Height = 50
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 50
                    Fg.Cols(2).Width = 45
                    Fg.Cols(3).Width = 120
                    Fg.Cols(4).Width = 50
                    Fg.Cols(5).Width = 120
                    Fg.Cols(6).Width = 60
                    Fg.Cols(7).Width = 50
                    Fg.Cols(8).Width = 45
                    Fg.Cols(9).Width = 200
                    Fg.Cols(10).Width = 60
                    Fg.Cols(11).Width = 45
                    Fg.Cols(12).Width = 50
                    Fg.Cols(13).Width = 250
                    Dim c As Column = Fg.Cols(12)
                    c.DataType = GetType(Decimal)
                    c.Format = "###,###,##0.00"

                    Me.Width = 1000
                    Fg.Width = Me.Width - 30
                Case "Contrato"
                    SQL = "SELECT TOP 500 C.CVE_CON, CO1.NOMBRE AS NOMBRE_CONTRATO, CO2.NOMBRE AS NOMBRE_ORIGEN, P1.CIUDAD AS CIUDAD_PLAZA1, 
                        CO2.DOMICILIO AS DOMI1_PLAZA1,  CO2.DOMICILIO2 AS DOMI2_PLAZA1, CO2.PLANTA AS PLANTA_PLAZA1, CO2.NOTA AS NOTA_PLAZA1, CO2.RFC AS RFC_PLAZA1, 
                        CO3.NOMBRE AS NOMBRE_DESTINO, P2.CIUDAD AS CIUDAD_PLAZA2, 
                        CO3.DOMICILIO AS DOMI1_PLAZA2,  CO2.DOMICILIO2 AS DOMI2_PLAZA2, CO3.PLANTA AS PLANTA_PLAZA2, CO3.NOTA AS NOTA_PLAZA2, CO3.RFC AS RFC_PLAZA2, 
                        RE.DESCR AS RECOGER_EN_DESCR, EE.DESCR AS ENTREGAR_EN_DESC, ISNULL(VALOR_DECLA,0) AS DECLA, PROD.DESCR AS DESCR_CVE_ART
                        FROM GCCONTRATO C 
                        LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBS 
                        LEFT JOIN GCCLIE_OP CO1 ON CO1.CLAVE = C.NO_CONTRATO
                        LEFT JOIN GCCLIE_OP CO2 ON CO2.CLAVE = CLAVE_O
                        LEFT JOIN GCCLIE_OP CO3 ON CO3.CLAVE = CLAVE_D
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = CO2.CVE_PLAZA
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = CO3.CVE_PLAZA
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = C.RECOGER_EN
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = C.ENTREGAR_EN
                        LEFT JOIN GCPRODUCTOS PROD ON PROD.CVE_PROD = C.CVE_ART
                        WHERE C.STATUS = 'A' ORDER BY TRY_PARSE(CVE_CON AS INT) DESC"
                    Fg.Cols.Count = 21
                    Fg(0, 1) = "No. contrato"
                    Fg(0, 2) = "Nombre contrato"
                    Fg(0, 3) = "Origen"
                    Fg(0, 4) = "Ciudad"
                    Fg(0, 5) = "Domicilio"
                    Fg(0, 6) = "Domicilio2"
                    Fg(0, 7) = "Planta"
                    Fg(0, 8) = "Nota"
                    Fg(0, 9) = "R.F.C."
                    Fg(0, 10) = "Destino"
                    Fg(0, 11) = "Ciudad"
                    Fg(0, 12) = "Domicilio"
                    Fg(0, 13) = "Domicilio2"
                    Fg(0, 14) = "Planta"
                    Fg(0, 15) = "Nota"
                    Fg(0, 16) = "R.F.C."
                    Fg(0, 17) = "Recoger en"
                    Fg(0, 18) = "Entregar en"
                    Fg(0, 19) = "Valor declarado"
                    Fg(0, 20) = "Producto"
                    Me.Width = Screen.PrimaryScreen.Bounds.Width - 50
                    Fg.Width = Me.Width - 30
                Case "Detalle Rutas"
                    'Fg(0, 1) = "Clave"
                    'Fg(0, 2) = "Origen"
                    'Fg(0, 3) = "Destino"
                    'Fg(0, 4) = "Km recorridos"
                    'Fg(0, 5) = "Costo casetas"
                    'Fg(0, 6) = "Ejes"
                    SQL = "SELECT TRY_PARSE(D.CVE_RUTA AS INT) AS 'Clave', P1.CIUDAD AS 'Origen', P2.CIUDAD AS 'Destino', ISNULL(D.KM_RECORRIDOS,0) AS 'Km. Recorridos', " &
                        "ISNULL(D.COSTO_CASETAS,0) AS 'Costo casetas', ISNULL(D.EJES,0) AS 'Ejes' " &
                        "FROM GCDETALLE_RUTAS D " &
                        "LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = D.CVE_PLA1 " &
                        "LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = D.CVE_PLA2 " &
                        "WHERE D.STATUS = 'A' ORDER BY CVE_RUTA"
                    Fg.Cols.Count = 7
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Origen"
                    Fg(0, 3) = "Destino"
                    Fg(0, 4) = "Km recorridos"
                    Fg(0, 5) = "Costo casetas"
                    Fg(0, 6) = "Ejes"
                    Fg(0, 7) = "Tipo tanque"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 300
                    Fg.Cols(3).Width = 90
                    Fg.Cols(4).Width = 90
                    Fg.Cols(5).Width = 50
                    Fg.Cols(6).Width = 0
                    Fg.Cols(7).Width = 0
                Case "Unidades"
                    'SQL = "SELECT CVE_UNI, DESCR FROM GCTIPO_UNIDAD WHERE STATUS = 'A' ORDER BY CVE_UNI"
                    If TipoUnidad > 0 Then
                        If TipoUnidad = 1 Then
                            CADENA_UNIDAD = "U.CVE_TIPO_UNI = 1 OR U.CVE_TIPO_UNI = 7"
                        Else
                            CADENA_UNIDAD = "U.CVE_TIPO_UNI = " & TipoUnidad
                        End If
                        SQL = "Select TRY_PARSE(U.CLAVE As INT), U.CLAVEMONTE, U.DESCR As NOMB_UNIDAD, U.PLACAS_MEX, M.DESCR As MARCA, 
                            ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0), ISNULL(T.DESCR,'') AS TIPOUNI 
                            FROM GCUNIDADES U 
                            LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                            LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI 
                            WHERE ISNULL(U.STATUS, 'A') = 'A' AND (U.CVE_TIPO_UNI = 0 OR " & CADENA_UNIDAD & ") ORDER by U.CLAVEMONTE"
                        Var4 = ""
                    Else
                        SQL = "SELECT TRY_PARSE(U.CLAVE AS INT), U.CLAVEMONTE, U.DESCR AS TIPOUNI, U.PLACAS_MEX, M.DESCR AS MARCA, 
                            ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0), ISNULL(T.DESCR,'') AS TIPOUNI
                            FROM GCUNIDADES U 
                            LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                            LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI
                            WHERE ISNULL(U.STATUS, 'A') = 'A' ORDER BY U.CLAVEMONTE"
                    End If
                    Fg.Cols.Count = 9
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Unidad"
                    Fg(0, 3) = "Descripción unidad"
                    Fg(0, 4) = "Placas"
                    Fg(0, 5) = "Marca"
                    Fg(0, 6) = "Tipo unidad"
                    Fg(0, 7) = "CVE_TAQ"
                    Fg(0, 8) = "Tipo unidad"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 0
                    Fg.Cols(2).Width = 90
                    Fg.Cols(3).Width = 160
                    Fg.Cols(4).Width = 100
                    Fg.Cols(5).Width = 80
                    Fg.Cols(6).Width = 0
                    Fg.Cols(7).Width = 80
                    Fg.Cols(8).Width = 120
                    Me.Width = 800
                    Fg.Width = Me.Width - 20
                    Fg.Dock = DockStyle.Fill
                Case "UnidadesInspec"
                    'Proceso = Var2
                    'If IsNumeric(Var4) Then
                    'TipoUnidad = Var4
                    'Else
                    'TipoUnidad = 0
                    'End If
                    'PARAM_VAR = Var5
                    SQL = "SELECT TRY_PARSE(U.CLAVE AS INT), U.CLAVEMONTE, U.DESCR AS TIPOUNI, U.PLACAS_MEX, M.DESCR AS MARCA, 
                        ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0), ISNULL(T.DESCR,'') AS TIPOUNI
                        FROM GCUNIDADES U 
                        LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                        LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI
                        WHERE ISNULL(U.STATUS, 'A') = 'A'
                        ORDER BY U.CLAVEMONTE"

                    Fg.Cols.Count = 9
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Unidad"
                    Fg(0, 3) = "Descripción unidad"
                    Fg(0, 4) = "Placas"
                    Fg(0, 5) = "Marca"
                    Fg(0, 6) = "Tipo unidad"
                    Fg(0, 7) = "CVE_TAQ"
                    Fg(0, 8) = "Tipo unidad"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 90
                    Fg.Cols(3).Width = 220
                    Fg.Cols(4).Width = 100
                    Fg.Cols(5).Width = 80
                    Fg.Cols(6).Width = 80
                    Fg.Cols(7).Width = 80
                    Fg.Cols(8).Width = 120
                Case "Uni_Viaje"

                    If TipoUnidad = 1 Then
                        CADENA_UNIDAD = "U.CVE_TIPO_UNI = 1 OR U.CVE_TIPO_UNI = 7"
                    Else
                        CADENA_UNIDAD = "U.CVE_TIPO_UNI = " & TipoUnidad
                    End If

                    SQL = "SELECT A.CVE_VIAJE, U.CLAVEMONTE AS UNIDAD, T.DESCR AS TIPOUNI, U.PLACAS_MEX, M.DESCR AS MARCA, 
                        O.NOMBRE + ' (' + CAST(A.CVE_OPER AS VARCHAR(10)) + ')'
                        FROM GCUNIDADES U 
                        LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                        LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI 
                        INNER JOIN GCASIGNACION_VIAJE A ON A.CVE_TRACTOR = U.CLAVEMONTE
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                        WHERE ISNULL(U.STATUS, 'A') = 'A' AND (U.CVE_TIPO_UNI = 0 OR U.CVE_TIPO_UNI = 1 OR U.CVE_TIPO_UNI = 7) AND A.CVE_ST_VIA <> 5 " &
                        IIf(PARAM_VAR.Trim.Length > 0, " AND A.CVE_OPER = '" & PARAM_VAR & "'", "") & "
                        ORDER by A.FECHAELAB DESC"
                    Var4 = ""
                    Var5 = ""
                    Fg.Cols.Count = 7
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Viaje"
                    Fg(0, 2) = "Unidad"
                    Fg(0, 3) = "Tipo unidad"
                    Fg(0, 4) = "Placas"
                    Fg(0, 5) = "Marca"
                    Fg(0, 6) = "Operador"
                    Fg.Cols(0).Width = 15
                    Fg.Cols(1).Width = 75
                    Fg.Cols(2).Width = 50
                    Fg.Cols(3).Width = 140
                    Fg.Cols(4).Width = 80
                    Fg.Cols(5).Width = 80
                    Fg.Cols(6).Width = 350
                    Me.Width = 850
                    Fg.Width = Me.Width - 30
                Case "UniAsigViaje"
                    If TipoUnidad = 1 Then
                        CADENA_UNIDAD = "U.CVE_TIPO_UNI = 1 OR U.CVE_TIPO_UNI = 7"
                    Else
                        CADENA_UNIDAD = "U.CVE_TIPO_UNI = " & TipoUnidad
                    End If
                    SQL = "SELECT TRY_PARSE(U.CLAVE AS INT), U.CLAVEMONTE AS UNIDAD, T.DESCR AS TIPOUNI, U.PLACAS_MEX, M.DESCR AS MARCA, 
                            ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0)
                            FROM GCUNIDADES U 
                            LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                            LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI 
                            WHERE ISNULL(U.STATUS, 'A') = 'A' AND (U.CVE_TIPO_UNI = 0 OR " & CADENA_UNIDAD & ") ORDER by U.CLAVEMONTE"
                    Var4 = ""
                    Fg.Cols.Count = 8
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Unidad"
                    Fg(0, 3) = "Tipo unidad"
                    Fg(0, 4) = "Placas"
                    Fg(0, 5) = "Marca"
                    Fg(0, 6) = "Tipo unidad"
                    Fg(0, 7) = "CVE_TAQ"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 90
                    Fg.Cols(3).Width = 220
                    Fg.Cols(4).Width = 100
                    Fg.Cols(5).Width = 80
                    Fg.Cols(6).Width = 80
                    Fg.Cols(7).Width = 80
                Case "Cliente operativo"
                    If Var8.Trim.Length > 0 Then
                        If Var8 = "R" Or Var8 = "D" Then
                            SQL = "SELECT C.CLAVE, C.NOMBRE, C.DOMICILIO, ISNULL(C.NOTA,0) AS C_NOTA
                                FROM GCCLIE_OP C
                                WHERE C.STATUS = 'A' AND RD = '" & Var8 & "'  ORDER BY C.CLAVE"
                        Else
                            SQL = "SELECT C.CLAVE, C.NOMBRE, C.DOMICILIO, ISNULL(C.NOTA,0) AS C_NOTA
                                FROM GCCLIE_OP C
                                WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                        End If
                    Else
                        SQL = "SELECT C.CLAVE, C.NOMBRE, C.DOMICILIO, ISNULL(C.MUNICIPIO,0) AS C_NOTA
                            FROM GCCLIE_OP C
                            WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                    End If

                    Fg.Cols.Count = 5
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Nombre"
                    Fg(0, 3) = "Domicilio"
                    Fg(0, 4) = "Nota"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 60
                    Fg.Cols(2).Width = 200
                    Fg.Cols(3).Width = 200
                    Fg.Cols(4).Width = 100

                    Fg.Cols(1).StarWidth = "*"
                    Fg.Cols(2).StarWidth = "3*"
                    Fg.Cols(3).StarWidth = "3*"
                    Fg.Cols(4).StarWidth = "3*"



                    Me.Width = 950
                    Fg.Width = Me.Width - 30
                Case "RecogerEn", "EntregarEn"
                    SQL = "SELECT TRY_PARSE(CVE_REG AS INT) AS CVEREG, DESCR FROM GCRECOGER_EN_ENTREGAR_EN WHERE STATUS = 'A' ORDER BY TRY_PARSE(CVE_REG AS INT)"
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 400
                Case "Plazas"
                    SQL = "SELECT CLAVE, CIUDAD, MUNICIPIO FROM GCPLAZAS WHERE STATUS = 'A' ORDER BY CLAVE"
                    Fg.Cols.Count = 4
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Ciudad"
                    Fg(0, 3) = "municipio"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 60
                    Fg.Cols(2).Width = 240
                    Fg.Cols(3).Width = 240
                    'Fg.Cols(1).Width = 90
                    'Fg.Cols(2).Width = 120
                    'Fg.Cols(3).Width = 120
                Case "Operador"
                    SQL = "SELECT CLAVE, NOMBRE, LICENCIA, LIC_VENC FROM GCOPERADOR WHERE STATUS = 'A' ORDER BY CLAVE"
                    Fg.Cols.Count = 5
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Nombre"
                    Fg(0, 3) = "Licencia"
                    Fg(0, 4) = "Vigencia"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 70
                    Fg.Cols(2).Width = 250
                    Fg.Cols(3).Width = 90
                    Fg.Cols(4).Width = 90
                Case "GCPRODUCTOS", "Productos"
                    SQL = "SELECT CVE_PROD, DESCR FROM GCPRODUCTOS WHERE STATUS = 'A'"
                    Fg.Cols.Count = 3
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 140
                    Fg.Cols(2).Width = 475
                    Me.Width = 700
                    Fg.Width = Me.Width - 30
                Case "Valor Declarado"
                    SQL = "SELECT E.CLAVE, E.DESCR, E.IMPORTE 
                        FROM GCVALOR_DECLARADO E 
                        WHERE E.STATUS = 'A' ORDER BY E.CLAVE"
                    Fg.Cols.Count = 4
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Decripción"
                    Fg(0, 3) = "Importe"
                    Fg.Cols(0).Width = 20
                    Fg.Cols(1).Width = 60
                    Fg.Cols(2).Width = 200
                    Fg.Cols(3).Width = 100

                    Dim c As Column = Fg.Cols(3)
                    c.DataType = GetType(Decimal)
                    c.Format = "###,###,##0.00"
            End Select
            DESPLEGAR()

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Redraw = False
            Fg.Rows.Count = 1

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        Select Case Proceso
                            Case "Metodo de pago", "Marca reno", "Prov reno"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "ListaPrec", "Flujo"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "MinveEnt", "MinveSal"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "TipoActivo", "Depto"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "Gastos"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4))
                            Case "NumGen", "GCConc", "Embalaje", "Cargas", "tblcclaveunidad", "GCSERVICIOS_MANTE", "GCCLASIFIC_SERVICIOS"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "GCCATEVA"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2))
                            Case "tblcformapago"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "PagoComplemento", "PagoComplementoDocCte"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2))
                            Case "Tarifas"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab & dr(5))
                            Case "GCCASETAS_X_RUTA"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                               dr(5) & vbTab & dr(6) & vbTab & dr(7))
                                Fg.Rows(Fg.Rows.Count - 1).Style = NewStyle1
                            Case "Carta porte", "PAGO CFDI"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4))
                            Case "FAC CFDI"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab & dr(5))
                            Case "FACTURA CFDI"
                                'SELECT TOP 2000 CFDI.FACTURA, P.CLAVE, P.NOMBRE, FECHA_DOC, F.IMPORTE, CFDI.FECHAELAB, CFDI.CLIENTE, P2.NOMBRE AS NOMBRE2
                                If dr(1).ToString.Trim.Length > 0 Then
                                    Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4))
                                Else
                                    Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(6) & vbTab & dr(7) & vbTab & dr(5) & vbTab & dr(8))
                                End If

                            Case "Pedidos", "PedidosProg"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6))
                            Case "Vend"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "InveR", "InvenRS", "InvenRP", "Inventario"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab & dr(5))
                            Case "Prov"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3))
                            Case "FACTURA"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3))
                            Case "Articulo", "ArticulosLlantas"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2))
                            Case "InveP", "InveS"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6))
                            Case "Operador", "GCSERVICIOS"
                                'SQL = "SELECT CLAVE, NOMBRE, LICENCIA, LIC_VENC FROM GCOPERADOR WHERE STATUS = 'A' ORDER BY CLAVE"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3))
                            Case "Cliente operativo"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3))
                            Case "Detalle Rutas"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6))
                            Case "Unidades", "UnidadesInspec"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6) & vbTab & dr(7))
                            Case "Uni_Viaje"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5))
                            Case "RecogerEn", "EntregarEn", "GCPRODUCTOS", "Productos"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "Plazas", "Valor Declarado"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2))
                            Case "ReseteoTab"
                                '    0       1                                2          3                                  4        
                                'CVE_TAB, CVE_ORI, ISNULL(P1.CIUDAD,'') AS DESCR_ORI, CVE_DES, ISNULL(P2.CIUDAD,'') AS DESCR_DES, 
                                '                                                                         5                                 6
                                'Case ISNULL(CARGADO_VACIO,0) WHEN 0 THEN 'Vacio' ELSE 'Cargado' END AS CAR_VAC, ISNULL(TIPO_VIAJE,'') AS VIAJE, 
                                '   7          8                      9                           10
                                'CLIENTE, C.NOMBRE, ISNULL(KMS,0) As KM, ISNULL(RENDIMIENTO,0) As LTS 
                                'From GCTABULADOR_PAR T 
                                'Left JOIN GCCLIE_OP C On C.CLAVE = CLIENTE 
                                'Left JOIN GCPLAZAS P1 On P1.CLAVE = CVE_ORI 
                                'Left JOIN GCPLAZAS P2 On P2.CLAVE = CVE_DES 
                                'ORDER BY CVE_TAB DESC"
                                Try
                                    Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                               dr(5) & vbTab & dr(6) & vbTab & dr(7) & vbTab & dr(8) & vbTab & dr(9) & vbTab & dr(10) & vbTab &
                                               IIf(dr(10) > 0, (dr(9) / dr(10)), 0) & vbTab & dr(11))
                                    Fg.Rows(Fg.Rows.Count - 1).Style = NewStyle1
                                Catch ex As Exception
                                    Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
                                End Try
                            Case "Contrato"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6) & vbTab & dr(7) & vbTab & dr(8) & vbTab & dr(9) & vbTab & dr(10) & vbTab &
                                           dr(11) & vbTab & dr(12) & vbTab & dr(13) & vbTab & dr(14) & vbTab & dr(15) & vbTab & dr(16) & vbTab &
                                           dr(17) & vbTab & dr(18) & vbTab & dr(19))
                            Case "Sueldo operadores"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6))
                            Case "Reseteo", "ReseteoVikingos"
                                Fg.AddItem("" & vbTab & dr("CVE_RES") & vbTab & dr("STATUS") & vbTab & dr("ESTADO") & vbTab & dr("FECHA") & vbTab &
                                   dr("NOMBRE") & vbTab & dr("CLAVEMONTE") & vbTab & dr("NOMBREMOTOR") & vbTab & dr("CAL_FAC_CAR_EVA") & vbTab &
                                   dr("CAL_RAL_EVA") & vbTab & dr("CALIF_VEL_MAX") & vbTab & dr("CAL_GLO_EVA") & vbTab &
                                   dr("BONO_RES") & vbTab & dr("ODOMETRO") & vbTab & dr("KM_ECM") & vbTab & dr("LTS_ECM") & vbTab &
                                   dr("LTS_REAL") & vbTab & dr("KMS_TAB") & vbTab & dr("LTS_TAB") & vbTab & dr("FAC_CARGA") & vbTab & dr("HRS_TRABAJO") & vbTab &
                                   dr("HRS_PTO_RALENTI") & vbTab & dr("LTS_PTO_RALENTI") & vbTab & dr("PORC_TIEMPO_PTO_RALENTI") & vbTab &
                                   dr("PORC_LTS_PTO_RALENTI") & vbTab & dr("REND_ECM") & vbTab & dr("PORC_VAR_LTS_ECM_REAL") & vbTab &
                                   dr("PORC_VAR_LTS_TAB_REAL") & vbTab & dr("REND_REAL") & vbTab & dr("DIF_LTS_REAL_LTS_ECM") & vbTab &
                                   dr("DIF_LTS_REAL_LTS_TAB"))
                            Case "Pedidos"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6) & vbTab & dr(7) & vbTab & dr(8) & vbTab & dr(9) & vbTab & dr(10))
                            Case "GCTAB_RUTAS"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6) & vbTab & dr(7) & vbTab & dr(8) & vbTab & dr(9) & vbTab & dr(10))
                            Case "RUTAS FLORES"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6) & vbTab & dr(7) & vbTab & dr(8) & vbTab & dr(9) & vbTab & dr(10) & vbTab &
                                           dr(11) & vbTab & dr(12) & vbTab & dr(13))
                            Case "Clientes", "Clie01", "Clie"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6) & vbTab & dr(7))
                            Case "CTE_CREDITO"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab & dr(5))
                            Case "CTE_POS"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                           dr(5) & vbTab & dr(6) & vbTab & dr(7) & vbTab & dr(8))
                        End Select
                    End While
                End Using
            End Using

            Select Case Proceso
                Case "ReseteoTab"
                    Fg.Rows(0).Style = NewStyle1
                    Fg.AutoSizeRows()
                    Fg.Rows(0).Height = 50
                Case "Contrato", "Carta porte", "FAC CFDI"
                    Fg.Rows(0).Style = NewStyle1
                    Fg.AutoSizeCols()
                    Fg.Rows(0).Height = 50
                Case "Sueldo operadores"
                    Fg.AutoSizeCols()
                Case "Reseteo", "ReseteoVikingos"
                    Fg.AutoSizeCols()
                    Fg.Rows(0).Height = 50
                Case "Pedidos", "GCTAB_RUTAS", "PedidosProg", "RUTAS FLORES", "PagoComplementoDocCte"
                    Fg.Rows(0).Height = 50
                Case "PagoComplemento"
                    Fg.Rows(0).Height = 40
                Case "ListaPrec"
                    Me.Height = ToolStrip1.Height + (Fg.Rows.DefaultSize * (Fg.Rows.Count)) + 30
                Case "MinveEnt", "MinveSal"
                    Me.Height = ToolStrip1.Height + (Fg.Rows.DefaultSize * (Fg.Rows.Count)) + 30
            End Select


            Fg.Rows(0).StyleNew.WordWrap = True
            Fg.Rows(0).StyleNew.TextAlign = TextAlignEnum.LeftCenter

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub FrmSelItem2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarBuscar_Click(sender As Object, e As EventArgs) Handles barBuscar.Click
        Try
            Select Case Proceso
                Case "Metodo de pago", "Marca reno", "Prov reno"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'DESCR
                    End If
                Case "ListaPrec", "Flujo"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'DESCR
                    End If
                Case "MinveEnt", "MinveSal"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'DESCR
                    End If
                Case "Tarifas"
                    If Fg.Row > 0 Then
                        'SQL = "SELECT DESCRIPCION, PRECIO, ISNULL(CVE_TIPO_OPE,0) AS C_T_OPE, ISNULL(TP.DESCR,'') AS DES, 
                        'ISNULL(PRECIO_X_TANQUE,0) AS PRE_X_TANQUE, R.CVE_ART

                        Var4 = Fg(Fg.Row, 2) 'PRECIO
                        Var5 = Fg(Fg.Row, 1) 'DESCR
                        Var7 = Fg(Fg.Row, 3) 'tipo OPERACION
                        Var8 = Fg(Fg.Row, 4) 'descr tipo OPERACION
                        Var6 = Var4
                        Var9 = Fg(Fg.Row, 5) 'PRECIO X TANQUE
                        Var10 = Fg(Fg.Row, 6) 'CVE_ART
                    End If
                Case "GCCASETAS_X_RUTA"
                    If Fg.Row > 0 Then
                        'Fg(0, 1) = "Clave"
                        'Fg(0, 2) = "Cve. plaza1"
                        'Fg(0, 3) = "Cve. plaza2"
                        'Fg(0, 4) = "Ciudad plaza1"
                        'Fg(0, 5) = "Ciudad plaza2"
                        'Fg(0, 6) = "Importe"
                        'Fg(0, 7) = "Cliente operativos"
                        'Fg(0, 8) = "Operador"
                        'Fg(0, 9) = "IAVE"
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 4) 'CVE_PLAZA1
                        Var6 = Fg(Fg.Row, 5) 'CVE_PLAZA2
                    End If
                Case "FACTURA CFDI", "PAGO CFDI"
                    If Fg.Row > 0 Then
                        'Fg(0, 1) = "Factura"
                        'Fg(0, 2) = "Cliente"
                        'Fg(0, 3) = "Nombre"
                        'Fg(0, 4) = "Fecha"
                        'Fg(0, 5) = "Importe"
                        Var4 = Fg(Fg.Row, 1) 'FACTURA
                        Var5 = Fg(Fg.Row, 2) 'CLIENTE
                        Var6 = Fg(Fg.Row, 3) 'NOMBRE
                        Var7 = Fg(Fg.Row, 4) 'FECHA
                    End If
                Case "FAC CFDI"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'FACTURA
                        Var5 = Fg(Fg.Row, 2) 'CARTA PORTE 1
                        Var6 = Fg(Fg.Row, 3) 'CARTA PORTE 2
                        Var7 = Fg(Fg.Row, 5) 'NOMBRE
                    End If
                Case "Carta porte"
                    If Fg.Row > 0 Then
                        'SELECT F.FACTURA, F.DOCUMENT, F.DOCUMENT2, F.CLIENTE, C.NOMBRE, F.FECHAELAB
                        'Fg(0, 1) = "FACTURA"
                        'Fg(0, 2) = "Carta porte 2"
                        'Fg(0, 3) = "Factura"
                        'Fg(0, 4) = "Usuario"
                        'Fg(0, 5) = "Fecha"

                        Var4 = Fg(Fg.Row, 1) 'FACTURA
                        Var5 = Fg(Fg.Row, 3) 'CARTA PORTE 2
                        Var6 = Fg(Fg.Row, 2) 'CARTA PORTE 1
                        Var7 = Fg(Fg.Row, 6) 'FECHA
                    End If
                Case "Pedidos", "PedidosProg"
                    'P.CVE_DOC, P.CVE_CON, P.CVE_CLIE, C.NOMBRE, P.CVE_ART, I.DESCR, P.FECHA, P1.CIUDAD AS ORIGEN,
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CVE_DOC
                        Var5 = Fg(Fg.Row, 2) 'CVE_CON
                        Var6 = Fg(Fg.Row, 3) 'CVE_CLIE
                    End If
                Case "Vend"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                    End If

                Case "InveR", "InvenRS", "InvenRP", "Inventario"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                        Var6 = Fg(Fg.Row, 3).ToString 'ALTERNA
                        Var7 = Fg(Fg.Row, 4).ToString 'EXIST
                        Var8 = Fg(Fg.Row, 5).ToString 'TIPO ELE
                    End If
                Case "CTE_POS"
                    'SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, LISTA_PREC, C.DESCUENTO, C.CALLE, USO_CFDI, ISNULL(REG_FISC,'') AS REGFISC
                    'From CLIE" & Empresa & " C
                    'Where c.STATUS = 'A' AND CON_CREDITO = 'S' ORDER BY C.CLAVE"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                        Var6 = Fg(Fg.Row, 3).ToString 'rfc
                        Var7 = Fg(Fg.Row, 4).ToString 'LISTA PREC
                        Var8 = Fg(Fg.Row, 5).ToString 'DESC
                        Var9 = Fg(Fg.Row, 6).ToString 'calle
                        Var10 = Fg(Fg.Row, 7).ToString 'USO CFDI
                        Var11 = Fg(Fg.Row, 8).ToString 'RES FISC
                    End If
                Case "CTE_CREDITO"
                    'SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, ISNULL(CAMPLIB5,0) AS LIB5 " &
                    '   "FROM CLIE" & Empresa & " C " &
                    '  "LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = C.CLAVE " &
                    '  "WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                        Var6 = Fg(Fg.Row, 3).ToString 'rfc
                        Var7 = Fg(Fg.Row, 4).ToString 'calle
                    End If
                Case "Clientes", "Prov", "Clie01", "Clie"
                    'SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, ISNULL(CAMPLIB5,0) AS LIB5 " &
                    '   "FROM CLIE" & Empresa & " C " &
                    '  "LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = C.CLAVE " &
                    '  "WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                        Var6 = Fg(Fg.Row, 3).ToString 'rfc
                        Var7 = Fg(Fg.Row, 4).ToString 'calle
                        If Proceso <> "Prov" Then
                            Var8 = Fg(Fg.Row, 5).ToString 'porc
                            Var9 = Fg(Fg.Row, 6).ToString 'porc o monto
                            Var10 = Fg(Fg.Row, 7).ToString 'USO CFDI
                            Var11 = Fg(Fg.Row, 8) 'regimen fiscal
                        Else
                            Var8 = "0"
                            Var9 = "0"
                        End If
                    End If
                Case "Zona", "Vend", "Listaprec", "Pais", "Tractor", "Articulo", "Grupo Unidades", "Placas Defa", "Servicios",
                     "GCPRODUCTOS", "Productos", "Estados", "ServiciosOrdenes", "ArticulosLlantas", "FACTURA", "Flujo"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                    End If
                Case "InveP", "InveS"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                        Var7 = Fg(Fg.Row, 3).ToString 'PRECIOS
                        Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                        Var8 = Fg(Fg.Row, 6).ToString 'TIPO PROD
                        Var9 = Fg(Fg.Row, 7).ToString 'COSTO PROM
                    End If
                Case "Pedidos", "GCTAB_RUTAS", "RUTAS FLORES"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1)
                        Var5 = Fg(Fg.Row, 2).ToString '
                        Var6 = Fg(Fg.Row, 3).ToString '

                        Var7 = Fg(Fg.Row, 3).ToString '
                        Var8 = Fg(Fg.Row, 4).ToString '
                    End If
                Case "Reseteo", "ReseteoVikingos"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                    End If
                Case "Gastos"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                        Var6 = Fg(Fg.Row, 3).ToString 'ALTERNA
                        Var7 = Fg(Fg.Row, 4).ToString 'EXIST
                        Var8 = Fg(Fg.Row, 5).ToString 'TIPO ELE
                    End If
                Case "TipoActivo", "Depto"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString   'NOMBRE
                    End If
                Case "NumGen"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString   'NOMBRE
                    End If
                Case "GCCATEVA"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString   'NOMBRE MOTOR
                        Var6 = Fg(Fg.Row, 3).ToString   'FULL SENCILLO
                    End If
                Case "GCConc", "Embalaje", "Cargas", "tblcclaveunidad", "GCSERVICIOS_MANTE", "GCCLASIFIC_SERVICIOS"
                    '"SELECT CVE_GAS, DESCR FROM GCCONC_GASTOS WHERE STATUS = 'A' ORDER BY CVE_GAS"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString   'NOMBRE MOTOR
                    End If

                Case "tblcformapago"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                    End If
                Case "PagoComplemento", "PagoComplementoDocCte", "PAGO CFDI"
                    If Fg.Row > 0 Then
                        'SELECT M.DOCTO, M.CVE_CLIE, P.NOMBRE
                        'Fg(0, 1) = "Documento"
                        'Fg(0, 2) = "Cliente"
                        'Fg(0, 3) = "Nombre"
                        Var4 = Fg(Fg.Row, 1).ToString   'DOCUMENTO
                        Var5 = Fg(Fg.Row, 2).ToString   'CLIENTE
                    End If
                Case "Sueldo operadores"
                    'Fg(0, 1) = "Clave"
                    'Fg(0, 2) = "Cliente"
                    'Fg(0, 3) = "Origen"
                    'Fg(0, 4) = "Destino"
                    'Fg(0, 5) = "Full/Sencillo"
                    'Fg(0, 6) = "Cargado/Vacio"
                    'Fg(0, 7) = "Sueldo"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString   'CIENTE
                        Var6 = Fg(Fg.Row, 3).ToString   'ORIGEN
                        Var7 = Fg(Fg.Row, 4).ToString   'DESTINO
                        Var8 = Fg(Fg.Row, 7).ToString   'SUELDO
                    End If
                Case "ReseteoTab"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  'CVE_TAB
                    End If
                Case "Contrato", "GCSERVICIOS"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                        Var6 = Fg(Fg.Row, 3) 'LICENCIA
                        Var7 = Fg(Fg.Row, 4) 'VIGENCIA
                    End If
                Case "Operador"
                    If Fg.Row > 0 Then
                        'SQL = "SELECT CLAVE, NOMBRE, LICENCIA, LIC_VENC FROM GCOPERADOR WHERE STATUS = 'A' ORDER BY CLAVE"
                        Var4 = Fg(Fg.Row, 1).ToString  'CVE_CON
                        Var5 = Fg(Fg.Row, 2).ToString  'NO_CONTRATO
                        Var6 = Fg(Fg.Row, 3).ToString  'CLAVE
                        Var7 = Fg(Fg.Row, 4).ToString  'NOMBRE
                    End If
                Case "Detalle Rutas"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1)          'CVE_RUTA
                        Var5 = Fg(Fg.Row, 2).ToString 'origen
                        Var6 = Fg(Fg.Row, 3).ToString 'destino
                        Var7 = Fg(Fg.Row, 4).ToString 'KM RECORRIDOS
                        Var8 = Fg(Fg.Row, 5).ToString 'COSTO_CASETAS
                        Var9 = Fg(Fg.Row, 6).ToString 'EJES
                    End If
                Case "Unidades", "UnidadesInspec"
                    'Select Case TRY_PARSE(u.CLAVE As INT), U.CLAVEMONTE, U.DESCR As TIPOUNI, U.PLACAS_MEX, M.DESCR As MARCA, 
                    'ISNULL(u.CVE_TIPO_UNI, 0) As TIPO_UNI, ISNULL(CVE_TAQ,0), ISNULL(T.DESCR,'') AS TIPOUNI

                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  'CLAVE unidad
                        Var3 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE NUM ECONOMICO
                        Var5 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE NUM ECONOMICO
                        Var6 = Fg(Fg.Row, 3).ToString   'DESCR TIPO UNIDAD
                        Var7 = Fg(Fg.Row, 4).ToString   'PLACAS
                        Var8 = Fg(Fg.Row, 5).ToString   'MARCA UNIDAD
                        Var9 = Fg(Fg.Row, 6).ToString   'CVE_TIPO UNI
                        Var11 = Fg(Fg.Row, 8).ToString   'descr CVE_TIPO UNI
                        If Not IsNothing(Fg(Fg.Row, 7)) Then
                            Var10 = Fg(Fg.Row, 7).ToString   'CVE_TAQ
                        End If
                    End If
                Case "Uni_Viaje"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  'CLAVE CVE_VIAJE
                        Var3 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE NUM ECONOMICO
                        Var5 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE NUM ECONOMICO
                        Var6 = Fg(Fg.Row, 3).ToString   'DESCR TIPO UNIDAD
                        Var7 = Fg(Fg.Row, 4).ToString   'PLACAS
                        Var8 = Fg(Fg.Row, 5).ToString   'MARCA UNIDAD
                        Var9 = Fg(Fg.Row, 6).ToString   'CVE_TIPO UNI
                        If Not IsNothing(Fg(Fg.Row, 7)) Then
                            Var10 = Fg(Fg.Row, 7).ToString   'CVE_TAQ
                        End If
                    End If
                Case "Cliente operativo"
                    If Fg.Row > 0 Then
                        '"SELECT TRY_PARSE(C.CLAVE AS INT), C.NOMBRE, ISNULL(P1.CIUDAD,'') AS PLAZA, C.DOMICILIO
                        Var4 = Fg(Fg.Row, 1) 'CLAVE 
                        Var5 = Fg(Fg.Row, 2).ToString 'nombre cliente operativo
                        Var6 = Fg(Fg.Row, 3).ToString 'plaza ciudad
                        Var7 = Fg(Fg.Row, 4).ToString 'domicilio cliente op
                    End If
                Case "Plazas", "Valor Declarado"
                    If Fg.Row > 0 Then
                        '"SELECT TRY_PARSE(C.CLAVE AS INT), C.NOMBRE, ISNULL(P1.CIUDAD,'') AS PLAZA, C.DOMICILIO
                        Var4 = Fg(Fg.Row, 1) 'CLAVE 
                        Var5 = Fg(Fg.Row, 2).ToString 'nombre cliente operativo
                        Var6 = Fg(Fg.Row, 3).ToString 'plaza ciudad
                    End If
                Case "RecogerEn", "EntregarEn", "GCPRODUCTOS", "Productos"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  '
                        Var5 = Fg(Fg.Row, 2).ToString  '
                    End If
            End Select
            Me.Close()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles barRefresh.Click
        Dim CADENA_UNIDAD As String

        Try
            tBox.Text = ""
            Select Case Proceso
                Case "GCSERVICIOS"
                    SQL = "SELECT S.CVE_SER, S.DESCR, S.COSTO_MO, 
                        CASE S.TIPO_SERVICIO WHEN 0 THEN 'Preventivo' ELSE 'Correctivo' END AS 'Tipo de servicio' 
                        FROM GCSERVICIOS S 
                        ORDER BY TRY_PARSE(CVE_SER AS INT) DESC"
                Case "GCSERVICIOS_MANTE"
                    SQL = "SELECT CVE_SER, DESCR 
                        FROM GCSERVICIOS_MANTE WHERE STATUS = 'A' ORDER BY TRY_PARSE(CVE_SER AS INT)"
                Case "GCCLASIFIC_SERVICIOS"
                    SQL = "SELECT CVE_CLA, DESCR FROM GCCLASIFIC_SERVICIOS WHERE STATUS = 'A'"
                Case "Marca reno"
                    SQL = "SELECT CVE_MARCA, DESCR
                        FROM GCMARCAS_RENOVADO WHERE STATUS = 'A'
                        ORDER BY TRY_PARSE(CVE_MARCA AS INT)"
                Case "Prov reno"
                    SQL = "SELECT CVE_PRE, DESCR
                        FROM GCPROVRENOVADO WHERE STATUS = 'A'
                        ORDER BY TRY_PARSE(CVE_PRE AS INT)"
                Case "Metodo de pago"
                    SQL = "SELECT metodoPago, descripcion
                        FROM tblcmetodopago
                        ORDER BY id"
                Case "ListaPrec"
                    SQL = "SELECT CLAVE, DESCR
                        FROM SOENTRADADINERO
                        WHERE TIPO = '" & PARAM_VAR & "' ORDER BY CLAVE"
                    SQL = "SELECT CVE_PRECIO, DESCRIPCION
                        FROM PRECIOS" & Empresa & "
                        WHERE STATUS = 'A'
                        ORDER BY CVE_PRECIO"
                Case "MinveEnt", "MinveSal"
                    SQL = "SELECT CVE_CPTO, DESCR
                        FROM CONM" & Empresa & "
                        WHERE STATUS = 'A' " & Var7 & "
                        ORDER BY CVE_CPTO"
                Case "Depto"
                    SQL = "SELECT CVE_DEPTO, DESCR
                        FROM GCDEPTOS 
                        WHERE STATUS = 'A'
                        ORDER BY TRY_PARSE(CVE_DEPTO AS INT)"
                Case "TipoActivo"
                    SQL = "SELECT CLAVE, DESCRIP
                        FROM GCTIPACTIV ORDER BY CLAVE"
                Case "Gastos"
                    SQL = "SELECT G.CVE_ART, G.DESCR, COSTO, DESC_LIN, DESCRIPESQ
                        FROM GCCATGASTOS G
                        LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = G.LINEA
                        LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = G.CVE_ESQIMPU
                        WHERE G.STATUS = 'A'    
                        ORDER BY CVE_ART"
                Case "PAGO CFDI"
                    SQL = "SELECT TOP 2000 CVE_DOC, CLIENTE, NOMBRE, FECHA, IMPORTE
                        FROM CFDI_COMPAGO PC 
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = PC.CLIENTE
                        WHERE PC.CLIENTE = '" & Var25 & "' 
                        ORDER BY FECHAELAB DESC"
                Case "FACTURA CFDI"
                    SQL = "SELECT TOP 2000 CFDI.FACTURA, P.CLAVE, P.NOMBRE, FECHA_DOC, F.IMPORTE,
                        CFDI.FECHAELAB, CFDI.CLIENTE, P2.NOMBRE AS NOMBRE2, CFDI.IMPORTE
                        FROM CFDI 
                        LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = CFDI.FACTURA
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                        LEFT JOIN CLIE" & Empresa & " P2 ON P2.CLAVE = CFDI.CLIENTE
                        WHERE ISNULL(F.STATUS,'') <> 'C' AND ISNULL(CFDI.ESTATUS,'') <> 'C'
                        ORDER BY F.FECHAELAB DESC"
                Case "NumGen"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES
                        FROM GCHORAS_GEN 
                        ORDER BY CVE_GEN"
                Case "GCConc"
                    SQL = "SELECT CVE_GAS, DESCR, CLASIFIC FROM GCCONC_GASTOS WHERE STATUS = 'A' ORDER BY CVE_GAS"
                Case "Embalaje"
                    SQL = "SELECT CLAVE, DESCR FROM GCEMBALAJE WHERE STATUS = 'A' ORDER BY TRY_PARSE(CLAVE AS INT)"
                Case "Cargas"
                    SQL = "SELECT CLAVE, DESCR FROM GCCARGAS WHERE STATUS = 'A' ORDER BY TRY_PARSE(CLAVE AS INT)"
                Case "tblcclaveunidad"
                    SQL = "SELECT claveUnidad, nombre FROM tblcclaveunidad ORDER BY claveUnidad"

                Case "GCCATEVA"
                    SQL = "SELECT E.CVE_EVA, M.DESCR, CASE WHEN E.TIPO_VIAJE = 1 THEN 'FULL' ELSE 'SENCILLO' END AS TIPVIAJE
                        FROM GCCATEVA E
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = E.CVE_MOT
                        WHERE E.STATUS = 'A' ORDER BY E.CVE_EVA"
                Case "tblcformapago"
                    SQL = "SELECT formaPago, descripcion FROM tblcformapago ORDER BY formaPago"

                Case "PagoComplemento", "PagoComplementoDocCte"
                    SQL = "SELECT M.DOCTO, M.CVE_CLIE, MAX(P.NOMBRE)
                        FROM CUEN_DET" & Empresa & " M
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE 
                        LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = M.REFER
                        LEFT JOIN MONED" & Empresa & " N ON N.NUM_MONED = M.NUM_MONED 
                        WHERE ISNULL(F.METODODEPAGO,'PPD') = 'PPD' AND ISNULL(F.FORMADEPAGOSAT,'99') = 99 AND 
                        ISNULL(CVE_DOC_COMPPAGO,'') = '' AND M.CVE_CLIE = '" & PARAM_VAR & "' 
                        GROUP BY M.CVE_CLIE, M.DOCTO
                        ORDER BY M.CVE_CLIE, M.REFER"
                Case "Tarifas"
                    SQL = "SELECT DESCRIPCION, PRECIO, ISNULL(CVE_TIPO_OPE,0) AS C_T_OPE, ISNULL(TP.DESCR,'') AS DES, 
                        ISNULL(PRECIO_X_TANQUE,0) AS PRE_X_TANQUE, R.CVE_ART
                        FROM GCTARIFAS T 
                        LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_TAB = T.CVE_RUTA
                        LEFT JOIN GCTIPO_OPERACION TP ON TP.CVE_TIPO = R.CVE_TIPO_OPE
                        LEFT JOIN PRECIOS" & Empresa & " P ON P.CVE_PRECIO = T.CVE_PRECIO
                        WHERE CVE_CON = '" & Var3 & "' ORDER BY T.CVE_PRECIO"
                Case "GCCASETAS_X_RUTA"
                    SQL = "SELECT C.CVE_CXR, C.CVE_PLAZA, C.CVE_PLAZA2, P1.CIUDAD AS CIUDAD1, P2.CIUDAD AS CIUDAD2, 
                        ISNULL(IMPORTE_CASETAS,0) AS IMPORTE, OP.NOMBRE, OP.NOMBRE, C.IAVE
                        FROM GCCASETAS_X_RUTA C 
                        LEFT JOIN GCCLIE_OP OP On OP.CLAVE = C.CLAVE_OP
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA 
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = C.CVE_PLAZA2
                        WHERE C.STATUS = 'A' ORDER BY CVE_CXR"
                Case "FAC CFDI"
                    SQL = "SELECT TOP 1000 F.FACTURA, F.DOCUMENT, F.DOCUMENT2, F.CLIENTE, C.NOMBRE, F.FECHAELAB
                        FROM CFDI F
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE
                        Order By FECHAELAB DESC"
                Case "Carta porte"
                    SQL = "SELECT TOP 1000 DOCUMENT, DOCUMENT2, FACTURA, USUARIO, FECHAELAB
                        From CFDI Order By FECHAELAB DESC"
                Case "Carta porte2"
                    SQL = "SELECT TOP 500 CVE_FOLIO, ISNULL(ST.DESCR,'EDICION') AS ST_CARTAP, ORDEN_DE, CVE_VIAJE, P.CVE_DOCP, 
                        CASE ISNULL(P.CVE_DOCR,'') WHEN '0' THEN '' WHEN '' THEN '' ELSE P.CVE_DOCR END, '(' + LTRIM(RTRIM(P.CLIENTE)) + ') ' + C.NOMBRE,
                        P.FECHAELAB, 
                        (CASE P.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI,
                        (CASE P.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, O.NOMBRE AS OPER, P.CVE_TRACTOR,
                        P.CVE_TANQUE1, P.CVE_TANQUE2, P.CVE_DOLLY, RE.DESCR AS RECEN, EE.DESCR AS ENTEN, 
                        (CASE P.CONCILIADO WHEN 1 THEN 'Conciliado' ELSE '' END) AS CONCI, 
                        ISNULL(CVE_MAT,'') AS CVE_MAT, ISNULL(VALOR_DECLARADO,0) AS VAL_CLA
                        FROM GCCARTA_PORTE P
                        LEFT JOIN GCSTATUS_CARTA_PORTE ST ON ST.CVE_CAP = P.ST_CARTA_PORTE
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN
                        ORDER BY P.FECHAELAB DESC"
                Case "PedidosProg"
                    SQL = "SELECT P.CVE_DOC, C3.NOMBRE, I.DESCR, P.FECHA_CARGA, P.FECHA_DESCARGA, RE.DESCR As RECIBIR_E, EE.DESCR AS RECOGER_E
                        FROM GCPEDIDOSPROG P
                        LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                        LEFT JOIN GCCONTRATO CT ON CT.CVE_CON = P.CVE_CON 
                        LEFT JOIN GCCLIE_OP C3 ON C3.CLAVE = CT.NO_CONTRATO 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN
                        WHERE P.STATUS = 'A' AND ISNULL(CVE_VIAJE,'') = '' AND 
                        NOT EXISTS (SELECT PED_ENLAZADO FROM GCPEDIDOS WHERE PED_ENLAZADO = P.CVE_DOC)
                        ORDER BY P.FECHAELAB DESC"
                Case "Vend"
                    SQL = "SELECT CVE_VEND, NOMBRE FROM VEND" & Empresa & "  WHERE STATUS = 'A' ORDER BY NOMBRE"
                Case "InveR", "InvenRS", "InvenRP", "Inventario"
                    ' --------------------               MULTIALMACEN      -----------------------
                    ' --------------------               MULTIALMACEN      -----------------------
                    ' --------------------               MULTIALMACEN      -----------------------
                    If G_ALM = 0 Then G_ALM = 1
                    If MULTIALMACEN = 0 Then
                        SQL = "SELECT CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS NUM_PARTE, 
                            EXIST, TIPO_ELE, STATUS 
                            FROM INVE" & Empresa & " I WHERE I.STATUS = 'A' AND I.TIPO_ELE <> 'K' ORDER BY I.DESCR"
                    Else
                        SQL = "SELECT M.CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = M.CVE_ART) AS NUM_PARTE, 
                            M.EXIST, I.TIPO_ELE, M.STATUS 
                            FROM MULT" & Empresa & " M 
                            LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                            WHERE I.STATUS = 'A' AND M.STATUS = 'A' AND I.TIPO_ELE <> 'K' AND CVE_ALM = " & G_ALM & " ORDER BY I.DESCR"
                    End If
                    ' --------------------               MULTIALMACEN      -----------------------
                Case "Prov"
                    SQL = "SELECT CLAVE, NOMBRE, RFC, CALLE FROM PROV" & Empresa & " WHERE STATUS = 'A' ORDER BY CLAVE"
                Case "Articulo", "FACTURA"
                    SQL = "SELECT CVE_ART, ISNULL(DESCR,'') AS DES, ISNULL(EXIST,0) AS EXI, LIN_PROD 
                        FROM INVE" & Empresa & " 
                        WHERE STATUS = 'A' AND TIPO_ELE <> 'K' AND CVE_ART <> 'TOT' 
                        ORDER BY DESCR"
                Case "InveS"
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, 
                        EXIST, TIPO_ELE, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I 
                        LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'S' ORDER BY CVE_ART"
                Case "InveP", "InveLiq"
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, 
                        EXIST, TIPO_ELE, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I 
                        LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'P' ORDER BY CVE_ART"
                Case "Clientes", "Clie01", "Clie"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, ISNULL(CAMPLIB5,0) AS LIB5, ISNULL(CAMPLIB6,0) AS LIB6, USO_CFDI, 
                        ISNULL(REG_FISC,'') AS REGFISC
                        FROM CLIE" & Empresa & " C
                        LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = C.CLAVE
                        WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                Case "CTE_POS"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, CASE WHEN ISNULL(LISTA_PREC,0) < 1 THEN 1 ELSE LISTA_PREC END AS LISTAPREC, 
                        C.DESCUENTO, C.CALLE, USO_CFDI, ISNULL(REG_FISC,'') AS REGFISC, 
                        CASE WHEN ISNULL(CON_CREDITO,'') = 'S' THEN 'Si' ELSE 'No' END AS CONCRED
                        FROM CLIE" & Empresa & " C
                        WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                Case "CTE_CREDITO"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, USO_CFDI, ISNULL(REG_FISC,'') AS REGFISC
                        FROM CLIE" & Empresa & " C
                        WHERE C.STATUS = 'A' AND ISNULL(CON_CREDITO,'') = 'S' ORDER BY C.CLAVE"

                Case "Reseteo"
                    SQL = "SELECT TOP 1000 R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, NOMBRE, R.CVE_UNI, U.CLAVEMONTE, M.DESCR AS NOMBREMOTOR, 
                        R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, CAL_GLO_EVA, BONO_RES, R.ODOMETRO, 
                        KM_ECM, LTS_ECM, LTS_REAL, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI, LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI, 
                        PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL, REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB, 
                        R.FECHAELAB, R.UUID 
                        FROM GCRESETEO R 
                        Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
                        Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT 
                        WHERE R.STATUS = 'A' AND ESTADO = 'FINALIZADO' " & PARAM_VAR & "
                        ORDER BY R.CVE_RES DESC"
                Case "ReseteoVikingos"
                    SQL = "SELECT TOP 1000 R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, NOMBRE, R.CVE_UNI, U.CLAVEMONTE, M.DESCR AS NOMBREMOTOR, 
                        R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, CAL_GLO_EVA, BONO_RES, R.ODOMETRO, 
                        KM_ECM, LTS_ECM, LTS_REAL, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI, LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI, 
                        PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL, REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB, 
                        R.FECHAELAB, R.UUID 
                        FROM GCRESETEO R 
                        Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
                        Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT 
                        WHERE R.STATUS = 'A'
                        ORDER BY R.CVE_RES DESC"
                Case "ReseteoTab"
                    SQL = "SELECT CVE_TAB, CVE_ORI, ISNULL(P1.CIUDAD,'') AS DESCR_ORI, CVE_DES, ISNULL(P2.CIUDAD,'') AS DESCR_DES, 
                        CASE ISNULL(CARGADO_VACIO,0) WHEN 0 THEN 'Vacio' ELSE 'Cargado' END AS CAR_VAC, ISNULL(TIPO_VIAJE,'') AS VIAJE, 
                        CLIENTE, C.NOMBRE, ISNULL(KMS,0) As KM, ISNULL(RENDIMIENTO,0) As LTS, T.OBSER
                        FROM GCTABULADOR_PAR T 
                        LEFT JOIN GCCLIE_OP C On C.CLAVE = CLIENTE 
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = CVE_ORI 
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = CVE_DES 
                        WHERE T.STATUS = 'A' ORDER BY CVE_TAB DESC"
                Case "Contrato"
                    SQL = "SELECT TOP 100 C.CVE_CON, CO1.NOMBRE AS NOMBRE_CONTRATO, CO2.NOMBRE AS NOMBRE_ORIGEN, P1.CIUDAD AS CIUDAD_PLAZA1, 
                        CO2.DOMICILIO AS DOMI1_PLAZA1,  CO2.DOMICILIO2 AS DOMI2_PLAZA1, CO2.PLANTA AS PLANTA_PLAZA1, CO2.NOTA AS NOTA_PLAZA1, CO2.RFC AS RFC_PLAZA1, 
                        CO3.NOMBRE AS NOMBRE_DESTINO, P2.CIUDAD AS CIUDAD_PLAZA2, 
                        CO3.DOMICILIO AS DOMI1_PLAZA2,  CO2.DOMICILIO2 AS DOMI2_PLAZA2, CO3.PLANTA AS PLANTA_PLAZA2, CO3.NOTA AS NOTA_PLAZA2, CO3.RFC AS RFC_PLAZA2, 
                        RE.DESCR AS RECOGER_EN_DESCR, EE.DESCR AS ENTREGAR_EN_DESC, ISNULL(VALOR_DECLA,0) AS DECLA, PROD.DESCR AS DESCR_CVE_ART
                        FROM GCCONTRATO C 
                        LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBS 
                        LEFT JOIN GCCLIE_OP CO1 ON CO1.CLAVE = C.NO_CONTRATO
                        LEFT JOIN GCCLIE_OP CO2 ON CO2.CLAVE = CLAVE_O
                        LEFT JOIN GCCLIE_OP CO3 ON CO3.CLAVE = CLAVE_D
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = CO2.CVE_PLAZA
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = CO3.CVE_PLAZA
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = C.RECOGER_EN
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = C.ENTREGAR_EN
                        LEFT JOIN GCPRODUCTOS PROD ON PROD.CVE_PROD = C.CVE_ART
                        WHERE C.STATUS = 'A' ORDER BY TRY_PARSE(CVE_CON AS INT) DESC"
                Case "Detalle Rutas"
                    SQL = "SELECT D.CVE_RUTA AS 'Clave', P1.CIUDAD AS 'Origen', P2.CIUDAD AS 'Destino', ISNULL(D.KM_RECORRIDOS,0) AS 'Km. Recorridos', " &
                        "ISNULL(D.COSTO_CASETAS,0) AS 'Costo casetas', ISNULL(D.EJES,0) AS 'Ejes' " &
                        "FROM GCDETALLE_RUTAS D " &
                        "LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = D.CVE_PLA1 " &
                        "LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = D.CVE_PLA2 " &
                        "WHERE D.STATUS = 'A' ORDER BY CVE_RUTA"
                Case "Unidades"
                    If TipoUnidad > 0 Then
                        If TipoUnidad = 1 Then
                            CADENA_UNIDAD = "U.CVE_TIPO_UNI = 1 OR U.CVE_TIPO_UNI = 7"
                        Else
                            CADENA_UNIDAD = "U.CVE_TIPO_UNI = " & TipoUnidad
                        End If
                        SQL = "Select TRY_PARSE(U.CLAVE As INT), U.CLAVEMONTE, U.DESCR As NOMB_UNIDAD, U.PLACAS_MEX, M.DESCR As MARCA, 
                            ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0), ISNULL(T.DESCR,'') AS TIPOUNI 
                            FROM GCUNIDADES U 
                            LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                            LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI 
                            WHERE ISNULL(U.STATUS, 'A') = 'A' AND (U.CVE_TIPO_UNI = 0 OR " & CADENA_UNIDAD & ") ORDER by U.CLAVEMONTE"
                    Else
                        SQL = "SELECT TRY_PARSE(U.CLAVE AS INT), U.CLAVEMONTE, U.DESCR AS TIPOUNI, U.PLACAS_MEX, M.DESCR AS MARCA, 
                            ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0), ISNULL(T.DESCR,'') AS TIPOUNI
                            FROM GCUNIDADES U 
                            LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                            LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI
                            WHERE ISNULL(U.STATUS, 'A') = 'A' ORDER BY U.CLAVEMONTE"
                    End If
                    Var4 = ""

                Case "Uni_Viaje"

                    SQL = "SELECT A.CVE_VIAJE, U.CLAVEMONTE AS UNIDAD, T.DESCR AS TIPOUNI, U.PLACAS_MEX, M.DESCR AS MARCA, 
                        ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0)
                        FROM GCUNIDADES U 
                        LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                        LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI 
                        INNER JOIN GCASIGNACION_VIAJE A ON A.CVE_TRACTOR = U.CLAVEMONTE
                        WHERE ISNULL(U.STATUS, 'A') = 'A' AND (U.CVE_TIPO_UNI = 0 OR U.CVE_TIPO_UNI = 1 OR U.CVE_TIPO_UNI = 7) AND A.CVE_ST_VIA <> 5 " &
                        IIf(PARAM_VAR.Trim.Length > 0, " AND A.CVE_OPER = '" & PARAM_VAR & "'", "") & "
                        ORDER by A.FECHAELAB DESC"
                Case "Cliente operativo"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.DOMICILIO, ISNULL(C.NOTA,0) AS C_NOTA
                        FROM GCCLIE_OP C
                        WHERE C.STATUS = 'A' ORDER BY TRY_PARSE(C.CLAVE AS INT) "
                Case "Plazas"
                    SQL = "SELECT CLAVE, CIUDAD, MUNICIPIO FROM GCPLAZAS WHERE STATUS = 'A' ORDER BY CLAVE"
                Case "Operador"
                    SQL = "SELECT CLAVE, NOMBRE, LICENCIA, LIC_VENC FROM GCOPERADOR WHERE STATUS = 'A' ORDER BY CLAVE"
                Case "GCPRODUCTOS", "Productos"
                    SQL = "SELECT CVE_PROD, DESCR FROM GCPRODUCTOS WHERE STATUS = 'A'"
                Case "Valor Declarado"
                    SQL = "SELECT E.CLAVE, E.DESCR, E.IMPORTE 
                        FROM GCVALOR_DECLARADO E 
                        WHERE E.STATUS = 'A' ORDER BY E.CLAVE"
                Case "GCTAB_RUTAS"
                    SQL = "SELECT T.CVE_TAB, T.FECHA, (CASE T.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, P1.CIUDAD AS ORIG, 
                        P2.CIUDAD AS DEST, NOMBRE AS NOMB, T.KM_RECO, T.COSTO_CASETAS, T.SUELDO_OPER, 
                        T.P_X_LITRO, T.OBSER
                        FROM GCTAB_RUTAS T
                        LEFT JOIN GCDETALLE_RUTAS D ON D.CVE_RUTA = T.CVE_RUTA
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.ORIGEN
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.DESTINO
                        LEFT JOIN GCCLIE_OP C ON C.CLAVE = LTRIM(RTRIM(T.CLIENTE))
                        WHERE T.STATUS = 'A' ORDER BY CVE_TAB DESC"
                Case "RUTAS FLORES"
                    SQL = "SELECT T.CVE_TAB, '(' + LTRIM(RTRIM(OP1.CLAVE)) + ') - ' + ISNULL(OP1.NOMBRE,'') AS NOM_OP1, T.DESCR AS NOMBRE_RUTA, T.DESCR2 AS NOMBRE_RUTA2, T.KMS, T.TAR_X_VIA_FULL AS TARIFA_VIAJE_FULL, 
                        T.TAR_X_VIA_SENC AS TARIFA_VIAJE_SENCILLO, T.TAR_OPER_FULL, TAR_X_TON_SENC AS TARIFA_OPER_SENCILLO, SUELDO_FULL, SUELDO_SENC,
                        PORC_SUELDO_FULL, PORC_SUELDO_SENC, (OP2.MUNICIPIO + ', ' + OP2.ESTADO) as PLANTA_ORIGEN, (OP3.MUNICIPIO + ', ' + OP3.ESTADO) AS PLANTA_DESTINO
                        FROM GCTAB_RUTAS_F T
                        LEFT JOIN CLIE" & Empresa & " OP1 ON OP1.CLAVE = T.CLIE_OP
                        LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = T.CLIE_OP_O
                        LEFT JOIN GCCLIE_OP OP3 ON OP3.CLAVE = T.CLIE_OP_D
                        LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = T.CVE_PROD
                        WHERE T.STATUS = 'A' ORDER BY TRY_PARSE(T.CVE_TAB AS INT)"

            End Select

            DESPLEGAR()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Var4 = ""
        Var5 = ""
        Var6 = ""
        Var7 = ""
        Var8 = ""
        Var9 = ""
        Me.Close()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarBuscar_Click(Nothing, Nothing)
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TBox_KeyDown(sender As Object, e As KeyEventArgs) Handles tBox.KeyDown
        Try
            If e.KeyCode = Keys.Down Then
                Fg.Focus()
                Return
            End If
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                TBox_TextChanged(Nothing, Nothing)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Dim CADENA_UNIDAD As String
        Try
            Select Case Proceso
                Case "GCSERVICIOS"
                    SQL = "SELECT S.CVE_SER, S.DESCR, S.COSTO_MO, 
                        CASE S.TIPO_SERVICIO WHEN 0 THEN 'Preventivo' ELSE 'Correctivo' END AS 'Tipo de servicio' 
                        FROM GCSERVICIOS S 
                        WHERE S.STATUS = 'A' and UPPER(S.DESCR) LIKE '%" & tBox.Text.Trim.ToUpper & "%'
                        ORDER BY TRY_PARSE(S.CVE_SER AS INT) DESC"
                Case "GCSERVICIOS_MANTE"
                    SQL = "SELECT CVE_SER, DESCR 
                        FROM GCSERVICIOS_MANTE 
                        WHERE STATUS = 'A' and UPPER(DESCR) LIKE '%" & tBox.Text.Trim.ToUpper & "%'
                        ORDER BY TRY_PARSE(CVE_SER AS INT)"
                Case "GCCLASIFIC_SERVICIOS"
                    SQL = "SELECT CVE_CLA, DESCR 
                        FROM GCCLASIFIC_SERVICIOS 
                        WHERE STATUS = 'A' and UPPER(DESCR) LIKE '%" & tBox.Text.Trim.ToUpper & "%'"
                Case "Marca reno"
                    SQL = "SELECT CVE_MARCA, DESCR
                        FROM GCMARCAS_RENOVADO 
                        WHERE STATUS = 'A' (CVE_MARCA LIKE '%" & tBox.Text.ToUpper & "%' OR DESCR LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY TRY_PARSE(CVE_MARCA AS INT)"
                Case "Prov reno"
                    SQL = "SELECT CVE_PRE, DESCR
                        FROM GCPROVRENOVADO 
                        WHERE STATUS = 'A' AND (CVE_MARCA LIKE '%" & tBox.Text.ToUpper & "%' OR DESCR LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY TRY_PARSE(CVE_PRE AS INT)"
                Case "Metodo de pago"
                    SQL = "SELECT metodoPago, descripcion
                        FROM tblcmetodopago
                        WHERE (metodoPago LIKE '%" & tBox.Text.ToUpper & "%' OR descripcion LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY id"
                Case "Flujo"
                    SQL = "SELECT CLAVE, DESCR
                        FROM SOENTRADADINERO
                        WHERE TIPO = '" & PARAM_VAR & "' AND 
                        (CLAVE LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(DESCR) LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY CLAVE"
                Case "ListaPrec"
                    SQL = "SELECT CVE_PRECIO, DESCRIPCION
                        FROM PRECIOS" & Empresa & "
                        WHERE STATUS = 'A' AND (CVE_PRECIO LIKE '%" & tBox.Text.ToUpper & "%' OR  DESCRIPCION LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY CVE_PRECIO"
                Case "MinveEnt", "MinveSal"
                    SQL = "SELECT CVE_CPTO, DESCR
						FROM CONM" & Empresa & "
						WHERE STATUS = 'A' " & Var7 & " AND (CVE_CPTO LIKE '%" & tBox.Text.ToUpper & "%' OR  DESCR LIKE '%" & tBox.Text.ToUpper & "%')
						ORDER BY CVE_CPTO"
                Case "Depto"
                    SQL = "SELECT CVE_DEPTO, DESCR
                        FROM GCDEPTOS 
                        WHERE STATUS = 'A' AND (CVE_DEPTO LIKE '%" & tBox.Text.ToUpper & "%' OR  DESCR LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY TRY_PARSE(CVE_DEPTO AS INT)"
                Case "TipoActivo"
                    SQL = "SELECT CLAVE, DESCRIP
                        FROM GCTIPACTIV 
                        WHERE (CLAVE LIKE '%" & tBox.Text.ToUpper & "%' OR  DESCRIP LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY CLAVE"
                Case "Gastos"
                    SQL = "SELECT G.CVE_ART, G.DESCR, COSTO, DESC_LIN, DESCRIPESQ
                        FROM GCCATGASTOS G
                        LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = G.LINEA
                        LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = G.CVE_ESQIMPU
                        WHERE G.STATUS = 'A' AND 
                        (G.CVE_ART LIKE '%" & tBox.Text.ToUpper & "%' OR  G.DESCR LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY CVE_ART"
                Case "PAGO CFDI"
                    SQL = "SELECT TOP 2000 CVE_DOC, CLIENTE, NOMBRE, FECHA, IMPORTE
                        FROM CFDI_COMPAGO PC 
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = PC.CLIENTE
                        WHERE PC.CLIENTE = '" & Var25 & "' AND 
                        (CVE_DOC LIKE '%" & tBox.Text.ToUpper & "%' OR PC.CLIENTE LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        NOMBRE LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY FECHAELAB DESC"
                Case "FACTURA CFDI"
                    SQL = "SELECT TOP 2000 CFDI.FACTURA, P.CLAVE, P.NOMBRE, FECHA_DOC, F.IMPORTE,
                        CFDI.FECHAELAB, CFDI.CLIENTE, P2.NOMBRE AS NOMBRE2, CFDI.IMPORTE
                        FROM CFDI 
                        LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = CFDI.FACTURA
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                        LEFT JOIN CLIE" & Empresa & " P2 ON P2.CLAVE = CFDI.CLIENTE
                        WHERE ISNULL(F.STATUS,'') <> 'C' AND ISNULL(CFDI.ESTATUS,'') <> 'C' AND 
                        (CFDI.FACTURA LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        P.CLAVE LIKE '%" & tBox.Text.ToUpper & "%' OR P.NOMBRE LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        P2.CLAVE LIKE '%" & tBox.Text.ToUpper & "%' OR P2.NOMBRE LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY F.FECHAELAB DESC"
                Case "NumGen"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES
                        FROM GCHORAS_GEN 
                        WHERE DESCR LIKE '%" & tBox.Text & "%'
                        ORDER BY CVE_GEN"
                Case "GCConc"
                    SQL = "SELECT CVE_GAS, DESCR, CLASIFIC 
                        FROM GCCONC_GASTOS 
                        WHERE STATUS = 'A' AND 
                        (CAST(CVE_GAS as VARCHAR(10)) LIKE '%" & tBox.Text.ToUpper & "%' or 
                        DESCR LIKE '%" & tBox.Text.ToUpper & "%' or 
                        CLASIFIC LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY CVE_GAS"
                Case "Embalaje"
                    SQL = "SELECT CLAVE, DESCR 
                        FROM GCEMBALAJE 
                        WHERE STATUS = 'A' AND 
                        CLAVE like '%" & tBox.Text.Trim & "%' OR UPPER(DESCR) LIKE '%" & tBox.Text.Trim.ToUpper & "%')
                        ORDER BY TRY_PARSE(CLAVE AS INT)"
                Case "tblcclaveunidad"
                    SQL = "SELECT claveUnidad, nombre 
                        FROM tblcclaveunidad 
                        WHERE claveUnidad like '%" & tBox.Text.Trim & "%' OR nombre LIKE '%" & tBox.Text & "%'
                        ORDER BY claveUnidad"
                Case "Cargas"
                    SQL = "SELECT CLAVE, DESCR 
                        FROM GCCARGAS 
                        WHERE STATUS = 'A' AND 
                        CLAVE like '%" & tBox.Text.Trim & "%' OR UPPER(DESCR) LIKE '%" & tBox.Text.Trim.ToUpper & "%')
                        ORDER BY TRY_PARSE(CLAVE AS INT)"
                Case "GCCATEVA"
                    SQL = "SELECT E.CVE_EVA, M.DESCR, CASE WHEN E.TIPO_VIAJE = 1 THEN 'FULL' ELSE 'SENCILLO' END AS TIPVIAJE
                        FROM GCCATEVA E
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = E.CVE_MOT
                        WHERE E.STATUS = 'A' AND 
                        (CAST(CVE_EVA AS VARCHAR(10) like '%" & tBox.Text.ToUpper & "%' OR UPPER(DESCR) LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY E.CVE_EVA"

                Case "tblcformapago"
                    SQL = "SELECT formaPago, descripcion FROM tblcformapago 
                        WHERE 
                        UPPER(formaPago) like '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(descripcion) LIKE '%" & tBox.Text.ToUpper & "%'
                        ORDER BY formaPago"
                Case "PagoComplemento", "PagoComplementoDocCte"
                    SQL = "SELECT M.DOCTO, M.CVE_CLIE, MAX(P.NOMBRE)
                        FROM CUEN_DET" & Empresa & " M
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE 
                        LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = M.REFER
                        LEFT JOIN MONED" & Empresa & " N ON N.NUM_MONED = M.NUM_MONED 
                        WHERE ISNULL(F.METODODEPAGO,'PPD') = 'PPD' AND ISNULL(F.FORMADEPAGOSAT,'99') = 99 AND 
                        ISNULL(CVE_DOC_COMPPAGO,'') = '' AND M.CVE_CLIE = '" & PARAM_VAR & "' AND (
                        M.DOCTO LIKE '%" & tBox.Text & "' OR M.CVE_CLIE LIKE '%" & tBox.Text & "' OR 
                        P.NOMBRE LIKE '%" & tBox.Text & "')
                        GROUP BY M.CVE_CLIE, M.DOCTO
                        ORDER BY M.CVE_CLIE, M.DOCTO"
                Case "Tarifas"
                    SQL = "SELECT DESCRIPCION, PRECIO, ISNULL(CVE_TIPO_OPE,0) AS C_T_OPE, ISNULL(TP.DESCR,'') AS DES, 
                        ISNULL(PRECIO_X_TANQUE,0) AS PRE_X_TANQUE, R.CVE_ART
                        FROM GCTARIFAS T 
                        LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_TAB = T.CVE_RUTA
                        LEFT JOIN GCTIPO_OPERACION TP ON TP.CVE_TIPO = R.CVE_TIPO_OPE
                        LEFT JOIN PRECIOS" & Empresa & " P ON P.CVE_PRECIO = T.CVE_PRECIO
                        WHERE CVE_CON = '" & Var3 & "' AND 
                        precio Like '%" & tBox.Text & "%'
                        ORDER BY CVE_PRECIO"
                Case "GCCASETAS_X_RUTA"
                    SQL = "SELECT C.CVE_CXR, C.CVE_PLAZA, C.CVE_PLAZA2, P1.CIUDAD AS CIUDAD1, P2.CIUDAD AS CIUDAD2, 
                        ISNULL(IMPORTE_CASETAS,0) AS IMPORTE, OP.NOMBRE, OP.NOMBRE, C.IAVE
                        FROM GCCASETAS_X_RUTA C 
                        LEFT JOIN GCCLIE_OP OP On OP.CLAVE = C.CLAVE_OP
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA 
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = C.CVE_PLAZA2
                        WHERE STATUS = 'A' AND (
                        CVE_CXR Like '%" & tBox.Text & "%' OR C.CVE_PLAZA Like '%" & tBox.Text & "%' OR C.CVE_PLAZA2 Like '%" & tBox.Text & "%' OR
                        P.CIUDAD Like '%" & tBox.Text & "%' OR P2.CIUDAD Like '%" & tBox.Text & "%' OR OP.NOMBRE Like '%" & tBox.Text & "%')
                        ORDER BY CVE_CXR"
                Case "FAC CFDI"
                    SQL = "SELECT F.FACTURA, F.DOCUMENT, F.DOCUMENT2, F.CLIENTE, C.NOMBRE, F.FECHAELAB
                        FROM CFDI F
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE
                        WHERE F.FACTURA LIKE '%" & tBox.Text & "%' OR F.DOCUMENT LIKE '%" & tBox.Text & "%' OR 
                        F.DOCUMENT2 LIKE '%" & tBox.Text & "%' OR F.CLIENTE LIKE '%" & tBox.Text & "%' OR 
                        NOMBRE LIKE '%" & tBox.Text & "%'
                        Order By FECHAELAB DESC"
                Case "Carta porte"
                    SQL = "SELECT DOCUMENT, DOCUMENT2, FACTURA, USUARIO, FECHAELAB
                        From CFDI 
                        WHERE DOCUMENT Like '%" & tBox.Text & "%' OR DOCUMENT2 Like '%" & tBox.Text & "%' OR FACTURA Like '%" & tBox.Text & "%' 
                        Order By FECHAELAB DESC"
                Case "Carta porte2"
                    SQL = "SELECT CVE_FOLIO, ISNULL(ST.DESCR,'EDICION') AS ST_CARTAP, ORDEN_DE, CVE_VIAJE, P.CVE_DOCP, 
                        CASE ISNULL(P.CVE_DOCR,'') WHEN '0' THEN '' WHEN '' THEN '' ELSE P.CVE_DOCR END, '(' + LTRIM(RTRIM(P.CLIENTE)) + ') ' + C.NOMBRE,
                        P.FECHAELAB, 
                        (CASE P.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI,
                        (CASE P.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, O.NOMBRE AS OPER, P.CVE_TRACTOR,
                        P.CVE_TANQUE1, P.CVE_TANQUE2, P.CVE_DOLLY, RE.DESCR AS RECEN, EE.DESCR AS ENTEN, 
                        (CASE P.CONCILIADO WHEN 1 THEN 'Conciliado' ELSE '' END) AS CONCI, 
                        ISNULL(CVE_MAT,'') AS CVE_MAT, ISNULL(VALOR_DECLARADO,0) AS VAL_CLA
                        FROM GCCARTA_PORTE P
                        LEFT JOIN GCSTATUS_CARTA_PORTE ST ON ST.CVE_CAP = P.ST_CARTA_PORTE
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN
                        WHERE P.STATUS = 'A' AND 
                        (P.CVE_FOLIO Like '%" & tBox.Text & "%' OR ST.DESCR LIKE '%" & tBox.Text & "%' OR ORDEN_DE LIKE '%" & tBox.Text & "%' OR 
                        CVE_VIAJE LIKE '%" & tBox.Text & "%' OR P.CVE_DOCP LIKE '%" & tBox.Text & "%' OR 
                        P.CVE_DOCR LIKE '%" & tBox.Text & "%' OR P.CLIENTE LIKE '%" & tBox.Text & "%' OR 
                        C.NOMBRE LIKE '%" & tBox.Text & "%' OR O.NOMBRE LIKE '%" & tBox.Text & "%' OR 
                        C.CVE_TRACTOR LIKE '%" & tBox.Text & "%' OR P.CVE_TANQUE1 LIKE '%" & tBox.Text & "%' OR 
                        P.CVE_TANQUE2 LIKE '%" & tBox.Text & "%' OR P.CVE_DOLLY LIKE '%" & tBox.Text & "%' OR 
                        RE.DESCR LIKE '%" & tBox.Text & "%' OR EE.DESCR LIKE '%" & tBox.Text & "%' OR 
                        CVE_MAT LIKE '%" & tBox.Text & "%') 
                        ORDER BY P.FECHAELAB DESC"
                Case "PedidosProg"
                    SQL = "SELECT P.CVE_DOC, C3.NOMBRE, I.DESCR, P.FECHA_CARGA, P.FECHA_DESCARGA, RE.DESCR As RECIBIR_E, EE.DESCR AS RECOGER_E
                        FROM GCPEDIDOSPROG P
                        LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                        LEFT JOIN GCCONTRATO CT ON CT.CVE_CON = P.CVE_CON 
                        LEFT JOIN GCCLIE_OP C3 ON C3.CLAVE = CT.NO_CONTRATO 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN
                        WHERE P.STATUS = 'A' AND ISNULL(CVE_VIAJE,'') = '' AND 
                        NOT EXISTS (SELECT PED_ENLAZADO FROM GCPEDIDOS WHERE PED_ENLAZADO = P.CVE_DOC) AND 
                        (P.CVE_DOC Like '%" & tBox.Text & "%' OR C3.NOMBRE LIKE '%" & tBox.Text & "%' OR I.DESCR LIKE '%" & tBox.Text & "%' OR 
                        RE.DESCR LIKE '%" & tBox.Text & "%' OR EE.DESCR LIKE '%" & tBox.Text & "%') 
                        ORDER BY P.FECHAELAB DESC"
                Case "Vend"
                    SQL = "SELECT CVE_VEND, NOMBRE FROM VEND" & Empresa & "  WHERE STATUS = 'A'  AND 
                        (CVE_VEND Like '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%') 
                        ORDER BY NOMBRE"

                Case "InveR", "InvenRS", "InvenRP", "Inventario"
                    ' --------------------               MULTIALMACEN      -----------------------
                    ' --------------------               MULTIALMACEN      -----------------------
                    ' --------------------               MULTIALMACEN      -----------------------
                    If G_ALM = 0 Then G_ALM = 1
                    If MULTIALMACEN = 0 Then
                        SQL = "SELECT I.CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS NUM_PARTE, 
                            EXIST, TIPO_ELE, STATUS 
                            FROM INVE" & Empresa & " I WHERE I.STATUS = 'A' AND I.TIPO_ELE <> 'K' AND 
                            (I.CVE_ART Like '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%' OR EXIST LIKE '%" & tBox.Text & "%') 
                            ORDER BY I.DESCR"
                    Else
                        SQL = "SELECT M.CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = M.CVE_ART) AS NUM_PARTE, 
                            M.EXIST, I.TIPO_ELE, M.STATUS 
                            FROM MULT" & Empresa & " M 
                            LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                            WHERE I.STATUS = 'A' AND M.STATUS = 'A' AND I.TIPO_ELE <> 'K' AND CVE_ALM = " & G_ALM & " AND 
                            (I.CVE_ART Like '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%' OR M.EXIST LIKE '%" & tBox.Text & "%') ORDER BY I.DESCR"
                    End If
                    ' --------------------               MULTIALMACEN      -----------------------
                Case "Prov"
                    SQL = "SELECT CLAVE, NOMBRE, RFC, CALLE FROM PROV" & Empresa & " 
                        WHERE STATUS = 'A'  AND 
                        (CLAVE Like '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR 
                        RFC LIKE '%" & tBox.Text & "%' OR CALLE LIKE '%" & tBox.Text & "%') 
                        ORDER BY CLAVE"

                Case "Articulo", "FACTURA"
                    SQL = "SELECT CVE_ART, ISNULL(DESCR,'') AS DES, ISNULL(EXIST,0) AS EXI, LIN_PROD FROM INVE" & Empresa & " 
                        WHERE STATUS = 'A' AND TIPO_ELE <> 'K' AND CVE_ART <> 'TOT' AND 
                        (CVE_ART Like '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%' OR EXIST LIKE '%" & tBox.Text & "%') 
                        ORDER BY DESCR"

                Case "InveS"
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, 
                        EXIST, TIPO_ELE, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I 
                        LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'S' AND 
                        (I.CVE_ART Like '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%' OR PRECIO LIKE '%" & tBox.Text & "%' OR 
                        EXIST LIKE '%" & tBox.Text & "%') 
                        ORDER BY CVE_ART"

                Case "InveP"
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, 
                        EXIST, TIPO_ELE, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I 
                        LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'P' AND 
                        (I.CVE_ART Like '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%' OR PRECIO LIKE '%" & tBox.Text & "%' OR 
                        EXIST LIKE '%" & tBox.Text & "%') 
                        ORDER BY CVE_ART"
                Case "Clientes", "Clie01", "Clie"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, ISNULL(CAMPLIB5,0) AS LIB5, ISNULL(CAMPLIB6,0) AS LIB6, USO_CFDI, 
                        ISNULL(REG_FISC,'') AS REGFISC
                        FROM CLIE" & Empresa & " C
                        LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = C.CLAVE
                        WHERE C.STATUS = 'A' AND 
                        (C.CLAVE Like '%" & tBox.Text & "%' OR C.NOMBRE LIKE '%" & tBox.Text & "%' OR 
                        C.RFC LIKE '%" & tBox.Text & "%' OR CALLE LIKE '%" & tBox.Text & "%' OR 
                        C.USO_CFDI LIKE '%" & tBox.Text & "%' OR REG_FISC LIKE '%" & tBox.Text & "%')
                        ORDER BY C.CLAVE"
                Case "CTE_POS"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, CASE WHEN ISNULL(LISTA_PREC,0) < 1 THEN 1 ELSE LISTA_PREC END AS LISTAPREC, 
                        C.DESCUENTO, C.CALLE, USO_CFDI, ISNULL(REG_FISC,'') AS REGFISC, 
                        CASE WHEN ISNULL(CON_CREDITO,'') = 'S' THEN 'Si' ELSE 'No' END AS CONCRED
                        FROM CLIE" & Empresa & " C
                        WHERE C.STATUS = 'A' AND 
                        (C.CLAVE Like '%" & tBox.Text & "%' OR C.NOMBRE LIKE '%" & tBox.Text & "%' OR 
                        C.RFC LIKE '%" & tBox.Text & "%' OR CALLE LIKE '%" & tBox.Text & "%' OR 
                        C.USO_CFDI LIKE '%" & tBox.Text & "%' OR REG_FISC LIKE '%" & tBox.Text & "%')
                        ORDER BY C.CLAVE"

                Case "CTE_CREDITO"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, USO_CFDI, ISNULL(REG_FISC,'') AS REGFISC
                        FROM CLIE" & Empresa & " C
                        WHERE C.STATUS = 'A' AND ISNULL(CON_CREDITO,'') = 'S' AND 
                        (C.CLAVE Like '%" & tBox.Text & "%' OR C.NOMBRE LIKE '%" & tBox.Text & "%' OR 
                        C.RFC LIKE '%" & tBox.Text & "%' OR CALLE LIKE '%" & tBox.Text & "%' OR 
                        C.USO_CFDI LIKE '%" & tBox.Text & "%' OR REG_FISC LIKE '%" & tBox.Text & "%')
                        ORDER BY C.CLAVE"

                Case "GCTAB_RUTAS"
                    SQL = "SELECT T.CVE_TAB, T.FECHA, (CASE T.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, P1.CIUDAD AS ORIG, 
                        P2.CIUDAD AS DEST, ('(' + T.CLIENTE + ')' + NOMBRE) AS NOMB, T.KM_RECO, T.COSTO_CASETAS, T.SUELDO_OPER, T.OBSER
                        FROM GCTAB_RUTAS T
                        LEFT JOIN GCDETALLE_RUTAS D ON D.CVE_RUTA = T.CVE_RUTA
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.ORIGEN
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.DESTINO
                        LEFT JOIN GCCLIE_OP C ON C.CLAVE = LTRIM(RTRIM(T.CLIENTE))
                        WHERE P.STATUS = 'A' AND ISNULL(CVE_VIAJE,'') = '' AND 
                        (P1.CIUDAD Like '%" & tBox.Text & "%' OR P2.CIUDAD LIKE '%" & tBox.Text & "%' OR T.CLIENTE LIKE '%" & tBox.Text & "%' OR 
                        NOMBRE LIKE '%" & tBox.Text & "%')
                        ORDER BY CVE_TAB DESC"
                Case "RUTAS FLORES"
                    SQL = "SELECT T.CVE_TAB, '(' + LTRIM(RTRIM(OP1.CLAVE)) + ') - ' + ISNULL(OP1.NOMBRE,'') AS NOM_OP1, T.DESCR AS NOMBRE_RUTA, 
                        T.DESCR2 AS NOMBRE_RUTA2, T.KMS, T.TAR_X_VIA_FULL AS TARIFA_VIAJE_FULL, T.TAR_X_VIA_SENC AS TARIFA_VIAJE_SENCILLO, 
                        T.TAR_OPER_FULL, TAR_X_TON_SENC AS TARIFA_OPER_SENCILLO, SUELDO_FULL, SUELDO_SENC, PORC_SUELDO_FULL, PORC_SUELDO_SENC, 
                        (OP2.MUNICIPIO + ', ' + OP2.ESTADO) as PLANTA_ORIGEN, (OP3.MUNICIPIO + ', ' + OP3.ESTADO) AS PLANTA_DESTINO
                        FROM GCTAB_RUTAS_F T
                        LEFT JOIN CLIE" & Empresa & " OP1 ON OP1.CLAVE = T.CLIE_OP
                        LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = T.CLIE_OP_O
                        LEFT JOIN GCCLIE_OP OP3 ON OP3.CLAVE = T.CLIE_OP_D
                        LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = T.CVE_PROD
                        WHERE 
                        T.CVE_TAB Like '%" & tBox.Text & "%' OR OP1.CLAVE Like '%" & tBox.Text & "%' OR OP1.NOMBRE Like '%" & tBox.Text & "%' OR 
                        T.DESCR Like '%" & tBox.Text & "%' OR 
                        ISNULL(T.DESCR2,'') Like '%" & tBox.Text & "%' OR ISNULL(T.KMS,'') Like '%" & tBox.Text & "%' OR 
                        ISNULL(T.TAR_X_VIA_FULL,'') Like '%" & tBox.Text & "%' OR ISNULL(T.TAR_X_VIA_SENC,'') Like '%" & tBox.Text & "%' OR 
                        ISNULL(T.TAR_OPER_FULL,'') Like '%" & tBox.Text & "%' OR ISNULL(T.TAR_X_TON_SENC,'') Like '%" & tBox.Text & "%' OR 
                        ISNULL(T.SUELDO_FULL,'') Like '%" & tBox.Text & "%' OR ISNULL(T.SUELDO_SENC,'') Like '%" & tBox.Text & "%' OR 
                        ISNULL(T.PORC_SUELDO_FULL,'') Like '%" & tBox.Text & "%' OR ISNULL(T.PORC_SUELDO_SENC,'') Like '%" & tBox.Text & "%' OR 
                        ISNULL(OP2.MUNICIPIO,'') Like '%" & tBox.Text & "%' OR ISNULL(OP2.ESTADO,'') Like '%" & tBox.Text & "%' OR 
                        ISNULL(OP3.MUNICIPIO,'') Like '%" & tBox.Text & "%' OR ISNULL(OP3.ESTADO,'') Like '%" & tBox.Text & "%'
                        ORDER BY TRY_PARSE(T.CVE_TAB AS INT)"

                Case "Pedidos"
                    SQL = "SELECT TOP 300 P.CVE_DOC, P.CVE_CON, O.NOMBRE, CO1.NOMBRE AS ORIGEN, CO2.NOMBRE AS DESTINO, I.DESCR, P.FECHA, 
                        P1.CIUDAD AS ORIGEN, P2.CIUDAD AS DESTINO, P.FECHA_CARGA, P.FECHA_DESCARGA
                        FROM GCPEDIDOS P
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                        LEFT JOIN GCCLIE_OP CO1 ON CO1.CLAVE = P.CLAVE_O
                        LEFT JOIN GCCLIE_OP CO2 ON CO2.CLAVE = P.CLAVE_D
                        LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = P.CVE_PLAZA1
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = P.CVE_PLAZA2
                        WHERE P.STATUS = 'A' AND ISNULL(CVE_VIAJE,'') = '' AND 
                        (CVE_DOC Like '%" & tBox.Text & "%' OR CVE_CON LIKE '%" & tBox.Text & "%' OR CO1.NOMBRE LIKE '%" & tBox.Text & "%' OR 
                        CO2.NOMBRE LIKE '%" & tBox.Text & "%' OR O.NOMBRE LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%' OR 
                        P1.CIUDAD LIKE '%" & tBox.Text & "%' OR P2.CIUDAD LIKE '%" & tBox.Text & "%')
                        ORDER BY P.FECHAELAB DESC"
                Case "ReseteoVikingos"
                    SQL = "SELECT TOP 1000 R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, NOMBRE, R.CVE_UNI, U.CLAVEMONTE, M.DESCR AS NOMBREMOTOR, 
                        R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, CAL_GLO_EVA, BONO_RES, R.ODOMETRO, 
                        KM_ECM, LTS_ECM, LTS_REAL, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI, LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI, 
                        PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL, REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB, 
                        R.FECHAELAB, R.UUID 
                        FROM GCRESETEO R 
                        Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
                        Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT 
                        WHERE R.STATUS = 'A' AND (
                        R.CVE_RES LIKE '%" & tBox.Text & "%' OR R.CVE_OPER LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR  
                        R.CVE_UNI LIKE '%" & tBox.Text & "%' OR U.CLAVEMONTE LIKE '%" & tBox.Text & "%' OR 
                        M.DESCR LIKE '%" & tBox.Text & "%') 
                        ORDER BY R.CVE_RES DESC"
                Case "Reseteo"
                    SQL = "SELECT TOP 1000 R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, NOMBRE, R.CVE_UNI, U.CLAVEMONTE, M.DESCR AS NOMBREMOTOR, 
                        R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, CAL_GLO_EVA, BONO_RES, R.ODOMETRO, 
                        KM_ECM, LTS_ECM, LTS_REAL, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI, LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI, 
                        PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL, REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB, 
                        R.FECHAELAB, R.UUID 
                        FROM GCRESETEO R 
                        Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
                        Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT 
                        WHERE R.STATUS = 'A' AND ESTADO = 'FINALIZADO' AND (
                        R.CVE_RES LIKE '%" & tBox.Text & "%' OR R.CVE_OPER LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR  
                        R.CVE_UNI LIKE '%" & tBox.Text & "%' OR U.CLAVEMONTE LIKE '%" & tBox.Text & "%' OR 
                        M.DESCR LIKE '%" & tBox.Text & "%') " & PARAM_VAR & "
                        ORDER BY R.CVE_RES DESC"
                Case "ReseteoTab"
                    SQL = "SELECT CVE_TAB, CVE_ORI, ISNULL(P1.CIUDAD,'') AS DESCR_ORI, CVE_DES, ISNULL(P2.CIUDAD,'') AS DESCR_DES, 
                        CASE ISNULL(CARGADO_VACIO,0) WHEN 0 THEN 'Vacio' ELSE 'Cargado' END AS CAR_VAC, ISNULL(TIPO_VIAJE,'') AS VIAJE, 
                        CLIENTE, C.NOMBRE, ISNULL(KMS,0) As KM, ISNULL(RENDIMIENTO,0) As LTS, T.OBSER
                        FROM GCTABULADOR_PAR T 
                        LEFT JOIN GCCLIE_OP C On C.CLAVE = CLIENTE 
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = CVE_ORI 
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = CVE_DES 
                        WHERE T.STATUS = 'A' AND CVE_TAB LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(P1.CIUDAD) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(P2.CIUDAD) Like '%" & tBox.Text.ToUpper & "%' OR CLIENTE  LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        T.CVE_TAB Like '%" & tBox.Text.ToUpper & "%' OR CVE_ORI LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        T.CVE_DES Like '%" & tBox.Text.ToUpper & "%' OR 
                        NOMBRE Like '%" & tBox.Text.ToUpper & "%' 
                        ORDER BY CVE_TAB DESC"
                Case "Contrato"
                    SQL = "SELECT TOP 100 C.CVE_CON, CO1.NOMBRE AS NOMBRE_CONTRATO, CO2.NOMBRE AS NOMBRE_ORIGEN, P1.CIUDAD AS CIUDAD_PLAZA1, 
                        CO2.DOMICILIO AS DOMI1_PLAZA1,  CO2.DOMICILIO2 AS DOMI2_PLAZA1, CO2.PLANTA AS PLANTA_PLAZA1, CO2.NOTA AS NOTA_PLAZA1, CO2.RFC AS RFC_PLAZA1, 
                        CO3.NOMBRE AS NOMBRE_DESTINO, P2.CIUDAD AS CIUDAD_PLAZA2, 
                        CO3.DOMICILIO AS DOMI1_PLAZA2,  CO2.DOMICILIO2 AS DOMI2_PLAZA2, CO3.PLANTA AS PLANTA_PLAZA2, CO3.NOTA AS NOTA_PLAZA2, CO3.RFC AS RFC_PLAZA2, 
                        RE.DESCR AS RECOGER_EN_DESCR, EE.DESCR AS ENTREGAR_EN_DESC, ISNULL(VALOR_DECLA,0) AS DECLA, PROD.DESCR AS DESCR_CVE_ART
                        FROM GCCONTRATO C 
                        LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBS 
                        LEFT JOIN GCCLIE_OP CO1 ON CO1.CLAVE = C.NO_CONTRATO
                        LEFT JOIN GCCLIE_OP CO2 ON CO2.CLAVE = CLAVE_O
                        LEFT JOIN GCCLIE_OP CO3 ON CO3.CLAVE = CLAVE_D
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = CO2.CVE_PLAZA
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = CO3.CVE_PLAZA
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = C.RECOGER_EN
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = C.ENTREGAR_EN
                        LEFT JOIN GCPRODUCTOS PROD ON PROD.CVE_PROD = C.CVE_ART
                        WHERE C.STATUS = 'A' AND (TRY_PARSE(C.CVE_CON AS INT) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(C.CVE_CON) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(CO1.NOMBRE) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(P1.CIUDAD) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(CO2.NOMBRE) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(P2.CIUDAD) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(CO3.NOMBRE) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(CO2.DOMICILIO) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(CO2.DOMICILIO2) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(CO2.RFC) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(CO3.RFC) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(CO2.PLANTA) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(CO3.PLANTA) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(PROD.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(RE.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(EE.DESCR) LIKE '%" & tBox.Text.ToUpper & "%') 
                        ORDER BY TRY_PARSE(C.CVE_CON AS INT) DESC"
                Case "Detalle Rutas"
                    SQL = "SELECT D.CVE_RUTA AS 'Clave', P1.CIUDAD AS 'Origen', P2.CIUDAD AS 'Destino', ISNULL(D.KM_RECORRIDOS,0) AS 'Km. Recorridos', " &
                        "ISNULL(D.COSTO_CASETAS,0) AS 'Costo casetas', ISNULL(D.EJES,0) AS 'Ejes' " &
                        "FROM GCDETALLE_RUTAS D " &
                        "LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = D.CVE_PLA1 " &
                        "LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = D.CVE_PLA2 " &
                        "WHERE D.STATUS = 'A' AND " &
                        "(D.CVE_RUTA LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(P1.CIUDAD) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(P2.CIUDAD) LIKE '%" & tBox.Text.ToUpper & "%') " &
                        "ORDER BY CVE_RUTA"
                Case "Unidades"
                    If TipoUnidad > 0 Then

                        If TipoUnidad = 1 Then
                            CADENA_UNIDAD = "(U.CVE_TIPO_UNI = 1 OR U.CVE_TIPO_UNI = 7)"
                        Else
                            CADENA_UNIDAD = "(U.CVE_TIPO_UNI = " & TipoUnidad & ")"
                        End If

                        SQL = "Select TRY_PARSE(U.CLAVE As INT), U.CLAVEMONTE, U.DESCR As NOMB_UNIDAD, U.PLACAS_MEX, M.DESCR As MARCA, 
                            ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0), ISNULL(T.DESCR,'') AS TIPOUNI 
                            FROM GCUNIDADES U 
                            LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                            LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI 
                            WHERE ISNULL(U.STATUS, 'A') = 'A' AND " & CADENA_UNIDAD & " AND " &
                            "(TRY_PARSE(U.CLAVE AS INT) LIKE '%" & tBox.Text.ToUpper & "%' OR CLAVEMONTE LIKE '%" & tBox.Text.ToUpper & "%' OR 
                            UPPER(U.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(U.PLACAS_MEX) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                            UPPER(M.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR U.CVE_TIPO_UNI LIKE '%" & tBox.Text.ToUpper & "%') 
                            ORDER by U.CLAVEMONTE"
                    Else
                        SQL = "SELECT TRY_PARSE(U.CLAVE AS INT), U.CLAVEMONTE, U.DESCR AS NOMB_UNIDAD, U.PLACAS_MEX, M.DESCR AS MARCA, 
                            ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0), T.DESCR AS TIPOUNI 
                            FROM GCUNIDADES U 
                            LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                            LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI  
                            WHERE ISNULL(U.STATUS, 'A') = 'A' AND (" &
                            "TRY_PARSE(U.CLAVE As INT) Like '%" & tBox.Text.ToUpper & "%' OR CLAVEMONTE LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(U.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                            UPPER(U.PLACAS_MEX) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(M.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR U.CVE_TIPO_UNI LIKE '%" & tBox.Text.ToUpper & "%') 
                            ORDER BY U.CLAVEMONTE"
                    End If
                    Var4 = ""
                Case "UnidadesInspec"
                    SQL = "SELECT TRY_PARSE(U.CLAVE AS INT), U.CLAVEMONTE, U.DESCR AS NOMB_UNIDAD, U.PLACAS_MEX, M.DESCR AS MARCA, 
                        ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0), T.DESCR AS TIPOUNI 
                        FROM GCUNIDADES U 
                        LEFT JOIN GCINSPEC_LLANTAS I ON I.UNIDAD = U.CLAVEMONTE 
                        LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                        LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI  
                        WHERE ISNULL(U.STATUS, 'A') = 'A'  AND ISNULL(I.STATUS,'') <> 'E' AND (" &
                        "TRY_PARSE(U.CLAVE As INT) Like '%" & tBox.Text.ToUpper & "%' OR CLAVEMONTE LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(U.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(U.PLACAS_MEX) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(M.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR U.CVE_TIPO_UNI LIKE '%" & tBox.Text.ToUpper & "%') 
                        ORDER BY U.CLAVEMONTE"
                    Var4 = ""
                Case "Uni_Viaje"
                    SQL = "SELECT A.CVE_VIAJE, U.CLAVEMONTE AS UNIDAD, T.DESCR AS TIPOUNI, U.PLACAS_MEX, M.DESCR AS MARCA, 
                        ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0)
                        FROM GCUNIDADES U 
                        LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                        LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI 
                        INNER JOIN GCASIGNACION_VIAJE A ON A.CVE_TRACTOR = U.CLAVEMONTE
                        WHERE ISNULL(U.STATUS, 'A') = 'A' AND (U.CVE_TIPO_UNI = 0 OR U.CVE_TIPO_UNI = 1 OR U.CVE_TIPO_UNI = 7) AND 
                        A.CVE_ST_VIA <> 5 " & IIf(PARAM_VAR.Trim.Length > 0, " AND A.CVE_OPER = '" & PARAM_VAR & "'", "") & " AND
                        (TRY_PARSE(U.CLAVE As INT) Like '%" & tBox.Text.ToUpper & "%' OR CLAVEMONTE LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(T.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(U.PLACAS_MEX) Like '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(M.DESCR) LIKE '%" & tBox.Text.ToUpper & "%' OR U.CVE_TIPO_UNI LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        CVE_VIAJE LIKE '%" & tBox.Text.ToUpper & "%') 
                        ORDER by A.FECHAELAB DESC"
                Case "Cliente operativo"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.DOMICILIO, ISNULL(C.NOTA,0) AS C_NOTA
                        FROM GCCLIE_OP C
                        WHERE C.STATUS = 'A' and C.CLAVE Like '%" & tBox.Text.ToUpper & "%' OR UPPER(NOMBRE) LIKE '%" & tBox.Text.ToUpper & "%' OR 
                        UPPER(DOMICILIO) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(NOTA) LIKE '%" & tBox.Text.ToUpper & "%'
                        ORDER BY TRY_PARSE(C.CLAVE AS INT) "
                Case "RecogerEn", "EntregarEn"
                    SQL = "SELECT TRY_PARSE(CVE_REG AS INT) AS CVEREG, DESCR 
                        FROM GCRECOGER_EN_ENTREGAR_EN 
                        WHERE STATUS = 'A' AND
                        (CVE_REG Like '%" & tBox.Text.ToUpper & "%' OR UPPER(DESCR) LIKE '%" & tBox.Text.ToUpper & "%')
                        ORDER BY TRY_PARSE(CVE_REG AS INT)"
                Case "Plazas"
                    If Fg.Rows.Count > 0 Then
                        SQL = "SELECT CLAVE, CIUDAD, MUNICIPIO FROM GCPLAZAS WHERE STATUS = 'A' AND " &
                            "(CLAVE LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(CIUDAD) LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(MUNICIPIO) LIKE '%" & tBox.Text.ToUpper & "%') " &
                            "ORDER BY CLAVE"
                    End If
                Case "Operador"
                    SQL = "SELECT CLAVE, NOMBRE, LICENCIA, LIC_VENC FROM GCOPERADOR WHERE STATUS = 'A' AND " &
                        "(CLAVE LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(NOMBRE) LIKE '%" & tBox.Text.ToUpper.ToUpper & "%' OR UPPER(LICENCIA) LIKE '%" & tBox.Text.ToUpper & "%') " &
                        "ORDER BY CLAVE"
                Case "GCPRODUCTOS", "Productos"
                    SQL = "SELECT CVE_PROD, DESCR FROM GCPRODUCTOS " &
                        "WHERE STATUS = 'A' AND " &
                        "(CVE_PROD LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(DESCR) LIKE '%" & tBox.Text.ToUpper & "%') "
                Case "Valor Declarado"
                    SQL = "SELECT E.CLAVE, E.DESCR, E.IMPORTE " &
                        "FROM GCVALOR_DECLARADO E " &
                        "WHERE E.STATUS = 'A' AND " &
                        "(CLAVE LIKE '%" & tBox.Text.ToUpper & "%' OR UPPER(E.DESCR) LIKE '%" & tBox.Text.ToUpper & "%') " &
                        "ORDER BY E.CLAVE"
            End Select
            DESPLEGAR()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Try
                BarBuscar_Click(Nothing, Nothing)
            Catch ex As Exception
                Bitacora(ex.Message & vbNewLine & ex.StackTrace)
                MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub Fg_KeyUp(sender As Object, e As KeyEventArgs) Handles Fg.KeyUp
        If e.KeyCode = Keys.Left And Fg.Col = 1 Then
            tBox.Focus()
        End If
    End Sub
    Private Sub TBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub TITULOS()

        Try
            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Estado"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Fecha"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(DateTime)

            Fg(0, 5) = "Oprador"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Unidad"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Motor"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Calif. factor carga"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Calif. ralenti"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Calif. vel. max."
            Dim c10 As Column = Fg.Cols(9)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Calif. global"
            Dim c11 As Column = Fg.Cols(10)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Bono"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Odometro"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Km ECM"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Lts. ECM"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Lts. Real"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "KM. Tabulador"
            Dim c17 As Column = Fg.Cols(17)
            c17.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "LTS. Tabulador"
            Dim c18 As Column = Fg.Cols(18)
            c18.DataType = GetType(Decimal)
            Fg.Cols(18).Format = "###,###,##0.00"

            Fg(0, 19) = "Factor de carga"
            Dim c19 As Column = Fg.Cols(19)
            c19.DataType = GetType(Int16)

            Fg(0, 20) = "Hrs. trabajo"
            Dim c20 As Column = Fg.Cols(20)
            c20.DataType = GetType(Decimal)
            Fg.Cols(20).Format = "###,###,##0.00"

            Fg(0, 21) = "Hrs. PTO. RALENTI"
            Dim c21 As Column = Fg.Cols(21)
            c21.DataType = GetType(Decimal)
            Fg.Cols(21).Format = "###,###,##0.00"

            Fg(0, 22) = "Lts. PTO. RALENTI"
            Dim c22 As Column = Fg.Cols(22)
            c22.DataType = GetType(Decimal)
            Fg.Cols(22).Format = "###,###,##0.00"

            Fg(0, 23) = "% Tiempo PTO RALENTI"
            Dim c23 As Column = Fg.Cols(23)
            c23.DataType = GetType(Decimal)
            Fg.Cols(23).Format = "###,###,##0.00"

            Fg(0, 24) = "% Lts PTO RALENTI"
            Dim c24 As Column = Fg.Cols(24)
            c24.DataType = GetType(Decimal)
            Fg.Cols(24).Format = "###,###,##0.00"

            Fg(0, 25) = "Rendimiento ECM"
            Dim c25 As Column = Fg.Cols(25)
            c25.DataType = GetType(Decimal)
            Fg.Cols(25).Format = "###,###,##0.00"

            Fg(0, 25) = "Porc. var. lts. real"
            Dim c26 As Column = Fg.Cols(26)
            c26.DataType = GetType(Decimal)
            Fg.Cols(26).Format = "###,###,##0.00"

            Fg(0, 27) = "Porc. var. lts. tab. real"
            Dim c27 As Column = Fg.Cols(27)
            c27.DataType = GetType(Decimal)
            Fg.Cols(27).Format = "###,###,##0.00"

            Fg(0, 28) = "Rendimiento real"
            Dim c28 As Column = Fg.Cols(28)
            c28.DataType = GetType(Decimal)
            Fg.Cols(28).Format = "###,###,##0.00"

            Fg(0, 29) = "Dif. lts. real. lts. ECM"
            Dim c29 As Column = Fg.Cols(29)
            c29.DataType = GetType(Decimal)
            Fg.Cols(29).Format = "###,###,##0.00"

            Fg(0, 30) = "Dif. lts. real lts. TAB"
            Dim c30 As Column = Fg.Cols(30)
            c30.DataType = GetType(Decimal)
            Fg.Cols(30).Format = "###,###,##0.00"
        Catch ex As Exception
        End Try
    End Sub
End Class
