<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class wGeneraPDF
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(wGeneraPDF))
        Me.label6 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.tbRutaCarpetaPDF = New System.Windows.Forms.TextBox()
        Me.btnCarpetaPDF = New System.Windows.Forms.Button()
        Me.label8 = New System.Windows.Forms.Label()
        Me.btnCarpetaXML = New System.Windows.Forms.Button()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.tbRutaCarpetaXML = New System.Windows.Forms.TextBox()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.tbDireccionPDF = New System.Windows.Forms.TextBox()
        Me.btnGuardarEn = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.tbRutaXML = New System.Windows.Forms.TextBox()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.btnBuscarImagen = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.btnCrearPDF = New System.Windows.Forms.Button()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panel3.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.panel2.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.label6.Location = New System.Drawing.Point(11, 12)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(101, 18)
        Me.label6.TabIndex = 7
        Me.label6.Text = "Ubicaciones"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.label7.Location = New System.Drawing.Point(22, 124)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(356, 17)
        Me.label7.TabIndex = 6
        Me.label7.Text = "Ruta de la carpeta de los nuevos CFDI´s en formato (.pdf)"
        '
        'tbRutaCarpetaPDF
        '
        Me.tbRutaCarpetaPDF.Location = New System.Drawing.Point(25, 150)
        Me.tbRutaCarpetaPDF.Name = "tbRutaCarpetaPDF"
        Me.tbRutaCarpetaPDF.Size = New System.Drawing.Size(483, 23)
        Me.tbRutaCarpetaPDF.TabIndex = 5
        '
        'btnCarpetaPDF
        '
        Me.btnCarpetaPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCarpetaPDF.FlatAppearance.BorderSize = 0
        Me.btnCarpetaPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCarpetaPDF.ForeColor = System.Drawing.Color.White
        Me.btnCarpetaPDF.Location = New System.Drawing.Point(433, 176)
        Me.btnCarpetaPDF.Name = "btnCarpetaPDF"
        Me.btnCarpetaPDF.Size = New System.Drawing.Size(75, 25)
        Me.btnCarpetaPDF.TabIndex = 7
        Me.btnCarpetaPDF.Text = "Guar&dar en"
        Me.btnCarpetaPDF.UseVisualStyleBackColor = False
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.label8.Location = New System.Drawing.Point(22, 39)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(373, 17)
        Me.label8.TabIndex = 3
        Me.label8.Text = "Ruta de la carpeta contenedora  de CFDI´s en formato (.xml)"
        '
        'btnCarpetaXML
        '
        Me.btnCarpetaXML.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCarpetaXML.FlatAppearance.BorderSize = 0
        Me.btnCarpetaXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCarpetaXML.ForeColor = System.Drawing.Color.White
        Me.btnCarpetaXML.Location = New System.Drawing.Point(433, 91)
        Me.btnCarpetaXML.Name = "btnCarpetaXML"
        Me.btnCarpetaXML.Size = New System.Drawing.Size(75, 25)
        Me.btnCarpetaXML.TabIndex = 4
        Me.btnCarpetaXML.Text = "&Elegir"
        Me.btnCarpetaXML.UseVisualStyleBackColor = False
        '
        'panel3
        '
        Me.panel3.BackColor = System.Drawing.Color.White
        Me.panel3.Controls.Add(Me.label6)
        Me.panel3.Controls.Add(Me.label7)
        Me.panel3.Controls.Add(Me.tbRutaCarpetaPDF)
        Me.panel3.Controls.Add(Me.btnCarpetaPDF)
        Me.panel3.Controls.Add(Me.label8)
        Me.panel3.Controls.Add(Me.tbRutaCarpetaXML)
        Me.panel3.Controls.Add(Me.btnCarpetaXML)
        Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel3.Location = New System.Drawing.Point(3, 3)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(521, 209)
        Me.panel3.TabIndex = 1
        '
        'tbRutaCarpetaXML
        '
        Me.tbRutaCarpetaXML.Location = New System.Drawing.Point(25, 65)
        Me.tbRutaCarpetaXML.Name = "tbRutaCarpetaXML"
        Me.tbRutaCarpetaXML.Size = New System.Drawing.Size(483, 23)
        Me.tbRutaCarpetaXML.TabIndex = 2
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.panel1)
        Me.tabPage1.Location = New System.Drawing.Point(4, 24)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(527, 215)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Conversión de archivo"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.White
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Controls.Add(Me.tbDireccionPDF)
        Me.panel1.Controls.Add(Me.btnGuardarEn)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.tbRutaXML)
        Me.panel1.Controls.Add(Me.btnExaminar)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel1.Location = New System.Drawing.Point(3, 3)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(521, 209)
        Me.panel1.TabIndex = 0
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.label3.Location = New System.Drawing.Point(11, 12)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(101, 18)
        Me.label3.TabIndex = 7
        Me.label3.Text = "Ubicaciones"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.label2.Location = New System.Drawing.Point(22, 124)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(258, 17)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Guardar documento en formato (.pdf) en"
        '
        'tbDireccionPDF
        '
        Me.tbDireccionPDF.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDireccionPDF.Location = New System.Drawing.Point(25, 150)
        Me.tbDireccionPDF.Name = "tbDireccionPDF"
        Me.tbDireccionPDF.Size = New System.Drawing.Size(483, 22)
        Me.tbDireccionPDF.TabIndex = 5
        '
        'btnGuardarEn
        '
        Me.btnGuardarEn.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuardarEn.FlatAppearance.BorderSize = 0
        Me.btnGuardarEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardarEn.ForeColor = System.Drawing.Color.White
        Me.btnGuardarEn.Location = New System.Drawing.Point(433, 176)
        Me.btnGuardarEn.Name = "btnGuardarEn"
        Me.btnGuardarEn.Size = New System.Drawing.Size(75, 25)
        Me.btnGuardarEn.TabIndex = 7
        Me.btnGuardarEn.Text = "Guar&dar en"
        Me.btnGuardarEn.UseVisualStyleBackColor = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.label1.Location = New System.Drawing.Point(22, 39)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(373, 17)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Ruta del Comprobante Fiscal Dígital (CFDI) en formato (.xml)"
        '
        'tbRutaXML
        '
        Me.tbRutaXML.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRutaXML.Location = New System.Drawing.Point(25, 65)
        Me.tbRutaXML.Name = "tbRutaXML"
        Me.tbRutaXML.Size = New System.Drawing.Size(483, 22)
        Me.tbRutaXML.TabIndex = 2
        '
        'btnExaminar
        '
        Me.btnExaminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnExaminar.FlatAppearance.BorderSize = 0
        Me.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExaminar.ForeColor = System.Drawing.Color.White
        Me.btnExaminar.Location = New System.Drawing.Point(433, 91)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(75, 25)
        Me.btnExaminar.TabIndex = 4
        Me.btnExaminar.Text = "&Elegir"
        Me.btnExaminar.UseVisualStyleBackColor = False
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.panel3)
        Me.tabPage2.Location = New System.Drawing.Point(4, 24)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(527, 215)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Conversión por carpeta"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.tabControl1.Location = New System.Drawing.Point(23, 251)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(535, 243)
        Me.tabControl1.TabIndex = 12
        '
        'label5
        '
        Me.label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.label5.Location = New System.Drawing.Point(247, 34)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(304, 177)
        Me.label5.TabIndex = 11
        Me.label5.Text = resources.GetString("label5.Text")
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.label4.Location = New System.Drawing.Point(18, 12)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(145, 20)
        Me.label4.TabIndex = 8
        Me.label4.Text = "Logo de la empresa"
        '
        'btnBuscarImagen
        '
        Me.btnBuscarImagen.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBuscarImagen.FlatAppearance.BorderSize = 0
        Me.btnBuscarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarImagen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarImagen.ForeColor = System.Drawing.Color.White
        Me.btnBuscarImagen.Location = New System.Drawing.Point(59, 186)
        Me.btnBuscarImagen.Name = "btnBuscarImagen"
        Me.btnBuscarImagen.Size = New System.Drawing.Size(91, 23)
        Me.btnBuscarImagen.TabIndex = 5
        Me.btnBuscarImagen.Text = "Buscar i&magen"
        Me.btnBuscarImagen.UseVisualStyleBackColor = False
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.White
        Me.panel2.Controls.Add(Me.label4)
        Me.panel2.Controls.Add(Me.btnBuscarImagen)
        Me.panel2.Controls.Add(Me.pictureBox1)
        Me.panel2.Location = New System.Drawing.Point(23, 22)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(200, 220)
        Me.panel2.TabIndex = 10
        '
        'btnCrearPDF
        '
        Me.btnCrearPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(131, Byte), Integer))
        Me.btnCrearPDF.FlatAppearance.BorderSize = 0
        Me.btnCrearPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCrearPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearPDF.ForeColor = System.Drawing.Color.White
        Me.btnCrearPDF.Location = New System.Drawing.Point(23, 508)
        Me.btnCrearPDF.Name = "btnCrearPDF"
        Me.btnCrearPDF.Size = New System.Drawing.Size(531, 55)
        Me.btnCrearPDF.TabIndex = 9
        Me.btnCrearPDF.Text = "&Generar archivo"
        Me.btnCrearPDF.UseVisualStyleBackColor = False
        '
        'pictureBox1
        '
        Me.pictureBox1.Location = New System.Drawing.Point(10, 33)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(176, 147)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 1
        Me.pictureBox1.TabStop = False
        '
        'wGeneraPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(581, 578)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.btnCrearPDF)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "wGeneraPDF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Convertir XML a PDF"
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        Me.tabPage1.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private label6 As System.Windows.Forms.Label

    Private label7 As System.Windows.Forms.Label

    Private tbRutaCarpetaPDF As System.Windows.Forms.TextBox

    Private WithEvents btnCarpetaPDF As System.Windows.Forms.Button

    Private label8 As System.Windows.Forms.Label

    Private WithEvents btnCarpetaXML As System.Windows.Forms.Button

    Private panel3 As System.Windows.Forms.Panel

    Private tbRutaCarpetaXML As System.Windows.Forms.TextBox

    Private tabPage1 As System.Windows.Forms.TabPage

    Private panel1 As System.Windows.Forms.Panel

    Private label3 As System.Windows.Forms.Label

    Private label2 As System.Windows.Forms.Label

    Private tbDireccionPDF As System.Windows.Forms.TextBox

    Private WithEvents btnGuardarEn As System.Windows.Forms.Button

    Private label1 As System.Windows.Forms.Label

    Private tbRutaXML As System.Windows.Forms.TextBox

    Private WithEvents btnExaminar As System.Windows.Forms.Button

    Private tabPage2 As System.Windows.Forms.TabPage

    Private tabControl1 As System.Windows.Forms.TabControl

    Private label5 As System.Windows.Forms.Label

    Private label4 As System.Windows.Forms.Label

    Private WithEvents btnBuscarImagen As System.Windows.Forms.Button

    Private pictureBox1 As System.Windows.Forms.PictureBox

    Private panel2 As System.Windows.Forms.Panel

    Private WithEvents btnCrearPDF As System.Windows.Forms.Button
End Class
