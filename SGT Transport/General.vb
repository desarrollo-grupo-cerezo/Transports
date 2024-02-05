Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports System.Drawing.Printing
Imports System.Text.RegularExpressions
Imports System.Management
Imports System.Net.NetworkInformation
Imports System.Security.Principal
Imports System.Xml
Imports System.Net.Mail
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.SQLite
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports C1.Win.C1SuperTooltip
Imports Stimulsoft.Report

Module General

    <Runtime.InteropServices.DllImport("user32.dll")>
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Boolean, ByVal lParam As Integer) As Integer

    End Function
    Public ColoFondoFG As Color = System.Drawing.Color.FromArgb(230, 233, 241, 250)
    '233, 241, 250
    Public PRINTDIRECTPV As Integer
    Public ReturnBool As Boolean
    Public REPORTE_POS As String = ""
    Public ESCENARIO As Integer
    Public FFormOpen As String
    Public FORM_LOAD_KEY As Boolean
    Public EXPORTAR_COMO_CSV As Integer = 0
    Public RUTA_X_USUARIO As Integer = 0
    Public RUTA_EXCEL As String
    Public CFDI_DEC As Integer = 2
    Public ISFAC_GLOBAL As Boolean = False

    Public SERIE_CFDI As String
    Public IMPORTE_SAT As Decimal

    Public PrinterPublic1 As String = ""
    Public PrinterPublic2 As String = ""
    Public FILE_PDF As String

    Public TIMBRADO_SAT As String

    Public CP_PEDIMENTO As String
    Public CP_NUM_PROV As String
    Public CP_OBSER_CFDI As String
    Public CTA_PORT1 As String
    Public CTA_PORT2 As String
    Public CP_CLIENTE As String
    Public CARTA_PORTE_ANEXO As String = ""
    Public CP_ORDEN_DE As String
    Public CP_EMBARQUE As String

    Public CP_RECOGER_EN As String
    Public CP_ENTREGAR_EN As String

    Public CP_TRACTOR As String
    Public CP_TANQUE1 As String
    Public CP_TANQUE2 As String
    Public CP_PLACAS_TRACTOR As String
    Public CP_PLACAS_TANQUE1 As String
    Public CP_PLACAS_TANQUE2 As String
    Public CP_PERMSCT As String
    Public CP_NUMPERMISOSCT As String
    Public CP_POLIZARESPCIVIL As String
    Public CP_ASEGURARESPCIVIL As String
    Public CP_SEG_RESPCIVIL As String
    Public CP_SEG_ECOLOGICO As String
    Public CP_POLIZAMEDAMBIENTE As String
    Public CP_ASEGURAMEDAMBIENTE As String
    Public CP_IMPRIME_IMPORTES As Boolean
    Public gRutaXML_NO_TIMBRADO As String
    Public gRutaXML_TIMBRADO As String
    Public XML_BK As String
    Public gRutaXML_TIMBRADO_CON_PRECIOS As String
    Public gRutaXML_TIMBRADO_SIN_PRECIOS As String

    Public gRutaPFX As String
    Public gContraPFX As String
    Public gRutaCertificado As String

    Public StiRep1 As String
    Public StiRep2 As String
    Public TIPO_MEDICION_COMBUSTIBLE As Integer = 0
    Public MULTIALMACEN As Integer = 0
    Public G_ALM As Integer = 1
    Public AFEC_TABLA_INVE As Integer = 0
    Public LINEA_VALOR_DECLA As String

    Public TIPO_VENTA As String
    Public FOLIO_VENTA As Long
    Public LETRA_VENTA As String

    Public FOLIO_G As Long
    Public LETRA_G As String
    Public ThemeElekos As String
    Public ThemeElekos2 As String

    Public aDOCS() As String
    Public aDATA(,) As String
    Public aRENOVADO() As String
    Public aDECIMAL() As String

    Public aTPV(10, 10) As String
    Public aLIB1(100, 100) As String
    Public aLIB2(102, 102, 102) As String

    Public CLAVE_SAE As Integer = 0
    Public VarFORM As String
    Public VarFORM2 As String
    Public returnValue As String
    Public returnValue2 As String
    Public ReturnExeQuery As Boolean
    Public ReturnValueLong As Long


    Public Connect As String
    'Public C21 As Boolean, C22 As Boolean
    Public OT_EXT As String
    Public GEN_OC_OT As String = ""

    Public OBSER_X_PARTIDA As Integer = 0
    Public OBSER_X_DOC As Integer = 0

    Public TIPO_OTI As Integer = 0
    Public TIPO_OTE As Integer = 0

    Public SistemaActivado As Boolean
    Public LicStatus As String
    Public SERIE As String
    Public LETRA_COMPRA As String
    Public FOLIO_COMPRA As Long

    Public LETRA_GASTO As String
    Public FOLIO_GASTO As Long

    Public Prosec As String
    Public FgEdit As Boolean
    Public DOC_NEW As Boolean
    Public SERIE_VENTA As String

    Public PERMITIR_GRABAR_DATOS As Integer
    Public TIPO_COMPRA As String

    Public Cp1 As String
    Public Cp2 As String
    Public MaxSelItem As Boolean = False

    Public CFDI_XML_DIGIBOX As String = ""

    Public Var1 As String = ""
    Public Var2 As String = ""
    Public Var3 As String = ""
    Public Var4 As String = ""
    Public Var5 As String = ""
    Public Var6 As String = ""
    Public Var7 As String = ""
    Public Var8 As String = ""
    Public Var9 As String = ""
    Public Var10 As String = ""
    Public Var11 As String = ""
    Public Var12 As String = ""
    Public Var13 As String = ""
    Public Var14 As String = ""
    Public Var15 As String = ""
    Public Var16 As String = ""
    Public Var17 As String = ""
    Public Var18 As String = ""
    Public Var19 As String = ""
    Public Var20 As Long = 0
    Public Var21 As Single
    Public Var22 As Single
    Public Var23 As Single
    Public Var24 As String = ""
    Public Var25 As String = ""

    Public Var26 As Integer
    Public Var27 As Integer
    Public Var28 As String
    Public Var44 As Long = 0
    Public Var45 As Long = 0
    Public Var46 As String = ""
    Public Var47 As String = ""
    Public Var48 As Decimal
    Public Var49 As Decimal

    Public NumSelIte As Long = 0

    Public DialogOK As String


    Public PassData As String 'frmOTIAE, frmcfdirelacionados, frmcfdicanc FrmCFDIRelFac
    Public PassData1 As String 'FrmFACTURAS
    Public PassData2 As String 'frmpagocomplemento
    Public PassData3 As String 'frmotiae, llantas compras
    Public PassData4 As String 'compras llantas otae
    Public PassData5 As String 'relacionados principal
    Public PassData6 As String 'envia correo
    Public PassData7 As String 'envia correo

    Public PassData8 As String '
    Public PassData9 As String '
    Public PassData10 As Date
    Public PassDoc_Timbrado As String '

    Public REM_CARTA_PORTE As Boolean

    Public r_ As Integer
    Public c_ As Integer

    Public ClaveProvSecuencial As Integer
    Public UtilizarAlternaProveedor As Integer

    Public Cpu_Id As String
    Public MacAdres As String
    Public SQLConn As SQLiteConnection

    Public cnSAE As New SqlConnection
    Public cnEMPRESA As New SqlConnection

    Public cnSAROCE As New SqlConnection

    Public cnGPS As New SqlConnection
    Public cnSQL As New SqlConnection

    Public conn As OleDbConnection

    Public SQL As String
    Public SQL1 As String
    Public SQL2 As String

    Public pwPoder As Boolean
    Public pwSupervisor As Boolean

    Public Ruta As String
    Public Porc1 As Single
    Public Ribon_Style As Integer

    Public POSUsuario As String

    Public Ruta_Framework As String
    Public RazonSocial As String

    Public NombreEmpresa As String
    Public Empresa As String
    Public Servidor As String
    Public Base As String
    Public RutaFirebird As String
    Public Usuario As String
    Public Pass As String
    Public Tipo As Integer
    Public USER_GRUPOCE As String = ""
    Public PASS_GRUPOCE As String = ""
    Public CLAVESAE As Integer = 0


    Public Servidor_SAROCE As String
    Public Base_SAROCE As String
    Public Usuario_SAROCE As String
    Public Pass_SAROCE As String

    Public Sub LeerConfig()
        Dim Nodata As Boolean
        Try
            Nodata = True
            Ribon_Style = 0

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(RIBBON,0) AS RIB FROM GCCONFIG"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            Nodata = False
                            Ribon_Style = dr("RIB")
                        End If
                    End Using
                    If Nodata Then
                        cmd.CommandText = "INSERT INTO GCCONFIG (RIBBON) VALUES('4')"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            Catch ex As Exception
                'Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            LETRA_COMPRA = ""
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV, LINEA_VALOR_DECLA 
                        FROM GCPARAMINVENT"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            MULTIALMACEN = dr("M_ULTIALMACEN")
                            AFEC_TABLA_INVE = dr("AFE_TAB_INV")
                            LINEA_VALOR_DECLA = dr.ReadNullAsEmptyString("LINEA_VALOR_DECLA")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                EXPORTAR_COMO_CSV = 0
                RUTA_X_USUARIO = 0
                RUTA_EXCEL = ""
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT TIPO_OTI, TIPO_OTE, TIPO_MEDICION_COMBUSTIBLE, EXPORTAR_COMO_CSV, RUTA_X_USUARIO, RUTA_EXCEL,
                        ISNULL(BAJA_VIAJE_FACTURACION,0) AS BAJA_VIAJE_FACT
                        FROM GCPARAMGENERALES"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TIPO_OTI = dr.ReadNullAsEmptyInteger("TIPO_OTI")
                            If TIPO_OTI = -1 Then TIPO_OTI = 0

                            TIPO_OTE = dr.ReadNullAsEmptyInteger("TIPO_OTE")
                            If TIPO_OTE = -1 Then TIPO_OTE = 0
                            TIPO_MEDICION_COMBUSTIBLE = dr.ReadNullAsEmptyInteger("TIPO_MEDICION_COMBUSTIBLE")
                            If TIPO_MEDICION_COMBUSTIBLE = -1 Then TIPO_MEDICION_COMBUSTIBLE = 0

                            EXPORTAR_COMO_CSV = dr.ReadNullAsEmptyInteger("EXPORTAR_COMO_CSV")
                            ' 0 o 1
                            RUTA_X_USUARIO = dr.ReadNullAsEmptyInteger("RUTA_X_USUARIO")
                            RUTA_EXCEL = dr.ReadNullAsEmptyString("RUTA_EXCEL")

                            If dr("BAJA_VIAJE_FACT") = 1 Then
                                MainRibbonForm.BarBajaViajes.Text = "Facturación viajes"
                            Else
                                MainRibbonForm.BarBajaViajes.Text = "Baja de viaje"
                            End If
                        End If
                    End Using
                End Using
                If RUTA_X_USUARIO = 1 Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(RUTA_EXCEL,'') AS RUTA_EX 
                            FROM GCPARAM_RUTA_EXCEL_USER 
                            WHERE USUARIO = '" & USER_GRUPOCE & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                RUTA_EXCEL = dr("RUTA_EX")
                            End If
                        End Using
                    End Using
                End If
                If RUTA_EXCEL.Trim.Length = 0 Then
                    RUTA_EXCEL = Application.StartupPath & "\XLS"
                End If
            Catch ex As Exception
                Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
                'MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CREA_RUTA_XLS()
        Try
            If RUTA_X_USUARIO = 1 Then
                SQL = "UPDATE GCPARAM_RUTA_EXCEL_USER SET RUTA_EXCEL = '" & Application.StartupPath & "'
                    WHERE USUARIO = '" & USER_GRUPOCE & "'"
            Else
                SQL = "UPDATE GCPARAMGENERALES SET RUTA_EXCEL = '" & Application.StartupPath & "'"
            End If
            EXECUTE_QUERY_NET(SQL)
        Catch ex As Exception
        End Try
    End Sub
    Public Function SIGUIENTE_SERIE_CARTA_PORTE() As String
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT SERIE_CARTA_PORTE, ULT_DOC_CARTA_PORTE FROM GCPARAMTRANSCG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Var24 = dr.ReadNullAsEmptyString("SERIE_CARTA_PORTE")
                        Var20 = dr.ReadNullAsEmptyDecimal("ULT_DOC_CARTA_PORTE") + 1
                    End If
                End Using
            End Using
            Return Var24 & Format(Var20, "0000000000")
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function
    Public Function SIGUIENTE_SERIE_CARTA_PORTE_VIRTUAL() As String
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT SERIE_CARTA_PORTE_VIRTUAL, ULT_DOC_CARTA_PORTE_VIRTUAL FROM GCPARAMTRANSCG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Var24 = dr.ReadNullAsEmptyString("SERIE_CARTA_PORTE_VIRTUAL")
                        Var20 = dr.ReadNullAsEmptyDecimal("ULT_DOC_CARTA_PORTE_VIRTUAL") + 1
                    End If
                End Using
            End Using
            Return Var24 & Format(Var20, "0000000000")
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function
    Public Function EXIST_FACTURA_CFDI_CONC_LV(FCVE_DOC As String) As Boolean
        Dim EXIST_VTA As Boolean
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_DOC FROM CFDI_CONC_LV WHERE CVE_DOC = '" & FCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXIST_VTA = True
            Else
                EXIST_VTA = False
            End If
            dr.Close()

            Return EXIST_VTA
        Catch ex As Exception
            Bitacora("366. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("366. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function EXIST_VALE_UTILITARIOS(fCVE_DOC As String) As Boolean
        Dim EXIST_VTA As Boolean
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            cmd.Connection = cnSAE
            SQL = "SELECT FOLIO FROM GCASIGNACION_VALES_UTIL WHERE FOLIO = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXIST_VTA = True
            Else
                EXIST_VTA = False
            End If
            dr.Close()

            Return EXIST_VTA
        Catch ex As Exception
            Bitacora("366. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("366. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function EXIST_CARTA_PORTE(fCVE_DOC As String) As Boolean
        Dim EXIST_VTA As Boolean
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            cmd.Connection = cnSAE
            SQL = "SELECT FACTURA FROM CFDI WHERE FACTURA = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXIST_VTA = True
            Else
                EXIST_VTA = False
            End If
            dr.Close()

            Return EXIST_VTA
        Catch ex As Exception
            Bitacora("366. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("366. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function OBTENER_ULTIMO_FOLIO_CARTA_PORTE()
        Try
            Dim CVE_DOC_CP As String, Sigue As Boolean = True
            Dim FOLIO_CP As Long, SERIE_CP As String

            CVE_DOC_CP = SIGUIENTE_SERIE_CARTA_PORTE()
            SERIE_CP = Var24
            FOLIO_CP = Var20

            Do While Sigue

                If SERIE_CP.ToString.Trim.Length = 0 Or SERIE_CP.ToString = "STAND." Then
                    CVE_DOC_CP = Space(10) & Format(FOLIO_CP, "0000000000")
                Else
                    CVE_DOC_CP = SERIE_CP & Format(FOLIO_CP, "0000000000")
                End If

                If EXISTE_CARTA_PORTE_GEN(CVE_DOC_CP) Then
                    FOLIO_CP += 1
                Else
                    Sigue = False
                End If
            Loop

            Var20 = FOLIO_CP
            Return CVE_DOC_CP

        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function
    Public Function GetFileContents(ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As String
        Dim strContents As String
        Dim objReader As StreamReader
        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            If strContents.ToString.Length = 0 Then strContents = "Admin"

            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
            Return "Admin"
        End Try
    End Function

    Public Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String) As Boolean
        'Dim Contents As String
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            Bitacora("2. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
        Return bAns
    End Function
    Public Sub BACKUPCSV(ByVal NombreArchivo As String, ByVal strData As String, Optional SobreEscribir As Boolean = True)
        'Dim Contents As String
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(Application.StartupPath & "\" & NombreArchivo & ".csv", SobreEscribir)
            objReader.Write(strData & vbNewLine)
            objReader.Close()
        Catch Ex As Exception
            Bitacora("3. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Public Sub BACKUP_SQL(ByVal NombreArchivo As String, ByVal strData As String, Optional SobreEscribir As Boolean = True)
        'Dim Contents As String
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(Application.StartupPath & "\" & NombreArchivo & ".sql", SobreEscribir)
            objReader.Write(strData & vbNewLine)
            objReader.Close()
        Catch Ex As Exception
            Bitacora("3. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Public Sub BACKUPTXT(ByVal NombreArchivo As String, ByVal strData As String, Optional SobreEscribir As Boolean = True)
        'Dim Contents As String
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(Application.StartupPath & "\" & NombreArchivo & ".txt", SobreEscribir)
            objReader.Write(strData & vbNewLine)
            objReader.Close()
        Catch Ex As Exception
            Bitacora("3. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Public Sub BACKUP_OVER(ByVal NombreArchivo As String, ByVal strData As String)
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(Application.StartupPath & "\" & NombreArchivo, False)
            objReader.Write(strData)
            objReader.Close()
        Catch Ex As Exception
        End Try
    End Sub
    Public Sub Createdatabase()

        Try
            SQLiteConnection.CreateFile(System.AppDomain.CurrentDomain.BaseDirectory & "\transcg.s3db")

            'Version = 3;Mode=ReadWrite;New=False;Compress=True;Journal Mode=Off;";
            'Dim connection As String = "Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\transcg.s3db;" &
            '    "Version=3;Mode=ReadWrite;New=True;Compress=True;Journal Mode=Off;"

            SQL = "Data Source=" & AppDomain.CurrentDomain.BaseDirectory & "\transcg.s3db"

            SQLConn = New SQLiteConnection(SQL, True)
            SQLConn.Open()

            Dim Sqlitecmd As New SQLiteCommand(SQLConn)
            Sqlitecmd = SQLConn.CreateCommand

            SQL1 = "CREATE TABLE [config] (" &
                   "[id] Integer PRIMARY KEY AUTOINCREMENT Not NULL,
                   [ribbon] INTEGER NULL,
                   [servidor_sar] VARCHAR(90) NULL,
                   [macadres] VARCHAR(100) NULL,
                   [fecha_lic] VARCHAR(20) NULL,
                   [base_sar] VARCHAR(90) NULL,
                   [usuario_sar] VARCHAR(30) NULL,
                   [pass_sar] VARCHAR(30) NULL,
                   [checklic] float NULL)"

            Sqlitecmd.CommandText = SQL1
            Sqlitecmd.ExecuteNonQuery()

            SQL1 = "INSERT INTO config (servidor_sar, base_sar, usuario_sar, pass_sar) VALUES (' ',' ',' ',' ')"
            Sqlitecmd.CommandText = SQL1
            Sqlitecmd.ExecuteNonQuery()

            Sqlitecmd.CommandText = SQL1
            Sqlitecmd.ExecuteNonQuery()

            SQLConn.Close()
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. No se logro crear la base de datos " & ex.Message & vbNewLine & ex.StackTrace & SQL)
            Exit Sub
        End Try

    End Sub
    Public Sub AgregaCampo()
        Try
            Dim cmd As New SQLiteCommand(SQLConn)
            Dim NCampo1 As String = "N", NCampo2 As String = "N", NCampo3 As String = "N", NCampo4 As String = "N", NCampo5 As String = "N"
            Dim NCampo6 As String = "N", NCampo7 As String = "N", Field1 As String
            Dim dr As SQLiteDataReader
            cmd = SQLConn.CreateCommand

            cmd.CommandText = "PRAGMA table_info('config')"
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Do While dr.Read
                    Field1 = dr("name")
                    If Field1 = "macadres" Then NCampo1 = "S"
                    If Field1 = "checklic" Then NCampo2 = "S"
                    If Field1 = "fecha_lic" Then NCampo3 = "S"
                Loop
            End If
            dr.Close()
            Dim sqlitecmd As New SQLiteCommand(SQLConn)
            sqlitecmd = SQLConn.CreateCommand
            If NCampo1 = "N" Then
                sqlitecmd.CommandText = "ALTER TABLE config ADD COLUMN macadres VARCHAR(100)"
                sqlitecmd.ExecuteNonQuery()
            End If
            If NCampo2 = "N" Then
                sqlitecmd.CommandText = "ALTER TABLE config ADD COLUMN checklic INTEGER"
                sqlitecmd.ExecuteNonQuery()
            End If
            If NCampo3 = "N" Then
                sqlitecmd.CommandText = "ALTER TABLE config ADD COLUMN fecha_lic VARCHAR(12)"
                sqlitecmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("6. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    '
    Public Sub CreaCarpeta(fCarpeta As String)
        Try
            If Not System.IO.Directory.Exists(fCarpeta) Then
                System.IO.Directory.CreateDirectory(fCarpeta)
            End If
        Catch ex As Exception
            MsgBox("8. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub Bitacora(ByVal strData As String)
        Dim objReader As StreamWriter, cadena_cx As String = ""
        Try
            cadena_cx = vbNewLine & "General:Bitacora:cnSAE:" & cnSAE.State & ", ConnectionTimeout:" & cnSAE.ConnectionTimeout & ", cnSAROCE:" & cnSAROCE.State & vbNewLine
        Catch ex As Exception
        End Try
        Try
            strData = DateTime.Now.ToString & " MZO23: " & strData & vbCrLf & "Empresa :" & Empresa & vbCrLf & SQL & vbNewLine

            objReader = New StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\BITACORA.txt", True)
            objReader.Write(strData)
            objReader.Write(cadena_cx & "--------------------------------------------------------" & vbCrLf)
            objReader.Close()

            If PASS_GRUPOCE = "BUS" Then
                'MsgBox(strData)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BITACORA_LIQ(ByVal strData As String)
        Dim objReader As StreamWriter, cadena_cx As String = ""
        Try
            cadena_cx = vbNewLine & "cnSAE:" & cnSAE.State & ", ConnectionTimeout:" & cnSAE.ConnectionTimeout & ", cnSAROCE:" & cnSAROCE.State & vbNewLine
        Catch ex As Exception
        End Try
        Try
            strData = DateTime.Now.ToString & " FEB22: " & strData & vbCrLf & "Empresa :" & Empresa & vbCrLf & SQL & vbNewLine

            objReader = New StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\BITACORA_LIQ.TXT", True)
            objReader.Write(strData)
            objReader.Write(cadena_cx & "--------------------------------------------------------" & vbCrLf)
            objReader.Close()

            If PASS_GRUPOCE = "BUS" Then
                'MsgBox(strData)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BITACORACFDI(ByVal strData As String)
        Dim objReader As StreamWriter, cadena_cx As String = ""
        Try
            cadena_cx = vbNewLine & "cnSAE:" & cnSAE.State & ", ConnectionTimeout:" & cnSAE.ConnectionTimeout & ", cnSAROCE:" & cnSAROCE.State & vbNewLine
        Catch ex As Exception
        End Try
        Try
            strData = DateTime.Now.ToString & " FEB22: " & strData & vbCrLf & "Empresa :" & Empresa & vbCrLf & SQL & vbNewLine

            objReader = New StreamWriter(AppDomain.CurrentDomain.BaseDirectory & "\BITACORACFDI.txt", True)
            objReader.Write(strData)
            objReader.Write(cadena_cx & "--------------------------------------------------------" & vbCrLf)
            objReader.Close()

            If PASS_GRUPOCE = "BUS" Then
                'MsgBox(strData)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BITACORASQL(ByVal strData As String)
        Dim objReader As StreamWriter, cadena_cx As String = ""
        Try
            cadena_cx = vbNewLine & "cnSAE:" & cnSAE.State & ", ConnectionTimeout:" & cnSAE.ConnectionTimeout & ", cnSAROCE:" & cnSAROCE.State & vbNewLine
        Catch ex As Exception
        End Try
        Try
            strData = DateTime.Now.ToString & " FEB22: " & strData & vbCrLf & "Empresa :" & Empresa & vbCrLf & SQL & vbNewLine

            objReader = New StreamWriter(AppDomain.CurrentDomain.BaseDirectory & "\BITACORA_SQL.txt", True)
            objReader.Write(strData)
            objReader.Write(cadena_cx & "--------------------------------------------------------" & vbCrLf)
            objReader.Close()

            If PASS_GRUPOCE = "BUS" Then
                'MsgBox(strData)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BITACORATPV(ByVal strData As String)
        Dim objReader As StreamWriter, cadena_cx As String = ""
        Try
            cadena_cx = vbNewLine & "cnSAE:" & cnSAE.State & ", ConnectionTimeout:" & cnSAE.ConnectionTimeout & ", cnSAROCE:" & cnSAROCE.State & vbNewLine
        Catch ex As Exception
        End Try
        Try
            strData = DateTime.Now.ToString & " FEB22: " & strData & vbCrLf & "Empresa :" & Empresa & vbCrLf & SQL & vbNewLine

            objReader = New StreamWriter(AppDomain.CurrentDomain.BaseDirectory & "\BITACORA_TPV.txt", True)
            objReader.Write(strData)
            objReader.Write(cadena_cx & "--------------------------------------------------------" & vbCrLf)
            objReader.Close()

            If PASS_GRUPOCE = "BUS" Then
                'MsgBox(strData)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BITACORADB(ByVal strData As String)
        Dim objReader As StreamWriter, cadena_cx As String = ""
        Try
            cadena_cx = vbNewLine & "cnSAE:" & cnSAE.State & ", ConnectionTimeout:" & cnSAE.ConnectionTimeout & ", cnSAROCE:" & cnSAROCE.State & vbNewLine
        Catch ex As Exception
        End Try
        Try
            strData = DateTime.Now.ToString & " AGO07: " & strData & vbCrLf & "Empresa :" & Empresa & vbCrLf & SQL & vbNewLine

            objReader = New StreamWriter(AppDomain.CurrentDomain.BaseDirectory & "\BITACORADB.txt", True)
            objReader.Write(strData)
            objReader.Write(cadena_cx & "--------------------------------------------------------" & vbCrLf)
            objReader.Close()

            If PASS_GRUPOCE = "BUS" Then
                'MsgBox(strData)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SaveFile(ByVal fFile As String, ByVal strData As String)

        Dim objReader As StreamWriter
        Try

            strData &= vbNewLine

            objReader = New StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory & "\" & fFile, True)
            objReader.Write(strData)
            objReader.Close()
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Public Function Encriptar(ByVal input As String) As String

        Try

            Dim iV() As Byte = ASCIIEncoding.ASCII.GetBytes("rivokeyi") 'La clave debe ser de 8 caracteres
            'rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5
            'ykltPlTrlzx97/erWlxaGhrtPzsyqL45
            Dim encryptionKey() As Byte = Convert.FromBase64String("ykltPlTrlzx97/erWlxaGhrtPzsyqL45")
            Dim buffer() As Byte = Encoding.UTF8.GetBytes(input)
            Dim des As New TripleDESCryptoServiceProvider With {
                .Key = encryptionKey,
                .IV = iV
            }

            Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function

    Public Function Desencriptar(ByVal input As String) As String
        Try

            Dim iV() As Byte = ASCIIEncoding.ASCII.GetBytes("rivokeyi") 'La clave debe ser de 8 caracteres
            Dim encryptionKey() As Byte = Convert.FromBase64String("ykltPlTrlzx97/erWlxaGhrtPzsyqL45") 'No se puede alterar la cantidad de caracteres pero si la clave
            Dim buffer() As Byte = Convert.FromBase64String(input)
            Dim des As New TripleDESCryptoServiceProvider With {
                .Key = encryptionKey,
                .IV = iV
            }
            Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try


    End Function

    Public Function ValidarLicencia() As Boolean
        'Ser_nube = Desencriptar("a40sGA1fd2gX0Jmk121AS+0P0feGWw3t")
        'Bas_nube = Desencriptar("TIZmDykhdqCzpKy6hgBo6rVvC3eDW2be")
        'UsuNube = Desencriptar("oQ3gQDLzkMN1DvM7auC5bQ==")
        'PasNube = Desencriptar("bRmEotg6mez6Sz/sdgbMwQ==")

        Dim cmdSql As New SqlCommand
        Dim reader As SqlDataReader
        Dim Conexion As String
        Dim ServidorNube As String
        Dim BaseNube As String
        Dim UsuarioNube As String
        Dim PassNube As String
        Dim sqlNube As New SqlConnection
        Dim Fechavenc As Date
        Dim DifDias As Integer
        Dim NoExiste As Boolean
        Dim ActivaViaWeb As Boolean
        Dim Venta_Renta As String
        Dim SiOpen As Boolean

        Try
            ValidarLicencia = False

            ServidorNube = Desencriptar("IePqQcHOYFyKQu46YrMzO62TxF1Dl0tfiSiX7aoQMSc =")
            BaseNube = Desencriptar("UoyRXZOtoe7WFzZ1PfWj3JV2llUjPAoe")
            UsuarioNube = Desencriptar("UoyRXZOtoe716deBH5uQ5A==")
            PassNube = Desencriptar("fFywR2/on8Ltvlz4TlXdNA==")

            Conexion = "server=" & ServidorNube & ";uid=" & UsuarioNube & ";password=" & PassNube & ";database=" & BaseNube

            SiOpen = False
            Try
                sqlNube = New SqlConnection(Conexion)
                sqlNube.Open()
                SiOpen = True
            Catch ex As Exception
                SiOpen = False
                Bitacora("50.1 " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
            End Try

            If SiOpen Then
                ActivaViaWeb = False
                NoExiste = False
                Venta_Renta = ""

                MacAdres = GET_ID()

                cmdSql.Connection = sqlNube

                SQL = "SELECT ISNULL(RTAVTA,'') AS RV, ISNULL(PAG,'') AS PAGADO, ISNULL(FECHA_VENC,'') AS F_VENC
                    FROM merkkaba_sa.REGLIC WHERE MAC = '" & MacAdres & "' AND SISTEMA = 'TransportCG'"

                cmdSql.CommandText = SQL

                reader = cmdSql.ExecuteReader
                If reader.HasRows Then
                    If reader.Read Then
                        System.Windows.Forms.Application.DoEvents()
                        NoExiste = True
                        Venta_Renta = reader("RV")
                        If Venta_Renta = "V" Then
                            If reader("PAGADO") = "S" Then
                                ValidarLicencia = True
                                ActivaViaWeb = True
                            Else
                                If IsDate(reader("F_VENC")) Then
                                    Fechavenc = reader("F_VENC")
                                    DifDias = DateDiff(DateInterval.Day, Date.Now, Fechavenc) + 1

                                    If DifDias >= 0 And DifDias < 30 Then
                                        ValidarLicencia = True
                                    End If
                                End If
                            End If
                        Else
                            If IsDate(reader("F_VENC")) Then
                                Fechavenc = reader("F_VENC")
                                DifDias = DateDiff(DateInterval.Day, Date.Now, Fechavenc) + 1

                                If DifDias >= 0 And DifDias < 30 Then
                                    ValidarLicencia = True
                                End If
                            End If
                        End If
                    End If
                Else
                    NoExiste = False
                End If
                reader.Close()
                'cmdSql = New SqlCommand
                If Not NoExiste Then
                    ValidarLicencia = True
                    cmdSql.CommandText = "INSERT INTO merkkaba_sa.REGLIC (RFC, NOMEMP, SRVC, MAC, FECHA_REG, FECHA_VENC, RTAVTA, PAG, SISTEMA, NUMEMP, ACCESOS) 
                        VALUES('" & " ','" & RazonSocial & "','" & Servidor & "','" & MacAdres & "',GETDATE(), GETDATE() + 30,'D','N','TransportCG',' ','0')"
                    cmdSql.ExecuteNonQuery()
                Else
                    cmdSql.CommandText = "UPDATE merkkaba_sa.REGLIC SET ACCESOS = ISNULL(ACCESOS,0) + 1"
                    cmdSql.ExecuteNonQuery()
                End If
                sqlNube.Close()

                BACKUPTXT("LIC", SQL, True)

                Dim cmd As New SQLiteCommand(SQLConn)
                cmd = SQLConn.CreateCommand
                If ActivaViaWeb Then
                    LicStatus = "Licencia válida"

                    SQL = "UPDATE config SET macadres = '" & Encriptar(MacAdres) & "', " & "fecha_lic = '" &
                        Encriptar(Format(DateTime.Today.Day, "00") & "/" & Format(DateTime.Today.Month, "00") & "/" & DateTime.Today.Year) & "'"

                    cmd.CommandText = SQL
                    cmd.ExecuteNonQuery()
                Else
                    Select Case Venta_Renta
                        Case "D"
                            LicStatus = "Versión TRIAL días restantes " & DifDias
                        Case "V"
                            LicStatus = "Versión TRIAL días restantes " & DifDias
                        Case "R"
                            LicStatus = "Sistema en renta días restantes " & DifDias
                        Case Else
                            LicStatus = " "
                    End Select
                End If
                cmd.CommandText = "UPDATE config SET checklic = " & DateTime.Today.Day & DateTime.Today.Month
                cmd.ExecuteNonQuery()
            Else
                LicStatus = "Versión TRIAL"
                ValidarLicencia = True
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
            ValidarLicencia = True
        End Try
    End Function

    Public Function SystemSerialNumber() As String
        Try
            ' Get the Windows Management Instrumentation object.
            Dim wmi As Object = GetObject("WinMgmts:")

            ' Get the "base boards" (mother boards).
            Dim serial_numbers As String = ""
            Dim mother_boards As Object = wmi.InstancesOf("Win32_BaseBoard")
            For Each board As Object In mother_boards
                serial_numbers &= ", " & board.SerialNumber
            Next board
            If serial_numbers.Length > 0 Then serial_numbers = serial_numbers.Substring(2)

            Return serial_numbers
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids = cpu_ids.Substring(2)

        Return cpu_ids
    End Function

    Public Function FSQL(fFECHA As String) As String
        Try
            Return fFECHA.Substring(6, 4) & fFECHA.Substring(3, 2) & fFECHA.Substring(0, 2)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Sub BUSCA_DESCR_ART(fCVE_ART As String)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Var9 = "N" : Var10 = "N"
        Try
            SQL = "SELECT I.CVE_ART, DESCR FROM INVE" & Empresa & " I " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                "WHERE (I.CVE_ART = '" & fCVE_ART & "' OR CVE_ALTER = '" & fCVE_ART & "') AND TIPO_ELE <> 'K' AND STATUS = 'A'"
            cmd.CommandText = SQL

            cmd.Connection = cnSAE
            reader = cmd.ExecuteReader
            If reader.Read Then
                Var9 = reader("DESCR")
                Var10 = reader("CVE_ART")
            End If
            reader.Close()
        Catch ex As Exception
            Bitacora("28. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    Public Sub BUSCA_DESCR_INVE(fCVE_ART As String)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Var10 = ""
        Try
            SQL = "SELECT I.CVE_ART, DESCR, ISNULL(CAMPLIB20,'') AS LIB20 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                "LEFT JOIN INVE_CLIB" & Empresa & " L ON L.CVE_PROD = I.CVE_ART " &
                "WHERE (I.CVE_ART = '" & fCVE_ART & "' OR CVE_ALTER = '" & fCVE_ART & "') AND TIPO_ELE <> 'K' AND STATUS = 'A'"
            cmd.CommandText = SQL
            cmd.Connection = cnSAE
            reader = cmd.ExecuteReader
            If reader.Read Then
                Var9 = reader("DESCR")
                Var10 = reader("LIB20")
            End If
            reader.Close()

        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    Public Sub BUSCA_UNIDAD(fCVE_UNI As String)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
        Try
            SQL = "SELECT CLAVE, DESCR, CVE_TIPO_UNI, PLACAS_MEX FROM GCUNIDADES WHERE ISNULL(STATUS, 'A') = 'A' AND CLAVE = '" & fCVE_UNI & "'"

            cmd.CommandText = SQL
            cmd.Connection = cnSAE
            reader = cmd.ExecuteReader
            If reader.Read Then
                Var4 = fCVE_UNI  'CLAVE
                Var5 = reader("DESCR") 'NOMBRE
                Var6 = reader("CVE_TIPO_UNI") 'TIPO UNI
                Var7 = reader("PLACAS_MEX") 'PLACAS
            Else
                Var4 = "NO"
            End If
            reader.Close()

        Catch ex As Exception
            Bitacora("48. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    Public Sub BUSCA_UNIDAD_CLAVEMONTE(fCVE_UNI As String)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
        Try
            SQL = "SELECT CLAVE, DESCR, CVE_TIPO_UNI, PLACAS_MEX FROM GCUNIDADES WHERE ISNULL(STATUS, 'A') = 'A' AND CLAVEMONTE = '" & fCVE_UNI & "'"

            cmd.CommandText = SQL
            cmd.Connection = cnSAE
            reader = cmd.ExecuteReader
            If reader.Read Then
                Var4 = fCVE_UNI  'CLAVE
                Var5 = reader.ReadNullAsEmptyString("DESCR") 'NOMBRE
                Var6 = reader.ReadNullAsEmptyInteger("CVE_TIPO_UNI") 'TIPO UNI
                Var7 = reader.ReadNullAsEmptyString("PLACAS_MEX") 'PLACAS
            Else
                Var4 = "NO"
            End If
            reader.Close()

        Catch ex As Exception
            Bitacora("48. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub

    Public Sub BUSCA_VALOR_DECLARADO(fCLAVE As Integer)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Var4 = "NO" : Var5 = "" : Var6 = "" : Var7 = ""
        Try
            SQL = "SELECT E.CLAVE, ISNULL(E.IMPORTE,0) AS IMPORT, ISNULL(E.DESCR,'') AS DES 
                FROM GCVALOR_DECLARADO E WHERE E.STATUS = 'A' AND E.CLAVE = '" & fCLAVE & "'"
            cmd.CommandText = SQL
            cmd.Connection = cnSAE
            reader = cmd.ExecuteReader
            If reader.Read Then
                Var5 = reader("DES")
                Var6 = Format(reader("IMPORT"), "###,##0,00")
                Var4 = ""
            End If
            reader.Close()
        Catch ex As Exception
            Bitacora("58. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    Public Sub BUSCA_ORIGEN_DESTINO(fTIPO As String, fCLAVE As Integer)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Var9 = ""
        If fCLAVE > 0 Then
            Try
                If fTIPO = "O" Then
                    SQL = "SELECT ISNULL(DESCR,'') AS NOM FROM GCORIGEN WHERE CLAVE = " & fCLAVE & " AND STATUS = 'A'"
                Else
                    SQL = "SELECT ISNULL(DESCR,'') AS NOM FROM GCDESTINO WHERE CLAVE = " & fCLAVE & " AND STATUS = 'A'"
                End If
                cmd.CommandText = SQL
                cmd.Connection = cnSAE
                reader = cmd.ExecuteReader
                If reader.Read Then
                    Var9 = reader("NOM")
                Else
                    Var9 = "NO"
                    MsgBox("No encontraron coincidencias")
                End If
                reader.Close()

            Catch ex As Exception
                Bitacora("68. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
            End Try
        End If
    End Sub
    Public Function OBTENER_CAMPO_LIBRE_CTE(FCLAVE As String, FCAMPLIB As String) As String
        Dim LIBRE As String = ""
        Try
            If FCLAVE.Length > 0 Then
                SQL = "SELECT ISNULL(" & FCAMPLIB & ",'') AS LIB FROM CLIE_CLIB" & Empresa &
                    " WHERE CVE_CLIE = '" & FCLAVE & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LIBRE = dr("LIB")
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            Bitacora("88. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
        End Try
        Return LIBRE
    End Function
    Public Sub BUSCA_CLIENTE(fCLAVE As String)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Var8 = "" : Var9 = "" : Var10 = "" : Var11 = ""
        Try
            fCLAVE = fCLAVE.Trim
            If fCLAVE.Length > 0 Then
                If IsNumeric(fCLAVE) Then
                    fCLAVE = Space(10 - fCLAVE.Length) & fCLAVE
                End If
                Try
                    SQL = "SELECT ISNULL(NOMBRE,'') AS NOM, ISNULL(CALLE,'') AS DIR, ISNULL(RFC,'') AS RF, ISNULL(LISTA_PREC,1) AS LISTAPREC 
                        FROM CLIE" & Empresa & "
                        WHERE CLAVE = '" & fCLAVE & "' AND STATUS = 'A'"
                    cmd.CommandText = SQL
                    cmd.Connection = cnSAE
                    reader = cmd.ExecuteReader
                    If reader.Read Then
                        Var8 = fCLAVE
                        Var9 = reader("NOM")
                        Var10 = reader("RF")
                        Var11 = reader("DIR")
                        Var26 = reader("LISTAPREC")
                    Else
                        Var8 = "NO"
                        MsgBox("Cliente inexistente")
                    End If
                    reader.Close()

                Catch ex As Exception
                    Bitacora("78. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("88. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    '===
    Public Function BUSCA_NOMBRE_PROV(fCLAVE As String) As String
        Dim Nombre As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(NOMBRE,'') AS NOM FROM PROV" & Empresa & " WHERE CLAVE = '" & fCLAVE & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Nombre = dr("NOM")
                    End If
                End Using
            End Using
            Return Nombre
        Catch ex As Exception
            Bitacora("78. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
            Return Nombre
        End Try
    End Function

    Public Sub BUSCA_ANTICIPOS_VIAJE(fCVE_ANTVI As Long)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader

        Var8 = ""
        Var9 = ""
        Var10 = ""

        Try
            SQL = "SELECT A.CVE_ANTVI, A.FECHA, C.DESCR, A.IMPORTE " &
                "FROM GCANTICIPOS_VIAJE A  " &
                "LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = A.NUM_CPTO " &
                "WHERE A.CVE_ANTVI = " & fCVE_ANTVI

            cmd.CommandText = SQL
            cmd.Connection = cnSAE
            reader = cmd.ExecuteReader
            If reader.Read Then
                Var8 = reader("FECHA")
                Var9 = reader("DESCR")
                Var10 = reader("IMPORTE")
            Else
                Var8 = "NO"
            End If
            reader.Close()

        Catch ex As Exception
            Bitacora("90. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub

    Public Sub KIT_DATOS_INVE(fInven As String, fCVE_ART As String)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader

        Var9 = ""
        Var10 = ""
        Var11 = ""
        Var12 = ""
        Try
            If fInven = "Articulo" Then
                SQL = "SELECT DESCR, ISNULL(ULT_COSTO,0) AS UCOSTO, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P1 WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1), 0) AS P1, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P2 WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 2), 0) AS P2 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                "WHERE (I.CVE_ART = '" & fCVE_ART & "' OR CVE_ALTER = '" & fCVE_ART & "') AND TIPO_ELE <> 'K'"
            Else
                SQL = "SELECT DESCR, ISNULL(ULT_COSTO,0) AS UCOSTO, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P1 WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1), 0) AS P1, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P2 WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 2), 0) AS P2 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN GCCVES_ALTER A ON A.CVE_ART = I.CVE_ART " &
                "WHERE (I.CVE_ART = '" & fCVE_ART & "' OR CVE_ALTER = '" & fCVE_ART & "') AND TIPO_ELE <> 'K'"
            End If

            cmd.CommandText = SQL
            cmd.Connection = cnSAE
            reader = cmd.ExecuteReader
            If reader.Read Then
                Var9 = reader("DESCR")
                Var10 = reader("P1")
                Var11 = reader("P2")
                Var12 = reader("UCOSTO")
            End If
            reader.Close()

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & " -- ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    Public Sub CREA_TAB(fFrm As Form, fTab As String)
        If Not ExisteTab(fTab) Then
            Try
                Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = fFrm.Name).FirstOrDefault()
                If instForm Is Nothing Then
                Else
                    'instForm.Dispose()
                End If
                fFrm.TopLevel = False
                fFrm.TopMost = True
                Dim newpage As New C1.Win.C1Command.C1DockingTabPage With {.Text = fTab, .Tag = fFrm}

                newpage.Controls.Add(fFrm)

                MainRibbonForm.Tab1.TabPages.Add(newpage)

                MainRibbonForm.Tab1.Dock = DockStyle.Fill
                MainRibbonForm.Tab1.SelectedTab = newpage


                fFrm.Show()
            Catch ex As Exception
                Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
                'msgbox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                For k = 0 To MainRibbonForm.Tab1.TabPages.Count - 1
                    If MainRibbonForm.Tab1.TabPages(k).Text = fTab Then
                        MainRibbonForm.Tab1.SelectedIndex = k
                        Exit For
                    End If
                Next
            Catch ex As Exception
                Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

    End Sub
    Public Function ExisteTab(fTab As String) As Boolean
        Dim ExistTab As Boolean
        Try
            ExistTab = False
            For k = 0 To MainRibbonForm.Tab1.TabPages.Count - 1

                Debug.Print(MainRibbonForm.Tab1.TabPages(k).Text)

                If MainRibbonForm.Tab1.TabPages(k).Text = fTab Then
                    ExistTab = True
                    Exit For
                End If
            Next
            Return ExistTab
        Catch ex As Exception
            Bitacora("166. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("166. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try

    End Function

    Sub CloseTab(fTab As String, Optional fTab2 As String = "", Optional fTab3 As String = "", Optional fTab4 As String = "", Optional fTab5 As String = "")

        Try
            For k = 0 To MainRibbonForm.Tab1.TabPages.Count - 1
                If MainRibbonForm.Tab1.TabPages(k).Text = fTab Or MainRibbonForm.Tab1.TabPages(k).Text = fTab2 Or
                    MainRibbonForm.Tab1.TabPages(k).Text = fTab3 Or MainRibbonForm.Tab1.TabPages(k).Text = fTab4 Or
                    MainRibbonForm.Tab1.TabPages(k).Text = fTab5 Then
                    MainRibbonForm.Tab1.TabPages.RemoveAt(k)
                    Exit For
                End If
            Next

        Catch ex As Exception
            Bitacora("171. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("171. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Function GET_MAX_ESTACION() As Integer
        Dim k As Integer = 0
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT ESTACION FROM GCESTACIONES"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                k += 1
            Loop
            dr.Close()

        Catch Ex As Exception
            Bitacora("220. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("220. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
        Return k + 1
    End Function

    Public Function GET_MAX_NUM_CPTO(fTABLA As String) As String
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim NUM_REG As Integer
            Dim k As Integer

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(NUM_CPTO,0) AS NUM FROM " & fTABLA & " WHERE NUM_CPTO <> 0 ORDER BY NUM_CPTO"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            k = 1
            Do While dr.Read
                NUM_REG = dr("NUM")
                If NUM_REG <> k Then
                    Exit Do
                End If
                k += 1
            Loop
            dr.Close()

            NUM_REG = k

            Return NUM_REG
        Catch Ex As Exception
            Bitacora("220. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("220. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Return 50
        End Try
    End Function
    Public Function GET_MAX_OP(fCAMPO As String) As Long
        If Not Valida_Conexion() Then
            Return "1"
        End If
        Dim NUM_REG As Long = 1
        Dim SQL1 As String
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL1 = "SELECT (ISNULL(MAX(CAST(SUBSTRING(CLAVE,2,LEN(CLAVE)) AS INT)),0) + 1) AS NUM FROM GCCLIE_OP WHERE SUBSTRING(CLAVE,1,1) = '" & fCAMPO & "'"
            cmd.CommandText = SQL1
            dr = cmd.ExecuteReader
            NUM_REG = "1"
            If dr.Read Then
                NUM_REG = dr("NUM")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return NUM_REG
    End Function
    Public Function GET_MAX(fTABLA As String, fCAMPO As String, Optional ByVal fLong As Long = 0, Optional ByVal fCadena As String = "") As String
        If Not Valida_Conexion() Then
            Return "1"
        End If
        Dim NUM_REG As String
        Dim SQL1 As String
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL1 = "SELECT ISNULL(MAX(CASE WHEN ISNUMERIC(" & fCAMPO & ") > 0 THEN CAST(" & fCAMPO & " AS INT) ELSE 0 END),0) + 1 AS NUM " &
                "FROM " & fTABLA & fCadena

            cmd.CommandText = SQL1
            dr = cmd.ExecuteReader
            NUM_REG = "1"
            If dr.Read Then
                NUM_REG = dr("NUM")
            End If
            dr.Close()

            If fLong > 0 Then
                NUM_REG = Space(fLong - NUM_REG.Trim.Length) & NUM_REG.Trim
            End If
            Return NUM_REG
        Catch ex As Exception

            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 1
        End Try
    End Function

    Public Function GET_MAX_TRY(fTABLA As String, fCAMPO As String, Optional ByVal fLong As Long = 0, Optional ByVal fCadena As String = "") As String
        If Not Valida_Conexion() Then
            Return "1"
        End If
        Dim NUM_REG As String
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT ISNULL(MAX(TRY_PARSE(" & fCAMPO & " AS INT)),0) + 1 AS NUM FROM " & fTABLA & fCadena

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            NUM_REG = "1"
            If dr.Read Then
                NUM_REG = dr("NUM")
            End If
            dr.Close()

            If fLong > 0 Then
                NUM_REG = Space(fLong - NUM_REG.Trim.Length) & NUM_REG.Trim
            End If
            Return NUM_REG
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 1
        End Try
    End Function
    Public Function CONVERTIR_TO_DECIMAL(ByRef FNUM As String) As Decimal
        Dim RETURNVALUE As Decimal = 0, Num_single As Decimal
        Try
            Try
                If Not IsNothing(FNUM) Then
                    FNUM = FNUM.Replace(",", "")
                Else
                    RETURNVALUE = 0
                End If
            Catch ex As Exception
                RETURNVALUE = 0
            End Try
            If String.IsNullOrEmpty(FNUM) Then
                RETURNVALUE = 0
            Else
                If Single.TryParse(FNUM, Num_single) Then
                    RETURNVALUE = Math.Round(CSng(FNUM), 4)
                Else
                    RETURNVALUE = 0
                End If
            End If

        Catch Ex As Exception
            RETURNVALUE = 0
            Bitacora("260. " & Ex.Message & vbNewLine & Ex.StackTrace)
            'MsgBox("260. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
        Return RETURNVALUE
    End Function

    Public Function CONVERTIR_TO_INT(ByRef FNUM As String) As Long
        Dim RETURNVALUE As Single
        Dim Num_single As Single
        Try
            If String.IsNullOrEmpty(FNUM) Then
                RETURNVALUE = 0
            Else
                If Single.TryParse(FNUM, Num_single) Then
                    RETURNVALUE = CInt(FNUM)
                Else
                    RETURNVALUE = 0
                End If
            End If
            Return RETURNVALUE
        Catch Ex As Exception
            Bitacora("270. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Return 0
        End Try
    End Function
    Public Function CONVERTIR_TO_LONG(ByRef FNUM As String) As Long
        Dim RETURNVALUE As Long
        Dim Num_single As Long

        Try
            If String.IsNullOrEmpty(FNUM) Then
                RETURNVALUE = 0
            Else
                If Long.TryParse(FNUM, Num_single) Then
                    RETURNVALUE = CLng(FNUM)
                Else
                    RETURNVALUE = 0
                End If
            End If
            Return RETURNVALUE
        Catch Ex As Exception
            Bitacora("270. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("270. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Return 0
        End Try
    End Function
    Public Function GRABA_MOTIVO_CANC(FMODULO As String, fOBSER As String) As Long
        Dim CVE_MTC As Long = 0
        Try
            Dim cmd As New SqlCommand

            SQL = "INSERT INTO GCMOTIVO_CANC (CVE_MTC, MODULO, USUARIO, DESCR, FECHAELAB) 
                OUTPUT Inserted.CVE_MTC VALUES((SELECT ISNULL(MAX(CVE_MTC),0) + 1 FROM GCMOTIVO_CANC),'" &
                FMODULO & "','" & USER_GRUPOCE & "','" & fOBSER & "',GETDATE())"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteScalar.ToString
            If returnValue IsNot Nothing Then
                If CLng(returnValue) > 0 Then
                    CVE_MTC = returnValue
                End If
            End If
        Catch Ex As Exception
            Bitacora("280. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
        Return CVE_MTC
    End Function
    Public Function GRABA_OBSER(fOBSER As String) As Long
        Dim CVE_OBS As Long
        Try
            Dim cmd As New SqlCommand
            CVE_OBS = 0

            SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & fOBSER & "')"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteScalar.ToString
            If returnValue IsNot Nothing Then
                If CLng(returnValue) > 0 Then
                    CVE_OBS = returnValue
                End If
            End If
            Return CVE_OBS
        Catch Ex As Exception
            Bitacora("280. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Return CVE_OBS
        End Try
    End Function
    Public Function INSERT_UPDATE_GCOBS(fCVE_OBS As Long, fOBS As String) As Long
        Try
            Dim cmd As New SqlCommand
            Dim CVE_OBS As Long

            If fOBS.Trim.Length > 0 Then
                If fCVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & fOBS & "')"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & fOBS & "' WHERE CVE_OBS = " & fCVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            CVE_OBS = fCVE_OBS
                        End If
                    End If
                End If
            End If

            Return CVE_OBS
        Catch ex As Exception
            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try

    End Function
    Public Function INSERT_UPDATE_OBS(fCVE_OBS As Long, fOBS As String) As Long
        Try
            Dim cmd As New SqlCommand
            Dim CVE_OBS As Long

            If fOBS.Trim.Length > 0 Then
                If fCVE_OBS = 0 Then
                    SQL = "INSERT INTO OBS_DOCC" & Empresa & " (CVE_OBS, STR_OBS) OUTPUT Inserted.CVE_OBS VALUES(" &
                        "(SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM OBS_DOCC" & Empresa & "),'" & fOBS & "')"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If Val(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If

                    SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = ISNULL((SELECT ISNULL(MAX(CVE_OBS),0) AS CVEOBS FROM OBS_DOCC" & Empresa & "),0) WHERE ID_TABLA = 57"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                Else
                    SQL = "UPDATE OBS_DOCC" & Empresa & " SET STR_OBS = '" & fOBS & "' WHERE CVE_OBS = " & fCVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If Val(returnValue) > 0 Then
                            CVE_OBS = fCVE_OBS
                        End If
                    End If
                End If
            End If
            Return CVE_OBS
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function

    Public Sub INSERT_UPDATE_OBS_FAC_CLIB(fCVE_DOC As String, fTIPO As String, fOBS As String)
        Try
            If fOBS.Trim.Length > 0 Then
                fOBS = fOBS.Replace("'", "””")

                SQL = "UPDATE FACT" & fTIPO & "_CLIB" & Empresa & " SET CAMPLIB5 = '" & fOBS & "' WHERE CLAVE_DOC = '" & fCVE_DOC & "' " &
                    "IF @@ROWCOUNT  = 0 " &
                    "INSERT INTO FACT" & fTIPO & "_CLIB" & Empresa & " (CLAVE_DOC, CAMPLIB5)  VALUES('" & fCVE_DOC & "','" & fOBS & "')"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub INSERT_UPDATE_OBS_FAC_CLIB_PAR(fCVE_DOC As String, fTIPO As String, fNUM_PAR As Integer, fOBS As String)
        Try
            If fOBS.Trim.Length > 0 Then
                fOBS = fOBS.Replace("'", "””")

                SQL = "UPDATE PAR_FACT" & fTIPO & "_CLIB" & Empresa & " SET CAMPLIB1 = '" & fOBS & "' WHERE CLAVE_DOC = '" & fCVE_DOC & "' AND NUM_PART = " & fNUM_PAR &
                    " IF @@ROWCOUNT  = 0 " &
                    "INSERT INTO PAR_FACT" & fTIPO & "_CLIB" & Empresa & " (CLAVE_DOC, NUM_PART, CAMPLIB1)  VALUES('" & fCVE_DOC & "','" & fNUM_PAR & "','" & fOBS & "')"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Sub INSERT_UPDATE_OBS_COMP_CLIB(fCVE_DOC As String, fTIPO As String, fOBS As String)
        Try
            If fOBS.Trim.Length > 0 Then
                fOBS = fOBS.Replace("'", "””")

                SQL = "UPDATE COMP" & fTIPO & "_CLIB" & Empresa & " SET CAMPLIB1 = '" & fOBS & "' WHERE CLAVE_DOC = '" & fCVE_DOC & "' " &
                    "IF @@ROWCOUNT  = 0 " &
                    "INSERT INTO COMP" & fTIPO & "_CLIB" & Empresa & " (CLAVE_DOC, CAMPLIB1)  VALUES('" & fCVE_DOC & "','" & fOBS & "')"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub INSERT_UPDATE_OBS_COMP_CLIB_PAR(fCVE_DOC As String, fTIPO As String, fNUM_PAR As Integer, fOBS As String)
        Try
            If fOBS.Trim.Length > 0 Then
                fOBS = fOBS.Replace("'", "””")


                SQL = "UPDATE PAR_COMP" & fTIPO & "_CLIB" & Empresa & " SET CAMPLIB1 = '" & fOBS & "' WHERE CLAVE_DOC = '" & fCVE_DOC & "' AND NUM_PART = " & fNUM_PAR &
                    " IF @@ROWCOUNT  = 0 " &
                    "INSERT INTO PAR_COMP" & fTIPO & "_CLIB" & Empresa & " (CLAVE_DOC, NUM_PART, CAMPLIB1)  VALUES('" & fCVE_DOC & "','" & fNUM_PAR & "','" & fOBS & "')"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Function INSERT_UPDATE_OBS_FAC(fCVE_OBS As Long, fOBS As String) As Long

        Try
            Dim cmd As New SqlCommand
            Dim CVE_OBS As Long

            If fOBS.Trim.Length > 0 Then
                If fOBS.Length > 255 Then
                    fOBS = fOBS.Substring(0, 255)
                End If
                If fCVE_OBS = 0 Then
                    SQL = "INSERT INTO OBS_DOCF" & Empresa & " (CVE_OBS, STR_OBS) OUTPUT Inserted.CVE_OBS VALUES(" &
                        "(SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM OBS_DOCF" & Empresa & "),'" & fOBS & "')"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If Val(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                    SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = ISNULL((SELECT ISNULL(MAX(CVE_OBS),0) AS CVEOBS FROM OBS_DOCF" & Empresa & "),0) WHERE ID_TABLA = 56"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                Else SQL = "UPDATE OBS_DOCF" & Empresa & " SET STR_OBS = '" & fOBS & "' WHERE CVE_OBS = " & fCVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            CVE_OBS = fCVE_OBS
                        End If
                    End If
                End If
            End If
            Return CVE_OBS
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
    Public Function INSERT_OBS_MINVE(fOBS As String) As Long
        Try
            Dim cmd As New SqlCommand
            Dim CVE_OBS As Long = 0

            If fOBS.Trim.Length > 0 Then
                If fOBS.Length > 255 Then
                    fOBS = fOBS.Substring(0, 255)
                End If
                fOBS = RemoveCharacter(fOBS)
                SQL = "INSERT INTO OMINVE" & Empresa & " (CVE_OBS, STR_OBS) OUTPUT Inserted.CVE_OBS VALUES(
                      (SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM OMINVE" & Empresa & "),'" & fOBS & "')"
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteScalar.ToString
                If returnValue IsNot Nothing Then
                    If Val(returnValue) > 0 Then
                        CVE_OBS = returnValue
                    End If
                End If
                SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = ISNULL((SELECT ISNULL(MAX(CVE_OBS),0) AS CVEOBS FROM OMINVE" & Empresa & "),0) WHERE ID_TABLA = 55"
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End If
            Return CVE_OBS
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
    Public Function INSERT_UPDATE_OCLI(fCVE_OBS As Long, fOBS As String) As Long

        Try
            Dim cmd As New SqlCommand
            Dim CVE_OBS As Long

            If fOBS.Trim.Length > 0 Then
                If fCVE_OBS = 0 Then

                    SQL = "INSERT INTO OCLI" & Empresa & " (CVE_OBS, STR_OBS) OUTPUT Inserted.CVE_OBS VALUES(" &
                        "(SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM OCLI" & Empresa & "),'" & fOBS & "')"

                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE OCLI" & Empresa & " SET STR_OBS = '" & fOBS & "' WHERE CVE_OBS = " & fCVE_OBS

                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            CVE_OBS = fCVE_OBS
                        End If
                    End If
                End If
            Else
                CVE_OBS = 0
            End If

            Return CVE_OBS

        Catch ex As Exception
            Bitacora("311. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
    Public Function BUSCA_CAT_XML(FXML As String, FCLAVE As String) As String
        Dim doc As New XmlDocument()
        Dim ResulBusqueda As String = ""

        FCLAVE = FCLAVE.Replace(",", "")
        FCLAVE = FCLAVE.Replace("'", "")

        Select Case FXML
            Case "CAT_UNIDAD_PESO"
                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_UNIDAD_PESO.xml")

                Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & FCLAVE & "']")
                If nodeList.Count > 0 Then
                    For Each node As XmlNode In nodeList
                        If Not IsNothing(node.Attributes("Descripcion")) Then
                            ResulBusqueda = node.Attributes("Descripcion").Value
                        End If
                    Next
                End If
            Case "CATINV", "CATINV2"
                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_PROD_SERV.xml")

                Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_ClaveProdServ='" & FCLAVE & "']")
                If nodeList.Count > 0 Then
                    For Each node As XmlNode In nodeList
                        If Not IsNothing(node.Attributes("Descripcion")) Then
                            ResulBusqueda = node.Attributes("Descripcion").Value
                        End If
                    Next
                End If
            Case "CAT_MATERIAL_PELIGROSO"
                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_MATERIAL_PELIGROSO.xml")

                Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & FCLAVE & "']")
                If nodeList.Count > 0 Then
                    For Each node As XmlNode In nodeList
                        If Not IsNothing(node.Attributes("Descripcion")) Then
                            ResulBusqueda = node.Attributes("Descripcion").Value
                        End If
                    Next
                End If
            Case "CAT_TIPO_EMBALAJE"
                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_TIPO_EMBALAJE.xml")

                Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & FCLAVE & "']")
                If nodeList.Count > 0 Then
                    For Each node As XmlNode In nodeList
                        If Not IsNothing(node.Attributes("Descripcion")) Then
                            ResulBusqueda = node.Attributes("Descripcion").Value
                        End If
                    Next
                End If
        End Select


        Return ResulBusqueda

    End Function
    Public Function BUSCA_CAT2(fTABLA As String, fCLAVE As String) As String
        If Not Valida_Conexion() Then
            Return ""
        End If

        If fTABLA.Trim.Length = 0 Or fCLAVE.Trim.Length = 0 Then
            Return ""
        End If
        Dim CADENA As String = ""

        If fCLAVE = "0" Or fCLAVE = "" Then
            Return ""
        End If

        fCLAVE = fCLAVE.Replace(",", "")
        fCLAVE = fCLAVE.Replace("'", "")
        SQL = ""
        Select Case fTABLA
            Case "TEA"
                SQL = "SELECT DESCRIPCION AS DES
                        FROM PRECIOS" & Empresa & "
                        WHERE CVE_PRECIO = " & fCLAVE
            Case "ConfigVehicular"
                SQL = "SELECT descripcion as DES FROM tblcconfigautotransporte WHERE clave = '" & fCLAVE & "'"
            Case "Marca reno"
                SQL = "SELECT DESCR AS DES FROM GCMARCAS_RENOVADO WHERE CVE_MARCA = '" & fCLAVE & "'"
            Case "Prov reno"
                SQL = "SELECT DESCR AS DES FROM GCPROVRENOVADO WHERE CVE_PRE = '" & fCLAVE & "'"
            Case "tblcclaveunidadpeso"
                SQL = "SELECT nombre as DES FROM tblcclaveunidadpeso WHERE clave = '" & fCLAVE & "'"
            Case "tblcclaveunidad"
                SQL = "SELECT nombre as DES FROM tblcclaveunidad WHERE claveUnidad = '" & fCLAVE & "'"
            Case "Bienestrans"
                'SQL = "SELECT descripcion AS DES FROM tblcclaveprodserv WHERE claveProdServ = '" & fCLAVE & "'"
            Case "tblcmaterialpeligroso"
                SQL = "SELECT descripcion as DES FROM tblcmaterialpeligroso WHERE clave = '" & fCLAVE & "'"
            Case "tblctipoembalaje"
                SQL = "SELECT descripcion AS DES FROM tblctipoembalaje WHERE clave = '" & fCLAVE & "'"
            Case "tblSectorCOFEPRIS"
                SQL = "SELECT descripcion AS DES FROM tblSectorCOFEPRIS WHERE clave = '" & fCLAVE & "'"
            Case "tblFormaFarmaceutica"
                SQL = "SELECT descripcion AS DES FROM tblFormaFarmaceutica WHERE clave = '" & fCLAVE & "'"
            Case "tblCondicionesEspeciales"
                SQL = "SELECT descripcion AS DES FROM tblCondicionesEspeciales WHERE clave = '" & fCLAVE & "'"
            Case "tblTipoMateria"
                SQL = "SELECT descripcion AS DES FROM tblTipoMateria WHERE clave = '" & fCLAVE & "'"
        End Select



        If SQL.Trim.Length > 0 Then

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        CADENA = dr("DES").ToString

                        If fTABLA = "TEA" Then
                            Var4 = dr("CVE_TAQ") 'CLAVE
                            Var5 = dr("T1_ANCHO") 'ANCHO
                            Var6 = dr("T1_ALTO") 'ALTO
                            Var7 = dr("T1_PROFUNDIDAD") 'PROFUNDIDAD
                        End If
                    End If
                End Using
            End Using
        End If



        Return CADENA

    End Function
    Public Function BUSCA_CAT(fTABLA As String, fCLAVE As String, Optional Mostra_EstatusA As Boolean = True) As String
        If Not Valida_Conexion() Then
            Return ""
        End If
        Try
            If fTABLA.Trim.Length = 0 Or fCLAVE.Trim.Length = 0 Then
                Return ""
            End If

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim CADENA As String

            If fCLAVE = "0" Or fCLAVE = "" Then
                Return ""
            End If

            fCLAVE = fCLAVE.Replace(",", "")
            fCLAVE = fCLAVE.Replace("'", "")

            cmd.Connection = cnSAE
            SQL = ""
            Select Case fTABLA
                Case "Metodo de pago"
                    SQL = "SELECT descripcion AS DES From tblcmetodopago Where metodoPago = '" & fCLAVE & "'"

                Case "USO CFDI"
                    SQL = "SELECT descripcion AS DES FROM tblcusocfdi WHERE usoCfdi = '" & fCLAVE & "'"
                Case "Flujo"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM SOENTRADADINERO WHERE TIPO = '" & Var5 & "' AND CLAVE = " & fCLAVE
                Case "ListaPrec"
                    SQL = "SELECT DESCRIPCION AS DES
                        FROM PRECIOS" & Empresa & "
                        WHERE CVE_PRECIO = " & fCLAVE
                Case "MinveEnt", "MinveSal"
                    SQL = "SELECT DESCR AS DES
						FROM CONM" & Empresa & "
						WHERE STATUS = 'A' " & Var7 & " AND CVE_CPTO = " & fCLAVE
                    SQL = SQL
                Case "TipoActivo"
                    SQL = "SELECT DESCRIP AS DES FROM GCTIPACTIV WHERE CLAVE = '" & fCLAVE & "'"
                Case "Depto"
                    SQL = "SELECT DESCR AS DES FROM GCDEPTOS WHERE CVE_DEPTO = '" & fCLAVE & "'"
                Case "NumGen"
                    SQL = "SELECT G.DESCR AS DES
                        FROM GCHORAS_GEN G
                        WHERE CVE_GEN = '" & fCLAVE & "'"
                    Debug.Print(SQL)

                Case "NumGen"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES
                        FROM GCHORAS_GEN
                        WHERE CVE_GEN = " & fCLAVE
                Case "GCCATEVA"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    SQL = "SELECT DESCR AS DES FROM GCCATEVA E WHERE CVE_EVA = " & fCLAVE
                    Debug.Print(SQL)
                Case "FAC CFDI"
                    SQL = "SELECT FACTURA AS DES FROM CFDI WHERE ISNULL(ESTATUS,'A') <> 'C' AND FACTURA = '" & fCLAVE & "'"
                Case "GCTIPO_OPERACION"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    SQL = "SELECT DESCR AS DES FROM GCTIPO_OPERACION T WHERE ISNULL(STATUS,'A') = 'A' AND CVE_TIPO = " & fCLAVE
                Case "tblcformapago"
                    SQL = "SELECT descripcion AS DES FROM tblcformapago WHERE formaPago = '" & fCLAVE & "'"
                Case "Sueldo operadores"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    SQL = "SELECT CVE_SUOP AS DES FROM GCSUELDO_OPER WHERE CVE_SUOP = " & fCLAVE
                Case "CuentaBeneficiario"
                    SQL = "SELECT CUENTA_BANCARIA, RFC_BANCO AS DES, NOMBRE_BANCO FROM CUENTA_BENEF" & Empresa & " WHERE CUENTA_BANCARIA = '" & fCLAVE & "'"
                Case "CuentaBeneficiario2"
                    SQL = "SELECT NOMBRE_BANCO AS DES FROM CUENTA_BENEF" & Empresa & " WHERE CLAVE = '" & fCLAVE & "'"
                Case "CuentaOrdenante"
                    SQL = "SELECT CUENTA_BANCARIA, RFC_BANCO AS DES, NOMBRE_BANCO FROM CUENTA_ORD" & Empresa & " WHERE CUENTA_BANCARIA = '" & fCLAVE & "'"
                Case "Almacen"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM ALMACENES" & Empresa & " WHERE CVE_ALM = " & fCLAVE

                Case "GCCASETAS_X_RUTA"
                    If fCLAVE = "" Then fCLAVE = "0"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    SQL = "SELECT C.CVE_CXR, C.CVE_PLAZA, C.CVE_PLAZA2, P1.CIUDAD AS DES, P2.CIUDAD AS CIUDAD2, 
                        ISNULL(IMPORTE_CASETAS,0) AS IMPORTE, C.CLAVE_OP, C.IAVE, OP.NOMBRE
                        FROM GCCASETAS_X_RUTA C 
                        LEFT JOIN GCCLIE_OP OP On OP.CLAVE = C.CLAVE_OP
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA 
                        LEFT JOIN GCPLAZAS P2 On P2.CLAVE = C.CVE_PLAZA2
                        WHERE C.STATUS = 'A' AND CVE_CXR = " & fCLAVE
                Case "Carta porte"
                    SQL = "SELECT FACTURA AS DES
                        FROM CFDI 
                        WHERE DOCUMENT = '" & fCLAVE & "'"
                    Debug.Print(SQL)
                Case "Aseguradora"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM GCASEGURADORAS WHERE LTRIM(RTRIM(CLAVE)) = '" & fCLAVE.Trim & "'"
                Case "Motor"
                    If fCLAVE = "" Or Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCMOTORES WHERE CVE_MOT = " & fCLAVE
                Case "Deduccion"
                    If fCLAVE = "" Or Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCDEDUCCIONES WHERE CVE_DED = " & fCLAVE
                Case "Tanques"
                    If fCLAVE = "" Then
                        fCLAVE = "0"
                    End If
                    'Var4 = Fg(Fg.Row, 1) 'CLAVE
                    'Var5 = Fg(Fg.Row, 2) 'ANCHO
                    'Var6 = Fg(Fg.Row, 3) 'ALTO
                    'Var7 = Fg(Fg.Row, 4) 'PROFUNDIDAD
                    'Var8 = Fg(Fg.Row, 5) 'LITROS
                    'Var9 = Fg(Fg.Row, 6) 'ANCHO
                    'Var10 = Fg(Fg.Row, 7) 'ALTO
                    'Var11 = Fg(Fg.Row, 8) 'PROFUNDIDAD
                    'Var12 = Fg(Fg.Row, 9) 'LITROS
                    SQL = "SELECT CVE_TAQ, T1_ANCHO, T1_ALTO, T1_PROFUNDIDAD, T1_LITROS AS DES, 
                        T2_ANCHO, T2_ALTO, T2_PROFUNDIDAD, T2_LITROS FROM GCTANQUES WHERE STATUS <> 'C'AND CVE_TAQ = " & fCLAVE
                Case "OT"
                    SQL = "SELECT ISNULL(CVE_ORD,'') AS DES FROM GCORDEN_TRABAJO_EXT WHERE STATUS <> 'C' AND CVE_ORD = '" & fCLAVE & "'"
                Case "Valor Declarado"
                    If fCLAVE = "" Or Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, IMPORTE FROM GCVALOR_DECLARADO WHERE STATUS = 'A' AND CLAVE = " & fCLAVE
                Case "RecogerEn", "EntregarEn"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCRECOGER_EN_ENTREGAR_EN WHERE CVE_REG = '" & fCLAVE & "'"
                Case "FACT"
                    SQL = "SELECT F.CVE_DOC AS DES, CLAVE, NOMBRE, FECHA_DOC, IMPORTE, ISNULL(DOC_SIG,'') AS DOCSIG, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG
                        FROM FACT" & Var15 & Empresa & " F
                        LEFT JOIN FACT" & Var15 & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = F.CVE_DOC
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                        WHERE F.STATUS <> 'C' AND LEN(ISNULL(DOC_SIG,'')) = 0 AND
                        ISNULL((SELECT ISNULL(SUM(PXS),0) FROM PAR_FACT" & Var15 & Empresa & " WHERE CVE_DOC = F.CVE_DOC),0) > 0
                        AND F.CVE_DOC = '" & fCLAVE & "'"
                    Debug.Print(SQL)
                Case "COMP"
                    SQL = "SELECT F.CVE_DOC AS DES, CLAVE, NOMBRE, FECHA_DOC, IMPORTE, ISNULL(DOC_SIG,'') AS DOCSIG, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG
                        FROM COMP" & Var15 & Empresa & " F
                        LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                        WHERE F.STATUS <> 'C' AND
                        ISNULL((SELECT ISNULL(SUM(PXR),0) FROM PAR_COMP" & Var15 & Empresa & " WHERE CVE_DOC = F.CVE_DOC),0) > 0 AND 
                        F.CVE_DOC = '" & Var11 & "'"
                Case "ServiciosOrdenes"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCSERVICIOS_MANTE WHERE STATUS = 'A'"
                Case "Usuario"
                    SQL = "SELECT NOMBRE AS DES FROM GCUSUARIOS WHERE USUARIO = '" & Var4 & "'"

                Case "PagoComplemento"
                    SQL = "SELECT M.REFER AS DES, M.IMPORTE, NUM_CPTO
                        FROM CUEN_DET" & Empresa & " M
                        LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = M.REFER
                        WHERE ISNULL(F.METODODEPAGO,'PPD') = 'PPD' AND ISNULL(FORMADEPAGOSAT,'99') = 99 AND ISNULL(CVE_DOC_COMPPAGO,'') = '' AND 
                        REFER = '" & fCLAVE & "' AND CVE_CLIE = '" & Var4 & "'"
                Case "ClieDocto"
                    SQL = "SELECT M.DOCTO AS DES, P.NOMBRE, M.FECHA_APLI, M.NO_FACTURA, M.IMPORTE
                        FROM CUEN_M" & Empresa & " M
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE 
                        WHERE M.NUM_CPTO <> 9 AND REFER = '" & fCLAVE & "'"
                    Debug.Print("")
                Case "ProvDocto"
                    SQL = "SELECT M.DOCTO AS DES, P.NOMBRE, M.FECHA_APLI, M.NO_FACTURA, M.IMPORTE
                        FROM PAGA_M" & Empresa & " M
                        LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = M.CVE_PROV
                        WHERE M.NUM_CPTO <> 9 AND REFER = '" & fCLAVE & "'"
                    Debug.Print("")
                Case "ClieDocSaldos"
                    SQL = "SELECT M.REFER AS DES, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,
	                    ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND 
	                    M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) + 
	                    (SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM CUEN_DET" & Empresa & " C3 
	                    WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1) AS SUMA_CUENDET,
	                    M.IMPORTE, M.IMPORTE + 
                      ISNULL((SELECT SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " C4 WHERE REFER = M.REFER AND CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO AND NUM_CARGO = M.NUM_CARGO),0) AS SALDO,
	                    M.DOCTO, M.NUM_CARGO, M.NUM_CPTO
	                    FROM CUEN_M" & Empresa & " M
	                    INNER JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE
	                    WHERE M.NUM_CPTO <> 9 AND
	                    (M.IMPORTE + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE CVE_CLIE = M.CVE_CLIE AND REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND M.NUM_CARGO = D.NUM_CARGO),0)) > 0.1 " &
                        IIf(Var4.Trim.Length = 0, "", " AND M.CVE_CLIE = '" & Var4 & "'") & " AND M.REFER = '" & fCLAVE & "'"
                    'WHERE REFER = '" & fCLAVE & "' " & Var4
                    Debug.Print("")
                Case "ProvDocSaldos2"
                    SQL = "SELECT M.REFER AS DES, M.CVE_PROV, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,
	                    ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " D WHERE M.CVE_PROV = D.CVE_PROV AND 
	                    M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) + 
	                    (SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM PAGA_DET" & Empresa & " C3 
	                    WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1) AS SUMA_CUENDET,
	                    M.IMPORTE, M.IMPORTE + 
                        ISNULL((SELECT SUM(IMPORTE*SIGNO) FROM PAGA_DET" & Empresa & " C4 WHERE REFER = M.REFER AND CVE_PROV = M.CVE_PROV AND ID_MOV = M.NUM_CPTO AND NUM_CARGO = M.NUM_CARGO),0) AS SALDO,
	                    M.DOCTO, M.NUM_CARGO, M.NUM_CPTO
	                    FROM PAGA_M" & Empresa & " M
	                    INNER JOIN PROV" & Empresa & " P ON P.CLAVE = M.CVE_PROV 
	                    WHERE M.NUM_CPTO <> 9 AND
	                    (M.IMPORTE + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " D WHERE CVE_PROV = M.CVE_PROV AND REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND M.NUM_CARGO = D.NUM_CARGO),0)) > 0.1 " &
                        IIf(Var4.Trim.Length = 0, "", " AND M.CVE_PROV = '" & Var4 & "'") & " AND M.REFER = '" & fCLAVE & "'"
                    'WHERE REFER = '" & fCLAVE & "' " & Var4
                    Debug.Print("")
                Case "ProvDocSaldos"
                    SQL = "SELECT M.REFER AS DES, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA, M.NUM_CARGO,
                        ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " D WHERE M.CVE_PROV = D.CVE_PROV AND 
                        M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) + 
                        (SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM PAGA_DET" & Empresa & " C3 
                        WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1) AS SUMA_CUENDET,
                        ISNULL((SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM PAGA_DET" & Empresa & " C3 
                        WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1),0) AS CARGOS, M.IMPORTE, M.NUM_CPTO
                        FROM PAGA_M" & Empresa & " M
                        WHERE M.REFER = '" & Var4 & "' AND M.CVE_PROV = '" & Var5 & "'"
                    Debug.Print("")
                Case "GCSTATUS_CARTA_PORTE"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCSTATUS_CARTA_PORTE WHERE CVE_CAP = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Status unidad"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'DISPONIBLE') AS DES FROM GCCAT_STATUS_UNIDADES WHERE CLAVE = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Estatus Viaje"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCCAT_STATUS_VIAJE WHERE CLAVE = " & fCLAVE & " AND STATUS  = 'A'"

                Case "ArticulosLlantas"
                    SQL = "SELECT MAX(I.DESCR) AS DES
                        FROM MULT" & Empresa & " M 
                        LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                        WHERE I.TIPO_ELE = 'P' AND M.CVE_ALM IN (SELECT NUM_ALM FROM GCLLANTAS_ALMACENES) AND M.CVE_ART = '" & fCLAVE & "'  
                        GROUP BY M.CVE_ART"
                Case "Inven"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM INVE" & Empresa & " I " &
                        "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                        "WHERE (I.CVE_ART = '" & fCLAVE & "' OR CVE_ALTER = '" & fCLAVE & "') AND STATUS  = 'A' AND TIPO_ELE <> 'K' AND I.CVE_ART <> 'TOT' "
                    Debug.Print("")
                Case "FACTURA"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES 
                        FROM INVE" & Empresa & " I
                        LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                        INNER JOIN GCPARAMVENTAS_LIN_FAC L ON L.LINEA = I.LIN_PROD
                        WHERE (I.CVE_ART = '" & fCLAVE & "' OR CVE_ALTER = '" & fCLAVE & "') AND 
                        STATUS  = 'A' AND TIPO_ELE <> 'K' AND I.CVE_ART <> 'TOT' "
                    Debug.Print("")
                Case "InveP"
                    SQL = "SELECT CASE WHEN ISNULL(DESCR,'') = '' THEN I.CVE_ART ELSE ISNULL(DESCR,'') END AS DES, 
                        ISNULL(CVE_ALTER,'') AS NUM_PARTE, ISNULL(TIPO_ELE,'') AS T_ELE, 
                        (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I
                        LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                        WHERE (I.CVE_ART = '" & fCLAVE & "' OR CVE_ALTER = '" & fCLAVE & "') AND I.STATUS  = 'A' AND TIPO_ELE = 'P'"
                Case "InvesSAE"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, ISNULL(CVE_ALTER,'') AS NUM_PARTE,
                        (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1 
                        FROM INVE" & Empresa & " I
                        LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                        WHERE (I.CVE_ART = '" & fCLAVE & "' OR CVE_ALTER = '" & fCLAVE & "') AND I.STATUS  = 'A' AND TIPO_ELE = 'S' AND 
                        LIN_PROD = '" & LINEA_VALOR_DECLA & "'"

                Case "InvenTabRutas"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, ISNULL(CVE_ALTER,'') AS NUM_PARTE,
                        (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1 
                        FROM INVE" & Empresa & " I
                        LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                        WHERE (I.CVE_ART = '" & fCLAVE & "' OR CVE_ALTER = '" & fCLAVE & "') AND I.STATUS  = 'A' AND 
                        LIN_PROD = '" & Var11 & "'"

                Case "InveS"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, ISNULL(CVE_ALTER,'') AS NUM_PARTE,
                        ISNULL(TIPO_ELE,'') AS T_ELE,
                        (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I
                        LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                        WHERE (I.CVE_ART = '" & fCLAVE & "' OR CVE_ALTER = '" & fCLAVE & "') AND I.STATUS  = 'A' AND TIPO_ELE = 'S'"
                Case "InveS2"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, ISNULL(CVE_ALTER,'') AS NUM_PARTE,
                        ISNULL(TIPO_ELE,'') AS T_ELE,
                        (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I
                        LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                        WHERE (I.CVE_ART = '" & fCLAVE & "' OR CVE_ALTER = '" & fCLAVE & "') AND I.STATUS  = 'A' AND
                        TIPO_ELE = 'S' AND LIN_PROD = '" & Var5 & "' "
                Case "InveLiq"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES
                        FROM INVE" & Empresa & " I
                        LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                        WHERE (I.CVE_ART = '" & fCLAVE & "' OR CVE_ALTER = '" & fCLAVE & "') AND I.STATUS  = 'A' AND LIN_PROD = '" & Var5 & "'"
                    '===================================================================================================
                    'GCINVER
                Case "InvenR"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, " &
                        "ISNULL((SELECT TOP 1 CVE_ALTER FROM GCCVES_ALTER A WHERE CVE_ART = I.CVE_ART),'') AS NUM_PARTE, ISNULL(TIPO_ELE,'') AS T_ELE " &
                        "FROM GCINVER I " &
                        "WHERE CVE_ART = '" & fCLAVE & "' AND STATUS  = 'A' AND TIPO_ELE <> 'K'"
                Case "InvenRP"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES " &
                        "FROM GCINVER I " &
                        "WHERE CVE_ART = '" & fCLAVE & "' AND STATUS  = 'A' AND TIPO_ELE = 'P'"
                Case "InvenRS"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES " &
                        "FROM GCINVER I " &
                        "WHERE CVE_ART = '" & fCLAVE & "' AND STATUS  = 'A' AND TIPO_ELE = 'S'"
                    '===================================================================================================
                Case "Cliente"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM CLIE" & Empresa & " WHERE REPLACE(CLAVE,' ','') = '" & fCLAVE.Replace(" ", "") & "'"
                Case "ClieOT"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES, ISNULL(CAMPLIB5,0) AS LIB5, ISNULL(CAMPLIB6,0) AS LIB6 " &
                        "FROM CLIE" & Empresa & " C " &
                        "LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = C.CLAVE " &
                        "WHERE CLAVE = '" & fCLAVE & "' AND C.STATUS  = 'A'"
                Case "Prov"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM PROV" & Empresa & " WHERE CLAVE = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "ProvLib"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES, ISNULL(CAMPLIB6,0) AS LIB6
                        FROM PROV" & Empresa & " 
                        LEFT JOIN PROV_CLIB" & Empresa & " L ON L.CVE_PROV = CLAVE    
                        WHERE CLAVE = '" & fCLAVE & "' AND STATUS  = 'A'"
                    Debug.Print(SQL)
                Case "Esquema"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCRIPESQ,'') AS DES FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Linea"
                    SQL = "SELECT ISNULL(DESC_LIN,'') AS DES FROM CLIN" & Empresa & " WHERE CVE_LIN = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Moneda"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, CVE_MONED FROM MONED" & Empresa & " WHERE NUM_MONED = " & fCLAVE & " AND STATUS  = 'A'"

                Case "Moneda2"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM MONED" & Empresa & " WHERE CVE_MONED = '" & fCLAVE & "' AND STATUS  = 'A'"
                    SQL2 = SQL
                Case "Moneda3"
                    SQL = "SELECT ISNULL(CVE_MONED,'') AS DES FROM MONED" & Empresa & " WHERE NUM_MONED = '" & fCLAVE & "' AND STATUS  = 'A'"
                    SQL2 = SQL

                Case "Pais"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM PAIS" & Empresa & " WHERE CVE_PAIS = '" & fCLAVE & "'"
                Case "Zona"
                    SQL = "SELECT ISNULL(TEXTO,'') AS DES FROM ZONA" & Empresa & " WHERE CVE_ZONA = '" & fCLAVE & "'"
                Case "Vend"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM VEND" & Empresa & " WHERE CVE_VEND = '" & fCLAVE & "'"
                Case "Tip Tercero"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM TIPO_TERCEROS" & Empresa & " WHERE TIPO = " & fCLAVE
                Case "Tip Opera"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM OPER_TERCEROS" & Empresa & " WHERE TIPO = " & fCLAVE

                Case "ConcSAT"
                    SQL = "SELECT FORMADEPAGOSAT, DESCR AS DES, NUM_CPTO FROM CONC" & Empresa & " 
                        WHERE STATUS = 'A' AND TIPO = 'A' AND CON_REFER = 'S' AND 
                        ISNULL(FORMADEPAGOSAT,'') <> '' AND FORMADEPAGOSAT = '" & fCLAVE & "'"

                Case "ConcCxC"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM CONC" & Empresa & " WHERE NUM_CPTO = " & fCLAVE

                Case "ConcCxCRefer"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM CONC" & Empresa & " WHERE STATUS = 'A' AND CON_REFER = 'S' AND NUM_CPTO = " & fCLAVE

                Case "ConcCxP"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM CONP" & Empresa & " WHERE STATUS = 'A' AND NUM_CPTO = " & fCLAVE
                Case "ConcCxPRefer"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM CONP" & Empresa & " WHERE STATUS = 'A' AND CON_REFER = 'S' AND NUM_CPTO = " & fCLAVE

                Case "Estados"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM GCESTADOS WHERE STATUS = 'A' AND CVE_ESTADO = " & fCLAVE
                Case "Incidencias"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCCATINCIDENCIAS WHERE STATUS = 'A' AND CVE_INC = " & fCLAVE
                Case "Poliza"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(TIPO_COBERTURA,'') AS DES FROM GCPOLIZAS WHERE STATUS = 'A' AND IDPOLIZA = " & fCLAVE
                Case "Gasolinera"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCGASOLINERAS WHERE CVE_GAS = '" & fCLAVE & "'"
                Case "IAVE"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCTARJETA_IAVE WHERE CLAVE = " & fCLAVE
                Case "AnticiposViaje"
                Case "Status"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCSTATUS WHERE CVE_ST = '" & fCLAVE & "'"
                Case "Rutas"
                    SQL = "SELECT ISNULL(ORIGEN + ' - ' + DESTINO,'') AS DES FROM GCRUTAS WHERE CVE_RUTA = " & fCLAVE
                Case "Contrato"
                    SQL = "SELECT ISNULL(CVE_CON,'') AS DES FROM GCCONTRATO WHERE CVE_CON = '" & fCLAVE & "'"

                Case "ContratoTab"
                    SQL = "SELECT ISNULL(CVE_CON,'') AS DES FROM GCCONTRATO T
                        WHERE CVE_CON = '" & fCLAVE & "' AND 
                        NOT EXISTS (SELECT CVE_TAB FROM GCTAB_RUTAS_F WHERE CVE_CON = T.CVE_CON AND CVE_CON <> '" & fCLAVE & "') AND T.STATUS = 'A'"

                Case "Carta Porte"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM GCCARTA_PORTE P " &
                        "LEFT JOIN GCCLIE_OP C ON C.CLAVE  = P.CLAVE_O " &
                        "WHERE CVE_FOLIO = '" & fCLAVE & "' AND CVE_FOLIO <> '" & Var10 & "' AND P.STATUS  = 'A'"
                Case "TipoDescuento"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCTIPO_DESC WHERE CVE_TIPO = " & fCLAVE & " AND STATUS  = 'A'"
                Case "FormaDescuento"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCFORMA_DESC WHERE CVE_FOR = " & fCLAVE & " AND STATUS  = 'A'"
                Case "GCConc"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCCONC_GASTOS WHERE CVE_GAS = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "CONM"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, CPN FROM CONM" & Empresa & " WHERE CVE_CPTO = " & fCLAVE & " AND STATUS  = 'A'"
                Case "GCLLANTAS_CONM"
                    SQL = "SELECT ISNULL(C.DESCR,'') AS DES, C.STATUS_LLANTA, S.DESCR AS DESCR_ST_LLA
                        FROM GCLLANTAS_CONM C
                        LEFT JOIN GCLLANTA_STATUS S ON S.CVE_STATUS = C.STATUS_LLANTA
                        WHERE C.CVE_CPTO = " & fCLAVE & " AND C.STATUS  = 'A'"
                Case "Servicios"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCSERVICIOS WHERE CVE_SER = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "GCPRODUCTOS", "Productos"
                    If Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    If Mostra_EstatusA Then
                        SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCPRODUCTOS WHERE CVE_PROD = " & fCLAVE & " AND STATUS = 'A'"
                    Else
                        SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCPRODUCTOS WHERE CVE_PROD = " & fCLAVE
                    End If
                Case "Mecanicos"
                    If Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCMECANICOS WHERE CVE_MEC = " & fCLAVE
                    SQL = SQL
                Case "Puesto"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCPUESTOS WHERE CVE_PUESTO = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Unidades"
                    SQL = "SELECT CLAVEMONTE, ISNULL(CLAVEMONTE,'') AS DES FROM GCUNIDADES WHERE CLAVE = '" & fCLAVE & "' AND ISNULL(STATUS, 'A') = 'A'"
                Case "Unidades2"
                    SQL = "SELECT CLAVEMONTE, ISNULL(CLAVEMONTE,'') AS DES FROM GCUNIDADES WHERE CLAVE = '" & fCLAVE & "' AND ISNULL(STATUS, 'A') = 'A' AND 
                        DESCR LIKE '%" & Var3 & "%'"
                Case "Unidad"
                    SQL = "SELECT U.CLAVE, ISNULL(U.CLAVEMONTE,'') AS DES2, CASE WHEN ISNULL(U.DESCR,'') = '' THEN ISNULL(U.CLAVEMONTE,'') ELSE ISNULL(U.DESCR,'') END AS DES, 
                        T.DESCR AS DESCR_TIPO_UNI, ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI, ISNULL(CVE_TAQ,0) AS TAQ
                        FROM GCUNIDADES U 
                        LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                        LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI
                        WHERE CLAVEMONTE = '" & fCLAVE & "' AND ISNULL(U.STATUS, 'A') = 'A' ORDER BY U.CLAVEMONTE"
                Case "Unidades3"
                    SQL = "SELECT U.CLAVE, U.CLAVEMONTE, ISNULL(U.CVE_MOT,'') AS CVEMOT, 
                        CASE WHEN ISNULL(U.DESCR,'') = '' THEN ISNULL(U.CLAVEMONTE,'') ELSE ISNULL(U.DESCR,'') END AS DES,
                        ISNULL(M.DESCR,'') + ' ' + (CASE WHEN U.CVE_TIPO_UNI = 1 THEN 'FULL' ELSE 'SENCILLO' END) AS DESCR_MOTOR
                        FROM GCUNIDADES U
                        LEFT JOIN GCMOTORES M ON M.CVE_MOT = U.CVE_MOT
                        WHERE (CLAVE = '" & fCLAVE & "' OR CLAVEMONTE = '" & fCLAVE & "') AND 
                        ISNULL(U.STATUS, 'A') = 'A' AND U.CVE_TIPO_UNI = " & Val(Var4)
                    Debug.Print(SQL)
                Case "Unidad2"
                    SQL = "SELECT CLAVE, ISNULL(DESCR,'') AS DES FROM GCUNIDADES WHERE CLAVEMONTE = '" & fCLAVE & "' AND 
                        ISNULL(STATUS, 'A') = 'A' AND DESCR LIKE '%" & Var3 & "%'"

                Case "LlantasCveLlanta"
                    SQL = "SELECT ISNULL(LL.CVE_LLANTA,0) AS DES " &
                        "FROM GCLLANTAS LL " &
                        "WHERE LL.NUM_ECONOMICO = '" & fCLAVE & "' AND LL.STATUS  = 'A'"

                Case "Llantas" 'LLANTAS
                    If IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(LL.NUM_ECONOMICO,'') AS DES, CVE_LLANTA, SL.DESCR AS ST_LLANTA
                        FROM GCLLANTAS LL
                        LEFT JOIN GCLLANTA_STATUS SL ON SL.CVE_STATUS = LL.STATUS_LLANTA 
                        WHERE LL.CVE_LLANTA = " & fCLAVE & " AND LL.STATUS  = 'A'"
                Case "LlantasNE" 'LLANTAS
                    SQL = "SELECT ISNULL(LL.NUM_ECONOMICO,'') AS DES, CVE_LLANTA, SL.DESCR AS ST_LLANTA
                        FROM GCLLANTAS LL
                        LEFT JOIN GCLLANTA_STATUS SL ON SL.CVE_STATUS = LL.STATUS_LLANTA 
                        WHERE LL.NUM_ECONOMICO = '" & fCLAVE & "' AND LL.STATUS  = 'A'"

                Case "Marcas" 'MARCA LLANTAS
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCMARCAS WHERE CVE_MARCA = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Tipo unidad"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCTIPO_UNIDAD WHERE CVE_UNI = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Tipo unidad2"
                    SQL = "SELECT T.DESCR AS DES FROM GCUNIDADES U " &
                        "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                        "WHERE CLAVEMONTE = '" & fCLAVE & "' AND ISNULL(U.STATUS, 'A') = 'A'"
                Case "Sucursal"
                    If Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCSUCURSAL WHERE CVE_SUC = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Marca unidad"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCMARCAUNIDAD WHERE CVE_MARCA = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Modelo"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCMODELO_UNIDAD WHERE CVE_MOD = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Modelo llanta"
                    If Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCLLANTA_MODELO WHERE CVE_MODELO = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Modelo Renovado"
                    If Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCLLANTA_MODELO WHERE STATUS = 'A' AND CVE_MODELO = " & fCLAVE
                Case "Medidas Llanta"
                    If Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCLLANTA_MEDIDA WHERE CVE_MED = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Marca" 'MARCA LLANTAS
                    If Not IsNumeric(fCLAVE) Then
                        fCLAVE = "0"
                    End If
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, TIPO FROM GCMARCAS WHERE STATUS = 'A' AND CVE_MARCA = " & fCLAVE
                Case "Propiedtarios"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM GCPROPIETARIOS WHERE CVE_PROP = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Tipo Llanta"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCLLANTA_TIPO WHERE CVE_TIPO = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Llanta modelo"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCLLANTA_MODELO WHERE CVE_MODELO = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Llanta medida"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCLLANTA_MEDIDA WHERE CVE_MED = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Llanta status"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCLLANTA_STATUS WHERE CVE_STATUS = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Operador"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES, LICENCIA, LIC_VENC FROM GCOPERADOR WHERE CLAVE = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Grupo unidad"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCGRUPO_UNI WHERE CVE_GPO = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Placas defa"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCPLACAS_DEFA WHERE CVE_PLA = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Clasificacion"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCCLASIFIC_SERVICIOS WHERE CVE_CLA = '" & fCLAVE & "' AND STATUS  = 'A'"

                Case "Tipo de cobro"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCTIPO_COBRO WHERE CVE_COBRO = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Num viaje"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCNUM_VIAJE WHERE CVE_VIAJE = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Viajes"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCVIAJES WHERE CLAVE = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Autoriza"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM GCAUTORIZA WHERE CVE_AUT = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Anticipos_Cat"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCANTICIPOS_CAT WHERE CVE_ANT = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Tipo poliza"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCTIPO_POLIZA WHERE TIPO_POL = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Equipo Asegurado"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCEQUIPO_ASEGURADO WHERE CVE_ASE = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Aseguradoras"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM GCASEGURADORAS WHERE LTRIM(RTRIM(CLAVE)) = " & fCLAVE.Trim & " AND STATUS  = 'A'"
                Case "Nivel de combustible"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT CLAVE, ID_TABLA, LITROS, ALTURA AS DES FROM GCNIVELCOMBUSTIBLE WHERE CLAVE = " & fCLAVE & " AND STATUS  = 'A'"
                Case "Fallas"
                    SQL = "SELECT ISNULL(DESCR_FALLA,'') AS DES FROM GCREPORTE_FALLAS WHERE CVE_FALLA = '" & fCLAVE & "' AND STATUS  = 'A'"
                Case "Origen"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCORIGEN WHERE CLAVE = " & fCLAVE & " AND STATUS = 'A'"
                Case "Destino"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT ISNULL(DESCR,'') AS DES FROM GCDESTINO WHERE CLAVE = " & fCLAVE & " AND STATUS = 'A'"
                Case "Plazas"
                    SQL = "SELECT ISNULL(CIUDAD,'') AS DES FROM GCPLAZAS WHERE CLAVE = " & fCLAVE & IIf(Mostra_EstatusA, " AND STATUS = 'A'", "")
                Case "Detalle Rutas"
                    If Not IsNumeric(fCLAVE) Then fCLAVE = "0"
                    If fCLAVE = "" Then fCLAVE = "0"
                    SQL = "SELECT D.CVE_RUTA, P1.CIUDAD AS DES, P2.CIUDAD AS DESTINO, ISNULL(D.KM_RECORRIDOS,0) AS KM, " &
                        "ISNULL(D.COSTO_CASETAS,0) AS COSTO_CAS, ISNULL(D.EJES,0) AS EJE " &
                        "FROM GCDETALLE_RUTAS D " &
                        "LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = D.CVE_PLA1 " &
                        "LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = D.CVE_PLA2 " &
                        "WHERE D.STATUS = 'A' AND CVE_RUTA = " & fCLAVE
                Case "Cliente operativo"
                    If Mostra_EstatusA Then
                        SQL = "SELECT ISNULL(C.NOMBRE,'') AS DES, ISNULL(P1.CIUDAD,'') AS PLAZA, ISNULL(C.DOMICILIO,'') AS DOMI, ISNULL(C.CVE_PLAZA,0) AS C_PLAZA
                            FROM GCCLIE_OP C 
                            LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C.CVE_PLAZA
                            WHERE C.STATUS = 'A'  AND C.CLAVE = '" & fCLAVE & "'"
                    Else
                        SQL = "SELECT ISNULL(C.NOMBRE,'') AS DES, ISNULL(P1.CIUDAD,'') AS PLAZA, ISNULL(C.DOMICILIO,'') AS DOMI, ISNULL(C.CVE_PLAZA,0) AS C_PLAZA
                            FROM GCCLIE_OP C
                            LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C.CVE_PLAZA
                            WHERE C.CLAVE = '" & fCLAVE & "'"
                    End If

                    SQL = "SELECT C.CLAVE, C.NOMBRE AS DES, C.DOMICILIO, ISNULL(C.MUNICIPIO,0) AS C_NOTA
                          FROM GCCLIE_OP C
                          WHERE C.CLAVE = '" & fCLAVE & "'
                          ORDER BY C.CLAVE"

            End Select
            CADENA = ""
            If SQL.Trim.Length > 0 Then
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    CADENA = dr("DES").ToString
                    If fTABLA = "Tanques" Then
                        Var4 = dr("CVE_TAQ") 'CLAVE
                        Var5 = dr("T1_ANCHO") 'ANCHO
                        Var6 = dr("T1_ALTO") 'ALTO
                        Var7 = dr("T1_PROFUNDIDAD") 'PROFUNDIDAD
                        Var8 = dr("DES") 'LITROS
                        Var9 = dr("T2_ANCHO") 'ANCHO
                        Var10 = dr("T2_ALTO") 'ALTO
                        Var11 = dr("T2_PROFUNDIDAD") 'PROFUNDIDAD
                        Var12 = dr("T2_LITROS") 'LITROS
                    End If
                    If fTABLA = "Moneda" Then
                        Var6 = dr("CVE_MONED")
                    End If
                    If fTABLA = "CuentaOrdenante" Or fTABLA = "CuentaBeneficiario" Then
                        Var6 = dr("NOMBRE_BANCO")
                    End If
                    If fTABLA = "GCLLANTAS_CONM" Then
                        'C.STATUS_LLANTA, S.DESCR AS DESCR_ST_LLA
                        Var6 = dr("DESCR_ST_LLA")
                        Var7 = dr("STATUS_LLANTA")
                    End If
                    If fTABLA = "CONM" Then
                        Var6 = dr.ReadNullAsEmptyString("CPN")
                    End If

                    '"PagoComplemento"
                    If fTABLA = "PagoComplemento" Then
                        Var21 = dr.ReadNullAsEmptyDecimal("IMPORTE")
                    End If
                    '"ClieDocSaldos"
                    If fTABLA = "ClieDocSaldos" Then
                        Var21 = dr.ReadNullAsEmptyDecimal("IMPORTE") - dr.ReadNullAsEmptyDecimal("SUMA_CUENDET")
                        Var22 = dr.ReadNullAsEmptyInteger("NUM_CPTO")
                        Var4 = dr("DES") '"Fg(Fg.Row, 1).ToString  'REFER
                        Var5 = dr("CVE_CLIE") 'Fg(Fg.Row, 2).ToString  'CLIENTE
                        Var7 = dr("SUMA_CUENDET") 'Fg(Fg.Row, 7) 'ABONOS
                        Var8 = dr("IMPORTE") 'Fg(Fg.Row, 8) 'IMPORTE
                        Var9 = dr("SALDO") 'Fg(Fg.Row, 9)  'SALDO
                        Var6 = dr("NUM_CARGO") 'Fg(Fg.Row, 11).ToString  'NUM_CARGO
                    End If
                    If fTABLA = "ProvDocSaldos2" Then
                        Var21 = dr.ReadNullAsEmptyDecimal("IMPORTE") - dr.ReadNullAsEmptyDecimal("SUMA_CUENDET")
                        Var22 = dr.ReadNullAsEmptyInteger("NUM_CPTO")
                        Var4 = dr("DES") '"Fg(Fg.Row, 1).ToString  'REFER
                        Var5 = dr("CVE_PROV") 'Fg(Fg.Row, 2).ToString  'CLIENTE
                        Var7 = dr("SUMA_CUENDET") 'Fg(Fg.Row, 7) 'ABONOS
                        Var8 = dr("IMPORTE") 'Fg(Fg.Row, 8) 'IMPORTE
                        Var9 = dr("SALDO") 'Fg(Fg.Row, 9)  'SALDO
                        Var6 = dr("NUM_CARGO") 'Fg(Fg.Row, 11).ToString  'NUM_CARGO
                        Var11 = dr("NO_FACTURA")
                    End If
                    'Var7 = Fg(Fg.Row, 7).ToString 'ABONOS
                    'Var8 = Fg(Fg.Row, 8).ToString 'IMPORTE
                    'Var9 = Fg(Fg.Row, 9).ToString SALDO
                    'ProvDocSaldos
                    If fTABLA = "ProvDocSaldos" Then
                        Var6 = dr("NUM_CARGO") 'Fg(Fg.Row, 11).ToString  'NUM_CARGO
                        Var7 = dr.ReadNullAsEmptyDecimal("SUMA_CUENDET") + dr.ReadNullAsEmptyDecimal("CARGOS")
                        Var8 = dr.ReadNullAsEmptyDecimal("IMPORTE")
                        Var9 = dr.ReadNullAsEmptyDecimal("IMPORTE") + dr.ReadNullAsEmptyDecimal("SUMA_CUENDET") + dr.ReadNullAsEmptyDecimal("CARGOS")
                        Var11 = dr.ReadNullAsEmptyString("NO_FACTURA")
                        Var12 = dr("NUM_CPTO")
                    End If
                    If fTABLA = "Llantas" Or fTABLA = "LlantasNE" Then
                        Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                        Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    End If
                    If fTABLA = "Unidad" Then
                        'Select Case u.CLAVE, ISNULL(U.CLAVEMONTE,'') AS DES2, 
                        'CASE WHEN ISNULL(U.DESCR,'') = '' THEN ISNULL(U.CLAVEMONTE,'') ELSE ISNULL(U.DESCR,'') END AS DES, 
                        't.DESCR AS DESCR_TIPO_UNI, ISNULL(u.CVE_TIPO_UNI, 0) As TIPO_UNI, ISNULL(CVE_TAQ, 0) AS TAQ
                        'Var4 = dr.ReadNullAsEmptyString("CLAVE").ToString
                        'Var5 = dr.ReadNullAsEmptyInteger("TIPO_UNI")
                        'Var6 = dr.ReadNullAsEmptyString("DES").ToString
                        'Var7 = dr.ReadNullAsEmptyString("TAQ").ToString
                        'var8 = descr tipo unidad
                        Var4 = dr.ReadNullAsEmptyString("CLAVE").ToString
                        Var5 = dr.ReadNullAsEmptyString("TIPO_UNI").ToString
                        Var6 = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI").ToString
                        Var7 = dr.ReadNullAsEmptyString("TAQ").ToString
                        Var8 = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI").ToString
                    End If
                    If fTABLA = "Unidades3" Then
                        'Select Case u.CLAVE, U.CLAVEMONTE, ISNULL(U.CVE_MOT,'') AS CVEMOT, 
                        'Case WHEN ISNULL(U.DESCR,'') = '' THEN ISNULL(U.CLAVEMONTE,'') ELSE ISNULL(U.DESCR,'') END AS DES,
                        'ISNULL(m.DESCR,'') + ' ' + (CASE WHEN U.CVE_TIPO_UNI = 1 THEN '' ELSE '' END) AS DESCR_MOTOR

                        Var4 = dr.ReadNullAsEmptyString("CLAVEMONTE").ToString
                        Var5 = dr.ReadNullAsEmptyString("CVEMOT").ToString
                        Var6 = dr.ReadNullAsEmptyString("DESCR_MOTOR").ToString
                    End If
                    If fTABLA = "Unidades" Or fTABLA = "Unidades2" Then
                        Var4 = dr.ReadNullAsEmptyString("CLAVEMONTE").ToString
                    End If
                    If fTABLA = "Nivel de combustible" Then
                        Var4 = dr.ReadNullAsEmptyInteger("CLAVE").ToString
                        Var5 = dr.ReadNullAsEmptyInteger("ID_TABLA").ToString
                        Var6 = dr.ReadNullAsEmptyDecimal("LITROS").ToString
                    End If
                    If fTABLA = "Detalle Rutas" Then
                        Var4 = dr.ReadNullAsEmptyString("DES").ToString
                        Var5 = dr.ReadNullAsEmptyString("DESTINO").ToString
                        Var6 = dr.ReadNullAsEmptyDecimal("COSTO_CAS").ToString
                        Var7 = dr.ReadNullAsEmptyDecimal("KM").ToString
                    End If
                    If fTABLA = "Operador" Then
                        Var6 = dr.ReadNullAsEmptyString("LICENCIA").ToString
                        Var7 = dr("LIC_VENC").ToString
                    End If
                    If fTABLA = "InvenR" Then
                        Var6 = dr.ReadNullAsEmptyString("NUM_PARTE")
                        Var8 = dr.ReadNullAsEmptyString("T_ELE")
                    End If
                    If fTABLA = "InveP" Or fTABLA = "InveS" Or fTABLA = "InveS2" Then
                        Var6 = dr.ReadNullAsEmptyString("NUM_PARTE")
                        Var7 = dr.ReadNullAsEmptyDecimal("P1")
                        Var8 = dr.ReadNullAsEmptyString("T_ELE")
                        Var9 = dr.ReadNullAsEmptyDecimal("C_PROM")
                    End If
                    If fTABLA = "InvesSAE" Then
                        Var6 = dr.ReadNullAsEmptyString("NUM_PARTE")
                        Var7 = dr.ReadNullAsEmptyDecimal("P1")
                    End If

                    If fTABLA = "ClieOT" Then
                        Var6 = dr("LIB5")
                        Var7 = dr("LIB6")
                    End If
                    If fTABLA = "FACT" Or fTABLA = "COMP" Then
                        '"Select F.CVE_DOC As DES, CLAVE, NOMBRE, FECHA_DOC, IMPORTE, ISNULL(DOC_SIG,'') AS DOCSIG, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG " &
                        Var4 = dr.ReadNullAsEmptyString("DES")
                        Var5 = dr.ReadNullAsEmptyString("CLAVE")
                        Var6 = dr.ReadNullAsEmptyString("NOMBRE")
                        Var7 = dr("FECHA_DOC")
                        Var8 = dr.ReadNullAsEmptyDecimal("IMPORTE")
                        Var9 = dr.ReadNullAsEmptyString("DOCSIG")
                        Var10 = dr.ReadNullAsEmptyString("TIPDOCSIG")
                    End If
                    If fTABLA = "Valor Declarado" Then
                        Var4 = Format(dr.ReadNullAsEmptyDecimal("IMPORTE"), "###,###,##0.00")
                    End If
                    If fTABLA = "Cliente operativo" Then
                        'SELECT C.CLAVE, C.NOMBRE, C.DOMICILIO, ISNULL(C.NOTA,0) AS C_NOTA
                        'From GCCLIE_OP C
                        'WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                        Var4 = dr("CLAVE") 'CLAVE 
                        Var5 = dr("DES") 'nombre cliente operativo
                        Var6 = dr("C_NOTA") 'plaza ciudad
                        Var7 = dr("DOMICILIO") 'domicilio cliente op
                    End If
                    If fTABLA = "ConcSAT" Then
                        Var6 = dr("NUM_CPTO")
                    End If
                    If fTABLA = "ProvLib" Then
                        Var6 = dr("LIB6")
                    End If
                Else
                    Debug.Print("")
                End If
                dr.Close()
            Else
                CADENA = "N"
            End If
            Return CADENA
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine & fTABLA & vbNewLine & SQL)
            Return "N"
        End Try
    End Function
    Public Function GET_PAGOSAT(fNUM_PAGO As String) As Boolean
        Try
            Dim Exist As Boolean
            Dim ds As New DataSet
            Dim i As Integer
            Dim a As String, b As String

            If fNUM_PAGO.Trim.Length = 0 Then
                Return True
            End If

            ds.InferXmlSchema(Application.StartupPath & "\CatalogosSat\CAT_FORMA_PAGO.xml", Nothing)
            ds.ReadXml(Application.StartupPath & "\CatalogosSat\CAT_FORMA_PAGO.xml")
            Exist = False            'Descripcion="Efectivo" c_FormaPago="01"
            If ds.Tables.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    a = ds.Tables(0).Rows(i).Item("c_FormaPago")
                    b = ds.Tables(0).Rows(i).Item("Descripcion")
                    If fNUM_PAGO = a Then
                        Exist = True
                        Exit For
                    End If
                Next
            End If
            Return Exist
        Catch Ex As Exception
            Bitacora("330. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("330. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Return False
        End Try

    End Function
    Public Function VERIFICA_TARJ_IAVE_NO_ASIGNADA(fCLAVE As String, fIAVE As String) As Boolean
        Dim ExistLlanta As Boolean

        ExistLlanta = False
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If fCLAVE.Trim.Length = 0 Then
                Return False
            End If
            SQL = "SELECT CLAVE, DESCR FROM GCUNIDADES WHERE CLAVE <> '" & fCLAVE & "' AND ISNULL(STATUS, 'A') = 'A' AND OD_TARJ_IAVE = '" & fIAVE & "'"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                ExistLlanta = True
                Var11 = dr("CLAVE") & " " & dr("DESCR")
            End If
            dr.Close()
            Return ExistLlanta
        Catch ex As Exception
            Bitacora("335. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("335. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    'EXISTE_PAGO_COMP
    Public Function EXISTE_PAGO_COMP(fTipoCompra As String, fCVE_DOC As String) As Boolean
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_DOC FROM CFDI_COMPAGO WHERE CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXISTE_PAGO_COMP = True
            Else
                EXISTE_PAGO_COMP = False
            End If
            dr.Close()

            Return EXISTE_PAGO_COMP
        Catch ex As Exception
            Bitacora("346. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("346. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function EXISTE_PRE_OC(fCVE_DOC As String) As Boolean
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim EXISTE As Boolean = False
        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_DOC FROM COMPO_PRE WHERE CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                EXISTE = True
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("346. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("346. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return EXISTE
    End Function
    Public Function EXISTE_COMPRA(fTipoCompra As String, fCVE_DOC As String) As Boolean

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_DOC FROM COMP" & fTipoCompra.ToUpper & Empresa & " WHERE CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXISTE_COMPRA = True
            Else
                EXISTE_COMPRA = False
            End If
            dr.Close()

            Return EXISTE_COMPRA
        Catch ex As Exception
            Bitacora("346. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("346. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function EXISTE_CVE_DOC_GASTO(fTipoCompra As String, fCVE_DOC As String) As Boolean

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_DOC FROM GCGASTOS WHERE CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXISTE_CVE_DOC_GASTO = True
            Else
                EXISTE_CVE_DOC_GASTO = False
            End If
            dr.Close()

            Return EXISTE_CVE_DOC_GASTO
        Catch ex As Exception
            Bitacora("346. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("346. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function EXISTE_PAGA_M(fTipoCompra As String, fCVE_DOC As String) As Boolean

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT REFER FROM PAGA_M" & Empresa & " WHERE REFER = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXISTE_PAGA_M = True
            Else
                EXISTE_PAGA_M = False
            End If
            dr.Close()

            Return EXISTE_PAGA_M

        Catch ex As Exception
            Bitacora("346. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("346. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function EXISTE_CARTA_PORTA_TRASLADO(fCVE_DOC As String) As Boolean
        Dim EXIST_VTA As Boolean = False
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_DOC FROM CFDI_CPT WHERE CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                EXIST_VTA = True
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return EXIST_VTA
    End Function

    Public Function EXISTE_VENTA(fTipoVenta As String, fCVE_DOC As String) As Boolean
        Dim EXIST_VTA As Boolean
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_DOC FROM FACT" & fTipoVenta.ToUpper & Empresa & " WHERE CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXIST_VTA = True
            Else
                EXIST_VTA = False
            End If
            dr.Close()

            Return EXIST_VTA
        Catch ex As Exception
            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function EXISTE_CARTA_PORTE_CFDI(fCVE_DOC As String) As Boolean
        Dim EXIST_VTA As Boolean
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT DOCUMENT FROM CFDI WHERE DOCUMENT = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXIST_VTA = True
            Else
                EXIST_VTA = False
            End If
            dr.Close()

            Return EXIST_VTA
        Catch ex As Exception
            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function EXISTE_CARTA_PORTE_GEN(FCVE_FOLIO As String) As Boolean
        Dim EXIST_VTA As Boolean
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_VIAJE FROM GCCARTA_PORTE WHERE CVE_FOLIO = '" & FCVE_FOLIO & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXIST_VTA = True
            Else
                EXIST_VTA = False
            End If
            dr.Close()

            Return EXIST_VTA
        Catch ex As Exception
            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function EXISTE_LIQUIDACION(FCVE_LIQ As Long) As Boolean
        Dim EXIST_VTA As Boolean = False
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_LIQ FROM GCLIQUIDACIONES WHERE CVE_LIQ = " & FCVE_LIQ
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                EXIST_VTA = True
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("366. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("366. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return EXIST_VTA
    End Function

    Public Function EXISTE_PEDIDO(fCVE_DOC As String) As Boolean
        Dim EXIST_VTA As Boolean
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE
            SQL = "SELECT CVE_DOC FROM GCPEDIDOS WHERE CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                EXIST_VTA = True
            Else
                EXIST_VTA = False
            End If
            dr.Close()

            Return EXIST_VTA
        Catch ex As Exception
            Bitacora("366. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("366. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function CALCULA_COSTO_PROM(fCVE_ART As String, fCOSTO_PROM As Decimal, fCOST As Decimal, fCant As Decimal, fSIGNO As Integer) As Decimal
        Dim ExistActual As Decimal
        Dim PROMEDIO As Decimal
        Dim COSTO_PROM As Decimal
        Dim cmd As New SqlCommand
        Dim Reader As SqlDataReader

        Try
            cmd.CommandText = "SELECT COALESCE(EXIST,0) AS EXISTENCIA, COALESCE(COSTO_PROM,0) AS COSTOPROM FROM INVE" & Empresa & " WHERE CVE_ART = '" & fCVE_ART & "'"
            cmd.Connection = cnSAE
            Reader = cmd.ExecuteReader
            If Reader.Read Then
                ExistActual = Reader("EXISTENCIA")
                COSTO_PROM = Reader("COSTOPROM")
            End If
            Reader.Close()
        Catch ex As Exception
            MsgBox("443. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("443. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
        'costo promedio = (existencia x ultimo costo promedio) +-(cantidad de mov. x costo mov.)
        '/ (existencia +- cantidad del mov)
        If fCVE_ART = "VW308" Then
            PROMEDIO = 0
        End If
        Try
            If fSIGNO > 0 Then
                If ExistActual + fCant <> 0 Then
                    PROMEDIO = ((ExistActual * COSTO_PROM) + (fCant * fCOST)) / (ExistActual + fCant)
                Else
                    PROMEDIO = COSTO_PROM
                End If
            Else
                If ExistActual - fCant <> 0 Then
                    PROMEDIO = ((ExistActual * COSTO_PROM) - (fCant * fCOST)) / (ExistActual - fCant)
                Else
                    PROMEDIO = COSTO_PROM
                End If
            End If

        Catch ex As Exception
            MsgBox("444. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("444. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try

        CALCULA_COSTO_PROM = PROMEDIO

    End Function

    Public Function SIGUIENTE_CVE_DOC_COMPRA(ByVal fTipoCompra As String, ByVal fLETRA As String) As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim CVE_DOC As String

        Try
            SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA " &
                "FROM FOLIOSC" & Empresa & " WHERE TIP_DOC = '" & fTipoCompra & "' AND " &
                "SERIE = '" & IIf(fLETRA = "", "STAND.", fLETRA) & "'"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                FOLIO_COMPRA = dr("ULTDOC") + 1
                If fLETRA = "STAND." Or fLETRA.Trim.Length = 0 Then
                    LETRA_COMPRA = ""
                    CVE_DOC = Format(FOLIO_COMPRA, "0000000000")
                    CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                Else
                    If Len(Trim(fLETRA)) > 0 Then
                        CVE_DOC = fLETRA & FOLIO_COMPRA
                    Else
                        CVE_DOC = Format(FOLIO_COMPRA, "0000000000")
                        CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                    End If
                End If
            Else
                LETRA_COMPRA = ""
                FOLIO_COMPRA = 1
                CVE_DOC = Format(FOLIO_COMPRA, "0000000000")
                CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
            End If
            dr.Close()
            Return CVE_DOC
        Catch ex As Exception
            MsgBox("454. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("454. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function

    Public Function SIGUIENTE_FOLIO_COMPRA(ByVal fTipoCompra As String, ByVal fLETRA As String) As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim FOIO_GEN As String = "1"
        Var4 = ""
        Try
            SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA " &
                "FROM FOLIOSC" & Empresa & " WHERE LOWER(TIP_DOC) = '" & fTipoCompra.ToLower & "' AND " &
                "SERIE = '" & IIf(fLETRA = "", "STAND.", fLETRA) & "'"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                FOIO_GEN = dr("ULTDOC") + 1
            Else
                FOIO_GEN = 1
                Var4 = "NO EXISTE"
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox("464. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("464. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
        Return FOIO_GEN
    End Function

    Public Function SIGUIENTE_CVE_DOC_VENTA(ByVal fTipoVENTA As String, ByVal fLETRA As String) As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim CVE_DOC As String
        Dim FOLIO_VENTA As Long
        Dim LETRA_VENTA As String

        Try
            SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA " &
                "FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & fTipoVENTA & "' AND " &
                "SERIE = '" & IIf(fLETRA = "", "STAND.", fLETRA) & "'"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                FOLIO_VENTA = dr("ULTDOC") + 1
                If fLETRA = "STAND." Or fLETRA.Trim.Length = 0 Then
                    LETRA_VENTA = ""
                    CVE_DOC = Format(FOLIO_VENTA, "0000000000")
                    CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                Else
                    If Len(Trim(fLETRA)) > 0 Then
                        CVE_DOC = fLETRA & FOLIO_VENTA
                    Else
                        CVE_DOC = Format(FOLIO_VENTA, "0000000000")
                        CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                    End If
                End If
            Else
                LETRA_VENTA = ""
                FOLIO_VENTA = 1
                CVE_DOC = Format(FOLIO_VENTA, "0000000000")
                CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
            End If
            dr.Close()
            FOLIO_G = FOLIO_VENTA

            Return CVE_DOC
        Catch ex As Exception
            MsgBox("474. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("474. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function

    Public Function SIGUIENTE_CVE_DOC_FACTURA(ByVal fTipoVENTA As String, ByVal fLETRA As String) As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim CVE_DOC As String
        Dim FOLIO_VENTA As Long
        Dim LETRA_VENTA As String

        Try
            SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA " &
                "FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & fTipoVENTA & "' AND " &
                "SERIE = '" & IIf(fLETRA = "", "STAND.", fLETRA) & "'"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                FOLIO_VENTA = dr("ULTDOC") + 1
                If fLETRA = "STAND." Or fLETRA.Trim.Length = 0 Then
                    LETRA_VENTA = ""
                    CVE_DOC = Format(FOLIO_VENTA, "0000000000")
                    CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                Else
                    If Len(Trim(fLETRA)) > 0 Then
                        CVE_DOC = fLETRA & Format(FOLIO_VENTA, "0000000000")
                    Else
                        CVE_DOC = Format(FOLIO_VENTA, "0000000000")
                        CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                    End If
                End If
            Else
                LETRA_VENTA = ""
                FOLIO_VENTA = 1
                CVE_DOC = Format(FOLIO_VENTA, "0000000000")
                CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
            End If
            dr.Close()
            FOLIO_G = FOLIO_VENTA

            Return CVE_DOC
        Catch ex As Exception
            MsgBox("474. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("474. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function


    Public Function SIGUIENTE_CVE_DOC_VENTA_CEROS(ByVal FTipoVENTA As String, ByVal FLETRA As String) As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim CVE_DOC As String
        Dim FOLIO_VENTA As Long
        Dim LETRA_VENTA As String

        Try
            SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA " &
                "FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & FTipoVENTA & "' AND " &
                "SERIE = '" & IIf(FLETRA = "", "STAND.", FLETRA) & "'"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                FOLIO_VENTA = dr("ULTDOC") + 1
                If FLETRA = "STAND." Or FLETRA.Trim.Length = 0 Then
                    LETRA_VENTA = ""
                    CVE_DOC = Format(FOLIO_VENTA, "0000000000")
                    CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                Else
                    If Len(Trim(FLETRA)) > 0 Then
                        CVE_DOC = FLETRA & Format(FOLIO_VENTA, "0000000000")
                    Else
                        CVE_DOC = Format(FOLIO_VENTA, "0000000000")
                        CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                    End If
                End If
            Else
                LETRA_VENTA = ""
                FOLIO_VENTA = 1
                CVE_DOC = Format(FOLIO_VENTA, "0000000000")
                CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
            End If
            dr.Close()
            FOLIO_G = FOLIO_VENTA

            Return CVE_DOC
        Catch ex As Exception
            MsgBox("474. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("474. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function

    Public Function SIGUIENTE_CVE_DOC_PAGOS(ByVal FTipoVENTA As String, ByVal FLETRA As String) As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim CVE_DOC As String
        Dim FOLIO_VENTA As Long
        Dim LETRA_VENTA As String

        Try
            SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA " &
                "FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & FTipoVENTA & "' AND " &
                "SERIE = '" & IIf(FLETRA = "", "STAND.", FLETRA) & "'"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                FOLIO_VENTA = dr("ULTDOC") + 1
                If FLETRA = "STAND." Or FLETRA.Trim.Length = 0 Then
                    LETRA_VENTA = ""
                    CVE_DOC = Format(FOLIO_VENTA, "0000")
                    CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                Else
                    If Len(Trim(FLETRA)) > 0 Then
                        CVE_DOC = FLETRA & Format(FOLIO_VENTA, "0000")
                    Else
                        CVE_DOC = Format(FOLIO_VENTA, "0000")
                        CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
                    End If
                End If
            Else
                LETRA_VENTA = ""
                FOLIO_VENTA = 1
                CVE_DOC = Format(FOLIO_VENTA, "0000")
                CVE_DOC = Space(20 - CVE_DOC.Trim.Length) & CVE_DOC.Trim
            End If
            dr.Close()
            FOLIO_G = FOLIO_VENTA

            Return CVE_DOC
        Catch ex As Exception
            MsgBox("474. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("474. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function

    Public Function SIGUIENTE_FOLIO_VENTA(ByVal fTipoVENTA As String, ByVal fLETRA As String) As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim FOIO_GEN As String

        Try
            SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA " &
                "FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & fTipoVENTA & "' AND " &
                "SERIE = '" & IIf(fLETRA = "", "STAND.", fLETRA) & "'"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                FOIO_GEN = dr("ULTDOC") + 1
            Else
                FOIO_GEN = 1
            End If
            dr.Close()
            Return FOIO_GEN
        Catch ex As Exception
            MsgBox("484. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("484. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            Return 1
        End Try
    End Function

    Public Sub CREA_TAB2(fFrm As Form, fTab As String)

        If Not ExisteTab2(fTab) Then
            Try
                fFrm.TopLevel = False
                fFrm.TopMost = True
                Dim Newpage As New C1.Win.C1Command.C1DockingTabPage With {.Text = fTab, .Tag = fFrm}

                'newpage.TabBackColor = Color.PaleGreen
                'newpage.BackColor = Color.PaleGreen
                FrmParametros.Tab1.TabPages.Add(Newpage)
                FrmParametros.Tab1.Dock = DockStyle.Fill
                Newpage.Controls.Add(fFrm)

                FrmParametros.Tab1.SelectedTab = Newpage
                fFrm.Show()

            Catch ex As Exception
                Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                For k = 0 To FrmParametros.Tab1.TabPages.Count - 1
                    If FrmParametros.Tab1.TabPages(k).Text = fTab Then
                        FrmParametros.Tab1.SelectedIndex = k
                        Exit For
                    End If
                Next
            Catch ex As Exception
                Bitacora("565. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("565. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

    End Sub


    Public Function ExisteTab2(fTab As String) As Boolean
        Dim ExistTab As Boolean
        Try
            ExistTab = False
            For k = 0 To FrmParametros.Tab1.TabPages.Count - 1
                If FrmParametros.Tab1.TabPages(k).Text = fTab Then
                    ExistTab = True
                    Exit For
                End If
            Next
            Return ExistTab
        Catch ex As Exception
            Bitacora("566. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("566. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try

    End Function
    Sub CloseTab2(fTab As String)
        Try
            For k = 0 To FrmParametros.Tab1.TabPages.Count - 1
                If FrmParametros.Tab1.TabPages(k).Text = fTab Then
                    FrmParametros.Tab1.TabPages.RemoveAt(k)
                    Exit For
                End If
            Next
        Catch ex As Exception
            Bitacora("571. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("571. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Function OBTENER_MRT(FREP As String) As String
        Dim ARCHIVO As String = ""
        Try
            SQL = "SELECT F.NOMBRE, F.ARCHIVO FROM GCFORMATOS F WHERE NOMBRE = '" & FREP & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        ARCHIVO = dr("ARCHIVO").ToString
                    End If
                End Using
            End Using
            Return ARCHIVO
        Catch ex As Exception
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ARCHIVO
        End Try
    End Function
    Public Function GET_RUTA_FORMATOS() As String
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim RUTA As String

            RUTA = Application.StartupPath
            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                RUTA = dr("RUTA_FORMATOS").ToString
            End If
            dr.Close()

            If RUTA.Trim.Length = 0 Then
                RUTA = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            End If

            Return RUTA
        Catch ex As Exception
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            Return Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End Try

    End Function

    Public Function UNIDAD_ASIGNADA(fUNIDAD As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ExistUnidad As Boolean

            SQL = "SELECT CLAVE, CLAVEMONTE, " &
                "(SELECT TOP 1 SU.DESCR FROM GCASIGNACION_VIAJE A4 LEFT JOIN GCCAT_STATUS_UNIDADES SU ON SU.CLAVE = A4.CVE_ST_UNI WHERE " &
                "A4.CVE_TRACTOR = U.CLAVEMONTE Or A4.CVE_TANQUE1 = U.CLAVEMONTE Or A4.CVE_TANQUE2 = U.CLAVEMONTE Or A4.CVE_DOLLY = U.CLAVEMONTE " &
                "ORDER BY FECHAELAB desc) AS STATUS_UNIDAD " &
                "From GCUNIDADES U " &
                "WHERE ISNULL(U.STATUS, 'A') = 'A' AND " &
                "(CVE_TANQUE1 = " & fUNIDAD & " OR CVE_TANQUE2 = " & fUNIDAD & " OR CVE_DOLLY = " & fUNIDAD & ")"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Var3 = ""
            ExistUnidad = False
            If dr.Read Then
                Var3 = "en la Clave " & dr("CLAVE") & " " & dr("CLAVEMONTE")
                ExistUnidad = True
            End If
            dr.Close()
            Return ExistUnidad
        Catch ex As Exception
            Bitacora("700. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("700. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function UNIDAD_ASIGNADA_A_OPERADOR(fCVE_OPER As Long, fUNIDAD As String) As Boolean
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ExistUnidad As Boolean

            SQL = "SELECT CLAVE, NOMBRE
                FROM GCOPERADOR U
                WHERE ISNULL(U.STATUS, 'A') = 'A' AND CLAVE <> " & fCVE_OPER & " AND 
                (CVE_TRACTOR= '" & fUNIDAD & "' OR CVE_TANQUE1 = '" & fUNIDAD & "' OR CVE_TANQUE2 = '" & fUNIDAD & "')"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Var3 = ""
            ExistUnidad = False
            If dr.Read Then
                Var3 = "en el operador " & dr("CLAVE") & " " & dr("NOMBRE")
                ExistUnidad = True
            End If
            dr.Close()
            Return ExistUnidad
        Catch ex As Exception
            Bitacora("700. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("700. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Sub UPDATE_DATOS_PROV(fIMPORTE As Decimal, fNO_FACTURA As String, fCVE_PROV As String, fSIGNO As String)
        Try
            If fSIGNO = " - " Then
                SQL = "UPDATE PROV" & Empresa & " SET SALDO = SALDO " & fSIGNO & fIMPORTE & ", " &
                     "ULT_PAGOD = '" & fNO_FACTURA & "', ULT_PAGOM = '" & fIMPORTE & "', ULT_PAGOF = CONVERT(VarChar, GETDATE(), 112) " &
                     "WHERE CLAVE = '" & fCVE_PROV & "'"
            Else
                SQL = "UPDATE PROV" & Empresa & " SET SALDO = SALDO " & fSIGNO & fIMPORTE & ", " &
                     "ULT_COMPD = '" & fNO_FACTURA & "', ULT_COMPM = '" & fIMPORTE & "', ULT_COMPF = CONVERT(VarChar, GETDATE(), 112) " &
                     "WHERE CLAVE = '" & fCVE_PROV & "'"
            End If

            Dim cmd As New SqlCommand With {
                .Connection = cnSAE,
                .CommandText = SQL
            }
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            Bitacora("710. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("710. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub UPDATE_DATOS_CLIE(fIMPORTE As Decimal, fNO_FACTURA As String, fCVE_CLPV As String, fSIGNO As String)
        Try
            If fSIGNO = " - " Then
                SQL = "UPDATE CLIE" & Empresa & " SET SALDO = SALDO " & fSIGNO & fIMPORTE & ", " &
                     "ULT_PAGOD = '" & fNO_FACTURA & "', ULT_PAGOM = '" & fIMPORTE & "', ULT_PAGOF = CONVERT(VarChar, GETDATE(), 112) " &
                     "WHERE CLAVE = '" & fCVE_CLPV & "'"
            Else
                SQL = "UPDATE CLIE" & Empresa & " SET SALDO = SALDO " & fSIGNO & fIMPORTE & ", " &
                     "ULT_PAGOD = '" & fNO_FACTURA & "', ULT_PAGOM = '" & fIMPORTE & "', ULT_PAGOF = CONVERT(VarChar, GETDATE(), 112) " &
                     "WHERE CLAVE = '" & fCVE_CLPV & "'"
            End If

            Dim cmd As New SqlCommand With {.Connection = cnSAE, .CommandText = SQL}
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            Bitacora("720. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("720. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Function SIGUIENTE_FOLIO_VIAJE(ByVal fSERIE_VIAJE As String, ByVal fFOLIO_VIAJE As Long) As String
        Dim CVE_VIAJE As String
        CVE_VIAJE = fSERIE_VIAJE & fFOLIO_VIAJE
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                Dim Sigue As Boolean = True

                Do While Sigue

                    CVE_VIAJE = IIf(fSERIE_VIAJE = "STAND." Or fSERIE_VIAJE = "", "", fSERIE_VIAJE.Trim) & fFOLIO_VIAJE

                    SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE WHERE CVE_VIAJE = '" & CVE_VIAJE & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            fFOLIO_VIAJE += 1
                        Else
                            Sigue = False
                        End If
                    End Using
                Loop
                Return CVE_VIAJE
            End Using
        Catch ex As Exception
            Return CVE_VIAJE
            Bitacora("730. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("730. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Function

    Public Function VALIDAR_ASIGNACION_VIAJE(fCVE_CON As String, fCVE_TRACTOR As String, fCVE_TANQUE1 As String, fCVE_TANQUE2 As String, fCVE_DOLLY As String) As String
        Dim CVE_VIAJE As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand

                SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE WHERE (CVE_CON = '" & fCVE_CON & "' OR 
                    CVE_TRACTOR = '" & fCVE_CON & "' OR CVE_TANQUE1 = '" & fCVE_TANQUE1 & "' OR 
                    CVE_TANQUE2  = '" & fCVE_TANQUE2 & "' OR CVE_DOLLY = '" & fCVE_DOLLY & "') AND CVE_ST_UNI <> 5 "
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_VIAJE = dr("CVE_VIAJE")
                    End If
                End Using
            End Using
            Return CVE_VIAJE
        Catch ex As Exception
            Return CVE_VIAJE
            Bitacora("740. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("740. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Function
    Public Function OPERADOR_ASIGNADO_VIAJE(fCVE_OPER As Integer) As String
        Dim CVE_VIAJE As String
        CVE_VIAJE = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand

                SQL = "SELECT CLAVEMONTE FROM GCUNIDADES WHERE CVE_OPER = " & fCVE_OPER & " AND CVE_ST_UNI <> 5 AND CVE_ST_UNI <> 6"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_VIAJE = dr("CLAVEMONTE")
                    End If
                End Using
            End Using
            Return CVE_VIAJE
        Catch ex As Exception
            Bitacora("750. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("750. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_VIAJE
        End Try
    End Function
    Public Function PEDIDO_ASIGNADO(fCVE_DOC As String) As String
        Dim CVE_VIAJE As String
        CVE_VIAJE = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE WHERE CVE_DOC = '" & fCVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_VIAJE = dr("CVE_VIAJE")
                    End If
                End Using
            End Using

            Return CVE_VIAJE
        Catch ex As Exception
            Return CVE_VIAJE
            Bitacora("760. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Function
    Public Function UNIDAD_ASIGNADA_VIAJE(fUNIDAD As String) As String
        Dim ExistUnidad As String = ""
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE WHERE " &
                "(CVE_TRACTOR = '" & fUNIDAD & "' OR CVE_TANQUE1 = '" & fUNIDAD & "' OR CVE_TANQUE2 = '" & fUNIDAD & "' OR " &
                "CVE_DOLLY = '" & fUNIDAD & "') AND CVE_ST_VIA <> 3 AND CVE_ST_VIA <> 5"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                ExistUnidad = dr("CVE_VIAJE")
            End If
            dr.Close()
            Return ExistUnidad
        Catch ex As Exception
            Bitacora("770. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("770. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ExistUnidad
        End Try
    End Function

    Public Function OBTENER_CARPETA_REPORTES() As String
        Dim RUTA_DOC As String

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                RUTA_DOC = dr("RUTA_FORMATOS").ToString
            Else
                RUTA_DOC = Application.StartupPath & "\REPORTES"
            End If
            dr.Close()
            Return RUTA_DOC
        Catch ex As Exception
            Bitacora("781. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("781. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function
    Public Sub OBTENER_PARAM_CONEXION(ByRef fEmpresa As String, ByRef fServidor As String, ByRef fUsuario As String, ByRef fPass As String, ByRef fBase As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAROCE
            cmd.CommandText = "SELECT * FROM EMPRESAS WHERE EMPRESA = '" & fEmpresa & "'"
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                fServidor = dr("Servidor")
                fUsuario = dr("usuario")
                fPass = dr("pass")
                fBase = dr("base")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("782. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Function OPEN_TAB(FTAB As String) As Boolean
        Dim SiOpen As Boolean = False
        Try
            Debug.Print(MainRibbonForm.Tab1.TabCount)

            For k = 0 To MainRibbonForm.Tab1.TabCount - 1

                If MainRibbonForm.Tab1.TabPages.Item(k).Text = FTAB Then
                    SiOpen = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            Bitacora("800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return SiOpen
    End Function

    Public Function FORM_IS_OPEN(fForm As String) As Boolean
        Dim SiOpen As Boolean
        SiOpen = False
        Try
            Dim frmCollection = Application.OpenForms
            For i As Integer = 0 To frmCollection.Count - 1

                Debug.Print(frmCollection.Item(i).Name)

                If frmCollection.Item(i).Name.ToUpper = fForm.ToUpper Then
                    frmCollection.Item(i).Activate()
                    SiOpen = True
                    Exit For
                End If
            Next i
            Return SiOpen
        Catch ex As Exception
            Bitacora("800. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function Form_Open(fFrm As Form)
        Dim SiOpen As Boolean
        SiOpen = False
        Try
            For Each form In My.Application.OpenForms
                Debug.Print(form.name)
                If (form.name = fFrm.Name) Then
                    SiOpen = True
                    Exit For
                End If
            Next
            Return SiOpen
        Catch ex As Exception
            Bitacora("801. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Sub AutosizeImage(ByVal ImagePath As String, ByVal picBox As PictureBox, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Try
            picBox.Image = Nothing
            picBox.SizeMode = pSizeMode
            If System.IO.File.Exists(ImagePath) Then
                Dim imgOrg As Bitmap
                Dim imgShow As Bitmap
                Dim g As Graphics
                Dim divideBy, divideByH, divideByW As Double
                imgOrg = DirectCast(Bitmap.FromFile(ImagePath), Bitmap)

                divideByW = imgOrg.Width / picBox.Width
                divideByH = imgOrg.Height / picBox.Height
                If divideByW > 1 Or divideByH > 1 Then
                    If divideByW > divideByH Then
                        divideBy = divideByW
                    Else
                        divideBy = divideByH
                    End If

                    imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                Else
                    imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                End If
                imgOrg.Dispose()

                picBox.Image = imgShow
            Else
                picBox.Image = Nothing
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Function UNIDAD_ESTA_EN_MANTO_EXTERNO_BASE(fCVE_UNI As String) As Boolean
        Dim StExtBase As Boolean = False

        Try
            SQL = "SELECT A.CVE_ST_UNI " &
                "FROM GCUNIDADES U " &
                "LEFT JOIN GCASIGNACION_VIAJE A ON A.CVE_TRACTOR = U.CLAVEMONTE OR A.CVE_TANQUE1 = U.CLAVEMONTE OR A.CVE_TANQUE2 = U.CLAVEMONTE OR A.CVE_DOLLY = U.CLAVEMONTE " &
                "LEFT JOIN GCCAT_STATUS_UNIDADES SU ON SU.CLAVE = A.CVE_ST_UNI " &
                "WHERE ISNULL(U.STATUS,'A') = 'A' AND U.CLAVEMONTE = '" & fCVE_UNI & "' AND (A.CVE_ST_UNI = 7 OR A.CVE_ST_UNI = 8)"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        StExtBase = True
                    End If
                End Using
            End Using

            If Not StExtBase Then
                Try
                    SQL = "SELECT U.CVE_ST_UNI " &
                        "FROM GCUNIDADES U " &
                        "WHERE ISNULL(U.STATUS,'A') = 'A' AND U.CLAVEMONTE = '" & fCVE_UNI & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                If dr.ReadNullAsEmptyInteger("CVE_ST_UNI") = 7 Or dr.ReadNullAsEmptyInteger("CVE_ST_UNI") = 8 Then
                                    StExtBase = True
                                End If
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If

            Return StExtBase
        Catch ex As Exception
            Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
            Return StExtBase
        End Try
    End Function
    Public Function LLANTA_ASIGNADA(fCVE_UNI As String, FCVE_LLANTA As Long) As Boolean
        Dim ExistLlanta As Boolean

        ExistLlanta = False
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If FCVE_LLANTA = 0 Then
                Return False
            End If
            Var6 = ""

            SQL = "SELECT ISNULL(UNIDAD,'') AS UNI FROM GCLLANTAS WHERE CVE_LLANTA = " & FCVE_LLANTA

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                If dr("UNI").ToString.Trim.Length > 0 Then
                    ExistLlanta = True
                    Var6 = dr("UNI")
                End If
            End If
            dr.Close()

        Catch ex As Exception
            Bitacora("475. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("475. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return ExistLlanta
    End Function
    Public Function LLANTA_ASIGNADA_UNIDADES(FCVE_LLANTA As Long) As Boolean
        Dim ExistLlanta As Boolean

        ExistLlanta = False
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If FCVE_LLANTA = 0 Then
                Return False
            End If
            Var6 = ""

            SQL = "SELECT ISNULL(UNIDAD,'') AS CVE_MONTE FROM GCLLANTAS WHERE CVE_LLANTA = " & FCVE_LLANTA & "'"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                ExistLlanta = True
                Var6 = dr("CVE_MONTE")
            End If
            dr.Close()

        Catch ex As Exception
            Bitacora("475. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("475. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return ExistLlanta
    End Function

    Public Function EXIST_NUM_ECONOMICO(FNUM_ECONOMICO As String) As String
        Dim ExistLlanta As String = ""

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If FNUM_ECONOMICO.Trim.Length = 0 Then
                Return False
            End If
            Var6 = ""

            SQL = "SELECT ISNULL(UNIDAD,'') AS CVE_MONTE FROM GCLLANTAS WHERE NUM_ECONOMICO = '" & FNUM_ECONOMICO & "'"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                ExistLlanta = dr("CVE_MONTE")
                If ExistLlanta.Trim.Length = 0 Then
                    ExistLlanta = "Existe pero no tiene unidad asignada"
                End If
            End If
            dr.Close()

        Catch ex As Exception
            Bitacora("475. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("475. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return ExistLlanta
    End Function


    Public Function Closo_Form_Open(fFrm As Form)
        Dim SiOpen As Boolean
        SiOpen = False
        Try
            For Each form In My.Application.OpenForms
                If (form.name = fFrm.Name) Then
                    fFrm.Close()
                    fFrm.Dispose()
                    SiOpen = True
                    Exit For
                End If
            Next
            Return SiOpen
        Catch ex As Exception
            Bitacora("201. " & ex.Message & vbNewLine & "---------------------------------" & ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function GRABA_BITA(fClave As String, fCVE_DOC_OBS As String, fIMPORTE As Single, fTIPO_VENTA As String, fMOTIVO As String,
                    Optional fCVE_DOC As String = "", Optional fCVE_ART As String = "", Optional fCVE_ACTIVIDAD As String = "") As Long
        Dim OBSER As String, CVE_BITA As Long = 0, CVE_COM As String
        Try
            Select Case fTIPO_VENTA
                Case "V"
                    CVE_COM = "VIAJE"
                Case "C"
                    CVE_COM = "CARPO"
                Case "P"
                    CVE_COM = "PEDI"
                Case "L"
                    CVE_COM = "LLANTAS"
                Case "T"
                    CVE_COM = "CONTRATO"
                Case "X"
                    CVE_COM = "CXC CFDI CARTA PORTE"
                Case Else
                    CVE_COM = ""
            End Select
            If fCVE_ACTIVIDAD.Length > 5 Then fCVE_ACTIVIDAD = fCVE_ACTIVIDAD.Substring(0, 5)
            If fCVE_ART.Length > 16 Then fCVE_ART = fCVE_ART.Substring(0, 16)

            OBSER = fMOTIVO & " {" & fCVE_DOC_OBS & "} $ " & IIf(fTIPO_VENTA <> "C" And fTIPO_VENTA <> "V", Format(fIMPORTE, "###,##0.00"), "")
            If Len(OBSER) > 255 Then OBSER = Mid$(OBSER, 1, 255)

            SQL = "SET ansi_warnings OFF
                INSERT INTO GCBITA (CVE_BITA, CVE_DOC, CVE_ART, CVE_CLIE, CVE_CAMPANIA, CVE_ACTIVIDAD, FECHAHORA, CVE_USUARIO, OBSERVACIONES, " &
                "STATUS, NOM_USUARIO) OUTPUT Inserted.CVE_BITA Values((SELECT COALESCE(MAX(CVE_BITA),0) + 1 FROM GCBITA),'" & fCVE_DOC & "','" &
                fCVE_ART & "','" & fClave & "','" & CVE_COM & "','" & fCVE_ACTIVIDAD & "',GETDATE(),'" & CLAVESAE & "','" & OBSER & "','" &
                fTIPO_VENTA & "','" & USER_GRUPOCE & "')"
            For o = 1 To 5
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If Val(returnValue) > 0 Then
                            CVE_BITA = returnValue
                            Exit For
                        End If
                    End If
                End Using
            Next

            Return CVE_BITA
            'If EXECUTE_QUERY_NET(SQL) Then
            'End If
        Catch ex As Exception
            Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_BITA
            'MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Function
    Public Function QUERY_GET_DATO(FTABLA As String, FGET_FIELD As String, FIELD1 As String, FIELD2 As String, FIELD3 As String,
                                    FFIELD_WHERE1 As String, FFIELD_WHERE2 As String, FFIELD_WHERE3 As String, EsNumber As Boolean) As String
        Dim DATO As String = ""

        If Not Valida_Conexion() Then
            Return False
        End If

        'FTABLA ,   FGET_FIELD, FIELD1,     FIELD2,     FIELD3,     FFIELD_WHERE1, FFIELD_WHERE2, FFIELD_WHERE3,    EsNumber
        'GCTARIFAS, PRECIO,     CVE_RUTA,   CVE_ART,    CVE_PRECIO, tCVE_TAB.Text, TCVE_ART.Text, 1,                True
        Try
            '     TCVE_ART.TEXT                        1
            If FFIELD_WHERE2.Trim.Length = 0 And FFIELD_WHERE3.Trim.Length = 0 Then
                SQL = "SELECT " & FGET_FIELD & " FROM " & FTABLA & " WHERE " & FIELD1 & " = '" & FFIELD_WHERE1 & "'"
            Else '                 PRECIO                 GCTARIFAS            CVE_RUTA          CVE_TAB
                '    TCVE_ART.TEXT                               1             
                If FFIELD_WHERE2.Trim.Length > 0 And FFIELD_WHERE3.Trim.Length > 0 Then
                    '                   "PRECIO"              GCTARIFAS           "CVE_RUTA"            CVE_TAB 
                    SQL = "SELECT " & FGET_FIELD & " FROM " & FTABLA & " WHERE " & FIELD1 & " = '" & FFIELD_WHERE1 & "' AND 
                        " & FIELD2 & " = '" & FFIELD_WHERE2 & "'  AND " & FIELD3 & " = '" & FFIELD_WHERE3 & "'"
                    '                          TCVE_ART.TEXT
                Else '                  "PRECIO"
                    SQL = "SELECT " & FGET_FIELD & " FROM " & FTABLA & " WHERE " & FIELD1 & " = '" & FFIELD_WHERE1 & "' AND 
                        " & FIELD2 & " = '" & FFIELD_WHERE2 & "'"
                    '      CVE_PRECIO         TCVE_ART.TEXT
                End If
            End If
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        DATO = dr.ReadNullAsEmptyString(FGET_FIELD)
                    End If
                End Using
            End Using
            If EsNumber Then
                If String.IsNullOrWhiteSpace(DATO) AndAlso Not IsNumeric(DATO) Then
                    DATO = "0"
                End If
            End If
        Catch ex As Exception
            Bitacora("620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return DATO
    End Function

    Public Function EXECUTE_QUERY_NET(fSQL As String) As Boolean
        Dim Efecto As Boolean = False

        Try
            For k = 1 To 5

                If Valida_Conexion() Then
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = fSQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Try
                                        ReturnValueLong = returnValue
                                    Catch ex As Exception
                                    End Try

                                    Efecto = True
                                    Exit For
                                End If
                            End If
                        End Using
                    Catch ex As SqlException
                        Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
                    Catch ex As Exception
                        Bitacora("610. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next

            Return Efecto

        Catch ex As Exception
            Bitacora("620. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & fSQL)
            Return False
        End Try
    End Function
    Public Function EXECUTE_QUERY_SAROCE(fSQL As String) As Boolean
        Dim Efecto As Boolean = False

        Try
            For k = 1 To 5

                If Valida_Conexion_SAROCE() Then
                    Try
                        Using cmd As SqlCommand = cnSAROCE.CreateCommand
                            cmd.CommandText = fSQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Efecto = True
                                    Exit For
                                End If
                            End If
                        End Using
                    Catch ex As SqlException
                        Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
                    Catch ex As Exception
                        Bitacora("610. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next

            Return Efecto

        Catch ex As Exception
            Bitacora("620. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & fSQL)
            Return False
        End Try
    End Function

    Public Function OBTENER_SERIE_USUARIO_TIPO_VENTA(FTIPO_VENTA As String) As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim SER_VENTA As String = "", SQLx As String
        Try
            'SQLx = "SELECT SERIE FROM GCUSUARIOS_SERIE WHERE UPPER(USUARIO) = '" & USER_GRUPOCE.ToUpper & "' AND TIP_DOC = '" & fTIPO_VENTA & "'"

            SQLx = "SELECT SERIE FROM GCUSUARIOS_PARAM WHERE UPPER(USUARIO) = '" & USER_GRUPOCE.ToUpper & "' AND TIPO_DOC = '" & FTIPO_VENTA & "'"
            cmd.Connection = cnSAE
            cmd.CommandText = SQLx
            dr = cmd.ExecuteReader
            If dr.Read Then
                SER_VENTA = dr("SERIE")
            End If
            dr.Close()
            Return SER_VENTA
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return ""
        End Try
    End Function

    Public Function OBTENER_CONSECUTIVO_OT(fCVE_ORD As String) As String
        Dim Sigue As Boolean = True
        Dim CVE_ORD As String, CV_ORD As Long, SQLx As String

        CV_ORD = fCVE_ORD
        CVE_ORD = fCVE_ORD
        Try
            Do While Sigue
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQLx = "SELECT CVE_ORD FROM GCORDEN_TRABAJO_EXT WHERE CVE_ORD  = '" & CVE_ORD & "'"
                    cmd.CommandText = SQLx
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CV_ORD += 1
                            CVE_ORD = CV_ORD
                        Else
                            Sigue = False
                        End If
                    End Using
                End Using
            Loop
            Return CVE_ORD
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_ORD
        End Try
    End Function
    Public Function VALIDA_FG(fFG As String) As Decimal
        Dim FgRegresa As Decimal = 0
        Try
            If Not IsNothing(fFG) Then
                If Not String.IsNullOrEmpty(fFG) Then
                    fFG = fFG.Replace(",", "")
                    If IsNumeric(fFG) Then
                        FgRegresa = fFG
                    End If
                End If
            End If
            Return FgRegresa
        Catch ex As Exception
            Bitacora("660. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("660. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return FgRegresa
        End Try
    End Function
    Public Function TruncateDec(ByVal ToTruncate As Decimal, ByVal DecimalPlaces As Integer) As Double
        Try
            Dim power As Decimal = Math.Pow(10, DecimalPlaces)
            Return Math.Truncate(ToTruncate * power) / power
        Catch ex As Exception
            Bitacora("670. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("670. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return ToTruncate
        End Try
    End Function
    Public Function TrunStr(ByVal ToTruncate As Decimal, ByVal DecimalPlaces As Integer) As Double
        Try
            Dim num As Double = ToTruncate
            num.ToString("G" & DecimalPlaces)
            Return num
        Catch ex As Exception
            Bitacora("670. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("670. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return ToTruncate
        End Try
    End Function
    Public Sub TOOLTIP_EN_CONTROLES(ByVal FControl As Control, FTOOLTIP As C1SuperTooltip)
        Try
            For Each c In FControl.Controls
                Try
                    If c.ToString = "" Then

                    End If
                    If TypeOf c Is TextBox Then
                        FTOOLTIP.SetToolTip(c, CType(c, TextBox).Name)
                    ElseIf TypeOf c Is ComboBox Then
                        FTOOLTIP.SetToolTip(c, CType(c, ComboBox).Name)
                    ElseIf TypeOf c Is ListView Then
                        FTOOLTIP.SetToolTip(c, CType(c, ListView).Name)
                    ElseIf TypeOf c Is TreeView Then
                        FTOOLTIP.SetToolTip(c, CType(c, TreeView).Name)
                    ElseIf TypeOf c Is CheckBox Then
                        FTOOLTIP.SetToolTip(c, CType(c, CheckBox).Name)
                    ElseIf TypeOf c Is ListBox Then
                        FTOOLTIP.SetToolTip(c, CType(c, ListBox).Name)
                    ElseIf TypeOf c Is Label Then
                        FTOOLTIP.SetToolTip(c, CType(c, Label).Name)
                    End If
                Catch ex As Exception
                    Bitacora("670. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("680. " & ex.Message & vbNewLine & "ex.StackTr ace: " & ex.StackTrace)
        End Try
    End Sub
    Public Sub SET_THEME(fControl As Control, FTHEME As String)
        Try
            For Each control In fControl.Controls
                Try
                    Dim theme As C1Theme = C1ThemeController.GetThemeByName(FTHEME, True)
                    C1ThemeController.ApplyThemeToControlTree(control, theme)
                Catch ex As Exception
                End Try
            Next

            For Each c As TextBox In fControl.Controls.OfType(Of TextBox)()
                Try
                    Dim theme As C1Theme = C1ThemeController.GetThemeByName(FTHEME, True)
                    C1ThemeController.ApplyThemeToControlTree(c, theme)
                Catch ex As Exception
                End Try
            Next
            For Each c As Button In fControl.Controls.OfType(Of Button)()
                Try
                    Dim theme As C1Theme = C1ThemeController.GetThemeByName(FTHEME, True)
                    C1ThemeController.ApplyThemeToControlTree(c, theme)
                Catch ex As Exception
                End Try
            Next
            For Each c As RadioButton In fControl.Controls.OfType(Of RadioButton)()
                Try
                    Dim theme As C1Theme = C1ThemeController.GetThemeByName(FTHEME, True)
                    C1ThemeController.ApplyThemeToControlTree(c, theme)
                Catch ex As Exception
                End Try
            Next
            For Each c As CheckBox In fControl.Controls.OfType(Of CheckBox)()
                Try
                    Dim theme As C1Theme = C1ThemeController.GetThemeByName(FTHEME, True)
                    C1ThemeController.ApplyThemeToControlTree(c, theme)
                Catch ex As Exception
                End Try
            Next
            For Each c As Control In fControl.Controls.OfType(Of RichTextBox)()
                Try
                    Dim theme As C1Theme = C1ThemeController.GetThemeByName(FTHEME, True)
                    C1ThemeController.ApplyThemeToControlTree(c, theme)
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("680. " & ex.Message & vbNewLine & "ex.StackTr ace: " & ex.StackTrace)
        End Try
    End Sub


    Public Sub SET_ALL_CONTROL_READ_AND_ENABLED(fControl As Control, Optional Efecto As Boolean = False)
        Try
            For Each c As TextBox In fControl.Controls.OfType(Of TextBox)()
                'c.ReadOnly = True
                c.Enabled = Efecto
                If c.GetType.ToString = "C1.Win.C1Input.C1NumericEdit" Then
                    c.Enabled = Efecto
                End If
                If c.GetType.ToString = "C1.Win.Calendar.C1DateEdit" Then
                    c.Enabled = Efecto
                End If
                'Debug.Print(c.GetType.ToString)
            Next
            For Each c As Button In fControl.Controls.OfType(Of Button)()
                c.Enabled = Efecto
            Next
            For Each c As RadioButton In fControl.Controls.OfType(Of RadioButton)()
                c.Enabled = Efecto
            Next
            For Each c As CheckBox In fControl.Controls.OfType(Of CheckBox)()
                c.Enabled = Efecto
            Next
            For Each c As Control In fControl.Controls.OfType(Of RichTextBox)()
                'If TypeOf cntrl Is PictureBox Then
                'End If
                Debug.Print(c.Name & "," & fControl.Name)
                If c.Name = "tOBS" Or c.Name = "tCVE_OBS_CON" Or c.Name = "tCVE_OBS" Then
                    If TypeOf c Is RichTextBox Then
                        c.Enabled = Efecto
                    End If
                End If
                If TypeOf c Is TextBox Then
                End If
            Next
        Catch ex As Exception
            Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("680. " & ex.Message & vbNewLine & "ex.StackTr ace: " & ex.StackTrace)
        End Try
    End Sub
    Public Sub LIMPIAR_ALL_CONTROL(fControl As Control)
        Try
            For Each c As TextBox In fControl.Controls.OfType(Of TextBox)()
                Try
                    If c.Name <> "F1" And c.Name <> "F2" Then
                        c.Text = ""
                    End If
                Catch ex As Exception
                    Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            For Each c As Label In fControl.Controls.OfType(Of Label)()
                Try
                    If c.Name.Substring(0, 2) = "Lt" Then
                        c.Text = ""
                    End If
                Catch ex As Exception
                    Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            For Each c As RadioButton In fControl.Controls.OfType(Of RadioButton)()
                Try
                    c.Checked = False
                Catch ex As Exception
                    Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            For Each c As CheckBox In fControl.Controls.OfType(Of CheckBox)()
                Try
                    c.Checked = False
                Catch ex As Exception
                    Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("680. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    Public Function RemoveCharacter(ByVal stringToCleanUp As String) As String
        Dim CharacterToRemove As String

        Try
            If Not IsNothing(stringToCleanUp) Then
                CharacterToRemove = Chr(10) + Chr(13) + Chr(9) + vbTab + vbLf + vbCr
                Dim firstThree As Char() = CharacterToRemove.Take(16).ToArray()
                For index = 1 To firstThree.Length - 1
                    stringToCleanUp = stringToCleanUp.ToString.Replace(firstThree(index), "")
                Next
            Else
                stringToCleanUp = ""
            End If
            Return stringToCleanUp
        Catch ex As Exception
            Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
            Return stringToCleanUp
        End Try
    End Function
    Public Function BUSCAR_FORMA_PAGO(fFORMA_PAGO As String) As String
        Dim NOM_PAGO As String = ""
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            If fFORMA_PAGO = "99" Then
                NOM_PAGO = "Por definir"
            Else
                SQL = "SELECT NUM_CPTO, DESCR, FORMADEPAGOSAT " &
                "FROM CONC" & Empresa & " WHERE FORMADEPAGOSAT = '" & fFORMA_PAGO & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    NOM_PAGO = dr.ReadNullAsEmptyString("DESCR")
                End If
                dr.Close()
            End If
            Return NOM_PAGO
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Return NOM_PAGO
        End Try
    End Function
    Public Function RFC_CLIENTE_EXISTE(fRFC As String) As Boolean
        Dim ExistRFC As Boolean = False

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim SQLx As String
            cmd.Connection = cnSAE

            SQLx = "SELECT CLAVE, NOMBRE 
                  FROM CLIE" & Empresa & " WHERE LTRIM(RTRIM(RFC)) = '" & fRFC.Trim & "'"
            cmd.CommandText = SQLx
            dr = cmd.ExecuteReader
            If dr.Read Then
                ExistRFC = True
                Var10 = dr("CLAVE") & " " & dr("NOMBRE")
            End If
            dr.Close()

            Return ExistRFC
        Catch ex As Exception
            MsgBox("2000. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2000. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ExistRFC
        End Try
    End Function
    Public Function RFC_PROV_EXISTE(fRFC As String) As Boolean
        Dim ExistRFC As Boolean = False

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT CLAVE, NOMBRE 
                  FROM PROV" & Empresa & " WHERE RFCC= '" & fRFC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                ExistRFC = True
                Var10 = dr("CLAVE") & " " & dr("NOMBRE")
            End If
            dr.Close()

            Return ExistRFC
        Catch ex As Exception
            MsgBox("2000. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2000. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ExistRFC
        End Try
    End Function
    Public Sub BACKUPXML(ByVal NombreArchivo As String, ByVal strData As String, Optional SobreEscribir As Boolean = False)
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(NombreArchivo, SobreEscribir)
            objReader.Write(strData)
            objReader.Close()
            Var4 = "OK"
        Catch Ex As Exception
            Var4 = "NO"
            Bitacora("60. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("Ruta no valida, verifique por favor")
        End Try
    End Sub

    Public Sub SendEmail(ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String, Optional ByVal AttachmentFiles As ArrayList = Nothing,
                         Optional ByVal FCORREO1 As String = "", Optional ByVal FCORREO2 As String = "", Optional ByVal FCORREO3 As String = "",
                         Optional ByVal FCORREO4 As String = "", Optional ByVal FCORREO5 As String = "")

        Dim SmtpServer As New SmtpClient()
        Dim i, iCnt As Integer, ARCHIVO As String

        Dim SERVIDOR_SMTP As String = "smtp.office365.com"
        Dim PUERTO_SMTP As Integer = 587
        Dim USER_SMTP As String = "heosoft@outlook.es"
        Dim PASS_SMTP As String = "r3ZyP-_Q#.CD7jR"
        Dim EnableSsl As Boolean = True

        Dim CC1 As String = FCORREO1.Replace(";", "")
        Dim C2 As String = FCORREO2.Replace(";", "")
        Dim C3 As String = FCORREO3.Replace(";", "")
        Dim C4 As String = FCORREO4.Replace(";", "")

        Dim Mail As New MailMessage()

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCSMTP"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SERVIDOR_SMTP = dr.ReadNullAsEmptyString("SERVIDOR")
                        If SERVIDOR_SMTP.Trim.Length > 0 Then
                            If IsNumeric(dr.ReadNullAsEmptyInteger("PUERTO")) Then
                                PUERTO_SMTP = dr.ReadNullAsEmptyInteger("PUERTO")
                                If PUERTO_SMTP = 0 Then
                                    PUERTO_SMTP = 587
                                End If
                            End If
                            USER_SMTP = dr.ReadNullAsEmptyString("USUARIO")
                            Try
                                If dr.ReadNullAsEmptyString("PASS").ToString.Trim.Length > 0 Then
                                    PASS_SMTP = Desencriptar(dr.ReadNullAsEmptyString("PASS"))
                                Else
                                    PASS_SMTP = ""
                                End If
                            Catch ex As Exception
                                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            EnableSsl = IIf(dr.ReadNullAsEmptyInteger("SSL") = 1, True, False)
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            'Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("60. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        If SERVIDOR_SMTP.Trim.Length = 0 Or PASS_GRUPOCE = "WINAS" Then
            If MsgBox("Realmente desea envia el correo?", vbYesNo) = vbYes Then
                SERVIDOR_SMTP = "smtp.office365.com" '"smtp-mail.outlook.com"
                PUERTO_SMTP = 587
                USER_SMTP = "heosoft@outlook.es"
                PASS_SMTP = "r3ZyP-_Q#.CD7jR"
                EnableSsl = True
            End If
        End If


        Try
            If SERVIDOR_SMTP.Trim.Length > 0 And PUERTO_SMTP > 0 Then
                CC1 = CC1.Replace(",", "")
                C2 = C2.Replace(",", "")
                C3 = C3.Replace(",", "")
                C4 = C4.Replace(",", "")
                strTo = strTo.Replace(";", "")
                Mail = New MailMessage With {.From = New MailAddress(USER_SMTP)}

                Mail.To.Add(strTo)
                If CC1.Trim.Length > 0 Then Mail.To.Add(CC1)
                If C2.Trim.Length > 0 Then Mail.To.Add(C2)
                If C3.Trim.Length > 0 Then Mail.To.Add(C3)
                If C4.Trim.Length > 0 Then Mail.To.Add(C4)

                Mail.Subject = strSubject
                Mail.Body = strBody

                If AttachmentFiles IsNot Nothing Then
                    iCnt = AttachmentFiles.Count - 1
                    For i = 0 To iCnt
                        If File.Exists(AttachmentFiles(i)) Then
                            ARCHIVO = AttachmentFiles(i)
                            Try
                                Dim attach As New Net.Mail.Attachment(ARCHIVO)
                                Mail.Attachments.Add(attach)
                            Catch ex As Exception
                                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("60. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End If
                    Next
                End If
                SmtpServer.UseDefaultCredentials = False
                SmtpServer.Credentials = New Net.NetworkCredential(USER_SMTP, PASS_SMTP)
                SmtpServer.Host = SERVIDOR_SMTP
                SmtpServer.Port = PUERTO_SMTP
                SmtpServer.EnableSsl = EnableSsl
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network

                SmtpServer.Send(Mail)
            End If
        Catch ex As Exception
            'Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & strTo & "," & CC1 & "," & C2 & "," & C3 & "," & C4)
            'MsgBox("60. " & ex.Message & vbCrLf & ex.StackTrace)
            Throw ex
        Finally
        End Try
    End Sub

    Public Function Validar_Mail(ByVal sMail As String) As Boolean
        Try            ' retorna true o false   
            If sMail.Trim.Length > 0 Then
                Return Regex.IsMatch(sMail, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub PLAY_WAV(fINDEX As Integer)
        Try
            Dim ArchivoWav As String = ""

            Select Case fINDEX
                Case 1
                    ArchivoWav = "tone1.wav"
                Case 2
                    ArchivoWav = "tone2.wav"
                Case 3
                    ArchivoWav = "tone3.wav"
            End Select
            ArchivoWav = Application.StartupPath & "\" & ArchivoWav
            If File.Exists(ArchivoWav) Then
                My.Computer.Audio.Play(ArchivoWav)
            Else
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            End If
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Function StrToNum(ByVal value As String) As Integer
        Try
            Dim mytext As String = value
            Dim myChars() As Char = mytext.ToCharArray()
            Dim returnVal As String = ""

            For Each ch As Char In myChars
                If Char.IsDigit(ch) Then
                    returnVal += ch
                End If
            Next
            Return Convert.ToInt32(returnVal)

        Catch ex As Exception
            Return value
        End Try

    End Function

    Public Function OBTENER_RUTA_XML() As String
        Dim RUTA_XML As String = Application.StartupPath

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                RUTA_XML = dr.ReadNullAsEmptyString("RUTA_XML")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return RUTA_XML

    End Function
    Public Function BUSCA_CTA_CONTABLE(fCVE_ALM As Integer) As String
        Dim CUENTA_CONT As String = ""

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CUEN_CONT FROM ALMACENES" & Empresa & " WHERE  CVE_ALM = " & fCVE_ALM
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CUENTA_CONT = dr.ReadNullAsEmptyString("CUEN_CONT")
                    End If
                End Using
            End Using
            Return CUENTA_CONT
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CUENTA_CONT
        End Try
    End Function
    Public Function BUSCA_CTA_ARTICULO(fCVE_ART As String) As String
        Dim CUENTA_CONT As String = ""

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CUEN_CONT FROM INVE" & Empresa & " WHERE  CVE_ALM = " & fCVE_ART
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CUENTA_CONT = dr.ReadNullAsEmptyString("CUEN_CONT")
                    End If
                End Using
            End Using
            Return CUENTA_CONT
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CUENTA_CONT
        End Try
    End Function
    Public Function BUSCA_ALMACEN_ARTICULO(FREFER As String, fCVE_ART As String) As Integer
        Dim CVE_ALM As Integer

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ALMACEN FROM MINVE" & Empresa & " WHERE REFER = '" & FREFER & "' AND CVE_ART = '" & fCVE_ART & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_ALM = dr.ReadNullAsEmptyString("ALMACEN")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return CVE_ALM
    End Function
    Public Function GET_NUM_MAX_CVE_ART() As String
        Try
            SQL = "SELECT MAX(CVE_ART), MAX(SUBSTRING(CVE_ART,2,LEN(CVE_ART))) FROM INVE" & Empresa & " WHERE SUBSTRING(CVE_ART,1,1) = 'M' AND SUBSTRING(CVE_ART,1,2) <> 'MS'"

            Return ""
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function

    Public Function BUSCA_CVE_LLANTA(FNUM_ECONOMICO As String) As String
        Dim ART As String = ""
        Var45 = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_LLANTA
                    FROM GCLLANTAS WHERE NUM_ECONOMICO = '" & FNUM_ECONOMICO & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        ART = dr("CVE_LLANTA")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return ART
    End Function


    Public Function BUSCA_ARTICULO_EN_LLANTAS(FNUM_ECONOMICO As String) As String
        Dim ART As String = ""
        Var45 = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ART, ISNULL(COSTO_LLANTA_MN,0) AS COSTO 
                    FROM GCLLANTAS WHERE NUM_ECONOMICO = '" & FNUM_ECONOMICO & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        ART = dr("CVE_ART")
                        Var45 = dr("COSTO")
                    End If
                End Using
            End Using
            Return ART
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ART
        End Try
    End Function

    Public Sub GRABA_ASIG_LLANTA(FNUM_ECONOMICO As String, FCVE_LLANTA As String, FPOS As Integer,
                      FTIPO_MOV As Integer, FCVE_UNI As String)

        SQL = "INSERT INTO GCLLANTAS_ASIG (NUM_ECONOMICO, POSICION, CVE_UNI, CVE_LLANTA, TIPO_MOV, USUARIO, FECHAELAB, UUID)
            VALUES(@NUM_ECONOMICO, @POSICION, @CVE_UNI, @CVE_LLANTA, @TIPO_MOV, @USUARIO, GETDATE(), NEWID())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = FNUM_ECONOMICO
                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = FPOS
                cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = FCVE_UNI
                cmd.Parameters.Add("@CVE_LLANTA", SqlDbType.VarChar).Value = FCVE_LLANTA
                cmd.Parameters.Add("@TIPO_MOV", SqlDbType.SmallInt).Value = FTIPO_MOV
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

    End Sub

    Public Function GET_ONLY_LETTER(FLETRAS As String) As String
        Dim LETRAS As String = ""

        Try
            LETRAS = String.Concat(FLETRAS.Where(AddressOf Char.IsLetter))
        Catch ex As Exception

        End Try
        Return LETRAS

    End Function
    Public Function GET_ONLY_LETTER2(FLETRAS As String) As String
        Dim LETRAS As String = ""
        Try
            Dim mytext As String = FLETRAS
            Dim Result As String = Regex.Replace(mytext, "[^a-zA-Z]", "")
            Dim myChars() As Char = Result.ToCharArray()
            For Each ch As Char In myChars
                If Char.IsDigit(ch) Then
                    LETRAS += ch
                End If
            Next
        Catch ex As Exception
        End Try
        Return LETRAS
    End Function
    Public Function GetNumeric(value As String) As String
        'OBGTIENE LA PARTE NUMERICA DE UNA CADENA
        Try
            Dim Output As New StringBuilder
            For i = 0 To value.Length - 1
                If IsNumeric(value(i)) Then
                    Output.Append(value(i))
                End If
            Next
            Return Output.ToString()
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Return ""
        End Try
    End Function

    Public Function BUSCAR_UUID_CARTA_PORTE(FFACTURA As String) As String
        Dim XML_TABLA As String = "", FILE_XML As String, UUID As String = "", VERSION As String = ""
        Dim xdoc As New XmlDocument()

        Try
            Select Case Var47
                Case "PAGO CFDI"
                    Var2 = Var47
                Case "FACTURA CFDI"
                    Var2 = Var47
                    Var5 = ""
                Case "Carta porte"
                    Var2 = "Carta porte"
            End Select

            If Var47 = "PAGO CFDI" Then
                SQL = "SELECT XML, VERSION FROM CFDI_COMPAGO WHERE CVE_DOC = '" & FFACTURA & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            XML_TABLA = dr("XML")
                            VERSION = dr("VERSION")
                        End If
                    End Using
                End Using
            Else
                SQL = "SELECT TDOC, DOCUMENT, XML, FILE_XML, ISNULL(VERSION,'') AS VERSION_CFDI 
                    FROM CFDI WHERE FACTURA = '" & FFACTURA & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            XML_TABLA = dr("XML")
                            VERSION = dr("VERSION_CFDI")
                        End If
                    End Using
                End Using
                If XML_TABLA.Trim.Length = 0 Then
                    SQL = "SELECT ISNULL(XML_DOC,'') AS XML, ISNULL(VERSION,'') AS VERSION_CFDI 
                        FROM CFDI" & Empresa & " WHERE CVE_DOC = '" & FFACTURA & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                XML_TABLA = dr("XML")
                                VERSION = dr("VERSION_CFDI")
                            End If
                        End Using
                    End Using
                End If
            End If

            If XML_TABLA.Trim.Length > 0 Then

                If VERSION = "4.0" Then
                    FILE_XML = OBTENER_RUTA_XML_TRANS_PDF() & "\TEMPXML40.xml"
                Else
                    FILE_XML = OBTENER_RUTA_XML_TRANS_PDF() & "\TEMPXML33.xml"
                End If

                File.WriteAllText(FILE_XML, XML_TABLA)

                xdoc.Load(FILE_XML)

                Dim v_namespace As New XmlNamespaceManager(xdoc.NameTable)

                If VERSION = "4.0" Then
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")
                Else
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                End If
                v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
                v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")

                Try
                    If Not IsNothing(xdoc.SelectSingleNode("/cfdi:Comprobante/@Serie", v_namespace)) Then
                        SERIE_CFDI = xdoc.SelectSingleNode("/cfdi:Comprobante/@Serie", v_namespace).InnerText
                    End If
                Catch ex As Exception
                End Try

                UUID = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", v_namespace).InnerText

                xdoc = Nothing
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "XML=" & XML_TABLA & "," & VERSION)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine &
                   "Por favor verifique que la version CFDI del documento " & FFACTURA &
                   " sea la correcta, verifique en la bitacora, ahi encontrará el contenido del XML")
        End Try

        Return UUID

    End Function

    Public Function BUSCAR_UUID_FACTURA_SAE(FCVE_DOC As String) As String
        Dim XML_TABLA As String = "", FILE_XML As String, UUID As String = "", VERSION As String = ""
        Dim xdoc As New XmlDocument()

        Try
            SQL = "SELECT XML, ISNULL(VERSION,'') AS VERSION_CFDI 
                FROM CFDI" & Empresa & " WHERE TIPO_DOC = 'F' AND CVE_DOC = '" & FCVE_DOC & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML_TABLA = dr("XML_DOC")
                        VERSION = dr("VERSION_CFDI")
                    End If
                End Using
            End Using

            If XML_TABLA.Trim.Length > 0 Then

                FILE_XML = OBTENER_RUTA_XML_TRANS_PDF() & "\TEMPXML_FAC.xml"
                File.WriteAllText(FILE_XML, XML_TABLA)

                xdoc.Load(FILE_XML)

                Dim v_namespace As New XmlNamespaceManager(xdoc.NameTable)


                If VERSION = "4.0" Then
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")
                Else
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                End If
                v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
                v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")

                UUID = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", v_namespace).InnerText
                xdoc = Nothing
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "XML=" & XML_TABLA & "," & VERSION)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return UUID
    End Function    '
    Public Function BUSCAR_UUID_FACTURA_TRANSPORT(FCVE_DOC As String) As String
        Dim XML_TABLA As String = "", FILE_XML As String, UUID As String = "", VERSION As String = ""
        Dim xdoc As New XmlDocument()

        Try
            SQL = "SELECT XML, ISNULL(VERSION,'') AS VERSION_CFDI 
                FROM CFDI WHERE FACTURA = '" & FCVE_DOC & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML_TABLA = dr("XML")
                        VERSION = dr("VERSION_CFDI")
                    End If
                End Using
            End Using

            If XML_TABLA.Trim.Length > 0 Then

                FILE_XML = OBTENER_RUTA_XML_TRANS_PDF() & "\TEMPXML_FAC.xml"
                File.WriteAllText(FILE_XML, XML_TABLA)

                xdoc.Load(FILE_XML)

                Dim v_namespace As New XmlNamespaceManager(xdoc.NameTable)

                If VERSION = "4.0" Then
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")
                Else
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                End If
                v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
                v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")

                UUID = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", v_namespace).InnerText
                xdoc = Nothing
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "XML=" & XML_TABLA & "," & VERSION)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return UUID
    End Function    '

    Public Function BUSCAR_TotalDistRec(FCVE_DOC As String) As String
        Dim XML_TABLA As String = "", FILE_XML As String, TotalDistRec As String = "0", VERSION As String = ""
        Dim xdoc As New XmlDocument()
        Try
            SQL = "SELECT TDOC, DOCUMENT, XML, FILE_XML, ISNULL(VERSION,'') AS VERSION_CFDI
                FROM CFDI WHERE FACTURA = '" & FCVE_DOC & "' AND ISNULL(ESTATUS,'A') <> 'C'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML_TABLA = dr("XML")
                        VERSION = dr("VERSION_CFDI")
                    End If
                End Using
            End Using

            If XML_TABLA.Trim.Length > 0 Then

                FILE_XML = OBTENER_RUTA_XML_TRANS_PDF() & "\TEMPXML_FAC.xml"
                File.WriteAllText(FILE_XML, XML_TABLA)
                xdoc.Load(FILE_XML)

                Dim v_namespace As New XmlNamespaceManager(xdoc.NameTable)

                If VERSION = "4.0" Then
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")
                Else
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                End If
                v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
                v_namespace.AddNamespace("cartaporte20", "http://www.sat.gob.mx/CartaPorte20")
                v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")

                TotalDistRec = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/cartaporte20:CartaPorte/@TotalDistRec", v_namespace).InnerText

                xdoc = Nothing
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "XML=" & XML_TABLA & "," & VERSION)
            'MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Not IsNumeric(TotalDistRec) Then
            TotalDistRec = "0"
        End If

        Return TotalDistRec

    End Function
    Public Function BUSCAR_CAMPOS_CFDI40(FXML As String) As String
        Dim UUID As String = "", VERSION As String = "4.0"
        Dim FECHA_TIMBRADO As String, FECHA_EXP As String, SELLO_SAT As String, NO_CERTIFICADO_SAT As String
        Dim SELLO_CFD As String, NO_CERTIFICADO As String, RfcProvCertif As String

        Dim xdoc As New XmlDocument()

        Try
            If FXML.Trim.Length > 0 Then

                xdoc.Load(FXML)

                Dim v_namespace As New XmlNamespaceManager(xdoc.NameTable)

                v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")

                v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
                v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")

                NO_CERTIFICADO = xdoc.SelectSingleNode("/cfdi:Comprobante//@NoCertificado", v_namespace).InnerText

                UUID = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", v_namespace).InnerText
                FECHA_TIMBRADO = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@FechaTimbrado", v_namespace).InnerText
                FECHA_EXP = xdoc.SelectSingleNode("/cfdi:Comprobante/@Fecha", v_namespace).InnerText

                IMPORTE_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/@Total", v_namespace).InnerText

                SELLO_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloSAT", v_namespace).InnerText
                NO_CERTIFICADO_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@NoCertificadoSAT", v_namespace).InnerText
                SELLO_CFD = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloCFD", v_namespace).InnerText
                RfcProvCertif = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@RfcProvCertif", v_namespace).InnerText

                Var9 = NO_CERTIFICADO
                Var10 = FECHA_TIMBRADO
                Var11 = FECHA_EXP

                Var12 = SELLO_SAT
                Var13 = NO_CERTIFICADO_SAT
                Var14 = SELLO_CFD
                Var15 = RfcProvCertif
                xdoc = Nothing
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "XML=" & FXML & "," & VERSION)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return UUID

    End Function
    Public Function OBTENER_RUTA_XML_TRANS_PDF() As String
        Dim RUTA_DISCO As String = gRutaXML_TIMBRADO
        Try
            RUTA_DISCO = "C:\TRANS PDF\SIN PRECIOS"
            If Not Directory.Exists(RUTA_DISCO) Then
                Directory.CreateDirectory("C:\TRANS PDF")
                Directory.CreateDirectory(RUTA_DISCO)
            End If
        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return RUTA_DISCO
    End Function
    Public Function BUSCAR_UUID_CFDI40(FCVE_DOC As String) As String
        Dim XML_TABLA As String = "", FILE_XML As String, UUID As String = "", VERSION As String = ""
        Dim FECHA_TIMBRADO As String, FECHA_EXP As String, SELLO_SAT As String, NO_CERTIFICADO_SAT As String
        Dim SELLO_CFD As String, NO_CERTIFICADO As String, RfcProvCertif As String, RUTA_DISCOC As String

        Dim xdoc As New XmlDocument()

        Try
            SQL = "SELECT XML, ISNULL(VERSION,'4.0') AS VERSION_CFDI 
                FROM CFDI WHERE FACTURA = '" & FCVE_DOC & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML_TABLA = dr.ReadNullAsEmptyString("XML")
                        VERSION = dr.ReadNullAsEmptyString("VERSION_CFDI")
                    End If
                End Using
            End Using
            If XML_TABLA.Trim.Length > 0 Then

                RUTA_DISCOC = OBTENER_RUTA_XML_TRANS_PDF()

                FILE_XML = RUTA_DISCOC & "\TEMPXML.xml"
                File.WriteAllText(FILE_XML, XML_TABLA)

                xdoc.Load(FILE_XML)

                Dim v_namespace As New XmlNamespaceManager(xdoc.NameTable)

                If VERSION = "4.0" Then
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")
                Else
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                End If
                v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
                v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")

                NO_CERTIFICADO = xdoc.SelectSingleNode("/cfdi:Comprobante//@NoCertificado", v_namespace).InnerText

                UUID = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", v_namespace).InnerText
                FECHA_TIMBRADO = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@FechaTimbrado", v_namespace).InnerText
                FECHA_EXP = xdoc.SelectSingleNode("/cfdi:Comprobante/@Fecha", v_namespace).InnerText

                IMPORTE_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/@Total", v_namespace).InnerText

                SELLO_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloSAT", v_namespace).InnerText
                NO_CERTIFICADO_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@NoCertificadoSAT", v_namespace).InnerText
                SELLO_CFD = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloCFD", v_namespace).InnerText
                RfcProvCertif = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@RfcProvCertif", v_namespace).InnerText

                Var9 = NO_CERTIFICADO
                Var10 = FECHA_TIMBRADO
                Var11 = FECHA_EXP

                Var12 = SELLO_SAT
                Var13 = NO_CERTIFICADO_SAT
                Var14 = SELLO_CFD


                Try
                    SQL = "UPDATE CFDI SET SELLO_SAT = '" & SELLO_SAT & "', FECHA_TIMBRADO = '" & FECHA_TIMBRADO & "', 
                        NO_CERTIFICADO = '" & NO_CERTIFICADO & "', NO_CERTIFICADO_SAT = '" & NO_CERTIFICADO_SAT & "', 
                        SELLO_CFD = '" & SELLO_CFD & "', UUID_CFDI = '" & UUID & "', RFCPROVCERTIF = '" & RfcProvCertif & "'
                        WHERE FACTURA = '" & FCVE_DOC & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                xdoc = Nothing
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "XML=" & XML_TABLA & "," & VERSION)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return UUID

    End Function
    Public Function BUSCAR_UUID_CFDI_PAGO(FCVE_DOC As String) As String
        Dim XML_TABLA As String = "", FILE_XML As String, UUID As String = "", VERSION As String = ""
        Dim FECHA_TIMBRADO As String, FECHA_EXP As String, SELLO_SAT As String, NO_CERTIFICADO_SAT As String
        Dim SELLO_CFD As String, NO_CERTIFICADO As String, RfcProvCertif As String, RUTA_DISCOC As String

        Dim xdoc As New XmlDocument()

        Try
            SQL = "SELECT XML, ISNULL(VERSION,'4.0') AS VERSION_CFDI 
                FROM CFDI_COMPAGO WHERE CVE_DOC = '" & FCVE_DOC & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML_TABLA = dr.ReadNullAsEmptyString("XML")
                        VERSION = dr.ReadNullAsEmptyString("VERSION_CFDI")
                    End If
                End Using
            End Using
            If XML_TABLA.Trim.Length > 0 Then

                Try
                    RUTA_DISCOC = "C:\TRANS PDF\SIN PRECIOS"
                    If Not Directory.Exists(RUTA_DISCOC) Then
                        Directory.CreateDirectory("C:\TRANS PDF")
                        Directory.CreateDirectory(RUTA_DISCOC)
                    End If
                Catch ex As Exception
                    RUTA_DISCOC = gRutaXML_TIMBRADO
                    BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                FILE_XML = RUTA_DISCOC & "\TEMPXML.xml"
                File.WriteAllText(FILE_XML, XML_TABLA)

                xdoc.Load(FILE_XML)

                Dim v_namespace As New XmlNamespaceManager(xdoc.NameTable)

                If VERSION = "4.0" Then
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")
                Else
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                End If
                v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
                v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")

                NO_CERTIFICADO = xdoc.SelectSingleNode("/cfdi:Comprobante//@NoCertificado", v_namespace).InnerText

                UUID = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", v_namespace).InnerText
                FECHA_TIMBRADO = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@FechaTimbrado", v_namespace).InnerText
                FECHA_EXP = xdoc.SelectSingleNode("/cfdi:Comprobante/@Fecha", v_namespace).InnerText

                IMPORTE_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/@Total", v_namespace).InnerText

                SELLO_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloSAT", v_namespace).InnerText
                NO_CERTIFICADO_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@NoCertificadoSAT", v_namespace).InnerText
                SELLO_CFD = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloCFD", v_namespace).InnerText
                RfcProvCertif = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@RfcProvCertif", v_namespace).InnerText

                Var9 = NO_CERTIFICADO
                Var10 = FECHA_TIMBRADO
                Var11 = FECHA_EXP

                Var12 = SELLO_SAT
                Var13 = NO_CERTIFICADO_SAT
                Var14 = SELLO_CFD


                Try
                    SQL = "UPDATE CFDI_COMPAGO SET SELLO_SAT = '" & SELLO_SAT & "', FECHA_TIMBRADO = '" & FECHA_TIMBRADO & "', 
                        NO_CERTIFICADO = '" & NO_CERTIFICADO & "', NO_CERTIFICADO_SAT = '" & NO_CERTIFICADO_SAT & "', 
                        SELLO_CFD = '" & SELLO_CFD & "', UUID = '" & UUID & "', RFCPROVCERTIF = '" & RfcProvCertif & "'
                        WHERE CVE_DOC = '" & FCVE_DOC & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                xdoc = Nothing
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "XML=" & XML_TABLA & "," & VERSION)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return UUID

    End Function
    Public Function EXTRAER_CFDI_PAGO_XML(FFACTURA As String) As String
        Dim XML_TABLA As String = "", FILE_XML As String, UUID As String = "", VERSION As String = ""
        Dim FECHA_TIMBRADO As String, FECHA_EXP As String

        Dim xdoc As New XmlDocument()

        Try
            SQL = "SELECT XML, ISNULL(VERSION,'4.0') AS VERSION_CFDI 
                FROM CFDI_COMPAGO WHERE CVE_DOC = '" & FFACTURA & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML_TABLA = dr.ReadNullAsEmptyString("XML")
                        VERSION = dr.ReadNullAsEmptyString("VERSION_CFDI")
                    End If
                End Using
            End Using
            If XML_TABLA.Trim.Length > 0 Then

                FILE_XML = OBTENER_RUTA_XML_TRANS_PDF() & "\TEMPXML.xml"
                File.WriteAllText(FILE_XML, XML_TABLA)

                xdoc.Load(FILE_XML)

                Dim v_namespace As New XmlNamespaceManager(xdoc.NameTable)

                If VERSION = "4.0" Then
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")
                Else
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                End If
                v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
                v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")

                UUID = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", v_namespace).InnerText
                FECHA_TIMBRADO = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@FechaTimbrado", v_namespace).InnerText
                FECHA_EXP = xdoc.SelectSingleNode("/cfdi:Comprobante/@Fecha", v_namespace).InnerText
                IMPORTE_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/@Total", v_namespace).InnerText

                Var10 = FECHA_TIMBRADO
                Var11 = FECHA_EXP

                xdoc = Nothing
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "XML=" & XML_TABLA & "," & VERSION)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return UUID

    End Function



    Public Function BUSCAR_UUID_CFDI_FACTURA(FCVE_DOC As String) As String
        Dim XML_TABLA As String = "", FILE_XML As String, UUID As String = "", VERSION As String = ""
        Dim FECHA_TIMBRADO As String, FECHA_EXP As String, SELLO_SAT As String, NO_CERTIFICADO_SAT As String
        Dim SELLO_CFD As String, NO_CERTIFICADO As String, RUTA_DISCOC As String, RfcProvCertif As String

        Dim xdoc As New XmlDocument()

        Try
            SQL = "SELECT XML, ISNULL(VERSION,'4.0') AS VERSION_CFDI 
                FROM CFDI WHERE FACTURA = '" & FCVE_DOC & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML_TABLA = dr.ReadNullAsEmptyString("XML")
                        VERSION = dr.ReadNullAsEmptyString("VERSION_CFDI")
                    End If
                End Using
            End Using
            If XML_TABLA.Trim.Length > 0 Then

                Try
                    RUTA_DISCOC = "C:\TRANS PDF\SIN PRECIOS"
                    If Not Directory.Exists(RUTA_DISCOC) Then
                        Directory.CreateDirectory("C:\TRANS PDF")
                        Directory.CreateDirectory(RUTA_DISCOC)
                    End If
                Catch ex As Exception
                    RUTA_DISCOC = gRutaXML_TIMBRADO
                    BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                FILE_XML = RUTA_DISCOC & "\TEMPXML.xml"
                File.WriteAllText(FILE_XML, XML_TABLA)

                xdoc.Load(FILE_XML)

                Dim v_namespace As New XmlNamespaceManager(xdoc.NameTable)

                If VERSION = "4.0" Then
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")
                Else
                    v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                End If
                v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
                v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")

                NO_CERTIFICADO = xdoc.SelectSingleNode("/cfdi:Comprobante//@NoCertificado", v_namespace).InnerText

                UUID = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", v_namespace).InnerText
                FECHA_TIMBRADO = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@FechaTimbrado", v_namespace).InnerText
                FECHA_EXP = xdoc.SelectSingleNode("/cfdi:Comprobante/@Fecha", v_namespace).InnerText

                IMPORTE_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/@Total", v_namespace).InnerText

                SELLO_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloSAT", v_namespace).InnerText
                NO_CERTIFICADO_SAT = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@NoCertificadoSAT", v_namespace).InnerText
                SELLO_CFD = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloCFD", v_namespace).InnerText
                RfcProvCertif = xdoc.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@RfcProvCertif", v_namespace).InnerText

                Var9 = NO_CERTIFICADO
                Var10 = FECHA_TIMBRADO
                Var11 = FECHA_EXP

                Var12 = SELLO_SAT
                Var13 = NO_CERTIFICADO_SAT
                Var14 = SELLO_CFD

                xdoc = Nothing
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "XML=" & XML_TABLA & "," & VERSION)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return UUID

    End Function

    Public Function ConvertToBase64(ByVal FSTRING As String) As String

        Dim myByte As Byte() = System.Text.Encoding.UTF8.GetBytes(FSTRING)
        Dim myBase64 As String = Convert.ToBase64String(myByte)
        Return myBase64

    End Function

    Public Function ConvertFileToBase64(ByVal fileName As String) As String
        Try
            Return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName))
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Sub REQUEST_CANC_CARTA_PORTE()
        Dim ACPCANC(12, 3) As String
        Try
            ACPCANC(1, 1) = "201"
            ACPCANC(1, 2) = "Solicitud recibida"
            ACPCANC(1, 3) = "Se ha recibido la petición de cancelación.ÊNo necesariamente significa que el Comprobante se ha cancelado."

            ACPCANC(2, 1) = "202"
            ACPCANC(2, 2) = "Solicitud recibida anteriormente"
            ACPCANC(2, 3) = "Se ha recibido la petición de cancelación anteriormente.ÊNo necesariamente significa que el Comprobante se ha cancelado."

            ACPCANC(3, 1) = "203"
            ACPCANC(3, 2) = "UUID No encontrado o no corresponde a emisor"
            ACPCANC(3, 3) = "El Folio Fiscal que se solicitó cancelar no se ha podido encontrar, o se encontró pero no fue emitido por el RFC especificado."

            ACPCANC(4, 1) = "204"
            ACPCANC(4, 2) = "UUID No aplicable para cancelación"
            ACPCANC(4, 3) = "El Folio Fiscal no se puede cancelar. El SAT no especifica bajo que criterios puede ocurrir este código, pero no es frecuente."

            ACPCANC(5, 1) = "205"
            ACPCANC(5, 2) = "UUID No existe"
            ACPCANC(5, 3) = "El SAT todavía no publica en su portal de internet el comprobante, y por lo tanto aœn no puede ser cancelado."

            ACPCANC(6, 1) = "301"
            ACPCANC(6, 2) = "XML mal formado"
            ACPCANC(6, 3) = "El XML de solicitud que se envió al SAT no est‡ correctamente formado. Sólo relevante para el mŽtodo de cancelación en línea con solicitud firmada de origen."

            ACPCANC(7, 1) = "302"
            ACPCANC(7, 2) = "Sello mal formado o inválido"
            ACPCANC(7, 3) = "El Sello que se usó para generar la solicitud de cancelación es incorrecto."

            ACPCANC(8, 1) = "303"
            ACPCANC(8, 2) = "Sello no corresponde a emisor"
            ACPCANC(8, 3) = "El certificado de sello digital (CSD) con el que se firmó la solicitud no corresponde al RFC del Emisor del CFDI."

            ACPCANC(9, 1) = "304"
            ACPCANC(9, 2) = "Sello revocado o caduco"
            ACPCANC(9, 3) = "El certificado de sello digital con el que se firmó la solicitud de cancelación ha sido revocado o no esta vigente."

            ACPCANC(10, 1) = "305"
            ACPCANC(10, 2) = "Certificado inválido"
            ACPCANC(10, 3) = "No se est‡ usando para firmar la solicitud de cancelación un certificado expedido por el SAT"

            ACPCANC(11, 1) = "310"
            ACPCANC(11, 2) = "Uso de certificado e.firma inválido"
            ACPCANC(11, 3) = "Se está usando un certificado de e.firma en vez de un Certificado de Sello Digital (CSD)"

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Function RunningAsAdmin() As Boolean
        Try
            Dim id As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim Principal As New WindowsPrincipal(id)

            Return Principal.IsInRole(WindowsBuiltInRole.Administrator)
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function GetMacAddress() As String
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim adapter As NetworkInterface
            Dim myMac As String = String.Empty

            For Each adapter In adapters
                Select Case adapter.NetworkInterfaceType
                'Exclude Tunnels, Loopbacks and PPP
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            myMac = adapter.GetPhysicalAddress.ToString
                            Exit For
                        End If

                End Select
            Next adapter

            Return myMac
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Friend Function GetVolumeSerial(Optional ByVal strDriveLetter As String = "C") As String
        Try
            Dim Disk As New ManagementObject(String.Format("win32_logicaldisk.deviceid=""{0}:""", strDriveLetter))

            Disk.Get()
            Return Disk("VolumeSerialNumber").ToString()
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function

    Friend Function GetMotherBoardID() As String
        Dim strMotherBoardID As String = String.Empty
        Try
            Dim query As New SelectQuery("Win32_BaseBoard")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject

            For Each info In search.Get()
                strMotherBoardID = info("SerialNumber").ToString()
            Next
            Return strMotherBoardID
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try

    End Function
    Public Function GET_ID() As String
        Dim NUM_ID As String
        Dim P1 As String = "", P2 As String, P3 As String, P4 As String
        Try

            P1 = CpuId()
            'Debug.Print("GetMotherBoardID:" & 
            P2 = GetMotherBoardID()
            'Debug.Print("GetMacAddress:" & 
            P3 = GetMacAddress()
            'Debug.Print("GetVolumeSerial:" & 
            P4 = GetVolumeSerial()

            If P2.Trim.Length > 0 Then
                NUM_ID = P2.Replace("/", "")
            Else
                If P4.Trim.Length > 0 Then
                    NUM_ID = P4
                Else
                    If P1.Trim.Length > 0 Then
                        NUM_ID = P1
                    Else
                        NUM_ID = P3
                    End If
                End If
            End If
            Return NUM_ID
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
            Return P1
        End Try
    End Function
    Public Function TSubTipoRemPublic(FTIPOSUBREM As String)
        Dim TSUB As String = ""
        Try
            Select Case FTIPOSUBREM
                Case "CTR001"
                    TSUB = "Caballete"
                Case "CTR002"
                    TSUB = "Caja"
                Case "CTR003"
                    TSUB = "Caja Abierta"
                Case "CTR004"
                    TSUB = "Caja Cerrada"
                Case "CTR005"
                    TSUB = "Caja De Recolección Con Cargador Frontal"
                Case "CTR006"
                    TSUB = "Caja Refrigerada"
                Case "CTR007"
                    TSUB = "Caja Seca"
                Case "CTR008"
                    TSUB = "Caja Transferencia"
                Case "CTR009"
                    TSUB = "Cama Baja o Cuello Ganso"
                Case "CTR010"
                    TSUB = "Chasis Portacontenedor"
                Case "CTR011"
                    TSUB = "Convencional De Chasis"
                Case "CTR012"
                    TSUB = "Equipo Especial"
                Case "CTR013"
                    TSUB = "Estacas"
                Case "CTR014"
                    TSUB = "Góndola Madrina"
                Case "CTR015"
                    TSUB = "Grúa Industrial"
                Case "CTR016"
                    TSUB = "Grúa "
                Case "CTR017"
                    TSUB = "Integral"
                Case "CTR018"
                    TSUB = "Jaula"
                Case "CTR019"
                    TSUB = "Media Redila"
                Case "CTR020"
                    TSUB = "Pallet o Celdillas"
                Case "CTR021"
                    TSUB = "Plataforma"
                Case "CTR022"
                    TSUB = "Plataforma Con Grúa"
                Case "CTR023"
                    TSUB = "Plataforma Encortinada"
                Case "CTR024"
                    TSUB = "Redilas"
                Case "CTR025"
                    TSUB = "Refrigerador"
                Case "CTR026"
                    TSUB = "Revolvedora"
                Case "CTR027"
                    TSUB = "Semicaja"
                Case "CTR028"
                    TSUB = "Tanque"
                Case "CTR029"
                    TSUB = "Tolva"
                Case "CTR030"
                    TSUB = "Tractor"
                Case "CTR031"
                    TSUB = "Volteo"
                Case "CTR032"
                    TSUB = "Volteo Desmontable"
                Case Else
                    MsgBox("Sub tipo 1 inexistente")
                    TSUB = ""
            End Select
        Catch ex As Exception
            Bitacora("1450. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return TSUB
    End Function

    Public Function GET_MAT_PELIGROSO(fCVE_MAT_PELIGROSO As String, Optional FMensaje As String = "") As String
        Dim CVE_MAT As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM tblcmaterialpeligroso WHERE clave = '" & fCVE_MAT_PELIGROSO & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_MAT = dr("descripcion")
                    Else
                        If FMensaje = "S" Then
                            MsgBox("Material peligroso inexistente")
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return CVE_MAT
    End Function
    Public Function GET_MAT_EMBALAJE(fEMBALAJE As String, Optional FMensaje As String = "") As String
        Dim EMBALAJE As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM tblctipoembalaje WHERE clave = '" & fEMBALAJE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        EMBALAJE = dr("descripcion")
                    Else
                        If FMensaje = "S" Then
                            MsgBox("Embalaje inexistente")
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return EMBALAJE
    End Function
    Public Function GET_CVE_FOLIO() As String
        Dim DatRegre As String = "", SQLx As String
        Dim id As String = Guid.NewGuid().ToString("N")

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                'SQLx = "SELECT ISNULL(ULT_CVE,0) + 1 AS CVE FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32"
                SQLx = "SELECT MAX(TRY_PARSE(CVE_FOLIO AS INT)) + 1 FROM MINVE" & Empresa
                cmd.CommandText = SQLx
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        DatRegre = dr(0)
                    End If
                End Using
            End Using
            Return DatRegre
        Catch ex As Exception
            Bitacora("640. " & ex.Message & vbNewLine & ex.StackTrace)
            Return id
        End Try
    End Function
    Public Function GET_CVE_FOLIO_MINVE()
        Dim CVE_FOLIO As String = "", Ano As String
        Dim id As String = Guid.NewGuid().ToString("N")
        Dim ErrFolio As Boolean = False
        Try
            CVE_FOLIO = GET_CVE_FOLIO()
            Ano = DateTime.Now.Year.ToString
            Ano = Ano.Substring(Ano.Length - 1, 1)
            CVE_FOLIO = Ano & Format(DateTime.Now.Month, "00") & Format(DateTime.Now.Day, "00") &
                    Format(DateTime.Now.Hour, "00") & Format(DateTime.Now.Minute, "00")

            If CVE_FOLIO.Length > 9 Then
                CVE_FOLIO = CVE_FOLIO.Substring(0, 9)
            ElseIf CVE_FOLIO.Trim.Length = 0 Or CVE_FOLIO.Trim.Length < 6 Then
                CVE_FOLIO = id
                If CVE_FOLIO.Length > 9 Then
                    CVE_FOLIO = CVE_FOLIO.Substring(0, 9)
                End If
            End If
        Catch ex As Exception
            ErrFolio = True
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If ErrFolio Then
            CVE_FOLIO = id
            If CVE_FOLIO.Length > 9 Then
                CVE_FOLIO = CVE_FOLIO.Substring(0, 9)
            End If
        End If

        Return CVE_FOLIO
    End Function

    'Function to set a printer as default
    Public Function SetDefaulPrinter(ByVal strPrinterName As String) As Boolean
        Dim strCurrPrinter As String
        Dim WsNetwork As Object
        Dim prntDoc As New PrintDocument

        strCurrPrinter = prntDoc.PrinterSettings.PrinterName
        WsNetwork = Microsoft.VisualBasic.CreateObject("WScript.Network")

        Try
            WsNetwork.SetDefaultPrinter(strPrinterName)
            prntDoc.PrinterSettings.PrinterName = strPrinterName

            'set default if selected printer name is a valid installed printer
            If prntDoc.PrinterSettings.IsValid Then
                Return True
            Else
                WsNetwork.SetDefaultPrinter(strCurrPrinter)
                Return False
            End If
        Catch ex As Exception
            WsNetwork.SetDefaultPrinter(strCurrPrinter)
            Return False
        Finally
            WsNetwork = Nothing
            prntDoc = Nothing
        End Try
    End Function
    Public Function MensajeBox(MsgMain As String, MsgFin As String, msgError As String) As String
        Dim Result As String = ""
        Try
            Dim msg As Object

            msg = New VtlMessageBox(C1.Win.C1Ribbon.VisualStyle.Office2010Blue)
            With msg
                '.AddImageToMoreText("gridImage", img)
                .MessageText = MsgMain
                .AddStandardButtons(MessageBoxButtons.OK)
                .Caption = MsgFin
                Select Case msgError
                    Case "Error"
                        .Icon = MessageBoxIcon.Error
                    Case "Exclamation"
                        .Icon = MessageBoxIcon.Exclamation
                    Case "Information"
                        .Icon = MessageBoxIcon.Information
                    Case "Question"
                        .Icon = MessageBoxIcon.Question
                    Case "Stop"
                        .Icon = MessageBoxIcon.Stop
                    Case "Warning"
                        .Icon = MessageBoxIcon.Warning
                    Case Else
                        .Icon = MessageBoxIcon.Information
                End Select

                .MessageBoxPosition = FormStartPosition.CenterScreen
                Result = .Show()
            End With
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return Result
    End Function
    Public Sub AJUSTA_COLUMNAS_FG(FFG As C1FlexGrid, FCOL As Integer, Optional NCOLS As Integer = 1)
        Dim Ancho As Integer, Ancho2 As Integer, SumaPorcen As Decimal = 0
        Try

            Ancho = Screen.PrimaryScreen.Bounds.Width - FFG.Cols(0).Width - 20
            Ancho2 = 0
            For k = 1 To FFG.Cols.Count - NCOLS
                Ancho2 += FFG.Cols(k).Width
            Next
            Dim FgPorcen1 As Decimal, SumP As Integer = 0

            For k = 1 To FFG.Cols.Count - NCOLS

                FgPorcen1 = TruncateDec(((FFG.Cols(k).Width / Ancho2) * 100), 1)

                Debug.Print(FgPorcen1)
                SumaPorcen += FgPorcen1

                FFG.Cols(k).Width = Int((Ancho * FgPorcen1) / 100)
                SumP += FFG.Cols(k).Width
            Next

            If FCOL > 0 Then
                'FFG.Cols(FCOL).Width = FFG.Cols(FCOL).Width + (Ancho - SumP - FFG.Cols(0).Width)
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub AJUSTA_COLUMNAS_FG2(FME As Form, FFG As C1FlexGrid, FCOL As Integer, Optional NCOLS As Integer = 1)
        Dim Ancho As Integer, Ancho2 As Integer
        Try

            If FME.Width = 0 Then
                Ancho = Screen.PrimaryScreen.Bounds.Width - FFG.Cols(0).Width - 20
            Else
                Ancho = FME.Width - FFG.Cols(0).Width - 30
            End If

            Ancho2 = 0
            For k = 1 To FFG.Cols.Count - NCOLS
                Ancho2 += FFG.Cols(k).Width
            Next
            Dim FgPorcen1 As Integer, SumP As Integer = 0

            For k = 1 To FFG.Cols.Count - NCOLS

                FgPorcen1 = ((FFG.Cols(k).Width / Ancho2) * 100)
                Debug.Print(FgPorcen1)

                FFG.Cols(k).Width = Int((Ancho * FgPorcen1) / 100)
                SumP += FFG.Cols(k).Width
            Next

            FME.Width = SumP - FFG.Cols(0).Width - 30

            If FCOL > 0 Then
                'FFG.Cols(FCOL).Width = FFG.Cols(FCOL).Width + (Ancho - SumP - FFG.Cols(0).Width)
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub AJUSTA_COLUMNAS_FG3(FME As Form, FFG As C1FlexGrid, FCOL As Integer, Optional NCOLS As Integer = 1)
        Dim Ancho As Integer, Ancho2 As Integer = 0
        Dim FgPorcen1 As Integer, SumP As Integer = 0
        Try
            If FME.Width = 0 Then
                Ancho = Screen.PrimaryScreen.Bounds.Width - FFG.Cols(0).Width - 20
            Else
                Ancho = FME.Width - FFG.Cols(0).Width - 30
            End If
            For k = 1 To FFG.Cols.Count - NCOLS
                Ancho2 += FFG.Cols(k).Width
            Next

            For k = 1 To FFG.Cols.Count - NCOLS

                FgPorcen1 = ((FFG.Cols(k).Width / Ancho2) * 100)
                Debug.Print(FgPorcen1)

                FFG.Cols(k).Width = Int((Ancho * FgPorcen1) / 100)
                SumP += FFG.Cols(k).Width
            Next

            FME.Width = SumP + FFG.Cols(0).Width + 20

        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub AJUSTA_COLUMNAS_FG4(FME As Form, FFG As C1FlexGrid, FCOL As Integer, Optional NCOLS As Integer = 1)
        Dim Ancho As Integer, Ancho2 As Integer
        Try

            If FME.Width = 0 Then
                Ancho = Screen.PrimaryScreen.Bounds.Width - FFG.Cols(0).Width - 20
            Else
                Ancho = FME.Width - FFG.Cols(0).Width - 30
            End If

            Ancho2 = 0
            For k = 0 To FFG.Cols.Count - NCOLS
                Ancho2 += FFG.Cols(k).Width
            Next
            Dim FgPorcen1 As Integer, SumP As Integer = 0

            For k = 1 To FFG.Cols.Count - NCOLS

                FgPorcen1 = ((FFG.Cols(k).Width / Ancho2) * 100)
                Debug.Print(FgPorcen1)

                FFG.Cols(k).Width = Int((Ancho * FgPorcen1) / 100)
                SumP += FFG.Cols(k).Width
            Next

            'FME.Width = SumP + FFG.Cols(0).Width + 40
            FFG.Width = FME.Width - FFG.Cols(0).Width - 30

            If FCOL > 0 Then
                'FFG.Cols(FCOL).Width = FFG.Cols(FCOL).Width + (Ancho - SumP - FFG.Cols(0).Width)
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub ProcessControls(ByVal ctrlContainer As Control)
        For Each ctrl As Control In ctrlContainer.Controls
            If TypeOf ctrl Is Label Then
                ' Do whatever to the TextBox
                ctrl.BackColor = Color.Transparent
            End If

            ' If the control has children,
            ' recursively call this function
            If ctrl.HasChildren Then
                ProcessControls(ctrl)
            End If
        Next
    End Sub
    Public Sub FGNUMERS(FFG As C1FlexGrid)
        If PASS_GRUPOCE = "BUS" Then
            Try
                For k = 1 To FFG.Cols.Count - 1
                    FFG(0, k) = k & "." & FFG(0, k)
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Function VERIFICAR_CAMPO_GRABADO(FTABLA As String, FCAMPO1 As String, FWHERE As String)
        Dim CAMPO_TABLA As String = "", ResultVerifi As Boolean = False

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT " & FCAMPO1 & " FROM " & FTABLA & FWHERE
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CAMPO_TABLA = dr(0)
                    End If
                End Using
            End Using
            If CAMPO_TABLA.Trim.Length > 0 Then
                ResultVerifi = True
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return ResultVerifi
    End Function

    Public Function QUITAR_IMPUESTO_BUENO(FCVE_ESQIMPU As Integer, FPREC As Decimal) As Decimal
        Dim PREC As Decimal = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4
                    FROM IMPU" & Empresa & " P 
                    WHERE CVE_ESQIMPU = " & FCVE_ESQIMPU
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        PREC = FPREC / (1 + (dr("IMPUESTO2") / 100) + (dr("IMPUESTO3") / 100) + (dr("IMPUESTO4") / 100))

                    Else
                        PREC = FPREC
                    End If
                End Using
            End Using
        Catch ex As Exception
            PREC = FPREC
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return PREC

    End Function

    Public Function QUITAR_IMPUESTO(FCVE_ART As String, FPREC As Decimal) As Decimal
        Dim PREC As Decimal = 0, IVA As Decimal, IEPS As Decimal
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4
                    FROM INVE" & Empresa & " I 
                    LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                    WHERE CVE_ART = '" & FCVE_ART & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        If dr("IMPUESTO1") = 0 And dr("IMPUESTO4") = 0 Then
                            PREC = FPREC
                        ElseIf dr("IMPUESTO1") > 0 And dr("IMPUESTO4") = 0 Then
                            PREC = FPREC / (1 + (dr("IMPUESTO1") / 100))
                        ElseIf dr("IMPUESTO1") = 0 And dr("IMPUESTO4") > 0 Then
                            PREC = FPREC / (1 + (dr("IMPUESTO4") / 100))
                        Else
                            IVA = FPREC / (1 + (dr("IMPUESTO4") / 100))
                            IEPS = (1 + (dr("IMPUESTO1") / 100))
                            PREC = (FPREC - IVA) / IEPS
                        End If
                    Else
                        PREC = FPREC
                    End If
                End Using
            End Using
        Catch ex As Exception
            PREC = FPREC
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return PREC

    End Function

    Public Function OBTENER_REGIMEN_FISCAL_XML(FREG_FISC) As String
        Dim Moral As String, Fisica As String, Descr As String = "", Regimen As String = ""

        Try

            If FREG_FISC.Trim.Length > 0 Then
                Dim doc As New XmlDocument()
                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_REGIMENFISCAL40.xml")
                Dim child_nodes As XmlNodeList = doc.GetElementsByTagName("row")
                Dim Existe As Boolean = False


                For Each child As XmlNode In child_nodes
                    Moral = child.Attributes("Moral").InnerXml '& " = " & child.InnerText & vbCrLf
                    Fisica = child.Attributes("Fisica").InnerXml
                    Descr = child.Attributes("Descripcion").InnerXml
                    Regimen = child.Attributes("c_RegimenFiscal").InnerXml

                    If Regimen = FREG_FISC Then
                        Existe = True
                        Exit For
                    End If
                Next child
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return Descr
    End Function

    Public Sub EXPORTAR_EXCEL_TRANSPORT(FFG As C1FlexGrid, FNOMBRE_EXCEL As String, Optional ByVal SoloColumnasVisibles As Boolean = False)
        Try
            Try
                If Not Directory.Exists(RUTA_EXCEL) Then
                    Directory.CreateDirectory(RUTA_EXCEL)
                End If
            Catch ex As Exception
                RUTA_EXCEL = Application.StartupPath
            End Try

            If EXPORTAR_COMO_CSV = 0 Then
                If SoloColumnasVisibles Then
                    FFG.SaveExcel(RUTA_EXCEL & "\" & FNOMBRE_EXCEL & ".xls", FileFlags.VisibleOnly)
                Else
                    FFG.SaveExcel(RUTA_EXCEL & "\" & FNOMBRE_EXCEL & ".xls", FileFlags.IncludeFixedCells)


                End If

                Process.Start(RUTA_EXCEL & "\" & FNOMBRE_EXCEL & ".xls")
            Else
                FFG.SaveGrid(RUTA_EXCEL & "\" & FNOMBRE_EXCEL & ".csv", FileFormatEnum.TextComma, IIf(SoloColumnasVisibles, FileFlags.VisibleOnly, FileFlags.AsDisplayed Or FileFlags.IncludeFixedCells))
                Process.Start(RUTA_EXCEL & "\" & FNOMBRE_EXCEL & ".csv")
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_EXCEL & "\" & FNOMBRE_EXCEL & ".xls")
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_EXCEL & "\" & FNOMBRE_EXCEL & ".xls")
        End Try
    End Sub

    Public Sub Copia_Portapapeles_Grid(Flgd As C1FlexGrid, Rango As CellRange)
        Dim StrCopy As String = ""

        If Flgd.Rows.Count < Rango.r2 Or Flgd.Cols.Count < Rango.c2 Then Return

        For i = Rango.r1 To Rango.r2
            If Flgd.Rows(i).Visible = True Then
                For j = Rango.c1 To Rango.c2

                    If Flgd.Cols(j).Visible = True Then
                        StrCopy = StrCopy & Flgd(i, j).ToString()

                        If j <> Rango.c2 Then
                            StrCopy = StrCopy & vbTab
                        End If
                    End If
                Next

                StrCopy = StrCopy & vbLf
            End If
        Next

        Clipboard.SetDataObject(StrCopy)
    End Sub

    Public Sub VisualizaReporte(ByVal Reporte As StiReport)
        Dim frm As New FrmImpresionReportes(Reporte)
        frm.Show()
    End Sub

    Public Sub VisualizaReporteGrid(ByVal FGrid As C1FlexGrid, ByVal docName As String, ByVal flags As PrintGridFlags, ByVal header As String, ByVal footer As String)
        FGrid.PrintGrid(docName, flags, header, footer)
    End Sub

    Public Sub RestauraSearchFG(ByRef FGrid As C1FlexGrid)
        Dim search As String
        search = FGrid.SearchDefinition
        FGrid.SearchDefinition = ""
        FGrid.SearchDefinition = search
    End Sub
    Public Function GET_ETIQUETA(FIDTABLA As String, FCAMPO As String) As String
        Dim ETIQUETA As String = ""
        SQL = "SELECT ETIQUETA FROM PARAM_CAMPOSLIBRES" & Empresa & " 
                WHERE IDTABLA = '" & FIDTABLA & "' AND CAMPO = '" & FCAMPO & "'"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        ETIQUETA = dr("ETIQUETA")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return ETIQUETA
    End Function

    Public Sub GEN_IMPRIMIR_TICKET(FTIPO_DOC As String, FSERIE As String, FCVE_DOC As String, FPROC As String,
                                   FIMPORTE As Decimal, Optional NUM_LETRA As String = "", Optional FCOPIAS_TK_NV As Integer = 1)
        Dim report As New StiReport()
        Dim RUTA_FORMATOS As String, j As Integer = 0, IMPRESORA As String = ""
        Try
            Dim Settings As New PrinterSettings()
            REPORTE_POS = ""

            Try
                SQL = "SELECT FTOEMISION, IMPRESORA 
                    FROM PARAM_FOLIOSF" & Empresa & " 
                    WHERE TIPODOCTO = '" & FTIPO_DOC & "' AND (SERIE = '" & FSERIE & "' OR SERIE = 'STAND.')"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            REPORTE_POS = Path.GetFileName(dr.ReadNullAsEmptyString("FTOEMISION"))
                            IMPRESORA = Path.GetFileName(dr.ReadNullAsEmptyString("IMPRESORA"))
                        End If
                    End Using
                End Using

            Catch ex As Exception
                Bitacora("2040. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2040. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If IMPRESORA.Trim.Length = 0 Then
                Settings.Copies = FCOPIAS_TK_NV
                IMPRESORA = Settings.PrinterName
            End If

            If REPORTE_POS.Trim.Length = 0 Then
                REPORTE_POS = "TicketEstandard.mrt"
            End If

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\" & REPORTE_POS
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            report.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            report.Dictionary.Databases.Clear()
            report.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            report.Compile()
            report.Dictionary.Synchronize()
            report.ReportName = FPROC

            If FTIPO_DOC = "A" Then
                report.Item("REFER") = FCVE_DOC
                report.Item("NUM_LETRA") = Num2Text(FIMPORTE)
            Else
                If REPORTE_POS = "TicketEstandard.mrt" Then
                    report.Item("CVE_DOC") = FCVE_DOC
                    report.Item("E") = Empresa
                    report.Item("TE") = FTIPO_DOC & Empresa
                Else
                    report("CVE_DOC") = FCVE_DOC
                End If
            End If

            report.Render()
            If PRINTDIRECTPV = 1 Then

                Dim printerSettings As New PrinterSettings With {.PrinterName = IMPRESORA, .Copies = FCOPIAS_TK_NV}
                report.Print(False, printerSettings)

            Else
                report.Show()
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Function EL_PAGO_ESTA_TIMBRADO(FCVE_DOC As String) As Boolean
        Dim EXISTE As Boolean = False

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI WHERE FACTURA = '" & FCVE_DOC & "' AND ISNULL(ESTATUS,'') <> 'C'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        EXISTE = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return EXISTE
    End Function

    Public Function ObtenerNombrePestanaConsulta(ByVal NombreMenu As String) As String
        Dim nombre As String = ""

        Select Case (NombreMenu)
            Case "BarContResFacturas"
                nombre = "Resumen Facturas"
            Case "BarContResLiq"
                nombre = "Resumen Liquidaciones"
            Case "BarContResLiqConceptos"
                nombre = "Resumen Liquidaciones Conceptos"
            Case "BarContResFacturasAbono"
                nombre = "Resumen Facturas Abonos"
        End Select
        Return nombre
    End Function
End Module

