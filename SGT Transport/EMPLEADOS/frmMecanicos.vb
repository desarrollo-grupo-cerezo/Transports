Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmMecanicos
    Private CADENA As String

    Private Sub frmMecanicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
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
        Try

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 6

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int16)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripción"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Cuenta contable"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Motivo cancelación"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            CADENA = "WHERE ISNULL(STATUS,'A') = 'A'"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT M.CVE_MEC, M.STATUS, M.DESCR, M.CUEN_CONT, MC.DESCR AS DES_MOTCANC
                FROM GCMECANICOS M
                LEFT JOIN GCMOTIVO_CANC MC ON MC.CVE_MTC = M.CVE_MTC
                " & CADENA

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_MEC") & vbTab & dr("STATUS") & vbTab & dr("DESCR") & vbTab & dr("CUEN_CONT") & vbTab &
                           dr("DES_MOTCANC"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

            If CADENA = "WHERE ISNULL(STATUS,'A') = 'A'" Then
                Fg.Cols(5).Visible = False
            Else
                Fg.Cols(5).Visible = True
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmMecanicos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Mecanicos")
        Me.Dispose()
    End Sub

    Private Sub frmMecanicos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            Var3 = ""

            frmMecanicosAE.ShowDialog()

            CADENA = "WHERE ISNULL(STATUS,'A') = 'A'"
            DESPLEGAR()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            Var3 = Fg(Fg.Row, 2)

            frmMecanicosAE.ShowDialog()

            CADENA = "WHERE ISNULL(STATUS,'A') = 'A'"
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                Var4 = ""
                FrmMotivoBaja.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    Dim CVE_MTC As Long = 0
                    Try
                        CVE_MTC = GRABA_MOTIVO_CANC("MECANICOS", Var4)
                    Catch ex As Exception
                        Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                    'SQL = "UPDATE GCUNIDADES SET STATUS = 'B' WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"

                    SQL = "UPDATE GCMECANICOS SET STATUS = 'B', CVE_MTC = " & CVE_MTC & " WHERE CVE_MEC = '" & Fg(Fg.Row, 1) & "'"
                    Dim cmd As New SqlCommand
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            MsgBox("El registro se elimino satisfactoriamente")
                            DESPLEGAR()
                        Else
                            MsgBox("NO se logro eliminar el registro")
                        End If
                    Else
                        MsgBox("!!NO se logro eliminar el registro!!")
                    End If
                Else
                    Dim ResultMensaje As String
                    ResultMensaje = MensajeBox("Cancelación no realizada", "Proceso finalizado", "Error")
                End If

            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "MECANICOS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click

        barEliminar.Visible = True
        CADENA = "WHERE ISNULL(STATUS,'A') = 'A'"
        DESPLEGAR()
    End Sub

    Private Sub BarMecEliminadas_Click(sender As Object, e As EventArgs) Handles BarMecEliminadas.Click


        barEliminar.Visible = False
        CADENA = " WHERE ISNULL(STATUS, 'A') = 'B'"
        DESPLEGAR()

    End Sub
End Class
