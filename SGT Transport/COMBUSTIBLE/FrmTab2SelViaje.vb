Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmTab2SelViaje
    Private Sub FrmTab2SelViaje_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        DESPLEGAR()

    End Sub
    Sub DESPLEGAR()
        Dim s As String

        Fg.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT T.CVE_TAB, T.NUM_VIAJE, T.STATUS, T.FOLIO_LIQ, T.CVE_OPER, T.CVE_UNI, T.NOMBRE_OPER, T.TIPO_VIAJE, 
                    T.CLIENTE, T.NOMBRE_CLIE, T.CVE_ORI, T.ORIGEN, T.CVE_DES, T.DESTINO, T.CARGADO_VACIO, T.KMS, 
                    T.RENDIMIENTO, T.LITROS, T.TONELADAS, FECHA_IDA
                    FROM GCRESET_TAB_VIKINGOS_PAR T 
                    LEFT JOIN GCCLIE_OP C On C.CLAVE = T.CLIENTE 
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.CVE_ORI 
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.CVE_DES 
                    WHERE ISNULL(T.STATUS,'A') = 'A' AND CVE_RES = " & Var10 & "
                    ORDER BY T.CVE_TAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        s = dr("NUM_VIAJE") & vbTab '1
                        s &= dr.ReadNullAsEmptyString("FECHA_IDA") & vbTab '2
                        s &= "(" & dr("CLIENTE") & ") " & dr("NOMBRE_CLIE") & vbTab '3
                        s &= dr("CVE_ORI") & vbTab '4
                        s &= dr.ReadNullAsEmptyString("ORIGEN") & vbTab '5
                        s &= dr("CVE_DES") & vbTab '6
                        s &= dr.ReadNullAsEmptyString("DESTINO") & vbTab '7
                        s &= IIf(dr.ReadNullAsEmptyInteger("CARGADO_VACIO") = 0, "Vacio", "Cargado") & vbTab '8
                        s &= dr.ReadNullAsEmptyString("TIPO_VIAJE") '9

                        Fg.AddItem("" & vbTab & s)
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmTab2SelViaje_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarSeleccionar_Click(sender As Object, e As ClickEventArgs) Handles BarSeleccionar.Click
        If Fg.Row > 0 Then
            Var11 = Fg(Fg.Row, 1)
            Me.Close()
        End If
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        BarSeleccionar_Click(Nothing, Nothing)
    End Sub
End Class