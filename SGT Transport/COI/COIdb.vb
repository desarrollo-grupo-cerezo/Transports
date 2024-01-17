Imports System.Data.SqlClient
Imports C1.C1Rdl.Rdl2008
Imports FirebirdSql.Data.FirebirdClient

Public Class COIdb

    Private _cnnFBD As FbConnection
    Private _csFRB As FbConnectionStringBuilder
    Private _enunDB As EnmDataBase
    Private _Server As String
    Private _DB As String
    Private _User As String
    Private _Password As String

    Public Enum EnmDataBase
        FireBird
        SQLserver
    End Enum

    Public Sub New()

        _cnnFBD = New FbConnection
        _csFRB = New FbConnectionStringBuilder

        Try
            If Not Valida_Conexion() Then
                Throw New System.Exception("No se pudo establecer conexión con la base de datos del sistema")
            End If

            SQL = String.Format("SELECT * FROM GCParamConexionCOI")
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        _enunDB = Convert.ToInt32(dr("ConexionDB").ToString())
                        _Server = dr("Server").ToString()
                        _DB = dr("DB").ToString()
                        _User = dr("User").ToString()

                        If dr.ReadNullAsEmptyString("Password").ToString.Trim.Length > 0 Then
                            _Password = Desencriptar(dr.ReadNullAsEmptyString("Password"))
                        Else
                            _Password = ""
                        End If

                        If _DB = String.Empty Or _User = String.Empty Or _Password = String.Empty Then
                            Throw New System.Exception("Faltan datos de conexión")
                        End If
                    Else
                        Throw New System.Exception("Datos de conexión no configurados")
                    End If
                End Using
            End Using

            If _enunDB = EnmDataBase.FireBird Then
                _csFRB.ServerType = FbServerType.Default
                _csFRB.UserID = _User
                _csFRB.Password = _Password
                _csFRB.Dialect = 3
                _csFRB.Database = _DB
                _csFRB.Pooling = False
            End If

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Throw New System.Exception("Error de conexión con la DB de COI" & vbNewLine & ex.Message)
        End Try

    End Sub

    Public Function ValidaConexion() As Boolean
        If _enunDB = EnmDataBase.FireBird Then
            Return ValidaConexionFBD()
        End If

        Return False
    End Function

    Public Function GeneraPoliza(ByRef lstPolizas As List(Of Poliza), ByVal lstCuentas As List(Of CuentaContable)) As Boolean
        If _enunDB = EnmDataBase.FireBird Then
            Return GeneraPolizaFBD(lstPolizas, lstCuentas)
        End If

        Return False
    End Function

    Public Function ValidaCuentas(ByRef lstCuentas As List(Of CuentaContable)) As Boolean
        If _enunDB = EnmDataBase.FireBird Then
            Return ValidaCuentasFBD(lstCuentas)
        End If

        Return False
    End Function


    Public Function ValidaConexionFBD() As Boolean
        Try
            _cnnFBD.ConnectionString = _csFRB.ToString
            _cnnFBD.Open()

            Dim cmd As New FbCommand("SELECT FIRST 1 EJERCICIO FROM FOLIOS", _cnnFBD)
            Dim fbdatareader As FbDataReader = cmd.ExecuteReader
            Dim id As String

            If fbdatareader.Read Then
                id = fbdatareader.GetString(0)
            End If

            _cnnFBD.Close()
            Return True

        Catch ex As FbException
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try

    End Function

    Public Function ValidaCuentasFBD(ByRef lstCuentas As List(Of CuentaContable)) As Boolean
        Try
            Dim sql As String
            Dim cmd As New FbCommand()
            Dim ejer As String

            _cnnFBD.ConnectionString = _csFRB.ToString
            _cnnFBD.Open()
            cmd.Connection = _cnnFBD

            For Each cta As CuentaContable In lstCuentas
                cta.NumCuentaAsignada = ""
                cta.Coincidencias = 0

                ejer = (cta.Ejercicio - 2000).ToString()
                sql = "SELECT NUM_CTA FROM CUENTAS" & ejer & " WHERE NUM_CTA LIKE '" & cta.NumCuenta.Replace("-", "") & "%'"
                cmd.CommandText = sql
                Using FbDataReader As FbDataReader = cmd.ExecuteReader

                    While FbDataReader.Read
                        cta.NumCuentaAsignada = FbDataReader.GetString(0)
                        cta.Coincidencias = cta.Coincidencias + 1
                    End While

                End Using
            Next

            _cnnFBD.Close()

            If lstCuentas.Where(Function(x) x.NumCuentaAsignada = "").Any() Then
                Return False
            End If

            If lstCuentas.Where(Function(x) x.Coincidencias > 1).Any() Then
                Return False
            End If

            Return True

        Catch ex As FbException
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try

    End Function


    Public Function GeneraPolizaFBD(ByRef lstPolizas As List(Of Poliza), lstCuentas As List(Of CuentaContable)) As Boolean
        Try

            If lstPolizas.Count = 0 Then Return False

            Using _cnnFBD = New FbConnection(_csFRB.ToString)
                _cnnFBD.Open()
                Using trn As FbTransaction = _cnnFBD.BeginTransaction
                    Using cmd As FbCommand = New FbCommand

                        cmd.Connection = _cnnFBD
                        cmd.Transaction = trn
                        Using cnGC = New SqlConnection(cnSAE.ConnectionString)
                            cnGC.Open()

                            Using trnGC As SqlTransaction = cnGC.BeginTransaction

                                For Each poliza As Poliza In lstPolizas

                                    If Not AsignaNumPolizaFBD(poliza, trn, lstCuentas) Then
                                        Throw New System.Exception("AsignaNumPoliza = False")
                                    End If

                                    If Not RegistraPolizaFBD(poliza, trn) Then
                                        Throw New System.Exception("RegistraPolizaFBD = False")
                                    End If

                                    If Not GrabaPolizaFBD(poliza, trn) Then
                                        Throw New System.Exception("GrabaPoliza = False")
                                    End If

                                    If Not GrabaAuxiliaresFBD(poliza, trn) Then
                                        Throw New System.Exception("GrabaAuxiliares = False")
                                    End If

                                    If Not ActualizaDocumentos(poliza, trnGC) Then
                                        Throw New System.Exception("ActualizaDocumentos = False")
                                    End If
                                Next

                                trnGC.Commit()
                                trn.Commit()
                            End Using
                        End Using
                    End Using
                End Using
            End Using

            Return True

        Catch ex As Exception
            Bitacora("560. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Return False
        End Try

    End Function

    Private Function AsignaNumPolizaFBD(ByRef poliza As Poliza, ByRef trn As FbTransaction, lstCuentas As List(Of CuentaContable)) As Boolean
        Dim Folio As Long = 0
        Dim NumPoliza As String
        Dim cmd As New FbCommand

        cmd.Connection = trn.Connection
        cmd.Transaction = trn
        cmd.CommandText = "SELECT FOLIO" & Format(poliza.Periodo, "00") & " FROM FOLIOS WHERE TIPPOL = '" & poliza.TipoPoliza & "' AND EJERCICIO = " & poliza.Ejercicio
        Dim dr As FbDataReader = cmd.ExecuteReader
        Folio = "     1"
        If (dr.Read) Then
            If IsNumeric(dr(0).ToString.Trim) Then
                Folio = dr(0)
            End If
        End If

        If Folio = 0 Then
            NumPoliza = "    1"
        Else
            Folio = Folio + 1
            NumPoliza = Space(5 - Folio.ToString().Trim().Length()) & Folio.ToString().Trim()
        End If
        poliza.NumPoliza = NumPoliza
        poliza.Auxiliares.ForEach(Sub(a) a.NumPoliza = NumPoliza)
        poliza.Auxiliares.ForEach(Sub(a) a.NumCuentaCOI = lstCuentas.FirstOrDefault(Function(x) x.Ejercicio = a.FechaPoliza.Year And x.NumCuenta = a.NumCuenta).NumCuentaAsignada)

        cmd.CommandText = "SELECT COALESCE(MAX(TRANSACCIO),0) + 1 FROM REGPOL"
        Dim dr2 As FbDataReader = cmd.ExecuteReader

        If (dr2.Read) Then
            If IsNumeric(dr2(0).ToString.Trim) Then
                poliza.RegistroPoliza.Transaccion = dr2(0)
            End If
        End If

        poliza.RegistroPoliza.TipoPoliza = poliza.TipoPoliza
        poliza.RegistroPoliza.NumPoliza = NumPoliza
        poliza.RegistroPoliza.FechaPoliza = poliza.FechaPoliza
        poliza.RegistroPoliza.FechaOPR = poliza.FechaPoliza
        poliza.RegistroPoliza.Sistema = "            SGT"
        poliza.RegistroPoliza.NumUsr = 0
        poliza.RegistroPoliza.Operacion = 1
        poliza.RegistroPoliza.Status = 1
        poliza.RegistroPoliza.TipoPolizaNTR = "?"
        poliza.RegistroPoliza.PolizaModelo = ""
        poliza.RegistroPoliza.REGCONCLI = 0
        poliza.RegistroPoliza.StatusCli = "?"

        Return True

    End Function

    Private Function RegistraPolizaFBD(ByRef poliza As Poliza, ByRef trn As FbTransaction) As Boolean
        Dim sql As String
        Dim returnValue As String

        sql = "INSERT INTO REGPOL (TRANSACCIO, TIPOPOL, NUMPOL, FECHAPOL, FECHAOPR, SISTEMA, NUMUSR, OPERACION, STATUS, TIPPOLINTR, POLMODELO,
                                REGCONCLI, STATUSCLI) VALUES (@TRANSACCIO, @TIPOPOL, @NUMPOL, @FECHAPOL, @FECHAOPR, @SISTEMA, @NUMUSR, @OPERACION, @STATUS, @TIPPOLINTR, 
                                @POLMODELO, @REGCONCLI, @STATUSCLI)"
        Using cmd As New FbCommand
            cmd.Connection = trn.Connection
            cmd.Transaction = trn
            cmd.CommandText = sql
            cmd.Parameters.Add("@TRANSACCIO", poliza.RegistroPoliza.Transaccion)
            cmd.Parameters.Add("@TIPOPOL", poliza.RegistroPoliza.TipoPoliza)
            cmd.Parameters.Add("@NUMPOL", poliza.RegistroPoliza.NumPoliza)
            cmd.Parameters.Add("@FECHAPOL", poliza.RegistroPoliza.FechaPoliza)
            cmd.Parameters.Add("@FECHAOPR", poliza.RegistroPoliza.FechaOPR)
            cmd.Parameters.Add("@SISTEMA", poliza.RegistroPoliza.Sistema)
            cmd.Parameters.Add("@NUMUSR", poliza.RegistroPoliza.NumUsr)
            cmd.Parameters.Add("@OPERACION", poliza.RegistroPoliza.Operacion)
            cmd.Parameters.Add("@STATUS", poliza.RegistroPoliza.Status)
            cmd.Parameters.Add("@TIPPOLINTR", poliza.RegistroPoliza.TipoPolizaNTR)
            cmd.Parameters.Add("@POLMODELO", poliza.RegistroPoliza.PolizaModelo)
            cmd.Parameters.Add("@REGCONCLI", poliza.RegistroPoliza.REGCONCLI)
            cmd.Parameters.Add("@STATUSCLI", poliza.RegistroPoliza.StatusCli)

            returnValue = cmd.ExecuteNonQuery().ToString()

            If Not returnValue Is Nothing Then
                If returnValue <> "1" Then
                    Return False
                End If
            Else
                Return False
            End If

        End Using

        Return True
    End Function

    Private Function GrabaPolizaFBD(ByRef poliza As Poliza, ByRef trn As FbTransaction) As Boolean
        Dim sql As String
        Dim i As Integer
        Dim returnValue As String
        Dim ejer As String
        ejer = (poliza.Ejercicio - 2000).ToString()

        sql = "INSERT INTO POLIZAS" & ejer & " (TIPO_POLI, NUM_POLIZ, PERIODO, EJERCICIO, FECHA_POL, CONCEP_PO, NUM_PART, LOGAUDITA, 
            CONTABILIZ, NUMPARCUA, TIENEDOCUMENTOS, PROCCONTAB, ORIGEN, UUID, ESPOLIZAPRIVADA) VALUES (@TIPO_POLI, @NUM_POLIZ, @PERIODO, 
            @EJERCICIO, @FECHA_POL, @CONCEP_PO, @NUM_PART, @LOGAUDITA, @CONTABILIZ, @NUMPARCUA, @TIENEDOCUMENTOS, @PROCCONTAB, 
            @ORIGEN, @UUID, @ESPOLIZAPRIVADA)"
        Using cmd As New FbCommand
            cmd.Connection = trn.Connection
            cmd.Transaction = trn
            cmd.CommandText = sql
            cmd.Parameters.Add("@TIPO_POLI", poliza.TipoPoliza)
            cmd.Parameters.Add("@NUM_POLIZ", poliza.NumPoliza)
            cmd.Parameters.Add("@PERIODO", poliza.Periodo)
            cmd.Parameters.Add("@EJERCICIO", poliza.Ejercicio)
            cmd.Parameters.Add("@FECHA_POL", poliza.FechaPoliza)
            cmd.Parameters.Add("@CONCEP_PO", poliza.ConceptoPoliza)
            cmd.Parameters.Add("@NUM_PART", poliza.NumPartida)
            cmd.Parameters.Add("@LOGAUDITA", poliza.LogAudita)
            cmd.Parameters.Add("@CONTABILIZ", poliza.Contabiliza)
            cmd.Parameters.Add("@NUMPARCUA", poliza.NumParCua)
            cmd.Parameters.Add("@TIENEDOCUMENTOS", poliza.TieneDocumentos)
            cmd.Parameters.Add("@PROCCONTAB", poliza.PROCCONTAB)
            cmd.Parameters.Add("@ORIGEN", poliza.Origen)
            cmd.Parameters.Add("@UUID", poliza.UUID)
            cmd.Parameters.Add("@ESPOLIZAPRIVADA", poliza.EsPolizaPrivada)

            returnValue = cmd.ExecuteNonQuery().ToString()

            If Not returnValue Is Nothing Then
                If returnValue <> "1" Then
                    Return False
                End If
            Else
                Return False
            End If


            Using cmd2 As New FbCommand
                cmd2.Connection = trn.Connection
                cmd2.Transaction = trn
                cmd2.CommandText = "UPDATE FOLIOS SET FOLIO" & Format(poliza.Periodo, "00") & " = '" & poliza.NumPoliza.Trim() & "' WHERE TIPPOL = '" & poliza.TipoPoliza & "' AND EJERCICIO = " & poliza.Ejercicio

                returnValue = cmd2.ExecuteNonQuery().ToString
                If Not returnValue Is Nothing Then
                    If returnValue <> "1" Then
                        Return False
                    End If
                Else
                    Return False
                End If

                If poliza.TipoDocumentoPoliza = EnmTipoDocumentoPoliza.VentasFletes Then
                    cmd2.CommandText = "UPDATE CONTROL SET CTREGPOL = CTREGPOL + 1, CTUUIDCOMP = CTUUIDCOMP + 1"
                End If
                If poliza.TipoDocumentoPoliza = EnmTipoDocumentoPoliza.Liquidacion Then
                    cmd2.CommandText = "UPDATE CONTROL SET CTREGPOL = CTREGPOL + 1"
                End If
                returnValue = cmd2.ExecuteNonQuery().ToString
                If Not returnValue Is Nothing Then
                    If returnValue <> "1" Then
                        Return False
                    End If
                Else
                    Return False
                End If

            End Using

        End Using



        Return True
    End Function

    Private Function GrabaAuxiliaresFBD(ByRef poliza As Poliza, ByRef trn As FbTransaction) As Boolean
        Dim sql As String
        Dim i As Integer
        Dim returnValue As String
        Dim ejer As String
        ejer = (poliza.Ejercicio - 2000).ToString()

        For Each auxiliar As Auxiliar In poliza.Auxiliares

            If Not GrabaUuidFBD(auxiliar, trn) Then
                Return False
            End If

            sql = "INSERT INTO AUXILIAR" & ejer & " (TIPO_POLI, NUM_POLIZ, NUM_PART, PERIODO, EJERCICIO, NUM_CTA, FECHA_POL, 
                CONCEP_PO, DEBE_HABER, MONTOMOV, NUMDEPTO, TIPCAMBIO, CONTRAPAR, ORDEN, CCOSTOS, CGRUPOS, IDINFADIPAR, IDUUID) 
                VALUES (@TIPO_POLI, @NUM_POLIZ, @NUM_PART, @PERIODO, @EJERCICIO, @NUM_CTA, @FECHA_POL, @CONCEP_PO, @DEBE_HABER, 
                @MONTOMOV, @NUMDEPTO, @TIPCAMBIO, @CONTRAPAR, @ORDEN, @CCOSTOS, @CGRUPOS, @IDINFADIPAR, @IDUUID)"


            Using cmd As New FbCommand
                cmd.Connection = trn.Connection
                cmd.Transaction = trn
                cmd.CommandText = sql
                cmd.Parameters.Add("@TIPO_POLI", auxiliar.TipoPoliza)
                cmd.Parameters.Add("@NUM_POLIZ", auxiliar.NumPoliza)
                cmd.Parameters.Add("@NUM_PART", auxiliar.NumPartida)
                cmd.Parameters.Add("@PERIODO", auxiliar.Periodo)
                cmd.Parameters.Add("@EJERCICIO", auxiliar.Ejercicio)
                cmd.Parameters.Add("@NUM_CTA", auxiliar.NumCuentaCOI)
                cmd.Parameters.Add("@FECHA_POL", auxiliar.FechaPoliza)
                cmd.Parameters.Add("@CONCEP_PO", auxiliar.ConceptoPoliza)
                cmd.Parameters.Add("@DEBE_HABER", auxiliar.DebeHaber)
                cmd.Parameters.Add("@MONTOMOV", auxiliar.MontoMovimiento)
                cmd.Parameters.Add("@NUMDEPTO", auxiliar.NumDepartamento)
                cmd.Parameters.Add("@TIPCAMBIO", auxiliar.TipoCambio)
                cmd.Parameters.Add("@CONTRAPAR", auxiliar.ContraPartida)
                cmd.Parameters.Add("@ORDEN", auxiliar.Orden)
                cmd.Parameters.Add("@CCOSTOS", auxiliar.CCostos)
                cmd.Parameters.Add("@CGRUPOS", auxiliar.CGupos)
                cmd.Parameters.Add("@IDINFADIPAR", auxiliar.IDINFADIPAR)
                cmd.Parameters.Add("@IDUUID", auxiliar.UUID.NumReg)
                returnValue = cmd.ExecuteNonQuery().ToString()

                If Not returnValue Is Nothing Then
                    If returnValue <> "1" Then
                        Return False
                    End If
                Else
                    Return False
                End If

                If auxiliar.DebeHaber = "D" Then

                    sql = "UPDATE SALDOS" & ejer & " SET " & "CARGO" & Format(auxiliar.Periodo, "00") & " = CARGO" & Format(auxiliar.Periodo, "00") & " + " & auxiliar.MontoMovimiento & " WHERE " &
                                    "NUM_CTA = '" & auxiliar.NumCuentaCOI & "' AND EJERCICIO = " & auxiliar.Ejercicio
                Else
                    sql = "UPDATE SALDOS" & ejer & " SET " & "ABONO" & Format(auxiliar.Periodo, "00") & " = ABONO" & Format(auxiliar.Periodo, "00") & " + " & auxiliar.MontoMovimiento & " WHERE " &
                                    "NUM_CTA = '" & auxiliar.NumCuentaCOI & "' AND EJERCICIO = " & auxiliar.Ejercicio
                End If

                Using cmd2 As New FbCommand
                    cmd2.Connection = trn.Connection
                    cmd2.Transaction = trn
                    cmd2.CommandText = sql

                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If Not returnValue Is Nothing Then
                        If returnValue <> "1" Then
                            Return False
                        End If
                    Else
                        Return False
                    End If
                End Using

            End Using



        Next

        Return True
    End Function

    Private Function GrabaUuidFBD(ByRef auxiliar As Auxiliar, ByRef trn As FbTransaction) As Boolean
        Dim sql As String
        Dim returnValue As String
        Dim NumReg As Long

        If auxiliar.UUID.NumReg = -1 And auxiliar.UUID.UUID <> "" Then

            Using cmd As New FbCommand
                cmd.Connection = trn.Connection
                cmd.Transaction = trn
                cmd.CommandText = "SELECT COALESCE(MAX(NUMREG),0) + 1 FROM UUIDTIMBRES"
                Dim dr As FbDataReader = cmd.ExecuteReader

                If (dr.Read) Then
                    If IsNumeric(dr(0).ToString.Trim) Then
                        NumReg = Convert.ToUInt64(dr(0))
                    End If
                End If

                sql = "INSERT INTO UUIDTIMBRES(NUMREG, UUIDTIMBRE, MONTO, SERIE, FOLIO, RFCEMISOR, RFCRECEPTOR, ORDEN, FECHA, TIPOCOMPROBANTE, TIPOCAMBIO, VERSIONCFDI, MONEDA)
                      VALUES(@NUMREG, @UUIDTIMBRE, @MONTO, @SERIE, @FOLIO, @RFCEMISOR, @RFCRECEPTOR, @ORDEN, @FECHA, @TIPOCOMPROBANTE, @TIPOCAMBIO, @VERSIONCFDI, @MONEDA)"

                cmd.CommandText = sql
                cmd.Parameters.Add("@NUMREG", NumReg)
                cmd.Parameters.Add("@UUIDTIMBRE", auxiliar.UUID.UUID)
                cmd.Parameters.Add("@MONTO", auxiliar.UUID.Monto)
                cmd.Parameters.Add("@SERIE", auxiliar.UUID.Serie)
                cmd.Parameters.Add("@FOLIO", auxiliar.UUID.Folio)
                cmd.Parameters.Add("@RFCEMISOR", auxiliar.UUID.RfcEmisor)
                cmd.Parameters.Add("@RFCRECEPTOR", auxiliar.UUID.RfcReceptor)
                cmd.Parameters.Add("@ORDEN", auxiliar.UUID.Orden)
                cmd.Parameters.Add("@FECHA", auxiliar.UUID.Fecha)
                cmd.Parameters.Add("@TIPOCOMPROBANTE", auxiliar.UUID.TipoComprobante)
                cmd.Parameters.Add("@TIPOCAMBIO", auxiliar.UUID.TipoCambio)
                cmd.Parameters.Add("@VERSIONCFDI", auxiliar.UUID.VersionCFDI)
                cmd.Parameters.Add("@MONEDA", auxiliar.UUID.Moneda)
                returnValue = cmd.ExecuteNonQuery().ToString()

                If Not returnValue Is Nothing Then
                    If returnValue <> "1" Then
                        Return False
                    End If
                Else
                    Return False
                End If

                auxiliar.UUID.NumReg = NumReg

            End Using

        End If


        Return True
    End Function

    Private Function ActualizaDocumentos(ByRef poliza As Poliza, ByRef trn As SqlTransaction) As Boolean
        Dim sql As String
        Dim i As Integer
        Dim returnValue As String

        Try

            Using cmd As SqlCommand = New SqlCommand()

                Dim IdPoliza As String
                sql = String.Format("INSERT INTO PolizasCOI(TipoPoliza, Folio, Ejercicio, Periodo, Fecha, Status, Usuario, FechaRegistro)
                                VALUES ('{0}', {1}, {2}, {3}, '{4:yyyyMMdd}', {5}, '{6}', getdate())", poliza.TipoPoliza, poliza.NumPoliza.Trim(), poliza.Ejercicio, poliza.Periodo, poliza.FechaPoliza, 1, USER_GRUPOCE)
                cmd.CommandText = sql
                cmd.Connection = trn.Connection
                cmd.Transaction = trn
                cmd.ExecuteNonQuery()

                sql = "SELECT SCOPE_IDENTITY()"
                cmd.CommandText = sql
                IdPoliza = cmd.ExecuteScalar().ToString()
                If IdPoliza IsNot Nothing Then
                    If IsNumeric(IdPoliza) Then
                        If Convert.ToInt64(IdPoliza) <= 0 Then
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If

                For Each documento As Documento In poliza.Documentos
                    If documento.TipoDocumento = EnmTipoDocumento.FacturaVentas Then
                        sql = String.Format("UPDATE FACTF{0} SET IDPOLIZACOI = {1} WHERE CVE_DOC = '{2}'", Empresa, IdPoliza, documento.ClaveDocumento)
                    End If
                    If documento.TipoDocumento = EnmTipoDocumento.Viaje Then
                        sql = String.Format("UPDATE GCASIGNACION_VIAJE SET IDPOLIZACOI = {0} WHERE CVE_VIAJE = '{1}'", IdPoliza, documento.ClaveDocumento)
                    End If
                    If documento.TipoDocumento = EnmTipoDocumento.Liquidacion Then
                        sql = String.Format("UPDATE GCLIQUIDACIONES SET IDPOLIZACOI = {0} WHERE CVE_LIQ = {1}", IdPoliza, documento.ClaveDocumento)
                    End If
                    If documento.TipoDocumento = EnmTipoDocumento.IngresosCxC Then
                        sql = String.Format("UPDATE CUEN_DET{0} SET IDPOLIZACOI = {1} WHERE DOCTO = '{2}' AND FECHA_APLI = '{3:yyyyMMdd}'", Empresa, IdPoliza, documento.ClaveDocumento, documento.FechaDocumento)
                    End If
                    cmd.CommandText = sql
                    returnValue = cmd.ExecuteNonQuery().ToString()

                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        Else
                            Return False
                        End If
                    Else
                        Return False
                    End If

                Next

            End Using

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

End Class

