<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDerechos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDerechos))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarDuplicar = New C1.Win.C1Command.C1Command()
        Me.BarExel = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkDuplicar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cboUsuario = New C1.Win.C1Input.C1ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GBox1 = New System.Windows.Forms.GroupBox()
        Me.BarCancelar = New System.Windows.Forms.Button()
        Me.BtnDuplicar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FgD = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBox1.SuspendLayout()
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarDuplicar)
        Me.MenuHolder.Commands.Add(Me.BarExel)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowShortcut = False
        Me.BarGrabar.ShowTextAsToolTip = False
        Me.BarGrabar.Text = "Grabar"
        '
        'BarDuplicar
        '
        Me.BarDuplicar.Image = Global.SGT_Transport.My.Resources.Resources.DUPLICAR2
        Me.BarDuplicar.Name = "BarDuplicar"
        Me.BarDuplicar.ShortcutText = ""
        Me.BarDuplicar.Text = "Duplicar derechos"
        '
        'BarExel
        '
        Me.BarExel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExel.Name = "BarExel"
        Me.BarExel.ShortcutText = ""
        Me.BarExel.Text = "Excel"
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
        Me.C1ToolBar1.ButtonWidth = 60
        Me.C1ToolBar1.CommandHolder = Nothing
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkDuplicar, Me.LkExcel, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1069, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.DefaultItem = True
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.OwnerDraw = True
        Me.LkGrabar.Text = "Grabar"
        Me.LkGrabar.ToolTipText = "Grabar"
        '
        'LkDuplicar
        '
        Me.LkDuplicar.Command = Me.BarDuplicar
        Me.LkDuplicar.SortOrder = 1
        Me.LkDuplicar.Text = "Duplicar"
        '
        'LkExcel
        '
        Me.LkExcel.Command = Me.BarExel
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
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "3,1,0,0,0,95,Columns:1{Width:200;Caption:""Modulo"";AllowDragging:False;AllowEditin" &
    "g:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:250;Caption:""Submodulos"";AllowDragging:False;AllowEditing:Fals" &
    "e;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(12, 80)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(550, 278)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'cboUsuario
        '
        Me.cboUsuario.AllowSpinLoop = False
        Me.cboUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboUsuario.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboUsuario.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUsuario.GapHeight = 0
        Me.cboUsuario.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboUsuario.ItemsDisplayMember = ""
        Me.cboUsuario.ItemsValueMember = ""
        Me.cboUsuario.Location = New System.Drawing.Point(127, 55)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(431, 19)
        Me.cboUsuario.TabIndex = 13
        Me.cboUsuario.Tag = Nothing
        Me.cboUsuario.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboUsuario.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Seleccione usuario"
        '
        'GBox1
        '
        Me.GBox1.Controls.Add(Me.BarCancelar)
        Me.GBox1.Controls.Add(Me.BtnDuplicar)
        Me.GBox1.Controls.Add(Me.Label2)
        Me.GBox1.Controls.Add(Me.FgD)
        Me.GBox1.Location = New System.Drawing.Point(582, 49)
        Me.GBox1.Name = "GBox1"
        Me.GBox1.Size = New System.Drawing.Size(454, 493)
        Me.GBox1.TabIndex = 16
        Me.GBox1.TabStop = False
        Me.GBox1.Visible = False
        '
        'BarCancelar
        '
        Me.BarCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarCancelar.Location = New System.Drawing.Point(164, 46)
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.Size = New System.Drawing.Size(124, 34)
        Me.BarCancelar.TabIndex = 19
        Me.BarCancelar.Text = "Cancelar"
        Me.BarCancelar.UseVisualStyleBackColor = True
        '
        'BtnDuplicar
        '
        Me.BtnDuplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDuplicar.Location = New System.Drawing.Point(17, 46)
        Me.BtnDuplicar.Name = "BtnDuplicar"
        Me.BtnDuplicar.Size = New System.Drawing.Size(124, 34)
        Me.BtnDuplicar.TabIndex = 18
        Me.BtnDuplicar.Text = "Duplicar"
        Me.BtnDuplicar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(433, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Seleccione usuarios a los que se les duplicarán los derechos"
        '
        'FgD
        '
        Me.FgD.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FgD.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.FgD.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.FgD.AutoClipboard = True
        Me.FgD.BackColor = System.Drawing.Color.White
        Me.FgD.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgD.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.FgD.ColumnInfo = resources.GetString("FgD.ColumnInfo")
        Me.FgD.ForeColor = System.Drawing.Color.Black
        Me.FgD.Location = New System.Drawing.Point(6, 86)
        Me.FgD.Name = "FgD"
        Me.FgD.Rows.DefaultSize = 19
        Me.FgD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.FgD.Size = New System.Drawing.Size(389, 376)
        Me.FgD.StyleInfo = resources.GetString("FgD.StyleInfo")
        Me.FgD.TabIndex = 17
        Me.FgD.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'FrmDerechos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 572)
        Me.Controls.Add(Me.GBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboUsuario)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmDerechos"
        Me.Text = "frmDerechos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBox1.ResumeLayout(False)
        Me.GBox1.PerformLayout()
        CType(Me.FgD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents cboUsuario As C1.Win.C1Input.C1ComboBox
    Friend WithEvents BarExel As C1.Win.C1Command.C1Command
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarDuplicar As C1.Win.C1Command.C1Command
    Friend WithEvents LkDuplicar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents GBox1 As GroupBox
    Friend WithEvents FgD As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnDuplicar As Button
    Friend WithEvents BarCancelar As Button
End Class
