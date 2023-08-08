Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Public Class FrmProgPedidosAE
    Private SERIE_PEDIDO As String
    Private DOCNEW As Boolean
    Private EditPed As Boolean
    Private Entra As Boolean
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        CARGAR_DATOS1()
        CARGAR_DATOS2()

        Me.ResumeLayout()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmProgPedidosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            F1.Value = Date.Today
            F1.Tag = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat

            F2.Value = Date.Today
            F2.Tag = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat

            Me.CenterToScreen()
            Me.KeyPreview = True
            LtFecha.Text = Now

            BtnContrato.FlatStyle = FlatStyle.Flat
            BtnContrato.FlatAppearance.BorderSize = 0
            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0
            BtnCLAVE_REM.FlatStyle = FlatStyle.Flat
            BtnCLAVE_REM.FlatAppearance.BorderSize = 0
            BtnPlaza.FlatStyle = FlatStyle.Flat
            BtnPlaza.FlatAppearance.BorderSize = 0
            BtnRecogerEn.FlatStyle = FlatStyle.Flat
            BtnRecogerEn.FlatAppearance.BorderSize = 0
            BtnProducto.FlatStyle = FlatStyle.Flat
            BtnProducto.FlatAppearance.BorderSize = 0
            BtnTractor.FlatStyle = FlatStyle.Flat
            BtnTractor.FlatAppearance.BorderSize = 0
            BtnTanque1.FlatStyle = FlatStyle.Flat
            BtnTanque1.FlatAppearance.BorderSize = 0
            BtnTanque2.FlatStyle = FlatStyle.Flat
            BtnTanque2.FlatAppearance.BorderSize = 0
            BtnCLAVE_DEST.FlatStyle = FlatStyle.Flat
            BtnCLAVE_DEST.FlatAppearance.BorderSize = 0
            BtnPlaza2.FlatStyle = FlatStyle.Flat
            BtnPlaza2.FlatAppearance.BorderSize = 0
            BtnEntregarEn.FlatStyle = FlatStyle.Flat
            BtnEntregarEn.FlatAppearance.BorderSize = 0

        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            TCVE_OBS.Tag = "0"
            tCLAVE_O.Text = "" : TCLAVE_D.Text = "" : tCLAVE_O.Tag = "" : TCLAVE_D.Tag = "" : TCVE_RUTA.Text = "" : LtRuta1.Text = ""
            TRUTA_SEN_VAC.Text = "" : TRUTA_SE_CAR.Text = "" : TRUTA_FULL_VAC.Text = "" : TRUTAL_FULL_CAR.Text = "" : TNOTA.Text = ""
            TRECOGER_EN.Text = "" : TENTREGAR_EN.Text = "" : TValorDeclarado.Text = "" : TCVE_OBS.Text = ""
            Lt1.Text = "" : LtValorDeclarado.Text = "" : LtNombre1.Text = "" : LtNombre2.Text = "" : TCVE_ART.Text = ""

            AssignValidation(Me.TValorDeclarado, ValidationType.Only_Numbers)
            AssignValidation(Me.tCopias, ValidationType.Only_Numbers)

            TCVE_TRACTOR.Text = ""
            TCVE_TANQUE1.Text = ""
            TCVE_TANQUE2.Text = ""

            TCVE_TRACTOR.Tag = ""
            TCVE_TANQUE1.Tag = ""
            TCVE_TANQUE2.Tag = ""

            LtTractor.Tag = " "
            LTanque1.Tag = " "
            LTanque2.Tag = " "

            TCVE_OPER.Tag = " "
            tCLAVE_O.Tag = " "
            TCLAVE_D.Tag = " "
            TRECOGER_EN.Tag = " "
            TENTREGAR_EN.Tag = " "

            SERIE_PEDIDO = ""
            EditPed = False
            Entra = True

        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        DERECHOS()

        DOCNEW = False
        If Var1 = "Nuevo" Then

            DOCNEW = True
            LtNewEdit.Text = "Nuevo"
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT ISNULL(SERIE_PROGPEDIDOS,0) AS SER_PED FROM GCPARAMVENTAS"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    SERIE_PEDIDO = dr("SER_PED")
                End If
                dr.Close()
            Catch ex As Exception
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_VENTA("P", SERIE_PEDIDO)

                If SERIE_PEDIDO = "" Or SERIE_PEDIDO = "STAND." Then
                    LtCVE_DOC.Text = Format(FOLIO_G, "0000000000")
                Else
                    LtCVE_DOC.Text = SERIE_PEDIDO & Format(FOLIO_G, "0000000000")
                End If
                TCONTRATO_CLIENTE.Focus()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            LtNewEdit.Text = "Edit"
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT P.CVE_DOC, P.CVE_CLIE, ISNULL(P.CVE_CON,'') AS CVECON, ISNULL(P.STATUS,'C') AS ST, CT.CVE_ART, P.CVE_ART AS ART_PRO_PED,
                    ISNULL(I.DESCR,'') AS DESCR_PRODUCTO, ISNULL(P1.CIUDAD,'') AS DESCR_ORIGEN, ISNULL(P2.CIUDAD,'') AS DESCR_DESTINO, 
                    P.FECHA, P.CVE_ORIGEN, P.CVE_DESTINO, ISNULL(T.CVE_TAB,'') AS CVE_TAB_V,
                    P.FECHA_CARGA, P.FECHA_DESCARGA, ISNULL(NOMBRE,'') AS NOMB, ISNULL(DOMICILIO,'') AS DIRE, ISNULL(RFC,'') AS RF, 
                    ISNULL(C.DOMICILIO2,'') AS MUNI, NUM_TALON, NUM_TALON2, P.CVE_CAP, P.CVE_OPER, P.CVE_TRACTOR, P.CVE_TANQUE1, P.CVE_TANQUE2, 
                    ISNULL(P.CVE_OBS,0) AS CVEOBS, ISNULL(O.DESCR,'') AS OBS_DESCR, P.RECOGER_EN, P.ENTREGAR_EN, ISNULL(P.CLAVE_O,'') AS ORIGEN, 
                    ISNULL(P.CLAVE_D,'') AS DESTINO, P.LEYENDA, P.VALOR_DECLA, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, P.CVE_VIAJE, PEDIMENTO
                    FROM GCPEDIDOSPROG P 
                    LEFT JOIN GCCLIE_OP C ON C.CLAVE = P.CVE_CLIE 
                    LEFT JOIN GCCONTRATO CT On CT.CVE_CON = P.CVE_CON 
                    LEFT JOIN GCTAB_RUTAS_F T ON T.CVE_CON = CT.CVE_CON
                    LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = CT.CVE_ART 
                    LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = P.CVE_ORIGEN 
                    LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = P.CVE_DESTINO 
                    LEFT JOIN GCOBS O ON O.CVE_OBS = P.CVE_OBS 
                    WHERE P.CVE_DOC = '" & Var2 & "'"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    EditPed = True
                    LtCVE_DOC.Text = Var2

                    If dr("ST") = "C" Then
                        LtStatus.Text = "CANCELADO"
                    End If

                    If dr.ReadNullAsEmptyString("ART_PRO_PED").Trim.ToString.Length > 0 Then
                        TCVE_ART.Text = dr.ReadNullAsEmptyString("ART_PRO_PED").ToString
                    Else
                        TCVE_ART.Text = dr.ReadNullAsEmptyString("CVE_ART").ToString
                    End If
                    LtProducto.Text = BUSCA_CAT("Productos", TCVE_ART.Text)
                    Try
                        TLeyenda.Text = dr.ReadNullAsEmptyString("LEYENDA").ToString
                        TValorDeclarado.Text = dr.ReadNullAsEmptyString("VALOR_DECLA").ToString
                        'SQL = "SELECT E.CLAVE, E.IMPORTE, E.DESCR FROM GCVALOR_DECLARADO E WHERE E.STATUS = 'A' AND E.CLAVE = '" & fCLAVE & "'"
                        BUSCA_VALOR_DECLARADO(TValorDeclarado.Text)
                        Lt1.Text = Var5
                        If IsNumeric(Var6) Then
                            LtValorDeclarado.Text = Var6
                        End If

                        LtViaje.Text = dr.ReadNullAsEmptyString("CVE_VIAJE")

                        LtTabulador.Text = dr("CVE_TAB_V")

                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TORDEN_DE.Text = dr.ReadNullAsEmptyString("ORDEN_DE")
                        TEMBARQUE.Text = dr.ReadNullAsEmptyString("EMBARQUE")
                        TCARGA_ANTERIOR.Text = dr.ReadNullAsEmptyString("CARGA_ANTERIOR")
                        TPEDIMENTO.Text = dr("PEDIMENTO")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    LtFecha.Text = dr("FECHA").ToString

                    If IsDate(dr("FECHA_CARGA").ToString) Then
                        F1.Value = dr("FECHA_CARGA").ToString
                        F1.Tag = dr("FECHA_CARGA").ToString
                    Else
                        F1.Value = Date.Today
                        F1.Tag = Date.Today
                    End If

                    If IsDate(dr("FECHA_DESCARGA").ToString) Then
                        F2.Value = dr("FECHA_DESCARGA").ToString
                        F2.Tag = dr("FECHA_DESCARGA").ToString
                    Else
                        F2.Value = Date.Today
                        F2.Tag = Date.Today
                    End If

                    TCVE_CON.Text = dr.ReadNullAsEmptyString("CVECON")

                    TENTREGAR_EN.Text = dr.ReadNullAsEmptyString("ENTREGAR_EN")
                    TRECOGER_EN.Text = dr.ReadNullAsEmptyString("RECOGER_EN")
                    If TENTREGAR_EN.Text.Trim.Length > 0 Then
                        LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                    End If
                    If TENTREGAR_EN.Text.Trim.Length > 0 Then
                        LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)
                    End If

                    tCLAVE_O.Text = dr("ORIGEN")
                    TCLAVE_D.Text = dr("DESTINO")

                    DESPLEGAR_CLIENTE_OPER(tCLAVE_O.Text) 'GCCLIE_OP 
                    DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text) 'GCCLIE_OP 

                    TCVE_TRACTOR.Text = dr.ReadNullAsEmptyString("CVE_TRACTOR").ToString
                    LtTractor.Text = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)

                    TCVE_TANQUE1.Text = dr.ReadNullAsEmptyString("CVE_TANQUE1").ToString
                    LTanque1.Text = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)

                    TCVE_TANQUE2.Text = dr.ReadNullAsEmptyString("CVE_TANQUE2").ToString
                    LTanque2.Text = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)

                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                            LtTipoViaje.Text = "Full"
                        Else
                            LtTipoViaje.Text = "Sencillo"
                        End If
                    End If
                    TCVE_OPER.Text = dr.ReadNullAsEmptyString("CVE_OPER")
                    If TCVE_OPER.Text = "0" Then
                        TCVE_OPER.Text = ""
                    End If
                    If TCVE_OPER.Text.Trim.Length > 0 Then
                        LtOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                    End If

                    LtTractor.Tag = TCVE_TRACTOR.Text
                    LTanque1.Tag = TCVE_TANQUE1.Text
                    LTanque2.Tag = TCVE_TANQUE2.Text

                    tCLAVE_O.Tag = tCLAVE_O.Text
                    TCLAVE_D.Tag = TCLAVE_D.Text
                    TRECOGER_EN.Tag = TRECOGER_EN.Text
                    TENTREGAR_EN.Tag = TENTREGAR_EN.Text
                    TCVE_OPER.Tag = TCVE_OPER.Text

                    TCVE_OBS.Tag = dr("CVEOBS")
                    TCVE_OBS.Text = dr("OBS_DESCR")
                End If
                dr.Close()

                TCVE_CON.Enabled = False

                TCONTRATO_CLIENTE.Select()
            Catch ex As Exception
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub CARGAR_DATOS2()

        BtnContrato.Enabled = True
        TCVE_OBS.Enabled = True
        TCVE_OBS_CON.Enabled = False

        'var3 VIAJE ASIGNADO
        If Var3.Trim.Length > 0 Then
            'var3 VIAJE ASIGNADO
            Try
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp1)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp2)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp3)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp4)
                SET_ALL_CONTROL_READ_AND_ENABLED(Box3)
                TENTREGAR_EN.Enabled = False
                TRECOGER_EN.Enabled = False
                TCVE_OPER.Enabled = False
                TCVE_TRACTOR.Enabled = False
                TCVE_TANQUE1.Enabled = False
                TCVE_TANQUE2.Enabled = False

                BarGrabar.Visible = False
            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If LtStatus.Text = "CANCELADO" Then
            SET_ALL_CONTROL_READ_AND_ENABLED(Gp1)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gp2)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gp3)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gp4)
            SET_ALL_CONTROL_READ_AND_ENABLED(Box3)
            TENTREGAR_EN.Enabled = False
            TRECOGER_EN.Enabled = False
            TCVE_OPER.Enabled = False
            TCVE_TRACTOR.Enabled = False
            TCVE_TANQUE1.Enabled = False
            TCVE_TANQUE2.Enabled = False
            TCVE_OBS.Enabled = False

            BarGrabar.Visible = False
            BarCancelar.Visible = False
        End If
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarGrabar.Visible = False
                BarImprimir.Visible = False
                BarCancelar.Visible = False
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp1)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp2)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp3)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp4)
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                      (CLAVE >= 24000 AND CLAVE < 24600 OR CLAVE >= 244000 AND CLAVE < 244200)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 24050 'GRABAR 
                                    BarGrabar.Visible = True
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp1, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp2, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp3, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp4, True)
                                Case 24052 'GRABAR 
                                    BarCancelar.Visible = True
                                Case 24075 'IMPIRMIR CARTA PORTE
                                    BarImprimir.Visible = True
                                Case 244060 'GENERALES
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp1)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp2)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp3)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp4)
                                Case 244080 'DATOS DE LA BITACORA
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box2)
                                Case 244100 'OBSERVACIONES PEDIDO
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box3)
                                Case 244120 'INSTRUCCIONES DE VIAJE
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box4)
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
    Private Sub FrmProgPedidosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_DOC As String, CVE_OBS As Long, FOLIO_ASIGNADO As Boolean, FOLIO_PEDIDO As Long, Sigue As Boolean, nCopias As Integer
        Dim FOLIO_CARTA_PORTE As String = "", FOLIO_CARTA_PORTE2 As String = ""
        Dim SQL1 As String
        Dim cmd As New SqlCommand

        If TCVE_CON.Text.Trim.Length = 0 Then
            MsgBox("La clave del contrato no debe quedar vacia")
            TCVE_CON.Select()
            Return
        End If
        TLeyenda.Select()


        If LtCVE_DOC.Text.Trim.Length = 0 Then
            EditPed = False
        End If
        If IsNumeric(tCopias.Text) Then
            nCopias = tCopias.Text
        Else
            nCopias = 0
        End If
        If nCopias < 0 And nCopias > 20 Then
            MsgBox("el número de copias no debe meno a cero o exceder a 10, verifique por favor")
            Return
        End If
        Try
            If TCVE_OBS.Text.Trim.Length > 0 Then
                CVE_OBS = Val(TCVE_OBS.Tag.ToString)
                CVE_OBS = INSERT_UPDATE_GCOBS(CVE_OBS, TCVE_OBS.Text)
            Else
                CVE_OBS = 0
            End If
        Catch ex As Exception
            Bitacora("39. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If Not EditPed Then
            'ALTA ES UN PEDIDO NUEVO          ALTA ES UN PEDIDO NUEVO
            CVE_DOC = ""
            Try
                Sigue = True
                FOLIO_ASIGNADO = False
                FOLIO_PEDIDO = SIGUIENTE_FOLIO_VENTA("P", SERIE_PEDIDO.ToString)
                Do While Sigue
                    If SERIE_PEDIDO.ToString.Trim.Length = 0 Or SERIE_PEDIDO.ToString = "STAND." Then
                        CVE_DOC = Space(10) & Format(FOLIO_PEDIDO, "0000000000")
                    Else
                        CVE_DOC = SERIE_PEDIDO & Format(FOLIO_PEDIDO, "0000000000")
                    End If
                    If EXISTE_PEDIDO(CVE_DOC) Then
                        FOLIO_PEDIDO += 1
                        FOLIO_ASIGNADO = True
                    Else
                        Sigue = False
                    End If
                Loop
            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            'NO  NO  NO  NO ES ALTA ES EDIT    EDIT ENDEJO
            CVE_DOC = LtCVE_DOC.Text
            nCopias = 0
        End If

        If DOCNEW Then
            SQL1 = "INSERT INTO GCPEDIDOSPROG (CVE_DOC, CVE_CON, STATUS, FECHA, FECHA_CARGA, FECHA_DESCARGA, FECHAELAB, UUID, NUM_TALON, NUM_TALON2, CVE_OPER, 
                CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2,CVE_OBS, ENTREGAR_EN, RECOGER_EN, CLAVE_O, CLAVE_D, CVE_PLAZA1, CVE_PLAZA2, CVE_ART, VALOR_DECLA, 
                LEYENDA, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, PEDIMENTO) VALUES (@CVE_DOC, @CVE_CON, 'A', @FECHA, @FECHA_CARGA, @FECHA_DESCARGA, GETDATE(), NEWID(), 
                @NUM_TALON, @NUM_TALON2, @CVE_OPER, @CVE_TRACTOR, @CVE_TANQUE1, @CVE_TANQUE2, @CVE_OBS, @ENTREGAR_EN, @RECOGER_EN, @CLAVE_O, @CLAVE_D, 
                @CVE_PLAZA1, @CVE_PLAZA2, @CVE_ART, @VALOR_DECLA, @LEYENDA, @ORDEN_DE, @EMBARQUE, @CARGA_ANTERIOR, @PEDIMENTO)"
        Else
            SQL1 = "UPDATE GCPEDIDOSPROG SET NUM_TALON = @NUM_TALON, NUM_TALON2 = @NUM_TALON2, FECHA_CARGA = @FECHA_CARGA, FECHA_DESCARGA = @FECHA_DESCARGA, 
                CVE_CON = @CVE_CON, CVE_OBS = @CVE_OBS, CVE_OPER = @CVE_OPER, CVE_TRACTOR = @CVE_TRACTOR, CVE_TANQUE1 = @CVE_TANQUE1, CVE_TANQUE2 = @CVE_TANQUE2,
                ENTREGAR_EN = @ENTREGAR_EN, RECOGER_EN = @RECOGER_EN, CLAVE_O = @CLAVE_O, CLAVE_D = @CLAVE_D, CVE_PLAZA1 = @CVE_PLAZA1, CVE_PLAZA2 = @CVE_PLAZA2,
                CVE_ART = @CVE_ART, VALOR_DECLA = @VALOR_DECLA, LEYENDA = @LEYENDA, ORDEN_DE = @ORDEN_DE, EMBARQUE = @EMBARQUE, CARGA_ANTERIOR = @CARGA_ANTERIOR,
                PEDIMENTO = @PEDIMENTO
                WHERE CVE_DOC = @CVE_DOC "
        End If
        cmd.CommandText = SQL1
        For k = 0 To nCopias
            Try
                cmd.Connection = cnSAE
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                cmd.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = TCVE_CON.Text
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now
                cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                cmd.Parameters.Add("@NUM_TALON", SqlDbType.VarChar).Value = FOLIO_CARTA_PORTE
                cmd.Parameters.Add("@NUM_TALON2", SqlDbType.VarChar).Value = FOLIO_CARTA_PORTE2
                cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                cmd.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                cmd.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = tCLAVE_O.Text
                cmd.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                cmd.Parameters.Add("@CVE_PLAZA1", SqlDbType.VarChar).Value = CONVERTIR_TO_INT(TCVE_PLAZA.Text)
                cmd.Parameters.Add("@CVE_PLAZA2", SqlDbType.VarChar).Value = CONVERTIR_TO_INT(TCVE_PLAZA2.Text)
                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text
                cmd.Parameters.Add("@VALOR_DECLA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TValorDeclarado.Text)
                cmd.Parameters.Add("@LEYENDA", SqlDbType.VarChar).Value = TLeyenda.Text
                cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                cmd.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                cmd.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                cmd.Parameters.Add("@PEDIMENTO", SqlDbType.VarChar).Value = TPEDIMENTO.Text

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        'ImprimirOrden(CVE_DOC)
                        If DOCNEW Then
                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_PEDIDO &
                                      " WHERE TIP_DOC = 'P' AND SERIE = '" & IIf(SERIE_PEDIDO = "", "STAND.", SERIE_PEDIDO) & "'"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("70. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try


                            CVE_DOC = ""
                            Try
                                Sigue = True
                                FOLIO_ASIGNADO = False
                                FOLIO_PEDIDO = SIGUIENTE_FOLIO_VENTA("P", SERIE_PEDIDO.ToString)
                                Do While Sigue

                                    If SERIE_PEDIDO.ToString.Trim.Length = 0 Or SERIE_PEDIDO.ToString = "STAND." Then
                                        CVE_DOC = Space(10) & Format(FOLIO_PEDIDO, "0000000000")
                                    Else
                                        CVE_DOC = SERIE_PEDIDO & Format(FOLIO_PEDIDO, "0000000000")
                                    End If

                                    If EXISTE_PEDIDO(CVE_DOC) Then
                                        FOLIO_PEDIDO += 1
                                        FOLIO_ASIGNADO = True
                                    Else
                                        Sigue = False
                                    End If
                                Loop
                            Catch ex As Exception
                                Bitacora("70. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next 'FIN ALTA DEL PEDIDO                 FIN ALTA DEL PEDIDO

        Try
            If LtTractor.Tag.ToString.Trim.Length > 0 Then
                If TCVE_TRACTOR.Text <> LtTractor.Tag Then
                    GRABA_BITA("", "", 0, "P", "Se cambio la unidad " & LtTractor.Tag & " por " & TCVE_TRACTOR.Text, LtCVE_DOC.Text, "", "FtoF")
                End If
            End If
            If LTanque1.Tag.ToString.Trim.Length > 0 Then
                If TCVE_TANQUE1.Text <> LTanque1.Tag Then
                    GRABA_BITA("", "", 0, "P", "Se cambio la unidad " & LTanque1.Tag & " por " & TCVE_TANQUE1.Text, LtCVE_DOC.Text, "", "FtoF")
                End If
            End If
            If LTanque2.Tag.ToString.Trim.Length > 0 Then
                If TCVE_TANQUE2.Text <> LTanque2.Tag Then
                    GRABA_BITA("", "", 0, "P", "Se cambio la unidad " & LTanque2.Tag & " por " & TCVE_TANQUE2.Text, LtCVE_DOC.Text, "", "FtoF")
                End If
            End If
            If tCLAVE_O.Tag.ToString.Trim.Length > 0 Then
                If tCLAVE_O.Tag <> tCLAVE_O.Text Then
                    GRABA_BITA("", "", 0, "P", "Se cambio el cliente operativo " & tCLAVE_O.Tag & " por " & tCLAVE_O.Text, LtCVE_DOC.Text, "", "FtoF")
                End If
            End If
            If TCLAVE_D.Tag.ToString.Trim.Length > 0 Then
                If TCLAVE_D.Tag <> TCLAVE_D.Text Then
                    GRABA_BITA("", "", 0, "P", "Se cambio el cliente operativo " & TCLAVE_D.Tag & " por " & TCLAVE_D.Text, LtCVE_DOC.Text, "", "FtoF")
                End If
            End If
            If TRECOGER_EN.Tag.ToString.Trim.Length > 0 Then
                If TRECOGER_EN.Tag <> TRECOGER_EN.Text Then
                    GRABA_BITA("", "", 0, "P", "Se cambio recoger en " & TRECOGER_EN.Tag & " por " & TRECOGER_EN.Text, LtCVE_DOC.Text, "", "FtoF")
                End If
            End If
            If TENTREGAR_EN.Tag.ToString.Trim.Length > 0 Then
                If TENTREGAR_EN.Tag <> TENTREGAR_EN.Text Then
                    GRABA_BITA("", "", 0, "P", "Se cambio entregar en " & TENTREGAR_EN.Tag & " por " & TENTREGAR_EN.Text, LtCVE_DOC.Text, "", "FtoF")
                End If
            End If
            If TCVE_OPER.Tag.ToString.Trim.Length > 0 Then
                If TCVE_OPER.Tag <> TCVE_OPER.Text Then
                    GRABA_BITA("", "", 0, "P", "Se cambio el operador " & TCVE_OPER.Tag & " por " & TCVE_OPER.Text, LtCVE_DOC.Text, "", "FtoF")
                End If
            End If

            LtTractor.Tag = TCVE_TRACTOR.Text
            LTanque1.Tag = TCVE_TANQUE1.Text
            LTanque2.Tag = TCVE_TANQUE2.Text

            tCLAVE_O.Tag = tCLAVE_O.Text
            TCLAVE_D.Tag = TCLAVE_D.Text
            TRECOGER_EN.Tag = TRECOGER_EN.Text
            TENTREGAR_EN.Tag = TENTREGAR_EN.Text
            TCVE_OPER.Tag = TCVE_OPER.Text

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        EditPed = True
        DOCNEW = False

        MsgBox("El registro se grabo satisfactoriamente")
        'LIMPIAR()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        ImprimirOrden(LtCVE_DOC.Text)
    End Sub
    Sub ImprimirOrden(fCVE_DOC As String)
        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportProgPedido.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportProgPedido.mrt, verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS & "\ReportProgPedido.mrt")

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("PREREP", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CVE_DOC") = fCVE_DOC
            StiReport1.Render()

            StiReport1.Show()
        Catch ex As Exception
            Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles BarCancelar.Click
        If MsgBox("Realmente desea cancelar el pedido?", vbYesNo) = vbYes Then
            Try
                SQL = "UPDATE GCPEDIDOSPROG SET STATUS = 'C' WHERE CVE_DOC = '" & LtCVE_DOC.Text & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                    MsgBox("El pedido se cancelo satisfactoriamente")
                    Me.Close()
                End Using
            Catch ex As Exception
                Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnContrato_Click(sender As Object, e As EventArgs) Handles BtnContrato.Click
        Try
            Var2 = "Contrato"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CON.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""

                DESPLEGAR_CONTRATO(TCVE_CON.Text)

                TCVE_CON.Select()
            End If
        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_CON_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CON.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnContrato_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = Keys.Tab Or e.KeyCode = 13 Then
                If tCLAVE_O.Text.Trim.Length = 0 Then
                    DESPLEGAR_CONTRATO(TCVE_CON.Text)
                End If
                'tCVE_OPER.Select()
                Label15.Select()
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_CON_Validated(sender As Object, e As EventArgs) Handles TCVE_CON.Validated
        Try
            If TCVE_CON.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Contrato", TCVE_CON.Text)
                If DESCR <> "" Then

                Else
                    TCVE_CON.Select()
                    MsgBox("El contrato no existe")
                    TCVE_CON.Text = ""
                End If
            Else
                tCLAVE_O.Text = "" : TCLAVE_D.Text = "" : tCLAVE_O.Tag = "" : TCLAVE_D.Tag = "" : TCVE_RUTA.Text = "" : LtRuta1.Text = ""
                TRUTA_SEN_VAC.Text = "" : TRUTA_SE_CAR.Text = "" : TRUTA_FULL_VAC.Text = "" : TRUTAL_FULL_CAR.Text = "" : TNOTA.Text = ""
                TRECOGER_EN.Text = "" : TENTREGAR_EN.Text = "" : TValorDeclarado.Text = "" : TCVE_OBS.Text = "" : TValorDeclarado.Text = ""
                Lt1.Text = "" : LtValorDeclarado.Text = "" : TCVE_ART.Text = ""
            End If
        Catch ex As Exception
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_CON_GotFocus(sender As Object, e As EventArgs) Handles TCVE_CON.GotFocus
        Entra = False
    End Sub
    Private Sub TCVE_CON_LostFocus(sender As Object, e As EventArgs) Handles TCVE_CON.LostFocus
        Entra = True
    End Sub
    Private Sub TCVE_CON_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_CON.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            TCONTRATO_CLIENTE.Select()
        End If
    End Sub
    Private Sub BtnCLAVE_REM_Click(sender As Object, e As EventArgs) Handles BtnCLAVE_REM.Click
        Try
            Var2 = "Cliente operativo" '       GCCLIE_OP
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                tCLAVE_O.Text = Var4
                DESPLEGAR_CLIENTE_OPER(Var4)
                LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TRECOGER_EN.Focus()
            End If
        Catch ex As Exception
            Bitacora("58. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("58. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCLAVE_REM_KeyDown(sender As Object, e As KeyEventArgs) Handles BtnCLAVE_REM.KeyDown
        Try
            Var2 = "Cliente operativo" '       GCCLIE_OP
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                tCLAVE_O.Text = Var4
                DESPLEGAR_CLIENTE_OPER(Var4)
                LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TRECOGER_EN.Focus()
            End If
        Catch ex As Exception
            Bitacora("58. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("58. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCLAVE_REM_Validated(sender As Object, e As EventArgs) Handles BtnCLAVE_REM.Validated
        Try
            Var2 = "Cliente operativo" '       GCCLIE_OP
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                tCLAVE_O.Text = Var4
                DESPLEGAR_CLIENTE_OPER(Var4)
                LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TRECOGER_EN.Focus()
            End If
        Catch ex As Exception
            Bitacora("58. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("58. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCLAVE_DEST_Click(sender As Object, e As EventArgs) Handles BtnCLAVE_DEST.Click
        Try
            Var2 = "Cliente operativo" '       GCCLIE_OP
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLAVE_D.Text = Var4
                DESPLEGAR_CLIENTE_OPER2(Var4)
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TENTREGAR_EN.Focus()
            End If
        Catch ex As Exception
            Bitacora("59 " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("59. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLAVE_O_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLAVE_O.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCLAVE_REM_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLAVE_O_Validated(sender As Object, e As EventArgs) Handles tCLAVE_O.Validated
        Try
            If tCLAVE_O.Text.Trim.Length > 0 Then
                DESPLEGAR_CLIENTE_OPER(tCLAVE_O.Text)
            Else
                LtNombre1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTractor_Click(sender As Object, e As EventArgs) Handles BtnTractor.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCVE_TRACTOR.Text = Var5
                TCVE_TRACTOR.Tag = Var4
                LtTractor.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_TANQUE1.Focus()
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTractor_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles TCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If TCVE_TANQUE1.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA(Var4) Then
                        MsgBox("La unidad actualmente se encuentra asignada " & Var3)
                        TCVE_TRACTOR.Text = ""
                        TCVE_TRACTOR.Tag = ""
                        LtTractor.Text = ""
                        TCVE_TRACTOR.Select()
                        Return
                    End If
                    'Var4 = dr.ReadNullAsEmptyString("CLAVE").ToString
                    'Var5 = dr.ReadNullAsEmptyInteger("TIPO_UNI")
                    'Var6 = dr.ReadNullAsEmptyString("DES").ToString'
                    'Var7 = dr.ReadNullAsEmptyString("TAQ").ToString
                    'Var8 = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI").ToString

                    Var3 = ""
                    TCVE_TRACTOR.Tag = DESCR
                    LtTractor.Text = DESCR

                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TRACTOR.Text = ""
                    TCVE_TRACTOR.Tag = ""
                    LtTractor.Text = ""
                    TCVE_TRACTOR.Select()
                End If
            Else
                TCVE_TANQUE1.Tag = ""
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTanque1_Click(sender As Object, e As EventArgs) Handles BtnTanque1.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var3 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If UNIDAD_ASIGNADA_LOCAL(2, Var5) Then
                    MsgBox("Unidad asignada, verifique por favor")
                    TCVE_TANQUE1.Text = ""
                    TCVE_TANQUE1.Tag = ""
                    LTanque1.Text = ""
                    Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                    TCVE_TANQUE1.Select()
                    Return
                End If
                LtTipoViaje.Text = "Sencillo"
                TCVE_TANQUE1.Text = Var5
                TCVE_TANQUE1.Tag = Var4
                LTanque1.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_TANQUE2.Focus()
            End If

        Catch Ex As Exception
            Bitacora("340. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("340. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_TANQUE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TANQUE1_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE1.Validated
        Try
            Dim DESCR As String
            If TCVE_TANQUE1.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA_LOCAL(2, TCVE_TANQUE1.Text) Then
                        MsgBox("Unidad asignada, verifique por favor")
                        TCVE_TANQUE1.Text = ""
                        TCVE_TANQUE1.Tag = ""
                        LTanque1.Text = ""
                        TCVE_TANQUE1.Select()
                        Return
                    End If
                    Var3 = ""
                    TCVE_TANQUE1.Tag = DESCR
                    LTanque1.Text = DESCR
                    If TCVE_TANQUE2.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                    Else
                        LtTipoViaje.Text = "Sencillo"
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TANQUE1.Text = ""
                    TCVE_TANQUE1.Tag = ""
                    LTanque1.Text = ""
                    TCVE_TANQUE1.Select()
                End If
            Else
                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                Else
                    LtTipoViaje.Text = "Sencillo"
                End If
                TCVE_TANQUE1.Tag = ""
                LTanque1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTanque2_Click(sender As Object, e As EventArgs) Handles BtnTanque2.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If UNIDAD_ASIGNADA_LOCAL(3, Var5) Then
                    MsgBox("La unidad asignada, verifique por favor")
                    TCVE_TANQUE2.Text = ""
                    TCVE_TANQUE2.Tag = ""
                    LTanque2.Text = ""
                    Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                    TCVE_TANQUE2.Select()
                    Return
                End If
                If TCVE_TANQUE1.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                Else
                    LtTipoViaje.Text = "Sencillo"
                End If
                TCVE_TANQUE2.Text = Var5
                TCVE_TANQUE2.Tag = Var4
                LTanque2.Text = Var6

                Var2 = "" : Var3 = "" : Var4 = ""
                Var5 = ""
                TRECOGER_EN.Focus()
            End If

        Catch Ex As Exception
            Bitacora("360. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("360. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TANQUE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TANQUE2_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE2.Validated
        Try
            Dim DESCR As String
            If TCVE_TANQUE2.Text.Length > 0 Then
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA_LOCAL(3, TCVE_TANQUE2.Text) Then
                        MsgBox("Unidad asignada, verifique por favor")
                        TCVE_TANQUE2.Text = ""
                        TCVE_TANQUE2.Tag = ""
                        LTanque2.Text = ""
                        TCVE_TANQUE2.Select()
                        Return
                    End If
                    Var3 = ""
                    TCVE_TANQUE2.Tag = DESCR
                    LTanque2.Text = DESCR
                    If TCVE_TANQUE1.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                    Else
                        LtTipoViaje.Text = "Sencillo"
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TANQUE2.Text = ""
                    TCVE_TANQUE2.Tag = ""
                    LTanque2.Text = ""
                    TRECOGER_EN.Focus()
                End If
            Else
                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                Else
                    LtTipoViaje.Text = "Sencillo"
                End If
                TCVE_TANQUE2.Tag = ""
                LTanque2.Text = ""
                TRECOGER_EN.Focus()
            End If
        Catch ex As Exception
            Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnRecogerEn_Click(sender As Object, e As EventArgs) Handles BtnRecogerEn.Click
        Try
            Var2 = "RecogerEn"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TRECOGER_EN.Text = Var4
                LtRecogerEn.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCLAVE_D.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TRECOGER_EN_Validated(sender As Object, e As EventArgs) Handles TRECOGER_EN.Validated
        Try
            If TRECOGER_EN.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                If DESCR <> "" Then
                    LtRecogerEn.Text = DESCR
                Else
                    MsgBox("Registro inexistente")
                    TRECOGER_EN.Text = ""
                    LtRecogerEn.Text = ""
                    TRECOGER_EN.Select()
                End If
            Else
                LtRecogerEn.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TRECOGER_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TRECOGER_EN.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                TCLAVE_D.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnEntregarEn_Click(sender As Object, e As EventArgs) Handles BtnEntregarEn.Click
        Try
            Var2 = "EntregarEn"
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TENTREGAR_EN.Text = Var4
                LtEntregarEn.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_PLAZA2.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TENTREGAR_EN_Validated(sender As Object, e As EventArgs) Handles TENTREGAR_EN.Validated
        Try
            If TENTREGAR_EN.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)
                If DESCR <> "" Then
                    LtEntregarEn.Text = DESCR
                Else
                    MessageBox.Show("Registro inexistente-")
                    TENTREGAR_EN.Focus()
                    TENTREGAR_EN.Text = ""
                    LtEntregarEn.Text = ""
                End If
            Else
                LtEntregarEn.Text = ""
                TCVE_ART.Select()
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TENTREGAR_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TENTREGAR_EN.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                TCVE_ART.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Dim OPER As String

            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                'OPER = OPERADOR_ASIGNADO_VIAJE(Var4) 'OBTIEN CVE_VIAJE
                OPER = ""
                If OPER = "" Then
                    TCVE_OPER.Text = Var4
                    LtOper.Text = Var5  'NOMBRE
                    Var2 = "" : Var4 = "" : Var5 = ""
                    TCVE_TRACTOR.Focus()
                Else
                    MsgBox("El operador se encuentra asignado en el viaje " & OPER)
                    TCVE_OPER.Text = ""
                    LtOper.Text = ""
                    Var2 = "" : Var4 = "" : Var5 = ""
                End If
            Else
                TCVE_OPER.Text = ""
                LtOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_OPER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_OPER.PreviewKeyDown
        Try
            If TCVE_OPER.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER.Text) Then
                Dim DESCR As String, OPER As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    'OPER = OPERADOR_ASIGNADO_VIAJE(tCVE_OPER.Text) 'OBTIEN CVE_VIAJE
                    OPER = ""
                    If OPER = "" Then
                        LtOper.Text = DESCR
                        Var2 = "" : Var4 = "" : Var5 = ""
                        TCVE_TRACTOR.Focus()
                    Else
                        MsgBox("El operador se encuentra asignado en el viaje " & OPER)
                        TCVE_OPER.Text = ""
                        LtOper.Text = ""
                        Var2 = "" : Var4 = "" : Var5 = ""
                        TCVE_OPER.Select()
                    End If
                Else
                    MsgBox("Operador inexistente")
                    LtOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                LtOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function UNIDAD_ASIGNADA_LOCAL(fUNI As Integer, fCVE_UNI As String) As Boolean
        Dim Exist As Boolean = False
        Try
            Select Case fUNI
                Case 1 'TRACTOR
                    Try
                        If TCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE2.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 2 'TANQUE 1
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE2.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 3 'TANQUE2
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("410. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("410. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 4 'DOLLY
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE2.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
            End Select
            Return Exist
        Catch ex As Exception
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Sub DESPLEGAR_CONTRATO(fCVE_CON As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT C.CVE_CON, C.CONTRATO_CLIENTE, C.CVE_RUTA, C.STATUS, C.RUTA_SEN_VAC, C.RUTA_SE_CAR, C.RUTA_FULL_VAC, C.RUTAL_FULL_CAR, 
                    C.NOTA, C.GAS_VIAJE_SEN, C.GAS_VIAJE_FUL, C.LTR_DIESEL_SEN, C.LTR_DIESEL_FULL, C.KM_SEN, C.KM_FULL, C.REDIMIENTO, C.OBSER, 
                    C.CVE_GAS, C.NO_VALES, C.TIPO_VIAJE, C.LITROS, C.NO_CONTRATO, CLAVE_O, CLAVE_D, CVE_ORIGEN, CVE_DESTINO, RECOGER_EN, ENTREGAR_EN, 
                    C.CVE_PROV, C.CVE_MAT, ISNULL(C.VALOR_DECLA,0) AS DECLA, C.CVE_ART, C.LEYENDA, ISNULL(C.IMPR_TALON,0) AS IMPR, ISNULL(C.CVE_OBS,0) AS CVEOBS, 
                    ISNULL(O.DESCR,'') AS OBS_DESCR, ISNULL(T.CVE_TAB,'') AS CVE_TAB_V 
                    FROM GCCONTRATO C 
                    LEFT JOIN GCTAB_RUTAS_F T ON T.CVE_CON = C.CVE_CON
                    LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBS 
                    WHERE C.CVE_CON = '" & fCVE_CON & "' AND C.STATUS = 'A' "
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        tCLAVE_O.Text = dr("CLAVE_O").ToString.Trim
                        TCLAVE_D.Text = dr("CLAVE_D").ToString.Trim
                        'MARCA1
                        TCONTRATO_CLIENTE.Text = dr("NO_CONTRATO").ToString

                        LtTabulador.Text = dr("CVE_TAB_V")

                        '"SELECT ISNULL(NOMBRE,'') AS DES FROM GCCLIE_OP WHERE CLAVE = " & fCLAVE
                        LtClienteContrato.Text = BUSCA_CAT("Cliente operativo", TCONTRATO_CLIENTE.Text)

                        '"SELECT * FROM GCCLIE_OP WHERE CLAVE = '" & fCVE_OPER & "'"
                        DESPLEGAR_CLIENTE_OPER(tCLAVE_O.Text)
                        DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text)

                        If TRECOGER_EN.Text.Trim.Length = 0 Then
                            TRECOGER_EN.Text = dr("RECOGER_EN").ToString
                            '"SELECT ISNULL(DESCR,'') AS DES FROM GCRECOGER_EN_ENTREGAR_EN WHERE CVE_REG = '" & fCLAVE & "'"
                            LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                        End If
                        If TENTREGAR_EN.Text.Trim.Length = 0 Then
                            TENTREGAR_EN.Text = dr("ENTREGAR_EN").ToString
                            '"SELECT ISNULL(DESCR,'') AS DES FROM GCRECOGER_EN_ENTREGAR_EN WHERE CVE_REG = '" & fCLAVE & "'"
                            LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)
                        End If

                        TValorDeclarado.Text = dr("DECLA").ToString
                        TLeyenda.Text = dr("LEYENDA").ToString
                        TRUTA_SEN_VAC.Text = dr("RUTA_SEN_VAC").ToString
                        TRUTA_SE_CAR.Text = dr("RUTA_SE_CAR").ToString
                        TRUTA_FULL_VAC.Text = dr("RUTA_FULL_VAC").ToString
                        TRUTAL_FULL_CAR.Text = dr("RUTAL_FULL_CAR").ToString
                        TNOTA.Text = dr("NOTA").ToString

                        TCVE_OBS_CON.Text = dr("OBS_DESCR")

                        TValorDeclarado.Text = dr("DECLA").ToString
                        If TValorDeclarado.Text = "0" Then
                            TValorDeclarado.Text = ""
                            Lt1.Text = ""
                            LtValorDeclarado.Text = ""
                        Else
                            Try
                                '"SELECT E.CLAVE, E.IMPORTE, E.DESCR From GCVALOR_DECLARADO E Where e.STATUS = 'A' AND E.CLAVE = '" & fCLAVE & "'"
                                BUSCA_VALOR_DECLARADO(TValorDeclarado.Text)
                                Lt1.Text = Var5
                                If IsNumeric(Var6) Then
                                    LtValorDeclarado.Text = Format(CSng(Var6), "###,##0.00")
                                End If
                            Catch ex As Exception
                                Bitacora("120 " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("120 " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                        TCVE_ART.Text = dr("CVE_ART").ToString
                        LtProducto.Text = BUSCA_CAT("Productos", TCVE_ART.Text)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR_CLIENTE_OPER(fCVE_OPER As String)
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCLIE_OP WHERE CLAVE = '" & fCVE_OPER & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        tCLAVE_O.Text = dr("CLAVE").ToString
                        LtNombre1.Text = dr("NOMBRE").ToString
                        LtPlaza.Text = dr("CVE_PLAZA").ToString
                        TCVE_PLAZA.Text = dr("CVE_PLAZA").ToString

                        If TCVE_PLAZA.Text.Trim.Length > 0 Then
                            LtPlaza.Text = BUSCA_CAT("Plazas", TCVE_PLAZA.Text, False)
                        End If
                        LtDom.Text = dr("DOMICILIO").ToString
                        LtDomi.Text = dr("DOMICILIO2").ToString
                        LtPlanta.Text = dr("PLANTA").ToString
                        LtNota.Text = dr("NOTA").ToString
                        LtRFC.Text = dr("RFC").ToString
                    Else
                        tCLAVE_O.Text = ""
                        LtNombre1.Text = ""
                        LtPlaza.Text = ""
                        LtPlaza.Text = ""
                        LtDom.Text = ""
                        LtDomi.Text = ""
                        LtPlanta.Text = ""
                        LtNota.Text = ""
                        LtRFC.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_CLIENTE_OPER2(fCVE_OPER As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCLIE_OP WHERE CLAVE = '" & fCVE_OPER & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCLAVE_D.Text = dr("CLAVE").ToString
                        LtNombre2.Text = dr("NOMBRE").ToString
                        TCVE_PLAZA2.Text = dr("CVE_PLAZA").ToString

                        If TCVE_PLAZA2.Text.Trim.Length > 0 Then
                            LtPlaza2.Text = BUSCA_CAT("Plazas", TCVE_PLAZA2.Text, False)
                        End If
                        LtDom2.Text = dr("DOMICILIO").ToString
                        LtDomi2.Text = dr("DOMICILIO2").ToString
                        LtPlanta2.Text = dr("PLANTA").ToString
                        LtNota2.Text = dr("NOTA").ToString
                        LtRFC2.Text = dr("RFC").ToString
                    Else
                        TCLAVE_D.Text = ""
                        LtNombre2.Text = ""
                        LtPlaza2.Text = ""
                        LtPlaza2.Text = ""
                        LtDom2.Text = ""
                        LtDomi2.Text = ""
                        LtPlanta2.Text = ""
                        LtNota2.Text = ""
                        LtRFC2.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnProducto_Click(sender As Object, e As EventArgs) Handles BtnProducto.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART.Text = Var4
                LtProducto.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TLeyenda.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProducto_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated
        Try
            If TCVE_ART.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("GCPRODUCTOS", TCVE_ART.Text)
                If DESCR <> "" And DESCR <> "N" Then
                    LtProducto.Text = DESCR
                Else
                    MsgBox("Articulo inexistente")
                End If
            End If
        Catch ex As Exception
            Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
