<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmParamSeriesTrans
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParamSeriesTrans))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tTIP_DOC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tFOLIODESDE = New System.Windows.Forms.TextBox()
        Me.Gpo = New System.Windows.Forms.GroupBox()
        Me.tFOLIOHASTA = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancelar = New C1.Win.C1Input.C1Button()
        Me.btnAceptar = New C1.Win.C1Input.C1Button()
        Me.tSERIE = New System.Windows.Forms.TextBox()
        Me.tULTDOC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gpo.SuspendLayout()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.btnEdit, Me.btnEliminar, Me.barSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(675, 54)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'barNuevo
        '
        Me.barNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.barNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barNuevo.Name = "barNuevo"
        Me.barNuevo.Size = New System.Drawing.Size(46, 51)
        Me.barNuevo.Text = "Nuevo"
        Me.barNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.SGT_Transport.My.Resources.Resources.edit
        Me.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(36, 51)
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.SGT_Transport.My.Resources.Resources.cancelar
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 51)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barSalir
        '
        Me.barSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.barSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(36, 51)
        Me.barSalir.Text = "Salir"
        Me.barSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(5, 70)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.Count = 1
        Me.Fg.Rows.DefaultSize = 21
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.Size = New System.Drawing.Size(470, 281)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 0
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 312
        Me.Label2.Text = "Tipo doc."
        '
        'tTIP_DOC
        '
        Me.tTIP_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTIP_DOC.Location = New System.Drawing.Point(81, 37)
        Me.tTIP_DOC.Name = "tTIP_DOC"
        Me.tTIP_DOC.Size = New System.Drawing.Size(100, 21)
        Me.tTIP_DOC.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 315
        Me.Label1.Text = "Folio desde"
        '
        'tFOLIODESDE
        '
        Me.tFOLIODESDE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFOLIODESDE.Location = New System.Drawing.Point(81, 64)
        Me.tFOLIODESDE.Name = "tFOLIODESDE"
        Me.tFOLIODESDE.Size = New System.Drawing.Size(100, 21)
        Me.tFOLIODESDE.TabIndex = 1
        '
        'Gpo
        '
        Me.Gpo.Controls.Add(Me.tFOLIOHASTA)
        Me.Gpo.Controls.Add(Me.Label5)
        Me.Gpo.Controls.Add(Me.btnCancelar)
        Me.Gpo.Controls.Add(Me.tTIP_DOC)
        Me.Gpo.Controls.Add(Me.btnAceptar)
        Me.Gpo.Controls.Add(Me.tSERIE)
        Me.Gpo.Controls.Add(Me.tULTDOC)
        Me.Gpo.Controls.Add(Me.Label3)
        Me.Gpo.Controls.Add(Me.Label4)
        Me.Gpo.Controls.Add(Me.Label2)
        Me.Gpo.Controls.Add(Me.tFOLIODESDE)
        Me.Gpo.Controls.Add(Me.Label1)
        Me.Gpo.Location = New System.Drawing.Point(482, 70)
        Me.Gpo.Name = "Gpo"
        Me.Gpo.Size = New System.Drawing.Size(186, 281)
        Me.Gpo.TabIndex = 1
        Me.Gpo.TabStop = False
        Me.Gpo.Visible = False
        '
        'tFOLIOHASTA
        '
        Me.tFOLIOHASTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFOLIOHASTA.Location = New System.Drawing.Point(81, 92)
        Me.tFOLIOHASTA.Name = "tFOLIOHASTA"
        Me.tFOLIOHASTA.Size = New System.Drawing.Size(100, 21)
        Me.tFOLIOHASTA.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 323
        Me.Label5.Text = "Folio hasta"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(94, 214)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(68, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(9, 214)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(69, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Grabar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'tSERIE
        '
        Me.tSERIE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSERIE.Location = New System.Drawing.Point(81, 119)
        Me.tSERIE.Name = "tSERIE"
        Me.tSERIE.Size = New System.Drawing.Size(100, 21)
        Me.tSERIE.TabIndex = 3
        '
        'tULTDOC
        '
        Me.tULTDOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tULTDOC.Location = New System.Drawing.Point(81, 146)
        Me.tULTDOC.Name = "tULTDOC"
        Me.tULTDOC.Size = New System.Drawing.Size(100, 21)
        Me.tULTDOC.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 317
        Me.Label3.Text = "Serie"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 318
        Me.Label4.Text = "Ult. doc."
        '
        'frmParamTransport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 363)
        Me.Controls.Add(Me.Gpo)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmParamTransport"
        Me.Text = "Parámetros transportCG"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gpo.ResumeLayout(False)
        Me.Gpo.PerformLayout()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnEliminar As ToolStripButton
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents tTIP_DOC As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tFOLIODESDE As TextBox
    Friend WithEvents Gpo As GroupBox
    Friend WithEvents barNuevo As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents btnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents tSERIE As TextBox
    Friend WithEvents tULTDOC As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tFOLIOHASTA As TextBox
    Friend WithEvents Label5 As Label
End Class
