<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmListaXML
    Inherits C1.Win.C1Ribbon.C1RibbonForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListaXML))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BarAceptar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BarSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBox = New System.Windows.Forms.TextBox()
        Me.LtNum = New System.Windows.Forms.Label()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoResize = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 9.0R
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndAllHeaders
        Me.Fg.ColumnInfo = "3,1,0,0,0,53,Columns:0{Style:""Font:Tahoma, 8pt;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:56;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:262;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(0, 54)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(444, 380)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 6
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarAceptar, Me.ToolStripSeparator1, Me.BarSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(444, 54)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BarAceptar
        '
        Me.BarAceptar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.BarAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarAceptar.Name = "BarAceptar"
        Me.BarAceptar.Size = New System.Drawing.Size(52, 51)
        Me.BarAceptar.Text = "Aceptar"
        Me.BarAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Size = New System.Drawing.Size(36, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(131, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Texto a buscar"
        '
        'TBox
        '
        Me.TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBox.ForeColor = System.Drawing.Color.Black
        Me.TBox.Location = New System.Drawing.Point(215, 7)
        Me.TBox.Name = "TBox"
        Me.TBox.Size = New System.Drawing.Size(190, 23)
        Me.TBox.TabIndex = 9
        '
        'LtNum
        '
        Me.LtNum.AutoSize = True
        Me.LtNum.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNum.Location = New System.Drawing.Point(218, 38)
        Me.LtNum.Name = "LtNum"
        Me.LtNum.Size = New System.Drawing.Size(78, 13)
        Me.LtNum.TabIndex = 11
        Me.LtNum.Text = "Texto a buscar"
        '
        'FrmListaXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 446)
        Me.Controls.Add(Me.LtNum)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TBox)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmListaXML"
        Me.ShowInTaskbar = False
        Me.Text = "Busqueda"
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BarAceptar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BarSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Label1 As Label
    Friend WithEvents TBox As TextBox
    Friend WithEvents LtNum As Label
End Class
