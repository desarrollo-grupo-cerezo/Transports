Imports System.Xml
Imports System.IO
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class frmClientesAE
    Private CLIENTE_SECUENCIAL As Int16 = 0
    Private SERIE_CLIENTE As String = ""

    Private CLIENTE As String
    Private ENTRA As Boolean
    Private RUTA_DOC As String
    Private RUTA_IMAGEN As String
    Private CLIE_NEW As Boolean = False
    Private EVENTO As String
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.SuspendLayout()
        DATOS0()
        DATOS1()
        Me.ResumeLayout()
    End Sub
    Private Sub FrmClientesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        BarraMenu.BackColor = Color.FromArgb(164, 177, 202)

        If Var4 = "XXX" Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.WindowState = FormWindowState.Normal
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.CenterToScreen()

            btnInicial.Visible = False
            btnAnterior.Visible = False
            btnSiguiente.Visible = False
            btnFinal.Visible = False
        End If

    End Sub
    Private Sub frmClientesAE_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim SPOR1 As Decimal

        SPOR1 = ((btnInicial.Height + btnInicial.Top) / Me.Height) * 100
        Split1.SizeRatio = SPOR1 + 1
        Split2.SizeRatio = 100 - Split1.SizeRatio - SPOR1

    End Sub
    Sub DATOS0()
        EVENTO = Var4
        Try
            'Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            'C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        BtnRFC.FlatStyle = FlatStyle.Flat
        BtnRFC.FlatAppearance.BorderSize = 0
        BtnRegimenFiscal.FlatStyle = FlatStyle.Flat
        BtnRegimenFiscal.FlatAppearance.BorderSize = 0
        BtnZonaEnvio.FlatStyle = FlatStyle.Flat
        BtnZonaEnvio.FlatAppearance.BorderSize = 0

        BtnMoneda.FlatStyle = FlatStyle.Flat
        BtnMoneda.FlatAppearance.BorderSize = 0
        BtnEsquema.FlatStyle = FlatStyle.Flat
        BtnEsquema.FlatAppearance.BorderSize = 0

        BtnVend.FlatStyle = FlatStyle.Flat
        BtnVend.FlatAppearance.BorderSize = 0
        BtnListaPrec.FlatStyle = FlatStyle.Flat
        BtnListaPrec.FlatAppearance.BorderSize = 0
        BtnUsoCFDI.FlatStyle = FlatStyle.Flat
        BtnUsoCFDI.FlatAppearance.BorderSize = 0
        BtnPagoSAT.FlatStyle = FlatStyle.Flat
        BtnPagoSAT.FlatAppearance.BorderSize = 0
        BtnPaisResiFiscal.FlatStyle = FlatStyle.Flat
        BtnPaisResiFiscal.FlatAppearance.BorderSize = 0
        BtnBancos.FlatStyle = FlatStyle.Flat
        BtnBancos.FlatAppearance.BorderSize = 0
        BtnPais.FlatStyle = FlatStyle.Flat
        BtnPais.FlatAppearance.BorderSize = 0
        BtnZona.FlatStyle = FlatStyle.Flat
        BtnZona.FlatAppearance.BorderSize = 0
        BtnMatriz.FlatStyle = FlatStyle.Flat
        BtnMatriz.FlatAppearance.BorderSize = 0

        BtnDocModelo.FlatStyle = FlatStyle.Flat
        BtnDocModelo.FlatAppearance.BorderSize = 0

        BtnCP.FlatStyle = FlatStyle.Flat
        BtnCP.FlatAppearance.BorderSize = 0

    End Sub
    Sub DATOS1()

        Try
            SplitM1.Dock = DockStyle.Fill
            SplitM1.SplitterWidth = 1
            TAB1.Dock = DockStyle.Fill


            C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
            C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
            ENTRA = True
            Me.KeyPreview = True

            ULT_PAGOF.Value = Date.Today
            ULT_PAGOF.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            ULT_PAGOF.CustomFormat = "dd/MM/yyyy"
            ULT_PAGOF.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            ULT_PAGOF.EditFormat.CustomFormat = "dd/MM/yyyy"

            FCH_ULTCOM.Value = Date.Today
            FCH_ULTCOM.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FCH_ULTCOM.CustomFormat = "dd/MM/yyyy"
            FCH_ULTCOM.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FCH_ULTCOM.EditFormat.CustomFormat = "dd/MM/yyyy"

            For k = 1 To Fg.Rows.Count - 1
                Fg(k, 1) = ""
                Fg(k, 2) = ""
                Fg(k, 3) = ""
            Next

            TNUM_MON.ErrorInfo.ShowErrorMessage = False
            TFLETE.ErrorInfo.ShowErrorMessage = False
            TCVE_ESQIMPU.ErrorInfo.ShowErrorMessage = False

            TDiasCred.ErrorInfo.ShowErrorMessage = False
            TLimCred.ErrorInfo.ShowErrorMessage = False
            TULT_PAGOM.ErrorInfo.ShowErrorMessage = False
            tDESCUENTO.ErrorInfo.ShowErrorMessage = False
            TULT_COMPM.ErrorInfo.ShowErrorMessage = False
            TVENTAS.ErrorInfo.ShowErrorMessage = False


            TDiasCred.Value = 0
            TLimCred.Value = 0
            TULT_PAGOM.Value = 0
            tDESCUENTO.Value = 0
            TULT_COMPM.Value = 0
            TVENTAS.Value = 0
            TNUM_MON.Value = 0
            TFLETE.Value = 0
            TCVE_ESQIMPU.Value = 0

            TCVE_OBS.Tag = ""

            ENTRA = False

            FgL.Cols.Count = 5
            FgL.Cols.Fixed = 1
            FgL.Cols(3).Width = 0
            FgL.Cols(4).Width = 0
            ENTRA = True


            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCPARAMCLIENTES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CLIENTE_SECUENCIAL = dr.ReadNullAsEmptyInteger("CLIENTE_SECUENCIAL")
                        SERIE_CLIENTE = dr.ReadNullAsEmptyString("SERIE_CLIENTE")
                    End If
                End Using
            End Using

            CONTROLES_MAXLENGHT()
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader

                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    RUTA_DOC = dr("RUTA_DOC").ToString
                    RUTA_IMAGEN = dr("RUTA_IMAGEN").ToString
                Else
                    RUTA_DOC = ""
                    RUTA_IMAGEN = ""
                End If
                dr.Close()

            Catch ex As Exception
            End Try

            TAB1.SelectedIndex = 0
            TREGIMEN_FISCAL.Tag = " "
            CLIE_NEW = False
            If Var1 = "Nuevo" Then

                CLIE_NEW = True
                BtnActivo.Enabled = False

                Try
                    INICIALIZAR_CONTROLES()

                    CARGAR_CAMPOS_LIBRES()

                    If CLIENTE_SECUENCIAL = 1 Then
                        TCLAVE.Text = GET_MAX("CLIE" & Empresa, "CLAVE", 10)
                        TCLAVE.Enabled = False
                    Else
                        TCLAVE.Select()
                    End If
                Catch ex As Exception
                    MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                CLIENTE = Var2
                DESPLEGAR_CLIENTE()

                DESPLEGAR_MERCANCIAS_CFG()

            End If
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_MERCANCIAS_CFG()
        Try
            SQL = "SELECT *
                FROM GCMERCANCIAS_CFG M 
                WHERE CLIENTE = '" & TCLAVE.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCOLA.Text = dr("COLA").ToString
                        TCOLB.Text = dr("COLB").ToString
                        TCOLC.Text = dr("COLC").ToString
                        TCOLD.Text = dr("COLD").ToString
                        TCOLE.Text = dr("COLE").ToString
                        TCOLF.Text = dr("COLF").ToString
                        TCOLN.Text = dr("COLN").ToString
                        TCOLG.Text = dr("COLG").ToString
                        TCOLH.Text = dr("COLH").ToString
                        TCOLI.Text = dr("COLI").ToString
                        TCOLJ.Text = dr("COLJ").ToString
                        TCOLK.Text = dr("COLK").ToString
                        TCOLL.Text = dr("COLL").ToString
                        TCOLM.Text = dr("COLM").ToString
                        TCOLO.Text = dr("COLO").ToString
                        TCOLP.Text = dr("COLP").ToString
                        TCOLQ.Text = dr("COLQ").ToString
                        TCOLR.Text = dr("COLR").ToString
                        TCOLS.Text = dr("COLS").ToString
                        TCOLT.Text = dr("COLT").ToString
                        TCOLU.Text = dr("COLU").ToString
                        TCOLV.Text = dr("COLV").ToString
                        TCOLW.Text = dr("COLW").ToString
                        TCOLX.Text = dr("COLX").ToString
                        TCOLY.Text = dr("COLY").ToString
                        TCOLZ.Text = dr("COLZ").ToString
                        TCOLAA.Text = dr("COLAA").ToString
                        TCOLAB.Text = dr("COLAB").ToString
                        TCOLAC.Text = dr("COLAC").ToString
                        TCOLAD.Text = dr("COLAD").ToString
                        TCOLAE.Text = dr("COLAE").ToString
                        TCOLAF.Text = dr("COLAF").ToString
                        TCOLAG.Text = dr("COLAG").ToString
                        TCOLAH.Text = dr("COLAH").ToString
                        TCOLAI.Text = dr("COLAI").ToString
                        TCOLAJ.Text = dr("COLAJ").ToString
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmClientesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        If EVENTO <> "XXX" Then
            CloseTab("Cliente")
        End If

        If ExisteTab("Clientes") Then
            frmClientes.DESPLEGAR()
        End If
    End Sub
    Private Sub FrmClientesAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                MnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmClientesAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Sub DESPLEGAR_CLIENTE()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim cmd2 As New SqlCommand
            Dim Exist As Boolean
            Exist = False

            cmd.Connection = cnSAE
            SQL = "SELECT I.CLAVE, I.STATUS, I.NOMBRE, I.RFC, I.CALLE, I.NUMINT, I.NUMEXT, I.CRUZAMIENTOS, I.CRUZAMIENTOS2, I.COLONIA, I.CODIGO,
                I.LOCALIDAD, I.MUNICIPIO, I.ESTADO, I.PAIS, I.NACIONALIDAD, I.REFERDIR, I.TELEFONO, I.CLASIFIC, I.FAX, I.PAG_WEB, I.CURP,
                I.CVE_ZONA, I.IMPRIR, I.MAIL, I.NIVELSEC, I.ENVIOSILEN, I.EMAILPRED, I.DIAREV, I.DIAPAGO, I.CON_CREDITO, I.DIASCRED, I.LIMCRED,
                I.SALDO, I.LISTA_PREC, I.CVE_BITA, I.ULT_PAGOD, I.ULT_PAGOM, I.ULT_PAGOF, I.DESCUENTO, I.ULT_VENTAD, I.ULT_COMPM, I.FCH_ULTCOM,
                I.VENTAS, I.CVE_VEND, I.CVE_OBS, I.TIPO_EMPRESA, I.MATRIZ, I.CALLE_ENVIO, I.NUMINT_ENVIO, I.NUMEXT_ENVIO,
                I.CRUZAMIENTOS_ENVIO, I.CRUZAMIENTOS_ENVIO2, I.COLONIA_ENVIO, I.LOCALIDAD_ENVIO, I.MUNICIPIO_ENVIO, I.ESTADO_ENVIO,
                I.PAIS_ENVIO, I.CODIGO_ENVIO, I.CVE_ZONA_ENVIO, I.REFERENCIA_ENVIO, I.CUENTA_CONTABLE, I.METODODEPAGO, I.NUMCTAPAGO, 
                I.MODELO, I.USO_CFDI, I.CVE_PAIS_SAT, I.NUMIDREGFISCAL, I.FORMADEPAGOSAT, ISNULL(OB.STR_OBS,'') AS OBSTR, I.REG_FISC,
                R.descripcion as DESC_REG_FISC, I.NOMBRECOMERCIAL, I.FLETE, I.TIPO_CAMBIO, CVE_ESQIMPU, I.NUM_MON,
                MUNICIPIO_SAT, LOCALIDAD_SAT, ESTADO_SAT, PAIS_SAT, COLONIA_SAT, ALIAS, APLICACION
                FROM CLIE" & Empresa & " I
                LEFT JOIN tblcregimenfiscal R ON R.regimenFiscal = I.REG_FISC
                LEFT JOIN OCLI" & Empresa & " OB ON OB.CVE_OBS = I.CVE_OBS                
                WHERE CLAVE = '" & CLIENTE & "' AND I.STATUS = 'A'"
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
                    TCRUZAMIENTOS2.Text = IIf(IsDBNull(dr("CRUZAMIENTOS2")), "", dr("CRUZAMIENTOS2"))
                    TCOLONIA.Text = IIf(IsDBNull(dr("COLONIA")), "", dr("COLONIA"))

                    TNOMBRECOMERCIAL.Text = dr.ReadNullAsEmptyString("NOMBRECOMERCIAL")

                    TFLETE.Value = dr.ReadNullAsEmptyDecimal("FLETE")

                    TCVE_ESQIMPU.Value = dr.ReadNullAsEmptyInteger("CVE_ESQIMPU")
                    LtEsquema.Text = BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text)


                    TNUM_MON.Value = dr.ReadNullAsEmptyDecimal("NUM_MON")
                    If TNUM_MON.Value > 0 Then
                        LtMoneda.Text = BUSCA_CAT("Moneda", TNUM_MON.Value)
                        LtMX.Text = Var6
                    End If

                    TMUNICIPIO_SAT.Text = dr.ReadNullAsEmptyString("MUNICIPIO_SAT")
                    TLOCALIDAD_SAT.Text = dr.ReadNullAsEmptyString("LOCALIDAD_SAT")
                    TESTADO_SAT.Text = dr.ReadNullAsEmptyString("ESTADO_SAT")
                    TPAIS_SAT.Text = dr.ReadNullAsEmptyString("PAIS_SAT")
                    TCOLONIA_SAT.Text = dr.ReadNullAsEmptyString("COLONIA_SAT")
                    TALIAS.Text = dr.ReadNullAsEmptyString("ALIAS")

                    TAPLICACION.Text = dr.ReadNullAsEmptyString("APLICACION")
                Catch ex As Exception
                    MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    TCODIGO.Text = IIf(IsDBNull(dr("CODIGO")), "", dr("CODIGO"))
                    TLOCALIDAD.Text = IIf(IsDBNull(dr("LOCALIDAD")), "", dr("LOCALIDAD"))
                    TMunicipio.Text = IIf(IsDBNull(dr("MUNICIPIO")), "", dr("MUNICIPIO"))
                    TEstado.Text = IIf(IsDBNull(dr("ESTADO")), "", dr("ESTADO"))
                    TPais.Text = IIf(IsDBNull(dr("PAIS")), "", dr("PAIS"))
                    LtPais.Text = BUSCA_CAT("Pais", TPais.Text)

                    TNacionalidad.Text = IIf(IsDBNull(dr("NACIONALIDAD")), "", dr("NACIONALIDAD"))
                    TREFERDIR.Text = IIf(IsDBNull(dr("REFERDIR")), "", dr("REFERDIR"))
                Catch ex As Exception
                    MsgBox("11. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("11. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    TTELEFONO.Text = IIf(IsDBNull(dr("TELEFONO")), "", dr("TELEFONO"))
                    TClasific.Text = IIf(IsDBNull(dr("CLASIFIC")), "", dr("CLASIFIC"))
                    TFax.Text = IIf(IsDBNull(dr("FAX")), "", dr("FAX"))
                    TPAG_WEB.Text = IIf(IsDBNull(dr("PAG_WEB")), "", dr("PAG_WEB"))
                    TCURP.Text = IIf(IsDBNull(dr("CURP")), "", dr("CURP"))
                    TCVE_ZONA.Text = IIf(IsDBNull(dr("CVE_ZONA")), "", dr("CVE_ZONA"))
                Catch ex As Exception
                    MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    If Not IsDBNull(dr("IMPRIR")) Then
                        If dr("IMPRIR") = "S" Then
                            chImprir.Checked = True
                        Else
                            chImprir.Checked = False
                        End If
                    Else
                        chImprir.Checked = False
                    End If
                Catch ex As Exception
                    MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    If IsDBNull(dr("MAIL")) Then
                        chMail.Checked = False
                    Else
                        If dr("MAIL") = "S" Then
                            chMail.Checked = True
                        Else
                            chMail.Checked = False
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    'If IsDBNull(dr("NIVELSEC")) Then
                    'OpNIVELSEC.Checked = False
                    'OpNIVELSEC2.Checked = False
                    'Else
                    'If dr("NIVELSEC") = 0 Then
                    'OpNIVELSEC.Checked = True
                    'OpNIVELSEC2.Checked = False
                    'Else
                    'OpNIVELSEC.Checked = False
                    'OpNIVELSEC2.Checked = True
                    'End If
                    'End If
                Catch ex As Exception
                    MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    'If dr.ReadNullAsEmptyString("ENVIOSILEN") = "S" Then
                    'ChENVIOSILEN.Checked = True
                    'Else
                    'ChENVIOSILEN.Checked = False
                    'End If
                    TEMAILPRED.Text = IIf(IsDBNull(dr("EMAILPRED")), "", dr("EMAILPRED"))
                    TDIAREV.Text = IIf(IsDBNull(dr("DIAREV")), "", dr("DIAREV"))
                    TDIAPAGO.Text = IIf(IsDBNull(dr("DIAPAGO")), "", dr("DIAPAGO"))
                    If dr.ReadNullAsEmptyString("CON_CREDITO") = "S" Then
                        chCON_CREDITO.Checked = True
                    Else
                        chCON_CREDITO.Checked = False
                    End If
                Catch ex As Exception
                    MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    TDiasCred.Value = dr.ReadNullAsEmptyInteger("DIASCRED")
                    TLimCred.Value = dr.ReadNullAsEmptyDecimal("LIMCRED")
                    LtSaldo.Text = dr.ReadNullAsEmptyDecimal("SALDO")

                    TLISTA_PREC.Text = IIf(IsDBNull(dr("LISTA_PREC")), "0", dr("LISTA_PREC"))
                    TULT_PAGOD.Text = IIf(IsDBNull(dr("ULT_PAGOD")), "", dr("ULT_PAGOD"))
                    TULT_PAGOM.Value = IIf(IsDBNull(dr("ULT_PAGOM")), "0", dr("ULT_PAGOM"))
                    If IsDate(dr("ULT_PAGOF")) Then
                        ULT_PAGOF.Value = dr("ULT_PAGOF")
                    Else
                        ULT_PAGOF.Value = Now
                    End If
                Catch ex As Exception
                    MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    tDESCUENTO.Value = IIf(IsDBNull(dr("DESCUENTO")), "0", dr("DESCUENTO"))
                    TULT_VENTAD.Text = IIf(IsDBNull(dr("ULT_VENTAD")), "", dr("ULT_VENTAD"))

                    TULT_COMPM.Value = IIf(IsDBNull(dr("ULT_COMPM")), "0", dr("ULT_COMPM"))
                    If IsDate(dr("FCH_ULTCOM")) Then
                        FCH_ULTCOM.Value = dr("FCH_ULTCOM")
                    End If
                    TVENTAS.Value = IIf(IsDBNull(dr("VENTAS")), "0", dr("VENTAS"))
                    TCVE_VEND.Text = IIf(IsDBNull(dr("CVE_VEND")), "", dr("CVE_VEND"))
                Catch ex As Exception
                    MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("18. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    TCVE_OBS.Text = dr.ReadNullAsEmptyString("OBSTR")
                    TCVE_OBS.Tag = dr.ReadNullAsEmptyString("CVE_OBS")

                    If dr.ReadNullAsEmptyString("TIPO_EMPRESA") = "M" Then
                        radMatriz.Checked = True
                        radSuc.Checked = False

                        TMATRIZ.Visible = False
                        LtMatriz.Visible = False
                        LMatriz.Visible = False
                        BtnMatriz.Visible = False
                    End If
                    If dr.ReadNullAsEmptyString("TIPO_EMPRESA") = "S" Then
                        radMatriz.Checked = False
                        radSuc.Checked = True

                        TMATRIZ.Visible = True
                        LtMatriz.Visible = True
                        LMatriz.Visible = True
                        BtnMatriz.Visible = True

                        TMATRIZ.Text = IIf(IsDBNull(dr("MATRIZ")), "", dr("MATRIZ"))
                    End If
                Catch ex As Exception
                    MsgBox("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    TCALLE_ENVIO.Text = IIf(IsDBNull(dr("CALLE_ENVIO")), "", dr("CALLE_ENVIO"))
                    TNUMINT_ENVIO.Text = IIf(IsDBNull(dr("NUMINT_ENVIO")), "", dr("NUMINT_ENVIO"))
                    TNUMEXT_ENVIO.Text = IIf(IsDBNull(dr("NUMEXT_ENVIO")), "", dr("NUMEXT_ENVIO"))
                    TCRUZAMIENTOS_ENVIO.Text = IIf(IsDBNull(dr("CRUZAMIENTOS_ENVIO")), "", dr("CRUZAMIENTOS_ENVIO"))

                    TCRUZAMIENTOS_ENVIO2.Text = IIf(IsDBNull(dr("CRUZAMIENTOS_ENVIO2")), "", dr("CRUZAMIENTOS_ENVIO2"))
                    TCOLONIA_ENVIO.Text = IIf(IsDBNull(dr("COLONIA_ENVIO")), "", dr("COLONIA_ENVIO"))
                    TLOCALIDAD_ENVIO.Text = IIf(IsDBNull(dr("LOCALIDAD_ENVIO")), "", dr("LOCALIDAD_ENVIO"))
                    TMUNICIPIO_ENVIO.Text = IIf(IsDBNull(dr("MUNICIPIO_ENVIO")), "", dr("MUNICIPIO_ENVIO"))
                    TESTADO_ENVIO.Text = IIf(IsDBNull(dr("ESTADO_ENVIO")), "", dr("ESTADO_ENVIO"))
                    TPAIS_ENVIO.Text = IIf(IsDBNull(dr("PAIS_ENVIO")), "", dr("PAIS_ENVIO"))
                    TCODIGO_ENVIO.Text = IIf(IsDBNull(dr("CODIGO_ENVIO")), "", dr("CODIGO_ENVIO"))
                    TCVE_ZONA_ENVIO.Text = IIf(IsDBNull(dr("CVE_ZONA_ENVIO")), "", dr("CVE_ZONA_ENVIO"))
                    TREFERENCIA_ENVIO.Text = IIf(IsDBNull(dr("REFERENCIA_ENVIO")), "", dr("REFERENCIA_ENVIO"))
                    TCUENTA_CONTABLE.Text = IIf(IsDBNull(dr("CUENTA_CONTABLE")), "", dr("CUENTA_CONTABLE"))
                    TMETODODEPAGO.Text = IIf(IsDBNull(dr("METODODEPAGO")), "", dr("METODODEPAGO"))
                    TNUMCTAPAGO.Text = IIf(IsDBNull(dr("NUMCTAPAGO")), "", dr("NUMCTAPAGO"))
                    TMODELO.Text = IIf(IsDBNull(dr("MODELO")), "", dr("MODELO"))
                    TUSO_CFDI.Text = IIf(IsDBNull(dr("USO_CFDI")), "", dr("USO_CFDI"))
                    LtUsoCFDI.Text = BUSCA_CAT("USO CFDI", TUSO_CFDI.Text)

                    TCVE_PAIS_SAT.Text = IIf(IsDBNull(dr("CVE_PAIS_SAT")), "", dr("CVE_PAIS_SAT"))
                    TNUMIDREGFISCAL.Text = IIf(IsDBNull(dr("NUMIDREGFISCAL")), "", dr("NUMIDREGFISCAL"))
                    TFORMADEPAGOSAT.Text = IIf(IsDBNull(dr("FORMADEPAGOSAT")), "", dr("FORMADEPAGOSAT"))
                    Label70.Text = BUSCA_CAT("tblcformapago", TFORMADEPAGOSAT.Text)

                    TREGIMEN_FISCAL.Text = dr.ReadNullAsEmptyString("REG_FISC")
                    LtRegFis.Text = OBTENER_REGIMEN_FISCAL_XML(TREGIMEN_FISCAL.Text)
                    TREGIMEN_FISCAL.Tag = TREGIMEN_FISCAL.Text
                    If dr.ReadNullAsEmptyString("STATUS") = "A" Then
                        BtnActivo.Text = "Activo"
                    End If
                Catch ex As Exception
                    MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                INICIALIZAR_CONTROLES()
            End If
            dr.Close()

            Try
                If Exist Then
                    Try
                        SQL = "SELECT CUENTA_BANCARIA, RFC_BANCO, NOMBRE_BANCO FROM CUENTA_ORD" & Empresa & " WHERE CLAVE = '" & TCLAVE.Text & "'"
                        cmd.CommandText = SQL
                        dr = cmd.ExecuteReader
                        Fg.Rows.Count = 1
                        Do While dr.Read
                            Fg.AddItem("" & vbTab & dr("CUENTA_BANCARIA") & vbTab & dr("NOMBRE_BANCO") & vbTab & dr("RFC_BANCO"))
                        Loop
                        dr.Close()
                    Catch Ex As Exception
                        Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                    'CAMPOS LIBRES
                    CARGAR_CAMPOS_LIBRES()
                    ADICIONALES()
                End If
            Catch Ex As Exception
                Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
                MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            End Try

            TCLAVE.Enabled = False
            TNOMBRE.Select()
        Catch ex As Exception
            MsgBox("21. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("21. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ADICIONALES()
        Dim cmd2 As New SqlCommand
        Dim dr2 As SqlDataReader
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim CAMPO As String, DATA_TYPE As String

        cmd.Connection = cnSAE
        cmd2.Connection = cnSAE

        Try
            SQL = "SELECT LEYENDA, NOMBRE, LONGITUD FROM CLIE_ADIC_C ORDER BY ORDEN"

            ENTRA = False
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            FgA.Rows.Count = 1
            FgA.Cols.Count = 6
            FgA.Cols(3).Visible = False
            FgA.Cols(4).Visible = False
            FgA.Cols(5).Visible = False

            Do While dr.Read
                '                                               DATOS                CAMPO           TIPO DATOS  
                FgA.AddItem("" & vbTab & dr("LEYENDA") & vbTab & " " & vbTab & dr("NOMBRE") & vbTab & " " & vbTab & dr("LONGITUD"))

                SQL = "SELECT * FROM CLIE_ADIC WHERE CLIENTE = '" & TCLAVE.Text & "'"
                cmd2.CommandText = SQL
                dr2 = cmd2.ExecuteReader
                If dr2.Read Then
                    CAMPO = dr("NOMBRE").ToString
                    FgA(FgA.Rows.Count - 1, 2) = dr2(CAMPO)
                End If
                dr2.Close()
            Loop
            dr.Close()
            ENTRA = True
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try

        Try
            Dim cs1 As C1.Win.C1FlexGrid.CellStyle
            Dim rg1 As New C1.Win.C1FlexGrid.CellRange()
            Dim c1numeric As New C1.Win.C1Input.C1NumericEdit
            For k As Integer = 1 To FgA.Rows.Count - 1

                DATA_TYPE = GET_DATATYPE("CLIE_ADIC", FgA(k, 3))
                FgA(k, 4) = DATA_TYPE

                Select Case DATA_TYPE
                    Case "varchar", "char"
                        Dim st As CellStyle = FgA.Styles.Add("MyStyle")
                        st.DataType = GetType(String)
                        Dim rg As CellRange = FgA.GetCellRange(k, 2, 1, 2)
                        rg.Style = st
                    Case "int"
                        cs1 = FgA.Styles.Add("DataType1")
                        cs1.DataType = GetType(Int32)
                        cs1.TextAlign = TextAlignEnum.RightCenter
                        cs1.Editor = c1numeric

                        rg1 = FgA.GetCellRange(k, 2)
                        rg1.Style = cs1
                    Case "smallint"
                        cs1 = FgA.Styles.Add("DataType1")
                        cs1.DataType = GetType(Int16)
                        cs1.Editor = c1numeric
                        rg1 = FgA.GetCellRange(k, 2)
                        rg1.Style = cs1
                    Case "float"
                        cs1 = FgA.Styles.Add("DataType1")
                        cs1.DataType = GetType(Single)
                        cs1.Editor = c1numeric
                        rg1 = FgA.GetCellRange(k, 2)
                        rg1.Style = cs1
                    Case "date", "datetime"
                        cs1 = FgA.Styles.Add("DataType1")
                        cs1.DataType = GetType(DateTime)
                        rg1 = FgA.GetCellRange(k, 2)
                        rg1.Style = cs1
                End Select
            Next
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_CAMPOS_LIBRES()
        Dim cmd2 As New SqlCommand
        Dim dr2 As SqlDataReader
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim CAMPO As String, DATA_TYPE As String

        cmd.Connection = cnSAE
        cmd2.Connection = cnSAE

        Try
            SQL = "SELECT NUM_EMP, IDTABLA, CAMPO, ETIQUETA FROM dbo.PARAM_CAMPOSLIBRES" & Empresa & " WHERE IDTABLA = 'CLIE_CLIB'"

            ENTRA = False
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            FgL.Rows.Count = 1
            Do While dr.Read

                FgL.AddItem("" & vbTab & dr("ETIQUETA").ToString & vbTab & " " & vbTab & dr("CAMPO").ToString & vbTab & " ")

                SQL = "SELECT * FROM CLIE_CLIB" & Empresa & " WHERE CVE_CLIE = '" & TCLAVE.Text & "'"
                cmd2.CommandText = SQL
                dr2 = cmd2.ExecuteReader
                If dr2.Read Then
                    CAMPO = dr("CAMPO")
                    FgL(FgL.Rows.Count - 1, 2) = dr2.ReadNullAsEmptyString(CAMPO)
                End If
                dr2.Close()
            Loop
            dr.Close()
            ENTRA = True
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try

        Try
            Dim cs1 As C1.Win.C1FlexGrid.CellStyle
            Dim rg1 As New C1.Win.C1FlexGrid.CellRange()
            Dim c1numeric As New C1.Win.C1Input.C1NumericEdit

            For k As Integer = 1 To FgL.Rows.Count - 1
                DATA_TYPE = GET_DATATYPE("CLIE_CLIB" & Empresa, FgL(k, 3))
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
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub CONTROLES_MAXLENGHT()

        TCLAVE.MaxLength = 10
        TNOMBRE.MaxLength = 120
        TRFC.MaxLength = 15
        TCALLE.MaxLength = 255
        TNumInt.MaxLength = 15
        TNumExt.MaxLength = 15
        TCRUZAMIENTOS.MaxLength = 255
        TCRUZAMIENTOS2.MaxLength = 255
        TCOLONIA.MaxLength = 50
        TCODIGO.MaxLength = 5
        TLOCALIDAD.MaxLength = 50
        TMunicipio.MaxLength = 50
        TEstado.MaxLength = 50
        TPais.MaxLength = 50
        TNacionalidad.MaxLength = 40
        TREFERDIR.MaxLength = 255
        TTELEFONO.MaxLength = 25
        TClasific.MaxLength = 5
        TFax.MaxLength = 25
        TPAG_WEB.MaxLength = 60
        TCURP.MaxLength = 18
        TCVE_ZONA.MaxLength = 6
        TEMAILPRED.MaxLength = 60
        TDIAREV.MaxLength = 2
        TDIAPAGO.MaxLength = 2
        TULT_PAGOD.MaxLength = 20
        TULT_VENTAD.MaxLength = 20
        TCVE_VEND.MaxLength = 5
        TMATRIZ.MaxLength = 10
        TCALLE_ENVIO.MaxLength = 80
        TNUMINT_ENVIO.MaxLength = 15
        TNUMEXT_ENVIO.MaxLength = 15
        TCRUZAMIENTOS_ENVIO.MaxLength = 40
        TCRUZAMIENTOS_ENVIO2.MaxLength = 40
        TCOLONIA_ENVIO.MaxLength = 50
        TLOCALIDAD_ENVIO.MaxLength = 50
        TMUNICIPIO_ENVIO.MaxLength = 50
        TESTADO_ENVIO.MaxLength = 50
        TPAIS_ENVIO.MaxLength = 50
        TCODIGO_ENVIO.MaxLength = 5
        TCVE_ZONA_ENVIO.MaxLength = 6
        TREFERENCIA_ENVIO.MaxLength = 255
        TCUENTA_CONTABLE.MaxLength = 28
        TMETODODEPAGO.MaxLength = 255
        TNUMCTAPAGO.MaxLength = 255
        TMODELO.MaxLength = 255
        TUSO_CFDI.MaxLength = 5
        TCVE_PAIS_SAT.MaxLength = 5
        TNUMIDREGFISCAL.MaxLength = 128
        TFORMADEPAGOSAT.MaxLength = 5

    End Sub
    Sub INICIALIZAR_CONTROLES()
        Try
            TCLAVE.Text = ""
            TNOMBRE.Text = ""
            TRFC.Text = ""
            TCALLE.Text = ""
            TNumInt.Text = ""
            TNumExt.Text = ""
            TCRUZAMIENTOS_ENVIO.Text = ""
            TCRUZAMIENTOS_ENVIO2.Text = ""
            TCOLONIA.Text = ""
            TCODIGO.Text = ""
            TLOCALIDAD.Text = ""
            TMunicipio.Text = ""
            TEstado.Text = ""
            TPais.Text = ""
            TNacionalidad.Text = ""
            TREFERENCIA_ENVIO.Text = ""
            TTELEFONO.Text = ""
            TClasific.Text = ""
            TFax.Text = ""
            TPAG_WEB.Text = ""
            TCURP.Text = ""
            TCVE_ZONA.Text = ""
            chImprir.Checked = False
            TEMAILPRED.Text = ""

            'OpNIVELSEC.Checked = False
            'OpNIVELSEC2.Checked = False
            'ChENVIOSILEN.Checked = False

            TEMAILPRED.Text = ""
            TDIAREV.Text = ""
            TDIAPAGO.Text = ""
            chCON_CREDITO.Checked = False
            TDiasCred.Value = 0
            TLimCred.Value = 0
            LtSaldo.Text = ""
            TLISTA_PREC.Text = ""
            TULT_PAGOD.Text = ""
            TULT_VENTAD.Text = ""
            ULT_PAGOF.Value = Now
            tDESCUENTO.Value = 0
            TULT_PAGOM.Value = 0
            TULT_COMPM.Value = 0
            TVENTAS.Value = 0
            TCVE_VEND.Text = ""
            TCVE_OBS.Text = ""
            TCVE_OBS.Tag = "0"
            radMatriz.Checked = False
            radSuc.Checked = False

            TMATRIZ.Visible = False
            LtMatriz.Visible = False
            LMatriz.Visible = False
            BtnMatriz.Visible = False

            TMATRIZ.Text = ""
            TCALLE_ENVIO.Text = ""
            TNUMINT_ENVIO.Text = ""
            TNUMEXT_ENVIO.Text = ""
            TCRUZAMIENTOS_ENVIO.Text = ""
            TCRUZAMIENTOS_ENVIO2.Text = ""
            TCOLONIA_ENVIO.Text = ""
            TLOCALIDAD_ENVIO.Text = ""
            TMUNICIPIO_ENVIO.Text = ""
            TESTADO_ENVIO.Text = ""
            TPAIS_ENVIO.Text = ""
            TCODIGO_ENVIO.Text = ""
            TCVE_ZONA_ENVIO.Text = ""
            TREFERENCIA_ENVIO.Text = ""
            TCUENTA_CONTABLE.Text = ""
            TMETODODEPAGO.Text = ""
            TNUMCTAPAGO.Text = ""
            TMODELO.Text = ""
            TUSO_CFDI.Text = ""
            TCVE_PAIS_SAT.Text = ""
            TNUMIDREGFISCAL.Text = ""
            TFORMADEPAGOSAT.Text = ""

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnGrabarYSalir_Click(sender As Object, e As EventArgs) Handles BtnGrabarYSalir.Click
        GRABAR("GRABAR Y SALIR")
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        GRABAR("GRABAR")
    End Sub
    Sub GRABAR(FGRABAR As String)
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim cmd As New SqlCommand
        Dim CVE_BITA As Long
        Dim CVE_OBS As Long

        Dim DIASCRED As Integer
        Dim LIMCRED As Single
        Dim ULT_PAGOM As Single
        Dim DESCUENTO As Single
        Dim ULT_COMPM As Single
        Dim VENTAS As Single
        Dim TIPO_EMPRESA As String

        TIPO_EMPRESA = ""

        If TCLAVE.Text.Trim.Length = 0 Then
            MsgBox("La clave del cliente no puede quedar vacia, verifique por favor")
            Return
        End If

        If TCLAVE.Text.Trim = "0" Then
            MsgBox("La clave del cliente no puede ser cero, verifique por favor")
            Return
        End If

        If BtnActivo.Text = "Baja" Then
            If MsgBox("Realmente desea dar de baja al cliente?", vbYesNo) = vbNo Then
                BtnActivo.Text = "Activo"
                Return
            End If
        End If

        If CLIE_NEW And TRFC.Text <> "XAXX010101000" And TRFC.Text.Trim.Length > 0 Then
            If RFC_CLIENTE_EXISTE(TRFC.Text) Then
                If MsgBox("El RFC actualmente se encuentra asignado al cliente " & vbNewLine & Var10 & vbNewLine & "Desea continuar?", vbYesNo) = vbNo Then
                    Return
                End If
            End If
        End If

        If TNOMBRE.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre del cliente")
            Return
        End If
        TPAG_WEB.Focus()

        Try
            DIASCRED = TDiasCred.Value
            LIMCRED = TLimCred.Value
            ULT_PAGOM = TULT_PAGOM.Value
            DESCUENTO = tDESCUENTO.Value
            ULT_COMPM = TULT_COMPM.Value
            VENTAS = TVENTAS.Value

            TIPO_EMPRESA = "M"
            If radSuc.Checked Then TIPO_EMPRESA = "S"
            TNUM_MON.UpdateValueWithCurrentText()
            TFLETE.UpdateValueWithCurrentText()
            TDiasCred.UpdateValueWithCurrentText()
            TLimCred.UpdateValueWithCurrentText()
            TULT_PAGOM.UpdateValueWithCurrentText()
            tDESCUENTO.UpdateValueWithCurrentText()
            TULT_COMPM.UpdateValueWithCurrentText()
            TVENTAS.UpdateValueWithCurrentText()
        Catch ex As Exception
            MsgBox("22.1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("22.1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If IsNumeric(TCVE_OBS.Tag) Then
                CVE_OBS = TCVE_OBS.Tag
            Else
                CVE_OBS = 0
            End If

            CVE_OBS = INSERT_UPDATE_OCLI(CVE_OBS, TCVE_OBS.Text)

        Catch ex As Exception
            MsgBox("22. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("22. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        SQL = "IF EXISTS (SELECT CLAVE FROM CLIE" & Empresa & " WHERE CLAVE = @CLAVE) 
            UPDATE CLIE" & Empresa & " Set CLAVE = @CLAVE, NOMBRE = @NOMBRE, RFC = @RFC, CALLE = @CALLE, NUMINT = @NUMINT, NUMEXT = @NUMEXT, 
            CRUZAMIENTOS = @CRUZAMIENTOS, CRUZAMIENTOS2 = @CRUZAMIENTOS2, COLONIA = @COLONIA, CODIGO = @CODIGO, LOCALIDAD = @LOCALIDAD, 
            MUNICIPIO = @MUNICIPIO, ESTADO = @ESTADO, PAIS = @PAIS, NACIONALIDAD = @NACIONALIDAD, REFERDIR = @REFERDIR, TELEFONO = @TELEFONO, 
            CLASIFIC = @CLASIFIC, FAX = @FAX, PAG_WEB = @PAG_WEB, CURP = @CURP, CVE_ZONA = @CVE_ZONA, IMPRIR = @IMPRIR, MAIL = @MAIL, 
            ENVIOSILEN = @ENVIOSILEN, EMAILPRED = @EMAILPRED, DIAREV = @DIAREV, DIAPAGO = @DIAPAGO, CON_CREDITO = @CON_CREDITO, 
            DIASCRED = @DIASCRED, LIMCRED = @LIMCRED, LISTA_PREC = @LISTA_PREC, CVE_BITA = @CVE_BITA, ULT_PAGOD = @ULT_PAGOD, 
            ULT_PAGOM = @ULT_PAGOM, ULT_PAGOF = @ULT_PAGOF, DESCUENTO = @DESCUENTO, ULT_VENTAD = @ULT_VENTAD, ULT_COMPM = @ULT_COMPM, 
            FCH_ULTCOM = @FCH_ULTCOM, VENTAS = @VENTAS, CVE_VEND = @CVE_VEND, CVE_OBS = @CVE_OBS, TIPO_EMPRESA = @TIPO_EMPRESA, MATRIZ = @MATRIZ, 
            CALLE_ENVIO = @CALLE_ENVIO, NUMINT_ENVIO = @NUMINT_ENVIO, NUMEXT_ENVIO = @NUMEXT_ENVIO, CRUZAMIENTOS_ENVIO = @CRUZAMIENTOS_ENVIO, 
            CRUZAMIENTOS_ENVIO2 = @CRUZAMIENTOS_ENVIO2, COLONIA_ENVIO = @COLONIA_ENVIO, LOCALIDAD_ENVIO = @LOCALIDAD_ENVIO, 
            MUNICIPIO_ENVIO = @MUNICIPIO_ENVIO, ESTADO_ENVIO = @ESTADO_ENVIO, PAIS_ENVIO = @PAIS_ENVIO, CODIGO_ENVIO = @CODIGO_ENVIO, 
            CVE_ZONA_ENVIO = @CVE_ZONA_ENVIO, REFERENCIA_ENVIO = @REFERENCIA_ENVIO, CUENTA_CONTABLE = @CUENTA_CONTABLE, 
            METODODEPAGO = @METODODEPAGO, NUMCTAPAGO = @NUMCTAPAGO, MODELO = @MODELO, USO_CFDI = @USO_CFDI, CVE_PAIS_SAT = @CVE_PAIS_SAT, 
            NUMIDREGFISCAL = @NUMIDREGFISCAL, FORMADEPAGOSAT = @FORMADEPAGOSAT, STATUS = @STATUS, REG_FISC = @REG_FISC, 
            NOMBRECOMERCIAL = @NOMBRECOMERCIAL, FLETE = @FLETE, NUM_MON = @NUM_MON, CVE_ESQIMPU = @CVE_ESQIMPU, MUNICIPIO_SAT = @MUNICIPIO_SAT, 
            LOCALIDAD_SAT = @LOCALIDAD_SAT, ESTADO_SAT = @ESTADO_SAT, PAIS_SAT = @PAIS_SAT, COLONIA_SAT = @COLONIA_SAT,
            ALIAS = @ALIAS, APLICACION = @APLICACION
            WHERE CLAVE = @CLAVE
            ELSE
            INSERT INTO CLIE" & Empresa & " (CLAVE, STATUS, NOMBRE, RFC, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO,
            LOCALIDAD, MUNICIPIO, ESTADO, PAIS, NACIONALIDAD, REFERDIR, TELEFONO, CLASIFIC, FAX, PAG_WEB, CURP, CVE_ZONA, IMPRIR, MAIL,
            ENVIOSILEN, EMAILPRED, DIAREV, DIAPAGO, CON_CREDITO, DIASCRED, LIMCRED, LISTA_PREC, CVE_BITA, ULT_PAGOD,ULT_PAGOM, 
            ULT_PAGOF, DESCUENTO, ULT_VENTAD, ULT_COMPM, FCH_ULTCOM, VENTAS, CVE_VEND, CVE_OBS, TIPO_EMPRESA, MATRIZ, CALLE_ENVIO, 
            NUMINT_ENVIO, NUMEXT_ENVIO, CRUZAMIENTOS_ENVIO, CRUZAMIENTOS_ENVIO2, COLONIA_ENVIO, LOCALIDAD_ENVIO, MUNICIPIO_ENVIO, 
            ESTADO_ENVIO, PAIS_ENVIO, CODIGO_ENVIO, CVE_ZONA_ENVIO, REFERENCIA_ENVIO, CUENTA_CONTABLE, METODODEPAGO, NUMCTAPAGO, MODELO, 
            USO_CFDI, CVE_PAIS_SAT, NUMIDREGFISCAL, FORMADEPAGOSAT, REG_FISC, NOMBRECOMERCIAL, FLETE, NUM_MON, CVE_ESQIMPU, MUNICIPIO_SAT,
            LOCALIDAD_SAT, ESTADO_SAT, PAIS_SAT, COLONIA_SAT, ALIAS, APLICACION) 
            VALUES(
            @CLAVE, 'A', @NOMBRE, @RFC, @CALLE, @NUMINT, @NUMEXT, @CRUZAMIENTOS, @CRUZAMIENTOS2, @COLONIA, @CODIGO, @LOCALIDAD,
            @MUNICIPIO, @ESTADO, @PAIS, @NACIONALIDAD, @REFERDIR, @TELEFONO, @CLASIFIC, @FAX, @PAG_WEB, @CURP, @CVE_ZONA, @IMPRIR, @MAIL,
            @ENVIOSILEN, @EMAILPRED, @DIAREV, @DIAPAGO, @CON_CREDITO, @DIASCRED, @LIMCRED, @LISTA_PREC, @CVE_BITA, @ULT_PAGOD, 
            @ULT_PAGOM, @ULT_PAGOF, @DESCUENTO, @ULT_VENTAD, @ULT_COMPM, @FCH_ULTCOM, @VENTAS, @CVE_VEND, @CVE_OBS, @TIPO_EMPRESA,
            @MATRIZ, @CALLE_ENVIO, @NUMINT_ENVIO, @NUMEXT_ENVIO, @CRUZAMIENTOS_ENVIO, @CRUZAMIENTOS_ENVIO2, @COLONIA_ENVIO, @LOCALIDAD_ENVIO,
            @MUNICIPIO_ENVIO, @ESTADO_ENVIO, @PAIS_ENVIO, @CODIGO_ENVIO, @CVE_ZONA_ENVIO, @REFERENCIA_ENVIO, @CUENTA_CONTABLE, @METODODEPAGO,
            @NUMCTAPAGO, @MODELO, @USO_CFDI, @CVE_PAIS_SAT, @NUMIDREGFISCAL, @FORMADEPAGOSAT, @REG_FISC, @NOMBRECOMERCIAL, @FLETE, 
            @NUM_MON, @CVE_ESQIMPU, @MUNICIPIO_SAT, @LOCALIDAD_SAT, @ESTADO_SAT, @PAIS_SAT, @COLONIA_SAT, @ALIAS, @APLICACION)"

        cmd.Connection = cnSAE
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = RemoveCharacter(TCLAVE.Text)
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = RemoveCharacter(TNOMBRE.Text.Trim)
            cmd.Parameters.Add("@NOMBRECOMERCIAL", SqlDbType.VarChar).Value = RemoveCharacter(TNOMBRECOMERCIAL.Text.Trim)
            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = RemoveCharacter(TRFC.Text.Trim)
            cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TCALLE.Text.Trim
            cmd.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = TNumInt.Text.Trim
            cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = TNumExt.Text.Trim
            cmd.Parameters.Add("@CRUZAMIENTOS", SqlDbType.VarChar).Value = TCRUZAMIENTOS.Text.Trim
            cmd.Parameters.Add("@CRUZAMIENTOS2", SqlDbType.VarChar).Value = TCRUZAMIENTOS2.Text.Trim
            cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = TCOLONIA.Text.Trim
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = TCODIGO.Text.Trim
            cmd.Parameters.Add("@LOCALIDAD", SqlDbType.VarChar).Value = TLOCALIDAD.Text.Trim
            cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMunicipio.Text.Trim
            cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = TEstado.Text.Trim
            cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = TPais.Text.Trim
            cmd.Parameters.Add("@NACIONALIDAD", SqlDbType.VarChar).Value = TNacionalidad.Text.Trim
            cmd.Parameters.Add("@REFERDIR", SqlDbType.VarChar).Value = TREFERDIR.Text.Trim
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = TTELEFONO.Text.Trim
            cmd.Parameters.Add("@CLASIFIC", SqlDbType.VarChar).Value = TClasific.Text.Trim
            cmd.Parameters.Add("@FAX", SqlDbType.VarChar).Value = TFax.Text.Trim
            cmd.Parameters.Add("@PAG_WEB", SqlDbType.VarChar).Value = TPAG_WEB.Text.Trim
            cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = TCURP.Text.Trim
            cmd.Parameters.Add("@CVE_ZONA", SqlDbType.VarChar).Value = TCVE_ZONA.Text.Trim
            cmd.Parameters.Add("@IMPRIR", SqlDbType.VarChar).Value = "S"
            cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = "S"
            cmd.Parameters.Add("@ENVIOSILEN", SqlDbType.VarChar).Value = "N"
            cmd.Parameters.Add("@EMAILPRED", SqlDbType.VarChar).Value = TEMAILPRED.Text
            cmd.Parameters.Add("@DIAREV", SqlDbType.VarChar).Value = TDIAREV.Text
            cmd.Parameters.Add("@DIAPAGO", SqlDbType.VarChar).Value = TDIAPAGO.Text
            cmd.Parameters.Add("@CON_CREDITO", SqlDbType.VarChar).Value = IIf(chCON_CREDITO.Checked, "S", "N")
            cmd.Parameters.Add("@DIASCRED", SqlDbType.Int).Value = CONVERTIR_TO_INT(TDiasCred.Value)
            cmd.Parameters.Add("@LIMCRED", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TLimCred.Value)
            cmd.Parameters.Add("@LISTA_PREC", SqlDbType.Int).Value = CONVERTIR_TO_INT(TLISTA_PREC.Text)
            cmd.Parameters.Add("@CVE_BITA", SqlDbType.Int).Value = CVE_BITA
            cmd.Parameters.Add("@ULT_PAGOD", SqlDbType.VarChar).Value = TULT_PAGOD.Text
            cmd.Parameters.Add("@ULT_PAGOM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TULT_PAGOM.Value)
            cmd.Parameters.Add("@ULT_PAGOF", SqlDbType.DateTime).Value = ULT_PAGOF.Value
            cmd.Parameters.Add("@DESCUENTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tDESCUENTO.Value)
            cmd.Parameters.Add("@ULT_VENTAD", SqlDbType.VarChar).Value = TULT_VENTAD.Text
            cmd.Parameters.Add("@ULT_COMPM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TULT_COMPM.Value)
            cmd.Parameters.Add("@FCH_ULTCOM", SqlDbType.DateTime).Value = FCH_ULTCOM.Value
            cmd.Parameters.Add("@VENTAS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVENTAS.Value)
            cmd.Parameters.Add("@CVE_VEND", SqlDbType.VarChar).Value = TCVE_VEND.Text
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            cmd.Parameters.Add("@TIPO_EMPRESA", SqlDbType.VarChar).Value = TIPO_EMPRESA
            cmd.Parameters.Add("@MATRIZ", SqlDbType.VarChar).Value = TMATRIZ.Text
            cmd.Parameters.Add("@CALLE_ENVIO", SqlDbType.VarChar).Value = TCALLE_ENVIO.Text
            cmd.Parameters.Add("@NUMINT_ENVIO", SqlDbType.VarChar).Value = TNUMINT_ENVIO.Text
            cmd.Parameters.Add("@NUMEXT_ENVIO", SqlDbType.VarChar).Value = TNUMEXT_ENVIO.Text
            cmd.Parameters.Add("@CRUZAMIENTOS_ENVIO", SqlDbType.VarChar).Value = TCRUZAMIENTOS_ENVIO.Text
            cmd.Parameters.Add("@CRUZAMIENTOS_ENVIO2", SqlDbType.VarChar).Value = TCRUZAMIENTOS_ENVIO2.Text
            cmd.Parameters.Add("@COLONIA_ENVIO", SqlDbType.VarChar).Value = TCOLONIA_ENVIO.Text
            cmd.Parameters.Add("@LOCALIDAD_ENVIO", SqlDbType.VarChar).Value = TLOCALIDAD_ENVIO.Text
            cmd.Parameters.Add("@MUNICIPIO_ENVIO", SqlDbType.VarChar).Value = TMUNICIPIO_ENVIO.Text
            cmd.Parameters.Add("@ESTADO_ENVIO", SqlDbType.VarChar).Value = TESTADO_ENVIO.Text
            cmd.Parameters.Add("@PAIS_ENVIO", SqlDbType.VarChar).Value = TPAIS_ENVIO.Text
            cmd.Parameters.Add("@CODIGO_ENVIO", SqlDbType.VarChar).Value = TCODIGO_ENVIO.Text
            cmd.Parameters.Add("@CVE_ZONA_ENVIO", SqlDbType.VarChar).Value = TCVE_ZONA_ENVIO.Text
            cmd.Parameters.Add("@REFERENCIA_ENVIO", SqlDbType.VarChar).Value = TREFERENCIA_ENVIO.Text
            cmd.Parameters.Add("@CUENTA_CONTABLE", SqlDbType.VarChar).Value = TCUENTA_CONTABLE.Text
            cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = TMETODODEPAGO.Text
            cmd.Parameters.Add("@NUMCTAPAGO", SqlDbType.VarChar).Value = TNUMCTAPAGO.Text
            cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO.Text
            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = TUSO_CFDI.Text.Trim
            cmd.Parameters.Add("@CVE_PAIS_SAT", SqlDbType.VarChar).Value = TCVE_PAIS_SAT.Text.Trim
            cmd.Parameters.Add("@NUMIDREGFISCAL", SqlDbType.VarChar).Value = TNUMIDREGFISCAL.Text.Trim
            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = TFORMADEPAGOSAT.Text.Trim
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = IIf(BtnActivo.Text = "Activo", "A", "B")
            cmd.Parameters.Add("@REG_FISC", SqlDbType.VarChar).Value = TREGIMEN_FISCAL.Text.Trim
            cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = TFLETE.Value
            cmd.Parameters.Add("@NUM_MON", SqlDbType.Float).Value = TNUM_MON.Value
            cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.Float).Value = TCVE_ESQIMPU.Value

            cmd.Parameters.Add("@MUNICIPIO_SAT", SqlDbType.VarChar).Value = TMUNICIPIO_SAT.Text
            cmd.Parameters.Add("@LOCALIDAD_SAT", SqlDbType.VarChar).Value = TLOCALIDAD_SAT.Text
            cmd.Parameters.Add("@ESTADO_SAT", SqlDbType.VarChar).Value = TESTADO_SAT.Text.Trim
            cmd.Parameters.Add("@PAIS_SAT", SqlDbType.VarChar).Value = TPAIS_SAT.Text.Trim
            cmd.Parameters.Add("@COLONIA_SAT", SqlDbType.VarChar).Value = TCOLONIA_SAT.Text
            cmd.Parameters.Add("@ALIAS", SqlDbType.VarChar).Value = TALIAS.Text
            cmd.Parameters.Add("@APLICACION", SqlDbType.VarChar).Value = TAPLICACION.Text

            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    GRABA_DATOS_BANCARIOS()
                    GRABAR_CAMPOS_LIBRES()
                    GRABAR_ADICIONALES()
                    GRABAR_MOVIMIENTOS_CFG()

                    Var11 = TCLAVE.Text
                    MsgBox("El registro se grabo satisfactoriamente")

                    If FGRABAR = "GRABAR Y SALIR" Then

                        Try
                            If FORM_IS_OPEN("frmClientes") Then
                                frmClientes.DESPLEGAR()
                            End If
                        Catch ex As Exception
                        End Try

                        Me.Close()
                    Else
                        BtnActivo.Enabled = True
                    End If
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub GRABAR_MOVIMIENTOS_CFG()
        Try
            SQL = "IF EXISTS (SELECT CLIENTE FROM GCMERCANCIAS_CFG WHERE CLIENTE = @CLIENTE)        
                    UPDATE GCMERCANCIAS_CFG SET 
                    COLA = @COLA, COLB = @COLB,
                    COLC = @COLC, COLD = @COLD, COLE = @COLE, COLF = @COLF, COLG = @COLG, COLH = @COLH, COLI = @COLI, 
                    COLJ = @COLJ, COLK = @COLK, COLL = @COLL, COLM = @COLM, COLN = @COLN,
                    COLO = @COLO, COLP = @COLP, COLQ = @COLQ, COLR = @COLR, COLS = @COLS, COLT = @COLT, COLU = @COLU, 
                    COLV = @COLV, COLW = @COLW, COLX = @COLX, COLY = @COLY, COLZ = @COLZ, COLAA = @COLAA, COLAB = @COLAB, 
                    COLAC = @COLAC, COLAD = @COLAD, COLAE = @COLAE, COLAF = @COLAF, COLAG = @COLAG, COLAH = @COLAH, 
                    COLAI = @COLAI, COLAJ = @COLAJ
                    WHERE  CLIENTE = @CLIENTE
                ELSE
                    INSERT INTO GCMERCANCIAS_CFG (CLIENTE, COLA, COLB, COLC, COLD, COLE, COLF, COLG, COLH, COLI, COLJ, COLK, COLL, COLM, COLN,
                    COLO, COLP, COLQ, COLR, COLS, COLT, COLU, COLV, COLW, COLX, COLY, COLZ, COLAA, COLAB, COLAC, COLAD, COLAE, COLAF, COLAG, 
                    COLAH, COLAI, COLAJ)
                    VALUES (
                    @CLIENTE, @COLA, @COLB, @COLC, @COLD, @COLE, @COLF, @COLG, @COLH, @COLI, @COLJ, @COLK, @COLL, @COLM, @COLN,
                    @COLO, @COLP, @COLQ, @COLR, @COLS, @COLT, @COLU, @COLV, @COLW, @COLX, @COLY, @COLZ, @COLAA, @COLAB, @COLAC, @COLAD, @COLAE, 
                    @COLAF, @COLAG, @COLAH, @COLAI, @COLAJ)"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLAVE.Text
                cmd.Parameters.Add("@COLA", SqlDbType.VarChar).Value = TCOLA.Text
                cmd.Parameters.Add("@COLB", SqlDbType.VarChar).Value = TCOLB.Text
                cmd.Parameters.Add("@COLC", SqlDbType.VarChar).Value = TCOLC.Text
                cmd.Parameters.Add("@COLD", SqlDbType.VarChar).Value = TCOLD.Text
                cmd.Parameters.Add("@COLE", SqlDbType.VarChar).Value = TCOLE.Text
                cmd.Parameters.Add("@COLF", SqlDbType.VarChar).Value = TCOLF.Text
                cmd.Parameters.Add("@COLG", SqlDbType.VarChar).Value = TCOLG.Text
                cmd.Parameters.Add("@COLH", SqlDbType.VarChar).Value = TCOLH.Text
                cmd.Parameters.Add("@COLI", SqlDbType.VarChar).Value = TCOLI.Text
                cmd.Parameters.Add("@COLJ", SqlDbType.VarChar).Value = TCOLJ.Text
                cmd.Parameters.Add("@COLK", SqlDbType.VarChar).Value = TCOLK.Text
                cmd.Parameters.Add("@COLL", SqlDbType.VarChar).Value = TCOLL.Text
                cmd.Parameters.Add("@COLM", SqlDbType.VarChar).Value = TCOLM.Text
                cmd.Parameters.Add("@COLN", SqlDbType.VarChar).Value = TCOLN.Text
                cmd.Parameters.Add("@COLO", SqlDbType.VarChar).Value = TCOLO.Text
                cmd.Parameters.Add("@COLP", SqlDbType.VarChar).Value = TCOLP.Text
                cmd.Parameters.Add("@COLQ", SqlDbType.VarChar).Value = TCOLQ.Text
                cmd.Parameters.Add("@COLR", SqlDbType.VarChar).Value = TCOLR.Text
                cmd.Parameters.Add("@COLS", SqlDbType.VarChar).Value = TCOLS.Text
                cmd.Parameters.Add("@COLT", SqlDbType.VarChar).Value = TCOLT.Text
                cmd.Parameters.Add("@COLU", SqlDbType.VarChar).Value = TCOLU.Text
                cmd.Parameters.Add("@COLV", SqlDbType.VarChar).Value = TCOLV.Text
                cmd.Parameters.Add("@COLW", SqlDbType.VarChar).Value = TCOLW.Text
                cmd.Parameters.Add("@COLX", SqlDbType.VarChar).Value = TCOLX.Text
                cmd.Parameters.Add("@COLY", SqlDbType.VarChar).Value = TCOLY.Text
                cmd.Parameters.Add("@COLZ", SqlDbType.VarChar).Value = TCOLZ.Text
                cmd.Parameters.Add("@COLAA", SqlDbType.VarChar).Value = TCOLAA.Text
                cmd.Parameters.Add("@COLAB", SqlDbType.VarChar).Value = TCOLAB.Text
                cmd.Parameters.Add("@COLAC", SqlDbType.VarChar).Value = TCOLAC.Text
                cmd.Parameters.Add("@COLAD", SqlDbType.VarChar).Value = TCOLAD.Text
                cmd.Parameters.Add("@COLAE", SqlDbType.VarChar).Value = TCOLAE.Text
                cmd.Parameters.Add("@COLAF", SqlDbType.VarChar).Value = TCOLAF.Text
                cmd.Parameters.Add("@COLAG", SqlDbType.VarChar).Value = TCOLAG.Text
                cmd.Parameters.Add("@COLAH", SqlDbType.VarChar).Value = TCOLAH.Text
                cmd.Parameters.Add("@COLAI", SqlDbType.VarChar).Value = TCOLAI.Text
                cmd.Parameters.Add("@COLAJ", SqlDbType.VarChar).Value = TCOLAJ.Text

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_ADICIONALES()
        Try
            Dim SQL2 As String, CADENA_INSERT1 As String = "INSERT INTO CLIE_ADIC (CLIENTE,", CADENA_INSERT2 As String = ""
            FgA.FinishEditing()

            ENTRA = False
            SQL = "UPDATE CLIE_ADIC SET"
            For k = 1 To FgA.Rows.Count - 1
                Try
                    If Not IsNothing(FgA(k, 2)) Then
                        If FgA(k, 2).ToString.Length > 0 Then
                            If FgA(k, 4).ToString.ToUpper = "INT" Or FgA(k, 4).ToString.ToUpper = "SMALLINT" Or FgA(k, 4).ToString.ToUpper = "FLOAT" Then
                                If IsNumeric(FgA(k, 2)) Then
                                    SQL = SQL & " " & FgA(k, 3) & " = " & FgA(k, 2).ToString.Trim & ", "
                                End If
                            Else
                                SQL = SQL & " " & FgA(k, 3) & " = '" & FgA(k, 2) & "', "
                            End If
                            CADENA_INSERT1 = CADENA_INSERT1 & FgA(k, 3) & ", "
                            CADENA_INSERT2 = CADENA_INSERT2 & "'" & FgA(k, 2).ToString.Trim & "', "
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("22. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            Next
            ENTRA = True
            If SQL = "UPDATE CLIE_ADIC SET" Then
                SQL = ""
            Else
                CADENA_INSERT1 = CADENA_INSERT1.Substring(0, CADENA_INSERT1.Length - 2) & ") "
                CADENA_INSERT2 = "VALUES ('" & TCLAVE.Text & "'," & CADENA_INSERT2.Substring(0, CADENA_INSERT2.Length - 2) & ") "

                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL2 = SQL.Substring(0, SQL.Length - 2) & " WHERE CLIENTE = '" & TCLAVE.Text & "' 
                               IF @@ROWCOUNT = 0  
                                " & CADENA_INSERT1 & CADENA_INSERT2
                        cmd.CommandText = SQL2
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch Ex As Exception
            Bitacora("22. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("22. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Sub GRABAR_CAMPOS_LIBRES()
        Dim SQL2 As String

        FgL.FinishEditing()

        Try
            ENTRA = False
            SQL = "UPDATE CLIE_CLIB" & Empresa & " SET "
            For k = 1 To FgL.Rows.Count - 1
                Try
                    If FgL(k, 4).ToString.ToUpper = "INT" Or FgL(k, 4).ToString.ToUpper = "SMALLINT" Or FgL(k, 4).ToString.ToUpper = "FLOAT" Or
                        FgL(k, 4).ToString.ToUpper = "DECIMAL" Or FgL(k, 4).ToString.ToUpper = "INT32" Or FgL(k, 4).ToString.ToUpper = "DOUBLE" Then
                        If IsNumeric(FgL(k, 2)) Then
                            SQL = SQL & " " & FgL(k, 3) & " = " & FgL(k, 2) & ", "
                        Else
                            SQL = SQL & " " & FgL(k, 3) & " = 0, "
                        End If
                    Else
                        SQL = SQL & " " & FgL(k, 3) & " = '" & FgL(k, 2) & "', "
                    End If
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            ENTRA = True
            If SQL = "UPDATE CLIE_CLIB" & Empresa & " SET " Then
                SQL = ""
            Else
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL2 = SQL.Substring(0, SQL.Length - 2) & " WHERE CVE_CLIE = '" & TCLAVE.Text & "' "
                        cmd.CommandText = SQL2
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            Else
                                Try
                                    SQL = "UPDATE CLIE_CLIB" & Empresa & " SET CVE_CLIE = '" & TCLAVE.Text & "',
                                    CAMPLIB1 = ' ',
                                    CAMPLIB2 = ' ',
                                    CAMPLIB3 = ' ',
                                    CAMPLIB4 = 0,  CAMPLIB5 = 0,  CAMPLIB6 = 0
                                    WHERE CVE_CLIE = '" & TCLAVE.Text & "'
                                    IF @@ROWCOUNT=0
                                    INSERT INTO CLIE_CLIB" & Empresa & " (CVE_CLIE, CAMPLIB1, CAMPLIB2,
                                    CAMPLIB3, CAMPLIB4, CAMPLIB5, CAMPLIB6) VALUES('" & TCLAVE.Text & "',' ',' ',' ','0','0','0')"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue = "1" Then
                                        End If
                                    End Using
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL2
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue = "1" Then
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            Try
                For k = 1 To FgL.Rows.Count - 1
                    If FgL(k, 1).ToString.Length > 0 Then
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE PARAM_CAMPOSLIBRES" & Empresa & " SET ETIQUETA = '" & FgL(k, 1) &
                                "' WHERE IDTABLA = 'CLIE_CLIB' AND CAMPO = '" & FgL(k, 3) & "'"
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
                Bitacora("21. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("21. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch Ex As Exception
            Bitacora("22. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("22. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub GRABA_DATOS_BANCARIOS()
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE
        For k = 1 To Fg.Rows.Count - 1

            If Fg(k, 1).ToString.Length > 0 Then
                SQL = "UPDATE CUENTA_ORD" & Empresa & " SET CUENTA_BANCARIA = @CUENTA_BANCARIA, RFC_BANCO = @RFC_BANCO, NOMBRE_BANCO = @NOMBRE_BANCO, CLAVE = @CLAVE" &
                    " WHERE CLAVE = @CLAVE " &
                    "IF @@ROWCOUNT = 0 " &
                    "INSERT INTO CUENTA_ORD" & Empresa & " (CUENTA_BANCARIA, RFC_BANCO, NOMBRE_BANCO, CLAVE) " &
                    "VALUES(@CUENTA_BANCARIA, @RFC_BANCO, @NOMBRE_BANCO, @CLAVE)"
                cmd.CommandText = SQL
                Try
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("@CUENTA_BANCARIA", SqlDbType.VarChar).Value = Fg(k, 1).ToString
                    cmd.Parameters.Add("@RFC_BANCO", SqlDbType.VarChar).Value = Fg(k, 3).ToString
                    cmd.Parameters.Add("@NOMBRE_BANCO", SqlDbType.VarChar).Value = Fg(k, 2).ToString
                    cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCLAVE.Text
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue = "1" Then
                    End If
                Catch ex As Exception
                    MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Next
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub RadMatriz_CheckedChanged(sender As Object, e As EventArgs) Handles radMatriz.CheckedChanged
        If radMatriz.Checked Then
            TMATRIZ.Visible = False
            LtMatriz.Visible = False
            LMatriz.Visible = False
            BtnMatriz.Visible = False
        Else
            TMATRIZ.Visible = True
            LtMatriz.Visible = True
            LMatriz.Visible = True
            BtnMatriz.Visible = True
        End If
    End Sub
    Private Sub RadSuc_CheckedChanged(sender As Object, e As EventArgs) Handles radSuc.CheckedChanged
        If radSuc.Checked Then
            TMATRIZ.Visible = True
            LtMatriz.Visible = True
            LMatriz.Visible = True
            BtnMatriz.Visible = True
        Else
            TMATRIZ.Visible = False
            LtMatriz.Visible = False
            LMatriz.Visible = False
            BtnMatriz.Visible = False
        End If
    End Sub
    Private Sub RadMatriz_GotFocus(sender As Object, e As EventArgs) Handles radMatriz.GotFocus
        radMatriz.BackColor = Color.YellowGreen
    End Sub
    Private Sub RadSuc_GotFocus(sender As Object, e As EventArgs) Handles radSuc.GotFocus
        radSuc.BackColor = Color.YellowGreen
    End Sub
    Private Sub RadSuc_LostFocus(sender As Object, e As EventArgs) Handles radSuc.LostFocus
        radSuc.BackColor = Color.Transparent
    End Sub
    Private Sub RadMatriz_LostFocus(sender As Object, e As EventArgs) Handles radMatriz.LostFocus
        radMatriz.BackColor = Color.Transparent
    End Sub
    Private Sub cboStatus_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        End If
    End Sub
    Private Sub BtnZona_Click(sender As Object, e As EventArgs) Handles BtnZona.Click
        Try
            Var2 = "Zona"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ZONA.Text = Var4
                LtZona.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnVend_Click(sender As Object, e As EventArgs) Handles BtnVend.Click
        Try
            Var2 = "Vend"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_VEND.Text = Var4
                LtVend.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnListaPrec_Click(sender As Object, e As EventArgs) Handles BtnListaPrec.Click
        Try
            Var2 = "Listaprec"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLISTA_PREC.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnZonaEnvio_Click(sender As Object, e As EventArgs) Handles BtnZonaEnvio.Click
        Try
            Var2 = "Zona"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ZONA_ENVIO.Text = Var4
                LtZonaEnvio.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnUsoCFDI_Click(sender As Object, e As EventArgs) Handles BtnUsoCFDI.Click
        Try
            Var2 = "USOCFDI"
            FrmSelItem22.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TUSO_CFDI.Text = Var4
                LtUsoCFDI.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TUSO_CFDI_KeyDown(sender As Object, e As KeyEventArgs) Handles TUSO_CFDI.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUsoCFDI_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TUSO_CFDI_Validated(sender As Object, e As EventArgs) Handles TUSO_CFDI.Validated
        Try
            Dim DESCR As String
            DESCR = BUSCA_CAT("USO CFDI", TUSO_CFDI.Text)
            If DESCR <> "N" Then
                LtUsoCFDI.Text = DESCR
            Else
                MsgBox("Uso CFDI inexistente")
                TUSO_CFDI.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnPagoSAT_Click(sender As Object, e As EventArgs) Handles BtnPagoSAT.Click
        Try
            Var2 = "PagoSAT"

            frmUsoCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TFORMADEPAGOSAT.Text = Var4
                Label70.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TFORMADEPAGOSAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TFORMADEPAGOSAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPagoSAT_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TFORMADEPAGOSAT_Validated(sender As Object, e As EventArgs) Handles TFORMADEPAGOSAT.Validated
        Try
            If TFORMADEPAGOSAT.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("tblcformapago", TFORMADEPAGOSAT.Text)
                If DESCR <> "N" And DESCR <> "" Then
                    Label70.Text = DESCR
                Else
                    MsgBox("Forma de pago SAT inexistente")
                    Label70.Text = ""
                    TFORMADEPAGOSAT.Text = ""
                End If
            Else
                LtVend.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnPaisResiFiscal_Click(sender As Object, e As EventArgs) Handles BtnPaisResiFiscal.Click
        Try
            Var2 = "Pais"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PAIS_SAT.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Try
            If frmClientes.Fg.Row > 1 Then
                CLIENTE = frmClientes.Fg(frmClientes.Fg.Row - 1, 1)
                frmClientes.Fg.Row = frmClientes.Fg.Row - 1
                DESPLEGAR_CLIENTE()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnInicial_Click(sender As Object, e As EventArgs) Handles btnInicial.Click
        Try
            If frmClientes.Fg.Row > 0 Then
                CLIENTE = frmClientes.Fg(1, 1)
                frmClientes.Fg.Row = 1
                DESPLEGAR_CLIENTE()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Try
            If frmClientes.Fg.Row > 0 Then
                If frmClientes.Fg.Row < frmClientes.Fg.Rows.Count - 1 Then
                    CLIENTE = frmClientes.Fg(frmClientes.Fg.Row + 1, 1)
                    frmClientes.Fg.Row = frmClientes.Fg.Row + 1
                    DESPLEGAR_CLIENTE()
                End If
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnFinal_Click(sender As Object, e As EventArgs) Handles btnFinal.Click
        Try
            If frmClientes.Fg.Row > 0 Then
                CLIENTE = frmClientes.Fg(frmClientes.Fg.Rows.Count - 1, 1)
                frmClientes.Fg.Row = frmClientes.Fg.Rows.Count - 1
                DESPLEGAR_CLIENTE()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnBancos_Click(sender As Object, e As EventArgs) Handles BtnBancos.Click
        'Var4 = Fg(Fg.Row, 1) 'CLAVE
        'Var5 = Fg(Fg.Row, 2) 'NOMBRE
        'Var6 = Fg(Fg.Row, 3) 'RFC
        Try
            Var2 = "Bancos"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TBancoFiscal.Tag = Var4
                TBancoFiscal.Text = Var5
                TRFCFiscal.Text = Var6
                TRFCFiscal.Select()
                Var2 = "" : Var5 = "" : Var6 = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If TCtaBanFiscal.Text.Trim.Length = 0 Then
                MsgBox("Capture la cuenta bancaria")
                Return
            End If
            If TBancoFiscal.Text.Trim.Length = 0 Then
                MsgBox("Seleccione el banco")
                Return
            End If
            If TRFCFiscal.Text.Trim.Length = 0 Then
                MsgBox("Capture el RFC")
                Return
            End If

            Fg.AddItem("" & vbTab & TCtaBanFiscal.Text & vbTab & TBancoFiscal.Text & vbTab & TRFCFiscal.Text)
            TCtaBanFiscal.Text = ""
            TBancoFiscal.Text = ""
            TRFCFiscal.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If Fg.Row > 0 Then
                Fg.RemoveItem(Fg.Row)
            Else
                MsgBox("Por favor seleccione un dato bancario")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgL_EnterCell(sender As Object, e As EventArgs) Handles FgL.EnterCell
        If FgL.Row > 0 And ENTRA Then
            FgL.StartEditing()
        End If
    End Sub
    Private Sub BtnDocModelo_Click(sender As Object, e As EventArgs) Handles BtnDocModelo.Click
        Try
            Dim rutaAspel As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) &
                "\Common Files\Aspel\Sistemas Aspel\SAE7.00\Empresa01\Documentos modelo"

            OpenFileDialog1.Title = "Por favor seleccione un archivo"
            OpenFileDialog1.InitialDirectory = rutaAspel
            OpenFileDialog1.Filter = "Documento modelo|*.mod"
            If TMODELO.Text.Trim.Length = 0 Then
                OpenFileDialog1.FileName = ""
            Else
                OpenFileDialog1.FileName = TMODELO.Text
            End If
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim copyToDir = Path.GetDirectoryName(OpenFileDialog1.FileName)
                Dim file = Path.GetFileName(OpenFileDialog1.FileName)
                If rutaAspel = copyToDir Then
                    '
                Else
                    Dim newPath = Path.Combine(copyToDir, file)
                    IO.File.Copy(OpenFileDialog1.FileName, rutaAspel & "\" & file)
                End If
                TMODELO.Text = file
                TMODELO.Tag = Path.GetFileName(OpenFileDialog1.FileName)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TMATRIZ_KeyDown(sender As Object, e As KeyEventArgs) Handles TMATRIZ.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMatriz_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TBancoFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles TBancoFiscal.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnBancos_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub BtnMatriz_Click(sender As Object, e As EventArgs) Handles BtnMatriz.Click
        Try
            Var2 = "Clientes" : Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var1.Trim.Length > 0 Then
                TMATRIZ.Text = Var4
                LMatriz.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TMATRIZ_Validated(sender As Object, e As EventArgs) Handles TMATRIZ.Validated
        Try
            Dim DESCR As String
            DESCR = BUSCA_CAT("Cliente", TMATRIZ.Text)
            If DESCR <> "N" Then
                LMatriz.Text = DESCR
            Else
                MsgBox("Sucursal inexistente")
                TMATRIZ.SelectAll()
                TMATRIZ.Select()
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TPais_KeyDown(sender As Object, e As KeyEventArgs) Handles TPais.KeyDown
        'If e.KeyCode = Keys.F2 Then
        'BtnPais_Click(Nothing, Nothing)
        'Return
        'End If
    End Sub
    Private Sub TPais_Validated(sender As Object, e As EventArgs) Handles TPais.Validated
        Try
            'If TPais.Text.Trim.Length > 0 Then
            'Dim DESCR As String
            'DESCR = BUSCA_CAT("Pais", TPais.Text)
            'If DESCR <> "N" And DESCR <> "" Then
            'LtPais.Text = DESCR
            'Else
            'MsgBox("Pais  inexistente")
            'LtPais.Text = ""
            'TPais.Text = ""
            'TPais.SelectAll()
            'TPais.Select()
            'End If
            'E'lse
            'LtPais.Text = ""
            'End If
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
        End Try
    End Sub

    Private Sub TCVE_VEND_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_VEND.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnVend_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_VEND_Validated(sender As Object, e As EventArgs) Handles TCVE_VEND.Validated
        Try
            If TCVE_VEND.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Vend", TCVE_VEND.Text)
                If DESCR <> "N" And DESCR <> "" Then
                    LtVend.Text = DESCR
                Else
                    MsgBox("Vendedor inexistente")
                    LtVend.Text = ""
                    TCVE_VEND.Text = ""
                    TCVE_VEND.SelectAll()
                    TCVE_VEND.Select()
                End If
            Else
                LtVend.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TDiasCred_TextChanged(sender As Object, e As EventArgs) Handles TDiasCred.TextChanged
        Try
            If Not IsNothing(TDiasCred.Value) Then
                'TDiasCred.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLimCred_TextChanged(sender As Object, e As EventArgs) Handles TLimCred.TextChanged
        Try
            If Not IsNothing(TLimCred.Value) Then
                TLimCred.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TDESCUENTO_TextChanged(sender As Object, e As EventArgs) Handles tDESCUENTO.TextChanged
        Try
            If Not IsNothing(tDESCUENTO.Value) Then
                tDESCUENTO.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_SetupEditor(sender As Object, e As RowColEventArgs) Handles FgA.SetupEditor
        Try
            Dim TIPO As String, LONGITUD As Integer

            '                                               DATOS                CAMPO           TIPO DATOS  
            'FgA.AddItem("" & vbTab & dr("LEYENDA") & vbTab & " " & vbTab & dr("NOMBRE") & vbTab & " " & vbTab & dr("LONGITUD"))
            If FgA.Row > 0 Then
                If FgA.Col = 2 Then
                    TIPO = FgA(FgA.Row, 4)
                    If IsNumeric(FgA(FgA.Row, 5)) Then
                        LONGITUD = CInt(FgA(Fg.Row, 5))
                    Else
                        LONGITUD = 0
                    End If

                    If TIPO = "VARCHAR" Then
                        If TypeOf FgA.Editor Is TextBox Then
                            Dim ctl As TextBox = FgA.Editor
                            If (e.Col = 2) Then
                                ctl.MaxLength = LONGITUD
                            Else
                                ctl.MaxLength = 0
                            End If
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnRegimenFiscal_Click(sender As Object, e As EventArgs) Handles BtnRegimenFiscal.Click
        Try
            Var2 = "RegimenFiscal"
            frmUsoCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TREGIMEN_FISCAL.Text = Var4
                LtRegFis.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TREGIMEN_FISCAL_KeyDown(sender As Object, e As KeyEventArgs) Handles TREGIMEN_FISCAL.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnRegimenFiscal_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TREGIMEN_FISCAL_Validated(sender As Object, e As EventArgs) Handles TREGIMEN_FISCAL.Validated

        Try
            LtRegFis.Text = OBTENER_REGIMEN_FISCAL_XML(TREGIMEN_FISCAL.Text)
            If LtRegFis.Text = "" Then
                MsgBox("Regimen fiscal inexistente, verifique por favor")
                TREGIMEN_FISCAL.Text = TREGIMEN_FISCAL.Tag
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub BtnActivo_Click(sender As Object, e As EventArgs) Handles BtnActivo.Click
        Try
            If BtnActivo.Text = "Activo" Then
                BtnActivo.Text = "Baja"
            Else
                BtnActivo.Text = "Activo"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TNOMBRE_KeyDown(sender As Object, e As KeyEventArgs) Handles TNOMBRE.KeyDown
        If e.KeyCode = 13 Then
            GroupBox8.Focus()
        End If
    End Sub
    Private Sub TNOMBRE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TNOMBRE.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox8.Focus()
        End If

    End Sub
    Private Sub BtnActivo_KeyDown(sender As Object, e As KeyEventArgs) Handles BtnActivo.KeyDown
        If e.KeyCode = 13 Then
            TRFC.Focus()
        End If
    End Sub
    Private Sub BtnActivo_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles BtnActivo.PreviewKeyDown
        If e.KeyCode = 9 Then
            TRFC.Focus()
        End If
    End Sub
    Private Sub GET_DATOS_CLIENTE()
    End Sub

    Private Sub BtnStatusCliente_Click(sender As Object, e As EventArgs) Handles BtnRFC.Click
        GET_DATOS_CLIENTE()
    End Sub

    Private Sub GroupBox8_Enter(sender As Object, e As EventArgs) Handles GroupBox8.Enter

    End Sub

    Private Sub TEMAILPRED_KeyDown(sender As Object, e As KeyEventArgs) Handles TEMAILPRED.KeyDown
        If e.KeyCode = 13 Then
            GroupBox7.Focus()
        End If
    End Sub
    Private Sub TEMAILPRED_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TEMAILPRED.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox7.Focus()
        End If
    End Sub

    Private Sub TULT_COMPM_KeyDown(sender As Object, e As KeyEventArgs) Handles TULT_COMPM.KeyDown
        If e.KeyCode = 13 Then
            GroupBox8.Focus()
        End If
    End Sub
    Private Sub TULT_COMPM_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TULT_COMPM.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox8.Focus()
        End If
    End Sub
    Private Sub TCVE_PAIS_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PAIS_SAT.KeyDown
        If e.KeyCode = 13 Then
            GroupBox5.Focus()
        End If
    End Sub
    Private Sub TCVE_PAIS_SAT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_PAIS_SAT.PreviewKeyDown
        If e.KeyCode = 9 Then
            GroupBox5.Focus()
        End If
    End Sub
    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus
        Fg.BorderStyle = Util.BaseControls.BorderStyleEnum.Fixed3D
    End Sub
    Private Sub Fg_LostFocus(sender As Object, e As EventArgs) Handles Fg.LostFocus
        Fg.BorderStyle = Util.BaseControls.BorderStyleEnum.FixedSingle
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        If e.KeyCode = 13 Then
            TCALLE_ENVIO.Focus()
        End If
    End Sub
    Private Sub Fg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Fg.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCALLE_ENVIO.Focus()
        End If
    End Sub
    Private Sub TCVE_ZONA_ENVIO_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ZONA_ENVIO.KeyDown
        If e.KeyCode = 13 Then
            TCVE_OBS.Focus()
        End If
    End Sub
    Private Sub TCVE_ZONA_ENVIO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_ZONA_ENVIO.PreviewKeyDown
        If e.KeyCode = 9 Then
            BtnZonaEnvio.Select()
        End If
    End Sub
    Private Sub BtnMetodoPago_Click(sender As Object, e As EventArgs) Handles BtnMetodoPago.Click
        Try
            Var2 = "Metodo de pago"
            Var4 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TMETODODEPAGO.Text = Var4
                Var2 = ""
                Var4 = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TMETODODEPAGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TMETODODEPAGO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMetodoPago_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TMETODODEPAGO_Validated(sender As Object, e As EventArgs) Handles TMETODODEPAGO.Validated
        Try
            If TMETODODEPAGO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Metodo de pago", TMETODODEPAGO.Text)
                If DESCR <> "N" And DESCR <> "" Then

                Else
                    MsgBox("Metodo de pago inexistente")
                    TMETODODEPAGO.Text = ""
                    TNUMCTAPAGO.Focus()
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnBorrarMercancias_Click(sender As Object, e As EventArgs)

        If Not CLIE_NEW Then
            If MsgBox("Realmente desea borrar las marcancias del cliente " & TCLAVE.Text & "?", vbYesNo) = vbYes Then
                Try
                    SQL = "DELETE FROM GCMERCANCIAS_CFG WHERE CVE_VIAJE = '" & TCLAVE.Text & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If Convert.ToInt32(returnValue) > 0 Then
                                Fg.Rows.Count = 1
                                MsgBox("Las mercancias se eliminaron correctamente")
                            Else
                                MsgBox("No se logro eliminar las mercancias")
                            End If
                        Else
                            MsgBox("No se logro eliminar las mercancias")
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            End If
        Else
            MsgBox("Por favor primero grabe el viaje")
        End If
    End Sub

    Private Sub TNOMBRE_TextChanged(sender As Object, e As EventArgs) Handles TNOMBRE.TextChanged

    End Sub

    Private Sub frmEstadoCuenta_Click(sender As Object, e As EventArgs) Handles frmEstadoCuenta.Click
        Try
            Var4 = TCLAVE.Text
            Var5 = TNOMBRE.Text
            FrmEdoCuentaCliente.ShowDialog()
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEstadoCuenta_Click(sender As Object, e As EventArgs) Handles BarEstadoCuenta.Click

    End Sub
    Private Sub BtnEsquema_Click(sender As Object, e As EventArgs) Handles BtnEsquema.Click
        Try
            Var2 = "Esquema"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ESQIMPU.Value = Var4
                LtEsquema.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TNumExt.Focus()
            End If
        Catch ex As Exception
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ESQIMPU_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ESQIMPU.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEsquema_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_ESQIMPU_Validated(sender As Object, e As EventArgs) Handles TCVE_ESQIMPU.Validated
        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Esquema inexistente")
                    TCVE_ESQIMPU.Select()
                Else
                    LtEsquema.Text = CADENA
                End If
            End If
        Catch ex As Exception
            Bitacora("112. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnMoneda_Click(sender As Object, e As EventArgs) Handles BtnMoneda.Click
        Try
            Var2 = "Moneda"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TNUM_MON.Text = Var4
                LtMoneda.Text = Var5
                LtMX.Text = Var6
                'Var4 = Fg(Fg.Row, 1) 'NUM_MONED
                'Var5 = Fg(Fg.Row, 2) 'DESCR
                'Var6 = Fg(Fg.Row, 3) 'CVE_MONDE
                'Var7 = Fg(Fg.Row, 4) 'TIPO CAMBBIO
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TCALLE.Focus()
            End If
        Catch ex As Exception
            MsgBox("210. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TNUM_MON_KeyDown(sender As Object, e As KeyEventArgs) Handles TNUM_MON.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMoneda_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TNUM_MON_Validated(sender As Object, e As EventArgs) Handles TNUM_MON.Validated
        Try
            If TNUM_MON.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Moneda", TNUM_MON.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Moneda inexistente")
                    TNUM_MON.Value = 1
                    TNUM_MON.Select()
                Else
                    LtMoneda.Text = CADENA
                    LtMX.Text = Var6
                End If
            End If
        Catch ex As Exception
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCP_Click(sender As Object, e As EventArgs) Handles BtnCP.Click
        Try
            Prosec = "CP"
            Var4 = ""
            Var6 = TCODIGO.Text
            Var7 = TLOCALIDAD.Text
            Var8 = TMunicipio.Text
            Var9 = TEstado.Text
            FrmListaXML.ShowDialog()
            'FrmSelItemBinding.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCODIGO.Text = Var4
                'TESTADO_SAT.Text = Var7
                'TMUNICIPIO_SAT.Text = Var8
                'TLOCALIDAD_SAT.Text = Var9
                'TPais.Text = "MEXICO"
                'TPAIS_SAT.Text = "MEX"
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCODIGO_Validated(sender As Object, e As EventArgs) Handles TCODIGO.Validated
        Dim doc As New XmlDocument()
        Dim CP As String, x As Integer = 0

        Try
            If TCODIGO.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_CODIGO_POSTAL.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_CODIGO_POSTAL.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_CodigoPostal='" & TCODIGO.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Codigo postal inexistente, verifique por favor")
                    Else
                        For Each node As XmlNode In nodeList
                            CP = node.Attributes("c_CodigoPostal").Value
                            TESTADO_SAT.Text = node.Attributes("c_Estado").Value
                            TMUNICIPIO_SAT.Text = node.Attributes("c_Municipio").Value
                            TLOCALIDAD_SAT.Text = node.Attributes("c_Localidad").Value
                            TPais.Text = "MEXICO"
                            TPAIS_SAT.Text = "MEX"

                            If CP = TCODIGO.Text Then
                                x += 1
                            End If
                        Next
                    End If
                    If x = 0 Then
                        MsgBox("Código postal no corresponde a la localidad y municipio capturados, verfique por favor")
                    Else
                        If TESTADO_SAT.Text.Trim.Length > 0 AndAlso TLOCALIDAD_SAT.Text.Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml")

                                'Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or7 @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")

                                Dim nodeList2 As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Estado='" & TESTADO_SAT.Text & "' and @Clave='" & TLOCALIDAD_SAT.Text & "']")
                                If nodeList2.Count > 0 Then
                                    For Each node As XmlNode In nodeList2
                                        If Not IsNothing(node.Attributes("Descripcion")) Then
                                            TLOCALIDAD.Text = node.Attributes("Descripcion").Value
                                        End If
                                    Next
                                End If
                            End If
                        End If
                        If TESTADO_SAT.Text.Trim.Length > 0 AndAlso TMUNICIPIO_SAT.Text.Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml")

                                'Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or7 @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")

                                Dim nodeList2 As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Estado='" & TESTADO_SAT.Text & "' and @Clave='" & TMUNICIPIO_SAT.Text & "']")
                                If nodeList2.Count > 0 Then
                                    For Each node As XmlNode In nodeList2
                                        If Not IsNothing(node.Attributes("Descripcion")) Then
                                            TMunicipio.Text = node.Attributes("Descripcion").Value
                                        End If
                                    Next
                                End If
                            End If
                        End If

                        If TESTADO_SAT.Text.Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml")

                                'Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or7 @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")

                                Dim nodeList2 As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TESTADO_SAT.Text & "']")
                                If nodeList2.Count > 0 Then
                                    For Each node As XmlNode In nodeList2
                                        If Not IsNothing(node.Attributes("Descripcion")) Then
                                            TEstado.Text = node.Attributes("Descripcion").Value
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    End If
                Else
                    MsgBox("Catálogo " & Application.StartupPath & "\CatalogosSat\CAT_CODIGO_POSTAL.xml inexistente, verifique por favor")
                End If
            End If

        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCertificado_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnMunicipio_Click(sender As Object, e As EventArgs) Handles BtnMunicipio.Click
        Try
            Prosec = "Municipio"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TMunicipio.Text = Var12
                TMUNICIPIO_SAT.Text = Var11
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLocalidad_Click(sender As Object, e As EventArgs) Handles BtnLocalidad.Click
        Try
            Prosec = "Localidad"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TLOCALIDAD.Text = Var12
                TLOCALIDAD_SAT.Text = Var11
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEstado_Click(sender As Object, e As EventArgs) Handles BtnEstado.Click
        Try
            Prosec = "Estado"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TEstado.Text = Var12
                TESTADO_SAT.Text = Var11
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnPais_Click(sender As Object, e As EventArgs) Handles BtnPais.Click
        Try
            Prosec = "Pais"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TPais.Text = Var12
                TPAIS_SAT.Text = Var11
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnColonia_Click(sender As Object, e As EventArgs) Handles BtnColonia.Click
        Try
            Prosec = "COLONIAS"
            Var4 = ""
            Var6 = TCOLONIA_SAT.Text
            Var7 = TCODIGO.Text
            FrmSelItemBinding.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCOLONIA.Text = Var8
                TCOLONIA_SAT.Text = Var4
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCODIGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TCODIGO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCP_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCOLONIA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCOLONIA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnColonia_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCOLONIA_Validated(sender As Object, e As EventArgs) Handles TCOLONIA.Validated
        SQL = "SELECT colonia, codigopostal, nombreasentamiento 
            FROM tblcolonias WHERE colonia = '" & TCOLONIA_SAT.Text & "' AND codigopostal = '" & TCODIGO.Text & "'"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCOLONIA.Text = dr("nombreasentamiento")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnApli_Click(sender As Object, e As EventArgs) Handles BtnApli.Click
        Try
            Var2 = "PagoSAT"

            frmUsoCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TAPLICACION.Text = Var4
                Label78.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TAPLICACION_KeyDown(sender As Object, e As KeyEventArgs) Handles TAPLICACION.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnApli_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TAPLICACION_Validated(sender As Object, e As EventArgs) Handles TAPLICACION.Validated
        Try
            If TAPLICACION.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("tblcformapago", TAPLICACION.Text)
                If DESCR <> "N" And DESCR <> "" Then
                    Label70.Text = DESCR
                Else
                    MsgBox("Forma de pago SAT inexistente")
                    Label70.Text = ""
                    TAPLICACION.Text = ""
                End If
            Else
                LtVend.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Class
