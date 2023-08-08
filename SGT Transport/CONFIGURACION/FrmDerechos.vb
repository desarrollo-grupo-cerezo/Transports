Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmDerechos
    Private Sub FrmDerechos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If
            Me.WindowState = FormWindowState.Maximized
            Fg.Rows(0).Height = 40
            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - cboUsuario.Top - cboUsuario.Height - 20

            GBox1.Width = 600

            GBox1.Left = Fg.Left + Fg.Width + 25
            GBox1.Height = Me.Height - C1ToolBar1.Height - 25
            FgD.Height = GBox1.Height - BtnDuplicar.Top - BtnDuplicar.Height - 15
            FgD.Width = GBox1.Width - 15

            Fg.Rows.Count = 1
            Fg.Cols.Count = 4
            '  Show outline tree.
            Fg.Width = 560
            Fg.Cols(0).Width = 40
            Fg.Cols(1).Width = 350
            If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                Fg.Cols(2).Width = 60
                Fg.Cols(3).Width = 40
                BarExel.Visible = True
            Else
                Fg.Cols(2).Width = 0
                Fg.Cols(3).Width = 0
                BarExel.Visible = False
            End If

            Fg.Tree.Column = 1
            Fg.Tree.Show(1)

            Fg.Tree.Style = TreeStyleFlags.Complete ' .SimpleLeaf
            Fg.Tree.LineColor = Color.DarkBlue

            Fg.Cols(1).AllowEditing = True
            Fg.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            Fg.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
            Fg.Styles.Normal.WordWrap = False
            Dim cs As CellStyle = Fg.Styles.Add("Data")
            cs.BackColor = SystemColors.Control

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            Dim SQLstr As String = "SELECT NIVEL, USUARIO, NOMBRE FROM GCUSUARIOS ORDER BY USUARIO"
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim z As Integer = 0

            cmd.Connection = cnSAE
            cmd.CommandText = SQLstr
            dr = cmd.ExecuteReader()
            cboUsuario.Items.Clear()
            While dr.Read()
                cboUsuario.Items.Add(New ValueDescriptionPair(dr.ReadNullAsEmptyString("USUARIO"), dr.ReadNullAsEmptyString("USUARIO") & " - " &
                          dr.ReadNullAsEmptyString("NOMBRE") & IIf(dr.ReadNullAsEmptyString("NIVEL") = "0", "  (Adminstrador)", ""),
                          dr.ReadNullAsEmptyString("USUARIO"), dr.ReadNullAsEmptyString("NIVEL"), z))
                z = z + 1
            End While
            dr.Close()
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmDerechos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Derechos")
        Me.Dispose()
    End Sub
    Sub GRABAR()
        Dim USUARIO_DER As String

        USUARIO_DER = CType(cboUsuario.SelectedItem, ValueDescriptionPair).ClavePair

        Try
            SQL = "DELETE FROM GCDERECHOS WHERE USUARIO = '" & USUARIO_DER & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("210. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try
            For i As Integer = 1 To Fg.Rows.Count - 1
                Dim ck As CheckEnum = Fg.GetCellCheck(i, 1)
                If Fg.GetCellCheck(i, 1) = CheckEnum.Checked Then
                    Try
                        If Fg(i, 2) = "93330" Then
                        End If
                        SQL = "IF NOT EXISTS (SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USUARIO_DER & "' AND CLAVE = " & Fg(i, 2) & ")
                            INSERT INTO GCDERECHOS (USUARIO, CLAVE, DERECHO) VALUES('" & USUARIO_DER & "','" & Fg(i, 2) & "','1')"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If

                        End Using
                    Catch ex As Exception
                        Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("210. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try
                End If
            Next
            MsgBox("Ok")
        Catch ex As Exception
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Dim Level As Integer, i As Integer, r As Row, Level2 As Integer = 1, Level4 As Integer = 1
        Dim USUARIO_DER As String, CADENA As String = ""

        If Not Valida_Conexion() Then
            Return
        End If

        USUARIO_DER = CType(cboUsuario.SelectedItem, ValueDescriptionPair).ClavePair

        Try
            If pwPoder Then
                SQL = "SELECT * FROM GCDERECHOS_CAT1 ORDER BY NUM_REG"
            Else
                If pwSupervisor Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(MODULO,'') AS MODU, ISNULL(ACCESO,0) AS ACC
                        FROM GCLICENCIAMIENTO_MODULOS"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read
                                Select Case Desencriptar(dr("MODU"))
                                    Case "LOGISTICA"
                                        CADENA += " OR (CLAVE >= 20000 AND CLAVE < 30000)"
                                    Case "TESORERIA"
                                        CADENA += " OR (CLAVE >= 30000 AND CLAVE < 40000)"
                                    Case "FACTURACION"
                                        CADENA += " OR (CLAVE >= 40000 AND CLAVE < 50000)"
                                    Case "LIQUIDACION"
                                        CADENA += " OR (CLAVE >= 50000 AND CLAVE < 60000)"
                                    Case "VENTAS"
                                        CADENA += " OR (CLAVE >= 60000 AND CLAVE < 70000)"
                                    Case "COMPRAS"
                                        CADENA += " OR (CLAVE >= 70000 AND CLAVE < 80000)"
                                    Case "CONTROL DE COMBUSTIBLE"
                                        CADENA += " OR (CLAVE >= 80000 AND CLAVE < 90000)"
                                    Case "MANTENIMIENTO"
                                        CADENA += " OR (CLAVE >= 90000 AND CLAVE < 100000)"
                                    Case "INVENTARIO"
                                        CADENA += " OR (CLAVE >= 100000 AND CLAVE < 110000)"
                                    Case "CONTABILIDAD"
                                        CADENA += " OR (CLAVE >= 110000 AND CLAVE < 120000)"
                                    Case "RESCURSOS HUMANOS"
                                        CADENA += " OR (CLAVE >= 120000 AND CLAVE < 130000)"
                                    Case "LOCALIZACION"
                                        CADENA += " OR (CLAVE >= 130000 AND CLAVE < 140000)"
                                    Case "REPORTES"
                                        CADENA += " OR (CLAVE >= 140000 AND CLAVE < 150000)"
                                    Case "CONFIGURACION"
                                        CADENA += " OR (CLAVE >= 150000 AND CLAVE < 160000)"
                                End Select
                            End While
                        End Using

                        If CADENA.Trim.Length > 0 Then
                            If CADENA.Substring(0, 4) = " OR " Then
                                CADENA = CADENA.Substring(4, CADENA.Length - 4)
                                SQL = "SELECT * FROM GCDERECHOS_CAT1 WHERE " & CADENA & " ORDER BY NUM_REG"
                            Else
                                SQL = "SELECT * FROM GCDERECHOS_CAT1 CLAVE >= 10000 AND CLAVE < 20000 ORDER BY NUM_REG"
                            End If
                        Else
                            SQL = "SELECT * FROM GCDERECHOS_CAT1 CLAVE >= 10000 AND CLAVE < 20000 ORDER BY NUM_REG"
                        End If
                    End Using
                End If
            End If

            Fg.AddItem("" & vbTab)
            Dim row As Row
            row = Fg.Rows(Fg.Rows.Count - 1)
            row.IsNode = True

            Dim nd As Node
            nd = row.Node
            nd.Level = Level            'nd.Checked = CheckEnum.Unchecked
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Level = 0
                    i = 1
                    Fg.Rows.Count = 1
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr.ReadNullAsEmptyString("MODULO") & vbTab & dr.ReadNullAsEmptyLong("CLAVE") & vbTab & Fg.Rows.Count)

                        Level = 1
                        r = Fg.Rows(Fg.Rows.Count - 1)
                        r.IsNode = True
                        r.Node.Level = Level
                        r.Node.Checked = CheckEnum.Unchecked
                        Level = Level + 1
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "Select * FROM GCDERECHOS_CAT2 WHERE CLAVE = " & dr.ReadNullAsEmptyLong("CLAVE") & " ORDER BY NUM_REG"
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                While dr2.Read
                                    Fg.AddItem("-" & vbTab & dr2.ReadNullAsEmptyString("MODULO") & vbTab & dr2.ReadNullAsEmptyLong("SUBCLAVE") & vbTab & Fg.Rows.Count)
                                    r = Fg.Rows(Fg.Rows.Count - 1)
                                    r.IsNode = True
                                    r.Node.Level = Level '+ 1
                                    r.Node.Checked = CheckEnum.Unchecked
                                    Level2 = 3
                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                        SQL = "SELECT * FROM GCDERECHOS_CAT3 WHERE CLAVE = '" & dr2.ReadNullAsEmptyLong("SUBCLAVE") & "'"
                                        cmd3.CommandText = SQL
                                        Using dr3 As SqlDataReader = cmd3.ExecuteReader
                                            While dr3.Read
                                                Fg.AddItem("-" & vbTab & dr3.ReadNullAsEmptyString("MODULO") & vbTab &
                                                            dr3.ReadNullAsEmptyLong("SUBCLAVE") & vbTab & Fg.Rows.Count)
                                                r = Fg.Rows(Fg.Rows.Count - 1)
                                                r.IsNode = True
                                                r.Node.Level = Level2
                                                r.Node.Checked = CheckEnum.Unchecked
                                                Level4 = 4
                                                'CATALOGO 4
                                                Using cmd4 As SqlCommand = cnSAE.CreateCommand
                                                    SQL = "SELECT * FROM GCDERECHOS_CAT4 WHERE CLAVE = '" & dr3.ReadNullAsEmptyLong("SUBCLAVE") & "'"
                                                    cmd4.CommandText = SQL
                                                    Using dr4 As SqlDataReader = cmd4.ExecuteReader
                                                        While dr4.Read
                                                            Fg.AddItem("-" & vbTab & dr4.ReadNullAsEmptyString("MODULO") & vbTab &
                                                                       dr4.ReadNullAsEmptyLong("SUBCLAVE") & vbTab & Fg.Rows.Count)
                                                            r = Fg.Rows(Fg.Rows.Count - 1)
                                                            r.IsNode = True
                                                            r.Node.Level = Level4
                                                            r.Node.Checked = CheckEnum.Unchecked
                                                        End While
                                                    End Using
                                                End Using
                                                'Level2 = Level2 + 1
                                            End While
                                        End Using
                                    End Using
                                End While
                            End Using
                        End Using
                        i = i + 1
                        Level = 0
                    End While
                End Using
            End Using
            For k = 1 To Fg.Rows.Count - 1
                Dim r1 As Row = Fg.Rows(k)
                Try
                    If BUSCAR_DERECHO(USUARIO_DER, Fg(r1.Index, 2)) Then
                        Fg.SetCellCheck(r1.Index, 1, CheckEnum.Checked)

                    Else
                        Fg.SetCellCheck(r1.Index, 1, CheckEnum.Unchecked)
                    End If
                    r1.Node.Collapsed = True

                Catch ex As Exception
                    Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function BUSCAR_DERECHO(fUSUARIO_DER As String, fCLAVE As Long)
        Dim ExistClave As Boolean = False
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & fUSUARIO_DER & "' AND CLAVE = '" & fCLAVE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        ExistClave = True
                    End If
                End Using
            End Using
            Return ExistClave
        Catch ex As Exception
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("270. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ExistClave
        End Try
    End Function
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Dim children As Integer = Fg.Rows(e.Row).Node.Children
        Dim Padre As Node = Fg.Rows(e.Row).Node.Parent
        Dim r_ As Integer, z As Integer = 0

        Dim firstRow, lastRow As Integer


        Try
            If children > 0 Then
                Dim cr As CellRange = Fg.Rows(e.Row).Node.GetCellRange()
                firstRow = cr.r1
                lastRow = cr.r2
                Dim Ck As CheckEnum = Fg.GetCellCheck(e.Row, e.Col)

                For i As Integer = firstRow To lastRow
                    If Fg(i, Fg.Col) <> "MODIFICAR" Then
                        Fg.SetCellCheck(i, e.Col, ck)
                    Else
                        Fg.SetCellCheck(i, e.Col, CheckEnum.Unchecked)
                    End If
                Next
                If Not IsNothing(Padre) Then
                    r_ = Padre.Row.Index
                    If Ck.Checked = 1 Then

                        Fg.SetCellCheck(r_, e.Col, CheckEnum.Checked)
                    Else
                        Fg.SetCellCheck(r_, e.Col, CheckEnum.Unchecked)
                    End If
                End If
            Else
                Dim cr As CellRange = Fg.Rows(e.Row).Node.GetCellRange()
                firstRow = cr.r1
                lastRow = cr.r2
                Dim ck As CheckEnum = Fg.GetCellCheck(e.Row, e.Col)
                If Not IsNothing(Padre) Then
                    r_ = Padre.Row.Index
                    lastRow = Padre.LastChild.Row.Index
                    For i As Integer = r_ + 1 To lastRow
                        If Fg.GetCellCheck(i, e.Col) = CheckEnum.Checked Then
                            z = z + 1
                        End If
                    Next
                    If z = 0 Then
                        Fg.SetCellCheck(r_, e.Col, CheckEnum.Unchecked)
                    Else
                        If ck.Checked = 1 Then
                            Fg.SetCellCheck(r_, e.Col, CheckEnum.Checked)
                            If Fg(Fg.Row, Fg.Col) = "MODIFICAR" Then
                                Fg.SetCellCheck(Fg.Row - 1, e.Col, CheckEnum.Unchecked)
                            End If
                            If Fg(Fg.Row, Fg.Col) = "CONSULTAR" Then
                                Fg.SetCellCheck(Fg.Row + 1, e.Col, CheckEnum.Unchecked)
                            End If
                        Else
                            Fg.SetCellCheck(r_, e.Col, CheckEnum.Unchecked)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("360. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUsuario.SelectedIndexChanged
        Dim USUARIO_DER As String, NIVEL As String
        Try

            'cboUsuario.Items.Add(New ValueDescriptionPair(dr("USUARIO"), dr("USUARIO") & " - " & dr("NOMBRE"), dr("USUARIO"), z))

            USUARIO_DER = CType(cboUsuario.SelectedItem, ValueDescriptionPair).ClavePair
            NIVEL = CType(cboUsuario.SelectedItem, ValueDescriptionPair).ClavePair2

            If NIVEL = "0" Then
                MsgBox("El usuario administrador tiene derecho en todo el sistema")
            End If

            DESPLEGAR()

        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarDuplicar_Click(sender As Object, e As ClickEventArgs) Handles BarDuplicar.Click
        GBox1.Visible = True
        BarDuplicar.Enabled = False

        Try
            Dim USUARIO_DER As String

            USUARIO_DER = CType(cboUsuario.SelectedItem, ValueDescriptionPair).ClavePair

            FgD.Rows.Count = 1

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NIVEL, USUARIO, NOMBRE FROM GCUSUARIOS WHERE USUARIO <> '" & USUARIO_DER & "' ORDER BY USUARIO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgD.AddItem("" & vbTab & "" & vbTab & dr("USUARIO") & vbTab & dr("NOMBRE"))
                    End While
                End Using
            End Using
            FgD.AutoSizeCols()
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnDuplicar_Click(sender As Object, e As EventArgs) Handles BtnDuplicar.Click
        Try
            Dim USUARIO_DER As String, USUARIO_DUPLICAR As String

            If MsgBox("Se duplicarán los derechos del usuario " & vbNewLine & cboUsuario.Text & vbNewLine &
                      " a los usuarios seleccionados, Desea continuar?", vbYesNo) = vbYes Then

                USUARIO_DER = CType(cboUsuario.SelectedItem, ValueDescriptionPair).ClavePair

                For k = 1 To FgD.Rows.Count - 1

                    If FgD(k, 1) Then

                        USUARIO_DUPLICAR = FgD(k, 2)
                        Try
                            SQL = "DELETE FROM  GCDERECHOS WHERE USUARIO = '" & USUARIO_DUPLICAR & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT * FROM GCDERECHOS WHERE USUARIO = '" & USUARIO_DER & "'"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    While dr.Read
                                        Try
                                            SQL = "INSERT INTO GCDERECHOS (USUARIO, CLAVE, DERECHO) VALUES('" & USUARIO_DUPLICAR & "','" & dr("CLAVE") & "','1')"
                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                cmd2.CommandText = SQL
                                                returnValue = cmd2.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End While
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Next

                MsgBox("Proceso terminado")
                GBox1.Visible = False
                BarDuplicar.Enabled = True

            End If
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles BarCancelar.Click
        GBox1.Visible = False
        BarDuplicar.Enabled = True
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        GRABAR()
    End Sub

    Private Sub BarExel_Click(sender As Object, e As ClickEventArgs) Handles BarExel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Derechos")
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
