Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmApliPagoConciCartaPorte
    Dim _myEditor As MyEditor
    Dim buttonList As New ArrayList()
    Dim IMPORTE_REAL As Single
    Dim CLIENTE As String



    Private Sub FrmApliPagoConciCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        Try
            Fg.Rows.Count = 250
            For k = 1 To Fg.Cols.Count - 1
                Fg(0, k) = Fg(0, k) & " " & k
            Next

            CLIENTE = Var10
            tCVE_CLIE.Text = Var10
            Var16 = Var10
            L3.Text = Var11
            tSUBTOTAL.Text = Format(Var21, "###,###,##0.00")
            tSALDO.Text = Format(Var21, "###,###,##0.00")
            IMPORTE_REAL = Var21

            _myEditor = New MyEditor(Fg, Var21)

            Fg.Select(1, 1)
            Fg.StartEditing()
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmApliPagoConciCartaPorte_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub
    Private Sub FrmApliPagoConciCartaPorte_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click

        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_BITA As Long
        Dim TIPO_MOV As String
        Dim SIGNO As Integer
        Dim CVE_AUT As Integer
        Dim USUARIO2 As Integer
        Dim NO_PARTIDA As Integer
        Dim NUM_CARGO As Integer
        Dim ID_MOV As Integer
        Dim CVE_FOLIO As String
        Dim CVE_OBS As Long
        Dim NO_FACTURA As String
        Dim CON_REFER As String
        Dim SIGNO_CADENA As String

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        CVE_BITA = 0 : TIPO_MOV = "" : SIGNO = 1 : CVE_AUT = 0 : USUARIO2 = 0 : NO_PARTIDA = 1 : ID_MOV = 1 : CVE_FOLIO = "" : CVE_OBS = 0 : NO_FACTURA = ""
        TIPO_MOV = "A" : SIGNO = -1 : CON_REFER = "" : SIGNO_CADENA = "" : NUM_CARGO = 1

        Var15 = "NO"
        SQL = "INSERT INTO CUEN_DET" & Empresa & " (CVE_CLIE, REFER, NUM_CPTO, NUM_CARGO, ID_MOV, CVE_FOLIO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, FECHA_APLI, " &
             "FECHA_VENC, NUM_MONED, TCAMBIO, IMPMON_EXT, TIPO_MOV, SIGNO, USUARIO, FECHAELAB, CTLPOL, UUID, VERSION_SINC, NO_PARTIDA) VALUES (@CVE_CLIE, " &
             "@REFER, @NUM_CPTO, @NUM_CARGO, @ID_MOV, @CVE_FOLIO, @CVE_OBS, @NO_FACTURA, @DOCTO, @IMPORTE, @FECHA_APLI, @FECHA_VENC, @NUM_MONED, @TCAMBIO, " &
             "@IMPMON_EXT, @TIPO_MOV, @SIGNO, @USUARIO, GETDATE(), '0', NEWID(), GETDATE(), " &
             "ISNULL((SELECT ISNULL(MAX(NO_PARTIDA),0) + 1 FROM CUEN_DET" & Empresa & " WHERE REFER = @REFER AND CVE_CLIE = @CVE_CLIE), 1))"

        For k = 1 To Fg.Rows.Count - 1

            If Not IsNothing(Fg(k, 1)) And Not IsNothing(Fg(k, 3)) And Not IsNothing(Fg(k, 7)) Then
                If Not String.IsNullOrEmpty(Fg(k, 1)) And Not String.IsNullOrEmpty(Fg(k, 3)) And Not String.IsNullOrEmpty(Fg(k, 7)) Then
                    If Fg(k, 1).ToString.Trim.Length > 0 And Fg(k, 3).ToString.Trim.Length > 0 And Fg(k, 7).ToString.Trim.Length > 0 Then
                        If CSng(Fg(k, 7)) > 0 Then
                            Try

                                Try
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = "SELECT * FROM CONC" & Empresa & " WHERE NUM_CPTO = " & CONVERTIR_TO_INT(Fg(k, 3))
                                        Using dr As SqlDataReader = cmd2.ExecuteReader
                                            If dr.Read Then
                                                CON_REFER = dr("CON_REFER")
                                                SIGNO = dr("SIGNO")
                                                If SIGNO = -1 Then
                                                    SIGNO_CADENA = " - "
                                                Else
                                                    SIGNO_CADENA = " + "
                                                End If
                                                TIPO_MOV = dr("TIPO")
                                            End If
                                        End Using
                                    End Using
                                Catch ex As Exception
                                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                cmd.CommandText = SQL
                                cmd.Parameters.Add("@CVE_CLIE", SqlDbType.VarChar).Value = tCVE_CLIE.Text
                                cmd.Parameters.Add("@REFER", SqlDbType.VarChar).Value = Fg(k, 1)
                                cmd.Parameters.Add("@NUM_CPTO", SqlDbType.Int).Value = CONVERTIR_TO_INT(Fg(k, 3))
                                cmd.Parameters.Add("@NUM_CARGO", SqlDbType.Int).Value = NUM_CARGO
                                cmd.Parameters.Add("@ID_MOV", SqlDbType.Int).Value = Fg(k, 12)
                                cmd.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = CVE_FOLIO
                                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                                cmd.Parameters.Add("@NO_FACTURA", SqlDbType.VarChar).Value = Fg(k, 1)
                                cmd.Parameters.Add("@DOCTO", SqlDbType.VarChar).Value = Fg(k, 6)
                                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 7))
                                cmd.Parameters.Add("@FECHA_APLI", SqlDbType.DateTime).Value = F1.Value
                                cmd.Parameters.Add("@FECHA_VENC", SqlDbType.DateTime).Value = F1.Value
                                cmd.Parameters.Add("@NUM_MONED", SqlDbType.Int).Value = 1
                                cmd.Parameters.Add("@TCAMBIO", SqlDbType.Float).Value = 1
                                cmd.Parameters.Add("@IMPMON_EXT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 7))
                                cmd.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = TIPO_MOV
                                cmd.Parameters.Add("@SIGNO", SqlDbType.Int).Value = SIGNO
                                cmd.Parameters.Add("@USUARIO", SqlDbType.SmallInt).Value = USUARIO2
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        Var15 = "SI"
                                        Try
                                            UPDATE_DATOS_CLIE(Fg(k, 7), Fg(k, 1), tCVE_CLIE.Text, SIGNO_CADENA)
                                        Catch ex As Exception
                                            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                End If
            End If
        Next
        Me.Close()

    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        If Fg.Row > 0 Then
            If Fg.Col = 2 Then
                'DOCUMENTO ClieDocSaldos
                Try
                    If IsNumeric(tSALDO.Text.Replace(",", "")) Then
                        If CSng(tSALDO.Text) <= 0 Then
                            MsgBox("El pago ya fue aplicado en su totalidad")
                            Fg(Fg.Row, 1) = ""
                            Return
                        End If
                    End If
                    Var2 = "ClieDocSaldos"
                    Var4 = "" : Var5 = ""
                    Var10 = " AND CVE_CLIE = '" & tCVE_CLIE.Text & "' "
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        Dim ExistDoc As Boolean
                        ExistDoc = False
                        Try
                            For k = 1 To Fg.Rows.Count - 1
                                If Not IsNothing(Fg(k, 1)) Then
                                    If Not String.IsNullOrEmpty(Fg(k, 1)) Then
                                        If Fg(k, 1) = Var4 Then
                                            ExistDoc = True
                                            Exit For
                                        End If
                                    End If
                                End If
                            Next
                            If ExistDoc Then
                                MsgBox("1. El documento ya fue agregado")
                                Fg(Fg.Row, 1) = ""
                                Return
                            End If
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Fg(Fg.Row, 1) = Var4
                        Var9 = CSng(tSUBTOTAL.Text.Replace(",", ""))
                        Dim IMPORT As Single
                        IMPORT = Var9 - SUMA_ABONOS()
                        Fg(Fg.Row, 1) = Var4
                        If Var9 > IMPORT Then
                            Fg(Fg.Row, 7) = IMPORT 'ABONO
                            Fg(Fg.Row, 8) = IMPORT 'SALDO
                            Fg(Fg.Row, 9) = Var9 'IMPORTE DOC
                            Fg(Fg.Row, 10) = IMPORT 'IMPORTE REAL
                            Fg(Fg.Row, 12) = Var6 'NUM_CPTO  es ID_MPOV DE CUEN_DET
                        Else
                            Fg(Fg.Row, 7) = Var9 'ABONO
                            Fg(Fg.Row, 8) = Var9 'SALDO
                            Fg(Fg.Row, 9) = Var9 'IMPORTE DOC
                            Fg(Fg.Row, 10) = Var9 'IMPORTE REAL
                            Fg(Fg.Row, 12) = Var6 'NUM_CPTO  es ID_MPOV DE CUEN_DET
                        End If
                        Var2 = "" : Var4 = "" : Var5 = ""
                        Fg.Col = 3
                    Else
                        Fg(Fg.Row, 3) = ""
                        Fg(Fg.Row, 5) = ""
                        Fg(Fg.Row, 7) = "" 'ABONO
                        Fg(Fg.Row, 8) = "" 'SALDO
                        Fg(Fg.Row, 9) = "" 'IMPORTE DOC
                        Fg(Fg.Row, 10) = "" 'IMPORTE REAL
                        Fg(Fg.Row, 12) = "" 'NUM_CPTO  es ID_MPOV DE CUEN_DET
                        Fg.Col = 1
                    End If
                Catch Ex As Exception
                    Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
                End Try
            End If
            If Fg.Col = 4 Then  'CONCEPTO
                Try
                    Var2 = "ConcCxC"
                    Var4 = "" : Var5 = ""
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        Fg(Fg.Row, 3) = Var4
                        Fg(Fg.Row, 5) = Var5
                        Var2 = "" : Var4 = "" : Var5 = ""
                        Fg.Col = 6
                    End If
                Catch Ex As Exception
                    Bitacora("130. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    MsgBox("130. " & Ex.Message & vbNewLine & Ex.StackTrace)
                End Try
            End If
        End If
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, Fg.Col)
                _myEditor.EnterCell(Fg.Row, Fg.Col)
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If e.Col = 1 Or e.Col = 2 Or e.Col = 3 Or e.Col = 4 Or e.Col = 6 Or e.Col = 7 Then
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_StartEdit(sender As Object, e As RowColEventArgs) Handles Fg.StartEdit
        Try
            If e.Col = 1 Or e.Col = 2 Or e.Col = 3 Or e.Col = 6 Or e.Col = 7 Then
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(e.Row, e.Col)
                End If
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

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        If Not IsNothing(_myEditor) Then
            _myEditor.StartEditing(Fg.Row, Fg.Col)
        End If
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
    End Sub
    Private Sub Fg_Validated(sender As Object, e As EventArgs) Handles Fg.Validated
        Dim IMPORTE As Single
        IMPORTE = 0

        Try
            For k = 1 To Fg.Rows.Count - 1
                If Not IsNothing(Fg(k, 7)) Then
                    If Not String.IsNullOrEmpty(Fg(k, 7)) Then
                        If IsNumeric(Fg(k, 7)) Then
                            IMPORTE = IMPORTE + Fg(k, 7)
                        End If
                    End If
                End If
            Next
            tABONOS.Text = Format(IMPORTE, "###,###,##0.00")
            tSALDO.Text = Format((tSUBTOTAL.Text.Replace(",", "") - IMPORTE), "###,###,##0.00")
        Catch ex As Exception
            Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        If Fg.Row > 0 Then
            If MsgBox("Realmente desea eliminar la partida?", vbYesNo) = vbYes Then
                _myEditor.EndEdit(Fg.Row, Fg.Col)
                Fg.RemoveItem(Fg.Row)
                Dim IMPORTE As Single = 0
                Try
                    For k = 1 To Fg.Rows.Count - 1
                        If Not IsNothing(Fg(k, 7)) Then
                            If Not String.IsNullOrEmpty(Fg(k, 7)) Then
                                If IsNumeric(Fg(k, 7)) Then
                                    IMPORTE = IMPORTE + Fg(k, 7)
                                End If
                            End If
                        End If
                    Next
                    tABONOS.Text = Format(IMPORTE, "###,###,##0.00")
                    tSALDO.Text = Format((tSUBTOTAL.Text.Replace(",", "") - IMPORTE), "###,###,##0.00")
                Catch ex As Exception
                    Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        End If
    End Sub
    Private Function SUMA_ABONOS() As Single
        Dim ABONO As Single
        ABONO = 0
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Not IsNothing(Fg(k, 7)) Then
                    If Not String.IsNullOrEmpty(Fg(k, 7)) Then
                        If IsNumeric(Fg(k, 7)) Then
                            ABONO = ABONO + Fg(k, 7)
                        End If
                    End If
                End If
            Next
            Return ABONO
        Catch ex As Exception
            Bitacora("480. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
End Class
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditor
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    ReadOnly yImporte As Single


    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid, MyImporte As Single)
        MyBase.New()
        Visible = False
        AutoSize = False
        BackColor = Color.Beige
        BorderStyle = BorderStyle.FixedSingle

        _pendingKey = Chr(0)
        yImporte = MyImporte
        _cancel = False
        _owner = owner
        _owner.Controls.Add(Me)
        '_owner.Cols(7).EditMask = "999,999,999.99"
    End Sub

    'comenzar a editar: mover a la celda y activar
    '
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer)
        'save coordinates of cell being edited
        'guardar las coordenadas de la celda que se está editando
        If col = 2 Or col = 4 Or col = 5 Or col = 8 Then

        Else
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
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)

        If col = 1 Or col = 2 Or col = 3 Or col = 4 Or col = 6 Or col = 7 Then

        Else
            MyBase.Visible = False
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
        Dim IMPORTE As Single

        If _col = 1 Or _col = 7 Then
            If Not IsNothing(_owner(_row, _col)) Then
                If _owner(_row, _col).ToString.Trim.Length = 0 Then
                    If _col = 7 Then
                        _owner(_row, 7) = "0"
                    End If
                    _owner.Select(_row, _col)
                    _cancel = True
                    Return
                End If
            Else
                If _col = 7 Then
                    _owner(_row, 7) = "0"
                End If
            End If
        End If
        If _col = 1 Then
            Try

                If SALDO_ES_CERO(_row) Then
                    MsgBox("El pago ya fue aplicado en su totalidad")
                    _owner.Select(_row, _col)
                    _owner(_row, _col) = ""
                    _cancel = True
                    Return
                Else
                    Dim Descr As String
                    Var9 = "" : Var22 = 0
                    Var4 = ""
                    Var10 = " AND CVE_CLIE = '" & Var16 & "' "
                    Descr = BUSCA_CAT("ClieDocSaldos", MyBase.Text)
                    If Descr.TrimEnd.Trim.Length = 0 Then
                        'MsgBox("Documento inexistente")
                        '_owner.Select(_row, _col)
                        '_owner(_row, _col) = ""
                        '_cancel = True
                        'Return
                    Else
                        Dim IMPORT As Single
                        IMPORT = yImporte - SUMA_ABONOS()
                        If IMPORT > yImporte Then
                            _owner(_owner.Row, 7) = IMPORT 'ABONO
                            _owner(_owner.Row, 8) = IMPORT 'SALDO
                            _owner(_owner.Row, 9) = Var9 'IMPORTE DOC
                            _owner(_owner.Row, 10) = IMPORT 'IMPORTE REAL
                            _owner(_owner.Row, 12) = Var22 'NUM_CPTO  es ID_MPOV DE CUEN_DET
                        Else
                            _owner(_owner.Row, 7) = Var9 'ABONO
                            _owner(_owner.Row, 8) = Var9 'SALDO
                            _owner(_owner.Row, 9) = Var9 'IMPORTE DOC
                            _owner(_owner.Row, 10) = Var9 'IMPORTE REAL
                            _owner(_owner.Row, 12) = Var22 'NUM_CPTO  es ID_MPOV DE CUEN_DET
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If _col = 3 Then
            Try
                Dim Descr As String
                Descr = BUSCA_CAT("ConcCxC", MyBase.Text)
                If Descr.TrimEnd.Trim.Length = 0 Then
                    MsgBox("1. Concepto inexistente")
                    _owner.Select(_row, _col)
                    _owner(_row, _col) = ""
                    _owner.StartEditing()
                    _cancel = True
                    Return
                Else
                    _owner(_row, 5) = Descr
                End If
            Catch ex As Exception
                Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("210. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If _col = 7 Then
            IMPORTE = 0
            If Not IsNothing(_owner(_row, 10)) Then
                If Not String.IsNullOrEmpty(_owner(_row, 10)) Then
                    If IsNumeric(_owner(_row, 10)) Then
                        IMPORTE = _owner(_row, 10)
                    End If
                End If
            End If

            If Not IsNothing(_owner(_row, _col)) Then
                If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                    If IsNumeric(_owner(_row, 7)) Then
                        If IsNumeric(MyBase.Text) Then
                            If CSng(MyBase.Text) > IMPORTE Then
                                MsgBox("El abono no puede ser mayor al saldo, verifique por favor")
                                _cancel = True
                                '_owner.Select()
                                '_owner.Select(_row, _col)
                                _owner.StartEditing()
                                Return
                            Else
                                _owner(_row, 8) = IMPORTE - MyBase.Text
                            End If
                        End If
                    End If
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
                _owner.Select()
                e.Handled = True
                MoveCursor(e.KeyCode)
            Case Keys.F2
                If _col = 1 Then
                    Try                    'DOCUMENTO ClieDocSaldos
                        Var2 = "ClieDocSaldos" : Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        Var10 = " AND CVE_CLIE = '" & Var16 & "' "
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            If EXISTE_DOC_FG(Var4) Then
                                MsgBox("2. El documento ya fue agregado")
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _cancel = True
                                Return
                            End If

                            If SALDO_ES_CERO(_row) Then
                                MsgBox("El pago ya fue aplicado en su totalidad")
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner(_row, 3) = ""
                                _owner(_row, 7) = ""
                                _owner(_row, 8) = ""
                                _owner(_row, 9) = ""
                                _owner(_row, 10) = ""
                                _owner(_row, 11) = ""
                                _owner(_row, 12) = ""
                                _cancel = True
                                Return
                            Else
                                Dim IMPORT As Single
                                IMPORT = yImporte - SUMA_ABONOS()
                                _owner(_owner.Row, 1) = Var4
                                If Var9 > IMPORT Then
                                    _owner(_owner.Row, 7) = IMPORT 'ABONO
                                    _owner(_owner.Row, 8) = IMPORT 'SALDO
                                    _owner(_owner.Row, 9) = Var9 'IMPORTE DOC
                                    _owner(_owner.Row, 10) = IMPORT 'IMPORTE REAL
                                    _owner(_owner.Row, 12) = Var6 'NUM_CPTO  es ID_MPOV DE CUEN_DET
                                Else
                                    _owner(_owner.Row, 7) = Var9 'ABONO
                                    _owner(_owner.Row, 8) = Var9 'SALDO
                                    _owner(_owner.Row, 9) = Var9 'IMPORTE DOC
                                    _owner(_owner.Row, 10) = Var9 'IMPORTE REAL
                                    _owner(_owner.Row, 12) = Var6 'NUM_CPTO  es ID_MPOV DE CUEN_DET
                                End If
                                Var2 = "" : Var4 = "" : Var5 = ""
                                _owner.Col = 3
                            End If
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("300. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("300. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
                If _owner.Col = 3 Then  'CONCEPTO
                    Try
                        Var2 = "ConcCxC"
                        Var4 = "" : Var5 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            _owner(_owner.Row, 3) = Var4
                            _owner(_owner.Row, 5) = Var5
                            Var2 = "" : Var4 = "" : Var5 = ""
                            _owner.Col = 6
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("310. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("310. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If

            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub

    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col



        If col = 1 Or col = 3 Or col = 7 Then
            If Not IsNothing(_owner(_row, _col)) Then
                If _owner(_row, _col).ToString.Trim.Length = 0 Then
                    _owner.Row = _row
                    _owner.Col = col
                    _owner.Row = _row
                    Return
                End If
            Else
                _owner.Select()
                '_owner.Row = _row
                '_owner.Col = col
                '_owner.Select(_row, _col)
                Return
            End If
        End If
        Select Case key
            Case Keys.Tab, Keys.Enter

            Case Keys.Up
                If row > 1 Then
                    row = row - 1
                Else
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                End If
            Case Keys.Down
                row = row + 1
            Case Keys.PageUp
                row -= 10
            Case Keys.PageUp
                row += 10
            Case Keys.Left
                If col > 1 Then
                    col = col - 1
                    If col = 2 Or col = 4 Then
                        col = col - 1
                    End If
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()

            Case Keys.Right
                If col < 10 Then
                    col = col + 1
                    If col = 2 Or col = 4 Then
                        col = col + 1
                    End If
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

        'aplicar nueva selección
        _owner.Select(row, col)

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        Dim IMPORTE As Single

        Select Case e.KeyChar
            Case Chr(13), Chr(9)
                Select Case col
                    Case 1
                        Dim Descr As String
                        Var9 = "" : Var22 = 0
                        Var4 = ""
                        Var10 = " AND CVE_CLIE = '" & Var16 & "' "
                        Descr = BUSCA_CAT("ClieDocSaldos", MyBase.Text)
                        If Descr.TrimEnd.Trim.Length = 0 Then
                            MsgBox("Documento inexistente")
                            _owner.Select(_row, _col)
                            _owner(_row, _col) = ""
                            _owner.StartEditing()
                            Return
                        End If
                        If Not IsNothing(_owner(_row, _col)) Then
                            If _owner(_row, _col).ToString.Trim.Length = 0 Then
                                _owner.Row = _row
                                _owner.Col = col
                                _owner.Row = _row
                                _owner.StartEditing()
                                Return
                            End If
                        Else
                            _owner.Select()
                            _owner.Row = _row
                            _owner.Col = col
                            _owner.StartEditing()
                            Return
                        End If
                        If col = 1 Then
                            If SALDO_ES_CERO(row) Then
                                _owner.Select()
                                _owner.Row = _row
                                _owner.Col = col
                                _owner.StartEditing()
                                Return
                            End If
                        End If
                    Case 3
                        If Not IsNothing(_owner(_row, _col)) Then
                            If _owner(_row, _col).ToString.Trim.Length = 0 Then
                                _owner.Row = _row
                                _owner.Col = col
                                _owner.Row = _row
                                _owner.StartEditing()
                                Return
                            End If
                        Else
                            '_owner.Select()
                            '_owner.Row = _row
                            '_owner.Col = col
                            '_owner.StartEditing()
                            Return
                        End If
                    Case 7
                        If Not IsNothing(_owner(_row, _col)) Then
                            If _owner(_row, _col).ToString.Trim.Length = 0 Then
                                _owner.Row = _row
                                _owner.Col = col
                                _owner.Row = _row
                                _owner.StartEditing()
                                Return
                            End If
                        Else
                            _owner.Select()
                            _owner.Row = _row
                            _owner.Col = col
                            _owner.StartEditing()
                            Return
                        End If
                End Select
                e.Handled = True
                _owner.Select()
                Select Case col
                    Case 2, 5, 6
                        _owner.Select(row, col + 1)
                    Case 1, 4
                        _owner.Select(row, col + 2)
                    Case 3
                        _owner.Select(row, col + 3)
                    Case 7, 8
                        If _col = 7 Then
                            IMPORTE = 0
                            If Not IsNothing(_owner(_row, 10)) Then
                                If Not String.IsNullOrEmpty(_owner(_row, 10)) Then
                                    If IsNumeric(_owner(_row, 10)) Then
                                        IMPORTE = _owner(_row, 10)
                                    End If

                                End If
                            End If

                            If Not IsNothing(_owner(_row, _col)) Then
                                If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                    If IsNumeric(_owner(_row, 7)) Then
                                        If IsNumeric(MyBase.Text) Then
                                            If CSng(MyBase.Text) > IMPORTE Then
                                                '_owner.Row = _row
                                                '_owner.Col = col
                                                '_owner.Row = _row
                                                '_owner.StartEditing()
                                                Return
                                            Else
                                                _owner(_row, 8) = IMPORTE - MyBase.Text
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        End If
                        _owner.Select(row + 1, 1)
                End Select
                _owner.StartEditing()
                Return
            Case Else

        End Select
        MyBase.OnKeyPress(e)
    End Sub
    Private Function SALDO_ES_CERO(fRow As Integer) As Boolean
        Dim IMPORTE As Single
        IMPORTE = 0

        Try
            For k = 1 To _owner.Rows.Count - 1
                If k <> fRow Then
                    If Not IsNothing(_owner(k, 7)) Then
                        If Not String.IsNullOrEmpty(_owner(k, 7)) Then
                            If IsNumeric(_owner(k, 7)) Then
                                IMPORTE = IMPORTE + _owner(k, 7)
                            End If
                        End If
                    End If
                End If
            Next
            If IMPORTE >= yImporte Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Private Function EXISTE_DOC_FG(fCVE_DOC As String) As Boolean
        Dim ExistDoc As Boolean
        ExistDoc = False
        Try
            For k = 1 To _owner.Rows.Count - 1
                If Not IsNothing(_owner(k, 1)) Then
                    If Not String.IsNullOrEmpty(_owner(k, 1)) Then
                        If _owner(k, 1) = fCVE_DOC Then
                            ExistDoc = True
                        End If
                    End If
                End If
            Next
            Return ExistDoc
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Private Function SUMA_ABONOS() As Single
        Dim ABONO As Single
        ABONO = 0
        Try
            For k = 1 To _owner.Rows.Count - 1
                If Not IsNothing(_owner(k, 7)) Then
                    If Not String.IsNullOrEmpty(_owner(k, 7)) Then
                        If IsNumeric(_owner(k, 7)) Then
                            ABONO = ABONO + _owner(k, 7)
                        End If
                    End If
                End If
            Next
            Return ABONO
        Catch ex As Exception
            Bitacora("480. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
End Class
