<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInvenR
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInvenR))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barPrecios = New System.Windows.Forms.ToolStripMenuItem()
        Me.barKits = New System.Windows.Forms.ToolStripMenuItem()
        Me.barBaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.barKardex = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.Lt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tBox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.barSalir.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.barEdit, Me.btnEliminar, Me.barRefresh, Me.barEliminar, Me.barPrecios, Me.barKits, Me.barBaja, Me.barKardex, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1205, 55)
        Me.barSalir.TabIndex = 9
        Me.barSalir.Text = "MenuStrip1"
        '
        'barNuevo
        '
        Me.barNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barNuevo.ForeColor = System.Drawing.Color.Black
        Me.barNuevo.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.barNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNuevo.Name = "barNuevo"
        Me.barNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barNuevo.Size = New System.Drawing.Size(56, 51)
        Me.barNuevo.Text = "Nuevo"
        Me.barNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barNuevo.ToolTipText = "F2-Nuevo"
        '
        'barEdit
        '
        Me.barEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barEdit.ForeColor = System.Drawing.Color.Black
        Me.barEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.barEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEdit.Name = "barEdit"
        Me.barEdit.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barEdit.Size = New System.Drawing.Size(44, 51)
        Me.barEdit.Text = "Edit"
        Me.barEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Image = Global.SGT_Transport.My.Resources.Resources.eliminar7
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.btnEliminar.Size = New System.Drawing.Size(63, 51)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barRefresh
        '
        Me.barRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barRefresh.ForeColor = System.Drawing.Color.Black
        Me.barRefresh.Image = Global.SGT_Transport.My.Resources.Resources.CR
        Me.barRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barRefresh.Name = "barRefresh"
        Me.barRefresh.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barRefresh.Size = New System.Drawing.Size(73, 51)
        Me.barRefresh.Text = "Refrescar"
        Me.barRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barEliminar
        '
        Me.barEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barEliminar.ForeColor = System.Drawing.Color.Black
        Me.barEliminar.Image = Global.SGT_Transport.My.Resources.Resources.letrar
        Me.barEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEliminar.Name = "barEliminar"
        Me.barEliminar.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barEliminar.Size = New System.Drawing.Size(98, 51)
        Me.barEliminar.Text = "Cambio Status"
        Me.barEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barPrecios
        '
        Me.barPrecios.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barPrecios.ForeColor = System.Drawing.Color.Black
        Me.barPrecios.Image = Global.SGT_Transport.My.Resources.Resources.CP
        Me.barPrecios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barPrecios.Name = "barPrecios"
        Me.barPrecios.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barPrecios.Size = New System.Drawing.Size(59, 51)
        Me.barPrecios.Text = "Precios"
        Me.barPrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barKits
        '
        Me.barKits.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barKits.ForeColor = System.Drawing.Color.Black
        Me.barKits.Image = Global.SGT_Transport.My.Resources.Resources.K
        Me.barKits.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barKits.Name = "barKits"
        Me.barKits.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barKits.Size = New System.Drawing.Size(44, 51)
        Me.barKits.Text = "Kit's"
        Me.barKits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barBaja
        '
        Me.barBaja.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barBaja.ForeColor = System.Drawing.Color.Black
        Me.barBaja.Image = Global.SGT_Transport.My.Resources.Resources.B
        Me.barBaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barBaja.Name = "barBaja"
        Me.barBaja.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barBaja.Size = New System.Drawing.Size(83, 51)
        Me.barBaja.Text = "Estatus baja"
        Me.barBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barKardex
        '
        Me.barKardex.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barKardex.ForeColor = System.Drawing.Color.Black
        Me.barKardex.Image = Global.SGT_Transport.My.Resources.Resources.k5
        Me.barKardex.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barKardex.Name = "barKardex"
        Me.barKardex.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barKardex.Size = New System.Drawing.Size(59, 51)
        Me.barKardex.Text = "Kardex"
        Me.barKardex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 9.0R
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "51,1,0,0,0,95,Columns:"
        Me.Fg.ExtendLastCol = True
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 71)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowErrors = True
        Me.Fg.Size = New System.Drawing.Size(1148, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 10
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'Lt
        '
        Me.Lt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lt.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt.Location = New System.Drawing.Point(277, 16)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(172, 23)
        Me.Lt.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Texto a buscar"
        '
        'tBox
        '
        Me.tBox.Location = New System.Drawing.Point(12, 19)
        Me.tBox.Name = "tBox"
        Me.tBox.Size = New System.Drawing.Size(259, 20)
        Me.tBox.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tBox)
        Me.Panel1.Controls.Add(Me.Lt)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(818, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(507, 49)
        Me.Panel1.TabIndex = 15
        '
        'frmInvenR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1205, 620)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmInvenR"
        Me.Text = "frmInvenR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barNuevo As ToolStripMenuItem
    Friend WithEvents barEdit As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents Lt As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tBox As TextBox
    Friend WithEvents barPrecios As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents barEliminar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents barRefresh As ToolStripMenuItem
    Friend WithEvents barBaja As ToolStripMenuItem
    Friend WithEvents barKits As ToolStripMenuItem
    Friend WithEvents barKardex As ToolStripMenuItem
End Class
