Imports C1.Win.C1Themes
Imports System.Xml

Public Class frmUsoCFDI

    Private Sub frmUsoCFDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Me.CenterToScreen()

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Try
            Dim ArchivoXml As String = ""
            Select Case Var2
                Case "UsoCFDI"
                    Me.Text = "Seleccione Uso CFDI"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_USOCFDI.xml"
                Case "PagoSAT"
                    Me.Text = "Seleccione Forma de pago"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_FORMA_PAGO.xml"
                Case "RegimenFiscal"
                    Me.Text = "Seleccione régimen fiscal"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_REGIMENFISCAL40.xml"
            End Select
            Dim xmlFile As XmlReader
            xmlFile = XmlReader.Create(ArchivoXml, New XmlReaderSettings())
            Dim ds As New DataSet
            ds.ReadXml(xmlFile)
            Fg.DataSource = ds.Tables(0)
            Select Case Var2
                Case "UsoCFDI"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 50
                    Fg.Cols(2).Width = 250
                    Fg.Cols(3).Width = 50 : Fg.Cols(4).Width = 50
                Case "PagoSAT"
                    Fg(0, 2) = "Clave"
                    Fg(0, 3) = "Descripción"
                    Fg.Cols(0).Width = 0 : Fg.Cols(1).Width = 0
                    Fg.Cols(2).Width = 50
                    Fg.Cols(3).Width = 220
                    Fg.Cols(4).Width = 0 : Fg.Cols(5).Width = 0 : Fg.Cols(6).Width = 0 : Fg.Cols(7).Width = 0 : Fg.Cols(8).Width = 0
                    Fg.Cols(9).Width = 0 : Fg.Cols(10).Width = 0 : Fg.Cols(11).Width = 0 : Fg.Cols(12).Width = 0 : Fg.Cols(13).Width = 0
                    Fg.Cols(14).Width = 0
                    Me.Width = 380
                    Fg.Width = Me.Width - 20
                Case "RegimenFiscal"
                    Fg(0, 1) = "Régimen fsical"
                    Fg(0, 2) = "Descripción"
                    Fg.Cols(0).Width = 30
                    Fg.Cols(1).Width = 50
                    Fg.Cols(2).Width = 450
                    Fg.Cols(3).Width = 0 : Fg.Cols(4).Width = 0
            End Select
            Me.Text = Fg.Rows.Count & " Registros encontrados"
        Catch ex As Exception
            msgbox("" & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick

        If Fg.Row > 0 Then
            If Var2 = "UsoCFDI" Then
                Var4 = Fg(Fg.Row, 1) 'CLAVE
                Var5 = Fg(Fg.Row, 2) 'NOMBRE
            Else
                Var4 = Fg(Fg.Row, 2) 'CLAVE
                Var5 = Fg(Fg.Row, 3) 'NOMBRE
            End If

            Select Case Var2
                Case "UsoCFDI"
                    Var4 = Fg(Fg.Row, 1) 'CLAVE
                    Var5 = Fg(Fg.Row, 2) 'NO
                Case "PagoSAT"
                    Var4 = Fg(Fg.Row, 2) 'CLAVE
                    Var5 = Fg(Fg.Row, 3) 'NOMBREMBRE
                Case "RegimenFiscal"
                    Var4 = Fg(Fg.Row, 1) 'CLAVE
                    Var5 = Fg(Fg.Row, 2) 'nombre
            End Select
            Me.Close()
        End If
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Call Fg_DoubleClick(Nothing, Nothing)
    End Sub
    Private Sub frmUsoCFDI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
