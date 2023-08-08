Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Public Class FrmObserYCampLib
    Private IDTABLA As String
    Private TABLAL As String
    Private NUM_PART As Integer
    Private ENTRA_FLEXI As Boolean = True
    Private CVE_DOC As String
    Private Sub FrmObserYCampLib_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Me.CenterToScreen()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        If TIPO_OTI = 0 Then
            TObser.MaxLength = 32767
        Else
            TObser.MaxLength = 255
        End If
        TObser.Text = Var4
        TObser.SelectionStart = 0
        TObser.Dock = DockStyle.Fill
        Fg.Dock = DockStyle.Fill


        If TIPO_COMPRA <> "o" And TIPO_COMPRA <> "q" Then
            If Var5 <> "NUEVO" Then
                TObser.Enabled = False
            End If
        End If
        IDTABLA = Var6
        TABLAL = Var7
        CVE_DOC = Var8

        NUM_PART = Var20


        CARGAR_CAMPLIB()
        'tObser.Select()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Var4 = TObser.Text
        Try
            Dim DATO As String = ""
            'Var6 = "FACTF_CLIB"
            'Var7 = "FACT" & TIPO_VENTA & "_CLIB" & Empresa
            'Var6 = "PAR_FACT_CLIB"
            'Var7 = "PAR_FACT" & TIPO_VENTA & "_CLIB" & Empresa
            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Not IsNothing(Fg(k, 3)) Then
                        If Not IsDBNull(Fg(k, 3)) Then
                            DATO = Fg(k, 3)
                            If DATO.Trim.Length = 0 Then
                                If Fg(k, 4) = "N" Then
                                    DATO = "0"
                                End If
                            End If
                        Else
                            If IsNumeric(Fg(k, 4)) Then
                                DATO = "0"
                            Else
                                DATO = ""
                            End If
                        End If
                    Else
                        If Fg(k, 4) = "N" Then
                            DATO = "0"
                        Else
                            DATO = ""
                        End If
                    End If
                    If Var6 = "FACTF_CLIB" Then
                        aLIB1(k, 0) = Fg(k, 1) 'CAMPO
                        aLIB1(k, 1) = Fg(k, 3) 'DATO CAPTURADO
                    Else
                        aLIB2(NUM_PART, k, 0) = Fg(k, 1)
                        aLIB2(NUM_PART, k, 1) = Fg(k, 3)
                    End If
                Catch ex As Exception
                    Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Me.Close()
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Private Sub FrmObserYCampLib_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub TObser_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TObser.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                Fg.Focus()
                Fg.Row = 1
                Fg.Col = 3
                'FgL.Select()
                Split2.Focus()
            End If
        Catch ex As Exception
            Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_CAMPLIB()
        Try
            Dim TIPO_CAMPO As String, FIELD_NAME As String, LIBRE As String

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            ENTRA_FLEXI = False
            'TAB1.SelectedIndex = 2
            Fg.Rows.Count = 1
            Fg.Cols.Fixed = 2

            Fg.Cols(1).Width = 0
            Fg.Cols(4).Width = 0
            cmd.Connection = cnSAE

            SQL = "SELECT NUM_EMP, IDTABLA, 
                CAMPO, SUBSTRING(CAMPO,1,7) + REPLICATE('0', 2-LEN(SUBSTRING(CAMPO,8,LEN(CAMPO)-7))) + SUBSTRING(CAMPO,8,LEN(CAMPO)-7), 
                ETIQUETA 
                FROM PARAM_CAMPOSLIBRES" & Empresa & " WHERE 
                IDTABLA = '" & IDTABLA & "' 
                ORDER BY SUBSTRING(CAMPO,1,7) + REPLICATE('0', 2-LEN(SUBSTRING(CAMPO,8,LEN(CAMPO)-7))) + SUBSTRING(CAMPO,8,LEN(CAMPO)-7)"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                If EXIST_FIELD_SQL_SAE(TABLAL, dr("CAMPO")) Then
                    Fg.AddItem("" & vbTab & dr.ReadNullAsEmptyString("CAMPO") & vbTab & dr.ReadNullAsEmptyString("ETIQUETA") & vbTab & " " & vbTab & " ")
                End If
            Loop
            dr.Close()

            If CVE_DOC.Trim.Length > 0 Then
                SQL = "SELECT TOP 1 * FROM " & TABLAL & " WHERE CLAVE_DOC = '" & CVE_DOC & "'"
            Else
                SQL = "SELECT TOP 1 * FROM " & TABLAL
            End If

            cmd.CommandText = SQL               '1 nombre del campo FIELD
            dr = cmd.ExecuteReader              '2 LEYENDA    
            If dr.Read Then                     '3 contenido del campo
                For k = 0 To dr.FieldCount - 1  '4 TIPO NUMERICO O STRING
                    Try
                        '{BACKUPTXT("INVE_CLIB", dr.GetName(k).ToString & "," & dr.GetFieldType(k).ToString & "," & dr.GetDataTypeName(k).ToString & ",'" & dr.GetSchemaTable.Columns(k).MaxLength)
                        FIELD_NAME = dr.GetName(k).ToString
                        For j = 1 To Fg.Rows.Count - 1
                            If Fg(j, 1) = FIELD_NAME Then

                                TIPO_CAMPO = dr.GetDataTypeName(k).ToString.ToUpper
                                'Dim c As Column = Fg.Cols(3)
                                If TIPO_CAMPO = "INT32" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or TIPO_CAMPO = "NUMERIC" Or
                                    TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Or TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "DECIMAL" Then

                                    If CVE_DOC.Trim.Length > 0 Then
                                        Fg(j, 3) = dr.ReadNullAsEmptyDecimal(FIELD_NAME)
                                    End If
                                    Fg(j, 4) = "N"
                                    'c.DataType = GetType(Decimal)
                                Else
                                    If CVE_DOC.Trim.Length > 0 Then
                                        LIBRE = dr.ReadNullAsEmptyString(FIELD_NAME)
                                        Fg(j, 3) = LIBRE
                                    End If
                                    Fg(j, 4) = " "
                                    'c.DataType = GetType(String)
                                End If

                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            Else
                For k = 0 To dr.FieldCount - 1  '4 TIPO NUMERICO O STRING
                    Try
                        'BACKUPTXT("INVE_CLIB", dr.GetName(k).ToString & "," & dr.GetFieldType(k).ToString & "," & dr.GetDataTypeName(k).ToString & ",'" & dr.GetSchemaTable.Columns(k).MaxLength)
                        FIELD_NAME = dr.GetName(k).ToString
                        For j = 1 To Fg.Rows.Count - 1
                            If Fg(j, 1) = FIELD_NAME Then
                                TIPO_CAMPO = dr.GetDataTypeName(k).ToString.ToUpper
                                Dim c As Column = Fg.Cols(3)
                                If TIPO_CAMPO = "INT32" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or TIPO_CAMPO = "NUMERIC" Or
                                    TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Or TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "DECIMAL" Then

                                    Fg(j, 4) = "N"
                                    c.DataType = GetType(Decimal)
                                Else
                                    Fg(j, 4) = ""
                                    c.DataType = GetType(String)
                                End If
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            End If
            dr.Close()
            Me.Refresh()

            Fg.FinishEditing()

            If CVE_DOC.Trim.Length = 0 Then
                Try
                    For k = 1 To Fg.Rows.Count - 1
                        If Var6 = "FACTF_CLIB" Then
                            For j = 0 To aLIB1.GetLength(0) - 1
                                If aLIB1(j, 0) <> "--" Then
                                    If Fg(k, 1) = aLIB1(j, 0) Then
                                        Fg(k, 3) = aLIB1(j, 1)
                                    End If
                                End If
                            Next
                        Else
                            For j = 0 To aLIB2.GetLength(0) - 2
                                If aLIB2(NUM_PART, j, 0) <> "--" Then
                                    If Fg(k, 1) = aLIB2(NUM_PART, j, 0) Then
                                        Fg(k, 3) = aLIB2(NUM_PART, j, 1)
                                    End If
                                End If

                            Next
                        End If
                    Next
                Catch ex As Exception
                    Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If

        Catch ex As Exception
            Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("65. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        ENTRA_FLEXI = True
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA_FLEXI Then
                If Fg.Col = 3 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If e.Row > 0 And ENTRA_FLEXI Then
                If e.Col = 3 Then
                    If Fg(e.Row, 4) = "N" Then
                        If Not IsNumeric(Fg.Editor.Text()) Then
                            e.Cancel = True
                            Fg.Editor.Text = "0"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 2 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus
        Try
            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        Catch ex As Exception
            Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TObser_KeyDown(sender As Object, e As KeyEventArgs) Handles TObser.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                BtnAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                BtnAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
