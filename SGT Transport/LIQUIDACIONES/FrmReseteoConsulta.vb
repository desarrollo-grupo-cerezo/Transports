Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmReseteoConsulta
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not Valida_Conexion() Then
                Return
            End If

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

            Me.CenterToScreen()

            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True
            Fg.Rows.Count = 1
            TBox.Text = ""
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            If Var2.Trim.Length > 0 Then
                SQL = "SELECT R.CVE_RES, R.ESTADO, R.CVE_OPER, NOMBRE, R.FECHA, CLAVEMONTE
                    FROM GCRESETEO R
                    LEFT JOIN GCOPERADOR O ON CLAVE = R.CVE_OPER
                    LEFT JOIN GCUNIDADES U ON U.CLAVE  = R.CVE_UNI
                    WHERE R.CVE_OPER = " & CInt(Var2) & " ORDER BY R.FECHAELAB DESC"
            Else
                SQL = "SELECT R.CVE_RES, R.ESTADO, R.CVE_OPER, NOMBRE, R.FECHA, CLAVEMONTE
                    FROM GCRESETEO R
                    LEFT JOIN GCOPERADOR O ON CLAVE = R.CVE_OPER
                    LEFT JOIN GCUNIDADES U ON U.CLAVE  = R.CVE_UNI
                    ORDER BY R.FECHAELAB DESC"
            End If

            Fg.Cols.Count = 7
            Fg(0, 1) = "Clave"
            Fg(0, 2) = "Estado"
            Fg(0, 3) = "Clave oper."
            Fg(0, 4) = "Nombre"
            Fg(0, 5) = "Fecha"
            Fg(0, 6) = "Unidad"
            Me.Width = 650
            FG.Width = ME.Width -25
            Fg.Cols(0).Width = 30
            Fg.Cols(1).Width = 55
            Fg.Cols(2).Width = 100
            Fg.Cols(3).Width = 60
            Fg.Cols(4).Width = 220
            Fg.Cols(5).Width = 70
            Fg.Cols(6).Width = 60

            DESPLEGAR()


        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Redraw = False
            Fg.Rows.Count = 1

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab &
                                   dr(3) & vbTab & dr(4) & vbTab & dr(5))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub FrmReseteoConsulta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmReseteoConsulta_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class