Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmAsigCatCobro
    Private Sub FrmAsigCatCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Me.WindowState = FormWindowState.Maximized

        TITULOS()
        Fg.Dock = DockStyle.Fill
        DESPLEGAR()

    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT A.CVE_COBRO, A.STATUS, A.DESCR, A.CUENTA, A.CENTRO_BENEF, A.DESCR_UME_FAC, A.CVE_PRODSERV, A.CVE_UNIDAD, A.OBS, 
                CASE WHEN A.CAUSA_IVA = 1 THEN 'Si' ELSE 'No' END AS CIVA, 
                CASE WHEN A.CAUSA_RET = 1 THEN 'Si' ELSE 'No' END AS CRET
                FROM GCASIGCONCEP_COBRO A 
                ORDER BY A.CVE_COBRO"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_COBRO") & vbTab & dr("STATUS") & vbTab & dr("DESCR") & vbTab & dr("CIVA") & vbTab &
                           dr("CRET") & vbTab & dr("CUENTA") & vbTab & dr("CENTRO_BENEF") & vbTab & dr("DESCR_UME_FAC") & vbTab &
                           dr("CVE_PRODSERV") & vbTab & dr("CVE_UNIDAD") & vbTab & dr("OBS"))
            Loop
            dr.Close()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmAsigCatCobro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Conceptos de cobro")
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"

            FrmAsigCatCobroAE.ShowDialog()

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            FrmAsigCatCobroAE.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As ClickEventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCASIGCONCEP_COBRO SET STATUS = 'B' WHERE CVE_COBRO = " & Convert.ToInt16(Fg(Fg.Row, 1))
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
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Conceptos de cobro de viaje")
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Sub TITULOS()
        Try

            Fg.Rows.Count = 1
            Fg.Cols.Count = 12

            Fg.Rows(0).Height = 40

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int16)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripción"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Causa IVA"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Retiene IVA"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Cuenta"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Centro de beneficios"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Descripción UMA facturación"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Clave producto servicio CFDI"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Clave unidad CFDI"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Observaciones"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)


            For k = 1 To Fg.Cols.Count - 1
                Fg.Cols(k).StarWidth = "*"
            Next
            Fg.Cols(3).StarWidth = "2*"
            Fg.Cols(11).StarWidth = "3*"

            Fg.Cols(1).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(2).TextAlign = TextAlignEnum.CenterCenter

            Fg.Cols(4).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(5).TextAlign = TextAlignEnum.CenterCenter

            Fg.Cols(9).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(10).TextAlign = TextAlignEnum.CenterCenter


            Fg.Styles.Fixed.WordWrap = True

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
End Class