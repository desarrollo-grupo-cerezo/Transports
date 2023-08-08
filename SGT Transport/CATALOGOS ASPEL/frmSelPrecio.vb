Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmSelPrecio
    Private ENTRA As Boolean = True
    Private Sub frmSelPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Var22 = 0
        ENTRA = False
        Try
            SQL = "SELECT CVE_PRECIO, DESCRIPCION
                FROM PRECIOS" & Empresa & " ORDER BY CVE_PRECIO"
            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If Var18 = "E" Then
                            If dr.ReadNullAsEmptyInteger("CVE_PRECIO") <> 2 Then
                                Fg.AddItem("" & vbTab & dr("CVE_PRECIO") & vbTab & dr("DESCRIPCION") & vbTab & 0)
                            End If
                        Else
                            Fg.AddItem("" & vbTab & dr("CVE_PRECIO") & vbTab & dr("DESCRIPCION") & vbTab & 0)
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If aDECIMAL.Length = 0 Then
                SQL = "SELECT CVE_PRECIO, PRECIO 
                    FROM PRECIO_X_PROD" & Empresa & "
                    WHERE CVE_ART = '" & Var17 & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            For k = 1 To Fg.Rows.Count - 1
                                If Fg(k, 1) = dr("CVE_PRECIO") Then
                                    Fg(k, 3) = dr("PRECIO")
                                End If
                            Next
                        End While
                    End Using
                End Using
            Else
                For k = 1 To Fg.Rows.Count - 1
                    Fg(k, 3) = aDECIMAL(k)
                Next
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Var18 = "E" Then
            Fg.AllowEditing = True
            Fg.SelectionMode = SelectionModeEnum.Cell
            BtnAceptar.Visible = True
        Else
            BtnAceptar.Visible = False
        End If
        ENTRA = True
    End Sub
    Private Sub frmSelPrecio_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 And Var18 <> "E" And ENTRA Then
                Var22 = Fg(Fg.Row, 3)
                Me.Close()
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Var18 = "E" And ENTRA Then
                If Fg.Row > 0 Then
                    If Fg.Col = 1 Or Fg.Col = 2 Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Var18 = "E" And ENTRA Then
                If Fg.Row > 0 Then
                    Fg.Col = 3
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            If Fg.Row > 0 Then
                Var22 = Fg(1, 3)
                ReDim aDECIMAL(Fg.Rows.Count - 1)

                For k = 1 To Fg.Rows.Count - 1
                    aDECIMAL(k) = Fg(k, 3)
                Next
            End If
            Me.Close()
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
