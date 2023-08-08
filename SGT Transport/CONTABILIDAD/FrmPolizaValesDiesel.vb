Imports System.IO
Imports System.Xml
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmPolizaValesDiesel
    Private EmisorRfcCFD As String

    Private SerieCFD As String
    Private FolioCFD As String
    Private FechaEmision As String

    Private TotalCFD As Decimal
    Private SubtotalCFD As Decimal
    Private IVAcfd As Decimal
    Private RETcfd As Decimal

    Private VersionCFD As String
    Private MonedaCFD As String
    Private FormaPagoCFD As String
    Private UsoCFDICFD As String
    Private TipoComprobanteCFD As String

    Private UsoCFD As String
    Private CADENA As String = ""
    Private RUTA_MODELO As String = ""
    Private FACTURA As String

    Private Sub FrmPolizaValesDiesel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 50
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height
            Fg.Height = Me.Height - Panel1.Height - Panel1.Height

            Fg.Cols.Count = 7
            Fg.Rows.Count = 1
            Fg(0, 1) = "Cuenta contable"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = ""
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripcion"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Cargo"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Abono"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "XML"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)
            Fg.Cols(6).Visible = False

            GET_RUTA_MODELO()

            Fg.Cols(6).Visible = False

            LtFolio.Text = Var46

            BarDesplegar_Click(Nothing, Nothing)

            tPOLIZA.Text = "Poliza vales diesel conciliación " & Var46 & " Fecha " & DateTime.Now.ToShortDateString

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GET_RUTA_MODELO()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                RUTA_MODELO = dr("RUTA_MODELO").ToString
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPolizaValesDiesel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Poliza vales diesel")
    End Sub

    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click

        If Var47.Trim.Length > 0 Then
            DESPLEGAR_VALES()
        Else
            DESPLEGAR_UTILITARIOS()
        End If
    End Sub
    Sub DESPLEGAR_VALES()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim GRABADO As Decimal = 0, EXCENTO As Decimal = 0, nDoc As Integer, CADENA_PROV As String = ""
        Dim SUMA_IVA As Decimal = 0, SUMA_GRABADO As Decimal = 0, SUMA_EXCENTO As Decimal = 0, CTA_PROV As String = "", LIB1 As String = "", LIB2 As String = ""

        Dim NewStyle1 As CellStyle, NewStyle2 As CellStyle

        Fg.Rows.Count = 1
        Fg.Redraw = False

        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.CadetBlue
        NewStyle1.ForeColor = Color.Black

        NewStyle2 = Fg.Styles.Add("NewStyle2")
        NewStyle2.BackColor = Color.Yellow
        NewStyle2.ForeColor = Color.Black

        Try
            SQL = "SELECT V.CVE_OPER, VCP.CVE_COVC, VCP.CVE_FOLIO, ISNULL(VCP.IVA,0) AS IVA1,  ISNULL(VV.IEPS,0) AS IEPS1, 
                ISNULL(VC.CVE_DOC,'') AS NUMFACTURA, VC.FECHA_DOC AS FECHAFACTURA, O.NOMBRE AS OPERADOR, V.CVE_TRACTOR AS UNIDAD, 
                ISNULL(P.NOMBRE,'') AS PROVEEDOR_GAS, ISNULL(U.CTA_CON_DIESEL,'') AS CTA_DIESEL, ISNULL(U.CTA_CON_DIESEL_SIVA,'') AS CTA_DIESEL_SIVA, 
                ISNULL(LITROS_REALES,0) AS LTS_REAL, ISNULL(P_X_LITRO,0) AS P_LTS, ISNULL(P.CUENTA_CONTABLE,'') AS CTA_PROV, 
                ISNULL(CAMPLIB1,'') AS LIB1, ISNULL(CAMPLIB2,'') AS LIB2
                FROM GCCONCI_VALES_COMBUS_PAR VCP
                LEFT JOIN GCCONCI_VALES_COMBUS VC ON VCP.CVE_COVC = VC.CVE_COVC 
                LEFT JOIN GCASIGNACION_VIAJE V ON VCP.CVE_VIAJE = V.CVE_VIAJE 
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = V.CVE_TRACTOR
                LEFT JOIN GCASIGNACION_VIAJE_VALES VV ON V.CVE_VIAJE = VV.CVE_VIAJE AND VV.FOLIO = VCP.CVE_FOLIO
                LEFT JOIN GCOPERADOR O ON V.CVE_OPER = O.CLAVE
                LEFT JOIN PROV" & Empresa & " P ON VC.CVE_PROV = P.CLAVE
                LEFT JOIN PROV_CLIB" & Empresa & " L ON L.CVE_PROV = P.CLAVE
                WHERE VCP.CVE_COVC = " & Var46 & " AND ISNULL(VCP.STATUS,'A') = 'A' AND 
                ISNULL(VV.STATUS,'A') = 'A'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try

                            If dr("LTS_REAL") > 0 Then
                                GRABADO = dr("LTS_REAL") * (dr("P_LTS") - (dr("IEPS1") / dr("LTS_REAL"))) / 1.16
                            End If

                            EXCENTO = dr("IEPS1")
                            CADENA = dr("PROVEEDOR_GAS") & "  F/" & dr("NUMFACTURA") & " VALE " & dr.ReadNullAsEmptyString("CVE_FOLIO")
                            CADENA_PROV = dr("PROVEEDOR_GAS") & "  F/" & dr("NUMFACTURA")

                            CTA_PROV = dr("CTA_PROV")
                            LIB1 = dr("LIB1")
                            LIB2 = dr("LIB2")
                            FACTURA = dr("NUMFACTURA")

                            Fg.AddItem("1" & vbTab & dr("CTA_DIESEL") & vbTab & "0" & vbTab & CADENA & vbTab & GRABADO & vbTab & "" & vbTab & "")
                            If dr("CTA_DIESEL").Trim.Length = 0 Then
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                                nDoc = nDoc + 1
                            End If
                            Fg.AddItem(" " & vbTab & dr("CTA_DIESEL_SIVA") & vbTab & "0" & vbTab & CADENA & vbTab & EXCENTO & vbTab & "" & vbTab & "")

                            If dr("CTA_DIESEL_SIVA").Trim.Length = 0 Then
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                                nDoc = nDoc + 1
                            End If

                            SUMA_IVA = SUMA_IVA + dr("IVA1")
                            SUMA_GRABADO = SUMA_GRABADO + GRABADO
                            SUMA_EXCENTO = SUMA_EXCENTO + EXCENTO

                        Catch ex As Exception
                            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                    Fg.AddItem("" & vbTab & "121-001-0000" & vbTab & "0" & vbTab & CADENA_PROV & vbTab & SUMA_IVA & vbTab & "" & vbTab & FACTURA)
                    Fg.AddItem(" " & vbTab & LIB1 & vbTab & "0" & vbTab & CADENA_PROV & vbTab & "" & vbTab & SUMA_EXCENTO & vbTab & FACTURA)
                    If LIB1.Trim.Length = 0 Then
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                        nDoc = nDoc + 1
                    End If
                    Fg.AddItem("" & vbTab & LIB2 & vbTab & "0" & vbTab & CADENA_PROV & vbTab & "" & vbTab & SUMA_IVA + SUMA_GRABADO & vbTab & FACTURA)
                    If LIB2.Trim.Length = 0 Then
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                        nDoc = nDoc + 1
                    End If

                End Using
            End Using
            Fg.AddItem("" & vbTab & " " & vbTab & "" & vbTab & " " & vbTab &
                       SUMA_IVA + SUMA_GRABADO + SUMA_EXCENTO & vbTab &
                       SUMA_IVA + SUMA_GRABADO + SUMA_EXCENTO & vbTab & "")
            Fg.AutoSizeCols()
            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
            Fg.Select()
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True

    End Sub
    Sub DESPLEGAR_UTILITARIOS()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim GRABADO As Decimal = 0, EXCENTO As Decimal, nDoc As Integer, CADENA_PROV As String = "", CADENA_COVC As String = " AND ("
        Dim SUMA_IVA As Decimal, SUMA_GRABADO As Decimal, SUMA_EXCENTO As Decimal, CTA_PROV As String = "", CTA_PROV_LIB As String = ""

        Dim NewStyle1 As CellStyle, NewStyle2 As CellStyle

        Fg.Rows.Count = 1
        Fg.Redraw = False

        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.CadetBlue
        NewStyle1.ForeColor = Color.Black

        NewStyle2 = Fg.Styles.Add("NewStyle2")
        NewStyle2.BackColor = Color.Yellow
        NewStyle2.ForeColor = Color.Black

        Try
            SQL = "SELECT * FROM GCCONCI_VALES_COMBUS_PAR WHERE CVE_COVC = '" & Var46 & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            CADENA_COVC = CADENA_COVC & " FOLIO = '" & dr("CVE_FOLIO") & "' OR "
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
            If CADENA_COVC = " AND (" Then
                CADENA_COVC = ""
            Else
                CADENA_COVC = CADENA_COVC.Substring(0, CADENA_COVC.Length - 4) & ")"
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "SELECT RIGHT('0000000000'+ISNULL(GV.FOLIO,''),10) AS CVE_FOLIO, ISNULL(GV.FACTURA,'') AS NUMFACTURA, GV.ST_VALES, GV.CVE_OPER, 
                O.NOMBRE AS NOMBRE_OPER, GV.FECHA, GV.CVE_GAS, ISNULL(P.NOMBRE,'') AS PROVEEDOR_GAS, ISNULL(GV.CVE_TRACTOR,'') AS UNIDAD, GV.LTS_INICIALES, 
                ISNULL(GV.LITROS_REALES,0) AS LTS_REAL, ISNULL(GV.P_X_LITRO,0) AS P_LITRO, GV.SUBTOTAL, GV.IVA, ISNULL(GV.IEPS,0) AS IEPS1, GV.IMPORTE,
                ISNULL(U.CTA_CON_DIESEL,'') AS CTA_DIESEL, ISNULL(U.CTA_CON_DIESEL_SIVA,'') AS CTA_DIESEL_SIVA, 
                ISNULL(P.CUENTA_CONTABLE,'') AS CTA_PROV, ISNULL(CAMPLIB1,'') AS LIB1
                FROM GCASIGNACION_VALES_UTIL GV
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = GV.CVE_TRACTOR
                LEFT JOIN GCOPERADOR O ON O.CLAVE = GV.CVE_OPER
                LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV
                LEFT JOIN PROV_CLIB" & Empresa & " L ON L.CVE_PROV = P.CLAVE
                WHERE ISNULL(GV.STATUS,'A') = 'A' " & CADENA_COVC
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            If dr("LTS_REAL") > 0 Then
                                GRABADO = dr("LTS_REAL") * (dr("P_LITRO") - (dr("IEPS1") / dr("LTS_REAL"))) / 1.16
                            End If

                            EXCENTO = dr("IEPS1")

                            CADENA = dr("PROVEEDOR_GAS") & "  F/" & dr("NUMFACTURA") & "  VALE " & dr("CVE_FOLIO") & "  UNIDAD " & dr("UNIDAD")
                            CADENA_PROV = dr("PROVEEDOR_GAS") & "  F/" & dr("NUMFACTURA")

                            CTA_PROV = dr("CTA_PROV")
                            CTA_PROV_LIB = dr("LIB1")
                            FACTURA = dr("NUMFACTURA")

                            Fg.AddItem("1" & vbTab & dr("CTA_DIESEL") & vbTab & "0" & vbTab & CADENA & vbTab & GRABADO & vbTab & "" & vbTab & "")
                            If dr("CTA_DIESEL").Trim.Length = 0 Then
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                                nDoc = nDoc + 1
                            End If
                            Fg.AddItem(" " & vbTab & dr("CTA_DIESEL_SIVA") & vbTab & "0" & vbTab & CADENA & vbTab & EXCENTO & vbTab & "" & vbTab & "")

                            If dr("CTA_DIESEL_SIVA").Trim.Length = 0 Then
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                                nDoc = nDoc + 1
                            End If
                            SUMA_IVA = SUMA_IVA + dr("IVA")
                            SUMA_GRABADO = SUMA_GRABADO + GRABADO
                            SUMA_EXCENTO = SUMA_EXCENTO + EXCENTO

                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                    Fg.AddItem("" & vbTab & "121-001-0000" & vbTab & "0" & vbTab & CADENA_PROV & vbTab & SUMA_IVA & vbTab & "" & vbTab & FACTURA)
                    Fg.AddItem("" & vbTab & CTA_PROV & vbTab & "0" & vbTab & CADENA_PROV & vbTab & "" & vbTab & SUMA_IVA + SUMA_GRABADO & vbTab & FACTURA)
                    If CTA_PROV.Trim.Length = 0 Then
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                        nDoc = nDoc + 1
                    End If
                    Fg.AddItem(" " & vbTab & CTA_PROV_LIB & vbTab & "0" & vbTab & CADENA_PROV & vbTab & "" & vbTab & SUMA_EXCENTO & vbTab & FACTURA)
                    If CTA_PROV_LIB.Trim.Length = 0 Then
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                        nDoc = nDoc + 1
                    End If
                End Using
            End Using
            Fg.AddItem("" & vbTab & " " & vbTab & "0" & vbTab & " " & vbTab &
                       SUMA_IVA + SUMA_GRABADO + SUMA_EXCENTO & vbTab &
                       SUMA_IVA + SUMA_GRABADO + SUMA_EXCENTO & vbTab & "")
            Fg.AutoSizeCols()
            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
            Fg.Select()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Poliza vales diesel conciliación " & Var46)
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPOLIZA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tPOLIZA.KeyPress

        Select Case e.KeyChar
            Case "\", "/", ":", ",", "*", "?", """", "<", ">", "|", "[", "]", ";", ":", "'", "+", "}", "{", "´", "="
                e.Handled = True
        End Select
    End Sub
    Private Sub BarGenPoliza_Click(sender As Object, e As ClickEventArgs) Handles BarGenPoliza.Click
        Dim s As String = "", PolizaModelo As String = "", nDoc As Integer = 0, RFC As String = ""
        Dim CUENTA As String, CONCEPTO As String, IMPORTE1 As Decimal, IMPORTE2 As Decimal
        Dim CADENA1 As String, XML As String
        Dim UUID_XML As String = "", SERIE As String = ""
        Dim POLIZA_MODELO As String = "", TOTAL As Decimal = 0, FILE_XML As String = "", NUM_PAR As Long = 12903, NUM_PARX As Long = 0

        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Trim.Length = 0 Then
                    nDoc = nDoc + 1
                End If
            Next
        Catch ex As Exception
        End Try

        If nDoc > 0 Then
            If MsgBox("Existen documentos sin CUENTA CONTABLE, Desea continuar?", vbYesNo) = vbNo Then
                Return
            End If
        End If

        If tPOLIZA.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre de la poliza")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor


        Try
            s = "<?xml version=""1.0"" standalone=""yes""?>  <DATAPACKET Version=""2.0""><METADATA>"
            s = s & "<FIELDS>"
            s = s & "<FIELD attrname=""VersionCOI"" fieldtype=""i2""/>"
            s = s & "<FIELD attrname=""TipoPoliz"" fieldtype=""string"" WIDTH=""5""/>"
            s = s & "<FIELD attrname=""DiaPoliz"" fieldtype=""string"" WIDTH=""2""/>"
            s = s & "<FIELD attrname=""ConcepPoliz"" fieldtype=""string"" WIDTH=""120""/>"
            s = s & "<FIELD attrname=""UUID"" fieldtype=""string"" WIDTH=""100""/>"
            s = s & "<FIELD attrname=""Partidas"" fieldtype=""nested""><FIELDS>"
            s = s & "<FIELD attrname=""Cuenta"" fieldtype=""string"" WIDTH=""21""/>"
            s = s & "<FIELD attrname=""Depto"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""ConceptoPol"" fieldtype=""string"" WIDTH=""120""/>"
            s = s & "<FIELD attrname=""Monto"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""TipoCambio"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""DebeHaber"" fieldtype=""string"" WIDTH=""1""/>"
            s = s & "<FIELD attrname=""ccostos"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""proyectos"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""Porcentaje"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""FRMPAGO"" fieldtype=""string"" WIDTH=""5""/>"
            s = s & "<FIELD attrname=""NUMCHEQUE"" fieldtype=""string"" WIDTH=""20""/>"
            s = s & "<FIELD attrname=""MONTOBN"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""BANCO"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""CTAORIG"" fieldtype=""string"" WIDTH=""50""/>"
            s = s & "<FIELD attrname=""BENEF"" fieldtype=""string"" WIDTH=""300""/>"
            s = s & "<FIELD attrname=""RFC"" fieldtype=""string"" WIDTH=""13""/>"
            s = s & "<FIELD attrname=""BANCODEST"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""CTADEST"" fieldtype=""string"" WIDTH=""50""/>"
            s = s & "<FIELD attrname=""FECHACHEQUE"" fieldtype=""string"" WIDTH=""10""/>"
            s = s & "<FIELD attrname=""BANCOORIGEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s = s & "<FIELD attrname=""BANCODESTEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s = s & "<FIELD attrname=""IDUUID"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""IDFISCAL"" fieldtype=""string"" WIDTH=""40""/>"
            s = s & "<FIELD attrname=""CDSPartidasUUID"" fieldtype=""nested"">"
            s = s & "<FIELDS>"
            s = s & "<FIELD attrname=""NUMREG"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""UUIDTIMBRE"" fieldtype=""string"" WIDTH=""36""/>"
            s = s & "<FIELD attrname=""MONTO"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""SERIE"" fieldtype=""string"" WIDTH=""100""/>"
            s = s & "<FIELD attrname=""FOLIO"" fieldtype=""string"" WIDTH=""100""/>"
            s = s & "<FIELD attrname=""RFCEMISOR"" fieldtype=""string"" WIDTH=""16""/>"
            s = s & "<FIELD attrname=""RFCRECEPTOR"" fieldtype=""string"" WIDTH=""16""/>"
            s = s & "<FIELD attrname=""FECHAUUID"" fieldtype=""string"" WIDTH=""10""/>"
            s = s & "<FIELD attrname=""TIPOCOMPROBANTE"" fieldtype=""i2""/>"
            s = s & "</FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></METADATA><ROWDATA>"
            s = s & "<ROW VersionCOI=""810"" TipoPoliz=""Dr"" DiaPoliz=""30"" ConcepPoliz=""" & tPOLIZA.Text & """><Partidas>"
            'BACKUPTXT("XML", s)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try
            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()

                CUENTA = Fg(k, 1)
                CONCEPTO = Fg(k, 3)
                IMPORTE1 = 0
                Try
                    IMPORTE1 = Fg(k, 4)
                Catch ex As Exception
                End Try
                IMPORTE2 = 0
                Try
                    IMPORTE2 = Fg(k, 5)
                Catch ex As Exception
                End Try

                If CUENTA.Trim.Length > 0 Then

                    If Fg(k, 6) IsNot Nothing Then
                        XML = Fg(k, 6)
                    Else
                        XML = ""
                    End If
                    CADENA1 = ""
                    If XML.Trim.Length > 0 Then

                        EmisorRfcCFD = "" : FolioCFD = "" : SerieCFD = "" : FechaEmision = "" : TotalCFD = 0 : SubtotalCFD = 0 : IVAcfd = 0
                        VersionCFD = "" : MonedaCFD = "" : FormaPagoCFD = "" : UsoCFDICFD = "" : TipoComprobanteCFD = "" : UsoCFD = ""
                        FILE_XML = ""
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT ARCHIVO_XML FROM GCCOMPRAS WHERE CVE_DOC  = '" & XML & "'"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read Then
                                        FILE_XML = OBTENER_RUTA_XML() & "\" & dr("ARCHIVO_XML")
                                    End If
                                End Using
                            End Using
                            If FILE_XML.Trim.Length > 0 Then
                                UUID_XML = OBTENER_UUID_XML(FILE_XML)
                            End If
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            FechaEmision = FechaEmision.Substring(8, 2) & "/" & FechaEmision.Substring(5, 2) & "/" & FechaEmision.Substring(0, 4)
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        If Not IsDate(FechaEmision) Then
                            FechaEmision = ""
                            NUM_PARX = 0
                        Else
                            NUM_PARX = NUM_PAR
                        End If
                        If UUID_XML.Trim.Length > 0 Then
                            CADENA1 = "<ROWCDSPartidasUUID NUMREG=""" & NUM_PARX & """ UUIDTIMBRE=""" & UUID_XML & """ MONTO=""" & TotalCFD & """ SERIE=""" & SerieCFD & """ FOLIO=""" & FolioCFD & """ RFCEMISOR=""" & EmisorRfcCFD & """ RFCRECEPTOR=""TEM820612AF7"" FECHAUUID=""" &
                                FechaEmision & """ TIPOCOMPROBANTE=""1""/>"
                        Else
                            CADENA1 = ""
                        End If
                    Else
                        CADENA1 = ""
                        NUM_PARX = 0
                    End If

                    s = s & "<ROWPartidas Cuenta=""" & CUENTA & """ Depto=""0"" ConceptoPol=""" & CONCEPTO & """"
                    If IMPORTE1 > 0 Then
                        s = s & " Monto=""" & Math.Round(IMPORTE1, 2) & """ TipoCambio=""1"" DebeHaber=""D"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    Else
                        s = s & " Monto=""" & Math.Round(IMPORTE2, 2) & """ TipoCambio=""1"" DebeHaber=""H"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    End If

                    s = s & " RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""" &
                        NUM_PARX & """ IDFISCAL=""""><CDSPartidasUUID>" & CADENA1 & "</CDSPartidasUUID>"
                    s = s & "</ROWPartidas>"

                    If NUM_PARX <> 0 Then
                        NUM_PAR = NUM_PAR + 1
                    End If
                    'IDFISCAL=""""><CDSPartidasUUID>" & CADENA1 & "</CDSPartidasUUID></ROWPartidas>"
                End If
            Next
            s = s & "</Partidas></ROW></ROWDATA></DATAPACKET>"

            Var4 = "NO"

            BACKUPXML(RUTA_MODELO & "\" & tPOLIZA.Text.Replace("/", "-") & ".POL", s)

            Try
                SQL = "UPDATE GCCONCI_VALES_COMBUS SET POL_GEN = 'S' WHERE CVE_COVC = " & Var46
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("655. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If Var4 = "OK" Then
                MsgBox("La póliza modelo se grabo satisfactoriamente en " & RUTA_MODELO & "\" & tPOLIZA.Text & ".XML")
                frmConciValesCombus.DESPLEGAR3()
            Else
                MsgBox("No se logro crear la póliza modelo en " & RUTA_MODELO & "\" & tPOLIZA.Text & ".XML")
            End If
        Catch ex As Exception
            Bitacora("655. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("655. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        fg.Cursor = Cursors.Default
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String, strSerie As String, strFolio As String, strFechaEmision As String, strSello As String, strNoCertificado As String
        Dim strSubtotal As String, strTotal As String, strMoneda As String, strCondiciones As String, strFormaPago As String, strMetodoPago As String
        Dim strLugarExpedicion As String, strReceptorRfc As String, strEmisorRfc As String, strEmisorNombre As String, strEmisorCalle As String
        Dim strEmisorNoExterior As String, strEmisorNoInterior As String, strEmisorColonia As String, strEmisorMunicipio As String
        Dim strEmisorEstado As String, strUsoCFDI As String, strRegimen As String, strDescuento As String, strNumCtaPago As String, strVersion As String
        Dim NoCertificadoSAT As String, UUID As String, UUIDR As String, FechaTimbrado As String, strVersionTimbre As String, NumOperacion As String
        Dim Monto As String, FormaDePagoP As String, FechaPago As String, Folio As String, Serie As String, ImpSaldoInsoluto As String
        Dim ImpPagado As String, ImpSaldoAnt As String, NumParcialidad As String, MetodoDePagoDR As String
        Dim concepto As XmlNodeList, Elemento As XmlNode, subnodo As XmlElement, IdDocumento As String
        Dim XML As String, xDoc As XmlDocument, xNodo As XmlNodeList, xAtt As XmlElement, Comprobante As XmlNode, Impuestos As XmlNode = Nothing
        Dim totalImpuestosTrasladados As Decimal, TotalImpuestosRetenidos As Decimal, vsTIT As Decimal, k As Integer
        'aqui
        If fFILE_XML.Trim.Length = 0 Then
            Return ""
        End If

        If Not File.Exists(fFILE_XML) Then
            Return ""
        End If

        strEmisorNombre = "" : strFechaEmision = "" : strEmisorCalle = "" : strEmisorMunicipio = "" : strEmisorEstado = ""
        strEmisorNoExterior = "" : strEmisorNoInterior = "" : strEmisorColonia = "" : strFormaPago = "" : strMetodoPago = ""
        strSubtotal = "" : strTotal = "" : strEmisorRfc = "" : strFolio = "" : strDescuento = "0" : strNumCtaPago = ""
        strSerie = "" : strVersionTimbre = "" : UUID = "" : FechaTimbrado = "" : NoCertificadoSAT = "" : strTipoComprobante = "" : strUsoCFDI = ""
        strReceptorRfc = "" : UUIDR = ""

        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""

        xDoc = New XmlDocument

        Try
            XML = fFILE_XML

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
                        totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("totalImpuestosTrasladados").Value)
                    Catch ex As Exception
                        totalImpuestosTrasladados = 0
                    End Try
                    If totalImpuestosTrasladados = 0 Then
                        Try
                            Impuestos = Comprobante("cfdi:Impuestos")
                            totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("TotalImpuestosTrasladados").Value)
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
                                    vsTIT = vsTIT + CDec(vRegIT.FirstChild.Attributes("importe").Value)
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
                        TotalImpuestosRetenidos = CDec(Impuestos.Attributes.GetNamedItem("TotalImpuestosRetenidos").Value)

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
                    UUIDR = ""
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:CfdiRelacionados")
                        If xNodo.Count > 0 Then
                            If xNodo.Count > 0 Then
                                For Each xAtt In xNodo.Item(0)
                                    Application.DoEvents()
                                    Me.Refresh()
                                    If xAtt.LocalName Like "CfdiRelacionado" Then
                                        UUIDR = VarXml(xAtt, "UUID")
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
            Return UUID
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return UUID
        End Try
    End Function
    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function
End Class
