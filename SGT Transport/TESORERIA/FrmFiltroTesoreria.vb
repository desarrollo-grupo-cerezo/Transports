Public Class FrmFiltroTesoreria
    Private Sub FrmFiltroTesoreria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.CenterToScreen()

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmFiltroTesoreria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click

        Try
            If ChDepositado.Checked Then
                Var5 = " AND FECHA_AUT IS NOT NULL AND FECHA_DEP IS NOT NULL AND 
                    P.FECHA >= '" & FSQL(F1.Value) & "' AND P.FECHA <= '" & FSQL(F2.Value) & "' " &
                    IIf(chIncluirCanc.Checked, "", "AND P.STATUS <> 'C'")
            ElseIf ChAutorizado.Checked Then
                Var5 = " AND FECHA_AUT IS NOT NULL AND FECHA_DEP IS NULL AND
                    P.FECHA >= '" & FSQL(F1.Value) & "' AND P.FECHA <= '" & FSQL(F2.Value) & "' " &
                    IIf(chIncluirCanc.Checked, "", "AND P.STATUS <> 'C'")
            Else
                Var5 = " AND FECHA_AUT IS NULL AND FECHA_DEP IS NULL AND
                    P.FECHA >= '" & FSQL(F1.Value) & "' AND P.FECHA <= '" & FSQL(F2.Value) & "' " &
                    IIf(chIncluirCanc.Checked, "", "AND P.STATUS <> 'C'")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Var4 = "CANCEL"
        Me.Close()
    End Sub
End Class
