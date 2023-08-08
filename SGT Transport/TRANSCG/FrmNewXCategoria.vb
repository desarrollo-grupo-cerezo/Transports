Imports System.Xml
Public Class FrmNewXCategoria
    Dim EntraCombo As Boolean
    Dim EntraRadio As Boolean
    Dim selCombo As Integer
    Dim EntraTextBuscar As Boolean
    Dim EntraCboGrupo As Boolean
    Dim EntraCboClase As Boolean
    Dim CualComboLlena As String
    WithEvents BindingSource1 As New BindingSource
    Private Sub FrmNewXCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            'RESIZR
            Dim ArchivoXml As String
            Dim SQLstr As String

            EntraCombo = False
            EntraRadio = True
            EntraCboGrupo = True
            EntraCboClase = True
            CualComboLlena = ""

            SplitP.SplitterWidth = 1

            EntraCombo = True
            EntraTextBuscar = True
            SQLstr = ""


            Select Case Prosec
                Case "CAT_MATERIAL_PELIGROSO"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_MATERIAL_PELIGROSO.xml"
                Case "UNIMED", "INVUNIMED"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_CLAVE_UNI.xml"
                Case "CATINV", "CATINV2"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_PROD_SERV.xml"
                Case "CAT_UNIDAD_PESO"
                    ArchivoXml = Application.StartupPath & "\CatalogosSat\CAT_UNIDAD_PESO.xml"
                Case Else
                    Return
            End Select

            Dim xmlFile As XmlReader
            xmlFile = XmlReader.Create(ArchivoXml, New XmlReaderSettings())
            Dim ds As New DataSet
            ds.ReadXml(xmlFile)

            BindingSource1.Filter = ""
            DataGridView1.DataSource = ds.Tables(0)
            BindingSource1.DataSource = ds.Tables(0)
            BindingSource1.Filter = SQLstr
            DataGridView1.DataSource = BindingSource1.DataSource
            'DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point)
            DataGridView1.RowHeadersVisible = False

            Select Case Prosec
                Case "CAT_MATERIAL_PELIGROSO", "CAT_UNIDAD_PESO"
                    DataGridView1.Columns(0).HeaderCell.Value = "Clave"
                    DataGridView1.Columns(1).HeaderCell.Value = "Descripción"

                    DataGridView1.Columns(0).Width = 80
                    DataGridView1.Columns(1).Width = 500

                    DataGridView1.Width = 650
                Case "UNIMED", "INVUNIMED"
                    DataGridView1.Columns(0).HeaderCell.Value = "Clave"
                    DataGridView1.Columns(1).HeaderCell.Value = "Descripción"
                    DataGridView1.Columns(2).HeaderCell.Value = "Clave"
                    DataGridView1.Columns(3).HeaderCell.Value = "Descripción"
                    DataGridView1.Columns(4).HeaderCell.Value = ""
                    DataGridView1.Columns(5).HeaderCell.Value = ""

                    DataGridView1.Columns(0).Width = 0
                    DataGridView1.Columns(1).Width = 0
                    DataGridView1.Columns(2).Width = 100
                    DataGridView1.Columns(3).Width = 420
                    DataGridView1.Columns(4).Width = 0
                    DataGridView1.Columns(5).Width = 0

                    DataGridView1.Columns(0).Visible = False
                    DataGridView1.Columns(1).Visible = False
                    DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(5).Visible = False
                    DataGridView1.Columns(6).Visible = False
                    DataGridView1.Columns(7).Visible = False
                Case "CATINV"
                    DataGridView1.Columns(0).HeaderCell.Value = "Clave"
                    DataGridView1.Columns(1).HeaderCell.Value = "Nombre"
                    DataGridView1.Columns(2).HeaderCell.Value = "Descripción"

                    DataGridView1.Columns(0).Width = 80
                    DataGridView1.Columns(1).Width = 300
                    DataGridView1.Columns(2).Width = 350
                    DataGridView1.Columns(3).Width = 35

                    DataGridView1.Columns(3).Visible = False
                    DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(5).Visible = False
                    'Me.Width = 680
                    DataGridView1.Width = 650
            End Select
            Me.Text = DataGridView1.Rows.Count & " Registros encontrados"
            Me.Top = 0
            Me.Height = My.Computer.Screen.Bounds.Size.Height - 50
            TBuscar.Focus()
        Catch ex As Exception
            MsgBox("" & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmNewXCategoria_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        TBuscar.Focus()
    End Sub
    Private Sub FrmNewXCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case 27
                TBuscar.Focus()
            Case Keys.F5
                EntraCombo = False
                EntraCombo = True
        End Select
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim Familia As String
        Dim Grupo As String
        Dim Clase As String
        EntraCombo = False
        Try
            If DataGridView1.Rows.Item(e.RowIndex).Cells(0).Value.ToString.Length = 0 Then
                Return
            End If

            Familia = DataGridView1.Rows.Item(e.RowIndex).Cells(0).Value.ToString
            Familia = Familia.Substring(0, 2)
            Grupo = DataGridView1.Rows.Item(e.RowIndex).Cells(0).Value.ToString.Substring(0, 4)
            Clase = DataGridView1.Rows.Item(e.RowIndex).Cells(0).Value.ToString.Substring(0, 6)

            EntraCombo = True
            EntraCboGrupo = False

            EntraCboGrupo = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click

        Dim Linea As String = ""
        Dim Descr As String = ""
        Dim Descr2 As String = ""
        Dim rowGrid As Long

        Try
            rowGrid = DataGridView1.CurrentCell.RowIndex

            Select Case Prosec
                Case "CAT_MATERIAL_PELIGROSO", "CAT_UNIDAD_PESO"
                    Linea = DataGridView1.Rows.Item(rowGrid).Cells(0).Value
                    Descr = DataGridView1.Rows.Item(rowGrid).Cells(1).Value
                Case "UNIMED", "INVUNIMED"
                    Linea = DataGridView1.Rows.Item(rowGrid).Cells(2).Value
                    Descr = DataGridView1.Rows.Item(rowGrid).Cells(3).Value
                    Descr2 = ""
                Case "CATINV"
                    Linea = DataGridView1.Rows.Item(rowGrid).Cells(0).Value
                    Descr = DataGridView1.Rows.Item(rowGrid).Cells(1).Value
                    Descr2 = DataGridView1.Rows.Item(rowGrid).Cells(2).Value
            End Select

            Var10 = Linea
            Var11 = Descr
            Var12 = Descr2
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Try
            Call BtnAceptar_Click(BtnAceptar, AcceptButton)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Call BtnAceptar_Click(BtnAceptar, AcceptButton)
                Case 37
                    TBuscar.Focus()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBuscar_GotFocus(sender As Object, e As EventArgs) Handles TBuscar.GotFocus
        TBuscar.SelectAll()
        TBuscar.BackColor = Color.Yellow
    End Sub
    Private Sub TBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles TBuscar.KeyDown
        If e.KeyCode = 40 Then
            DataGridView1.Focus()
        End If
    End Sub
    Private Sub TBuscar_LostFocus(sender As Object, e As EventArgs) Handles TBuscar.LostFocus
        TBuscar.BackColor = Color.White
    End Sub
    Private Sub TBuscar_TextChanged(sender As Object, e As EventArgs) Handles TBuscar.TextChanged
        If EntraTextBuscar Then
            Aplicar_Filtro()
        End If
    End Sub
    Public Sub Aplicar_Filtro()
        ' filtrar por el campo nombre del cliente
        ''''''''''''''''''''''''''''''''''''''''''''''''''''  
        Try
            Dim ret As Integer = Filtrar_DataGridView(TBuscar.Text.Trim)

            If ret = 0 Then
                ' si no hay registros cambiar el color del txtbox  
                Me.TBuscar.BackColor = Color.Red
                TBuscar.ForeColor = Color.White
            Else
                Me.TBuscar.BackColor = Color.White
                TBuscar.ForeColor = Color.Black
            End If
            ' visualizar la cantidad de registros  
            'Me.Text = ret & " Registros encontrados"
            Lt.Text = ret & " Registros encontrados"
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Function Filtrar_DataGridView(ByVal texto As String) As Integer
        Dim filtro As String = ""
        Me.Cursor = Cursors.WaitCursor
        Try
            If BindingSource1.DataSource Is Nothing Then
                Return 0
            End If
            filtro = ""
            If texto.Length > 0 Then
                texto = texto.Substring(0, 1).ToUpper & texto.Substring(1, texto.Length - 1)
            End If

            Select Case Prosec
                Case "CATINV"
                    filtro = "c_ClaveProdServ like '%" & texto & "%' or Descripcion like '%" & texto & "%'"
                Case "CATINV2"
                    filtro = "not c_ClaveProdServ like '%00' AND (Descripcion like '%" & texto & "%' OR c_ClaveProdServ LIKE '" & texto & "%') AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '64' AND SUBSTRING(c_ClaveProdServ,1,2) <> '70' AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '71' AND SUBSTRING(c_ClaveProdServ,1,2) <> '72' AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '73' AND SUBSTRING(c_ClaveProdServ,1,2) <> '76' AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '77' AND SUBSTRING(c_ClaveProdServ,1,2) <> '78' AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '80' AND SUBSTRING(c_ClaveProdServ,1,2) <> '81' AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '82' AND SUBSTRING(c_ClaveProdServ,1,2) <> '83' AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '84' AND SUBSTRING(c_ClaveProdServ,1,2) <> '85' AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '86' AND SUBSTRING(c_ClaveProdServ,1,2) <> '90' AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '91' AND SUBSTRING(c_ClaveProdServ,1,2) <> '92' AND " &
                             "SUBSTRING(c_ClaveProdServ,1,2) <> '93' AND SUBSTRING(c_ClaveProdServ,1,2) <> '94' "
                            '64 70 71 72 73 76 77 78 80 81 82 83 84 85 86 90 91 92 93 94
                Case "UNIMED", "INVUNIMED"
                    filtro = "c_ClaveUnidad like '%" & texto & "%' OR Nombre like '%" & texto & "%'"
                Case "CAT_MATERIAL_PELIGROSO", "CAT_UNIDAD_PESO"
                    filtro = "Descripcion like '%" & texto & "%' OR Clave like '%" & texto & "%'"
            End Select

            BindingSource1.Filter = filtro
            DataGridView1.DataSource = BindingSource1.DataSource

            Me.Cursor = Cursors.Default

            Return BindingSource1.Count
        Catch ex As Exception
            MsgBox("" & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & filtro)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & filtro)
        End Try
        Return 0
    End Function


    Public Sub Aplicar_Filtro2()
        ' filtrar por el campo nombre del cliente
        ''''''''''''''''''''''''''''''''''''''''''''''''''''  
        Try
            Dim ret As Integer = Filtrar_DataGridView2(TBuscar.Text.Trim)

            If ret = 0 Then
                ' si no hay registros cambiar el color del txtbox  
                Me.TBuscar.BackColor = Color.Red
                TBuscar.ForeColor = Color.White
            Else
                Me.TBuscar.BackColor = Color.White
                TBuscar.ForeColor = Color.Black
            End If
            ' visualizar la cantidad de registros  
            Me.Text = ret & " Registros encontrados"

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Function Filtrar_DataGridView2(ByVal texto As String) As Integer
        Dim filtro As String
        filtro = ""
        Me.Cursor = Cursors.WaitCursor
        Try
            If BindingSource1.DataSource Is Nothing Then
                Return 0
            End If

            filtro = "not c_ClaveProdServ like '%00' AND (Descripcion like '%" & texto & "%' OR c_ClaveProdServ LIKE '" & texto & "%')"

            BindingSource1.Filter = filtro
            DataGridView1.DataSource = BindingSource1.DataSource
            Me.Cursor = Cursors.Default
            Return BindingSource1.Count
        Catch ex As Exception
            MsgBox("" & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & filtro)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace & vbNewLine & filtro)
        End Try
        Me.Cursor = Cursors.Default
        Return 0
    End Function

    Private Function BuscaFamilia(fFamilia As String) As String
        Try
            Select Case fFamilia
                Case "10", "11", "12", "13", "14", "15"
                    BuscaFamilia = "Materias primas, quimicos, papel y combustibles (10 11 12 13 14 15)"
                Case "20", "21", "23", "24", "26", "27"
                    BuscaFamilia = "Herramientas y equipos industriales (20 21 23 24 26 27)"
                Case "30", "31", "32", "39"
                    BuscaFamilia = "Suministros y componentes (30 31 32 39)"
                Case "22", "25", "40"
                    BuscaFamilia = "Suministros y equipos de construccion, edificaciones y transportes (22 25 40)"
                Case "41", "42", "51"
                    BuscaFamilia = "Productos farmaceuticos, y suministros y equipos de ensayo, de laboratorio y medicos (41 42 51)"
                Case "47", "48", "50"
                    BuscaFamilia = "Suministros y equipos de servicios, limpieza y comida (47 48 50)"
                Case "43", "44", "45", "55"
                    BuscaFamilia = "Suministros y equipos tecnologicos, de comunicaciones y de negocios (43 44 45 55)"
                Case "46"
                    BuscaFamilia = "Suministros y equipos de defensa y seguridad (46)"
                Case "49", "52", "53", "54", "56", "60"
                    BuscaFamilia = "Suministros y equipos de consumo, domesticos y personales (49 52 53 54 56 60)"
                Case "64 70", "71", "72", "73", "76", "77", "78", "80", "81", "82", "83", "84", "85", "86", "90", "91", "92", "93", "94"
                    BuscaFamilia = "Servicios (64 70 71 72 73 76 77 78 80 81 82 83 84 85 86 90 91 92 93 94)"
                Case "95"
                    BuscaFamilia = "Bienes Inmuebles (95)"
                Case Else
                    BuscaFamilia = ""
            End Select
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
            Bitacora(ex.Message & vbNewLine & ex.StackTrace)
            BuscaFamilia = ""
        End Try
    End Function

    Private Sub CboClase_SelectedIndexChanged(sender As Object, e As EventArgs)
        If EntraCboClase Then
            EntraTextBuscar = False
            TBuscar.Text = ""
            EntraTextBuscar = True

            selCombo = 3
            Aplicar_Filtro2()
        End If
    End Sub
    Private Sub CboGrupo_SelectedIndexChanged(sender As Object, e As EventArgs)
        If EntraCboGrupo Then
            EntraTextBuscar = False
            TBuscar.Text = ""
            EntraTextBuscar = True

            CualComboLlena = "Clase"
            selCombo = 2
            Aplicar_Filtro2()
        End If
    End Sub
    Private Sub FrmNewXCategoria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub
End Class
