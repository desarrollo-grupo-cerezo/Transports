Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmSelItemTabFlores
    Private Sub FrmSelItemTabFlores_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CADENA1 As String, Ancho As Integer = 0, Sigue As Boolean, s As String
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos2, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue

        Catch ex As Exception
        End Try

        Try
            Fg.Redraw = False
            Fg.Rows.Count = 1
            Fg.Cols(1).AllowEditing = True

            'TITULOS()
            'Var3 = TCVE_OPER.Text
            'Var4 = TCVE_UNI.Text
            'SELECT * FROM GCCLIE_OP WHERE CLAVE = '" & fCVE_OPER & "'"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.STATUS, R.CVE_TAB, O.NOMBRE AS NOMBRE_OPER, A.CVE_TRACTOR, A.FECHA, 
                        (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNI, 
                        A.CLAVE_O, OP1.NOMBRE AS NOMBRE1, OP1.CVE_PLAZA AS PLAZA1, P1.CIUDAD AS CIUDAD1, 
                        A.CLAVE_D, OP2.NOMBRE AS NOMBRE2, OP2.CVE_PLAZA AS PLAZA2, P2.CIUDAD AS CIUDAD2, R.KMS, 
                        A.FECHA_CARGA, CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS STATUSVIAJE, 
                        RE.DESCR AS ORIGUEN, EE.DESCR AS DESTINO, U.CVE_REND, 
                        R.AUTO_SENC, R.P4_SENC, R.AUTO_SENC_LTS, R.P4_SENC_LTS,
                        R.FULL_AUTO, R.FULL_P4, R.FULL_AUTO_LTS, R.FULL_P4_LTS,
                        CVE_CAP1, CVE_CAP2
                        FROM GCASIGNACION_VIAJE A 
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                        LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                        LEFT JOIN GCCONTRATO C ON C.CVE_CON = A.CVE_CON
                        LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                        LEFT JOIN GCCLIE_OP OP1 ON OP1.CLAVE = A.CLAVE_O
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = OP1.CVE_PLAZA
                        LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = A.CLAVE_D
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = OP2.CVE_PLAZA
                        LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = A.RECOGER_EN
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = A.ENTREGAR_EN
                        WHERE A.STATUS <> 'C' AND A.CVE_ST_VIA <> 5 AND A.CVE_ST_VIA <> 7 AND 
                        A.CVE_OPER = '" & Var3 & "' AND A.CVE_TRACTOR = '" & Var4 & "'
                        ORDER BY A.FECHAELAB DESC"
                    'Var3 = TCVE_OPER.Text
                    'Var4 = TCVE_UNI.Tag
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            '("Autónomo")   0 '("P4")         1

                            Sigue = True
                            Try
                                For z = 0 To aDOCS.Length - 1
                                    If aDOCS(z) = dr("CVE_VIAJE") Then
                                        Sigue = False
                                    End If
                                Next
                            Catch ex As Exception
                            End Try

                            If Sigue Then
                                Try
                                    If dr("TIPOUNI") = "Full" Then
                                        If dr.ReadNullAsEmptyInteger("CVE_REND") = 0 Then
                                            CADENA1 = dr("FULL_AUTO") & vbTab & dr("FULL_AUTO_LTS")
                                        Else
                                            CADENA1 = dr("FULL_P4") & vbTab & dr("FULL_P4_LTS")
                                        End If
                                    Else
                                        If dr.ReadNullAsEmptyInteger("CVE_REND") = 0 Then
                                            CADENA1 = dr("AUTO_SENC") & vbTab & dr("AUTO_SENC_LTS")
                                        Else
                                            CADENA1 = dr("P4_SENC") & vbTab & dr("P4_SENC_LTS")
                                        End If
                                    End If
                                    '                1                   2                3                    4
                                    s = "" & vbTab & "" & vbTab & dr("CVE_TAB") & vbTab & 1 & vbTab & dr("CVE_VIAJE") & vbTab
                                    '           5                         6                          7
                                    s &= dr("STATUS") & vbTab & dr("NOMBRE_OPER") & vbTab & dr("CVE_TRACTOR") & vbTab
                                    '                                8                                            9 
                                    s &= dr.ReadNullAsEmptyString("FECHA") & vbTab & dr.ReadNullAsEmptyString("TIPOUNI") & vbTab
                                    '          10                       11                     12                      13  
                                    s &= dr("CLAVE_O") & vbTab & dr("NOMBRE1") & vbTab & dr("PLAZA1") & vbTab & dr("CIUDAD1") & vbTab
                                    '          14                       15                     16                      17
                                    s &= dr("CLAVE_D") & vbTab & dr("NOMBRE2") & vbTab & dr("PLAZA2") & vbTab & dr("CIUDAD2") & vbTab
                                    '          18                            19                        20                      21 
                                    s &= dr("FECHA_CARGA") & vbTab & dr("STATUSVIAJE") & vbTab & dr("ORIGUEN") & vbTab & dr("DESTINO") & vbTab
                                    '         22                23                    24                       25
                                    s &= dr("KMS") & vbTab & CADENA1 & vbTab & dr("CVE_CAP1") & vbTab & dr("CVE_CAP2")
                                    Fg.AddItem(s)
                                Catch ex As Exception
                                    Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                End Try
                            End If
                        End While
                    End Using
                    Fg.AutoSizeCols()                    'Fg.AutoSizeRows()
                End Using
            Catch ex As Exception
                Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

            If Fg.Rows.Count = 1 Then
                MsgBox("No se encontraron viajes")
                Me.Close()
            Else
                Fg.Cols(3).Visible = False : Fg.Cols(6).Visible = False : Fg.Cols(7).Visible = False

                Fg.Cols(9).Visible = False : Fg.Cols(10).Visible = False : Fg.Cols(11).Visible = False : Fg.Cols(12).Visible = False
                Fg.Cols(14).Visible = False : Fg.Cols(16).Visible = False

                Fg.Cols(5).Width = 0 : Fg.Cols(10).Width = 200 : Fg.Cols(14).Width = 200 : Fg.Cols(12).Width = 120 : Fg.Cols(16).Width = 120

                ReDim aDATA(0, 0)
                aDATA(0, 0) = ""

                For j = 1 To Fg.Cols.Count - 1
                    Fg(0, j) = j & " " & Fg(0, j)
                    If Fg.Cols(j).IsVisible Then
                        Ancho += Fg.Cols(j).Width
                    End If
                Next
                Me.Width = Ancho - 150
                Me.CenterToScreen()
                Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
            End If

        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub

    Private Sub FrmSelItemTabFlores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click
        Dim z As Integer = 0
        Try

            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Fg(k, 1) Then
                        z += 1
                    End If
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            Fg.FinishEditing()

            ReDim aDATA(z, 3)
            z = 0
            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Fg(k, 1) Then
                        aDATA(z, 0) = Fg(k, 4) 'CVE_VIAJE
                        aDATA(z, 1) = Fg(k, 2) 'CVE_TAB
                        aDATA(z, 2) = Fg(k, 3) 'NCOPIAS
                        z += 1
                    End If
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            If z = 0 Then
                MsgBox("Por favor seleccione al menos un viaje")
                Return
            End If

            Me.Close()
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, 2, state)
        Next
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 3 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If e.Row = 0 AndAlso e.Col = 2 Then
                ChangeState(Fg.GetCellCheck(e.Row, e.Col))
            Else
                If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 2, CheckEnum.Unchecked)
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS()
        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 20

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150


            Fg(0, 1) = "Seleccione"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Boolean)

            Fg(0, 2) = "Clave"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Int32)

            Fg(0, 3) = "Num. copias"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Int32)

            Fg(0, 4) = "Num.viaje"
            Dim cc3 As Column = Fg.Cols(4)
            cc3.DataType = GetType(String)

            Fg(0, 5) = "Folio"
            Dim c4 As Column = Fg.Cols(5)
            c4.DataType = GetType(Int32)

            Fg(0, 6) = "Clave oper."
            Dim c5 As Column = Fg.Cols(6)
            c5.DataType = GetType(Int32)

            Fg(0, 7) = "Nombre operador"
            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(String)

            Fg(0, 8) = "Unidad"
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(String)

            Fg(0, 9) = "Tipo viaje"
            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(String)

            Fg(0, 10) = "Cliente"
            Dim c9 As Column = Fg.Cols(10)
            c9.DataType = GetType(String)

            Fg(0, 11) = "Nombre cliente"
            Dim c10 As Column = Fg.Cols(11)
            c10.DataType = GetType(String)

            Fg(0, 12) = "Cve. origen"
            Dim c11 As Column = Fg.Cols(12)
            c11.DataType = GetType(Int32)

            Fg(0, 13) = "Descripcion origen"
            Dim c12 As Column = Fg.Cols(13)
            c12.DataType = GetType(String)

            Fg(0, 14) = "Cve. destino"
            Dim c13 As Column = Fg.Cols(14)
            c13.DataType = GetType(Int32)

            Fg(0, 15) = "Descripcion destino"
            Dim c14 As Column = Fg.Cols(15)
            c14.DataType = GetType(String)

            Fg(0, 16) = "Cargado/Vacio"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(String)

            Fg(0, 17) = "KMS"
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 18) = "Rendimiento"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 19) = "Litros"
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(Decimal)
            Fg.Cols(18).Format = "###,###,##0.00"

            Fg(0, 20) = "Toneladas"
            Dim c19 As Column = Fg.Cols(20)
            c19.DataType = GetType(Decimal)
            Fg.Cols(19).Format = "###,###,##0.00"

        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            Dim cal1 As Decimal

            If Fg.Row > 0 Then
                If Fg.Col = 3 Then
                    If Not IsDBNull(Fg.Editor.Text) Then
                        If Not IsNothing(Fg.Editor.Text) Then
                            If IsNumeric(Fg.Editor.Text) Then
                                cal1 = CDec(Fg.Editor.Text) - CInt(Fg.Editor.Text)
                                If cal1 > 0 Then
                                    If cal1 <> 0.5 Then
                                        e.Cancel = True
                                        MsgBox("Valor incorrecto")
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
