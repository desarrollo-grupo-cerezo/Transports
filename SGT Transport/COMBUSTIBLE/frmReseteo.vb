Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmReseteo
    Private Cm As ContextMenuStrip = New ContextMenuStrip()

    Private CADENA As String = ""
    Private MALLA_PERSO As Boolean = False
    Private N_TOP As String = " TOP 300 "
    Private TIPO_TAB As Integer = 0
    Private NRow As Integer
    Private ENTRA_FG As Boolean = True
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub CARGAR_DATOS1()


        Try
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

            Dim menu1 As New ToolStripMenuItem() With {.Text = "Ocultar columna", .Name = "mnuItem1"}
            AddHandler menu1.Click, AddressOf MnuItem_Clicked
            Cm.Items.Add(menu1)

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(TIPO_TAB,0) AS TI_TAB FROM GCPARAMGENERALES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TIPO_TAB = dr("TI_TAB")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        TAB1.Dock = DockStyle.Fill
        BarHorasGen.Visible = False
        BarVales.Visible = False
        Try
            DERECHOS()

            Me.WindowState = FormWindowState.Maximized

            Fg1.Cols.Count = 1
            Fg1.DrawMode = DrawModeEnum.OwnerDraw

            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 50
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg.Cols.Count = 1
            Fg.Styles.Fixed.WordWrap = True
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then
                BarRecalculoGlobal.Visible = True
                BarRecalculoEvento2.Visible = True

                MnuMlla.Visible = True

                Fg.DragMode = DragModeEnum.Automatic
                Fg.AllowDragging = AllowDraggingEnum.Columns
            Else
                MnuMlla.Visible = False
                BarRecalculoGlobal.Visible = False
                BarRecalculoEvento2.Visible = False
            End If
            BarVales.Visible = False

            N_TOP = " TOP 3000 "
            CADENA = " WHERE R.STATUS = 'A' ORDER BY R.FECHAELAB DESC"
            Select Case TIPO_TAB
                Case 0
                    BarHorasGen.Visible = True
                    Fg.Cols.Count = 45
                    'TITULOS()
                    Pag2.TabVisible = False
                    TITULOS_TABLA()
                    DESPLEGAR()
                Case 1
                    'TITULOS_TABLA()
                    BarHorasGen.Visible = True
                    Fg.Cols.Count = 45
                    DESPLEGAR_VIKINGOS()
                Case 2
                    Fg.Cols.Count = 45
                    Pag2.TabVisible = False
                    'TITULOS()
                    TITULOS_TABLA()
                    DESPLEGAR()
            End Select

            Try
                If PASS_GRUPOCE.ToUpper = "WINAS" Then
                    For k = 1 To Fg.Cols.Count - 1
                        Fg(0, k) = Fg(0, k) & " " & k
                    Next
                End If
                Fg.Cols(0).Width = 60
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmReseteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            'Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            'Fg.Styles("Alternate").BackColor = Color.SlateBlue  ' .PowderBlue
            'Fg.Styles("Highlight").BackColor = Color.CornflowerBlue
            'Fg.Styles("Focus").BackColor = Color.CornflowerBlue
            'Fg.Styles("Focus").Border.Color = Color.Red
            'Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            'Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double

        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuItem_Clicked(sender As Object, e As EventArgs)
        Try
            If PASS_GRUPOCE = "BR3FRAJA" Then
                Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
                If item IsNot Nothing Then
                    Fg.Cols(Fg.Col).Visible = False
                End If
            End If
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR()
        Dim s As String, FN(42) As String, z As Integer = 0, ErrorDetec As Boolean = False
        Fg.BeginUpdate()
        Fg.Redraw = False
        Fg.Cols.Count = 44

        If MALLA_PERSO Then
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT TIPO_CAMPO, CAMPO FROM GCCAMPO_X_MALLA ORDER BY ORDEN_N"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            FN(z) = dr("CAMPO")
                            If EXIST_FIELD_SQL_SAE("GCRESETEO", FN(z)) Then
                                ErrorDetec = True
                            End If
                            'BACKUPTXT("RESETDATATYPE", "TIPO_CAMPO:" & dr("TIPO_CAMPO").ToString & " CAMPO:" & dr("CAMPO").GetType().ToString)
                            z += 1
                        End While
                    End Using
                End Using

                If ErrorDetec Then
                    MALLA_PERSO = False
                End If
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If

        Try
            Fg.Rows.Count = 1 'PREDETERMINADO     PREDETERMINADO     PREDETERMINADO     PREDETERMINADO     PREDETERMINADO     PREDETERMINADO     

            SQL = "SELECT " & N_TOP & " R.CVE_RES, R.ESTADO, R.FECHA, R.CVE_OPER, NOMBRE, R.NO_LIQUI, U.CLAVEMONTE, M.DESCR AS NOMBREMOTOR, 
                MO.DESCR AS DESCR_MOD, R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, R.CAL_GLO_EVA, BONO_RES, R.ODOMETRO, R.KM_ECM, 
                R.LTS_ECM, R.LTS_REAL, R.LTS_AUTORIZADOS, ISNULL(R.LTS_DESCONTAR,0) AS LTS_DESC, R.KMS_TAB, R.LTS_TAB, R.FAC_CARGA, 
                R.HRS_TRABAJO, R.HRS_PTO_RALENTI, R.LTS_PTO_RALENTI, R.PORC_TIEMPO_PTO_RALENTI, R.PORC_LTS_PTO_RALENTI, R.REND_ECM, 
                R.PORC_VAR_LTS_ECM_REAL, R.PORC_VAR_LTS_TAB_REAL, R.REND_REAL, R.DIF_LTS_REAL_LTS_ECM, R.DIF_LTS_REAL_LTS_TAB, 
                R.FECHAELAB, R.UUID, R.PORC_TOL_EVENTO2, R.LTS_AUTORIZADOS2, R.LTS_VALES2, R.PRECIO_X_LTS2, R.DESCXLITROS2, 
                CASE WHEN ISNULL(R.EVENTO,0) = 0 THEN R.LTS_DESCONTAR ELSE R.LTS_DESCONTAR2 END AS LTS_DESC_EVEN, ISNULL(R.EVENTO,0) AS EVENT,
                VELMAX, RPM_MAX, CALIF_RPM, NO_VIAJE
                FROM GCRESETEO R 
                Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
                Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
                Left Join GCMODELO_UNIDAD MO ON MO.CVE_MOD = U.CVE_MODELO
                LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT " & CADENA

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If MALLA_PERSO Then

                            '   0                 1                   2                   3                   4
                            s = "" & vbTab & VN(dr(FN(0))) & vbTab & VN(dr(FN(1))) & vbTab & VN(dr(FN(2))) & vbTab & VN(dr(FN(3))) & vbTab
                            '          5                  6                   7                   8
                            s &= VN(dr(FN(4))) & vbTab & VN(dr(FN(5))) & vbTab & VN(dr(FN(6))) & vbTab & VN(dr(FN(7))) & vbTab
                            '         9                   10                  11                   12
                            s &= VN(dr(FN(8))) & vbTab & VN(dr(FN(9))) & vbTab & VN(dr(FN(10))) & vbTab & VN(dr(FN(11))) & vbTab
                            '          13                   14                   15                   16
                            s &= VN(dr(FN(12))) & vbTab & VN(dr(FN(13))) & vbTab & VN(dr(FN(14))) & vbTab & VN(dr(FN(15))) & vbTab
                            '          17                  18                   19                   20
                            s &= VN(dr(FN(16))) & vbTab & VN(dr(FN(17))) & vbTab & VN(dr(FN(18))) & vbTab & VN(dr(FN(19))) & vbTab
                            '         21                   22                   23 
                            s &= VN(dr(FN(20))) & vbTab & VN(dr(FN(21))) & vbTab & VN(dr(FN(22))) & vbTab
                            '          24                  25                   26
                            s &= VN(dr(FN(23))) & vbTab & VN(dr(FN(24))) & vbTab & VN(dr(FN(25))) & vbTab
                            '             27                       28                       29
                            s &= VN(dr(FN(26))) & vbTab & VN(dr(FN(27))) & vbTab & VN(dr(FN(28))) & vbTab
                            '             30                       31                       32
                            s &= VN(dr(FN(29))) & vbTab & VN(dr(FN(30))) & vbTab & VN(dr(FN(31))) & vbTab
                            '             33                       34                       35
                            s &= VN(dr(FN(32))) & vbTab & VN(dr(FN(33))) & vbTab & VN(dr(FN(34))) & vbTab
                            '             36                       37                       38
                            s &= VN(dr(FN(35))) & vbTab & VN(dr(FN(36))) & vbTab & VN(dr(FN(37))) & vbTab
                            '             39                       40                       41                       42                  43
                            s &= VN(dr(FN(38))) & vbTab & VN(dr(FN(39))) & vbTab & VN(dr(FN(40))) & vbTab & VN(dr(FN(41)) & vbTab & VN(dr(FN(42))))
                        Else
                            s = "" & vbTab & dr("CVE_RES") & vbTab & dr("ESTADO") & vbTab & dr("FECHA") & vbTab & dr("NOMBRE") & vbTab
                            '            5                         6                         7                           8
                            s &= dr("NO_LIQUI") & vbTab & dr("CLAVEMONTE") & vbTab & dr("DESCR_MOD") & vbTab & dr("NOMBREMOTOR") & vbTab
                            '               9                            10                            11                          12
                            s &= dr("CAL_FAC_CAR_EVA") & vbTab & dr("CAL_RAL_EVA") & vbTab & dr("CALIF_VEL_MAX") & vbTab & dr("CAL_GLO_EVA") & vbTab
                            '            13                      14                      15                      16
                            s &= dr("BONO_RES") & vbTab & dr("ODOMETRO") & vbTab & dr("KM_ECM") & vbTab & dr("LTS_ECM") & vbTab
                            '            17                      18                      19                               20
                            s &= dr("REND_ECM") & vbTab & dr("LTS_REAL") & vbTab & dr("REND_REAL") & vbTab & dr("DIF_LTS_REAL_LTS_ECM") & vbTab
                            '            21                               22                                    23 
                            s &= dr("LTS_DESC_EVEN") & vbTab & dr("PORC_VAR_LTS_ECM_REAL") & " %" & vbTab & dr("FAC_CARGA") & vbTab
                            '            24                             25                                  26
                            s &= dr("HRS_TRABAJO") & vbTab & dr("HRS_PTO_RALENTI") & vbTab & dr("PORC_TIEMPO_PTO_RALENTI") & " %" & vbTab
                            '            27                                   28                                      29
                            s &= dr("LTS_PTO_RALENTI") & vbTab & dr("PORC_LTS_PTO_RALENTI") & " %" & vbTab & dr("LTS_AUTORIZADOS") & vbTab
                            '            30                     31                              32
                            s &= dr("KMS_TAB") & vbTab & dr("LTS_TAB") & vbTab & dr("PORC_VAR_LTS_TAB_REAL") & vbTab
                            '            33                                      34                            35
                            s &= dr("DIF_LTS_REAL_LTS_TAB") & vbTab & dr("PORC_TOL_EVENTO2") & vbTab & dr("LTS_AUTORIZADOS2") & vbTab
                            '            36                          37                              38                         39 
                            s &= dr("LTS_VALES2") & vbTab & dr("DESCXLITROS2") & vbTab & dr("PRECIO_X_LTS2") & vbTab & dr("Event") & vbTab
                            '           40                    41                        42                      43
                            s &= dr("VELMAX") & vbTab & dr("RPM_MAX") & vbTab & dr("CALIF_RPM") & vbTab & dr.ReadNullAsEmptyString("NO_VIAJE")
                        End If
                        Fg.AddItem(s)
                    End While
                End Using
            End Using

            Fg.Cols(4).Width = 300
            'Fg.AutoSizeCols()
            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
                If NRow > 0 Then
                    Fg.Row = NRow
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Fg.EndUpdate()
    End Sub

    Private Function VN(FDATO) As String
        Dim REGRESA As String = ""
        Try
            If IsDBNull(FDATO) AndAlso IsNothing(FDATO) Then
                REGRESA = ""
            Else
                REGRESA = FDATO
            End If
        Catch ex As Exception
        End Try
        Return REGRESA
    End Function
    Sub DESPLEGAR_VIKINGOS2()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            Fg.Redraw = False

            SQL = "SELECT " & N_TOP & " R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, NOMBRE, R.NO_LIQUI, R.CVE_UNI, U.CLAVEMONTE,
                M.DESCR As NOMBREMOTOR, R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, CAL_GLO_EVA, BONO_RES, R.ODOMETRO, KM_ECM,
                LTS_ECM, LTS_REAL, LTS_AUTORIZADOS, LTS_DESCONTAR, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI,
                LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI, PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL,
                REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB, R.FECHAELAB, R.UUID,
                ISNULL((SELECT MIN(FECHA_IDA) FROM GCRESET_TAB_VIKINGOS_PAR WHERE CVE_RES = R.CVE_RES),'') AS F_IDA_INI,
                ISNULL((SELECT MAX(FECHA_IDA) FROM GCRESET_TAB_VIKINGOS_PAR WHERE CVE_RES = R.CVE_RES),'') AS F_IDA_FIN,
                PORC_TOL_EVENTO2, LTS_AUTORIZADOS2, LTS_VALES2, LTS_DESCONTAR2, PRECIO_X_LTS2, DESCXLITROS2
                FROM GCRESETEO R 
                Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
                Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
                LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT " &
                CADENA
            '█████████████████████████████████████████████████████████████████████████████████████████████████████████
            'VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_RES") & vbTab & dr("STATUS") & vbTab & dr("ESTADO") & vbTab & dr("FECHA") & vbTab &
                           dr("NOMBRE") & vbTab & dr("NO_LIQUI") & vbTab &
                           IIf(dr("F_IDA_INI") = "01/01/1900", "", dr("F_IDA_INI")) & vbTab &
                           IIf(dr("F_IDA_FIN") = "01/01/1900", "", dr("F_IDA_FIN")) & vbTab &
                           dr("CLAVEMONTE") & vbTab & dr("NOMBREMOTOR") & vbTab & dr("CAL_FAC_CAR_EVA") & vbTab &
                           dr("CAL_RAL_EVA") & vbTab & dr("CALIF_VEL_MAX") & vbTab & dr("CAL_GLO_EVA") & vbTab & dr("BONO_RES") & vbTab &
                           dr("ODOMETRO") & vbTab & dr("KM_ECM") & vbTab & dr("LTS_ECM") & vbTab & dr("LTS_REAL") & vbTab &
                           dr("LTS_AUTORIZADOS") & vbTab & dr("LTS_DESCONTAR") & vbTab & dr("KMS_TAB") & vbTab & dr("LTS_TAB") & vbTab &
                           dr("FAC_CARGA") & vbTab & dr("HRS_TRABAJO") & vbTab & dr("HRS_PTO_RALENTI") & vbTab &
                           dr("LTS_PTO_RALENTI") & vbTab & dr("PORC_TIEMPO_PTO_RALENTI") & vbTab &
                           dr("PORC_LTS_PTO_RALENTI") & vbTab & dr("REND_ECM") & vbTab & dr("PORC_VAR_LTS_ECM_REAL") & vbTab &
                           dr("PORC_VAR_LTS_TAB_REAL") & vbTab & dr("REND_REAL") & vbTab & dr("DIF_LTS_REAL_LTS_ECM") & vbTab &
                           dr("DIF_LTS_REAL_LTS_TAB") & vbTab & dr("PORC_TOL_EVENTO2") & vbTab & dr("LTS_AUTORIZADOS2") & vbTab &
                           dr("LTS_VALES2") & vbTab & dr("LTS_DESCONTAR2") & vbTab & dr("PRECIO_X_LTS2") & vbTab & dr("DESCXLITROS2"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()
            'VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     
            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
                If NRow > 0 Then
                    Fg.Row = NRow
                End If
            Catch ex As Exception
            End Try

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarNuevo.Visible = False
                BarEdit.Visible = False
                BarEliminar.Visible = False
                BarReactivarReseteo.Visible = False
                BarEliminarValesDiesel.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "Select CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                CLAVE >= 81000 AND CLAVE <= 81530"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 81005 'NUEVO
                                    BarNuevo.Visible = True
                                Case 81010 'EDIT
                                    BarEdit.Visible = True
                                Case 81015 'CANCELAR
                                    BarEliminar.Visible = True
                                Case 81090
                                    BarReactivarReseteo.Visible = True
                                    BarEliminarValesDiesel.Visible = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmReseteo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Reseteo")
        Me.Dispose()

    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"

            FrmReseteoAE.ShowDialog()

            'DESPLEGAR()

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function GET_COL_CVE_RESET(FCLAVE As String, FROW As Integer) As String
        Dim ContenidoFg As String = "0"
        Try
            For col_ = 1 To Fg.Cols.Count - 1
                If Fg(0, col_) = FCLAVE Then
                    ContenidoFg = Fg(FROW, col_)
                    Exit For
                End If
            Next
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ContenidoFg
    End Function

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then
                Var1 = "Edit"

                NRow = Fg.Row

                'FrmReseteoAE.ShowDialog()
                Select Case TIPO_TAB
                    Case 0, 2
                        Var2 = GET_COL_CVE_RESET("Clave", Fg.Row)

                        If Var2.Trim.Length = 0 Or Not IsNumeric(Var2) Or CLng(Var2) = 0 Then
                            Var2 = GET_COL_CVE_RESET("Reseteo", Fg.Row)
                        End If

                        If Var2.Trim.Length = 0 Then
                            MsgBox("Por favor seleccione un reseteo")
                            Return
                        End If

                        If Not IsNumeric(Var2) Then
                            MsgBox("Por favor seleccione un reseteo")
                            Return
                        End If
                        If CLng(Var2) = 0 Then
                            MsgBox("Por favor seleccione un reseteo")
                            Return
                        End If

                        Dim form As New FrmReseteoAE
                        form.ShowDialog()
                        form.MdiParent = MainRibbonForm

                        'DESPLEGAR()
                    Case 1

                        Var2 = Fg(Fg.Row, 1)

                        Dim form As New FrmReseteoAE
                        form.ShowDialog()
                        form.MdiParent = MainRibbonForm

                        'DESPLEGAR_VIKINGOS()

                    Case Else
                        Dim form As New FrmReseteoAE
                        form.ShowDialog()
                        form.MdiParent = MainRibbonForm

                        DESPLEGAR()
                End Select

            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Dim ValorCelda As String, CLAVE_RES As Long

        Try 'Fg(Fg.Row, 2) = "EN LIQUIDACION"

            CLAVE_RES = GET_COL_CVE_RESET("Reseteo", Fg.Row)
            If CLAVE_RES = 0 Then
                CLAVE_RES = GET_COL_CVE_RESET("Clave", Fg.Row)
            End If

            ValorCelda = GET_COL_CVE_RESET("Estado", Fg.Row)

            If ValorCelda = "EN LIQUIDACION" Then
                MsgBox("El reseteo se encuentra en liquidación no es posible cancelarlo")
                Return
            End If
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                SQL = "UPDATE GCRESETEO SET STATUS = 'B' WHERE CVE_RES = " & CLAVE_RES
                Dim cmd As New SqlCommand With {.Connection = cnSAE, .CommandText = SQL}
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        If TIPO_TAB = 1 Then

                            For k = 1 To Fg.Rows.Count - 1
                                If Not IsNothing(CLAVE_RES) Then
                                    If IsNumeric(CLAVE_RES) Then
                                        Try
                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                SQL = "UPDATE GCTABULADOR_EXCEL SET CVE_RES = '' WHERE CVE_RES = " & CLAVE_RES
                                                cmd2.CommandText = SQL
                                                returnValue = cmd2.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            'MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                            Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                        End Try
                                    End If
                                End If
                            Next
                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "DELETE FROM GCRESET_TAB_VIKINGOS_PAR WHERE CVE_RES = " & CLAVE_RES
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                'MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try


                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET CVE_RESET = '' WHERE CVE_RESET = " & CLAVE_RES
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                'MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try

                        End If

                        MsgBox("El registro se eliminó satisfactoriamente")

                        Select Case TIPO_TAB
                            Case 0
                                DESPLEGAR()
                            Case 1
                                DESPLEGAR_VIKINGOS()
                            Case 2
                                DESPLEGAR()
                        End Select

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
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarEdit_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        CADENA = " WHERE R.STATUS = 'A' AND FECHA = '" & FSQL(Date.Now) & "' ORDER BY R.FECHAELAB DESC"
        Select Case TIPO_TAB
            Case 0
                DESPLEGAR()
            Case 1
                DESPLEGAR_VIKINGOS()
            Case 2
                DESPLEGAR()
        End Select
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        N_TOP = ""
        dt = dt.AddDays(-1)
        CADENA = " WHERE R.STATUS = 'A' AND FECHA = '" & FSQL(dt) & "' ORDER BY R.FECHAELAB DESC"
        Select Case TIPO_TAB
            Case 0
                DESPLEGAR()
            Case 1
                DESPLEGAR_VIKINGOS()
            Case 2
                DESPLEGAR()
        End Select
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        N_TOP = ""
        CADENA = " WHERE R.STATUS = 'A' AND MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " ORDER BY R.FECHAELAB DESC"
        Select Case TIPO_TAB
            Case 0
                DESPLEGAR()
            Case 1
                DESPLEGAR_VIKINGOS()
            Case 2
                DESPLEGAR()
        End Select
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        N_TOP = ""
        CADENA = " WHERE R.STATUS = 'A' AND MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " ORDER BY R.FECHAELAB DESC"
        Select Case TIPO_TAB
            Case 0
                DESPLEGAR()
            Case 1
                DESPLEGAR_VIKINGOS()
            Case 2
                DESPLEGAR()
        End Select
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        N_TOP = ""
        CADENA = " WHERE R.STATUS = 'A' ORDER BY R.FECHAELAB DESC"
        Select Case TIPO_TAB
            Case 0
                DESPLEGAR()
            Case 1
                'DESPLEGAR()
                DESPLEGAR_VIKINGOS()
            Case 2
                DESPLEGAR()
        End Select
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click

        Try
            If TAB1.SelectedIndex = 0 Then
                N_TOP = " TOP 2500 "
                CADENA = " WHERE R.STATUS = 'A' ORDER BY R.FECHAELAB DESC"

                Select Case TIPO_TAB
                    Case 0
                        DESPLEGAR()
                    Case 1
                        'DESPLEGAR()
                        DESPLEGAR_VIKINGOS()
                    Case 2
                        DESPLEGAR()
                End Select

            Else
                DESPLEGAR1()
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            If TAB1.SelectedIndex = 0 Then
                EXPORTAR_EXCEL_TRANSPORT(Fg, "RESETEO")
            Else
                EXPORTAR_EXCEL_TRANSPORT(Fg1, "VALES DIESEL")
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarRecalculoGlobal_Click(sender As Object, e As EventArgs) Handles BarRecalculoGlobal.Click
        frmRESETEORecalculoGlobal.ShowDialog()
    End Sub

    Private Sub BtnDesplegar_Click(sender As Object, e As EventArgs) Handles btnDesplegar.Click
        Try
            N_TOP = ""
            'CADENA = " WHERE R.STATUS = 'A' ORDER BY R.FECHAELAB DESC"
            CADENA = " WHERE R.STATUS = 'A' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' ORDER BY R.FECHAELAB DESC"
            Select Case TIPO_TAB
                Case 0
                    DESPLEGAR()
                Case 1
                    DESPLEGAR_VIKINGOS()
                Case 2
                    DESPLEGAR
            End Select
        Catch ex As Exception
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImprimirGastosDiesel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BarReactivarReseteo_Click(sender As Object, e As EventArgs) Handles BarReactivarReseteo.Click
        Try
            Dim ValorCelda As String = "", CLAVE_RES As Long
            If Fg.Row > 0 Then

                Select Case TIPO_TAB
                    Case 0, 2
                        'Fg(Fg.Row, 2) <> "FINALIZADO"
                        ValorCelda = GET_COL_CVE_RESET("Estado", Fg.Row)
                        CLAVE_RES = GET_COL_CVE_RESET("Reseteo", Fg.Row)
                        If CLAVE_RES = 0 Then
                            CLAVE_RES = GET_COL_CVE_RESET("Clave", Fg.Row)
                        End If

                        If ValorCelda <> "FINALIZADO" Then
                            MsgBox("No es posible reactivar el reseteo, para poder reactivar debe de estar como FINALIZADO")
                            Return
                        End If
                    Case 1
                        'Fg(Fg.Row, 2) <> "FINALIZADO"
                        If Fg(Fg.Row, 3) <> "FINALIZADO" Then
                            MsgBox("No es posible reactivar el reseteo, para poder reactivar debe de estar como FINALIZADO")
                            Return
                        End If
                        CLAVE_RES = Fg(Fg.Row, 1)
                End Select

                If MsgBox("Realmente desea reactivar el reseteo?", vbYesNo) = vbYes Then

                    Try
                        SQL = "UPDATE GCRESETEO SET ESTADO = 'EDICION' WHERE CVE_RES = " & CLAVE_RES
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    MsgBox("El resteo se reactivo correctamente")

                                    N_TOP = " TOP 5000 "
                                    CADENA = " WHERE R.STATUS = 'A' ORDER BY R.FECHAELAB DESC"
                                    Select Case TIPO_TAB
                                        Case 0
                                            DESPLEGAR
                                        Case 1
                                            DESPLEGAR_VIKINGOS()
                                        Case 2
                                            DESPLEGAR
                                    End Select

                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try

                End If
            End If

        Catch ex As Exception
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TAB1_SelectedTabChanged(sender As Object, e As EventArgs) Handles TAB1.SelectedTabChanged
        Try
            Select Case TAB1.SelectedIndex
                Case 0
                    BarNuevo.Visible = True
                    BarEdit.Visible = True
                    BarEliminar.Visible = True
                    BarraAbajo.Visible = True
                    BarReactivarReseteo.Visible = True

                    BarVales.Visible = False

                    C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)
                Case 1
                    BarNuevo.Visible = False
                    BarEdit.Visible = False
                    BarEliminar.Visible = False
                    BarraAbajo.Visible = False
                    BarReactivarReseteo.Visible = False

                    BarVales.Visible = True

                    C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg1, C1FlexGridSearchPanel1)
                    DESPLEGAR1()
            End Select
        Catch ex As Exception
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR1()
        Try
            Fg1.Redraw = False

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            '0000003031
            'GCASIGNACION_VIAJE_VALES FECHA_CARGA
            'ISNULL(STUFF((SELECT ', ' + cast(NUM_VIAJE as varchar(10)) FROM GCRESET_TAB_VIKINGOS_PAR S WHERE S.CVE_RES = GV.CVE_RESET FOR XML PATH ('')),1,1, ''),'') AS 'Viajes', 
            'ISNULL(V.CVE_TRACTOR,'') AS 'Unidad', 

            SQL = "SELECT TOP 2500 ISNULL(GV.ST_VALES,'EDICION') AS 'Estatus vale', RIGHT('0000000000'+ISNULL(GV.FOLIO,''),10) AS 'Folio', 
                ISNULL((SELECT CLAVEMONTE FROM GCRESETEO R LEFT JOIN GCUNIDADES U ON U.CLAVE = R.CVE_UNI WHERE R.CVE_RES = GV.CVE_RESET),'') AS 'Unidad', 
                CVE_RESET as 'Reseteo', ISNULL(GV.CVE_OPER,'') AS 'Clave oper.', 
                ISNULL(O.NOMBRE,'') AS 'Operador', ISNULL(GV.FACTURA,'') AS 'Factura', ISNULL(GV.FECHA,'') AS 'Fecha', 
                ISNULL(GV.FECHA_CARGA,'') AS 'Fecha carga', GV.CVE_VIAJE AS 'Viaje',
                '(' + RTRIM(LTRIM(ISNULL(G.CVE_PROV,''))) + ') ' + ISNULL(P.NOMBRE,'') AS 'Proveedor', 
                ISNULL(GV.CVE_GAS,'') AS 'Clave', '('  + ISNULL(GV.CVE_GAS,'') + ')   ' + ISNULL(G.DESCR,'') AS 'Gasolinera', 
                ISNULL(GV.LITROS,0) AS 'Litros iniciales', ISNULL(GV.LITROS_REALES,0) AS 'Litros reales', ISNULL(GV.P_X_LITRO,0) AS 'P. X litro', 
                ISNULL(GV.SUBTOTAL,0) AS 'Subtotal', ISNULL(GV.IVA,0) AS 'IVA', ISNULL(GV.IEPS,0) AS 'IEPS', ISNULL(GV.IMPORTE,0) AS 'Importe', 
                ISNULL(GV.FACTURA,'') AS 'Factura', ISNULL(GV.OBS,'') AS 'Observaciones', GV.UUID AS 'Id'
                FROM GCASIGNACION_VIAJE_VALES GV
                LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = GV.CVE_VIAJE                
                LEFT JOIN GCOPERADOR O ON O.CLAVE = GV.CVE_OPER 
                LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV
                WHERE ISNULL(GV.STATUS,'A') = 'A' AND (ST_VALES = 'CAPTURADO' or ST_VALES = 'ACEPTADO')
                ORDER BY RIGHT('0000000000'+ISNULL(GV.FOLIO,''),10) DESC"
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg1.DataSource = BindingSource1.DataSource
            Fg1.Redraw = True

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg1.Cols.Count - 1
                    Fg1(0, k) = Fg1(0, k) & k
                Next
            End If
            Fg1.Redraw = True
            If Fg1.Rows.Count > 1 Then
                Fg1.AutoSizeRows()
                Fg1.Cols(8).Width = 0

                If NRow > 0 Then
                    Fg1.Row = NRow
                Else
                    Fg1.Row = 1
                End If
            End If
            NRow = 0
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS_TABLA()
        Dim z As Integer = 1, h As Integer = 0

        Try
            If EXIST_LA_TABLA("GCCAMPO_X_MALLA") Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CAMPO, TIPO_CAMPO, ALINEADO, LEYENDA, ISNULL(LEYENDA_N,'') AS LEYEN_N, ORDEN_N, 
                    ISNULL(VISIBLE,1) AS VIS
                    FROM GCCAMPO_X_MALLA 
                    WHERE MODULO = 'RESETEO' AND PROCESO = '0'
                    ORDER BY ORDEN_N"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            If dr("VIS") = 0 Then
                                Fg.Cols(z).Visible = False
                            Else
                                Fg.Cols(z).Visible = True
                            End If

                            Fg(0, z) = dr("LEYEN_N")

                            Debug.Print(dr("LEYEN_N").GetType.ToString)

                            Dim cc1 As Column = Fg.Cols(z)
                            Select Case dr("TIPO_CAMPO")
                                Case "INT", "IINT"
                                    cc1.DataType = GetType(Int32)
                                Case "STRING"
                                    cc1.DataType = GetType(String)
                                Case "DECIMAL"
                                    cc1.DataType = GetType(Decimal)
                                    Fg.Cols(z).Format = "###,###,##0.00"
                                Case "DATETIME", "DATE"
                                    cc1.DataType = GetType(DateTime)
                                Case Else
                                    cc1.DataType = GetType(String)
                            End Select
                            If PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
                                cc1.AllowDragging = True
                            End If
                            z += 1
                            h += 1
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            h = 0
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If h = 0 Then
            MALLA_PERSO = False
            TITULOS()
        Else
            MALLA_PERSO = True
        End If

    End Sub
    Sub TITULOS()
        Fg.Cols.Count = 44
        Try
            Fg(0, 1) = "Reseteo"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)
            cc1.AllowDragging = True

            Fg(0, 2) = "Estado"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)
            c2.AllowDragging = True

            Fg(0, 3) = "Fecha"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(DateTime)
            c3.AllowDragging = True

            Fg(0, 4) = "Operador"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)
            c4.AllowDragging = True

            Fg(0, 5) = "No. liquidación"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)
            c5.AllowDragging = True

            Fg(0, 6) = "Unidad"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)
            c6.AllowDragging = True

            Fg(0, 7) = "Modelo"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)
            c7.AllowDragging = True

            Fg(0, 8) = "Motor"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)
            c8.AllowDragging = True

            Fg(0, 9) = "Calif. factor carga"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"
            c9.AllowDragging = True

            Fg(0, 10) = "Calif. ralenti"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"
            c10.AllowDragging = True

            Fg(0, 11) = "Calif. vel. max."
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"
            c11.AllowDragging = True

            Fg(0, 12) = "Calif. global"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"
            c12.AllowDragging = True

            Fg(0, 13) = "Bono"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"
            c13.AllowDragging = True

            Fg(0, 14) = "Odometro"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"
            c14.AllowDragging = True

            Fg(0, 15) = "Km ECM"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"
            c15.AllowDragging = True

            Fg(0, 16) = "Lts. ECM"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"
            c16.AllowDragging = True

            Fg(0, 17) = "Rendimiento ECM"
            Dim c17 As Column = Fg.Cols(17)
            c17.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"
            c17.AllowDragging = True

            Fg(0, 18) = "Lts. Real"
            Dim c18 As Column = Fg.Cols(18)
            c18.DataType = GetType(Decimal)
            Fg.Cols(18).Format = "###,###,##0.00"
            c18.AllowDragging = True

            Fg(0, 19) = "Rendimiento real"
            Dim c19 As Column = Fg.Cols(19)
            c19.DataType = GetType(Decimal)
            Fg.Cols(19).Format = "###,###,##0.00"
            c19.AllowDragging = True

            Fg(0, 20) = "Dif. lts. real. lts. ECM"
            Dim c20 As Column = Fg.Cols(20)
            c20.DataType = GetType(Decimal)
            Fg.Cols(20).Format = "###,###,##0.00"
            c20.AllowDragging = True

            Fg(0, 21) = "Lts. a descontar"
            Dim c21 As Column = Fg.Cols(21)
            c21.DataType = GetType(Decimal)
            Fg.Cols(21).Format = "###,###,##0.00"
            c21.AllowDragging = True

            Fg(0, 22) = "Porc. var. lts. real" '%
            Dim c22 As Column = Fg.Cols(22)
            c22.DataType = GetType(Decimal)
            Fg.Cols(22).TextAlign = TextAlignEnum.RightCenter
            c22.AllowDragging = True

            Fg(0, 23) = "Factor de carga"
            Dim c23 As Column = Fg.Cols(23)
            c23.DataType = GetType(Int16)
            c23.AllowDragging = True

            Fg(0, 24) = "Hrs. trabajo"
            Dim c24 As Column = Fg.Cols(24)
            c24.DataType = GetType(Decimal)
            Fg.Cols(24).Format = "###,###,##0.00"
            c24.AllowDragging = True

            Fg(0, 25) = "Hrs. PTO. RALENTI"
            Dim c25 As Column = Fg.Cols(25)
            c25.DataType = GetType(Decimal)
            Fg.Cols(25).Format = "###,###,##0.00"
            c25.AllowDragging = True

            Fg(0, 26) = "% Tiempo PTO RALENTI" '%
            Dim c26 As Column = Fg.Cols(26)
            c26.DataType = GetType(Decimal)
            Fg.Cols(26).TextAlign = TextAlignEnum.RightCenter
            c26.AllowDragging = True

            Fg(0, 27) = "Lts. PTO. RALENTI"
            Dim c27 As Column = Fg.Cols(27)
            c27.DataType = GetType(Decimal)
            Fg.Cols(27).Format = "###,###,##0.00"
            c27.AllowDragging = True

            Fg(0, 28) = "% Lts PTO RALENTI" '%
            Dim c28 As Column = Fg.Cols(28)
            c28.DataType = GetType(Decimal)
            Fg.Cols(28).TextAlign = TextAlignEnum.RightCenter
            c28.AllowDragging = True

            Fg(0, 29) = "Lts. autorizados"
            Dim c29 As Column = Fg.Cols(29)
            c29.DataType = GetType(Decimal)
            Fg.Cols(29).Format = "###,###,##0.00"
            c29.AllowDragging = True

            Fg(0, 30) = "KM. Tabulador"
            Dim c30 As Column = Fg.Cols(30)
            c30.DataType = GetType(Decimal)
            Fg.Cols(30).Format = "###,###,##0.00"
            c30.AllowDragging = True

            Fg(0, 31) = "LTS. Tabulador"
            Dim c31 As Column = Fg.Cols(31)
            c31.DataType = GetType(Decimal)
            Fg.Cols(31).Format = "###,###,##0.00"
            c31.AllowDragging = True

            Fg(0, 32) = "Porc. var. lts. tab. real"
            Dim c32 As Column = Fg.Cols(32)
            c32.DataType = GetType(Decimal)
            Fg.Cols(32).Format = "###,###,##0.00"
            c32.AllowDragging = True

            Fg(0, 33) = "Dif. lts. real lts. TAB"
            Dim c33 As Column = Fg.Cols(33)
            c33.DataType = GetType(Decimal)
            Fg.Cols(33).Format = "###,###,##0.00"
            c33.AllowDragging = True

            Fg(0, 34) = "% Tolerancia evento 2"
            Dim c34 As Column = Fg.Cols(34)
            c34.DataType = GetType(Decimal)
            Fg.Cols(34).Format = "###,###,##0.00"
            c34.AllowDragging = True

            Fg(0, 35) = "Litros autorizados evento 2"
            Dim c35 As Column = Fg.Cols(35)
            c35.DataType = GetType(Decimal)
            Fg.Cols(35).Format = "###,###,##0.00"
            c35.AllowDragging = True

            Fg(0, 36) = "Litros vales evento 2"
            Dim c36 As Column = Fg.Cols(36)
            c36.DataType = GetType(Decimal)
            Fg.Cols(36).Format = "###,###,##0.00"
            c36.AllowDragging = True

            Fg(0, 37) = "Litros a descontar evento 2"
            Dim c37 As Column = Fg.Cols(37)
            c37.DataType = GetType(Decimal)
            Fg.Cols(37).Format = "###,###,##0.00"
            c37.AllowDragging = True

            Fg(0, 38) = "Precio por litro evento 2"
            Dim c38 As Column = Fg.Cols(38)
            c38.DataType = GetType(Decimal)
            Fg.Cols(38).Format = "###,###,##0.00"
            c38.AllowDragging = True

            Fg(0, 39) = "Evento"
            Dim c39 As Column = Fg.Cols(39)
            c39.DataType = GetType(Decimal)
            Fg.Cols(39).Format = "###,###,##0.00"
            c39.AllowDragging = True

            Fg(0, 40) = "Velocidad máxima"
            Dim c40 As Column = Fg.Cols(40)
            c40.DataType = GetType(Decimal)
            Fg.Cols(40).Format = "###,###,##0.00"
            c40.AllowDragging = True

            Fg(0, 41) = "RPM máxima"
            Dim c41 As Column = Fg.Cols(41)
            c41.DataType = GetType(Decimal)
            Fg.Cols(41).Format = "###,###,##0.00"
            c41.AllowDragging = True

            Fg(0, 42) = "Calif. RPM"
            Dim c42 As Column = Fg.Cols(42)
            c42.DataType = GetType(Decimal)
            Fg.Cols(42).Format = "###,###,##0.00"
            c42.AllowDragging = True

            Fg(0, 43) = "Num. viajes"
            Dim c43 As Column = Fg.Cols(43)
            c43.DataType = GetType(Decimal)
            Fg.Cols(43).Format = "###,###,##0.00"
            c43.AllowDragging = True

            If ENTRA_FG Then
                ENTRA_FG = False
                For k = 1 To Fg.Cols.Count - 1
                    If PASS_GRUPOCE = "BUS" Then
                        Fg(0, k) = k & "." & Fg(0, k)

                    End If
                Next
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub

    Sub TITULOS_VIKINGOS()

        Try
            Fg(0, 1) = "Reseteo"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Estado"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Fecha"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(DateTime)

            Fg(0, 5) = "Operador"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "No. liquidación"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            'NUEVAS COLUMNAS
            Fg(0, 7) = "Fecha ida inicial"
            Dim c66 As Column = Fg.Cols(7)
            c66.DataType = GetType(String)

            Fg(0, 8) = "Fecha ida final"
            Dim c67 As Column = Fg.Cols(8)
            c66.DataType = GetType(String)

            Fg(0, 9) = "Unidad"
            Dim c7 As Column = Fg.Cols(9)
            c7.DataType = GetType(String)

            Fg(0, 10) = "Viajes"
            Dim cc7 As Column = Fg.Cols(10)
            cc7.DataType = GetType(String)

            Fg(0, 11) = "Motor"
            Dim c8 As Column = Fg.Cols(11)
            c8.DataType = GetType(String)

            Fg(0, 12) = "Calif. factor carga"
            Dim c9 As Column = Fg.Cols(12)
            c9.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Calif. ralenti"
            Dim c10 As Column = Fg.Cols(13)
            c10.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Calif. vel. max."
            Dim c11 As Column = Fg.Cols(14)
            c11.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Calif. global"
            Dim c12 As Column = Fg.Cols(15)
            c12.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Bono"
            Dim c13 As Column = Fg.Cols(16)
            c13.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "Odometro"
            Dim c14 As Column = Fg.Cols(17)
            c14.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "Km ECM"
            Dim c15 As Column = Fg.Cols(18)
            c15.DataType = GetType(Decimal)
            Fg.Cols(18).Format = "###,###,##0.00"

            Fg(0, 19) = "Lts. ECM"
            Dim c16 As Column = Fg.Cols(19)
            c16.DataType = GetType(Decimal)
            Fg.Cols(19).Format = "###,###,##0.00"

            Fg(0, 20) = "Lts. Real"
            Dim c17 As Column = Fg.Cols(20)
            c17.DataType = GetType(Decimal)
            Fg.Cols(20).Format = "###,###,##0.00"

            Fg(0, 21) = "Lts. autorizados"
            Dim c18 As Column = Fg.Cols(21)
            c18.DataType = GetType(Decimal)
            Fg.Cols(21).Format = "###,###,##0.00"

            Fg(0, 22) = "Lts. a descontar"
            Dim c19 As Column = Fg.Cols(22)
            c19.DataType = GetType(Decimal)
            Fg.Cols(22).Format = "###,###,##0.00"

            Fg(0, 23) = "KM. Tabulador"
            Dim c20 As Column = Fg.Cols(23)
            c20.DataType = GetType(Decimal)
            Fg.Cols(23).Format = "###,###,##0.00"

            Fg(0, 24) = "LTS. Tabulador"
            Dim c21 As Column = Fg.Cols(24)
            c21.DataType = GetType(Decimal)
            Fg.Cols(24).Format = "###,###,##0.00"

            Fg(0, 25) = "Factor de carga"
            Dim c22 As Column = Fg.Cols(25)
            c22.DataType = GetType(Int16)

            Fg(0, 26) = "Hrs. trabajo"
            Dim c23 As Column = Fg.Cols(26)
            c23.DataType = GetType(Decimal)
            Fg.Cols(26).Format = "###,###,##0.00"

            Fg(0, 27) = "Hrs. PTO. RALENTI"
            Dim c24 As Column = Fg.Cols(27)
            c24.DataType = GetType(Decimal)
            Fg.Cols(27).Format = "###,###,##0.00"

            Fg(0, 28) = "Lts. PTO. RALENTI"
            Dim c25 As Column = Fg.Cols(28)
            c25.DataType = GetType(Decimal)
            Fg.Cols(28).Format = "###,###,##0.00"

            Fg(0, 29) = "% Tiempo PTO RALENTI"
            Dim c26 As Column = Fg.Cols(29)
            c26.DataType = GetType(Decimal)
            Fg.Cols(29).Format = "###,###,##0.00"

            Fg(0, 30) = "% Lts PTO RALENTI"
            Dim c27 As Column = Fg.Cols(30)
            c27.DataType = GetType(Decimal)
            Fg.Cols(30).Format = "###,###,##0.00"

            Fg(0, 31) = "Rendimiento ECM"
            Dim c28 As Column = Fg.Cols(31)
            c28.DataType = GetType(Decimal)
            Fg.Cols(31).Format = "###,###,##0.00"

            Fg(0, 32) = "Porc. var. lts. real"
            Dim c29 As Column = Fg.Cols(32)
            c29.DataType = GetType(Decimal)
            Fg.Cols(32).Format = "###,###,##0.00"

            Fg(0, 33) = "Porc. var. lts. tab. real"
            Dim c30 As Column = Fg.Cols(33)
            c30.DataType = GetType(Decimal)
            Fg.Cols(33).Format = "###,###,##0.00"

            Fg(0, 34) = "Rendimiento real"
            Dim c31 As Column = Fg.Cols(34)
            c31.DataType = GetType(Decimal)
            Fg.Cols(34).Format = "###,###,##0.00"

            Fg(0, 35) = "Dif. lts. real. lts. ECM"
            Dim c32 As Column = Fg.Cols(35)
            c32.DataType = GetType(Decimal)
            Fg.Cols(35).Format = "###,###,##0.00"

            Fg(0, 36) = "Dif. lts. real lts. TAB"
            Dim c33 As Column = Fg.Cols(36)
            c33.DataType = GetType(Decimal)
            Fg.Cols(36).Format = "###,###,##0.00"

            'PORC_TOL_EVENTO2, LTS_AUTORIZADOS2, LTS_VALES2, LTS_DESCONTAR2, PRECIO_X_LTS2, DESCXLITROS2
            Fg(0, 37) = "% Tolerancia evento 2"
            Dim c36 As Column = Fg.Cols(37)
            c36.DataType = GetType(Decimal)
            Fg.Cols(37).Format = "###,###,##0.00"

            Fg(0, 38) = "Litros autorizados evento 2"
            Dim c37 As Column = Fg.Cols(38)
            c37.DataType = GetType(Decimal)
            Fg.Cols(38).Format = "###,###,##0.00"

            Fg(0, 39) = "Litros vales evento 2"
            Dim c38 As Column = Fg.Cols(39)
            c38.DataType = GetType(Decimal)
            Fg.Cols(39).Format = "###,###,##0.00"

            Fg(0, 40) = "Litros a descontar evento 2"
            Dim c39 As Column = Fg.Cols(40)
            c39.DataType = GetType(Decimal)
            Fg.Cols(40).Format = "###,###,##0.00"

            Fg(0, 41) = "Precio por litro evento 2"
            Dim c40 As Column = Fg.Cols(41)
            c40.DataType = GetType(Decimal)
            Fg.Cols(41).Format = "###,###,##0.00"

            Fg(0, 42) = "Desc. por litros evento 2"
            Dim c41 As Column = Fg.Cols(42)
            c41.DataType = GetType(Decimal)
            Fg.Cols(42).Format = "###,###,##0.00"

            Fg(0, 43) = "Evento"
            Dim c43 As Column = Fg.Cols(43)
            c43.DataType = GetType(String)

            Fg(0, 44) = "Lts. ECM/Lts. Tabulador"
            Dim c44 As Column = Fg.Cols(44)
            c44.DataType = GetType(String)

            If ENTRA_FG Then
                ENTRA_FG = False
                For k = 1 To Fg.Cols.Count - 1
                    If PASS_GRUPOCE = "BUS" Then
                        Fg(0, k) = k & "." & Fg(0, k)
                    End If
                Next
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub RestaurarMalla()
        Try
            Select Case TIPO_TAB
                Case 0, 2
                    SQL = "SELECT * FROM GCCAMPO_X_MALLA WHERE MODULO = 'RESETEO' AND (PROCESO = '0' OR PROCESO = '2')"
                Case 1
                    SQL = "SELECT * FROM GCCAMPO_X_MALLA WHERE MODULO = 'RESETEO' AND PROCESO = '1'"
            End Select
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
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
            'e.Text = rowNumber.ToString()
            Fg(e.Row, 0) = rowNumber.ToString()

            'Select Case Fg(e.Row, 3)
            'Case "Cancelado"
            'Fg.SetCellStyle(e.Row, 3, cs2)
            'End Select
        End If
    End Sub
    Private Sub Fg_MouseDown(sender As Object, e As MouseEventArgs) Handles Fg.MouseDown
        Try
            If PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
                If Fg.Row > 0 Then
                    If Fg.ColSel = 1 Then

                    End If
                    If e.Button = MouseButtons.Right Then
                        Fg.ContextMenuStrip = Cm
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarGrabarMalla_Click_1(sender As Object, e As EventArgs) Handles BarGrabarMalla.Click
        Try
            Dim LEYENDA As String, VISIBLE As Integer = 0

            For k = 1 To Fg.Cols.Count - 1

                If Not IsNothing(Fg(0, k)) Then
                    LEYENDA = Fg(0, k)
                    LEYENDA = LEYENDA.Replace("'", "''")
                    If Fg.Cols(k).IsVisible Then
                        VISIBLE = 1
                    Else
                        VISIBLE = 0
                    End If
                    SQL = "UPDATE GCCAMPO_X_MALLA SET ORDEN_N = " & k & ", VISIBLE  = " & VISIBLE & "
                        WHERE LEYENDA = '" & LEYENDA & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                End If
            Next
            MsgBox("El orden en la malla se grabo correctamente")
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCfgMalla_Click(sender As Object, e As EventArgs) Handles BarCfgMalla.Click

        FrmOrdenMallas.ShowDialog()

        TITULOS_TABLA()
    End Sub

    Private Sub BarReporteVales_Click(sender As Object, e As EventArgs) Handles BarReporteVales.Click
        FrmReporteValesViking.ShowDialog()
    End Sub

    Private Function EXIST_LA_TABLA(fTABLA As String) As Boolean
        Dim Existe_Table As Boolean = False
        Try
            SQL = "SELECT * From INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & fTABLA & "'"
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            reader = cmd.ExecuteReader
            If reader.Read Then
                Existe_Table = True
            End If
            reader.Close()
        Catch ex As Exception
            BITACORADB("36. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & SQL)
        End Try
        Return Existe_Table

    End Function

    Private Sub BarEliminarValesDiesel_Click(sender As Object, e As EventArgs) Handles BarEliminarValesDiesel.Click
        Try
            If Fg1.Row < 0 Then
                MsgBox("Por favor seleccione un vale de combustible")
                Return
            End If

            If Not IsNothing(Fg1(Fg1.Row, 4)) Then

                If Fg1(Fg1.Row, 4).ToString.Trim.Length > 0 And Fg1(Fg1.Row, 4).ToString <> "0" Then

                    Dim ESTADO_RES As String = ""

                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT ISNULL(ESTADO,'') AS ESTAD FROM GCRESETEO WHERE CVE_RES = '" & Fg1(Fg1.Row, 4) & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    ESTADO_RES = dr("ESTAD")
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try

                    If ESTADO_RES <> "EDICION" Then
                        MsgBox("Por favor primero cancele el reseteo")
                        Return
                    End If
                End If
            End If

            If Not IsNothing(Fg1(Fg1.Row, 1)) Then
                If Fg1(Fg1.Row, 1) = "ACEPTADO" Then
                    MsgBox("Por favor primero REACTIVE el vale de combustible")
                    Return
                End If
            End If

            If MsgBox("Realmente desea eliminar el vale de combustible seleccionado?", vbYesNo) = vbYes Then
                Try
                    SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET STATUS = 'C', ST_VALES = 'CAPTURADO' 
                        WHERE FOLIO = '" & Fg1(Fg1.Row, 2) & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                                Try
                                    If IsNumeric(Fg1(Fg1.Row, 15)) AndAlso IsNumeric(Fg1(Fg1.Row, 4)) Then

                                        SQL = "UPDATE GCRESETEO SET 
                                            LTS_VALES = ISNULL(LTS_VALES,0) - " & Convert.ToDecimal(Fg1(Fg1.Row, 15)) & " 
                                            WHERE CVE_RES = " & Convert.ToInt32(Fg1(Fg1.Row, 4))
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then

                                                End If
                                            End If
                                        End Using
                                    End If
                                Catch ex As Exception
                                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                End Try

                                MsgBox("El vale se eliminó correctamente")

                                DESPLEGAR1()

                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarReActivarVale_Click(sender As Object, e As EventArgs) Handles BarReActivarVale.Click
        Try
            If Fg1.Row < 0 Then
                MsgBox("Por favor seleccione un vale de combustible")
                Return
            End If

            Dim ESTADO_RES As String = ""

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(ESTADO,'') AS ESTAD FROM GCRESETEO WHERE CVE_RES = '" & Fg1(Fg1.Row, 4) & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            ESTADO_RES = dr("ESTAD")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            If ESTADO_RES = "EDICION" Then
                If MsgBox("Realmente desea reactivar el vale de combustible seleccionado?", vbYesNo) = vbYes Then
                    Try
                        SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET ST_VALES = 'CAPTURADO' 
                        WHERE FOLIO = '" & Fg1(Fg1.Row, 2) & "'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    MsgBox("El vale se reactivo correctamente")

                                    DESPLEGAR1()

                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try
                End If
            Else
                If Not IsNothing(Fg1(Fg1.Row, 4)) AndAlso Fg1(Fg1.Row, 4) IsNot DBNull.Value Then
                    If Fg1(Fg1.Row, 4) > 0 Or Fg1(Fg1.Row, 4) = "0" Then
                        MsgBox("Por favor primero cancele el reseteo")
                        Return
                    End If
                End If

            End If


        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarReasignarValeDiesel_Click(sender As Object, e As EventArgs) Handles BarReasignarValeDiesel.Click
        Var1 = "Edit"
        Var3 = "Reasignar"
        Try
            Var4 = Fg1(Fg1.Row, 2)
            Var5 = Fg1(Fg1.Row, 5)
            Var6 = Fg1(Fg1.Row, 6)

            If Not IsNothing(Fg1(Fg1.Row, 4)) Then
                If Not IsDBNull(Fg1(Fg1.Row, 4)) Then
                    Var7 = Fg1(Fg1.Row, 4)
                End If
            End If

            frmConciValesComEditViking.ShowDialog()

            CADENA = " WHERE R.STATUS = 'A' ORDER BY R.FECHAELAB DESC"

            DESPLEGAR1()
            NRow = 0
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEditVale_Click(sender As Object, e As EventArgs) Handles BarEditVale.Click
        Var1 = "Edit"
        Var4 = ""
        Try
            Var4 = Fg1(Fg1.Row, 2)
            Var5 = Fg1(Fg1.Row, 5)
            Var6 = Fg1(Fg1.Row, 6)

            If Not IsNothing(Fg1(Fg1.Row, 4)) Then
                If Not IsDBNull(Fg1(Fg1.Row, 4)) Then
                    Var7 = Fg1(Fg1.Row, 4)
                End If
            End If

            frmConciValesComEditViking.ShowDialog()

            CADENA = " WHERE R.STATUS = 'A' ORDER BY R.FECHAELAB DESC"

            DESPLEGAR1()
            NRow = 0
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarHorasGen_Click(sender As Object, e As EventArgs) Handles BarHorasGen.Click
        FrmHorasGenerador.ShowDialog()
    End Sub
    Private Sub Fg1_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg1.OwnerDrawCell
        If e.Row >= Fg1.Rows.Fixed And e.Col = Fg1.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg1.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Sub DESPLEGAR_VIKINGOS()
        Dim LRC1 As Decimal, LRC2 As Decimal, LRC3 As Decimal, LRC4 As Decimal, LTS_REAL As Decimal

        Try
            Dim s As String
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            Fg.Redraw = False

            'GCRESET_TAB_VIKINGOS_PAR

            SQL = "SELECT " & N_TOP & " R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, NOMBRE, R.NO_LIQUI, R.CVE_UNI, U.CLAVEMONTE,
                ISNULL(STUFF((SELECT ', ' + cast(NUM_VIAJE as varchar(10)) FROM GCRESET_TAB_VIKINGOS_PAR S WHERE S.CVE_RES = R.CVE_RES FOR XML PATH ('')),1,1, ''),'') AS VIAJES, 
                M.DESCR As NOMBREMOTOR, R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, CAL_GLO_EVA, BONO_RES, R.ODOMETRO, KM_ECM,
                LTS_ECM, LTS_REAL, LTS_AUTORIZADOS, LTS_DESCONTAR, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI,
                LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI, PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL,
                REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB, R.FECHAELAB, R.UUID,
                ISNULL((SELECT MIN(FECHA_IDA) FROM GCRESET_TAB_VIKINGOS_PAR WHERE CVE_RES = R.CVE_RES),'') AS F_IDA_INI,
                ISNULL((SELECT MAX(FECHA_IDA) FROM GCRESET_TAB_VIKINGOS_PAR WHERE CVE_RES = R.CVE_RES),'') AS F_IDA_FIN,
                PORC_TOL_EVENTO2, LTS_AUTORIZADOS2, LTS_VALES2, LTS_DESCONTAR2, PRECIO_X_LTS2, DESCXLITROS2, 
                LTS_SALIDA, LTS_VALES, LTS_FORANEOS, LTS_LLEGADA, EVENTO, CASE WHEN EVENTO_LTS = 0 THEN 'Lts. ECM' ELSE 'Lts. TAB' END AS LTS_ECM_TAB
                FROM GCRESETEO R 
                Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
                Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
                LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT " &
                CADENA
            '█████████████████████████████████████████████████████████████████████████████████████████████████████████
            'VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read

                'TLTS_SALIDA.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_SALIDA"), "###,###,##0.0")
                'TLTS_LLEGADA.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_LLEGADA"), "###,###,##0.0")
                'TLTS_FORANEOS.Value = dr.ReadNullAsEmptyDecimal("LTS_FORANEOS")
                LRC1 = dr.ReadNullAsEmptyDecimal("LTS_SALIDA")
                LRC2 = dr.ReadNullAsEmptyDecimal("LTS_VALES")
                LRC3 = dr.ReadNullAsEmptyDecimal("LTS_FORANEOS")
                LRC4 = dr.ReadNullAsEmptyDecimal("LTS_LLEGADA")

                LTS_REAL = LRC1 + LRC2 + LRC3 - LRC4

                If PASS_GRUPOCE = "BR3FRAJA" Then
                    Try

                        'BACKUPTXT("CALCULOS", dr("CVE_RES") & ", " &
                        '          "LTS_SALIDA = " & dr.ReadNullAsEmptyDecimal("LTS_SALIDA") & ", " &
                        '          "LTS_VALES = " & dr.ReadNullAsEmptyDecimal("LTS_VALES") & ", " &
                        '          "LTS_FORANEOS = " & dr.ReadNullAsEmptyDecimal("LTS_FORANEOS") & ", " &
                        '          "LTS_LEGADA = " & dr.ReadNullAsEmptyDecimal("LTS_LLEGADA") & ", " &
                        '          "LTS_REAL = " & LTS_REAL)

                        SQL = "UPDATE GCRESETEO SET LTS_REAL = " & LTS_REAL & ", LTS_VALES2 = " & LTS_REAL & " WHERE CVE_RES = " & dr("CVE_RES")
                        If EXECUTE_QUERY_NET(SQL) Then
                        End If

                        If dr("CVE_RES") = 440 Then
                            Debug.Print("")
                        End If
                    Catch ex As Exception
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    'LTS_REAL = dr("LTS_REAL")
                End If

                If dr("CVE_RES") = 440 Then
                    Debug.Print("")
                End If

                s = dr("CVE_RES") & vbTab & dr("STATUS") & vbTab & dr("ESTADO") & vbTab & dr("FECHA") & vbTab &
                    dr("NOMBRE") & vbTab & dr("NO_LIQUI") & vbTab &
                    IIf(dr("F_IDA_INI") = "01/01/1900", "", dr("F_IDA_INI")) & vbTab &
                    IIf(dr("F_IDA_FIN") = "01/01/1900", "", dr("F_IDA_FIN")) & vbTab &
                    dr("CLAVEMONTE") & vbTab & dr("VIAJES") & vbTab & dr("NOMBREMOTOR") & vbTab & dr("CAL_FAC_CAR_EVA") & vbTab &
                    dr("CAL_RAL_EVA") & vbTab & dr("CALIF_VEL_MAX") & vbTab & dr("CAL_GLO_EVA") & vbTab & dr("BONO_RES") & vbTab &
                    dr("ODOMETRO") & vbTab & dr("KM_ECM") & vbTab & dr("LTS_ECM") & vbTab & LTS_REAL & vbTab &
                    dr("LTS_AUTORIZADOS") & vbTab & dr("LTS_DESCONTAR") & vbTab & dr("KMS_TAB") & vbTab & dr("LTS_TAB") & vbTab &
                    dr("FAC_CARGA") & vbTab & dr("HRS_TRABAJO") & vbTab & dr("HRS_PTO_RALENTI") & vbTab &
                    dr("LTS_PTO_RALENTI") & vbTab & dr("PORC_TIEMPO_PTO_RALENTI") & vbTab &
                    dr("PORC_LTS_PTO_RALENTI") & vbTab & dr("REND_ECM") & vbTab & dr("PORC_VAR_LTS_ECM_REAL") & vbTab &
                    dr("PORC_VAR_LTS_TAB_REAL") & vbTab & dr("REND_REAL") & vbTab & dr("DIF_LTS_REAL_LTS_ECM") & vbTab &
                    dr("DIF_LTS_REAL_LTS_TAB") & vbTab & dr("PORC_TOL_EVENTO2") & vbTab & dr("LTS_AUTORIZADOS2") & vbTab &
                    dr("LTS_VALES2") & vbTab & dr("LTS_DESCONTAR2") & vbTab & dr("PRECIO_X_LTS2") & vbTab &
                    dr("DESCXLITROS2") & vbTab & (dr("EVENTO") + 1) & vbTab & dr("LTS_ECM_TAB")

                Fg.AddItem("" & vbTab & s)
                'BACKUPTXT("RESET", s)
            Loop
            dr.Close()
            'VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     VIKINGOS     
            Try
                If NRow > 0 Then
                    Fg.Row = NRow
                End If
            Catch ex As Exception
            End Try

            TITULOS_VIKINGOS()

            If PASS_GRUPOCE = "BUS" Then
                Fg.Cols.Fixed = 4
            End If

            Fg.AutoSizeCols()

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub BarRecalculoEvento2LtsTab_Click(sender As Object, e As EventArgs) Handles BarRecalculoEvento2.Click

        Try
            Var27 = TIPO_TAB

            Dim f As New FrmRecalEve2 With {.MdiParent = MainRibbonForm.Owner}
            f.ShowDialog()

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
End Class
