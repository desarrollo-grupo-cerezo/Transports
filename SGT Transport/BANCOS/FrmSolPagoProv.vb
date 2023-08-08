Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports C1.Win.C1Command

Public Class FrmSolPagoProv
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmSolPagoProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
            Me.Close()
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Me.CenterToScreen()

            Me.WindowState = FormWindowState.Maximized
        Catch ex As Exception
        End Try
        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 13
            Fg.Rows(0).Height = 40
            Fg.Dock = DockStyle.Fill

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Integer)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Beneficiario"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Fecha pago"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(DateTime)

            Fg(0, 5) = "Forma de pago"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Importe"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Monto asignado"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Saldo"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Concepto"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Solicita"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Revisa/autoriza"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)

            Fg(0, 12) = "Transfiere"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim dt As DateTime = Now

            Fg.Rows.Count = 1

            SQL = "SELECT S.CLAVE, S.STATUS, S.FECHA_P, S.FORMAPAGO, C.DESCR, S.CVE_PROV, P.NOMBRE, S.IMPORTE, 
                S.CONCEPTO, S.SOLICITA, S.REV_AUT, S.TRANSFIERE, ISNULL(L.CAMPLIB6,0) AS LIB6,
                ISNULL((SELECT ISNULL(SUM(IMPORTE),0) AS MONTO FROM SOL_PAGO WHERE STATUS = 'A' AND FORMAPAGO = 23 AND CVE_PROV = L.CVE_PROV AND
                MONTH(S.FECHA_P) = " & dt.Month & " AND YEAR(S.FECHA_P) = " & dt.Year & "),0) AS MONTO_ABONADO
                FROM SOL_PAGO S
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = S.CVE_PROV
                LEFT JOIN PROV_CLIB" & Empresa & " L ON L.CVE_PROV = S.CVE_PROV
                LEFT JOIN CONP" & Empresa & " C ON C.NUM_CPTO = S.FORMAPAGO
                WHERE S.STATUS = 'A' ORDER BY S.CLAVE DESC"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("STATUS") & vbTab &
                           "(" & dr("CVE_PROV").ToString.Trim & ") " & dr("NOMBRE") & vbTab & dr("FECHA_P") & vbTab &
                           "(" & dr("FORMAPAGO") & ") " & dr("DESCR") & vbTab & dr("IMPORTE") & vbTab &
                           dr("LIB6") & vbTab & dr("LIB6") - dr("MONTO_ABONADO") & vbTab & dr("CONCEPTO") & vbTab & dr("SOLICITA") & vbTab &
                           dr("REV_AUT") & vbTab & dr("TRANSFIERE"))
                    End While
                End Using
            End Using
            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmSolPagoProv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Solicitud pago prov.")
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            FrmSolPagoProvAE.ShowDialog()

            'Var9 = TCLAVE.Value
            'Var10 = "IMPRIMIR"
            If Var10 = "IMPRIMIR" Then
                IMPRIMIR(CInt(Var9))
            End If

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then
                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 1)
                FrmSolPagoProvAE.ShowDialog()
                DESPLEGAR()
            Else
                MsgBox("Por favor seleccione un movimiento")
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As ClickEventArgs) Handles BarCancelar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE SOL_PAGO SET STATUS = 'B' WHERE CLAVE = " & Fg(Fg.Row, 1)
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
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Solicitud pago proveedores")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarRefrescar_Click(sender As Object, e As ClickEventArgs) Handles BarRefrescar.Click
        DESPLEGAR()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 13 Then
                    BarEdit_Click(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarEdit_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Sub IMPRIMIR(FCLAVE As Integer)
        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSolPagoProv.mrt"
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
            StiReport1.Item("CLAVE") = FCLAVE

            'StiReport1("F3") = TFECHA.Value.ToString.Substring(0, 10)

            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class