Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1Command
Imports System.Data.SqlClient

Public Class FrmEstatusCFDI
    Private IMPORTE As Decimal

    Private Sub FrmEstatusCFDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CADENA As String, UUID As String = "", MONTO As String
        Dim timbrarSOAP As CONSULTA_CFDI_SAT.ConsultaCFDIServiceClient = New CONSULTA_CFDI_SAT.ConsultaCFDIServiceClient
        Dim Acuse As CONSULTA_CFDI_SAT.Acuse = New CONSULTA_CFDI_SAT.Acuse
        Dim CVE_DOC As String

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

        Var10 = ""
        Var11 = ""
        IMPORTE_SAT = 0

        CVE_DOC = Var2
        LtCVE_DOC.Text = Var2


        If PassData1 = "PAGO COMPLEMENTO" Then
            UUID = BUSCAR_UUID_CFDI_PAGO(Var2)
        Else
            UUID = BUSCAR_UUID_CFDI_FACTURA(Var2)
        End If

        Try
            '?re=TEM820612AF7&rr=IFM040817JA4&tt=1.00&id=7E620865-25EA-40E1-BF5C-F0268DA33DA8
            '?re=BEN9501023I0&rr=SARM8209281F1&tt=440.000000&id=EC609EC1-5F63-4333-A2B8-2EDC10B68075"
            If UUID.Trim.Length > 0 Then
                MONTO = "0"

                'Var2 = Fg(Fg.Row, 1) 'DOCUMENTO
                'Var3 = EMISOR_NOMBRE
                'Var4 = EMISOR_RFC
                'Var5 = Fg(Fg.Row, 4) 'RFC RECEPTOR
                'Var6 = Fg(Fg.Row, 3) 'NOMBRE RECEPTOR

                LRFC_EMISOR.Text = Var4
                LTNOMBRE_EMISOR.Text = Var3
                LTRFC_RECEPTOR.Text = Var5
                LTNOMBRE_RECEPTOR.Text = Var6
                LTFOLIO_FISCAL.Text = UUID
                LTFECHA_CER.Text = Var10
                LTFECHA_EXP.Text = Var11


                'Var10 = FECHA_TIMBRADO
                'Var11 = FECHA_EXP

                CADENA = "?&id=7e620865-25ea-40e1-bf5c-f0268da33da8&re=TEM820612AF7&rr=IFM040817JA4&tt=0"

                'CADENA = "?&id=7e620865-25ea-40e1-bf5c-f0268da33da8&re=TEM820612AF7&rr=IFM040817JA4&tt=0&fe=zNmvNQ=="

                If PassData1 = "PAGO COMPLEMENTO" Then
                    LTEFECTO_COMPROBANTE.Text = "Pago"
                    LTTOTAL_CFDI.Text = "0"

                    '                                 rfc emisor     rfc receptor   importe    
                    CADENA = "?&id=" & UUID & "&re=" & Var4 & "&rr=" & Var5 & "&tt=0"
                Else
                    LTEFECTO_COMPROBANTE.Text = "Factura"
                    LTTOTAL_CFDI.Text = Format(IMPORTE_SAT, "###,###,###,###0.00")

                    '                                 rfc emisor     rfc receptor   importe    
                    CADENA = "?&id=" & UUID & "&re=" & Var4 & "&rr=" & Var5 & "&tt=" & IMPORTE_SAT
                End If

                Acuse = timbrarSOAP.Consulta(CADENA)

                LTESTADO_CFDI.Text = Acuse.Estado
                LTSTATUS_CANC.Text = Acuse.EsCancelable

                'Acuse.EstatusCancelacion

                '=================
                If Acuse.Estado.Trim = "Cancelado" Then

                    Dim FECHA_CAN As String = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss")

                    SQL = "UPDATE CFDI SET ESTATUS = 'C', FECHA_CANCELADA = GETDATE(), FECHA_CANCEL = @FECHA_CANCEL
                        WHERE FACTURA = @FACTURA"
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = CVE_DOC
                            cmd.Parameters.Add("@FECHA_CANCEL", SqlDbType.VarChar).Value = FECHA_CAN
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using

                        SQL = "UPDATE FACTF" & Empresa & " SET STATUS = 'C' WHERE CVE_DOC = '" & CVE_DOC & "'"
                        EXECUTE_QUERY_NET(SQL)

                    Catch ex As Exception
                        BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
                '==========================
            End If
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmEstatusCFDI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = "", ARCHIVO As String
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            Dim t As DataTable = DataSet1.Tables(0)
            Dim r As DataRow
            DataSet1.Clear()

            r = t.NewRow()
            r("RFC_EMISOR") = LRFC_EMISOR.Text
            r("NOMBRE_EMISOR") = LTNOMBRE_EMISOR.Text
            r("RFC_RECEPTOR") = LTRFC_RECEPTOR.Text
            r("NOMBRE_RECEPTOR") = LTNOMBRE_RECEPTOR.Text
            r("UUID") = LTFOLIO_FISCAL.Text
            r("FECHA_EXP") = LTFECHA_EXP.Text
            r("FRECHA_CER") = LTFECHA_CER.Text
            r("PAC_CER") = LT_PAC.Text
            r("TOTAL_CFDI") = LTTOTAL_CFDI.Text
            r("TIPO_COMPROBANTE") = LTEFECTO_COMPROBANTE.Text
            r("ESTADO_CFDI") = LTESTADO_CFDI.Text
            r("STATUS_CANC") = LTSTATUS_CANC.Text
            t.Rows.Add(r)

            ARCHIVO = RUTA_FORMATOS & "\ReportStatusCFDI.mrt"
            If Not File.Exists(ARCHIVO) Then
                MsgBox("No existe el reporte " & ARCHIVO & ", verifique por favor")
                Return
            End If

            StiReport1.Load(ARCHIVO)
            StiReport1.Compile()

            StiReport1.RegData(DataSet1)

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Render()

            'If PASS_GRUPOCE.ToUpper = "BUS" Then
            'StiReport1.Design()
            'Else
            'StiReport1.Show()
            'End If
            StiReport1.Show()
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

End Class
