Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Input
Public Class FrmPolizaSalidaLLantas
    Dim RUTA_MODELO As String = ""
    Private Sub FrmPolizaSalidaLLantas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Catch ex As Exception
            End Try

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

            ' 1 o varios, son los 4, 5, 6, 7 y 10
            C1List1.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " WHERE STATUS = 'A' AND 
                    (CVE_ALM = 4 OR CVE_ALM = 5 OR CVE_ALM = 6 OR CVE_ALM = 7 OR CVE_ALM = 10)"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_ALM") & ";" & dr("DESCR"))
                    End While
                End Using
            End Using
            Me.C1List1.Splits(0).DisplayColumns(0).Width = 50
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

            tPOLIZA.Text = "Poliza salida de llantas " & DateTime.Now.ToString("MMMM")

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmPolizaSalidaLLantas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Poliza salida llantas")
    End Sub

    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Dim nDoc As Integer, CADENA As String = "", CUEN_CONTABLE As String, LEY_ALM As String = "", NUM_ALM As Integer
        Dim CUEN_CONT_INVE As String, SUMA_ALMACEN As Decimal = 0, SUMA As Decimal = 0, j As Integer = 0
        Dim Sigue As Boolean = True, ALM1 As Integer, ALM2 As Integer
        Dim NewStyle1 As CellStyle

        Fg.Redraw = False
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.LightGray
        NewStyle1.ForeColor = Color.Black

        'ALMACENES
        CADENA = " AND ("
        For row As Integer = 0 To C1List1.ListCount - 1
            Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
            Dim cellValue1 As Object = C1List1.GetDisplayText(row, 1)

            If C1List1.GetSelected(row) Then

                If Sigue Then
                    Sigue = True
                    ALM1 = cellValue.ToString
                End If
                ALM2 = cellValue.ToString
                'CADENA = CADENA & "M.ALMACEN = " & cellValue.ToString & " OR "
                'LEY_ALM = "Almacen " & cellValue.ToString
                'NUM_ALM = cellValue.ToString
                j = j + 1
            End If
        Next
        If j = 0 Then
            MsgBox("Por favor seleccione al menos un almacén")
            Return
        End If

        If j > 1 Then
            LEY_ALM = "Almacen"
        End If
        CADENA = CADENA.Substring(0, CADENA.Length - 4) & ")"
        Fg.Rows.Count = 1

        Try
            SQL = "SELECT M.REFER, ISNULL(MAX(M.ALMACEN),0) AS ALM, ISNULL(SUM(M.CANT * M.COSTO),0) AS IMPORT, MAX(U.CLAVEMONTE) AS UNIDAD, 
                ISNULL(MAX(U.CUEN_CONT2),'') AS UNI_CUEN2, ISNULL(MAX(U.CUEN_CONT),'') AS UNI_CUEN, ISNULL(MAX(I.CUENT_CONT),'') AS CTA_INVE
                FROM MINVE" & Empresa & " M
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART 
                LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = M.ALMACEN
                LEFT JOIN GCUNIDADES U ON U.CLAVE = M.CLAVE_CLPV
                WHERE M.FECHA_DOCU >= '" & FSQL(F1.Value) & "' AND M.FECHA_DOCU <= '" & FSQL(F2.Value) & "' " &
                CADENA & " AND CVE_CPTO = 67 AND RTRIM(LTRIM(ISNULL(CLAVE_CLPV,''))) <> '' 
                GROUP BY M.REFER ORDER BY M.REFER"

            SQL = "SELECT M.REFER, M.CLAVE_CLPV, M.CVE_ART, I.DESCR, M.COSTO, (M.COSTO * M.CANT) AS IMPORTE, M.CANT, M.ALMACEN,
                M.CVE_CPTO, M.FECHA_DOCU, U.CLAVEMONTE
                FROM MINVE" & Empresa & " M
                LEFT JOIN INVE" & Empresa & " I ON M.CVE_ART = I.CVE_ART 
                LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = I.LIN_PROD
                LEFT JOIN GCUNIDADES U ON M.CLAVE_CLPV = U.CLAVE
                WHERE (M.CVE_CPTO = 62 or M.CVE_CPTO = 67) AND M.FECHA_DOCU >= ? AND M.FECHA_DOCU <= ? AND
                (ISNULL(dbo.CLIN01.CVE_LIN,'') in (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) OR ISNULL(dbo.CLIN01.CVE_LIN,'') = '') AND 
                (ISNULL(dbo.M.ALMACEN,0) = ? OR ISNULL(dbo.M.ALMACEN,0) = ?  OR ISNULL(dbo.M.ALMACEN,0)  = ?  OR ISNULL(dbo.M.ALMACEN,0) = ?  OR 
                ISNULL(dbo.M.ALMACEN,0) = ? OR ISNULL(dbo.M.ALMACEN,0) = ?  OR ISNULL(dbo.M.ALMACEN,0)  = ?  OR ISNULL(dbo.M.ALMACEN,0) = ?  OR 
                ISNULL(dbo.M.ALMACEN,0) = ? OR ISNULL(dbo.M.ALMACEN,0) = ?  OR ISNULL(dbo.M.ALMACEN,0)  = ?  OR ISNULL(dbo.M.ALMACEN,0) = ?  OR 
                ISNULL(dbo.M.ALMACEN,0) = ? OR ISNULL(dbo.M.ALMACEN,0) = ?  OR ISNULL(dbo.M.ALMACEN,0)  = ?  OR ISNULL(dbo.M.ALMACEN,0) = ?  OR 
                ISNULL(dbo.M.ALMACEN,0) = ? OR ISNULL(dbo.M.ALMACEN,0) = ?  OR ISNULL(dbo.M.ALMACEN,0)  = ?  OR ISNULL(dbo.M.ALMACEN,0) = ? )"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            CUEN_CONT_INVE = dr("UNI_CUEN2") & "-" & dr("UNI_CUEN").Substring(4, 3) & "-" & dr("CTA_INVE")

                            Fg.AddItem("M" & vbTab & CUEN_CONT_INVE & vbTab & "0" & vbTab & "Orden de trabajo " & dr("REFER") & vbTab & dr("IMPORT") & vbTab & "")
                            SUMA_ALMACEN = SUMA_ALMACEN + dr("IMPORT")
                            If CUEN_CONT_INVE.Trim.Length = 0 Then
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 6, NewStyle1)
                                nDoc = nDoc + 1
                            End If
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            If j = 1 Then
                CUEN_CONTABLE = BUSCA_CTA_CONTABLE(NUM_ALM) '  BUSCO LA CUENTA CONTABLE DEL ALMACEN
            Else
                CUEN_CONTABLE = ""
            End If


            Fg.AddItem("" & vbTab & CUEN_CONTABLE & vbTab & "0" & vbTab & LEY_ALM & vbTab & "" & vbTab & SUMA_ALMACEN)
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & Math.Round(SUMA_ALMACEN, 6) & vbTab & SUMA_ALMACEN)

            Fg.AutoSizeCols()
            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
            Fg.Select()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Poliza salida llantas")
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
                    s = s & "<ROWPartidas Cuenta=""" & CUENTA & """ Depto=""0"" ConceptoPol=""" & CONCEPTO & """"
                    If IMPORTE1 > 0 Then
                        s = s & " Monto=""" & Math.Round(IMPORTE1, 2) & """ TipoCambio=""1"" DebeHaber=""D"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    Else
                        s = s & " Monto=""" & Math.Round(IMPORTE2, 2) & """ TipoCambio=""1"" DebeHaber=""H"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    End If

                    s = s & " RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""0"" IDFISCAL=""""><CDSPartidasUUID></CDSPartidasUUID>"
                    s = s & "</ROWPartidas>"
                End If
            Next
            s = s & "</Partidas></ROW></ROWDATA></DATAPACKET>"

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

    Private Sub F1_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles F1.DropDownClosed
        Try
            Dim d1 As DateTime = F1.Value

            tPOLIZA.Text = "Poliza salida de llantas " & MonthName(d1.Month)
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
