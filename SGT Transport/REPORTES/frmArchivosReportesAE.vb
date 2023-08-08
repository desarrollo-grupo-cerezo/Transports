Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Public Class frmArchivosReportesAE
    Private Sub frmArchivosReportesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.KeyPreview = True
        If Var1 = "Nuevo" Then
            Try
                tCVE_REP.Text = GET_MAX("GCFORMATOS", "CVE_REP")
                tCVE_REP.Enabled = False
                tDescr.Text = ""
                tNombre.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT F.CVE_REP, F.NOMBRE, F.DESCR, F.ARCHIVO, F.FECHAELAB, F.UUID FROM GCFORMATOS F WHERE CVE_REP = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_REP.Text = dr("CVE_REP").ToString
                    tNombre.Text = dr("NOMBRE").ToString
                    tDescr.Text = dr("DESCR").ToString
                    tFormato.Text = dr("ARCHIVO").ToString
                End If
                dr.Close()

                tCVE_REP.Enabled = False
                tNombre.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE GCFORMATOS SET NOMBRE = @NOMBRE, DESCR = @DESCR, ARCHIVO = @ARCHIVO
            WHERE CVE_REP = @CVE_REP
            IF @@ROWCOUNT = 0
            INSERT INTO GCFORMATOS (CVE_REP, STATUS, NOMBRE, DESCR, ARCHIVO, FECHAELAB, UUID)
            VALUES(@CVE_REP, 'A', @NOMBRE, @DESCR, @ARCHIVO, GETDATE(), NEWID())"
        Try
            cmd.CommandText = SQL
            cmd.Parameters.Add("@CVE_REP", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_REP.Text)
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = tNombre.Text
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@ARCHIVO", SqlDbType.VarChar).Value = tFormato.Text
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

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Try

            Dim rutaCg As String = GET_RUTA_FORMATOS()

            OpenFileDialog1.Title = "Por favor seleccione un archivo"
            OpenFileDialog1.InitialDirectory = rutaCg
            OpenFileDialog1.Filter = "Reporte mrt|*.mrt"
            If tFormato.Text.Trim.Length = 0 Then
                OpenFileDialog1.FileName = ""
            Else
                OpenFileDialog1.FileName = tFormato.Text
            End If

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

                Dim copyToDir = Path.GetDirectoryName(OpenFileDialog1.FileName)
                Dim file = Path.GetFileName(OpenFileDialog1.FileName)

                BACKUPTXT("ruta", rutaCg & " = " & copyToDir)

                If rutaCg = copyToDir Then
                    '
                Else
                    Dim newPath = Path.Combine(copyToDir, file)
                    Try
                        BACKUPTXT("ruta", OpenFileDialog1.FileName & "," & rutaCg & "\" & file)
                        IO.File.Copy(OpenFileDialog1.FileName, rutaCg & "\" & file, True)
                    Catch ex As Exception
                    End Try
                End If

                tFormato.Text = file
                tFormato.Tag = Path.GetFileName(OpenFileDialog1.FileName)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub frmArchivosReportesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub
End Class
