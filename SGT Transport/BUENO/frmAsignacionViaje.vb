Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmAsignacionViaje
    Dim _StartSearch As Boolean
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private ASIG_VIAJES As Integer = 0
    Private CADENA As String

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        SendMessage(Me.Handle, 11, False, 0)

        CARGAR_DATOS1()

        SendMessage(Me.Handle, 11, True, 0)

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub FrmAsignacionViaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            ' Allow filtering in the grid
            Fg.AllowFiltering = True
            ' Specify filter for column 1
            Fg.Cols(1).AllowFiltering = C1.Win.C1FlexGrid.AllowFiltering.ByCondition

        Catch ex As Exception
        End Try

    End Sub

    Sub CARGAR_DATOS1()
        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(BarEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
            Me.KeyPreview = True

            TAB1.Dock = DockStyle.Fill
            Fg.Rows.Count = 1
            Fg2.Rows.Count = 1

            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)


            Fg.Styles("Focus").BackColor = Color.PowderBlue
            Fg.Styles("Focus").Border.Color = Color.Red
            Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double
            Fg.FocusRect = FocusRectEnum.Solid

            Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            Fg.Styles.Fixed.WordWrap = True

            Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            Me.Size = Screen.PrimaryScreen.WorkingArea.Size

            Fg.Rows(0).Height = 40
            Fg2.Rows(0).Height = 40

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - 150
            DERECHOS()

            CADENA = "WHERE A.STATUS <> 'C'"

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(ASIG_VIAJES,0) AS ASIG_VIAJ FROM GCPARAMGENERALES"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            ASIG_VIAJES = dr("ASIG_VIAJ")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            DESPLEGAR()

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = k & "." & Fg(0, k)
                Next
            End If

        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Redraw = False

            SQL = "SELECT TOP 5000 A.CVE_VIAJE AS 'Clave viaje', A.STATUS AS 'Estatus', 
                (SELECT CASE WHEN COUNT(*) = 0 THEN '' ELSE CAST(COUNT(*) AS VARCHAR(3)) END FROM GCASIGNACION_VIAJE_GASTOS GV WHERE CVE_VIAJE = A.CVE_VIAJE AND ISNULL(GV.STATUS,'A') = 'A') AS 'Gastos capturados',
                (SELECT CASE WHEN COUNT(*) = 0 THEN '' ELSE CAST(COUNT(*) AS VARCHAR(3)) END FROM GCASIGNACION_VIAJE_VALES GV WHERE GV.CVE_VIAJE = A.CVE_VIAJE AND ISNULL(GV.STATUS,'A') = 'A') AS 'Vales capturados', 
                A.VIAJE_COMPLE AS 'Viaje complementario',U.CLAVEMONTE AS 'Tractor', A.FECHA AS 'Fecha',  (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS 'Tipo unidad', 
                A.FECHA_CARGA AS 'Fecha carga', A.FECHA_DESCARGA AS 'Fecha descarga', C.NOMBRE AS 'Cliente', 
                CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS 'Estatus viaje', 
                O.NOMBRE AS 'Operador', R1.NOTA 'Alias origen', R2.NOTA AS 'Alias destino', 
                CASE WHEN A.FOLIO = 0 THEN '' ELSE A.SERIE + CAST(A.FOLIO AS VARCHAR(10)) END AS 'Factura', 
                ISNULL(R.DESCR,'') AS 'Ruta', ISNULL(R.DESCR2,'') AS 'Ruta 2'
                FROM GCASIGNACION_VIAJE A 
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = A.CLIENTE
                LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_TAB = A.CVE_TAB
                LEFT JOIN GCCLIE_OP RT1 ON RT1.CLAVE = R.CLIE_OP_O
                LEFT JOIN GCCLIE_OP RT2 ON RT2.CLAVE = R.CLIE_OP_D
                LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                LEFT JOIN GCCLIE_OP R1 ON R1.CLAVE = A.CLAVE_O
                LEFT JOIN GCCLIE_OP R2 ON R2.CLAVE = A.CLAVE_D
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = A.ENTREGAR_EN " & CADENA &
                "ORDER BY A.FECHAELAB DESC"

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt

            If TAB1.SelectedIndex = 0 Then
                Fg.DataSource = BindingSource1.DataSource

                Fg.Cols(1).StarWidth = "*"
                Fg.Cols(2).StarWidth = "*"
                Fg.Cols(3).StarWidth = "*"
                Fg.Cols(4).StarWidth = "*"
                Fg.Cols(5).StarWidth = "*"
                Fg.Cols(6).StarWidth = "*"
                Fg.Cols(7).StarWidth = "*"
                Fg.Cols(8).StarWidth = "*"
                Fg.Cols(9).StarWidth = "*"
                Fg.Cols(10).StarWidth = "*"
                Fg.Cols(11).StarWidth = "*"
                Fg.Cols(12).StarWidth = "*"
                Fg.Cols(13).StarWidth = "3*"
                Fg.Cols(14).StarWidth = "3*"
                Fg.Cols(15).StarWidth = "*"
                Fg.Cols(16).StarWidth = "*"
                Fg.Cols(17).StarWidth = "3*"

                Fg.Rows(0).StyleNew.WordWrap = True
                Fg.Rows(0).StyleNew.TextAlign = TextAlignEnum.LeftCenter

                Fg.Focus()
            Else
                Fg2.DataSource = BindingSource1.DataSource
                Fg2.AutoSizeCols()
                Fg2.Focus()
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True

    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarNuevo.Visible = False
                BarEdit.Visible = False
                BarEliminar.Visible = False

            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                (CLAVE >= 22000 AND CLAVE < 22990 OR CLAVE >= 222000 AND CLAVE < 222400)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 22000  'ASIGNACION DE VIAJE

                                Case 22010  'NUEVO VIAJE
                                    BarNuevo.Visible = True
                                Case 22020  'EDIT VIAJE
                                    BarEdit.Visible = True
                                Case 22030  'CANCELAR VIAJE
                                    BarEliminar.Visible = True
                                Case 22040  'GRABAR VIAJE
                                Case 22050  'DATOS GENERALES
                                Case 22070  'OBSERVACIONES VIAJE
                                Case 22080  'GASTOS DE CIAJE
                                Case 22090  'DATOS DE LA BITACORA
                                Case 22100  'IMPRIMIR BITACORA DE VIAJE
                                Case 22110  'IMPIRMIR CARTA PORTE

                                Case 222050 'CONSULTAR 

                                Case 222070 'CONSULTAR 

                                Case 222090 'CONSULTAR 

                                Case 222110 'CONSULTAR 

                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmAsignacionViaje_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Asignación de Viajes")
        Me.Dispose()
    End Sub
    Private Sub FrmAsignacionViaje_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case 27
                    TBUSCAR.Focus()
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    BarEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    BarSalir_Click(Nothing, Nothing)
                Case Keys.F12
                    C1FlexGridSearchPanel1.Controls.Item(0).Focus()
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            Var2 = ""
            Var3 = ""
            Var10 = "VVM"
            ESCENARIO = 0
            Var17 = ""
            CREA_TAB(FrmAsigViajeBuenoAE, "Asignación viaje")

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"

            If TAB1.SelectedIndex = 0 Then
                Var2 = Fg(Fg.Row, 1)
            Else
                Var2 = Fg2(Fg2.Row, 1)
            End If

            Var3 = ""
            Var17 = ""
            Var10 = "VVM"
            ESCENARIO = 0
            CREA_TAB(FrmAsigViajeBuenoAE, "Asignación viaje")

        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If Fg(Fg.Row, 2) = "C" Then
                MsgBox("El viaje actualmente se encuentra cancelado, verifique por favor")
                Return
            End If
            Dim NGastos As Integer = 0, NViajes As Integer = 0
            Try
                If IsNumeric(Fg(Fg.Row, 3)) Then
                    NGastos = CInt(Fg(Fg.Row, 3))
                Else
                    NGastos = 0
                End If
            Catch ex As Exception
            End Try
            Try
                If IsNumeric(Fg(Fg.Row, 4)) Then
                    NViajes = CInt(Fg(Fg.Row, 4))
                Else
                    NViajes = 0
                End If
            Catch ex As Exception
            End Try

            If NGastos > 0 Or NViajes > 0 Then
                MsgBox("No es posible cancelar el viaje porque cuanta con gastos de viaje o vales de combustible")
                Return
            End If

            If MsgBox("Realmente desea cancelar el viaje?", vbYesNo) = vbYes Then
                Dim SI_GASTOS As Boolean = False

                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ST_GASTOS FROM GCASIGNACION_VIAJE_GASTOS WHERE CVE_VIAJE = '" & Fg(Fg.Row, 1) & "' AND ST_GASTOS = 'DEPOSITADO'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                SI_GASTOS = True
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                If SI_GASTOS Then
                    MsgBox("El viaje " & Fg(Fg.Row, 1) & " tiene gastos depositados no es posible cancelarlo, verifique por favor")
                Else

                    Var4 = ""
                    'FrmMotivoBaja.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        'Dim CVE_MTC As Long = 0
                        Try
                            'CVE_MTC = GRABA_MOTIVO_CANC("ASIGANCION DE VIAJE", Var4)
                        Catch ex As Exception
                            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                        'SQL = "UPDATE GCASIGNACION_VIAJE SET STATUS = 'C', CVE_ST_VIA = 7, CVE_DOC = '', CVE_CAP1 = '', CVE_CAP2 = '' 
                        'WHERE CVE_VIAJE = '" & Fg(Fg.Row, 1) & "'"
                    Else
                        'Dim ResultMensaje As String
                        'ResultMensaje = MensajeBox("Cancelación abortada ¡¡¡¡¡", "Proceso finalizado", "Error")
                    End If

                    Try
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCASIGNACION_VIAJE SET STATUS = 'C', CVE_ST_VIA = 7, CVE_DOC = '', CVE_CAP1 = '', CVE_CAP2 = '' 
                                WHERE CVE_VIAJE = '" & Fg(Fg.Row, 1) & "'"
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Try
                                        Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                            SQL = "UPDATE GCPEDIDOS SET CVE_VIAJE = '' WHERE CVE_DOC = '" & Fg(Fg.Row, 15) & "'"
                                            cmd3.CommandText = SQL
                                            returnValue = cmd3.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try

                                    Try
                                        If Not IsNothing(Fg(Fg.Row, 14)) Then
                                            If Fg(Fg.Row, 14).ToString.Trim.Length > 0 Then
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    ', CVE_DOCP = '' 
                                                    SQL = "UPDATE GCCARTA_PORTE SET CVE_VIAJE = '' WHERE CVE_FOLIO = '" & Fg(Fg.Row, 16) & "'"
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            End If
                                        End If
                                        If Not IsNothing(Fg(Fg.Row, 15)) Then
                                            If Fg(Fg.Row, 15).ToString.Trim.Length > 0 Then
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    ', CVE_DOCP = '' 
                                                    SQL = "UPDATE GCCARTA_PORTE SET CVE_VIAJE = '' WHERE CVE_FOLIO = '" & Fg(Fg.Row, 18) & "'"
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            End If
                                        End If
                                    Catch ex As Exception
                                        Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try

                                    MsgBox("El viaje se cancelo correctamente")

                                    CADENA = "WHERE A.STATUS <> 'C'"
                                    DESPLEGAR()
                                Else
                                    MsgBox("No se logro realizar el deposito del gasto de viaje")
                                End If
                            Else
                                MsgBox("No se logro realizar el deposito del gasto de viaje")
                            End If
                        End Using

                    Catch ex As Exception
                        Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            If TAB1.SelectedIndex = 0 Then
                CADENA = "WHERE A.FECHA >= '" & FSQL(F1.Value) & "' AND A.FECHA <= '" & FSQL(F2.Value) & "' AND A.STATUS <> 'C'"
            Else
                CADENA = "WHERE A.FECHA >= '" & FSQL(F1.Value) & "' AND A.FECHA <= '" & FSQL(F2.Value) & "' AND A.STATUS = 'C'"
            End If

            If tCVE_TRACTOR.Text.Trim.Length > 0 Then
                CADENA = CADENA & " AND U.CLAVEMONTE = '" & tCVE_TRACTOR.Text & "'"
            End If
            DESPLEGAR()

        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTractor_Click(sender As Object, e As EventArgs) Handles btnTractor.Click
        Try
            Var2 = "Unidades2"
            Var3 = ""
            Var4 = "1"
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_TRACTOR.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTractor_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles tCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If tCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    tCVE_TRACTOR.Text = Var5
                End If
            Else
                tCVE_TRACTOR.Text = ""
            End If
        Catch ex As Exception
            Bitacora("145. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("145. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click

        If TAB1.SelectedIndex = 0 Then
            CADENA = "WHERE A.STATUS <> 'C'"
        Else
            CADENA = "WHERE A.STATUS = 'C'"
        End If

        DESPLEGAR()
    End Sub

    Private Sub BarTransbordo_Click(sender As Object, e As EventArgs)
        Try
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            Var3 = "TRANSBORDO"
            If ASIG_VIAJES = 0 Then
                CREA_TAB(FrmAsignacionViajeAE, "Asignación viaje")
            Else
                CREA_TAB(FrmAsigViajeBuenoAE, "Asignación viaje")
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))

                BarEdit_Click(Nothing, Nothing)

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuReporte_Click(sender As Object, e As EventArgs) Handles MnuReporte.Click
        Try
            frmAsigGastosDieselImprimir.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuValesDeCombustible_Click(sender As Object, e As EventArgs) Handles MnuValesDeCombustible.Click
        Try
            frmAsigValesImprimir.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuGastosDeViaje_Click(sender As Object, e As EventArgs) Handles MnuGastosDeViaje.Click
        Try
            frmAsigGastosImprimir.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub C1FlexGridSearchPanel1_Load(sender As Object, e As EventArgs) Handles C1FlexGridSearchPanel1.Load

    End Sub

    Private Sub BarFiltro_Click(sender As Object, e As EventArgs) Handles BarFiltro.Click

        Var2 = ""
        Var3 = ""
        Var4 = ""

        FrmFiltro.ShowDialog()
        If Var2.Trim.Length > 0 Or Var3.Trim.Length > 0 Or Var4.Trim.Length > 0 Then

            CADENA = Var2 & Var3 & Var4

            If TAB1.SelectedIndex = 0 Then
                CADENA += " AND A.STATUS <> 'C'"
            Else
                CADENA += " AND A.STATUS = 'C'"
            End If

            DESPLEGAR()

        End If
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            Dim RUTA As String

            RUTA = GET_RUTA_FORMATOS()

            If TAB1.SelectedIndex = 0 Then
                EXPORTAR_EXCEL_TRANSPORT(Fg, "ASIGNACION VIAJES" & Now.Day & Now.Minute & Now.Second & ".XLS")
            Else
                EXPORTAR_EXCEL_TRANSPORT(Fg2, "ASIGNACION VIAJES" & Now.Day & Now.Minute & Now.Second & ".XLS")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarReportes_Click(sender As Object, e As EventArgs) Handles BarReportes.Click

    End Sub

    Private Sub TAB1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TAB1.SelectedIndexChanged
        Select Case TAB1.SelectedIndex
            Case 0
                BarActualizar.Enabled = True
                BarEliminar.Enabled = True
                BarNuevo.Enabled = True
                BarExcel.Enabled = True

                Try
                    C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)
                    'C1FlexGridSearchPanel1.ActiveControl.Text = ""
                Catch ex As Exception
                End Try

                If Fg.Rows.Count = 1 Then
                    CADENA = "WHERE A.STATUS <> 'C'"
                    DESPLEGAR()
                End If
            Case 1
                BarActualizar.Enabled = False
                BarEliminar.Enabled = False
                BarNuevo.Enabled = False
                BarExcel.Enabled = False

                Try
                    C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg2, C1FlexGridSearchPanel1)
                    'C1FlexGridSearchPanel1.ActiveControl.Text = ""
                Catch ex As Exception
                End Try

                If Fg2.Rows.Count = 1 Then
                    CADENA = "WHERE A.STATUS = 'C'"
                    DESPLEGAR()
                End If
        End Select
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Try
            If e.Row > 0 Then
                If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
                    Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
                    e.Text = rowNumber.ToString()
                End If
            End If


        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarUpdateTabRuta_Click(sender As Object, e As EventArgs)


        If MsgBox("Realmente desea actualizar el tabulador de rutas?", vbYesNo) = vbYes Then
            SQL = "SELECT A.CVE_VIAJE, A.CVE_CON, A.CVE_TAB_VIAJE, ISNULL(R.CVE_TAB,'') AS CVE_TAB_RUTA
                 FROM GCASIGNACION_VIAJE A 
                 LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = A.CVE_CON
                 WHERE ISNULL(CVE_TAB_VIAJE,'') = '' OR ISNULL(CVE_TAB_VIAJE,'') = '0' AND ISNULL(CVE_CON,'') = '' AND ISNULL(R.CVE_TAB,'') <> ''
                 ORDER BY A.FECHAELAB DESC"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_TAB_VIAJE = '" & dr("CVE_TAB_RUTA") & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            End Using

                        End While
                    End Using
                End Using
                MsgBox("Proceso terminado")
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub TBUSCAR_TextChanged(sender As Object, e As EventArgs) Handles TBUSCAR.TextChanged

        Try
            If TBUSCAR.Text.Trim.Length > 0 Then
                ' Column Filter(Filters products whose ProductName begins with 'C')
                Dim colFilter As ColumnFilter = New ColumnFilter()
                colFilter.ConditionFilter.Condition1.Parameter = TBUSCAR.Text
                colFilter.ConditionFilter.Condition1.[Operator] = ConditionOperator.Contains   '  .BeginsWith
                Fg.Cols("Clave viaje").Filter = colFilter
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TBUSCAR.Text = ""
        Fg.ClearFilter()
        Fg.Focus()
    End Sub

    Private Sub Fg2_DoubleClick(sender As Object, e As EventArgs) Handles Fg2.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))

                BarEdit_Click(Nothing, Nothing)

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TBUSCAR_KeyDown(sender As Object, e As KeyEventArgs) Handles TBUSCAR.KeyDown

        If e.KeyCode = 13 Then
            If TBUSCAR.Text.Trim.Length > 0 Then
                If Fg.Row > 0 Then
                    Var1 = "Edit"

                    Var2 = TBUSCAR.Text
                    Var3 = ""
                    Var17 = ""
                    Var10 = "VVM"
                    ESCENARIO = 0
                    CREA_TAB(FrmAsigViajeBuenoAE, "Asignación viaje")

                Else
                    MsgBox("Por favor seleccione un registro")
                End If
            End If
        End If
    End Sub
End Class
