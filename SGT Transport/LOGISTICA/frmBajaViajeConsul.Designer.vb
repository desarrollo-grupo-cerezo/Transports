<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBajaViajeConsul
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBajaViajeConsul))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tCLIENTE = New System.Windows.Forms.TextBox()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tCVE_BAJA = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tNETO = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.tIVA = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.tSUBTOTAL = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.SpliMain = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.tRETENCION = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        CType(Me.SpliMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SpliMain.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.Split2.SuspendLayout()
        Me.Split3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(1224, 381)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 206
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(69, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 15)
        Me.Label12.TabIndex = 313
        Me.Label12.Text = "Cliente fiscal"
        '
        'tCLIENTE
        '
        Me.tCLIENTE.AcceptsReturn = True
        Me.tCLIENTE.AcceptsTab = True
        Me.tCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.tCLIENTE.Location = New System.Drawing.Point(149, 40)
        Me.tCLIENTE.Name = "tCLIENTE"
        Me.tCLIENTE.Size = New System.Drawing.Size(70, 21)
        Me.tCLIENTE.TabIndex = 311
        '
        'LtNombre
        '
        Me.LtNombre.BackColor = System.Drawing.Color.LightGray
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(225, 40)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(331, 23)
        Me.LtNombre.TabIndex = 314
        Me.LtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(422, 10)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(133, 22)
        Me.F1.TabIndex = 308
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(311, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 15)
        Me.Label14.TabIndex = 309
        Me.Label14.Text = "Fecha carta porte"
        '
        'tCVE_BAJA
        '
        Me.tCVE_BAJA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_BAJA.Location = New System.Drawing.Point(149, 10)
        Me.tCVE_BAJA.Name = "tCVE_BAJA"
        Me.tCVE_BAJA.Size = New System.Drawing.Size(116, 21)
        Me.tCVE_BAJA.TabIndex = 310
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 15)
        Me.Label5.TabIndex = 307
        Me.Label5.Text = "Clave de transferencia"
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.barSalir.Size = New System.Drawing.Size(1226, 39)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 315
        Me.barSalir.Text = "MenuStrip1"
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.White
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(41, 35)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tNETO
        '
        Me.tNETO.BackColor = System.Drawing.Color.Transparent
        Me.tNETO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tNETO.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNETO.Location = New System.Drawing.Point(998, 2)
        Me.tNETO.Name = "tNETO"
        Me.tNETO.Size = New System.Drawing.Size(152, 25)
        Me.tNETO.TabIndex = 321
        Me.tNETO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.BackColor = System.Drawing.Color.Transparent
        Me.L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.Location = New System.Drawing.Point(955, 5)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(38, 17)
        Me.L3.TabIndex = 320
        Me.L3.Text = "Neto"
        '
        'tIVA
        '
        Me.tIVA.BackColor = System.Drawing.Color.Transparent
        Me.tIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tIVA.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tIVA.Location = New System.Drawing.Point(555, 2)
        Me.tIVA.Name = "tIVA"
        Me.tIVA.Size = New System.Drawing.Size(152, 25)
        Me.tIVA.TabIndex = 319
        Me.tIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.BackColor = System.Drawing.Color.Transparent
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.Location = New System.Drawing.Point(521, 5)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(29, 17)
        Me.L2.TabIndex = 318
        Me.L2.Text = "IVA"
        '
        'tSUBTOTAL
        '
        Me.tSUBTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.tSUBTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tSUBTOTAL.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSUBTOTAL.Location = New System.Drawing.Point(347, 2)
        Me.tSUBTOTAL.Name = "tSUBTOTAL"
        Me.tSUBTOTAL.Size = New System.Drawing.Size(152, 25)
        Me.tSUBTOTAL.TabIndex = 317
        Me.tSUBTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.BackColor = System.Drawing.Color.Transparent
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.Location = New System.Drawing.Point(277, 5)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(65, 17)
        Me.L1.TabIndex = 316
        Me.L1.Text = "Sub-total"
        '
        'SpliMain
        '
        Me.SpliMain.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SpliMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SpliMain.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SpliMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SpliMain.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SpliMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SpliMain.Location = New System.Drawing.Point(0, 39)
        Me.SpliMain.Name = "SpliMain"
        Me.SpliMain.Panels.Add(Me.Split1)
        Me.SpliMain.Panels.Add(Me.Split2)
        Me.SpliMain.Panels.Add(Me.Split3)
        Me.SpliMain.Size = New System.Drawing.Size(1226, 618)
        Me.SpliMain.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SpliMain.TabIndex = 322
        Me.SpliMain.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'Split1
        '
        Me.Split1.BorderWidth = 1
        Me.Split1.Controls.Add(Me.tCVE_BAJA)
        Me.Split1.Controls.Add(Me.Label5)
        Me.Split1.Controls.Add(Me.Label12)
        Me.Split1.Controls.Add(Me.Label14)
        Me.Split1.Controls.Add(Me.tCLIENTE)
        Me.Split1.Controls.Add(Me.F1)
        Me.Split1.Controls.Add(Me.LtNombre)
        Me.Split1.Height = 128
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(1224, 126)
        Me.Split1.SizeRatio = 20.847R
        Me.Split1.TabIndex = 0
        '
        'Split2
        '
        Me.Split2.BorderWidth = 1
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 383
        Me.Split2.Location = New System.Drawing.Point(1, 133)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(1224, 381)
        Me.Split2.SizeRatio = 79.461R
        Me.Split2.TabIndex = 1
        '
        'Split3
        '
        Me.Split3.BorderWidth = 1
        Me.Split3.Controls.Add(Me.tRETENCION)
        Me.Split3.Controls.Add(Me.Label2)
        Me.Split3.Controls.Add(Me.tSUBTOTAL)
        Me.Split3.Controls.Add(Me.tNETO)
        Me.Split3.Controls.Add(Me.L1)
        Me.Split3.Controls.Add(Me.L3)
        Me.Split3.Controls.Add(Me.L2)
        Me.Split3.Controls.Add(Me.tIVA)
        Me.Split3.Height = 99
        Me.Split3.Location = New System.Drawing.Point(1, 520)
        Me.Split3.Name = "Split3"
        Me.Split3.Size = New System.Drawing.Size(1224, 97)
        Me.Split3.TabIndex = 2
        '
        'tRETENCION
        '
        Me.tRETENCION.BackColor = System.Drawing.Color.Transparent
        Me.tRETENCION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tRETENCION.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRETENCION.Location = New System.Drawing.Point(797, 2)
        Me.tRETENCION.Name = "tRETENCION"
        Me.tRETENCION.Size = New System.Drawing.Size(152, 25)
        Me.tRETENCION.TabIndex = 323
        Me.tRETENCION.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(720, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 322
        Me.Label2.Text = "Retención"
        '
        'frmBajaViajeConsul
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1226, 657)
        Me.Controls.Add(Me.SpliMain)
        Me.Controls.Add(Me.barSalir)
        Me.Name = "frmBajaViajeConsul"
        Me.ShowInTaskbar = False
        Me.Text = "Consulta de bajas de viaje"
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.SpliMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SpliMain.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        Me.Split2.ResumeLayout(False)
        Me.Split3.ResumeLayout(False)
        Me.Split3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label12 As Label
    Friend WithEvents tCLIENTE As TextBox
    Friend WithEvents LtNombre As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label14 As Label
    Friend WithEvents tCVE_BAJA As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tNETO As Label
    Friend WithEvents L3 As Label
    Friend WithEvents tIVA As Label
    Friend WithEvents L2 As Label
    Friend WithEvents tSUBTOTAL As Label
    Friend WithEvents L1 As Label
    Friend WithEvents SpliMain As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents tRETENCION As Label
    Friend WithEvents Label2 As Label
End Class
