Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmRESETEORecalculoGlobal
    Private Sub frmRESETEORecalculoGlobal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

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

    End Sub

    Private Sub frmRESETEORecalculoGlobal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim CVE_MOT As Integer
            Dim CAL1 As Decimal = 0, CAL2 As Decimal = 0, CAL3 As Decimal = 0, CVE_RES As Integer, j As Integer = 0
            Dim V1 As Decimal = 0, V2 As Decimal = 0, C1 As Decimal = 0, PORC_USO_RALENTI As Decimal = 0, CALIF_RALENTI As Decimal = 0
            Dim LTS_AUTORIZADOS As Decimal = 0, LTS_DESCONTAR As Decimal = 0, LTS_ECM As Decimal = 0, LTS_RALENTI As Decimal = 0
            Dim LTS_FISICOS As Decimal = 0
            cmd.Connection = cnSAE

            SQL = "SELECT R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, R.CVE_UNI, R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, 
                CAL_GLO_EVA, BONO_RES, R.ODOMETRO,  KM_ECM, LTS_ECM, LTS_REAL, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI, 
                LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI,  PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL, 
                REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB, CVE_MOT, EVE_PORC_TOLERANCIA, LTS_VALES, EVE_PORC_RALENTI,
                LTS_SALIDA, LTS_LLEGADA, LTS_FORANEOS
                FROM GCRESETEO R
                WHERE R.FECHA >= '" & FSQL(F1.Value) & "' AND R.FECHA <= '" & FSQL(F2.Value) & "'"

            Fg.Rows.Count = 1

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read

                CVE_RES = dr.ReadNullAsEmptyInteger("CVE_RES")
                CVE_MOT = dr.ReadNullAsEmptyInteger("CVE_MOT")

                If CVE_RES > 0 Then
                    Try
                        CAL1 = 0 : CAL2 = 0 : CAL3 = 0

                        CAL1 = dr.ReadNullAsEmptyDecimal("LTS_ECM") - dr.ReadNullAsEmptyDecimal("LTS_PTO_RALENTI")
                        CAL2 = dr.ReadNullAsEmptyDecimal("EVE_PORC_RALENTI") + dr.ReadNullAsEmptyDecimal("EVE_PORC_TOLERANCIA")
                        If CAL2 > 0 Then
                            CAL2 = 1 + (CAL2 / 100)
                        Else
                            CAL2 = 0
                        End If
                        LTS_AUTORIZADOS = CAL1 * CAL2
                        'LTS_VALES = dr("")
                        LTS_FISICOS = dr.ReadNullAsEmptyDecimal("LTS_SALIDA") + dr.ReadNullAsEmptyDecimal("LTS_VALES") + dr.ReadNullAsEmptyDecimal("LTS_FORANEOS") - dr.ReadNullAsEmptyDecimal("LTS_LLEGADA")
                        'MsgBox("LTS. REALES = LTS_SALIDA + LTS_VALES - LTS_LLEGADA")
                        If LTS_AUTORIZADOS - LTS_FISICOS > 0 Then
                            LTS_DESCONTAR = 0
                        Else
                            LTS_DESCONTAR = LTS_AUTORIZADOS - LTS_FISICOS
                        End If

                        LTS_ECM = (dr.ReadNullAsEmptyDecimal("LTS_ECM") - dr.ReadNullAsEmptyDecimal("LTS_PTO_RALENTI")) * dr.ReadNullAsEmptyDecimal("EVE_PORC_TOLERANCIA")
                        LTS_RALENTI = (dr.ReadNullAsEmptyDecimal("LTS_ECM") - dr.ReadNullAsEmptyDecimal("LTS_PTO_RALENTI")) * dr.ReadNullAsEmptyDecimal("EVE_PORC_RALENTI") / 100

                        Fg.AddItem("" & vbTab & CVE_RES & vbTab & CAL1 & vbTab & CAL2 & vbTab &
                                   dr.ReadNullAsEmptyDecimal("LTS_SALIDA") & vbTab & dr.ReadNullAsEmptyDecimal("LTS_VALES") & vbTab &
                                   dr.ReadNullAsEmptyDecimal("LTS_LLEGADA") & vbTab & LTS_AUTORIZADOS & vbTab & LTS_FISICOS & vbTab &
                                   LTS_DESCONTAR)

                        If CVE_RES = 1167 Then
                            MsgBox("LTS_AUTORIZADOS = " & LTS_AUTORIZADOS & ", LTS_VALES = " & dr.ReadNullAsEmptyDecimal("LTS_VALES"))
                        End If
                        Try
                            SQL = "UPDATE GCRESETEO Set LTS_AUTORIZADOS = " & LTS_AUTORIZADOS & ", LTS_DESCONTAR = " & LTS_DESCONTAR & "
                                WHERE CVE_RES = " & CVE_RES
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQL
                                returnValue = cmd3.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                                Lt1.Text = "CVE_RES " & CVE_RES
                                j = j + 1
                                Lt2.Text = j
                            End Using
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Catch ex As Exception
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Loop
            dr.Close()
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function OBTENER_BONO_DESDE_CATEVA(fCVE_MOT As Integer, fCANT_GLO_EVA As Decimal) As Decimal
        Dim BONO As Decimal = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCATEVA WHERE CVE_MOT = " & fCVE_MOT & " AND STATUS <> 'B'"
                            cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Try
                            If dr("CALIF_GLOBAL") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL2") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO2")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL3") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO3")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL4") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO4")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL5") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO5")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL6") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO6")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL7") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO7")
                            End If
                        Catch ex As Exception
                            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1340. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End Using
            End Using
            Return BONO
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1340. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & SQL)
            Return BONO
        End Try
    End Function
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "RESETEO")
    End Sub
End Class
