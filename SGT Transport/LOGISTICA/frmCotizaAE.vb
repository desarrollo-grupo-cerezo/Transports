Imports System.IO
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmCotizaAE
    Private ENTRA_BTN As Boolean
    Private ENTRA As Boolean
    Private Salir As Boolean
    Private ENTRA_TXT As Boolean = True
    Private NewRecord As Boolean = False
    Private _myEditor As MyEditorCot
    Private Sub FrmCotizaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            AssignValidation(Me.TCOSTOS_FIJOS1, ValidationType.Only_Numbers)
            AssignValidation(Me.TDEPRE1, ValidationType.Only_Numbers)
            AssignValidation(Me.TUNI_ACTIVAS, ValidationType.Only_Numbers)
            AssignValidation(Me.TNUM_CIRCUITO, ValidationType.Only_Numbers)
            AssignValidation(Me.TDIAS_ANALISIS, ValidationType.Only_Numbers)
            AssignValidation(Me.TDIAS_NATURALES, ValidationType.Only_Numbers)
            AssignValidation(Me.TPRECIO_X_LT_DIESEL, ValidationType.Only_Numbers)
            AssignValidation(Me.TPORC_MANIOBRAS, ValidationType.Only_Numbers)
        Catch ex As Exception
        End Try
        Try
            _myEditor = New MyEditorCot(Fg)
        Catch ex As Exception

        End Try
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            WindowState = FormWindowState.Maximized

            ENTRA = False
            Salir = False
            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
            KeyPreview = True
            Fg.Rows.Count = 1
            If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = Fg(0, k) & " " & k
                Next
            End If
            Try
                TCVE_COT.Text = "" : TCLIENTE.Text = "" : F1.Value = Now : TCOSTOS_FIJOS1.Text = 0 : TDEPRE1.Text = 0 : TCOSTOS_FIJOS2.Text = 0 : TDEPRE2.Text = 0
                TCOSTOS_FIJOS3.Text = 0 : TDEPRE3.Text = 0 : TUNI_ACTIVAS.Text = 0 : TNUM_CIRCUITO.Text = 0 : TDIAS_ANALISIS.Text = 0 : TDIAS_NATURALES.Text = 0
                TPRECIO_X_LT_DIESEL.Text = 0 : TPRECIO_DIESEL_SINIVA.Text = 0 : TPORC_MANIOBRAS.Text = 0 : TTOTAL_COSTO_OP.Text = 0 : TCOSTO_OP_MENSUAL.Text = 0
                TCOSTO_FIJO.Text = 0 : TDEPRECIACION.Text = 0 : TFLETE_MENSUAL.Text = 0 : TKMS_MENSUAL.Text = 0 : TUTILIDAD_MENSUAL.Text = 0 : TISR.Text = 0
                TUTILIDAD_NETA_MES.Text = 0
                Lt7.Text = "" : Lt8.Text = "" : Lt9.Text = "" : Lt10.Text = "" : Lt11.Text = "" : Lt12.Text = "" : Lt13.Text = "" : Lt14.Text = ""
            Catch ex As Exception
            End Try

            ENTRA_TXT = False
            If Var1 = "Nuevo" Then
                Try
                    NewRecord = True
                    TCVE_COT.Text = GET_MAX("GCCOTIZADOR", "CVE_COT")
                    TCVE_COT.Enabled = False
                    BarImprimir.Enabled = False
                    BarCancelar.Enabled = False

                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                               "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                    Fg.Row = Fg.Rows.Count - 1

                    TCLIENTE.Select()
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("20. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try

            Else
                Try
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    cmd.Connection = cnSAE

                    SQL = "SELECT C.CVE_COT, C.CLIENTE, C.FECHA, C.COSTOS_FIJOS1, C.DEPRE1, C.COSTOS_FIJOS2, C.DEPRE2, C.COSTOS_FIJOS3, C.DEPRE3, C.UNI_ACTIVAS, " &
                        "C.NUM_CIRCUITOS, C.DIAS_ANALISIS, C.DIAS_NATURALES, C.PRECIO_X_LT_DIESEL, C.PRECIO_DIESEL_SINIVA, C.PORC_MANIOBRAS, C.TOTAL_COSTO_OP, " &
                        "C.COSTO_OP_MENSUAL, C.COSTO_FIJO, C.DEPRECIACION, C.FLETE_MENSUAL, C.KMS_MENSUAL, C.UTILIDAD_MENSUAL, C.ISR, C.UTILIDAD_NETA_MES, C.FECHAELAB " &
                        "FROM GCCOTIZADOR C " &
                        "WHERE CVE_COT = '" & Var2 & "'"
                    cmd.CommandText = SQL
                    dr = cmd.ExecuteReader

                    If dr.Read Then
                        TCVE_COT.Text = dr.ReadNullAsEmptyString("CVE_COT").ToString
                        TCLIENTE.Text = dr.ReadNullAsEmptyString("CLIENTE").ToString
                        F1.Value = dr.ReadNullAsEmptyString("FECHA").ToString

                        TCOSTOS_FIJOS1.Text = dr.ReadNullAsEmptyDecimal("COSTOS_FIJOS1").ToString
                        TDEPRE1.Text = dr.ReadNullAsEmptyDecimal("DEPRE1").ToString
                        TDEPRE1.Text = Format(CONVERTIR_TO_DECIMAL(TDEPRE1.Text), "###,###,##0.00")

                        TCOSTOS_FIJOS2.Text = dr.ReadNullAsEmptyDecimal("COSTOS_FIJOS2").ToString
                        TCOSTOS_FIJOS2.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS2.Text), "###,###,##0.00")

                        TCOSTOS_FIJOS3.Text = dr.ReadNullAsEmptyDecimal("COSTOS_FIJOS3").ToString
                        TCOSTOS_FIJOS3.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS3.Text), "###,###,##0.00")

                        TDEPRE3.Text = dr.ReadNullAsEmptyDecimal("DEPRE3").ToString
                        TDEPRE3.Text = Format(CONVERTIR_TO_DECIMAL(TDEPRE3.Text), "###,###,##0.00")

                        TNUM_CIRCUITO.Text = dr.ReadNullAsEmptyDecimal("NUM_CIRCUITOS").ToString
                        TUNI_ACTIVAS.Text = dr.ReadNullAsEmptyDecimal("UNI_ACTIVAS")
                        TDIAS_ANALISIS.Text = dr.ReadNullAsEmptyDecimal("DIAS_ANALISIS")
                        TDIAS_NATURALES.Text = dr.ReadNullAsEmptyInteger("DIAS_NATURALES").ToString

                        TDEPRE2.Text = dr.ReadNullAsEmptyDecimal("DEPRE2").ToString
                        TDEPRE2.Text = Format(CONVERTIR_TO_DECIMAL(TDEPRE2.Text), "###,###,##0.00")

                        TPRECIO_X_LT_DIESEL.Text = dr.ReadNullAsEmptyDecimal("PRECIO_X_LT_DIESEL").ToString
                        TPRECIO_DIESEL_SINIVA.Text = dr.ReadNullAsEmptyDecimal("PRECIO_DIESEL_SINIVA").ToString
                        TPRECIO_DIESEL_SINIVA.Text = Math.Round(TPRECIO_X_LT_DIESEL.Text / 1.16, 2)
                        TPORC_MANIOBRAS.Text = dr.ReadNullAsEmptyDecimal("PORC_MANIOBRAS").ToString

                        TTOTAL_COSTO_OP.Text = Format(dr.ReadNullAsEmptyDecimal("TOTAL_COSTO_OP").ToString, "###,###,##0.00")
                        TCOSTO_OP_MENSUAL.Text = Format(dr.ReadNullAsEmptyDecimal("COSTO_OP_MENSUAL").ToString, "###,###,##0.00")
                        TCOSTO_FIJO.Text = Format(dr.ReadNullAsEmptyDecimal("COSTO_FIJO").ToString, "###,###,##0.00")
                        TDEPRECIACION.Text = Format(dr.ReadNullAsEmptyDecimal("DEPRECIACION").ToString, "###,###,##0.00")
                        TFLETE_MENSUAL.Text = dr.ReadNullAsEmptyDecimal("FLETE_MENSUAL").ToString
                        TKMS_MENSUAL.Text = Format(dr.ReadNullAsEmptyDecimal("KMS_MENSUAL").ToString, "###,###,##0.00")
                        TUTILIDAD_MENSUAL.Text = Format(dr.ReadNullAsEmptyDecimal("UTILIDAD_MENSUAL").ToString, "###,###,##0.00")
                        TISR.Text = Format(dr.ReadNullAsEmptyDecimal("ISR").ToString, "###,###,##0.00")
                        TUTILIDAD_NETA_MES.Text = Format(dr.ReadNullAsEmptyDecimal("UTILIDAD_NETA_MES").ToString, "###,###,##0.00")
                    End If
                    dr.Close()

                    CARGAR_PARTIDAS_COT(TCVE_COT.Text)

                    Try
                        If CONVERTIR_TO_DECIMAL(TNUM_CIRCUITO.Text) > 0 Then
                            LtDiaDuraCir.Text = Math.Round(CONVERTIR_TO_DECIMAL(TDIAS_ANALISIS.Text) / CONVERTIR_TO_DECIMAL(TNUM_CIRCUITO.Text), 2)
                        End If
                    Catch ex As Exception
                        Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    BarCalcular_Click(Nothing, Nothing)

                    TCVE_COT.Enabled = False
                    BarCalcular.Enabled = False

                    F1.Enabled = False

                    'Var3 = Fg(Fg.Row, 2)'ESTATUS
                    Select Case Var3
                        Case "C"
                            C1SplitterPanel1.Enabled = False
                            C1SplitterPanel2.Enabled = False
                            BarCalcular.Enabled = False
                            BarCancelar.Enabled = False
                            BarGrabar.Enabled = False
                        Case "E"
                            C1SplitterPanel1.Enabled = False
                            C1SplitterPanel2.Enabled = False
                            C1SplitterPanel3.Enabled = False
                        Case "A"
                            C1SplitterPanel1.Enabled = True
                            C1SplitterPanel2.Enabled = True
                            C1SplitterPanel3.Enabled = True
                    End Select
                    TCOSTOS_FIJOS1.Select()

                Catch ex As Exception
                    MsgBox("25. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    Bitacora("25. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
        ENTRA_TXT = True

    End Sub
    Sub CARGAR_PARTIDAS_COT(fCVE_COT As String)
        Try
            ENTRA = False

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ORIGEN AS CVE_ORI, ISNULL(P1.CIUDAD,'') AS CIU_ORI, CVE_DESTINO AS CVE_DES, ISNULL(P2.CIUDAD,'') AS CIU_DES, KMS, " &
                    "KMS_MANIOBRAS AS KMS_MAN, FLETE, SALDOS_OP AS SAL_OP, LTS_DIESEL AS LTS_DIE, REND, COSTO_DIESEL AS COST_DIE, " &
                    "CASETAS_SIN_IVA AS CAS_SIN_IVA, C.UUID " &
                    "FROM GCCOTIZADOR_PAR C " &
                    "LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C.CVE_ORIGEN " &
                    "LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = C.CVE_DESTINO " &
                    "WHERE CVE_COT  = '" & fCVE_COT & "' AND C.STATUS <> 'B'"
                cmd.CommandText = SQL
                Fg.Rows.Count = 1
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_ORI") & vbTab & "" & vbTab & dr("CIU_ORI") & vbTab & dr("CVE_DES") & vbTab & "" & vbTab &
                                       dr("CIU_DES") & vbTab & dr("KMS") & vbTab & dr("KMS_MAN") & vbTab & dr("FLETE") & vbTab & dr("SAL_OP") & vbTab &
                                       dr("LTS_DIE") & vbTab & dr("REND") & vbTab & dr("COST_DIE") & vbTab & dr("CAS_SIN_IVA") & vbTab & dr("UUID"))
                    End While
                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                               "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                    Fg.Row = Fg.Rows.Count - 1
                End Using
            End Using
            'Fg.AutoSizeCols()
            Fg.Cols(15).Width = 0
            ENTRA = True
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCotizaAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Salir = True
        Try
            CloseTab("Cotización")
            Me.Dispose()
            If FORM_IS_OPEN("frmCotizador") Then
                SQL = SQL1
                frmCotizador.DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnClie_Click(sender As Object, e As EventArgs) Handles BtnClie.Click
        Try
            Var2 = "Clientes"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4

                LLENA_CAMPOS(Var4)

                Var2 = ""
                Var4 = ""
                Var5 = ""
                TCOSTOS_FIJOS1.Focus()
            End If
        Catch ex As Exception
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("70. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Grabar"
                    GUARDAR()
                Case "Imrimir"

                Case "Cancelar"
                    If Fg.Row > 0 Then
                        If MsgBox("Realmente desea cancelar el documento " & TCVE_COT.Text & "?", vbYesNo) = vbYes Then
                            Var2 = Fg(Fg.Row, 1)
                            SQL = "UPDATE GCCOTIZADOR SET STATUS = 'C' WHERE CVE_COT = '" & TCVE_COT.Text & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        MsgBox("La cotización se cancelo satisfactoriamente")
                                        Me.Close()
                                    End If
                                End If
                            End Using
                        End If
                    Else
                        MsgBox("Por favor seleccione un registro")
                    End If
                Case "Salir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            If IsNumeric(TCLIENTE.Text.Trim) Then
                TCLIENTE.Text = Space(10 - TCLIENTE.Text.Trim.Length) & TCLIENTE.Text.Trim
            End If
            TCOSTOS_FIJOS1.Focus()
        End If
    End Sub
    Private Sub TCLIENTE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCLIENTE.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        End If
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 And Not Salir Then

                LLENA_CAMPOS(TCLIENTE.Text)

            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLIENTE_Leave(sender As Object, e As EventArgs) Handles TCLIENTE.Leave
        'If tCLIENTE.Text.Trim.Length = 0 And Not Salir Then
        'MessageBox.Show("Por favor capture la clave del cliente")
        'Return
        'End If
    End Sub
    Sub LLENA_CAMPOS(ByVal fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If IsNumeric(fCLAVE.Trim) Then
                fCLAVE = Space(10 - fCLAVE.Trim.Length) & fCLAVE.Trim
                TCLIENTE.Text = fCLAVE
            End If

            cmd.Connection = cnSAE
            SQL = "SELECT NOMBRE, CALLE, COLONIA, NUMINT, NUMEXT, CODIGO, RFC, MUNICIPIO, ESTADO, ISNULL(LISTA_PREC,1) AS PRECIO " &
                "FROM CLIE" & Empresa & " WHERE CLAVE  = '" & fCLAVE & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                LtNombre.Text = dr("NOMBRE").ToString
                'LtCalle.Text = dr("CALLE").ToString
                'LtColonia.Text = dr("COLONIA").ToString
                'LtNumInt.Text = dr("NUMINT").ToString
                'LtNumExt.Text = dr("NUMEXT").ToString
                'LtCP.Text = dr("CODIGO").ToString
                'LtRFC.Text = dr("RFC").ToString
                'LtPoblacion.Text = dr("MUNICIPIO").ToString
                'LtEstado.Text = dr("ESTADO").ToString
            Else
                MsgBox("Cliente inexistente")
                TCLIENTE.Text = ""
                TCLIENTE.Select()
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("140 " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GUARDAR()
        ENTRA_TXT = False

        If TCLIENTE.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el cliente que paga")
            TCLIENTE.Select()
            Return
        End If
        BarCalcular_Click(Nothing, Nothing)

        If NewRecord Then
            TCVE_COT.Text = GET_MAX("GCCOTIZADOR", "CVE_COT")
        End If

        Try
            SQL = "UPDATE GCCOTIZADOR SET CLIENTE = @CLIENTE, COSTOS_FIJOS1 = @COSTOS_FIJOS1, DEPRE1 = @DEPRE1, COSTOS_FIJOS2 = @COSTOS_FIJOS2, DEPRE2 = @DEPRE2, " &
                "COSTOS_FIJOS3 = @COSTOS_FIJOS3, DEPRE3 = @DEPRE3, UNI_ACTIVAS = @UNI_ACTIVAS, NUM_CIRCUITOS = @NUM_CIRCUITOS, DIAS_ANALISIS = @DIAS_ANALISIS, " &
                "DIAS_NATURALES = @DIAS_NATURALES, PRECIO_X_LT_DIESEL = @PRECIO_X_LT_DIESEL, PRECIO_DIESEL_SINIVA = @PRECIO_DIESEL_SINIVA, " &
                "PORC_MANIOBRAS = @PORC_MANIOBRAS, TOTAL_COSTO_OP = @TOTAL_COSTO_OP, COSTO_OP_MENSUAL = @COSTO_OP_MENSUAL, COSTO_FIJO = @COSTO_FIJO, " &
                "DEPRECIACION = @DEPRECIACION, FLETE_MENSUAL = @FLETE_MENSUAL, KMS_MENSUAL = @KMS_MENSUAL, UTILIDAD_MENSUAL = @UTILIDAD_MENSUAL, " &
                "ISR = @ISR, UTILIDAD_NETA_MES = @UTILIDAD_NETA_MES, REND_G = @REND_G, DIAS_DURA_CIRC = @DIAS_DURA_CIRC " &
                "WHERE CVE_COT = @CVE_COT " &
                "IF @@ROWCOUNT = 0 " &
                "INSERT INTO GCCOTIZADOR (CVE_COT, STATUS, CLIENTE, FECHA, COSTOS_FIJOS1, DEPRE1, COSTOS_FIJOS2, DEPRE2, COSTOS_FIJOS3, DEPRE3, UNI_ACTIVAS, " &
                "NUM_CIRCUITOS, DIAS_ANALISIS, DIAS_NATURALES, PRECIO_X_LT_DIESEL, PRECIO_DIESEL_SINIVA, PORC_MANIOBRAS, TOTAL_COSTO_OP, COSTO_OP_MENSUAL, COSTO_FIJO, " &
                "DEPRECIACION, FLETE_MENSUAL, KMS_MENSUAL, UTILIDAD_MENSUAL, ISR, UTILIDAD_NETA_MES, REND_G, DIAS_DURA_CIRC, FECHAELAB)  VALUES(@CVE_COT, 'E'," &
                "@CLIENTE, @FECHA, @COSTOS_FIJOS1, @DEPRE1, @COSTOS_FIJOS2, @DEPRE2, @COSTOS_FIJOS3, @DEPRE3, @UNI_ACTIVAS, @NUM_CIRCUITOS, @DIAS_ANALISIS, " &
                "@DIAS_NATURALES, @PRECIO_X_LT_DIESEL, @PRECIO_DIESEL_SINIVA, @PORC_MANIOBRAS, @TOTAL_COSTO_OP, @COSTO_OP_MENSUAL, @COSTO_FIJO, " &
                "@DEPRECIACION, @FLETE_MENSUAL, @KMS_MENSUAL, @UTILIDAD_MENSUAL, @ISR, @UTILIDAD_NETA_MES, @REND_G, @DIAS_DURA_CIRC, GETDATE())"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_COT", SqlDbType.VarChar).Value = TCVE_COT.Text
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLIENTE.Text
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                cmd.Parameters.Add("@COSTOS_FIJOS1", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS1.Text), 2)
                cmd.Parameters.Add("@DEPRE1", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TDEPRE1.Text), 2)
                cmd.Parameters.Add("@COSTOS_FIJOS2", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS2.Text), 2)
                cmd.Parameters.Add("@DEPRE2", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TDEPRE2.Text), 2)
                cmd.Parameters.Add("@COSTOS_FIJOS3", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS3.Text), 2)
                cmd.Parameters.Add("@DEPRE3", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TDEPRE3.Text), 2)
                cmd.Parameters.Add("@UNI_ACTIVAS", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TUNI_ACTIVAS.Text)
                cmd.Parameters.Add("@NUM_CIRCUITOS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TNUM_CIRCUITO.Text)
                cmd.Parameters.Add("@DIAS_ANALISIS", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TDIAS_ANALISIS.Text)
                cmd.Parameters.Add("@DIAS_NATURALES", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TDIAS_NATURALES.Text)
                cmd.Parameters.Add("@PRECIO_X_LT_DIESEL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TPRECIO_X_LT_DIESEL.Text), 2)
                cmd.Parameters.Add("@PRECIO_DIESEL_SINIVA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TPRECIO_DIESEL_SINIVA.Text), 2)
                cmd.Parameters.Add("@PORC_MANIOBRAS", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TPORC_MANIOBRAS.Text), 2)
                cmd.Parameters.Add("@TOTAL_COSTO_OP", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TTOTAL_COSTO_OP.Text), 2)
                cmd.Parameters.Add("@COSTO_OP_MENSUAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCOSTO_OP_MENSUAL.Text), 2)
                cmd.Parameters.Add("@COSTO_FIJO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCOSTO_FIJO.Text), 2)
                cmd.Parameters.Add("@DEPRECIACION", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TDEPRECIACION.Text), 2)
                cmd.Parameters.Add("@FLETE_MENSUAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TFLETE_MENSUAL.Text), 2)
                cmd.Parameters.Add("@KMS_MENSUAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TKMS_MENSUAL.Text), 2)
                cmd.Parameters.Add("@UTILIDAD_MENSUAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TUTILIDAD_MENSUAL.Text), 2)
                cmd.Parameters.Add("@ISR", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TISR.Text), 2)
                cmd.Parameters.Add("@UTILIDAD_NETA_MES", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TUTILIDAD_NETA_MES.Text), 2)
                cmd.Parameters.Add("@REND_G", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Lt12.Text), 2)
                cmd.Parameters.Add("@DIAS_DURA_CIRC", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtDiaDuraCir.Text), 2)

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        GRABAR_PARTIDAS()
                        MsgBox("El registro se grabo satisfactoriamente")
                        Me.Close()
                    Else
                        MsgBox("No se logro grabar el registro")
                    End If
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            End Using
        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_PARTIDAS()
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "UPDATE GCCOTIZADOR_PAR SET STATUS = 'C' WHERE CVE_COT = '" & TCVE_COT.Text & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                For k = 1 To Fg.Rows.Count - 1
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            If Fg(k, 1).ToString.Length > 0 Then
                                Try
                                    SQL = "UPDATE GCCOTIZADOR_PAR SET CVE_ORIGEN = @CVE_ORIGEN, STATUS = 'A', CVE_DESTINO = @CVE_DESTINO, KMS = @KMS, KMS_MANIOBRAS = @KMS_MANIOBRAS, " &
                                        "FLETE = @FLETE, SALDOS_OP = @SALDOS_OP, LTS_DIESEL = @LTS_DIESEL, REND = @REND, COSTO_DIESEL = @COSTO_DIESEL, CASETAS_SIN_IVA = @CASETAS_SIN_IVA " &
                                        "WHERE CVE_COT = @CVE_COT AND UUID = '" & Fg(k, 15) & "' " &
                                        "IF @@ROWCOUNT = 0 " &
                                        "INSERT INTO GCCOTIZADOR_PAR (CVE_COT, STATUS, CVE_ORIGEN, CVE_DESTINO, KMS, KMS_MANIOBRAS, FLETE, SALDOS_OP, LTS_DIESEL, REND, " &
                                        "COSTO_DIESEL, CASETAS_SIN_IVA, FECHAELAB, UUID) VALUES(@CVE_COT, 'A', @CVE_ORIGEN, @CVE_DESTINO, @KMS, @KMS_MANIOBRAS, @FLETE, " &
                                        "@SALDOS_OP, @LTS_DIESEL, @REND, @COSTO_DIESEL, @CASETAS_SIN_IVA, GETDATE(), NEWID())"
                                    cmd.CommandText = SQL
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("@CVE_COT", SqlDbType.VarChar).Value = TCVE_COT.Text
                                    cmd.Parameters.Add("@CVE_ORIGEN", SqlDbType.Int).Value = CONVERTIR_TO_INT(Fg(k, 1))
                                    cmd.Parameters.Add("@CVE_DESTINO", SqlDbType.Int).Value = CONVERTIR_TO_INT(Fg(k, 4))
                                    cmd.Parameters.Add("@KMS", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 7)), 2)
                                    cmd.Parameters.Add("@KMS_MANIOBRAS", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 8)), 2)
                                    cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 9)), 2)
                                    cmd.Parameters.Add("@SALDOS_OP", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 10)), 2)
                                    cmd.Parameters.Add("@LTS_DIESEL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 11)), 2)
                                    cmd.Parameters.Add("@REND", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 12)), 2)
                                    cmd.Parameters.Add("@COSTO_DIESEL", SqlDbType.SmallInt).Value = Math.Round(CONVERTIR_TO_INT(Fg(k, 13)), 2)
                                    cmd.Parameters.Add("@CASETAS_SIN_IVA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 14)), 2)
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                Catch ex As Exception
                                    MsgBox("180. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    Bitacora("180. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                End Try
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            End Using
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub TCLIENTE_GotFocus(sender As Object, e As EventArgs) Handles TCLIENTE.GotFocus
        TCLIENTE.SelectAll()
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        If Fg.Row > 0 Then
            If Fg.Col = 2 Then
                Try
                    ENTRA_BTN = False
                    Var2 = "Plazas"
                    Var4 = "" : Var5 = ""
                    Fg.FinishEditing()
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        'Var4 = Fg(Fg.Row, 1) CLAVE
                        'Var5 = Fg(Fg.Row, 2) CIUDAD
                        'Var6 = Fg(Fg.Row, 3) MUNICIPIO
                        ENTRA = False
                        Fg.FinishEditing()
                        Fg(Fg.Row, 1) = Var4
                        Fg(Fg.Row, 3) = Var5
                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 4
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(e.Row, 4)
                        End If
                    Else
                        Fg.Col = 1
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(e.Row, 1)
                        End If
                    End If
                    ENTRA_BTN = True
                Catch ex As Exception
                    MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Return
            End If
            If Fg.Col = 5 Then
                Try
                    ENTRA_BTN = False
                    Var2 = "Plazas"
                    Var4 = "" : Var5 = ""
                    Fg.FinishEditing()
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        'Var4 = Fg(Fg.Row, 1) CLAVE
                        'Var5 = Fg(Fg.Row, 2) CIUDAD
                        'Var6 = Fg(Fg.Row, 3) MUNICIPIO
                        ENTRA = False
                        Fg.FinishEditing()
                        Fg(Fg.Row, 4) = Var4
                        Fg(Fg.Row, 6) = Var5
                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 7
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(e.Row, 7)
                        End If
                    Else
                        Fg.Col = 1
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(e.Row, 1)
                        End If
                    End If
                    ENTRA_BTN = True
                Catch ex As Exception
                    MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        End If
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If ENTRA Then
                If Fg.Row > 0 Then
                    If Fg.Col = 3 Or Fg.Col = 6 Or Fg.Col = 8 Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If ENTRA Then
                If Fg.Col = 1 Or Fg.Col = 5 Then
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
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_StartEdit(sender As Object, e As RowColEventArgs) Handles Fg.StartEdit
        Try
            If ENTRA Then
                If Fg.Col = 3 Or Fg.Col = 6 Or Fg.Col = 8 Then
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
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
        Try
            If ENTRA Then
                _myEditor.SetPendingKey(e.KeyChar)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                '8 11 13
                If Fg.Col = 1 Or Fg.Col = 4 Or Fg.Col = 7 Or Fg.Col = 9 Or Fg.Col = 10 Or Fg.Col = 12 Or Fg.Col = 14 Then
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

            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBotonMagico_GotFocus(sender As Object, e As EventArgs) Handles TBotonMagico.GotFocus
        Try
            Fg.Select()
            Dim c_ As Integer
            If Fg.Col = 2 Then
                c_ = 1
            Else
                c_ = Fg.Col
            End If
            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, c_)
            End If
        Catch ex As Exception
            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAltaProducto_Click(sender As Object, e As EventArgs) Handles BtnAltaProducto.Click
        Try
            If Fg(Fg.Rows.Count - 1, 1).ToString.Trim.Length > 0 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                               "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
            End If
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, 1)
            End If
        Catch ex As Exception
            MsgBox("840. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("840. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnEliProd_Click(sender As Object, e As EventArgs) Handles BtnEliProd.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                    Fg.RemoveItem(Fg.Row)
                    If Fg(Fg.Rows.Count - 1, 1).ToString.Trim.Length > 0 And Fg(Fg.Rows.Count - 1, 4).ToString.Trim.Length > 0 And Fg(Fg.Rows.Count - 1, 7).ToString.Trim.Length > 0 Then
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                               "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                    End If
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 1
                    If Not IsNothing(_myEditor) Then
                        _myEditor.StartEditing(Fg.Row, 1)
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCOSTOS_FIJOS1_TextChanged(sender As Object, e As EventArgs) Handles TCOSTOS_FIJOS1.TextChanged
        Try
            Dim COSTOS_FIJOS1 As Single = 0, UNI_ACTIVAS As Single = 0
            Dim COSTOS_FIJOS2 As Single = 0, DIAS_NATURALES As Single = 0

            If IsNumeric(TCOSTOS_FIJOS1.Text) Then COSTOS_FIJOS1 = TCOSTOS_FIJOS1.Text
            If IsNumeric(TCOSTOS_FIJOS2.Text) Then COSTOS_FIJOS2 = TCOSTOS_FIJOS2.Text
            If IsNumeric(TUNI_ACTIVAS.Text) Then UNI_ACTIVAS = TUNI_ACTIVAS.Text
            If IsNumeric(TDIAS_NATURALES.Text) Then DIAS_NATURALES = TDIAS_NATURALES.Text

            If UNI_ACTIVAS > 0 Then TCOSTOS_FIJOS2.Text = Math.Round(COSTOS_FIJOS1 / UNI_ACTIVAS, 2)
            If DIAS_NATURALES > 0 Then TCOSTOS_FIJOS3.Text = Math.Round(COSTOS_FIJOS2 / DIAS_NATURALES, 2)
            TCOSTOS_FIJOS2.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS2.Text), "###,###,##0.00")
            TCOSTOS_FIJOS3.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS3.Text), "###,###,##0.00")
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TDEPRE1_TextChanged(sender As Object, e As EventArgs) Handles TDEPRE1.TextChanged
        Try
            If IsNumeric(TDEPRE1.Text) And IsNumeric(TUNI_ACTIVAS.Text) Then
                If CONVERTIR_TO_DECIMAL(TUNI_ACTIVAS.Text) > 0 Then
                    TDEPRE2.Text = Math.Round(TDEPRE1.Text / TUNI_ACTIVAS.Text, 2)
                    TDEPRE2.Text = Format(CONVERTIR_TO_DECIMAL(TDEPRE2.Text), "###,###,##0.00")
                End If
            End If
            If IsNumeric(TDEPRE2.Text) And IsNumeric(TDIAS_NATURALES.Text) Then
                If CONVERTIR_TO_DECIMAL(TDIAS_NATURALES.Text) > 0 Then
                    TDEPRE3.Text = Math.Round(TDEPRE2.Text / TDIAS_NATURALES.Text, 2)
                    TDEPRE3.Text = Format(CONVERTIR_TO_DECIMAL(TDEPRE3.Text), "###,###,##0.00")
                End If
            End If
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPRECIO_X_LT_DIESEL_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_X_LT_DIESEL.TextChanged
        ENTRA_TXT = False
        ENTRA = False
        Try
            If Fg.Row > 0 Then
                If IsNumeric(TPRECIO_X_LT_DIESEL.Text) Then
                    TPRECIO_DIESEL_SINIVA.Text = Math.Round(TPRECIO_X_LT_DIESEL.Text / 1.16, 2)
                    If Not IsNothing(Fg(Fg.Row, 11)) Then
                        Fg(Fg.Row, 13) = Math.Round(Fg(Fg.Row, 11) * (TPORC_MANIOBRAS.Text / 100), 2)
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA_TXT = True
        ENTRA = True
    End Sub
    Private Sub TPRECIO_X_LT_DIESEL_Validated(sender As Object, e As EventArgs) Handles TPRECIO_X_LT_DIESEL.Validated
        ENTRA = False
        Try
            If Fg.Row > 0 Then
                If IsNumeric(TPRECIO_X_LT_DIESEL.Text) And ENTRA_TXT Then
                    TPRECIO_DIESEL_SINIVA.Text = Math.Round(TPRECIO_X_LT_DIESEL.Text / 1.16, 2)
                    If Not IsNothing(Fg(Fg.Row, 11)) Then
                        If IsNumeric(TPORC_MANIOBRAS.Text) Then
                            Fg(Fg.Row, 13) = Math.Round(Fg(Fg.Row, 11) * (TPORC_MANIOBRAS.Text / 100), 2)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub TPORC_MANIOBRAS_TextChanged(sender As Object, e As EventArgs) Handles TPORC_MANIOBRAS.TextChanged
        ENTRA = False
        Try
            If Fg.Row > 0 Then
                If IsNumeric(TPORC_MANIOBRAS.Text) Then
                    If Not IsNothing(Fg(Fg.Row, 7)) Then
                        Fg(Fg.Row, 8) = Fg(Fg.Row, 7) * (TPORC_MANIOBRAS.Text / 100)
                    End If
                End If
            End If

        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub TPORC_MANIOBRAS_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TPORC_MANIOBRAS.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, 1)
                End If
                Fg.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarCalcular_Click(sender As Object, e As ClickEventArgs) Handles BarCalcular.Click
        Try
            SUMA_FG()
            TTOTAL_COSTO_OP.Text = VALIDA_FG(Lt10.Text) + VALIDA_FG(Lt13.Text) + VALIDA_FG(Lt14.Text)
            TCOSTO_OP_MENSUAL.Text = VALIDA_FG(TTOTAL_COSTO_OP.Text) * VALIDA_FG(TNUM_CIRCUITO.Text)

            TCOSTO_FIJO.Text = VALIDA_FG(TDIAS_ANALISIS.Text) * VALIDA_FG(TCOSTOS_FIJOS3.Text)
            TDEPRECIACION.Text = VALIDA_FG(TDEPRE3.Text) * VALIDA_FG(TDIAS_ANALISIS.Text)
            TCOSTOS_TOTALES.Text = VALIDA_FG(TCOSTO_OP_MENSUAL.Text) + VALIDA_FG(TCOSTO_FIJO.Text) + VALIDA_FG(TDEPRECIACION.Text)

            TFLETE_MENSUAL.Text = VALIDA_FG(Lt9.Text) * VALIDA_FG(TNUM_CIRCUITO.Text)

            TKMS_MENSUAL.Text = VALIDA_FG(Lt8.Text) * VALIDA_FG(TNUM_CIRCUITO.Text)

            TUTILIDAD_MENSUAL.Text = VALIDA_FG(TFLETE_MENSUAL.Text) - VALIDA_FG(TCOSTOS_TOTALES.Text)
            TISR.Text = VALIDA_FG(TUTILIDAD_MENSUAL.Text) * 0.3
            TUTILIDAD_NETA_MES.Text = VALIDA_FG(TUTILIDAD_MENSUAL.Text) - VALIDA_FG(TISR.Text)

            TTOTAL_COSTO_OP.Text = Format(VALIDA_FG(TTOTAL_COSTO_OP.Text), "###,###,##0.00")
            TCOSTO_OP_MENSUAL.Text = Format(VALIDA_FG(TCOSTO_OP_MENSUAL.Text), "###,###,##0.00")
            TCOSTO_FIJO.Text = Format(VALIDA_FG(TCOSTO_FIJO.Text), "###,###,##0.00")
            TDEPRECIACION.Text = Format(VALIDA_FG(TDEPRECIACION.Text), "###,###,##0.00")
            TCOSTOS_TOTALES.Text = Format(VALIDA_FG(TCOSTOS_TOTALES.Text), "###,###,##0.00")
            TKMS_MENSUAL.Text = Format(VALIDA_FG(TKMS_MENSUAL.Text), "###,###,##0.00")
            TUTILIDAD_MENSUAL.Text = Format(VALIDA_FG(TUTILIDAD_MENSUAL.Text), "###,###,##0.00")
            TISR.Text = Format(VALIDA_FG(TISR.Text), "###,###,##0.00")
            TUTILIDAD_NETA_MES.Text = Format(VALIDA_FG(TUTILIDAD_NETA_MES.Text), "###,###,##0.00")

        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub SUMA_FG()
        Dim C7 As Decimal = 0, C8 As Decimal = 0, C9 As Decimal = 0, C10 As Decimal = 0, C11 As Decimal = 0, C12 As Decimal = 0, C13 As Decimal = 0, C14 As Decimal = 0
        Try
            For k = 1 To Fg.Rows.Count - 1
                C7 += VALIDA_FG(Fg(k, 7))
                C8 += VALIDA_FG(Fg(k, 8))
                C9 += VALIDA_FG(Fg(k, 9))
                C10 += VALIDA_FG(Fg(k, 10))
                C11 += VALIDA_FG(Fg(k, 11))
                C12 += VALIDA_FG(Fg(k, 12))
                C13 += VALIDA_FG(Fg(k, 13))
                C14 += VALIDA_FG(Fg(k, 14))
            Next
            Lt7.Text = Format(C7, "###,###,##0.00")
            Lt8.Text = Format(C8, "###,###,##0.00")
            Lt9.Text = Format(C9, "###,###,##0.00")
            Lt10.Text = Format(C10, "###,###,##0.00")
            Lt11.Text = Format(C11, "###,###,##0.00")
            If C11 > 0 Then
                Lt12.Text = Format(C8 / C11, "###,###,##0.00")
            End If
            Lt13.Text = Format(C13, "###,###,##0.00")
            Lt14.Text = Format(C14, "###,###,##0.00")

        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCOSTOS_FIJOS1_Validated(sender As Object, e As EventArgs) Handles TCOSTOS_FIJOS1.Validated
        Try
            Dim COSTOS_FIJOS1 As Single = 0, UNI_ACTIVAS As Single = 0
            Dim COSTOS_FIJOS2 As Single = 0, DIAS_NATURALES As Single = 0

            If IsNumeric(TCOSTOS_FIJOS1.Text) Then COSTOS_FIJOS1 = TCOSTOS_FIJOS1.Text
            If IsNumeric(TCOSTOS_FIJOS2.Text) Then COSTOS_FIJOS2 = TCOSTOS_FIJOS2.Text
            If IsNumeric(TUNI_ACTIVAS.Text) Then UNI_ACTIVAS = TUNI_ACTIVAS.Text
            If IsNumeric(TDIAS_NATURALES.Text) Then DIAS_NATURALES = TDIAS_NATURALES.Text

            If UNI_ACTIVAS > 0 Then TCOSTOS_FIJOS2.Text = Math.Round(COSTOS_FIJOS1 / UNI_ACTIVAS, 2)
            If DIAS_NATURALES > 0 Then TCOSTOS_FIJOS3.Text = Math.Round(COSTOS_FIJOS2 / DIAS_NATURALES, 2)

            TCOSTOS_FIJOS2.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS2.Text), "###,###,##0.00")
            TCOSTOS_FIJOS3.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS3.Text), "###,###,##0.00")
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TDEPRE1_Validated(sender As Object, e As EventArgs) Handles TDEPRE1.Validated
        Try
            If IsNumeric(TDEPRE1.Text) And IsNumeric(TUNI_ACTIVAS.Text) Then
                If CONVERTIR_TO_DECIMAL(TUNI_ACTIVAS.Text) Then
                    TDEPRE2.Text = Math.Round(TDEPRE1.Text / TUNI_ACTIVAS.Text, 2)
                    TDEPRE2.Text = Format(CONVERTIR_TO_DECIMAL(TDEPRE2.Text), "###,###,##0.00")
                End If
            End If
            If IsNumeric(TDEPRE2.Text) And IsNumeric(TDIAS_NATURALES.Text) Then
                If CONVERTIR_TO_DECIMAL(TDIAS_NATURALES.Text) > 0 Then
                    TDEPRE3.Text = Math.Round(TDEPRE2.Text / TDIAS_NATURALES.Text, 2)
                    TDEPRE3.Text = Format(CONVERTIR_TO_DECIMAL(TDEPRE3.Text), "###,###,##0.00")
                End If
            End If
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPORC_MANIOBRAS_Validated(sender As Object, e As EventArgs) Handles TPORC_MANIOBRAS.Validated
        ENTRA = False
        Dim PORC As Single
        PORC = TPORC_MANIOBRAS.Text
        Try
            If IsNumeric(TPORC_MANIOBRAS.Text) And ENTRA_TXT Then
                For k = 1 To Fg.Rows.Count - 1
                    If Not IsNothing(Fg(k, 7)) Then
                        If Not String.IsNullOrEmpty(Fg(k, 7)) Then
                            Fg(k, 8) = Fg(k, 7) * (CONVERTIR_TO_DECIMAL(PORC) / 100)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub TUNI_ACTIVAS_TextChanged(sender As Object, e As EventArgs) Handles TUNI_ACTIVAS.TextChanged
        Try
            Dim COSTOS_FIJOS1 As Single = 0, UNI_ACTIVAS As Single = 0
            Dim COSTOS_FIJOS2 As Single = 0, DIAS_NATURALES As Single = 0

            If IsNumeric(TCOSTOS_FIJOS1.Text) Then COSTOS_FIJOS1 = TCOSTOS_FIJOS1.Text
            If IsNumeric(TCOSTOS_FIJOS2.Text) Then COSTOS_FIJOS2 = TCOSTOS_FIJOS2.Text
            If IsNumeric(TUNI_ACTIVAS.Text) Then UNI_ACTIVAS = TUNI_ACTIVAS.Text
            If IsNumeric(TDIAS_NATURALES.Text) Then DIAS_NATURALES = TDIAS_NATURALES.Text

            If UNI_ACTIVAS > 0 Then TCOSTOS_FIJOS2.Text = Math.Round(COSTOS_FIJOS1 / UNI_ACTIVAS, 2)
            If DIAS_NATURALES > 0 Then TCOSTOS_FIJOS3.Text = Math.Round(COSTOS_FIJOS2 / DIAS_NATURALES, 2)
            TCOSTOS_FIJOS2.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS2.Text), "###,###,##0.00")
            TCOSTOS_FIJOS3.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS3.Text), "###,###,##0.00")

            If CONVERTIR_TO_DECIMAL(TUNI_ACTIVAS.Text) > 0 Then
                TDEPRE2.Text = TDEPRE1.Text / CONVERTIR_TO_DECIMAL(TUNI_ACTIVAS.Text)
                TDEPRE2.Text = Format(CONVERTIR_TO_DECIMAL(TDEPRE2.Text), "###,###,##0.00")
            End If

        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TDIAS_NATURALES_TextChanged(sender As Object, e As EventArgs) Handles TDIAS_NATURALES.TextChanged
        Try
            Dim COSTOS_FIJOS1 As Single = 0, UNI_ACTIVAS As Single = 0
            Dim COSTOS_FIJOS2 As Single = 0, DIAS_NATURALES As Single = 0

            If IsNumeric(TCOSTOS_FIJOS1.Text) Then COSTOS_FIJOS1 = TCOSTOS_FIJOS1.Text
            If IsNumeric(TCOSTOS_FIJOS2.Text) Then COSTOS_FIJOS2 = TCOSTOS_FIJOS2.Text
            If IsNumeric(TUNI_ACTIVAS.Text) Then UNI_ACTIVAS = TUNI_ACTIVAS.Text
            If IsNumeric(TDIAS_NATURALES.Text) Then
                DIAS_NATURALES = TDIAS_NATURALES.Text
            End If

            If UNI_ACTIVAS > 0 Then TCOSTOS_FIJOS2.Text = Math.Round(COSTOS_FIJOS1 / UNI_ACTIVAS, 2)
            If DIAS_NATURALES > 0 Then TCOSTOS_FIJOS3.Text = Math.Round(COSTOS_FIJOS2 / DIAS_NATURALES, 2)
            TCOSTOS_FIJOS2.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS2.Text), "###,###,##0.00")
            TCOSTOS_FIJOS3.Text = Format(CONVERTIR_TO_DECIMAL(TCOSTOS_FIJOS3.Text), "###,###,##0.00")
            If DIAS_NATURALES > 0 Then TDEPRE3.Text = Format(CONVERTIR_TO_DECIMAL(TDEPRE2.Text) / CONVERTIR_TO_DECIMAL(DIAS_NATURALES), "###,###,##0.00")
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim RUTA_FORMATOS As String = ""
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportCotizador.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportCotizador.mrt, verifique por favor")
                Return
            End If

            StiReport1.Load(RUTA_FORMATOS & "\ReportCotizador.mrt")

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("PREREP", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = TCVE_COT.Text
            StiReport1.Render()
            'StiReport1.Print(True)
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
            MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TNUM_CIRCUITO_TextChanged(sender As Object, e As EventArgs) Handles TNUM_CIRCUITO.TextChanged
        Dim NUM_CIR As Single

        Try
            NUM_CIR = TNUM_CIRCUITO.Text
            If NUM_CIR > 0 Then
                LtDiaDuraCir.Text = Math.Round(CONVERTIR_TO_DECIMAL(TDIAS_ANALISIS.Text) / CONVERTIR_TO_DECIMAL(NUM_CIR), 2)
            End If
        Catch ex As Exception
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TDIAS_ANALISIS_TextChanged(sender As Object, e As EventArgs) Handles TDIAS_ANALISIS.TextChanged
        Try
            If CONVERTIR_TO_DECIMAL(TNUM_CIRCUITO.Text) > 0 Then
                LtDiaDuraCir.Text = Math.Round(CONVERTIR_TO_DECIMAL(TDIAS_ANALISIS.Text) / CONVERTIR_TO_DECIMAL(TNUM_CIRCUITO.Text), 2)
            End If
        Catch ex As Exception
            Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditorCot
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid)
        MyBase.New()
        Visible = False
        AutoSize = False
        BackColor = Color.Beige
        BorderStyle = BorderStyle.FixedSingle

        _pendingKey = Chr(0)
        _cancel = False
        _owner = owner
        _owner.Controls.Add(Me)
        _owner.Cols(6).EditMask = "999,999,999.99"
        _owner.Cols(7).EditMask = "999,999,999.99"
    End Sub
    'comenzar a editar: mover a la celda y activar
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        'save coordinates of cell being edited
        'guardar las coordenadas de la celda que se está editando
        If col = 1 And keyRec = 9 Then
            MyBase.Visible = True
            _owner.Select()
            _owner.StartEditing()
            Return
        End If
        If col = 1 And keyRec = 99 Then
            _owner.Select(1, 1)
            _owner.Row = 1
            _owner.Col = 1
            MoveCursor(Keys.Enter)
            _owner.Rows.Count = 1
            Return
        End If
        If col = 99 Then
            _owner.Col = 1
            FrmCotizaAE.TBotonMagico.Focus()
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

        rc.Width -= 1
        rc.Height -= 1

        MyBase.Bounds = rc
        'initialize control content
        'inicializar contenido de control

        MyBase.Text = ""
        If _pendingKey > " " Then
            MyBase.Text = _pendingKey.ToString()
        ElseIf _owner(row, col) IsNot Nothing Then
            MyBase.Text = _owner(row, col).ToString()
        End If

        MyBase.Select(Text.Length, 0)

        'make editor visible
        MyBase.Visible = True

        'and get the focus
        '_owner.Select(_row, 2)
        MyBase.Select()

        MyBase.SelectionStart = 0
        MyBase.SelectionLength = MyBase.TextLength

    End Sub
    Public Sub EndEdit(ByVal row As Integer, ByVal col As Integer)
        Try
            _owner.FinishEditing()
            _owner(row, col) = ""
            MyBase.Text = ""
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)
        If row > 0 Then
            If col = 1 Or col = 4 Then
                MyBase.Visible = True
            End If
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
        rcScroll.Width -= rcScroll.X
        rcScroll.Height -= rcScroll.Y
        rcCell = Rectangle.Intersect(rcCell, rcScroll)

        'y mueve el control
        If (rcCell.Width > 0) Then rcCell.Width -= 1
        If (rcCell.Height > 0) Then rcCell.Height -= 1
        MyBase.Bounds = rcCell
    End Sub
    'Foco perdido: ocultar el editor
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        Dim DIESEL As Decimal, PORC_MANIOBRAS As Single
        'AQUI ESTA EL ERROR DONDE SE BRINCA  LA CLAVE DEL CLIENTE
        If _col = 99 Then
            _owner.Col = 1
            frmCotizaAE.tBotonMagico.Focus()
            _owner.Select()
            _owner.Select(_row, 2)
            _owner.StartEditing()
            Return
        End If
        Try
            'aqui esta el error
            If _col = 1 Then
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
            If _col = 7 Then
                Try
                    If Not IsNothing(MyBase.Text) Then
                        If Not String.IsNullOrEmpty(MyBase.Text) Then
                            Try

                                If IsNumeric(frmCotizaAE.tPORC_MANIOBRAS.Text) Then
                                    PORC_MANIOBRAS = frmCotizaAE.tPORC_MANIOBRAS.Text
                                    _owner(_row, 8) = Math.Round(MyBase.Text + (MyBase.Text * (PORC_MANIOBRAS / 100)), 2)
                                End If

                                If Not IsNothing(_owner(_row, 8)) And Not IsNothing(_owner(_row, 12)) Then
                                    _owner(_row, 11) = Math.Round(_owner(_row, 8) / _owner(_row, 12), 2)
                                End If

                                If Not IsNothing(_owner(_row, 11)) Then
                                    If IsNumeric(frmCotizaAE.tPRECIO_DIESEL_SINIVA.Text) Then
                                        DIESEL = frmCotizaAE.tPRECIO_DIESEL_SINIVA.Text
                                        _owner(_row, 13) = Math.Round(_owner(_row, 11) * DIESEL, 2)
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("550. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("550. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("550. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If _col = 12 Then
                Try
                    Try
                        If IsNumeric(frmCotizaAE.tPORC_MANIOBRAS.Text) Then
                            If Not IsNothing(_owner(_row, 7)) Then
                                _owner(_row, 8) = Math.Round(_owner(_row, 7) + (_owner(_row, 7) * (frmCotizaAE.tPORC_MANIOBRAS.Text / 100)), 2)
                            End If
                        End If
                        If IsNumeric(frmCotizaAE.tPORC_MANIOBRAS.Text) Then
                            If Not IsNothing(_owner(_row, 8)) And Not IsNothing(MyBase.Text) Then
                                _owner(_row, 11) = Math.Round(_owner(_row, 8) / MyBase.Text, 2)
                            End If
                        End If
                        If IsNumeric(frmCotizaAE.tPRECIO_DIESEL_SINIVA.Text) Then
                            DIESEL = frmCotizaAE.tPRECIO_DIESEL_SINIVA.Text
                            If Not IsNothing(_owner(_row, 11)) Then
                                _owner(_row, 13) = Math.Round(_owner(_row, 11) * DIESEL, 2)
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("550. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Catch ex As Exception
                    Bitacora("550. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("550. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If _col = 99 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 9)) Then
                                If IsNumeric(MyBase.Text) Then

                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            'If _col = 7 Then
            'Return
            'End If

            'procesamiento base
            MyBase.OnLeave(e)
            'copiar texto a la cuadrícula del propietario
            If Not _cancel Then
                _owner(_row, _col) = MyBase.Text
                Return
            End If
            'no más claves pendientes
            _pendingKey = Chr(0)

            'hecho por ahora, ocultar editor
            MyBase.Visible = False
        Catch ex As Exception
            Bitacora("4150. " & ex.Message & vbNewLine & ex.StackTrace)
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
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        If _col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmCotizaAE.tBotonMagico.Focus()
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
                'Dim keypress As System.Windows.Forms.KeyPressEventArgs
                'OnKeyDown(e)
            Case Keys.F2
                If _col = 1 Then
                    Try
                        Var2 = "Plazas" : Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            _owner(_row, 1) = Var4
                            _owner(_row, 3) = Var5
                            _owner.Col = 4
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
                If _col = 4 Then
                    Try
                        Var2 = "Plazas" : Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            _owner(_row, 4) = Var4
                            _owner(_row, 6) = Var5
                            _owner.Col = 7
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
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
                frmCotizaAE.tBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        If col = 1 And key = Keys.Left Then
            frmCotizaAE.tBotonMagico.Focus()
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
                Return
            End If
        End If
        Select Case key
            Case Keys.Tab, Keys.Enter

            Case Keys.Up
                If _owner.Row = 1 Then
                    frmCotizaAE.tBotonMagico.Focus()
                    Return
                End If
                If IsNothing(_owner(_row, 1)) Then
                    If IsNothing(_owner(_row, 3)) Then
                        _owner.RemoveItem(_owner.Row)
                        Return
                    Else
                        If _owner(_row, 3).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            Return
                        End If
                    End If
                Else
                    If IsNothing(_owner(_row, 3)) Then
                        If _owner(_row, 2).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            Return
                        End If
                    End If
                End If

                If row > 1 Then
                    row -= 1
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
                                frmCotizaAE.tBotonMagico.Focus()
                            Else
                                _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                       "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                            End If
                        Case 3
                            frmCotizaAE.tBotonMagico.Focus()
                        Case 9
                            frmCotizaAE.tBotonMagico.Focus()
                    End Select
                    Return
                Else
                    row += 1
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
                                    End If
                                    Return
                                Else
                                    If _owner(_row, 3).ToString.Length = 0 Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                        End If
                                        Return
                                    End If
                                End If
                            Else
                                If IsNothing(_owner(_row, 3)) Then
                                    If _owner(_row, 1).ToString.Length = 0 Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                        End If
                                        Return
                                    End If
                                End If
                            End If
                            If row = 1 Then
                                row = _owner.Rows.Count - 1
                            Else
                                row -= 1
                            End If
                            col = 1
                        Case 4
                            col = 1
                        Case 7
                            col = 4
                        Case <= 14
                            col -= 1
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
                If col <= 14 Then
                    Select Case col
                        Case 1
                            'CORREGIR AQUI
                            If IsNothing(_owner(_row, 1)) Then
                                frmCotizaAE.tBotonMagico.Focus()
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
                            col = 4
                            'Return
                        Case 4
                            col = 7
                        Case 7
                            col = 9
                        Case 10
                            col = 12
                        Case 12
                            col = 14
                        Case 9
                            col = 10
                        Case 14
                            col = 1
                    End Select
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

        'aplicar nueva selección        7
        _owner.Select(_row, _col)

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        Dim HayErr As Boolean

        If col = 99 Then
            _owner.Col = 1
            frmCotizaAE.tBotonMagico.Focus()
            _owner.Select()
            _owner.Select(_row, 1)
            _owner.StartEditing()
            Return
        End If
        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)
                    Select Case _col
                        Case 1 'PLAZA1
                            Dim Descr As String

                            If MyBase.Text.Trim.Length = 0 Then
                                frmCotizaAE.tBotonMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            End If
                            Var9 = "" : Var22 = 0 : Var4 = ""

                            Descr = BUSCA_CAT("Plazas", MyBase.Text)

                            If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                MsgBox("Plaza inexistente")
                                frmCotizaAE.tBotonMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            Else
                                _owner(_row, 1) = MyBase.Text
                                _owner(_row, 3) = Descr
                                _owner.Col = 4
                                Return
                            End If
                        Case 4
                            Dim Descr As String
                            If MyBase.Text.Trim.Length = 0 Then
                                frmCotizaAE.tBotonMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            End If
                            Var4 = MyBase.Text
                            Descr = BUSCA_CAT("Plazas", MyBase.Text)
                            If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                MsgBox("Plaza inexistente")
                                frmCotizaAE.tBotonMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            Else
                                _owner(_row, 4) = Var4
                                _owner(_row, 6) = Descr
                                _owner.Col = 7
                                Return
                            End If
                        Case 14
                            Try
                                HayErr = False
                                Try
                                    _owner.Select(row + 1, 1)
                                Catch ex As Exception
                                    HayErr = True
                                End Try
                                If HayErr Then
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                   "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                                    _owner.Select(row + 1, 1)
                                Else
                                End If
                                _owner.StartEditing()
                                Return
                            Catch ex As Exception
                                Bitacora("4250. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("4250. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 7, 10, 12
                            _owner.Select(row, col + 2)
                        Case 8, 9, 11, 13, 14
                            _owner.Select(row, col + 1)
                        Case 55
                            _owner.Select(row, col + 4)
                        Case 10
                    End Select
                    _owner.StartEditing()
                    'Return
                Case Else
                    If _col = 5 Then
                        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                            e.KeyChar = ""
                            Return
                        End If
                    End If
                    If _col = 1 Then
                        'e.KeyChar = e.KeyChar.ToString.ToUpper
                    End If
            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            Bitacora("4300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class

