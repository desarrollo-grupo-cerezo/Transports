Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Command

Public Class frmEstatusOperadores
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmEstatusOperadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Me.WindowState = FormWindowState.Maximized
        Fg.Rows.Count = 1
        Fg.Cols.Count = 11

        Fg.Rows(0).Height = 40
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - 100

        DESPLEGAR()
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            SQL = "SELECT P.CLAVE AS 'Clave', P.NOMBRE AS 'Nombre', P.CVE_ST_OPER AS 'Cve. st.', S.DESCR AS 'Estatus', P.CVE_TRACTOR AS 'Tractor', 
                P.CVE_TANQUE1 AS 'Tanque1', P.CVE_TANQUE2 AS 'Tanque2', O.DESCR AS 'Observaciones'
                FROM GCOPERADOR P
                LEFT JOIN GCSTATUS_OPER S ON S.CVE_ST_OPER = P.CVE_ST_OPER 
                LEFT JOIN GCOBS O ON O.CVE_OBS = P.CVE_OBS
                WHERE P.STATUS = 'A' 
                ORDER BY ISNULL(S.PRIORIDAD,9999)"

            Fg.Redraw = False
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource
            Fg.AutoSizeCols()

            Fg.Cols(3).Width = 0
            Fg.Redraw = True

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmEstatusOperadores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Estatus operadores")
        Me.Dispose()
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub

    Private Sub BarObservaciones_Click(sender As Object, e As ClickEventArgs) Handles BarObservaciones.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 8)
                TIPO_COMPRA = "o"
                frmObserDocumento.ShowDialog()
                Fg(Fg.Row, 8) = Var4
                If Var4.Trim.Length > 0 Then
                    SQL = "UPDATE GCUNIDADES SET OBS = '" & Var4 & "' WHERE CLAVEMONTE = '" & Fg(Fg.Row, 1) & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                DESPLEGAR()
                            End If
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Barsalir_Click(sender As Object, e As ClickEventArgs) Handles Barsalir.Click
        Me.Close()
    End Sub
    Private Sub BarStatus_Click(sender As Object, e As ClickEventArgs) Handles BarStatus.Click
        Try
            If Fg.Row > 0 Then
                If IsNumeric(Fg(Fg.Row, 1)) Then
                    Var44 = Fg(Fg.Row, 1)
                    If IsNumeric(Fg(Fg.Row, 3)) Then
                        Var45 = Fg(Fg.Row, 3)
                    Else
                        Var45 = 0
                    End If
                    frmAsignarStatusOper.ShowDialog()
                    DESPLEGAR()

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarAsignarUnidad_Click(sender As Object, e As ClickEventArgs) Handles BarAsignarUnidad.Click
        Try
            If Fg.Row > 0 Then
                If IsNumeric(Fg(Fg.Row, 1)) Then
                    Var44 = Fg(Fg.Row, 1)
                    frmEstatusOperCaptura.ShowDialog()
                    DESPLEGAR()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
