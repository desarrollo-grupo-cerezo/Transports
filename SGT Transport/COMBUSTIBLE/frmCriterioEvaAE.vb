Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class frmCriterioEvaAE
    Private NewRecord As Boolean = False
    Private Sub frmCriterioEvaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Var1 = "Nuevo" Then
            Try
                NewRecord = True
                tCVE_EVE.Text = GET_MAX("GCCRITERIOS_EVA", "CVE_EVE")
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT C.CVE_EVE, C.TABULADOR, C.FISICO_VS_ECM, C.RALENTI, C.PORC_TOLERANCIA, C.PORC_RALENTI, C.CRITERIO 
                    FROM GCCRITERIOS_EVA C WHERE STATUS = 'A' AND CVE_EVE = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_EVE.Text = dr("CVE_EVE").ToString
                    tTABULADOR.Text = IIf(dr("TABULADOR") = 1, "Si", "No")
                    tFISICO_VS_ECM.Text = IIf(dr("FISICO_VS_ECM") = 1, "Si", "No")
                    tRALENTI.Text = IIf(dr("RALENTI") = 1, "Si", "No")
                    tCRITERIO.Text = dr("CRITERIO").ToString
                Else
                    tTABULADOR.Text = ""
                    tFISICO_VS_ECM.Text = ""
                    tRALENTI.Text = ""
                    tCRITERIO.Text = ""
                End If
                dr.Close()
                tTABULADOR.Select()
                Me.Size = New System.Drawing.Size(608, 250)
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub BarGrabr_Click(sender As Object, e As ClickEventArgs) Handles BarGrabr.Click
        Try
            If NewRecord Then
                SQL = "INSERT INTO GCCRITERIOS_EVA (CVE_EVE, STATUS, TABULADOR, FISICO_VS_ECM, RALENTI, CRITERIO, UUID)  VALUES(
                    ISNULL((SELECT ISNULL(MAX(CVE_EVE),0) + 1 FROM GCCRITERIOS_EVA),1), 'A', @TABULADOR, @FISICO_VS_ECM, @RALENTI, @CRITERIO, NEWID())"
            Else
                SQL = "UPDATE GCCRITERIOS_EVA SET CRITERIO = @CRITERIO WHERE CVE_EVE = @CVE_EVE"
            End If
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.Parameters.Add("@CVE_EVE", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_EVE.Text)
                cmd.Parameters.Add("@TABULADOR", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tTABULADOR.Text)
                cmd.Parameters.Add("@FISICO_VS_ECM", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tFISICO_VS_ECM.Text)
                cmd.Parameters.Add("@RALENTI", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tRALENTI.Text)
                cmd.Parameters.Add("@CRITERIO", SqlDbType.VarChar).Value = tCRITERIO.Text
                cmd.CommandText = SQL
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
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmCriterioEvaAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub RAyuda_TextChanged(sender As Object, e As EventArgs) Handles RAyuda.TextChanged

    End Sub

    Private Sub BtnAyuda_Click(sender As Object, e As EventArgs) Handles BtnAyuda.Click
        If RAyuda.Visible Then
            RAyuda.Visible = False
            Me.Size = New System.Drawing.Size(610, 250)
        Else
            RAyuda.Visible = True
            '1171, 501
            Me.Size = New System.Drawing.Size(1171, 501)
        End If
    End Sub
End Class
