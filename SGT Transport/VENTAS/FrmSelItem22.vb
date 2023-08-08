Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmSelItem22
    Dim Proceso As String
    Dim VarCadena As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmSelItem22_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not Valida_Conexion() Then
                Return
            End If

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

            If DialogOK = "Show" Then
                Me.TopMost = True
            End If

            Me.CenterToScreen()

            Proceso = Var2

            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True
            Fg.Rows.Count = 1
            TBox.Text = ""
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            Select Case Proceso
                Case "ClasificProv"
                    SQL = "SELECT CLASIFIC FROM PROV" & Empresa & " WHERE ISNULL(STATUS,'A') = 'A' AND ISNULL(CLASIFIC,'') <> '' ORDER BY CVE_TIPO"
                    Fg.Cols.Count = 3
                    Fg(0, 1) = "Clasificación"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 250
                    Me.Width = 480
                    Fg.Width = Me.Width - 30
                    Me.MaximizeBox = False
                    Me.MinimizeBox = False
                Case "GCTIPO_OPERACION"
                    SQL = "SELECT T.CVE_TIPO, T.DESCR FROM GCTIPO_OPERACION T WHERE ISNULL(STATUS,'A') = 'A' ORDER BY CVE_TIPO"
                    Fg.Cols.Count = 3
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Descripción"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 80
                    Fg.Cols(2).Width = 250
                    Me.Width = 480
                    Fg.Width = Me.Width - 30
                    Me.MaximizeBox = False
                    Me.MinimizeBox = False
                Case "USOCFDI"
                    SQL = "SELECT usoCfdi, descripcion FROM tblcusocfdi ORDER BY descripcion"
                    Fg.Cols.Count = 3
                    Fg(0, 1) = "Uso cfdi"
                    Fg(0, 2) = "Descripción"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 80
                    Fg.Cols(2).Width = 320
                    Me.Width = 480
                    'Me.Height = 200
                    Fg.Width = Me.Width - 30
                    Me.MaximizeBox = False
                    Me.MinimizeBox = False
                Case "MONEDA"
                    SQL = "SELECT moneda, descripcion FROM tblcmoneda ORDER BY moneda"
                    Fg.Cols.Count = 3
                    Fg(0, 1) = "Moneda"
                    Fg(0, 2) = "Descripción"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 80
                    Fg.Cols(2).Width = 320
                    Me.Width = 480
                    'Me.Height = 200
                    Fg.Width = Me.Width - 30
                    Me.MaximizeBox = False
                    Me.MinimizeBox = False
            End Select
            DESPLEGAR()

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Redraw = False
            Fg.Rows.Count = 1

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Select Case Proceso
                            Case "ClasificProv"
                                Fg.AddItem("" & vbTab & dr(0))
                            Case "USOCFDI", "MONEDA"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "GCTIPO_OPERACION"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                        End Select
                    End While
                End Using
            End Using
            Select Case Proceso
                Case "USOCFDI"
                    'Fg.Rows(0).Style = NewStyle1
                    'Fg.AutoSizeCols()
                    Fg.Rows(0).Height = 40
            End Select

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub FrmSelItem22_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If DialogOK = "Show" Then
            Me.TopMost = False
        End If
        Me.Dispose()
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click
        Try
            Select Case Proceso
                Case "ClasificProv"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1)
                    End If
                Case "USOCFDI", "MONEDA"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1)
                        Var5 = Fg(Fg.Row, 2)
                    End If
                Case "GCTIPO_OPERACION"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1)
                        Var5 = Fg(Fg.Row, 2)
                    End If
            End Select
            Me.Close()

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:" & Proceso)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles TBox.TextChanged
        Try
            Select Case Proceso
                Case "ClasificProv"
                    SQL = "SELECT CLASIFIC FROM PROV" & Empresa & " 
                        WHERE ISNULL(STATUS,'A') = 'A' AND ISNULL(CLASIFIC,'') <> '' AND CLASIFIC LIKE '%" & TBox.Text & "%' 
                        ORDER BY CVE_TIPO"
                Case "USOCFDI"
                    SQL = "SELECT usoCfdi, descripcion FROM tblcusocfdi 
                        WHERE usoCfdi LIKE '%" & TBox.Text & "%' OR descripcion LIKE '%" & TBox.Text & "%' 
                        ORDER BY usoCfdi"
                Case "GCTIPO_OPERACION"
                    SQL = "SELECT T.CVE_TIPO, T.DESCR FROM GCTIPO_OPERACION T 
                        WHERE ISNULL(STATUS,'A') = 'A' AND DESCR LIKE '%" & TBox.Text & "%'
                        ORDER BY CVE_TIPO"
                Case "MONEDA"
                    SQL = "SELECT moneda, descripcion FROM tblcmoneda 
                        WHERE moneda LIKE '%" & TBox.Text & "%' OR descripcion LIKE '%" & TBox.Text & "%' 
                        ORDER BY moneda"

            End Select
            DESPLEGAR()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarAceptar_Click(Nothing, Nothing)
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TBox.KeyDown
        Try
            If e.KeyCode = Keys.Down Then
                Fg.Focus()
                Return
            End If
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                TBox_TextChanged(Nothing, Nothing)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        BarAceptar_Click(Nothing, Nothing)
    End Sub
End Class
