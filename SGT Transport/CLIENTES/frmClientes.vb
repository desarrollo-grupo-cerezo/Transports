Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmClientes

    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
    End Sub
    Sub CARGAR_DATOS()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)
        Catch ex As Exception
        End Try

        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(MNUEliminarCliente, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(BarraMenu, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True

            Fg.Rows.Count = 1
            Fg.Cols.Count = 84

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            If Not pwPoder Then
                MNUClientesBaja.Visible = False
            End If


            DERECHOS()

            DESPLEGAR()
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmClientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Clientes")
        Me.Dispose()
    End Sub
    Sub DERECHOS()
        Dim z As Integer = 0
        If pwPoder Then
            barNuevo.Visible = True
            barEdit.Visible = True
            MNUEliminarCliente.Visible = True
        Else
            Try
                barNuevo.Visible = False
                barEdit.Visible = False
                MNUEliminarCliente.Visible = False

                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE > 10100 AND CLAVE < 10500"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            z = z + 1
                            Select Case dr("CLAVE")
                                Case 10101
                                    barNuevo.Visible = True
                                Case 10130
                                    barEdit.Visible = True
                                Case 10160
                                    MNUEliminarCliente.Visible = True
                            End Select
                        End While
                    End Using
                End Using
                If z = 0 Then
                    barNuevo.Visible = True
                    barEdit.Visible = True
                    MNUEliminarCliente.Visible = True
                End If
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR(Optional FSTATUS As String = " WHERE STATUS = 'A'")
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT CLAVE, STATUS, NOMBRE, RFC, CURP, REG_FISC, USO_CFDI, FORMADEPAGOSAT, SALDO, CALLE, NUMINT, NUMEXT, 
                CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO, LOCALIDAD, MUNICIPIO, ESTADO, PAIS, NACIONALIDAD, REFERDIR, 
                TELEFONO, CLASIFIC, FAX, PAG_WEB, CVE_ZONA, IMPRIR, MAIL, NIVELSEC, ENVIOSILEN, EMAILPRED, DIAREV, DIAPAGO, 
                CON_CREDITO, DIASCRED, LIMCRED, LISTA_PREC, CVE_BITA, ULT_PAGOD, ULT_PAGOM, ULT_PAGOF, DESCUENTO, ULT_VENTAD, 
                ULT_COMPM, FCH_ULTCOM, VENTAS, CVE_VEND, CVE_OBS, TIPO_EMPRESA, MATRIZ, PROSPECTO, CALLE_ENVIO, NUMINT_ENVIO, 
                NUMEXT_ENVIO, CRUZAMIENTOS_ENVIO, CRUZAMIENTOS_ENVIO2, COLONIA_ENVIO, LOCALIDAD_ENVIO, MUNICIPIO_ENVIO, 
                ESTADO_ENVIO, PAIS_ENVIO, CODIGO_ENVIO, CVE_ZONA_ENVIO, REFERENCIA_ENVIO, CUENTA_CONTABLE, ADDENDAF, ADDENDAD,
                NAMESPACE, METODODEPAGO, NUMCTAPAGO, MODELO, DES_IMPU1, DES_IMPU2, DES_IMPU3, DES_IMPU4, DES_PER, LAT_GENERAL, 
                LON_GENERAL, LAT_ENVIO, LON_ENVIO, CVE_PAIS_SAT, NUMIDREGFISCAL
                FROM CLIE" & Empresa & FSTATUS & " ORDER BY TRY_PARSE(CLAVE AS INT)"
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            TITULOS()

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            Var4 = ""
            CREA_TAB(frmClientesAE, "Cliente")

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Var4 = ""
            BarEdit_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            Var4 = ""
            CREA_TAB(frmClientesAE, "Cliente")
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
    Private Sub MNUClientesBaja_Click(sender As Object, e As EventArgs) Handles MNUClientesBaja.Click
        Try
            If pwPoder Then
                DESPLEGAR(" WHERE STATUS = 'B'")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MNUEliminarCliente_Click(sender As Object, e As EventArgs) Handles MNUEliminarCliente.Click
        Try
            If MsgBox("Realmente desea de baja al cliente?", vbYesNo) = vbYes Then

                SQL = "UPDATE CLIE" & Empresa & " SET STATUS = 'B' WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"

                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandTimeout = 120

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
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS()
        Try
            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "RFC"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "CURP"
            Dim cc5 As Column = Fg.Cols(5)
            cc5.DataType = GetType(String)

            Fg(0, 6) = "Régimen fiscal"
            Dim cc6 As Column = Fg.Cols(6)
            cc6.DataType = GetType(String)

            Fg(0, 7) = "Uso CFDI"
            Dim c79 As Column = Fg.Cols(7)
            c79.DataType = GetType(String)

            Fg(0, 8) = "Forma pago SAT"
            Dim c82 As Column = Fg.Cols(8)
            c82.DataType = GetType(String)

            Fg(0, 9) = "Saldo"
            Dim c5 As Column = Fg.Cols(9)
            c5.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Dirección"
            Dim c6 As Column = Fg.Cols(10)
            c6.DataType = GetType(String)

            Fg(0, 11) = "Num. int."
            Dim c7 As Column = Fg.Cols(11)
            c7.DataType = GetType(String)

            Fg(0, 12) = "Num. ext."
            Dim c8 As Column = Fg.Cols(12)
            c8.DataType = GetType(String)

            Fg(0, 13) = "Cruzamiento"
            Dim c9 As Column = Fg.Cols(13)
            c9.DataType = GetType(String)

            Fg(0, 14) = "Cruzamientos 2"
            Dim c10 As Column = Fg.Cols(14)
            c10.DataType = GetType(String)

            Fg(0, 15) = "Colonia"
            Dim c11 As Column = Fg.Cols(15)
            c11.DataType = GetType(String)

            Fg(0, 16) = "C.P."
            Dim c12 As Column = Fg.Cols(16)
            c12.DataType = GetType(String)

            Fg(0, 17) = "Localidad"
            Dim c13 As Column = Fg.Cols(17)
            c13.DataType = GetType(String)

            Fg(0, 18) = "Municipio"
            Dim c14 As Column = Fg.Cols(18)
            c14.DataType = GetType(String)

            Fg(0, 19) = "Estado"
            Dim c15 As Column = Fg.Cols(19)
            c15.DataType = GetType(String)

            Fg(0, 20) = "Pais"
            Dim c16 As Column = Fg.Cols(20)
            c16.DataType = GetType(String)

            Fg(0, 21) = "Nacionalidad"
            Dim c17 As Column = Fg.Cols(21)
            c17.DataType = GetType(String)

            Fg(0, 22) = "Referencia dirección"
            Dim c18 As Column = Fg.Cols(22)
            c18.DataType = GetType(String)

            Fg(0, 23) = "Telefono"
            Dim c19 As Column = Fg.Cols(23)
            c19.DataType = GetType(String)

            Fg(0, 24) = "Clasific."
            Dim c20 As Column = Fg.Cols(24)
            c20.DataType = GetType(String)

            Fg(0, 25) = "Fax"
            Dim c21 As Column = Fg.Cols(25)
            c21.DataType = GetType(String)

            Fg(0, 26) = "Pagina web"
            Dim c22 As Column = Fg.Cols(26)
            c22.DataType = GetType(String)

            Fg(0, 27) = "Zona"
            Dim c24 As Column = Fg.Cols(27)
            c24.DataType = GetType(String)

            Fg(0, 28) = "Imprimit"
            Dim c25 As Column = Fg.Cols(28)
            c25.DataType = GetType(String)

            Fg(0, 29) = "Correo"
            Dim c26 As Column = Fg.Cols(29)
            c26.DataType = GetType(String)

            Fg(0, 30) = "Nivel"
            Dim c27 As Column = Fg.Cols(30)
            c27.DataType = GetType(Int32)

            Fg(0, 31) = "Envios"
            Dim c28 As Column = Fg.Cols(31)
            c28.DataType = GetType(String)

            Fg(0, 32) = "Correo pred."
            Dim c29 As Column = Fg.Cols(32)
            c29.DataType = GetType(String)

            Fg(0, 33) = "Dias revisión"
            Dim c30 As Column = Fg.Cols(33)
            c30.DataType = GetType(String)

            Fg(0, 34) = "Dias pago"
            Dim c31 As Column = Fg.Cols(34)
            c31.DataType = GetType(String)

            Fg(0, 35) = "Con crédito"
            Dim c32 As Column = Fg.Cols(35)
            c32.DataType = GetType(String)

            Fg(0, 36) = "Dias crédito"
            Dim c33 As Column = Fg.Cols(36)
            c33.DataType = GetType(Int32)

            Fg(0, 37) = "Límite de crédito"
            Dim c34 As Column = Fg.Cols(37)
            c34.DataType = GetType(Decimal)
            Fg.Cols(37).Format = "###,###,##0.00"

            Fg(0, 38) = "Lista precios"
            Dim c35 As Column = Fg.Cols(38)
            c35.DataType = GetType(Int32)

            Fg(0, 39) = "Bitacora"
            Dim c36 As Column = Fg.Cols(39)
            c36.DataType = GetType(Int32)

            Fg(0, 40) = "Ult. pogo"
            Dim c37 As Column = Fg.Cols(40)
            c37.DataType = GetType(String)

            Fg(0, 41) = "Ult. monto pago"
            Dim c38 As Column = Fg.Cols(41)
            c38.DataType = GetType(Decimal)
            Fg.Cols(41).Format = "###,###,##0.00"

            Fg(0, 42) = "Fecha ult. pago"
            Dim c39 As Column = Fg.Cols(42)
            c39.DataType = GetType(DateTime)

            Fg(0, 43) = "Descuento"
            Dim c40 As Column = Fg.Cols(43)
            c40.DataType = GetType(Decimal)
            Fg.Cols(43).Format = "###,###,##0.00"

            Fg(0, 44) = "Documento ult. venta"
            Dim c41 As Column = Fg.Cols(44)
            c41.DataType = GetType(String)

            Fg(0, 45) = "Monto ult. compra"
            Dim c42 As Column = Fg.Cols(45)
            c42.DataType = GetType(Decimal)
            Fg.Cols(45).Format = "###,###,##0.00"

            Fg(0, 46) = "Fecha ult. compra"
            Dim c43 As Column = Fg.Cols(46)
            c43.DataType = GetType(DateTime)

            Fg(0, 47) = "Ventas"
            Dim c44 As Column = Fg.Cols(47)
            c44.DataType = GetType(Decimal)
            Fg.Cols(47).Format = "###,###,##0.00"

            Fg(0, 48) = "Vendedor"
            Dim c45 As Column = Fg.Cols(48)
            c45.DataType = GetType(String)

            Fg(0, 49) = "Observaciones"
            Dim c46 As Column = Fg.Cols(49)
            c46.DataType = GetType(Int32)

            Fg(0, 50) = "Tipo empresa"
            Dim c47 As Column = Fg.Cols(50)
            c47.DataType = GetType(String)

            Fg(0, 51) = "Matriz"
            Dim c48 As Column = Fg.Cols(51)
            c48.DataType = GetType(String)

            Fg(0, 52) = "Prospecto"
            Dim c49 As Column = Fg.Cols(52)
            c49.DataType = GetType(String)

            Fg(0, 53) = "Dirección envio"
            Dim c50 As Column = Fg.Cols(53)
            c50.DataType = GetType(String)

            Fg(0, 54) = "Num. int. envio"
            Dim c51 As Column = Fg.Cols(54)
            c51.DataType = GetType(String)

            Fg(0, 55) = "Num. ext. envio"
            Dim c52 As Column = Fg.Cols(55)
            c52.DataType = GetType(String)

            Fg(0, 56) = "Cruzamientos envio"
            Dim c53 As Column = Fg.Cols(56)
            c53.DataType = GetType(String)

            Fg(0, 57) = "Cruzamientos envio 2"
            Dim c54 As Column = Fg.Cols(57)
            c54.DataType = GetType(String)

            Fg(0, 58) = "Coloni envio"
            Dim c55 As Column = Fg.Cols(58)
            c55.DataType = GetType(String)

            Fg(0, 59) = "Localidad envio"
            Dim c56 As Column = Fg.Cols(59)
            c56.DataType = GetType(String)

            Fg(0, 60) = "Municipio envio"
            Dim c57 As Column = Fg.Cols(60)
            c57.DataType = GetType(String)

            Fg(0, 61) = "Estado envio"
            Dim c58 As Column = Fg.Cols(61)
            c58.DataType = GetType(String)

            Fg(0, 62) = "Pais envio"
            Dim c59 As Column = Fg.Cols(62)
            c59.DataType = GetType(String)

            Fg(0, 63) = "Código envio"
            Dim c60 As Column = Fg.Cols(63)
            c60.DataType = GetType(String)

            Fg(0, 64) = "Zona envio"
            Dim c61 As Column = Fg.Cols(64)
            c61.DataType = GetType(String)

            Fg(0, 65) = "Referencia envio"
            Dim c62 As Column = Fg.Cols(65)
            c62.DataType = GetType(String)

            Fg(0, 66) = "Cuenta contable"
            Dim c63 As Column = Fg.Cols(66)
            c63.DataType = GetType(String)

            Fg(0, 67) = "Adenda"
            Dim c64 As Column = Fg.Cols(67)
            c64.DataType = GetType(String)
            c64.Visible = False

            Fg(0, 68) = "Adenda"
            Dim c65 As Column = Fg.Cols(68)
            c65.DataType = GetType(String)
            c65.Visible = False

            Fg(0, 69) = "Name space"
            Dim c66 As Column = Fg.Cols(69)
            c66.DataType = GetType(String)
            c66.Visible = False

            Fg(0, 70) = "Metodo de pago"
            Dim c67 As Column = Fg.Cols(70)
            c67.DataType = GetType(String)

            Fg(0, 71) = "Num. cta. pago"
            Dim c68 As Column = Fg.Cols(71)
            c68.DataType = GetType(String)

            Fg(0, 72) = "Modelo"
            Dim c69 As Column = Fg.Cols(72)
            c69.DataType = GetType(String)

            Fg(0, 73) = "Desc. impu1"
            Dim c70 As Column = Fg.Cols(73)
            c70.DataType = GetType(String)
            c70.Visible = False

            Fg(0, 74) = "Desc. impu2"
            Dim c71 As Column = Fg.Cols(74)
            c71.DataType = GetType(String)
            c71.Visible = False

            Fg(0, 75) = "Desc. impu3"
            Dim c72 As Column = Fg.Cols(75)
            c72.DataType = GetType(String)
            c72.Visible = False

            Fg(0, 76) = "Desc. impu4"
            Dim c73 As Column = Fg.Cols(76)
            c73.DataType = GetType(String)
            c73.Visible = False

            Fg(0, 77) = "DES_PER"
            Dim c74 As Column = Fg.Cols(77)
            c74.DataType = GetType(String)
            c74.Visible = False

            Fg(0, 78) = "LAT_GENERAL"
            Dim c75 As Column = Fg.Cols(78)
            c75.DataType = GetType(Decimal)
            Fg.Cols(78).Format = "###,###,##0.00"
            c75.Visible = False

            Fg(0, 79) = "LON_GENERAL"
            Dim c76 As Column = Fg.Cols(79)
            c76.DataType = GetType(Decimal)
            Fg.Cols(79).Format = "###,###,##0.00"
            c76.Visible = False

            Fg(0, 80) = "LAT_ENVIO"
            Dim c77 As Column = Fg.Cols(80)
            c77.DataType = GetType(Decimal)
            Fg.Cols(80).Format = "###,###,##0.00"
            c77.Visible = False

            Fg(0, 81) = "LON_ENVIO"
            Dim c78 As Column = Fg.Cols(81)
            c78.DataType = GetType(Decimal)
            Fg.Cols(81).Format = "###,###,##0.00"
            c78.Visible = False

            Fg(0, 82) = "Cve. pais SAT"
            Dim c80 As Column = Fg.Cols(82)
            c80.DataType = GetType(String)

            Fg(0, 83) = "Num. id Reg. fiscal"
            Dim c81 As Column = Fg.Cols(83)
            c81.DataType = GetType(String)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    MNUEliminarCliente_Click(Nothing, Nothing)
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

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "CLIENTES")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEstadoCtaClie_Click(sender As Object, e As EventArgs) Handles BarEstadoCtaClie.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 1)
                Var5 = Fg(Fg.Row, 3)
                Var49 = IIf(IsDBNull(Fg(Fg.Row, 9)), 0, Fg(Fg.Row, 9))

                FrmEdoCuentaCliente.ShowDialog()

                If PASS_GRUPOCE <> "BUS" Then
                    DESPLEGAR()
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BarAltaCxC.Click
        frmRecepcionPagosCxC.ShowDialog()
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click

    End Sub
End Class
