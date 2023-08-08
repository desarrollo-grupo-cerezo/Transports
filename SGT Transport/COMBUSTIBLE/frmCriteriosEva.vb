Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class frmCriteriosEva
    Private Sub frmCriteriosEva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg.Rows.Count = 1
            Fg.Cols.Count = 6

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Evento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)
            cc1.TextAlign = TextAlignEnum.CenterCenter

            Fg(0, 2) = "Tabulador"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)
            c2.TextAlign = TextAlignEnum.CenterCenter

            Fg(0, 3) = "Físico vs Ecm"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)
            c3.TextAlign = TextAlignEnum.CenterCenter

            Fg(0, 4) = "Ralenti"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)
            c4.TextAlign = TextAlignEnum.CenterCenter

            Fg(0, 5) = "Criterio"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT CVE_EVE, TABULADOR, FISICO_VS_ECM, RALENTI, CRITERIO 
                    FROM GCCRITERIOS_EVA WHERE STATUS = 'A' ORDER BY CVE_EVE"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_EVE") & vbTab & IIf(dr("TABULADOR") = 1, "Si", "No") & vbTab & IIf(dr("FISICO_VS_ECM") = 1, "Si", "No") & vbTab &
                           IIf(dr("RALENTI") = 1, "Si", "No") & vbTab & dr("CRITERIO"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmCriteriosEva_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Criterios evaluación")
        Me.Dispose()
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then
                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 1)
                If IsNumeric(Var2) Then
                    frmCriterioEvaAE.ShowDialog()
                    DESPLEGAR()
                Else
                    MsgBox("Evento incorrecto")
                End If
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As ClickEventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCCRITERIOS_EVA SET STATUS = 'B' WHERE CVE_EVE = " & Fg(Fg.Row, 1)
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se elimino satisfactoriamente")
                        DESPLEGAR()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click
        Try
            If Fg.Row > 0 Then
                Var1 = "Nuevo"
                frmCriterioEvaAE.ShowDialog()
                DESPLEGAR()
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
