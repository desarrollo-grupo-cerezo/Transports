Imports Stimulsoft.Base.Drawing
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Components
Imports System.IO
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class frmArchivosReportes
    Private Sub frmArchivosReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
            Me.WindowState = FormWindowState.Maximized

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg.Rows.Count = 1
            'Fg.Cols.Count = 56

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Nombre"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripción"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Formato"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim ARCHIVO As String
            Dim RUTA As String

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT CVE_REP, NOMBRE, DESCR, ARCHIVO FROM GCFORMATOS WHERE STATUS = 'A' ORDER BY CVE_REP"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            RUTA = GET_RUTA_FORMATOS()

            Fg.Rows.Count = 1
            Do While dr.Read
                If File.Exists(RUTA & "\" & dr("ARCHIVO")) Then
                    ARCHIVO = "ok"
                Else
                    ARCHIVO = "NO EXISTE"
                End If
                Fg.AddItem("" & vbTab & dr("CVE_REP") & vbTab & dr("NOMBRE") & vbTab & dr("DESCR") & vbTab & dr("ARCHIVO") & vbTab & ARCHIVO)
            Loop
            dr.Close()
            'Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub frmArchivosReportes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Formatos")
        Me.Dispose()
    End Sub
    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmArchivosReportesAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            frmArchivosReportesAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "DELETE FROM GCFORMATOS WHERE CVE_REP = " & Fg(Fg.Row, 1)
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se elimino satisfactoriamente")
                        DESPLEGAR()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        barDesignerFormato_Click(Nothing, Nothing)
    End Sub
    Private Sub barDesignerFormato_Click(sender As Object, e As EventArgs) Handles barDesignerFormato.Click
        Try
            Var10 = Fg(Fg.Row, 4)
            Var11 = Fg(Fg.Row, 5)

            BACKUPTXT("XTAB_CAPTION", "frmArchivosReportes" & vbNewLine)
            If PASS_GRUPOCE = "BUS" Then
                Try

                    Dim Rreporte_MRT As String = ""
                    Try
                        Rreporte_MRT = GET_RUTA_FORMATOS() & "\" & Var10
                    Catch ex As Exception
                    End Try

                    If Not File.Exists(Rreporte_MRT) Then
                        CEATE_REPORTE(Rreporte_MRT)
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
                    Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                If PASS_GRUPOCE = "BUS" Then
                    frmReportDesigner.Show()
                Else
                    CREA_TAB(frmReportDesigner, "Reporteador")
                End If

            End If

        Catch ex As Exception
            Bitacora("212. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("212. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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
