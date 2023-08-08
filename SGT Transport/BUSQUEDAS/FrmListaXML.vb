Imports C1.Win.C1Themes
Imports System.Xml
Public Class FrmListaXML
    Dim CADENA As String = ""
    WithEvents BindingSource1 As New BindingSource
    Private Sub FrmListaXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Me.CenterToScreen()

            Dim ArchivoXml As String = ""
            Select Case Prosec
                Case "CAT_INCOTERM"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_TIPO_OP.xml"
                Case "CAT_EXPORTACION40"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_EXPORTACION40.xml"
                Case "CAT_UNI_ADUANA"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_UNI_ADUANA.xml"
                Case "CAT_TIPO_OP"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_TIPO_OP.xml"
                Case "CAT_MOT_TRASLADO"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_MOT_TRASLADO.xml"

                Case "Municipio"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml"
                Case "Localidad"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml"
                Case "Estado"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml"
                Case "Pais"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_PAIS.xml"
                Case "CP"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_CODIGO_POSTAL.xml"
                Case "Colonia"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_COLONIAS.xml"

                Case "Motivo traslado" '<row Descripcion="Envío de mercancias facturadas con anterioridad" c_MotivoTraslado="01"/>
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_MOT_TRASLADO.xml"
                Case "Tipo operacion"
                Case "INCOTERM"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_INCOTERM.xml"
                Case "Unidad aduana"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_UNI_ADUANA.xml"
                Case "Cat. Aduana"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_ADUANA.xml"
                Case Else
                    MsgBox("Por favor envie un proceso")
            End Select

            Fg.Dock = DockStyle.Fill

            Dim xmlFile As XmlReader
            xmlFile = XmlReader.Create(ArchivoXml, New XmlReaderSettings())
            Dim ds As New DataSet
            ds.ReadXml(xmlFile)


            BindingSource1.DataSource = ds.Tables(0)

            Select Case Prosec
                Case "CP"
                    'Var6 = TCP.Text
                    'Var7 = TLOCALIDAD.Text
                    'Var8 = TMUNICIPIO.Text
                    'Var9 = TESTADO.Text

                    'BindingSource1.Filter = "(c_Localidad Like '%" & Var7 & "%' OR c_Municipio LIKE '%" & Var8 & "%' OR c_Estado like '%" & Var9 & "%'  )"
                    If Var7.Trim.Length > 0 Then CADENA = "c_Localidad='" & Var7 & "' AND "
                    If Var8.Trim.Length > 0 Then CADENA += "c_Municipio='" & Var8 & "' AND "
                    If Var9.Trim.Length > 0 Then CADENA += "c_Estado='" & Var9 & "' AND "

                    If CADENA.Trim.Length > 0 And Var6.Trim.Length = 0 Then
                        CADENA = "(" & CADENA.Substring(0, CADENA.Length - 5) & ")"
                    Else
                        CADENA = "c_CodigoPostal = '" & Var6 & "'"
                    End If
                    If Var6.Trim.Length = 0 Then
                        CADENA = ""
                    End If


                    BindingSource1.Filter = CADENA '"c_Localidad='" & Var7 & "' AND c_Municipio='" & Var8 & "' AND c_Estado='" & Var9 & "'"

                Case "Colonia"
                    If Var7.Trim.Length > 0 Then CADENA = "c_CodigoPostal='" & Var7 & "'"

                    BindingSource1.Filter = CADENA
            End Select

            Fg.DataSource = BindingSource1.DataSource

            Select Case Prosec
                Case "Pais"
                    Fg.Cols(3).Width = 0
                    Fg.Cols(4).Width = 0
                    Fg.Cols(5).Width = 0
                    Fg.Cols(6).Width = 0

                    Fg.Cols(3).Visible = False
                    Fg.Cols(4).Visible = False
                    Fg.Cols(5).Visible = False
                    Fg.Cols(6).Visible = False

                    Fg(0, 1) = "Clave"
                    Fg(0, 2) = "Pais"
                Case "CP"
                    Fg(0, 1) = "Codigo postal"
                    Fg(0, 2) = "Estado"
                    Fg(0, 3) = "Municipio"
                    Fg(0, 4) = "Localidad"
                Case "Colonia"
                    Fg(0, 1) = "Descricpión"
                    Fg(0, 2) = "Código postal"
                    Fg(0, 3) = "Colonia"
            End Select

            AJUSTA_COLUMNAS_FG2(Me, Fg, 0, 1)

            LtNum.Text = "Registros encontrados " & Fg.Rows.Count - 1
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmListaXML_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub TXTS1_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = 40 Then
                Fg.Focus()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarAceptar_Click(sender As Object, e As EventArgs) Handles BarAceptar.Click
        Try
            If Fg.Row > 0 Then
                Var10 = Fg(Fg.Row, 1)

                If Fg.Cols.Count - 1 >= 3 Then

                    Var11 = Fg(Fg.Row, 1)
                    Var12 = Fg(Fg.Row, 2)

                    'Fg(0, 1) = "Codigo postal"
                    'Fg(0, 2) = "Estado"
                    'Fg(0, 3) = "Municipio"
                    'Fg(0, 4) = "Localidad"
                    Var4 = Fg(Fg.Row, 1)
                    Var7 = Fg(Fg.Row, 2)
                    Var8 = Fg(Fg.Row, 3)
                    Var9 = Fg(Fg.Row, 4)

                End If
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarAceptar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If e.KeyCode = Keys.Left Then
                TBox.Focus()
                Return
            End If
            If e.KeyCode = 13 Then
                BarAceptar_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles TBox.TextChanged
        Try
            Select Case Prosec
                Case "Municipio"
                    'Descripcion="Aguascalientes" Estado="AGU" Clave="001"/>
                    SQL = "(Descripcion LIKE '%" & TBox.Text & "%' OR Clave LIKE '%" & TBox.Text & "%')"
                    BindingSource1.Sort = "Clave"
                Case "Localidad"
                    '<row Descripcion="Aguascalientes" Estado="AGU" Clave="01"/>
                    SQL = "(Descripcion LIKE '%" & TBox.Text & "%' OR Estado LIKE '%" & TBox.Text & "%' OR 
                        Clave LIKE '%" & TBox.Text & "%')"
                    BindingSource1.Sort = "Clave"
                Case "Estado"
                    '<row Descripcion="Aguascalientes" Pais="MEX" Clave="AGU"/>
                    SQL = "(Descripcion LIKE '%" & TBox.Text & "%' OR Pais LIKE '%" & TBox.Text & "%' OR 
                        Clave LIKE '%" & TBox.Text & "%')"
                    BindingSource1.Sort = "Clave"
                Case "Pais"
                    '<row Descripcion="Afganistán" c_Pais="AFG"/>
                    SQL = "(Descripcion LIKE '%" & TBox.Text & "%' OR c_Pais LIKE '%" & TBox.Text & "%')"
                    BindingSource1.Sort = "Descripcion"
                Case "CP"
                    '<row c_Localidad="01" c_Municipio="010" c_Estado="DIF" c_CodigoPostal="01000"/
                    SQL = "(c_Localidad Like '%" & TBox.Text & "%' OR c_Municipio LIKE '%" & TBox.Text & "%' OR 
                         c_Estado Like '%" & TBox.Text & "%' OR c_CodigoPostal LIKE '%" & TBox.Text & "%')"
                    BindingSource1.Sort = "c_CodigoPostal"
            End Select

            BindingSource1.RemoveFilter()

            If TBox.Text.Trim.Length > 0 Then

                BindingSource1.Filter = SQL
            Else
                BindingSource1.Filter = CADENA
            End If
            ' enlzar el datagridview al BindingSource  

            Fg.DataSource = BindingSource1.DataSource

            'AJUSTA_COLUMNAS_FG2(Me, Fg, 0, 1)

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TBox.KeyDown
        Try
            If e.KeyCode = Keys.Down Then
                Fg.Focus()
                Return
            End If
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                TBox_TextChanged(Nothing, Nothing)
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace & vbNewLine)
        End Try
    End Sub
End Class