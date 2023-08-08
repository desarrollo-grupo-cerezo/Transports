Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmSelViajes
    Private Sub FrmSelViajes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            Me.Width = 1100
            Fg.Width = Me.Width - 20
            Fg.Rows.Count = 1

            Fg.Cols(1).StarWidth = "*"
            Fg.Cols(2).StarWidth = "*"
            Fg.Cols(3).StarWidth = "*"
            Fg.Cols(4).StarWidth = "*"
            Fg.Cols(5).StarWidth = "*"
            Fg.Cols(6).StarWidth = "*"
            Fg.Cols(7).StarWidth = "2*"
            Fg.Cols(8).StarWidth = "2*"
            Fg.Cols(9).StarWidth = "2*"


            Me.CenterToScreen()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub FrmSelViajes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try
            Var2 = "CLIE"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                LtNombre.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                DESPLEGAR()
                Fg.Focus()
            End If
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Var5 = ""
                Dim DESCR As String
                DESCR = TCLIENTE.Text.Trim
                If IsNumeric(DESCR) Then
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCLIENTE.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR <> "" Then
                    LtNombre.Text = DESCR

                    DESPLEGAR()

                    Fg.Focus()
                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE.Text = ""
                    LtNombre.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("387. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("387. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR()

        Fg.Rows.Count = 1
        Fg.Redraw = False

        SQL = "SELECT TOP 5000 A.CVE_VIAJE, 
            A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
            CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
            O.NOMBRE, RE.DESCR AS ORIGEN, EE.DESCR AS DESTINO
            FROM GCASIGNACION_VIAJE A 
            LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
            LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
            LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = A.RECOGER_EN
            LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = A.ENTREGAR_EN
            WHERE ISNULL(A.FACTURADO,'') <> 'S' AND A.CLIENTE = '" & TCLIENTE.Text & "'
            ORDER BY A.FECHAELAB DESC"

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "" & vbTab & dr("CVE_VIAJE") & vbTab & dr("CVE_TRACTOR") & vbTab &
                                   dr("FECHA") & vbTab & dr("TIPOUNIDAD") & vbTab & dr("ESTATUSVIAJE") & vbTab &
                                   dr("NOMBRE") & vbTab & dr("ORIGEN") & vbTab & dr("DESTINO"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Fg.Redraw = True
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click
        Try
            Dim z As Integer = 0
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) = True Then
                    z += 1
                End If
            Next

            If z = 0 Then
                MsgBox("Por favor seleccione al menos un viaje")
                Return
            End If

            ReDim aDOCS(z - 1)
            z = 0
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) = True Then
                    aDOCS(z) = Fg(k, 2)
                    z += 1
                End If
            Next

            Var4 = "ok"
            Me.Close()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If Fg.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCLIENTE_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles TCLIENTE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnCliente_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class