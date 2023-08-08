<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCartaPorteTrasladoAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCartaPorteTrasladoAE))
        Me.BarraMENU = New System.Windows.Forms.MenuStrip()
        Me.BarTimbrarCartaPorteTraslado = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCFD = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSerie = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.LtCVE_DOC = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LtSucOrigen = New System.Windows.Forms.Label()
        Me.LtSucDestino = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Ldocu = New System.Windows.Forms.Label()
        Me.SplitM1 = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.LtNpart = New System.Windows.Forms.Label()
        Me.TConfigVehicular = New System.Windows.Forms.TextBox()
        Me.TKMRecorridos = New C1.Win.C1Input.C1NumericEdit()
        Me.TFechaDescarga = New System.Windows.Forms.DateTimePicker()
        Me.TFechaCarga = New System.Windows.Forms.DateTimePicker()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TFOLIO_TEA = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.LtTractor = New System.Windows.Forms.Label()
        Me.BtnTEA = New C1.Win.C1Input.C1Button()
        Me.BtnTractor = New C1.Win.C1Input.C1Button()
        Me.LTConfigVehicular = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.TCVE_OPER = New System.Windows.Forms.TextBox()
        Me.LtUsoCFDI = New System.Windows.Forms.Label()
        Me.TCVE_TRACTOR = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LtRFC = New System.Windows.Forms.Label()
        Me.BtnOper = New C1.Win.C1Input.C1Button()
        Me.LaTractor = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.LtCliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.BtnConfigVehicular = New System.Windows.Forms.Button()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.CboTransInter = New C1.Win.C1Input.C1ComboBox()
        Me.LtCanc = New System.Windows.Forms.Label()
        Me.LtTimbrado = New System.Windows.Forms.Label()
        Me.BarraMENU.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM1.SuspendLayout()
        Me.Split1.SuspendLayout()
        CType(Me.TKMRecorridos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnTEA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnTractor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split2.SuspendLayout()
        CType(Me.CboTransInter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraMENU
        '
        Me.BarraMENU.AutoSize = False
        Me.BarraMENU.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.BarraMENU.ImageScalingSize = New System.Drawing.Size(12, 12)
        Me.BarraMENU.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarTimbrarCartaPorteTraslado, Me.BarImprimir, Me.BarExcel, Me.MnuCFD, Me.BarSalir})
        Me.BarraMENU.Location = New System.Drawing.Point(0, 0)
        Me.BarraMENU.Name = "BarraMENU"
        Me.BarraMENU.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.BarraMENU.Size = New System.Drawing.Size(1200, 60)
        Me.BarraMENU.Stretch = False
        Me.BarraMENU.TabIndex = 10
        Me.BarraMENU.Text = "MenuStrip1"
        '
        'BarTimbrarCartaPorteTraslado
        '
        Me.BarTimbrarCartaPorteTraslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarTimbrarCartaPorteTraslado.ForeColor = System.Drawing.Color.Black
        Me.BarTimbrarCartaPorteTraslado.Image = Global.SGT_Transport.My.Resources.Resources.cfdi20_e
        Me.BarTimbrarCartaPorteTraslado.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarTimbrarCartaPorteTraslado.Name = "BarTimbrarCartaPorteTraslado"
        Me.BarTimbrarCartaPorteTraslado.Padding = New System.Windows.Forms.Padding(4, 15, 4, 0)
        Me.BarTimbrarCartaPorteTraslado.ShortcutKeyDisplayString = "F3-Guardar"
        Me.BarTimbrarCartaPorteTraslado.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarTimbrarCartaPorteTraslado.Size = New System.Drawing.Size(54, 52)
        Me.BarTimbrarCartaPorteTraslado.Text = "Timbrar"
        Me.BarTimbrarCartaPorteTraslado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.BarImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.Size = New System.Drawing.Size(78, 52)
        Me.BarImprimir.Text = "Reimprimir"
        Me.BarImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarExcel
        '
        Me.BarExcel.Image = Global.SGT_Transport.My.Resources.Resources.excel1
        Me.BarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarExcel.Name = "BarExcel"
        Me.BarExcel.Size = New System.Drawing.Size(46, 52)
        Me.BarExcel.Text = "Excel"
        Me.BarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuCFD
        '
        Me.MnuCFD.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarSerie, Me.BarCancelar})
        Me.MnuCFD.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.MnuCFD.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuCFD.Name = "MnuCFD"
        Me.MnuCFD.Size = New System.Drawing.Size(78, 52)
        Me.MnuCFD.Text = "Opciones 1"
        Me.MnuCFD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSerie
        '
        Me.BarSerie.Image = Global.SGT_Transport.My.Resources.Resources.bin
        Me.BarSerie.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSerie.Name = "BarSerie"
        Me.BarSerie.Size = New System.Drawing.Size(136, 38)
        Me.BarSerie.Text = "Series"
        '
        'BarCancelar
        '
        Me.BarCancelar.Image = Global.SGT_Transport.My.Resources.Resources.X1
        Me.BarCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.Size = New System.Drawing.Size(136, 38)
        Me.BarCancelar.Text = "Cancelar"
        '
        'BarSalir
        '
        Me.BarSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarSalir.ForeColor = System.Drawing.Color.Black
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Padding = New System.Windows.Forms.Padding(4, 15, 4, 0)
        Me.BarSalir.Size = New System.Drawing.Size(44, 52)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.EditOptions = CType(((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(6, 32)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 300
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowCursor = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(792, 158)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 352
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'LtCVE_DOC
        '
        Me.LtCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCVE_DOC.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCVE_DOC.Location = New System.Drawing.Point(739, 25)
        Me.LtCVE_DOC.Name = "LtCVE_DOC"
        Me.LtCVE_DOC.Size = New System.Drawing.Size(169, 31)
        Me.LtCVE_DOC.TabIndex = 360
        Me.LtCVE_DOC.Text = "0000000009"
        Me.LtCVE_DOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(45, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 355
        Me.Label4.Text = "Sucursal origen"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(35, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 16)
        Me.Label6.TabIndex = 357
        Me.Label6.Text = "Sucursal  destino"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(530, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 354
        Me.Label1.Text = "Fecha"
        '
        'LtSucOrigen
        '
        Me.LtSucOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSucOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSucOrigen.Location = New System.Drawing.Point(148, 67)
        Me.LtSucOrigen.Name = "LtSucOrigen"
        Me.LtSucOrigen.Size = New System.Drawing.Size(303, 21)
        Me.LtSucOrigen.TabIndex = 356
        '
        'LtSucDestino
        '
        Me.LtSucDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSucDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtSucDestino.Location = New System.Drawing.Point(148, 94)
        Me.LtSucDestino.Name = "LtSucDestino"
        Me.LtSucDestino.Size = New System.Drawing.Size(303, 21)
        Me.LtSucDestino.TabIndex = 358
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Enabled = False
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(578, 12)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(114, 20)
        Me.F1.TabIndex = 353
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Ldocu
        '
        Me.Ldocu.AutoSize = True
        Me.Ldocu.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ldocu.Location = New System.Drawing.Point(775, 5)
        Me.Ldocu.Name = "Ldocu"
        Me.Ldocu.Size = New System.Drawing.Size(89, 17)
        Me.Ldocu.TabIndex = 359
        Me.Ldocu.Text = "Documento"
        '
        'SplitM1
        '
        Me.SplitM1.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SplitM1.BorderWidth = 1
        Me.SplitM1.CollapsingCueColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.SplitM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitM1.Location = New System.Drawing.Point(5, 68)
        Me.SplitM1.Name = "SplitM1"
        Me.SplitM1.Panels.Add(Me.Split1)
        Me.SplitM1.Panels.Add(Me.Split2)
        Me.SplitM1.Size = New System.Drawing.Size(1127, 430)
        Me.SplitM1.SplitterWidth = 1
        Me.SplitM1.TabIndex = 363
        Me.SplitM1.UseParentVisualStyle = False
        '
        'Split1
        '
        Me.Split1.Controls.Add(Me.LtTimbrado)
        Me.Split1.Controls.Add(Me.LtNpart)
        Me.Split1.Controls.Add(Me.TConfigVehicular)
        Me.Split1.Controls.Add(Me.TKMRecorridos)
        Me.Split1.Controls.Add(Me.TFechaDescarga)
        Me.Split1.Controls.Add(Me.TFechaCarga)
        Me.Split1.Controls.Add(Me.Label52)
        Me.Split1.Controls.Add(Me.Label51)
        Me.Split1.Controls.Add(Me.Label8)
        Me.Split1.Controls.Add(Me.TFOLIO_TEA)
        Me.Split1.Controls.Add(Me.Label46)
        Me.Split1.Controls.Add(Me.Label34)
        Me.Split1.Controls.Add(Me.LtTractor)
        Me.Split1.Controls.Add(Me.BtnTEA)
        Me.Split1.Controls.Add(Me.BtnTractor)
        Me.Split1.Controls.Add(Me.LTConfigVehicular)
        Me.Split1.Controls.Add(Me.Label5)
        Me.Split1.Controls.Add(Me.LtOper)
        Me.Split1.Controls.Add(Me.TCVE_OPER)
        Me.Split1.Controls.Add(Me.LtUsoCFDI)
        Me.Split1.Controls.Add(Me.TCVE_TRACTOR)
        Me.Split1.Controls.Add(Me.Label15)
        Me.Split1.Controls.Add(Me.Label7)
        Me.Split1.Controls.Add(Me.LtRFC)
        Me.Split1.Controls.Add(Me.BtnOper)
        Me.Split1.Controls.Add(Me.LaTractor)
        Me.Split1.Controls.Add(Me.LtNombre)
        Me.Split1.Controls.Add(Me.LtSucDestino)
        Me.Split1.Controls.Add(Me.LtCliente)
        Me.Split1.Controls.Add(Me.Label2)
        Me.Split1.Controls.Add(Me.LtCVE_DOC)
        Me.Split1.Controls.Add(Me.Ldocu)
        Me.Split1.Controls.Add(Me.Label4)
        Me.Split1.Controls.Add(Me.F1)
        Me.Split1.Controls.Add(Me.Label6)
        Me.Split1.Controls.Add(Me.LtSucOrigen)
        Me.Split1.Controls.Add(Me.Label1)
        Me.Split1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Split1.Height = 221
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1125, 221)
        Me.Split1.SizeRatio = 51.651R
        Me.Split1.TabIndex = 0
        '
        'LtNpart
        '
        Me.LtNpart.AutoSize = True
        Me.LtNpart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNpart.Location = New System.Drawing.Point(144, 182)
        Me.LtNpart.Name = "LtNpart"
        Me.LtNpart.Size = New System.Drawing.Size(15, 16)
        Me.LtNpart.TabIndex = 576
        Me.LtNpart.Text = "_"
        '
        'TConfigVehicular
        '
        Me.TConfigVehicular.Enabled = False
        Me.TConfigVehicular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TConfigVehicular.Location = New System.Drawing.Point(147, 121)
        Me.TConfigVehicular.Name = "TConfigVehicular"
        Me.TConfigVehicular.Size = New System.Drawing.Size(55, 22)
        Me.TConfigVehicular.TabIndex = 3
        '
        'TKMRecorridos
        '
        Me.TKMRecorridos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TKMRecorridos.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TKMRecorridos.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMRecorridos.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMRecorridos.DisplayFormat.CustomFormat = "###,###,##0.00"
        Me.TKMRecorridos.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMRecorridos.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMRecorridos.EditFormat.CustomFormat = "###,###,##0.00"
        Me.TKMRecorridos.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TKMRecorridos.EditFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TKMRecorridos.Enabled = False
        Me.TKMRecorridos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKMRecorridos.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.TKMRecorridos.InterceptArrowKeys = False
        Me.TKMRecorridos.Location = New System.Drawing.Point(147, 149)
        Me.TKMRecorridos.Name = "TKMRecorridos"
        Me.TKMRecorridos.Size = New System.Drawing.Size(92, 19)
        Me.TKMRecorridos.TabIndex = 5
        Me.TKMRecorridos.Tag = Nothing
        Me.TKMRecorridos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TKMRecorridos.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        Me.TKMRecorridos.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.TKMRecorridos.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TFechaDescarga
        '
        Me.TFechaDescarga.CalendarFont = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFechaDescarga.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TFechaDescarga.Enabled = False
        Me.TFechaDescarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFechaDescarga.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TFechaDescarga.Location = New System.Drawing.Point(863, 149)
        Me.TFechaDescarga.Name = "TFechaDescarga"
        Me.TFechaDescarga.Size = New System.Drawing.Size(152, 22)
        Me.TFechaDescarga.TabIndex = 7
        '
        'TFechaCarga
        '
        Me.TFechaCarga.CalendarFont = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFechaCarga.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.TFechaCarga.Enabled = False
        Me.TFechaCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFechaCarga.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TFechaCarga.Location = New System.Drawing.Point(578, 149)
        Me.TFechaCarga.Name = "TFechaCarga"
        Me.TFechaCarga.Size = New System.Drawing.Size(152, 22)
        Me.TFechaCarga.TabIndex = 6
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Enabled = False
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(736, 151)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(125, 16)
        Me.Label52.TabIndex = 570
        Me.Label52.Text = "Fecha de descarga"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(473, 151)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(102, 16)
        Me.Label51.TabIndex = 569
        Me.Label51.Text = "Fecha de carga"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 16)
        Me.Label8.TabIndex = 420
        Me.Label8.Text = "Seleccione folio TEA"
        '
        'TFOLIO_TEA
        '
        Me.TFOLIO_TEA.AcceptsReturn = True
        Me.TFOLIO_TEA.AcceptsTab = True
        Me.TFOLIO_TEA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFOLIO_TEA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFOLIO_TEA.Location = New System.Drawing.Point(148, 39)
        Me.TFOLIO_TEA.MaxLength = 10
        Me.TFOLIO_TEA.Name = "TFOLIO_TEA"
        Me.TFOLIO_TEA.Size = New System.Drawing.Size(116, 22)
        Me.TFOLIO_TEA.TabIndex = 0
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(6, 151)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(139, 16)
        Me.Label46.TabIndex = 568
        Me.Label46.Text = "*Kilometros recorridos"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(34, 124)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(110, 16)
        Me.Label34.TabIndex = 573
        Me.Label34.Text = "*Config. vehicular"
        '
        'LtTractor
        '
        Me.LtTractor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTractor.Location = New System.Drawing.Point(666, 94)
        Me.LtTractor.Name = "LtTractor"
        Me.LtTractor.Size = New System.Drawing.Size(215, 21)
        Me.LtTractor.TabIndex = 407
        Me.LtTractor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTEA
        '
        Me.BtnTEA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTEA.Image = CType(resources.GetObject("BtnTEA.Image"), System.Drawing.Image)
        Me.BtnTEA.Location = New System.Drawing.Point(265, 39)
        Me.BtnTEA.Name = "BtnTEA"
        Me.BtnTEA.Size = New System.Drawing.Size(24, 21)
        Me.BtnTEA.TabIndex = 421
        Me.BtnTEA.UseVisualStyleBackColor = True
        Me.BtnTEA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnTractor
        '
        Me.BtnTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTractor.Image = CType(resources.GetObject("BtnTractor.Image"), System.Drawing.Image)
        Me.BtnTractor.Location = New System.Drawing.Point(640, 94)
        Me.BtnTractor.Name = "BtnTractor"
        Me.BtnTractor.Size = New System.Drawing.Size(24, 21)
        Me.BtnTractor.TabIndex = 408
        Me.BtnTractor.UseVisualStyleBackColor = True
        Me.BtnTractor.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LTConfigVehicular
        '
        Me.LTConfigVehicular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTConfigVehicular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTConfigVehicular.Location = New System.Drawing.Point(203, 121)
        Me.LTConfigVehicular.Name = "LTConfigVehicular"
        Me.LTConfigVehicular.Size = New System.Drawing.Size(248, 21)
        Me.LTConfigVehicular.TabIndex = 575
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(510, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 417
        Me.Label5.Text = "Uso CFDI"
        '
        'LtOper
        '
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.Location = New System.Drawing.Point(640, 121)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(241, 21)
        Me.LtOper.TabIndex = 412
        Me.LtOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCVE_OPER
        '
        Me.TCVE_OPER.AcceptsReturn = True
        Me.TCVE_OPER.AcceptsTab = True
        Me.TCVE_OPER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_OPER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_OPER.Location = New System.Drawing.Point(578, 121)
        Me.TCVE_OPER.MaxLength = 10
        Me.TCVE_OPER.Name = "TCVE_OPER"
        Me.TCVE_OPER.Size = New System.Drawing.Size(35, 22)
        Me.TCVE_OPER.TabIndex = 2
        '
        'LtUsoCFDI
        '
        Me.LtUsoCFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUsoCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUsoCFDI.Location = New System.Drawing.Point(578, 68)
        Me.LtUsoCFDI.Name = "LtUsoCFDI"
        Me.LtUsoCFDI.Size = New System.Drawing.Size(49, 20)
        Me.LtUsoCFDI.TabIndex = 418
        Me.LtUsoCFDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TCVE_TRACTOR
        '
        Me.TCVE_TRACTOR.AcceptsReturn = True
        Me.TCVE_TRACTOR.AcceptsTab = True
        Me.TCVE_TRACTOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_TRACTOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_TRACTOR.Location = New System.Drawing.Point(578, 94)
        Me.TCVE_TRACTOR.MaxLength = 10
        Me.TCVE_TRACTOR.Name = "TCVE_TRACTOR"
        Me.TCVE_TRACTOR.Size = New System.Drawing.Size(60, 22)
        Me.TCVE_TRACTOR.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(510, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 16)
        Me.Label15.TabIndex = 410
        Me.Label15.Text = "Operador"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(532, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 16)
        Me.Label7.TabIndex = 415
        Me.Label7.Text = "R.F.C."
        '
        'LtRFC
        '
        Me.LtRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRFC.Location = New System.Drawing.Point(578, 39)
        Me.LtRFC.Name = "LtRFC"
        Me.LtRFC.Size = New System.Drawing.Size(127, 20)
        Me.LtRFC.TabIndex = 416
        '
        'BtnOper
        '
        Me.BtnOper.FlatAppearance.BorderSize = 0
        Me.BtnOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOper.Image = CType(resources.GetObject("BtnOper.Image"), System.Drawing.Image)
        Me.BtnOper.Location = New System.Drawing.Point(614, 121)
        Me.BtnOper.Name = "BtnOper"
        Me.BtnOper.Size = New System.Drawing.Size(24, 22)
        Me.BtnOper.TabIndex = 411
        Me.BtnOper.UseVisualStyleBackColor = True
        Me.BtnOper.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LaTractor
        '
        Me.LaTractor.AutoSize = True
        Me.LaTractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaTractor.Location = New System.Drawing.Point(524, 101)
        Me.LaTractor.Name = "LaTractor"
        Me.LaTractor.Size = New System.Drawing.Size(51, 16)
        Me.LaTractor.TabIndex = 406
        Me.LaTractor.Text = "Unidad"
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(200, 12)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(251, 21)
        Me.LtNombre.TabIndex = 414
        '
        'LtCliente
        '
        Me.LtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCliente.Location = New System.Drawing.Point(148, 12)
        Me.LtCliente.Name = "LtCliente"
        Me.LtCliente.Size = New System.Drawing.Size(50, 21)
        Me.LtCliente.TabIndex = 362
        Me.LtCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(97, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 361
        Me.Label2.Text = "Cliente"
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 206
        Me.Split2.Location = New System.Drawing.Point(1, 223)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1125, 206)
        Me.Split2.TabIndex = 363
        '
        'BtnConfigVehicular
        '
        Me.BtnConfigVehicular.FlatAppearance.BorderSize = 0
        Me.BtnConfigVehicular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConfigVehicular.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfigVehicular.Image = Global.SGT_Transport.My.Resources.Resources.lupa15
        Me.BtnConfigVehicular.Location = New System.Drawing.Point(1066, 127)
        Me.BtnConfigVehicular.Name = "BtnConfigVehicular"
        Me.BtnConfigVehicular.Size = New System.Drawing.Size(23, 23)
        Me.BtnConfigVehicular.TabIndex = 574
        Me.BtnConfigVehicular.UseVisualStyleBackColor = True
        Me.BtnConfigVehicular.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(980, 82)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(152, 16)
        Me.Label41.TabIndex = 567
        Me.Label41.Text = "Transporte internacional"
        Me.Label41.Visible = False
        '
        'CboTransInter
        '
        Me.CboTransInter.AllowSpinLoop = False
        Me.CboTransInter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboTransInter.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboTransInter.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboTransInter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTransInter.GapHeight = 0
        Me.CboTransInter.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboTransInter.ItemsDisplayMember = ""
        Me.CboTransInter.ItemsValueMember = ""
        Me.CboTransInter.Location = New System.Drawing.Point(1029, 101)
        Me.CboTransInter.Name = "CboTransInter"
        Me.CboTransInter.Size = New System.Drawing.Size(60, 20)
        Me.CboTransInter.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboTransInter.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboTransInter.TabIndex = 4
        Me.CboTransInter.Tag = Nothing
        Me.CboTransInter.Visible = False
        Me.CboTransInter.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboTransInter.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtCanc
        '
        Me.LtCanc.AutoSize = True
        Me.LtCanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCanc.Location = New System.Drawing.Point(479, 30)
        Me.LtCanc.Name = "LtCanc"
        Me.LtCanc.Size = New System.Drawing.Size(0, 17)
        Me.LtCanc.TabIndex = 576
        '
        'LtTimbrado
        '
        Me.LtTimbrado.AutoSize = True
        Me.LtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTimbrado.Location = New System.Drawing.Point(898, 96)
        Me.LtTimbrado.Name = "LtTimbrado"
        Me.LtTimbrado.Size = New System.Drawing.Size(17, 17)
        Me.LtTimbrado.TabIndex = 577
        Me.LtTimbrado.Text = "_"
        '
        'FrmCartaPorteTrasladoAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 531)
        Me.Controls.Add(Me.LtCanc)
        Me.Controls.Add(Me.SplitM1)
        Me.Controls.Add(Me.BarraMENU)
        Me.Controls.Add(Me.CboTransInter)
        Me.Controls.Add(Me.BtnConfigVehicular)
        Me.Controls.Add(Me.Label41)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCartaPorteTrasladoAE"
        Me.Text = "Carta porte traslado"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarraMENU.ResumeLayout(False)
        Me.BarraMENU.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM1.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        CType(Me.TKMRecorridos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnTEA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnTractor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split2.ResumeLayout(False)
        CType(Me.CboTransInter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraMENU As MenuStrip
    Friend WithEvents BarTimbrarCartaPorteTraslado As ToolStripMenuItem
    Friend WithEvents BarImprimir As ToolStripMenuItem
    Friend WithEvents MnuCFD As ToolStripMenuItem
    Friend WithEvents BarSerie As ToolStripMenuItem
    Friend WithEvents BarCancelar As ToolStripMenuItem
    Friend WithEvents BarSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtCVE_DOC As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LtSucOrigen As Label
    Friend WithEvents LtSucDestino As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Ldocu As Label
    Friend WithEvents SplitM1 As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents LaTractor As Label
    Friend WithEvents TCVE_TRACTOR As TextBox
    Friend WithEvents LtTractor As Label
    Friend WithEvents BtnTractor As C1.Win.C1Input.C1Button
    Friend WithEvents BtnOper As C1.Win.C1Input.C1Button
    Friend WithEvents Label15 As Label
    Friend WithEvents TCVE_OPER As TextBox
    Friend WithEvents LtOper As Label
    Friend WithEvents LtCliente As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LtRFC As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LtUsoCFDI As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TFOLIO_TEA As TextBox
    Friend WithEvents BtnTEA As C1.Win.C1Input.C1Button
    Private WithEvents TFechaDescarga As DateTimePicker
    Private WithEvents TFechaCarga As DateTimePicker
    Friend WithEvents Label52 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents CboTransInter As C1.Win.C1Input.C1ComboBox
    Friend WithEvents TKMRecorridos As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents TConfigVehicular As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents LTConfigVehicular As Label
    Private WithEvents BtnConfigVehicular As Button
    Friend WithEvents LtCanc As Label
    Friend WithEvents BarExcel As ToolStripMenuItem
    Friend WithEvents LtNpart As Label
    Friend WithEvents LtTimbrado As Label
End Class
