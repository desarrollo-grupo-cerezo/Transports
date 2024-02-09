Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmSelItemCFDI
    Dim Proceso As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmSelItemCFDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If
        Dim nTabla As Boolean = True

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        If PassData = "TOP" Then
            Me.TopMost = True
        End If

        Me.CenterToScreen()

        Proceso = Var2
        Fg.Rows.Count = 1
        Fg.DrawMode = DrawModeEnum.OwnerDraw
        Fg.AllowFreezing = AllowFreezingEnum.Columns
        Fg.Cols.Frozen = 1
        Try
            SQL = ""
            Select Case Proceso
                Case "TipoRelacion"
                    nTabla = False
                Case "tblcclaveunidadpeso"
                    SQL = "SELECT clave, nombre from tblcclaveunidadpeso order by clave"
                Case "tblctipoembalaje"
                    SQL = "SELECT clave, descripcion from tblctipoembalaje order by clave"
                Case "tblcmaterialpeligroso"
                    SQL = "SELECT clave, descripcion from tblcmaterialpeligroso order by clave"
                Case "PermSCT"
                    nTabla = False
                Case "ConfigVehicular"
                    SQL = "SELECT clave, descripcion FROM tblcconfigautotransporte ORDER BY clave"
                Case "SubTipoRem"
                    nTabla = False
                Case "SAT_CLAVEPROD_SERVCP"
                    SQL = "SELECT claveProdServ AS 'Clave producto', descripcion AS 'Descripción' 
                        FROM tblcclaveprodserv ORDER BY claveProdServ"
                Case "tblSectorCOFEPRIS"
                    SQL = "SELECT clave, descripcion FROM tblSectorCOFEPRIS ORDER BY clave"
                Case "tblFormaFarmaceutica"
                    SQL = "SELECT clave, descripcion FROM tblFormaFarmaceutica ORDER BY clave"
                Case "tblCondicionesEspeciales"
                    SQL = "SELECT clave, descripcion FROM tblCondicionesEspeciales ORDER BY clave"
                Case "tblTipoMateria"
                    SQL = "SELECT clave, descripcion FROM tblTipoMateria ORDER BY clave"
            End Select
            If nTabla Then
                If SQL.Trim.Length > 0 Then
                    Dim da As New SqlDataAdapter
                    Dim dt As New DataTable
                    da = New SqlDataAdapter(SQL, cnSAE)
                    dt = New DataTable ' crear un DataTable
                    da.SelectCommand.CommandTimeout = 120
                    da.Fill(dt)

                    BindingSource1.DataSource = dt

                    Fg.Redraw = False

                    Fg.DataSource = BindingSource1.DataSource
                    Select Case Proceso
                        Case "tblcclaveunidadpeso", "tblctipoembalaje", "tblcmaterialpeligroso", "ConfigVehicular", "SAT_CLAVEPROD_SERVCP", "tblSectorCOFEPRIS", "tblFormaFarmaceutica", "tblCondicionesEspeciales", "tblTipoMateria"
                            Fg(0, 0) = ""
                            Fg(0, 1) = "Clave"
                            Fg(0, 2) = "Descripción"
                            Fg.Cols(0).Width = 35
                            Fg.Cols(1).Width = 70
                            Fg.Cols(2).Width = 200
                        Case ""
                    End Select
                    Fg.AutoSizeCols()
                    Fg.Redraw = True
                End If
            Else
                Select Case Proceso
                    Case "TipoRelacion"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Tipo relación"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 100
                        Fg.Cols(2).Width = 250
                        Fg.AddItem("" & vbTab & "01" & vbTab & "Nota de crédito de los documentos relacionados")
                        Fg.AddItem("" & vbTab & "02" & vbTab & "Nota de débito de los documentos relacionados")
                        Fg.AddItem("" & vbTab & "03" & vbTab & "Devolución de mercancía sobre facturas o traslados previos")
                        Fg.AddItem("" & vbTab & "04" & vbTab & "Sustitución de los CFDI previos")
                        Fg.AddItem("" & vbTab & "05" & vbTab & "Traslado de marcancias facturados previamente")
                        Fg.AddItem("" & vbTab & "06" & vbTab & "Factura generada por los traslados previos")
                        Fg.AddItem("" & vbTab & "07" & vbTab & "CFDI por aplicación de anticipo")
                        Fg.AddItem("" & vbTab & "08" & vbTab & "Factura generada por pagos de parcialidades")
                        Fg.AddItem("" & vbTab & "09" & vbTab & "Factura generada por pagos diferidos")
                    Case "PermSCT"
                        'ESTA NO ESTA 
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 200
                        Fg.AddItem("" & vbTab & "TPAF01" & vbTab & "Autotransporte Federal de carga general.")
                        Fg.AddItem("" & vbTab & "TPAF02" & vbTab & "Transporte privado de carga.")
                        Fg.AddItem("" & vbTab & "TPAF03" & vbTab & "Autotransporte Federal de Carga Especializada de materiales y residuos peligrosos.")
                        Fg.AddItem("" & vbTab & "TPXX00" & vbTab & "Permiso no contemplado en al catálogo.")
                    Case "SubTipoRem"
                        Fg.Cols.Count = 3
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 300
                        Fg.AddItem("" & vbTab & "CTR001" & vbTab & "Caballete")
                        Fg.AddItem("" & vbTab & "CTR002" & vbTab & "Caja")
                        Fg.AddItem("" & vbTab & "CTR003" & vbTab & "Caja Abierta")
                        Fg.AddItem("" & vbTab & "CTR004" & vbTab & "Caja Cerrada")
                        Fg.AddItem("" & vbTab & "CTR005" & vbTab & "Caja De Recolección Con Cargador Frontal")
                        Fg.AddItem("" & vbTab & "CTR006" & vbTab & "Caja Refrigerada")
                        Fg.AddItem("" & vbTab & "CTR007" & vbTab & "Caja Seca")
                        Fg.AddItem("" & vbTab & "CTR008" & vbTab & "Caja Transferencia")
                        Fg.AddItem("" & vbTab & "CTR009" & vbTab & "Cama Baja o Cuello Ganso")
                        Fg.AddItem("" & vbTab & "CTR010" & vbTab & "Chasis Portacontenedor")
                        Fg.AddItem("" & vbTab & "CTR011" & vbTab & "Convencional De Chasis")
                        Fg.AddItem("" & vbTab & "CTR012" & vbTab & "Equipo Especial")
                        Fg.AddItem("" & vbTab & "CTR013" & vbTab & "Estacas")
                        Fg.AddItem("" & vbTab & "CTR014" & vbTab & "Góndola Madrina")
                        Fg.AddItem("" & vbTab & "CTR015" & vbTab & "Grúa Industrial")
                        Fg.AddItem("" & vbTab & "CTR016" & vbTab & "Grúa ")
                        Fg.AddItem("" & vbTab & "CTR017" & vbTab & "Integral")
                        Fg.AddItem("" & vbTab & "CTR018" & vbTab & "Jaula")
                        Fg.AddItem("" & vbTab & "CTR019" & vbTab & "Media Redila")
                        Fg.AddItem("" & vbTab & "CTR020" & vbTab & "Pallet o Celdillas")
                        Fg.AddItem("" & vbTab & "CTR021" & vbTab & "Plataforma")
                        Fg.AddItem("" & vbTab & "CTR022" & vbTab & "Plataforma Con Grúa")
                        Fg.AddItem("" & vbTab & "CTR023" & vbTab & "Plataforma Encortinada")
                        Fg.AddItem("" & vbTab & "CTR024" & vbTab & "Redilas")
                        Fg.AddItem("" & vbTab & "CTR025" & vbTab & "Refrigerador")
                        Fg.AddItem("" & vbTab & "CTR026" & vbTab & "Revolvedora")
                        Fg.AddItem("" & vbTab & "CTR027" & vbTab & "Semicaja")
                        Fg.AddItem("" & vbTab & "CTR028" & vbTab & "Tanque")
                        Fg.AddItem("" & vbTab & "CTR029" & vbTab & "Tolva")
                        Fg.AddItem("" & vbTab & "CTR030" & vbTab & "Tractor")
                        Fg.AddItem("" & vbTab & "CTR031" & vbTab & "Volteo")
                        Fg.AddItem("" & vbTab & "CTR032" & vbTab & "Volteo Desmontable")

                End Select
                Fg.AutoSizeCols()
            End If
            SplitPanel1.Text = "Registros encontrados " & Fg.Rows.Count - 1
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub
    Private Sub FrmSelItemCFDI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
    Private Sub tBox_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Down Then
                Fg.Focus()
                Return
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub
    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 1) 'clave
                Var5 = Fg(Fg.Row, 2) 'descripcion
            End If
            Me.Close()
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub
    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Try
                BarAceptar_Click(Nothing, Nothing)
            Catch ex As Exception
                Bitacora(ex.Message & vbNewLine & ex.StackTrace & "Proceso: " & Proceso)
            End Try
        End If
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarAceptar_Click(Nothing, Nothing)

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
    Private Sub Fg_KeyUp(sender As Object, e As KeyEventArgs) Handles Fg.KeyUp
        If e.KeyCode = Keys.Left Then
            C1FlexGridSearchPanel1.Focus()
        End If
    End Sub
End Class
