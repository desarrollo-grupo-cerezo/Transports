Imports System.Data.SqlClient
Public Class frmProductosAE
    Private Sub frmProductosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Me.CenterToScreen()
        CboMatPeligroso.Items.Add("Sí")
        CboMatPeligroso.Items.Add("No")

        If Var1 = "Nuevo" Then
            Try
                tCVE_PROD.Text = GET_MAX("GCPRODUCTOS", "CVE_PROD")
                tCVE_PROD.Enabled = False
                tDescr.Text = ""
                tDescr.Select()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT P.CVE_PROD, P.DESCR, P.STATUS, P.GUID, CUEN_CONT, ISNULL(MAT_PELIGROSO,-1) AS MAT_PELI, CVE_MAT_PELIGROSO,
                     EMBALAJE, UNIDADPESO, BIENESTRANSP
                     FROM GCPRODUCTOS P WHERE CVE_PROD = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_PROD.Text = dr("CVE_PROD").ToString
                    tDescr.Text = dr("DESCR").ToString
                    tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")

                    If dr.ReadNullAsEmptyInteger("MAT_PELI") = 0 Then
                        CboMatPeligroso.SelectedIndex = 0
                        PanelMatPeligro.Visible = True
                    Else
                        PanelMatPeligro.Visible = False
                        CboMatPeligroso.SelectedIndex = 1
                    End If
                    TUnidadPeso.Text = dr.ReadNullAsEmptyString("UNIDADPESO")
                    TBienesTransp.Text = dr.ReadNullAsEmptyString("BIENESTRANSP")
                    TCveMaterialPeligroso.Text = dr.ReadNullAsEmptyString("CVE_MAT_PELIGROSO")
                    LTCveMaterialPeligroso.Text = GET_MAT_PELIGROSO(TCveMaterialPeligroso.Text)
                    TEmbalaje.Text = dr.ReadNullAsEmptyString("EMBALAJE")
                    LTEmbalaje.Text = GET_MAT_EMBALAJE(TEmbalaje.Text)
                Else
                    tCVE_PROD.Text = ""
                    tDescr.Text = ""
                End If
                dr.Close()

                TEmbalaje_Validated(Nothing, Nothing)
                TCveMaterialPeligroso_Validated(Nothing, Nothing)
                TUnidadPeso_Validated(Nothing, Nothing)
                TBienesTransp_Validated(Nothing, Nothing)

                tCVE_PROD.Enabled = False
                tDescr.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmProductosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmProductosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCPRODUCTOS SET CVE_PROD = @CVE_PROD, DESCR = @DESCR, CUEN_CONT = @CUEN_CONT, MAT_PELIGROSO = @MAT_PELIGROSO, 
            CVE_MAT_PELIGROSO = @CVE_MAT_PELIGROSO, EMBALAJE = @EMBALAJE, UNIDADPESO = @UNIDADPESO, BIENESTRANSP = @BIENESTRANSP
            WHERE CVE_PROD = @CVE_PROD
            IF @@ROWCOUNT = 0
            INSERT INTO GCPRODUCTOS (CVE_PROD, DESCR, STATUS, GUID, CUEN_CONT, MAT_PELIGROSO, CVE_MAT_PELIGROSO, EMBALAJE, UNIDADPESO,
            BIENESTRANSP)  VALUES (@CVE_PROD, @DESCR, 'A', NEWID(), @CUEN_CONT, @MAT_PELIGROSO, @CVE_MAT_PELIGROSO, 
            @EMBALAJE, @UNIDADPESO, @BIENESTRANSP)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_PROD", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_PROD.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text

            cmd.Parameters.Add("@UNIDADPESO", SqlDbType.VarChar).Value = TUnidadPeso.Text
            cmd.Parameters.Add("@BIENESTRANSP", SqlDbType.VarChar).Value = TBienesTransp.Text
            cmd.Parameters.Add("@MAT_PELIGROSO", SqlDbType.SmallInt).Value = CboMatPeligroso.SelectedIndex
            cmd.Parameters.Add("@CVE_MAT_PELIGROSO", SqlDbType.VarChar).Value = TCveMaterialPeligroso.Text
            cmd.Parameters.Add("@EMBALAJE", SqlDbType.VarChar).Value = TEmbalaje.Text
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

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub


    Private Sub BtnCveMaterialPeligroso_Click(sender As Object, e As EventArgs) Handles BtnCveMaterialPeligroso.Click
        Try
            Var2 = "tblcmaterialpeligroso"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCveMaterialPeligroso.Text = Var4
                LTCveMaterialPeligroso.Text = Var5
                TEmbalaje.Focus()
            End If
        Catch ex As Exception
            Bitacora("1300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCveMaterialPeligroso_KeyDown(sender As Object, e As KeyEventArgs) Handles TCveMaterialPeligroso.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCveMaterialPeligroso_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCveMaterialPeligroso_Validated(sender As Object, e As EventArgs) Handles TCveMaterialPeligroso.Validated
        Try
            If TCveMaterialPeligroso.Text.Trim.Length > 0 Then
                LTCveMaterialPeligroso.Text = GET_MAT_PELIGROSO(TCveMaterialPeligroso.Text, "S")
            Else
                LTCveMaterialPeligroso.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function GET_MAT_PELIGROSO(fCVE_MAT_PELIGROSO As String, Optional FMensaje As String = "") As String
        Dim CVE_MAT As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM tblcmaterialpeligroso WHERE clave = '" & TCveMaterialPeligroso.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_MAT = dr("descripcion")
                    Else
                        If FMensaje = "S" Then
                            MsgBox("Material peligroso inexistente")
                        End If
                    End If
                End Using
            End Using
            Return CVE_MAT
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_MAT
        End Try
    End Function
    Private Sub BtnEmbalaje_Click(sender As Object, e As EventArgs) Handles BtnEmbalaje.Click
        Try
            Var2 = "tblctipoembalaje"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TEmbalaje.Text = Var4
                LTEmbalaje.Text = Var5
            End If
        Catch ex As Exception
            Bitacora("1290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TEmbalaje_KeyDown(sender As Object, e As KeyEventArgs) Handles TEmbalaje.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEmbalaje_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TEmbalaje_Validated(sender As Object, e As EventArgs) Handles TEmbalaje.Validated
        Try
            If TEmbalaje.Text.Trim.Length > 0 Then
                LTEmbalaje.Text = GET_MAT_EMBALAJE(TEmbalaje.Text)
            Else
                LTEmbalaje.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function GET_MAT_EMBALAJE(fEMBALAJE As String, Optional FMensaje As String = "") As String
        Dim EMBALAJE As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM tblctipoembalaje WHERE clave = '" & fEMBALAJE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        EMBALAJE = dr("descripcion")
                    Else
                        If FMensaje = "S" Then
                            MsgBox("Embalaje inexistente")
                        End If
                    End If
                End Using
            End Using
            Return EMBALAJE
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            Return EMBALAJE
        End Try
    End Function

    Private Sub CboMatPeligroso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMatPeligroso.SelectedIndexChanged
        Try
            If CboMatPeligroso.SelectedIndex = 0 Then
                PanelMatPeligro.Visible = True
            Else
                PanelMatPeligro.Visible = False
            End If
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnUnidadPeso_Click(sender As Object, e As EventArgs) Handles BtnUnidadPeso.Click
        Try
            Var2 = "tblcclaveunidadpeso"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TUnidadPeso.Text = Var4
                LTUnidadPeso.Text = Var5
                TBienesTransp.Focus()
            End If
        Catch ex As Exception
            Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnBienesTransp_Click(sender As Object, e As EventArgs) Handles BtnBienesTransp.Click
        Try
            Var2 = "SAT_CLAVEPROD_SERVCP"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TBienesTransp.Text = Var4
                LTBienesTransp.Text = Var5
                CboMatPeligroso.Focus()
            End If
        Catch ex As Exception
            Bitacora("1320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TUnidadPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles TUnidadPeso.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUnidadPeso_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TUnidadPeso_Validated(sender As Object, e As EventArgs) Handles TUnidadPeso.Validated
        Try
            If TUnidadPeso.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM tblcclaveunidadpeso WHERE clave = '" & TUnidadPeso.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTUnidadPeso.Text = dr("nombre")
                            TBienesTransp.Focus()
                        Else
                            MsgBox("Unidad de peso inexistente")
                            LTUnidadPeso.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTUnidadPeso.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TBienesTransp_KeyDown(sender As Object, e As KeyEventArgs) Handles TBienesTransp.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnBienesTransp_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TBienesTransp_Validated(sender As Object, e As EventArgs) Handles TBienesTransp.Validated
        Try
            If TBienesTransp.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM SAT_CLAVEPROD_SERVCP WHERE CLAVE_PROD = '" & TBienesTransp.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTBienesTransp.Text = dr("DESCR")
                            CboMatPeligroso.Focus()
                        Else
                            MsgBox("Bienes transporte inexistente")
                            LTBienesTransp.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTBienesTransp.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmProductosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
