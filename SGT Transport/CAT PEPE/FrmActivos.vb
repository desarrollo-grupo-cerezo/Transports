Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmActivos
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

    End Sub
    Private Sub FrmActivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        DESPLEGAR()

    End Sub
    Sub DESPLEGAR()

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            Fg.Rows.Count = 1
            Fg.Redraw = False

            SQL = "SELECT CLAVE, TIPO, DESCRIP, LOCALIZ, MONTORIG, MONTORIGEX, FECHAADQ, MAXDED, VALMER, DEPACU, VIDAUT, METDEP, TASDEP, 
                TASDEPFIS, STATUS, FECHAELIM, NUMDEPTO, FECHAULTRE, NUMSERIE, BANDEDINM, FECINIDEP, FECINIDEPF, DEPACUFISC, OBSERVACIO, 
                TIPOCAMBIO, POLIZASEG, COMPASEGU, AGENTESEG, TELSINIES, TIPOCOBER, MONTOASEG, PRIMATOTA, DEDUCIBLE, FECVIGENC, 
                FECPROXMA, FECULTMAN, PERIODOMA, COSTOMANT, RESPACTFIJO 
                FROM GCACTIVOS
                WHERE ISNULL(STATUS,'A') <> 'B'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("STATUS") & vbTab & dr("DESCRIP") & vbTab & dr("FECHAADQ") & vbTab & dr("MONTORIG") & vbTab &
                           dr("VIDAUT") & vbTab & dr("VALMER") & vbTab & dr("TIPO") & vbTab & dr("LOCALIZ") & vbTab & dr("NUMDEPTO") & vbTab &
                           dr("NUMSERIE") & vbTab & ("RESPACTFIJO") & vbTab &
                           dr("FECINIDEP") & vbTab & dr("TASDEP") & vbTab & dr("DEPACU") & vbTab &
                           dr("METDEP") & vbTab & dr("FECINIDEPF") & vbTab & dr("TASDEPFIS") & vbTab & dr("BANDEDINM") & vbTab & dr("DEPACUFISC") & vbTab & dr("MAXDED") & vbTab &
                           dr("POLIZASEG") & vbTab & dr("COMPASEGU") & vbTab & dr("AGENTESEG") & vbTab & dr("TELSINIES") & vbTab &
                           dr("TIPOCOBER") & vbTab & dr("MONTOASEG") & vbTab & dr("PRIMATOTA") & vbTab & dr("DEDUCIBLE") & vbTab &
                           dr("FECVIGENC") & vbTab & dr("FECULTMAN") & vbTab & dr("COSTOMANT") & vbTab &
                           dr("PERIODOMA") & vbTab & dr("FECPROXMA") & vbTab & dr("OBSERVACIO"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()
            Fg.Cols(4).Width = 75
            Fg.Cols(13).Width = 75
            Fg.Cols(14).Width = 75
            Fg.Cols(15).Width = 75
            Fg.Cols(16).Width = 75
            Fg.Cols(17).Width = 76
            Fg.Cols(18).Width = 70
            Fg.Cols(19).Width = 75
            Fg.Cols(20).Width = 76
            Fg.Cols(21).Width = 70
            Fg.Cols(30).Width = 70
            Fg.Cols(31).Width = 70
            Fg.Cols(32).Width = 70
            Fg.Cols(33).Width = 70
            Fg.Cols(34).Width = 70

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Fg.Redraw = True
    End Sub

    Private Sub FrmActivos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Activos")
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"

            Dim f As New FrmActivosAE With {
                .MdiParent = MainRibbonForm.Owner
            }
            f.ShowDialog()

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            Dim f As New FrmActivosAE With {
                .MdiParent = MainRibbonForm.Owner
            }
            f.ShowDialog()

            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then

                SQL = "UPDATE GCACTIVOS SET STATUS = 'B' WHERE  CLAVE = '" & Fg(Fg.Row, 1) & "'"
                Dim cmd As New SqlCommand With {.Connection = cnSAE, .CommandText = SQL}

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

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "ACTIVOS")
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Sub TITULOS()
        Try
            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1
            Fg.Cols.Count = 36

            Fg.Styles.Fixed.WordWrap = True

            Fg.Rows(0).Height = 50
            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c15 As Column = Fg.Cols(2)
            c15.DataType = GetType(String)

            Fg(0, 3) = "Descripción"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Fecha de adquisición"
            Dim c7 As Column = Fg.Cols(4)
            c7.DataType = GetType(DateTime)

            Fg(0, 5) = "Monto original"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "% Vida util rem."
            Dim c11 As Column = Fg.Cols(6)
            c11.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Valor de mercado"
            Dim c9 As Column = Fg.Cols(7)
            c9.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Tipo de activo"
            Dim c2 As Column = Fg.Cols(8)
            c2.DataType = GetType(Int16)

            Fg(0, 9) = "Localización"
            Dim c4 As Column = Fg.Cols(9)
            c4.DataType = GetType(String)

            Fg(0, 10) = "Departamento"
            Dim c17 As Column = Fg.Cols(10)
            c17.DataType = GetType(Int16)

            Fg(0, 11) = "Número de serie"
            Dim c19 As Column = Fg.Cols(11)
            c19.DataType = GetType(String)

            Fg(0, 12) = "Responsable del activo"
            Dim c39 As Column = Fg.Cols(12)
            c39.DataType = GetType(String)

            Fg(0, 13) = "Fecha inicio depreciación contable"
            Dim c21 As Column = Fg.Cols(13)
            c21.DataType = GetType(DateTime)

            Fg(0, 14) = "Tasa de depreciación contable"
            Dim c13 As Column = Fg.Cols(14)
            c13.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Depreciación acumulada contable" '"DEPACUFISC"
            Dim c23 As Column = Fg.Cols(15)
            c23.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Metodo depreciación fiscal"
            Dim c12 As Column = Fg.Cols(16)
            c12.DataType = GetType(String)

            Fg(0, 17) = "Fecha inicio depreciación fiscal"
            Dim c22 As Column = Fg.Cols(17)
            c22.DataType = GetType(DateTime)

            'BANDEDINM
            Fg(0, 18) = "Deducción inmediata"
            Dim cc17 As Column = Fg.Cols(18)
            cc17.DataType = GetType(Int16)

            Fg(0, 19) = "Tasa de depreciación fiscal"
            Dim c14 As Column = Fg.Cols(19)
            c14.DataType = GetType(Decimal)
            Fg.Cols(19).Format = "###,###,##0.00"

            Fg(0, 20) = "Depresiación acumulada fisacal"
            Dim c10 As Column = Fg.Cols(20)
            c10.DataType = GetType(Decimal)
            Fg.Cols(20).Format = "###,###,##0.00"

            Fg(0, 21) = "Monto máximo deducible fiscal"
            Dim c8 As Column = Fg.Cols(21)
            c8.DataType = GetType(Decimal)
            Fg.Cols(21).Format = "###,###,##0.00"

            Fg(0, 22) = "Poliza de seguro"
            Dim c26 As Column = Fg.Cols(22)
            c26.DataType = GetType(String)

            Fg(0, 23) = "Compañia aseguradora"
            Dim c27 As Column = Fg.Cols(23)
            c27.DataType = GetType(String)

            Fg(0, 24) = "Agente de seguro"
            Dim c28 As Column = Fg.Cols(24)
            c28.DataType = GetType(String)

            Fg(0, 25) = "Teléfono siniestro"
            Dim c29 As Column = Fg.Cols(25)
            c29.DataType = GetType(String)

            Fg(0, 26) = "Tipo cobertura"
            Dim c30 As Column = Fg.Cols(26)
            c30.DataType = GetType(String)

            Fg(0, 27) = "Monto asegurado"
            Dim c31 As Column = Fg.Cols(27)
            c31.DataType = GetType(Decimal)
            Fg.Cols(27).Format = "###,###,##0.00"

            Fg(0, 28) = "Prima total"
            Dim c32 As Column = Fg.Cols(28)
            c32.DataType = GetType(Decimal)
            Fg.Cols(28).Format = "###,###,##0.00"

            Fg(0, 29) = "Deducible"
            Dim c33 As Column = Fg.Cols(29)
            c33.DataType = GetType(Decimal)
            Fg.Cols(29).Format = "###,###,##0.00"

            Fg(0, 30) = "Fecha vigencia"
            Dim c34 As Column = Fg.Cols(30)
            c34.DataType = GetType(DateTime)

            Fg(0, 31) = "Fecha próximo mantenimiento"
            Dim c35 As Column = Fg.Cols(31)
            c35.DataType = GetType(DateTime)

            Fg(0, 32) = "Fecha último mantenimiento"
            Dim c36 As Column = Fg.Cols(32)
            c36.DataType = GetType(DateTime)

            Fg(0, 33) = "Periodo mantenimiento"
            Dim c37 As Column = Fg.Cols(33)
            c37.DataType = GetType(Int16)

            Fg(0, 34) = "Costo mantenimiento"
            Dim c38 As Column = Fg.Cols(34)
            c38.DataType = GetType(Decimal)
            Fg.Cols(34).Format = "###,###,##0.00"

            Fg(0, 35) = "Observaciones"
            Dim c24 As Column = Fg.Cols(35)
            c24.DataType = GetType(String)

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To 0 'Fg.Cols.Count - 1
                    Fg(0, k) = k & " " & Fg(0, k)
                Next
            End If

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
End Class