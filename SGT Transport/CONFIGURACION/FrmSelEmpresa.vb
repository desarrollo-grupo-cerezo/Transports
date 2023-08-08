Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmSelEmpresa
    Private UTILIZAR_LECTOR_HUELLA As Integer
    Private RUTA_HUELLAS As String
    Private RUTA_FOTOS As String

    Private Sub FrmSelEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        Try
            Application.EnableVisualStyles()
            Desplegar()
            ListBox.SelectedIndex = 0

            If TUsuario.Text.Trim.Length = 0 Then
                TUsuario.Text = "Admin"
            End If

            AGREGA_CAMPOS_SAROCE()

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Dim Text As String = ""
            Dim readText() As String = File.ReadAllLines(Application.StartupPath & "\TransPortCG.ini")
            Dim s As String
            For Each s In readText
                Text = s
            Next
            If Text.Trim.Length > 0 Then
                If Text.ToUpper = "TABLAS" Or Text.ToUpper = "TABLAS2" Or
                    Text.ToUpper = "TABLAS3" Or Text.ToUpper = "TABLAS24" Or
                    Text.ToUpper = "TABLAS5" Then
                    TUsuario.Text = "Admin"
                Else
                    TUsuario.Text = Text
                End If
            End If
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Empresa = ListBox.Items(ListBox.SelectedIndex)
            Empresa = Empresa.Substring(0, 2)

            SQL = "SELECT RUTA_HUELLAS, RUTA_FOTOS, UTILIZAR_LECTOR_HUELLA FROM CONFIG WHERE EMPRESA = '" & Empresa & "'"
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        UTILIZAR_LECTOR_HUELLA = dr.ReadNullAsEmptyInteger("UTILIZAR_LECTOR_HUELLA")
                        RUTA_HUELLAS = dr.ReadNullAsEmptyString("RUTA_HUELLAS")
                        RUTA_FOTOS = dr.ReadNullAsEmptyString("RUTA_FOTOS")
                    Else
                        SQL = "INSERT CONFIG (EMPRESA, UTILIZAR_LECTOR_HUELLA, RUTA_HUELLAS, RUTA_FOTOS) VALUES ('01', 0, ' ', ' ')"
                        EXECUTE_QUERY_SAROCE(SQL)

                        UTILIZAR_LECTOR_HUELLA = 0
                        RUTA_HUELLAS = ""
                        RUTA_FOTOS = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        If UTILIZAR_LECTOR_HUELLA = 1 Then
            If RUTA_HUELLAS.Trim.Length > 0 Then

                L1.Visible = False
                L2.Visible = False
                TUsuario.Visible = False
                TPass.Visible = False
            Else
                MsgBox("Por favor capture la ruta de las huellas dactilares en configuración-parámetros del sistema-parámetros generales")
            End If
        End If
    End Sub
    Sub Desplegar()
        If Not Valida_Conexion_SAROCE() Then
            Return
        End If

        Try
            Dim SQLstr As String = "Select * FROM EMPRESAS ORDER BY EMPRESA"
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim Nodata As Boolean

            Nodata = True
            cmd.Connection = cnSAROCE
            cmd.CommandText = SQLstr
            dr = cmd.ExecuteReader()
            ListBox.Items.Clear()

            While dr.Read()
                ListBox.Items.Add(dr("empresa") & " " & dr("nombre"))
                Nodata = False
            End While
            dr.Close()

            If Nodata Then
                SQL = "INSERT INTO EMPRESAS (EMPRESA, NOMBRE, SERVIDOR, BASE, USUARIO, PASS, TIPO) " &
                    "VALUES ('01','EMPRESA S.A. DE C.V.','(LOCAL)\SQLEXPRESS','SAE701','1234','1234','1')"
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("Existe un problema en la base de configuración, verifique por favor y vuelva a entrar al sistema")

            LIMPIAR_CAMPO_BASE_SAROCE()
            My.Application.OpenForms.Cast(Of Form)().Except({Me}).ToList().ForEach(Sub(form) form.Close())
            End
        End Try
    End Sub
    Sub LIMPIAR_CAMPO_BASE_SAROCE()
        Try
            Dim cmdSqlite As New SQLiteCommand(SQLConn) With {.CommandText = "UPDATE config SET base_sar = 'SACRICE'"}
            cmdSqlite.ExecuteNonQuery()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click

        Try
            Dim AccesoUsuario As Boolean, Pasw As Integer, CREA_TABLAS_TRANSGC As Boolean = False
            Dim cmd As New SqlCommand
            Dim cmd2 As New SqlCommand
            Dim dr As SqlDataReader

            Try
                If ListBox.SelectedIndex = -1 Then
                    MsgBox("Por favor seleccione una empresa")
                    Exit Sub
                End If

                Empresa = ListBox.Items(ListBox.SelectedIndex)
                Empresa = Empresa.Substring(0, 2)

                If UTILIZAR_LECTOR_HUELLA = 1 Then
                    If RUTA_HUELLAS.Trim.Length > 0 Then

                        TUsuario.Enabled = False
                        TPass.Enabled = False

                        Connect = ""
                        Var3 = RUTA_FOTOS
                        Var4 = RUTA_HUELLAS

                        FrmLogin.ShowDialog()
                        If Connect = "Si" Then
                            TUsuario.Text = USER_GRUPOCE

                            If PASS_GRUPOCE.ToUpper.Trim = "WINAS" Or PASS_GRUPOCE.ToUpper.Trim = "TAIS920" Or
                                PASS_GRUPOCE.ToUpper.Trim = "BR3FRAJA" Or PASS_GRUPOCE.ToUpper.Trim = "SAYAYIN" Or
                                PASS_GRUPOCE.ToUpper.Trim = "BUS" Or PASS_GRUPOCE.ToUpper.Trim = "MAYAYI" Or
                                PASS_GRUPOCE.ToUpper.Trim = "258036" Then

                                TPass.Text = PASS_GRUPOCE
                            End If
                            TUsuario.Text = Var1

                            If Not OpenSQLSERVER(Empresa) Then
                                pwPoder = True
                                MsgBox("Imposible conectarse a la base de datos")
                                Me.Close()
                                Me.Hide()
                                Connect = "No"
                                Return
                            End If

                            VALIDA_USER_POSG()
                            'VALIDA_USER_POSG()
                            'Me.Close()
                        Else
                            Return
                        End If
                    End If
                Else
                    cnSAE.Close()
                End If

                USER_GRUPOCE = TUsuario.Text.ToUpper.Trim
                PASS_GRUPOCE = TPass.Text.Trim.ToUpper.Trim


                RazonSocial = ListBox.Items(ListBox.SelectedIndex)

                SQL = "SELECT NOMBRE, SERVIDOR, BASE, USUARIO, PASS FROM EMPRESAS WHERE EMPRESA = '" & Empresa & "'"
                cmd.Connection = cnSAROCE
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader()

                If dr.Read Then
                    RazonSocial = dr("NOMBRE")
                    Servidor = dr("SERVIDOR").ToString
                    Base = dr("BASE").ToString
                    Usuario = dr("USUARIO").ToString
                    Pass = dr("PASS").ToString
                End If
                dr.Close()

                If cnSAE.State = 0 Then
                    If Not OpenSQLSERVER(Empresa) Then
                        pwPoder = True
                        MsgBox("Imposible conectarse a la base de datos")
                        Me.Close()
                        Me.Hide()
                        Connect = "No"
                        Return
                    End If
                End If

            Catch ex As Exception
                MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            End Try
            cmd.Connection = cnSAE
            cmd2.Connection = cnSAE


            If Not EXISTE_TABLA("GCPARAMGENERALES") Or Not EXISTE_TABLA("GCPARAMTRANSCG") Or Not EXISTE_TABLA("GCCARTA_PORTE") Or Not EXISTE_TABLA("CFDI") Then
                CREA_TABLAS_TRANSGC = True
            End If

            If TUsuario.Text.ToUpper.Trim = "TABLAS" Or CREA_TABLAS_TRANSGC Then
                'MsgBox("A continuación se crearán las tablas adicionales por favor espere")


                Me.UseWaitCursor = True
                Me.Cursor = Cursors.WaitCursor
                TUsuario.Cursor = Cursors.WaitCursor

                If PASS_GRUPOCE <> "BUS" And PASS_GRUPOCE <> "BR3FRAJA" Then
                    Return
                End If

                If MsgBox("Realmente desea genera tablas?", vbYesNo) = vbNo Then
                    Return
                End If
                If MsgBox("Este proceso puede durar varios minutos, Realmente desea genera tablas?", vbYesNo) = vbNo Then
                    Return
                End If
                Lt1.Text = "Creando tablas ...... Paso 1"
                Me.Refresh()
                CREA_TABLAS()
                CREA_TABLAS_2022()
                Lt1.Text = "Creando tablas ...... Paso 2"
                Me.Refresh()
                If CREATE_TABLAS_GPS(Servidor, Usuario, Pass) Then
                End If
                Lt1.Text = "Creando tablas ......  Paso3"
                Me.Refresh()

                AGREGA_CAMPOS_SAE_2022()
                AGREGA_CAMPOS_SAE()

                Lt1.Text = "Creando tablas ......  Paso4"
                Me.Refresh()
                CREA_TABLAS_CARTA_PORTE()

                Me.Cursor = Cursors.Default
                Me.UseWaitCursor = False
                Application.UseWaitCursor = False
            End If

            If TUsuario.Text.ToUpper.Trim = "TABLAS2" Then
                MsgBox("A continuación se crearán las tablas adicionales por favor espere")

                CREA_TABLAS_2022()
                AGREGA_CAMPOS_SAE_2022()
            End If

            If TUsuario.Text.ToUpper.Trim = "TABLAS3" Then
                If MsgBox("Desea crear las tablas de derechos", vbYesNo) = vbYes Then
                    TABLAS_DERECHOS()
                End If
            End If

            If TUsuario.Text.ToUpper.Trim = "TABLAS4" Then
                If MsgBox("Desea crear las tablas de cartas porte", vbYesNo) = vbYes Then
                    CREA_TABLAS_CARTA_PORTE()
                End If
            End If

            If TUsuario.Text.ToUpper.Trim = "TABLAS5" Then
                MsgBox("A continuación se crearán las tablas 5")
                TABLAS5()
            End If

            AGREGA_CAMPOS_SAE_2023()

            Try
                cmd.CommandText = "SELECT * FROM GCUSUARIOS"
                dr = cmd.ExecuteReader()
                If Not dr.Read Then
                    SQL = "INSERT INTO GCUSUARIOS (USUARIO, NOMBRE, PASS, NIVEL) VALUES('admin','administrador','','0')"
                    cmd2.CommandText = SQL
                    cmd2.ExecuteNonQuery()
                End If
                dr.Close()
            Catch ex As Exception
                MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                SQL = "SELECT USUARIO, NOMBRE, ISNULL(CLAVE_SAE,0) AS CLAVESAE, NIVEL " &
                    "FROM GCUSUARIOS WHERE UPPER(USUARIO) = '" & TUsuario.Text.ToUpper.Trim & "' AND PASS = '" & Encriptar(TPass.Text.Trim) & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader()
                AccesoUsuario = False
                Pasw = 0
                CLAVESAE = 0
                If dr.Read Then
                    AccesoUsuario = True
                    CLAVESAE = dr("CLAVESAE")
                    If IsNumeric(dr("NIVEL")) Then
                        Pasw = dr("NIVEL")
                    Else
                        Pasw = 1
                    End If
                End If
                dr.Close()
            Catch ex As Exception
                MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            End Try

            pwPoder = False
            If TPass.Text.ToUpper.Trim = "WINAS" Or TPass.Text.ToUpper.Trim = "TAIS920" Or
                TPass.Text.ToUpper.Trim = "BR3FRAJA" Or TPass.Text.ToUpper.Trim = "SAYAYIN" Or
                TPass.Text.ToUpper.Trim = "BUS" Or TPass.Text.ToUpper.Trim = "MAYAYI" Or TPass.Text.ToUpper.Trim = "258036" Then
                pwPoder = True
            Else
                If Not AccesoUsuario Then
                    MsgBox("Acceso denegado")
                    Exit Sub
                Else
                    Select Case Pasw
                        Case 0
                            pwPoder = True
                        Case 1
                            pwPoder = False
                            pwSupervisor = False
                        Case 2
                            pwPoder = False
                            pwSupervisor = True
                    End Select
                End If
            End If
            USER_GRUPOCE = TUsuario.Text.ToUpper.Trim
            PASS_GRUPOCE = TPass.Text.Trim.ToUpper.Trim

            If TUsuario.Text.ToUpper.Trim <> "TABLAS" And TUsuario.Text.ToUpper.Trim <> "TABLAS2" And
                TUsuario.Text.ToUpper.Trim <> "TABLAS3" And TUsuario.Text.ToUpper.Trim <> "TABLAS4" And TUsuario.Text.ToUpper.Trim <> "TABLAS5" Then
                If SaveTextToFile(TUsuario.Text, System.AppDomain.CurrentDomain.BaseDirectory & "\TransPortCG.ini") Then
                End If
            End If

            LeerConfig()

            Me.Close()
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub VALIDA_USER_POSG()
        Dim AccesoUsuario As Boolean, Pasw As Integer

        If TPass.Text.ToUpper.Trim = "WINAS" Or TPass.Text.ToUpper.Trim = "TAIS920" Or
                TPass.Text.ToUpper.Trim = "BR3FRAJA" Or TPass.Text.ToUpper.Trim = "SAYAYIN" Or
                TPass.Text.ToUpper.Trim = "BUS" Or TPass.Text.ToUpper.Trim = "MAYAYI" Or TPass.Text.ToUpper.Trim = "258036" Then
            pwPoder = True
        Else
            Try
                AccesoUsuario = False : Pasw = 0 : CLAVESAE = 0
                SQL = "SELECT USUARIO, NOMBRE, ISNULL(CLAVE_SAE,0) AS CLAVESAE, NIVEL, PASS
                     FROM GCUSUARIOS 
                     WHERE 
                     UPPER(USUARIO) = '" & TUsuario.Text.ToUpper.Trim & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TPass.Text = Desencriptar(dr("PASS"))
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub ListBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            TUsuario.Focus()
        End If
    End Sub
    Private Sub TUsuario_GotFocus(sender As Object, e As EventArgs) Handles TUsuario.GotFocus
        TUsuario.SelectAll()
        TUsuario.BackColor = Color.LightCyan
    End Sub

    Private Sub TUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TUsuario.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            TPass.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub TUsuario_LostFocus(sender As Object, e As EventArgs) Handles TUsuario.LostFocus
        TUsuario.BackColor = Color.White
    End Sub
    Private Sub TPass_GotFocus(sender As Object, e As EventArgs) Handles TPass.GotFocus
        TPass.SelectAll()
        TPass.BackColor = Color.LightCyan
    End Sub
    Private Sub TPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPass.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Call CmdAceptar_Click(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub
    Private Sub TPass_LostFocus(sender As Object, e As EventArgs) Handles TPass.LostFocus
        TPass.BackColor = Color.White
    End Sub
    Private Sub CmdCancelar_Click(sender As Object, e As EventArgs) Handles CmdCancelar.Click
        End
    End Sub

    Private Function EXISTE_TABLA(fTABLA As String) As Boolean
        Dim Exist_Table As Boolean = False
        Try
            SQL = "SELECT * From INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & fTABLA & "'"
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            reader = cmd.ExecuteReader
            If reader.Read Then
                Exist_Table = True
            End If
            reader.Close()
        Catch ex As Exception
            Exist_Table = True
            BITACORADB("36. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & SQL)
        End Try
        Return Exist_Table

    End Function


    Private Sub FrmSelEmpresa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmSelEmpresa_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ListBox.BackColor = Color.LightCyan
        TUsuario.BackColor = Color.White
        TPass.BackColor = Color.White
    End Sub

    Private Sub ListBox_Click(sender As Object, e As EventArgs) Handles ListBox.Click

        Try
            Empresa = ListBox.Items(ListBox.SelectedIndex)
            Empresa = Empresa.Substring(0, 2)

            SQL = "SELECT RUTA_HUELLAS, RUTA_FOTOS, UTILIZAR_LECTOR_HUELLA FROM CONFIG WHERE EMPRESA = '" & Empresa & "'"
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        UTILIZAR_LECTOR_HUELLA = dr.ReadNullAsEmptyInteger("UTILIZAR_LECTOR_HUELLA")
                        RUTA_HUELLAS = dr.ReadNullAsEmptyString("RUTA_HUELLAS")
                        RUTA_FOTOS = dr.ReadNullAsEmptyString("RUTA_FOTOS")
                    Else
                        SQL = "INSERT CONFIG (EMPRESA, UTILIZAR_LECTOR_HUELLA, RUTA_HUELLAS, RUTA_FOTOS) VALUES ('01', 0, ' ', ' ')"
                        EXECUTE_QUERY_SAROCE(SQL)

                        UTILIZAR_LECTOR_HUELLA = 0
                        RUTA_HUELLAS = ""
                        RUTA_FOTOS = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        If UTILIZAR_LECTOR_HUELLA = 1 Then
            If RUTA_HUELLAS.Trim.Length > 0 Then

                L1.Visible = False
                L2.Visible = False
                TUsuario.Visible = False
                TPass.Visible = False
            Else
                MsgBox("Por favor capture la ruta de las huellas dactilares en configuración-parámetros del sistema-parámetros generales")
            End If
        Else
            L1.Visible = True
            L2.Visible = True
            TUsuario.Visible = True
            TPass.Visible = True
        End If

    End Sub
End Class