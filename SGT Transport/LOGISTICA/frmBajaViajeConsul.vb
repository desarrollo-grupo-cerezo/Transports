Imports System.Data.SqlClient
Public Class frmBajaViajeConsul
    Private Sub frmBajaViajeConsul_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Me.Left = 50
        Me.Width = Screen.PrimaryScreen.Bounds.Width - 100

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        If Var1 = "Consulta" Then
            tCVE_BAJA.Text = Var10
            tCLIENTE.Text = Var9
            LtNombre.Text = Var8
            F1.Value = Var11
            F1.ReadOnly = True

            tCVE_BAJA.ReadOnly = True
            tCLIENTE.ReadOnly = True
        End If

        DESPLEGAR_ASIGNADOS(Var10)

    End Sub
    Sub DESPLEGAR_ASIGNADOS(fCVE_BAJA As String)
        Try
            Dim SUBTOTAL As Decimal = 0, IVA As Decimal = 0, RETENCION As Decimal = 0, NETO As Decimal = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT C.CVE_FOLIO, C.CVE_VIAJE, C.CLIENTE, T.NOMBRE, C.FECHA_DOC, C.STATUS, C.CVE_TRACTOR, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO, 
                    P1.CIUDAD AS PLAZA_ORIGEN, P2.CIUDAD AS PLAZA_DESTINO, C.TIPO_VIAJE, C.TIPO_UNI, C.CVE_OPER, C.CLAVE_O, C.CVE_TIPO_PAGO, 
                    C.CVE_ART, C.SUBTOTAL, C.IVA, C.RETENCION, C.NETO, C.FLETE, P.FECHA_CARGA, P.FECHA_DESCARGA, ISNULL(C.ST_CARTA_PORTE,1) AS ST_CP, 
                    ISNULL(ST.DESCR,'EDICION') AS ST_CARTAP 
                    FROM GCCARTA_PORTE C 
                    LEFT JOIN CLIE" & Empresa & " T ON T.CLAVE = C.CLIENTE 
                    LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = C.CLAVE_O 
                    LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = C.CLAVE_D 
                    LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C.CVE_PLAZA1
                    LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = C.CVE_PLAZA2
                    LEFT JOIN GCBAJA_VIAJE_PAR CP ON CP.CVE_FOLIO = C.CVE_FOLIO 
                    LEFT JOIN GCPEDIDOS P ON P.CVE_VIAJE = C.CVE_VIAJE 
                    LEFT JOIN GCSTATUS_CARTA_PORTE ST ON ST.CVE_CAP = C.ST_CARTA_PORTE 
                    WHERE CVE_BAJA = '" & fCVE_BAJA & "'"
                cmd.CommandText = SQL
                Fg.Rows.Count = 1
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("FECHA_DOC") & vbTab & dr("CVE_FOLIO") & vbTab & dr("CVE_TRACTOR") & vbTab &
                                   dr("ORIGEN") & vbTab & dr("DESTINO") & vbTab & dr("PLAZA_ORIGEN") & vbTab & dr("PLAZA_DESTINO") & vbTab &
                                   dr("SUBTOTAL") & vbTab & dr("IVA") & vbTab & dr("RETENCION") & vbTab & dr("NETO") & vbTab & dr("ST_CARTAP"))
                        SUBTOTAL = SUBTOTAL + dr("SUBTOTAL")
                        IVA = IVA + dr("IVA")
                        RETENCION = RETENCION + dr("RETENCION")
                        NETO = NETO + dr("NETO")
                    End While
                End Using
                tSUBTOTAL.Text = Format(SUBTOTAL, "###,###,##0.00")
                tIVA.Text = Format(IVA, "###,###,##0.00")
                tRETENCION.Text = Format(RETENCION, "###,###,##0.00")
                tNETO.Text = Format(NETO, "###,###,##0.00")
                Fg.AutoSizeCols()
            End Using
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub frmBajaViajeConsul_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
