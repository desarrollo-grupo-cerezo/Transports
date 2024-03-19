<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAntSalProv
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAntSalProv))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarDesplegar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitMP1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.chDetallado = New C1.Win.C1Input.C1CheckBox()
        Me.TClasific = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.SplitMP2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraMenu.SuspendLayout()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.SplitMP1.SuspendLayout()
        CType(Me.chDetallado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitMP2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(17, 15)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(745, 176)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 312
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(564, 4)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(252, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 313
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarDesplegar, Me.BarExcel, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(997, 53)
        Me.BarraMenu.TabIndex = 314
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarDesplegar.ForeColor = System.Drawing.Color.Black
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.desplegar
        Me.BarDesplegar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutKeyDisplayString = ""
        Me.BarDesplegar.ShowShortcutKeys = False
        Me.BarDesplegar.Size = New System.Drawing.Size(71, 49)
        Me.BarDesplegar.Text = "Desplegar"
        Me.BarDesplegar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarDesplegar.ToolTipText = "F2-Nuevo"
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarExcel.ForeColor = System.Drawing.Color.Black
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.BarExcel.Size = New System.Drawing.Size(44, 49)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 49)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SplitM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitM1.Location = New System.Drawing.Point(12, 73)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.SplitMP1)
        Me.SplitM1.Panels.Add(Me.SplitMP2)
        Me.SplitM1.Size = New System.Drawing.Size(954, 364)
        Me.SplitM1.TabIndex = 315
        '
        'SplitMP1
        '
        Me.SplitMP1.Controls.Add(Me.chDetallado)
        Me.SplitMP1.Controls.Add(Me.TClasific)
        Me.SplitMP1.Controls.Add(Me.Label45)
        Me.SplitMP1.Controls.Add(Me.Label4)
        Me.SplitMP1.Controls.Add(Me.F1)
        Me.SplitMP1.Height = 54
        Me.SplitMP1.Location = New System.Drawing.Point(1, 1)
        Me.SplitMP1.Name = "SplitMP1"
        Me.SplitMP1.Size = New System.Drawing.Size(952, 54)
        Me.SplitMP1.SizeRatio = 15.0R
        Me.SplitMP1.TabIndex = 0
        '
        'chDetallado
        '
        Me.chDetallado.BackColor = System.Drawing.Color.Transparent
        Me.chDetallado.BorderColor = System.Drawing.Color.Transparent
        Me.chDetallado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chDetallado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chDetallado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chDetallado.ForeColor = System.Drawing.Color.Black
        Me.chDetallado.Location = New System.Drawing.Point(589, 21)
        Me.chDetallado.Name = "chDetallado"
        Me.chDetallado.Padding = New System.Windows.Forms.Padding(1)
        Me.chDetallado.Size = New System.Drawing.Size(127, 24)
        Me.chDetallado.TabIndex = 312
        Me.chDetallado.Text = "Detallado"
        Me.chDetallado.UseVisualStyleBackColor = True
        Me.chDetallado.Value = Nothing
        Me.chDetallado.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TClasific
        '
        Me.TClasific.AcceptsReturn = True
        Me.TClasific.AcceptsTab = True
        Me.TClasific.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TClasific.Location = New System.Drawing.Point(406, 24)
        Me.TClasific.Name = "TClasific"
        Me.TClasific.Size = New System.Drawing.Size(60, 21)
        Me.TClasific.TabIndex = 237
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(326, 27)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(76, 15)
        Me.Label45.TabIndex = 238
        Me.Label45.Text = "Clasificacion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha de referencia"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(172, 25)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 6
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitMP2
        '
        Me.SplitMP2.Controls.Add(Me.Fg)
        Me.SplitMP2.Height = 304
        Me.SplitMP2.Location = New System.Drawing.Point(1, 59)
        Me.SplitMP2.Name = "SplitMP2"
        Me.SplitMP2.Size = New System.Drawing.Size(952, 304)
        Me.SplitMP2.SizeRatio = 85.0R
        Me.SplitMP2.TabIndex = 1
        '
        'FrmAntSalProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 479)
        Me.Controls.Add(Me.SplitM1)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAntSalProv"
        Me.Text = "Antiguedad de saldos proveedores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.SplitMP1.ResumeLayout(False)
        Me.SplitMP1.PerformLayout()
        CType(Me.chDetallado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitMP2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarDesplegar As ToolStripMenuItem
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitMP1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitMP2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents TClasific As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents chDetallado As C1.Win.C1Input.C1CheckBox
End Class
