Imports C1.Win.C1Themes
Imports CSJ2K.j2k.io
Imports System.Data.SqlClient
Public Class FrmUnidades
    Private BindingSource1 As New BindingSource

    Private CADENA As String
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmUnidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_DATOS1()

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        If Not EXISTE_STORE_PROCEDURE("dbo.OB_UNIDADES") Then
            SQL = "CREATE PROCEDURE dbo.OB_UNIDADES
       AS 
       BEGIN
            SET NOCOUNT ON;   
            SELECT U.CLAVE AS 'Clave', CLAVEMONTE AS 'Num. económico', ISNULL(U.STATUS,'A') as 'Estatus', U.DESCR AS 'Descripción', 
                PLACAS_MEX AS 'Placas', T.DESCR AS 'Tipo unidad', M.DESCR AS 'Marca', D.DESCR AS 'Modelo', NUM_SERIE_UNI AS 'Num. serie unidad',
                ISNULL(L1.NUM_ECONOMICO,'') AS 'Posicion 1', ISNULL(L2.NUM_ECONOMICO,'') AS 'Posicion 2', ISNULL(L3.NUM_ECONOMICO,'') AS 'Posicion 3', 
                ISNULL(L4.NUM_ECONOMICO,'') AS 'Posicion 4', ISNULL(L5.NUM_ECONOMICO,'') AS 'Posicion 5', ISNULL(L6.NUM_ECONOMICO,'') AS 'Posicion 6', 
                ISNULL(L7.NUM_ECONOMICO,'') AS 'Posicion 7', ISNULL(L8.NUM_ECONOMICO,'') AS 'Posicion 8', ISNULL(L9.NUM_ECONOMICO,'') AS 'Posicion 9', 
                ISNULL(L10.NUM_ECONOMICO,'') AS 'Posicion 10', ISNULL(L11.NUM_ECONOMICO,'') AS 'Posicion 11', ISNULL(L12.NUM_ECONOMICO,'') AS 'Posicion 12',
                MC.DESCR AS 'Motivo cancelación'
                FROM GCUNIDADES U
                LEFT JOIN GCOPERADOR O ON O.CLAVE = U.CVE_OPER
                LEFT JOIN GCMOTIVO_CANC MC ON MC.CVE_MTC = U.CVE_MTC
                LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI
                LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA
                LEFT JOIN GCMODELO_UNIDAD D ON D.CVE_MOD = U.CVE_MODELO
                LEFT JOIN GCLLANTAS L1 ON L1.CVE_LLANTA = U.CHLL1
                LEFT JOIN GCLLANTAS L2 ON L2.CVE_LLANTA = U.CHLL2
                LEFT JOIN GCLLANTAS L3 ON L3.CVE_LLANTA = U.CHLL3
                LEFT JOIN GCLLANTAS L4 ON L4.CVE_LLANTA = U.CHLL4
                LEFT JOIN GCLLANTAS L5 ON L5.CVE_LLANTA = U.CHLL5
                LEFT JOIN GCLLANTAS L6 ON L6.CVE_LLANTA = U.CHLL6
                LEFT JOIN GCLLANTAS L7 ON L7.CVE_LLANTA = U.CHLL7
                LEFT JOIN GCLLANTAS L8 ON L8.CVE_LLANTA = U.CHLL8
                LEFT JOIN GCLLANTAS L9 ON L9.CVE_LLANTA = U.CHLL9
                LEFT JOIN GCLLANTAS L10 ON L10.CVE_LLANTA = U.CHLL10
                LEFT JOIN GCLLANTAS L11 ON L11.CVE_LLANTA = U.CHLL11
                LEFT JOIN GCLLANTAS L12 ON L12.CVE_LLANTA = U.CHLL12 
                ORDER BY TRY_PARSE(U.CLAVE AS INT)
       END"
            EXECUTE_QUERY_NET(SQL)
        End If

        Me.WindowState = FormWindowState.Maximized
        C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
        C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
        C1SuperTooltip1.SetToolTip(BarEliminar, "F4 - Eliminar")
        C1SuperTooltip1.SetToolTip(BarraMenu, "F5 - Salir")

        Fg.Rows(0).Height = 40
        Fg.Dock = DockStyle.Fill

        CADENA = "ISNULL(U.STATUS, 'A') = 'A'"

        DESPLEGAR()

    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Fg.Redraw = False
        Fg.BeginUpdate()

        Try
            'SQL = "SELECT U.CLAVE AS 'Clave', CLAVEMONTE AS 'Num. económico', ISNULL(U.STATUS,'A') as 'Estatus', (CASE WHEN RENTADO = 1 THEN 'SI' ELSE '' END) 'Rentado',
            '   (CASE WHEN UNIDAD_PERMISI = 1 THEN 'SI' ELSE '' END) AS 'Unidad/Permisionario', U.DESCR AS 'Descripción', 
            'PLACAS_MEX AS 'Placas', T.DESCR AS 'Tipo unidad',
            'CVE_SUC AS 'Sucursal', NOMBRE AS 'NombreOperador', M.DESCR AS 'Marca', 
            'd.DESCR AS 'Modelo', NUM_SERIE_UNI AS 'Num. serie unidad',
            'ISNULL(L1.NUM_ECONOMICO,'') AS 'Posicion 1', ISNULL(L2.NUM_ECONOMICO,'') AS 'Posicion 2', ISNULL(L3.NUM_ECONOMICO,'') AS 'Posicion 3', 
            'ISNULL(L4.NUM_ECONOMICO,'') AS 'Posicion 4', ISNULL(L5.NUM_ECONOMICO,'') AS 'Posicion 5', ISNULL(L6.NUM_ECONOMICO,'') AS 'Posicion 6', 
            'ISNULL(L7.NUM_ECONOMICO,'') AS 'Posicion 7', ISNULL(L8.NUM_ECONOMICO,'') AS 'Posicion 8', ISNULL(L9.NUM_ECONOMICO,'') AS 'Posicion 9', 
            'ISNULL(L10.NUM_ECONOMICO,'') AS 'Posicion 10', ISNULL(L11.NUM_ECONOMICO,'') AS 'Posicion 11', ISNULL(L12.NUM_ECONOMICO,'') AS 'Posicion 12',
            'MC.DESCR AS 'Motivo cancelación'

            SQL = "SELECT U.CLAVE AS 'Clave', CLAVEMONTE AS 'Num. económico', ISNULL(U.STATUS,'A') as 'Estatus', U.DESCR AS 'Descripción', 
                PLACAS_MEX AS 'Placas', T.DESCR AS 'Tipo unidad', M.DESCR AS 'Marca', D.DESCR AS 'Modelo', NUM_SERIE_UNI AS 'Num. serie unidad',
                ISNULL(L1.NUM_ECONOMICO,'') AS 'Posicion 1', ISNULL(L2.NUM_ECONOMICO,'') AS 'Posicion 2', ISNULL(L3.NUM_ECONOMICO,'') AS 'Posicion 3', 
                ISNULL(L4.NUM_ECONOMICO,'') AS 'Posicion 4', ISNULL(L5.NUM_ECONOMICO,'') AS 'Posicion 5', ISNULL(L6.NUM_ECONOMICO,'') AS 'Posicion 6', 
                ISNULL(L7.NUM_ECONOMICO,'') AS 'Posicion 7', ISNULL(L8.NUM_ECONOMICO,'') AS 'Posicion 8', ISNULL(L9.NUM_ECONOMICO,'') AS 'Posicion 9', 
                ISNULL(L10.NUM_ECONOMICO,'') AS 'Posicion 10', ISNULL(L11.NUM_ECONOMICO,'') AS 'Posicion 11', ISNULL(L12.NUM_ECONOMICO,'') AS 'Posicion 12',
                MC.DESCR AS 'Motivo cancelación'
                FROM GCUNIDADES U
                LEFT JOIN GCOPERADOR O ON O.CLAVE = U.CVE_OPER
                LEFT JOIN GCMOTIVO_CANC MC ON MC.CVE_MTC = U.CVE_MTC
                LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI
                LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA
                LEFT JOIN GCMODELO_UNIDAD D ON D.CVE_MOD = U.CVE_MODELO
                LEFT JOIN GCLLANTAS L1 ON L1.CVE_LLANTA = U.CHLL1
                LEFT JOIN GCLLANTAS L2 ON L2.CVE_LLANTA = U.CHLL2
                LEFT JOIN GCLLANTAS L3 ON L3.CVE_LLANTA = U.CHLL3
                LEFT JOIN GCLLANTAS L4 ON L4.CVE_LLANTA = U.CHLL4
                LEFT JOIN GCLLANTAS L5 ON L5.CVE_LLANTA = U.CHLL5
                LEFT JOIN GCLLANTAS L6 ON L6.CVE_LLANTA = U.CHLL6
                LEFT JOIN GCLLANTAS L7 ON L7.CVE_LLANTA = U.CHLL7
                LEFT JOIN GCLLANTAS L8 ON L8.CVE_LLANTA = U.CHLL8
                LEFT JOIN GCLLANTAS L9 ON L9.CVE_LLANTA = U.CHLL9
                LEFT JOIN GCLLANTAS L10 ON L10.CVE_LLANTA = U.CHLL10
                LEFT JOIN GCLLANTAS L11 ON L11.CVE_LLANTA = U.CHLL11
                LEFT JOIN GCLLANTAS L12 ON L12.CVE_LLANTA = U.CHLL12 
                WHERE " & CADENA & " ORDER BY TRY_PARSE(U.CLAVE AS INT)"
            'bs.DataSource = dt
            'bs.SuspendBinding()
            'bs.RaiseListChangedEvents = false 
            'bs.Filter = "1=0" 
            'dt.BeginLoadData() 
            ' some modification on data table
            'dt.EndLoadData()
            'bs.RaiseListChangedEvents = True
            'bs.Filter = ""


            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 180
            da.Fill(dt)
            BindingSource1.RaiseListChangedEvents = False
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource




            If CADENA = "ISNULL(U.STATUS, 'A') = 'A'" Then
                'Fg.Cols(25).Visible = False
            Else
                'Fg.Cols(25).Visible = True
            End If

            CADENA = "ISNULL(U.STATUS, 'A') = 'A'"

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Fg.EndUpdate()

    End Sub
    Private Sub FrmUnidades_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Unidades")
        Me.Dispose()
    End Sub
    Private Sub FrmUnidades_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    BarNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    BarEliminar_Click(Nothing, Nothing)
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
    Private Sub FrmUnidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try

            Var1 = "Nuevo"
            Var3 = ""

            CREA_TAB(frmUnidadesAE, "Movimientos Unidades")
            'frmUnidadesAE.ShowDialog()
            'DESPLEGAR()
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then
                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 1)

                Var3 = Fg(Fg.Row, 3)

                CREA_TAB(frmUnidadesAE, "Movimientos Unidades")

            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar la unidad?", vbYesNo) = vbYes Then

                Var4 = ""
                FrmMotivoBaja.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    Dim CVE_MTC As Long = 0
                    Try
                        CVE_MTC = GRABA_MOTIVO_CANC("UNIDADES", Var4)
                    Catch ex As Exception
                        Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                    SQL = "UPDATE GCUNIDADES SET STATUS = 'B', CVE_MTC = " & CVE_MTC & " WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"

                    Dim cmd As New SqlCommand With {.Connection = cnSAE, .CommandText = SQL}

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
                Else
                    Dim ResultMensaje As String
                    ResultMensaje = MensajeBox("Cancelación no realizada", "Proceso finalizado", "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()

    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick

        BarEdit_Click(Nothing, Nothing)

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "UNIDADES")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarUnidadesEliminadas_Click(sender As Object, e As EventArgs) Handles BarUnidadesEliminadas.Click

        BarEliminar.Visible = False

        CADENA = "ISNULL(U.STATUS, 'A') = 'B'"

        DESPLEGAR()

    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click

        BarEliminar.Visible = True
        CADENA = "ISNULL(U.STATUS, 'A') = 'A'"
        DESPLEGAR()

    End Sub
End Class
