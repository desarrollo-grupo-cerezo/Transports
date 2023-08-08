Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Stimulsoft.Report.StiOptions.Export

Public Class FrmParamSeries
    Private TIPODOCTO As String
    Private Sub FrmParamDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Me.CenterToScreen()

            TIPODOCTO = Var11

            Fg.Dock = DockStyle.Fill
            Fg.Styles("Normal").Border.Color = Color.DarkGray
            Fg.Styles.Fixed.WordWrap = True
            Fg.Rows(0).Height = 50
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            Fg.Cols(1).Visible = False
            Fg.Cols(2).Visible = False
            Fg.Cols(3).Width = 60
            Fg.Cols(4).Width = 35
            Fg.Cols(5).Width = 40
            Fg.Cols(6).Width = 90
            Fg.Cols(7).Width = 60
            Fg.Cols(8).Width = 220
            Fg.Cols(9).Width = 220
            Fg.Cols(10).Width = 60

            Dim SerPorDoc As String = ""
            Select Case Var11
                Case "F"
                    SerPorDoc = "Facturas"
                Case "V"
                    SerPorDoc = "Notas de venta"
                Case "R"
                    SerPorDoc = "Remisiones"
                Case "P"
                    SerPorDoc = "Pedidos"
                Case "C"
                    SerPorDoc = "Cotizaciones"
                Case "D"
                    SerPorDoc = "Devoluciones"
                Case "E"
                    SerPorDoc = "Notas de crédito"
                Case "G"
                    SerPorDoc = "Complemento de pago"
                Case "T"
                    SerPorDoc = "Carta porte traslado"
            End Select

            Me.Text = "Series " & SerPorDoc


            DESPLEGAR()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            'INDEX 
            'NUM_EMP, TIPODOCTO, SERIE

            SQL = "SELECT NUM_EMP, TIPODOCTO, SERIE, ISNULL(TIPO,'I') AS TIP, ISNULL(MASCARA,1) AS MASCA, ISNULL(FTOEMISION,'') AS FTOEMI, 
                ISNULL(FOLIOINICIAL,0) AS FOLINI, ISNULL(LONGITUD,0) AS LONGI, ISNULL(STATUS,'') AS ST, ISNULL(FTOEMISIONCFDI40,'') AS FTO40
                FROM PARAM_FOLIOSF" & Empresa & " WHERE TIPODOCTO = '" & TIPODOCTO & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader


            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("NUM_EMP") & vbTab & dr("TIPODOCTO") & vbTab & dr("SERIE") & vbTab & dr("TIP") & vbTab &
                            dr("FOLINI") & vbTab & IIf(dr("MASCA") = 1, "Derecha y ceros", "Izquierda") & vbTab & dr("LONGI") & vbTab &
                            dr("FTOEMI") & vbTab & dr("FTO40") & vbTab & IIf(dr("ST") = "B", "Bloqueado", "Disponible"))
            Loop
            dr.Close()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmParamDocumentos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Series")
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click
        Try

            Var1 = "Nuevo"
            Var12 = TIPODOCTO

            Using myDialog As New FrmParamSeriesAE
                If (myDialog.ShowDialog() = DialogResult.OK) Then
                End If
            End Using

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Try
                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 2)
                Var3 = Fg(Fg.Row, 3)

                Var12 = TIPODOCTO

                Using myDialog As New FrmParamSeriesAE
                    If (myDialog.ShowDialog() = DialogResult.OK) Then
                    End If
                End Using
                'FrmParamSeriesAE.ShowDialog()
                DESPLEGAR()

            Catch ex As Exception
                MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As ClickEventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                'INDEX 
                'NUM_EMP, TIPODOCTO, SERIE

                SQL = "UPDATE PARAM_FOLIOSF" & Empresa & " SET STATUS = 'B' WHERE 
                    NUM_EMP = " & Convert.ToInt16(Fg(Fg.Row, 1)) & "' AND TIPODOCTO = '" & Fg(Fg.Row, 2) & "' AND SERIE = '" & Fg(Fg.Row, 3) & "'"

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
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "SERIES VENTAS")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
End Class