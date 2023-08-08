<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViajesAE
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
        Me.tClave = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tDescr = New System.Windows.Forms.TextBox()
        Me.Descripcin = New System.Windows.Forms.Label()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.tCVE_VIAJE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cboEstado = New C1.Win.C1Input.C1ComboBox()
        Me.tCIUDAD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(631, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 6
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
        'tClave
        '
        Me.tClave.AcceptsReturn = True
        Me.tClave.AcceptsTab = True
        Me.tClave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tClave.Location = New System.Drawing.Point(103, 97)
        Me.tClave.Name = "tClave"
        Me.tClave.Size = New System.Drawing.Size(48, 22)
        Me.tClave.TabIndex = 0
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(68, 100)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(30, 13)
        Me.Label27.TabIndex = 88
        Me.Label27.Text = "Viaje"
        '
        'tDescr
        '
        Me.tDescr.AcceptsReturn = True
        Me.tDescr.AcceptsTab = True
        Me.tDescr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescr.Location = New System.Drawing.Point(103, 151)
        Me.tDescr.Name = "tDescr"
        Me.tDescr.Size = New System.Drawing.Size(289, 22)
        Me.tDescr.TabIndex = 2
        '
        'Descripcin
        '
        Me.Descripcin.AutoSize = True
        Me.Descripcin.Location = New System.Drawing.Point(54, 154)
        Me.Descripcin.Name = "Descripcin"
        Me.Descripcin.Size = New System.Drawing.Size(44, 13)
        Me.Descripcin.TabIndex = 87
        Me.Descripcin.Text = "Nombre"
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'tCVE_VIAJE
        '
        Me.tCVE_VIAJE.AcceptsReturn = True
        Me.tCVE_VIAJE.AcceptsTab = True
        Me.tCVE_VIAJE.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCVE_VIAJE.Location = New System.Drawing.Point(103, 124)
        Me.tCVE_VIAJE.Name = "tCVE_VIAJE"
        Me.tCVE_VIAJE.Size = New System.Drawing.Size(110, 22)
        Me.tCVE_VIAJE.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Clave"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Location = New System.Drawing.Point(58, 235)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(40, 13)
        Me.Label43.TabIndex = 140
        Me.Label43.Text = "Estado"
        '
        'cboEstado
        '
        Me.cboEstado.AllowSpinLoop = False
        Me.cboEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboEstado.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboEstado.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstado.GapHeight = 0
        Me.cboEstado.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboEstado.ItemsDisplayMember = ""
        Me.cboEstado.ItemsValueMember = ""
        Me.cboEstado.Location = New System.Drawing.Point(103, 232)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(184, 20)
        Me.cboEstado.TabIndex = 5
        Me.cboEstado.Tag = Nothing
        Me.cboEstado.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.cboEstado.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'tCIUDAD
        '
        Me.tCIUDAD.AcceptsReturn = True
        Me.tCIUDAD.AcceptsTab = True
        Me.tCIUDAD.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCIUDAD.Location = New System.Drawing.Point(103, 204)
        Me.tCIUDAD.Name = "tCIUDAD"
        Me.tCIUDAD.Size = New System.Drawing.Size(289, 22)
        Me.tCIUDAD.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 142
        Me.Label2.Text = "Ciudad"
        '
        'F1
        '
        Me.F1.AllowSpinLoop = False
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(103, 178)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(289, 20)
        Me.F1.TabIndex = 3
        Me.F1.Tag = Nothing
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Black
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(35, 181)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "Fecha/hora"
        '
        'frmViajesAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 296)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tCIUDAD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.tCVE_VIAJE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tClave)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tDescr)
        Me.Controls.Add(Me.Descripcin)
        Me.Controls.Add(Me.barSalir)
        Me.Name = "frmViajesAE"
        Me.Text = "Viajes"
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barGrabar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents tClave As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tDescr As TextBox
    Friend WithEvents Descripcin As Label
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents tCVE_VIAJE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents cboEstado As C1.Win.C1Input.C1ComboBox
    Friend WithEvents tCIUDAD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label14 As Label
End Class
