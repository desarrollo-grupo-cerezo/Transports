<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCFDIRelFac
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCFDIRelFac))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.BarAceptar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tMagico2 = New System.Windows.Forms.TextBox()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LtCliente = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
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
        'Fg
        '
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Fg.Location = New System.Drawing.Point(7, 97)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 22
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(747, 255)
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
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(179, 66)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(414, 20)
        Me.LtNombre.TabIndex = 374
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(47, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 16)
        Me.Label14.TabIndex = 373
        Me.Label14.Text = "Cliente"
        '
        'LtCliente
        '
        Me.LtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCliente.Location = New System.Drawing.Point(102, 66)
        Me.LtCliente.Name = "LtCliente"
        Me.LtCliente.Size = New System.Drawing.Size(71, 20)
        Me.LtCliente.TabIndex = 375
        '
        'FrmCFDIRelFac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 364)
        Me.Controls.Add(Me.LtCliente)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.tMagico2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCFDIRelFac"
        Me.Text = "Documentos relacionados"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents BarAceptar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents tMagico2 As TextBox
    Friend WithEvents BarEliminar As ToolStripMenuItem
    Friend WithEvents LtNombre As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents LtCliente As Label
End Class
