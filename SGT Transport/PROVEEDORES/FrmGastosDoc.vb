Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmGastosDoc
    Dim CADENA As String
    Dim TIPO_COMPRA_LOCAL As String
    Dim N_TOP As String = " TOP 2000 "
    Private CVE_ART_RNBDO As String
    Private CVE_ART_NUEVAS As String

    Private CVE_ART_REPARA As String

    Private ACTIVAR_RENOVADO As Integer = 0
    Private ACTIVAR_LLANTAS_NUEVAS As Integer = 0
    Private CVE_CPTO_RENOVADO As Integer = 0
    Private CVE_CPTO_RENOVADO_ENT As Integer = 0

    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1

        Me.ResumeLayout()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub CARGAR_DATOS1()
        Me.WindowState = FormWindowState.Maximized
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With
        Try
            SplitM.BorderWidth = 1
            SplitM.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill

            F1.Value = Date.Today
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            TIPO_COMPRA_LOCAL = TIPO_COMPRA

            BarXML.Visible = False
            LtCompras.Text = "Gastos"
            BarXML.Visible = True

            CARGA_PARAM_INVENT()

            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 50
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            DERECHOS()

            'CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "' ORDER BY FECHA_DOC DESC"
            TITULOS()

            CADENA = "  ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmGastosDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Dim ThemeLocal As String = "VS2013Blue"
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeLocal, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            'SET_THEME(Me, ThemeLocal)
            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        Catch ex As Exception
        End Try

    End Sub
    Sub DERECHOS()
        Dim z As Integer = 0

        If Not pwPoder Then

            Try
                barNueva.Visible = False
                barModificar.Visible = False
                barCancelar.Visible = False
            Catch ex As Exception
            End Try

            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 70100 AND CLAVE < 70500"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 70101
                                    barNueva.Visible = True
                                Case 70130
                                    barModificar.Visible = True
                                Case 70160
                                    barCancelar.Visible = True
                            End Select
                            z = z + 1
                        End While
                    End Using
                End Using
                If z = 0 Then
                    barNueva.Visible = True
                    barModificar.Visible = True
                    barCancelar.Visible = True
                End If
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(CVE_ART_RNBDO,'') AS ART_RBDO, ISNULL(CVE_ART_REPARA,'') AS ART_REPARA, 
                ISNULL(CVE_CPTO_RENOVADO,0) AS CVE_CPTO_REN, ISNULL(CVE_CPTO_RENOVADO_ENT,0) AS CVE_CPTO_REN_ENT
                FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                CVE_ART_RNBDO = dr("ART_RBDO")
                CVE_ART_REPARA = dr("ART_REPARA")

                CVE_CPTO_RENOVADO = dr("CVE_CPTO_REN")
                CVE_CPTO_RENOVADO_ENT = dr("CVE_CPTO_REN_ENT")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, S4 As Decimal = 0, S5 As Decimal = 0, S6 As Decimal = 0
        Fg.Redraw = False
        Fg.Rows.Count = 1

        Try
            SQL = "SELECT " & N_TOP & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, CASE WHEN C.STATUS = 'C' THEN 'Cancelada' ELSE 'Emitida' END AS ST, 
                C.SU_REFER, C.FECHA_DOC, C.FECHA_REC, C.FECHA_PAG, C.FECHA_CANCELA, C.CAN_TOT, C.IMP_TOT1, C.IMP_TOT2, C.IMP_TOT3, 
                C.IMP_TOT4, C.DES_TOT, C.DES_FIN, C.NUM_ALMA, C.FECHAELAB, C.IMPORTE, 
                CASE ISNULL(C.TIP_DOC_ANT,'') WHEN 'o' THEN 'Orden de compra' WHEN 'q' THEN 'Requsición' ELSE '' END AS TIPO_D_ANT, 
                ISNULL(C.DOC_ANT,'') AS DOCANT, 
                CASE ISNULL(C.TIP_DOC_SIG,'') WHEN 'o' THEN 'Orden de compra' WHEN 'q' THEN 'Requsición' ELSE '' END AS TIPO_D_SIG, 
                ISNULL(C.DOC_SIG,'') AS DOCSIG 
                FROM GCGASTOS C
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV " &
                CADENA

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE") & vbTab & dr("ST") & vbTab &
                                dr("SU_REFER") & vbTab & dr("FECHA_DOC") & vbTab & dr("FECHA_REC") & vbTab & dr("FECHA_PAG") & vbTab &
                                dr("FECHA_CANCELA") & vbTab & dr("CAN_TOT") & vbTab & dr("IMP_TOT1") & vbTab & dr("IMP_TOT2") & vbTab &
                                dr("IMP_TOT3") & vbTab & dr("IMP_TOT4") & vbTab & dr("IMPORTE") & dr("DES_TOT") & vbTab & dr("DES_FIN") & vbTab &
                                dr("NUM_ALMA") & vbTab & dr("FECHAELAB") & vbTab & dr("TIPO_D_ANT") & vbTab &
                                dr("DOCANT") & vbTab & dr("TIPO_D_SIG") & vbTab & dr("DOCSIG"))
                            S1 += dr("CAN_TOT")
                            S2 += dr("IMP_TOT1")
                            S3 += dr("IMP_TOT2")
                            S4 += dr("IMP_TOT3")
                            S5 += dr("IMP_TOT4")
                            S6 += dr("IMPORTE")
                        End While
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                "" & vbTab & S1 & vbTab & S2 & vbTab & S3 & vbTab & S4 & vbTab & S5 & vbTab & S6)
                    End Using
                End Using
            Catch SQLex As SqlException
                Dim SSS As SqlError, Sqlcadena As String = ""
                For Each SSS In SQLex.Errors
                    Sqlcadena += SSS.Message & vbNewLine
                Next
                BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()
            N_TOP = " TOP 1000 "
            LtNUm.Text = "Registros : " & Fg.Rows.Count - 1

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmGastosDoc_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Gastos")
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        tBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "' ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        tBox.Text = ""
        dt = dt.AddDays(-1)
        N_TOP = ""
        CADENA = " WHERE FECHA_DOC = '" & FSQL(dt) & "' ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        tBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        tBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        tBox.Text = ""
        N_TOP = ""
        CADENA = " ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BarNueva_Click(sender As Object, e As EventArgs) Handles barNueva.Click
        Var17 = ""
        Var11 = "nueva"
        Var12 = ""
        Var13 = ""

        Try
            If FORM_IS_OPEN("FrmGastos") Then
                FrmGastos.Close()
                FrmGastos.Dispose()
            Else
                If OPEN_TAB("FrmGastos") Then
                    FrmGastos.Close()
                    FrmGastos.Dispose()
                End If
            End If
        Catch ex As Exception
        End Try


        CREA_TAB(FrmGastos, "Captura gastos")
    End Sub
    Private Sub BarModificar_Click(sender As Object, e As EventArgs) Handles barModificar.Click
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 4) = "C" Then
                    Var6 = "C"
                Else
                    Var6 = ""
                End If
                Var11 = "edit"
                Var12 = Fg(Fg.Row, 1)
                Var13 = Fg(Fg.Row, 23) 'DOCUMENTO SIGUIENTE
                Var14 = Fg(Fg.Row, 20) 'DOCUMENTO ANTERIOR
                Var17 = ""
                If Var12.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione un documento")
                    Return
                End If

                CloseTab("Captura gastos")

                CREA_TAB(FrmGastos, "Captura gastos")
            Else
                MsgBox("Por favor seleccione un documento")
            End If
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles barCancelar.Click
        Try
            Dim EXIST_G As String, CADENA_EXIST As String, CVE_DOC As String, PAR_COMP_ANT As Integer
            'MOVSINV
            Dim NUM_ALM As Integer, CVE_CPTO As Integer, TIPO_DOC As String, REFER As String, CLAVE_CLPV As String, CVE_VEND As String, CANT_COST As Single
            Dim COSTO As Single, PREC As Decimal, AFEC_COI As String, FACTOR_CON As Single, CVE_FOLIO As String, SIGNO As Integer, COSTEADO As String
            Dim COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single, DESDE_INVE As String, MOV_ENLAZADO As Integer, CVE_OBS As Long
            Dim REG_SERIE As Integer, UNI_VENTA As String, E_LTPD As Integer, TIPO_PROD As String, CTLPOL As Integer
            Dim DOC_SIG As String = "", TIP_DOC_SIG As String = "", TIP_DOC_ANT As String = "", DOC_ANT As String = "", CANT As Decimal
            Dim NUM_MOV As Long, CVE_ART As String, EXISTEN_ABONOS As Boolean = False


            Dim cmd As New SqlCommand
            Dim cmd2 As New SqlCommand
            Dim dr As SqlDataReader


            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120
            cmd2.Connection = cnSAE
            cmd2.CommandTimeout = 120
            'FIN MOVSINV

            If Fg.Row <= 0 Then
                MsgBox("Por favor seleccione una gasto")
                Return
            End If

            CVE_DOC = Fg(Fg.Row, 1)
            CLAVE_CLPV = Fg(Fg.Row, 2)
            Try
                If Not IsNothing(Fg(Fg.Row, 23)) Then
                    DOC_SIG = Fg(Fg.Row, 23)
                Else
                    DOC_SIG = ""
                End If
            Catch ex As Exception
            End Try
            Try
                If Not IsNothing(Fg(Fg.Row, 22)) Then
                    Select Case Fg(Fg.Row, 22)
                        Case "Orden de compra"
                            TIP_DOC_SIG = "O"
                        Case "Requsición"
                            TIP_DOC_SIG = "Q"
                    End Select
                Else
                    TIP_DOC_SIG = ""
                End If
            Catch ex As Exception
                Bitacora("108. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                Select Case Fg(Fg.Row, 20).ToString
                    Case "Orden de compra"
                        TIP_DOC_ANT = "O"
                    Case "Requsición"
                        TIP_DOC_ANT = "Q"
                End Select
            Catch ex As Exception
                Bitacora("109. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If Not IsNothing(Fg(Fg.Row, 21)) Then
                DOC_ANT = Fg(Fg.Row, 21)
            Else
                DOC_ANT = ""
            End If

            If DOC_SIG.Trim.Length > 0 Then
                MsgBox("El folio " & CVE_DOC & " se le genero el documento " & DOC_SIG & " tipo doc " & TIP_DOC_SIG & " no se puede cancelar")
                Exit Sub
            End If

            If MsgBox("Realmente desea cancelar documento " & CVE_DOC & "?", vbYesNo) = vbNo Then
                Exit Sub
            End If

            If Fg(Fg.Row, 4) = "C" Then
                MsgBox("El documento ya se encuentra cancelado")
                Exit Sub
            End If


            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT REFER FROM PAGA_DET" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                cmd3.CommandText = SQL
                Using dr3 As SqlDataReader = cmd3.ExecuteReader
                    If dr3.Read Then
                        EXISTEN_ABONOS = True
                    End If
                End Using
            End Using

            If EXISTEN_ABONOS Then
                MsgBox("El gasto tiene abonos, no es posible realizar la cancelación, verifique por favor")
                Return
            End If

            SQL = "UPDATE GCGASTOS SET STATUS = 'C', ENLAZADO = 'O', TIP_DOC_ANT = '', DOC_ANT = '', 
                 FECHA_CANCELA = CONVERT(varchar, GETDATE(), 112)
                 WHERE CVE_DOC = '" & CVE_DOC & "'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If


            SQL = "DELETE FROM PAGA_M" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
            cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If

                SQL = "DELETE FROM PAGA_DET" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If

            '====================================
            If TIP_DOC_ANT.Trim.Length > 0 Then
                SQL = "UPDATE GCGASTOS SET ENLAZADO = 'O', DOC_SIG = '', TIP_DOC_SIG = '' WHERE DOC_SIG = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End If
            '====================================================

            SQL = "SELECT P.CVE_ART, P.NUM_ALM, P.CANT, P.PREC, P.COST, P.UNI_VENTA, I.TIPO_ELE, P.NUM_PAR
                 FROM GCGASTOS_PART P
                 LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                 WHERE P.CVE_DOC = '" & CVE_DOC & "' AND I.TIPO_ELE = 'P'"
            cmd2.CommandText = SQL
            dr = cmd2.ExecuteReader
            Do While dr.Read

                NUM_ALM = dr.ReadNullAsEmptyInteger("NUM_ALM")
                CANT = dr.ReadNullAsEmptyDecimal("CANT")
                CVE_ART = dr.ReadNullAsEmptyString("CVE_ART")
                COSTO = dr.ReadNullAsEmptyDecimal("COST")
                UNI_VENTA = dr.ReadNullAsEmptyString("UNI_VENTA")
                PREC = dr.ReadNullAsEmptyDecimal("PREC")
                Try
                    If DOC_ANT.Trim.Length > 0 Then

                        PAR_COMP_ANT = BUSCAR_PARTIDA_DOCTOSIGC(CVE_DOC, DOC_ANT, dr("NUM_PAR"))

                        If PAR_COMP_ANT > 0 Then
                            SQL = "UPDATE GCGASTOS_PART SET PXR = " & CANT & " WHERE
                                 CVE_DOC = '" & DOC_ANT & "' AND NUM_PAR = " & PAR_COMP_ANT
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("109. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                If dr("TIPO_ELE") = "P" Then

                    SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) - " & CANT & " WHERE CVE_ART = '" & CVE_ART & "'"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If

                    If MULTIALMACEN = 1 Then
                        SQL = "UPDATE MULT" & Empresa & " SET EXIST = ISNULL(EXIST,0) - " & CANT & " 
                            WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End If

                    'MOVSINV
                    CVE_CPTO = 57 : TIPO_DOC = "c" : REFER = CVE_DOC : CANT_COST = COSTO * CANT : AFEC_COI = "" : CVE_OBS = 0 : REG_SERIE = 0
                    E_LTPD = 0 : TIPO_PROD = "P" : FACTOR_CON = 1 : CTLPOL = 0 : SIGNO = -1 : COSTEADO = "S"

                    COSTO_PROM_INI = CANT_COST
                    COSTO_PROM_FIN = CANT_COST : DESDE_INVE = "S" : MOV_ENLAZADO = 0 : CVE_VEND = "" : CVE_FOLIO = ""

                    EXIST_G = "ISNULL((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),0)" 'EXIST_G

                    If MULTIALMACEN = 1 Then
                        CADENA_EXIST = "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM & "),0)"   'EXISTENCIA
                    Else
                        CADENA_EXIST = "COALESCE((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),0)"  'EXISTENCIA
                    End If

                    SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV,
                        VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON,
                        FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO) 
                        OUTPUT Inserted.NUM_MOV VALUES('" &
                        CVE_ART & "','" & NUM_ALM & "',(SELECT COALESCE(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" & CVE_CPTO &
                        "',Convert(varchar, GETDATE(), 112),'" & TIPO_COMPRA_LOCAL & "','" & REFER & "','" & CLAVE_CLPV & "','" &
                        CVE_VEND & "','" & CANT & "','" & CANT_COST & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" &
                        UNI_VENTA & "','" & E_LTPD & "'," & EXIST_G & "," & CADENA_EXIST & ",'" & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE()" &
                        ",(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" &
                        SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "')"
                    Try
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteScalar().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                        Try
                            NUM_MOV = returnValue
                        Catch ex As Exception
                        End Try
                    Catch ex As Exception
                        Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Loop
            dr.Close()

            'TERMINA LA CANCELACION DE LAS PARTIDAS DE LA COMPRA
            'TERMINA LA CANCELACION DE LAS PARTIDAS DE LA COMPRA
            'TERMINA LA CANCELACION DE LAS PARTIDAS DE LA COMPRA

            N_TOP = " TOP 1000 "
            CADENA = "  ORDER BY FECHAELAB DESC"
            DESPLEGAR()
            MsgBox("El documento se cancelo satisfactoriamente")
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function BUSCAR_PARTIDA_DOCTOSIGC(fCVE_DOC As String, fDOC_ANT As String, fNUM_PAR As Integer) As Integer
        Dim PARTIDA As Integer = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT PART_E FROM DOCTOSIGC" & Empresa & " WHERE 
                    CVE_DOC = '" & fCVE_DOC & "' AND CVE_DOC_E = '" & fDOC_ANT & "' AND PARTIDA = " & fNUM_PAR
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        PARTIDA = dr("PART_E")
                    End If
                End Using
            End Using
            Return PARTIDA
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            Return PARTIDA
        End Try
    End Function

    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            CADENA = "WHERE (UPPER(CVE_DOC) LIKE '%" & tBox.Text & "%' OR CVE_CLPV LIKE '%" & tBox.Text & "%' OR 
                    UPPER(NOMBRE) LIKE '%" & tBox.Text & "%') ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, 1))
        Catch ex As Exception
        End Try
        Try
            barModificar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarXML_Click(sender As Object, e As EventArgs) Handles BarXML.Click

        Var17 = "G"
        CREA_TAB(frmComprasXML, "Documentos XML")
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        Try
            N_TOP = " TOP 1000 "
            CADENA = " ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        tBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, LtCompras.Text)
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub TITULOS()
        Try
            Fg.Cols.Count = 22

            Fg(0, 1) = "Documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Proveedor"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Estatus"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Su refer."
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Fecha"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg(0, 7) = "Fecha rec."
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(DateTime)

            Fg(0, 8) = "Fecha pag."
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(DateTime)

            Fg(0, 9) = "Fecha cancelada"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(DateTime)

            Fg(0, 10) = "Sub. tottal"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "IEPS"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Retención ISR"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Retención IVA"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "IVA"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Importe"
            Dim c19 As Column = Fg.Cols(15)
            c19.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Descuento"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "Des. fin."
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "Almacen"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(Int32)

            Fg(0, 19) = "Fecha elab."
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(DateTime)

            Fg(0, 20) = "Tipo documento anterior"
            Dim c20 As Column = Fg.Cols(20)
            c20.DataType = GetType(String)

            Fg(0, 21) = "Documento anterior"
            Dim c21 As Column = Fg.Cols(21)
            c21.DataType = GetType(String)

            Fg(0, 22) = "Tipo documento siguiente"
            Dim c22 As Column = Fg.Cols(22)
            c22.DataType = GetType(String)

            Fg(0, 23) = "Documento siguiente"
            Dim c23 As Column = Fg.Cols(23)
            c23.DataType = GetType(String)

            Fg.Cols(9).Width = 80
            Fg.Cols(20).Width = 100
            'Fg.Cols(21).Width = 130
            'Fg.Cols(23).Width = 130
            Fg.Cols(22).Width = 100

            Fg.Cols(9).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(20).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(22).TextAlign = TextAlignEnum.CenterCenter

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

            Dim cs2 As CellStyle
            cs2 = Fg.Styles.Add("CS2")
            cs2.BackColor = Color.Red
            cs2.ForeColor = Color.White
            cs2.Font = New Font("Tahoma", 9, FontStyle.Bold)

            Select Case Fg(e.Row, 4)
                Case "Cancelada"
                    Fg.SetCellStyle(e.Row, 3, cs2)
                    Fg.SetCellStyle(e.Row, 4, cs2)
                    Fg.SetCellStyle(e.Row, 9, cs2)
            End Select

        End If
    End Sub
End Class
