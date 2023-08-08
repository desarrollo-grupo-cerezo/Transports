Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmSelItemCP
    Private Sub FrmSelItemCP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try
            Fg.Redraw = False
            Fg.Rows.Count = 1

            SQL = "SELECT CVE_FOLIO, FECHA_DOC, C.CVE_ART, P.DESCR, ST.DESCR AS DESCR_ST
                FROM GCCARTA_PORTE C
                LEFT JOIN GCSTATUS_CARTA_PORTE ST ON ST.CVE_CAP = C.ST_CARTA_PORTE
                LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = C.CVE_ART
                WHERE 
                C.STATUS = 'A' AND ISNULL(C.ST_CARTA_PORTE,0) <> 5 AND ISNULL(CVE_VIAJE,'') = '' AND ISNULL(CVE_DOCP,'') = '' 
                ORDER BY CVE_FOLIO"
            'ST_CARTA_PORTE =  5 = CANCELADA
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "" & vbTab & dr("CVE_FOLIO") & vbTab & dr("FECHA_DOC")  & vbTab & dr("DESCR") & vbTab & dr("DESCR_ST"))
                    End While
                End Using
            End Using

            Fg.AutoSizeCols()
            Fg.Redraw = True
            Me.CenterToScreen()

        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmSelItemCP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click
        Dim z As Integer = 0
        Try
            Var4 = "" : Var5 = ""
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) Then
                    z += 1
                    If z = 1 Then
                        Var4 = Fg(k, 2)
                    Else
                        Var5 = Fg(k, 2)
                    End If
                End If
            Next
            If z <> Var45 Then
                MsgBox("Por favor seleccione " & IIf(Var45 = 1, "una carta porte", "dos cartas porte"))
                Return
            End If

            Me.Close()
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            Dim z As Integer = 0

            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) Then
                    z += 1
                End If
            Next
            If z > Var45 Then
                MsgBox("Las cartas portes requeridas ya fueron seleccionadas, desmarque para poder seleccionar la deseada")
                e.Cancel = True
                Fg(Fg.Row, 1) = False
            End If
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
