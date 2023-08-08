Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmMinveSeguimiento
    Private CVE_CPTO_OT_SAL As Integer

    Private Sub FrmMinveSeguimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fg.Rows.Count = 1

        Fg.Rows(0).Height = 40
        Fg.Cols(0).Width = 100
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - 150

    End Sub

    Private Sub FrmMinveSeguimiento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Generar Minve no realizados")
        Me.Dispose()
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Try
            Dim REFER As String = "", CVE_ORD As String, ORDEN As String, CVE_ART As String, j As Long = 0, z As Long = 0, CVE_CPTO As Integer
            Dim CANT As Decimal = 0
            Me.Cursor = Cursors.WaitCursor
            Fg.Cursor = Cursors.WaitCursor

            Fg.Redraw = False
            Fg.Rows.Count = 1
            chOcultarMovsRealzaidos.Checked = False

            Using cmd As SqlCommand = cnSAE.CreateCommand
                'UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'M', HORA2 = 'MINVE', CVE_PROV = '" & CVE_FOLIO &

                SQL = "SELECT O.FECHA, P.CVE_ORD, P.CVE_ART, P.CANT, P.STATUS, P.HORA2, P.CVE_PROV, P.CVE_ALM, P.UUID, P.GUID, P.FECHAELAB
                    FROM GCORDEN_TRA_SER_EXT P 
                    LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD 
                    LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                    WHERE O.STATUS <> 'C' AND P.CVE_ART <> 'TOT' AND P.STATUS <> 'C' AND I.TIPO_ELE = 'P' AND O.ESTATUS = 'AUTORIZADA'
                    ORDER BY TRY_CAST(P.CVE_ORD AS INT) DESC"

                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CVE_ORD = dr("CVE_ORD")
                        ORDEN = "OT" & CVE_ORD
                        CVE_ART = dr("CVE_ART")
                        Try
                            REFER = ""
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT ISNULL(REFER,'') AS REF, (CANT * SIGNO) AS CANTIDAD, CVE_CPTO 
                                    FROM MINVE" & Empresa & " WHERE 
                                    SUBSTRING(REFER,1," & (CVE_ORD.Length + 2) & ") = '" & ORDEN & "' AND CVE_ART = '" & CVE_ART & "'"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.HasRows Then
                                        Do While dr2.Read
                                            REFER = REFER & dr2("REF") & " "
                                            CVE_CPTO = dr2("CVE_CPTO")
                                            CANT = dr2("CANTIDAD")
                                        Loop
                                    Else
                                        z = z + 1
                                        CANT = 0
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        j = j + 1
                        Lt1.Text = "Total movimientos " & j & " movimientos no realizados " & z

                        Fg.AddItem(j & vbTab & IIf(REFER.Trim.Length > 0, False, True) & vbTab & REFER & vbTab & dr("CVE_ORD") & vbTab & dr("FECHA") & vbTab &
                                   CVE_CPTO & vbTab & CVE_ART & vbTab & dr("CANT") & vbTab & CANT & vbTab & dr("CVE_ALM") & vbTab & dr("STATUS") & vbTab &
                                   dr("HORA2") & vbTab & dr("CVE_PROV") & vbTab & dr("UUID") & vbTab & dr("GUID") & vbTab & dr("FECHAELAB"))
                        If REFER.Trim.Length > 0 Then
                            Fg.Rows(Fg.Rows.Count - 1).Visible = False
                        End If
                    End While
                End Using
            End Using

        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default

        MsgBox("Proceso terminado")
    End Sub

    Private Sub BarGenMinve_Click(sender As Object, e As ClickEventArgs) Handles BarGenMinve.Click
        Dim CVE_ART As String = "", CVE_ORD As String = ""
        Dim CVE_CPTO As Integer = 60, FACTOR_CON As Single = 1, SIGNO As Integer = -1, COSTEADO As String = "S", COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single
        Dim DESDE_INVE As String = "S", MOV_ENLAZADO As Integer = 0, TIPO_DOC As String = "M", TIPO_PROD As String = "P", ExistProd As Boolean = False
        Dim CANT As Single, PREC As Single = 0, COSTO As Single = 0, CVE_VEND As String = "", REG_SERIE As Integer = 0, UNI_MED As String = "", E_LTPD As String = ""
        Dim CVE_DOC As String = "", CLIENTE As String = "", COSTO_PROM As Single = 0, EXIST As Single = 0 : Dim ALMACEN As Integer = 0, NO_HAY_EXIST As Integer = 0
        Dim CVE_FOLIO As String = "", UUID As String = "", NO_SE_GRABO As Boolean = True, Ano As String, ErrFolio As Boolean
        Dim ALM_STR As String = "", Num As Integer = 0, FECHA As String, FECHAELAB As String

        Dim cmd As New SqlCommand

        If MsgBox("Realmente desea generar los movimientos al inventario de la orden de trabajo?", vbYesNo) = vbNo Then
            Return
        End If
        Fg.FinishEditing()
        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Red
        NewStyle1.ForeColor = Color.White

        CARGA_PARAM_INVENT()

        If CVE_CPTO_OT_SAL = 0 Then
            MsgBox("Por favor seleccione los conceptos en Parametros del sistema-Inventario")
            Return
        End If
        CVE_CPTO = CVE_CPTO_OT_SAL

        If Not Valida_Conexion() Then
            Return
        End If
        Dim regDate As DateTime
        Try
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            For k = 1 To Fg.Rows.Count - 1

                If Fg(k, 1) Then
                    CVE_ORD = Fg(k, 3)
                    FECHA = Fg(k, 4)
                    CVE_ART = Fg(k, 6)
                    CANT = Fg(k, 7)
                    ALMACEN = Fg(k, 9)
                    UUID = Fg(k, 13)

                    If IsNothing(Fg(k, 15)) Then
                        regDate = FECHA & " 09:30:00"
                    Else
                        regDate = Fg(k, 15)
                    End If
                    'Dim strDate As String = regDate.ToString("yyyy-MM-dd HH:mm:ss")

                    FECHAELAB = regDate.ToString("yyyyMMdd HH:mm:ss")

                    If ALMACEN = 0 Then ALMACEN = 1

                    If CVE_ART.Trim.Length > 0 And CVE_ART <> "TOT" And CANT > 0 Then
                        If Not Valida_Conexion() Then
                        End If
                        EXIST = 0

                        SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                If dr2.Read Then
                                    EXIST = dr2("EXIST")
                                    UNI_MED = dr2("UNI_MED")
                                    COSTO_PROM = dr2("COSTO_PROM")
                                    TIPO_PROD = dr2("TIPO_ELE")

                                    COSTO = COSTO_PROM
                                    COSTO_PROM_INI = COSTO_PROM
                                    COSTO_PROM_FIN = COSTO_PROM
                                    ExistProd = True
                                End If
                            End Using
                        End Using

                        If TIPO_PROD = "P" And ExistProd Then

                            CVE_DOC = "OT" & CVE_ORD & "/" & Format(Now.Hour, "00") & Format(Now.Second, "00") & Now.Day & Now.Month & Now.Year
                            If CVE_DOC.Length > 20 Then
                                CVE_DOC = CVE_DOC.Substring(0, 20)
                            End If

                            ErrFolio = False

                            CVE_FOLIO = GET_CVE_FOLIO()
                            If CVE_FOLIO.Trim.Length = 0 Or CVE_FOLIO = "-" Then
                                Ano = DateTime.Now.Year.ToString
                                Ano = Ano.Substring(Ano.Length - 1, 1)
                                CVE_FOLIO = Ano & Format(DateTime.Now.Month, "00") & Format(DateTime.Now.Day, "00") & Format(DateTime.Now.Hour, "00") &
                                Format(DateTime.Now.Minute, "00")
                            End If

                            SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV, 
                                VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, CVE_FOLIO, TIPO_PROD, 
                                FACTOR_CON, FECHAELAB, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) 
                                VALUES ('" & CVE_ART & "','" & ALMACEN & "',(SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" &
                                CVE_CPTO & "','" & FSQL(FECHA) & "','" & TIPO_DOC & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" &
                                CANT & "','" & CANT & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                                "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                            If MULTIALMACEN = 1 Then
                                SQL = SQL & "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                            Else
                                SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                            End If 'CVE_FOLIO
                            SQL = SQL & CVE_FOLIO & "','" & TIPO_PROD & "','" & FACTOR_CON & "','" & FECHAELAB & "','" & SIGNO & "','" & COSTEADO & "','" &
                                COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" & COSTO_PROM & "')"

                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery.ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                            Try '- TERMINA INSERT INTO MINVE               - TERMINA INSERT INTO MINVE
                                SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If

                                SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'M', HORA2 = 'MINVE', GUID = 'REGEN MINVE', CVE_PROV = '" & CVE_FOLIO &
                                    "', FECHAELAB = '" & FECHAELAB & "' WHERE UUID = '" & UUID & "'"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If

                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCORDEN_TRABAJO_EXT SET ESTATUS = 'AUTORIZADA' WHERE CVE_ORD = '" & CVE_ORD & "'"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery.ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If

                End If
            Next
            'FINALZIAR ODEN DE TRABAJO

            Me.Cursor = Cursors.WaitCursor

            Fg.Rows.Count = 1

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV, ISNULL(CVE_CPTO_OT,0) AS CVE_CPTOOT, " &
                "ISNULL(CVE_CPTO_OT_SAL,0) AS CVE_CPTOOT_SAL, CVE_ART_TOT " &
                "FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                CVE_CPTO_OT_SAL = dr("CVE_CPTOOT_SAL")
            End If
            dr.Close()

        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub ChOcultarMovsRealzaidos_CheckedChanged(sender As Object, e As EventArgs) Handles chOcultarMovsRealzaidos.CheckedChanged
        Try
            Fg.Redraw = False
            If chOcultarMovsRealzaidos.Checked Then
                For k = 1 To Fg.Rows.Count - 1
                    If Not Fg(k, 1) Then
                        Fg.Rows(k).Visible = True
                    End If
                Next
            Else
                For k = 1 To Fg.Rows.Count - 1
                    If Not Fg.Rows(k).IsVisible Then
                        Fg.Rows(k).Visible = False 
                    End If
                Next
            End If
            Fg.Redraw = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Minve. no generados")
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarKardex_Click(sender As Object, e As ClickEventArgs) Handles BarKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 6) 'CVE_ART
                Var5 = Var4
                If Var4.Trim.Length > 0 Then
                    frmKardex.ShowDialog()
                Else
                    MessageBox.Show("Por favor seleccione un artículo")
                End If
            End If
        Catch ex As Exception
            Bitacora("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
