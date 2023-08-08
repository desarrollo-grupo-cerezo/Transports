<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReasignarValesDiesel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReasignarValesDiesel))
        Me.MenuHolder2 = New C1.Win.C1Command.C1CommandHolder()
        Me.BarNuevo = New C1.Win.C1Command.C1Command()
        Me.BarEdit = New C1.Win.C1Command.C1Command()
        Me.BarEliminar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkNuevo = New C1.Win.C1Command.C1CommandLink()
        Me.LkEdit = New C1.Win.C1Command.C1CommandLink()
        Me.LkEliminar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        CType(Me.MenuHolder2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder2
        '
        Me.MenuHolder2.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder2.Commands.Add(Me.BarNuevo)
        Me.MenuHolder2.Commands.Add(Me.BarEdit)
        Me.MenuHolder2.Commands.Add(Me.BarEliminar)
        Me.MenuHolder2.Commands.Add(Me.BarSalir)
        Me.MenuHolder2.Owner = Nothing
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
        'BarEliminar
        '
        Me.BarEliminar.Image = Global.SGT_Transport.My.Resources.Resources.eliminar7
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
        Me.C1ToolBar1.Size = New System.Drawing.Size(504, 43)
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
        'FrmReasignarValesDiesel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 296)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReasignarValesDiesel"
        Me.Text = "Reasignar Vales Diesel"
        CType(Me.MenuHolder2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder2 As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarNuevo As C1.Win.C1Command.C1Command
    Private WithEvents BarEdit As C1.Win.C1Command.C1Command
    Private WithEvents BarEliminar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkNuevo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEdit As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkEliminar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
End Class
