Imports C1.Win.C1List


Imports System.Data.SqlClient

Public Class frmCreaInsertSQL
    Dim tabla As String

    Private Sub frmCreaInsertSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            cboEmpresa1.Items.Clear()

            For k = 1 To 99
                cboEmpresa1.Items.Add(Format(k, "00"))
                cboEmpresa2.Items.Add(Format(k, "00"))
            Next
        Catch ex As Exception

        End Try
        Try
            Me.WindowState = FormWindowState.Maximized
            FgT.Height = Me.Height - 140
            tBox.Height = Me.Height - 140
            tBox.Width = Screen.PrimaryScreen.Bounds.Width - FgT.Width - Fg.Width - 150
            Fg.Height = Me.Height - 140


            DESPLEGAR("")

        Catch ex As Exception
            MsgBox("1.2. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1.2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            'C1DisplayColumnCollection cols = this.c1List1.Splits[0].DisplayColumns;
            'Dim cols As C1DisplayColumnCollection = C1List1.Splits(0).DisplayColumns
            'cols(0).Width = 200
            'cols(1).Width = 200

        Catch ex As Exception
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.WindowState = FormWindowState.Maximized


    End Sub

    Sub DESPLEGAR(fSQLGC As String)

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            cmd.Connection = cnSAE

            If fSQLGC.Trim.Length = 0 Then
                SQL = "SELECT * FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME"
            Else
                SQL = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE SUBSTRING(TABLE_NAME,1,2) = 'GC' ORDER BY TABLE_NAME"
            End If

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            FgT.Rows.Count = 1

            Do While dr.Read
                FgT.AddItem("" & vbTab & dr("TABLE_NAME"))
            Loop
            dr.Close()

        Catch ex As Exception
            msgbox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click


        Try
            Dim ExistTab As Boolean

            ExistTab = False
            For k = 0 To MainRibbonForm.Tab1.TabPages.Count - 1
                If MainRibbonForm.Tab1.TabPages(k).Text = "Crea Insert data" Then
                    ExistTab = True
                    MainRibbonForm.Tab1.TabPages.RemoveAt(k)
                    Exit For
                End If
            Next

            Me.Close()
        Catch ex As Exception
            msgbox("4. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("4. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barCreateCode_Click(sender As Object, e As EventArgs) Handles barCreateCode.Click
        Dim Campo As String
        Dim Tipo As String
        Dim Lng As Long
        Dim z1 As Integer
        Dim z2 As Integer
        Dim z3 As Integer
        Dim CLAVE As String


        Dim CADENA_DIM As String
        Dim CADENA1 As String
        Dim CADENA2 As String
        Dim CADENA3 As String
        Dim CADENA4 As String

        Dim CADENA3_PARAM As String
        Dim CADENA_CAMPO As String
        Dim CADENA_CAMPO2 As String
        Dim CADENA_BOX As String
        Dim CADENA_MAXLENGHT As String


        Try
            CADENA1 = ""
            CADENA2 = ""
            CADENA3 = ""
            CADENA3_PARAM = ""
            CADENA_DIM = ""
            Tipo = ""
            CADENA_CAMPO = ""
            CADENA_CAMPO2 = ""
            CADENA4 = ""
            Campo = ""
            CLAVE = ""
            CADENA_BOX = ""

            Try
                CADENA2 = vbNewLine
                CADENA2 = CADENA2 & "Dim cmd As New SqlCommand" & vbNewLine
                CADENA2 = CADENA2 & "cmd.Connection = cnSAE" & vbNewLine & vbNewLine

                Try

                    For k = 1 To Fg.Rows.Count - 1

                        If Fg(k, 1) = "True" Then
                            Campo = Fg(k, 2)
                            Tipo = Fg(k, 3)

                            If Campo.IndexOf("CVE") = -1 And Campo.ToUpper <> "STATUS" Then
                                CADENA2 = CADENA2 & "If " & Campo & ".Text.Trim.Length = 0 Then" & vbNewLine
                                CADENA2 = CADENA2 & "   MsgBox(" & """La descripción no debe quedar vacia, verifique por favor" & """)" & vbNewLine
                                CADENA2 = CADENA2 & "   Return" & vbNewLine
                                CADENA2 = CADENA2 & "End If" & vbNewLine & vbNewLine
                            End If
                        End If
                    Next

                Catch Ex As Exception
                    Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
                End Try

                CADENA2 = CADENA2 & "SQL = ""UPDATE " & tabla & " SET "
                CADENA_CAMPO = CADENA_CAMPO & """INSERT INTO " & tabla & " ("

            Catch ex As Exception
                msgbox("5. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("5. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            CADENA_MAXLENGHT = ""
            CADENA3 = " VALUES("
            z1 = 0 : z2 = 0 : z3 = 0
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) = "True" Then
                    Try
                        Campo = Fg(k, 2)
                        Tipo = Fg(k, 3)
                        If IsNumeric(Fg(k, 4)) Then
                            Lng = Fg(k, 4)
                        Else
                            Lng = 0
                        End If

                        If Campo.IndexOf("CVE") > -1 Then
                            CLAVE = Campo
                        End If
                        CADENA1 = CADENA1 & Campo & ", "
                        CADENA2 = CADENA2 & Campo & " = " & "@" & Campo & ", "
                        CADENA3 = CADENA3 & "@" & Campo & ", "


                        z1 = z1 + 1
                        z2 = z2 + 1
                        z3 = z3 + 1
                        If z1 = 6 Then
                            z1 = 1 : CADENA2 = CADENA2 & """" & " & " & vbNewLine : CADENA2 = CADENA2 & """"
                        End If
                        If z2 = 12 Then z2 = 1 : CADENA3 = CADENA3 & """" & " &" & vbNewLine : CADENA3 = CADENA3 & """"
                        If z3 = 12 Then z3 = 1 : CADENA_CAMPO = CADENA_CAMPO & """" & " &" & vbNewLine : CADENA_CAMPO = CADENA_CAMPO & """"

                    Catch ex As Exception
                        msgbox("6. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("6. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        Select Case Tipo.ToUpper
                            Case "VARCHAR"
                                CADENA_DIM = CADENA_DIM & "DIM t" & Campo & " AS STRING" & vbNewLine
                                CADENA_MAXLENGHT = CADENA_MAXLENGHT & "t" & Campo & ".MaxLength = " & Fg(k, 4) & vbNewLine
                            Case "INT"
                                CADENA_DIM = CADENA_DIM & "DIM t" & Campo & " AS integer" & vbNewLine
                            Case "FLOAT"
                                CADENA_DIM = CADENA_DIM & "DIM t" & Campo & " AS single" & vbNewLine
                            Case "SMALLINT"
                                CADENA_DIM = CADENA_DIM & "DIM t" & Campo & " AS integer" & vbNewLine
                            Case "DATE"
                                CADENA_DIM = CADENA_DIM & "DIM t" & Campo & " AS string" & vbNewLine
                            Case "DATETIME"
                                CADENA_DIM = CADENA_DIM & "DIM t" & Campo & " AS string" & vbNewLine
                            Case "LONG"
                                CADENA_DIM = CADENA_DIM & "DIM t" & Campo & " AS long" & vbNewLine
                            Case "BIT"
                            Case "DECIMAL"
                            Case "SMALLMONEY"
                            Case "TINYINT"
                            Case Else
                                CADENA_MAXLENGHT = CADENA_MAXLENGHT & "t" & Campo & ".MaxLength = " & Fg(k, 4) & vbNewLine
                        End Select

                        CADENA_CAMPO = CADENA_CAMPO & Campo & ", "

                    Catch ex As Exception
                        msgbox("7. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("7. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next

            CADENA_CAMPO = CADENA_CAMPO.Substring(0, CADENA_CAMPO.Length - 2) & ")"
            CADENA3 = CADENA3.Substring(0, CADENA3.Length - 2) & ")""" '& " &"
            CADENA2 = CADENA2.Substring(0, CADENA2.Length - 2) & """" & " & " & vbNewLine & """ WHERE " & CLAVE & " = @" & CLAVE & " "" & " & vbNewLine
            CADENA2 = CADENA2 & """IF @@ROWCOUNT = 0 " & """ & " & vbNewLine

            CADENA_CAMPO = CADENA2 & CADENA_CAMPO & """" & " &" & vbNewLine & """" & CADENA3 & vbNewLine & vbNewLine

            CADENA_CAMPO = CADENA_CAMPO & "      cmd.commandtext = SQL" & vbNewLine & vbNewLine

            CADENA_CAMPO = CADENA_CAMPO & "        Dim STATUS As String" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "        If  Then" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "            STATUS = " & """A""" & vbNewLine & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "        Else" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "            If  Then" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                STATUS = " & """A""" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "            Else" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                STATUS = " & """I""" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "            End If" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "        End If" & vbNewLine & vbNewLine

            CADENA_CAMPO = CADENA_CAMPO & "         try" & vbNewLine

            For k = 1 To Fg.Rows.Count - 1
                CADENA1 = Fg(k, 1)

                If Fg(k, 1) = "True" Then
                    Campo = Fg(k, 2)
                    Tipo = Fg(k, 3)
                    If IsNumeric(Fg(k, 4)) Then
                        Lng = Fg(k, 4)
                    Else
                        Lng = 0
                    End If
                    Select Case Tipo.ToUpper
                        Case "VARCHAR"
                            If Campo.ToUpper = "STATUS" Then
                                CADENA_CAMPO = CADENA_CAMPO & "                 cmd.Parameters.Add(""@" & Campo & """, SqlDbType.VarChar).Value = " & Campo & vbNewLine
                            Else
                                CADENA_CAMPO = CADENA_CAMPO & "                 cmd.Parameters.Add(""@" & Campo & """, SqlDbType.VarChar).Value = t" & Campo & ".text" & vbNewLine
                            End If
                        Case "INT"
                            CADENA_CAMPO = CADENA_CAMPO & "                 cmd.Parameters.Add(""@" & Campo & """, SqlDbType.Int).Value = CONVERTIR_TO_INT(t" & Campo & ".text)" & vbNewLine
                        Case "FLOAT"
                            CADENA_CAMPO = CADENA_CAMPO & "                 cmd.Parameters.Add(""@" & Campo & """, SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(t" & Campo & ".text)" & vbNewLine
                        Case "SMALLINT"
                            CADENA_CAMPO = CADENA_CAMPO & "                 cmd.Parameters.Add(""@" & Campo & """, SqlDbType.SmallInt ).Value = CONVERTIR_TO_INT(t" & Campo & ".text)" & vbNewLine
                        Case "DATE"
                            CADENA_CAMPO = CADENA_CAMPO & "                 cmd.Parameters.Add(""@" & Campo & """, SqlDbType.Date ).Value = t" & Campo & ".text" & vbNewLine
                        Case "DATETIME"
                            CADENA_CAMPO = CADENA_CAMPO & "                 cmd.Parameters.Add(""@" & Campo & """, SqlDbType.DateTime ).Value = t" & Campo & ".text" & vbNewLine
                        Case "LONG"
                            CADENA_CAMPO = CADENA_CAMPO & "                 cmd.Parameters.Add(""@" & Campo & """, SqlDbType.int).Value = CONVERTIR_TO_INT(t" & Campo & ".text)" & vbNewLine
                    End Select
                End If
            Next

            CADENA_CAMPO = CADENA_CAMPO & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "             returnValue = cmd.ExecuteNonQuery().ToString" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "             If returnValue IsNot Nothing Then" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                 If returnValue = """ & "1" & """" & " Then " & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                     MsgBox(" & """El registro se grabo satisfactoriamente" & """)" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                     me.close" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                 else" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                     MsgBox(" & """No se logro grabar el registro" & """)" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                 End If" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "             else" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                 MsgBox(" & """No se logro grabar el registro" & """)" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "             End If" & vbNewLine

            CADENA_CAMPO = CADENA_CAMPO & "         Catch ex As Exception" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "              msgbox(""" & "10. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "              Bitacora(""" & "10. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "         End Try" & vbNewLine

            CADENA_CAMPO = CADENA_CAMPO & "'==========================================================================" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "'========== FIN PARAMETROS =============== FIN PARAMETROS =================" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "'==========================================================================" & vbNewLine

            CADENA_CAMPO = CADENA_CAMPO & "       Try" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "            If MsgBox(" & """Realmente desea eliminar el registro?" & """, vbYesNo) = vbYes Then" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                SQL = " & """UPDATE " & tabla & " SET STATUS = 'B' WHERE " & CLAVE & " = '" & """ & Fg(Fg.Row, 1) & " & """'""" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                Dim cmd As New SqlCommand" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                cmd.Connection = cnSAE" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                cmd.CommandText = SQL" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                returnValue = cmd.ExecuteNonQuery().ToString" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                If returnValue IsNot Nothing Then" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                    If returnValue = """ & "1" & """" & " Then" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                        MsgBox(" & """" & "El registro se elimino satisfactoriamente" & """" & ")" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                        DESPLEGAR()" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                    Else" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                        MsgBox(" & """" & "NO se logro eliminar el registro" & """" & ")" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                    End If" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                Else" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                    MsgBox(" & """" & "!!NO se logro eliminar el registro!!" & """" & ")" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "                End If" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "            End If" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "       Catch ex As Exception" & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "              msgbox(""" & "12. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "              Bitacora(""" & "12. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA_CAMPO = CADENA_CAMPO & "       End Try" & vbNewLine

            Clipboard.Clear()
            Clipboard.SetDataObject(CADENA_DIM & vbNewLine & CADENA_CAMPO)

            SaveTextToFile(CADENA_DIM & vbNewLine & CADENA_MAXLENGHT & vbNewLine & CADENA_CAMPO, Application.StartupPath & "\Q2.TXT")

            tBox.Text = CADENA_DIM & vbNewLine & CADENA_CAMPO

        Catch ex As Exception
            msgbox("8. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click

    End Sub

    Private Sub barCreateCodeGC_Click(sender As Object, e As EventArgs) Handles barCreateCodeGC.Click


        DESPLEGAR("S")

    End Sub

    Private Sub barCodeInicio_Click(sender As Object, e As EventArgs) Handles barCodeInicio.Click
        Dim CADENA_DIM As String
        Dim CADENA1 As String
        Dim CADENA_CAMPO As String
        Dim CADENA_ASIG As String
        Dim CLAVE As String
        Dim CADENA_SELECT As String
        Dim AliaSel As String

        Dim Fg1 As String
        Dim Fg2 As String
        Dim Fg3 As String

        Dim Campo As String
        Dim Tipo As String
        Dim CADENA_BOX As String
        Dim CADENA_BOX2 As String
        Dim CADENA_BOX3 As String
        Dim j As Integer


        Try

            Fg1 = ""
            Fg1 = Fg1 & "       Me.WindowState = FormWindowState.Maximized" & vbNewLine
            Fg1 = Fg1 & "       C1SuperTooltip1.SetToolTip(barNuevo, " & """F2 - Nuevo" & """" & ")" & vbNewLine
            Fg1 = Fg1 & "       C1SuperTooltip1.SetToolTip(barEdit, " & """F3 - Edit" & """" & ")" & vbNewLine
            Fg1 = Fg1 & "       C1SuperTooltip1.SetToolTip(barEliminar, " & """F4 - Eliminar" & """" & ")" & vbNewLine
            Fg1 = Fg1 & "       C1SuperTooltip1.SetToolTip(barSalir, " & """F5 - Salir" & """" & ")" & vbNewLine & vbNewLine
            Fg1 = Fg1 & "       Me.WindowState = FormWindowState.Maximized" & vbNewLine & vbNewLine
            Fg1 = Fg1 & "       me.KeyPreview = true" & vbNewLine

            Fg1 = Fg1 & "       Fg.rows.count = 1" & vbNewLine
            Fg1 = Fg1 & "       Fg.cols.count = " & Fg.Rows.Count & vbNewLine
            Fg1 = Fg1 & "" & vbNewLine
            Fg1 = Fg1 & "       Fg.Rows(0).Height = 40" & vbNewLine
            Fg1 = Fg1 & "       Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25" & vbNewLine
            Fg1 = Fg1 & "       Fg.Height = Me.Height - 150" & vbNewLine & vbNewLine

            CADENA_DIM = ""
            CADENA_ASIG = ""
            CADENA_CAMPO = ""
            CADENA_BOX = ""
            CADENA_BOX2 = ""
            CADENA_BOX3 = ""
            Fg2 = ""
            CLAVE = ""
            Campo = ""
            For k = 1 To Fg.Rows.Count - 1
                Campo = Fg(k, 2)
                If Fg(k, 1) = "True" Then
                    If Campo.IndexOf("CVE") > -1 Then
                        CLAVE = Campo
                    End If
                End If
            Next

            CADENA_BOX = CADENA_BOX & "C1SuperTooltip1.SetToolTip(barGrabar, " & """F3 - Grabar" & """" & ")" & vbNewLine
            CADENA_BOX = CADENA_BOX & "C1SuperTooltip1.SetToolTip(mnuSalir, " & """F5 - Salir" & """" & ")" & vbNewLine
            CADENA_BOX = CADENA_BOX & "Me.CenterToScreen()" & vbNewLine & vbNewLine
            CADENA_BOX = CADENA_BOX & "me.KeyPreview = true" & vbNewLine
            CADENA_BOX = CADENA_BOX & "" & vbNewLine & vbNewLine

            CADENA_BOX = CADENA_BOX & "Try" & vbNewLine
            CADENA_BOX = CADENA_BOX & "     " & vbNewLine
            CADENA_BOX = CADENA_BOX & "     cboStatus.Items.Add(" & """Activo""" & ")" & vbNewLine
            CADENA_BOX = CADENA_BOX & "     cboStatus.Items.Add(" & """Inactivo""" & ")" & vbNewLine
            CADENA_BOX = CADENA_BOX & "Catch ex As Exception" & vbNewLine
            CADENA_BOX = CADENA_BOX & "End Try" & vbNewLine & vbNewLine

            CADENA_BOX = CADENA_BOX & "If Var1 = """ & "Nuevo" & """" & " Then" & vbNewLine & vbNewLine
            CADENA_BOX = CADENA_BOX & "     Try" & vbNewLine & vbNewLine
            CADENA_BOX = CADENA_BOX & "         " & vbNewLine
            CADENA_BOX = CADENA_BOX & "         tClave.Text = GET_MAX(""" & tabla & """, """ & CLAVE & """)" & vbNewLine
            CADENA_BOX = CADENA_BOX & "         tClave.Enabled = False" & vbNewLine
            CADENA_BOX = CADENA_BOX & "         tDescr.Text = """"" & vbNewLine
            CADENA_BOX = CADENA_BOX & "         tDescr.Select()" & vbNewLine & vbNewLine

            CADENA_BOX = CADENA_BOX & "      Catch ex As Exception" & vbNewLine
            CADENA_BOX = CADENA_BOX & "           msgbox(""" & "2. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA_BOX = CADENA_BOX & "           Bitacora(""" & "2. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA_BOX = CADENA_BOX & "      End Try" & vbNewLine
            CADENA_BOX = CADENA_BOX & " else" & vbNewLine
            CADENA_BOX = CADENA_BOX & "     try" & vbNewLine & vbNewLine

            CADENA_BOX = CADENA_BOX & "         dim cmd as new sqlcommand" & vbNewLine
            CADENA_BOX = CADENA_BOX & "         dim dr as sqldatareader " & vbNewLine
            CADENA_BOX = CADENA_BOX & "         cmd.connection = cnSAE" & vbNewLine & vbNewLine

            j = 1
            Fg3 = "     fg.additem(" & """" & """" & " & vbtab & "
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) = "True" Then
                    Campo = Fg(k, 2)
                    Tipo = Fg(k, 3)

                    If Campo.IndexOf("CVE") > -1 Then
                        CLAVE = Campo
                    End If
                    If Campo.ToUpper = "STATUS" Then
                        'CADENA_BOX2 = CADENA_BOX2 & "          t" & Campo & ".text = dr(" & """" & Campo & """" & ")" & vbNewLine
                        CADENA_BOX2 = CADENA_BOX2 & "          If dr(" & """STATUS""" & ") = " & """A""" & " Then" & vbNewLine
                        CADENA_BOX2 = CADENA_BOX2 & "             " & vbNewLine
                        CADENA_BOX2 = CADENA_BOX2 & "          Else" & vbNewLine
                        CADENA_BOX2 = CADENA_BOX2 & "             cboStatus.SelectedIndex = 1" & vbNewLine
                        CADENA_BOX2 = CADENA_BOX2 & "          End If" & vbNewLine

                        CADENA_BOX3 = CADENA_BOX3 & "          " & vbNewLine
                    Else
                        CADENA_BOX2 = CADENA_BOX2 & "          t" & Campo & ".text = dr(" & """" & Campo & """" & ").tostring" & vbNewLine
                        'CADENA_BOX3 = CADENA_BOX3 & "          t" & Campo & ".text = """"" & vbNewLine
                    End If


                    Fg1 = Fg1 & "       fg(0," & j & ") = " & """" & Campo & """" & vbNewLine
                    Fg2 = Fg2 & "       Fg.Cols(" & j & ").AllowEditing = false" & vbNewLine

                    Fg3 = Fg3 & "dr(" & """" & Campo & """" & ") & vbtab & "
                    CADENA_ASIG = CADENA_ASIG & "       t" & Campo & ".text = dr(""" & Campo & """)" & vbNewLine & vbTab

                    Try
                        Select Case Tipo.ToUpper
                            Case "VARCHAR"
                                CADENA_DIM = CADENA_DIM & "DIM " & Campo & " AS STRING" & vbNewLine
                                Fg1 = Fg1 & "       Dim c" & j & " As Column = Fg.Cols(" & j & ")" & vbNewLine
                                Fg1 = Fg1 & "       c" & j & ".DataType = GetType(String)" & vbNewLine & vbNewLine

                                CADENA_BOX3 = CADENA_BOX3 & "          t" & Campo & ".text = """"" & vbNewLine

                            Case "INT"
                                CADENA_DIM = CADENA_DIM & "DIM " & Campo & " AS integer" & vbNewLine
                                Fg1 = Fg1 & "       Dim c" & j & " As Column = Fg.Cols(" & j & ")" & vbNewLine
                                Fg1 = Fg1 & "       c" & j & ".DataType = GetType(int32)" & vbNewLine & vbNewLine
                                CADENA_BOX3 = CADENA_BOX3 & "          t" & Campo & ".value = 0" & vbNewLine

                            Case "FLOAT"
                                CADENA_DIM = CADENA_DIM & "DIM " & Campo & " AS single" & vbNewLine
                                Fg1 = Fg1 & "       Dim c" & j & " As Column = Fg.Cols(" & j & ")" & vbNewLine
                                Fg1 = Fg1 & "       c" & j & ".DataType = GetType(Decimal)" & vbNewLine
                                Fg1 = Fg1 & "       Fg.Cols(" & j & ").Format = """ & "###,###,##0.00" & """" & vbNewLine & vbNewLine

                                CADENA_BOX3 = CADENA_BOX3 & "          t" & Campo & ".value = 0" & vbNewLine
                            Case "SMALLINT"
                                CADENA_DIM = CADENA_DIM & "DIM " & Campo & " AS integer" & vbNewLine
                                Fg1 = Fg1 & "       Dim c" & j & " As Column = Fg.Cols(" & j & ")" & vbNewLine
                                Fg1 = Fg1 & "       c" & j & ".DataType = GetType(int16)" & vbNewLine & vbNewLine
                                CADENA_BOX3 = CADENA_BOX3 & "          t" & Campo & ".value = 0" & vbNewLine
                            Case "DATE"
                                CADENA_DIM = CADENA_DIM & "DIM " & Campo & " AS string" & vbNewLine
                                Fg1 = Fg1 & "       Dim c" & j & " As Column = Fg.Cols(" & j & ")" & vbNewLine
                                Fg1 = Fg1 & "       c" & j & ".DataType = GetType(datetime)" & vbNewLine & vbNewLine
                                CADENA_BOX3 = CADENA_BOX3 & "          t" & Campo & ".value = 0" & vbNewLine
                            Case "DATETIME"
                                CADENA_DIM = CADENA_DIM & "DIM " & Campo & " AS string" & vbNewLine
                                Fg1 = Fg1 & "       Dim c" & j & " As Column = Fg.Cols(" & j & ")" & vbNewLine
                                Fg1 = Fg1 & "       c" & j & ".DataType = GetType(datetime)" & vbNewLine & vbNewLine
                                CADENA_BOX3 = CADENA_BOX3 & "          t" & Campo & ".value = 0" & vbNewLine
                            Case "LONG"
                                CADENA_DIM = CADENA_DIM & "DIM " & Campo & " AS long" & vbNewLine
                                Fg1 = Fg1 & "       Dim c" & j & " As Column = Fg.Cols(" & j & ")" & vbNewLine
                                Fg1 = Fg1 & "       c" & j & ".DataType = GetType(int32)" & vbNewLine & vbNewLine
                                CADENA_BOX3 = CADENA_BOX3 & "          t" & Campo & ".value = 0" & vbNewLine
                        End Select
                    Catch ex As Exception
                        msgbox("7. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("7. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    j = j + 1
                End If
            Next
            Fg2 = Fg2 & vbNewLine
            Fg2 = Fg2 & "       DESPLEGAR()" & vbNewLine & vbNewLine

            CADENA1 = "try" & vbNewLine & vbNewLine
            CADENA1 = CADENA1 & Fg1 & vbNewLine & Fg2 & vbNewLine
            CADENA1 = CADENA1 & "" & vbNewLine
            CADENA1 = CADENA1 & "         Catch ex As Exception" & vbNewLine
            CADENA1 = CADENA1 & "              msgbox(""" & "13. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA1 = CADENA1 & "              Bitacora(""" & "13. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA1 = CADENA1 & "         End Try" & vbNewLine & vbNewLine

            CADENA1 = CADENA1 & "SUB DESPLEGAR" & vbNewLine & vbNewLine
            CADENA1 = CADENA1 & "try" & vbNewLine & vbNewLine

            CADENA1 = CADENA1 & "     dim cmd as new sqlcommand" & vbNewLine
            CADENA1 = CADENA1 & "     dim dr as sqldatareader " & vbNewLine
            CADENA1 = CADENA1 & "     cmd.connection = cnSAE" & vbNewLine & vbNewLine
            CADENA1 = CADENA1 & "           SQL = " & """SELECT "

            CADENA_SELECT = ""
            AliaSel = tabla.Substring(2, 1)

            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) = "True" Then
                    Campo = Fg(k, 2)
                    Try

                        CADENA1 = CADENA1 & Campo & ", "
                        CADENA_SELECT = CADENA_SELECT & AliaSel & "." & Campo & ", "

                    Catch ex As Exception
                        msgbox("7. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("7. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next

            CADENA_SELECT = CADENA_SELECT.Substring(0, CADENA_SELECT.Length - 2)

            CADENA1 = CADENA1.Substring(0, CADENA1.Length - 2)
            Fg3 = Fg3.Substring(0, Fg3.Length - 10).Trim & ")"

            CADENA1 = CADENA1 & " FROM " & tabla & """" & vbNewLine & vbNewLine
            CADENA1 = CADENA1 & "       cmd.commandtext = SQL" & vbNewLine
            CADENA1 = CADENA1 & "       dr = cmd.executereader" & vbNewLine & vbNewLine
            CADENA1 = CADENA1 & "       fg.rows.count = 1" & vbNewLine & vbNewLine
            CADENA1 = CADENA1 & "       do while dr.read" & vbNewLine
            CADENA1 = CADENA1 & "           " & Fg3 & vbNewLine
            CADENA1 = CADENA1 & "loop" & vbNewLine
            CADENA1 = CADENA1 & "       dr.close" & vbNewLine
            CADENA1 = CADENA1 & "Fg.AutoSizeCols()" & vbNewLine
            CADENA1 = CADENA1 & "" & vbNewLine
            CADENA1 = CADENA1 & "         Catch ex As Exception" & vbNewLine
            CADENA1 = CADENA1 & "              msgbox(""" & "14. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA1 = CADENA1 & "              Bitacora(""" & "14. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA1 = CADENA1 & "         End Try" & vbNewLine
            CADENA1 = CADENA1 & "END SUB" & vbNewLine


            CADENA_BOX = CADENA_BOX & "       me.KeyPreview = true" & vbNewLine & vbNewLine


            CADENA_BOX = CADENA_BOX & "       SQL = """ & "SELECT " & CADENA_SELECT & " FROM " & tabla & " " & AliaSel & " WHERE " & CLAVE & " = '""" & " & var2 & " & """'" & """" & vbNewLine
            CADENA_BOX = CADENA_BOX & "       cmd.commandtext = SQL" & vbNewLine
            CADENA_BOX = CADENA_BOX & "       dr = cmd.executereader" & vbNewLine & vbNewLine
            CADENA_BOX = CADENA_BOX & "       if dr.read then" & vbNewLine
            CADENA_BOX = CADENA_BOX & "          " & CADENA_BOX2
            CADENA_BOX = CADENA_BOX & "       else" & vbNewLine
            CADENA_BOX = CADENA_BOX & "          " & CADENA_BOX3
            CADENA_BOX = CADENA_BOX & "       end if" & vbNewLine
            CADENA_BOX = CADENA_BOX & "       dr.close" & vbNewLine & vbNewLine
            CADENA_BOX = CADENA_BOX & "       tClave.Enabled = False" & vbNewLine
            CADENA_BOX = CADENA_BOX & "       tDescr.Select()" & vbNewLine & vbNewLine
            CADENA_BOX = CADENA_BOX & "       Catch ex As Exception" & vbNewLine
            CADENA_BOX = CADENA_BOX & "              msgbox(""" & "15. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA_BOX = CADENA_BOX & "              Bitacora(""" & "15. """ & " & ex.Message & vbNewLine & """ & """" & " & ex.StackTrace) " & vbNewLine
            CADENA_BOX = CADENA_BOX & "       End Try" & vbNewLine
            CADENA_BOX = CADENA_BOX & "end if" & vbNewLine
            CADENA_BOX = CADENA_BOX & "'==========================================================================" & vbNewLine
            CADENA_BOX = CADENA_BOX & "'========== FIN FORM LOAD  =============== FIN FORM LOAD ==================" & vbNewLine
            CADENA_BOX = CADENA_BOX & "'==========================================================================" & vbNewLine

            Clipboard.Clear()
            Clipboard.SetDataObject(CADENA_DIM & vbNewLine & CADENA_BOX & vbNewLine & CADENA1)

            SaveTextToFile(CADENA_DIM & vbNewLine & CADENA_BOX & vbNewLine & CADENA1, Application.StartupPath & "\Q1.TXT")

            tBox.Text = CADENA_DIM & vbNewLine & CADENA_BOX & vbNewLine & CADENA1

        Catch ex As Exception
            msgbox("8. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgT_Click(sender As Object, e As EventArgs) Handles FgT.Click

        Try
            tabla = FgT(FgT.Row, 1)

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & tabla & "'"

            cmd.CommandText = SQL

            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1

            Do While dr.Read
                Fg.AddItem("" & vbTab & "-1" & vbTab & dr("COLUMN_NAME") & vbTab & dr("DATA_TYPE") & vbTab & dr("CHARACTER_MAXIMUM_LENGTH"))
            Loop
            dr.Close()

            Fg.AutoSizeCols()

        Catch ex As Exception
            msgbox("3. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("3. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace & vbNewLine & SQL)
        End Try

    End Sub

    Private Sub barCreateBaseGPS_Click(sender As Object, e As EventArgs) Handles barCreateBaseGPS.Click

        Fg.Rows.Insert(1)
        Fg(1, 1) = ""
        Fg(1, 2) = "Campo"
        Fg(1, 3) = "int"

        If MsgBox("Realmente desea crear la base GPS?", vbYesNo) = vbYes Then
            If CREA_BASE_GPS(Servidor_SAROCE, Usuario_SAROCE, Pass_SAROCE) Then
                MsgBox("La base se creo satisfactoriamente")
            Else
                MsgBox("No se logro CREAR la base")
            End If
        End If

    End Sub

    Private Sub frmCreaInsertSQL_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarRenombrarTablas_Click(sender As Object, e As EventArgs) Handles BarRenombrarTablas.Click

        If MsgBox("Realmente desea renombrar las tablas?", vbYesNo) = vbYes Then
            Try
                For k = 1 To FgT.Rows.Count - 1

                    If FgT(k, 1).ToString.Substring(0, 2) <> "GC" Then
                        SQL = "EXEC sp_rename '" & FgT(k, 1) & "', '" & FgT(k, 1).ToString.Replace(cboEmpresa1.Text, cboEmpresa2.Text) & "'; "
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        End Using
                    End If
                Next
                MsgBox("Proceso terminado")
            Catch ex As Exception
                MsgBox("3. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("3. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace & vbNewLine & SQL)
            End Try
        End If

    End Sub
End Class