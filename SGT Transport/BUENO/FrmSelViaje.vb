Imports System.Data.SqlClient

Public Class FrmSelViaje
    Private Evento As String
    Private VIAJES_ESCENARIO As Integer = 0
    Private TIPO_ESCENARIO As Integer = 99

    Private Sub FrmSelViaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        TCVE_DOC.Value = ""
        TNUM_VIAJES_COPIAR.Value = 1
        Var44 = 0
        If IsNumeric(Var2) Then
            VIAJES_ESCENARIO = Convert.ToInt16(Var2)
        Else
            VIAJES_ESCENARIO = 0
        End If

        BtnFactura.Visible = False
        Lt1.Visible = False
        Lt1.Visible = False
        TNUM_VIAJES_COPIAR.Visible = False

        Evento = Var2

        If Evento = "Copiar viaje" Then
            Lt1.Visible = True
            TNUM_VIAJES_COPIAR.Visible = True
        End If

    End Sub
    Private Sub FrmSelViaje_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnSelViaje_Click(sender As Object, e As EventArgs) Handles BtnSelViaje.Click
        Try
            Var2 = "Asignacion Viajes bueno2"
            Var4 = "" : Var5 = "" : Var6 = "" : Var10 = ""

            FrmSelItem.ShowDialog()
            MainRibbonForm.Activate()
            If Var4.Trim.Length > 0 Then

                TCVE_VIAJE.Text = Var4
                If IsNumeric(Var5) Then
                    TIPO_ESCENARIO = Convert.ToInt16(Var5)  'TIPO DE FACTURACION O ESCENARIO
                Else
                    TIPO_ESCENARIO = 0
                End If

                If TIPO_ESCENARIO = 3 Then
                    If Evento = "CANCELAR FACTURA" Then
                        BtnFactura.Visible = True
                        Lt2.Visible = True
                        TCVE_DOC.Visible = True
                        Lt2.Left = Lt1.Left
                        Lt2.Top = Lt1.Top
                        TCVE_DOC.Left = TNUM_VIAJES_COPIAR.Left
                        TCVE_DOC.Top = TNUM_VIAJES_COPIAR.Top
                        BtnFactura.Left = BtnSelViaje.Left
                        BtnFactura.Top = TCVE_DOC.Top
                    Else
                        BtnFactura.Visible = False
                        Lt2.Visible = False
                        TCVE_DOC.Visible = False
                    End If
                End If

                Var2 = "" : Var4 = "" : Var5 = ""
            Else
                BtnFactura.Visible = False
                Lt2.Visible = False
                TCVE_DOC.Visible = False
                TIPO_ESCENARIO = 99
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Try
            TNUM_VIAJES_COPIAR.UpdateValueWithCurrentText()


            If TCVE_VIAJE.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un viaje")
                Return
            Else


                Var24 = TCVE_VIAJE.Text
                Var44 = TNUM_VIAJES_COPIAR.Value
                Var47 = TCVE_DOC.Text

                Me.Close()
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TCVE_VIAJE_Validated(sender As Object, e As EventArgs) Handles TCVE_VIAJE.Validated
        Try
            If TCVE_VIAJE.Text.Trim.Length > 0 Then
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader

                SQL = "SELECT ISNULL(TIPO_FACTURACION,0) AS TIPO_FACT 
                    FROM GCASIGNACION_VIAJE 
                    WHERE CVE_VIAJE = '" & TCVE_VIAJE.Text & "' AND CVE_ST_VIA <> 7"
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TIPO_ESCENARIO = dr("TIPO_FACT")

                    If TIPO_ESCENARIO = 3 Then
                        If Evento = "CANCELAR FACTURA" Then
                            BtnFactura.Visible = True
                            Lt2.Visible = True
                            TCVE_DOC.Visible = True
                            Lt2.Left = Lt1.Left
                            Lt2.Top = Lt1.Top
                            TCVE_DOC.Left = TNUM_VIAJES_COPIAR.Left
                            TCVE_DOC.Top = TNUM_VIAJES_COPIAR.Top
                            BtnFactura.Left = BtnSelViaje.Left
                            BtnFactura.Top = TCVE_DOC.Top
                        Else
                            BtnFactura.Visible = False
                            Lt2.Visible = False
                            TCVE_DOC.Visible = False
                        End If
                    End If
                Else
                    MsgBox("Viaje inexistente")
                    TCVE_VIAJE.Text = ""
                End If
                dr.Close()
            Else
                BtnFactura.Visible = False
                Lt2.Visible = False
                TCVE_DOC.Visible = False
                TIPO_ESCENARIO = 99
            End If
        Catch ex As Exception
            Bitacora("1680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnFactura_Click(sender As Object, e As EventArgs) Handles BtnFactura.Click

        If TCVE_VIAJE.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el viaje")
            Return
        End If

        Try
            Var2 = "Abonos viajes"
            Var4 = "" : Var5 = "" : Var6 = "" : Var10 = ""
            Var46 = TCVE_VIAJE.Text

            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_DOC.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_DOC_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_DOC.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnFactura_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_DOC_Validated(sender As Object, e As EventArgs) Handles TCVE_DOC.Validated
        Try
            If TCVE_VIAJE.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture el viaje")
                Return
            End If

            If TCVE_DOC.Text.Trim.Length > 0 Then
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader

                SQL = "SELECT ISNULL(CVE_DOC,0) AS CVEDOC
                    FROM GCASIGNACION_VIAJE_ABONOS
                    WHERE CVE_DOC = '" & TCVE_DOC.Text & "'"
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If Not dr.Read Then
                    MsgBox("Factura inexistente")
                    TCVE_DOC.Text = ""
                End If
                dr.Close()
            End If
        Catch ex As Exception
            Bitacora("1680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_VIAJE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_VIAJE.KeyDown
        Try

            If e.KeyCode = 13 Then
                BtnAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class