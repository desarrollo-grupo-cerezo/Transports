Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmCOI
    Private Sub frmCOI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Fg.Rows.Count = 1
            FgLiq.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCParamConexionCOI"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TipoConexion.Checked = True
                        txServidor.Text = dr.ReadNullAsEmptyString("Server")
                        txDB.Text = dr.ReadNullAsEmptyString("DB")
                        txUser.Text = dr.ReadNullAsEmptyString("User")
                        Try
                            If dr.ReadNullAsEmptyString("Password").ToString.Trim.Length > 0 Then
                                txPassword.Text = Desencriptar(dr.ReadNullAsEmptyString("Password"))
                            Else
                                txPassword.Text = ""
                            End If
                        Catch ex As Exception
                            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End Using

                SQL = "SELECT * FROM GCParamTiposPolizasCOI ORDER BY ID"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("ID") & vbTab & dr("Documento") & vbTab & dr("TipoPoliza"))
                    End While
                End Using
                SQL = "SELECT * FROM GCParamLiquidacionesCOI ORDER BY ID"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgLiq.AddItem("" & vbTab & dr("ID") & vbTab & dr("Descripcion") & vbTab & dr("Valor"))
                    End While
                End Using

            End Using
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmCOI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab2("Configuración de Aspel COI")
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim Pwd As String
        Dim ID As String
        Dim Valor As String
        Dim k As Integer

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                Using trn As SqlTransaction = cnSAE.BeginTransaction

                    cmd.Transaction = trn

                    For k = 1 To Fg.Rows.Count - 1
                        ID = Fg(k, 1)
                        Valor = Fg(k, 3).ToString().Replace("'", "")

                        SQL = String.Format("UPDATE GCParamTiposPolizasCOI SET TipoPoliza = '{0}' WHERE ID = {1}", Valor, ID)
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString

                        If returnValue IsNot Nothing Then
                            If returnValue <> "1" Then
                                Throw New System.Exception("No se logro grabar el registro GCParamTiposPolizasCOI")
                            End If
                        Else
                            Throw New System.Exception("No se logro grabar el registro GCParamTiposPolizasCOI")
                        End If
                    Next

                    For k = 1 To FgLiq.Rows.Count - 1
                        ID = FgLiq(k, 1)
                        Valor = FgLiq(k, 3).ToString().Replace("'", "")

                        SQL = String.Format("UPDATE GCParamLiquidacionesCOI SET Valor = '{0}' WHERE ID = {1}", Valor, ID)
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString

                        If returnValue IsNot Nothing Then
                            If returnValue <> "1" Then
                                Throw New System.Exception("No se logro grabar el registro GCParamLiquidacionesCOI")
                            End If
                        Else
                            Throw New System.Exception("No se logro grabar el registro GCParamLiquidacionesCOI")
                        End If
                    Next

                    SQL = "UPDATE GCParamConexionCOI SET [ConexionDB] = @ConexionDB, [Server] = @Server,  [DB]= @DB,  [User] = @User, [Password] = @Password
                IF @@ROWCOUNT = 0 
                    INSERT INTO GCParamConexionCOI ([ConexionDB], [Server], [DB], [User], [Password]) VALUES(@ConexionDB, @Server,@DB, @User, @Password)"

                    If txPassword.Text.Trim.Length = 0 Then
                        Pwd = ""
                    Else
                        Pwd = Encriptar(txPassword.Text)
                    End If

                    cmd.CommandText = SQL
                    cmd.Parameters.Add("@ConexionDB", SqlDbType.TinyInt).Value = IIf(TipoConexion.Checked, 0, 1)
                    cmd.Parameters.Add("@Server", SqlDbType.VarChar).Value = txServidor.Text
                    cmd.Parameters.Add("@DB", SqlDbType.VarChar).Value = txDB.Text
                    cmd.Parameters.Add("@User", SqlDbType.VarChar).Value = txUser.Text
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Pwd

                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue <> "1" Then
                            Throw New System.Exception("No se logro grabar el registro GCParamConexionCOI")
                        End If
                    Else
                        Throw New System.Exception("No se logro grabar el registro GCParamConexionCOI")
                    End If

                    trn.Commit()
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("10. Error al guarda la configuración" & vbNewLine & ex.Message)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
