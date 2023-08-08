Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Themes

Public Class FrmParamSeriesAE
    Private NewReg As Boolean
    Private TIPODOCTO As String

    Private Sub FrmParamSeriesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()


            CboMascara.Items.Add("Derecha y ceros")
            CboMascara.Items.Add("Izquierda")

            CboStatus.Items.Add("Disponible")
            CboStatus.Items.Add("Bloqueado")
            Me.KeyPreview = True

            RadImpreso.Checked = True
            TSERIE.Text = ""
            TFTOEMISION.Text = ""
            CboMascara.SelectedIndex = 0
            TFOLIOINICIAL.Value = 0
            TLONGITUD.Value = 0
            CboStatus.SelectedIndex = 0
            TFTOEMISION_CFDI.Text = ""

            TIPODOCTO = Var12

        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then

            NewReg = True
            Try
                TSERIE.Text = ""
                TSERIE.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            NewReg = False
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                'INDEX 
                'NUM_EMP, TIPODOCTO, SERIE
                SQL = "SELECT NUM_EMP, TIPODOCTO, SERIE, ISNULL(TIPO,'I') AS TIP, ISNULL(MASCARA,1) AS MASCA, ISNULL(FTOEMISION,'') AS FTOEMI, 
                    ISNULL(FOLIOINICIAL,0) AS FOLINI, ISNULL(LONGITUD,0) AS LONGI, ISNULL(STATUS,'') AS ST, ISNULL(FTOEMISIONCFDI40,'') AS FTO40
                    FROM PARAM_FOLIOSF" & Empresa & " 
                    WHERE TIPODOCTO = '" & TIPODOCTO & "' AND SERIE = '" & Var3 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    If dr("TIP") = "I" Then
                        RadImpreso.Checked = True
                    Else
                        RadDigital.Checked = True
                    End If

                    TSERIE.Text = dr("SERIE")
                    TFTOEMISION.Text = dr("FTOEMI")
                    If dr("MASCA") = 1 Then
                        CboMascara.SelectedIndex = 0
                    Else
                        CboMascara.SelectedIndex = 1
                    End If

                    TFOLIOINICIAL.Value = dr("FOLINI")
                    TLONGITUD.Value = dr("LONGI")

                    If dr("ST") = "D" Then
                        CboStatus.SelectedIndex = 0
                    Else
                        CboStatus.SelectedIndex = 1
                    End If
                    TFTOEMISION.Text = dr("FTOEMI")
                    TFTOEMISION_CFDI.Text = dr("FTO40")
                End If
                dr.Close()

                TSERIE.Enabled = False
                TFOLIOINICIAL.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmParamSeriesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarGrabar.Click
        Dim NUMFOLIO As String, SERIE As String, CVE_FOLIO As String, FILE1 As String = "", FILE2 As String = ""

        If TSERIE.Text.Trim.Length = 0 Then
            SERIE = "STAND."
            CVE_FOLIO = "STAND."
            NUMFOLIO = "NULL"
        Else
            SERIE = TSERIE.Text
            CVE_FOLIO = "1"
            NUMFOLIO = "1"
        End If

        Try
            Dim rutaCg As String = GET_RUTA_FORMATOS()
            Dim copyToDir As String = ""
            Dim file As String = ""

            If TFTOEMISION.Text.Trim.Length > 0 Then

                copyToDir = Path.GetDirectoryName(TFTOEMISION.Text)
                file = Path.GetFileName(TFTOEMISION.Text)

                If rutaCg = copyToDir Then
                    FILE1 = rutaCg & "\" & file
                Else
                    Dim newPath = Path.Combine(copyToDir, file)
                    Try
                        IO.File.Copy(TFTOEMISION.Text, rutaCg & "\" & file, True)
                    Catch ex As Exception
                    End Try
                End If
            End If

            If TFTOEMISION_CFDI.Text.Trim.Length > 0 Then

                copyToDir = Path.GetDirectoryName(TFTOEMISION_CFDI.Text)
                file = Path.GetFileName(TFTOEMISION_CFDI.Text)
                If rutaCg = copyToDir Then
                    FILE2 = rutaCg & "\" & file
                Else
                    Dim newPath = Path.Combine(copyToDir, file)
                    Try
                        IO.File.Copy(TFTOEMISION_CFDI.Text, rutaCg & "\" & file, True)
                        FILE2 = rutaCg & "\" & file
                    Catch ex As Exception
                    End Try
                End If
            End If


            SQL = "IF EXISTS (SELECT SERIE FROM PARAM_FOLIOSF" & Empresa & " WHERE TIPODOCTO = @TIPODOCTO AND SERIE = @SERIE)
                UPDATE PARAM_FOLIOSF" & Empresa & " SET TIPO = @TIPO, FTOEMISION = @FTOEMISION, MASCARA = @MASCARA, FOLIOINICIAL = @FOLIOINICIAL, 
                STATUS = @STATUS, FTOEMISIONCFDI40 = @FTOEMISIONCFDI40
                WHERE TIPODOCTO = @TIPODOCTO AND SERIE = @SERIE
            ELSE
                INSERT INTO PARAM_FOLIOSF" & Empresa & " (NUM_EMP, NUMFOLIO, CVEFOLIO, TIPODOCTO, TIPO, SERIE, FTOEMISION, MASCARA, 
                FOLIOINICIAL, FOLIOFINAL, LONGITUD, STATUS, FTOEMISIONCFDI40)
                VALUES(
                @NUM_EMP, @NUMFOLIO, @CVEFOLIO, @TIPODOCTO, @TIPO, @SERIE, @FTOEMISION, @MASCARA, @FOLIOINICIAL, @FOLIOFINAL, @LONGITUD, 
                @STATUS, @FTOEMISIONCFDI40)"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@NUM_EMP", SqlDbType.Int).Value = CONVERTIR_TO_INT(Empresa)
                cmd.Parameters.Add("@NUMFOLIO", SqlDbType.VarChar).Value = NUMFOLIO
                cmd.Parameters.Add("@CVEFOLIO", SqlDbType.VarChar).Value = CVE_FOLIO
                cmd.Parameters.Add("@TIPODOCTO", SqlDbType.VarChar).Value = TIPODOCTO
                cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = IIf(RadImpreso.Checked, "I", "D")
                cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE
                cmd.Parameters.Add("@FTOEMISION", SqlDbType.VarChar).Value = FILE1
                cmd.Parameters.Add("@MASCARA", SqlDbType.VarChar).Value = CboMascara.SelectedIndex + 1
                cmd.Parameters.Add("@FOLIOINICIAL", SqlDbType.Int).Value = CONVERTIR_TO_INT(TFOLIOINICIAL.Text)
                cmd.Parameters.Add("@FOLIOFINAL", SqlDbType.Int).Value = 1
                cmd.Parameters.Add("@LONGITUD", SqlDbType.Int).Value = CONVERTIR_TO_INT(TLONGITUD.Text)
                cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = IIf(CboStatus.SelectedIndex = 0, "D", "B")
                cmd.Parameters.Add("@FTOEMISIONCFDI40", SqlDbType.VarChar).Value = FILE2
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then


                        MsgBox("La serie se grabo correctamente")
                        Me.Close()
                    Else
                        MsgBox("No se logro grabr la serie")
                    End If
                Else
                    MsgBox("No se logro grabr la serie")
                End If
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnFtoEmision_Click(sender As Object, e As EventArgs) Handles BtnFtoEmision.Click
        Try
            Dim openExcelFileDialog As New OpenFileDialog With {
                .Filter = "Reporte mrt (*.mrt)|*.mrt",
                .FilterIndex = 1,
                .RestoreDirectory = True
            }
            If openExcelFileDialog.ShowDialog() = DialogResult.OK Then
                TFTOEMISION.Text = openExcelFileDialog.FileName
            Else
                TFTOEMISION.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnFtoEmisionCFDI_Click(sender As Object, e As EventArgs) Handles BtnFtoEmisionCFDI.Click
        Try
            Dim openExcelFileDialog As New OpenFileDialog With {
                .Filter = "Reporte mrt (*.mrt)|*.mrt",
                .FilterIndex = 1,
                .RestoreDirectory = True
            }
            If openExcelFileDialog.ShowDialog() = DialogResult.OK Then
                TFTOEMISION_CFDI.Text = openExcelFileDialog.FileName
            Else
                TFTOEMISION_CFDI.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnDisenador1_Click(sender As Object, e As EventArgs) Handles BtnDisenador1.Click

        If NewReg Then
            Dim result = RJMessageBox.Show("Primero grabe la serie por favor", "Advertencia", MessageBoxButtons.OK)
            Return
        End If
        Try
            If TFTOEMISION.Text.Trim.Length > 0 Then
                If TFTOEMISION.Text.IndexOf(".mrt") > -1 Then
                    If IO.File.Exists(TFTOEMISION.Text) Then

                        PrinterMRT(Path.GetFileNameWithoutExtension(TFTOEMISION.Text))

                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BtnDisenador2_Click(sender As Object, e As EventArgs) Handles BtnDisenador2.Click
        If NewReg Then
            Dim result = RJMessageBox.Show("Primero grabe la serie por favor", "Advertencia", MessageBoxButtons.OK)
            Return
        End If
        Try
            If TFTOEMISION.Text.Trim.Length > 0 Then
                If TFTOEMISION.Text.IndexOf(".mrt") > -1 Then
                    If IO.File.Exists(TFTOEMISION.Text) Then
                        PrinterMRT(Path.GetFileNameWithoutExtension(TFTOEMISION_CFDI.Text))
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class