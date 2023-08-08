<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaldosClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaldosClientes))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.chConSaldo = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.C1Input.C1DateEdit()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.L3 = New System.Windows.Forms.Label()
        Me.btnSaldos = New System.Windows.Forms.Button()
        Me.TCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.BtnCliente = New C1.Win.C1Input.C1Button()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.Shortcut = System.Windows.Forms.Shortcut.F2
        Me.BarDesplegar.ShortcutText = "F2"
        Me.BarDesplegar.Text = "Desplegar"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarImprimir.ShortcutText = "F3"
        Me.BarImprimir.Text = "Imprimir"
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
        Me.BarSalir.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.BarSalir.ShortcutText = "F5"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkImprimir, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1159, 43)
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
        Me.LkDesplegar.ToolTipText = "Desplegar"
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.SortOrder = 1
        Me.LkImprimir.Text = "Imprimir"
        Me.LkImprimir.ToolTipText = "Imprimir"
        '
        'LkExcel
        '
        Me.LkExcel.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 2
        Me.LkExcel.Text = "Excel"
        Me.LkExcel.ToolTipText = "Excel"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 3
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'chConSaldo
        '
        Me.chConSaldo.AutoSize = True
        Me.chConSaldo.Location = New System.Drawing.Point(610, 67)
        Me.chConSaldo.Name = "chConSaldo"
        Me.chConSaldo.Size = New System.Drawing.Size(180, 17)
        Me.chConSaldo.TabIndex = 31
        Me.chConSaldo.Text = "Mostrar movimientos con saldo 0"
        Me.chConSaldo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Fecha"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.F1.Calendar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.System
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.F1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.F1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.GapHeight = 0
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(73, 72)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(127, 19)
        Me.F1.TabIndex = 29
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 9.0R
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Me.Fg, Me.C1FlexGridSearchPanel1)
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(12, 104)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.Fg.Size = New System.Drawing.Size(950, 260)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 28
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(815, 49)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchDelay = 300
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(332, 49)
        Me.C1FlexGridSearchPanel1.TabIndex = 32
        Me.C1FlexGridSearchPanel1.Watermark = "Capture texto a buscar"
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.Location = New System.Drawing.Point(1018, 69)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(0, 15)
        Me.L3.TabIndex = 33
        '
        'btnSaldos
        '
        Me.btnSaldos.Location = New System.Drawing.Point(968, 117)
        Me.btnSaldos.Name = "btnSaldos"
        Me.btnSaldos.Size = New System.Drawing.Size(95, 30)
        Me.btnSaldos.TabIndex = 35
        Me.btnSaldos.Text = "Saldos"
        Me.btnSaldos.UseVisualStyleBackColor = True
        '
        'TCLIENTE
        '
        Me.TCLIENTE.AcceptsReturn = True
        Me.TCLIENTE.AcceptsTab = True
        Me.TCLIENTE.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE.Location = New System.Drawing.Point(281, 66)
        Me.TCLIENTE.MaxLength = 10
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(56, 24)
        Me.TCLIENTE.TabIndex = 106
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(237, 69)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 16)
        Me.Label27.TabIndex = 107
        Me.Label27.Text = "Clave"
        '
        'BtnCliente
        '
        Me.BtnCliente.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnCliente.Location = New System.Drawing.Point(343, 66)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(23, 24)
        Me.BtnCliente.TabIndex = 195
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'frmSaldosClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1159, 510)
        Me.Controls.Add(Me.BtnCliente)
        Me.Controls.Add(Me.TCLIENTE)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.btnSaldos)
        Me.Controls.Add(Me.L3)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.chConSaldo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSaldosClientes"
        Me.Text = "frmSaldosClientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Public WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents chConSaldo As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents F1 As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents L3 As System.Windows.Forms.Label
    Friend WithEvents btnSaldos As System.Windows.Forms.Button
    Friend WithEvents TCLIENTE As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents BtnCliente As C1.Win.C1Input.C1Button
End Class
