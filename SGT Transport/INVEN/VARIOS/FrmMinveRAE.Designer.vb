<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMinveRAE
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMinveRAE))
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barAgregar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barReimprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnNumCpto = New C1.Win.C1Input.C1Button()
        Me.L1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tREFER = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSel = New C1.Win.C1Input.C1Button()
        Me.L2 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.StiReport2 = New Stimulsoft.Report.StiReport()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.btnSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.barAgregar, Me.barEliminar, Me.barReimprimir, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(720, 55)
        Me.barSalir.TabIndex = 11
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = ""
        Me.barGrabar.Size = New System.Drawing.Size(57, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barGrabar.ToolTipText = "F2-Nuevo"
        '
        'barAgregar
        '
        Me.barAgregar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barAgregar.ForeColor = System.Drawing.Color.Black
        Me.barAgregar.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.barAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAgregar.Name = "barAgregar"
        Me.barAgregar.Size = New System.Drawing.Size(64, 51)
        Me.barAgregar.Text = "Agregar"
        Me.barAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barEliminar
        '
        Me.barEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barEliminar.ForeColor = System.Drawing.Color.Black
        Me.barEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.barEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEliminar.Name = "barEliminar"
        Me.barEliminar.Size = New System.Drawing.Size(63, 51)
        Me.barEliminar.Text = "Eliminar"
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barReimprimir
        '
        Me.barReimprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barReimprimir.ForeColor = System.Drawing.Color.Black
        Me.barReimprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.barReimprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barReimprimir.Name = "barReimprimir"
        Me.barReimprimir.Size = New System.Drawing.Size(82, 51)
        Me.barReimprimir.Text = "Reimprimir"
        Me.barReimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.btnNumCpto)
        Me.Panel5.Controls.Add(Me.L1)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.tNUM_CPTO)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Location = New System.Drawing.Point(4, 68)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(346, 102)
        Me.Panel5.TabIndex = 33
        '
        'btnNumCpto
        '
        Me.btnNumCpto.ForeColor = System.Drawing.Color.Black
        Me.btnNumCpto.Image = CType(resources.GetObject("btnNumCpto.Image"), System.Drawing.Image)
        Me.btnNumCpto.Location = New System.Drawing.Point(123, 40)
        Me.btnNumCpto.Name = "btnNumCpto"
        Me.btnNumCpto.Size = New System.Drawing.Size(26, 20)
        Me.btnNumCpto.TabIndex = 10
        Me.btnNumCpto.UseVisualStyleBackColor = True
        Me.btnNumCpto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'L1
        '
        Me.L1.BackColor = System.Drawing.Color.Transparent
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(74, 66)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(256, 20)
        Me.L1.TabIndex = 134
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(9, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 159
        Me.Label8.Text = "Descripción"
        '
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.Location = New System.Drawing.Point(74, 40)
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(47, 20)
        Me.tNUM_CPTO.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(9, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Num.  cpto"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(-1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(346, 22)
        Me.Label6.TabIndex = 157
        Me.Label6.Text = "Concepto"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tREFER
        '
        Me.tREFER.AcceptsReturn = True
        Me.tREFER.AcceptsTab = True
        Me.tREFER.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tREFER.Location = New System.Drawing.Point(71, 66)
        Me.tREFER.Name = "tREFER"
        Me.tREFER.Size = New System.Drawing.Size(92, 20)
        Me.tREFER.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnSel)
        Me.Panel1.Controls.Add(Me.L2)
        Me.Panel1.Controls.Add(Me.tREFER)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(356, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(346, 102)
        Me.Panel1.TabIndex = 34
        '
        'btnSel
        '
        Me.btnSel.AutoSize = True
        Me.btnSel.Image = CType(resources.GetObject("btnSel.Image"), System.Drawing.Image)
        Me.btnSel.Location = New System.Drawing.Point(317, 66)
        Me.btnSel.Name = "btnSel"
        Me.btnSel.Size = New System.Drawing.Size(24, 25)
        Me.btnSel.TabIndex = 164
        Me.btnSel.UseVisualStyleBackColor = True
        Me.btnSel.Visible = False
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.Transparent
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(71, 39)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(202, 20)
        Me.L2.TabIndex = 134
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Documento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(9, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Tipo"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(-1, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(346, 22)
        Me.Label4.TabIndex = 157
        Me.Label4.Text = "Documento"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV.Location = New System.Drawing.Point(248, 189)
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(47, 20)
        Me.tCVE_PROV.TabIndex = 3
        Me.tCVE_PROV.Visible = False
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(47, 189)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(132, 19)
        Me.F1.TabIndex = 2
        Me.F1.Tag = Nothing
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.Location = New System.Drawing.Point(5, 191)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(37, 13)
        Me.Label90.TabIndex = 155
        Me.Label90.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(191, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 160
        Me.Label5.Text = "Proveedor"
        Me.Label5.Visible = False
        '
        'L3
        '
        Me.L3.BackColor = System.Drawing.Color.Transparent
        Me.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.Location = New System.Drawing.Point(322, 189)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(202, 20)
        Me.L3.TabIndex = 160
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.L3.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(526, 192)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 162
        Me.Label10.Text = "Almacen"
        '
        'cboAlmacen
        '
        Me.cboAlmacen.AllowSpinLoop = False
        Me.cboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboAlmacen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboAlmacen.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboAlmacen.GapHeight = 0
        Me.cboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboAlmacen.ItemsDisplayMember = ""
        Me.cboAlmacen.ItemsValueMember = ""
        Me.cboAlmacen.Location = New System.Drawing.Point(575, 189)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(127, 18)
        Me.cboAlmacen.TabIndex = 4
        Me.cboAlmacen.Tag = Nothing
        Me.cboAlmacen.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.cboAlmacen.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'StiReport2
        '
        Me.StiReport2.CookieContainer = Nothing
        Me.StiReport2.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport2.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport2.ReportAlias = "Report"
        Me.StiReport2.ReportGuid = "6431435e20c44ed8a255080ce67b4eb6"
        Me.StiReport2.ReportImage = Nothing
        Me.StiReport2.ReportName = "Report"
        Me.StiReport2.ReportSource = Nothing
        Me.StiReport2.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport2.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport2.UseProgressInThread = False
        '
        'btnProv
        '
        Me.btnProv.ForeColor = System.Drawing.Color.Black
        Me.btnProv.Image = CType(resources.GetObject("btnProv.Image"), System.Drawing.Image)
        Me.btnProv.Location = New System.Drawing.Point(295, 189)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(26, 20)
        Me.btnProv.TabIndex = 11
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.Visible = False
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.CellButtonImage = CType(resources.GetObject("Fg.CellButtonImage"), System.Drawing.Image)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(4, 228)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.Size = New System.Drawing.Size(698, 221)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 5
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'frmMinveRAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 476)
        Me.Controls.Add(Me.cboAlmacen)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnProv)
        Me.Controls.Add(Me.L3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label90)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tCVE_PROV)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMinveRAE"
        Me.Text = "Movimientos al Inventario"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2007Silver
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.btnNumCpto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btnSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents barAgregar As ToolStripMenuItem
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel5 As Panel
    Friend WithEvents tREFER As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tNUM_CPTO As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents L1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents L2 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label90 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents L3 As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents Label10 As Label
    Friend WithEvents cboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents btnNumCpto As C1.Win.C1Input.C1Button
    Friend WithEvents btnSel As C1.Win.C1Input.C1Button
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents barReimprimir As ToolStripMenuItem
    Friend WithEvents StiReport2 As Stimulsoft.Report.StiReport
End Class
