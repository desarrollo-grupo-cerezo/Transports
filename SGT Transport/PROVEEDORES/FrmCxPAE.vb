Imports System.Data.SqlClient
Public Class FrmCxPAE
    Private Sub frmCxPAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        tDescr.MaxLength = 17
        tCUEN_CONT.MaxLength = 28

        INICIALIZAR_CONTROLES()

        If Var1 = "Nuevo" Then
            Try
                tNUM_CPTO.Text = GET_MAX("CONP" & Empresa, "NUM_CPTO")
                tNUM_CPTO.Enabled = False
                tDescr.Text = ""
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

                SQL = "SELECT N.NUM_CPTO, N.DESCR, N.TIPO, N.CUEN_CONT, N.CON_REFER, N.GEN_CPTO, N.AUTORIZACION, N.SIGNO, N.ES_FMA_PAG, N.CVE_BITA, N.STATUS " &
                    "FROM CONP" & Empresa & " N WHERE N.NUM_CPTO = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tNUM_CPTO.Text = dr("NUM_CPTO").ToString
                    tDescr.Text = dr("DESCR").ToString
                    If dr("TIPO") = "C" Then
                        radCargo.Checked = True
                        radAbono.Checked = False
                        chES_FMA_PAG.Enabled = False
                        chCON_REFER.Enabled = True
                        chAUTORIZACION.Enabled = True
                    Else
                        radCargo.Checked = False
                        radAbono.Checked = True
                        chES_FMA_PAG.Enabled = True
                        chCON_REFER.Enabled = True
                        chAUTORIZACION.Enabled = True
                    End If
                    tCUEN_CONT.Text = dr("CUEN_CONT").ToString
                    If dr("CON_REFER") = "S" Then
                        chCON_REFER.Checked = True
                    Else
                        chCON_REFER.Checked = False
                    End If
                    tGEN_CPTO.Text = dr("GEN_CPTO").ToString
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
            chES_FMA_PAG.Enabled = False
            chCON_REFER.Enabled = True
            chAUTORIZACION.Enabled = True

            tCUEN_CONT.Text = ""
            tGEN_CPTO.Text = ""

            chAUTORIZACION.Checked = False
            chES_FMA_PAG.Checked = False
            chCON_REFER.Checked = False

            chES_FMA_PAG.Enabled = False
            chCON_REFER.Enabled = False

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub frmCxPAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmCxPAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
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

        SQL = "UPDATE CONP" & Empresa & " SET NUM_CPTO = @NUM_CPTO, DESCR = @DESCR, TIPO = @TIPO, CUEN_CONT = @CUEN_CONT, CON_REFER = @CON_REFER, GEN_CPTO = @GEN_CPTO, " &
            "AUTORIZACION = @AUTORIZACION, SIGNO = @SIGNO, ES_FMA_PAG = @ES_FMA_PAG  " &
            "WHERE NUM_CPTO = @NUM_CPTO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO CONP" & Empresa & " (NUM_CPTO, DESCR, TIPO, CUEN_CONT, CON_REFER, GEN_CPTO, AUTORIZACION, SIGNO, ES_FMA_PAG, CVE_BITA, STATUS)" &
            " VALUES(@NUM_CPTO, @DESCR, @TIPO, @CUEN_CONT, @CON_REFER, @GEN_CPTO, @AUTORIZACION, @SIGNO, @ES_FMA_PAG, @CVE_BITA, 'A')"

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
    Private Sub btnGenConc_Click(sender As Object, e As EventArgs) Handles btnGenConc.Click
        Try
            Var2 = "ConcCxP"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tGEN_CPTO.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("25. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("25. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub tGEN_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles tGEN_CPTO.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnGenConc_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tGEN_CPTO_Validated(sender As Object, e As EventArgs) Handles tGEN_CPTO.Validated
        Try
            If tGEN_CPTO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("ConcCxP", tGEN_CPTO.Text)
                If DESCR <> "" Then
                    tGEN_CPTO.Text = DESCR
                Else
                    MsgBox("Concepto inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("25. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("25. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub radCargo_Click(sender As Object, e As EventArgs) Handles radCargo.Click

        If radCargo.Checked Then
            chES_FMA_PAG.Checked = False
            chES_FMA_PAG.Enabled = False
            chCON_REFER.Enabled = True
            chAUTORIZACION.Enabled = True
        Else
            chES_FMA_PAG.Enabled = True
            chCON_REFER.Enabled = True
            chAUTORIZACION.Enabled = True
        End If
    End Sub

    Private Sub radAbono_Click(sender As Object, e As EventArgs) Handles radAbono.Click
        If radAbono.Checked Then
            chES_FMA_PAG.Enabled = True
            chCON_REFER.Enabled = True
            chAUTORIZACION.Enabled = True
        Else
            chES_FMA_PAG.Enabled = False
            chCON_REFER.Enabled = True
            chAUTORIZACION.Enabled = True
        End If
    End Sub
End Class
