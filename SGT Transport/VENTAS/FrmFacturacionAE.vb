Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmFacturacionAE
    Private Sub frmFacturacionAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Dim Lng As Integer
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd.Connection = cnSAE

        tDesc.Value = 0
        Me.WindowState = FormWindowState.Maximized
        Fg.Width = Me.Width - 100

        Fg.SetCellCheck(0, 1, CheckEnum.Checked)
        Fg.Rows.Count = 1

        Lng = Me.Width

        LtFecha.Text = Date.Now.ToShortDateString
        Lt1.Left = Lng - 300 - LtSubTotal.Width
        Lt2.Left = Lng - 300 - LtDesc.Width
        Lt3.Left = Lng - 300 - LtRet.Width
        Lt4.Left = Lng - 300 - LtIva.Width
        Lt5.Left = Lng - 300 - LtTotal.Width

        LtSubTotal.Left = Lng - 300
        LtDesc.Left = Lng - 300
        LtRet.Left = Lng - 300
        LtIva.Left = Lng - 300
        LtTotal.Left = Lng - 300

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                LtCVE_DOC.Text = GET_MAX("GCFACT", "CVE_DOC")
                tCVE_CON.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                SQL = "SELECT F.CVE_DOC, F.CVE_CON, F.CVE_VIAJE, F.STATUS, F.CVE_CLPV, F.CVE_VIAJE, F.FECHA_DOC, F.IMPORTE, " &
                    "CAN_TOT, TOT_DESC, TOT_IMP1, TOT_IMP4, ISNULL(NOMBRE,'') AS NOMB, ISNULL(CALLE,'') AS DIRE, ISNULL(NUMINT,'') AS NOINT,  " &
                    "ISNULL(NUMEXT,'') AS NOEXT, ISNULL(RFC,'') AS RF, ISNULL(CODIGO,'') AS CP, ISNULL(COLONIA,'') AS COLO, " &
                    "ISNULL(MUNICIPIO,'') AS MUNI, ISNULL(ESTADO,'') AS EST " &
                    "FROM GCFACT F " &
                    "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CVE_CLPV " &
                    "WHERE CVE_DOC = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_CON.Text = dr("CVE_CON").ToString
                    tCVE_VIAJE.Text = dr("CVE_VIAJE").ToString
                    LtCVE_DOC.Text = dr("CVE_DOC").ToString
                    LtClave.Text = dr("CVE_CLPV").ToString
                    tCVE_VIAJE.Text = dr("CVE_VIAJE").ToString
                    LtFecha.Text = dr("FECHA_DOC").ToString

                    LtNombre.Text = dr("NOMB")
                    LtCalle.Text = dr("DIRE")
                    LtNoINt.Text = dr("NOINT")
                    LtNoExt.Text = dr("NOEXT")
                    LtRFC.Text = dr("RF")
                    LtCP.Text = dr("CP")
                    LtCol.Text = dr("COLO")
                    LtCiudad.Text = dr("MUNI")
                    LtEstado.Text = dr("EST")

                    LtSubTotal.Text = dr("CAN_TOT").ToString
                    LtDesc.Text = dr("TOT_DESC").ToString
                    LtRet.Text = dr("TOT_IMP1").ToString
                    LtIva.Text = dr("TOT_IMP4").ToString
                    LtTotal.Text = dr("IMPORTE").ToString
                End If
                dr.Close()

                CARGAR_PAR()

                tCVE_CON.Enabled = False
                tCVE_VIAJE.Select()

            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub CARGAR_PAR()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd.Connection = cnSAE

        Try
            SQL = "SELECT P.CVE_ART, P.CANT, DESCR, P.CVE_CPTO, P.DESCT, P.DES_TOT, P.IMP1, P.IMP2, P.IMP3, P.IMP4, P.TOT_PARTIDA " &
                "FROM GCPAR_FACT P " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART " &
                "WHERE CVE_DOC = '" & Var2 & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count=1
            Do While dr.Read

                Fg.AddItem("" & vbTab & True & vbTab & dr("CANT") & vbTab & dr("CVE_ART") & vbTab & dr("DESCR") & vbTab & dr("CVE_CPTO") & vbTab &
                               dr("DESCT") & vbTab & dr("IMP4") & vbTab & dr("IMP1") & vbTab & dr("TOT_PARTIDA"))
            Loop
            dr.Close()
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmFacturacionAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmFacturacionAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim j As Integer
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tCVE_CON.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el número de contrato")
            Return
        End If
        If tCVE_VIAJE.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el viaje")
            Return
        End If
        j = 0
        For k = 1 To Fg.Rows.Count - 1
            If Fg(k, 1) Then
                j = j + 1
            End If
        Next
        If j = 0 Then
            MsgBox("Por favor seleccione al menos una partida ")
            Return
        End If

        SQL = "UPDATE GCFACT SET CVE_VIAJE = @CVE_VIAJE, CAN_TOT = @CAN_TOT, TOT_DESC = @TOT_DESC, TOT_IMP1 = @TOT_IMP1, " &
            "TOT_IMP4 = @TOT_IMP4, IMPORTE = @IMPORTE " &
            "WHERE CVE_DOC = @CVE_DOC " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCFACT (CVE_DOC, STATUS, CVE_CLPV, CVE_CON, CVE_VIAJE, FECHA_DOC, CAN_TOT, TOT_DESC, TOT_IMP1, TOT_IMP4, IMPORTE)" &
            " VALUES(@CVE_DOC, 'A', @CVE_CLPV, @CVE_CON, @CVE_VIAJE, GETDATE(), @CAN_TOT, @TOT_DESC, @TOT_IMP1, @TOT_IMP4, @IMPORTE)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = LtCVE_DOC.Text
            cmd.Parameters.Add("@CVE_CLPV", SqlDbType.VarChar).Value = LtClave.Text
            cmd.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = CONVERTIR_TO_INT(tCVE_CON.Text)
            cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_VIAJE.Text)
            cmd.Parameters.Add("@CAN_TOT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtSubTotal.Text)
            cmd.Parameters.Add("@TOT_DESC", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtDesc.Text)
            cmd.Parameters.Add("@TOT_IMP1", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtRet.Text)
            cmd.Parameters.Add("@TOT_IMP4", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtIva.Text)
            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtTotal.Text)
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    GRABAR_PAR()
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
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
    End Sub
    Sub GRABAR_PAR()
        Dim CANT As Single
        Dim PRECIO As Single
        Dim TOT_PARTIDA As Single
        Dim DESC As Single
        Dim DES_TOT As Single
        Dim IMP1 As Single
        Dim IMP4 As Single
        Dim k As Integer
        Dim Sigue As Boolean

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE GCPAR_FACT SET CVE_ART = @CVE_ART, CANT = @CANT, CVE_CPTO = @CVE_CPTO, DESCT = @DESCT, " &
            "DES_TOT = @DES_TOT, IMP1 = @IMP1, IMP2 = @IMP2, IMP3 = @IMP3, IMP4 = @IMP4, TOT_PARTIDA = @TOT_PARTIDA " &
            "WHERE CVE_DOC = @CVE_DOC " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCPAR_FACT (CVE_DOC, CVE_ART, CANT, CVE_CPTO, DESCT, DES_TOT, IMP1, IMP2, IMP3, IMP4, TOT_PARTIDA)" &
            " VALUES(@CVE_DOC, @CVE_ART, @CANT, @CVE_CPTO, @DESCT, @DES_TOT, @IMP1, @IMP2, @IMP3, @IMP4, @TOT_PARTIDA)"

        For k = 1 To Fg.Rows.Count - 1
            Try
                Sigue = False
                Try
                    If Fg(k, 1) Then
                        Sigue = True
                    End If
                Catch ex As Exception
                    Bitacora("10.1. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If Sigue Then
                    cmd.CommandText = SQL
                    'Fg.AddItem("" & vbTab & "CHECK" & vbTab & "1" & vbTab & dr("ART") & vbTab & dr("DES") & vbTab & dr("CPTO") & vbTab &
                    '          "0" & vbTab & IVA & vbTab & RET & vbTab & IMPORTE)

                    CANT = Fg(k, 1)
                    DESC = Fg(k, 6)
                    IMP1 = Fg(k, 9)
                    IMP4 = Fg(k, 8)
                    PRECIO = Fg(k, 9)
                    DES_TOT = CANT * PRECIO * DESC / 100
                    TOT_PARTIDA = CANT * PRECIO

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = LtCVE_DOC.Text
                    cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = Fg(k, 3)
                    cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 2))
                    cmd.Parameters.Add("@CVE_CPTO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(Fg(k, 5))
                    cmd.Parameters.Add("@DESCT", SqlDbType.Float).Value = DESC
                    cmd.Parameters.Add("@DES_TOT", SqlDbType.Float).Value = DES_TOT
                    cmd.Parameters.Add("@IMP1", SqlDbType.Float).Value = IMP1
                    cmd.Parameters.Add("@IMP2", SqlDbType.Float).Value = 0
                    cmd.Parameters.Add("@IMP3", SqlDbType.Float).Value = 0
                    cmd.Parameters.Add("@IMP4", SqlDbType.Float).Value = IMP4
                    cmd.Parameters.Add("@TOT_PARTIDA", SqlDbType.Float).Value = TOT_PARTIDA
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                msgbox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub btnContrato_Click(sender As Object, e As EventArgs) Handles btnContrato.Click
        Try
            Var2 = "Contrato"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_CON.Text = Var4
                LtClave.Text = Var6
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
                BUSCA_CONTRATO()
                tCVE_VIAJE.Focus()
            End If
        Catch ex As Exception
            Bitacora("49. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("49. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnViaje_Click(sender As Object, e As EventArgs) Handles btnViaje.Click
        Try
            Var2 = "Viajes"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_VIAJE.Text = Var4
                LtViaje.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tDesc.Focus()
            End If
        Catch ex As Exception
            Bitacora("49. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("49. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub BUSCA_CONTRATO()
        Try
            Dim Sigue As Boolean
            Dim IMPORTE As Single
            Dim IVA As Single
            Dim RET As Single
            Dim CAN_TOT As Single
            Dim IMPUESTO As Single
            Dim RETENCION As Single
            Dim TOT_DESC As Single
            Dim DESC As Single
            Dim CANT As Single

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            Sigue = True
            DESC = tDesc.Value

            If tCVE_CON.Text.Trim.Length > 0 Then
                SQL = "SELECT T.CVE_CON, T.NO_CONTRATO, ISNULL(CLAVE_O,'') AS CLIENTE, ISNULL(NOMBRE, '') AS NOMB, ISNULL(N.CVE_ART,'') AS ART, " &
                    "ISNULL(I.DESCR, '') AS DES, ISNULL(N.CVE_CPTO, 0) AS CPTO, " &
                    "ISNULL(N.TRASLADO,0) AS TRAS, ISNULL(N.RETIENE,0) AS RET, ISNULL(N.IMPORTE, 0) AS IMPORT, " &
                    "ISNULL(CALLE,'') AS DIRE, ISNULL(MUNICIPIO,'') AS MUNI, ISNULL(RFC,'') AS RF, ISNULL(CODIGO,'') AS CP, ISNULL(ESTADO, '') AS EST, " &
                    "ISNULL(COLONIA,'') AS COLO, ISNULL(NUMINT,'') AS NOINT, ISNULL(NUMEXT,'') AS NOEXT " &
                    "FROM GCCONTRATO T " &
                    "LEFT JOIN GCCONTRATO_CONC N ON N.CVE_CON = T.CVE_CON " &
                    "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = N.CVE_ART " &
                    "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = CC.CLAVE_O " &
                    "WHERE T.CVE_CON = '" & tCVE_CON.Text & "' AND CLAVE_O = '" & LtClave.Text & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                Fg.Rows.Count = 1

                Do While dr.Read
                    If Sigue Then
                        LtClave.Text = dr("CLIENTE")
                        LtNombre.Text = dr("NOMB")
                        LtCalle.Text = dr("DIRE")
                        LtNoINt.Text = dr("NOINT")
                        LtNoExt.Text = dr("NOEXT")
                        LtRFC.Text = dr("RF")
                        LtCP.Text = dr("CP")
                        LtCol.Text = dr("COLO")
                        LtCiudad.Text = dr("MUNI")
                        LtEstado.Text = dr("EST")
                        Sigue = False
                    End If

                    CANT = 1
                    IMPORTE = dr("IMPORT")
                    IVA = IIf(dr("TRAS"), 16, 0)
                    RET = IIf(dr("RET"), -16, 0)
                    CAN_TOT = CAN_TOT + IMPORTE
                    IMPUESTO = IMPUESTO + (IMPORTE * IVA / 100)
                    RETENCION = RETENCION + (IMPORTE * RET / 100)

                    Fg.AddItem("" & vbTab & true & vbTab & "1" & vbTab & dr("ART") & vbTab & dr("DES") & vbTab & dr("CPTO") & vbTab &
                               "0" & vbTab & IVA & vbTab & RET & vbTab & IMPORTE)
                Loop
                dr.Close()

                TOT_DESC = (CAN_TOT * DESC / 100)

                LtSubTotal.Text = Format(CAN_TOT, "###,##0.00")
                LtDesc.Text = Format(TOT_DESC, "###,##0.00")
                LtRet.Text = Format(RETENCION, "###,##0.00")
                LtIva.Text = Format(IMPUESTO, "###,##0.00")
                LtTotal.Text = Format(CAN_TOT - TOT_DESC + RETENCION + IMPUESTO, "###,##0.00")

                'Fg.AutoSizeCols()
                Fg.AutoSizeRows()
                Fg.Rows(0).Height = 35
            End If

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub Calcular()
        Dim IMPORTE As Single
        Dim IVA As Single
        Dim RET As Single
        Dim CAN_TOT As Single
        Dim IMPUESTO As Single
        Dim RETENCION As Single
        Dim TOT_DESC As Single
        Dim DESC As Single
        Dim CANT As Single

        Try

            DESC = tDesc.Value

            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) Then
                    CANT = Fg(k, 2)
                    IMPORTE = Fg(k, 9)
                    IVA = Fg(k, 7)
                    RET = Fg(k, 8)
                    Fg(k, 6) = DESC
                    TOT_DESC = TOT_DESC + (IMPORTE * DESC / 100)
                    IMPORTE = IMPORTE - (IMPORTE * DESC / 100)

                    CAN_TOT = CAN_TOT + IMPORTE
                    IMPUESTO = IMPUESTO + (IMPORTE * IVA / 100)
                    RETENCION = RETENCION + (IMPORTE * RET / 100)

                End If
            Next

            LtSubTotal.Text = Format(CAN_TOT, "###,##0.00")
            LtDesc.Text = Format(TOT_DESC, "###,##0.00")
            LtRet.Text = Format(RETENCION, "###,##0.00")
            LtIva.Text = Format(IMPUESTO, "###,##0.00")
            LtTotal.Text = Format(CAN_TOT - TOT_DESC + RETENCION + IMPUESTO, "###,##0.00")

        Catch ex As Exception
            Bitacora("94. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("94. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmFacturacionAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Factura")
            Me.Dispose()

            If FORM_IS_OPEN("frmFacturacion") Then
                frmFacturacion.DESPLEGAR()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles Fg.AfterEdit
        Calcular()
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        If Fg.Row > 0 Then
            If Fg.Col <> 1 Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        If e.Row = 0 AndAlso e.Col = 1 Then
            ChangeState(Fg.GetCellCheck(e.Row, e.Col))
        Else
            If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)
        End If
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, 1, state)
        Next
    End Sub
    Private Sub tDesc_Validated(sender As Object, e As EventArgs) Handles tDesc.Validated
        If tDesc.Value > 0 Then
            Calcular()
        End If
    End Sub
    Private Sub tDesc_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tDesc.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Fg.Focus()
            If tDesc.Value > 0 Then
                Calcular()
            End If
        End If
    End Sub
    Private Sub tCVE_VIAJE_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_VIAJE.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            LtViaje.Text = BUSCA_CAT("Viajes", tCVE_VIAJE.Text)
            Fg.Focus()
        End If
    End Sub

    Private Sub tDesc_TextChanged(sender As Object, e As EventArgs) Handles tDesc.TextChanged
        Calcular()

    End Sub
End Class
