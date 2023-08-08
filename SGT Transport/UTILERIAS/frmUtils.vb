Imports System.Data.SqlClient
Public Class frmUtils
    Private Sub frmUtils_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
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

        F1.Value = "01/12/2020"
        F2.Value = "31/12/2020"

    End Sub

    Private Sub BarUpdateLibUni_Click(sender As Object, e As EventArgs) Handles BarUpdateLibUni.Click
        Dim CLAVEMONTE As String = "", CVE_DOC As String = "", Nreg As Integer = 0, Nreg2 As Integer = 0, CVE_DOC_FAC As String = ""

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_DOC, CVE_PEDI, DOC_SIG FROM FACTR" & Empresa & " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            CVE_DOC = dr.ReadNullAsEmptyString("CVE_DOC")
                            CLAVEMONTE = ""
                            CVE_DOC_FAC = dr.ReadNullAsEmptyString("DOC_SIG")

                            If dr.ReadNullAsEmptyString("CVE_PEDI").ToString.Trim.Length > 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT CVE_UNI FROM GCORDEN_TRABAJO_EXT WHERE CVE_ORD = '" & dr.ReadNullAsEmptyString("CVE_PEDI") & "'"
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            CLAVEMONTE = dr2.ReadNullAsEmptyString("CVE_UNI")
                                        End If
                                    End Using
                                End Using
                            End If
                        Catch ex As Exception
                            Bitacora("20. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            MsgBox("20. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                        If CLAVEMONTE.Trim.Length > 0 Then
                            Try
                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                    'Placa: Xxxxx Unidad: XXXXX
                                    BUSCA_UNIDAD_CLAVEMONTE(CLAVEMONTE)

                                    SQL = "UPDATE FACTR_CLIB" & Empresa & " SET CAMPLIB4 = 'Placa:" & Var7 & " Unidad: " & CLAVEMONTE & "' " &
                                        "WHERE CLAVE_DOC = '" & CVE_DOC & "' " &
                                        "IF @@ROWCOUNT = 0 " &
                                        "INSERT INTO FACTR_CLIB" & Empresa & " (CLAVE_DOC, CAMPLIB4) VALUES('" & CVE_DOC & "','Placa:" & Var7 & " Unidad: " & CLAVEMONTE & "')"
                                    cmd3.CommandText = SQL
                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            Nreg = Nreg + 1
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("30. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                MsgBox("30. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                            If CVE_DOC_FAC.Trim.Length > 0 Then
                                Try
                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                        'Placa: Xxxxx Unidad: XXXXX
                                        BUSCA_UNIDAD_CLAVEMONTE(CLAVEMONTE)

                                        SQL = "UPDATE FACTF_CLIB" & Empresa & " SET CAMPLIB4 = 'Placa:" & Var7 & " Unidad: " & CLAVEMONTE & "' " &
                                            "WHERE CLAVE_DOC = '" & CVE_DOC_FAC & "' " &
                                            "IF @@ROWCOUNT = 0 " &
                                            "INSERT INTO FACTF_CLIB" & Empresa & " (CLAVE_DOC, CAMPLIB4) VALUES('" & CVE_DOC_FAC & "','Placa:" & Var7 & " Unidad: " & CLAVEMONTE & "')"
                                        cmd3.CommandText = SQL
                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                                Nreg2 = Nreg2 + 1
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("40. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    MsgBox("40. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End While
                End Using
            End Using
            MsgBox("Proceso terminado, REMISIONES actualizados " & Nreg & vbNewLine &
                   "Proceso terminado, FACTURAS actualizados " & Nreg2)
        Catch ex As Exception
            Bitacora("75. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("75. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
End Class
