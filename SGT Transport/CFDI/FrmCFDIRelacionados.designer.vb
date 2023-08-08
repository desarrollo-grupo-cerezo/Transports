<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCFDIRelacionados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCFDIRelacionados))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.BarAceptar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.LtTipoRelacion = New System.Windows.Forms.Label()
        Me.BtnTipoRelacion = New C1.Win.C1Input.C1Button()
        Me.TCVE_TIPORELACION = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tMagico2 = New System.Windows.Forms.TextBox()
        Me.barSalir.SuspendLayout()
        CType(Me.BtnTipoRelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarAceptar, Me.BarEliminar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(766, 53)
        Me.barSalir.TabIndex = 2
        Me.barSalir.Text = "MenuStrip1"
        '
        'BarAceptar
        '
        Me.BarAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarAceptar.ForeColor = System.Drawing.Color.Black
        Me.BarAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.BarAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAceptar.Name = "BarAceptar"
        Me.BarAceptar.ShortcutKeyDisplayString = ""
        Me.BarAceptar.Size = New System.Drawing.Size(56, 49)
        Me.BarAceptar.Text = "Aceptar"
        Me.BarAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarAceptar.ToolTipText = "F3-Enlazar"
        '
        'BarEliminar
        '
        Me.BarEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarEliminar.ForeColor = System.Drawing.Color.Black
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.grideiminar
        Me.BarEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutKeyDisplayString = ""
        Me.BarEliminar.Size = New System.Drawing.Size(56, 49)
        Me.BarEliminar.Text = "Aceptar"
        Me.BarEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarEliminar.ToolTipText = "F3-Enlazar"
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 49)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LtTipoRelacion
        '
        Me.LtTipoRelacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTipoRelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTipoRelacion.Location = New System.Drawing.Point(232, 75)
        Me.LtTipoRelacion.Name = "LtTipoRelacion"
        Me.LtTipoRelacion.Size = New System.Drawing.Size(414, 20)
        Me.LtTipoRelacion.TabIndex = 369
        '
        'BtnTipoRelacion
        '
        Me.BtnTipoRelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTipoRelacion.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnTipoRelacion.Location = New System.Drawing.Point(204, 73)
        Me.BtnTipoRelacion.Name = "BtnTipoRelacion"
        Me.BtnTipoRelacion.Size = New System.Drawing.Size(24, 24)
        Me.BtnTipoRelacion.TabIndex = 2
        Me.BtnTipoRelacion.UseVisualStyleBackColor = True
        Me.BtnTipoRelacion.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_TIPORELACION
        '
        Me.TCVE_TIPORELACION.AcceptsReturn = True
        Me.TCVE_TIPORELACION.AcceptsTab = True
        Me.TCVE_TIPORELACION.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_TIPORELACION.Location = New System.Drawing.Point(114, 73)
        Me.TCVE_TIPORELACION.Name = "TCVE_TIPORELACION"
        Me.TCVE_TIPORELACION.Size = New System.Drawing.Size(88, 22)
        Me.TCVE_TIPORELACION.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(21, 76)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 16)
        Me.Label14.TabIndex = 367
        Me.Label14.Text = "Tipo relación"
        '
        'Fg
        '
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Fg.Location = New System.Drawing.Point(12, 107)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(747, 209)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 1
        '
        'tMagico2
        '
        Me.tMagico2.AcceptsReturn = True
        Me.tMagico2.AcceptsTab = True
        Me.tMagico2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tMagico2.Location = New System.Drawing.Point(619, 12)
        Me.tMagico2.Name = "tMagico2"
        Me.tMagico2.Size = New System.Drawing.Size(36, 22)
        Me.tMagico2.TabIndex = 370
        '
        'FrmCFDIRelacionados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 334)
        Me.Controls.Add(Me.LtTipoRelacion)
        Me.Controls.Add(Me.BtnTipoRelacion)
        Me.Controls.Add(Me.TCVE_TIPORELACION)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.tMagico2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCFDIRelacionados"
        Me.Text = "CFDI Relacionados"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.BtnTipoRelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents BarAceptar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents LtTipoRelacion As Label
    Friend WithEvents BtnTipoRelacion As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_TIPORELACION As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents tMagico2 As TextBox
    Friend WithEvents BarEliminar As ToolStripMenuItem
End Class
