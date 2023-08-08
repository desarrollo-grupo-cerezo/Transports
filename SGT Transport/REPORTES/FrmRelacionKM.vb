Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports System.IO
Public Class FrmRelacionKM
    Private Sub FrmRelacionKM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Try
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

            Me.CenterToScreen()

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmRelacionKM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim KM_RECORRIDOS As Decimal
        Dim t As DataTable = DataSet1.Tables(0)
        Dim r As DataRow
        DataSet1.Clear()

        Try
            SQL = "SELECT FACTURA, C.CVE_VIAJE, DOCUMENT, DOCUMENT2, C.CVE_TRACTOR, C.CVE_TANQUE1, C.CVE_TANQUE2, C.CVE_OPER, O.NOMBRE, C.CLAVE_O, 
                OP1.NOMBRE AS OP_NOMBRE_O, P1.CIUDAD AS CIUDAD_O, C.CLAVE_D, OP2.NOMBRE AS OP_NOMBRE_D, P2.CIUDAD AS CIUDAD_D, 
                C.PESO_BRUTO1 - C.TARA1 AS PESO1, C.PESO_BRUTO2 - C.TARA2 AS PESO2, I.CVE_PROD, I.DESCR, F.XML, C.FECHA_CARGA, C.KM_RECORRIDOS
                FROM CFDI F
                LEFT JOIN GCCARTA_PORTE C ON C.CVE_FOLIO = F.DOCUMENT OR C.CVE_FOLIO = DOCUMENT2
                LEFT JOIN GCOPERADOR O ON O.CLAVE = C.CVE_OPER
                LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = C.CVE_ART
                LEFT JOIN GCCLIE_OP OP1 ON OP1.CLAVE = C.CLAVE_O
                LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = OP1.CVE_PLAZA
                LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = C.CLAVE_D
                LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = OP2.CVE_PLAZA
                WHERE ISNULL(F.ESTATUS,'A') <> 'C' AND C.FECHA_CARGA >= '" & FSQL(F1.Value) & " 00:00:00' AND C.FECHA_CARGA <= '" & FSQL(F2.Value) & " 23:59:00'
                ORDER BY C.CVE_TRACTOR"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If dr("CVE_TRACTOR").ToString.Length > 0 Then
                            Try
                                KM_RECORRIDOS = BUSCAR_TotalDistRec(dr("FACTURA"))
                                r = t.NewRow()
                                r("FACTURA") = dr("FACTURA")
                                r("DOCUMENT") = dr("DOCUMENT")
                                r("DOCUMENT2") = dr("DOCUMENT2")
                                r("CVE_TRACTOR") = dr("CVE_TRACTOR")
                                r("CVE_TANQUE1") = dr("CVE_TANQUE1")
                                r("CVE_TANQUE2") = dr("CVE_TANQUE2")
                                r("CVE_OPER") = dr("CVE_OPER")
                                r("NOMBRE") = dr("NOMBRE")
                                r("OP_NOMBRE_O") = dr("OP_NOMBRE_O")
                                r("CIUDAD_O") = dr("CIUDAD_O")
                                r("OP_NOMBRE_D") = dr("OP_NOMBRE_D")
                                r("CIUDAD_D") = dr("CIUDAD_D")
                                r("PESO1") = dr("PESO1")
                                r("PESO2") = dr("PESO2")
                                r("DESCR") = dr("DESCR")
                                r("KM_RECO") = KM_RECORRIDOS
                                r("FECHA_CARGA") = dr("FECHA_CARGA")
                                r("FEC1") = F1.Value
                                r("FEC2") = F2.Value
                                r("NUM") = 1
                                t.Rows.Add(r)
                            Catch ex As Exception

                            End Try

                            If KM_RECORRIDOS > 0 Then

                                If dr("DOCUMENT") = "AA-0000162490" Or dr("DOCUMENT2") = "AA-0000162490" Then
                                    KM_RECORRIDOS = KM_RECORRIDOS
                                End If
                                Try
                                    SQL = "UPDATE GCASIGNACION_VIAJE  SET KM_RECORRIDOS = " & KM_RECORRIDOS & " WHERE CVE_VIAJE = '" & dr("CVE_VIAJE") & "'"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    SQL = "UPDATE GCCARTA_PORTE SET KM_RECORRIDOS = " & KM_RECORRIDOS & " WHERE CVE_FOLIO = '" & dr("DOCUMENT") & "'"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    SQL = "UPDATE GCCARTA_PORTE SET KM_RECORRIDOS = " & KM_RECORRIDOS & " WHERE CVE_FOLIO = '" & dr("DOCUMENT2") & "'"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Else
                                KM_RECORRIDOS = KM_RECORRIDOS
                            End If

                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Dim RUTA_FORMATOS As String = ""
            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportRelacionKM.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.RegData(DataSet1)

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Render()
            StiReport1.Show()
            'StiReport1.Design()

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        BarImprimir.Enabled = True
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
