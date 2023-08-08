Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmEnlazarComprasNuevo
    Dim _myEditor As MyEditorEnlaceCompra
    Dim TIPO_COMPRA As String
    Dim ENTRA As Boolean
    Private Sub FrmEnlazarComprasNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            ReDim aDOCS(-1)
            TIPO_COMPRA = Var10
            tCLAVE.Tag = Var10

            Select Case Var10
                Case "O"
                    Lt1.Text = "Orden de compra"
                Case "R"
                    Lt1.Text = "Recepción"
                Case "Q"
                    Lt1.Text = "Requisición"
                Case "D"
                    Lt1.Text = "Devolucion"
            End Select
            ENTRA = True
            Fg.Rows.Count = 2
            Fg.Rows(0).Height = 30
            Fg.Cols(2).ComboList = "..."
            Fg.Cols(2).Width = 18
            Var11 = ""
            _myEditor = New MyEditorEnlaceCompra(Fg, 10)

            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(1, 1)
            End If
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmEnlazarComprasNuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarEnlazar_Click(sender As Object, e As EventArgs) Handles barEnlazar.Click
        Dim z As Integer = 0
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Not IsNothing(Fg(k, 1)) Then
                    If Fg(k, 1).ToString.Trim.Length > 0 Then
                        z = z + 1
                    End If
                End If
            Next
            ReDim Preserve aDOCS(z - 1)
            z = 0
            For k = 1 To Fg.Rows.Count - 1
                If Not IsNothing(Fg(k, 1)) Then
                    If Fg(k, 1).ToString.Trim.Length > 0 Then
                        Try
                            aDOCS(z) = Fg(k, 1)
                            z = z + 1
                        Catch ex As Exception
                            Bitacora("355. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
            Next
            If z = 0 Then
                MsgBox("Por favor seleccione al menos un documento")
                ReDim Preserve aDOCS(-1)
            Else
                Me.Close()
            End If
        Catch ex As Exception
            Bitacora("357. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("357. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg.Row > 0 Then
                Fg.RemoveItem(Fg.Row)
            Else
                MsgBox("Por favor seleccione el renglon a eliminar aeliminar")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCLAVE.Text = Var4
                Var11 = Var4
                LtNombre.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""

                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(1, 1)
                End If
            End If
        Catch ex As Exception
            Bitacora("357. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("357. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLAVE_Validated(sender As Object, e As EventArgs) Handles tCLAVE.Validated
        Try
            If tCLAVE.Text.Trim.Length > 0 Then
                Var5 = ""
                Dim DESCR As String
                DESCR = tCLAVE.Text.Trim
                If IsNumeric(DESCR) Then
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    tCLAVE.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Prov", tCLAVE.Text)
                If DESCR <> "" Then
                    Var11 = tCLAVE.Text
                    LtNombre.Text = DESCR
                Else
                    MsgBox("Proveedor inexistente")
                    tCLAVE.Text = ""
                    LtNombre.Text = ""
                    tCLAVE.Focus()
                    tCLAVE.SelectAll()
                End If
            End If
        Catch ex As Exception
            Bitacora("387. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("387. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLAVE_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLAVE.KeyDown
        If e.KeyCode = 13 Then
            Fg.Select()

            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, Fg.Col)
            End If
        End If
        If e.KeyCode = Keys.F2 Then
            BtnProv_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TMagico2_GotFocus(sender As Object, e As EventArgs) Handles tMagico2.GotFocus
        Try
            Fg.Select()
            Fg.Focus()

            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, Fg.Col)
            End If
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        If Fg.Col = 1 And ENTRA Then
            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, Fg.Col)
            End If
            'cancel built -in editor
        End If
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 Then

                    If Not IsNothing(_myEditor) Then
                        _myEditor.StartEditing(Fg.Row, Fg.Col)
                    End If

                End If
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_StartEdit(sender As Object, e As RowColEventArgs) Handles Fg.StartEdit
        Try
            If e.Col = 1 Then
                e.Cancel = True
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_AfterScroll(sender As Object, e As RangeEventArgs) Handles Fg.AfterScroll
        If _myEditor.Visible Then
            _myEditor.UpdatePosition()
        End If
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        _myEditor.SetPendingKey(e.KeyChar)
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If e.Col = 1 Or e.Col = 2 Then
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub EnlaceDoc()
        Try
            barEnlazar_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCLAVE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCLAVE.PreviewKeyDown
        If e.KeyCode = 9 Then
            Fg.Select()

            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, Fg.Col)
            End If
        End If
    End Sub

    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            Var11 = tCLAVE.Text 'CLIENTE
            Var15 = TIPO_COMPRA
            Var2 = "COMP" : Var6 = "" : Var9 = ""
            Var4 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1) 'CVE_DOC
                'Var5 = Fg(Fg.Row, 2) 'CLAVE
                'Var6 = Fg(Fg.Row, 3) 'NOMBRE
                'Var7 = Fg(Fg.Row, 4) 'FECHA
                'Var8 = Fg(Fg.Row, 5) 'IMPORTE
                'Var9 = Fg(Fg.Row, 6) 'doc sig
                'Var10 = Fg(Fg.Row, 7) 'tip doc sig
                Dim ExistDoc As Boolean = False

                For k = 1 To Fg.Rows.Count - 1
                    If k <> Fg.Row Then
                        If Fg(k, 1) = Var4 Then
                            ExistDoc = True
                        End If
                    End If
                Next
                If ExistDoc Then
                    MsgBox("1. EL documento ya se encuentra agregado")
                    MyBase.Text = ""
                    'Fg(Fg.Row, 1) = ""
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 1
                    Fg.StartEditing()
                    Return
                End If
                Fg(Fg.Row, 1) = Var4
                Fg(Fg.Row, 3) = Var5
                Fg(Fg.Row, 4) = Var6
                Fg(Fg.Row, 5) = Var7
                Fg(Fg.Row, 6) = Var8
                Fg(Fg.Row, 7) = Var9
                Fg(Fg.Row, 8) = Var10
                Try
                    If Fg(Fg.Rows.Count - 1, 1).ToString.Length <> 0 Then
                        '                         CVE_DOC       SEL        CLIENTE       NOMBRE      DOC_SIG      IMPORTE
                        '                            1            2           3            4            5            6 
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                    End If
                Catch ex As Exception
                End Try
                Fg.Select(Fg.Row + 1, 1)

                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, Fg.Col)
                End If
            End If
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class

'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditorEnlaceCompra
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid, MyImporte As Single)
        MyBase.New()
        Visible = False
        AutoSize = False
        BackColor = Color.Beige
        BorderStyle = BorderStyle.FixedSingle

        _pendingKey = Chr(0)
        _cancel = False
        _owner = owner
        _owner.Controls.Add(Me)
    End Sub
    'comenzar a editar: mover a la celda y activar
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        'save coordinates of cell being edited
        'guardar las coordenadas de la celda que se está editando
        If col = 1 And keyRec = 9 Then
            If IsNothing(_owner(_row, 2)) Then
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        If col = 1 Then
            _row = row
            _col = col
            'assume we'll save the edits
            'supongamos que guardaremos las ediciones
            _cancel = False
            'move editor over the current cell
            'mover editor sobre la celda actual
            Dim rc As Rectangle = _owner.GetCellRect(row, col, True)
            rc.Width = rc.Width - 1
            rc.Height = rc.Height - 1

            MyBase.Bounds = rc
            'initialize control content
            'inicializar contenido de control
            MyBase.Text = ""
            If _pendingKey > " " Then
                MyBase.Text = _pendingKey.ToString()
            ElseIf Not _owner(row, col) Is Nothing Then
                MyBase.Text = _owner(row, col).ToString()
            End If
            MyBase.Select(Text.Length, 0)
            'make editor visible
            MyBase.Visible = True
            'and get the focus
            MyBase.Select()
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = MyBase.TextLength
        End If

    End Sub
    Public Sub EndEdit(ByVal row As Integer, ByVal col As Integer)
        Try
            _owner.FinishEditing()
            _owner(row, col) = ""
            MyBase.Text = ""
        Catch ex As Exception
            Bitacora("390. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("390. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)
        If col = 1 Then
            MyBase.Visible = True
        End If
    End Sub
    'guardar clave que inició el modo de edición
    Public Sub SetPendingKey(ByVal chr As Char)
        _pendingKey = chr
    End Sub

    'move editor after the grid has scrolled
    'mover editor después de que la cuadrícula se haya desplazado
    Public Sub UpdatePosition()
        'get cell rect now
        'obtener celular ahora
        Dim rcCell As Rectangle = _owner.GetCellRect(_row, _col, False)

        'intersect with scrollable part of the grid
        'intersectarse con parte desplazable de la cuadrícula
        Dim rcScroll As Rectangle = _owner.ClientRectangle
        rcScroll.X = _owner.Cols(_owner.Cols.Fixed).Left
        rcScroll.Y = _owner.Rows(_owner.Rows.Fixed).Top
        rcScroll.Width = rcScroll.Width - rcScroll.X
        rcScroll.Height = rcScroll.Height - rcScroll.Y
        rcCell = Rectangle.Intersect(rcCell, rcScroll)

        'y mueve el control
        If (rcCell.Width > 0) Then rcCell.Width = rcCell.Width - 1
        If (rcCell.Height > 0) Then rcCell.Height = rcCell.Height - 1
        MyBase.Bounds = rcCell
    End Sub

    'Foco perdido: ocultar el editor
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        Try
            If _col = 1 And MyBase.Text.Trim.Length > 0 Then 'DOCUMENTO
                Try
                    Dim Descr As String = ""

                    For k = 1 To _owner.Rows.Count - 1
                        If k <> _owner.Row Then
                            If _owner(k, 1) = MyBase.Text Then
                                Descr = "99"
                                Exit For
                            End If
                        End If
                    Next
                    If Descr = "99" Then
                        MsgBox("2. Documento ya agregado")
                        MyBase.Text = ""
                        _owner(_row, 1) = ""
                        Return
                    End If
                    Descr = ""

                    If frmEnlazarComprasNuevo.tCLAVE.Tag = "" Then
                        Var15 = "O"
                    Else
                        Var15 = frmEnlazarComprasNuevo.tCLAVE.Tag
                    End If
                    Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = "" : Var9 = "" : Var10 = "" : Var22 = 0
                    Descr = BUSCA_CAT("COMP", MyBase.Text)
                    If Descr.TrimEnd.Trim.Length > 0 Then
                        _owner(_row, 1) = Var4
                        _owner(_row, 3) = Var5
                        _owner(_row, 4) = Var6
                        _owner(_row, 5) = Var7
                        _owner(_row, 6) = Var8
                        _owner(_row, 7) = Var9
                        _owner(_row, 8) = Var10
                    Else
                        MsgBox("1. Documento inexistente")
                        MyBase.Text = ""
                        Return
                    End If
                Catch ex As Exception
                    Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                If _owner.Rows.Count - 1 <> _owner.Row Then
                    If MyBase.Text = "" Then
                        Try
                            _owner.RemoveItem(_owner.Row)
                        Catch ex As Exception
                        End Try
                        _owner.Row = _owner.Rows.Count - 1
                    End If
                End If
            End If
            'procesamiento base
            MyBase.OnLeave(e)

            'copiar texto a la cuadrícula del propietario
            If Not _cancel Then
                _owner(_row, _col) = MyBase.Text
            End If

            'no más claves pendientes
            _pendingKey = Chr(0)

            'hecho por ahora, ocultar editor
            MyBase.Visible = False
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub
    'manejaremos la tecla de tabulación nosotros mismos
    Protected Overrides Function IsInputkey(ByVal keydata As Keys) As Boolean
        If keydata = Keys.Tab Or keydata = Keys.Enter Then
            Return True
        End If
        Return MyBase.IsInputKey(keydata)
    End Function

    'algunas teclas finalizan la edición
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Escape
                _cancel = True
                _owner.Select()
                e.Handled = True
            Case Keys.Enter, Keys.Tab, Keys.Up, Keys.Down, Keys.PageUp, Keys.PageDown, Keys.Left, Keys.Right

                Select Case _col
                    Case 1
                        If e.KeyCode = 13 Or e.KeyCode = 9 Then
                        End If
                End Select

                '_owner.Select()
                'e.Handled = True

                MoveCursor(e.KeyCode)
            Case Keys.F2
                If _col = 1 Then
                    Try                    'ARTICULOS

                        Var15 = frmEnlazarComprasNuevo.tCLAVE.Tag
                        Var2 = "COMP" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            'Var4 = Fg(Fg.Row, 1) 'CVE_DOC
                            'Var5 = Fg(Fg.Row, 2) 'CLAVE
                            'Var6 = Fg(Fg.Row, 3) 'NOMBRE
                            'Var7 = Fg(Fg.Row, 4) 'FECHA
                            'Var8 = Fg(Fg.Row, 5) 'IMPORTE
                            'Var9 = Fg(Fg.Row, 6) 'doc sig
                            'Var10 = Fg(Fg.Row, 7) 'tip doc sig
                            Dim ExistDoc As Boolean = False

                            For k = 1 To _owner.Rows.Count - 1
                                If _owner(k, 1) = Var4 Then
                                    ExistDoc = True
                                End If
                            Next
                            If ExistDoc Then
                                MsgBox("3. EL documento ya se encuentra agregado")
                                Return
                            End If

                            _owner(_row, 1) = Var4
                            _owner(_row, 3) = Var5
                            _owner(_row, 4) = Var6
                            _owner(_row, 5) = Var7
                            _owner(_row, 6) = Var8
                            _owner(_row, 7) = Var9
                            _owner(_row, 8) = Var10
                            '                         CVE_DOC       SEL        CLIENTE       NOMBRE      DOC_SIG      IMPORTE
                            '                            1            2           3            4            5            6 
                            _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                            _owner.Select(_row + 1, 1)
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("402. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("402. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
            Case Keys.F3
                frmEnlaceVentas.EnlaceDoc()
            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub

    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col

        If col = 1 And key = Keys.Left Then
            frmEnlaceVentas.tMagico2.Focus()
            Return
        End If

        Select Case key
            Case Keys.Tab, Keys.Enter
                Select Case col
                    Case 1
                        If _owner.Rows.Count - 1 = row Then
                            If IsNothing(_owner(_row, 1)) Then
                                frmEnlaceVentas.tMagico2.Focus()
                            Else
                                If _owner(_row, 1).ToString.Trim.Length = 0 Then

                                Else
                                    '                         CVE_DOC       SEL        CLIENTE       NOMBRE      DOC_SIG      IMPORTE
                                    '                            1            2           3            4            5            6 
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                                    row = row + 1
                                    _owner.Select()
                                    _owner.Select(row, col)
                                    _owner.StartEditing()
                                End If
                            End If
                        Else
                            row = row + 1
                        End If
                End Select
            Case Keys.Up
                If _owner.Row = 1 Then
                    frmEnlaceVentas.tMagico2.Focus()
                    Return
                End If
                If IsNothing(_owner(_row, 1)) Then
                    _owner.RemoveItem(_owner.Row)
                    Return
                End If

                If row > 1 Then
                    row = row - 1
                Else
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                End If
            Case Keys.Down
                If _owner.Rows.Count - 1 = row Then
                    Select Case col
                        Case 1
                            If IsNothing(_owner(_row, 1)) Then
                                frmEnlaceVentas.tMagico2.Focus()
                            Else
                                If _owner(_row, 1).ToString.Trim.Length = 0 Then
                                    Return
                                Else
                                    '                         CVE_DOC       SEL        CLIENTE       NOMBRE      DOC_SIG      IMPORTE
                                    '                            1            2           3            4            5            6 
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                                    _owner.Select(row + 1, 1)
                                End If

                            End If
                    End Select
                    Return
                Else
                    row = row + 1
                End If
            Case Keys.PageUp
                row -= 10
            Case Keys.PageUp
                row += 10
            Case Keys.Left
                If col > 1 Then
                    Select Case col
                        Case 1
                            If IsNothing(_owner(_row, 1)) Then
                                _owner.RemoveItem(_owner.Row)
                                Return
                            Else
                                If _owner(_row, 1).ToString.Length = 0 Then
                                    If _owner.Rows.Count - 1 <> 1 Then
                                        _owner.RemoveItem(_owner.Row)
                                    End If
                                    Return
                                End If
                            End If
                            If row = 1 Then
                                row = _owner.Rows.Count - 1
                            Else
                                row = row - 1
                            End If
                            col = 1
                    End Select
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
                Return
            Case Keys.Right
                If col <= 2 Then
                    Select Case col
                        Case 1                            'CORREGIR AQUI
                            If IsNothing(_owner(_row, 1)) Then
                                frmEnlaceVentas.tMagico2.Focus()
                                Return
                            End If
                            If MyBase.Text.ToString.Trim.Length = 0 Then
                                frmEnlaceVentas.tMagico2.Focus()
                                Return
                            End If
                    End Select
                Else
                    col = 1
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
        End Select

        'validar nueva selección
        If (row < _owner.Rows.Fixed) Then row = _owner.Rows.Fixed
        If (col < _owner.Cols.Fixed) Then col = _owner.Cols.Fixed
        If (row > _owner.Rows.Count - 1) Then row = _owner.Rows.Count - 1
        If (col > _owner.Cols.Count - 1) Then col = _owner.Cols.Count - 1

        'aplicar nueva selección        7
        _owner.Select(row, col)

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        Dim HayErr As Boolean

        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)

                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 1
                            Dim Descr As String
                            If MyBase.Text.Trim.Length = 0 Then
                                frmEnlaceVentas.tMagico2.Focus()
                                Return
                            End If
                            Descr = ""
                            For k = 1 To _owner.Rows.Count - 1
                                If k <> row Then
                                    If _owner(k, 1) = MyBase.Text Then
                                        Descr = "99"
                                        Exit For
                                    End If
                                End If
                            Next
                            If Descr = "99" Then
                                MsgBox("4. Documento ya agregado")
                                _owner(_row, 1) = ""
                                frmEnlaceVentas.tMagico2.Focus()
                                Return
                            End If
                            Descr = ""
                            Var9 = "" : Var22 = 0
                            Var4 = ""
                            Descr = MyBase.Text
                            If IsNumeric(Descr.Trim) Then
                                Descr = Space(10) & Format(Val(Descr.Trim), "0000000000")
                            End If
                            Var15 = ""


                            Var11 = Descr
                            Descr = BUSCA_CAT("COMP", Descr)
                            If Descr = "N" Then
                                MsgBox("2. Documento inexistente")
                                frmEnlaceVentas.tMagico2.Focus()

                                MyBase.Text = ""
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            Else
                                If Descr.TrimEnd.Trim.Length = 0 Then
                                    MsgBox("2. Documento inexistente")
                                    frmEnlaceVentas.tMagico2.Focus()

                                    MyBase.Text = ""
                                    _owner.Select(_row, _col)
                                    _owner(_row, _col) = ""
                                    _owner.StartEditing()
                                    Return
                                Else
                                    _owner(_row, 1) = Var4
                                    _owner(_row, 3) = Var5
                                    _owner(_row, 4) = Var6
                                    _owner(_row, 5) = Var7
                                    _owner(_row, 6) = Var8
                                    _owner(_row, 7) = Var9
                                    _owner(_row, 8) = Var10
                                    If _owner.Rows.Count - 1 = _row Then
                                        '                         CVE_DOC       SEL        CLIENTE       NOMBRE      DOC_SIG      IMPORTE
                                        '                            1            2           3            4            5            6 
                                        _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                                        _owner.Select(_row + 1, 1)
                                    End If
                                    frmEnlaceVentas.tMagico2.Focus()
                                    Return
                                End If
                            End If
                            If ExistDoc(Descr) And Descr <> "N" Then
                                MsgBox("5. El documento ya fue agregado")
                                MyBase.Text = ""
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            Else
                                Descr = ""
                            End If

                            HayErr = False
                            Try
                                _owner.Select(row + 1, 1)
                            Catch ex As Exception
                                HayErr = True
                            End Try
                            If HayErr Then
                                '                         CVE_DOC       SEL        CLIENTE       NOMBRE      DOC_SIG      IMPORTE
                                '                            1            2           3            4            5            6 
                                _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                                _owner.Select(row + 1, 1)
                            Else
                            End If
                    End Select
                    _owner.StartEditing()
                    Return
                Case Else

            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            Bitacora("406. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("406. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function ExistDoc(fCVE_DOC As String) As Boolean
        Try
            Dim ExisDoc As Boolean = False

            For K = 1 To _owner.Rows.Count - 1
                If K <> _owner.Row Then
                    If _owner(K, 1) = fCVE_DOC Then
                        ExisDoc = True
                    End If
                End If
            Next
            Return ExisDoc
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
End Class

