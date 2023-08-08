Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmSelGasolineras
    Private CVE_PROV As String
    Public Sub New(fCVE_PROV As String)

        InitializeComponent()
        CVE_PROV = fCVE_PROV

    End Sub

    Private Sub FrmSelGasolineras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            BarraMenu.BackColor = Color.FromArgb(164, 177, 202)
        Catch ex As Exception
        End Try
        Try
            C1List1.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT A.CVE_GAS, MAX(G.DESCR) AS DES 
                    FROM GCASIGNACION_VIAJE_VALES A
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = A.CVE_GAS
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV
                    WHERE A.STATUS <> 'C' AND G.CVE_PROV = '" & CVE_PROV & "' AND 
                    A.ST_VALES = 'ACEPTADO' AND ISNULL(A.CONCILIADO,0) = 0 
                    GROUP BY A.CVE_GAS
                    ORDER BY TRY_CAST(A.CVE_GAS AS INT)"

                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_GAS") & ";" & dr("DES"))
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT A.CVE_GAS, MAX(G.DESCR) AS DES 
                    FROM GCASIGNACION_VALES_UTIL A
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = A.CVE_GAS
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV
                    WHERE G.CVE_PROV = '" & CVE_PROV & "' AND A.ST_VALES = 'ACEPTADO' AND ISNULL(A.CONCILIADO,0) = 0 
                    GROUP BY A.CVE_GAS
                    ORDER BY A.CVE_GAS"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_GAS") & ";" & dr("DES"))
                    End While
                End Using
            End Using

            Me.C1List1.Splits(0).DisplayColumns(0).Width = 50

            Me.CenterToScreen()
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmSelGasolineras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click
        Try
            Dim j As Integer = 0
            VarFORM = ""
            Var4 = ""
            For row As Integer = 0 To C1List1.ListCount - 1
                Dim cellValue As Object = C1List1.GetDisplayText(row, 0)

                If C1List1.GetSelected(row) Then
                    VarFORM = VarFORM & "A.CVE_GAS = '" & cellValue.ToString & "' OR "
                    Var4 = Var4 & cellValue.ToString & ", "
                    j = j + 1
                End If
            Next
            If j = 0 Then
                MsgBox("Por favor seleccione al menos una gasolinera")
            Else
                Var4 = Var4.Substring(0, Var4.Length - 2)
                VarFORM = " AND (" & VarFORM.Substring(0, VarFORM.Length - 4) & ")"
                Me.Close()
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
