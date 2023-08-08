Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar
Imports C1.Win.C1FlexGrid
Public Class FrmProv
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

            DialogOK = ""
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(BarEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(BarraMenu, "F5 - Salir")

            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 56

            Fg.Rows(0).Height = 40

            Fg.Dock = DockStyle.Fill

            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - 150

            If Not pwPoder Then
                DERECHOS()
            End If
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DERECHOS()
        Try
            Dim z As Integer = 0
            BarNuevo.Visible = False
            BarEdit.Visible = False
            BarEliminar.Visible = False

            SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE > 10500 AND CLAVE < 11000"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Select Case dr("CLAVE")
                            Case 10530
                                BarNuevo.Visible = True
                            Case 10560
                                BarEdit.Visible = True
                            Case 10590
                                BarEliminar.Visible = True
                        End Select
                        z = z + 1
                    End While
                End Using
            End Using
            If z = 0 Then
                BarNuevo.Visible = True
                BarEdit.Visible = True
                BarEliminar.Visible = True
            End If
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try

            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT CLAVE, STATUS, NOMBRE, RFC, SALDO, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO, LOCALIDAD, MUNICIPIO, ESTADO,
                CVE_PAIS, NACIONALIDAD, TELEFONO, CLASIFIC, FAX, PAG_WEB, CURP, CVE_ZONA, CON_CREDITO, DIASCRED, LIMCRED, CVE_BITA, ULT_PAGOD, ULT_PAGOM,
                ULT_PAGOF, ULT_COMPD, ULT_COMPM, ULT_COMPF, VENTAS, DESCUENTO, TIP_TERCERO, TIP_OPERA, CVE_OBS, CUENTA_CONTABLE, FORMA_PAGO, BENEFICIARIO,
                TITULAR_CUENTA, BANCO, SUCURSAL_BANCO, CUENTA_BANCO, CLABE, DESC_OTROS, IMPRIR, MAIL, NIVELSEC, ENVIOSILEN, EMAILPRED, MODELO, LAT, LON
                FROM PROV" & Empresa & " ORDER BY CLAVE"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            'cmd.CommandText = SQL
            'dr = cmd.ExecuteReader
            'Fg.Rows.Count = 1
            'Do While dr.Read
            'Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("STATUS") & vbTab & dr("NOMBRE") & vbTab & dr("RFC") & vbTab & dr("CALLE") & vbTab & dr("NUMINT") & vbTab & dr("NUMEXT") & vbTab & dr("CRUZAMIENTOS") & vbTab & dr("CRUZAMIENTOS2") & vbTab & dr("COLONIA") & vbTab & dr("CODIGO") & vbTab & dr("LOCALIDAD") & vbTab & dr("MUNICIPIO") & vbTab & dr("ESTADO") & vbTab & dr("CVE_PAIS") & vbTab & dr("NACIONALIDAD") & vbTab & dr("TELEFONO") & vbTab & dr("CLASIFIC") & vbTab & dr("FAX") & vbTab & dr("PAG_WEB") & vbTab & dr("CURP") & vbTab & dr("CVE_ZONA") & vbTab & dr("CON_CREDITO") & vbTab & dr("DIASCRED") & vbTab & dr("LIMCRED") & vbTab & dr("CVE_BITA") & vbTab & dr("ULT_PAGOD") & vbTab & dr("ULT_PAGOM") & vbTab & dr("ULT_PAGOF") & vbTab & dr("ULT_COMPD") & vbTab & dr("ULT_COMPM") & vbTab & dr("ULT_COMPF") & vbTab & dr("SALDO") & vbTab & dr("VENTAS") & vbTab & dr("DESCUENTO") & vbTab & dr("TIP_TERCERO") & vbTab & dr("TIP_OPERA") & vbTab & dr("CVE_OBS") & vbTab & dr("CUENTA_CONTABLE") & vbTab & dr("FORMA_PAGO") & vbTab & dr("BENEFICIARIO") & vbTab & dr("TITULAR_CUENTA") & vbTab & dr("BANCO") & vbTab & dr("SUCURSAL_BANCO") & vbTab & dr("CUENTA_BANCO") & vbTab & dr("CLABE") & vbTab & dr("DESC_OTROS") & vbTab & dr("IMPRIR") & vbTab & dr("MAIL") & vbTab & dr("NIVELSEC") & vbTab & dr("ENVIOSILEN") & vbTab & dr("EMAILPRED") & vbTab & dr("MODELO") & vbTab & dr("LAT") & vbTab & dr("LON"))
            'Loop
            'dr.Close()
            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "NOMBRE"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "RFC"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "SALDO"
            Dim c33 As Column = Fg.Cols(5)
            c33.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "Dirección"
            Dim c5 As Column = Fg.Cols(6)
            c5.DataType = GetType(String)

            Fg(0, 7) = "NUMINT"
            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(String)

            Fg(0, 8) = "NUMEXT"
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(String)

            Fg(0, 9) = "CRUZAMIENTOS"
            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(String)

            Fg(0, 10) = "CRUZAMIENTOS2"
            Dim c9 As Column = Fg.Cols(10)
            c9.DataType = GetType(String)

            Fg(0, 11) = "COLONIA"
            Dim c10 As Column = Fg.Cols(11)
            c10.DataType = GetType(String)

            Fg(0, 12) = "CODIGO"
            Dim c11 As Column = Fg.Cols(12)
            c11.DataType = GetType(String)

            Fg(0, 13) = "LOCALIDAD"
            Dim c12 As Column = Fg.Cols(13)
            c12.DataType = GetType(String)

            Fg(0, 14) = "MUNICIPIO"
            Dim c13 As Column = Fg.Cols(14)
            c13.DataType = GetType(String)

            Fg(0, 15) = "ESTADO"
            Dim c14 As Column = Fg.Cols(15)
            c14.DataType = GetType(String)

            Fg(0, 16) = "CVE_PAIS"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(String)

            Fg(0, 17) = "NACIONALIDAD"
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(String)

            Fg(0, 18) = "TELEFONO"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(String)

            Fg(0, 19) = "CLASIFIC"
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(String)

            Fg(0, 20) = "FAX"
            Dim c19 As Column = Fg.Cols(20)
            c19.DataType = GetType(String)

            Fg(0, 21) = "PAG_WEB"
            Dim c20 As Column = Fg.Cols(21)
            c20.DataType = GetType(String)

            Fg(0, 22) = "CURP"
            Dim c21 As Column = Fg.Cols(22)
            c21.DataType = GetType(String)

            Fg(0, 23) = "CVE_ZONA"
            Dim c22 As Column = Fg.Cols(23)
            c22.DataType = GetType(String)

            Fg(0, 24) = "CON_CREDITO"
            Dim c23 As Column = Fg.Cols(24)
            c23.DataType = GetType(String)

            Fg(0, 25) = "DIASCRED"
            Dim c24 As Column = Fg.Cols(25)
            c24.DataType = GetType(Int32)

            Fg(0, 26) = "LIMCRED"
            Dim c25 As Column = Fg.Cols(26)
            c25.DataType = GetType(Decimal)
            Fg.Cols(26).Format = "###,###,##0.00"

            Fg(0, 27) = "CVE_BITA"
            Dim c26 As Column = Fg.Cols(27)
            c26.DataType = GetType(Int32)

            Fg(0, 28) = "ULT_PAGOD"
            Dim c27 As Column = Fg.Cols(28)
            c27.DataType = GetType(String)

            Fg(0, 29) = "ULT_PAGOM"
            Dim c28 As Column = Fg.Cols(29)
            c28.DataType = GetType(Decimal)
            Fg.Cols(29).Format = "###,###,##0.00"

            Fg(0, 30) = "ULT_PAGOF"
            Dim c29 As Column = Fg.Cols(30)
            c29.DataType = GetType(DateTime)

            Fg(0, 31) = "ULT_COMPD"
            Dim c30 As Column = Fg.Cols(31)
            c30.DataType = GetType(String)

            Fg(0, 32) = "ULT_COMPM"
            Dim c31 As Column = Fg.Cols(32)
            c31.DataType = GetType(Decimal)
            Fg.Cols(31).Format = "###,###,##0.00"

            Fg(0, 33) = "ULT_COMPF"
            Dim c32 As Column = Fg.Cols(33)
            c32.DataType = GetType(DateTime)


            Fg(0, 34) = "VENTAS"
            Dim c34 As Column = Fg.Cols(34)
            c34.DataType = GetType(Decimal)
            Fg.Cols(34).Format = "###,###,##0.00"

            Fg(0, 35) = "DESCUENTO"
            Dim c35 As Column = Fg.Cols(35)
            c35.DataType = GetType(Decimal)
            Fg.Cols(35).Format = "###,###,##0.00"

            Fg(0, 36) = "TIP_TERCERO"
            Dim c36 As Column = Fg.Cols(36)
            c36.DataType = GetType(Int32)

            Fg(0, 37) = "TIP_OPERA"
            Dim c37 As Column = Fg.Cols(37)
            c37.DataType = GetType(Int32)

            Fg(0, 38) = "CVE_OBS"
            Dim c38 As Column = Fg.Cols(38)
            c38.DataType = GetType(Int32)

            Fg(0, 39) = "CUENTA_CONTABLE"
            Dim c39 As Column = Fg.Cols(39)
            c39.DataType = GetType(String)

            Fg(0, 40) = "FORMA_PAGO"
            Dim c40 As Column = Fg.Cols(40)
            c40.DataType = GetType(Int32)

            Fg(0, 41) = "BENEFICIARIO"
            Dim c41 As Column = Fg.Cols(41)
            c41.DataType = GetType(String)

            Fg(0, 42) = "TITULAR_CUENTA"
            Dim c42 As Column = Fg.Cols(42)
            c42.DataType = GetType(String)

            Fg(0, 43) = "BANCO"
            Dim c43 As Column = Fg.Cols(43)
            c43.DataType = GetType(String)

            Fg(0, 44) = "SUCURSAL_BANCO"
            Dim c44 As Column = Fg.Cols(44)
            c44.DataType = GetType(String)

            Fg(0, 45) = "CUENTA_BANCO"
            Dim c45 As Column = Fg.Cols(45)
            c45.DataType = GetType(String)

            Fg(0, 46) = "CLABE"
            Dim c46 As Column = Fg.Cols(46)
            c46.DataType = GetType(String)

            Fg(0, 47) = "DESC_OTROS"
            Dim c47 As Column = Fg.Cols(47)
            c47.DataType = GetType(String)

            Fg(0, 48) = "IMPRIR"
            Dim c48 As Column = Fg.Cols(48)
            c48.DataType = GetType(String)

            Fg(0, 49) = "MAIL"
            Dim c49 As Column = Fg.Cols(49)
            c49.DataType = GetType(String)

            Fg(0, 50) = "NIVELSEC"
            Dim c50 As Column = Fg.Cols(50)
            c50.DataType = GetType(Int32)

            Fg(0, 51) = "ENVIOSILEN"
            Dim c51 As Column = Fg.Cols(51)
            c51.DataType = GetType(String)

            Fg(0, 52) = "EMAILPRED"
            Dim c52 As Column = Fg.Cols(52)
            c52.DataType = GetType(String)

            Fg(0, 53) = "MODELO"
            Dim c53 As Column = Fg.Cols(53)
            c53.DataType = GetType(String)

            Fg(0, 54) = "LAT"
            Dim c54 As Column = Fg.Cols(54)
            c54.DataType = GetType(Decimal)
            Fg.Cols(54).Format = "###,###,##0.00"

            Fg(0, 55) = "LON"
            Dim c55 As Column = Fg.Cols(55)
            c55.DataType = GetType(Decimal)
            Fg.Cols(55).Format = "###,###,##0.00"
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            'frmProvAE.ShowDialog()
            CREA_TAB(frmProvAE, "Proveedores ")
            'DESPLEGAR()
        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmProv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Proveedores")
        Me.Dispose()
    End Sub

    Private Sub frmProv_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then
                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 1)
                'frmProvAE.Show()
                CREA_TAB(frmProvAE, "Proveedores ")
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE PROV" & Empresa & " SET STATUS = 'B' WHERE CVE_OBS = '" & Fg(Fg.Row, 1) & "'"
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
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()

    End Sub

    Private Sub frmEstadoCuenta_Click(sender As Object, e As EventArgs) Handles frmEstadoCuenta.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 1)
                Var5 = Fg(Fg.Row, 3)
                Var49 = Fg(Fg.Row, 5)

                frmEdoCuentaProv.ShowDialog()

                DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BatCxP_Click(sender As Object, e As EventArgs) Handles BatCxP.Click
        frmRecepcionPagosCompras.ShowDialog()
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub
End Class
