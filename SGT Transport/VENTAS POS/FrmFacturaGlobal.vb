
Imports System.IO
Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmFacturaGlobal
    Private _comprobante As Comprobante

    Private UsoCFD As String, CVE_DOC As String, RUTA_XML As String, RUTA_PDF As String, EMISOR_RAZON_SOCIAL As String = "", EMISOR_LUGAR_EXPEDICION As String = ""
    Private EMISOR_REGIMEN_FISCAL As String = "", EmisorRfcCFD As String, SerieCFD As String, FolioCFD As String, FechaEmision As String
    Private FormaPagoCFD As String, UsoCFDICFD As String, TipoComprobanteCFD As String
    Private TIMBRADO_DEMO As String = "No", gUSUARIO_PAC As String, gPASS_PAC As String, EMISOR_RFC As String
    Private PolizaMedAmbiente As String, AseguraMedAmbiente As String, CP_POLIZAMEDAMBIENTE As String, CP_ASEGURAMEDAMBIENTE As String
    Private TCALLE As String, TNUMEXT As String, TNUMINT As String, TCP As String

    Private CVE_ART_FG As String
    Private SERIE_FAC_GLOBAL As String
    Private PERIODICIDAD As String
    Private FECHA1 As String
    Private FECHA2 As String
    Private SERIE_FILTRO As String
    Private CLIENTE_MOSTRADOR As String
    Private CTE_MOSTR_TODOS As Boolean

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub FrmFacturaGlobal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
        C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Fg.Styles.EmptyArea.BackColor = ColoFondoFG

        Dim SPOR1 As Decimal
        SPOR1 = ((C1ToolBar1.Height + LtFecha1.Top + LtFecha1.Height) / Me.Height) * 100
        SplitP1.SizeRatio = SPOR1 + 1
        SplitP2.SizeRatio = 100 - SplitP1.SizeRatio

        ProcessControls(SplitP1)         'PROCESO PARA QUITAR EL FONDO EN LAS ETIQUETAS

    End Sub
    Sub CARGAR_DATOS()
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLIE_MOSTR, CVE_ART_FG FROM GCPARAMVENTAS"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CLIENTE_MOSTRADOR = dr.ReadNullAsEmptyString("CLIE_MOSTR")
                        CVE_ART_FG = dr.ReadNullAsEmptyString("CVE_ART_FG")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try

            'Var10 = SERIE_FAC_GLOBAL
            'Var11 = PERIODICIDAD
            'Var12 = FECHA1
            'Var13 = FECHA2
            'Var14 = SERIE_FILTRO
            SERIE_FAC_GLOBAL = Var10
            PERIODICIDAD = Var11
            FECHA1 = Var12
            FECHA2 = Var13
            SERIE_FILTRO = Var14

            Split1.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill
            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Checked)

            LtSerieFacturaGlobal.Text = SERIE_FAC_GLOBAL
            LtPeriodicidad.Text = PERIODICIDAD
            LtFecha1.Text = FECHA1
            LtFecha2.Text = FECHA2
            LtSerieFiltro.Text = SERIE_FILTRO
            If Var26 = 1 Then
                CTE_MOSTR_TODOS = False
                LtFiltrarCteMostr.Text = "Todas las notas"
            Else
                CTE_MOSTR_TODOS = True
                LtFiltrarCteMostr.Text = "Solo notas de cliente mostrador"
            End If

            Fg.Cols(1).StarWidth = "*"
            Fg.Cols(2).StarWidth = "2*"
            Fg.Cols(3).StarWidth = "2*"
            Fg.Cols(4).StarWidth = "2*"

            DESPLEGAR()

        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim CADENA_SERIE As String, CADENA_MOSTR As String
            Me.Cursor = Cursors.WaitCursor
            Fg.Redraw = False

            If SERIE_FILTRO = "Todos" Then
                CADENA_SERIE = ""
            Else
                CADENA_SERIE = " AND SERIE = '" & SERIE_FILTRO & "'"
            End If
            If CTE_MOSTR_TODOS Then
                CADENA_MOSTR = " AND CVE_CLPV = '" & CLIENTE_MOSTRADOR & "'"
            Else
                CADENA_MOSTR = ""
            End If

            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_DOC, FECHA_DOC, IMPORTE 
                    FROM FACTV" & Empresa & " 
                    WHERE FECHA_DOC >= '" & FSQL(FECHA1) & "' AND FECHA_DOC <= '" & FSQL(FECHA2) & "' AND 
                    ISNULL(ENLAZADO,'') <> 'T'" & CADENA_SERIE & CADENA_MOSTR
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "1" & vbTab & dr("CVE_DOC") & vbTab & dr("FECHA_DOC") & vbTab & dr("IMPORTE"))
                    End While
                End Using
            End Using

            Lt1.Text = "Documentos encontrados:" & Fg.Rows.Count - 1
            Fg.Redraw = True

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BarTimbrar_Click(sender As Object, e As ClickEventArgs) Handles BarTimbrar.Click
        Dim CVE_DOC As String = "", CVE_DOC_G As String = "", IMPORTE As Decimal, IEPS As Decimal, IVA4 As Decimal, CVE_PRODSERV As String = ""
        Dim SERIEFG As String, SIGUE As Boolean = True, FOLIO_VG As Long, DETEC_ERROR_VIOLATION_KEY As Boolean = False
        Dim CAN_TOT As Decimal = 0, j As Integer = 0, RFC As String = "", USO_CFDI As String = "", REG_FISC As String = "", z As Integer = 0
        Dim FORMADEPAGOSAT As String = "", NUM_PAR As Integer = 1, COSTO As Decimal = 0
        Dim CVE_ESQ As Integer, CVE_ESQ1 As Integer, CVE_ESQ2 As Integer, CVE_ESQ3 As Integer, SELIMP As Boolean
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, TIPO_PROD As String = "", GRABO_PAR As Boolean
        Dim IMP1APLICA As Integer, IMP2APLICA As Integer, IMP3APLICA As Integer, IMP4APLICA As Integer, HayError As Boolean = False, CP As String = ""

        SERIEFG = LtSerieFacturaGlobal.Text

        If SERIEFG.Trim.Length = 0 Then
            MsgBox("Por favor seleccine la serie de la factura global")
            Return
        End If

        Try
            FOLIO_VG = SIGUIENTE_FOLIO_VENTA("F", SERIEFG)

            Do While SIGUE
                If SERIEFG.Trim.Length = 0 Or SERIEFG = "STAND." Then
                    CVE_DOC = Space(10) & Format(FOLIO_VG, "0000000000")
                Else
                    CVE_DOC = SERIEFG & Format(FOLIO_VG, "0000000000")
                End If

                If EXISTE_VENTA("F", CVE_DOC) Then
                    FOLIO_VG += 1
                Else
                    SIGUE = False
                End If
            Loop
        Catch ex As Exception
            BITACORATPV("425. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("425. " & ex.Message & vbNewLine & ex.StackTrace)
            Return
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT RFC, USO_CFDI, REG_FISC, FORMADEPAGOSAT, CODIGO
                    FROM CLIE" & Empresa & " 
                    WHERE CLAVE = '" & CLIENTE_MOSTRADOR & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        RFC = dr("RFC")
                        USO_CFDI = dr("USO_CFDI")
                        REG_FISC = dr("REG_FISC")
                        FORMADEPAGOSAT = dr("FORMADEPAGOSAT")
                        CP = dr("CODIGO")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        If MsgBox("Realmente desea generar la factura global?", vbYesNo, CVE_DOC) = vbNo Then
            Return
        End If

        Try
            IEPS = 0
            IVA4 = 0
            IMPORTE = 0

            Try
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1) Then

                        CVE_DOC_G = Fg(k, 2)

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT (PREC * CANT) AS TOT_PAR, COST * CANT AS COSTO, IMPU1, IMPU2, IMPU3, IMPU4,
                                TOTIMP1 AS TIMP1, TOTIMP2 AS TIMP2, TOTIMP3 AS TIMP3, TOTIMP4 AS TIMP4
                                FROM PAR_FACTV" & Empresa & " P
                                LEFT JOIN FACTV" & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                                WHERE P.CVE_DOC = '" & CVE_DOC_G & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read

                                    If dr("IMPU1") > 0 Then
                                        'IMPU1 = (dr("IMPU1") / 100) + 1
                                        IEPS += dr("TOT_PAR") * dr("IMPU1") / 100
                                    End If
                                    If dr("IMPU4") > 0 Then
                                        IVA4 += dr("TOT_PAR") * dr("IMPU4") / 100
                                    End If
                                    COSTO += dr("COSTO")
                                    'IEPS += dr("TIMP1")
                                    'IVA4 += dr("TIMP4")
                                    CAN_TOT += dr("TOT_PAR") '+ IEPS + IVA4
                                    j += 1
                                End While
                            End Using
                        End Using
                    End If
                Next
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                HayError = True
            End Try

            If HayError Then
                MsgBox("No se logro crear la factura global")
                Return
            End If
            If j > 0 Then
                'CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS
                For x = 1 To 5
                    Try
                        SQL = "INSERT INTO FACTF" & Empresa & " (TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, DAT_MOSTR, CVE_VEND, CVE_PEDI, FECHA_DOC, 
                            FECHA_ENT, FECHA_VEN, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, CVE_OBS, 
                            NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, CTLPOL, 
                            ESCFD, AUTORIZA, SERIE, FOLIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, 
                            METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, UUID, VERSION_SINC, FORMADEPAGOSAT, USO_CFDI)
                            VALUES(
                            @TIP_DOC, @CVE_DOC, @CVE_CLPV, 'E', @DAT_MOSTR, @CVE_VEND, @CVE_PEDI, CONVERT(varchar, GETDATE(), 112), 
                            CONVERT(varchar, GETDATE(), 112), CONVERT(varchar, GETDATE(), 112), ROUND(@CAN_TOT,6), ROUND(@IMP_TOT1,6), 
                            ROUND(@IMP_TOT2,6), ROUND(@IMP_TOT3,6), ROUND(@IMP_TOT4,6), @DES_TOT, @DES_FIN, @COM_TOT, @CONDICION, @CVE_OBS, 
                            @NUM_ALMA, @ACT_CXC, @ACT_COI, @ENLAZADO, @TIP_DOC_E, @NUM_MONED, @TIPCAMB, @NUM_PAGOS, GETDATE(), @PRIMERPAGO, 
                            @RFC, @CTLPOL, @ESCFD, @AUTORIZA, @SERIE, @FOLIO, @DAT_ENVIO, @CONTADO, @CVE_BITA, @BLOQ, @FORMAENVIO, 
                            @DES_FIN_PORC, @DES_TOT_PORC, ROUND(@IMPORTE,6), @METODODEPAGO, @NUMCTAPAGO, @TIP_DOC_ANT, @DOC_ANT, NEWID(), 
                            GETDATE(), @FORMADEPAGOSAT, @USO_CFDI)"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Add("@TIP_DOC", SqlDbType.VarChar).Value = "F"
                            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                            cmd.Parameters.Add("@CVE_CLPV", SqlDbType.VarChar).Value = CLIENTE_MOSTRADOR
                            cmd.Parameters.Add("@DAT_MOSTR", SqlDbType.Int).Value = 0
                            cmd.Parameters.Add("@CVE_VEND", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@CVE_PEDI", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@CAN_TOT", SqlDbType.Float).Value = CAN_TOT
                            cmd.Parameters.Add("@IMP_TOT1", SqlDbType.Float).Value = IEPS
                            cmd.Parameters.Add("@IMP_TOT2", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@IMP_TOT3", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@IMP_TOT4", SqlDbType.Float).Value = IVA4
                            cmd.Parameters.Add("@DES_TOT", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@DES_FIN", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@COM_TOT", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@CONDICION", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = 0
                            cmd.Parameters.Add("@NUM_ALMA", SqlDbType.Int).Value = 1
                            cmd.Parameters.Add("@ACT_CXC", SqlDbType.VarChar).Value = "S"
                            cmd.Parameters.Add("@ACT_COI", SqlDbType.VarChar).Value = "N"
                            cmd.Parameters.Add("@ENLAZADO", SqlDbType.VarChar).Value = "O"
                            cmd.Parameters.Add("@TIP_DOC_E", SqlDbType.VarChar).Value = "V"
                            cmd.Parameters.Add("@NUM_MONED", SqlDbType.Int).Value = 1
                            cmd.Parameters.Add("@TIPCAMB", SqlDbType.Float).Value = 1
                            cmd.Parameters.Add("@NUM_PAGOS", SqlDbType.Int).Value = 1
                            cmd.Parameters.Add("@PRIMERPAGO", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = RFC
                            cmd.Parameters.Add("@CTLPOL", SqlDbType.Int).Value = 0
                            cmd.Parameters.Add("@ESCFD", SqlDbType.VarChar).Value = "T"
                            cmd.Parameters.Add("@AUTORIZA", SqlDbType.Int).Value = 1
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIEFG
                            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO_VG
                            cmd.Parameters.Add("@DAT_ENVIO", SqlDbType.Int).Value = 0
                            cmd.Parameters.Add("@CONTADO", SqlDbType.VarChar).Value = "S"
                            cmd.Parameters.Add("@CVE_BITA", SqlDbType.Int).Value = 0
                            cmd.Parameters.Add("@BLOQ", SqlDbType.VarChar).Value = "N"
                            cmd.Parameters.Add("@FORMAENVIO", SqlDbType.VarChar).Value = "I"
                            cmd.Parameters.Add("@DES_FIN_PORC", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@DES_TOT_PORC", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CAN_TOT + IEPS + IVA4
                            cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = "PUE"
                            cmd.Parameters.Add("@NUMCTAPAGO", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@TIP_DOC_ANT", SqlDbType.VarChar).Value = "V"
                            cmd.Parameters.Add("@DOC_ANT", SqlDbType.VarChar).Value = CVE_DOC_G
                            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FORMADEPAGOSAT
                            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                    Exit For
                                End If
                            End If
                        End Using
                        'CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS
                    Catch ex As SqlException
                        ' Log the original exception here
                        For Each sqlError As SqlError In ex.Errors

                            BITACORASQL(sqlError.Number & ", " & sqlError.ToString)

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
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try
                    If DETEC_ERROR_VIOLATION_KEY Then
                        Try
                            FOLIO_VG = SIGUIENTE_FOLIO_VENTA("F", SERIEFG)
                            SIGUE = True
                            Do While SIGUE
                                If SERIEFG.Trim.Length = 0 Or SERIEFG = "STAND." Then
                                    CVE_DOC = Space(10) & Format(FOLIO_VG, "0000000000")
                                Else
                                    CVE_DOC = LETRA_VENTA & Format(FOLIO_VG, "0000000000")
                                End If

                                If EXISTE_VENTA("F", CVE_DOC) Then
                                    FOLIO_VG += 1
                                Else
                                    SIGUE = False
                                End If
                            Loop
                        Catch ex As Exception
                            BITACORATPV("425. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("425. " & ex.Message & vbNewLine & ex.StackTrace)
                            Return
                        End Try
                    End If
                Next

                'CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS       CABEZAS

                'FIN FOR GRABADO CORRECTA DE LA CABEZA



                'INICIA GRABADO DE LAS PARTIDAS
                For k = 1 To Fg.Rows.Count - 1

                    If Fg(k, 1) Then

                        CVE_DOC_G = Fg(k, 2)
                        IEPS = 0 : IVA4 = 0 : IMPORTE = 0 : CVE_ESQ1 = 0 : CVE_ESQ2 = 0 : CVE_ESQ3 = 0
                        z = 0
                        SELIMP = True
                        'PARTIDAS   PARTIDAS   PARTIDAS   PARTIDAS  PARTIDAS
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT CANT, NUM_PAR, (PREC * CANT) AS TOT_PAR, (COST * CANT) AS COSTO, IMPU1, IMPU2, IMPU3, IMPU4,
                            TOTIMP1 AS TIMP1, TOTIMP2 AS TIMP2, TOTIMP3 AS TIMP3, TOTIMP4 AS TIMP4, CVE_ESQ
                            FROM PAR_FACTV" & Empresa & " P
                            LEFT JOIN FACTV" & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                            WHERE P.CVE_DOC = '" & CVE_DOC_G & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    'PARTIDAS   PARTIDAS   PARTIDAS   PARTIDAS  PARTIDAS
                                    If dr("IMPU1") > 0 Then
                                        IEPS += dr("TOT_PAR") * dr("IMPU1") / 100
                                        CVE_ESQ1 = dr("CVE_ESQ")
                                    End If
                                    If dr("IMPU4") > 0 Then
                                        IVA4 += dr("TOT_PAR") * dr("IMPU4") / 100
                                        CVE_ESQ2 = dr("CVE_ESQ")
                                    End If
                                    If dr("IMPU1") > 0 And dr("IMPU4") > 0 Then
                                        CVE_ESQ3 = dr("CVE_ESQ")
                                    End If
                                    COSTO += dr("COSTO")
                                    'IEPS += dr("TIMP1")
                                    'IVA4 += dr("TIMP4")
                                    IMPORTE += dr("TOT_PAR") '+ IEPS + IVA4

                                    SQL = "INSERT INTO DOCTOSIGF" & Empresa & " (TIP_DOC, CVE_DOC, ANT_SIG, TIP_DOC_E, CVE_DOC_E, PARTIDA, PART_E, CANT_E) 
                                        VALUES ('F','" & CVE_DOC & "','A','V','" & CVE_DOC_G & "','" & NUM_PAR & "','" & dr("NUM_PAR") & "','" & dr("CANT") & "')"
                                    Try
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                    End Try

                                    z += 1
                                End While
                            End Using
                            If z > 0 Then
                                SQL = "UPDATE FACTV" & Empresa & " SET TIP_DOC_SIG = 'F', DOC_SIG = '" & CVE_DOC & "' WHERE CVE_DOC = '" & CVE_DOC_G & "'"
                                If EXECUTE_QUERY_NET(SQL) Then
                                    returnValue2 = "1"
                                End If
                            Else
                                returnValue2 = "1"
                            End If
                            If CVE_ESQ1 > 0 Then
                                CVE_ESQ = CVE_ESQ1
                            ElseIf CVE_ESQ2 > 0 Then
                                CVE_ESQ = CVE_ESQ2
                            Else
                                CVE_ESQ = CVE_ESQ3
                            End If
                        End Using
                        'PARTIDAS   PARTIDAS   PARTIDAS   PARTIDAS  PARTIDAS
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, 
                                IMP1APLICA, IMP2APLICA, IMP3APLICA, IMP4APLICA  
                                FROM IMPU" & Empresa & " 
                                WHERE CVE_ESQIMPU = " & CVE_ESQ
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    IMPU1 = dr("IMPUESTO1")
                                    IMPU2 = dr("IMPUESTO2")
                                    IMPU3 = dr("IMPUESTO3")
                                    IMPU4 = dr("IMPUESTO4")
                                    IMP1APLICA = dr("IMP1APLICA")
                                    IMP2APLICA = dr("IMP2APLICA")
                                    IMP3APLICA = dr("IMP3APLICA")
                                    IMP4APLICA = dr("IMP4APLICA")
                                End If
                            End Using
                        End Using
                        'PARTIDAS   PARTIDAS   PARTIDAS   PARTIDAS  PARTIDAS
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT TIPO_ELE
                                FROM INVE" & Empresa & " 
                                WHERE CVE_ART = '" & CVE_ART_FG & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    TIPO_PROD = dr("TIPO_ELE")
                                End If
                            End Using
                        End Using

                        If z > 0 Then
                            GRABO_PAR = False
                            Try
                                'PARTIDAS   PARTIDAS   PARTIDAS   PARTIDAS  PARTIDAS
                                SQL = "INSERT INTO PAR_FACTF" & Empresa & " (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, 
                                    IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, 
                                    DESC3, COMI, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, 
                                    TIPO_ELEM, TOT_PARTIDA, MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC, MTO_CUOTA, UUID, 
                                    VERSION_SINC)
                                    VALUES (@CVE_DOC, @NUM_PAR, @CVE_ART, @CANT, @PXS, ROUND(@PREC,6), ROUND(@COST,6), @IMPU1, @IMPU2, 
                                    @IMPU3, @IMPU4, @IMP1APLA, @IMP2APLA, @IMP3APLA, @IMP4APLA, ROUND(@TOTIMP1,6), ROUND(@TOTIMP2,6), 
                                    ROUND(@TOTIMP3,6), ROUND(@TOTIMP4,6), @DESC1, @DESC2, @DESC3, @COMI, @ACT_INV, @NUM_ALM, @POLIT_APLI, 
                                    @TIP_CAM, @UNI_VENTA, @TIPO_PROD, @CVE_OBS, @REG_SERIE, @E_LTPD, @TIPO_ELEM, ROUND(@TOT_PARTIDA,6), 
                                    @MAN_IEPS, @APL_MAN_IMP, @CUOTA_IEPS, @APL_MAN_IEPS, @MTO_PORC, @MTO_CUOTA, NEWID(), GETDATE())"
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    cmd.CommandText = SQL
                                    cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                                    cmd.Parameters.Add("@NUM_PAR", SqlDbType.Int).Value = NUM_PAR
                                    cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = CVE_ART_FG
                                    cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = 1
                                    cmd.Parameters.Add("@PXS", SqlDbType.Float).Value = 1
                                    cmd.Parameters.Add("@PREC", SqlDbType.Float).Value = IMPORTE
                                    cmd.Parameters.Add("@COST", SqlDbType.Float).Value = COSTO
                                    cmd.Parameters.Add("@IMPU1", SqlDbType.Float).Value = IMPU1
                                    cmd.Parameters.Add("@IMPU2", SqlDbType.Float).Value = IMPU2
                                    cmd.Parameters.Add("@IMPU3", SqlDbType.Float).Value = IMPU3
                                    cmd.Parameters.Add("@IMPU4", SqlDbType.Float).Value = IMPU4
                                    cmd.Parameters.Add("@IMP1APLA", SqlDbType.SmallInt).Value = IMP1APLICA
                                    cmd.Parameters.Add("@IMP2APLA", SqlDbType.SmallInt).Value = IMP2APLICA
                                    cmd.Parameters.Add("@IMP3APLA", SqlDbType.SmallInt).Value = IMP3APLICA
                                    cmd.Parameters.Add("@IMP4APLA", SqlDbType.SmallInt).Value = IMP4APLICA
                                    cmd.Parameters.Add("@TOTIMP1", SqlDbType.Float).Value = IEPS
                                    cmd.Parameters.Add("@TOTIMP2", SqlDbType.Float).Value = 0
                                    cmd.Parameters.Add("@TOTIMP3", SqlDbType.Float).Value = 0
                                    cmd.Parameters.Add("@TOTIMP4", SqlDbType.Float).Value = IVA4
                                    cmd.Parameters.Add("@DESC1", SqlDbType.Float).Value = 0
                                    cmd.Parameters.Add("@DESC2", SqlDbType.Float).Value = 0
                                    cmd.Parameters.Add("@DESC3", SqlDbType.Float).Value = 0
                                    cmd.Parameters.Add("@COMI", SqlDbType.Float).Value = 0
                                    cmd.Parameters.Add("@ACT_INV", SqlDbType.VarChar).Value = ""
                                    cmd.Parameters.Add("@NUM_ALM", SqlDbType.Int).Value = 1
                                    cmd.Parameters.Add("@POLIT_APLI", SqlDbType.VarChar).Value = ""
                                    cmd.Parameters.Add("@TIP_CAM", SqlDbType.Float).Value = 1
                                    cmd.Parameters.Add("@UNI_VENTA", SqlDbType.VarChar).Value = "N/A"
                                    cmd.Parameters.Add("@TIPO_PROD", SqlDbType.VarChar).Value = TIPO_PROD
                                    cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = 0
                                    cmd.Parameters.Add("@REG_SERIE", SqlDbType.Int).Value = 0
                                    cmd.Parameters.Add("@E_LTPD", SqlDbType.Int).Value = 0
                                    cmd.Parameters.Add("@TIPO_ELEM", SqlDbType.VarChar).Value = "N"
                                    cmd.Parameters.Add("@TOT_PARTIDA", SqlDbType.Float).Value = IMPORTE
                                    cmd.Parameters.Add("@MAN_IEPS", SqlDbType.VarChar).Value = IIf(IVA4 > 0, "N", "")
                                    cmd.Parameters.Add("@APL_MAN_IMP", SqlDbType.Int).Value = IIf(IVA4 > 0, 1, 0)
                                    cmd.Parameters.Add("@CUOTA_IEPS", SqlDbType.Float).Value = 0
                                    cmd.Parameters.Add("@APL_MAN_IEPS", SqlDbType.VarChar).Value = IIf(IVA4 > 0, "C", "")
                                    cmd.Parameters.Add("@MTO_PORC", SqlDbType.Float).Value = 0
                                    cmd.Parameters.Add("@MTO_CUOTA", SqlDbType.Float).Value = 0
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            Lt1.Text = "Partidas procesadas:" & NUM_PAR
                                            NUM_PAR += 1
                                        End If
                                    End If
                                End Using
                                'PARTIDAS   PARTIDAS   PARTIDAS   PARTIDAS  PARTIDAS

                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End If
                    End If
                Next
            End If


            PassData1 = "FACTURA GLOBAL"
            Var4 = CVE_DOC
            Var5 = ""
            Var18 = ""
            Var16 = ""


            '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
            ' INICA PROCESO DE TIMBRAR 
            FrmTimbrarCdeP.LtNombre.Text = "Cliente mostrador"
            FrmTimbrarCdeP.LtRFC.Text = ""
            FrmTimbrarCdeP.LtUSO_CFDI.Text = USO_CFDI
            FrmTimbrarCdeP.LtRegimenReceptor.Text = REG_FISC
            FrmTimbrarCdeP.LtCP.Text = CP

            FrmTimbrarCdeP.ShowDialog()

            'MsgBox("Proceso terminado")

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmFacturaGlobal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Factura global")
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Factura de cierre de notas de venta " & FECHA1.Replace("/", "_"))
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If e.Row = 0 AndAlso e.Col = 1 Then
                ChangeState(Fg.GetCellCheck(e.Row, e.Col))
            Else
                If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, 1, state)
        Next
    End Sub
    Private Function GetImpuestosConcepto(FPRECIO As Decimal, FCANT As Decimal, FDESC As Decimal,
                     FIMPU1 As Decimal, FIMPU2 As Decimal, FIMPU3 As Decimal, FIMPU4 As Decimal) As ImpuestosC
        Dim Impuesto As New ImpuestosC()
        Try
            If FIMPU1 > 0 Then
                FIMPU1 /= 100
                Impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU1, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "003", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU1, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU2 < 0 Then
                FIMPU2 = Math.Abs(FIMPU2)
                FIMPU2 /= 100
                Impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU2, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU2, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU3 < 0 Then
                FIMPU3 = Math.Abs(FIMPU3)
                FIMPU3 /= 100
                Impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU3, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "003", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU3, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU4 > 0 Then
                FIMPU4 /= 100
                Impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU4, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU4, 2), .TipoFactor = "Tasa"})
            End If
        Catch ex As Exception
            BITACORATPV("1750. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1750. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return Impuesto

    End Function
    Private Sub CalculaTotalesCFDI()
        _comprobante.Impuestos = GetImpuestosCFDI(_comprobante.Conceptos.Concepto)
        Dim subtotal As Decimal = 0D
        Dim descuento As Decimal = 0D

        For Each c As Concepto In _comprobante.Conceptos.Concepto
            subtotal += c.Importe
            descuento = c.Descuento
        Next

        _comprobante.SubTotal = subtotal
        _comprobante.Descuento = descuento
        _comprobante.Total = subtotal - _comprobante.Impuestos.TotalImpuestosRetenidos + _comprobante.Impuestos.TotalImpuestosTrasladados
        _comprobante.TotalLetra = New Numalet().ToCustomString(_comprobante.Total)

    End Sub
    Private Function GetImpuestosCFDI(ByVal conceptos As List(Of Concepto)) As Impuestos
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
                    traslados(index).Base = traslados(index).Base + t.Base
                Else
                    traslado = New Traslado()

                    traslado.Base = traslado.Base + t.Base
                    traslado.Importe = t.Importe
                    traslado.Impuesto = t.Impuesto
                    traslado.TasaOCuota = t.TasaOCuota
                    traslado.TipoFactor = t.TipoFactor

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

        If totalImpuestosRetenidos > 0 Then
            impuestos.TotalImpuestosRetenidos = totalImpuestosRetenidos
        End If
        If totalImpuestosTrasladados > 0 Then
            impuestos.TotalImpuestosTrasladados = totalImpuestosTrasladados
        End If
        impuestos.Traslados = traslados
        impuestos.Retenciones = retenciones
        Return impuestos
    End Function
End Class