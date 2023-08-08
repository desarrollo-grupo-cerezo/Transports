Imports System.IO
Public Class wGeneraPDF
    Private rutaImagen = String.Empty

    Private Sub btnBuscarImagen_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen.Click
        Dim open As OpenFileDialog = New OpenFileDialog()
        open.Filter = "Imagen JPG (*.jpg;*.jpeg;*.jpe)|*.jpg;*.jpeg;*.jpe |PNG (*.png)|*.png |Archivo de mapa de bits(*.bmp)|*.bmp | Todos los formatos |*.jpg;*.jpeg;*.jpe;*.png;*.bmp"
        open.FilterIndex = 4
        If open.ShowDialog() <> DialogResult.OK Then Return
        pictureBox1.Image = Image.FromFile(open.FileName)
        rutaImagen = open.FileName
    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        Dim open As OpenFileDialog = New OpenFileDialog()
        open.Filter = "Archivo XML (*.xml)|*.xml"
        open.FilterIndex = 4
        If open.ShowDialog() <> DialogResult.OK Then Return
        tbRutaXML.Text = open.FileName
    End Sub

    Private Sub btnCrearPDF_Click(sender As Object, e As EventArgs) Handles btnCrearPDF.Click
        If tabControl1.SelectedTab.Name = "tabPage1" Then
            CreaPDF.Generar(tbRutaXML.Text, tbDireccionPDF.Text, rutaImagen, True)
            'Dim crearPDF As CreaPDF = New CreaPDF(tbRutaXML.Text, tbDireccionPDF.Text, pictureBox1.Image)
        ElseIf tabControl1.SelectedTab.Name = "tabPage2" Then
            Dim di As DirectoryInfo = New DirectoryInfo(tbRutaCarpetaXML.Text)
            Dim nuevaRuta As String
            For Each fi In di.GetFiles("*.xml")
                nuevaRuta = tbRutaCarpetaPDF.Text & "\" + fi.Name.Replace(".xml", ".pdf")
                CreaPDF.Generar(fi.FullName, nuevaRuta, rutaImagen, True)
                'Dim crearPDF As CreaPDF = New CreaPDF(fi.FullName, nuevaRuta, pictureBox1.Image)
            Next
        Else
            MessageBox.Show("No se ha seleccionado una pestaña")
        End If
    End Sub

    Private Sub btnGuardarEn_Click(sender As Object, e As EventArgs) Handles btnGuardarEn.Click
        Dim guardar As SaveFileDialog = New SaveFileDialog()
        guardar.Filter = "Archivo PDF (*.pdf)|*.pdf"
        If guardar.ShowDialog() <> DialogResult.OK Then Return
        tbDireccionPDF.Text = guardar.FileName
    End Sub

    Private Sub btnCarpetaXML_Click(sender As Object, e As EventArgs) Handles btnCarpetaXML.Click
        Dim guardar As FolderBrowserDialog = New FolderBrowserDialog()
        guardar.RootFolder = System.Environment.SpecialFolder.Desktop
        guardar.ShowNewFolderButton = False
        guardar.Description = "Selecciona la carpeta contenedora de archivos en formato XML"
        If guardar.ShowDialog() <> DialogResult.OK Then Return
        tbRutaCarpetaXML.Text = guardar.SelectedPath
    End Sub

    Private Sub btnCarpetaPDF_Click(sender As Object, e As EventArgs) Handles btnCarpetaPDF.Click
        Dim guardar As FolderBrowserDialog = New FolderBrowserDialog()
        guardar.RootFolder = System.Environment.SpecialFolder.Desktop
        guardar.Description = "Selecciona la carpeta donde se almacenarán los nuevos archivos en formato PDF"
        If guardar.ShowDialog() <> DialogResult.OK Then Return
        tbRutaCarpetaPDF.Text = guardar.SelectedPath
    End Sub
End Class