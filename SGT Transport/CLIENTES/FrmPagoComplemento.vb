Imports Stimulsoft.Report
Imports System.IO
Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmPagoComplemento
    Dim CADENA As String = ""
    Private EMISOR_RFC As String = ""
    Private EMISOR_NOMBRE As String = ""
    Private RUTA_PDF As String

    Dim MULTIALMACEN As Integer
    Dim TIPO_VENTA_LOCAL As String '= TIPO_VENTA
    Dim TOP_REG As String = " TOP 500"
    Private TXTS1 As C1.Win.C1Input.C1ComboBox
    'Private cb1Event As EventHandler = AddressOf cbx_SelectedIndexChanged
    'Private searchButton As New Button  = TryCast(C1FlexGridSearchPanel1.Controls(2), ButtonBase)
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmPagoComplemento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos2, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then
                BarDisenador.Visible = True
            End If
        Catch ex As Exception
        End Try

        TXTS1 = TryCast(C1FlexGridSearchPanel1.Controls(0), C1.Win.C1Input.C1ComboBox)

        AddHandler TXTS1.KeyDown, AddressOf TXTS1_KeyDown

        For k = 0 To C1FlexGridSearchPanel1.Controls.Count - 1
            If C1FlexGridSearchPanel1.Controls(k).Name = "" Then

            End If
        Next

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        EMISOR_RFC = dr("EMISOR_RFC")
                        EMISOR_NOMBRE = dr("EMISOR_RAZON_SOCIAL")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Me.KeyPreview = True

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTS1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 40 Then
            Fg.Focus()
        End If
    End Sub
    Private Sub FrmPagoComplemento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Complemento de pago")
        Me.Dispose()
    End Sub
    Sub DERECHOS()
        Dim z As Integer

        If pwPoder Then
            Try
                barNueva.Visible = True
                barModificar.Visible = True
                BarExcel.Visible = True
            Catch ex As Exception
            End Try
        Else
            Try
                barNueva.Visible = False
                barModificar.Visible = False
                BarExcel.Visible = False
            Catch ex As Exception
            End Try
            Try

                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE > 60100 AND CLAVE < 70000"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 60101
                                    barNueva.Visible = True
                                Case 60130
                                    barModificar.Visible = True
                                Case 60160
                                    BarExcel.Visible = True
                            End Select
                            z = z + 1
                        End While
                    End Using
                End Using
                If z = 0 Then
                End If
                Try
                    'C1FlexGridSearchPanel1.ActiveControl.Text = ""
                Catch ex As Exception
                End Try
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
            SQL = "SELECT " & TOP_REG & " F.CVE_DOC, F.CLIENTE, NOMBRE, F.RFC, 
                CASE F.ESTATUS WHEN 'T' THEN 'Timbrada' WHEN 'P' THEN 'Pendiente' WHEN 'C' THEN 'Cancelada' END AS ST, F.IMPORTE,
                F.FECHAELAB, F.FECHA_CANCEL, FECHA_TIMBRADO, F.VERSION, ISNULL(CODIGO,'') AS CODI, ISNULL(REG_FISC,'') AS REGFISCAL,
                ISNULL(P.EMAILPRED,'') AS CORREO
                FROM CFDI_COMPAGO F
                LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE  = F.CLIENTE " &
                CADENA & " ORDER BY F.FECHAELAB DESC"

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg(0, 1) = "Factura digital"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Cliente"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "R.F.C."
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Estatus"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)
            'c1.TextAlign = TextAlignEnum.CenterCenter

            Fg(0, 6) = "Importe"
            Dim c66 As Column = Fg.Cols(6)
            c66.DataType = GetType(Decimal)
            c66.Format = "N2"

            Fg(0, 7) = "Fecha elab."
            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(DateTime)
            c6.Format = "G"

            Fg(0, 8) = "Fecha cancelación"
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(DateTime)
            c7.Format = "G"

            Fg(0, 9) = "Fecha timbrado"
            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(DateTime)

            Fg(0, 10) = "Versión CFDI"
            Dim c9 As Column = Fg.Cols(10)
            c9.DataType = GetType(String)

            Fg(0, 11) = "CP"
            Dim c10 As Column = Fg.Cols(11)
            c10.DataType = GetType(String)

            Fg(0, 12) = "Régimen fiscal"
            Dim c11 As Column = Fg.Cols(12)
            c11.DataType = GetType(String)

            Fg(0, 13) = "Correo"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(String)

            'Fg.Cols(1).Width = 110 : Fg.Cols(2).Width = 50 : Fg.Cols(4).Width = 60 : Fg.Cols(5).Width = 100 : Fg.Cols(6).Width = 90 : Fg.Cols(7).Width = 70
            'Fg.Cols(8).Width = 70
            'Fg.Cols(5).TextAlign = TextAlignEnum.LeftCenter

            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            Fg.Subtotal(AggregateEnum.Clear)
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 6, "Grand Total")

            Fg.AutoSizeCols()

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNueva_Click(sender As Object, e As EventArgs) Handles barNueva.Click
        Try
            Try
                Var11 = "nueva"
                CREA_TAB(FrmPagoComplementoAE, "Pago complemento")
            Catch ex As Exception
                Bitacora("75. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarModificar_Click(sender As Object, e As EventArgs) Handles barModificar.Click
        Try
            If Fg.Row > 0 Then

                Var11 = "edit"
                Var12 = Fg(Fg.Row, 1) 'REFER

                CREA_TAB(FrmPagoComplementoAE, "Pago complemento")
            End If
        Catch ex As Exception
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles barRefresh.Click

        TOP_REG = " TOP 500 "
        CADENA = ""
        DESPLEGAR()

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Complemeto de pagos")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub

    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        Try

            TOP_REG = ""
            CADENA = " WHERE F.FECHA = '" & FSQL(Date.Now) & "'"
            DESPLEGAR()

            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-1)
            TOP_REG = " "
            CADENA = " WHERE FECHA = '" & FSQL(dt) & "'"
            DESPLEGAR()

            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Try
            Dim dt As DateTime = Date.Today

            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

            TOP_REG = " "
            CADENA = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Try
            Dim dt As DateTime = Date.Today

            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

            dt = dt.AddMonths(-1)
            TOP_REG = ""
            CADENA = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        Try
            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

            CADENA = ""
            TOP_REG = ""
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                barModificar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            MsgBox("325. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("325. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnDesplegar_Click(sender As Object, e As EventArgs) Handles btnDesplegar.Click
        Try
            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

            CADENA = " WHERE F.FECHA >=' " & FSQL(F1.Value) & "' AND F.FECHA <=' " & FSQL(F2.Value) & "'"
            TOP_REG = ""
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Dim cs1 As CellStyle
        cs1 = Fg.Styles.Add("CS1")
        cs1.BackColor = Color.LightGreen

        Dim cs2 As CellStyle
        cs2 = Fg.Styles.Add("CS2")
        cs2.BackColor = Color.Red


        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

            Select Case Fg(e.Row, 5)
                Case "Pendiente"
                    Fg.SetCellStyle(e.Row, 5, cs1)
                Case "Cancelada"
                    Fg.SetCellStyle(e.Row, 5, cs2)
                Case "Timbrada"
                    'BarTimbrar.Visible = False
            End Select
        End If
    End Sub
    Private Sub FrmPagoComplemento_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = 27 Then
                TXTS1.Items.Clear()

                TXTS1.Focus()
            End If
        Catch ex As Exception
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarTimbrar_Click(sender As Object, e As EventArgs) Handles BarTimbrar.Click
        Try            ' INICA PROCESO DE TIMBRAR 
            If Fg.Row > 0 Then

                Try
                    Select Case Fg(Fg.Row, 5)
                        Case "Pendiente"

                        Case "Cancelada"
                            MsgBox("El documento ya se encuentra cancelado, verifique por favor")
                            Return
                        Case "Timbrada"
                            MsgBox("El documento ya se encuentra timbrado verifique por favor")
                            Return
                    End Select
                Catch ex As Exception
                End Try

                If MsgBox("Realmente desea timbrar el documento " & Fg(Fg.Row, 1) & "?", vbYesNo) = vbNo Then
                    Return
                End If

                FrmTimbrarCdeP.LtNombre.Text = Fg(Fg.Row, 3)
                FrmTimbrarCdeP.LtRFC.Text = Fg(Fg.Row, 4)
                FrmTimbrarCdeP.LtUSO_CFDI.Text = "CP01"
                FrmTimbrarCdeP.LtRegimenReceptor.Text = Fg(Fg.Row, 12)
                FrmTimbrarCdeP.LtCP.Text = Fg(Fg.Row, 11)

                Var4 = Fg(Fg.Row, 1)

                Var17 = ""

                PassData1 = "PAGO COMPLEMENTO"
                FrmTimbrarCdeP.ShowDialog()

                If Var17.Trim.Length > 0 Then
                    DESPLEGAR()
                End If
            Else
                MsgBox("Por favor seleccione un documento")
            End If
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarConsultaSATStatus_Click(sender As Object, e As EventArgs) Handles BarConsultaSATStatus.Click

        If Fg.Row = 0 Then
            MsgBox("Por favor seleccione un documento")
            Return

        End If

        PassData1 = "PAGO COMPLEMENTO"

        Var2 = Fg(Fg.Row, 1) 'DOCUMENTO
        Var3 = EMISOR_NOMBRE
        Var4 = EMISOR_RFC
        Var5 = Fg(Fg.Row, 4) 'RFC RECEPTOR
        Var6 = Fg(Fg.Row, 3) 'NOMBRE RECEPTOR

        FrmEstatusCFDI.ShowDialog()

    End Sub

    Private Sub BarCancelarPagoCFDI_Click(sender As Object, e As EventArgs) Handles BarCancelarPagoCFDI.Click
        Try
            If Fg.Row > 0 Then

                If MsgBox("Realmente desea cancelar el pago CFDI del documento " & Fg(Fg.Row, 1) & "?", vbYesNo) = vbNo Then
                    Return
                End If


                If Fg(Fg.Row, 3) = "Cancelada" Then
                    MsgBox("la carta porte ya se encuentra cancelada, verifique por favor")
                    Return
                End If

                Var2 = Fg(Fg.Row, 1) 'CVE_DOC
                Var25 = Fg(Fg.Row, 2) 'cliente
                Var3 = Fg(Fg.Row, 5) 'estatus

                Var17 = ""
                FrmCFDICancPago.ShowDialog()

                If Var17.Trim.Length > 0 Then
                    DESPLEGAR()
                End If

            Else
                MsgBox("Por favor seleccione un complemento de pago")
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCancelarDocumento_Click(sender As Object, e As EventArgs) Handles BarCancelarDocumento.Click

        If Fg.Row > 0 Then
            If MsgBox("Realmente desea cancelar el documento " & Fg(Fg.Row, 1) & "?", vbYesNo) = vbNo Then
                Return
            End If

            Try
                Select Case Fg(Fg.Row, 5)
                    Case "Pendiente"

                    Case "Cancelada"
                        MsgBox("El documento ya se encuentra cancelado, verifique por favor")
                        Return
                    Case "Timbrada"
                        MsgBox("El documento ya se encuentra timbrado debe ir ala opcion cancedlar pago CFDI")
                        Return
                End Select

                Dim FECHA_CAN As String

                FECHA_CAN = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss")

                SQL = "UPDATE CFDI_COMPAGO SET ESTATUS = 'C', FECHA_CANCEL = @FECHA_CANCEL, XML_CANC = @XML_CANC,
                    OBS_CANC = @OBS_CANC 
                    WHERE CVE_DOC = @CVE_DOC"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = Fg(Fg.Row, 1)
                    cmd.Parameters.Add("@XML_CANC", SqlDbType.VarChar).Value = ""
                    cmd.Parameters.Add("@FECHA_CANCEL", SqlDbType.VarChar).Value = FECHA_CAN
                    cmd.Parameters.Add("@OBS_CANC", SqlDbType.VarChar).Value = ""
                    cmd.Parameters.Add("@USUARIO_CANCELA", SqlDbType.VarChar).Value = USER_GRUPOCE
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
                'GCCFDI_COMPAGO_PAR_DR 
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT REFER FROM CFDI_COMPAGO_PAR_DR WHERE CVE_DOC = '" & Fg(Fg.Row, 1) & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            For z = 1 To 5
                                SQL = "UPDATE CUEN_DET" & Empresa & " SET CVE_DOC_COMPPAGO = '' WHERE REFER = @REFER"
                                Try
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        cmd2.Parameters.Clear()
                                        cmd2.Parameters.Add("@REFER", SqlDbType.VarChar).Value = dr("REFER")
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If CInt(returnValue) > 0 Then
                                            Exit For
                                        End If
                                    End Using
                                Catch ex As Exception
                                    BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
                                End Try
                                If Not Valida_Conexion() Then
                                End If
                            Next
                        End While
                    End Using
                End Using

                Fg(Fg.Row, 5) = "Cancelada"

                MsgBox("Documento cancelado correctamente")
            Catch ex As Exception
                MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            'BarTimbrar.Visible = True
            Select Case Fg(Fg.Row, 5)
                Case "Pendiente"
                    'BarCancelarPagoCFDI.Visible = True
                Case "Cancelada"
                    'BarTimbrar.Visible = False
                    'BarCancelarPagoCFDI.Visible = False
                Case "Timbrada"
                    'BarTimbrar.Visible = False
                    'BarCancelarPagoCFDI.Visible = True
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarEnviarPorCorreoComprobante_Click(sender As Object, e As EventArgs) Handles BarEnviarPorCorreoComprobante.Click
        Dim XML As String = "", FILE_XML As String = "", CVE_DOC As String = "", PDF As String = ""
        Dim ENVIAR_MAIL As String = "", CORREO_CLIENTE As String = "", NOMBRE_CLIENTE As String = ""

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        PassData6 = dr("CALLE") & ", Num. ext. " & dr("NUMEXT") & ", CP " & dr("CP")

                        EMISOR_RFC = dr("EMISOR_RFC")

                        gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                        gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO_CONPRECIOS")

                        gRutaCertificado = dr("FILE_CER") 'CERTIFICADO
                        gRutaPFX = dr("FILE_PFX").ToString '.KEY
                        gContraPFX = dr("PASS_PFX").ToString  'contrasena del certificado
                    End If
                End Using
            End Using
        Catch ex As Exception

            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            CVE_DOC = Fg(Fg.Row, 1)
            SQL = "SELECT XML FROM CFDI_COMPAGO WHERE CVE_DOC = '" & CVE_DOC & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML = dr("XML")
                    End If
                End Using
            End Using

            FILE_XML = gRutaXML_TIMBRADO & "\" & EMISOR_RFC & "-" & CVE_DOC & ".xml"

            File.WriteAllText(FILE_XML, XML)
            FILE_XML = gRutaXML_TIMBRADO & "\" & EMISOR_RFC & "-" & CVE_DOC & ".xml"

            IMPRIMIR_CFDI(CVE_DOC, "PDF")

            Var2 = Fg(Fg.Row, 1) 'DOCUMENTO
            Var3 = EMISOR_NOMBRE
            Var4 = EMISOR_RFC
            Var5 = Fg(Fg.Row, 4) 'RFC RECEPTOR
            Var6 = Fg(Fg.Row, 3) 'NOMBRE RECEPTOR

            Var7 = FILE_XML
            Var8 = RUTA_PDF
            Var9 = Fg(Fg.Row, 13) 'CORREO

            FrmCorreo.ShowDialog()

            If Var4 = "NO" Then
                Return
            End If

        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Sub IMPRIMIR_CFDI(FCVE_DOC As String, Optional FPDF As String = "")
        Try
            Dim XML As String, RUTA_DISCOC As String

            SQL = "SELECT XML FROM CFDI_COMPAGO WHERE CVE_DOC = '" & FCVE_DOC & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML = dr("XML")
                    Else
                        XML = ""
                    End If
                End Using
            End Using

            Try
                Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String

                RUTA_FORMATOS = GET_RUTA_FORMATOS()

                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDIPAGO.mrt"
                If Not File.Exists(ARCHIVO_MRT) Then
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    Return
                End If
                RUTA_PDF = RUTA_FORMATOS & "\ReportCFDIPAGO.PDF"
                Try
                    RUTA_DISCOC = "C:\TRANS PDF\SIN PRECIOS"
                    If Not Directory.Exists(RUTA_DISCOC) Then
                        Directory.CreateDirectory("C:\TRANS PDF")
                        Directory.CreateDirectory(RUTA_DISCOC)
                    End If
                Catch ex As Exception
                    RUTA_DISCOC = gRutaXML_TIMBRADO
                    BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                'QR = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?&id=91346FA9-B904-4CFB-95C8-8981989CBA6C&re=SCA920130LV3&rr=MOGM730513N54&tt=0.000000&fe=o7pPKA=="
                'QR = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?&id=" & uuid & "&re=SCA920130LV3&rr=MOGM730513N54&tt=0.000000&fe=o7pPKA=="

                StiReport1.Load(ARCHIVO_MRT)
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                           Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.ReportName = "Complemento de pago"

                StiReport1.Compile()
                StiReport1("CVE_DOC") = FCVE_DOC

                StiReport1.Render()
                If FPDF = "PDF" Then
                    StiReport1.ExportDocument(StiExportFormat.Pdf, RUTA_PDF)
                Else
                    StiReport1.Show()
                End If
            Catch ex As Exception
                MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDescargarXMLYPDF_Click(sender As Object, e As EventArgs) Handles BarDescargarXMLYPDF.Click
        Try
            If Fg.Rows.Selected.Count > 0 Then
                Try
                    Dim r_ As Row
                    For k = 0 To Fg.Rows.Selected.Count - 1
                        r_ = Fg.Rows.Selected(k)

                        FrmDescargarXmlPDF.C1List1.AddItem(Fg(r_.Index, 1) & ";" & Fg(r_.Index, 4))
                    Next
                    Var4 = "PAGO"
                    FrmDescargarXmlPDF.ShowDialog()
                Catch ex As Exception
                    Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                MsgBox("Por favor seleccione al menos un documento")
            End If
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarDisenador_Click(sender As Object, e As EventArgs) Handles BarDisenador.Click

        PrinterMRT("ReportCFDIPAGO")

    End Sub
End Class
