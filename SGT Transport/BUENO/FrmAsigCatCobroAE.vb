Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports SGT_Transport.WSFD
Imports Stimulsoft.Report.Design.StiBuilder

Public Class FrmAsigCatCobroAE
    Private Sub FrmAsigCatCobroAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            TORDEN.Value = 0

            TIVA.Value = 0
            TRET.Value = 0
        Catch ex As Exception
        End Try

        Me.KeyPreview = True
        Me.CenterToScreen()

        If Var1 = "Nuevo" Then
            Try
                TCVE_COBRO.Text = GET_MAX("GCASIGCONCEP_COBRO", "CVE_COBRO")
                TCVE_COBRO.Enabled = False
                TDESCR.Text = ""
                TIVA.Visible = False
                Lt1.Visible = False

                TRET.Visible = False
                Lt2.Visible = False

                TDESCR.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT A.CVE_COBRO, A.STATUS, A.DESCR, A.CAUSA_IVA, A.CAUSA_RET, A.CUENTA, A.CENTRO_BENEF, 
                    A.DESCR_UME_FAC, A.CVE_PRODSERV, A.CVE_UNIDAD, A.OBS, IVA, RET
                    FROM GCASIGCONCEP_COBRO A 
                    WHERE CVE_COBRO = " & Convert.ToInt16(Var2)

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCVE_COBRO.Text = dr("CVE_COBRO").ToString
                    TDESCR.Text = dr("DESCR").ToString
                    TCVE_COBRO.Text = dr("CVE_COBRO").ToString
                    TDESCR.Text = dr("DESCR").ToString
                    If dr("CAUSA_IVA") = 1 Then
                        ChCausaIva.Checked = True
                        TIVA.Visible = True
                        Lt1.Visible = True
                    Else
                        ChCausaIva.Checked = False
                        TIVA.Visible = False
                        Lt1.Visible = False
                    End If
                    TIVA.Value = dr.ReadNullAsEmptyDecimal("IVA")
                    If dr("CAUSA_RET") = 1 Then
                        ChRetieneIva.Checked = True
                        TRET.Visible = True
                        Lt2.Visible = True
                    Else
                        ChRetieneIva.Checked = False
                        TRET.Visible = False
                        Lt2.Visible = False
                    End If
                    TRET.Value = dr.ReadNullAsEmptyDecimal("RET")

                    TCUENTA.Text = dr("CUENTA").ToString
                    TCENTRO_BENEF.Text = dr("CENTRO_BENEF").ToString
                    TCVE_PRODSERV.Text = dr("CVE_PRODSERV").ToString
                    TCVE_UNIDAD.Text = dr("CVE_UNIDAD").ToString
                    TOBS.Text = dr("OBS").ToString

                Else
                    TCVE_COBRO.Text = 0
                    TDESCR.Text = ""
                End If
                dr.Close()

                TCVE_COBRO.Enabled = False
                TDESCR.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmAsigCatCobroAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        Try
            TORDEN.UpdateValueWithCurrentText()
            TCVE_PRODSERV.UpdateValueWithCurrentText()
            TCVE_UNIDAD.UpdateValueWithCurrentText()
            TIVA.UpdateValueWithCurrentText()
            TRET.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If


        SQL = "IF EXISTS (SELECT CVE_COBRO FROM GCASIGCONCEP_COBRO WHERE CVE_COBRO = @CVE_COBRO)
                UPDATE GCASIGCONCEP_COBRO SET DESCR = @DESCR, CAUSA_IVA = @CAUSA_IVA, CAUSA_RET = @CAUSA_RET, CUENTA = @CUENTA,
                CENTRO_BENEF = @CENTRO_BENEF, DESCR_UME_FAC = @DESCR_UME_FAC, CVE_PRODSERV = @CVE_PRODSERV, CVE_UNIDAD = @CVE_UNIDAD, 
                OBS = @OBS, ORDEN = @ORDEN, IVA = @IVA, RET = @RET
                WHERE CVE_COBRO = @CVE_COBRO
            ELSE
                INSERT INTO GCASIGCONCEP_COBRO (CVE_COBRO, STATUS, DESCR, CAUSA_IVA, IVA, CAUSA_RET, RET, CUENTA, CENTRO_BENEF, DESCR_UME_FAC, 
                CVE_PRODSERV, CVE_UNIDAD, OBS, UUID, ORDEN)
                VALUES(
                @CVE_COBRO, 'A', @DESCR, @CAUSA_IVA, @IVA, @CAUSA_RET, @RET, @CUENTA, @CENTRO_BENEF, @DESCR_UME_FAC, @CVE_PRODSERV, 
                @CVE_UNIDAD, @OBS, NEWID(), @ORDEN)"


        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_COBRO.Text)
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
                cmd.Parameters.Add("@CAUSA_IVA", SqlDbType.SmallInt).Value = IIf(ChCausaIva.Checked, 1, 0)
                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = TIVA.Value
                cmd.Parameters.Add("@CAUSA_RET", SqlDbType.SmallInt).Value = IIf(ChRetieneIva.Checked, 1, 0)
                cmd.Parameters.Add("@RET", SqlDbType.Float).Value = TRET.Value
                cmd.Parameters.Add("@CUENTA", SqlDbType.VarChar).Value = TCUENTA.Text
                cmd.Parameters.Add("@CENTRO_BENEF", SqlDbType.VarChar).Value = TCENTRO_BENEF.Text
                cmd.Parameters.Add("@DESCR_UME_FAC", SqlDbType.VarChar).Value = CboUMEFac.Text
                cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV.Value
                cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD.Value
                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TOBS.Text
                cmd.Parameters.Add("@ORDEN", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TORDEN.Value)

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using

            MsgBox("El cobro se grabo correctamente")
            Me.Close()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnProdServ_Click(sender As Object, e As EventArgs) Handles BtnProdServ.Click
        Prosec = "CATINV"
        FrmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            TCVE_PRODSERV.Text = Var10
            LtCveProdServ.Text = Var11
        End If
    End Sub

    Private Sub BtnCveUni_Click(sender As Object, e As EventArgs) Handles BtnCveUni.Click
        Try
            Prosec = "UNIMED"
            FrmNewXCategoria.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCVE_UNIDAD.Text = Var10
                LtCveUnidad.Text = Var11
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ChCausaIva_CheckedChanged(sender As Object, e As EventArgs) Handles ChCausaIva.CheckedChanged
        If ChCausaIva.Checked Then
            TIVA.Visible = True
            Lt1.Visible = True
        Else
            TIVA.Visible = False
            Lt1.Visible = False
        End If
    End Sub

    Private Sub ChRetieneIva_CheckedChanged(sender As Object, e As EventArgs) Handles ChRetieneIva.CheckedChanged
        If ChRetieneIva.Checked Then
            TRET.Visible = True
            Lt2.Visible = True
        Else
            TRET.Visible = False
            Lt2.Visible = False
        End If
    End Sub
End Class