Imports System.Data.SqlClient
Public Class FrmParamTransCG
    Private Sub FrmParamTransCG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        TFACTOR_IEPS.Value = 0
        TIEPS.Value = 0
        TIEPS_MAGNA.Value = 0
        TIEPS_PREMIUN.Value = 0
        TIEPS_DIESEL.Value = 0

        TSERIE_UTILITARIOS.Text = ""

        TFOLIO_UTILITARIOS.Value = 0

        AssignValidation(Me.TULT_DOC_CARTA_PORTE, ValidationType.Only_Numbers)
        AssignValidation(Me.TDIAS_ANTICIPACION, ValidationType.Only_Numbers)
        AssignValidation(Me.TDIAS_ANTICIPACION, ValidationType.Only_Numbers)

        Try
            SQL = "SELECT FACTOR_IEPS, IEPS, ISNULL(MODULO_UNIDADES_COMPLETA,0) AS MOD_UNI_COM, ISNULL(PERMITIR_UNIDAD,0) AS P_UNIDAD,
                ISNULL(SOLICITAR_ACT_MANTE,0) AS SOL_ACT_MAN, ISNULL(PORC_ORDEN_TRA_EXT,0) AS P_ORDEN_TRA_EXT, ISNULL(PORC_O_MONTO,0) AS P_O_M, 
                SERIE_CARTA_PORTE, SERIE_CARTA_PORTE_VIRTUAL, ULT_DOC_CARTA_PORTE, ULT_DOC_CARTA_PORTE_VIRTUAL, DIAS_ANTICIPACION, 
                SERIE_VALE_COMBUS, VALOR_DECLA_DESDE_SAE, LIN_PROD, ISNULL(GRABAR_CERO_LIQ,0) AS GRABARCEROLIQ, IEPS_MAGNA, 
                IEPS_PREMIUN, IEPS_DIESEL, ISNULL(SERIE_UTILITARIOS,'') AS SERIE_U, ISNULL(FOLIO_UTILITARIOS,0) AS FOLIO_U, 
                ISNULL(SERIE_RE,'') AS SER_RE, ISNULL(FOLIO_RE,0) AS FOL_RE, ISNULL(CONFIGVEHICULAR,'') AS CONFIGVE
                FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TFACTOR_IEPS.Value = dr.ReadNullAsEmptyDecimal("FACTOR_IEPS")
                        TIEPS.Value = dr.ReadNullAsEmptyDecimal("IEPS")
                        ChModuloUnidadCompleta.Value = dr.ReadNullAsEmptyInteger("MOD_UNI_COM")
                        ChPermitirUnidad.Value = dr.ReadNullAsEmptyInteger("P_UNIDAD")
                        ChSolicitarActMante.Value = dr.ReadNullAsEmptyInteger("SOL_ACT_MAN")
                        TPorcOrdTrabExt.Value = dr.ReadNullAsEmptyDecimal("P_ORDEN_TRA_EXT")
                        TSERIE_CARTA_PORTE.Text = dr.ReadNullAsEmptyString("SERIE_CARTA_PORTE")
                        TSERIE_CARTA_PORTE_VIRTUAL.Text = dr.ReadNullAsEmptyString("SERIE_CARTA_PORTE_VIRTUAL")
                        TULT_DOC_CARTA_PORTE.Text = dr.ReadNullAsEmptyDecimal("ULT_DOC_CARTA_PORTE")
                        TULT_DOC_CARTA_PORTE_VIRTUAL.Text = dr.ReadNullAsEmptyDecimal("ULT_DOC_CARTA_PORTE_VIRTUAL")


                        TDIAS_ANTICIPACION.Text = dr.ReadNullAsEmptyInteger("DIAS_ANTICIPACION")
                        TSERIE_VALE_COMBUS.Text = dr.ReadNullAsEmptyString("SERIE_VALE_COMBUS")
                        ChValorDeclaDesdeSAE.Value = dr.ReadNullAsEmptyInteger("VALOR_DECLA_DESDE_SAE")
                        TLIN_PROD.Text = dr.ReadNullAsEmptyString("LIN_PROD")
                        ChGrabarCeroLiq.Checked = dr("GRABARCEROLIQ")
                        TIEPS_MAGNA.Value = dr.ReadNullAsEmptyDecimal("IEPS_MAGNA")
                        TIEPS_PREMIUN.Value = dr.ReadNullAsEmptyDecimal("IEPS_PREMIUN")
                        TIEPS_DIESEL.Value = dr.ReadNullAsEmptyDecimal("IEPS_DIESEL")
                        TSERIE_UTILITARIOS.Text = dr("SERIE_U")
                        TFOLIO_UTILITARIOS.Value = dr("FOLIO_U")

                        TSERIE_RE.Text = dr("SER_RE")
                        TFOLIO_RE.Text = dr("FOL_RE")
                        TConfigVehicular.Text = dr("CONFIGVE")
                    End If
                End Using
            End Using

            Tab1.SelectedIndex = 0
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click

        Try
            TFOLIO_UTILITARIOS.UpdateValueWithCurrentText()

        Catch ex As Exception

        End Try

        SQL = "UPDATE GCPARAMTRANSCG SET FACTOR_IEPS = @FACTOR_IEPS, IEPS = @IEPS, PERMITIR_UNIDAD = @PERMITIR_UNIDAD, 
            SOLICITAR_ACT_MANTE = @SOLICITAR_ACT_MANTE, PORC_ORDEN_TRA_EXT = @PORC_ORDEN_TRA_EXT, 
            SERIE_CARTA_PORTE = @SERIE_CARTA_PORTE, SERIE_CARTA_PORTE_VIRTUAL = @SERIE_CARTA_PORTE_VIRTUAL,
            ULT_DOC_CARTA_PORTE = @ULT_DOC_CARTA_PORTE, ULT_DOC_CARTA_PORTE_VIRTUAL = @ULT_DOC_CARTA_PORTE_VIRTUAL, 
            DIAS_ANTICIPACION = @DIAS_ANTICIPACION, SERIE_VALE_COMBUS = @SERIE_VALE_COMBUS, 
            VALOR_DECLA_DESDE_SAE = @VALOR_DECLA_DESDE_SAE, LIN_PROD = @LIN_PROD, GRABAR_CERO_LIQ = @GRABAR_CERO_LIQ,
            IEPS_MAGNA = @IEPS_MAGNA, IEPS_PREMIUN = @IEPS_PREMIUN, IEPS_DIESEL = @IEPS_DIESEL, 
            SERIE_UTILITARIOS = @SERIE_UTILITARIOS, FOLIO_UTILITARIOS = @FOLIO_UTILITARIOS, SERIE_RE= @SERIE_RE, 
            FOLIO_RE = @FOLIO_RE, CONFIGVEHICULAR = @CONFIGVEHICULAR 
            IF @@ROWCOUNT = 0
            INSERT INTO GCPARAMTRANSCG (FACTOR_IEPS, IEPS, PERMITIR_UNIDAD, SOLICITAR_ACT_MANTE, PORC_ORDEN_TRA_EXT, 
            SERIE_CARTA_PORTE, SERIE_CARTA_PORTE_VIRTUAL, ULT_DOC_CARTA_PORTE, ULT_DOC_CARTA_PORTE_VIRTUAL, 
            DIAS_ANTICIPACION, SERIE_VALE_COMBUS, VALOR_DECLA_DESDE_SAE, LIN_PROD, GRABAR_CERO_LIQ, IEPS_MAGNA, 
            IEPS_PREMIUN, IEPS_DIESEL, SERIE_UTILITARIOS, FOLIO_UTILITARIOS, SERIE_RE, FOLIO_RE, CONFIGVEHICULAR ) 
            VALUES (
            @FACTOR_IEPS, @IEPS, @PERMITIR_UNIDAD, @SOLICITAR_ACT_MANTE, @PORC_ORDEN_TRA_EXT, @SERIE_CARTA_PORTE, 
            @SERIE_CARTA_PORTE_VIRTUAL, @ULT_DOC_CARTA_PORTE, @ULT_DOC_CARTA_PORTE_VIRTUAL, @DIAS_ANTICIPACION, 
            @SERIE_VALE_COMBUS, @VALOR_DECLA_DESDE_SAE, @LIN_PROD, @GRABAR_CERO_LIQ, @IEPS_MAGNA, @IEPS_PREMIUN, 
            @IEPS_DIESEL, @SERIE_UTILITARIOS, @FOLIO_UTILITARIOS, @SERIE_RE, @FOLIO_RE, @CONFIGVEHICULAR)"
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE
            cmd.CommandText = SQL

            cmd.Parameters.Add("@FACTOR_IEPS", SqlDbType.Float).Value = TFACTOR_IEPS.Text
            cmd.Parameters.Add("@IEPS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TIEPS.Value)
            cmd.Parameters.Add("@MODULO_UNIDADES_COMPLETA", SqlDbType.Int).Value = IIf(ChModuloUnidadCompleta.Value, 1, 0)
            cmd.Parameters.Add("@PERMITIR_UNIDAD", SqlDbType.Int).Value = IIf(ChPermitirUnidad.Value, 1, 0)
            cmd.Parameters.Add("@SOLICITAR_ACT_MANTE", SqlDbType.Int).Value = IIf(ChSolicitarActMante.Value, 1, 0)
            cmd.Parameters.Add("@PORC_ORDEN_TRA_EXT", SqlDbType.Float).Value = TPorcOrdTrabExt.Value
            cmd.Parameters.Add("@SERIE_CARTA_PORTE", SqlDbType.VarChar).Value = TSERIE_CARTA_PORTE.Text
            cmd.Parameters.Add("@SERIE_CARTA_PORTE_VIRTUAL", SqlDbType.VarChar).Value = TSERIE_CARTA_PORTE_VIRTUAL.Text
            cmd.Parameters.Add("@ULT_DOC_CARTA_PORTE", SqlDbType.Int).Value = CONVERTIR_TO_LONG(TULT_DOC_CARTA_PORTE.Text)
            cmd.Parameters.Add("@ULT_DOC_CARTA_PORTE_VIRTUAL", SqlDbType.Int).Value = CONVERTIR_TO_LONG(TULT_DOC_CARTA_PORTE_VIRTUAL.Text)
            cmd.Parameters.Add("@DIAS_ANTICIPACION", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TDIAS_ANTICIPACION.Text)
            cmd.Parameters.Add("@SERIE_VALE_COMBUS", SqlDbType.VarChar).Value = TSERIE_VALE_COMBUS.Text
            cmd.Parameters.Add("@VALOR_DECLA_DESDE_SAE", SqlDbType.SmallInt).Value = IIf(ChValorDeclaDesdeSAE.Checked, 1, 0)
            cmd.Parameters.Add("@LIN_PROD", SqlDbType.VarChar).Value = TLIN_PROD.Text
            cmd.Parameters.Add("@GRABAR_CERO_LIQ", SqlDbType.Bit).Value = ChGrabarCeroLiq.Checked
            cmd.Parameters.Add("@IEPS_MAGNA", SqlDbType.Float).Value = TIEPS_MAGNA.Value
            cmd.Parameters.Add("@IEPS_PREMIUN", SqlDbType.Float).Value = TIEPS_PREMIUN.Value
            cmd.Parameters.Add("@IEPS_DIESEL", SqlDbType.Float).Value = TIEPS_DIESEL.Value
            cmd.Parameters.Add("@SERIE_UTILITARIOS", SqlDbType.VarChar).Value = TSERIE_UTILITARIOS.Text
            cmd.Parameters.Add("@FOLIO_UTILITARIOS", SqlDbType.Int).Value = TFOLIO_UTILITARIOS.Value
            cmd.Parameters.Add("@SERIE_RE", SqlDbType.VarChar).Value = TSERIE_RE.Text
            cmd.Parameters.Add("@FOLIO_RE", SqlDbType.Int).Value = TFOLIO_RE.Text
            cmd.Parameters.Add("@CONFIGVEHICULAR ", SqlDbType.VarChar).Value = TConfigVehicular.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If tMensaje.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAROCE.CreateCommand
                    SQL = "UPDATE CONFIG SET MENSAJE = '" & tMensaje.Text & "' IF @@ROWCOUNT = 0 INSERT INTO CONFIG (MENSAJE) VALUES('" & tMensaje.Text & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If

        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Me.Close()
    End Sub
    Private Sub BtnSeries_Click(sender As Object, e As EventArgs) Handles BtnSeries.Click
        CREA_TAB2(frmParamSeriesTrans, "Series")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmParamTransCG_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab2("Parámetros transportCG")
        Me.Dispose()
    End Sub

    Private Sub BtnLinea_Click(sender As Object, e As EventArgs) Handles btnLinea.Click
        Try
            Var2 = "Lineas"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLIN_PROD.Text = Var4
                LtLinea.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TLIN_PROD_KeyDown(sender As Object, e As KeyEventArgs) Handles TLIN_PROD.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnLinea_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TLIN_PROD_Validated(sender As Object, e As EventArgs) Handles TLIN_PROD.Validated
        Try
            If TLIN_PROD.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Linea", TLIN_PROD.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Linea inexistente")
                    TLIN_PROD.Text = ""
                    LtLinea.Text = ""
                    TLIN_PROD.Select()
                Else
                    LtLinea.Text = CADENA
                End If
            Else
                LtLinea.Text = ""
            End If
        Catch ex As Exception
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnConfigVehicular_Click(sender As Object, e As EventArgs) Handles BtnConfigVehicular.Click
        Try
            Var2 = "ConfigVehicular"
            Var4 = "" : Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TConfigVehicular.Text = Var4
                LTConfigVehicular.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            Else
                TConfigVehicular.Text = ""
                LTConfigVehicular.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TConfigVehicular_KeyDown(sender As Object, e As KeyEventArgs) Handles TConfigVehicular.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnConfigVehicular_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TConfigVehicular_Validated(sender As Object, e As EventArgs) Handles TConfigVehicular.Validated
        Try
            Dim DESCR As String
            If TConfigVehicular.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT2("ConfigVehicular", TConfigVehicular.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LTConfigVehicular.Text = DESCR
                Else
                    MsgBox("Unidad inexistente")
                    TConfigVehicular.Text = ""
                    LTConfigVehicular.Text = ""
                End If
            Else
                LTConfigVehicular.Text = ""
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
