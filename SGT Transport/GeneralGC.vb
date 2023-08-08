Imports System.Data.SqlClient

Module GeneralGC
    Public Mycolor1 As Color
    Public Mycolor2 As Color
    Public Function BUSCA_ENCAT(fTABLA As String, FCLAVE As String) As String
        If Not Valida_Conexion() Then
            Return ""
        End If
        Dim CADENA As String = ""
        Try
            If fTABLA.Trim.Length = 0 Or FCLAVE.Trim.Length = 0 Then
                Return ""
            End If
            FCLAVE = FCLAVE.Replace(",", "")
            FCLAVE = FCLAVE.Replace("'", "")

            Select Case fTABLA
                Case "CVE_CONCEP"
                    SQL = "SELECT CONCEP AS DES, ISNULL(IVA,0) AS IV FROM BCONCEP WHERE CVE_CONCEP = '" & FCLAVE & "'"
                Case "FORMAPAGOSAT"
                    SQL = "SELECT descripcion as DES FROM tblcformapago WHERE formaPago = '" & FCLAVE & "'"
                Case "BENEF"
                    SQL = "SELECT NOMBRE AS DES FROM BBENEF WHERE CLAVE = '" & FCLAVE & "'"
            End Select
            If SQL.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CADENA = dr("DES").ToString
                            If fTABLA = "CVE_CONCEP" Then
                                Var6 = dr("IV")
                            End If
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & fTABLA & vbNewLine & SQL)
        End Try

        Return CADENA

    End Function

    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES"
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " -- " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select

        Return Num2Text
    End Function

End Module
