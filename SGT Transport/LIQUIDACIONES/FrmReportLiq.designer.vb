<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportLiq
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportLiq))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FD2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FD1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FC2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FC1 = New C1.Win.Calendar.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BarImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.barSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.FD2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FD1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FC2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FC1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(168, 223)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 16)
        Me.Label7.TabIndex = 197
        Me.Label7.Text = "Por fecha de descarga"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(232, 255)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 16)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = "al"
        '
        'FD2
        '
        Me.FD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FD2.Calendar.ClearText = "&Limpiar"
        Me.FD2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FD2.Calendar.TodayText = "&Hoy"
        Me.FD2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FD2.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.FD2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FD2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.FD2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FD2.Location = New System.Drawing.Point(277, 253)
        Me.FD2.Name = "FD2"
        Me.FD2.Size = New System.Drawing.Size(122, 20)
        Me.FD2.TabIndex = 195
        Me.FD2.Tag = Nothing
        Me.FD2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FD2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(56, 255)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 16)
        Me.Label9.TabIndex = 194
        Me.Label9.Text = "Del"
        '
        'FD1
        '
        Me.FD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FD1.Calendar.ClearText = "&Limpiar"
        Me.FD1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FD1.Calendar.TodayText = "&Hoy"
        Me.FD1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FD1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.FD1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FD1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.FD1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FD1.Location = New System.Drawing.Point(87, 253)
        Me.FD1.Name = "FD1"
        Me.FD1.Size = New System.Drawing.Size(122, 20)
        Me.FD1.TabIndex = 193
        Me.FD1.Tag = Nothing
        Me.FD1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FD1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FD1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(168, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 16)
        Me.Label4.TabIndex = 192
        Me.Label4.Text = "Por fecha de carga"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(232, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 16)
        Me.Label5.TabIndex = 191
        Me.Label5.Text = "al"
        '
        'FC2
        '
        Me.FC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FC2.Calendar.ClearText = "&Limpiar"
        Me.FC2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FC2.Calendar.TodayText = "&Hoy"
        Me.FC2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FC2.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.FC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FC2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.FC2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FC2.Location = New System.Drawing.Point(277, 184)
        Me.FC2.Name = "FC2"
        Me.FC2.Size = New System.Drawing.Size(122, 20)
        Me.FC2.TabIndex = 190
        Me.FC2.Tag = Nothing
        Me.FC2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FC2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(56, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 16)
        Me.Label6.TabIndex = 189
        Me.Label6.Text = "Del"
        '
        'FC1
        '
        Me.FC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FC1.Calendar.ClearText = "&Limpiar"
        Me.FC1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.FC1.Calendar.TodayText = "&Hoy"
        Me.FC1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FC1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.FC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FC1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.FC1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.FC1.Location = New System.Drawing.Point(87, 184)
        Me.FC1.Name = "FC1"
        Me.FC1.Size = New System.Drawing.Size(122, 20)
        Me.FC1.TabIndex = 188
        Me.FC1.Tag = Nothing
        Me.FC1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.FC1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.FC1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(158, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 16)
        Me.Label3.TabIndex = 187
        Me.Label3.Text = "Por fecha del viaje"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(232, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 16)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "al"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarImprimir, Me.ToolStripSeparator1, Me.barSalir, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(452, 54)
        Me.ToolStrip1.TabIndex = 184
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BarImprimir
        '
        Me.BarImprimir.Image = Global.SGT_Transport.My.Resources.Resources.printer
        Me.BarImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BarImprimir.Name = "BarImprimir"
        Me.BarImprimir.Size = New System.Drawing.Size(57, 51)
        Me.BarImprimir.Text = "Imprimir"
        Me.BarImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 54)
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.ClearText = "&Limpiar"
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.TodayText = "&Hoy"
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.F2.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.F2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F2.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(277, 102)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(122, 20)
        Me.F2.TabIndex = 185
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 183
        Me.Label1.Text = "Del"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.ClearText = "&Limpiar"
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.TodayText = "&Hoy"
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.F1.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(87, 102)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(122, 20)
        Me.F1.TabIndex = 182
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "31320c5567ae426cbbe5fd03c0c610a8"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'FrmReportLiq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 356)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.FD2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.FD1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FC2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FC1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.F2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportLiq"
        Me.ShowInTaskbar = False
        Me.Text = "Reporte de liquidaciones"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.FD2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FD1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FC2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FC1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents FD2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents FD1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents FC2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents FC1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BarImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents barSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
End Class
