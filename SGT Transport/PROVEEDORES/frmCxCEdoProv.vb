Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class frmCxCEdoProv
    Private Sub frmCxCEdoProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        LtClave.Text = Var1
        LtNombre.Text = Var2

        '  Show outline tree.
        Fg.Tree.Column = 1
        Fg.Tree.Style = TreeStyleFlags.SimpleLeaf
        Fg.Tree.LineColor = Color.DarkBlue

        DESPLEGAR()

    End Sub

    Sub DESPLEGAR()
        Dim IMPORTE As Decimal
        Dim SALDO As Decimal
        Dim Level As Integer
        Dim i As Integer
        Dim r As Row
        Try

            SQL = "SELECT M.CVE_PROV, M.REFER, MAX(M.IMPORTE) IMPORT, MAX(M.NUM_CPTO) AS CPTO, MAX(C.DESCR) AS DS, " &
                  "MAX(M.NO_FACTURA) AS NO_FAC, MAX(M.DOCTO) AS DOCT, MAX(M.NUM_CARGO) AS NCARGO, MAX(M.FECHA_APLI) AS FAPLI, " &
                  "MAX(M.FECHA_VENC) AS FVENC, MAX(M.SIGNO) AS SIG, ISNULL(SUM(D.IMPORTE * D.SIGNO),0) AS SUM1,  " &
                  "ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " WHERE CVE_PROV = M.CVE_PROV AND REFER = M.REFER),0) AS SUM2 " &
                  "FROM PAGA_M" & Empresa & " M " &
                  "LEFT JOIN PAGA_DET" & Empresa & " D ON M.CVE_PROV = D.CVE_PROV AND M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO " &
                  "LEFT JOIN CONP" & Empresa & " C ON C.NUM_CPTO = M.NUM_CPTO WHERE M.CVE_PROV = '" & Var1 & "' " &
                  "GROUP BY M.CVE_PROV, M.REFER ORDER BY MAX(M.FECHA_APLI) DESC" '  HAVING (MAX(M.IMPORTE) - ISNULL(SUM(D.IMPORTE * D.SIGNO),0)) > 0.1 "

            Fg.AddItem("" & vbTab)
            Dim row As Row
            row = Fg.Rows(Fg.Rows.Count - 1)
            row.IsNode = True

            Dim nd As Node
            nd = row.Node
            nd.Level = Level


            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Level = 0
                    i = 1
                    Fg.Rows.Count = 1
                    While dr.Read
                        'Fg.Rows.InsertNode(i, Level)

                        Try
                            'Fg.AddItem("" & vbTab)
                            IMPORTE = IMPORTE + dr("IMPORT")
                            SALDO = SALDO + (dr("IMPORT") * dr("SIG") + dr("SUM2"))
                            If SALDO < 0 Then SALDO = 0
                        Catch ex As Exception
                            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            i = Fg.Rows.Count - 1
                            Fg.AddItem("" & vbTab & dr("REFER") & vbTab & dr("DS") & vbTab & dr("DOCT") & vbTab & dr("NCARGO") & vbTab &
                                       dr("FAPLI") & vbTab & dr("FVENC") & vbTab & (dr("Import") * dr("SIG")) & vbTab &
                                       ((dr("Import") * dr("SIG")) + dr("SUM2")) & vbTab & dr("REFER") & vbTab & dr("CPTO") & vbTab &
                                       "PAGA_M" & vbTab & dr("SIG"))
                        Catch ex As Exception
                            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        'Fg(i, 1) = dr("NO_FAC")
                        'Fg(i, 2) = dr("DS")
                        'Fg(i, 3) = dr("DOCT")
                        'Fg(i, 4) = dr("NCARGO")
                        'Fg(i, 5) = dr("FAPLI")
                        'Fg(i, 6) = dr("FVENC")
                        'Fg(i, 7) = (dr("Import") * dr("SIG"))
                        'Fg(i, 8) = ((dr("Import") * dr("SIG")) + dr("SUM1"))
                        'Fg(i, 9) = dr("REFER")
                        'Fg(i, 10) = dr("CPTO")
                        'Fg(i, 11) = "PAGA_M"
                        'Fg(i, 12) = dr("SIG")
                        r = Fg.Rows(Fg.Rows.Count - 1)
                        r.IsNode = True
                        r.Node.Level = Level
                        'r.Node.Collapsed = True
                        Fg.AddItem("" & vbTab & "Factura" & vbTab & "Concepto" & vbTab & "Documento" & vbTab &
                            "" & vbTab & "Fecha Apli." & vbTab & "fecha venc." & vbTab & "Importe" & vbTab &
                            "folio" & vbTab & "Estatus" & vbTab & "10" & vbTab & "11")

                        SQL = "SELECT D.NUM_CPTO, C.DESCR, D.REFER, D.NO_FACTURA , D.FECHA_APLI, D.FECHA_VENC, " &
                             "D.IMPORTE, D.SIGNO, D.NO_PARTIDA " &
                             "FROM PAGA_DET" & Empresa & " D " &
                             "LEFT JOIN CONP" & Empresa & " C ON C.NUM_CPTO = D.NUM_CPTO " &
                             "WHERE CVE_PROV = '" & dr("CVE_PROV") & "' AND REFER = '" & dr("REFER") & "'"
                        Level = 2
                        r = Fg.Rows(Fg.Rows.Count - 1)
                        r.IsNode = True
                        r.Node.Level = Level
                        'r.Node.Collapsed = True
                        'Level = Level + 1
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                While dr2.Read
                                    Try
                                        Fg.AddItem("-" & vbTab & dr2("NO_FACTURA") & vbTab & dr2("DESCR") & vbTab & dr2("REFER") & vbTab &
                                        "" & vbTab & dr2("FECHA_APLI") & vbTab & dr2("FECHA_VENC") & vbTab & (dr2("IMPORTE") * dr2("SIGNO")) &
                                        vbTab & "" & vbTab & dr2("REFER") & vbTab & dr2("NO_PARTIDA") & vbTab & "PAGA_DET" & vbTab & dr2("SIGNO"))
                                        r = Fg.Rows(Fg.Rows.Count - 1)
                                        r.IsNode = True
                                        r.Node.Level = Level '+ 1

                                        BACKUPTXT("paga", dr2("REFER"))
                                    Catch ex As Exception
                                        Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End While
                                BACKUPTXT("paga", "----------------")
                            End Using
                        End Using
                        i = i + 1
                        Level = 0
                        'r = Fg.Rows(Fg.Rows.Count - 1)
                        'r.IsNode = True
                        'r.Node.Level = Level + 1
                    End While
                End Using
            End Using

            For k = 1 To Fg.Rows.Count - 1
                Dim r1 As Row = Fg.Rows(k)
                r1.Node.Collapsed = True
            Next


        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmCxCEdoProv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
