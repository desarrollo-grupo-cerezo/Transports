<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmParamOpcVentas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.Pag1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Pag2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.C1CheckBox5 = New C1.Win.C1Input.C1CheckBox()
        Me.C1CheckBox1 = New C1.Win.C1Input.C1CheckBox()
        Me.C1CheckBox4 = New C1.Win.C1Input.C1CheckBox()
        Me.C1CheckBox2 = New C1.Win.C1Input.C1CheckBox()
        Me.C1CheckBox3 = New C1.Win.C1Input.C1CheckBox()
        Me.ChObser_x_doc = New C1.Win.C1Input.C1CheckBox()
        Me.Pag3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Pag4 = New C1.Win.C1Command.C1DockingTabPage()
        Me.chALMACEN = New C1.Win.C1Input.C1CheckBox()
        Me.chOBSER_X_PARTIDA = New C1.Win.C1Input.C1CheckBox()
        Me.chIMPUESTOS = New C1.Win.C1Input.C1CheckBox()
        Me.chINDIRECTOS_X_PARTIDA = New C1.Win.C1Input.C1CheckBox()
        Me.Pag5 = New C1.Win.C1Command.C1DockingTabPage()
        Me.tARTICULO = New System.Windows.Forms.TextBox()
        Me.BarGrabar = New System.Windows.Forms.ToolStripButton()
        Me.BarSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.Pag2.SuspendLayout()
        CType(Me.C1CheckBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CheckBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CheckBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CheckBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CheckBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChObser_x_doc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pag4.SuspendLayout()
        CType(Me.chALMACEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chOBSER_X_PARTIDA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chIMPUESTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chINDIRECTOS_X_PARTIDA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.CanCloseTabs = True
        Me.Tab1.CanMoveTabs = True
        Me.Tab1.CloseBox = C1.Win.C1Command.CloseBoxPositionEnum.ActivePage
        Me.Tab1.Controls.Add(Me.Pag1)
        Me.Tab1.Controls.Add(Me.Pag2)
        Me.Tab1.Controls.Add(Me.Pag3)
        Me.Tab1.Controls.Add(Me.Pag4)
        Me.Tab1.Controls.Add(Me.Pag5)
        Me.Tab1.HotTrack = True
        Me.Tab1.Location = New System.Drawing.Point(0, 54)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedTabBold = True
        Me.Tab1.ShowTabList = True
        Me.Tab1.Size = New System.Drawing.Size(689, 344)
        Me.Tab1.TabIndex = 1
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2010Blue
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'Pag1
        '
        Me.Pag1.Location = New System.Drawing.Point(1, 24)
        Me.Pag1.Name = "Pag1"
        Me.Pag1.Size = New System.Drawing.Size(687, 319)
        Me.Pag1.TabIndex = 0
        Me.Pag1.Text = "Generales"
        '
        'Pag2
        '
        Me.Pag2.Controls.Add(Me.C1CheckBox5)
        Me.Pag2.Controls.Add(Me.C1CheckBox1)
        Me.Pag2.Controls.Add(Me.C1CheckBox4)
        Me.Pag2.Controls.Add(Me.C1CheckBox2)
        Me.Pag2.Controls.Add(Me.C1CheckBox3)
        Me.Pag2.Controls.Add(Me.ChObser_x_doc)
        Me.Pag2.Location = New System.Drawing.Point(1, 24)
        Me.Pag2.Name = "Pag2"
        Me.Pag2.Size = New System.Drawing.Size(687, 319)
        Me.Pag2.TabIndex = 1
        Me.Pag2.Text = "Punto de venta"
        '
        'C1CheckBox5
        '
        Me.C1CheckBox5.BackColor = System.Drawing.Color.Transparent
        Me.C1CheckBox5.BorderColor = System.Drawing.Color.Transparent
        Me.C1CheckBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1CheckBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.C1CheckBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1CheckBox5.ForeColor = System.Drawing.Color.Black
        Me.C1CheckBox5.Location = New System.Drawing.Point(11, 10)
        Me.C1CheckBox5.Name = "C1CheckBox5"
        Me.C1CheckBox5.Padding = New System.Windows.Forms.Padding(1)
        Me.C1CheckBox5.Size = New System.Drawing.Size(246, 22)
        Me.C1CheckBox5.TabIndex = 319
        Me.C1CheckBox5.Text = "Vender sin existencias"
        Me.C1CheckBox5.UseVisualStyleBackColor = True
        Me.C1CheckBox5.Value = Nothing
        Me.C1CheckBox5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1CheckBox1
        '
        Me.C1CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.C1CheckBox1.BorderColor = System.Drawing.Color.Transparent
        Me.C1CheckBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.C1CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.C1CheckBox1.Location = New System.Drawing.Point(11, 116)
        Me.C1CheckBox1.Name = "C1CheckBox1"
        Me.C1CheckBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.C1CheckBox1.Size = New System.Drawing.Size(246, 22)
        Me.C1CheckBox1.TabIndex = 318
        Me.C1CheckBox1.Text = "Alta de cliente"
        Me.C1CheckBox1.UseVisualStyleBackColor = True
        Me.C1CheckBox1.Value = Nothing
        Me.C1CheckBox1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1CheckBox4
        '
        Me.C1CheckBox4.BackColor = System.Drawing.Color.Transparent
        Me.C1CheckBox4.BorderColor = System.Drawing.Color.Transparent
        Me.C1CheckBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1CheckBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.C1CheckBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1CheckBox4.ForeColor = System.Drawing.Color.Black
        Me.C1CheckBox4.Location = New System.Drawing.Point(11, 142)
        Me.C1CheckBox4.Name = "C1CheckBox4"
        Me.C1CheckBox4.Padding = New System.Windows.Forms.Padding(1)
        Me.C1CheckBox4.Size = New System.Drawing.Size(246, 22)
        Me.C1CheckBox4.TabIndex = 317
        Me.C1CheckBox4.Text = "Alta de productos"
        Me.C1CheckBox4.UseVisualStyleBackColor = True
        Me.C1CheckBox4.Value = Nothing
        Me.C1CheckBox4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1CheckBox2
        '
        Me.C1CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.C1CheckBox2.BorderColor = System.Drawing.Color.Transparent
        Me.C1CheckBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.C1CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1CheckBox2.ForeColor = System.Drawing.Color.Black
        Me.C1CheckBox2.Location = New System.Drawing.Point(11, 64)
        Me.C1CheckBox2.Name = "C1CheckBox2"
        Me.C1CheckBox2.Padding = New System.Windows.Forms.Padding(1)
        Me.C1CheckBox2.Size = New System.Drawing.Size(246, 22)
        Me.C1CheckBox2.TabIndex = 316
        Me.C1CheckBox2.Text = "Permirir vender abajo del costo"
        Me.C1CheckBox2.UseVisualStyleBackColor = True
        Me.C1CheckBox2.Value = Nothing
        Me.C1CheckBox2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'C1CheckBox3
        '
        Me.C1CheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.C1CheckBox3.BorderColor = System.Drawing.Color.Transparent
        Me.C1CheckBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.C1CheckBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1CheckBox3.ForeColor = System.Drawing.Color.Black
        Me.C1CheckBox3.Location = New System.Drawing.Point(11, 90)
        Me.C1CheckBox3.Name = "C1CheckBox3"
        Me.C1CheckBox3.Padding = New System.Windows.Forms.Padding(1)
        Me.C1CheckBox3.Size = New System.Drawing.Size(246, 22)
        Me.C1CheckBox3.TabIndex = 315
        Me.C1CheckBox3.Text = "Permiri vender abajo del mínimo"
        Me.C1CheckBox3.UseVisualStyleBackColor = True
        Me.C1CheckBox3.Value = Nothing
        Me.C1CheckBox3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'ChObser_x_doc
        '
        Me.ChObser_x_doc.BackColor = System.Drawing.Color.Transparent
        Me.ChObser_x_doc.BorderColor = System.Drawing.Color.Transparent
        Me.ChObser_x_doc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChObser_x_doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChObser_x_doc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChObser_x_doc.ForeColor = System.Drawing.Color.Black
        Me.ChObser_x_doc.Location = New System.Drawing.Point(11, 38)
        Me.ChObser_x_doc.Name = "ChObser_x_doc"
        Me.ChObser_x_doc.Padding = New System.Windows.Forms.Padding(1)
        Me.ChObser_x_doc.Size = New System.Drawing.Size(246, 22)
        Me.ChObser_x_doc.TabIndex = 9
        Me.ChObser_x_doc.Text = "Artículos con impuesto incluido"
        Me.ChObser_x_doc.UseVisualStyleBackColor = True
        Me.ChObser_x_doc.Value = Nothing
        Me.ChObser_x_doc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Pag3
        '
        Me.Pag3.Location = New System.Drawing.Point(1, 24)
        Me.Pag3.Name = "Pag3"
        Me.Pag3.Size = New System.Drawing.Size(687, 319)
        Me.Pag3.TabIndex = 2
        Me.Pag3.Text = "Folios"
        '
        'Pag4
        '
        Me.Pag4.Controls.Add(Me.chALMACEN)
        Me.Pag4.Controls.Add(Me.chOBSER_X_PARTIDA)
        Me.Pag4.Controls.Add(Me.chIMPUESTOS)
        Me.Pag4.Controls.Add(Me.chINDIRECTOS_X_PARTIDA)
        Me.Pag4.Location = New System.Drawing.Point(1, 24)
        Me.Pag4.Name = "Pag4"
        Me.Pag4.Size = New System.Drawing.Size(687, 319)
        Me.Pag4.TabIndex = 3
        Me.Pag4.Text = "Por partida"
        '
        'chALMACEN
        '
        Me.chALMACEN.BackColor = System.Drawing.Color.Transparent
        Me.chALMACEN.BorderColor = System.Drawing.Color.Transparent
        Me.chALMACEN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chALMACEN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chALMACEN.ForeColor = System.Drawing.Color.Black
        Me.chALMACEN.Location = New System.Drawing.Point(28, 109)
        Me.chALMACEN.Name = "chALMACEN"
        Me.chALMACEN.Padding = New System.Windows.Forms.Padding(1)
        Me.chALMACEN.Size = New System.Drawing.Size(179, 20)
        Me.chALMACEN.TabIndex = 9
        Me.chALMACEN.Text = "Almacén"
        Me.chALMACEN.UseVisualStyleBackColor = True
        Me.chALMACEN.Value = Nothing
        Me.chALMACEN.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'chOBSER_X_PARTIDA
        '
        Me.chOBSER_X_PARTIDA.BackColor = System.Drawing.Color.Transparent
        Me.chOBSER_X_PARTIDA.BorderColor = System.Drawing.Color.Transparent
        Me.chOBSER_X_PARTIDA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chOBSER_X_PARTIDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chOBSER_X_PARTIDA.ForeColor = System.Drawing.Color.Black
        Me.chOBSER_X_PARTIDA.Location = New System.Drawing.Point(28, 31)
        Me.chOBSER_X_PARTIDA.Name = "chOBSER_X_PARTIDA"
        Me.chOBSER_X_PARTIDA.Padding = New System.Windows.Forms.Padding(1)
        Me.chOBSER_X_PARTIDA.Size = New System.Drawing.Size(221, 20)
        Me.chOBSER_X_PARTIDA.TabIndex = 8
        Me.chOBSER_X_PARTIDA.Text = "Observaciones y campos libres"
        Me.chOBSER_X_PARTIDA.UseVisualStyleBackColor = True
        Me.chOBSER_X_PARTIDA.Value = Nothing
        Me.chOBSER_X_PARTIDA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'chIMPUESTOS
        '
        Me.chIMPUESTOS.BackColor = System.Drawing.Color.Transparent
        Me.chIMPUESTOS.BorderColor = System.Drawing.Color.Transparent
        Me.chIMPUESTOS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chIMPUESTOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chIMPUESTOS.ForeColor = System.Drawing.Color.Black
        Me.chIMPUESTOS.Location = New System.Drawing.Point(28, 83)
        Me.chIMPUESTOS.Name = "chIMPUESTOS"
        Me.chIMPUESTOS.Padding = New System.Windows.Forms.Padding(1)
        Me.chIMPUESTOS.Size = New System.Drawing.Size(179, 20)
        Me.chIMPUESTOS.TabIndex = 6
        Me.chIMPUESTOS.Text = "Impuestos"
        Me.chIMPUESTOS.UseVisualStyleBackColor = True
        Me.chIMPUESTOS.Value = Nothing
        Me.chIMPUESTOS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'chINDIRECTOS_X_PARTIDA
        '
        Me.chINDIRECTOS_X_PARTIDA.BackColor = System.Drawing.Color.Transparent
        Me.chINDIRECTOS_X_PARTIDA.BorderColor = System.Drawing.Color.Transparent
        Me.chINDIRECTOS_X_PARTIDA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chINDIRECTOS_X_PARTIDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chINDIRECTOS_X_PARTIDA.ForeColor = System.Drawing.Color.Black
        Me.chINDIRECTOS_X_PARTIDA.Location = New System.Drawing.Point(28, 57)
        Me.chINDIRECTOS_X_PARTIDA.Name = "chINDIRECTOS_X_PARTIDA"
        Me.chINDIRECTOS_X_PARTIDA.Padding = New System.Windows.Forms.Padding(1)
        Me.chINDIRECTOS_X_PARTIDA.Size = New System.Drawing.Size(179, 20)
        Me.chINDIRECTOS_X_PARTIDA.TabIndex = 7
        Me.chINDIRECTOS_X_PARTIDA.Text = "Indirectos por partida"
        Me.chINDIRECTOS_X_PARTIDA.UseVisualStyleBackColor = True
        Me.chINDIRECTOS_X_PARTIDA.Value = Nothing
        Me.chINDIRECTOS_X_PARTIDA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Pag5
        '
        Me.Pag5.Location = New System.Drawing.Point(1, 24)
        Me.Pag5.Name = "Pag5"
        Me.Pag5.Size = New System.Drawing.Size(687, 319)
        Me.Pag5.TabIndex = 4
        Me.Pag5.Text = "Campos libres"
        '
        'tARTICULO
        '
        Me.tARTICULO.Location = New System.Drawing.Point(0, 0)
        Me.tARTICULO.Name = "tARTICULO"
        Me.tARTICULO.Size = New System.Drawing.Size(100, 20)
        Me.tARTICULO.TabIndex = 0
        '
        'BarGrabar
        '
        Me.BarGrabar.Image = Global.SGT_Transport.My.Resources.Resources.salvar
        Me.BarGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarGrabar.Name = "BarGrabar"
        Me.BarGrabar.Size = New System.Drawing.Size(46, 51)
        Me.BarGrabar.Text = "Grabar"
        Me.BarGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarSalir
        '
        Me.BarSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.BarSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarSalir.Name = "BarSalir"
        Me.BarSalir.Size = New System.Drawing.Size(36, 51)
        Me.BarSalir.Text = "Salir"
        Me.BarSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarGrabar, Me.BarSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(692, 54)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'FrmParamOpcVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 405)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Tab1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmParamOpcVentas"
        Me.ShowInTaskbar = False
        Me.Text = "ACUM_VTAS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Pag2.ResumeLayout(False)
        CType(Me.C1CheckBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CheckBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CheckBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CheckBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CheckBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChObser_x_doc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pag4.ResumeLayout(False)
        CType(Me.chALMACEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chOBSER_X_PARTIDA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chIMPUESTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chINDIRECTOS_X_PARTIDA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents Pag2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Pag4 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents chALMACEN As C1.Win.C1Input.C1CheckBox
    Friend WithEvents chOBSER_X_PARTIDA As C1.Win.C1Input.C1CheckBox
    Friend WithEvents chIMPUESTOS As C1.Win.C1Input.C1CheckBox
    Friend WithEvents chINDIRECTOS_X_PARTIDA As C1.Win.C1Input.C1CheckBox
    Friend WithEvents Pag5 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents ChObser_x_doc As C1.Win.C1Input.C1CheckBox
    Friend WithEvents tARTICULO As TextBox
    Friend WithEvents BarGrabar As ToolStripButton
    Friend WithEvents BarSalir As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Pag1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1CheckBox2 As C1.Win.C1Input.C1CheckBox
    Friend WithEvents C1CheckBox3 As C1.Win.C1Input.C1CheckBox
    Friend WithEvents C1CheckBox1 As C1.Win.C1Input.C1CheckBox
    Friend WithEvents C1CheckBox4 As C1.Win.C1Input.C1CheckBox
    Friend WithEvents C1CheckBox5 As C1.Win.C1Input.C1CheckBox
End Class
