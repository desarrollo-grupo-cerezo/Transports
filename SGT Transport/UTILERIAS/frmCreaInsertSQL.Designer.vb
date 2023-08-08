<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreaInsertSQL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreaInsertSQL))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.tBox = New C1.Win.C1Input.C1TextBox()
        Me.FgT = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cboEmpresa1 = New System.Windows.Forms.ComboBox()
        Me.cboEmpresa2 = New System.Windows.Forms.ComboBox()
        Me.barCodeInicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.barCreateCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.barCreateCodeGC = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarRenombrarTablas = New System.Windows.Forms.ToolStripMenuItem()
        Me.barCreateBaseGPS = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        CType(Me.tBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FgT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(351, 69)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(517, 443)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 2
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barCodeInicio, Me.barCreateCode, Me.barCreateCodeGC, Me.BarRenombrarTablas, Me.barCreateBaseGPS, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1184, 55)
        Me.barSalir.TabIndex = 3
        Me.barSalir.Text = "MenuStrip1"
        '
        'tBox
        '
        Me.tBox.AutoSize = False
        Me.tBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tBox.Location = New System.Drawing.Point(863, 67)
        Me.tBox.Multiline = True
        Me.tBox.Name = "tBox"
        Me.tBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tBox.Size = New System.Drawing.Size(308, 443)
        Me.tBox.TabIndex = 5
        Me.tBox.Tag = Nothing
        Me.tBox.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tBox.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FgT
        '
        Me.FgT.AllowEditing = False
        Me.FgT.AllowFiltering = True
        Me.FgT.BackColor = System.Drawing.Color.White
        Me.FgT.ColumnInfo = "2,1,0,0,0,95,Columns:1{Width:269;Caption:""TABLA"";AllowDragging:False;AllowEditing" &
    ":False;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.FgT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FgT.ForeColor = System.Drawing.Color.Black
        Me.FgT.Location = New System.Drawing.Point(12, 70)
        Me.FgT.Name = "FgT"
        Me.FgT.Rows.DefaultSize = 19
        Me.FgT.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgT.Size = New System.Drawing.Size(333, 443)
        Me.FgT.StyleInfo = resources.GetString("FgT.StyleInfo")
        Me.FgT.TabIndex = 6
        Me.FgT.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'cboEmpresa1
        '
        Me.cboEmpresa1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa1.FormattingEnabled = True
        Me.cboEmpresa1.Location = New System.Drawing.Point(526, 12)
        Me.cboEmpresa1.Name = "cboEmpresa1"
        Me.cboEmpresa1.Size = New System.Drawing.Size(65, 21)
        Me.cboEmpresa1.TabIndex = 8
        '
        'cboEmpresa2
        '
        Me.cboEmpresa2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa2.FormattingEnabled = True
        Me.cboEmpresa2.Location = New System.Drawing.Point(619, 12)
        Me.cboEmpresa2.Name = "cboEmpresa2"
        Me.cboEmpresa2.Size = New System.Drawing.Size(65, 21)
        Me.cboEmpresa2.TabIndex = 9
        '
        'barCodeInicio
        '
        Me.barCodeInicio.Image = Global.SGT_Transport.My.Resources.Resources.NET11
        Me.barCodeInicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barCodeInicio.Name = "barCodeInicio"
        Me.barCodeInicio.Size = New System.Drawing.Size(81, 51)
        Me.barCodeInicio.Text = "Code Inicial"
        Me.barCodeInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barCreateCode
        '
        Me.barCreateCode.Image = Global.SGT_Transport.My.Resources.Resources.NET2
        Me.barCreateCode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barCreateCode.Name = "barCreateCode"
        Me.barCreateCode.Size = New System.Drawing.Size(53, 51)
        Me.barCreateCode.Text = "Create"
        Me.barCreateCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barCreateCodeGC
        '
        Me.barCreateCodeGC.Image = Global.SGT_Transport.My.Resources.Resources.SQLSERVER4_e
        Me.barCreateCodeGC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barCreateCodeGC.Name = "barCreateCodeGC"
        Me.barCreateCodeGC.Size = New System.Drawing.Size(124, 51)
        Me.barCreateCodeGC.Text = "Desplegar tablas GC"
        Me.barCreateCodeGC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarRenombrarTablas
        '
        Me.BarRenombrarTablas.Image = Global.SGT_Transport.My.Resources.Resources.sql341
        Me.BarRenombrarTablas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarRenombrarTablas.Name = "BarRenombrarTablas"
        Me.BarRenombrarTablas.Size = New System.Drawing.Size(113, 51)
        Me.BarRenombrarTablas.Text = "Renombrar Tablas"
        Me.BarRenombrarTablas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barCreateBaseGPS
        '
        Me.barCreateBaseGPS.Image = Global.SGT_Transport.My.Resources.Resources.sql36
        Me.barCreateBaseGPS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barCreateBaseGPS.Name = "barCreateBaseGPS"
        Me.barCreateBaseGPS.Size = New System.Drawing.Size(94, 51)
        Me.barCreateBaseGPS.Text = "Crea Base GPS"
        Me.barCreateBaseGPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmCreaInsertSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 543)
        Me.Controls.Add(Me.cboEmpresa2)
        Me.Controls.Add(Me.cboEmpresa1)
        Me.Controls.Add(Me.FgT)
        Me.Controls.Add(Me.tBox)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.Fg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCreaInsertSQL"
        Me.Text = "Crea Insert SQL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.tBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FgT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barSalir As System.Windows.Forms.MenuStrip
    Friend WithEvents barCreateCode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tBox As C1.Win.C1Input.C1TextBox
    Friend WithEvents barCreateCodeGC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barCodeInicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FgT As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barCreateBaseGPS As ToolStripMenuItem
    Friend WithEvents BarRenombrarTablas As ToolStripMenuItem
    Friend WithEvents cboEmpresa1 As ComboBox
    Friend WithEvents cboEmpresa2 As ComboBox
End Class
