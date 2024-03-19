Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports GMap.NET

Public Class FrmAntSalProv
    Private Sub FrmAntSalProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            SplitM1.Dock = DockStyle.Fill
            Fg.BringToFront()
            Fg.Dock = DockStyle.Fill

            BarraMenu.BackColor = Color.FromArgb(164, 177, 202)

            Fg.Cols(5).Width = 0

            Fg.Cols(1).StarWidth = "*"
            Fg.Cols(2).StarWidth = "3*"
            Fg.Cols(3).StarWidth = "*"
            Fg.Cols(4).StarWidth = "*"
            Fg.Cols(5).StarWidth = "*"
            Fg.Cols(6).StarWidth = "*"
            Fg.Cols(7).StarWidth = "*"
            Fg.Cols(8).StarWidth = "*"
            Fg.Cols(9).StarWidth = "*"

            Fg.Tree.Column = 1
            Fg.Tree.Show(1)
            Fg.Tree.Style = TreeStyleFlags.Complete ' .SimpleLeaf
            Fg.Tree.LineColor = Color.DarkBlue

            Fg.Cols(1).AllowEditing = True
            Fg.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            Fg.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
            Fg.Styles.Normal.WordWrap = False

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As EventArgs) Handles BarDesplegar.Click

        Fg.Rows.Count = 1
        Cursor.Current = Cursors.Default
        Fg.Redraw = False
        Fg.BeginUpdate()
        Try
            Dim PROV As String = "", IMPORTE As Decimal = -99999999, ABONOS As Decimal = 0, CADENA As String = ""
            Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, S4 As Decimal = 0, S5 As Decimal = 0, SALDO As Decimal = 0
            Dim CARGOS As Decimal = 0, NDIAS As Integer, Level As Integer = 0, i As Integer, n As Integer = 0
            Dim RUTA_FORMATOS As String = "", j As Integer = 0, CADENA2 As String
            Dim SALDO0 As Decimal, SALDO30 As Decimal, SALDO60 As Decimal, SALDO90 As Decimal, SALDO91 As Decimal, FECHA_VENC As Date

            Cursor.Current = Cursors.WaitCursor

            If TClasific.Text.Trim.Length = 0 Then
                CADENA2 = ""
            Else
                CADENA2 = " AND CLASIFIC = " & TClasific.Text
            End If

            CADENA = " AND (M.IMPORTE * M.SIGNO) + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " 
                    WHERE CVE_PROV = M.CVE_PROV AND ID_MOV = M.NUM_CPTO AND REFER = M.REFER),0) > 0.9 "

            SQL = "SELECT M.CVE_PROV, MAX(T.NOMBRE) AS NOM_PROV, MAX(T.CLASIFIC) AS CLAS, SUM(M.IMPORTE * M.SIGNO) As IMPORTE_M, 
                MAX(T.DIASCRED) AS DCRED, MAX(FECHA_VENC) AS F_VENC
                FROM PAGA_M" & Empresa & " M
                LEFT JOIN PROV" & Empresa & " T ON T.CLAVE = M.CVE_PROV
                WHERE M.FECHA_APLI <= '" & FSQL(F1.Value) & "' " & CADENA2 & CADENA & "
                GROUP BY M.CVE_PROV
                ORDER BY M.CVE_PROV"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        IMPORTE = dr("IMPORTE_M")
                        FECHA_VENC = dr("F_VENC")
                        NDIAS += DateDiff(DateInterval.Day, FECHA_VENC, Now)

                        If dr("CVE_PROV") = "       170" Then
                            Debug.Print("")
                        End If
                        Try
                            SALDO = 0
                            Using cmd5 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT ISNULL(SUM(IMPORTE * SIGNO),0) AS IMPORT 
                                    FROM PAGA_DET" & Empresa & " M
                                    WHERE CVE_PROV = '" & dr("CVE_PROV") & "' AND M.FECHA_APLI <= '" & FSQL(F1.Value) & "' " & CADENA2 & CADENA
                                cmd5.CommandText = SQL
                                Using dr5 As SqlDataReader = cmd5.ExecuteReader
                                    If dr5.Read Then
                                        SALDO = IMPORTE + dr5("IMPORT")
                                        ABONOS += dr5("IMPORT")
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try

                        If SALDO < 0 Then
                            Debug.Print("")
                        End If

                        SALDO0 = 0 : SALDO30 = 0 : SALDO60 = 0 : SALDO90 = 0 : SALDO91 = 0
                        Select Case NDIAS
                            Case < 1
                                SALDO0 = SALDO
                            Case 1 To 30
                                SALDO30 = SALDO
                            Case 31 To 60
                                SALDO60 = SALDO
                            Case 61 To 90
                                SALDO90 = SALDO
                            Case > 90
                                SALDO91 = SALDO
                        End Select
                        Fg.AddItem("" & vbTab & dr("CVE_PROV") & vbTab & dr("NOM_PROV") & vbTab & dr("CLAS") & vbTab &
                                   dr("DCRED") & vbTab & SALDO0 & vbTab & SALDO30 & vbTab & SALDO60 & vbTab & SALDO90 & vbTab & SALDO91 & vbTab & IMPORTE)

                    End While
                End Using
            End Using

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Cursor.Current = Cursors.Default
        Fg.Redraw = True
        Fg.EndUpdate()

    End Sub
    Private Sub FrmAntSalProv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Antigüedad saldos proveedores")
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "ANTIGUEDAD DE SALDOS")
    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If e.KeyCode = Keys.C Then
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class