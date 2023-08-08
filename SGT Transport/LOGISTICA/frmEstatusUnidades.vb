Imports System.Data.SqlClient
Imports System.ServiceModel
Imports System.Web.UI.WebControls
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports Stimulsoft.Report.Design.ContextTools

Public Class FrmEstatusUnidades
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub FrmEstatusUnidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        BarMenu.BackColor = Color.FromArgb(207, 221, 238)

        BarMenu.ForeColor = Color.White


    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Me.WindowState = FormWindowState.Maximized
        Fg.Rows.Count = 1
        'Fg.Cols.Count = 11

        Fg.Rows(0).Height = 40
        Fg.Dock = DockStyle.Fill
        Fg.DrawMode = DrawModeEnum.OwnerDraw

        'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        'Fg.Height = Me.Height - 100

        DESPLEGAR()
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            SQL = "SELECT U.CLAVEMONTE AS 'Clave', U.CVE_TIPO_UNI AS 'Tipo', T.DESCR AS 'Tipo de unidad', 
                (SELECT TOP 1 FECHA FROM GCASIGNACION_VIAJE A6 WHERE A6.CVE_TRACTOR = U.CLAVEMONTE OR A6.CVE_TANQUE1 = U.CLAVEMONTE OR A6.CVE_TANQUE2 = U.CLAVEMONTE OR A6.CVE_DOLLY = U.CLAVEMONTE ORDER BY FECHA DESC) As 'Fecha ult. viaje', 
                SQ.DES_ST_UNI AS 'Estatus Unidad', 
                (SELECT TOP 1 SV.DESCR FROM GCASIGNACION_VIAJE A5 LEFT JOIN GCCAT_STATUS_VIAJE SV ON SV.CLAVE = A5.CVE_ST_VIA WHERE A5.CVE_TRACTOR = U.CLAVEMONTE OR A5.CVE_TANQUE1 = U.CLAVEMONTE OR A5.CVE_TANQUE2 = U.CLAVEMONTE OR A5.CVE_DOLLY = U.CLAVEMONTE ORDER BY FECHAELAB desc) AS 'Estatus Viaje',
                ISNULL(OBS,'') AS 'Observaciones', ISNULL(SQ.DES_PROD,'') AS 'Producto asignado', SQ.FECHA_ST_UNI AS 'Ult. fecha estatus', SQ.KIT as 'Kit',
                SQ.NOMBRE_OPER AS 'Nombre operador', SQ.NOMBRE_OPER_TMP as 'Nombre operador postura', SQ.STATUS_OPER AS 'Estatus operador',"

            SQL += "(SELECT TOP 1 P1.CIUDAD FROM GCASIGNACION_VIAJE A7 
                    LEFT JOIN GCCLIE_OP OP ON OP.CLAVE = A7.CLAVE_D 
                    LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = OP.CVE_PLAZA 
                    WHERE A7.CVE_TRACTOR = U.CLAVEMONTE OR A7.CVE_TANQUE1 = U.CLAVEMONTE OR A7.CVE_TANQUE2 = U.CLAVEMONTE OR A7.CVE_DOLLY = U.CLAVEMONTE 
                    ORDER BY FECHA DESC) As 'Ult. destino tractor',"

            SQL += "(SELECT TOP 1 PROD.DESCR FROM GCASIGNACION_VIAJE A8 
                    LEFT JOIN GCPEDIDOS PE ON PE.CVE_DOC = A8.CVE_DOC 
                    LEFT JOIN GCPRODUCTOS PROD ON PROD.CVE_PROD = PE.CVE_ART
                    WHERE A8.CVE_TRACTOR = U.CLAVEMONTE OR A8.CVE_TANQUE1 = U.CLAVEMONTE OR A8.CVE_TANQUE2 = U.CLAVEMONTE OR A8.CVE_DOLLY = U.CLAVEMONTE 
                    ORDER BY A8.FECHA DESC) As 'Ult. producto cargado' "

            SQL += "FROM GCUNIDADES U
                LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI 
                OUTER APPLY  (SELECT TOP 1 SU.DESCR AS DES_ST_UNI, FECHA_ST_UNI, D.DESCR AS DES_PROD, KIT, 
                    CVE_OPER, O1.NOMBRE AS NOMBRE_OPER, CVE_OPER_ST, CVE_OPER_POSTURA, O2.NOMBRE AS NOMBRE_OPER_TMP, CVE_OPER_POSTURA_ST,
                    STO.DESCR AS STATUS_OPER
				    FROM GCSTATUS_UNIDADES P2 
                    LEFT JOIN GCOPERADOR O1 ON O1.CLAVE = P2.CVE_OPER
                    LEFT JOIN GCOPERADOR O2 ON O2.CLAVE = P2.CVE_OPER_POSTURA
                    LEFT JOIN GCSTATUS_OPER STO ON STO.CVE_ST_OPER = P2.CVE_OPER_ST
                    LEFT JOIN GCPRODUCTOS D ON D.CVE_PROD = P2.CVE_PROD
                    LEFT JOIN GCCAT_STATUS_UNIDADES SU ON SU.CLAVE = P2.CVE_ST_UNI 
				    WHERE CVE_UNI = U.CLAVEMONTE AND P2.STATUS =  'A' ) AS SQ
                WHERE U.STATUS = 'A'  AND (U.CVE_TIPO_UNI = 1 OR U.CVE_TIPO_UNI = 2 OR U.CVE_TIPO_UNI = 3)
                ORDER BY ISNULL(SQ.KIT,99999), U.CVE_TIPO_UNI"

            'ORDER BY ISNULL(SU.ORDEN,9999)"
            Fg.Redraw = False
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource
            Fg.AutoSizeCols()

            Fg.Redraw = True
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmEstatusUnidades_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Estatus Unidades")
        Me.Dispose()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarArmarKits_Click(sender As Object, e As EventArgs) Handles BarArmarKits.Click
        Try
            Dim KIT As Long, z As Integer = 0, nTractor As Integer = 0, nTanque As Integer = 0, nDolly As Integer = 0, KitArmado As Integer

            For Each r As Row In Fg.Rows.Selected
                z += 1
                Try
                    '1 TRACTOR, 2 TANQUE, 3 DOLLY
                    If Fg(r.Index, 2) = "1" Then nTractor += 1
                    If Fg(r.Index, 2) = "2" Then nTanque += 1
                    If Fg(r.Index, 2) = "3" Then nDolly += 1

                    If Not IsDBNull(Fg(r.Index, 11)) AndAlso Not IsNothing(Fg(r.Index, 11)) Then
                        If Fg(r.Index, 11) > 0 Then
                            KitArmado += 1
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next

            If KitArmado > 0 Then
                MsgBox("kit armando por favor primero desasigne el kit")
                Return
            End If
            If z <= 1 Then
                MsgBox("Por favor seleccione un kit completo")
                Return
            End If
            If nTractor = 0 Then
                MsgBox("Por favor seleccione un tractor para poder armar el kit")
                Return
            End If
            If nTractor > 1 Then
                MsgBox("Por favor seleccione solo un tractor para poder armar el kit")
                Return
            End If
            If nTanque = 0 Then
                MsgBox("Por favor seleccione 1 ó 2 tanques para poder armar el kit")
                Return
            End If
            If nTanque > 2 Then
                MsgBox("Por favor seleccione un máximo de 2 tanques para poder armar el kit")
                Return
            End If
            KIT = GET_MAX("GCSTATUS_UNIDADES", "KIT")

            For Each r As Row In Fg.Rows.Selected


                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "IF EXISTS (SELECT CVE_UNI FROM GCSTATUS_UNIDADES WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A')
                              UPDATE GCSTATUS_UNIDADES SET KIT = @KIT WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A'
                           ELSE
                              INSERT INTO GCSTATUS_UNIDADES (CVE_UNI, STATUS, KIT, FECHAELAB, UUID) VALUES(@CVE_UNI, 'A', @KIT, GETDATE(), NEWID())"
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = Fg(r.Index, 1)
                        cmd.Parameters.Add("@KIT", SqlDbType.Int).Value = KIT
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                End Using
            Next

            MsgBox("El registro se grabo satisfactoriamente")

            DESPLEGAR()

        Catch ex As Exception
            Bitacora("52. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("52. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDesasignarKits_Click(sender As Object, e As EventArgs) Handles BarDesasignarKits.Click
        Try
            For Each r As Row In Fg.Rows.Selected

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    Try
                        'SQL = "UPDATE GCSTATUS_UNIDADES SET KIT = NULL WHERE CVE_UNI = '" & Fg(r.Index, 1) & "' And STATUS = 'A'"

                        'SQL = "UPDATE GCSTATUS_UNIDADES SET STATUS = 'D' WHERE CVE_UNI = '" & Fg(r.Index, 1) & "' And STATUS = 'A'"
                        SQL = "DELETE FROM GCSTATUS_UNIDADES WHERE CVE_UNI = '" & Fg(r.Index, 1) & "'"
                        cmd.CommandText = SQL

                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                End Using
            Next

            MsgBox("El registro se grabo satisfactoriamente")

            DESPLEGAR()

        Catch ex As Exception
            Bitacora("72. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("72. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarStatusUnidad_Click(sender As Object, e As EventArgs) Handles BarStatusUnidad.Click
        Try
            If Fg.Row > 0 Then
                Var6 = ""
                Var7 = ""
                Var8 = "UNIDAD"
                'Var9 = Fg(Fg.Row, 3).ToString 'VIAJE
                'Var19 = Fg(Fg.Row, 1).ToString 'UNIDAD

                FrmStatusViajeUnidad.ShowDialog()

                If Var26 > 0 Then
                    'Var26 = CVE_ST_UNI
                    'Var27 = CVE_ST_VIA
                    For Each r As Row In Fg.Rows.Selected

                        Console.WriteLine(r.Index.ToString())

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "IF EXISTS (SELECT CVE_UNI FROM GCSTATUS_UNIDADES WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A')
                                UPDATE GCSTATUS_UNIDADES SET CVE_ST_UNI = @CVE_ST_UNI, FECHA_ST_UNI = CONVERT(varchar, GETDATE(), 112) 
                                WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A'
                           ELSE
                                INSERT INTO GCSTATUS_UNIDADES (CVE_UNI, STATUS, KIT, CVE_ST_UNI, FECHA_ST_UNI, FECHAELAB, UUID) VALUES(@CVE_UNI, 'A', 0, 
                                @CVE_ST_UNI, CONVERT(varchar, GETDATE(), 112), GETDATE(), NEWID())"

                            cmd.CommandText = SQL
                            Try
                                cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = Fg(r.Index, 1)
                                cmd.Parameters.Add("@CVE_ST_UNI", SqlDbType.Int).Value = Var26
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            Catch ex As Exception
                                MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
                                Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                        End Using
                    Next

                    MsgBox("El registro se grabo satisfactoriamente")

                    DESPLEGAR()

                End If
            End If
        Catch ex As Exception
            Bitacora("92. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("92. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub

    Private Sub BarProducto_Click(sender As Object, e As EventArgs) Handles BarProducto.Click
        Try
            Dim CVE_PROD As Integer

            Var2 = "Productos"
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 And IsNumeric(Var4) Then

                For Each r As Row In Fg.Rows.Selected
                    'Console.WriteLine(r.Index.ToString())
                    CVE_PROD = Convert.ToInt16(Var4)

                    If Fg(r.Index, 2) = 2 Then

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "IF EXISTS (SELECT CVE_UNI FROM GCSTATUS_UNIDADES WHERE CVE_UNI = @CVE_UNI AND STATUS = 'A')
                                      UPDATE GCSTATUS_UNIDADES SET CVE_PROD = @CVE_PROD WHERE CVE_UNI = @CVE_UNI AND STATUS = 'A'
                                   ELSE
                                      INSERT INTO GCSTATUS_UNIDADES (CVE_UNI, CVE_PROD, STATUS, FECHAELAB, UUID) VALUES(@CVE_UNI, @CVE_PROD, 'A', GETDATE(), NEWID())"

                            cmd.CommandText = SQL
                            Try
                                cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = Fg(r.Index, 1)
                                cmd.Parameters.Add("@CVE_PROD", SqlDbType.Int).Value = CVE_PROD
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            Catch ex As Exception
                                MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                        End Using

                    End If
                Next

                MsgBox("El registro se grabo satisfactoriamente")

                DESPLEGAR()

            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarObser_Click(sender As Object, e As EventArgs) Handles BarObser.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 7)
                TIPO_COMPRA = "o"
                frmObserDocumento.ShowDialog()
                If Var4.Trim.Length > 0 Then

                    Fg(Fg.Row, 7) = Var4

                    SQL = "UPDATE GCUNIDADES SET OBS = '" & Var4 & "' WHERE CLAVEMONTE = '" & Fg(Fg.Row, 1) & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                DESPLEGAR()
                            End If
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Try
            If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            'Select Case Fg(Fg.Row, 2)
            'Case 1
            'BarProducto.Enabled = True
            'Case Else
            'BarProducto.Enabled = True
            'End Select

        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarAsigOper_Click(sender As Object, e As EventArgs) Handles BarAsigOper.Click
        Try
            If Fg.Row > 0 Then
                Var26 = 0

                FrmEstatusUnidadesAsigOper.ShowDialog()

                If Var26 > 0 Then
                    'Var26 = 
                    'Var27 = 
                    For Each r As Row In Fg.Rows.Selected

                        Console.WriteLine(r.Index.ToString())

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "IF EXISTS (SELECT CVE_UNI FROM GCSTATUS_UNIDADES WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A')
                                UPDATE GCSTATUS_UNIDADES SET CVE_OPER = @CVE_OPER
                                WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A'
                           ELSE
                                INSERT INTO GCSTATUS_UNIDADES (CVE_UNI, STATUS, KIT, CVE_OPER, FECHAELAB, UUID) VALUES(@CVE_UNI, 'A', 0, @CVE_OPER, GETDATE(), NEWID())"

                            cmd.CommandText = SQL
                            Try
                                cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = Fg(r.Index, 1)
                                cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = Var26
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            Catch ex As Exception
                                MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
                                Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                        End Using
                    Next

                    MsgBox("El registro se grabo satisfactoriamente")

                    DESPLEGAR()

                End If
            End If
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDesAsigOper_Click(sender As Object, e As EventArgs) Handles BarDesAsigOper.Click
        Try
            If Fg.Row > 0 Then

                If MsgBox("Realmente desea desasignar operador postura?", vbYesNo) = vbYes Then

                    For Each r As Row In Fg.Rows.Selected

                        SQL = "UPDATE GCSTATUS_UNIDADES SET CVE_OPER = 0 WHERE CVE_UNI = '" & Fg(r.Index, 1) & "' AND STATUS = 'A'"

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    DESPLEGAR()
                                End If
                            End If
                        End Using
                    Next
                End If
            End If
        Catch ex As Exception
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("270. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarAsigOperPos_Click(sender As Object, e As EventArgs) Handles BarAsigOperPos.Click
        Try
            If Fg.Row > 0 Then
                Var26 = 0

                FrmEstatusUnidadesAsigOper.ShowDialog()

                If Var26 > 0 Then
                    'Var26 = 
                    'Var27 = 
                    For Each r As Row In Fg.Rows.Selected

                        Console.WriteLine(r.Index.ToString())

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "IF EXISTS (SELECT CVE_UNI FROM GCSTATUS_UNIDADES WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A')
                                UPDATE GCSTATUS_UNIDADES SET CVE_OPER_POSTURA = @CVE_OPER
                                WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A'
                           ELSE
                                INSERT INTO GCSTATUS_UNIDADES (CVE_UNI, STATUS, KIT, CVE_OPER_POSTURA, FECHAELAB, UUID) VALUES(@CVE_UNI, 'A', 0, @CVE_OPER, GETDATE(), NEWID())"

                            cmd.CommandText = SQL
                            Try
                                cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = Fg(r.Index, 1)
                                cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = Var26
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            Catch ex As Exception
                                MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
                                Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                        End Using
                    Next

                    MsgBox("El registro se grabo satisfactoriamente")

                    DESPLEGAR()

                End If
            End If
        Catch ex As Exception
            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDesAsigOperPos_Click(sender As Object, e As EventArgs) Handles BarDesAsigOperPos.Click
        Try
            If Fg.Row > 0 Then

                If MsgBox("Realmente desea desasignar operador?", vbYesNo) = vbYes Then

                    For Each r As Row In Fg.Rows.Selected
                        SQL = "UPDATE GCSTATUS_UNIDADES SET CVE_OPER_POSTURA = 0 WHERE CVE_UNI = '" & Fg(r.Index, 1) & "' AND STATUS = 'A'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    DESPLEGAR()
                                End If
                            End If
                        End Using
                    Next
                End If
            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEstatusOper_Click(sender As Object, e As EventArgs) Handles BarEstatusOper.Click
        Try
            If Fg.Row > 0 Then
                Var26 = 0

                FrmEstatusUnidadesStOper.ShowDialog()

                If Var26 > 0 Then
                    For Each r As Row In Fg.Rows.Selected

                        Console.WriteLine(r.Index.ToString())

                        Using cmd As SqlCommand = cnSAE.CreateCommand

                            SQL = "IF EXISTS (SELECT CVE_UNI FROM GCSTATUS_UNIDADES WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A')
                                UPDATE GCSTATUS_UNIDADES SET CVE_OPER_ST = @CVE_OPER_ST
                                WHERE CVE_UNI = @CVE_UNI AND ISNULL(STATUS,'') = 'A'
                           ELSE
                                INSERT INTO GCSTATUS_UNIDADES (CVE_UNI, STATUS, KIT, CVE_OPER_ST, FECHAELAB, UUID) VALUES(@CVE_UNI, 'A', 0, @CVE_OPER_ST, GETDATE(), NEWID())"

                            cmd.CommandText = SQL
                            Try
                                cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = Fg(r.Index, 1)
                                cmd.Parameters.Add("@CVE_OPER_ST", SqlDbType.Int).Value = Var26
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            Catch ex As Exception
                                MsgBox("310. " & ex.Message & vbNewLine & ex.StackTrace)
                                Bitacora("310. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                        End Using
                    Next

                    MsgBox("El registro se grabo satisfactoriamente")

                    DESPLEGAR()

                End If
            End If
        Catch ex As Exception
            Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
