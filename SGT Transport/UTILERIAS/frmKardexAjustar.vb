Imports System.Data.SqlClient
Public Class frmKardexAjustar
    Private Sub frmKardexAjustar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
    End Sub

    Private Sub frmKardexAjustar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnAjustarKardex_Click(sender As Object, e As EventArgs) Handles BtnAjustarKardex.Click
        Try
            Dim CVE_ART As String, CADENA As String = ""

            If tCVE_ART.Text.Trim.Length > 0 Then
                CVE_ART = BUSCA_CAT("Inven", tCVE_ART.Text)
                If CVE_ART = "N" Or CVE_ART = "" Then
                    MessageBox.Show("Articulo inexistente")
                    Return
                End If
                CADENA = " WHERE MINVE" & Empresa & ".CVE_ART = '" & tCVE_ART.Text & "'"
            Else
                CADENA = ""
            End If
            If tCVE_ART.Text.Trim.Length > 0 Then
                If MsgBox("Realmente desea ajustar kardex del articulo " & tCVE_ART.Text & "?", vbYesNo) = vbNo Then
                    Return
                End If
            Else
                If MsgBox("Realmente desea ajustar kardex de todos los producto del catalogo?", vbYesNo) = vbNo Then
                    Return
                End If
            End If
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "UPDATE MINVE" & Empresa & " SET EXISTENCIA = (SELECT SUM(I2.CANT * SIGNO) FROM MINVE" & Empresa & " I2 WHERE
                   I2.NUM_MOV <= MINVE" & Empresa & ".NUM_MOV AND I2.CVE_ART = MINVE" & Empresa & ".CVE_ART AND I2.ALMACEN = MINVE" & Empresa & ".ALMACEN)" & CADENA
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
            MessageBox.Show("Proceso terminado regsitros afectados " & returnValue)
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btAjustarExistViaKardex_Click(sender As Object, e As EventArgs) Handles btAjustarExistViaKardex.Click
        Dim CVE_ART As String, CADENA As String = "", CADENA2 As String = "", CADENA3 As String = ""

        Try
            If tCVE_ART.Text.Trim.Length > 0 Then
                CVE_ART = BUSCA_CAT("Inven", tCVE_ART.Text)
                If CVE_ART = "N" Or CVE_ART = "" Then
                    MessageBox.Show("Articulo inexistente")
                    Return
                End If
                CADENA = " AND MULT" & Empresa & ".CVE_ART = '" & tCVE_ART.Text & "'"
                CADENA2 = " WHERE INVE" & Empresa & ".CVE_ART = '" & tCVE_ART.Text & "'"
                CADENA3 = " WHERE MULT" & Empresa & ".CVE_ART = '" & tCVE_ART.Text & "'"
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If tCVE_ART.Text.Trim.Length > 0 Then
            If MsgBox("Realmente desea ajustar existenias via kardex del articulo " & tCVE_ART.Text & "?", vbYesNo) = vbNo Then
                Return
            End If
        Else
            If MsgBox("Realmente desea ajustar existenias via kardex de todos los producto del catalogo?", vbYesNo) = vbNo Then
                Return
            End If
        End If
        Try
            If MULTIALMACEN > 0 Then
                SQL = "UPDATE MULT" & Empresa & " SET EXIST = 0 WHERE NOT EXISTS (SELECT CVE_ART FROM MINVE" & Empresa &
                     " WHERE MINVE" & Empresa & ".CVE_ART = MULT" & Empresa & ".CVE_ART AND MINVE" & Empresa & ".ALMACEN = MULT" & Empresa & ".CVE_ALM) " & CADENA
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
                SQL = "UPDATE MULT" & Empresa & " SET MULT" & Empresa & ".EXIST = ISNULL((SELECT SUM(CANT * SIGNO) FROM MINVE" & Empresa &
                    " WHERE MINVE" & Empresa & ".CVE_ART = MULT" & Empresa & ".CVE_ART AND MINVE" & Empresa & ".ALMACEN = MULT" & Empresa & ".CVE_ALM),0) " &
                    "FROM MULT" & Empresa & CADENA3
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "UPDATE INVE" & Empresa & " SET INVE" & Empresa & ".EXIST = ISNULL((SELECT SUM(CANT*SIGNO) FROM MINVE" & Empresa &
              " WHERE MINVE" & Empresa & ".CVE_ART = INVE" & Empresa & ".CVE_ART),0) FROM INVE" & Empresa & CADENA2
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        MessageBox.Show("Proceso terminado regsitros afectados " & returnValue)
    End Sub
    Private Sub BtnArt_Click(sender As Object, e As EventArgs) Handles BtnArt.Click
        Try
            Var2 = "Articulo"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_ART.Text = Var4
                L1.Text = Var5
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnKardex_Click(sender As Object, e As EventArgs) Handles btnKardex.Click
        Try
            If tCVE_ART.Text.Trim.Length > 0 Then
                Var4 = tCVE_ART.Text
                Var5 = L1.Text
                frmKardex.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
