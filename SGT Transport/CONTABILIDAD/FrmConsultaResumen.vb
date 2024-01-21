Imports C1.Win.C1Themes
Imports System.IO
Imports System.Xml
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win
Imports C1.C1Rdl.Rdl2008
Imports FirebirdSql.Data

Public Class FrmConsultaResumen

    Private RUTA_MODELO As String = ""
    Private lstPolizas As List(Of Poliza) = New List(Of Poliza)
    Private lstCuentas As List(Of CuentaContable) = New List(Of CuentaContable)
    Dim Debe As Decimal, Haber As Decimal
    Public NombreConsulta As String
    Public NombreFrm As String
    Private Sub FrmConsultaResumen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            lbSerie.Visible = False
            CboSeries.Visible = False
            lbEstatus.Visible = False
            CboEstatus.Visible = False
            lbCliente.Visible = False
            txCliente.Visible = False
            BtnCliente.Visible = False
            txClienteNombre.Visible = False
            lbTimbrada.Visible = False
            cboTimbrada.Visible = False

            Select Case (NombreFrm)
                Case "BarContResFacturas"
                    lbSerie.Visible = True
                    CboSeries.Visible = True
                    lbEstatus.Visible = True
                    CboEstatus.Visible = True
                    lbCliente.Visible = True
                    txCliente.Visible = True
                    BtnCliente.Visible = True
                    txClienteNombre.Visible = True
                    lbTimbrada.Visible = True
                    cboTimbrada.Visible = True
                    CargaCombosFacturas()
                Case "BarContResFacturasAbono"
                    lbSerie.Visible = True
                    CboSeries.Visible = True
                    lbCliente.Visible = True
                    txCliente.Visible = True
                    BtnCliente.Visible = True
                    txClienteNombre.Visible = True
                    lbTimbrada.Visible = True
                    cboTimbrada.Visible = True
                    CargaCombosFacturas()
                Case "BarContResLiq"
                    lbSerie.Text = "Estatus"
                    lbSerie.Visible = True
                    CboSeries.Visible = True
                    CargaCombosLiquidaciones()
                Case "BarContResLiqConceptos"
                    lbSerie.Text = "Estatus"
                    lbSerie.Visible = True
                    CboSeries.Visible = True
                    CargaCombosLiquidaciones()
            End Select

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

            D1 = "01/" & Format(N.Month, "00") & "/" & N.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & N.Year

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
            Panel1.Width = Fg.Width
            'Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height
            Fg.Height = Me.Height - Panel1.Height - Panel1.Height

            Desplegar()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CargaCombosFacturas()
        SQL = "SELECT ISNULL(TIP_DOC,'') AS TI_DOC, ISNULL(SERIE,'') AS LETRA
                FROM FOLIOSF" & Empresa & "
                WHERE TIP_DOC = 'F' ORDER BY TIP_DOC"

        CboSeries.Items.Clear()
        CboSeries.Items.Add("")
        Using cmd As SqlCommand = cnSAE.CreateCommand
            cmd.CommandText = SQL
            Using dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    CboSeries.Items.Add(dr("LETRA"))
                End While
            End Using
        End Using
        CboSeries.SelectedIndex = 0

        CboEstatus.Items.Clear()
        CboEstatus.Items.Add("")
        CboEstatus.Items.Add("EMITIDA")
        CboEstatus.Items.Add("CANCELADA")
        cboTimbrada.Items.Clear()
        cboTimbrada.Items.Add("")
        cboTimbrada.Items.Add("SI")
        cboTimbrada.Items.Add("NO")

    End Sub

    Private Sub CargaCombosLiquidaciones()
        SQL = "SELECT * FROM GCSTATUS_LIQUIDACION"

        CboSeries.Items.Clear()
        CboSeries.Items.Add("")
        Using cmd As SqlCommand = cnSAE.CreateCommand
            cmd.CommandText = SQL
            Using dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    CboSeries.Items.Add(dr("DESCR"))
                End While
            End Using
        End Using
        CboSeries.SelectedIndex = 0

        CboEstatus.Items.Clear()
        cboTimbrada.Items.Clear()

    End Sub

    Private Sub FrmConsultaResumen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab(NombreConsulta)
    End Sub


    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Desplegar()
    End Sub

    Private Sub Desplegar()
        If Not Valida_Conexion() Then
            Return
        End If


        Dim Filtro As String = ""

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor
        Fg.Focus()

        'Fg.Rows.Count = 1
        Fg.Redraw = False

        Filtro = String.Format("WHERE Fecha BETWEEN '{0:yyyyMMdd}' AND '{1:yyyyMMdd}' ", F1.Value, F2.Value)

        Select Case (NombreFrm)
            Case "BarContResFacturas"
                If CboSeries.Text <> "" Then
                    Filtro += String.Format(" AND ctrl_Serie = '{0}'", CboSeries.Text.Replace("-", ""))
                End If
                If CboEstatus.Text <> "" Then
                    Filtro += String.Format(" AND Estatus = '{0}'", CboEstatus.Text)
                End If
                If cboTimbrada.Text <> "" Then
                    Filtro += String.Format(" AND Timbrada = '{0}'", cboTimbrada.Text)
                End If
                If txCliente.Text <> "" Then
                    Filtro += String.Format(" AND [Clave Cliente] = '{0}'", txCliente.Text.Trim)
                End If
                SQL = String.Format("SELECT * FROM VT_RPT_ResumenFacturas {0} ORDER BY Fecha", Filtro)
            Case "BarContResLiq"
                If CboSeries.Text <> "" Then
                    Filtro += String.Format(" AND Estatus = '{0}'", CboSeries.Text.Replace("-", ""))
                End If
                SQL = String.Format("SELECT * FROM VT_RPT_ResumenLiquidacion {0} ORDER BY Liquidación", Filtro)
            Case "BarContResLiqConceptos"
                If CboSeries.Text <> "" Then
                    Filtro += String.Format(" AND Estatus = '{0}'", CboSeries.Text.Replace("-", ""))
                End If
                SQL = String.Format("SELECT * FROM VT_RPT_ResumenLiquidacionConceptos {0} ORDER BY Liquidación", Filtro)
            Case "BarContResFacturasAbono"
                If CboSeries.Text <> "" Then
                    Filtro += String.Format(" AND ctrl_Serie = '{0}'", CboSeries.Text.Replace("-", ""))
                End If
                If cboTimbrada.Text <> "" Then
                    Filtro += String.Format(" AND Timbrada = '{0}'", cboTimbrada.Text)
                End If
                If txCliente.Text <> "" Then
                    Filtro += String.Format(" AND [Clave Cliente] = '{0}'", txCliente.Text.Trim)
                End If
                SQL = String.Format("SELECT * FROM VT_RPT_ResumenFacturasAbonos {0} ORDER BY Fecha", Filtro)
        End Select

        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim tipoDato As String
            Dim field As String

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)
            Fg.DataSource = dt

            For i = 0 To Fg.Cols.Count - 1
                If Not Fg.Cols(i).DataType() Is Nothing Then
                    tipoDato = Fg.Cols(i).DataType().Name
                    field = Fg.Cols(i).Name
                    If tipoDato = "Decimal" Or tipoDato = "Double" Then
                        Fg.Cols(i).Format = "###,###,##0.00"
                    End If
                    If field.Contains("ctrl_") Then
                        Fg.Cols(i).Visible = False
                    End If
                End If
            Next

            Fg.AutoSizeCols()

            LtNUm.Text = "Registros encontradas: " & Fg.Rows.Count - 1
            Fg.Select()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try

            EXPORTAR_EXCEL_TRANSPORT(Fg, NombreConsulta, False)

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub txCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txCliente.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCliente_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub txCliente_Validated(sender As Object, e As EventArgs) Handles txCliente.Validated
        Try
            If txCliente.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Cliente", txCliente.Text, False)
                If DESCR <> "" Then

                    txClienteNombre.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    txClienteNombre.Text = ""
                    txCliente.Text = ""
                End If
            Else
                txClienteNombre.Text = ""
                txCliente.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try

            Var2 = "CTE_POS"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                txCliente.Text = Var4
                txClienteNombre.Text = Var5

                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            End If

        Catch ex As Exception
            MsgBox("1660. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1660. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

End Class
