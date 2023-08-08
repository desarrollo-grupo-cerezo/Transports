Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmEnlaceCompra
    Dim TIPO_DOC_COM_SEL As String

    Private Sub frmEnlaceCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Fg.Rows.Count = 1

        Fg.Rows(0).Height = 50
        TIPO_DOC_COM_SEL = Var10
        Select Case TIPO_DOC_COM_SEL
            Case "R"
                Lt.Text = "Recepción"
            Case "O"
                Lt.Text = "Orden de compra"
            Case "Q"
                Lt.Text = "Requisición"
        End Select
        Var10 = ""
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Var10 = ""
        Me.Close()
    End Sub

    Private Sub btnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PROV.Text = Var4
                LtNombre.Text = Var5
                BUSCA_DOC()
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Focus()
            End If
        Catch ex As Exception
            Bitacora("357. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("357. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barOrdenCompra_Click(sender As Object, e As EventArgs) Handles barOrdenCompra.Click
        Lt.Text = "Orden de compra"
        TIPO_DOC_COM_SEL = "O"
    End Sub

    Private Sub barRequisicion_Click(sender As Object, e As EventArgs) Handles barRequisicion.Click
        Lt.Text = "Requisición"
        TIPO_DOC_COM_SEL = "Q"
    End Sub

    Private Sub tCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                BUSCA_DOC()
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub BUSCA_DOC()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim CVE_PROV As String

            CVE_PROV = tCVE_PROV.Text.Trim
            If IsNumeric(CVE_PROV) Then
                CVE_PROV = Space(10 - CVE_PROV.Length) & CVE_PROV
            End If

            tCVE_PROV.Text = CVE_PROV

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM COMP" & UCase(TIPO_DOC_COM_SEL) & Empresa & " C " &
                "WHERE CVE_CLPV = '" & CVE_PROV & "' AND ISNULL((SELECT SUM(PXR) FROM PAR_COMP" & UCase(TIPO_DOC_COM_SEL) & Empresa & " WHERE CVE_DOC = C.CVE_DOC),0) > 0 " &
                "ORDER BY FECHAELAB DESC"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & "" & vbTab & dr("FECHA_DOC") & vbTab & dr("CAN_TOT") & vbTab &
                           dr("IMPORTE") & vbTab & dr("TIP_DOC_ANT") & vbTab & dr("DOC_ANT") & vbTab & dr("TIP_DOC_SIG") & vbTab & dr("DOC_SIG"))
            Loop
            dr.Close()

        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEnlazar_Click(sender As Object, e As EventArgs) Handles barEnlazar.Click
        Try
            If Fg.Row > 0 Then

                Var9 = TIPO_DOC_COM_SEL
                Var10 = Fg(Fg.Row, 1)

                Me.Close()
            Else
                MsgBox("Por favor seleccione un documento documento")
            End If
        Catch ex As Exception
            Bitacora("11. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("11. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        barEnlazar_Click(Nothing, Nothing)
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If e.Row > 0 Then
                If e.Col <> 2 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmEnlaceCompra_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
