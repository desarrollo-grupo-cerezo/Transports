<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCFDISeries
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCFDISeries))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboCPTraslado = New C1.Win.C1Input.C1ComboBox()
        Me.L3 = New System.Windows.Forms.Label()
        Me.BtnClie = New C1.Win.C1Input.C1Button()
        Me.TCVE_CLIE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCPTraslado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.ShortcutText = ""
        Me.BarGrabar.ShowShortcut = False
        Me.BarGrabar.ShowTextAsToolTip = False
        Me.BarGrabar.Text = "Grabar"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.MinButtonSize = 34
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(457, 56)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'LkGrabar
        '
        Me.LkGrabar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabar.Command = Me.BarGrabar
        Me.LkGrabar.Delimiter = True
        Me.LkGrabar.Text = "Grabar"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 16)
        Me.Label2.TabIndex = 312
        Me.Label2.Text = "Serie carta porte traslado"
        '
        'CboCPTraslado
        '
        Me.CboCPTraslado.AllowSpinLoop = False
        Me.CboCPTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboCPTraslado.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboCPTraslado.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboCPTraslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCPTraslado.GapHeight = 0
        Me.CboCPTraslado.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboCPTraslado.ItemsDisplayMember = ""
        Me.CboCPTraslado.ItemsValueMember = ""
        Me.CboCPTraslado.Location = New System.Drawing.Point(192, 101)
        Me.CboCPTraslado.Name = "CboCPTraslado"
        Me.CboCPTraslado.Size = New System.Drawing.Size(100, 21)
        Me.CboCPTraslado.TabIndex = 0
        Me.CboCPTraslado.Tag = Nothing
        Me.CboCPTraslado.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboCPTraslado.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'L3
        '
        Me.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.Location = New System.Drawing.Point(82, 179)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(345, 20)
        Me.L3.TabIndex = 317
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnClie
        '
        Me.BtnClie.AutoSize = True
        Me.BtnClie.FlatAppearance.BorderSize = 0
        Me.BtnClie.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie.Image = CType(resources.GetObject("BtnClie.Image"), System.Drawing.Image)
        Me.BtnClie.Location = New System.Drawing.Point(252, 148)
        Me.BtnClie.Name = "BtnClie"
        Me.BtnClie.Size = New System.Drawing.Size(26, 22)
        Me.BtnClie.TabIndex = 316
        Me.BtnClie.UseVisualStyleBackColor = True
        Me.BtnClie.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCVE_CLIE
        '
        Me.TCVE_CLIE.AcceptsReturn = True
        Me.TCVE_CLIE.AcceptsTab = True
        Me.TCVE_CLIE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_CLIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CLIE.Location = New System.Drawing.Point(192, 148)
        Me.TCVE_CLIE.Name = "TCVE_CLIE"
        Me.TCVE_CLIE.Size = New System.Drawing.Size(54, 22)
        Me.TCVE_CLIE.TabIndex = 314
        Me.TCVE_CLIE.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 16)
        Me.Label5.TabIndex = 315
        Me.Label5.Text = "Cliente carta porte traslado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 318
        Me.Label1.Text = "Nombre"
        '
        'FrmCFDISeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 304)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.L3)
        Me.Controls.Add(Me.BtnClie)
        Me.Controls.Add(Me.TCVE_CLIE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboCPTraslado)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCFDISeries"
        Me.ShowInTaskbar = False
        Me.Text = "Parámetros CFDI"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCPTraslado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label2 As Label
    Friend WithEvents CboCPTraslado As C1.Win.C1Input.C1ComboBox
    Friend WithEvents L3 As Label
    Friend WithEvents BtnClie As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_CLIE As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
End Class
