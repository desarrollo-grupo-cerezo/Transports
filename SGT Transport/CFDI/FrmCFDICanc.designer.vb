﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCFDICanc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCFDICanc))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarCancelar = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkCancelar = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.LtCP1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LtCP2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LtFactura = New System.Windows.Forms.Label()
        Me.CboMotivoCanc = New C1.Win.C1Input.C1ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LtMotivo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtUUI = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TOBSER = New System.Windows.Forms.TextBox()
        Me.LtTimbrado = New System.Windows.Forms.Label()
        Me.TCVE_FOLIO = New System.Windows.Forms.TextBox()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.BtnCartaPorte = New System.Windows.Forms.Button()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.LTUUID_SUSTITUYE = New System.Windows.Forms.Label()
        Me.Lt3 = New System.Windows.Forms.Label()
        Me.LtFacturaSust = New System.Windows.Forms.Label()
        Me.Lt4 = New System.Windows.Forms.Label()
        Me.LTCVE_FOLIO2 = New System.Windows.Forms.Label()
        Me.Lt5 = New System.Windows.Forms.Label()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboMotivoCanc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarCancelar)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarCancelar
        '
        Me.BarCancelar.Image = Global.SGT_Transport.My.Resources.Resources.equis2
        Me.BarCancelar.Name = "BarCancelar"
        Me.BarCancelar.ShortcutText = ""
        Me.BarCancelar.ShowShortcut = False
        Me.BarCancelar.ShowTextAsToolTip = False
        Me.BarCancelar.Text = "Cancelar"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkCancelar, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(563, 44)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.Wrap = True
        '
        'LkCancelar
        '
        Me.LkCancelar.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkCancelar.Command = Me.BarCancelar
        Me.LkCancelar.Delimiter = True
        Me.LkCancelar.Text = "Cancelar CFDI"
        '
        'LkSalir
        '
        Me.LkSalir.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkSalir.Command = Me.BarSalir
        Me.LkSalir.Delimiter = True
        Me.LkSalir.SortOrder = 1
        Me.LkSalir.ToolTipText = "SALIR"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(15, 75)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(124, 16)
        Me.Label26.TabIndex = 562
        Me.Label26.Text = "Motivo cancelación"
        '
        'LtCP1
        '
        Me.LtCP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCP1.Location = New System.Drawing.Point(143, 184)
        Me.LtCP1.Name = "LtCP1"
        Me.LtCP1.Size = New System.Drawing.Size(120, 23)
        Me.LtCP1.TabIndex = 567
        Me.LtCP1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 568
        Me.Label1.Text = "Carta porte"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(311, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 570
        Me.Label2.Text = "Carta porte 2"
        '
        'LtCP2
        '
        Me.LtCP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCP2.Location = New System.Drawing.Point(398, 180)
        Me.LtCP2.Name = "LtCP2"
        Me.LtCP2.Size = New System.Drawing.Size(120, 23)
        Me.LtCP2.TabIndex = 569
        Me.LtCP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(86, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 575
        Me.Label3.Text = "Factura"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtFactura
        '
        Me.LtFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFactura.Location = New System.Drawing.Point(143, 146)
        Me.LtFactura.Name = "LtFactura"
        Me.LtFactura.Size = New System.Drawing.Size(120, 23)
        Me.LtFactura.TabIndex = 574
        Me.LtFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboMotivoCanc
        '
        Me.CboMotivoCanc.AllowSpinLoop = False
        Me.CboMotivoCanc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.CboMotivoCanc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CboMotivoCanc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CboMotivoCanc.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.CboMotivoCanc.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.CboMotivoCanc.DropDownWidth = 450
        Me.CboMotivoCanc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMotivoCanc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CboMotivoCanc.GapHeight = 0
        Me.CboMotivoCanc.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.CboMotivoCanc.ItemsDisplayMember = ""
        Me.CboMotivoCanc.ItemsValueMember = ""
        Me.CboMotivoCanc.Location = New System.Drawing.Point(143, 73)
        Me.CboMotivoCanc.Name = "CboMotivoCanc"
        Me.CboMotivoCanc.Size = New System.Drawing.Size(375, 20)
        Me.CboMotivoCanc.Style.DropDownBackColor = System.Drawing.Color.White
        Me.CboMotivoCanc.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro
        Me.CboMotivoCanc.TabIndex = 577
        Me.CboMotivoCanc.Tag = Nothing
        Me.CboMotivoCanc.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.CboMotivoCanc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(91, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 579
        Me.Label4.Text = "Motivo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtMotivo
        '
        Me.LtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtMotivo.Location = New System.Drawing.Point(143, 108)
        Me.LtMotivo.Name = "LtMotivo"
        Me.LtMotivo.Size = New System.Drawing.Size(375, 23)
        Me.LtMotivo.TabIndex = 578
        Me.LtMotivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(98, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 16)
        Me.Label5.TabIndex = 582
        Me.Label5.Text = "UUID"
        '
        'LtUUI
        '
        Me.LtUUI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUUI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUUI.Location = New System.Drawing.Point(143, 222)
        Me.LtUUI.Name = "LtUUI"
        Me.LtUUI.Size = New System.Drawing.Size(375, 23)
        Me.LtUUI.TabIndex = 581
        Me.LtUUI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(39, 264)
        Me.Label22.Margin = New System.Windows.Forms.Padding(3)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 16)
        Me.Label22.TabIndex = 584
        Me.Label22.Text = "Observaciones"
        '
        'TOBSER
        '
        Me.TOBSER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TOBSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOBSER.Location = New System.Drawing.Point(143, 260)
        Me.TOBSER.MaxLength = 80
        Me.TOBSER.Name = "TOBSER"
        Me.TOBSER.Size = New System.Drawing.Size(375, 22)
        Me.TOBSER.TabIndex = 585
        '
        'LtTimbrado
        '
        Me.LtTimbrado.AutoSize = True
        Me.LtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTimbrado.Location = New System.Drawing.Point(361, 15)
        Me.LtTimbrado.Name = "LtTimbrado"
        Me.LtTimbrado.Size = New System.Drawing.Size(57, 16)
        Me.LtTimbrado.TabIndex = 587
        Me.LtTimbrado.Text = "_______"
        '
        'TCVE_FOLIO
        '
        Me.TCVE_FOLIO.AcceptsReturn = True
        Me.TCVE_FOLIO.AcceptsTab = True
        Me.TCVE_FOLIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_FOLIO.Location = New System.Drawing.Point(143, 328)
        Me.TCVE_FOLIO.Name = "TCVE_FOLIO"
        Me.TCVE_FOLIO.ReadOnly = True
        Me.TCVE_FOLIO.Size = New System.Drawing.Size(120, 22)
        Me.TCVE_FOLIO.TabIndex = 591
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(65, 331)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(74, 16)
        Me.Lt1.TabIndex = 589
        Me.Lt1.Text = "Carta porte"
        '
        'BtnCartaPorte
        '
        Me.BtnCartaPorte.AutoSize = True
        Me.BtnCartaPorte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnCartaPorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCartaPorte.Image = CType(resources.GetObject("BtnCartaPorte.Image"), System.Drawing.Image)
        Me.BtnCartaPorte.Location = New System.Drawing.Point(266, 327)
        Me.BtnCartaPorte.Name = "BtnCartaPorte"
        Me.BtnCartaPorte.Size = New System.Drawing.Size(24, 23)
        Me.BtnCartaPorte.TabIndex = 590
        Me.BtnCartaPorte.UseVisualStyleBackColor = True
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(33, 406)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(106, 16)
        Me.Lt2.TabIndex = 593
        Me.Lt2.Text = "UUID sustitución"
        '
        'LTUUID_SUSTITUYE
        '
        Me.LTUUID_SUSTITUYE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTUUID_SUSTITUYE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTUUID_SUSTITUYE.Location = New System.Drawing.Point(143, 403)
        Me.LTUUID_SUSTITUYE.Name = "LTUUID_SUSTITUYE"
        Me.LTUUID_SUSTITUYE.Size = New System.Drawing.Size(375, 23)
        Me.LTUUID_SUSTITUYE.TabIndex = 592
        Me.LTUUID_SUSTITUYE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lt3
        '
        Me.Lt3.AutoSize = True
        Me.Lt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt3.Location = New System.Drawing.Point(86, 368)
        Me.Lt3.Name = "Lt3"
        Me.Lt3.Size = New System.Drawing.Size(53, 16)
        Me.Lt3.TabIndex = 596
        Me.Lt3.Text = "Factura"
        Me.Lt3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LtFacturaSust
        '
        Me.LtFacturaSust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtFacturaSust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtFacturaSust.Location = New System.Drawing.Point(143, 365)
        Me.LtFacturaSust.Name = "LtFacturaSust"
        Me.LtFacturaSust.Size = New System.Drawing.Size(120, 23)
        Me.LtFacturaSust.TabIndex = 595
        Me.LtFacturaSust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lt4
        '
        Me.Lt4.AutoSize = True
        Me.Lt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt4.Location = New System.Drawing.Point(311, 331)
        Me.Lt4.Name = "Lt4"
        Me.Lt4.Size = New System.Drawing.Size(84, 16)
        Me.Lt4.TabIndex = 599
        Me.Lt4.Text = "Carta porte 2"
        '
        'LTCVE_FOLIO2
        '
        Me.LTCVE_FOLIO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTCVE_FOLIO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTCVE_FOLIO2.Location = New System.Drawing.Point(398, 328)
        Me.LTCVE_FOLIO2.Name = "LTCVE_FOLIO2"
        Me.LTCVE_FOLIO2.Size = New System.Drawing.Size(120, 23)
        Me.LTCVE_FOLIO2.TabIndex = 598
        Me.LTCVE_FOLIO2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lt5
        '
        Me.Lt5.AutoSize = True
        Me.Lt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt5.Location = New System.Drawing.Point(223, 298)
        Me.Lt5.Name = "Lt5"
        Me.Lt5.Size = New System.Drawing.Size(234, 16)
        Me.Lt5.TabIndex = 600
        Me.Lt5.Text = "UUID que sustituye al cancelado"
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "ba89cd5b302b40e9930aecefc7b05080"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'FrmCFDICanc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 460)
        Me.Controls.Add(Me.Lt5)
        Me.Controls.Add(Me.Lt4)
        Me.Controls.Add(Me.LTCVE_FOLIO2)
        Me.Controls.Add(Me.Lt3)
        Me.Controls.Add(Me.LtFacturaSust)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.LTUUID_SUSTITUYE)
        Me.Controls.Add(Me.TCVE_FOLIO)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.BtnCartaPorte)
        Me.Controls.Add(Me.LtTimbrado)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TOBSER)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LtUUI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LtMotivo)
        Me.Controls.Add(Me.CboMotivoCanc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LtFactura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LtCP2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LtCP1)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCFDICanc"
        Me.ShowInTaskbar = False
        Me.Text = "Cancelación CFDI carta porte"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboMotivoCanc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents BarCancelar As C1.Win.C1Command.C1Command
    Private WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkCancelar As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Label26 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LtCP1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LtCP2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LtFactura As Label
    Friend WithEvents CboMotivoCanc As C1.Win.C1Input.C1ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LtMotivo As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LtUUI As Label
    Private WithEvents Label22 As Label
    Private WithEvents TOBSER As TextBox
    Friend WithEvents LtTimbrado As Label
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents Lt2 As Label
    Friend WithEvents LTUUID_SUSTITUYE As Label
    Friend WithEvents TCVE_FOLIO As TextBox
    Friend WithEvents Lt1 As Label
    Friend WithEvents BtnCartaPorte As Button
    Friend WithEvents Lt3 As Label
    Friend WithEvents LtFacturaSust As Label
    Friend WithEvents Lt4 As Label
    Friend WithEvents LTCVE_FOLIO2 As Label
    Friend WithEvents Lt5 As Label
End Class
