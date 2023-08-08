<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVentanaCobro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVentanaCobro))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LtSubtotal = New System.Windows.Forms.Label()
        Me.LtIeps = New System.Windows.Forms.Label()
        Me.LtDesc = New System.Windows.Forms.Label()
        Me.LtDesFin = New System.Windows.Forms.Label()
        Me.LtIVA = New System.Windows.Forms.Label()
        Me.LtImpu3 = New System.Windows.Forms.Label()
        Me.LtTotal = New System.Windows.Forms.Label()
        Me.LtImpu2 = New System.Windows.Forms.Label()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.Fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.FgP = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.LtCambio = New System.Windows.Forms.Label()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.TIMPORTE_RECIBIDO = New C1.Win.C1Input.C1TextBox()
        Me.LtImporteTotal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FgP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMPORTE_RECIBIDO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(73, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sub-total"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Desc. financiero"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "I.E.P.S."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(63, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Descuento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(96, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "I.V.A."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(63, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Total venta"
        '
        'LtSubtotal
        '
        Me.LtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtSubtotal.Location = New System.Drawing.Point(133, 7)
        Me.LtSubtotal.Name = "LtSubtotal"
        Me.LtSubtotal.Size = New System.Drawing.Size(130, 20)
        Me.LtSubtotal.TabIndex = 6
        Me.LtSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtIeps
        '
        Me.LtIeps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtIeps.Location = New System.Drawing.Point(133, 82)
        Me.LtIeps.Name = "LtIeps"
        Me.LtIeps.Size = New System.Drawing.Size(130, 20)
        Me.LtIeps.TabIndex = 7
        Me.LtIeps.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtDesc
        '
        Me.LtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDesc.Location = New System.Drawing.Point(133, 32)
        Me.LtDesc.Name = "LtDesc"
        Me.LtDesc.Size = New System.Drawing.Size(130, 20)
        Me.LtDesc.TabIndex = 8
        Me.LtDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtDesFin
        '
        Me.LtDesFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtDesFin.Location = New System.Drawing.Point(133, 57)
        Me.LtDesFin.Name = "LtDesFin"
        Me.LtDesFin.Size = New System.Drawing.Size(130, 20)
        Me.LtDesFin.TabIndex = 9
        Me.LtDesFin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtIVA
        '
        Me.LtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtIVA.Location = New System.Drawing.Point(133, 157)
        Me.LtIVA.Name = "LtIVA"
        Me.LtIVA.Size = New System.Drawing.Size(130, 20)
        Me.LtIVA.TabIndex = 13
        Me.LtIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtImpu3
        '
        Me.LtImpu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImpu3.Location = New System.Drawing.Point(133, 132)
        Me.LtImpu3.Name = "LtImpu3"
        Me.LtImpu3.Size = New System.Drawing.Size(130, 20)
        Me.LtImpu3.TabIndex = 12
        Me.LtImpu3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtTotal
        '
        Me.LtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtTotal.Location = New System.Drawing.Point(133, 182)
        Me.LtTotal.Name = "LtTotal"
        Me.LtTotal.Size = New System.Drawing.Size(130, 20)
        Me.LtTotal.TabIndex = 11
        Me.LtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LtImpu2
        '
        Me.LtImpu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImpu2.Location = New System.Drawing.Point(133, 107)
        Me.LtImpu2.Name = "LtImpu2"
        Me.LtImpu2.Size = New System.Drawing.Size(130, 20)
        Me.LtImpu2.TabIndex = 10
        Me.LtImpu2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnGrabar
        '
        Me.BtnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Location = New System.Drawing.Point(55, 323)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(80, 40)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(183, 323)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(80, 40)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Tag = ""
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(34, 259)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(96, 15)
        Me.Lt1.TabIndex = 340
        Me.Lt1.Text = "Importe recibido"
        '
        'Fg
        '
        Me.Fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Fg.AllowEditing = False
        Me.Fg.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.Fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.Fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.Fg.AutoClipboard = True
        Me.Fg.AutoGenerateColumns = False
        Me.Fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Fg.CausesValidation = False
        Me.Fg.ColumnInfo = resources.GetString("Fg.ColumnInfo")
        Me.Fg.EditOptions = CType((C1.Win.C1FlexGrid.EditFlags.ExitOnLeftRightKeys Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest), C1.Win.C1FlexGrid.EditFlags)
        Me.Fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Fg.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Fg.Location = New System.Drawing.Point(3, 6)
        Me.Fg.Name = "Fg"
        Me.Fg.Rows.DefaultSize = 19
        Me.Fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.Fg.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None
        Me.Fg.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.Fg.Size = New System.Drawing.Size(341, 207)
        Me.Fg.StyleInfo = resources.GetString("Fg.StyleInfo")
        Me.Fg.TabIndex = 0
        '
        'FgP
        '
        Me.FgP.AllowEditing = False
        Me.FgP.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.FgP.AutoClipboard = True
        Me.FgP.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.FgP.ColumnInfo = resources.GetString("FgP.ColumnInfo")
        Me.FgP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FgP.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgP.Location = New System.Drawing.Point(3, 219)
        Me.FgP.Name = "FgP"
        Me.FgP.Rows.DefaultSize = 19
        Me.FgP.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FgP.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None
        Me.FgP.Size = New System.Drawing.Size(341, 162)
        Me.FgP.StyleInfo = resources.GetString("FgP.StyleInfo")
        Me.FgP.TabIndex = 1
        '
        'LtCambio
        '
        Me.LtCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCambio.Location = New System.Drawing.Point(133, 282)
        Me.LtCambio.Name = "LtCambio"
        Me.LtCambio.Size = New System.Drawing.Size(130, 20)
        Me.LtCambio.TabIndex = 344
        Me.LtCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(77, 282)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(50, 15)
        Me.Lt2.TabIndex = 343
        Me.Lt2.Text = "Cambio"
        '
        'TIMPORTE_RECIBIDO
        '
        Me.TIMPORTE_RECIBIDO.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TIMPORTE_RECIBIDO.BorderColor = System.Drawing.Color.DodgerBlue
        Me.TIMPORTE_RECIBIDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TIMPORTE_RECIBIDO.DataType = GetType(Decimal)
        Me.TIMPORTE_RECIBIDO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.TIMPORTE_RECIBIDO.DisplayFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE_RECIBIDO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.TIMPORTE_RECIBIDO.EditFormat.Inherit = CType((((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.CalendarType), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.TIMPORTE_RECIBIDO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIMPORTE_RECIBIDO.FormatType = C1.Win.C1Input.FormatTypeEnum.Currency
        Me.TIMPORTE_RECIBIDO.Location = New System.Drawing.Point(133, 257)
        Me.TIMPORTE_RECIBIDO.MarkEmpty = True
        Me.TIMPORTE_RECIBIDO.Name = "TIMPORTE_RECIBIDO"
        Me.TIMPORTE_RECIBIDO.Size = New System.Drawing.Size(130, 21)
        Me.TIMPORTE_RECIBIDO.TabIndex = 3
        Me.TIMPORTE_RECIBIDO.Tag = Nothing
        Me.TIMPORTE_RECIBIDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TIMPORTE_RECIBIDO.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TIMPORTE_RECIBIDO.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'LtImporteTotal
        '
        Me.LtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtImporteTotal.Location = New System.Drawing.Point(133, 232)
        Me.LtImporteTotal.Name = "LtImporteTotal"
        Me.LtImporteTotal.Size = New System.Drawing.Size(130, 20)
        Me.LtImporteTotal.TabIndex = 349
        Me.LtImporteTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(52, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 15)
        Me.Label12.TabIndex = 348
        Me.Label12.Text = "Importe total"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LtSubtotal)
        Me.Panel1.Controls.Add(Me.LtImporteTotal)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TIMPORTE_RECIBIDO)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.LtCambio)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Lt2)
        Me.Panel1.Controls.Add(Me.LtIeps)
        Me.Panel1.Controls.Add(Me.LtDesc)
        Me.Panel1.Controls.Add(Me.LtDesFin)
        Me.Panel1.Controls.Add(Me.Lt1)
        Me.Panel1.Controls.Add(Me.LtImpu2)
        Me.Panel1.Controls.Add(Me.BtnCancelar)
        Me.Panel1.Controls.Add(Me.LtTotal)
        Me.Panel1.Controls.Add(Me.BtnGrabar)
        Me.Panel1.Controls.Add(Me.LtImpu3)
        Me.Panel1.Controls.Add(Me.LtIVA)
        Me.Panel1.Location = New System.Drawing.Point(348, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(308, 378)
        Me.Panel1.TabIndex = 350
        '
        'FrmVentanaCobro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 393)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FgP)
        Me.Controls.Add(Me.Fg)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVentanaCobro"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Totales"
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.Fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FgP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMPORTE_RECIBIDO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LtSubtotal As Label
    Friend WithEvents LtIeps As Label
    Friend WithEvents LtDesc As Label
    Friend WithEvents LtDesFin As Label
    Friend WithEvents LtIVA As Label
    Friend WithEvents LtImpu3 As Label
    Friend WithEvents LtTotal As Label
    Friend WithEvents LtImpu2 As Label
    Friend WithEvents BtnGrabar As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents Lt1 As Label
    Friend WithEvents Fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents FgP As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LtCambio As Label
    Friend WithEvents Lt2 As Label
    Friend WithEvents TIMPORTE_RECIBIDO As C1.Win.C1Input.C1TextBox
    Friend WithEvents LtImporteTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel1 As Panel
End Class
