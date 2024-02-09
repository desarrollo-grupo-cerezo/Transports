Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmSelGastosViaje
    Private Sub FrmSelGastosViaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmSelGastosViaje_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            Me.CenterToScreen()

            DESPLEGAR()
        Catch ex As Exception

        End Try
    End Sub
    Sub DESPLEGAR()
        Dim STATUS As Boolean = False
        Fg.Rows.Count = 1

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT GV.CVE_VIAJE, ISNULL(GV.STATUS,'A') AS STA, GV.CVE_OPER, GV.CVE_GAV, GV.FOLIO, GV.FECHA, GV.CVE_NUM, 
                    ISNULL(GV.IMPORTE,0) AS IMPORT, DESCR, ISNULL(GV.ST_GASTOS,'EDICION') AS ST_GAS, GV.UUID, ISNULL(GV.OBS, '') AS OBS
                    FROM GCASIGNACION_VIAJE_GASTOS GV
                    LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = GV.CVE_VIAJE
                    LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = GV.CVE_NUM
                    WHERE GV.CVE_OPER = '" & Var18 & "' AND
                    ISNULL(ST_GASTOS,'') = 'DEPOSITADO' ORDER BY GV.FECHAELAB"
                'ESTE PEDAZO DE CODIGO SE QUITO RESPONSABLE CRISTIAN   CVE_TRACTOR = '" & Var19 & "' AND 
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            If dr("STA") = "L" Then
                                STATUS = False
                            Else
                                STATUS = True
                            End If

                            For k = 1 To frmLiquidacionesAE.FgG.Rows.Count - 1
                                If frmLiquidacionesAE.Fgg(k, 10) = dr("UUID") Then
                                    STATUS = False
                                    Exit For
                                End If
                            Next

                            If STATUS Then
                                Fg.AddItem("" & vbTab & "" & vbTab & dr("CVE_VIAJE") & vbTab & dr("FOLIO") & vbTab & dr("FECHA") & vbTab & dr("CVE_NUM") & vbTab &
                                    dr("DESCR") & vbTab & dr("IMPORT") & vbTab & dr("ST_GAS") & vbTab & 0 & vbTab & dr("UUID") & vbTab & "" & vbTab & dr("OBS"))
                            End If
                        Catch ex As Exception
                            Bitacora("850. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
                Fg.AutoSizeCols()

                Fg.Cols(9).Width = 0
                Fg.Cols(10).Width = 0
                Fg.Cols(11).Width = 0

                If Fg.Rows.Count = 1 Then
                    MsgBox("No se encontraron gastos pendientes")
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmSelGastosViaje_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click
        Dim cRow As Integer

        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) Then

                    cRow = frmLiquidacionesAE.FgG.Rows.Count - 1
                    If cRow = 0 Then
                        cRow = 1
                    End If

                    frmLiquidacionesAE.FgG.Rows.Insert(cRow)
                    Select Case cRow
                        Case 1
                    End Select

                    frmLiquidacionesAE.FgG(cRow, 1) = True
                    frmLiquidacionesAE.FgG(cRow, 2) = Fg(k, 2)
                    frmLiquidacionesAE.FgG(cRow, 3) = Fg(k, 3)
                    frmLiquidacionesAE.FgG(cRow, 4) = Fg(k, 4)
                    frmLiquidacionesAE.FgG(cRow, 5) = Fg(k, 5)
                    frmLiquidacionesAE.FgG(cRow, 6) = Fg(k, 6)
                    frmLiquidacionesAE.FgG(cRow, 7) = Fg(k, 7)
                    frmLiquidacionesAE.FgG(cRow, 8) = Fg(k, 8)
                    frmLiquidacionesAE.FgG(cRow, 9) = 0
                    frmLiquidacionesAE.FgG(cRow, 10) = Fg(k, 10)
                    FrmLiquidacionesAE.FgG(cRow, 11) = "G"
                    FrmLiquidacionesAE.FgG(cRow, 12) = Fg(k, 12)
                End If
            Next
            Me.Close()
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Gastos de viaje")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

End Class
