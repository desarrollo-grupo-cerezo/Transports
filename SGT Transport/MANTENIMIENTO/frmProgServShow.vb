Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmProgServShow

    Private Sub frmProgServShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

            DESPLEGAR()

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim CADENA1 As String
            Dim nDia As Integer

            ENCABEZADO()
            'Cp1 = "1"  FILTRAR FECHA_PROG
            'Cp1 = "0"  NO   NO FILTAR
            If Cp1 = "1" Then
                If IsNumeric(nDia) Then
                    nDia = Cp1
                    CADENA1 = " AND FECHA_PROG BETWEEN '" & FSQL(DateTime.Now) & " 00:00:00' AND '" & FSQL(DateTime.Now.AddDays(nDia)) & " 23:59:59'"
                Else
                    CADENA1 = ""
                End If
            Else
                CADENA1 = ""
            End If
            SQL = "SELECT CVE_PROG, P.STATUS, P.CVE_UNI, T.DESCR AS TDESCR, ISNULL(SM.DESCR,'') AS DESCR_SM, FECHA_PROG, KM_ACTUAL, " &
                "KM_PROX_SERVICIO, ISNULL(O.DESCR,'') AS OBS_STR, CVE_ORD, " &
                "ISNULL(STUFF((SELECT ' , ' + S.CVE_ART FROM GCPROGAMACION_SERVICIOS_PAR S INNER JOIN INVE" & Empresa & " I ON I.CVE_ART = S.CVE_ART WHERE S.CVE_PROG = P.CVE_PROG FOR XML PATH ('')),1,2, ''),'') AS PAR_SER " &
                "FROM GCPROGAMACION_SERVICIOS P " &
                "LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = P.CVE_UNI " &
                "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                "LEFT JOIN GCSERVICIOS_MANTE SM ON SM.CVE_SER = P.CVE_SER " &
                "LEFT JOIN GCOBS O ON O.CVE_OBS = P.CVE_OBS " &
                "WHERE P.STATUS = 'A' AND ISNULL(P.CVE_ORD,'') = '' " & CADENA1 &
                " ORDER BY CAST(CVE_PROG AS INT) DESC"

            'P.CVE_UNI = '" & Var5 & "' AND " '&
            'IIf(Var16.Trim.Length > 0, " AND FECHA_PROG = '" & Var16 & "'", "")
            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_PROG") & vbTab & dr("STATUS") & vbTab & dr("CVE_UNI") & vbTab & dr("TDESCR") & vbTab &
                           dr("DESCR_SM") & vbTab & dr("FECHA_PROG") & vbTab & dr("KM_ACTUAL") & vbTab & dr("KM_PROX_SERVICIO") & vbTab &
                           dr("CVE_ORD") & vbTab & dr("OBS_STR") & vbTab & dr("PAR_SER"))
                    End While
                End Using
            End Using
            If Fg.Rows.Count = 1 And Cp1 = "1" Then
                Me.Close()
                Return
            End If
            Fg.Rows(0).Height = 50
            Fg.Cols(0).Width = 30 : Fg.Cols(1).Width = 50 : Fg.Cols(2).Width = 50 : Fg.Cols(3).Width = 60 : Fg.Cols(4).Width = 130
            Fg.Cols(5).Width = 130 : Fg.Cols(6).Width = 70 : Fg.Cols(7).Width = 60 : Fg.Cols(8).Width = 60 : Fg.Cols(9).Width = 60
            Fg.Cols(10).Width = 110 : Fg.Cols(11).Width = 200
            Fg.AutoSizeRows()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ENCABEZADO()
        Fg.Rows(0).Height = 40
        Fg.Cols.Count = 12
        Fg(0, 1) = "Clave"
        Dim c1 As Column = Fg.Cols(1)
        c1.DataType = GetType(String)

        Fg(0, 2) = "Estatus"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Unidad"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Unidad"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(String)

        Fg(0, 5) = "Unidad"
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)

        Fg(0, 6) = "Fecha"
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(DateTime)

        Fg(0, 7) = "Km actual"
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(Decimal)
        Fg.Cols(7).Format = "###,###,##0.00"

        Fg(0, 8) = "Km prox. servicio"
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(Decimal)
        Fg.Cols(8).Format = "###,###,##0.00"

        Fg(0, 9) = "Orden de trabajo"
        Dim c9 As Column = Fg.Cols(9)
        c9.DataType = GetType(String)

        Fg(0, 10) = "Observaciones"
        Dim c10 As Column = Fg.Cols(10)
        c10.DataType = GetType(String)

        Fg(0, 11) = "Productos"
        Dim c11 As Column = Fg.Cols(11)
        c11.DataType = GetType(String)

    End Sub
    Private Sub frmProgServShow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Var16.Trim.Length = 0 Then
                Var16 = Fg(Fg.Row, 1)
                Var17 = Fg(Fg.Row, 3) & " " & Fg(Fg.Row, 4) & " " & Fg(Fg.Row, 5)
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
