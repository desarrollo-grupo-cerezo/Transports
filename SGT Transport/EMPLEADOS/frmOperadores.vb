Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmOperadores

    Private CADENA As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGA1()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub CARGA1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            TAB1.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill
            Fg2.Dock = DockStyle.Fill
        Catch ex As Exception
        End Try
        Try

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")

            Fg.BeginUpdate()
            Fg2.BeginUpdate()

            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 40

            Fg2.Rows.Count = 1
            Fg2.Rows(0).Height = 40


            TITULOS()
            TITULOS2()

            Fg.EndUpdate()
            Fg2.EndUpdate()

            CADENA = "WHERE ISNULL(O.STATUS,'A') = 'A' OR ISNULL(O.STATUS,'A') = 'R'"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmOperadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Fg.BeginUpdate()
            Fg2.BeginUpdate()

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT CLAVE as 'Clave', O.STATUS, NOMBRE as 'Nombre', O.RFC, CURP, FCONTRA as 'Fecha de contrato', O.CALLE as 'Calle', O.TELEFONO as 'Telefono', 
                O.COLONIA_SAT as 'Colonia', O.CP_SAT, O.MUNICIPIO as 'Ciudad', CVE_ESTADO as 'Estado', LICENCIA as 'Licencia',
                LIC_VENC as 'Vencimiento', LICB + ' ' +  LICC + ' ' + LICE as 'Tipo licencia', PASAPARTE as 'Pasaporte', PAS_VENC as 'Vencimiento', 
                IMSS as 'Afiliacion IMSS', G.DESCR as 'Grupo sanguineo', DIABETICO as 'Diabetico', HIPERTENSO as 'Hipertenso', ALERGIAS as 'Alergias', 
                B.DESCR as 'Banco', NUM_CUENTA as 'Num. cuenta', O.CLABE, FECHANAC as 'Fecha de nacimiento', BENEFICIARIO as 'Beneficiario', 
                AVISAR_A as 'Contactar emergencias', O.POBLACION_SAT as 'Localidad SAT', MUNICIPIO_SAT as 'Municipio SAT',
                O.ESTADO_SAT as 'Estado SAT', O.PAIS_SAT as 'Pais SAT', O.CORREO as 'Correo', MC.DESCR AS 'Motivo cancelación'
                FROM GCOPERADOR O
                LEFT JOIN GCMOTIVO_CANC MC ON MC.CVE_MTC = O.CVE_MTC
                LEFT JOIN GCBANCOS B ON B.CVE_BANCO = O.CVE_BANCO
                LEFT JOIN GCGRUPO_SANGUINEO G ON G.CVE_GRUSAN = O.CVE_GRUSAN
                " & CADENA

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            If CADENA = "WHERE ISNULL(O.STATUS,'A') = 'A' OR ISNULL(O.STATUS,'A') = 'R'" Then
                barEliminar.Visible = True
            Else
                barEliminar.Visible = False
            End If

            CADENA = "WHERE ISNULL(O.STATUS,'A') = 'A' OR ISNULL(O.STATUS,'A') = 'R'"

            BindingSource1.DataSource = dt

            If TAB1.SelectedIndex = 0 Then
                Fg.DataSource = BindingSource1.DataSource
                Fg.AutoSizeCols()
            Else
                Fg2.DataSource = BindingSource1.DataSource
                Fg2.AutoSizeCols()
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.EndUpdate()
        Fg2.EndUpdate()

    End Sub

    Sub TITULOS()

        Fg.Cols.Count = 70
        Fg(0, 1) = "Clave"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(Int32)

        Fg(0, 2) = "Clave montellano"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Estatus"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Nombre"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(String)

        Fg(0, 5) = "RFC"
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)

        Fg(0, 6) = "CURP"
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(String)

        Fg(0, 7) = "FCONTRA"
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(DateTime)

        Fg(0, 8) = "Dirección"
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(String)

        Fg(0, 9) = "TELEFONO"
        Dim c9 As Column = Fg.Cols(9)
        c9.DataType = GetType(String)

        Fg(0, 10) = "COLONIA"
        Dim c10 As Column = Fg.Cols(10)
        c10.DataType = GetType(String)

        Fg(0, 11) = "CP"
        Dim c11 As Column = Fg.Cols(11)
        c11.DataType = GetType(String)

        Fg(0, 12) = "CIUDAD"
        Dim c12 As Column = Fg.Cols(12)
        c12.DataType = GetType(String)

        Fg(0, 13) = "CVE_ESTADO"
        Dim c13 As Column = Fg.Cols(13)
        c13.DataType = GetType(String)

        Fg(0, 14) = "LICENCIA"
        Dim c14 As Column = Fg.Cols(14)
        c14.DataType = GetType(String)

        Fg(0, 15) = "LIC_VENC"
        Dim c15 As Column = Fg.Cols(15)
        c15.DataType = GetType(DateTime)

        Fg(0, 16) = "LICB"
        Dim c16 As Column = Fg.Cols(16)
        c16.DataType = GetType(Int16)

        Fg(0, 17) = "LICC"
        Dim c17 As Column = Fg.Cols(17)
        c17.DataType = GetType(Int16)

        Fg(0, 18) = "LICE"
        Dim c18 As Column = Fg.Cols(18)
        c18.DataType = GetType(Int16)

        Fg(0, 19) = "PASAPARTE"
        Dim c19 As Column = Fg.Cols(19)
        c19.DataType = GetType(String)

        Fg(0, 20) = "PAS_VENC"
        Dim c20 As Column = Fg.Cols(20)
        c20.DataType = GetType(DateTime)

        Fg(0, 21) = "IMSS"
        Dim c21 As Column = Fg.Cols(21)
        c21.DataType = GetType(String)

        Fg(0, 22) = "CVE_GRUSAN"
        Dim c22 As Column = Fg.Cols(22)
        c22.DataType = GetType(Int16)

        Fg(0, 23) = "DIABETICO"
        Dim c23 As Column = Fg.Cols(23)
        c23.DataType = GetType(Int16)

        Fg(0, 24) = "HIPERTENSO"
        Dim c24 As Column = Fg.Cols(24)
        c24.DataType = GetType(Int16)

        Fg(0, 25) = "ALERGIAS"
        Dim c25 As Column = Fg.Cols(25)
        c25.DataType = GetType(Int16)

        Fg(0, 26) = "CVE_BANCO"
        Dim c26 As Column = Fg.Cols(26)
        c26.DataType = GetType(Int32)

        Fg(0, 27) = "APP_MOVIL"
        Dim c27 As Column = Fg.Cols(27)
        c27.DataType = GetType(Int16)

        Fg(0, 28) = "NUM_CUENTA"
        Dim c28 As Column = Fg.Cols(28)
        c28.DataType = GetType(String)

        Fg(0, 29) = "CLABE"
        Dim c29 As Column = Fg.Cols(29)
        c29.DataType = GetType(String)

        Fg(0, 30) = "CVE_TIPO_OPER"
        Dim c30 As Column = Fg.Cols(30)
        c30.DataType = GetType(Int16)

        Fg(0, 31) = "CVE_EDOCIVIL"
        Dim c31 As Column = Fg.Cols(31)
        c31.DataType = GetType(String)

        Fg(0, 32) = "FECHANAC"
        Dim c32 As Column = Fg.Cols(32)
        c32.DataType = GetType(DateTime)

        Fg(0, 33) = "BENEFICIARIO"
        Dim c33 As Column = Fg.Cols(33)
        c33.DataType = GetType(String)

        Fg(0, 34) = "AVISAR_A"
        Dim c34 As Column = Fg.Cols(34)
        c34.DataType = GetType(String)

        Fg(0, 35) = "CVE_PUESTO"
        Dim c35 As Column = Fg.Cols(35)
        c35.DataType = GetType(String)

        Fg(0, 36) = "FACTO_SM_INFONAVIT"
        Dim c36 As Column = Fg.Cols(36)
        c36.DataType = GetType(Decimal)
        Fg.Cols(36).Format = "###,###,##0.00"

        Fg(0, 37) = "FACTO_PORC_INFONAVIT"
        Dim c37 As Column = Fg.Cols(37)
        c37.DataType = GetType(Decimal)
        Fg.Cols(37).Format = "###,###,##0.00"

        Fg(0, 38) = "RET_DIARIA_INFONAVIT"
        Dim c38 As Column = Fg.Cols(38)
        c38.DataType = GetType(Decimal)
        Fg.Cols(38).Format = "###,###,##0.00"

        Fg(0, 39) = "RET_DIARIA_FONACOT"
        Dim c39 As Column = Fg.Cols(39)
        c39.DataType = GetType(Decimal)
        Fg.Cols(39).Format = "###,###,##0.00"

        Fg(0, 40) = "TRANSPORTADORA"
        Dim c40 As Column = Fg.Cols(40)
        c40.DataType = GetType(String)

        Fg(0, 41) = "CVE_TRACTOR"
        Dim c41 As Column = Fg.Cols(41)
        c41.DataType = GetType(String)

        Fg(0, 42) = "CVE_OBS"
        Dim c42 As Column = Fg.Cols(42)
        c42.DataType = GetType(Int32)

        Fg(0, 43) = "CVE_TIPO_REG"
        Dim c43 As Column = Fg.Cols(43)
        c43.DataType = GetType(Int16)

        Fg(0, 44) = "CVE_DEPTO"
        Dim c44 As Column = Fg.Cols(44)
        c44.DataType = GetType(String)

        Fg(0, 45) = "CVE_TIPO_CON"
        Dim c45 As Column = Fg.Cols(45)
        c45.DataType = GetType(Int16)

        Fg(0, 46) = "CVE_TIPO_JOR"
        Dim c46 As Column = Fg.Cols(46)
        c46.DataType = GetType(Int16)

        Fg(0, 47) = "CVE_PER_PAGO"
        Dim c47 As Column = Fg.Cols(47)
        c47.DataType = GetType(Int16)

        Fg(0, 48) = "CVE_RIES_PUE"
        Dim c48 As Column = Fg.Cols(48)
        c48.DataType = GetType(Int16)

        Fg(0, 49) = "Correo"
        Dim c49 As Column = Fg.Cols(49)
        c49.DataType = GetType(String)

        Fg(0, 50) = "VL_SEN_CAR"
        Dim c50 As Column = Fg.Cols(50)
        c50.DataType = GetType(Decimal)
        Fg.Cols(50).Format = "###,###,##0.00"

        Fg(0, 51) = "VL_SEN_VAC"
        Dim c51 As Column = Fg.Cols(51)
        c51.DataType = GetType(Decimal)
        Fg.Cols(51).Format = "###,###,##0.00"

        Fg(0, 52) = "VL_FULL_CAR_CAR"
        Dim c52 As Column = Fg.Cols(52)
        c52.DataType = GetType(Decimal)
        Fg.Cols(52).Format = "###,###,##0.00"

        Fg(0, 53) = "VL_FULL_VAC_VAC"
        Dim c53 As Column = Fg.Cols(53)
        c53.DataType = GetType(Decimal)
        Fg.Cols(53).Format = "###,###,##0.00"

        Fg(0, 54) = "VL_FULL_CAR_VAC"
        Dim c54 As Column = Fg.Cols(54)
        c54.DataType = GetType(Decimal)
        Fg.Cols(54).Format = "###,###,##0.00"

        Fg(0, 55) = "VL_SUE_SEM"
        Dim c55 As Column = Fg.Cols(55)
        c55.DataType = GetType(Decimal)
        Fg.Cols(55).Format = "###,###,##0.00"

        Fg(0, 56) = "VL_SUE_DIA"
        Dim c56 As Column = Fg.Cols(56)
        c56.DataType = GetType(Decimal)
        Fg.Cols(56).Format = "###,###,##0.00"

        Fg(0, 57) = "VL_SUE_DIA_INT"
        Dim c57 As Column = Fg.Cols(57)
        c57.DataType = GetType(Decimal)
        Fg.Cols(57).Format = "###,###,##0.00"

        Fg(0, 58) = "VL_SEN_CAR_KM"
        Dim c58 As Column = Fg.Cols(58)
        c58.DataType = GetType(Decimal)
        Fg.Cols(58).Format = "###,###,##0.00"

        Fg(0, 59) = "VL_SEN_CAR_MI"
        Dim c59 As Column = Fg.Cols(59)
        c59.DataType = GetType(Decimal)
        Fg.Cols(59).Format = "###,###,##0.00"

        Fg(0, 60) = "VL_SEN_VAC_KM"
        Dim c60 As Column = Fg.Cols(60)
        c60.DataType = GetType(Decimal)
        Fg.Cols(60).Format = "###,###,##0.00"

        Fg(0, 61) = "VL_SEN_VAC_MI"
        Dim c61 As Column = Fg.Cols(61)
        c61.DataType = GetType(Decimal)
        Fg.Cols(61).Format = "###,###,##0.00"

        Fg(0, 62) = "VL_FULL_VAC_VAC_KM"
        Dim c62 As Column = Fg.Cols(62)
        c62.DataType = GetType(Decimal)
        Fg.Cols(62).Format = "###,###,##0.00"

        Fg(0, 63) = "VL_FULL_VAC_VAC_MI"
        Dim c63 As Column = Fg.Cols(63)
        c63.DataType = GetType(Decimal)
        Fg.Cols(63).Format = "###,###,##0.00"

        Fg(0, 64) = "VL_FULL_CAR_CAR_KM"
        Dim c64 As Column = Fg.Cols(64)
        c64.DataType = GetType(Decimal)
        Fg.Cols(64).Format = "###,###,##0.00"

        Fg(0, 65) = "VL_FULL_CAR_CAR_MI"
        Dim c65 As Column = Fg.Cols(65)
        c65.DataType = GetType(Decimal)
        Fg.Cols(65).Format = "###,###,##0.00"

        Fg(0, 66) = "VL_FULL_CAR_VAC_KM"
        Dim c66 As Column = Fg.Cols(66)
        c66.DataType = GetType(Decimal)
        Fg.Cols(66).Format = "###,###,##0.00"

        Fg(0, 67) = "VL_FULL_CAR_VAC_MI"
        Dim c67 As Column = Fg.Cols(67)
        c67.DataType = GetType(Decimal)
        Fg.Cols(67).Format = "###,###,##0.00"

        Fg(0, 68) = "CVE_CLASIFIC"
        Dim c68 As Column = Fg.Cols(68)
        c68.DataType = GetType(Int16)

        Fg(0, 69) = "Motico cancelación"
        Dim c69 As Column = Fg.Cols(69)
        c69.DataType = GetType(String)
    End Sub
    Sub TITULOS2()

        Fg2.Cols.Count = 70
        Fg2(0, 1) = "Clave"
        Dim cc1 As Column = Fg2.Cols(1)
        cc1.DataType = GetType(Int32)

        Fg2(0, 2) = "Clave montellano"
        Dim c2 As Column = Fg2.Cols(2)
        c2.DataType = GetType(String)

        Fg2(0, 3) = "Estatus"
        Dim c3 As Column = Fg2.Cols(3)
        c3.DataType = GetType(String)

        Fg2(0, 4) = "Nombre"
        Dim c4 As Column = Fg2.Cols(4)
        c4.DataType = GetType(String)

        Fg2(0, 5) = "RFC"
        Dim c5 As Column = Fg2.Cols(5)
        c5.DataType = GetType(String)

        Fg2(0, 6) = "CURP"
        Dim c6 As Column = Fg2.Cols(6)
        c6.DataType = GetType(String)

        Fg2(0, 7) = "FCONTRA"
        Dim c7 As Column = Fg2.Cols(7)
        c7.DataType = GetType(DateTime)

        Fg2(0, 8) = "Dirección"
        Dim c8 As Column = Fg2.Cols(8)
        c8.DataType = GetType(String)

        Fg2(0, 9) = "TELEFONO"
        Dim c9 As Column = Fg2.Cols(9)
        c9.DataType = GetType(String)

        Fg2(0, 10) = "COLONIA"
        Dim c10 As Column = Fg2.Cols(10)
        c10.DataType = GetType(String)

        Fg2(0, 11) = "CP"
        Dim c11 As Column = Fg2.Cols(11)
        c11.DataType = GetType(String)

        Fg2(0, 12) = "CIUDAD"
        Dim c12 As Column = Fg2.Cols(12)
        c12.DataType = GetType(String)

        Fg2(0, 13) = "CVE_ESTADO"
        Dim c13 As Column = Fg2.Cols(13)
        c13.DataType = GetType(String)

        Fg2(0, 14) = "LICENCIA"
        Dim c14 As Column = Fg2.Cols(14)
        c14.DataType = GetType(String)

        Fg2(0, 15) = "LIC_VENC"
        Dim c15 As Column = Fg2.Cols(15)
        c15.DataType = GetType(DateTime)

        Fg2(0, 16) = "LICB"
        Dim c16 As Column = Fg2.Cols(16)
        c16.DataType = GetType(Int16)

        Fg2(0, 17) = "LICC"
        Dim c17 As Column = Fg2.Cols(17)
        c17.DataType = GetType(Int16)

        Fg2(0, 18) = "LICE"
        Dim c18 As Column = Fg2.Cols(18)
        c18.DataType = GetType(Int16)

        Fg2(0, 19) = "PASAPARTE"
        Dim c19 As Column = Fg2.Cols(19)
        c19.DataType = GetType(String)

        Fg2(0, 20) = "PAS_VENC"
        Dim c20 As Column = Fg2.Cols(20)
        c20.DataType = GetType(DateTime)

        Fg2(0, 21) = "IMSS"
        Dim c21 As Column = Fg2.Cols(21)
        c21.DataType = GetType(String)

        Fg2(0, 22) = "CVE_GRUSAN"
        Dim c22 As Column = Fg2.Cols(22)
        c22.DataType = GetType(Int16)

        Fg2(0, 23) = "DIABETICO"
        Dim c23 As Column = Fg2.Cols(23)
        c23.DataType = GetType(Int16)

        Fg2(0, 24) = "HIPERTENSO"
        Dim c24 As Column = Fg2.Cols(24)
        c24.DataType = GetType(Int16)

        Fg2(0, 25) = "ALERGIAS"
        Dim c25 As Column = Fg2.Cols(25)
        c25.DataType = GetType(Int16)

        Fg2(0, 26) = "CVE_BANCO"
        Dim c26 As Column = Fg2.Cols(26)
        c26.DataType = GetType(Int32)

        Fg2(0, 27) = "APP_MOVIL"
        Dim c27 As Column = Fg2.Cols(27)
        c27.DataType = GetType(Int16)

        Fg2(0, 28) = "NUM_CUENTA"
        Dim c28 As Column = Fg2.Cols(28)
        c28.DataType = GetType(String)

        Fg2(0, 29) = "CLABE"
        Dim c29 As Column = Fg2.Cols(29)
        c29.DataType = GetType(String)

        Fg2(0, 30) = "CVE_TIPO_OPER"
        Dim c30 As Column = Fg2.Cols(30)
        c30.DataType = GetType(Int16)

        Fg2(0, 31) = "CVE_EDOCIVIL"
        Dim c31 As Column = Fg2.Cols(31)
        c31.DataType = GetType(String)

        Fg2(0, 32) = "FECHANAC"
        Dim c32 As Column = Fg2.Cols(32)
        c32.DataType = GetType(DateTime)

        Fg2(0, 33) = "BENEFICIARIO"
        Dim c33 As Column = Fg2.Cols(33)
        c33.DataType = GetType(String)

        Fg2(0, 34) = "AVISAR_A"
        Dim c34 As Column = Fg2.Cols(34)
        c34.DataType = GetType(String)

        Fg2(0, 35) = "CVE_PUESTO"
        Dim c35 As Column = Fg2.Cols(35)
        c35.DataType = GetType(String)

        Fg2(0, 36) = "FACTO_SM_INFONAVIT"
        Dim c36 As Column = Fg2.Cols(36)
        c36.DataType = GetType(Decimal)
        Fg2.Cols(36).Format = "###,###,##0.00"

        Fg2(0, 37) = "FACTO_PORC_INFONAVIT"
        Dim c37 As Column = Fg2.Cols(37)
        c37.DataType = GetType(Decimal)
        Fg2.Cols(37).Format = "###,###,##0.00"

        Fg2(0, 38) = "RET_DIARIA_INFONAVIT"
        Dim c38 As Column = Fg2.Cols(38)
        c38.DataType = GetType(Decimal)
        Fg2.Cols(38).Format = "###,###,##0.00"

        Fg2(0, 39) = "RET_DIARIA_FONACOT"
        Dim c39 As Column = Fg2.Cols(39)
        c39.DataType = GetType(Decimal)
        Fg2.Cols(39).Format = "###,###,##0.00"

        Fg2(0, 40) = "TRANSPORTADORA"
        Dim c40 As Column = Fg2.Cols(40)
        c40.DataType = GetType(String)

        Fg2(0, 41) = "CVE_TRACTOR"
        Dim c41 As Column = Fg2.Cols(41)
        c41.DataType = GetType(String)

        Fg2(0, 42) = "CVE_OBS"
        Dim c42 As Column = Fg2.Cols(42)
        c42.DataType = GetType(Int32)

        Fg2(0, 43) = "CVE_TIPO_REG"
        Dim c43 As Column = Fg2.Cols(43)
        c43.DataType = GetType(Int16)

        Fg2(0, 44) = "CVE_DEPTO"
        Dim c44 As Column = Fg2.Cols(44)
        c44.DataType = GetType(String)

        Fg2(0, 45) = "CVE_TIPO_CON"
        Dim c45 As Column = Fg2.Cols(45)
        c45.DataType = GetType(Int16)

        Fg2(0, 46) = "CVE_TIPO_JOR"
        Dim c46 As Column = Fg2.Cols(46)
        c46.DataType = GetType(Int16)

        Fg2(0, 47) = "CVE_PER_PAGO"
        Dim c47 As Column = Fg2.Cols(47)
        c47.DataType = GetType(Int16)

        Fg2(0, 48) = "CVE_RIES_PUE"
        Dim c48 As Column = Fg2.Cols(48)
        c48.DataType = GetType(Int16)

        Fg2(0, 49) = "Correo"
        Dim c49 As Column = Fg2.Cols(49)
        c49.DataType = GetType(String)

        Fg2(0, 50) = "VL_SEN_CAR"
        Dim c50 As Column = Fg2.Cols(50)
        c50.DataType = GetType(Decimal)
        Fg2.Cols(50).Format = "###,###,##0.00"

        Fg2(0, 51) = "VL_SEN_VAC"
        Dim c51 As Column = Fg2.Cols(51)
        c51.DataType = GetType(Decimal)
        Fg2.Cols(51).Format = "###,###,##0.00"

        Fg2(0, 52) = "VL_FULL_CAR_CAR"
        Dim c52 As Column = Fg2.Cols(52)
        c52.DataType = GetType(Decimal)
        Fg2.Cols(52).Format = "###,###,##0.00"

        Fg2(0, 53) = "VL_FULL_VAC_VAC"
        Dim c53 As Column = Fg2.Cols(53)
        c53.DataType = GetType(Decimal)
        Fg2.Cols(53).Format = "###,###,##0.00"

        Fg2(0, 54) = "VL_FULL_CAR_VAC"
        Dim c54 As Column = Fg2.Cols(54)
        c54.DataType = GetType(Decimal)
        Fg2.Cols(54).Format = "###,###,##0.00"

        Fg2(0, 55) = "VL_SUE_SEM"
        Dim c55 As Column = Fg2.Cols(55)
        c55.DataType = GetType(Decimal)
        Fg2.Cols(55).Format = "###,###,##0.00"

        Fg2(0, 56) = "VL_SUE_DIA"
        Dim c56 As Column = Fg2.Cols(56)
        c56.DataType = GetType(Decimal)
        Fg2.Cols(56).Format = "###,###,##0.00"

        Fg2(0, 57) = "VL_SUE_DIA_INT"
        Dim c57 As Column = Fg2.Cols(57)
        c57.DataType = GetType(Decimal)
        Fg2.Cols(57).Format = "###,###,##0.00"

        Fg2(0, 58) = "VL_SEN_CAR_KM"
        Dim c58 As Column = Fg2.Cols(58)
        c58.DataType = GetType(Decimal)
        Fg2.Cols(58).Format = "###,###,##0.00"

        Fg2(0, 59) = "VL_SEN_CAR_MI"
        Dim c59 As Column = Fg2.Cols(59)
        c59.DataType = GetType(Decimal)
        Fg2.Cols(59).Format = "###,###,##0.00"

        Fg2(0, 60) = "VL_SEN_VAC_KM"
        Dim c60 As Column = Fg2.Cols(60)
        c60.DataType = GetType(Decimal)
        Fg2.Cols(60).Format = "###,###,##0.00"

        Fg2(0, 61) = "VL_SEN_VAC_MI"
        Dim c61 As Column = Fg2.Cols(61)
        c61.DataType = GetType(Decimal)
        Fg2.Cols(61).Format = "###,###,##0.00"

        Fg2(0, 62) = "VL_FULL_VAC_VAC_KM"
        Dim c62 As Column = Fg2.Cols(62)
        c62.DataType = GetType(Decimal)
        Fg2.Cols(62).Format = "###,###,##0.00"

        Fg2(0, 63) = "VL_FULL_VAC_VAC_MI"
        Dim c63 As Column = Fg2.Cols(63)
        c63.DataType = GetType(Decimal)
        Fg2.Cols(63).Format = "###,###,##0.00"

        Fg2(0, 64) = "VL_FULL_CAR_CAR_KM"
        Dim c64 As Column = Fg2.Cols(64)
        c64.DataType = GetType(Decimal)
        Fg2.Cols(64).Format = "###,###,##0.00"

        Fg2(0, 65) = "VL_FULL_CAR_CAR_MI"
        Dim c65 As Column = Fg2.Cols(65)
        c65.DataType = GetType(Decimal)
        Fg2.Cols(65).Format = "###,###,##0.00"

        Fg2(0, 66) = "VL_FULL_CAR_VAC_KM"
        Dim c66 As Column = Fg2.Cols(66)
        c66.DataType = GetType(Decimal)
        Fg2.Cols(66).Format = "###,###,##0.00"

        Fg2(0, 67) = "VL_FULL_CAR_VAC_MI"
        Dim c67 As Column = Fg2.Cols(67)
        c67.DataType = GetType(Decimal)
        Fg2.Cols(67).Format = "###,###,##0.00"

        Fg2(0, 68) = "CVE_CLASIFIC"
        Dim c68 As Column = Fg2.Cols(68)
        c68.DataType = GetType(Int16)

        Fg2(0, 69) = "Motico cancelación"
        Dim c69 As Column = Fg2.Cols(69)
        c69.DataType = GetType(String)
    End Sub
    Private Sub FrmOperadores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        CloseTab("Operadores")
        Me.Dispose()
    End Sub

    Private Sub FrmOperadores_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Try
            Select Case e.KeyCode
                Case Keys.F2
                    BarNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    BarEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            Var3 = ""

            frmOperadoresAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"

            If TAB1.SelectedIndex = 0 Then
                Var2 = Fg(Fg.Row, 1)
                Var3 = Fg(Fg.Row, 3)
            Else
                Var2 = Fg2(Fg2.Row, 1)
                Var3 = Fg2(Fg2.Row, 3)
            End If

            frmOperadoresAE.ShowDialog()
            TAB1.SelectedIndex = 0
            DESPLEGAR()

        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                Var4 = ""
                FrmMotivoBaja.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    Dim CVE_MTC As Long = 0
                    Try
                        CVE_MTC = GRABA_MOTIVO_CANC("OPERADORES", Var4)
                    Catch ex As Exception
                        Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    SQL = "UPDATE GCOPERADOR SET STATUS = 'B', CVE_MTC = " & CVE_MTC & " WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"

                    Dim cmd As New SqlCommand
                    cmd.Connection = cnSAE
                    cmd.CommandTimeout = 120

                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            MsgBox("El registro se cancelo correctamente")
                            DESPLEGAR()
                        Else
                            MsgBox("NO se logro cancelar el operador")
                        End If
                    Else
                        MsgBox("NO se logro cancelar el operador")
                    End If
                Else
                    Dim ResultMensaje As String
                    ResultMensaje = MensajeBox("Cancelación no realizada", "Proceso finalizado", "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("9. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            barEdit_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click

        CADENA = " WHERE ISNULL(O.STATUS, 'A') = 'A' OR ISNULL(O.STATUS,'A') = 'R'"
        barEliminar.Visible = True

        DESPLEGAR()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "OPERADORES")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarOperEliminadas_Click(sender As Object, e As EventArgs)

        barEliminar.Visible = False

        CADENA = " WHERE ISNULL(O.STATUS, 'A') = 'B'"
        barEliminar.Visible = False
        DESPLEGAR()
    End Sub

    Private Sub TAB1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TAB1.SelectedIndexChanged
        Try
            If TAB1.SelectedIndex = 0 Then
                barEliminar.Visible = True

                CADENA = " WHERE ISNULL(O.STATUS, 'A') = 'A' OR ISNULL(O.STATUS, 'A') = 'R'"
                barEliminar.Visible = False
                DESPLEGAR()
            Else
                barEliminar.Visible = False

                CADENA = " WHERE ISNULL(O.STATUS, 'A') = 'B'"
                barEliminar.Visible = False
                DESPLEGAR()

            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
