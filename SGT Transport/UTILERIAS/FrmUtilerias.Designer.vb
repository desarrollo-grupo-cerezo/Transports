<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUtilerias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUtilerias))
        Me.barSalir = New System.Windows.Forms.MenuStrip()
        Me.BarXls = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNUUTILERIAS = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuActClaveCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuObtenerCFDIyGrabar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuValesCombusCFDI = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGrabarFactUtil = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuImporFactCartaPorteSAE = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuKmRecorridos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuGrabarFACTFDesdeXML = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataTreeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuValesCxP = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAgregarCxCDesdeFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.FechaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarActulaizarFechaTimbreEbCartaPorte = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAgregarCxC = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarLlenarBienesTransport = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarBienesTransportados = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarConectBaseSqlServerCe = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarEnviarTablaSqlServer = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarAgregarEspaciosALaTablaDeClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.Calendar.C1DateEdit()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.TCVE_DOC1 = New C1.Win.C1Input.C1TextBox()
        Me.TCVE_DOC2 = New C1.Win.C1Input.C1TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImportarBuenoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarClientesOperativos = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarOperadores = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarUnidades = New System.Windows.Forms.ToolStripMenuItem()
        Me.barSalir.SuspendLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCVE_DOC1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCVE_DOC2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'barSalir
        '
        Me.barSalir.BackColor = System.Drawing.Color.AliceBlue
        Me.barSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarXls, Me.MNUUTILERIAS, Me.ImportarBuenoToolStripMenuItem, Me.mnuSalir})
        Me.barSalir.Location = New System.Drawing.Point(0, 0)
        Me.barSalir.Name = "barSalir"
        Me.barSalir.Size = New System.Drawing.Size(1203, 55)
        Me.barSalir.Stretch = False
        Me.barSalir.TabIndex = 26
        Me.barSalir.Text = "MenuStrip1"
        '
        'BarXls
        '
        Me.BarXls.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarXls.ForeColor = System.Drawing.Color.Black
        Me.BarXls.Image = Global.SGT_Transport.My.Resources.Resources.xls
        Me.BarXls.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BarXls.Name = "BarXls"
        Me.BarXls.ShortcutKeyDisplayString = ""
        Me.BarXls.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BarXls.Size = New System.Drawing.Size(45, 51)
        Me.BarXls.Text = "Excel"
        Me.BarXls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MNUUTILERIAS
        '
        Me.MNUUTILERIAS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuActClaveCliente, Me.MnuObtenerCFDIyGrabar, Me.MnuValesCombusCFDI, Me.MnuGrabarFactUtil, Me.MnuImporFactCartaPorteSAE, Me.MnuKmRecorridos, Me.MnuGrabarFACTFDesdeXML, Me.DataTreeToolStripMenuItem, Me.MnuValesCxP, Me.BarAgregarCxCDesdeFacturas, Me.FechaToolStripMenuItem, Me.BarActulaizarFechaTimbreEbCartaPorte, Me.BarAgregarCxC, Me.BarLlenarBienesTransport, Me.BarBienesTransportados, Me.BarConectBaseSqlServerCe, Me.BarEnviarTablaSqlServer, Me.BarAgregarEspaciosALaTablaDeClientes})
        Me.MNUUTILERIAS.Image = Global.SGT_Transport.My.Resources.Resources.desplegar
        Me.MNUUTILERIAS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MNUUTILERIAS.Name = "MNUUTILERIAS"
        Me.MNUUTILERIAS.Size = New System.Drawing.Size(61, 51)
        Me.MNUUTILERIAS.Text = "Utilerias"
        Me.MNUUTILERIAS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MnuActClaveCliente
        '
        Me.MnuActClaveCliente.Name = "MnuActClaveCliente"
        Me.MnuActClaveCliente.Size = New System.Drawing.Size(310, 22)
        Me.MnuActClaveCliente.Text = "1. Actualiza clave cliente"
        '
        'MnuObtenerCFDIyGrabar
        '
        Me.MnuObtenerCFDIyGrabar.Name = "MnuObtenerCFDIyGrabar"
        Me.MnuObtenerCFDIyGrabar.Size = New System.Drawing.Size(310, 22)
        Me.MnuObtenerCFDIyGrabar.Text = "2. Obtener CFDI y grabar"
        '
        'MnuValesCombusCFDI
        '
        Me.MnuValesCombusCFDI.Name = "MnuValesCombusCFDI"
        Me.MnuValesCombusCFDI.Size = New System.Drawing.Size(310, 22)
        Me.MnuValesCombusCFDI.Text = "3. Vales combustible CFDI"
        '
        'MnuGrabarFactUtil
        '
        Me.MnuGrabarFactUtil.Name = "MnuGrabarFactUtil"
        Me.MnuGrabarFactUtil.Size = New System.Drawing.Size(310, 22)
        Me.MnuGrabarFactUtil.Text = "4. Grabar Factura utilitarios"
        '
        'MnuImporFactCartaPorteSAE
        '
        Me.MnuImporFactCartaPorteSAE.Name = "MnuImporFactCartaPorteSAE"
        Me.MnuImporFactCartaPorteSAE.Size = New System.Drawing.Size(310, 22)
        Me.MnuImporFactCartaPorteSAE.Text = "5. Importar facturas carta porte"
        '
        'MnuKmRecorridos
        '
        Me.MnuKmRecorridos.Name = "MnuKmRecorridos"
        Me.MnuKmRecorridos.Size = New System.Drawing.Size(310, 22)
        Me.MnuKmRecorridos.Text = "6. Km. Recorridos"
        '
        'MnuGrabarFACTFDesdeXML
        '
        Me.MnuGrabarFACTFDesdeXML.Name = "MnuGrabarFACTFDesdeXML"
        Me.MnuGrabarFACTFDesdeXML.Size = New System.Drawing.Size(310, 22)
        Me.MnuGrabarFACTFDesdeXML.Text = "7. Grabar FACTF desde XML"
        '
        'DataTreeToolStripMenuItem
        '
        Me.DataTreeToolStripMenuItem.Name = "DataTreeToolStripMenuItem"
        Me.DataTreeToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.DataTreeToolStripMenuItem.Text = "8. Data tree"
        '
        'MnuValesCxP
        '
        Me.MnuValesCxP.Name = "MnuValesCxP"
        Me.MnuValesCxP.Size = New System.Drawing.Size(310, 22)
        Me.MnuValesCxP.Text = "9 Vales CxP"
        '
        'BarAgregarCxCDesdeFacturas
        '
        Me.BarAgregarCxCDesdeFacturas.Name = "BarAgregarCxCDesdeFacturas"
        Me.BarAgregarCxCDesdeFacturas.Size = New System.Drawing.Size(310, 22)
        Me.BarAgregarCxCDesdeFacturas.Text = "10. Agregar CxC desde facturas"
        '
        'FechaToolStripMenuItem
        '
        Me.FechaToolStripMenuItem.Name = "FechaToolStripMenuItem"
        Me.FechaToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.FechaToolStripMenuItem.Text = "11. Fecha"
        '
        'BarActulaizarFechaTimbreEbCartaPorte
        '
        Me.BarActulaizarFechaTimbreEbCartaPorte.Name = "BarActulaizarFechaTimbreEbCartaPorte"
        Me.BarActulaizarFechaTimbreEbCartaPorte.Size = New System.Drawing.Size(310, 22)
        Me.BarActulaizarFechaTimbreEbCartaPorte.Text = "12. Actulaizar fecha timbre eb carta porte"
        '
        'BarAgregarCxC
        '
        Me.BarAgregarCxC.Name = "BarAgregarCxC"
        Me.BarAgregarCxC.Size = New System.Drawing.Size(310, 22)
        Me.BarAgregarCxC.Text = "13. Agregar CxC"
        '
        'BarLlenarBienesTransport
        '
        Me.BarLlenarBienesTransport.Name = "BarLlenarBienesTransport"
        Me.BarLlenarBienesTransport.Size = New System.Drawing.Size(310, 22)
        Me.BarLlenarBienesTransport.Text = "14. Llenar campos Bienes transportados"
        '
        'BarBienesTransportados
        '
        Me.BarBienesTransportados.Name = "BarBienesTransportados"
        Me.BarBienesTransportados.Size = New System.Drawing.Size(310, 22)
        Me.BarBienesTransportados.Text = "15. Bienes Transportados"
        '
        'BarConectBaseSqlServerCe
        '
        Me.BarConectBaseSqlServerCe.Name = "BarConectBaseSqlServerCe"
        Me.BarConectBaseSqlServerCe.Size = New System.Drawing.Size(310, 22)
        Me.BarConectBaseSqlServerCe.Text = "16. Conectar base sql serverCe"
        '
        'BarEnviarTablaSqlServer
        '
        Me.BarEnviarTablaSqlServer.Name = "BarEnviarTablaSqlServer"
        Me.BarEnviarTablaSqlServer.Size = New System.Drawing.Size(310, 22)
        Me.BarEnviarTablaSqlServer.Text = "17. Enviar tabla sql server"
        '
        'BarAgregarEspaciosALaTablaDeClientes
        '
        Me.BarAgregarEspaciosALaTablaDeClientes.Name = "BarAgregarEspaciosALaTablaDeClientes"
        Me.BarAgregarEspaciosALaTablaDeClientes.Size = New System.Drawing.Size(310, 22)
        Me.BarAgregarEspaciosALaTablaDeClientes.Text = "18. Agregar los espacios a la clave de clientes"
        '
        'mnuSalir
        '
        Me.mnuSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSalir.ForeColor = System.Drawing.Color.Black
        Me.mnuSalir.Image = Global.SGT_Transport.My.Resources.Resources.puertasalida
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuSalir.Size = New System.Drawing.Size(44, 51)
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both
        Me.Fg.BackColor = System.Drawing.Color.White
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.Fg.EditOptions = CType(((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.UseNumericEditor) _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.Fg.ForeColor = System.Drawing.Color.Black
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.Fg.Location = New System.Drawing.Point(12, 68)
        Me.Fg.Name = "Fg"
        Me.Fg.PreserveEditMode = True
        Me.Fg.Rows.Count = 10
        Me.Fg.Rows.DefaultSize = 20
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.Fg.ShowCellLabels = True
        Me.Fg.ShowCursor = True
        Me.Fg.Size = New System.Drawing.Size(1120, 403)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 27
        Me.Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(438, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 301
        Me.Label1.Text = "Fecha"
        '
        'F1
        '
        Me.F1.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F1.Calendar.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Me.F1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        Me.F1.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.F1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(485, 21)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(113, 19)
        Me.F1.TabIndex = 302
        Me.F1.Tag = Nothing
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.F1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(1091, 23)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(104, 17)
        Me.Lt1.TabIndex = 303
        Me.Lt1.Text = "____________"
        '
        'TCVE_DOC1
        '
        Me.TCVE_DOC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_DOC1.Location = New System.Drawing.Point(704, 21)
        Me.TCVE_DOC1.Name = "TCVE_DOC1"
        Me.TCVE_DOC1.Size = New System.Drawing.Size(157, 21)
        Me.TCVE_DOC1.TabIndex = 304
        Me.TCVE_DOC1.Tag = Nothing
        '
        'TCVE_DOC2
        '
        Me.TCVE_DOC2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_DOC2.Location = New System.Drawing.Point(908, 21)
        Me.TCVE_DOC2.Name = "TCVE_DOC2"
        Me.TCVE_DOC2.Size = New System.Drawing.Size(157, 21)
        Me.TCVE_DOC2.TabIndex = 305
        Me.TCVE_DOC2.Tag = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(606, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 306
        Me.Label2.Text = "Del documento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(876, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "al"
        '
        'ImportarBuenoToolStripMenuItem
        '
        Me.ImportarBuenoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarClientes, Me.BarClientesOperativos, Me.BarOperadores, Me.BarUnidades})
        Me.ImportarBuenoToolStripMenuItem.Image = Global.SGT_Transport.My.Resources.Resources.desplegar6
        Me.ImportarBuenoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImportarBuenoToolStripMenuItem.Name = "ImportarBuenoToolStripMenuItem"
        Me.ImportarBuenoToolStripMenuItem.Size = New System.Drawing.Size(102, 51)
        Me.ImportarBuenoToolStripMenuItem.Text = "Importar Bueno"
        Me.ImportarBuenoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarClientes
        '
        Me.BarClientes.Name = "BarClientes"
        Me.BarClientes.Size = New System.Drawing.Size(180, 22)
        Me.BarClientes.Text = "Clientes"
        '
        'BarClientesOperativos
        '
        Me.BarClientesOperativos.Name = "BarClientesOperativos"
        Me.BarClientesOperativos.Size = New System.Drawing.Size(180, 22)
        Me.BarClientesOperativos.Text = "Clientes operativos"
        '
        'BarOperadores
        '
        Me.BarOperadores.Name = "BarOperadores"
        Me.BarOperadores.Size = New System.Drawing.Size(180, 22)
        Me.BarOperadores.Text = "Operadores"
        '
        'BarUnidades
        '
        Me.BarUnidades.Name = "BarUnidades"
        Me.BarUnidades.Size = New System.Drawing.Size(180, 22)
        Me.BarUnidades.Text = "Unidades"
        '
        'FrmUtilerias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1203, 536)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCVE_DOC2)
        Me.Controls.Add(Me.TCVE_DOC1)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F1)
        Me.Controls.Add(Me.Fg)
        Me.Controls.Add(Me.barSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmUtilerias"
        Me.Text = "FrmUtilerias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barSalir.ResumeLayout(False)
        Me.barSalir.PerformLayout()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCVE_DOC1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCVE_DOC2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents barSalir As MenuStrip
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents F1 As C1.Win.Calendar.C1DateEdit
    Friend WithEvents Lt1 As Label
    Friend WithEvents BarXls As ToolStripMenuItem
    Friend WithEvents MNUUTILERIAS As ToolStripMenuItem
    Friend WithEvents MnuActClaveCliente As ToolStripMenuItem
    Friend WithEvents MnuObtenerCFDIyGrabar As ToolStripMenuItem
    Friend WithEvents MnuValesCombusCFDI As ToolStripMenuItem
    Friend WithEvents MnuValesCxP As ToolStripMenuItem
    Friend WithEvents MnuGrabarFactUtil As ToolStripMenuItem
    Friend WithEvents MnuImporFactCartaPorteSAE As ToolStripMenuItem
    Friend WithEvents MnuKmRecorridos As ToolStripMenuItem
    Friend WithEvents MnuGrabarFACTFDesdeXML As ToolStripMenuItem
    Friend WithEvents DataTreeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarAgregarCxCDesdeFacturas As ToolStripMenuItem
    Friend WithEvents FechaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarActulaizarFechaTimbreEbCartaPorte As ToolStripMenuItem
    Friend WithEvents BarAgregarCxC As ToolStripMenuItem
    Friend WithEvents TCVE_DOC1 As C1.Win.C1Input.C1TextBox
    Friend WithEvents TCVE_DOC2 As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BarLlenarBienesTransport As ToolStripMenuItem
    Friend WithEvents BarBienesTransportados As ToolStripMenuItem
    Friend WithEvents BarConectBaseSqlServerCe As ToolStripMenuItem
    Friend WithEvents BarEnviarTablaSqlServer As ToolStripMenuItem
    Friend WithEvents BarAgregarEspaciosALaTablaDeClientes As ToolStripMenuItem
    Friend WithEvents ImportarBuenoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarClientes As ToolStripMenuItem
    Friend WithEvents BarClientesOperativos As ToolStripMenuItem
    Friend WithEvents BarOperadores As ToolStripMenuItem
    Friend WithEvents BarUnidades As ToolStripMenuItem
End Class
