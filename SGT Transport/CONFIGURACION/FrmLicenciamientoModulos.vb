Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Public Class FrmLicenciamientoModulos
    Private AMOUDULOS(25) As String
    Private Sub FrmLicenciamientoModulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Me.CenterToScreen()

        Dim MODULO As String

        Fg.DrawMode = DrawModeEnum.OwnerDraw
        Fg.Dock = DockStyle.Fill

        LLENA_MODULOS()

        Fg.Rows.Count = 1

        For k = 0 To AMOUDULOS.Length - 1
            Fg.AddItem("" & vbTab & AMOUDULOS(k) & vbTab & 0)
        Next

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(MODULO,'') AS MODU, ISNULL(ACCESO,0) AS ACC
                        FROM GCLICENCIAMIENTO_MODULOS"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        For k = 1 To Fg.Rows.Count - 1
                            MODULO = Desencriptar(dr("MODU"))
                            If MODULO = Fg(k, 1) Then
                                Fg(k, 2) = 1
                            End If
                        Next
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("28. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("28. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmLicenciamientoModulos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        Try
            SQL = "DELETE FROM GCLICENCIAMIENTO_MODULOS"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Bitacora("26. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("26. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            For k = 1 To Fg.Rows.Count - 1

                If Fg(k, 2) Then
                    SQL = "INSERT INTO GCLICENCIAMIENTO_MODULOS (MODULO, ACCESO, UUID) VALUES ('" &
                        Encriptar(Fg(k, 1)) & "','" & Fg(k, 2) & "',NEWID())"
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                End If
            Next

            MsgBox("Los modulos se grabaron correctamente")
            Me.Close()
        Catch ex As Exception
            Bitacora("28. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("28. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If e.Row = 0 AndAlso e.Col = 1 Then
                ChangeState(Fg.GetCellCheck(e.Row, e.Col))
            Else
                If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, 1, state)
        Next
    End Sub
    Sub LLENA_MODULOS()

        Try
            AMOUDULOS(0) = "CLIENTES"
            AMOUDULOS(1) = "PROVEEDORES"
            AMOUDULOS(2) = "ASEGURADORAS"
            AMOUDULOS(3) = "TARJETA IAVA"
            AMOUDULOS(4) = "CONTRATOS"
            AMOUDULOS(5) = "TIPO DE CARGA"
            AMOUDULOS(6) = "RUTAS"
            AMOUDULOS(7) = "TRAFICO"
            AMOUDULOS(8) = "EMPLEADOS"
            AMOUDULOS(9) = "CENTRO DE COSTO"
            AMOUDULOS(10) = "CATALOGOS"
            AMOUDULOS(11) = "VARIOS"
            AMOUDULOS(12) = "LOGISTICA"
            AMOUDULOS(13) = "TESORERIA"
            AMOUDULOS(14) = "FACTURACION"
            AMOUDULOS(15) = "LIQUIDACION"
            AMOUDULOS(16) = "VENTAS"
            AMOUDULOS(17) = "COMPRAS"
            AMOUDULOS(18) = "CONTROL DE COMBUSTIBLE"
            AMOUDULOS(19) = "MANTENIMIENTO"
            AMOUDULOS(20) = "INVENTARIO"
            AMOUDULOS(21) = "CONTABILIDAD"
            AMOUDULOS(22) = "RESCURSOS HUMANOS"
            AMOUDULOS(23) = "LOCALIZACION"
            AMOUDULOS(24) = "REPORTES"
            AMOUDULOS(25) = "CONFIGURACION"

        Catch ex As Exception
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Try
            If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
