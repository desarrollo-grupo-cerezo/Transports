Imports System.Data.SqlClient
Imports C1.Win.C1Command
Public Class frmBitacora
    Private CADENA As String
    Private BindingSource2 As BindingSource = New BindingSource
    Private Sub frmBitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Fg.Rows.Count = 2
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height-50
            Panel1.Width = Fg.Width
            C1FlexGridSearchPanel1.Left = Fg.Width - C1FlexGridSearchPanel1.Width - 50

            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-15)
            CADENA = " WHERE FECHAHORA BETWEEN '" & FSQL(dt) & " 00:00:00' AND '" & FSQL(F2.Value) & " 23:59:59'"

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            SQL = "SELECT CVE_BITA AS 'Cve. Bitacora', CVE_CLIE AS 'Clave', FECHAHORA AS 'Fecha', OBSERVACIONES AS 'Obsrvaciones', NOM_USUARIO AS 'Usuario', 
                U.NOMBRE AS 'Nombre usuario',    
                CASE WHEN STATUS = 'C' THEN 'Carta porte' WHEN STATUS = 'V' THEN 'Viaje' ELSE STATUS END AS 'Proceso', 
                CVE_DOC AS 'Documento ', CVE_ART AS 'Documento'
                FROM GCBITA B 
                LEFT JOIN GCUSUARIOS U ON U.USUARIO = B.NOM_USUARIO " &
                CADENA &
                " ORDER BY FECHAHORA DESC"
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource2.DataSource = dt
            Fg.DataSource = BindingSource2.DataSource

            Fg.Cols(1).Width = 70 : Fg.Cols(2).Width = 70 : Fg.Cols(3).Width = 130 : Fg.Cols(4).Width = 300 : Fg.Cols(5).Width = 160
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmBitacora_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Bitácora")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Desplegar"
                    CADENA = " WHERE FECHAHORA BETWEEN '" & FSQL(F1.Value) & " 00:00:00' AND '" & FSQL(F2.Value) & " 23:59:59'"
                    DESPLEGAR()
                Case "Edit"
                Case "Cambio estatus"
                Case "Salir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        Try
            CADENA = " WHERE FECHAHORA BETWEEN '" & FSQL(Date.Now) & " 00:00:00' AND '" & FSQL(Date.Now) & " 23:59:59'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-1)
            CADENA = " WHERE FECHAHORA BETWEEN '" & FSQL(dt) & " 00:00:00' AND '" & FSQL(dt) & " 23:59:59'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Try
            Dim dt As DateTime = Date.Today

            CADENA = " WHERE MONTH(FECHAHORA) = " & dt.Month & " AND YEAR(FECHAHORA) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddMonths(-1)

            CADENA = " WHERE MONTH(FECHAHORA) = " & dt.Month & " AND YEAR(FECHAHORA) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        Try
            CADENA = ""
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-15)
        CADENA = " WHERE FECHAHORA BETWEEN '" & FSQL(dt) & " 00:00:00' AND '" & FSQL(F2.Value) & " 23:59:59'"

        DESPLEGAR()
    End Sub

    Private Sub BarCambiosDoc_Click(sender As Object, e As ClickEventArgs) Handles BarCambiosDoc.Click
        CADENA = " WHERE CVE_ACTIVIDAD = 'FtoF'"

        DESPLEGAR()
    End Sub
End Class
