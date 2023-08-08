Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Imports C1.Win.C1Command
Imports C1.Util.DX

Public Class FrmFacturaGlobalSel
    Private SERIE_FACTURA_GLOBAL As String
    Private SERIE_FACG As String
    Private PERIODICIDAD As String
    Private SERIE_FILTRO As String

    Private Sub FrmFacturaGlobal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()

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

            CboPeriodicidad.Items.Add("")

            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Periodicidad", GetType(System.String))
            dt.Columns.Add("Descripción", GetType(System.String))
            'dt.Columns.Add("BANCO", GetType(System.String))

            CboPeriodicidad.Items.Clear()
            dt.Rows.Add("01", "Diario")
            dt.Rows.Add("02", "Semanal")
            dt.Rows.Add("03", "Quincenal")
            dt.Rows.Add("04", "Mensual")

            CboPeriodicidad.TextDetached = True
            CboPeriodicidad.ItemsDataSource = dt.DefaultView
            CboPeriodicidad.ItemsDisplayMember = "Descripción"
            CboPeriodicidad.ItemsValueMember = "Periodicidad"
            CboPeriodicidad.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboPeriodicidad.HtmlPattern = "<table><tr><td width=30>{Periodicidad}</td><td width=100>{Descripción}</td></td></tr></table>"


            SQL = "SELECT ISNULL(TIP_DOC,'') AS TI_DOC, ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA
                FROM FOLIOSF" & Empresa & "
                WHERE TIP_DOC = 'F' OR TIP_DOC = 'V'"

            CboSerieFiltro.Items.Add("Todos")
            CboSerieFacturaGlobal.Items.Clear()
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If dr("TI_DOC") = "F" Then
                            CboSerieFacturaGlobal.Items.Add(dr("LETRA"))
                        End If
                        If dr("TI_DOC") = "V" Then
                            CboSerieFiltro.Items.Add(dr("LETRA"))
                        End If
                    End While
                End Using
            End Using

            If CboSerieFiltro.Items.Count > 0 Then
                CboSerieFiltro.SelectedIndex = 0
            End If

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT SERIE SERIE FROM GCUSUARIOS_PARAM WHERE USUARIO = '" & USER_GRUPOCE & "' AND TIPO_DOC = 'FG'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        For k = 0 To CboSerieFacturaGlobal.Items.Count - 1
                            If CboSerieFacturaGlobal.Items(k) = dr.ReadNullAsEmptyString("SERIE") Then
                                CboSerieFacturaGlobal.SelectedIndex = k
                                Exit For
                            End If
                        Next
                    End If
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT SERIE_FACTURA_GLOBAL, ISNULL(PERIODICIDAD,-1) AS PERIODICID FROM GCPARAMVENTAS"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CboPeriodicidad.SelectedIndex = dr("PERIODICID")
                        SERIE_FACTURA_GLOBAL = dr.ReadNullAsEmptyString("SERIE_FACTURA_GLOBAL")
                    End If
                End Using
            End Using

            If PASS_GRUPOCE = "BUS" Then
                F1.Value = "24/01/2023"
                F2.Value = "24/01/2023"
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As ClickEventArgs) Handles BarAceptar.Click

        Try
            If CboSerieFacturaGlobal.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione la serie de la factura global")
                Return
            End If

            If CboPeriodicidad.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione la periodicidad")
                Return
            End If
            If CboSerieFiltro.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione la serie del filtro")
                Return
            End If

            Tab1.Focus()

            PERIODICIDAD = CboPeriodicidad.Text
            SERIE_FACG = CboSerieFacturaGlobal.Text
            SERIE_FILTRO = CboSerieFiltro.Text

            Me.DialogResult = DialogResult.OK

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmFacturaGlobal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Public ReadOnly Property MySerieFactutaGlobal As String
        Get
            Return Me.SERIE_FACG
        End Get
    End Property
    Public ReadOnly Property MyPeriodicidad As String
        Get
            Return Me.PERIODICIDAD
        End Get
    End Property
    Public ReadOnly Property MyF1 As String
        Get
            Return Me.F1.Value
        End Get
    End Property
    Public ReadOnly Property MyF2 As String
        Get
            Return Me.F2.Value
        End Get
    End Property
    Public ReadOnly Property MySerieFiltro As String
        Get
            Return Me.SERIE_FILTRO
        End Get
    End Property
    Public ReadOnly Property MyClienteMostrador As Boolean
        Get
            Return Me.RadTodas.Checked
        End Get
    End Property
End Class