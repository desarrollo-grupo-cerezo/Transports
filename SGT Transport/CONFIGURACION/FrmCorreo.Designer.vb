<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCorreo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCorreo))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarCorreo = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkCorreo = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.TCORREO1 = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TCORREO2 = New System.Windows.Forms.TextBox()
        Me.TCORREO4 = New System.Windows.Forms.TextBox()
        Me.TCORREO3 = New System.Windows.Forms.TextBox()
        Me.TCORREO_CTE = New System.Windows.Forms.TextBox()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarCorreo)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarCorreo
        '
        Me.BarCorreo.Image = Global.SGT_Transport.My.Resources.Resources.correo1
        Me.BarCorreo.Name = "BarCorreo"
        Me.BarCorreo.ShortcutText = ""
        Me.BarCorreo.ShowShortcut = False
        Me.BarCorreo.ShowTextAsToolTip = False
        Me.BarCorreo.Text = "Correo"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkCorreo, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 34
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(550, 57)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'LkCorreo
        '
        Me.LkCorreo.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkCorreo.Command = Me.BarCorreo
        Me.LkCorreo.Delimiter = True
        Me.LkCorreo.Text = "Enviar correo"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.Text = "Salir"
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'TCORREO1
        '
        Me.TCORREO1.AcceptsReturn = True
        Me.TCORREO1.AcceptsTab = True
        Me.TCORREO1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCORREO1.Location = New System.Drawing.Point(32, 259)
        Me.TCORREO1.MaxLength = 90
        Me.TCORREO1.Name = "TCORREO1"
        Me.TCORREO1.Size = New System.Drawing.Size(497, 23)
        Me.TCORREO1.TabIndex = 0
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(29, 239)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(133, 17)
        Me.Nombre.TabIndex = 117
        Me.Nombre.Text = "Correos adicionales"
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LtNombre.Location = New System.Drawing.Point(32, 99)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(497, 23)
        Me.LtNombre.TabIndex = 118
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 17)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 17)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Correo cliente"
        '
        'TCORREO2
        '
        Me.TCORREO2.AcceptsReturn = True
        Me.TCORREO2.AcceptsTab = True
        Me.TCORREO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCORREO2.Location = New System.Drawing.Point(32, 287)
        Me.TCORREO2.MaxLength = 90
        Me.TCORREO2.Name = "TCORREO2"
        Me.TCORREO2.Size = New System.Drawing.Size(497, 23)
        Me.TCORREO2.TabIndex = 1
        '
        'TCORREO4
        '
        Me.TCORREO4.AcceptsReturn = True
        Me.TCORREO4.AcceptsTab = True
        Me.TCORREO4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCORREO4.Location = New System.Drawing.Point(32, 343)
        Me.TCORREO4.MaxLength = 90
        Me.TCORREO4.Name = "TCORREO4"
        Me.TCORREO4.Size = New System.Drawing.Size(497, 23)
        Me.TCORREO4.TabIndex = 3
        '
        'TCORREO3
        '
        Me.TCORREO3.AcceptsReturn = True
        Me.TCORREO3.AcceptsTab = True
        Me.TCORREO3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCORREO3.Location = New System.Drawing.Point(32, 315)
        Me.TCORREO3.MaxLength = 90
        Me.TCORREO3.Name = "TCORREO3"
        Me.TCORREO3.Size = New System.Drawing.Size(497, 23)
        Me.TCORREO3.TabIndex = 2
        '
        'TCORREO_CTE
        '
        Me.TCORREO_CTE.AcceptsReturn = True
        Me.TCORREO_CTE.AcceptsTab = True
        Me.TCORREO_CTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCORREO_CTE.Location = New System.Drawing.Point(32, 169)
        Me.TCORREO_CTE.MaxLength = 90
        Me.TCORREO_CTE.Name = "TCORREO_CTE"
        Me.TCORREO_CTE.Size = New System.Drawing.Size(497, 23)
        Me.TCORREO_CTE.TabIndex = 123
        '
        'FrmCorreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 408)
        Me.Controls.Add(Me.TCORREO_CTE)
        Me.Controls.Add(Me.TCORREO4)
        Me.Controls.Add(Me.TCORREO3)
        Me.Controls.Add(Me.TCORREO2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.TCORREO1)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCorreo"
        Me.Text = "Enviar correo electrónico"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarCorreo As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkCorreo As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents TCORREO1 As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents TCORREO4 As TextBox
    Friend WithEvents TCORREO3 As TextBox
    Friend WithEvents TCORREO2 As TextBox
    Friend WithEvents TCORREO_CTE As TextBox
End Class
