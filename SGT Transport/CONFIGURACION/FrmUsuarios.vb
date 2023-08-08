Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Command
Imports System.IO

Public Class FrmUSUARIOS
    Private ENTRA As Boolean = True, RUTA_HUELLAS As String, RUTA_FOTOS As String
    Private VF As String = "|", VF2 As String = "|", VV As String = "|", VP As String = "|", VC As String = "|", VR As String = "|", VD As String = "|", VCDP As String = "|", VNC As String = "|", VT As String = "|"
    Private CC As String = "|", CR As String = "|", CO As String = "|", CQ As String = "|", CDC As String = "|", ALM As String = "|", ALMD As String = "|"
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmGCUSUARIOS_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Valida_Conexion_SAROCE() Then
            MsgBox("Imposible conectarse a la base de configuración")
            Me.Close()
            Return
        End If

        Panel1.Top = 0
        Panel1.Left = 0
        Panel1.Height = Me.Height
        Panel1.Width = Me.Width
        Panel1.Visible = False

        ENTRA = True
    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            FgU.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Try
            Using cmd As SqlCommand = cnSAROCE.CreateCommand '
                SQL = "SELECT RUTA_HUELLAS, RUTA_FOTOS FROM CONFIG WHERE EMPRESA = '" & Empresa & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        RUTA_HUELLAS = dr.ReadNullAsEmptyString("RUTA_HUELLAS")
                        RUTA_FOTOS = dr.ReadNullAsEmptyString("RUTA_FOTOS")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try
            AssignValidation(TCLAVE_SAE, ValidationType.Only_Numbers)
            Application.EnableVisualStyles()

            PictureBox5.Tag = ""

            'BtnAceptar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
            'BtnCancelar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue

            FgU.Rows.Count = 1
            FgU.DrawMode = DrawModeEnum.OwnerDraw
            FgU.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill
            Fg2.Dock = DockStyle.Fill
            'Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(TIP_DOC,'') AS TIP, ISNULL(SERIE,'') AS SER,
                        ISNULL(TIPO,0) AS TIPO_DIG
                        FROM FOLIOSF" & Empresa & " 
                        ORDER BY TIP_DOC, SERIE"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("TIP")
                                Case "F"
                                    VF += dr("SER") & "|"
                                    VF2 += dr("SER") & "|"
                                Case "V"
                                    VV += dr("SER") & "|"
                                Case "P"
                                    VP += dr("SER") & "|"
                                Case "C"
                                    VC += dr("SER") & "|"
                                Case "R"
                                    VR += dr("SER") & "|"
                                Case "D"
                                    VD += dr("SER") & "|"
                                Case "E"
                                    VNC += dr("SER") & "|"
                                Case "G"
                                    VCDP += dr("SER") & "|"
                                Case "T"
                                    VT += dr("SER") & "|"
                            End Select
                        End While
                    End Using
                End Using

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(TIP_DOC,'') AS TIP, ISNULL(SERIE,'') AS SER
                        FROM FOLIOSC" & Empresa & " 
                        ORDER BY TIP_DOC, SERIE"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("TIP")
                                Case "c"
                                    CC += dr("SER") & "|"
                                Case "r"
                                    CR += dr("SER") & "|"
                                Case "o"
                                    CO += dr("SER") & "|"
                                Case "q"
                                    CQ += dr("SER") & "|"
                                Case "d"
                                    CDC += dr("SER") & "|"
                            End Select
                        End While
                    End Using
                End Using

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_ALM, DESCR
                        FROM ALMACENES" & Empresa & " 
                        ORDER BY CVE_ALM"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            ALM += Format(dr("CVE_ALM"), "00") & " " & dr("DESCR") & "|"
                            ALMD += Format(dr("CVE_ALM"), "00") & " " & dr("DESCR") & "|"
                        End While
                    End Using
                End Using

                Fg.AddItem("" & vbTab & "F" & vbTab & "Folio facturas" & vbTab & "") '1
                Fg.AddItem("" & vbTab & "V" & vbTab & "Folio notas de venta" & vbTab & "") '2
                Fg.AddItem("" & vbTab & "R" & vbTab & "Folio remisiones" & vbTab & "") '3
                Fg.AddItem("" & vbTab & "P" & vbTab & "Folio pedidos" & vbTab & "") '4
                Fg.AddItem("" & vbTab & "C" & vbTab & "Folio cotizaciones" & vbTab & "") '5
                Fg.AddItem("" & vbTab & "D" & vbTab & "Folio devoluciones" & vbTab & "") '6
                Fg.AddItem("" & vbTab & "G" & vbTab & "Folio comprobantes de pago" & vbTab & "") '7
                Fg.AddItem("" & vbTab & "E" & vbTab & "Folio notas de crédito" & vbTab & "") '8
                Fg.AddItem("" & vbTab & "T" & vbTab & "Folio carta porte traslado" & vbTab & "") '9

                Fg.AddItem("" & vbTab & "c" & vbTab & "Folio compras" & vbTab & "") '10
                Fg.AddItem("" & vbTab & "r" & vbTab & "Folio recepciones" & vbTab & "") '11
                Fg.AddItem("" & vbTab & "o" & vbTab & "Folio ordenes de compra" & vbTab & "") '12
                Fg.AddItem("" & vbTab & "q" & vbTab & "Folio Requisiciones" & vbTab & "") '13
                Fg.AddItem("" & vbTab & "d" & vbTab & "Folio devolución de compras" & vbTab & "") '14
                Fg.AddItem("" & vbTab & "a" & vbTab & "Almacén" & vbTab & "") '15
                Fg.AddItem("" & vbTab & "ad" & vbTab & "Almacén de devolución" & vbTab & "") '16

                Fg.AddItem("" & vbTab & "FG" & vbTab & "Serie factura global" & vbTab & "") '17

                Fg.Cols(1).StarWidth = "*"
                Fg.Cols(2).StarWidth = "3*"
                Fg.Cols(3).StarWidth = "2*"

            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Desplegar()
            FgU.Cols(7).Visible = False
            FgU.Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter
            FgU.Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter
            FgU.Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter
            FgU.Cols(4).TextAlignFixed = TextAlignEnum.CenterCenter
            FgU.Cols(5).TextAlignFixed = TextAlignEnum.CenterCenter
            FgU.Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter
            FgU.Cols(8).TextAlignFixed = TextAlignEnum.CenterCenter
            FgU.Cols(9).TextAlignFixed = TextAlignEnum.CenterCenter

            FgU.Cols(1).StarWidth = "2*"
            FgU.Cols(2).StarWidth = "3*"
            FgU.Cols(3).StarWidth = "*"
            FgU.Cols(4).StarWidth = "*"
            FgU.Cols(5).StarWidth = "*"
            FgU.Cols(7).StarWidth = "*"
            FgU.Cols(8).StarWidth = "*"
            FgU.Cols(9).StarWidth = "*"

        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Fg2.Rows.Count = 1
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                SQL = "SELECT EMPRESA, NOMBRE, SERVIDOR, BASE, USUARIO, PASS 
                     FROM EMPRESAS ORDER BY EMPRESA"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg2.AddItem("" & vbTab & "" & vbTab & dr("EMPRESA") & " " & dr("NOMBRE"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Sub Desplegar()
        Try
            FgU.Rows.Count = 1
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim Nivel As String = ""

            SQL = "SELECT USUARIO, NOMBRE, PASS, ISNULL(PASS_ALTERNA,'') AS PASS_ALT, NIVEL, ISNULL(CLAVE_SAE,0) AS CVE_SAE, 
                ISNULL(FOTO,'') AS FOTO_PIC 
                FROM GCUSUARIOS
                ORDER BY USUARIO"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader()

            While dr.Read()
                Select Case dr.ReadNullAsEmptyString("NIVEL")
                    Case 0
                        Nivel = "Administrador"
                    Case 1
                        Nivel = "Secretarial"
                    Case 2
                        Nivel = "Supervisor"
                End Select

                If PASS_GRUPOCE = "BUS" Then
                    FgU.AddItem("" & vbTab & dr.ReadNullAsEmptyString("USUARIO") & vbTab & dr.ReadNullAsEmptyString("NOMBRE") & vbTab &
                            Desencriptar(dr.ReadNullAsEmptyString("PASS")) & vbTab & dr.ReadNullAsEmptyString("PASS_ALT") & vbTab & Nivel & vbTab &
                            dr.ReadNullAsEmptyInteger("CVE_SAE") & vbTab &
                            dr.ReadNullAsEmptyString("FOTO_PIC") & vbTab & "")
                Else
                    FgU.AddItem("" & vbTab & dr.ReadNullAsEmptyString("USUARIO") & vbTab & dr.ReadNullAsEmptyString("NOMBRE") & vbTab &
                            dr.ReadNullAsEmptyString("PASS") & vbTab & dr.ReadNullAsEmptyString("PASS_ALT") & vbTab & Nivel & vbTab &
                            dr.ReadNullAsEmptyInteger("CVE_SAE") & vbTab &
                            dr.ReadNullAsEmptyString("FOTO_PIC") & vbTab & "")
                End If


                If File.Exists(RUTA_FOTOS & "\" & dr.ReadNullAsEmptyString("FOTO_PIC")) Then
                    FgU.SetCellImage(FgU.Rows.Count - 1, 8, My.Resources.images_e)
                End If
                If File.Exists(RUTA_HUELLAS & "\" & dr.ReadNullAsEmptyString("USUARIO") & ".fpt") Then
                    FgU.SetCellImage(FgU.Rows.Count - 1, 9, My.Resources.huella16_e0)
                End If

            End While
            dr.Close()
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TUsuario_GotFocus(sender As Object, e As EventArgs) Handles tUsuario.GotFocus
        tUsuario.SelectAll()
        tUsuario.BackColor = Color.Yellow
    End Sub
    Private Sub TNombre_GotFocus(sender As Object, e As EventArgs) Handles tNombre.GotFocus
        tNombre.SelectAll()
        tNombre.BackColor = Color.Yellow
    End Sub
    Private Sub TPass_GotFocus(sender As Object, e As EventArgs) Handles tPass.GotFocus
        tPass.SelectAll()
        tPass.BackColor = Color.Yellow
    End Sub
    Private Sub TUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tUsuario.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            tNombre.Focus()
        End If
    End Sub
    Private Sub TUsuario_LostFocus(sender As Object, e As EventArgs) Handles tUsuario.LostFocus
        tUsuario.BackColor = Color.White
    End Sub
    Private Sub TNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tNombre.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            tPass.Focus()
        End If
    End Sub
    Private Sub TNombre_LostFocus(sender As Object, e As EventArgs) Handles tNombre.LostFocus
        tNombre.BackColor = Color.White
    End Sub
    Private Sub TPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tPass.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            cboNivel.Focus()
        End If
    End Sub

    Private Sub TPass_LostFocus(sender As Object, e As EventArgs) Handles tPass.LostFocus
        tPass.BackColor = Color.White
    End Sub

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir2.Click
        Me.Close()
    End Sub
    Private Sub BtnCaptutaHuellas_Click(sender As Object, e As EventArgs) Handles BtnCaptutaHuellas.Click

        Try
            PictureBox5.Focus()

            If RUTA_HUELLAS.Trim.Length = 0 Then
                MsgBox("Por favor capture la ruta de las huellas dactilares en configuración-parámetros-parámetros generales")
                Return
            End If

            If Not IO.Directory.Exists(RUTA_HUELLAS) Then
                MsgBox("Ruta invalida, por favor verifique la ruta de las huellas dactilares en configuración-parámetros-parámetros generales")
                Return
            End If

            If PictureBox5.Tag.ToString.Trim.Length.ToString > 0 Then
                Var2 = PictureBox5.Tag
            Else
                Var2 = ""
            End If

            FrmCapturaHuellas.TUSUARIO.Text = TUsuario.Text
            FrmCapturaHuellas.ShowDialog()

        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub Lt3_Click(sender As Object, e As EventArgs) Handles Lt3.Click

    End Sub

    Private Sub BtnVerificarHuella_Click(sender As Object, e As EventArgs) Handles BtnVerificarHuella.Click

        Try
            If PictureBox5.Tag.ToString.Trim.Length.ToString > 0 Then
                Var2 = PictureBox5.Tag
            Else
                Var2 = ""
            End If
            Var3 = RUTA_FOTOS
            Var4 = RUTA_HUELLAS
            FrmLogin.TUSUARIO.Text = TUsuario.Text

            FrmLogin.ShowDialog()
            PictureBox5.Focus()
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnBorrarHuella_Click(sender As Object, e As EventArgs) Handles BtnBorrarHuella.Click

        Try
            Dim result = RJMessageBox.Show("Realmente desea borrar la huella del usuario " & TUsuario.Text & ".",
                                       "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then

                If IO.File.Exists(RUTA_HUELLAS & "\" & TUsuario.Text & ".fpt") Then
                    IO.File.Delete(RUTA_HUELLAS & "\" & TUsuario.Text & ".fpt")

                    Dim result1 = RJMessageBox.Show("La huella de borro correctamente", "Advertencia", MessageBoxButtons.OK)

                End If
            End If

            PictureBox5.Focus()
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub MnuNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click

        Try
            Panel1.Visible = True
            BarraMenu.Enabled = False
            TUsuario.Text = ""
            TNombre.Text = ""
            TPass.Text = ""
            CboNivel.SelectedIndex = -1
            TCLAVE_SAE.Text = ""
            TPASS_ALTERNA.Text = ""

            PictureBox5.Image = My.Resources.picx1
            PictureBox5.Tag = ""

            For k = 1 To Fg.Rows.Count - 1
                Fg(k, 3) = ""
            Next

            BtnSelFoto.Enabled = False
            BtnBorrarHuella.Enabled = False
            BtnVerificarHuella.Enabled = False
            BtnBorrarHuella.Enabled = False
            BtnQuitarFoto.Enabled = False
            BtnCaptutaHuellas.Enabled = False

            TUsuario.Enabled = True
            TUsuario.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnSelFoto_Click(sender As Object, e As EventArgs) Handles BtnSelFoto.Click
        Try
            PictureBox5.Focus()

            If RUTA_FOTOS.Trim.Length = 0 Then
                MsgBox("Por favor capture la ruta de las fotografias en configuración-parámetros-parámetros generales")
                Return
            End If

            If Not IO.Directory.Exists(RUTA_FOTOS) Then
                MsgBox("Ruta invalida, por favor verifique la ruta de las fotografias en configuración-parámetros-parámetros generales")
                Return
            End If

            With OpenFileDialog1
                .Filter = "Todos los archivos|*.*|PNGs|*.png|GIFs|*.gif|JPEGs|*.jpg"
                .FilterIndex = 4
                If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                    PictureBox5.Image = Image.FromFile(OpenFileDialog1.FileName)
                    PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
                    PictureBox5.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                    PictureBox5.Tag = OpenFileDialog1.FileName
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnQuitarFoto_Click(sender As Object, e As EventArgs) Handles BtnQuitarFoto.Click
        Try
            Dim result = RJMessageBox.Show("Realmente desea borrar la huella del usuario " & TUsuario.Text & ".",
                                       "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                PictureBox5.Image = My.Resources.picx1
                PictureBox5.Tag = ""
            End If
            PictureBox5.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MnuEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Try
            Call FgU_DoubleClick(Nothing, Nothing)

        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Dim Usuario1 As String
        Try
            Usuario1 = FgU(FgU.Row, 1)

            If MsgBox("Realmente desea eliminar el usuario " & Usuario1 & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Desplegar()
                Exit Sub
            End If

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "DELETE FROM GCUSUARIOS WHERE USUARIO = '" & Usuario1 & "'"
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
            End Using

            Desplegar()
        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        MsgBox("El registro se elimino satisfactoriamente")
    End Sub
    Private Sub FrmUSUARIOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Usuarios")
    End Sub
    Private Sub FgU_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles FgU.OwnerDrawCell
        Try
            If PASS_GRUPOCE = "BUS" Then

            Else
                If e.Row >= FgU.Rows.Fixed And e.Col = 3 And FgU(0, 3) = "Contraseña" Then
                    e.Text = New String("*"c, e.Text.Length)
                End If
                If e.Row >= FgU.Rows.Fixed And e.Col = 4 And FgU(0, 4) = "Contraseña alterna" Then
                    e.Text = New String("*"c, e.Text.Length)
                End If
            End If

        Catch ex As Exception
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgU_DoubleClick(sender As Object, e As EventArgs) Handles FgU.DoubleClick
        Try
            Tab1.SelectedIndex = 0

            TUsuario.Text = FgU(FgU.Row, 1)
            TNombre.Text = FgU(FgU.Row, 2)
            TPass.Text = Desencriptar(FgU(FgU.Row, 3))
            TPASS_ALTERNA.Text = Desencriptar(FgU(FgU.Row, 4))

            Select Case FgU(FgU.Row, 5)
                Case "Administrador"
                    CboNivel.SelectedIndex = 0
                Case "Secretarial"
                    CboNivel.SelectedIndex = 1
                Case "Supervisor"
                    CboNivel.SelectedIndex = 2
            End Select
            ENTRA = False

            Try
                Dim Existe As Boolean

                For k = 1 To Fg.Rows.Count - 1
                    Fg(k, 3) = ""
                Next

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(TIPO_DOC,'') AS TIP, ISNULL(SERIE,'') AS SER
                         FROM GCUSUARIOS_PARAM 
                         WHERE UPPER(USUARIO) = '" & TUsuario.Text.Trim.ToUpper & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            Existe = False

                            For k = 1 To Fg.Rows.Count - 1

                                If dr("TIP") = Fg(k, 1) Then
                                    If dr("TIP") = "a" Or dr("TIP") = "ad" Then
                                        Try
                                            If IsNumeric(dr("SER")) Then
                                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                    SQL = "SELECT CVE_ALM, DESCR
                                                        FROM ALMACENES" & Empresa & " WHERE CVE_ALM = " & Convert.ToInt16(dr("SER"))
                                                    cmd2.CommandText = SQL
                                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                                        If dr2.Read Then
                                                            Fg(k, 3) = dr("SER") & " " & dr2("DESCR")
                                                            Existe = True
                                                        End If
                                                    End Using
                                                End Using
                                            End If
                                        Catch ex As Exception
                                            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    Else
                                        Fg(k, 3) = dr("SER")
                                        Existe = True
                                    End If
                                End If
                                If Existe Then
                                    Exit For
                                End If
                            Next
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Try
                For k = 1 To Fg2.Rows.Count - 1
                    Fg2(k, 1) = ""
                Next

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(EMPRESA,'') AS EMP
                         FROM GCUSUARIOS_EMP 
                         WHERE UPPER(USUARIO) = '" & TUsuario.Text.Trim.ToUpper & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            For k = 1 To Fg2.Rows.Count - 1
                                If dr("EMP") = Fg2(k, 2).ToString.Substring(0, 2) Then
                                    Fg2(k, 1) = True
                                    Exit For
                                End If
                            Next
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            TCLAVE_SAE.Text = FgU(FgU.Row, 6)

            If FgU(FgU.Row, 7).ToString.Trim.Length > 0 Then
                PictureBox5.Tag = RUTA_FOTOS & "\" & FgU(FgU.Row, 7)

                If IO.File.Exists(RUTA_FOTOS & "\" & FgU(FgU.Row, 7)) Then
                    PictureBox5.Image = Image.FromFile(RUTA_FOTOS & "\" & FgU(FgU.Row, 7))
                End If
            Else
                PictureBox5.Tag = ""
                PictureBox5.Image = My.Resources.picx1
            End If

            Panel1.Visible = True
            BarraMenu.Enabled = False

            BtnSelFoto.Enabled = True
            BtnBorrarHuella.Enabled = True
            BtnVerificarHuella.Enabled = True
            BtnBorrarHuella.Enabled = True
            BtnQuitarFoto.Enabled = True
            BtnCaptutaHuellas.Enabled = True

            TUsuario.Enabled = False

            TNombre.Focus()
        Catch ex As Exception
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub

    Private Sub FgU_KeyDown(sender As Object, e As KeyEventArgs) Handles FgU.KeyDown
        If e.KeyCode = 13 Then
            If e.KeyCode = 46 Then
                Call MnuEdit_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub FrmUSUARIOS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then
            Panel1.Visible = False
            BarraMenu.Enabled = True
        End If
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        If Fg.Col = 3 Then
            Select Case Fg.Row
                Case 1
                    Fg.Cols(3).ComboList = VF
                Case 2
                    Fg.Cols(3).ComboList = VV
                Case 3
                    Fg.Cols(3).ComboList = VR
                Case 4
                    Fg.Cols(3).ComboList = VP
                Case 5
                    Fg.Cols(3).ComboList = VC
                Case 6
                    Fg.Cols(3).ComboList = VD
                Case 7
                    Fg.Cols(3).ComboList = VCDP
                Case 8
                    Fg.Cols(3).ComboList = VNC
                Case 9
                    Fg.Cols(3).ComboList = VT
                Case 10
                    Fg.Cols(3).ComboList = CC
                Case 11
                    Fg.Cols(3).ComboList = CR
                Case 12
                    Fg.Cols(3).ComboList = CO
                Case 13
                    Fg.Cols(3).ComboList = CQ
                Case 14
                    Fg.Cols(3).ComboList = CDC
                Case 15
                    Fg.Cols(3).ComboList = ALM
                Case 16
                    Fg.Cols(3).ComboList = ALMD
                Case 17
                    Fg.Cols(3).ComboList = VF2
            End Select
        End If
        'Fg(9, 1) = "Folio compras"
        'Fg(10, 1) = "Folio recepciones"
        'Fg(11, 1) = "Folio ordenes de compra"
        'Fg(12, 1) = "Folio Requisiciones"
        'Fg(13, 1) = "Folio devolución de compras"
        'Fg(14, 1) = "Almacén"
        'Fg(15, 1) = "Almacén de devolución"

    End Sub
    Private Sub Fg2_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg2.CellChecked
        Try
            Select Case e.Col
                Case 1
                    If e.Row = 0 AndAlso e.Col = 1 Then
                        ChangeState(Fg.GetCellCheck(e.Row, e.Col))
                    Else
                        If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)
                    End If
                Case 5
                    If Not Fg(Fg.Row, 1) And Fg(Fg.Row, 4).ToString.Trim.Length = 0 Then
                        Fg.SetCellCheck(e.Row, 5, CheckEnum.Unchecked)
                    Else
                        For k = 1 To Fg.Rows.Count - 1
                            If k <> e.Row AndAlso k <> 1 Then
                                Fg.SetCellCheck(k, 5, CheckEnum.Unchecked)
                            End If
                        Next
                    End If
            End Select
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg2.Rows.Fixed To Fg2.Rows.Count - 1
            Fg2.SetCellCheck(row, 1, state)
        Next
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim CLAVE As String, CVE_SAE As Integer = 0, SERIEU As String, FOTO As String = ""
        Dim PASS_ALTERNA As String

        Try
            If TPass.Text.Trim.Length = 0 Then
                CLAVE = ""
            Else
                CLAVE = Encriptar(TPass.Text.ToUpper)
            End If

            If TPASS_ALTERNA.Text.Trim.Length = 0 Then
                PASS_ALTERNA = ""
            Else
                PASS_ALTERNA = Encriptar(TPASS_ALTERNA.Text.ToUpper)
            End If
            If IsNumeric(TCLAVE_SAE.Text.Trim) Then
                CVE_SAE = TCLAVE_SAE.Text.Trim
            End If

            If PictureBox5.Tag.ToString.Trim.Length > 0 Then
                Try
                    FOTO = Path.GetFileName(PictureBox5.Tag)

                    FileCopy(PictureBox5.Tag, RUTA_FOTOS & "\" & FOTO)
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If

            SQL = "UPDATE GCUSUARIOS SET NOMBRE = '" & TNombre.Text.Trim.ToUpper & "',USUARIO = '" & TUsuario.Text & "', 
                PASS = '" & CLAVE & "', PASS_ALTERNA = '" & PASS_ALTERNA & "', NIVEL = '" & CboNivel.SelectedIndex & "', 
                CLAVE_SAE = " & CVE_SAE & ", FOTO = '" & FOTO & "'
                WHERE UPPER(USUARIO) = '" & TUsuario.Text.Trim.ToUpper & "' 
                IF @@ROWCOUNT = 0
                INSERT INTO GCUSUARIOS (USUARIO, NOMBRE, PASS, PASS_ALTERNA, NIVEL, CLAVE_SAE, FOTO) VALUES ('" &
                TUsuario.Text.Trim.ToUpper & "','" & TNombre.Text & "','" & CLAVE & "','" & PASS_ALTERNA & "','" &
                CboNivel.SelectedIndex & "','" & CVE_SAE & "','" & FOTO & "')"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using

            For k = 1 To Fg.Rows.Count - 1

                SERIEU = Fg(k, 3)

                If SERIEU.Trim.Length > 0 Then

                    If Fg(k, 1) = "a" Or Fg(k, 1) = "ad" Or Fg(k, 1) = "ep" Then
                        SERIEU = SERIEU.Substring(0, 2)
                    End If

                    SQL = "IF EXISTS (SELECT SERIE FROM GCUSUARIOS_PARAM WHERE UPPER(USUARIO) = '" & TUsuario.Text.Trim.ToUpper & "' AND TIPO_DOC = '" & Fg(k, 1) & "')
                                UPDATE GCUSUARIOS_PARAM SET SERIE = '" & SERIEU & "'
                                WHERE UPPER(USUARIO) = '" & TUsuario.Text.Trim.ToUpper & "' AND TIPO_DOC = '" & Fg(k, 1) & "'
                            ELSE
                                INSERT INTO GCUSUARIOS_PARAM (USUARIO, TIPO_DOC, SERIE) 
                                VALUES ('" & TUsuario.Text.Trim.ToUpper & "','" & Fg(k, 1) & "','" & SERIEU & "')"

                    returnValue = EXECUTE_QUERY_NET(SQL)
                    If returnValue = "" Then
                    End If
                End If
            Next

            For k = 1 To Fg2.Rows.Count - 1

                If Fg2(k, 1) Then

                    SERIEU = Fg2(k, 2).ToString.Substring(0, 2)

                    SQL = "IF EXISTS (SELECT USUARIO FROM GCUSUARIOS_EMP WHERE UPPER(USUARIO) = '" & TUsuario.Text.Trim.ToUpper & "' AND EMPRESA = '" & SERIEU & "')
                                UPDATE GCUSUARIOS_EMP SET EMPRESA = '" & SERIEU & "'
                                WHERE UPPER(USUARIO) = '" & TUsuario.Text.Trim.ToUpper & "' AND EMPRESA = '" & SERIEU & "'
                            ELSE
                                INSERT INTO GCUSUARIOS_EMP (USUARIO, EMPRESA, UUID) VALUES ('" & TUsuario.Text.Trim.ToUpper & "','" & SERIEU & "',NEWID())"
                    returnValue = EXECUTE_QUERY_NET(SQL)
                    If returnValue = "" Then
                    End If
                End If
            Next

            Desplegar()

            MsgBox("Los datos se grabaron satisfactorimente")
            Panel1.Visible = False
            BarraMenu.Enabled = True
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click


        Panel1.Visible = False
        BarraMenu.Enabled = True

    End Sub

    Private Sub Lt3_DoubleClick(sender As Object, e As EventArgs) Handles Lt3.DoubleClick

    End Sub
End Class