Imports System.Data.SqlClient

Public Class FrmRecalEve2
    Private TIPO_TAB As Integer
    Private Sub FrmRecalEve2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If
        Me.CenterToScreen()

        Try
            Dim i As Integer = 1
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

            TIPO_TAB = Var27

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim LTS_AUTORIZADOS2 As Decimal, LTS_DESCONTAR2 As Decimal, DESCXLITROS2 As Decimal, z As Integer = 0, Ntot As Integer
        Dim LRC1 As Decimal, LRC2 As Decimal, LRC3 As Decimal, LRC4 As Decimal, LTS_VALES2 As Decimal

        If MsgBox("Realmente desea recalcular evento2?", vbYesNo) = vbNo Then
            Return
        End If

        SQL = "SELECT R.CVE_RES, R.ESTADO, R.STATUS, R.FECHA, R.CVE_OPER, NOMBRE, R.NO_LIQUI, R.CVE_UNI, U.CLAVEMONTE,
            ISNULL(STUFF((SELECT ', ' + cast(NUM_VIAJE as varchar(10)) FROM GCRESET_TAB_VIKINGOS_PAR S WHERE S.CVE_RES = R.CVE_RES FOR XML PATH ('')),1,1, ''),'') AS VIAJES, 
            M.DESCR As NOMBREMOTOR, R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CALIF_VEL_MAX, CAL_GLO_EVA, BONO_RES, R.ODOMETRO, KM_ECM,
            LTS_ECM, LTS_REAL, LTS_AUTORIZADOS, LTS_DESCONTAR, KMS_TAB, LTS_TAB, FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI,
            LTS_PTO_RALENTI, PORC_TIEMPO_PTO_RALENTI, PORC_LTS_PTO_RALENTI, REND_ECM, PORC_VAR_LTS_ECM_REAL, PORC_VAR_LTS_TAB_REAL,
            REND_REAL, DIF_LTS_REAL_LTS_ECM, DIF_LTS_REAL_LTS_TAB, R.FECHAELAB, R.UUID,
            ISNULL((SELECT MIN(FECHA_IDA) FROM GCRESET_TAB_VIKINGOS_PAR WHERE CVE_RES = R.CVE_RES),'') AS F_IDA_INI,
            ISNULL((SELECT MAX(FECHA_IDA) FROM GCRESET_TAB_VIKINGOS_PAR WHERE CVE_RES = R.CVE_RES),'') AS F_IDA_FIN,
            PORC_TOL_EVENTO2, LTS_AUTORIZADOS2, LTS_VALES2, LTS_DESCONTAR2, PRECIO_X_LTS2, DESCXLITROS2, 
            LTS_SALIDA, LTS_VALES, LTS_FORANEOS, LTS_LLEGADA, EVENTO, CASE WHEN EVENTO_LTS = 0 THEN 'Lts. ECM' ELSE 'Lts. TAB' END AS LTS_ECM_TAB
            FROM GCRESETEO R 
            Left Join GCOPERADOR O ON O.CLAVE = R.CVE_OPER 
            Left Join GCUNIDADES U ON U.CLAVE = R.CVE_UNI 
            LEFT JOIN GCMOTORES M ON M.CVE_MOT = R.CVE_MOT 
            WHERE R.STATUS = 'A' AND R.ESTADO = 'FINALIZADO' AND 
            FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "'
            ORDER BY R.FECHAELAB DESC"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If dr("EVENTO") = 1 Then

                            LRC1 = dr.ReadNullAsEmptyDecimal("LTS_SALIDA")
                            LRC2 = dr.ReadNullAsEmptyDecimal("LTS_VALES")
                            LRC3 = dr.ReadNullAsEmptyDecimal("LTS_FORANEOS")
                            LRC4 = dr.ReadNullAsEmptyDecimal("LTS_LLEGADA")

                            LTS_VALES2 = LRC1 + LRC2 + LRC3 - LRC4

                            If dr("PORC_TOL_EVENTO2") > 0 Then
                                LTS_AUTORIZADOS2 = dr.ReadNullAsEmptyDecimal("LTS_ECM") + ((dr.ReadNullAsEmptyDecimal("LTS_ECM") * dr.ReadNullAsEmptyDecimal("PORC_TOL_EVENTO2")) / 100)
                            Else
                                LTS_AUTORIZADOS2 = 0
                            End If

                            If RadLtsECM.Checked Then
                                Select Case TIPO_TAB
                                    Case 0 'MONTELLANO  TABULADOR EDE RUTAS
                                        If LTS_VALES2 > 0 Then
                                            If LTS_AUTORIZADOS2 < LTS_VALES2 Then
                                                LTS_DESCONTAR2 = LTS_AUTORIZADOS2 - LTS_VALES2
                                            Else
                                                LTS_DESCONTAR2 = 0
                                            End If
                                        Else
                                            LTS_DESCONTAR2 = 0
                                        End If
                                        If LTS_DESCONTAR2 > 0 Then
                                            LTS_DESCONTAR2 = 0
                                            DESCXLITROS2 = 0
                                        End If
                                    Case 1
                                        'VIKINGOS TABULADOR ED RUTAS
                                        If LTS_VALES2 > 0 Then
                                            If LTS_AUTORIZADOS2 < LTS_VALES2 Then
                                                LTS_DESCONTAR2 = LTS_AUTORIZADOS2 - LTS_VALES2
                                            Else
                                                LTS_DESCONTAR2 = 0
                                            End If
                                        Else
                                            LTS_DESCONTAR2 = 0
                                        End If
                                    Case 2
                                        'MONTELLANO VIAJES POR LIQUIDAR
                                        If LTS_VALES2 Then
                                            LTS_DESCONTAR2 = LTS_AUTORIZADOS2 - LTS_VALES2
                                        Else
                                            LTS_DESCONTAR2 = LTS_AUTORIZADOS2
                                        End If
                                End Select

                                If dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS2") > 0 Then
                                    DESCXLITROS2 = LTS_DESCONTAR2 * dr("PRECIO_X_LTS2")
                                Else
                                    DESCXLITROS2 = 0
                                End If

                                If dr("CVE_RES") = 808 Then
                                    Debug.Print("")
                                End If
                                Ntot += 1
                                Try
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        SQL = "UPDATE GCRESETEO SET LTS_AUTORIZADOS2 = " & LTS_AUTORIZADOS2 & ", LTS_VALES2 = " & LTS_VALES2 & ",
                                        LTS_DESCONTAR2 = " & LTS_DESCONTAR2 & ", DESCXLITROS2 = " & DESCXLITROS2 & "
                                        WHERE CVE_RES = " & dr.ReadNullAsEmptyLong("CVE_RES")
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery()
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                                z += 1
                                                Lt1.Text = z & "/" & Ntot
                                            End If
                                        End If
                                    End Using

                                Catch ex As Exception
                                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                End Try
                            Else
                                '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                                '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                                '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘

                                'LITROS TABULADOR
                                Try
                                    'EVENTO 2 OPCION 2
                                    'EVENTO 2 LITROS TABULADOR

                                    Select Case TIPO_TAB
                                        Case 0 'MONTELLANO  TABULADOR EDE RUTAS
                                            If LTS_VALES2 > 0 Then

                                                If LTS_AUTORIZADOS2 > LTS_VALES2 Then
                                                    LTS_DESCONTAR2 = 0
                                                    DESCXLITROS2 = 0
                                                Else '               SUMA DE LOS LTS DEL FG
                                                    LTS_DESCONTAR2 = dr.ReadNullAsEmptyDecimal("LTS_TAB") - LTS_VALES2
                                                    DESCXLITROS2 = LTS_DESCONTAR2 * dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS2")
                                                End If

                                                If LTS_DESCONTAR2 > 0 Then
                                                    LTS_DESCONTAR2 = 0
                                                    DESCXLITROS2 = 0
                                                End If
                                            End If
                                        Case 1
                                            'VIKINGOS TABULADOR ED RUTAS
                                            If LTS_AUTORIZADOS2 > LTS_VALES2 Then
                                                LTS_DESCONTAR2 = 0
                                                DESCXLITROS2 = 0
                                            Else
                                                LTS_DESCONTAR2 = dr.ReadNullAsEmptyDecimal("LTS_TAB") - LTS_VALES2
                                                DESCXLITROS2 = LTS_DESCONTAR2 * dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS2")
                                            End If

                                        Case 2
                                            LTS_DESCONTAR2 = dr.ReadNullAsEmptyDecimal("LTS_TAB") - LTS_VALES2
                                            DESCXLITROS2 = LTS_DESCONTAR2 * dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS2")
                                    End Select

                                    LTS_AUTORIZADOS2 = dr("LTS_TAB")

                                    Try

                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            SQL = "UPDATE GCRESETEO SET LTS_AUTORIZADOS2 = " & LTS_AUTORIZADOS2 & ", LTS_VALES2 = " & LTS_VALES2 & ",
                                                    LTS_DESCONTAR2 = " & LTS_DESCONTAR2 & ", DESCXLITROS2 = " & DESCXLITROS2 & "
                                                    WHERE CVE_RES = " & dr.ReadNullAsEmptyLong("CVE_RES")
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery()
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                    z += 1
                                                    Lt1.Text = z & "/" & Ntot
                                                End If
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                    End Try

                                Catch ex As Exception
                                    Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End While
                End Using
            End Using

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class