Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmProvAE
    Private PROVEEDOR As String
    Private PROV_NEW As Boolean = False

    Private ENTRA As Boolean
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmProvAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        End Try

        If DialogOK = "Show" Then
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.CenterToScreen()
        End If


        SplitM1.Dock = DockStyle.Fill
        TAB1.Dock = DockStyle.Fill

        BtnPais.FlatStyle = FlatStyle.Flat
        BtnPais.FlatAppearance.BorderSize = 0
        BtnZona.FlatStyle = FlatStyle.Flat
        BtnZona.FlatAppearance.BorderSize = 0
        BtnTip_Tercero.FlatStyle = FlatStyle.Flat
        BtnTip_Tercero.FlatAppearance.BorderSize = 0
        BtnTip_Opera.FlatStyle = FlatStyle.Flat
        BtnTip_Opera.FlatAppearance.BorderSize = 0
        BtnCuentaCorreo.FlatStyle = FlatStyle.Flat
        BtnCuentaCorreo.FlatAppearance.BorderSize = 0
        BtnDocModelo.FlatStyle = FlatStyle.Flat
        BtnDocModelo.FlatAppearance.BorderSize = 0

        ENTRA = True
        Me.KeyPreview = True
        CboFormaPago.Items.Clear()
        CboFormaPago.Items.Add("Efectivo")
        CboFormaPago.Items.Add("Cheque")
        CboFormaPago.Items.Add("Transferencia")
        CboFormaPago.Items.Add("Tarjeta de crédito")
        CboFormaPago.Items.Add("Otros")

        ULT_PAGOF.Value = Date.Today
        ULT_PAGOF.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        ULT_PAGOF.CustomFormat = "dd/MM/yyyy"
        ULT_PAGOF.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        ULT_PAGOF.EditFormat.CustomFormat = "dd/MM/yyyy"

        ULT_COMPF.Value = Date.Today
        ULT_COMPF.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        ULT_COMPF.CustomFormat = "dd/MM/yyyy"
        ULT_COMPF.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        ULT_COMPF.EditFormat.CustomFormat = "dd/MM/yyyy"

        If Not Valida_Conexion() Then
            Return
        End If

        ENTRA = False

        FgL.Cols.Count = 5
        FgL.Cols.Fixed = 2
        FgL.Cols(3).Width = 0
        FgL.Cols(4).Width = 0
        ENTRA = True

        CONTROLES_MAXLENGHT()
        CARGA_CAT()

        TAB1.SelectedIndex = 0

        ChImprir.Checked = False
        ChMail.Enabled = False
        TEMAILPRED.Enabled = False
        ChENVIOSILEN.Enabled = False

        If Var1 = "Nuevo" Then
            Try
                BtnInicial.Visible = False
                BtnFinal.Visible = False
                BtnAnterior.Visible = False
                BtnSiguiente.Visible = False

                INICIALIZAR_CONTROLES()
                CARGAR_CAMPOS_LIBRES()

                TCLAVE.Text = GET_MAX("PROV" & Empresa, "CLAVE", 10)
                TCLAVE.Enabled = False
                TNOMBRE.Select()
                PROV_NEW = True
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            PROVEEDOR = Var2
            DESPLEGAR_PROVEEDOR()
        End If
    End Sub
    Sub DESPLEGAR_PROVEEDOR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim cmd2 As New SqlCommand
            Dim FORMA_PAGO As Integer

            Dim Exist As Boolean

            Exist = False

            cmd.Connection = cnSAE


            SQL = "Select CLAVE, STATUS, NOMBRE, RFC, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO, LOCALIDAD, MUNICIPIO, ESTADO,
                CVE_PAIS, NACIONALIDAD, TELEFONO, CLASIFIC, FAX, PAG_WEB, CURP, CVE_ZONA, CON_CREDITO, DIASCRED, LIMCRED, CVE_BITA, ULT_PAGOD, ULT_PAGOM,
                ULT_PAGOF, ULT_COMPD, ULT_COMPM, ULT_COMPF, SALDO, VENTAS, DESCUENTO, TIP_TERCERO, TIP_OPERA, P.CVE_OBS, CUENTA_CONTABLE, FORMA_PAGO,
                BENEFICIARIO, TITULAR_CUENTA, BANCO, SUCURSAL_BANCO, CUENTA_BANCO, CLABE, DESC_OTROS, IMPRIR, MAIL, ENVIOSILEN, EMAILPRED, MODELO,
                ISNULL(OB.STR_OBS,'') AS OBSTR, CUENTA_MANTE, ISNULL(CUENTA_PROV,'') AS CTA_PROV,
                ISNULL(CUENTA_FIS_OPER,'') AS CUENTA_FIS_OPER, ISNULL(CUENTA_FIS_ADMIN,'') AS CUENTA_FIS_ADMIN, ISNULL(CUENTA_FIS_MTTO,'') AS CUENTA_FIS_MTTO
                FROM PROV" & Empresa & " P
                LEFT JOIN OPROV" & Empresa & " OB On OB.CVE_OBS = P.CVE_OBS
                WHERE CLAVE = '" & PROVEEDOR & "' AND P.STATUS = 'A'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                Exist = True

                TCLAVE.Text = dr("CLAVE")

                Try
                    TNOMBRE.Text = IIf(IsDBNull(dr("NOMBRE")), "", dr("NOMBRE"))
                    TRFC.Text = IIf(IsDBNull(dr("RFC")), "", dr("RFC"))
                    TCALLE.Text = IIf(IsDBNull(dr("CALLE")), "", dr("CALLE"))
                    TNumInt.Text = IIf(IsDBNull(dr("NUMINT")), "", dr("NUMINT"))
                    TNumExt.Text = IIf(IsDBNull(dr("NUMEXT")), "", dr("NUMEXT"))
                    TCRUZAMIENTOS.Text = IIf(IsDBNull(dr("CRUZAMIENTOS")), "", dr("CRUZAMIENTOS"))
                    tCRUZAMIENTOS2.Text = IIf(IsDBNull(dr("CRUZAMIENTOS2")), "", dr("CRUZAMIENTOS2"))
                    TCOLONIA.Text = IIf(IsDBNull(dr("COLONIA")), "", dr("COLONIA"))
                Catch ex As Exception
                    MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    TCODIGO.Text = IIf(IsDBNull(dr("CODIGO")), "", dr("CODIGO"))
                    TLOCALIDAD.Text = IIf(IsDBNull(dr("LOCALIDAD")), "", dr("LOCALIDAD"))
                    TMunicipio.Text = IIf(IsDBNull(dr("MUNICIPIO")), "", dr("MUNICIPIO"))
                    TEstado.Text = IIf(IsDBNull(dr("ESTADO")), "", dr("ESTADO"))
                    TPais.Text = IIf(IsDBNull(dr("CVE_PAIS")), "", dr("CVE_PAIS"))
                    LtPais.Text = BUSCA_CAT("Pais", TPais.Text)
                    TNacionalidad.Text = IIf(IsDBNull(dr("NACIONALIDAD")), "", dr("NACIONALIDAD"))
                Catch ex As Exception
                    MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    TTELEFONO.Text = IIf(IsDBNull(dr("TELEFONO")), "", dr("TELEFONO"))
                    TClasific.Text = IIf(IsDBNull(dr("CLASIFIC")), "", dr("CLASIFIC"))
                    TFax.Text = IIf(IsDBNull(dr("FAX")), "", dr("FAX"))
                    TPAG_WEB.Text = IIf(IsDBNull(dr("PAG_WEB")), "", dr("PAG_WEB"))
                    TCURP.Text = IIf(IsDBNull(dr("CURP")), "", dr("CURP"))
                    TCVE_ZONA.Text = IIf(IsDBNull(dr("CVE_ZONA")), "", dr("CVE_ZONA"))
                    LtZona.Text = BUSCA_CAT("Zona", TCVE_ZONA.Text)
                    TCUENTA_CONTABLE.Text = dr.ReadNullAsEmptyString("CUENTA_CONTABLE")
                    TCUENTA_PROV.Text = dr.ReadNullAsEmptyString("CTA_PROV")
                    TCUENTA_MANTE.Text = dr.ReadNullAsEmptyString("CUENTA_MANTE")
                    TxCtaFisOper.Text = dr.ReadNullAsEmptyString("CUENTA_FIS_OPER")
                    TxCtaFisAdmin.Text = dr.ReadNullAsEmptyString("CUENTA_FIS_ADMIN")
                    TxCtaFisMtto.Text = dr.ReadNullAsEmptyString("CUENTA_FIS_MTTO")

                Catch ex As Exception
                    MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    If Not IsDBNull(dr("IMPRIR")) Then
                        If dr("IMPRIR") = "S" Then
                            ChImprir.Checked = True
                            ChMail.Enabled = True
                            TEMAILPRED.Enabled = True
                            ChENVIOSILEN.Enabled = True
                        Else
                            ChImprir.Checked = False
                            ChMail.Enabled = False
                            TEMAILPRED.Enabled = False
                            ChENVIOSILEN.Enabled = False
                        End If
                    Else
                        ChImprir.Checked = False
                    End If
                Catch ex As Exception
                    MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    If IsDBNull(dr("MAIL")) Then
                        ChMail.Checked = False
                    Else
                        If dr("MAIL") = "S" Then
                            ChMail.Checked = True
                        Else
                            ChMail.Checked = False
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    If IsDBNull(dr("ENVIOSILEN")) Then
                        ChENVIOSILEN.Checked = False
                    Else
                        If dr("ENVIOSILEN") = "S" Then
                            ChENVIOSILEN.Checked = True
                        Else
                            ChENVIOSILEN.Checked = False
                        End If

                    End If
                    TEMAILPRED.Text = IIf(IsDBNull(dr("EMAILPRED")), "", dr("EMAILPRED"))
                    If dr("CON_CREDITO") = "S" Then
                        chCON_CREDITO.Checked = True
                        TDiasCred.Enabled = True
                        TLimCred.Enabled = True
                    Else
                        chCON_CREDITO.Checked = False
                        TDiasCred.Enabled = False
                        TLimCred.Enabled = False
                    End If
                Catch ex As Exception
                    MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    FORMA_PAGO = IIf(IsDBNull(dr("FORMA_PAGO")), 0, dr("FORMA_PAGO"))
                    Try
                        CboFormaPago.SelectedIndex = FORMA_PAGO
                    Catch ex As Exception
                        MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Select Case FORMA_PAGO
                        Case 0 'EFECTIVO
                            TDESC_OTROS.Visible = True
                            CboBanco.Visible = False
                            TSucursal.Visible = False
                            TCuenta.Visible = False
                            TDESC_OTROS.Text = IIf(IsDBNull(dr("DESC_OTROS")), "", dr("DESC_OTROS"))
                        Case 1 'CHEQUE
                            TDESC_OTROS.Visible = True
                            CboBanco.Visible = False
                            TSucursal.Visible = False
                            TCuenta.Visible = False
                            TDESC_OTROS.Text = IIf(IsDBNull(dr("BENEFICIARIO")), "", dr("BENEFICIARIO"))
                        Case 2 'TRANSFERENCIA
                            TDESC_OTROS.Visible = True
                            CboBanco.Visible = True
                            TSucursal.Visible = True
                            TCuenta.Visible = True
                            '=========================================================
                            '=========================================================
                            '   BANCOS   BANCOS   BANCOS   BANCOS   BANCOS   BANCOS
                            '=========================================================
                            '=========================================================
                            Try
                                For Each vdp As ValueDescriptionPair In CboBanco.Items
                                    If vdp.ValuePair = dr("BANCO") Then
                                        CboBanco.SelectedIndex = vdp.cboIndex
                                        Exit For
                                    End If
                                Next
                            Catch ex As Exception
                                MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
                                Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            TDESC_OTROS.Text = IIf(IsDBNull(dr("TITULAR_CUENTA")), "", dr("TITULAR_CUENTA"))
                            TSucursal.Text = IIf(IsDBNull(dr("SUCURSAL_BANCO")), "", dr("SUCURSAL_BANCO"))
                            TCuenta.Text = IIf(IsDBNull(dr("CUENTA_BANCO")), "", dr("CUENTA_BANCO"))
                            TClabe.Text = IIf(IsDBNull(dr("CLABE")), "", dr("CLABE"))
                        Case 3 'TARJETA DE CREDITO
                            TDESC_OTROS.Visible = True
                            CboBanco.Visible = False
                            TSucursal.Visible = False
                            TCuenta.Visible = False
                            TDESC_OTROS.Text = IIf(IsDBNull(dr("DESC_OTROS")), "", dr("DESC_OTROS"))
                        Case 4 'OTROS
                            TDESC_OTROS.Visible = True
                            CboBanco.Visible = False
                            TSucursal.Visible = False
                            TCuenta.Visible = False
                            TDESC_OTROS.Text = IIf(IsDBNull(dr("DESC_OTROS")), "", dr("DESC_OTROS"))
                    End Select
                Catch ex As Exception
                    MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    TDiasCred.Value = IIf(IsDBNull(dr("DIASCRED")), "0", dr("DIASCRED"))
                    TLimCred.Value = IIf(IsDBNull(dr("DIASCRED")), "0", dr("LIMCRED"))
                    TSaldo.Value = IIf(IsDBNull(dr("SALDO")), "0", dr("SALDO"))

                    TULT_PAGOD.Text = IIf(IsDBNull(dr("ULT_PAGOD")), "", dr("ULT_PAGOD"))
                    TULT_PAGOM.Value = IIf(IsDBNull(dr("ULT_PAGOM")), "0", dr("ULT_PAGOM"))
                    If IsDate(dr("ULT_PAGOF")) Then
                        ULT_PAGOF.Value = dr("ULT_PAGOF")
                    Else
                        ULT_PAGOF.Value = Now
                    End If
                Catch ex As Exception
                    MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    TDESCUENTO.Value = IIf(IsDBNull(dr("DESCUENTO")), "0", dr("DESCUENTO"))

                    TTIP_TERCERO.Value = IIf(IsDBNull(dr("TIP_TERCERO")), "0", dr("TIP_TERCERO"))
                    TTIP_OPERA.Value = IIf(IsDBNull(dr("TIP_OPERA")), "0", dr("TIP_OPERA"))
                    LtTip_Tercero.Text = BUSCA_CAT("Tip Tercero", TTIP_TERCERO.Text)
                    LtTip_Opera.Text = BUSCA_CAT("Tip Opera", TTIP_OPERA.Text)

                    TULT_COMPD.Text = IIf(IsDBNull(dr("ULT_COMPD")), "", dr("ULT_COMPD"))

                    TULT_COMPM.Value = IIf(IsDBNull(dr("ULT_COMPM")), "0", dr("ULT_COMPM"))
                    If IsDate(dr("ULT_COMPF")) Then
                        ULT_COMPF.Value = dr("ULT_COMPF")
                    End If
                    TVENTAS.Value = IIf(IsDBNull(dr("VENTAS")), "0", dr("VENTAS"))
                Catch ex As Exception
                    MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            Else
                INICIALIZAR_CONTROLES()
            End If
            dr.Close()

            CARGAR_CAMPOS_LIBRES()

            TCLAVE.Enabled = False
            TNOMBRE.Select()

        Catch ex As Exception
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_CAMPOS_LIBRES()
        Try
            Dim cmd2 As New SqlCommand
            Dim dr2 As SqlDataReader
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            Dim DATA_TYPE As String
            Dim CAMPO As String
            cmd.Connection = cnSAE
            cmd2.Connection = cnSAE

            'CAMPOS LIBRES
            Try
                SQL = "SELECT NUM_EMP, IDTABLA, ISNULL(CAMPO,'') AS CAMP, ETIQUETA FROM PARAM_CAMPOSLIBRES" & Empresa & " WHERE IDTABLA = 'PROV_CLIB'"

                ENTRA = False
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                FgL.Rows.Count = 1
                Do While dr.Read

                    FgL.AddItem("" & vbTab & dr("ETIQUETA").ToString & vbTab & " " & vbTab & dr("CAMP").ToString & vbTab & " ")

                    SQL = "SELECT * FROM PROV_CLIB" & Empresa & " WHERE CVE_PROV = '" & TCLAVE.Text & "'"
                    cmd2.CommandText = SQL
                    dr2 = cmd2.ExecuteReader
                    If dr2.Read Then
                        CAMPO = dr("CAMP").ToString
                        FgL(FgL.Rows.Count - 1, 2) = dr2(CAMPO)
                    End If
                    dr2.Close()
                Loop
                dr.Close()
                ENTRA = True
            Catch Ex As Exception
                Bitacora("130. " & Ex.Message & vbNewLine & Ex.StackTrace)
                MsgBox("130. " & Ex.Message & vbNewLine & Ex.StackTrace)
            End Try

            Try
                Dim cs1 As CellStyle
                Dim rg1 As New CellRange()
                Dim c1numeric As New C1.Win.C1Input.C1NumericEdit With {
                    .VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
                }

                For k As Integer = 1 To FgL.Rows.Count - 1

                    DATA_TYPE = GET_DATATYPE("PROV_CLIB" & Empresa, FgL(k, 3))
                    FgL(k, 4) = DATA_TYPE

                    Select Case DATA_TYPE.ToLower
                        Case "varchar", "char"
                            Dim st As CellStyle = FgL.Styles.Add("MyStyle")
                            st.DataType = GetType(String)
                            Dim rg As CellRange = FgL.GetCellRange(k, 2, 1, 2)
                            rg.Style = st
                        Case "int"
                            cs1 = FgL.Styles.Add("DataType1")
                            cs1.DataType = GetType(Int32)
                            cs1.TextAlign = TextAlignEnum.RightCenter
                            cs1.Editor = c1numeric


                            rg1 = FgL.GetCellRange(k, 2)
                            rg1.Style = cs1
                        Case "smallint"
                            cs1 = FgL.Styles.Add("DataType1")
                            cs1.DataType = GetType(Int16)
                            cs1.Editor = c1numeric
                            rg1 = FgL.GetCellRange(k, 2)
                            rg1.Style = cs1
                        Case "float"
                            cs1 = FgL.Styles.Add("DataType1")
                            cs1.DataType = GetType(Single)
                            cs1.Editor = c1numeric
                            rg1 = FgL.GetCellRange(k, 2)
                            rg1.Style = cs1
                        Case "date", "datetime"
                            cs1 = FgL.Styles.Add("DataType1")
                            cs1.DataType = GetType(DateTime)
                            rg1 = FgL.GetCellRange(k, 2)
                            rg1.Style = cs1
                    End Select
                Next
            Catch Ex As Exception
                Bitacora("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
                MsgBox("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
            End Try

        Catch Ex As Exception
            Bitacora("150. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("150. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub CARGA_CAT()

        Dim cmd As New SqlCommand
        Dim z As Integer
        cmd.Connection = cnSAE

        Try
            Dim dr As SqlDataReader

            SQL = "SELECT * FROM GCBANCOS WHERE STATUS = 'A' ORDER BY DESCR"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboBanco.Items.Clear()
            Do While dr.Read
                CboBanco.Items.Add(New ValueDescriptionPair(dr("CVE_BANCO"), dr("DESCR"), dr("CVE_BANCO"), "", z))
                z += 1
            Loop
            dr.Close()

        Catch ex As Exception
            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CONTROLES_MAXLENGHT()

        TCLAVE.MaxLength = 10
        TNOMBRE.MaxLength = 120
        TRFC.MaxLength = 15
        TCALLE.MaxLength = 80
        TNumInt.MaxLength = 15
        TNumExt.MaxLength = 15
        TCRUZAMIENTOS.MaxLength = 40
        tCRUZAMIENTOS2.MaxLength = 40
        TCOLONIA.MaxLength = 50
        TCODIGO.MaxLength = 5
        TLOCALIDAD.MaxLength = 50
        TMunicipio.MaxLength = 50
        TEstado.MaxLength = 50

        TTIP_TERCERO.Value = 0
        TTIP_OPERA.Value = 0

        TPais.MaxLength = 2
        TNacionalidad.MaxLength = 40
        TTELEFONO.MaxLength = 25
        TClasific.MaxLength = 5
        TFax.MaxLength = 25
        TPAG_WEB.MaxLength = 60
        TCURP.MaxLength = 18
        TCVE_ZONA.MaxLength = 6
        TULT_PAGOD.MaxLength = 20
        TULT_COMPD.MaxLength = 20
        TCUENTA_CONTABLE.MaxLength = 28
        TDESC_OTROS.MaxLength = 60
        TEMAILPRED.MaxLength = 60
        TMODELO.MaxLength = 255

        TxCtaFisOper.MaxLength = 28
        TxCtaFisAdmin.MaxLength = 28
        TxCtaFisMtto.MaxLength = 28

    End Sub
    Sub INICIALIZAR_CONTROLES()
        Try
            TCLAVE.Text = ""
            TNOMBRE.Text = ""
            TRFC.Text = ""
            TCALLE.Text = ""
            TNumInt.Text = ""
            TNumExt.Text = ""
            TCRUZAMIENTOS.Text = ""
            tCRUZAMIENTOS2.Text = ""
            TCOLONIA.Text = ""
            TCODIGO.Text = ""
            TLOCALIDAD.Text = ""
            TMunicipio.Text = ""
            TEstado.Text = ""
            TPais.Text = ""
            TNacionalidad.Text = ""
            TTELEFONO.Text = ""
            TClasific.Text = ""
            TFax.Text = ""
            TPAG_WEB.Text = ""
            TCURP.Text = ""
            TCVE_ZONA.Text = ""
            chCON_CREDITO.Checked = False

            TDiasCred.Value = 0
            TLimCred.Value = 0
            TULT_PAGOD.Text = ""
            TULT_PAGOM.Value = 0
            ULT_PAGOF.Value = 0
            TULT_COMPD.Text = ""
            TULT_COMPM.Value = 0
            TULT_PAGOM.Value = 0
            TSaldo.Value = 0
            TVENTAS.Value = 0
            TDESCUENTO.Value = 0
            TTIP_TERCERO.Value = 0
            TTIP_OPERA.Value = 0
            TCVE_OBS.Text = 0
            TCUENTA_CONTABLE.Text = ""

            TxCtaFisOper.Text = ""
            TxCtaFisAdmin.Text = ""
            TxCtaFisMtto.Text = ""

            CboFormaPago.SelectedIndex = 1
            TDESC_OTROS.Text = ""
            ChImprir.Checked = False
            'tMAIL.text = ""
            'tNIVELSEC.value = 0
            ChENVIOSILEN.Checked = False
            TEMAILPRED.Text = ""
            TMODELO.Text = ""
        Catch Ex As Exception
            Bitacora("180. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("180. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmProvAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmProvAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_BITA As Long
        Dim CVE_OBS As Long
        Dim CVE_BANCO As String
        Dim SUCURSAL As String
        Dim CUENTA As String
        Dim CLABE As String
        Dim BENEFICIARIO As String
        Dim TITULAR_CUENTA As String

        Dim DESC_OTROS As String
        Dim FORMA_PAGO As Integer
        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }


        If PROV_NEW And TRFC.Text <> "XAXX010101000" And TRFC.Text.Trim.Length > 0 Then
            If RFC_CLIENTE_EXISTE(TRFC.Text) Then
                If MsgBox("El RFC actualmente se encuentra asignado al cliente " & vbNewLine & Var10 & vbNewLine & ", Desea continuar?", vbYesNo) = vbNo Then
                    Return
                End If
            End If
        End If

        FgL.FinishEditing()

        'BENEFICIARIO = "" : TITULAR_CUENTA = "" : SUCURSAL = "" : CUENTA = "" : CLABE = "" : CVE_BANCO = ""
        DESC_OTROS = TDESC_OTROS.Text
        BENEFICIARIO = DESC_OTROS
        TITULAR_CUENTA = TDESC_OTROS.Text
        SUCURSAL = TSucursal.Text
        CUENTA = TCuenta.Text
        CLABE = TClabe.Text
        CVE_BANCO = ""
        Try
            FORMA_PAGO = CboFormaPago.SelectedIndex

            Select Case FORMA_PAGO
                Case 0 'EFECTIVO
                    DESC_OTROS = TDESC_OTROS.Text
                Case 1 'CHEQUE
                    DESC_OTROS = TDESC_OTROS.Text
                    BENEFICIARIO = DESC_OTROS
                Case 2 'TRANSFERENCIA
                    Try
                        If CboBanco.SelectedIndex = -1 Then
                            CVE_BANCO = ""
                        Else
                            CVE_BANCO = CType(CboBanco.SelectedItem, ValueDescriptionPair).ClavePair
                        End If
                    Catch ex As Exception
                        MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    TITULAR_CUENTA = TDESC_OTROS.Text
                    SUCURSAL = TSucursal.Text
                    CUENTA = TCuenta.Text
                    CLABE = TClabe.Text
                Case 3 'TARJETA DE CREDITO
                    DESC_OTROS = TDESC_OTROS.Text
                Case 4 'OTROS
                    DESC_OTROS = TDESC_OTROS.Text
            End Select
        Catch ex As Exception
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "IF EXISTS (SELECT CLAVE FROM PROV" & Empresa & " WHERE CLAVE = @CLAVE)
            UPDATE PROV" & Empresa & " SET CLAVE = @CLAVE, NOMBRE = @NOMBRE, RFC = @RFC, CALLE = @CALLE, NUMINT = @NUMINT,
            NUMEXT = @NUMEXT, CRUZAMIENTOS = @CRUZAMIENTOS, CRUZAMIENTOS2 = @CRUZAMIENTOS2, COLONIA = @COLONIA, CODIGO = @CODIGO,
            LOCALIDAD = @LOCALIDAD, MUNICIPIO = @MUNICIPIO, ESTADO = @ESTADO, CVE_PAIS = @CVE_PAIS, NACIONALIDAD = @NACIONALIDAD,
            TELEFONO = @TELEFONO, CLASIFIC = @CLASIFIC, FAX = @FAX, PAG_WEB = @PAG_WEB, CURP = @CURP, CVE_ZONA = @CVE_ZONA, 
            CON_CREDITO = @CON_CREDITO, DIASCRED = @DIASCRED, LIMCRED = @LIMCRED, CVE_BITA = @CVE_BITA, ULT_PAGOD = @ULT_PAGOD, 
            ULT_PAGOM = @ULT_PAGOM, ULT_PAGOF = @ULT_PAGOF, ULT_COMPD = @ULT_COMPD, ULT_COMPM = @ULT_COMPM, ULT_COMPF = @ULT_COMPF, 
            SALDO = @SALDO, VENTAS = @VENTAS, DESCUENTO = @DESCUENTO, TIP_TERCERO = @TIP_TERCERO, TIP_OPERA = @TIP_OPERA, 
            CVE_OBS = @CVE_OBS, CUENTA_CONTABLE = @CUENTA_CONTABLE, FORMA_PAGO = @FORMA_PAGO, BENEFICIARIO = @BENEFICIARIO, 
            TITULAR_CUENTA = @TITULAR_CUENTA, BANCO = @BANCO, SUCURSAL_BANCO = @SUCURSAL_BANCO, CUENTA_BANCO = @CUENTA_BANCO, 
            CLABE = @CLABE, DESC_OTROS = @DESC_OTROS, IMPRIR = @IMPRIR, MAIL = @MAIL, ENVIOSILEN = @ENVIOSILEN, EMAILPRED = 
            @EMAILPRED, MODELO = @MODELO, CUENTA_MANTE = @CUENTA_MANTE, CUENTA_PROV = @CUENTA_PROV, CUENTA_FIS_OPER=@CUENTA_FIS_OPER, CUENTA_FIS_ADMIN=@CUENTA_FIS_ADMIN, CUENTA_FIS_MTTO=@CUENTA_FIS_MTTO
            WHERE CLAVE = @CLAVE
            ELSE
            INSERT INTO PROV" & Empresa & " (CLAVE, STATUS, NOMBRE, RFC, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, 
            CODIGO, LOCALIDAD, MUNICIPIO, ESTADO, CVE_PAIS, NACIONALIDAD, TELEFONO, CLASIFIC, FAX, PAG_WEB, CURP, CVE_ZONA, CON_CREDITO, 
            DIASCRED, LIMCRED, CVE_BITA, ULT_PAGOD, ULT_PAGOM, ULT_PAGOF, ULT_COMPD, ULT_COMPM, ULT_COMPF, SALDO, VENTAS, DESCUENTO, 
            TIP_TERCERO, TIP_OPERA, CVE_OBS, CUENTA_CONTABLE, FORMA_PAGO, BENEFICIARIO, TITULAR_CUENTA, BANCO, SUCURSAL_BANCO,
            CUENTA_BANCO, CLABE, DESC_OTROS, IMPRIR, MAIL, ENVIOSILEN, EMAILPRED, MODELO, CUENTA_MANTE, CUENTA_PROV, CUENTA_FIS_OPER, CUENTA_FIS_ADMIN, CUENTA_FIS_MTTO) 
            VALUES (
            @CLAVE, 'A', @NOMBRE, @RFC, @CALLE, @NUMINT, @NUMEXT, @CRUZAMIENTOS, @CRUZAMIENTOS2, @COLONIA, @CODIGO, @LOCALIDAD, 
            @MUNICIPIO, @ESTADO, @CVE_PAIS, @NACIONALIDAD, @TELEFONO, @CLASIFIC, @FAX, @PAG_WEB, @CURP, @CVE_ZONA, @CON_CREDITO, 
            @DIASCRED, @LIMCRED, @CVE_BITA, @ULT_PAGOD, @ULT_PAGOM, @ULT_PAGOF, @ULT_COMPD, @ULT_COMPM, @ULT_COMPF, @SALDO, @VENTAS, 
            @DESCUENTO, @TIP_TERCERO, @TIP_OPERA, @CVE_OBS, @CUENTA_CONTABLE, @FORMA_PAGO, @BENEFICIARIO, @TITULAR_CUENTA, @BANCO, 
            @SUCURSAL_BANCO, @CUENTA_BANCO, @CLABE, @DESC_OTROS, @IMPRIR, @MAIL, @ENVIOSILEN, @EMAILPRED, @MODELO, @CUENTA_MANTE, @CUENTA_PROV, @CUENTA_FIS_OPER, @CUENTA_FIS_ADMIN, @CUENTA_FIS_MTTO)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = RemoveCharacter(TCLAVE.Text)
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = RemoveCharacter(TNOMBRE.Text)
            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = RemoveCharacter(TRFC.Text)
            cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TCALLE.Text
            cmd.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = TNumInt.Text
            cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = TNumExt.Text
            cmd.Parameters.Add("@CRUZAMIENTOS", SqlDbType.VarChar).Value = TCRUZAMIENTOS.Text
            cmd.Parameters.Add("@CRUZAMIENTOS2", SqlDbType.VarChar).Value = tCRUZAMIENTOS2.Text
            cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = TCOLONIA.Text
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = TCODIGO.Text
            cmd.Parameters.Add("@LOCALIDAD", SqlDbType.VarChar).Value = TLOCALIDAD.Text
            cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMunicipio.Text
            cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = TEstado.Text
            cmd.Parameters.Add("@CVE_PAIS", SqlDbType.VarChar).Value = TPais.Text
            cmd.Parameters.Add("@NACIONALIDAD", SqlDbType.VarChar).Value = TNacionalidad.Text
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = TTELEFONO.Text
            cmd.Parameters.Add("@CLASIFIC", SqlDbType.VarChar).Value = TClasific.Text
            cmd.Parameters.Add("@FAX", SqlDbType.VarChar).Value = TFax.Text
            cmd.Parameters.Add("@PAG_WEB", SqlDbType.VarChar).Value = TPAG_WEB.Text
            cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = TCURP.Text
            cmd.Parameters.Add("@CVE_ZONA", SqlDbType.VarChar).Value = TCVE_ZONA.Text
            cmd.Parameters.Add("@CON_CREDITO", SqlDbType.VarChar).Value = IIf(chCON_CREDITO.Checked, "S", "N")
            cmd.Parameters.Add("@DIASCRED", SqlDbType.Int).Value = CONVERTIR_TO_INT(TDiasCred.Value)
            cmd.Parameters.Add("@LIMCRED", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TLimCred.Value)
            cmd.Parameters.Add("@CVE_BITA", SqlDbType.Int).Value = CVE_BITA
            cmd.Parameters.Add("@SALDO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TSaldo.Value)

            cmd.Parameters.Add("@ULT_PAGOD", SqlDbType.VarChar).Value = TULT_PAGOD.Text
            cmd.Parameters.Add("@ULT_PAGOM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TULT_PAGOM.Value)
            cmd.Parameters.Add("@ULT_PAGOF", SqlDbType.DateTime).Value = ULT_PAGOF.Value
            cmd.Parameters.Add("@ULT_COMPD", SqlDbType.VarChar).Value = TULT_COMPD.Text
            cmd.Parameters.Add("@ULT_COMPM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TULT_COMPM.Value)
            cmd.Parameters.Add("@ULT_COMPF", SqlDbType.DateTime).Value = ULT_COMPF.Value

            cmd.Parameters.Add("@VENTAS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVENTAS.Value)
            cmd.Parameters.Add("@DESCUENTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TDESCUENTO.Value)
            cmd.Parameters.Add("@TIP_TERCERO", SqlDbType.Int).Value = CONVERTIR_TO_INT(TTIP_TERCERO.Value)
            cmd.Parameters.Add("@TIP_OPERA", SqlDbType.Int).Value = CONVERTIR_TO_INT(TTIP_OPERA.Value)
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            cmd.Parameters.Add("@CUENTA_CONTABLE", SqlDbType.VarChar).Value = TCUENTA_CONTABLE.Text
            cmd.Parameters.Add("@CUENTA_PROV", SqlDbType.VarChar).Value = TCUENTA_PROV.Text
            cmd.Parameters.Add("@CUENTA_BANCO", SqlDbType.VarChar).Value = CUENTA
            cmd.Parameters.Add("@CUENTA_MANTE", SqlDbType.VarChar).Value = TCUENTA_MANTE.Text

            cmd.Parameters.Add("@FORMA_PAGO", SqlDbType.Int).Value = CboFormaPago.SelectedIndex
            cmd.Parameters.Add("@BENEFICIARIO", SqlDbType.VarChar).Value = BENEFICIARIO
            cmd.Parameters.Add("@TITULAR_CUENTA", SqlDbType.VarChar).Value = TITULAR_CUENTA
            cmd.Parameters.Add("@BANCO", SqlDbType.VarChar).Value = CVE_BANCO
            cmd.Parameters.Add("@SUCURSAL_BANCO", SqlDbType.VarChar).Value = SUCURSAL
            cmd.Parameters.Add("@CLABE", SqlDbType.VarChar).Value = CLABE
            cmd.Parameters.Add("@DESC_OTROS", SqlDbType.VarChar).Value = TDESC_OTROS.Text
            cmd.Parameters.Add("@IMPRIR", SqlDbType.VarChar).Value = "S"
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = "S"
            cmd.Parameters.Add("@ENVIOSILEN", SqlDbType.VarChar).Value = "N"
            cmd.Parameters.Add("@EMAILPRED", SqlDbType.VarChar).Value = TEMAILPRED.Text
            cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO.Text

            cmd.Parameters.Add("@CUENTA_FIS_OPER", SqlDbType.VarChar).Value = TxCtaFisOper.Text
            cmd.Parameters.Add("@CUENTA_FIS_ADMIN", SqlDbType.VarChar).Value = TxCtaFisAdmin.Text
            cmd.Parameters.Add("@CUENTA_FIS_MTTO", SqlDbType.VarChar).Value = TxCtaFisMtto.Text

            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    GRABAR_CAMPOS_LIBRES()
                    If PROV_NEW Then

                        Try
                            If IsNumeric(TCLAVE.Text.Trim) Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = " & Val(TCLAVE.Text.Trim) & " WHERE ID_TABLA = 12 or ID_TABLA = 65"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            Bitacora("230. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("230. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub GRABAR_CAMPOS_LIBRES()
        Dim CADENA As String, CADENA2 As String

        Try
            ENTRA = False
            SQL = "UPDATE PROV_CLIB" & Empresa & " SET "
            CADENA = " IF @@ROWCOUNT = 0 " &
                     "INSERT INTO PROV_CLIB" & Empresa & "(CVE_PROV, "
            CADENA2 = TCLAVE.Text & "','"
            For k = 1 To FgL.Rows.Count - 1
                Try
                    If Not IsNothing(FgL(k, 2)) Then
                        If Not IsDBNull(FgL(k, 2)) Then
                            If Not String.IsNullOrEmpty(FgL(k, 2)) Then
                                If FgL(k, 2).ToString.Length > 0 Then
                                    If FgL(k, 4).ToString = "int" Or FgL(k, 4).ToString = "smallint" Or FgL(k, 4).ToString = "float" Then
                                        SQL = SQL & " " & FgL(k, 3) & " = " & FgL(k, 2) & ", "
                                    Else
                                        SQL = SQL & " " & FgL(k, 3) & " = '" & FgL(k, 2) & "', "
                                    End If
                                    CADENA = CADENA & FgL(k, 3) & ", "
                                    CADENA2 = CADENA2 & FgL(k, 2) & "','"
                                End If
                            End If
                        End If
                    End If

                Catch ex As Exception
                    Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            ENTRA = True
            If SQL = "UPDATE PROV_CLIB" & Empresa & " SET " Then
                SQL = ""
            Else
                CADENA = CADENA.Substring(0, CADENA.Length - 2) & ") VALUES ('"
                CADENA2 = CADENA2.Substring(0, CADENA2.Length - 3) & "')"
                SQL = SQL.Substring(0, SQL.Length - 2) & " WHERE CVE_PROV = '" & TCLAVE.Text & "'" & CADENA & CADENA2
                Dim cmd As New SqlCommand With {
                    .Connection = cnSAE,
                    .CommandText = SQL
                }
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End If
        Catch Ex As Exception
            Bitacora("250. " & Ex.Message & vbNewLine & Ex.StackTrace)
            'MsgBox("250. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmProvAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Proveedores ")
        Try
            If ExisteTab("Proveedores") Then
                FrmProv.DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        Try
            If FrmProv.Fg.Row > 1 Then
                PROVEEDOR = FrmProv.Fg(FrmProv.Fg.Row - 1, 1)
                FrmProv.Fg.Row = FrmProv.Fg.Row - 1
                DESPLEGAR_PROVEEDOR()
            End If

        Catch Ex As Exception
            Bitacora("260. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("260. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnInicial_Click(sender As Object, e As EventArgs) Handles BtnInicial.Click
        Try
            If FrmProv.Fg.Row > 0 Then
                PROVEEDOR = FrmProv.Fg(1, 1)
                FrmProv.Fg.Row = 1
                DESPLEGAR_PROVEEDOR()
            End If
        Catch Ex As Exception
            Bitacora("270. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("270. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        Try
            If FrmProv.Fg.Row > 0 Then

                If FrmProv.Fg.Row < FrmProv.Fg.Rows.Count - 1 Then
                    PROVEEDOR = FrmProv.Fg(FrmProv.Fg.Row + 1, 1)
                    FrmProv.Fg.Row = FrmProv.Fg.Row + 1
                    DESPLEGAR_PROVEEDOR()
                End If
            End If
        Catch Ex As Exception
            Bitacora("280. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("280. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnFinal_Click(sender As Object, e As EventArgs) Handles BtnFinal.Click
        Try
            If FrmProv.Fg.Row > 0 Then
                PROVEEDOR = FrmProv.Fg(FrmProv.Fg.Rows.Count - 1, 1)
                FrmProv.Fg.Row = FrmProv.Fg.Rows.Count - 1
                DESPLEGAR_PROVEEDOR()
            End If
        Catch ex As Exception
            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgL_EnterCell(sender As Object, e As EventArgs) Handles FgL.EnterCell

        Try
            If FgL.Row > 0 And ENTRA Then
                FgL.StartEditing()
            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTip_Tercero_Click(sender As Object, e As EventArgs) Handles BtnTip_Tercero.Click
        Try
            Var2 = "Tip Tercero"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TTIP_TERCERO.Value = Var4
                LtTip_Tercero.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TTIP_OPERA.Select()
            End If
        Catch Ex As Exception
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTip_Opera_Click(sender As Object, e As EventArgs) Handles BtnTip_Opera.Click

        Try
            Var2 = "Tip Opera"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TTIP_OPERA.Value = Var4
                LtTip_Opera.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch Ex As Exception
            MsgBox("330. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("330. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnZona_Click(sender As Object, e As EventArgs) Handles BtnZona.Click
        Try
            Var2 = "Zona"
            Var4 = ""
            Var5 = ""

            frmSelItem.ShowDialog()
            TCVE_ZONA.Text = Var4
            LtZona.Text = Var5
            Var2 = ""
            Var4 = ""
            Var5 = ""
        Catch ex As Exception
            MsgBox("340. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnPais_Click(sender As Object, e As EventArgs) Handles BtnPais.Click
        Try
            Var2 = "Pais"
            Var4 = ""
            Var5 = ""

            frmSelItem.ShowDialog()
            TPais.Text = Var4
            LtPais.Text = Var5
            Var2 = ""
            Var4 = ""
            Var5 = ""
        Catch ex As Exception
            MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChCON_CREDITO_CheckedChanged(sender As Object, e As EventArgs) Handles chCON_CREDITO.CheckedChanged

        Try
            If chCON_CREDITO.Checked Then
                TDiasCred.Enabled = True
                TLimCred.Enabled = True
            Else
                TDiasCred.Enabled = False
                TLimCred.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("365. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("365. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboFormaPago_SelectedItemChanged(sender As Object, e As EventArgs) Handles CboFormaPago.SelectedItemChanged
        'cboFormaPago.Items.Add("Efectivo")
        'cboFormaPago.Items.Add("Cheque")
        'cboFormaPago.Items.Add("Transferencia")
        'cboFormaPago.Items.Add("Tarjeta de crédito")
        'cboFormaPago.Items.Add("Otros")
        Try
            Select Case CboFormaPago.SelectedItem
                Case "Efectivo" 'EFECTIVO
                    TDESC_OTROS.Visible = True
                    CboBanco.Visible = False
                    TSucursal.Visible = False
                    TCuenta.Visible = False
                    TClabe.Visible = False
                    LtObser.Text = "Observaciones"
                    LtBanco.Visible = False
                    LtSuc.Visible = False
                    LtCuenta.Visible = False
                    LtClabe.Visible = False
                Case "Cheque" 'CHEQUE
                    TDESC_OTROS.Visible = True
                    CboBanco.Visible = False
                    TSucursal.Visible = False
                    TCuenta.Visible = False
                    TClabe.Visible = False
                    LtObser.Text = "Beneficiario"
                    LtBanco.Visible = False
                    LtSuc.Visible = False
                    LtCuenta.Visible = False
                    LtClabe.Visible = False
                Case "Transferencia" 'TRANSFERENCIA
                    TDESC_OTROS.Visible = True
                    CboBanco.Visible = True
                    TSucursal.Visible = True
                    TCuenta.Visible = True
                    TClabe.Visible = True
                    LtObser.Text = "Observaciones"
                    LtBanco.Visible = True
                    LtSuc.Visible = True
                    LtCuenta.Visible = True
                    LtClabe.Visible = True
                Case "Tarjeta de crédito" 'TARJETA DE CREDITO
                    TDESC_OTROS.Visible = True
                    CboBanco.Visible = False
                    TSucursal.Visible = False
                    TCuenta.Visible = False
                    TClabe.Visible = False
                    LtObser.Text = "Observaciones"
                    LtBanco.Visible = False
                    LtSuc.Visible = False
                    LtCuenta.Visible = False
                    LtClabe.Visible = False
                Case "Otros" 'OTROS
                    TDESC_OTROS.Visible = True
                    CboBanco.Visible = False
                    TSucursal.Visible = False
                    TCuenta.Visible = False
                    TClabe.Visible = False
                    LtObser.Text = "Observaciones"
                    LtBanco.Visible = False
                    LtSuc.Visible = False
                    LtCuenta.Visible = False
                    LtClabe.Visible = False
            End Select
        Catch ex As Exception
            MsgBox("360. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChImprir_CheckedChanged(sender As Object, e As EventArgs) Handles ChImprir.CheckedChanged
        Try
            If ChImprir.Checked Then
                ChMail.Enabled = True
                TEMAILPRED.Enabled = True
                ChENVIOSILEN.Enabled = True
            Else
                ChMail.Enabled = False
                TEMAILPRED.Enabled = False
                ChENVIOSILEN.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEstadoCuenta_Click(sender As Object, e As EventArgs) Handles BarEstadoCuenta.Click
        Var4 = TCLAVE.Text
        Var5 = TNOMBRE.Text

        FrmEdoCuentaProv.ShowDialog()

    End Sub

    Private Sub TPais_KeyDown(sender As Object, e As KeyEventArgs) Handles TPais.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPais_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TPais_Validated(sender As Object, e As EventArgs) Handles TPais.Validated
        Try
            If TPais.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Pais", TPais.Text)
                If DESCR <> "N" And DESCR <> "" Then
                    LtPais.Text = DESCR
                Else
                    MsgBox("Pais  inexistente")
                    LtPais.Text = ""
                    TPais.Text = ""
                    TPais.SelectAll()
                    TPais.Select()
                End If
            Else
                LtPais.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ZONA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ZONA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnZona_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_ZONA_Validated(sender As Object, e As EventArgs) Handles TCVE_ZONA.Validated
        Try
            If TCVE_ZONA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Zona", TCVE_ZONA.Text)
                If DESCR <> "N" And DESCR <> "" Then
                    LtZona.Text = DESCR
                Else
                    MsgBox("Zona inexistente")
                    LtZona.Text = ""
                    TCVE_ZONA.Text = ""
                    TCVE_ZONA.SelectAll()
                    TCVE_ZONA.Select()
                End If
            Else
                LtPais.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgL_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgL.ValidateEdit
        Try
            If e.Row > 0 Then
                If e.Col = 3 Then
                    If FgL(e.Row, 4) = "N" Then
                        If Not IsNumeric(FgL.Editor.Text()) Then
                            e.Cancel = True
                            FgL.Editor.Text = "0"
                            MsgBox("Solo valores numéricos")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TDiasCred_TextChanged(sender As Object, e As EventArgs) Handles TDiasCred.TextChanged
        Try
            If Not IsNothing(TDiasCred.Value) Then
                TDiasCred.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TDESCUENTO_TextChanged(sender As Object, e As EventArgs) Handles TDESCUENTO.TextChanged
        Try
            If Not IsNothing(TDESCUENTO.Value) Then
                TDESCUENTO.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TNOMBRE_KeyDown(sender As Object, e As KeyEventArgs) Handles TNOMBRE.KeyDown
        If e.KeyCode = 13 Then
            GroupBox8.Select()
        End If
    End Sub

    Private Sub TNOMBRE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TNOMBRE.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox8.Select()
        End If
    End Sub

    Private Sub TTIP_OPERA_KeyDown(sender As Object, e As KeyEventArgs) Handles TTIP_OPERA.KeyDown
        If e.KeyCode = 13 Then
            GroupBox9.Select()
        End If
    End Sub

    Private Sub TTIP_OPERA_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TTIP_OPERA.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox9.Select()
        End If
    End Sub

    Private Sub TDESCUENTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TDESCUENTO.KeyDown
        If e.KeyCode = 13 Then
            GroupBox7.Select()
        End If
    End Sub

    Private Sub TDESCUENTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TDESCUENTO.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox7.Select()
        End If
    End Sub

    Private Sub TClabe_KeyDown(sender As Object, e As KeyEventArgs) Handles TClabe.KeyDown
        If e.KeyCode = 13 Then
            TVENTAS.Select()
        End If
    End Sub

    Private Sub TClabe_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TClabe.PreviewKeyDown
        If e.KeyCode = 9 Then
            TVENTAS.Select()
        End If
    End Sub

    Private Sub TULT_PAGOM_KeyDown(sender As Object, e As KeyEventArgs) Handles TULT_PAGOM.KeyDown
        If e.KeyCode = 13 Then
            GroupBox2.Select()
        End If
    End Sub

    Private Sub TULT_PAGOM_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TULT_PAGOM.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox2.Select()
        End If
    End Sub

    Private Sub TULT_COMPM_KeyDown(sender As Object, e As KeyEventArgs) Handles TULT_COMPM.KeyDown
        If e.KeyCode = 13 Then
            GroupBox12.Select()
        End If
    End Sub
    Private Sub TULT_COMPM_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TULT_COMPM.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox12.Select()
        End If
    End Sub

    Private Sub TVENTAS_KeyDown(sender As Object, e As KeyEventArgs) Handles TVENTAS.KeyDown
        If e.KeyCode = 13 Then
            GroupBox1.Select()
        End If
    End Sub

    Private Sub TVENTAS_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TVENTAS.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox1.Select()
        End If
    End Sub
End Class
