Imports System.IO
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Dictionary

Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmConcepFlujo
    Private list As ArrayList = Nothing
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub FrmFlujo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Me.WindowState = FormWindowState.Maximized
        Catch ex As Exception
        End Try
    End Sub
    Sub CARGAR_DATOS1()
        Try
            If Var11 = "E" Then
                Lt1.Text = "Conceptos de entrada de flujo de efectivo"
            Else
                Lt1.Text = "Conceptos de salida de flujo de efectivo"
            End If

            SplitM.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill


            Fg.Rows.Count = 1
            Fg.Cols.Count = 4

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int16)

            Fg(0, 2) = "Descripción"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Tipo"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmFlujo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Conceptos Flujo efectivo")
    End Sub
    Sub DESPLEGAR()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            If Var11 = "E" Then
                SQL = "SELECT CLAVE, DESCR, TIPO FROM SOENTRADADINERO WHERE TIPO = 'E' ORDER BY CLAVE"
            Else
                SQL = "SELECT CLAVE, DESCR, TIPO FROM SOENTRADADINERO WHERE TIPO = 'S' ORDER BY CLAVE"
            End If

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("DESCR") & vbTab & IIf(dr("TIPO") = "E", "Entrada", "Salida"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub


    Private Sub BarNuevo_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"

            FrmConcepFlujoAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            FrmConcepFlujoAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                SQL = "UPDATE SOENTRADADINERO SET STATUS = 'B' WHERE  CLAVE = " & Fg(Fg.Row, 1) & " AND TIPO = '" & Var11 & "'"

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
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarImprimir.Click

        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportFlujoEfectivo.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text

            'StiReport1.Dictionary.Variables.Add(New Stimulsoft.Report.Dictionary.StiVariable("SQLF1", ""))

            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Conceptos flujo")
    End Sub

    Private Sub BarDisenador_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarDisenador.Click
        Dim report As New StiReport()
        Dim RUTA_FORMATOS As String

        RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportFlujoEfectivo.mrt"

        If Not File.Exists(RUTA_FORMATOS) Then

            CREATE_REPORTE(RUTA_FORMATOS)

            report.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            report.Dictionary.Databases.Clear()
            report.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            SQL = "SELECT CLAVE, DESCR, TIPO FROM SOENTRADADINERO WHERE TIPO = '" & Var11 & "'"

            Dim DS1 As New StiSqlSource("OLE DB", "SOENTRADADINERO", "SOENTRADADINERO", SQL, True)
            report.Dictionary.DataSources.Add(DS1)

            DS1.Columns.Add("CLAVE", "", GetType(Integer))
            DS1.Columns.Add("DESCR", "", GetType(String))
            DS1.Columns.Add("TIPO", "", GetType(String))

            DS1.SynchronizeColumns()
            report.Dictionary.Synchronize()

            'Dim newVariable = New StiVariable()            'report.Dictionary.Variables.Add(newVariable)
            report.Dictionary.Variables.Add(New Stimulsoft.Report.Dictionary.StiVariable("FECHA1", ""))
            report.Dictionary.Variables("FECHA1").Value = "ANYTHING"

            report.Compile()
            report.ReportName = Me.Text
            report.Render()
            report.Design()
        Else
            PrinterMRT("ReportFlujoEfectivo")
        End If

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class

