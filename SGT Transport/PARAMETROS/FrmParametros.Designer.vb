<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmParametros
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParametros))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barDatosEmpresa = New System.Windows.Forms.ToolStripButton()
        Me.barParamGenerales = New System.Windows.Forms.ToolStripButton()
        Me.barClientes = New System.Windows.Forms.ToolStripButton()
        Me.barProv = New System.Windows.Forms.ToolStripButton()
        Me.barInvent = New System.Windows.Forms.ToolStripButton()
        Me.barCompras = New System.Windows.Forms.ToolStripButton()
        Me.barVentas = New System.Windows.Forms.ToolStripButton()
        Me.barMontellano = New System.Windows.Forms.ToolStripButton()
        Me.BarSMTP = New System.Windows.Forms.ToolStripButton()
        Me.BarParamFacturaElec = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barDatosEmpresa, Me.barParamGenerales, Me.barClientes, Me.barProv, Me.barInvent, Me.barCompras, Me.barVentas, Me.barMontellano, Me.BarSMTP, Me.BarParamFacturaElec, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(122, 620)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.C1ThemeController1.SetTheme(Me.ToolStrip1, "Office2010Blue")
        '
        'barDatosEmpresa
        '
        Me.barDatosEmpresa.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barDatosEmpresa.Image = Global.SGT_Transport.My.Resources.Resources.empresa12
        Me.barDatosEmpresa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barDatosEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barDatosEmpresa.Name = "barDatosEmpresa"
        Me.barDatosEmpresa.Size = New System.Drawing.Size(119, 49)
        Me.barDatosEmpresa.Text = "Datos de la empresa"
        Me.barDatosEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barParamGenerales
        '
        Me.barParamGenerales.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barParamGenerales.Image = Global.SGT_Transport.My.Resources.Resources.empresa14
        Me.barParamGenerales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barParamGenerales.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barParamGenerales.Name = "barParamGenerales"
        Me.barParamGenerales.Size = New System.Drawing.Size(119, 49)
        Me.barParamGenerales.Text = "Parametros generales"
        Me.barParamGenerales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barClientes
        '
        Me.barClientes.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barClientes.Image = Global.SGT_Transport.My.Resources.Resources.person_autoriza1
        Me.barClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barClientes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barClientes.Name = "barClientes"
        Me.barClientes.Size = New System.Drawing.Size(119, 49)
        Me.barClientes.Text = "Clientes y CxC"
        Me.barClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barProv
        '
        Me.barProv.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barProv.Image = Global.SGT_Transport.My.Resources.Resources.dando
        Me.barProv.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barProv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barProv.Name = "barProv"
        Me.barProv.Size = New System.Drawing.Size(119, 49)
        Me.barProv.Text = "Proveedores y CxP"
        Me.barProv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barInvent
        '
        Me.barInvent.Image = Global.SGT_Transport.My.Resources.Resources.inventario1
        Me.barInvent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barInvent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barInvent.Name = "barInvent"
        Me.barInvent.Size = New System.Drawing.Size(119, 51)
        Me.barInvent.Text = "Inventario"
        Me.barInvent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barCompras
        '
        Me.barCompras.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barCompras.Image = Global.SGT_Transport.My.Resources.Resources.cart
        Me.barCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barCompras.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barCompras.Name = "barCompras"
        Me.barCompras.Size = New System.Drawing.Size(119, 49)
        Me.barCompras.Text = "Compras"
        Me.barCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barVentas
        '
        Me.barVentas.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barVentas.Image = Global.SGT_Transport.My.Resources.Resources.ventas2
        Me.barVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barVentas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barVentas.Name = "barVentas"
        Me.barVentas.Size = New System.Drawing.Size(119, 49)
        Me.barVentas.Text = "Ventas"
        Me.barVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barMontellano
        '
        Me.barMontellano.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barMontellano.Image = Global.SGT_Transport.My.Resources.Resources.cerezo11
        Me.barMontellano.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barMontellano.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barMontellano.Name = "barMontellano"
        Me.barMontellano.Size = New System.Drawing.Size(119, 49)
        Me.barMontellano.Text = "TransportCG"
        Me.barMontellano.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSMTP
        '
        Me.BarSMTP.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarSMTP.Image = Global.SGT_Transport.My.Resources.Resources.smtp3
        Me.BarSMTP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSMTP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarSMTP.Name = "BarSMTP"
        Me.BarSMTP.Size = New System.Drawing.Size(119, 38)
        Me.BarSMTP.Text = "SMTP"
        Me.BarSMTP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarParamFacturaElec
        '
        Me.BarParamFacturaElec.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarParamFacturaElec.Image = Global.SGT_Transport.My.Resources.Resources.cfdi20_e
        Me.BarParamFacturaElec.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarParamFacturaElec.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarParamFacturaElec.Name = "BarParamFacturaElec"
        Me.BarParamFacturaElec.Size = New System.Drawing.Size(119, 49)
        Me.BarParamFacturaElec.Text = "Factura electronica"
        Me.BarParamFacturaElec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton1.Image = Global.SGT_Transport.My.Resources.Resources.CFDI31_e
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(119, 49)
        Me.ToolStripButton1.Text = "Series CFDI"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.CanCloseTabs = True
        Me.Tab1.CanMoveTabs = True
        Me.Tab1.CloseBox = C1.Win.C1Command.CloseBoxPositionEnum.AllPages
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(122, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedIndex = 1
        Me.Tab1.SelectedTabBold = True
        Me.Tab1.ShowTabList = True
        Me.Tab1.Size = New System.Drawing.Size(840, 620)
        Me.Tab1.TabIndex = 4
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.C1ThemeController1.SetTheme(Me.Tab1, "Office2010Blue")
        '
        'FrmParametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 620)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParametros"
        Me.ShowInTaskbar = False
        Me.Text = "Parametros de configuración"
        Me.C1ThemeController1.SetTheme(Me, "Office2010Blue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents barDatosEmpresa As ToolStripButton
    Friend WithEvents barParamGenerales As ToolStripButton
    Friend WithEvents barClientes As ToolStripButton
    Friend WithEvents barProv As ToolStripButton
    Friend WithEvents barInvent As ToolStripButton
    Friend WithEvents barCompras As ToolStripButton
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents barVentas As ToolStripButton
    Friend WithEvents barMontellano As ToolStripButton
    Friend WithEvents BarSMTP As ToolStripButton
    Friend WithEvents BarParamFacturaElec As ToolStripButton
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents ToolStripButton1 As ToolStripButton
End Class
