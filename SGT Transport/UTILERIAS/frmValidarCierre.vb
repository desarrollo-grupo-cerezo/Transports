Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmValidarCierre
    Private Sub frmValidarCierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True

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

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 80
            Fg.Height = Screen.PrimaryScreen.Bounds.Height - F1.Top-F1.Height -100

            cboDec.Items.Add("1")
            cboDec.Items.Add("2")
            cboDec.Items.Add("3")
            cboDec.Items.Add("4")
            cboDec.Items.Add("5")
            cboDec.Items.Add("6")
            cboDec.Items.Add("7")
            cboDec.Items.Add("8")
            cboDec.SelectedIndex = 3

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmValidarCierre_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarDesplegara_Click(sender As Object, e As EventArgs) Handles BarDesplegara.Click
        Dim k As Long
        Dim SUM_IMPORTE As Double
        Dim SUM_DES_TOT As Double
        Dim SUM_CAN_TOT As Double
        Dim SUM_IMP_TOT1 As Double
        Dim SUM_IMP_TOT2 As Double
        Dim SUM_IMP_TOT3 As Double
        Dim SUM_IMP_TOT4 As Double
        Dim SUM_TOT_PARTIDA As Double
        Dim SUM_CREDITO As Double
        Dim s As String

        Me.Cursor = Cursors.WaitCursor
        k = 1

        Fg.Rows.Count = 1

        Try
            SQL = "SELECT F.CVE_DOC, CVE_CLPV, STATUS, CVE_VEND, FECHA_DOC, ISNULL(CONDICION,'') AS CONDI, TIP_DOC_ANT, " &
          "DOC_ANT, TIP_DOC_SIG, DOC_SIG, CAN_TOT, DES_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, IMPORTE, " &
          "ISNULL((SELECT SUM(TOT_PARTIDA) FROM PAR_FACTR" & Empresa & " P WHERE CVE_DOC = F.CVE_DOC),0) AS SUM_TOT_PARTIDA " &
          "FROM FACTR" & Empresa & " F WHERE " &
          "FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        k = k + 1
                        Application.DoEvents()
                        s = "" & vbTab
                        s = s & dr("CVE_DOC") & vbTab '1
                        s = s & dr("CVE_CLPV") & vbTab '2
                        s = s & dr("STATUS") & vbTab '3
                        s = s & dr("CVE_VEND") & vbTab '4
                        s = s & dr("FECHA_DOC") & vbTab '5
                        s = s & dr("CONDI") & vbTab '6
                        s = s & dr("TIP_DOC_ANT") & vbTab '7
                        s = s & dr("DOC_ANT") & vbTab '8
                        s = s & dr("TIP_DOC_SIG") & vbTab '9
                        s = s & dr("DOC_SIG") & vbTab '10
                        s = s & dr("CAN_TOT") & vbTab '11
                        s = s & dr("SUM_TOT_PARTIDA") & vbTab '12
                        s = s & dr("DES_TOT") & vbTab '13
                        s = s & dr("IMP_TOT1") & vbTab '14
                        s = s & dr("IMP_TOT2") & vbTab '15
                        s = s & dr("IMP_TOT3") & vbTab '16
                        s = s & dr("IMP_TOT4") & vbTab '17
                        s = s & dr("IMPORTE") '18
                        Fg.AddItem(s)

                        Try
                            If dr("STATUS") <> "C" Then
                                If dr("CONDI") = "Credito" Then
                                    SUM_CREDITO = SUM_CREDITO + dr("IMPORTE")
                                End If
                                SUM_IMPORTE = SUM_IMPORTE + dr("IMPORTE")
                                SUM_DES_TOT = SUM_DES_TOT + dr("DES_TOT")
                                SUM_CAN_TOT = SUM_CAN_TOT + dr("CAN_TOT")
                                SUM_TOT_PARTIDA = SUM_TOT_PARTIDA + dr("SUM_TOT_PARTIDA")
                                SUM_IMP_TOT1 = SUM_IMP_TOT1 + dr("IMP_TOT1")
                                SUM_IMP_TOT2 = SUM_IMP_TOT2 + dr("IMP_TOT2")
                                SUM_IMP_TOT3 = SUM_IMP_TOT3 + dr("IMP_TOT3")
                                SUM_IMP_TOT4 = SUM_IMP_TOT4 + dr("IMP_TOT4")
                            Else
                                If dr("STATUS") = "C" Then
                                    Fg(Fg.Row, 6) = "Cancelada"
                                    Fg(Fg.Row, 7) = "Cancelada"
                                    Fg(Fg.Row, 10) = "Cancelada"
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                    End While
                End Using
            End Using

            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
               "" & vbTab & "Suma Credito" & vbTab & Format(SUM_CREDITO, "###,##0.00") & vbTab &
               "" & vbTab & "" & vbTab & "" & vbTab & SUM_CAN_TOT & vbTab & SUM_TOT_PARTIDA & vbTab & SUM_DES_TOT & vbTab &
               SUM_IMP_TOT1 & vbTab & SUM_IMP_TOT2 & vbTab & SUM_IMP_TOT3 & vbTab & SUM_IMP_TOT4 & vbTab & SUM_IMPORTE)
            '==========================================================================================================
            Fg.AutoSizeCols()
            Me.Cursor = Cursors.Default
            MsgBox("ok")
        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click

        Dim k As Integer

        Dim CVE_DOC As String, IMPORTE As Double, SUMA As Double, DIF As Double, CANT As Double
        Dim PREC As Double, DESC1 As Double, Desc2 As Double, CAN_TOT As Double, ImporteConDes As Double, Impu1 As Double
        Dim IMPU4 As Double, DES_TOT As Double, cIMPU As Double, cIEPS As Double, IMP_TOT1 As Double, IMP_TOT4 As Double
        Dim SUM_IMPORTE As Double, SUM_DES_TOT As Double, SUM_CAN_TOT As Double, SUM_IMP_TOT1 As Double, SUM_IMP_TOT4 As Double
        Dim SUM_TOT_PARTIDA As Double, SUM_TOT_PARTIDA2 As Double, TOT_PARTIDA As Double, nDec As Integer

        If MsgBox("Realmente desea recalcular tabla FACT?", vbYesNo) = vbNo Then
            Exit Sub
        End If

        'CAMBIOS EN CIERRE AGO 2020
        Me.Cursor = Cursors.WaitCursor
        SUMA = 0 : DIF = 0
        nDec = Val(cboDec.Text)
        If nDec = 0 Then nDec = 4

        For k = 1 To Fg.Rows.Count - 2

            Application.DoEvents()
            IMP_TOT1 = 0 : IMP_TOT4 = 0 : IMPORTE = 0 : CAN_TOT = 0 : DES_TOT = 0 : TOT_PARTIDA = 0 : SUM_TOT_PARTIDA = 0
            Lt.Text = k & "/" & Fg.Rows.Count - 2
            If Fg(k, 3) <> "C" Then

                CVE_DOC = Fg(k, 1)
                SQL = "SELECT P.CVE_DOC, P.CVE_ART, CANT, PREC, COST, DESC1, DESC2, NUM_PAR, IMPUESTO1, IMPUESTO4, I.CVE_ESQIMPU, IMP4APLICA " &
                     "FROM PAR_FACTR" & Empresa & " P " &
                     "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART " &
                     "LEFT JOIN IMPU" & Empresa & " IP ON IP.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                     "WHERE CVE_DOC = '" & CVE_DOC & "' "
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            CANT = dr("CANT")
                            PREC = dr("PREC")
                            DESC1 = dr("DESC1")
                            Desc2 = dr("Desc2")

                            Impu1 = dr("IMPUESTO1")
                            IMPU4 = dr("IMPUESTO4")
                            CAN_TOT = CAN_TOT + (CANT * PREC)
                            TOT_PARTIDA = (CANT * PREC)
                            SUM_TOT_PARTIDA = SUM_TOT_PARTIDA + TOT_PARTIDA
                            SUM_TOT_PARTIDA2 = SUM_TOT_PARTIDA2 + TOT_PARTIDA

                            ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                            DES_TOT = DES_TOT + (CANT * PREC * DESC1 / 100)
                            cIEPS = ImporteConDes * Impu1 / 100
                            If dr("IMP4APLICA") = 1 Then
                                cIMPU = (ImporteConDes + cIEPS) * IMPU4 / 100
                            Else
                                cIMPU = (ImporteConDes * IMPU4) / 100
                            End If
                            IMP_TOT1 = IMP_TOT1 + cIEPS
                            IMP_TOT4 = IMP_TOT4 + cIMPU
                            IMPORTE = IMPORTE + ImporteConDes + cIEPS + cIMPU
                            'CAMBIOS EN CIERRE AGO 2020
                            If Fg(k, 1) = "AL5785" Then
                                DIF = DIF
                            End If

                            SQL = "UPDATE PAR_FACTR" & Empresa & " SET PREC = " & Math.Round(PREC, 6) & ", " &
                               "TOT_PARTIDA = " & Math.Round((CANT * PREC), nDec) & ", " &
                               "TOTIMP1 = " & Math.Round(cIEPS, nDec) & ", TOTIMP4 = " & Math.Round(cIMPU, nDec) & " WHERE " &
                               "CVE_DOC = '" & dr("CVE_DOC") & "' AND CVE_ART = '" & dr("CVE_ART") & "' AND NUM_PAR = " & dr("NUM_PAR")
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End While

                        SUM_CAN_TOT = SUM_CAN_TOT + CAN_TOT
                        SUM_DES_TOT = SUM_DES_TOT + DES_TOT
                        SUM_IMP_TOT1 = SUM_IMP_TOT1 + IMP_TOT1
                        SUM_IMP_TOT4 = SUM_IMP_TOT4 + IMP_TOT4
                        SUM_IMPORTE = SUM_IMPORTE + IMPORTE

                        DIF = DIF + Val(Fg(k, 15)) - IMPORTE

                        CAN_TOT = Math.Round(CAN_TOT, 2)

                        If Fg(k, 1) = "AL5785" Then
                            DIF = DIF
                        End If
                        'CAMBIOS EN CIERRE AGO 2020
                        Fg(k, 19) = Math.Round(CAN_TOT, nDec)
                        Fg(k, 20) = Math.Round(DES_TOT, nDec)
                        Fg(k, 21) = Math.Round(IMP_TOT1, nDec)
                        Fg(k, 22) = Math.Round(IMP_TOT4, nDec)
                        Fg(k, 23) = Math.Round(SUM_TOT_PARTIDA, nDec)
                        Fg(k, 24) = Math.Round(IMPORTE, nDec)

                        SQL = "UPDATE FACTR" & Empresa & " SET " &
                            "CAN_TOT = " & Math.Round(CAN_TOT, nDec) & ", " &
                            "DES_TOT = " & Math.Round(DES_TOT, nDec) & ", " &
                            "IMP_TOT1 = " & Math.Round(IMP_TOT1, nDec) & ", " &
                            "IMP_TOT4 = " & Math.Round(IMP_TOT4, nDec) & ", " &
                            "IMPORTE = " & Math.Round(IMPORTE, nDec) &
                            " WHERE CVE_DOC = '" & CVE_DOC & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    End Using
                End Using
            End If
        Next
        'CAMBIOS EN CIERRE AGO 2020
        Fg(Fg.Rows.Count - 1, 19) = SUM_CAN_TOT
        Fg(Fg.Rows.Count - 1, 20) = SUM_DES_TOT
        Fg(Fg.Rows.Count - 1, 21) = SUM_IMP_TOT1
        Fg(Fg.Rows.Count - 1, 22) = SUM_IMP_TOT4
        Fg(Fg.Rows.Count - 1, 23) = SUM_TOT_PARTIDA2
        Fg(Fg.Rows.Count - 1, 24) = SUM_IMPORTE

        Fg.AutoSizeCols()
        Fg.Cursor = Cursors.Default
        Me.Cursor = Cursors.Default
        MsgBox("OK")

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Cierre")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Clipboard.Clear()
        Clipboard.SetText(Fg(Fg.Row, Fg.Col))

    End Sub
End Class
