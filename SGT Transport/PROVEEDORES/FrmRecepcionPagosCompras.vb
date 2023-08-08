Imports System.IO
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmRecepcionPagosCompras
    Dim ENTRA As Boolean
    Private _myEditor As MyEditorCxP

    Private Sub FrmRecepcionPagosCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        ENTRA = True

        If Var10 = "Compra" Then
            tPROV.Enabled = False
            tREFER.Enabled = False
        End If


        Me.CenterToScreen()

        Try
            Fg.Rows.Count = 1
            '                    concepto       f2        descr concep   docto       importe 
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0")
            Fg.Row = 1
            Fg.Col = 1

            _myEditor = New MyEditorCxP(Fg, 0)

            _myEditor.StartEditing(Fg.Row, 1)

            tPROV.Select()

        Catch ex As Exception
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub GUARDAR()
        BarGrabar_Click(Nothing, Nothing)
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim j As Integer
        Dim NUM_CPTO As Integer
        Dim IMPORTE As Decimal
        Dim NUM_PAGOS As Integer
        Dim SUMAPAGOS As Decimal
        Dim FORMAPAGO As String
        Dim DOCTO As String

        If MsgBox("Realmente desea grabar el pago?", vbYesNo) = vbYes Then
            Try
                NUM_PAGOS = 0 : SUMAPAGOS = 0
                ENTRA = False
                For j = 1 To Fg.Rows.Count - 1
                    If Not IsNothing(Fg(j, 1)) Then
                        NUM_CPTO = Fg(j, 1)
                    Else
                        NUM_CPTO = 0
                    End If
                    If NUM_CPTO > 0 Then
                        If Not IsNothing(Fg(j, 1)) Then
                            IMPORTE = Fg(j, 5)
                        Else
                            IMPORTE = 0
                        End If
                        If IMPORTE > 0 Then

                            DOCTO = Fg(j, 4)

                            SUMAPAGOS = SUMAPAGOS + IMPORTE
                            CUEN_DET_COM(tREFER.Text, IMPORTE, NUM_CPTO, DOCTO)
                            NUM_PAGOS = NUM_PAGOS + 1
                        End If
                    End If

                Next
                ENTRA = True

                UPDATE_DATOS_PROV(SUMAPAGOS * -1, tREFER.Text, tPROV.Text, " - ")

                FORMAPAGO = "S"

                LIMPIAR()

                MsgBox("El pago se realizo satisfactoriamente")

            Catch ex As Exception
                Bitacora("40. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

    End Sub
    Sub LIMPIAR()
        Try
            tPROV.Text = ""
            tREFER.Text = ""

            Fg.Rows.Count = 1
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0")
            Fg.Row = 1
            Fg.Col = 1

            F1.Value = Now

            LtTotalPagos.Text = ""
            LtDocActual.Text = ""
            LtSaldo.Text = ""
            LtNombre.Text = ""
            LtNO_FACTURA.Text = ""

            tPROV.Focus()

        Catch ex As Exception
        End Try
    End Sub
    Sub IMPRIMIR_CXP(FNO_PARTIDA As Integer)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCxP" & Empresa & ".mrt"
            If Not File.Exists(ARCHIVO_MRT) Then
                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCxP.mrt"
                If Not File.Exists(ARCHIVO_MRT) Then
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    Return
                End If
            End If

            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = tREFER.Text
            StiReport1.Item("NO_PARTIDA") = FNO_PARTIDA
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CUEN_DET_COM(fCVE_DOC As String, fIMPORTE As Decimal, fNUM_CPTO As Integer, fDOCTO As String)

        Dim CVE_PROV As String, REFER As String, ID_MOV As Integer, NUM_CPTO As Integer, NUM_CARGO As Integer, CVE_OBS As Long, NO_FACTURA As String
        Dim IMPORTE As Decimal, AFEC_COI As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CTLPOL As Integer
        Dim CVE_FOLIO As String, TIPO_MOV As String, SIGNO As Integer, CVE_AUT As Integer, Usuario2 As Integer, REF_SIST As String, NO_PARTIDA As Integer

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        Try
            CVE_PROV = tPROV.Text
            REFER = fCVE_DOC
            NO_FACTURA = fCVE_DOC
            NUM_CPTO = fNUM_CPTO

            ID_MOV = 1

            NUM_CARGO = 1
            CVE_OBS = 0
            If fDOCTO.Trim.Length = 0 Then fDOCTO = fCVE_DOC
            IMPORTE = fIMPORTE
            AFEC_COI = "" : NUM_MONED = 1 : TCAMBIO = 1
            IMPMON_EXT = IMPORTE

            CTLPOL = 0 : CVE_FOLIO = "" : TIPO_MOV = "A" : SIGNO = -1 : CVE_AUT = 0 : Usuario2 = 0 : REF_SIST = "" : NO_PARTIDA = 1

            SQL = "INSERT INTO PAGA_DET" & Empresa & " (CVE_PROV, REFER, ID_MOV, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE,
                  FECHA_APLI, FECHA_VENC, AFEC_COI, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, CTLPOL, CVE_FOLIO, TIPO_MOV, SIGNO,
                  CVE_AUT, USUARIO, REF_SIST, NO_PARTIDA) VALUES('" & CVE_PROV & "','" & REFER & "','" & ID_MOV & "','" & NUM_CPTO & "','" &
                  NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & fDOCTO & "','" & Math.Round(IMPORTE, 6) & "','" &
                  FSQL(F1.Value) & "','" & FSQL(F1.Value) & "','" & AFEC_COI & "','" & NUM_MONED & "','" & TCAMBIO & "','" &
                  Math.Round(IMPORTE, 6) & "',GETDATE(),'" & CTLPOL & "','" & CVE_FOLIO & "','" & TIPO_MOV & "','" &
                  SIGNO & "','" & CVE_AUT & "','" & Usuario2 & "','" & REF_SIST & "',
                  ISNULL((SELECT MAX(NO_PARTIDA) + 1 FROM PAGA_DET" & Empresa & " WHERE REFER = '" & REFER & "' AND CVE_PROV = '" & CVE_PROV & "'),1))"

            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    UPDATE_DATOS_PROV(IMPORTE, NO_FACTURA, CVE_PROV, " - ")
                End If
            End If

        Catch ex As Exception
            Bitacora("74. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("74. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub UPDATE_DATOS_PROV(fIMPORTE As Decimal, fNO_FACTURA As String, fCVE_PROV As String, fSIGNO As String)
        'CUANDO ES UN ABONO ULT_PAGOD, ULT_PAGOM, ULT_PAGOF
        'CUANDO ES UN CARGO ULT_COMPD, ULT_COMPD, ULT_COMPM ULT_COMPF
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            If fSIGNO = " - " Then
                SQL = "UPDATE PROV" & Empresa & " SET SALDO = SALDO " & fSIGNO & fIMPORTE & ", " &
                    "ULT_PAGOD = '" & fNO_FACTURA & "', ULT_PAGOM = '" & fIMPORTE & "', ULT_PAGOF = CONVERT(VarChar, GETDATE(), 112) " &
                    "WHERE CLAVE = '" & fCVE_PROV & "'"
            Else
                SQL = "UPDATE PROV" & Empresa & " SET SALDO = SALDO " & fSIGNO & fIMPORTE & ", " &
                    "ULT_COMPD = '" & fNO_FACTURA & "', ULT_COMPM = '" & fIMPORTE & "', ULT_COMPF = CONVERT(VarChar, GETDATE(), 112) " &
                    "WHERE CLAVE = '" & fCVE_PROV & "'"
            End If
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                End If
            End If
        Catch ex As Exception
            Bitacora("76. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("76. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg.Row > 0 Then
                Fg.RemoveItem(Fg.Row)
                Fg.Col=1
            End If
        Catch ex As Exception
            Bitacora("78. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("78. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tPROV.Text = Var4
                LtNombre.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                F1.Focus()
            End If
        Catch ex As Exception
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub BtnConc_Click(sender As Object, e As EventArgs) Handles btnConc.Click
        Try
            Var2 = "ConcCxPRef"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                Fg.FinishEditing()
                Fg(Fg.Row, 1) = Var4
                Fg(Fg.Row, 3) = Var5

                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Col = 4
            End If
        Catch ex As Exception
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function CalculaPagos(fRow As Integer) As Decimal
        Try
            Dim SUMA As Decimal

            ENTRA = False
            SUMA = 0
            For k = 1 To Fg.Rows.Count - 1
                If k <> fRow Then
                    SUMA = SUMA + Fg(k, 5)
                End If
            Next
            ENTRA = True
            Return SUMA
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Select Case Fg.Col
                Case 1, 2, 4, 5
                    ENTRA = True
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmRecepcionPagosCompras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub TPROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tPROV.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnProv_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                Dim DESCR As String
                DESCR = tPROV.Text.Trim
                If IsNumeric(DESCR) Then
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    tPROV.Text = DESCR
                End If
                tREFER.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnDoc_Click(sender As Object, e As EventArgs) Handles btnDoc.Click
        Try
            Var2 = "ProvDocSaldos"
            Var4 = tPROV.Text
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var7 = Fg(Fg.Row, 7).ToString 'ABONOS
                'Var8 = Fg(Fg.Row, 8).ToString 'IMPORTE
                'Var9 = Fg(Fg.Row, 9).ToString SALDO
                tREFER.Text = Var4
                LtSaldo.Text = Format(Val(Var9), "###,###,##0.00")
                LtDocActual.Text = Format(Val(Var8), "###,###,##0.00")
                tREFER.Tag = Var12

                LtNO_FACTURA.Text = "FACTURA:" & Var11
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Focus()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                _myEditor.StartEditing(Fg.Row, 1)
            End If

        Catch Ex As Exception
            MsgBox("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TREFER_KeyDown(sender As Object, e As KeyEventArgs) Handles tREFER.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnDoc_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                Fg.Select()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, 1)
                End If

            End If
        Catch ex As Exception
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tREFER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tREFER.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                'Fg.Select()
                'Fg.Row = Fg.Rows.Count - 1
                'Fg.Col = 1
                '_myEditor.StartEditing(Fg.Row, 9)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub TREFER_Validated(sender As Object, e As EventArgs) Handles tREFER.Validated
        Dim FOLIOD As Long
        Try
            If tREFER.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(tREFER.Text.Trim) Then
                    FOLIOD = tREFER.Text.Trim

                    tREFER.Text = Space(10) & Format(FOLIOD, "0000000000")
                End If

                Var4 = tREFER.Text
                Var5 = tPROV.Text
                If Var4.Trim.Length > 0 And Var5.Trim.Length > 0 Then
                    DESCR = BUSCA_CAT("ProvDocSaldos", tREFER.Text)
                    If DESCR <> "" Then
                        'Var21 = dr.ReadNullAsEmptyDecimal("IMPORTE") - dr.ReadNullAsEmptyDecimal("SUMA_CUENDET")
                        'Var22 = dr.ReadNullAsEmptyInteger("NUM_CPTO")
                        'Var4 = dr("DES") '"Fg(Fg.Row, 1).ToString  'REFER
                        'Var5 = dr("CVE_PROV") 'Fg(Fg.Row, 2).ToString  'CLIENTE
                        'Var7 = dr("SUMA_CUENDET") 'Fg(Fg.Row, 7) 'ABONOS
                        'Var8 = dr("IMPORTE") 'Fg(Fg.Row, 8) 'IMPORTE
                        'Var9 = dr("SALDO") 'Fg(Fg.Row, 9)  'SALDO
                        'Var6 = dr("NUM_CARGO") 'Fg(Fg.Row, 11).ToString  'NUM_CARGO

                        'Var7 = dr("SUMA_CUENDET") + dr("CARGOS")
                        'Var8 = dr("IMPORTE")
                        'Var9 = dr("IMPORTE") + dr("SUMA_CUENDET") + dr("CARGOS")
                        LtSaldo.Text = Format(Val(Var9), "###,###,##0.00")
                        LtDocActual.Text = Format(Val(Var9), "###,###,##0.00")
                        tREFER.Tag = Var22 'CONCEPTO
                        LtNO_FACTURA.Text = "FACTURA:" & Var11
                        Fg.Focus()
                        Fg.Row = 1
                        Fg.Col = 1

                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(Fg.Row, 9)
                        End If

                    Else
                        MsgBox("El documento no existe o se encuentra saldado")
                        tREFER.Text = ""
                        tREFER.Select()
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROV_Validated(sender As Object, e As EventArgs) Handles tPROV.Validated
        Try
            If tPROV.Text.Trim.Length > 0 Then
                Var5 = ""
                Dim DESCR As String
                DESCR = tPROV.Text.Trim
                If IsNumeric(DESCR) Then
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    tPROV.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Prov", tPROV.Text)
                If DESCR <> "" Then
                    Var11 = tPROV.Text
                    LtNombre.Text = DESCR
                Else
                    MsgBox("Proveedor inexistente")
                    tPROV.Text = ""
                    LtNombre.Text = ""
                    tREFER.Focus()
                    tREFER.SelectAll()
                End If
            End If
        Catch ex As Exception
            Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub tMagico_GotFocus(sender As Object, e As EventArgs) Handles tMagico.GotFocus
        Try
            Fg.Select()
            Dim c_ As Integer
            c_ = Fg.Col

            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, c_)
            End If

        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                Dim c_ As Integer
                c_ = Fg.Col
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, c_)
                End If
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If ENTRA Then
                If Fg.Row > 0 Then
                    If Fg.Col = 3 Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        Try
            If ENTRA Then
                _myEditor.SetPendingKey(e.KeyChar)
            End If
        Catch ex As Exception
            Bitacora("230. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        '1 2 6
        Try
            If ENTRA Then
                If Fg.Col = 1 Or Fg.Col = 4 Or Fg.Col = 5 Then
                    Dim c_ As Integer
                    c_ = Fg.Col

                    If Not IsNothing(_myEditor) Then
                        _myEditor.StartEditing(Fg.Row, c_)
                    End If

                End If
            End If
        Catch ex As Exception
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_AfterScroll(sender As Object, e As RangeEventArgs) Handles Fg.AfterScroll
        If ENTRA Then
            If _myEditor.Visible Then
                _myEditor.UpdatePosition()
            End If
        End If
    End Sub

    Private Sub F1_KeyDown(sender As Object, e As KeyEventArgs) Handles F1.KeyDown
        If e.KeyCode = 13 Then
            tREFER.Focus()
        End If
    End Sub
End Class

'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditorCxP
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid, MyAlmacen As Decimal)
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
    '
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        Dim Sigue As Boolean

        'save coordinates of cell being edited        'guardar las coordenadas de la celda que se está editando
        If keyRec = 66 Then
            MyBase.Text = ""
            MyBase.Visible = False
            _owner.FinishEditing()
            Return
        End If
        If col = 1 And keyRec = 9 Then
            'MyBase.Visible = True
            '_owner.Select(_row, 1)
            '_owner.StartEditing()

            _owner.Col = 1
            frmRecepcionPagosCompras.tMagico.Focus()
            _owner.Select()
            _owner.Select(_row, 2)
            _owner.StartEditing()
            Return
        End If
        If col = 1 And keyRec = 999 Then
            _owner.Col = 1
            MyBase.Visible = True
            _owner.Select(_row, 1)
            _owner.StartEditing()
            SendKeys.Send("{TAB}")
            Return
        End If
        Sigue = True

        If Sigue And (col = 1 Or col = 4 Or col = 5) Then
            If col = 99 Then
                _owner.Col = 1
                frmRecepcionPagosCompras.tMagico.Focus()
                MyBase.Visible = True
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If

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
            If col = 131 Then
                'PRECIO
            End If
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
            '_owner.Select(_row, 2)
            MyBase.Select()
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = MyBase.TextLength

            If col = 1 And keyRec = 99 Then
                SendKeys.Send("{TAB}")
            End If
        End If

    End Sub
    Public Sub EndEdit(ByVal row As Integer, ByVal col As Integer)
        Try
            _owner.FinishEditing()
            _owner(row, col) = ""
            MyBase.Text = ""
        Catch ex As Exception
            Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)
        If col = 1 Or col = 4 Or col = 5 Then
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
        Dim PAGOS As Decimal, IMPORTE As Decimal, SUM_PAGOS As Decimal
        If _col = 99 Then
            _owner.Col = 1
            frmRecepcionPagosCompras.tMagico.Focus()
            _owner.Select()
            _owner.Select(_row, 2)
            _owner.StartEditing()
            Return
        End If
        Try
            'aqui esta el error
            If _col = 22 Then
                If IsNothing(_owner(_row, 2)) Then
                    MyBase.Visible = True
                    '_owner.Select()
                    '_owner.Select(_row, 2)
                    _owner.StartEditing()
                    Return
                End If
                'If _owner(_row, _col) = "" Then
                MyBase.Visible = True
                '_owner.Select()
                '_owner.Select(_row, 2)
                _owner.StartEditing()
                Return
                'End If
            End If
            If _col = 1 Then
                Try
                    Try
                        IMPORTE = 0 'SALDO
                        If IsNumeric(frmRecepcionPagosCompras.LtDocActual.Text.Replace(",", "")) Then
                            'SALDO
                            IMPORTE = frmRecepcionPagosCompras.LtDocActual.Text.Replace(",", "")
                        End If

                        PAGOS = IMPORTE - CalculaPagos(_row)
                        If Not IsNothing(_owner(_row, 5)) Then
                            If IsNumeric(_owner(_row, 5)) Then
                                If CDec(_owner(_row, 5)) = 0 Then
                                    _owner(_row, 5) = PAGOS
                                End If
                            Else
                                _owner(_row, 5) = PAGOS
                            End If
                        Else
                            _owner(_row, 5) = PAGOS
                        End If
                    Catch ex As Exception
                        Bitacora("4050. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    '_owner.FinishEditing()
                Catch ex As Exception
                    Bitacora("4100. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("4100. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If _col = 4 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(MyBase.Text) Then
                                Try
                                    If CDec(MyBase.Text) > 0 Then
                                        Try
                                            IMPORTE = 0 'SALDO
                                            If IsNumeric(frmRecepcionPagosCompras.LtSaldo.Text.Replace(",", "")) Then
                                                'SALDO
                                                IMPORTE = frmRecepcionPagosCompras.LtSaldo.Text.Replace(",", "")
                                            End If

                                            SUM_PAGOS = CalculaPagos(_row)
                                            PAGOS = IMPORTE - SUM_PAGOS

                                            If PAGOS < 0 Then
                                                MsgBox("El documento ya esta saldado")
                                                MyBase.Text = "0"
                                                _owner.StartEditing()
                                                Return
                                            End If
                                        Catch ex As Exception
                                            Bitacora("4050. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End If
                                Catch ex As Exception
                                    Bitacora("4070. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                _owner.FinishEditing()
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("4100. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("4100. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If _col = 5 Then
                Try
                    IMPORTE = 0 'SALDO
                    If IsNumeric(frmRecepcionPagosCompras.LtSaldo.Text.Replace(",", "")) Then
                        'SALDO
                        IMPORTE = frmRecepcionPagosCompras.LtSaldo.Text.Replace(",", "")
                    End If

                    If IsNumeric(MyBase.Text) Then
                        PAGOS = IMPORTE - CalculaPagos(_row) - CDec(MyBase.Text)
                    Else
                        PAGOS = IMPORTE - CalculaPagos(_row)
                    End If

                    If PAGOS < 0 Then
                        MsgBox("El importe es mayor al saldo verifique por favor")

                        _owner.Col = 4
                        frmRecepcionPagosCompras.tMagico.Focus()
                        If _row > 1 Then
                            _row = _row - 1
                        End If
                        _owner.Select(_row, _col)
                        _owner(_row, _col) = ""

                        '_owner.StartEditing()
                        Return
                    End If
                    frmRecepcionPagosCompras.LtTotalPagos.Text = Format(CalculaPagos(0), "###,###,##0.00")
                    '_owner.StartEditing()

                Catch ex As Exception
                    Bitacora("4150. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
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
            Bitacora("4200. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("940. " & ex.Message & vbNewLine & ex.StackTrace)
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
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        If _col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmRecepcionPagosCompras.tMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If
        End If

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
                    Try    'CONCEPTOS
                        Var2 = "ConcCxPRef"
                        Var4 = ""
                        Var5 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            _owner(_owner.Row, 1) = Var4
                            _owner(_owner.Row, 3) = Var5

                            Var2 = ""
                            Var4 = ""
                            Var5 = ""
                            _owner.Col = 4
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("4300. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("4300. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
                If _col = 5 Then
                End If
            Case Keys.F3
                frmRecepcionPagosCompras.GUARDAR()
            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub

    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col

        If col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmRecepcionPagosCompras.tMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        If col = 1 And key = Keys.Left Then
            frmRecepcionPagosCompras.tMagico.Focus()
            Return
        End If

        Select Case key
            Case Keys.Tab, Keys.Enter

            Case Keys.Up
                If _owner.Row = 1 Then
                    frmRecepcionPagosCompras.tMagico.Focus()
                    Return
                End If
                If IsNothing(_owner(_row, 1)) Then
                    If IsNothing(_owner(_row, 2)) Then
                        _owner.RemoveItem(_owner.Row)
                        row = _owner.Rows.Count - 1
                        Return
                    Else
                        If _owner(_row, 2).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                Else
                    If _owner(_row, 2).ToString.Trim.Length = 0 Then
                        If _owner(_row, 1).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                End If

                If row > 1 Then
                    row = row - 1
                    '_owner.Select()
                    _owner.Select(row, col)
                    '_owner.StartEditing()
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
                                frmRecepcionPagosCompras.tMagico.Focus()
                            Else
                                If _owner(_row, 1).ToString.Length > 0 And _owner(_row, 1).ToString.Length > 0 Then
                                    '                          concepto       f2        descr concep  docto       importe 
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & " ")
                                    _owner.Select(row + 1, 1)
                                Else
                                    frmRecepcionPagosCompras.tMagico.Focus()
                                End If
                            End If
                        Case 2
                            frmRecepcionPagosCompras.tMagico.Focus()
                        Case 5
                            frmRecepcionPagosCompras.tMagico.Focus()
                    End Select
                    Return
                Else
                    row = row + 1
                    _owner.Select()
                    _owner.Select(row, col)
                    '_owner.StartEditing()
                End If
            Case Keys.PageUp
                row -= 10
            Case Keys.PageUp
                row += 10
            Case Keys.Left
                If col > 1 Then
                    Select Case col
                        Case 1
                            Try
                                Dim DESCR As String
                                DESCR = BUSCA_CAT("ConcCxPRefer", _owner(_owner.Row, 1))
                                _owner(_owner.Row, 3) = DESCR

                            Catch ex As Exception
                                Bitacora("4310. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                frmRecepcionPagosCompras.tMagico.Focus()
                                _owner.Select()
                                _owner.Select(row, col)
                                _owner.StartEditing()
                                Return
                            Catch ex As Exception
                                Bitacora("4320. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Case 4
                            col = 1
                            '_owner.Select()
                            _owner.Select(row, col)
                            '_owner.StartEditing()
                            Return
                        Case 5
                            col = 4
                            _owner.Select()
                            _owner.Select(row, col)
                            '_owner.StartEditing()
                            Return
                            'If row = 1 Then
                            'row = _owner.Rows.Count - 1
                            'Else
                            'row = row - 1
                            'End If
                            'col = 1
                    End Select
                    'col = col - 1
                    'If col = 2 Or col = 4 Then
                    'col = col - 1
                    'End If
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
                Return
            Case Keys.Right
                If col <= 8 Then
                    Select Case col
                        Case 1
                            'CORREGIR AQUI
                            If IsNothing(_owner(_row, 1)) Then
                                frmRecepcionPagosCompras.tMagico.Focus()
                                '_owner.Select()
                                '_owner.Select(row, col)
                                '_owner.StartEditing()
                                Return
                            End If
                            If MyBase.Text.ToString.Length = 0 Then
                                frmRecepcionPagosCompras.tMagico.Focus()
                                '_owner.Select()
                                _owner.Select(row, col)
                                '_owner.StartEditing()
                                Return
                            End If
                            col = 4
                            '_owner.Select()
                            _owner.Select(row, col)
                            '_owner.StartEditing()
                            Return
                        Case 4 'DOCTO
                            col = 5
                            _owner.Select(row, col)
                            Return
                        Case 5 'IMPORTE
                            col = 5
                            frmRecepcionPagosCompras.tMagico.Focus()
                            '_owner.Select()
                            _owner.Select(row, col)
                            '_owner.StartEditing()
                            Return
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
        _owner.Select(_row, _col)

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        Dim HayErr As Boolean

        If col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmRecepcionPagosCompras.tMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If
        End If
        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)
                    Select Case _col
                        Case 1 'CONCEPTO
                            Dim Descr As String

                            If MyBase.Text.Trim.Length = 0 Then
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                frmRecepcionPagosCompras.tMagico.Focus()
                                MyBase.Visible = True
                                Return
                            End If

                            Var9 = "" : Var22 = 0 : Var4 = ""
                            Descr = BUSCA_CAT("ConcCxPRefer", MyBase.Text)
                            If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                MsgBox("Concepto inexistente ó el artículo es un servicio")
                                frmRecepcionPagosCompras.tMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                '_owner.StartEditing()
                                Return
                            Else
                                _owner.Col = 4
                                _owner(_row, 3) = Descr

                                Return
                            End If

                        Case 4
                            _owner.Col = 5
                            Try
                                Dim PAGOS As Decimal, IMPORTE As Decimal = 0

                                If IsNumeric(frmRecepcionPagosCompras.LtSaldo.Text.Replace(",", "")) Then
                                    'SALDO DOCUMENTO
                                    IMPORTE = frmRecepcionPagosCompras.LtSaldo.Text.Replace(",", "")
                                End If
                                PAGOS = IMPORTE - CalculaPagos(_row)
                                frmRecepcionPagosCxC.LtTotalPagos.Text = Format(CalculaPagos(0), "###,###,##0.00")
                                frmRecepcionPagosCxC.LtSaldo.Text = Format(PAGOS, "###,###,##0.00")
                                '_owner(_row, 5) = PAGOS
                            Catch ex As Exception
                                Bitacora("4380. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            _owner.StartEditing()
                            frmRecepcionPagosCompras.tMagico.Focus()
                            MyBase.Visible = True
                            Return
                        Case 5 'MONTO DOCUMENTO
                            If (MyBase.Text.Trim.Length = 0 Or MyBase.Text.Trim = "0") And _col = 99 Then
                                MyBase.Visible = True
                                frmRecepcionPagosCompras.tMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = "0"
                                '_owner.StartEditing()
                                Return
                            End If
                            Try
                                HayErr = False
                                Try
                                    _owner.Select(row + 1, 1)
                                Catch ex As Exception
                                    HayErr = True
                                End Try

                                If HayErr Then
                                    'If FgEdit Then
                                    '                          concepto       f2        descr concep  docto       importe 
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & " ")
                                    _owner.Select(row + 1, 1)
                                    'End If
                                Else
                                    'If _owner(row, 1) > 0 And _owner(row, 3).ToString.Trim.Length > 0 Then
                                    'End If
                                End If
                                _owner.Col = 1
                                '_owner.Select(_row, _col)
                                '_owner(_row, _col) = "1"
                                '_owner.StartEditing()
                                Return
                            Catch ex As Exception
                                Bitacora("4390. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("4390. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 111
                            _owner.Select(row, col + 4)
                        Case 55
                            _owner.Select(row, col + 4)
                        Case 10
                    End Select

                    _owner.StartEditing()
                    'Return

                Case Else
                    If _col = 5 Then
                        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                            e.KeyChar = ""
                            Return
                        End If
                    End If
                    If _col = 1 Then
                        'e.KeyChar = e.KeyChar.ToString.ToUpper
                    End If
            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            Bitacora("4400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function CalculaPagos(fRow As Integer) As Decimal
        Try
            Dim SUMA As Decimal

            SUMA = 0
            For k = 1 To _owner.Rows.Count - 1
                If k <> fRow Then
                    SUMA = SUMA + _owner(k, 5)
                End If
            Next
            Return SUMA
        Catch ex As Exception
            Bitacora("4550. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
End Class