<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCriterioEvaAE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCriterioEvaAE))
        Me.MenuHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.BarGrabr = New C1.Win.C1Command.C1Command()
        Me.BarSalir = New C1.Win.C1Command.C1Command()
        Me.C1ToolBar1 = New C1.Win.C1Command.C1ToolBar()
        Me.LkGrabr = New C1.Win.C1Command.C1CommandLink()
        Me.LkSalir = New C1.Win.C1Command.C1CommandLink()
        Me.tCRITERIO = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.tCVE_EVE = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.tTABULADOR = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tFISICO_VS_ECM = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tRALENTI = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnAyuda = New System.Windows.Forms.Button()
        Me.RAyuda = New System.Windows.Forms.RichTextBox()
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuHolder
        '
        Me.MenuHolder.Animation = C1.Win.C1Command.C1AnimationEnum.[On]
        Me.MenuHolder.Commands.Add(Me.BarGrabr)
        Me.MenuHolder.Commands.Add(Me.BarSalir)
        Me.MenuHolder.Owner = Me
        '
        'BarGrabr
        '
        Me.BarGrabr.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabr.Name = "BarGrabr"
        Me.BarGrabr.ShortcutText = ""
        Me.BarGrabr.ShowShortcut = False
        Me.BarGrabr.ShowTextAsToolTip = False
        Me.BarGrabr.Text = "Grabr"
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
        Me.C1ToolBar1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.LkGrabr, Me.LkSalir})
        Me.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.C1ToolBar1.Movable = False
        Me.C1ToolBar1.Name = "C1ToolBar1"
        Me.C1ToolBar1.Size = New System.Drawing.Size(1163, 43)
        Me.C1ToolBar1.Text = "C1ToolBar1"
        Me.C1ToolBar1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'LkGrabr
        '
        Me.LkGrabr.ButtonLook = CType((C1.Win.C1Command.ButtonLookFlags.Text Or C1.Win.C1Command.ButtonLookFlags.Image), C1.Win.C1Command.ButtonLookFlags)
        Me.LkGrabr.Command = Me.BarGrabr
        Me.LkGrabr.Delimiter = True
        Me.LkGrabr.Text = "Grabr"
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
        'tCRITERIO
        '
        Me.tCRITERIO.AcceptsReturn = True
        Me.tCRITERIO.AcceptsTab = True
        Me.tCRITERIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCRITERIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCRITERIO.Location = New System.Drawing.Point(134, 160)
        Me.tCRITERIO.MaxLength = 120
        Me.tCRITERIO.Name = "tCRITERIO"
        Me.tCRITERIO.Size = New System.Drawing.Size(458, 21)
        Me.tCRITERIO.TabIndex = 2
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label37.Location = New System.Drawing.Point(12, 164)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(130, 17)
        Me.Label37.TabIndex = 496
        Me.Label37.Text = "Litro autorizados = "
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tCVE_EVE
        '
        Me.tCVE_EVE.BackColor = System.Drawing.Color.PaleTurquoise
        Me.tCVE_EVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tCVE_EVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_EVE.Location = New System.Drawing.Point(134, 61)
        Me.tCVE_EVE.Name = "tCVE_EVE"
        Me.tCVE_EVE.Size = New System.Drawing.Size(60, 21)
        Me.tCVE_EVE.TabIndex = 515
        Me.tCVE_EVE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(54, 66)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(44, 15)
        Me.Label39.TabIndex = 514
        Me.Label39.Text = "Evento"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tTABULADOR
        '
        Me.tTABULADOR.BackColor = System.Drawing.Color.PaleTurquoise
        Me.tTABULADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tTABULADOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTABULADOR.Location = New System.Drawing.Point(134, 85)
        Me.tTABULADOR.Name = "tTABULADOR"
        Me.tTABULADOR.Size = New System.Drawing.Size(60, 21)
        Me.tTABULADOR.TabIndex = 517
        Me.tTABULADOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(35, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 15)
        Me.Label5.TabIndex = 516
        Me.Label5.Text = "Tabulador"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tFISICO_VS_ECM
        '
        Me.tFISICO_VS_ECM.BackColor = System.Drawing.Color.PaleTurquoise
        Me.tFISICO_VS_ECM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tFISICO_VS_ECM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFISICO_VS_ECM.Location = New System.Drawing.Point(134, 109)
        Me.tFISICO_VS_ECM.Name = "tFISICO_VS_ECM"
        Me.tFISICO_VS_ECM.Size = New System.Drawing.Size(60, 21)
        Me.tFISICO_VS_ECM.TabIndex = 519
        Me.tFISICO_VS_ECM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 15)
        Me.Label7.TabIndex = 518
        Me.Label7.Text = "Fisico vs ECM"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tRALENTI
        '
        Me.tRALENTI.BackColor = System.Drawing.Color.PaleTurquoise
        Me.tRALENTI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tRALENTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRALENTI.Location = New System.Drawing.Point(134, 134)
        Me.tRALENTI.Name = "tRALENTI"
        Me.tRALENTI.Size = New System.Drawing.Size(60, 21)
        Me.tRALENTI.TabIndex = 521
        Me.tRALENTI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(52, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 15)
        Me.Label9.TabIndex = 520
        Me.Label9.Text = "Ralenti"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnAyuda
        '
        Me.BtnAyuda.Image = Global.SGT_Transport.My.Resources.Resources.help6
        Me.BtnAyuda.Location = New System.Drawing.Point(547, 128)
        Me.BtnAyuda.Name = "BtnAyuda"
        Me.BtnAyuda.Size = New System.Drawing.Size(31, 29)
        Me.BtnAyuda.TabIndex = 523
        Me.BtnAyuda.UseVisualStyleBackColor = True
        '
        'RAyuda
        '
        Me.RAyuda.BackColor = System.Drawing.Color.White
        Me.RAyuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RAyuda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RAyuda.ForeColor = System.Drawing.Color.Black
        Me.RAyuda.Location = New System.Drawing.Point(608, 48)
        Me.RAyuda.Name = "RAyuda"
        Me.RAyuda.ReadOnly = True
        Me.RAyuda.Size = New System.Drawing.Size(544, 411)
        Me.RAyuda.TabIndex = 525
        Me.RAyuda.Text = resources.GetString("RAyuda.Text")
        Me.RAyuda.Visible = False
        '
        'frmCriterioEvaAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1163, 470)
        Me.Controls.Add(Me.RAyuda)
        Me.Controls.Add(Me.BtnAyuda)
        Me.Controls.Add(Me.tRALENTI)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tFISICO_VS_ECM)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tTABULADOR)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tCVE_EVE)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.tCRITERIO)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.C1ToolBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCriterioEvaAE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Criterio evaluación"
        CType(Me.MenuHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents BarGrabr As C1.Win.C1Command.C1Command
    Friend WithEvents BarSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1ToolBar1 As C1.Win.C1Command.C1ToolBar
    Friend WithEvents LkGrabr As C1.Win.C1Command.C1CommandLink
    Friend WithEvents LkSalir As C1.Win.C1Command.C1CommandLink
    Friend WithEvents tCRITERIO As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents tCVE_EVE As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents tTABULADOR As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tFISICO_VS_ECM As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tRALENTI As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents BtnAyuda As Button
    Friend WithEvents RAyuda As RichTextBox
End Class
