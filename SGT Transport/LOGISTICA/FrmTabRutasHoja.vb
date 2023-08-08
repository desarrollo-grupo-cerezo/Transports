Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmTabRutasHoja
    Private Nrow As Integer = 0
    Private TIPO_RUTAS As String
    Private CADENA As String
    Private CAT_RUTAS As Integer = 0
    Private ASIG_VIAJES As Integer
    Private SERIE_RE As String

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmTabRutasHoja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If TIPO_RUTAS = "RE" Then
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try
        End If


    End Sub
    Sub CARGAR_DATOS()
        Try
            Fg.Rows(0).Height = 40
            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - 150
            Fg.Cols(0).Width = 50
            Fg.DrawMode = DrawModeEnum.OwnerDraw
            If PASS_GRUPOCE = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = Fg(0, k) & "(" & k & ")"
                Next
            End If


            TIPO_RUTAS = Var10 '= "RE"  = F

            If TIPO_RUTAS = "F" Then
                CADENA = " AND ISNULL(SERIE_RE,'') = ''"
            Else
                Lt1.Visible = True
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(SERIE_RE,'R') AS SER_RE FROM GCPARAMTRANSCG"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                SERIE_RE = dr("SER_RE")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try

                CADENA = " AND ISNULL(SERIE_RE,'') = '" & SERIE_RE & "'"
            End If


            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(CAT_RUTAS,0) AS CAT_RUT FROM GCPARAMGENERALES"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CAT_RUTAS = dr("CAT_RUT")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(ASIG_VIAJES,0) AS ASIG_VIAJ FROM GCPARAMGENERALES"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            ASIG_VIAJES = dr("ASIG_VIAJ")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            DESPLEGAR()
        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR()
        Dim s As String, AUTO_SENC_LTS As Decimal = 0, P4_SENC_LTS As Decimal = 0, FULL_AUTO_LTS As Decimal = 0, FULL_P4_LTS As Decimal = 0
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE
            Fg.Redraw = False
            Fg.Rows.Count = 1

            Fg.BeginUpdate()



            SQL = "SELECT T.CVE_TAB, ISNULL(T.CLIE_OP,'') AS C_OP, ISNULL(OP1.NOMBRE,'') AS NOM_CTE, ISNULL(T.DESCR,'') AS DES,
                ISNULL(T.DESCR2,'') AS DES2, OP2.CLAVE AS C_OP_O, ISNULL(OP2.NOMBRE,'') AS NOM_OP_O, 
                OP3.CLAVE AS C_OP_D, ISNULL(OP3.NOMBRE,'') AS NOM_OP_D, T.CVE_GAS, KMS, T.AUTO_SENC, 
                T.AUTO_SENC_LTS, T.SUELDO_FULL, T.SUELDO_SENC, T.TAR_X_TON_FULL, T.TAR_X_VIA_FULL, T.TAR_X_TON_SENC, 
                T.TAR_X_VIA_SENC, GT.DESCR AS GASTOS, GS.DESCR AS GASOLINERA, T.LITROS_RUTA, PORC_SUELDO_FULL, 
                PORC_SUELDO_SENC, TAR_OPER_FULL, CVE_CASETA, ISNULL(IMPORTE_GASTO,0) AS IMPORTE
                FROM GCTAB_RUTAS_F T
                LEFT JOIN CLIE" & Empresa & " OP1 ON OP1.CLAVE = T.CLIE_OP
                LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = T.CLIE_OP_O
                LEFT JOIN GCCLIE_OP OP3 ON OP3.CLAVE = T.CLIE_OP_D
                LEFT JOIN GCCONC_GASTOS GT ON GT.CVE_GAS = T.CVE_GAS
                LEFT JOIN GCGASOLINERAS GS ON GS.CVE_GAS = T.CVE_GASOL
                WHERE T.STATUS = 'A' " & CADENA & "
                ORDER BY TRY_PARSE(T.CVE_TAB AS INT) DESC"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                '           1                    2                    3                   4                      5
                s = dr("CVE_TAB") & vbTab & dr("DES") & vbTab & dr("DES2") & vbTab & dr("C_OP") & vbTab & dr("NOM_CTE") & vbTab
                '              6                       7                       8                      9                
                s = s & dr("C_OP_O") & vbTab & dr("NOM_OP_O") & vbTab & dr("C_OP_D") & vbTab & dr("NOM_OP_D") & vbTab
                '              10                        11                    12                      13                          14
                s = s & dr("CVE_CASETA") & vbTab & dr("IMPORTE") & vbTab & dr("KMS") & vbTab & dr("AUTO_SENC") & vbTab & dr("TAR_X_TON_FULL") & vbTab
                '                15                              16                             17               
                s = s & dr("TAR_X_VIA_FULL") & vbTab & dr("TAR_X_VIA_SENC") & vbTab & dr("TAR_OPER_FULL") & vbTab
                '                 18                             19                               20                            21
                s = s & dr("TAR_X_TON_SENC") & vbTab & dr("PORC_SUELDO_FULL") & vbTab & dr("PORC_SUELDO_SENC") & vbTab & dr("SUELDO_FULL") & vbTab
                '                22                         23                       24      
                s = s & dr("SUELDO_SENC") & vbTab & dr("GASOLINERA") & vbTab & dr("GASTOS") & vbTab
                '       25                    26                 27            28
                s = s & "" & vbTab & dr("LITROS_RUTA") & vbTab & "N" & vbTab & ""
                Fg.AddItem("" & vbTab & s)
            Loop
            dr.Close()
            Fg.AutoSizeCols()
            If PASS_GRUPOCE <> "BUS" Then
                Fg.Cols(25).Visible = False 'CLIE_OP
                Fg.Cols(26).Visible = False 'CVE_PLAZA
                Fg.Cols(27).Visible = False 'CVE_PLAZA
                Fg.Cols(28).Visible = False 'CVE_PROD
                Fg.Cols(29).Visible = False 'CVE_PLAZA
                Fg.Cols(30).Visible = False 'CVE_PROD
                Fg.Cols(31).Visible = False 'CVE_PROD
                Fg.Cols(32).Visible = False 'MODIFICADO Si ó No ENDEJO
            End If
            Fg.Cols(0).Width = 50

            If Nrow > 0 Then
                Fg.Row = Nrow
            End If
            Nrow = 0
            Fg.Redraw = True

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        Finally
            Fg.EndUpdate()
        End Try
    End Sub
    Private Sub FrmTabRutasHoja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Tab. rutas")
        Me.Dispose()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Rutas")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 3 Then

                End If
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            '1 2 4 6 8 10 14
            If e.Col = 1 Or e.Col = 2 Or e.Col = 4 Or e.Col = 6 Or e.Col = 8 Or e.Col = 10 Or e.Col = 14 Or
                e.Col = 21 Or e.Col = 22 Or e.Col = 23 Or e.Col = 24 Then
                e.Cancel = True
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        'Get the current cell's Editor As a TextBox
        Dim tb As TextBox = DirectCast(Me.Fg.Editor, TextBox)
        If tb.SelectionLength <> 0 Then
            tb.SelectionStart = tb.SelectionLength
        End If
    End Sub
    Private Sub Fg_KeyPressEdit(sender As Object, e As KeyPressEditEventArgs) Handles Fg.KeyPressEdit
        If Fg.Col = 16 Then
            Try
                If IsNumeric(Fg.Editor.Text) Then
                    Fg(Fg.Row, 21) = CDec(Fg.Editor.Text) / Fg(Fg.Row, 17)
                End If
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
            Try
                If IsNumeric(Fg.Editor.Text) Then
                    Fg(Fg.Row, 22) = CDec(Fg.Editor.Text) / Fg(Fg.Row, 18)
                End If
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
            Try
                If IsNumeric(Fg.Editor.Text) Then
                    Fg(Fg.Row, 23) = CDec(Fg.Editor.Text) / Fg(Fg.Row, 19)
                End If
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
            Try
                If IsNumeric(Fg.Editor.Text) Then
                    Fg(Fg.Row, 24) = CDec(Fg.Editor.Text) / Fg(Fg.Row, 20)
                End If
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
        If Fg.Col = 17 Then
            Try
                If IsNumeric(Fg.Editor.Text) Then
                    Fg(Fg.Row, 21) = Fg(Fg.Row, 16) / CDec(Fg.Editor.Text)
                End If
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
        If Fg.Col = 18 Then
            Try
                If IsNumeric(Fg.Editor.Text) Then
                    Fg(Fg.Row, 22) = Fg(Fg.Row, 16) / CDec(Fg.Editor.Text)
                End If
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
        If Fg.Col = 19 Then
            Try

                If IsNumeric(Fg.Editor.Text) Then
                    Fg(Fg.Row, 23) = Fg(Fg.Row, 16) / CDec(Fg.Editor.Text)
                End If
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

        If Fg.Col = 20 Then
            Try
                If IsNumeric(Fg.Editor.Text) Then
                    Fg(Fg.Row, 24) = Fg(Fg.Row, 16) / CDec(Fg.Editor.Text)
                End If
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            Var10 = TIPO_RUTAS

            FrmTabRutasHojaAE.ShowDialog()

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Try
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            Var10 = TIPO_RUTAS
            Nrow = Fg.Row

            FrmTabRutasHojaAE.ShowDialog()

            'DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles Fg.AfterEdit

    End Sub

    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If Fg.Editor.Text <> Fg(e.Row, e.Col) Then
                Fg(e.Row, 27) = "Si"
                Select Case e.Col
                    Case 3
                        Fg(e.Row, 32) = "Si"
                    Case 5
                        Fg(e.Row, 33) = "Si"
                    Case 7
                        Fg(e.Row, 34) = "Si"
                    Case 9
                        Fg(e.Row, 35) = "Si"
                    Case 11
                        Fg(e.Row, 36) = "Si"
                    Case 12
                        Fg(e.Row, 37) = "Si"
                    Case 13
                        Fg(e.Row, 38) = "Si"
                End Select
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_SetupEditor(sender As Object, e As RowColEventArgs) Handles Fg.SetupEditor
        Dim tb As TextBox = TryCast(Fg.Editor, TextBox)
        'Dim tb As TextBox = DirectCast(Me.Fg.Editor, TextBox)
        'tb.SelectionStart = 3
        If tb IsNot Nothing Then
            'tb.[Select](0, 3)
            'tb.[Select](0, tb.Text.Length)
        End If
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar la ruta seleccionada?", vbYesNo) = vbYes Then

                SQL = "UPDATE GCTAB_RUTAS_F SET STATUS = 'B' WHERE CVE_TAB = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
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
End Class
