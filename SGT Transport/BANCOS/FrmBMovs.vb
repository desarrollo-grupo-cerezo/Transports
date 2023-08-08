Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports C1.Win.C1Command

Public Class FrmBMovs
    Private CTA_BANC As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmBMovs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
            Me.Close()
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Me.CenterToScreen()
        Catch ex As Exception
        End Try
        Try
            Dim NAME_BANCO As String = ""

            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            CTA_BANC = Var8

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(CUENTA_BANCARIA,'') AS CTA_BANCARIA, ISNULL(NOMBRE_BANCO,'') AS NOMBRE
                    FROM CUENTA_BENEF" & Empresa & " WHERE CLAVE = '" & Convert.ToInt32(CTA_BANC) & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        NAME_BANCO = dr("NOMBRE")
                        Lt1.Text = "Cuenta bancaria:" & dr("CTA_BANCARIA") & "    Banco:" & NAME_BANCO
                    End If
                End Using
            End Using

            If Not EXISTE_TABLA_SQL("BMOV" & CTA_BANC) Then
                CREA_TABLAS_BANCOS(CTA_BANC)
            End If

            Fg.Dock = DockStyle.Fill

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Fg.Redraw = False
        Try
            SQL = "SELECT M.NUM_REG AS 'Clave', M.STATUS AS 'Estatus', M.CVE_CONCEP as 'Concepto', C.CONCEP AS 'Descripción', 
                M.REF1 AS 'Referencia 1', M.REF2 AS 'Referencia 2', M.FECHA AS 'Fecha', M.F_COBRO AS 'Fecha cobro', 
                M.MONTO_TOT AS 'Monto', M.MONTO_IVA_TOT AS 'IVA', '(' + M.CLPV + ') ' + B.NOMBRE AS 'Beneficiario', 
                M.X_OBSER AS 'Observaciones', M.FORMAPAGOSAT AS 'Forma de pago sat', NUM_CHEQUE AS 'Número de cheque'
                FROM BMOV" & CTA_BANC & " M
                LEFT JOIN BCONCEP C ON C.CVE_CONCEP = M.CVE_CONCEP
                LEFT JOIN BBENEF B ON B.CLAVE = M.CLPV
                WHERE M.STATUS = 'A'"

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub FrmBMovs_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        MainRibbonForm.RibBMovs.Enabled = True

        Me.Dispose()
        CloseTab("Movimientos bancarios")
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As ClickEventArgs) Handles BarCancelar.Click
        Try
            If MsgBox("Realmente desea cancelar el movimiento?", vbYesNo) = vbYes Then
                SQL = "UPDATE BMOV" & CTA_BANC & " SET STATUS = 'B' WHERE NUM_REG = " & CInt(Fg(Fg.Row, 1))
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
    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        Try
            If Fg.Row > 0 Then

                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 1)
                Var3 = CTA_BANC
                FrmBmovsAE.ShowDialog()
                DESPLEGAR()
            Else
                MsgBox("Por favor seleccione un movimiento")
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            Var3 = CTA_BANC
            FrmBmovsAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarRefrescar_Click(sender As Object, e As ClickEventArgs) Handles BarRefrescar.Click
        DESPLEGAR()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Function EXISTE_TABLA_SQL(fTABLA As String) As Boolean
        Dim Exist_Table As Boolean = False
        Try
            SQL = "SELECT * From INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & fTABLA & "'"
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            reader = cmd.ExecuteReader
            If reader.Read Then
                Exist_Table = True
            End If
            reader.Close()
        Catch ex As Exception
            Exist_Table = False
            BITACORADB("36. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & SQL)
        End Try
        Return Exist_Table
    End Function
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 13 Then
                    BarEdit_Click(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                BarEdit_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Movimientos")
        Catch ex As Exception
        End Try
    End Sub
End Class
