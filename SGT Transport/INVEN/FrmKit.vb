Imports System.IO
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmKit
    Private ENTRA As Boolean
    Private ENTRA_KEY As Boolean
    Private REMOVE_ROW As Integer
    Private ENTRA_BTN As Boolean
    Private Key_Pres As Integer
    Private ARTICULO As String
    Private Tabla As String


    Private Sub frmKit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try

            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            Me.KeyPreview = True
            ENTRA = True
            ENTRA_KEY = True
            Key_Pres = 0
            REMOVE_ROW = 0
            ENTRA_BTN = True

            Fg.Rows(0).Height = 40

            ARTICULO = Var10
            Tabla = Var11
            tPrecio.Value = Var12
            DESPLEGAR()

            tPrecio.Select()


        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            If Tabla = "InvenR" Then
                SQL = "SELECT CVE_PROD, PORCEN, CANTIDAD, ISNULL(ULT_COSTO,0) AS UCOSTO,  DESCR, " &
                "ISNULL((SELECT PRECIO FROM GCPRECIO_X_PROD P1 WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1), 0) AS P1, " &
                "ISNULL((SELECT PRECIO FROM GCPRECIO_X_PROD P2 WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 2), 0) AS P2 " &
                "FROM GCKITS K " &
                "LEFT JOIN GCINVER I ON I.CVE_ART = K.CVE_PROD " &
                "LEFT JOIN GCCVES_ALTER A ON A.CVE_ART = K.CVE_PROD " &
                "WHERE K.CVE_ART = '" & ARTICULO & "'"
            Else
                SQL = "SELECT CVE_PROD, PORCEN, CANTIDAD, ISNULL(ULT_COSTO,0) AS UCOSTO,  DESCR, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P1 WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1), 0) AS P1, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P2 WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 2), 0) AS P2 " &
                "FROM KITS" & Empresa & " K " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = K.CVE_PROD " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = K.CVE_PROD " &
                "WHERE K.CVE_ART = '" & ARTICULO & "'"
            End If

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            ENTRA = False
            Fg.Rows.Count = 1
            If dr.HasRows Then
                Do While dr.Read
                    Fg.AddItem("" & vbTab & dr("CVE_PROD") & vbTab & "" & vbTab & dr("DESCR") & vbTab & dr("CANTIDAD") & vbTab & dr("PORCEN") & vbTab &
                               dr("P1") & vbTab & dr("P2") & vbTab & dr("UCOSTO"))

                    Fg.SetCellImage(Fg.Rows.Count - 1, 2, My.Resources.LUPA4)
                Loop
            Else
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0")


                Fg.SetCellImage(Fg.Rows.Count - 1, 2, My.Resources.LUPA4)

                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                Fg.StartEditing()
            End If
            dr.Close()

            Calcular()
            ENTRA = True
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmKit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F4
                    barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("REalmente desea eliminar la partida?", vbYesNo) = vbYes Then
                    Fg.RemoveItem(Fg.Row)

                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0")

                    If File.Exists(Application.StartupPath & "\LUPA4.jpg") Then
                        Fg.SetCellImage(Fg.Rows.Count - 1, 2, My.Resources.LUPA4)
                    End If
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 1
                    Fg.StartEditing()

                End If
            Else
                MsgBox("Por favor seleccione un servicio")
            End If
        Catch ex As Exception
            MsgBox("109. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("109. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()

    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_ART As String
        Dim CANT As Single
        Dim PORCEN As Single
        Dim GraboOk As Boolean

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        Try
            GraboOk = False

            For k = 1 To Fg.Rows.Count - 1

                CVE_ART = Fg(k, 1)
                CANT = Fg(k, 4)
                PORCEN = Fg(k, 5)

                If CANT > 0 And CVE_ART.Trim.Length > 0 Then

                    SQL = "UPDATE " & IIf(Tabla = "Inven", "KITS" & Empresa, "GCKITS") & " SET CVE_PROD = @CVE_PROD, PORCEN = @PORCEN, CANTIDAD = @CANTIDAD " &
                        "WHERE CVE_ART = @CVE_ART AND CVE_PROD = @CVE_PROD " &
                        "IF @@ROWCOUNT = 0 " &
                        "INSERT INTO " & IIf(Tabla = "Inven", "KITS" & Empresa, "GCKITS") & " (CVE_ART, CVE_PROD, PORCEN, CANTIDAD) VALUES(@CVE_ART, @CVE_PROD, @PORCEN, @CANTIDAD)"

                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(ARTICULO)
                        cmd.Parameters.Add("@CVE_PROD", SqlDbType.VarChar).Value = RemoveCharacter(CVE_ART)
                        cmd.Parameters.Add("@PORCEN", SqlDbType.Float).Value = PORCEN
                        cmd.Parameters.Add("@CANTIDAD", SqlDbType.Float).Value = CANT
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                GraboOk = True
                                Me.Close()
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            If GraboOk Then
                MsgBox("El registro se grabo satisfactoriamente")
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click

        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            MsgBox("104. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("104. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                Select Case Fg.Col
                    Case 3

                    Case > 4

                    Case Else
                        If REMOVE_ROW > 0 Then
                            If Fg.Row > 0 Then
                                Fg.Row = REMOVE_ROW
                            End If
                            REMOVE_ROW = 0
                        End If
                        Fg.StartEditing()
                End Select
            End If
        Catch ex As Exception
            MsgBox("105. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 2 Then
                    e.Cancel = True
                End If
                If Fg.Col = 3 Then
                    e.Cancel = True
                End If
                If Fg.Col > 4 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox("106. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("106. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 Then
                    If Key_Pres = Keys.Right Or Key_Pres = Keys.Left Then
                        Key_Pres = 0
                        e.Cancel = True
                    End If
                    If Fg.Editor.Text.Trim.Length > 0 Then
                        If Existe_Kit(Fg.Editor.Text) Then
                            MsgBox("El articulo existe en el kit verifique por favor")
                            e.Cancel = True
                            Fg.Editor.Text = ""
                            Fg(Fg.Row, 3) = ""
                            Return
                        End If

                        KIT_DATOS_INVE(Tabla, Fg.Editor.Text)

                        'Var9 ' reader("DESCR")
                        'Var10 ' reader("P1")
                        'Var11 ' reader("P2")
                        'Var12 ' reader("UCOSTO")
                        If Var9 <> "" Then
                            Fg(Fg.Row, 3) = Var9
                            Fg(Fg.Row, 6) = Var10
                            Fg(Fg.Row, 7) = Var11
                            Fg(Fg.Row, 8) = Var12
                        Else
                            e.Cancel = True
                            MsgBox("Articulo inexistente")
                            ENTRA = False
                            Fg.Editor.Text = ""
                            ENTRA = True
                            Fg.Col = 1
                        End If
                    Else

                        Select Case Key_Pres
                            Case Keys.Up '38

                            Case Keys.Down '40

                                If Fg.Editor.Text.Trim.Length = 0 Then

                                    e.Cancel = True
                                Else
                                    Key_Pres = 0
                                    e.Cancel = True

                                End If
                            Case 13, 9
                                Key_Pres = 0
                                e.Cancel = True
                            Case Else
                                'e.Cancel = True
                                If Key_Pres = Keys.Right Then
                                    If Fg.Editor.Text.Trim.Length = 0 Then
                                        e.Cancel = True
                                        Key_Pres = 0
                                    End If

                                Else

                                    Key_Pres = 0
                                End If

                        End Select
                    End If
                End If
                If e.Col = 4 Then
                    Calcular()
                End If
            End If
        Catch ex As Exception
            MsgBox("108. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("108. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus
        ENTRA_KEY = False
    End Sub

    Private Sub Fg_LostFocus(sender As Object, e As EventArgs) Handles Fg.LostFocus
        ENTRA_KEY = True
    End Sub

    Private Sub Fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles Fg.AfterEdit
        Try
            If e.Row > 0 And ENTRA Then
                If e.Col = 4 Then
                    If Fg(e.Row, 1).ToString.Trim.Length > 0 And Fg(e.Row, 3).ToString.Trim.Length > 0 Then
                        If Fg.Row = Fg.Rows.Count - 1 Then
                            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0")

                            If File.Exists(Application.StartupPath & "\LUPA4.jpg") Then
                                Fg.SetCellImage(Fg.Rows.Count - 1, 2, My.Resources.LUPA4)
                            End If

                            Fg.Row = Fg.Rows.Count - 1
                            Fg.Col = 1
                            Fg.StartEditing()
                            Return
                        End If
                    End If

                End If
                If e.Col = 1 Then
                    If Key_Pres = Keys.Down Then
                        Key_Pres = 0
                        If e.Row = Fg.Rows.Count - 1 Then

                            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0")

                            If File.Exists(Application.StartupPath & "\LUPA4.jpg") Then
                                Fg.SetCellImage(Fg.Rows.Count - 1, 2, My.Resources.LUPA4)
                            End If

                            Fg.Row = Fg.Rows.Count - 1
                            Fg.Col = 1
                            Fg.StartEditing()
                            Return
                        End If
                    Else
                        If Key_Pres = Keys.Up Then
                            Key_Pres = 0
                            If Fg(e.Row, 1).ToString.Trim.Length = 0 Or Fg(e.Row, 3).ToString.Trim.Length = 0 Then
                                Fg.RemoveItem(e.Row)
                                REMOVE_ROW = Fg.Row
                                Return
                            End If
                        Else
                            If Fg(e.Row, 1).ToString.Trim.Length > 0 Then
                                Fg.Select(e.Row, e.Col + 2)
                            End If
                        End If
                    End If
                    Return
                End If

            End If
        Catch ex As Exception
            MsgBox("109. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("109. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If ENTRA Then
                If e.KeyCode = Keys.F2 Then
                    btnArt_GotFocus(Nothing, Nothing)
                    Return
                End If
                If e.KeyCode = Keys.Up And e.Row > 1 Then
                    Key_Pres = e.KeyCode
                    Return
                End If
                If e.KeyCode = Keys.Down Then
                    Key_Pres = e.KeyCode
                    Return
                End If
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Then
                    Key_Pres = e.KeyCode
                    Return
                End If
                If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
                    Key_Pres = e.KeyCode
                    Return
                End If
                If e.KeyCode = 27 Then
                    Key_Pres = e.KeyCode
                    If Fg.Col = 1 Then
                        If Fg(Fg.Row, 1).ToString.Trim.Length = 0 Or Fg(Fg.Row, 3).ToString.Trim.Length = 0 Then
                            Fg.RemoveItem(Fg.Row)
                            REMOVE_ROW = Fg.Row
                            Return
                        End If
                    End If
                    Return
                End If
            End If
        Catch ex As Exception
            MsgBox("111. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 And e.KeyCode = 27 Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length = 0 Or Fg(Fg.Row, 3).ToString.Trim.Length = 0 Then
                        Fg.RemoveItem(Fg.Row)
                        REMOVE_ROW = Fg.Row
                        Return
                    End If
                    Return
                End If
                If Fg.Col = 1 And e.KeyCode = Keys.Down Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 And Fg(Fg.Row, 3).ToString.Trim.Length > 0 Then

                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0")

                        If File.Exists(Application.StartupPath & "\LUPA4.jpg") Then
                            Fg.SetCellImage(Fg.Rows.Count - 1, 2, My.Resources.LUPA4)
                        End If

                        Fg.Row = Fg.Rows.Count - 1
                        Fg.Col = 1
                        Fg.StartEditing()
                        Return
                    End If
                End If
                If Fg.Col = 4 Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 And Fg(Fg.Row, 3).ToString.Trim.Length > 0 Then

                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0")

                        If File.Exists(Application.StartupPath & "\LUPA4.jpg") Then
                            Fg.SetCellImage(Fg.Rows.Count - 1, 2, My.Resources.LUPA4)
                        End If

                        Fg.Col = 1
                        Fg.Row = Fg.Rows.Count - 1
                        Fg.StartEditing()
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("111. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function Existe_Kit(fKIT As String) As String
        Try
            Dim Exist_M As Boolean
            Exist_M = False
            For k = 1 To Fg.Rows.Count - 1
                If k <> Fg.Row Then
                    If Fg(k, 1) = fKIT Then
                        Exist_M = True
                        Exit For
                    End If
                End If
            Next
            Return Exist_M
        Catch ex As Exception
            Return False
            MsgBox("107. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("107. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Function

    Private Sub btnArt_GotFocus(sender As Object, e As EventArgs) Handles btnArt.GotFocus
        Try
            If Key_Pres = Keys.Right Or Key_Pres = Keys.Left Then
                Key_Pres = 0
                Fg.Col = 1
                Return
            End If
            If ENTRA_BTN Then
                ENTRA_BTN = False
                If Tabla = "InvenR" Then
                    Var2 = "InveR"
                Else
                    Var2 = "Articulo"
                End If

                Var4 = ""
                Var5 = ""
                Fg.FinishEditing()

                FrmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then

                    If Existe_Kit(Var4) Then
                        MsgBox("El articulo fue agregado verifique por favor")
                        Fg(Fg.Row, 1) = ""
                        Fg(Fg.Row, 3) = ""
                        Fg.Col = 1
                        Fg.StartEditing()
                        Return
                    End If

                    Fg(Fg.Row, 1) = Var4
                    Fg(Fg.Row, 3) = Var5
                    Var2 = ""
                    Var4 = ""
                    Var5 = ""
                    Fg.Col = 1
                    Fg.StartEditing()
                Else
                    Fg.Col = 1
                End If
                ENTRA_BTN = True
            End If

        Catch ex As Exception
            ENTRA_BTN = True
            MsgBox("107. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("107. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA_BTN = True
    End Sub
    Private Sub tPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles tPrecio.KeyDown
        Try
            Dim k As Integer

            If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
                Fg.Focus()

                If Fg.Row > 0 Then
                    ENTRA = False
                    For k = 1 To Fg.Rows.Count - 1
                        If Fg(k, 1).ToString = "" Then
                            Exit For
                        End If
                    Next
                    If k = Fg.Rows.Count Then
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0")

                        If File.Exists(Application.StartupPath & "\LUPA4.jpg") Then
                            Fg.SetCellImage(Fg.Rows.Count - 1, 2, My.Resources.LUPA4)
                        End If

                        Fg.Row = Fg.Rows.Count - 1
                        Fg.Col = 1
                        Fg.StartEditing()
                    Else
                        Fg.Row = k
                        Fg.Col = 1
                    End If
                    ENTRA = True
                Else
                    ENTRA = False
                    Fg.Row = 1
                    Fg.Col = 1
                    ENTRA = True
                End If

            End If
        Catch ex As Exception
            ENTRA = True
            msgbox("107. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("107. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub Calcular()
        '    Fg.TextMatrix(0, 1) = "Producto"
        '    Fg.TextMatrix(0, 2) = "?"
        '    Fg.TextMatrix(0, 3)= "Descripción"
        '    Fg.TextMatrix(0, 4) = "Cantidad"
        '    Fg.TextMatrix(0, 5) = "Porcentaje"
        '    Fg.TextMatrix(0, 6) = "Precio publico"
        '    Fg.TextMatrix(0, 7) = "Precio min."
        '    Fg.TextMatrix(0, 8) = "ULT COSTO"
        Dim PRECIO_REAL As Decimal
        Dim PRECIO_MINIMO_REAL As Decimal
        Dim COSTO_REAL As Decimal
        Dim PORCEN As Decimal

        Dim nPar As Integer
        Dim k As Integer

        ENTRA = False
        Try
            nPar = 0 : PRECIO_REAL = 0 : PRECIO_MINIMO_REAL = 0 : COSTO_REAL = 0
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 4) > 0 And Fg(k, 1).ToString.Length > 0 Then
                    nPar = nPar + 1
                    PRECIO_REAL = PRECIO_REAL + (Fg(k, 4) * Fg(k, 6))
                    PRECIO_MINIMO_REAL = PRECIO_MINIMO_REAL + (Fg(k, 4) * Fg(k, 7))
                    COSTO_REAL = COSTO_REAL + (Fg(k, 4) * Fg(k, 8))
                End If
            Next

            If PRECIO_REAL > 0 Then
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 4) > 0 And Fg(k, 1).ToString.Length > 0 Then
                        PORCEN = (PRECIO_REAL - Fg(k, 6)) / PRECIO_REAL
                        Fg(k, 5) = Math.Round((1 - PORCEN) * 100, 2)
                    End If
                Next
            End If
            LrPrecioReal.Text = Format(PRECIO_REAL, "###,##0.00") 'PRECIOS REAL
            LtPrecioMin.Text = Format(PRECIO_MINIMO_REAL, "###,##0.00")   'PRECIOS MINIMO REAL
            LtCosto.Text = Format(COSTO_REAL, "###,##0.00")   'COSTO
            LtTotal.Text = Format(PRECIO_REAL, "###,##0.00")    'TOTAL
            LtTotPar.Text = nPar 'TOTAL PARTIDAS
        Catch ex As Exception
            msgbox("107. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("107. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        ENTRA = True
    End Sub

    Private Sub frmKit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
