<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmbalajeBueno
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmbalajeBueno))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarMenuEstatus = New C1.Win.C1Command.C1CommandMenu()
        Me.BarMenuNormal = New C1.Win.C1Command.C1CommandLink()
        Me.BarMenuFinalizado = New C1.Win.C1Command.C1CommandLink()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkNuevo = New C1.Win.C1Command.C1CommandLink()
        Me.LkEdit = New C1.Win.C1Command.C1CommandLink()
        Me.LkRefrescar = New C1.Win.C1Command.C1CommandLink()
        Me.LkCancelar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BarNuevo = New C1.Win.C1Command.C1Command()
        Me.BarEdit = New C1.Win.C1Command.C1Command()
        Me.BarRefrescar = New C1.Win.C1Command.C1Command()
        Me.BarCancelar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.BarCambioStatus = New C1.Win.C1Command.C1Command()
        Me.BarTodos = New C1.Win.C1Command.C1Command()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarRefrescar)
        Me.MenuHolder.Commands.Add(Me.BarNuevo)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Commands.Add(Me.BarCambioStatus)
        Me.MenuHolder.Commands.Add(Me.BarEdit)
        Me.MenuHolder.Commands.Add(Me.BarCancelar)
        Me.MenuHolder.Commands.Add(Me.BarTodos)
        Me.MenuHolder.Commands.Add(Me.BarMenuEstatus)
        Me.MenuHolder.Owner = Me
        '
        'BarMenuEstatus
        '
        Me.BarMenuEstatus.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.BarMenuNormal, Me.BarMenuFinalizado})
        Me.BarMenuEstatus.HideNonRecentLinks = False
        Me.BarMenuEstatus.ImageBarWidth = 80
        Me.BarMenuEstatus.Name = "BarMenuEstatus"
        Me.BarMenuEstatus.ShortcutText = ""
        Me.BarMenuEstatus.Text = "Cambio Estatus"
        Me.BarMenuEstatus.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.BarMenuEstatus.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'BarMenuNormal
        '
        Me.BarMenuNormal.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.BarMenuNormal.Text = "Normal"
        '
        'BarMenuFinalizado
        '
        Me.BarMenuFinalizado.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.BarMenuFinalizado.SortOrder = 1
        Me.BarMenuFinalizado.Text = "Finalizado"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkNuevo, Me.LkEdit, Me.LkRefrescar, Me.LkCancelar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(800, 43)
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
        '
        'LkEdit
        '
        Me.LkEdit.Command = Me.BarEdit
        Me.LkEdit.Delimiter = True
        Me.LkEdit.SortOrder = 1
        Me.LkEdit.Text = "Edit"
        '
        'LkRefrescar
        '
        Me.LkRefrescar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkRefrescar.Command = Me.BarRefrescar
        Me.LkRefrescar.Delimiter = True
        Me.LkRefrescar.SortOrder = 2
        Me.LkRefrescar.Text = "Refrescar"
        Me.LkRefrescar.ToolTipText = "Refrescar"
        '
        'LkCancelar
        '
        Me.LkCancelar.Command = Me.BarCancelar
        Me.LkCancelar.Delimiter = True
        Me.LkCancelar.SortOrder = 3
        Me.LkCancelar.Text = "Cancelar"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 4
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "5,1,0,0,0,95,Columns:"
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(25, 101)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.Size = New System.Drawing.Size(465, 177)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 314
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'BarNuevo
        '
        Me.BarNuevo.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.BarNuevo.Name = "BarNuevo"
        Me.BarNuevo.ShortcutText = ""
        Me.BarNuevo.ShowShortcut = False
        Me.BarNuevo.ShowTextAsToolTip = False
        Me.BarNuevo.Text = "Nuevo"
        '
        'BarEdit
        '
        Me.BarEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit1
        Me.BarEdit.Name = "BarEdit"
        Me.BarEdit.ShortcutText = ""
        Me.BarEdit.Text = "Edit"
        '
        'BarRefrescar
        '
        Me.BarRefrescar.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.BarRefrescar.Name = "BarRefrescar"
        Me.BarRefrescar.ShortcutText = ""
        Me.BarRefrescar.ShowShortcut = False
        Me.BarRefrescar.ShowTextAsToolTip = False
        Me.BarRefrescar.Text = "Refrescar"
        '
        'BarCancelar
        '
        Me.BarCancelar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.ShortcutText = ""
        Me.BarCancelar.Text = "Cancelar"
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
        'BarCambioStatus
        '
        Me.BarCambioStatus.Image = Global.SGT_Transport.My.Resources.Resources.E3
        Me.BarCambioStatus.Name = "BarCambioStatus"
        Me.BarCambioStatus.ShortcutText = ""
        Me.BarCambioStatus.Text = "Cambio estatus"
        '
        'BarTodos
        '
        Me.BarTodos.Image = Global.SGT_Transport.My.Resources.Resources.doc10
        Me.BarTodos.Name = "BarTodos"
        Me.BarTodos.ShortcutText = ""
        Me.BarTodos.Text = "Todos"
        '
        'FrmEmbalajeBueno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEmbalajeBueno"
        Me.Text = "Embalaje"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarRefrescar As C1.Win.C1Command.C1Command
    Friend WithEvents BarNuevo As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents BarCambioStatus As C1.Win.C1Command.C1Command
    Friend WithEvents BarEdit As C1.Win.C1Command.C1Command
    Friend WithEvents BarCancelar As C1.Win.C1Command.C1Command
    Friend WithEvents BarTodos As C1.Win.C1Command.C1Command
    Friend WithEvents BarMenuEstatus As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents BarMenuNormal As C1.Win.C1Command.C1CommandLink
    Friend WithEvents BarMenuFinalizado As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkNuevo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEdit As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkRefrescar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkCancelar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
