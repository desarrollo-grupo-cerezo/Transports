﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPolizaCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPolizaCompras))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LtNUm = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarGenPoliza = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarCarpeta = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkGenPoliza = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkCarpeta = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.TPOLIZA = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Page1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Page2 = New C1.Win.C1Command.C1DockingTabPage()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Page1.SuspendLayout()
        Me.Page2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(923, 301)
        Me.Fg.TabIndex = 11
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.F2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(12, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 101)
        Me.Panel1.TabIndex = 329
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(148, 71)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(119, 19)
        Me.RadioButton2.TabIndex = 337
        Me.RadioButton2.Text = "Gastos de oficina"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(48, 71)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(75, 19)
        Me.RadioButton1.TabIndex = 336
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Compras"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 309
        Me.Label1.Text = "Rango de fechas"
        '
        'F1
        '
        Me.F1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(50, 31)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F2
        '
        Me.F2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(179, 31)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 1
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 15)
        Me.Label2.TabIndex = 305
        Me.Label2.Text = "Del"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(156, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "al"
        '
        'LtNUm
        '
        Me.LtNUm.AutoSize = True
        Me.LtNUm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNUm.Location = New System.Drawing.Point(357, 124)
        Me.LtNUm.Name = "LtNUm"
        Me.LtNUm.Size = New System.Drawing.Size(63, 15)
        Me.LtNUm.TabIndex = 331
        Me.LtNUm.Text = "________"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(783, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 400
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(301, 38)
        Me.C1FlexGridSearchPanel1.TabIndex = 330
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'Fg2
        '
        Me.Fg2.AllowEditing = False
        Me.Fg2.AllowFiltering = True
        Me.Fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg2.ColumnInfo = resources.GetString("Fg2.ColumnInfo")
        Me.Fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg2.Location = New System.Drawing.Point(0, 0)
        Me.Fg2.Name = "Fg2"
        Me.Fg2.Rows.DefaultSize = 19
        Me.Fg2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg2.Size = New System.Drawing.Size(923, 301)
        Me.Fg2.TabIndex = 12
        Me.Fg2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarGenPoliza)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarCarpeta)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutText = ""
        Me.BarDesplegar.ShowShortcut = False
        Me.BarDesplegar.ShowTextAsToolTip = False
        Me.BarDesplegar.Text = "Desplegar"
        '
        'BarGenPoliza
        '
        Me.BarGenPoliza.Image = Global.SGT_Transport.My.Resources.Resources.XMLF
        Me.BarGenPoliza.Name = "BarGenPoliza"
        Me.BarGenPoliza.ShortcutText = ""
        Me.BarGenPoliza.Text = "Generar poliza"
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutText = ""
        Me.BarExcel.Text = "Excel"
        '
        'BarCarpeta
        '
        Me.BarCarpeta.Image = Global.SGT_Transport.My.Resources.Resources.folder3
        Me.BarCarpeta.Name = "BarCarpeta"
        Me.BarCarpeta.ShortcutText = ""
        Me.BarCarpeta.ShowShortcut = False
        Me.BarCarpeta.ShowTextAsToolTip = False
        Me.BarCarpeta.Text = "Carpeta polizas"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkGenPoliza, Me.LkExcel, Me.LkCarpeta, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1115, 45)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkDesplegar
        '
        Me.LkDesplegar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkDesplegar.Command = Me.BarDesplegar
        Me.LkDesplegar.Delimiter = True
        Me.LkDesplegar.Text = "Desplegar"
        '
        'LkGenPoliza
        '
        Me.LkGenPoliza.Command = Me.BarGenPoliza
        Me.LkGenPoliza.SortOrder = 1
        Me.LkGenPoliza.Text = "Generar poliza"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 2
        Me.LkExcel.Text = "Excel"
        '
        'LkCarpeta
        '
        Me.LkCarpeta.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkCarpeta.Command = Me.BarCarpeta
        Me.LkCarpeta.Delimiter = True
        Me.LkCarpeta.SortOrder = 3
        Me.LkCarpeta.Text = "Carpeta polizas"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 4
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'TPOLIZA
        '
        Me.TPOLIZA.Location = New System.Drawing.Point(360, 82)
        Me.TPOLIZA.Name = "TPOLIZA"
        Me.TPOLIZA.Size = New System.Drawing.Size(382, 20)
        Me.TPOLIZA.TabIndex = 333
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(357, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 332
        Me.Label4.Text = "Nombre poliza modelo"
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Page1)
        Me.Tab1.Controls.Add(Me.Page2)
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(12, 160)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(925, 326)
        Me.Tab1.TabIndex = 334
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'Page1
        '
        Me.Page1.Controls.Add(Me.Fg)
        Me.Page1.Location = New System.Drawing.Point(1, 24)
        Me.Page1.Name = "Page1"
        Me.Page1.Size = New System.Drawing.Size(923, 301)
        Me.Page1.TabIndex = 0
        Me.Page1.Text = "Documentos"
        '
        'Page2
        '
        Me.Page2.Controls.Add(Me.Fg2)
        Me.Page2.Location = New System.Drawing.Point(1, 24)
        Me.Page2.Name = "Page2"
        Me.Page2.Size = New System.Drawing.Size(923, 301)
        Me.Page2.TabIndex = 1
        Me.Page2.Text = "Almacen"
        '
        'frmPolizaCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1115, 498)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.TPOLIZA)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Controls.Add(Me.LtNUm)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPolizaCompras"
        Me.Text = "Poliza compras"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Page1.ResumeLayout(False)
        Me.Page2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LtNUm As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarCarpeta As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkCarpeta As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarGenPoliza As C1.Win.C1Command.C1Command
    Friend WithEvents LkGenPoliza As C1.Win.C1Command.C1CommandLink
    Friend WithEvents TPOLIZA As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Page1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Page2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
End Class
