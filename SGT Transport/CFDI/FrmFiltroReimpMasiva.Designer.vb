<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFiltroReimpMasiva
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFiltroReimpMasiva))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarImprimir = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkImprimir = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.Lt7 = New System.Windows.Forms.Label()
        Me.TCVE_CLIE2 = New System.Windows.Forms.TextBox()
        Me.BtnClie2 = New C1.Win.C1Input.C1Button()
        Me.Lt6 = New System.Windows.Forms.Label()
        Me.TCVE_CLIE1 = New System.Windows.Forms.TextBox()
        Me.BtnClie1 = New C1.Win.C1Input.C1Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TFAC2 = New System.Windows.Forms.TextBox()
        Me.BrtFactura2 = New C1.Win.C1Input.C1Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TFAC1 = New System.Windows.Forms.TextBox()
        Me.BrtFactura1 = New C1.Win.C1Input.C1Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChIgnorarFechas = New C1.Win.C1Input.C1CheckBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClie2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClie1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BrtFactura2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BrtFactura1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChIgnorarFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(110, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Rango de fechas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(256, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 351
        Me.Label2.Text = "al"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(295, 104)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 1
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(79, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 350
        Me.Label1.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(113, 104)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarImprimir)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.ShortcutText = ""
        Me.BarImprimir.ShowShortcut = False
        Me.BarImprimir.ShowTextAsToolTip = False
        Me.BarImprimir.Text = "Imprimir"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkImprimir, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(539, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkImprimir
        '
        Me.LkImprimir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkImprimir.Command = Me.BarImprimir
        Me.LkImprimir.Delimiter = True
        Me.LkImprimir.Text = "Imprimir"
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
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt5.Location = New System.Drawing.Point(200, 149)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(97, 16)
        Me.Lt5.TabIndex = 8
        Me.Lt5.Text = "Rango clientes"
        '
        'Lt7
        '
        Me.Lt7.AutoSize = True
        Me.Lt7.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt7.Location = New System.Drawing.Point(250, 181)
        Me.Lt7.Name = "Lt7"
        Me.Lt7.Size = New System.Drawing.Size(18, 16)
        Me.Lt7.TabIndex = 363
        Me.Lt7.Text = "al"
        '
        'TCVE_CLIE2
        '
        Me.TCVE_CLIE2.AcceptsReturn = True
        Me.TCVE_CLIE2.AcceptsTab = True
        Me.TCVE_CLIE2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_CLIE2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CLIE2.ForeColor = System.Drawing.Color.Black
        Me.TCVE_CLIE2.Location = New System.Drawing.Point(273, 177)
        Me.TCVE_CLIE2.MaxLength = 10
        Me.TCVE_CLIE2.Name = "TCVE_CLIE2"
        Me.TCVE_CLIE2.Size = New System.Drawing.Size(78, 22)
        Me.TCVE_CLIE2.TabIndex = 3
        '
        'BtnClie2
        '
        Me.BtnClie2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie2.Image = CType(resources.GetObject("BtnClie2.Image"), System.Drawing.Image)
        Me.BtnClie2.Location = New System.Drawing.Point(354, 178)
        Me.BtnClie2.Name = "BtnClie2"
        Me.BtnClie2.Size = New System.Drawing.Size(23, 20)
        Me.BtnClie2.TabIndex = 364
        Me.BtnClie2.UseVisualStyleBackColor = True
        Me.BtnClie2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt6
        '
        Me.Lt6.AutoSize = True
        Me.Lt6.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Lt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Lt6.Location = New System.Drawing.Point(101, 180)
        Me.Lt6.Name = "Lt6"
        Me.Lt6.Size = New System.Drawing.Size(28, 16)
        Me.Lt6.TabIndex = 360
        Me.Lt6.Text = "Del"
        '
        'TCVE_CLIE1
        '
        Me.TCVE_CLIE1.AcceptsReturn = True
        Me.TCVE_CLIE1.AcceptsTab = True
        Me.TCVE_CLIE1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TCVE_CLIE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_CLIE1.ForeColor = System.Drawing.Color.Black
        Me.TCVE_CLIE1.Location = New System.Drawing.Point(134, 177)
        Me.TCVE_CLIE1.MaxLength = 10
        Me.TCVE_CLIE1.Name = "TCVE_CLIE1"
        Me.TCVE_CLIE1.Size = New System.Drawing.Size(78, 22)
        Me.TCVE_CLIE1.TabIndex = 2
        '
        'BtnClie1
        '
        Me.BtnClie1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClie1.Image = CType(resources.GetObject("BtnClie1.Image"), System.Drawing.Image)
        Me.BtnClie1.Location = New System.Drawing.Point(215, 178)
        Me.BtnClie1.Name = "BtnClie1"
        Me.BtnClie1.Size = New System.Drawing.Size(23, 20)
        Me.BtnClie1.TabIndex = 361
        Me.BtnClie1.UseVisualStyleBackColor = True
        Me.BtnClie1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(244, 283)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 16)
        Me.Label6.TabIndex = 371
        Me.Label6.Text = "al"
        '
        'TFAC2
        '
        Me.TFAC2.AcceptsReturn = True
        Me.TFAC2.AcceptsTab = True
        Me.TFAC2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TFAC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFAC2.Location = New System.Drawing.Point(267, 280)
        Me.TFAC2.MaxLength = 10
        Me.TFAC2.Name = "TFAC2"
        Me.TFAC2.Size = New System.Drawing.Size(134, 22)
        Me.TFAC2.TabIndex = 5
        '
        'BrtFactura2
        '
        Me.BrtFactura2.Image = CType(resources.GetObject("BrtFactura2.Image"), System.Drawing.Image)
        Me.BrtFactura2.Location = New System.Drawing.Point(406, 281)
        Me.BrtFactura2.Name = "BrtFactura2"
        Me.BrtFactura2.Size = New System.Drawing.Size(23, 20)
        Me.BrtFactura2.TabIndex = 372
        Me.BrtFactura2.UseVisualStyleBackColor = True
        Me.BrtFactura2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(40, 283)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 16)
        Me.Label7.TabIndex = 369
        Me.Label7.Text = "Del"
        '
        'TFAC1
        '
        Me.TFAC1.AcceptsReturn = True
        Me.TFAC1.AcceptsTab = True
        Me.TFAC1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TFAC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFAC1.Location = New System.Drawing.Point(72, 280)
        Me.TFAC1.MaxLength = 10
        Me.TFAC1.Name = "TFAC1"
        Me.TFAC1.Size = New System.Drawing.Size(134, 22)
        Me.TFAC1.TabIndex = 4
        '
        'BrtFactura1
        '
        Me.BrtFactura1.Image = CType(resources.GetObject("BrtFactura1.Image"), System.Drawing.Image)
        Me.BrtFactura1.Location = New System.Drawing.Point(210, 281)
        Me.BrtFactura1.Name = "BrtFactura1"
        Me.BrtFactura1.Size = New System.Drawing.Size(23, 20)
        Me.BrtFactura1.TabIndex = 370
        Me.BrtFactura1.UseVisualStyleBackColor = True
        Me.BrtFactura1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(187, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Rango documentos"
        '
        'ChIgnorarFechas
        '
        Me.ChIgnorarFechas.BackColor = System.Drawing.Color.Transparent
        Me.ChIgnorarFechas.BorderColor = System.Drawing.Color.Transparent
        Me.ChIgnorarFechas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChIgnorarFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChIgnorarFechas.ForeColor = System.Drawing.Color.Black
        Me.ChIgnorarFechas.Location = New System.Drawing.Point(295, 62)
        Me.ChIgnorarFechas.Name = "ChIgnorarFechas"
        Me.ChIgnorarFechas.Padding = New System.Windows.Forms.Padding(1)
        Me.ChIgnorarFechas.Size = New System.Drawing.Size(166, 32)
        Me.ChIgnorarFechas.TabIndex = 6
        Me.ChIgnorarFechas.Text = "Ignorar fechas"
        Me.ChIgnorarFechas.UseVisualStyleBackColor = False
        Me.ChIgnorarFechas.Value = False
        Me.ChIgnorarFechas.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmFiltroReimpMasiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 365)
        Me.Controls.Add(Me.ChIgnorarFechas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TFAC2)
        Me.Controls.Add(Me.BrtFactura2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TFAC1)
        Me.Controls.Add(Me.BrtFactura1)
        Me.Controls.Add(Me.Lt5)
        Me.Controls.Add(Me.Lt7)
        Me.Controls.Add(Me.TCVE_CLIE2)
        Me.Controls.Add(Me.BtnClie2)
        Me.Controls.Add(Me.Lt6)
        Me.Controls.Add(Me.TCVE_CLIE1)
        Me.Controls.Add(Me.BtnClie1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFiltroReimpMasiva"
        Me.ShowInTaskbar = False
        Me.Text = "Filtro reimpresión masiva"
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClie2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClie1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BrtFactura2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BrtFactura1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChIgnorarFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarImprimir As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkImprimir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Lt5 As Label
    Friend WithEvents Lt7 As Label
    Friend WithEvents TCVE_CLIE2 As TextBox
    Friend WithEvents BtnClie2 As C1.Win.C1Input.C1Button
    Friend WithEvents Lt6 As Label
    Friend WithEvents TCVE_CLIE1 As TextBox
    Friend WithEvents BtnClie1 As C1.Win.C1Input.C1Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TFAC2 As TextBox
    Friend WithEvents BrtFactura2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TFAC1 As TextBox
    Friend WithEvents BrtFactura1 As C1.Win.C1Input.C1Button
    Friend WithEvents ChIgnorarFechas As C1.Win.C1Input.C1CheckBox
    Friend WithEvents PrintDialog1 As PrintDialog
End Class
