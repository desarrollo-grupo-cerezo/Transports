Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmCasetasXRuta
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmCasetasXRuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try

            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1
            Fg.Cols.Count = 13

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150


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
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT C.CVE_CXR, C.STATUS, C.CVE_PLAZA, C.CVE_PLAZA2, P1.CIUDAD AS CIUDAD1, P2.CIUDAD AS CIUDAD2, IMPORTE_CASETAS
                FROM GCCASETAS_X_RUTA C 
                LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA 
                LEFT JOIN GCPLAZAS P2 On P2.CLAVE = C.CVE_PLAZA2
                WHERE C.STATUS = 'A' ORDER BY CVE_CXR"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Clave"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Int32)

            Fg(0, 4) = "Origen"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Clave"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Int32)

            Fg(0, 6) = "Destino"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Importe casetas"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            c7.Format = "N2"
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCasetasXRuta_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Casetas por ruta")
        Me.Dispose()
    End Sub
    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"

            FrmCasetasXRutaAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            FrmCasetasXRutaAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCCASETAS_X_RUTA SET STATUS = 'B' WHERE CVE_CXR = " & Fg(Fg.Row, 1)
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se elimino satisfactoriamente")
                        DESPLEGAR()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
