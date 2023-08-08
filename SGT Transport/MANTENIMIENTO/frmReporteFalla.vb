Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmReporteFalla
    Private Sub frmReporteFalla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 11

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Estado"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Sucursal"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Fecha"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(DateTime)

            Fg(0, 6) = "Unidad"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Operador"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Clasificación de servicio"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Descripción de la falla"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Orden de trabajo"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            DESPLEGAR()

        Catch ex As Exception
            msgbox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim CVE_ORD As String
            Dim C1 As String
            Dim C2 As String
            Dim C3 As String
            Dim C4 As String

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT F.CVE_FALLA, F.STATUS, F.CVE_SUC, F.FECHA, F.CVE_UNI, F.CVE_OPER, F.CVE_CLAS, F.DESCR_FALLA, ISNULL(ESTATUS,'Captura') AS ESTAT, 
                REPLACE(ISNULL(STUFF((SELECT ' , ' + CVE_UNI FROM GCREPORTE_FALLAS_PAR P WHERE P.CVE_FALLA = F.CVE_FALLA FOR XML PATH ('')),1,2, ''),''),',',' ') AS UNIDAD, 
                ISNULL(O.NOMBRE,'') AS NOMBRE_OPER, ISNULL(C.DESCR,'') AS DESCR_CLAS, 
                REPLACE(ISNULL(STUFF((SELECT ' , ' + CVE_ORD FROM GCREPORTE_FALLAS_PAR P WHERE P.CVE_FALLA = F.CVE_FALLA ORDER BY TRY_PARSE(CVE_ORD AS INT) FOR XML PATH ('')),1,2, ''),''),',','') AS CVEORD 
                FROM GCREPORTE_FALLAS F 
                LEFT JOIN GCOPERADOR O ON O.CLAVE = F.CVE_OPER 
                LEFT JOIN GCCLASIFIC_SERVICIOS C ON C.CVE_CLA = F.CVE_CLAS 
                WHERE F.STATUS = 'A' ORDER BY TRY_CAST(F.CVE_FALLA AS INT) DESC"
            Fg.Redraw = False
            '"SELECT CVE_CLA, DESCR FROM GCCLASIFIC_SERVICIOS WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read

                CVE_ORD = dr("CVEORD")
                C1 = dr("UNIDAD").ToString
                C2 = dr("NOMBRE_OPER").ToString
                C3 = dr("DESCR_CLAS").ToString
                C4 = dr("DESCR_FALLA").ToString.Replace("vbTab", "")

                Fg.AddItem("" & vbTab & dr("CVE_FALLA") & vbTab & dr("STATUS") & vbTab & dr("ESTAT") & vbTab & dr("CVE_SUC") & vbTab &
                           dr("FECHA") & vbTab & C1 & vbTab & C2 & vbTab & C3 & vbTab & C4 & vbTab & CVE_ORD)
            Loop
            dr.Close()
            Fg.AutoSizeCols()
            Fg.Redraw = True

            Try
                C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmReporteFalla_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Reporte de Falla")
        Me.Dispose()
    End Sub

    Private Sub frmReporteFalla_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            msgbox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"

            CREA_TAB(frmReporteFallaAE, "Captura Fallas")
            'frmReporteFallaAE.ShowDialog()
            'DESPLEGAR()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)

        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            CREA_TAB(frmReporteFallaAE, "Captura Fallas")
            'frmReporteFallaAE.ShowDialog() '
            'DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCREPORTE_FALLAS SET STATUS = 'B' WHERE CVE_FALLA = '" & Fg(Fg.Row, 1) & "'"
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
            msgbox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
