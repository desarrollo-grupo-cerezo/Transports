<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFlujoCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFlujoCaja))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.RadEntrada = New System.Windows.Forms.RadioButton()
        Me.RadSalida = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TIMPORTE = New C1.Win.C1Input.C1NumericEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TOBS = New C1.Win.C1Input.C1TextBox()
        Me.TCLAVE = New C1.Win.C1Input.C1NumericEdit()
        Me.LtDescr = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnCpto = New C1.Win.C1Input.C1Button()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMPORTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TOBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCLAVE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCpto, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarGrabar.Text = "Grabar"
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Shortcut = System.Windows.Forms.Shortcut.F5
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
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(412, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabar
        '
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
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'RadEntrada
        '
        Me.RadEntrada.AutoSize = True
        Me.RadEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadEntrada.Location = New System.Drawing.Point(96, 109)
        Me.RadEntrada.Name = "RadEntrada"
        Me.RadEntrada.Size = New System.Drawing.Size(72, 20)
        Me.RadEntrada.TabIndex = 0
        Me.RadEntrada.TabStop = True
        Me.RadEntrada.Text = "Entrada"
        Me.RadEntrada.UseVisualStyleBackColor = True
        '
        'RadSalida
        '
        Me.RadSalida.AutoSize = True
        Me.RadSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadSalida.Location = New System.Drawing.Point(225, 109)
        Me.RadSalida.Name = "RadSalida"
        Me.RadSalida.Size = New System.Drawing.Size(64, 20)
        Me.RadSalida.TabIndex = 1
        Me.RadSalida.TabStop = True
        Me.RadSalida.Text = "Salida"
        Me.RadSalida.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(108, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(174, 16)
        Me.Label8.TabIndex = 397
        Me.Label8.Text = "Tipo de movimiento de caja"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 409
        Me.Label1.Text = "Concepto"
        '
        'TIMPORTE
        '
        Me.TIMPORTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TIMPORTE.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPORTE.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPORTE.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPORTE.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TIMPORTE.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPORTE.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TIMPORTE.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TIMPORTE.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPORTE.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TIMPORTE.InterceptArrowKeys = False
        Me.TIMPORTE.Location = New System.Drawing.Point(184, 235)
        Me.TIMPORTE.Name = "TIMPORTE"
        Me.TIMPORTE.Size = New System.Drawing.Size(129, 20)
        Me.TIMPORTE.TabIndex = 3
        Me.TIMPORTE.Tag = Nothing
        Me.TIMPORTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPORTE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TIMPORTE.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TIMPORTE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(126, 237)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 16)
        Me.Label15.TabIndex = 574
        Me.Label15.Text = "Importe"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(26, 278)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 16)
        Me.Label16.TabIndex = 572
        Me.Label16.Text = "Observaciones"
        '
        'TOBS
        '
        Me.TOBS.BorderColor = System.Drawing.Color.LightSkyBlue
        Me.TOBS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TOBS.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOBS.Location = New System.Drawing.Point(29, 300)
        Me.TOBS.Multiline = True
        Me.TOBS.Name = "TOBS"
        Me.TOBS.Size = New System.Drawing.Size(284, 47)
        Me.TOBS.TabIndex = 4
        Me.TOBS.Tag = Nothing
        Me.TOBS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TCLAVE
        '
        Me.TCLAVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TCLAVE.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TCLAVE.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCLAVE.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCLAVE.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCLAVE.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TCLAVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLAVE.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TCLAVE.InterceptArrowKeys = False
        Me.TCLAVE.Location = New System.Drawing.Point(111, 155)
        Me.TCLAVE.Name = "TCLAVE"
        Me.TCLAVE.Size = New System.Drawing.Size(51, 20)
        Me.TCLAVE.TabIndex = 2
        Me.TCLAVE.Tag = Nothing
        Me.TCLAVE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCLAVE.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TCLAVE.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TCLAVE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDescr
        '
        Me.LtDescr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDescr.Location = New System.Drawing.Point(111, 187)
        Me.LtDescr.Name = "LtDescr"
        Me.LtDescr.Size = New System.Drawing.Size(262, 22)
        Me.LtDescr.TabIndex = 576
        Me.LtDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 190)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 577
        Me.Label2.Text = "Descripción"
        '
        'BtnCpto
        '
        Me.BtnCpto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCpto.Image = CType(resources.GetObject("BtnCpto.Image"), System.Drawing.Image)
        Me.BtnCpto.Location = New System.Drawing.Point(165, 155)
        Me.BtnCpto.Name = "BtnCpto"
        Me.BtnCpto.Size = New System.Drawing.Size(26, 20)
        Me.BtnCpto.TabIndex = 578
        Me.BtnCpto.UseVisualStyleBackColor = True
        Me.BtnCpto.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'FrmFlujoCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 369)
        Me.Controls.Add(Me.BtnCpto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LtDescr)
        Me.Controls.Add(Me.TCLAVE)
        Me.Controls.Add(Me.TIMPORTE)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TOBS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.RadSalida)
        Me.Controls.Add(Me.RadEntrada)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFlujoCaja"
        Me.Text = "Flujo de caja"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMPORTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TOBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCLAVE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCpto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabar As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents RadEntrada As RadioButton
    Friend WithEvents RadSalida As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TIMPORTE As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label15 As Label
    Private WithEvents Label16 As Label
    Friend WithEvents TOBS As C1.Win.C1Input.C1TextBox
    Friend WithEvents TCLAVE As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents LtDescr As Label
    Friend WithEvents BtnCpto As C1.Win.C1Input.C1Button
End Class
