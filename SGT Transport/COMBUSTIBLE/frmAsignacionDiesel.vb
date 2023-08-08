Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmAsignacionDiesel
    Private Sub frmAsignacionDiesel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

            'Fg.Rows.Count = 1
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - tCAPACIDAD.Top + tCAPACIDAD.Width
            Fg.Rows(0).Height = 50

        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmAsignacionDiesel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Asignación diesel")
    End Sub

    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            Var2 = "ReseteoTab"
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                AGREGAR_PARTIDA_PAR_TAB(Var4)

                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("750. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("750. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Sub AGREGAR_PARTIDA_PAR_TAB(fCVE_TAB As Long)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_OPER, O.NOMBRE AS NOMB_OPER, CVE_UNI, TIPO_VIAJE, CVE_ORI, ISNULL(P1.CIUDAD,'') AS DESCR_ORI, CVE_DES, 
                    ISNULL(P2.CIUDAD,'') AS DESCR_DES, 
                    ISNULL(CARGADO_VACIO,0) AS CAR_VAC, CLIENTE, C.NOMBRE AS NOMB_OP, ISNULL(KMS,0) As KM, ISNULL(RENDIMIENTO,0) As RENDI 
                    FROM GCTABULADOR_PAR T 
                    LEFT JOIN GCOPERADOR O On O.CLAVE = T.CVE_OPER 
                    LEFT JOIN GCCLIE_OP C On C.CLAVE = CLIENTE 
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = CVE_ORI 
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = CVE_DES 
                    WHERE CVE_TAB = " & fCVE_TAB
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Try
                            Fg(Fg.Row, 1) = fCVE_TAB
                            Fg(Fg.Row, 2) = dr("CVE_UNI")
                            Fg(Fg.Row, 1) = dr("CVE_ORI")
                            Fg(Fg.Row, 1) = dr("DESCR_ORI")
                            Fg(Fg.Row, 1) = dr("CVE_DES")
                            Fg(Fg.Row, 1) = dr("DESCR_DES")
                            Fg(Fg.Row, 1) = IIf(dr("CAR_VAC"), "CARGADO", "VACIO")
                            Fg(Fg.Row, 1) = dr("TIPO_VIAJE")
                            Fg(Fg.Row, 1) = dr("CLIENTE")
                            Fg(Fg.Row, 1) = dr("NOMB_OP")
                            Fg(Fg.Row, 1) = dr("KM")
                            Fg(Fg.Row, 1) = dr("RENDI")
                            Fg(Fg.Row, 1) = IIf(dr("RENDI") > 0, dr("KM") / dr("RENDI"), 0)
                        Catch ex As Exception
                            Bitacora("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            MsgBox("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    End If
                End Using
                'CALCULA_RENDIMIENTO()
            End Using
        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

End Class
