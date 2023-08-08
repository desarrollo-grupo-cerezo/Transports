Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmArticulosTOT
    Dim buttonList As New ArrayList()
    Private ENTRA As Boolean
    Private Sub frmArticulosTOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            CARGA_PARAM_INVENT()

            Fg.Rows.Count = 2

            For Each r As Row In Fg.Rows
                If r.Index > 0 Then
                    'Set row number
                    r(0) = r.Index
                    'Create Button
                    Dim bt As New Button
                    bt.BackColor = SystemColors.Control

                    bt.Image = My.Resources.lupa15

                    bt.Text = ""
                    bt.Tag = r.Index 'Tag it so the button knows which row it's on
                    AddHandler bt.Click, AddressOf btnSelArt_Click
                    buttonList.Add(New HostedControl(Fg, bt, r.Index, 5))
                End If
            Next
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                AFEC_TABLA_INVE = dr("AFE_TAB_INV")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmArticulosTOT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Friend Class HostedControl
        Friend _flex As C1FlexGrid
        Friend _ctl As Control
        Friend _row As Row
        Friend _col As Column
        Friend Sub New(ByVal flex As C1FlexGrid, ByVal hosted As Control, ByVal row As Integer, ByVal col As Integer)
            ' save info 
            _flex = flex
            _ctl = hosted
            _row = flex.Rows(row)
            _col = flex.Cols(col)
            ' insert hosted control into grid 
            _flex.Controls.Add(_ctl)
        End Sub
        Friend Function UpdatePosition() As Boolean
            ' get row/col indices 
            Dim r As Integer = _row.Index
            Dim c As Integer = _col.Index
            If r < 0 OrElse c < 0 Then
                Return False
            End If
            ' get cell rect 
            Dim rc As Rectangle = _flex.GetCellRect(r, c, False)
            ' hide control if out of range 
            If rc.Width <= 0 OrElse rc.Height <= 0 OrElse Not rc.IntersectsWith(_flex.ClientRectangle) Then
                _ctl.Visible = False
                Return True
            End If
            ' move the control and show it 
            _ctl.Bounds = rc
            _ctl.Visible = True
            ' done 
            Return True
        End Function
    End Class
    Private Sub btnSelArt_Click(sender As Object, e As EventArgs) Handles btnSelArt.Click
        Try
            If IsNothing(Fg(Fg.Row, 2)) Then
                MsgBox("La cantidad no debe quedar vacia")
                Fg.Col = 2
                Return
            End If
            If Fg(Fg.Row, 2).ToString.Trim.Length = 0 Then
                MsgBox("La cantidad no debe quedar vacia")
                Fg.Col = 2
                Return
            End If
            Var15 = "Busqueda"
            Var2 = "InveR"
            Var4 = ""
            Var5 = ""

            Fg.FinishEditing()

            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                Fg(Fg.Row, 4) = Var4
                Fg(Fg.Row, 6) = Var5
                LLENAR_GRID_ARTICULO(Var4)
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Col = 8
            Else
                Fg.Col = 1
            End If
        Catch ex As Exception
            Bitacora("327. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("327. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_GRID_ARTICULO(fCVE_ART As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ULT_COSTO As Single

            ULT_COSTO = 0
            cmd.Connection = cnSAE
            SQL = "SELECT DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE CVE_ART = '" & fCVE_ART & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                ULT_COSTO = dr("ULT_COSTO")
                Fg(Fg.Row, 6) = dr("DESCR")
                Fg(Fg.Row, 7) = dr("UNI_MED")
                Fg(Fg.Row, 9) = dr("IMPUESTO1") 'IEPS
                Fg(Fg.Row, 10) = dr("IMPUESTO2") 'IMPU2
                Fg(Fg.Row, 11) = dr("IMPUESTO3") 'IMPU4
                Fg(Fg.Row, 12) = dr("IMPUESTO4") 'IVA
                If Fg(Fg.Row, 15) <> fCVE_ART Then
                    Fg(Fg.Row, 13) = ULT_COSTO 'COSTO
                End If
                Fg(Fg.Row, 14) = Fg(Fg.Row, 2) * Fg(Fg.Row, 13)
                Fg(Fg.Row, 15) = fCVE_ART
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("408. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("408. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            Select Case e.Col
                Case 1, 2, 3, 4, 8, 13
                Case Else
                    e.Cancel = True
            End Select
        Catch ex As Exception
            Bitacora("307. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("307. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Try
            Dim sStyleName As String
            sStyleName = "RowStyle"
            Dim cs As C1.Win.C1FlexGrid.CellStyle = Fg.Styles.Add(sStyleName)
            '-- Set Italics On or Off
            'cs.Font = New Font("Tahoma", 12, FontStyle.Italic)
            cs.Font = New Font(ChrW(23655) & ChrW(23765), 12, FontStyle.Regular, GraphicsUnit.Point, 134)

            Dim rg As C1.Win.C1FlexGrid.CellRange = Fg.GetCellRange(1, 1, 8, Fg.Cols.Count - 1)

            rg.Style = Fg.Styles(sStyleName)
            e.Handled = True
        Catch ex As Exception
            Bitacora("301. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("301. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_Paint(sender As Object, e As PaintEventArgs) Handles Fg.Paint
        For Each hosted As HostedControl In buttonList
            hosted.UpdatePosition()
        Next
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If tPROV.Text.Trim.Length = 0 Then
                'tPROV.Focus()
                'Return
            End If

            If Fg.Row > 0 And ENTRA Then

                Select Case Fg.Col
                    Case 1, 2, 3, 4, 8
                        Fg.StartEditing()
                    Case 13
                        Fg.StartEditing()
                        Fg.Col = 13
                    Case Else
                End Select
            End If
        Catch ex As Exception
            Bitacora("302. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("302. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If e.KeyCode = Keys.F2 Then
                btnSelArt_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Select Case e.Col
                    Case 2 'cantidad

                    Case 3 'ALMACEN
                        ENTRA = False
                        Fg.Col = 4
                        Fg.StartEditing()
                        ENTRA = True
                        Return
                    Case 4 'ARTICULO
                        ENTRA = False
                        Fg.Col = 7
                        Fg.StartEditing()
                        ENTRA = True
                        Return
                    Case 8 'DESC
                        ENTRA = False
                        Fg.Col = 12
                        Fg.StartEditing()
                        ENTRA = True
                        Return
                    Case 13 'COSTO
                        Fg.Row = Fg.Row + 1
                        Fg.Col = 1
                        Fg.StartEditing()
                        Return
                End Select
            End If
        Catch ex As Exception
            Bitacora("317. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("317. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If Fg.Row > 0 Then
                Select Case Fg.Col
                    Case 2 'CANTIDAD
                        If Fg.Editor.Text.Trim.Length > 0 Then
                            Try
                                Fg(Fg.Row, 14) = Fg(Fg.Row, 2) * Fg(Fg.Row, 13)
                            Catch ex As Exception
                                Bitacora("337. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("337. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Return
                        End If
                    Case 4 'PRUDUCTO
                        If Fg.Editor.Text.Trim.Length > 0 Then
                            LLENAR_GRID_ARTICULO(Fg.Editor.Text)
                        End If
                    Case 8
                        If Fg.Row > 0 Then
                            Fg(Fg.Row, 14) = ROW_CALC(Fg.Row, Val(Fg(Fg.Row, 2)), Val(Fg(Fg.Row, 13)), Val(Fg.Editor.Text))
                        End If
                    Case 13
                        If Fg.Editor.Text.Trim.Length > 0 Then
                            If IsNumeric(Fg.Editor.Text) Then
                                'Fg(Fg.Row, 14) = Fg(Fg.Row, 2) * Fg.Editor.Text
                                Fg(Fg.Row, 14) = ROW_CALC(Fg.Row, Val(Fg(Fg.Row, 2)), Fg.Editor.Text, Val(Fg(Fg.Row, 8)))
                            End If
                        End If
                End Select
            End If
        Catch ex As Exception
            Bitacora("347. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("347. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function ROW_CALC(fRow As Integer, fCant As Single, fPrecio As Single, fDesc As Single)
        Try
            Dim CALCULO As Single

            CALCULO = (fCant * fPrecio) - (fCant * fPrecio * fDesc / 100)
            Return CALCULO
        Catch ex As Exception
            Bitacora("348. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("348. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function

    Private Sub txt_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt.PreviewKeyDown

        'If tPROV.Text.Trim.Length = 0 Then
        'MsgBox("Por favor capture la clave del cliente")
        'tPROV.Select()
        'Return
        'End If

        If e.KeyCode = 9 Then
            If Fg.Row > 0 Then
                If Fg.Col = 2 Then
                    Try
                        Fg(Fg.Row, 14) = Fg(Fg.Row, 2) * Fg(Fg.Row, 13)
                    Catch ex As Exception
                        Bitacora("337. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("337. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Return
                End If
                If Fg.Col = 4 Then
                    Fg.Col = 8
                    Fg.StartEditing()
                    Return
                End If
                If Fg.Col = 8 Then
                    Fg.Col = 13
                    Fg.StartEditing()
                    Return
                End If
                If Fg.Col = 13 Then
                    Fg.Row = Fg.Row + 1
                    Fg.Col = 2
                    Fg.StartEditing()
                    Return
                End If
            End If
        End If
    End Sub
    Private Sub Fg_StartEdit(sender As Object, e As RowColEventArgs) Handles Fg.StartEdit
        Try
            If e.Row > 0 Then
                If e.Col = 2 Then
                    If Fg(e.Row, 2) = 0 Then
                        Fg(e.Row, 2) = 1
                    End If
                End If
                If e.Col = 8 Then
                    If Not IsNothing(Fg(e.Row, 8)) Then
                        If Fg(e.Row, 8).ToString.Length = 0 Then
                            Fg(e.Row, 8) = "0"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("412. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("412. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click

    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click

    End Sub
End Class
