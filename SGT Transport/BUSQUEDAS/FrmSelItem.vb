Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmSelItem
    Dim Proceso As String
    Dim VarCadena As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmSelItem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If DialogOK = "Show" Then
            Me.TopMost = False
        End If
        Me.Dispose()
    End Sub
    Private Sub FrmSelItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not Valida_Conexion() Then
                Return
            End If

            If DialogOK = "Show" Then
                Me.TopMost = True
            End If

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)

                ToolStrip1.BackColor = Color.FromArgb(207, 221, 238)

            Catch ex As Exception
            End Try

            tBox.Text = ""
            SQL = ""

            Proceso = Var2
            VarCadena = Var46

            If VarCadena.Trim.Length > 0 Then
                Lt1.Text = "Linea :" & VarCadena
            End If
            If Proceso = "InveR" Or Proceso = "InvenRS" Then
                barRefresh.Visible = True
                barServicios.Visible = True
            Else
                barRefresh.Visible = False
                barServicios.Visible = False
            End If

            BindingSource1.ResetBindings(True)
            BindingSource1.RemoveFilter()

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable


            Select Case Proceso
                Case "Abonos viajes"
                    SQL = "SELECT CVE_DOC, SUBTOTAL, IVA, RET, NETO 
                        FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = '" & VarCadena & "'"

                Case "PagoComplemento"
                    SQL = "SELECT M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,
                        ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND 
                        M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) AS SUMA_CUENDET,
                        M.IMPORTE, M.TIPO_MOV, M.DOCTO, M.NUM_CPTO
                        FROM CUEN_M" & Empresa & " M
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE 
                        LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = M.REFER 
                        WHERE M.NUM_CPTO <> 9 AND ISNULL(F.METODODEPAGO,'PPD') = 'PPD' AND ISNULL(F.FORMADEPAGOSAT,'99') = 99 AND 
                        AND M.CVE_CLIE = '" & Var4 & "' 
                        ORDER BY M.CVE_CLIE, M.REFER"
                Case "CuentaOrdenante"
                    'CUENTA_ORD" & Empresa & " 
                    SQL = "SELECT CUENTA_BANCARIA, RFC_BANCO, NOMBRE_BANCO, CLAVE, CLABE 
                        FROM CUENTA_ORD" & Empresa & " 
                        WHERE CLAVE = '" & Var46 & "'
                        ORDER BY NOMBRE_BANCO"
                    Fg.Cols.Count = 6
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Cuenta bancaria"
                    Fg(0, 2) = "RFC banco"
                    Fg(0, 3) = "Nombre del banco"
                    Fg(0, 4) = "Clave banco"
                    Fg(0, 5) = "CLABE"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 110
                    Fg.Cols(2).Width = 90
                    Fg.Cols(3).Width = 220
                    Fg.Cols(4).Width = 90
                    Fg.Cols(5).Width = 90
                Case "CuentaBeneficiaria"
                    SQL = "Select CUENTA_BANCARIA, RFC_BANCO, NOMBRE_BANCO, CLAVE, CLABE FROM CUENTA_BENEF" & Empresa & " ORDER BY NOMBRE_BANCO"
                    Fg.Cols.Count = 6
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Cuenta bancaria"
                    Fg(0, 2) = "RFC banco"
                    Fg(0, 3) = "Nombre del banco"
                    Fg(0, 4) = "Clave banco"
                    Fg(0, 5) = "CLABE"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 110
                    Fg.Cols(2).Width = 90
                    Fg.Cols(3).Width = 220
                    Fg.Cols(4).Width = 90
                    Fg.Cols(5).Width = 90
                Case "Aseguradoras"
                    SQL = "SELECT CLAVE, NOMBRE FROM GCASEGURADORAS WHERE STATUS = 'A' ORDER BY CLAVE"
                Case "Unidad"
                    SQL = "SELECT U.CLAVE, U.CLAVEMONTE, U.DESCR, U.PLACAS_MEX, M.DESCR AS MARCA, T.DESCR AS TUNI
                        FROM GCUNIDADES U 
                        LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA 
                        LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI
                        WHERE ISNULL(U.STATUS, 'A') = 'A' ORDER BY U.CLAVEMONTE"
                    Fg.Cols.Count = 9
                    Fg(0, 0) = ""
                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Unidad"
                    Fg(0, 3) = "Descripción unidad"
                    Fg(0, 4) = "Placas"
                    Fg(0, 5) = "Marca"
                    Fg(0, 6) = "Tipo unidad"
                    Fg.Cols(0).Width = 35
                    Fg.Cols(1).Width = 0
                    Fg.Cols(2).Width = 90
                    Fg.Cols(3).Width = 220
                    Fg.Cols(4).Width = 100
                    Fg.Cols(5).Width = 80
                    Fg.Cols(6).Width = 80
                Case "GCDEDUC_OPER"
                    If Not IsNumeric(Var3.Trim) Then
                        Var3 = "0"
                    End If
                    SQL = "SELECT DO.FOLIO, D.DESCR AS DESCR_DED, DO.DESCR, DO.IMPORTE_PRESTAMO, 
                        ISNULL((SELECT SUM(IMPORTE) FROM GCLIQ_DEDUCCIONES D WHERE D.STATUS = 'A' AND D.CVE_DED = DO.FOLIO),0) AS ABONOS,
                        DO.IMPORTE_PRESTAMO - ISNULL((SELECT SUM(IMPORTE) FROM GCLIQ_DEDUCCIONES D WHERE D.STATUS = 'A' AND D.CVE_DED = DO.FOLIO),0) AS SALDO_ACT,
                        DO.FECHA 
                        FROM GCDEDUC_OPER DO
                        LEFT JOIN GCDEDUCCIONES D ON D.CVE_DED = DO.CVE_DED
                        WHERE DO.STATUS = 'A' AND CVE_OPER = " & Var3 & " AND YEAR(FECHA) > 2021 AND 
                        DO.IMPORTE_PRESTAMO - ISNULL((SELECT SUM(IMPORTE) FROM GCLIQ_DEDUCCIONES D WHERE D.STATUS = 'A' AND D.CVE_DED = DO.FOLIO),0) > .09
                        ORDER BY DO.FOLIO"
                    Var3 = "0"
                Case "Deducciones"
                    SQL = "SELECT CVE_DED, DESCR FROM GCDEDUCCIONES WHERE STATUS = 'A' ORDER BY CVE_DED"
                Case "Reseteo"
                    SQL = "SELECT TOP 500 R.CVE_RES, R.STATUS, R.FECHA, R.CVE_OPER, R.CVE_UNI, R.CVE_MOT, R.ODOMETRO, R.KM_ECM, R.LTS_ECM, R.LTS_REAL, R.LTS_TAB, 
                        R.FAC_CARGA, R.HRS_TRABAJO, R.HRS_PTO_RALENTI, R.LTS_PTO_RALENTI, R.PORC_TIEMPO_PTO_RALENTI, R.PORC_LTS_PTO_RALENTI, R.REND_ECM, 
                        R.PORC_VAR_LTS_ECM_REAL, R.PORC_VAR_LTS_TAB_REAL, R.REND_REAL, R.DIF_LTS_REAL_LTS_ECM, R.DIF_LTS_REAL_LTS_TAB, 
                        LTS_SALIDA, LTS_VALES, LTS_LLEGADA, PDF, ESTADO, DESCT, CALIF, VELMAX, TIEMPO_MARCH_INERCIA, KMS_TAB, CALIF_FACTOR_CARGA, 
                        CALIF_RALENTI, CALIF_GLOBAL, CAL_FAC_CAR_EVA, CAL_RAL_EVA, CAL_GLO_EVA, LTS_DESCONTAR, PRECIO_X_LTS, LTS_AUTORIZADOS, 
                        LITROS_UREA, CARGO_X_PUNTO_MUERTO, FACTOR_CARGA, PORC_USO_RALENTI, LTS_UREA_REAL, PORC_TOLERANCIA, PORC_RALENTI, 
                        NO_VIAJE, NO_LIQUI, BONO_RES, LTS_FORANEOS, CVE_EVE, CALIF_VEL_MAX, NO_DE_VIAJES, NO_DE_VIAJES_VACIO, BONO_RES_VACIO
                        FROM GCRESETEO R ORDER BY R.CVE_RES DESC"
                Case "Evento"
                    SQL = "SELECT CVE_EVE, CASE WHEN TABULADOR = 1 THEN 'Si' ELSE 'No' END, CASE WHEN FISICO_VS_ECM = 1 THEN 'Si' ELSE 'No' END, 
                        CASE WHEN RALENTI = 1 THEN 'Si' ELSE 'No' END, PORC_TOLERANCIA, PORC_RALENTI, CRITERIO 
                        FROM GCCRITERIOS_EVA WHERE STATUS = 'A' ORDER BY CVE_EVE"
                Case "Motor"
                    SQL = "SELECT CVE_MOT, MOTOR, DESCR, CASE 
                        WHEN TIPO_VIAJE = 0 THEN 'Full' 
                        WHEN TIPO_VIAJE = 1 THEN 'Sencillo'
                        WHEN TIPO_VIAJE = 2 THEN 'Full/Sencillo' ELSE '' END AS TIP_VIAJE 
                        FROM GCMOTORES WHERE STATUS = 'A' ORDER BY CVE_MOT"
                Case "TAQ"
                    SQL = "SELECT CVE_TAQ, ISNULL(T1_ANCHO,0), ISNULL(T1_ALTO,0), ISNULL(T1_PROFUNDIDAD,0), ISNULL(T1_LITROS,0), ISNULL(T2_ANCHO,0), 
                        ISNULL(T2_ALTO,0), ISNULL(T2_PROFUNDIDAD,0), ISNULL(T2_LITROS,0)  
                        FROM GCTANQUES WHERE STATUS <> 'C' ORDER BY CVE_TAQ"
                Case "Medicion combustible"
                    SQL = "SELECT M.CLAVE, U.CLAVEMONTE, M.FECHA, M.SUMA
                        FROM GCMEDICIONCOMBUSTIBLE M
                        LEFT JOIN GCUNIDADES U ON U.CLAVE = M.CVE_UNI
                        WHERE M.STATUS <> 'C' AND CLAVEMONTE = '" & Var4 & "' AND TIPO_LITROS = " & Var20 & " AND ISNULL(CVE_RES,0) = 0
                        ORDER BY M.CLAVE DESC"
                Case "OT"
                    SQL = "SELECT CVE_ORD, ESTATUS, FECHA, CVE_UNI FROM GCORDEN_TRABAJO_EXT WHERE STATUS <> 'C' ORDER BY CAST(CVE_ORD AS INT)"
                Case "Almacenes"
                    SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
                Case "RecogerEn", "EntregarEn"
                    SQL = "SELECT CAST(CVE_REG AS INT) AS CVEREG, DESCR FROM GCRECOGER_EN_ENTREGAR_EN WHERE STATUS = 'A' ORDER BY CAST(CVE_REG AS INT)"
                Case "FACT"
                    If Var15.Trim.Length = 0 Then
                        Var15 = "C"
                    End If
                    If Var11.Trim.Length = 0 Then
                        SQL = "SELECT TOP 200 F.CVE_DOC, CLAVE, NOMBRE, FECHA_DOC, IMPORTE, ISNULL(DOC_SIG,'') AS DOCSIG, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG,
                              ISNULL((SELECT COUNT(*) FROM PAR_FACT" & Var15 & Empresa & " WHERE CVE_DOC = F.CVE_DOC AND TIPO_PROD = 'S'),0) AS NSer
                              FROM FACT" & Var15 & Empresa & " F
                              LEFT JOIN FACT" & Var15 & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = F.CVE_DOC
                              LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                              WHERE F.STATUS <> 'C' AND ENLAZADO = 'O' AND
                              ISNULL((SELECT ISNULL(SUM(PXS),0) FROM PAR_FACT" & Var15 & Empresa & " WHERE CVE_DOC = F.CVE_DOC),0) > 0
                              ORDER BY F.FECHAELAB DESC"
                    Else
                        SQL = "SELECT TOP 200 F.CVE_DOC, CLAVE, NOMBRE, FECHA_DOC, IMPORTE, ISNULL(DOC_SIG,'') AS DOCSIG, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG
                              FROM FACT" & Var15 & Empresa & " F
                              LEFT JOIN FACT" & Var15 & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = F.CVE_DOC
                              LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                              WHERE F.STATUS <> 'C' AND ENLAZADO = 'O' AND CVE_CLPV = '" & Var11 & "' AND
                              ISNULL((SELECT ISNULL(SUM(PXS),0) FROM PAR_FACT" & Var15 & Empresa & " WHERE CVE_DOC = F.CVE_DOC),0) > 0
                              ORDER BY F.FECHAELAB DESC"
                    End If
                    SQL2 = SQL

                Case "CFDI"
                    SQL = "SELECT FACTURA AS 'Factura', CASE WHEN ESTATUS = 'C' THEN 'Cancelada' ELSE 'Emitida' END AS 'Estatus', 
                        CASE WHEN ISNULL(ESTATUS,'') = 'C' THEN '' ELSE DOCUMENT END AS 'Carta porte', 
                        CASE WHEN ISNULL(ESTATUS,'') = 'C' THEN '' ELSE ISNULL(DOCUMENT2,'') END AS 'carta porte 2', 
                        FECHAELAB AS 'Fecha elaboración', OBS_CANC AS 'Observaciones'                    
                        FROM CFDI ORDER BY FECHAELAB DESC"

                Case "FACTURAS"
                    SQL = "SELECT TOP 200 F.CVE_DOC, CLAVE, NOMBRE, FECHA_DOC, IMPORTE, ISNULL(DOC_ANT,'') AS DOCSIG, ISNULL(TIP_DOC_ANT,'') AS TIPDOCSIG
                        FROM FACTF" & Empresa & " F
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                        WHERE F.STATUS <> 'C'
                        ORDER BY F.FECHAELAB DESC"
                Case "COMP"
                    'var11 prov
                    'VAR15 TIPO DOC
                    If Var11.Trim.Length = 0 Then
                        SQL = "SELECT TOP 200 F.CVE_DOC, ISNULL(CVE_CLPV,'') AS PROV, ISNULL(NOMBRE,'') AS NOMB, FECHA_DOC, IMPORTE,                             ISNULL(DOC_SIG,'') AS DOCSIG, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG
                            FROM COMP" & Var15 & Empresa & " F
                            LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                            WHERE F.STATUS <> 'C' AND
                            ISNULL((SELECT ISNULL(SUM(PXR),0) FROM PAR_COMP" & Var15 & Empresa & " WHERE CVE_DOC = F.CVE_DOC),0) > 0
                            ORDER BY F.FECHAELAB DESC"
                    Else
                        SQL = "SELECT TOP 200 F.CVE_DOC, ISNULL(CVE_CLPV,'') AS PROV, ISNULL(NOMBRE,'') AS NOMB, FECHA_DOC, IMPORTE, 
                            ISNULL(DOC_SIG,'') AS DOCSIG, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG
                            FROM COMP" & Var15 & Empresa & " F
                            LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = F.CVE_CLPV
                            WHERE F.STATUS <> 'C' AND CVE_CLPV = '" & Var11 & "' AND
                            ISNULL((SELECT ISNULL(SUM(PXR),0) FROM PAR_COMP" & Var15 & Empresa & " WHERE CVE_DOC = F.CVE_DOC),0) > 0
                            ORDER BY F.FECHAELAB DESC"
                    End If
                Case "Usuario"
                    SQL = "SELECT USUARIO, NOMBRE FROM GCUSUARIOS ORDER BY NOMBRE"
                Case "Consulta Bajas Viajes"
                    SQL = "SELECT TOP 200 CVE_BAJA, STATUS, FECHA, " &
                        "(SELECT SUM(SUBTOTAL) FROM GCBAJA_VIAJE_PAR WHERE CVE_BAJA = B.CVE_BAJA) AS STOTAL, " &
                        "(SELECT SUM(IVA) FROM GCBAJA_VIAJE_PAR WHERE CVE_BAJA = B.CVE_BAJA) AS IV, " &
                        "(SELECT SUM(RETENCION) FROM GCBAJA_VIAJE_PAR WHERE CVE_BAJA = B.CVE_BAJA) AS RET, " &
                        "(SELECT SUM(NETO) FROM GCBAJA_VIAJE_PAR WHERE CVE_BAJA = B.CVE_BAJA) AS NET " &
                        "FROM GCBAJA_VIAJE B ORDER BY CVE_BAJA DESC"

                Case "Asignacion Viajes bueno"
                    Select Case ESCENARIO
                        Case 3
                            SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                A.NETO, ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0) AS ABONOS,
                                (A.NETO -ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) AS SALDO,
                                O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                FROM GCASIGNACION_VIAJE A 
                                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                WHERE A.STATUS <> 'C' AND ISNULL(FACTURADO,'') <> 'S' OR (A.TIPO_FACTURACION = 3 AND 
                                (A.NETO - ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) > 0.09)
                                ORDER BY A.FECHAELAB DESC"
                        Case 1, 2
                            SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
                                O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                FROM GCASIGNACION_VIAJE A 
                                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                WHERE A.STATUS <> 'C' AND ISNULL(FACTURADO,'') <> 'S'
                                ORDER BY A.FECHAELAB DESC"
                        Case 0
                            SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
                                O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                FROM GCASIGNACION_VIAJE A 
                                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                WHERE A.STATUS <> 'C'
                                ORDER BY A.FECHAELAB DESC"
                        Case Else
                            SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
                                O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                FROM GCASIGNACION_VIAJE A 
                                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                WHERE A.STATUS <> 'C' AND ISNULL(FACTURADO,'') <> 'S'
                                ORDER BY A.FECHAELAB DESC"
                    End Select
                Case "Asignacion Viajes bueno2"

                    If Var19 = "MOSTRAR TODOS" Then
                        Select Case ESCENARIO
                            Case 3
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.TIPO_FACTURACION, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                A.NETO, ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0) AS ABONOS,
                                (A.NETO -ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) AS SALDO,
                                O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                FROM GCASIGNACION_VIAJE A 
                                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                WHERE A.STATUS <> 'C'
                                ORDER BY A.FECHAELAB DESC"
                            Case 1, 2
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.TIPO_FACTURACION, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
                                O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                FROM GCASIGNACION_VIAJE A 
                                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                WHERE A.STATUS <> 'C'
                                ORDER BY A.FECHAELAB DESC"
                            Case 0
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.TIPO_FACTURACION, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
                                O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                FROM GCASIGNACION_VIAJE A 
                                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                WHERE A.STATUS <> 'C'
                                ORDER BY A.FECHAELAB DESC"
                            Case Else
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.TIPO_FACTURACION, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
                                O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                FROM GCASIGNACION_VIAJE A 
                                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                WHERE A.STATUS <> 'C'
                                ORDER BY A.FECHAELAB DESC"
                        End Select
                    Else
                        Select Case ESCENARIO
                            Case 3
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.TIPO_FACTURACION, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                    A.NETO, ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0) AS ABONOS,
                                    (A.NETO -ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) AS SALDO,
                                    O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                    FROM GCASIGNACION_VIAJE A 
                                    LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                    LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                    LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                    WHERE A.STATUS <> 'C' AND ISNULL(FACTURADO,'') <> 'S' AND ISNULL(TIMBRADO,'') <> 'S' AND (A.NETO -ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) > .01
                                    ORDER BY A.FECHAELAB DESC"
                            Case 1, 2
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.TIPO_FACTURACION, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                    CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
                                    O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                    FROM GCASIGNACION_VIAJE A 
                                    LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                    LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                    LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                    LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                    WHERE A.STATUS <> 'C' AND ISNULL(FACTURADO,'') <> 'S' AND ISNULL(TIMBRADO,'') <> 'S'
                                    ORDER BY A.FECHAELAB DESC"
                            Case 0
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.TIPO_FACTURACION, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                    CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
                                    O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                    FROM GCASIGNACION_VIAJE A 
                                    LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                    LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                    LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                    LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                    WHERE A.STATUS <> 'C'
                                    ORDER BY A.CVE_VIAJE DESC"
                            Case Else
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.TIPO_FACTURACION, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                                CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS ESTATUSVIAJE, 
                                O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 
                                FROM GCASIGNACION_VIAJE A 
                                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                                LEFT JOIN GCCLIE_OP C1 ON C1.CLAVE  = A.CLAVE_O 
                                LEFT JOIN GCCLIE_OP C2 ON C2.CLAVE  = A.CLAVE_D 
                                WHERE A.STATUS <> 'C'
                                ORDER BY A.FECHAELAB DESC"
                        End Select
                    End If
                Case "Asignacion viajes"
                    SQL = "SELECT TOP 100 A.CVE_VIAJE, U.CLAVEMONTE, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI,
                        (CASE A.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, O.NOMBRE,
                        (CASE WHEN ISNULL(P1.CIUDAD,'') = '' THEN A.ENTREGAR_EN ELSE ISNULL(P1.CIUDAD,'') END) AS DESCR_ORIGEN,
                        (CASE WHEN ISNULL(P2.CIUDAD,'') = '' THEN A.RECOGER_EN ELSE ISNULL(P2.CIUDAD,'') END) AS DESCR_DESTINO,
                        S.DESCR, (SELECT TOP 1 ISNULL(CVE_VIAJE,'') FROM GCCARTA_PORTE WHERE CVE_VIAJE = A.CVE_VIAJE) AS VIAJE
                        FROM GCASIGNACION_VIAJE A
                        LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                        LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                        LEFT JOIN GCCONTRATO CT ON CT.CVE_CON = A.CVE_CON
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = CT.CVE_ORIGEN
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = CT.CVE_DESTINO
                        WHERE ISNULL(A.STATUS,'A') <> 'C' AND 
                        ISNULL((SELECT TOP 1 ISNULL(CVE_VIAJE,'') FROM GCCARTA_PORTE WHERE CVE_VIAJE = A.CVE_VIAJE),'') = '' 
                        ORDER BY TRY_PARSE(U.CLAVE AS INT) DESC"
                Case "Asignacion viajes Liq"
                    SQL = "SELECT TOP 100 CAST(A.CVE_VIAJE AS INT), U.CLAVEMONTE, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI,
                        (CASE A.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, O.NOMBRE,
                        (CASE WHEN ISNULL(P1.CIUDAD,'') = '' THEN A.ENTREGAR_EN ELSE ISNULL(P1.CIUDAD,'') END) AS DESCR_ORIGEN,
                        (CASE WHEN ISNULL(P2.CIUDAD,'') = '' THEN A.RECOGER_EN ELSE ISNULL(P2.CIUDAD,'') END) AS DESCR_DESTINO,
                        S.DESCR, (SELECT TOP 1 ISNULL(CVE_VIAJE,'') FROM GCCARTA_PORTE WHERE CVE_VIAJE = A.CVE_VIAJE) AS VIAJE
                        FROM GCASIGNACION_VIAJE A
                        LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                        LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                        LEFT JOIN GCCONTRATO CT ON CT.CVE_CON = A.CVE_CON
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = CT.CVE_ORIGEN
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = CT.CVE_DESTINO
                        WHERE ISNULL(A.STATUS,'A') <> 'C' AND 
                        ISNULL((SELECT TOP 1 ISNULL(CVE_VIAJE,'') FROM GCCARTA_PORTE WHERE CVE_VIAJE = A.CVE_VIAJE),'') <> ''
                        ORDER BY TRY_PARSE(A.CVE_VIAJE AS INT) DESC"
                Case "Asignacion viajes todos"
                    SQL = "SELECT TOP 100 A.CVE_VIAJE, U.CLAVEMONTE, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI,
                        (CASE A.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, O.NOMBRE,
                        (CASE WHEN ISNULL(P1.CIUDAD,'') = '' THEN A.ENTREGAR_EN ELSE ISNULL(P1.CIUDAD,'') END) AS DESCR_ORIGEN,
                        (CASE WHEN ISNULL(P2.CIUDAD,'') = '' THEN A.RECOGER_EN ELSE ISNULL(P2.CIUDAD,'') END) AS DESCR_DESTINO,
                        S.DESCR, (SELECT TOP 1 ISNULL(CVE_VIAJE,'') FROM GCCARTA_PORTE WHERE CVE_VIAJE = A.CVE_VIAJE) AS VIAJE
                        FROM GCASIGNACION_VIAJE A
                        LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                        LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                        LEFT JOIN GCCONTRATO CT ON CT.CVE_CON = A.CVE_CON
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = CT.CVE_ORIGEN
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = CT.CVE_DESTINO
                        WHERE ISNULL(A.STATUS,'A') <> 'C'
                        ORDER BY A.CVE_VIAJE DESC"
                Case "Cliente operativo"
                    SQL = "SELECT TRY_PARSE(C.CLAVE AS INT), C.NOMBRE, ISNULL(P1.CIUDAD,'') AS PLAZA, C.DOMICILIO
                        FROM GCCLIE_OP C
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C.CVE_PLAZA
                        WHERE C.STATUS = 'A'
                        ORDER BY TRY_PARSE(C.CLAVE AS INT) "
                Case "Tab Rutas"
                    SQL = "SELECT D.CVE_RUTA, FECHA, (D.ORIGEN + ' ' + D.DESTINO) AS RUTA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI,
                        D.COSTO_CASETAS, D.KM_RECORRIDOS, D.EJES
                        FROM GCDETALLE_RUTAS D
                        WHERE D.STATUS = 'A'"
                Case "Detalle Rutas"
                    'Fg(0, 1) = "Clave"
                    'Fg(0, 2) = "Origen"
                    'Fg(0, 3) = "Destino"
                    'Fg(0, 4) = "Km recorridos"
                    'Fg(0, 5) = "Costo casetas"
                    'Fg(0, 6) = "Ejes"
                    SQL = "SELECT D.CVE_RUTA AS 'Clave', P1.CIUDAD AS 'Origen', P2.CIUDAD AS 'Destino', ISNULL(D.KM_RECORRIDOS,0) AS 'Km. Recorridos',
                        ISNULL(D.COSTO_CASETAS,0) AS 'Costo casetas', ISNULL(D.EJES,0) AS 'Ejes'
                        FROM GCDETALLE_RUTAS D
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = D.CVE_PLA1
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = D.CVE_PLA2
                        WHERE d.STATUS = 'A' ORDER BY CVE_RUTA"
                Case "Remision"
                    SQL = "SELECT TOP 100 CVE_DOC, CVE_CLPV, NOMBRE, FECHA_DOC, IMPORTE
                        FROM FACTR" & Empresa & " F
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CVE_CLPV
                        WHERE F.STATUS <> 'C' ORDER BY CVE_DOC DESC"
                Case "Moneda"
                    SQL = "SELECT NUM_MONED, DESCR, CVE_MONED, TCAMBIO FROM MONED" & Empresa & " WHERE STATUS = 'A' ORDER BY NUM_MONED"
                Case "Esquema"
                    SQL = "SELECT CVE_ESQIMPU, DESCRIPESQ FROM IMPU" & Empresa & " WHERE STATUS = 'A' ORDER BY CVE_ESQIMPU"
                Case "Lineas"
                    SQL = "SELECT CVE_LIN, ISNULL(DESC_LIN,'') AS DESCR FROM CLIN" & Empresa & " WHERE STATUS = 'A' AND 
                        ISNULL(CVE_LIN,'') <> '' 
                        ORDER BY CVE_LIN"
                Case "Clientes", "Clie01", "Clie"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, ISNULL(CAMPLIB5,0) AS LIB5, ISNULL(CAMPLIB6,0) AS LIB6
                        FROM CLIE" & Empresa & " C
                        LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = C.CLAVE
                        WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                Case "CLIE"
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, MUNICIPIO 
                        FROM CLIE" & Empresa & " C 
                        WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                Case "Prov"
                    SQL = "SELECT CLAVE, NOMBRE, RFC, CALLE FROM PROV" & Empresa & " WHERE STATUS = 'A' ORDER BY CLAVE"
                Case "Zona"
                    SQL = "SELECT CVE_ZONA, TEXTO FROM ZONA" & Empresa & " WHERE STATUS = 'A' AND TNODO = 'C' ORDER BY TEXTO"
                Case "Pais"
                    SQL = "SELECT CVE_PAIS, DESCR FROM PAIS" & Empresa & "  ORDER BY DESCR"
                Case "Vend"
                    SQL = "SELECT CVE_VEND, NOMBRE FROM VEND" & Empresa & "  WHERE STATUS = 'A' ORDER BY NOMBRE"
                Case "Listaprec"
                    SQL = "SELECT CVE_PRECIO, DESCRIPCION FROM PRECIOS" & Empresa & "  WHERE STATUS = 'A' ORDER BY CVE_PRECIO"
                Case "ConcCxC"
                    SQL = "SELECT NUM_CPTO, DESCR FROM CONC" & Empresa & " WHERE STATUS = 'A' AND TIPO = 'A' AND CON_REFER = 'S' ORDER BY NUM_CPTO"
                Case "ConcSAT"
                    SQL = "SELECT FORMADEPAGOSAT, DESCR, NUM_CPTO FROM CONC" & Empresa & " WHERE STATUS = 'A' AND TIPO = 'A' AND CON_REFER = 'S' AND 
                        ISNULL(FORMADEPAGOSAT,'') <> '' ORDER BY FORMADEPAGOSAT"
                Case "CONM"
                    SQL = "SELECT CVE_CPTO, DESCR, CPN FROM CONM" & Empresa & " WHERE STATUS = 'A' ORDER BY CVE_CPTO"
                Case "GCLLANTAS_CONM"
                    SQL = "SELECT C.CVE_CPTO, C.DESCR, S.DESCR AS DESCR_ST, CASE WHEN C.SIGNO = 1 THEN 'Entrada' ELSE 'Salida' END AS ENTSAL, 
                        C.STATUS_LLANTA
                        FROM GCLLANTAS_CONM C
                        LEFT JOIN GCLLANTA_STATUS S ON S.CVE_STATUS = C.STATUS_LLANTA 
                        WHERE C.STATUS = 'A' ORDER BY C.CVE_CPTO"
                Case "ConcCxP"
                    SQL = "SELECT NUM_CPTO, DESCR FROM CONP" & Empresa & " WHERE STATUS = 'A' AND TIPO = 'A' ORDER BY NUM_CPTO"
                Case "ConcCxPRef"
                    SQL = "SELECT NUM_CPTO, DESCR FROM CONP" & Empresa & " WHERE STATUS = 'A' AND TIPO = 'A' AND CON_REFER = 'S' ORDER BY NUM_CPTO"

                Case "ProvDocSaldos"
                    '               
                    SQL = "SELECT M.REFER, M.CVE_PROV, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,
                        ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " D WHERE M.CVE_PROV = D.CVE_PROV AND 
                        M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) + 
                        (SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM PAGA_DET" & Empresa & " C3 
                        WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1) AS SUMA_CUENDET,
                        M.IMPORTE,
                        M.IMPORTE + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " D WHERE M.CVE_PROV = D.CVE_PROV AND 
                        M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) + 
                        (SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM PAGA_DET" & Empresa & " C3 WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1),
                        M.NUM_CARGO, M.DOCTO, M.NUM_CPTO
                        FROM PAGA_M" & Empresa & " M
                        INNER JOIN PROV" & Empresa & " P ON M.CVE_PROV = P.CLAVE
                        LEFT JOIN COMPC" & Empresa & " C ON M.REFER = C.CVE_DOC
                        WHERE M.NUM_CPTO <> 9 AND
                        (M.IMPORTE + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM PAGA_DET" & Empresa & " D WHERE M.CVE_PROV = D.CVE_PROV AND M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0)) > 0.1 " &
                        IIf(Var4.Trim.Length = 0, "", " AND M.CVE_PROV = '" & Var4 & "'") &
                        "ORDER BY M.CVE_PROV, M.REFER "

                Case "ClieDocSaldos"
                    SQL = "SELECT M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,
                        ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) AS SUMA_CUENDET,
                        M.IMPORTE, M.TIPO_MOV, M.DOCTO, M.NUM_CPTO
                        FROM CUEN_M" & Empresa & " M
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE 
                        LEFT JOIN FACTF" & Empresa & " C ON C.CVE_DOC = M.REFER 
                        WHERE M.NUM_CPTO <> 9 AND
                        (M.IMPORTE + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0)) > 0.1 " &
                        IIf(Var4.Trim.Length = 0, "", " AND M.CVE_CLIE = '" & Var4 & "'") &
                        "ORDER BY M.CVE_CLIE, M.REFER"
                Case "ClieDocSaldos2"
                    '                1           2         3            4            5             6 
                    SQL = "SELECT M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,"
                    '                                                  7
                    SQL &= "ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND 
                        M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) + 
                        (SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM CUEN_DET" & Empresa & " C3 
                        WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1) AS SUMA_CUENDET,"
                    SQL &= "M.IMPORTE, " '8
                    '                  9
                    SQL &= "M.IMPORTE + 
                        ISNULL((SELECT SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " C4 WHERE REFER = M.REFER AND CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO AND NUM_CARGO = M.NUM_CARGO),0) AS SALDO,"
                    '              10          11         12 
                    SQL &= "M.DOCTO, M.NUM_CARGO, M.NUM_CPTO "
                    SQL &= "FROM CUEN_M" & Empresa & " M
                        INNER JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE
                        WHERE M.NUM_CPTO <> 9 AND
                        (M.IMPORTE + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE CVE_CLIE = M.CVE_CLIE AND REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND M.NUM_CARGO = D.NUM_CARGO),0)) > 0.1 " &
                        IIf(Var4.Trim.Length = 0, "", " AND M.CVE_CLIE = '" & Var4 & "'") & " ORDER BY M.CVE_CLIE, M.REFER "


                Case "DocPagosComp"
                    SQL = "SELECT TOP 500 M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.NO_FACTURA, M.DOCTO, M.IMPORTE, NO_PARTIDA
                        FROM CUEN_DET" & Empresa & " M
                        INNER JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE
                        WHERE M.CVE_CLIE = '" & Var4 & "' AND M.REFER = '" & Var5 & "' ORDER BY M.FECHAELAB DESC"
                Case "ClieDocTo"
                    SQL = "SELECT M.DOCTO, P.NOMBRE, M.FECHA_APLI, M.NO_FACTURA, M.IMPORTE
                        FROM CUEN_M" & Empresa & " M
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = M.CVE_CLIE 
                        WHERE M.NUM_CPTO <> 9 AND M.CVE_CLIE = '" & Var4 & "'
                        ORDER BY M.CVE_CLIE, M.REFER"
                Case "ProvDocTo"
                    SQL = "SELECT M.DOCTO, P.NOMBRE, M.FECHA_APLI, M.NO_FACTURA, M.IMPORTE
                        FROM PAGA_M" & Empresa & " M
                        LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = M.CVE_PROV
                        WHERE M.NUM_CPTO <> 9 AND M.CVE_PROV = '" & Var4 & "'
                        ORDER BY M.CVE_PROV, M.REFER"
                Case "FACTG"
                    'Fg(0, 1) = "Documento"
                    'Fg(0, 2) = "Clave"
                    'Fg(0, 3) = "Nombre"
                    'Fg(0, 4) = "Fecha"
                    'Fg(0, 5) = "Importe"
                    'Fg(0, 6) = "Tipo mov."
                    'Fg(0, 7) = "No. Factura"
                    'Fg(0, 8) = "Docto"
                    'Fg(0, 9) = "Concepto"
                    SQL = "SELECT REFER, CVE_CLIE, NOMBRE, FECHA_APLI, IMPORTE, NO_FACTURA, DOCTO, 
                        CAST(D.NUM_CPTO AS VARCHAR(2)) + ' ' + C.DESCR
                        FROM CUEN_DET" & Empresa & " D
                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = D.CVE_CLIE 
                        LEFT JOIN CONC" & Empresa & " C ON C.NUM_CPTO = D.NUM_CPTO
                        WHERE ISNULL(CVE_DOC_COMPPAGO,'') = '' AND ISNULL(C.FORMADEPAGOSAT,'') <> '' AND 
                        CVE_CLIE = '" & Var4 & "' ORDER BY REFER"
                Case "Tip Opera", "Tip Tercero"
                    SQL = "SELECT TIPO, DESCR FROM OPER_TERCEROS" & Empresa & " ORDER BY TIPO"

                Case "Estados"
                    SQL = "SELECT CVE_ESTADO, NOMBRE FROM GCESTADOS WHERE STATUS = 'A'"
                Case "GCASEGURADORAS"
                    SQL = "SELECT CLAVE, NOMBRE FROM GCASEGURADORAS WHERE STATUS = 'A'"
                Case "GCPOLIZAS"
                    SQL = "SELECT IDPOLIZA, FOLIO, T.DESCR AS DESCR_TIPO_POL, E.DESCR AS EQUIPO, R.NOMBRE, TIPO_COBERTURA " &
                        "FROM GCPOLIZAS P " &
                        "LEFT JOIN GCTIPO_POLIZA T ON T.TIPO_POL = P.TIPO_POL " &
                        "LEFT JOIN GCEQUIPO_ASEGURADO E ON E.CVE_ASE = P.CVE_ASE " &
                        "LEFT JOIN PROV" & Empresa & " R ON R.CLAVE = P.CVE_PROV " &
                        "WHERE P.STATUS = 'A' ORDER BY IDPOLIZA"

                Case "GCSERVICIOS_MANTE"
                    SQL = "SELECT CVE_SER, DESCR FROM GCCATINCIDENCIAS WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Incidencias"
                    SQL = "SELECT CVE_INC, DESCR FROM GCCATINCIDENCIAS WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Tipo Poliza"
                    SQL = "SELECT TIPO_POL, DESCR FROM GCTIPO_POLIZA WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Equipo Asegurado"
                    SQL = "SELECT CVE_ASE, DESCR FROM GCEQUIPO_ASEGURADO WHERE STATUS = 'A' ORDER BY DESCR"

                Case "IAVE"
                    SQL = "SELECT CLAVE, DESCR, VIGENCIA FROM GCTARJETA_IAVE WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Origen"
                    SQL = "SELECT CLAVE, DESCR FROM GCORIGEN WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Destino"
                    SQL = "SELECT CLAVE, DESCR FROM GCDESTINO WHERE STATUS = 'A' ORDER BY DESCR"

                Case "Status"
                    SQL = "SELECT CVE_ST, DESCR FROM GCSTATUS WHERE STATUS = 'A' ORDER BY CVE_ST"
                Case "Rutas"
                    SQL = "SELECT CAST(CVE_RUTA AS INT), ORIGEN, DESTINO FROM GCRUTAS ORDER BY CAST(CVE_RUTA AS INT)"
                Case "GCConc"
                    SQL = "SELECT CVE_GAS, DESCR, CLASIFIC FROM GCCONC_GASTOS WHERE STATUS = 'A' ORDER BY CVE_GAS"
                Case "AnticipoCat"
                    SQL = "SELECT CVE_ANT, DESCR FROM GCANTICIPOS_CAT WHERE STATUS = 'A' ORDER BY CVE_ANT"
                Case "AnticipoViaje"
                    SQL = "SELECT A.CVE_ANTVI, A.FECHA, ISNULL(C.DESCR,'') AS DES, A.IMPORTE " &
                        "FROM GCANTICIPOS_VIAJE A " &
                        "LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = A.NUM_CPTO "
                Case "TipoDescuento"
                    SQL = "SELECT CVE_TIPO, DESCR FROM GCTIPO_DESC WHERE STATUS = 'A' ORDER BY CVE_TIPO"
                Case "FormaDescuento"
                    SQL = "SELECT CVE_FOR, DESCR FROM GCFORMA_DESC WHERE STATUS = 'A' ORDER BY CVE_FOR"
                Case "Autoriza"
                    SQL = "SELECT CVE_AUT, NOMBRE FROM GCAUTORIZA WHERE STATUS = 'A' ORDER BY CVE_AUT"

                Case "Fallas"

                    SQL = "SELECT CAST(P.CVE_FALLA AS INT), U.DESCR, P.DESCR_FALLA, P.CVE_ORD AS 'Orden asignada', P.CVE_UNI, P.NO_PARTIDA " &
                        "FROM GCREPORTE_FALLAS_PAR P " &
                        "LEFT JOIN GCREPORTE_FALLAS F ON F.CVE_FALLA = P.CVE_FALLA " &
                        "LEFT JOIN GCUNIDADES U ON U.CLAVE = P.CVE_UNI " &
                        "WHERE F.STATUS = 'A' AND P.CVE_UNI <> '' ORDER BY CAST(P.CVE_FALLA AS INT)"
                Case "Inven" 'SOLO PRODUCTOS
                    SQL = "SELECT CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM GCCVES_ALTER A WHERE CVE_ART = I.CVE_ART) AS NUM_PARTE, EXIST, CVE_ESQIMPU 
                        FROM INVE" & Empresa & " I WHERE STATUS = 'A' AND TIPO_ELE = 'P' ORDER BY DESCR"

                Case "Articulo" 'TODOS
                    SQL = "SELECT CVE_ART, ISNULL(DESCR,'') AS DES, ISNULL(EXIST,0) AS EXI FROM INVE" & Empresa & " 
                        WHERE STATUS = 'A' AND TIPO_ELE <> 'K' AND CVE_ART <> 'TOT' ORDER BY DESCR"

                Case "ArticulosLlantas"
                    SQL = "SELECT M.CVE_ART, MAX(I.DESCR) AS DES, MAX(M.EXIST)
                        FROM MULT" & Empresa & " M 
                        LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                        WHERE I.TIPO_ELE = 'P' AND M.CVE_ALM IN (SELECT NUM_ALM FROM GCLLANTAS_ALMACENES)
                        GROUP BY M.CVE_ART"

                Case "InveP" 'SOLO PRODUCTOS
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, 
                        EXIST, TIPO_ELE, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I 
                        LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'P' ORDER BY CVE_ART"
                Case "GCINVER"
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO, (SELECT TOP 1 CVE_ALTER FROM GCCVES_ALTER A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, 
                        EXIST, TIPO_ELE, ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM GCINVER I 
                        LEFT JOIN GCPRECIO_X_PROD P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'P' ORDER BY I.CVE_ART"

                Case "InveSAE" 'SOLO SERVICIOS Y CLAVE ESPECIAL
                    SQL = "SELECT I.CVE_ART, DESCR, (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1,
                        (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA
                        FROM INVE" & Empresa & " I 
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'S' AND LIN_PROD = '" & LINEA_VALOR_DECLA & "' ORDER BY CVE_ART"

                Case "InveS" 'SOLO SERVICIOS Y LINEA ESPECIFICA
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO,
                        (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, EXIST, TIPO_ELE,
                        ISNULL(COSTO_PROM,0) AS C_PROM
                        FROM INVE" & Empresa & " I 
                        LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND P.CVE_PRECIO = 1 
                        WHERE I.STATUS = 'A' AND TIPO_ELE = 'S' AND LIN_PROD = '" & Var5 & "' ORDER BY DESCR"
                    Debug.Print("")
                Case "InvenTabRutas"
                    SQL = "SELECT I.CVE_ART, DESCR, PRECIO,
                        (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, EXIST, TIPO_ELE,
                        ISNULL(COSTO_PROM,0) AS C_PROM, LIN_PROD
                        FROM INVE" & Empresa & " I 
                        LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND P.CVE_PRECIO = 1 
                        WHERE I.STATUS = 'A' AND LIN_PROD = '" & Var11 & "' ORDER BY DESCR"

                Case "InveLiq" 'SOLO LINEA ESPECIFICA
                    SQL = "SELECT I.CVE_ART, DESCR, (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1,
                        (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA 
                        FROM INVE" & Empresa & " I 
                        WHERE I.STATUS = 'A' AND LIN_PROD = '" & VarCadena & "' ORDER BY CVE_ART"

                Case "InvenRS"
                    SQL = "SELECT CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS NUM_PARTE, " &
                        "EXIST, CVE_ESQIMPU " &
                        "FROM INVE" & Empresa & " I WHERE STATUS = 'A' AND TIPO_ELE = 'S' " &
                        "ORDER BY DESCR"
                Case "Servicios" 'SOLO SERVICIOS
                    SQL = "SELECT CVE_ART, DESCR, EXIST FROM INVE" & Empresa & " WHERE STATUS = 'A' AND TIPO_ELE = 'S' ORDER BY DESCR"

                Case "Inventario"
                    ' --------------------               MULTIALMACEN      -----------------------
                    ' --------------------               MULTIALMACEN      -----------------------
                    ' --------------------               MULTIALMACEN      -----------------------
                    If G_ALM = 0 Then G_ALM = 1
                    If MULTIALMACEN = 0 Then
                        SQL = "SELECT CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS NUM_PARTE, 
                            EXIST, TIPO_ELE, STATUS 
                            FROM INVE" & Empresa & " I WHERE I.STATUS = 'A' AND I.TIPO_ELE <> 'K' ORDER BY I.DESCR"
                    Else
                        SQL = "SELECT M.CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = M.CVE_ART) AS NUM_PARTE, 
                            M.EXIST, I.TIPO_ELE, M.STATUS 
                            FROM MULT" & Empresa & " M 
                            LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                            WHERE I.STATUS = 'A' AND M.STATUS = 'A' AND I.TIPO_ELE <> 'K' AND CVE_ALM = " & G_ALM & " ORDER BY I.DESCR"
                    End If
                    ' --------------------               MULTIALMACEN      -----------------------

                Case "InveR"
                    SQL = "SELECT CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS NUM_PARTE, 
                        EXIST, TIPO_ELE, STATUS 
                        FROM INVE" & Empresa & " I WHERE I.STATUS = 'A' AND I.TIPO_ELE <> 'K' ORDER BY I.CVE_ART"
                Case "InvenRP"
                    SQL = "SELECT CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER" & Empresa & " FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS NUM_PARTE, EXIST, CVE_ESQIMPU " &
                        "FROM INVE" & Empresa & " I WHERE STATUS = 'A' AND TIPO_ELE = 'P' ORDER BY DESCR"

                Case "GCPRODUCTOS", "Productos"
                    SQL = "SELECT CVE_PROD, DESCR FROM GCPRODUCTOS WHERE STATUS = 'A'"
                Case "Mecanicos"
                    SQL = "SELECT CVE_MEC, DESCR FROM GCMECANICOS WHERE STATUS = 'A' ORDER BY CVE_MEC"
                Case "Viajes"
                    SQL = "SELECT FAST(CLAVE AS INT), CVE_VIAJE, DESCR FROM GCVIAJES WHERE STATUS = 'A' ORDER BY CAST(CLAVE AS INT)"
                Case "Numero de Viaje"
                    SQL = "SELECT CAST(CVE_VIAJE AS INT), DESCR FROM GCNUM_VIAJE WHERE STATUS = 'A' ORDER BY CAST(CVE_VIAJE AS INT)"
                Case "Tipo de Cobro"
                    SQL = "SELECT CAST(CVE_COBRO AS INT), DESCR FROM GCTIPO_COBRO WHERE STATUS = 'A' ORDER BY CAST(CVE_COBRO AS INT)"
                Case "Carta Porte"
                    SQL = "SELECT CVE_FOLIO, CVE_VIAJE, FECHA_DOC, C.CVE_ART, DESCR, ST_CARTA_PORTE " &
                        "FROM GCCARTA_PORTE C " &
                        "LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = C.CVE_ART " &
                        "WHERE C.STATUS = 'A' AND CVE_FOLIO <> '" & Var10 & "' ORDER BY CVE_FOLIO"
                Case "Contrato"
                    SQL = "SELECT T.CVE_CON, P1.NOMBRE AS NOMBRE1, P2.NOMBRE AS NOMBRE2, P3.NOMBRE As NOMBRE3
                        From GCCONTRATO T
                        LEFT JOIN GCCLIE_OP P1 ON P1.CLAVE = T.NO_CONTRATO
                        LEFT JOIN GCCLIE_OP P2 ON P2.CLAVE = T.CLAVE_O
                        LEFT JOIN GCCLIE_OP P3 ON P3.CLAVE = T.CLAVE_D
                        Where T.STATUS = 'A' ORDER BY CAST(T.CVE_CON AS INT) DESC"
                Case "ContratoTab"
                    SQL = "SELECT T.CVE_CON, P1.NOMBRE AS NOMBRE1, P2.NOMBRE AS NOMBRE2, P3.NOMBRE As NOMBRE3
                        From GCCONTRATO T
                        LEFT JOIN GCCLIE_OP P1 ON P1.CLAVE = T.NO_CONTRATO
                        LEFT JOIN GCCLIE_OP P2 ON P2.CLAVE = T.CLAVE_O
                        LEFT JOIN GCCLIE_OP P3 ON P3.CLAVE = T.CLAVE_D
                        WHERE T.STATUS = 'A' AND NOT EXISTS (SELECT CVE_TAB FROM GCTAB_RUTAS_F WHERE CVE_CON = T.CVE_CON)
                        ORDER BY TRY_PARSE(T.CVE_CON AS INT) DESC"
                Case "Modelo"
                    SQL = "Select CAST(CVE_MOD AS INT), DESCR FROM GCMODELO_UNIDAD WHERE STATUS = 'A' ORDER BY CAST(CVE_MOD AS INT)"
                Case "Modelo Renovado"
                    SQL = "SELECT CAST(CVE_MODELO AS INT), DESCR FROM GCLLANTA_MODELO WHERE STATUS = 'A' ORDER BY CAST(CVE_MODELO AS INT)"

                Case "LlantasNoAsignadas"
                    SQL = "SELECT CAST(LL.CVE_LLANTA AS INT), LL.NUM_ECONOMICO, LL.UNIDAD, LL.POSICION, M.DESCR, SL.DESCR AS ST_LLANTA, 
                        LL.CVE_ART, COSTO_LLANTA_MN
                        FROM GCLLANTAS LL 
                        LEFT JOIN GCLLANTA_STATUS SL ON SL.CVE_STATUS = LL.STATUS_LLANTA 
                        LEFT JOIN GCMARCAS M ON M.CVE_MARCA = LL.MARCA 
                        WHERE LL.STATUS = 'A' AND LL.STATUS_LLANTA <> '1'
                        ORDER BY TRY_CAST(NUM_ECONOMICO AS INT) DESC"

                    Debug.Print(SQL)

                Case "Llantas"
                    SQL = "SELECT CAST(LL.CVE_LLANTA AS INT), LL.NUM_ECONOMICO, LL.UNIDAD, LL.POSICION, M.DESCR, SL.DESCR AS ST_LLANTA, 
                        LL.CVE_ART, COSTO_LLANTA_MN
                        FROM GCLLANTAS LL 
                        LEFT JOIN GCLLANTA_STATUS SL ON SL.CVE_STATUS = LL.STATUS_LLANTA 
                        LEFT JOIN GCMARCAS M ON M.CVE_MARCA = LL.MARCA 
                        WHERE LL.STATUS = 'A' " & VarCadena & "
                        ORDER BY TRY_CAST(NUM_ECONOMICO AS INT) DESC"

                Case "LlantasStatusPendiente_2"
                    SQL = "SELECT CAST(LL.CVE_LLANTA AS INT), LL.NUM_ECONOMICO, LL.UNIDAD, LL.POSICION, M.DESCR, SL.DESCR AS ST_LLANTA, LL.CVE_ART, 
                        ISNULL(COSTO_LLANTA_MN,0) AS COSTO, STATUS_LLANTA 
                        FROM GCLLANTAS LL 
                        LEFT JOIN GCLLANTA_STATUS SL ON SL.CVE_STATUS = LL.STATUS_LLANTA 
                        LEFT JOIN GCMARCAS M ON M.CVE_MARCA = LL.MARCA 
                        WHERE LL.STATUS = 'A' AND LL.STATUS_LLANTA = 2 ORDER BY TRY_CAST(NUM_ECONOMICO AS INT)"

                Case "Modelo Llanta"
                    SQL = "SELECT CAST(CVE_MODELO AS INT), DESCR FROM GCLLANTA_MODELO WHERE STATUS = 'A' ORDER BY CAST(CVE_MODELO AS INT) DESC"
                Case "Marca" 'MARCA LLANTAS
                    SQL = "SELECT CAST(CVE_MARCA AS INT), DESCR, TIPO FROM GCMARCAS WHERE STATUS = 'A' ORDER BY CAST(CVE_MARCA AS INT)"
                Case "Marca Renovado" 'MARCA LLANTAS
                    SQL = "SELECT CAST(CVE_MARCA AS INT), DESCR, TIPO FROM GCMARCAS_RENOVADO WHERE STATUS = 'A' ORDER BY CAST(CVE_MARCA AS INT)"
                Case "Tipo Llanta"
                    SQL = "SELECT CAST(CVE_TIPO AS INT), DESCR FROM GCLLANTA_TIPO WHERE STATUS = 'A' ORDER BY CAST(CVE_TIPO AS INT)"
                Case "Medidas Llanta" 'GCLLANTA_MEDIDA
                    SQL = "SELECT CAST(CVE_MED AS INT), DESCR FROM GCLLANTA_MEDIDA  WHERE STATUS = 'A' ORDER BY CAST(CVE_MED AS INT)"
                Case "Status Llanta"
                    SQL = "SELECT CVE_STATUS, DESCR FROM GCLLANTA_STATUS WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Deptos"
                    SQL = "SELECT CVE_DEPTO, DESCR FROM GCDEPTOS WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Puestos"
                    SQL = "SELECT CVE_PUESTO, DESCR FROM GCPUESTOS WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Formas de pago"
                    SQL = "SELECT CVE_PAGO, DESCR FROM GCFORMAPAGO WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Bancos"
                    SQL = "SELECT CVE_BANCO, DESCR, RFC FROM GCBANCOS WHERE STATUS = 'A' ORDER BY DESCR"
                Case "Tractor"
                    SQL = "SELECT CVE_TRACTOR, MARCA, MODELO FROM GCTRACTOR WHERE STATUS = 'A'"
                Case "Tipo Unidad"
                    SQL = "SELECT CVE_UNI, DESCR FROM GCTIPO_UNIDAD WHERE STATUS = 'A' ORDER BY CVE_UNI"
                Case "Sucursal"
                    SQL = "SELECT CVE_SUC, DESCR FROM GCSUCURSAL WHERE STATUS = 'A' ORDER BY CVE_SUC"
                Case "Operador"
                    SQL = "SELECT CLAVE, ISNULL(NOMBRE,'') AS NOMB, ISNULL(LICENCIA,'') AS LIC, ISNULL(LIC_VENC,'') AS L_VIG FROM GCOPERADOR WHERE STATUS = 'A' ORDER BY CLAVE"
                Case "OperadorSel"
                    SQL = "SELECT CLAVE, NOMBRE, ISNULL(LICENCIA,'') AS LIC, ISNULL(LIC_VENC,'') AS LIC_VENC 
                        FROM GCOPERADOR O WHERE STATUS = 'A' AND
                        ISNULL((SELECT TOP 1 CVE_ST_UNI FROM GCASIGNACION_VIAJE WHERE CVE_OPER = O.CLAVE AND CVE_ST_UNI <> 5 AND CVE_ST_UNI <> 3),0) IN (0,3,5)
                        ORDER BY CLAVE"
                Case "Marca Unidad"
                    SQL = "SELECT CAST(CVE_MARCA AS INT) AS MARCA, DESCR FROM GCMARCAUNIDAD WHERE STATUS = 'A' ORDER BY CAST(CVE_MARCA AS INT)"
                Case "Unidades"
                    If Var4.Trim.Length > 0 Then
                        SQL = "SELECT CAST(U.CLAVE AS INT), U.CLAVEMONTE AS UNIDAD, T.DESCR AS TIPOUNI, U.PLACAS_MEX, M.DESCR AS MARCA, ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI " &
                            "FROM GCUNIDADES U " &
                            "LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA " &
                            "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                            "WHERE ISNULL(U.STATUS, 'A') = 'A' AND U.CVE_TIPO_UNI = " & Val(Var4) &
                            " ORDER BY U.CLAVEMONTE"
                        Var4 = ""
                    Else
                        SQL = "SELECT CAST(U.CLAVE AS INT), U.CLAVEMONTE, T.DESCR, U.PLACAS_MEX, M.DESCR, ISNULL(U.CVE_TIPO_UNI, 0) AS TIPO_UNI " &
                            "FROM GCUNIDADES U " &
                            "LEFT JOIN GCMARCAUNIDAD M ON M.CVE_MARCA = U.CVE_MARCA " &
                            "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                            "WHERE ISNULL(U.STATUS, 'A') = 'A' ORDER BY U.CLAVEMONTE"
                    End If
                Case "Unidades2"
                    If Var4.Trim.Length > 0 Then
                        SQL = "SELECT U.CLAVE, U.CLAVEMONTE, U.DESCR, U.PLACAS_MEX, U.CVE_TIPO_UNI, 
                            ISNULL(U.CVE_MOT,'') AS CVEMOT, ISNULL(M.DESCR,'') AS DESCR_MOTOR
                            FROM GCUNIDADES U
                            LEFT JOIN GCMOTORES M ON M.CVE_MOT = U.CVE_MOT
                            WHERE ISNULL(U.STATUS, 'A') = 'A' AND U.CVE_TIPO_UNI = " & Val(Var4) & " 
                            ORDER BY CLAVEMONTE"
                    Else
                        SQL = "SELECT U.CLAVE, U.CLAVEMONTE, U.DESCR, U.PLACAS_MEX, U.CVE_TIPO_UNI, U.CVE_MOT, M.DESCR_MOTOR
                            FROM GCUNIDADES U
                            LEFT JOIN GCMOTORES M ON M.CVE_MOT = U.CVE_MOT
                            WHERE ISNULL(U.STATUS, 'A') = 'A' 
                            ORDER BY CLAVEMONTE"
                    End If
                    Debug.Print(SQL)
                Case "Grupo Unidades"
                    SQL = "SELECT CAST(CVE_GPO AS INT), DESCR FROM GCGRUPO_UNI WHERE STATUS = 'A' ORDER BY CAST(CVE_GPO AS INT)"
                Case "Placas Defa"
                    SQL = "SELECT CAST(CVE_PLA AS INT), DESCR FROM GCPLACAS_DEFA WHERE STATUS = 'A' ORDER BY CAST(CVE_PLA AS INT)"
                Case "Servicios2"
                    SQL = "SELECT CVE_SER, DESCR FROM GCSERVICIOS WHERE STATUS = 'A' ORDER BY CVE_SER"
                Case "ServiciosOrdenes"
                    SQL = "SELECT CAST(CVE_SER AS INT), DESCR FROM GCSERVICIOS_MANTE WHERE STATUS = 'A' ORDER BY TRY_PARSE(CVE_SER AS INT)"
                Case "Clasificacion"
                    SQL = "SELECT CVE_CLA, DESCR FROM GCCLASIFIC_SERVICIOS WHERE STATUS = 'A' ORDER BY TRY_PARSE(CVE_CLA AS INT)"
                Case "Gasolinera"
                    SQL = "SELECT CAST(G.CVE_GAS AS INT), G.DESCR, NOMBRE
                        FROM GCGASOLINERAS G
                        LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV
                        WHERE G.STATUS = 'A' ORDER BY CAST(G.CVE_GAS AS INT)"
                Case "GasConci"
                    If Var4.Trim.Length > 0 Then
                        SQL = "SELECT CAST(CVE_GAS AS INT), DESCR FROM GCGASOLINERAS WHERE STATUS = 'A' AND CVE_PROV = '" & Var4 & "' ORDER BY TRY_PARSE(CVE_GAS AS INT)"
                    Else
                        SQL = "SELECT CAST(CVE_GAS AS INT), DESCR FROM GCGASOLINERAS WHERE STATUS = 'A' ORDER BY TRY_PARSE(CVE_GAS AS INT)"
                    End If
                Case "MarcaTipo"
                    SQL = "SELECT CAST(CVE_TIPO AS INT), DESCR FROM GCLLANTA_TIPO WHERE STATUS = 'A' ORDER BY TRY_PARSE(CVE_TIPO AS INT)"
                Case "Valor Declarado"
                    SQL = "SELECT E.CLAVE, E.DESCR, E.IMPORTE " &
                        "FROM GCVALOR_DECLARADO E " &
                        "WHERE E.STATUS = 'A' ORDER BY E.CLAVE"
                Case "Nivel Combustible"
                    SQL = "SELECT CAST(CLAVE AS INT), ID_TABLA, ALTURA, LITROS FROM GCNIVELCOMBUSTIBLE WHERE STATUS = 'A' ORDER BY ID_TABLA"
                Case "Plazas"
                    SQL = "SELECT CLAVE, CIUDAD, MUNICIPIO FROM GCPLAZAS WHERE STATUS = 'A' ORDER BY CLAVE"
                Case "Pedidos"
                    SQL = "SELECT P.CVE_DOC, P.CVE_CON, P.CVE_CLIE, C.NOMBRE, P.CVE_ART, I.DESCR, P.FECHA, P1.CIUDAD AS ORIGEN,
                        P2.CIUDAD AS DESTINO, P.FECHA_CARGA, P.FECHA_DESCARGA
                        FROM GCPEDIDOS P
                        LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CVE_CLIE
                        LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                        LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = P.CVE_ORIGEN
                        LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = P.CVE_DESTINO
                        WHERE P.STATUS = 'A' AND ISNULL(CVE_VIAJE,'') = '' ORDER BY P.FECHAELAB DESC"
                Case "PedidosProg"
                    SQL = "SELECT P.CVE_DOC, C3.NOMBRE, I.DESCR, P.FECHA_CARGA, P.FECHA_DESCARGA, RE.DESCR As RECIBIR_E, EE.DESCR AS RECOGER_E
                        FROM GCPEDIDOSPROG P
                        LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                        LEFT JOIN GCCONTRATO CT ON CT.CVE_CON = P.CVE_CON 
                        LEFT JOIN GCCLIE_OP C3 ON C3.CLAVE = CT.NO_CONTRATO 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN
                        WHERE P.STATUS = 'A' AND ISNULL(CVE_VIAJE,'') = '' AND 
                        NOT EXISTS (SELECT PED_ENLAZADO FROM GCPEDIDOS WHERE PED_ENLAZADO = P.CVE_DOC)
                        ORDER BY P.FECHAELAB DESC"
                Case Else
                    MsgBox("No se encontraron coincidencias " & Proceso)
            End Select
            If SQL.Trim.Length > 0 Then
                da = New SqlDataAdapter(SQL, cnSAE)
                dt = New DataTable ' crear un DataTable
                da.SelectCommand.CommandTimeout = 120

                da.Fill(dt)

                BindingSource1.DataSource = dt
                Fg.DataSource = BindingSource1.DataSource


                Lt.Text = "Registros encontrados " & Fg.Rows.Count - 1
                Select Case Proceso
                    Case "DocPagosComp"
                        'SQL = "SELECT TOP 500 M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.NO_FACTURA, M.DOCTO, M.IMPORTE, NO_PARTIDA
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Documento"
                        Fg(0, 2) = "Cliente"
                        Fg(0, 3) = "Nombre"
                        Fg(0, 4) = "Fecha"
                        Fg(0, 5) = "No. factura"
                        Fg(0, 6) = "Docto"
                        Fg(0, 7) = "Importe"
                        Fg(0, 8) = "No. partida"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 90
                        Fg.Cols(2).Width = 50
                        Fg.Cols(3).Width = 200
                        Fg.Cols(4).Width = 70
                        Fg.Cols(5).Width = 70
                        Fg.Cols(6).Width = 70
                        Fg.Cols(7).Width = 80
                        Fg.Cols(8).Width = 80
                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"
                        Fg.Cols(7).Style = NewStyle2
                    Case "GCDEDUC_OPER"
                        'SQL = "SELECT DO.FOLIO, D.DESCR AS DESCR_DED, DO.DESCR, DO.IMPORTE_PRESTAMO, 
                        'ISNULL((SELECT SUM(IMPORTE) FROM GCLIQ_DEDUCCIONES D WHERE D.CVE_DED = DO.FOLIO),0) AS ABONOS,
                        'Do.IMPORTE_PRESTAMO - ISNULL((SELECT SUM(IMPORTE) FROM GCLIQ_DEDUCCIONES D WHERE D.CVE_DED = DO.FOLIO),0) AS SALDO_ACT,
                        'Do.FECHA 
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Folio"
                        Fg(0, 2) = "Deduccion"
                        Fg(0, 3) = "Descripción"
                        Fg(0, 4) = "Importe prestamo"
                        Fg(0, 5) = "Pago en liq."
                        Fg(0, 6) = "Saldo actual"
                        Fg(0, 7) = "Fecha"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 60
                        Fg.Cols(2).Width = 230
                        Fg.Cols(3).Width = 230
                        Fg.Cols(4).Width = 90
                        Fg.Cols(5).Width = 70
                        Fg.Cols(6).Width = 70
                        Fg.Cols(7).Width = 70
                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"
                        Fg.Cols(4).Style = NewStyle2
                        Fg.Cols(5).Style = NewStyle2
                        Fg.Cols(6).Style = NewStyle2
                        Me.Width = 900
                        Fg.Width = Me.Width - 20
                    Case "Deducciones", "Aseguradoras"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"

                    Case "Evento"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Evento"
                        Fg(0, 2) = "Tabulador"
                        Fg(0, 3) = "Fisico vs ECM"
                        Fg(0, 4) = "RALENTI"
                        Fg(0, 5) = "%Tolerancia"
                        Fg(0, 6) = "%Ralenti"
                        Fg(0, 7) = "Criterio"
                        Fg.Cols(4).Format = "N2"
                        Fg.Cols(5).Format = "N2"

                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 40
                        Fg.Cols(2).Width = 55
                        Fg.Cols(3).Width = 70
                        Fg.Cols(4).Width = 50
                        Fg.Cols(5).Width = 70
                        Fg.Cols(6).Width = 50
                        Fg.Cols(7).Width = 300

                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.TextAlign = TextAlignEnum.CenterCenter

                        Fg.Cols(2).Style = NewStyle2
                        Fg.Cols(3).Style = NewStyle2
                        Fg.Cols(4).Style = NewStyle2
                        Fg.Cols(6).Style = NewStyle2

                        Me.Width = 750
                        Fg.Width = Me.Width - 20
                    Case "Motor"
                        'SQL = "SELECT CVE_MOT, MOTOR, DESCR, CASE 
                        '  WHEN TIPO_VIAJE = 0 THEN 'Full' 
                        '  WHEN TIPO_VIAJE = 1 THEN 'Sencillo'
                        '  WHEN TIPO_VIAJE = 2 THEN 'Full/Sencillo' ELSE '' END AS TIP_VIAJE FROM GCMOTORES ORDER BY CVE_MOT"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Motor"
                        Fg(0, 3) = "Descripción"
                        Fg(0, 4) = "Tipo viaje"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 70
                        Fg.Cols(3).Width = 200
                        Fg.Cols(4).Width = 60
                    Case "TAQ"
                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"

                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "1 Ancho"
                        Fg(0, 3) = "1 Alto"
                        Fg(0, 4) = "1 Profundidad"
                        Fg(0, 5) = "1 Litros"
                        Fg(0, 6) = "2 Ancho"
                        Fg(0, 7) = "2 Alto"
                        Fg(0, 8) = "2 Profundidad"
                        Fg(0, 9) = "2 Litros"

                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 80
                        Fg.Cols(2).Width = 80
                        Fg.Cols(3).Width = 80
                        Fg.Cols(4).Width = 80
                        Fg.Cols(5).Width = 80

                        Fg.Cols(6).Width = 80
                        Fg.Cols(7).Width = 80
                        Fg.Cols(8).Width = 80
                        Fg.Cols(9).Width = 80

                        Fg.Cols(2).Style = NewStyle2
                        Fg.Cols(3).Style = NewStyle2
                        Fg.Cols(4).Style = NewStyle2
                        Fg.Cols(5).Style = NewStyle2

                        Fg.Cols(6).Style = NewStyle2
                        Fg.Cols(7).Style = NewStyle2
                        Fg.Cols(8).Style = NewStyle2
                        Fg.Cols(9).Style = NewStyle2

                    Case "Medicion combustible"
                        'SQL = "SELECT M.CLAVE, M.CLAVEMONTE, M.FECHA, M.SUMA " &
                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"

                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Unidad"
                        Fg(0, 3) = "Fecha"
                        Fg(0, 4) = "Litros"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 80
                        Fg.Cols(2).Width = 80
                        Fg.Cols(3).Width = 90
                        Fg.Cols(4).Width = 100

                        Fg.Cols(4).Style = NewStyle2

                    Case "OT"
                        'SQL = "SELECT CVE_ORD, DESCR, ESTATUS, FECHA, CVE_UNI FROM GCORDEN_TRABAJO_EXT WHERE STATUS <> 'C' ORDER BY CVE_ORD"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Num. orden"
                        Fg(0, 2) = "Estatus"
                        Fg(0, 3) = "Fecha"
                        Fg(0, 4) = "Unidad"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 80
                        Fg.Cols(2).Width = 120
                        Fg.Cols(3).Width = 100
                        Fg.Cols(4).Width = 120
                    Case "Almacenes"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Almacen"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 250
                    Case "RecogerEn", "EntregarEn"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 400
                    Case "CFDI"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Documento"
                        Fg(0, 2) = "Estatus"
                        Fg(0, 3) = "Carta porte"
                        Fg(0, 4) = "Carta porte2"
                        Fg(0, 5) = "Fecha"
                        Fg(0, 6) = "Observaciones"

                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 100
                        Fg.Cols(2).Width = 70
                        Fg.Cols(3).Width = 110
                        Fg.Cols(4).Width = 110
                        Fg.Cols(5).Width = 80
                        Fg.Cols(6).Width = 70

                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                    Case "FACT", "COMP", "FACTURAS"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Documento"
                        Fg(0, 2) = "Cliente"
                        Fg(0, 3) = "Nombre"
                        Fg(0, 4) = "Fecha"
                        Fg(0, 5) = "Importe"
                        Fg(0, 6) = "Doc. sig."
                        Fg(0, 7) = "Tip. doc. sig."
                        Fg.Cols(5).Format = "N2"

                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 100
                        Fg.Cols(2).Width = 70
                        Fg.Cols(3).Width = 300
                        Fg.Cols(4).Width = 70
                        Fg.Cols(5).Width = 80
                        Fg.Cols(6).Width = 70
                        Fg.Cols(7).Width = 70

                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                    Case "Origen"
                    Case "Remision"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Documento"
                        Fg(0, 2) = "Cliente"
                        Fg(0, 3) = "Nombre"
                        Fg(0, 4) = "Fecha"
                        Fg(0, 5) = "Importe"
                        Fg.Cols(5).Format = "N2"

                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 80
                        Fg.Cols(2).Width = 50
                        Fg.Cols(3).Width = 350
                        Fg.Cols(4).Width = 70
                        Fg.Cols(5).Width = 70

                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                    Case "Carta Porte"
                        'CVE_FOLIO, CVE_VIAJE, FECHA_DOC, CVE_ART, ST_CARTA_PORTE
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Folio"
                        Fg(0, 2) = "Viaje"
                        Fg(0, 3) = "Fecha"
                        Fg(0, 4) = "Artículo"
                        Fg(0, 5) = "Descripcion"
                        Fg(0, 6) = "Estatus"

                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 70
                        Fg.Cols(3).Width = 70
                        Fg.Cols(4).Width = 70
                        Fg.Cols(5).Width = 200
                        Fg.Cols(6).Width = 70

                        Me.Width = 600
                        Fg.Width = Me.Width - 30
                    Case "Clientes", "Clie01", "Clie"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Nombre"
                        Fg(0, 3) = "R.F.C."
                        Fg(0, 4) = "Domicilio"
                        Fg(0, 5) = "%Porc., utilidad"
                        Fg(0, 6) = "Porc. o monto"

                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 400
                        Fg.Cols(3).Width = 70
                        Fg.Cols(4).Width = 120
                        Fg.Cols(5).Width = 100
                        Fg.Cols(6).Width = 0

                        Me.Width = 600
                        Fg.Width = Me.Width - 30
                    Case "CLIE"
                        'SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, MUNICIPIO 
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Nombre"
                        Fg(0, 3) = "R.F.C."
                        Fg(0, 4) = "Domicilio"
                        Fg(0, 5) = "Municipio"

                        'Fg.Cols(0).Width = 30
                        'Fg.Cols(1).Width = 70
                        'Fg.Cols(2).Width = 400
                        'Fg.Cols(3).Width = 70
                        'Fg.Cols(4).Width = 120
                        'Fg.Cols(5).Width = 100

                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "3*"
                        Fg.Cols(3).StarWidth = "*"
                        Fg.Cols(4).StarWidth = "2*"
                        Fg.Cols(5).StarWidth = "2*"

                        Me.Width = 800
                        Fg.Width = Me.Width - 30
                    Case "Prov"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Nombre"
                        Fg(0, 3) = "R.F.C."
                        Fg(0, 4) = "Domicilio"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 400
                        Fg.Cols(3).Width = 70
                        Fg.Cols(4).Width = 120

                        Me.Width = 600
                        Fg.Width = Me.Width - 30
                    Case "Modelo", "Modelo Llanta", "Medidas Llanta", "Origen", "Destino", "Incidencias", "GCSERVICIOS_MANTE", "Estados"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 400
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"

                        Me.Width = 500
                        Fg.Width = Me.Width - 30
                    Case "Modelo Renovado", "Status", "GCASEGURADORAS"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                    Case "Marca"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 3) = "Nombre"
                        Fg(0, 3) = "Tipo"

                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "*"

                        Me.Width = 450
                        Fg.Width = Me.Width - 30
                    'Dim c As Column = Fg.Cols("Importe")
                    'c.DataType = GetType(Decimal)
                    'c.Format = "###,##0.00"

                    Case "Marca Renovado"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                    Case "Tipo Llanta", "MarcaTipo"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                    Case "Status Llanta"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                    Case "Deptos"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                    Case "Operador", "OperadorSel"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Nombre"
                        Fg(0, 3) = "Licencia"
                        Fg(0, 4) = "Vigencia"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 250
                        Fg.Cols(3).Width = 90
                        Fg.Cols(4).Width = 90
                        'SELECT CLAVE, NOMBRE, LICENCIA, LIC_VENC
                    Case "Pustos", "Tipo Unidad", "Sucursal", "Marca Unidad", "Modelo"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                    Case "Formas de pago"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                    Case "Zona", "Pais", "Vend", "Listaprec"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(2).Width = 400
                    Case "Unidad"
                        ''SQL = "SELECT U.CLAVE AS 'Clave', U.CLAVEMONTE AS 'Unidad', U.DESCR AS 'Tipo unidad', U.PLACAS_MEX as 'Placas', M.DESCR as 'Marca'" &
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Unidad"
                        Fg(0, 3) = "Tipo unidad"
                        Fg(0, 4) = "Placas"
                        Fg(0, 5) = "Marca"
                        Fg(0, 6) = "Tipo unidad"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 90
                        Fg.Cols(3).Width = 220
                        Fg.Cols(4).Width = 100
                        Fg.Cols(5).Width = 80
                        Fg.Cols(6).Width = 80
                    Case "Unidades2"
                        'SELECT CLAVE, CLAVEMONTE, DESCR, PLACAS_MEX, CVE_TIPO_UNI
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Clave Monte."
                        Fg(0, 3) = "Unidad"
                        Fg(0, 4) = "Placas"
                        Fg(0, 5) = "Tipo unidad"
                        Fg(0, 6) = "Motor"
                        Fg(0, 7) = "Nombre motor"
                        'SELECT U.CLAVE, U.CLAVEMONTE, U.DESCR, U.PLACAS_MEX, U.CVE_TIPO_UNI, U.CVE_MOT, M.DESCR_MOTOR
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 45
                        Fg.Cols(2).Width = 80
                        Fg.Cols(3).Width = 110
                        Fg.Cols(4).Width = 20
                        Fg.Cols(5).Width = 90
                        Fg.Cols(6).Width = 70
                        Fg.Cols(7).Width = 170
                        Fg.AutoSizeCols()
                    Case "Bancos"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "R.F.C."
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "*"
                        'SQL = "SELECT CVE_ART, DESCR, (SELECT TOP 1 CVE_ALTER FROM GCCVES_ALTER A WHERE CVE_ART = I.CVE_ART) AS NUM_PARTE, EXIST " &
                        '"FROM I WHERE STATUS = 'A' AND TIPO_ELE <> 'K' ORDER BY DESCR"
                    Case "InveSAE"
                        'SQL = "SELECT I.CVE_ART, DESCR, (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1,
                        '(SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA
                        'From INVE" & Empresa & " I WHERE I.STATUS = 'A' AND TIPO_ELE = 'S' AND CVE_PRODSERV = '78101802' ORDER BY CVE_ART"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Precio"
                        Fg(0, 4) = "Alterna"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 120
                        Fg.Cols(2).Width = 300
                        Fg.Cols(3).Width = 90
                        Fg.Cols(4).Width = 100
                        Me.Width = 800
                        Fg.Width = Me.Width - 30

                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"
                        Fg.Cols(3).Style = NewStyle2
                    Case "InveLiq"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Precio"
                        Fg(0, 4) = "Alterna"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 120
                        Fg.Cols(2).Width = 300
                        Fg.Cols(3).Width = 90
                        Fg.Cols(4).Width = 100
                        Me.Width = 600
                        Fg.Width = Me.Width - 30
                    Case "InveP", "InveS", "GCINVER", "InvenTabRutas"
                        'SQL = "SELECT I.CVE_ART, DESCR, PRECIO, (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, 
                        'EXIST, TIPO_ELE, ISNULL(COSTO_PROM,0) AS C_PROM
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Precio"
                        Fg(0, 4) = "Alterna"
                        Fg(0, 5) = "Exist."
                        Fg(0, 6) = "Tipo prod."
                        Fg(0, 7) = "Costo prom"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 120
                        Fg.Cols(2).Width = 300
                        Fg.Cols(3).Width = 90
                        Fg.Cols(4).Width = 100
                        Fg.Cols(5).Width = 90
                        Fg.Cols(6).Width = 90
                        Fg.Cols(7).Width = 90
                        Me.Width = 800
                        Fg.Width = Me.Width - 30

                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"
                        Fg.Cols(3).Style = NewStyle2
                        Fg.Cols(5).Style = NewStyle2
                        Fg.Cols(7).Style = NewStyle2
                    Case "Articulo", "ArticulosLlantas"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Exist."
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "*"
                        Me.Width = 600
                        Fg.Width = Me.Width - 30

                    Case "InveR", "InvenRS", "InvenRP", "Inventario", "GCINVER"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "No. parte"
                        Fg(0, 4) = "Exist."
                        Fg(0, 5) = "Tipo"
                        Fg(0, 6) = "Estatus"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 120
                        Fg.Cols(2).Width = 300
                        Fg.Cols(3).Width = 100
                        Fg.Cols(4).Width = 100
                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                    Case "ConcCxC", "Tipo de Cobro", "CONM", "ConcCxP", "ConcCxPRef"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                    Case "ConcSAT"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Concepto"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "*"
                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                    Case "GCLLANTAS_CONM"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Estatus llanta"
                        Fg(0, 4) = "Entrada/Salida"
                        Fg(0, 5) = "Cve. status"

                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 250
                        Fg.Cols(3).Width = 200
                        Fg.Cols(4).Width = 90
                        Fg.Cols(5).Width = 70
                        Me.Width = 700
                        Fg.Width = Me.Width - 30

                    Case "Grupo Unidades", "Placas Defa", "Servicios", "Servicios2", "Clasificacion",
                         "Numero de Viaje", "GCPRODUCTOS", "Productos", "ServiciosOrdenes"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                    Case "Tractor"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Marca"
                        Fg(0, 3) = "Modelo"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "*"
                    Case "GCConc"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Clasificación"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "*"
                    Case "Gasolinera"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Proveedor"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "*"
                        Me.Width = 800
                        Fg.Width = Me.Width - 30
                    Case "Lineas", "Lineas", "Mecanicos", "AnticipoCat", "GasConci"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                    Case "Moneda"
                        'NUM_MONED, DESCR, CVE_MONED, TCAMBIO
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Cve.moned"
                        Fg(0, 4) = "Tipo cambio"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 300
                        Fg.Cols(3).Width = 70
                        Fg.Cols(4).Width = 70
                    Case "Fallas"
                        'SQL = "SELECT P.CVE_FALLA, U.DESCR, P.DESCR_FALLA, F.CVE_ORD AS 'Orden asignada' 
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Unidad"
                        Fg(0, 3) = "Descripción"
                        Fg(0, 4) = "Orden asignada"
                        Fg(0, 5) = "Unidadad"
                        Fg(0, 6) = "Partida"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 50
                        Fg.Cols(2).Width = 110
                        Fg.Cols(3).Width = 400
                        Fg.Cols(4).Width = 40
                        Fg.Cols(5).Width = 50
                        Fg.Cols(6).Width = 50
                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                        Fg.Rows(0).Style = NewStyle1
                        Fg.Cols(2).Style = NewStyle1
                        Fg.Cols(3).Style = NewStyle1
                        For i As Integer = 0 To Fg.Rows.Count - 1
                            Fg.Rows(i).Height = 50
                            'Fg.AutoSizeRow(i)
                        Next i
                    Case "Viajes"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Num."
                        Fg(0, 2) = "Clave"
                        Fg(0, 3) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "*"
                        Fg.Cols(3).StarWidth = "3*"
                    Case "AnticipoViaje"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Fecha"
                        Fg(0, 3) = "Descripción"
                        Fg(0, 4) = "Importe"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 35
                        Fg.Cols(2).Width = 70
                        Fg.Cols(3).Width = 300
                        Fg.Cols(4).Width = 70
                    Case "Tip Tercero", "Tip Opera", "AnticipoViaje", "Tipo Poliza", "Equipo Asegurado"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                    Case "Nivel Combustible"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "ID"
                        Fg(0, 3) = "Altura"
                        Fg(0, 4) = "Litros"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 80
                        Fg.Cols(2).Width = 80
                        Fg.Cols(3).Width = 80
                        Fg.Cols(4).Width = 80

                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"
                        Fg.Cols(4).Style = NewStyle2

                        Me.Width = 400
                        Fg.Width = Me.Width - 30
                    Case "Contrato", "ContratoTab"
                        'SQL = "SELECT T.CVE_CON AS 'Clave', (SELECT NOMBRE FROM GCCLIE_OP WHERE CLAVE = T.NO_CONTRATO) AS 'Nombre contrato', " &
                        '"(SELECT NOMBRE FROM GCCLIE_OP WHERE CLAVE = T.CLAVE_O) AS 'Nombre contrato', " &
                        '"(SELECT NOMBRE FROM GCCLIE_OP WHERE CLAVE = T.CLAVE_D) AS 'Nombre destino' " &
                        '"FROM GCCONTRATO T " &
                        '"WHERE T.STATUS = 'A' ORDER BY CAST(T.CVE_CON AS INT) DESC"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Cve. Cont."
                        Fg(0, 2) = "Nombre contrato"
                        Fg(0, 3) = "Nombre origen"
                        Fg(0, 4) = "Nombre destino"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 220
                        Fg.Cols(3).Width = 220
                        Fg.Cols(4).Width = 220
                        'Fg.Cols(5).Width = 50
                        'Fg.Cols(6).Width = 200
                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                    Case "Rutas"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Cve. ruta"
                        Fg(0, 2) = "Origen"
                        Fg(0, 3) = "Destino"
                        Fg.Cols(0).Width = 20
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 150
                        Fg.Cols(3).Width = 150
                        Me.Width = 700
                        Fg.Width = Me.Width - 30
                    Case "Llantas", "LlantasStatusPendiente_2", "LlantasNoAsignadas"
                        'LL.CVE_LLANTA, LL.NUM_ECONOMICO, LL.UNIDAD, LL.POSICION, M.DESCR
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Cve. llanta"
                        Fg(0, 2) = "Num. Económico"
                        Fg(0, 3) = "Unidad"
                        Fg(0, 4) = "Posicion"
                        Fg(0, 5) = "Marca"
                        Fg(0, 6) = "Estatus"
                        Fg(0, 7) = "Artículo"
                        Fg(0, 8) = "Costo"
                        Fg(0, 9) = "Estatus llanta"

                        Fg.Cols(9).Visible = False

                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "*"
                        Fg.Cols(3).StarWidth = "*"
                        Fg.Cols(4).StarWidth = "*"
                        Fg.Cols(5).StarWidth = "2*"
                        Fg.Cols(6).StarWidth = "2*"
                        Fg.Cols(7).StarWidth = "*"
                        Fg.Cols(8).StarWidth = "*"

                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"
                        Fg.Cols(8S).Style = NewStyle2

                        Me.Width = 900
                        Fg.Width = Me.Width - 10
                    Case "Valor Declarado"
                        '"SELECT E.CLAVE, E.CLIENTE, E.NOMBRE, E.CVE_ART, P.DESCR, E.IMPORTE

                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Decripción"
                        Fg(0, 3) = "Importe"
                        Fg.Cols(0).Width = 20

                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "*"

                    Case "IAVE"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Descripción"
                        Fg(0, 3) = "Vigencia"
                        Fg.Cols(0).Width = 35


                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "*"

                    Case "GCPOLIZAS"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "IDPoliza"
                        Fg(0, 2) = "Folio"
                        Fg(0, 3) = "Tipo poliza"
                        Fg(0, 4) = "Equipo Asegurado"
                        Fg(0, 5) = "Proveedor"
                        Fg(0, 6) = "Tipo cobertura"

                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 60
                        Fg.Cols(3).Width = 100
                        Fg.Cols(4).Width = 100
                        Fg.Cols(5).Width = 100
                        Fg.Cols(6).Width = 100
                    Case "Tab Rutas"
                        'SQL = "SELECT D.CVE_RUTA, FECHA, (D.ORIGEN + ' ' + D.DESTINO) AS RUTA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, " & 
                        '"D.COSTO_CASETAS, D.KM_RECORRIDOS, D.EJES " &
                        '"FROM GCDETALLE_RUTAS D " &
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Fecha"
                        Fg(0, 3) = "Ruta"
                        Fg(0, 4) = "Tipo viaje"
                        Fg(0, 5) = "Costo casetas"
                        Fg(0, 6) = "Km. Recorridos"
                        Fg(0, 7) = "Ejes"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 40
                        Fg.Cols(2).Width = 70
                        Fg.Cols(3).Width = 270
                        Fg.Cols(4).Width = 65
                        Fg.Cols(5).Width = 70
                        Fg.Cols(6).Width = 70
                        Fg.Cols(7).Width = 60
                        For i As Integer = 1 To Fg.Rows.Count - 1
                            Fg.Rows(i).Style = NewStyle1
                        Next i
                        Me.Width = 800
                        Fg.Width = Me.Width - 30
                        Fg.AutoSizeRows()
                    Case "Detalle Rutas"
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Origen"
                        Fg(0, 3) = "Destino"
                        Fg(0, 4) = "Km recorridos"
                        Fg(0, 5) = "Costo casetas"
                        Fg(0, 6) = "Ejes"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 70
                        Fg.Cols(2).Width = 300
                        Fg.Cols(3).Width = 90
                        Fg.Cols(4).Width = 90
                        Fg.Cols(5).Width = 50
                        Fg.Cols(6).Width = 0
                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"
                        Fg.Cols(4).Style = NewStyle2
                        Fg.Cols(5).Style = NewStyle2
                        Me.Width = 750
                        Fg.Width = Me.Width - 30
                        Fg.AutoSizeRows()
                    Case "Pedidos", "PedidosProg"
                        'SQL = "SELECT P.CVE_DOC, P.CVE_CLIE, C.NOMBRE, P.CVE_ART, I.DESCR, P.FECHA, P1.CIUDAD AS ORIGEN, " &
                        '"P2.CIUDAD AS DESTINO, P.FECHA_CARGA, P.FECHA_DESCARGA " &
                        '"FROM GCPEDIDOS P " &
                        '"LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CVE_CLIE " &
                        '"LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART " &
                        '"LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = P.CVE_ORIGEN " &
                        '"LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = P.CVE_DESTINO " &
                        '"WHERE P.STATUS = 'A' ORDER BY P.FECHAELAB DESC"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Documento"
                        Fg(0, 2) = "Nombre"
                        Fg(0, 3) = "Decripcion"
                        Fg(0, 4) = "Fecha carga"
                        Fg(0, 5) = "Fecha descarga"
                        Fg(0, 6) = "Origen"
                        Fg(0, 7) = "Destino"

                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 100
                        Fg.Cols(2).Width = 350
                        Fg.Cols(3).Width = 250
                        Fg.Cols(4).Width = 90
                        Fg.Cols(5).Width = 90
                        Fg.Cols(6).Width = 120
                        Fg.Cols(7).Width = 120
                        Me.Width = 1150
                        Fg.Width = Me.Width - 30


                        Fg.AutoSizeCols()
                    Case "FACTG"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Documento"
                        Fg(0, 2) = "Clave"
                        Fg(0, 3) = "Nombre"
                        Fg(0, 4) = "Fecha"
                        Fg(0, 5) = "Importe"
                        Fg(0, 6) = "No. Factura"
                        Fg(0, 7) = "Docto"
                        Fg(0, 8) = "Concepto"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 100
                        Fg.Cols(2).Width = 50
                        Fg.Cols(3).Width = 220
                        Fg.Cols(4).Width = 70
                        Fg.Cols(5).Width = 80
                        Fg.Cols(6).Width = 90
                        Fg.Cols(7).Width = 90
                        Fg.Cols(8).Width = 190

                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"

                        Fg.Cols(5).Style = NewStyle2

                        Me.Width = 950
                        Fg.Width = Me.Width - 30
                    Case "ClieDocTo", "ProvDocTo"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Documento"
                        Fg(0, 2) = "Nombre"
                        Fg(0, 3) = "Fecha"
                        Fg(0, 4) = "No. Factura"
                        Fg(0, 5) = "Importe"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 100
                        Fg.Cols(2).Width = 220
                        Fg.Cols(3).Width = 70
                        Fg.Cols(4).Width = 70
                        Fg.Cols(5).Width = 90

                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"

                        Fg.Cols(5).Style = NewStyle2
                        Me.Width = 750
                        Fg.Width = Me.Width - 30
                    Case "ClieDocSaldos2"
                        'SQL = "SELECT M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,
                        'ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND 
                        'm.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) + 
                        '(SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM CUEN_DET" & Empresa & " C3 
                        'WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1) AS SUMA_CUENDET,
                        'm.IMPORTE, M.IMPORTE + 
                        'ISNULL((SELECT SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " C4 WHERE REFER = M.REFER AND CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO AND NUM_CARGO = M.NUM_CARGO),0),
                        'm.DOCTO, M.NUM_CARGO

                        Fg(0, 0) = ""
                        Fg(0, 1) = "Documento"
                        Fg(0, 2) = "Clave"
                        Fg(0, 3) = "Nombre"
                        Fg(0, 4) = "Fecha"
                        Fg(0, 5) = "Fecha venc."
                        Fg(0, 6) = "No. Factura"
                        Fg(0, 7) = "Abonos"
                        Fg(0, 8) = "Importe"
                        Fg(0, 9) = "Saldo"
                        Fg(0, 10) = "Docto"
                        Fg(0, 11) = "Num. cargo"
                        Fg(0, 12) = "Num. cpto."
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 100
                        Fg.Cols(2).Width = 50
                        Fg.Cols(3).Width = 220
                        Fg.Cols(4).Width = 70
                        Fg.Cols(5).Width = 70
                        Fg.Cols(6).Width = 90
                        Fg.Cols(7).Width = 90
                        Fg.Cols(8).Width = 90
                        Fg.Cols(9).Width = 90
                        Fg.Cols(10).Width = 50
                        Fg.Cols(11).Width = 50
                        Fg.Cols(12).Width = 50
                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"

                        Fg.Cols(7).Style = NewStyle2
                        Fg.Cols(8).Style = NewStyle2
                        Fg.Cols(9).Style = NewStyle2
                        Me.Width = 950
                        Fg.Width = Me.Width - 30
                    Case "ProvDocSaldos", "PagoComplemento", "ClieDocSaldos"
                        'SQL = "SELECT M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,
                        'ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND 
                        'm.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) AS SUMA_CUENDET,
                        'm.IMPORTE, M.DOCTO, M.NUM_CARGO

                        Fg(0, 0) = ""
                        Fg(0, 1) = "Documento"
                        Fg(0, 2) = "Clave"
                        Fg(0, 3) = "Nombre"
                        Fg(0, 4) = "Fecha"
                        Fg(0, 5) = "Fecha venc."
                        Fg(0, 6) = "No. Factura"
                        Fg(0, 7) = "Abonos"
                        Fg(0, 8) = "Importe"
                        Fg(0, 9) = "Docto"
                        Fg(0, 10) = "Num. cargo"

                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 100
                        Fg.Cols(2).Width = 50
                        Fg.Cols(3).Width = 220
                        Fg.Cols(4).Width = 70
                        Fg.Cols(5).Width = 70
                        Fg.Cols(6).Width = 90
                        Fg.Cols(7).Width = 90
                        Fg.Cols(8).Width = 90
                        Fg.Cols(9).Width = 90
                        Fg.Cols(10).Width = 50

                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"

                        Fg.Cols(7).Style = NewStyle2
                        Fg.Cols(8).Style = NewStyle2

                        Me.Width = 950
                        Fg.Width = Me.Width - 30
                    Case "Plazas"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Ciudad"
                        Fg(0, 3) = "municipio"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).StarWidth = "*"
                        Fg.Cols(2).StarWidth = "2*"
                        Fg.Cols(3).StarWidth = "2*"


                    Case "Cliente operativo"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Nombre"
                        Fg(0, 3) = "Plaza"
                        Fg(0, 4) = "Domicilio"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 60
                        Fg.Cols(2).Width = 200
                        Fg.Cols(3).Width = 200
                        Fg.Cols(4).Width = 100
                        Fg.AutoSizeRows()
                        Me.Width = 650
                        Fg.Width = Me.Width - 30
                    Case "Consulta Bajas Viajes"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Clave"
                        Fg(0, 2) = "Estatus"
                        Fg(0, 3) = "Fecha"
                        Fg(0, 4) = "Subtotal"
                        Fg(0, 5) = "IVA"
                        Fg(0, 6) = "Retencion"
                        Fg(0, 7) = "Neto"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 60
                        Fg.Cols(2).Width = 60
                        Fg.Cols(3).Width = 80
                        Fg.Cols(4).Width = 90
                        Fg.Cols(5).Width = 90
                        Fg.Cols(6).Width = 90
                        Fg.Cols(7).Width = 90
                        Fg.AutoSizeRows()
                    Case "Asignacion Viajes bueno", "Asignacion Viajes bueno2"
                        Me.Width = 1200
                        Fg.Width = Me.Width - 5
                        Fg.Rows(0).Height = 50
                        If ESCENARIO = 3 Then

                            Fg(0, 0) = ""
                            Fg(0, 1) = "Viaje"
                            Fg(0, 2) = "Tipo facturación"
                            Fg(0, 3) = "Unidad"
                            Fg(0, 4) = "Fecha"
                            Fg(0, 5) = "Tipo unidad"
                            Fg(0, 6) = "Importe"
                            Fg(0, 7) = "Abonos"
                            Fg(0, 8) = "Saldo"
                            Fg(0, 9) = "Operador"
                            Fg(0, 10) = "Origen"
                            Fg(0, 11) = "Destino"
                            Fg.Cols(1).StarWidth = "*"
                            Fg.Cols(2).StarWidth = "*"
                            Fg.Cols(3).StarWidth = "*"
                            Fg.Cols(4).StarWidth = "*"
                            Fg.Cols(5).StarWidth = "*"
                            Fg.Cols(6).StarWidth = "*"
                            Fg.Cols(7).StarWidth = "*"
                            Fg.Cols(8).StarWidth = "*"
                            Fg.Cols(9).StarWidth = "2*"
                            Fg.Cols(10).StarWidth = "2*"
                            Fg.Cols(11).StarWidth = "2*"
                        Else
                            Fg(0, 0) = ""
                            Fg(0, 1) = "Viaje"
                            Fg(0, 2) = "Tipo facturación"
                            Fg(0, 3) = "Unidad"
                            Fg(0, 4) = "Fecha"
                            Fg(0, 5) = "Tipo unidad"
                            Fg(0, 6) = "Estatus viaje"
                            Fg(0, 7) = "Operador"
                            Fg(0, 8) = "Origen"
                            Fg(0, 9) = "Destino"
                            Fg.Cols(1).StarWidth = "*"
                            Fg.Cols(2).StarWidth = "*"
                            Fg.Cols(3).StarWidth = "*"
                            Fg.Cols(4).StarWidth = "*"
                            Fg.Cols(5).StarWidth = "*"
                            Fg.Cols(6).StarWidth = "*"
                            Fg.Cols(7).StarWidth = "2*"
                            Fg.Cols(8).StarWidth = "2*"
                            Fg.Cols(9).StarWidth = "2*"
                        End If
                        Dim NewStyle2 As CellStyle
                        NewStyle2 = Fg.Styles.Add("NewStyle2")
                        NewStyle2.Format = "###,###,##0.00"

                        Fg.Cols(6).Style = NewStyle2
                        Fg.Cols(7).Style = NewStyle2
                        Fg.Cols(8).Style = NewStyle2

                        Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
                        Fg.Styles.Fixed.WordWrap = True

                    Case "Asignacion viajes", "Asignacion viajes Liq", "Asignacion viajes todos"
                        '{SQL = "SELECT TOP 100 A.CVE_VIAJE, U.CLAVEMONTE, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, " &
                        '"(CASE A.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, O.NOMBRE, " &
                        '"(CASE WHEN ISNULL(P1.CIUDAD,'') = '' THEN A.ENTREGAR_EN ELSE ISNULL(P1.CIUDAD,'') END) AS DESCR_ORIGEN, " &
                        '"(CASE WHEN ISNULL(P2.CIUDAD,'') = '' THEN A.RECOGER_EN ELSE ISNULL(P2.CIUDAD,'') END) AS DESCR_DESTINO, " &
                        '"S.DESCR " &
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Viaje"
                        Fg(0, 2) = "Unidad"
                        Fg(0, 3) = "Fecha"
                        Fg(0, 4) = "Tipo unidad"
                        Fg(0, 5) = "Tipo viaje"
                        Fg(0, 6) = "Nombre"
                        Fg(0, 7) = "Origen"
                        Fg(0, 8) = "Destino"
                        Fg(0, 9) = "Estatus"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 60
                        Fg.Cols(2).Width = 60
                        Fg.Cols(3).Width = 70
                        Fg.Cols(4).Width = 90
                        Fg.Cols(5).Width = 90
                        Fg.Cols(6).Width = 200
                        Fg.Cols(7).Width = 150
                        Fg.Cols(8).Width = 150
                        Fg.Cols(9).Width = 60
                        Fg.AutoSizeRows()
                        Me.Width = 750
                        Fg.Width = Me.Width - 30
                    Case "Usuario"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Usuario"
                        Fg(0, 2) = "Nombre"
                        Fg.Cols(0).Width = 30
                        Fg.Cols(1).Width = 80
                        Fg.Cols(2).Width = 250
                        Fg.AutoSizeRows()
                    Case "CuentaOrdenante"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Cuenta bancaria"
                        Fg(0, 2) = "RFC banco"
                        Fg(0, 3) = "Nombre del banco"
                        Fg(0, 4) = "Clave banco"
                        Fg(0, 5) = "CLABE"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 110
                        Fg.Cols(2).Width = 90
                        Fg.Cols(3).Width = 220
                        Fg.Cols(4).Width = 90
                        Fg.Cols(5).Width = 90
                    Case "CuentaBeneficiaria"
                        Fg(0, 0) = ""
                        Fg(0, 1) = "Cuenta bancaria"
                        Fg(0, 2) = "RFC banco"
                        Fg(0, 3) = "Nombre del banco"
                        Fg(0, 4) = "Clave banco"
                        Fg(0, 5) = "CLABE"
                        Fg.Cols(0).Width = 35
                        Fg.Cols(1).Width = 110
                        Fg.Cols(2).Width = 90
                        Fg.Cols(3).Width = 220
                        Fg.Cols(4).Width = 90
                        Fg.Cols(5).Width = 90
                End Select
            Else
                Me.Close()
            End If

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            'MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
        Try
            If Fg.Rows.Count = 1 Then
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Select Case Proceso
                    Case "Servicios"
                        MsgBox("No se encontraron servicios en inventario")
                    Case "InvenTabRutas"
                        MsgBox("No se encontraron artículos en la linea " & Var11)
                    Case "ArticulosLlantas"
                        MsgBox("No se encontraron artículos, por favor asigne los almacenes de llantas en Configuración-Inventario-llantas")
                    Case Else
                        If Proceso = "GCDEDUC_OPER" Then
                            MsgBox("No se encontraron deducciones del operador")
                        Else
                            If Proceso = "GCDEDUC_OPER" Then
                                MsgBox("No se encontraron registros o ya fueron enlazados")
                            Else
                                MsgBox("No se encontraron registros")
                            End If
                        End If
                End Select

                NumSelIte = 0
                Me.Close()
                Return
            End If
        Catch ex As Exception
        End Try

        Try
            If Var15 = "Busqueda" Then
                tBox.Select()
            End If
        Catch ex As Exception
        End Try

        Me.CenterToScreen()
    End Sub
    Private Sub TBox_KeyDown(sender As Object, e As KeyEventArgs) Handles tBox.KeyDown
        Try
            If e.KeyCode = Keys.Down Then
                Fg.Focus()
                Return
            End If
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                TBox_TextChanged(Nothing, Nothing)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub
    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            SQL = ""
            Select Case Proceso
                Case "Abonos viajes"
                    SQL = "CVE_DOC LIKE '" & tBox.Text & "'"

                    BindingSource1.Sort = "CVE_DOC"
                Case "DocPagosComp"
                    SQL = "(M.REFER LIKE '%" & tBox.Text & "%' OR M.CVE_CLIE LIKE '%" & tBox.Text & "%' OR 
                        P.NOMBRE LIKE '%" & tBox.Text & "%' OR M.NO_FACTURA LIKE '%" & tBox.Text & "%' OR 
                        M.DOCTO LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "FECHAELAB DESC"
                Case "CuentaOrdenante", "CuentaBeneficiaria"
                    SQL = "(CUENTA_BANCARIA LIKE '%" & tBox.Text & "%' OR RFC_BANCO LIKE '%" & tBox.Text & "%' OR 
                        NOMBRE_BANCO Like '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "NOMBRE_BANCO"
                Case "Unidad"
                    'SELECT U.CLAVE, U.CLAVEMONTE, U.DESCR, U.PLACAS_MEX, M.DESCR, T.DESCR
                    SQL = "(CLAVEMONTE LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%' OR 
                        PLACAS_MEX Like '%" & tBox.Text & "%' OR MARCA LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CLAVEMONTE"
                Case "GCDEDUC_OPER"
                    'SELECT DO.FOLIO, D.DESCR AS DESCR_DED, DO.DESCR, DO.IMPORTE_PRESTAMO, DO.SALDO, DO.PAGO_EN_LIQ, DO.SALDO_ACTUAL 
                    SQL = "(D.DESCR LIKE '%" & tBox.Text & "%' OR DO.DESCR LIKE '%" & tBox.Text & "%')"
                Case "Deducciones"
                    SQL = "(DESCR LIKE '%" & tBox.Text.ToUpper & "%')"
                Case "Aseguradoras"
                    SQL = "(CLAVE LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                Case "Evento"
                    SQL = "(CRITERIO LIKE '%" & tBox.Text & "%')"
                Case "Motor"
                    SQL = "(MOTOR LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                Case "Medicion combustible"
                    'SQL = "SELECT M.CLAVE, M.CLAVEMONTE, M.FECHA, M.SUMA " &
                    SQL = "(CLAVE LIKE '%" & tBox.Text & "%' OR CLAVEMONTE LIKE '%" & tBox.Text & "%')"
                Case "OT"
                    SQL = "(CVE_UNI LIKE '%" & tBox.Text & "%')"
                Case "Almacenes"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                Case "RecogerEn", "EntregarEn"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    'BindingSource1.Sort = "CVEREG"
                Case "FACT"
                    SQL = "(CVE_DOC LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%')"
                Case "CFDI"
                    SQL = "(FACTURA LIKE '%" & tBox.Text & "%' OR DOCUMENT LIKE '%" & tBox.Text & "%' OR 
                        DOCUMENT2 LIKE '%" & tBox.Text & "%')"
                Case "FACTURAS"
                    SQL = "(CVE_DOC LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR 
                            CLAVE LIKE '%" & tBox.Text & "%' OR DOCSIG LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_DOC"
                Case "COMP"
                    SQL = "(CVE_DOC LIKE '%" & tBox.Text & "%' OR NOMB LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_DOC"
                Case "Usuario"
                    SQL = "(USUARIO '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%')"
                Case "Status"
                    SQL = "(CVE_STA '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                Case "Rutas"
                    SQL = "(ORIGEN LIKE '%" & tBox.Text & "%' OR DESTINO LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "ORIGEN"
                Case "Contrato", "ContratoTab"
                    'SQL = "SELECT T.CVE_CON, P1.NOMBRE AS NOMBRE1, P2.NOMBRE AS NOMBRE2, P3.NOMBRE As NOMBRE3
                    'From GCCONTRATO T
                    'L'eft JOIN GCCLIE_OP P1 ON P1.CLAVE = T.NO_CONTRATO
                    'Left JOIN GCCLIE_OP P2 ON P2.CLAVE = T.CLAVE_O
                    'Left JOIN GCCLIE_OP P3 ON P3.CLAVE = T.CLAVE_D
                    'Where T.STATUS = 'A' ORDER BY CAST(T.CVE_CON AS INT) DESC"

                    SQL = "(CVE_CON LIKE '%" & tBox.Text & "%' OR NOMBRE1 LIKE '%" & tBox.Text & "%' OR 
                           NOMBRE2 LIKE '%" & tBox.Text & "%'  OR NOMBRE3 LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_CON"
                Case "Remision"
                    SQL = "(CVE_DOC LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "AnticipoViaje", "AnticipoViaje", "FormaDescuento"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "GCConc"
                    SQL = "CAST(CVE_GAS as VARCHAR(10)) LIKE '%" & tBox.Text & "%' or DESCR LIKE '%" & tBox.Text & "%' or CLASIFIC LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "DESCR"
                Case "AnticipoCat"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Viajes"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Tip Tercero"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Tip Opera"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Clientes", "Clie01", "Clie", "CLIE"
                    'SQL = "SELECT CLAVE, NOMBRE, RFC, CALLE, ISNULL(CAMPLIB5,0) AS LIB5, ISNULL(CAMPLIB6,0) AS LIB6
                    'From CLIE" & Empresa & " C
                    'Left JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = C.CLAVE
                    'WHERE C.STATUS = 'A' ORDER BY CLAVE"
                    SQL = "(CLAVE LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CLAVE"
                Case "Prov"
                    SQL = "(CLAVE LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "NOMBRE"
                Case "Modelo"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Modelo Renovado", "Modelo Llanta"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Marca"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Marca Renovado"
                    SQL = "(CVE_MARCA LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Tipo Llanta", "MarcaTipo"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Llantas", "LlantasStatusPendiente_2", "LlantasNoAsignadas"
                    '"SELECT CAST(LL.CVE_LLANTA AS INT), LL.NUM_ECONOMICO, LL.UNIDAD, LL.POSICION, M.DESCR, SL.DESCR AS ST_LLANTA
                    SQL = "(NUM_ECONOMICO LIKE '%" & tBox.Text & "%' OR UNIDAD LIKE '%" & tBox.Text & "%' OR " &
                        "DESCR Like '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "NUM_ECONOMICO"
                Case "Status Llanta"
                    SQL = "CVE_STATUS LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "DESCR"
                Case "Deptos"
                    SQL = "(CVE_DEPTO LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Puestos"
                    SQL = "(CVE_PUESTO LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Formas de pago"
                    SQL = "(CVE_PAGO LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%' )"
                    BindingSource1.Sort = "DESCR"
                Case "Bancos"
                    SQL = "(CVE_BANCO LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%' )"
                    BindingSource1.Sort = "DESCR"
                Case "Tipo Unidad"
                    SQL = "(CVE_UNI LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Sucursal"
                    SQL = "(CVE_SUC LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Operador", "OperadorSel"
                    'SELECT CLAVE, ISNULL(NOMBRE,'') AS NOMB, ISNULL(LICENCIA,'') AS LIC, ISNULL(LIC_VENC,'') AS L_VIG FROM GCOPERADOR WHERE STATUS = 'A' ORDER BY CLAVE"
                    SQL = "NOMB LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "NOMB"
                Case "Marca"
                    SQL = "(CVE_MARCA LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "Marca Unidad"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    'BindingSource1.Sort = "DESCR"
                Case "Zona"
                    SQL = "(CVE_ZONA LIKE '%" & tBox.Text & "%' OR TEXTO LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "TEXTO"
                Case "Pais"
                    SQL = "CVE_PAIS LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "DESCR"
                Case "Vend"
                    SQL = "(CVE_VEND LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "NOMBRE"
                Case "Listaprec"
                    SQL = "(DESCRIPCION LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_PRECIO"

                Case "Unidades2"
                    'SELECT CLAVE, CLAVEMONTE, DESCR, PLACAS_MEX, CVE_TIPO_UNI
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%' OR CLAVEMONTE LIKE '%" & tBox.Text & "%' OR 
                        PLACAS_MEX LIKE '%" & tBox.Text & "%')"
                    'BindingSource1.Sort = "CLAVE"
                Case "ArticulosLlantas"
                    'SQL = "SELECT CVE_ART, ISNULL(DESCR,'') AS DES, ISNULL(EXIST,0) AS EXI
                    SQL = "(CVE_ART LIKE '%" & tBox.Text & "%' OR DES LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_ART"
                Case "Articulo"
                    'SQL = "SELECT I.CVE_ART, DESCR, (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1,
                    '(SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, EXIST, TIPO_ELE,
                    'ISNULL(COSTO_PROM,0) AS C_PROM
                    'From INVE" & Empresa & " I WHERE I.STATUS = 'A' AND TIPO_ELE = 'P' ORDER BY DESCR"

                    SQL = "(CVE_ART LIKE '%" & tBox.Text.ToUpper & "%' OR DES LIKE '%" & tBox.Text.ToUpper & "%')"
                    BindingSource1.Sort = "CVE_ART"
                Case "InveP", "InveS", "InveLiq", "GCINVER", "InvenTabRutas"
                    'SQL = "SELECT I.CVE_ART, DESCR, PRECIO,
                    '(SELECT TOP 1 CVE_ALTER FROM CVES_ALTER01 A WHERE CVE_ART = I.CVE_ART) AS ALTERNA, EXIST, TIPO_ELE,
                    ' ISNULL(COSTO_PROM,0) AS C_PROM
                    'From INVE" & Empresa & " I 
                    'Left JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND P.CVE_PRECIO = 1 
                    'WHERE I.STATUS = 'A' AND TIPO_ELE = 'S' AND LIN_PROD = '" & Var5 & "' ORDER BY DESCR"
                    SQL = "(CVE_ART LIKE '%" & tBox.Text.ToUpper & "%' OR DESCR LIKE '%" & tBox.Text.ToUpper & "%')"
                    'C_PROM P1
                    BindingSource1.Sort = "CVE_ART"

                Case "InveR", "InvenRS", "InvenRP", "Inventario"
                    SQL = "(CVE_ART LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_ART"
                Case "GCPRODUCTOS", "Productos"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    'BindingSource1.Sort = "CVE_PROD"
                Case "Mecanicos"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_MEC"
                Case "Tractor"
                    SQL = "(CVE_TRACTOR LIKE '%" & tBox.Text & "%' OR MARCA '%" & tBox.Text & "%' OR MODELO LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_TRACTOR"
                Case "Grupo Unidades"
                    SQL = "(CVE_GPO LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_GPO"
                Case "Placas Defa"
                    SQL = "(CVE_PLA LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_PLA"
                Case "Medidas Llanta"
                    SQL = "(DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "DESCR"
                Case "ConcCxC", "ConcCxP", "CONM", "ConcCxPRef", "GCLLANTAS_CONM"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_CPTO"

                Case "ConcSAT"
                    SQL = "FORMADEPAGOSAT LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "FORMADEPAGOSAT"

                Case "Servicios", "ServiciosOrdenes", "InveSAE"
                    SQL = "CVE_ART LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_ART"
                Case "Servicios2"
                    SQL = "CVE_SER LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_SER"
                Case "Clasificacion"
                    'SQL = "SELECT CVE_CLA, DESCR FROM GCCLASIFIC_SERVICIOS WHERE STATUS = 'A' ORDER BY TRY_PARSE(CVE_CLA AS INT)"
                    SQL = "CVE_CLA LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_CLA"
                Case "Tipo de Cobro"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%'"
                    'BindingSource1.Sort = "CVE_COBRO"
                Case "Numero de Viaje"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_VIAJE"
                Case "Gasolinera", "GasConci"
                    'SQL = "SELECT CAST(CVE_GAS AS INT), DESCR FROM GCGASOLINERAS WHERE STATUS = 'A' ORDER BY CAST(CVE_GAS AS INT)"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = ""
                Case "Lineas"
                    SQL = "(CVE_LIN LIKE '%" & tBox.Text & "%' or DESCR LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_LIN"
                Case "Lineas"
                    SQL = "DESCRIPESQ LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_ESQIMPU"
                Case "Moneda"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%' OR CVE_MONED LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "NUM_MONED"
                Case "Fallas"
                    SQL = "DESCR_FALLA LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_FALLAS"
                Case "Valor Declarado"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%'"
                    'BindingSource1.Sort = "CLAVE"
                Case "Origen", "Destino", "IAVE"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CLAVE"
                Case "Tipo Poliza"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "TIPO_POL"
                Case "Equipo Asegurado"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_ASE"
                Case "GCPOLIZAS"
                    'IDPOLIZA, FOLIO, T.DESCR AS DESCR_TIPO_POL, E.DESCR AS EQUIPO, R.NOMBRE, TIPO_COBERTURA " &
                    'T.DESCR AS DESCR_TIPO_POL, E.DESCR AS EQUIPO, P.NOMBRE 
                    SQL = "T.DESCR LIKE '%" & tBox.Text & "%' OR E.DESCR LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CLAVE"
                Case "Incidencias", "GCSERVICIOS_MANTE"
                    SQL = "DESCR LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_INC"
                Case "GCASEGURADORAS"
                    SQL = "NOMBRE LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CLAVE"
                Case "Estados"
                    SQL = "NOMBRE LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_ESTADO"
                Case "Nivel Combustible"
                    'SQL = "ALTURA LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "ID_TABLA"
                Case "ProvDocSaldos"
                    'SQL = "SELECT M.REFER, M.CVE_PROV, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA, .TIPO_MOV, M.DOCTO, M.NUM_CPTO
                    SQL = "REFER LIKE '%" & tBox.Text & "%' OR CVE_PROV LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR 
                           NO_FACTURA LIKE '%" & tBox.Text & "%' OR DOCTO LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "REFER"
                Case "ClieDocTo", "ProvDocTo"
                    'SQL = "SELECT M.DOCTO, P.NOMBRE, M.FECHA_APLI, M.NO_FACTURA, M.IMPORTE
                    SQL = "DOCTO LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR 
                           NO_FACTURA LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "DOCTO"
                Case "ClieDocSaldos", "ClieDocSaldos2", "PagoComplemento"
                    'SQL = "SELECT M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,
                    'ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND 
                    'm.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) + 
                    '(SELECT COALESCE(SUM(C3.IMPORTE * SIGNO),0) AS ABONOS FROM CUEN_DET" & Empresa & " C3 
                    'WHERE C3.REFER = M.REFER AND ID_MOV = M.NUM_CPTO AND SIGNO = 1) AS SUMA_CUENDET,
                    'm.IMPORTE, M.IMPORTE + 
                    'ISNULL((SELECT SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " C4 WHERE REFER = M.REFER AND CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO AND NUM_CARGO = M.NUM_CARGO),0),
                    'm.DOCTO, M.NUM_CARGO
                    SQL = "REFER LIKE '%" & tBox.Text & "%' OR CVE_CLIE LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR 
                           NO_FACTURA LIKE '%" & tBox.Text & "%' OR DOCTO LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "REFER"
                Case "FACTG"
                    'SQL = "SELECT D.REFER, D.CVE_CLIE, P.NOMBRE, D.FECHA_APLI, M.IMPORTE, D.NO_FACTURA, M.DOCTO, m.NUM_CPTO + ' ' + D.DESCR
                    SQL = "REFER LIKE '%" & tBox.Text & "%' OR CVE_CLIE LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR 
                           NO_FACTURA LIKE '%" & tBox.Text & "%' OR DOCTO LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "REFER"
                Case "Plazas"
                    SQL = "CIUDAD LIKE '%" & tBox.Text & "%' OR MUNICIPIO LIKE '%" & tBox.Text & "%'"
                    'BindingSource1.Sort = "CLAVE"
                Case "Pedidos", "PedidosProg"
                    'SELECT P.CVE_DOC, C3.NOMBRE, I.DESCR, P.FECHA_CARGA, P.FECHA_DESCARGA, RE.DESCR As RECIBIR_E, EE.DESCR AS RECOGER_E
                    SQL = "(P.CVE_DOC Like '%" & tBox.Text & "%' OR C3.NOMBRE LIKE '%" & tBox.Text & "%' OR I.DESCR '%" & tBox.Text & "%' OR 
                        RE.RECIBIR_E LIKE '%" & tBox.Text & "%' OR RR.RECOGER_E LIKE '%" & tBox.Text & "%')"
                    BindingSource1.Sort = "CVE_DOC"
                Case "Detalle Rutas"
                    'SQL = "SELECT CAST(D.CVE_RUTA AS INT AS 'Clave', P1.CIUDAD AS 'Origen', P2.CIUDAD AS 'Destino', ISNULL(D.KM_RECORRIDOS,0 AS 'Km. Recorridos', " &
                    '    "ISNULL(D.COSTO_CASETAS,0 AS 'Costo casetas', ISNULL(D.EJES,0 AS 'Ejes' " 
                    SQL = "P1.CIUDAD LIKE '%" & tBox.Text & "%' OR P2.CIUDAD LIKE '%" & tBox.Text & "%'"
                    'BindingSource1.Sort = "D.CVE_RUTA"
                Case "Cliente operativo"
                    'SQL = "SELECT CAST(C.CLAVE AS INT AS CLIEOP, C.NOMBRE, ISNULL(P1.CIUDAD,'' AS PLAZA, C.DOMICILIO " &
                    '   "FROM GCCLIE_OP C " &
                    '  "LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = C.CVE_PLAZA " &
                    ' "ORDER BY CAST(C.CLAVE AS INT "
                    SQL = "CLIEOP LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR DOMICILIO LIKE '%" & tBox.Text & "%'"
                    'BindingSource1.Sort = "CLAVE"
                Case "Asignacion viajes", "Asignacion viajes Liq", "Asignacion viajes todos"
                    SQL = "CVE_VIAJE LIKE '%" & tBox.Text & "%' OR CLAVEMONTE LIKE '%" & tBox.Text & "%' OR " &
                        "T_UNI LIKE '%" & tBox.Text & "%' OR T_VIAJE LIKE '%" & tBox.Text & "%' OR " &
                        "NOMBRE LIKE '%" & tBox.Text & "%' OR DESCR_ORIGEN LIKE '%" & tBox.Text & "%'  OR DESCR_DESTINO LIKE '%" & tBox.Text & "%'"
                    'BindingSource1.Sort = "CLAVE"

                Case "Asignacion Viajes bueno", "Asignacion Viajes bueno2"

                    'SELECT TOP 5000 A.CVE_VIAJE, A.CVE_TRACTOR, A.FECHA, (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNIDAD, 
                    '.NETO, ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0) AS ABONOS,
                    '(A.NETO -ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) AS SALDO,
                    'O.NOMBRE, C1.NOMBRE AS ORIGEN, C2.NOMBRE AS DESTINO 

                    SQL = "CVE_VIAJE Like '%" & tBox.Text & "%' OR CVE_TRACTOR LIKE '%" & tBox.Text & "%' OR " &
                        "NOMBRE LIKE '%" & tBox.Text & "%' OR ORIGEN LIKE '%" & tBox.Text & "%' OR DESTINO LIKE '%" & tBox.Text & "%'"

                Case "Consulta Bajas Viajes"
                    SQL = "CVE_BAJA LIKE '%" & tBox.Text & "%' OR CAST(SUBTOTAL AS FLOAT) LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_BAJA"
                Case "Tab Rutas"
                    SQL = "RUTA_ORIGEN LIKE '%" & tBox.Text & "%' OR RUTA_DESTINO LIKE '%" & tBox.Text & "%' OR " &
                        "CLIENTE LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR " &
                        "T_UNI LIKE '%" & tBox.Text & "%' OR T_VIAJE LIKE '%" & tBox.Text & "%'"
                    BindingSource1.Sort = "CVE_TAB"
                Case Else
                    MsgBox("No se encontraron coincidencias")
            End Select

            BindingSource1.RemoveFilter()

            If tBox.Text.Trim.Length > 0 Then
                BindingSource1.Filter = SQL
            Else
                BindingSource1.Filter = ""
            End If
            ' enlzar el datagridview al BindingSource  

            Fg.DataSource = BindingSource1.DataSource

            Lt.Text = "Registros encontrados " & Fg.Rows.Count - 1
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            'MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarBuscar_Click(Nothing, Nothing)
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Var4 = ""
        Var5 = ""
        Var6 = ""
        Var7 = ""
        Var8 = ""
        Var9 = ""
        Me.Close()
    End Sub
    Private Sub BarBuscar_Click(sender As Object, e As EventArgs) Handles barBuscar.Click
        Try
            Select Case Proceso
                Case "Abonos viajes"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CVE_DOC
                    End If
                Case "DocPagosComp"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'REFER
                        Var5 = Fg(Fg.Row, 2) 'CVE_CLIE
                        Var6 = Fg(Fg.Row, 3) 'NOMBRE
                        Var7 = Fg(Fg.Row, 5) 'NO_FACTURA
                        Var8 = Fg(Fg.Row, 6) 'DOCTO
                        Var9 = Fg(Fg.Row, 7) 'IMPORTE
                        Var10 = Fg(Fg.Row, 8) 'NO_PARTIDA
                    End If
                Case "CuentaOrdenante", "CuentaBeneficiaria"
                    'SQL = "SELECT CUENTA_BANCARIA, RFC_BANCO, NOMBRE_BANCO, CLAVE FROM CUENTA_BENEF" & Empresa & " ORDER BY NOMBRE_BANCO"
                    If Fg.Row > 0 Then
                        If Fg(Fg.Row, 1) IsNot DBNull.Value Then
                            Var4 = Fg(Fg.Row, 1) 'CUENTA BANCARIA
                        Else
                            Var4 = ""
                        End If
                        If Fg(Fg.Row, 2) IsNot DBNull.Value Then
                            Var5 = Fg(Fg.Row, 2) 'RFC 
                        Else
                            Var5 = ""
                        End If
                        If Fg(Fg.Row, 3) IsNot DBNull.Value Then
                            Var6 = Fg(Fg.Row, 3) 'NOMBRE BANCO
                        Else
                            Var6 = ""
                        End If
                        If Fg(Fg.Row, 4) IsNot DBNull.Value Then
                            Var7 = Fg(Fg.Row, 4) 'CVE_BANCO
                        Else
                            Var7 = ""
                        End If
                        If Fg(Fg.Row, 5) IsNot DBNull.Value Then
                            Var8 = Fg(Fg.Row, 5) 'CLABE
                        Else
                            Var8 = ""
                        End If
                    End If
                Case "Moneda"
                    If Fg.Row > 0 Then
                        'NUM_MONED, DESCR, CVE_MONED, TCAMBIO
                        Var4 = Fg(Fg.Row, 1) 'NUM_MONED
                        Var5 = Fg(Fg.Row, 2) 'DESCR
                        Var6 = Fg(Fg.Row, 3) 'CVE_MONDE
                        Var7 = Fg(Fg.Row, 4) 'TIPO CAMBBIO
                        'NUM_MONED, DESCR, CVE_MONED, TCAMBIO 
                    End If
                Case "GCDEDUC_OPER"
                    'SQL = "SELECT DO.FOLIO, D.DESCR AS DESCR_DED, DO.DESCR, DO.IMPORTE_PRESTAMO, DO.SALDO, DO.PAGO_EN_LIQ, DO.SALDO_ACTUAL 		
                    'Fg(0, 1) = "Folio"
                    'Fg(0, 2) = "Deduccion"
                    'Fg(0, 3) = "Descripción"
                    'Fg(0, 4) = "Importe prestamo"
                    'Fg(0, 5) = "Saldo"
                    'Fg(0, 6) = "Pago en liq."
                    'Fg(0, 7) = "Saldo actual"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'FOLIO
                        Var5 = Fg(Fg.Row, 2) 'DESCR DEDUCCION
                        Var6 = Fg(Fg.Row, 3) 'DESCRIPCION DEDUDC OPER
                        Var7 = Fg(Fg.Row, 4) 'IMPORTE PRESTAMO
                        Var8 = Fg(Fg.Row, 6) 'SALDO
                        Var9 = Fg(Fg.Row, 5) 'PAGO EN LIQ.
                        Var10 = Fg(Fg.Row, 6) 'SALDO ACTUAL
                    End If
                Case "Deducciones", "Aseguradoras"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString   'clave
                        Var5 = Fg(Fg.Row, 2).ToString   'descr
                    End If
                Case "Evento"
                    'SQL = "SELECT CVE_EVE, TABULADOR, FISICO_VS_ECM, RALENTI, PORC_TOLERANCIA, PORC_RALENTI, CRITERIO 
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString
                        Var5 = Fg(Fg.Row, 2).ToString
                        Var6 = Fg(Fg.Row, 3).ToString
                        Var7 = Fg(Fg.Row, 4).ToString
                        Var8 = Fg(Fg.Row, 5).ToString
                        Var9 = Fg(Fg.Row, 6).ToString
                        Var10 = Fg(Fg.Row, 7).ToString
                    End If
                Case "Motor"
                    If Fg.Row > 0 Then
                        'SQL = "SELECT CVE_MOT, MOTOR, DESCR, CASE 
                        'WHEN TIPO_VIAJE = 0 THEN 'Full' 
                        'WHEN TIPO_VIAJE = 1 THEN 'Sencillo'
                        'WHEN TIPO_VIAJE = 2 THEN 'Full/Sencillo' ELSE '' END AS TIP_VIAJE 
                        'From GCMOTORES WHERE STATUS = 'A' ORDER BY CVE_MOT"
                        Var4 = Fg(Fg.Row, 1).ToString   'clave MOTOR
                        Var5 = Fg(Fg.Row, 3).ToString   'descr
                        Var6 = Fg(Fg.Row, 2).ToString   'MOTOR
                        Var7 = Fg(Fg.Row, 4).ToString   'TIPO_VIAJE
                    End If
                Case "TAQ"
                    'Fg(0, 2) = "1 Ancho"
                    'Fg(0, 3) = "1 Alto"
                    'Fg(0, 4) = "1 Profundidad"
                    'Fg(0, 5) = "1 Litros"
                    'Fg(0, 6) = "2 Ancho"
                    'Fg(0, 7) = "2 Alto"
                    'Fg(0, 8) = "2 Profundidad"
                    'Fg(0, 9) = "2 Litros"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE

                        Var5 = Fg(Fg.Row, 2) 'ANCHO
                        Var6 = Fg(Fg.Row, 3) 'ALTO
                        Var7 = Fg(Fg.Row, 4) 'PROFUNDIDAD
                        Var8 = Fg(Fg.Row, 5) 'LITROS

                        Var9 = Fg(Fg.Row, 6) 'ANCHO
                        Var10 = Fg(Fg.Row, 7) 'ALTO
                        Var11 = Fg(Fg.Row, 8) 'PROFUNDIDAD
                        Var12 = Fg(Fg.Row, 9) 'LITROS

                    End If
                Case "Medicion combustible"
                    'SQL = "SELECT M.CLAVE, M.CLAVEMONTE, M.FECHA, M.SUMA " &
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString   'M.CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString   'M.CLAVEMONTE
                        Var6 = Fg(Fg.Row, 4).ToString   'SUMA LITROS
                    End If
                Case "OT"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString
                    End If
                Case "Almacenes"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString
                        Var5 = Fg(Fg.Row, 2).ToString
                    End If
                Case "RecogerEn", "EntregarEn"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  '
                        Var5 = Fg(Fg.Row, 2).ToString  '
                    End If
                Case "FACT", "COMP", "FACTURAS"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CVE_DOC
                        Var5 = Fg(Fg.Row, 2) 'CLAVE
                        Var6 = Fg(Fg.Row, 3) 'NOMBRE
                        Var7 = Fg(Fg.Row, 4) 'FECHA
                        Var8 = Fg(Fg.Row, 5) 'IMPORTE
                        Var9 = Fg(Fg.Row, 6) 'doc sig
                        Var10 = Fg(Fg.Row, 7) 'tip doc sig
                    End If
                Case "CFDI"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'factura
                        Var5 = Fg(Fg.Row, 3) 'carta porte1
                        Var6 = Fg(Fg.Row, 4) 'carta porte 2
                    End If
                Case "Usuario"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  '
                        Var5 = Fg(Fg.Row, 2).ToString  '
                    End If
                Case "Contrato", "ContratoTab"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  'CVE_CON
                        Var5 = Fg(Fg.Row, 2).ToString  'NO_CONTRATO
                        Var6 = Fg(Fg.Row, 3).ToString  'CLAVE
                        Var7 = Fg(Fg.Row, 4).ToString  'NOMBRE
                    End If
                Case "Remision"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CVE_DOC
                        Var5 = Fg(Fg.Row, 2) 'CLAVE
                        Var6 = Fg(Fg.Row, 3) 'NOMBRE
                        Var7 = Fg(Fg.Row, 4) 'FECHA
                        Var8 = Fg(Fg.Row, 5) 'IMPORTE
                    End If
                Case "Carta Porte"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = ""
                        Var6 = ""
                        Var7 = ""
                    End If
                Case "Clientes", "Prov", "Clie01", "Clie"
                    'SQL = "SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, ISNULL(CAMPLIB5,0) AS LIB5 " &
                    '   "FROM CLIE" & Empresa & " C " &
                    '  "LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE = C.CLAVE " &
                    '  "WHERE C.STATUS = 'A' ORDER BY C.CLAVE"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                        Var6 = Fg(Fg.Row, 3).ToString 'rfc
                        Var7 = Fg(Fg.Row, 4).ToString 'calle
                        If Proceso <> "Prov" Then
                            Var8 = Fg(Fg.Row, 5).ToString 'porc
                            Var9 = Fg(Fg.Row, 6).ToString 'porc o monto
                        Else
                            Var8 = "0"
                            Var9 = "0"
                        End If
                    End If
                Case "CLIE"
                    If Fg.Row > 0 Then
                        'SELECT C.CLAVE, C.NOMBRE, C.RFC, C.CALLE, MUNICIPIO 
                        Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                        Var6 = Fg(Fg.Row, 3).ToString 'rfc
                        Var7 = Fg(Fg.Row, 4).ToString 'calle
                        Var8 = Fg(Fg.Row, 5).ToString 'municipio
                    End If
                Case "Modelo", "Modelo Renovado", "Modelo Llanta", "Medidas Llanta", "Origen", "Destino"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                    End If
                Case "Marca", "Marca Renovado", "GCASEGURADORAS"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                    End If
                Case "Tipo Llanta"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                    End If
                Case "Status Llanta"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                    End If
                Case "MarcaTipo"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                    End If
                Case "Deptos"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                    End If
                Case "Puestos", "Tipo Unidad", "Sucursal", "Operador", "Marca Unidad", "Modelo", "OperadorSel"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                        Var6 = Fg(Fg.Row, 3) 'LICENCIA
                        Var7 = Fg(Fg.Row, 4) 'VIGENCIA
                    End If
                Case "CONM", "GCLLANTAS_CONM"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                        Var6 = Fg(Fg.Row, 3) 'descr status
                        Var7 = Fg(Fg.Row, 5) 'clave status
                    End If
                Case "Formas de pago", "ConcCxC", "ConcCxP", "ConcCxPRef"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'FORMAPAGOSAT
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                    End If
                Case "ConcSAT"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'FORMAPAGOSAT
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                        Var6 = Fg(Fg.Row, 3) 'NUM_CPTO
                    End If

                Case "InveSAE"
                    'SQL = "SELECT I.CVE_ART, DESCR, (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1,
                    '    (SELECT TOP 1 CVE_ALTER FROM CVES_ALTER" & Empresa & " A WHERE CVE_ART = I.CVE_ART) AS ALTERNA
                    'From INVE" & Empresa & " I WHERE I.STATUS = 'A' AND TIPO_ELE = 'S' AND CVE_PRODSERV = '78101802' ORDER BY CVE_ART"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CVE_ART
                        Var5 = Fg(Fg.Row, 2) 'DESCRIPCION
                        Var6 = Fg(Fg.Row, 3) 'PRECIO
                    End If
                Case "Zona", "Vend", "Listaprec", "Pais", "Tractor", "Articulo", "Grupo Unidades", "Placas Defa", "Servicios",
                     "GCPRODUCTOS", "Productos", "Estados", "ServiciosOrdenes", "ArticulosLlantas", "Servicios2"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'NOMBRE
                    End If
                Case "InveR", "InvenRS", "InvenRP", "Inventario", "GCINVER"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                        Var6 = Fg(Fg.Row, 3).ToString 'ALTERNA
                        Var7 = Fg(Fg.Row, 4).ToString 'EXIST
                        Var8 = Fg(Fg.Row, 5).ToString 'TIPO ELE
                    End If
                Case "InveLiq"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                        Var7 = Fg(Fg.Row, 3).ToString 'PRECIOS
                        Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                    End If
                Case "InveP", "InveS", "InveLiq", "InvenTabRutas"
                    If Fg.Row > 0 Then
                        'Fg(0, 1) = "Clave"
                        'Fg(0, 2) = "Descripción"
                        'Fg(0, 3) = "Precio"
                        'Fg(0, 4) = "Alterna"
                        'Fg(0, 5) = "Exist."
                        'Fg(0, 6) = "Tipo prod."
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                        Var7 = Fg(Fg.Row, 3).ToString 'PRECIOS
                        Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                        Var8 = Fg(Fg.Row, 6).ToString 'TIPO PROD
                        Var9 = Fg(Fg.Row, 7).ToString 'COSTO PROM
                    End If
                Case "Unidad"
                    If Fg.Row > 0 Then
                        'SELECT U.CLAVE, U.CLAVEMONTE, U.DESCR, U.PLACAS_MEX, M.DESCR AS MARCA, T.DESCR AS TUNI
                        Var4 = Fg(Fg.Row, 2).ToString  'CLAVE MONTE
                        Var3 = Fg(Fg.Row, 1).ToString  'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString  'CLAVE MONTE
                        Var6 = Fg(Fg.Row, 3).ToString  'DESCR
                        Var7 = Fg(Fg.Row, 4).ToString  'PLACAS
                        Var8 = Fg(Fg.Row, 5).ToString  'DESCR MARCA
                        'Var9 = Fg(Fg.Row, 6).ToString  'CLAVE CVE_TIPO UNI
                        'Var11 = Fg(Fg.Row, 8).ToString 'DESCR TIPO UNI
                    End If

                Case "Unidades2"
                    If Fg.Row > 0 Then
                        'SELECT U.CLAVE, U.CLAVEMONTE, U.DESCR, U.PLACAS_MEX, U.CVE_TIPO_UNI, U.CVE_MOT, M.DESCR_MOTOR
                        Var4 = Fg(Fg.Row, 1).ToString  '
                        Var3 = Fg(Fg.Row, 2).ToString  'CLAVE MONTE
                        Var5 = Fg(Fg.Row, 2).ToString  'CLAVE MONTE
                        Var6 = Fg(Fg.Row, 3).ToString  'DESCR uni
                        Var7 = Fg(Fg.Row, 4).ToString  'PLACAS
                        Var8 = Fg(Fg.Row, 5).ToString  'DESCR TIPO UNIDAD
                        Var9 = Fg(Fg.Row, 6).ToString  'motor
                        Var10 = Fg(Fg.Row, 7).ToString  'NOMBRE MOTOR
                    End If
                Case "Bancos"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                        Var6 = Fg(Fg.Row, 3).ToString  'RFC
                    End If
                Case "Clasificacion", "Tipo de Cobro", "Numero de Viaje", "Gasolinera", "Lineas", "Esquema", "Mecanicos", "GasConci"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                    End If
                Case "Fallas", "AnticipoCat", "TipoDescuento", "FormaDescuento", "Status"
                    If Fg.Row > 0 Then
                        'SQL = "SELECT P.CVE_FALLA, U.DESCR, P.DESCR_FALLA, F.CVE_ORD AS 'Orden asignada', F.CVE_UNI " 
                        Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString  'desc UNIDAD
                        Var6 = Fg(Fg.Row, 3).ToString  'descrip FALLA
                        Var7 = Fg(Fg.Row, 4).ToString  'ORDEN ASIGNADA
                        Var8 = Fg(Fg.Row, 5).ToString  'unidad
                        Var9 = Fg(Fg.Row, 6).ToString  'no_partida
                    End If
                Case "Viajes", "Autoriza", "GCConc", "Tipo Poliza", "Equipo Asegurado"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) & " " & Fg(Fg.Row, 3) 'NOMBRE
                    End If
                Case "AnticipoViaje", "Nivel Combustible"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2) 'FECHA
                        Var6 = Fg(Fg.Row, 3) 'FECHA
                        Var7 = Fg(Fg.Row, 4) 'IMPORTE
                    End If
                Case "Rutas", "IAVE"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'ORIGEN
                        Var6 = Fg(Fg.Row, 3).ToString 'DESTINO
                    End If
                Case "Tip Tercero", "Tip Opera", "Incidencias", "GCSERVICIOS_MANTE"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1).ToString 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'UNIDAD
                        'Var6 = Fg(Fg.Row, 3) 'NUM ECONOMICO
                    End If
                Case "Llantas", "LlantasStatusPendiente_2", "LlantasNoAsignadas"
                    'LL.CVE_LLANTA, LL.NUM_ECONOMICO, LL.UNIDAD, LL.POSICION, M.DESCR
                    Var4 = Fg(Fg.Row, 1).ToString 'CLAVE
                    Var5 = Fg(Fg.Row, 2).ToString 'UNIDAD
                    Var6 = Fg(Fg.Row, 5).ToString 'MARCA
                    Var7 = Fg(Fg.Row, 6).ToString 'ESTATUS LLANTAS
                    Var8 = Fg(Fg.Row, 7).ToString 'articulo
                    Var9 = Fg(Fg.Row, 8).ToString 'costo
                    Var10 = Fg(Fg.Row, 9).ToString 'CVE_ST_UNI
                Case "Valor Declarado"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE
                        Var5 = Fg(Fg.Row, 2).ToString 'DESCR
                        Var6 = Format(CSng(Fg(Fg.Row, 3)), "###,##0.0") 'IMPORTE
                    End If
                Case "GCPOLIZAS"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) '
                        Var5 = Fg(Fg.Row, 2).ToString '
                        Var6 = Fg(Fg.Row, 3).ToString '
                        Var7 = Fg(Fg.Row, 4).ToString '
                        Var8 = Fg(Fg.Row, 5).ToString '
                        Var9 = Fg(Fg.Row, 6).ToString
                    End If
                Case "ProvDocSaldos"
                    'Fg(0, 1) = "Documento"
                    'Fg(0, 2) = "Clave"
                    'Fg(0, 3) = "Nombre"
                    'Fg(0, 4) = "Fecha"
                    'Fg(0, 5) = "Fecha venc."
                    'Fg(0, 6) = "No. Factura"
                    'Fg(0, 7) = "Abonos"
                    'Fg(0, 8) = "Importe"
                    'Fg(0, 9) = "Docto"
                    'Fg(0, 10) = "Num. cargo"
                    If Fg.Row > 0 Then
                        'M.TIPO_MOV, M.DOCTO, M.NUM_CPTO
                        '10             11       12
                        Var4 = Fg(Fg.Row, 1) 'DOCUMENTO
                        Var5 = Fg(Fg.Row, 2) 'CLAVE
                        Var6 = Fg(Fg.Row, 3) 'NOMBRE
                        Var11 = Fg(Fg.Row, 6).ToString 'NO_FACTURA
                        Var7 = Fg(Fg.Row, 7).ToString 'ABONOS
                        Var8 = Fg(Fg.Row, 8).ToString 'IMPORTE
                        Var9 = Fg(Fg.Row, 9).ToString 'DOTO
                        Var12 = Fg(Fg.Row, 10).ToString
                        Var10 = Fg(Fg.Row, 10) 'NUM_CARGO
                    End If
                Case "ClieDocTo", "ProvDocTo"
                    If Fg.Row > 0 Then
                        Try
                            Var4 = Fg(Fg.Row, 1).ToString  'DOCTO
                            Var5 = Fg(Fg.Row, 2).ToString  'NOMBRE
                        Catch ex As Exception
                        End Try
                    End If
                Case "ClieDocSaldos", "PagoComplemento"
                    If Fg.Row > 0 Then
                        Try
                            'SQL = "SELECT M.REFER, M.CVE_CLIE, P.NOMBRE, M.FECHA_APLI, M.FECHA_VENC, M.NO_FACTURA,
                            'ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " D WHERE M.CVE_CLIE = D.CVE_CLIE AND M.REFER = D.REFER AND M.NUM_CPTO = D.ID_MOV AND M.NUM_CARGO = D.NUM_CARGO),0) AS SUMA_CUENDET,
                            'm.IMPORTE, M.TIPO_MOV, M.DOCTO, M.NUM_CPTO

                            Var4 = Fg(Fg.Row, 1).ToString  'REFER
                            Var5 = Fg(Fg.Row, 2).ToString  'CLIENTE
                            Var7 = Fg(Fg.Row, 7) 'ABONOS
                            Var8 = Fg(Fg.Row, 8) 'IMPORTE
                            Var9 = Fg(Fg.Row, 8) + Fg(Fg.Row, 7)  'SALDO
                            Var6 = Fg(Fg.Row, 11).ToString  'NUM_CPTO
                        Catch ex As Exception
                        End Try
                    Else
                        Var4 = ""
                        Var5 = ""
                        Var7 = ""
                        Var8 = ""
                        Var9 = ""
                        Var6 = ""
                    End If
                Case "ClieDocSaldos2"
                    If Fg.Row > 0 Then
                        Try
                            Var4 = Fg(Fg.Row, 1).ToString  'REFER
                            Var5 = Fg(Fg.Row, 2).ToString  'CLIENTE
                            Var7 = Fg(Fg.Row, 7) 'ABONOS
                            Var8 = Fg(Fg.Row, 8) 'IMPORTE
                            Var9 = Fg(Fg.Row, 8) + Fg(Fg.Row, 7)  'SALDO
                            Var6 = Fg(Fg.Row, 11).ToString  'NUM_CARGO
                            Var10 = Fg(Fg.Row, 12).ToString  'NUM_cpto
                        Catch ex As Exception
                        End Try
                    Else
                        Var4 = ""
                        Var5 = ""
                        Var7 = ""
                        Var8 = ""
                        Var9 = ""
                        Var6 = ""
                    End If
                Case "FACTG"
                    If Fg.Row > 0 Then
                        Try
                            Var4 = Fg(Fg.Row, 1).ToString  'REFER
                            Var5 = Fg(Fg.Row, 2).ToString  'CLIENTE
                            Var6 = Fg(Fg.Row, 5) 'IMPORTE
                            Var7 = Fg(Fg.Row, 4) 'FECHA
                        Catch ex As Exception
                        End Try
                    Else
                        Var4 = ""
                        Var5 = ""
                        Var7 = ""
                        Var8 = ""
                        Var9 = ""
                        Var6 = ""
                    End If
                Case "Plazas"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1)
                        Var5 = Fg(Fg.Row, 2).ToString '
                        Var6 = Fg(Fg.Row, 3).ToString '
                    End If
                Case "Pedidos", "PedidosProg"
                    'P.CVE_DOC, P.CVE_CON, P.CVE_CLIE, C.NOMBRE, P.CVE_ART, I.DESCR, P.FECHA, P1.CIUDAD AS ORIGEN,
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CVE_DOC
                        Var5 = Fg(Fg.Row, 2) 'CVE_CON
                        Var6 = Fg(Fg.Row, 3) 'CVE_CLIE
                    End If
                Case "Detalle Rutas"
                    If Fg.Row > 0 Then
                        'Fg(0, 1) = "Clave"
                        'Fg(0, 2) = "Origen"
                        'Fg(0, 3) = "Destino"
                        'Fg(0, 4) = "Km recorridos"
                        'Fg(0, 5) = "Costo casetas"
                        'Fg(0, 6) = "Ejes"
                        Var4 = Fg(Fg.Row, 1)          'CVE_RUTA
                        Var5 = Fg(Fg.Row, 2).ToString 'origen
                        Var6 = Fg(Fg.Row, 3).ToString 'destino
                        Var7 = Fg(Fg.Row, 4).ToString 'KM RECORRIDOS
                        Var8 = Fg(Fg.Row, 5).ToString 'COSTO_CASETAS
                        Var9 = Fg(Fg.Row, 6).ToString 'EJES

                    End If
                Case "Tab Rutas"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE 
                        Var5 = Fg(Fg.Row, 2).ToString 'FECHA
                        Var6 = Fg(Fg.Row, 3).ToString 'TIPO
                        Var7 = Fg(Fg.Row, 4).ToString 'ORIGEN
                        Var8 = Fg(Fg.Row, 5).ToString 'DESTINO
                    End If
                Case "Cliente operativo"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE 
                        Var5 = Fg(Fg.Row, 2).ToString 'nombre
                        Var6 = Fg(Fg.Row, 3).ToString 'domicilio
                    End If
                Case "Asignacion viajes", "Consulta Bajas Viajes", "Asignacion viajes Liq", "Asignacion viajes todos", "Asignacion Viajes bueno", "Asignacion Viajes bueno2"
                    If Fg.Row > 0 Then
                        Var4 = Fg(Fg.Row, 1) 'CLAVE 
                        Var5 = Fg(Fg.Row, 2).ToString 'TIPO DE FACTURACION O ESCENARIO
                        Var6 = Fg(Fg.Row, 3).ToString
                    End If
            End Select

            Me.Close()

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso:  " & Proceso)
            'MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress

        If e.KeyChar = ChrW(Keys.Return) Then
            Try
                BarBuscar_Click(Nothing, Nothing)
            Catch ex As Exception
                Bitacora(ex.Message & vbNewLine & ex.StackTrace & "Proceso: " & Proceso)
                'MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace & "Proceso: " & Proceso)
            End Try
        End If
    End Sub
    Private Sub Fg_KeyUp(sender As Object, e As KeyEventArgs) Handles Fg.KeyUp
        If e.KeyCode = Keys.Left Then
            tBox.Focus()
        End If
    End Sub
    Private Sub BarRefresh_Click(sender As Object, e As EventArgs) Handles barRefresh.Click
        Try
            BindingSource1.RemoveFilter()
            BindingSource1.Filter = ""
            Fg.DataSource = BindingSource1.DataSource
            Fg.AutoSizeCols()
            Lt.Text = "Registros encontrados " & Fg.Rows.Count - 1
        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            'MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub

    Private Sub BarServicios_Click(sender As Object, e As EventArgs) Handles barServicios.Click
        Try
            SQL = "(STATUS <> 'B' AND TIPO_ELE = 'S' AND (CVE_ART LIKE '%" & tBox.Text & "%' OR DESCR LIKE '%" & tBox.Text & "%'))"

            BindingSource1.RemoveFilter()
            BindingSource1.Filter = SQL
            Fg.DataSource = BindingSource1.DataSource
            Fg.AutoSizeCols()

            Lt.Text = "Registros encontrados " & Fg.Rows.Count - 1

        Catch ex As Exception
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
            'MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace & vbNewLine & "Proceso: " & Proceso)
        End Try
    End Sub

    Private Sub TBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "*" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub TITULOS()
        Fg(0, 1) = "Clave"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(Int32)

        Fg(0, 2) = "Estatus"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Estado"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Fecha"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(DateTime)

        Fg(0, 5) = "Oprador"
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)

        Fg(0, 6) = "Unidad"
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(String)

        Fg(0, 7) = "Motor"
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(String)

        Fg(0, 8) = "Calif. factor carga"
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(Decimal)
        Fg.Cols(8).Format = "###,###,##0.00"

        Fg(0, 9) = "Calif. ralenti"
        Dim c9 As Column = Fg.Cols(9)
        c9.DataType = GetType(Decimal)
        Fg.Cols(9).Format = "###,###,##0.00"

        Fg(0, 10) = "Calif. vel. max."
        Dim c10 As Column = Fg.Cols(9)
        c10.DataType = GetType(Decimal)
        Fg.Cols(10).Format = "###,###,##0.00"

        Fg(0, 11) = "Calif. global"
        Dim c11 As Column = Fg.Cols(10)
        c11.DataType = GetType(Decimal)
        Fg.Cols(11).Format = "###,###,##0.00"

        Fg(0, 12) = "Bono"
        Dim c12 As Column = Fg.Cols(12)
        c12.DataType = GetType(Decimal)
        Fg.Cols(12).Format = "###,###,##0.00"

        Fg(0, 13) = "Odometro"
        Dim c13 As Column = Fg.Cols(13)
        c13.DataType = GetType(Decimal)
        Fg.Cols(13).Format = "###,###,##0.00"

        Fg(0, 14) = "Km ECM"
        Dim c14 As Column = Fg.Cols(14)
        c14.DataType = GetType(Decimal)
        Fg.Cols(14).Format = "###,###,##0.00"

        Fg(0, 15) = "Lts. ECM"
        Dim c15 As Column = Fg.Cols(15)
        c15.DataType = GetType(Decimal)
        Fg.Cols(15).Format = "###,###,##0.00"

        Fg(0, 16) = "Lts. Real"
        Dim c16 As Column = Fg.Cols(16)
        c16.DataType = GetType(Decimal)
        Fg.Cols(16).Format = "###,###,##0.00"

        Fg(0, 17) = "KM. Tabulador"
        Dim c17 As Column = Fg.Cols(17)
        c17.DataType = GetType(Decimal)
        Fg.Cols(17).Format = "###,###,##0.00"

        Fg(0, 18) = "LTS. Tabulador"
        Dim c18 As Column = Fg.Cols(18)
        c18.DataType = GetType(Decimal)
        Fg.Cols(18).Format = "###,###,##0.00"

        Fg(0, 19) = "Factor de carga"
        Dim c19 As Column = Fg.Cols(19)
        c19.DataType = GetType(Int16)

        Fg(0, 20) = "Hrs. trabajo"
        Dim c20 As Column = Fg.Cols(20)
        c20.DataType = GetType(Decimal)
        Fg.Cols(20).Format = "###,###,##0.00"

        Fg(0, 21) = "Hrs. PTO. RALENTI"
        Dim c21 As Column = Fg.Cols(21)
        c21.DataType = GetType(Decimal)
        Fg.Cols(21).Format = "###,###,##0.00"

        Fg(0, 22) = "Lts. PTO. RALENTI"
        Dim c22 As Column = Fg.Cols(22)
        c22.DataType = GetType(Decimal)
        Fg.Cols(22).Format = "###,###,##0.00"

        Fg(0, 23) = "% Tiempo PTO RALENTI"
        Dim c23 As Column = Fg.Cols(23)
        c23.DataType = GetType(Decimal)
        Fg.Cols(23).Format = "###,###,##0.00"

        Fg(0, 24) = "% Lts PTO RALENTI"
        Dim c24 As Column = Fg.Cols(24)
        c24.DataType = GetType(Decimal)
        Fg.Cols(24).Format = "###,###,##0.00"

        Fg(0, 25) = "Rendimiento ECM"
        Dim c25 As Column = Fg.Cols(25)
        c25.DataType = GetType(Decimal)
        Fg.Cols(25).Format = "###,###,##0.00"

        Fg(0, 25) = "Porc. var. lts. real"
        Dim c26 As Column = Fg.Cols(26)
        c26.DataType = GetType(Decimal)
        Fg.Cols(26).Format = "###,###,##0.00"

        Fg(0, 27) = "Porc. var. lts. tab. real"
        Dim c27 As Column = Fg.Cols(27)
        c27.DataType = GetType(Decimal)
        Fg.Cols(27).Format = "###,###,##0.00"

        Fg(0, 28) = "Rendimiento real"
        Dim c28 As Column = Fg.Cols(28)
        c28.DataType = GetType(Decimal)
        Fg.Cols(28).Format = "###,###,##0.00"

        Fg(0, 29) = "Dif. lts. real. lts. ECM"
        Dim c29 As Column = Fg.Cols(29)
        c29.DataType = GetType(Decimal)
        Fg.Cols(29).Format = "###,###,##0.00"

        Fg(0, 30) = "Dif. lts. real lts. TAB"
        Dim c30 As Column = Fg.Cols(30)
        c30.DataType = GetType(Decimal)
        Fg.Cols(30).Format = "###,###,##0.00"
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click

    End Sub
End Class
