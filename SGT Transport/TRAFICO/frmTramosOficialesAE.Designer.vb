<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTramosOficialesAE
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
        Me.components = New System.ComponentModel.Container()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tCVE_TOF = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tRPD = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tRUTA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tCLASE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tALERTAS = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tKMS = New C1.Win.C1Input.C1NumericEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.tKMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(632, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 8
        Me.barSalir.Text = "MenuStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.barGrabar.ForeColor = System.Drawing.Color.White
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
        Me.mnuSalir.ForeColor = System.Drawing.Color.White
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tCVE_TOF
        '
        Me.tCVE_TOF.AcceptsReturn = True
        Me.tCVE_TOF.AcceptsTab = True
        Me.tCVE_TOF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_TOF.Location = New System.Drawing.Point(118, 80)
        Me.tCVE_TOF.Name = "tCVE_TOF"
        Me.tCVE_TOF.Size = New System.Drawing.Size(110, 21)
        Me.tCVE_TOF.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(79, 83)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 116
        Me.Label27.Text = "Clave"
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.Location = New System.Drawing.Point(118, 140)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(436, 21)
        Me.tDescr.TabIndex = 2
        '
        'Nombre
        '
        Me.Nombre.AutoSize = True
        Me.Nombre.Location = New System.Drawing.Point(69, 144)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(44, 13)
        Me.Nombre.TabIndex = 115
        Me.Nombre.Text = "Nombre"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'tRPD
        '
        Me.tRPD.AcceptsReturn = True
        Me.tRPD.AcceptsTab = True
        Me.tRPD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRPD.Location = New System.Drawing.Point(118, 170)
        Me.tRPD.Name = "tRPD"
        Me.tRPD.Size = New System.Drawing.Size(110, 21)
        Me.tRPD.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(83, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "RPD"
        '
        'tRUTA
        '
        Me.tRUTA.AcceptsReturn = True
        Me.tRUTA.AcceptsTab = True
        Me.tRUTA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tRUTA.Location = New System.Drawing.Point(118, 200)
        Me.tRUTA.Name = "tRUTA"
        Me.tRUTA.Size = New System.Drawing.Size(110, 21)
        Me.tRUTA.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Ruta"
        '
        'tCLASE
        '
        Me.tCLASE.AcceptsReturn = True
        Me.tCLASE.AcceptsTab = True
        Me.tCLASE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCLASE.Location = New System.Drawing.Point(118, 230)
        Me.tCLASE.Name = "tCLASE"
        Me.tCLASE.Size = New System.Drawing.Size(110, 21)
        Me.tCLASE.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 234)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Clas"
        '
        'tALERTAS
        '
        Me.tALERTAS.AcceptsReturn = True
        Me.tALERTAS.AcceptsTab = True
        Me.tALERTAS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tALERTAS.Location = New System.Drawing.Point(118, 290)
        Me.tALERTAS.Name = "tALERTAS"
        Me.tALERTAS.Size = New System.Drawing.Size(289, 21)
        Me.tALERTAS.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(74, 293)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Alertas"
        '
        'tKMS
        '
        Me.tKMS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.tKMS.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tKMS.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.tKMS.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.tKMS.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.tKMS.Location = New System.Drawing.Point(118, 260)
        Me.tKMS.Name = "tKMS"
        Me.tKMS.Size = New System.Drawing.Size(110, 18)
        Me.tKMS.TabIndex = 6
        Me.tKMS.Tag = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Kilometros"
        '
        'frmTramosOficialesAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 342)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tKMS)
        Me.Controls.Add(Me.tALERTAS)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tCLASE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tRUTA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tRPD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tCVE_TOF)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(Me.barSalir)
        Me.Name = "frmTramosOficialesAE"
        Me.Text = "Rutas Oficiales"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.tKMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tCVE_TOF As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tDescr As TextBox
    Friend WithEvents Nombre As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tRPD As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tRUTA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tCLASE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tALERTAS As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tKMS As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label5 As Label
End Class
