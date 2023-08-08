Imports System.IO
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmPreOCCompra
    Private ENTRA As Boolean = True
    Private OBSER As String = ""
    Private OBSER_PAR As String = ""
    Private CompEdit As Boolean = 0
    Private FgModif As Boolean = True
    Private SERIE_PRE_OC As String = ""
    Private SERIE_OC_DESDE_PRE_OC As String = ""
    Private FOLIO_PRE_OC As Long = 0
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

            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            Fg.Styles.Fixed.WordWrap = True
            Fg.Rows(0).Height = 50
            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg.Rows.Count = 1
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG


            Fg.Styles("Highlight").BackColor = Color.CornflowerBlue
            Fg.Styles("Focus").BackColor = Color.White
            Fg.Styles("Focus").Border.Color = Color.Red
            Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double

            SplitM1.Dock = DockStyle.Fill
            SplitM1.BorderWidth = 1
            SplitM1.SplitterWidth = 1

            Fg.Dock = DockStyle.Fill
            Fg.Cols(13).Visible = False


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

            Dim N = DateTime.Now.AddMonths(-1)
            Dim D1 As String, D2 As String

            D1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

            F1.Value = D1
            F2.Value = D2

            BtnLinea.FlatStyle = FlatStyle.Flat
            BtnLinea.FlatAppearance.BorderSize = 0

            Fg.Cols(1).Width = 80
            Fg.Cols(2).Width = 200
            Fg.Cols(3).Width = 65
            Fg.Cols(5).Width = 90 'FECHA ULT ORDEN DE COMPRA
            Fg.Cols(6).Width = 70 'FECHA ULTIMA COMPRA
            Fg.Cols(7).Width = 60 'DIFERENCIA
            Fg.Cols(8).Width = 60 'EXISTENCIA
            Fg.Cols(9).Width = 80 'CANIDAD ULTIMA COMPRA
            Fg.Cols(10).Width = 100
            Fg.Cols(11).Width = 80 'SUGERIDO DE ORDEN DE COMPRA
            Fg.Cols(12).Width = 100 'CANIDAD A PEDIR

            Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter


            AJUSTA_COLUMNAS_FG(Fg, 10)

        Catch ex As Exception
        End Try
        Try
            C1List1.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                SQL = "SELECT EMPRESA, NOMBRE, SERVIDOR, BASE, USUARIO, PASS 
                        FROM EMPRESAS WHERE ISNULL(VISIBLE,1) = 1 ORDER BY EMPRESA"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If dr("EMPRESA") <> Empresa Then
                            C1List1.AddItem(dr("EMPRESA") & ";" & dr("NOMBRE"))
                        Else
                            LtEmpresa.Text = dr("EMPRESA") & " " & dr("NOMBRE")
                        End If
                    End While
                End Using
            End Using
            Me.C1List1.Splits(0).DisplayColumns(0).Width = 50

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            CARGA_PARAM_COMPRAS()

            If Var11 = "edit" Then
                CompEdit = True
                LtCVE_DOC.Text = Var12
                BarImprimir.Enabled = True

                Lt2.Text = "Orden de compra generada: " & Var13

                BUSCAR_COMPRA(Var12)
            Else
                FOLIO_PRE_OC = SIGUIENTE_FOLIO_COMPRA("p", SERIE_PRE_OC)

                If SERIE_PRE_OC.Trim.Length = 0 Or SERIE_PRE_OC = "STAND." Then
                    LtCVE_DOC.Text = "          " & Format(FOLIO_PRE_OC, "0000000000")
                Else
                    LtCVE_DOC.Text = SERIE_PRE_OC & Format(FOLIO_PRE_OC, "0000000000")
                End If

                LtFecha.Text = Now
                BarImprimir.Enabled = False
            End If

            ProcessControls(Me)

        Catch ex As Exception
            MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("5. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPreOrdenDeCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion_SAROCE() Then
            Me.Close()
            Return
        End If
        If Var4 = "NO EXISTE" Then
            MsgBox("No existen series de Pre-Orden de compra, favor de agregarlo en parámetros-compras-series")
            Me.Close()
        End If

    End Sub
    Sub CARGA_PARAM_COMPRAS()
        Try
            SQL = "SELECT ISNULL(SERIE_PRE_OC,'') AS S_COMPRA, ISNULL(SERIE_OC_DESDE_PRE_OC,'') AS SER_OC_DESDE_PRE_OC
                  FROM GCPARAMCOMPRAS"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SERIE_PRE_OC = dr.ReadNullAsEmptyString("S_COMPRA")
                        SERIE_OC_DESDE_PRE_OC = dr.ReadNullAsEmptyString("SER_OC_DESDE_PRE_OC")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("28. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("28. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPreOrdenDeCompra_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Pre-Orden de compra")
        Me.Dispose()

        If FORM_IS_OPEN("FrmPreOCDocs") Then
            frmComprasDoc.DESPLEGAR()
        End If

    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Dim EMPRESA_DEST As String, CVE_DOC As String, COMPRA_SUGERIDA As Decimal, FORMULA As Decimal
        Dim DIF As Decimal, j As Long = 0, FECHA_ULT_COMP As String, CANT_ULT As Decimal, FECH_ULT_OC As String
        Dim SUMA_VENTAS As Decimal, SUMA_EXIST As Decimal, LINEA As String, CANT_SUG As Decimal = 0
        Dim CADENA_CS As String = "", CADENA_CS2 As String = "", SIGUE As Boolean = True, s As String

        LINEA = BUSCA_CAT("Linea", TLINEA.Text)
        If LINEA = "" Then
            MsgBox("Linea inexistente verifique por favor")
            Return
        End If

        Fg.Rows.Count = 1
        Me.Cursor = Cursors.WaitCursor
        Fg.Redraw = False

        If CompEdit Then
            CADENA_CS = "OUTER APPLY (SELECT ISNULL(SUM(CANT),0) AS CANT_SUG 
                        FROM COMPO_PRE_PAR P1
                        LEFT JOIN COMPO_PRE CC ON CC.CVE_DOC = P1.CVE_DOC
                        WHERE CC.STATUS <> 'C' AND P1.CVE_DOC = '" & LtCVE_DOC.Text & "' AND CVE_ART = I.CVE_ART) AS SQ2 "
            CADENA_CS2 = ", SQ2.CANT_SUG"
        End If

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT I.CVE_ART, I.DESCR, ISNULL(I.STOCK_MIN,0) AS S_MIN, ISNULL(I.STOCK_MAX, 0) AS S_MAX, I.EXIST, ISNULL(I.COMP_X_REC,0) AS COMP_X_R,
                    ISNULL((SELECT SUM(CANT) FROM PAR_FACTF" & Empresa & " P LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                    WHERE F.STATUS <> 'C' AND FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' AND
                    CVE_ART = I.CVE_ART),0) AS VENTAS_V,
                    ISNULL((SELECT TOP 1 FECHA_DOC FROM PAR_COMPO" & Empresa & " P 
                    LEFT JOIN COMPO" & Empresa & " F ON F.CVE_DOC = P.CVE_DOC WHERE F.STATUS <> 'C' AND CVE_ART = I.CVE_ART),0) AS FECH_ULT_OC,
                    ISNULL(SQ.CVE_DOC,'') AS CVE_DOC_COM, ISNULL(SQ.CANT,0) AS CANT_COM, SQ.CVE_CLPV, SQ.NOMBRE,
                    ISNULL(SQ.FECHA_DOC,'') AS FECHA_DOC_COM" & CADENA_CS2 & "
                    FROM INVE" & Empresa & " I 
                    OUTER APPLY  (SELECT TOP 1 P.CVE_ART, P.CVE_DOC, CANT, FECHA_DOC, F.CVE_CLPV, PROV.NOMBRE
                            FROM PAR_COMPC" & Empresa & " P 
                            LEFT JOIN COMPC" & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                            LEFT JOIN PROV" & Empresa & " PROV ON PROV.CLAVE = F.CVE_CLPV
                            WHERE F.STATUS <> 'C' AND P.CVE_ART = I.CVE_ART AND SUBSTRING(PROV.CLASIFIC,1,3) = '" & TLINEA.Text & "'
                            ORDER BY FECHAELAB DESC) AS SQ " & CADENA_CS & "
                            WHERE I.STATUS <> 'B' AND I.LIN_PROD = '" & TLINEA.Text & "'
                            ORDER BY CVE_ART"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If SIGUE Then
                            SIGUE = False
                            LtProv.Text = dr.ReadNullAsEmptyString("CVE_CLPV")
                            LtNombre.Text = dr.ReadNullAsEmptyString("NOMBRE")
                        End If
                        CVE_DOC = dr("CVE_DOC_COM")
                        CANT_ULT = dr("CANT_COM")
                        If dr("FECH_ULT_OC").Year <= 1990 Then
                            FECH_ULT_OC = ""
                        Else
                            FECH_ULT_OC = dr("FECH_ULT_OC")
                        End If
                        If dr("FECHA_DOC_COM").Year <= 1990 Then
                            FECHA_ULT_COMP = ""
                        Else
                            FECHA_ULT_COMP = dr("FECHA_DOC_COM")
                        End If
                        DIF = 0
                        If FECH_ULT_OC.Trim.Length > 0 And FECHA_ULT_COMP.Trim.Length > 0 Then
                            If IsDate(FECHA_ULT_COMP) Then
                                If Convert.ToDateTime(FECHA_ULT_COMP).Year > 1990 Then
                                    DIF = DateDiff(DateInterval.Day, dr("FECH_ULT_OC"), Convert.ToDateTime(FECHA_ULT_COMP))
                                    If DIF < 0 Then DIF = 0
                                End If
                            End If
                        End If

                        SUMA_EXIST = dr("EXIST")
                        SUMA_VENTAS = dr("VENTAS_V")

                        For row As Integer = 0 To C1List1.ListCount - 1
                            Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
                            If C1List1.GetSelected(row) Then
                                EMPRESA_DEST = cellValue.ToString

                                If EMPRESA_DEST <> Empresa Then
                                    If OpenEmpresa(EMPRESA_DEST) Then 'cnEMPRESA
                                        SQL = "SELECT ISNULL(EXIST,0) AS EXIS, SQ.SUMA_VTA
                                        FROM INVE" & EMPRESA_DEST & " I
                                        OUTER APPLY (SELECT ISNULL(SUM(CANT),0) AS SUMA_VTA FROM PAR_FACTV" & EMPRESA_DEST & " P 
                                        LEFT JOIN FACTV" & EMPRESA_DEST & " F ON F.CVE_DOC = P.CVE_DOC
                                        WHERE F.STATUS <> 'C' AND FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' AND 
                                        P.CVE_ART = I.CVE_ART) AS SQ
                                        WHERE CVE_ART = '" & dr("CVE_ART") & "'"

                                        Using cmd2 As SqlCommand = cnEMPRESA.CreateCommand
                                            cmd2.CommandText = SQL
                                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                                If dr2.Read Then
                                                    SUMA_VENTAS += dr2("SUMA_VTA")
                                                    SUMA_EXIST += dr2("EXIS")
                                                End If
                                            End Using
                                        End Using

                                    End If
                                End If
                            End If
                        Next

                        If SUMA_EXIST < 0 Then SUMA_EXIST = 0

                        FORMULA = SUMA_VENTAS * (DIF / 30)

                        COMPRA_SUGERIDA = SUMA_VENTAS - SUMA_EXIST + FORMULA

                        If COMPRA_SUGERIDA < 0 Then COMPRA_SUGERIDA = 0

                        Try
                            If CompEdit Then
                                CANT_SUG = dr("CANT_SUG")
                                If CANT_SUG < 0 Then CANT_SUG = 0
                            Else
                                CANT_SUG = 0
                            End If
                        Catch ex As Exception
                            Bitacora("50. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try

                        s = dr("CVE_ART") & vbTab '1    
                        s &= dr("DESCR") & vbTab '2 
                        s &= SUMA_VENTAS & vbTab '3 'VENDIDO AL RANGO DE FECHAS (VENDIDO A 30 DIAS)
                        s &= CVE_DOC & vbTab '4 ULTIMA COMPRAS
                        s &= FECH_ULT_OC & vbTab '5 Fecha ultima orde de compra
                        s &= FECHA_ULT_COMP & vbTab '6  Fecha ultima compra
                        s &= DIF & vbTab '7 Diferencia (Dias)
                        s &= SUMA_EXIST & vbTab '8  Existencia
                        s &= CANT_ULT & vbTab '9    Cantidad ultima compra
                        s &= FORMULA & vbTab '10    Cantidad entre Dif De orde de compra y Compra
                        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                        s &= COMPRA_SUGERIDA & vbTab '11    Sugerido de orden de compra   AQUI
                        s &= CANT_SUG & vbTab '12   Cantidad a pedir
                        s &= 0 '13  NUM_PAR
                        Fg.AddItem("" & vbTab & s)
                        j += 1
                        Lt1.Text = "Artículos " & j
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Fg.AutoSizeCols()


        Fg.Cols(3).Width = 65
        Fg.Cols(5).Width = 90 'FECHA ULT ORDEN DE COMPRA
        Fg.Cols(6).Width = 70 'FECHA ULTIMA COMPRA
        Fg.Cols(7).Width = 60 'DIFERENCIA
        Fg.Cols(8).Width = 60 'EXISTENCIA
        Fg.Cols(9).Width = 80 'CANIDAD ULTIMA COMPRA
        Fg.Cols(10).Width = 100
        Fg.Cols(11).Width = 80 'SUGERIDO DE ORDEN DE COMPRA
        Fg.Cols(12).Width = 100 'CANIDAD A PEDIR

        Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter


        AJUSTA_COLUMNAS_FG(Fg, 0, 2)

        Me.Cursor = Cursors.Default
        Fg.Redraw = True

        MsgBox("Proceso terminado")
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Pre Orden de compra")
    End Sub
    Private Sub BarGenOrdenCompra_Click(sender As Object, e As ClickEventArgs) Handles BarGenOrdenCompra.Click
        Dim Continua As Boolean

        Dim FOLIO_ASIGNADO As Boolean, CVE_DOC As String, DESCR As String, CANT As Decimal, CVE_ART As String, COSTO As Decimal
        Dim IMPORTE As Decimal, IMPU1 As Decimal, IMPU4 As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer
        Dim IMP4APLA As Integer, CVE_ESQIMPU As Integer, UNI_MED As String, IMP_TOT1 As Decimal, IMP_TOT4 As Decimal, cIeps As Decimal, cImpu As Decimal
        Dim nClavesNoEncontradas As Integer, CVE_CLPV As String, PREC As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, ACT_INV As String, TIP_CAM As Integer
        Dim TIPO_ELEM As String, TIPO_PROD As String, CVE_OBS As Integer, REG_SERIE As Integer, E_LTPD As Integer, FACTCONV As Decimal
        Dim MINDIRECTO As Integer, NUM_MOV As Long, MAN_IEPS As String, APL_MAN_IMP As Decimal, CUOTA_IEPS As Decimal, APL_MAN_IEPS As String
        Dim MTO_PORC As Decimal, MTO_CUOTA As Decimal, NUM_PAR As Integer, NUM_ALM As Integer, TOT_PARTIDA As Decimal, DESCU As Decimal, TOTIMP1 As Decimal
        Dim TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, ImporteIeps As Decimal, ImporteImpu2 As Decimal
        Dim ImporteImpu3 As Decimal, ImporteIVA As Decimal, STATUS As String, TIP_DOC As String, IMP_TOT2 As Decimal, IMP_TOT3 As Decimal, TOT_IND As Decimal
        Dim OBS_COND As String, ACT_CXP As String, ACT_COI As String, NUM_MONED As Integer, TIPCAMB As Integer, ENLAZADO As String, TIP_DOC_E As String
        Dim CTLPOL As Integer, ESCFD As String, CONTADO As String, BLOQ As String, DES_FIN_PORC As Decimal, DES_TOT_PORC As Decimal, TIP_DOC_ANT As String
        Dim DOC_ANT As String, TIP_DOC_SIG As String, DOC_SIG As String, FORMAENVIO As String, SU_REFER As String, CAN_TOT As Decimal
        Dim DES_TOT As Decimal, DES_FIN As Decimal, FOLIO As Long, ULT_DOC As Long
        'MOVSINV
        Dim COSTO_PROMEDIO As Decimal, CVE_CPTO As Integer, CLAVE_CLPV As String, Vend As String, CANT_COST As Decimal, UNI_VENTA As String
        Dim FACTOR_CON As Decimal, SIGNO As Integer, COSTEADO As String, COSTO_PROM_INI As Decimal, COSTO_PROM_FIN As Decimal, COSTO_PROM As Decimal
        Dim DESDE_INVE As String, MOV_ENLAZADO As Integer, NUM_CPTO As Integer, NUM_CARGO As Int16
        Dim AFEC_COI As String, TCAMBIO As Int16, CVE_FOLIO As String, TIPO_MOV As String, CVE_AUT As Integer, ENTREGADA As String, REF_SIST As String
        Dim FECHA_REC As String, ULT_COSTO As Decimal, TIPO_ELE As String, Usuario2 As Integer, DESC1 As Decimal, Sigue As Boolean, Exist_esquema_imp As Boolean
        Dim VENTA_RANGO_FECH As Decimal, CVE_DOC_COM As String, FECHA_ULT_OC As String, FECHA_ULT_COMPRA As String, DIF As Decimal
        Dim EXIST As Decimal, CANT_ULT_COMP As Decimal, CANT_ENT_DIF_OC_Y_COMP As Decimal, CANT_SUG_OC As Decimal
        Dim FOLIO_OC_DESDE_PRE As Long = 0
        Dim cmdProv As New SqlCommand
        Dim cmd As New SqlCommand
        Dim Reader As SqlDataReader

        CVE_DOC = ""
        Try
            Fg.FinishEditing()
        Catch ex As Exception
        End Try
        If Not Valida_Conexion() Then
            Return
        End If
        CVE_CLPV = LtProv.Text.Trim
        SU_REFER = LtCVE_DOC.Text

        OBS_COND = BUSCA_CAT("Prov", CVE_CLPV)
        If OBS_COND = "" Then
            MsgBox("Proveedor inexistente verifique por favor")
            Return
        End If

        OBS_COND = ""
        Usuario2 = 0
        For i As Integer = 1 To Fg.Rows.Count - 1
            Try
                If Not IsNothing(Fg(i, 1)) Then
                    CVE_ART = Fg(i, 1)
                    CVE_ART = CVE_ART.Replace("'", "")
                    CVE_ART = RemoveCharacter(CVE_ART)
                Else
                    CVE_ART = ""
                End If
                If IsNothing(Fg(i, 12)) Then
                    CANT = 0
                Else
                    If IsNumeric(Fg(i, 12)) Then
                        CANT = Fg(i, 12)
                    Else
                        CANT = 0
                    End If
                End If
                If CVE_ART.Length > 0 And CANT > 0 Then
                    Usuario2 += 1
                End If
            Catch ex As Exception
            End Try
        Next

        If Usuario2 = 0 Then
            MsgBox("No se encontraron artículos con la cantidad capturada, por favor capture la cantidad a pedir")
            Return
        Else
            Usuario2 = 0
        End If

        If MsgBox("Realmente desea generar la orden de compra?", vbYesNo) = vbNo Then
            Return
        End If

        Try
            Sigue = True
            FOLIO_ASIGNADO = False

            FOLIO_OC_DESDE_PRE = SIGUIENTE_FOLIO_COMPRA("o", SERIE_OC_DESDE_PRE_OC)

            Do While Sigue

                If SERIE_OC_DESDE_PRE_OC.Trim.Length = 0 Or SERIE_OC_DESDE_PRE_OC = "STAND." Then
                    CVE_DOC = Space(10) & Format(FOLIO_OC_DESDE_PRE, "0000000000")
                Else
                    CVE_DOC = SERIE_OC_DESDE_PRE_OC & Format(FOLIO_OC_DESDE_PRE, "0000000000")
                End If

                If EXISTE_COMPRA("o", CVE_DOC) Then
                    FOLIO_OC_DESDE_PRE += 1
                    FOLIO_ASIGNADO = True
                Else
                    Sigue = False
                End If
            Loop
            ULT_DOC = FOLIO_OC_DESDE_PRE
            FOLIO = ULT_DOC
        Catch ex As Exception
            Bitacora("61. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'PROV
        ULT_COSTO = 0 : TIPO_ELE = "P"
        CVE_ESQIMPU = 1
        Dim dt As DateTime = F1.Value
        FECHA_REC = dt.Year & Format(dt.Month, "00") & Format(dt.Day, "00")

        cmd.Connection = cnSAE

        Me.Cursor = Cursors.WaitCursor
        Try

            Dim cmdExist As New SqlCommand
            Sigue = True
            IMPORTE = 0 : nClavesNoEncontradas = 0 : TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0 : CAN_TOT = 0 : DESCR = ""
            Exist_esquema_imp = False

            For i As Integer = 1 To Fg.Rows.Count - 1
                If Not Valida_Conexion() Then
                End If

                Try
                    If Not IsNothing(Fg(i, 1)) Then
                        CVE_ART = Fg(i, 1)
                        CVE_ART = CVE_ART.Replace("'", "")
                        CVE_ART = RemoveCharacter(CVE_ART)
                    Else
                        CVE_ART = ""
                    End If

                    If IsNothing(Fg(i, 12)) Then
                        CANT = 0
                    Else
                        If IsNumeric(Fg(i, 12)) Then
                            CANT = Fg(i, 12)
                        Else
                            CANT = 0
                        End If
                    End If

                    If CVE_ART.Length > 0 And CANT > 0 Then
                        DESC1 = 0
                        UNI_MED = ""
                        Try
                            SQL = "SELECT * FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"

                            cmd.CommandText = SQL
                            Reader = cmd.ExecuteReader
                            If Reader.HasRows Then
                                If Reader.Read Then
                                    ULT_COSTO = Reader("ULT_COSTO")
                                    COSTO_PROM = Reader("COSTO_PROM")
                                    CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                                    TIPO_ELE = Reader("TIPO_ELE")
                                Else
                                    Bitacora("1. PROBLEMA DETECTADO EN GUARDAR NO SE ENCONTRO EL ARTICULO " & CVE_ART & " frmCOMPRAS " & SQL)
                                End If
                            End If
                            Reader.Close()

                            cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            Reader = cmd.ExecuteReader
                            If Reader.Read Then
                                IMPU1 = CSng(Reader("IMPUESTO1"))
                                IMPU2 = CSng(Reader("IMPUESTO2"))
                                IMPU3 = CSng(Reader("IMPUESTO3"))
                                IMPU4 = CSng(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP2APLA = CInt(Reader("IMP2APLICA"))
                                IMP3APLA = CInt(Reader("IMP3APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            Else
                                Bitacora("1. PROBLEMA DETECTADO EN GUARDAR NO SE ENCONTRO EL ESQUEMA IMPUESTO frmComprasTrans " & SQL)
                            End If
                            Reader.Close()

                        Catch ex As Exception
                            Bitacora("141. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            MsgBox("141. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            COSTO = ULT_COSTO

                            DES_TOT = 0
                            cIeps = COSTO * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cImpu2 = CSng((COSTO + cIeps) * IMPU2 / 100)
                            Else
                                cImpu2 = CSng(COSTO * IMPU2 / 100)
                            End If

                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cImpu3 = CSng((COSTO + cIeps + cImpu2) * IMPU3 / 100)
                            Else
                                cImpu3 = CSng(COSTO * IMPU3 / 100)
                            End If

                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cImpu = (COSTO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cImpu = COSTO * IMPU4 / 100
                            End If

                            ImporteIeps += (COSTO * CANT * IMPU1 / 100)
                            ImporteImpu2 += (COSTO * CANT * IMPU2 / 100)
                            ImporteImpu3 += (COSTO * CANT * IMPU3 / 100)
                            ImporteIVA += COSTO * CANT * IMPU4 / 100

                            TOTIMP1 += (CANT * cIeps)
                            TOTIMP2 += (CANT * cImpu2)
                            TOTIMP3 += (CANT * cImpu3)
                            TOTIMP4 += (CANT * cImpu)

                            IMPORTE += (CANT * (COSTO + cIeps + cImpu2 + cImpu3 + cImpu))

                            CAN_TOT += (CANT * COSTO)

                            DESCU = 0
                        Catch ex As Exception
                            MsgBox("142. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("142. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                Catch ex As Exception
                    MsgBox("143. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("143. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            Next
            IMP_TOT1 = TOTIMP1
            IMP_TOT2 = TOTIMP2
            IMP_TOT3 = TOTIMP3
            IMP_TOT4 = TOTIMP4

            DES_TOT_PORC = 0
            DES_TOT = 0

            CVE_OBS = 0 : DES_FIN = 0
            STATUS = "E" : TIP_DOC = "p" : TOT_IND = 0 : ACT_CXP = "S" : ACT_COI = "N" : NUM_MONED = 1 : TIPCAMB = 1
            ENLAZADO = "O" : TIP_DOC_E = "O" : CTLPOL = 0 : ESCFD = "N" : CONTADO = "N" : BLOQ = "N" : DES_FIN_PORC = 0
            TIP_DOC_ANT = "p" : DOC_ANT = LtCVE_DOC.Text : TIP_DOC_SIG = "" : DOC_SIG = "" : FORMAENVIO = ""
            PREC = 0 : IMPU2 = 0 : IMPU3 = 0 : ACT_INV = "S" : TIP_CAM = 1 : TIPO_ELEM = "N" : TIPO_PROD = "P"
            CVE_OBS = 0 : REG_SERIE = 0 : E_LTPD = 0 : FACTCONV = 1 : MINDIRECTO = 0 : NUM_MOV = 0 : MAN_IEPS = "N" : APL_MAN_IMP = 1
            CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
            NUM_CARGO = 1 : AFEC_COI = "A" : NUM_MONED = 1 : TCAMBIO = 1 : CTLPOL = 0 : CVE_FOLIO = ""
            TIPO_MOV = "A" : CVE_AUT = 0 : Usuario2 = "0" : ENTREGADA = "S" : REF_SIST = ""

            NUM_CPTO = 1 'CXP
            CVE_CPTO = 1 'MOVS INV
            SIGNO = 1
            NUM_ALM = 1
            OBSER = RemoveCharacter(OBSER)

            If OBSER.Trim.Length > 0 Then
                If TIPO_OTI = 0 Then
                    INSERT_UPDATE_OBS_COMP_CLIB(CVE_DOC, "P", OBSER)
                Else
                    Try
                        If IsNumeric(LtDescrLinea.Tag) Then
                            CVE_OBS = LtDescrLinea.Tag
                        Else
                            CVE_OBS = 0
                        End If
                    Catch ex As Exception
                        Bitacora("144. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    CVE_OBS = INSERT_UPDATE_OBS(CVE_OBS, OBSER)
                End If
            End If

            Try
                For k As Integer = 1 To 5
                    SQL = "INSERT INTO COMPO" & Empresa & " (TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, SU_REFER, FECHA_DOC, FECHA_REC, 
                        FECHA_PAG, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, TOT_IND, OBS_COND, CVE_OBS, NUM_ALMA, ACT_CXP, 
                        ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, SERIE, FOLIO, CTLPOL, ESCFD, CONTADO, BLOQ, DES_FIN_PORC, 
                        DES_TOT_PORC, IMPORTE, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, FORMAENVIO) VALUES (@TIP_DOC, @CVE_DOC, @CVE_CLPV, @STATUS, 
                        @SU_REFER, @FECHA_DOC, @FECHA_REC, @FECHA_PAG, @CAN_TOT, @IMP_TOT1, @IMP_TOT2, @IMP_TOT3, @IMP_TOT4, @DES_TOT, @DES_FIN, @TOT_IND,  
                        @OBS_COND, @CVE_OBS, @NUM_ALMA, @ACT_CXP, @ACT_COI, @ENLAZADO, @TIP_DOC_E, @NUM_MONED, @TIPCAMB, @NUM_PAGOS, GETDATE(), @SERIE, 
                        @FOLIO, @CTLPOL, @ESCFD, @CONTADO, @BLOQ, @DES_FIN_PORC, @DES_TOT_PORC, @IMPORTE, @TIP_DOC_ANT, @DOC_ANT, @TIP_DOC_SIG, @DOC_SIG, 
                        @FORMAENVIO)"

                    Try
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@TIP_DOC", SqlDbType.VarChar).Value = "o"
                        cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                        cmd.Parameters.Add("@CVE_CLPV", SqlDbType.VarChar).Value = CVE_CLPV
                        cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "E"
                        cmd.Parameters.Add("@SU_REFER", SqlDbType.VarChar).Value = SU_REFER
                        cmd.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = Now
                        cmd.Parameters.Add("@FECHA_REC", SqlDbType.Date).Value = F1.Value
                        cmd.Parameters.Add("@FECHA_PAG", SqlDbType.Date).Value = F2.Value
                        cmd.Parameters.Add("@CAN_TOT", SqlDbType.Float).Value = Math.Round(CAN_TOT, 6)
                        cmd.Parameters.Add("@IMP_TOT1", SqlDbType.Float).Value = Math.Round(IMP_TOT1, 6)
                        cmd.Parameters.Add("@IMP_TOT2", SqlDbType.Float).Value = Math.Round(IMP_TOT2, 6)
                        cmd.Parameters.Add("@IMP_TOT3", SqlDbType.Float).Value = Math.Round(IMP_TOT3, 6)
                        cmd.Parameters.Add("@IMP_TOT4", SqlDbType.Float).Value = Math.Round(IMP_TOT4, 6)
                        cmd.Parameters.Add("@DES_TOT", SqlDbType.Float).Value = DES_TOT
                        cmd.Parameters.Add("@DES_FIN", SqlDbType.Float).Value = DES_FIN
                        cmd.Parameters.Add("@TOT_IND", SqlDbType.Float).Value = TOT_IND
                        cmd.Parameters.Add("@OBS_COND", SqlDbType.VarChar).Value = OBS_COND
                        cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                        cmd.Parameters.Add("@NUM_ALMA", SqlDbType.Int).Value = NUM_ALM
                        cmd.Parameters.Add("@ACT_CXP", SqlDbType.VarChar).Value = ACT_CXP
                        cmd.Parameters.Add("@ACT_COI", SqlDbType.VarChar).Value = ACT_COI
                        cmd.Parameters.Add("@ENLAZADO", SqlDbType.VarChar).Value = ENLAZADO
                        cmd.Parameters.Add("@TIP_DOC_E", SqlDbType.VarChar).Value = TIP_DOC_E
                        cmd.Parameters.Add("@NUM_MONED", SqlDbType.Int).Value = NUM_MONED
                        cmd.Parameters.Add("@TIPCAMB", SqlDbType.Float).Value = TIPCAMB
                        cmd.Parameters.Add("@NUM_PAGOS", SqlDbType.Int).Value = 1
                        cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE_OC_DESDE_PRE_OC
                        cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO
                        cmd.Parameters.Add("@CTLPOL", SqlDbType.Int).Value = CTLPOL
                        cmd.Parameters.Add("@ESCFD", SqlDbType.VarChar).Value = ESCFD
                        cmd.Parameters.Add("@CONTADO", SqlDbType.VarChar).Value = CONTADO
                        cmd.Parameters.Add("@BLOQ", SqlDbType.VarChar).Value = BLOQ
                        cmd.Parameters.Add("@DES_FIN_PORC", SqlDbType.Float).Value = DES_FIN_PORC
                        cmd.Parameters.Add("@DES_TOT_PORC", SqlDbType.Float).Value = DES_TOT_PORC
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                        cmd.Parameters.Add("@TIP_DOC_ANT", SqlDbType.VarChar).Value = TIP_DOC_ANT
                        cmd.Parameters.Add("@DOC_ANT", SqlDbType.VarChar).Value = DOC_ANT
                        cmd.Parameters.Add("@TIP_DOC_SIG", SqlDbType.VarChar).Value = TIP_DOC_SIG
                        cmd.Parameters.Add("@DOC_SIG", SqlDbType.VarChar).Value = DOC_SIG
                        cmd.Parameters.Add("@FORMAENVIO", SqlDbType.VarChar).Value = FORMAENVIO
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                        Exit For
                    Catch sqlEx As SqlException
                        If sqlEx.Number = 2627 Then
                        End If
                        Bitacora("53. " & sqlEx.Message & vbNewLine & sqlEx.StackTrace)
                    Catch ex As Exception
                        Bitacora("147. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("147. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        Sigue = True
                        FOLIO_ASIGNADO = False
                        Do While Sigue

                            If SERIE_OC_DESDE_PRE_OC.Trim.Length = 0 Or SERIE_OC_DESDE_PRE_OC = "STAND." Then
                                CVE_DOC = Space(10) & Format(FOLIO_OC_DESDE_PRE, "0000000000")
                            Else
                                CVE_DOC = SERIE_OC_DESDE_PRE_OC & Format(FOLIO_OC_DESDE_PRE, "0000000000")
                            End If

                            If EXISTE_COMPRA("o", CVE_DOC) Then
                                FOLIO_OC_DESDE_PRE += 1
                                FOLIO_ASIGNADO = True
                            Else
                                Sigue = False
                            End If
                        Loop
                        ULT_DOC = FOLIO_OC_DESDE_PRE
                        FOLIO = ULT_DOC
                    Catch ex As Exception
                        Bitacora("61. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            Catch ex As Exception
                MsgBox("158. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("158. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                Me.Cursor = Cursors.Default
                Return
            End Try
            '==========================================================================================================================================
            '               EMPIEZA PARTIDAS                  EMPIEZA PARTIDAS                  EMPIEZA PARTIDAS   
            '==========================================================================================================================================
            NUM_PAR = 1 : TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0

            For i As Integer = 1 To Fg.Rows.Count - 1

                If Not Valida_Conexion() Then
                End If
                Application.DoEvents()

                Try
                    CVE_ART = Fg(i, 1)
                    CVE_ART = CVE_ART.Replace("'", "")
                    CVE_ART = RemoveCharacter(CVE_ART)
                    If IsNothing(Fg(i, 12)) Then
                        CANT = 0
                    Else
                        CANT = Fg(i, 12)
                    End If
                Catch ex As Exception
                    CVE_ART = ""
                End Try


                If CVE_ART.Length > 0 And CANT > 0 Then

                    ULT_COSTO = 0 : COSTO_PROM = 0
                    CVE_ESQIMPU = 1
                    Try
                        SQL = "SELECT * FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        Reader = cmd.ExecuteReader
                        If Reader.HasRows Then
                            If Reader.Read Then
                                ULT_COSTO = Reader("ULT_COSTO")
                                COSTO_PROM = Reader("COSTO_PROM")
                                CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                                TIPO_ELE = Reader("TIPO_ELE")
                            End If
                        End If
                        Reader.Close()

                    Catch ex As Exception
                        MsgBox("159. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("159. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    UNI_MED = ""
                    COSTO = ULT_COSTO
                    Try
                        cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                        Reader = cmd.ExecuteReader
                        If Reader.HasRows Then
                            If Reader.Read Then
                                IMPU1 = CSng(Reader("IMPUESTO1"))
                                IMPU2 = CSng(Reader("IMPUESTO2"))
                                IMPU3 = CSng(Reader("IMPUESTO3"))
                                IMPU4 = CSng(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP2APLA = CInt(Reader("IMP2APLICA"))
                                IMP3APLA = CInt(Reader("IMP3APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            End If
                        End If
                        Reader.Close()

                        cIeps = COSTO * IMPU1 / 100
                        If IMP2APLA = 2 Or IMP2APLA = 1 Then
                            cImpu2 = CSng((COSTO + cIeps) * IMPU2 / 100)
                        Else
                            cImpu2 = CSng(COSTO * IMPU2 / 100)
                        End If

                        If IMP3APLA = 2 Or IMP3APLA = 1 Then
                            cImpu3 = CSng((COSTO + cIeps + cImpu2) * IMPU3 / 100)
                        Else
                            cImpu3 = CSng(COSTO * IMPU3 / 100)
                        End If

                        If IMP4APLA = 1 Or IMP4APLA = 2 Then
                            cImpu = (COSTO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                        Else
                            cImpu = COSTO * IMPU4 / 100
                        End If

                        ImporteIeps += (COSTO * CANT * IMPU1 / 100)
                        ImporteImpu2 += (COSTO * CANT * IMPU2 / 100)
                        ImporteImpu3 += (COSTO * CANT * IMPU3 / 100)
                        ImporteIVA += (COSTO * CANT * IMPU4 / 100)

                        DESCU += DES_TOT_PORC
                        TOTIMP1 += (CANT * cIeps)
                        TOTIMP2 += (CANT * cImpu2)
                        TOTIMP3 += (CANT * cImpu3)
                        TOTIMP4 += (CANT * cImpu)
                        TOT_PARTIDA = COSTO * CANT
                        COSTO_PROMEDIO = 0
                        CLAVE_CLPV = CVE_CLPV
                        UNI_VENTA = UNI_MED

                        PREC = 0 : Vend = "" : CANT_COST = 0 : CVE_OBS = 0 : REG_SERIE = 0 : E_LTPD = 0 : TIPO_PROD = "P" : FACTOR_CON = 1 : CTLPOL = 0
                        COSTEADO = "S" : COSTO_PROM_INI = COSTO : COSTO_PROM_FIN = COSTO : DESDE_INVE = "N" : MOV_ENLAZADO = 0

                        VENTA_RANGO_FECH = Fg(i, 3)
                        CVE_DOC_COM = Fg(i, 4)

                        If Not IsNothing(Fg(i, 5)) Then
                            FECHA_ULT_OC = Fg(i, 5)
                        Else
                            FECHA_ULT_OC = "01/01/1900"
                        End If
                        If Not IsNothing(Fg(i, 6)) Then
                            FECHA_ULT_COMPRA = Fg(i, 6)
                        Else
                            FECHA_ULT_COMPRA = "01/01/1900"
                        End If

                        DIF = Fg(i, 7)
                        EXIST = Fg(i, 8)
                        CANT_ULT_COMP = Fg(i, 9)
                        CANT_ENT_DIF_OC_Y_COMP = Fg(i, 10)
                        CANT_SUG_OC = Fg(i, 11)

                        If FECHA_ULT_OC.Trim.Length = 0 Then
                            FECHA_ULT_OC = "01/01/1900"
                        End If
                        If FECHA_ULT_COMPRA.Trim.Length = 0 Then
                            FECHA_ULT_COMPRA = "01/01/1900"
                        End If

                    Catch ex As Exception
                        MsgBox("161. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("161. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    '***************************************************************************************
                    '***************************************************************************************
                    ' ***********************           EMPIEZA PARTIDAS     *******************************
                    '***************************************************************************************
                    '***************************************************************************************
                    NUM_ALM = 1
                    Try
                        OBSER_PAR = Fg(i, 18)
                        OBSER_PAR = RemoveCharacter(OBSER_PAR)
                    Catch ex As Exception
                    End Try

                    Try
                        CVE_OBS = 0
                        If Not IsNothing(OBSER_PAR) Then
                            If OBSER_PAR.ToString.Trim.Length > 0 Then
                                Try
                                    If IsNumeric(Fg(i, 19)) Then
                                        CVE_OBS = Fg(i, 19)
                                    Else
                                        CVE_OBS = 0
                                    End If
                                Catch ex As Exception
                                    CVE_OBS = 0
                                    Bitacora("163. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                End Try
                                CVE_OBS = INSERT_UPDATE_OBS(CVE_OBS, OBSER_PAR)
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("164. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    NUM_ALM = 1

                    SQL = "INSERT INTO PAR_COMPO" & Empresa & " (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXR, PREC, COST, IMPU1,IMPU2, IMPU3, IMPU4, IMP1APLA, 
                        IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESCU, ACT_INV, TIP_CAM, UNI_VENTA, TIPO_ELEM, 
                        TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, FACTCONV, COST_DEV, NUM_ALM, MINDIRECTO, NUM_MOV, TOT_PARTIDA,
                        MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC, MTO_CUOTA, CVE_ESQ, DESCR_ART) 
                        VALUES (
                        @CVE_DOC, @NUM_PAR, @CVE_ART, @CANT, @PXR, @PREC, @COST, @IMPU1, @IMPU2, @IMPU3, @IMPU4, @IMP1APLA, @IMP2APLA, @IMP3APLA, 
                        @IMP4APLA, @TOTIMP1, @TOTIMP2, @TOTIMP3, @TOTIMP4, @DESCU, @ACT_INV, @TIP_CAM, @UNI_VENTA, @TIPO_ELEM, @TIPO_PROD, 
                        @CVE_OBS, @REG_SERIE, @E_LTPD, @FACTCONV, @COST_DEV, @NUM_ALM, @MINDIRECTO, 0, @TOT_PARTIDA, @MAN_IEPS, @APL_MAN_IMP, 
                        @CUOTA_IEPS, @APL_MAN_IEPS, @MTO_PORC, @MTO_CUOTA, @CVE_ESQ, @DESCR_ART)"
                    Try
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                        cmd.Parameters.Add("@NUM_PAR", SqlDbType.Int).Value = NUM_PAR
                        cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(CVE_ART)
                        cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CANT
                        cmd.Parameters.Add("@PXR", SqlDbType.Float).Value = CANT
                        cmd.Parameters.Add("@PREC", SqlDbType.Float).Value = Math.Round(PREC, 6)
                        cmd.Parameters.Add("@COST", SqlDbType.Float).Value = Math.Round(COSTO, 6)
                        cmd.Parameters.Add("@IMPU1", SqlDbType.Float).Value = IMPU1
                        cmd.Parameters.Add("@IMPU2", SqlDbType.Float).Value = IMPU2
                        cmd.Parameters.Add("@IMPU3", SqlDbType.Float).Value = IMPU3
                        cmd.Parameters.Add("@IMPU4", SqlDbType.Float).Value = IMPU4
                        cmd.Parameters.Add("@IMP1APLA", SqlDbType.SmallInt).Value = IMP1APLA
                        cmd.Parameters.Add("@IMP2APLA", SqlDbType.SmallInt).Value = IMP2APLA
                        cmd.Parameters.Add("@IMP3APLA", SqlDbType.SmallInt).Value = IMP3APLA
                        cmd.Parameters.Add("@IMP4APLA", SqlDbType.SmallInt).Value = IMP4APLA
                        cmd.Parameters.Add("@TOTIMP1", SqlDbType.Float).Value = Math.Round(TOTIMP1, 6)
                        cmd.Parameters.Add("@TOTIMP2", SqlDbType.Float).Value = Math.Round(TOTIMP2, 6)
                        cmd.Parameters.Add("@TOTIMP3", SqlDbType.Float).Value = Math.Round(TOTIMP3, 6)
                        cmd.Parameters.Add("@TOTIMP4", SqlDbType.Float).Value = Math.Round(TOTIMP4, 6)
                        cmd.Parameters.Add("@DESCU", SqlDbType.Float).Value = DESCU
                        cmd.Parameters.Add("@ACT_INV", SqlDbType.VarChar).Value = ACT_INV
                        cmd.Parameters.Add("@TIP_CAM", SqlDbType.Float).Value = TIP_CAM
                        cmd.Parameters.Add("@UNI_VENTA", SqlDbType.VarChar).Value = UNI_MED
                        cmd.Parameters.Add("@TIPO_ELEM", SqlDbType.VarChar).Value = TIPO_ELEM
                        cmd.Parameters.Add("@TIPO_PROD", SqlDbType.VarChar).Value = TIPO_ELE
                        cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                        cmd.Parameters.Add("@REG_SERIE", SqlDbType.Int).Value = REG_SERIE
                        cmd.Parameters.Add("@E_LTPD", SqlDbType.Int).Value = E_LTPD
                        cmd.Parameters.Add("@FACTCONV", SqlDbType.Float).Value = FACTCONV
                        cmd.Parameters.Add("@COST_DEV", SqlDbType.Float).Value = 0
                        cmd.Parameters.Add("@NUM_ALM", SqlDbType.Int).Value = NUM_ALM
                        cmd.Parameters.Add("@MINDIRECTO", SqlDbType.Float).Value = MINDIRECTO
                        cmd.Parameters.Add("@NUM_MOV", SqlDbType.Int).Value = NUM_MOV
                        cmd.Parameters.Add("@TOT_PARTIDA", SqlDbType.Float).Value = Math.Round(TOT_PARTIDA, 6)
                        cmd.Parameters.Add("@MAN_IEPS", SqlDbType.VarChar).Value = MAN_IEPS
                        cmd.Parameters.Add("@APL_MAN_IMP", SqlDbType.Int).Value = APL_MAN_IMP
                        cmd.Parameters.Add("@CUOTA_IEPS", SqlDbType.Float).Value = CUOTA_IEPS
                        cmd.Parameters.Add("@APL_MAN_IEPS", SqlDbType.VarChar).Value = APL_MAN_IEPS
                        cmd.Parameters.Add("@MTO_PORC", SqlDbType.Float).Value = MTO_PORC
                        cmd.Parameters.Add("@MTO_CUOTA", SqlDbType.Float).Value = MTO_CUOTA
                        cmd.Parameters.Add("@CVE_ESQ", SqlDbType.Int).Value = CVE_ESQIMPU
                        cmd.Parameters.Add("@DESCR_ART", SqlDbType.VarChar).Value = ""
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("170. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    ' ***********************      SQL SERVER   *******************************
                    NUM_PAR += 1
                End If

            Next
            'TERMINA FOR DE PARTIDAS
            'TERMINA FOR DE PARTIDAS
            'TERMINA FOR DE PARTIDAS

            '████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
            '████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████

            Try
                If SERIE_PRE_OC = "" Or SERIE_PRE_OC = "STAND." Then
                    SQL = "UPDATE FOLIOSC" & Empresa & " SET ULT_DOC = " & FOLIO & " WHERE TIP_DOC = 'p' AND SERIE = 'STAND.'"
                Else
                    SQL = "UPDATE FOLIOSC" & Empresa & " SET ULT_DOC = " & FOLIO & " WHERE TIP_DOC = 'p' AND SERIE = '" & SERIE_PRE_OC & "'"
                End If
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If

                SQL = "UPDATE COMPO_PRE SET ENLAZADO = 'T', TIP_DOC_SIG = 'o', DOC_SIG = '" & CVE_DOC & "' WHERE CVE_DOC = '" & LtCVE_DOC.Text & "'"
                returnValue = EXECUTE_QUERY_NET(SQL)

                BarGrabar.Enabled = False
                BarDesplegar.Enabled = False
                BarGenOrdenCompra.Enabled = False
                C1List1.Enabled = False
                BarSeries.Enabled = False
            Catch ex As Exception
                MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("320. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            End Try


            Me.Cursor = Cursors.Default
            Continua = False

            FgModif = False

            ImprimirOrden(CVE_DOC)


        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Sub CALCULAR_IMPORTES()

        Dim cmd As New SqlCommand
        Dim Reader As SqlDataReader
        Dim IMPORTE As Decimal, DESCUENTO1 As Decimal, ImporteConDes As Decimal, DESC1 As Decimal, CVE_ESQIMPU As Integer = 1
        Dim CAN_TOT As Decimal, DES_TOT As Decimal, COSTO As Decimal, COSTO_NETO As Decimal
        Dim cIeps As Decimal, cImpu As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer, IMP4APLA As Integer
        Dim TOTIMP1 As Decimal, TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal
        Dim ImporteIeps As Decimal, ImporteImpu2 As Decimal, ImporteImpu3 As Decimal, ImporteIVA As Decimal, CANT As Decimal
        Dim CVE_ART As String, ULT_COSTO As Decimal

        cmd.Connection = cnSAE
        Try
            DES_TOT = 0 : TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0
            For i As Integer = 1 To Fg.Rows.Count - 1
                Try
                    CVE_ART = Fg(i, 1)
                    CVE_ART = CVE_ART.Replace("'", "")
                    CVE_ART = RemoveCharacter(CVE_ART)
                Catch ex As Exception
                    CVE_ART = ""
                End Try
                Try
                    Try
                        If IsNumeric(Fg(i, 12)) Then
                            CANT = Fg(i, 12)
                        Else
                            CANT = 0
                        End If
                    Catch ex As Exception
                        CANT = 0
                    End Try

                    If CVE_ART.Length > 0 And CANT > 0 Then
                        Try
                            SQL = "SELECT ULT_COSTO, COSTO_PROM, CVE_ESQIMPU FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                            cmd.CommandText = SQL
                            Reader = cmd.ExecuteReader
                            If Reader.HasRows Then
                                If Reader.Read Then
                                    CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                                    ULT_COSTO = Reader("ULT_COSTO")
                                Else
                                    Bitacora("1. PROBLEMA DETECTADO EN CALCULAR IMPORTES NO SE ENCONTRO EL ESQUEMA IMPUESTO frmComprasTrans ")
                                End If
                            End If
                            Reader.Close()
                        Catch ex As Exception
                            MsgBox("720. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("720. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            SQL = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            cmd.CommandText = SQL
                            Reader = cmd.ExecuteReader
                            If Reader.Read Then
                                IMPU1 = CSng(Reader("IMPUESTO1"))
                                IMPU2 = CSng(Reader("IMPUESTO2"))
                                IMPU3 = CSng(Reader("IMPUESTO3"))
                                IMPU4 = CSng(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP2APLA = CInt(Reader("IMP2APLICA"))
                                IMP3APLA = CInt(Reader("IMP3APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            Else
                                Bitacora("PROBLEMA DETECTADO EN CALCULAR IMPORTES NO ENCONTRO EL IMPUESTO frmComprasTrans ")
                            End If
                            Reader.Close()
                        Catch ex As Exception
                            Bitacora("730. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            MsgBox("730. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        Try
                            DESC1 = 0
                            COSTO = ULT_COSTO

                            COSTO = Math.Round(CDec(COSTO), 6)
                            COSTO_NETO = COSTO - (COSTO * DESC1 / 100)

                            DESCUENTO1 = (CANT * COSTO * DESC1 / 100)
                            ImporteConDes = (CANT * COSTO) - DESCUENTO1
                            ImporteConDes = Math.Round(CDec(ImporteConDes), 6)

                            DES_TOT += DESCUENTO1

                            cIeps = COSTO_NETO * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cImpu2 = CSng((COSTO_NETO + cIeps) * IMPU2 / 100)
                            Else
                                cImpu2 = CSng(COSTO_NETO * IMPU2 / 100)
                            End If

                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cImpu3 = CSng((COSTO_NETO + cIeps + cImpu2) * IMPU3 / 100)
                            Else
                                cImpu3 = CSng(COSTO_NETO * IMPU3 / 100)
                            End If

                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cImpu = (COSTO_NETO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cImpu = COSTO_NETO * IMPU4 / 100
                            End If

                            ImporteIeps += (COSTO_NETO * CANT * IMPU1 / 100)
                            ImporteImpu2 += (COSTO_NETO * CANT * IMPU2 / 100)
                            ImporteImpu3 += (COSTO_NETO * CANT * IMPU3 / 100)
                            ImporteIVA += (COSTO_NETO * CANT * IMPU4 / 100)


                            TOTIMP1 += CANT * cIeps
                            TOTIMP2 += CANT * cImpu2
                            TOTIMP3 += CANT * cImpu3
                            TOTIMP4 += (CANT * cImpu)

                            IMPORTE += (CANT * (COSTO_NETO + cIeps + cImpu2 + cImpu3 + cImpu))
                            CAN_TOT += CANT * COSTO
                        Catch ex As Exception
                            MsgBox("740. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("740. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    MsgBox("750. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("750. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            Next
            If TOTIMP2 < 0 Then
                frmComprasTotales.Lt1.Text = "RET."
            End If
            If TOTIMP3 < 0 Then
                frmComprasTotales.Lt2.Text = "RET."
            End If

            Var7 = "TOTALES"

            frmComprasTotales.LtSubtotal.Text = Format(CAN_TOT, "###,##0.00")
            frmComprasTotales.LtDesc.Text = Format(DES_TOT, "###,##0.00")
            frmComprasTotales.LtIeps.Text = Format(TOTIMP1, "###,##0.00")
            frmComprasTotales.LtImpu2.Text = Format(TOTIMP2, "###,##0.00")
            frmComprasTotales.LtImpu3.Text = Format(TOTIMP3, "###,##0.00")
            frmComprasTotales.LtIVA.Text = Format(TOTIMP4, "###,##0.00")
            frmComprasTotales.LtTotal.Text = Format(CAN_TOT - DES_TOT + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4, "###,##0.00")

            frmComprasTotales.ShowDialog()

        Catch ex As Exception
            Bitacora("760. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub ImprimirOrden(fCVE_DOC As String)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra" & Empresa & ".mrt"
            If Not File.Exists(ARCHIVO_MRT) Then
                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra.mrt"
                If Not File.Exists(ARCHIVO_MRT) Then
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    Return
                End If
            End If

            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = fCVE_DOC
            StiReport1.Render()

            StiReport1.Show()

        Catch ex As Exception
            Bitacora("710. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Sub BUSCAR_COMPRA(fCVE_DOC As String)
        If Not Valida_Conexion() Then
            Return
        End If
        Dim COSTO As Decimal, NUM_ALM As Integer, IEPS As Decimal, IMPU As Decimal, cIEPS As Decimal, cIMPU As Decimal
        Dim DESCP As Decimal, DESCP2 As Decimal, PrecioVenta As Decimal, Sigue As Boolean = True, OBSER As String, z As Integer = 0
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        ENTRA = False

        Lt1.Text = ""
        cmd.Connection = cnSAE
        Fg.Rows.Count = 1
        Try
            SQL = "SELECT P.CVE_DOC, FECHA_DOC, ISNULL(F.STATUS,'') AS ST, P.CVE_ART, ISNULL(CANT,0) AS CAN, PXR, I.DESCR, P.DESCU, 
                PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, COST, UNI_VENTA, I.EXIST, ISNULL(NUM_PAR,0) AS NUMPAR, 
                P.NUM_ALM, ISNULL(F.CVE_CLPV,'') AS PROV, C.NOMBRE, C.RFC, SU_REFER, ISNULL(F.CVE_OBS,0) AS CVE_OBS_DOC, 
                ISNULL(O.STR_OBS,'') AS OBS_DOC, ISNULL(P.CVE_OBS,0) AS CVE_OBS_PAR, ISNULL(OP.STR_OBS,'') AS OBS_PAR, 
                F.DOC_ANT, F.DOC_SIG, C.DIASCRED, F.FECHA_REC, F.FECHA_PAG, ISNULL(F.ENLAZADO,'') AS ENLAZA, P.CVE_DOC_COM, 
                P.FECHA_ULT_OC, P.FECHA_ULT_COMPRA, P.VENTA_RANGO_FECH, P.DIF, P.CANT_ULT_COMP, P.CANT_ENT_DIF_OC_Y_COMP, 
                P.CANT_SUG_OC 
                FROM COMPO_PRE_PAR P
                LEFT JOIN COMPO_PRE F ON F.CVE_DOC = P.CVE_DOC 
                LEFT JOIN OBS_DOCC" & Empresa & " O ON O.CVE_OBS = F.CVE_OBS 
                LEFT JOIN OBS_DOCC" & Empresa & " OP ON OP.CVE_OBS = P.CVE_OBS 
                LEFT JOIN PROV" & Empresa & " C ON C.CLAVE = F.CVE_CLPV 
                LEFT JOIN INVE" & Empresa & " I On replace(replace(I.CVE_ART,CHAR(13),''),CHAR(10),'') =replace(replace(P.CVE_ART ,CHAR(13),''),CHAR(10),'')
                LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = I.CVE_ESQIMPU 
                WHERE P.CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                If Sigue Then
                    TLINEA.Text = dr.ReadNullAsEmptyString("PROV")
                    LtDescrLinea.Text = dr.ReadNullAsEmptyString("NOMBRE")
                    LtDescrLinea.Tag = dr.ReadNullAsEmptyLong("CVE_OBS_DOC")
                    OBSER = dr.ReadNullAsEmptyString("OBS_DOC")
                    F1.Value = dr("FECHA_REC")
                    F2.Value = dr("FECHA_PAG")
                    LtFecha.Text = dr("FECHA_DOC")
                    Sigue = False

                    If dr("ENLAZA") = "T" Or dr("ST") = "C" Then
                        BarGrabar.Enabled = False
                        BarDesplegar.Enabled = False
                        BarGenOrdenCompra.Enabled = False
                        C1List1.Enabled = False
                        BarSeries.Enabled = False

                        FgModif = False
                        TLINEA.Enabled = False
                        BtnLinea.Enabled = False
                        F1.Enabled = False
                        F2.Enabled = False
                        If dr("ST") = "C" Then
                            '          New Font("Font Name", 10, FontStyle.Regular)
                            Lt1.Font = New Font("Comic Sans MS", 18, FontStyle.Bold Or FontStyle.Underline)
                            Lt1.Text = "CANCELADA"
                        End If
                    End If
                End If
                NUM_ALM = dr.ReadNullAsEmptyInteger("NUM_ALM")
                COSTO = Math.Round(dr("COST"), 6)
                DESCP = COSTO * dr("DESCU") / 100
                IEPS = dr("IMPU1")
                cIEPS = (COSTO - DESCP - DESCP2) * IEPS / 100
                IMPU = dr("IMPU4")
                cIMPU = (COSTO - DESCP - DESCP2 + cIEPS) * IMPU / 100
                PrecioVenta = COSTO - DESCP - DESCP2
                Fg.AddItem("" & vbTab & dr("CVE_ART") & vbTab & dr("DESCR") & vbTab & dr("VENTA_RANGO_FECH") & vbTab &
                           dr("CVE_DOC_COM") & vbTab & dr("FECHA_ULT_OC") & vbTab & dr("FECHA_ULT_COMPRA") & vbTab &
                           dr("DIF") & vbTab & dr("EXIST") & vbTab & dr("CANT_ULT_COMP") & vbTab &
                           dr("CANT_ENT_DIF_OC_Y_COMP") & vbTab & IIf(dr("CANT_SUG_OC") < 0, 0, dr("CANT_SUG_OC")) & vbTab &
                           dr("CAN") & vbTab & dr("NUMPAR"))
                '               13
                z += 1
            Loop
            Fg.Focus()
            Fg.Row = 1
            Fg.Col = 1

            If Lt1.Text <> "CANCELADA" Then
                Lt1.Text = "Partidas pre-orden de compra " & z
            End If

            Fg.AutoSizeCols()
            Fg.Cols(3).Width = 65
            Fg.Cols(5).Width = 90 'FECHA ULT ORDEN DE COMPRA
            Fg.Cols(6).Width = 70 'FECHA ULTIMA COMPRA
            Fg.Cols(7).Width = 60 'DIFERENCIA
            Fg.Cols(8).Width = 60 'EXISTENCIA
            Fg.Cols(9).Width = 80 'CANIDAD ULTIMA COMPRA
            Fg.Cols(10).Width = 100
            Fg.Cols(11).Width = 80 'SUGERIDO DE ORDEN DE COMPRA
            Fg.Cols(12).Width = 100 'CANIDAD A PEDIR
            Fg.Cols(13).Width = 0 'NUM_PAR
            ENTRA = True
        Catch ex As Exception
            Bitacora("670. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("670. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim Continua As Boolean

        Dim FOLIO_ASIGNADO As Boolean, CVE_DOC As String, DESCR As String, CANT As Decimal, CVE_ART As String, COSTO As Decimal
        Dim IMPORTE As Decimal, IMPU1 As Decimal, IMPU4 As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer
        Dim IMP4APLA As Integer, CVE_ESQIMPU As Integer, UNI_MED As String, IMP_TOT1 As Decimal, IMP_TOT4 As Decimal, cIeps As Decimal, cImpu As Decimal
        Dim nClavesNoEncontradas As Integer, CVE_CLPV As String = "", PREC As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, ACT_INV As String, TIP_CAM As Integer
        Dim TIPO_ELEM As String, TIPO_PROD As String, CVE_OBS As Integer, REG_SERIE As Integer, E_LTPD As Integer, FACTCONV As Decimal
        Dim MINDIRECTO As Integer, NUM_MOV As Long, MAN_IEPS As String, APL_MAN_IMP As Decimal, CUOTA_IEPS As Decimal, APL_MAN_IEPS As String
        Dim MTO_PORC As Decimal, MTO_CUOTA As Decimal, NUM_PAR As Integer, NUM_PAR2 As Integer, NUM_ALM As Integer, TOT_PARTIDA As Decimal, DESCU As Decimal, TOTIMP1 As Decimal
        Dim TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, ImporteIeps As Decimal, ImporteImpu2 As Decimal
        Dim ImporteImpu3 As Decimal, ImporteIVA As Decimal, STATUS As String, TIP_DOC As String, IMP_TOT2 As Decimal, IMP_TOT3 As Decimal, TOT_IND As Decimal
        Dim OBS_COND As String, ACT_CXP As String, ACT_COI As String, NUM_MONED As Integer, TIPCAMB As Integer, ENLAZADO As String, TIP_DOC_E As String
        Dim CTLPOL As Integer, ESCFD As String, CONTADO As String, BLOQ As String, DES_FIN_PORC As Decimal, DES_TOT_PORC As Decimal, TIP_DOC_ANT As String
        Dim DOC_ANT As String, TIP_DOC_SIG As String, DOC_SIG As String, FORMAENVIO As String, SU_REFER As String, CAN_TOT As Decimal
        Dim DES_TOT As Decimal, DES_FIN As Decimal, FOLIO As Long, ULT_DOC As Long
        'MOVSINV
        Dim COSTO_PROMEDIO As Decimal, CVE_CPTO As Integer, CLAVE_CLPV As String, Vend As String, CANT_COST As Decimal, UNI_VENTA As String
        Dim FACTOR_CON As Decimal, SIGNO As Integer, COSTEADO As String, COSTO_PROM_INI As Decimal, COSTO_PROM_FIN As Decimal, COSTO_PROM As Decimal
        Dim DESDE_INVE As String, MOV_ENLAZADO As Integer, NUM_CPTO As Integer, NUM_CARGO As Int16
        Dim AFEC_COI As String, TCAMBIO As Int16, CVE_FOLIO As String, TIPO_MOV As String, CVE_AUT As Integer, ENTREGADA As String, REF_SIST As String
        Dim FECHA_REC As String, ULT_COSTO As Decimal, TIPO_ELE As String, Usuario2 As Integer, DESC1 As Decimal, Sigue As Boolean, Exist_esquema_imp As Boolean
        Dim VENTA_RANGO_FECH As Decimal, CVE_DOC_COM As String = "", FECHA_ULT_OC As String = "", FECHA_ULT_COMPRA As String = "", DIF As Decimal = 0
        Dim EXIST As Decimal = 0, CANT_ULT_COMP As Decimal = 0, CANT_ENT_DIF_OC_Y_COMP As Decimal = 0, CANT_SUG_OC As Decimal = 0

        Dim cmdProv As New SqlCommand
        Dim cmd As New SqlCommand
        Dim Reader As SqlDataReader

        If Not Valida_Conexion() Then
            Return
        End If

        CVE_DOC = ""
        Try
            CVE_CLPV = LtProv.Text
            ESCFD = BUSCA_CAT("Prov", CVE_CLPV)
            If ESCFD = "" Then
                MsgBox("Proveedor inexistente verifique por favor")
                Return
            End If
            ESCFD = ""

            Fg.FinishEditing()
        Catch ex As Exception
        End Try

        Usuario2 = 0
        For i As Integer = 1 To Fg.Rows.Count - 1
            Try
                If Not IsNothing(Fg(i, 1)) Then
                    CVE_ART = Fg(i, 1)
                    CVE_ART = CVE_ART.Replace("'", "")
                    CVE_ART = RemoveCharacter(CVE_ART)
                Else
                    CVE_ART = ""
                End If
                If IsNothing(Fg(i, 12)) Then
                    CANT = 0
                Else
                    If IsNumeric(Fg(i, 12)) Then
                        CANT = Fg(i, 12)
                    Else
                        CANT = 0
                    End If
                End If
                If CVE_ART.Length > 0 And CANT > 0 Then
                    Usuario2 += 1
                End If
            Catch ex As Exception
            End Try
        Next

        If Usuario2 = 0 Then
            MsgBox("No se encontraron Artículos con la cantidad capturada, por favor capture la cantidad a solicitar")
            Return
        Else
            Usuario2 = 0

        End If

        If CompEdit Then
            CVE_DOC = LtCVE_DOC.Text
        Else
            Try
                Sigue = True
                FOLIO_ASIGNADO = False

                Do While Sigue

                    If SERIE_PRE_OC.Trim.Length = 0 Or SERIE_PRE_OC = "STAND." Then
                        CVE_DOC = Space(10) & Format(FOLIO_PRE_OC, "0000000000")
                    Else
                        CVE_DOC = SERIE_PRE_OC & Format(FOLIO_PRE_OC, "0000000000")
                    End If

                    If EXISTE_PRE_OC(CVE_DOC) Then
                        FOLIO_PRE_OC += 1
                        FOLIO_ASIGNADO = True
                    Else
                        Sigue = False
                    End If
                Loop
                ULT_DOC = FOLIO_PRE_OC
                FOLIO = ULT_DOC
            Catch ex As Exception
                Bitacora("61. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        'PROV
        ULT_COSTO = 0 : TIPO_ELE = "P" : CVE_ESQIMPU = 1 : SU_REFER = "" : OBS_COND = ""
        Dim dt As DateTime = F1.Value
        FECHA_REC = dt.Year & Format(dt.Month, "00") & Format(dt.Day, "00")

        If MsgBox("Realmente desea grabar la pre-orden de compra?", vbYesNo) = vbNo Then
            Exit Sub
        End If

        cmd.Connection = cnSAE
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim cmdExist As New SqlCommand
            Sigue = True : Exist_esquema_imp = False
            IMPORTE = 0 : nClavesNoEncontradas = 0 : TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0 : CAN_TOT = 0 : DESCR = ""

            For i As Integer = 1 To Fg.Rows.Count - 1
                If Not Valida_Conexion() Then
                End If

                Try
                    If Not IsNothing(Fg(i, 1)) Then
                        CVE_ART = Fg(i, 1)
                        CVE_ART = CVE_ART.Replace("'", "")
                        CVE_ART = RemoveCharacter(CVE_ART)
                    Else
                        CVE_ART = ""
                    End If

                    If IsNothing(Fg(i, 12)) Then
                        CANT = 0
                    Else
                        If IsNumeric(Fg(i, 12)) Then
                            CANT = Fg(i, 12)
                        Else
                            CANT = 0
                        End If
                    End If

                    If CVE_ART.Length > 0 And CANT > 0 Then
                        DESC1 = 0
                        UNI_MED = ""
                        Try
                            SQL = "SELECT * FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"

                            cmd.CommandText = SQL
                            Reader = cmd.ExecuteReader
                            If Reader.HasRows Then
                                If Reader.Read Then
                                    ULT_COSTO = Reader("ULT_COSTO")
                                    COSTO_PROM = Reader("COSTO_PROM")
                                    CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                                    TIPO_ELE = Reader("TIPO_ELE")
                                Else
                                    Bitacora("1. PROBLEMA DETECTADO EN GUARDAR NO SE ENCONTRO EL ARTICULO " & CVE_ART & " frmComprasTrans " & SQL)
                                End If
                            End If
                            Reader.Close()

                            cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            Reader = cmd.ExecuteReader
                            If Reader.Read Then
                                IMPU1 = CSng(Reader("IMPUESTO1"))
                                IMPU2 = CSng(Reader("IMPUESTO2"))
                                IMPU3 = CSng(Reader("IMPUESTO3"))
                                IMPU4 = CSng(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP2APLA = CInt(Reader("IMP2APLICA"))
                                IMP3APLA = CInt(Reader("IMP3APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            Else
                                Bitacora("1. PROBLEMA DETECTADO EN GUARDAR NO SE ENCONTRO EL ESQUEMA IMPUESTO frmComprasTrans " & SQL)
                            End If
                            Reader.Close()

                        Catch ex As Exception
                            Bitacora("141. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            MsgBox("141. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            COSTO = ULT_COSTO

                            DES_TOT = 0
                            cIeps = COSTO * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cImpu2 = CSng((COSTO + cIeps) * IMPU2 / 100)
                            Else
                                cImpu2 = CSng(COSTO * IMPU2 / 100)
                            End If

                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cImpu3 = CSng((COSTO + cIeps + cImpu2) * IMPU3 / 100)
                            Else
                                cImpu3 = CSng(COSTO * IMPU3 / 100)
                            End If

                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cImpu = (COSTO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cImpu = COSTO * IMPU4 / 100
                            End If

                            ImporteIeps += (COSTO * CANT * IMPU1 / 100)
                            ImporteImpu2 += (COSTO * CANT * IMPU2 / 100)
                            ImporteImpu3 += (COSTO * CANT * IMPU3 / 100)
                            ImporteIVA += COSTO * CANT * IMPU4 / 100

                            TOTIMP1 += (CANT * cIeps)
                            TOTIMP2 += (CANT * cImpu2)
                            TOTIMP3 += (CANT * cImpu3)
                            TOTIMP4 += (CANT * cImpu)

                            IMPORTE += (CANT * (COSTO + cIeps + cImpu2 + cImpu3 + cImpu))

                            CAN_TOT += (CANT * COSTO)

                            DESCU = 0
                        Catch ex As Exception
                            MsgBox("142. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("142. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                Catch ex As Exception
                    MsgBox("143. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("143. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            Next
            IMP_TOT1 = TOTIMP1
            IMP_TOT2 = TOTIMP2
            IMP_TOT3 = TOTIMP3
            IMP_TOT4 = TOTIMP4

            DES_TOT_PORC = 0
            DES_TOT = 0

            CVE_OBS = 0 : DES_FIN = 0
            STATUS = "E" : TIP_DOC = "p" : TOT_IND = 0 : ACT_CXP = "S" : ACT_COI = "N" : NUM_MONED = 1 : TIPCAMB = 1
            ENLAZADO = "O" : TIP_DOC_E = "O" : CTLPOL = 0 : ESCFD = "N" : CONTADO = "N" : BLOQ = "N" : DES_FIN_PORC = 0
            TIP_DOC_ANT = "" : DOC_ANT = "" : TIP_DOC_SIG = "" : DOC_SIG = "" : FORMAENVIO = ""
            PREC = 0 : IMPU2 = 0 : IMPU3 = 0 : ACT_INV = "S" : TIP_CAM = 1 : TIPO_ELEM = "N" : TIPO_PROD = "P"
            CVE_OBS = 0 : REG_SERIE = 0 : E_LTPD = 0 : FACTCONV = 1 : MINDIRECTO = 0 : NUM_MOV = 0 : MAN_IEPS = "N" : APL_MAN_IMP = 1
            CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
            NUM_CARGO = 1 : AFEC_COI = "A" : NUM_MONED = 1 : TCAMBIO = 1 : CTLPOL = 0 : CVE_FOLIO = ""
            TIPO_MOV = "A" : CVE_AUT = 0 : Usuario2 = "0" : ENTREGADA = "S" : REF_SIST = ""

            NUM_CPTO = 1 'CXP
            CVE_CPTO = 1 'MOVS INV
            SIGNO = 1
            NUM_ALM = 1

            OBSER = RemoveCharacter(OBSER)

            If OBSER.Trim.Length > 0 Then
                If TIPO_OTI = 0 Then
                    INSERT_UPDATE_OBS_COMP_CLIB(CVE_DOC, "P", OBSER)
                Else
                    Try
                        If IsNumeric(LtDescrLinea.Tag) Then
                            CVE_OBS = LtDescrLinea.Tag
                        Else
                            CVE_OBS = 0
                        End If
                    Catch ex As Exception
                        Bitacora("144. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    CVE_OBS = INSERT_UPDATE_OBS(CVE_OBS, OBSER)
                End If
            End If

            SQL = "UPDATE COMPO_PRE SET CVE_CLPV = @CVE_CLPV, STATUS = @STATUS, SU_REFER = @SU_REFER, 
                CAN_TOT = @CAN_TOT, IMP_TOT1 = @IMP_TOT1, IMP_TOT2 = @IMP_TOT2, IMP_TOT3 = @IMP_TOT3, IMP_TOT4 = @IMP_TOT4, DES_TOT = @DES_TOT, 
                DES_FIN = @DES_FIN, TOT_IND = @TOT_IND, OBS_COND = @OBS_COND, CVE_OBS = @CVE_OBS, NUM_ALMA = @NUM_ALMA, ACT_CXP = @ACT_CXP, 
                ACT_COI = @ACT_COI, ENLAZADO = @ENLAZADO, TIP_DOC_E = @TIP_DOC_E, NUM_MONED = @NUM_MONED, TIPCAMB = @TIPCAMB, NUM_PAGOS = @NUM_PAGOS, 
                SERIE = @SERIE, FOLIO = @FOLIO, CTLPOL = @CTLPOL, ESCFD = @ESCFD, CONTADO = @CONTADO, BLOQ = @BLOQ, DES_FIN_PORC = @DES_FIN_PORC, 
                DES_TOT_PORC = @DES_TOT_PORC, IMPORTE = @IMPORTE, TIP_DOC_ANT = @TIP_DOC_ANT, DOC_ANT = @DOC_ANT, TIP_DOC_SIG = @TIP_DOC_SIG, 
                DOC_SIG = @DOC_SIG, FORMAENVIO = @FORMAENVIO 
                WHERE CVE_DOC = @CVE_DOC 
                IF @@ROWCOUNT = 0 
                INSERT INTO COMPO_PRE (TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, SU_REFER, FECHA_DOC, FECHA_REC, 
                FECHA_PAG, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, TOT_IND, OBS_COND, CVE_OBS, NUM_ALMA, ACT_CXP, 
                ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, SERIE, FOLIO, CTLPOL, ESCFD, CONTADO, BLOQ, DES_FIN_PORC, 
                DES_TOT_PORC, IMPORTE, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, FORMAENVIO) VALUES (@TIP_DOC, @CVE_DOC, @CVE_CLPV, @STATUS, 
                @SU_REFER, @FECHA_DOC, @FECHA_REC, @FECHA_PAG, @CAN_TOT, @IMP_TOT1, @IMP_TOT2, @IMP_TOT3, @IMP_TOT4, @DES_TOT, @DES_FIN, @TOT_IND,  
                @OBS_COND, @CVE_OBS, @NUM_ALMA, @ACT_CXP, @ACT_COI, @ENLAZADO, @TIP_DOC_E, @NUM_MONED, @TIPCAMB, @NUM_PAGOS, GETDATE(), @SERIE, 
                @FOLIO, @CTLPOL, @ESCFD, @CONTADO, @BLOQ, @DES_FIN_PORC, @DES_TOT_PORC, @IMPORTE, @TIP_DOC_ANT, @DOC_ANT, @TIP_DOC_SIG, @DOC_SIG, 
                @FORMAENVIO)"
            Try
                For k As Integer = 1 To 5
                    Try
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@TIP_DOC", SqlDbType.VarChar).Value = TIP_DOC
                        cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                        cmd.Parameters.Add("@CVE_CLPV", SqlDbType.VarChar).Value = CVE_CLPV
                        cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "E"
                        cmd.Parameters.Add("@SU_REFER", SqlDbType.VarChar).Value = SU_REFER
                        cmd.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = Now
                        cmd.Parameters.Add("@FECHA_REC", SqlDbType.Date).Value = F1.Value
                        cmd.Parameters.Add("@FECHA_PAG", SqlDbType.Date).Value = F2.Value
                        cmd.Parameters.Add("@CAN_TOT", SqlDbType.Float).Value = Math.Round(CAN_TOT, 6)
                        cmd.Parameters.Add("@IMP_TOT1", SqlDbType.Float).Value = Math.Round(IMP_TOT1, 6)
                        cmd.Parameters.Add("@IMP_TOT2", SqlDbType.Float).Value = Math.Round(IMP_TOT2, 6)
                        cmd.Parameters.Add("@IMP_TOT3", SqlDbType.Float).Value = Math.Round(IMP_TOT3, 6)
                        cmd.Parameters.Add("@IMP_TOT4", SqlDbType.Float).Value = Math.Round(IMP_TOT4, 6)
                        cmd.Parameters.Add("@DES_TOT", SqlDbType.Float).Value = DES_TOT
                        cmd.Parameters.Add("@DES_FIN", SqlDbType.Float).Value = DES_FIN
                        cmd.Parameters.Add("@TOT_IND", SqlDbType.Float).Value = TOT_IND
                        cmd.Parameters.Add("@OBS_COND", SqlDbType.VarChar).Value = OBS_COND
                        cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                        cmd.Parameters.Add("@NUM_ALMA", SqlDbType.Int).Value = NUM_ALM
                        cmd.Parameters.Add("@ACT_CXP", SqlDbType.VarChar).Value = ACT_CXP
                        cmd.Parameters.Add("@ACT_COI", SqlDbType.VarChar).Value = ACT_COI
                        cmd.Parameters.Add("@ENLAZADO", SqlDbType.VarChar).Value = ENLAZADO
                        cmd.Parameters.Add("@TIP_DOC_E", SqlDbType.VarChar).Value = TIP_DOC_E
                        cmd.Parameters.Add("@NUM_MONED", SqlDbType.Int).Value = NUM_MONED
                        cmd.Parameters.Add("@TIPCAMB", SqlDbType.Float).Value = TIPCAMB
                        cmd.Parameters.Add("@NUM_PAGOS", SqlDbType.Int).Value = 1
                        cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE_PRE_OC
                        cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO
                        cmd.Parameters.Add("@CTLPOL", SqlDbType.Int).Value = CTLPOL
                        cmd.Parameters.Add("@ESCFD", SqlDbType.VarChar).Value = ESCFD
                        cmd.Parameters.Add("@CONTADO", SqlDbType.VarChar).Value = CONTADO
                        cmd.Parameters.Add("@BLOQ", SqlDbType.VarChar).Value = BLOQ
                        cmd.Parameters.Add("@DES_FIN_PORC", SqlDbType.Float).Value = DES_FIN_PORC
                        cmd.Parameters.Add("@DES_TOT_PORC", SqlDbType.Float).Value = DES_TOT_PORC
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                        cmd.Parameters.Add("@TIP_DOC_ANT", SqlDbType.VarChar).Value = TIP_DOC_ANT
                        cmd.Parameters.Add("@DOC_ANT", SqlDbType.VarChar).Value = DOC_ANT
                        cmd.Parameters.Add("@TIP_DOC_SIG", SqlDbType.VarChar).Value = TIP_DOC_SIG
                        cmd.Parameters.Add("@DOC_SIG", SqlDbType.VarChar).Value = DOC_SIG
                        cmd.Parameters.Add("@FORMAENVIO", SqlDbType.VarChar).Value = FORMAENVIO
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                        Exit For
                    Catch sqlEx As SqlException
                        If sqlEx.Number = 2627 Then
                        End If
                        Bitacora("53. " & sqlEx.Message & vbNewLine & sqlEx.StackTrace)
                    Catch ex As Exception
                        Bitacora("147. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("147. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If CompEdit Then
                        Try
                            Sigue = True
                            FOLIO_ASIGNADO = False
                            Do While Sigue

                                If SERIE_PRE_OC.Trim.Length = 0 Or SERIE_PRE_OC = "STAND." Then
                                    CVE_DOC = Space(10) & Format(FOLIO_PRE_OC, "0000000000")
                                Else
                                    CVE_DOC = SERIE_PRE_OC & Format(FOLIO_PRE_OC, "0000000000")
                                End If

                                If EXISTE_PRE_OC(CVE_DOC) Then
                                    FOLIO_PRE_OC += 1
                                    FOLIO_ASIGNADO = True
                                Else
                                    Sigue = False
                                End If
                            Loop
                            ULT_DOC = FOLIO_PRE_OC
                            FOLIO = ULT_DOC
                        Catch ex As Exception
                            Bitacora("61. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Next
            Catch ex As Exception
                MsgBox("158. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("158. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                Me.Cursor = Cursors.Default
                Return
            End Try
            '==========================================================================================================================================
            '               EMPIEZA PARTIDAS                  EMPIEZA PARTIDAS                  EMPIEZA PARTIDAS   
            '==========================================================================================================================================
            NUM_PAR = 1 : TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0

            For i As Integer = 1 To Fg.Rows.Count - 1

                If Not Valida_Conexion() Then
                End If
                Application.DoEvents()

                Try
                    CVE_ART = Fg(i, 1)
                    CVE_ART = CVE_ART.Replace("'", "")
                    CVE_ART = RemoveCharacter(CVE_ART)
                    If IsNothing(Fg(i, 12)) Then
                        CANT = 0
                    Else
                        CANT = Fg(i, 12)
                    End If
                Catch ex As Exception
                    CVE_ART = ""
                End Try


                If CVE_ART.Length > 0 And CANT > 0 Then

                    ULT_COSTO = 0 : COSTO_PROM = 0
                    CVE_ESQIMPU = 1
                    Try
                        SQL = "SELECT * FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        Reader = cmd.ExecuteReader
                        If Reader.HasRows Then
                            If Reader.Read Then
                                ULT_COSTO = Reader("ULT_COSTO")
                                COSTO_PROM = Reader("COSTO_PROM")
                                CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                                TIPO_ELE = Reader("TIPO_ELE")
                            End If
                        End If
                        Reader.Close()

                    Catch ex As Exception
                        MsgBox("159. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("159. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    UNI_MED = ""
                    COSTO = ULT_COSTO
                    Try
                        cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                        Reader = cmd.ExecuteReader
                        If Reader.HasRows Then
                            If Reader.Read Then
                                IMPU1 = CSng(Reader("IMPUESTO1"))
                                IMPU2 = CSng(Reader("IMPUESTO2"))
                                IMPU3 = CSng(Reader("IMPUESTO3"))
                                IMPU4 = CSng(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP2APLA = CInt(Reader("IMP2APLICA"))
                                IMP3APLA = CInt(Reader("IMP3APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            End If
                        End If
                        Reader.Close()

                        cIeps = COSTO * IMPU1 / 100
                        If IMP2APLA = 2 Or IMP2APLA = 1 Then
                            cImpu2 = CSng((COSTO + cIeps) * IMPU2 / 100)
                        Else
                            cImpu2 = CSng(COSTO * IMPU2 / 100)
                        End If

                        If IMP3APLA = 2 Or IMP3APLA = 1 Then
                            cImpu3 = CSng((COSTO + cIeps + cImpu2) * IMPU3 / 100)
                        Else
                            cImpu3 = CSng(COSTO * IMPU3 / 100)
                        End If

                        If IMP4APLA = 1 Or IMP4APLA = 2 Then
                            cImpu = (COSTO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                        Else
                            cImpu = COSTO * IMPU4 / 100
                        End If

                        ImporteIeps += (COSTO * CANT * IMPU1 / 100)
                        ImporteImpu2 += (COSTO * CANT * IMPU2 / 100)
                        ImporteImpu3 += (COSTO * CANT * IMPU3 / 100)
                        ImporteIVA += (COSTO * CANT * IMPU4 / 100)

                        DESCU += DES_TOT_PORC
                        TOTIMP1 += (CANT * cIeps)
                        TOTIMP2 += (CANT * cImpu2)
                        TOTIMP3 += (CANT * cImpu3)
                        TOTIMP4 += (CANT * cImpu)
                        TOT_PARTIDA = COSTO * CANT
                        COSTO_PROMEDIO = 0
                        CLAVE_CLPV = CVE_CLPV
                        UNI_VENTA = UNI_MED

                        PREC = 0 : Vend = "" : CANT_COST = 0 : CVE_OBS = 0 : REG_SERIE = 0 : E_LTPD = 0 : TIPO_PROD = "P" : FACTOR_CON = 1 : CTLPOL = 0
                        COSTEADO = "S" : COSTO_PROM_INI = COSTO : COSTO_PROM_FIN = COSTO : DESDE_INVE = "N" : MOV_ENLAZADO = 0

                        VENTA_RANGO_FECH = Fg(i, 3)
                        CVE_DOC_COM = Fg(i, 4)

                        If Not IsNothing(Fg(i, 5)) Then
                            FECHA_ULT_OC = Fg(i, 5)
                        Else
                            FECHA_ULT_OC = "01/01/1900"
                        End If
                        If Not IsNothing(Fg(i, 6)) Then
                            FECHA_ULT_COMPRA = Fg(i, 6)
                        Else
                            FECHA_ULT_COMPRA = "01/01/1900"
                        End If

                        DIF = Fg(i, 7)
                        EXIST = Fg(i, 8)
                        CANT_ULT_COMP = Fg(i, 9)
                        CANT_ENT_DIF_OC_Y_COMP = Fg(i, 10)
                        CANT_SUG_OC = Fg(i, 11)

                        If FECHA_ULT_OC.Trim.Length = 0 Then
                            FECHA_ULT_OC = "01/01/1900"
                        End If
                        If FECHA_ULT_COMPRA.Trim.Length = 0 Then
                            FECHA_ULT_COMPRA = "01/01/1900"
                        End If

                    Catch ex As Exception
                        MsgBox("161. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("161. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    '***************************************************************************************
                    ' ***********************           EMPIEZA PARTIDAS     *******************************
                    '***************************************************************************************
                    Try
                        CVE_OBS = 0
                        OBSER_PAR = Fg(i, 18)
                        OBSER_PAR = RemoveCharacter(OBSER_PAR)

                        If Not IsNothing(OBSER_PAR) Then
                            If OBSER_PAR.ToString.Trim.Length > 0 Then
                                Try
                                    If IsNumeric(Fg(i, 19)) Then
                                        CVE_OBS = Fg(i, 19)
                                    Else
                                        CVE_OBS = 0
                                    End If
                                Catch ex As Exception
                                    CVE_OBS = 0
                                    Bitacora("163. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                End Try
                                CVE_OBS = INSERT_UPDATE_OBS(CVE_OBS, OBSER_PAR)
                            End If
                        End If
                        NUM_PAR2 = 0
                        If CompEdit Then
                            NUM_PAR2 = Fg(i, 13)
                        End If
                    Catch ex As Exception
                        Bitacora("164. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    SQL = "UPDATE COMPO_PRE_PAR SET CANT = @CANT, PXR = @PXR, PREC = @PREC, 
                        COST = @COST, IMPU1 = @IMPU1, IMPU2 = @IMPU2, IMPU3 = @IMPU3, IMPU4 = @IMPU4, IMP1APLA = @IMP1APLA, IMP2APLA = @IMP2APLA, 
                        IMP3APLA = @IMP3APLA, IMP4APLA = @IMP4APLA, TOTIMP1 = @TOTIMP1, TOTIMP2 = @TOTIMP2, TOTIMP3 = @TOTIMP3, TOTIMP4 = @TOTIMP4, 
                        DESCU = @DESCU, ACT_INV = @ACT_INV, TIP_CAM = @TIP_CAM, UNI_VENTA = @UNI_VENTA, TIPO_ELEM = @TIPO_ELEM, TIPO_PROD = @TIPO_PROD, 
                        CVE_OBS = @CVE_OBS, REG_SERIE = @REG_SERIE, E_LTPD = @E_LTPD, FACTCONV = @FACTCONV, COST_DEV = @COST_DEV, NUM_ALM = @NUM_ALM, 
                        MINDIRECTO = @MINDIRECTO, NUM_MOV = @NUM_MOV, TOT_PARTIDA = @TOT_PARTIDA, MAN_IEPS = @MAN_IEPS, APL_MAN_IMP = @APL_MAN_IMP, 
                        CUOTA_IEPS = @CUOTA_IEPS, APL_MAN_IEPS = @APL_MAN_IEPS, MTO_PORC = @MTO_PORC, MTO_CUOTA = @MTO_CUOTA, CVE_ESQ = @CVE_ESQ, 
                        DESCR_ART = @DESCR_ART, VENTA_RANGO_FECH = @VENTA_RANGO_FECH, CVE_DOC_COM = @CVE_DOC_COM, FECHA_ULT_OC = @FECHA_ULT_OC, 
                        FECHA_ULT_COMPRA = @FECHA_ULT_COMPRA, DIF = @DIF, EXIST = @EXIST, CANT_ULT_COMP = @CANT_ULT_COMP, 
                        CANT_ENT_DIF_OC_Y_COMP = @CANT_ENT_DIF_OC_Y_COMP, CANT_SUG_OC = @CANT_SUG_OC 
                        WHERE CVE_DOC = @CVE_DOC And NUM_PAR = @NUM_PAR 
                        If @@ROWCOUNT = 0 
                        INSERT INTO COMPO_PRE_PAR (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXR, PREC, COST, IMPU1,IMPU2, IMPU3, IMPU4, IMP1APLA, 
                        IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESCU, ACT_INV, TIP_CAM, UNI_VENTA, TIPO_ELEM, 
                        TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, FACTCONV, COST_DEV, NUM_ALM, MINDIRECTO, NUM_MOV, TOT_PARTIDA,
                        MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC, MTO_CUOTA, CVE_ESQ, DESCR_ART, VENTA_RANGO_FECH, 
                        CVE_DOC_COM, FECHA_ULT_OC, FECHA_ULT_COMPRA, DIF, EXIST, CANT_ULT_COMP, CANT_ENT_DIF_OC_Y_COMP, CANT_SUG_OC) 
                        VALUES (
                        @CVE_DOC, @NUM_PAR, @CVE_ART, @CANT, @PXR, @PREC, @COST, @IMPU1, @IMPU2, @IMPU3, @IMPU4, @IMP1APLA, @IMP2APLA, @IMP3APLA, 
                        @IMP4APLA, @TOTIMP1, @TOTIMP2, @TOTIMP3, @TOTIMP4, @DESCU, @ACT_INV, @TIP_CAM, @UNI_VENTA, @TIPO_ELEM, @TIPO_PROD, 
                        @CVE_OBS, @REG_SERIE, @E_LTPD, @FACTCONV, @COST_DEV, @NUM_ALM, @MINDIRECTO, 0, @TOT_PARTIDA, @MAN_IEPS, @APL_MAN_IMP, 
                        @CUOTA_IEPS, @APL_MAN_IEPS, @MTO_PORC, @MTO_CUOTA, @CVE_ESQ, @DESCR_ART, @VENTA_RANGO_FECH, @CVE_DOC_COM, 
                        @FECHA_ULT_OC, @FECHA_ULT_COMPRA, @DIF, @EXIST, @CANT_ULT_COMP, @CANT_ENT_DIF_OC_Y_COMP, @CANT_SUG_OC)"
                    Try
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                        cmd.Parameters.Add("@NUM_PAR", SqlDbType.Int).Value = IIf(NUM_PAR2 = 0, NUM_PAR, NUM_PAR2)
                        cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(CVE_ART)
                        cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CANT
                        cmd.Parameters.Add("@PXR", SqlDbType.Float).Value = CANT
                        cmd.Parameters.Add("@PREC", SqlDbType.Float).Value = Math.Round(PREC, 6)
                        cmd.Parameters.Add("@COST", SqlDbType.Float).Value = Math.Round(COSTO, 6)
                        cmd.Parameters.Add("@IMPU1", SqlDbType.Float).Value = IMPU1
                        cmd.Parameters.Add("@IMPU2", SqlDbType.Float).Value = IMPU2
                        cmd.Parameters.Add("@IMPU3", SqlDbType.Float).Value = IMPU3
                        cmd.Parameters.Add("@IMPU4", SqlDbType.Float).Value = IMPU4
                        cmd.Parameters.Add("@IMP1APLA", SqlDbType.SmallInt).Value = IMP1APLA
                        cmd.Parameters.Add("@IMP2APLA", SqlDbType.SmallInt).Value = IMP2APLA
                        cmd.Parameters.Add("@IMP3APLA", SqlDbType.SmallInt).Value = IMP3APLA
                        cmd.Parameters.Add("@IMP4APLA", SqlDbType.SmallInt).Value = IMP4APLA
                        cmd.Parameters.Add("@TOTIMP1", SqlDbType.Float).Value = Math.Round(TOTIMP1, 6)
                        cmd.Parameters.Add("@TOTIMP2", SqlDbType.Float).Value = Math.Round(TOTIMP2, 6)
                        cmd.Parameters.Add("@TOTIMP3", SqlDbType.Float).Value = Math.Round(TOTIMP3, 6)
                        cmd.Parameters.Add("@TOTIMP4", SqlDbType.Float).Value = Math.Round(TOTIMP4, 6)
                        cmd.Parameters.Add("@DESCU", SqlDbType.Float).Value = DESCU
                        cmd.Parameters.Add("@ACT_INV", SqlDbType.VarChar).Value = ACT_INV
                        cmd.Parameters.Add("@TIP_CAM", SqlDbType.Float).Value = TIP_CAM
                        cmd.Parameters.Add("@UNI_VENTA", SqlDbType.VarChar).Value = UNI_MED
                        cmd.Parameters.Add("@TIPO_ELEM", SqlDbType.VarChar).Value = TIPO_ELEM
                        cmd.Parameters.Add("@TIPO_PROD", SqlDbType.VarChar).Value = TIPO_ELE
                        cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                        cmd.Parameters.Add("@REG_SERIE", SqlDbType.Int).Value = REG_SERIE
                        cmd.Parameters.Add("@E_LTPD", SqlDbType.Int).Value = E_LTPD
                        cmd.Parameters.Add("@FACTCONV", SqlDbType.Float).Value = FACTCONV
                        cmd.Parameters.Add("@COST_DEV", SqlDbType.Float).Value = 0
                        cmd.Parameters.Add("@NUM_ALM", SqlDbType.Int).Value = NUM_ALM
                        cmd.Parameters.Add("@MINDIRECTO", SqlDbType.Float).Value = MINDIRECTO
                        cmd.Parameters.Add("@NUM_MOV", SqlDbType.Int).Value = NUM_MOV
                        cmd.Parameters.Add("@TOT_PARTIDA", SqlDbType.Float).Value = Math.Round(TOT_PARTIDA, 6)
                        cmd.Parameters.Add("@MAN_IEPS", SqlDbType.VarChar).Value = MAN_IEPS
                        cmd.Parameters.Add("@APL_MAN_IMP", SqlDbType.Int).Value = APL_MAN_IMP
                        cmd.Parameters.Add("@CUOTA_IEPS", SqlDbType.Float).Value = CUOTA_IEPS
                        cmd.Parameters.Add("@APL_MAN_IEPS", SqlDbType.VarChar).Value = APL_MAN_IEPS
                        cmd.Parameters.Add("@MTO_PORC", SqlDbType.Float).Value = MTO_PORC
                        cmd.Parameters.Add("@MTO_CUOTA", SqlDbType.Float).Value = MTO_CUOTA
                        cmd.Parameters.Add("@CVE_ESQ", SqlDbType.Int).Value = CVE_ESQIMPU
                        cmd.Parameters.Add("@DESCR_ART", SqlDbType.VarChar).Value = ""

                        cmd.Parameters.Add("@VENTA_RANGO_FECH", SqlDbType.Float).Value = VENTA_RANGO_FECH
                        cmd.Parameters.Add("@CVE_DOC_COM", SqlDbType.VarChar).Value = CVE_DOC_COM
                        cmd.Parameters.Add("@FECHA_ULT_OC", SqlDbType.Date).Value = FECHA_ULT_OC
                        cmd.Parameters.Add("@FECHA_ULT_COMPRA", SqlDbType.Date).Value = FECHA_ULT_COMPRA
                        cmd.Parameters.Add("@DIF", SqlDbType.Float).Value = DIF
                        cmd.Parameters.Add("@EXIST", SqlDbType.Float).Value = EXIST
                        cmd.Parameters.Add("@CANT_ULT_COMP", SqlDbType.Float).Value = CANT_ULT_COMP
                        cmd.Parameters.Add("@CANT_ENT_DIF_OC_Y_COMP", SqlDbType.Float).Value = CANT_ENT_DIF_OC_Y_COMP
                        cmd.Parameters.Add("@CANT_SUG_OC", SqlDbType.Float).Value = CANT_SUG_OC
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("170. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    ' ***********************      SQL SERVER   *******************************
                    NUM_PAR += 1
                End If

            Next
            'TERMINA FOR DE PARTIDAS
            'TERMINA FOR DE PARTIDAS
            'TERMINA FOR DE PARTIDAS

            '████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
            '████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████

            If Not CompEdit Then
                Try
                    If SERIE_PRE_OC = "" Or SERIE_PRE_OC = "STAND." Then
                        SQL = "UPDATE FOLIOSC" & Empresa & " SET ULT_DOC = " & FOLIO & " WHERE TIP_DOC = 'p' AND SERIE = 'STAND.'"
                    Else
                        SQL = "UPDATE FOLIOSC" & Empresa & " SET ULT_DOC = " & FOLIO & " WHERE TIP_DOC = 'p' AND SERIE = '" & SERIE_PRE_OC & "'"
                    End If
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                    LtCVE_DOC.Text = CVE_DOC
                Catch ex As Exception
                    MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("320. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            End If

            Me.Cursor = Cursors.Default
            Continua = False
            BarImprimir.Enabled = True
            CompEdit = True
            ImprimirPre_Orden(CVE_DOC)


        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Sub ImprimirPre_Orden(fCVE_DOC As String)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportPreOrdenDeCompra" & Empresa & ".mrt"
            If Not File.Exists(ARCHIVO_MRT) Then
                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportPreOrdenDeCompra.mrt"
                If Not File.Exists(ARCHIVO_MRT) Then
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    Return
                End If
            End If

            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = fCVE_DOC
            StiReport1.Render()

            StiReport1.Show()

        Catch ex As Exception
            Bitacora("710. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            ImprimirPre_Orden(LtCVE_DOC.Text)
        Catch ex As Exception
            Bitacora("710. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnLinea_Click(sender As Object, e As EventArgs) Handles BtnLinea.Click
        Try
            Var2 = "Lineas"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLINEA.Text = Var4
                'LtNombre.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                F1.Focus()
            End If
        Catch ex As Exception
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLINEA_KeyDown(sender As Object, e As KeyEventArgs) Handles TLINEA.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnLinea_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                Dim DESCR As String
                DESCR = TLINEA.Text.Trim
                C1List1.Focus()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TLINEA_Validated(sender As Object, e As EventArgs) Handles TLINEA.Validated
        Try
            If TLINEA.Text.Trim.Length > 0 Then
                Var5 = ""
                Dim DESCR As String
                DESCR = TLINEA.Text.Trim
                If IsNumeric(DESCR) Then
                    TLINEA.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Linea", TLINEA.Text)
                If DESCR <> "" Then
                    Var11 = TLINEA.Text
                    LtDescrLinea.Text = DESCR
                Else
                    MsgBox("Linea inexistente")
                    TLINEA.Text = ""
                    LtDescrLinea.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

        End If
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If e.Row > 0 Then
                If FgModif Then
                    If e.Col <> 12 Then
                        e.Cancel = True
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTotales_Click(sender As Object, e As ClickEventArgs) Handles BarTotales.Click
        Try
            CALCULAR_IMPORTES()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarSeries_Click(sender As Object, e As ClickEventArgs) Handles BarSeries.Click
        Try
            TIPO_COMPRA = "p"

            frmSeriesCompras.ShowDialog()
            If FOLIO_COMPRA > 0 Then
                If LETRA_COMPRA.Trim.Length = 0 Or LETRA_COMPRA = "STAND." Then
                    LtCVE_DOC.Text = "          " & Format(FOLIO_COMPRA, "0000000000")
                Else
                    LtCVE_DOC.Text = LETRA_COMPRA & Format(FOLIO_COMPRA, "0000000000")
                End If

                SERIE_PRE_OC = LETRA_COMPRA
                FOLIO_PRE_OC = FOLIO_COMPRA
            End If

        Catch ex As Exception
            Bitacora("550. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("550. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Class