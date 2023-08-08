<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWebServices
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWebServices))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.barWebServices = New System.Windows.Forms.ToolStripMenuItem()
        Me.barActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.barRutas = New System.Windows.Forms.ToolStripMenuItem()
        Me.barExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarTest = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarGoogleMpas1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.C1FlexPivotPrintDocument1 = New C1.Win.FlexPivot.C1FlexPivotPrintDocument()
        Me.Lt = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.LtFecha = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboUnidad = New C1.Win.C1Input.C1ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.F2 = New C1.Win.Calendar.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.barSalir.SuspendLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barWebServices, Me.barActualizar, Me.barRutas, Me.barExcel, Me.BarTest, Me.BarGoogleMpas1, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1177, 55)
        Me.barSalir.TabIndex = 7
        Me.barSalir.Text = "MenuStrip1"
        '
        'barWebServices
        '
        Me.barWebServices.Image = Global.SGT_Transport.My.Resources.Resources.nube1
        Me.barWebServices.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barWebServices.Name = "barWebServices"
        Me.barWebServices.ShortcutKeyDisplayString = "Desplegar"
        Me.barWebServices.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barWebServices.Size = New System.Drawing.Size(71, 51)
        Me.barWebServices.Text = "Desplegar"
        Me.barWebServices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barActualizar
        '
        Me.barActualizar.Image = Global.SGT_Transport.My.Resources.Resources.refresh
        Me.barActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barActualizar.Name = "barActualizar"
        Me.barActualizar.ShortcutKeyDisplayString = "Desplegar"
        Me.barActualizar.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barActualizar.Size = New System.Drawing.Size(71, 51)
        Me.barActualizar.Text = "Actualizar"
        Me.barActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barRutas
        '
        Me.barRutas.Image = Global.SGT_Transport.My.Resources.Resources.ruta6
        Me.barRutas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barRutas.Name = "barRutas"
        Me.barRutas.ShortcutKeyDisplayString = "Desplegar"
        Me.barRutas.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barRutas.Size = New System.Drawing.Size(48, 51)
        Me.barRutas.Text = "Rutas"
        Me.barRutas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'barExcel
        '
        Me.barExcel.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.barExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.barExcel.Name = "barExcel"
        Me.barExcel.ShortcutKeyDisplayString = "Desplegar"
        Me.barExcel.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.barExcel.Size = New System.Drawing.Size(46, 51)
        Me.barExcel.Text = "Excel"
        Me.barExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarTest
        '
        Me.BarTest.Image = Global.SGT_Transport.My.Resources.Resources.LETRA_T2
        Me.BarTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarTest.Name = "BarTest"
        Me.BarTest.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarTest.Size = New System.Drawing.Size(44, 51)
        Me.BarTest.Text = "TEST"
        Me.BarTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarTest.Visible = False
        '
        'BarGoogleMpas1
        '
        Me.BarGoogleMpas1.Image = Global.SGT_Transport.My.Resources.Resources.M9
        Me.BarGoogleMpas1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarGoogleMpas1.Name = "BarGoogleMpas1"
        Me.BarGoogleMpas1.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BarGoogleMpas1.Size = New System.Drawing.Size(48, 51)
        Me.BarGoogleMpas1.Text = "Maps"
        Me.BarGoogleMpas1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BarGoogleMpas1.Visible = False
        '
        'mnuSalir
        '
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'C1FlexPivotPrintDocument1
        '
        Me.C1FlexPivotPrintDocument1.DocumentName = "Reporte de C1FlexPivot"
        Me.C1FlexPivotPrintDocument1.HeaderText = "&[Title]" & Global.Microsoft.VisualBasic.ChrW(9) & "&[Date]" & Global.Microsoft.VisualBasic.ChrW(9) & "Pagina &[Page]"
        '
        'Lt
        '
        Me.Lt.AutoSize = True
        Me.Lt.Location = New System.Drawing.Point(998, 26)
        Me.Lt.Name = "Lt"
        Me.Lt.Size = New System.Drawing.Size(0, 13)
        Me.Lt.TabIndex = 11
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(7, 27)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(135, 18)
        Me.F1.TabIndex = 12
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtFecha
        '
        Me.LtFecha.AutoSize = True
        Me.LtFecha.BackColor = System.Drawing.Color.Transparent
        Me.LtFecha.ForeColor = System.Drawing.Color.White
        Me.LtFecha.Location = New System.Drawing.Point(4, 8)
        Me.LtFecha.Name = "LtFecha"
        Me.LtFecha.Size = New System.Drawing.Size(90, 13)
        Me.LtFecha.TabIndex = 13
        Me.LtFecha.Text = "Seleccione fecha"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowFiltering = True
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop
        Me.Fg.AutoSearchDelay = 9.0R
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ClipboardCopyMode = C1.Win.C1FlexGrid.ClipboardCopyModeEnum.DataAndColumnHeaders
        Me.Fg.ColumnInfo = "4,1,0,0,0,95,Columns:1{AllowNull:False;Caption:""Clave"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:343;AllowNull:Fa" &
    "lse;Caption:""Nombre"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{AllowNull:False;Caption:""R.F.C."";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.Fg.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(0, 71)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.Size = New System.Drawing.Size(1150, 352)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 15
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(347, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Seleccione Unidad"
        '
        'cboUnidad
        '
        Me.cboUnidad.AllowSpinLoop = False
        Me.cboUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboUnidad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cboUnidad.DropDownStyle = C1.Win.C1Input.DropDownStyle.DropDownList
        Me.cboUnidad.GapHeight = 0
        Me.cboUnidad.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.cboUnidad.ItemsDisplayMember = ""
        Me.cboUnidad.ItemsValueMember = ""
        Me.cboUnidad.Location = New System.Drawing.Point(348, 27)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(102, 18)
        Me.cboUnidad.TabIndex = 17
        Me.cboUnidad.Tag = Nothing
        Me.cboUnidad.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.cboUnidad.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.F2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboUnidad)
        Me.Panel1.Controls.Add(Me.F1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LtFecha)
        Me.Panel1.Location = New System.Drawing.Point(706, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(459, 54)
        Me.Panel1.TabIndex = 18
        '
        'F2
        '
        Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F2.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F2.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F2.Location = New System.Drawing.Point(171, 27)
        Me.F2.Name = "F2"
        Me.F2.Size = New System.Drawing.Size(135, 18)
        Me.F2.TabIndex = 18
        Me.F2.Tag = Nothing
        Me.F2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F2.VisualStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(168, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Seleccione fecha"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 180000
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.SteelBlue
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.Black
        Me.Lt1.Location = New System.Drawing.Point(464, 26)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(111, 15)
        Me.Lt1.TabIndex = 20
        Me.Lt1.Text = "_____________"
        '
        'frmWebServices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 435)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.Lt)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmWebServices"
        Me.Text = "Web Services"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.F2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents barSalir As System.Windows.Forms.MenuStrip
    Friend WithEvents barWebServices As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents C1FlexPivotPrintDocument1 As C1.Win.FlexPivot.C1FlexPivotPrintDocument
    Friend WithEvents barRutas As ToolStripMenuItem
    Friend WithEvents Lt As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents LtFecha As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents cboUnidad As C1.Win.C1Input.C1ComboBox
    Friend WithEvents barActualizar As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents F2 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents BarTest As ToolStripMenuItem
    Friend WithEvents BarGoogleMpas1 As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Lt1 As Label
End Class
