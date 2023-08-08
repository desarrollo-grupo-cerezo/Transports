Imports C1.C1Excel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Public Class frmTabuladorCombustibleAE
    Private _MyEditorTab As MyEditorTab
    Private TIPO_TAB As Integer = 0
    Private ENTRA As Boolean
    Private ENTRA_COMBO As Boolean = True
    Private MODO_EDIT As String
    Private msg As VtlMessageBox

    Private Sub FrmTabuladorCombustibles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With
        Fg.Rows.Count = 1
        Fg.Rows(0).Height = 40
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - BarraMenu.Height - 100
        Me.KeyPreview = True
        DERECHOS()

        Fg.DrawMode = DrawModeEnum.OwnerDraw

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(TIPO_TAB,0) AS TI_TAB FROM GCPARAMGENERALES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TIPO_TAB = dr("TI_TAB")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Select Case TIPO_TAB
            Case 0, 2
                BarExcel.Visible = False

                Fg.Cols(1).Visible = False
                Fg.Cols(2).Visible = False
                Fg.Cols(3).Visible = False

                Fg.Cols(0).Width = 50
                Fg.Cols(19).Width = 0


                Fg.Cols(10).ComboList = "|Cargado|Vacio"
                Fg.Cols(11).ComboList = "|Full|Sencillo"

                Try
                    DESPLEGAR_PAR()
                Catch ex As Exception
                    Bitacora("35. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("35. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try

                FgEdit = True
                Try
                    _MyEditorTab = New MyEditorTab(Fg, 10)
                    If Fg.Row > 0 Then
                        Fg.Row = Fg.Rows.Count - 1
                        Fg.Col = 1
                        _MyEditorTab.StartEditing(Fg.Row, 1)
                    End If
                Catch ex As Exception
                    Bitacora("45. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("45. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Case 1
                Fg.Rows.Count = 1

                Fg.Cols(1).ComboList = ""
                Fg.Cols(3).ComboList = ""
                Fg.Cols(5).ComboList = ""
                Fg.Cols(8).ComboList = ""
                Fg.Cols(10).ComboList = ""
                Fg.Cols(11).ComboList = ""
                Fg.Cols(13).ComboList = ""

                Fg.Cols(4).AllowEditing = True
                Fg.Cols(7).AllowEditing = True

                Fg.Cols(4).ComboList = "..."
                Fg.Cols(7).ComboList = "..."
                Fg.Cols(8).ComboList = "..."
                Fg.Cols(11).ComboList = "..."
                Fg.Cols(13).ComboList = "..."


                TITULOS()

                DESPLEGAR_VIKINGOS()

        End Select

        ENTRA = True

        If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
            For k = 1 To Fg.Cols.Count - 1
                Fg(0, k) = Fg(0, k) & " " & k
            Next
        End If


    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                barGrabar.Visible = False
                btnEliProd.Enabled = False
                btnAltaProducto.Enabled = False
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 81500 AND CLAVE < 81600"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 81510 'NUEVO
                                    barGrabar.Visible = True
                                    btnAltaProducto.Enabled = True
                                Case 81530 'ELIMINAR
                                    btnEliProd.Enabled = True
                                Case 81540 'GRABAR
                                    barGrabar.Visible = True
                                    BarActualizar.Visible = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR_VIKINGOS()
        Fg.Redraw = False

        Fg.Rows.Count = 1

        Try
            Dim NewStyle1 As CellStyle

            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.BackColor = Color.LightSkyBlue
            NewStyle1.ForeColor = Color.Black

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT T.CVE_TAB, T.NUM_VIAJE, T.STATUS, T.FOLIO_LIQ, T.CVE_OPER, T.CVE_UNI, T.NOMBRE_OPER, T.TIPO_VIAJE, 
                    T.CLIENTE, T.NOMBRE_CLIE, T.CVE_ORI, T.ORIGEN, T.CVE_DES, T.DESTINO, T.CARGADO_VACIO, T.KMS, T.RENDIMIENTO, 
                    T.LITROS, T.TONELADAS, ISNULL(T.CVE_RES,0) AS CVE_RESET, ISNULL(FECHA_IDA,'') AS F_IDA
                    FROM GCTABULADOR_EXCEL T 
                    LEFT JOIN GCCLIE_OP C On C.CLAVE = T.CLIENTE 
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.CVE_ORI 
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.CVE_DES 
                    WHERE ISNULL(T.STATUS,'A') = 'A' ORDER BY T.CVE_TAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_TAB") & vbTab & dr("NUM_VIAJE") & vbTab & dr("FOLIO_LIQ") & vbTab &
                                dr("CVE_OPER") & vbTab & dr.ReadNullAsEmptyString("NOMBRE_OPER") & vbTab &
                                IIf(dr("F_IDA") = "01/01/1900", "", dr("F_IDA")) & vbTab & dr.ReadNullAsEmptyString("CVE_UNI") & vbTab &
                                dr.ReadNullAsEmptyString("TIPO_VIAJE") & vbTab & dr("CLIENTE") & vbTab & dr("NOMBRE_CLIE") & vbTab &
                                dr("CVE_ORI") & vbTab & dr.ReadNullAsEmptyString("ORIGEN") & vbTab & dr("CVE_DES") & vbTab &
                                dr.ReadNullAsEmptyString("DESTINO") & vbTab & IIf(dr.ReadNullAsEmptyInteger("CARGADO_VACIO") = 0, "Vacio", "Cargado") & vbTab &
                                dr("KMS") & vbTab & dr.ReadNullAsEmptyDecimal("RENDIMIENTO") & vbTab &
                                dr("LITROS") & vbTab & dr.ReadNullAsEmptyDecimal("TONELADAS") & vbTab & IIf(dr("CVE_RESET") = 0, "", dr("CVE_RESET")))
                        If dr("CVE_RESET") > 0 Then
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 6, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 19, NewStyle1)
                        End If

                    End While
                End Using
                Fg.AutoSizeCols()

                Fg.Cols(6).Width = 100

            End Using
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Sub DESPLEGAR_PAR()
        Dim CA1 As Decimal, CAR_VAC As Integer
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "UPDATE GCTABULADOR_PAR SET UUID = NEWID() WHERE ISNULL(UUID,'') = ''"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If

            End Using
        Catch ex As Exception
        End Try
        Fg.Redraw = False

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_TAB, CVE_OPER, CVE_UNI, CVE_ORI, ISNULL(P1.CIUDAD,'') AS DESCR_ORI, CVE_DES, ISNULL(P2.CIUDAD,'') AS DESCR_DES, 
                    ISNULL(CARGADO_VACIO,0) AS CAR_VAC, ISNULL(TIPO_VIAJE,'') AS TIP_VIAJE, CLIENTE, C.NOMBRE, ISNULL(KMS,0) As KM, RENDIMIENTO, 
                    ISNULL(LITROS,0) As LTS, T.TONELADAS, T.UUID, ISNULL(OBSER,'') AS STR_OBS
                    FROM GCTABULADOR_PAR T 
                    LEFT JOIN GCCLIE_OP C On C.CLAVE = T.CLIENTE 
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.CVE_ORI 
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.CVE_DES 
                    WHERE ISNULL(T.STATUS,'A') = 'A' ORDER BY T.CVE_TAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If dr.ReadNullAsEmptyDecimal("RENDIMIENTO") > 0 Then
                            CA1 = dr.ReadNullAsEmptyDecimal("KM") / dr.ReadNullAsEmptyDecimal("RENDIMIENTO")
                        Else
                            CA1 = 0
                        End If

                        CAR_VAC = dr.ReadNullAsEmptyInteger("CAR_VAC")

                        Fg.AddItem(dr("CVE_TAB") & vbTab & dr("CVE_OPER") & vbTab &
                           BUSCA_CAT("Operador", dr.ReadNullAsEmptyInteger("CVE_OPER")) & vbTab & dr.ReadNullAsEmptyString("CVE_UNI") & vbTab &
                           dr("CVE_ORI") & vbTab & "" & vbTab & dr.ReadNullAsEmptyString("DESCR_ORI") & vbTab & dr("CVE_DES") & vbTab &
                           "" & vbTab & dr.ReadNullAsEmptyString("DESCR_DES") & vbTab &
                           IIf(dr.ReadNullAsEmptyInteger("CAR_VAC") = 0, "Vacio", "Cargado") & vbTab &
                           dr.ReadNullAsEmptyString("TIP_VIAJE") & vbTab & dr.ReadNullAsEmptyString("CLIENTE") & vbTab & "" & vbTab &
                           dr.ReadNullAsEmptyString("NOMBRE") & vbTab & dr("KM") & vbTab & dr.ReadNullAsEmptyDecimal("RENDIMIENTO") & vbTab &
                           CA1 & vbTab & dr.ReadNullAsEmptyDecimal("TONELADAS") & vbTab & dr.ReadNullAsEmptyString("UUID") & vbTab &
                           dr.ReadNullAsEmptyString("STR_OBS"))

                        If dr("CVE_TAB") = "106" Then
                        End If

                    End While
                End Using
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                          "" & vbTab & "" & vbTab & "" & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
            End Using
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Fg.Redraw = True

        msg = New VtlMessageBox(C1.Win.C1Ribbon.VisualStyle.Office2010Blue)
        Dim Result As String
        With msg
            '.AddImageToMoreText("gridImage", img)
            .MessageText = "LIsto"
            '.MoreText = "-----"
            .AddStandardButtons(MessageBoxButtons.OK)
            .Caption = "OK"
            .Icon = MessageBoxIcon.Information
            .MessageBoxPosition = FormStartPosition.CenterScreen
            Result = .Show()
        End With

    End Sub
    Private Sub FrmTabuladorCombustibles_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Tabulador combustible")

            Me.Dispose()
            'If FORM_IS_OPEN("frmTabuladorCombustible") Then
            'frmTabuladorCombustible.DESPLEGAR()
            'End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click

        Select Case TIPO_TAB
            Case 0, 2
                TABULADOR_TRANSPORT()
            Case 1
                GRABAR_TABULADOR_EXCEL()
        End Select

    End Sub
    Sub TABULADOR_TRANSPORT()
        Dim CVE_ORI As Integer, CVE_DES As Integer, CLIENTE As String, CARGADO_VACIO As Integer, TONELADAS As Decimal, KMS As Decimal, LITROS As Decimal
        Dim UUID As String = "", RENDIMIENTO As Decimal, CVE_OPER As Integer, CVE_UNI As String, TIPO_VIAJE As String, CVE_TAB As Long, OBSER As String = ""

        If Not Valida_Conexion() Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "UPDATE GCTABULADOR_PAR SET ESTADO = 'B' "
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        SQL = "UPDATE GCTABULADOR_PAR SET CVE_OPER = @CVE_OPER, CVE_UNI = @CVE_UNI, TIPO_VIAJE = @TIPO_VIAJE, CVE_ORI = @CVE_ORI, CVE_DES = @CVE_DES, 
            CARGADO_VACIO = @CARGADO_VACIO, CLIENTE = @CLIENTE, KMS = @KMS, RENDIMIENTO = @RENDIMIENTO, LITROS = @LITROS, ESTADO = 'A', 
            TONELADAS = @TONELADAS, OBSER = @OBSER 
            WHERE CVE_TAB = @CVE_TAB
            IF @@ROWCOUNT = 0 
            INSERT INTO GCTABULADOR_PAR (CVE_TAB, STATUS, ESTADO, CVE_OPER, CVE_UNI, TIPO_VIAJE, CVE_ORI, CVE_DES, CARGADO_VACIO, CLIENTE, KMS, 
            RENDIMIENTO, LITROS, TONELADAS, OBSER, UUID) OUTPUT Inserted.CVE_TAB VALUES (@CVE_TAB, 'A', 'A', @CVE_OPER, @CVE_UNI, 
            @TIPO_VIAJE, @CVE_ORI, @CVE_DES, @CARGADO_VACIO, @CLIENTE, @KMS, @RENDIMIENTO, @LITROS, @TONELADAS, @OBSER, NEWID())"

        Try
            ENTRA = False
            For k = 1 To Fg.Rows.Count - 1
                Try
                    CVE_TAB = 0
                    Try
                        If Not IsNothing(Fg(k, 0)) Then
                            If IsNumeric(Fg(k, 0)) Then
                                CVE_TAB = Fg(k, 0)
                            End If
                        End If
                    Catch ex As Exception
                        CVE_TAB = 0
                    End Try
                    If CVE_TAB = 0 Then
                        CVE_TAB = GET_MAX("GCTABULADOR_PAR", "CVE_TAB")
                    End If

                    If Not IsNothing(Fg(k, 4)) Then
                        If IsNumeric(Fg(k, 4)) Then
                            CVE_OPER = Fg(k, 4)
                        Else
                            CVE_OPER = 0
                        End If
                    Else
                        CVE_OPER = 0
                    End If
                    CVE_UNI = Fg(k, 3)
                    If IsNumeric(Fg(k, 4)) Then
                        CVE_ORI = Fg(k, 4)
                    Else
                        CVE_ORI = 0
                    End If
                    If IsNumeric(Fg(k, 7)) Then
                        CVE_DES = Fg(k, 7)
                    Else
                        CVE_DES = 0
                    End If

                    CARGADO_VACIO = IIf(Fg(k, 10).ToString.ToUpper = "CARGADO", 1, 0)
                    TIPO_VIAJE = Fg(k, 11)
                    CLIENTE = Fg(k, 12)

                    If Fg(k, 0) = "106" Then
                    End If

                    If IsNumeric(Fg(k, 15)) Then
                        KMS = Fg(k, 15)
                    Else
                        KMS = 0
                    End If
                    If IsNumeric(Fg(k, 16)) Then
                        RENDIMIENTO = Fg(k, 16)
                    Else
                        RENDIMIENTO = 0
                    End If

                    If RENDIMIENTO > 0 Then
                        LITROS = KMS / RENDIMIENTO
                    Else
                        LITROS = 0
                    End If
                    Try
                        If Not IsNothing(Fg(k, 18)) Then
                            TONELADAS = Fg(k, 18)
                        Else
                            TONELADAS = 0
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 19)) Then
                            UUID = Fg(k, 19)
                        Else
                            UUID = ""
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 20)) Then
                            OBSER = Fg(k, 20)
                        Else
                            OBSER = ""
                        End If
                    Catch ex As Exception
                    End Try
                    If k = Fg.Rows.Count - 2 Then
                        OBSER = OBSER
                    End If
                    If CVE_ORI > 0 And CVE_DES > 0 Then
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_TAB", SqlDbType.Int).Value = CVE_TAB
                            cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CVE_OPER
                            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = CVE_UNI
                            cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.VarChar).Value = TIPO_VIAJE
                            cmd.Parameters.Add("@CVE_ORI", SqlDbType.Int).Value = CONVERTIR_TO_INT(CVE_ORI)
                            cmd.Parameters.Add("@CVE_DES", SqlDbType.Int).Value = CONVERTIR_TO_INT(CVE_DES)
                            cmd.Parameters.Add("@CARGADO_VACIO", SqlDbType.Bit).Value = CARGADO_VACIO
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = CLIENTE
                            cmd.Parameters.Add("@KMS", SqlDbType.Float).Value = KMS
                            cmd.Parameters.Add("@RENDIMIENTO", SqlDbType.Float).Value = RENDIMIENTO
                            cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = Math.Round(LITROS, 2)
                            cmd.Parameters.Add("@TONELADAS", SqlDbType.Float).Value = Math.Round(TONELADAS, 2)
                            cmd.Parameters.Add("@UUID", SqlDbType.VarChar).Value = UUID
                            cmd.Parameters.Add("@OBSER", SqlDbType.VarChar).Value = OBSER
                            returnValue = cmd.ExecuteScalar
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                                Fg(k, 0) = returnValue
                            End If
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("95. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("95. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
            ENTRA = True
            MsgBox("Los tabuladores se grabaron satisfactoriamente")
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default

    End Sub
    Sub GRABAR_TABULADOR_EXCEL()

        Dim CVE_ORI As Integer, CVE_DES As Integer, CLIENTE As String, CARGADO_VACIO As Integer, TONELADAS As Decimal, KMS As Decimal, LITROS As Decimal
        Dim UUID As String = "", RENDIMIENTO As Decimal, CVE_OPER As Integer, CVE_UNI As String, TIPO_VIAJE As String, CVE_TAB As Long, OBSER As String = ""
        Dim NUM_VIAJE As Long, FOLIO_LIQ As Long, NOMBRE_OPER As String, NOMBRE_CLIE As String, ORIGEN As String, DESTINO As String, j As Integer = 0
        Dim z As Integer = 0, FECHA_IDA As Date

        If Not Valida_Conexion() Then
            Return
        End If

        Me.Fg.Redraw = False

        Me.Cursor = Cursors.WaitCursor

        Try
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "UPDATE GCTABULADOR_PAR SET ESTADO = 'B' "
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Dim newStyle1 As CellStyle = Fg.Styles.Add("NewStyle1")
        newStyle1.BackColor = Color.Red
        newStyle1.ForeColor = Color.White
        newStyle1.Font = New Font("Aril", 11, FontStyle.Bold)

        Try
            ENTRA = False
            For k = 1 To Fg.Rows.Count - 1
                Try
                    CVE_TAB = 0
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            If IsNumeric(Fg(k, 1)) Then
                                CVE_TAB = Fg(k, 1)
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    If CVE_TAB = 0 Then
                        CVE_TAB = GET_MAX("GCTABULADOR_EXCEL", "CVE_TAB")
                    End If

                    If Not IsNothing(Fg(k, 2)) Then
                        If IsNumeric(Fg(k, 2)) Then
                            NUM_VIAJE = Fg(k, 2)
                        Else
                            NUM_VIAJE = 0
                        End If
                    Else
                        NUM_VIAJE = 0
                    End If


                    If NUM_VIAJE > 0 Then

                        Lt1.Text = "Registros procesados " & k & " de " & Fg.Rows.Count - 1

                        If Not IsNothing(Fg(k, 3)) Then
                            If IsNumeric(Fg(k, 3)) Then
                                FOLIO_LIQ = Fg(k, 3)
                            Else
                                FOLIO_LIQ = 0
                            End If
                        Else
                            FOLIO_LIQ = 0
                        End If

                        If Not IsNothing(Fg(k, 4)) Then
                            If IsNumeric(Fg(k, 4)) Then
                                CVE_OPER = Fg(k, 4)
                            Else
                                CVE_OPER = 0
                            End If
                        Else
                            CVE_OPER = 0
                        End If
                        If Not IsNothing(Fg(k, 5)) Then
                            NOMBRE_OPER = Fg(k, 5)
                        Else
                            NOMBRE_OPER = ""
                        End If

                        If Not IsNothing(Fg(k, 6)) Then
                            If IsDate(Fg(k, 6)) Then
                                FECHA_IDA = Fg(k, 6)
                            Else
                                FECHA_IDA = "01/01/1900"
                            End If
                        Else
                            FECHA_IDA = "01/01/1900"
                        End If

                        If Not IsNothing(Fg(k, 7)) Then
                            CVE_UNI = Fg(k, 7)
                        Else
                            CVE_UNI = ""
                        End If

                        If Not IsNothing(Fg(k, 8)) Then
                            TIPO_VIAJE = Fg(k, 8)
                        Else
                            TIPO_VIAJE = ""
                        End If

                        If Not IsNothing(Fg(k, 9)) Then
                            CLIENTE = Fg(k, 9)
                        Else
                            CLIENTE = ""
                        End If
                        If Not IsNothing(Fg(k, 10)) Then
                            NOMBRE_CLIE = Fg(k, 10)
                        Else
                            NOMBRE_CLIE = ""
                        End If

                        If Not IsNothing(Fg(k, 11)) Then
                            CVE_ORI = Fg(k, 11)
                        Else
                            CVE_ORI = 0
                        End If
                        If Not IsNothing(Fg(k, 12)) Then
                            ORIGEN = Fg(k, 12)
                        Else
                            ORIGEN = ""
                        End If

                        If Not IsNothing(Fg(k, 13)) Then
                            CVE_DES = Fg(k, 13)
                        Else
                            CVE_DES = 0
                        End If

                        If Not IsNothing(Fg(k, 14)) Then
                            DESTINO = Fg(k, 14)
                        Else
                            DESTINO = ""
                        End If

                        If Not IsNothing(Fg(k, 15)) Then
                            CARGADO_VACIO = IIf(Fg(k, 15) = "CARGADO", 1, 0)
                        Else
                            CARGADO_VACIO = 0
                        End If

                        If Not IsNothing(Fg(k, 16)) Then
                            If IsNumeric(Fg(k, 16)) Then
                                KMS = Fg(k, 16)
                            Else
                                KMS = 0
                            End If
                        Else
                            KMS = 0
                        End If

                        If Not IsNothing(Fg(k, 17)) Then
                            If IsNumeric(Fg(k, 17)) Then
                                RENDIMIENTO = Fg(k, 17)
                            Else
                                RENDIMIENTO = 0
                            End If
                        Else
                            RENDIMIENTO = 0
                        End If
                        If Not IsNothing(Fg(k, 18)) Then
                            If IsNumeric(Fg(k, 18)) Then
                                LITROS = Fg(k, 18)
                            Else
                                LITROS = 0
                            End If
                        Else
                            LITROS = 0
                        End If
                        Try
                            If Not IsNothing(Fg(k, 19)) Then
                                If IsNumeric(Fg(k, 19)) Then
                                    TONELADAS = Fg(k, 19)
                                Else
                                    TONELADAS = 0
                                End If
                            Else
                                TONELADAS = 0
                            End If
                        Catch ex As Exception
                        End Try

                        If NOMBRE_OPER.Trim.Length > 0 Then
                            CVE_OPER = GRABA_OPERADOR(NOMBRE_OPER)
                        End If
                        If ORIGEN.Trim.Length > 0 Then
                            CVE_ORI = GRABA_ORIGEN(ORIGEN)
                        End If
                        If DESTINO.Trim.Length > 0 Then
                            CVE_DES = GRABA_ORIGEN(DESTINO)
                        End If
                        If NOMBRE_CLIE.Trim.Length > 0 Then
                            CLIENTE = GRABA_CLIENTE(NOMBRE_CLIE)
                        End If

                        GRABA_UNIDAD(CVE_UNI)

                        SQL = "SET ansi_warnings OFF
                            UPDATE GCTABULADOR_EXCEL SET FOLIO_LIQ = @FOLIO_LIQ, CVE_OPER = @CVE_OPER, CVE_UNI = @CVE_UNI, 
                            NOMBRE_OPER = @NOMBRE_OPER, TIPO_VIAJE = @TIPO_VIAJE, CLIENTE = @CLIENTE, NOMBRE_CLIE = @NOMBRE_CLIE, 
                            CVE_ORI = @CVE_ORI, ORIGEN = @ORIGEN, CVE_DES = @CVE_DES, DESTINO = @DESTINO, FECHA_IDA = @FECHA_IDA,
                            CARGADO_VACIO = @CARGADO_VACIO, KMS = @KMS, RENDIMIENTO = @RENDIMIENTO, LITROS = @LITROS, 
                            TONELADAS = @TONELADAS
                            OUTPUT INSERTED.CVE_TAB
                            WHERE NUM_VIAJE = @NUM_VIAJE
                            IF @@ROWCOUNT = 0 
                            INSERT INTO GCTABULADOR_EXCEL (CVE_TAB, NUM_VIAJE, STATUS, FOLIO_LIQ, CVE_OPER, CVE_UNI, NOMBRE_OPER, 
                            TIPO_VIAJE, CLIENTE, NOMBRE_CLIE, CVE_ORI, ORIGEN, CVE_DES, DESTINO, CARGADO_VACIO, KMS, RENDIMIENTO, 
                            LITROS, TONELADAS, FECHA_IDA)
                            OUTPUT Inserted.CVE_TAB VALUES(@CVE_TAB, @NUM_VIAJE, 'A', @FOLIO_LIQ, @CVE_OPER, @CVE_UNI, @NOMBRE_OPER, 
                            @TIPO_VIAJE, @CLIENTE, @NOMBRE_CLIE, @CVE_ORI, @ORIGEN, @CVE_DES, @DESTINO, @CARGADO_VACIO, @KMS, 
                            @RENDIMIENTO, @LITROS, @TONELADAS, @FECHA_IDA)"

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_TAB", SqlDbType.Int).Value = CVE_TAB
                            cmd.Parameters.Add("@NUM_VIAJE", SqlDbType.Int).Value = NUM_VIAJE
                            cmd.Parameters.Add("@FOLIO_LIQ", SqlDbType.Int).Value = FOLIO_LIQ
                            cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CVE_OPER
                            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = CVE_UNI
                            cmd.Parameters.Add("@NOMBRE_OPER", SqlDbType.VarChar).Value = NOMBRE_OPER
                            cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.VarChar).Value = TIPO_VIAJE
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = CLIENTE
                            cmd.Parameters.Add("@NOMBRE_CLIE", SqlDbType.VarChar).Value = NOMBRE_CLIE
                            cmd.Parameters.Add("@CVE_ORI", SqlDbType.Int).Value = CVE_ORI
                            cmd.Parameters.Add("@ORIGEN", SqlDbType.VarChar).Value = ORIGEN
                            cmd.Parameters.Add("@CVE_DES", SqlDbType.Int).Value = CVE_DES
                            cmd.Parameters.Add("@DESTINO", SqlDbType.VarChar).Value = DESTINO
                            cmd.Parameters.Add("@KMS", SqlDbType.Float).Value = KMS
                            cmd.Parameters.Add("@CARGADO_VACIO", SqlDbType.SmallInt).Value = CARGADO_VACIO
                            cmd.Parameters.Add("@RENDIMIENTO", SqlDbType.Float).Value = RENDIMIENTO
                            cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = LITROS
                            cmd.Parameters.Add("@TONELADAS", SqlDbType.Float).Value = TONELADAS
                            cmd.Parameters.Add("@FECHA_IDA", SqlDbType.Date).Value = FECHA_IDA
                            returnValue = cmd.ExecuteScalar
                            If returnValue IsNot Nothing Then
                                Fg(k, 1) = returnValue
                            Else
                                Fg(k, 1) = CVE_TAB
                                j += 1
                            End If
                            Fg(k, 4) = CVE_OPER
                            Fg(k, 9) = CLIENTE
                            Fg(k, 11) = CVE_ORI
                            Fg(k, 13) = CVE_DES

                            If Var4 = "B" Then
                                Fg.SetCellStyle(1, 1, newStyle1)
                                z += 1
                            End If
                        End Using
                    End If

                Catch ex As Exception
                    Bitacora("95. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("95. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
            If z > 0 Then
                MsgBox("Se encontraron operadores que estan de baja verifique por favor")
            End If
            ENTRA = True

            MsgBox("Los tabuladores se grabaron satisfactoriamente, registros agregados " & j)

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Me.Fg.Redraw = True
    End Sub
    Private Sub GRABA_UNIDAD(FUNIDAD As String)
        Dim CLAVE As String

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CLAVE = dr("CLAVEMONTE")
                    Else
                        CLAVE = GET_MAX_TRY("GCUNIDADES", "CLAVE")

                        SQL = "SET ansi_warnings OFF
                            INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, DESCR, CVE_TIPO_UNI) VALUES ('" &
                            CLAVE & "','" & FUNIDAD & "','A','" & FUNIDAD & "','1')"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteScalar
                            If returnValue IsNot Nothing Then
                                CLAVE = returnValue
                            End If
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Function GRABA_OPERADOR(FNOMBRE_OPER As String) As Long
        Dim CLAVE As Long
        Try
            Var4 = ""
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE, STATUS FROM GCOPERADOR WHERE NOMBRE = '" & FNOMBRE_OPER & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CLAVE = dr("CLAVE")
                        Var4 = dr("STATUS")
                    Else
                        CLAVE = GET_MAX("GCOPERADOR", "CLAVE")

                        SQL = "INSERT INTO GCOPERADOR (CLAVE, STATUS, NOMBRE) OUTPUT Inserted.CLAVE VALUES ('" & CLAVE & "','A','" & FNOMBRE_OPER & "')"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteScalar
                            If returnValue IsNot Nothing Then
                                CLAVE = returnValue
                            End If
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CLAVE
    End Function
    Private Function GRABA_ORIGEN(FORIGEN As String) As String
        Dim CLAVE As Long
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE FROM GCPLAZAS WHERE CIUDAD = '" & FORIGEN & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CLAVE = dr("CLAVE")
                    Else
                        CLAVE = GET_MAX("GCPLAZAS", "CLAVE")

                        SQL = "INSERT INTO GCPLAZAS (CLAVE, STATUS, CIUDAD) OUTPUT Inserted.CLAVE VALUES ('" & CLAVE & "','A','" & FORIGEN & "')"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteScalar
                            If returnValue IsNot Nothing Then
                                CLAVE = returnValue
                            End If
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return CLAVE
    End Function

    Private Function GRABA_DESTINO(FDESTINO As String) As String
        Dim CLAVE As Long
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE FROM GCPLAZAS WHERE CIUDAD = '" & FDESTINO & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CLAVE = dr("CLAVE")
                    Else
                        CLAVE = GET_MAX("GCPLAZAS", "CLAVE")

                        SQL = "INSERT INTO GCPLAZAS (CLAVE, STATUS, CIUDAD) OUTPUT Inserted.CLAVE VALUES ('" & CLAVE & "','A','" & FDESTINO & "')"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteScalar
                            If returnValue IsNot Nothing Then
                                CLAVE = returnValue
                            End If
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return CLAVE
    End Function

    Private Function GRABA_CLIENTE(FNOMBRE_CLIE) As String
        Dim CLAVE As Long
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE FROM GCCLIE_OP WHERE NOMBRE = '" & FNOMBRE_CLIE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CLAVE = dr("CLAVE")
                    Else
                        CLAVE = GET_MAX_TRY("GCCLIE_OP", "CLAVE")

                        SQL = "INSERT INTO GCCLIE_OP (CLAVE, STATUS, NOMBRE) OUTPUT Inserted.CLAVE VALUES ('" & CLAVE & "','A','" & FNOMBRE_CLIE & "')"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteScalar
                            If returnValue IsNot Nothing Then
                                CLAVE = returnValue
                            End If
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return CLAVE
    End Function
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            If Fg.Row > 0 Then
                Select Case TIPO_TAB
                    Case 0, 2
                        Select Case e.Col
                            Case 1 'OPERADOR
                                Var2 = "Operador"
                                Var4 = "" : Var5 = ""
                                Dim EncEror As Boolean = False
                                Try
                                    frmSelItem.ShowDialog()
                                Catch ex As Exception
                                    EncEror = True
                                End Try
                                If EncEror Then
                                    frmSelItem.Show()
                                    frmSelItem.Select()
                                End If
                                If Var4.Trim.Length > 0 Then
                                    Fg(Fg.Row, 1) = Var4.ToUpper
                                    Fg(Fg.Row, 2) = Var5.ToUpper
                                    Var2 = "" : Var4 = "" : Var5 = ""
                                    Fg.Col = 3
                                Else
                                    Fg.Col = 1
                                End If
                            Case 3 'TRACTOR
                                Var2 = "Unidades"
                                Var4 = "" : Var5 = ""
                                Dim EncEror As Boolean = False
                                Try
                                    frmSelItem.ShowDialog()
                                Catch ex As Exception
                                    EncEror = True
                                End Try
                                If EncEror Then
                                    frmSelItem.Show()
                                    frmSelItem.Select()
                                End If
                                If Var5.Trim.Length > 0 Then
                                    Fg(Fg.Row, 3) = Var5.ToUpper
                                    Var2 = "" : Var4 = "" : Var5 = ""
                                    Fg.Col = 4
                                Else
                                    Fg.Col = 3
                                End If
                            Case 5, 8 'ORIGEN
                                Try
                                    Var15 = "Busqueda"
                                    Var2 = "Plazas"
                                    Var4 = "" : Var5 = ""
                                    Fg.FinishEditing()

                                    Dim EncEror As Boolean = False

                                    Try
                                        frmSelItem.ShowDialog()
                                    Catch ex As Exception
                                        EncEror = True
                                    End Try
                                    If EncEror Then
                                        frmSelItem.Show()
                                        frmSelItem.Select()
                                    End If
                                    If Var4.Trim.Length > 0 Then
                                        If e.Col = 5 Then
                                            Fg(Fg.Row, 4) = Var4
                                            Fg(Fg.Row, 6) = Var5
                                        Else
                                            Fg(Fg.Row, 7) = Var4
                                            Fg(Fg.Row, 9) = Var5
                                        End If
                                        Var2 = "" : Var4 = "" : Var5 = ""
                                        Fg.Col = 13
                                    Else
                                        Fg.Col = 1
                                    End If
                                Catch ex As Exception
                                    Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Case 100
                                'frmTabComCargadoVacio
                                Dim EncEror As Boolean = False
                                Try
                                    frmTabComCargadoVacio.ShowDialog()
                                Catch ex As Exception
                                    EncEror = True
                                End Try
                                If EncEror Then
                                    frmTabComCargadoVacio.Show()
                                    frmTabComCargadoVacio.Select()
                                End If
                                If Var4.Trim.Length > 0 Then
                                    Fg(Fg.Row, 10) = Var4.ToUpper
                                    Var2 = "" : Var4 = "" : Var5 = ""
                                    Fg.Col = 11
                                Else
                                    Fg.Col = 10
                                End If
                            Case 111
                                'full sencillo
                                Dim EncEror As Boolean = False
                                Try
                                    frmFullSencillo.ShowDialog()
                                Catch ex As Exception
                                    EncEror = True
                                End Try
                                If EncEror Then
                                    frmFullSencillo.Show()
                                    frmFullSencillo.Select()
                                End If
                                If Var4.Trim.Length > 0 Then
                                    Fg(Fg.Row, 11) = Var4.ToUpper
                                    Var2 = "" : Var4 = "" : Var5 = ""
                                    Fg.Col = 12
                                Else
                                    Fg.Col = 11
                                End If
                            Case 13 'CLIENTE
                                Try
                                    Var15 = "Busqueda"
                                    Var2 = "Cliente operativo"
                                    Var4 = "" : Var5 = ""
                                    Fg.FinishEditing()
                                    FrmSelItem2.ShowDialog()
                                    If Var4.Trim.Length > 0 Then
                                        Fg(Fg.Row, 12) = Var4
                                        Fg(Fg.Row, 14) = Var5
                                        Var2 = "" : Var4 = "" : Var5 = ""
                                        Fg.Col = 15
                                    Else
                                        Fg.Col = 13
                                    End If
                                Catch ex As Exception
                                    Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("290. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                        End Select
                    Case 1
                        Select Case e.Col
                            Case 4 'OPERADOR
                                Var2 = "Operador"
                                Var4 = "" : Var5 = ""
                                Dim EncEror As Boolean = False
                                Try
                                    frmSelItem.ShowDialog()
                                Catch ex As Exception
                                    EncEror = True
                                End Try
                                If EncEror Then
                                    frmSelItem.Show()
                                    frmSelItem.Select()
                                End If
                                If Var4.Trim.Length > 0 Then
                                    Fg(Fg.Row, 4) = Var4.ToUpper
                                    Fg(Fg.Row, 5) = Var5.ToUpper
                                    Var2 = "" : Var4 = "" : Var5 = ""
                                    Fg.Col = 6
                                Else
                                    Fg.Col = 1
                                End If
                            Case 7 'TRACTOR
                                Var2 = "Unidad"
                                Var4 = "" : Var5 = ""
                                Dim EncEror As Boolean = False
                                Try
                                    frmSelItem.ShowDialog()
                                Catch ex As Exception
                                    EncEror = True
                                End Try
                                If EncEror Then
                                    frmSelItem.Show()
                                    frmSelItem.Select()
                                End If
                                If Var5.Trim.Length > 0 Then
                                    Fg(Fg.Row, 6) = Var5.ToUpper
                                    Var2 = "" : Var4 = "" : Var5 = ""
                                    Fg.Col = 8
                                Else
                                    Fg.Col = 6
                                End If
                            Case 8 'CLIENTE
                                Try
                                    Var15 = "Busqueda"
                                    Var2 = "Cliente operativo"
                                    Var4 = "" : Var5 = ""
                                    Fg.FinishEditing()
                                    FrmSelItem2.ShowDialog()
                                    If Var4.Trim.Length > 0 Then
                                        Fg(Fg.Row, 8) = Var4
                                        Fg(Fg.Row, 9) = Var5
                                        Var2 = "" : Var4 = "" : Var5 = ""
                                        Fg.Col = 10
                                    Else
                                        Fg.Col = 8
                                    End If
                                Catch ex As Exception
                                    Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("290. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Case 11, 13 'ORIGEN
                                Try
                                    Var15 = "Busqueda"
                                    Var2 = "Plazas"
                                    Var4 = "" : Var5 = ""
                                    Fg.FinishEditing()

                                    Dim EncEror As Boolean = False

                                    Try
                                        frmSelItem.ShowDialog()
                                    Catch ex As Exception
                                        EncEror = True
                                    End Try
                                    If EncEror Then
                                        frmSelItem.Show()
                                        frmSelItem.Select()
                                    End If
                                    If Var4.Trim.Length > 0 Then
                                        If e.Col = 11 Then
                                            Fg(Fg.Row, 10) = Var4
                                            Fg(Fg.Row, 11) = Var5
                                        Else
                                            Fg(Fg.Row, 12) = Var4
                                            Fg(Fg.Row, 13) = Var5
                                        End If
                                        Var2 = "" : Var4 = "" : Var5 = ""
                                        Fg.Col = 14
                                    Else
                                        Fg.Col = 10
                                    End If
                                Catch ex As Exception
                                    Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                        End Select
                End Select
            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TMagico2_GotFocus(sender As Object, e As EventArgs) Handles tMagico2.GotFocus
        Try
            Fg.Select()
            Dim c_ As Integer
            If Fg.Col = 1 Then
                c_ = 1
            Else
                c_ = Fg.Col
            End If
            _MyEditorTab.StartEditing(Fg.Row, c_, 98)
        Catch ex As Exception
            Bitacora("1450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAltaProducto_Click(sender As Object, e As EventArgs) Handles btnAltaProducto.Click
        Try
            Select Case TIPO_TAB
                Case 0, 2
                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                          "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                    Fg.Select()
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 1
                    _MyEditorTab.StartEditing(1, 1)
                Case 1
                    Fg.AddItem("" & vbTab & "0" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "0" & vbTab & "0" & vbTab & "0" & vbTab & "0")
                    Fg.Select()
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 1
            End Select
        Catch ex As Exception
            Bitacora("1450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnEliProd_Click(sender As Object, e As EventArgs) Handles btnEliProd.Click
        Try
            If Fg.Row > 0 Then
                Select Case TIPO_TAB
                    Case 0, 2
                        If MsgBox("Realmente desea cancelar la partida seleccionada?", vbYesNo) = vbYes Then
                            Fg.RemoveItem(Fg.Row)
                            Fg.Select()
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.Col = 1
                            _MyEditorTab.StartEditing(Fg.Row, 1)
                        End If
                    Case 1
                        If MsgBox("Realmente desea eliminar el tabulador seleccionada?", vbYesNo) = vbYes Then
                            Try
                                Dim SIOK As Boolean = False, CVE_RESET As Long = 0

                                If Not IsNothing(Fg(Fg.Row, 20)) Then
                                    If IsNumeric(Fg(Fg.Row, 20)) Then
                                        CVE_RESET = CLng(Fg(Fg.Row, 20))
                                    End If
                                End If
                                If CVE_RESET > 0 Then
                                    MsgBox("El tabulador de combustible tiene asignado un reseteo, no es posible cancelarlo, verifique por favor")
                                    Return
                                Else
                                    If Not IsNothing(Fg(Fg.Row, 1)) Then
                                        If IsNumeric(Fg(Fg.Row, 1)) Then
                                            SQL = "DELETE FROM GCTABULADOR_EXCEL WHERE CVE_TAB = " & CLng(Fg(Fg.Row, 1))
                                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                                cmd.CommandText = SQL
                                                returnValue = cmd.ExecuteNonQuery
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                        Fg.RemoveItem(Fg.Row)
                                                        Fg.Select()
                                                        Fg.Row = Fg.Rows.Count - 1
                                                        Fg.Col = 1
                                                        SIOK = True
                                                    End If
                                                End If
                                            End Using
                                        End If
                                    End If
                                    If SIOK Then
                                        MsgBox("El tabulador de elimino correctamente")
                                    Else
                                        MsgBox("No se logro eliminar el tabulador")
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("880. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("880. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                End Select
            Else
                MsgBox("Por favor seleccione un tabulador")
            End If
        Catch ex As Exception
            Bitacora("880. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("880. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>'>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>'>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 

    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> EVENTOS FG INCIIA

    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>'>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>'>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
    Private Sub Fg_AfterScroll(sender As Object, e As RangeEventArgs) Handles Fg.AfterScroll
        If ENTRA Then
            Select Case TIPO_TAB
                Case 0, 2
                    If _MyEditorTab.Visible Then
                        _MyEditorTab.UpdatePosition()
                    End If
            End Select
        End If
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If ENTRA Then
                If Fg.Row > 0 Then
                    If TIPO_TAB = 0 Then
                        '1	3	4   5   7   8   10  11  12  13	15	16
                        If Fg.Col = 1 Or Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 7 Or Fg.Col = 8 Or Fg.Col = 10 Or Fg.Col = 11 Or
                            Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 15 Or Fg.Col = 16 Or Fg.Col = 18 Or Fg.Col = 20 Then
                            e.Cancel = False
                        Else
                            e.Cancel = True
                        End If
                    Else
                        If Fg.Col = 1 Or Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 7 Or Fg.Col = 8 Or Fg.Col = 10 Or Fg.Col = 11 Or
                            Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 15 Or Fg.Col = 16 Or Fg.Col = 18 Or Fg.Col = 20 Then
                            e.Cancel = False
                        Else
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("1200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown

        Select Case TIPO_TAB
            Case 0, 2
                Select Case e.KeyCode
                    Case Keys.Enter
                        Select Case Fg.Selection.c1
                            Case 7
                                Fg.StartEditing(Fg.Selection.BottomRow, 2)
                                e.SuppressKeyPress = True
                                e.Handled = True
                        End Select
                End Select
        End Select
    End Sub
    Private Sub Fg_MouseMove(sender As Object, e As MouseEventArgs) Handles Fg.MouseMove

        Select Case TIPO_TAB
            Case 0, 2
                Var20 = e.X
                Var21 = MainRibbonForm.c1Ribbon1.Height + BarraMenu.Height + e.Y
        End Select
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If ENTRA Then
                Select Case TIPO_TAB
                    Case 0, 2
                        If Fg.Col = 10 Or Fg.Col = 11 Then
                            Return
                        End If

                        '1	3	4  5    7   8   10  11  12  13  15	16
                        If Fg.Col = 1 Or Fg.Col = 2 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 7 Or Fg.Col = 8 Or Fg.Col = 10 Or
                            Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 15 Or Fg.Col = 16 Or Fg.Col = 18 Or Fg.Col = 20 Then
                            'start editing the cell with the custom editor
                            Dim c_ As Integer
                            If Fg.Col = 1 Then
                                c_ = 1
                            Else
                                c_ = Fg.Col
                            End If
                            _MyEditorTab.StartEditing(Fg.Row, c_)
                            'cancel built -in editor
                        End If
                End Select
            End If
        Catch ex As Exception
            Bitacora("1200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                Select Case TIPO_TAB
                    Case 0, 2
                        If Fg.Col <> 10 And Fg.Col <> 11 Then
                            ENTRA_COMBO = True
                        End If
                        '1	3	4  5    7   8   10  11  12  13  15	16
                        If Fg.Col = 1 Or Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 7 Or Fg.Col = 8 Or Fg.Col = 10 Or
                            Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 15 Or Fg.Col = 16 Or Fg.Col = 18 Or Fg.Col = 20 Then
                            Dim c_ As Integer
                            If Fg.Col = 1 Then
                                c_ = 1
                            Else
                                c_ = Fg.Col
                            End If
                            _MyEditorTab.StartEditing(Fg.Row, c_)
                        End If
                End Select
            End If
        Catch ex As Exception
            Bitacora("1190. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        Select Case TIPO_TAB
            Case 0, 2
                If ENTRA And Fg.Col <> 6 Then
                    _MyEditorTab.SetPendingKey(e.KeyChar)
                End If
        End Select
    End Sub
    Private Sub Fg_ComboCloseUp(sender As Object, e As RowColEventArgs) Handles Fg.ComboCloseUp
        'Fg.Col = 11
    End Sub
    Private Sub Fg_SetupEditor(sender As Object, e As RowColEventArgs) Handles Fg.SetupEditor
        Select Case TIPO_TAB
            Case 0, 2
                If ENTRA And (e.Col = 10 Or e.Col = 11) And ENTRA_COMBO Then
                    ENTRA_COMBO = False
                    Dim combo As ComboBox = CType(Fg.Editor, ComboBox)
                    combo.DroppedDown = True
                End If
        End Select
    End Sub
    Private Sub Fg_AfterSelChange(sender As Object, e As RangeEventArgs) Handles Fg.AfterSelChange

        Select Case TIPO_TAB
            Case 0, 2
                If ENTRA And (Fg.Col = 10 Or Fg.Col = 11) Then
                    Fg.StartEditing()
                End If
        End Select
    End Sub
    Private Sub Fg_StartEdit(sender As Object, e As RowColEventArgs) Handles Fg.StartEdit
        Try
            If ENTRA Then
                Select Case TIPO_TAB
                    Case 0, 2
                        If Fg.Col = 10 Or Fg.Col = 11 Then
                            Return
                        End If
                        '1	3	4  5    7   8   10  11  12  13  15	16
                        If Fg.Col = 1 Or Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 7 Or Fg.Col = 8 Or Fg.Col = 10 Or
                            Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 15 Or Fg.Col = 16 Or Fg.Col = 18 Or Fg.Col = 20 Then
                            'start editing the cell with the custom editor
                            '_myEditor.StartEditing(e.Row, e.Col)
                            'cancel built-in editor
                            e.Cancel = True
                        Else
                            e.Cancel = True
                        End If
                End Select
            End If
        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_MouseEnterCell(sender As Object, e As RowColEventArgs) Handles Fg.MouseEnterCell
        Try
            Select Case TIPO_TAB
                Case 0, 2
                    If Fg.Col = 10 Then
                        Fg.Col = 10
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        Select Case TIPO_TAB
            Case 0, 2
                DESPLEGAR_PAR()
            Case 1
                DESPLEGAR_VIKINGOS()
        End Select
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        'VIKINGOS
        Dim NUM_VIAJE As Long, s As String
        Try
            Var2 = "" : Var4 = ""
            FrmExcel.ShowDialog()

            If Var2.Trim.Length > 0 And Var4.Trim.Length > 0 Then
                C1XLBook1.Clear()
                C1XLBook1.Load(Var2)
                Dim source As XLSheet = C1XLBook1.Sheets(Var4)
                Me.Cursor = Cursors.WaitCursor
                Fg.Cursor = Cursors.WaitCursor
                'Fg(0, 1) = "Clave"
                'Fg(0, 2) = "Num. viaje"
                'Fg(0, 3) = "Folio"
                'Fg(0, 4) = "Clave oper"
                'Fg(0, 6) = "Nombre operador"
                'Fg(0, 5) = "Unidad"
                'Fg(0, 7) = "Tipo viaje"
                'Fg(0, 8) = "Cliente"
                'Fg(0, 9) = "Nombre del cliente"
                'Fg(0, 10) = "Cve. origen"
                'Fg(0, 11) = "Descripción origen"
                'Fg(0, 12) = "Cve. destino"
                'Fg(0, 13) = "Descripción destino"
                'Fg(0, 14) = "Cargado vacio"
                'Fg(0, 15) = "Kms"
                'Fg(0, 16) = "Rendimiento"b
                'Fg(0, 17) = "Litros"
                'Fg(0, 18) = "Toneladas"
                Fg.Redraw = False
                For row = 2 To source.Rows.Count - 1
                    Application.DoEvents()
                    If Not IsNothing(source(row, 0).Value) Then
                        If IsNumeric(source(row, 0).Value) Then
                            NUM_VIAJE = source(row, 0).Value
                        Else
                            NUM_VIAJE = 0
                        End If
                    Else
                        NUM_VIAJE = 0
                    End If
                    If NUM_VIAJE > 0 Then
                        If Not EXISTE_VIKINGOS(NUM_VIAJE) Then
                            'Fg.AddItem("" & vbTab & dr("CVE_TAB") & vbTab & dr("NUM_VIAJE") & vbTab & dr("FOLIO_LIQ") & vbTab &
                            'dr("CVE_OPER") & vbTab & dr.ReadNullAsEmptyString("NOMBRE_OPER") & vbTab &
                            'IIf(dr("F_IDA") = "01/01/1900", "", dr("F_IDA")) & vbTab & dr.ReadNullAsEmptyString("CVE_UNI") & vbTab &
                            'dr.ReadNullAsEmptyString("TIPO_VIAJE") & vbTab & dr("CLIENTE") & vbTab & dr("NOMBRE_CLIE") & vbTab &
                            'dr("CVE_ORI") & vbTab & dr.ReadNullAsEmptyString("ORIGEN") & vbTab & dr("CVE_DES") & vbTab &
                            'dr.ReadNullAsEmptyString("DESTINO") & vbTab & IIf(dr.ReadNullAsEmptyInteger("CARGADO_VACIO") = 0, "Vacio", "Cargado") & vbTab &
                            'dr("KMS") & vbTab & dr.ReadNullAsEmptyDecimal("RENDIMIENTO") & vbTab &
                            'dr("LITROS") & vbTab & dr.ReadNullAsEmptyDecimal("TONELADAS") & vbTab & IIf(dr("CVE_RESET") = 0, "", dr("CVE_RESET")))
                            '                                       A                          C  
                            s = "" & vbTab & "" & vbTab & source(row, 0).Value & vbTab & source(row, 2).Value & vbTab & "" & vbTab
                            '              D                             E                             G
                            s &= source(row, 4).Value & vbTab & source(row, 5).Value & vbTab & source(row, 3).Value & vbTab
                            '             H                                           I
                            s &= source(row, 7).Value & vbTab & "" & vbTab & source(row, 8).Value & vbTab & "" & vbTab
                            '             J                                             K                              
                            s &= source(row, 12).Value & vbTab & "" & vbTab & source(row, 13).Value & vbTab & source(row, 47).Value & vbTab

                            s &= source(row, 44).Value & vbTab & source(row, 45).Value & vbTab & source(row, 46).Value
                            Fg.AddItem(s)
                        End If
                    End If
                Next row

                Fg.AutoSizeCols()
                Fg.Cols(6).Width = 100
                Fg.Redraw = True
            End If

        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default

    End Sub
    Private Function EXISTE_VIKINGOS(FNUM_VIAJE As Long) As Boolean
        Dim Existe As Boolean = False
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 2) = FNUM_VIAJE Then
                    Existe = True
                End If
            Next
        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return Existe
    End Function
    Sub TITULOS()
        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 21

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Num. viaje"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Int32)

            Fg(0, 3) = "No. liquidación"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Int32)

            Fg(0, 4) = "Clave oper"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Int32)

            Fg(0, 5) = "Nombre operador"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Fecha ida"
            Dim c66 As Column = Fg.Cols(6)
            c66.DataType = GetType(Date)

            Fg(0, 7) = "Unidad"
            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(String)

            Fg(0, 8) = "Tipo viaje"
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(String)

            Fg(0, 9) = "Cliente"
            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(String)

            Fg(0, 10) = "Nombre del cliente"
            Dim c9 As Column = Fg.Cols(10)
            c9.DataType = GetType(String)

            Fg(0, 11) = "Cve. origen"
            Dim c10 As Column = Fg.Cols(11)
            c10.DataType = GetType(Int32)

            Fg(0, 12) = "Descripción origen"
            Dim c11 As Column = Fg.Cols(12)
            c11.DataType = GetType(String)

            Fg(0, 13) = "Cve. destino"
            Dim c12 As Column = Fg.Cols(13)
            c12.DataType = GetType(Int32)

            Fg(0, 14) = "Descripción destino"
            Dim c13 As Column = Fg.Cols(14)
            c13.DataType = GetType(String)

            Fg(0, 15) = "Cargado vacio"
            Dim c14 As Column = Fg.Cols(15)
            c14.DataType = GetType(String)

            Fg(0, 16) = "Kms"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 17) = "Rendimiento"
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 18) = "Litros"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 19) = "Toneladas"
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(Decimal)
            Fg.Cols(18).Format = "###,###,##0.00"

            Fg(0, 20) = "Reseteo"
            Dim c19 As Column = Fg.Cols(20)
            c19.DataType = GetType(String)



            Fg.Cols(8).ComboList = "|Full|Sencillo"
            Fg.Cols(15).ComboList = "|Cargado|Vacio"

        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub BarExportarExcel_Click(sender As Object, e As EventArgs) Handles BarExportarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Tabaulador de combustible")
    End Sub
End Class


'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditorTab
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean

    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid, MyImporte As Single)
        MyBase.New()
        Visible = False
        AutoSize = False
        BackColor = Color.Beige
        BorderStyle = BorderStyle.FixedSingle

        _pendingKey = Chr(0)
        _cancel = False
        _owner = owner
        _owner.Controls.Add(Me)
    End Sub

    'comenzar a editar: mover a la celda y activar
    '
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        'save coordinates of cell being edited
        'guardar las coordenadas de la celda que se está editando
        Dim PRECIO As Single

        If (col = 1) And keyRec = 9 Then
            If IsNothing(_owner(_row, 1)) Then
                MyBase.Visible = True
                _owner.Select()
                _owner.StartEditing()
                Return
            End If
        End If
        If col = 1 And keyRec = 99 Then
            _owner.Select(1, 1)
            _owner.Row = 1
            _owner.Col = 1
            MoveCursor(Keys.Enter)
            _owner.Rows.Count = 2
            Return
        End If
        If (col = 1) And keyRec = 198 Then
            MyBase.Visible = True
            _owner.Select(1, 1)
            _owner.Row = 1
            _owner.Col = 1
            '_owner.StartEditing()
            Return
        End If
        'N  N      N        N    N   N       N 
        '1	3	4  5    7   8   10  11  12  13  15	16
        If col = 4 Or col = 7 Or col = 12 Or col = 15 Or col = 16 Or col = 18 Or col = 20 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmTabuladorCombustibleAE.tMagico2.Focus()
                MyBase.Visible = True
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If

            _row = row
            _col = col
            'assume we'll save the edits
            'supongamos que guardaremos las ediciones
            _cancel = False
            'move editor over the current cell
            'mover editor sobre la celda actual
            Dim rc As Rectangle = _owner.GetCellRect(row, col, True)
            rc.Width = rc.Width - 1
            rc.Height = rc.Height - 1

            MyBase.Bounds = rc
            'initialize control content
            'inicializar contenido de control
            If col = 131 Then
                'PRECIO
            End If
            MyBase.Text = ""

            If _pendingKey > " " Then
                MyBase.Text = _pendingKey.ToString()
            ElseIf Not _owner(row, col) Is Nothing Then
                If col = 11 Or col = 12 Then
                    Try
                        If IsNumeric(_owner(row, col)) Then
                            PRECIO = _owner(row, col)
                            PRECIO = Math.Round(PRECIO, 4)
                        Else
                            PRECIO = 0
                        End If
                        MyBase.Text = PRECIO
                    Catch ex As Exception
                    End Try
                Else
                    MyBase.Text = _owner(row, col).ToString()
                End If
            End If
            MyBase.Select(Text.Length, 0)
            'make editor visible
            MyBase.Visible = True
            'and get the focus
            '_owner.Select(_row, 2)
            MyBase.Select()
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = MyBase.TextLength
        End If

    End Sub
    Public Sub EndEdit(ByVal row As Integer, ByVal col As Integer)
        Try
            _owner.FinishEditing()
            _owner(row, col) = ""
            MyBase.Text = ""
        Catch ex As Exception
            Bitacora("1620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)
        'N  N      N        N    N   N       N 
        '1	3	4  5    7   8   10  11  12  13  15	16
        If col = 4 Or col = 7 Or col = 12 Or col = 15 Or col = 16 Or col = 18 Or col = 20 Then
            MyBase.Visible = True
        End If
    End Sub
    'guardar clave que inició el modo de edición
    Public Sub SetPendingKey(ByVal chr As Char)
        _pendingKey = chr
    End Sub

    'move editor after the grid has scrolled
    'mover editor después de que la cuadrícula se haya desplazado
    Public Sub UpdatePosition()
        'get cell rect now
        'obtener celular ahora
        Dim rcCell As Rectangle = _owner.GetCellRect(_row, _col, False)

        'intersect with scrollable part of the grid
        'intersectarse con parte desplazable de la cuadrícula
        Dim rcScroll As Rectangle = _owner.ClientRectangle
        rcScroll.X = _owner.Cols(_owner.Cols.Fixed).Left
        rcScroll.Y = _owner.Rows(_owner.Rows.Fixed).Top
        rcScroll.Width = rcScroll.Width - rcScroll.X
        rcScroll.Height = rcScroll.Height - rcScroll.Y
        rcCell = Rectangle.Intersect(rcCell, rcScroll)

        'y mueve el control
        If (rcCell.Width > 0) Then rcCell.Width = rcCell.Width - 1
        If (rcCell.Height > 0) Then rcCell.Height = rcCell.Height - 1
        MyBase.Bounds = rcCell
    End Sub

    'Foco perdido: ocultar el editor
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)

        If _col <> 1 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmTabuladorCombustibleAE.tMagico2.Focus()
                _owner.Select()
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If
        End If

        Try
            If _col = 4 Then 'origen
                Try
                    If Not IsNothing(MyBase.Text) Then
                        Dim DESCR As String
                        DESCR = BUSCA_CAT("Plazas", MyBase.Text)
                        If DESCR <> "" And DESCR <> "N" Then
                            _owner(_row, 6) = DESCR
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("1630. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1630. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If _col = 7 Then 'destino
                Try
                    If Not IsNothing(MyBase.Text) Then
                        Dim DESCR As String
                        DESCR = BUSCA_CAT("Plazas", MyBase.Text)
                        If DESCR <> "" And DESCR <> "N" Then
                            _owner(_row, 9) = DESCR
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("1630. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1630. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            'aqui esta el error
            If _col = 22 Then
                If IsNothing(_owner(_row, 2)) Then
                    MyBase.Visible = True
                    _owner.Select()
                    _owner.Select(_row, 2)
                    _owner.StartEditing()
                    Return
                End If
                If _owner(_row, _col) = "" Then
                    MyBase.Visible = True
                    Return
                End If
            End If
            If _col = 11 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 12)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim C1 As Decimal
                                        C1 = _owner(_row, 13) * MyBase.Text
                                        _owner(_row, 13) = C1
                                    Catch ex As Exception
                                        _owner(_row, 13) = _owner(_row, 11) * _owner(_row, 12)
                                    End Try
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            End If
            If _col = 15 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 16)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim C1 As Decimal
                                        C1 = MyBase.Text / _owner(_row, 16)
                                        _owner(_row, 17) = C1
                                    Catch ex As Exception
                                    End Try
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If _col = 16 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 16)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim C1 As Decimal
                                        C1 = _owner(_row, 15) / MyBase.Text
                                        _owner(_row, 17) = C1
                                    Catch ex As Exception
                                    End Try
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1635. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            'procesamiento base
            MyBase.OnLeave(e)

            'copiar texto a la cuadrícula del propietario
            If Not _cancel Then
                _owner(_row, _col) = MyBase.Text
            End If

            'no más claves pendientes
            _pendingKey = Chr(0)

            'hecho por ahora, ocultar editor
            MyBase.Visible = False
        Catch ex As Exception
            Bitacora("1650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("940. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub
    'manejaremos la tecla de tabulación nosotros mismos
    Protected Overrides Function IsInputkey(ByVal keydata As Keys) As Boolean
        If keydata = Keys.Tab Or keydata = Keys.Enter Then
            Return True
        End If
        Return MyBase.IsInputKey(keydata)
    End Function

    'algunas teclas finalizan la edición
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)

        Select Case e.KeyCode
            Case Keys.Escape
                _cancel = True
                _owner.Select()
                e.Handled = True
            Case Keys.Enter, Keys.Tab, Keys.Up, Keys.Down, Keys.PageUp, Keys.PageDown, Keys.Left, Keys.Right
                _owner.Select()
                e.Handled = True
                MoveCursor(e.KeyCode)
            Case Keys.F2
                If _col = 1 Or _col = 4 Or _col = 8 Then
                    Try  'ORIGEN
                        Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        Select Case _col
                            Case 1 'operador
                                Var2 = "Operador"
                                frmSelItem.ShowDialog()
                            Case 3 'tractor
                                Var2 = "Unidades"
                                frmSelItem.ShowDialog()
                            Case 4
                                Var2 = "Plazas"
                                frmSelItem.ShowDialog()
                            Case 7
                                Var2 = "Plazas"
                                frmSelItem.ShowDialog()
                            Case 12
                                Var2 = "Cliente operativo"
                                frmSelItem2.ShowDialog()
                        End Select
                        If Var4.Trim.Length > 0 Then
                            Select Case _col
                                Case 1
                                    _owner(_row, _col) = Var4
                                    _owner.Col = 3
                                Case 3
                                    _owner(_row, _col) = Var4
                                    _owner.Col = 4
                                Case 4
                                    _owner(_row, _col) = Var4
                                    _owner(_row, _col + 1) = Var5
                                    _owner.Col = 7
                                Case 5
                                    _owner(_row, _col) = Var4
                                    _owner.Col = 7
                                Case 8
                                    _owner(_row, _col) = Var4
                                    _owner.Col = 10
                                Case 10
                                    _owner(_row, _col) = Var4
                                    _owner.Col = 11
                                Case 11
                                    _owner(_row, _col) = Var4
                                    _owner.Col = 12
                                Case 13
                                    _owner(_row, _col) = Var4
                                    _owner.Col = 15
                            End Select
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("1750. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("1750. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub

    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col

        If col = 1 And key = Keys.Left Then
            frmTabuladorCombustibleAE.tMagico2.Focus()
            Return
        End If

        Select Case key
            Case Keys.Tab, Keys.Enter

            Case Keys.Up
                If _owner.Row = 1 Then
                    frmTabuladorCombustibleAE.tMagico2.Focus()
                    Return
                End If
                If IsNothing(_owner(_row, 2)) Then
                    If IsNothing(_owner(_row, 4)) Then
                        _owner.RemoveItem(_owner.Row)
                        row = _owner.Rows.Count - 1
                        Return
                    Else
                        If _owner(_row, 4).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                Else
                    If IsNothing(_owner(_row, 4)) Then
                        If _owner(_row, 2).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                End If

                If row > 1 Then
                    row = row - 1
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                Else
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                End If
            Case Keys.Down
                If _owner.Rows.Count - 1 = row Then
                    Select Case col
                        Case 1
                            If IsNothing(_owner(_row, 1)) Then
                                frmTabuladorCombustibleAE.tMagico2.Focus()
                            Else
                                If FgEdit Then
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                   "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                   "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0")
                                    _owner.Select(row + 1, 1)
                                Else
                                    frmTabuladorCombustibleAE.tMagico2.Focus()
                                    _owner.Select(row, 1)
                                End If
                            End If
                        Case 4, 7, 8, 11, 12
                            frmTabuladorCombustibleAE.tMagico2.Focus()
                    End Select
                    Return
                Else
                    row = row + 1
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                End If
            Case Keys.PageUp
                row -= 10
            Case Keys.PageUp
                row += 10
            Case Keys.Left
                If col >= 1 Then
                    Select Case col
                        Case 1
                            If IsNothing(_owner(_row, 1)) Then
                                If IsNothing(_owner(_row, 3)) Then
                                    If _owner.Rows.Count - 1 <> 1 Then
                                        _owner.RemoveItem(_owner.Row)
                                        row = _owner.Rows.Count - 1
                                    End If
                                    Return
                                Else
                                    If _owner(_row, 1).ToString.Length = 0 Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                            row = _owner.Rows.Count - 1
                                        End If
                                        Return
                                    End If
                                End If
                            Else
                                If IsNothing(_owner(_row, 3)) Then
                                    If _owner(_row, 1).ToString.Length = 0 Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                            row = _owner.Rows.Count - 1
                                        End If
                                        Return
                                    End If
                                End If
                            End If
                            If row = 1 Then
                                row = _owner.Rows.Count - 1
                            Else
                                row = row - 1
                            End If
                            col = 1
                        Case 3
                            col = 1
                        Case 4
                            col = 3
                        Case 7
                            col = 4
                        Case 10
                            col = 7
                        Case 11
                            col = 10
                        Case 12
                            col = 11
                        Case 15
                            col = 12
                        Case 16
                            col = 15
                    End Select
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
                Return
            Case Keys.Right
                If col <= 13 Then
                    Select Case col
                        Case 1
                            'CORREGIR AQUI
                            If IsNothing(_owner(_row, 1)) Then
                                frmTabuladorCombustibleAE.tMagico2.Focus()
                                '_owner.Select()
                                '_owner.Select(row, col)
                                '_owner.StartEditing()
                                Return
                            End If
                            If MyBase.Text.ToString.Length = 0 Then
                                _owner.Select()
                                _owner.Select(row, col)
                                _owner.StartEditing()
                                Return
                            End If
                            col = 3
                        Case 3
                            col = 4
                        Case 4
                            If IsNothing(_owner(_row, 1)) Then
                                frmTabuladorCombustibleAE.tMagico2.Focus()
                                Return
                            End If
                            If MyBase.Text.ToString.Length = 0 Then
                                frmTabuladorCombustibleAE.tMagico2.Focus()
                                Return
                            End If
                            col = 7
                        Case 7
                            col = 10
                        Case 10
                            col = 11
                        Case 11
                            col = 12
                        Case 12
                            col = 15
                        Case 15
                            col = 16
                        Case 16
                            col = 18
                        Case 18
                            col = 20
                        Case 20
                            col = 1
                    End Select
                Else
                    col = 1
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
        End Select

        'validar nueva selección
        If (row < _owner.Rows.Fixed) Then row = _owner.Rows.Fixed
        If (col < _owner.Cols.Fixed) Then col = _owner.Cols.Fixed
        If (row > _owner.Rows.Count - 1) Then row = _owner.Rows.Count - 1
        If (col > _owner.Cols.Count - 1) Then col = _owner.Cols.Count - 1

        'aplicar nueva selección        7
        _owner.Select(_row, _col)

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        Dim HayErr As Boolean

        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)
                    Select Case _col
                        Case 4, 7 'ORIGEN
                            Dim Descr As String
                            If MyBase.Text.Trim.Length = 0 Then
                                frmTabuladorCombustibleAE.tMagico2.Select()
                                Return
                            End If
                            Var9 = "" : Var22 = 0 : Var4 = ""
                            Descr = BUSCA_CAT("Plazas", MyBase.Text)
                            If Descr.Trim.Length = 0 Or Descr = "N" Then

                                MsgBox("Plaza inexistente")
                                frmTabuladorCombustibleAE.tMagico2.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            Else
                                If _col = 4 Then
                                    _owner(_row, 6) = Descr
                                    _owner.Col = 7
                                Else
                                    _owner(_row, 9) = Descr
                                    _owner.Col = 10
                                End If
                                _owner.StartEditing()
                                Return
                            End If
                        Case 10
                            _owner.Col = 11
                            _owner.StartEditing()
                            Return
                        Case 11
                            _owner.Col = 12
                            _owner.StartEditing()
                            Return
                        Case 12
                            Dim Descr As String
                            If MyBase.Text.Trim.Length = 0 Then
                                frmTabuladorCombustibleAE.tMagico2.Focus()
                                Return
                            End If
                            Var9 = "" : Var22 = 0 : Var4 = ""
                            Descr = BUSCA_CAT("Cliente operativo", MyBase.Text)
                            If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                MsgBox("Cliente inexistente")
                                frmTabuladorCombustibleAE.tMagico2.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                            Else
                                _owner(_row, 14) = Descr
                                _owner.Col = 15
                                _owner.StartEditing()
                            End If
                            Return
                        Case 15
                            If Not IsNothing(_owner(_row, _col)) Then
                                If _owner(_row, _col).ToString.Trim.Length = 0 Then
                                    _owner.Row = _row
                                    _owner.Col = col
                                    _owner.Row = _row
                                    _owner.StartEditing()
                                    Return
                                Else
                                    _owner.Col = 16
                                    _owner.StartEditing()
                                    Return
                                End If
                            Else
                                '_owner.Select()
                                '_owner.Row = _row
                                '_owner.Col = col
                                '_owner.StartEditing()
                                'Return
                            End If
                    End Select
                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 1
                            _owner.Select(row, col + 2)
                        Case 3
                            _owner.Select(row, col + 1)
                        Case 4
                            _owner.Select(row, col + 3)
                        Case 7
                            _owner.Select(row, col + 3)
                        Case 8
                            _owner.Select(row, col + 2)
                        Case 10
                            _owner.Select(row, col + 1)
                        Case 11
                            _owner.Select(row, col + 1)
                        Case 12
                            _owner.Select(row, col + 3)
                        Case 15
                            Try
                                If Not IsNothing(_owner(_row, _col)) Then
                                    If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                        If IsNumeric(_owner(_row, 12)) Then
                                            If IsNumeric(MyBase.Text) Then
                                                Try
                                                    Dim C1 As Decimal
                                                    C1 = MyBase.Text / _owner(_row, 16)
                                                    _owner(_row, 17) = C1
                                                Catch ex As Exception
                                                End Try
                                            End If
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("1855. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            _owner.Select(row, col + 1)
                        Case 16
                            Try
                                If Not IsNothing(_owner(_row, _col)) Then
                                    If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                        If IsNumeric(_owner(_row, 11)) Then
                                            If IsNumeric(MyBase.Text) Then
                                                Try
                                                    Dim C1 As Decimal
                                                    C1 = _owner(_row, 15) / MyBase.Text
                                                    _owner(_row, 17) = C1
                                                Catch ex As Exception
                                                End Try
                                            End If
                                        End If
                                    End If
                                End If
                                _owner.Select(row, col + 1)
                            Catch ex As Exception
                                Bitacora("1860. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("1860. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Case 16
                            Try
                                HayErr = False
                                Try
                                    _owner.Select(row + 1, 1)
                                Catch ex As Exception
                                    HayErr = True
                                End Try
                                If HayErr Then
                                    If FgEdit Then
                                        '                           1             2           3             4            5           6          7           8     9   10     11     12 		13
                                        '                         origen... descr  destino ... descr  cargado/vacio	cliente ... nombre	kms	rendimiento lts
                                        _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                       "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
                                        _owner.Select(row + 1, 1)
                                    End If
                                Else
                                End If
                            Catch ex As Exception
                                Bitacora("1860. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("1860. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                    _owner.StartEditing()
                    Return

                Case Else
                    If _col = 1 Then
                        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                            e.KeyChar = ""
                            Return
                        End If

                    End If
            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            Bitacora("1870. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1870. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class

