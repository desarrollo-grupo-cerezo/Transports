Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Stimulsoft.Report.StiOptions.Export
Imports C1.Win

Public Class FrmInven
    Private ReadOnly BindingSource1 As New BindingSource
    Private ParamCadena As String
    Private EditReg As Boolean = True
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmInven_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        DialogOK = ""
        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(BarraMenu, "F5 - Salir")
            Me.WindowState = FormWindowState.Maximized

            'Fg.Styles.Normal.WordWrap = True

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg.Dock = DockStyle.Fill
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150
            Application.DoEvents()
            ParamCadena = " I.STATUS = 'A'"
            cboLinea.Width = 200

            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE
                SQL = "SELECT CVE_LIN, DESC_LIN FROM CLIN" & Empresa & " WHERE STATUS = 'A'"

                cboLinea.Items.Add("")
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                Do While dr.Read
                    cboLinea.Items.Add(String.Format("{0,5}", dr("CVE_LIN")) & "  " & dr("DESC_LIN"))
                Loop
                dr.Close()
            Catch ex As Exception
                MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            DERECHOS()

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DERECHOS()
        Dim z As Integer = 0
        If pwPoder Then
            BarNuevo.Visible = True
            'barEdit.Visible = True
            EditReg = True
            BtnEliminar.Visible = True
            BarCAMBIOESTATUS.Visible = True
        Else
            Try
                BarNuevo.Visible = False
                'barEdit.Visible = False
                BtnEliminar.Visible = False
                BarCAMBIOESTATUS.Visible = False
                EditReg = False
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 100100 AND CLAVE < 100500"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            z += 1
                            Select Case dr("CLAVE")
                                Case 100101 'ALTAS
                                    BarNuevo.Visible = True
                                Case 100130 'MODIFICAR
                                    'barEdit.Visible = True
                                    EditReg = True
                                Case 100160 'ELIMINAR
                                    BtnEliminar.Visible = True
                                Case 100190 'CAMBIO ESTATUS
                                    BarCAMBIOESTATUS.Visible = True
                                Case 100220 'CAMBIO DE PRECIOS

                            End Select
                        End While
                    End Using
                End Using
                If z = 0 Then
                    BarNuevo.Visible = True
                    'barEdit.Visible = True
                    EditReg = True
                    BtnEliminar.Visible = True
                    BarCAMBIOESTATUS.Visible = True
                End If
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ds As New DataSet

            Fg.Redraw = False
            Fg.AllowEditing = False

            Application.DoEvents()
            SQL = "SELECT I.CVE_ART, I.STATUS, 
                STUFF((SELECT ' ' + CVE_ALTER + '  ' FROM CVES_ALTER" & Empresa & " WHERE CVE_ART = I.CVE_ART AND ISNULL(CVE_ALTER,'') <> '' FOR XML PATH ('')),1,1, '') AS ALTERNA,
                I.DESCR, I.EXIST, ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 2),0) AS P2,
                I.COSTO_PROM, I.ULT_COSTO, ISNULL(I.LIN_PROD,'') AS LINEA, I.UNI_MED, I.CTRL_ALM, I.TIEM_SURT, I.STOCK_MIN, I.STOCK_MAX, 
                I.TIP_COSTEO, I.FCH_ULTCOM, I.COMP_X_REC, I.FCH_ULTVTA, I.PEND_SURT, I.CVE_OBS, I.TIPO_ELE, I.UNI_ALT, I.FAC_CONV,
                I.APART, I.CON_LOTE, I.CON_PEDIMENTO, I.PESO, I.VOLUMEN, CAST(I.CVE_ESQIMPU AS VARCHAR(3)) + '. ' + DESCRIPESQ, I.CUENT_CONT, 
                I.CVE_PRODSERV, I.CVE_UNIDAD
                FROM INVE" & Empresa & " I 
                LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU    
                WHERE " & ParamCadena & " ORDER BY DESCR"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource
            Lt.Text = "Registros encontrados: " & Fg.Rows.Count - 1

            ENCABEZADO()

            'If ParamCadena.IndexOf("STATUS = 'B'") = -1 Then
            'End If
            'Fg.AutoSizeRows()
            Fg.Cols(4).Width = 200
            Fg.Cols(0).Width = 60
            Fg.Redraw = True

        Catch ex As Exception
            'MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ENCABEZADO()
        Try
            'Fg.COLSws.Count = 34

            Fg.Rows(0).Height = 40
            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - 150

            Fg(0, 1) = "Artículo"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Cve. alterna"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Descripción"
            Dim c4 As Column = Fg.Cols(4)
            c3.DataType = GetType(String)

            Fg(0, 5) = "Existencia"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Precio público"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Precio mínimo"
            Dim cc6 As Column = Fg.Cols(7)
            cc6.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Costo prom."
            Dim ccy As Column = Fg.Cols(8)
            ccy.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Ultimo costo"
            Dim c7 As Column = Fg.Cols(9)
            c7.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Linea"
            Dim c8 As Column = Fg.Cols(10)
            c8.DataType = GetType(String)

            Fg(0, 11) = "Unidad medida"
            Dim c9 As Column = Fg.Cols(11)
            c9.DataType = GetType(String)

            Fg(0, 12) = "Ctrl alm"
            Dim c10 As Column = Fg.Cols(12)
            c10.DataType = GetType(String)

            Fg(0, 13) = "Tiempo surtido"
            Dim c11 As Column = Fg.Cols(13)
            c11.DataType = GetType(Int32)

            Fg(0, 14) = "Stock min."
            Dim c12 As Column = Fg.Cols(14)
            c12.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Stock max."
            Dim c13 As Column = Fg.Cols(15)
            c13.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Tipo costeo"
            Dim c14 As Column = Fg.Cols(16)
            c14.DataType = GetType(String)

            Fg(0, 17) = "Fecha ult. compra"
            Dim c15 As Column = Fg.Cols(17)
            c15.DataType = GetType(DateTime)

            Fg(0, 18) = "Compras x recibir"
            Dim c16 As Column = Fg.Cols(18)
            c16.DataType = GetType(Decimal)
            Fg.Cols(18).Format = "###,###,##0.00"

            Fg(0, 19) = "Fecha ult. venta"
            Dim c17 As Column = Fg.Cols(19)
            c17.DataType = GetType(DateTime)

            Fg(0, 20) = "Pendientes x surtir"
            Dim c18 As Column = Fg.Cols(20)
            c18.DataType = GetType(Decimal)
            Fg.Cols(20).Format = "###,###,##0.00"

            Fg(0, 21) = "Observaciones"
            Dim c19 As Column = Fg.Cols(21)
            c19.DataType = GetType(Int32)

            Fg(0, 22) = "Tipo elemento"
            Dim c20 As Column = Fg.Cols(22)
            c20.DataType = GetType(String)

            Fg(0, 23) = "Unidad alterna"
            Dim c21 As Column = Fg.Cols(23)
            c21.DataType = GetType(String)

            Fg(0, 24) = "Fac. Conv."
            Dim c22 As Column = Fg.Cols(24)
            c22.DataType = GetType(Decimal)
            Fg.Cols(24).Format = "###,###,##0.00"

            Fg(0, 25) = "Apartados"
            Dim c23 As Column = Fg.Cols(25)
            c23.DataType = GetType(Decimal)
            Fg.Cols(25).Format = "###,###,##0.00"

            Fg(0, 26) = "Con lote"
            Dim c24 As Column = Fg.Cols(26)
            c24.DataType = GetType(String)

            Fg(0, 27) = "Con pedimento"
            Dim c25 As Column = Fg.Cols(27)
            c25.DataType = GetType(String)

            Fg(0, 28) = "Peso"
            Dim c26 As Column = Fg.Cols(28)
            c26.DataType = GetType(Decimal)
            Fg.Cols(26).Format = "###,###,##0.00"

            Fg(0, 29) = "Volumen"
            Dim c27 As Column = Fg.Cols(29)
            c27.DataType = GetType(Decimal)
            Fg.Cols(29).Format = "###,###,##0.00"

            Fg(0, 30) = "Esquema impuesto"
            Dim c28 As Column = Fg.Cols(30)
            c28.DataType = GetType(Int32)

            Fg(0, 31) = "Cuenta contable"
            Dim c29 As Column = Fg.Cols(31)
            c29.DataType = GetType(Int32)

            Fg(0, 32) = "Clave SAT"
            Dim c30 As Column = Fg.Cols(32)
            c30.DataType = GetType(String)

            Fg(0, 33) = "Unidad SAT"
            Dim c31 As Column = Fg.Cols(33)
            c31.DataType = GetType(String)
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmInven_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Inventario")
        Me.Dispose()
    End Sub

    Private Sub FrmInven_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    BarNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                Case Keys.F5
                    BarSalir_Click(Nothing, Nothing)
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
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            CREA_TAB(frmInvenAE, "Inventario articulo")
            'ParamCadena = " STATUS = 'A'"
            'DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            If EditReg Then
                Var3 = "Si"
            Else
                Var3 = "No"
            End If

            'Dim mycol As New MyBackGroundColors
            'mycol.DoSet(Me)
            'Dim frm1 As New FrmInvenAE
            'mycol.DoSet(frm1) 'and than this for every form you create.
            'frm1.Show()

            CREA_TAB(FrmInvenAE, "Inventario articulo")
            'ParamCadena = " STATUS = 'A'"
            'DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE INVE" & Empresa & " SET STATUS = 'B' WHERE CVE_ART = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand With {
                    .Connection = cnSAE,
                    .CommandTimeout = 120,
                    .CommandText = SQL
                }
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se elimino satisfactoriamente")
                        ParamCadena = " I.STATUS = 'A'"
                        DESPLEGAR()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        ParamCadena = " I.STATUS = 'A'"
        cboLinea.SelectedIndex = -1
        'TBox.Text = ""

        DESPLEGAR()
    End Sub
    Private Sub TBox_TextChanged(sender As Object, e As EventArgs)
        Try
            'ParamCadena = " I.STATUS = 'A' And (UPPER(CVE_ART) LIKE '%" & TBox.Text.ToUpper & "%' OR UPPER(DESCR) LIKE '%" & TBox.Text.ToUpper & "%')"

            'DESPLEGAR()

        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarKardex_Click(sender As Object, e As EventArgs) Handles BarKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 1)
                Var5 = ""
                Try
                    Var5 = Fg(Fg.Row, 4)
                Catch ex As Exception
                End Try
                FrmKardex.ShowDialog()
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCAMBIOESTATUS_Click(sender As Object, e As EventArgs) Handles BarCAMBIOESTATUS.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea cambiar el estatus del articulo " & Fg(Fg.Row, 1) & "?", vbYesNo) = vbYes Then

                    If Fg(Fg.Row, 2) = "A" Then
                        SQL = "UPDATE INVE" & Empresa & " SET STATUS = 'B' WHERE CVE_ART = '" & Fg(Fg.Row, 1) & "'"
                    Else
                        SQL = "UPDATE INVE" & Empresa & " SET STATUS = 'A' WHERE CVE_ART = '" & Fg(Fg.Row, 1) & "'"
                    End If

                    Dim cmd As New SqlCommand With {
                        .Connection = cnSAE,
                        .CommandTimeout = 120,
                        .CommandText = SQL
                    }
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            MsgBox("El registro se actualizo satisfactoriamente")
                            ParamCadena = " STATUS = 'A'"
                            DESPLEGAR()
                        Else
                            MsgBox("NO se logro actualizo el registro")
                        End If
                    Else
                        MsgBox("!!NO se logro actualizo el registro!!")
                    End If
                End If
            End If

        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarESTATUSBAJA_Click(sender As Object, e As EventArgs) Handles BarESTATUSBAJA.Click
        ParamCadena = " I.STATUS = 'B'"
        DESPLEGAR()
    End Sub
    Private Sub BarPRECIOS_Click_1(sender As Object, e As EventArgs) Handles BarPRECIOS.Click
        CREA_TAB(FrmListaPrecios, "Precios")
    End Sub
    Private Sub BarKITS_Click_1(sender As Object, e As EventArgs) Handles BarKITS.Click
        ParamCadena = " I.STATUS = 'A' AND TIPO_ELE = 'K'"
        DESPLEGAR()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col).ToString)
            End If

            BarEdit_Click(Nothing, Nothing)
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboLinea_DropDownClosed(sender As Object, e As EventArgs) Handles cboLinea.DropDownClosed
        Try
            Dim Linea As String
            If cboLinea.Text.Trim.Length = 0 Then
                ParamCadena = " I.STATUS = 'A'"
            Else
                Linea = cboLinea.Text.Substring(0, 5).Trim
                ParamCadena = " I.STATUS = 'A' AND LTRIM(RTRIM(LIN_PROD)) = '" & Linea & "'"
            End If
            DESPLEGAR()
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBox_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Down Then
                Fg.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarDesplegarArticulosServicios_Click(sender As Object, e As EventArgs) Handles BarDesplegarArticulosServicios.Click
        ParamCadena = " I.STATUS = 'A' AND TIPO_ELE = 'S'"
        DESPLEGAR()
    End Sub

    Private Sub BarAltaAlmacen_Click(sender As Object, e As EventArgs) Handles BarAltaAlmacen.Click
        Try
            If Fg.Row > 0 Then
                Var25 = Fg(Fg.Row, 1)
                FrmAltaMultialmacen.ShowDialog()
            Else
                MsgBox("Por favor seleccione un artículo")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarListaPrecio_Click(sender As Object, e As EventArgs) Handles BarListaPrecio.Click
        Try
            Var17 = Fg(Fg.Row, 1)
            frmSelPrecio.Text = "Precios articulo " & Var17
            frmSelPrecio.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "ARTICULOS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell

        Try
            If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

                'If Fg(e.Row, 32).ToString.Trim.Length = 0 Then
                'Fg.Rows(e.Row).Style = Fg.Styles("CS1")
                'End If
                'If Fg(e.Row, 33).ToString.Trim.Length = 0 Then
                'Fg.Rows(e.Row).Style = Fg.Styles("CS2")
                'End If

                'If Fg(e.Row, 6) > 0 Then
                ''PRECIO PUBLICO   PRECIO MINIMO
                'If Fg(e.Row, 7) > Fg(e.Row, 6) Then
                'Fg.Rows(e.Row).Style = Fg.Styles("CS4")
                'End If
                'End If
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
