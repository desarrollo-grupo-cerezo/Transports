<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFacturaGlobal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturaGlobal))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarTimbrar = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkTimbrar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.LtDel = New System.Windows.Forms.Label()
        Me.LtSerieFiltro = New System.Windows.Forms.Label()
        Me.LtFecha2 = New System.Windows.Forms.Label()
        Me.LtFecha1 = New System.Windows.Forms.Label()
        Me.LtPeriodicidad = New System.Windows.Forms.Label()
        Me.LtSerieFacturaGlobal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitP1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.LtFiltrarCteMostr = New System.Windows.Forms.Label()
        Me.SplitP2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Lt1 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Split1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split1.SuspendLayout()
        Me.SplitP1.SuspendLayout()
        Me.SplitP2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarTimbrar)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutText = ""
        Me.BarDesplegar.Text = "Desplegar"
        Me.BarDesplegar.Visible = False
        '
        'BarTimbrar
        '
        Me.BarTimbrar.Image = Global.SGT_Transport.My.Resources.Resources.cfdi20_e
        Me.BarTimbrar.Name = "BarTimbrar"
        Me.BarTimbrar.ShortcutText = ""
        Me.BarTimbrar.ShowShortcut = False
        Me.BarTimbrar.ShowTextAsToolTip = False
        Me.BarTimbrar.Text = "Timbrar"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.ShowShortcut = False
        Me.BarExcel.ShowTextAsToolTip = False
        Me.BarExcel.Text = "Excel"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.ShortcutText = ""
        Me.BarSalir.ShowShortcut = False
        Me.BarSalir.ShowTextAsToolTip = False
        Me.BarSalir.Text = "Salir"
        '
        'C1ToolBar1
        '
        Me.C1ToolBar1.AccessibleName = "Tool Bar"
        Me.C1ToolBar1.AutoSize = False
        Me.C1ToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.C1ToolBar1.BackImageInImageBar = True
        Me.C1ToolBar1.Border.Style = C1.Win.C1Command.BorderStyleEnum.Ridge
        Me.C1ToolBar1.ButtonLayoutHorz = C1.Win.C1Command.ButtonLayoutEnum.TextBelow
        Me.C1ToolBar1.ButtonLookHorz = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonLookVert = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.C1ToolBar1.ButtonWidth = 90
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkTimbrar, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(943, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkDesplegar
        '
        Me.LkDesplegar.Command = Me.BarDesplegar
        Me.LkDesplegar.Delimiter = True
        Me.LkDesplegar.Text = "Desplegar"
        '
        'LkTimbrar
        '
        Me.LkTimbrar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkTimbrar.Command = Me.BarTimbrar
        Me.LkTimbrar.Delimiter = True
        Me.LkTimbrar.SortOrder = 1
        Me.LkTimbrar.Text = "Timbrar"
        '
        'LkExcel
        '
        Me.LkExcel.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 2
        Me.LkExcel.Text = "Excel"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 3
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(20, 18)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(554, 252)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 314
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(54, 51)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(76, 15)
        Me.LtDel.TabIndex = 359
        Me.LtDel.Text = "Fecha inicial"
        '
        'LtSerieFiltro
        '
        Me.LtSerieFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSerieFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSerieFiltro.Location = New System.Drawing.Point(535, 48)
        Me.LtSerieFiltro.Name = "LtSerieFiltro"
        Me.LtSerieFiltro.Size = New System.Drawing.Size(50, 22)
        Me.LtSerieFiltro.TabIndex = 405
        Me.LtSerieFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LtFecha2
        '
        Me.LtFecha2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFecha2.Location = New System.Drawing.Point(342, 48)
        Me.LtFecha2.Name = "LtFecha2"
        Me.LtFecha2.Size = New System.Drawing.Size(75, 22)
        Me.LtFecha2.TabIndex = 403
        Me.LtFecha2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LtFecha1
        '
        Me.LtFecha1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFecha1.Location = New System.Drawing.Point(136, 48)
        Me.LtFecha1.Name = "LtFecha1"
        Me.LtFecha1.Size = New System.Drawing.Size(75, 22)
        Me.LtFecha1.TabIndex = 402
        Me.LtFecha1.Text = "12/12/2023"
        Me.LtFecha1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LtPeriodicidad
        '
        Me.LtPeriodicidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtPeriodicidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtPeriodicidad.Location = New System.Drawing.Point(342, 21)
        Me.LtPeriodicidad.Name = "LtPeriodicidad"
        Me.LtPeriodicidad.Size = New System.Drawing.Size(104, 22)
        Me.LtPeriodicidad.TabIndex = 407
        Me.LtPeriodicidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LtSerieFacturaGlobal
        '
        Me.LtSerieFacturaGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSerieFacturaGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSerieFacturaGlobal.Location = New System.Drawing.Point(136, 21)
        Me.LtSerieFacturaGlobal.Name = "LtSerieFacturaGlobal"
        Me.LtSerieFacturaGlobal.Size = New System.Drawing.Size(50, 22)
        Me.LtSerieFacturaGlobal.TabIndex = 406
        Me.LtSerieFacturaGlobal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 15)
        Me.Label3.TabIndex = 408
        Me.Label3.Text = "Serie factura global"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(260, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 409
        Me.Label4.Text = "Periodicidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(467, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 15)
        Me.Label5.TabIndex = 410
        Me.Label5.Text = "Serie filtro"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(269, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 411
        Me.Label6.Text = "Fecha final"
        '
        'Split1
        '
        Me.Split1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.Split1.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Split1.BorderWidth = 1
        Me.Split1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Split1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Split1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Split1.Location = New System.Drawing.Point(24, 49)
        Me.Split1.Name = "Split1"
        Me.Split1.Panels.Add(Me.SplitP1)
        Me.Split1.Panels.Add(Me.SplitP2)
        Me.Split1.Size = New System.Drawing.Size(862, 389)
        Me.Split1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Split1.TabIndex = 412
        Me.Split1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'SplitP1
        '
        Me.SplitP1.Controls.Add(Me.Lt1)
        Me.SplitP1.Controls.Add(Me.LtFiltrarCteMostr)
        Me.SplitP1.Controls.Add(Me.LtFecha1)
        Me.SplitP1.Controls.Add(Me.Label6)
        Me.SplitP1.Controls.Add(Me.LtDel)
        Me.SplitP1.Controls.Add(Me.Label5)
        Me.SplitP1.Controls.Add(Me.LtFecha2)
        Me.SplitP1.Controls.Add(Me.Label4)
        Me.SplitP1.Controls.Add(Me.LtSerieFiltro)
        Me.SplitP1.Controls.Add(Me.Label3)
        Me.SplitP1.Controls.Add(Me.LtSerieFacturaGlobal)
        Me.SplitP1.Controls.Add(Me.LtPeriodicidad)
        Me.SplitP1.Height = 110
        Me.SplitP1.Location = New System.Drawing.Point(1, 1)
        Me.SplitP1.Name = "SplitP1"
        Me.SplitP1.Size = New System.Drawing.Size(860, 110)
        Me.SplitP1.SizeRatio = 28.721R
        Me.SplitP1.TabIndex = 0
        '
        'LtFiltrarCteMostr
        '
        Me.LtFiltrarCteMostr.AutoSize = True
        Me.LtFiltrarCteMostr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFiltrarCteMostr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFiltrarCteMostr.Location = New System.Drawing.Point(611, 48)
        Me.LtFiltrarCteMostr.Name = "LtFiltrarCteMostr"
        Me.LtFiltrarCteMostr.Size = New System.Drawing.Size(44, 18)
        Me.LtFiltrarCteMostr.TabIndex = 412
        Me.LtFiltrarCteMostr.Text = "_____"
        Me.LtFiltrarCteMostr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitP2
        '
        Me.SplitP2.Controls.Add(Me.Fg)
        Me.SplitP2.Height = 273
        Me.SplitP2.Location = New System.Drawing.Point(1, 115)
        Me.SplitP2.Name = "SplitP2"
        Me.SplitP2.Size = New System.Drawing.Size(860, 273)
        Me.SplitP2.TabIndex = 1
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(467, 80)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(28, 15)
        Me.Lt1.TabIndex = 413
        Me.Lt1.Text = "___"
        '
        'FrmFacturaGlobal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 450)
        Me.Controls.Add(Me.Split1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmFacturaGlobal"
        Me.Text = "Factura global"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Split1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split1.ResumeLayout(False)
        Me.SplitP1.ResumeLayout(False)
        Me.SplitP1.PerformLayout()
        Me.SplitP2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Friend WithEvents BarTimbrar As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkTimbrar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtDel As Label
    Friend WithEvents LtSerieFiltro As Label
    Friend WithEvents LtFecha2 As Label
    Friend WithEvents LtFecha1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LtPeriodicidad As Label
    Friend WithEvents LtSerieFacturaGlobal As Label
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitP1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitP2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents LtFiltrarCteMostr As Label
    Friend WithEvents Lt1 As Label
End Class
