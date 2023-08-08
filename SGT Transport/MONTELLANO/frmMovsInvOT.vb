Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1FlexGrid

Public Class FrmMovsInvOT
    Private PROC_OT As String
    Private FG_NOT As Boolean = True
    Private TIPO_VENTA As String = "R"
    Private CVE_CPTO_OT As Integer = 0

    Private Sub frmMovsInvOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Catch ex As Exception
            End Try

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            Panel1.Enabled = False
            Panel2.Enabled = False

            Tab1.Height = Me.Height - Tab1.Height + 50
            Tab1.Width = Me.Width - 50
            Fg.Width = Me.Width - 100



            CARGA_PARAM_INVENT()

            PROC_OT = Var15
            If PROC_OT = "TOTINT" Then

                SQL = "SELECT O.CVE_ORD, O.ESTATUS, O.FECHA, O.CVE_SER, O.TIPO_SERVICIO, ISNULL(O.TIPO_EXTRA, 0) AS T_EXTRA, O.CVE_UNI, O.CVE_TIPO, O.CVE_OPER, " &
                    "O.CVE_PROV, O.FACTURA, O.VIDA_REP_ANO, O.VIDA_REP_KM, O.LUGAR_REP, O.NOTA, O.CVE_OBS, OB.DESCR AS OBS_STR " &
                    "FROM GCORDEN_TRABAJO O " &
                    "LEFT JOIN GCOBS OB ON OB.CVE_OBS = O.CVE_OBS " &
                    "WHERE CVE_ORD = '" & Var2 & "' AND STATUS = 'A'"
            Else
                SQL = "SELECT O.CVE_ORD, O.ESTATUS, O.FECHA, O.CVE_SER, O.TIPO_SERVICIO, ISNULL(O.TIPO_EXTRA, 0) AS T_EXTRA, O.CVE_UNI, O.CVE_TIPO, O.CVE_OPER, " &
                    "O.CVE_PROV, O.FACTURA, O.VIDA_REP_ANO, O.VIDA_REP_KM, O.LUGAR_REP, O.NOTA, O.CVE_OBS, OB.DESCR AS OBS_STR " &
                    "FROM GCORDEN_TRABAJO_EXT O " &
                    "LEFT JOIN GCOBS OB ON OB.CVE_OBS = O.CVE_OBS " &
                    "WHERE CVE_ORD = '" & Var2 & "'"
            End If

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                tCVE_ORD.Text = dr("CVE_ORD").ToString
                F1.Value = dr("FECHA").ToString
                If dr("T_EXTRA").ToString = "1" Then
                    radPreventivo.Checked = False
                    radCorrectivo.Checked = False
                    radExtra.AutoCheck = True
                Else
                    If dr("TIPO_SERVICIO").ToString = 0 Then
                        radPreventivo.Checked = True
                        radCorrectivo.Checked = False
                        radExtra.Checked = False
                    Else
                        If dr("TIPO_SERVICIO").ToString = 1 Then
                            radPreventivo.Checked = False
                            radCorrectivo.Checked = True
                            radExtra.Checked = False
                        Else
                            radPreventivo.Checked = False
                            radCorrectivo.Checked = False
                            radExtra.Checked = True
                        End If
                    End If
                End If

                tCVE_UNI.Text = dr("CVE_UNI").ToString
                tCVE_TIPO.Text = dr("CVE_TIPO").ToString
                tCVE_OPER.Text = dr("CVE_OPER").ToString
                LtOper.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)

                Var6 = "0"
                tCVE_PROV.Text = dr("CVE_PROV").ToString
                L3.Text = BUSCA_CAT("ClieOT", tCVE_PROV.Text)
                tCVE_PROV.Tag = Val(Var6)

                tEstatus.Text = dr("ESTATUS").ToString
                tLUGAR_REP.Text = dr("LUGAR_REP").ToString
                tNOTA.Text = dr("NOTA").ToString

                tOBSER.Text = dr("OBS_STR").ToString
                tOBSER.Tag = dr("CVE_OBS").ToString

                CARGAR_SERVICIOS()
            End If
            dr.Close()
            tCVE_ORD.Enabled = False

            If Var1 = "Consul" Or tEstatus.Text = "FINALIZADO" Then
                FG_NOT = False
                'Fg.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV, ISNULL(CVE_CPTO_OT_SAL,0) AS CVE_CPTOOT " &
                "FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                AFEC_TABLA_INVE = dr("AFE_TAB_INV")
                CVE_CPTO_OT = dr("CVE_CPTOOT")

            End If
            dr.Close()

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(SERIE_REMISION,0) AS SERIE_REM " &
                "FROM GCPARAMVENTAS"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                SERIE_VENTA = dr("SERIE_REM")
            Else
                SERIE_VENTA = ""
            End If
            dr.Close()

        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmMovsInvOT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Movs. Inv. TOT")
            Me.Dispose()

            'If FORM_IS_OPEN("frmOrdenDeTrabajo") Then
            'frmOrdenDeTrabajo.DESPLEGAR()
            ' End If
        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_SERVICIOS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim DESCR As String, IMPORTE As Decimal = 0, CANT As Decimal = 0, CANT_ENT As Decimal = 0, CANT_ORD As Decimal = 0
            Dim s As String

            cmd.Connection = cnSAE
            Fg.Rows.Count = 1

            Fg(0, 1) = "Seleccione"

            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Boolean)
            Fg(0, 2) = "Artculo"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripcion"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Almacén"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Cantidad"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.0000"
            Fg.Cols(6).Width = 80

            Fg(0, 6) = "Costo"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"
            Fg.Cols(6).Width = 90

            Fg(0, 7) = "Servicio"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Cant. entregada"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"
            Fg.Cols(8).Width = 90

            Fg(0, 9) = "Estatus"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Subtotal"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Cantidad real"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"
            Fg.Cols(11).Width = 80

            Fg(0, 12) = "Estatus"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            Fg(0, 13) = "UUID"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(String)

            Fg.Cols(13).Width = 0
            Fg.Cols(7).Visible = False
            Fg.Cols(10).Visible = False
            Fg.Cols(11).Visible = False
            Fg.Cols(12).Visible = False
            If Var1 = "Consul" Then
                Fg.Cols(1).Visible = False
            End If

            SQL = "SELECT CVE_ORD, ISNULL(O.CVE_ART,'') AS CLAVE, ISNULL(I.DESCR,'') AS DES, ISNULL(O.CANT,0) AS CANTI,
                 ISNULL((SELECT SUM(CANT * SIGNO) FROM MINVE" & Empresa & " WHERE
                (REFER LIKE 'OT" & tCVE_ORD.Text & "%' OR REFER LIKE 'CCOT" & tCVE_ORD.Text & "%') AND CVE_ART = O.CVE_ART AND CVE_FOLIO = O.CVE_PROV),0) AS CANT_ENT,
                ISNULL(O.COSTO,0) AS COST, ISNULL(HORA2,'') AS MINVE, ISNULL(O.NO_PARTE,'') AS N_PARTE, TIPO_ELE, ISNULL(TIEMPO_SER, '') AS SERV,
                ISNULL(TIEMPO_REAL, '') AS REAL1, ISNULL(TIPO,0) AS TIPO_I, ISNULL(O.STATUS, '-') AS ST, ISNULL(CVE_PROV,'') AS CVE_FOLIO, 
                ISNULL(O.UUID,'') AS UID, CVE_ALM
                FROM GCORDEN_TRA_SER_EXT O
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = O.CVE_ART
                WHERE CVE_ORD = '" & tCVE_ORD.Text & "' AND TIPO_PROD = 'P' AND O.STATUS <> 'C' AND ISNULL(CONTROL,'') = ''
                ORDER BY FECHAELAB"
            Try
                If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                    For k = 1 To Fg.Cols.Count - 1
                        Fg(0, k) = Fg(0, k) & " " & k
                    Next
                End If
            Catch ex As Exception
            End Try
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                If dr("CLAVE") <> "TOT" Then
                    DESCR = dr("DES")
                    '    Cant. Original   cant. MINVE

                    CANT = Math.Round(dr("CANTI") + dr("CANT_ENT"), 4)

                    'BACKUPTXT("ORDEN_CANT", dr("CLAVE") & "  ----    " & CANT & " , " & dr("CANTI") & " , " & dr("CANT_ENT") & " , " & dr("CANT_ENTR"))
                    'ESTAS ES LA EXTERNA TONTO CIRO
                    If CANT > 0 Then
                        '                 1                  2                 3                    4       
                        s = "" & vbTab & "0" & vbTab & dr("CLAVE") & vbTab & DESCR & vbTab & dr("CVE_ALM") & vbTab
                        '         5                 6               7                       8                           9          
                        s = s & CANT & vbTab & dr("COST") & vbTab & "" & vbTab & Math.Abs(dr("CANT_ENT")) & vbTab & dr("ST") & vbTab
                        '              10                      11                                12   
                        s = s & (CANT * dr("COST")) & vbTab & CANT & vbTab & IIf(dr("ST") = "M", "Mov. realizado", " ") & vbTab
                        '           13                  14                       15   
                        s = s & dr("UID") & vbTab & dr("MINVE") & vbTab & dr("CVE_FOLIO")

                        Fg.AddItem(s)
                    End If
                    Try
                        IMPORTE = IMPORTE + (CANT * dr("COST"))
                    Catch ex As Exception
                        Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If

            Loop
            dr.Close()
            LtTotal.Text = Format(IMPORTE, "###,###,##0.00")
            If Fg.Rows.Count > 1 Then
                Fg.Row = 1
            Else
                barGrabar.Enabled = False
            End If
        Catch ex As Exception
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim CVE_ART As String, NReg As Integer = 0
        Dim CVE_CPTO As Integer = 60, FACTOR_CON As Single = 1, SIGNO As Integer = -1, COSTEADO As String = "S", COSTO_PROM_INI As Single
        Dim COSTO_PROM_FIN As Single
        Dim DESDE_INVE As String = "S", MOV_ENLAZADO As Integer = 0, TIPO_DOC As String = "M", TIPO_PROD As String = "P", ExistProd As Boolean = False
        Dim CANT As Single, PREC As Single = 0, COSTO As Single = 0, CVE_VEND As String = "", REG_SERIE As Integer = 0, UNI_MED As String = ""
        Dim E_LTPD As String = ""
        Dim CVE_DOC As String, CLIENTE As String = "", COSTO_PROM As Single = 0, EXIST As Single = 0 : Dim ALMACEN As Integer = 0, NO_HAY_EXIST As Integer = 0
        Dim HayPart As Boolean, CVE_FOLIO As String, Continua As Boolean, UUID As String = "", NO_SE_GRABO As Boolean = True, Ano As String
        Dim ErrFolio As Boolean
        Dim cmd As New SqlCommand

        If MsgBox("Realmente desea generar los movimientos al inventario de la orden de trabajo?", vbYesNo) = vbNo Then
            Return
        End If
        Fg.FinishEditing()
        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Red
        NewStyle1.ForeColor = Color.White

        If CVE_CPTO_OT = 0 Then
            MsgBox("Por favor seleccione los conceptos en Parametros del sistema-Inventario")
            Return
        End If

        CVE_CPTO = CVE_CPTO_OT
        Try
            For k = 1 To Fg.Rows.Count - 1
                'Var15 = "EXTTOT"
                If PROC_OT = "TOTINT" Then
                    If Fg(k, 1) Then
                        PREC = PREC + 1
                    End If
                Else
                    If Fg(k, 1) Then
                        PREC = PREC + 1
                    End If
                End If
            Next
            If PREC = 0 Then
                MsgBox("Por favor seleccione al menos una partida")
                Return
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180
            CVE_DOC = "OT" & tCVE_ORD.Text & "/" & Format(Now.Hour, "00") & Format(Now.Second, "00") & Now.Day & Now.Month & Now.Year
            If CVE_DOC.Length > 20 Then
                CVE_DOC = CVE_DOC.Substring(0, 20)
            End If
            HayPart = False

            For k = 1 To Fg.Rows.Count - 1

                CVE_FOLIO = ""
                CANT = Fg(k, 5)
                CVE_ART = Fg(k, 2)
                PREC = Fg(k, 6)

                Try
                    UUID = Fg(k, 13)
                    CVE_FOLIO = Fg(k, 15)
                Catch ex As Exception
                    Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try


                If CVE_ART.Trim.Length > 0 And CANT > 0 And Fg(k, 1) And UUID.Trim.Length > 0 Then
                    NReg = NReg + 1
                    HayPart = True
                    If Not Valida_Conexion() Then
                    End If
                    EXIST = 0
                    Try
                        If PROC_OT = "TOTEXT" Then
                            Try
                                If IsNumeric(Fg(k, 4)) Then
                                    ALMACEN = Fg(k, 4)
                                Else
                                    ALMACEN = 1
                                End If
                            Catch ex As Exception
                                ALMACEN = Fg(k, 4)
                            End Try
                        Else
                            ALMACEN = 1
                        End If

                        If ALMACEN = 0 Then ALMACEN = 1

                        COSTO_PROM_INI = COSTO_PROM
                        COSTO_PROM_FIN = COSTO_PROM
                    Catch ex As Exception
                        Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    If MULTIALMACEN = 1 Then
                        Try
                            SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE
                                FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        UNI_MED = dr2("UNI_MED")
                                        COSTO = dr2("ULT_COSTO")
                                        COSTO_PROM = dr2("COSTO_PROM")
                                        TIPO_PROD = dr2("TIPO_ELE")
                                    End If
                                End Using
                            End Using

                            SQL = "SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM  = " & ALMACEN
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        EXIST = dr2("EXIST")
                                        ExistProd = True
                                    End If
                                End Using
                            End Using

                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        Try
                            SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE " &
                                "FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        EXIST = dr2("EXIST")
                                        UNI_MED = dr2("UNI_MED")
                                        COSTO = dr2("ULT_COSTO")
                                        COSTO_PROM = dr2("COSTO_PROM")
                                        TIPO_PROD = dr2("TIPO_ELE")
                                        ExistProd = True
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                    If TIPO_PROD = "P" And ExistProd And EXIST >= CANT Then

                        Continua = True
                        If Not Valida_Conexion() Then
                            Continua = False
                            NO_SE_GRABO = False
                        End If
                        If Continua Then
                            ErrFolio = False
                            Try
                                If CVE_FOLIO.Trim.Length = 0 Or CVE_FOLIO = "-" Then
                                    CVE_FOLIO = GET_CVE_FOLIO()
                                    If CVE_FOLIO.Trim.Length = 0 Or CVE_FOLIO = "-" Then

                                        Try
                                            Ano = DateTime.Now.Year.ToString
                                            Ano = Ano.Substring(Ano.Length - 1, 1)
                                            CVE_FOLIO = Ano & Format(DateTime.Now.Month, "00") & Format(DateTime.Now.Day, "00") & Format(DateTime.Now.Hour, "00") & Format(DateTime.Now.Minute, "00")
                                        Catch ex As Exception
                                            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                ErrFolio = True
                            End Try

                            If ErrFolio Then
                                Try
                                    Ano = DateTime.Now.Year.ToString
                                    Ano = Ano.Substring(Ano.Length - 1, 1)
                                    CVE_FOLIO = Ano & Format(DateTime.Now.Month, "00") & Format(DateTime.Now.Day, "00") & Format(DateTime.Now.Hour, "00") & Format(DateTime.Now.Minute, "00")
                                Catch ex As Exception
                                    Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If

                            ErrFolio = False
                            Try '- TERMINA INSERT INTO MINVE               - TERMINA INSERT INTO MINVE

                                For j = 1 To 5
                                    SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'M', HORA2 = 'MINVE', CVE_PROV = '" & CVE_FOLIO & "' WHERE UUID = '" & UUID & "'"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery.ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            ErrFolio = True
                                            Exit For
                                        End If
                                    End If
                                    If Not Valida_Conexion() Then
                                    End If
                                Next
                            Catch ex As Exception
                                Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                'MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                ErrFolio = True
                            End Try

                            If ErrFolio Then
                                Try
                                    If MULTIALMACEN = 1 Then
                                        SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT &
                                            " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN &
                                            " If @@ROWCOUNT = 0
                                            INSERT INTO MULT" & Empresa & " (CVE_ART, CVE_ALM, STATUS, CTRL_ALM,
                                            EXIST, STOCK_MIN, STOCK_MAX, COMP_X_REC, UUID, VERSION_SINC) VALUES('" & CVE_ART & "','" & ALMACEN & "','A','','" &
                                            CANT & "', 0, 0, 0, NEWID(), GETDATE())"
                                        cmd.CommandText = SQL
                                        returnValue = cmd.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
                                    Bitacora("170. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                End Try
                                Continua = True
                                Try
                                    SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) - " & CANT & " WHERE CVE_ART = '" & CVE_ART & "'"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery.ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then

                                        End If
                                    End If
                                Catch ex As Exception
                                    Continua = False
                                    Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, 
                                        REFER, CLAVE_CLPV, VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G,
                                        EXISTENCIA, CVE_FOLIO, TIPO_PROD, FACTOR_CON, FECHAELAB, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN,
                                        DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) VALUES('" & CVE_ART & "','" & ALMACEN & "'," &
                                        "(SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" &
                                        CVE_CPTO & "',CONVERT(varchar, GETDATE(), 112),'" & TIPO_DOC & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" &
                                        CANT & "','" & CANT & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                                        "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                                    If MULTIALMACEN = 1 Then
                                        'EXISTENCIA
                                        SQL = SQL & "ISNULL((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN & "),0),'"
                                    Else
                                        SQL = SQL & "ISNULL((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),0),'"  'EXISTENCIA
                                    End If 'CVE_FOLIO
                                    SQL = SQL & CVE_FOLIO & "','" & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),'" & SIGNO & "','" & COSTEADO & "','" &
                                        COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" & COSTO_PROM & "')"

                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery.ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            NO_HAY_EXIST = NO_HAY_EXIST + 1
                                        End If
                                    End If
                                    Try
                                        Fg(k, 5) = Fg(k, 5) - CANT
                                        Fg(k, 1) = False
                                    Catch ex As Exception
                                    End Try

                                    Try
                                        SQL = "UPDATE TBLCONTROL" & Empresa & " SET 
                                            ULT_CVE = (SELECT ISNULL(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) 
                                            FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
                                        cmd.CommandText = SQL
                                        returnValue = cmd.ExecuteNonQuery.ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    Catch ex As Exception
                                        Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                    GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, COSTO, "M", "Generacion de movimiento al inventario " &
                                               "Referencia : " & CVE_DOC & " articulo " & CVE_ART & " Cantidad " & CANT & "  FOLIO  " & CVE_FOLIO)
                                Catch ex As Exception
                                    Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Else
                                BACKUPTXT("FALLAS ORD", SQL)
                            End If
                        Else
                            Fg.Rows(k).Style = NewStyle1
                        End If
                    Else
                        Fg(k, 0) = "EI"
                        Fg(k, 16) = "Existencia " & EXIST
                    End If
                End If
            Next

            If NReg = 0 Then
                MsgBox("No se encontraron partidas a procesar")
            Else
                If NO_HAY_EXIST > 0 Then
                    ImprimirOrden(CVE_DOC)
                Else
                    MsgBox("Algunas partidas no hay existencia suficiente")
                End If
                If Not NO_SE_GRABO Then
                    MsgBox("Algunas partidas NO se leS genero el movimiento al inventario, por favor vuelva a intentarlo")
                End If
            End If
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function BUSCA_CVE_FOLIO_VIA_UUID(fUUID As String) As String
        Dim CVE_FOL As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_PROV FROM GCORDEN_TRA_SER_EXT WHERE UUID = '" & fUUID & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_FOL = dr.ReadNullAsEmptyString("CVE_PROV")
                    End If
                End Using
            End Using
            Return CVE_FOL
        Catch ex As Exception
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("270. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_FOL
        End Try
    End Function
    Private Sub barReimpresion_Click(sender As Object, e As EventArgs) Handles barReimpresion.Click
        ImprimirOrden(tCVE_ORD.Text)
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Sub ImprimirOrden(fCVE_ORD As String)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            Select Case Empresa
                Case "01"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "02"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE02.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "03"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE03.mrt"
                    If Not File.Exists(ARCHIVO_MRT & "") Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "04"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE04.mrt"
                    If Not File.Exists(ARCHIVO_MRT & "") Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "05"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE05.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "06"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE06.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "07"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE07.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "08"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE08.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "09"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE09.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "10"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE10.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "11"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE11.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "12"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE12.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "13"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE13.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "14"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE14.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "15"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE15.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "16"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE16.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "17"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE17.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "18"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE18.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "19"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE19.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "20"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE20.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "21"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE21.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "22"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE22.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case Else
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
            End Select
            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.Item("REFER") = fCVE_ORD

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If Fg(e.Row, 2) = "TOT" Then
                    e.Cancel = True
                    Return
                End If

                If FG_NOT Then
                    If e.Col <> 1 And e.Col <> 5 Then
                        e.Cancel = True
                    End If
                Else
                    e.Cancel = True
                End If

            End If
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If e.Col = 5 Then
                If Val(Fg.Editor.Text) > Fg(e.Row, 11) Then
                    MessageBox.Show("La cantidad no puede ser mayor a la original")
                    Fg.Editor.Text = Fg(e.Row, 11)
                    'e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("510. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("510. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 Then
                If FG_NOT Then
                    If Fg.Col = 5 Then
                        Fg.StartEditing()
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("520. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_LeaveCell(sender As Object, e As EventArgs) Handles Fg.LeaveCell
        Try
            Fg.FinishEditing()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barKardex_Click(sender As Object, e As EventArgs) Handles barKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 2)
                Var5 = ""
                Try
                    Var5 = Fg(Fg.Row, 3)
                Catch ex As Exception
                End Try
                frmKardex.ShowDialog()
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmMovsInvOT_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Focus()
        Me.Select()
    End Sub

End Class
