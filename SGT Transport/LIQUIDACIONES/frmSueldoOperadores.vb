Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmSueldoOperadores
    Private CADENA As String = ""

    Private Sub frmSueldoOperadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1
            Fg.Cols.Count = 13

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Catch ex As Exception
            End Try

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Ruta"
            Dim c2 As Column = Fg.Cols(1)
            c2.DataType = GetType(Int32)

            Fg(0, 3) = "Estatus"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)
            c3.TextAlign = TextAlignEnum.CenterCenter

            Fg(0, 4) = "Cliente"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Nombre"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Origen"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Destino"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Tipo viaje"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Tipo viaje"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Sueldo full"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Single)
            c10.Format = "###,###,###,##0.00"

            Fg(0, 11) = "Sueldo sencillo"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Single)
            c11.Format = "###,###,###,##0.00"

            Fg(0, 12) = "Observaciones"
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
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            Fg.Redraw = False
            Fg.Rows.Count = 1

            SQL = "SELECT TOP 5000 S.CVE_SUOP, S.CVE_TAB, S.STATUS, S.CLAVE_O, ISNULL(C.NOMBRE,'') AS ORIGEN, ISNULL(P1.CIUDAD,'') AS P1, ISNULL(P2.CIUDAD,'') AS P2, 
                CASE WHEN TIPO_FULL_SENCILLO = 0 THEN 'Full' ELSE 'Sencillo' END AS TIPO1, 
                CASE WHEN TIPO_CARGADO_VACIO = 0 THEN 'Cargado' ELSE 'Vacio' END AS TIPO2, S.SUELDO, ISNULL(SUELDO_SENC,0) AS SUE_S, ISNULL(OBSER,'') AS STR_OBS
                FROM GCSUELDO_OPER S 
                LEFT JOIN GCCLIE_OP C ON C.CLAVE = S.CLAVE_O
                LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = S.PLAZA_O
                LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = S.PLAZA_D
                WHERE S.STATUS = 'A' " & CADENA & " ORDER BY CVE_SUOP"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr.ReadNullAsEmptyInteger("CVE_SUOP") & vbTab & dr.ReadNullAsEmptyString("CVE_TAB") & vbTab &
                           dr.ReadNullAsEmptyString("STATUS") & vbTab &
                           dr.ReadNullAsEmptyString("CLAVE_O") & vbTab & dr.ReadNullAsEmptyString("ORIGEN") & vbTab &
                           dr.ReadNullAsEmptyString("P1") & vbTab & dr.ReadNullAsEmptyString("P2") & vbTab &
                           dr("TIPO1") & vbTab & dr("TIPO2") & vbTab & dr("SUELDO") & vbTab & dr("SUE_S") & vbTab & dr("STR_OBS"))
            Loop
            dr.Close()
            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            Fg.Subtotal(AggregateEnum.Clear)
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")

            Fg.AutoSizeCols()
            Lt.Text = "Registros encontrados " & Fg.Rows.Count - 1
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub frmSueldoOperadores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Sueldo operadores")
        Me.Dispose()
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmSueldoOperadoresAE.ShowDialog()

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var23 = Fg.Row

            Var2 = Fg(Fg.Row, 1)

            frmSueldoOperadoresAE.ShowDialog()
            DESPLEGAR()

            Fg.Row = Var23
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg.Row > 0 Then
                If IsNumeric(Fg(Fg.Row, 1)) Then
                    If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                        Var4 = ""
                        'FrmMotivoBaja.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            'Dim CVE_MTC As Long = 0
                            Try
                                'CVE_MTC = GRABA_MOTIVO_CANC("SUELDO OPERADORES", Var4)
                            Catch ex As Exception
                                Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                            'SQL = "UPDATE GCSUELDO_OPER SET STATUS = 'B', CVE_MTC = " & CVE_MTC & " WHERE CVE_SUOP = " & Fg(Fg.Row, 1)
                        Else
                            'Dim ResultMensaje As String
                            'ResultMensaje = MensajeBox("Cancelación abortada ¡¡¡¡¡", "Proceso finalizado", "Error")
                        End If

                        SQL = "UPDATE GCSUELDO_OPER SET STATUS = 'B' WHERE CVE_SUOP = " & Fg(Fg.Row, 1)

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
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "SUELDO OPERADORES")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click

        Try
            Fg.Focus()
        Catch ex As Exception
        End Try

        CADENA = ""

        DESPLEGAR()
    End Sub

    Private Sub tBox_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = 40 Then
                Fg.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
