Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmZonas

    Private Sub frmZonas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Zonas")
    End Sub

    Private Sub frmZonas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            msgbox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmZonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 3

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg.Cols(0).AllowEditing = False
            Fg.Cols(1).AllowEditing = False
            Fg.Cols(2).AllowEditing = False

            Fg.Cols.Fixed = 0
            Fg.Rows.Count = 1
            Fg.ExtendLastCol = True
            Fg.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
            Fg.Styles.Normal.Border.Style = BorderStyleEnum.None
            ' initialize outline tree
            Fg.Tree.Column = 0
            Fg.Tree.Style = TreeStyleFlags.SimpleLeaf

            Fg.Cols(0).Width = 40
            Fg.Cols(1).Width = 60
            Fg.Cols(2).Width = 150
            Fg.Rows.Add()

            DESPLEGAR()

        Catch ex As Exception
            msgbox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub AddNodo(ByVal fNODO As String, ByVal fLevel As Integer, fCVE_ZONA As String, fTNODO As String)

        Try

            Dim thisDir As String
            thisDir = fNODO

            Dim row As Integer = Fg.Rows.Count
            Fg.Rows.Add()
            Fg.Rows(row).IsNode = True
            Fg.Rows(row).Node.Level = fLevel

            Fg(row, 0) = fNODO
            Fg(row, 1) = fCVE_ZONA
            Fg(row, 2) = fTNODO
        Catch ex As Exception
            msgbox("13.1 " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13.1 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try

            Dim cmd As New sqlcommand
            Dim dr As SqlDataReader
            Dim cmd2 As New SqlCommand
            Dim dr2 As SqlDataReader
            Dim cmd3 As New SqlCommand
            Dim dr3 As SqlDataReader

            Dim Nivel As Integer, ZONA As String, ZONA2 As String
            Dim CVE_ZONA As Integer, TEXTO As String, TNODO As String
            Dim TEXTO2 As String, TEXTO3 As String
            cmd.connection = cnSAE
            cmd2.Connection = cnSAE
            cmd3.Connection = cnSAE

            Nivel = 1
            Fg.Rows.Count = 1

            SQL = "SELECT CVE_ZONA, CVE_PADRE, TEXTO, TNODO, CTA_CONT, IMPUEFLETE, MONTOFLETE, FORMULA, STATUS " &
                "FROM ZONA" & Empresa & " WHERE CVE_PADRE = 'RAIZ'"

            cmd.commandtext = SQL
            dr = cmd.executereader
            Do While dr.Read
                Application.DoEvents()

                ZONA = dr("CVE_ZONA")
                TEXTO = dr("TEXTO")
                TNODO = dr("TNODO")

                If IsNumeric(dr("CVE_ZONA").ToString.Trim) Then
                    CVE_ZONA = dr("CVE_ZONA").ToString.Trim
                Else
                    CVE_ZONA = 1
                End If

                If IsNumeric(dr("CVE_PADRE").ToString.Trim) Then
                    Nivel = dr("CVE_PADRE").ToString.Trim
                Else
                    Nivel = 1
                End If
                AddNodo(dr("TEXTO"), 0, dr("CVE_ZONA"), dr("TNODO"))

                SQL = "SELECT CVE_ZONA, CVE_PADRE, TEXTO, TNODO, CTA_CONT, IMPUEFLETE, MONTOFLETE, FORMULA, STATUS " &
                    "FROM ZONA" & Empresa & " WHERE CVE_PADRE = '" & ZONA & "'"

                cmd2.CommandText = SQL
                dr2 = cmd2.ExecuteReader
                Do While dr2.Read
                    Application.DoEvents()

                    TEXTO2 = dr2("TEXTO")
                    If IsNumeric(dr2("CVE_PADRE").ToString.Trim) Then
                        Nivel = dr2("CVE_PADRE").ToString.Trim
                    End If
                    If IsNumeric(dr2("CVE_ZONA").ToString.Trim) Then
                        CVE_ZONA = dr2("CVE_ZONA").ToString.Trim
                    End If
                    AddNodo(dr2("TEXTO"), Nivel, dr2("CVE_ZONA"), dr2("TNODO"))

                    ZONA2 = Space(6 - CVE_ZONA.ToString.Length) & CVE_ZONA.ToString

                    SQL = "SELECT CVE_ZONA, CVE_PADRE, TEXTO, TNODO, CTA_CONT, IMPUEFLETE, MONTOFLETE, FORMULA, STATUS " &
                        "FROM ZONA" & Empresa & " WHERE CVE_PADRE = '" & ZONA2 & "'"

                    cmd3.CommandText = SQL
                    dr3 = cmd3.ExecuteReader
                    Do While dr3.Read
                        Application.DoEvents()

                        TEXTO3 = dr3("TEXTO")

                        If IsNumeric(dr3("CVE_PADRE").ToString.Trim) Then
                            Nivel = dr3("CVE_PADRE").ToString.Trim
                        End If
                        AddNodo(dr3("TEXTO"), Nivel, dr3("CVE_ZONA"), dr3("TNODO"))
                    Loop
                    dr3.Close()
                Loop
                dr2.Close()
            Loop
            dr.Close()

        Catch ex As Exception
            msgbox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Dim TNODO As String
            'Fg(Row, 0) = fNODO
            'Fg(Row, 1) = fCVE_ZONA
            'Fg(Row, 2) = fTNODO

            TNODO = ""
            Var3 = ""
            Var2 = ""
            If Fg.Row > 0 Then
                TNODO = Fg(Fg.Row, 2)
                If TNODO <> "A" Then
                    Var2 = Fg(Fg.Row, 1)
                Else
                    Var2 = ""
                End If
                Var3 = Fg(Fg.Row, 0)
            End If
            Var1 = "Nuevo"
            Var4 = TNODO


            frmZonasAE.ShowDialog()

            DESPLEGAR()

        Catch ex As Exception
            msgbox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click

        Try

            If Fg.Row > 0 Then
                Dim TNODO As String

                TNODO = Fg(Fg.Row, 2)
                'CVE_ZONA = Var2
                'tNOMBRE.Text = Var3
                If TNODO <> "A" Then
                    Var1 = "Edit"
                    Var2 = Fg(Fg.Row, 1)
                    Var3 = Fg(Fg.Row, 0)
                    Var4 = Fg(Fg.Row, 2)

                    If TNODO = "C" Then
                        frmZonasAE.ShowDialog()
                    Else
                        frmZonaNodo.ShowDialog()
                    End If
                    DESPLEGAR()

                Else
                    MsgBox("Por favor seleccione un registro")
                End If
            End If

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
        
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE ZONA" & Empresa & " SET STATUS = 'B' WHERE CVE_PADRE = '" & Fg(Fg.Row, 1) & "'"
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
            End If
        Catch ex As Exception
            msgbox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()

    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click

        If Fg.Row > 0 Then
            Dim fg1 As String, fg2 As String, fg3 As String

            fg1 = Fg(Fg.Row, 0)
            fg2 = Fg(Fg.Row, 1)
            fg3 = Fg(Fg.Row, 2)

            If fg3 = "A" Then
                barNuevo.Enabled = True
                barEdit.Enabled = False
                barEliminar.Enabled = False
            End If
            If fg3 = "B" Then
                barNuevo.Enabled = False
                barEdit.Enabled = True
                barEliminar.Enabled = True
            End If
            If fg3 = "C" Then
                barNuevo.Enabled = True
                barEdit.Enabled = True
                barEliminar.Enabled = True
            End If
        End If
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick

        Try

            barEdit_Click(Nothing, Nothing)

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
End Class
