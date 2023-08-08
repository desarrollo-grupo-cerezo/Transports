<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidarCierre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidarCierre))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.BarDesplegara = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.BarGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboDec = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lt = New System.Windows.Forms.Label()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.barMenu.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarDesplegara, Me.BarGrabar, Me.barSalir, Me.BarExcel})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(1123, 55)
        Me.barMenu.TabIndex = 11
        Me.barMenu.Text = "MenuStrip1"
        '
        'BarDesplegara
        '
        Me.BarDesplegara.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarDesplegara.ForeColor = System.Drawing.Color.White
        Me.BarDesplegara.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.BarDesplegara.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarDesplegara.Name = "BarDesplegara"
        Me.BarDesplegara.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarDesplegara.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarDesplegara.Size = New System.Drawing.Size(75, 51)
        Me.BarDesplegara.Text = "Desplegar"
        Me.BarDesplegara.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barSalir
        '
        Me.barSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barSalir.ForeColor = System.Drawing.Color.White
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.Name = "barSalir"
        Me.barSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.barSalir.Size = New System.Drawing.Size(44, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 115)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(1094, 326)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 12
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(454, 4)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(357, 44)
        Me.C1FlexGridSearchPanel1.TabIndex = 19
        Me.C1FlexGridSearchPanel1.Watermark = "Texto a buscar"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.ShowClearButton = False
        Me.F2.Calendar.ShowWeekNumbers = True
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(319, 74)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(111, 19)
        Me.F2.TabIndex = 159
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(277, 76)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 161
        Me.Label15.Text = "Fecha"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.ShowClearButton = False
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(75, 74)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(113, 19)
        Me.F1.TabIndex = 158
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.Location = New System.Drawing.Point(35, 77)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(37, 13)
        Me.Label90.TabIndex = 160
        Me.Label90.Text = "Fecha"
        '
        'BarGrabar
        '
        Me.BarGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarGrabar.ForeColor = System.Drawing.Color.White
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarGrabar.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarGrabar.Size = New System.Drawing.Size(57, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cboDec
        '
        Me.cboDec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDec.FormattingEnabled = True
        Me.cboDec.Location = New System.Drawing.Point(546, 74)
        Me.cboDec.Name = "cboDec"
        Me.cboDec.Size = New System.Drawing.Size(121, 21)
        Me.cboDec.TabIndex = 162
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(484, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 163
        Me.Label1.Text = "Decimales"
        '
        'Lt
        '
        Me.Lt.AutoSize = True
        Me.Lt.BackColor = System.Drawing.Color.Transparent
        Me.Lt.Location = New System.Drawing.Point(710, 77)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(0, 13)
        Me.Lt.TabIndex = 164
        '
        'BarExcel
        '
        Me.BarExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BarExcel.ForeColor = System.Drawing.Color.White
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.BarExcel.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.BarExcel.Size = New System.Drawing.Size(48, 51)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmValidarCierre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 465)
        Me.Controls.Add(Me.Lt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboDec)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label90)
        Me.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barMenu)
        Me.Name = "frmValidarCierre"
        Me.Text = "Validar cierre"
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents BarDesplegara As ToolStripMenuItem
    Friend WithEvents barSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label90 As Label
    Friend WithEvents BarGrabar As ToolStripMenuItem
    Friend WithEvents cboDec As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Lt As Label
    Friend WithEvents BarExcel As ToolStripMenuItem
End Class
