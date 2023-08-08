<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRecepcionPagosCxC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecepcionPagosCxC))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraCompras = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.LtTotalPagos = New System.Windows.Forms.Label()
        Me.LtSaldo = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.LtDocActual = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.TCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDoc = New C1.Win.C1Input.C1Button()
        Me.tREFER = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnConc = New C1.Win.C1Input.C1Button()
        Me.tMagico = New System.Windows.Forms.TextBox()
        Me.LtNO_FACTURA = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraCompras.SuspendLayout()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnConc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit) _
            Or C1.Win.C1FlexGrid.EditFlags.ExitOnLeftRightKeys) _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(12, 160)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(617, 163)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 3
        '
        'BarraCompras
        '
        Me.BarraCompras.AutoSize = False
        Me.BarraCompras.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.BarraCompras.ImageScalingSize = New System.Drawing.Size(12, 12)
        Me.BarraCompras.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.barEliminar, Me.barSalir})
        Me.BarraCompras.Location = New System.Drawing.Point(0, 0)
        Me.BarraCompras.Name = "BarraCompras"
        Me.BarraCompras.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.BarraCompras.Size = New System.Drawing.Size(718, 60)
        Me.BarraCompras.Stretch = False
        Me.BarraCompras.TabIndex = 4
        Me.BarraCompras.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.Padding = New System.Windows.Forms.Padding(4, 15, 4, 0)
        Me.barGrabar.ShortcutKeyDisplayString = ""
        Me.barGrabar.ShowShortcutKeys = False
        Me.barGrabar.Size = New System.Drawing.Size(54, 52)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barGrabar.ToolTipText = "F2-Nuevo"
        '
        'barEliminar
        '
        Me.barEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barEliminar.ForeColor = System.Drawing.Color.Black
        Me.barEliminar.Image = Global.SGT_Transport.My.Resources.Resources.grideiminar
        Me.barEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEliminar.Name = "barEliminar"
        Me.barEliminar.Size = New System.Drawing.Size(85, 52)
        Me.barEliminar.Text = "Eliminar par."
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barSalir
        '
        Me.barSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barSalir.ForeColor = System.Drawing.Color.Black
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Padding = New System.Windows.Forms.Padding(4, 15, 4, 0)
        Me.barSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.barSalir.Size = New System.Drawing.Size(44, 52)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LtTotalPagos
        '
        Me.LtTotalPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotalPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotalPagos.Location = New System.Drawing.Point(494, 341)
        Me.LtTotalPagos.Name = "LtTotalPagos"
        Me.LtTotalPagos.Size = New System.Drawing.Size(135, 22)
        Me.LtTotalPagos.TabIndex = 120
        Me.LtTotalPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtSaldo
        '
        Me.LtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSaldo.Location = New System.Drawing.Point(271, 341)
        Me.LtSaldo.Name = "LtSaldo"
        Me.LtSaldo.Size = New System.Drawing.Size(135, 22)
        Me.LtSaldo.TabIndex = 124
        Me.LtSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(223, 344)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(44, 16)
        Me.Label21.TabIndex = 123
        Me.Label21.Text = "Saldo"
        '
        'LtDocActual
        '
        Me.LtDocActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDocActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDocActual.Location = New System.Drawing.Point(79, 341)
        Me.LtDocActual.Name = "LtDocActual"
        Me.LtDocActual.Size = New System.Drawing.Size(135, 22)
        Me.LtDocActual.TabIndex = 122
        Me.LtDocActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(411, 344)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 16)
        Me.Label20.TabIndex = 119
        Me.Label20.Text = "Total pagos"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(2, 344)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 16)
        Me.Label18.TabIndex = 121
        Me.Label18.Text = "Doc. actual"
        '
        'btnProv
        '
        Me.btnProv.AutoSize = True
        Me.btnProv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnProv.Image = CType(resources.GetObject("btnProv.Image"), System.Drawing.Image)
        Me.btnProv.Location = New System.Drawing.Point(201, 75)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(22, 22)
        Me.btnProv.TabIndex = 298
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCLIENTE
        '
        Me.TCLIENTE.AcceptsReturn = True
        Me.TCLIENTE.AcceptsTab = True
        Me.TCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE.Location = New System.Drawing.Point(110, 75)
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(88, 22)
        Me.TCLIENTE.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(62, 78)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 16)
        Me.Label14.TabIndex = 297
        Me.Label14.Text = "Clave"
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(291, 75)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(338, 22)
        Me.LtNombre.TabIndex = 300
        Me.LtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(233, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 16)
        Me.Label2.TabIndex = 299
        Me.Label2.Text = "Nombre"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(110, 104)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(110, 20)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(59, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 301
        Me.Label3.Text = "Fecha"
        '
        'btnDoc
        '
        Me.btnDoc.AutoSize = True
        Me.btnDoc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDoc.Image = CType(resources.GetObject("btnDoc.Image"), System.Drawing.Image)
        Me.btnDoc.Location = New System.Drawing.Point(245, 132)
        Me.btnDoc.Name = "btnDoc"
        Me.btnDoc.Size = New System.Drawing.Size(22, 22)
        Me.btnDoc.TabIndex = 305
        Me.btnDoc.UseVisualStyleBackColor = True
        Me.btnDoc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tREFER
        '
        Me.tREFER.AcceptsReturn = True
        Me.tREFER.AcceptsTab = True
        Me.tREFER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tREFER.Location = New System.Drawing.Point(110, 131)
        Me.tREFER.Name = "tREFER"
        Me.tREFER.Size = New System.Drawing.Size(132, 22)
        Me.tREFER.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 16)
        Me.Label4.TabIndex = 304
        Me.Label4.Text = "Documento"
        '
        'btnConc
        '
        Me.btnConc.AutoSize = True
        Me.btnConc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnConc.Image = Global.SGT_Transport.My.Resources.Resources.lupu16
        Me.btnConc.Location = New System.Drawing.Point(762, 159)
        Me.btnConc.Name = "btnConc"
        Me.btnConc.Size = New System.Drawing.Size(22, 22)
        Me.btnConc.TabIndex = 306
        Me.btnConc.UseVisualStyleBackColor = True
        Me.btnConc.Visible = False
        Me.btnConc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tMagico
        '
        Me.tMagico.AcceptsReturn = True
        Me.tMagico.AcceptsTab = True
        Me.tMagico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tMagico.Location = New System.Drawing.Point(789, 238)
        Me.tMagico.Name = "tMagico"
        Me.tMagico.Size = New System.Drawing.Size(57, 22)
        Me.tMagico.TabIndex = 356
        '
        'LtNO_FACTURA
        '
        Me.LtNO_FACTURA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNO_FACTURA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNO_FACTURA.Location = New System.Drawing.Point(291, 129)
        Me.LtNO_FACTURA.Name = "LtNO_FACTURA"
        Me.LtNO_FACTURA.Size = New System.Drawing.Size(338, 22)
        Me.LtNO_FACTURA.TabIndex = 357
        Me.LtNO_FACTURA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "ceda627063734c60b959d6fbcfcde1a8"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'frmRecepcionPagosCxC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 377)
        Me.Controls.Add(Me.LtNO_FACTURA)
        Me.Controls.Add(Me.tMagico)
        Me.Controls.Add(Me.btnConc)
        Me.Controls.Add(Me.btnDoc)
        Me.Controls.Add(Me.tREFER)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnProv)
        Me.Controls.Add(Me.TCLIENTE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LtTotalPagos)
        Me.Controls.Add(Me.LtSaldo)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.LtDocActual)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.BarraCompras)
        Me.Controls.Add(Me.Fg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRecepcionPagosCxC"
        Me.ShowInTaskbar = False
        Me.Text = "Recepción de pagos cuentas por cobrar"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraCompras.ResumeLayout(False)
        Me.BarraCompras.PerformLayout()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnConc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarraCompras As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents barSalir As ToolStripMenuItem
    Friend WithEvents LtTotalPagos As Label
    Friend WithEvents LtSaldo As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents LtDocActual As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents TCLIENTE As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents btnDoc As C1.Win.C1Input.C1Button
    Friend WithEvents tREFER As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtN As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents btnConc As C1.Win.C1Input.C1Button
    Friend WithEvents tMagico As TextBox
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents LtNO_FACTURA As Label
End Class
