Imports System.Xml
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmProductos
    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            Me.WindowState = FormWindowState.Maximized

            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 11

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(Int32)

            Fg(0, 2) = "Descripción"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Estatus"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Cuenta contable"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Unidad peso"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Bienes transporte"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Material peligroso"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Descripcion material peligroso"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Embalaje"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

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
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE
            Dim ArchivoXml As String

            ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_PROD_SERV.xml"

            Dim xmlFile As XmlReader
            xmlFile = XmlReader.Create(ArchivoXml, New XmlReaderSettings())
            Dim ds As New DataSet
            ds.ReadXml(xmlFile)

            Fg.Redraw = False

            SQL = "SELECT P.CVE_PROD, P.DESCR, P.STATUS, P.CUEN_CONT, UP.nombre as NOMBRE_UNIDADPESO, B.DESCR AS DESCR_BIENESTRANSP, 
                CASE WHEN ISNULL(MAT_PELIGROSO,-1) = 0 THEN 'Sí' ELSE 'No' END AS MAT_PELI,
                M.descripcion AS DESCR_MAT_PELI, E.descripcion AS DESCR_EMBALAJE
                FROM GCPRODUCTOS P
                LEFT JOIN tblcmaterialpeligroso M ON M.clave = CVE_MAT_PELIGROSO
                LEFT JOIN SAT_CLAVEPROD_SERVCP B ON B.CLAVE_PROD = BIENESTRANSP
                LEFT JOIN tblcclaveunidadpeso UP ON UP.clave = UNIDADPESO
                LEFT JOIN tblctipoembalaje E ON E.clave = EMBALAJE
                WHERE P.STATUS = 'A' ORDER BY P.CVE_PROD"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Fg.Rows.Count = 1
            Do While dr.Read

                Fg.AddItem("" & vbTab & dr("CVE_PROD") & vbTab & dr("DESCR") & vbTab &
                           dr("STATUS") & vbTab & dr("CUEN_CONT") & vbTab & dr("NOMBRE_UNIDADPESO") & vbTab &
                           dr("DESCR_BIENESTRANSP") & vbTab & dr("MAT_PELI") & vbTab & dr("DESCR_MAT_PELI") & vbTab &
                           dr("DESCR_EMBALAJE"))
            Loop
            dr.Close()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub

    Private Sub FrmProductos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Productos")
        Me.Dispose()
    End Sub

    Private Sub FrmProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    BarNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    BarEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmProductosAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            frmProductosAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCPRODUCTOS SET STATUS = 'B' WHERE CVE_PROD = " & Fg(Fg.Row, 1)
                Dim cmd As New SqlCommand With {
                    .Connection = cnSAE,
                    .CommandText = SQL
                }
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
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
