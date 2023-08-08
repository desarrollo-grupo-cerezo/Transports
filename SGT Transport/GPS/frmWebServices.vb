Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.Xml
Imports System.IO
Imports System.Net
Imports C1.Win.C1Input
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Runtime.Serialization

Public Class frmWebServices
    Private BindingSource1 As BindingSource = New BindingSource

    Private Sub frmWebServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FECHA2 As Date = Date.Now
        Dim FECHA As String
        Dim RegFecha As Boolean

        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        Application.EnableVisualStyles()
        Me.WindowState = FormWindowState.Maximized
        BindingSource1.ResetBindings(True)
        BindingSource1.RemoveFilter()

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        F2.Value = Date.Today
        F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.CustomFormat = "dd/MM/yyyy"
        F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.EditFormat.CustomFormat = "dd/MM/yyyy"

        FECHA = FECHA2.ToString("yyyyMMdd")
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT CLAVEMONTE FROM GCUNIDADES WHERE ISNULL(STATUS, 'A') = 'A' ORDER BY CLAVEMONTE"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            cboUnidad.Items.Clear()

            Do While dr.Read
                cboUnidad.Items.Add(dr("CLAVEMONTE"))
            Loop
            dr.Close()

        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        BindingSource1.ResetBindings(True)
        BindingSource1.RemoveFilter()

        RegFecha = False

        If OpenGPS(Servidor_SAROCE, "GCGPS", Usuario_SAROCE, Pass_SAROCE) Then
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader

                cmd.Connection = cnGPS

                SQL = "SELECT TOP 10 * FROM POSICIONES WHERE FECHA = '" & FECHA & "' ORDER BY FECHACREACION"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    RegFecha = True
                End If
                dr.Close()

            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                Fg.Rows(0).Height = 40
                Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
                Fg.Height = Me.Height - barSalir.Height - 50
                Fg.Left = 15

                If RegFecha Then
                    SQL = "SELECT TOP 10000 * FROM POSICIONES WHERE FECHA = '" & FECHA & "' ORDER BY FECHACREACION"
                Else
                    SQL = "SELECT TOP 10000 * FROM POSICIONES ORDER BY FECHACREACION"
                End If


                da = New SqlDataAdapter(SQL, cnGPS)
                dt = New DataTable ' crear un DataTable
                da.SelectCommand.CommandTimeout = 120

                da.Fill(dt)

                BindingSource1.DataSource = dt
                Fg.DataSource = BindingSource1.DataSource

                TITULOS()
                Fg.AutoSizeCols()
                Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
            Catch ex As Exception
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("No se logro conectar a la base de datos GPS")
        End If
    End Sub
    Sub TITULOS()

        Fg(0, 1) = "Estatus"
        Fg(0, 2) = "Unidad"
        Fg(0, 3) = "altitud"
        Fg(0, 4) = "cercaCiudad"
        Fg(0, 5) = "combustibletotal"
        Fg(0, 6) = "Fecha"
        Fg(0, 7) = "fechacreacion"
        Fg(0, 8) = "flota"
        Fg(0, 9) = "ignicion"
        Fg(0, 10) = "importacionid"
        Fg(0, 11) = "lat"
        Fg(0, 12) = "lng"
        Fg(0, 13) = "odometrototal"
        Fg(0, 14) = "operador"
        Fg(0, 15) = "placas"
        Fg(0, 16) = "subflota"
        Fg(0, 17) = "unitno"
        Fg(0, 18) = "velpromedio"

        Dim c1 As Column = Fg.Cols(1)
        c1.DataType = GetType(String)

        Dim c2 As Column = Fg.Cols(1)
        c2.DataType = GetType(String)

        Dim c3 As Column = Fg.Cols(2)
        c3.DataType = GetType(String)
        c3.Format = "N2"
        Fg.Cols(3).TextAlign = TextAlignEnum.RightCenter

        Dim c4 As Column = Fg.Cols(3)
        c4.DataType = GetType(String)

        Dim c5 As Column = Fg.Cols(4)
        c5.DataType = GetType(Single)
        c5.Format = "N2"
        Fg.Cols(5).TextAlign = TextAlignEnum.RightCenter

        Dim c6 As Column = Fg.Cols(5)
        c6.DataType = GetType(Date)
        c6.Format = "d"

        Fg.Cols(7).DataType = GetType(Date)
        Fg.Cols(7).Format = "G"

        Dim c8 As Column = Fg.Cols(7)
        c8.DataType = GetType(String)

        Dim c9 As Column = Fg.Cols(8)
        c9.DataType = GetType(String)

        Dim c10 As Column = Fg.Cols(9)
        c10.DataType = GetType(String)

        Dim c11 As Column = Fg.Cols(10)
        c11.DataType = GetType(String)

        Dim c12 As Column = Fg.Cols(11)
        c12.DataType = GetType(Decimal)
        Fg.Cols(12).TextAlign = TextAlignEnum.RightCenter
        c12.Format = "N6"

        Dim c13 As Column = Fg.Cols(12)
        c13.DataType = GetType(Decimal)
        c13.Format = "N6"
        Fg.Cols(13).TextAlign = TextAlignEnum.RightCenter

        Dim c14 As Column = Fg.Cols(13)
        c14.DataType = GetType(String)

        Dim c15 As Column = Fg.Cols(14)
        c15.DataType = GetType(String)

        Dim c16 As Column = Fg.Cols(15)
        c16.DataType = GetType(String)

        Dim c17 As Column = Fg.Cols(16)
        c17.DataType = GetType(String)

        Dim c18 As Column = Fg.Cols(17)
        c18.DataType = GetType(String)
    End Sub

    Private Sub barWebServices_Click(sender As Object, e As EventArgs) Handles barWebServices.Click

        'BOTON GOOD         DESPLEGAR        DESPLEGAR
        Dim A1 As String, A2 As String, A3 As String, A4 As String, A5 As String, A6 As String, A7 As String, A8 As String, A9 As String
        Dim A10 As String, A11 As String, A12 As String, A13 As String, A14 As String, A15 As String, A16 As String, A17 As String, A18 As String
        Dim A19 As String, A20 As String, A21 As String = "", A22 As String, A23 As String, A24 As String, A25 As String, A26 As String, A27 As String
        Dim A28 As String, A29 As String, A30 As String, A31 As String, A32 As String = "", LAT As Decimal, LON As Decimal
        Dim FECHA As String, FECHA2 As DateTime, FECHA3 As String
        Dim NReg As Integer, CADENA As String = ""

        Me.Cursor = Cursors.WaitCursor
        Me.Cursor = Cursors.WaitCursor
        Try
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString("https://telemetry.dev.api.enlacefl.com/clients/444/users/13501/assets/current-position?key=AIzaSyB9hWVCQjGX8d0hSeX3biRvOp_lgixpqDY")

            BACKUPTXT("GPS_COORD", result)
            Try
                Dim path = "..assetId"
                Dim jResults = JToken.Parse(result)
                Dim query = jResults.SelectTokens(path)
                Dim count = query.Count()
                NReg = count
            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Dim result1 = JsonConvert.DeserializeObject(result)
            For k = 0 To NReg - 1
                Try

                    A1 = result1("data")(k)("assetId")
                    A2 = result1("data")(k)("vehicleNumber")
                    A3 = result1("data")(k)("numberPlates")
                    A4 = result1("data")(k)("vehicleBrand")
                    A5 = result1("data")(k)("vehicleModel")
                    A6 = result1("data")(k)("vehicleYear")
                    A7 = result1("data")(k)("vin")
                    A8 = result1("data")(k)("engineModel")
                    A9 = result1("data")(k)("groupName")
                    A10 = result1("data")(k)("serialNumber")
                    A11 = result1("data")(k)("position")("gpsSpeed")
                    A12 = result1("data")(k)("position")("gpsDistance")
                    A13 = result1("data")(k)("position")("status")("diagnosticStatusId")
                    A14 = result1("data")(k)("position")("status")("diagnosticStatus")
                    A15 = result1("data")(k)("position")("status")("operationalStatusId")
                    A16 = result1("data")(k)("position")("status")("operationalStatus")
                    A17 = result1("data")(k)("position")("ignition")
                    A18 = result1("data")(k)("position")("orientation")
                    A19 = result1("data")(k)("position")("orientationLabel")
                    A20 = result1("data")(k)("position")("satellites")
                    A22 = result1("data")(k)("position")("nearestCityReference")
                    A23 = result1("data")(k)("position")("nearestCity")("distance")
                    A24 = result1("data")(k)("position")("nearestCity")("name")
                    A25 = result1("data")(k)("position")("nearestCity")("orientation")

                    A26 = result1("data")(k)("position")("date")
                    A27 = result1("data")(k)("position")("latitude")
                    A28 = result1("data")(k)("position")("longitude")
                    A29 = result1("data")(k)("position")("streetReference")
                    A30 = result1("data")(k)("position")("altitude")
                    A31 = result1("data")(k)("position")("isSatelliteSource")

                    LAT = 0 : LON = 0
                    Try
                        LAT = A27
                        LON = A28
                    Catch ex As Exception
                        LAT = 0 : LON = 0
                        Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    If A2 = "M-234" Then
                        LAT = LAT
                    End If
                    If LAT <> 0 And LON <> 0 Then
                        SQL = "IF NOT EXISTS (SELECT UNIDAD FROM POSICIONES WHERE LAT = " & LAT & " AND LNG = " & LON & ") 
                        INSERT INTO POSICIONES (STATUS, UNIDAD, ALTITUD, CERCACIUDAD, COMBUSTIBLETOTAL, FECHA, FECHACREACION, FLOTA, IGNICION, 
                        IMPORTACIONID, LAT, LNG, ODOMETROTOTAL, OPERADOR, PLACAS, SUBFLOTA, UUID) VALUES('"
                        FECHA3 = A26
                        If IsDate(FECHA3) Then
                            FECHA2 = FECHA3
                            FECHA = FECHA2.ToString("yyyyMMdd HH:mm:ss")
                            FECHA3 = FECHA2.ToString("yyyyMMdd")
                        Else
                            FECHA = Now.ToString("yyyyMMdd HH:mm:ss")
                            FECHA3 = Now.ToString("yyyyMMdd")
                        End If
                        If A22.Length > 90 Then A22 = A22.Substring(0, 90)
                        SQL = SQL & "A','"
                        SQL = SQL & A2 & "','" 'UNIDAD
                        SQL = SQL & A30 & "','" 'ALTITUD
                        SQL = SQL & A22 & "','" 'CERCACIUDAD
                        SQL = SQL & "0','"
                        SQL = SQL & FECHA3 & "','"
                        SQL = SQL & FECHA & "','"
                        SQL = SQL & A9 & "','" 'FLOTA
                        SQL = SQL & A17 & "','" 'IGNICION
                        SQL = SQL & "0','"
                        SQL = SQL & LAT & "','" 'ATITUD
                        SQL = SQL & LON & "','" 'LONGITUD
                        SQL = SQL & "0','"
                        SQL = SQL & " ','"
                        SQL = SQL & A3 & "','" 'PLACAS
                        SQL = SQL & A4 & "',NEWID())" 'SUBFLOTA
                        Try
                            Using cmd As SqlCommand = cnGPS.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                            If A2 = "M-234" Then
                                LAT = LAT
                            End If

                        Catch ex As Exception
                            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Try
            CloseTab("webservices")
            Me.Close()
        Catch ex As Exception
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barExcel_Click(sender As Object, e As EventArgs) Handles barExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Estadisticas de venta por Zona")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barRutas_Click(sender As Object, e As EventArgs) Handles barRutas.Click
        Try
            If Fg.Row > 0 Then
                Var1 = cboUnidad.Text
                frmGMapNet.Show()
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmWebServices_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            cnGPS.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barActualizar_Click(sender As Object, e As EventArgs) Handles barActualizar.Click
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            Fg.Redraw = False

            Application.EnableVisualStyles()
            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            SQL = "SELECT TOP 10000 * FROM POSICIONES WHERE ISNULL(STATUS,'A') = 'A' ORDER BY FECHACREACION"

            da = New SqlDataAdapter(SQL, cnGPS)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            BindingSource1.Sort = "FECHACREACION"
            Fg.DataSource = BindingSource1.DataSource

            For k = 1 To Fg.Rows.Count - 1
                Fg(k, 0) = k
            Next
            TITULOS()
            Fg.AutoSizeCols()

            If cboUnidad.Text <> "" Then
                cboUnidad_DropDownClosed(Nothing, Nothing)
            End If

            Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1
        Catch ex As Exception
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetDataObject(Fg(Fg.Row, 10) & ", " & vbNewLine & Fg(Fg.Row, 11))

        Catch ex As Exception
            MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub F1_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles F1.DropDownClosed
        FILTRAR_FECHAS()
    End Sub
    Sub FILTRAR_FECHAS()
        Dim FECHA2 As Date = F1.Value
        Dim FECHA As String
        Dim FECHA1 As String
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            Application.EnableVisualStyles()
            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            FECHA = FECHA2.ToString("yyyyMMdd")
            FECHA = FECHA2.ToString("yyyyMMdd")
            FECHA2 = F2.Value
            FECHA1 = FECHA2.ToString("yyyyMMdd")

            SQL = "SELECT * FROM POSICIONES WHERE FECHA >= '" & FECHA & "' AND FECHA <= '" & FECHA1 & "'"

            da = New SqlDataAdapter(SQL, cnGPS)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            BindingSource1.Sort = "FECHACREACION"
            Fg.DataSource = BindingSource1.DataSource

            TITULOS()
            Fg.AutoSizeCols()
            Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1

        Catch ex As Exception
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub cboUnidad_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles cboUnidad.DropDownClosed
        Try
            Dim FECHA2 As Date = F1.Value
            Dim FECHA As String
            Dim FECHA1 As String

            Fg.Redraw = False

            FECHA = FECHA2.ToString("yyyyMMdd")
            FECHA = FECHA2.ToString("yyyyMMdd")
            FECHA2 = F2.Value
            FECHA1 = FECHA2.ToString("yyyyMMdd")

            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            Application.EnableVisualStyles()
            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            SQL = "SELECT * FROM POSICIONES WHERE UNIDAD = '" & cboUnidad.Text & "' AND FECHA >= '" & FECHA & "' AND FECHA <= '" & FECHA1 & "'
                   AND ISNULL(STATUS,'A') = 'A'"

            da = New SqlDataAdapter(SQL, cnGPS)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            BindingSource1.Sort = "FECHACREACION"
            Fg.DataSource = BindingSource1.DataSource

            For k = 1 To Fg.Rows.Count - 1
                Fg(k, 0) = k
            Next

            TITULOS()
            Fg.AutoSizeCols()
            Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1

        Catch ex As Exception
            Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub F2_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles F2.DropDownClosed
        FILTRAR_FECHAS()
    End Sub
    Private Sub BarTest_Click(sender As Object, e As EventArgs) Handles BarTest.Click
        Dim A1 As String, A2 As String, A3 As String, A4 As String, A5 As String, A6 As String, A7 As String, A8 As String, A9 As String
        Dim A10 As String, A11 As String, A12 As String, A13 As String, A14 As String, A15 As String, A16 As String, A17 As String, A18 As String
        Dim A19 As String, A20 As String, A21 As String = "", A22 As String, A23 As String, A24 As String, A25 As String, A26 As String, A27 As String
        Dim A28 As String, A29 As String, A30 As String, A31 As String, A32 As String = ""
        Dim FECHA As String, FECHA2 As DateTime, FECHA3 As String
        Dim NReg As Integer, CADENA As String = ""

        Try
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString("https://telemetry.dev.api.enlacefl.com/clients/444/users/13501/assets/current-position?key=AIzaSyB9hWVCQjGX8d0hSeX3biRvOp_lgixpqDY")

            BACKUPTXT("GPS_COORD", result)
            Try
                Dim path = "..assetId"
                Dim jResults = JToken.Parse(result)
                Dim query = jResults.SelectTokens(path)
                Dim count = query.Count()
                NReg = count
            Catch ex As Exception
                Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Dim result1 = JsonConvert.DeserializeObject(result)
            For k = 0 To NReg - 1
                Try
                    A1 = result1("data")(k)("assetId")
                    A2 = result1("data")(k)("vehicleNumber")
                    A3 = result1("data")(k)("numberPlates")
                    A4 = result1("data")(k)("vehicleBrand")
                    A5 = result1("data")(k)("vehicleModel")
                    A6 = result1("data")(k)("vehicleYear")
                    A7 = result1("data")(k)("vin")
                    A8 = result1("data")(k)("engineModel")
                    A9 = result1("data")(k)("groupName")
                    A10 = result1("data")(k)("serialNumber")
                    A11 = result1("data")(k)("position")("gpsSpeed")
                    A12 = result1("data")(k)("position")("gpsDistance")
                    A13 = result1("data")(k)("position")("status")("diagnosticStatusId")
                    A14 = result1("data")(k)("position")("status")("diagnosticStatus")
                    A15 = result1("data")(k)("position")("status")("operationalStatusId")
                    A16 = result1("data")(k)("position")("status")("operationalStatus")
                    A17 = result1("data")(k)("position")("ignition")
                    A18 = result1("data")(k)("position")("orientation")
                    A19 = result1("data")(k)("position")("orientationLabel")
                    A20 = result1("data")(k)("position")("satellites")
                    A22 = result1("data")(k)("position")("nearestCityReference")
                    A23 = result1("data")(k)("position")("nearestCity")("distance")
                    A24 = result1("data")(k)("position")("nearestCity")("name")
                    A25 = result1("data")(k)("position")("nearestCity")("orientation")

                    A26 = result1("data")(k)("position")("date")
                    A27 = result1("data")(k)("position")("latitude")
                    A28 = result1("data")(k)("position")("longitude")
                    A29 = result1("data")(k)("position")("streetReference")
                    A30 = result1("data")(k)("position")("altitude")
                    A31 = result1("data")(k)("position")("isSatelliteSource")

                    SQL = "INSERT INTO POSICIONES (STATUS, UNIDAD, ALTITUD, CERCACIUDAD, COMBUSTIBLETOTAL, FECHA, FECHACREACION, FLOTA, IGNICION, " &
                            "IMPORTACIONID, LAT, LNG, ODOMETROTOTAL, OPERADOR, PLACAS, SUBFLOTA, UUID) VALUES('"
                    FECHA3 = A26
                    If IsDate(FECHA3) Then
                        FECHA2 = FECHA3
                        FECHA = FECHA2.ToString("yyyyMMdd HH:mm:ss")
                        FECHA3 = FECHA2.ToString("yyyyMMdd")
                    Else
                        FECHA = Now.ToString("yyyyMMdd HH:mm:ss")
                        FECHA3 = Now.ToString("yyyyMMdd")
                    End If
                    If A22.Length > 90 Then A22 = A22.Substring(0, 90)

                    SQL = SQL & "A','"
                    SQL = SQL & A2 & "','"
                    SQL = SQL & A30 & "','"
                    SQL = SQL & A22 & "','"
                    SQL = SQL & "0','"
                    SQL = SQL & FECHA3 & "','"
                    SQL = SQL & FECHA & "','"
                    SQL = SQL & A9 & "','"
                    SQL = SQL & A17 & "','"
                    SQL = SQL & "0','"
                    SQL = SQL & A27 & "','" 'ATITUD
                    SQL = SQL & A28 & "','" 'LONGITUD
                    SQL = SQL & "0','"
                    SQL = SQL & " ','"
                    SQL = SQL & A3 & "','"
                    SQL = SQL & A4 & "',NEWID())"
                    Try
                        Using cmd As SqlCommand = cnGPS.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        End Using

                    Catch ex As Exception
                        Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Catch ex As Exception
                    Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            Lt1.Text = Fg.Rows.Count - 1

        Catch ex As Exception
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarGoogleMpas1_Click(sender As Object, e As EventArgs) Handles BarGoogleMpas1.Click
        frmGoogleMaps1.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Enabled = False
            barWebServices_Click(Nothing, Nothing) ' DESCARGAS COORDENADAS DE LA NUBE

            barActualizar_Click(Nothing, Nothing) 'ACTUALIZAR MALLA

            BACKUPTXT("TIMER_GPS", DateTime.Now.ToLongDateString() & " " & DateTime.Now.ToString("hh:mm:ss") & "    Registros:" & Fg.Rows.Count - 1)

            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)

        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Timer1.Enabled = True

    End Sub
End Class
