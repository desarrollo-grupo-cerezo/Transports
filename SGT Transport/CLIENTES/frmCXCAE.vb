Imports System.Data.SqlClient

Public Class frmCXCAE
    Private Sub frmCXCAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmCXCAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub frmCXCAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Return
        End If

        BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        If Var1 = "Nuevo" Then

            Try
                INICIALIZAR_CONTROLES()
                tNUM_CPTO.Text = GET_MAX_NUM_CPTO("CONC" & Empresa)
                tNUM_CPTO.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT N.NUM_CPTO, N.DESCR, N.TIPO, N.CUEN_CONT, N.CON_REFER, N.GEN_CPTO, N.AUTORIZACION, N.ES_FMA_PAG, " &
                    "N.STATUS, N.DAR_CAMBIO, N.FORMADEPAGOSAT FROM CONC" & Empresa & " N " &
                    "WHERE NUM_CPTO = " & Var2

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tNUM_CPTO.Text = dr("NUM_CPTO")
                    tDescr.Text = dr("DESCR").ToString
                    If dr("TIPO") = "C" Then
                        radCargo.Checked = True
                        radAbono.Checked = False
                    Else
                        radCargo.Checked = False
                        radAbono.Checked = True
                    End If
                    tCUEN_CONT.Text = dr("CUEN_CONT").ToString

                    If dr("CON_REFER") = "S" Then
                        chCON_REFER.Checked = True
                    Else
                        chCON_REFER.Checked = False
                    End If

                    tGEN_CPTO.Text = dr("GEN_CPTO")
                    If dr("AUTORIZACION") = "S" Then
                        chAUTORIZACION.Checked = True
                    Else
                        chAUTORIZACION.Checked = False
                    End If
                    If dr("ES_FMA_PAG") = "S" Then
                        chES_FMA_PAG.Checked = True
                    Else
                        chES_FMA_PAG.Checked = False
                    End If

                    If dr("DAR_CAMBIO") = "S" Then
                        chDAR_CAMBIO.Checked = True
                    Else
                        chDAR_CAMBIO.Checked = False
                    End If
                    tFORMADEPAGOSAT.Text = dr("FORMADEPAGOSAT").ToString
                Else
                    INICIALIZAR_CONTROLES()
                End If
                dr.Close()

                tNUM_CPTO.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Sub INICIALIZAR_CONTROLES()

        Try

            tNUM_CPTO.Text = ""
            tDescr.Text = ""
            radCargo.Checked = True
            radAbono.Checked = False

            tCUEN_CONT.Text = ""
            chCON_REFER.Checked = False
            tGEN_CPTO.Text = ""

            chAUTORIZACION.Checked = False
            chES_FMA_PAG.Checked = False
            chDAR_CAMBIO.Checked = False
            tFORMADEPAGOSAT.Text = ""

            chES_FMA_PAG.Enabled = False
            tFORMADEPAGOSAT.Enabled = False
            btnConSAT.Enabled = False
            chDAR_CAMBIO.Enabled = False

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If


        Dim CVE_BITA As Integer

        Dim cmd As New SqlCommand

        cmd.Connection = cnSAE

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If
        If Not GET_PAGOSAT(tFORMADEPAGOSAT.Text) Then
            MsgBox("Concepto inexistente verifique por favor")
            Return
        End If


        SQL = "IF EXISTS (SELECT NUM_CPTO FROM CONC" & Empresa & " WHERE NUM_CPTO = @NUM_CPTO)
                UPDATE CONC" & Empresa & " SET NUM_CPTO = @NUM_CPTO, DESCR = @DESCR, TIPO = @TIPO, CUEN_CONT = @CUEN_CONT, CON_REFER = @CON_REFER,
                GEN_CPTO = @GEN_CPTO, AUTORIZACION = @AUTORIZACION, SIGNO = @SIGNO, ES_FMA_PAG = @ES_FMA_PAG, CVE_BITA = @CVE_BITA,
                ENLINEA = @ENLINEA, DAR_CAMBIO = @DAR_CAMBIO, FORMADEPAGOSAT = @FORMADEPAGOSAT
                WHERE NUM_CPTO = @NUM_CPTO
            ELSE
                INSERT INTO CONC" & Empresa & " (NUM_CPTO, DESCR, TIPO, CUEN_CONT, CON_REFER, GEN_CPTO, AUTORIZACION, SIGNO, ES_FMA_PAG, CVE_BITA,
                STATUS, ENLINEA, DAR_CAMBIO, FORMADEPAGOSAT) VALUES (@NUM_CPTO, @DESCR, @TIPO, @CUEN_CONT, @CON_REFER, @GEN_CPTO, @AUTORIZACION,
                @SIGNO, @ES_FMA_PAG, @CVE_BITA, 'A', @ENLINEA, @DAR_CAMBIO, @FORMADEPAGOSAT)"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@NUM_CPTO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tNUM_CPTO.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = IIf(radCargo.Checked, "C", "A")
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
            cmd.Parameters.Add("@CON_REFER", SqlDbType.VarChar).Value = IIf(chCON_REFER.Checked, "S", "N")
            cmd.Parameters.Add("@GEN_CPTO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tGEN_CPTO.Text)
            cmd.Parameters.Add("@AUTORIZACION", SqlDbType.VarChar).Value = IIf(chAUTORIZACION.Checked, "S", "N")
            cmd.Parameters.Add("@SIGNO", SqlDbType.SmallInt).Value = IIf(radCargo.Checked, 1, -1)
            cmd.Parameters.Add("@ES_FMA_PAG", SqlDbType.VarChar).Value = IIf(chES_FMA_PAG.Checked, "S", "N")
            cmd.Parameters.Add("@CVE_BITA", SqlDbType.Int).Value = CVE_BITA

            cmd.Parameters.Add("@ENLINEA", SqlDbType.SmallInt).Value = -1
            cmd.Parameters.Add("@DAR_CAMBIO", SqlDbType.VarChar).Value = IIf(chDAR_CAMBIO.Checked, "S", "N")
            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = tFORMADEPAGOSAT.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()

    End Sub

    Private Sub radCargo_CheckedChanged(sender As Object, e As EventArgs) Handles radCargo.CheckedChanged

        Try

            If radCargo.Checked Then
                chES_FMA_PAG.Enabled = False
                tFORMADEPAGOSAT.Enabled = False
                btnConSAT.Enabled = False
                chDAR_CAMBIO.Enabled = False
            Else
                chES_FMA_PAG.Enabled = True
                tFORMADEPAGOSAT.Enabled = True
                btnConSAT.Enabled = True
                chDAR_CAMBIO.Enabled = True
            End If

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnConSAT_Click(sender As Object, e As EventArgs) Handles btnConSAT.Click

        Var2 = "PagoSAT"
        frmUsoCFDI.ShowDialog()
        tFORMADEPAGOSAT.Text = Var4
        Var2 = ""
        Var4 = ""
        Var5 = ""

    End Sub

    Private Sub tFORMADEPAGOSAT_KeyDown(sender As Object, e As KeyEventArgs) Handles tFORMADEPAGOSAT.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

        End If
    End Sub

    Private Sub tFORMADEPAGOSAT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tFORMADEPAGOSAT.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If Not GET_PAGOSAT(tFORMADEPAGOSAT.Text) Then
                MsgBox("Concepto inexistente verifique por favor")
            End If
        End If
    End Sub

    Private Sub tFORMADEPAGOSAT_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tFORMADEPAGOSAT.Validating
        If Not GET_PAGOSAT(tFORMADEPAGOSAT.Text) Then
            MsgBox("Concepto inexistente verifique por favor")
        End If

    End Sub

    Private Sub btnGenConc_Click(sender As Object, e As EventArgs) Handles btnGenConc.Click

        Var2 = "ConcCxC"
        Var4 = ""
        Var5 = ""
        frmSelItem.ShowDialog()
        tGEN_CPTO.Text = Var4
        Var2 = ""
        Var4 = ""
        Var5 = ""

    End Sub

End Class
