<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMultiAlmacenRAlta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMultiAlmacenRAlta))
        Me.barMenu = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCTRL_ALM = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.tCOMP_X_REC = New C1.Win.C1Input.C1NumericEdit()
        Me.tSTOCK_MAX = New C1.Win.C1Input.C1NumericEdit()
        Me.tSTOCK_MIN = New C1.Win.C1Input.C1NumericEdit()
        Me.tEXIST = New C1.Win.C1Input.C1NumericEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New C1.Win.C1Input.C1ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tCVE_ART = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnProd = New C1.Win.C1Input.C1Button()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.barMenu.SuspendLayout()
        CType(Me.tCOMP_X_REC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tSTOCK_MAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tSTOCK_MIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tEXIST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barMenu
        '
        Me.barMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.barMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barMenu.Location = New System.Drawing.Point(0, 0)
        Me.barMenu.Name = "barMenu"
        Me.barMenu.Size = New System.Drawing.Size(641, 55)
        Me.barMenu.Stretch = False
        Me.barMenu.TabIndex = 0
        Me.barMenu.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(57, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tCTRL_ALM
        '
        Me.tCTRL_ALM.AcceptsReturn = True
        Me.tCTRL_ALM.AcceptsTab = True
        Me.tCTRL_ALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCTRL_ALM.Location = New System.Drawing.Point(417, 118)
        Me.tCTRL_ALM.Name = "tCTRL_ALM"
        Me.tCTRL_ALM.Size = New System.Drawing.Size(171, 22)
        Me.tCTRL_ALM.TabIndex = 2
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(287, 121)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(124, 16)
        Me.Label27.TabIndex = 88
        Me.Label27.Text = "Control de almacen"
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(12, 163)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(88, 16)
        Me.Nombre.TabIndex = 87
        Me.Nombre.Text = "Stock minimo"
        '
        'tCOMP_X_REC
        '
        Me.tCOMP_X_REC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tCOMP_X_REC.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tCOMP_X_REC.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tCOMP_X_REC.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tCOMP_X_REC.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tCOMP_X_REC.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tCOMP_X_REC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCOMP_X_REC.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tCOMP_X_REC.Location = New System.Drawing.Point(417, 194)
        Me.tCOMP_X_REC.Name = "tCOMP_X_REC"
        Me.tCOMP_X_REC.Size = New System.Drawing.Size(131, 20)
        Me.tCOMP_X_REC.TabIndex = 6
        Me.tCOMP_X_REC.Tag = Nothing
        Me.tCOMP_X_REC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tCOMP_X_REC.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'tSTOCK_MAX
        '
        Me.tSTOCK_MAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tSTOCK_MAX.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tSTOCK_MAX.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tSTOCK_MAX.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tSTOCK_MAX.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tSTOCK_MAX.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tSTOCK_MAX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSTOCK_MAX.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tSTOCK_MAX.Location = New System.Drawing.Point(417, 161)
        Me.tSTOCK_MAX.Name = "tSTOCK_MAX"
        Me.tSTOCK_MAX.Size = New System.Drawing.Size(131, 20)
        Me.tSTOCK_MAX.TabIndex = 4
        Me.tSTOCK_MAX.Tag = Nothing
        Me.tSTOCK_MAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tSTOCK_MAX.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'tSTOCK_MIN
        '
        Me.tSTOCK_MIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tSTOCK_MIN.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tSTOCK_MIN.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tSTOCK_MIN.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tSTOCK_MIN.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tSTOCK_MIN.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tSTOCK_MIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSTOCK_MIN.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tSTOCK_MIN.Location = New System.Drawing.Point(108, 161)
        Me.tSTOCK_MIN.Name = "tSTOCK_MIN"
        Me.tSTOCK_MIN.Size = New System.Drawing.Size(131, 20)
        Me.tSTOCK_MIN.TabIndex = 3
        Me.tSTOCK_MIN.Tag = Nothing
        Me.tSTOCK_MIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tSTOCK_MIN.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'tEXIST
        '
        Me.tEXIST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tEXIST.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tEXIST.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tEXIST.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.tEXIST.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tEXIST.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tEXIST.Enabled = False
        Me.tEXIST.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEXIST.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tEXIST.Location = New System.Drawing.Point(108, 194)
        Me.tEXIST.Name = "tEXIST"
        Me.tEXIST.Size = New System.Drawing.Size(131, 20)
        Me.tEXIST.TabIndex = 5
        Me.tEXIST.Tag = Nothing
        Me.tEXIST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tEXIST.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(286, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 16)
        Me.Label3.TabIndex = 315
        Me.Label3.Text = "Pendientes x recibir"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 314
        Me.Label4.Text = "Existencia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(319, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 313
        Me.Label1.Text = "Stock maximo"
        '
        'cboAlmacen
        '
        Me.cboAlmacen.AllowSpinLoop = False
        Me.cboAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboAlmacen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboAlmacen.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.GapHeight = 0
        Me.cboAlmacen.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboAlmacen.ItemsDisplayMember = ""
        Me.cboAlmacen.ItemsValueMember = ""
        Me.cboAlmacen.Location = New System.Drawing.Point(89, 118)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(175, 20)
        Me.cboAlmacen.TabIndex = 1
        Me.cboAlmacen.Tag = Nothing
        Me.cboAlmacen.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboAlmacen.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 312
        Me.Label2.Text = "Almacen"
        '
        'tCVE_ART
        '
        Me.tCVE_ART.AcceptsReturn = True
        Me.tCVE_ART.AcceptsTab = True
        Me.tCVE_ART.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_ART.Location = New System.Drawing.Point(89, 82)
        Me.tCVE_ART.Name = "tCVE_ART"
        Me.tCVE_ART.Size = New System.Drawing.Size(175, 22)
        Me.tCVE_ART.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Articulo"
        '
        'btnProd
        '
        Me.btnProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProd.Image = CType(resources.GetObject("btnProd.Image"), System.Drawing.Image)
        Me.btnProd.Location = New System.Drawing.Point(266, 83)
        Me.btnProd.Name = "btnProd"
        Me.btnProd.Size = New System.Drawing.Size(26, 20)
        Me.btnProd.TabIndex = 144
        Me.btnProd.UseVisualStyleBackColor = True
        Me.btnProd.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'frmMultiAlmacenRAlta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 256)
        Me.Controls.Add(Me.tCOMP_X_REC)
        Me.Controls.Add(Me.tSTOCK_MAX)
        Me.Controls.Add(Me.barMenu)
        Me.Controls.Add(Me.tSTOCK_MIN)
        Me.Controls.Add(Me.tCVE_ART)
        Me.Controls.Add(Me.tEXIST)
        Me.Controls.Add(Me.btnProd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.cboAlmacen)
        Me.Controls.Add(Me.tCTRL_ALM)
        Me.Controls.Add(Me.Nombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMultiAlmacenRAlta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta productos en almacén"
        Me.barMenu.ResumeLayout(False)
        Me.barMenu.PerformLayout()
        CType(Me.tCOMP_X_REC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tSTOCK_MAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tSTOCK_MIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tEXIST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barMenu As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tCTRL_ALM As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Nombre As Label
    Friend WithEvents tCVE_ART As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnProd As C1.Win.C1Input.C1Button
    Friend WithEvents cboAlmacen As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tCOMP_X_REC As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tSTOCK_MAX As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tSTOCK_MIN As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tEXIST As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
End Class
