Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmPreOCDocs
    Private CADENA As String
    Private TIPO_COMPRA_LOCAL As String
    Private N_TOP As String = " TOP 5000 "
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub CARGAR_DATOS1()
        Dim ThemeLocal As String

        Me.WindowState = FormWindowState.Maximized
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        SplitM.BorderWidth = 1
        SplitM.Dock = DockStyle.Fill
        Fg.Dock = DockStyle.Fill
        Try
            TIPO_COMPRA_LOCAL = TIPO_COMPRA
            ThemeLocal = ThemeElekos

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeLocal, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

            CARGA_PARAM_INVENT()
            Me.KeyPreview = True
            Fg.Rows.Count = 1

            Fg.Rows(0).Height = 50
            DERECHOS()
            'CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "' ORDER BY FECHA_DOC DESC"
            TITULOS()
            CADENA = "  ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPreOrdenDeCompraDocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
    End Sub
    Sub DERECHOS()
        Dim z As Integer = 0

        If Not pwPoder Then
            Try
                BarNueva.Visible = False
                BarModificar.Visible = False
                BarCancelar.Visible = False
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 71000 AND CLAVE < 71500"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 71001
                                    BarNueva.Visible = True
                                Case 71030
                                    BarModificar.Visible = True
                                Case 71060
                                    BarCancelar.Visible = True
                            End Select
                            z += 1
                        End While
                    End Using
                End Using
                If z = 0 Then
                    BarNueva.Visible = True
                    BarModificar.Visible = True
                    BarCancelar.Visible = True
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(CVE_ART_RNBDO,'') AS ART_RBDO, ISNULL(CVE_ART_REPARA,'') AS ART_REPARA, 
                ISNULL(CVE_CPTO_RENOVADO,0) AS CVE_CPTO_REN, ISNULL(CVE_CPTO_RENOVADO_ENT,0) AS CVE_CPTO_REN_ENT
                FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Fg.Rows.Count = 1
        Fg.Redraw = False
        Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, S4 As Decimal = 0, S5 As Decimal = 0, S6 As Decimal = 0

        Try
            SQL = "SELECT " & N_TOP & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, C.STATUS, C.SU_REFER, C.FECHA_DOC, C.FECHA_REC, C.FECHA_PAG, 
                C.FECHA_CANCELA, C.CAN_TOT, C.IMP_TOT1, C.IMP_TOT2, C.IMP_TOT3, C.IMP_TOT4, C.DES_TOT, C.DES_FIN, C.NUM_ALMA, 
                C.FECHAELAB, C.IMPORTE, C.TIP_DOC_ANT  AS TIPO_D_ANT, ISNULL(C.DOC_ANT,'') AS DOCANT, C.TIP_DOC_SIG AS TIPO_D_SIG, 
                ISNULL(C.DOC_SIG,'') AS DOCSIG, TIP_DOC AS OT
                FROM COMPO_PRE C
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV " &
                CADENA
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE") & vbTab &
                                dr("STATUS") & vbTab & dr("SU_REFER") & vbTab & dr("FECHA_DOC") & vbTab & dr("FECHA_REC") & vbTab &
                                dr("FECHA_PAG") & vbTab & dr("FECHA_CANCELA") & vbTab & dr("CAN_TOT") & vbTab & dr("IMP_TOT1") & vbTab &
                                dr("IMP_TOT2") & vbTab & dr("IMP_TOT3") & vbTab & dr("IMP_TOT4") & vbTab & dr("IMPORTE") & vbTab &
                                dr("DES_TOT") & vbTab & dr("DES_FIN") & vbTab & dr("NUM_ALMA") & vbTab & dr("FECHAELAB") & vbTab &
                                dr("TIPO_D_ANT") & vbTab & dr("DOCANT") & vbTab & dr("TIPO_D_SIG") & vbTab & dr("DOCSIG"))
                            S1 += dr("CAN_TOT")
                            S2 += dr("IMP_TOT1")
                            S3 += dr("IMP_TOT2")
                            S4 += dr("IMP_TOT3")
                            S5 += dr("IMP_TOT4")
                            S6 += dr("IMPORTE")
                        End While
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab &
                           S1 & vbTab & S2 & vbTab & S3 & vbTab & S4 & vbTab & S5 & vbTab & S6)
                    End Using
                End Using
            Catch SQLex As SqlException
                Dim SSS As SqlError, Sqlcadena As String = ""
                For Each SSS In SQLex.Errors
                    Sqlcadena += SSS.Message & vbNewLine
                Next
                BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()

            AJUSTA_COLUMNAS_FG(Fg, 0, 1)

            'FGNUMERS(Fg)

            N_TOP = " TOP 1000 "
            LtNUm.Text = "Registros : " & Fg.Rows.Count - 1
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub FrmPreOrdenDeCompraDocs_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Pre-Ordenes de Compra")
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        Try
            N_TOP = " TOP 1000 "
            CADENA = " ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles BarCancelar.Click
        Try
            Dim CVE_DOC As String
            Dim DOC_SIG As String = "", TIP_DOC_SIG As String = "", TIP_DOC_ANT As String = "", DOC_ANT As String = ""
            Dim EXISTEN_ABONOS As Boolean = False

            Dim cmd As New SqlCommand With {.Connection = cnSAE, .CommandTimeout = 120}

            If Fg.Row <= 0 Then
                MsgBox("Por favor seleccione una compra")
                Return
            End If

            CVE_DOC = Fg(Fg.Row, 1)

            If MsgBox("Realmente desea cancelar documento " & CVE_DOC & "?", vbYesNo) = vbNo Then
                Exit Sub
            End If

            If Fg(Fg.Row, 4) = "C" Then
                MsgBox("El documento ya se encuentra cancelado")
                Exit Sub
            End If

            SQL = "UPDATE COMPO_PRE SET STATUS = 'C', ENLAZADO = 'O', TIP_DOC_ANT = '', DOC_ANT = '' 
                   WHERE CVE_DOC = '" & CVE_DOC & "'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If

            N_TOP = " TOP 1000 "
            CADENA = "  ORDER BY FECHAELAB DESC"
            DESPLEGAR()
            MsgBox("El documento se cancelo satisfactoriamente")
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Pre orden de compra")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarModificar_Click(sender As Object, e As EventArgs) Handles BarModificar.Click
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 4) = "C" Then
                    Var6 = "C"
                Else
                    Var6 = ""
                End If
                Var11 = "edit"
                Var12 = Fg(Fg.Row, 1)
                Var13 = Fg(Fg.Row, 23) 'DOCUMENTO SIGUIENTE
                Var14 = Fg(Fg.Row, 20) 'DOCUMENTO ANTERIOR
                'Fg(0, 23) = "Documento siguiente"
                Var17 = ""
                If Var12.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione un documento")
                    Return
                End If

                CREA_TAB(FrmPreOCCompra, "Pre-Orden de compra")
            Else
                MsgBox("Por favor seleccione un documento")
            End If
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        TBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "' ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        TBox.Text = ""
        dt = dt.AddDays(-1)
        N_TOP = ""
        CADENA = " WHERE FECHA_DOC = '" & FSQL(dt) & "' ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        TBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        TBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        TBox.Text = ""
        N_TOP = ""
        CADENA = " ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BarNueva_Click(sender As Object, e As EventArgs) Handles BarNueva.Click
        Var17 = ""
        Var11 = "nueva"
        Var12 = ""
        Var13 = ""

        If FORM_IS_OPEN("FrmPreOCCompra") Then
            FrmPreOCCompra.Close()
            FrmPreOCCompra.Dispose()
        End If

        CREA_TAB(FrmPreOCCompra, "Pre-Orden de compra")
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles TBox.TextChanged
        Try
            CADENA = "WHERE (UPPER(CVE_DOC) LIKE '%" & TBox.Text & "%' OR CVE_CLPV LIKE '%" & TBox.Text & "%' OR 
                    UPPER(NOMBRE) LIKE '%" & TBox.Text & "%') ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, 1))
        Catch ex As Exception
        End Try
        Try
            BarModificar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub TITULOS()
        Try

            Fg.Cols.Count = 24

            Fg(0, 1) = "Documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Proveedor"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Estatus"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Su refer."
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Fecha"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg(0, 7) = "Fecha rec."
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(DateTime)

            Fg(0, 8) = "Fecha pag."
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(DateTime)

            Fg(0, 9) = "Fecha cancelada"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(DateTime)

            Fg(0, 10) = "Sub. tottal"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "IEPS"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Retención ISR"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Retención IVA"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "IVA"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Importe"
            Dim c19 As Column = Fg.Cols(15)
            c19.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Descuento"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "Des. fin."
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "Almacen"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(Int32)

            Fg(0, 19) = "Fecha elab."
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(DateTime)

            Fg(0, 20) = "Tipo documento anterior"
            Dim c20 As Column = Fg.Cols(20)
            c20.DataType = GetType(String)

            Fg(0, 21) = "Documento anterior"
            Dim c21 As Column = Fg.Cols(21)
            c21.DataType = GetType(String)

            Fg(0, 22) = "Tipo documento siguiente"
            Dim c22 As Column = Fg.Cols(22)
            c22.DataType = GetType(String)

            Fg(0, 23) = "Documento siguiente"
            Dim c23 As Column = Fg.Cols(23)
            c23.DataType = GetType(String)

            Fg.Cols(9).Width = 80
            Fg.Cols(20).Width = 100
            Fg.Cols(22).Width = 100

            Fg.Cols(9).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(20).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(22).TextAlign = TextAlignEnum.CenterCenter


        Catch ex As Exception

        End Try
    End Sub
End Class