Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO

Public Class FrmSAROCE
    Private Sub FrmSAROCE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()

        If Not IsNothing(Base_SAROCE) Then
            If Base_SAROCE.Trim.Length = 0 Then
                Base_SAROCE = "TRANSCG"
            End If
        End If

        TServidor.Text = Servidor_SAROCE
        TBase.Text = Base_SAROCE
        TUsuario.Text = Usuario_SAROCE
        TPass.Text = Pass_SAROCE
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If TServidor.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre del servidor")
            Return
        End If
        If TBase.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre de la base")
            Return
        End If
        If TUsuario.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre del usuario")
            Return
        End If
        If TPass.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la contraseña")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim cmdSqlite As New SQLiteCommand(SQLConn)
        Dim SiOpen As Boolean
        Dim HayError As Boolean = False

        SiOpen = False
        Lt.Text = "Conectando se la base"
        If Not OpenSAROCE(TServidor.Text, TBase.Text, TUsuario.Text, TPass.Text, False) Then
            If Not OpenSAE(TServidor.Text, "master", TUsuario.Text, TPass.Text) Then
                MsgBox("Imposible conectarse al servidor con estas credenciales")
            Else
                Lt.Text = "Creando base por favor espere ......"
                Me.Refresh()
                Try
                    cnSQL.Close()
                Catch ex As Exception
                End Try
                Application.DoEvents()

                If CREA_SAROCE(TServidor.Text, TBase.Text, TUsuario.Text, TPass.Text) Then
                    Try

                        Servidor_SAROCE = TServidor.Text
                        Base_SAROCE = TBase.Text
                        Usuario_SAROCE = TUsuario.Text
                        Pass_SAROCE = TPass.Text

                        Try
                            cmdSqlite.CommandText = "UPDATE config SET servidor_sar = '" & Servidor_SAROCE & "', base_sar = '" & Base_SAROCE & "', usuario_sar = '" & Usuario_SAROCE & "', pass_sar = '" & Pass_SAROCE & "'"
                            cmdSqlite.ExecuteNonQuery()
                        Catch ex As Exception
                            HayError = True
                        End Try

                        If HayError Then
                            MsgBox("Por favor ejecute el TransportGC como administrador")
                            End
                            Return
                        Else
                            If Not OpenSAROCE(Servidor_SAROCE, Base_SAROCE, Usuario_SAROCE, Pass_SAROCE) Then
                                MsgBox("La base de configuración se creo satisfactoriamente, PERO NO SE LOGRO ABRIR")
                                BtnAceptar.Enabled = True
                            Else
                                MsgBox("La base de configuración se creo satisfactoriamente")

                                Var2 = "Con Border"
                                FrmEmpresas.Show()
                                FrmEmpresas.Focus()
                                Me.Close()
                            End If
                        End If

                        Me.Cursor = Cursors.Default
                    Catch ex As Exception
                        Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If Not Directory.Exists(Application.StartupPath & "\XLS") Then
                            Directory.CreateDirectory(Application.StartupPath & "\XLS")
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    BtnAceptar.Enabled = True
                    MsgBox("No se logro crear la base de configuración")
                End If
                Lt.Text = ""
            End If
        Else
            'OPEN SAROCE OK
            Me.Cursor = Cursors.Default

            If Not EXISTE_TABLA_SAROCE("EMPRESAS") Then
                Lt.Text = ""

                MsgBox("Existe un problema con la base de configuración " & TBase.Text & "," & vbNewLine &
                       "recuerde la base de configuración no debe ser la que se utiliza para trabajar con las empresas, ejemplo EMPRESA01," & vbNewLine &
                       "si la configuración esta correcta por favor comuníquese con el administrador, " & vbNewLine &
                       "porque se deberá borrar la base " & TBase.Text & " manualmente y posteriormente entrar nuevamente al sistema")
                Return
            End If

            Try
                Servidor_SAROCE = TServidor.Text
                Base_SAROCE = TBase.Text
                Usuario_SAROCE = TUsuario.Text
                Pass_SAROCE = TPass.Text

                Try
                    SQL = "UPDATE config SET 
                        servidor_sar = '" & Servidor_SAROCE & "', 
                        base_sar = '" & Base_SAROCE & "', 
                        usuario_sar = '" & Usuario_SAROCE & "', 
                        pass_sar = '" & Pass_SAROCE & "'"
                    cmdSqlite.CommandText = SQL
                    cmdSqlite.ExecuteNonQuery()
                Catch ex As Exception
                    HayError = True
                End Try

                If HayError Then
                    MsgBox("Por favor ejecute el TransportGC como administrador")
                    End
                Else
                    Dim f As New FrmSelEmpresa With {.MdiParent = MainRibbonForm}
                    f.Show()
                End If

                Me.Close()

            Catch ex As Exception
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            End Try
        End If

        Me.Cursor = Cursors.Default

        If SiOpen Then
            Me.Hide()
            Me.Close()
        End If

    End Sub
    Private Function EXISTE_TABLA_SAROCE(fTABLA As String) As Boolean
        Dim Exist_Table As Boolean = False
        Try
            SQL = "SELECT * From INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & fTABLA & "'"
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.Connection = cnSAROCE
            cmd.CommandText = SQL
            reader = cmd.ExecuteReader
            If reader.Read Then
                Exist_Table = True
            End If
            reader.Close()
        Catch ex As Exception
            Exist_Table = False
            BITACORADB("36. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & SQL)
        End Try
        Return Exist_Table

    End Function
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Connect = "No"
        Me.Close()
    End Sub

    Private Sub FrmSAROCE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class