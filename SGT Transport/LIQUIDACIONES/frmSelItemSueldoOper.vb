Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class frmSelItemSueldoOper
    Private Sub frmSelItemSueldoOper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SQL = "SELECT S.CVE_SUOP, ISNULL(C.NOMBRE,'') AS ORIGEN, ISNULL(P1.CIUDAD,'') AS PLAZA1, ISNULL(P2.CIUDAD,'') AS PLAZA2, 
                CASE WHEN TIPO_FULL_SENCILLO = 0 THEN 'Full' ELSE 'Sencillo' END AS TIPO1, 
                CASE WHEN TIPO_CARGADO_VACIO = 0 THEN 'Cargado' ELSE 'Vacio' END AS TIPO2, 
                ISNULL(" & IIf(Var9 = "Full", "SUELDO", "SUELDO_SENC") & ",0) AS SUELD
                FROM GCSUELDO_OPER S 
                LEFT JOIN GCCLIE_OP C ON C.CLAVE = S.CLAVE_O
                LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = S.PLAZA_O
                LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = S.PLAZA_D
                WHERE S.STATUS = 'A' ORDER BY CVE_SUOP"
            'Fg.Cols.Count = 8
            Fg(0, 1) = "Clave"
            Fg(0, 2) = "Cliente"
            Fg(0, 3) = "Origen"
            Fg(0, 4) = "Destino"
            Fg(0, 5) = "Full/Sencillo"
            Fg(0, 6) = "Cargado/Vacio"
            Fg(0, 7) = "Sueldo"
            Fg.Rows(0).Height = 50

            DESPLEGAR()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try

        Me.CenterToScreen()

    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Rows.Count = 1
            Fg.Redraw = False
            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr(0) & vbTab & dr(1) & vbTab & dr(2) & vbTab & dr(3) & vbTab & dr(4) & vbTab &
                                   dr(5) & vbTab & dr(6))
                    End While
                End Using
            End Using
            Fg.AutoSizeCols()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub frmSelItemSueldoOper_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                Var5 = Fg(Fg.Row, 2).ToString   'CIENTE
                Var6 = Fg(Fg.Row, 3).ToString   'ORIGEN
                Var7 = Fg(Fg.Row, 4).ToString   'DESTINO
                Var8 = Fg(Fg.Row, 7).ToString   'SUELDO

                Me.Close
            End If
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barRefresh_Click(sender As Object, e As EventArgs) Handles barRefresh.Click
        Try
            tCLIENTE.Text = ""
            tCVE_PLAZA.Text = ""
            tCVE_PLAZA2.Text = ""
            LtNombre.Text = ""
            LtPlaza.Text = ""
            LtPlaza2.Text = ""

            SQL = "SELECT S.CVE_SUOP, ISNULL(C.NOMBRE,'') AS ORIGEN, ISNULL(P1.CIUDAD,'') AS PLAZA1, ISNULL(P2.CIUDAD,'') AS PLAZA2, 
                CASE WHEN TIPO_FULL_SENCILLO = 0 THEN 'Full' ELSE 'Sencillo' END AS TIPO1, 
                CASE WHEN TIPO_CARGADO_VACIO = 0 THEN 'Cargado' ELSE 'Vacio' END AS TIPO2, 
                ISNULL(" & IIf(Var9 = "Full", "SUELDO", "SUELDO_SENC") & ",0) AS SUELD
                FROM GCSUELDO_OPER S 
                LEFT JOIN GCCLIE_OP C ON C.CLAVE = S.CLAVE_O
                LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = S.PLAZA_O
                LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = S.PLAZA_D
                WHERE S.STATUS = 'A' ORDER BY CVE_SUOP"

            DESPLEGAR()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click

    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        barAceptar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnCLIENTE_Click(sender As Object, e As EventArgs) Handles btnCLIENTE.Click
        Try
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                tCLIENTE.Text = Var4
                DESPLEGAR_CLIENTE_OPER(Var4)
                LtNombre.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""

            End If
        Catch ex As Exception
            Bitacora("98. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("98. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnCLIENTE_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCLIENTE_Validated(sender As Object, e As EventArgs) Handles tCLIENTE.Validated
        Try
            If tCLIENTE.Text.Trim.Length > 0 Then
                DESPLEGAR_CLIENTE_OPER(tCLIENTE.Text)
                tCVE_PLAZA.Select()
            Else
                LtPlaza.Text = ""
            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_CLIENTE_OPER(fCVE_OPER As String)
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCLIE_OP WHERE CLAVE = '" & fCVE_OPER & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        tCLIENTE.Text = dr("CLAVE").ToString
                        LtNombre.Text = dr("NOMBRE").ToString
                    Else
                        tCLIENTE.Text = ""
                        LtNombre.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnPlaza1_Click(sender As Object, e As EventArgs) Handles btnPlaza1.Click
        Try
            Var2 = "Plazas" 'GCPLAZAS
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PLAZA.Text = Var4
                LtPlaza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_PLAZA.Select()
            Else
                LtPlaza.Text = ""
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PLAZA_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza1_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_PLAZA_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA.Validated
        Try
            If tCVE_PLAZA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA.Text)
                If DESCR <> "" Then
                    LtPlaza.Text = DESCR
                    tCVE_PLAZA2.Select()
                Else
                    MessageBox.Show("Plaza inexistente")
                    tCVE_PLAZA.Focus()
                    tCVE_PLAZA.Text = ""
                    LtPlaza.Text = ""
                End If
            Else
                LtPlaza.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnPlaza2_Click(sender As Object, e As EventArgs) Handles btnPlaza2.Click
        Try
            Var2 = "Plazas" 'GCPLAZAS
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PLAZA2.Text = Var4
                LtPlaza2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PLAZA2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_PLAZA2_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA2.Validated
        Try
            If tCVE_PLAZA2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA2.Text)
                If DESCR <> "" Then
                    LtPlaza2.Text = DESCR
                Else
                    MessageBox.Show("Plaza inexistente")
                    tCVE_PLAZA2.Focus()
                    tCVE_PLAZA2.Text = ""
                    LtPlaza2.Text = ""
                End If
            Else
                LtPlaza2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        Try
            Dim CADENA As String = ""

            If tCLIENTE.Text.Trim.Length > 0 Then
                CADENA = " AND CLAVE_O = '" & tCLIENTE.Text & "'"
            End If
            If tCVE_PLAZA.Text.Trim.Length > 0 Then
                CADENA = " AND PLAZA_O = '" & tCVE_PLAZA.Text & "'"
            End If
            If tCVE_PLAZA2.Text.Trim.Length > 0 Then
                CADENA = " AND PLAZA_D = '" & tCVE_PLAZA2.Text & "'"
            End If

            SQL = "SELECT S.CVE_SUOP, ISNULL(C.NOMBRE,'') AS ORIGEN, ISNULL(P1.CIUDAD,'') AS PLAZA1, ISNULL(P2.CIUDAD,'') AS PLAZA2, 
            CASE WHEN TIPO_FULL_SENCILLO = 0 THEN 'Full' ELSE 'Sencillo' END AS TIPO1, 
            CASE WHEN TIPO_CARGADO_VACIO = 0 THEN 'Cargado' ELSE 'Vacio' END AS TIPO2, S.SUELDO 
            FROM GCSUELDO_OPER S 
            LEFT JOIN GCCLIE_OP C ON C.CLAVE = S.CLAVE_O
            LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = S.PLAZA_O
            LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = S.PLAZA_D
            WHERE S.STATUS = 'A' " & CADENA & " ORDER BY CVE_SUOP"
            DESPLEGAR()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
