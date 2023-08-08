Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Input
Imports System.Data.SqlClient
Public Class FrmKardex
    Private CADENA As String
    Private Sub frmKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        CARGA_PARAM_INVENT()

        If MULTIALMACEN = 1 Then
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT * FROM ALMACENES" & Empresa & " WHERE CVE_ALM <> 1 ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                cboAlmacen.Items.Add("Todos")
                Do While dr.Read
                    cboAlmacen.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
                Loop
                dr.Close()
                cboAlmacen.SelectedIndex = 0

                FgA.Rows.Count = 1
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT M.CVE_ALM, DESCR, M.EXIST
                    FROM MULT" & Empresa & " M
                    LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = M.CVE_ALM
                    WHERE CVE_ART = '" & Var4 & "' ORDER BY CVE_ALM"
                    cmd2.CommandText = SQL
                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                        While dr2.Read
                            FgA.AddItem("" & vbTab & dr2("CVE_ALM") & vbTab & dr2("DESCR") & vbTab & dr2("EXIST"))
                        End While
                    End Using
                End Using

            Catch ex As Exception
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            cboAlmacen.Visible = False
            FgA.Visible = False
        End If

        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - 150
        Fg.Cols(0).Width = 50

        DESPLEGAR()

    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            AFEC_TABLA_INVE = 1
            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                AFEC_TABLA_INVE = dr("AFE_TAB_INV")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim Sigue As Boolean
            Dim TipoDoc As String
            Dim CVE_DOC_FAC As String
            Dim USER_FAC As String
            Dim CVE_PROV As String
            Dim ENTRADAS As Single
            Dim SALIDAS As Single
            Dim k As Integer = 1

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            TipoDoc = ""
            CVE_DOC_FAC = ""
            USER_FAC = ""
            CVE_PROV = ""
            ENTRADAS = 0
            SALIDAS = 0

            Lt1.Text = Var4
            L1.Text = Var5

            SQL = "SELECT M.CVE_ART, M.NUM_MOV, M.ALMACEN, M.CVE_CPTO, M.FECHA_DOCU, I.DESCR AS DES, I.CTRL_ALM, I.UNI_ALT, I.STOCK_MIN, 
                I.STOCK_MAX, I.FCH_ULTCOM, I.FCH_ULTCOM, I.UNI_MED, I.COSTO_PROM, ISNULL(I.EXIST,0) AS EXISTE, I.TIP_COSTEO, M.SIGNO, M.COSTO,
                M.FECHA_DOCU, M.FECHAELAB, M.CLAVE_CLPV, M.CANT, M.REFER, M.EXISTENCIA, M.COSTEADO, C.DESCR AS DES_CONM, M.DESDE_INVE, 
                TIPO_DOC, NUM_MOV
                FROM MINVE" & Empresa & " M
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                LEFT JOIN CONM" & Empresa & " C ON M.CVE_CPTO = C.CVE_CPTO
                WHERE M.CVE_ART = '" & Var4 & "'" & CADENA & " ORDER BY M.NUM_MOV DESC"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Sigue = True
            If dr.HasRows Then
                Do While dr.Read
                    If Sigue Then
                        Sigue = False
                        L1.Text = dr("DES").ToString
                        Lt2.Text = dr("UNI_ALT").ToString
                        Lt3.Text = dr("UNI_MED").ToString
                        Lt4.Text = dr("CTRL_ALM").ToString
                        Lt5.Text = dr("STOCK_MIN").ToString
                        Lt6.Text = dr("STOCK_MAX").ToString
                        Lt7.Text = dr("FCH_ULTCOM").ToString
                        Lt8.Text = IIf(dr("TIP_COSTEO").ToString = "P", "Promedio", dr("TIP_COSTEO").ToString)
                        Lt9.Text = Format(dr("COSTO_PROM"), "###,###,##0.00")
                        Lt10.Text = Format(dr("Existe"), "###,###,##0.00")
                    End If
                    Select Case dr("TIPO_DOC").ToString
                        Case "c"
                            TipoDoc = "Compra"
                        Case "r"
                            TipoDoc = "Recepción"
                        Case "C"
                            TipoDoc = "Cotizacion"
                        Case "P"
                            TipoDoc = "Pedido"
                        Case "R"
                            TipoDoc = "Remision"
                        Case "V"
                            TipoDoc = "Nota de venta"
                        Case "M"
                            TipoDoc = "Movimiento al inventario"
                        Case "D"
                            TipoDoc = "Devolución"
                        Case "F"
                            TipoDoc = "Factura"
                    End Select
                    CVE_DOC_FAC = "" : USER_FAC = ""
                    CVE_PROV = dr.ReadNullAsEmptyString("CLAVE_CLPV").ToString

                    Fg.AddItem(k & vbTab & dr("CVE_CPTO") & vbTab & dr("NUM_MOV") & vbTab & dr("REFER") & vbTab & (dr("CANT") * dr("SIGNO")) & vbTab &
                       dr("Existencia") & vbTab & dr("COSTO") & vbTab & dr("Almacen") & vbTab & dr("Existencia") & vbTab & dr("DES_CONM") & vbTab & dr("NUM_MOV") & vbTab &
                       dr("FECHA_DOCU") & vbTab & dr("FECHAELAB") & vbTab & TipoDoc & vbTab & IIf(dr("COSTEADO") = "S", "Si", "No") & vbTab &
                       IIf(dr("DESDE_INVE") = "S", "Si", "No") & vbTab & CVE_PROV & vbTab & CVE_DOC_FAC & vbTab & USER_FAC)
                    k += 1
                    CVE_DOC_FAC = ""
                    USER_FAC = ""
                    CVE_PROV = ""

                    If dr("CVE_CPTO") < 51 Then
                        ENTRADAS += dr("CANT")
                    Else
                        SALIDAS += dr("CANT")
                    End If

                Loop
                Lt11.Text = Format(ENTRADAS, "###,###,##0.00")
                Lt12.Text = Format(SALIDAS, "###,###,##0.00")
            End If
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmKardex_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Kardex" & Lt1.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cboAlmacen_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles cboAlmacen.DropDownClosed
        Try
            Dim ALMACEN As Integer
            ALMACEN = 1
            If cboAlmacen.SelectedIndex > -1 Then
                If cboAlmacen.SelectedIndex = 0 Then
                    CADENA = ""
                Else
                    ALMACEN = Val(cboAlmacen.Items(cboAlmacen.SelectedIndex).ToString.Substring(0, 2))
                    CADENA = " AND ALMACEN = " & ALMACEN
                End If
                DESPLEGAR()
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles BarRefresh.Click
        DESPLEGAR()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
