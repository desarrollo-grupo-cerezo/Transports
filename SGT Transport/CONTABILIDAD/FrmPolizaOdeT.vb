Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Input
Public Class FrmPolizaOdeT
    Dim CADENA As String = ""
    Dim CADENA2 As String = ""
    Dim RUTA_MODELO As String = ""
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource

    Private Sub FrmPolizaOdeT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Almacén", GetType(System.String))
            dt.Columns.Add("Descripción", GetType(System.String))

            CboAlmacen.Items.Clear()
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " WHERE STATUS = 'A' AND CVE_ALM <> 1 AND CVE_ALM <> 2 AND CVE_ALM <> 3 AND CVE_ALM <> 8 ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(dr("CVE_ALM"), dr("DESCR"))
                    End While
                End Using
            End Using

            CboAlmacen.TextDetached = True
            CboAlmacen.ItemsDataSource = dt.DefaultView
            CboAlmacen.ItemsDisplayMember = "Descripción"
            CboAlmacen.ItemsValueMember = "Almacén"
            CboAlmacen.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboAlmacen.HtmlPattern = "<table><tr><td width=30>{Almacén}</td><td width=240>{Descripción}</td><td width=300></tr></table>"

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


            GET_RUTA_MODELO()

            tPOLIZA.Text = "Poliza de mantenimiento " & DateTime.Now.ToString("MMMM")

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPolizaOdeT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Poliza orden de trabajo")
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
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_ALM As Integer, CUEN_CONTABLE As String = "", SUMA_ALMACEN As Decimal = 0, LIB13 As String
        Dim NewStyle1 As CellStyle

        If CboAlmacen.SelectedIndex = -1 Then
            MsgBox("Por favor seleccione un almacen")
            Return
        End If

        Fg.Rows.Count = 1

        CVE_ALM = CboAlmacen.Items(CboAlmacen.SelectedIndex)

        Fg.Redraw = False
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Magenta
        NewStyle1.ForeColor = Color.Black
        'CADENA = " WHERE O.FECHA >= '" & FSQL(F1.Value) & "' AND O.FECHA <= '" & FSQL(F2.Value) & "' "
        'CADENA2 = " WHERE C.FECHA_DOC >= '" & FSQL(F1.Value) & "' AND C.FECHA_DOC <= '" & FSQL(F2.Value) & "' "
        '6, 7 y 10
        Try
            SQL = "SELECT P.CVE_ORD, P.CVE_ART, ISNULL(O.CVE_UNI,'') AS CVE_TRAC, ISNULL(U.DESCR,'') AS DESCR_UNI, 
                ISNULL(U.CUEN_CONT,'') AS CTA_UNIDAD, ISNULL(U.CUEN_CONT2,'') AS CTA_UNIDAD2, ISNULL(P.CVE_ALM,0) AS CVE_ALM_ART, 
                P.CVE_ART, ISNULL(CAMPLIB13,'') AS LIB13, ISNULL(P.IMPORTE,0) AS IMPORT, P.TIEMPO_REAL, 
                ISNULL((SELECT TOP 1 CAMPLIB13 FROM PAR_COMPO" & Empresa & " PO LEFT JOIN INVE_CLIB" & Empresa & " L ON L.CVE_PROD = PO.CVE_ART 
                WHERE CVE_DOC = P.TIEMPO_REAL),'') AS LIB13_OC
                FROM GCORDEN_TRA_SER_EXT P
                LEFT JOIN INVE_CLIB" & Empresa & " L ON L.CVE_PROD = P.CVE_ART
                LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = O.CVE_UNI " &
                CADENA & " AND O.STATUS <> 'C' AND P.CVE_ALM = " & CVE_ALM & " ORDER BY P.CVE_ORD"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CVE_ALM = dr("CVE_ALM_ART")

                        If dr("CVE_ART") = "TOT" Then
                            LIB13 = dr("LIB13_OC")
                        Else
                            LIB13 = dr("LIB13")
                        End If
                        Try
                            If dr("CTA_UNIDAD").ToString.Trim.Length > 7 Then
                                CUEN_CONTABLE = dr("CTA_UNIDAD2") & "-" & dr("CTA_UNIDAD").ToString.Substring(4, 3) & "-" & LIB13
                            Else
                                CUEN_CONTABLE = dr("CTA_UNIDAD2")
                            End If
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        Fg.AddItem("" & vbTab & CUEN_CONTABLE & vbTab & "0" & vbTab & "Orden de trabajo " & dr("CVE_ORD") & "     Orden de compra:  " &
                                   dr("TIEMPO_REAL") & vbTab & dr("IMPORT") & vbTab & "")
                        SUMA_ALMACEN += dr("IMPORT")

                        BACKUPTXT("POLIZAODETE", dr("CVE_ORD") & "," & dr("IMPORT"))

                        If dr.ReadNullAsEmptyString("CTA_UNIDAD").Trim.Length = 0 Or dr("CTA_UNIDAD2").Trim.Length = 0 Or LIB13.Trim.Length = 0 Then
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 6, NewStyle1)
                        End If
                    End While
                End Using
            End Using

            CUEN_CONTABLE = BUSCA_CTA_CONTABLE(CVE_ALM)

            Fg.AddItem("" & vbTab & CUEN_CONTABLE & vbTab & "0" & vbTab & "Almacén " & CVE_ALM & vbTab & "" & vbTab & Math.Round(SUMA_ALMACEN, 6))
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & Math.Round(SUMA_ALMACEN, 6) & vbTab & Math.Round(SUMA_ALMACEN, 6))

            Fg.AutoSizeCols()

            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
            Fg.Select()

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Sub DESPLEGAR_ODEC()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_ALM As Integer, CUEN_CONTABLE As String, SUMA_ALMACEN As Decimal = 0
        Dim NewStyle1 As CellStyle

        If CboAlmacen.SelectedIndex = -1 Then
            MsgBox("Por favor seleccione un almacen")
            Return
        End If
        'CUANDO     ES  ALMNACEN    3           CUANDO     ES  ALMNACEN    3
        Fg.Rows.Count = 1

        CVE_ALM = CboAlmacen.Items(CboAlmacen.SelectedIndex)

        Fg.Redraw = False
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Magenta
        NewStyle1.ForeColor = Color.Black
        'CUANDO     ES  ALMNACEN    3           CUANDO     ES  ALMNACEN    3
        Try
            SQL = "SELECT P.CVE_DOC, P.CVE_ART, ISNULL(P.NUM_ALM,0) AS CVE_ALM_ART, ISNULL(CUENT_CONT,'') AS CUEN_CONTABLE,
                ISNULL(CAMPLIB13,'') AS     , P.TOT_PARTIDA AS IMPORT
                FROM PAR_COMPO" & Empresa & " P
                LEFT JOIN COMPO" & Empresa & " O ON O.CVE_DOC = P.CVE_DOC
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                LEFT JOIN INVE_CLIB" & Empresa & " L ON L.CVE_PROD = P.CVE_ART " &
                CADENA & " AND O.STATUS <> 'C' AND P.NUM_ALM = " & CVE_ALM & "  ORDER BY P.CVE_DOC"
            'CUANDO     ES  ALMNACEN    3           CUANDO     ES  ALMNACEN    3
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CVE_ALM = dr("CVE_ALM_ART")
                        CUEN_CONTABLE = dr("CUEN_CONTABLE")
                        'CUANDO     ES  ALMNACEN    3           CUANDO     ES  ALMNACEN    3
                        Fg.AddItem("" & vbTab & CUEN_CONTABLE & vbTab & "0" & vbTab & "Orden de compra " & dr("CVE_DOC") & "     Articulo:" &
                                   dr("CVE_ART") & vbTab & dr("IMPORT") & vbTab & "")

                        SUMA_ALMACEN += dr("IMPORT")
                        If CUEN_CONTABLE.Trim.Length = 0 Then
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                            Fg.SetCellStyle(Fg.Rows.Count - 1, 6, NewStyle1)
                        End If
                    End While
                End Using
            End Using
            'CUANDO     ES  ALMNACEN    3           CUANDO     ES  ALMNACEN    3
            CUEN_CONTABLE = BUSCA_CTA_CONTABLE(CVE_ALM)

            Fg.AddItem("" & vbTab & CUEN_CONTABLE & vbTab & "0" & vbTab & "Almacén " & CVE_ALM & vbTab & "" & vbTab & Math.Round(SUMA_ALMACEN, 6))
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & Math.Round(SUMA_ALMACEN, 6) & vbTab & Math.Round(SUMA_ALMACEN, 6))

            Fg.AutoSizeCols()

            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
            Fg.Select()

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Try
            Dim CVE_ALM As Integer

            If CboAlmacen.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione un almacen")
                Return
            End If

            CVE_ALM = CboAlmacen.Items(CboAlmacen.SelectedIndex)

            If CVE_ALM = 3 Then
                CADENA = " WHERE O.FECHA_DOC >= '" & FSQL(F1.Value) & "' AND O.FECHA_DOC <= '" & FSQL(F2.Value) & "' "
                DESPLEGAR_ODEC()
            Else
                CADENA = " WHERE O.FECHA >= '" & FSQL(F1.Value) & "' AND O.FECHA <= '" & FSQL(F2.Value) & "' "
                CADENA2 = " WHERE C.FECHA_DOC >= '" & FSQL(F1.Value) & "' AND C.FECHA_DOC <= '" & FSQL(F2.Value) & "' "
                DESPLEGAR()
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Poliza orden de compra")
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
        Dim s As String = "", nDoc As Integer = 0
        Dim CUENTA As String, CONCEPTO As String, IMPORTE1 As Decimal, IMPORTE2 As Decimal

        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Trim.Length = 0 Then
                    nDoc += 1
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

        Try
            s = "<?xml version=""1.0"" standalone=""yes""?>  <DATAPACKET Version=""2.0""><METADATA>"
            s &= "<FIELDS>"
            s &= "<FIELD attrname=""VersionCOI"" fieldtype=""i2""/>"
            s &= "<FIELD attrname=""TipoPoliz"" fieldtype=""string"" WIDTH=""5""/>"
            s &= "<FIELD attrname=""DiaPoliz"" fieldtype=""string"" WIDTH=""2""/>"
            s &= "<FIELD attrname=""ConcepPoliz"" fieldtype=""string"" WIDTH=""120""/>"
            s &= "<FIELD attrname=""UUID"" fieldtype=""string"" WIDTH=""100""/>"
            s &= "<FIELD attrname=""Partidas"" fieldtype=""nested""><FIELDS>"
            s &= "<FIELD attrname=""Cuenta"" fieldtype=""string"" WIDTH=""21""/>"
            s &= "<FIELD attrname=""Depto"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""ConceptoPol"" fieldtype=""string"" WIDTH=""120""/>"
            s &= "<FIELD attrname=""Monto"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""TipoCambio"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""DebeHaber"" fieldtype=""string"" WIDTH=""1""/>"
            s &= "<FIELD attrname=""ccostos"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""proyectos"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""Porcentaje"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""FRMPAGO"" fieldtype=""string"" WIDTH=""5""/>"
            s &= "<FIELD attrname=""NUMCHEQUE"" fieldtype=""string"" WIDTH=""20""/>"
            s &= "<FIELD attrname=""MONTOBN"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""BANCO"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""CTAORIG"" fieldtype=""string"" WIDTH=""50""/>"
            s &= "<FIELD attrname=""BENEF"" fieldtype=""string"" WIDTH=""300""/>"
            s &= "<FIELD attrname=""RFC"" fieldtype=""string"" WIDTH=""13""/>"
            s &= "<FIELD attrname=""BANCODEST"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""CTADEST"" fieldtype=""string"" WIDTH=""50""/>"
            s &= "<FIELD attrname=""FECHACHEQUE"" fieldtype=""string"" WIDTH=""10""/>"
            s &= "<FIELD attrname=""BANCOORIGEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s &= "<FIELD attrname=""BANCODESTEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s &= "<FIELD attrname=""IDUUID"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""IDFISCAL"" fieldtype=""string"" WIDTH=""40""/>"
            s &= "<FIELD attrname=""CDSPartidasUUID"" fieldtype=""nested"">"
            s &= "<FIELDS>"
            s &= "<FIELD attrname=""NUMREG"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""UUIDTIMBRE"" fieldtype=""string"" WIDTH=""36""/>"
            s &= "<FIELD attrname=""MONTO"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""SERIE"" fieldtype=""string"" WIDTH=""100""/>"
            s &= "<FIELD attrname=""FOLIO"" fieldtype=""string"" WIDTH=""100""/>"
            s &= "<FIELD attrname=""RFCEMISOR"" fieldtype=""string"" WIDTH=""16""/>"
            s &= "<FIELD attrname=""RFCRECEPTOR"" fieldtype=""string"" WIDTH=""16""/>"
            s &= "<FIELD attrname=""FECHAUUID"" fieldtype=""string"" WIDTH=""10""/>"
            s &= "<FIELD attrname=""TIPOCOMPROBANTE"" fieldtype=""i2""/>"
            s &= "</FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></METADATA><ROWDATA>"
            s &= "<ROW VersionCOI=""810"" TipoPoliz=""Dr"" DiaPoliz=""30"" ConcepPoliz=""" & tPOLIZA.Text & """><Partidas>"
            BACKUPTXT("XML", s)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try
            Me.Cursor = Cursors.WaitCursor
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
                    s &= "<ROWPartidas Cuenta=""" & CUENTA & """ Depto=""0"" ConceptoPol=""" & CONCEPTO & """"
                    If IMPORTE1 > 0 Then
                        s &= " Monto=""" & Math.Round(IMPORTE1, 2) & """ TipoCambio=""1"" DebeHaber=""D"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    Else
                        s &= " Monto=""" & Math.Round(IMPORTE2, 2) & """ TipoCambio=""1"" DebeHaber=""H"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    End If

                    s &= " RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""0"" IDFISCAL=""""><CDSPartidasUUID></CDSPartidasUUID>"
                    s &= "</ROWPartidas>"
                End If
            Next
            s &= "</Partidas></ROW></ROWDATA></DATAPACKET>"

            Var4 = "NO"

            BACKUPXML(RUTA_MODELO & "\" & tPOLIZA.Text.Replace("/", "-") & ".POL", s)

            Me.Cursor = Cursors.Default

            If Var4 = "OK" Then
                MsgBox("La poliza modelo se grabo satisfactoriamente en " & RUTA_MODELO & "\" & tPOLIZA.Text & ".XML")
            Else
                MsgBox("No se logro crear la poliza modelo en " & RUTA_MODELO & "\" & tPOLIZA.Text & ".XML")
            End If
        Catch ex As Exception
            Bitacora("655. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("655. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub CboAlmacen_DropDownClosed(sender As Object, e As DropDownClosedEventArgs)
        Try
            Dim d1 As DateTime = F1.Value

            tPOLIZA.Text = "Poliza de mantenimiento " & MonthName(d1.Month)
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
