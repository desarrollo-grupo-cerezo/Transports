Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmComprasXML
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub CARGAR_DATOS1()
        Try

            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 10

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height 

            Fg(0, 1) = "Documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "UUID"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Proveedor"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Nombre"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Importe"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Fecha"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg(0, 7) = "Serie"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Folio"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Archivo XML"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmComprasXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        SplitM.Dock = DockStyle.Fill
        SplitM.BorderWidth = 1
        SplitM.SplitterWidth = 1

        Split1.SizeRatio = 6
        Split1.BorderWidth = 1

        Fg.Dock = DockStyle.Fill

    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            Fg.Redraw = False

            If Var17 = "C" Then
                SQL = "SELECT X.CVE_DOC, X.UUID_XML, CVE_CLPV, NOMBRE, IMPORTE, FECHA_DOC, SERIE, FOLIO, X.ARCHIVO_XML 
                    FROM GCCOMPRAS X
                    LEFT JOIN COMPC" & Empresa & " C ON C.CVE_DOC = X.CVE_DOC 
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = C.CVE_CLPV
                    ORDER BY FECHAELAB DESC"
            Else
                SQL = "SELECT X.CVE_DOC, X.UUID_XML, CVE_CLPV, NOMBRE, IMPORTE, FECHA_DOC, SERIE, FOLIO, X.ARCHIVO_XML 
                    FROM GCCOMPRAS X
                    LEFT JOIN GCGASTOS C ON C.CVE_DOC = X.CVE_DOC 
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = C.CVE_CLPV
                    ORDER BY FECHAELAB DESC"
            End If

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("UUID_XML") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE") & vbTab &
                           dr("IMPORTE") & vbTab & dr("FECHA_DOC") & vbTab & dr("SERIE") & vbTab & dr("FOLIO") & vbTab & dr("ARCHIVO_XML"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub frmComprasXML_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Documentos XML")
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If File.Exists(Fg(Fg.Row, 6)) Then
                Process.Start(Fg(Fg.Row, 6))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function OBTENER_RUTA_XML() As String
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
            Return RUTA_XML
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Return RUTA_XML
        End Try
    End Function

    Private Sub BarVerXML_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarVerXML.Click
        Try
            Dim RUTA_XML As String, ARCHIVO_XML As String
            RUTA_XML = OBTENER_RUTA_XML()

            If Fg(Fg.Row, 9).ToString.IndexOf(":\") > -1 Then
                ARCHIVO_XML = Path.GetFileName(Fg(Fg.Row, 9))
            Else
                ARCHIVO_XML = Fg(Fg.Row, 9)
            End If

            If File.Exists(RUTA_XML & "\" & ARCHIVO_XML) Then
                Process.Start(RUTA_XML & "\" & ARCHIVO_XML)
            Else
                MsgBox("No se encontro el archivo XML en la ruta especificada")
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarCarpetaXML_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarCarpetaXML.Click
        Try
            Dim RUTA_XML As String
            RUTA_XML = OBTENER_RUTA_XML()
            Process.Start(RUTA_XML)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "XML COMPRAS")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
