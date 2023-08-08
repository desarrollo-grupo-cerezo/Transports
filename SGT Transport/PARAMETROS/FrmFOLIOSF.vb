Imports System.Data.SqlClient
Public Class FrmFOLIOSF
    Private TIPO_D As String
    Private Sub FrmFOLIOSF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Fg.Rows(0).Height = 40
            TIPO_D = "V"
            DESPLEGAR("V")

            Me.CenterToScreen()

            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR(fTIPO As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(TIP_DOC,'') AS T_DOC, ISNULL(FOLIODESDE,0) AS DESDE, ISNULL(FOLIOHASTA,0) AS HASTA,
                    ISNULL(SERIE,'') AS SER, ISNULL(ULT_DOC,0) AS U_DOC, ISNULL(TIPO,'') AS TIP
                    FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & fTIPO & "' ORDER BY SERIE"
                cmd.CommandText = SQL
                Fg.Rows.Count = 1
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("T_DOC") & vbTab & dr("DESDE") & vbTab & dr("HASTA") & vbTab & dr("SER") & vbTab &
                                   dr("U_DOC") & vbTab & IIf(dr("TIP") = "I", "Impresión", "Digital"))
                    End While
                End Using
            End Using
            TIPO_D = fTIPO
            Fg.AutoSizeCols()
        Catch ex As Exception
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"

            If IsNothing(TIPO_D) Then
                MsgBox("Por favor seleccione tipo de documento")
                Return
            ElseIf TIPO_D.Trim.Length = 0 Then
                MsgBox("Por favor seleccione tipo de documento")
                Return
            End If

            Var5 = TIPO_D
            Var6 = Fg(Fg.Row, 4)
            FrmFoliosfAE.ShowDialog()
            DESPLEGAR(TIPO_D)
        End If
    End Sub
    Private Sub BarNotas_Click(sender As Object, e As EventArgs) Handles BarNotas.Click
        DESPLEGAR("V")
    End Sub
    Private Sub BarRemisiones_Click(sender As Object, e As EventArgs) Handles BarRemisiones.Click
        DESPLEGAR("R")
    End Sub
    Private Sub BarCotizaciones_Click(sender As Object, e As EventArgs) Handles BarCotizaciones.Click
        DESPLEGAR("C")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmFOLIOSF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarPedidos_Click(sender As Object, e As EventArgs) Handles BarPedidos.Click
        DESPLEGAR("P")
    End Sub
    Private Sub BarDevoluciones_Click(sender As Object, e As EventArgs) Handles BarDevoluciones.Click
        DESPLEGAR("D")
    End Sub
    Private Sub BarPagoComplemento_Click(sender As Object, e As EventArgs) Handles BarPagoComplemento.Click
        DESPLEGAR("G")
    End Sub
    Private Sub BarFacturas_Click(sender As Object, e As EventArgs) Handles BarFacturas.Click
        DESPLEGAR("F")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        DESPLEGAR("T")
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Var1 = "Nuevo"

        If IsNothing(TIPO_D) Then
            MsgBox("Por favor seleccione tipo de documento")
            Return
        ElseIf TIPO_D.Trim.Length = 0 Then
            MsgBox("Por favor seleccione tipo de documento")
            Return
        End If

        Var5 = TIPO_D
        FrmFoliosfAE.ShowDialog()
        DESPLEGAR(TIPO_D)
    End Sub
End Class
