Imports System.IO

Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmTPVFlujoEfectivo
    Private Sub FrmTPVFlujo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
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
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Fg.Dock = DockStyle.Fill

        Catch ex As Exception
        End Try
        TITULOS()
        DESPLEGAR("")
    End Sub
    Sub DESPLEGAR(FTIPO As String)
        Dim CADENA As String, S1 As Decimal, S2 As Decimal, S3 As Decimal, IMPORTE As Decimal
        Try
            Select Case FTIPO
                Case "E"
                    CADENA = " WHERE F.TIPO_MOV = 'E'"
                Case "S"
                    CADENA = " WHERE F.TIPO_MOV = 'S'"
                Case Else
                    CADENA = ""
            End Select
            Fg.Rows.Count = 1

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT TOP 1000 F.ID, F.CLAVE, C.DESCR, F.TIPO_MOV, F.CAJA, F.USUARIO, F.FECHAELAB, F.IMPORTE, OBSER 
                    FROM SOFLUJO F
                    LEFT JOIN SOENTRADADINERO C ON C.CLAVE = F.CLAVE " &
                    CADENA & "
                    ORDER BY FECHAELAB DESC"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("DESCR") & vbTab & IIf(dr("TIPO_MOV") = "E", "Entrada", "Salida") & vbTab & dr("CAJA") & vbTab &
                                   dr("USUARIO") & vbTab & dr("FECHAELAB") & vbTab & IIf(dr("TIPO_MOV") = "E", dr("IMPORTE"), 0) & vbTab &
                                   IIf(dr("TIPO_MOV") = "E", 0, dr("IMPORTE") * -1) & vbTab & "" & vbTab & dr("OBSER") & vbTab & dr("ID"))

                        If dr("TIPO_MOV") = "E" Then
                            S1 += dr("IMPORTE")
                            IMPORTE = dr("IMPORTE")
                        Else
                            S2 += dr("IMPORTE") * -1
                            IMPORTE = dr("IMPORTE") * -1
                        End If
                        S3 += IMPORTE
                    End While

                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                   "" & vbTab & "" & vbTab & S1 & vbTab & S2 & vbTab & S3)
                End Using
            End Using

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmTPVFlujo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Flujo de caja")
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarNuevo.Click

        FrmFlujoCaja.ShowDialog()
        DESPLEGAR("")

    End Sub

    Private Sub BarEntradas_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarEntradas.Click
        DESPLEGAR("E")
    End Sub

    Private Sub BarSalidas_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalidas.Click
        DESPLEGAR("S")
    End Sub
    Private Sub BarTodos_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarTodos.Click
        DESPLEGAR("")
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarEliminar.Click

        If Fg.Row > 0 Then
            If Not pwPoder Then
                RJMessageBox.Show("Usuario sin derechos para eliminar flujo de caja", "Advertencia", MessageBoxButtons.OK)
                Return
            End If

            Dim result = RJMessageBox.Show("Realmente desea eliminar el flujo de caja?",
                                       "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Try
                    SQL = "DELETE FROM SOFLUJO WHERE ID = " & Fg(Fg.Row, 11)
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                MsgBox("El flujo de caja se elimino correctamente")
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            End If
        End If
    End Sub

    Private Sub BarActualizar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR("")
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarImprimir.Click
        If Fg.Row > 0 Then
            Try
                Dim RUTA_FORMATOS As String
                Dim j As Integer = 0

                BarImprimir.Enabled = False

                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\TicketFlujo.mrt"
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
                StiReport1.Item("ID") = Fg(Fg.Row, 11)
                StiReport1("TIPO") = Fg(Fg.Row, 3)

                StiReport1.Render()
                StiReport1.Show()
            Catch ex As Exception
                Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            BarImprimir.Enabled = True
        Else
            RJMessageBox.Show("Por favor seleccione un flujo de caja", "Advertencia", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Flujo de caja")
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Sub TITULOS()

        Fg.Rows(0).Height = 40
        Fg.Cols.Count = 12

        Fg(0, 1) = "Clave"
        Dim c1 As Column = Fg.Cols(1)
        c1.DataType = GetType(Int32)

        Fg(0, 2) = "Descripción"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Entrada/Salida"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Caja"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(Int16)

        Fg(0, 5) = "Usuario"
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)

        Fg(0, 6) = "Fecha"
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(DateTime)

        Fg(0, 7) = "Entradas"
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(Decimal)
        Fg.Cols(7).Format = "###,###,##0.00"

        Fg(0, 8) = "Salidas"
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(Decimal)
        Fg.Cols(8).Format = "###,###,##0.00"

        Fg(0, 9) = "Monto en caja"
        Dim c9 As Column = Fg.Cols(9)
        c9.DataType = GetType(Decimal)
        Fg.Cols(9).Format = "###,###,##0.00"

        Fg(0, 10) = "Observaciones"
        Dim c10 As Column = Fg.Cols(10)
        c10.DataType = GetType(String)

        Fg(0, 11) = "ID"
        Dim c11 As Column = Fg.Cols(11)
        c11.DataType = GetType(Int32)

        Fg.Cols(11).Visible = False

    End Sub

End Class