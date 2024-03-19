<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCobEfecClie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCobEfecClie))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarDesplegar = New C1.Win.C1Command.C1Command()
        Me.BarExcel = New C1.Win.C1Command.C1Command()
        Me.BarDiseñador = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkDesplegar = New C1.Win.C1Command.C1CommandLink()
        Me.LkExcel = New C1.Win.C1Command.C1CommandLink()
        Me.LkDisenador = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.SplitMP1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnClie1 = New System.Windows.Forms.Button()
        Me.TCLIENTE1 = New System.Windows.Forms.TextBox()
        Me.BtnClie2 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TCLIENTE2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SplitMP2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.SplitMP1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitMP2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarDesplegar)
        Me.MenuHolder.Commands.Add(Me.BarExcel)
        Me.MenuHolder.Commands.Add(Me.BarDiseñador)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Owner = Me
        '
        'BarDesplegar
        '
        Me.BarDesplegar.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.BarDesplegar.Name = "BarDesplegar"
        Me.BarDesplegar.ShortcutText = ""
        Me.BarDesplegar.Text = "Desplegar"
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
        'BarDiseñador
        '
        Me.BarDiseñador.Image = Global.SGT_Transport.My.Resources.Resources.diseñador
        Me.BarDiseñador.Name = "BarDiseñador"
        Me.BarDiseñador.ShortcutText = ""
        Me.BarDiseñador.Text = "Diseñador"
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
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.Text = "Imprimir"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkDesplegar, Me.LkImprimir, Me.LkExcel, Me.LkDisenador, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(809, 43)
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
        'LkExcel
        '
        Me.LkExcel.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkExcel.Command = Me.BarExcel
        Me.LkExcel.Delimiter = True
        Me.LkExcel.SortOrder = 2
        Me.LkExcel.Text = "Excel"
        '
        'LkDisenador
        '
        Me.LkDisenador.Command = Me.BarDiseñador
        Me.LkDisenador.Delimiter = True
        Me.LkDisenador.SortOrder = 3
        Me.LkDisenador.Text = "Diseñador"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 4
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'LkImprimir
        '
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.SortOrder = 1
        Me.LkImprimir.Text = "Imprimir"
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
        Me.Fg.Location = New System.Drawing.Point(14, 18)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(714, 177)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 314
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM1.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM1.Location = New System.Drawing.Point(12, 49)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.SplitMP1)
        Me.SplitM1.Panels.Add(Me.SplitMP2)
        Me.SplitM1.Size = New System.Drawing.Size(738, 338)
        Me.SplitM1.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM1.TabIndex = 315
        Me.SplitM1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'SplitMP1
        '
        Me.SplitMP1.Controls.Add(Me.Label2)
        Me.SplitMP1.Controls.Add(Me.F2)
        Me.SplitMP1.Controls.Add(Me.Label4)
        Me.SplitMP1.Controls.Add(Me.F1)
        Me.SplitMP1.Controls.Add(Me.Label1)
        Me.SplitMP1.Controls.Add(Me.BtnClie1)
        Me.SplitMP1.Controls.Add(Me.TCLIENTE1)
        Me.SplitMP1.Controls.Add(Me.BtnClie2)
        Me.SplitMP1.Controls.Add(Me.Label10)
        Me.SplitMP1.Controls.Add(Me.TCLIENTE2)
        Me.SplitMP1.Controls.Add(Me.Label13)
        Me.SplitMP1.Height = 50
        Me.SplitMP1.Location = New System.Drawing.Point(1, 1)
        Me.SplitMP1.Name = "SplitMP1"
        Me.SplitMP1.Size = New System.Drawing.Size(736, 50)
        Me.SplitMP1.SizeRatio = 15.0R
        Me.SplitMP1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(198, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "a la fecha"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(269, 27)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 20)
        Me.F2.TabIndex = 19
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "De la fecha"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(92, 27)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 20)
        Me.F1.TabIndex = 10
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(537, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Rango de clientes"
        '
        'BtnClie1
        '
        Me.BtnClie1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnClie1.FlatAppearance.BorderSize = 0
        Me.BtnClie1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClie1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie1.Image = CType(resources.GetObject("BtnClie1.Image"), System.Drawing.Image)
        Me.BtnClie1.Location = New System.Drawing.Point(545, 27)
        Me.BtnClie1.Name = "BtnClie1"
        Me.BtnClie1.Size = New System.Drawing.Size(25, 24)
        Me.BtnClie1.TabIndex = 17
        Me.BtnClie1.UseVisualStyleBackColor = True
        '
        'TCLIENTE1
        '
        Me.TCLIENTE1.AcceptsReturn = True
        Me.TCLIENTE1.AcceptsTab = True
        Me.TCLIENTE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE1.Location = New System.Drawing.Point(468, 28)
        Me.TCLIENTE1.Name = "TCLIENTE1"
        Me.TCLIENTE1.Size = New System.Drawing.Size(77, 22)
        Me.TCLIENTE1.TabIndex = 11
        '
        'BtnClie2
        '
        Me.BtnClie2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnClie2.FlatAppearance.BorderSize = 0
        Me.BtnClie2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClie2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie2.Image = CType(resources.GetObject("BtnClie2.Image"), System.Drawing.Image)
        Me.BtnClie2.Location = New System.Drawing.Point(692, 27)
        Me.BtnClie2.Name = "BtnClie2"
        Me.BtnClie2.Size = New System.Drawing.Size(25, 24)
        Me.BtnClie2.TabIndex = 18
        Me.BtnClie2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(418, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Desde"
        '
        'TCLIENTE2
        '
        Me.TCLIENTE2.AcceptsReturn = True
        Me.TCLIENTE2.AcceptsTab = True
        Me.TCLIENTE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE2.Location = New System.Drawing.Point(623, 28)
        Me.TCLIENTE2.Name = "TCLIENTE2"
        Me.TCLIENTE2.Size = New System.Drawing.Size(69, 22)
        Me.TCLIENTE2.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(578, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 16)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Hasta"
        '
        'SplitMP2
        '
        Me.SplitMP2.Controls.Add(Me.Fg)
        Me.SplitMP2.Height = 282
        Me.SplitMP2.Location = New System.Drawing.Point(1, 55)
        Me.SplitMP2.Name = "SplitMP2"
        Me.SplitMP2.Size = New System.Drawing.Size(736, 282)
        Me.SplitMP2.SizeRatio = 90.0R
        Me.SplitMP2.TabIndex = 1
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(550, 3)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(216, 36)
        Me.C1FlexGridSearchPanel1.TabIndex = 317
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'FrmCobEfecClie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 450)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.SplitM1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCobEfecClie"
        Me.Text = "FrmCobEfecClie"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.SplitMP1.ResumeLayout(False)
        Me.SplitMP1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitMP2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarDesplegar As C1.Win.C1Command.C1Command
    Friend WithEvents BarExcel As C1.Win.C1Command.C1Command
    Friend WithEvents BarDiseñador As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkDesplegar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkExcel As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkDisenador As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents SplitMP1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents SplitMP2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnClie1 As Button
    Friend WithEvents TCLIENTE1 As TextBox
    Friend WithEvents BtnClie2 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TCLIENTE2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
End Class
