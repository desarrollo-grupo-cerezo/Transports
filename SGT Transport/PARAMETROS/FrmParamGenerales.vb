Imports System.IO
Imports System.Data.SqlClient
Imports Stimulsoft.Controls.Win.DotNetBar

Public Class FrmParamGenerales
    Private Sub FrmParamGenerales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            cboOT.Items.Clear()
            cboOT.Items.Add("Predeterminada")
            cboOT.Items.Add("Trans 2")

            cboOTE.Items.Clear()
            cboOTE.Items.Add("Predeterminada")
            cboOTE.Items.Add("Trans 2")

            cboNivelCombustible.Items.Clear()
            cboNivelCombustible.Items.Add("Predeterminada")
            cboNivelCombustible.Items.Add("Trans 2")

            CboTabRutas.Items.Clear()
            CboTabRutas.Items.Add("Tabulador de rutas")
            CboTabRutas.Items.Add("Importador excel")
            CboTabRutas.Items.Add("Viajes por liquidar")
            cboNivelCombustible.SelectedIndex = 0


            CboLlantas.Items.Clear()
            CboLlantas.Items.Add("Predeterminada")
            CboLlantas.Items.Add("Trans 2")

            Tab1.Dock = DockStyle.Fill

            CboCatRutas.Items.Add("Catalogo de rutas 1")
            CboCatRutas.Items.Add("Catalogo de rutas 2")

            CBOASIG_VIAJE.Items.Add("Asignación de viaje 1")
            CBOASIG_VIAJE.Items.Add("Asignación de viaje 2")

            CboBAJA_VIAJE_FACTURACION.Items.Add("Predeterminado")
            CboBAJA_VIAJE_FACTURACION.Items.Add("Facturación desde viajes realizados")
            CboBAJA_VIAJE_FACTURACION.SelectedIndex = 0

        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "SELECT RUTA_HUELLAS, RUTA_FOTOS, UTILIZAR_LECTOR_HUELLA FROM CONFIG WHERE EMPRESA = '" & Empresa & "'"
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        If dr.ReadNullAsEmptyInteger("UTILIZAR_LECTOR_HUELLA") = 1 Then
                            ChUtilizarHuella.Checked = True
                        Else
                            ChUtilizarHuella.Checked = False
                        End If
                        TRUTA_HUELLAS.Text = dr.ReadNullAsEmptyString("RUTA_HUELLAS")
                        TRUTA_FOTOS.Text = dr.ReadNullAsEmptyString("RUTA_FOTOS")

                    Else
                        ChUtilizarHuella.Checked = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            BtnAsignarRutaUsuarios.Visible = False



            cmd.Connection = cnSAE
            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                TRUTA_DOC.Text = dr("RUTA_DOC")
                TRUTA_IMAGEN.Text = dr("RUTA_IMAGEN")

                TRUTA_MODELO.Text = dr("RUTA_MODELO").ToString
                TRUTA_FORMATOS.Text = dr("RUTA_FORMATOS").ToString
                TRUTA_XML.Text = dr.ReadNullAsEmptyString("RUTA_XML").ToString

                cboOT.SelectedIndex = dr.ReadNullAsEmptyInteger("TIPO_OTI")
                cboOTE.SelectedIndex = dr.ReadNullAsEmptyInteger("TIPO_OTE")

                cboNivelCombustible.SelectedIndex = dr.ReadNullAsEmptyInteger("TIPO_MEDICION_COMBUSTIBLE")

                CboTabRutas.SelectedIndex = dr.ReadNullAsEmptyInteger("TIPO_TAB")

                CboLlantas.SelectedIndex = dr.ReadNullAsEmptyInteger("TIPO_LLANTAS")

                CboCatRutas.SelectedIndex = dr.ReadNullAsEmptyInteger("CAT_RUTAS")

                CBOASIG_VIAJE.SelectedIndex = dr.ReadNullAsEmptyInteger("ASIG_VIAJES")

                CboBAJA_VIAJE_FACTURACION.SelectedIndex = dr.ReadNullAsEmptyInteger("BAJA_VIAJE_FACTURACION")

                If dr.ReadNullAsEmptyInteger("DESCUENTO") = 0 Then
                    chDescuento.Checked = False
                Else
                    chDescuento.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("CALIFICACION") = 0 Then
                    chCalificacion.Checked = False
                Else
                    chCalificacion.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("VELOCIDADMAXIMA") = 0 Then
                    chVelocidadMaxima.Checked = False
                Else
                    chVelocidadMaxima.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("TIEMPOMARCHAINERCIA") = 0 Then
                    chTiempoMarchaInercia.Checked = False
                Else
                    chTiempoMarchaInercia.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("LITROSDESCONTAR") = 0 Then
                    chLitrosDescontar.Checked = False
                Else
                    chLitrosDescontar.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("PRECIOXLITRO") = 0 Then
                    chPrecioXLitro.Checked = False
                Else
                    chPrecioXLitro.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("DESCXLITRO") = 0 Then
                    chDescXLitro.Checked = False
                Else
                    chDescXLitro.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("LTSAUTORIZ") = 0 Then
                    chLtsAutoriz.Checked = False
                Else
                    chLtsAutoriz.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("LTSUREA") = 0 Then
                    chLtsUREA.Checked = False
                Else
                    chLtsUREA.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("LTSUREA_REAL") = 0 Then
                    chLtsUreaReal.Checked = False
                Else
                    chLtsUreaReal.Checked = True
                End If

                If dr.ReadNullAsEmptyInteger("CARGOXPUNTOMUERTO") = 0 Then
                    chCargoXPuntoMuerto.Checked = False
                Else
                    chCargoXPuntoMuerto.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("NO_VIAJE") = 0 Then
                    chNO_VIAJE.Checked = False
                Else
                    chNO_VIAJE.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("NO_LIQUI") = 0 Then
                    chNO_LIQUI.Checked = False
                Else
                    chNO_LIQUI.Checked = True
                End If
                'NUEVAS
                If dr.ReadNullAsEmptyInteger("HORAS_GEN1") = 0 Then
                    ChHorasGen1.Checked = False
                Else
                    ChHorasGen1.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("HORAS_GEN2") = 0 Then
                    ChHorasGen2.Checked = False
                Else
                    ChHorasGen2.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("HORAS_USO1") = 0 Then
                    ChHorasUso1.Checked = False
                Else
                    ChHorasUso1.Checked = True
                End If
                '2
                If dr.ReadNullAsEmptyInteger("HORAS_GEN3") = 0 Then
                    ChHorasGen3.Checked = False
                Else
                    ChHorasGen3.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("HORAS_GEN4") = 0 Then
                    ChHorasGen4.Checked = False
                Else
                    ChHorasGen4.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("HORAS_USO1") = 0 Then
                    ChHorasUso2.Checked = False
                Else
                    ChHorasUso2.Checked = True
                End If

                'nuevos
                If dr.ReadNullAsEmptyInteger("LTS_GEN2") = 0 Then
                    ChLtsGen2.Checked = False
                Else
                    ChLtsGen2.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("NUM_VIAJES_FULL") = 0 Then
                    ChNumViajesFull.Checked = False
                Else
                    ChNumViajesFull.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("NUM_VIAJES_SENC") = 0 Then
                    ChNumViajesSenc.Checked = False
                Else
                    ChNumViajesSenc.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("RPM_MAXIMA") = 0 Then
                    ChRPMMaxima.Checked = False
                Else
                    ChRPMMaxima.Checked = True
                End If
                '********************************
                'nuevos
                If dr.ReadNullAsEmptyInteger("NUMGEN1") = 0 Then
                    ChNumGen1.Checked = False
                Else
                    ChNumGen1.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("NUMGEN2") = 0 Then
                    ChNumGen2.Checked = False
                Else
                    ChNumGen2.Checked = True
                End If
                If dr.ReadNullAsEmptyInteger("LTSDESCGEN") = 0 Then
                    ChLtsDescGen.Checked = False
                Else
                    ChLtsDescGen.Checked = True
                End If
                'Fin nuevos



                TEXCEL.Text = dr.ReadNullAsEmptyString("RUTA_EXCEL")

                If dr.ReadNullAsEmptyInteger("EXPORTAR_COMO_CSV") = 1 Then
                    ChExportarComoCSV.Checked = True
                Else
                    ChExportarComoCSV.Checked = False
                End If
                If dr.ReadNullAsEmptyInteger("RUTA_X_USUARIO") = 1 Then
                    ChRutaXUsuario.Checked = True
                    BtnAsignarRutaUsuarios.Visible = True
                Else
                    ChRutaXUsuario.Checked = False
                End If
            Else
                TRUTA_DOC.Text = ""
                TRUTA_IMAGEN.Text = ""
                TRUTA_MODELO.Text = ""
                TRUTA_FORMATOS.Text = ""
                TRUTA_XML.Text = ""
                cboOT.SelectedIndex = 0
                cboOTE.SelectedIndex = 0
                TIPO_MEDICION_COMBUSTIBLE = 0

            End If
            dr.Close()

        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Try

            TIPO_OTI = cboOTE.SelectedIndex
            TIPO_MEDICION_COMBUSTIBLE = cboNivelCombustible.SelectedIndex
            If TIPO_MEDICION_COMBUSTIBLE = -1 Then TIPO_MEDICION_COMBUSTIBLE = 0

            If CboBAJA_VIAJE_FACTURACION.SelectedIndex = 0 Then
                MainRibbonForm.BarBajaViajes.Text = "Baja de Viajes"
            Else
                MainRibbonForm.BarBajaViajes.Text = "Facturación viajes"
            End If

            SQL = "UPDATE GCPARAMGENERALES SET RUTA_DOC = '" & TRUTA_DOC.Text & "', RUTA_IMAGEN = '" & TRUTA_IMAGEN.Text & "', 
                  RUTA_MODELO = '" & TRUTA_MODELO.Text & "', 
                  RUTA_FORMATOS = '" & TRUTA_FORMATOS.Text & "', TIPO_OTI = " & cboOT.SelectedIndex & ", TIPO_OTE = " & TIPO_OTI & ", 
                  TIPO_MEDICION_COMBUSTIBLE = " & TIPO_MEDICION_COMBUSTIBLE & ", RUTA_XML = '" & TRUTA_XML.Text & "', 
                  DESCUENTO = " & IIf(chDescuento.Checked, 1, 0) & ", CALIFICACION = " & IIf(chCalificacion.Checked, 1, 0) & ", 
                  VELOCIDADMAXIMA = " & IIf(chVelocidadMaxima.Checked, 1, 0) & ", TIEMPOMARCHAINERCIA = " & IIf(chTiempoMarchaInercia.Checked, 1, 0) & ", 
                  LITROSDESCONTAR = " & IIf(chLitrosDescontar.Checked, 1, 0) & ", PRECIOXLITRO = " & IIf(chPrecioXLitro.Checked, 1, 0) & ", 
                  DESCXLITRO = " & IIf(chDescXLitro.Checked, 1, 0) & ", LTSAUTORIZ = " & IIf(chLtsAutoriz.Checked, 1, 0) & ", 
                  LTSUREA = " & IIf(chLtsUREA.Checked, 1, 0) & ", LTSUREA_REAL = " & IIf(chLtsUreaReal.Checked, 1, 0) & ", 
                  CARGOXPUNTOMUERTO = " & IIf(chCargoXPuntoMuerto.Checked, 1, 0) & ", NO_VIAJE = " & IIf(chNO_VIAJE.Checked, 1, 0) & ",
                  NO_LIQUI = " & IIf(chNO_LIQUI.Checked, 1, 0) & ", HORAS_GEN1 = " & IIf(ChHorasGen1.Checked, 1, 0) & ", 
                  HORAS_GEN2 = " & IIf(ChHorasGen2.Checked, 1, 0) & ", HORAS_USO1 = " & IIf(ChHorasUso1.Checked, 1, 0) & ", 
                  HORAS_GEN3 = " & IIf(ChHorasGen3.Checked, 1, 0) & ", HORAS_GEN4 = " & IIf(ChHorasGen4.Checked, 1, 0) & ", 
                  HORAS_USO2 = " & IIf(ChHorasUso2.Checked, 1, 0) & ", TIPO_TAB = " & CboTabRutas.SelectedIndex & ", TIPO_LLANTAS = " & CboLlantas.SelectedIndex & ", 
                  LTS_GEN2 = " & IIf(ChLtsGen2.Checked, 1, 0) & ", NUM_VIAJES_FULL = " & IIf(ChNumViajesFull.Checked, 1, 0) & ", 
                  NUM_VIAJES_SENC = " & IIf(ChNumViajesSenc.Checked, 1, 0) & ", RPM_MAXIMA = " & IIf(ChRPMMaxima.Checked, 1, 0) & ", 
                  NUMGEN1 = " & IIf(ChNumGen1.Checked, 1, 0) & ", NUMGEN2 = " & IIf(ChNumGen2.Checked, 1, 0) & ", 
                  LTSDESCGEN = " & IIf(ChLtsDescGen.Checked, 1, 0) & ", RUTA_EXCEL = '" & TEXCEL.Text & "', 
                  EXPORTAR_COMO_CSV = " & IIf(ChExportarComoCSV.Checked, 1, 0) & ", RUTA_X_USUARIO = " & IIf(ChRutaXUsuario.Checked, 1, 0) & ",
                  CAT_RUTAS = " & CboCatRutas.SelectedIndex & ", ASIG_VIAJES = " & CBOASIG_VIAJE.SelectedIndex & ", 
                  BAJA_VIAJE_FACTURACION = " & CboBAJA_VIAJE_FACTURACION.SelectedIndex

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery()
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using


            SQL = "WITH CONF AS   (
                SELECT EMPRESA, ROW_NUMBER() OVER (PARTITION BY EMPRESA ORDER BY EMPRESA) AS Row_Number
                FROM CONFIG)
                DELETE FROM CONF WHERE Row_Number <> 1;"
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery()
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using

            SQL = "IF EXISTS (SELECT EMPRESA FROM CONFIG WHERE EMPRESA = '" & Empresa & "')
                UPDATE CONFIG SET RUTA_FOTOS = '" & TRUTA_FOTOS.Text & "', RUTA_HUELLAS = '" & TRUTA_HUELLAS.Text & "', 
                UTILIZAR_LECTOR_HUELLA = " & IIf(ChUtilizarHuella.Checked, 1, 0) & " WHERE EMPRESA = '" & Empresa & "'
                ELSE
                INSERT INTO CONFIG (EMPRESA, RUTA_FOTOS, RUTA_HUELLAS, UTILIZAR_LECTOR_HUELLA) VALUES ('" &
                Empresa & "','" & TRUTA_FOTOS.Text & "','" & TRUTA_HUELLAS.Text & "','" & IIf(ChUtilizarHuella.Checked, 1, 0) & "')"

            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery()
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using

            MsgBox("Los datos se grabaron correctamente")
            Me.Close()
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmParamGenerales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab2("Parámetros generales")
    End Sub
    Private Sub BtnDoc_Click(sender As Object, e As EventArgs) Handles BtnDoc.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_DOC.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnImagen.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_IMAGEN.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub BtnModelo_Click(sender As Object, e As EventArgs) Handles BtnModelo.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_MODELO.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub BtnFormatos_Click(sender As Object, e As EventArgs) Handles BtnFormatos.Click
        FolderBrowserDialog1.SelectedPath = Application.StartupPath
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_FORMATOS.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub BtnXmlCompras_Click_1(sender As Object, e As EventArgs) Handles BtnXmlCompras.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_XML.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        FolderBrowserDialog1.SelectedPath = Application.StartupPath
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TEXCEL.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub BtnAsignarRutaUsuarios_Click(sender As Object, e As EventArgs) Handles BtnAsignarRutaUsuarios.Click
        Try
            FrmRutasExcelXUsuario.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ChRutaXUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles ChRutaXUsuario.CheckedChanged
        Try
            If ChRutaXUsuario.Checked Then
                BtnAsignarRutaUsuarios.Visible = True
            Else
                BtnAsignarRutaUsuarios.Visible = False
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnHuellas_Click(sender As Object, e As EventArgs) Handles BtnHuellas.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_HUELLAS.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub BtnFotos_Click_1(sender As Object, e As EventArgs) Handles BtnFotos.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_FOTOS.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub


End Class
