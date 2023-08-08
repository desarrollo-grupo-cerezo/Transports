<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParamClientes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParamClientes))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.barGrabar = New System.Windows.Forms.ToolStripButton()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TSERIE_CLIENTE = New SGT_Transport.TextBoxEx()
        Me.ChClaveCteSecuencial = New C1.Win.C1Input.C1CheckBox()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.BtnEliminar = New C1.Win.C1Input.C1Button()
        Me.BtnAgregar = New C1.Win.C1Input.C1Button()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab1.SuspendLayout()
        Me.Pag1.SuspendLayout()
        CType(Me.ChClaveCteSecuencial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag2.SuspendLayout()
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAgregar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barGrabar, Me.barSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(675, 54)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'barGrabar
        '
        Me.barGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.barGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.barGrabar.Name = "barGrabar"
        Me.barGrabar.Size = New System.Drawing.Size(46, 51)
        Me.barGrabar.Text = "Grabar"
        Me.barGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'C1DockingTab1
        '
        Me.C1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.C1DockingTab1.Controls.Add(Me.Pag1)
        Me.C1DockingTab1.Controls.Add(Me.Pag2)
        Me.C1DockingTab1.HotTrack = True
        Me.C1DockingTab1.Location = New System.Drawing.Point(12, 57)
        Me.C1DockingTab1.Name = "C1DockingTab1"
        Me.C1DockingTab1.Size = New System.Drawing.Size(651, 340)
        Me.C1DockingTab1.TabIndex = 4
        Me.C1DockingTab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.C1DockingTab1.TabsShowFocusCues = False
        Me.C1DockingTab1.TabsSpacing = 2
        Me.C1DockingTab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.C1DockingTab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'Pag1
        '
        Me.Pag1.Controls.Add(Me.Label11)
        Me.Pag1.Controls.Add(Me.TSERIE_CLIENTE)
        Me.Pag1.Controls.Add(Me.ChClaveCteSecuencial)
        Me.Pag1.Location = New System.Drawing.Point(1, 24)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(649, 315)
        Me.Pag1.TabIndex = 1
        Me.Pag1.Text = "Generales"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(275, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 15)
        Me.Label11.TabIndex = 328
        Me.Label11.Text = "Serie"
        '
        'TSERIE_CLIENTE
        '
        Me.TSERIE_CLIENTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TSERIE_CLIENTE.Location = New System.Drawing.Point(317, 34)
        Me.TSERIE_CLIENTE.Name = "TSERIE_CLIENTE"
        Me.TSERIE_CLIENTE.Size = New System.Drawing.Size(79, 20)
        Me.TSERIE_CLIENTE.TabIndex = 327
        '
        'ChClaveCteSecuencial
        '
        Me.ChClaveCteSecuencial.BackColor = System.Drawing.Color.Transparent
        Me.ChClaveCteSecuencial.BorderColor = System.Drawing.Color.Transparent
        Me.ChClaveCteSecuencial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ChClaveCteSecuencial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChClaveCteSecuencial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChClaveCteSecuencial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.ChClaveCteSecuencial.Location = New System.Drawing.Point(29, 34)
        Me.ChClaveCteSecuencial.Name = "ChClaveCteSecuencial"
        Me.ChClaveCteSecuencial.Padding = New System.Windows.Forms.Padding(4, 1, 1, 1)
        Me.ChClaveCteSecuencial.Size = New System.Drawing.Size(205, 22)
        Me.ChClaveCteSecuencial.TabIndex = 1
        Me.ChClaveCteSecuencial.Text = "Clave del cliente secuencial"
        Me.ChClaveCteSecuencial.UseVisualStyleBackColor = True
        Me.ChClaveCteSecuencial.Value = Nothing
        Me.ChClaveCteSecuencial.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Pag2
        '
        Me.Pag2.Controls.Add(Me.BtnEliminar)
        Me.Pag2.Controls.Add(Me.BtnAgregar)
        Me.Pag2.Controls.Add(Me.Fg)
        Me.Pag2.Location = New System.Drawing.Point(1, 24)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(649, 315)
        Me.Pag2.TabIndex = 0
        Me.Pag2.Text = "Campos libres"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Location = New System.Drawing.Point(351, 267)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(75, 30)
        Me.BtnEliminar.TabIndex = 6
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = True
        Me.BtnEliminar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.Location = New System.Drawing.Point(188, 267)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(75, 30)
        Me.BtnAgregar.TabIndex = 5
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        Me.BtnAgregar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Fg
        '
        Me.Fg.AllowFiltering = True
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.Location = New System.Drawing.Point(3, 3)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(643, 240)
        Me.Fg.TabIndex = 15
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'FrmParamClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 418)
        Me.Controls.Add(Me.C1DockingTab1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmParamClientes"
        Me.Text = "Parametros clientes"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTab1.ResumeLayout(False)
        Me.Pag1.ResumeLayout(False)
        Me.Pag1.PerformLayout()
        CType(Me.ChClaveCteSecuencial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag2.ResumeLayout(False)
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAgregar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents barGrabar As ToolStripButton
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BtnAgregar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnEliminar As C1.Win.C1Input.C1Button
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents ChClaveCteSecuencial As C1.Win.C1Input.C1CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TSERIE_CLIENTE As TextBoxEx
End Class
