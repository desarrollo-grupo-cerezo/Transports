Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmFOLIOSC
    Private TIPO_D As String

    Private Sub FrmSeriesCat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Me.CenterToScreen()
        Catch ex As Exception
        End Try
        Try
            TIPO_D = "c"
            DESPLEGAR("c")
        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR(fTIPO As String)
        Try
            Dim Existe As Boolean = False

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM FOLIOSC" & Empresa & " WHERE LOWER(TIP_DOC) = '" & fTIPO.ToLower & "' ORDER BY SERIE"
                cmd.CommandText = SQL
                Fg.Rows.Count = 1
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("TIP_DOC").ToString.ToLower & vbTab & dr("FOLIODESDE") & vbTab &
                                   dr("FOLIOHASTA") & vbTab & dr("SERIE") & vbTab & dr("ULT_DOC"))
                        Existe = True
                    End While
                End Using
            End Using
            If Not Existe Then
                Try
                    SQL = "IF NOT EXISTS (SELECT TIP_DOC FROM FOLIOSC" & Empresa & " WHERE LOWER(TIP_DOC) = '" & fTIPO.ToLower & "' AND SERIE = 'STAND.')
                        INSERT INTO FOLIOSC" & Empresa & " (TIP_DOC, FOLIODESDE, FOLIOHASTA, SERIE, 
                        ULT_DOC, STATUS) VALUES('" & fTIPO.ToLower & "',0,1,'STAND.',0,'A')"

                    If EXECUTE_QUERY_NET(SQL) Then
                        Fg.AddItem("" & vbTab & fTIPO.ToLower & vbTab & "0" & vbTab & "1" & vbTab & "STAND." & vbTab & 0)
                    End If
                Catch ex As Exception
                End Try
            End If

            TIPO_D = fTIPO
        Catch ex As Exception
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCompras_Click(sender As Object, e As EventArgs) Handles BarCompras.Click
        DESPLEGAR("c")
    End Sub
    Private Sub BarRecepcion_Click(sender As Object, e As EventArgs) Handles BarRecepcion.Click
        DESPLEGAR("r")
    End Sub
    Private Sub BarOrdeCompra_Click(sender As Object, e As EventArgs) Handles BarOrdeCompra.Click
        DESPLEGAR("o")
    End Sub
    Private Sub BarRequisicon_Click(sender As Object, e As EventArgs) Handles BarRequisicon.Click
        DESPLEGAR("q")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
    Private Sub BarDocNUevo_Click(sender As Object, e As EventArgs) Handles BarDocNUevo.Click
        Var1 = "Nuevo"
        Var5 = TIPO_D
        Var6 = ""
        frmSeriesAE.ShowDialog()
        DESPLEGAR(TIPO_D)
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var5 = TIPO_D
            Var6 = Fg(Fg.Row, 4)
            frmSeriesAE.ShowDialog()
            DESPLEGAR(TIPO_D)
        End If
    End Sub

    Private Sub FrmSeriesCat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGastos_Click(sender As Object, e As EventArgs) Handles BarGastos.Click
        DESPLEGAR("g")
    End Sub

    Private Sub BarPreOrdenCompra_Click(sender As Object, e As EventArgs) Handles BarPreOrdenCompra.Click
        DESPLEGAR("p")
    End Sub
End Class
