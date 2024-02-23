Imports C1.Win.C1Themes
Imports System.IO
Imports System.Xml
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmPolizaFondoOper

    Private RUTA_MODELO As String = ""
    Private lstPolizas As List(Of Poliza) = New List(Of Poliza)
    Private lstCuentas As List(Of CuentaContable) = New List(Of CuentaContable)
    Dim Debe As Decimal, Haber As Decimal
    Private Sub FrmPolizaFondoOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            Dim N = DateTime.Now.AddMonths(-1)
            Dim D1 As String, D2 As String

            D1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

            F1.Value = D1
            F2.Value = D2

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 50
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height
            Fg.Height = Me.Height - Panel1.Height - Panel1.Height

            Fg.Cols.Count = 17
            Fg.Rows.Count = 1
            Fg(0, 1) = "Fecha Documento"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)
            c1.Name = "FechaDocumento"

            Fg(0, 2) = "Documento"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)
            c2.Name = "Documento"

            Fg(0, 3) = "Tipo Documento"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)
            c3.Name = "TipoDocumento"

            Fg(0, 4) = "Fecha Viaje"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)
            c4.Name = "FechaViaje"

            Fg(0, 5) = "Viaje"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)
            c5.Name = "Viaje"

            Fg(0, 6) = "IdPoliza"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)
            c6.Name = "IdPoliza"

            Fg(0, 7) = "Orden"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)
            c7.Name = "Orden"

            Fg(0, 8) = "Tipo Póliza"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)
            c8.TextAlignFixed = TextAlignEnum.CenterCenter
            c8.Name = "TipoPoliza"

            Fg(0, 9) = "Núm. Póliza / No. Cuenta"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)
            c9.TextAlignFixed = TextAlignEnum.CenterCenter
            c9.Name = "NumPoliza"

            Fg(0, 10) = "Concepto Póliza  / Depto."
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)
            c10.TextAlignFixed = TextAlignEnum.CenterCenter
            c10.Name = "Concepto"

            Fg(0, 11) = "Fecha / Concepto Mov."
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)
            c11.TextAlignFixed = TextAlignEnum.CenterCenter
            c11.Name = "Mov"

            Fg(0, 12) = "Tipo de Cambio"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)
            c12.TextAlignFixed = TextAlignEnum.CenterCenter
            c12.Name = "TipoCambio"

            Fg(0, 13) = "Debe"
            Dim c13 As Column = Fg.Cols(13)
            'c13.DataType = GetType(Decimal)
            'c13.Format = "###,###,##0.00"
            c13.TextAlignFixed = TextAlignEnum.CenterCenter
            c13.TextAlign = TextAlignEnum.RightCenter
            c13.Name = "Debe"

            Fg(0, 14) = "Haber"
            Dim c14 As Column = Fg.Cols(14)
            'c14.DataType = GetType(Decimal)
            'c14.Format = "###,###,##0.00"
            c14.TextAlignFixed = TextAlignEnum.CenterCenter
            c14.TextAlign = TextAlignEnum.RightCenter
            c14.Name = "Haber"

            Fg(0, 15) = "Centro de Costos"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(String)
            c15.TextAlignFixed = TextAlignEnum.CenterCenter
            c15.TextAlign = TextAlignEnum.RightCenter
            c15.Name = "CC"

            Fg(0, 16) = "Proyecto"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(String)
            c16.TextAlignFixed = TextAlignEnum.CenterCenter
            c16.Name = "Proyecto"

            GET_RUTA_MODELO()

            Fg.Cols(1).Visible = False
            Fg.Cols(2).Visible = False
            Fg.Cols(3).Visible = False
            Fg.Cols(4).Visible = False
            Fg.Cols(5).Visible = False
            Fg.Cols(6).Visible = False
            Fg.Cols(7).Visible = False


            TPOLIZA.Text = "Póliza Fondo Operadores " & DateTime.Now.ToString("MMMM")

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GET_RUTA_MODELO()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                RUTA_MODELO = dr("RUTA_MODELO").ToString
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPolizaFondoOper_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Póliza Fondo Operadores")
    End Sub

    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        If Not Valida_Conexion() Then
            Return
        End If


        Dim Filtro As String
        Dim NewStyle1 As CellStyle, NewStyle2 As CellStyle, NewStyle3 As CellStyle, NewStyle4 As CellStyle
        Dim TotalDocumentos As Integer = 0

        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.CadetBlue
        NewStyle1.ForeColor = Color.Black
        NewStyle1.DataType = GetType(Decimal)
        NewStyle1.Format = "###,###,##0.00"

        NewStyle2 = Fg.Styles.Add("NewStyle2")
        NewStyle2.BackColor = Color.Red
        NewStyle2.ForeColor = Color.White
        NewStyle2.DataType = GetType(Decimal)
        NewStyle2.Format = "###,###,##0.00"

        NewStyle3 = Fg.Styles.Add("NewStyle3")
        NewStyle3.ForeColor = Color.DarkBlue

        NewStyle4 = Fg.Styles.Add("NewStyle4")
        NewStyle4.ForeColor = Color.Red

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor
        Fg.Focus()

        Fg.Rows.Count = 1
        Fg.Redraw = False

        'Filtro = String.Format("{0} BETWEEN '{1:yyyyMMdd}' AND '{2:yyyyMMdd}' {3} ", "FechaDocumento", F1.Value, F2.Value, IIf(chkSinPoliza.CheckState = CheckState.Checked, "AND IdPoliza = 0", ""))

        Try
            SQL = String.Format("EXEC dbo.sp_CTB_POLIZA_FONDO_OPER '{0:yyyyMMdd}', '{1:yyyyMMdd}'", F1.Value, F2.Value)
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Fg.AddItem(" " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " ")
                    Fg.AddItem(" " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " ")

                    Dim poliza As New Poliza()
                    Dim auxiliar As New Auxiliar()
                    Dim numPartida As Integer = 0
                    lstPolizas = New List(Of Poliza)
                    lstCuentas = New List(Of CuentaContable)
                    Debe = 0
                    Haber = 0

                    While dr.Read

                        Try
#Region "Listado de Pólizas"

                            '' Solo se prepara el listado con pólizas pendientes por generar
                            'If dr("IdPoliza").ToString().Equals("0") Then

                            '    Select Case dr("Orden").ToString()
                            '        Case "1"
                            '            poliza = New Poliza()
                            '            numPartida = 0
                            '            With poliza
                            '                .TipoPoliza = dr("TipoPoliza").ToString()
                            '                .NumPoliza = ""
                            '                .Periodo = Convert.ToDateTime(dr("FechaDocumento")).Month()
                            '                .Ejercicio = Convert.ToDateTime(dr("FechaDocumento")).Year()
                            '                .FechaPoliza = Convert.ToDateTime(dr("FechaDocumento"))
                            '                .ConceptoPoliza = dr("ConceptoPolizaDepto").ToString()
                            '                '.NumPartida
                            '                .LogAudita = "N"
                            '                .Contabiliza = "S"
                            '                .NumParCua = 0
                            '                .TieneDocumentos = 0
                            '                .PROCCONTAB = 0
                            '                .Origen = "SGT"
                            '                '.UUID
                            '                .EsPolizaPrivada = 0
                            '                '.UUIDOP
                            '                .TipoDocumentoPoliza = EnmTipoDocumentoPoliza.IngresosCxC
                            '                .Documentos.Add(New Documento(EnmTipoDocumento.IngresosCxC, dr("Documento").ToString(), Convert.ToDateTime(dr("FechaDocumento"))))
                            '            End With
                            '        Case "2", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13"
                            '            numPartida = numPartida + 1
                            '            auxiliar = New Auxiliar()
                            '            With auxiliar
                            '                .TipoPoliza = poliza.TipoPoliza
                            '                .NumPoliza = poliza.NumPoliza
                            '                .NumPartida = numPartida
                            '                .Periodo = poliza.Periodo
                            '                .Ejercicio = poliza.Ejercicio
                            '                .NumCuenta = dr("NoPolizaCuenta").ToString()
                            '                .FechaPoliza = poliza.FechaPoliza
                            '                .ConceptoPoliza = dr("DiaConceptoMov").ToString()
                            '                .DebeHaber = IIf(IsNumeric(dr("Debe")), "D", "H")
                            '                .MontoMovimiento = Convert.ToDouble(IIf(IsNumeric(dr("Debe")), dr("Debe"), dr("Haber")))
                            '                .NumDepartamento = 0
                            '                .TipoCambio = Convert.ToDouble(dr("TipoCambio"))
                            '                .ContraPartida = 0
                            '                .Orden = numPartida
                            '                .CCostos = 0
                            '                .CGupos = 0
                            '                .IDINFADIPAR = -1
                            '                .UUID.NumReg = -1
                            '            End With
                            '            RegistraCuenta(poliza.Ejercicio, dr("NoPolizaCuenta").ToString())
                            '            poliza.Auxiliares.Add(auxiliar)
                            '        Case "3"
                            '            Select Case dr("SubOrden").ToString()
                            '                Case "0"
                            '                    numPartida = numPartida + 1
                            '                    auxiliar = New Auxiliar()
                            '                    With auxiliar
                            '                        .TipoPoliza = poliza.TipoPoliza
                            '                        .NumPoliza = poliza.NumPoliza
                            '                        .NumPartida = numPartida
                            '                        .Periodo = poliza.Periodo
                            '                        .Ejercicio = poliza.Ejercicio
                            '                        .NumCuenta = dr("NoPolizaCuenta").ToString()
                            '                        .FechaPoliza = poliza.FechaPoliza
                            '                        .ConceptoPoliza = dr("DiaConceptoMov").ToString()
                            '                        .DebeHaber = IIf(IsNumeric(dr("Debe")), "D", "H")
                            '                        .MontoMovimiento = Convert.ToDouble(IIf(IsNumeric(dr("Debe")), dr("Debe"), dr("Haber")))
                            '                        .NumDepartamento = 0
                            '                        .TipoCambio = Convert.ToDouble(dr("TipoCambio"))
                            '                        .ContraPartida = 0
                            '                        .Orden = numPartida
                            '                        .CCostos = 0
                            '                        .CGupos = 0
                            '                        .IDINFADIPAR = -1
                            '                        .UUID.NumReg = -1
                            '                    End With
                            '                    RegistraCuenta(poliza.Ejercicio, dr("NoPolizaCuenta").ToString())

                            '                Case "2"
                            '                    With auxiliar.UUID
                            '                        .NumReg = -1
                            '                        .UUID = dr("Proyecto").ToString()
                            '                        .Monto = Convert.ToDouble(dr("CentroCostos").ToString().Replace(",", ""))
                            '                        .Serie = dr("DiaConceptoMov").ToString()
                            '                        .Folio = dr("TipoCambio").ToString()
                            '                        .RfcEmisor = dr("Debe").ToString()
                            '                        .RfcReceptor = dr("Haber").ToString()
                            '                        .Orden = 1
                            '                        .Fecha = Convert.ToDateTime(dr("FechaDocumento"))
                            '                        .TipoComprobante = 1
                            '                        .TipoCambio = Convert.ToDouble(dr("TipoCambioCFDI"))
                            '                        .VersionCFDI = dr("VersionCFDI").ToString()
                            '                        .Moneda = dr("MonedaCFDI").ToString()
                            '                    End With
                            '                    poliza.Auxiliares.Add(auxiliar)
                            '                    'poliza.UUID = dr("Proyecto").ToString()
                            '            End Select


                            '        Case "14"
                            '            poliza.NumPartida = numPartida
                            '            lstPolizas.Add(poliza)

                            '    End Select
                            'End If

#End Region

                            If dr("Orden").ToString().Equals("1") Then
                                TotalDocumentos = TotalDocumentos + 1
                            End If

                            Fg.AddItem("" & vbTab & dr("FechaDocumento") & vbTab & dr("Documento") & vbTab & dr("TipoDocumento") & vbTab & dr("FechaViaje") & vbTab &
                                       dr("Viaje") & vbTab & dr("IdPoliza") & vbTab & dr("Orden") & vbTab & dr("TipoPoliza") & vbTab & IIf(dr("Orden").ToString().Equals("1"), TotalDocumentos, dr("NoPolizaCuenta")) & vbTab &
                                       dr("ConceptoPolizaDepto") & vbTab & dr("DiaConceptoMov") & vbTab & dr("TipoCambio") & vbTab & IIf(dr("NoPolizaCuenta") = "FIN_PARTIDAS", Math.Round(dr("TotalDebe"), 2), dr("Debe")) & vbTab & IIf(dr("NoPolizaCuenta") = "FIN_PARTIDAS", Math.Round(dr("TotalHaber"), 2), dr("Haber")) & vbTab &
                                       dr("CentroCostos") & vbTab & dr("Proyecto"))

                            If Convert.ToInt32(dr("Orden")) > 1 And Convert.ToInt32(dr("Orden")) < 6 And Convert.ToInt32(dr("SubOrden")) = 0 Then
                                If IsNumeric(dr("Debe").ToString().Replace(",", "")) Then
                                    Debe += Convert.ToDecimal(dr("Debe").ToString().Replace(",", ""))
                                End If
                                If IsNumeric(dr("Haber").ToString().Replace(",", "")) Then
                                    Haber += Convert.ToDecimal(dr("Haber").ToString().Replace(",", ""))
                                End If
                                If dr("EstaCuadrada").ToString().Equals("0") Then
                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 13, NewStyle4)
                                    Fg.SetCellStyle(Fg.Rows.Count - 1, 14, NewStyle4)
                                End If
                            End If

                            If dr("Orden").ToString().Equals("1") And Not dr("IdPoliza").ToString().Equals("0") Then
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 9, NewStyle3)
                            End If

                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                    End While
                End Using
            End Using
            Fg.AddItem(" " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & "99" & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & String.Format("{0:n4}", Debe) & vbTab & String.Format("{0:n4}", Haber) & vbTab &
                                       " " & vbTab & " ")
            Fg.SetCellStyle(Fg.Rows.Count - 1, 13, IIf(Debe = Haber, NewStyle1, NewStyle2))
            Fg.SetCellStyle(Fg.Rows.Count - 1, 14, IIf(Debe = Haber, NewStyle1, NewStyle2))
            Fg.AutoSizeCols()

            LtNUm.Text = "Pólizas encontradas: " & TotalDocumentos
            Fg.Select()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default

        MsgBox("Proceso terminado")

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            Fg.AllowFiltering = True
            Fg.FilterDefinition = "<ColumnFilters><ColumnFilter ColumnIndex='6' ColumnName='Orden' DataType='System.String'><ConditionFilter AndConditions='True'><Condition Operator='DoesNotContain' Parameter='99' /></ConditionFilter></ColumnFilter></ColumnFilters>"
            EXPORTAR_EXCEL_TRANSPORT(Fg, TPOLIZA.Text, True)
            Fg.FilterDefinition = ""
            Fg.AllowFiltering = False
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TPOLIZA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPOLIZA.KeyPress

        Select Case e.KeyChar
            Case "\", "/", ":", ",", "*", "?", """", "<", ">", "|", "[", "]", ";", ":", "'", "+", "}", "{", "´", "="
                e.Handled = True
        End Select
    End Sub

    Private Sub BarGenPoliza_Click(sender As Object, e As ClickEventArgs) Handles BarGenPoliza.Click
        Try
            Return

            If lstPolizas.Count = 0 Then
                MsgBox("No hay pólizas pendientes de generar")
                Return
            End If

            If Debe <> Haber Then
                MsgBox("Totales de pólizas descuadradas, favor de verificar")
                Return
            End If

            Dim coi As New COIdb()
            If Not coi.ValidaConexion() Then
                MsgBox("No se pudo establecer conexion con la Base de Datos, favor de verificar")
                Return
            End If

            If Not coi.ValidaCuentas(lstCuentas) Then
                MarcaCuentas()
                MsgBox("Algunas cuentas no existen en COI y/o mas de una coincidencia, favor de verificar")
                Return
            End If

            If Not coi.GeneraPoliza(lstPolizas, lstCuentas) Then
                MsgBox("Error al generar la póliza")
                Return
            End If

            Fg.Rows.Count = 1
            'Fg.Redraw = False
            lstPolizas = New List(Of Poliza)
            lstCuentas = New List(Of CuentaContable)
            Debe = 0
            Haber = 0
            MsgBox("Pólizas generadas correctamente")

        Catch ex As Exception
            MsgBox(ex.Message)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub RegistraCuenta(Anio As Integer, Cuenta As String)
        If Not lstCuentas.Where(Function(x) x.Ejercicio = Anio And x.NumCuenta = Cuenta).Any() Then
            lstCuentas.Add(New CuentaContable(Anio, Cuenta))
        End If
    End Sub

    Private Function CuentaOk(Anio As Integer, Cuenta As String) As Boolean
        If lstCuentas.Where(Function(x) x.Ejercicio = Anio And x.NumCuenta = Cuenta And (x.NumCuentaAsignada = "" Or x.Coincidencias > 1)).Any() Then
            Return False
        End If

        Return True
    End Function

    Private Sub MarcaCuentas()
        Dim k As Integer
        Dim fecha As DateTime
        Dim cuenta As String
        Dim NewStyle1 As CellStyle
        Dim orden As Integer

        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Red
        NewStyle1.ForeColor = Color.White

        For k = 1 To Fg.Rows.Count - 1
            If IsNumeric(Fg(k, 7)) Then
                orden = Convert.ToInt32(Fg(k, 7))
                If orden > 1 And orden < 15 Then ' Orden
                    fecha = Convert.ToDateTime(Fg(k, 1)) ' Fecha Factura
                    cuenta = Fg(k, 9) ' Núm. Póliza / No. Cuenta
                    If Not CuentaOk(fecha.Year, cuenta) Then
                        Fg.SetCellStyle(k, 9, NewStyle1)
                    End If

                End If
            End If

        Next
    End Sub

    Private Sub BarCopy_Click(sender As Object, e As ClickEventArgs) Handles BarCopy.Click
        Try
            If Fg.Rows.Count < 2 Then Return

            Dim rng As New CellRange()
            rng.r1 = 1
            rng.r2 = Fg.Rows.Count - 2
            rng.c1 = 8
            rng.c2 = 16

            Copia_Portapapeles_Grid(Fg, rng)

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
