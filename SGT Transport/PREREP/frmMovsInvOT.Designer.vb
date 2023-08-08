<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMovsInvOT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovsInvOT))
        Me.tNOTA = New System.Windows.Forms.TextBox()
        Me.tLUGAR_REP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.L3 = New System.Windows.Forms.Label()
        Me.btnProv = New C1.Win.C1Input.C1Button()
        Me.tCVE_PROV = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnProgServ = New C1.Win.C1Input.C1Button()
        Me.LtOper = New System.Windows.Forms.Label()
        Me.tCVE_OPER = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.L4 = New System.Windows.Forms.Label()
        Me.tEstatus = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tCVE_TIPO = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.radExtra = New System.Windows.Forms.RadioButton()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radCorrectivo = New System.Windows.Forms.RadioButton()
        Me.radPreventivo = New System.Windows.Forms.RadioButton()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.tCVE_ORD = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.LtTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.tOBSER = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.barReimpresion = New System.Windows.Forms.ToolStripMenuItem()
        Me.barKardex = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.Panel2.SuspendLayout()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProgServ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTabPage1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tNOTA
        '
        Me.tNOTA.AcceptsReturn = True
        Me.tNOTA.AcceptsTab = True
        Me.tNOTA.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNOTA.Location = New System.Drawing.Point(563, 120)
        Me.tNOTA.Name = "tNOTA"
        Me.tNOTA.Size = New System.Drawing.Size(133, 20)
        Me.tNOTA.TabIndex = 1
        '
        'tLUGAR_REP
        '
        Me.tLUGAR_REP.AcceptsReturn = True
        Me.tLUGAR_REP.AcceptsTab = True
        Me.tLUGAR_REP.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLUGAR_REP.Location = New System.Drawing.Point(108, 120)
        Me.tLUGAR_REP.Name = "tLUGAR_REP"
        Me.tLUGAR_REP.Size = New System.Drawing.Size(419, 20)
        Me.tLUGAR_REP.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(533, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 142
        Me.Label10.Text = "Nota"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 13)
        Me.Label12.TabIndex = 140
        Me.Label12.Text = "Lugar de reparacion"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.L3)
        Me.Panel2.Controls.Add(Me.btnProv)
        Me.Panel2.Controls.Add(Me.tCVE_PROV)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.tNOTA)
        Me.Panel2.Controls.Add(Me.btnProgServ)
        Me.Panel2.Controls.Add(Me.tLUGAR_REP)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.LtOper)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.tCVE_OPER)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.L4)
        Me.Panel2.Controls.Add(Me.tEstatus)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.tCVE_TIPO)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.L2)
        Me.Panel2.Controls.Add(Me.tCVE_UNI)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(363, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(762, 147)
        Me.Panel2.TabIndex = 33
        '
        'L3
        '
        Me.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.Location = New System.Drawing.Point(142, 79)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(234, 22)
        Me.L3.TabIndex = 149
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnProv
        '
        Me.btnProv.Image = CType(resources.GetObject("btnProv.Image"), System.Drawing.Image)
        Me.btnProv.Location = New System.Drawing.Point(114, 79)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(26, 20)
        Me.btnProv.TabIndex = 148
        Me.btnProv.UseVisualStyleBackColor = True
        Me.btnProv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tCVE_PROV
        '
        Me.tCVE_PROV.AcceptsReturn = True
        Me.tCVE_PROV.AcceptsTab = True
        Me.tCVE_PROV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_PROV.Location = New System.Drawing.Point(59, 79)
        Me.tCVE_PROV.Name = "tCVE_PROV"
        Me.tCVE_PROV.Size = New System.Drawing.Size(54, 22)
        Me.tCVE_PROV.TabIndex = 146
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "Cliente"
        '
        'btnProgServ
        '
        Me.btnProgServ.Location = New System.Drawing.Point(382, 3)
        Me.btnProgServ.Name = "btnProgServ"
        Me.btnProgServ.Size = New System.Drawing.Size(26, 20)
        Me.btnProgServ.TabIndex = 145
        Me.btnProgServ.Text = "....."
        Me.btnProgServ.UseVisualStyleBackColor = True
        Me.btnProgServ.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtOper
        '
        Me.LtOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtOper.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtOper.Location = New System.Drawing.Point(122, 53)
        Me.LtOper.Name = "LtOper"
        Me.LtOper.Size = New System.Drawing.Size(254, 20)
        Me.LtOper.TabIndex = 144
        Me.LtOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Label16.Location = New System.Drawing.Point(6, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 142
        Me.Label16.Text = "Operador"
        '
        'L4
        '
        Me.L4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L4.Location = New System.Drawing.Point(122, 28)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(254, 20)
        Me.L4.TabIndex = 140
        Me.L4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tEstatus
        '
        Me.tEstatus.AcceptsReturn = True
        Me.tEstatus.AcceptsTab = True
        Me.tEstatus.Enabled = False
        Me.tEstatus.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEstatus.Location = New System.Drawing.Point(382, 53)
        Me.tEstatus.Name = "tEstatus"
        Me.tEstatus.Size = New System.Drawing.Size(159, 20)
        Me.tEstatus.TabIndex = 3
        Me.tEstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(434, 37)
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
        Me.Label9.Location = New System.Drawing.Point(29, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "Tipo"
        '
        'L2
        '
        Me.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(122, 3)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(254, 20)
        Me.L2.TabIndex = 131
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Label4.Location = New System.Drawing.Point(16, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Unidad"
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
        Me.Panel1.Controls.Add(Me.tCVE_ORD)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Location = New System.Drawing.Point(4, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(361, 147)
        Me.Panel1.TabIndex = 32
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
        Me.radExtra.UseVisualStyleBackColor = False
        '
        'F1
        '
        Me.F1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(201, 24)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(132, 20)
        Me.F1.TabIndex = 1
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.radCorrectivo.UseVisualStyleBackColor = False
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
        Me.radPreventivo.UseVisualStyleBackColor = False
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(159, 26)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(37, 13)
        Me.Label90.TabIndex = 153
        Me.Label90.Text = "Fecha"
        '
        'L1
        '
        Me.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(2, 77)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(354, 20)
        Me.L1.TabIndex = 152
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tCVE_ORD
        '
        Me.tCVE_ORD.AcceptsReturn = True
        Me.tCVE_ORD.AcceptsTab = True
        Me.tCVE_ORD.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_ORD.Location = New System.Drawing.Point(53, 23)
        Me.tCVE_ORD.Name = "tCVE_ORD"
        Me.tCVE_ORD.Size = New System.Drawing.Size(81, 24)
        Me.tCVE_ORD.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(7, 26)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 17)
        Me.Label27.TabIndex = 149
        Me.Label27.Text = "Folio"
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.Controls.Add(Me.Pag1)
        Me.Tab1.Controls.Add(Me.C1DockingTabPage1)
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(4, 190)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedTabBold = True
        Me.Tab1.Size = New System.Drawing.Size(1126, 290)
        Me.Tab1.TabIndex = 35
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.LtTotal)
        Me.Pag1.Controls.Add(Me.Label3)
        Me.Pag1.Controls.Add(Me.Fg)
        Me.Pag1.Location = New System.Drawing.Point(1, 24)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(1124, 265)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Servicios"
        '
        'LtTotal
        '
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
        Me.Label3.Location = New System.Drawing.Point(830, 270)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "Importe"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.AutoClipboard = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.CellButtonImage = Global.SGT_Transport.My.Resources.Resources.lupu2
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(6, 3)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 2
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(1115, 257)
        Me.Fg.TabIndex = 0
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.Controls.Add(Me.tOBSER)
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 24)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(1124, 265)
        Me.C1DockingTabPage1.TabIndex = 1
        Me.C1DockingTabPage1.Text = "Observaciones"
        '
        'tOBSER
        '
        Me.tOBSER.AcceptsReturn = True
        Me.tOBSER.AcceptsTab = True
        Me.tOBSER.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tOBSER.Location = New System.Drawing.Point(8, 52)
        Me.tOBSER.Multiline = True
        Me.tOBSER.Name = "tOBSER"
        Me.tOBSER.Size = New System.Drawing.Size(695, 134)
        Me.tOBSER.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.ToolStripSeparator1, Me.barReimpresion, Me.barKardex, Me.mnuSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1145, 33)
        Me.ToolStrip1.TabIndex = 36
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = CType(resources.GetObject("barGrabar.Image"), System.Drawing.Image)
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.Padding = New System.Windows.Forms.Padding(0)
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(43, 33)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 33)
        '
        'barReimpresion
        '
        Me.barReimpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barReimpresion.ForeColor = System.Drawing.Color.Black
        Me.barReimpresion.Image = Global.SGT_Transport.My.Resources.Resources.printer
        Me.barReimpresion.Name = "barReimpresion"
        Me.barReimpresion.ShortcutKeyDisplayString = "Grabar registro"
        Me.barReimpresion.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barReimpresion.Size = New System.Drawing.Size(77, 33)
        Me.barReimpresion.Text = "Reimpresión"
        Me.barReimpresion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barReimpresion.Visible = False
        '
        'barKardex
        '
        Me.barKardex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barKardex.ForeColor = System.Drawing.Color.Black
        Me.barKardex.Image = Global.SGT_Transport.My.Resources.Resources.k5
        Me.barKardex.Name = "barKardex"
        Me.barKardex.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barKardex.Size = New System.Drawing.Size(52, 33)
        Me.barKardex.Text = "Kardex"
        Me.barKardex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = CType(resources.GetObject("mnuSalir.Image"), System.Drawing.Image)
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(39, 33)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "0e7f8935874847f694db78cb9dd97e50"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'frmMovsInvOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 513)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMovsInvOT"
        Me.Text = "Movimientos al inventario OT"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.btnProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProgServ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        Me.Pag1.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTabPage1.ResumeLayout(False)
        Me.C1DockingTabPage1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tNOTA As TextBox
    Friend WithEvents tLUGAR_REP As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnProgServ As C1.Win.C1Input.C1Button
    Friend WithEvents LtOper As Label
    Friend WithEvents tCVE_OPER As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents L4 As Label
    Friend WithEvents tEstatus As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents tCVE_TIPO As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents L2 As Label
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents radExtra As RadioButton
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents radCorrectivo As RadioButton
    Friend WithEvents radPreventivo As RadioButton
    Friend WithEvents Label90 As Label
    Friend WithEvents L1 As Label
    Friend WithEvents tCVE_ORD As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents LtTotal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tOBSER As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents barReimpresion As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents L3 As Label
    Friend WithEvents btnProv As C1.Win.C1Input.C1Button
    Friend WithEvents tCVE_PROV As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents barKardex As ToolStripMenuItem
End Class
