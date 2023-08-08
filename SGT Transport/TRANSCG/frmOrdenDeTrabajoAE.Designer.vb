<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrdenDeTrabajoAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenDeTrabajoAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barFinalizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barReimpresion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.LtTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAltaServicio = New C1.Win.C1Input.C1Button()
        Me.btnEliSer = New C1.Win.C1Input.C1Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.btnAltaMecanico = New C1.Win.C1Input.C1Button()
        Me.btnEliMec = New C1.Win.C1Input.C1Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.FgM = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Pag3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.tOBSER = New System.Windows.Forms.TextBox()
        Me.Pag4 = New C1.Win.C1Command.C1DockingTabPage()
        Me.btnAltaFalla = New C1.Win.C1Input.C1Button()
        Me.btnEliFallas = New C1.Win.C1Input.C1Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.FgF = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.radExtra = New System.Windows.Forms.RadioButton()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radCorrectivo = New System.Windows.Forms.RadioButton()
        Me.radPreventivo = New System.Windows.Forms.RadioButton()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.btnServicios = New C1.Win.C1Input.C1Button()
        Me.tCVE_SER = New System.Windows.Forms.TextBox()
        Me.Lt = New System.Windows.Forms.Label()
        Me.tCVE_ORD = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.btnOperador = New C1.Win.C1Input.C1Button()
        Me.tCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.L4 = New System.Windows.Forms.Label()
        Me.btnTipo = New C1.Win.C1Input.C1Button()
        Me.tEstatus = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tCVE_TIPO = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.btnUnidades = New C1.Win.C1Input.C1Button()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.tNOTA = New System.Windows.Forms.TextBox()
        Me.tLUGAR_REP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.tMagico = New System.Windows.Forms.TextBox()
        Me.barSalir.SuspendLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        CType(Me.btnAltaServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliSer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag2.SuspendLayout()
        CType(Me.btnAltaMecanico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliMec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FgM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag3.SuspendLayout()
        Me.Pag4.SuspendLayout()
        CType(Me.btnAltaFalla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliFallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FgF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.btnOperador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.barFinalizar, Me.barReimpresion, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Padding = New System.Windows.Forms.Padding(2)
        Me.barSalir.Size = New System.Drawing.Size(1185, 37)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 0
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.White
        Me.barGrabar.Image = CType(resources.GetObject("barGrabar.Image"), System.Drawing.Image)
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.Padding = New System.Windows.Forms.Padding(0)
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(46, 33)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barFinalizar
        '
        Me.barFinalizar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barFinalizar.ForeColor = System.Drawing.Color.White
        Me.barFinalizar.Image = Global.SGT_Transport.My.Resources.Resources.ok
        Me.barFinalizar.Name = "barFinalizar"
        Me.barFinalizar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barFinalizar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barFinalizar.Size = New System.Drawing.Size(62, 33)
        Me.barFinalizar.Text = "Finalizar"
        Me.barFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barReimpresion
        '
        Me.barReimpresion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.barReimpresion.ForeColor = System.Drawing.Color.White
        Me.barReimpresion.Image = Global.SGT_Transport.My.Resources.Resources.Printer
        Me.barReimpresion.Name = "barReimpresion"
        Me.barReimpresion.ShortcutKeyDisplayString = "Grabar registro"
        Me.barReimpresion.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barReimpresion.Size = New System.Drawing.Size(83, 33)
        Me.barReimpresion.Text = "Reimpresión"
        Me.barReimpresion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.White
        Me.mnuSalir.Image = CType(resources.GetObject("mnuSalir.Image"), System.Drawing.Image)
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(41, 33)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Pag1)
        Me.Tab1.Controls.Add(Me.Pag2)
        Me.Tab1.Controls.Add(Me.Pag3)
        Me.Tab1.Controls.Add(Me.Pag4)
        Me.Tab1.Location = New System.Drawing.Point(5, 198)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedTabBold = True
        Me.Tab1.Size = New System.Drawing.Size(1150, 353)
        Me.Tab1.TabIndex = 0
        Me.Tab1.TabsSpacing = 5
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.LtTotal)
        Me.Pag1.Controls.Add(Me.Label3)
        Me.Pag1.Controls.Add(Me.btnAltaServicio)
        Me.Pag1.Controls.Add(Me.btnEliSer)
        Me.Pag1.Controls.Add(Me.Label13)
        Me.Pag1.Controls.Add(Me.Fg)
        Me.Pag1.Location = New System.Drawing.Point(1, 24)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(1148, 328)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Servicios"
        '
        'LtTotal
        '
        Me.LtTotal.BackColor = System.Drawing.Color.Transparent
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotal.Location = New System.Drawing.Point(887, 266)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(148, 20)
        Me.LtTotal.TabIndex = 146
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(830, 270)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "Importe"
        '
        'btnAltaServicio
        '
        Me.btnAltaServicio.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.btnAltaServicio.Location = New System.Drawing.Point(799, 5)
        Me.btnAltaServicio.Name = "btnAltaServicio"
        Me.btnAltaServicio.Size = New System.Drawing.Size(23, 22)
        Me.btnAltaServicio.TabIndex = 1
        Me.btnAltaServicio.UseVisualStyleBackColor = True
        Me.btnAltaServicio.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.btnAltaServicio.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnEliSer
        '
        Me.btnEliSer.Image = Global.SGT_Transport.My.Resources.Resources.doceliminar16
        Me.btnEliSer.Location = New System.Drawing.Point(863, 5)
        Me.btnEliSer.Name = "btnEliSer"
        Me.btnEliSer.Size = New System.Drawing.Size(28, 24)
        Me.btnEliSer.TabIndex = 2
        Me.btnEliSer.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(291, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 17)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "Servicios"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.CellButtonImage = Global.SGT_Transport.My.Resources.Resources.lupu2
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(6, 35)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.Size = New System.Drawing.Size(1155, 225)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 0
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Pag2
        '
        Me.Pag2.Controls.Add(Me.btnAltaMecanico)
        Me.Pag2.Controls.Add(Me.btnEliMec)
        Me.Pag2.Controls.Add(Me.Label14)
        Me.Pag2.Controls.Add(Me.FgM)
        Me.Pag2.Location = New System.Drawing.Point(1, 24)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(1148, 328)
        Me.Pag2.TabIndex = 1
        Me.Pag2.Text = "Mecánicos/Ayudantes"
        '
        'btnAltaMecanico
        '
        Me.btnAltaServicio.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.btnAltaMecanico.Location = New System.Drawing.Point(699, 8)
        Me.btnAltaMecanico.Name = "btnAltaMecanico"
        Me.btnAltaMecanico.Size = New System.Drawing.Size(32, 33)
        Me.btnAltaMecanico.TabIndex = 1
        Me.btnAltaMecanico.UseVisualStyleBackColor = True
        Me.btnAltaMecanico.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.btnAltaMecanico.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnEliMec
        '
        Me.btnEliMec.Image = CType(resources.GetObject("btnEliMec.Image"), System.Drawing.Image)
        Me.btnEliMec.Location = New System.Drawing.Point(767, 11)
        Me.btnEliMec.Name = "btnEliMec"
        Me.btnEliMec.Size = New System.Drawing.Size(35, 27)
        Me.btnEliMec.TabIndex = 2
        Me.btnEliMec.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(302, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 17)
        Me.Label14.TabIndex = 131
        Me.Label14.Text = "MECANICOS"
        '
        'FgM
        '
        Me.FgM.BackColor = System.Drawing.Color.White
        Me.FgM.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgM.ColumnInfo = "4,1,0,0,0,95,Columns:1{Width:105;Caption:""Clave"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:45;Caption:""..."";ShowB" &
    "uttons:Always;Style:""ComboList:""""..."""";"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{Width:516;Caption:""Nombre"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.FgM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FgM.ForeColor = System.Drawing.Color.Black
        Me.FgM.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgM.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgM.Location = New System.Drawing.Point(4, 47)
        Me.FgM.Name = "FgM"
        Me.FgM.PreserveEditMode = True
        Me.FgM.Rows.Count = 1
        Me.FgM.Rows.DefaultSize = 19
        Me.FgM.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.FgM.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.FgM.Size = New System.Drawing.Size(798, 221)
        Me.FgM.StyleInfo = resources.GetString("FgM.StyleInfo")
        Me.FgM.TabIndex = 3
        Me.FgM.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Pag3
        '
        Me.Pag3.Controls.Add(Me.tOBSER)
        Me.Pag3.Location = New System.Drawing.Point(1, 24)
        Me.Pag3.Name = "Pag3"
        Me.Pag3.Size = New System.Drawing.Size(1148, 328)
        Me.Pag3.TabIndex = 2
        Me.Pag3.Text = "Observaciones"
        '
        'tOBSER
        '
        Me.tOBSER.AcceptsReturn = True
        Me.tOBSER.AcceptsTab = True
        Me.tOBSER.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tOBSER.Location = New System.Drawing.Point(24, 27)
        Me.tOBSER.Multiline = True
        Me.tOBSER.Name = "tOBSER"
        Me.tOBSER.Size = New System.Drawing.Size(695, 134)
        Me.tOBSER.TabIndex = 0
        '
        'Pag4
        '
        Me.Pag4.Controls.Add(Me.btnAltaFalla)
        Me.Pag4.Controls.Add(Me.btnEliFallas)
        Me.Pag4.Controls.Add(Me.Label15)
        Me.Pag4.Controls.Add(Me.FgF)
        Me.Pag4.Location = New System.Drawing.Point(1, 24)
        Me.Pag4.Name = "Pag4"
        Me.Pag4.Size = New System.Drawing.Size(1148, 328)
        Me.Pag4.TabIndex = 3
        Me.Pag4.Text = "Reporte de fallas"
        '
        'btnAltaFalla
        '
        Me.btnAltaFalla.Image = Global.SGT_Transport.My.Resources.Resources.add
        Me.btnAltaFalla.Location = New System.Drawing.Point(778, 11)
        Me.btnAltaFalla.Name = "btnAltaFalla"
        Me.btnAltaFalla.Size = New System.Drawing.Size(32, 33)
        Me.btnAltaFalla.TabIndex = 1
        Me.btnAltaFalla.UseVisualStyleBackColor = True
        Me.btnAltaFalla.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.btnAltaFalla.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'btnEliFallas
        '
        Me.btnEliFallas.Image = CType(resources.GetObject("btnEliFallas.Image"), System.Drawing.Image)
        Me.btnEliFallas.Location = New System.Drawing.Point(841, 11)
        Me.btnEliFallas.Name = "btnEliFallas"
        Me.btnEliFallas.Size = New System.Drawing.Size(35, 27)
        Me.btnEliFallas.TabIndex = 2
        Me.btnEliFallas.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(302, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(170, 17)
        Me.Label15.TabIndex = 131
        Me.Label15.Text = "REPORTE DE FALLAS"
        '
        'FgF
        '
        Me.FgF.BackColor = System.Drawing.Color.White
        Me.FgF.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgF.ColumnInfo = resources.GetString("FgF.ColumnInfo")
        Me.FgF.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FgF.ForeColor = System.Drawing.Color.Black
        Me.FgF.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgF.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgF.Location = New System.Drawing.Point(4, 47)
        Me.FgF.Name = "FgF"
        Me.FgF.PreserveEditMode = True
        Me.FgF.Rows.Count = 1
        Me.FgF.Rows.DefaultSize = 19
        Me.FgF.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgF.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.FgF.Size = New System.Drawing.Size(905, 221)
        Me.FgF.StyleInfo = resources.GetString("FgF.StyleInfo")
        Me.FgF.TabIndex = 0
        Me.FgF.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.radExtra)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.radCorrectivo)
        Me.Panel1.Controls.Add(Me.radPreventivo)
        Me.Panel1.Controls.Add(Me.Label90)
        Me.Panel1.Controls.Add(Me.L1)
        Me.Panel1.Controls.Add(Me.btnServicios)
        Me.Panel1.Controls.Add(Me.tCVE_SER)
        Me.Panel1.Controls.Add(Me.Lt)
        Me.Panel1.Controls.Add(Me.tCVE_ORD)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Location = New System.Drawing.Point(5, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(361, 147)
        Me.Panel1.TabIndex = 28
        '
        'radExtra
        '
        Me.radExtra.AutoSize = True
        Me.radExtra.Location = New System.Drawing.Point(244, 123)
        Me.radExtra.Name = "radExtra"
        Me.radExtra.Size = New System.Drawing.Size(89, 17)
        Me.radExtra.TabIndex = 5
        Me.radExtra.TabStop = True
        Me.radExtra.Text = "Extraordinario"
        Me.radExtra.UseVisualStyleBackColor = True
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(201, 13)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(132, 20)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-1, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(361, 18)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Tipo de servicio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'radCorrectivo
        '
        Me.radCorrectivo.AutoSize = True
        Me.radCorrectivo.Location = New System.Drawing.Point(127, 123)
        Me.radCorrectivo.Name = "radCorrectivo"
        Me.radCorrectivo.Size = New System.Drawing.Size(73, 17)
        Me.radCorrectivo.TabIndex = 4
        Me.radCorrectivo.TabStop = True
        Me.radCorrectivo.Text = "Correctivo"
        Me.radCorrectivo.UseVisualStyleBackColor = True
        '
        'radPreventivo
        '
        Me.radPreventivo.AutoSize = True
        Me.radPreventivo.Location = New System.Drawing.Point(11, 123)
        Me.radPreventivo.Name = "radPreventivo"
        Me.radPreventivo.Size = New System.Drawing.Size(76, 17)
        Me.radPreventivo.TabIndex = 3
        Me.radPreventivo.TabStop = True
        Me.radPreventivo.Text = "Preventivo"
        Me.radPreventivo.UseVisualStyleBackColor = True
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.Location = New System.Drawing.Point(159, 15)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(37, 13)
        Me.Label90.TabIndex = 153
        Me.Label90.Text = "Fecha"
        '
        'L1
        '
        Me.L1.BackColor = System.Drawing.Color.Transparent
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(2, 77)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(354, 20)
        Me.L1.TabIndex = 152
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnServicios
        '
        Me.btnServicios.ForeColor = System.Drawing.Color.Black
        Me.btnServicios.Image = CType(resources.GetObject("btnServicios.Image"), System.Drawing.Image)
        Me.btnServicios.Location = New System.Drawing.Point(256, 46)
        Me.btnServicios.Name = "btnServicios"
        Me.btnServicios.Size = New System.Drawing.Size(26, 20)
        Me.btnServicios.TabIndex = 151
        Me.btnServicios.UseVisualStyleBackColor = True
        Me.btnServicios.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCVE_SER
        '
        Me.tCVE_SER.AcceptsReturn = True
        Me.tCVE_SER.AcceptsTab = True
        Me.tCVE_SER.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_SER.Location = New System.Drawing.Point(180, 44)
        Me.tCVE_SER.Name = "tCVE_SER"
        Me.tCVE_SER.Size = New System.Drawing.Size(71, 24)
        Me.tCVE_SER.TabIndex = 2
        '
        'Lt
        '
        Me.Lt.AutoSize = True
        Me.Lt.BackColor = System.Drawing.Color.Transparent
        Me.Lt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt.Location = New System.Drawing.Point(15, 47)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(158, 15)
        Me.Lt.TabIndex = 150
        Me.Lt.Text = "Actividad de mantenimiento"
        '
        'tCVE_ORD
        '
        Me.tCVE_ORD.AcceptsReturn = True
        Me.tCVE_ORD.AcceptsTab = True
        Me.tCVE_ORD.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_ORD.Location = New System.Drawing.Point(53, 12)
        Me.tCVE_ORD.Name = "tCVE_ORD"
        Me.tCVE_ORD.Size = New System.Drawing.Size(81, 24)
        Me.tCVE_ORD.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(7, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 17)
        Me.Label27.TabIndex = 149
        Me.Label27.Text = "Folio"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LtOper)
        Me.Panel2.Controls.Add(Me.btnOperador)
        Me.Panel2.Controls.Add(Me.tCVE_OPER)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.L4)
        Me.Panel2.Controls.Add(Me.btnTipo)
        Me.Panel2.Controls.Add(Me.tEstatus)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.tCVE_TIPO)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.L2)
        Me.Panel2.Controls.Add(Me.btnUnidades)
        Me.Panel2.Controls.Add(Me.tCVE_UNI)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(364, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(571, 78)
        Me.Panel2.TabIndex = 29
        '
        'LtOper
        '
        Me.LtOper.BackColor = System.Drawing.Color.Transparent
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.Location = New System.Drawing.Point(147, 53)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(254, 20)
        Me.LtOper.TabIndex = 144
        Me.LtOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOperador
        '
        Me.btnOperador.Image = CType(resources.GetObject("btnOperador.Image"), System.Drawing.Image)
        Me.btnOperador.Location = New System.Drawing.Point(119, 53)
        Me.btnOperador.Name = "btnOperador"
        Me.btnOperador.Size = New System.Drawing.Size(26, 20)
        Me.btnOperador.TabIndex = 143
        Me.btnOperador.UseVisualStyleBackColor = True
        Me.btnOperador.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnOperador.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCVE_OPER
        '
        Me.tCVE_OPER.AcceptsReturn = True
        Me.tCVE_OPER.AcceptsTab = True
        Me.tCVE_OPER.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_OPER.Location = New System.Drawing.Point(59, 53)
        Me.tCVE_OPER.Name = "tCVE_OPER"
        Me.tCVE_OPER.Size = New System.Drawing.Size(60, 20)
        Me.tCVE_OPER.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(6, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 142
        Me.Label16.Text = "Operador"
        '
        'L4
        '
        Me.L4.BackColor = System.Drawing.Color.Transparent
        Me.L4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L4.Location = New System.Drawing.Point(147, 28)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(254, 20)
        Me.L4.TabIndex = 140
        Me.L4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTipo
        '
        Me.btnTipo.Image = CType(resources.GetObject("btnTipo.Image"), System.Drawing.Image)
        Me.btnTipo.Location = New System.Drawing.Point(119, 28)
        Me.btnTipo.Name = "btnTipo"
        Me.btnTipo.Size = New System.Drawing.Size(26, 20)
        Me.btnTipo.TabIndex = 139
        Me.btnTipo.UseVisualStyleBackColor = True
        Me.btnTipo.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnTipo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tEstatus
        '
        Me.tEstatus.AcceptsReturn = True
        Me.tEstatus.AcceptsTab = True
        Me.tEstatus.Enabled = False
        Me.tEstatus.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEstatus.Location = New System.Drawing.Point(407, 53)
        Me.tEstatus.Name = "tEstatus"
        Me.tEstatus.Size = New System.Drawing.Size(159, 20)
        Me.tEstatus.TabIndex = 3
        Me.tEstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(459, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 138
        Me.Label11.Text = "Estatus"
        '
        'tCVE_TIPO
        '
        Me.tCVE_TIPO.AcceptsReturn = True
        Me.tCVE_TIPO.AcceptsTab = True
        Me.tCVE_TIPO.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TIPO.Location = New System.Drawing.Point(59, 28)
        Me.tCVE_TIPO.Name = "tCVE_TIPO"
        Me.tCVE_TIPO.Size = New System.Drawing.Size(60, 20)
        Me.tCVE_TIPO.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(29, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "Tipo"
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.Transparent
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(147, 3)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(254, 20)
        Me.L2.TabIndex = 131
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnUnidades
        '
        Me.btnUnidades.Image = CType(resources.GetObject("btnUnidades.Image"), System.Drawing.Image)
        Me.btnUnidades.Location = New System.Drawing.Point(119, 3)
        Me.btnUnidades.Name = "btnUnidades"
        Me.btnUnidades.Size = New System.Drawing.Size(26, 20)
        Me.btnUnidades.TabIndex = 130
        Me.btnUnidades.UseVisualStyleBackColor = True
        Me.btnUnidades.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.btnUnidades.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.Location = New System.Drawing.Point(59, 3)
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(60, 20)
        Me.tCVE_UNI.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(16, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Unidad"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.tNOTA)
        Me.Panel4.Controls.Add(Me.tLUGAR_REP)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Location = New System.Drawing.Point(364, 117)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(571, 70)
        Me.Panel4.TabIndex = 31
        '
        'tNOTA
        '
        Me.tNOTA.AcceptsReturn = True
        Me.tNOTA.AcceptsTab = True
        Me.tNOTA.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNOTA.Location = New System.Drawing.Point(109, 37)
        Me.tNOTA.Name = "tNOTA"
        Me.tNOTA.Size = New System.Drawing.Size(218, 20)
        Me.tNOTA.TabIndex = 1
        '
        'tLUGAR_REP
        '
        Me.tLUGAR_REP.AcceptsReturn = True
        Me.tLUGAR_REP.AcceptsTab = True
        Me.tLUGAR_REP.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLUGAR_REP.Location = New System.Drawing.Point(109, 15)
        Me.tLUGAR_REP.Name = "tLUGAR_REP"
        Me.tLUGAR_REP.Size = New System.Drawing.Size(457, 20)
        Me.tLUGAR_REP.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(79, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 142
        Me.Label10.Text = "Nota"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(7, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 13)
        Me.Label12.TabIndex = 140
        Me.Label12.Text = "Lugar de reparacion"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "e8a622778c0743709003952334aafb09"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.VB
        Me.StiReport1.UseProgressInThread = False
        '
        'tMagico
        '
        Me.tMagico.Location = New System.Drawing.Point(869, 299)
        Me.tMagico.Name = "tMagico"
        Me.tMagico.Size = New System.Drawing.Size(100, 20)
        Me.tMagico.TabIndex = 32
        '
        'frmOrdenDeTrabajoAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1185, 560)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.barSalir)
        Me.Controls.Add(Me.tMagico)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrdenDeTrabajoAE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de Trabajo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        Me.Pag1.PerformLayout()
        CType(Me.btnAltaServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliSer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag2.ResumeLayout(False)
        Me.Pag2.PerformLayout()
        CType(Me.btnAltaMecanico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliMec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FgM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag3.ResumeLayout(False)
        Me.Pag3.PerformLayout()
        Me.Pag4.ResumeLayout(False)
        Me.Pag4.PerformLayout()
        CType(Me.btnAltaFalla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliFallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FgF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.btnOperador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label90 As Label
    Friend WithEvents L1 As Label
    Friend WithEvents btnServicios As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_SER As TextBox
    Friend WithEvents Lt As Label
    Friend WithEvents tCVE_ORD As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents radCorrectivo As RadioButton
    Friend WithEvents radPreventivo As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents L2 As Label
    Friend WithEvents btnUnidades As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tEstatus As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents tCVE_TIPO As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents tNOTA As TextBox
    Friend WithEvents tLUGAR_REP As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag4 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents FgM As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents tOBSER As TextBox
    Friend WithEvents FgF As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents L4 As Label
    Friend WithEvents btnTipo As C1.Win.C1Input.C1Button
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents btnEliSer As C1.Win.C1Input.C1Button
    Friend WithEvents btnEliMec As C1.Win.C1Input.C1Button
    Friend WithEvents btnEliFallas As C1.Win.C1Input.C1Button
    Friend WithEvents barReimpresion As ToolStripMenuItem
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents radExtra As RadioButton
    Friend WithEvents LtOper As Label
    Friend WithEvents btnOperador As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_OPER As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents barFinalizar As ToolStripMenuItem
    Friend WithEvents btnAltaServicio As C1.Win.C1Input.C1Button
    Friend WithEvents btnAltaMecanico As C1.Win.C1Input.C1Button
    Friend WithEvents btnAltaFalla As C1.Win.C1Input.C1Button
    Friend WithEvents tMagico As TextBox
    Friend WithEvents LtTotal As Label
    Friend WithEvents Label3 As Label
End Class
