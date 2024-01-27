Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmPagoMultSaldosItem
    Private Proceso As String
    Private PARAM_VAR As String = ""
    Private TipoUnidad As Integer
    Private Sub FrmPagoMultSaldosItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Application.EnableVisualStyles()

        Fg.Cols.Count = 16

        Fg.Dock = DockStyle.Fill

        Fg(0, 0) = ""
        Fg(0, 1) = "Seleccione"
        Fg(0, 2) = "Documento"
        Fg(0, 3) = "Clave"
        Fg(0, 4) = "Nombre"
        Fg(0, 5) = "Fecha"
        Fg(0, 6) = "Fecha venc."
        Fg(0, 7) = "No. Factura"
        Fg(0, 8) = "Docto"
        Fg(0, 9) = "Abonos"
        Fg(0, 10) = "Importe"
        Fg(0, 11) = "Saldo"
        Fg(0, 12) = "NumCargo"
        Fg(0, 13) = "Num_Moneda"
        Fg(0, 14) = "Moneda"
        Fg(0, 15) = "TC"


        Fg.Cols(1).StarWidth = "*"
        Fg.Cols(2).StarWidth = "2*"
        Fg.Cols(3).StarWidth = "*"
        Fg.Cols(4).StarWidth = "3*"
        Fg.Cols(5).StarWidth = "*"
        Fg.Cols(6).StarWidth = "*"
        Fg.Cols(7).StarWidth = "*"
        Fg.Cols(8).StarWidth = "*"
        Fg.Cols(9).StarWidth = "*"
        Fg.Cols(10).StarWidth = "*"
        Fg.Cols(11).StarWidth = "*"
        Fg.Cols(13).StarWidth = "*"
        Fg.Cols(14).StarWidth = "*"
        Fg.Cols(15).StarWidth = "*"

        Fg.Cols(12).Visible = False

        Fg.Cols(13).Visible = False
        Fg.Cols(15).Visible = False

        Fg.Cols(1).MinWidth = 50
        Fg.Cols(1).DataType = GetType(Boolean)

        Fg.Cols(9).Format = "###,###,##0.00"
        Fg.Cols(10).Format = "###,###,##0.00"
        Fg.Cols(11).Format = "###,###,##0.00"
        Me.Width = 1200
        Fg.Width = Me.Width - 30

        Me.CenterToScreen()

        DESPLEGAR()
    End Sub

    Sub DESPLEGAR()
        Try
            Fg.Redraw = False
            Fg.Rows.Count = 1

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True

            '                1           2         3            4            5             6          7
            SQL = "SELECT M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA, M.DOCTO, "
            SQL &= "ISNULL((SELECT SUM(IMPMON_EXT * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND 
                M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) + 
                (SELECT COALESCE(SUM(C3.IMPMON_EXT * SIGNO),0) AS ABONOS FROM CUEN_DET" & Empresa & " C3 
                WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1) AS SUMA_CUENDET, M.IMPMON_EXT AS IMPORTE, "
            '                                                                            8             9
            '                  10
            SQL &= "M.IMPMON_EXT + 
                ISNULL((SELECT SUM(IMPMON_EXT*SIGNO) FROM CUEN_DET" & Empresa & " C4 WHERE REFER = M.REFER AND CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO AND NUM_CARGO = M.NUM_CARGO),0) AS SALDO,"
            '              11          12
            SQL &= "M.NUM_CARGO, M.NUM_CPTO, M.NUM_MONED, D.CVE_MONED, M.TCAMBIO  "
            SQL &= "FROM CUEN_M" & Empresa & " M
                INNER JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE
                INNER JOIN MONED" & Empresa & " D ON D.NUM_MONED = M.NUM_MONED
                WHERE M.NUM_CPTO <> 9 AND
            (M.IMPMON_EXT + ISNULL((SELECT SUM(IMPMON_EXT * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE CVE_CLIE = M.CVE_CLIE AND REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND M.NUM_CARGO = D.NUM_CARGO),0)) > 0.1 " &
            IIf(Var4.Trim.Length = 0, "", " AND M.CVE_CLIE = '" & Var4 & "'") & " ORDER BY M.CVE_CLIE, M.REFER "

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                   dr(5) & vbTab & dr(6) & vbTab & dr(7) & vbTab & dr(8) & vbTab & dr(9) & vbTab & dr(10) & vbTab & dr(12) & vbTab & dr(13) & vbTab & dr(14))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub

    Private Sub FrmPagoMultSaldosItem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click
        Dim z As Integer = 0
        Try
            If Fg.Row > 0 Then
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1) Then
                        z += 1
                    End If
                Next
                ReDim aTPV(z, 7)

                z = 0
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1) Then
                        aTPV(z, 0) = Fg(k, 2) 'REFER
                        aTPV(z, 1) = Fg(k, 12) 'NUM_CARGO
                        aTPV(z, 2) = Fg(k, 11) 'SALDO
                        aTPV(z, 3) = 0 'SALDO
                        aTPV(z, 4) = Fg(k, 11) 'SALDO

                        aTPV(z, 5) = Fg(k, 13) 'NUM_MONEDA
                        aTPV(z, 6) = Fg(k, 14) 'CVE_MONEDA
                        aTPV(z, 7) = Fg(k, 15) 'TC
                        z += 1
                    End If
                Next
            End If
            Me.Close()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub

    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            SQL = "REFER LIKE '%" & tBox.Text & "%' OR CVE_CLIE LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR 
                NO_FACTURA LIKE '%" & tBox.Text & "%' OR DOCTO LIKE '%" & tBox.Text & "%'"
            DESPLEGAR()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tBox_KeyDown(sender As Object, e As KeyEventArgs) Handles tBox.KeyDown
        Try
            If e.KeyCode = Keys.Down Then
                Fg.Focus()
                Return
            End If
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                TBox_TextChanged(Nothing, Nothing)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs)
        Try
            BarAceptar_Click(Nothing, Nothing)
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Left Then
            tBox.Focus()
        End If
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Return) Then
            Try
                BarAceptar_Click(Nothing, Nothing)
            Catch ex As Exception
                Bitacora(ex.Message & vbNewLine & ex.StackTrace & "Proceso: " & Proceso)
                'MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace & "Proceso: " & Proceso)
            End Try
        End If
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If e.Row > 0 Then
                If e.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
