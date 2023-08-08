<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFacturaGlobalSel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturaGlobalSel))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarAceptar = New C1.Win.C1Command.C1Command()
        Me.BarCancelar = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkAceptar = New C1.Win.C1Command.C1CommandLink()
        Me.LkCancelar = New C1.Win.C1Command.C1CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboSerieFacturaGlobal = New C1.Win.C1Input.C1ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CboPeriodicidad = New C1.Win.C1Input.C1ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtAl = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.LtDel = New System.Windows.Forms.Label()
        Me.CboSerieFiltro = New C1.Win.C1Input.C1ComboBox()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Tab2 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.RadSoloNCteMostr = New System.Windows.Forms.RadioButton()
        Me.RadTodas = New System.Windows.Forms.RadioButton()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSerieFacturaGlobal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboPeriodicidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboSerieFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab2.SuspendLayout()
        Me.Pag2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarAceptar)
        Me.MenuHolder.Commands.Add(Me.BarCancelar)
        Me.MenuHolder.Owner = Me
        '
        'BarAceptar
        '
        Me.BarAceptar.Image = Global.SGT_Transport.My.Resources.Resources.disco1
        Me.BarAceptar.Name = "BarAceptar"
        Me.BarAceptar.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.BarAceptar.ShortcutText = ""
        Me.BarAceptar.Text = "Aceptar"
        '
        'BarCancelar
        '
        Me.BarCancelar.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.ShortcutText = ""
        Me.BarCancelar.ShowShortcut = False
        Me.BarCancelar.ShowTextAsToolTip = False
        Me.BarCancelar.Text = "Cancelar"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkAceptar, Me.LkCancelar})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(476, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkAceptar
        '
        Me.LkAceptar.Command = Me.BarAceptar
        Me.LkAceptar.Delimiter = True
        Me.LkAceptar.Text = "Aceptar"
        '
        'LkCancelar
        '
        Me.LkCancelar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkCancelar.Command = Me.BarCancelar
        Me.LkCancelar.Delimiter = True
        Me.LkCancelar.SortOrder = 1
        Me.LkCancelar.Text = "Cancelar"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(387, 47)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Es proceso generará un CFDI Global, basandose en un conjunto de notas de venta qu" &
    "e se indique en el filtro de fechas. El desglose de esta facturación será por no" &
    "tas de venta."
        '
        'CboSerieFacturaGlobal
        '
        Me.CboSerieFacturaGlobal.AllowSpinLoop = False
        Me.CboSerieFacturaGlobal.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CboSerieFacturaGlobal.BorderColor = System.Drawing.Color.DodgerBlue
        Me.CboSerieFacturaGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerieFacturaGlobal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerieFacturaGlobal.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboSerieFacturaGlobal.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerieFacturaGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerieFacturaGlobal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CboSerieFacturaGlobal.GapHeight = 0
        Me.CboSerieFacturaGlobal.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerieFacturaGlobal.ItemsDisplayMember = ""
        Me.CboSerieFacturaGlobal.ItemsValueMember = ""
        Me.CboSerieFacturaGlobal.Location = New System.Drawing.Point(97, 30)
        Me.CboSerieFacturaGlobal.Name = "CboSerieFacturaGlobal"
        Me.CboSerieFacturaGlobal.Size = New System.Drawing.Size(76, 19)
        Me.CboSerieFacturaGlobal.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboSerieFacturaGlobal.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboSerieFacturaGlobal.TabIndex = 598
        Me.CboSerieFacturaGlobal.Tag = Nothing
        Me.CboSerieFacturaGlobal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(219, 32)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 15)
        Me.Label21.TabIndex = 602
        Me.Label21.Text = "Periodicidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'CboPeriodicidad
        '
        Me.CboPeriodicidad.AcceptsTab = True
        Me.CboPeriodicidad.AllowSpinLoop = False
        Me.CboPeriodicidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CboPeriodicidad.BorderColor = System.Drawing.Color.DodgerBlue
        Me.CboPeriodicidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboPeriodicidad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboPeriodicidad.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboPeriodicidad.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboPeriodicidad.DropDownWidth = 140
        Me.CboPeriodicidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPeriodicidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CboPeriodicidad.GapHeight = 0
        Me.CboPeriodicidad.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboPeriodicidad.ItemsDisplayMember = ""
        Me.CboPeriodicidad.ItemsValueMember = ""
        Me.CboPeriodicidad.Location = New System.Drawing.Point(298, 31)
        Me.CboPeriodicidad.Name = "CboPeriodicidad"
        Me.CboPeriodicidad.Size = New System.Drawing.Size(120, 19)
        Me.CboPeriodicidad.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboPeriodicidad.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboPeriodicidad.TabIndex = 599
        Me.CboPeriodicidad.Tag = Nothing
        Me.CboPeriodicidad.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(57, 31)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(36, 15)
        Me.Label22.TabIndex = 601
        Me.Label22.Text = "Serie"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(156, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 15)
        Me.Label2.TabIndex = 604
        Me.Label2.Text = "Fechas de elaboración"
        '
        'LtAl
        '
        Me.LtAl.AutoSize = True
        Me.LtAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtAl.Location = New System.Drawing.Point(220, 32)
        Me.LtAl.Name = "LtAl"
        Me.LtAl.Size = New System.Drawing.Size(67, 15)
        Me.LtAl.TabIndex = 359
        Me.LtAl.Text = "Fecha final"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(57, 75)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 15)
        Me.Label20.TabIndex = 603
        Me.Label20.Text = "Serie"
        '
        'F2
        '
        Me.F2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.F2.BorderColor = System.Drawing.Color.DodgerBlue
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(298, 30)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(100, 19)
        Me.F2.TabIndex = 357
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtDel
        '
        Me.LtDel.AutoSize = True
        Me.LtDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtDel.Location = New System.Drawing.Point(17, 32)
        Me.LtDel.Name = "LtDel"
        Me.LtDel.Size = New System.Drawing.Size(76, 15)
        Me.LtDel.TabIndex = 358
        Me.LtDel.Text = "Fecha inicial"
        '
        'CboSerieFiltro
        '
        Me.CboSerieFiltro.AllowSpinLoop = False
        Me.CboSerieFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CboSerieFiltro.BorderColor = System.Drawing.Color.DodgerBlue
        Me.CboSerieFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboSerieFiltro.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboSerieFiltro.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboSerieFiltro.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboSerieFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSerieFiltro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CboSerieFiltro.GapHeight = 0
        Me.CboSerieFiltro.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboSerieFiltro.ItemsDisplayMember = ""
        Me.CboSerieFiltro.ItemsValueMember = ""
        Me.CboSerieFiltro.Location = New System.Drawing.Point(97, 73)
        Me.CboSerieFiltro.Name = "CboSerieFiltro"
        Me.CboSerieFiltro.Size = New System.Drawing.Size(66, 19)
        Me.CboSerieFiltro.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboSerieFiltro.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboSerieFiltro.TabIndex = 600
        Me.CboSerieFiltro.Tag = Nothing
        Me.CboSerieFiltro.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'F1
        '
        Me.F1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.F1.BorderColor = System.Drawing.Color.DodgerBlue
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(97, 30)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(100, 19)
        Me.F1.TabIndex = 356
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Pag1)
        Me.Tab1.ItemSize = New System.Drawing.Size(459, 0)
        Me.Tab1.Location = New System.Drawing.Point(12, 116)
        Me.Tab1.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(457, 105)
        Me.Tab1.TabAreaBorder = True
        Me.Tab1.TabAreaSpacing = 0
        Me.Tab1.TabIndex = 605
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsSpacing = 0
        Me.Tab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Silver
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Silver
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.CboPeriodicidad)
        Me.Pag1.Controls.Add(Me.Label22)
        Me.Pag1.Controls.Add(Me.Label21)
        Me.Pag1.Controls.Add(Me.CboSerieFacturaGlobal)
        Me.Pag1.Location = New System.Drawing.Point(1, 22)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(455, 82)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Datos de facturación global"
        '
        'Tab2
        '
        Me.Tab2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab2.Controls.Add(Me.Pag2)
        Me.Tab2.ItemSize = New System.Drawing.Size(457, 0)
        Me.Tab2.Location = New System.Drawing.Point(12, 225)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Size = New System.Drawing.Size(457, 181)
        Me.Tab2.TabAreaBorder = True
        Me.Tab2.TabAreaSpacing = 0
        Me.Tab2.TabIndex = 606
        Me.Tab2.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab2.TabsSpacing = 0
        Me.Tab2.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.Tab2.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Silver
        Me.Tab2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Silver
        '
        'Pag2
        '
        Me.Pag2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Pag2.Controls.Add(Me.RadTodas)
        Me.Pag2.Controls.Add(Me.RadSoloNCteMostr)
        Me.Pag2.Controls.Add(Me.F1)
        Me.Pag2.Controls.Add(Me.CboSerieFiltro)
        Me.Pag2.Controls.Add(Me.Label2)
        Me.Pag2.Controls.Add(Me.LtDel)
        Me.Pag2.Controls.Add(Me.LtAl)
        Me.Pag2.Controls.Add(Me.F2)
        Me.Pag2.Controls.Add(Me.Label20)
        Me.Pag2.Location = New System.Drawing.Point(1, 22)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(455, 158)
        Me.Pag2.TabBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Pag2.TabBackColorSelected = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Pag2.TabIndex = 0
        Me.Pag2.Text = "Filtro de notas de venta"
        '
        'RadSoloNCteMostr
        '
        Me.RadSoloNCteMostr.AutoSize = True
        Me.RadSoloNCteMostr.Checked = True
        Me.RadSoloNCteMostr.Location = New System.Drawing.Point(97, 114)
        Me.RadSoloNCteMostr.Name = "RadSoloNCteMostr"
        Me.RadSoloNCteMostr.Size = New System.Drawing.Size(173, 17)
        Me.RadSoloNCteMostr.TabIndex = 606
        Me.RadSoloNCteMostr.TabStop = True
        Me.RadSoloNCteMostr.Text = "Solo notas de cliente mostrador"
        Me.RadSoloNCteMostr.UseVisualStyleBackColor = True
        '
        'RadTodas
        '
        Me.RadTodas.AutoSize = True
        Me.RadTodas.Location = New System.Drawing.Point(298, 114)
        Me.RadTodas.Name = "RadTodas"
        Me.RadTodas.Size = New System.Drawing.Size(100, 17)
        Me.RadTodas.TabIndex = 607
        Me.RadTodas.Text = "Todas las notas"
        Me.RadTodas.UseVisualStyleBackColor = True
        '
        'FrmFacturaGlobalSel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 418)
        Me.Controls.Add(Me.Tab2)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFacturaGlobalSel"
        Me.ShowInTaskbar = False
        Me.Text = "Factura global de notas de venta"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Office2010Blue
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSerieFacturaGlobal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboPeriodicidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboSerieFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        Me.Pag1.PerformLayout()
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab2.ResumeLayout(False)
        Me.Pag2.ResumeLayout(False)
        Me.Pag2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarAceptar As C1.Win.C1Command.C1Command
    Friend WithEvents BarCancelar As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkAceptar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkCancelar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label1 As Label
    Friend WithEvents CboSerieFacturaGlobal As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents CboPeriodicidad As C1.Win.C1Input.C1ComboBox
    Friend WithEvents CboSerieFiltro As C1.Win.C1Input.C1ComboBox
    Friend WithEvents LtAl As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtDel As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Tab2 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents RadTodas As RadioButton
    Friend WithEvents RadSoloNCteMostr As RadioButton
End Class
