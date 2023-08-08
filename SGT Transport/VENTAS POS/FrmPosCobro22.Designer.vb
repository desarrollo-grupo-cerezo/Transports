<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPosCobro22
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPosCobro22))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TEFECTIVO = New C1.Win.C1Input.C1TextBox()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.LtTotal = New C1.Win.C1Input.C1Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LTCAMBIO = New C1.Win.C1Input.C1Label()
        Me.PnlGrabar = New System.Windows.Forms.Panel()
        Me.LtVend = New C1.Win.C1Input.C1Button()
        Me.BtnVend = New C1.Win.C1Input.C1Button()
        Me.TCVE_VEND = New System.Windows.Forms.TextBox()
        Me.BtnClienteDatos = New C1.Win.C1Input.C1Button()
        Me.BtnCliente = New C1.Win.C1Input.C1Button()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.TCLIENTE = New System.Windows.Forms.TextBox()
        Me.RadCrédito = New System.Windows.Forms.RadioButton()
        Me.RadContado = New System.Windows.Forms.RadioButton()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.ChFacturar = New C1.Win.C1Input.C1CheckBox()
        Me.BtnGrabar = New C1.Win.C1Input.C1Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.F1 = New C1.Win.C1Input.C1DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PnlTarjetas = New System.Windows.Forms.Panel()
        Me.BtnTiempoAire = New C1.Win.C1Input.C1Button()
        Me.BtnTarjetaDebito = New C1.Win.C1Input.C1Button()
        Me.BtnTarjetaCredito = New C1.Win.C1Input.C1Button()
        Me.BtnDolar = New C1.Win.C1Input.C1Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TOBS = New C1.Win.C1Input.C1TextBox()
        Me.TTARJ_CREDITO = New C1.Win.C1Input.C1TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TTARJ_DEBITO = New C1.Win.C1Input.C1TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TTRANS = New C1.Win.C1Input.C1TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TVALES = New C1.Win.C1Input.C1TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TDOLARES = New C1.Win.C1Input.C1TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtImporte = New C1.Win.C1Input.C1Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.TEFECTIVO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LTCAMBIO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlGrabar.SuspendLayout()
        CType(Me.LtVend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnVend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClienteDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChFacturar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGrabar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlTarjetas.SuspendLayout()
        CType(Me.BtnTiempoAire, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnTarjetaDebito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnTarjetaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TOBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TTARJ_CREDITO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TTARJ_DEBITO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TTRANS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TVALES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDOLARES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LtImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Blue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1007, 42)
        Me.Label1.TabIndex = 359
        Me.Label1.Text = "COBRAR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(316, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 37)
        Me.Label12.TabIndex = 364
        Me.Label12.Text = "Total:"
        '
        'TEFECTIVO
        '
        Me.TEFECTIVO.BackColor = System.Drawing.Color.White
        Me.TEFECTIVO.BorderColor = System.Drawing.Color.Silver
        Me.TEFECTIVO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEFECTIVO.CustomFormat = "###,###,##0.00"
        Me.TEFECTIVO.DataType = GetType(Decimal)
        Me.TEFECTIVO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TEFECTIVO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TEFECTIVO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TEFECTIVO.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TEFECTIVO.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEFECTIVO.Location = New System.Drawing.Point(433, 164)
        Me.TEFECTIVO.MarkEmpty = True
        Me.TEFECTIVO.Name = "TEFECTIVO"
        Me.TEFECTIVO.Size = New System.Drawing.Size(212, 42)
        Me.TEFECTIVO.TabIndex = 0
        Me.TEFECTIVO.Tag = Nothing
        Me.TEFECTIVO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TEFECTIVO.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TEFECTIVO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(234, 517)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(123, 36)
        Me.Lt2.TabIndex = 362
        Me.Lt2.Text = "Cambio"
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(317, 169)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(110, 32)
        Me.Lt1.TabIndex = 361
        Me.Lt1.Text = "Efectivo"
        '
        'LtTotal
        '
        Me.LtTotal.BackColor = System.Drawing.Color.White
        Me.LtTotal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtTotal.Location = New System.Drawing.Point(421, 52)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(224, 41)
        Me.LtTotal.TabIndex = 365
        Me.LtTotal.Tag = Nothing
        Me.LtTotal.Text = "0.00"
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LtTotal.TextDetached = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(356, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(245, 37)
        Me.Label2.TabIndex = 366
        Me.Label2.Text = "Forma de pago"
        '
        'LTCAMBIO
        '
        Me.LTCAMBIO.BackColor = System.Drawing.Color.Black
        Me.LTCAMBIO.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LTCAMBIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LTCAMBIO.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTCAMBIO.ForeColor = System.Drawing.Color.White
        Me.LTCAMBIO.Location = New System.Drawing.Point(363, 517)
        Me.LTCAMBIO.Name = "LTCAMBIO"
        Me.LTCAMBIO.Size = New System.Drawing.Size(305, 39)
        Me.LTCAMBIO.TabIndex = 367
        Me.LTCAMBIO.Tag = Nothing
        Me.LTCAMBIO.Text = "0.00"
        Me.LTCAMBIO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LTCAMBIO.TextDetached = True
        '
        'PnlGrabar
        '
        Me.PnlGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PnlGrabar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlGrabar.Controls.Add(Me.LtVend)
        Me.PnlGrabar.Controls.Add(Me.BtnVend)
        Me.PnlGrabar.Controls.Add(Me.TCVE_VEND)
        Me.PnlGrabar.Controls.Add(Me.BtnClienteDatos)
        Me.PnlGrabar.Controls.Add(Me.BtnCliente)
        Me.PnlGrabar.Controls.Add(Me.LtNombre)
        Me.PnlGrabar.Controls.Add(Me.TCLIENTE)
        Me.PnlGrabar.Controls.Add(Me.RadCrédito)
        Me.PnlGrabar.Controls.Add(Me.RadContado)
        Me.PnlGrabar.Controls.Add(Me.BtnCancelar)
        Me.PnlGrabar.Controls.Add(Me.ChFacturar)
        Me.PnlGrabar.Controls.Add(Me.BtnGrabar)
        Me.PnlGrabar.Controls.Add(Me.Label4)
        Me.PnlGrabar.Controls.Add(Me.F1)
        Me.PnlGrabar.Controls.Add(Me.Label3)
        Me.PnlGrabar.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlGrabar.Location = New System.Drawing.Point(744, 42)
        Me.PnlGrabar.Name = "PnlGrabar"
        Me.PnlGrabar.Size = New System.Drawing.Size(263, 601)
        Me.PnlGrabar.TabIndex = 0
        '
        'LtVend
        '
        Me.LtVend.BackColor = System.Drawing.Color.Black
        Me.LtVend.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.LtVend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LtVend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtVend.ForeColor = System.Drawing.Color.White
        Me.LtVend.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LtVend.Location = New System.Drawing.Point(4, 301)
        Me.LtVend.Name = "LtVend"
        Me.LtVend.Size = New System.Drawing.Size(86, 25)
        Me.LtVend.TabIndex = 379
        Me.LtVend.Text = "Vendedor"
        Me.LtVend.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LtVend.UseVisualStyleBackColor = False
        '
        'BtnVend
        '
        Me.BtnVend.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnVend.Location = New System.Drawing.Point(143, 301)
        Me.BtnVend.Name = "BtnVend"
        Me.BtnVend.Size = New System.Drawing.Size(25, 25)
        Me.BtnVend.TabIndex = 378
        Me.BtnVend.UseVisualStyleBackColor = True
        '
        'TCVE_VEND
        '
        Me.TCVE_VEND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCVE_VEND.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCVE_VEND.Location = New System.Drawing.Point(91, 302)
        Me.TCVE_VEND.Name = "TCVE_VEND"
        Me.TCVE_VEND.Size = New System.Drawing.Size(50, 23)
        Me.TCVE_VEND.TabIndex = 7
        '
        'BtnClienteDatos
        '
        Me.BtnClienteDatos.BackColor = System.Drawing.Color.Black
        Me.BtnClienteDatos.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnClienteDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClienteDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClienteDatos.ForeColor = System.Drawing.Color.White
        Me.BtnClienteDatos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnClienteDatos.Location = New System.Drawing.Point(4, 141)
        Me.BtnClienteDatos.Name = "BtnClienteDatos"
        Me.BtnClienteDatos.Size = New System.Drawing.Size(66, 25)
        Me.BtnClienteDatos.TabIndex = 376
        Me.BtnClienteDatos.Text = "Cliente"
        Me.BtnClienteDatos.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnClienteDatos.UseVisualStyleBackColor = False
        '
        'BtnCliente
        '
        Me.BtnCliente.Image = Global.SGT_Transport.My.Resources.Resources.lupa14
        Me.BtnCliente.Location = New System.Drawing.Point(164, 141)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(25, 25)
        Me.BtnCliente.TabIndex = 375
        Me.BtnCliente.UseVisualStyleBackColor = True
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(3, 177)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(247, 111)
        Me.LtNombre.TabIndex = 374
        '
        'TCLIENTE
        '
        Me.TCLIENTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCLIENTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCLIENTE.Location = New System.Drawing.Point(72, 142)
        Me.TCLIENTE.Name = "TCLIENTE"
        Me.TCLIENTE.Size = New System.Drawing.Size(91, 23)
        Me.TCLIENTE.TabIndex = 6
        '
        'RadCrédito
        '
        Me.RadCrédito.AutoSize = True
        Me.RadCrédito.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCrédito.Location = New System.Drawing.Point(113, 101)
        Me.RadCrédito.Name = "RadCrédito"
        Me.RadCrédito.Size = New System.Drawing.Size(71, 21)
        Me.RadCrédito.TabIndex = 5
        Me.RadCrédito.Text = "Credito"
        Me.RadCrédito.UseVisualStyleBackColor = True
        '
        'RadContado
        '
        Me.RadContado.AutoSize = True
        Me.RadContado.Checked = True
        Me.RadContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadContado.Location = New System.Drawing.Point(6, 101)
        Me.RadContado.Name = "RadContado"
        Me.RadContado.Size = New System.Drawing.Size(79, 21)
        Me.RadContado.TabIndex = 4
        Me.RadContado.TabStop = True
        Me.RadContado.Text = "Contado"
        Me.RadContado.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.White
        Me.BtnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = Global.SGT_Transport.My.Resources.Resources.cancel8
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(6, 491)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(200, 52)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "ESC - Cancelar "
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'ChFacturar
        '
        Me.ChFacturar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChFacturar.Location = New System.Drawing.Point(6, 438)
        Me.ChFacturar.Name = "ChFacturar"
        Me.ChFacturar.Size = New System.Drawing.Size(161, 24)
        Me.ChFacturar.TabIndex = 2
        Me.ChFacturar.Text = "Facturar venta"
        Me.ChFacturar.UseVisualStyleBackColor = False
        Me.ChFacturar.Value = Nothing
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.White
        Me.BtnGrabar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = Global.SGT_Transport.My.Resources.Resources.impresora27
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(6, 362)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(200, 52)
        Me.BtnGrabar.TabIndex = 1
        Me.BtnGrabar.Text = "F1 - Imprimir ticket"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 17)
        Me.Label4.TabIndex = 369
        Me.Label4.Text = "Tipo de venta"
        '
        'F1
        '
        Me.F1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.F1.Calendar.DayNameLength = 1
        Me.F1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.LongDate
        Me.F1.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.F1.Enabled = False
        Me.F1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F1.GapHeight = 0
        Me.F1.ImagePadding = New System.Windows.Forms.Padding(0)
        Me.F1.Location = New System.Drawing.Point(11, 28)
        Me.F1.Name = "F1"
        Me.F1.Size = New System.Drawing.Size(239, 19)
        Me.F1.TabIndex = 0
        Me.F1.Tag = Nothing
        Me.F1.Value = New Date(2022, 12, 14, 19, 0, 14, 0)
        Me.F1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(49, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 369
        Me.Label3.Text = "Fecha de venta"
        '
        'PnlTarjetas
        '
        Me.PnlTarjetas.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PnlTarjetas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlTarjetas.Controls.Add(Me.BtnTiempoAire)
        Me.PnlTarjetas.Controls.Add(Me.BtnTarjetaDebito)
        Me.PnlTarjetas.Controls.Add(Me.BtnTarjetaCredito)
        Me.PnlTarjetas.Controls.Add(Me.BtnDolar)
        Me.PnlTarjetas.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlTarjetas.Location = New System.Drawing.Point(0, 42)
        Me.PnlTarjetas.Name = "PnlTarjetas"
        Me.PnlTarjetas.Size = New System.Drawing.Size(171, 601)
        Me.PnlTarjetas.TabIndex = 369
        '
        'BtnTiempoAire
        '
        Me.BtnTiempoAire.BackColor = System.Drawing.Color.White
        Me.BtnTiempoAire.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnTiempoAire.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTiempoAire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTiempoAire.Image = Global.SGT_Transport.My.Resources.Resources.recargar1
        Me.BtnTiempoAire.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnTiempoAire.Location = New System.Drawing.Point(11, 135)
        Me.BtnTiempoAire.Name = "BtnTiempoAire"
        Me.BtnTiempoAire.Size = New System.Drawing.Size(123, 56)
        Me.BtnTiempoAire.TabIndex = 2
        Me.BtnTiempoAire.Text = "Tiempo aire"
        Me.BtnTiempoAire.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTiempoAire.UseVisualStyleBackColor = False
        Me.BtnTiempoAire.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Black
        '
        'BtnTarjetaDebito
        '
        Me.BtnTarjetaDebito.BackColor = System.Drawing.Color.White
        Me.BtnTarjetaDebito.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnTarjetaDebito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTarjetaDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTarjetaDebito.Image = Global.SGT_Transport.My.Resources.Resources.terminal4
        Me.BtnTarjetaDebito.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnTarjetaDebito.Location = New System.Drawing.Point(11, 73)
        Me.BtnTarjetaDebito.Name = "BtnTarjetaDebito"
        Me.BtnTarjetaDebito.Size = New System.Drawing.Size(123, 56)
        Me.BtnTarjetaDebito.TabIndex = 1
        Me.BtnTarjetaDebito.Text = "Tarjeta " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de débito"
        Me.BtnTarjetaDebito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTarjetaDebito.UseVisualStyleBackColor = False
        Me.BtnTarjetaDebito.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Black
        '
        'BtnTarjetaCredito
        '
        Me.BtnTarjetaCredito.BackColor = System.Drawing.Color.White
        Me.BtnTarjetaCredito.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnTarjetaCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTarjetaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTarjetaCredito.Image = Global.SGT_Transport.My.Resources.Resources.terminal1
        Me.BtnTarjetaCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnTarjetaCredito.Location = New System.Drawing.Point(11, 7)
        Me.BtnTarjetaCredito.Name = "BtnTarjetaCredito"
        Me.BtnTarjetaCredito.Size = New System.Drawing.Size(123, 56)
        Me.BtnTarjetaCredito.TabIndex = 0
        Me.BtnTarjetaCredito.Text = "Tarjeta " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de crédito"
        Me.BtnTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTarjetaCredito.UseVisualStyleBackColor = False
        Me.BtnTarjetaCredito.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Black
        '
        'BtnDolar
        '
        Me.BtnDolar.BackColor = System.Drawing.Color.White
        Me.BtnDolar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnDolar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDolar.Image = Global.SGT_Transport.My.Resources.Resources.dolar6
        Me.BtnDolar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDolar.Location = New System.Drawing.Point(11, 202)
        Me.BtnDolar.Name = "BtnDolar"
        Me.BtnDolar.Size = New System.Drawing.Size(109, 52)
        Me.BtnDolar.TabIndex = 3
        Me.BtnDolar.Text = "Dolar"
        Me.BtnDolar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDolar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TOBS)
        Me.GroupBox1.Location = New System.Drawing.Point(177, 570)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(561, 71)
        Me.GroupBox1.TabIndex = 370
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Observaciones"
        '
        'TOBS
        '
        Me.TOBS.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.TOBS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TOBS.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(167, Byte), Integer))
        Me.TOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOBS.Location = New System.Drawing.Point(6, 16)
        Me.TOBS.Multiline = True
        Me.TOBS.Name = "TOBS"
        Me.TOBS.Size = New System.Drawing.Size(549, 51)
        Me.TOBS.TabIndex = 6
        Me.TOBS.Tag = Nothing
        Me.TOBS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'TTARJ_CREDITO
        '
        Me.TTARJ_CREDITO.BackColor = System.Drawing.Color.White
        Me.TTARJ_CREDITO.BorderColor = System.Drawing.Color.Silver
        Me.TTARJ_CREDITO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTARJ_CREDITO.CustomFormat = "###,###,##0.00"
        Me.TTARJ_CREDITO.DataType = GetType(Decimal)
        Me.TTARJ_CREDITO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TTARJ_CREDITO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TTARJ_CREDITO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TTARJ_CREDITO.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TTARJ_CREDITO.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTARJ_CREDITO.Location = New System.Drawing.Point(433, 212)
        Me.TTARJ_CREDITO.MarkEmpty = True
        Me.TTARJ_CREDITO.Name = "TTARJ_CREDITO"
        Me.TTARJ_CREDITO.Size = New System.Drawing.Size(212, 42)
        Me.TTARJ_CREDITO.TabIndex = 1
        Me.TTARJ_CREDITO.Tag = Nothing
        Me.TTARJ_CREDITO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TTARJ_CREDITO.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TTARJ_CREDITO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(272, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 32)
        Me.Label5.TabIndex = 372
        Me.Label5.Text = "Tarj. crédito"
        '
        'TTARJ_DEBITO
        '
        Me.TTARJ_DEBITO.BackColor = System.Drawing.Color.White
        Me.TTARJ_DEBITO.BorderColor = System.Drawing.Color.Silver
        Me.TTARJ_DEBITO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTARJ_DEBITO.CustomFormat = "###,###,##0.00"
        Me.TTARJ_DEBITO.DataType = GetType(Decimal)
        Me.TTARJ_DEBITO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TTARJ_DEBITO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TTARJ_DEBITO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TTARJ_DEBITO.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TTARJ_DEBITO.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTARJ_DEBITO.Location = New System.Drawing.Point(433, 260)
        Me.TTARJ_DEBITO.MarkEmpty = True
        Me.TTARJ_DEBITO.Name = "TTARJ_DEBITO"
        Me.TTARJ_DEBITO.Size = New System.Drawing.Size(212, 42)
        Me.TTARJ_DEBITO.TabIndex = 2
        Me.TTARJ_DEBITO.Tag = Nothing
        Me.TTARJ_DEBITO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TTARJ_DEBITO.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TTARJ_DEBITO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(280, 265)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 32)
        Me.Label6.TabIndex = 374
        Me.Label6.Text = "Tarj. dédito"
        '
        'TTRANS
        '
        Me.TTRANS.BackColor = System.Drawing.Color.White
        Me.TTRANS.BorderColor = System.Drawing.Color.Silver
        Me.TTRANS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTRANS.CustomFormat = "###,###,##0.00"
        Me.TTRANS.DataType = GetType(Decimal)
        Me.TTRANS.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TTRANS.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TTRANS.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TTRANS.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TTRANS.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTRANS.Location = New System.Drawing.Point(433, 308)
        Me.TTRANS.MarkEmpty = True
        Me.TTRANS.Name = "TTRANS"
        Me.TTRANS.Size = New System.Drawing.Size(212, 42)
        Me.TTRANS.TabIndex = 3
        Me.TTRANS.Tag = Nothing
        Me.TTRANS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TTRANS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TTRANS.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(249, 313)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 32)
        Me.Label7.TabIndex = 376
        Me.Label7.Text = "Transferencia"
        '
        'TVALES
        '
        Me.TVALES.BackColor = System.Drawing.Color.White
        Me.TVALES.BorderColor = System.Drawing.Color.Silver
        Me.TVALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TVALES.CustomFormat = "###,###,##0.00"
        Me.TVALES.DataType = GetType(Decimal)
        Me.TVALES.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TVALES.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TVALES.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TVALES.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TVALES.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TVALES.Location = New System.Drawing.Point(433, 356)
        Me.TVALES.MarkEmpty = True
        Me.TVALES.Name = "TVALES"
        Me.TVALES.Size = New System.Drawing.Size(212, 42)
        Me.TVALES.TabIndex = 4
        Me.TVALES.Tag = Nothing
        Me.TVALES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TVALES.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TVALES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(348, 361)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 32)
        Me.Label8.TabIndex = 378
        Me.Label8.Text = "Vales"
        '
        'TDOLARES
        '
        Me.TDOLARES.BackColor = System.Drawing.Color.White
        Me.TDOLARES.BorderColor = System.Drawing.Color.Silver
        Me.TDOLARES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDOLARES.CustomFormat = "###,###,##0.00"
        Me.TDOLARES.DataType = GetType(Decimal)
        Me.TDOLARES.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDOLARES.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDOLARES.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.TDOLARES.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TDOLARES.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDOLARES.Location = New System.Drawing.Point(433, 404)
        Me.TDOLARES.MarkEmpty = True
        Me.TDOLARES.Name = "TDOLARES"
        Me.TDOLARES.Size = New System.Drawing.Size(212, 42)
        Me.TDOLARES.TabIndex = 5
        Me.TDOLARES.Tag = Nothing
        Me.TDOLARES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDOLARES.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TDOLARES.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(319, 409)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 32)
        Me.Label9.TabIndex = 380
        Me.Label9.Text = "Dolares"
        '
        'LtImporte
        '
        Me.LtImporte.BackColor = System.Drawing.Color.White
        Me.LtImporte.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtImporte.Location = New System.Drawing.Point(433, 449)
        Me.LtImporte.Name = "LtImporte"
        Me.LtImporte.Size = New System.Drawing.Size(212, 51)
        Me.LtImporte.TabIndex = 382
        Me.LtImporte.Tag = Nothing
        Me.LtImporte.Text = "0.00"
        Me.LtImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LtImporte.TextDetached = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(216, 455)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(211, 37)
        Me.Label10.TabIndex = 381
        Me.Label10.Text = "Importe total"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300
        '
        'FrmPosCobro22
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1007, 643)
        Me.Controls.Add(Me.LtImporte)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TDOLARES)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TVALES)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TTRANS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TTARJ_DEBITO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TTARJ_CREDITO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PnlTarjetas)
        Me.Controls.Add(Me.PnlGrabar)
        Me.Controls.Add(Me.LTCAMBIO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LtTotal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TEFECTIVO)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPosCobro22"
        Me.ShowInTaskbar = False
        Me.Text = "Cobrar"
        CType(Me.TEFECTIVO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LTCAMBIO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlGrabar.ResumeLayout(False)
        Me.PnlGrabar.PerformLayout()
        CType(Me.LtVend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnVend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClienteDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChFacturar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGrabar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.F1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlTarjetas.ResumeLayout(False)
        CType(Me.BtnTiempoAire, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnTarjetaDebito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnTarjetaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDolar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.TOBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TTARJ_CREDITO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TTARJ_DEBITO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TTRANS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TVALES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDOLARES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LtImporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TEFECTIVO As C1.Win.C1Input.C1TextBox
    Friend WithEvents Lt2 As Label
    Friend WithEvents Lt1 As Label
    Friend WithEvents LtTotal As C1.Win.C1Input.C1Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LTCAMBIO As C1.Win.C1Input.C1Label
    Friend WithEvents PnlGrabar As Panel
    Friend WithEvents F1 As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnGrabar As C1.Win.C1Input.C1Button
    Friend WithEvents ChFacturar As C1.Win.C1Input.C1CheckBox
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents PnlTarjetas As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TOBS As C1.Win.C1Input.C1TextBox
    Friend WithEvents BtnDolar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnTiempoAire As C1.Win.C1Input.C1Button
    Friend WithEvents BtnTarjetaDebito As C1.Win.C1Input.C1Button
    Friend WithEvents BtnTarjetaCredito As C1.Win.C1Input.C1Button
    Friend WithEvents TTARJ_CREDITO As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TTARJ_DEBITO As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TTRANS As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TVALES As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents RadCrédito As RadioButton
    Friend WithEvents RadContado As RadioButton
    Friend WithEvents TDOLARES As C1.Win.C1Input.C1TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents LtImporte As C1.Win.C1Input.C1Label
    Friend WithEvents Label10 As Label
    Friend WithEvents BtnClienteDatos As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCliente As C1.Win.C1Input.C1Button
    Friend WithEvents LtNombre As Label
    Friend WithEvents TCLIENTE As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LtVend As C1.Win.C1Input.C1Button
    Friend WithEvents BtnVend As C1.Win.C1Input.C1Button
    Friend WithEvents TCVE_VEND As TextBox
End Class
