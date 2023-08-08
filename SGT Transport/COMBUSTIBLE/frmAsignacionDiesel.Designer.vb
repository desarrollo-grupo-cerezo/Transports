<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAsignacionDiesel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignacionDiesel))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarNuevo = New C1.Win.C1Command.C1Command()
        Me.BarEdit = New C1.Win.C1Command.C1Command()
        Me.BarEliminar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkNuevo = New C1.Win.C1Command.C1CommandLink()
        Me.LkEdit = New C1.Win.C1Command.C1CommandLink()
        Me.LkEliminar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tLTS_STOCK = New C1.Win.C1Input.C1TextBox()
        Me.LtLTS_STOCK = New System.Windows.Forms.Label()
        Me.tCAPACIDAD = New C1.Win.C1Input.C1TextBox()
        Me.SplitMain = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tLTS_STOCK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tCAPACIDAD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitMain.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.Split2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarNuevo)
        Me.MenuHolder.Commands.Add(Me.BarEdit)
        Me.MenuHolder.Commands.Add(Me.BarEliminar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarNuevo
        '
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutText = ""
        Me.BarNuevo.ShowShortcut = False
        Me.BarNuevo.ShowTextAsToolTip = False
        Me.BarNuevo.Text = "Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutText = ""
        Me.BarEdit.Text = "Edit"
        '
        'BarEliminar
        '
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BarEliminar.Name = "BarEliminar"
        Me.BarEliminar.ShortcutText = ""
        Me.BarEliminar.ShowShortcut = False
        Me.BarEliminar.ShowTextAsToolTip = False
        Me.BarEliminar.Text = "Cancelar"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkNuevo, Me.LkEdit, Me.LkEliminar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1094, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkNuevo
        '
        Me.LkNuevo.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkNuevo.Command = Me.BarNuevo
        Me.LkNuevo.Delimiter = True
        Me.LkNuevo.Text = "Nuevo"
        Me.LkNuevo.ToolTipText = ""
        '
        'LkEdit
        '
        Me.LkEdit.Command = Me.BarEdit
        Me.LkEdit.Delimiter = True
        Me.LkEdit.SortOrder = 1
        Me.LkEdit.Text = "Edit"
        Me.LkEdit.ToolTipText = ""
        '
        'LkEliminar
        '
        Me.LkEliminar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkEliminar.Command = Me.BarEliminar
        Me.LkEliminar.Delimiter = True
        Me.LkEliminar.SortOrder = 2
        Me.LkEliminar.Text = "Cancelar"
        Me.LkEliminar.ToolTipText = "Cancelar"
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
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.Size = New System.Drawing.Size(1090, 386)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 12
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(73, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Capacidad"
        '
        'tLTS_STOCK
        '
        Me.tLTS_STOCK.AcceptsReturn = True
        Me.tLTS_STOCK.AcceptsTab = True
        Me.tLTS_STOCK.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tLTS_STOCK.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tLTS_STOCK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tLTS_STOCK.CustomFormat = "###,###,##0.00"
        Me.tLTS_STOCK.DataType = GetType(Decimal)
        Me.tLTS_STOCK.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tLTS_STOCK.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLTS_STOCK.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tLTS_STOCK.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLTS_STOCK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLTS_STOCK.Location = New System.Drawing.Point(389, 17)
        Me.tLTS_STOCK.Name = "tLTS_STOCK"
        Me.tLTS_STOCK.Size = New System.Drawing.Size(100, 19)
        Me.tLTS_STOCK.TabIndex = 541
        Me.tLTS_STOCK.Tag = Nothing
        Me.tLTS_STOCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tLTS_STOCK.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtLTS_STOCK
        '
        Me.LtLTS_STOCK.AutoSize = True
        Me.LtLTS_STOCK.BackColor = System.Drawing.Color.Transparent
        Me.LtLTS_STOCK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtLTS_STOCK.ForeColor = System.Drawing.Color.Black
        Me.LtLTS_STOCK.Location = New System.Drawing.Point(329, 19)
        Me.LtLTS_STOCK.Name = "LtLTS_STOCK"
        Me.LtLTS_STOCK.Size = New System.Drawing.Size(54, 15)
        Me.LtLTS_STOCK.TabIndex = 542
        Me.LtLTS_STOCK.Text = "Lts stock"
        '
        'tCAPACIDAD
        '
        Me.tCAPACIDAD.AcceptsReturn = True
        Me.tCAPACIDAD.AcceptsTab = True
        Me.tCAPACIDAD.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tCAPACIDAD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tCAPACIDAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCAPACIDAD.CustomFormat = "###,###,##0.00"
        Me.tCAPACIDAD.DataType = GetType(Decimal)
        Me.tCAPACIDAD.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tCAPACIDAD.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tCAPACIDAD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.tCAPACIDAD.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tCAPACIDAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCAPACIDAD.Location = New System.Drawing.Point(144, 17)
        Me.tCAPACIDAD.Name = "tCAPACIDAD"
        Me.tCAPACIDAD.Size = New System.Drawing.Size(100, 19)
        Me.tCAPACIDAD.TabIndex = 540
        Me.tCAPACIDAD.Tag = Nothing
        Me.tCAPACIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tCAPACIDAD.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'SplitMain
        '
        Me.SplitMain.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitMain.BorderWidth = 2
        Me.SplitMain.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitMain.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitMain.Location = New System.Drawing.Point(0, 43)
        Me.SplitMain.Name = "SplitMain"
        Me.SplitMain.Panels.Add(Me.Split1)
        Me.SplitMain.Panels.Add(Me.Split2)
        Me.SplitMain.Panels.Add(Me.Split3)
        Me.SplitMain.Size = New System.Drawing.Size(1094, 512)
        Me.SplitMain.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitMain.SplitterWidth = 1
        Me.SplitMain.TabIndex = 544
        Me.SplitMain.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'Split1
        '
        Me.Split1.AutoScroll = True
        Me.Split1.Controls.Add(Me.tLTS_STOCK)
        Me.Split1.Controls.Add(Me.Label1)
        Me.Split1.Controls.Add(Me.LtLTS_STOCK)
        Me.Split1.Controls.Add(Me.tCAPACIDAD)
        Me.Split1.Height = 57
        Me.Split1.Location = New System.Drawing.Point(2, 2)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1090, 57)
        Me.Split1.SizeRatio = 11.25R
        Me.Split1.TabIndex = 0
        '
        'Split2
        '
        Me.Split2.AutoScroll = True
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 386
        Me.Split2.Location = New System.Drawing.Point(2, 60)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1090, 386)
        Me.Split2.SizeRatio = 85.969R
        Me.Split2.TabIndex = 1
        '
        'Split3
        '
        Me.Split3.AutoScroll = True
        Me.Split3.Height = 63
        Me.Split3.Location = New System.Drawing.Point(2, 447)
        Me.Split3.Name = "Split3"
        Me.Split3.Size = New System.Drawing.Size(1090, 63)
        Me.Split3.TabIndex = 2
        '
        'frmAsignacionDiesel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 555)
        Me.Controls.Add(Me.SplitMain)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAsignacionDiesel"
        Me.Text = "Asignacion diesel"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tLTS_STOCK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tCAPACIDAD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitMain.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        Me.Split2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarNuevo As C1.Win.C1Command.C1Command
    Friend WithEvents BarEdit As C1.Win.C1Command.C1Command
    Friend WithEvents BarEliminar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkNuevo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEdit As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEliminar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents tLTS_STOCK As C1.Win.C1Input.C1TextBox
    Friend WithEvents LtLTS_STOCK As Label
    Friend WithEvents tCAPACIDAD As C1.Win.C1Input.C1TextBox
    Friend WithEvents SplitMain As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split3 As C1.Win.C1SplitContainer.C1SplitterPanel
End Class
