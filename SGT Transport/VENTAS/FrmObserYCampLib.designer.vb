<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmObserYCampLib
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmObserYCampLib))
        Me.TObser = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.SplitM = New C1.Win.C1SplitContainer.C1SplitContainer()
        Me.Split1 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Split2 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Split3 = New C1.Win.C1SplitContainer.C1SplitterPanel()
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitM.SuspendLayout()
        Me.Split1.SuspendLayout()
        Me.Split2.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TObser
        '
        Me.TObser.AcceptsReturn = True
        Me.TObser.Location = New System.Drawing.Point(0, 0)
        Me.TObser.Multiline = True
        Me.TObser.Name = "TObser"
        Me.TObser.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TObser.Size = New System.Drawing.Size(558, 108)
        Me.TObser.TabIndex = 2
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(363, 8)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(89, 26)
        Me.BtnCancelar.TabIndex = 9
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(216, 8)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(89, 26)
        Me.BtnAceptar.TabIndex = 8
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'SplitM
        '
        Me.SplitM.AutoSizeElement = C1.Framework.AutoSizeElement.Both
        Me.SplitM.BackColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.SplitM.BorderWidth = 1
        Me.SplitM.CollapsingAreaColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SplitM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitM.FixedLineColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.SplitM.Location = New System.Drawing.Point(0, 0)
        Me.SplitM.Name = "SplitM"
        Me.SplitM.Panels.Add(Me.Split1)
        Me.SplitM.Panels.Add(Me.Split2)
        Me.SplitM.Panels.Add(Me.Split3)
        Me.SplitM.Size = New System.Drawing.Size(708, 302)
        Me.SplitM.SplitterColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.SplitM.TabIndex = 0
        Me.SplitM.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue
        '
        'Split1
        '
        Me.Split1.BorderColor = System.Drawing.Color.Black
        Me.Split1.Controls.Add(Me.TObser)
        Me.Split1.Height = 122
        Me.Split1.Location = New System.Drawing.Point(1, 1)
        Me.Split1.Name = "Split1"
        Me.Split1.Size = New System.Drawing.Size(706, 122)
        Me.Split1.SizeRatio = 41.216R
        Me.Split1.TabIndex = 1
        '
        'Split2
        '
        Me.Split2.BorderColor = System.Drawing.Color.Black
        Me.Split2.Controls.Add(Me.Fg)
        Me.Split2.Height = 130
        Me.Split2.Location = New System.Drawing.Point(1, 127)
        Me.Split2.Name = "Split2"
        Me.Split2.Size = New System.Drawing.Size(706, 130)
        Me.Split2.SizeRatio = 76.471R
        Me.Split2.TabIndex = 3
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveDown
        Me.Fg.Location = New System.Drawing.Point(0, 0)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.Fg.ShowCursor = True
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(558, 130)
        Me.Fg.TabIndex = 6
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'Split3
        '
        Me.Split3.Controls.Add(Me.BtnCancelar)
        Me.Split3.Controls.Add(Me.BtnAceptar)
        Me.Split3.Height = 40
        Me.Split3.Location = New System.Drawing.Point(1, 261)
        Me.Split3.Name = "Split3"
        Me.Split3.Size = New System.Drawing.Size(706, 40)
        Me.Split3.TabIndex = 7
        '
        'FrmObserYCampLib
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 302)
        Me.Controls.Add(Me.SplitM)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FrmObserYCampLib"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observaciones documento"
        CType(Me.SplitM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitM.ResumeLayout(False)
        Me.Split1.ResumeLayout(False)
        Me.Split1.PerformLayout()
        Me.Split2.ResumeLayout(False)
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TObser As TextBox
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents SplitM As C1.Win.C1SplitContainer.C1SplitContainer
    Friend WithEvents Split1 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split2 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Split3 As C1.Win.C1SplitContainer.C1SplitterPanel
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
