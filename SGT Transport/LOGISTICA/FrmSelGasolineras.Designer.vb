<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelGasolineras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelGasolineras))
        Me.C1List1 = New C1.Win.C1List.C1List()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.barAceptar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1List1
        '
        Me.C1List1.AllowColMove = False
        Me.C1List1.AllowRowSizing = C1.Win.C1List.RowSizingEnum.None
        Me.C1List1.AlternatingRows = True
        Me.C1List1.BackColor = System.Drawing.SystemColors.Control
        Me.C1List1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1List1.Caption = "Seleccione las gasolineras"
        Me.C1List1.CaptionHeight = 25
        Me.C1List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1List1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1List1.DeadAreaBackColor = System.Drawing.SystemColors.Control
        Me.C1List1.ExtendRightColumn = True
        Me.C1List1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1List1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.C1List1.Images.Add(CType(resources.GetObject("C1List1.Images"), System.Drawing.Image))
        Me.C1List1.ItemHeight = 16
        Me.C1List1.Location = New System.Drawing.Point(12, 68)
        Me.C1List1.MatchEntryTimeout = CType(2000, Long)
        Me.C1List1.Name = "C1List1"
        Me.C1List1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1List1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1List1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1List1.RowDivider.Color = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.C1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.[Single]
        Me.C1List1.RowSubDividerColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.C1List1.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox
        Me.C1List1.Size = New System.Drawing.Size(410, 268)
        Me.C1List1.TabIndex = 355
        Me.C1List1.PropBag = resources.GetString("C1List1.PropBag")
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.BarraMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barAceptar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(439, 55)
        Me.BarraMenu.TabIndex = 356
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'barAceptar
        '
        Me.barAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barAceptar.ForeColor = System.Drawing.Color.Black
        Me.barAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.barAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barAceptar.Name = "barAceptar"
        Me.barAceptar.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barAceptar.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barAceptar.Size = New System.Drawing.Size(60, 51)
        Me.barAceptar.Text = "Aceptar"
        Me.barAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barAceptar.ToolTipText = "F2-Nuevo"
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
        'FrmSelGasolineras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 350)
        Me.Controls.Add(Me.BarraMenu)
        Me.Controls.Add(Me.C1List1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelGasolineras"
        Me.Text = "Seleccione gasolineras"
        CType(Me.C1List1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1List1 As C1.Win.C1List.C1List
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents barAceptar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
End Class
