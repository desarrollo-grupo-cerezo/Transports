Imports System.Data.SqlClient
Imports System.Xml

Public Class FrmPlazasAE
    Private Sub FrmPlazasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        TMUNICIPIO.Text = ""
        TCVE_ESTADO.Text = ""
        LtEstado.Text = ""

        BtnEstado.FlatStyle = FlatStyle.Flat
        BtnEstado.FlatAppearance.BorderSize = 0
        BarraMenu.BackColor = Color.FromArgb(164, 177, 202)

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Me.CenterToScreen()

        If Var1 = "Nuevo" Then
            Try
                TCLAVE.Text = GET_MAX("GCPLAZAS", "CLAVE")
                TCLAVE.Enabled = False
                TLOCALIDAD.Text = ""
                TLOCALIDAD.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT P.CLAVE, P.CIUDAD, P.MUNICIPIO, P.CVE_ESTADO, CUEN_CONT, CLAVE_SAT_LOC, CLAVE_SAT_MUN 
                    FROM GCPLAZAS P WHERE CLAVE = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCLAVE.Text = dr("CLAVE").ToString
                    TLOCALIDAD.Text = dr("CIUDAD").ToString
                    TMUNICIPIO.Text = dr("MUNICIPIO").ToString
                    TCVE_ESTADO.Text = dr("CVE_ESTADO").ToString
                    TCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                    TCLAVE_SAT_LOC.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_LOC")
                    TCLAVE_SAT_MUN.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_MUN")
                End If
                dr.Close()

                If TCVE_ESTADO.Text.Trim.Length > 0 Then
                    tCVE_ESTADO_Validated(Nothing, Nothing)
                End If

                TCLAVE.Enabled = False
                TLOCALIDAD.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FrmPlazasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub FrmPlazasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        If TLOCALIDAD.Text.Trim.Length = 0 Then
            MsgBox("La ciudad no debe quedar vacia, verifique por favor")
            Return
        End If

        If TMUNICIPIO.Text.Trim.Length = 0 Then
            MsgBox("El municipio no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCPLAZAS SET CIUDAD = @CIUDAD, MUNICIPIO = @MUNICIPIO, CVE_ESTADO = @CVE_ESTADO, CUEN_CONT = @CUEN_CONT, 
            CLAVE_SAT_LOC = @CLAVE_SAT_LOC, CLAVE_SAT_MUN = @CLAVE_SAT_MUN
            WHERE CLAVE = @CLAVE
            IF @@ROWCOUNT = 0
            INSERT INTO GCPLAZAS (CLAVE, STATUS, CIUDAD, MUNICIPIO, CVE_ESTADO, CUEN_CONT, CLAVE_SAT_LOC, CLAVE_SAT_MUN) VALUES(@CLAVE, 'A', 
            @CIUDAD, @MUNICIPIO, @CVE_ESTADO, @CUEN_CONT, @CLAVE_SAT_LOC, @CLAVE_SAT_MUN)"
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CLAVE", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCLAVE.Text)
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = TLOCALIDAD.Text
            cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMUNICIPIO.Text
            cmd.Parameters.Add("@CVE_ESTADO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_ESTADO.Text)
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = TCUEN_CONT.Text
            cmd.Parameters.Add("@CLAVE_SAT_LOC", SqlDbType.VarChar).Value = TCLAVE_SAT_LOC.Text
            cmd.Parameters.Add("@CLAVE_SAT_MUN", SqlDbType.VarChar).Value = TCLAVE_SAT_MUN.Text
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

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub TCVE_ESTADO_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ESTADO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnEstado_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                TCUEN_CONT.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCVE_ESTADO_Validated(sender As Object, e As EventArgs) Handles TCVE_ESTADO.Validated
        Try
            If TCVE_ESTADO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Estados", TCVE_ESTADO.Text)
                If DESCR <> "" Then
                    LtEstado.Text = DESCR
                    TLOCALIDAD.Focus()
                    TLOCALIDAD.SelectAll()
                    BUSCA_ESTADO(CInt(TCVE_ESTADO.Text))
                Else
                    MsgBox("Estado inexistente")
                    TCVE_ESTADO.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEstado_Click(sender As Object, e As EventArgs) Handles BtnEstado.Click
        Try
            Var2 = "Estados"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ESTADO.Text = Var4
                LtEstado.Text = Var5
                BUSCA_ESTADO(CInt(TCVE_ESTADO.Text))
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TCUEN_CONT.Focus()
            End If

        Catch Ex As Exception
            MsgBox("102. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("102. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub BUSCA_ESTADO(FESTADO As Integer)
        Try
            SQL = "SELECT E.CVE_ESTADO, E.NUM_ESTADO, E.NOMBRE, E.PAIS, CLAVE_SAT_EST, CLAVE_SAT_PAIS 
                FROM GCESTADOS E 
                WHERE CVE_ESTADO = " & FESTADO
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        LtEstado.Text = dr.ReadNullAsEmptyString("NOMBRE")
                        LtClaveSatEstado.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_EST")
                        LtPais.Text = dr.ReadNullAsEmptyString("PAIS")
                        LtClaveSatPais.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_PAIS")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("102. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("102. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPlazasAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()

    End Sub

    Private Sub TCVE_ESTADO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_ESTADO.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCUEN_CONT.Focus()
        End If
    End Sub

    Private Sub BtnMunicipio_Click(sender As Object, e As EventArgs) Handles BtnMunicipio.Click
        Try
            Prosec = "Municipio"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCLAVE_SAT_MUN.Text = Var10
                TMUNICIPIO.Text = Var12

            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLAVE_SAT_MUN_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLAVE_SAT_MUN.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMunicipio_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCLAVE_SAT_MUN_Validated(sender As Object, e As EventArgs) Handles TCLAVE_SAT_MUN.Validated
        Dim doc As New XmlDocument()
        Try
            If TMUNICIPIO.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TMUNICIPIO.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Localidad inexistente, verifique por favor")
                    End If
                Else
                    MsgBox("Catálogo " & Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml inexistente, verifique por favor")
                End If
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLocalidad_Click(sender As Object, e As EventArgs) Handles BtnLocalidad.Click
        Try
            Prosec = "Localidad"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCLAVE_SAT_LOC.Text = Var10
                TLOCALIDAD.Text = Var12
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLAVE_SAT_LOC_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLAVE_SAT_LOC.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnLocalidad_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCLAVE_SAT_LOC_Validated(sender As Object, e As EventArgs) Handles TCLAVE_SAT_LOC.Validated
        Dim doc As New XmlDocument()
        Try
            If TLOCALIDAD.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TLOCALIDAD.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Localidad inexistente, verifique por favor")
                    End If
                Else
                    MsgBox("Catálogo " & Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml inexistente, verifique por favor")
                End If
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
