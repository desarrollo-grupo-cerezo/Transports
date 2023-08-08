Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmSelItemBancos
    Dim Proceso As String
    Dim VarCadena As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmSelItemBancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Case "CVE_CONCEP"
                    SQL = "SELECT CVE_CONCEP, TIPO, CONCEP, CLASIFICACION, IVA 
                        FROM BCONCEP WHERE ISNULL(STATUS,'A') = 'A' ORDER BY CVE_CONCEP"
                    Fg.Cols.Count = 6
                    Fg(0, 1) = "Concepto"
                    Fg(0, 2) = "Tipo"
                    Fg(0, 3) = "Descripción"
                    Fg(0, 4) = "Clasificación"
                    Fg(0, 5) = "IVA"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 65
                    Fg.Cols(2).Width = 60
                    Fg.Cols(3).Width = 250
                    Fg.Cols(4).Width = 80
                    Fg.Cols(5).Width = 70
                    Me.Width = 480
                    Fg.Width = Me.Width - 30
                    Me.MaximizeBox = False
                    Me.MinimizeBox = False
                Case "FORMAPAGOSAT"
                    SQL = "SELECT formaPago, descripcion FROM tblcformapago ORDER BY formaPago"
                    Fg.Cols.Count = 3
                    Fg(0, 1) = "Forma de pago"
                    Fg(0, 2) = "Descripción"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 80
                    Fg.Cols(2).Width = 320
                    Me.Width = 480
                    'Me.Height = 200
                    Fg.Width = Me.Width - 30
                    Me.MaximizeBox = False
                    Me.MinimizeBox = False
                Case "BENEF"
                    SQL = "SELECT CLAVE, NOMBRE, RFC, TIPO, REFERENCIA FROM BBENEF WHERE ISNULL(STATUS,'') = 'A' ORDER BY CLAVE"
                    Fg.Cols.Count = 6
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Nombre"
                    Fg(0, 3) = "RFC"
                    Fg(0, 4) = "Tipo"
                    Fg(0, 5) = "Referencia"

                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 35
                    Fg.Cols(2).Width = 280
                    Fg.Cols(3).Width = 90
                    Fg.Cols(4).Width = 50
                    Fg.Cols(5).Width = 90
                    Me.Width = 600
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
                            Case "CVE_CONCEP"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4))
                            Case "FORMAPAGOSAT"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1))
                            Case "BENEF"
                                Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4))
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
    Private Sub FrmSelItemBancos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If DialogOK = "Show" Then
            Me.TopMost = False
        End If
        Me.Dispose()
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click
        Try
            Select Case Proceso
                Case "CVE_CONCEP"
                    'SQL = "SELECT CVE_CONCEP, TIPO, CONCEP, CLASIFICACION, IVA FROM BCONCEP ORDER BY CVE_CONCEP"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1)
                        Var5 = Fg(Fg.Row, 3)
                        Var6 = Fg(Fg.Row, 5)
                    End If
                Case "FORMAPAGOSAT"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1)
                        Var5 = Fg(Fg.Row, 2)
                    End If
                Case "BENEF"
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

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click

        Select Case Proceso
            Case "CVE_CONCEP"
                SQL = "SELECT CVE_CONCEP, TIPO, CONCEP, CLASIFICACION, IVA 
                        FROM BCONCEP ORDER BY CVE_CONCEP"
            Case "FORMAPAGOSAT"
                SQL = "SELECT formaPago, descripcion FROM tblcformapago ORDER BY formaPago"
            Case "BENEF"
                SQL = "SELECT NUM_REG, NOMBRE, RFC, TIPO, REFERENCIA FROM BBENEF ORDER BY NUM_REG"
        End Select
        DESPLEGAR()
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles TBox.TextChanged
        Try
            Select Case Proceso
                Case "CVE_CONCEP"
                    SQL = "SELECT CVE_CONCEP, TIPO, CONCEP, CLASIFICACION, IVA 
                        FROM BCONCEP
                        WHERE CVE_CONCEP LIKE '%" & TBox.Text & "%' OR TIPO LIKE '%" & TBox.Text & "%' OR 
                        CONCEP LIKE '%" & TBox.Text & "%' OR CLASIFICACION LIKE '%" & TBox.Text & "%' 
                        ORDER BY CVE_CONCEP"
                Case "FORMAPAGOSAT"
                    SQL = "SELECT formaPago, descripcion FROM tblcformapago
                        WHERE UPPER(formaPago) LIKE '%" & TBox.Text.ToUpper & "%' OR 
                        UPPER(descripcion) LIKE '%" & TBox.Text.ToUpper & "%'
                        ORDER BY formaPago"
                Case "BENEF"
                    SQL = "SELECT NUM_REG, NOMBRE, RFC, TIPO, REFERENCIA 
                    FROM BBENEF 
                    WHERE 
                    UPPER(NOMBRE) LIKE '%" & TBox.Text.ToUpper & "%' OR 
                    UPPER(RFC) LIKE '%" & TBox.Text.ToUpper & "%' OR 
                    UPPER(TIPO) LIKE '%" & TBox.Text.ToUpper & "%' OR 
                    UPPER(REFERENCIA) LIKE '%" & TBox.Text.ToUpper & "%'
                    ORDER BY NUM_REG"
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
                BarAceptar_Click(Nothing, Nothing)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                BarAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
