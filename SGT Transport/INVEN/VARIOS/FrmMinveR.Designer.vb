<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMinveR
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMinveR))
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.barHoy = New System.Windows.Forms.ToolStripMenuItem()
        Me.barEsteMes = New System.Windows.Forms.ToolStripMenuItem()
        Me.barMesAnterior = New System.Windows.Forms.ToolStripMenuItem()
        Me.barTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReimprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1SuperTooltip1 = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barSalir.SuspendLayout()
        Me.SuspendLayout()
        '
        'Fg
        '
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.Location = New System.Drawing.Point(0, 58)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(709, 406)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 11
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barNuevo, Me.barHoy, Me.barEsteMes, Me.barMesAnterior, Me.barTodos, Me.mnuReimprimir, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1084, 53)
        Me.barSalir.TabIndex = 10
        Me.barSalir.Text = "MenuStrip1"
        '
        'barNuevo
        '
        Me.barNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barNuevo.ForeColor = System.Drawing.Color.Black
        Me.barNuevo.Image = Global.SGT_Transport.My.Resources.Resources.file1
        Me.barNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barNuevo.Name = "barNuevo"
        Me.barNuevo.ShortcutKeyDisplayString = "F2-Nuevo"
        Me.barNuevo.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.barNuevo.Size = New System.Drawing.Size(51, 49)
        Me.barNuevo.Text = "Nuevo"
        Me.barNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.barNuevo.ToolTipText = "F2-Nuevo"
        '
        'barHoy
        '
        Me.barHoy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barHoy.ForeColor = System.Drawing.Color.Black
        Me.barHoy.Image = CType(resources.GetObject("barHoy.Image"), System.Drawing.Image)
        Me.barHoy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barHoy.Name = "barHoy"
        Me.barHoy.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barHoy.Size = New System.Drawing.Size(44, 49)
        Me.barHoy.Text = "Hoy"
        Me.barHoy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barEsteMes
        '
        Me.barEsteMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barEsteMes.ForeColor = System.Drawing.Color.Black
        Me.barEsteMes.Image = CType(resources.GetObject("barEsteMes.Image"), System.Drawing.Image)
        Me.barEsteMes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barEsteMes.Name = "barEsteMes"
        Me.barEsteMes.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barEsteMes.Size = New System.Drawing.Size(62, 49)
        Me.barEsteMes.Text = "Este mes"
        Me.barEsteMes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barMesAnterior
        '
        Me.barMesAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barMesAnterior.ForeColor = System.Drawing.Color.Black
        Me.barMesAnterior.Image = Global.SGT_Transport.My.Resources.Resources.doc10
        Me.barMesAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barMesAnterior.Name = "barMesAnterior"
        Me.barMesAnterior.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barMesAnterior.Size = New System.Drawing.Size(77, 49)
        Me.barMesAnterior.Text = "Mes anterior"
        Me.barMesAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barTodos
        '
        Me.barTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barTodos.ForeColor = System.Drawing.Color.Black
        Me.barTodos.Image = Global.SGT_Transport.My.Resources.Resources.folder3
        Me.barTodos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barTodos.Name = "barTodos"
        Me.barTodos.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.barTodos.Size = New System.Drawing.Size(49, 49)
        Me.barTodos.Text = "Todos"
        Me.barTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuReimprimir
        '
        Me.mnuReimprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuReimprimir.ForeColor = System.Drawing.Color.Black
        Me.mnuReimprimir.Image = Global.SGT_Transport.My.Resources.Resources.impresora6
        Me.mnuReimprimir.Name = "mnuReimprimir"
        Me.mnuReimprimir.Size = New System.Drawing.Size(67, 49)
        Me.mnuReimprimir.Text = "Reimprimir"
        Me.mnuReimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 49)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1SuperTooltip1
        '
        Me.C1SuperTooltip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.C1SuperTooltip1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "513754da56ae424f9231414c3ba25091"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'frmMinveR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 598)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMinveR"
        Me.Text = "Movimientos al inventario"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents barNuevo As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents C1SuperTooltip1 As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents barHoy As ToolStripMenuItem
    Friend WithEvents barEsteMes As ToolStripMenuItem
    Friend WithEvents barMesAnterior As ToolStripMenuItem
    Friend WithEvents barTodos As ToolStripMenuItem
    Friend WithEvents mnuReimprimir As ToolStripMenuItem
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
End Class
