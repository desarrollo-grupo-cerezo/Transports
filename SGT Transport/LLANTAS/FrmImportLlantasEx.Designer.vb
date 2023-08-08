<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportLlantasEx
    Inherits C1.Win.C1Ribbon.C1RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImportLlantasEx))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboHojas = New C1.Win.C1Input.C1ComboBox()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.TExcel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarraMenu = New System.Windows.Forms.MenuStrip()
        Me.BarCargarArchivoExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.C1XLBook1 = New C1.C1Excel.C1XLBook()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Lt2 = New System.Windows.Forms.Label()
        CType(Me.CboHojas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraMenu.SuspendLayout()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.Split2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(82, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Selecciona hoja"
        '
        'CboHojas
        '
        Me.CboHojas.AllowSpinLoop = False
        Me.CboHojas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboHojas.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboHojas.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboHojas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboHojas.GapHeight = 0
        Me.CboHojas.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboHojas.ItemsDisplayMember = ""
        Me.CboHojas.ItemsValueMember = ""
        Me.CboHojas.Location = New System.Drawing.Point(192, 58)
        Me.CboHojas.Name = "CboHojas"
        Me.CboHojas.Size = New System.Drawing.Size(200, 20)
        Me.CboHojas.TabIndex = 27
        Me.CboHojas.Tag = Nothing
        Me.CboHojas.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboHojas.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnExcel
        '
        Me.BtnExcel.Location = New System.Drawing.Point(794, 20)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(27, 23)
        Me.BtnExcel.TabIndex = 26
        Me.BtnExcel.Text = "....."
        Me.BtnExcel.UseVisualStyleBackColor = True
        '
        'TExcel
        '
        Me.TExcel.AcceptsReturn = True
        Me.TExcel.AcceptsTab = True
        Me.TExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TExcel.Location = New System.Drawing.Point(192, 22)
        Me.TExcel.Name = "TExcel"
        Me.TExcel.Size = New System.Drawing.Size(596, 22)
        Me.TExcel.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Selecciona archivo Excel"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = "1,1,0,0,0,100,Columns:"
        Me.Fg.EditOptions = CType(((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(46, 36)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowCursor = True
        Me.Fg.Size = New System.Drawing.Size(590, 205)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 29
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'BarraMenu
        '
        Me.BarraMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.BarraMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarCargarArchivoExcel, Me.BarGrabar, Me.BarSalir})
        Me.BarraMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarraMenu.Name = "BarraMenu"
        Me.BarraMenu.Size = New System.Drawing.Size(1180, 55)
        Me.BarraMenu.Stretch = False
        Me.BarraMenu.TabIndex = 30
        Me.BarraMenu.Text = "MenuStrip1"
        '
        'BarCargarArchivoExcel
        '
        Me.BarCargarArchivoExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarCargarArchivoExcel.ForeColor = System.Drawing.Color.White
        Me.BarCargarArchivoExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarCargarArchivoExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCargarArchivoExcel.Name = "BarCargarArchivoExcel"
        Me.BarCargarArchivoExcel.ShortcutKeyDisplayString = ""
        Me.BarCargarArchivoExcel.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarCargarArchivoExcel.Size = New System.Drawing.Size(71, 51)
        Me.BarCargarArchivoExcel.Text = "Desplegar"
        Me.BarCargarArchivoExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarGrabar.ForeColor = System.Drawing.Color.White
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = ""
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarGrabar.Size = New System.Drawing.Size(54, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BarSalir.ForeColor = System.Drawing.Color.White
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarSalir.Size = New System.Drawing.Size(44, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(730, 7)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 300
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(241, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 210
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(12, 72)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.Split1)
        Me.SplitM.Panels.Add(Me.Split2)
        Me.SplitM.Size = New System.Drawing.Size(987, 409)
        Me.SplitM.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.TabIndex = 211
        Me.SplitM.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'Split1
        '
        Me.Split1.Controls.Add(Me.Lt2)
        Me.Split1.Controls.Add(Me.Lt1)
        Me.Split1.Controls.Add(Me.CboHojas)
        Me.Split1.Controls.Add(Me.Label1)
        Me.Split1.Controls.Add(Me.TExcel)
        Me.Split1.Controls.Add(Me.Label2)
        Me.Split1.Controls.Add(Me.BtnExcel)
        Me.Split1.Height = 115
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(985, 115)
        Me.Split1.SizeRatio = 28.536R
        Me.Split1.TabIndex = 0
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.Transparent
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(465, 62)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(35, 16)
        Me.Lt1.TabIndex = 29
        Me.Lt1.Text = "____"
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 288
        Me.Split2.Location = New System.Drawing.Point(1, 120)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(985, 288)
        Me.Split2.TabIndex = 1
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.BackColor = System.Drawing.Color.Transparent
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(729, 62)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(35, 16)
        Me.Lt2.TabIndex = 30
        Me.Lt2.Text = "____"
        '
        'FrmImportLlantasEx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1180, 575)
        Me.Controls.Add(Me.SplitM)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.BarraMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmImportLlantasEx"
        Me.Text = "Importar llantas desde excel"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CboHojas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraMenu.ResumeLayout(False)
        Me.BarraMenu.PerformLayout()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        Me.Split2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents CboHojas As C1.Win.C1Input.C1ComboBox
    Friend WithEvents BtnExcel As Button
    Friend WithEvents TExcel As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BarraMenu As MenuStrip
    Friend WithEvents BarCargarArchivoExcel As ToolStripMenuItem
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents C1XLBook1 As C1.C1Excel.C1XLBook
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Lt1 As Label
    Friend WithEvents Lt2 As Label
End Class
