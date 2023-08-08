Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Public Class FrmPDocDR
    Private UUID_FRM As String
    Private ClienteDr As String

    Private Sub FrmPDocDR_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        'Me.TopMost = True
        'MakeMeTopmostForAWhile()
        UUID_FRM = PassData2


        Dim LngDif As Decimal, lng2 As Decimal = 0
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height

        '0.22037               495+322+25=842   1080-842=238
        lng2 = ((intY - (Var44 + Var45 + 25)) / intY)
        LngDif = (1 - lng2) * 100

        'Var44 = pnt.Y 'FG
        'Var45 = Fg.Row * 23 'PUNOS AGREGAGOS X FILA

        Me.Height = 230
        Me.Width = Screen.PrimaryScreen.Bounds.Width - 100
        If LngDif > 75 Then
            Me.Location = New Point(50, Var44)
        Else
            Me.Location = New Point(50, Var44 + Var45 + 25)
        End If


        FFormOpen = "OPEN"

        ClienteDr = Var47

        DESPLEGAR()

    End Sub
    Sub DESPLEGAR()
        Dim OBJETOIMP_DR As String = "", EXISTE As Boolean = False, IMPORTEDR As Decimal = 0, LETRA_DR As String
        Fg.Rows.Count = 1

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCFDI_COMPAGO_PAR_DR WHERE CVE_DOC = '" & ClienteDr & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & "" & vbTab & dr("NUMPARCIALIDAD") & vbTab &
                            dr("FECHA") & vbTab & dr("IMPSALDOANT") & vbTab & dr("IMPPAGADO") & vbTab &
                            dr("IMPSALDOINSOLUTO") & vbTab & dr("IDDOCUMENTO") & vbTab & dr("SERIE") & vbTab &
                            dr("FOLIO") & vbTab & dr("MONEDADR") & vbTab & dr("FORMADEPAGOSAT") & vbTab & dr("TCAMBIO"))
                        EXISTE = True
                    End While
                    Fg.AutoSizeCols()
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            If Not EXISTE Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT D.REFER, D.CVE_CLIE, P.NOMBRE, D.FECHA_APLI, D.NO_FACTURA, D.DOCTO, D.IMPORTE, 
                    N.CVE_MONED, D.TCAMBIO, D.NO_PARTIDA, M.IMPORTE AS IMPORTE_M, LV.METODODEPAGO, LV.FORMADEPAGOSAT
                    FROM CUEN_DET" & Empresa & " D
                    LEFT JOIN CUEN_M" & Empresa & " M ON M.REFER = D.REFER
                    LEFT JOIN CFDI LV ON LV.FACTURA = D.REFER
                    LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = D.CVE_CLIE 
                    LEFT JOIN MONED" & Empresa & " N ON N.NUM_MONED = M.NUM_MONED 
                    WHERE ISNULL(LV.METODODEPAGO,'PPD') = 'PPD' AND ISNULL(LV.FORMADEPAGOSAT,'99') = 99 AND 
                    ISNULL(D.CVE_DOC_COMPPAGO,'') = '' AND D.REFER = '" & ClienteDr & "'"
                    cmd.CommandText = SQL

                    Dim UUIDDR As String, IMPORTE As Decimal = 0, SALDO_ANT As Decimal

                    SALDO_ANT = Var48 - Var49 'IMPORTE_M - ABONOS
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        Do While dr.Read

                            UUIDDR = BUSCAR_UUID_CARTA_PORTE(dr("REFER"))

                            If UUIDDR.Trim.Length > 0 Then

                                SALDO_ANT -= IMPORTE
                                LETRA_DR = Regex.Replace(dr("REFER"), "[^a-zA-Z]", "")

                                IMPORTEDR = Math.Round(dr("IMPORTE"), 6)

                                Fg.AddItem("" & vbTab & dr("REFER") & vbTab & "" & vbTab & dr("NO_PARTIDA") & vbTab &
                                  dr("FECHA_APLI") & vbTab & SALDO_ANT & vbTab & dr("IMPORTE") & vbTab &
                                  (SALDO_ANT - IMPORTEDR) & vbTab & UUIDDR & vbTab & LETRA_DR & vbTab &
                                  GetNumeric(dr("REFER")) & vbTab & dr("CVE_MONED") & vbTab &
                                  dr("FORMADEPAGOSAT") & vbTab & dr("TCAMBIO"))

                                IMPORTE = IMPORTEDR

                                Try
                                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM GCCFDI_COMPAGO_PAR_DR WHERE CVE_DOC = @CVE_DOC AND NUMPARCIALIDAD = @NUMPARCIALIDAD)
                                    BEGIN
                                        INSERT INTO GCCFDI_COMPAGO_PAR_DR (CVE_DOC, FECHA, FOLIO, OBJETOIMP_DR, IMPSALDOINSOLUTO, IMPPAGADO, IMPSALDOANT, 
                                        NUMPARCIALIDAD, EQUIVALENCIADR, MONEDADR, SERIE, IDDOCUMENTO, FORMADEPAGOSAT, TCAMBIO, GUID_G) VALUES(
                                        @CVE_DOC, @FECHA, @FOLIO, @OBJETOIMP_DR, @IMPSALDOINSOLUTO, @IMPPAGADO, @IMPSALDOANT, @NUMPARCIALIDAD, 
                                        @EQUIVALENCIADR, @MONEDADR, @SERIE, @IDDOCUMENTO, @FORMADEPAGOSAT, @TCAMBIO, @GUID_G)
                                    END"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        cmd2.Parameters.Clear()
                                        cmd2.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = Var47
                                        cmd2.Parameters.Add("@FECHA", SqlDbType.Date).Value = dr("FECHA_APLI")
                                        cmd2.Parameters.Add("@FOLIO", SqlDbType.Int).Value = GetNumeric(dr("REFER"))
                                        cmd2.Parameters.Add("@OBJETOIMP_DR", SqlDbType.VarChar).Value = OBJETOIMP_DR
                                        cmd2.Parameters.Add("@IMPSALDOINSOLUTO", SqlDbType.Float).Value = Math.Round((SALDO_ANT - IMPORTEDR), 6)
                                        cmd2.Parameters.Add("@IMPPAGADO", SqlDbType.Float).Value = IMPORTEDR
                                        cmd2.Parameters.Add("@IMPSALDOANT", SqlDbType.Float).Value = SALDO_ANT
                                        cmd2.Parameters.Add("@NUMPARCIALIDAD", SqlDbType.SmallInt).Value = dr("NO_PARTIDA")
                                        cmd2.Parameters.Add("@EQUIVALENCIADR", SqlDbType.SmallInt).Value = dr("TCAMBIO")
                                        cmd2.Parameters.Add("@MONEDADR", SqlDbType.VarChar).Value = dr("CVE_MONED")
                                        cmd2.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = LETRA_DR
                                        cmd2.Parameters.Add("@IDDOCUMENTO", SqlDbType.VarChar).Value = UUIDDR
                                        cmd2.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = dr("FORMADEPAGOSAT")
                                        cmd2.Parameters.Add("@TCAMBIO", SqlDbType.VarChar).Value = dr("TCAMBIO")
                                        cmd2.Parameters.Add("@GUID_G", SqlDbType.VarChar).Value = UUID_FRM
                                        returnValue = cmd2.ExecuteNonQuery()
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then

                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                End Try
                            End If
                        Loop
                        Fg.AutoSizeCols()
                    End Using
                End Using

            End If

        Catch ex As Exception
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Function AGREGAR_DOC(FCVE_DOC As String, FNO_PARTIDA As Integer) As Boolean
        Dim EXISTE As Boolean = False
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) = FCVE_DOC And Fg(k, 3) = FNO_PARTIDA Then
                    EXISTE = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return EXISTE
    End Function
    Private Sub FrmPDocDR_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FFormOpen = "CLOSE"
        Me.Dispose()
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        Try
            If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                Try
                    If IsNumeric(Fg(Fg.Row, 3)) Then

                        SQL = "DELETE FROM GCCFDI_COMPAGO_PAR_DR WHERE 
                            CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3))

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Fg.Rows(Fg.Row).Visible = False
                                End If
                            End If
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try

            End If
        Catch ex As Exception
            Bitacora("251. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_LeaveEdit(sender As Object, e As RowColEventArgs) Handles Fg.LeaveEdit
        Try
            If Fg.Row > 0 Then
                Select Case Fg.Col
                    Case 1
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET CVE_DOC = '" & Fg(Fg.Row, 1) & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 3
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET NUMPARCIALIDAD = " & CInt(Fg.Editor.Text) & " WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg.Editor.Text))
                    Case 4
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET FECHA = '" & FSQL(Fg.Editor.Text) & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 5
                        Fg(Fg.Row, 7) = CDec(Fg.Editor.Text) - Fg(Fg.Row, 6)
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET IMPSALDOANT = " & CDec(Fg.Editor.Text) & " WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))

                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET IMPSALDOINSOLUTO = " & CDec(Fg(Fg.Row, 7)) & " WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 7
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET IMPSALDOINSOLUTO = " & CDec(Fg.Editor.Text) & " WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))

                    Case 8 'UUID
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET IDDOCUMENTO = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 9 'SERIE
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET SERIE= '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 10 'FOLIO
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET FOLIO = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 11 'MONEDA
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET MONEDADR = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 12 'METODO DE PAGO
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET FORMADEPAGOSAT = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 13 'TCAMBIO
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET TCAMBIO = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                End Select

            End If
        Catch ex As Exception
            Bitacora("251. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 2 Then
                    Var2 = "PagoComplementoDocCte"
                    Var5 = ClienteDr
                    'SOLO FACTURAS QUE TENGAN 99 Y PPD
                    FrmSelItem2.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        Fg(Fg.Row, 1) = Var4
                        Var2 = "" : Var4 = "" : Var5 = ""
                        Fg.Col = 3
                    Else
                        Fg.Col = 1
                    End If
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("251. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
