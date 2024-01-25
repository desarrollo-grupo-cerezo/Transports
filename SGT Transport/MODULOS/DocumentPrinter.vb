Imports System.IO
Imports System.Data.SqlClient
Imports Stimulsoft.Base.Drawing
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Components

Module DocumentPrinter

    Public Function PrintFile(ByVal fileName As String, FPrinterSelec As String) As Boolean
        Dim printProcess As System.Diagnostics.Process = Nothing
        Dim printed As Boolean = False

        Try

            Dim startInfo As New ProcessStartInfo()

            startInfo.Verb = "Print"
            startInfo.Arguments = FPrinterSelec ' <----printer to use---- 
            startInfo.FileName = fileName
            startInfo.UseShellExecute = True
            startInfo.CreateNoWindow = True
            startInfo.WindowStyle = ProcessWindowStyle.Hidden

            Using print As System.Diagnostics.Process = Process.Start(startInfo)
                'Close the application after X milliseconds with WaitForExit(X) 
                print.WaitForExit(10000)

                If print.HasExited = False Then

                    If print.CloseMainWindow() Then
                        printed = True
                    Else
                        printed = True
                    End If
                Else
                    printed = True
                End If

                print.Close()

            End Using
        Catch ex As Exception
            Throw
        End Try
        Return printed

    End Function


    ''' <summary>
    ''' Change the default printer using a print dialog Box
    ''' </summary>
    ''' <param name="defaultPrinterSetting"></param>
    ''' <remarks></remarks>
    Public Sub ChangePrinterSettings(ByRef defaultPrinterSetting As System.Drawing.Printing.PrinterSettings)

        Dim printDialogBox As New PrintDialog

        If printDialogBox.ShowDialog = Windows.Forms.DialogResult.OK Then

            If printDialogBox.PrinterSettings.IsValid Then
                defaultPrinterSetting = printDialogBox.PrinterSettings
            End If

        End If

    End Sub



    ''' <summary>
    ''' Get the default printer settings in the system
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDefaultPrinterSetting() As System.Drawing.Printing.PrinterSettings

        Dim defaultPrinterSetting As System.Drawing.Printing.PrinterSettings = Nothing

        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters


            defaultPrinterSetting = New System.Drawing.Printing.PrinterSettings
            defaultPrinterSetting.PrinterName = printer

            If defaultPrinterSetting.IsDefaultPrinter Then
                Return defaultPrinterSetting
            End If

        Next

        Return defaultPrinterSetting

    End Function

    Public Sub PrinterMRT(FREPORTE As String, Optional FNOMBRE_DESCR As String = "")
        Try

            Dim Rreporte_MRT As String = "", Existe As Boolean = False
            Rreporte_MRT = GET_RUTA_FORMATOS() & "\" & FREPORTE & ".mrt"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCFORMATOS WHERE ARCHIVO = '" & FREPORTE & ".mrt'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Existe = True
                    End If
                End Using
            End Using

            If Not Existe Then
                Dim CVE_REP As Integer

                If FNOMBRE_DESCR.Trim.Length = 0 Then
                    FNOMBRE_DESCR = FREPORTE
                End If

                CVE_REP = GET_MAX("GCFORMATOS", "CVE_REP")

                SQL = "SET ansi_warnings OFF;
                    UPDATE GCFORMATOS SET NOMBRE = @NOMBRE, DESCR = @DESCR, ARCHIVO = @ARCHIVO
                    WHERE CVE_REP = @CVE_REP
                    IF @@ROWCOUNT = 0
                    INSERT INTO GCFORMATOS (CVE_REP, STATUS, NOMBRE, DESCR, ARCHIVO, FECHAELAB, UUID)
                    VALUES(ISNULL((SELECT MAX(CVE_REP) + 1 FROM GCFORMATOS),1), 'A', @NOMBRE, 
                    @DESCR, @ARCHIVO, GETDATE(), NEWID())"
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        cmd.Parameters.Add("@CVE_REP", SqlDbType.Int).Value = CVE_REP
                        cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = FNOMBRE_DESCR
                        cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = FNOMBRE_DESCR
                        cmd.Parameters.Add("@ARCHIVO", SqlDbType.VarChar).Value = FREPORTE & ".mrt"
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If Not File.Exists(Rreporte_MRT) Then
                        CREATE_REPORTE(Rreporte_MRT)
                    End If
                Catch ex As Exception
                    MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If

            Dim report = New StiReport()
            StiOptions.Designer.Ribbon.ShowMainMenuClose = True
            StiOptions.Designer.Ribbon.ShowMainMenuNew = True
            StiOptions.Designer.Ribbon.ShowMainMenuCheckForIssues = True
            StiOptions.Designer.Ribbon.ShowMainMenuOptions = True
            StiOptions.Designer.Ribbon.ShowMainMenuRecentFiles = True
            StiOptions.Designer.Ribbon.ShowMainMenuReportNew = True
            StiOptions.Designer.Ribbon.ShowMainMenuReportOpen = True
            'StiOptions.Designer.Ribbon.ShowMainMenuReportOpenFromGoogleDocs = True
            StiOptions.Designer.Ribbon.ShowMainMenuReportSaveAs = True
            'StiOptions.Designer.Ribbon.ShowMainMenuReportSaveAsToGoogleDocs = True
            StiOptions.Designer.Ribbon.ShowMainMenuReportSetup = True

            If File.Exists(Rreporte_MRT) Then
                report.Load(Rreporte_MRT)
            End If

            report.Design()

        Catch ex As Exception
            Bitacora("212. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("212. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Public Sub PrinterMRT_Create(FREPORTE As String, Optional FNOMBRE_DESCR As String = "")
        Try

            Dim Rreporte_MRT As String = "", Existe As Boolean = False
            Rreporte_MRT = GET_RUTA_FORMATOS() & "\" & FREPORTE & ".mrt"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCFORMATOS WHERE ARCHIVO = '" & FREPORTE & ".mrt'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Existe = True
                    End If
                End Using
            End Using

            If Not Existe Then
                Dim CVE_REP As Integer

                If FNOMBRE_DESCR.Trim.Length = 0 Then
                    FNOMBRE_DESCR = FREPORTE
                End If

                CVE_REP = GET_MAX("GCFORMATOS", "CVE_REP")

                SQL = "SET ansi_warnings OFF;
                    UPDATE GCFORMATOS SET NOMBRE = @NOMBRE, DESCR = @DESCR, ARCHIVO = @ARCHIVO
                    WHERE CVE_REP = @CVE_REP
                    IF @@ROWCOUNT = 0
                    INSERT INTO GCFORMATOS (CVE_REP, STATUS, NOMBRE, DESCR, ARCHIVO, FECHAELAB, UUID)
                    VALUES(ISNULL((SELECT MAX(CVE_REP) + 1 FROM GCFORMATOS),1), 'A', @NOMBRE, 
                    @DESCR, @ARCHIVO, GETDATE(), NEWID())"
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        cmd.Parameters.Add("@CVE_REP", SqlDbType.Int).Value = CVE_REP
                        cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = FNOMBRE_DESCR
                        cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = FNOMBRE_DESCR
                        cmd.Parameters.Add("@ARCHIVO", SqlDbType.VarChar).Value = FREPORTE & ".mrt"
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If Not File.Exists(Rreporte_MRT) Then
                        CREATE_REPORTE(Rreporte_MRT)
                    End If
                Catch ex As Exception
                    MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("212. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("212. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Public Sub CREATE_REPORTE(FREPORT As String, Optional FDATASOURCE As String = "DataSet")

        Dim CALLE As String = "", NOMBRE_EMP As String = ""
        Dim report = New StiReport()
        report.Dictionary.Synchronize()
        Dim page = report.Pages(0)
        Dim headerBand = New StiHeaderBand()

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        CALLE = dr.ReadNullAsEmptyString("CALLE") & ", " & dr.ReadNullAsEmptyString("NUMEXT") & ", " &
                                dr.ReadNullAsEmptyString("CP") & ", " & dr.ReadNullAsEmptyString("ESTADO") & ", " &
                                dr("EMISOR_RFC")

                        NOMBRE_EMP = dr("EMISOR_RAZON_SOCIAL")


                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        headerBand.Height = 5
        headerBand.Name = "HeaderBand"
        page.Components.Add(headerBand)

        Dim headerText = New StiText(New RectangleD(3, 0, 14, 0.5)) With {
            .Text = NOMBRE_EMP,
            .HorAlignment = StiTextHorAlignment.Center,
            .Name = "LtHeaderText",
            .Brush = New StiSolidBrush(Color.Transparent)
        }
        headerBand.Components.Add(headerText)

        Dim headerText2 = New StiText(New RectangleD(3, 1, 14, 0.5)) With {
            .Text = CALLE,
            .HorAlignment = StiTextHorAlignment.Center,
            .Name = "LtCalle",
            .Brush = New StiSolidBrush(Color.Transparent)
        }
        headerBand.Components.Add(headerText2)

        Dim dataBand = New StiDataBand()
        dataBand.DataSourceName = FDATASOURCE
        dataBand.Height = 0.5
        dataBand.Name = "DataBand"
        page.Components.Add(dataBand)

        'Dim dataText = New StiText(New RectangleD(0, 0, 5, 0.5))
        'dataText.Text = "{Line}.{Customers.CompanyName}"
        'dataText.Name = "DataText"
        'dataBand.Components.Add(dataText)

        Dim footerBand = New StiFooterBand With {
            .Height = 0.5,
            .Name = "FooterBand"
        }
        page.Components.Add(footerBand)

        Dim footerText = New StiText(New RectangleD(0, 0, 5, 0.5)) With {
            .Text = "Count - {Count()}",
            .HorAlignment = StiTextHorAlignment.Right,
            .Name = "FooterText",
            .Brush = New StiSolidBrush(Color.LightGreen)
        }
        footerBand.Components.Add(footerText)

        report.Save(FREPORT)

    End Sub
End Module
