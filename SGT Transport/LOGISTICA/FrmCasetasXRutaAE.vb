Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmCasetasXRutaAE
    Private Sub FrmCasetasXRutaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim s As String, j As Integer

            Me.KeyPreview = True
            barMenu.BackColor = Color.FromArgb(164, 177, 202)

            Fg.Rows.Count = 1
            Fg.Redraw = False
            Fg.BeginUpdate()


            BtnPlaza.FlatStyle = FlatStyle.Flat
            BtnPlaza.FlatAppearance.BorderSize = 0
            BtnCLAVE_REM.FlatStyle = FlatStyle.Flat
            BtnCLAVE_REM.FlatAppearance.BorderSize = 0
            BtnPlaza2.FlatStyle = FlatStyle.Flat
            BtnPlaza2.FlatAppearance.BorderSize = 0
            BtnRuta.FlatStyle = FlatStyle.Flat
            BtnRuta.FlatAppearance.BorderSize = 0


            Fg.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)

            cboEjesTotal.Items.Clear()
            cboEjesTotal.Items.Add("3")
            cboEjesTotal.Items.Add("5")
            cboEjesTotal.Items.Add("9")
            cboEjesTotal.SelectedIndex = 0

            Fg.Cols(2).AllowSorting = True
            Fg.Cols(2).Sort = SortFlags.Ascending
            Fg.Sort(C1.Win.C1FlexGrid.SortFlags.UseColSort, 2, 2)

            Me.Left = 5
            Me.Width = Screen.PrimaryScreen.Bounds.Width - 5
            Fg.Width = Me.Width - 10
            Fg.Rows(0).Height = 40


            Fg.Cols(8).Visible = False
            Fg.Cols(9).Visible = False
            Fg.Cols(10).Visible = False

            Fg.Cols(14).Visible = False
            Fg.Cols(15).Visible = False
            Fg.Cols(16).Visible = False

            'Fg.Cols(17).Visible = False
            'Fg.Cols(18).Visible = False
            'Fg.Cols(19).Visible = False

            Fg.Cols(20).Visible = False
            Fg.Cols(21).Visible = False
            Fg.Cols(22).Visible = False

            Fg.Cols(23).Visible = False
            Fg.Cols(24).Visible = False
            Fg.Cols(25).Visible = False

            Fg.Cols(26).Visible = False
            Fg.Cols(27).Visible = False
            Fg.Cols(28).Visible = False


            Fg.Cols(2).Width = 60
            Fg.Cols(3).Width = 60
            Fg.Cols(4).Width = 300

            Fg.Cols(5).Width = 95
            Fg.Cols(6).Width = 60
            Fg.Cols(7).Width = 60

            Fg.Cols(8).Width = 85
            Fg.Cols(9).Width = 85
            Fg.Cols(11).Width = 65
            Fg.Cols(12).Width = 65
            Fg.Cols(13).Width = 60
            Fg.Cols(14).Width = 65
            Fg.Cols(15).Width = 65
            Fg.Cols(17).Width = 75
            Fg.Cols(18).Width = 75
            Fg.Cols(20).Width = 65
            Fg.Cols(21).Width = 65

            Fg.Cols(23).Width = 65
            Fg.Cols(24).Width = 65
            Fg.Cols(26).Width = 65
            Fg.Cols(27).Width = 65
            Fg.Cols(29).Width = 75
            Fg.Cols(30).Width = 75
            Fg.Cols(30).Width = 65


            Fg.Cols(32).Width = 0
            Fg.Cols(33).Width = 0

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_CAS, DESCR, CVE_PLAZA, CASE WHEN C.TIPO_PAGO = 'M' THEN 'Multitag' ELSE 'Efectivo' END AS TIPOPAGO, ISNULL(IMPORTE,0) AS T1,
                    ISNULL(IMPORTE2,0) AS T2,ISNULL(IMPORTE3,0) AS T3, ISNULL(IMPORTE4,0) AS T4, ISNULL(IMPORTE5,0) AS T5, ISNULL(IMPORTE6,0) AS T6,
                    ISNULL(IMPORTE7,0) AS T7, ISNULL(IMPORTE8,0) AS T8, CLAVE_OP, IAVE, ISNULL(CRUCE,1) AS CRUZE
                    FROM GCCASETAS C
                    WHERE C.STATUS = 'A' "

                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        s = "" & vbTab '1
                        s &= 0 & vbTab '1
                        s &= dr("CVE_CAS") & vbTab '2
                        s &= dr("DESCR") & vbTab '3
                        s &= dr("TIPOPAGO") & vbTab '4
                        s &= dr("CVE_PLAZA") & vbTab '5
                        s &= dr("CRUZE") & vbTab '6

                        s &= IIf(dr("T1") > 0, dr("T1") / dr("CRUZE"), 0) & vbTab '7
                        s &= dr("T1") & vbTab '8
                        s &= 0 & vbTab '9
                        s &= IIf(dr("T2") > 0, dr("T2") / dr("CRUZE"), 0) / dr("CRUZE") & vbTab '10
                        s &= dr("T2") & vbTab '11
                        s &= 0 & vbTab '12
                        s &= IIf(dr("T3") > 0, dr("T3") / dr("CRUZE"), 0) / dr("CRUZE") & vbTab '13
                        s &= dr("T3") & vbTab '14
                        s &= False & vbTab '15
                        s &= IIf(dr("T4") > 0, dr("T4") / dr("CRUZE"), 0) / dr("CRUZE") & vbTab '16
                        s &= dr("T4") & vbTab '17
                        s &= False & vbTab '18
                        s &= IIf(dr("T5") > 0, dr("T5") / dr("CRUZE"), 0) / dr("CRUZE") & vbTab '19
                        s &= dr("T5") & vbTab '20
                        s &= False & vbTab '21 
                        s &= IIf(dr("T6") > 0, dr("T6") / dr("CRUZE"), 0) / dr("CRUZE") & vbTab '22
                        s &= dr("T6") & vbTab '23
                        s &= False & vbTab '24
                        s &= IIf(dr("T7") > 0, dr("T7") / dr("CRUZE"), 0) / dr("CRUZE") & vbTab '25
                        s &= dr("T7") & vbTab '26
                        s &= False & vbTab '27
                        s &= IIf(dr("T8") > 0, dr("T8") / dr("CRUZE"), 0) / dr("CRUZE") & vbTab '28


                        s &= dr("T8") & vbTab '29
                        s &= False & vbTab '30
                        s &= dr("CLAVE_OP") & vbTab '31
                        s &= dr("IAVE") '32

                        j += 1
                        'Lt1.Text = j


                        Fg.AddItem("" & vbTab & s)
                        ' & vbTab & dr("NOMBRE") & vbTab & dr("IAVE")
                    End While
                    'Fg.AutoSizeCols()
                End Using
            End Using
            Fg.Redraw = True
            Fg.EndUpdate()

        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        txRuta.Text = ""
        txDescripcion.Text = ""
        tCVE_PLAZA.Tag = ""
        tCVE_PLAZA2.Tag = ""
        LtPlaza.Tag = ""
        LtPlaza2.Tag = ""
        rbTractor.Checked = True
        rbSencillo.Checked = False
        rbFull.Checked = False

        If Var1 = "Nuevo" Then
            Try
                TCVE_CXR.Text = GET_MAX("GCCASETAS_X_RUTA", "CVE_CXR")
                TCVE_CXR.Enabled = False
                'tCVE_PLAZA.Text = ""
                'tCVE_PLAZA.Select()
                txRuta.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT C.CVE_CXR, C.STATUS, C.CVE_PLAZA, C.CVE_PLAZA2, ISNULL(C.CVE_TAB, 0) AS CVE_TAB, ISNULL(C.TIPO_UNIDAD, 0) AS TIPO_UNIDAD, ISNULL(R.DESCR, '') AS DES, ISNULL(R.DESCR2, '') AS DES2, 
                    ISNULL(C.DESCR, '') AS DESCR, ISNULL(IMPORTE_CASETAS,0) AS IMPORTE, C.CLAVE_OP, C.IAVE, OP.NOMBRE, C.COL_IMPORTE, C.ORIGEN, C.DESTINO
                    FROM GCCASETAS_X_RUTA C 
                    LEFT JOIN GCCLIE_OP OP On OP.CLAVE = C.CLAVE_OP
					LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_TAB = C.CVE_TAB
                    WHERE CVE_CXR = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TCVE_CXR.Text = dr("CVE_CXR")

                    'If dr.ReadNullAsEmptyInteger("CVE_PLAZA") = 0 Then
                    '    tCVE_PLAZA.Text = ""
                    'Else
                    '    tCVE_PLAZA.Text = dr.ReadNullAsEmptyString("CVE_PLAZA")
                    '    tCVE_PLAZA.Tag = dr.ReadNullAsEmptyString("ST_PLAZA")
                    'End If
                    'If dr.ReadNullAsEmptyInteger("CVE_PLAZA2") = 0 Then
                    '    tCVE_PLAZA2.Text = ""
                    'Else
                    '    tCVE_PLAZA2.Text = dr.ReadNullAsEmptyString("CVE_PLAZA2")
                    '    tCVE_PLAZA2.Tag = dr.ReadNullAsEmptyString("ST_PLAZA2")
                    'End If

                    If dr.ReadNullAsEmptyString("CVE_TAB").Equals("0") Then
                        txRuta.Text = ""
                    Else
                        txRuta.Text = dr.ReadNullAsEmptyString("CVE_TAB")
                    End If

                    txDescripcion.Text = dr.ReadNullAsEmptyString("DESCR")

                    LtPlaza.Text = dr.ReadNullAsEmptyString("DES")
                    LtPlaza2.Text = dr.ReadNullAsEmptyString("DES2")

                    LtImporte.Text = Format(dr("IMPORTE"), "###,###,##0.00")

                    tCLAVE_O.Text = dr.ReadNullAsEmptyString("CLAVE_OP")
                    LtNombre1.Text = dr.ReadNullAsEmptyString("NOMBRE")

                    TIAVE.Text = dr.ReadNullAsEmptyString("ORIGEN")
                    TTIPO_RUTA.Text = dr.ReadNullAsEmptyString("DESTINO")


                    Select Case dr.ReadNullAsEmptyString("TIPO_UNIDAD")
                        Case "1"
                            rbTractor.Checked = True
                        Case "2"
                            rbSencillo.Checked = True
                        Case "3"
                            rbFull.Checked = True
                    End Select

                    Select Case dr.ReadNullAsEmptyString("COL_IMPORTE")
                        Case 3
                            cboEjesTotal.SelectedIndex = 0
                        Case 5
                            cboEjesTotal.SelectedIndex = 1
                        Case 9
                            cboEjesTotal.SelectedIndex = 2
                    End Select



                End If
                dr.Close()

                DESPLEGAR_PAR()

                CalculaTotales()
                TCVE_CXR.Enabled = False
                txRuta.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

        Me.CenterToScreen()
        Me.SplitContainer1.Panel1MinSize = 30
        Me.SplitContainer1.Panel2MinSize = 70


        If PASS_GRUPOCE = "BUS" Then
            For k = 1 To Fg.Cols.Count - 1
                Fg(0, k) = k & "." & Fg(0, k)
            Next
        End If

    End Sub
    Sub DESPLEGAR_PAR()
        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Yellow

        Fg.Redraw = False
        Fg.BeginUpdate()

        Try
            Dim SUMA As Decimal = 0, EJE As Integer, z As Integer

            If IsNumeric(TCVE_CXR.Text) Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_CXR, CVE_CAS, ISNULL(CRUCE,0) AS CRUZE, EJE2, IMPORTE2, EJE3, IMPORTE3, EJE4, IMPORTE4, EJE5, IMPORTE5, EJE6, IMPORTE6, EJE7, IMPORTE7, EJE8, IMPORTE8, EJE9, IMPORTE9, ORDEN
                        FROM GCCASETAS_X_RUTA_PAR 
                        WHERE CVE_CXR =  " & CInt(TCVE_CXR.Text) & " ORDER BY ORDEN"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            For row As Integer = 1 To Fg.Rows.Count - 1
                                z = 0
                                If Fg(row, 3) = dr("CVE_CAS") Then
                                    Fg(row, 1) = True
                                    Fg(row, 2) = dr("ORDEN")
                                    Fg(row, 7) = dr.ReadNullAsEmptyInteger("CRUZE")
                                    EJE = dr("EJE2")
                                    If dr("EJE2") Then
                                        Fg(row, 10) = True
                                        SUMA += Fg(row, 9)
                                        Fg(row, 9) = dr("IMPORTE2") * dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg(row, 8) = dr("IMPORTE2")
                                        Fg.SetCellStyle(row, 9, NewStyle1)
                                        Fg.SetCellStyle(row, 10, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE3") Then
                                        Fg(row, 13) = True
                                        SUMA += Fg(row, 12)
                                        Fg(row, 12) = dr("IMPORTE3") * dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg(row, 11) = dr("IMPORTE3")
                                        Fg.SetCellStyle(row, 12, NewStyle1)
                                        Fg.SetCellStyle(row, 13, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE4") Then
                                        Fg(row, 16) = True
                                        SUMA += Fg(row, 15)
                                        Fg(row, 15) = dr("IMPORTE4") * dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg(row, 14) = dr("IMPORTE4")
                                        Fg.SetCellStyle(row, 15, NewStyle1)
                                        Fg.SetCellStyle(row, 16, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE5") Then
                                        Fg(row, 19) = True
                                        SUMA += Fg(row, 18)
                                        Fg(row, 18) = dr("IMPORTE5") * dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg(row, 17) = dr("IMPORTE5")
                                        Fg.SetCellStyle(row, 18, NewStyle1)
                                        Fg.SetCellStyle(row, 19, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE6") Then
                                        Fg(row, 22) = True
                                        SUMA += Fg(row, 21)
                                        Fg(row, 21) = dr("IMPORTE6") * dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg(row, 20) = dr("IMPORTE6")
                                        Fg.SetCellStyle(row, 21, NewStyle1)
                                        Fg.SetCellStyle(row, 22, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE7") Then
                                        Fg(row, 25) = True
                                        SUMA += Fg(row, 24)
                                        Fg(row, 24) = dr("IMPORTE7") * dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg(row, 23) = dr("IMPORTE7")
                                        Fg.SetCellStyle(row, 24, NewStyle1)
                                        Fg.SetCellStyle(row, 25, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE8") Then
                                        Fg(row, 28) = True
                                        SUMA += Fg(row, 27)
                                        Fg(row, 27) = dr("IMPORTE8") * dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg(row, 26) = dr("IMPORTE8")
                                        Fg.SetCellStyle(row, 26, NewStyle1)
                                        Fg.SetCellStyle(row, 27, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE9") Then
                                        Fg(row, 31) = True
                                        Fg(row, 30) = dr("IMPORTE9") * dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg(row, 29) = dr("IMPORTE9")
                                        SUMA += Fg(row, 30)
                                        Fg.SetCellStyle(row, 29, NewStyle1)
                                        Fg.SetCellStyle(row, 30, NewStyle1)
                                        z += 1
                                    End If

                                    If z > 0 Then
                                        Fg.SetCellStyle(row, 0, NewStyle1)
                                    End If
                                End If
                            Next
                        End While

                        For row As Integer = Fg.Rows.Count - 1 To 1 Step -1
                            If Fg(row, 1) = False Then
                                Fg.RemoveItem(row)
                            End If
                        Next

                        LtImporte.Text = Format(SUMA, "###,###,##0.00")
                    End Using
                End Using

                Fg.Cols(2).Sort = SortFlags.Ascending
                Fg.Sort(C1.Win.C1FlexGrid.SortFlags.UseColSort, 2, 2)

            End If
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Fg.EndUpdate()

    End Sub
    Private Sub FrmCasetasXRutaAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub btnPlaza_Click(sender As Object, e As EventArgs) Handles BtnPlaza.Click
        'Try
        '    Var2 = "Plazas"
        '    Var4 = "" : Var5 = "" : Var6 = ""
        '    FrmSelItem2.ShowDialog()
        '    If Var4.Trim.Length > 0 Then
        '        tCVE_PLAZA.Text = Var4
        '        LtPlaza.Text = Var5
        '        Var2 = "" : Var4 = "" : Var5 = ""
        '        tCVE_PLAZA2.Focus()
        '    End If
        'Catch ex As Exception
        '    Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
        '    MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        'End Try
    End Sub
    Private Sub tCVE_PLAZA_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA.KeyDown
        'If e.KeyCode = Keys.F2 Then
        '    btnPlaza_Click(Nothing, Nothing)
        '    Return
        'End If
    End Sub

    Private Sub tCVE_PLAZA_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA.Validated
        '    Try
        '        If tCVE_PLAZA.Text.Trim.Length > 0 Then
        '            Dim DESCR As String
        '            DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA.Text)
        '            If DESCR <> "" Then
        '                LtPlaza.Text = DESCR
        '                'tCVE_PLAZA2.Focus()
        '            Else
        '                If tCVE_PLAZA.Tag <> "B" And tCVE_PLAZA.Text <> LtPlaza.Tag Then
        '                    MessageBox.Show("Plaza inexistente")
        '                    tCVE_PLAZA.Focus()
        '                    tCVE_PLAZA.Text = ""
        '                    LtPlaza.Text = ""
        '                End If
        '            End If
        '        Else
        '            LtPlaza.Text = ""
        '        End If
        '    Catch ex As Exception
        '        Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        '        MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        '    End Try
    End Sub
    Private Sub btnPlaza2_Click(sender As Object, e As EventArgs) Handles BtnPlaza2.Click
        'Try
        '    Var2 = "Plazas"
        '    Var4 = "" : Var5 = "" : Var6 = ""
        '    FrmSelItem2.ShowDialog()
        '    If Var4.Trim.Length > 0 Then
        '        tCVE_PLAZA2.Text = Var4
        '        LtPlaza2.Text = Var5
        '        Var2 = "" : Var4 = "" : Var5 = ""
        '        tCLAVE_O.Focus()
        '    End If
        'Catch ex As Exception
        '    Bitacora("588. " & ex.Message & vbNewLine & ex.StackTrace)
        '    MsgBox("588. " & ex.Message & vbNewLine & ex.StackTrace)
        'End Try
    End Sub
    Private Sub tCVE_PLAZA2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA2.KeyDown
        'If e.KeyCode = Keys.F2 Then
        '    btnPlaza2_Click(Nothing, Nothing)
        '    Return
        'End If
    End Sub
    Private Sub tCVE_PLAZA2_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA2.Validated
        'Try
        '    If tCVE_PLAZA2.Text.Trim.Length > 0 Then
        '        Dim DESCR As String
        '        DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA2.Text)
        '        If DESCR <> "" Then
        '            LtPlaza2.Text = DESCR
        '            'tCLAVE_O.Focus()
        '        Else
        '            If tCVE_PLAZA2.Tag <> "B" And tCVE_PLAZA2.Text <> LtPlaza2.Tag Then
        '                MessageBox.Show("Plaza inexistente")
        '                tCVE_PLAZA2.Focus()
        '                tCVE_PLAZA2.Text = ""
        '                LtPlaza2.Text = ""
        '            End If
        '        End If
        '    Else
        '        LtPlaza2.Text = ""
        '    End If
        'Catch ex As Exception
        '    Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        '    MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        'End Try
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim IMPORTE As Decimal = 0, NUM_PAR As Integer = 0
        Dim cmd As New SqlCommand

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        cmd.Connection = cnSAE

        CalculaTotales()

        Try
            If IsNumeric(LtImporte.Text.Replace(",", "")) Then
                IMPORTE = LtImporte.Text.Replace(",", "")
            Else
                IMPORTE = 0
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Dim TipoUnidad As Integer
        If rbTractor.Checked Then
            TipoUnidad = 1
        ElseIf rbSencillo.Checked Then
            TipoUnidad = 2
        ElseIf rbFull.Checked Then
            TipoUnidad = 3
        End If

        SQL = "UPDATE GCCASETAS_X_RUTA SET IMPORTE_CASETAS = @IMPORTE_CASETAS, 
            CLAVE_OP = @CLAVE_OP, IAVE = @IAVE, CVE_TAB = @CVE_TAB, TIPO_UNIDAD = @TIPO_UNIDAD, DESCR = @DESCR, COL_IMPORTE = @COL_IMPORTE,
            ORIGEN = @ORIGEN, DESTINO = @DESTINO    
            WHERE CVE_CXR = @CVE_CXR
            IF @@ROWCOUNT = 0
            INSERT INTO GCCASETAS_X_RUTA (CVE_CXR, STATUS, IMPORTE_CASETAS, CLAVE_OP, IAVE, UUID, CVE_TAB, TIPO_UNIDAD, DESCR, COL_IMPORTE, ORIGEN, DESTINO) 
            VALUES (
            @CVE_CXR, 'A', @IMPORTE_CASETAS, @CLAVE_OP, @IAVE, NEWID(), @CVE_TAB, @TIPO_UNIDAD, @DESCR, @COL_IMPORTE, @ORIGEN, @DESTINO)"
        cmd.CommandText = SQL
        Try
            Dim colImporte As Integer

            Select Case cboEjesTotal.SelectedIndex
                Case 0
                    colImporte = 3
                Case 1
                    colImporte = 5
                Case 2
                    colImporte = 9
            End Select

            NUM_PAR += 1

            cmd.Parameters.Add("@CVE_CXR", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_CXR.Text)
            cmd.Parameters.Add("@CVE_PLAZA", SqlDbType.Int).Value = NUM_PAR
            'cmd.Parameters.Add("@CVE_PLAZA2", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_PLAZA2.Text)
            cmd.Parameters.Add("@IMPORTE_CASETAS", SqlDbType.Int).Value = IMPORTE
            cmd.Parameters.Add("@CLAVE_OP", SqlDbType.VarChar).Value = tCLAVE_O.Text
            cmd.Parameters.Add("@IAVE", SqlDbType.VarChar).Value = TIAVE.Text
            cmd.Parameters.Add("@ORIGEN", SqlDbType.VarChar).Value = TIAVE.Text
            cmd.Parameters.Add("@DESTINO", SqlDbType.VarChar).Value = TTIPO_RUTA.Text

            cmd.Parameters.Add("@CVE_TAB", SqlDbType.VarChar).Value = txRuta.Text
            cmd.Parameters.Add("@TIPO_UNIDAD", SqlDbType.TinyInt).Value = TipoUnidad
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = txDescripcion.Text
            cmd.Parameters.Add("@COL_IMPORTE", SqlDbType.TinyInt).Value = colImporte

            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                    GRABAR_GASOLINERAS()
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_GASOLINERAS()
        Dim s As String = ""

        Try
            SQL = "DELETE FROM GCCASETAS_X_RUTA_PAR WHERE CVE_CXR = '" & TCVE_CXR.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using

            For row As Integer = 1 To Fg.Rows.Count - 1

                If Fg(row, 1) Then
                    'CONSTRAINT PK_GCCASETAS_X_RUTA_PAR PRIMARY KEY CLUSTERED (CVE_CXR, CVE_CAS)
                    '                                                                 10      9     13      12      16       15     19      18       22       21     25      24      28      27      31       30
                    s = "INSERT INTO GCCASETAS_X_RUTA_PAR (CVE_CXR, CVE_CAS, CRUCE, EJE2, IMPORTE2, EJE3, IMPORTE3, EJE4, IMPORTE4, EJE5, IMPORTE5, EJE6, IMPORTE6, EJE7, IMPORTE7, EJE8, IMPORTE8, EJE9, IMPORTE9, "
                    '                                                                                                  EJE2                   IMPORTE                EJE3                IMPORTE                 EJE4      
                    s &= "ORDEN, UUID) VALUES('" & TCVE_CXR.Text & "','" & Fg(row, 3) & "','" & Fg(row, 7) & "','" & Fg(row, 10) & "','" & Fg(row, 9) & "','" & Fg(row, 13) & "','" & Fg(row, 12) & "','" & Fg(row, 16) & "','"
                    '     IMPORTE                  EJE5                IMPORTE                EJE6                   IMPORTE               EJE7                IMPORTE  
                    s &= Fg(row, 15) & "','" & Fg(row, 19) & "','" & Fg(row, 18) & "','" & Fg(row, 22) & "','" & Fg(row, 21) & "','" & Fg(row, 25) & "','" & Fg(row, 24) & "','"
                    '        EJE8                  IMPORTE               EJE9                 IMPORTE               ORDEN 
                    s &= Fg(row, 28) & "','" & Fg(row, 27) & "','" & Fg(row, 31) & "','" & Fg(row, 30) & "','" & Fg(row, 2) & "',NEWID())"

                    SQL = s

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                    End Using

                End If
            Next
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked

        Try
            If e.Row = 0 Then
                ChangeState(Fg.GetCellCheck(e.Row, e.Col))
                ChangeState(Fg.GetCellCheck(e.Row, 10))
                ChangeState(Fg.GetCellCheck(e.Row, 13))
                ChangeState(Fg.GetCellCheck(e.Row, 16))
                ChangeState(Fg.GetCellCheck(e.Row, 19))
                ChangeState(Fg.GetCellCheck(e.Row, 22))
                ChangeState(Fg.GetCellCheck(e.Row, 15))
                ChangeState(Fg.GetCellCheck(e.Row, 28))
                ChangeState(Fg.GetCellCheck(e.Row, 31))
            Else
                'If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        CalculaTotales()
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum, Optional fcol As Integer = 1)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, fcol, state)
        Next
    End Sub

    Private Sub CalculaTotales()
        Try
            Dim SUMA As Decimal = 0
            Dim colImporte As Integer = 0

            Select Case cboEjesTotal.SelectedIndex
                Case 0
                    colImporte = 3
                Case 1
                    colImporte = 5
                Case 2
                    colImporte = 9
            End Select

            Fg.FinishEditing()
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) Then
                    If Fg(k, 12) And colImporte = 3 Then SUMA += Fg(k, 12) '* Fg(k, 6)
                    If Fg(k, 18) And colImporte = 5 Then SUMA += Fg(k, 18) '* Fg(k, 6)
                    If Fg(k, 30) And colImporte = 9 Then SUMA += Fg(k, 30) '* Fg(k, 6)
                End If
            Next
            LtImporte.Text = Format(SUMA, "###,###,##0.00")
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnCLAVE_REM_Click(sender As Object, e As EventArgs) Handles BtnCLAVE_REM.Click
        Try
            Var2 = "Cliente operativo" '       GCCLIE_OP
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                tCLAVE_O.Text = Var4
                LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TIAVE.Focus()
            End If
        Catch ex As Exception
            Bitacora("58. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("58. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCLAVE_O_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLAVE_O.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnCLAVE_REM_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCLAVE_O_Validated(sender As Object, e As EventArgs) Handles tCLAVE_O.Validated
        Try
            If tCLAVE_O.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Cliente operativo", tCLAVE_O.Text, False)
                If DESCR.Trim.Length > 0 Then
                    LtNombre1.Text = DESCR
                    'TIAVE.Focus()
                Else
                    MsgBox("Cliente operativo inexistente")
                    LtNombre1.Text = ""
                End If
            Else
                LtNombre1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TIAVE_KeyDown(sender As Object, e As KeyEventArgs) Handles TIAVE.KeyDown
        If e.KeyCode = 13 Then
            Fg.Focus()
        End If
    End Sub
    Private Sub TIAVE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TIAVE.PreviewKeyDown
        If e.KeyCode = 9 Then
            Fg.Select()
            Fg.Focus()
        End If
    End Sub

    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            Dim SUMA As Decimal = 0, SUMA_EJE As Decimal = 0
            Dim colImporte As Integer = 0

            Select Case cboEjesTotal.SelectedIndex
                Case 0
                    colImporte = 3
                Case 1
                    colImporte = 5
                Case 2
                    colImporte = 9
            End Select

            If Fg.Row > 0 Then
                If Fg.Col = 7 And (colImporte = 3 Or colImporte = 5 Or colImporte = 9) Then
                    For k = 1 To Fg.Rows.Count - 1
                        If k <> Fg.Row Then
                            If Fg(k, 1) Then
                                If Fg(k, 9) And colImporte = 2 Then SUMA += Fg(k, 8) * Fg(k, 7)
                                If Fg(k, 12) And colImporte = 3 Then SUMA += Fg(k, 11) * Fg(k, 7)
                                If Fg(k, 18) And colImporte = 4 Then SUMA += Fg(k, 17) * Fg(k, 7)
                                If Fg(k, 21) And colImporte = 6 Then SUMA += Fg(k, 20) * Fg(k, 7)
                                If Fg(k, 24) And colImporte = 7 Then SUMA += Fg(k, 23) * Fg(k, 7)
                                If Fg(k, 27) And colImporte = 8 Then SUMA += Fg(k, 26) * Fg(k, 7)
                                If Fg(k, 30) And colImporte = 9 Then SUMA += Fg(k, 29) * Fg(k, 7)
                            End If
                        End If
                    Next
                    If IsNumeric(Fg.Editor.Text) Then
                        Fg(Fg.Row, 9) = Fg(Fg.Row, 8) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 12) = Fg(Fg.Row, 11) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 18) = Fg(Fg.Row, 17) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 21) = Fg(Fg.Row, 20) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 24) = Fg(Fg.Row, 23) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 27) = Fg(Fg.Row, 26) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 30) = Fg(Fg.Row, 29) * CDec(Fg.Editor.Text)


                        If Fg(Fg.Row, 9) And colImporte = 2 Then SUMA += Fg(Fg.Row, 8) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 12) And colImporte = 3 Then SUMA += Fg(Fg.Row, 11) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 18) And colImporte = 4 Then SUMA += Fg(Fg.Row, 17) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 21) And colImporte = 5 Then SUMA += Fg(Fg.Row, 20) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 24) And colImporte = 7 Then SUMA += Fg(Fg.Row, 23) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 27) And colImporte = 8 Then SUMA += Fg(Fg.Row, 26) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 30) And colImporte = 9 Then SUMA += Fg(Fg.Row, 29) * CDec(Fg.Editor.Text)

                    End If

                    LtImporte.Text = Format(SUMA, "###,###,##0.00")
                End If

            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnRuta_Click(sender As Object, e As EventArgs) Handles BtnRuta.Click
        Try
            Var2 = "RUTAS FLORES"
            Var4 = "" : Var5 = "" : Var6 = "" : Var10 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                txRuta.Text = Var4
                txRuta.Tag = Var4
                LtPlaza.Text = Var7
                LtPlaza2.Text = Var8
                Var2 = "" : Var4 = "" : Var5 = ""

            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub txRuta_KeyDown(sender As Object, e As KeyEventArgs) Handles txRuta.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnRuta_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub txRuta_Validated(sender As Object, e As EventArgs) Handles txRuta.Validated
        Try

            If txRuta.Text = "" Then
                LtPlaza.Text = ""
                LtPlaza2.Text = ""
                Return
            End If

            SQL = "SELECT T.*, ISNULL(T.DESCR,'') AS DES, ISNULL(T.DESCR2,'') AS DES2, ISNULL(T.DESCR,'') AS DESCR_RUTA
                FROM GCTAB_RUTAS_F T                 
                WHERE T.CVE_TAB = '" & txRuta.Text & "'"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        'LtNombreRuta.Text = dr("DESCR_RUTA")
                        LtPlaza.Text = dr("DES")
                        LtPlaza2.Text = dr("DES2")
                    Else
                        txRuta.Text = ""
                        LtPlaza.Text = ""
                        LtPlaza2.Text = ""
                    End If
                End Using
            End Using

        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnRecargarCasetas_Click(sender As Object, e As EventArgs) Handles BtnRecargarCasetas.Click
        Try
            Dim s As String
            Dim STATUS As Boolean
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_CAS, DESCR, CVE_PLAZA, CASE WHEN C.TIPO_PAGO = 'M' THEN 'Multitag' ELSE 'Efectivo' END AS TIPOPAGO, ISNULL(IMPORTE,0) AS T1,
                    ISNULL(IMPORTE2,0) AS T2,ISNULL(IMPORTE3,0) AS T3, ISNULL(IMPORTE4,0) AS T4, ISNULL(IMPORTE5,0) AS T5, ISNULL(IMPORTE6,0) AS T6,
                    ISNULL(IMPORTE7,0) AS T7, ISNULL(IMPORTE8,0) AS T8, CLAVE_OP, IAVE, ISNULL(CRUCE,1) AS CRUZE
                    FROM GCCASETAS C
                    WHERE C.STATUS = 'A'"

                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        STATUS = True

                        For k = 1 To Fg.Rows.Count - 1
                            If Fg(k, 3) = dr("CVE_CAS") Then
                                STATUS = False
                                Exit For
                            End If
                        Next


                        If STATUS Then

                            s = "" & vbTab '1
                            s &= dr("CVE_PLAZA") & vbTab '2
                            s &= dr("CVE_CAS") & vbTab '3
                            s &= dr("DESCR") & vbTab '4
                            s &= dr("TIPOPAGO") & vbTab '5
                            s &= dr("CVE_PLAZA") & vbTab '6
                            s &= dr("CRUZE") & vbTab '7
                            s &= dr("T1") / dr("CRUZE") & vbTab '8
                            s &= dr("T1") & vbTab '9
                            s &= False & vbTab '10
                            s &= dr("T2") / dr("CRUZE") & vbTab '11
                            s &= dr("T2") & vbTab '12
                            s &= False & vbTab '13
                            s &= dr("T3") / dr("CRUZE") & vbTab '14
                            s &= dr("T3") & vbTab '15
                            s &= False & vbTab '16
                            s &= dr("T4") / dr("CRUZE") & vbTab '17
                            s &= dr("T4") & vbTab '18
                            s &= False & vbTab '19
                            s &= dr("T5") / dr("CRUZE") & vbTab '20
                            s &= dr("T5") & vbTab '21
                            s &= False & vbTab '22 
                            s &= dr("T6") / dr("CRUZE") & vbTab '23
                            s &= dr("T6") & vbTab '24
                            s &= False & vbTab '25
                            s &= dr("T7") / dr("CRUZE") & vbTab '26
                            s &= dr("T7") & vbTab '27
                            s &= False & vbTab '28
                            s &= dr("T8") / dr("CRUZE") & vbTab '29
                            s &= dr("T8") & vbTab '30
                            s &= False & vbTab '31
                            s &= dr("CLAVE_OP") & vbTab '32
                            s &= dr("IAVE") '33

                            Fg.AddItem("" & vbTab & s)
                            ' & vbTab & dr("NOMBRE") & vbTab & dr("IAVE")
                        End If
                    End While
                    'Fg.AutoSizeCols()
                End Using
            End Using
            Fg.Redraw = True
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_RowColChange(sender As Object, e As EventArgs) Handles Fg.RowColChange

    End Sub

    Private Sub Fg_RowValidated(sender As Object, e As RowColEventArgs) Handles Fg.RowValidated
        CalculaTotales()
    End Sub

    Private Sub cboEjesTotal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEjesTotal.SelectedIndexChanged
        CalculaTotales()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Casetas por ruta")
    End Sub
End Class
