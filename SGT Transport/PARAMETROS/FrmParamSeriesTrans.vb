Imports System.Data.SqlClient
Public Class FrmParamSeriesTrans
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private Sub frmParamTransport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        tTIP_DOC.MaxLength = 30
        tSERIE.MaxLength = 10
        Try
            SQL = "SELECT TIP_DOC as 'Tipo documento', FOLIODESDE as 'Folio desde', FOLIOHASTA 'Folio hasta', SERIE as 'Serie', 
                ULT_DOC AS 'Ult. Documento' FROM GCFOLIOS ORDER BY TIP_DOC"
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt

            Fg.DataSource = BindingSource1.DataSource

            Fg.AutoSizeCols()

        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub

    Private Sub frmParamTransport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab2("Series")
        Me.Dispose()
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Gpo.Visible = True
            tTIP_DOC.Text = ""
            tSERIE.Text = "STAND."
            tFOLIODESDE.Text = "0"
            tFOLIOHASTA.Text = "0"
            tULTDOC.Text = "0"
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If tTIP_DOC.Text.Trim.Length = 0 Then
            MsgBox("El tipo doc no debe quedar vacia, verifique por favor")
            Return
        End If

        If tSERIE.Text.Trim.Length = 0 Then
            MsgBox("La serie no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCFOLIOS SET FOLIODESDE = @FOLIODESDE, FOLIOHASTA = @FOLIOHASTA, ULT_DOC = @ULT_DOC
            WHERE TIP_DOC = @TIP_DOC AND SERIE = @SERIE
            IF @@ROWCOUNT = 0
            INSERT INTO GCFOLIOS (TIP_DOC, FOLIODESDE, FOLIOHASTA, SERIE, ULT_DOC, STATUS) VALUES(@TIP_DOC, @FOLIODESDE, 
            @FOLIOHASTA, @SERIE, @ULT_DOC, 'A')"
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            cmd.Parameters.Add("@TIP_DOC", SqlDbType.VarChar).Value = tTIP_DOC.Text
            cmd.Parameters.Add("@FOLIODESDE", SqlDbType.Int).Value = CONVERTIR_TO_INT(tFOLIODESDE.Text)
            cmd.Parameters.Add("@FOLIOHASTA", SqlDbType.Int).Value = CONVERTIR_TO_INT(tFOLIOHASTA.Text)
            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = IIf(tSERIE.Text.Trim = "", "STAND.", tSERIE.Text)
            cmd.Parameters.Add("@ULT_DOC", SqlDbType.Int).Value = CONVERTIR_TO_INT(tULTDOC.Text)
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Gpo.Visible = False
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Gpo.Visible = False
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Gpo.Visible = True
        Try
            tTIP_DOC.Text = Fg(Fg.Row, 1)
            tFOLIODESDE.Text = Fg(Fg.Row, 2)
            tFOLIOHASTA.Text = Fg(Fg.Row, 3)
            tSERIE.Text = Fg(Fg.Row, 4)
            tULTDOC.Text = Fg(Fg.Row, 5)
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub
End Class
