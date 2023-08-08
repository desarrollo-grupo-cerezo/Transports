<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmValeCombustibleAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValeCombustibleAE))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.LtVale = New System.Windows.Forms.Label()
        Me.tVALE_GAS = New System.Windows.Forms.TextBox()
        Me.LtUnidad = New System.Windows.Forms.Label()
        Me.tCVE_UNI = New System.Windows.Forms.TextBox()
        Me.tCVE_FOLIO = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Lt = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtCartaPorte = New System.Windows.Forms.Label()
        Me.tCVE_CAR = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tOBSER = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tImporte = New C1.Win.C1Input.C1NumericEdit()
        Me.tPrecio = New C1.Win.C1Input.C1NumericEdit()
        Me.tLITROS_REAL = New C1.Win.C1Input.C1NumericEdit()
        Me.tLITROS = New C1.Win.C1Input.C1NumericEdit()
        Me.LtConc = New System.Windows.Forms.Label()
        Me.tNUM_CPTO = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnFormaPago = New System.Windows.Forms.Button()
        Me.btnCarPorte = New System.Windows.Forms.Button()
        Me.btnUnidad = New System.Windows.Forms.Button()
        Me.btnGas = New System.Windows.Forms.Button()
        Me.LtGas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tCVE_GAS = New System.Windows.Forms.TextBox()
        Me.barSalir.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tLITROS_REAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tLITROS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(585, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 13
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.barGrabar.ForeColor = System.Drawing.Color.Black
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.ShortcutKeyDisplayString = "Grabar registro"
        Me.barGrabar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barGrabar.Size = New System.Drawing.Size(54, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LtVale
        '
        Me.LtVale.AutoSize = True
        Me.LtVale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtVale.Location = New System.Drawing.Point(44, 106)
        Me.LtVale.Name = "LtVale"
        Me.LtVale.Size = New System.Drawing.Size(84, 15)
        Me.LtVale.TabIndex = 243
        Me.LtVale.Text = "Folio gasolina"
        '
        'tVALE_GAS
        '
        Me.tVALE_GAS.AcceptsReturn = True
        Me.tVALE_GAS.AcceptsTab = True
        Me.tVALE_GAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tVALE_GAS.Location = New System.Drawing.Point(132, 102)
        Me.tVALE_GAS.Name = "tVALE_GAS"
        Me.tVALE_GAS.Size = New System.Drawing.Size(83, 21)
        Me.tVALE_GAS.TabIndex = 1
        '
        'LtUnidad
        '
        Me.LtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUnidad.Location = New System.Drawing.Point(240, 181)
        Me.LtUnidad.Name = "LtUnidad"
        Me.LtUnidad.Size = New System.Drawing.Size(312, 20)
        Me.LtUnidad.TabIndex = 239
        '
        'tCVE_UNI
        '
        Me.tCVE_UNI.AcceptsReturn = True
        Me.tCVE_UNI.AcceptsTab = True
        Me.tCVE_UNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_UNI.Location = New System.Drawing.Point(132, 180)
        Me.tCVE_UNI.Name = "tCVE_UNI"
        Me.tCVE_UNI.Size = New System.Drawing.Size(83, 21)
        Me.tCVE_UNI.TabIndex = 5
        '
        'tCVE_FOLIO
        '
        Me.tCVE_FOLIO.AcceptsReturn = True
        Me.tCVE_FOLIO.AcceptsTab = True
        Me.tCVE_FOLIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_FOLIO.Location = New System.Drawing.Point(132, 75)
        Me.tCVE_FOLIO.Name = "tCVE_FOLIO"
        Me.tCVE_FOLIO.Size = New System.Drawing.Size(83, 21)
        Me.tCVE_FOLIO.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(94, 78)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 15)
        Me.Label27.TabIndex = 236
        Me.Label27.Text = "Folio"
        '
        'Lt
        '
        Me.Lt.AutoSize = True
        Me.Lt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt.Location = New System.Drawing.Point(81, 184)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(47, 15)
        Me.Lt.TabIndex = 235
        Me.Lt.Text = "Unidad"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(132, 132)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(159, 19)
        Me.F1.TabIndex = 3
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(62, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "Fecha vale"
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(132, 157)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(159, 19)
        Me.F2.TabIndex = 4
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 247
        Me.Label4.Text = "Fecha carga"
        '
        'LtCartaPorte
        '
        Me.LtCartaPorte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCartaPorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCartaPorte.Location = New System.Drawing.Point(240, 231)
        Me.LtCartaPorte.Name = "LtCartaPorte"
        Me.LtCartaPorte.Size = New System.Drawing.Size(312, 20)
        Me.LtCartaPorte.TabIndex = 250
        '
        'tCVE_CAR
        '
        Me.tCVE_CAR.AcceptsReturn = True
        Me.tCVE_CAR.AcceptsTab = True
        Me.tCVE_CAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_CAR.Location = New System.Drawing.Point(132, 230)
        Me.tCVE_CAR.Name = "tCVE_CAR"
        Me.tCVE_CAR.Size = New System.Drawing.Size(83, 21)
        Me.tCVE_CAR.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(61, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 249
        Me.Label6.Text = "Carta porte"
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(132, 257)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 20)
        Me.Label7.TabIndex = 253
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 258)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 15)
        Me.Label8.TabIndex = 252
        Me.Label8.Text = "Carta porte asociada"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(86, 285)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 15)
        Me.Label9.TabIndex = 255
        Me.Label9.Text = "Precio"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(323, 285)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 15)
        Me.Label10.TabIndex = 257
        Me.Label10.Text = "Importe"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(91, 317)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 15)
        Me.Label11.TabIndex = 259
        Me.Label11.Text = "Litros"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(298, 316)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 15)
        Me.Label12.TabIndex = 261
        Me.Label12.Text = "Litros reales"
        '
        'tOBSER
        '
        Me.tOBSER.AcceptsReturn = True
        Me.tOBSER.AcceptsTab = True
        Me.tOBSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tOBSER.Location = New System.Drawing.Point(132, 345)
        Me.tOBSER.Multiline = True
        Me.tOBSER.Name = "tOBSER"
        Me.tOBSER.Size = New System.Drawing.Size(452, 78)
        Me.tOBSER.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(40, 345)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 15)
        Me.Label13.TabIndex = 263
        Me.Label13.Text = "Observaciones"
        '
        'tImporte
        '
        Me.tImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tImporte.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tImporte.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tImporte.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tImporte.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tImporte.Location = New System.Drawing.Point(377, 283)
        Me.tImporte.Name = "tImporte"
        Me.tImporte.Size = New System.Drawing.Size(130, 19)
        Me.tImporte.TabIndex = 9
        Me.tImporte.Tag = Nothing
        Me.tImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tImporte.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tImporte.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tImporte.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tPrecio
        '
        Me.tPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tPrecio.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tPrecio.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tPrecio.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tPrecio.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tPrecio.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPrecio.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tPrecio.Location = New System.Drawing.Point(132, 283)
        Me.tPrecio.Name = "tPrecio"
        Me.tPrecio.Size = New System.Drawing.Size(130, 19)
        Me.tPrecio.TabIndex = 8
        Me.tPrecio.Tag = Nothing
        Me.tPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tPrecio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tPrecio.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tPrecio.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tLITROS_REAL
        '
        Me.tLITROS_REAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tLITROS_REAL.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tLITROS_REAL.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLITROS_REAL.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLITROS_REAL.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tLITROS_REAL.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLITROS_REAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLITROS_REAL.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tLITROS_REAL.Location = New System.Drawing.Point(377, 314)
        Me.tLITROS_REAL.Name = "tLITROS_REAL"
        Me.tLITROS_REAL.Size = New System.Drawing.Size(130, 19)
        Me.tLITROS_REAL.TabIndex = 11
        Me.tLITROS_REAL.Tag = Nothing
        Me.tLITROS_REAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tLITROS_REAL.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tLITROS_REAL.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLITROS_REAL.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'tLITROS
        '
        Me.tLITROS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tLITROS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tLITROS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLITROS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLITROS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.GeneralNumber
        Me.tLITROS.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.tLITROS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLITROS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tLITROS.Location = New System.Drawing.Point(132, 314)
        Me.tLITROS.Name = "tLITROS"
        Me.tLITROS.Size = New System.Drawing.Size(130, 19)
        Me.tLITROS.TabIndex = 10
        Me.tLITROS.Tag = Nothing
        Me.tLITROS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tLITROS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.tLITROS.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.tLITROS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtConc
        '
        Me.LtConc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtConc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtConc.Location = New System.Drawing.Point(384, 102)
        Me.LtConc.Name = "LtConc"
        Me.LtConc.Size = New System.Drawing.Size(175, 20)
        Me.LtConc.TabIndex = 266
        '
        'tNUM_CPTO
        '
        Me.tNUM_CPTO.AcceptsReturn = True
        Me.tNUM_CPTO.AcceptsTab = True
        Me.tNUM_CPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNUM_CPTO.Location = New System.Drawing.Point(318, 102)
        Me.tNUM_CPTO.Name = "tNUM_CPTO"
        Me.tNUM_CPTO.Size = New System.Drawing.Size(42, 21)
        Me.tNUM_CPTO.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(225, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 15)
        Me.Label14.TabIndex = 265
        Me.Label14.Text = "Forma de pago"
        '
        'btnFormaPago
        '
        Me.btnFormaPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFormaPago.Image = CType(resources.GetObject("btnFormaPago.Image"), System.Drawing.Image)
        Me.btnFormaPago.Location = New System.Drawing.Point(360, 100)
        Me.btnFormaPago.Name = "btnFormaPago"
        Me.btnFormaPago.Size = New System.Drawing.Size(24, 23)
        Me.btnFormaPago.TabIndex = 267
        Me.btnFormaPago.UseVisualStyleBackColor = True
        '
        'btnCarPorte
        '
        Me.btnCarPorte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCarPorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCarPorte.Image = CType(resources.GetObject("btnCarPorte.Image"), System.Drawing.Image)
        Me.btnCarPorte.Location = New System.Drawing.Point(214, 229)
        Me.btnCarPorte.Name = "btnCarPorte"
        Me.btnCarPorte.Size = New System.Drawing.Size(24, 23)
        Me.btnCarPorte.TabIndex = 251
        Me.btnCarPorte.UseVisualStyleBackColor = True
        '
        'btnUnidad
        '
        Me.btnUnidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnidad.Image = CType(resources.GetObject("btnUnidad.Image"), System.Drawing.Image)
        Me.btnUnidad.Location = New System.Drawing.Point(214, 179)
        Me.btnUnidad.Name = "btnUnidad"
        Me.btnUnidad.Size = New System.Drawing.Size(24, 23)
        Me.btnUnidad.TabIndex = 241
        Me.btnUnidad.UseVisualStyleBackColor = True
        '
        'btnGas
        '
        Me.btnGas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGas.Image = CType(resources.GetObject("btnGas.Image"), System.Drawing.Image)
        Me.btnGas.Location = New System.Drawing.Point(214, 203)
        Me.btnGas.Name = "btnGas"
        Me.btnGas.Size = New System.Drawing.Size(24, 23)
        Me.btnGas.TabIndex = 577
        Me.btnGas.UseVisualStyleBackColor = True
        '
        'LtGas
        '
        Me.LtGas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtGas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtGas.Location = New System.Drawing.Point(240, 205)
        Me.LtGas.Name = "LtGas"
        Me.LtGas.Size = New System.Drawing.Size(312, 20)
        Me.LtGas.TabIndex = 576
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(61, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 575
        Me.Label2.Text = "Gasolinera"
        '
        'tCVE_GAS
        '
        Me.tCVE_GAS.AcceptsReturn = True
        Me.tCVE_GAS.AcceptsTab = True
        Me.tCVE_GAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_GAS.Location = New System.Drawing.Point(132, 204)
        Me.tCVE_GAS.Name = "tCVE_GAS"
        Me.tCVE_GAS.Size = New System.Drawing.Size(83, 21)
        Me.tCVE_GAS.TabIndex = 574
        '
        'frmValeCombustibleAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 463)
        Me.Controls.Add(Me.btnGas)
        Me.Controls.Add(Me.LtGas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tCVE_GAS)
        Me.Controls.Add(Me.tNUM_CPTO)
        Me.Controls.Add(Me.btnFormaPago)
        Me.Controls.Add(Me.LtConc)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tLITROS_REAL)
        Me.Controls.Add(Me.tLITROS)
        Me.Controls.Add(Me.tImporte)
        Me.Controls.Add(Me.tPrecio)
        Me.Controls.Add(Me.tOBSER)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnCarPorte)
        Me.Controls.Add(Me.LtCartaPorte)
        Me.Controls.Add(Me.tCVE_CAR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LtVale)
        Me.Controls.Add(Me.tVALE_GAS)
        Me.Controls.Add(Me.btnUnidad)
        Me.Controls.Add(Me.LtUnidad)
        Me.Controls.Add(Me.tCVE_UNI)
        Me.Controls.Add(Me.tCVE_FOLIO)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Lt)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValeCombustibleAE"
        Me.Text = "Vale combustible"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tLITROS_REAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tLITROS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents LtVale As Label
    Friend WithEvents tVALE_GAS As TextBox
    Friend WithEvents btnUnidad As Button
    Friend WithEvents LtUnidad As Label
    Friend WithEvents tCVE_UNI As TextBox
    Friend WithEvents tCVE_FOLIO As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Lt As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCarPorte As Button
    Friend WithEvents LtCartaPorte As Label
    Friend WithEvents tCVE_CAR As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents tOBSER As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tImporte As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tPrecio As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tLITROS_REAL As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents tLITROS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents btnFormaPago As Button
    Friend WithEvents LtConc As Label
    Friend WithEvents tNUM_CPTO As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnGas As Button
    Friend WithEvents LtGas As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tCVE_GAS As TextBox
End Class
