Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Input
Public Class FrmPolizaRenovados
    Dim CADENA As String = ""
    Dim CADENA2 As String = ""
    Dim RUTA_MODELO As String = ""
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmPolizaRenovados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Almacén", GetType(System.String))
            dt.Columns.Add("Descripción", GetType(System.String))

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
    Private Sub FrmPolizaRenovados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Poliza renovados")
    End Sub

    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        If Not Valida_Conexion() Then
            Return
        End If
        Dim nDoc As Integer, CUEN_CONTABLE As String = "", SUMA_ALMACEN As Decimal = 0, SUMA As Decimal = 0, LIB13 As String = ""
        Dim NewStyle1 As CellStyle

        Fg.Rows.Count = 1
        Fg.Redraw = False
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Magenta
        NewStyle1.ForeColor = Color.Black
        Try        'GCUNIDADES.CUEN_CONT2-???"GCUNIDADES.CUENT_CONT"????-0002

            Try
                SQL = "SELECT MAX(CVE_UNI) AS CVEUNI, MAX(NUM_ALM) AS NUMALM, 
                    SUM(COSTO) AS COST, MAX(O1.DESCR) AS DES_DOC, MAX(O2.DESCR) AS DES_PAR, 
                    MAX(U.CUEN_CONT) AS UNI_CUEN, ISNULL(MAX(U.CUEN_CONT2),'') AS UNI_CUEN2
                    FROM GCGASTOS_RENOVADO G
                    LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = G.CVE_UNI 
                    LEFT JOIN GCOBS O1 ON O1.CVE_OBS = G.CVE_OBS_DOC
                    LEFT JOIN GCOBS O2 ON O2.CVE_OBS = G.CVE_OBS_PAR
                    WHERE ISNULL(G.STATUS,'A') = 'A' AND 
                    FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' 
                    GROUP BY CVE_UNI"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Try
                                CUEN_CONTABLE = ""
                                Try
                                    CUEN_CONTABLE = dr("UNI_CUEN2") & "-" & dr("UNI_CUEN").Substring(4, 3) & "-0002"
                                Catch ex As Exception
                                End Try
                                Fg.AddItem("" & vbTab & CUEN_CONTABLE & vbTab & "0" & vbTab & "Unidad " & dr("CVEUNI") & vbTab & dr("COST") & vbTab & "")
                                SUMA_ALMACEN = SUMA_ALMACEN + dr("COST")

                                If dr.ReadNullAsEmptyString("UNI_CUEN2").Trim.Length = 0 Then
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
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            CUEN_CONTABLE = BUSCA_CTA_CONTABLE(3)

            Fg.AddItem("" & vbTab & CUEN_CONTABLE & vbTab & "0" & vbTab & "Almacén 3" & vbTab & "" & vbTab & Math.Round(SUMA_ALMACEN, 6))
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & Math.Round(SUMA_ALMACEN, 6) & vbTab & Math.Round(SUMA_ALMACEN, 6))

            Fg.AutoSizeCols()

            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
            Fg.Select()

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True

        MsgBox("Proceso terminado")

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Poliza renovados")
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
