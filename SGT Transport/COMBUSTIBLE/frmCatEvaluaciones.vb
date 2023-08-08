Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class frmCatEvaluaciones
    Private Sub frmCatEvaluaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try
            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 27

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int16)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripción evaluación"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Descripción motor"
            Dim cc3 As Column = Fg.Cols(4)
            cc3.DataType = GetType(String)

            Fg(0, 5) = "Factor carga"
            Dim c4 As Column = Fg.Cols(5)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 6) = "Calif. factor carga"
            Dim c5 As Column = Fg.Cols(6)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 7) = "Porc. uso ralenti"
            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Calif. ralenti"
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Velocidad maxima"
            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Calif. vel. max."
            Dim c9 As Column = Fg.Cols(10)
            c9.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Ponderación vel. max."
            Dim c10 As Column = Fg.Cols(11)
            c10.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Tipo de viaje"
            Dim c11 As Column = Fg.Cols(12)
            c11.DataType = GetType(String)

            Fg(0, 13) = "Calif. global 1"
            Dim c12 As Column = Fg.Cols(13)
            c12.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Bono 1"
            Dim c13 As Column = Fg.Cols(14)
            c13.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Calif. global 2"
            Dim c14 As Column = Fg.Cols(15)
            c14.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Bono 2"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "Calif. global 3"
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "Bono 3"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(Decimal)
            Fg.Cols(18).Format = "###,###,##0.00"

            Fg(0, 19) = "Calif. global 4"
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(Decimal)
            Fg.Cols(19).Format = "###,###,##0.00"

            Fg(0, 20) = "Bono 4"
            Dim c19 As Column = Fg.Cols(20)
            c19.DataType = GetType(Decimal)
            Fg.Cols(20).Format = "###,###,##0.00"

            Fg(0, 21) = "Calif. global 5"
            Dim c20 As Column = Fg.Cols(21)
            c20.DataType = GetType(Decimal)
            Fg.Cols(21).Format = "###,###,##0.00"

            Fg(0, 22) = "Bono 5"
            Dim c21 As Column = Fg.Cols(22)
            c21.DataType = GetType(Decimal)
            Fg.Cols(22).Format = "###,###,##0.00"

            Fg(0, 23) = "Calif. global 6"
            Dim c22 As Column = Fg.Cols(23)
            c22.DataType = GetType(Decimal)
            Fg.Cols(23).Format = "###,###,##0.00"

            Fg(0, 24) = "Bono 6"
            Dim c23 As Column = Fg.Cols(24)
            c23.DataType = GetType(Decimal)
            Fg.Cols(24).Format = "###,###,##0.00"

            Fg(0, 25) = "Calif. global 7"
            Dim c24 As Column = Fg.Cols(25)
            c24.DataType = GetType(Decimal)
            Fg.Cols(25).Format = "###,###,##0.00"

            Fg(0, 26) = "Bono 7"
            Dim c25 As Column = Fg.Cols(26)
            c25.DataType = GetType(Decimal)
            Fg.Cols(26).Format = "###,###,##0.00"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New sqlcommand
            Dim dr As sqldatareader
            cmd.connection = cnSAE

            SQL = "SELECT E.CVE_EVA, E.STATUS, ISNULL(E.DESCR,'') AS DES, M.DESCR, E.FACTOR_CARGA, E.CALIF_FACTOR_CARGA, 
                E.PORC_USO_RALENTI, E.CALIF_RALENTI, E.VEL_MAX, E.CALIF_VEL_MAX, E.PON_VEL_MAX, 
                CASE WHEN ISNULL(E.TIPO_VIAJE,-1) = 0 THEN 'Sencillo' 
                     WHEN ISNULL(E.TIPO_VIAJE,-1) = 1 THEN 'Full' 
                     WHEN ISNULL(E.TIPO_VIAJE,-1) = 2 THEN 'Full/Sencillo' ELSE '' END AS TVIAJE,
                E.CALIF_GLOBAL, E.CALIF_GLOBAL2, E.CALIF_GLOBAL3, E.CALIF_GLOBAL4, E.CALIF_GLOBAL5, E.CALIF_GLOBAL6, E.CALIF_GLOBAL7, 
                E.BONO, E.BONO2, E.BONO3, E.BONO4, E.BONO5, E.BONO6, E.BONO7 
                FROM GCCATEVA E
                LEFT JOIN GCMOTORES M ON M.CVE_MOT = E.CVE_MOT
                WHERE E.STATUS = 'A' ORDER BY E.CVE_EVA"
            cmd.commandtext = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_EVA") & vbTab & dr("STATUS") & vbTab &
                    IIf(dr("DES").ToString.Trim.Length = 0, dr("DESCR"), dr("DES")) & vbTab & dr("DESCR") & vbTab &
                    dr("FACTOR_CARGA") & vbTab & dr("CALIF_FACTOR_CARGA") & vbTab & dr("PORC_USO_RALENTI") & vbTab &
                    dr("CALIF_RALENTI") & vbTab & dr("VEL_MAX") & vbTab & dr.ReadNullAsEmptyDecimal("CALIF_VEL_MAX") & vbTab &
                    dr("PON_VEL_MAX") & vbTab & dr("TVIAJE") & vbTab &
                    dr("CALIF_GLOBAL") & vbTab & dr("CALIF_GLOBAL2") & vbTab & dr("CALIF_GLOBAL3") & vbTab &
                    dr("CALIF_GLOBAL4") & vbTab & dr("CALIF_GLOBAL5") & vbTab & dr("CALIF_GLOBAL6") & vbTab &
                    dr("CALIF_GLOBAL7") & vbTab & dr("BONO") & vbTab & dr("BONO2") & vbTab & dr("BONO3") & vbTab &
                    dr("BONO4") & vbTab & dr("BONO5") & vbTab & dr("BONO6") & vbTab & dr("BONO7"))
            Loop
            dr.close
            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmCatEvaluaciones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Cat. evaluaciones")
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            frmCatEvaluacionesAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"

            Var2 = Fg(Fg.Row, 1)
            frmCatEvaluacionesAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                If IsNumeric(Fg(Fg.Row, 1)) Then
                    SQL = "UPDATE GCCATEVA SET STATUS = 'B' WHERE CVE_EVA = " & Fg(Fg.Row, 1)
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
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "CATALOGO EVALUACIONES")
    End Sub
End Class
