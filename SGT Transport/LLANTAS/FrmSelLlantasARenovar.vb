Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class FrmSelLlantasARenovar
    Private ReadOnly TIPO_LLANTA As String
    Private ReadOnly NUM_PAR As Integer
    Private ReadOnly NLlantas As Integer
    Private UUID As String
    Private ENTRA As Boolean = True

    Public Sub New(PTIPO_LLANTA As String, PUUID As String, ByVal FnLLantas As Integer, FNUM_PAR As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        NLlantas = FnLLantas
        UUID = PUUID
        TIPO_LLANTA = PTIPO_LLANTA
        NUM_PAR = FNUM_PAR
    End Sub
    Private Sub FrmSelLlantasARenovar_Load(sender As Object, e As EventArgs) Handles Me.Load

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
            Dim id As Guid = Guid.NewGuid(), z As Integer = 1


            If UUID.Trim.Length = 0 Then
                UUID = id.ToString
            End If
            PassData4 = "no"
            Fg.Rows.Count = NLlantas + 1

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_ECONOMICO FROM GCLLA_REN_TMP WHERE UUID = '" & UUID & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            Fg(z, 1) = dr("NUM_ECONOMICO")
                            z += 1
                        Catch ex As Exception
                            Bitacora("357. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
            Me.CenterToParent()

        Catch ex As Exception
            Bitacora("357. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("357. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmSelLlantasARenovar_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Fg.Row = 1
        Fg.Col = 1
        Fg.StartEditing()
    End Sub
    Private Sub FrmSelLlantasARenovar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        GRABAR_NOS_ECONOMICOS()
        PassData3 = UUID
        Me.Dispose()
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As ClickEventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el número económico?", vbYesNo) = vbYes Then
                If Fg.Row > 0 Then
                    Fg.RemoveItem(Fg.Row)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        GRABAR_NOS_ECONOMICOS()
    End Sub
    Sub GRABAR_NOS_ECONOMICOS()
        Try
            Dim ExistLlanta As Boolean = True, z As Integer = 0
            PassData4 = "no"
            C1ToolBar1.Select()

            ENTRA = False

            If TIPO_LLANTA = "RENOVADO" Then
                For k = 1 To Fg.Rows.Count - 1
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Trim.Length > 0 Then
                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT NUM_ECONOMICO FROM GCLLANTAS WHERE NUM_ECONOMICO = '" & Fg(k, 1) & "'"
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        If dr.Read Then
                                            z += 1
                                        Else
                                            ExistLlanta = False
                                            Fg.Row = k
                                            Fg.Cols(k).StyleNew.BackColor = Color.Red
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("355. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                Next
                If Not ExistLlanta Then
                    MsgBox("Algunos números económicos no existen verifique por favor")
                    ENTRA = True
                    Return
                End If
            Else
                For k = 1 To Fg.Rows.Count - 1
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Trim.Length > 0 Then
                            z += 1
                        End If
                    End If
                Next
            End If
            If Fg.Rows.Count - 1 <> z Then
                MsgBox("Por favor capture todos los números de serie")
                Fg.Col = 1
                Fg.StartEditing()
                ENTRA = True
                Return
            End If

            SQL = "DELETE FROM GCLLA_REN_TMP WHERE UUID = '" & UUID & "'"
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                cmd2.CommandText = SQL
                returnValue = cmd2.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using

            For k = 1 To Fg.Rows.Count - 1
                If Not IsNothing(Fg(k, 1)) Then
                    If Fg(k, 1).ToString.Trim.Length > 0 Then
                        Try
                            SQL = "INSERT INTO GCLLA_REN_TMP (TIPO_LLANTA, NUM_ECONOMICO, CVE_ART, NUM_PAR, UUID) VALUES('" & TIPO_LLANTA & "','" &
                                Fg(k, 1) & "','" & Fg(k, 2) & "','" & NUM_PAR & "','" & UUID & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        PassData4 = "ok"
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("355. " & ex.Message & vbNewLine & ex.StackTrace)
                            'MsgBox("357. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("El número económico ya fue agregado en una partida anterior, verifique por favor")
                        End Try
                    End If
                End If
            Next
            Me.Close()

        Catch ex As Exception
            Bitacora("357. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("357. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit

        Try
            If ENTRA Then
                ENTRA = False
                If Fg.Row > 0 Then
                    If Fg.Col = 2 Then
                        e.Cancel = True
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
        End Try
        End Sub
    Private Sub Fg_ENTERCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If Fg.Col = 1 Then
                    Fg.StartEditing()
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
        End Try
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            ENTRA = False
            Var2 = "Llantas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then

                If EXISTE_NUM_ECONOMICO_FG(Var4, Fg.Row) Then
                    MsgBox("El número económico ya fue agregado verifique por favor")
                Else
                    If Var8.Trim.Length = 0 Then
                        MsgBox("La llanta no tiene asignado la clave del articulo, verifique por favor")
                    Else
                        Fg(Fg.Row, 1) = Var5
                        Fg(Fg.Row, 2) = Var8

                        If Fg.Row > Fg.Rows.Count - 1 Then
                            Fg.Row = Fg.Row + 1
                        End If
                    End If
                    Fg.Col = 1
                End If
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
            ENTRA = True
        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("175. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            ENTRA = False
            If e.KeyCode = Keys.F2 Then
                Var2 = "Llantas"
                Var4 = "" : Var5 = "" : Var6 = ""
                frmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    If EXISTE_NUM_ECONOMICO_FG(Var4, Fg.Row) Then
                        MsgBox("El número económico ya fue agregado verifique por favor")
                    Else
                        Fg.Editor.Text = Var5
                        Fg(Fg.Row, 2) = Var8
                        If Fg.Row < Fg.Rows.Count - 1 Then
                            Fg.Row = Fg.Row + 1
                        End If
                        ENTRA = True
                        Fg.StartEditing()
                    End If

                    Var2 = "" : Var4 = "" : Var5 = ""
                End If
            End If
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                If Fg.Row < Fg.Rows.Count - 1 Then
                    'Fg.Row = Fg.Row + 1
                Else
                    'Fg.StartEditing()
                    'Fg.Row = 1
                End If
            End If
            ENTRA = True

        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("175. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Function EXISTE_NUM_ECONOMICO_FG(FNUM_ECONOMICO As String, FRow As Integer) As Boolean
        Dim ExistNumas As Boolean = False
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) = FNUM_ECONOMICO And k <> FRow Then
                    ExistNumas = True
                    Exit For
                End If
            Next
            Return ExistNumas
        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("175. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ExistNumas
        End Try
    End Function
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            'SQL = "SELECT CAST(LL.CVE_LLANTA AS INT), LL.NUM_ECONOMICO, LL.UNIDAD, LL.POSICION, M.DESCR 
            'From GCLLANTAS LL 
            'Left JOIN GCMARCAS M ON M.CVE_MARCA = LL.MARCA 
            'WHERE LL.STATUS = 'A' ORDER BY TRY_CAST(NUM_ECONOMICO AS INT)"
            Dim NoExist As Boolean = False, CVE_ART As String = ""

            If Fg.Editor.Text.Trim.Length > 0 And ENTRA Then
                If EXISTE_NUM_ECONOMICO_FG(Fg.Editor.Text, Fg.Row) Then
                    MsgBox("El número económico ya fue agregado verifique por favor")
                    Fg.Editor.Text = ""
                    e.Cancel = True
                Else
                    ENTRA = False
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(CVE_ART,'') AS CVEART, NUM_ECONOMICO FROM GCLLANTAS WHERE NUM_ECONOMICO = '" & Fg.Editor.Text & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If Not dr.Read Then
                                NoExist = True
                            Else
                                NoExist = False
                                CVE_ART = dr("CVEART")
                                Fg(Fg.Row, 2) = CVE_ART
                            End If
                        End Using
                    End Using
                    If NoExist = True Then
                        MsgBox("Número económico inexistente, verifique por favor")
                        e.Cancel = True
                        Fg.Editor.Text = ""
                    Else
                        If CVE_ART.Trim.Length = 0 Then
                            MsgBox("La llanta no tiene asignada clave de artículo, verifique por favor")
                            e.Cancel = True
                            Fg.Editor.Text = ""
                        Else
                            If Fg.Row <= Fg.Rows.Count - 1 Then
                                'Fg.Row = Fg.Row + 1
                            Else
                                Fg.Row = 1
                            End If
                        End If
                        Fg.StartEditing()
                    End If
                    ENTRA = True

                End If
            End If
        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("175. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Col = 1 Then
                Fg.StartEditing()
            End If
        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
