
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmConciCartaPorteAE
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmConciCartaPorteAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Me.KeyPreview = True
        Fg.Rows.Count = 1
        Fg2.Rows.Count = 1
        Fg.Cols.Count = 10

        Fg.Styles(CellStyleEnum.Normal).WordWrap = True
        Fg2.Styles(CellStyleEnum.Normal).WordWrap = True
        Fg.Cols(1).Sort = SortFlags.Ascending
        Fg.Cols(0).Width = 5
        Fg2.Cols(0).Width = 5

        F1.Value = Date.Today
        F1.FormatType = c1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = c1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"
        Me.Left = 0
        Me.Width = Screen.PrimaryScreen.Bounds.Width

        tCVE_CCP.Text = ""
        tCVE_DOC.Text = ""
        tCLIENTE.Text = ""
        If Var1 = "Nuevo" Then
            Try
                tCVE_CCP.Text = GET_MAX("GCCONCI_CARTA_PORTE", "CVE_CCP")
                tCVE_CCP.Enabled = False
                tCVE_DOC.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT C.CVE_CCP, C.CLIENTE, C.CVE_DOC, C.FECHA_DOC " &
                    "FROM GCCONCI_CARTA_PORTE C " &
                    "WHERE CVE_CCP = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_CCP.Text = dr("CVE_CCP").ToString
                    tCLIENTE.Text = dr("CLIENTE")
                    LtNombre.Text = BUSCA_CAT("Cliente", tCLIENTE.Text)
                    tCVE_DOC.Text = dr("CVE_DOC").ToString
                    F1.Value = dr("FECHA_DOC").ToString
                    DESPLEGAR2(Var2)
                End If
                dr.Close()
                tCLIENTE.Enabled = False
                btnCliente.Enabled = False
                tCVE_CCP.Enabled = False
                Fg.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        DESPLEGAR("")

        btnAgregar.Left = Fg2.Left + 200
        btnRegresar.Left = btnAgregar.Left + 600

    End Sub
    Sub DESPLEGAR(fCliente As String)
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            SQL = "SELECT FACTURA, CVE_VIAJE, P.CLIENTE, C.NOMBRE, P.SUBTOTAL, P.IVA, P.RETENCION, P.IMPORTE, P.FECHAELAB
                FROM CFDI P
                LEFT JOIN GCASIGNACION_VIAJE A ON A.CVE_DOC = P.FACTURA    
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                WHERE ISNULL(P.ESTATUS,'') <> 'C' " &
                IIf(fCliente.Trim.Length > 0, "AND P.CLIENTE = '" & tCLIENTE.Text & "'", "") & " ORDER BY FACTURA"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("FACTURA") & vbTab & dr("CVE_VIAJE") & vbTab & dr("CLIENTE") & vbTab & dr("NOMBRE") & vbTab &
                                    dr("FECHAELAB") & vbTab & dr("SUBTOTAL") & vbTab & dr("IVA") & vbTab & dr("RETENCION") & vbTab & dr("IMPORTE"))
                    End While
                End Using
            End Using

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR2(fCVE_CPP As Long)
        If Not Valida_Conexion() Then
            Return
        End If
        Dim SUBTOTAL As Single
        Dim IVA As Single
        Dim NETO As Single
        Dim RETENCION As Single

        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg2.Styles.Add("NewStyle1")
        NewStyle1.WordWrap = True


        Try
            SQL = "SELECT PP.CVE_CCP, PP.CVE_FOLIO, P.CVE_VIAJE, CLIENTE, C.NOMBRE, P.FECHA_DOC, SUBTOTAL, IVA, RETENCION, NETO " &
                "FROM GCCONCI_CARTA_PORTE_PAR PP " &
                "LEFT JOIN GCCARTA_PORTE P ON P.CVE_FOLIO = PP.CVE_FOLIO " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE " &
                "WHERE PP.CVE_CCP = " & fCVE_CPP
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg2.AddItem("" & vbTab & dr("CVE_FOLIO") & vbTab & dr("CVE_VIAJE") & vbTab & dr("CLIENTE") & vbTab & dr("NOMBRE") & vbTab &
                                    dr("FECHA_DOC") & vbTab & dr("SUBTOTAL") & vbTab & dr("IVA") & vbTab & dr("RETENCION") & vbTab & dr("NETO"))
                        Fg2.Rows(Fg2.Rows.Count - 1).Style = NewStyle1
                        SUBTOTAL = SUBTOTAL + dr("SUBTOTAL")
                        IVA = IVA + dr("IVA")
                        RETENCION = RETENCION + dr("RETENCION")
                        NETO = NETO + dr("NETO")
                    End While
                End Using
            End Using

            tSUBTOTAL.Text = Format(SUBTOTAL, "###,###,##0.00")
            tIVA.Text = Format(IVA, "###,###,##0.00")
            tRETENCION.Text = Format(RETENCION, "###,###,##0.00")
            tNETO.Text = Format(NETO, "###,###,##0.00")

            Fg2.AutoSizeRows()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tCVE_DOC.Text.Trim.Length = 0 Then
            MsgBox("La factura no debe quedar vacia, verifique por favor")
            Return
        End If
        If tCLIENTE.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione el cliente")
            Return
        End If

        Var15 = ""
        Try
            Var10 = tCLIENTE.Text
            Var11 = LtNombre.Text

            If IsNumeric(tNETO.Text.Replace(",", "")) Then
                Var21 = tNETO.Text.Replace(",", "")
            Else
                Var21 = 0
            End If

            frmApliPagoConciCartaPorte.ShowDialog()

        Catch ex As Exception
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Var15 = "SI" Then
            SQL = "UPDATE GCCONCI_CARTA_PORTE SET CVE_DOC = @CVE_DOC, FECHA_DOC = @FECHA_DOC, CLIENTE = @CLIENTE, IMPORTE = @IMPORTE " &
            "WHERE CVE_CCP = @CVE_CCP " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCCONCI_CARTA_PORTE (CVE_CCP, CVE_DOC, FECHA_DOC, STATUS, CLIENTE, IMPORTE, FECHAELAB, UUID) " &
            "VALUES(@CVE_CCP, @CVE_DOC, @FECHA_DOC, 'A', @CLIENTE, @IMPORTE, GETDATE(), NEWID())"
            cmd.CommandText = SQL
            Try
                cmd.Parameters.Add("@CVE_CCP", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_CCP.Text)
                cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = tCVE_DOC.Text
                cmd.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = F1.Value
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = tCLIENTE.Text
                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tNETO.Text.Replace(",", ""))
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                        GRABAR_PARTIDAS_VALES()

                        MsgBox("El registro se grabo satisfactoriamente")

                        Me.Close()
                    Else
                        MsgBox("No se logro grabar el registro")
                    End If
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("NO se logro grabar la conciliación")
        End If

    End Sub
    Sub GRABAR_PARTIDAS_VALES()
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE
        'PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    
        Try
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCONCI_CARTA_PORTE_PAR WHERE CVE_CCP = " & tCVE_CCP.Text
                cmd2.CommandText = SQL
                Using dr As SqlDataReader = cmd2.ExecuteReader
                    While dr.Read
                        SQL = "UPDATE GCCARTA_PORTE SET CONCILIADO = 0 WHERE CVE_FOLIO = '" & dr("CVE_FOLIO") & "'"
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End While
                End Using
            End Using
            SQL = "DELETE FROM GCCONCI_CARTA_PORTE_PAR  WHERE CVE_CCP = " & tCVE_CCP.Text
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "INSERT INTO GCCONCI_CARTA_PORTE_PAR (CVE_CCP, CVE_FOLIO, UUID) VALUES(@CVE_CCP, @CVE_FOLIO, NEWID())"
        cmd.CommandText = SQL
        'PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    
        For k = 1 To Fg2.Rows.Count - 1
            Try
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_CCP", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_CCP.Text)
                cmd.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = Fg2(k, 1)
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCCARTA_PORTE SET CONCILIADO = 1 WHERE CVE_FOLIO = '" & Fg2(k, 1) & "'"
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    End If
                End If
            Catch ex As Exception
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
        'PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    PARTIDAS    
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim SUBTOTAL As Single
        Dim IVA As Single
        Dim NETO As Single
        Dim RETENCION As Single
        Dim CADENA As String
        Dim CVE_FOLIO As String
        Dim Exist As Boolean

        Dim NoCliente As Boolean
        Dim z As Integer

        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg2.Styles.Add("NewStyle1")
        NewStyle1.WordWrap = True
        CADENA = ""

        Try
            Dim r As Row
            z = 0
            NoCliente = False
            For Each r In Fg.Rows.Selected

                CVE_FOLIO = Fg(r.Index, 1)
                Exist = False
                For k = 1 To Fg2.Rows.Count - 1
                    If Fg2(k, 1) = CVE_FOLIO Then
                        Exist = True
                        Exit For
                    End If
                Next

                If Exist Then
                    CADENA = CADENA & CVE_FOLIO & vbNewLine
                Else
                    Exist = False
                    If Fg2.Rows.Count = 1 Or tCLIENTE.Text.Trim.Length = 0 Then
                        tCLIENTE.Text = Fg(Fg.Row, 3)
                        LtNombre.Text = Fg(Fg.Row, 4)
                        Exist = True
                    Else
                        For k = 1 To Fg2.Rows.Count - 1
                            If Fg(r.Index, 1) = tCLIENTE.Text Then
                                Exist = True
                                Exit For
                            End If
                        Next

                    End If
                    If Exist Then
                        Fg2.AddItem("" & vbTab & Fg(r.Index, 1) & vbTab & Fg(r.Index, 2) & vbTab & Fg(r.Index, 3) & vbTab & Fg(r.Index, 4) & vbTab &
                                                        Fg(r.Index, 5) & vbTab & Fg(r.Index, 6) & vbTab & Fg(r.Index, 7) & vbTab & Fg(r.Index, 8) & vbTab & Fg(r.Index, 9))
                        Fg2.Rows(Fg2.Rows.Count - 1).Style = NewStyle1
                        Fg2.AutoSizeRows()

                        Fg.RemoveItem(r.Index)
                        z = z + 1
                    Else
                        CADENA = CADENA & CVE_FOLIO & " es diferente el cliente" & vbNewLine
                    End If
                End If
            Next
            If z > 0 Then
                SUBTOTAL = 0 : IVA = 0 : RETENCION = 0 : NETO = 0
                For k = 1 To Fg2.Rows.Count - 1
                    SUBTOTAL = SUBTOTAL + Fg2(k, 6)
                    IVA = IVA + Fg2(k, 7)
                    RETENCION = RETENCION + Fg2(k, 8)
                    NETO = NETO + Fg2(k, 9)
                Next
                tSUBTOTAL.Text = Format(SUBTOTAL, "###,###,##0.00")
                tIVA.Text = Format(IVA, "###,###,##0.00")
                tRETENCION.Text = Format(RETENCION, "###,###,##0.00")
                tNETO.Text = Format(NETO, "###,###,##0.00")
                tCLIENTE.Enabled = False

            Else
                If CADENA.Trim.Length > 0 Then
                    MsgBox("El folio " & vbNewLine & CADENA & "ó ya se encuentran asignados verifique por favor")
                Else
                    MsgBox("Por favor seleccione al menos una carta porte a agregar")
                End If
            End If


        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return
        Try
            If Fg.Row > 0 Then
            Else
                MsgBox("Por favor seleccione una carta porte")
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Dim SUBTOTAL As Single
        Dim IVA As Single
        Dim NETO As Single
        Dim RETENCION As Single
        Dim z As Integer

        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg2.Styles.Add("NewStyle1")
        NewStyle1.WordWrap = True

        Fg.Cols(1).AllowSorting = True
        Fg.Styles.Fixed.BackColor = Color.LightGreen
        Fg.Cols(1).StyleNew.BackColor = Color.LightBlue

        Try
            Dim r As Row
            z = 0
            For Each r In Fg2.Rows.Selected
                Fg.AddItem("" & vbTab & Fg2(r.Index, 1) & vbTab & Fg2(r.Index, 2) & vbTab & Fg2(r.Index, 3) & vbTab & Fg2(r.Index, 4) & vbTab &
                           Fg2(r.Index, 5) & vbTab & Fg2(r.Index, 6) & vbTab & Fg2(r.Index, 7) & vbTab & Fg2(r.Index, 8) & vbTab & Fg2(r.Index, 9))
                Fg2.RemoveItem(r.Index)

                Fg.Rows(Fg.Rows.Count - 1).Style = NewStyle1
                Fg.AutoSizeRows()
                z = z + 1
            Next
            If z > 0 Then
                SUBTOTAL = 0 : IVA = 0 : NETO = 0
                For k = 1 To Fg2.Rows.Count - 1
                    SUBTOTAL = SUBTOTAL + Fg2(Fg2.Row, 6)
                    IVA = IVA + Fg2(Fg2.Row, 7)
                    RETENCION = RETENCION + Fg2(Fg2.Row, 8)
                    NETO = NETO + Fg2(Fg2.Row, 9)
                Next
                SUBTOTAL = Math.Round(SUBTOTAL, 2)
                IVA = Math.Round(IVA, 2)
                RETENCION = Math.Round(RETENCION, 2)
                NETO = Math.Round(NETO, 2)

                tSUBTOTAL.Text = Format(SUBTOTAL, "###,###,##0.00")
                tIVA.Text = Format(IVA, "###,###,##0.00")
                tRETENCION.Text = Format(RETENCION, "###,###,##0.00")
                tNETO.Text = Format(NETO, "###,###,##0.00")

                If Fg2.Rows.Count = 1 Then
                    tCLIENTE.Enabled = True
                    btnCliente.Enabled = True
                End If
                Fg.Refresh()

                Fg.Sort(SortFlags.UseColSort, 1, 2)

            Else
                MsgBox("Por favor seleccione al menos una carta porte a regresar")
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmConciCartaPorteAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select

    End Sub

    Private Sub frmConciCartaPorteAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCLIENTE.Text = Var4
                LtNombre.Text = Var5
                DESPLEGAR(Var4)
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLIENTE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnCliente_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tCLIENTE_Validated(sender As Object, e As EventArgs) Handles tCLIENTE.Validated
        Try
            Dim DESCR As String
            If tCLIENTE.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Cliente", tCLIENTE.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtNombre.Text = DESCR
                    DESPLEGAR(tCLIENTE.Text)
                Else
                    MsgBox("Cliente inexistente")
                    tCLIENTE.Text = ""
                    LtNombre.Text = ""
                End If
            Else
                tCLIENTE.Text = ""
                LtNombre.Text = ""
                DESPLEGAR("")
            End If
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmConciCartaPorteAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barReactivar_Click(sender As Object, e As EventArgs)
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea reactivar la carta porte " & Fg(Fg.Row, 1) & "?", vbYesNo) = vbYes Then
                    If MsgBox("Este proceso eliminará la carta porte de la conciliacion si fue conciliada, Desea contuar?", vbYesNo) = vbYes Then
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCCARTA_PORTE SET ST_CARTA_PORTE = 4, CONCILIADO = 0 WHERE CVE_FOLIO = '" & Fg(Fg.Row, 1) & "'"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        SQL = "DELETE FROM GCCONCI_CARTA_PORTE_PAR WHERE CVE_FOLIO = '" & Fg(Fg.Row, 1) & "'"
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using

                                    MsgBox("La carta porte se reactivó satisfactoriamente")
                                    Fg.RemoveItem(Fg.Row)
                                Else
                                    MsgBox("NO se logro reactivar la carta porte")
                                End If
                            End If
                        End Using
                    End If

                End If
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barActualizar_Click(sender As Object, e As EventArgs) Handles barActualizar.Click
        Try
            If Not tCLIENTE.Enabled Then
                tCLIENTE.Text = ""
                LtNombre.Text = ""
            End If

            DESPLEGAR("")
        Catch ex As Exception
            Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("210. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barGrabarCxC_Click(sender As Object, e As EventArgs)
        Try
            Var10 = " AND M.CVE_CLIE = '" & tCLIENTE.Text & "'"
            Var11 = LtNombre.Text

            If IsNumeric(tNETO.Text.Replace(",", "")) Then
                Var21 = tNETO.Text.Replace(",", "")
            Else
                Var21 = 0
            End If

            FrmApliPagoConciCartaPorte.Show()

        Catch ex As Exception
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmConciCartaPorteAE_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Me.Text = e.X & " " & e.Y
    End Sub

    Private Sub Split1_MouseMove(sender As Object, e As MouseEventArgs) Handles Split1.MouseMove
        Me.Text = e.X & " " & e.Y
    End Sub

    Private Sub SplitMain_Resize(sender As Object, e As EventArgs) Handles SplitMain.Resize

        btnAgregar.Left = Fg2.Left + 200
        btnRegresar.Left = btnAgregar.Left + 600
    End Sub
End Class
