Imports C1.Win.C1Themes
Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmConciValesCombusAE
    Private IsNew As Boolean
    Private SERIE_CFDI As String = ""
    Private FOLIO_CFDI As Long = 0
    Private Cadena_gas As String = ""
    Private SERIE_COMP_CONCI_VAL_DIESEL As String

    Private Sub FrmConciValesCombusAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Me.CenterToScreen()
        Me.KeyPreview = True
        Fg.Rows.Count = 1
        Fg2.Rows.Count = 1

        C1SplitContainer1.SplitterWidth = 1
        Fg2.Rows(0).Height = 50
        Fg.Rows(0).Height = 50

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"
        F1.Value = Now


        Fg.Styles.Fixed.WordWrap = True
        Fg2.Styles.Fixed.WordWrap = True
        Fg.AutoClipboard = True
        Fg.ClipboardCopyMode = ClipboardCopyModeEnum.DataAndColumnHeaders
        Fg.Cols(12).Sort = C1.Win.C1FlexGrid.SortFlags.Ascending

        Fg.Cols(0).Width = 40
        Fg.Cols(2).Width = 40
        Fg.Cols(3).Width = 90
        Fg.Cols(4).Width = 160
        Fg.Cols(5).Width = 40
        Fg.Cols(6).Width = 200
        Fg.Cols(7).Width = 80
        Fg.Cols(8).Width = 80
        Fg.Cols(9).Width = 80
        Fg.Cols(10).Width = 80
        Fg.Cols(11).Width = 80
        Fg.Cols(12).Width = 0

        Fg2.Cols(2).Width = 40
        Fg2.Cols(3).Width = 90
        Fg2.Cols(4).Width = 160
        Fg2.Cols(5).Width = 40
        Fg2.Cols(6).Width = 200
        Fg2.Cols(7).Width = 80
        Fg2.Cols(8).Width = 80
        Fg2.Cols(9).Width = 80
        Fg2.Cols(10).Width = 80
        Fg2.Cols(11).Width = 80
        Fg2.Cols(12).Width = 80
        Fg2.Cols(13).Width = 0


        BtnProv.FlatStyle = FlatStyle.Flat
        BtnProv.FlatAppearance.BorderSize = 0
        BtnGas.FlatStyle = FlatStyle.Flat
        BtnGas.FlatAppearance.BorderSize = 0

        TCVE_COVC.Enabled = True
        TCVE_DOC.Enabled = True
        BarGrabar.Enabled = True
        BarGrabarXML.Visible = False
        F1.Enabled = True
        Fg.Enabled = True
        Fg2.Enabled = True
        BtnAgregar.Enabled = True
        BtnRegresar.Enabled = True
        TCVE_DOC.Tag = " "
        Me.Left = 10
        Me.Width = Screen.PrimaryScreen.Bounds.Width - 25


        If Var47.Trim.Length > 0 Then
            'TIENE VIAJE
            BarImprimirVehiUtil.Visible = False
            BarImprimir.Visible = True
        Else
            'ES UTILITARIO
            BarImprimirVehiUtil.Visible = True
            BarImprimir.Visible = False
        End If

        CARGA_PARAM_COMPRAS()

        If Var1 = "Nuevo" Then
            Try
                IsNew = True
                Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)
                Fg2.SetCellCheck(0, 1, CheckEnum.Unchecked)

                TCVE_COVC.Text = GET_MAX("GCCONCI_VALES_COMBUS", "CVE_COVC")
                TCVE_COVC.Enabled = False
                BarCancelar.Enabled = False
                BarCxP.Enabled = False
                TCVE_PROV.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE
                IsNew = False

                SQL = "SELECT C.CVE_COVC, C.CVE_DOC, C.CVE_PROV, C.FECHA_DOC, C.CVE_GAS, G.DESCR, ISNULL(C.STATUS,'') AS ST, ISNULL(C.SUBTOTAL,0) AS SUBTOTAL1, 
                    ISNULL(C.IVA,0) AS IVA1, ISNULL(C.NETO,0) AS NETO1, ISNULL(XML,'') AS F_XML
                    FROM GCCONCI_VALES_COMBUS C 
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = C.CVE_GAS
                    WHERE CVE_COVC = " & Convert.ToInt32(Var2)
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then

                    TCVE_COVC.Text = dr("CVE_COVC").ToString
                    TCVE_DOC.Text = dr("CVE_DOC").ToString
                    TCVE_PROV.Text = dr("CVE_PROV").ToString

                    LtProv.Text = BUSCA_CAT("Prov", TCVE_PROV.Text)

                    TCVE_DOC.Tag = dr("F_XML").ToString

                    F1.Value = dr("FECHA_DOC").ToString
                    tSUBTOTAL.Text = Format(Math.Round(dr("SUBTOTAL1"), 2), "###,###,##0.000")
                    tIVA.Text = Format(Math.Round(dr("IVA1"), 2), "###,###,##0.000")
                    tNETO.Text = Format(Math.Round(dr("NETO1"), 2), "###,###,##0.000")
                    'C.STATUS
                    Select Case dr("ST")
                        Case "C"
                            LtCanc.Text = "CANCELADA"
                        Case "F"
                            LtCanc.Text = "FACTURA CERRADA"
                            BarCxP.Enabled = True
                        Case "T"
                            LtCanc.Text = "CUENTAS POR PAGAR"
                        Case Else
                            LtCanc.Text = "ACTIVO"
                    End Select

                    DESPLEGAR_CONCI_VALES()
                Else
                    TCVE_DOC.Text = ""
                    F1.Value = Now
                    tSUBTOTAL.Text = 0
                    tIVA.Text = 0
                    tNETO.Text = 0
                End If
                dr.Close()

                TCVE_COVC.Enabled = False

                If LtCanc.Text = "ACTIVO" Then
                    'BLOQUE ACTIVADO POR TIPO DE STATUS
                    Ltg.Visible = True 'Leyenda Gasolinera
                    LtGas.Visible = True 'nombre de la gasolinera
                    BtnGas.Visible = True 'boton gasolinera

                    TCVE_PROV.Enabled = True
                    BarDesplegar.Enabled = True
                Else
                    'BLOQUE DESACTIVADO POR TIPO DE STATUS
                    Ltg.Visible = False 'Leyenda Gasolinera
                    LtGas.Visible = False 'nombre de la gasolinera
                    BtnGas.Visible = False 'boton gasolinera

                    TCVE_PROV.Enabled = False
                    BarDesplegar.Enabled = False
                End If


                If LtCanc.Text = "FACTURA CERRADA" Or LtCanc.Text = "CUENTAS POR PAGAR" Or LtCanc.Text = "CANCELADA" Then
                    TCVE_DOC.Enabled = False
                    F1.Enabled = False
                    'aqui
                    BarGrabar.Enabled = False

                    BarGrabarXML.Visible = True
                    BtnAgregar.Enabled = False
                    BtnRegresar.Enabled = False
                    BarDesplegar.Enabled = False
                    If LtCanc.Text = "FACTURA CERRADA" Or LtCanc.Text = "CUENTAS POR PAGAR" Then
                        BarCancelar.Enabled = True
                        BarCerrarFactura.Enabled = False
                    Else
                        BarCancelar.Enabled = False
                        BarCerrarFactura.Enabled = False
                    End If
                Else
                    Fg.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
                    Fg2.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
                    TCVE_DOC.Enabled = True
                End If
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Fg.Select()
            Fg.Focus()
        End If
        Fg.AllowSorting = True
    End Sub
    Sub CARGA_PARAM_COMPRAS()
        Try
            SQL = "SELECT ISNULL(SERIE_COMP_CONCI_VAL_DIESEL,'D') AS SER_CONC_VAL_DIE FROM GCPARAMCOMPRAS"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SERIE_COMP_CONCI_VAL_DIESEL = dr("SER_CONC_VAL_DIE")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("28. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("28. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_CONCI_VALES()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim z As Integer = 0
            Fg2.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT C.CVE_VIAJE, C.CVE_FOLIO, C.FECHA, C.SUBTOTAL, C.IVA, C.NETO, G.CVE_GAS, ISNULL(G.DESCR,'') AS NOMBRE_GAS,
                    ISNULL(LITROS,0) AS LTS_INICIALES, ISNULL(LITROS_REALES,0) AS LTS_REAL, A.OBS
                    FROM GCCONCI_VALES_COMBUS_PAR C
                    LEFT JOIN GCASIGNACION_VIAJE_VALES A ON A.FOLIO = C.CVE_FOLIO
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = C.CVE_GAS
                    WHERE ISNULL(C.STATUS,'A') <> 'C' AND C.CVE_COVC = '" & TCVE_COVC.Text & "' AND ISNULL(A.STATUS,'') <> 'C'
                    ORDER BY CVE_FOLIO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        z += 1 '                 1                    2                         3                     4                       5                        6
                        Fg2.AddItem(z & vbTab & "" & vbTab & dr("CVE_VIAJE") & vbTab & dr("CVE_FOLIO") & vbTab & dr("OBS") & vbTab & dr("CVE_GAS") & vbTab & dr("NOMBRE_GAS") & vbTab &
                                    dr("LTS_INICIALES") & vbTab & dr("LTS_REAL") & vbTab & dr("FECHA") & vbTab & dr("SUBTOTAL") & vbTab & dr("IVA") & vbTab & dr("NETO") & vbTab & z)
                        '                    7                           8                       9                      10                     11                  12
                    End While
                End Using
            End Using
            If z > 0 Then
                Dim SUBTOTAL As Decimal, IVA As Decimal, NETO As Decimal

                For k = 1 To Fg2.Rows.Count - 1
                    Fg2(k, 0) = k
                    SUBTOTAL += Fg2(k, 10)
                    IVA += Fg2(k, 10)
                    NETO += Fg2(k, 12)
                Next
                tSUBTOTAL.Text = Format(SUBTOTAL, "###,###,##0.00")
                tIVA.Text = Format(IVA, "###,###,##0.00")
                tNETO.Text = Format(NETO, "###,###,##0.00")

                DESPLEGAR_VALES_GAS("", z)
            End If

        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As EventArgs) Handles BarDesplegar.Click
        DESPLEGAR_VALES_GAS()
    End Sub

    Private Sub FrmConciValesCombusAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmConciValesCombusAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim SUBTOTAL As Decimal, IVA As Decimal, NETO As Decimal, XML As String = "", UUID_XML As String
        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        If Not Valida_Conexion() Then
            Return
        End If

        If TCVE_DOC.Text.Trim.Length = 0 Then
            MsgBox("La factura no debe quedar vacia, verifique por favor")
            Return
        End If

        If IsNew Then
            If Fg2.Rows.Count = 1 Then
                MsgBox("No a seleccionado ningún vale")
                Return
            End If
        End If

        If Fg2.Rows.Count = 1 Then
            TCVE_DOC.Text = ""
        End If

        Try
            If IsNumeric(tSUBTOTAL.Text.Replace(",", "")) Then
                SUBTOTAL = tSUBTOTAL.Text.Replace(",", "")
            End If
            If IsNumeric(tIVA.Text.Replace(",", "")) Then
                IVA = tIVA.Text.Replace(",", "")
            End If
            If IsNumeric(tNETO.Text.Replace(",", "")) Then
                NETO = tNETO.Text.Replace(",", "")
            End If

            XML = TCVE_DOC.Tag
            If XML.Length > 255 Then
                XML = XML.Substring(0, 255)
            End If
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "UPDATE GCCONCI_VALES_COMBUS SET CVE_DOC = @CVE_DOC, FECHA_DOC = @FECHA_DOC, SUBTOTAL = @SUBTOTAL,
            IVA = @IVA, NETO = @NETO, XML = @XML, SERIE_CFDI = @SERIE_CFDI, FOLIO_CFDI = @FOLIO_CFDI 
            WHERE CVE_COVC = @CVE_COVC
            IF @@ROWCOUNT = 0
            INSERT INTO GCCONCI_VALES_COMBUS (CVE_COVC, CVE_DOC, CVE_PROV, FECHA_DOC, STATUS, SUBTOTAL, IVA, NETO, XML, FECHA, 
            SERIE_CFDI, FOLIO_CFDI, FECHAELAB, UUID) VALUES (@CVE_COVC, @CVE_DOC, @CVE_PROV, @FECHA_DOC, 'A', @SUBTOTAL, @IVA, 
            @NETO, @XML, GETDATE(), @SERIE_CFDI, @FOLIO_CFDI, GETDATE(), NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_COVC", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_COVC.Text)
            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = TCVE_DOC.Text
            cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = TCVE_PROV.Text
            cmd.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = F1.Value
            'cmd.Parameters.Add("@CVE_GAS", SqlDbType.VarChar).Value = tCVE_GAS.Text
            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(SUBTOTAL, 6)
            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IVA, 6)
            cmd.Parameters.Add("@NETO", SqlDbType.Float).Value = Math.Round(NETO, 6)
            cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = XML
            cmd.Parameters.Add("@SERIE_CFDI", SqlDbType.VarChar).Value = SERIE_CFDI
            cmd.Parameters.Add("@FOLIO_CFDI", SqlDbType.Int).Value = FOLIO_CFDI
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                    GRABAR_PARTIDAS_VALES()
                    IsNew = False

                    If Not VERIFICAR_CAMPO_GRABADO("GCCONCI_VALES_COMBUS", "CVE_DOC", " WHERE CVE_COVC = " & CONVERTIR_TO_INT(TCVE_COVC.Text)) Then

                        Dim result = RJMessageBox.Show("No se logro grabar la factura, por favor vuelva a grabar la conciliación", "Advertencia", MessageBoxButtons.OK)

                    Else
                        MsgBox("El registro se grabo satisfactoriamente")
                    End If
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If

            Try
                'GRABANDO XML
                Dim RUTA_XML As String, ARCHIVO As String, RUTA_ACTUAL As String, FILE_XML As String

                ARCHIVO = TCVE_DOC.Tag.ToString
                FILE_XML = Path.GetFileName(ARCHIVO)

                If ARCHIVO.Trim.Length > 0 And FILE_XML.Trim.Length > 0 Then

                    RUTA_XML = OBTENER_RUTA_XML()
                    If RUTA_XML.Trim.Length = 0 Then
                        RUTA_XML = Application.StartupPath
                    End If

                    RUTA_ACTUAL = Path.GetDirectoryName(ARCHIVO)
                    UUID_XML = OBTENER_UUID_XML(ARCHIVO)

                    SQL = "UPDATE GCCOMPRAS SET UUID_XML = '" & UUID_XML & "', ARCHIVO_XML = '" & FILE_XML & "' 
                        WHERE TIPO_DOC = 'VD' AND CVE_DOC = '" & TCVE_DOC.Text & "'
                        IF @@ROWCOUNT = 0
                        INSERT INTO GCCOMPRAS (NUM_REG, TIPO_DOC, CVE_DOC, MODULO, UUID_XML, ARCHIVO_XML, UUID) VALUES(
                        ISNULL((SELECT MAX(NUM_REG) + 1 FROM GCCOMPRAS),1),'VD','" & TCVE_DOC.Text & "','" &
                        "CONCI. VALES COMBUSTIBLE','" & UUID_XML & "','" & FILE_XML & "',NEWID())"

                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Try
                                    FileCopy(ARCHIVO, RUTA_XML & "\" & FILE_XML)
                                Catch ex As Exception
                                    Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End Using
                Else
                    MsgBox("Por favor seleccione el XML")
                End If
            Catch ex As Exception
                Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                'MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_PARTIDAS_VALES()

        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand With {.Connection = cnSAE}
        'PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS
        Try
            Try
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_VIAJE, CVE_FOLIO FROM GCCONCI_VALES_COMBUS_PAR WHERE CVE_COVC = " & Convert.ToInt32(TCVE_COVC.Text)
                    cmd2.CommandText = SQL
                    Using dr As SqlDataReader = cmd2.ExecuteReader
                        While dr.Read
                            Try
                                SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET CONCILIADO = 0, ST_VALES = 'ACEPTADO', FACTURA = '' 
                                    WHERE CVE_VIAJE = '" & dr("CVE_VIAJE") & "' AND FOLIO = '" & dr("CVE_FOLIO") & "'"
                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                    cmd3.CommandText = SQL
                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("780. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("780. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("780. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("780. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            SQL = "DELETE FROM GCCONCI_VALES_COMBUS_PAR WHERE CVE_COVC = " & Convert.ToInt32(TCVE_COVC.Text)
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Not Valida_Conexion() Then
        End If

        SQL = "INSERT INTO GCCONCI_VALES_COMBUS_PAR (CVE_COVC, CVE_VIAJE, CVE_FOLIO, STATUS, FECHA, CVE_GAS, SUBTOTAL, IVA, NETO, UUID)
             VALUES(@CVE_COVC, @CVE_VIAJE, @CVE_FOLIO, 'A', @FECHA, @CVE_GAS, @SUBTOTAL, @IVA, @NETO, NEWID())"
        cmd.CommandText = SQL
        'PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    
        For k = 1 To Fg2.Rows.Count - 1

            Try

                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_COVC", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_COVC.Text)
                cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = Fg2(k, 2)
                cmd.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = Fg2(k, 3)
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = IIf(IsDate(Fg2(k, 8)), Fg2(k, 8), Now)
                cmd.Parameters.Add("@CVE_GAS", SqlDbType.VarChar).Value = Fg2(k, 4)
                cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg2(k, 10)), 6)
                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg2(k, 11)), 6)
                cmd.Parameters.Add("@NETO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg2(k, 12)), 6)
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            '             GCASIGNACION_VIAJE_VALES 
                            SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET CONCILIADO = 1, ST_VALES = 'CONCILIADO', FACTURA = '" & TCVE_DOC.Text & "' 
                                WHERE CVE_VIAJE = '" & Fg2(k, 2) & "' AND FOLIO = '" & Fg2(k, 3) & "'"
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                        Try  'SI NO TIENE VIAJE ES UTILITARIO Y SE ACTUALIZA CAMPO FACTURA EN TABLA UTILITARIOS
                            If Var47.Trim.Length = 0 Then
                                Try
                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand '                                                   0000000043
                                        SQL = "UPDATE GCASIGNACION_VALES_UTIL SET FACTURA = '" & TCVE_DOC.Text & "', 
                                            ST_VALES = 'CONCILIADO' WHERE FOLIO = '" & Fg2(k, 3) & "'"

                                        BACKUPTXT("CRISTIAN", SQL)
                                        cmd3.CommandText = SQL
                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                    End Using
                                Catch ex As Exception
                                    Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                    'MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        Catch ex As Exception
                            Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            'MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
            Catch ex As Exception
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
        'PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    
    End Sub
    Sub DESPLEGAR_VALES_GAS(Optional fOPCION As String = "S", Optional fReg As Integer = 0)
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            If fOPCION = "S" Then
                If Fg2.Rows.Count > 1 Then
                    If MsgBox("hay vales asignados, realmente desea desplegar?", vbYesNo) = vbNo Then
                        Return
                    End If
                End If
            End If

            Dim z As Integer = fReg, j As Integer = 0, Sigue As Boolean

            If TCVE_PROV.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la clave del proveedor")
                Return
            End If

            Fg.Rows.Count = 1
            If fOPCION = "S" Then
                If Cadena_gas.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione al menos una gasolinera")
                    Return
                End If
                Fg2.Rows.Count = 1
            End If
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT A.CVE_VIAJE, A.FOLIO,  G.CVE_GAS, G.DESCR AS NOMBRE_GAS, A.FECHA, A.SUBTOTAL, A.IVA, A.IMPORTE,
                        ISNULL(LITROS,0) AS LTS_INICIALES, ISNULL(LITROS_REALES,0) AS LTS_REAL, OBS
                        FROM GCASIGNACION_VIAJE_VALES A
                        LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = A.CVE_GAS
                        LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV
                        WHERE A.STATUS <> 'C' AND G.CVE_PROV = '" & TCVE_PROV.Text & "' AND 
                        A.ST_VALES = 'ACEPTADO' AND ISNULL(A.CONCILIADO,0) = 0 " & Cadena_gas & " 
                        ORDER BY A.FOLIO"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Sigue = True
                            For k = 1 To Fg2.Rows.Count - 1
                                If Fg2(k, 3) = dr("FOLIO") Then
                                    Sigue = False
                                End If
                            Next
                            If Sigue Then
                                z += 1 '                 1                   2                       3                    4   
                                Fg.AddItem(z & vbTab & "" & vbTab & dr("CVE_VIAJE") & vbTab & dr("FOLIO") & vbTab & dr("OBS") & vbTab & dr("CVE_GAS") & vbTab &
                                       dr("NOMBRE_GAS") & vbTab & dr("LTS_INICIALES") & vbTab & dr("LTS_REAL") & vbTab & dr("FECHA") & vbTab &
                                       dr("SUBTOTAL") & vbTab & dr("IVA") & vbTab & dr("IMPORTE") & vbTab & z)

                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT A.FOLIO,  G.CVE_GAS, G.DESCR AS NOMBRE_GAS, A.FECHA, A.SUBTOTAL, A.IVA, A.IMPORTE,
                    ISNULL(LTS_INICIALES,0) AS LTS_INICIALES, ISNULL(LITROS_REALES,0) AS LTS_REAL
                    FROM GCASIGNACION_VALES_UTIL A
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = A.CVE_GAS
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV
                    WHERE G.CVE_PROV = '" & TCVE_PROV.Text & "' AND 
                    A.ST_VALES = 'ACEPTADO' AND ISNULL(A.CONCILIADO,0) = 0 " & Cadena_gas & " 
                    ORDER BY A.FOLIO"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            Sigue = True
                            For k = 1 To Fg2.Rows.Count - 1
                                If Fg2(k, 3) = dr("FOLIO") Then
                                    Sigue = False
                                End If
                            Next
                            If Sigue Then
                                z += 1
                                Fg.AddItem(z & vbTab & "" & vbTab & "" & vbTab & dr("FOLIO") & vbTab & dr("CVE_GAS") & vbTab &
                                           dr("NOMBRE_GAS") & vbTab & dr("LTS_INICIALES") & vbTab & dr("LTS_REAL") & vbTab & dr("FECHA") & vbTab &
                                           dr("SUBTOTAL") & vbTab & dr("IVA") & vbTab & dr("IMPORTE") & vbTab & z)
                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If Fg.Rows.Count = 1 Then
                Lt1.Text = ""
                If fOPCION = "S" Then
                    MsgBox("No se encontraron gasolineras de este proveedor")
                End If
            Else
                Lt1.Text = "Vales encontrados:" & z

                If LtCanc.Text <> "FACTURA CERRADA" And LtCanc.Text <> "CANCELADA" Then
                    Fg.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
                End If
            End If

        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try
            If Fg.Row > 0 Then
                Dim CVE_FOLIO As String, CVE_VIAJE As String, Exist As Boolean, SUBTOTAL As Single, IVA As Single, NETO As Single, z As Integer = 0

                For k = Fg.Rows.Count - 1 To 1 Step -1
                    If Fg(k, 1) Then
                        CVE_VIAJE = Fg(k, 2)
                        CVE_FOLIO = Fg(k, 3)
                        Exist = False
                        For j = 1 To Fg2.Rows.Count - 1
                            If Fg2(j, 2) = CVE_VIAJE And Fg2(j, 3) = CVE_FOLIO Then
                                Exist = True
                                Exit For
                            End If
                        Next
                        If Not Exist Then
                            Fg2.AddItem("" & vbTab & "" & vbTab & Fg(k, 2) & vbTab & Fg(k, 3) & vbTab & Fg(k, 4) & vbTab &
                                Fg(k, 5) & vbTab & Fg(k, 6) & vbTab & Fg(k, 7) & vbTab & Fg(k, 8) & vbTab & Fg(k, 9) & vbTab &
                                Fg(k, 10) & vbTab & Fg(k, 11) & vbTab & Fg(k, 12) & vbTab & Fg(k, 13))
                            z += 1
                            Fg.RemoveItem(k)
                        End If
                    End If
                Next

                If z > 0 Then
                    Fg2.Sort(C1.Win.C1FlexGrid.SortFlags.Ascending, 8, 8)
                    SUBTOTAL = 0 : IVA = 0 : NETO = 0
                    For k = 1 To Fg2.Rows.Count - 1
                        Fg2(k, 0) = k
                        SUBTOTAL += Fg2(k, 10)
                        IVA += Fg2(k, 11)
                        NETO += Fg2(k, 12)
                    Next
                    tSUBTOTAL.Text = Format(SUBTOTAL, "###,###,##0.00")
                    tIVA.Text = Format(IVA, "###,###,##0.00")
                    tNETO.Text = Format(NETO, "###,###,##0.00")

                    Fg.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
                    Fg2.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)

                    If Fg2.Rows.Count = 1 Then
                        Lt2.Text = ""
                    Else
                        Lt2.Text = "Vales seleccionados:" & Fg2.Rows.Count - 1
                    End If
                Else
                    MsgBox("Por favor seleccione al menos un vale de combustible")
                End If
            Else
                MsgBox("No existen vales de combustible, verifique por favor")
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnRegresar_Click(sender As Object, e As EventArgs) Handles BtnRegresar.Click
        Try
            If Fg2.Row > 0 Then
                Dim SUBTOTAL As Single, IVA As Single, NETO As Single, z As Integer = 0

                For k = Fg2.Rows.Count - 1 To 1 Step -1
                    Try
                        If Fg2(k, 1) Then
                            Fg.AddItem(Fg2(k, 12) & vbTab & "" & vbTab & Fg2(k, 2) & vbTab & Fg2(k, 3) & vbTab & Fg2(k, 4) & vbTab &
                                       Fg2(k, 5) & vbTab & Fg2(k, 6) & vbTab & Fg2(k, 7) & vbTab & Fg2(k, 8) & vbTab & Fg2(k, 9) & vbTab &
                                       Fg2(k, 10) & vbTab & Fg2(k, 11) & vbTab & Fg2(k, 12) & vbTab & Fg2(k, 13))
                            Fg2.RemoveItem(k)
                            z += 1
                        End If
                    Catch ex As Exception
                        Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next

                If z > 0 Then
                    SUBTOTAL = 0 : IVA = 0 : NETO = 0
                    Fg2.Refresh()
                    Try
                        For k = 1 To Fg2.Rows.Count - 1
                            SUBTOTAL += Fg2(k, 10)
                            IVA += Fg2(k, 11)
                            NETO += Fg2(k, 12)
                        Next
                        SUBTOTAL = Math.Round(SUBTOTAL, 6)
                        IVA = Math.Round(IVA, 6)
                        NETO = Math.Round(NETO, 6)

                        tSUBTOTAL.Text = Format(SUBTOTAL, "###,###,##0.00")
                        tIVA.Text = Format(IVA, "###,###,##0.00")
                        tNETO.Text = Format(NETO, "###,###,##0.00")

                        If Fg.Row > 0 Then
                            Fg.Row = 1
                        End If
                    Catch ex As Exception
                        Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        Fg.Sort(SortFlags.UseColSort, 12, 12)

                        Fg2.SetCellCheck(0, 1, CheckEnum.Unchecked)
                        Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)
                    Catch ex As Exception
                        Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    MsgBox("Por favor seleccione al menos un vale de combustible a regresar")
                End If
                'Fg.Cols(8).Sort = C1.Win.C1FlexGrid.SortFlags.Ascending
            Else
                'MsgBox("No existen vales de combustible a regresar, verifique por favor")
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmConciValesCombusAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles BarCancelar.Click
        Dim IMPORTE As Decimal = 0
        If Not Valida_Conexion() Then
            Return
        End If

        If MsgBox("Realmente desea cancelar la conciliacion?", vbYesNo) = vbYes Then
            Dim EXISTE_PAGO As Boolean = False
            Dim REFER As String = ""

            Try

                SQL = "SELECT REFER FROM PAGA_M" & Empresa & " WHERE 
                     NO_FACTURA = '" & TCVE_DOC.Text & "' AND CVE_PROV = '" & TCVE_PROV.Text & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            REFER = dr("REFER")
                        End If
                    End Using
                End Using

                If REFER.Trim.Length > 0 Then
                    SQL = "SELECT REFER FROM PAGA_DET" & Empresa & " WHERE 
                        REFER = '" & REFER & "' AND CVE_PROV = '" & TCVE_PROV.Text & "'"
                Else
                    SQL = "SELECT REFER FROM PAGA_DET" & Empresa & " WHERE 
                        NO_FACTURA = '" & TCVE_DOC.Text & "' AND CVE_PROV = '" & TCVE_PROV.Text & "'"
                End If

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            EXISTE_PAGO = True
                        End If
                    End Using
                End Using

            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            If EXISTE_PAGO Then
                MsgBox("La conciliación tiene un pago, No se puede cancelar")
                Return
            End If

            Try
                For k = 1 To Fg2.Rows.Count - 1
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCCONCI_VALES_COMBUS_PAR SET STATUS = 'C' WHERE 
                                CVE_COVC = " & TCVE_COVC.Text & " AND 
                                CVE_VIAJE = '" & Fg2(k, 2) & "' AND 
                                CVE_FOLIO = '" & Fg2(k, 3) & "'"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Try
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET CONCILIADO = 0, ST_VALES = 'ACEPTADO', FACTURA = '' 
                                                    WHERE CVE_VIAJE = '" & Fg2(k, 2) & "' AND FOLIO = '" & Fg2(k, 3) & "'"
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                    Try  'SI NO TIENE VIAJE ES UTILITARIO Y SE ACTUALIZA CAMPO FACTURA EN TABLA UTILITARIOS
                                        If Var47.Trim.Length = 0 Then
                                            Try
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    SQL = "UPDATE GCASIGNACION_VALES_UTIL SET FACTURA = '', ST_VALES = 'ACEPTADO' WHERE FOLIO = '" & Fg2(k, 3) & "'"

                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                End Using
                                            Catch ex As Exception
                                                Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                                'MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                        End If
                                    Catch ex As Exception
                                        Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                        'MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try

                                    IMPORTE += Fg2(k, 12)

                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
                Try
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "UPDATE GCCONCI_VALES_COMBUS SET STATUS = 'C' WHERE CVE_COVC = " & Convert.ToInt32(TCVE_COVC.Text)
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    If IMPORTE > 0 Then
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "DELETE FROM PAGA_M" & Empresa & " WHERE NO_FACTURA = '" & TCVE_DOC.Text & "' AND CVE_PROV = '" & TCVE_PROV.Text & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        Try
                            SQL = "UPDATE PROV" & Empresa & " SET SALDO = COALESCE(SALDO,0) - (" & Math.Round(IMPORTE, 6) & ")
                                   WHERE CLAVE = '" & TCVE_PROV.Text & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            SQL = "UPDATE ACOMP" & Empresa & " SET CVTA_COM = ISNULL(CVTA_COM,0) - " & IMPORTE & " WHERE CVE_ACOMP = " & Now.Month
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("154. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            MsgBox("154. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                MsgBox("La conciliación se cancelo satisfactoriamente")

                Me.Close()
            Catch ex As Exception
                Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If LtCanc.Text = "FACTURA CERRADA" Or LtCanc.Text = "CANCELADA" Then
            Else
                If e.Row = 0 Then
                    ChangeState(Fg.GetCellCheck(e.Row, e.Col))
                Else
                    If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)
                End If
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, 1, state)
        Next
    End Sub

    Private Sub Fg2_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg2.CellChecked
        Try
            If LtCanc.Text = "FACTURA CERRADA" Or LtCanc.Text = "CANCELADA" Then
            Else
                If e.Row = 0 AndAlso e.Col = 1 Then
                    ChangeState2(Fg2.GetCellCheck(e.Row, e.Col))
                Else
                    If Fg2.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg2.SetCellCheck(0, 1, CheckEnum.Unchecked)
                End If

            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChangeState2(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg2.Rows.Fixed To Fg2.Rows.Count - 1
            Fg2.SetCellCheck(row, 1, state)
        Next
    End Sub

    Private Sub BarCerrarFactura_Click(sender As Object, e As EventArgs) Handles BarCerrarFactura.Click

        If Not Valida_Conexion() Then
            Return
        End If
        Try
            If LtCanc.Text = "FACTURA CERRADA" Then
                MsgBox("La factura actualemnte se encuentra cerrada, verifique por favor")
                Return
            End If
            If LtCanc.Text = "CANCELADA" Then
                MsgBox("La factura actualemnte se encuentra cancelada, verifique por favor")
                Return
            End If

            If TCVE_PROV.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la clave del proveedor")
                Return
            End If

            If TCVE_COVC.Text.Trim.Length > 0 Then
                If MsgBox("Realmente desea cerrar la conciliación?", vbYesNo) = vbYes Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "UPDATE GCCONCI_VALES_COMBUS SET STATUS = 'F' WHERE CVE_COVC = " & Convert.ToInt32(TCVE_COVC.Text)
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                                BarCxP_Click(Nothing, Nothing)

                                MsgBox("La concilación se cerro satisfactoriamente")
                                Me.Close()
                            Else
                                MsgBox("No se logro cerrar satisfactoriamente")
                            End If
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If LtCanc.Text = "FACTURA CERRADA" Or LtCanc.Text = "CANCELADA" Then
                e.Cancel = True
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg2_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg2.BeforeEdit
        Try
            If LtCanc.Text = "FACTURA CERRADA" Or LtCanc.Text = "CANCELADA" Then
                e.Cancel = True
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg2, "Conci vales combustible")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String

            If IsNew Then
                MsgBox("Por favor primero grabe la conciliación")
                Return
            End If

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportConciValesCombusG.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CVE_COVC") = CLng(TCVE_COVC.Text)
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub IMPRIMIR_UTILS_VIA_IEPS(FFACTURA As String)
        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportVehiculosUtil.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("FACTURA") = FFACTURA
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarAdjuntarXML_Click(sender As Object, e As EventArgs) Handles BarAdjuntarXML.Click
        Try
            Var2 = ""
            Var3 = ""
            Var6 = ""
            Var25 = TCVE_DOC.Tag
            frmAdjuntarXML.ShowDialog()

            TCVE_DOC.Tag = Var25 'RUTA Y NOMBRE XML
            SERIE_CFDI = Var2

            If IsNumeric(Var3) Then
                FOLIO_CFDI = Var3
            Else
                FOLIO_CFDI = 0
            End If

            If Var6 = "DESASOCIAR" Then
                DESASOCIA_XML()
            End If
        Catch ex As Exception
            Bitacora("409. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESASOCIA_XML()
        Try
            SQL = "UPDATE GCCONCI_VALES_COMBUS SET XML = ' ', SERIE_CFDI = ' ', FOLIO_CFDI = 0 
                WHERE CVE_COVC = " & CONVERTIR_TO_INT(TCVE_COVC.Text)
            EXECUTE_QUERY_NET(SQL)

            SQL = "DELETE FROM GCCOMPRAS WHERE TIPO_DOC = 'VC' AND CVE_DOC = '" & TCVE_DOC.Text & "'"
            EXECUTE_QUERY_NET(SQL)

        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String, strSerie As String, strFolio As String, strFechaEmision As String, strSello As String
        Dim strNoCertificado As String, strSubtotal As String, strTotal As String, strMoneda As String, strCondiciones As String
        Dim strFormaPago As String, strMetodoPago As String, strLugarExpedicion As String, strReceptorRfc As String

        Dim strEmisorRfc As String, strEmisorNombre As String
        Dim strUsoCFDI As String, strRegimen As String, strDescuento As String, strNumCtaPago As String, strVersion As String
        Dim NoCertificadoSAT As String, UUID As String, UUIDR As String

        Dim FechaTimbrado As String, strVersionTimbre As String, NumOperacion As String, Monto As String, FormaDePagoP As String
        Dim FechaPago As String, Folio As String, Serie As String, ImpSaldoInsoluto As String, ImpPagado As String
        Dim ImpSaldoAnt As String, NumParcialidad As String, MetodoDePagoDR As String, XML As String
        Dim concepto As XmlNodeList
        Dim Elemento As XmlNode
        Dim subnodo As XmlElement
        Dim IdDocumento As String
        Dim xDoc As XmlDocument
        Dim xNodo As XmlNodeList
        Dim xAtt As XmlElement
        Dim Comprobante As XmlNode

        UUID = "" : strTipoComprobante = ""

        xDoc = New XmlDocument

        Try
            XML = fFILE_XML

            If XML.Trim.Length > 0 Then
                Dim books = XDocument.Load(XML)

                xDoc.Load(XML)

                Comprobante = xDoc.Item("cfdi:Comprobante")
                xNodo = xDoc.GetElementsByTagName("cfdi:Comprobante")
                If xNodo.Count > 0 Then
                    For Each xAtt In xNodo
                        Application.DoEvents()
                        Try
                            strVersion = VarXml(xAtt, "Version")
                        Catch ex As Exception
                            strVersion = ""
                        End Try
                        Try
                            strTipoComprobante = VarXml(xAtt, "TipoDeComprobante")
                            strSerie = VarXml(xAtt, "Serie")
                            strFolio = VarXml(xAtt, "Folio")
                            strFechaEmision = VarXml(xAtt, "Fecha")
                            strSello = VarXml(xAtt, "sello")
                            strNoCertificado = VarXml(xAtt, "NoCertificado")
                            strSubtotal = VarXml(xAtt, "SubTotal")
                            strTotal = VarXml(xAtt, "Total")
                            strMoneda = VarXml(xAtt, "Moneda")
                            strCondiciones = VarXml(xAtt, "CondicionesDePago")
                            strFormaPago = VarXml(xAtt, "FormaPago")
                            strMetodoPago = VarXml(xAtt, "MetodoPago")
                            strNumCtaPago = VarXml(xAtt, "NumCtaPago").Trim
                            strLugarExpedicion = VarXml(xAtt, "LugarExpedicion")
                            strDescuento = VarXml(xAtt, "Descuento")

                            strRegimen = VarXml(xAtt, "NoCertificadoSAT")
                        Catch ex As Exception
                            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("90. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        End Try
                    Next '   EMISOR   EMISOR   EMISOR   EMISOR
                    Try
                        UUID = ""
                        concepto = xDoc.GetElementsByTagName("cfdi:Complemento")
                        For Each Elemento In concepto
                            For Each subnodo In Elemento
                                UUID = Trim(subnodo.GetAttribute("UUID"))
                            Next
                        Next
                    Catch ex As Exception
                        Bitacora("91. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    UUIDR = ""
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:CfdiRelacionados")
                        If xNodo.Count > 0 Then
                            If xNodo.Count > 0 Then
                                For Each xAtt In xNodo.Item(0)
                                    Application.DoEvents()
                                    Me.Refresh()
                                    If xAtt.LocalName Like "CfdiRelacionado" Then
                                        UUIDR = VarXml(xAtt, "UUID")
                                    End If
                                Next
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("92. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strReceptorRfc = VarXml(xAtt, "Rfc")
                                'LtRFC.Text = strReceptorRfc
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("93. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Receptor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strEmisorRfc = VarXml(xAtt, "Rfc")
                                strEmisorNombre = VarXml(xAtt, "Nombre")
                                strUsoCFDI = VarXml(xAtt, "UsoCFDI")
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("94. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Complemento")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo.Item(0)
                                Application.DoEvents()
                                Me.Refresh()
                                If xAtt.LocalName Like "TimbreFiscalDigital" Then
                                    NoCertificadoSAT = VarXml(xAtt, "NoCertificadoSAT")
                                    UUID = VarXml(xAtt, "UUID")
                                    FechaTimbrado = VarXml(xAtt, "FechaTimbrado")
                                    strVersionTimbre = VarXml(xAtt, "Version")
                                End If
                                If xAtt.LocalName Like "Pagos" Then
                                    NoCertificadoSAT = VarXml(xAtt, "Version")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If strTipoComprobante = "P" Then
                        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
                        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""
                        Try
                            concepto = xDoc.GetElementsByTagName("pago10:Pagos")
                            For Each Elemento In concepto
                                For Each subnodo In Elemento
                                    NumOperacion = Trim(subnodo.GetAttribute("NumOperacion"))
                                    Monto = Trim(subnodo.GetAttribute("Monto"))
                                    FormaDePagoP = Trim(subnodo.GetAttribute("FormaDePagoP"))
                                    FechaPago = Trim(subnodo.GetAttribute("FechaPago"))
                                Next
                            Next
                            If Val(Monto) > 0 Then strTotal = Val(Monto)
                            If FechaPago.Trim.Length > 0 Then FechaTimbrado = FechaPago
                            If FormaDePagoP.Trim.Length > 0 Then strFormaPago = FormaDePagoP
                        Catch ex As Exception
                            Bitacora("96.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            MetodoDePagoDR = ""
                            concepto = xDoc.GetElementsByTagName("pago10:Pago")
                            For Each Elemento In concepto
                                'pago10:DoctoRelacionado
                                For Each subnodo In Elemento
                                    Folio = Trim(subnodo.GetAttribute("Folio"))
                                    Serie = Trim(subnodo.GetAttribute("Serie"))
                                    ImpSaldoInsoluto = Trim(subnodo.GetAttribute("ImpSaldoInsoluto"))
                                    ImpPagado = Trim(subnodo.GetAttribute("ImpPagado"))
                                    ImpSaldoAnt = Trim(subnodo.GetAttribute("ImpSaldoAnt"))
                                    NumParcialidad = Trim(subnodo.GetAttribute("NumParcialidad"))
                                    MetodoDePagoDR = Trim(subnodo.GetAttribute("MetodoDePagoDR"))
                                    IdDocumento = Trim(subnodo.GetAttribute("IdDocumento"))
                                Next
                            Next
                            If FormaDePagoP.Trim.Length > 0 Then
                                strMetodoPago = MetodoDePagoDR
                            End If
                        Catch ex As Exception
                            Bitacora("97.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If 'If xNodo.Count > 0 Then
            End If
            Return UUID
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return UUID
        End Try
    End Function

    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function

    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles BtnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PROV.Text = Var4
                LtProv.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                'tCVE_GAS.Focus()

            End If
        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PROV.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnProv_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_PROV_Validated(sender As Object, e As EventArgs) Handles TCVE_PROV.Validated
        Try
            If TCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCVE_PROV.Text.Trim) Then
                    DESCR = TCVE_PROV.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCVE_PROV.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Prov", TCVE_PROV.Text)
                If DESCR <> "" Then
                    LtProv.Text = DESCR
                Else
                    MsgBox("Proveedor inexistente")
                    TCVE_PROV.Text = ""
                    LtProv.Text = ""
                End If
            Else
                LtProv.Text = ""
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmConciValesCombusAE_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            BtnAgregar.Left = Fg.Left + Fg.Width - BtnAgregar.Width - 50
            BtnAgregar.Top = Splitter1.Height - BtnAgregar.Height - 30

            BtnRegresar.Left = Fg.Left + Fg.Width + 50
            BtnRegresar.Top = Splitter1.Height - BtnRegresar.Height - 30

            Lt1.Top = Splitter1.Height - Lt1.Height - 45
            Lt2.Top = Splitter1.Height - Lt2.Height - 45

            Lt2.Left = Fg.Left + Fg.Width + 150

        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnGas_Click(sender As Object, e As EventArgs) Handles BtnGas.Click
        Try
            VarFORM = ""
            Var4 = ""
            Dim FormGasoSel As New FrmSelGasolineras(TCVE_PROV.Text)
            FormGasoSel.ShowDialog()

            LtGas.Text = Var4

            Cadena_gas = VarFORM

        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_MouseClick(sender As Object, e As MouseEventArgs) Handles Fg.MouseClick
        Dim r_ As Row

        Try
            If LtCanc.Text = "FACTURA CERRADA" Or LtCanc.Text = "CANCELADA" Then
                Return
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Fg.Rows.Selected.Count > 2 Then
            Try
                For k = 0 To Fg.Rows.Selected.Count - 1

                    r_ = Fg.Rows.Selected(k)
                    Fg(r_.Index, 1) = True
                Next
            Catch ex As Exception
                Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub BarCxP_Click(sender As Object, e As EventArgs) Handles BarCxP.Click
        Dim CVE_CLPV As String, REFER As String = "", CVE_OBS As Integer = 0, NUM_MONED As Integer, NUM_CPTO As Integer, NUM_CARGO As Int16
        Dim TIPO_MOV As String, CVE_AUT As Integer, USUARIO2 As Integer, SIGNO As Integer, IMPORTE As Decimal, ENTREGADA As String
        Dim STATUS As String = "E", AFEC_COI As String, TCAMBIO As Int16, CAN_TOT As Decimal = 0, SIGUE As Boolean
        Dim FOLIO_GAS As Long = 0, NO_FACTURA As String, NETO As Decimal = 0, GRABA_OK As Boolean = False

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            CVE_CLPV = TCVE_PROV.Text
            Try
                For k = 1 To Fg2.Rows.Count - 1
                    CAN_TOT += Fg2(k, 10)
                    NETO += Fg2(k, 12)
                Next
            Catch ex As Exception
                Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If CAN_TOT = 0 Or NETO = 0 Then
                MsgBox("Existe un problema de los importes verifique por favor")
                Return
            End If

            IMPORTE = NETO

            If IMPORTE > 0 Then
                NUM_CPTO = 1 : NUM_CARGO = 1 : AFEC_COI = "A" : NUM_MONED = 1 : TCAMBIO = 1 : TIPO_MOV = "C" : SIGNO = 1 : CVE_AUT = 0
                USUARIO2 = "0" : ENTREGADA = "S" : NO_FACTURA = TCVE_DOC.Text

                Try
                    SIGUE = True
                    FOLIO_GAS = SIGUIENTE_FOLIO_COMPRA("c", SERIE_COMP_CONCI_VAL_DIESEL)
                    Do While SIGUE
                        REFER = SERIE_COMP_CONCI_VAL_DIESEL & Format(FOLIO_GAS, "0000000000")
                        If EXISTE_PAGA_M("c", REFER) Then
                            FOLIO_GAS += 1
                        Else
                            SIGUE = False
                        End If
                    Loop
                Catch ex As Exception
                    Bitacora("31. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                SQL = "IF NOT EXISTS (SELECT REFER FROM PAGA_M" & Empresa & " WHERE REFER = '" & REFER & "' AND 
                    NUM_CPTO = " & NUM_CPTO & " AND NO_FACTURA = '" & NO_FACTURA & "')
                    INSERT INTO PAGA_M" & Empresa & " (CVE_PROV, REFER, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, FECHA_APLI, 
                    FECHA_VENC, AFEC_COI, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, TIPO_MOV, SIGNO, USUARIO, ENTREGADA, FECHA_ENTREGA, STATUS) VALUES('" &
                    CVE_CLPV & "','" & REFER & "','" & NUM_CPTO & "','" & NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & REFER & "','" &
                    Math.Round(IMPORTE, 6) & "',CONVERT(varchar, GETDATE(), 112),CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & NUM_MONED & "','" &
                    TCAMBIO & "','" & Math.Round(IMPORTE, 6) & "',GETDATE(),'" & TIPO_MOV & "','" & SIGNO & "','" & USUARIO2 & "','" & ENTREGADA & "',
                    CONVERT(varchar, GETDATE(), 112),'" & STATUS & "')"

                For k = 1 To 5
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                GRABA_OK = True
                                Exit For
                            End If
                        End If
                    End Using
                    If Not Valida_Conexion() Then
                    End If
                Next

                If GRABA_OK Then
                    Try
                        SQL = "UPDATE GCCONCI_VALES_COMBUS SET STATUS = 'T' WHERE CVE_COVC = " & Convert.ToInt32(TCVE_COVC.Text)
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("154. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("154. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        SQL = "UPDATE PROV" & Empresa & " SET SALDO = COALESCE(SALDO,0) + " & Math.Round(IMPORTE, 6) & ",
                            ULT_COMPD = '" & REFER & "', ULT_COMPM = '" & Math.Round(IMPORTE, 6) & "', ULT_COMPF = CONVERT(varchar, GETDATE(), 112)
                            WHERE CLAVE = '" & CVE_CLPV & "'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        SQL = "UPDATE ACOMP" & Empresa & " SET CVTA_COM = ISNULL(CVTA_COM,0) + " & CAN_TOT & " WHERE CVE_ACOMP = " & Now.Month &
                            " IF @@ROWCOUNT = 0
                            INSERT INTO ACOMP" & Empresa & " (CVE_ACOMP, CVTA_COM, CDESCTO) VALUES ('" & Now.Month & "','" & CAN_TOT & "','0')"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("154. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("154. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        SQL = "UPDATE FOLIOSC" & Empresa & " SET ULT_DOC = " & FOLIO_GAS & " 
                                    WHERE SERIE = '" & SERIE_COMP_CONCI_VAL_DIESEL & "' AND TIP_DOC = 'c'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("154. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("154. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    MsgBox("No se logro crear la cuenta por pagar")
                End If
            Else
                MsgBox("No se grabo la cuenta por pagar porque el importe es cero")
            End If
            LtCanc.Text = "CUENTAS POR PAGAR"
            BarCancelar.Enabled = False
            BarCxP.Enabled = False
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabarXML_Click(sender As Object, e As EventArgs) Handles BarGrabarXML.Click
        Dim XML As String = "", UUID_XML As String

        Dim cmd As New SqlCommand With {.Connection = cnSAE}
        Try
            XML = TCVE_DOC.Tag
            If XML.Length > 255 Then
                XML = XML.Substring(0, 255)
            End If
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If XML.Trim.Length > 0 Then

            SQL = "UPDATE GCCONCI_VALES_COMBUS SET XML = @XML, SERIE_CFDI = @SERIE_CFDI , FOLIO_CFDI = @FOLIO_CFDI 
                WHERE CVE_COVC = @CVE_COVC"
            cmd.CommandText = SQL
            Try
                cmd.Parameters.Add("@CVE_COVC", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_COVC.Text)
                cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = XML
                cmd.Parameters.Add("@SERIE_CFDI", SqlDbType.VarChar).Value = SERIE_CFDI
                cmd.Parameters.Add("@FOLIO_CFDI", SqlDbType.Int).Value = FOLIO_CFDI
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        IsNew = False
                        MsgBox("El registro se grabo satisfactoriamente")
                    Else
                        MsgBox("No se logro grabar el registro")
                    End If
                Else
                    MsgBox("No se logro grabar el registro")
                End If

                Try
                    'GRABANDO XML
                    Dim RUTA_XML As String, ARCHIVO As String, RUTA_ACTUAL As String, FILE_XML As String

                    ARCHIVO = TCVE_DOC.Tag.ToString
                    FILE_XML = Path.GetFileName(ARCHIVO)

                    If ARCHIVO.Trim.Length > 0 And FILE_XML.Trim.Length > 0 Then

                        RUTA_XML = OBTENER_RUTA_XML()
                        If RUTA_XML.Trim.Length = 0 Then
                            RUTA_XML = Application.StartupPath
                        End If

                        RUTA_ACTUAL = Path.GetDirectoryName(ARCHIVO)
                        UUID_XML = OBTENER_UUID_XML(ARCHIVO)

                        SQL = "UPDATE GCCOMPRAS SET UUID_XML = '" & UUID_XML & "', ARCHIVO_XML = '" & FILE_XML & "' 
                            WHERE TIPO_DOC = 'VC' AND CVE_DOC = '" & TCVE_DOC.Text & "'
                            IF @@ROWCOUNT = 0
                            INSERT INTO GCCOMPRAS (NUM_REG, TIPO_DOC, CVE_DOC, MODULO, UUID_XML, ARCHIVO_XML, UUID) 
                            VALUES(
                            ISNULL((SELECT MAX(NUM_REG) + 1 FROM GCCOMPRAS),1),'VC','" & TCVE_DOC.Text & "','" &
                            "CONCI VALES COMBUSTIBLE','" & UUID_XML & "','" & FILE_XML & "',NEWID())"

                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Try
                                        FileCopy(ARCHIVO, RUTA_XML & "\" & FILE_XML)
                                    Catch ex As Exception
                                        Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If
                            End If
                        End Using
                    Else
                        MsgBox("Por favor seleccione el XML")
                    End If
                Catch ex As Exception
                    Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    'MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("Por favor seleccione un XML")
        End If
    End Sub
    Private Sub Fg2_DoubleClick(sender As Object, e As EventArgs) Handles Fg2.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg2(Fg2.Row, Fg2.Col))

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarImprimirVehiUtil_Click(sender As Object, e As EventArgs) Handles BarImprimirVehiUtil.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim FACTURA As String

            FACTURA = TCVE_DOC.Text

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportVehiculosUtil.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If

            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CVE_COVC") = TCVE_COVC.Text
            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSolicitudDePago_Click(sender As Object, e As EventArgs) Handles BarSolicitudDePago.Click
        Try
            Dim RUTA_FORMATOS As String

            If IsNew Then
                MsgBox("Por favor primero grabe la conciliación")
                Return
            End If

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSolicituDePago.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CVE_DOC") = TCVE_DOC.Text
            StiReport1.Render()

            StiReport1.Show()

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
