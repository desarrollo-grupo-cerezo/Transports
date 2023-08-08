Imports C1.Win.C1Themes
Imports CSJ2K.j2k.io
Imports System.Data.SqlClient
Public Class FrmActivosAE
	Private Sub frmCapturaDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Try
			Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
			C1ThemeController.ApplyThemeToControlTree(Me, theme)

			Me.VisualStyle = True
			Me.KeyPreview = True

		Catch ex As Exception
		End Try

		Try
			TFECINIDEP.Value = Date.Today
			TFECINIDEP.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECINIDEP.CustomFormat = "dd/MM/yyyy"
			TFECINIDEP.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECINIDEP.EditFormat.CustomFormat = "dd/MM/yyyy"

			TFECHAADQ.Value = Date.Today
			TFECHAADQ.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECHAADQ.CustomFormat = "dd/MM/yyyy"
			TFECHAADQ.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECHAADQ.EditFormat.CustomFormat = "dd/MM/yyyy"

			TFECINIDEPF.Value = Date.Today
			TFECINIDEPF.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECINIDEPF.CustomFormat = "dd/MM/yyyy"
			TFECINIDEPF.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECINIDEPF.EditFormat.CustomFormat = "dd/MM/yyyy"

			TFECVIGENC.Value = Date.Today
			TFECVIGENC.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECVIGENC.CustomFormat = "dd/MM/yyyy"
			TFECVIGENC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECVIGENC.EditFormat.CustomFormat = "dd/MM/yyyy"

			TFECULTMAN.Value = Date.Today
			TFECULTMAN.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECULTMAN.CustomFormat = "dd/MM/yyyy"
			TFECULTMAN.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECULTMAN.EditFormat.CustomFormat = "dd/MM/yyyy"

			TFECPROXMA.Value = Date.Today
			TFECPROXMA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECPROXMA.CustomFormat = "dd/MM/yyyy"
			TFECPROXMA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
			TFECPROXMA.EditFormat.CustomFormat = "dd/MM/yyyy"

			BtnTipoActivo.FlatStyle = FlatStyle.Flat
			BtnTipoActivo.FlatAppearance.BorderSize = 0
			BtnDepto.FlatStyle = FlatStyle.Flat
			BtnDepto.FlatAppearance.BorderSize = 0
			Tab1.Dock = DockStyle.Fill

			TMONTORIG.Value = 0
			TMAXDED.Value = 0
			TVALMER.Value = 0
			TDEPACU.Value = 0
			TVIDAUT.Value = 0

			TTASDEP.Value = 0

			TTASDEPFIS.Value = 0
			TDEPACUFISC.Value = 0
			TMONTOASEG.Value = 0
			TPRIMATOTA.Value = 0
			TDEDUCIBLE.Value = 0
			TCOSTOMANT.Value = 0
			TTELSINIES.Value = ""

			CBOPERIODOMA.Items.Add("Sin mantto.")
			CBOPERIODOMA.Items.Add("Enero")
			CBOPERIODOMA.Items.Add("Febrero")
			CBOPERIODOMA.Items.Add("Marzo")
			CBOPERIODOMA.Items.Add("Abril")
			CBOPERIODOMA.Items.Add("Mayo")
			CBOPERIODOMA.Items.Add("Junio")
			CBOPERIODOMA.Items.Add("Julio")
			CBOPERIODOMA.Items.Add("Agosto")
			CBOPERIODOMA.Items.Add("Septiembre")
			CBOPERIODOMA.Items.Add("Octubre")
			CBOPERIODOMA.Items.Add("Noviembre")
			CBOPERIODOMA.Items.Add("Diciembre")

			CBOPERIODOMA.SelectedIndex = 0

		Catch ex As Exception
		End Try

		If Var1 = "Nuevo" Then
			Try
				TCLAVE.Text = GET_MAX("GCACTIVOS", "CLAVE")
				TCLAVE.Enabled = False
				TDESCRIP.Text = ""
				TDESCRIP.Select()
			Catch ex As Exception
				MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
				Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
			End Try
		Else
			TCLAVE.Text = Var2
			Try
				Using cmd As SqlCommand = cnSAE.CreateCommand
					SQL = "SELECT CLAVE, TIPO, DESCRIP, LOCALIZ, MONTORIG, MONTORIGEX, FECHAADQ, MAXDED, VALMER, DEPACU, 
						VIDAUT, METDEP, TASDEP, TASDEPFIS, STATUS, NUMDEPTO, NUMSERIE, FECINIDEP, BANDEDINM,
						FECINIDEPF, DEPACUFISC, OBSERVACIO, TIPOCAMBIO, POLIZASEG, COMPASEGU, AGENTESEG, TELSINIES, TIPOCOBER, 
						MONTOASEG, PRIMATOTA, DEDUCIBLE, FECVIGENC, FECPROXMA, FECULTMAN, PERIODOMA, COSTOMANT, RESPACTFIJO
						FROM GCACTIVOS WHERE CLAVE = '" & Var2 & "'"
					cmd.CommandText = SQL
					Using dr As SqlDataReader = cmd.ExecuteReader
						If dr.Read Then
							Try
								TDESCRIP.Text = dr.ReadNullAsEmptyString("DESCRIP")
								TLOCALIZ.Text = dr.ReadNullAsEmptyString("LOCALIZ")
								TMONTORIG.Value = dr("MONTORIG")
								If IsDate(dr.ReadNullAsEmptyString("FECHAADQ")) Then
									TFECHAADQ.Value = dr.ReadNullAsEmptyString("FECHAADQ")
								End If
								TMAXDED.Value = dr("MAXDED")
								TVALMER.Value = dr("VALMER")
								TDEPACU.Value = dr("DEPACU")
								TVIDAUT.Value = dr("VIDAUT")
								TTASDEP.Value = dr("TASDEP")
								TTASDEPFIS.Value = dr("TASDEPFIS")

								TNUMDEPTO.Text = dr.ReadNullAsEmptyInteger("NUMDEPTO")
								If TNUMDEPTO.Text.Trim.Length > 0 Then
									LtDepto.Text = BUSCA_CAT("Depto", TNUMDEPTO.Text)
								End If

								TTIPO_ACTIVO.Text = dr("TIPO")
								If TTIPO_ACTIVO.Text.Trim.Length > 0 Then
									LtActivo.Text = BUSCA_CAT("TipoActivo", TTIPO_ACTIVO.Text)
								End If

								TNUMSERIE.Text = dr.ReadNullAsEmptyString("NUMSERIE")
								Try
									If Not IsNothing(dr.ReadNullAsEmptyString("FECINIDEP")) Then
										If IsDate(dr.ReadNullAsEmptyString("FECINIDEP")) Then
											TFECINIDEP.Value = dr("FECINIDEP")
										End If
									End If

									If dr("BANDEDINM") = "S" Then
										CHBANDEDINM.Checked = True
									Else
										CHBANDEDINM.Checked = False
									End If
								Catch ex As Exception
									Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
								End Try

								If IsDate(dr.ReadNullAsEmptyString("FECINIDEPF")) Then
									TFECINIDEPF.Value = dr.ReadNullAsEmptyString("FECINIDEPF")
								End If
								TDEPACUFISC.Value = dr("DEPACUFISC")
								TOBSERVACIO.Text = dr.ReadNullAsEmptyString("OBSERVACIO")
								TPOLIZASEG.Text = dr.ReadNullAsEmptyString("POLIZASEG")
								TCOMPASEGU.Text = dr.ReadNullAsEmptyString("COMPASEGU")
								TAGENTESEG.Text = dr.ReadNullAsEmptyString("AGENTESEG")
								TTELSINIES.Value = dr.ReadNullAsEmptyString("TELSINIES")
								TTIPOCOBER.Text = dr.ReadNullAsEmptyString("TIPOCOBER")
								TMONTOASEG.Value = dr("MONTOASEG")
								TPRIMATOTA.Value = dr("PRIMATOTA")
								TDEDUCIBLE.Value = dr("DEDUCIBLE")

								If IsDate(dr("FECVIGENC")) Then
									TFECVIGENC.Value = dr("FECVIGENC")
								End If
								If IsDate(dr("FECPROXMA")) Then
									TFECPROXMA.Value = dr("FECPROXMA")
								End If
								If IsDate(dr("FECULTMAN")) Then
									TFECULTMAN.Value = dr("FECULTMAN")
								End If

								CBOPERIODOMA.SelectedIndex = dr.ReadNullAsEmptyInteger("PERIODOMA")

								TCOSTOMANT.Value = dr("COSTOMANT")
								TRESPACTFIJO.Text = dr.ReadNullAsEmptyString("RESPACTFIJO")
							Catch ex As Exception
								Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
								MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
							End Try
						End If
					End Using
				End Using
				TDESCRIP.Select()
			Catch ex As Exception
				Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
				MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
			End Try
		End If
	End Sub
	Private Sub FrmActivosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
		If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
			SendKeys.Send("{TAB}")
			e.Handled = True
		End If
	End Sub
	Private Sub FrmCapturaDatos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
		Me.Dispose()
	End Sub
	Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click

		If MsgBox("Realmente desea grabar la información?", vbYesNo) = vbNo Then
			Return
		End If
		Dim TIPO As Integer

		Try
			TMONTORIG.UpdateValueWithCurrentText()
			TMAXDED.UpdateValueWithCurrentText()
			TVALMER.UpdateValueWithCurrentText()
			TDEPACU.UpdateValueWithCurrentText()
			TTASDEP.UpdateValueWithCurrentText()

			TTASDEPFIS.UpdateValueWithCurrentText()
			TDEPACUFISC.UpdateValueWithCurrentText()
			TMONTOASEG.UpdateValueWithCurrentText()
			TPRIMATOTA.UpdateValueWithCurrentText()
			TDEDUCIBLE.UpdateValueWithCurrentText()
			TCOSTOMANT.UpdateValueWithCurrentText()
			'TTELSINIES.UpdateValueWithCurrentText()
		Catch ex As Exception
			Bitacora("240. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
		End Try
		If IsNumeric(TTIPO_ACTIVO.Text.Trim) Then
			TIPO = TTIPO_ACTIVO.Text.Trim
		Else
			TIPO = 0
		End If

		Try
			SQL = "UPDATE GCACTIVOS SET DESCRIP = @DESCRIP, LOCALIZ = @LOCALIZ, MONTORIG = @MONTORIG, 
				FECHAADQ = @FECHAADQ, MAXDED = @MAXDED, VALMER = @VALMER, DEPACU = @DEPACU, VIDAUT = @VIDAUT,
				TASDEP = @TASDEP, TASDEPFIS = @TASDEPFIS, NUMDEPTO = @NUMDEPTO, NUMSERIE = @NUMSERIE, BANDEDINM = @BANDEDINM,
				FECINIDEP = @FECINIDEP, FECINIDEPF = @FECINIDEPF, DEPACUFISC = @DEPACUFISC, OBSERVACIO = @OBSERVACIO, 
				POLIZASEG = @POLIZASEG, COMPASEGU = @COMPASEGU, AGENTESEG = @AGENTESEG, TELSINIES = @TELSINIES, TIPOCOBER = @TIPOCOBER, 
				MONTOASEG = @MONTOASEG, PRIMATOTA = @PRIMATOTA, DEDUCIBLE = @DEDUCIBLE, FECVIGENC = @FECVIGENC, FECPROXMA = @FECPROXMA, 
				FECULTMAN = @FECULTMAN, PERIODOMA = @PERIODOMA, COSTOMANT = @COSTOMANT, RESPACTFIJO = @RESPACTFIJO
				WHERE CLAVE = @CLAVE
				If @@ROWCOUNT = 0
				INSERT INTO GCACTIVOS (CLAVE, STATUS, TIPO, DESCRIP, LOCALIZ, MONTORIG, FECHAADQ, MAXDED, VALMER, DEPACU, VIDAUT, TASDEP,
				TASDEPFIS, NUMDEPTO, NUMSERIE, FECINIDEP, FECINIDEPF, DEPACUFISC, OBSERVACIO, POLIZASEG, COMPASEGU, AGENTESEG, TELSINIES, 
				TIPOCOBER, MONTOASEG, PRIMATOTA, DEDUCIBLE, FECVIGENC, FECPROXMA, FECULTMAN, PERIODOMA, COSTOMANT, RESPACTFIJO, BANDEDINM)
				VALUES (@CLAVE, 'A', @TIPO, @DESCRIP, @LOCALIZ, @MONTORIG, @FECHAADQ, @MAXDED, @VALMER, @DEPACU, @VIDAUT, @TASDEP, @TASDEPFIS, 
				@NUMDEPTO, @NUMSERIE, @FECINIDEP, @FECINIDEPF, @DEPACUFISC, @OBSERVACIO, @POLIZASEG, @COMPASEGU, @AGENTESEG, @TELSINIES, 
				@TIPOCOBER, @MONTOASEG, @PRIMATOTA, @DEDUCIBLE, @FECVIGENC, @FECPROXMA, @FECULTMAN, @PERIODOMA, @COSTOMANT, @RESPACTFIJO, @BANDEDINM)"
			Using cmd As SqlCommand = cnSAE.CreateCommand
				cmd.CommandText = SQL
				cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCLAVE.Text
				cmd.Parameters.Add("@TIPO", SqlDbType.SmallInt).Value = TIPO
				cmd.Parameters.Add("@DESCRIP", SqlDbType.VarChar).Value = TDESCRIP.Text
				cmd.Parameters.Add("@LOCALIZ", SqlDbType.VarChar).Value = TLOCALIZ.Text
				cmd.Parameters.Add("@MONTORIG", SqlDbType.Float).Value = TMONTORIG.Value
				cmd.Parameters.Add("@FECHAADQ", SqlDbType.DateTime).Value = TFECHAADQ.Text
				cmd.Parameters.Add("@MAXDED", SqlDbType.Float).Value = TMAXDED.Value
				cmd.Parameters.Add("@VALMER", SqlDbType.Float).Value = TVALMER.Value
				cmd.Parameters.Add("@DEPACU", SqlDbType.Float).Value = TDEPACU.Value
				cmd.Parameters.Add("@VIDAUT", SqlDbType.Float).Value = TVIDAUT.Value
				cmd.Parameters.Add("@TASDEP", SqlDbType.Float).Value = TTASDEP.Value
				cmd.Parameters.Add("@TASDEPFIS", SqlDbType.Float).Value = TTASDEPFIS.Value
				cmd.Parameters.Add("@NUMDEPTO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TNUMDEPTO.Text)
				cmd.Parameters.Add("@NUMSERIE", SqlDbType.VarChar).Value = TNUMSERIE.Text
				cmd.Parameters.Add("@FECINIDEP", SqlDbType.DateTime).Value = TFECINIDEP.Text
				cmd.Parameters.Add("@FECINIDEPF", SqlDbType.DateTime).Value = TFECINIDEPF.Text
				cmd.Parameters.Add("@DEPACUFISC", SqlDbType.Float).Value = TDEPACUFISC.Value
				cmd.Parameters.Add("@OBSERVACIO", SqlDbType.VarChar).Value = TOBSERVACIO.Text
				cmd.Parameters.Add("@POLIZASEG", SqlDbType.VarChar).Value = TPOLIZASEG.Text
				cmd.Parameters.Add("@COMPASEGU", SqlDbType.VarChar).Value = TCOMPASEGU.Text
				cmd.Parameters.Add("@AGENTESEG", SqlDbType.VarChar).Value = TAGENTESEG.Text
				cmd.Parameters.Add("@TELSINIES", SqlDbType.VarChar).Value = TTELSINIES.Value
				cmd.Parameters.Add("@TIPOCOBER", SqlDbType.VarChar).Value = TTIPOCOBER.Text
				cmd.Parameters.Add("@MONTOASEG", SqlDbType.Float).Value = TMONTOASEG.Value
				cmd.Parameters.Add("@PRIMATOTA", SqlDbType.Float).Value = TPRIMATOTA.Value
				cmd.Parameters.Add("@DEDUCIBLE", SqlDbType.Float).Value = TDEDUCIBLE.Value
				cmd.Parameters.Add("@FECVIGENC", SqlDbType.DateTime).Value = TFECVIGENC.Text
				cmd.Parameters.Add("@FECPROXMA", SqlDbType.DateTime).Value = TFECPROXMA.Text
				cmd.Parameters.Add("@FECULTMAN", SqlDbType.DateTime).Value = TFECULTMAN.Text
				cmd.Parameters.Add("@PERIODOMA", SqlDbType.SmallInt).Value = CBOPERIODOMA.SelectedIndex
				cmd.Parameters.Add("@COSTOMANT", SqlDbType.Float).Value = TCOSTOMANT.Value
				cmd.Parameters.Add("@RESPACTFIJO", SqlDbType.VarChar).Value = TRESPACTFIJO.Text
				cmd.Parameters.Add("@BANDEDINM", SqlDbType.VarChar).Value = IIf(CHBANDEDINM.Checked, "S", "N")
				returnValue = cmd.ExecuteNonQuery().ToString
				If returnValue IsNot Nothing Then
					If returnValue = "1" Then
						MsgBox("El activo se grabo correctamente")
						Me.Close()
					End If
				End If
			End Using
		Catch ex As Exception
			MsgBox("410. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
			Bitacora("240. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
		End Try

	End Sub
	Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
		Me.Close()
	End Sub

	Private Sub BtnTipoActivo_Click(sender As Object, e As EventArgs) Handles BtnTipoActivo.Click
		Try
			Var2 = "TipoActivo"
			Var4 = ""
			Var5 = ""
			FrmSelItem2.ShowDialog()
			If Var4.Trim.Length > 0 Then
				TTIPO_ACTIVO.Text = Var4
				LtActivo.Text = Var5
				TLOCALIZ.Focus()
			End If
		Catch ex As Exception
			Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub
	Private Sub TTIPO_ACTIVO_KeyDown(sender As Object, e As KeyEventArgs) Handles TTIPO_ACTIVO.KeyDown
		If e.KeyCode = Keys.F2 Then
			BtnTipoActivo_Click(Nothing, Nothing)
		End If
	End Sub
	Private Sub TTIPO_ACTIVO_Validated(sender As Object, e As EventArgs) Handles TTIPO_ACTIVO.Validated
		Try
			If TTIPO_ACTIVO.Text.Trim.Length > 0 Then
				Using cmd As SqlCommand = cnSAE.CreateCommand
					SQL = "SELECT DESCRIP FROM GCTIPACTIV WHERE CLAVE = '" & TTIPO_ACTIVO.Text & "'"
					cmd.CommandText = SQL
					Using dr As SqlDataReader = cmd.ExecuteReader
						If dr.Read Then
							LtActivo.Text = dr("DESCRIP")
						Else
							MsgBox("Tipo activo inexistente")
							LtActivo.Text = ""
						End If
					End Using
				End Using
			Else
				LtActivo.Text = ""
			End If
		Catch ex As Exception
			Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub

	Private Sub BtnDepto_Click(sender As Object, e As EventArgs) Handles BtnDepto.Click
		Try
			Var2 = "Depto"
			Var4 = ""
			Var5 = ""
			FrmSelItem2.ShowDialog()
			If Var4.Trim.Length > 0 Then
				TNUMDEPTO.Text = Var4
				LtDepto.Text = Var5
				TNUMSERIE.Focus()
			End If
		Catch ex As Exception
			Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub

	Private Sub TNUMDEPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TNUMDEPTO.KeyDown
		If e.KeyCode = Keys.F2 Then
			BtnDepto_Click(Nothing, Nothing)
		End If
	End Sub

	Private Sub TNUMDEPTO_Validated(sender As Object, e As EventArgs) Handles TNUMDEPTO.Validated
		Try
			If TNUMDEPTO.Text.Trim.Length > 0 Then
				Using cmd As SqlCommand = cnSAE.CreateCommand
					SQL = "SELECT DESCR FROM GCDEPTOS WHERE CVE_DEPTO = '" & TNUMDEPTO.Text & "'"
					cmd.CommandText = SQL
					Using dr As SqlDataReader = cmd.ExecuteReader
						If dr.Read Then
							LtDepto.Text = dr("DESCR")
						Else
							MsgBox("Deparatamente inexistente")
							LtDepto.Text = ""
						End If
					End Using
				End Using
			Else
				LtDepto.Text = ""
			End If
		Catch ex As Exception
			Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
			MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
		End Try
	End Sub
End Class
