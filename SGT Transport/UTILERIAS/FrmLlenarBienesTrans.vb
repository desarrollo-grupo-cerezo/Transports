Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports C1.Win.C1Command

Public Class FrmLlenarBienesTrans
	Private Sub FrmLlenarBienesTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Me.CenterToScreen()

		CboMatPeligroso.Items.Add("Sí")
		CboMatPeligroso.Items.Add("No")

		CboMatPeligroso.SelectedIndex = 1
		PanelMatPeligro.Visible = False

	End Sub

	Private Sub FrmLlenarBienesTrans_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
		Me.Dispose()
	End Sub

	Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
		Dim j As Integer = 0

		Me.Cursor = Cursors.WaitCursor

		Try
			Using cmd As SqlCommand = cnSAE.CreateCommand
				SQL = "SELECT CVE_ART FROM INVE" & Empresa
				cmd.CommandText = SQL
				Using dr As SqlDataReader = cmd.ExecuteReader
					While dr.Read

						Application.DoEvents()

						Try
							SQL = "IF NOT EXISTS (SELECT CVE_ART FROM INVE_CP WHERE CVE_ART = '" & dr("CVE_ART") & "')
									INSERT INTO INVE_CP (CVE_ART, MAT_PELIGROSO, CVE_MAT_PELIGROSO, EMBALAJE, UNIDADPESO, BIENESTRANSP) VALUES ('" &
									dr("CVE_ART") & "','" & CboMatPeligroso.SelectedIndex & "','" & TCveMaterialPeligroso.Text & "','" & TEmbalaje.Text & "','" &
									"KGM','" & TBienesTransp.Text & "')
								ELSE
									UPDATE INVE_CP SET MAT_PELIGROSO = '" & CboMatPeligroso.SelectedIndex & "', CVE_MAT_PELIGROSO = '" & TCveMaterialPeligroso.Text & "', 
									EMBALAJE = '" & TEmbalaje.Text & "', UNIDADPESO = 'KGM', BIENESTRANSP = '" & TBienesTransp.Text & "'
									WHERE CVE_ART = '" & dr("CVE_ART") & "'"

							Using cmd2 As SqlCommand = cnSAE.CreateCommand
								cmd2.CommandText = SQL
								returnValue = cmd2.ExecuteNonQuery().ToString
								If returnValue IsNot Nothing Then
									If returnValue = "1" Then

										j += 1
										Lt2.Text = j
									End If
								End If
							End Using
						Catch ex As Exception
							Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
							MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
						End Try

					End While
				End Using
			End Using
			MsgBox("Proceso terminado")

		Catch ex As Exception
			Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
		End Try

		Me.Cursor = Cursors.Default


	End Sub
	Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
		Me.Close()
	End Sub
	Private Sub BtnUnidadPeso_Click(sender As Object, e As EventArgs) Handles BtnUnidadPeso.Click
		Try
			Var2 = "tblcclaveunidadpeso"
			Var4 = ""
			Var5 = ""
			FrmSelItemCFDI.ShowDialog()
			If Var4.Trim.Length > 0 Then
				TUnidadPeso.Text = Var4
				LTUnidadPeso.Text = Var5
				TBienesTransp.Focus()
			End If
		Catch ex As Exception
			Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub
	Private Sub TUnidadPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles TUnidadPeso.KeyDown
		If e.KeyCode = Keys.F2 Then
			BtnUnidadPeso_Click(Nothing, Nothing)
		End If
	End Sub
	Private Sub TUnidadPeso_Validated(sender As Object, e As EventArgs) Handles TUnidadPeso.Validated
		Try
			If TUnidadPeso.Text.Trim.Length > 0 Then
				Using cmd As SqlCommand = cnSAE.CreateCommand
					SQL = "SELECT * FROM tblcclaveunidadpeso WHERE clave = '" & TUnidadPeso.Text & "'"
					cmd.CommandText = SQL
					Using dr As SqlDataReader = cmd.ExecuteReader
						If dr.Read Then
							LTUnidadPeso.Text = dr("nombre")
							TBienesTransp.Focus()
						Else
							MsgBox("Unidad de peso inexistente")
							LTUnidadPeso.Text = ""
						End If
					End Using
				End Using
			Else
				LTUnidadPeso.Text = ""
			End If
		Catch ex As Exception
			Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub
	Private Sub BtnBienesTransp_Click(sender As Object, e As EventArgs) Handles BtnBienesTransp.Click
		Try
			Prosec = "CATINV"
			FrmNewXCategoria.ShowDialog()
			If Var10.Trim.Length > 0 Then
				'Var10 = Linea
				'Var11 = Descr
				'Var12 = Descr2
				TBienesTransp.Text = Var10
				LTBienesTransp.Text = Var11
				CboMatPeligroso.Focus()
			End If
		Catch ex As Exception
			Bitacora("1320. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub
	Private Sub TBienesTransp_KeyDown(sender As Object, e As KeyEventArgs) Handles TBienesTransp.KeyDown
		If e.KeyCode = Keys.F2 Then
			BtnBienesTransp_Click(Nothing, Nothing)
		End If
	End Sub
	Private Sub TBienesTransp_Validated(sender As Object, e As EventArgs) Handles TBienesTransp.Validated
		Try
			If TBienesTransp.Text.Trim.Length > 0 Then
				COLOCA_BIENES_TRANSP()
			Else
				LTBienesTransp.Text = ""
			End If
		Catch ex As Exception
			Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub
	Sub COLOCA_BIENES_TRANSP()
		Try
			If TBienesTransp.Text.Trim.Length > 0 Then
				Using cmd As SqlCommand = cnSAE.CreateCommand
					SQL = "SELECT * FROM SAT_CLAVEPROD_SERVCP WHERE CLAVE_PROD = '" & TBienesTransp.Text & "'"
					cmd.CommandText = SQL
					Using dr As SqlDataReader = cmd.ExecuteReader
						If dr.Read Then
							LTBienesTransp.Text = dr("DESCR")
							CboMatPeligroso.Focus()
						Else
							MsgBox("Bienes transporte inexistente")
							LTBienesTransp.Text = ""
						End If
					End Using
				End Using
			End If
		Catch ex As Exception
			Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub
	Private Sub BtnCveMaterialPeligroso_Click(sender As Object, e As EventArgs) Handles BtnCveMaterialPeligroso.Click
		Try
			Var2 = "tblcmaterialpeligroso"
			Var4 = ""
			Var5 = ""
			FrmSelItemCFDI.ShowDialog()
			If Var4.Trim.Length > 0 Then
				TCveMaterialPeligroso.Text = Var4
				LTCveMaterialPeligroso.Text = Var5
				TEmbalaje.Focus()
			End If
		Catch ex As Exception
			Bitacora("1300. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub

	Private Sub TCveMaterialPeligroso_KeyDown(sender As Object, e As KeyEventArgs) Handles TCveMaterialPeligroso.KeyDown
		If e.KeyCode = Keys.F2 Then
			BtnCveMaterialPeligroso_Click(Nothing, Nothing)
		End If
	End Sub

	Private Sub TCveMaterialPeligroso_Validated(sender As Object, e As EventArgs) Handles TCveMaterialPeligroso.Validated
		Try
			If TCveMaterialPeligroso.Text.Trim.Length > 0 Then
				LTCveMaterialPeligroso.Text = GET_MAT_PELIGROSO(TCveMaterialPeligroso.Text, "S")
			Else
				LTCveMaterialPeligroso.Text = ""
			End If
		Catch ex As Exception
			Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub

	Private Sub BtnEmbalaje_Click(sender As Object, e As EventArgs) Handles BtnEmbalaje.Click
		Try
			Var2 = "tblctipoembalaje"
			Var4 = ""
			Var5 = ""
			FrmSelItemCFDI.ShowDialog()
			If Var4.Trim.Length > 0 Then
				TEmbalaje.Text = Var4
				LTEmbalaje.Text = Var5
			End If
		Catch ex As Exception
			Bitacora("1290. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1290. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub

	Private Sub TEmbalaje_KeyDown(sender As Object, e As KeyEventArgs) Handles TEmbalaje.KeyDown
		If e.KeyCode = Keys.F2 Then
			BtnEmbalaje_Click(Nothing, Nothing)
		End If
		If e.KeyCode = 13 Then
			TUnidadPeso.Focus()
		End If
	End Sub

	Private Sub TEmbalaje_Validated(sender As Object, e As EventArgs) Handles TEmbalaje.Validated
		Try
			If TEmbalaje.Text.Trim.Length > 0 Then
				LTEmbalaje.Text = GET_MAT_EMBALAJE(TEmbalaje.Text)
			Else
				LTEmbalaje.Text = ""
			End If
		Catch ex As Exception
			Bitacora("1400. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1400. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub

	Private Sub CboMatPeligroso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMatPeligroso.SelectedIndexChanged
		Try
			If CboMatPeligroso.SelectedIndex = 0 Then
				PanelMatPeligro.Visible = True
			Else
				PanelMatPeligro.Visible = False
			End If
		Catch ex As Exception
			Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try

	End Sub
End Class