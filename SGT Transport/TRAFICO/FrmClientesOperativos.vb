Imports System.Data.SqlClient
Public Class FrmClientesOperativos
    Private BindingSource1 As New BindingSource
    Private CADENA As String
    Private FormMaxMin As String = ""
    Private TipoRemDest As String = ""
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub CARGA1()
        Try
            Tab1.Dock = DockStyle.Fill

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(BarEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")

            FormMaxMin = Var17
            TipoRemDest = Var8
            If FormMaxMin = "" Then
                With Screen.PrimaryScreen.WorkingArea
                    Me.SetBounds(.Left, .Top, .Width, .Height)
                End With
                Me.WindowState = FormWindowState.Maximized

                If TipoRemDest = "D" Then
                    Pag1.Visible = False
                Else
                    Pag2.Visible = False
                End If
            Else
                Me.FormBorderStyle = FormBorderStyle.FixedSingle
                Me.WindowState = FormWindowState.Normal
                Me.CenterToScreen()

            End If

            Fg.Rows.Count = 1
            Fg.Cols.Count = 10
            Fg.Rows(0).Height = 40
            Fg.Styles.Normal.WordWrap = True

            Fg2.Rows.Count = 1
            Fg2.Cols.Count = 10
            Fg2.Rows(0).Height = 40
            Fg2.Styles.Normal.WordWrap = True

            Tab1.Dock = DockStyle.Fill
            TAB2.Dock = DockStyle.Fill
            TAB3.Dock = DockStyle.Fill

            Fg.Dock = DockStyle.Fill
            Fg2.Dock = DockStyle.Fill
            FgR2.Dock = DockStyle.Fill
            FgD2.Dock = DockStyle.Fill


            CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'R'"

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmClientesOperativos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        CARGA1()
    End Sub
    Sub DESPLEGAR()
        Try

            Fg.Redraw = False
            Fg.BeginUpdate()

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT C.CLAVE AS 'Clave', CASE WHEN C.STATUS = 'A' THEN 'Activo' ELSE 'Cancelado' END AS 'Estatus', C.NOMBRE AS 'Nombre', 
                C.DOMICILIO AS 'Domicilio', C.DOMICILIO2 AS 'Domicilio2', C.PLANTA AS 'Planta', C.RFC AS 'R.F.C.', 
                C.POBLACION AS 'Localidad', C.POBLACION_SAT AS 'Clave SAT localidad', C.MUNICIPIO AS 'Municipio', C.MUNICIPIO_SAT AS 'Clave SAT municipio', 
                C.NOMBRE AS 'Estado', C.ESTADO_SAT AS 'Clave SAT estado', C.PAIS AS 'País', C.PAIS_SAT AS 'Clave SAT país', 
                C.NOTA AS 'Nota', CveRegistroISTMO AS 'Registro ISTMO SAT' 
                FROM GCCLIE_OP C
                WHERE " & CADENA & "
                ORDER BY TRY_PARSE(C.CLAVE AS INT) DESC"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt

            Fg.Redraw = False

            If Tab1.SelectedIndex = 0 Then

                If TAB2.SelectedIndex = 0 Then
                    Fg.DataSource = BindingSource1.DataSource

                    Fg.Cols(3).Width = 200
                    Fg.Cols(4).Width = 200
                    Fg.Cols(5).Width = 250
                    Fg.Cols(6).Width = 250
                    Fg.Cols(9).Width = 200
                    Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
                    Fg.AutoSizeRows()
                    Fg.Redraw = True
                    'RestauraSearchFG(Fg)
                Else
                    FgR2.DataSource = BindingSource1.DataSource

                    FgR2.Cols(3).Width = 200
                    FgR2.Cols(4).Width = 200
                    FgR2.Cols(5).Width = 250
                    FgR2.Cols(6).Width = 250
                    FgR2.Cols(9).Width = 200
                    Lt1.Text = "Registros encontrados " & FgR2.Rows.Count - 1
                    FgR2.AutoSizeRows()
                    FgR2.Redraw = True
                End If

            Else
                If TAB3.SelectedIndex = 0 Then
                    Fg2.DataSource = BindingSource1.DataSource

                    Fg2.Cols(3).Width = 200
                    Fg2.Cols(4).Width = 200
                    Fg2.Cols(5).Width = 250
                    Fg2.Cols(6).Width = 250
                    Fg2.Cols(7).Width = 200
                    Lt1.Text = "Registros encontrados " & Fg2.Rows.Count - 1
                    Fg2.AutoSizeRows()
                    Fg2.Redraw = True
                Else
                    FgD2.DataSource = BindingSource1.DataSource

                    FgD2.Cols(3).Width = 200
                    FgD2.Cols(4).Width = 200
                    FgD2.Cols(5).Width = 250
                    FgD2.Cols(6).Width = 250
                    FgD2.Cols(9).Width = 200
                    Lt1.Text = "Registros encontrados " & FgD2.Rows.Count - 1
                    FgD2.AutoSizeRows()
                    FgD2.Redraw = True
                End If

            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Fg.EndUpdate()

    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"

            If Tab1.SelectedIndex = 0 Then
                Var8 = "R"
            Else
                Var8 = "D"
            End If

            FrmClientesOperativosAE.ShowDialog()

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            If Tab1.SelectedIndex = 0 Then
                Var8 = "R"
                CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'R'"

                Var2 = Fg(Fg.Row, 1)
            Else
                Var8 = "D"
                CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'D'"

                Var2 = Fg2(Fg2.Row, 1)
            End If


            FrmClientesOperativosAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                If Tab1.SelectedIndex = 0 Then
                    SQL = "UPDATE GCCLIE_OP SET STATUS = 'B' WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"
                Else
                    SQL = "UPDATE GCCLIE_OP SET STATUS = 'B' WHERE CLAVE = '" & Fg2(Fg2.Row, 1) & "'"
                End If

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
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmClientesOperativos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmClientesOperativos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If FormMaxMin = "" Then
            CloseTab("Clientes Operativos")
        End If
        Me.Dispose()
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        If Tab1.SelectedIndex = 0 Then
            Var8 = "R"
            CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'R'"
        Else
            Var8 = "D"
            CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'D'"
        End If

        DESPLEGAR()
    End Sub

    Private Sub BarClientesOP_Click(sender As Object, e As EventArgs)

        If Tab1.SelectedIndex = 0 Then
            Var8 = "R"
            CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'R'"
        Else
            Var8 = "D"
            CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'D'"
        End If
        DESPLEGAR()

    End Sub

    Private Sub Tab1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedIndexChanged
        If Tab1.SelectedIndex = 0 Then

            C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)
            CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'R'"
        Else
            C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg2, C1FlexGridSearchPanel1)
            TAB3.SelectedIndex = 0
            CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'D'"
        End If

        DESPLEGAR()
    End Sub

    Private Sub TAB2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TAB2.SelectedIndexChanged
        If TAB2.SelectedIndex = 0 Then
            CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'R'"

        Else
            CADENA = "C.STATUS = 'B' AND C.CLAVE <> '0' AND RD = 'R'"
        End If

        DESPLEGAR()
    End Sub

    Private Sub TAB3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TAB3.SelectedIndexChanged
        If TAB3.SelectedIndex = 0 Then
            CADENA = "C.STATUS = 'A' AND C.CLAVE <> '0' AND RD = 'D'"
        Else
            CADENA = "C.STATUS = 'B' AND C.CLAVE <> '0' AND RD = 'D'"
        End If

        DESPLEGAR()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If FormMaxMin = "M" Then
                Var4 = Fg(Fg.Row, 1)
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg2_DoubleClick(sender As Object, e As EventArgs) Handles Fg2.DoubleClick
        Try
            If FormMaxMin = "M" Then
                Var4 = Fg2(Fg2.Row, 1)
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
