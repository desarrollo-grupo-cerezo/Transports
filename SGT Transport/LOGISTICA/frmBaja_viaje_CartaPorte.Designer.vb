
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBaja_viaje_CartaPorte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBaja_viaje_CartaPorte))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.LtCliente = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BarraAbajo = New System.Windows.Forms.ToolStrip()
        Me.BHoy = New System.Windows.Forms.ToolStripButton()
        Me.BAyer = New System.Windows.Forms.ToolStripButton()
        Me.BEsteMes = New System.Windows.Forms.ToolStripButton()
        Me.BMesAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BTodos = New System.Windows.Forms.ToolStripButton()
        Me.BarConsultar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRF = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRT = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarTimbrarCPConPrecios = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCFDI = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarReactivar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.BarraAbajo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(12, 67)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.Size = New System.Drawing.Size(585, 457)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 12
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarConsultar, Me.BarRF, Me.BarRT, Me.BarTimbrarCPConPrecios, Me.BarCFDI, Me.BarReactivar, Me.BarActualizar, Me.BarExcel, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(1369, 55)
        Me.BarraMenu.TabIndex = 11
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "cd52cf85db7f44deae505224be4f8c2a"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Location = New System.Drawing.Point(1246, 10)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(39, 13)
        Me.Lt1.TabIndex = 15
        Me.Lt1.Text = "Cliente"
        '
        'LtCliente
        '
        Me.LtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCliente.Location = New System.Drawing.Point(1291, 9)
        Me.LtCliente.Name = "LtCliente"
        Me.LtCliente.Size = New System.Drawing.Size(66, 19)
        Me.LtCliente.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(972, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(267, 41)
        Me.Panel1.TabIndex = 350
        '
        'TBox
        '
        Me.TBox.Location = New System.Drawing.Point(88, 12)
        Me.TBox.Name = "TBox"
        Me.TBox.Size = New System.Drawing.Size(173, 20)
        Me.TBox.TabIndex = 348
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 347
        Me.Label1.Text = "Texto a buscar"
        '
        'BarraAbajo
        '
        Me.BarraAbajo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraAbajo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BHoy, Me.BAyer, Me.BEsteMes, Me.BMesAnterior, Me.BTodos})
        Me.BarraAbajo.Location = New System.Drawing.Point(0, 527)
        Me.BarraAbajo.Name = "BarraAbajo"
        Me.BarraAbajo.Size = New System.Drawing.Size(1369, 25)
        Me.BarraAbajo.TabIndex = 351
        Me.BarraAbajo.Text = "ToolStrip1"
        '
        'BHoy
        '
        Me.BHoy.AutoSize = False
        Me.BHoy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BHoy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BHoy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BHoy.Name = "BHoy"
        Me.BHoy.Size = New System.Drawing.Size(80, 22)
        Me.BHoy.Text = "Hoy"
        '
        'BAyer
        '
        Me.BAyer.AutoSize = False
        Me.BAyer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BAyer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BAyer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BAyer.Name = "BAyer"
        Me.BAyer.Size = New System.Drawing.Size(80, 22)
        Me.BAyer.Text = "Ayer"
        '
        'BEsteMes
        '
        Me.BEsteMes.AutoSize = False
        Me.BEsteMes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BEsteMes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BEsteMes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEsteMes.Name = "BEsteMes"
        Me.BEsteMes.Size = New System.Drawing.Size(80, 22)
        Me.BEsteMes.Text = "Este Mes"
        '
        'BMesAnterior
        '
        Me.BMesAnterior.AutoSize = False
        Me.BMesAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BMesAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BMesAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BMesAnterior.Name = "BMesAnterior"
        Me.BMesAnterior.Size = New System.Drawing.Size(80, 22)
        Me.BMesAnterior.Text = "Mes Anterior"
        '
        'BTodos
        '
        Me.BTodos.AutoSize = False
        Me.BTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BTodos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTodos.Name = "BTodos"
        Me.BTodos.Size = New System.Drawing.Size(80, 22)
        Me.BTodos.Text = "Todos"
        '
        'BarConsultar
        '
        Me.BarConsultar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarConsultar.ForeColor = System.Drawing.Color.Black
        Me.BarConsultar.Image = CType(resources.GetObject("BarConsultar.Image"), System.Drawing.Image)
        Me.BarConsultar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarConsultar.Name = "BarConsultar"
        Me.BarConsultar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarConsultar.Size = New System.Drawing.Size(70, 51)
        Me.BarConsultar.Text = "Consultar"
        Me.BarConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRF
        '
        Me.BarRF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarRF.ForeColor = System.Drawing.Color.Black
        Me.BarRF.Image = Global.SGT_Transport.My.Resources.Resources.RF3
        Me.BarRF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRF.Name = "BarRF"
        Me.BarRF.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarRF.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarRF.Size = New System.Drawing.Size(68, 51)
        Me.BarRF.Text = "Remision"
        Me.BarRF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarRF.ToolTipText = "F2-Nuevo"
        '
        'BarRT
        '
        Me.BarRT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarRT.ForeColor = System.Drawing.Color.Black
        Me.BarRT.Image = Global.SGT_Transport.My.Resources.Resources.RT
        Me.BarRT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRT.Name = "BarRT"
        Me.BarRT.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarRT.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarRT.Size = New System.Drawing.Size(68, 51)
        Me.BarRT.Text = "Remision"
        Me.BarRT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarRT.ToolTipText = "F2-Nuevo"
        '
        'BarTimbrarCPConPrecios
        '
        Me.BarTimbrarCPConPrecios.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarTimbrarCPConPrecios.ForeColor = System.Drawing.Color.Black
        Me.BarTimbrarCPConPrecios.Image = Global.SGT_Transport.My.Resources.Resources.cfdix1
        Me.BarTimbrarCPConPrecios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarTimbrarCPConPrecios.Name = "BarTimbrarCPConPrecios"
        Me.BarTimbrarCPConPrecios.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarTimbrarCPConPrecios.Size = New System.Drawing.Size(89, 51)
        Me.BarTimbrarCPConPrecios.Text = "Timbrar carta"
        Me.BarTimbrarCPConPrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarCFDI
        '
        Me.BarCFDI.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarCFDI.ForeColor = System.Drawing.Color.Black
        Me.BarCFDI.Image = Global.SGT_Transport.My.Resources.Resources.xml1
        Me.BarCFDI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCFDI.Name = "BarCFDI"
        Me.BarCFDI.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarCFDI.Size = New System.Drawing.Size(106, 51)
        Me.BarCFDI.Text = "CFDI Carta porte"
        Me.BarCFDI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarReactivar
        '
        Me.BarReactivar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarReactivar.ForeColor = System.Drawing.Color.Black
        Me.BarReactivar.Image = Global.SGT_Transport.My.Resources.Resources.reactivar2
        Me.BarReactivar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarReactivar.Name = "BarReactivar"
        Me.BarReactivar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarReactivar.Size = New System.Drawing.Size(67, 51)
        Me.BarReactivar.Text = "Reactivar"
        Me.BarReactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarActualizar
        '
        Me.BarActualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarActualizar.ForeColor = System.Drawing.Color.Black
        Me.BarActualizar.Image = Global.SGT_Transport.My.Resources.Resources.rotate
        Me.BarActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarActualizar.Name = "BarActualizar"
        Me.BarActualizar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarActualizar.Size = New System.Drawing.Size(71, 51)
        Me.BarActualizar.Text = "Actualizar"
        Me.BarActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(46, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'FrmBaja_viaje_CartaPorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1369, 552)
        Me.Controls.Add(Me.BarraAbajo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LtCliente)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmBaja_viaje_CartaPorte"
        Me.Text = "Baja de viaje carta porte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.BarraAbajo.ResumeLayout(False)
        Me.BarraAbajo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarRF As ToolStripMenuItem
    Friend WithEvents BarReactivar As ToolStripMenuItem
    Friend WithEvents BarConsultar As ToolStripMenuItem
    Friend WithEvents BarActualizar As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents BarRT As ToolStripMenuItem
    Friend WithEvents Lt1 As Label
    Friend WithEvents LtCliente As Label
    Friend WithEvents BarCFDI As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BarTimbrarCPConPrecios As ToolStripMenuItem
    Friend WithEvents BarraAbajo As ToolStrip
    Friend WithEvents BHoy As ToolStripButton
    Friend WithEvents BAyer As ToolStripButton
    Friend WithEvents BEsteMes As ToolStripButton
    Friend WithEvents BMesAnterior As ToolStripButton
    Friend WithEvents BTodos As ToolStripButton
End Class
