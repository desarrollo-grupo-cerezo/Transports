Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmRangosDesgasteAE
    Private Sub FrmRangosDesgasteAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        Me.KeyPreview = True
        TDE.Value = 0
        THASTA.Value = 0
        TCOLOR.Value = ""
        If Var1 = "Nuevo" Then
            Try
                TCVE_DES.Value = GET_MAX("GCLLANTAS_RANGOS_DESGASTE", "CVE_DES")
                TCVE_DES.Enabled = False
                TDE.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT L.CVE_DES, L.STATUS, L.DE, L.HASTA, L.COLOR
                    FROM GCLLANTAS_RANGOS_DESGASTE L 
                    WHERE CVE_DES = " & Convert.ToInt32(Var2)
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCVE_DES.Value = dr("CVE_DES")
                    TDE.Value = dr("DE").ToString
                    THASTA.Value = dr("HASTA").ToString
                    TCOLOR.Value = dr("COLOR").ToString
                Else
                    TCVE_DES.Value = 0
                    TDE.Value = 0
                    THASTA.Value = 0
                    TCOLOR.Value = ""
                End If
                dr.Close()

                TCVE_DES.Enabled = False
                TDE.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FrmRangosDesgasteAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        Try

            TDE.UpdateValueWithCurrentText()
            THASTA.UpdateValueWithCurrentText()
            TCOLOR.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        SQL = "IF EXISTS (SELECT CVE_DES FROM GCLLANTAS_RANGOS_DESGASTE WHERE CVE_DES = @CVE_DES)
            UPDATE GCLLANTAS_RANGOS_DESGASTE SET DE = @DE, HASTA = @HASTA, COLOR = @COLOR
            WHERE CVE_DES = @CVE_DES
       ELSE
            INSERT INTO GCLLANTAS_RANGOS_DESGASTE (CVE_DES, STATUS, DE, HASTA, COLOR, UUID)
            VALUES(@CVE_DES, 'A', @DE, @HASTA, @COLOR, NEWID())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_DES", SqlDbType.Int).Value = TCVE_DES.Value
                cmd.Parameters.Add("@DE", SqlDbType.Float).Value = TDE.Value
                cmd.Parameters.Add("@HASTA", SqlDbType.Float).Value = THASTA.Value
                cmd.Parameters.Add("@COLOR", SqlDbType.VarChar).Value = TCOLOR.Value
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se grabo correctamente")
                        Me.Close()
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace) 
         End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class