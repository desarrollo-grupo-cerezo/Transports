<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParamOPciones
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParamOPciones))
        Me.Tab1 = New C1.Win.C1Command.C1DockingTab()
        Me.PagGenerales = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagInvent = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagCompras = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagClientes = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagProv = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagFE = New C1.Win.C1Command.C1DockingTabPage()
        Me.PagVentas = New C1.Win.C1Command.C1DockingTabPage()
        Me.Tab2 = New C1.Win.C1Command.C1DockingTab()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.Split2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab1.CloseBox = C1.Win.C1Command.CloseBoxPositionEnum.ActivePage
        Me.Tab1.Controls.Add(Me.PagGenerales)
        Me.Tab1.Controls.Add(Me.PagInvent)
        Me.Tab1.Controls.Add(Me.PagCompras)
        Me.Tab1.Controls.Add(Me.PagClientes)
        Me.Tab1.Controls.Add(Me.PagProv)
        Me.Tab1.Controls.Add(Me.PagFE)
        Me.Tab1.Controls.Add(Me.PagVentas)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab1.HotTrack = True
        Me.Tab1.ItemSize = New System.Drawing.Size(140, 40)
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.MultiLine = True
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedIndex = 7
        Me.Tab1.SelectedTabBold = True
        Me.Tab1.Size = New System.Drawing.Size(720, 99)
        Me.Tab1.SplitterWidth = 1
        Me.Tab1.TabAreaBorder = True
        Me.Tab1.TabAreaSpacing = 10
        Me.Tab1.TabIndex = 1
        Me.Tab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab1.TabsShowFocusCues = False
        Me.Tab1.TabsSpacing = 2
        Me.Tab1.TabTextAlignment = System.Drawing.StringAlignment.Center
        Me.Tab1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.Tab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'PagGenerales
        '
        Me.PagGenerales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PagGenerales.CausesValidation = False
        Me.PagGenerales.Location = New System.Drawing.Point(1, 91)
        Me.PagGenerales.Name = "PagGenerales"
        Me.PagGenerales.Size = New System.Drawing.Size(718, 7)
        Me.PagGenerales.TabIndex = 0
        Me.PagGenerales.Text = "Generales"
        '
        'PagInvent
        '
        Me.PagInvent.Location = New System.Drawing.Point(1, 91)
        Me.PagInvent.Name = "PagInvent"
        Me.PagInvent.Size = New System.Drawing.Size(718, 7)
        Me.PagInvent.TabIndex = 1
        Me.PagInvent.Text = "Inventario"
        '
        'PagCompras
        '
        Me.PagCompras.Location = New System.Drawing.Point(1, 91)
        Me.PagCompras.Name = "PagCompras"
        Me.PagCompras.Size = New System.Drawing.Size(718, 7)
        Me.PagCompras.TabIndex = 3
        Me.PagCompras.Text = "Compras"
        '
        'PagClientes
        '
        Me.PagClientes.Location = New System.Drawing.Point(1, 91)
        Me.PagClientes.Name = "PagClientes"
        Me.PagClientes.Size = New System.Drawing.Size(718, 7)
        Me.PagClientes.TabIndex = 4
        Me.PagClientes.Text = "Clientes"
        '
        'PagProv
        '
        Me.PagProv.Location = New System.Drawing.Point(1, 91)
        Me.PagProv.Name = "PagProv"
        Me.PagProv.Size = New System.Drawing.Size(718, 7)
        Me.PagProv.TabIndex = 5
        Me.PagProv.Text = "Proveedores"
        '
        'PagFE
        '
        Me.PagFE.Location = New System.Drawing.Point(1, 91)
        Me.PagFE.Name = "PagFE"
        Me.PagFE.Size = New System.Drawing.Size(718, 7)
        Me.PagFE.TabIndex = 6
        Me.PagFE.Text = "Factura elentrónica"
        '
        'PagVentas
        '
        Me.PagVentas.Location = New System.Drawing.Point(1, 91)
        Me.PagVentas.Name = "PagVentas"
        Me.PagVentas.Size = New System.Drawing.Size(718, 7)
        Me.PagVentas.TabIndex = 7
        Me.PagVentas.Text = "Ventas"
        '
        'Tab2
        '
        Me.Tab2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab2.CanCloseTabs = True
        Me.Tab2.CanMoveTabs = True
        Me.Tab2.CloseBox = C1.Win.C1Command.CloseBoxPositionEnum.AllPages
        Me.Tab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab2.HotTrack = True
        Me.Tab2.Location = New System.Drawing.Point(0, 0)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.SelectedTabBold = True
        Me.Tab2.ShowCaption = True
        Me.Tab2.ShowTabList = True
        Me.Tab2.ShowTabs = False
        Me.Tab2.ShowToolTips = True
        Me.Tab2.Size = New System.Drawing.Size(720, 472)
        Me.Tab2.SplitterWidth = 1
        Me.Tab2.TabIndex = 0
        Me.Tab2.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.Tab2.TabsShowFocusCues = False
        Me.Tab2.TabsSpacing = 2
        Me.Tab2.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        Me.Tab2.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitM.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(0, 0)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.Split1)
        Me.SplitM.Panels.Add(Me.Split2)
        Me.SplitM.Size = New System.Drawing.Size(720, 575)
        Me.SplitM.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.SplitM.TabIndex = 2
        Me.SplitM.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        Me.SplitM.UseParentVisualStyle = False
        '
        'Split1
        '
        Me.Split1.Controls.Add(Me.Tab1)
        Me.Split1.Height = 99
        Me.Split1.Location = New System.Drawing.Point(0, 0)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(720, 99)
        Me.Split1.SizeRatio = 17.326R
        Me.Split1.TabIndex = 0
        '
        'Split2
        '
        Me.Split2.Controls.Add(Me.Tab2)
        Me.Split2.Height = 472
        Me.Split2.Location = New System.Drawing.Point(0, 103)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(720, 472)
        Me.Split2.TabIndex = 1
        '
        'FrmParamOPciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 575)
        Me.Controls.Add(Me.SplitM)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParamOPciones"
        Me.Text = "Parametros de configuración"
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents PagGenerales As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagInvent As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagCompras As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagClientes As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagProv As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents PagFE As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents Tab2 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents PagVentas As C1.Win.C1Command.C1DockingTabPage
End Class
