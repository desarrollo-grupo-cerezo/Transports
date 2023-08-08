<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKit))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.tPrecio = New C1.Win.C1Input.C1NumericEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtPrecioMin = New System.Windows.Forms.Label()
        Me.LrPrecioReal = New System.Windows.Forms.Label()
        Me.LtCosto = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.btnArt = New C1.Win.C1Input.C1Button()
        Me.LtTotPar = New System.Windows.Forms.Label()
        Me.LtTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnArt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.barEliminar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(778, 55)
        Me.barSalir.TabIndex = 2
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.White
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = ""
        Me.barGrabar.Size = New System.Drawing.Size(57, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barGrabar.ToolTipText = "F2-Nuevo"
        '
        'barEliminar
        '
        Me.barEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barEliminar.ForeColor = System.Drawing.Color.White
        Me.barEliminar.Image = Global.SGT_Transport.My.Resources.Resources.delete
        Me.barEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEliminar.Name = "barEliminar"
        Me.barEliminar.ShortcutKeyDisplayString = "F4 - Eliminar"
        Me.barEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barEliminar.Size = New System.Drawing.Size(63, 51)
        Me.barEliminar.Text = "Eliminar"
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuSalir.ForeColor = System.Drawing.Color.White
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeyDisplayString = "F5 - Salir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(0, 152)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.Size = New System.Drawing.Size(766, 225)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 1
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'tPrecio
        '
        Me.tPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tPrecio.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tPrecio.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.tPrecio.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.tPrecio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPrecio.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tPrecio.Location = New System.Drawing.Point(73, 79)
        Me.tPrecio.Name = "tPrecio"
        Me.tPrecio.Size = New System.Drawing.Size(159, 20)
        Me.tPrecio.TabIndex = 0
        Me.tPrecio.Tag = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Precio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Costo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(331, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Precio Min. Real"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(354, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Precio Real"
        '
        'LtPrecioMin
        '
        Me.LtPrecioMin.BackColor = System.Drawing.Color.SteelBlue
        Me.LtPrecioMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPrecioMin.ForeColor = System.Drawing.Color.White
        Me.LtPrecioMin.Location = New System.Drawing.Point(420, 112)
        Me.LtPrecioMin.Name = "LtPrecioMin"
        Me.LtPrecioMin.Size = New System.Drawing.Size(101, 18)
        Me.LtPrecioMin.TabIndex = 17
        Me.LtPrecioMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LrPrecioReal
        '
        Me.LrPrecioReal.BackColor = System.Drawing.Color.SteelBlue
        Me.LrPrecioReal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LrPrecioReal.ForeColor = System.Drawing.Color.White
        Me.LrPrecioReal.Location = New System.Drawing.Point(420, 84)
        Me.LrPrecioReal.Name = "LrPrecioReal"
        Me.LrPrecioReal.Size = New System.Drawing.Size(101, 18)
        Me.LrPrecioReal.TabIndex = 16
        Me.LrPrecioReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtCosto
        '
        Me.LtCosto.BackColor = System.Drawing.Color.SteelBlue
        Me.LtCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCosto.ForeColor = System.Drawing.Color.White
        Me.LtCosto.Location = New System.Drawing.Point(73, 112)
        Me.LtCosto.Name = "LtCosto"
        Me.LtCosto.Size = New System.Drawing.Size(92, 18)
        Me.LtCosto.TabIndex = 18
        Me.LtCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'btnArt
        '
        Me.btnArt.AutoSize = True
        Me.btnArt.Image = Global.SGT_Transport.My.Resources.Resources.LUPA4
        Me.btnArt.Location = New System.Drawing.Point(742, 105)
        Me.btnArt.Name = "btnArt"
        Me.btnArt.Size = New System.Drawing.Size(24, 25)
        Me.btnArt.TabIndex = 35
        Me.btnArt.UseVisualStyleBackColor = True
        Me.btnArt.Visible = False
        '
        'LtTotPar
        '
        Me.LtTotPar.BackColor = System.Drawing.Color.SteelBlue
        Me.LtTotPar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotPar.ForeColor = System.Drawing.Color.White
        Me.LtTotPar.Location = New System.Drawing.Point(154, 408)
        Me.LtTotPar.Name = "LtTotPar"
        Me.LtTotPar.Size = New System.Drawing.Size(92, 18)
        Me.LtTotPar.TabIndex = 39
        Me.LtTotPar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtTotal
        '
        Me.LtTotal.BackColor = System.Drawing.Color.SteelBlue
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.ForeColor = System.Drawing.Color.White
        Me.LtTotal.Location = New System.Drawing.Point(501, 408)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(101, 18)
        Me.LtTotal.TabIndex = 38
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(464, 411)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Total"
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Location = New System.Drawing.Point(77, 411)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(71, 13)
        Me.Lt1.TabIndex = 36
        Me.Lt1.Text = "Total partidas"
        '
        'frmKit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 457)
        Me.Controls.Add(Me.LtTotPar)
        Me.Controls.Add(Me.LtTotal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.btnArt)
        Me.Controls.Add(Me.LtCosto)
        Me.Controls.Add(Me.LtPrecioMin)
        Me.Controls.Add(Me.LrPrecioReal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tPrecio)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Armando del Kit"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnArt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents tPrecio As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LtPrecioMin As Label
    Friend WithEvents LrPrecioReal As Label
    Friend WithEvents LtCosto As Label
    Friend WithEvents btnArt As C1.Win.C1Input.C1Button
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents LtTotPar As Label
    Friend WithEvents LtTotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Lt1 As Label
End Class
