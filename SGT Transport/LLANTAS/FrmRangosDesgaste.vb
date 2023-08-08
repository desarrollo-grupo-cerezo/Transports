Imports C1.Win.C1FlexGrid
Imports System.IO
Imports C1.Win.C1Command
Imports System.Data.SqlClient

Public Class FrmRangosDesgaste
    Private Sub FrmRangosDesgaste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1
            Fg.Cols.Count = 5

            Fg.Rows(0).Height = 40
            Fg.Dock = DockStyle.Fill

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int32)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "De"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg.Cols(3).Format = "###,###,##0.00"

            Fg(0, 4) = "Hasta"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            'Fg(0, 5) = "Color"
            'Dim c5 As Column = Fg.Cols(5)
            'c5.DataType = GetType(String)

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

            SQL = "SELECT CVE_DES, STATUS, DE, HASTA, COLOR 
                FROM GCLLANTAS_RANGOS_DESGASTE WHERE STATUS = 'A' ORDER BY CVE_DES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_DES") & vbTab & dr("STATUS") & vbTab & dr("DE") & vbTab &
                            dr("HASTA")) ' & vbTab & dr("COLOR"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmRangosDesgaste_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Rangos desgaste")
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            FrmRangosDesgasteAE.ShowDialog()
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
            FrmRangosDesgasteAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As ClickEventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCLLANTAS_RANGOS_DESGASTE SET STATUS = 'B' WHERE CVE_DES = '" & Fg(Fg.Row, 1) & "'"
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
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Rangos de Desgaste")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarDisenador_Click(sender As Object, e As ClickEventArgs) Handles BarDisenador.Click
        PrinterMRT("ReportRangosDesgaste")
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim RUTA_FORMATOS As String
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportRangosDesgaste.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text

            'StiReport1.Item("F1") = F1.Value
            'StiReport1.Item("F2") = F2.Value
            'StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
            'StiReport1("F4") = F2.Value.ToString.Substring(0, 10)

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class