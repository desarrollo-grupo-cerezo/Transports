<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjuntarXML
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdjuntarXML))
        Me.btnXML = New System.Windows.Forms.Button()
        Me.tXML = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtFecha = New System.Windows.Forms.Label()
        Me.LtTotal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtVersion = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LtMoneda = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtFormaPago = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LtUsoCFDI = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LtTipoComprobante = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LtFolio = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtSerie = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.BtnDEsAsociarXml = New System.Windows.Forms.Button()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnXML
        '
        Me.btnXML.BackColor = System.Drawing.Color.Transparent
        Me.btnXML.ForeColor = System.Drawing.Color.Black
        Me.btnXML.Location = New System.Drawing.Point(639, 99)
        Me.btnXML.Name = "btnXML"
        Me.btnXML.Size = New System.Drawing.Size(27, 23)
        Me.btnXML.TabIndex = 216
        Me.btnXML.Text = "....."
        Me.C1ThemeController1.SetTheme(Me.btnXML, "Office2007Blue")
        Me.btnXML.UseVisualStyleBackColor = True
        '
        'tXML
        '
        Me.tXML.AcceptsReturn = True
        Me.tXML.AcceptsTab = True
        Me.tXML.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tXML.ForeColor = System.Drawing.Color.Black
        Me.tXML.Location = New System.Drawing.Point(21, 101)
        Me.tXML.Name = "tXML"
        Me.tXML.Size = New System.Drawing.Size(612, 21)
        Me.tXML.TabIndex = 215
        Me.C1ThemeController1.SetTheme(Me.tXML, "Office2007Blue")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "Archivo XML"
        Me.C1ThemeController1.SetTheme(Me.Label1, "Office2007Blue")
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.BtnAceptar.ForeColor = System.Drawing.Color.Black
        Me.BtnAceptar.Location = New System.Drawing.Point(21, 21)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(89, 28)
        Me.BtnAceptar.TabIndex = 233
        Me.BtnAceptar.Text = "Aceptar"
        Me.C1ThemeController1.SetTheme(Me.BtnAceptar, "Office2007Blue")
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancelar.ForeColor = System.Drawing.Color.Black
        Me.BtnCancelar.Location = New System.Drawing.Point(253, 21)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(89, 28)
        Me.BtnCancelar.TabIndex = 234
        Me.BtnCancelar.Text = "Cancelar"
        Me.C1ThemeController1.SetTheme(Me.BtnCancelar, "Office2007Blue")
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 16)
        Me.Label2.TabIndex = 235
        Me.Label2.Text = "Fecha de registro"
        Me.C1ThemeController1.SetTheme(Me.Label2, "Office2007Blue")
        '
        'LtFecha
        '
        Me.LtFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFecha.ForeColor = System.Drawing.Color.Black
        Me.LtFecha.Location = New System.Drawing.Point(133, 174)
        Me.LtFecha.Name = "LtFecha"
        Me.LtFecha.Size = New System.Drawing.Size(277, 22)
        Me.LtFecha.TabIndex = 236
        Me.C1ThemeController1.SetTheme(Me.LtFecha, "Office2007Blue")
        '
        'LtTotal
        '
        Me.LtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotal.ForeColor = System.Drawing.Color.Black
        Me.LtTotal.Location = New System.Drawing.Point(540, 145)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(126, 22)
        Me.LtTotal.TabIndex = 238
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.C1ThemeController1.SetTheme(Me.LtTotal, "Office2007Blue")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(495, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 16)
        Me.Label5.TabIndex = 237
        Me.Label5.Text = "Total"
        Me.C1ThemeController1.SetTheme(Me.Label5, "Office2007Blue")
        '
        'LtVersion
        '
        Me.LtVersion.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtVersion.ForeColor = System.Drawing.Color.Black
        Me.LtVersion.Location = New System.Drawing.Point(501, 203)
        Me.LtVersion.Name = "LtVersion"
        Me.LtVersion.Size = New System.Drawing.Size(38, 22)
        Me.LtVersion.TabIndex = 240
        Me.LtVersion.Text = "3.3"
        Me.LtVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtVersion, "Office2007Blue")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(441, 205)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 239
        Me.Label7.Text = "Versión"
        Me.C1ThemeController1.SetTheme(Me.Label7, "Office2007Blue")
        '
        'LtMoneda
        '
        Me.LtMoneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMoneda.ForeColor = System.Drawing.Color.Black
        Me.LtMoneda.Location = New System.Drawing.Point(628, 203)
        Me.LtMoneda.Name = "LtMoneda"
        Me.LtMoneda.Size = New System.Drawing.Size(38, 22)
        Me.LtMoneda.TabIndex = 242
        Me.LtMoneda.Text = "MXN"
        Me.LtMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtMoneda, "Office2007Blue")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(564, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 16)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Moneda"
        Me.C1ThemeController1.SetTheme(Me.Label9, "Office2007Blue")
        '
        'LtFormaPago
        '
        Me.LtFormaPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LtFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFormaPago.ForeColor = System.Drawing.Color.Black
        Me.LtFormaPago.Location = New System.Drawing.Point(540, 174)
        Me.LtFormaPago.Name = "LtFormaPago"
        Me.LtFormaPago.Size = New System.Drawing.Size(126, 22)
        Me.LtFormaPago.TabIndex = 244
        Me.LtFormaPago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtFormaPago, "Office2007Blue")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(433, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 16)
        Me.Label11.TabIndex = 243
        Me.Label11.Text = "Forma de pago"
        Me.C1ThemeController1.SetTheme(Me.Label11, "Office2007Blue")
        '
        'LtUsoCFDI
        '
        Me.LtUsoCFDI.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LtUsoCFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUsoCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUsoCFDI.ForeColor = System.Drawing.Color.Black
        Me.LtUsoCFDI.Location = New System.Drawing.Point(303, 203)
        Me.LtUsoCFDI.Name = "LtUsoCFDI"
        Me.LtUsoCFDI.Size = New System.Drawing.Size(107, 22)
        Me.LtUsoCFDI.TabIndex = 246
        Me.LtUsoCFDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtUsoCFDI, "Office2007Blue")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(231, 205)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 16)
        Me.Label13.TabIndex = 245
        Me.Label13.Text = "Uso CFDI"
        Me.C1ThemeController1.SetTheme(Me.Label13, "Office2007Blue")
        '
        'LtTipoComprobante
        '
        Me.LtTipoComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LtTipoComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTipoComprobante.ForeColor = System.Drawing.Color.Black
        Me.LtTipoComprobante.Location = New System.Drawing.Point(133, 203)
        Me.LtTipoComprobante.Name = "LtTipoComprobante"
        Me.LtTipoComprobante.Size = New System.Drawing.Size(93, 22)
        Me.LtTipoComprobante.TabIndex = 248
        Me.LtTipoComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtTipoComprobante, "Office2007Blue")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(8, 205)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(119, 16)
        Me.Label15.TabIndex = 247
        Me.Label15.Text = "Tipo comprobante"
        Me.C1ThemeController1.SetTheme(Me.Label15, "Office2007Blue")
        '
        'LtFolio
        '
        Me.LtFolio.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFolio.ForeColor = System.Drawing.Color.Black
        Me.LtFolio.Location = New System.Drawing.Point(303, 145)
        Me.LtFolio.Name = "LtFolio"
        Me.LtFolio.Size = New System.Drawing.Size(107, 22)
        Me.LtFolio.TabIndex = 252
        Me.LtFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.C1ThemeController1.SetTheme(Me.LtFolio, "Office2007Blue")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(259, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 16)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Folio"
        Me.C1ThemeController1.SetTheme(Me.Label4, "Office2007Blue")
        '
        'LtSerie
        '
        Me.LtSerie.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSerie.ForeColor = System.Drawing.Color.Black
        Me.LtSerie.Location = New System.Drawing.Point(133, 145)
        Me.LtSerie.Name = "LtSerie"
        Me.LtSerie.Size = New System.Drawing.Size(93, 22)
        Me.LtSerie.TabIndex = 250
        Me.C1ThemeController1.SetTheme(Me.LtSerie, "Office2007Blue")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(87, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 249
        Me.Label8.Text = "Serie"
        Me.C1ThemeController1.SetTheme(Me.Label8, "Office2007Blue")
        '
        'BtnDEsAsociarXml
        '
        Me.BtnDEsAsociarXml.BackColor = System.Drawing.Color.Transparent
        Me.BtnDEsAsociarXml.ForeColor = System.Drawing.Color.Black
        Me.BtnDEsAsociarXml.Location = New System.Drawing.Point(137, 21)
        Me.BtnDEsAsociarXml.Name = "BtnDEsAsociarXml"
        Me.BtnDEsAsociarXml.Size = New System.Drawing.Size(89, 28)
        Me.BtnDEsAsociarXml.TabIndex = 253
        Me.BtnDEsAsociarXml.Text = "Desasociar xml"
        Me.C1ThemeController1.SetTheme(Me.BtnDEsAsociarXml, "Office2007Blue")
        Me.BtnDEsAsociarXml.UseVisualStyleBackColor = True
        '
        'frmAdjuntarXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 279)
        Me.Controls.Add(Me.BtnDEsAsociarXml)
        Me.Controls.Add(Me.LtFolio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LtSerie)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LtTipoComprobante)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.LtUsoCFDI)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.LtFormaPago)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LtMoneda)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LtVersion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LtTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LtFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.btnXML)
        Me.Controls.Add(Me.tXML)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAdjuntarXML"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjuntar XML"
        Me.C1ThemeController1.SetTheme(Me, "Office2007Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnXML As Button
    Friend WithEvents tXML As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents LtFecha As Label
    Friend WithEvents LtTotal As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LtVersion As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LtMoneda As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LtFormaPago As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LtUsoCFDI As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents LtTipoComprobante As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents LtFolio As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LtSerie As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents BtnDEsAsociarXml As Button
End Class
