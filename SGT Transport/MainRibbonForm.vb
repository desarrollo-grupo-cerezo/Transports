Imports System.ServiceProcess
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Globalization
Imports System.Threading
Imports C1.Win.C1Command

Public Class MainRibbonForm
    Private BAJA_VIAJE_FACT As Integer = 0
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
    Private Sub MainRibbonForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim current As CultureInfo = CultureInfo.CurrentCulture
            Dim currentUi As CultureInfo = CultureInfo.CurrentUICulture

            If current.Name <> "es-MX" Then
                Dim ci As CultureInfo
                ci = New CultureInfo("es-MX")
                CultureInfo.DefaultThreadCurrentCulture = ci

                Dim cinfo As CultureInfo = Thread.CurrentThread.CurrentCulture.Clone()
                cinfo.NumberFormat.NumberDecimalSeparator = "."
                cinfo.NumberFormat.CurrencyDecimalSeparator = "."
                cinfo.NumberFormat.CurrencyDecimalDigits = 6
                Thread.CurrentThread.CurrentCulture = cinfo
            End If

            ThemeElekos = "Office2010Blue"
            ThemeElekos2 = "VS2013Blue"


            Dim LData As String = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiIHN0YW5kYWxvbmU9InllcyI/Pgo8TGljZW5zZSBLZXk9ImNyOERaN1hKMkR5MUs2UUJBTkRPSVRLdlpjTzZkelVod2lsSHBnVlluQ3k0cXlHV2V6TFZubFJGeFAxNU1mSWZnUmdNWm1XaEdOQWRFNFRqZWZnQ1ovbFR2b1BkSXRIbDZXdDVBNWk1TVhFbnFkQnVPMUthRnovRFFzYUdWTGhzdjlySG1ybnRxSElFRGxJeGRxYUpNcGtLb0Frd1A3d1N6T01KMVkrbUNmVTVVRmV6REwvTjd1enJ4M0Y0d2I1SGErd0E2VFQ5VFJ3SzAzejlFS01aRmwzU1lSL3o0YVU3TE0wZFNYWTlqU0ZKZ2dqZlZzRFVLaUJyVm5td1ljaXVyOUVrYmw5Q3RaWTAzdG1yZm01QlplKzZnaHRFTm4wb2gzMzh0WlJleWpjcjc0QWs3MWhnWWtuTE9CQzE1VllmalhzcXVBVW13MlI2TWNWMlBPT2JyY1RSYlhBZ3pvUWJPeWQ4U2JFWmN3aE43NktQd1dzUVFTMUowdGlZSFVLeE9tMnQ0ZkJWMGhQVmhhOUI4Y0swNHFKUVp0MDBaMWNKRGEwd2I4VWx6RWs5QkhVVzJlbk9mVDE0UnlIQ2krWUdlbVBLY2RDUXJoMXpyWVRGN0ltb0x4N3h1NGV2RFRZc2xzV0JrbFFJb3g4NnJWckVVa1N0dXErQUNTWS9xVTM5L1Zhd3Y5S0FmUjVUZUVicGt3RGhTYjBOQkFqVDhBeXRsRFZkR2ZpZzBxS0czVllpVHBYRnc1cHRMVmgrYmtkK2RnN3Z4dHZyNDVaVVdKZXlyekdOR0g3YUZZZDZwLzJNRy9YSlRsR3ovU05RbzJDUExraU83SlhuOU5HZXhaN3BIbTBkZ3pNWmJHRVhxVmR2bG04MTJhL1hMMVNxeEdVWStvNVpsVUM3WTV4Z2dhRCtGZVA5enpoeUpxSUVwcDk3My9ScTRteG1wQWZMcVNzTzJSeHlTcStpdjFDc3AwQ3JvMDc4OEhybDFteWt4dVQweWRSWVpDNkRTeDhNMi9MWTNkOXNud3U3NkFmYjVDOVF1ZE9Zc0wzREh2aGZncmNVSWUvcUhmVFo5QWF6Y3pUanlyM2RPQkFjczBLZk12Y0xVUzRSeHZDdW1NNDVyNDJnMXJ3UGluN2JBcmYvZnNMTzZtS3g0WWRoSURNWlF6V3RjbkhFSTF5TXJ6aU9pdXhMdE8xalRBV25uU2VLVDJ0cXI3Tm42Qmg5TURHNjZZK2lJaW4xV05TUCtMdDFYdXRkajNKTyt4b1FNUVB5ZFpoZkJYZXpVMEhRMnd0eEdwdzRNczRTMTVJbFg1TEdXR3dXeUdYTWNjVWd3b1RDeFRGYmgyZFo0Vkg3OVZHTEVFR1JRWEZrNTRBdlFLdFBpdUcxY0w4RFo3WEoyRHkxSzZUUWVORE9YeFl2NFNveitCMHNBS0VwTVRrNCtTYWpYNksrSjlUOFhZVXRTOE8wWWZGUFZqZkhIYTZORWQyODdVcUlqMnJnQlF1bjVDV3hCczFHUm5BYmd1Z3MyL2ZQakcwZmdQemdSYzR5Q3ZObFg4V2pKUnloc3U5VFRKTjd1R3NOdnprU2IyZWlyQmhEaG1vQ0Jqa0wyYnMzT3I2d2pnNnBUNVpmNGhEdDF0STBJNXo1aytxQXVSZnRhd1lmamhXYmpMS0xKOTlUVk1kRDZaTCtTenNtQkNWN05lYm96V0RUTWgrRnJPT292R09ZbUk1bWp4Smd1MVRXNnI1V0JUK2oxSjBFNmJIb2tEMWo0Wm1DWUQreVBPUW1PMm1yUTNGdC9jVmZwQWlJdzliRkgwZ1FIbXQ4QnNuZnQ2MVV3c1h6cSs2akNvY1hOOUMvRXZPblhTczZuVlNGSkVBL3l1QmNIazZxOWdqanBnRG1NTEcrNlpxR1VjRWMzZEp2THpuK3pNT0p3TDI4WUQxN3BLSXBUNnd6WFBFVFJwWS9qNHhoMkQvaFhJRVNHcTk1eTVmZE9MNmx1QT09IiBWZXJzaW9uPSI5LjkiPgogICAgPFR5cGU+UnVudGltZTwvVHlwZT4KICAgIDxVc2VybmFtZT5Vc2VyTmFtZTwvVXNlcm5hbWU+CiAgICA8RW1haWw+ZU1haWxAaG9zdC5jb208L0VtYWlsPgogICAgPE9yZ2FuaXphdGlvbj5Pcmdhbml6YXRpb248L09yZ2FuaXphdGlvbj4KICAgIDxMaWNlbnNlZERhdGU+MjAxNi0wMS0wMVQxMjowMDowMFo8L0xpY2Vuc2VkRGF0ZT4KICAgIDxFeHBpcmVkRGF0ZT4yMDk5LTEyLTMxVDEyOjAwOjAwWjwvRXhwaXJlZERhdGU+CiAgICA8UHJvZHVjdHM+CiAgICAgICAgPFByb2R1Y3Q+CiAgICAgICAgICAgIDxOYW1lPlNwaXJlLk9mZmljZSBQbGF0aW51bTwvTmFtZT4KICAgICAgICAgICAgPFZlcnNpb24+OS45OTwvVmVyc2lvbj4KICAgICAgICAgICAgPFN1YnNjcmlwdGlvbj4KICAgICAgICAgICAgICAgIDxOdW1iZXJPZlBlcm1pdHRlZERldmVsb3Blcj45OTk5OTwvTnVtYmVyT2ZQZXJtaXR0ZWREZXZlbG9wZXI+CiAgICAgICAgICAgICAgICA8TnVtYmVyT2ZQZXJtaXR0ZWRTaXRlPjk5OTk5PC9OdW1iZXJPZlBlcm1pdHRlZFNpdGU+CiAgICAgICAgICAgIDwvU3Vic2NyaXB0aW9uPgogICAgICAgIDwvUHJvZHVjdD4KICAgIDwvUHJvZHVjdHM+CiAgICA8SXNzdWVyPgogICAgICAgIDxOYW1lPklzc3VlcjwvTmFtZT4KICAgICAgICA8RW1haWw+aXNzdWVyQGlzc3Vlci5jb208L0VtYWlsPgogICAgICAgIDxVcmw+aHR0cDovL3d3dy5pc3N1ZXIuY29tPC9Vcmw+CiAgICA8L0lzc3Vlcj4KPC9MaWNlbnNlPg=="
            Spire.License.LicenseProvider.SetLicenseKey(LData)

        Catch ex As Exception
            Bitacora("1. " & ex.Message & ex.StackTrace)
            MsgBox("1. " & ex.Message & ex.StackTrace)
        End Try
        Try
            If Not IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory & "\transcg.s3db") Then
                Createdatabase()
            End If
            'Dim FilePath As String = AppDomain.CurrentDomain.BaseDirectory & "\transcg.s3db"
            'Dim UserAccount As String = "Everyone"
            'Dim FileInfo As New IO.FileInfo(FilePath)
            'Dim FileAcl As New FileSecurity
            'FileAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Modify, AccessControlType.Allow))
            '            FolderAcl.SetAccessRuleProtection(True, False) 'uncomment to remove existing permissions
            'FileInfo.SetAccessControl(FileAcl)
            Dim connection As String = "Data Source=" & AppDomain.CurrentDomain.BaseDirectory & "\transcg.s3db;"
            'Dim connection As String = "Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86) & "\cerezo\transcg.s3db;" &
            '    "Version=3;Mode=ReadWrite;New=True;Compress=True;Journal Mode=Off;"
            'MsgBox(connection)

            SQLConn = New SQLiteConnection(connection, True)
            SQLConn.Open()

            Dim cmd As New SQLiteCommand(SQLConn)
            Dim dr As SQLiteDataReader
            Dim Existe As Boolean

            AgregaCampo()

            Servidor_SAROCE = ""
            Base_SAROCE = ""
            Usuario_SAROCE = ""
            Pass_SAROCE = ""

            cmd.CommandText = "SELECT ifnull(servidor_sar,'') as server, ifnull(base_sar,'') as db, ifnull(usuario_sar,'') as userio, 
                ifnull(pass_sar,'') as pasw
                FROM config"
            dr = cmd.ExecuteReader
            Existe = False
            If dr.Read Then
                Servidor_SAROCE = dr("server").ToString
                Base_SAROCE = dr("db").ToString
                Usuario_SAROCE = dr("userio").ToString
                Pass_SAROCE = dr("pasw").ToString
                Existe = True
            End If
            dr.Close()

            If Not Existe Then
                SQL = "INSERT INTO config (servidor_sar, base_sar, usuario_sar, pass_sar) VALUES ('(LOCAL)\SQLEXPRESS ','GCGRUPOCE','sa','1234')"
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
        'VERIFICA SI ESTA CORRIENDO EL SERVICIO SQL SI NO LO ARRANCA
        StartStop()

        Try
            Connect = ""
            If Not OpenSAROCE(Servidor_SAROCE, Base_SAROCE, Usuario_SAROCE, Pass_SAROCE) Then
                FrmSAROCE.ShowDialog()
                If Connect = "No" Then
                    End
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If PASS_GRUPOCE.ToUpper <> "BR3FRAJA" And PASS_GRUPOCE.ToUpper <> "BUS" And Servidor_SAROCE <> "LAP-GS\SQLDEV" Then
                If Not ValidarLicencia() Then
                    MsgBox("La licencia ha expirado si desea comprar el sistema de transporte TransportCG favor de comunicarse a " & vbNewLine &
                                "martin@grupo-cerezo.com, gustavo@grupo-cerezo.com, c.cerezo@grupo-cerezo.com" & vbNewLine & "Serial: " & GET_ID())
                    End
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("2. FORM LOAD ValidarLicencia: " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            StbtnServidor.Text = Servidor
            StbtnBase.Text = Base
            StUsuario.Text = USER_GRUPOCE
            'StVersion.Text = "Versión 4.0"
            StVersion.Text = String.Format("Versión {0}.{1}.{2}", System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Major, System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Minor, System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Build)
            StSerieLic.Text = "Serial:" & GET_ID()
            'StLic.Text = LicStatus
            If RunningAsAdmin() Then
                StUserWindows.Text = "Windows Administrador"
            Else
                StUserWindows.Text = ""
            End If
            StLicencia.Text = LicStatus

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            BarActivos.Visible = False
            BarAseguradoras.Visible = False
            BarInventario.Visible = False
            RibbListaPrecios.Visible = False

            RibPePeTesoreria.Visible = False
            RibTesGastos.Visible = False
            RibTesCuentasBancarias.Visible = False
            RibTesBeneficiariosBancarios.Visible = False

            BarPrecios1.Visible = False
            BarImpuestos1.Visible = False
            BarConcMinve1.Visible = False
            BarAlmacenes1.Visible = False
            BarMultialmacen1.Visible = False
            BarLineasProductos2.Visible = False
            BarUniMed1.Visible = False
            'BarMovsInvOT.Visible = false
            Connect = ""

            Dim f As New FrmSelEmpresa With {.MdiParent = Me.Owner, .TopLevel = True, .TopMost = True}

            f.ShowDialog()

            If Connect = "No" Then

                Closo_Form_Open(FrmEmpresas)

                Var2 = "Con Border"
                FrmEmpresas.ShowDialog()
            End If

            If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                TabInvRefac.Text = "REFACCIONES (GCINVER - GCMINVER01)"
                'TabInvActFijo.Text = "ACTIVO FIJO (GCIFIJO)"
            End If

            Try
                StbtnServidor.Text = Servidor
                StbtnBase.Text = Base
                StEmpresa.Text = "Empresa: " & Empresa
                StUsuario.Text = USER_GRUPOCE
                'Text = RazonSocial
                'StVersion.Text = "Versión 4.0"
                StVersion.Text = String.Format("Versión {0}.{1}.{2}", System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Major, System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Minor, System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Build)
                'StLic.Text = LicStatus
                ASIGNAR_DERECHOS()
            Catch ex As Exception
            End Try

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(BAJA_VIAJE_FACTURACION,0) AS BAJA_VIAJE_FACT
                        FROM GCPARAMGENERALES"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            BAJA_VIAJE_FACT = dr("BAJA_VIAJE_FACT")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If BAJA_VIAJE_FACT = 1 Then
                BarBajaViajes.Text = "Facturación viajes"
            End If
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub MainRibbonForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.BringToFront()
        Me.Show()
    End Sub
    Private Sub MainRibbonForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If MsgBox("Realmente desea salir?", vbYesNo) = vbYes Then
            e.Cancel = False
            Try
                My.Application.OpenForms.Cast(Of Form)().Except({Me}).ToList().ForEach(Sub(form) form.Close())
            Catch ex As Exception
            End Try
            Try
                cnSAE = Nothing
                cnSQL = Nothing
            Catch ex As Exception
            End Try
        Else
            e.Cancel = True
        End If
    End Sub
    Sub ASIGNAR_DERECHOS()
        Dim w1 As Integer = 0, w2 As Integer = 0

        If PASS_GRUPOCE.ToString.ToUpper = "BUS" Or PASS_GRUPOCE.ToUpper = "WINAS" Or
            PASS_GRUPOCE.ToUpper = "BR3FRAJA" Or PASS_GRUPOCE.ToUpper = "258036" Then

            'BarCFDICartaPorte.Visible = True
            BarTabRutasFlex.Visible = True
            BarLicenciamientoMobulos.Visible = True

            'ELENKOS
            BarActivos.Visible = True
            RibTipoActivos.Visible = True
            BarAseguradoras.Visible = True
            BarInventario.Visible = True
            RibbListaPrecios.Visible = True

            RibPePeTesoreria.Visible = True
            RibTesGastos.Visible = True
            RibTesCuentasBancarias.Visible = True
            RibTesBeneficiariosBancarios.Visible = True

            BarPrecios1.Visible = True
            BarImpuestos1.Visible = True
            BarConcMinve1.Visible = True
            BarAlmacenes1.Visible = True
            BarMultialmacen1.Visible = True
            BarLineasProductos2.Visible = True
            BarUniMed1.Visible = True
            BarMovsInvOT.Visible = True
        Else
            'BarCFDICartaPorte.Visible = False
            BarTabRutasFlex.Visible = False
            BarLicenciamientoMobulos.Visible = False

            'ELENKOS
            BarActivos.Visible = False
            RibTipoActivos.Visible = False
            BarAseguradoras.Visible = False
            BarInventario.Visible = False
            RibbListaPrecios.Visible = False

            RibPePeTesoreria.Visible = False
            RibTesGastos.Visible = False
            RibTesCuentasBancarias.Visible = False
            RibTesBeneficiariosBancarios.Visible = False

            BarPrecios1.Visible = False
            BarImpuestos1.Visible = False
            BarConcMinve1.Visible = False
            BarAlmacenes1.Visible = False
            BarMultialmacen1.Visible = False
            BarLineasProductos2.Visible = False
            BarUniMed1.Visible = False
        End If

        If pwPoder Then
            'ADMINISTRADOR
            TabCatalogos.Visible = True
            TabViajes.Visible = True
            TabTesoreria.Visible = True
            TabFacturacion.Visible = True
            TabLiquidacion.Visible = True
            TabVentas.Visible = True
            TabCompras.Visible = True
            TabControlCombus.Visible = True
            TabMante.Visible = True
            TabInventario.Visible = True
            TabConta.Visible = True
            TabRecHum.Visible = True
            TabLocalizacion.Visible = True
            TabRep.Visible = True
            TabMnuProv.Visible = True
            BarAseguradoras.Visible = True
            RibTarjetaIAVE.Visible = True


            BarContratos.Visible = True
            BarProdCargar.Visible = True
            BarTrafico.Visible = True
            TabMnuEmpleados.Visible = True
            TabMnuCat.Visible = True

            BarCatStatusUnidades.Visible = True
            BarCatStatusViaje.Visible = True
            BarStatusUnidades.Visible = True
            BarTabRutas.Visible = True
            BarAsignacionViajes.Visible = True
            BarCartaPorte.Visible = True
            BarAutoriza.Visible = True
            BarCasetasXRuta.Visible = True

            BarBajaViajes.Visible = True

            TabMnuComercial.Visible = True       'ADMINISTRADOR
            'NUEVOS DIC 4
            BarConciliacionValesCombus.Visible = True

            BarConcilCartaPorte.Visible = True
            BarCxC.Visible = True
            BarListaprecios.Visible = True
            BarProveedores5.Visible = True
            BarDiesel1.Visible = True

            BarCotizaciones.Visible = True
            BarRemisiones.Visible = True
            BarRemisionCartaPorte.Visible = True

            'TESORERIA
            TabTesoreria.Visible = True
            BarTesoreria.Visible = True
            BarDeducOper.Visible = True

            'LIQUIDACION
            TabLiquidacion.Visible = True
            BarLiquidaciones.Visible = True
            BarConsignacion2.Visible = True

            'COMPRAS             COMPRAS             COMPRAS             COMPRAS             COMPRAS             
            BarCompras.Visible = True
            BarRecepciones.Visible = True
            BarOrdenDeCompras.Visible = True
            BarRequisiciones.Visible = True
            RibbonMenu2.Visible = True

            'CONTROL DE COMBUSTIBLE
            BarNivelCombustible.Visible = True
            BarMedicionCombustible.Visible = True
            BarReset.Visible = True
            BarTabuladorCombustible.Visible = True       'ADMINISTRADOR

            BarCatTanques.Visible = True
            BarIndicadorDepto.Visible = True
            BarCatEvaluaciones.Visible = True
            BarCriteriosEva.Visible = True
            BarAsignacionDiesel.Visible = True


            'MANTENIMIENTO
            TabMnuLlantas.Visible = True
            MnuLlantas.Visible = True
            MnuMarcasLlantas.Visible = True
            MnuTipoLlantas.Visible = True
            MnuEstatusLlantas.Visible = True
            MnuModeloLlantas.Visible = True
            MnuMedidaLlantas.Visible = True
            BarLlantasAct.Visible = True
            BarLlantasMante.Visible = True
            BarClasificServicios.Visible = True
            BarReporteLLantas.Visible = True
            BarPrograServicios.Visible = True
            BarOrdenesDeTrabajoExternas.Visible = True
            BarOrdenDeTrabajoManto.Visible = True
            BarMenuReportes.Visible = True

            'INVENTARIO
            BarServiciosDeInventario.Visible = True
            'BarMovsInvOT.Visible = True
            BarMinveTOT.Visible = True
            BarConcMinve.Visible = True
            BarAlmacenes.Visible = True
            BarMultialmacen.Visible = True
            BarLineasProductos.Visible = True
            BarUniMed.Visible = True     'ADMINISTRADOR      ADMINISTRADOR      ADMINISTRADOR      


            'CONTABILIDAD
            'barPolizaDeTrafico.Visible = True
            'RibPolizasManteInterno.Visible = True
            'barPolizaDeInven.Visible = True
            'barPolizaDeVentas.Visible = True
            BarPolizaDeCompras.Visible = True
            'RECURSOS HUMANOS
            BarEmpleados.Visible = True
            BarEmpleados1.Visible = True
            BarPrestamosPersonales.Visible = True
            BarPrestamosInfonavit.Visible = True
            'LOCALIZACION
            BarEstados.Visible = True
            BarLocalidades.Visible = True
            BarWebServices.Visible = True
            BarPuntosInteres.Visible = True
            'CONFIGURACION
            BarEmpresas.Visible = True
            BarDerechosUsuarios.Visible = True
            BarUsuarios.Visible = True
            BarParamSistema.Visible = True
            BarBitacoraUsuarios.Visible = True
            BarGRUPOCE.Visible = True
            BarDisenador.Visible = True     'ADMINISTRADOR      ADMINISTRADOR      ADMINISTRADOR      
            'CATALOGOS
            MnuClientes.Visible = True
            MnuConcCxC.Visible = True
            MnuContratos.Visible = True
            MnuAltaCxC.Visible = True
            MnuEdoCuenta.Visible = True     'ADMINISTRADOR      ADMINISTRADOR      ADMINISTRADOR      
            MnuProveedores.Visible = True
            MnuCxP.Visible = True
            MnuContacProv.Visible = True
            MnuAltaCxP.Visible = True
            MnuConcGastos.Visible = True
            MnuRutas.Visible = True
            MnuUnidades.Visible = True
            MnuMarcasUnidades.Visible = True
            MnuTiposUnidades.Visible = True
            MnuModelosUnidades.Visible = True
            MnuGrupoUnidades.Visible = True
            MnuInstrucViajes.Visible = True
            MnuCombustible.Visible = True
            MnuGasolineras.Visible = True
            MnuTramosOficiales.Visible = True
            MnuValorDeclarado.Visible = True
            MnuPlazas.Visible = True
            MnuClientesOperativos.Visible = True
            MnuStGastosViaje.Visible = True
            MnuStCartaPorte.Visible = True
            MnuStLiquidacion.Visible = True
            MnuStValeCombustible.Visible = True
            MnuOperadores.Visible = True
            MnuDescOperador.Visible = True     'ADMINISTRADOR      ADMINISTRADOR      ADMINISTRADOR      
            MnuTipoDesc.Visible = True
            MnuTipoDesc.Visible = True
            MnuTipoJornada1.Visible = True
            MnuPeriodicidadPago1.Visible = True
            MnuRiesgoTrabajo1.Visible = True
            MnuIncidencias1.Visible = True
            MnuFormasPagoEmpleados.Visible = True
            MnuMecanicos.Visible = True

            MnuPedidos.Visible = True
            MnuCotizador.Visible = True

            TabMnuLlantas.Visible = True
            MnuLlantas.Visible = True
            MnuMarcasLlantas.Visible = True     'ADMINISTRADOR      ADMINISTRADOR      ADMINISTRADOR      
            MnuTipoLlantas.Visible = True
            MnuEstatusLlantas.Visible = True
            MnuModeloLlantas.Visible = True
            MnuMedidaLlantas.Visible = True
            BarLlantasAct.Visible = True
            BarLlantasMante.Visible = True
            BarClasificServicios.Visible = True
            BarReporteLLantas.Visible = True
            BarPrograServicios.Visible = True

            TabConfig.Visible = True
            TabUtilerias.Visible = True
            MnuClientes.Visible = True
            MnuConcCxC.Visible = True
            MnuContratos.Visible = True
            MnuAltaCxC.Visible = True
            MnuEdoCuenta.Visible = True
            MnuProveedores.Visible = True
            MnuCxP.Visible = True
            MnuContacProv.Visible = True
            MnuAltaCxP.Visible = True
            MnuConcGastos.Visible = True     'ADMINISTRADOR      ADMINISTRADOR      ADMINISTRADOR      
            MnuRutas.Visible = True
            MnuUnidades.Visible = True
            MnuMarcasUnidades.Visible = True
            MnuTiposUnidades.Visible = True
            MnuModelosUnidades.Visible = True
            MnuGrupoUnidades.Visible = True
            MnuInstrucViajes.Visible = True
            MnuCombustible.Visible = True
            MnuGasolineras.Visible = True
            MnuTramosOficiales.Visible = True
            MnuValorDeclarado.Visible = True
            MnuPlazas.Visible = True
            MnuClientesOperativos.Visible = True
            MnuStGastosViaje.Visible = True
            MnuStCartaPorte.Visible = True
            MnuStLiquidacion.Visible = True
            MnuStValeCombustible.Visible = True
            MnuOperadores.Visible = True
            MnuDescOperador.Visible = True
            MnuTipoDesc.Visible = True
            MnuTipoDesc.Visible = True
            MnuTipoJornada1.Visible = True
            MnuPeriodicidadPago1.Visible = True
            MnuRiesgoTrabajo1.Visible = True
            MnuIncidencias1.Visible = True
            MnuFormasPagoEmpleados.Visible = True
            MnuMecanicos.Visible = True
            MnuMotores.Visible = True
            MnuCasetas.Visible = True
            MNUActPrecios.Visible = True

            'ADMINISTRADOR      ADMINISTRADOR      ADMINISTRADOR      
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE UPPER(USUARIO) = '" & USER_GRUPOCE & "' AND CLAVE = 23620"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 23620  'CARTA PORTE LV
                                    'BarCFDICartaPorte.Visible = True
                                Case 14520
                                    BarTabRutasFlex.Visible = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            End Try
            BarTabRutasFlex.Visible = True
        Else
            BarLicenciamientoMobulos.Visible = False
            '========================================================================================================================
            'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
            '========================================================================================================================
            Try
                '--------- CATALOGOS

                TabCatalogos.Visible = False
                'CLIENTES
                TabMnuClientes.Visible = False
                MnuClientes.Visible = False
                MnuConcCxC.Visible = False
                MnuContratos.Visible = False
                MnuAltaCxC.Visible = False
                MnuEdoCuenta.Visible = False
                'PROVEEDORES
                TabMnuProv.Visible = False
                MnuProveedores.Visible = False
                MnuCxP.Visible = False
                MnuContacProv.Visible = False
                MnuAltaCxP.Visible = False
                '---------------			
                BarAseguradoras.Visible = False
                RibTarjetaIAVE.Visible = False

                '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘

                'ELENKOS
                'RibSep5.Visible = False
                'RibSep6.Visible = False

                BarActivos.Visible = False
                RibTipoActivos.Visible = False
                BarInventario.Visible = False
                RibbListaPrecios.Visible = False

                RibPePeTesoreria.Visible = False
                RibTesGastos.Visible = False
                RibTesCuentasBancarias.Visible = False
                RibTesBeneficiariosBancarios.Visible = False



                '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘

                BarContratos.Visible = False
                BarProdCargar.Visible = False
                BarTrafico.Visible = False
                'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                'TRAFICO
                MnuConcGastos.Visible = False
                MnuRutas.Visible = False
                MnuUnidades.Visible = False
                MnuMarcasUnidades.Visible = False
                MnuTiposUnidades.Visible = False
                MnuModelosUnidades.Visible = False
                MnuGrupoUnidades.Visible = False
                MnuInstrucViajes.Visible = False
                MnuCombustible.Visible = False
                MnuGasolineras.Visible = False
                MnuTramosOficiales.Visible = False
                MnuValorDeclarado.Visible = False
                MnuPlazas.Visible = False
                MnuClientesOperativos.Visible = False
                MnuStGastosViaje.Visible = False
                MnuStCartaPorte.Visible = False
                MnuStLiquidacion.Visible = False
                MnuStValeCombustible.Visible = False
                BarRecogerEnEntregarEn.Visible = False
                MnuMotores.Visible = False
                MnuCasetas.Visible = False
                MNUActPrecios.Visible = False
                'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                'EMPLEADOS
                TabMnuEmpleados.Visible = False
                MnuOperadores.Visible = False
                MnuDescOperador.Visible = False
                MnuTipoDesc.Visible = False
                MnuTipoDesc.Visible = False
                MnuTipoJornada1.Visible = False
                MnuPeriodicidadPago1.Visible = False
                MnuRiesgoTrabajo1.Visible = False
                MnuIncidencias1.Visible = False
                MnuFormasPagoEmpleados.Visible = False
                MnuMecanicos.Visible = False
                'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                TabMnuCat.Visible = False
                'LOGISTICA
                TabViajes.Visible = False
                BarCatStatusUnidades.Visible = False
                BarCatStatusViaje.Visible = False
                BarStatusUnidades.Visible = False
                '5 OCT. 21
                BarCatStatusOper.Visible = False
                BarStatusOperadores.Visible = False

                BarTabRutas.Visible = False
                BarAsignacionViajes.Visible = False
                BarCartaPorte.Visible = False
                BarAutoriza.Visible = False
                BarCasetasXRuta.Visible = False
                BarBajaViajes.Visible = False
                BarConciliacionValesCombus.Visible = False

                TabMnuComercial.Visible = False
                'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                MnuPedidos.Visible = False
                MnuCotizador.Visible = False
                '-------------------------------------
                'TESORERIA
                TabTesoreria.Visible = False
                BarTesoreria.Visible = False
                BarDeducOper.Visible = False

                'FACTURACION
                TabFacturacion.Visible = False
                BarConcilCartaPorte.Visible = False
                BarCxC.Visible = False
                BarListaprecios.Visible = False
                BarProveedores5.Visible = False
                BarDiesel1.Visible = False
                'LIQUIDACION
                'TabLiquidacion.Visible = False
                'BarLiquidaciones.Visible = False
                'BarConsignacion2.Visible = False
                'VENTAS
                TabVentas.Visible = False
                BarCotizaciones.Visible = False
                BarRemisiones.Visible = False
                BarRemisionCartaPorte.Visible = False
                'COMPRAS
                TabCompras.Visible = False
                BarCompras.Visible = False
                BarRecepciones.Visible = False
                BarOrdenDeCompras.Visible = False
                BarRequisiciones.Visible = False
                RibbonMenu2.Visible = False
                'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                'CONTROL DE COMBUSTIBLE
                TabControlCombus.Visible = False
                BarNivelCombustible.Visible = False
                BarMedicionCombustible.Visible = False
                BarReset.Visible = False
                BarTabuladorCombustible.Visible = False
                BarCatTanques.Visible = False
                BarIndicadorDepto.Visible = False
                BarCatEvaluaciones.Visible = False
                BarCriteriosEva.Visible = False
                BarAsignacionDiesel.Visible = False
                'MANTENIMIENTO
                TabMante.Visible = False
                TabMnuLlantas.Visible = False

                TabMnuLlantas.Visible = False
                MnuLlantas.Visible = False
                MnuMarcasLlantas.Visible = False
                MnuTipoLlantas.Visible = False
                MnuEstatusLlantas.Visible = False
                MnuModeloLlantas.Visible = False
                MnuMedidaLlantas.Visible = False
                BarLlantasAct.Visible = False
                BarLlantasMante.Visible = False
                BarClasificServicios.Visible = False
                BarReporteLLantas.Visible = False
                BarPrograServicios.Visible = False
                BarOrdenesDeTrabajoExternas.Visible = False
                BarOrdenDeTrabajoManto.Visible = False
                BarMenuReportes.Visible = False

                'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                'INVENTARIO
                TabInventario.Visible = False
                BarServiciosDeInventario.Visible = False
                BarMovsInvOT.Visible = False
                BarMinveTOT.Visible = False
                BarConcMinve.Visible = False
                BarAlmacenes.Visible = False
                BarMultialmacen.Visible = False
                BarLineasProductos.Visible = False
                BarUniMed.Visible = False
                'CONTABILIDAD
                TabConta.Visible = False
                'barPolizaDeTrafico.Visible = False
                RibPolizasManteInterno.Visible = False
                'barPolizaDeInven.Visible = False
                'barPolizaDeVentas.Visible = False
                BarPolizaDeCompras.Visible = False
                'RECURSOS HUMANOS
                TabRecHum.Visible = False
                BarEmpleados.Visible = False
                BarEmpleados1.Visible = False
                BarPrestamosPersonales.Visible = False
                BarPrestamosInfonavit.Visible = False
                'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                'LOCALIZACION
                TabLocalizacion.Visible = False
                BarEstados.Visible = False
                BarLocalidades.Visible = False
                BarWebServices.Visible = False
                BarPuntosInteres.Visible = False
                'REPORTES
                TabRep.Visible = False
                'CONFIGURACION			
                TabConfig.Visible = False
                BarEmpresas.Visible = False
                BarDerechosUsuarios.Visible = False
                BarUsuarios.Visible = False
                BarParamSistema.Visible = False
                BarBitacoraUsuarios.Visible = False
                BarGRUPOCE.Visible = False
                BarDisenador.Visible = False

                BarTabRutasFlex.Visible = False

                'UTILERIAS
                TabUtilerias.Visible = False
                'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 

                Dim x As Integer = 0

                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE UPPER(USUARIO) = '" & USER_GRUPOCE & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            x += 1
                            Select Case dr("CLAVE")
                                Case 10000  'CATALOGOS
                                    TabCatalogos.Visible = True
                                Case 20000  'LOGISTICA
                                    TabViajes.Visible = True
                                Case 30000  'TESORERIA
                                    TabTesoreria.Visible = True
                                Case 50000  'LIQUIDACION 
                                    TabLiquidacion.Visible = True
                                    'LIQUIDACION
                                Case 50000  'TABULADOR
                                    TabLiquidacion.Visible = True
                                Case 50020  'LIQUIDACION 
                                    BarLiquidaciones.Visible = True
                                Case 50040  'SALDO DE OPERADORES
                                    BarConsignacion2.Visible = True
                                Case 50040  'SALDO DE OPERADORES
                                    BarConsignacion2.Visible = True
                                    'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                                Case 60000  'VENTAS
                                    TabVentas.Visible = True
                                Case 70000  'COMPRAS
                                    TabCompras.Visible = True
                                Case 80000  'CONTROL DE COMBUSTIBLE
                                    TabControlCombus.Visible = True
                                Case 90000  'MANTENIMIENTO
                                    TabMante.Visible = True
                                Case 100000 'INVENTARIO
                                    TabInventario.Visible = True

                                Case 110000 'CONTABILIDAD
                                    TabConta.Visible = True
                                Case 120000 'RECURSOS HUMANOS
                                    TabRecHum.Visible = True
                                Case 130000 'LOCALIZACION
                                    TabLocalizacion.Visible = True
                                Case 140000 'REPORTES
                                    TabRep.Visible = True
                                Case 150000 'CONFIGURACION

                                Case 160000 'UTILERIAS
                                    TabUtilerias.Visible = False
                                Case 10100  'CLIENTES
                                    TabMnuClientes.Visible = True
                                Case 10500  'PROVEEDORES
                                    TabMnuProv.Visible = True
                                Case 11000  'ASEGURADORAS
                                    BarAseguradoras.Visible = True
                                Case 11100  'TARJETAS IAVE
                                    RibTarjetaIAVE.Visible = True
                                Case 11500  'CONTRATOS
                                    BarContratos.Visible = True
                                Case 12000  'PRODUCTOS A CARGAR PARA TANQUES
                                    BarProdCargar.Visible = True
                                Case 12500  'TRAFICO
                                    BarTrafico.Visible = True
                                Case 13000  'EMPLEADOS
                                    TabMnuEmpleados.Visible = True
                                Case 13500  'CENTRO DE COSTOS

                                Case 14000  'CATALOGOS
                                    TabMnuCat.Visible = True
                                Case 14520  'RUTAS SENOR FLORES
                                    BarTabRutasFlex.Visible = True
                                Case 14530 'MOTIVO CANCELACIONES
                                    BarMotivosCancel.Visible = True

                                Case 15000 'ACTIVOS
                                    BarActivos.Visible = True
                                    w1 += 1
                                Case 15015 'TIPO DE ACTIVOS
                                    RibTipoActivos.Visible = True
                                Case 15030 'PRODUCTOS Y SERVICIOS
                                    BarInventario.Visible = True
                                Case 15060 'LISTA DE PRECIOS
                                    RibbListaPrecios.Visible = True

                                Case 15090 'PRECIOS
                                    BarPrecios1.Visible = True
                                Case 15120 'IMPUESTOS
                                    BarImpuestos1.Visible = True
                                Case 15150 'CONCEPTOS MOVIMIENTOS AL INVENTARIO
                                    BarConcMinve1.Visible = True
                                Case 15180 'ALMACENES
                                    BarAlmacenes1.Visible = True
                                Case 15210 'MULTIALMACEN
                                    BarMultialmacen1.Visible = True
                                Case 15250 'LINEAS
                                    BarLineasProductos2.Visible = True
                                Case 15060 'UNIDADES DE MEDIDA
                                    BarUniMed1.Visible = True

                                Case 16200 'MENU TESORERIA
                                    w2 += 1
                                    RibPePeTesoreria.Visible = True
                                Case 16225 'GASTOS PROVEEDORES 
                                    RibTesGastos.Visible = True
                                Case 16250 'CUENTAS BANCARIAS
                                    RibTesCuentasBancarias.Visible = True
                                Case 16275 'BENEFICIARIOS BANCARIOS
                                    RibTesBeneficiariosBancarios.Visible = True
                                    'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                                    'LOGISTICA
                                Case 20000  'TABULADOR VIAJES
                                    TabViajes.Visible = True
                                Case 20100  'CAT. ESTATUS UNIDADES
                                    BarCatStatusUnidades.Visible = True
                                Case 20500  'CAT. ESTATUS VIAJE
                                    BarCatStatusViaje.Visible = True
                                Case 20550  'CAT. ESTATUS OPERADOR
                                    BarCatStatusViaje.Visible = True
                                Case 20600  'PERSONAL AUTORIZA
                                    BarAutoriza.Visible = True
                                Case 20700
                                    BarCasetasXRuta.Visible = True
                                Case 21000  'ESTATUS UNIDADES
                                    BarStatusUnidades.Visible = True
                                Case 21300  'ESTATUS OPERADORES
                                    BarStatusOperadores.Visible = True
                                Case 21500  'TABULADOR DE VIAJES
                                    BarTabRutas.Visible = True
                                Case 22000  'ASIGNACION DE VIAJE
                                    BarAsignacionViajes.Visible = True
                                Case 22500  'CARTA PORTE
                                    BarCartaPorte.Visible = True
                                Case 23500  'BAJA DE VIAJES
                                    BarBajaViajes.Visible = True
                                Case 23600
                                    BarConciliacionValesCombus.Visible = True
                                    'CFDI LICORES VERACRUZ
                                Case 23620
                                    'BarCFDICartaPorte.Visible = True
                                Case 24000  'COMERCIAL
                                    TabMnuComercial.Visible = True

                                    '============================= TESORERIA
                                Case 30500  'autorizacion de gastos
                                    BarTesoreria.Visible = True
                                Case 32500  'deduccion x operador
                                    BarDeducOper.Visible = True
                                    'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                                   '============================= FACTURACION
                                Case 40000  'FACTURACION
                                    TabFacturacion.Visible = True
                                Case 40100  'CONCILIACION CARTA PORTE
                                    BarConcilCartaPorte.Visible = True
                                Case 40500  'CUENTAS X COBRAR
                                    BarCxC.Visible = True
                                Case 41000  'LISTA DE PRECIOS
                                    BarListaprecios.Visible = True
                                Case 41500  'PRECIOS DE FLETE
                                    BarProveedores5.Visible = True
                                Case 42000  'ACTUALIZACION PRECIOS BASE A DIESEL
                                    BarDiesel1.Visible = True
                                    '============================= VENTAS
                                Case 61010  'FACTURACION
                                    BarCotizaciones.Visible = True
                                Case 60100  'COTIZACION
                                    BarCotizaciones.Visible = True
                                Case 60500  'REMISIONES
                                    BarRemisiones.Visible = True
                                Case 60800  'REMISIONES
                                    BarRemisionCartaPorte.Visible = True
                                    '============================= COMPRAS
                                Case 70100  'COMPRAS
                                    BarCompras.Visible = True
                                Case 70500  'RECEPCION
                                    BarRecepciones.Visible = True
                                Case 71000  'ORDE DE COMPRA
                                    BarOrdenDeCompras.Visible = True
                                Case 71500  'REQUISICION
                                    BarRequisiciones.Visible = True
                                Case 71800  'REPORTES COMPRAS
                                    RibbonMenu2.Visible = True
                                    '============================== CONTROL DE COMBUSTIBLE
                                Case 80100  'NIVEL DE COMBUISTIBLE
                                    BarNivelCombustible.Visible = True
                                Case 80500  'MEDICION DE COMBUSTIBLE
                                    BarMedicionCombustible.Visible = True
                                Case 81000  'RESETEO DE UNIDADES
                                    BarReset.Visible = True
                                Case 81500  'TABULADOR DE COMBUSTIBLE
                                    BarTabuladorCombustible.Visible = True
                                    'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                                Case 82000  'CATALOGO DE TANQUES
                                    BarCatTanques.Visible = True
                                Case 82500  'INDICADORES
                                    BarIndicadorDepto.Visible = True
                                Case 83000  'CATALOGO DE EVALUACIONES
                                    BarCatEvaluaciones.Visible = True
                                Case 83020  'CRITERIOS DE EVALUACION
                                    BarCriteriosEva.Visible = True
                                Case 83040  'ASIGNACION DIESEL
                                    BarAsignacionDiesel.Visible = True
                                    '============================= INVENTARIO
                                Case 100100 'PRODUCTOS Y SERVICIOS
                                    BarServiciosDeInventario.Visible = True
                                Case 100500 'ENTREGA DE PRODUCTOS
                                    TabInvMovsInv.Visible = True
                                    BarMovsInvOT.Visible = True
                                Case 101000 'MOVS. AL INVENTARIO
                                    TabInvMovsInv.Visible = True
                                    BarMinveTOT.Visible = True
                                Case 101500 'CONCEPTOS DE MOVS. A INVENTARIO
                                    BarConcMinve.Visible = True
                                Case 102000 'ALMACENES
                                    BarAlmacenes.Visible = True
                                Case 102500 'MULTIALMACEN
                                    BarMultialmacen.Visible = True
                                Case 103000 'LINEAS DE PRODUCTOS
                                    BarLineasProductos.Visible = True
                                Case 103500 'UNIDADES DE MEDIDA
                                    BarUniMed.Visible = True
                                    'CONTABILIDAD
                                Case 110100 'POLIZAS DE TRAFICO
                                    'barPolizaDeTrafico.Visible = True
                                Case 110500 'POLIZAS DE MANTENIMIENTO
                                    RibPolizasManteInterno.Visible = True
                                Case 111000 'POLIZAS DE INVENTARIO
                                    'barPolizaDeInven.Visible = True
                                Case 111500 'POLIZAS DE VENTAS
                                    'barPolizaDeVentas.Visible = True
                                Case 112000 'POLIZAS DE COMPRAS
                                    BarPolizaDeCompras.Visible = True
                                    '============================= RECURSOS HUMANOS
                                Case 120100 'EMPLEADOS
                                    BarEmpleados.Visible = True
                                Case 120500 'PERMISOS
                                    BarEmpleados1.Visible = True
                                Case 121000 'PRESTAMOS PERSONALES
                                    BarPrestamosPersonales.Visible = True
                                Case 121500 'PRESTAMOS DE INFONAVIT
                                    BarPrestamosInfonavit.Visible = True

                                    'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                                    '============================= LOCALIZACION
                                Case 130100 'ESTADOS
                                    BarEstados.Visible = True
                                Case 130500 'LOCALIDADES
                                    BarLocalidades.Visible = True
                                Case 131000 'WEBSERVICES
                                    BarWebServices.Visible = True
                                Case 131500 'PUNTOS DE INTERES
                                    BarPuntosInteres.Visible = True
                                    '============================= UTILERIAS
                                Case 150100 'EMPRESAS
                                    BarEmpresas.Visible = True
                                Case 150500 'DERECHOS DE USUARIOS
                                    BarDerechosUsuarios.Visible = True
                                Case 151000 'USUARIOS
                                    BarUsuarios.Visible = True
                                Case 151500 'PARAMETROS DEL SISTEMA
                                    BarParamSistema.Visible = True
                                Case 152000 'BITACORA USUARIOS
                                    BarBitacoraUsuarios.Visible = True
                                Case 152500 'CONEXION GRUPOCE
                                    BarGRUPOCE.Visible = True
                                Case 153000 'DISEÑADO'R
                                    BarDisenador.Visible = True
                                    '=========================== CLIENTES
                                Case 10101  'CLIENTES
                                    MnuClientes.Visible = True
                                Case 10220  'CONCEPTOS DE CUENTAS X COBRAR
                                    MnuConcCxC.Visible = True
                                Case 10250  'CONTRATOS
                                    MnuContratos.Visible = True
                                Case 10280  'ALTAS CXC
                                    MnuAltaCxC.Visible = True
                                Case 10310  'ESTADO DE CUENTA
                                    MnuEdoCuenta.Visible = True
                                    '=========================== PROVEEDORES
                                Case 10501  'PROVEEDORES
                                    MnuProveedores.Visible = True
                                Case 10620  'CONCEPTOS DE CUENTAS X PAGAR
                                    MnuCxP.Visible = True
                                Case 10650  'CONTRATOS
                                    MnuContacProv.Visible = True
                                Case 10680  'ALTAS CXC
                                    MnuAltaCxP.Visible = True
                                    'Case 10710  'ESTADO DE CUENTA
                                    'BarEstadoCuentaProv.Visible = True

                                    'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 

                                    '=========================== TRAFICO
                                Case 12501  'CONCEPTO DE GASTOS
                                    MnuConcGastos.Visible = True
                                Case 12520  'RUTAS
                                    MnuRutas.Visible = True
                                Case 12540  'UNIDADES
                                    MnuUnidades.Visible = True
                                Case 12560  'MARCAS UNIDADES
                                    MnuMarcasUnidades.Visible = True
                                Case 12580  'TIPO DE UNIDADES
                                    MnuTiposUnidades.Visible = True
                                Case 12600  'MODELO DE UNIDADES
                                    MnuModelosUnidades.Visible = True
                                Case 12620  'GRUPO DE UNIDADES
                                    MnuGrupoUnidades.Visible = True
                                Case 12640  'INSTRUCCIONES DE VIAJE
                                    MnuInstrucViajes.Visible = True
                                Case 12660  'COMBUSTIBLE
                                    MnuCombustible.Visible = True
                                Case 12680  'GASOLINERAS
                                    MnuGasolineras.Visible = True
                                Case 12700  'TRAMOS OFICIALES
                                    MnuTramosOficiales.Visible = True
                                Case 12720  'VALOR DECLARADO
                                    MnuValorDeclarado.Visible = True
                                Case 12740  'PLAZAS
                                    MnuPlazas.Visible = True
                                Case 12760  'CLIENTES OPERATIVOS
                                    MnuClientesOperativos.Visible = True
                                Case 12780  'ESTATUS GASTOS DE VIAJE
                                    MnuStGastosViaje.Visible = True
                                Case 12800  'ESTATUS CARTA PORTE
                                    MnuStCartaPorte.Visible = True
                                Case 12820  'ESTATUS LIQUIDACION
                                    MnuStLiquidacion.Visible = True
                                Case 12840  'ESTATUS VALE COMBUSTIBLE
                                    MnuStValeCombustible.Visible = True
                                Case 12860  '
                                    BarRecogerEnEntregarEn.Visible = True
                                Case 12880  '								
                                    MnuMotores.Visible = True
                                Case 12885  'casetas
                                    MnuCasetas.Visible = True
                                Case 12890  'ACTUALZAICION DE PRECIOS
                                    MNUActPrecios.Visible = True
                                    'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 

                                'EMPLEADOS
                                Case 13001  'OPERADORES
                                    MnuOperadores.Visible = True
                                Case 13020  'DESCUENTO OPERADOR
                                    MnuDescOperador.Visible = True
                                Case 13040  'TIPO DESCUENTO
                                    MnuTipoDesc.Visible = True
                                Case 13060  'FORMA DESCUENTO
                                    MnuTipoDesc.Visible = True
                                Case 13080  'TIPO JORNADA
                                    MnuTipoJornada1.Visible = True
                                Case 13100  'PERIODICIDAD DE PAGO
                                    MnuPeriodicidadPago1.Visible = True
                                Case 13120  'RIESGO TRABAJO
                                    MnuRiesgoTrabajo1.Visible = True
                                Case 13140  'INCIDENCIAS
                                    MnuIncidencias1.Visible = True
                                Case 13160  'FORMA DE PAGO EMPLEADOS
                                    MnuFormasPagoEmpleados.Visible = True
                                Case 13180  'MECANICOS
                                    MnuMecanicos.Visible = True
                                    'LOGISTICA-COMERCIAL
                                Case 24001  'COTIZADOR
                                    MnuCotizador.Visible = True
                                Case 24030  'PEDIDOS
                                    MnuPedidos.Visible = True
                                    '============================= MENTENIMIENTO
                                Case 90100  'MODULO LLANTAS
                                    TabMnuLlantas.Visible = True

                                    '====================== LLANTAS
                                Case 90101  'LLANTAS
                                    MnuLlantas.Visible = True
                                Case 90130  'MARCAS LLANTAS
                                    MnuMarcasLlantas.Visible = True
                                Case 90160  'TIPO LLANTAS
                                    MnuTipoLlantas.Visible = True
                                Case 90190    'ESTATUS LLANTAS
                                    MnuEstatusLlantas.Visible = True
                                Case 90220  'MODELOS LLANTAS
                                    MnuModeloLlantas.Visible = True
                                Case 90250  'MEDIDA LLANTAS
                                    MnuMedidaLlantas.Visible = True

                                    'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 

                                Case 90500  'ACTIVIDADES MANTENIMIENTO
                                    BarLlantasAct.Visible = True
                                Case 91000  'SERVICIOS DE MANTENIMIENTO
                                    BarLlantasMante.Visible = True
                                Case 91500  'CLASIFICACION DE SERVICIOS
                                    BarClasificServicios.Visible = True
                                Case 92000  'REPORTE DE FALLAS
                                    BarReporteLLantas.Visible = True
                                Case 92500  'PROGRAMACION DE SERVICIOS
                                    BarPrograServicios.Visible = True
                                Case 93000  'ORDENES DE TRABAJO enternas
                                    BarOrdenesDeTrabajoExternas.Visible = True
                                Case 93500  'ORDENES DE TRABAJO EXTERNAS
                                    BarOrdenDeTrabajoManto.Visible = True
                                Case 94000  'REPORTES MANTENIMIENTO
                                    BarMenuReportes.Visible = True
                            End Select
                        End While
                    End Using
                End Using
                'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                If x = 0 Then
                    TabCatalogos.Visible = True
                    TabMnuClientes.Visible = True
                    MnuClientes.Visible = True
                    TabVentas.Visible = True
                    TabCompras.Visible = True
                    TabMante.Visible = True
                    TabInventario.Visible = True
                    TabMnuProv.Visible = True
                    MnuProveedores.Visible = True

                    If USER_GRUPOCE.IndexOf("ALMACEN") > -1 Then
                        BarOrdenesDeTrabajoExternas.Visible = True
                        BarOrdenDeTrabajoManto.Visible = True
                        BarServiciosDeInventario.Visible = True
                        'BarMovsInvOT.Visible = True
                        BarMinveTOT.Visible = True
                    Else
                        If USER_GRUPOCE.IndexOf("MANTE") > -1 Then
                            BarOrdenesDeTrabajoExternas.Visible = True
                            BarOrdenDeTrabajoManto.Visible = True
                            TabVentas.Visible = True
                            BarCotizaciones.Visible = True
                            BarRemisiones.Visible = True
                        Else
                            TabMnuLlantas.Visible = True
                            MnuLlantas.Visible = True
                            MnuMarcasLlantas.Visible = True
                            MnuTipoLlantas.Visible = True
                            MnuEstatusLlantas.Visible = True
                            MnuModeloLlantas.Visible = True
                            MnuMedidaLlantas.Visible = True

                            BarLlantasMante.Visible = False
                            BarLlantasAct.Visible = False
                            BarClasificServicios.Visible = False
                            BarReporteLLantas.Visible = False
                            BarPrograServicios.Visible = False
                        End If
                    End If
                    'DERECHOS USUARIOS  SOLO USUARIOS  USUARIOS  USUARIOS  USUARIOS                                      USUARIOS  USUARIOS 
                    BarTrafico.Visible = True
                    MnuUnidades.Visible = True
                    MnuOperadores.Visible = True

                    MnuMarcasUnidades.Visible = True
                    MnuTiposUnidades.Visible = True
                    MnuModelosUnidades.Visible = True
                    MnuGrupoUnidades.Visible = True

                    BarRecogerEnEntregarEn.Visible = False
                    MnuFormaDescuento.Visible = False
                    TabMnuEmpleados.Visible = True
                    TabViajes.Visible = False
                    BarAseguradoras.Visible = False
                    BarContratos.Visible = False
                    BarProdCargar.Visible = False

                    TabMnuCat.Visible = False
                    TabTesoreria.Visible = False
                    TabFacturacion.Visible = False
                    TabLiquidacion.Visible = False
                    TabControlCombus.Visible = False
                    TabConta.Visible = False
                    TabRecHum.Visible = False
                    TabLocalizacion.Visible = False
                Else
                    If USER_GRUPOCE.IndexOf("ALMACEN") > -1 Then
                        If Not TabMante.Visible Then
                            TabMante.Visible = True
                            BarOrdenesDeTrabajo.Visible = True
                        End If
                    End If
                End If

                If pwSupervisor Then
                    TabConfig.Visible = True
                    BarUsuarios.Visible = True
                    BarDerechosUsuarios.Visible = True
                End If
            Catch ex As Exception
                Bitacora(ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            'MODULOS SUPERVISOR
            Try
                Dim MOUDLO As String, x As Integer = 0

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(MODULO,'') AS MODU, ISNULL(ACCESO,0) AS ACC
                        FROM GCLICENCIAMIENTO_MODULOS"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            x += 1
                        End While
                    End Using
                End Using

                If x > 0 Then
                    TabMnuClientes.Visible = False : TabMnuProv.Visible = False : BarAseguradoras.Visible = False
                    RibTarjetaIAVE.Visible = False : BarContratos.Visible = False : BarProdCargar.Visible = False
                    BarTabRutasFlex.Visible = False : BarTrafico.Visible = False : TabMnuEmpleados.Visible = False
                    TabViajes.Visible = False : TabTesoreria.Visible = False : TabFacturacion.Visible = False
                    TabLiquidacion.Visible = False : TabVentas.Visible = False : TabCompras.Visible = False
                    TabControlCombus.Visible = False : TabMante.Visible = False : TabInventario.Visible = False
                    TabConta.Visible = False : TabRecHum.Visible = False : TabLocalizacion.Visible = False
                    TabRep.Visible = False : TabConfig.Visible = False

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(MODULO,'') AS MODU, ISNULL(ACCESO,0) AS ACC
                            FROM GCLICENCIAMIENTO_MODULOS"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read
                                MOUDLO = Desencriptar(dr("MODU"))
                                Select Case Desencriptar(dr("MODU"))
                                    Case "CLIENTES"
                                        TabMnuClientes.Visible = True
                                        If pwSupervisor Then
                                            TabMnuProv.Visible = True
                                            BarTrafico.Visible = True
                                            TabMnuEmpleados.Visible = True
                                        End If
                                    Case "PROVEEDORES"
                                        TabMnuProv.Visible = True
                                        If pwSupervisor Then
                                            BarTrafico.Visible = True
                                            TabMnuEmpleados.Visible = True
                                        End If
                                    Case "ASEGURADORAS"
                                        BarAseguradoras.Visible = True
                                    Case "TARJETA IAVA"
                                        RibTarjetaIAVE.Visible = True
                                    Case "CONTRATOS"
                                        BarContratos.Visible = True
                                    Case "TIPO DE CARGA"
                                        BarProdCargar.Visible = True
                                    Case "RUTAS"
                                        BarTabRutasFlex.Visible = True
                                    Case "TRAFICO"
                                        BarTrafico.Visible = True
                                    Case "EMPLEADOS"
                                        TabMnuEmpleados.Visible = True
                                    Case "CENTRO DE COSTO"

                                    Case "CATALOGOS"
                                        TabMnuCat.Visible = True
                                        'EMPIEZAN LOS MODULOS
                                    Case "LOGISTICA"
                                        TabViajes.Visible = True
                                        If pwSupervisor Then
                                            TabViajes.Visible = True
                                            BarCatStatusUnidades.Visible = True
                                            BarCatStatusViaje.Visible = True
                                            BarCatStatusViaje.Visible = True
                                            BarAutoriza.Visible = True
                                            BarCasetasXRuta.Visible = True
                                            BarStatusUnidades.Visible = True
                                            BarStatusOperadores.Visible = True
                                            BarTabRutas.Visible = True
                                            BarAsignacionViajes.Visible = True
                                            BarCartaPorte.Visible = True
                                            BarBajaViajes.Visible = True
                                            BarConciliacionValesCombus.Visible = True
                                            'BarCFDICartaPorte.Visible = True
                                            TabMnuComercial.Visible = True
                                        End If
                                    Case "TESORERIA"
                                        TabTesoreria.Visible = True
                                        If pwSupervisor Then
                                            BarTesoreria.Visible = True
                                            BarDeducOper.Visible = True
                                        End If
                                    Case "FACTURACION"
                                        TabFacturacion.Visible = True
                                        If pwSupervisor Then
                                            TabFacturacion.Visible = True
                                            BarConcilCartaPorte.Visible = True
                                            BarCxC.Visible = True
                                            BarListaprecios.Visible = True
                                            BarProveedores5.Visible = True
                                            BarDiesel1.Visible = True
                                        End If
                                    Case "LIQUIDACION"
                                        TabLiquidacion.Visible = True
                                    Case "VENTAS"
                                        TabVentas.Visible = True
                                        If pwSupervisor Then
                                            BarCotizaciones.Visible = True
                                            BarRemisiones.Visible = True
                                            BarRemisionCartaPorte.Visible = True
                                        End If
                                    Case "COMPRAS"
                                        TabCompras.Visible = True
                                        If pwSupervisor Then
                                            BarCompras.Visible = True
                                            BarRecepciones.Visible = True
                                            BarOrdenDeCompras.Visible = True
                                            BarRequisiciones.Visible = True
                                            RibbonMenu2.Visible = True
                                        End If
                                    Case "CONTROL DE COMBUSTIBLE"
                                        TabControlCombus.Visible = True
                                        If pwSupervisor Then
                                            BarNivelCombustible.Visible = True
                                            BarMedicionCombustible.Visible = True
                                            BarReset.Visible = True
                                            BarTabuladorCombustible.Visible = True
                                            BarCatTanques.Visible = True
                                            BarIndicadorDepto.Visible = True
                                            BarCatEvaluaciones.Visible = True
                                            BarCriteriosEva.Visible = True
                                            BarAsignacionDiesel.Visible = True
                                        End If
                                    Case "MANTENIMIENTO"
                                        TabMante.Visible = True
                                        If pwSupervisor Then
                                            TabMnuLlantas.Visible = True
                                            MnuLlantas.Visible = True
                                            MnuMarcasLlantas.Visible = True
                                            MnuTipoLlantas.Visible = True
                                            MnuEstatusLlantas.Visible = True
                                            MnuModeloLlantas.Visible = True
                                            MnuMedidaLlantas.Visible = True
                                            BarLlantasAct.Visible = True
                                            BarLlantasMante.Visible = True
                                            BarClasificServicios.Visible = True
                                            BarReporteLLantas.Visible = True
                                            BarPrograServicios.Visible = True
                                            BarOrdenesDeTrabajoExternas.Visible = True
                                            BarOrdenDeTrabajoManto.Visible = True
                                            BarMenuReportes.Visible = True
                                        End If
                                    Case "INVENTARIO"
                                        TabInventario.Visible = True
                                        If pwSupervisor Then
                                            BarServiciosDeInventario.Visible = True
                                            TabInvMovsInv.Visible = True
                                            'BarMovsInvOT.Visible = True
                                            TabInvMovsInv.Visible = True
                                            BarMinveTOT.Visible = True
                                            BarConcMinve.Visible = True
                                            BarAlmacenes.Visible = True
                                            BarMultialmacen.Visible = True
                                            BarLineasProductos.Visible = True
                                            BarUniMed.Visible = True
                                        End If
                                    Case "CONTABILIDAD"
                                        TabConta.Visible = True
                                    Case "RESCURSOS HUMANOS"
                                        TabRecHum.Visible = True
                                    Case "LOCALIZACION"
                                        TabLocalizacion.Visible = True
                                    Case "REPORTES"
                                        TabRep.Visible = True
                                    Case "CONFIGURACION"
                                        TabConfig.Visible = True
                                End Select
                            End While
                        End Using
                    End Using
                End If
                If pwSupervisor And Not pwPoder Then
                    TabConfig.Visible = True
                    BarLicenciamientoMobulos.Visible = False
                    BarEmpresas.Visible = True
                    BarDerechosUsuarios.Visible = True
                    BarUsuarios.Visible = True
                    BarParamSistema.Visible = True
                    BarBitacoraUsuarios.Visible = True
                    BarGRUPOCE.Visible = True
                    BarDisenador.Visible = True
                    BarAcercaDe.Visible = True
                End If
            Catch ex As Exception
                Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If 'IF PWPODER 

        Try
            Application.DoEvents()
            Var20 = 0
            If TabCatalogos.Visible = True Then
                TabCatalogos.Selected = True
            Else
                If TabMante.Visible = True Then
                    TabMante.Selected = True
                Else
                    If TabInventario.Visible = True Then
                        TabInventario.Selected = True
                    Else
                        If TabVentas.Visible = True Then
                            TabVentas.Selected = True
                        Else
                            If TabCompras.Visible = True Then
                                TabCompras.Selected = True
                            End If
                        End If
                    End If
                End If
            End If

            If Not BarMovsInvOT.Visible And Not BarMinveTOT.Visible Then
                TabInvMovsInv.Visible = False
            Else
                TabInvMovsInv.Visible = True
            End If
            If Not BarMenuReportes.Visible Then
                GpoReportMante.Visible = False
            Else
                GpoReportMante.Visible = True
            End If
            If w1 = 0 Then
                'RibSep5.Visible = False
            End If
            If w2 = 0 Then
                'RibSep6.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub C1Ribbon1_MinimizedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1Ribbon1.MinimizedChanged
        If c1Ribbon1.Minimized Then
            MinimizeRibbonButton.Visible = False
            ExpandRibbonButton.Visible = True
        Else
            MinimizeRibbonButton.Visible = True
            ExpandRibbonButton.Visible = False
        End If
    End Sub

    Private Sub MinimizeRibbonButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizeRibbonButton.Click
        c1Ribbon1.Minimized = True
    End Sub

    Private Sub ExpandRibbonButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandRibbonButton.Click
        c1Ribbon1.Minimized = False
    End Sub
    Protected Overrides Sub OnMdiChildActivate(ByVal e As System.EventArgs)
        MyBase.OnMdiChildActivate(e)
        If Not _windowSwitching Then
        End If
    End Sub
#Region "MDI Window Switching Code"

    Private _windowSwitching As Boolean
    Private _turnOffMdi As Boolean

    Friend ReadOnly Property WindowSwitching() As Boolean
        Get
            Return _windowSwitching
        End Get
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        If _turnOffMdi Then
            IsMdiContainer = False
            _turnOffMdi = False
        End If
    End Sub
#End Region
    Private Sub BarSalir_Click_1(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarCreaInsertData_Click(sender As Object, e As EventArgs) Handles BarCreaInsertData.Click
        If pwPoder Then
            'BACKUPTXT("XTAB_CAPTION", "frmCreaInsertSQL")
            'CREA_TAB(frmCreaInsertSQL, "Crea Insert data")
        Else
            'MsgBox("Acceso denegado")
        End If
    End Sub
    Private Sub BarContratos_Click(sender As Object, e As EventArgs) Handles BarContratos.Click
        BACKUPTXT("XTAB_CAPTION", "frmContratos")
        CREA_TAB(FrmContratos, "Contratos")
    End Sub
    Private Sub BarEmpresas_Click_1(sender As Object, e As EventArgs) Handles BarEmpresas.Click
        If pwPoder Then
            BACKUPTXT("XTAB_CAPTION", "frmEmpresas")

            Var2 = "Sin Border"
            CREA_TAB(FrmEmpresas, "Empresas")
        Else
            MsgBox("Acceso denegado")
        End If
    End Sub
    Private Sub BarClasificServicios_Click(sender As Object, e As EventArgs) Handles BarClasificServicios.Click
        BACKUPTXT("XTAB_CAPTION", "frmClasificServicios")
        CREA_TAB(frmClasificServicios, "Clasificación de servicios")
    End Sub
    Private Sub Tab1_TabPageClosing(sender As Object, e As TabPageCancelEventArgs) Handles Tab1.TabPageClosing
        Try
            Select Case Tab1.TabPages(Tab1.SelectedIndex).Text
                Case "Contratos AE", "Contratos"
                    frmContratosAE.Dispose()
                Case "Clasificación de serviciosAE"
                    frmClasificServiciosAE.Dispose()
                Case "Clasificación de servicios"
                    frmClasificServicios.Dispose()
                Case "Tipo Llanta"
                    FrmLlantasTipo.Dispose()
                Case "Marcas Llantas"
                    FrmMarcasLlantas.Dispose()
                Case "Marcas LlantasAE"
                    FrmMarcasLLantasAE.Dispose()
                Case "Status Llantas"
                    frmStatusLlantasAE.Dispose()
                Case "Webservice"
                    frmWebServices.Dispose()
                Case "Reporteador"
                    frmReportDesigner.Dispose()
                Case "Tipo Llanta"
                    FrmLlantasTipo.Dispose()
                Case "Marcas Llantas"
                    FrmMarcasLlantas.Dispose()
                Case "Status Llantas"
                    frmStatusLlantas.Dispose()
                Case "Modelo Llantas"
                    frmModeloLlantas.Dispose()
                Case "Llantas"
                    FrmLlantas.Dispose()
                Case "Movimientos Llantas"
                    FrmLlantasAE.Dispose()
                Case "Operadores"
                    frmOperadores.Dispose()
                Case "Departamentos"
                    frmDeptos.Dispose()
                Case "Puestos"
                    frmPuestos.Dispose()
                Case "Bancos"
                    frmBancos.Dispose()
                Case "Conceptos Cuentas X Cobrar"
                    frmCXC.Dispose()
                Case "Estados"
                    frmEstados.Dispose()
                Case "Grupo Sanguineo"
                    frmGrupoSanguineo.Dispose()
                Case "Tipo de Regimen"
                    frmTipoRegimen.Dispose()
                Case "Tipo Operación"
                    frmTipoOperacion.Dispose()
                Case "Tipo Contrato"
                    frmTipoContrato.Dispose()
                Case "Tipo Jornada"
                    frmTipoJornada.Dispose()
                Case "Periodicidad de pago"
                    frmPeriodicidadPago.Dispose()
                Case "Riesgo de trabajo"
                    frmRiesgoTrabajo.Dispose()
                Case "Incidencias"
                    frmCatIncidencias.Dispose()
                Case "Unidades"
                    frmUnidades.Dispose()
                Case "Movimientos Unidades"
                    frmUnidadesAE.Dispose()
                Case "Medidas Llantas"
                    frmMedidasLlantas.Dispose()
                Case "Propietarios"
                    frmPropietarios.Dispose()
                Case "Marca Unidad"
                    frmMarcaUnidad.Dispose()
                Case "Modelo Unidad"
                    frmModeloUnidad.Dispose()
                Case "Tipo Unidad"
                    frmTipoUnidad.Dispose()
                Case "Sucursales"
                    frmSucursal.Dispose()
                Case "Tipo de Combustible"
                    frmTipoCombustible.Dispose()
                Case "Marca Unidad"
                    frmMarcaUnidad.Dispose()
                Case "Clientes"
                    frmClientes.Dispose()
                Case "Clientes "
                    frmClientesAE.Dispose()
                Case "Zonas"
                    frmZonas.Dispose()
                Case "Vendedores"
                    frmVend.Dispose()
                Case "Grupo Unidades"
                    frmGrupoUnidades.Dispose()
                Case "Placas Default"
                    frmPlacasDefa.Dispose()
                Case "Marcas Renovado"
                    FrmMarcasRenovado.Dispose()
                Case "Modelos Renovado"
                    frmModelosRenovado.Dispose()
                Case "Puestos"
                    frmPuestos.Dispose()
                Case "Conceptos Prestamos"
                    frmConcPrestamos.Dispose()
                Case "Conceptos de Gastos"
                    frmConcGastos.Dispose()
                Case "Detalles Rutas"
                    frmDetallesRutas.Dispose()
                Case "Marca Unidad"
                    frmMarcaUnidad.Dispose()
                Case "Tipo Unidad"
                    frmTipoUnidad.Dispose()
                Case "Modelo Unidad"
                    frmModeloUnidad.Dispose()
                Case "Grupo Unidades"
                    frmGrupoUnidades.Dispose()
                Case "Instrucciones de viaje"
                    frmInstrucViaje.Dispose()
                Case "Operadores"
                    frmOperadores.Dispose()
                Case "Tipo Jornada"
                    frmTipoJornada.Dispose()
                Case "Periodicidad de pago"
                    frmPeriodicidadPago.Dispose()
                Case "Incidencias"
                    frmCatIncidencias.Dispose()
                Case "Forma Pago Empleados"
                    frmFormaPagoEmpleados.Dispose()
                Case "Riesgo de trabajo"
                    frmRiesgoTrabajo.Dispose()
                Case "Clientes"
                    frmClientes.Dispose()
                Case "Conceptos Cuentas X Cobrar"
                    frmCXC.Dispose()
                Case "Proveedores"
                    FrmProv.Dispose()
                Case "Conceptos CxP"
                    FrmCxP.Dispose()
                Case "Programación de Servicios"
                    frmProgServicios.Dispose()
                Case "Servicios de Mantenimiento"
                    frmServiciosMante.Dispose()
                Case "Actividades Mantenimiento"
                    frmActividadesMante.Dispose()
                Case "Reporte de Falla"
                    frmReporteFalla.Dispose()
                Case "Mecanicos"
                    frmMecanicos.Dispose()
                Case "Ordenes de Trabajo"
                    Select Case TIPO_OTI
                        Case 0
                            'frmOrdenDeTrabajoExt.Dispose()
                        Case 1
                            frmOTI.Dispose()
                    End Select
                Case "Orden de Trabajo"
                    Select Case TIPO_OTI
                        Case 0
                            'FrmOrdenDeTrabajoExtAE.Dispose()
                        Case 1
                            frmOTIAE.Dispose()
                    End Select
                Case "Mantenimiento Externo"
                    Select Case TIPO_OTI
                        Case 0
                            'frmMantenimientoExterno.Dispose()
                        Case 1
                            frmOTE.Dispose()
                    End Select
                Case "Orden de Trabajo Externa"
                    Select Case TIPO_OTI
                        Case 0
                            Try
                                'If VarFORM2 = "NoSalirDelForm" Then
                                'MessageBox.Show("Existen partidas en la orden de trabajo externa para confirmar por favor utilice la opción Salir")
                                'e.Cancel = True
                                'Else
                                'frmMantenimientoExternoAE.Dispose()
                                'End If
                            Catch ex As Exception
                            End Try
                        Case 1
                            Try
                                If VarFORM2 = "NoSalirDelForm" Then
                                    MessageBox.Show("Existen partidas en la orden de trabajo externa para confirmar por favor utilice la opción Salir")
                                    e.Cancel = True
                                Else
                                    frmOTEAE.Dispose()
                                End If
                            Catch ex As Exception
                            End Try
                    End Select
                Case "Movs. Inv. TOT"
                    'FrmMovsInvOT.Dispose()
                Case "Gasolineras"
                    frmGasolineras.Dispose()
                Case "Movimientos Carta Porte", "Carta Porte"
                    'FrmCartaPorteAE.Dispose()
                Case "Consulta carta porte"
                    'FrmCartaPorteAE.Dispose()
                Case "Tipo de Cobro"
                    frmTipoDeCobroAE.Dispose()
                Case "Número de viaje"
                    frmNumeroViajeAE.Dispose()
                Case "Estatus"
                    frmStatus.Dispose()
                Case "Vale Combustible"
                    frmValeCombustibleAE.Dispose()
                Case "Aseguradoras"
                    frmAseguradoras.Dispose()
                Case "Movimiento Aseguradoras"
                    frmAseguradorasAE.Dispose()
                Case "Casetas"
                    frmCasetasAE.Dispose()
                Case "Tramos Oficiales"
                    frmTramosOficialesAE.Dispose()
                Case "Detalles Rutas"
                    frmDetallesRutasAE.Dispose()
                Case "Inventario Refacciones"
                    FrmInvenRAE.Dispose()
                Case "Inventario de Activo Fijo"
                    FrmInvenFijoAE.Dispose()
                Case "Lineas"
                    FrmLineasAE.Dispose()
                Case "Unidad de Medida"
                    FrmUniMedAE.Dispose()
                Case "Conc. movs. al inv."
                    frmConMAE.Dispose()
                Case "Contactos Proveedores"
                    frmContapAE.Dispose()
                Case "Catálogo Anticipos"
                    frmAnticiposCatAE.Dispose()
                Case "Anticipos de Viaje"
                    frmAnticiposViajeAE.Dispose()
                Case "Viajes"
                    frmViajesAE.Dispose()
                Case "Personal Autoriza"
                    frmAutorizaAE.Dispose()
                Case "Gastos de Viajes"
                    frmGastosDeViajeAE.Dispose()
                Case "Descuento Operador"
                    frmDescOperadorAE.Dispose()
                Case "Tipo Descuento"
                    frmTipoDescuentoAE.Dispose()
                Case "Forma Descuento"
                    frmFormaDescuentoAE.Dispose()
                Case "Baja de Viajes"
                    'frmBajaDeViajesAE.Dispose()
                Case "Facturación"
                    FrmFacturacionAE.Dispose()
                Case "Productos"
                    frmProductosAE.Dispose()
                Case "Operadores"
                    frmOperadoresAE.Dispose()
                Case "Inventario"
                    FrmInven.Dispose()
                Case "Inventario articulo"
                    FrmInvenAE.Dispose()
                Case "Centro de Costos"
                    frmCentroCostosAE.Dispose()
                Case "Destino"
                    frmDestinoAE.Dispose()
                Case "Puntos de Interes"
                    frmPuntosDeInteres.Dispose()
                Case "Valor Declarado"
                    frmValorDeclaradoAE.Dispose()
                Case "Tarjeta IAVE"
                    frmTarjetaIAVEAE.Dispose()
                Case "Tarjetas IAVE"
                    frmTarjetaIAVE.Dispose()
                Case "Combustible Efectivo"
                    frmValeCombustibleEfectivoAE.Dispose()
                Case "Polizas Seguro"
                    frmPolizaSeguroAE.Dispose()
                Case "Tipo Póliza"
                    frmTipoPolizaAE.Dispose()
                Case "Equipo Asegurado"
                    frmEquipoAseguradoAE.Dispose()
                Case "Siniestros"
                    frmSiniestroAE.Dispose()
                Case "Liquidaciones"
                    FrmLiquidaciones.Dispose()
                Case "Liquidación"
                    FrmLiquidacionesAE.Dispose()
                Case "Movimientos al Inventario"
                    FrmMinveRAE.Dispose()

                Case "Captura Compra", "Captura Recepcion", "Captura Orden de Compra", "Captura Requisición", "Captura devolución compras"
                    FrmComprasTrans.Dispose()
                Case "Compras", "Recepciones", "Orden de Compra", "Requisición", "Devolución compras"
                    frmComprasDoc.Dispose()
                Case "Gastos"

                Case "Plazas"
                    FrmPlazasAE.Dispose()
                Case "Marcas Llantas"
                    FrmMarcasLLantasAE.Dispose()
                Case "Tipo Llanta"
                    FrmLlantasTipoAE.Dispose()
                Case "Status Llantas"
                    frmStatusLlantasAE.Dispose()
                Case "Modelo Llantas"
                    frmModeloLlantasAE.Dispose()
                Case "Medidas Llantas"
                    frmMedidasLlantasAE.Dispose()
                Case "Llantas"
                    FrmLlantasAE.Dispose()
                Case "Reporte de Falla"
                    frmReporteFallaAE.Dispose()
                Case "Nivel de Combustible"
                    frmNivelCombustibleAE.Dispose()
                Case "Medición de Combustible"
                    frmMedicionCombustibleAE.Dispose()
                Case "Reseteo"
                    FrmReseteoAE.Dispose()
                Case "Almacenes"
                    FrmAlmacenesAE.Dispose()
                Case "Alta CxP"
                    FrmAltaCxPAE.Dispose()
                Case "Multialmacén"
                    FrmMultiAlmacen.Dispose()
                Case "Pedidos AE"
                    FrmPedidosAE.Dispose()
                Case "Pedidos"
                    frmPedidos.Dispose()
                Case "Estatus Unidades"
                    frmCatStatusUnidadesAE.Dispose()
                Case "Estatus Viaje"
                    frmCatStatusViajeAE.Dispose()
                Case "Estatus Unidades"
                    FrmEstatusUnidades.Dispose()
                Case "Asignación de Viajes"
                    FrmAsignacionViaje.Dispose()
                Case "Asignación viaje"
                    FrmAsignacionViajeAE.Dispose()
                    FrmAsigViajeBuenoAE.Dispose()
                Case "Tabulador de rutas"
                    frmTabRutas.Dispose()
                Case "Clientes Operativos"
                    FrmClientesOperativosAE.Dispose()
                Case "Estatus Gastos de Viaje"
                    frmSt_Gastos_ViajeAE.Dispose()
                Case "Estatus carta Porte"
                    frmStCartaPorteAE.Dispose()
                Case "Estatus liquidacion"
                    frmStLiquidacionAE.Dispose()
                Case "Estatus vale combustible"
                    frmStValeCombustibleAE.Dispose()
                Case "Conciliación Vales Combustible"
                    FrmConciValesCombusAE.Dispose()
                Case "Vale Combustible"
                    frmValeCombustibleAE.Dispose()
                Case "Formatos"
                    frmArchivosReportes.Dispose()
                Case "Conciliación Cartas Porte"
                    frmConciCartaPorte.Dispose()
                Case "Alta CxC"
                    frmAltaCxC.Dispose()
                Case "Lista Precios"
                    FrmListaPrecios.Dispose()
                Case "Precios inventario fijo"
                    FrmPrecios.Dispose()
                Case "Tesoreria"
                    FrmTesoreria.Dispose()
                Case "Movimientos a Operadores"
                    frmOperadoresAE.Dispose()
                Case "Tabuladores combustible"
                    frmTabuladorCombustible.Dispose()
                Case "Tabulador combustible"
                    frmTabuladorCombustibleAE.Dispose()
                Case "Entrega de productos OT", "Movs. Inv. OT"
                    'FrmMovsInvOT.Dispose()
                Case "Movimientos al Inventario"
                    FrmMinveSae.Dispose()
                Case "Documentos"
                    FrmDocumentos.Dispose()
                Case "Punto de venta"
                    FrmTPV.Dispose()
                Case "Movs. Ordenes de Trabajo"
                    'frmOrdenDeTrabajoExtMovsInv.Dispose()
                Case "Derechos"
                    FrmDerechos.Dispose()
                Case "Trazabilidad"
                    frmTrazabilidad.Dispose()
                Case "Reporte facturas"
                    frmReporteFacturas.Dispose()
                Case "Cotizador"
                    frmCotizador.Dispose()
                Case "Cotización"
                    FrmCotizaAE.Dispose()
                Case "Reporte precio costos"
                    frmReportePrecioCostos.Dispose()
                Case "Reporte notas facturas"
                    ReporteVentasFacturas.Dispose()
                Case "Reporte ordenes de trabajo"
                    frmReporteOrdenDeTRabajo.Dispose()
                Case "Reporte de unidades"
                    frmReporteDeUnidades.Dispose()
                Case "Reporte de refacciones"
                    frmReporteDeRefacciones.Dispose()
                Case "Catálogo tanques"
                    frmTanques.Dispose()
                Case "Indicadores del departamento"
                    FrmIndicadorDepto.Dispose()
                Case "Motores"
                    frmMotores.Dispose()
                Case "Documentos XML"
                    frmComprasXML.Dispose()
                Case "Póliza compras"
                    FrmPolizaCompras.Dispose()
                Case "Estatus operadores"
                    frmEstatusOperadores.Dispose()
                    frmEstatusOperadores.Dispose()
                Case "Cat. St. operador"
                    frmCatStatusOper.Dispose()
                Case "Criterios evaluación"
                    frmCriteriosEva.Dispose()
                Case "Baja carta porte"
                    FrmBaja_viaje_CartaPorte.Dispose()
                    FrmAsigViajeBueno.Dispose()
                Case "Sueldo operadores"
                    frmSueldoOperadores.Dispose()
                Case "Deducciones"
                    FrmDeducciones.Dispose()
                Case "Asignación diesel"
                    frmAsignacionDiesel.Dispose()
                Case "Servicios x unidad"
                    frmServiciosXUnidad.Dispose()
                Case "Existencia a una fecha"
                    frmExistAUnaFecha.Dispose()
                Case "Poliza de mantenimiento"
                    FrmPolizaMantenimiento.Dispose()
                Case "Poliza mantenimiento externo"
                    FrmPolizaMantExt.Dispose()

                Case "Deducciones operadores"
                    FrmDeducOperAE.Dispose()
                Case "Poliza orden de trabajo"
                    FrmPolizaOdeT.Dispose()
                Case "Movs. inv. llantas"
                    FrmLlantasMinve.Dispose()
                Case "Control llantas"
                    FrmControlLlantas.Dispose()
                Case "UTILERIAS"
                    FrmUtilerias.Dispose()
                Case "Detallado compras"
                    FrmDetalladoCompras.Dispose()
                Case "Casetas por ruta"
                    FrmCasetasXRutaAE.Dispose()
                Case "Conceptos llantas"
                    FrmLlantasConM.Dispose()
                Case "Generar CFDI 4.0"
                    Principal.Dispose()
                Case "Poliza salida llantas"
                    FrmPolizaSalidaLLantas.Dispose()
                Case "Poliza renovados"
                    FrmPolizaRenovados.Dispose()
                Case "Actualización de precios"
                    FrmActPrecios.Dispose()
                Case "Concentrado CFDI carta porte"
                    FrmCFDICartaPorteConcen.Dispose()
                Case "Programación de pedidos"
                    FrmProgPedidos.Dispose()
                Case "Tab. rutas"
                    FrmTabRutasHoja.Dispose()
                Case "Parámetros clientes"
                    FrmParamClientes.Dispose()
                Case "Gasto renovado"
                    FrmGastoRenovado.Dispose()
                Case "Complemento de pago"
                    FrmPagoComplemento.Dispose()
                Case "Pago complemento"
                    FrmPagoComplementoAE.Dispose()
                Case "Pólizas Provisión Diesel"
                    FrmPolizaDiesel.Dispose()
                Case "Poliza folios dinero"
                    FrmPolizaFoliosDinero.Dispose()
                Case "Almacenes refacciones"
                    FrmAlmacenesR.Dispose()
                Case "Multialmacén refacciones"
                    FrmAltaMultialmacenR.Dispose()
                Case "Almacenes activo fijo"
                    FrmAlmacenesF.Dispose()
                Case "Multialmacén activo fijo"
                    FrmAltaMultialmacenF.Dispose()
                Case "Poliza egreso"
                    FrmPolizaEgreso.Dispose()
                Case "Mantenimiento OT"
                    FrmManteOT.Dispose()
                Case "Cuenta bancaria ordenante"
                    FrmCtaBanOrd.Dispose()
                Case "Cuenta bancaria beneficiario"
                    FrmCtaBanEmpresa.Dispose()
                Case "Poliza salida gen. oper y mec."
                    FrmPolizasSalidaGenOperMec.Dispose()
                Case "Poliza ingresos CxC"
                    FrmPolizaIngresosCxC.Dispose()
                Case "Ventas por producto por cliente"
                    FrnVtaXProXCteTrackFullRojo.Dispose()
                Case "Consulta movs. inv. OT"
                    FrmConsultaMovsInvOT.Dispose()
                Case "Póliza compras NC"
                    FrmPolizaComprasNC.Dispose()
                Case "Facturas"
                    frmFACTURAS.Dispose()
                Case "Resumen de compras"
                    FrmDetalladoComprasJulio.Dispose()
                Case "Gastos"
                    FrmGastosDoc.Dispose()
                Case "Captura gastos"
                    FrmGastos.Dispose()
                Case "Motivos cancelaciones"
                    FrmMotivosCancel.Dispose()
                Case "Antiguedad de saldos clientes"
                    frmSaldosClientes.Dispose()
                Case "Antiguedad de saldos proveedores"
                    frmAntSaldosProv.Dispose()
                Case "Resumen de ventas"
                    FrmDetalladoComprasJulio.Dispose()
                Case "Saldos de clientes"
                    FrmClientesV2.Dispose()
                Case "Saldos operadores"
                    FrmSaldosOperadores.Dispose()
                Case "Deduccion operador"
                    FrmDeducOperAE.Dispose()
                Case "Movimientos bancarios"
                    RibBMovs.Enabled = True
                    FrmBMovs.Dispose()
                Case "Conceptos bancarios"
                    FrmBConBan.Dispose()
                Case "Beneficiarios"
                    FrmBBenef.Dispose()
                Case "Solicitud pago prov."
                    FrmSolPagoProv.Dispose()
                Case "Póliza liquidaciones"
                    FrmPolizaLiq.Dispose()
                Case "Pre-Ordenes de Compra"
                    FrmPreOCDocs.Dispose()
                Case "Pre-Orden de Compra"
                    FrmPreOCCompra.Dispose()
                Case "Generadores"
                    FrmGenerador.Dispose()
                Case "Cat. gastos"
                    FrmCatGastos.Dispose()
                Case "Impuestos"
                    FrmEsquemas.Dispose()
                Case "Tipo Activos"
                    FrmTipoActivos.Dispose()
                Case "Activos"
                    FrmActivos.Dispose()
                Case "Lista de precios"
                    FrmConsulPrecios.Dispose()
                Case "Consulta bancaria"
                    FrmConsultaBancaria.Dispose()
                Case "Póliza gastos administrativos"
                    FrmPolizaGastos.Dispose()
                Case "Cartas porte  traslado"
                    FrmCartaPorteTraslado.Dispose()
                Case "Carta porte traslado"
                    FrmCartaPorteTrasladoAE.Dispose()
                Case "Almacén"
                    FrmAlmacenesAE.Dispose()
                Case "Edo. cuenta gen. oper"
                    FrmEdoCuentaGenOper.Dispose()
                Case "Series"
                    FrmParamSeries.Dispose()
                Case "Seguimiento viajes"
                    FrmSeguimientoViajes.Dispose()
                Case "Inspección llantas"
                    FrmInspeccionLlantas.Dispose()
                Case "Usuarios"
                    FrmUSUARIOS.Dispose()
                Case "Conceptos Flujo efectivo"
                    FrmConcepFlujo.Dispose()
                Case "Flujo de caja"
                    FrmTPVFlujoEfectivo.Dispose()
                Case "Estaciones"
                    FrmEstacionTrab.Dispose()
                Case "Importar llantas"
                    FrmImportLlantasEx.Dispose()
                Case "Factura global"
                    FrmFacturaGlobal.Dispose()
                Case "Facturar viaje"
                    FrmAsigViajeBueno.Dispose()
                Case "Conceptos de cobro"
                    FrmAsigCatCobro.Dispose()
                Case "Marcas renovado"
                    FrmMarcasRenovado.Dispose()
                Case "Proveedor renovado"
                    FrmProvRenovados.Dispose()
                Case "Pila desecho"
                    FrmPilaDesecho.Dispose()
                Case "Addendas"
                    FrmAddendas.Dispose()
                Case "Embalaje"
                    FrmEmbalajeBueno.Dispose()
                Case "Cargas"
                    FrmCargasBueno.Dispose()
                Case "Impuestos/Cuentas por año"
                    FrmEsquemasYear.Dispose()
                Case "Impuestos/Cuentas por mes"
                    FrmEsquemasMes.Dispose()
                Case Else
                    BACKUPTXT("XYTAB_CAPTION", "----------------------------------------------------------------------------")
                    BACKUPTXT("XYTAB_CAPTION", Tab1.TabPages(Tab1.SelectedIndex).Text)
            End Select
        Catch ex As Exception
            'MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarLlantasTipo_Click(sender As Object, e As EventArgs) Handles BarLlantasTipo.Click
        BACKUPTXT("XTAB_CAPTION", "frmLlantasTipo")
        CREA_TAB(FrmLlantasTipo, "Tipo Llanta")
    End Sub
    Private Sub BarLlantasMarca_Click(sender As Object, e As EventArgs) Handles BarLlantasMarca.Click
        BACKUPTXT("XTAB_CAPTION", "frmMarcasLlantas")
        CREA_TAB(FrmMarcasLlantas, "Marcas Llantas")
    End Sub
    Private Sub BarLlantasStatus_Click(sender As Object, e As EventArgs) Handles BarLlantasStatus.Click
        BACKUPTXT("XTAB_CAPTION", "frmStatusLlantas")
        CREA_TAB(frmStatusLlantas, "Status Llantas")
    End Sub
    Private Sub BarLlantasModelo_Click(sender As Object, e As EventArgs) Handles BarLlantasModelo.Click
        BACKUPTXT("XTAB_CAPTION", "frmModeloLlantas")
        CREA_TAB(frmModeloLlantas, "Modelo Llantas")
    End Sub
    Private Sub BarLlantas_Click(sender As Object, e As EventArgs) Handles BarLlantas.Click
        BACKUPTXT("XTAB_CAPTION", "frmLlantas")
        CREA_TAB(FrmLlantas, "Llantas")
    End Sub
    Private Sub BarWebServices_Click(sender As Object, e As EventArgs) Handles BarWebServices.Click
        BACKUPTXT("XTAB_CAPTION", "frmWebServices")
        CREA_TAB(frmWebServices, "webservices")
    End Sub
    Private Sub BarOperadores_Click(sender As Object, e As EventArgs) Handles BarOperadores.Click
        BACKUPTXT("XTAB_CAPTION", "frmOperadores")
        CREA_TAB(frmOperadores, "Operadores")
    End Sub
    Private Sub BarDepto_Click(sender As Object, e As EventArgs) Handles BarDepto.Click
        BACKUPTXT("XTAB_CAPTION", "frmDeptos")
        CREA_TAB(frmDeptos, "Departamentos")
    End Sub
    Private Sub BarPuestos_Click(sender As Object, e As EventArgs) Handles BarPuestos.Click
        BACKUPTXT("XTAB_CAPTION", "frmPuestos")
        CREA_TAB(frmPuestos, "Puestos")
    End Sub
    Private Sub BarBancos_Click(sender As Object, e As EventArgs) Handles BarBancos.Click
        BACKUPTXT("XTAB_CAPTION", "frmBancos")
        CREA_TAB(frmBancos, "Bancos")
    End Sub
    Private Sub BarFormasPago_Click(sender As Object, e As EventArgs) Handles BarConcCxC.Click
        BACKUPTXT("XTAB_CAPTION", "frmCXC")

        CREA_TAB(frmCXC, "Conceptos Cuentas X Cobrar")
    End Sub
    Private Sub MnuEstados_Click(sender As Object, e As EventArgs) Handles MnuEstados.Click
        BACKUPTXT("XTAB_CAPTION", "frmEstados")
        CREA_TAB(frmEstados, "Estados")
    End Sub
    Private Sub MnuTipoRegimen_Click(sender As Object, e As EventArgs) Handles MnuTipoRegimen.Click
        BACKUPTXT("XTAB_CAPTION", "frmTipoRegimen")
        CREA_TAB(frmTipoRegimen, "Tipo de Regimen")
    End Sub
    Private Sub MnuTipoOperacion_Click(sender As Object, e As EventArgs) Handles MnuTipoOperacion.Click
        BACKUPTXT("XTAB_CAPTION", "frmTipoOperacion")

        CREA_TAB(frmTipoOperacion, "Tipo Operación")
    End Sub
    Private Sub MnuTipoContrato_Click(sender As Object, e As EventArgs) Handles MnuTipoContrato.Click
        BACKUPTXT("XTAB_CAPTION", "frmTipoContrato")
        CREA_TAB(frmTipoContrato, "Tipo Contrato")
    End Sub
    Private Sub BarLlantasMed_Click(sender As Object, e As EventArgs) Handles BarLlantasMed.Click
        BACKUPTXT("XTAB_CAPTION", "frmMedidasLlantas")
        CREA_TAB(frmMedidasLlantas, "Medidas Llantas")
    End Sub
    Private Sub MnuPropietarios_Click(sender As Object, e As EventArgs) Handles MnuPropietarios.Click
        BACKUPTXT("XTAB_CAPTION", "frmPropietarios")
        CREA_TAB(frmPropietarios, "Propietarios")
    End Sub
    Private Sub MnuSucursales_Click(sender As Object, e As EventArgs) Handles MnuSucursales.Click
        BACKUPTXT("XTAB_CAPTION", "frmSucursal")
        CREA_TAB(frmSucursal, "Sucursales")
    End Sub
    Private Sub MnuTipoCombustible_Click(sender As Object, e As EventArgs) Handles MnuTipoCombustible.Click
        BACKUPTXT("XTAB_CAPTION", "frmTipoCombustible")
        CREA_TAB(frmTipoCombustible, "Tipo de Combustible")
    End Sub
    Private Sub BarMaarca_Click(sender As Object, e As EventArgs) Handles BarMaarca.Click
        BACKUPTXT("XTAB_CAPTION", "frmMarcaUnidad")
        CREA_TAB(frmMarcaUnidad, "Marca Unidad")
    End Sub
    Private Sub BarGRUPOCE_Click(sender As Object, e As EventArgs) Handles BarGRUPOCE.Click
        FrmSAROCE.ShowDialog()
    End Sub
    Private Sub MnuZonas_Click(sender As Object, e As EventArgs) Handles MnuZonas.Click
        BACKUPTXT("XTAB_CAPTION", "frmZonas")
        CREA_TAB(frmZonas, "Zonas")
    End Sub
    Private Sub BarUsuarios_Click_1(sender As Object, e As EventArgs) Handles BarUsuarios.Click
        'FrmUSUARIOS.ShowDialog()
        CREA_TAB(FrmUSUARIOS, "Usuarios")
    End Sub
    Private Sub MnuDepto_Click(sender As Object, e As EventArgs) Handles MnuDepto.Click
        BACKUPTXT("XTAB_CAPTION", "frmDeptos")
        CREA_TAB(frmDeptos, "Departamentos")
    End Sub
    Private Sub MnuPuestosEmpleados_Click(sender As Object, e As EventArgs) Handles MnuPuestosEmpleados.Click
        BACKUPTXT("XTAB_CAPTION", "frmPuestos")
        CREA_TAB(frmPuestos, "Puestos")
    End Sub
    Private Sub MnuBancos1_Click(sender As Object, e As EventArgs)
        BACKUPTXT("XTAB_CAPTION", "frmBancos")
        CREA_TAB(frmBancos, "Bancos")
    End Sub

    Private Sub MnuConcPrestamos_Click(sender As Object, e As EventArgs) Handles MnuConcPrestamos.Click
        BACKUPTXT("XTAB_CAPTION", "frmConcPrestamos")
        CREA_TAB(frmConcPrestamos, "Conceptos Prestamos")
    End Sub
    Private Sub MnuConcGastos_Click(sender As Object, e As EventArgs) Handles MnuConcGastos.Click
        BACKUPTXT("XTAB_CAPTION", "frmConcGastos")
        CREA_TAB(frmConcGastos, "Conceptos de Gastos")
    End Sub
    Private Sub MnuRutas_Click(sender As Object, e As EventArgs) Handles MnuRutas.Click
        BACKUPTXT("XTAB_CAPTION", "frmDetallesRutas")
        CREA_TAB(frmDetallesRutas, "Detalles Rutas")
    End Sub
    Private Sub MnuUnidades_Click(sender As Object, e As EventArgs) Handles MnuUnidades.Click
        BACKUPTXT("XTAB_CAPTION", "frmUnidades")
        CREA_TAB(frmUnidades, "Unidades")
    End Sub
    Private Sub MnuMarcasUnidades_Click(sender As Object, e As EventArgs) Handles MnuMarcasUnidades.Click
        BACKUPTXT("XTAB_CAPTION", "frmMarcaUnidad")
        CREA_TAB(frmMarcaUnidad, "Marca Unidad")
    End Sub
    Private Sub MnuTiposUnidades_Click(sender As Object, e As EventArgs) Handles MnuTiposUnidades.Click
        BACKUPTXT("XTAB_CAPTION", "frmTipoUnidad")
        CREA_TAB(frmTipoUnidad, "Tipo Unidad")
    End Sub
    Private Sub MnuModelosUnidades_Click(sender As Object, e As EventArgs) Handles MnuModelosUnidades.Click
        BACKUPTXT("XTAB_CAPTION", "frmModeloUnidad")
        CREA_TAB(frmModeloUnidad, "Modelo Unidad")
    End Sub
    Private Sub MnuGrupoUnidades_Click(sender As Object, e As EventArgs) Handles MnuGrupoUnidades.Click
        BACKUPTXT("XTAB_CAPTION", "frmGrupoUnidades")
        CREA_TAB(frmGrupoUnidades, "Grupo Unidades")
    End Sub
    Private Sub MnuInstrucViajes_Click(sender As Object, e As EventArgs) Handles MnuInstrucViajes.Click
        BACKUPTXT("XTAB_CAPTION", "frmInstrucViaje")
        CREA_TAB(frmInstrucViaje, "Instrucciones de viaje")
    End Sub
    Private Sub MnuOperadores_Click(sender As Object, e As EventArgs) Handles MnuOperadores.Click
        BACKUPTXT("XTAB_CAPTION", "frmOperadores")
        CREA_TAB(frmOperadores, "Operadores")
    End Sub
    Private Sub MnuTipoJornada1_Click(sender As Object, e As EventArgs) Handles MnuTipoJornada1.Click
        BACKUPTXT("XTAB_CAPTION", "frmTipoJornada")
        CREA_TAB(frmTipoJornada, "Tipo Jornada")
    End Sub
    Private Sub MnuPeriodicidadPago1_Click(sender As Object, e As EventArgs) Handles MnuPeriodicidadPago1.Click
        BACKUPTXT("XTAB_CAPTION", "frmPeriodicidadPago")
        CREA_TAB(frmPeriodicidadPago, "Periodicidad de pago")
    End Sub
    Private Sub MnuIncidencias1_Click(sender As Object, e As EventArgs) Handles MnuIncidencias1.Click
        BACKUPTXT("XTAB_CAPTION", "frmCatIncidencias")
        CREA_TAB(frmCatIncidencias, "Incidencias")
    End Sub
    Private Sub MnuFormasPagoEmpleados_Click(sender As Object, e As EventArgs) Handles MnuFormasPagoEmpleados.Click
        BACKUPTXT("XTAB_CAPTION", "frmFormaPagoEmpleados")
        CREA_TAB(frmFormaPagoEmpleados, "Forma Pago Empleados")
    End Sub
    Private Sub MnuRiesgoTrabajo1_Click(sender As Object, e As EventArgs) Handles MnuRiesgoTrabajo1.Click
        BACKUPTXT("XTAB_CAPTION", "frmRiesgoTrabajo")
        CREA_TAB(frmRiesgoTrabajo, "Riesgo de trabajo")
    End Sub
    Private Sub MnuClientes_Click(sender As Object, e As EventArgs) Handles MnuClientes.Click
        BACKUPTXT("XTAB_CAPTION", "frmClientes")
        CREA_TAB(frmClientes, "Clientes")
    End Sub
    Private Sub MnuConcCxC_Click(sender As Object, e As EventArgs) Handles MnuConcCxC.Click
        BACKUPTXT("XTAB_CAPTION", "frmCXC")
        CREA_TAB(frmCXC, "Conceptos Cuentas X Cobrar")
    End Sub
    Private Sub MnuProveedores_Click(sender As Object, e As EventArgs) Handles MnuProveedores.Click
        BACKUPTXT("XTAB_CAPTION", "frmProv")
        CREA_TAB(FrmProv, "Proveedores")
    End Sub
    Private Sub MnuCxP_Click(sender As Object, e As EventArgs) Handles MnuCxP.Click
        BACKUPTXT("XTAB_CAPTION", "frmCxP")
        CREA_TAB(FrmCxP, "Conceptos CxP")
    End Sub
    Private Sub BarPrograServicios_Click(sender As Object, e As EventArgs) Handles BarPrograServicios.Click
        BACKUPTXT("XTAB_CAPTION", "frmProgServicios")
        CREA_TAB(frmProgServicios, "Programación de Servicios")
    End Sub
    Private Sub BarLlantasMante_Click(sender As Object, e As EventArgs) Handles BarLlantasMante.Click
        BACKUPTXT("XTAB_CAPTION", "frmServiciosMante")
        CREA_TAB(frmServiciosMante, "Servicios de Mantenimiento")
    End Sub
    Private Sub BarLlantasAct_Click(sender As Object, e As EventArgs) Handles BarLlantasAct.Click
        BACKUPTXT("XTAB_CAPTION", "frmActividadesMante")
        CREA_TAB(frmActividadesMante, "Actividades Mantenimiento")
    End Sub
    Private Sub BarReporteLLantas_Click(sender As Object, e As EventArgs) Handles BarReporteLLantas.Click
        BACKUPTXT("XTAB_CAPTION", "frmReporteFalla")
        CREA_TAB(frmReporteFalla, "Reporte de Falla")
    End Sub
    Private Sub MnuMecanicos_Click(sender As Object, e As EventArgs) Handles MnuMecanicos.Click
        BACKUPTXT("XTAB_CAPTION", "frmMecanicos")
        CREA_TAB(frmMecanicos, "Mecanicos")
    End Sub
    Private Sub BarOrdenesDeTrabajo_Click(sender As Object, e As EventArgs) Handles BarOrdenesDeTrabajo.Click
        BACKUPTXT("XTAB_CAPTION", "frmOrdenDeTrabajo")
        Var16 = "OT"
        CREA_TAB(frmOrdenDeTrabajo, "Orden de Trabajo")
    End Sub
    Private Sub MnuGasolineras_Click(sender As Object, e As EventArgs) Handles MnuGasolineras.Click
        BACKUPTXT("XTAB_CAPTION", "frmGasolineras")
        CREA_TAB(frmGasolineras, "Gasolineras")
    End Sub
    Private Sub BarCartaPorte_Click(sender As Object, e As EventArgs) Handles BarCartaPorte.Click
        'BACKUPTXT("XTAB_CAPTION", "frmCartaPorte")
        'CREA_TAB(FrmCartaPorte, "Carta Porte")
    End Sub
    Private Sub MnuTipoDeCobro_Click(sender As Object, e As EventArgs) Handles MnuTipoDeCobro.Click
        BACKUPTXT("XTAB_CAPTION", "frmTipoDeCobro")
        CREA_TAB(frmTipoDeCobro, "Tipo de Cobro")
    End Sub
    Private Sub MnuStatus_Click(sender As Object, e As EventArgs) Handles MnuStatus.Click
        BACKUPTXT("XTAB_CAPTION", "frmStatus")
        CREA_TAB(frmStatus, "Estatus")
    End Sub
    Private Sub BarProveedores2_Click(sender As Object, e As EventArgs) Handles BarAseguradoras.Click
        BACKUPTXT("XTAB_CAPTION", "frmAseguradoras")
        CREA_TAB(frmAseguradoras, "Aseguradoras")
    End Sub
    Private Sub MnuTramosOficiales_Click(sender As Object, e As EventArgs) Handles MnuTramosOficiales.Click
        BACKUPTXT("XTAB_CAPTION", "frmTramosOficiales")
        CREA_TAB(frmTramosOficiales, "Tramos Oficiales")
    End Sub
    Private Sub BarINVER_Click(sender As Object, e As EventArgs) Handles BarINVER.Click
        'INVENTARIO REFACCIONES
        'GCINVER 
        BACKUPTXT("XTAB_CAPTION", "frmInvenR")
        CREA_TAB(FrmInvenR, "Inventario Refacciones")
    End Sub
    Private Sub BarLineasProductos_Click(sender As Object, e As EventArgs) Handles BarLineasProductos.Click
        BACKUPTXT("XTAB_CAPTION", "frmLineas")
        CREA_TAB(FrmLineas, "Lineas")
    End Sub
    Private Sub BarUniMed_Click(sender As Object, e As EventArgs) Handles BarUniMed.Click
        BACKUPTXT("XTAB_CAPTION", "frmUniMed")
        CREA_TAB(FrmUniMed, "Unidad de Medida")
    End Sub
    Private Sub BarConcMinve_Click(sender As Object, e As EventArgs) Handles BarConcMinve.Click
        BACKUPTXT("XTAB_CAPTION", "frmConM")
        CREA_TAB(FrmConM, "Conc. movs. al inv.")
    End Sub
    Private Sub MnuContacProv_Click(sender As Object, e As EventArgs) Handles MnuContacProv.Click
        BACKUPTXT("XTAB_CAPTION", "frmContap")
        CREA_TAB(frmContap, "Contactos Proveedores")
    End Sub
    Private Sub BarAutoriza_Click(sender As Object, e As EventArgs) Handles BarAutoriza.Click
        BACKUPTXT("XTAB_CAPTION", "frmAutoriza")
        CREA_TAB(frmAutoriza, "Personal Autoriza")
    End Sub
    Private Sub MnuDescOperador_Click(sender As Object, e As EventArgs) Handles MnuDescOperador.Click
        BACKUPTXT("XTAB_CAPTION", "frmDescOperador")
        CREA_TAB(frmDescOperador, "Descuento Operador")
    End Sub
    Private Sub MnuTipoDesc_Click(sender As Object, e As EventArgs) Handles MnuTipoDesc.Click
        BACKUPTXT("XTAB_CAPTION", "frmTipoDescuento")
        CREA_TAB(frmTipoDescuento, "Tipo Descuento")
    End Sub
    Private Sub MnuFormaDescuento_Click(sender As Object, e As EventArgs) Handles MnuFormaDescuento.Click
        BACKUPTXT("XTAB_CAPTION", "frmFormaDescuento")
        CREA_TAB(frmFormaDescuento, "Forma Descuento")
    End Sub
    Private Sub BarBajaViajes_Click(sender As Object, e As EventArgs) Handles BarBajaViajes.Click

        Var17 = ""
        'BACKUPTXT("XTAB_CAPTION", "FrmAsigViajeBueno")
        'CREA_TAB(FrmAsigViajeBueno, "Facturar viaje")
        'Dim args As String
        'args = Servidor & " " & Base & " " & Usuario & " " & Pass & " " & Empresa & " " & USER_GRUPOCE & " " & PASS_GRUPOCE & " " & pwPoder
        Process.Start(Application.StartupPath & "\Control de viajes.exe", Servidor & " " & Base & " " & Usuario & " " & Pass & " " & Empresa & " " & USER_GRUPOCE & " " & PASS_GRUPOCE & " " & pwPoder)

    End Sub
    Private Sub BarProveedores4_Click(sender As Object, e As EventArgs) Handles BarProdCargar.Click
        BACKUPTXT("XTAB_CAPTION", "frmProductos")
        CREA_TAB(frmProductos, "Productos")
    End Sub
    Private Sub BarEmpleados_Click(sender As Object, e As EventArgs) Handles BarEmpleados.Click
        BACKUPTXT("XTAB_CAPTION", "frmOperadores")
        CREA_TAB(frmOperadores, "Operadores")
    End Sub

    Private Sub BarServiciosDeVenta_Click(sender As Object, e As EventArgs) Handles BarServiciosDeVenta.Click
        BACKUPTXT("XTAB_CAPTION", "frmInven")
        CREA_TAB(FrmInven, "Inventario")
    End Sub
    Private Sub BarPuntosInteres_Click(sender As Object, e As EventArgs) Handles BarPuntosInteres.Click
        BACKUPTXT("XTAB_CAPTION", "frmPuntosDeInteres")
        CREA_TAB(frmPuntosDeInteres, "Puntos de Interes")
    End Sub
    Private Sub MnuValorDeclarado_Click(sender As Object, e As EventArgs) Handles MnuValorDeclarado.Click
        BACKUPTXT("XTAB_CAPTION", "frmValorDeclarado")
        CREA_TAB(frmValorDeclarado, "Valor Declarado")
    End Sub
    Private Sub BarLiquidaciones_Click(sender As Object, e As EventArgs) Handles BarLiquidaciones.Click
        BACKUPTXT("XTAB_CAPTION", "frmLiquidaciones")
        CREA_TAB(FrmLiquidaciones, "Liquidaciones")
    End Sub
    Private Sub BarMINVE_Click(sender As Object, e As EventArgs) Handles BarMINVE.Click
        BACKUPTXT("XTAB_CAPTION", "frmMinveR")
        CREA_TAB(FrmMinveR, "Movimientos al Inventario")
    End Sub
    Private Sub BarCompras_Click(sender As Object, e As EventArgs) Handles BarCompras.Click
        Var17 = ""
        BACKUPTXT("XTAB_CAPTION", "frmComprasDoc")

        CloseTab("Compras", "Recepciones", "Orden de Compra", "Requisición", "Devolución compras")

        Try
            If FORM_IS_OPEN("frmComprasTrans") Then
                FrmComprasTrans.Close()
                FrmComprasTrans.Dispose()
            Else
                If OPEN_TAB("Compras") Or OPEN_TAB("Recepciones") Or OPEN_TAB("Orden de Compra") Or OPEN_TAB("Requisición") Or OPEN_TAB("Devolución compras") Then
                    FrmComprasTrans.Close()
                    FrmComprasTrans.Dispose()
                End If
            End If
            If FORM_IS_OPEN("frmComprasDoc") Then
                frmComprasDoc.Close()
                frmComprasDoc.Dispose()
            End If
        Catch ex As Exception
        End Try

        CloseTab("Captura Compra", "Captura Recepcion", "Captura Orden de Compra", "Captura Requisición", "Captura devolución compras")

        TIPO_COMPRA = "c"
        Var17 = ""
        'frmComprasDoc.Dispose()

        CREA_TAB(frmComprasDoc, "Compras")
    End Sub
    Private Sub BarRecepciones_Click(sender As Object, e As EventArgs) Handles BarRecepciones.Click
        BACKUPTXT("XTAB_CAPTION", "frmComprasDoc")
        Var17 = ""

        CloseTab("Compras", "Recepciones", "Orden de Compra", "Requisición", "Devolución compras")

        Try
            If FORM_IS_OPEN("frmComprasTrans") Then
                FrmComprasTrans.Close()
                FrmComprasTrans.Dispose()
            Else
                If OPEN_TAB("Compras") Or OPEN_TAB("Recepciones") Or OPEN_TAB("Orden de Compra") Or OPEN_TAB("Requisición") Or OPEN_TAB("Devolución compras") Then
                    frmComprasDoc.Close()
                    frmComprasDoc.Dispose()
                End If
            End If
            If FORM_IS_OPEN("frmComprasDoc") Then
                frmComprasDoc.Close()
                frmComprasDoc.Dispose()
            End If
        Catch ex As Exception
        End Try
        CloseTab("Captura Compra", "Captura Recepcion", "Captura Orden de Compra", "Captura Requisición", "Captura devolución compras")

        TIPO_COMPRA = "r"
        Var17 = ""
        'frmComprasDoc.Dispose()
        CREA_TAB(frmComprasDoc, "Recepciones")
    End Sub
    Private Sub BarOrdenDeCompras_Click(sender As Object, e As EventArgs) Handles BarOrdenDeCompras.Click
        BACKUPTXT("XTAB_CAPTION", "frmComprasDoc")

        Var17 = ""

        CloseTab("Compras", "Recepciones", "Orden de Compra", "Requisición", "Devolución compras")

        Try
            If FORM_IS_OPEN("frmComprasTrans") Then
                FrmComprasTrans.Close()
                FrmComprasTrans.Dispose()
            Else
                If OPEN_TAB("Compras") Or OPEN_TAB("Recepciones") Or OPEN_TAB("Orden de Compra") Or OPEN_TAB("Requisición") Or OPEN_TAB("Devolución compras") Then
                    frmComprasDoc.Close()
                    frmComprasDoc.Dispose()
                End If
            End If
            If FORM_IS_OPEN("frmComprasDoc") Then
                frmComprasDoc.Close()
                frmComprasDoc.Dispose()
            End If
        Catch ex As Exception
        End Try
        CloseTab("Captura Compra", "Captura Recepcion", "Captura Orden de Compra", "Captura Requisición", "Captura devolución compras")

        Var17 = ""
        TIPO_COMPRA = "o"
        'frmComprasDoc.Dispose()
        CREA_TAB(frmComprasDoc, "Orden de Compra")
    End Sub
    Private Sub BarRequisiciones_Click(sender As Object, e As EventArgs) Handles BarRequisiciones.Click
        BACKUPTXT("XTAB_CAPTION", "frmComprasDoc")

        Var17 = ""

        CloseTab("Compras", "Recepciones", "Orden de Compra", "Requisición", "Devolución compras")

        Try
            If FORM_IS_OPEN("frmComprasTrans") Then
                FrmComprasTrans.Close()
                FrmComprasTrans.Dispose()
            Else
                If OPEN_TAB("Compras") Or OPEN_TAB("Recepciones") Or OPEN_TAB("Orden de Compra") Or OPEN_TAB("Requisición") Or OPEN_TAB("Devolución compras") Then
                    frmComprasDoc.Close()
                    frmComprasDoc.Dispose()
                End If
            End If
            If FORM_IS_OPEN("frmComprasDoc") Then
                frmComprasDoc.Close()
                frmComprasDoc.Dispose()
            End If
        Catch ex As Exception
        End Try
        CloseTab("Captura Compra", "Captura Recepcion", "Captura Orden de Compra", "Captura Requisición", "Captura devolución compras")

        TIPO_COMPRA = "q"
        Var17 = ""
        'frmComprasDoc.Dispose()
        CREA_TAB(frmComprasDoc, "Requisición")
    End Sub
    Private Sub BarParamSistema_Click(sender As Object, e As EventArgs) Handles BarParamSistema.Click

        Try
            FrmParametros.ShowDialog()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub BarOrdenesDeTrabajoExternas_Click(sender As Object, e As EventArgs) Handles BarOrdenesDeTrabajoExternas.Click
        BACKUPTXT("XTAB_CAPTION", "frmOrdenDeTrabajoExt")
        Var15 = "EXTTOT"
        Var16 = "OT"
        OT_EXT = "A"

        Select Case TIPO_OTI
            Case 0
                'If FORM_IS_OPEN("frmOrdenDeTrabajoExt") Then
                Try
                        'frmOrdenDeTrabajoExt.Close()
                        'frmOrdenDeTrabajoExt.Dispose()
                    Catch ex As Exception
                    End Try
                'End If
                CREA_TAB(frmOTI, "Ordenes de Trabajo")
            Case 1
                If FORM_IS_OPEN("frmOTI") Then
                    Try
                        frmOTI.Close()
                        frmOTI.Dispose()
                    Catch ex As Exception
                    End Try
                End If
                CREA_TAB(frmOTI, "Ordenes de Trabajo")
        End Select

    End Sub
    Private Sub MnuPlazas_Click(sender As Object, e As EventArgs) Handles MnuPlazas.Click
        BACKUPTXT("XTAB_CAPTION", "frmPlazas")
        CREA_TAB(FrmPlazas, "Plazas")
    End Sub
    Private Sub MnuMarcasLlantas_Click(sender As Object, e As EventArgs) Handles MnuMarcasLlantas.Click
        BACKUPTXT("XTAB_CAPTION", "frmMarcasLlantas")
        CREA_TAB(FrmMarcasLlantas, "Marcas Llantas")
    End Sub
    Private Sub MnuTipoLlantas_Click(sender As Object, e As EventArgs) Handles MnuTipoLlantas.Click
        BACKUPTXT("XTAB_CAPTION", "frmLlantasTipo")
        CREA_TAB(FrmLlantasTipo, "Tipo Llanta")
    End Sub
    Private Sub MnuEstatusLlantas_Click(sender As Object, e As EventArgs) Handles MnuEstatusLlantas.Click
        BACKUPTXT("XTAB_CAPTION", "frmStatusLlantas")
        CREA_TAB(frmStatusLlantas, "Status Llantas")
    End Sub
    Private Sub MnuModeloLlantas_Click(sender As Object, e As EventArgs) Handles MnuModeloLlantas.Click
        BACKUPTXT("XTAB_CAPTION", "frmModeloLlantas")
        CREA_TAB(frmModeloLlantas, "Modelo Llantas")
    End Sub
    Private Sub MnuMedidaLlantas_Click(sender As Object, e As EventArgs) Handles MnuMedidaLlantas.Click
        BACKUPTXT("XTAB_CAPTION", "frmMedidasLlantas")
        CREA_TAB(frmMedidasLlantas, "Medidas Llantas")
    End Sub
    Private Sub MnuLlantas_Click(sender As Object, e As EventArgs) Handles MnuLlantas.Click
        BACKUPTXT("XTAB_CAPTION", "frmLlantas")
        CREA_TAB(FrmLlantas, "Llantas")
    End Sub
    Private Sub MnuOrdenesDeTrabajo_Click(sender As Object, e As EventArgs) Handles MnuOrdenesDeTrabajo.Click
        'BACKUPTXT("XTAB_CAPTION", "frmOrdenDeTrabajoExt")
        'CREA_TAB(frmOrdenDeTrabajoExt, "Orden de Trabajo Externa")
    End Sub
    Private Sub MnuReporteDeFallas_Click(sender As Object, e As EventArgs) Handles MnuReporteDeFallas.Click
        BACKUPTXT("XTAB_CAPTION", "frmReporteFalla")
        CREA_TAB(frmReporteFalla, "Reporte de Falla")
    End Sub
    Private Sub BarAlmacenes_Click(sender As Object, e As EventArgs) Handles BarAlmacenes.Click
        BACKUPTXT("XTAB_CAPTION", "frmAlmacenes")
        CREA_TAB(FrmAlmacenes, "Almacenes")
    End Sub
    Private Sub MnuAltaCxP_Click(sender As Object, e As EventArgs) Handles MnuAltaCxP.Click
        BACKUPTXT("XTAB_CAPTION", "frmAltaCxP")
        CREA_TAB(FrmAltaCxP, "Alta CxP")
    End Sub
    Private Sub BarMultialmacen_Click(sender As Object, e As EventArgs) Handles BarMultialmacen.Click
        BACKUPTXT("XTAB_CAPTION", "frmMultiAlmacen")
        CREA_TAB(FrmMultiAlmacen, "Multialmacén")
    End Sub
    Private Sub BarCatStatusViaje_Click(sender As Object, e As EventArgs) Handles BarCatStatusViaje.Click
        BACKUPTXT("XTAB_CAPTION", "frmCatStatusViaje")
        CREA_TAB(frmCatStatusViaje, "Estatus Viaje")
    End Sub
    Private Sub BarCatStatusUnidades_Click(sender As Object, e As EventArgs) Handles BarCatStatusUnidades.Click
        BACKUPTXT("XTAB_CAPTION", "frmCatStatusUnidades")
        CREA_TAB(frmCatStatusUnidades, "Cat. Estatus Unidades")
    End Sub

    Private Sub BarStatusUnidades_Click(sender As Object, e As EventArgs) Handles BarStatusUnidades.Click
        BACKUPTXT("XTAB_CAPTION", "frmEstatusUnidades")
        CREA_TAB(FrmEstatusUnidades, "Estatus Unidades")
    End Sub
    Private Sub BarAsignacionViajes_Click(sender As Object, e As EventArgs) Handles BarAsignacionViajes.Click
        BACKUPTXT("XTAB_CAPTION", "frmAsignacionViaje")

        CREA_TAB(FrmAsignacionViaje, "Asignación de Viajes")


    End Sub
    Private Sub BarTabRutas_Click(sender As Object, e As EventArgs) Handles BarTabRutas.Click
        BACKUPTXT("XTAB_CAPTION", "frmTabRutas")
        CREA_TAB(frmTabRutas, "Tabulador de rutas")
    End Sub
    Private Sub MnuClientesOperativos_Click(sender As Object, e As EventArgs) Handles MnuClientesOperativos.Click
        BACKUPTXT("XTAB_CAPTION", "frmClientesOperativos")

        Var17 = ""

        CREA_TAB(FrmClientesOperativos, "Clientes Operativos")
    End Sub
    Private Sub MnuStGastosViaje_Click(sender As Object, e As EventArgs) Handles MnuStGastosViaje.Click
        BACKUPTXT("XTAB_CAPTION", "frmSt_Gastos_Viaje")
        CREA_TAB(frmSt_Gastos_Viaje, "Estatus Gastos de Viaje")
    End Sub
    Private Sub MnuStCartaPorte_Click(sender As Object, e As EventArgs) Handles MnuStCartaPorte.Click
        BACKUPTXT("XTAB_CAPTION", "frmStCartaPorte")
        CREA_TAB(frmStCartaPorte, "Estatus carta Porte")
    End Sub
    Private Sub MnuStLiquidacion_Click(sender As Object, e As EventArgs) Handles MnuStLiquidacion.Click
        BACKUPTXT("XTAB_CAPTION", "frmStLiquidacion")
        CREA_TAB(frmStLiquidacion, "Estatus liquidacion")
    End Sub
    Private Sub MnuStValeCombustible_Click(sender As Object, e As EventArgs) Handles MnuStValeCombustible.Click
        BACKUPTXT("XTAB_CAPTION", "frmStValeCombustible")
        CREA_TAB(frmStValeCombustible, "Estatus vale combustible")
    End Sub
    Private Sub MnuConciliacionValesCombustible_Click(sender As Object, e As EventArgs) Handles MnuConciliacionValesCombustible.Click
        BACKUPTXT("XTAB_CAPTION", "frmConciValesCombus")
        CREA_TAB(FrmConciValesCombus, "Conciliación Vales Combustible")
    End Sub
    Private Sub MnuValeCombustible_Click(sender As Object, e As EventArgs) Handles MnuValeCombustible.Click
        BACKUPTXT("XTAB_CAPTION", "frmValeCombustible")
        CREA_TAB(frmValeCombustible, "Vale Combustible")
    End Sub
    Private Sub BarDisenador_Click(sender As Object, e As EventArgs) Handles BarDisenador.Click
        BACKUPTXT("XTAB_CAPTION", "frmArchivosReportes")
        CREA_TAB(frmArchivosReportes, "Formatos")
    End Sub
    Private Sub BarConcilCartaPorte_Click(sender As Object, e As EventArgs) Handles BarConcilCartaPorte.Click
        BACKUPTXT("XTAB_CAPTION", "frmconcicartaporte")
        CREA_TAB(frmConciCartaPorte, "Conciliación Cartas Porte")
    End Sub
    Private Sub MnuAltaCxC_Click(sender As Object, e As EventArgs) Handles MnuAltaCxC.Click
        BACKUPTXT("XTAB_CAPTION", "frmAltaCxC")
        CREA_TAB(frmAltaCxC, "Alta CxC")
    End Sub
    Private Sub MnuEdoCuenta_Click(sender As Object, e As EventArgs) Handles MnuEdoCuenta.Click
        BACKUPTXT("XTAB_CAPTION", "frmEstadoCuentaClie")
        CREA_TAB(frmEstadoCuentaClie, "Estado de cuenta")
    End Sub
    Private Sub BarTesoreria_Click(sender As Object, e As EventArgs) Handles BarTesoreria.Click
        BACKUPTXT("XTAB_CAPTION", "frmTesoreria")
        CREA_TAB(FrmTesoreria, "Tesoreria")
    End Sub
    Private Sub BarTabuladorCombustible_Click(sender As Object, e As EventArgs) Handles BarTabuladorCombustible.Click
        BACKUPTXT("XTAB_CAPTION", "frmTabuladorCombustibleAE")
        CREA_TAB(frmTabuladorCombustibleAE, "Tabulador combustible")
    End Sub
    Private Sub BarMovsInvOT_Click(sender As Object, e As EventArgs) Handles BarMovsInvOT.Click
        BACKUPTXT("XTAB_CAPTION", "frmOrdenDeTrabajoExtMovsInv")
        Var15 = "EXTTOT"
        Var16 = "MIOT"
        CREA_TAB(frmOrdenDeTrabajoExtMovsInv, "Movs. Ordenes de Trabajo")
    End Sub
    Private Sub BarMinveTOT_Click(sender As Object, e As EventArgs) Handles BarMinveTOT.Click
        BACKUPTXT("XTAB_CAPTION", "frmMinveSae")
        CREA_TAB(FrmMinveSae, "Movimientos al Inventario")
    End Sub
    Private Sub BarServiciosDeInventario_Click(sender As Object, e As EventArgs) Handles BarServiciosDeInventario.Click
        'SERVICIOS DE INVENTARIO
        'INVE01
        BACKUPTXT("XTAB_CAPTION", "frmInven")
        CREA_TAB(FrmInven, "Inventario")
    End Sub
    Private Sub BarCotizaciones_Click(sender As Object, e As EventArgs) Handles BarCotizaciones.Click
        BACKUPTXT("XTAB_CAPTION", "frmDocumentos")
        Var4 = ""
        TIPO_VENTA = "C"
        CREA_TAB(FrmDocumentos, "Documentos")
    End Sub
    Private Sub BarDerechosUsuarios_Click(sender As Object, e As EventArgs) Handles BarDerechosUsuarios.Click
        BACKUPTXT("XTAB_CAPTION", "frmDerechos")
        CREA_TAB(FrmDerechos, "Derechos")
    End Sub
    Private Sub BarRemisiones_Click(sender As Object, e As EventArgs) Handles BarRemisiones.Click
        BACKUPTXT("XTAB_CAPTION", "frmFACTURAS")
        Var4 = ""
        TIPO_VENTA = "R"
        CREA_TAB(FrmDocumentos, "Documentos")
    End Sub
    Private Sub BarBitacora_Click(sender As Object, e As EventArgs) Handles BarBitacora.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmBitacora")
            CREA_TAB(frmBitacora, "Bitacora")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim MENSAJE As String = ""
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                'SQL = "Select ISNULL(MENSAJE,'') AS MENSA FROM CONFIG"
                'cmd.CommandText = SQL
                'Using dr As SqlDataReader = cmd.ExecuteReader
                'If dr.Read Then
                'MENSAJE = dr("MENSA")
                'End If
                'End Using
            End Using
            If MENSAJE.Trim.Length > 0 Then
                If MessageBox.Show("MENSAJE", "Información", MessageBoxButtons.YesNo) = vbYes Then
                    Try
                        'Using cmd As SqlCommand = cnSAROCE.CreateCommand
                        'SQL = "UPDATE CONFIG SET MENSAJE = ''"
                        'cmd.CommandText = SQL
                        'returnValue = cmd.ExecuteNonQuery().ToString
                        'If returnValue IsNot Nothing Then
                        'If returnValue = "1" Then
                        'End If
                        'End If
                        '       End Using
                    Catch ex As Exception
                        Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarOrdenDeTrabajoManto_Click(sender As Object, e As EventArgs) Handles BarOrdenDeTrabajoManto.Click
        Dim C93000 As Boolean, C93090 As Boolean, z As Integer = 0

        If Not Valida_Conexion() Then
            Return
        End If
        Try
            SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 93000"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Select Case dr("CLAVE")
                            Case 93000
                                C93000 = True
                            Case 93090
                                C93090 = True
                        End Select
                        z += 1
                    End While
                End Using
            End Using
            If z = 0 Then
                C93000 = True
            End If
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        OT_EXT = "M"
        Select Case TIPO_OTI
            Case 0
                'BACKUPTXT("XTAB_CAPTION", "frmMantenimientoExterno")
                'CREA_TAB(frmMantenimientoExterno, "Mantenimiento Externo")
            Case 1
                BACKUPTXT("XTAB_CAPTION", "frmOTEAE")
                CREA_TAB(frmOTE, "Mantenimiento Externo")
        End Select
    End Sub
    Private Sub BarTrazabilidad_Click(sender As Object, e As EventArgs)
        BACKUPTXT("XTAB_CAPTION", "frmTrazabilidad")
        CREA_TAB(frmTrazabilidad, "Trazabilidad")
    End Sub
    Private Sub BarActulizacionPrecios_Click(sender As Object, e As EventArgs) Handles BarActulizacionPrecios.Click
        Try
            If MsgBox("Realmente desea actualizar el costo prom. + 1 peso en el precio 2?", vbYesNo) = vbNo Then
                Return
            End If
            Me.Cursor = Cursors.WaitCursor

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ART, ISNULL(COSTO_PROM,0) AS COST_PROM FROM INVE" & Empresa & " ORDER BY CVE_ART"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()

                        Try
                            If dr("COST_PROM") > 0 Then
                                SQL = "UPDATE PRECIO_X_PROD" & Empresa & " SET PRECIO = " & Math.Round((dr("COST_PROM") + 1), 4) &
                                " WHERE CVE_ART = '" & dr("CVE_ART") & "' AND CVE_PRECIO = 2"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            End If
                        Catch ex As Exception
                            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
            Me.Cursor = Cursors.Default

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarValidarCierre_Click(sender As Object, e As EventArgs) Handles BarValidarCierre.Click
        'frmValidarCierre.ShowDialog()
    End Sub
    Private Sub BarReporteFacturas_Click(sender As Object, e As EventArgs) Handles BarReporteFacturas.Click
        BACKUPTXT("XTAB_CAPTION", "frmReporteFactutras")
        CREA_TAB(frmReporteFacturas, "Reporte facturas")
    End Sub
    Private Sub BarAsigLLantasExcel_Click(sender As Object, e As EventArgs) Handles BarAsigLLantasExcel.Click
        CREA_TAB(FrmUtilerias, "UTILERIAS")
    End Sub
    Private Sub BarTools2_Click(sender As Object, e As EventArgs) Handles BarTools2.Click
        'frmUtils.ShowDialog()
    End Sub
    Private Sub MnuPedidos_Click(sender As Object, e As EventArgs) Handles MnuPedidos.Click
        BACKUPTXT("XTAB_CAPTION", "frmPedidos")
        CREA_TAB(frmPedidos, "Pedidos")
    End Sub
    Private Sub MnuCotizador_Click(sender As Object, e As EventArgs) Handles MnuCotizador.Click
        BACKUPTXT("XTAB_CAPTION", "frmCotizador")
        CREA_TAB(frmCotizador, "Cotizador")
    End Sub

    Private Sub BarReset_Click_1(sender As Object, e As EventArgs) Handles BarReset.Click
        BACKUPTXT("XTAB_CAPTION", "frmReseteo")
        CREA_TAB(frmReseteo, "Reseteo")
    End Sub
    Private Sub BarAjustarKardex1_Click(sender As Object, e As EventArgs) Handles BarAjustarKardex1.Click
        Try
            If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Or PASS_GRUPOCE = "FRAJA" Or PASS_GRUPOCE = "WINAS" Or PASS_GRUPOCE = "GBASYS61" Then
                frmKardexAjustar.ShowDialog()
            Else
                MessageBox.Show("Acceso no autorizado")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarExportarUnidades_Click(sender As Object, e As EventArgs) Handles BarExportarUnidades.Click
        'frmImportarUnidades.ShowDialog()
    End Sub

    Private Sub BarRecogerEnEntregarEn_Click(sender As Object, e As EventArgs) Handles BarRecogerEnEntregarEn.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmCatEntregarEnRecogerEn.frm")
            CREA_TAB(frmCatEntregarEnRecogerEn, "Catálogo entregar En/recoger En")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarReportePrecioCostos_Click(sender As Object, e As EventArgs) Handles BarReportePrecioCostos.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmReportePrecioCostos")
            CREA_TAB(frmReportePrecioCostos, "Reporte precio costos")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarReporteNotasFacturas_Click(sender As Object, e As EventArgs) Handles BarReporteNotasFacturas.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmReporteVentasFacturas")
            CREA_TAB(ReporteVentasFacturas, "Reporte notas facturas")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarReporteOrdenesTrabajo_Click(sender As Object, e As EventArgs) Handles BarReporteOrdenesTrabajo.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmReporteOrdenDeTRabajo")
            CREA_TAB(frmReporteOrdenDeTRabajo, "Reporte ordenes de trabajo")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarReporteDeUnidades_Click(sender As Object, e As EventArgs) Handles BarReporteDeUnidades.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmReporteDeUnidades")
            CREA_TAB(frmReporteDeUnidades, "Reporte de unidades")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarReporteDeRefacciones_Click(sender As Object, e As EventArgs) Handles BarReporteDeRefacciones.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmReporteDeRefacciones")
            CREA_TAB(frmReporteDeRefacciones, "Reporte de refacciones")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarReporteDeTallerExterno_Click(sender As Object, e As EventArgs) Handles BarReporteDeTallerExterno.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmReporteTallerExterno")
            CREA_TAB(frmReporteTallerExterno, "Reporte de taller externo")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarNivelCombustible_Click(sender As Object, e As EventArgs) Handles BarNivelCombustible.Click
        BACKUPTXT("XTAB_CAPTION", "frmNivelCombustible")
        CREA_TAB(frmNivelCombustible, "Nivel de Combustible")
    End Sub

    Private Sub BarMedicionCombustible_Click(sender As Object, e As EventArgs) Handles BarMedicionCombustible.Click
        BACKUPTXT("XTAB_CAPTION", "frmMedicionCombustible")

        CREA_TAB(frmMedicionCombustible, "Medición de Combustible")

    End Sub

    Public Sub StartStop()
        Try
            Dim servicesButNotDevices As ServiceController() = ServiceController.GetServices()
            Dim servicio As String

            For Each service As ServiceController In servicesButNotDevices
                servicio = service.ServiceName
                If servicio.Length >= 5 Then
                    servicio = servicio.Substring(0, 5)
                End If '                                                         SQLBrowser 1
                If servicio.ToUpper = "MSSQL" Or service.ServiceName.ToUpper = "SQLBROWSER" Then
                    If service.Status = ServiceControllerStatus.Stopped Then
                        service.Start()
                    End If
                End If
            Next
        Catch ex As Exception
            ' Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarTabuladorCombustible1_Click(sender As Object, e As EventArgs) Handles BarCatTanques.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmReporteTallerExterno")
            CREA_TAB(frmTanques, "Catálogo tanques")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarIndicadorDepto_Click(sender As Object, e As EventArgs) Handles BarIndicadorDepto.Click
        Try
            CREA_TAB(FrmIndicadorDepto, "Indicadores del departamento")
        Catch ex As Exception
        End Try
    End Sub


    Public Function IsConnected(ServerName As String, UserID As String, Password As String) As Boolean
        Dim connStr As String = String.Format("Data Source={0}", ServerName)
        If Not String.IsNullOrEmpty(UserID) Then
            connStr &= String.Format(";User ID={0};Password={1}", UserID, Password)
        Else
            connStr &= ";Integrated Security=True"
        End If
        Return IsConnected(connStr)
    End Function

    Public Function IsConnected(Connection As String) As Boolean
        Static conn As SqlConnection
        If conn Is Nothing Then
            conn = New SqlConnection(Connection)
            conn.Open()
        End If
        Return IsConnected(conn)
    End Function

    Public Function IsConnected(ByRef Conn As SqlConnection) As Boolean
        If Conn IsNot Nothing Then Return (Conn.State = ConnectionState.Open)
        Return False
    End Function

    Private Sub MnuMotores_Click(sender As Object, e As EventArgs) Handles MnuMotores.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmMotores")
            CREA_TAB(frmMotores, "Motores")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarCatEvaluaciones_Click(sender As Object, e As EventArgs) Handles BarCatEvaluaciones.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmCatEvaluaciones")
            CREA_TAB(frmCatEvaluaciones, "Cat. evaluaciones")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub MnuManagamentSQL_Click(sender As Object, e As EventArgs) Handles MnuManagamentSQL.Click
        Try
            'If PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
            'FrmSQL.Show()
            'End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarPolizaDeCompras_Click(sender As Object, e As EventArgs) Handles BarPolizaDeCompras.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmPolizaCompras")
            CREA_TAB(FrmPolizaCompras, "Póliza compras")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarStatusOperadores_Click(sender As Object, e As EventArgs) Handles BarStatusOperadores.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "FrmSeguimientoViajes")
            CREA_TAB(FrmSeguimientoViajes, "Seguimiento viajes")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarCatStatusOper_Click(sender As Object, e As EventArgs) Handles BarCatStatusOper.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmCatStatusOper")
            CREA_TAB(frmCatStatusOper, "Cat. St. operador")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarCriteriosEva_Click(sender As Object, e As EventArgs) Handles BarCriteriosEva.Click
        Try
            BACKUPTXT("XTAB_CAPTION", "frmCriteriosEva")
            CREA_TAB(frmCriteriosEva, "Criterios evaluación")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarConciliacionValesCombus_Click(sender As Object, e As EventArgs) Handles BarConciliacionValesCombus.Click
        BACKUPTXT("XTAB_CAPTION", "frmConciValesCombus")
        CREA_TAB(FrmConciValesCombus, "Conciliación Vales Combustible")
    End Sub

    Private Sub BarConsignacion2_Click(sender As Object, e As EventArgs) Handles BarConsignacion2.Click
        BACKUPTXT("XTAB_CAPTION", "frmSueldoOperadores")
        CREA_TAB(frmSueldoOperadores, "Sueldo operadores")
    End Sub
    Private Sub BarDeducciones_Click(sender As Object, e As EventArgs) Handles BarDeducciones.Click
        BACKUPTXT("XTAB_CAPTION", "frmDeducciones")
        CREA_TAB(FrmDeducciones, "Deducciones")
    End Sub
    Private Sub BarAsignacionDiesel_Click(sender As Object, e As EventArgs) Handles BarAsignacionDiesel.Click
        BACKUPTXT("XTAB_CAPTION", "frmAsignacionDiesel")
        CREA_TAB(frmAsignacionDiesel, "Asignación diesel")
    End Sub

    Private Sub MnuServiciosXUnidad_Click(sender As Object, e As EventArgs) Handles RMante_Rep_ServiciosXUnidad.Click
        BACKUPTXT("XTAB_CAPTION", "frmServiciosXUnidad")
        Try
            frmServiciosXUnidad.ShowDialog()
        Catch ex As Exception
            frmServiciosXUnidad.Show()
        End Try
        'CREA_TAB(frmServiciosXUnidad, "Servicios x unidad")
    End Sub
    Private Sub MnuRepExistALaFecha_Click_1(sender As Object, e As EventArgs) Handles RMante_Rep_ExistALaFecha.Click
        BACKUPTXT("XTAB_CAPTION", "frmExistAUnaFecha")
        Var4 = "Existencia a una fecha"
        Try
            frmExistAUnaFecha.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuRepCompras_Click_1(sender As Object, e As EventArgs) Handles RMante_Rep_Compras.Click
        BACKUPTXT("XTAB_CAPTION", "frmExistAUnaFecha")
        Var4 = "Reporte de compras"

        Try
            frmExistAUnaFecha.ShowDialog()
        Catch ex As Exception
            frmExistAUnaFecha.Show()
        End Try
    End Sub
    Private Sub MnuRepComprasXProveedor_Click_1(sender As Object, e As EventArgs) Handles RMante_Rep_ComprasXProveedor.Click
        BACKUPTXT("XTAB_CAPTION", "frmExistAUnaFecha")
        Var4 = "Compras por proveedor"

        Try
            frmExistAUnaFecha.ShowDialog()
        Catch ex As Exception
            frmExistAUnaFecha.Show()
        End Try
    End Sub
    Private Sub MnuSalGenDetDeLlantas_Click_1(sender As Object, e As EventArgs) Handles RMante_Rep_SalGenDetDeLlantas.Click
        BACKUPTXT("XTAB_CAPTION", "frmExistAUnaFecha")
        Var4 = "Salida de llantas por unidad"
        Try
            frmExistAUnaFecha.ShowDialog()
        Catch ex As Exception
            frmExistAUnaFecha.Show()
        End Try
    End Sub
    Private Sub MnuDetOC_Click(sender As Object, e As EventArgs) Handles RMante_Rep_DetOC.Click
        BACKUPTXT("XTAB_CAPTION", "frmExistAUnaFecha")
        Var4 = "Detallado de ordenes de compra"
        Try
            frmExistAUnaFecha.ShowDialog()
        Catch ex As Exception
            frmExistAUnaFecha.Show()
        End Try
    End Sub
    Private Sub BarRemisionCartaPorte_Click(sender As Object, e As EventArgs) Handles BarRemisionCartaPorte.Click
        Try
            Var4 = "CARTA PORTE"
            BACKUPTXT("XTAB_CAPTION", "frmDocumentos")
            TIPO_VENTA = "R"
            CREA_TAB(FrmDocumentos, "Documentos")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarDeducOper_Click(sender As Object, e As EventArgs) Handles BarDeducOper.Click
        CREA_TAB(FrmDeducOper, "Deducciones operadores")
    End Sub
    Private Sub BarRecepcionPagosCompras_Click(sender As Object, e As EventArgs) Handles BarRecepcionPagosCompras.Click
        FrmRecepcionPagosCompras.ShowDialog()
    End Sub
    Private Sub MnuRepSalOperYMec_Click(sender As Object, e As EventArgs) Handles RMante_Rep_SalOperYMec.Click
        FrmRepSalidasOperYMec.ShowDialog()
    End Sub
    Private Sub BarGastosXManteDeUni_Click(sender As Object, e As EventArgs) Handles RMante_Rep_GastosXManteDeUni.Click
        FrmGastosManteXUni.Show()
    End Sub
    Private Sub BarOperacionDiaria_Click(sender As Object, e As EventArgs) Handles BarOperacionDiaria.Click
        FrmOperacionDiaria.ShowDialog()
    End Sub
    Private Sub BarBitacoraUsuarios_Click(sender As Object, e As EventArgs) Handles BarBitacoraUsuarios.Click
        CREA_TAB(frmBitacora, "Bitácora")
    End Sub

    Private Sub MnuActCostoViaMinveCompra_Click(sender As Object, e As EventArgs) Handles MnuActCostoViaMinveCompra.Click
        'frmUpateCostos.ShowDialog()
    End Sub

    Private Sub MnuValidarImportesFacturas_Click(sender As Object, e As EventArgs) Handles MnuValidarImportesFacturas.Click
        Try
            'CREA_TAB(frmValidaFacturas, "Validar facturas")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuImportarAccess_Click(sender As Object, e As EventArgs) Handles MnuImportarAccess.Click
        Try
            'CREA_TAB(frmImportarAccess, "Importar desde access")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuExportarTablas_Click(sender As Object, e As EventArgs) Handles MnuExportarTablas.Click
        'frmExportarTablasEmpresaToEmpresa.ShowDialog()
    End Sub

    Private Sub MnuImportarExcel_Click(sender As Object, e As EventArgs) Handles MnuImportarExcel.Click
        'frmImportarExcelToTabla.Show()
    End Sub

    Private Sub RemoverCaracEspeciales_Click(sender As Object, e As EventArgs) Handles RemoverCaracEspeciales.Click
        frmQuitarCaracEspeciales.ShowDialog()
    End Sub

    Private Sub MnubackupBase_Click(sender As Object, e As EventArgs) Handles MnubackupBase.Click
        Dim RUTA_SQL As String = ""

        If MsgBox("Realmente desea respaldar la base de datos?", vbYesNo) = vbYes Then
            Try
                SQL = "EXEC master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer',N'BackupDirectory'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            RUTA_SQL = dr(1)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("52. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("52. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                SQL = "BACKUP DATABASE [" & cnSAE.Database & "] TO  DISK = N'" & cnSAE.Database.Replace("SAE", "S") &
                  "_T_" & Format(DateTime.Now.Day, "00") & Format(TimeOfDay.Minute, "00") &
                  ".bak' WITH NOFORMAT, INIT, NAME = N'" & cnSAE.Database &
                  "-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End Using
                Process.Start("explorer.exe", RUTA_SQL)
            Catch ex As Exception
                Bitacora("52. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("52. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub MnuOTMInve_Click(sender As Object, e As EventArgs) Handles MnuOTMInve.Click
        CREA_TAB(FrmMinveSeguimiento, "Generar Minve no realizados")
    End Sub
    Private Sub MnuDetalladoCompras_Click(sender As Object, e As EventArgs) Handles MnuDetalladoCompras.Click
        CREA_TAB(FrmDetalladoCompras, "Detallado compras")
    End Sub
    Private Sub BarDetalladoCompras_Click(sender As Object, e As EventArgs) Handles RMante_Rep_DetalladoCompras.Click
        Var4 = "Detallado compras"
        Try
            frmExistAUnaFecha.ShowDialog()
        Catch ex As Exception
            frmExistAUnaFecha.Show()
        End Try
    End Sub
    Private Sub MnuCasetas_Click(sender As Object, e As EventArgs) Handles MnuCasetas.Click
        CREA_TAB(frmCasetas, "Casetas")
    End Sub

    Private Sub BarCasetasXRuta_Click(sender As Object, e As EventArgs) Handles BarCasetasXRuta.Click
        CREA_TAB(FrmCasetasXRuta, "Casetas por ruta")
    End Sub
    Private Sub MnuSalidasLLantasXUnidad_Click(sender As Object, e As EventArgs) Handles RMante_Rep_SalidasLLantasXUnidad.Click
        Var4 = ""
        Try
            frmSalidaLLantasXUnidad.ShowDialog()
        Catch ex As Exception
            frmSalidaLLantasXUnidad.Show()
        End Try
    End Sub
    Private Sub BarPolizaSalidaLLantas_Click(sender As Object, e As EventArgs)
        CREA_TAB(FrmPolizaSalidaLLantas, "Poliza salida llantas")
    End Sub
    Private Sub MNUActPrecios_Click(sender As Object, e As EventArgs) Handles MNUActPrecios.Click
        CREA_TAB(FrmActPrecios, "Actualización de precios")
    End Sub

    Private Sub BraProgPedidos_Click(sender As Object, e As EventArgs) Handles BraProgPedidos.Click
        CREA_TAB(FrmProgPedidos, "Programación de pedidos")
    End Sub
    Private Sub BarTarjetaIAVE_Click(sender As Object, e As EventArgs)
        CREA_TAB(frmTarjetaIAVE, "Tarjetas IAVE")
    End Sub
    Private Sub BarReporteLiq_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub BarCFDICartaPorte_Click(sender As Object, e As EventArgs)
        'CREA_TAB(FrmCFDIConCP, "Carta porte")
    End Sub
    Private Sub BarTabRutasFlex_Click(sender As Object, e As EventArgs) Handles BarTabRutasFlex.Click
        Var10 = "F"
        CREA_TAB(FrmTabRutasHoja, "Tab. rutas")
    End Sub
    Private Sub BarComprasDev_Click(sender As Object, e As EventArgs) Handles BarComprasDev.Click
        BACKUPTXT("XTAB_CAPTION", "frmComprasDoc")
        Var17 = ""

        CloseTab("Compras", "Recepciones", "Orden de Compra", "Requisición", "Devolución compras")

        Try
            If FORM_IS_OPEN("frmComprasTrans") Then
                FrmComprasTrans.Close()
                FrmComprasTrans.Dispose()
            Else
                If OPEN_TAB("Compras") Or OPEN_TAB("Recepciones") Or OPEN_TAB("Orden de Compra") Or OPEN_TAB("Requisición") Or OPEN_TAB("Devolución compras") Then
                    frmComprasDoc.Close()
                    frmComprasDoc.Dispose()
                End If
            End If
            If FORM_IS_OPEN("frmComprasDoc") Then
                frmComprasDoc.Close()
                frmComprasDoc.Dispose()
            End If
        Catch ex As Exception
        End Try
        CloseTab("Captura Compra", "Captura Recepcion", "Captura Orden de Compra", "Captura Requisición", "Captura devolución compras")
        TIPO_COMPRA = "d"
        Var17 = ""
        'frmComprasDoc.Dispose()
        CREA_TAB(frmComprasDoc, "Devolución compras")
    End Sub
    Private Sub MnuGastoRenovado_Click(sender As Object, e As EventArgs) Handles MnuGastoRenovado.Click
        CREA_TAB(FrmGastoRenovado, "Gasto renovado")
    End Sub
    Private Sub BarDevolucionVentas_Click(sender As Object, e As EventArgs) Handles BarDevolucionVentas.Click
        Var4 = ""
        TIPO_VENTA = "D"
        CREA_TAB(FrmDocumentos, "Documentos")
    End Sub
    Private Sub BarAcercaDe_Click(sender As Object, e As EventArgs) Handles BarAcercaDe.Click
        FrmAcercaDe.ShowDialog()
    End Sub
    Private Sub BarReporteDeduc_Click(sender As Object, e As EventArgs) Handles BarReporteDeduc.Click
        FrmReporteDeduc.ShowDialog()
    End Sub

    Private Sub MbuPagoComplemento_Click(sender As Object, e As EventArgs) Handles MnuPagoComplemento.Click
        CREA_TAB(FrmPagoComplemento, "Complemento de pago")
    End Sub

    Private Sub BarPolizaVentaFlete_Click(sender As Object, e As EventArgs) Handles BarPolizaVentaFlete.Click
        CREA_TAB(FrmPolizaVentasFlete, "Póliza ventas flete")
    End Sub
    Private Sub BarPolizaVentaOtros_Click(sender As Object, e As EventArgs) Handles BarPolizaVentaOtros.Click
        CREA_TAB(FrmPolizaVentasOtros, "Poliza ventas otros")
    End Sub

    Private Sub BarResumenFacturas_Click(sender As Object, e As EventArgs) Handles BarResumenFacturas.Click
        CREA_TAB(FrmTransResumenFac, "Resumen de facturas")
    End Sub
    Private Sub BarResumenFacturas1_Click(sender As Object, e As EventArgs) Handles BarResumenFacturas1.Click
        FrmRelacionKM.ShowDialog()
    End Sub
    Private Sub MnuReportLiq_Click(sender As Object, e As EventArgs) Handles MnuReportLiq.Click
        FrmReportLiq.ShowDialog()
    End Sub
    Private Sub MnuViajesLiqui_Click(sender As Object, e As EventArgs) Handles MnuViajesLiqui.Click
        FrmReportViajesLiq.ShowDialog()
    End Sub
    Private Sub BarPolizaManteExt_Click(sender As Object, e As EventArgs)
        CREA_TAB(FrmPolizaMantExt, "Poliza mantenimiento externo")
    End Sub
    Private Sub BarValidaOT_Click(sender As Object, e As EventArgs) Handles RMante_Rep_ValidaOT.Click
        FrmReportOTTerPen.ShowDialog()
    End Sub
    Private Sub RibDieselReconocido_Click(sender As Object, e As EventArgs) Handles RibDieselReconocido.Click
        FrmReporDieselReconocido.ShowDialog()
    End Sub
    Private Sub BarPolizaEgresosDiesel_Click(sender As Object, e As EventArgs) Handles BarPolizaEgresosDiesel.Click
        CREA_TAB(FrmPolizaDiesel, "Pólizas Provisión Diesel")
    End Sub
    Private Sub BarPolizaFoliosDinero_Click(sender As Object, e As EventArgs) Handles BarPolizaFoliosDinero.Click
        CREA_TAB(FrmPolizaFoliosDinero, "Poliza folios dinero")
    End Sub

    Private Sub RibPolizasManteExterno_Click(sender As Object, e As EventArgs) Handles RibPolizasManteExterno.Click
        CREA_TAB(FrmPolizaProvisionOTE, "Póliza Provisión OT Ext.")
    End Sub
    Private Sub RibPolizasManteInterno_Click(sender As Object, e As EventArgs) Handles RibPolizasManteInterno.Click
        Try
            CREA_TAB(FrmPolizaMantenimiento, "Poliza de mantenimiento")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RibPolizasSalidaLLantas_Click(sender As Object, e As EventArgs) Handles RibPolizasSalidaLLantas.Click
        CREA_TAB(FrmPolizaSalidaLLantas, "Poliza salida llantas")
    End Sub

    Private Sub RibPolizasOT_Click(sender As Object, e As EventArgs) Handles RibPolizasOT.Click
        CREA_TAB(FrmPolizaOdeT, "Poliza orden de trabajo")
    End Sub
    Private Sub RibPolizasRenovado_Click(sender As Object, e As EventArgs) Handles RibPolizasRenovado.Click
        CREA_TAB(FrmPolizaRenovados, "Poliza renovados")
    End Sub
    Private Sub BarAlmacenesR_Click(sender As Object, e As EventArgs) Handles BarAlmacenesR.Click
        CREA_TAB(FrmAlmacenesR, "Almacenes refacciones")
    End Sub
    Private Sub BarMultialmacenR_Click(sender As Object, e As EventArgs) Handles BarMultialmacenR.Click
        CREA_TAB(FrmMultiAlmacenR, "Multialmacén refacciones")
    End Sub
    Private Sub BarAlmacenesF_Click(sender As Object, e As EventArgs)
        CREA_TAB(FrmAlmacenesF, "Almacenes activo fijo")
    End Sub
    Private Sub BarMultialmacenF_Click(sender As Object, e As EventArgs)
        CREA_TAB(FrmMultiAlmacenF, "Multialmacén activo fijo")
    End Sub
    Private Sub BarPolizaEgresos_Click(sender As Object, e As EventArgs) Handles BarPolizaEgresos.Click
        CREA_TAB(FrmPolizaEgreso, "Poliza egreso")
    End Sub
    Private Sub RibRecepPagosCxC_Click(sender As Object, e As EventArgs) Handles RibRecepPagosCxC.Click
        frmRecepcionPagosCxC.ShowDialog()
    End Sub
    Private Sub MnuCtaBanOrd_Click(sender As Object, e As EventArgs)
        CREA_TAB(FrmCtaBanOrd, "Cuenta bancaria ordenante")
    End Sub

    Private Sub MnuCtaBanBen_Click(sender As Object, e As EventArgs)
        CREA_TAB(FrmCtaBanEmpresa, "Cuenta bancaria beneficiario")
    End Sub
    Private Sub MnuServiciosXUnidadSinMinve_Click(sender As Object, e As EventArgs) Handles RMante_Rep_ServiciosXUnidadSinMinve.Click
        frmServiciosXUnidadMinve.ShowDialog()
    End Sub
    Private Sub RibPolizaSalidasGenOperMec_Click(sender As Object, e As EventArgs) Handles RibPolizaSalidasGenOperMec.Click
        CREA_TAB(FrmPolizasSalidaGenOperMec, "Poliza salida gen. oper y mec.")
    End Sub

    Private Sub BarPolizaIngresos_Click(sender As Object, e As EventArgs) Handles BarPolizaIngresos.Click
        CREA_TAB(FrmPolizaIngresosCxC, "Póliza Ingresos CxC")
    End Sub
    Private Sub RibOTExternas_Click(sender As Object, e As EventArgs) Handles RMante_Rep_OTExternas.Click
        FrmRepOTExternas.ShowDialog()
    End Sub
    Private Sub RibValidaExcel_Click(sender As Object, e As EventArgs) Handles RibValidaExcel.Click
        'FrmImportAsigLlantasExcel.Show()
    End Sub
    Private Sub RibConsolidado_Click(sender As Object, e As EventArgs) Handles RMante_Rep_Consolidado.Click
        FrmReportConsolidado.ShowDialog()
    End Sub
    Private Sub RibPagoMult_Click(sender As Object, e As EventArgs) Handles RibPagoMult.Click
        FrmPagoMultidocCxC.ShowDialog()
    End Sub
    Private Sub BarVtasXProXCteTrackFullRojo_Click(sender As Object, e As EventArgs) Handles BarVtasXProXCteTrackFullRojo.Click
        CREA_TAB(FrnVtaXProXCteTrackFullRojo, "Ventas por producto por cliente")
    End Sub
    Private Sub RibTesoreriaAltaCxC_Click(sender As Object, e As EventArgs) Handles RibTesoreriaAltaCxC.Click
        CREA_TAB(frmAltaCxC, "Alta CxC")
    End Sub

    Private Sub RibVentasAltaCxC_Click(sender As Object, e As EventArgs) Handles RibVentasAltaCxC.Click
        CREA_TAB(frmAltaCxC, "Alta CxC")
    End Sub
    Private Sub RibTesoreriaPagoMult_Click(sender As Object, e As EventArgs) Handles RibTesoreriaPagoMult.Click
        FrmPagoMultidocCxC.ShowDialog()
    End Sub
    Private Sub RibVentasPagoMult_Click(sender As Object, e As EventArgs) Handles RibVentasPagoMult.Click
        FrmPagoMultidocCxC.ShowDialog()
    End Sub
    Private Sub RibTesoreriaComprobantePagoCFDI_Click(sender As Object, e As EventArgs) Handles RibTesoreriaComprobantePagoCFDI.Click
        CREA_TAB(FrmPagoComplemento, "Complemento de pago")
    End Sub
    Private Sub RibVentasComprobantePagoCFDI_Click(sender As Object, e As EventArgs) Handles RibVentasComprobantePagoCFDI.Click
        CREA_TAB(FrmPagoComplemento, "Complemento de pago")
    End Sub
    Private Sub RibTesoreriaComprobantePagoCompras_Click(sender As Object, e As EventArgs) Handles RibTesoreriaComprobantePagoCompras.Click
        FrmRecepcionPagosCompras.ShowDialog()
    End Sub
    Private Sub RibTesoreriaAltaCxP_Click(sender As Object, e As EventArgs) Handles RibTesoreriaAltaCxP.Click
        CREA_TAB(FrmAltaCxP, "Alta CxP")
    End Sub

    Private Sub BarLineasProductos1_Click(sender As Object, e As EventArgs) Handles BarLineasProductos1.Click
        CREA_TAB(FrmConsultaMovsInvOT, "Consulta movs. inv. OT")
    End Sub
    Private Sub BarConsulMinveOT_Click(sender As Object, e As EventArgs) Handles BarConsulMinveOT.Click
        CREA_TAB(FrmConsultaMovsInvOT, "Consulta movs. inv. OT")
    End Sub
    Private Sub BarFacturacion_Click(sender As Object, e As EventArgs) Handles BarFacturacion.Click
        CREA_TAB(FrmCFDICartaPorteConcen, "Concentrado CFDI carta porte")
    End Sub
    Private Sub BarLicenciamientoMobulos_Click(sender As Object, e As EventArgs) Handles BarLicenciamientoMobulos.Click
        FrmLicenciamientoModulos.ShowDialog()
    End Sub
    Private Sub BarViajesXOperador_Click(sender As Object, e As EventArgs) Handles BarViajesXOperador.Click
        FrmReportViajesXOperador.ShowDialog()
    End Sub
    Private Sub RibTesoreriaConsultaBancaria_Click(sender As Object, e As EventArgs) Handles RibTesoreriaConsultaBancaria.Click
        CREA_TAB(FrmConsultaBancaria, "Consulta bancaria")
    End Sub
    Private Sub BarPolizaComprasNC_Click(sender As Object, e As EventArgs) Handles BarPolizaComprasNC.Click
        CREA_TAB(FrmPolizaComprasNC, "Póliza compras NC")
    End Sub
    Private Sub BarFACT_CFDI4_Click(sender As Object, e As EventArgs) Handles BarFACT_CFDI4.Click
        Var4 = ""
        TIPO_VENTA = "F"
        CREA_TAB(frmFACTURAS, "Facturas")
    End Sub
    Private Sub RibRHIngresosXOperador_Click(sender As Object, e As EventArgs) Handles RibRHIngresosXOperador.Click
        FrmIngresosXOperador.ShowDialog()
    End Sub
    Private Sub RibResumenDeCompras_Click(sender As Object, e As EventArgs) Handles RibResumenDeCompras.Click
        CREA_TAB(FrmDetalladoComprasJulio, "Resumen de compras")
    End Sub
    Private Sub RibGastos_Click(sender As Object, e As EventArgs)
        CREA_TAB(FrmGastosDoc, "Gastos")
    End Sub
    Private Sub BarMotivosCancel_Click(sender As Object, e As EventArgs)
        CREA_TAB(FrmMotivosCancel, "Motivos cancelaciones")
    End Sub
    Private Sub RibCBCompras_Click(sender As Object, e As EventArgs) Handles RConta_Menu_CC_Compras.Click
        Var4 = "COMPRAS"
        FrmCierreContable.ShowDialog()
    End Sub
    Private Sub RibCBDevCompras_Click(sender As Object, e As EventArgs) Handles RConta_Menu_CC_DevCompras.Click
        Var4 = "DEVOLUCION COMPRAS"
        FrmCierreContable.ShowDialog()
    End Sub
    Private Sub RibCBFacturas_Click(sender As Object, e As EventArgs) Handles RConta_Menu_CC_Facturas.Click
        Var4 = "FACTURAS"
        FrmCierreContable.ShowDialog()
    End Sub
    Private Sub RibCBDevFacturas_Click(sender As Object, e As EventArgs) Handles RConta_Menu_CC_DevFacturas.Click
        Var4 = "DEVOLUCION FACTURAS"
        FrmCierreContable.ShowDialog()
    End Sub
    Private Sub RibCBOT_Click(sender As Object, e As EventArgs) Handles RConta_Menu_CC_OT.Click
        Var4 = "OT"
        FrmCierreContable.ShowDialog()
    End Sub
    Private Sub RibCBIngresos_Click(sender As Object, e As EventArgs) Handles RConta_Menu_CC_Ingresos.Click
        Var4 = "INGRESO"
        FrmCierreContable.ShowDialog()
    End Sub
    Private Sub RibCBEgresos_Click(sender As Object, e As EventArgs) Handles RConta_Menu_CC_Egresos.Click
        Var4 = "EGRESO"
        FrmCierreContable.ShowDialog()
    End Sub
    Private Sub RibCBMovLLantas_Click(sender As Object, e As EventArgs) Handles RConta_Menu_CC_MovLLantas.Click
        Var4 = "MOV LLANTAS"
        FrmCierreContable.ShowDialog()
    End Sub
    Private Sub RibCBGastos_Click(sender As Object, e As EventArgs) Handles RConta_Menu_CC_Gastos.Click
        Var4 = "GASTOS"
        FrmCierreContable.ShowDialog()
    End Sub
    Private Sub RibAntSaldosClientes_Click(sender As Object, e As EventArgs) Handles RibAntSaldosClientes.Click
        'CREA_TAB(FrmAntiguedadSaldosClie, "Antiguedad de saldos clientes")
        FrmAntiguedadSaldosClie.ShowDialog()
    End Sub
    Private Sub RibAntSaldosPorv_Click(sender As Object, e As EventArgs) Handles RibAntSaldosPorv.Click
        FrmAntiguedadSaldosProv.ShowDialog()
    End Sub
    Private Sub RibSaldosClientes_Click(sender As Object, e As EventArgs) Handles RibSaldosClientes.Click
        CREA_TAB(FrmClientesV2, "Saldos de clientes")
    End Sub
    Private Sub RibResumenVentas1_Click(sender As Object, e As EventArgs) Handles RibResumenVentas1.Click
        CREA_TAB(FrmDetalladoVentasJulio, "Resumen de ventas")
    End Sub
    Private Sub RiBPagoMultiDocCXP_Click(sender As Object, e As EventArgs) Handles RiBPagoMultiDocCXP.Click
        FrmPagoMultidocCxP.ShowDialog()
    End Sub
    Private Sub RibSaldosOperadores_Click(sender As Object, e As EventArgs) Handles RibSaldosOperadores.Click
        CREA_TAB(FrmSaldosOperadores, "Saldos operadores")
    End Sub
    Private Sub RibCartaPorteXRecibir_Click(sender As Object, e As EventArgs) Handles RLogisticaRep_CartaPorteXRecibir.Click
        Try
            Var4 = "Carta porte"
            FrmReporteDifPeso.ShowDialog()
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RibReportDifPeso_Click(sender As Object, e As EventArgs) Handles RLogisticaRep_ReportDifPeso.Click
        Try
            Var4 = "DifPeso"
            FrmReporteDifPeso.ShowDialog()
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RibCartaPorteTransferidas_Click(sender As Object, e As EventArgs) Handles RLogisticaRep_CartaPorteTransferidas.Click
        Try
            Var4 = "Cartas porte transferidas"
            FrmReporteDifPeso.ShowDialog()
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RibCartaPorteXRecibir1_Click(sender As Object, e As EventArgs) Handles RibCartaPorteXRecibir1.Click
        Try
            Var4 = "Carta porte"
            FrmReporteDifPeso.ShowDialog()
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RibReportDifPeso1_Click(sender As Object, e As EventArgs) Handles RibReportDifPeso1.Click
        Try
            Var4 = "DifPeso"
            FrmReporteDifPeso.ShowDialog()
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RibCartaPorteTransferidas1_Click(sender As Object, e As EventArgs) Handles RibCartaPorteTransferidas1.Click
        Try
            Var4 = "Cartas porte transferidas"
            FrmReporteDifPeso.ShowDialog()
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RibPagoMultProvCxP_Click(sender As Object, e As EventArgs) Handles RibPagoMultProvCxP.Click
        FrmPagoMultidocCxP.ShowDialog()
    End Sub
    Private Sub RibBMovs_Click(sender As Object, e As EventArgs) Handles RibBMovs.Click
        Var8 = ""
        FrmSelCuentaBancaria.ShowDialog()
        If Var8.Trim.Length > 0 Then
            RibBMovs.Enabled = False
            BACKUPTXT("XTAB_CAPTION", "FrmBMovs")
            CREA_TAB(FrmBMovs, "Movimientos bancarios")
        End If
    End Sub
    Private Sub BarTabRutasEspeciales_Click(sender As Object, e As EventArgs) Handles BarTabRutasEspeciales.Click
        BACKUPTXT("XTAB_CAPTION", "FrmTabRutasHoja")
        Var10 = "RE"
        CREA_TAB(FrmTabRutasHoja, "Tab. rutas")
    End Sub
    Private Sub MnuReportLiq1_Click(sender As Object, e As EventArgs) Handles RLiq_Rep_ReportLiq.Click
        BACKUPTXT("XTAB_CAPTION", "FrmReportLiq")
        FrmReportLiq.ShowDialog()
    End Sub
    Private Sub MnuViajesLiqui1_Click(sender As Object, e As EventArgs) Handles RLiq_Rep_ViajesLiqui.Click
        BACKUPTXT("XTAB_CAPTION", "FrmReportViajesLiq")
        FrmReportViajesLiq.ShowDialog()
    End Sub
    Private Sub RibDieselReconocido1_Click(sender As Object, e As EventArgs) Handles RLiq_Rep_DieselReconocido.Click
        BACKUPTXT("XTAB_CAPTION", "FrmReporDieselReconocido")
        FrmReporDieselReconocido.ShowDialog()
    End Sub
    Private Sub BarViajesXOperador1_Click(sender As Object, e As EventArgs) Handles RLiq_Rep_ViajesXOperador.Click
        BACKUPTXT("XTAB_CAPTION", "FrmReportViajesXOperador")
        FrmReportViajesXOperador.ShowDialog()
    End Sub
    Private Sub RibConcepBanc_Click(sender As Object, e As EventArgs) Handles RibConcepBanc.Click
        BACKUPTXT("XTAB_CAPTION", "FrmBConBan")
        CREA_TAB(FrmBConBan, "Conceptos bancarios")
    End Sub
    Private Sub RibBenef_Click(sender As Object, e As EventArgs) Handles RibBenef.Click
        BACKUPTXT("XTAB_CAPTION", "FrmBBenef")
        CREA_TAB(FrmBBenef, "Beneficiarios")
    End Sub
    Private Sub RibSolPagoProv_Click(sender As Object, e As EventArgs) Handles RibSolPagoProv.Click
        BACKUPTXT("XTAB_CAPTION", "FrmSolPagoProv")
        CREA_TAB(FrmSolPagoProv, "Solicitud pago prov.")
    End Sub
    Private Sub MnuGrupoSanguineo_Click(sender As Object, e As EventArgs) Handles MnuGrupoSanguineo.Click
        BACKUPTXT("XTAB_CAPTION", "frmGrupoSanguineo")
        CREA_TAB(frmGrupoSanguineo, "Grupo sanguineo")
    End Sub
    Private Sub BarPolizaLiq_Click(sender As Object, e As EventArgs) Handles BarPolizaLiq.Click
        BACKUPTXT("XTAB_CAPTION", "FrmPolizaLiq")
        CREA_TAB(FrmPolizaLiq, "Póliza liquidaciones")
    End Sub
    Private Sub BarNotaVenta_Click(sender As Object, e As EventArgs) Handles BarNotaVenta.Click
        BACKUPTXT("XTAB_CAPTION", "FrmDocumentos")
        Var4 = ""
        TIPO_VENTA = "V"
        CREA_TAB(FrmDocumentos, "Documentos")
    End Sub
    Private Sub BarPedido_Click(sender As Object, e As EventArgs) Handles BarPedido.Click
        BACKUPTXT("XTAB_CAPTION", "FrmDocumentos")
        Var4 = ""
        TIPO_VENTA = "P"
        CREA_TAB(FrmDocumentos, "Documentos")
    End Sub
    Private Sub BarPuntoVenta_Click(sender As Object, e As EventArgs) Handles BarPuntoVenta.Click
        'Dim mycol As New MyBackGroundColors
        'mycol.DoSet(Me)
        'Dim frm1 As New FrmPOS
        'mycol.DoSet(frm1) 'and than this for every form you create.
        'frm1.Show()
        'FrmPOS.Show()

        'ShellExecute(Scr_hDC, "Open", App.Path & "\POSREP\POSREP.EXE", Server & " " & db & " " & UserRoot & " " & Pass & " " & Empresa, App.Path, SW_SHOWNORMAL)

        Process.Start(Application.StartupPath & "\GCVENTA\GCVENTA.exe", Servidor & " " & Base & " " & Usuario & " " & Pass & " " & Empresa & " " & USER_GRUPOCE)


    End Sub
    Private Sub BarPreOrdenCompra_Click(sender As Object, e As EventArgs) Handles BarPreOrdenCompra.Click
        BACKUPTXT("XTAB_CAPTION", "FrmPreOCDocs")
        Var17 = ""
        TIPO_COMPRA = "p"
        'frmComprasDoc.Dispose()
        CREA_TAB(FrmPreOCDocs, "Pre-Ordenes de Compra")
    End Sub
    Private Sub BarParamConfig_Click(sender As Object, e As EventArgs) Handles BarParamConfig.Click
        FrmParamOPciones.ShowDialog()
    End Sub
    Private Sub BarNumGen_Click(sender As Object, e As EventArgs) Handles BarNumGen.Click
        BACKUPTXT("XTAB_CAPTION", "FrmSolPagoProv")
        CREA_TAB(FrmGenerador, "Generadores")
    End Sub
    Private Sub RinViajesRealizados_Click(sender As Object, e As EventArgs) Handles RLogisticaRep_ViajesRealizados.Click
        BACKUPTXT("XTAB_CAPTION", "FrmReporteViajesRealizados")
        FrmReporteViajesRealizados.ShowDialog()
    End Sub
    Private Sub MnuCatGastos_Click(sender As Object, e As EventArgs) Handles MnuCatGastos.Click
        BACKUPTXT("XTAB_CAPTION", "FrmCatGastos")
        CREA_TAB(FrmCatGastos, "Cat. gastos")
    End Sub

    Private Sub BarImpuestos_Click(sender As Object, e As EventArgs) Handles BarImpuestos.Click
        BACKUPTXT("XTAB_CAPTION", "FrmEsquemas")
        CREA_TAB(FrmEsquemas, "Impuestos")
    End Sub
    Private Sub RibTipoActivos_Click(sender As Object, e As EventArgs) Handles RibTipoActivos.Click
        BACKUPTXT("XTAB_CAPTION", "FrmTipoActivos")
        CREA_TAB(FrmTipoActivos, "Tipo Activos")
    End Sub
    Private Sub BarPrecios_Click(sender As Object, e As EventArgs) Handles BarPrecios.Click
        BACKUPTXT("XTAB_CAPTION", "Frmlistaprecios")
        CREA_TAB(FrmListaPrecios, "Precios")
    End Sub
    Private Sub RibTesGastos_Click(sender As Object, e As EventArgs) Handles RibTesGastos.Click
        BACKUPTXT("XTAB_CAPTION", "FrmGastosDoc")
        CREA_TAB(FrmGastosDoc, "Gastos")
    End Sub
    Private Sub RibTesCuentasBancarias_Click(sender As Object, e As EventArgs) Handles RibTesCuentasBancarias.Click
        BACKUPTXT("XTAB_CAPTION", "FrmCtaBanOrd")
        CREA_TAB(FrmCtaBanOrd, "Cuenta bancaria ordenante")
    End Sub
    Private Sub RibTesBeneficiariosBancarios_Click(sender As Object, e As EventArgs) Handles RibTesBeneficiariosBancarios.Click
        BACKUPTXT("XTAB_CAPTION", "FrmCtaBanBen")
        CREA_TAB(FrmCtaBanEmpresa, "Cuenta bancaria de la empresa")
    End Sub
    Private Sub BarActivos_Click(sender As Object, e As EventArgs) Handles BarActivos.Click
        BACKUPTXT("XTAB_CAPTION", "FrmActivos")
        CREA_TAB(FrmActivos, "Activos")
    End Sub
    Private Sub BarInventario_Click(sender As Object, e As EventArgs) Handles BarInventario.Click
        BACKUPTXT("XTAB_CAPTION", "frmInven")
        CREA_TAB(FrmInven, "Inventario")
    End Sub
    Private Sub BarINVE_Click(sender As Object, e As EventArgs)
        'INVENTARIO ACTIVO FIJO
        'GCCIFIJO
        BACKUPTXT("XTAB_CAPTION", "frmInvenFijo")
        CREA_TAB(FrmInvenFijo, "Inventario de Activo Fijo")
    End Sub

    Private Sub BarINVE21_Click(sender As Object, e As EventArgs) Handles RibbListaPrecios.Click
        BACKUPTXT("XTAB_CAPTION", "FrmConsulPrecios")
        CREA_TAB(FrmConsulPrecios, "Lista de precios")
    End Sub

    Private Sub BarConsultaListaPrec_Click(sender As Object, e As EventArgs) Handles BarConsultaListaPrec.Click
        BACKUPTXT("XTAB_CAPTION", "FrmConsulPrecios")
        CREA_TAB(FrmConsulPrecios, "Lista de precios")
    End Sub

    Private Sub RibTarjetaIAVE_Click(sender As Object, e As EventArgs) Handles RibTarjetaIAVE.Click
        BACKUPTXT("XTAB_CAPTION", "frmTarjetaIAVE")
        CREA_TAB(frmTarjetaIAVE, "Tarjetas IAVE")
    End Sub

    Private Sub BarPolizaLiq1_Click(sender As Object, e As EventArgs) Handles BarPolizaLiq1.Click
        BACKUPTXT("XTAB_CAPTION", "FrmPolizaGastos")
        CREA_TAB(FrmPolizaGastos, "Póliza gastos administrativos")
    End Sub

    Private Sub BarCartaPorteTraslado_Click(sender As Object, e As EventArgs) Handles BarCartaPorteTraslado.Click
        BACKUPTXT("XTAB_CAPTION", "FrmCartaPorteTraslado")
        CREA_TAB(FrmCartaPorteTraslado, "Cartas porte  traslado")
    End Sub

    Private Sub BarConexionTEA_Click(sender As Object, e As EventArgs) Handles BarConexionTEA.Click
        Dim f As New FrmConexionTEA With {
                .MdiParent = Me.Owner
            }
        f.ShowDialog()
    End Sub

    Private Sub BarAlmacenes1_Click(sender As Object, e As EventArgs) Handles BarAlmacenes1.Click
        BACKUPTXT("XTAB_CAPTION", "frmAlmacenes")
        CREA_TAB(FrmAlmacenes, "Almacenes")
    End Sub
    Private Sub BarPrecios1_Click(sender As Object, e As EventArgs) Handles BarPrecios1.Click
        BACKUPTXT("XTAB_CAPTION", "Frmlistaprecios")
        CREA_TAB(FrmListaPrecios, "Precios")
    End Sub
    Private Sub BarImpuestos1_Click(sender As Object, e As EventArgs) Handles BarImpuestos1.Click
        BACKUPTXT("XTAB_CAPTION", "FrmEsquemas")
        CREA_TAB(FrmEsquemas, "Impuestos")
    End Sub
    Private Sub BarConcMinve1_Click(sender As Object, e As EventArgs) Handles BarConcMinve1.Click
        BACKUPTXT("XTAB_CAPTION", "frmConM")
        CREA_TAB(FrmConM, "Conc. movs. al inv.")
    End Sub
    Private Sub BarMultialmacen1_Click(sender As Object, e As EventArgs) Handles BarMultialmacen1.Click
        BACKUPTXT("XTAB_CAPTION", "frmMultiAlmacen")
        CREA_TAB(FrmMultiAlmacen, "Multialmacén")
    End Sub
    Private Sub BarLineasProductos2_Click(sender As Object, e As EventArgs) Handles BarLineasProductos2.Click
        BACKUPTXT("XTAB_CAPTION", "frmLineas")
        CREA_TAB(FrmLineas, "Lineas")
    End Sub
    Private Sub BarUniMed1_Click(sender As Object, e As EventArgs) Handles BarUniMed1.Click
        BACKUPTXT("XTAB_CAPTION", "frmUniMed")
        CREA_TAB(FrmUniMed, "Unidad de Medida")
    End Sub
    Private Sub RibIngresosXOperador_Click(sender As Object, e As EventArgs) Handles RibIngresosXOperador.Click
        BACKUPTXT("XTAB_CAPTION", "FrmLiqIngresosXOperador")
        FrmLiqIngresosXOperador.ShowDialog()
    End Sub
    Private Sub RibComparativoPesosReales_Click(sender As Object, e As EventArgs) Handles RibComparativoPesosReales.Click

    End Sub
    Private Sub BarResumenMovsInv_Click(sender As Object, e As EventArgs) Handles BarResumenMovsInv.Click
        Dim f As New FrmResumenMovsInv With {.MdiParent = Me.Owner}
        f.ShowDialog()
    End Sub
    Private Sub RibDifPesosConImporte_Click(sender As Object, e As EventArgs) Handles RLogisticaRep_DifPesosConImporte.Click
        BACKUPTXT("XTAB_CAPTION", "FrmRepDifPesosConImporte")
        Dim f As New FrmRepDifPesosConImporte With {
                .MdiParent = Me.Owner
            }
        f.ShowDialog()
    End Sub
    Private Sub MnuBienesTransport_Click(sender As Object, e As EventArgs) Handles MnuBienesTransport.Click
        FrmLlenarBienesTrans.ShowDialog()
    End Sub
    Private Sub RibEdoCtaGenOper_Click(sender As Object, e As EventArgs) Handles RibEdoCtaGenOper.Click
        BACKUPTXT("XTAB_CAPTION", "FrmEdoCuentaGenOper")
        CREA_TAB(FrmEdoCuentaGenOper, "Edo. cuenta gen. oper")
    End Sub
    Private Sub MnuRangosDesgaste_Click(sender As Object, e As EventArgs) Handles MnuRangosDesgaste.Click
        BACKUPTXT("XTAB_CAPTION", "FrmRangosDesgaste")
        CREA_TAB(FrmRangosDesgaste, "Rangos desgaste")
    End Sub
    Private Sub MnuConcepEntradaFlujoEfectivo_Click(sender As Object, e As EventArgs) Handles MnuConcepEntradaFlujoEfectivo.Click
        BACKUPTXT("XTAB_CAPTION", "FrmFlujo")
        Var11 = "E"
        CREA_TAB(FrmConcepFlujo, "Conceptos Flujo efectivo")
    End Sub
    Private Sub MnuConcepSalidaFlujoEfectivo_Click(sender As Object, e As EventArgs) Handles MnuConcepSalidaFlujoEfectivo.Click
        BACKUPTXT("XTAB_CAPTION", "FrmFlujo")
        Var11 = "S"
        CREA_TAB(FrmConcepFlujo, "Conceptos Flujo efectivo")
    End Sub

    Private Sub RVentas_CorteDelDia_Click(sender As Object, e As EventArgs) Handles RVentas_CorteDelDia.Click

    End Sub

    Private Sub RVentas_ResumenVentas_Click(sender As Object, e As EventArgs) Handles RVentas_ResumenVentas.Click
        BACKUPTXT("XTAB_CAPTION", "FrmDetalladoVentasJulio")
        CREA_TAB(FrmDetalladoVentasJulio, "Resumen de ventas")
    End Sub

    Private Sub RVentas_FlujoCaja_Click(sender As Object, e As EventArgs) Handles RVentas_FlujoCaja.Click
        BACKUPTXT("XTAB_CAPTION", "FrmTPVFlujoEfectivo")
        CREA_TAB(FrmTPVFlujoEfectivo, "Flujo de caja")
    End Sub

    Private Sub BarEstacionTrabajo_Click(sender As Object, e As EventArgs) Handles BarEstacionTrabajo.Click
        BACKUPTXT("XTAB_CAPTION", "FrmEstacionTrab")
        CREA_TAB(FrmEstacionTrab, "Estaciones")
    End Sub

    Private Sub RLogisticaRep_KmReal_Click(sender As Object, e As EventArgs) Handles RLogisticaRep_KmReal.Click
        BACKUPTXT("XTAB_CAPTION", "FrmRepDifPesosConImporte")
        Dim f As New FrmReportKmReal With {
                .MdiParent = Me.Owner
            }
        f.ShowDialog()
    End Sub

    Private Sub BarImportaXML_Click(sender As Object, e As EventArgs) Handles BarImportaXML.Click

        Process.Start(Application.StartupPath & "\ImportSaeXML64\ImportSAExml.exe", "-" & Servidor & " -" & Base & " -" & Usuario & " -" & Pass & " -" &
                      Empresa & " -" & USER_GRUPOCE & " -" & Servidor_SAROCE & " -" & Base_SAROCE & " -" & Usuario_SAROCE & " -" & Pass_SAROCE)

    End Sub
    Private Sub BarFacturaGlobal_Click(sender As Object, e As EventArgs) Handles BarFacturaGlobal.Click
        Try
            Dim SERIE_FAC_GLOBAL As String = "", PERIODICIDAD As String = "", FECHA1 As String = "", FECHA2 As String = "", SERIE_FILTRO As String = ""
            Dim SIGUE As Boolean = False, CLIENTE_MOSTRADOR As Boolean = False

            Using options = New FrmFacturaGlobalSel()
                If DialogResult.OK = options.ShowDialog() Then
                    Try
                        If Not IsNothing(options) Then
                            SERIE_FAC_GLOBAL = options.MySerieFactutaGlobal
                            PERIODICIDAD = options.MyPeriodicidad
                            FECHA1 = options.MyF1
                            FECHA2 = options.MyF2
                            SERIE_FILTRO = options.MySerieFiltro
                            CLIENTE_MOSTRADOR = options.MyClienteMostrador
                            SIGUE = True
                        End If
                    Catch ex As Exception
                        MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
                        BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End Using

            If SIGUE Then
                Var10 = SERIE_FAC_GLOBAL
                Var11 = PERIODICIDAD
                Var12 = FECHA1
                Var13 = FECHA2
                Var14 = SERIE_FILTRO
                If CLIENTE_MOSTRADOR Then
                    Var26 = 1
                Else
                    Var26 = 0
                End If

                CREA_TAB(FrmFacturaGlobal, "Factura global")

            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSelEmpresa_Click(sender As Object, e As EventArgs) Handles BarSelEmpresa.Click
        Try
            Dim f As New FrmSelEmpresa With {
                .MdiParent = Me.Owner,
                .TopLevel = True
            }
            f.ShowDialog()

            Try
                StbtnServidor.Text = Servidor
                StbtnBase.Text = Base
                StEmpresa.Text = "Empresa: " & Empresa
                StUsuario.Text = USER_GRUPOCE
                'Text = RazonSocial
                'StVersion.Text = "Versión 4.0"
                StVersion.Text = String.Format("Versión {0}.{1}.{2}", System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Major, System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Minor, System.Reflection.Assembly.GetEntryAssembly().GetName().Version.Build)
                'StLic.Text = LicStatus
                ASIGNAR_DERECHOS()
            Catch ex As Exception
            End Try

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            If TabCatalogos.Visible Then
                c1Ribbon1.SelectedTabIndex = 0
            Else
                If TabViajes.Visible Then
                    c1Ribbon1.SelectedTabIndex = 1
                Else
                    If TabVentas.Visible Then
                        c1Ribbon1.SelectedTabIndex = 5
                    Else
                        If TabCompras.Visible Then
                            c1Ribbon1.SelectedTabIndex = 6
                        Else
                            If TabInventario.Visible Then
                                c1Ribbon1.SelectedTabIndex = 9
                            End If
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub RLogisticaRep_Precursores_Click(sender As Object, e As EventArgs) Handles RLogisticaRep_Precursores.Click
        Try
            Dim f As New FrmPrecursores With {.MdiParent = Me.Owner, .TopLevel = True}
            f.ShowDialog()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RibConcepCobroViajes_Click(sender As Object, e As EventArgs) Handles RibConcepCobroViajes.Click
        CREA_TAB(FrmAsigCatCobro, "Conceptos de cobro")
    End Sub

    Private Sub RibLlantasCatRenovados_Click(sender As Object, e As EventArgs) Handles RibLlantasMarcaRenovados.Click
        CREA_TAB(FrmMarcasRenovado, "Marcas renovado")
    End Sub

    Private Sub RibLlantasProvReno_Click(sender As Object, e As EventArgs) Handles RibLlantasProvReno.Click
        CREA_TAB(FrmProvRenovados, "Proveedor renovado")
    End Sub

    Private Sub RibReporte1_Click(sender As Object, e As EventArgs) Handles RibReporte1.Click
        VarFORM2 = "1"
        Try
            Dim f As New FrmReporte44 With {.MdiParent = Me.Owner, .TopLevel = True}
            f.ShowDialog()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RibReporte2_Click(sender As Object, e As EventArgs) Handles RibReporte2.Click
        VarFORM2 = "2"
        Try
            Dim f As New FrmReporte44 With {.MdiParent = Me.Owner, .TopLevel = True}
            f.ShowDialog()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RibReporte3_Click(sender As Object, e As EventArgs) Handles RibReporte3.Click
        VarFORM2 = "3"
        Try
            Dim f As New FrmReporte44 With {.MdiParent = Me.Owner, .TopLevel = True}
            f.ShowDialog()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RibReporte4_Click(sender As Object, e As EventArgs) Handles RibReporte4.Click
        VarFORM2 = "4"

        Try
            Dim f As New FrmReporte44 With {.MdiParent = Me.Owner, .TopLevel = True}
            f.ShowDialog()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RibReporte5_Click(sender As Object, e As EventArgs) Handles RibReporte5.Click
        VarFORM2 = "5"
        Try
            Dim f As New FrmReporte44 With {.MdiParent = Me.Owner, .TopLevel = True}
            f.ShowDialog()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RibComercioExterior_Click(sender As Object, e As EventArgs) Handles RibComercioExterior.Click
        BACKUPTXT("XTAB_CAPTION", "FrmAddendas")
        CREA_TAB(FrmAddendas, "Addendas")
    End Sub

    Private Sub RibEmbalaje_Click(sender As Object, e As EventArgs) Handles RibEmbalaje.Click
        BACKUPTXT("XTAB_CAPTION", "FrmEmbalajeBueno")
        CREA_TAB(FrmEmbalajeBueno, "Embalaje")
    End Sub

    Private Sub RibCargas_Click(sender As Object, e As EventArgs) Handles RibCargas.Click
        BACKUPTXT("XTAB_CAPTION", "FrmCargasBueno")
        CREA_TAB(FrmCargasBueno, "Cargas")
    End Sub

    Private Sub BarImpuestoAño_Click(sender As Object, e As EventArgs) Handles BarImpuestoAño.Click
        BACKUPTXT("XTAB_CAPTION", "FrmEsquemasYear")
        CREA_TAB(FrmEsquemasYear, "Impuestos/Cuentas por año")
    End Sub

    Private Sub BarImpuestoMes_Click(sender As Object, e As EventArgs) Handles BarImpuestoMes.Click
        BACKUPTXT("XTAB_CAPTION", "FrmEsquemasMes")
        CREA_TAB(FrmEsquemasMes, "Impuestos/Cuentas por mes")
    End Sub

    Private Sub BarDescargaMasivaSAT_Click(sender As Object, e As EventArgs) Handles BarDescargaMasivaSAT.Click
        Try
            Process.Start(Application.StartupPath & "\Descarga SAT Masiva\Descarga SAT Masiva.exe")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarContResumen_Click(sender As Object, e As EventArgs) Handles BarContResFacturas.Click, BarContResLiq.Click, BarContResLiqConceptos.Click, BarContResFacturasAbono.Click
        Dim Consulta As String
        Consulta = ObtenerNombrePestanaConsulta(sender.Name)
        Dim frm As New FrmConsultaResumen()
        frm.NombreConsulta = Consulta
        frm.NombreFrm = sender.Name

        CREA_TAB(frm, Consulta)
    End Sub

    Private Sub RibPolPagRef_Click(sender As Object, e As EventArgs) Handles RibPolPagRef.Click
        'FrmPolizaPagoRef
        BACKUPTXT("XTAB_CAPTION", "FrmPolizaPagoRef")
        CREA_TAB(FrmPolizaPagoRef, "Póliza Pago Refacciones")
    End Sub

    Private Sub RibPolProvRef_Click(sender As Object, e As EventArgs) Handles RibPolProvRef.Click
        BACKUPTXT("XTAB_CAPTION", "FrmPolizaProvRef")
        CREA_TAB(FrmPolizaProvRef, "Póliza Provisión Refacciones")
    End Sub

    Private Sub BarRepGerencial2_Click(sender As Object, e As EventArgs) Handles BarRepGerencial2.Click
        BACKUPTXT("XTAB_CAPTION", "FrmRepGerencial2")
        FrmRepGerencial2.ShowDialog()
    End Sub

    Private Sub BarGerencial3_Click(sender As Object, e As EventArgs) Handles BarGerencial3.Click
        BACKUPTXT("XTAB_CAPTION", "FrmRepGerencial3")
        FrmRepGerencial3.ShowDialog()
    End Sub

    Private Sub RibPolFondoOper_Click(sender As Object, e As EventArgs) Handles RibPolFondoOper.Click
        BACKUPTXT("XTAB_CAPTION", "FrmPolizaFondoOper")
        CREA_TAB(FrmPolizaFondoOper, "Póliza Fondo Operadores")
    End Sub

    Private Sub RibPolSalAlm_Click(sender As Object, e As EventArgs) Handles RibPolSalAlm.Click
        BACKUPTXT("XTAB_CAPTION", "FrmPolizaSalidaAlmacen")
        CREA_TAB(FrmPolizaSalidaAlmacen, "Póliza Salida Almacén Refacciones")
    End Sub

    Private Sub RibPolPagOTE_Click(sender As Object, e As EventArgs) Handles RibPolPagOTE.Click
        BACKUPTXT("XTAB_CAPTION", "FrmPolizaPagoOTE")
        CREA_TAB(FrmPolizaPagoOTE, "Póliza Pago OT Ext.")
    End Sub

    Private Sub RibRepPensionAlimenticia_Click(sender As Object, e As EventArgs) Handles RibRepPensionAlimenticia.Click, RLiq_Rep_Pension.Click
        BACKUPTXT("XTAB_CAPTION", "FrmPensionAlimenticia")
        FrmPensionAlimenticia.ShowDialog()
    End Sub
End Class
