Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.IO
Public Class frmOrdenDeTrabajoAE
    Private ENTRA As Boolean
    Private ENTRA_KEY As Boolean
    Private REMOVE_ROW As Integer
    Private ENTRA_BTN As Boolean
    Private ENTRA_FALLAS As Boolean
    Private PERMITIR_UNIDAD As Integer = 0
    Private SOLICITAR_ACT_MANTE As Integer = 0
    Private r_ As Integer
    Private c_ As Integer

    Private SEGONE As Boolean
    Private _myEditor As MyEditorOT

    Private Sub FrmOrdenDeTrabajoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        SEGONE = True
        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        Tab1.Height = Me.Height - Tab1.Height + 100
        Tab1.Width = Me.Width - 50
        Fg.Width = Me.Width - 100

        tCVE_ORD.MaxLength = 10
        tEstatus.MaxLength = 80
        tCVE_SER.MaxLength = 10
        tCVE_UNI.MaxLength = 10
        tCVE_TIPO.MaxLength = 10
        tLUGAR_REP.MaxLength = 50
        tNOTA.MaxLength = 100

        ENTRA_FALLAS = False
        ENTRA = False
        Fg.Cols(2).Width = 20
        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                  "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "")
        Fg.Row = 1
        Fg.Col = 1

        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.WordWrap = True

        FgF.Rows(0).Height = 40
        FgF.Rows(0).Style = NewStyle1
        FgF.Cols(1).Style = NewStyle1
        FgF.Cols(3).Style = NewStyle1
        FgF.Cols(4).Style = NewStyle1


        FgM.Cols(2).Width = 20
        FgF.Cols(2).Width = 20
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.WindowState = FormWindowState.Maximized

        If Not Valida_Conexion() Then
            Return
        End If

        If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
            'For k = 1 To Fg.Rows.Count - 1
            'Fg(0, k) = Fg(0, k) & " " & k
            'Next
        End If

        Try
            SQL = "SELECT ISNULL(PERMITIR_UNIDAD,0) AS P_UNIDAD, ISNULL(SOLICITAR_ACT_MANTE,0) AS SOL_ACT_MAN FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        PERMITIR_UNIDAD = dr("P_UNIDAD")
                        SOLICITAR_ACT_MANTE = dr("SOL_ACT_MAN")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If SOLICITAR_ACT_MANTE = 0 Then
                btnServicios.Visible = False
                tCVE_SER.Visible = False
                Lt.Visible = False
            Else
                btnServicios.Visible = True
                tCVE_SER.Visible = True
                Lt.Visible = True
            End If
        Catch ex As Exception
        End Try

        CARGA_PARAM_INVENT()

        'For k = 1 To Fg.Cols.Count - 1
        'Fg(0, k) = Fg(0, k) & "(" & k & ")"
        ' Next
        If MULTIALMACEN = 0 Then
            Fg.Cols(8).Visible = False
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim Cadena As String

                cmd.Connection = cnSAE
                SQL = "SELECT * FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                Cadena = ""
                Do While dr.Read
                    Cadena = Cadena & Format(dr("CVE_ALM"), "00") & " " & dr("DESCR") & "|"
                Loop
                dr.Close()
                Fg.Cols(8).ComboList = Cadena
            Catch ex As Exception
                Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        ENTRA_KEY = True
        REMOVE_ROW = 0
        ENTRA_BTN = True
        LIMPIAR()

        If Var1 = "Nuevo" Then
            Try
                tCVE_ORD.Text = GET_MAX("GCORDEN_TRABAJO", "CVE_ORD")
                tCVE_ORD.Enabled = False
                tEstatus.Text = "Captura"
                tCVE_SER.Select()

            Catch ex As Exception
                MsgBox("32. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("32. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT O.CVE_ORD, O.ESTATUS, O.FECHA, O.CVE_SER, O.TIPO_SERVICIO, ISNULL(O.TIPO_EXTRA, 0) AS T_EXTRA, O.CVE_UNI, O.CVE_TIPO, O.CVE_OPER, " &
                    "O.CVE_PROV, O.FACTURA, O.VIDA_REP_ANO, O.VIDA_REP_KM, O.LUGAR_REP, O.NOTA, O.CVE_OBS, OB.DESCR AS OBS_STR " &
                    "FROM GCORDEN_TRABAJO O " &
                    "LEFT JOIN GCOBS OB ON OB.CVE_OBS = O.CVE_OBS " &
                    "WHERE CVE_ORD = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_ORD.Text = dr("CVE_ORD").ToString
                    F1.Value = dr("FECHA").ToString
                    tCVE_SER.Text = dr("CVE_SER").ToString
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
                    tEstatus.Text = dr("ESTATUS").ToString
                    tLUGAR_REP.Text = dr("LUGAR_REP").ToString
                    tNOTA.Text = dr("NOTA").ToString

                    tOBSER.Text = dr("OBS_STR").ToString
                    tOBSER.Tag = dr("CVE_OBS").ToString

                    If tEstatus.Text = "FINALIZADA" Then
                        FgF.Enabled = False
                        SET_ALL_CONTROL_READ_AND_ENABLED(Panel1)
                        SET_ALL_CONTROL_READ_AND_ENABLED(Panel2)
                        'Panel1.Enabled = False
                        'Panel2.Enabled = False
                    End If

                    CARGAR_SERVICIOS()
                    CARGAR_MECANICOS()
                    CARGAR_FALLAS()

                End If
                dr.Close()

                tCVE_ORD.Enabled = False
                tCVE_SER.Select()

            Catch ex As Exception
                MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        ENTRA = True
        ENTRA_FALLAS = True

        _myEditor = New MyEditorOT(Fg, MULTIALMACEN)

    End Sub

    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                AFEC_TABLA_INVE = dr("AFE_TAB_INV")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_SERVICIOS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim DESCR As String, ALMA As String, IMPORTE As Decimal = 0

            cmd.Connection = cnSAE

            SQL = "SELECT CVE_ORD, ISNULL(O.CVE_ART,'') AS ARTICULO, ISNULL(CVE_PROV,'') AS PROV, NOMBRE, ISNULL(I.DESCR,'') AS DES, " &
                "ISNULL(O.CANT,0) AS CANTI, ISNULL(NUM_ALM,1) AS ALMACEN, " &
                "ISNULL((SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = O.CVE_ART),'') AS N_PARTE, " &
                "ISNULL(O.COSTO,'') AS COST, I.TIPO_ELE, ISNULL(O.UUID,'') AS UID " &
                "FROM GCORDEN_TRA_SER O " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = O.CVE_ART " &
                "LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = O.CVE_PROV " &
                "WHERE CVE_ORD = '" & tCVE_ORD.Text & "' ORDER BY FECHAELAB"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            If dr.HasRows Then
                Do While dr.Read
                    DESCR = dr("DES")
                    ALMA = dr("ALMACEN")
                    Fg.AddItem(IIf(dr("TIPO_ELE") = "S", "S", "") & vbTab & dr("ARTICULO") & vbTab & "" & vbTab & DESCR & vbTab & dr("N_PARTE") & vbTab &
                               dr("PROV") & vbTab & "" & vbTab & dr("NOMBRE") & vbTab & ALMA & vbTab & dr("CANTI") & vbTab &
                               dr("COST") & vbTab & dr("CANTI") * dr("COST") & vbTab & dr("TIPO_ELE") & vbTab & dr("UID"))
                    Try
                        IMPORTE = IMPORTE + (dr("CANTI") * dr("COST"))
                    Catch ex As Exception
                        Bitacora("42. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Loop
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                "0" & vbTab & "0" & vbTab & "0" & vbTab & "-" & vbTab & "-")
                LtTotal.Text = Format(IMPORTE, "###,###,##0.00")
            Else
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                "0" & vbTab & "0" & vbTab & "0" & vbTab & "-" & vbTab & "-")
            End If
            Fg.Col = 2
            Fg.Col = 1
            Fg.StartEditing()
            dr.Close()
        Catch ex As Exception
            Bitacora("46. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("46. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULAR_IMPORTES()
        Try
            Dim SUMA As Decimal = 0
            Fg.FinishEditing()

            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Trim.Length > 0 Then
                    SUMA = SUMA + (Fg(k, 9) * Fg(k, 10))
                End If
            Next
            LtTotal.Text = Format(SUMA, "###,###,##0.00")
        Catch ex As Exception

        End Try
    End Sub
    Sub CARGAR_MECANICOS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT CVE_ORD, ISNULL(O.CVE_MEC,'') AS CLAVE, ISNULL(M.DESCR,'') AS DES " &
                "FROM GCORDEN_TRA_MEC O " &
                "LEFT JOIN GCMECANICOS M ON M.CVE_MEC = O.CVE_MEC " &
                "WHERE CVE_ORD = '" & tCVE_ORD.Text & "' ORDER BY CVE_ORD"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            FgM.Rows.Count = 1
            If dr.HasRows Then
                Do While dr.Read
                    FgM.AddItem("" & vbTab & dr("CLAVE") & vbTab & "" & vbTab & dr("DES"))
                    FgM.Rows(FgM.Rows.Count - 1).Height = 30
                Loop
            Else
                FgM.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                FgM.Rows(FgM.Rows.Count - 1).Height = 30
                FgM.Col = 1
                FgM.StartEditing()
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox("56. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("56. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_FALLAS()
        Try
            Dim FALLA As String

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            'SQL = "SELECT CVE_FALLA, STATUS, CVE_SUC, FECHA, CVE_UNI, CVE_OPER, CVE_CLAS, DESCR_FALLA FROM GCREPORTE_FALLAS"
            SQL = "SELECT P.CVE_ORD, O.CVE_UNI, ISNULL(O.CVE_FALLA,'') AS CLAVE, O.NO_PARTIDA, ISNULL(P.DESCR_FALLA,'') AS DES, U.DESCR AS DESCR_UNI " &
                "FROM GCORDEN_TRA_RFA O " &
                "LEFT JOIN GCREPORTE_FALLAS F ON F.CVE_FALLA = O.CVE_FALLA " &
                "LEFT JOIN GCREPORTE_FALLAS_PAR P ON P.CVE_FALLA = O.CVE_FALLA AND P.NO_PARTIDA = O.NO_PARTIDA " &
                "LEFT JOIN GCUNIDADES U ON U.CLAVE = P.CVE_UNI " &
                "WHERE O.CVE_ORD = '" & tCVE_ORD.Text & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            FgF.Rows.Count = 1
            If dr.HasRows Then
                Do While dr.Read
                    FALLA = dr("CLAVE")
                    If FALLA.Trim.Length > 0 Then
                        FgF.AddItem("" & vbTab & FALLA & vbTab & "" & vbTab & dr("DESCR_UNI") & vbTab & dr("DES") & vbTab & dr("CVE_ORD") & vbTab & dr("CVE_UNI") & vbTab & dr("NO_PARTIDA"))
                        FgF.Rows(FgF.Rows.Count - 1).Height = 40
                    End If
                Loop
            Else
                FgF.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                FgF.Rows(FgF.Rows.Count - 1).Height = 40
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox("66. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("66. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA_FALLAS = True
    End Sub
    Sub LIMPIAR()
        Try
            tCVE_ORD.Text = ""
            F1.Value = Now
            tCVE_SER.Text = ""
            radPreventivo.Checked = True
            radCorrectivo.Checked = False
            tCVE_UNI.Text = ""
            tCVE_TIPO.Text = ""
            tLUGAR_REP.Text = ""
            tNOTA.Text = ""

            ENTRA = False

            Fg.Rows.Count = 1
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                "0" & vbTab & "0" & vbTab & "0" & vbTab & "-" & vbTab & "-")
            Fg.Rows(FgM.Rows.Count - 1).Height = 30
            FgM.Rows.Count = 1
            FgM.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
            FgM.Rows(FgM.Rows.Count - 1).Height = 30
            FgM.Row = FgM.Rows.Count - 1
            FgM.Col = 1

            FgF.Rows.Count = 1
            FgF.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
            FgF.Rows(FgF.Rows.Count - 1).Height = 40

            ENTRA = True

        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmOrdenDeTrabajoAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmOrdenDeTrabajoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_OBS As Long, Tipo_ser As Integer = 0
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If PERMITIR_UNIDAD = 0 Then
            Try
                If Not UNIDAD_ESTA_EN_MANTO_EXTERNO_BASE(tCVE_UNI.Text) Then
                    MsgBox("La unidad " & tCVE_UNI.Text & " no se encuentra en mantenimientio Externo ó base")
                    Return
                End If
            Catch ex As Exception

            End Try
        End If

        If radPreventivo.Checked Then
            Tipo_ser = 0
        Else
            If radCorrectivo.Checked Then
                Tipo_ser = 1
            Else
                Tipo_ser = 2
            End If
        End If
        Try
            If tOBSER.Text.Trim.Length > 0 Then
                If IsNumeric(tOBSER.Tag) Then
                    CVE_OBS = tOBSER.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tOBSER.Text & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & tOBSER.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End If
            End If

            tOBSER.Tag = CVE_OBS

        Catch ex As Exception
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "UPDATE GCORDEN_TRABAJO SET ESTATUS = @ESTATUS, FECHA = @FECHA, CVE_SER = @CVE_SER, TIPO_SERVICIO = @TIPO_SERVICIO, " &
            "TIPO_EXTRA = @TIPO_EXTRA, CVE_UNI = @CVE_UNI, CVE_TIPO = @CVE_TIPO, CVE_OPER = @CVE_OPER, " &
            "LUGAR_REP = @LUGAR_REP, NOTA = @NOTA " &
            "WHERE CVE_ORD = @CVE_ORD " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCORDEN_TRABAJO (CVE_ORD, STATUS, FECHA, CVE_SER, TIPO_SERVICIO, TIPO_EXTRA, CVE_UNI, CVE_TIPO, CVE_OPER, ESTATUS, " &
            "LUGAR_REP, NOTA, CVE_OBS) VALUES(@CVE_ORD, 'A', @FECHA, @CVE_SER, @TIPO_SERVICIO, @TIPO_EXTRA, @CVE_UNI, @CVE_TIPO, " &
            "@CVE_OPER, @ESTATUS, @LUGAR_REP, @NOTA, @CVE_OBS)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = tCVE_ORD.Text
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Text
            cmd.Parameters.Add("@CVE_SER", SqlDbType.VarChar).Value = tCVE_SER.Text
            cmd.Parameters.Add("@TIPO_SERVICIO", SqlDbType.SmallInt).Value = Tipo_ser
            cmd.Parameters.Add("@TIPO_EXTRA", SqlDbType.SmallInt).Value = IIf(radExtra.Checked, 1, 0)
            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Text
            cmd.Parameters.Add("@CVE_TIPO", SqlDbType.VarChar).Value = tCVE_TIPO.Text
            cmd.Parameters.Add("@CVE_OPER", SqlDbType.VarChar).Value = tCVE_OPER.Text
            cmd.Parameters.Add("@ESTATUS", SqlDbType.VarChar).Value = tEstatus.Text
            cmd.Parameters.Add("@LUGAR_REP", SqlDbType.VarChar).Value = tLUGAR_REP.Text
            cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = tNOTA.Text
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    GRABAR_SERVICIOS()
                    GRABAR_MECANICOS()
                    GRABAR_FALLAS()
                    MsgBox("La orden de trabajo se grabo satisfactoriamente")
                    'ImprimirOrden(tCVE_ORD.Text)
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_SERVICIOS()
        Try
            Dim NUM_ALM As Integer
            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            SQL = "DELETE FROM GCORDEN_TRA_SER WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
            ENTRA = False
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Trim.Length > 0 Then
                    Try
                        If MULTIALMACEN = 1 Then
                            If String.IsNullOrEmpty(Fg(k, 8).ToString.Substring(0, 2)) Then
                                NUM_ALM = 1
                            Else
                                NUM_ALM = Fg(k, 8).ToString.Substring(0, 2)
                            End If
                        Else
                            NUM_ALM = 1
                        End If
                    Catch ex As Exception
                        NUM_ALM = 1
                    End Try

                    SQL = "INSERT INTO GCORDEN_TRA_SER (CVE_ORD, CVE_ART, CVE_PROV, CANT, COSTO, NUM_ALM, IMPORTE, TIPO_ELE, FECHAELAB, UUID) " &
                        "VALUES (@CVE_ORD, @CVE_ART, @CVE_PROV, @CANT, @COSTO, @NUM_ALM, @IMPORTE, @TIPO_ELE, GETDATE(), NEWID())"
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = tCVE_ORD.Text
                        cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = Fg(k, 1)
                        cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = Fg(k, 5)
                        cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 9))
                        cmd.Parameters.Add("@COSTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 10))
                        cmd.Parameters.Add("@NUM_ALM", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(NUM_ALM)
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 11))
                        cmd.Parameters.Add("@TIPO_ELE", SqlDbType.VarChar).Value = Fg(k, 12)
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            ENTRA = True
        Catch ex As Exception
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_MECANICOS()
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            SQL = "DELETE FROM GCORDEN_TRA_MEC WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
            ENTRA = False
            For k = 1 To FgM.Rows.Count - 1

                If FgM(k, 1).ToString.Trim.Length > 0 Then
                    SQL = "INSERT INTO GCORDEN_TRA_MEC (CVE_ORD, CVE_MEC, FECHAELAB) VALUES (@CVE_ORD, @CVE_MEC, GETDATE())"
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = tCVE_ORD.Text
                        cmd.Parameters.Add("@CVE_MEC", SqlDbType.VarChar).Value = FgM(k, 1).ToString
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            ENTRA = True
        Catch ex As Exception
            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_FALLAS()
        Try
            Dim cmd As New SqlCommand
            Dim cmd2 As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd2.Connection = cnSAE

            SQL = "SELECT * FROM GCORDEN_TRA_RFA WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                Try
                    SQL = "UPDATE GCREPORTE_FALLAS_PAR SET CVE_ORD = '' WHERE CVE_FALLA = '" & dr("CVE_FALLA") & "' AND NO_PARTIDA = " & dr("NO_PARTIDA")
                    cmd2.CommandText = SQL
                    Try
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Catch ex As Exception
                    MsgBox("210. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Loop
            dr.Close()

            SQL = "DELETE FROM GCORDEN_TRA_RFA WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
            ENTRA = False
            ENTRA_FALLAS = False
            For k = 1 To FgF.Rows.Count - 1

                If FgF(k, 1).ToString.Trim.Length > 0 Then

                    SQL = "INSERT INTO GCORDEN_TRA_RFA (CVE_ORD, CVE_FALLA, CVE_UNI, NO_PARTIDA, FECHAELAB) VALUES (@CVE_ORD, @CVE_FALLA, @CVE_UNI, @NO_PARTIDA, GETDATE())"
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = tCVE_ORD.Text
                        cmd.Parameters.Add("@CVE_FALLA", SqlDbType.VarChar).Value = FgF(k, 1).ToString
                        cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = FgF(k, 6).ToString
                        cmd.Parameters.Add("@NO_PARTIDA", SqlDbType.VarChar).Value = FgF(k, 7).ToString
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        'RUTINA GRABAR LA ORDEN DE TRABAJAO EN EL REPORTE DE FALLAS
                        SQL = "UPDATE GCREPORTE_FALLAS_PAR SET CVE_ORD = '" & tCVE_ORD.Text & "' WHERE " &
                            "CVE_FALLA = '" & FgF(k, 1).ToString & "' AND NO_PARTIDA = " & FgF(k, 7).ToString
                        cmd.CommandText = SQL
                        Try
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox("230. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("230. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Catch ex As Exception
                        MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            ENTRA = True
            ENTRA_FALLAS = True
        Catch ex As Exception
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub


    Private Sub BtnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If PERMITIR_UNIDAD = 0 Then
                    If UNIDAD_ESTA_EN_MANTO_EXTERNO_BASE(Var5) Then
                        tCVE_UNI.Text = Var5
                        L2.Text = Var6
                        Var2 = ""
                        Var4 = ""
                        Var5 = ""
                        tCVE_TIPO.Focus()
                    Else
                        MsgBox("La unidad No se encuentra en mantenimientio Externo ó base")
                    End If
                Else
                    tCVE_UNI.Text = Var5
                    L2.Text = Var6
                    Var2 = ""
                    Var4 = ""
                    Var5 = ""
                    tCVE_TIPO.Focus()
                End If
            End If
        Catch Ex As Exception
            MsgBox("260. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("260. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
        Try
            Var2 = "Tipo Unidad"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_TIPO.Text = Var4
                L4.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tEstatus.Focus()
            End If

        Catch Ex As Exception
            MsgBox("270. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("270. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub


    Private Sub BtnServicios_Click(sender As Object, e As EventArgs) Handles btnServicios.Click
        Try
            Var2 = "ServiciosOrdenes"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_SER.Text = Var4
                L1.Text = Var5

                LLENAR_SERVICIOS(Var4)

                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_UNI.Focus()
            End If

        Catch Ex As Exception
            MsgBox("280. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("280. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub


    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If ENTRA Then
                If Fg.Row > 0 Then
                    If Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 7 Or Fg.Col = 10 Or Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("1200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmOrdenDeTrabajoAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Orden de trabajo OT")
            Me.Dispose()

            If FORM_IS_OPEN("frmOrdenDeTrabajo") Then
                frmOrdenDeTrabajo.DESPLEGAR()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        If ENTRA Then

            If Fg.Col = 1 Or Fg.Col = 5 Or Fg.Col = 6 Or Fg.Col = 8 Or Fg.Col = 9 Then
                Dim c_ As Integer
                If Fg.Col = 2 Then
                    c_ = 1
                Else
                    c_ = Fg.Col
                End If

                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, c_)
                End If
                'cancel built -in editor
            End If
        End If
    End Sub
    '=========================================         FgM   =================================================
    '=========================================         FgM   =================================================
    '=========================================         FgM   =================================================
    Private Sub FgM_Click(sender As Object, e As EventArgs) Handles FgM.Click
        If FgM.Row > 0 Then
            If FgM.Col = 1 Then
                FgM.StartEditing()
            End If
        End If
    End Sub

    Private Sub FgM_EnterCell(sender As Object, e As EventArgs) Handles FgM.EnterCell
        Try
            If FgM.Row > 0 And ENTRA Then
                If FgM.Col = 3 Then
                Else
                    If REMOVE_ROW > 0 Then

                        If FgM.Row > 0 Then
                            FgM.Row = REMOVE_ROW
                        End If
                        REMOVE_ROW = 0
                    End If
                    FgM.StartEditing()
                End If
            End If
        Catch ex As Exception
            MsgBox("410. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("410. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgM_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgM.BeforeEdit
        Try
            If FgM.Row > 0 And ENTRA Then
                If FgM.Col = 3 Then
                    e.Cancel = True
                End If
                If FgM.Col = 2 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgM_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgM.ValidateEdit
        Try
            If FgM.Row > 0 And ENTRA Then
                If FgM.Col = 1 Then
                    If FgM.Editor.Text.Trim.Length > 0 Then

                        Dim DESCR As String

                        If Existe_Meca(FgM.Editor.Text) Then
                            MsgBox("El mecanico ya fue agregado verifique por favor")
                            e.Cancel = True
                            FgM.Editor.Text = ""
                            FgM(FgM.Row, 3) = ""
                            Return
                        End If
                        DESCR = BUSCA_CAT("Mecanicos", FgM.Editor.Text)
                        If DESCR <> "" Then
                            FgM(FgM.Row, 3) = DESCR
                        Else
                            e.Cancel = True
                            MsgBox("Mecanico inexistente")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgM_GotFocus(sender As Object, e As EventArgs) Handles FgM.GotFocus

        ENTRA_KEY = False
    End Sub

    Private Sub FgM_LostFocus(sender As Object, e As EventArgs) Handles FgM.LostFocus

        ENTRA_KEY = True
    End Sub

    Private Sub FgM_AfterEdit(sender As Object, e As RowColEventArgs) Handles FgM.AfterEdit
        Try
            If e.Row > 0 Then
                If e.Col = 9 Then
                    If FgM(e.Row, 1).ToString.Trim.Length > 0 And FgM(e.Row, 3).ToString.Trim.Length > 0 Then
                        If FgM.Row = FgM.Rows.Count - 1 Then
                            FgM.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                            FgM.Rows(FgM.Rows.Count - 1).Height = 30

                            FgM.Row = FgM.Rows.Count - 1
                            FgM.Col = 1
                            FgM.StartEditing()

                            Return
                        End If
                    End If

                End If
                If e.Col = 1 Then
                    Return
                End If

            End If
        Catch ex As Exception
            MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgM_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles FgM.KeyDownEdit
        Try
            If e.KeyCode = 27 Then
                If FgM.Col = 1 Then
                    If FgM(FgM.Row, 1).ToString.Trim.Length = 0 Or FgM(FgM.Row, 3).ToString.Trim.Length = 0 Then
                        FgM.RemoveItem(FgM.Row)
                        REMOVE_ROW = FgM.Row

                        Return
                    End If
                End If
                Return
            End If
        Catch ex As Exception
            MsgBox("450. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgM_KeyDown(sender As Object, e As KeyEventArgs) Handles FgM.KeyDown
        Try
            If FgM.Row > 0 Then
                If FgM.Col = 1 And e.KeyCode = 27 Then
                    If Fg(FgM.Row, 1).ToString.Trim.Length = 0 Or FgM(FgM.Row, 3).ToString.Trim.Length = 0 Then
                        FgM.RemoveItem(FgM.Row)
                        REMOVE_ROW = FgM.Row

                        Return
                    End If
                    Return
                End If
                If FgM.Col = 1 And e.KeyCode = Keys.Down Then
                    If FgM(FgM.Row, 1).ToString.Trim.Length > 0 And FgM(FgM.Row, 3).ToString.Trim.Length > 0 Then

                        FgM.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                        FgM.Rows(FgM.Rows.Count - 1).Height = 30

                        FgM.Row = FgM.Rows.Count - 1
                        FgM.Col = 1
                        FgM.StartEditing()
                        Return
                    End If
                End If
                If FgM.Col = 3 Then
                    If FgM(FgM.Row, 1).ToString.Trim.Length > 0 And FgM(FgM.Row, 3).ToString.Trim.Length > 0 Then

                        FgM.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                        FgM.Rows(FgM.Rows.Count - 1).Height = 30

                        FgM.Col = 1
                        FgM.Row = FgM.Rows.Count - 1
                        FgM.StartEditing()
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("460. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function Existe_Meca(fMECA As String) As String
        Try
            Dim Exist_M As Boolean
            Exist_M = False
            For k = 1 To FgM.Rows.Count - 1
                If k <> FgM.Row Then
                    If FgM(k, 1) = fMECA Then
                        Exist_M = True
                        Exit For
                    End If
                End If
            Next
            Return Exist_M
        Catch ex As Exception
            Return False
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Function

    Private Sub BtnEliMec_Click(sender As Object, e As EventArgs) Handles btnEliMec.Click
        Try
            If FgM.Row > 0 Then
                FgM.RemoveItem(FgM.Row)
            Else
                MsgBox("Por favor seleccione un mecánico")
            End If
        Catch ex As Exception
            MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("480. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEliSer_Click(sender As Object, e As EventArgs) Handles btnEliSer.Click
        Try
            If Fg.Row > 0 Then

                If MsgBox("Realmente desea eliminar la partida (artículo " & Fg(Fg.Row, 1) & ") ?", vbYesNo) = vbYes Then
                    Try
                        Fg.RemoveItem(Fg.Row)
                    Catch ex As Exception
                        Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Else
                MsgBox("Por favor seleccione una partida")
            End If
        Catch ex As Exception
            Bitacora("510. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("510. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    '=========================================   FgF FFFFFFFF  =========================================
    '=========================================   FgF   =================================================
    '=========================================   FgF FFFFFFFF  =========================================

    Private Sub FgF_Click(sender As Object, e As EventArgs) Handles FgF.Click
        If FgF.Row > 0 And ENTRA_FALLAS Then
            If FgF.Col = 1 Then
                FgF.StartEditing()
            End If
        End If
    End Sub

    Private Sub FgF_EnterCell(sender As Object, e As EventArgs) Handles FgF.EnterCell
        Try   'AQUI AQUI
            'Return
            If FgF.Row > 0 And ENTRA_FALLAS Then
                ENTRA_FALLAS = False
                If FgF.Col <> 1 Then
                Else
                    If REMOVE_ROW > 0 Then

                        If FgF.Row > 0 Then
                            FgF.Row = REMOVE_ROW
                        End If
                        REMOVE_ROW = 0
                    End If
                    FgF.StartEditing()
                End If
                ENTRA_FALLAS = True
            End If
        Catch ex As Exception
            Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("520. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgF_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgF.BeforeEdit
        Try
            If FgF.Row > 0 And ENTRA_FALLAS Then
                ENTRA_FALLAS = False
                If FgF.Col = 4 Then
                    e.Cancel = True
                End If
                'If FgF.Col = 2 Then
                'e.Cancel = True
                'End If
                ENTRA_FALLAS = True
            End If
        Catch ex As Exception
            Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("530. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgF_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgF.ValidateEdit
        Try
            If FgF.Row > 0 And ENTRA_FALLAS = True Then
                ENTRA_FALLAS = False
                If FgF.Col = 1 Then
                    If FgF.Editor.Text.Trim.Length > 0 Then

                    End If
                End If
                ENTRA_FALLAS = True
            End If
        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA_FALLAS = True
    End Sub

    Private Sub FgF_GotFocus(sender As Object, e As EventArgs) Handles FgF.GotFocus

        ENTRA_KEY = False
    End Sub

    Private Sub FgF_LostFocus(sender As Object, e As EventArgs) Handles FgF.LostFocus

        ENTRA_KEY = True
    End Sub

    Private Sub FgF_AfterEdit(sender As Object, e As RowColEventArgs) Handles FgF.AfterEdit
        Try
            If e.Row > 0 And ENTRA_FALLAS Then
                ENTRA_FALLAS = False
                If e.Col = 9 Then
                    If FgF(e.Row, 1).ToString.Trim.Length > 0 And FgF(e.Row, 4).ToString.Trim.Length > 0 Then
                        If FgF.Row = FgF.Rows.Count - 1 Then
                            FgF.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & "" & vbTab & "" & "" & vbTab & "")
                            FgF.Rows(FgF.Rows.Count - 1).Height = 40
                            FgF.Row = FgF.Rows.Count - 1
                            FgF.Col = 1
                            FgF.StartEditing()
                            ENTRA_FALLAS = True
                            Return
                        End If
                    End If
                End If
                If e.Col = 1 Then
                    Return
                End If
                ENTRA_FALLAS = True
            End If
        Catch ex As Exception
            Bitacora("550. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("550. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgF_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles FgF.KeyDownEdit
        Try
            If Not ENTRA_FALLAS Then
                Return
            End If
            If e.KeyCode = 27 Then

                If FgF.Col = 1 Then
                    If FgF(FgF.Row, 1).ToString.Trim.Length = 0 Or FgF(FgF.Row, 4).ToString.Trim.Length = 0 Then
                        FgF.RemoveItem(FgF.Row)
                        REMOVE_ROW = FgF.Row

                        Return
                    End If
                End If
                Return
            End If
        Catch ex As Exception
            Bitacora("560. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("560. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgF_KeyDown(sender As Object, e As KeyEventArgs) Handles FgF.KeyDown
        Try
            If FgF.Row > 0 And ENTRA_FALLAS Then
                If FgF.Col = 1 And e.KeyCode = 27 Then
                    If Fg(FgF.Row, 1).ToString.Trim.Length = 0 Or FgF(FgF.Row, 4).ToString.Trim.Length = 0 Then
                        FgF.RemoveItem(FgF.Row)
                        REMOVE_ROW = FgF.Row

                        Return
                    End If
                    Return
                End If
                If FgF.Col = 1 And e.KeyCode = Keys.Down Then
                    If FgF(FgF.Row, 1).ToString.Trim.Length > 0 And FgF(FgF.Row, 4).ToString.Trim.Length > 0 Then

                        FgF.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & "" & vbTab & "" & "" & vbTab & "")
                        FgF.Rows(FgF.Rows.Count - 1).Height = 40

                        FgF.Row = FgF.Rows.Count - 1
                        FgF.Col = 1
                        FgF.StartEditing()

                        Return
                    End If
                End If
                If FgF.Col = 4 Then
                    If FgF(FgF.Row, 1).ToString.Trim.Length > 0 And FgF(FgF.Row, 4).ToString.Trim.Length > 0 Then

                        FgF.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & "" & vbTab & "" & "" & vbTab & "")
                        FgF.Rows(FgF.Rows.Count - 1).Height = 40

                        FgF.Col = 1
                        FgF.Row = FgF.Rows.Count - 1
                        FgF.StartEditing()

                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("570. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("570. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function Existe_Falla(fFALLA As String, fCVE_UNI As String, fNO_PARTIDA As String) As String

        Try
            Dim Exist_M As Boolean
            Exist_M = False
            For k = 1 To FgF.Rows.Count - 1
                If k <> FgF.Row Then
                    If FgF(k, 1) = fFALLA And FgF(k, 6) = fCVE_UNI And FgF(k, 7) = fNO_PARTIDA Then
                        Exist_M = True
                        Exit For
                    End If
                End If
            Next
            Return Exist_M
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Sub LLENAR_SERVICIOS(fCLAVE As String)
        Try
            Dim DESCR As String = ""
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            If MsgBox("Realmente desea cargar las actividades de mantenimiento", vbYesNo) = vbNo Then
                Return
            End If

            ENTRA = False
            Fg.Rows.Count = 1
            SQL = "SELECT P.CVE_ART, ISNULL(P.CANT,1) AS CANTI, ISNULL(P.DESCR,'') AS DES, ISNULL(TIEMPO,0) AS SERV, ISNULL(TIEMPO_REAL,0) AS REAL, TIPO, " &
                "ISNULL((SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = P.CVE_ART),'') AS N_PARTE, ISNULL(P.STATUS,'') AS ST, TIPO_ELE, " &
                "ISNULL((SELECT TOP 1 PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1 " &
                "FROM GCSERVICIOS_MANTE_PAR P " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART " &
                "WHERE CVE_SER = '" & fCLAVE & "'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_ART") & vbTab & "" & vbTab & dr("DES") & vbTab & dr("N_PARTE") & vbTab & "" & vbTab &
                             "" & vbTab & "" & vbTab & "" & vbTab & dr("CANTI") & vbTab & dr("P1") & vbTab & (dr("CANTI") * dr("P1")) & vbTab &
                            dr("TIPO_ELE") & vbTab & " ")
            Loop
            dr.Close()
            ENTRA = True
        Catch ex As Exception
            Bitacora("590. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("590. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
        Try
            If tCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                If DESCR <> "" Then
                    If PERMITIR_UNIDAD = 0 Then
                        If UNIDAD_ESTA_EN_MANTO_EXTERNO_BASE(tCVE_UNI.Text) Then
                            L1.Text = DESCR
                        Else
                            MsgBox("La unidad No se encuentra en mantenimientio Externo ó base")
                            tCVE_UNI.Text = ""
                        End If
                    Else
                        L1.Text = DESCR
                    End If

                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI.Text = ""
                    tCVE_UNI.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_SER_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_SER.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnServicios_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnUnidades_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_TIPO_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TIPO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnTipo_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCVE_TIPO_Validated(sender As Object, e As EventArgs) Handles tCVE_TIPO.Validated
        Try
            If tCVE_TIPO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo unidad", tCVE_TIPO.Text)
                If DESCR <> "" Then
                    L4.Text = DESCR
                    tCVE_OPER.Focus()
                Else
                    MsgBox("Tipo Unidad inexistente")
                    tCVE_TIPO.Text = ""
                    tCVE_TIPO.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("610. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("610. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_SER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCVE_SER.PreviewKeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            Try
                If tCVE_SER.Text.Trim.Length > 0 Then
                    Dim DESCR As String
                    DESCR = BUSCA_CAT("Servicios", tCVE_SER.Text)
                    If DESCR <> "" Then
                        L1.Text = DESCR
                        LLENAR_SERVICIOS(tCVE_SER.Text)
                    Else
                        MsgBox("Servicio inexistente")
                        tCVE_SER.Text = ""
                        tCVE_SER.Select()
                    End If
                End If
            Catch ex As Exception
                Bitacora("620. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("620. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub ImprimirOrden(fCVE_ORD As String)
        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenTrabajo.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportOrdenTrabajo.mrt, verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS & "\ReportOrdenTrabajo.mrt")

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CVE_ORDEN") = fCVE_ORD
            StiReport1.Render()
            'StiReport1.Print(True)
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarReimpresion_Click(sender As Object, e As EventArgs) Handles barReimpresion.Click
        ImprimirOrden(tCVE_ORD.Text)
    End Sub


    Private Sub BtnOperador_Click(sender As Object, e As EventArgs) Handles btnOperador.Click
        Try
            Var2 = "Operador"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_OPER.Text = Var4
                LtOper.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tEstatus.Focus()
            End If

        Catch Ex As Exception
            Bitacora("640. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("640. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles tCVE_OPER.Validated
        Try
            If tCVE_OPER.Text.Trim.Length > 0 And IsNumeric(tCVE_OPER.Text) Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Operador", tCVE_OPER.Text)
                If DESCR <> "" Then
                    L1.Text = DESCR
                Else
                    MsgBox("Operador inexistente")
                    tCVE_OPER.Text = ""
                    tCVE_OPER.Select()
                End If
            Else
                LtOper.Text = ""
                tCVE_OPER.Text = ""
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OPER.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnOperador_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_OPER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCVE_OPER.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            tLUGAR_REP.Select()
        End If

    End Sub
    Private Sub BarFinalizar_Click(sender As Object, e As EventArgs) Handles barFinalizar.Click
        Try
            Dim cmd2 As New SqlCommand

            SQL = "UPDATE GCORDEN_TRABAJO SET ESTATUS = 'FINALIZADA'"
            cmd2.Connection = cnSAE
            cmd2.CommandText = SQL
            cmd2.ExecuteNonQuery()
        Catch ex As Exception
            Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEliFallas_Click(sender As Object, e As EventArgs) Handles btnEliFallas.Click
        Try
            If FgF.Row > 0 Then
                FgF.RemoveItem(FgF.Row)
            Else
                MsgBox("Por favor seleccione una falla")
            End If
        Catch ex As Exception
            Bitacora("690. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("690. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAltaFalla_Click(sender As Object, e As EventArgs) Handles btnAltaFalla.Click

        Try
            FgF.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & "" & vbTab & "" & "" & vbTab & "")
            FgF.Rows(FgF.Rows.Count - 1).Height = 40
            FgF.Row = FgF.Rows.Count - 1
            FgF.Col = 1
            FgF.StartEditing()

        Catch ex As Exception
            Bitacora("700. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("700. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAltaServicio_Click(sender As Object, e As EventArgs) Handles btnAltaServicio.Click

        Try

            If IsNothing(Fg(Fg.Rows.Count - 1, 1)) Then
                Return
            End If
            If String.IsNullOrEmpty(Fg(Fg.Rows.Count - 1, 1)) Then
                Return
            End If

            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                "0" & vbTab & "0" & vbTab & "0" & vbTab & "-" & vbTab & "-")

            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1

            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, 1)
            End If

        Catch ex As Exception
            Bitacora("720. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("720. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAltaMecanico_Click(sender As Object, e As EventArgs) Handles btnAltaMecanico.Click
        Try
            FgM.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
            FgM.Rows(FgM.Rows.Count - 1).Height = 30
            FgM.Col = 1
            FgM.Row = FgM.Rows.Count - 1
            FgM.StartEditing()
        Catch ex As Exception
            MsgBox("721. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("721. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TOBSER_KeyDown(sender As Object, e As KeyEventArgs) Handles tOBSER.KeyDown
        Try
            If e.KeyCode = 13 Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadExtra_KeyDown(sender As Object, e As KeyEventArgs) Handles radExtra.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            tCVE_UNI.Focus()
        End If
    End Sub
    Private Sub TEstatus_KeyDown(sender As Object, e As KeyEventArgs) Handles tEstatus.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            tLUGAR_REP.Focus()
        End If
    End Sub
    Private Sub TNOTA_KeyDown(sender As Object, e As KeyEventArgs) Handles tNOTA.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Fg.Focus()

            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, 1)
            End If
        End If
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick

        Try
            If ENTRA_BTN Then
                ENTRA_BTN = False
                Fg.FinishEditing()
                If e.Col = 2 Then
                    Var2 = "InveR" : Var4 = "" : Var5 = ""
                Else
                    Var2 = "Prov" : Var4 = "" : Var5 = ""
                End If
                frmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    If e.Col = 2 Then
                        Fg(Fg.Row, 0) = IIf(Var8 = "S", "S", "")
                        Fg(Fg.Row, 1) = Var4  'CVE_ART
                        Fg(Fg.Row, 3) = Var5  'DESCR
                        Fg(Fg.Row, 4) = Var6  'NO_PARTE
                        Fg(Fg.Row, 10) = Var7  'precio
                        Fg(Fg.Row, 12) = Var8  'TIPO ELE
                    Else
                        Fg(Fg.Row, 5) = Var4  'CLAVE
                        Fg(Fg.Row, 7) = Var5  'NOMBRE
                    End If
                    Var2 = "" : Var4 = "" : Var5 = ""
                    CALCULAR_IMPORTES()
                    ENTRA = True
                    '2 = CELLBUTTON
                    If e.Col = 2 Then
                        Fg.Col = 5 'PROVEEDOR

                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(e.Row, 5)
                        End If
                    Else
                        If MULTIALMACEN = 1 Then
                            Fg.Col = 8 'ALMACEN

                            If Not IsNothing(_myEditor) Then
                                _myEditor.StartEditing(e.Row, 8)
                            End If
                        Else
                            Fg.Col = 9 'CANTIDAD
                            If Not IsNothing(_myEditor) Then
                                _myEditor.StartEditing(e.Row, 9)
                            End If
                        End If
                    End If
                Else
                    If e.Col = 2 Then
                        Fg.Col = 1 'ARTICULO
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(e.Row, 1)
                        End If
                    Else
                        Fg.Col = 5 'PROVEEDOR
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(e.Row, 5)
                        End If
                    End If

                End If
                ENTRA_BTN = True
            End If
        Catch ex As Exception
            MsgBox("727. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("727. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgF_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgF.CellButtonClick
        Try

            ENTRA_BTN = False

            Var2 = "Fallas"
            Var4 = "" 'CVE_FALLA
            Var5 = "" 'DESC UNIDAD
            Var6 = "" 'DESC FALLA
            Var7 = "" 'ORDER ASIGNADA
            Var8 = "" 'CVE_UNI
            Var9 = "" 'NO_PARTIDA

            FgF.FinishEditing()
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If Var7.Trim.Length > 0 Then
                    MsgBox("El reporte de falla ya fue asignada a la orden " & Var7 & ", verifique por favor")
                    Return
                End If
                If Existe_Falla(Var4, Var8, Var9) Then
                    MsgBox("El reporte de falla ya fue agregado verifique por favor")
                    FgF(FgF.Row, 1) = ""
                    FgF(FgF.Row, 3) = ""
                    FgF(FgF.Row, 4) = ""
                    FgF(FgF.Row, 5) = ""
                    FgF(FgF.Row, 6) = ""
                    ENTRA_FALLAS = True
                    FgF.Col = 1
                    FgF.StartEditing()
                    Return
                End If
                ENTRA_FALLAS = False
                If FgF.Rows.Count - 1 = 0 Then
                    Try
                        FgF.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & "" & vbTab & "" & "" & vbTab & "")
                        FgF.Rows(FgF.Rows.Count - 1).Height = 40
                        FgF.Row = FgF.Rows.Count - 1
                        FgF.Col = 2
                        FgF.StartEditing()
                    Catch ex As Exception
                        MsgBox("770. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("770. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
                FgF(FgF.Row, 1) = Var4
                FgF(FgF.Row, 3) = Var5
                FgF(FgF.Row, 4) = Var6
                FgF(FgF.Row, 5) = Var7
                FgF(FgF.Row, 6) = Var8
                FgF(FgF.Row, 7) = Var9
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = "" : Var9 = ""
                ENTRA_FALLAS = True
                FgF.Col = 4
            Else
                FgF.Col = 1
            End If

        Catch ex As Exception
            ENTRA_BTN = True
            MsgBox("780. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("780. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA_BTN = True
    End Sub

    Private Sub FgM_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgM.CellButtonClick
        Try
            If ENTRA_BTN Then

                ENTRA_BTN = False
                Var2 = "Mecanicos"
                Var4 = ""
                Var5 = ""
                FgM.FinishEditing()

                frmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then

                    FgM(FgM.Row, 1) = Var4
                    FgM(FgM.Row, 3) = Var5
                    Var2 = ""
                    Var4 = ""
                    Var5 = ""
                    FgM.Col = 3
                Else
                    FgM.Col = 1
                End If
                ENTRA_BTN = True
            End If

        Catch ex As Exception
            ENTRA_BTN = True
            MsgBox("790. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("790. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub EntraFlex(fENTRA As Boolean)
        Try
            ENTRA = fENTRA
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TMagico_GotFocus(sender As Object, e As EventArgs) Handles tMagico.GotFocus
        Try
            Fg.Select()
            Dim c_ As Integer
            If Fg.Col = 1 Then
                c_ = 1
            Else
                c_ = Fg.Col
            End If

            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, c_)
            End If
        Catch ex As Exception
            Bitacora("1450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                Dim c_ As Integer
                If Fg.Col = 2 Then
                    c_ = 1
                Else
                    c_ = Fg.Col
                End If

                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, c_)
                End If
            End If
        Catch ex As Exception
            Bitacora("1190. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_StartEdit(sender As Object, e As RowColEventArgs) Handles Fg.StartEdit
        Try
            If ENTRA Then
                If Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 7 Or Fg.Col = 10 Or Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Then
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_AfterScroll(sender As Object, e As RangeEventArgs) Handles Fg.AfterScroll
        If ENTRA Then
            If _myEditor.Visible Then
                _myEditor.UpdatePosition()
            End If
        End If
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        If ENTRA Then
            _myEditor.SetPendingKey(e.KeyChar)
        End If
    End Sub
    Sub ENTRA_VAL(fENT As Boolean)
        Try
            ENTRA = fENT
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadPreventivo_KeyDown(sender As Object, e As KeyEventArgs) Handles radPreventivo.KeyDown
        If e.KeyCode = 13 Then
            'tCVE_UNI.Select()
        End If
    End Sub

    Private Sub RadCorrectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles radCorrectivo.KeyDown
        If e.KeyCode = 13 Then
            'tCVE_UNI.Select()
        End If
    End Sub

    Private Sub RadCorrectivo_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles radCorrectivo.PreviewKeyDown
        If e.KeyCode = 9 Then
            'tCVE_UNI.Focus()
        End If
    End Sub
End Class

'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditorOT
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    Private YAlmacen As Single


    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid, MyAlmacen As Single)
        MyBase.New()
        Visible = False
        AutoSize = False
        BackColor = Color.Beige
        BorderStyle = BorderStyle.FixedSingle

        _pendingKey = Chr(0)
        yAlmacen = MyAlmacen
        _cancel = False
        _owner = owner
        _owner.Controls.Add(Me)
        _owner.Cols(10).EditMask = "999,999,999.99"
        _owner.Cols(11).EditMask = "999,999,999.99"
    End Sub

    'comenzar a editar: mover a la celda y activar
    '
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)

        'save coordinates of cell being edited
        'guardar las coordenadas de la celda que se está editando
        Dim PRECIO As Single

        If col = 1 And keyRec = 9 Then
            If IsNothing(_owner(_row, 1)) Then
                MyBase.Visible = True
                _owner.Select()
                _owner.StartEditing()
                Return
            End If
        End If
        If col = 1 And keyRec = 99 Then
            _owner.Select(1, 2)
            _owner.Row = 1
            _owner.Col = 1
            MoveCursor(Keys.Enter)
            _owner.Rows.Count = 1
            Return
        End If
        If col = 1 Or col = 5 Or col = 6 Or col = 8 Or col = 9 Then
            If col = 99 Then
                _owner.Col = 1
                frmOrdenDeTrabajoAE.tMagico.Focus()
                MyBase.Visible = True
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If

            _row = row
            _col = col
            'assume we'll save the edits
            'supongamos que guardaremos las ediciones
            _cancel = False
            'move editor over the current cell
            'mover editor sobre la celda actual
            Dim rc As Rectangle = _owner.GetCellRect(row, col, True)
            rc.Width = rc.Width - 1
            rc.Height = rc.Height - 1

            MyBase.Bounds = rc
            'initialize control content
            'inicializar contenido de control
            If col = 131 Then
                'PRECIO
            End If
            MyBase.Text = ""
            If _pendingKey > " " Then
                MyBase.Text = _pendingKey.ToString()
            ElseIf Not _owner(row, col) Is Nothing Then
                If col = 9 Then
                    PRECIO = _owner(row, col).ToString()
                    PRECIO = Math.Round(PRECIO, 4)
                    MyBase.Text = PRECIO
                Else
                    MyBase.Text = _owner(row, col).ToString()
                End If
            End If
            MyBase.Select(Text.Length, 0)
            'make editor visible
            MyBase.Visible = True
            'and get the focus
            '_owner.Select(_row, 2)
            MyBase.Select()
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = MyBase.TextLength
        End If

    End Sub
    Public Sub EndEdit(ByVal row As Integer, ByVal col As Integer)

        Try
            _owner.FinishEditing()
            _owner(row, col) = ""
            MyBase.Text = ""
        Catch ex As Exception
            Bitacora("1620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)

        If col = 1 Or col = 5 Or col = 6 Or col = 8 Or col = 9 Then
            MyBase.Visible = True
        End If
    End Sub
    'guardar clave que inició el modo de edición
    Public Sub SetPendingKey(ByVal chr As Char)
        _pendingKey = chr
    End Sub

    'move editor after the grid has scrolled
    'mover editor después de que la cuadrícula se haya desplazado
    Public Sub UpdatePosition()

        'get cell rect now
        'obtener celular ahora
        Dim rcCell As Rectangle = _owner.GetCellRect(_row, _col, False)

        'intersect with scrollable part of the grid
        'intersectarse con parte desplazable de la cuadrícula
        Dim rcScroll As Rectangle = _owner.ClientRectangle
        rcScroll.X = _owner.Cols(_owner.Cols.Fixed).Left
        rcScroll.Y = _owner.Rows(_owner.Rows.Fixed).Top
        rcScroll.Width = rcScroll.Width - rcScroll.X
        rcScroll.Height = rcScroll.Height - rcScroll.Y
        rcCell = Rectangle.Intersect(rcCell, rcScroll)

        'y mueve el control
        If (rcCell.Width > 0) Then rcCell.Width = rcCell.Width - 1
        If (rcCell.Height > 0) Then rcCell.Height = rcCell.Height - 1
        MyBase.Bounds = rcCell
    End Sub

    'Foco perdido: ocultar el editor
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)

        If _col = 99 Then
            _owner.Col = 1
            frmOrdenDeTrabajoAE.tMagico.Focus()
            _owner.Select()
            _owner.Select(_row, 2)
            _owner.StartEditing()
            Return
        End If

        Try
            If _col = 9 Then 'cantidad
                Try
                    If Not IsNothing(MyBase.Text) And Not IsNothing(_owner(_row, 9)) Then
                        'frmTPV.CALCULAR_IMPORTES()
                    End If
                Catch ex As Exception
                    Bitacora("1630. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1630. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            'aqui esta el error
            If _col = 22 Then
                If IsNothing(_owner(_row, 1)) Then
                    MyBase.Visible = True
                    _owner.Select()
                    _owner.Select(_row, 1)
                    _owner.StartEditing()
                    Return
                End If
                If _owner(_row, _col) = "" Then
                    MyBase.Visible = True
                    Return
                End If
            End If
            If _col = 9 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 9)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim C1 As Decimal
                                        C1 = MyBase.Text * _owner(_row, 10)
                                        _owner(_row, 11) = C1
                                    Catch ex As Exception
                                        _owner(_row, 11) = MyBase.Text * _owner(_row, 10)
                                    End Try
                                    _owner.FinishEditing()
                                    CALCULAR_IMPORTES()
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            End If
            If _col = 99 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 9)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim C1 As Decimal
                                        C1 = _owner(_row, 10) * MyBase.Text
                                        _owner(_row, 11) = C1

                                    Catch ex As Exception
                                        _owner(_row, 11) = _owner(_row, 10) * MyBase.Text
                                    End Try
                                    CALCULAR_IMPORTES()
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            End If
            'procesamiento base
            MyBase.OnLeave(e)

            'copiar texto a la cuadrícula del propietario
            If Not _cancel Then
                _owner(_row, _col) = MyBase.Text
            End If

            'no más claves pendientes
            _pendingKey = Chr(0)

            'hecho por ahora, ocultar editor
            MyBase.Visible = False
        Catch ex As Exception
            Bitacora("1650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("940. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub
    'manejaremos la tecla de tabulación nosotros mismos
    Protected Overrides Function IsInputkey(ByVal keydata As Keys) As Boolean
        If keydata = Keys.Tab Or keydata = Keys.Enter Then
            Return True
        End If
        Return MyBase.IsInputKey(keydata)
    End Function

    'algunas teclas finalizan la edición
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If _col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmOrdenDeTrabajoAE.tMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If
        End If

        Select Case e.KeyCode
            Case Keys.Escape
                _cancel = True
                _owner.Select()
                e.Handled = True
            Case Keys.Enter, Keys.Tab, Keys.Up, Keys.Down, Keys.PageUp, Keys.PageDown, Keys.Left, Keys.Right
                _owner.Select()
                e.Handled = True
                MoveCursor(e.KeyCode)
            Case Keys.F2
                If _col = 1 Then
                    Try                    'ARTICULOS
                        Var2 = "InveP" : Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            'Var4 = Fg(Fg.Row, 1) 'CLAVE
                            'Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                            'Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                            'Var7 = Fg(Fg.Row, 5).ToString 'PRECIOS
                            'Var8 = Fg(Fg.Row, 6).ToString 'TIPO PROD
                            _owner(_row, 1) = Var4
                            _owner(_row, 3) = Var5
                            _owner(_row, 4) = Var6
                            _owner(_row, 10) = Var7
                            _owner(_row, 12) = Var8
                            Try
                                Dim C1 As Decimal
                                C1 = _owner(_row, 9) * Val(Var7)
                                _owner(_row, 11) = C1
                            Catch ex As Exception
                            End Try
                            frmOrdenDeTrabajoAE.CALCULAR_IMPORTES()

                            _owner.Col = 5
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("1750. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("1750. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
                If _col = 5 Then
                    Var2 = "Prov" : Var4 = "" : Var5 = ""
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        _owner(_row, 5) = Var4  'CLAVE
                        _owner(_row, 7) = Var5  'NOMBRE
                        Var2 = "" : Var4 = "" : Var5 = ""
                        If yAlmacen = 1 Then
                            _owner.Col = 8 'ALMACEN
                        Else
                            _owner.Col = 9 'CANTIDAD
                        End If
                    End If
                End If
            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub

    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col

        If col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmOrdenDeTrabajoAE.tMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        If col = 1 And key = Keys.Left Then
            frmOrdenDeTrabajoAE.tMagico.Focus()
            Return
        End If

        If col = 22 Or col = 24 Or col = 25 Or col = 213 Then
            If Not IsNothing(_owner(_row, _col)) Then
                If _owner(_row, _col).ToString.Trim.Length = 0 Then
                    _owner.Row = _row
                    _owner.Col = col
                    _owner.Row = _row
                    Return
                End If
            Else
                _owner.Select()
                '_owner.Row = _row
                '_owner.Col = col
                '_owner.Select(_row, _col)
                Return
            End If
        End If
        Select Case key
            Case Keys.Tab, Keys.Enter

            Case Keys.Up
                If _owner.Row = 1 Then
                    frmOrdenDeTrabajoAE.tMagico.Focus()
                    Return
                End If
                If IsNothing(_owner(_row, 1)) Then
                    If IsNothing(_owner(_row, 3)) Then
                        _owner.RemoveItem(_owner.Row)
                        row = _owner.Rows.Count - 1
                        Return
                    Else
                        If _owner(_row, 3).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                Else
                    If IsNothing(_owner(_row, 3)) Then
                        If _owner(_row, 2).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                End If

                If row > 1 Then
                    row = row - 1
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                Else
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                End If
            Case Keys.Down
                If _owner.Rows.Count - 1 = row Then
                    Select Case col
                        Case 1
                            If IsNothing(_owner(_row, 1)) Then
                                frmOrdenDeTrabajoAE.tMagico.Focus()
                            Else
                                If FgEdit Then
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                   "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "")
                                    _owner.Select(row + 1, 1)
                                Else
                                    frmOrdenDeTrabajoAE.tMagico.Focus()
                                    _owner.Select(row, 1)
                                End If
                            End If
                        Case 3
                            frmOrdenDeTrabajoAE.tMagico.Focus()
                        Case 9
                            frmOrdenDeTrabajoAE.tMagico.Focus()
                    End Select
                    Return
                Else
                    row = row + 1
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                End If
            Case Keys.PageUp
                row -= 10
            Case Keys.PageUp
                row += 10
            Case Keys.Left
                If col > 1 Then
                    Select Case col
                        Case 1
                            If IsNothing(_owner(_row, 1)) Then
                                If IsNothing(_owner(_row, 3)) Then
                                    If _owner.Rows.Count - 1 <> 1 Then
                                        _owner.RemoveItem(_owner.Row)
                                        row = _owner.Rows.Count - 1
                                    End If
                                    Return
                                Else
                                    If _owner(_row, 3).ToString.Length = 0 Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                            row = _owner.Rows.Count - 1
                                        End If
                                        Return
                                    End If
                                End If
                            Else
                                If IsNothing(_owner(_row, 3)) Then
                                    If _owner(_row, 1).ToString.Length = 0 Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                            row = _owner.Rows.Count - 1
                                        End If
                                        Return
                                    End If
                                End If
                            End If
                            If row = 1 Then
                                row = _owner.Rows.Count - 1
                            Else
                                row = row - 1
                            End If
                            col = 1
                        Case 5
                            col = 1
                        Case 9
                            col = 5
                    End Select
                    'col = col - 1
                    'If col = 2 Or col = 4 Then
                    'col = col - 1
                    'End If
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
                Return
            Case Keys.Right
                If col <= 9 Then
                    Select Case col
                        Case 1
                            'CORREGIR AQUI
                            If IsNothing(_owner(_row, 1)) Then
                                frmOrdenDeTrabajoAE.tMagico.Focus()
                                '_owner.Select()
                                '_owner.Select(row, col)
                                '_owner.StartEditing()
                                Return
                            End If
                            If MyBase.Text.ToString.Length = 0 Then
                                _owner.Select()
                                _owner.Select(row, col)
                                _owner.StartEditing()
                                Return
                            End If
                            col = 5
                        Case 5 'PROVEEDOR
                            'If IsNothing(_owner(_row, 1)) Then
                            'frmOrdenDeTrabajoAE.tMagico.Focus()
                            'Return
                            'End If
                            'If MyBase.Text.ToString.Length = 0 Then
                            'frmOrdenDeTrabajoAE.tMagico.Focus()
                            'Return
                            'e'nd If
                            col = 9
                        Case 9
                            col = 1
                    End Select
                    'col = col + 1
                    'If col = 2 Or col = 4 Then
                    'col = col + 1
                    'End If
                Else
                    col = 1
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
        End Select

        'validar nueva selección
        If (row < _owner.Rows.Fixed) Then row = _owner.Rows.Fixed
        If (col < _owner.Cols.Fixed) Then col = _owner.Cols.Fixed
        If (row > _owner.Rows.Count - 1) Then row = _owner.Rows.Count - 1
        If (col > _owner.Cols.Count - 1) Then col = _owner.Cols.Count - 1

        'aplicar nueva selección        7
        _owner.Select(_row, _col)

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        Dim HayErr As Boolean

        If col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmOrdenDeTrabajoAE.tMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If
        End If
        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)
                    Select Case _col
                        Case 1 'CVE_ART
                            Dim Descr As String
                            If MyBase.Text.Trim.Length = 0 Then
                                frmOrdenDeTrabajoAE.tMagico.Focus()
                                Return
                            End If
                            Var9 = "" : Var22 = 0 : Var4 = ""
                            'Var6 = dr("NUM_PARTE")
                            'Var7 = dr("P1")
                            'Var8 = dr("T_ELE")
                            Descr = BUSCA_CAT("InveP", MyBase.Text)
                            If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                MsgBox("Articulo inexistente")
                                frmOrdenDeTrabajoAE.tMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            Else
                                'LLENAR_GRID_ARTICULO(MyBase.Text)
                                'Var6 = dr("NUM_PARTE")
                                'Var7 = dr("P1")
                                'Var8 = dr("T_ELE")
                                '_owner(_row, 1) = Var4
                                _owner(_row, 3) = Descr
                                _owner(_row, 4) = Var6
                                _owner(_row, 10) = Var7
                                _owner(_row, 12) = Var8
                                Try
                                    Dim C1 As Decimal
                                    C1 = _owner(_row, 9) * Val(Var7)
                                    _owner(_row, 11) = C1
                                Catch ex As Exception
                                End Try
                                _owner.Col = 5
                                Return
                            End If
                        Case 5 'proveedor
                            'If Not IsNothing(_owner(_row, _col)) Then
                            'If _owner(_row, _col).ToString.Trim.Length = 0 Then
                            '_owner.Row = _row
                            '_owner.Col = col
                            '_owner.Row = _row
                            '_owner.StartEditing()
                            'Return
                            'End If
                            'End If
                            'If MyBase.Text.Trim.Length = 0 Then
                            'frmOrdenDeTrabajoAE.tMagico.Focus()
                            'Return
                            'End If
                            _owner.Col = 9
                            '_owner.Select()
                            '_owner.Select(_row, 9)
                            _owner.StartEditing()
                            Return
                        Case 9 'cantidad
                            If MyBase.Text.Trim.Length = 0 Or MyBase.Text.Trim = "0" Then
                                MsgBox("Cantidad incorrecta")
                                frmOrdenDeTrabajoAE.tMagico.Focus()
                                Return
                            End If
                            Try
                                If Not IsNothing(_owner(_row, _col)) Then
                                    If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                        If IsNumeric(_owner(_row, 1)) Then
                                            If IsNumeric(MyBase.Text) Then
                                                Try
                                                    Dim C1 As Decimal
                                                    C1 = _owner(_row, 10) * MyBase.Text
                                                    _owner(_row, 11) = C1
                                                Catch ex As Exception
                                                    _owner(_row, 11) = _owner(_row, 10) * MyBase.Text
                                                End Try
                                                frmOrdenDeTrabajoAE.CALCULAR_IMPORTES()
                                            End If
                                        End If
                                    End If
                                End If
                                HayErr = False
                                Try
                                    _owner.Select(row + 1, 1)
                                Catch ex As Exception
                                    HayErr = True
                                End Try
                                If HayErr Then
                                    'If FgEdit Then
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                       "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "")
                                    _owner.Select(row + 1, 1)
                                    'End If
                                Else
                                    If _owner(row, 1) > 0 And _owner(row, 3).ToString.Trim.Length > 0 Then
                                    End If
                                End If
                                _owner.StartEditing()
                                return
                            Catch ex As Exception
                                Bitacora("1860. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("1860. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 111
                            _owner.Select(row, col + 4)
                        Case 55
                            _owner.Select(row, col + 4)
                        Case 10
                    End Select

                    _owner.StartEditing()
                    'Return

                Case Else
                    If _col = 1 Then
                        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                            e.KeyChar = ""
                            Return
                        End If

                    End If
            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            Bitacora("1870. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1870. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_GRID_ARTICULO(fCVE_ART As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ULT_COSTO As Single

            If fCVE_ART.Trim.Length = 0 Then
                Return
            End If

            ULT_COSTO = 0
            cmd.Connection = cnSAE
            SQL = "SELECT I.CVE_ART, DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU, " &
                "ISNULL((SELECT TOP 1 PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE I.CVE_ART = '" & fCVE_ART & "' OR A.CVE_ALTER = '" & fCVE_ART & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                _owner(_row, 1) = dr("CVE_ART")
                _owner(_row, 3) = dr("DESCR")
                Try
                    Dim C1 As Decimal
                    C1 = _owner(_row, 9) * _owner(_row, 10)
                    _owner(_row, 11) = C1
                Catch ex As Exception
                    _owner(_row, 11) = _owner(_row, 9) * _owner(_row, 10)
                End Try
                'frmTPV.CALCULAR_IMPORTES()
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("1880. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1880. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULAR_IMPORTES()
        Try
            Dim SUMA As Decimal = 0
            _owner.FinishEditing()

            For k = 1 To _owner.Rows.Count - 1
                If _owner(k, 1).ToString.Trim.Length > 0 Then
                    SUMA = SUMA + _owner(k, 11)
                End If
            Next
            frmOrdenDeTrabajoAE.LtTotal.Text = Format(SUMA, "###,###,##0.00")
        Catch ex As Exception
            Bitacora("1900. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Class
