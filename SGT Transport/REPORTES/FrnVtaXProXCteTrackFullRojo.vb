Imports System.IO
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Command
Public Class FrnVtaXProXCteTrackFullRojo

    Private SUMA_VIAJES_ESP1 As Decimal = 0
    Private SUMA_VIAJES_ESP2 As Decimal = 0
    Private SUMA_VIAJES_ESP3 As Decimal = 0
    Private SUMA_VIAJES_ESP4 As Decimal = 0

    Private SUMA_VIAJES_ESPF1 As Decimal = 0
    Private SUMA_VIAJES_ESPF2 As Decimal = 0
    Private SUMA_VIAJES_ESPF3 As Decimal = 0
    Private SUMA_VIAJES_ESPF4 As Decimal = 0


    Private Sub FrnVtaXProXCteTrackFullRojo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            'Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            'Fg.Styles("Alternate").BackColor = Color.PowderBlue
            'Fg.Styles("Highlight").BackColor = Color.CornflowerBlue
            'Fg.Styles("Focus").BackColor = Color.CornflowerBlue
            'Fg.Styles("Focus").Border.Color = Color.Red
            'Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            'Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double

        Catch ex As Exception
        End Try
        Try
            F1.Value = Date.Today
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            Me.WindowState = FormWindowState.Maximized
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With

            Fg.Rows.Count = 1

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - F1.Top - F1.Height - 50

            Fg.Cols(2).Width = 150

            btnClie.FlatStyle = FlatStyle.Flat
            btnClie.FlatAppearance.BorderSize = 0

            BtnProducto.FlatStyle = FlatStyle.Flat
            BtnProducto.FlatAppearance.BorderSize = 0

            Dim N = DateTime.Now.AddMonths(-1)
            Dim D1 As String, D2 As String

            D1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

            F1.Value = D1
            F2.Value = D2
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrnVtaXProXCteTrackFullRojo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Ventas por producto por cliente")
        Me.Dispose()
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Dim R1 As Decimal = 0, R2 As Decimal = 0, CC1 As Decimal = 0, C2 As Decimal = 0, C3 As Decimal = 0, C4 As Decimal = 0, r_ As Integer = 0
        Dim T1 As Decimal, T2 As Decimal, T3 As Decimal = 0, TS As Integer = 0, TF As Integer = 0, rCte_ As Integer = 0, PESO As Decimal
        Dim SUMA_TON_CLASIFIC As Decimal = 0, SUMA_IMPORTE_CLASIFIC As Decimal = 0, Sigue As Boolean = False
        Dim CADENA As String = "", CLASIF2 As String = "", SUM_SENCILLO As Decimal = 0, SUM_FULL As Decimal = 0
        Dim FECHA_LP As String, UNIDADES As String = "", CADENA_CP As String, CADENA_GCPRODUC As String, CADENA_GCPRODUC2 As String
        Dim d1 As Date = F1.Value
        Dim NMES As Integer, NANO As Integer, CVE_TAB As String

        Me.Cursor = Cursors.WaitCursor

        Fg.Rows.Count = 1
        Fg.Redraw = False
        Fg.Cols(9).Visible = False

        Dim rs As CellStyle
        rs = Fg.Styles.Add("RowColor")
        rs.BackColor = Color.LightSkyBlue

        Dim rs2 As CellStyle
        rs2 = Fg.Styles.Add("ColorCliente")
        rs2.BackColor = Color.Thistle

        If TCLIENTE.Text.Trim.Length > 0 Then
            TCLIENTE.Text = Space(10 - TCLIENTE.Text.Length) & TCLIENTE.Text
            CADENA = " AND P.CLIENTE = '" & TCLIENTE.Text & "'"
        End If
        If TCVE_PROD.Text.Trim.Length > 0 Then
            CADENA_GCPRODUC = " AND CVE_ART = '" & TCVE_PROD.Text & "'"
            CADENA_GCPRODUC2 = " AND I.DESCR = '" & TDESCR.Text & "'"
        Else
            CADENA_GCPRODUC = ""
            CADENA_GCPRODUC2 = ""
        End If

        CC1 = 0 : C2 = 0 : C3 = 0 : C4 = 0

        SUMA_VIAJES_ESPF1 = 0
        SUMA_VIAJES_ESPF2 = 0
        SUMA_VIAJES_ESPF3 = 0
        SUMA_VIAJES_ESPF4 = 0

        SQL = "SELECT P.CLIENTE, MAX(NOMBRE) AS NOMB, ISNULL(CLASIFIC,'') AS CLASIF
            FROM GCCARTA_PORTE P
            LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
            WHERE ISNULL(P.CLIENTE,'') <> '' AND 
            FECHA_REAL_CARGA >= '" & FSQL(F1.Value) & " 00:00:00' AND 
            FECHA_REAL_CARGA <= '" & FSQL(F2.Value) & " 23:59:00' " & CADENA & CADENA_GCPRODUC & " 
            GROUP BY CLIENTE, CLASIFIC ORDER BY CLASIFIC"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If CLASIF2 <> dr("CLASIF") And Sigue Then
                            Sigue = True
                            'If dr("CLIENTE") = "         8" Or dr("CLIENTE") = "        25" Or dr("CLIENTE") = "        82" Then
                            'Sigue = True
                            'End If
                            If SUMA_TON_CLASIFIC > 0 And SUMA_IMPORTE_CLASIFIC > 0 Then
                                Fg.Rows.Insert(Fg.Rows.Count)
                                Fg.Rows.Insert(Fg.Rows.Count)

                                Fg(Fg.Rows.Count - 2, 2) = "1. Total por grupo"
                                Fg(Fg.Rows.Count - 2, 3) = CLASIF2

                                Fg(Fg.Rows.Count - 2, 4) = SUMA_TON_CLASIFIC + SUMA_VIAJES_ESP1
                                Fg(Fg.Rows.Count - 2, 5) = SUMA_IMPORTE_CLASIFIC + SUMA_VIAJES_ESP2
                                Fg(Fg.Rows.Count - 2, 6) = SUM_SENCILLO + SUMA_VIAJES_ESP3
                                Fg(Fg.Rows.Count - 2, 7) = SUM_FULL + SUMA_VIAJES_ESP4

                                Fg(Fg.Rows.Count - 2, 8) = SUM_SENCILLO + SUM_FULL + +SUMA_VIAJES_ESP3 + +SUMA_VIAJES_ESP4

                                Fg(Fg.Rows.Count - 2, 10) = "1"
                                Fg.Rows(Fg.Rows.Count - 2).Style = Fg.Styles("RowColor")
                                T3 += SUM_SENCILLO + SUM_FULL

                                SUMA_VIAJES_ESP1 = 0 : SUMA_VIAJES_ESP2 = 0 : SUMA_VIAJES_ESP3 = 0 : SUMA_VIAJES_ESP4 = 0

                            End If
                            SUMA_TON_CLASIFIC = 0 : SUMA_IMPORTE_CLASIFIC = 0 : SUM_FULL = 0 : SUM_SENCILLO = 0
                        End If
                        Fg.AddItem("" & vbTab & dr("CLIENTE") & " " & dr("NOMB") & vbTab & dr("CLASIF") & vbTab &
                                   "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "1")

                        rCte_ = Fg.Rows.Count - 1
                        Fg.Rows(Fg.Rows.Count - 1).Style = Fg.Styles("ColorCliente")

                        SQL = "SELECT P.CVE_ART, MAX(I.DESCR) AS DES, ISNULL(SUM(PESO_BRUTO3 - TARA3),0) AS PB3,
                            ISNULL(P1.CIUDAD,'') AS ORIGEN, ISNULL(P2.CIUDAD,'') AS DESTINO
                            FROM CFDI F 
                            LEFT JOIN GCCARTA_PORTE P ON F.DOCUMENT = P.CVE_FOLIO AND ISNULL(F.ESTATUS,'A') <> 'C'
                            LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                            LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE = P.CLAVE_O
                            LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C1.CVE_PLAZA
                            LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE = P.CLAVE_D
                            LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = C2.CVE_PLAZA
                            LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                            WHERE ISNULL(ESTATUS,'A') <> 'C' AND 
                            (ISNUMERIC(P.CVE_TAB_VIAJE) = 1 OR P.CVE_TAB_VIAJE = '') AND 
                            P.CLIENTE = '" & dr("CLIENTE") & "' " & CADENA_GCPRODUC2 & "
                            AND FECHA_REAL_CARGA >= '" & FSQL(F1.Value) & " 00:00:00' AND FECHA_REAL_CARGA <= '" & FSQL(F2.Value) & " 23:59:00' 
                            GROUP BY P.CVE_ART, P1.CIUDAD, P2.CIUDAD ORDER BY MAX(CLASIFIC)"
                        SQL1 = SQL
                        CC1 = 0 : C2 = 0 : C3 = 0 : C4 = 0
                        Try
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQL
                                Using dr3 As SqlDataReader = cmd3.ExecuteReader
                                    While dr3.Read

                                        '                                               1
                                        Fg.AddItem("" & vbTab & IIf(dr3("PB3") = 0, "FALSO FLETE", dr3("DES")) & vbTab &
                                                   dr3("ORIGEN") & "-" & dr3("DESTINO") & vbTab & "" & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab &
                                                   0 & vbTab & 0 & vbTab & "1")
                                        '                           2                             3            4           5           6           7
                                        '         UNIDAD    TONELADAS     IMPORTE   SENCILLO       FULL       RUTAS
                                        r_ = Fg.Rows.Count - 1
                                        SQL = "SELECT P.CLIENTE, F.SUBTOTAL, F.IVA, F.RETENCION, F.IMPORTE, F.SUBTOTAL AS SUBTOT, F.DOCUMENT, 
                                            (CASE P.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, F.FACTURA, P.CVE_ART,
                                            ISNULL(F.DOCUMENT2,'') AS DOCUMENTCP2, 
                                            (CASE P.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, P.CVE_TRACTOR, P.CVE_TANQUE1, 
                                            P.CVE_TANQUE2, P.CVE_DOCR,  ISNULL(CLASIFIC,'') AS CLASIF, ISNULL(PESO_BRUTO3,0) AS PESO3, 
                                            ISNULL(TARA3,0) AS T3, ISNULL((SELECT TOP 1 (PESO_BRUTO3 - TARA3) AS C3 FROM GCCARTA_PORTE 
                                            WHERE CVE_FOLIO = F.DOCUMENT2),0) AS CP2_CARGA3, ISNULL(P.CVE_TAB_VIAJE,'') AS CP_TAB_CVE
                                            FROM CFDI F 
                                            LEFT JOIN GCCARTA_PORTE P ON F.DOCUMENT = P.CVE_FOLIO AND ISNULL(F.ESTATUS,'A') <> 'C'
                                            LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE = P.CLAVE_O
                                            LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C1.CVE_PLAZA
                                            LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE = P.CLAVE_D
                                            LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = C2.CVE_PLAZA
                                            LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                                            LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                                            WHERE ISNULL(ESTATUS,'A') <> 'C' AND 
                                            (ISNUMERIC(P.CVE_TAB_VIAJE) = 1 OR P.CVE_TAB_VIAJE = '') AND 
                                            P.CLIENTE = '" & dr("CLIENTE") & "' AND
                                            FECHA_REAL_CARGA >= '" & FSQL(F1.Value) & " 00:00:00' AND 
                                            FECHA_REAL_CARGA <= '" & FSQL(F2.Value) & " 23:59:00' AND
                                            P.CVE_ART = '" & dr3("CVE_ART") & "' AND 
                                            P1.CIUDAD = '" & dr3("ORIGEN") & "' AND P2.CIUDAD = '" & dr3("DESTINO") & "'"

                                        Try 'GCSTATUS_CARTA_PORTE = 5 CANCELADO  ISNULL(PESO_BRUTO3,0) > 0 AND
                                            R1 = 0 : R2 = 0
                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                cmd2.CommandText = SQL
                                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                                    While dr2.Read
                                                        Try

                                                            'If dr2("DOCUMENT") = "AA-0000166844" Then
                                                            'Debug.Print("")
                                                            'End If
                                                            Try
                                                                CVE_TAB = dr2("CP_TAB_CVE").ToString.Substring(0, 1)
                                                            Catch ex As Exception
                                                            End Try

                                                            PESO = (dr2("PESO3") - dr2("T3")) + dr2("CP2_CARGA3")

                                                            If dr2("DOCUMENT") = "AA-0000165438" Then
                                                                Debug.Print("")
                                                            End If
                                                            UNIDADES = dr2("CVE_TRACTOR").ToString.Replace("-", "") & "-" &
                                                                    dr2("CVE_TANQUE1").ToString.Replace("-", "") & "-" &
                                                                    dr2("CVE_TANQUE2").ToString.Replace("-", "")

                                                            If Microsoft.VisualBasic.Right(UNIDADES, 1) = "-" Then
                                                                UNIDADES = UNIDADES.Substring(0, UNIDADES.Length - 1)
                                                            End If

                                                            CADENA_CP = dr2("DOCUMENT") &
                                                            IIf(dr2("DOCUMENTCP2").ToString.Length = 0, "", "-" & dr2("DOCUMENTCP2"))


                                                            If Not ChOcultarDoc.Checked Then
                                                                Fg.AddItem("" & vbTab & "" & vbTab &
                                                                       dr2("CVE_DOCR") & "  " & CADENA_CP & vbTab &
                                                                       UNIDADES & vbTab &
                                                                       PESO & vbTab &
                                                                       dr2("SUBTOT") & vbTab &
                                                                       "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "1")
                                                                ' & vbTab & dr2("CP_TAB_CVE")
                                                            End If

                                                            R1 += PESO
                                                            R2 += dr2("SUBTOT")

                                                            CC1 += PESO
                                                            C2 += dr2("SUBTOT")

                                                            T1 += PESO
                                                            T2 += dr2("SUBTOT")
                                                            SUMA_TON_CLASIFIC += PESO
                                                            SUMA_IMPORTE_CLASIFIC += dr2("SUBTOT")

                                                            For j = 1 To Fg.Rows.Count - 1
                                                                If Not IsNothing(Fg(j, 9)) Then
                                                                    If Fg(j, 9) = r_ Then
                                                                        r_ = j
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            Next
                                                            Fg(r_, 4) += PESO
                                                            Fg(r_, 5) += dr2("SUBTOT")
                                                            If dr2("T_UNI") = "Full" Then 'full
                                                                If IsNumeric(Fg(r_, 7)) Then
                                                                    Fg(r_, 7) += 1
                                                                Else
                                                                    Fg(r_, 7) = 1
                                                                End If
                                                                SUM_FULL += 1
                                                                TF += 1
                                                                C4 += 1
                                                            Else
                                                                If IsNumeric(Fg(r_, 6)) Then
                                                                    Fg(r_, 6) += 1
                                                                Else
                                                                    Fg(r_, 6) = 1
                                                                End If
                                                                TS += 1
                                                                SUM_SENCILLO += 1
                                                                C3 += 1
                                                            End If
                                                            'AQUI TENGO QUE BUSCAR Y SUMA EN EL DATASET
                                                        Catch ex As Exception
                                                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                                        End Try
                                                    End While
                                                End Using
                                            End Using
                                        Catch ex As Exception
                                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                        End Try
                                    End While
                                End Using
                                '█████████████████████████████████████████████████████████████████
                                Dim SUMA_REM As Decimal = 0, SihayFacR As Boolean = False, PRODUCR As String = ""

                                If CADENA_GCPRODUC2.Trim.Length = 0 Then
                                    'EMPIEZA LOS QUE NO ESTAN EN TRANSPORT SE HICICEORN QUE
                                    SQL = "SELECT ISNULL(LI.CAMPLIB9,'') AS LI9
                                    FROM FACTR" & Empresa & " F
                                    LEFT JOIN CLIE" & Empresa & " C ON F.CVE_CLPV = C.CLAVE
                                    LEFT JOIN PAR_FACTR" & Empresa & " P ON F.CVE_DOC = P.CVE_DOC
                                    LEFT JOIN INVE_CLIB" & Empresa & " LI ON P.CVE_ART = LI.CVE_PROD
                                    LEFT JOIN PAR_FACTR_CLIB" & Empresa & " LP ON P.NUM_PAR = LP.NUM_PART AND P.CVE_DOC = LP.CLAVE_DOC
                                    WHERE LP.CAMPLIB5 <> '' AND ISNULL(F.STATUS,'A') <> 'C' AND TOT_PARTIDA > 1 AND F.ENLAZADO = 'T' AND 
                                    C.CLAVE = '" & dr("CLIENTE") & "' AND SUBSTRING(ISNULL(LP.CAMPLIB3,'   '),1,3) <> 'AA-'
                                    GROUP BY LI.CAMPLIB9
                                    ORDER BY LI.CAMPLIB9"
                                    Using cmd4 As SqlCommand = cnSAE.CreateCommand
                                        cmd4.CommandText = SQL
                                        Using dr4 As SqlDataReader = cmd4.ExecuteReader
                                            While dr4.Read

                                                SQL = "SELECT C.CLAVE, C.NOMBRE, F.STATUS, F.CAN_TOT, ISNULL(CLASIFIC,'') AS CLASIF, F.CVE_DOC,
                                                TOT_PARTIDA, ISNULL(LI.CAMPLIB7,'') AS LI7, ISNULL(LI.CAMPLIB8,'') AS LI8, 
                                                ISNULL(LI.CAMPLIB9,'') AS LI9, ISNULL(LP.CAMPLIB1,'') AS LP1, 
                                                ISNULL(LP.CAMPLIB2,'') AS LP2, ISNULL(LP.CAMPLIB3,'') AS LP3, 
                                                ISNULL(LP.CAMPLIB4,'') AS LP4, ISNULL(LP.CAMPLIB5,'') AS LP5, 
                                                ISNULL(LI.CAMPLIB6,1) AS LIB6, NUM_PAR
                                                FROM FACTR" & Empresa & " F
                                                LEFT JOIN CLIE" & Empresa & " C ON F.CVE_CLPV = C.CLAVE
                                                LEFT JOIN PAR_FACTR" & Empresa & " P ON F.CVE_DOC = P.CVE_DOC
                                                LEFT JOIN INVE_CLIB" & Empresa & " LI ON P.CVE_ART = LI.CVE_PROD
                                                LEFT JOIN PAR_FACTR_CLIB" & Empresa & " LP ON P.NUM_PAR = LP.NUM_PART AND P.CVE_DOC = LP.CLAVE_DOC
                                                WHERE LP.CAMPLIB5 <> '' AND ISNULL(F.STATUS,'A') <> 'C' AND TOT_PARTIDA > 1 AND  F.ENLAZADO = 'T' AND 
                                                C.CLAVE = '" & dr("CLIENTE") & "' AND SUBSTRING(ISNULL(LP.CAMPLIB3,'   '),1,3) <> 'AA-' AND 
                                                LI.CAMPLIB9 = '" & dr4("LI9") & "' 
                                                ORDER BY LI.CAMPLIB9, LI.CAMPLIB8, F.CVE_DOC"

                                                '██████████████████████████████████████████████████████████████████████████
                                                'CARTAS PORTE NO DIDENTIFICADAS
                                                'CLASIF2 = ""
                                                SUMA_REM = 0 : SihayFacR = False : PRODUCR = ""
                                                r_ = Fg.Rows.Count
                                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                    cmd2.CommandText = SQL
                                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                                        While dr2.Read
                                                            Try
                                                                FECHA_LP = dr2("LP5")
                                                                PRODUCR = dr2("LI9")

                                                                If PRODUCR.Trim.Length > 0 Then
                                                                    Debug.Print("3. " & PRODUCR)
                                                                End If

                                                                If IsNumeric(FECHA_LP.Substring(2, 2)) Then
                                                                    NMES = CInt(FECHA_LP.Substring(2, 2))
                                                                Else
                                                                    NMES = 0
                                                                End If

                                                                If IsNumeric(FECHA_LP.Substring(4, 2)) Then
                                                                    NANO = CInt(FECHA_LP.Substring(4, 2))
                                                                Else
                                                                    NANO = 0
                                                                End If
                                                                If NMES > 0 And NANO > 0 Then
                                                                    If NMES = d1.Month And NANO = d1.Year - 2000 Then
                                                                        Sigue = True
                                                                        If Not ChOcultarDoc.Checked Then
                                                                            Fg.AddItem("R" & vbTab & "" & vbTab & dr2("CVE_DOC") & vbTab &
                                                                                dr2("LP4").ToString.Replace("-", "") & vbTab &
                                                                                1 & vbTab & dr2("TOT_PARTIDA") & vbTab & "" & vbTab &
                                                                                "" & vbTab & "" & vbTab & 0 & vbTab & "1")

                                                                        End If
                                                                        C2 += dr2("TOT_PARTIDA")
                                                                        T2 += dr2("TOT_PARTIDA")
                                                                        SUMA_IMPORTE_CLASIFIC += dr2("TOT_PARTIDA")
                                                                        SUMA_REM += dr2("TOT_PARTIDA")
                                                                        SihayFacR = True

                                                                        If dr2("LIB6") = 1 Then 'full
                                                                        Else
                                                                        End If
                                                                    End If
                                                                End If
                                                            Catch ex As Exception
                                                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                                            End Try
                                                        End While
                                                    End Using
                                                End Using
                                                If SihayFacR Then
                                                    Fg.Rows.Insert(r_)
                                                    Fg.Rows.Insert(r_)
                                                    Fg(r_ + 1, 1) = PRODUCR & " (FALSO FLETE REM)"
                                                    Fg(r_ + 1, 5) = SUMA_REM
                                                    Fg.Rows(r_ + 1).Style = Fg.Styles("RowColor")

                                                End If
                                            End While
                                        End Using
                                    End Using
                                End If

                                '██████████████████████████████████████████████████████████████████████████

                                If CADENA_GCPRODUC2.Trim.Length = 0 Then
                                    Try
                                        Dim SUMA_FAC As Decimal = 0, SihayFac As Boolean = False, PRODUC As String = ""

                                        'TABLA FACTF SE VA A CONSIDERAR LAS FACTURAS HECHAS EN  
                                        '20 JULIO 2022
                                        '       FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS 
                                        ''◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                                        'EMPIEZA LOS QUE NO ESTAN EN TRANSPORT SE HICICEORN QUE
                                        SQL = "SELECT ISNULL(LI.CAMPLIB9,'') AS LI9
                                        FROM FACTF" & Empresa & " F
                                        LEFT JOIN CLIE" & Empresa & " C ON F.CVE_CLPV = C.CLAVE
                                        LEFT JOIN PAR_FACTF" & Empresa & " P ON F.CVE_DOC = P.CVE_DOC
                                        LEFT JOIN INVE_CLIB" & Empresa & " LI ON P.CVE_ART = LI.CVE_PROD
                                        LEFT JOIN PAR_FACTF_CLIB" & Empresa & " LP ON P.NUM_PAR = LP.NUM_PART AND P.CVE_DOC = LP.CLAVE_DOC
                                        WHERE LP.CAMPLIB5 <> '' AND ISNULL(F.STATUS,'A') <> 'C' AND TOT_PARTIDA > 1 AND 
                                        C.CLAVE = '" & dr("CLIENTE") & "' AND SUBSTRING(ISNULL(LP.CAMPLIB3,'   '),1,3) <> 'AA-'
                                        GROUP BY LI.CAMPLIB9
                                        ORDER BY LI.CAMPLIB9"
                                        Using cmd4 As SqlCommand = cnSAE.CreateCommand
                                            cmd4.CommandText = SQL
                                            Using dr4 As SqlDataReader = cmd4.ExecuteReader
                                                While dr4.Read
                                                    '       FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS 
                                                    SQL = "SELECT C.CLAVE, C.NOMBRE, F.STATUS, F.CAN_TOT, ISNULL(CLASIFIC,'') AS CLASIF, F.CVE_DOC,
                                                TOT_PARTIDA, ISNULL(LI.CAMPLIB7,'') AS LI7, ISNULL(LI.CAMPLIB8,'') AS LI8, 
                                                ISNULL(LI.CAMPLIB9,'') AS LI9, ISNULL(LP.CAMPLIB1,'') AS LP1, 
                                                ISNULL(LP.CAMPLIB2,'') AS LP2, ISNULL(LP.CAMPLIB3,'') AS LP3, 
                                                ISNULL(LP.CAMPLIB4,'') AS LP4, ISNULL(LP.CAMPLIB5,'') AS LP5, 
                                                ISNULL(LI.CAMPLIB6,1) AS LIB6, NUM_PAR
                                                FROM FACTF" & Empresa & " F
                                                LEFT JOIN CLIE" & Empresa & " C ON F.CVE_CLPV = C.CLAVE
                                                LEFT JOIN PAR_FACTF" & Empresa & " P ON F.CVE_DOC = P.CVE_DOC
                                                LEFT JOIN INVE_CLIB" & Empresa & " LI ON P.CVE_ART = LI.CVE_PROD
                                                LEFT JOIN PAR_FACTF_CLIB" & Empresa & " LP ON P.NUM_PAR = LP.NUM_PART AND P.CVE_DOC = LP.CLAVE_DOC
                                                WHERE LP.CAMPLIB5 <> '' AND ISNULL(F.STATUS,'A') <> 'C' AND TOT_PARTIDA > 1 AND 
                                                C.CLAVE = '" & dr("CLIENTE") & "' AND 
                                                LI.CAMPLIB9 = '" & dr4("LI9") & "' 
                                                ORDER BY LI.CAMPLIB9, LI.CAMPLIB8, F.CVE_DOC"
                                                    '       FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS 
                                                    r_ = Fg.Rows.Count
                                                    SUMA_FAC = 0 : SihayFac = False : PRODUC = ""
                                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                        cmd2.CommandText = SQL
                                                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                                            While dr2.Read
                                                                Try
                                                                    PRODUC = dr2("LI9")
                                                                    FECHA_LP = dr2("LP5")

                                                                    If PRODUCR.Trim.Length > 0 Then
                                                                        Debug.Print("4. " & PRODUCR)
                                                                    End If

                                                                    If IsNumeric(FECHA_LP.Substring(2, 2)) Then
                                                                        NMES = FECHA_LP.Substring(2, 2)
                                                                    Else
                                                                        NMES = 0
                                                                    End If
                                                                    If IsNumeric(FECHA_LP.Substring(4, 2)) Then
                                                                        NANO = FECHA_LP.Substring(4, 2)
                                                                    Else
                                                                        NANO = 0
                                                                    End If

                                                                    If NMES > 0 And NANO > 0 Then
                                                                        If NMES = d1.Month And NANO = d1.Year - 2000 Then

                                                                            'If dr2("CVE_DOC") = "A0000005438" Then
                                                                            'Debug.Print("")
                                                                            'End If

                                                                            Sigue = True
                                                                            If Not ChOcultarDoc.Checked Then
                                                                                Fg.AddItem("F" & vbTab & dr2("LI9") & " - (F)" & vbTab &
                                                                                   dr2("CVE_DOC") & vbTab & dr2("LP4").ToString.Replace("-", "") & vbTab &
                                                                                    1 & vbTab & dr2("TOT_PARTIDA") & vbTab & "" & vbTab &
                                                                                    "" & vbTab & "" & vbTab & 0 & vbTab & "1")

                                                                            End If
                                                                            C2 += dr2("TOT_PARTIDA")
                                                                            T2 += dr2("TOT_PARTIDA")
                                                                            SUMA_IMPORTE_CLASIFIC += dr2("TOT_PARTIDA")
                                                                            SUMA_FAC += dr2("TOT_PARTIDA")
                                                                            SihayFac = True
                                                                            '       FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS
                                                                        End If
                                                                    End If
                                                                Catch ex As Exception
                                                                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                                                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                                                End Try
                                                            End While
                                                        End Using
                                                    End Using
                                                    If SihayFac Then
                                                        Fg.Rows.Insert(r_)
                                                        Fg.Rows.Insert(r_)
                                                        Fg(r_ + 1, 1) = PRODUC & " (FALSO FLETE)"
                                                        Fg(r_ + 1, 5) = SUMA_FAC
                                                        Fg.Rows(r_ + 1).Style = Fg.Styles("RowColor")

                                                    End If
                                                End While
                                            End Using
                                        End Using
                                        '       FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS        FACTURAS 
                                        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                                        'FIN TABLA FACTF
                                    Catch ex As Exception
                                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                    End Try
                                End If

                                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "1. Total cliente" & vbTab & CC1 & vbTab & C2 & vbTab &
                                           C3 & vbTab & C4 & vbTab & C3 + C4 & vbTab & 0 & vbTab & "1")
                                'CLASIF2 = dr2("CLASIF")
                                CLASIF2 = dr("CLASIF") ' INICIAL CLASIFIC X CLIENTE
                                Sigue = True
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try

                        DESPLEGAR_VIAJES_ESPECIALES(dr("CLIENTE"), CC1, C2, C3, C4)

                        'EN WHILE MAIN PRINCIPAL EL PRIMEOR ENDEJO
                    End While 'DO WHILE CLIENTE GROUP BY CLIENTE CLASIFIC
                End Using
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "Total global" & vbTab &
                           T1 + SUMA_VIAJES_ESPF1 & vbTab & T2 + SUMA_VIAJES_ESPF2 & vbTab &
                           TS + SUMA_VIAJES_ESPF3 & vbTab & TF + SUMA_VIAJES_ESPF4 & vbTab &
                           TS + TF + SUMA_VIAJES_ESPF3 + SUMA_VIAJES_ESPF4 & vbTab & 0 & vbTab & "1")
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Fg.Cols(2).Width = 250
        Fg.AutoSizeCols()
        Fg.Redraw = True

        Fg.Cursor = Cursors.Default
        Me.Cursor = Cursors.Default
        Dim msg As Object


        msg = New VtlMessageBox(C1.Win.C1Ribbon.VisualStyle.Office2010Blue)
        Dim Result As String
        With msg
            '.AddImageToMoreText("gridImage", img)
            .MessageText = " Proceso terminado  "
            .AddStandardButtons(MessageBoxButtons.OK)
            .Caption = "Reporte ventas por producto por cliente"
            .Icon = MessageBoxIcon.Information

            .MessageBoxPosition = FormStartPosition.CenterScreen
            Result = .Show()

        End With
    End Sub
    Sub DESPLEGAR_VIAJES_ESPECIALES(FCLIENTE As String, FMONTO1 As Decimal, FMONTO2 As Decimal, FTS As Decimal , FTF As Decimal )
        Dim R1 As Decimal = 0, R2 As Decimal = 0, CC1 As Decimal = 0, C2 As Decimal = 0, C3 As Decimal = 0, C4 As Decimal = 0, r_ As Integer = 0
        Dim T1 As Decimal, T2 As Decimal, T3 As Decimal = 0, TS As Integer = 0, TF As Integer = 0, rCte_ As Integer = 0, PESO As Decimal
        Dim SUMA_TON_CLASIFIC As Decimal = 0, SUMA_IMPORTE_CLASIFIC As Decimal = 0, Sigue As Boolean = False
        Dim CADENA As String = "", CLASIF2 As String = "", SUM_SENCILLO As Decimal = 0, SUM_FULL As Decimal = 0
        Dim UNIDADES As String = "", CADENA_CP As String, CADENA_GCPRODUC As String, CADENA_GCPRODUC2 As String
        Dim d1 As Date = F1.Value, NVe As Integer = 0, ExistViajEsp As Boolean = False

        Dim rs As CellStyle
        rs = Fg.Styles.Add("RowColor2")
        rs.BackColor = Color.Gold

        Dim rs2 As CellStyle
        rs2 = Fg.Styles.Add("ColorCliente2")
        rs2.BackColor = Color.Yellow

        NVe = Fg.Rows.Count - 1


        CADENA = " AND P.CLIENTE = '" & FCLIENTE & "'"
        If TCVE_PROD.Text.Trim.Length > 0 Then
            CADENA_GCPRODUC = " AND CVE_ART = '" & TCVE_PROD.Text & "'"
            CADENA_GCPRODUC2 = " AND I.DESCR = '" & TDESCR.Text & "'"
        Else
            CADENA_GCPRODUC = ""
            CADENA_GCPRODUC2 = ""
        End If

        SQL = "SELECT P.CLIENTE, MAX(NOMBRE) AS NOMB, ISNULL(CLASIFIC,'') AS CLASIF
            FROM GCCARTA_PORTE P
            LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
            WHERE ISNULL(P.CLIENTE,'') <> '' AND 
            (ISNUMERIC(P.CVE_TAB_VIAJE) = 0 AND P.CVE_TAB_VIAJE <> '') AND 
            FECHA_REAL_CARGA >= '" & FSQL(F1.Value) & " 00:00:00' AND 
            FECHA_REAL_CARGA <= '" & FSQL(F2.Value) & " 23:59:00' " & CADENA & CADENA_GCPRODUC & " 
            GROUP BY CLIENTE, CLASIFIC ORDER BY CLASIFIC"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If CLASIF2 <> dr("CLASIF") And Sigue Then
                            Sigue = True
                            'If dr("CLIENTE") = "         8" Or dr("CLIENTE") = "        25" Or dr("CLIENTE") = "        82" Then
                            'Sigue = True
                            'End If
                            If SUMA_TON_CLASIFIC > 0 And SUMA_IMPORTE_CLASIFIC > 0 Then
                                Fg.Rows.Insert(Fg.Rows.Count)
                                Fg.Rows.Insert(Fg.Rows.Count)

                                Fg(Fg.Rows.Count - 2, 2) = "-Total por grupo especial"
                                Fg(Fg.Rows.Count - 2, 3) = CLASIF2
                                Fg(Fg.Rows.Count - 2, 4) = SUMA_TON_CLASIFIC
                                Fg(Fg.Rows.Count - 2, 5) = SUMA_IMPORTE_CLASIFIC
                                Fg(Fg.Rows.Count - 2, 6) = SUM_SENCILLO
                                Fg(Fg.Rows.Count - 2, 7) = SUM_FULL
                                Fg(Fg.Rows.Count - 2, 8) = SUM_SENCILLO + SUM_FULL

                                Fg(Fg.Rows.Count - 2, 10) = "0"

                                Fg.Rows(Fg.Rows.Count - 2).Style = Fg.Styles("RowColor2")

                                T3 += SUM_SENCILLO + SUM_FULL
                                If dr("CLIENTE") = "        82" Then
                                    Sigue = True
                                End If

                            End If
                            SUMA_TON_CLASIFIC = 0 : SUMA_IMPORTE_CLASIFIC = 0 : SUM_FULL = 0 : SUM_SENCILLO = 0
                        End If
                        Fg.AddItem("" & vbTab & dr("CLIENTE") & " " & dr("NOMB") & vbTab & dr("CLASIF") & vbTab &
                                   "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "0")

                        rCte_ = Fg.Rows.Count - 1
                        Fg.Rows(Fg.Rows.Count - 1).Style = Fg.Styles("ColorCliente2")

                        SQL = "SELECT P.CVE_ART, MAX(I.DESCR) AS DES, ISNULL(SUM(PESO_BRUTO3 - TARA3),0) AS PB3,
                            ISNULL(P1.CIUDAD,'') AS ORIGEN, ISNULL(P2.CIUDAD,'') AS DESTINO
                            FROM CFDI F 
                            LEFT JOIN GCCARTA_PORTE P ON F.DOCUMENT = P.CVE_FOLIO AND ISNULL(F.ESTATUS,'A') <> 'C'
                            LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                            LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE = P.CLAVE_O
                            LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C1.CVE_PLAZA
                            LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE = P.CLAVE_D
                            LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = C2.CVE_PLAZA
                            LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                            WHERE ISNULL(ESTATUS,'A') <> 'C' AND (ISNUMERIC(P.CVE_TAB_VIAJE) = 0 AND P.CVE_TAB_VIAJE <> '') AND 
                            P.CLIENTE = '" & dr("CLIENTE") & "' " & CADENA_GCPRODUC2 & "
                            AND FECHA_REAL_CARGA >= '" & FSQL(F1.Value) & " 00:00:00' AND FECHA_REAL_CARGA <= '" & FSQL(F2.Value) & " 23:59:00' 
                            GROUP BY P.CVE_ART, P1.CIUDAD, P2.CIUDAD ORDER BY MAX(CLASIFIC)"
                        SQL1 = SQL
                        CC1 = 0 : C2 = 0 : C3 = 0 : C4 = 0
                        Try
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQL
                                Using dr3 As SqlDataReader = cmd3.ExecuteReader
                                    While dr3.Read

                                        '                                               1
                                        Fg.AddItem("" & vbTab & IIf(dr3("PB3") = 0, "FALSO FLETE", dr3("DES")) & vbTab &
                                                   dr3("ORIGEN") & "-" & dr3("DESTINO") & vbTab & "" & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab &
                                                   0 & vbTab & 0 & vbTab & "0")
                                        '                           2                             3            4           5           6           7
                                        '         UNIDAD    TONELADAS     IMPORTE   SENCILLO       FULL       RUTAS
                                        r_ = Fg.Rows.Count - 1
                                        SQL = "SELECT P.CLIENTE, F.SUBTOTAL, F.IVA, F.RETENCION, F.IMPORTE, F.SUBTOTAL AS SUBTOT, F.DOCUMENT, 
                                            (CASE P.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, F.FACTURA, P.CVE_ART,
                                            ISNULL(F.DOCUMENT2,'') AS DOCUMENTCP2, 
                                            (CASE P.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, P.CVE_TRACTOR, P.CVE_TANQUE1, 
                                            P.CVE_TANQUE2, P.CVE_DOCR,  ISNULL(CLASIFIC,'') AS CLASIF, ISNULL(PESO_BRUTO3,0) AS PESO3, 
                                            ISNULL(TARA3,0) AS T3, ISNULL((SELECT TOP 1 (PESO_BRUTO3 - TARA3) AS C3 FROM GCCARTA_PORTE 
                                            WHERE CVE_FOLIO = F.DOCUMENT2),0) AS CP2_CARGA3, ISNULL(P.CVE_TAB_VIAJE,'') AS CP_TAB_CVE
                                            FROM CFDI F 
                                            LEFT JOIN GCCARTA_PORTE P ON F.DOCUMENT = P.CVE_FOLIO AND ISNULL(F.ESTATUS,'A') <> 'C'
                                            LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE = P.CLAVE_O
                                            LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C1.CVE_PLAZA
                                            LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE = P.CLAVE_D
                                            LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = C2.CVE_PLAZA
                                            LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                                            LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                                            WHERE ISNULL(ESTATUS,'A') <> 'C' AND 
                                            (ISNUMERIC(P.CVE_TAB_VIAJE) = 0 AND P.CVE_TAB_VIAJE <> '') AND 
                                            P.CLIENTE = '" & dr("CLIENTE") & "' AND
                                            FECHA_REAL_CARGA >= '" & FSQL(F1.Value) & " 00:00:00' AND 
                                            FECHA_REAL_CARGA <= '" & FSQL(F2.Value) & " 23:59:00' AND
                                            P.CVE_ART = '" & dr3("CVE_ART") & "' AND 
                                            P1.CIUDAD = '" & dr3("ORIGEN") & "' AND P2.CIUDAD = '" & dr3("DESTINO") & "'"

                                        Try 'GCSTATUS_CARTA_PORTE = 5 CANCELADO  ISNULL(PESO_BRUTO3,0) > 0 AND
                                            R1 = 0 : R2 = 0
                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                cmd2.CommandText = SQL
                                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                                    While dr2.Read
                                                        ExistViajEsp = True
                                                        Try
                                                            PESO = (dr2("PESO3") - dr2("T3")) + dr2("CP2_CARGA3")

                                                            If dr2("DOCUMENT") = "AA-0000165438" Then
                                                                Debug.Print("")
                                                            End If
                                                            UNIDADES = dr2("CVE_TRACTOR").ToString.Replace("-", "") & "-" &
                                                                    dr2("CVE_TANQUE1").ToString.Replace("-", "") & "-" &
                                                                    dr2("CVE_TANQUE2").ToString.Replace("-", "")

                                                            If Microsoft.VisualBasic.Right(UNIDADES, 1) = "-" Then
                                                                UNIDADES = UNIDADES.Substring(0, UNIDADES.Length - 1)
                                                            End If

                                                            CADENA_CP = dr2("DOCUMENT") &
                                                            IIf(dr2("DOCUMENTCP2").ToString.Length = 0, "", "-" & dr2("DOCUMENTCP2"))


                                                            If Not ChOcultarDoc.Checked Then
                                                                Fg.AddItem("" & vbTab & "" & vbTab &
                                                                       dr2("CVE_DOCR") & "  " & CADENA_CP & vbTab &
                                                                       UNIDADES & vbTab &
                                                                       PESO & vbTab &
                                                                       dr2("SUBTOT") & vbTab &
                                                                       "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & dr2("CP_TAB_CVE"))
                                                                ' & vbTab & dr2("CP_TAB_CVE")
                                                            End If

                                                            R1 += PESO
                                                            R2 += dr2("SUBTOT")

                                                            CC1 += PESO
                                                            C2 += dr2("SUBTOT")

                                                            T1 += PESO
                                                            T2 += dr2("SUBTOT")
                                                            SUMA_TON_CLASIFIC += PESO
                                                            SUMA_IMPORTE_CLASIFIC += dr2("SUBTOT")

                                                            For j = 1 To Fg.Rows.Count - 1
                                                                If Not IsNothing(Fg(j, 9)) Then
                                                                    If Fg(j, 9) = r_ Then
                                                                        r_ = j
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            Next
                                                            Fg(r_, 4) += PESO
                                                            Fg(r_, 5) += dr2("SUBTOT")
                                                            If dr2("T_UNI") = "Full" Then 'full
                                                                If IsNumeric(Fg(r_, 7)) Then
                                                                    Fg(r_, 7) += 1
                                                                Else
                                                                    Fg(r_, 7) = 1
                                                                End If
                                                                SUM_FULL += 1
                                                                TF += 1
                                                                C4 += 1
                                                            Else
                                                                If IsNumeric(Fg(r_, 6)) Then
                                                                    Fg(r_, 6) += 1
                                                                Else
                                                                    Fg(r_, 6) = 1
                                                                End If
                                                                TS += 1
                                                                SUM_SENCILLO += 1
                                                                C3 += 1
                                                            End If
                                                            'AQUI TENGO QUE BUSCAR Y SUMA EN EL DATASET
                                                        Catch ex As Exception
                                                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                                        End Try
                                                    End While
                                                End Using
                                            End Using
                                        Catch ex As Exception
                                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                        End Try
                                    End While
                                End Using
                                '█████████████████████████████████████████████████████████████████
                                Dim SUMA_REM As Decimal = 0, SihayFacR As Boolean = False, PRODUCR As String = ""


                                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "-Total cliente" & vbTab & CC1 & vbTab & C2 & vbTab &
                                           C3 & vbTab & C4 & vbTab & C3 + C4 & vbTab & 0 & vbTab & "0")
                                'CLASIF2 = dr2("CLASIF")
                                CLASIF2 = dr("CLASIF") ' INICIAL CLASIFIC X CLIENTE
                                Sigue = True
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    End While 'DO WHILE CLIENTE GROUP BY CLIENTE CLASIFIC
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        If ExistViajEsp Then
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "-Total global especial" & vbTab &
                           T1 + FMONTO1 & vbTab & T2 + FMONTO2 & vbTab & TS + FTS & vbTab & TF + FTF & vbTab & TS + TF + FTS + FTF & vbTab & 0 & vbTab & "0")

            SUMA_VIAJES_ESPF1 += T1
            SUMA_VIAJES_ESPF2 += T2
            SUMA_VIAJES_ESPF3 += TS
            SUMA_VIAJES_ESPF4 += TF

            SUMA_VIAJES_ESP1 = T1
            SUMA_VIAJES_ESP2 = T2
            SUMA_VIAJES_ESP3 = TS
            SUMA_VIAJES_ESP4 = TF

            Fg.Rows.Insert(NVe + 1)
            Fg.Rows.Insert(NVe + 2)
            Fg.Rows.Insert(NVe + 3)
            Fg.Rows.Insert(NVe + 4)
            Fg(NVe + 3, 1) = "VIAJES ESPECIALES"
        End If
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "VENTAS X PRODUCTO X CLIENTE")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = "", ARCHIVO As String
            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            Dim t As DataTable = DataSet1.Tables(0)
            Dim r As DataRow
            DataSet1.Clear()

            ARCHIVO = RUTA_FORMATOS & "\ReportVtaXProXCteTrackFullRojo.mrt"
            If Not File.Exists(ARCHIVO) Then
                MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                Return
            End If

            For k = 1 To Fg.Rows.Count - 1
                r = t.NewRow()
                If Not IsDBNull(Fg(k, 1)) Then
                    If Not IsNothing(Fg(k, 1)) Then
                        r("NOM_CLIE") = Fg(k, 1)
                    Else
                        r("NOM_CLIE") = ""
                    End If
                Else
                    r("NOM_CLIE") = ""
                End If

                r("RUTA") = Fg(k, 2)
                r("UNIDAD") = Fg(k, 3)

                If Not IsDBNull(Fg(k, 5)) Then
                    If Not IsNothing(Fg(k, 4)) Then
                        r("TONELADAS") = Fg(k, 4)
                    Else
                        r("TONELADAS") = 0
                    End If
                Else
                    r("TONELADAS") = 0
                End If
                If Not IsDBNull(Fg(k, 5)) Then
                    If Not IsNothing(Fg(k, 5)) Then
                        r("IMPORTE") = Fg(k, 5)
                    Else
                        r("IMPORTE") = 0
                    End If
                Else
                    r("IMPORTE") = 0
                End If
                r("SENCILLO") = Fg(k, 6)
                r("FULL") = Fg(k, 7)
                r("TOTAL_VIAJES") = Fg(k, 8)
                r("FF1") = F1.Value
                r("FF2") = F2.Value
                t.Rows.Add(r)
            Next

            StiReport1.Load(ARCHIVO)
            StiReport1.Compile()

            StiReport1.RegData(DataSet1)

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Render()

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                'StiReport1.Design()
            Else
                'StiReport1.Show()
            End If
            StiReport1.Show()
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnClie_Click(sender As Object, e As EventArgs) Handles btnClie.Click
        Try
            Var2 = "Clientes"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("1080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Var5 = ""
                Dim DESCR As String
                DESCR = TCLIENTE.Text.Trim
                If IsNumeric(DESCR) Then
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCLIENTE.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR <> "" Then
                    Var11 = TCLIENTE.Text
                    LtNombre.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE.Text = ""
                    LtNombre.Text = ""
                    TCLIENTE.Focus()
                    TCLIENTE.SelectAll()
                End If
            Else
                LtNombre.Text = ""
            End If
        Catch ex As Exception
            Bitacora("387. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("387. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
    Private Sub BtnProducto_Click(sender As Object, e As EventArgs) Handles BtnProducto.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PROD.Text = Var4
                TDESCR.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                Fg.Focus()
            End If
        Catch ex As Exception
            Bitacora("1780. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1780. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PROD_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PROD.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProducto_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_PROD_Validated(sender As Object, e As EventArgs) Handles TCVE_PROD.Validated
        Try
            If TCVE_PROD.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("GCPRODUCTOS", TCVE_PROD.Text)
                If DESCR <> "" And DESCR <> "N" Then
                    TDESCR.Text = DESCR
                    Fg.Focus()
                Else
                    MsgBox("Articulo inexistente")
                    TCVE_PROD.Select()
                    TCVE_PROD.Text = ""
                    TDESCR.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("1800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
