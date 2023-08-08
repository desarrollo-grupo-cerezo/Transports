Imports System.Data.SqlClient
Public Class frmContapAE
    Private Sub frmContapAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        cboTipoContacto.Items.Clear()
        cboTipoContacto.Items.Add("Administración")
        cboTipoContacto.Items.Add("Almacén")
        cboTipoContacto.Items.Add("Cobranza")
        cboTipoContacto.Items.Add("Compras")
        cboTipoContacto.Items.Add("Pagos")
        cboTipoContacto.Items.Add("Ventas")
        cboTipoContacto.Items.Add("Otro")

        tNCONTACTO.Text = ""
        tCVE_PROV.Text = ""
        tNOMBRE.Text = ""
        tDIRECCION.Text = ""
        tTELEFONO.Text = ""
        tEMAIL.Text = ""
        cboTipoContacto.SelectedIndex = 6

        If Var1 = "Nuevo" Then
            Try
                tNCONTACTO.Text = GET_MAX("CONTAP" & Empresa, "NCONTACTO")
                tNCONTACTO.Enabled = False
                tNOMBRE.Text = ""
                tNOMBRE.Select()
            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT N.NCONTACTO, N.CVE_PROV, N.NOMBRE, N.DIRECCION, N.TELEFONO, N.EMAIL, N.TIPOCONTAC " &
                    "FROM CONTAP" & Empresa & " N WHERE N.NCONTACTO = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tNCONTACTO.Text = dr("NCONTACTO").ToString
                    tCVE_PROV.Text = dr("CVE_PROV").ToString
                    LtProv.Text = BUSCA_CAT("Prov", tCVE_PROV.Text)
                    tNOMBRE.Text = dr("NOMBRE").ToString
                    tDIRECCION.Text = dr("DIRECCION").ToString
                    tTELEFONO.text = dr("TELEFONO").ToString
                    tEMAIL.Text = dr("EMAIL").ToString
                    Select Case dr("TIPOCONTAC").ToString
                        Case "T"
                            cboTipoContacto.SelectedIndex = 6
                        Case "C"
                            cboTipoContacto.SelectedIndex = 2
                        Case "V"
                            cboTipoContacto.SelectedIndex = 5
                        Case "O"
                            cboTipoContacto.SelectedIndex = 3
                        Case "A"
                            cboTipoContacto.SelectedIndex = 0
                        Case "L"
                            cboTipoContacto.SelectedIndex = 1
                        Case "P"
                            cboTipoContacto.SelectedIndex = 4
                    End Select
                End If
                dr.Close()

                tNCONTACTO.Enabled = False
                tCVE_PROV.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

    End Sub

    Private Sub frmContapAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmContapAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim TIPOCONTAC As String

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE


        If tNOMBRE.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        TIPOCONTAC = "T"

        Select Case cboTipoContacto.SelectedIndex
            Case 6
                TIPOCONTAC = "T"
            Case 2
                TIPOCONTAC = "C"
            Case 5
                TIPOCONTAC = "V"
            Case 3
                TIPOCONTAC = "O"
            Case 0
                TIPOCONTAC = "A"
            Case 1
                TIPOCONTAC = "L"
            Case 4
                TIPOCONTAC = "P"
        End Select

        SQL = "UPDATE CONTAP" & Empresa & " SET NCONTACTO = @NCONTACTO, CVE_PROV = @CVE_PROV, NOMBRE = @NOMBRE, DIRECCION = @DIRECCION, TELEFONO = @TELEFONO, EMAIL = @EMAIL, " &
            "TIPOCONTAC = @TIPOCONTAC " &
            " WHERE NCONTACTO = @NCONTACTO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO CONTAP" & Empresa & " (NCONTACTO, CVE_PROV, NOMBRE, DIRECCION, TELEFONO, EMAIL, TIPOCONTAC, STATUS)" &
            " VALUES (@NCONTACTO, @CVE_PROV, @NOMBRE, @DIRECCION, @TELEFONO, @EMAIL, @TIPOCONTAC, 'A')"

        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@NCONTACTO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tNCONTACTO.Text)
            cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = tCVE_PROV.Text
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = tNOMBRE.Text
            cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = tDIRECCION.Text
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = tTELEFONO.Text
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = tEMAIL.Text
            cmd.Parameters.Add("@TIPOCONTAC", SqlDbType.VarChar).Value = TIPOCONTAC
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
    Private Sub btnZona_Click(sender As Object, e As EventArgs) Handles btnZona.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PROV.Text = Var4
                LtProv.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tNOMBRE.Focus()
            End If
        Catch ex As Exception
            Bitacora("357. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("357. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnZona_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_PROV_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV.Validated
        Try
            If tCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If tCVE_PROV.Text.Length < 5 Then
                    If IsNumeric(tCVE_PROV.Text.Trim) Then
                        DESCR = tCVE_PROV.Text.Trim
                        DESCR = Space(10 - DESCR.Length) & DESCR
                        tCVE_PROV.Text = DESCR
                    End If
                End If
                DESCR = BUSCA_CAT("Prov", tCVE_PROV.Text)
                If DESCR <> "" Then
                    LtProv.Text = DESCR
                Else
                    MsgBox("Proveedor inexistente")
                    tCVE_PROV.Text = ""
                    LtProv.Text = ""
                    tCVE_PROV.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
