Imports Stimulsoft.Base.Drawing
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Components
Imports System.Data.SqlClient
Imports System.IO

Public Class frmReportDesigner
    Private Sub frmReportDesigner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim RUTA As String
        RUTA = GET_RUTA_FORMATOS()

        Me.WindowState = FormWindowState.Maximized

        If PASS_GRUPOCE = "BUS" Then
            Me.ShowInTaskbar = True
        End If

        'StiRibbonDesignerControl1.Top = 0
        'StiRibbonDesignerControl1.Left = 0
        'StiRibbonDesignerControl1.Height = My.Computer.Screen.Bounds.Size.Height - 75
        'StiRibbonDesignerControl1.Width = My.Computer.Screen.Bounds.Size.Width - 5


        'Stimulsoft.Base.Localization.StiLocalization.addLocalizationFile("Localizations/pt-BR.xml", False, "Portuguese (Brazil)")
        'Stimulsoft.Base.Localization.StiLocalization.setLocalizationFile("Localizations/es.xml")
        'Stimulsoft.Base.Localization.StiLocalization.setLocalizationFile("Localizations/es.xml", true)

        StiRibbonDesignerControl1.ShowTabPageBarPageSetup = True
        StiRibbonDesignerControl1.ShowLocalizationMenu = True
        StiRibbonDesignerControl1.ShowMainMenuOptions = True
        'StiRibbonDesignerControl1.ShowMainMenuReportSaveAs = True
        StiRibbonDesignerControl1.Enabled = True

        If Not File.Exists(RUTA & "\" & Var10) Then
            CEATE_REPORTE(RUTA & "\" & Var10)
        End If

        StiRibbonDesignerControl1.OpenFile(RUTA & "\" & Var10)

    End Sub
    Private Sub CEATE_REPORTE(FREPORT As String)

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
        dataBand.DataSourceName = "DataSet"
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

End Class
