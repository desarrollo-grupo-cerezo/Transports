
Imports System.Data.SqlServerCe
Imports System.Xml
Imports C1.Win.C1FlexGrid
Imports System.IO
Imports System.Data.SqlClient
Imports System.Globalization

Public Class FrmUtilerias
    Private TotalCFD As Decimal
    Private SubtotalCFD As Decimal
    Private IVAcfd As Decimal
    Private RETcfd As Decimal
    Private UUIDR As String
    Private SerieCFD As String, FolioCFD As Long, FechaEmision As String, VersionCFD As String
    Private MonedaCFD As String, FormaPagoCFD As String, TipoComprobanteCFD As String, UsoCFDICFD As String
    Private TIPO_RELACION As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmUtilerias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        Fg.Width = Me.Width - 25
        Fg.Height = Me.Height - barSalir.Height - 50

        Fg.Cols.Count = 6
        Fg(0, 0) = ""
        Fg(0, 1) = "Articulo"
        Fg(0, 2) = "Descripcion"
        Fg(0, 3) = "almacen"
        Fg(0, 4) = "costo"
        Fg(0, 5) = "Cantidad"
    End Sub

    Private Sub FrmUtilerias_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("UTILERIAS")
    End Sub

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Sub GRABAR_MINVE()
        Dim CANT As Single, CVE_ART As String, COSTO As Single
        Dim CVE_ESQIMPU As Integer = 1, CANT_COST As Decimal
        Dim CLAVE_CLPV As String = "", PREC As Single, IMPU2 As Single, IMPU3 As Single, ACT_INV As String, TIP_CAM As Integer, TIPO_ELEM As String, TIPO_PROD As String
        Dim CVE_OBS As Integer, REG_SERIE As Integer, E_LTPD As Integer, FACTCONV As Single, MINDIRECTO As Integer, NUM_MOV As Long, MAN_IEPS As String
        Dim APL_MAN_IMP As Single, CUOTA_IEPS As Single, APL_MAN_IEPS As String, MTO_PORC As Single, MTO_CUOTA As Single, NUM_ALM As Integer
        Dim STATUS As String, TIP_DOC As String, Vend As String = ""
        Dim CTLPOL As Integer, ESCFD As String, CONTADO As String, BLOQ As String, DES_FIN_PORC As Single
        Dim TIP_DOC_SIG As String, DOC_SIG As String, FORMAENVIO As String, COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single, DESDE_INVE As String

        Dim CADENA_EXIST As String, EXIST_G As String, FACTOR_CON As Integer, COSTEADO As String
        Dim CVE_CPTO As Integer, REFER As String, UNI_VENTA As String, SIGNO As Integer, MOV_ENLAZADO As Integer, FECHA As String

        CVE_OBS = 0
        STATUS = "E" : TIP_DOC = "M"
        CTLPOL = 0 : ESCFD = "N" : CONTADO = "N" : BLOQ = "N" : DES_FIN_PORC = 0
        TIP_DOC_SIG = "" : DOC_SIG = "" : FORMAENVIO = ""
        PREC = 0 : IMPU2 = 0 : IMPU3 = 0 : ACT_INV = "S" : TIP_CAM = 1 : TIPO_ELEM = "N" : TIPO_PROD = "P"
        CVE_OBS = 0 : REG_SERIE = 0 : E_LTPD = 0 : FACTCONV = 1 : MINDIRECTO = 0 : NUM_MOV = 0 : MAN_IEPS = "N" : APL_MAN_IMP = 1
        CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0 : FACTOR_CON = 1 : COSTEADO = "" : DESDE_INVE = "" : MOV_ENLAZADO = 0
        UNI_VENTA = "PZ"
        SIGNO = 1
        CVE_CPTO = 8
        FECHA = "20210301"
        REFER = "IMCG"

        Try
            For k = 1 To Fg.Rows.Count - 1
                'Fg.AddItem("" & vbTab & CVE_ART & vbTab & dr("DES") & vbTab & "0" & vbTab & dr("COST") & vbTab & NCANT)
                CVE_ART = Fg(k, 1)
                NUM_ALM = Fg(k, 3)
                COSTO = Fg(k, 4)
                CANT = Fg(k, 5)
                CANT = Math.Abs(CANT)

                COSTO_PROM_INI = COSTO
                COSTO_PROM_FIN = COSTO

                EXIST_G = "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')" 'EXIST_G
                If MULTIALMACEN = 1 Then
                    CADENA_EXIST = "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM & "),0)"   'EXISTENCIA
                Else
                    CADENA_EXIST = "COALESCE((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),0)"  'EXISTENCIA
                End If

                SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV, VEND, 
                    CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON, FECHAELAB, 
                    CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO) OUTPUT Inserted.NUM_MOV VALUES('" &
                    CVE_ART & "','" & NUM_ALM & "',(SELECT COALESCE(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" & CVE_CPTO & "','" &
                    FECHA & "','" & TIP_DOC & "','" & REFER & "','" & CLAVE_CLPV & "','" & Vend & "','" &
                    CANT & "','" & CANT_COST & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" & UNI_VENTA & "','" & E_LTPD & "'," &
                    EXIST_G & "," & CADENA_EXIST & ",'" & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),
                    (SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" & SIGNO & "','" & COSTEADO & "','" &
                    COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "')"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Next
            MessageBox.Show("Proceso terminado")
            Fg.Rows.Count = 1
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BtnAsignarLlantas_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As EventArgs)
        Dim CVE_ART As String, k As Long = 1, NCANT As Decimal

        Fg.Rows.Count = 1


        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT M.CVE_ART, MAX(DESCR) AS DES, ISNULL(SUM(CANT * SIGNO),0) AS NCANT, MAX(COSTO) AS COST 
                  FROM MINVE" & Empresa & " M
                  LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                  GROUP BY M.CVE_ART"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        Application.DoEvents()

                        CVE_ART = dr("CVE_ART")
                        NCANT = dr("NCANT")
                        k = k + 1
                        If NCANT < 0 Then
                            Try
                                Fg.AddItem("" & vbTab & CVE_ART & vbTab & dr("DES") & vbTab & "1" & vbTab & dr("COST") & vbTab & NCANT)
                                'Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                'SQL = "UPDATE INVE" & Empresa & " SET ULT_COSTO = " & COSTO & ", COSTO_PROM = " & COSTO & " WHERE CVE_ART = '" & CVE_ART & "'"
                                'cmd2.CommandText = SQL
                                'returnValue = cmd2.ExecuteNonQuery().ToString
                                'If returnValue IsNot Nothing Then
                                'If returnValue = "1" Then
                                'End If
                                'End If
                                'End Using
                            Catch ex As Exception
                                Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                'MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End While
                End Using
            End Using

            Fg.AutoSizeCols()

            MessageBox.Show("Proceso terminado")

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

        Fg.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = " SELECT * FROM GCLLANTAS_MINVE WHERE TIP_DOC = 'c'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()
                        Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("NUM_ECONOMICO") & vbTab & "" & vbTab & "")
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CVE_DOC, NUM_PAR, CVE_ART, COST FROM PAR_COMPC" & Empresa & " WHERE CVE_DOC = '" & dr("CVE_DOC") & "'"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then

                                        Fg(Fg.Rows.Count - 1, 3) = dr2("cost")
                                        Try
                                            SQL = "UPDATE GCLLANTAS_MINVE SET COSTO = " & dr2("COST") & " WHERE UUID = '" & dr("UUID") & "'"
                                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                cmd3.CommandText = SQL
                                                returnValue = cmd3.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                        Try
                                            SQL = "UPDATE GCLLANTAS SET COSTO_LLANTA_MN = " & dr2("COST") & " WHERE NUM_ECONOMICO = '" & dr("NUM_ECONOMICO") & "'"
                                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                cmd3.CommandText = SQL
                                                returnValue = cmd3.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                        Try
                                            SQL = "UPDATE GCLLANTAS_MINVE SET COSTO = " & dr2("COST") & " WHERE CVE_DOC = '" & dr("DOC_ANT") & "'"
                                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                cmd3.CommandText = SQL
                                                returnValue = cmd3.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Fg.AutoSizeCols()

            MessageBox.Show("Proceso terminado")

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarAsiganrLlantas_Click(sender As Object, e As EventArgs)

        Fg.Cols.Count = 6
        Fg(0, 0) = ""
        Fg(0, 3) = "Unidad"
        Fg(0, 1) = "Num. economico"
        Fg(0, 4) = "Clave llanta"
        Fg(0, 2) = "Posicion"
        Fg(0, 5) = "Tipo Mov."

        Dim k As Long = 0, NCANT As Decimal

        Fg.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE, STATUS, CLAVEMONTE, CHLL1, CHLL2, CHLL3, CHLL4, CHLL5, CHLL6, CHLL7, CHLL8, CHLL9, CHLL10, CHLL11, CHLL12  
                    FROM GCUNIDADES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        Application.DoEvents()



                        If NCANT < 0 Then
                            k = k + 1
                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    'SQL = "UPDATE INVE" & Empresa & " SET ULT_COSTO = " & COSTO & ", COSTO_PROM = " & COSTO & " WHERE CVE_ART = '" & CVE_ART & "'"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                'MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End While
                End Using
            End Using

            Fg.AutoSizeCols()

            MessageBox.Show("Proceso terminado")

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarUpdateFechaCompRaMinve_Click(sender As Object, e As EventArgs)
        Try
            Dim FECHA_COMPRA As String, z As Integer = 0
            Fg.Rows.Count = 1
            Fg.Redraw = False

            If MsgBox("Realmente deseas actualizar fecha en minve via compr?", vbYesNo) = vbNo Then
                Return
            End If

            Fg.Cols.Count = 6
            Fg(0, 0) = ""
            Fg(0, 1) = "Tipo doc"
            Fg(0, 2) = "Documento"
            Fg(0, 3) = "Fecha"
            Fg(0, 4) = ""
            Fg(0, 5) = ""


            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM COMPR" & Empresa
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        Application.DoEvents()

                        z = z + 1
                        Lt1.Text = z

                        FECHA_COMPRA = dr("FECHA_DOC")

                        Try
                            SQL = "UPDATE MINVE" & Empresa & " SET FECHA_DOCU = '" & FSQL(FECHA_COMPRA) & "' 
                                WHERE REFER = '" & dr("CVE_DOC") & "' AND TIPO_DOC = 'r'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If CLng(returnValue) > 0 Then
                                        Fg.AddItem(returnValue & vbTab & dr("TIP_DOC") & vbTab & dr("CVE_DOC") & vbTab & FECHA_COMPRA)
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            Fg.Redraw = True
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarPedidoCartaPorte_Click(sender As Object, e As EventArgs)
        Dim CVE_DOC As String, FECHA, CVE_OPER As String, CVE_TRACTOR As String, CVE_TANQUE1 As String, CVE_TANQUE2 As String
        Dim CLAVE_O_P As String, CLAVE_D_P As String, CVE_PLAZA1_P As String, CVE_PLAZA2_P As String, CARTA_PORT As String
        Dim FOLIO_PEDIDO As String, CVE_OPER_CP As String, CVE_TRACTOR_CP As String, CVE_TANQUE1_CP As String, CVE_TANQUE2_CP
        Dim CVE_DOLLY_CP As String, CLAVE_O_CP As String, CLAVE_D_CP As String, CVE_PLAZA1_CP As String, CVE_PLAZA2_CP
        Dim Sigue As Boolean = False
        Dim RECOGER_EN_P As String, ENTREGAR_EN_P As String, RECOGER_EN_CP As String, ENTREGAR_EN_CP As String

        Try
            Dim z As Integer = 0
            Fg.Rows.Count = 1

            Fg.Cols.Count = 25

            Fg(0, 1) = "CVE_DOC"
            Fg(0, 2) = "FECHA"
            Fg(0, 3) = "CVE_OPER"
            Fg(0, 4) = "CVE_TRACTOR"
            Fg(0, 5) = "CVE_TANQUE1"
            Fg(0, 6) = "CVE_TANQUE2"
            Fg(0, 7) = "CLAVE_O_P"
            Fg(0, 8) = "CLAVE_D_P"
            Fg(0, 9) = "CVE_PLAZA1_P"
            Fg(0, 10) = "CVE_PLAZA2_P"

            Fg(0, 11) = "CARTA_PORT"
            Fg(0, 12) = "FOLIO_PEDIDO"
            Fg(0, 13) = "CVE_OPER_CP"
            Fg(0, 14) = "CVE_TRACTOR_CP"
            Fg(0, 15) = "CVE_TANQUE1_CP"
            Fg(0, 16) = "CVE_TANQUE2_CP"
            'Fg(0, 17) = "CVE_DOLLY_CP"
            Fg(0, 17) = "CLAVE_O_CP"
            Fg(0, 18) = "CLAVE_D_CP"
            Fg(0, 19) = "CVE_PLAZA1_CP"
            Fg(0, 20) = "CVE_PLAZA2_CP"

            Fg(0, 21) = "RECOGER_EN_P"
            Fg(0, 22) = "RECOGER_EN_CP"
            Fg(0, 23) = "ENTREGAR_EN_P"
            Fg(0, 24) = "ENTREGAR_EN_CP"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = " SELECT P.CVE_DOC, P.FECHA, P.CVE_OPER, P.CVE_TRACTOR, P.CVE_TANQUE1, P.CVE_TANQUE2, P.CLAVE_O AS CLAVE_O_P, P.CLAVE_D AS CLAVE_D_P, P.CVE_PLAZA1 AS CVE_PLAZA1_P, P.CVE_PLAZA2 AS CVE_PLAZA2_P, P.RECOGER_EN AS RECOGER_EN_P, P.ENTREGAR_EN AS ENTREGAR_EN_P, 
                  CP.RECOGER_EN AS RECOGER_EN_CP, CP.ENTREGAR_EN AS ENTREGAR_EN_CP,
                  CP.CVE_FOLIO AS CARTA_PORT, CP.CVE_DOCP AS FOLIO_PEDIDO, CP.CVE_OPER AS CVE_OPER_CP, CP.CVE_TRACTOR AS CVE_TRACTOR_CP, 
                  CP.CVE_TANQUE1 AS CVE_TANQUE1_CP, CP.CVE_TANQUE2 AS CVE_TANQUE2_CP, CP.CVE_DOLLY AS CVE_DOLLY_CP, 
                  CP.CLAVE_O AS CLAVE_O_CP, CP.CLAVE_D AS CLAVE_D_CP, CP.CVE_PLAZA1 AS CVE_PLAZA1_CP, CP.CVE_PLAZA2 AS CVE_PLAZA2_CP
                  FROM GCPEDIDOS P
                  INNER JOIN GCCARTA_PORTE CP ON CP.CVE_DOCP = P.CVE_DOC
                  WHERE MONTH(FECHA) = 11 AND YEAR(FECHA) = 2021"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()
                        CVE_DOC = dr("CVE_DOC")
                        FECHA = dr("FECHA")
                        CVE_OPER = dr("CVE_OPER")
                        CVE_TRACTOR = dr("CVE_TRACTOR")
                        CVE_TANQUE1 = dr("CVE_TANQUE1")
                        CVE_TANQUE2 = dr("CVE_TANQUE2")
                        CLAVE_O_P = dr("CLAVE_O_P")
                        CLAVE_D_P = dr("CLAVE_D_P")
                        CVE_PLAZA1_P = dr("CVE_PLAZA1_P")
                        CVE_PLAZA2_P = dr("CVE_PLAZA2_P")

                        CARTA_PORT = dr("CARTA_PORT")
                        FOLIO_PEDIDO = dr("FOLIO_PEDIDO")
                        CVE_OPER_CP = dr("CVE_OPER_CP")
                        CVE_TRACTOR_CP = dr("CVE_TRACTOR_CP")
                        CVE_TANQUE1_CP = dr("CVE_TANQUE1_CP")
                        CVE_TANQUE2_CP = dr("CVE_TANQUE2_CP")
                        CVE_DOLLY_CP = dr("CVE_DOLLY_CP")
                        CLAVE_O_CP = dr("CLAVE_O_CP")
                        CLAVE_D_CP = dr("CLAVE_D_CP")
                        CVE_PLAZA1_CP = dr("CVE_PLAZA1_CP")
                        CVE_PLAZA2_CP = dr("CVE_PLAZA2_CP")

                        RECOGER_EN_P = dr("RECOGER_EN_P")
                        ENTREGAR_EN_P = dr("ENTREGAR_EN_P")
                        RECOGER_EN_CP = dr("RECOGER_EN_CP")
                        ENTREGAR_EN_CP = dr("ENTREGAR_EN_CP")

                        Sigue = False

                        If CVE_TRACTOR <> CVE_TRACTOR_CP Then Sigue = True
                        If CVE_TANQUE1 <> CVE_TANQUE1_CP Then Sigue = True
                        If CVE_TANQUE2 <> CVE_TANQUE2_CP Then Sigue = True
                        If CLAVE_O_P <> CLAVE_O_CP Then Sigue = True
                        If CLAVE_D_P <> CLAVE_D_CP Then Sigue = True
                        If CVE_PLAZA1_P <> CVE_PLAZA1_CP Then Sigue = True
                        If CVE_PLAZA2_P <> CVE_PLAZA2_CP Then Sigue = True

                        If RECOGER_EN_P <> RECOGER_EN_CP Then Sigue = True
                        If ENTREGAR_EN_P <> ENTREGAR_EN_CP Then Sigue = True

                        Try
                            If Sigue Then
                                Fg.AddItem("" & vbTab & CVE_DOC & vbTab & FECHA & vbTab & CVE_OPER & vbTab & CVE_TRACTOR & vbTab & CVE_TANQUE1 & vbTab &
                                CVE_TANQUE2 & vbTab & CLAVE_O_P & vbTab & CLAVE_D_P & vbTab & CVE_PLAZA1_P & vbTab & CVE_PLAZA2_P & vbTab & CARTA_PORT & vbTab &
                                FOLIO_PEDIDO & vbTab & CVE_OPER_CP & vbTab & CVE_TRACTOR_CP & vbTab &
                                CVE_TANQUE1_CP & vbTab & CVE_TANQUE2_CP & vbTab & CLAVE_O_CP & vbTab & CLAVE_D_CP & vbTab & CVE_PLAZA1_CP & vbTab &
                                CVE_PLAZA2_CP & vbTab &
                                RECOGER_EN_P & vbTab & RECOGER_EN_CP & vbTab & ENTREGAR_EN_P & vbTab & ENTREGAR_EN_CP)
                            End If
                            SQL = ""
                            'Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            'cmd2.CommandText = SQL
                            'returnValue = cmd2.ExecuteNonQuery().ToString
                            'If returnValue IsNot Nothing Then
                            'If CLng(returnValue) > 0 Then
                            'Fg.AddItem(returnValue & vbTab & dr("TIP_DOC") & vbTab & dr("CVE_DOC") & vbTab & FECHA_COMPRA)
                            'End If
                            'End If
                            'End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                    End While
                End Using
            End Using

            Fg.AutoSizeCols()


            Fg.Redraw = True
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs)

        Try
            If MsgBox("Realmente desea actualizar tabla carta porte?", vbYesNo) = vbYes Then
                For k = 1 To Fg.Rows.Count - 1
                    SQL = "UPDATE GCCARTA_PORTE SET CVE_TRACTOR = '" & Fg(k, 4) & "', CVE_TANQUE1 = '" & Fg(k, 5) & "', CVE_TANQUE2 = '" & Fg(k, 6) & "',
                      CVE_OPER = " & Fg(k, 3) & ", CLAVE_O = '" & Fg(k, 7) & "', CLAVE_D = '" & Fg(k, 8) & "', 
                      CVE_PLAZA1 = " & Fg(k, 9) & ", CVE_PLAZA2 = " & Fg(k, 10) & ", 
                      RECOGER_EN = '" & Fg(k, 21) & "', ENTREGAR_EN = '" & Fg(k, 23) & "'
                      WHERE CVE_DOCP = '" & Fg(k, 1) & "'"

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Next
                MessageBox.Show("Proceso terminado")
                Fg.Rows.Count = 1
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarValidarComtratoVsCartaPorte_Click(sender As Object, e As EventArgs)
        'CONTRATO
        Dim CVE_CON As String, CLAVE_O_CON As String, CLAVE_D_CON As String, RECOGER_EN_CON As String, ENTREGAR_EN_CON As String
        'PEDIDO
        Dim CVE_DOC As String, CLAVE_O_P As String, CLAVE_D_P As String, RECOGER_EN_P As String, ENTREGAR_EN_P As String
        'CARTA PORTE
        Dim CVE_FOLIO As String, CLAVE_O_CP As String, CLAVE_D_CP As String, RECOGER_EN_CP As String, ENTREGAR_EN_CP As String
        Dim Sigue As Boolean = False, S1 As String, S2 As String, S3 As String

        Try
            Dim z As Integer = 0
            Fg.Rows.Count = 1

            Fg.Cols.Count = 16
            'CONTRATO
            Fg(0, 1) = "CVE_CON"
            Fg(0, 2) = "CLAVE_O_CON"
            Fg(0, 3) = "CLAVE_D_CON "
            Fg(0, 4) = "RECOGER_EN_CON "
            Fg(0, 5) = "ENTREGAR_EN_CON "
            'PEDIDO
            Fg(0, 6) = "CVE_DOC"
            Fg(0, 7) = "CLAVE_O_P"
            Fg(0, 8) = "CLAVE_D_P"
            Fg(0, 9) = "RECOGER_EN_P"
            Fg(0, 10) = "ENTREGAR_EN_P"
            'CARTA PORTE
            Fg(0, 11) = "CVE_FOLIO"
            Fg(0, 12) = "CLAVE_O_CP"
            Fg(0, 13) = "CLAVE_D_CP"
            Fg(0, 14) = "RECOGER_EN_CP"
            Fg(0, 15) = "ENTREGAR_EN_CP"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = " SELECT C.CVE_CON, C.CLAVE_O, C.CLAVE_D, C.RECOGER_EN, C.ENTREGAR_EN, 
                      P.CVE_DOC, P.CVE_CON AS CONTRATO_PED, P.NUM_TALON, P.NUM_TALON2, P.CLAVE_O AS CLAVE_O_P, P.CLAVE_D AS CLAVE_D_P, 
                      P.RECOGER_EN AS RECOGER_EN_P, P.ENTREGAR_EN AS ENTREGAR_EN_P,
                      CP.CVE_FOLIO, CP.CVE_DOCP, CP.CLAVE_O AS CLAVE_O_CP, CP.CLAVE_D AS CLAVE_D_CP, CP.RECOGER_EN AS RECOGER_EN_CP, 
                      CP.ENTREGAR_EN AS ENTREGAR_EN_CP
                      FROM GCCONTRATO C 
                      INNER JOIN GCPEDIDOS P ON P.CVE_CON = C.CVE_CON
                      INNER JOIN GCCARTA_PORTE CP ON CP.CVE_DOCP = P.CVE_DOC
                      WHERE MONTH(P.FECHA) = 11 AND YEAR(P.FECHA) = 2021"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()
                        'CONTRATO
                        CVE_CON = dr("CVE_CON")
                        CLAVE_O_CON = dr("CLAVE_O")
                        CLAVE_D_CON = dr("CLAVE_D")
                        RECOGER_EN_CON = dr("RECOGER_EN")
                        ENTREGAR_EN_CON = dr("ENTREGAR_EN")
                        'PEDIDO
                        CVE_DOC = dr("CVE_DOC")
                        CLAVE_O_P = dr("CLAVE_O_P")
                        CLAVE_D_P = dr("CLAVE_D_P")
                        RECOGER_EN_P = dr("RECOGER_EN_P")
                        ENTREGAR_EN_P = dr("ENTREGAR_EN_P")
                        'CARTA PORTE
                        CVE_FOLIO = dr("CVE_FOLIO")
                        CLAVE_O_CP = dr("CLAVE_O_CP")
                        CLAVE_D_CP = dr("CLAVE_D_CP")
                        RECOGER_EN_CP = dr("RECOGER_EN_CP")
                        ENTREGAR_EN_CP = dr("ENTREGAR_EN_CP")

                        Sigue = False
                        If CLAVE_O_CON <> CLAVE_O_P Then Sigue = True
                        If CLAVE_D_CON <> CLAVE_D_P Then Sigue = True
                        If RECOGER_EN_CON <> RECOGER_EN_P Then Sigue = True
                        If ENTREGAR_EN_CON <> ENTREGAR_EN_P Then Sigue = True

                        If CLAVE_O_CON <> CLAVE_O_CP Then Sigue = True
                        If CLAVE_D_CON <> CLAVE_D_CP Then Sigue = True
                        If RECOGER_EN_CON <> RECOGER_EN_CP Then Sigue = True
                        If ENTREGAR_EN_CON <> ENTREGAR_EN_CP Then Sigue = True
                        Try
                            If Sigue Then
                                S1 = CVE_CON & vbTab & CLAVE_O_CON & vbTab & CLAVE_D_CON & vbTab & RECOGER_EN_CON & vbTab & ENTREGAR_EN_CON & vbTab
                                S2 = CVE_DOC & vbTab & CLAVE_O_P & vbTab & CLAVE_D_P & vbTab & RECOGER_EN_P & vbTab & ENTREGAR_EN_P & vbTab
                                S3 = CVE_FOLIO & vbTab & CLAVE_O_CP & vbTab & CLAVE_D_CP & vbTab & RECOGER_EN_CP & vbTab & ENTREGAR_EN_P
                                Fg.AddItem("" & vbTab & S1 & S2 & S3)
                            End If
                            SQL = ""
                            'Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            'cmd2.CommandText = SQL
                            'returnValue = cmd2.ExecuteNonQuery().ToString
                            'If returnValue IsNot Nothing Then
                            'If CLng(returnValue) > 0 Then
                            'Fg.AddItem(returnValue & vbTab & dr("TIP_DOC") & vbTab & dr("CVE_DOC") & vbTab & FECHA_COMPRA)
                            'End If
                            'End If
                            'End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                    End While
                End Using
            End Using

            Fg.AutoSizeCols()


            Fg.Redraw = True
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarGrabarConPedCP_Click(sender As Object, e As EventArgs)
        Try
            If MsgBox("Realmente desea actualizar tabla pedidos y carta porte desde el contrato?", vbYesNo) = vbYes Then
                'PEDIDOS
                For k = 1 To Fg.Rows.Count - 1
                    SQL = "UPDATE GCPEDIDOS SET CLAVE_O = '" & Fg(k, 2) & "', CLAVE_D = '" & Fg(k, 3) & "', 
                      RECOGER_EN = '" & Fg(k, 4) & "', ENTREGAR_EN = '" & Fg(k, 5) & "' WHERE CVE_CON = '" & Fg(k, 1) & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Next

                For k = 1 To Fg.Rows.Count - 1
                    SQL = "UPDATE GCCARTA_PORTE SET CLAVE_O = '" & Fg(k, 2) & "', CLAVE_D = '" & Fg(k, 3) & "', 
                      RECOGER_EN = '" & Fg(k, 4) & "', ENTREGAR_EN = '" & Fg(k, 5) & "' WHERE CVE_DOCP = '" & Fg(k, 6) & "'"

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Next
                MessageBox.Show("Proceso terminado")
                Fg.Rows.Count = 1
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarXls_Click(sender As Object, e As EventArgs) Handles BarXls.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Utilerias")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarCxP()
        Dim CVE_CLPV As String, REFER As String = "", CVE_OBS As Integer = 0, NUM_MONED As Integer, NUM_CPTO As Integer, NUM_CARGO As Int16 = 1
        Dim TIPO_MOV As String, CVE_AUT As Integer, USUARIO2 As Integer, SIGNO As Integer, IMPORTE As Decimal, ENTREGADA As String
        Dim STATUS As String = "E", AFEC_COI As String, TCAMBIO As Int16, CAN_TOT As Decimal = 0, SIGUE As Boolean
        Dim FOLIO_GAS As Long = 0, NO_FACTURA As String, NETO As Decimal = 0, CVE_COVC As Long, J As Integer = 0

        Try
            For k = 1 To Fg.Rows.Count - 1

                Application.DoEvents()

                CVE_COVC = Fg(k, 1)
                CVE_CLPV = Fg(k, 3)
                NO_FACTURA = Fg(k, 5)
                CAN_TOT = Fg(k, 9)
                IMPORTE = Fg(k, 11)

                If Fg(k, 2) = "Cancelado" Then
                    CAN_TOT = CAN_TOT
                End If
                If IMPORTE > 0 And Fg(k, 2) <> "Cancelado" Then
                    NUM_CPTO = 1 : NUM_CARGO = 1 : AFEC_COI = "A" : NUM_MONED = 1 : TCAMBIO = 1 : TIPO_MOV = "C" : SIGNO = 1 : CVE_AUT = 0
                    USUARIO2 = "0" : ENTREGADA = "S"
                    Try
                        SIGUE = True
                        FOLIO_GAS = SIGUIENTE_FOLIO_COMPRA("c", "STAND.")
                        Do While SIGUE
                            REFER = Space(10) & Format(FOLIO_GAS, "0000000000")
                            If EXISTE_COMPRA("c", REFER) Then
                                FOLIO_GAS = FOLIO_GAS + 1
                            Else
                                SIGUE = False
                            End If
                        Loop
                    Catch ex As Exception
                        Bitacora("31. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    SQL = "IF NOT EXISTS (SELECT REFER FROM PAGA_M" & Empresa & " WHERE NO_FACTURA = '" & NO_FACTURA & "')
                        INSERT INTO PAGA_M" & Empresa & " (CVE_PROV, REFER, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, FECHA_APLI, 
                        FECHA_VENC, AFEC_COI, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, TIPO_MOV, SIGNO, USUARIO, ENTREGADA, FECHA_ENTREGA, STATUS) 
                        VALUES('" &
                        CVE_CLPV & "','" & REFER & "','" & NUM_CPTO & "','" & NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & REFER & "','" &
                        Math.Round(IMPORTE, 6) & "',CONVERT(varchar, GETDATE(), 112),CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" &
                        NUM_MONED & "','" & TCAMBIO & "','" & Math.Round(IMPORTE, 6) & "',GETDATE(),'" & TIPO_MOV & "','" & SIGNO & "','" &
                        USUARIO2 & "','" & ENTREGADA & "',CONVERT(varchar, GETDATE(), 112),'" & STATUS & "')"

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                J = J + 1
                                Fg(k, 15) = REFER
                                If CVE_COVC > 0 Then
                                    Try
                                        SQL = "UPDATE GCCONCI_VALES_COMBUS SET STATUS = 'T', REFER_PAGA_M = '" & REFER & "' 
                                        WHERE CVE_COVC = " & CVE_COVC
                                        cmd.CommandText = SQL
                                        returnValue = cmd.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    Catch ex As Exception
                                        Bitacora("154. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                        MsgBox("154. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If

                                Try
                                    SQL = "UPDATE PROV" & Empresa & " SET SALDO = COALESCE(SALDO,0) + " & Math.Round(IMPORTE, 6) & ",
                                        ULT_COMPD = '" & REFER & "', ULT_COMPM = '" & Math.Round(IMPORTE, 6) & "', 
                                        ULT_COMPF = CONVERT(varchar, GETDATE(), 112)
                                        WHERE CLAVE = '" & CVE_CLPV & "'"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                Catch ex As Exception
                                    Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    SQL = "UPDATE ACOMP" & Empresa & " SET CVTA_COM = ISNULL(CVTA_COM,0) + " & CAN_TOT & " WHERE CVE_ACOMP = " & Now.Month &
                                       " IF @@ROWCOUNT = 0
                                   INSERT INTO ACOMP" & Empresa & " (CVE_ACOMP, CVTA_COM, CDESCTO) VALUES ('" & Now.Month & "','" & CAN_TOT & "','0')"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                Catch ex As Exception
                                    Bitacora("154. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                    MsgBox("154. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                Try
                                    SQL = "UPDATE FOLIOSC" & Empresa & " SET ULT_DOC = " & FOLIO_GAS & " WHERE SERIE = 'STAND.' AND TIP_DOC = 'c'"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then

                                        End If
                                    End If
                                Catch ex As Exception
                                    Bitacora("154. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                    MsgBox("154. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End Using
                End If
            Next
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        MsgBox("Proceso terminado, cuentas por pagar afectadas " & J)
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
    Private Sub MnuActClaveCliente_Click(sender As Object, e As EventArgs) Handles MnuActClaveCliente.Click
        Dim z As Integer, CLIENTE As String, CVE_DOC As String

        Fg.Rows.Count = 1
        Try
            SQL = "SELECT isnull(FACTURA,'') AS FAC, DOCUMENT, ISNULL(P.CLIENTE,'') AS CLAVE FROM CFDI C
                LEFT JOIN GCCARTA_PORTE P ON P.CVE_FOLIO = C.DOCUMENT"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Application.DoEvents()
                        CVE_DOC = dr("FAC")
                        CLIENTE = dr("CLAVE")
                        z = z + 1
                        Lt1.Text = z
                        Try
                            SQL = "UPDATE FACTF" & Empresa & " SET CVE_CLPV = '" & CLIENTE & "' WHERE CVE_DOC = '" & CVE_DOC & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If CLng(returnValue) > 0 Then
                                        Fg.AddItem(returnValue & vbTab & CVE_DOC & vbTab & dr("DOCUMENT") & vbTab & "FACTF")
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            SQL = "UPDATE CUEN_M" & Empresa & " SET CVE_CLIE = '" & CLIENTE & "' WHERE REFER = '" & CVE_DOC & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If CLng(returnValue) > 0 Then
                                        Fg.AddItem(returnValue & vbTab & CVE_DOC & vbTab & dr("DOCUMENT") & vbTab & "CUEN_M")
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            'MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        MsgBox("Proceso terminado")
    End Sub

    Private Sub MnuObtenerCFDIyGrabar_Click(sender As Object, e As EventArgs) Handles MnuObtenerCFDIyGrabar.Click
        Dim XML_TABLA As String = "", FILE_XML As String = "", SERIE_CFDI As String, FOLIO_CFDI As Long
        Dim FECHA_TIMBRE As String, FECHA_CARGA As String = "", CVE_FOLIO1 As String, CVE_FOLIO2 As String

        Try
            SQL = "SELECT TDOC, DOCUMENT, DOCUMENT2, XML, FILE_XML FROM CFDI"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read
                        XML_TABLA = dr("XML")
                        CVE_FOLIO1 = dr("DOCUMENT")
                        CVE_FOLIO2 = dr.ReadNullAsEmptyString("DOCUMENT2")

                        If XML_TABLA.Trim.Length > 0 Then
                            FILE_XML = Application.StartupPath & "\TEMPXML_FAC.xml"
                            File.WriteAllText(FILE_XML, XML_TABLA)
                            Dim leer As LeerXML = New LeerXML
                            Dim comprobante As Comprobante = leer.ObtenerComprobante(FILE_XML)
                            Dim contador As Integer = 1

                            SERIE_CFDI = comprobante.Serie
                            If Not IsNothing(comprobante.Folio) Then
                                If IsNumeric(comprobante.Folio) Then
                                    FOLIO_CFDI = comprobante.Folio
                                End If
                            End If

                            FECHA_TIMBRE = comprobante.Complemento.TimbreFiscalDigital.FechaTimbrado.ToString("s")

                            If Not IsNothing(comprobante.Complemento.CartaPorte20) Then
                                For Each ubicacion In comprobante.Complemento.CartaPorte20.Ubicaciones.Ubicacion
                                    'ubicacion.TipoUbicacion
                                    'ubicacion.IDUbicacion
                                    'If(ubicacion.TipoUbicacion = "Origen", "remitente", "destinario")
                                    'ubicacion.RFCRemitenteDestinatario
                                    'If(ubicacion.TipoUbicacion = "Origen", "remitente", "destinario")
                                    'ubicacion.NombreRemitenteDestinatario
                                    'ubicacion.NumRegIdTrib
                                    'ubicacion.ResidenciaFiscal
                                    'ubicacion.NumEstacion
                                    'ubicacion.NombreEstacion
                                    'ubicacion.NavegacionTrafico
                                    'ubicacion.FechaHoraSalidaLlegada.ToString("s")
                                    'ubicacion.TipoEstacion & " " + ObtenerTipoEstacion(ubicacion.TipoEstacion)
                                    'ubicacion.DistanciaRecorrida.ToString("f2")
                                    If contador.ToString() = "1" Then
                                        'Recoger En"
                                        'CP_RECOGER_EN
                                        FECHA_CARGA = ubicacion.FechaHoraSalidaLlegada.ToString("s")
                                    Else
                                        'Entregar En
                                        'CP_ENTREGAR_EN
                                    End If
                                    contador = contador + 1
                                Next
                                'GRABANDO 
                                Try
                                    Dim FECHA_T As String = FECHA_TIMBRE.Replace("T", " ")
                                    Dim F_TIMBRE As String = DateTime.ParseExact(FECHA_T, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyyMMdd HH:mm:ss")

                                    Dim FECHA_CAR As String = FECHA_CARGA.Replace("T", " ")
                                    Dim F_CARGA As String = DateTime.ParseExact(FECHA_CAR, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyyMMdd HH:mm:ss")

                                    SQL = "UPDATE GCCARTA_PORTE SET FECHA_TIMBRE  = '" & F_TIMBRE & "', FECHA_CARGA_TIMBRE = '" & F_CARGA & "'
                                        WHERE CVE_FOLIO = '" & CVE_FOLIO1 & "' OR CVE_FOLIO = '" & CVE_FOLIO2 & "' AND FECHA_CARGA_TIMBRE IS NULL"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                        End If
                                    End Using
                                Catch ex As Exception
                                    MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                    Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                            'FIN IF XML_TABLA.Trim.Length > 0 Then
                        End If
                    Loop
                End Using
            End Using
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub MnuValesCombusCFDI_Click(sender As Object, e As EventArgs) Handles MnuValesCombusCFDI.Click
        Dim XML_TABLA As String = "", FILE_XML As String = "", SERIE_CFDI As String, FOLIO_CFDI As Long
        Dim CVE_COVC As Long

        Try
            SQL = "SELECT ISNULL(C.CVE_COVC,0) AS CVE_COV, C.CVE_DOC, C.CVE_PROV, C.FECHA_DOC, ISNULL(XML,'') AS F_XML
                FROM GCCONCI_VALES_COMBUS C"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read
                        XML_TABLA = OBTENER_RUTA_XML() & "\" & Path.GetFileName(dr("F_XML"))
                        CVE_COVC = dr("CVE_COV")

                        If XML_TABLA.Trim.Length > 0 Then
                            If File.Exists(XML_TABLA) Then
                                Dim leer As LeerXML = New LeerXML
                                Dim comprobante As Comprobante = leer.ObtenerComprobante(XML_TABLA)
                                Dim contador As Integer = 1

                                SERIE_CFDI = comprobante.Serie
                                If Not IsNothing(comprobante.Folio) Then
                                    If IsNumeric(comprobante.Folio) Then
                                        FOLIO_CFDI = comprobante.Folio
                                    End If
                                End If

                                Try
                                    If CVE_COVC > 0 Then
                                        SQL = "UPDATE GCCONCI_VALES_COMBUS SET SERIE_CFDI = '" & SERIE_CFDI & "', FOLIO_CFDI = '" & FOLIO_CFDI & "'
                                            WHERE CVE_COVC  = " & CVE_COVC
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                            End If
                                        End Using
                                    End If
                                Catch ex As Exception
                                    MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                    Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Else
                                Debug.Print("")
                            End If
                            'FIN IF XML_TABLA.Trim.Length > 0 Then
                        End If
                    Loop
                End Using
            End Using
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub MnuValesCxP_Click(sender As Object, e As EventArgs) Handles MnuValesCxP.Click
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            Fg.Redraw = False
            SQL = "SELECT ISNULL(V.CVE_COVC,0) AS COV, CASE V.STATUS 
                WHEN 'A' THEN 'Activo' 
                WHEN 'T' THEN 'Cuentas por pagar' 
                WHEN 'F' THEN 'Cerrada' 
                ELSE 'Cancelado' 
                END AS 'ESTATUS', 
                ISNULL(V.CVE_PROV,'') AS PROV, NOMBRE, ISNULL(V.CVE_DOC,'') AS DOC, SERIE_CFDI, FOLIO_CFDI, V.FECHA_DOC, ISNULL(V.SUBTOTAL,0) AS SUBTOT, 
                ISNULL(V.IVA,0) AS IVAS, ISNULL(V.NETO,0) AS IMPORTE, 
                ISNULL((SELECT COUNT(*) FROM GCCONCI_VALES_COMBUS_PAR P WHERE ISNULL(P.STATUS,'A') = 'A' AND P.CVE_COVC = V.CVE_COVC),0) AS Vales,
                CASE WHEN ISNULL(POL_GEN,'') = 'S' THEN 'Generada' ELSE '' END AS 'Poliza',
                (SELECT SUM(LITROS_REALES) AS LTS_INICIALES FROM GCCONCI_VALES_COMBUS_PAR C LEFT JOIN GCASIGNACION_VIAJE_VALES A ON A.FOLIO = C.CVE_FOLIO
                WHERE ISNULL(C.STATUS,'A') <> 'C' AND C.CVE_COVC = V.CVE_COVC AND ISNULL(A.STATUS,'') <> 'C') AS LITROS,
                ISNULL((SELECT TOP 1 REFER FROM PAGA_M" & Empresa & " WHERE NO_FACTURA = V.CVE_DOC),'') AS Paga_M
                FROM GCCONCI_VALES_COMBUS V
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = V.CVE_PROV
                WHERE ISNULL(V.STATUS,'A') <> '' ORDER BY TRY_CAST(CVE_COVC As INT) DESC"
            'GCCONCI_VALES_COMBUS 
            'MOSTRAR TODOS MENOS LOS QUE ESTAN EN EDICION
            'CAMBIAR EL STATUS DE VALE A CAPTURADO Y QUITAR DE ESTA PESTANA Y ENVIARLO A LA PRIMERA PESTANA

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg(0, 1) = "Folio conci."
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int32)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Clave"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Proveedor"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Factura"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Serie"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Folio"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Fecha factura"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(DateTime)

            Fg(0, 9) = "SubTotal"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "IVA"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Neto"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Litros reales"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 14) = "Total litros"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg.Cols.Count = 16
            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = Fg(0, k) & k
                Next
            End If

            Fg.AutoSizeCols()
            Fg.Redraw = True
            If MsgBox("Desea generar la CXP a todas las conciliaciones?", vbYesNo) = vbYes Then
                BarCxP()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub MnuGrabarFactUtil_Click(sender As Object, e As EventArgs) Handles MnuGrabarFactUtil.Click
        Dim dt As DateTime = F1.Value
        Dim Mes As String, j As Integer, CP1 As String = "", CP2 As String = "", SERIE As String = "", FOLIO As String = "", FECHA_CERT As String = ""
        Dim XML As String = "", XML_CANC As String = "", CLIENTE As String = "", SUBTOTAL As Decimal, RETENCION As Decimal
        Dim IVA As Decimal, IMPORTE As Decimal, FECHA_CANCEL As String = ""

        Fg.Rows.Count = 1

        Mes = Format(dt.Month, "00")
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT P.CLAVE_DOC FROM PAR_FACTF_CLIB" & Empresa & " P
                    WHERE CAMPLIB3 LIKE 'AA%' AND CAMPLIB5 LIKE '__" & Mes & "__'
                    GROUP BY P.CLAVE_DOC"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            SQL = "SELECT P.CLAVE_DOC, CAMPLIB3, IMPORTE, SERIE, FOLIO, FECHA_CERT, XML_DOC, XML_DOC_CANCELA, CVE_CLPV, CAN_TOT, IMP_TOT2,
                                IMP_TOT3, IMP_TOT4, IMPORTE, CFDI.FECHA_CANCELA
                                FROM PAR_FACTF_CLIB" & Empresa & " P
                                LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = P.CLAVE_DOC
                                LEFT JOIN CFDI" & Empresa & " CFDI ON CFDI.CVE_DOC = P.CLAVE_DOC
                                WHERE P.CLAVE_DOC = '" & dr("CLAVE_DOC") & "'"
                            j = 1
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    While dr2.Read
                                        Select Case j
                                            Case 1
                                                CP1 = dr2("CAMPLIB3")
                                            Case 2
                                                CP2 = dr2("CAMPLIB3")
                                            Case 3
                                                Exit While
                                        End Select
                                        j = j + 1
                                        SERIE = dr2.ReadNullAsEmptyString("SERIE")
                                        FOLIO = dr2.ReadNullAsEmptyLong("FOLIO")
                                        FECHA_CERT = dr2.ReadNullAsEmptyString("FECHA_CERT")
                                        FECHA_CANCEL = dr2.ReadNullAsEmptyString("FECHA_CANCELA")
                                        XML = dr2.ReadNullAsEmptyString("XML_DOC").Replace("'", "''")
                                        XML_CANC = dr2.ReadNullAsEmptyString("XML_DOC_CANCELA").Replace("'", "''")
                                        CLIENTE = dr2.ReadNullAsEmptyString("CVE_CLPV")
                                        SUBTOTAL = dr2.ReadNullAsEmptyDecimal("CAN_TOT")
                                        RETENCION = dr2.ReadNullAsEmptyDecimal("IMP_TOT2") + dr2.ReadNullAsEmptyDecimal("IMP_TOT3")
                                        IVA = dr2.ReadNullAsEmptyDecimal("IMP_TOT4")
                                        IMPORTE = dr2.ReadNullAsEmptyDecimal("IMPORTE")
                                    End While
                                End Using
                            End Using
                            SQL = "IF NOT EXISTS (SELECT FACTURA FROM CFDI WHERE FACTURA = '" & CP1 & "')
                                INSERT INTO CFDI (TDOC,  FACTURA, DOCUMENT, DOCUMENT2, SERIE, FOLIO, FECHA_CERT, FECHA_CANCEL, XML,
                                XML_CANC, OBS_CANC, FILE_XML, TIMBRADO, USUARIO, VERSION, FECHAELAB, UUID, FECHA_CANCELADA, USUARIO_CANCELA,
                                CVE_MCANC, ESTATUS, CLIENTE, SUBTOTAL, RETENCION, IVA, IMPORTE, COM_PAGO, POLIZA) VALUES ('CP','" & CP1 & "','" &
                                CP1 & "','" & CP2 & "','" & SERIE & "','" & FOLIO & "','" & FECHA_CERT & "','" & FECHA_CANCEL & "','" &
                                XML & "','" & XML_CANC & "',' ',' ','S',' ','2.0',GETDATE(),NEWID(),GETDATE(),' ',' ',' ','" & CLIENTE & "','" &
                                SUBTOTAL & "','" & RETENCION & "','" & IVA & "','" & IMPORTE & "',' ',' ')"
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQL
                                returnValue = cmd3.ExecuteNonQuery()
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        Fg.AddItem("" & dr("CLAVE_DOC") & vbTab & vbTab & CP1 & vbTab & CP2)
                                    End If
                                End If
                            End Using

                        Catch ex As Exception
                            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuKmRecorridos_Click(sender As Object, e As EventArgs) Handles MnuKmRecorridos.Click
        Dim XML_TABLA As String = "", FILE_XML As String = ""
        Dim FECHA_CARGA As String = ""

        Try
            SQL = "SELECT FACTURA, C.CVE_FOLIO, C.STATUS, C.FECHA_CARGA, C.KM_RECORRIDOS, LV.KM_RECORRI 
                FROM GCCARTA_PORTE C
                LEFT JOIN CFDI_CONC_LV LV ON CARTA_PORTE1 = C.CVE_FOLIO
                LEFT JOIN CFDI F ON F.DOCUMENT = C.CVE_FOLIO
                WHERE C.KM_RECORRIDOS =0"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read

                        Try
                            If dr.ReadNullAsEmptyDecimal("KM_RECORRI") > 0 Then
                                SQL = "UPDATE GCCARTA_PORTE SET KM_RECORRIDOS = " & dr("KM_RECORRI") & "
                                 WHERE CVE_FOLIO = '" & dr("CVE_FOLIO") & "'"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                    End If
                                End Using

                                SQL = "UPDATE GCASIGNACION_VIAJE SET KM_RECORRIDOS = " & dr("KM_RECORRI") & " 
                                    WHERE CVE_CAP1 = '" & dr("CVE_FOLIO") & "'"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                    End If
                                End Using

                            End If
                        Catch ex As Exception
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Loop
                End Using
            End Using
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub MnuGrabarFACTFDesdeXML_Click(sender As Object, e As EventArgs) Handles MnuGrabarFACTFDesdeXML.Click
        Dim XML As String = "", FILE_XML As String = "", CVE_DOC As String = "", j As Integer = 0

        If MsgBox("Realmente desea actualizar la tabla FACTF desde los XML?", vbYesNo) = vbNo Then
            Return
        End If
        Fg.Redraw = False
        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor
        Fg.Rows.Count = 1
        Fg.Cols.Count = 7
        Fg(0, 1) = "Documento"
        Fg(0, 2) = "Subtotal"
        Fg(0, 3) = "Retencion"
        Fg(0, 4) = "Iva"
        Fg(0, 5) = "Importe"
        Fg(0, 6) = "Fecha"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(Decimal)
        Fg.Cols(2).Format = "###,###,##0.00"

        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(Decimal)
        Fg.Cols(3).Format = "###,###,##0.00"

        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(Decimal)
        Fg.Cols(4).Format = "###,###,##0.00"

        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(Decimal)
        Fg.Cols(5).Format = "###,###,##0.00"

        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(DateTime)

        For k = 1 To 1
            If k = 1 Then
                SQL = "SELECT FACTURA, XML, FECHAELAB FROM CFDI WHERE ISNULL(SUBTOTAL,0) = 0 "
            Else
                'SQL = "SELECT * FROM CFDI01 WHERE CVE_DOC >= 'A0000009944' ORDER BY CVE_DOC "
            End If
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        Do While dr.Read
                            If k = 1 Then
                                XML = dr("XML")
                                CVE_DOC = dr("FACTURA")
                            Else
                                'XML = dr("XML_DOC")
                                'CVE_DOC = dr("CVE_DOC")
                            End If
                            If XML.Trim.Length > 0 Then
                                TotalCFD = 0
                                SubtotalCFD = 0
                                IVAcfd = 0
                                RETcfd = 0

                                'GRABANDO 
                                If SubtotalCFD > 0 And TotalCFD > 0 Then
                                    j += 1
                                    Lt1.Text = "Registros " & j
                                    If IVAcfd = 0 Then
                                        Lt1.Text = "Registros " & j
                                    End If
                                    SQL = "UPDATE CFDI SET 
                                        SUBTOTAL = '" & SubtotalCFD & "', 
                                        IMPORTE = '" & TotalCFD & "', 
                                        RETENCION = " & RETcfd * -1 & ", 
                                        IVA = " & IVAcfd & "
                                        WHERE FACTURA = '" & CVE_DOC & "'"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                                Fg.AddItem("" & vbTab & CVE_DOC & vbTab & SubtotalCFD & vbTab & RETcfd & vbTab & IVAcfd & vbTab &
                                                           TotalCFD & vbTab & dr("FECHAELAB"))
                                            Else
                                                Debug.Print("")
                                            End If
                                        End If
                                    End Using
                                End If
                            End If
                        Loop
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        Fg.Redraw = True
        MsgBox("Proceso terminado")
    End Sub

    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function

    Private Sub DataTreeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataTreeToolStripMenuItem.Click
        BindGrid(Fg)
        CreateTree(Fg)
        CreateSubTotal(Fg)
    End Sub

    Private Sub FechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FechaToolStripMenuItem.Click

        Dim FECHA_T1 As DateTime
        Dim FECHA_T2 As String

        Try
            Var10 = "2022/10/26 17:02:44"
            Var11 = Var10.Substring(8, 2) & "/" & Var10.Substring(5, 2) & "/" & Var10.Substring(0, 4) & " " & Var10.Substring(11, Var10.Length - 11)
            Var12 = Var10.Substring(8, 2) & Var10.Substring(5, 2) & Var10.Substring(0, 4) & " " & Var10.Substring(11, Var10.Length - 11)
            Dim oDate1 As DateTime = DateTime.ParseExact(Var11, "dd/MM/yyyy HH:mm:ss", Nothing)

            FECHA_T1 = oDate1
            FECHA_T2 = Var12

            MsgBox(Now.ToString("yyyy-MM-ddTHH:mm:ss"))


        Catch ex As Exception
            MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarActulaizarFechaTimbreEbCartaPorte_Click(sender As Object, e As EventArgs) Handles BarActulaizarFechaTimbreEbCartaPorte.Click
        Try
            Fg.Rows.Count = 1

            If MsgBox("Realmente desea actualizar la fecha de timbrado en carta porte?", vbYesNo) = vbYes Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CFDI.FACTURA, CFDI.FECHA_CERT, ISNULL(CFDI.DOCUMENT,'') AS CARPORT, P.FECHA_TIMBRE
                        FROM CFDI 
                        LEFT JOIN GCCARTA_PORTE P ON P.CVE_FOLIO = CFDI.DOCUMENT
                        WHERE YEAR(CFDI.FECHAELAB) >= 2022"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            Try
                                If dr("CARPORT").ToString.Trim.Length > 0 Then
                                    SQL = "UPDATE GCCARTA_PORTE SET FECHA_TIMBRE = TRY_PARSE('" & dr("FECHA_CERT") & "' AS DATETIME USING 'es-mx')
                                        WHERE CVE_FOLIO = '" & dr("CARPORT") & "'"

                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then

                                                Fg.AddItem("" & vbTab & dr("FACTURA") & vbTab & dr("CARPORT") & vbTab & dr("FECHA_CERT") & vbTab &
                                                           dr("FECHA_TIMBRE"))
                                            End If
                                        End If
                                    End Using
                                End If
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try

                        End While
                    End Using
                End Using

                MsgBox("Proceso terminado")

            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarAgregarCxC_Click(sender As Object, e As EventArgs) Handles BarAgregarCxC.Click
        Try
            Dim REFER As String, CVE_CLPV As String, IMPORTE As Decimal, CVE_VEND As String
            Fg.Rows.Count = 1

            Using cmd As SqlCommand = cnSAE.CreateCommand
                'A0000010277 al Folio A0000010308
                SQL = "SELECT * FROM FACTF" & Empresa & " WHERE CVE_DOC >= '" & TCVE_DOC1.Text & "' AND CVE_DOC <= '" & TCVE_DOC2.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        REFER = dr("CVE_DOC")
                        CVE_CLPV = dr("CVE_CLPV")
                        IMPORTE = dr("IMPORTE")
                        CVE_VEND = dr("CVE_VEND")

                        If IMPORTE > 0 Then

                            If CUEN_M(REFER, CVE_CLPV, IMPORTE, CVE_VEND, 0) Then
                                Fg.AddItem("" & vbTab & REFER & vbTab & CVE_CLPV & vbTab & IMPORTE & vbTab & CVE_VEND)
                            End If
                        End If

                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarLlenarBienesTransport_Click(sender As Object, e As EventArgs) Handles BarLlenarBienesTransport.Click

    End Sub

    Private Sub BarBienesTransportados_Click(sender As Object, e As EventArgs) Handles BarBienesTransportados.Click

        FrmLlenarBienesTrans.ShowDialog()

    End Sub

    Private Sub BarConectBaseSqlServerCe_Click(sender As Object, e As EventArgs) Handles BarConectBaseSqlServerCe.Click
        Try
            '
            'Encerramos la conexion en un Bloque using para asegurarse de destruir todos los objetos utilizados dentro
            'ademas de cerrar la conexion despues de ejectuar la consulta
            '
            Using cnx As New SqlCeConnection("Data Source=|DataDirectory|\TRANSPORTGC.mdf")
                'Creamos una variable que contendra la consulta a ejecutar
                '
                Dim SqlAction As String = "SELECT * FROM INVE"
                '
                'Creamos un comeando del tipo SqlCeCommand y le pasamos la variable que contiene
                'la consulta y la conexion
                '
                Using cmd As New SqlCeCommand(SqlAction, cnx)
                    '
                    'Creamos un objeto DataAdapter este objeto se encarga de abrir la conexion a la Bd
                    '
                    Dim da As New SqlCeDataAdapter(cmd)
                    '
                    'Creamos un objeto DataTable que contendra los daos recuperados por el DataAdapter
                    '
                    Dim dt As New DataTable()

                    '
                    'Llenamos el objeto DataTable con los datos recuperados por el DataAdapter
                    '
                    da.Fill(dt)
                    '
                    'Establecemos el DataSource del Control DataGridView
                    '
                    Fg.DataSource = dt

                End Using
            End Using
        Catch ex As Exception
            MsgBox("2020. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORATPV("2020. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarEnviarTablaSqlServer_Click(sender As Object, e As EventArgs) Handles BarEnviarTablaSqlServer.Click

        CREA_SP_EMPLEADOS()

        Try
            Dim cmd As SqlCommand = New SqlCommand("spInsertEmployees", cnSAE)

            cmd.CommandType = CommandType.StoredProcedure
            Dim paramTVP As SqlParameter = New SqlParameter() With {
            .ParameterName = "@EmpTableType",
            .Value = GetEmployeeData()
        }
            cmd.Parameters.Add(paramTVP)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("2020. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORATPV("2020. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Function GetEmployeeData() As DataTable
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Id")
        dt.Columns.Add("Name")
        dt.Columns.Add("Gender")
        dt.Rows.Add("1", "maria", "Femenino")
        dt.Rows.Add("2", "gustavo", "Masculino")
        dt.Rows.Add("3", "rocio", "Masculino")
        dt.Rows.Add("4", "luis", "Masculino")
        dt.Rows.Add("5", "ezequiel", "Masculino")
        Return dt
    End Function

    Private Sub BarAgregarEspaciosALaTablaDeClientes_Click(sender As Object, e As EventArgs) Handles BarAgregarEspaciosALaTablaDeClientes.Click
        Dim CLAVE As String
        Try
            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE FROM CLIE" & Empresa
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CLAVE = Space(10 - dr("CLAVE").ToString.Trim.Length) & dr("CLAVE").ToString.Trim

                        SQL = "UPDATE CLIE" & Empresa & " SET CLAVE = '" & CLAVE & "' WHERE CLAVE = '" & dr("CLAVE") & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        End Using

                        Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & CLAVE)
                    End While
                End Using
            End Using

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarClientes_Click(sender As Object, e As EventArgs) Handles BarClientes.Click

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = ""
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub BtnRuta_Click(sender As Object, e As EventArgs) Handles BtnRuta.Click
        Try            ' Configuración del FolderBrowserDialog  
            With FolderBrowserDialog1
                .Reset() ' resetea  
                ' leyenda  
                .Description = " Seleccionar una carpeta "
                ' Path " Mis documentos "  
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                ' deshabilita el botón " crear nueva carpeta "  
                .ShowNewFolderButton = False
                '.RootFolder = Environment.SpecialFolder.Desktop  
                '.RootFolder = Environment.SpecialFolder.StartMenu  
                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  
                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then
                    TRUTA.Text = .SelectedPath

                    GET_FILES_XMLS(TRUTA.Text)
                End If
                .Dispose()
            End With
        Catch ex As Exception
            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("16. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
        End Try
    End Sub


    Private Sub BarObtenerRelacionados_Click(sender As Object, e As EventArgs) Handles BarObtenerRelacionados.Click
        Dim CVE_DOC As String
        Try
            For k = 1 To Fg.Rows.Count - 1

                If Not IsNothing(Fg(k, 1)) AndAlso Fg(k, 1).ToString.Trim.Length > 0 Then

                    CVE_DOC = Path.GetFileNameWithoutExtension(Fg(k, 2))
                    SQL = "IF EXISTS (SELECT UUID FROM CFDI_REL" & Empresa & " WHERE UUID = '" & Fg(k, 1).ToString & "' AND CVE_DOC = '" & CVE_DOC & "')
                        UPDATE CFDI_REL" & Empresa & " SET UUID ='" & Fg(k, 1).ToString & "', TIP_REL = '" & Fg(k, 3).ToString & "'
                        WHERE UUID = '" & Fg(k, 1).ToString & "' AND CVE_DOC = '" & CVE_DOC & "'
                    ELSE
                        INSERT INTO CFDI_REL" & Empresa & " (UUID, TIP_REL, CVE_DOC, CVE_DOC_REL, TIP_DOC, FECHA_CERT) 
                         VALUES ('" & Fg(k, 1).ToString & "','" & Fg(k, 3) & "','" & CVE_DOC & "',' ','P','" & FechaEmision & "')"
                    If Not EXECUTE_QUERY_NET(SQL) Then
                        Debug.Print("")
                    End If
                End If
            Next

            MsgBox("Proceso terminado")

        Catch ex As Exception
            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("16. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
        End Try
        'If Not EXISTS(SELECT UUID FROM CFDI_REL05 WHERE UUID = '')
        'INSERT INTO CFDI_REL05 (UUID, TIP_REL, CVE_DOC, CVE_DOC_REL, TIP_DOC, FECHA_CERT) 
        'VALUES('','04','74939ac4-6eb0-4536-ae5b-a37ea2696193',' ','P','')
    End Sub
    Sub GET_FILES_XMLS(fRUTA As String)
        Dim NAME_XML As String
        If fRUTA.Trim.Length > 0 Then
            Try
                Dim nFiles As ObjectModel.ReadOnlyCollection(Of String)

                nFiles = My.Computer.FileSystem.GetFiles(fRUTA)

                Fg.Redraw = False
                Fg.BeginUpdate()

                Fg.Rows.Count = 1
                For k = 0 To nFiles.Count - 1
                    Dim extension As String = Path.GetExtension(nFiles(k))
                    If extension.ToUpper = ".XML" Then

                        NAME_XML = Path.GetFileName(nFiles(k))

                        OBTENER_UUID_XML(nFiles(k))

                        Fg.AddItem("" & vbTab & UUIDR & vbTab & NAME_XML & vbTab & TIPO_RELACION & vbTab & nFiles(k))

                    End If
                Next
            Catch ex As Exception
                Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("16. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            End Try

            Fg.Redraw = True
            Fg.EndUpdate()

            MsgBox("Listo")

        End If
    End Sub
    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String, strSerie As String, strFolio As String, strFechaEmision As String, strSello As String, strNoCertificado As String
        Dim strSubtotal As String, strTotal As String, strMoneda As String, strCondiciones As String, strFormaPago As String, strMetodoPago As String
        Dim strLugarExpedicion As String, strReceptorRfc As String, strEmisorRfc As String, strEmisorNombre As String
        Dim strUsoCFDI As String, strRegimen As String, strDescuento As String, strNumCtaPago As String, strVersion As String
        Dim NoCertificadoSAT As String, UUID As String = "", FechaTimbrado As String, strVersionTimbre As String, NumOperacion As String
        Dim Monto As String, FormaDePagoP As String, FechaPago As String, Folio As String, Serie As String, ImpSaldoInsoluto As String
        Dim ImpPagado As String, ImpSaldoAnt As String, NumParcialidad As String, MetodoDePagoDR As String
        Dim concepto As XmlNodeList, Elemento As XmlNode, subnodo As XmlElement, IdDocumento As String, UsoCFD As String
        Dim XML As String, xDoc As XmlDocument, xNodo As XmlNodeList, xAtt As XmlElement, Comprobante As XmlNode, Impuestos As XmlNode = Nothing
        Dim totalImpuestosTrasladados As Decimal, TotalImpuestosRetenidos As Decimal, vsTIT As Decimal, k As Integer

        Dim CVE_DOC As String, RUTA_XML As String, RUTA_PDF As String, EMISOR_RAZON_SOCIAL As String = "", EMISOR_LUGAR_EXPEDICION As String = ""
        Dim EMISOR_REGIMEN_FISCAL As String = "", EmisorRfcCFD As String, SerieCFD As String, FolioCFD As String, FechaEmision As String
        Dim TotalCFD As Decimal, SubtotalCFD As Decimal, IVAcfd As Decimal, RETcfd As Decimal, VersionCFD As String, MonedaCFD As String
        Dim FormaPagoCFD As String, UsoCFDICFD As String, TipoComprobanteCFD As String, strTipoRelacion As String


        'aqui
        XML = fFILE_XML

        If XML.Trim.Length = 0 Then
            Return ""
        End If


        If Not File.Exists(XML) Then
            Return ""
        End If

        strEmisorRfc = ""
        strTipoComprobante = "" : strUsoCFDI = ""

        xDoc = New XmlDocument

        Dim v_namespace As New XmlNamespaceManager(xDoc.NameTable)

        v_namespace.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4")
        v_namespace.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
        v_namespace.AddNamespace("implocal", "http://www.sat.gob.mx/implocal")


        Try
            If XML.Trim.Length > 0 Then
                Dim books = XDocument.Load(XML)

                xDoc.Load(XML)

                Comprobante = xDoc.Item("cfdi:Comprobante")
                xNodo = xDoc.GetElementsByTagName("cfdi:Comprobante")
                If xNodo.Count > 0 Then
                    For Each xAtt In xNodo
                        Application.DoEvents()
                        Try
                            strVersion = VarXml(xAtt, "Version")
                        Catch ex As Exception
                            strVersion = ""
                        End Try

                        Try
                            strTipoComprobante = VarXml(xAtt, "TipoDeComprobante")
                            strSerie = VarXml(xAtt, "Serie")
                            strFolio = VarXml(xAtt, "Folio")
                            strFechaEmision = VarXml(xAtt, "Fecha")
                            strSello = VarXml(xAtt, "sello")
                            strNoCertificado = VarXml(xAtt, "NoCertificado")
                            strSubtotal = VarXml(xAtt, "SubTotal")
                            strTotal = VarXml(xAtt, "Total")
                            strMoneda = VarXml(xAtt, "Moneda")
                            strCondiciones = VarXml(xAtt, "CondicionesDePago")
                            strFormaPago = VarXml(xAtt, "FormaPago")
                            strMetodoPago = VarXml(xAtt, "MetodoPago")
                            strNumCtaPago = VarXml(xAtt, "NumCtaPago").Trim
                            strLugarExpedicion = VarXml(xAtt, "LugarExpedicion")
                            strDescuento = VarXml(xAtt, "Descuento")
                            strRegimen = VarXml(xAtt, "NoCertificadoSAT")

                            SerieCFD = VarXml(xAtt, "Serie")
                            FolioCFD = VarXml(xAtt, "Folio")

                            FechaEmision = strFechaEmision
                            TotalCFD = strTotal
                            SubtotalCFD = strSubtotal

                            VersionCFD = strVersion
                            MonedaCFD = strMoneda
                            FormaPagoCFD = BUSCAR_FORMA_PAGO(strFormaPago)
                            VersionCFD = strVersion
                            UsoCFDICFD = strUsoCFDI
                            TipoComprobanteCFD = IIf(strTipoComprobante = "I", "Ingreso", "Egreso")
                        Catch ex As Exception
                            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                            'MsgBox("90. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        End Try
                    Next '   EMISOR   EMISOR   EMISOR   EMISOR

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo

                                strEmisorRfc = VarXml(xAtt, "rfc")
                                Try
                                    If strEmisorRfc.Trim.Length = 0 Then
                                        strEmisorRfc = VarXml(xAtt, "Rfc")
                                    End If
                                Catch ex As Exception
                                    Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                strEmisorNombre = VarXml(xAtt, "nombre")
                                Try
                                    If strEmisorNombre.Trim.Length = 0 Then
                                        strEmisorNombre = VarXml(xAtt, "Nombre")
                                    End If
                                Catch ex As Exception
                                    Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Next
                            EmisorRfcCFD = strEmisorRfc
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        Impuestos = Comprobante("cfdi:Impuestos")
                        If Not IsNothing(Impuestos.Attributes.GetNamedItem("totalImpuestosTrasladados")) Then
                            totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("totalImpuestosTrasladados").Value)
                        End If
                    Catch ex As Exception
                        totalImpuestosTrasladados = 0
                    End Try
                    If totalImpuestosTrasladados = 0 Then
                        Try
                            Impuestos = Comprobante("cfdi:Impuestos")
                            If Not IsNothing(Impuestos.Attributes.GetNamedItem("TotalImpuestosTrasladados")) Then
                                totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("TotalImpuestosTrasladados").Value)
                            End If
                        Catch ex As Exception
                            totalImpuestosTrasladados = 0
                        End Try
                    End If
                    Try
                        If totalImpuestosTrasladados = 0 Then
                            vsTIT = 0
                            k = 1
                            For Each vRegIT As XmlElement In Impuestos.ChildNodes
                                If vRegIT.Name = "cfdi:Traslados" Then
                                    If Not IsNothing(vRegIT.FirstChild.Attributes("importe")) Then
                                        vsTIT += CDec(vRegIT.FirstChild.Attributes("importe").Value)
                                    End If
                                End If
                            Next
                        Else
                            vsTIT = totalImpuestosTrasladados
                        End If
                    Catch ex As Exception
                        'Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    IVAcfd = totalImpuestosTrasladados


                    Try
                        Impuestos = Comprobante("cfdi:Impuestos")
                        If Not IsNothing(Impuestos.Attributes.GetNamedItem("TotalImpuestosRetenidos")) Then
                            TotalImpuestosRetenidos = CDec(Impuestos.Attributes.GetNamedItem("TotalImpuestosRetenidos").Value)
                        End If
                    Catch ex As Exception
                        TotalImpuestosRetenidos = 0
                    End Try

                    RETcfd = TotalImpuestosRetenidos


                    Try
                        UUID = ""
                        concepto = xDoc.GetElementsByTagName("cfdi:Complemento")
                        For Each Elemento In concepto
                            For Each subnodo In Elemento
                                UUID = Trim(subnodo.GetAttribute("UUID"))
                            Next
                        Next
                    Catch ex As Exception
                        Bitacora("91. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    xNodo = xDoc.GetElementsByTagName("cfdi:Comprobante")
                    If xNodo.Count > 0 Then
                        strTipoRelacion = ""
                        Try
                            xNodo = xDoc.GetElementsByTagName("cfdi:CfdiRelacionados")
                            If xNodo.Count > 0 Then
                                strTipoRelacion = VarXml(xNodo.Item(0), "TipoRelacion")
                                TIPO_RELACION = strTipoRelacion
                            End If
                        Catch ex As Exception
                            Bitacora("92. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try


                    End If



                    UUIDR = ""
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:CfdiRelacionados")
                        If xNodo.Count > 0 Then
                            If xNodo.Count > 0 Then


                                For Each xAtt In xNodo.Item(0)
                                    If xAtt.LocalName Like "CfdiRelacionado" Then
                                        UUIDR = VarXml(xAtt, "UUID")

                                        CVE_DOC = SerieCFD & "-" & FolioCFD

                                        SQL = "IF EXISTS (SELECT UUID FROM CFDI_REL" & Empresa & " WHERE UUID = '" & UUIDR & "' AND CVE_DOC = '" & CVE_DOC & "')
                                            UPDATE CFDI_REL" & Empresa & " SET UUID ='" & UUIDR & "', TIP_REL = '" & TIPO_RELACION & "', FEbCHA_CERT = '" & strFechaEmision & "'
                                            WHERE UUID = '" & UUIDR & "' AND CVE_DOC = '" & CVE_DOC & "'
                                        ELSE
                                            INSERT INTO CFDI_REL" & Empresa & " (UUID, TIP_REL, CVE_DOC, CVE_DOC_REL, TIP_DOC, FECHA_CERT) 
                                             VALUES ('" & UUIDR & "','" & TIPO_RELACION & "','" & CVE_DOC & "',' ','P','" & strFechaEmision & "')"
                                        If Not EXECUTE_QUERY_NET(SQL) Then
                                            Debug.Print("")
                                        End If


                                    End If
                                Next
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("92. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strReceptorRfc = VarXml(xAtt, "Rfc")
                                'LtRFC.Text = strReceptorRfc
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("93. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Receptor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strEmisorRfc = VarXml(xAtt, "Rfc")
                                strEmisorNombre = VarXml(xAtt, "Nombre")
                                strUsoCFDI = VarXml(xAtt, "UsoCFDI")
                                UsoCFD = strUsoCFDI
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("94. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Complemento")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo.Item(0)
                                If xAtt.LocalName Like "TimbreFiscalDigital" Then
                                    NoCertificadoSAT = VarXml(xAtt, "NoCertificadoSAT")
                                    UUID = VarXml(xAtt, "UUID")
                                    FechaTimbrado = VarXml(xAtt, "FechaTimbrado")
                                    strVersionTimbre = VarXml(xAtt, "Version")
                                End If
                                If xAtt.LocalName Like "Pagos" Then
                                    NoCertificadoSAT = VarXml(xAtt, "Version")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If strTipoComprobante = "P" Then
                        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
                        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""
                        Try
                            concepto = xDoc.GetElementsByTagName("pago10:Pagos")
                            For Each Elemento In concepto
                                For Each subnodo In Elemento
                                    NumOperacion = Trim(subnodo.GetAttribute("NumOperacion"))
                                    Monto = Trim(subnodo.GetAttribute("Monto"))
                                    FormaDePagoP = Trim(subnodo.GetAttribute("FormaDePagoP"))
                                    FechaPago = Trim(subnodo.GetAttribute("FechaPago"))
                                Next
                            Next
                            If Val(Monto) > 0 Then strTotal = Val(Monto)
                            If FechaPago.Trim.Length > 0 Then FechaTimbrado = FechaPago
                            If FormaDePagoP.Trim.Length > 0 Then strFormaPago = FormaDePagoP
                        Catch ex As Exception
                            Bitacora("96.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            MetodoDePagoDR = ""
                            concepto = xDoc.GetElementsByTagName("pago10:Pago")
                            For Each Elemento In concepto
                                'pago10:DoctoRelacionado
                                For Each subnodo In Elemento
                                    Folio = Trim(subnodo.GetAttribute("Folio"))
                                    Serie = Trim(subnodo.GetAttribute("Serie"))
                                    ImpSaldoInsoluto = Trim(subnodo.GetAttribute("ImpSaldoInsoluto"))
                                    ImpPagado = Trim(subnodo.GetAttribute("ImpPagado"))
                                    ImpSaldoAnt = Trim(subnodo.GetAttribute("ImpSaldoAnt"))
                                    NumParcialidad = Trim(subnodo.GetAttribute("NumParcialidad"))
                                    MetodoDePagoDR = Trim(subnodo.GetAttribute("MetodoDePagoDR"))
                                    IdDocumento = Trim(subnodo.GetAttribute("IdDocumento"))
                                Next
                            Next
                            If FormaDePagoP.Trim.Length > 0 Then
                                strMetodoPago = MetodoDePagoDR
                            End If
                        Catch ex As Exception
                            Bitacora("97.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If 'If xNodo.Count > 0 Then
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
        End Try

        Return UUID

    End Function


    Private Function CUEN_M(fCVE_DOC As String, fCLAVE As String, fIMPORTE As Decimal,
                            fCVE_VEND As String, fCVE_BITA As Long) As Boolean

        Dim CVE_CLIE As String, REFER As String, NUM_CPTO As Integer, CVE_OBS As Long, NO_FACTURA As String, DOCTO As String, IMPORTE As Decimal
        Dim AFEC_COI As String, STRCVEVEND As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CVE_FOLIO As String
        Dim TIPO_MOV As String, SIGNO As Integer, ENTREGADA As String, SEGRABO As Boolean = False
        Dim cmd As New SqlCommand
        Dim cmdT As New SqlCommand

        Try
            CVE_CLIE = fCLAVE
            REFER = fCVE_DOC
            NO_FACTURA = REFER
            DOCTO = REFER
            IMPORTE = fIMPORTE
            IMPMON_EXT = fIMPORTE

            SIGNO = 1
            NUM_CPTO = 1
            CVE_OBS = 0 : AFEC_COI = "S" : STRCVEVEND = fCVE_VEND : NUM_MONED = 1 : TCAMBIO = 1
            CVE_FOLIO = "" : TIPO_MOV = "C" : ENTREGADA = "S"

            SQL = "IF NOT EXISTS(SELECT REFER FROM CUEN_M" & Empresa & " WHERE " &
                "REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "' AND NUM_CPTO = " & NUM_CPTO & " AND NUM_CARGO = 1) " &
                "INSERT INTO CUEN_M" & Empresa & " (CVE_CLIE, REFER, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, " &
                "IMPORTE, FECHA_APLI, FECHA_VENC, AFEC_COI, STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, TIPO_MOV, " &
                "CVE_BITA, SIGNO, USUARIO, ENTREGADA, FECHA_ENTREGA, STATUS, UUID, VERSION_SINC) VALUES('" & CVE_CLIE & "','" & REFER & "','" & NUM_CPTO &
                "','1','" & CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" & Math.Round(fIMPORTE, 6) & "',CONVERT(varchar, GETDATE(), 112)," &
                "CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & STRCVEVEND & "','" & NUM_MONED & "','" & TCAMBIO & "','" &
                Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'" & TIPO_MOV & "','" & fCVE_BITA & "','" & SIGNO & "','" &
                CLAVE_SAE & "','" & ENTREGADA & "',CONVERT(varchar, GETDATE(), 112),'A', NEWID(), GETDATE())"
            Try
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        SEGRABO = True
                    End If
                End If
            Catch ex As Exception
                BITACORATPV("2000. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2000. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORATPV("2020. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2020. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return SEGRABO
    End Function

    Public Sub BindGrid(ByVal grid As C1FlexGrid)
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Course", GetType(String))
        dt.Columns.Add("Score", GetType(Integer))
        dt.Columns.Add("Attendance", GetType(Integer))
        dt.Columns.Add("Country", GetType(String))
        dt.Rows.Add(1, "Helen Bennett", "ComputerScience", 79, 84, "Spain")
        dt.Rows.Add(2, "Ana Trujillo", "Biology", 78, 87, "Mexico")
        dt.Rows.Add(3, "Antonio Moreno", "Aeronautics", 71, 70, "Spain")
        dt.Rows.Add(4, "Paolo Accorti", "Biology", 74, 63, "Spain")
        dt.Rows.Add(5, "Elizabeth Brown", "ComputerScience", 80, 93, "Mexico")
        dt.Rows.Add(6, "Jaime Yorres", "Biology", 61, 48, "Spain")
        dt.Rows.Add(7, "Yvonne Moncada", "Aeronautics", 85, 78, "Mexico")
        dt.Rows.Add(8, "Martine Rancé", "Aeronautics", 67, 81, "Spain")
        dt.Rows.Add(9, "Sergio Gutiérrezy", "ComputerScience", 62, 58, "Mexico")
        dt.Rows.Add(10, "Thomas Hardy", "Aeronautics", 94, 92, "Mexico")
        dt.Rows.Add(11, "Patricio Simpson", "Aeronautics", 46, 52, "Spain")
        dt.Rows.Add(12, "Maria Anders", "ComputerScience", 85, 73, "Spain")
        grid.DataSource = dt
        grid.AutoSizeCols()
        TryCast(grid.DataSource, DataTable).DefaultView.Sort = "Course"

    End Sub

    Public Sub CreateTree(ByVal grid As C1FlexGrid)
        grid.Tree.Column = 1
        grid.Tree.Style = TreeStyleFlags.SimpleLeaf
        grid.Tree.Show(1)
        grid.AutoSizeCols()
    End Sub

    Public Sub CreateSubTotal(ByVal grid As C1FlexGrid)
        grid.Subtotal(AggregateEnum.Clear)
        grid.Subtotal(AggregateEnum.Average, 1, 3, 3, 4, "Average for {0}")
        grid.AutoSizeCols()
    End Sub

    Private Sub ALTA_CXC_DESDE_FACTF()

        Dim CVE_CLPV As String, REFER As String
        Dim SIGNO As Integer, IMPORTE As Decimal
        Dim CAN_TOT As Decimal = 0, CVE_VEND As String
        Dim j As Integer = 0

        Try
            For k = 1 To Fg.Rows.Count - 1

                Application.DoEvents()

                REFER = Fg(k, 1)
                CVE_CLPV = Fg(k, 3)
                IMPORTE = Fg(k, 6)
                CVE_VEND = ""
                If IMPORTE > 0 Then

                    If CUEN_M(REFER, CVE_CLPV, IMPORTE, 1, CVE_VEND) Then


                        j += 1

                        UPDATE_DATOS_CLIE(Math.Round(IMPORTE, 6), REFER, CVE_CLPV, SIGNO)
                        Try
                            SQL = "UPDATE AFACT" & Empresa & " SET FVTA_COM = ISNULL(FVTA_COM,0) + " & CAN_TOT & " WHERE CVE_AFACT = " & Now.Month & "
                                       If @@ROWCOUNT = 0
                                       INSERT INTO AFACT" & Empresa & " (CVE_AFACT, FVTA_COM, FDESCTO) VALUES ('" & Now.Month & "','" & CAN_TOT & "','0')"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("154. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            MsgBox("154. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                    End If
                End If
            Next
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        MsgBox("Proceso terminado, cuentas por pagar afectadas " & J)
    End Sub
    Private Sub BarAgregarCxCDesdeFacturas_Click(sender As Object, e As EventArgs) Handles BarAgregarCxCDesdeFacturas.Click
        Try

            SQL = "SELECT CVE_DOC, F.STATUS, CVE_CLPV, NOMBRE, FECHA_DOC, IMPORTE
                FROM FACTF" & Empresa & " F
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CVE_CLPV
                WHERE F.STATUS = 'A' AND SERIE = 'A' AND 
                NOT EXISTS (SELECT REFER CUEN_M" & Empresa & " WHERE REFER = F.CVE_DOC"

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource


            Fg(0, 1) = "Documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Cliente"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Nombre"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Fecha"
            Dim c5 As Column = Fg.Cols(6)
            c5.DataType = GetType(DateTime)

            Fg(0, 6) = "Importe"
            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"



            Fg.AutoSizeCols()
            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = Fg(0, k) & k
                Next
            End If

            Fg.AutoSizeCols()
            Fg.Redraw = True
            If MsgBox("Desea generar la CXP a todas las conciliaciones?", vbYesNo) = vbYes Then
                ALTA_CXC_DESDE_FACTF()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Class