<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelEmpresa
    Inherits C1.Win.C1Ribbon.C1RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelEmpresa))
        Me.TPass = New System.Windows.Forms.TextBox()
        Me.L2 = New System.Windows.Forms.Label()
        Me.TUsuario = New System.Windows.Forms.TextBox()
        Me.L1 = New System.Windows.Forms.Label()
        Me.ListBox = New System.Windows.Forms.ListBox()
        Me.CmdAceptar = New C1.Win.C1Input.C1Button()
        Me.CmdCancelar = New C1.Win.C1Input.C1Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C1ThemeController1 = New C1.Win.C1Themes.C1ThemeController()
        Me.Lt1 = New System.Windows.Forms.Label()
        CType(Me.CmdAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmdCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TPass
        '
        Me.TPass.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.TPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPass.ForeColor = System.Drawing.Color.Black
        Me.TPass.Location = New System.Drawing.Point(106, 196)
        Me.TPass.Name = "TPass"
        Me.TPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TPass.Size = New System.Drawing.Size(179, 22)
        Me.TPass.TabIndex = 18
        Me.C1ThemeController1.SetTheme(Me.TPass, "ShinyBlue")
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.ForeColor = System.Drawing.Color.Black
        Me.L2.Location = New System.Drawing.Point(24, 199)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(76, 16)
        Me.L2.TabIndex = 17
        Me.L2.Text = "Contraseña"
        Me.C1ThemeController1.SetTheme(Me.L2, "ShinyBlue")
        '
        'TUsuario
        '
        Me.TUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.TUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUsuario.ForeColor = System.Drawing.Color.Black
        Me.TUsuario.Location = New System.Drawing.Point(106, 170)
        Me.TUsuario.Name = "TUsuario"
        Me.TUsuario.Size = New System.Drawing.Size(179, 22)
        Me.TUsuario.TabIndex = 16
        Me.C1ThemeController1.SetTheme(Me.TUsuario, "ShinyBlue")
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.ForeColor = System.Drawing.Color.Black
        Me.L1.Location = New System.Drawing.Point(46, 173)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(54, 16)
        Me.L1.TabIndex = 15
        Me.L1.Text = "Usuario"
        Me.C1ThemeController1.SetTheme(Me.L1, "ShinyBlue")
        '
        'ListBox
        '
        Me.ListBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.ListBox.ForeColor = System.Drawing.Color.Black
        Me.ListBox.FormattingEnabled = True
        Me.ListBox.Location = New System.Drawing.Point(2, 4)
        Me.ListBox.Name = "ListBox"
        Me.ListBox.Size = New System.Drawing.Size(353, 160)
        Me.ListBox.TabIndex = 12
        Me.C1ThemeController1.SetTheme(Me.ListBox, "ShinyBlue")
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Location = New System.Drawing.Point(60, 254)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Padding = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.CmdAceptar.Size = New System.Drawing.Size(90, 30)
        Me.CmdAceptar.TabIndex = 19
        Me.CmdAceptar.Text = "Aceptar"
        Me.C1ThemeController1.SetTheme(Me.CmdAceptar, "ShinyBlue")
        Me.CmdAceptar.UseVisualStyleBackColor = True
        Me.CmdAceptar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Location = New System.Drawing.Point(216, 254)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Padding = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.CmdCancelar.Size = New System.Drawing.Size(90, 30)
        Me.CmdCancelar.TabIndex = 20
        Me.CmdCancelar.Text = "cancelar"
        Me.C1ThemeController1.SetTheme(Me.CmdCancelar, "ShinyBlue")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        Me.CmdCancelar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(4, 296)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 18)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Ver. 3.20.4.2"
        Me.C1ThemeController1.SetTheme(Me.Label3, "ShinyBlue")
        '
        'C1ThemeController1
        '
        Me.C1ThemeController1.Theme = "ShinyBlue"
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.Lt1.Font = New System.Drawing.Font("Modern No. 20", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.ForeColor = System.Drawing.Color.Black
        Me.Lt1.Location = New System.Drawing.Point(5, 228)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(0, 15)
        Me.Lt1.TabIndex = 22
        Me.C1ThemeController1.SetTheme(Me.Lt1, "ShinyBlue")
        '
        'FrmSelEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 317)
        Me.Controls.Add(Me.Lt1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.TPass)
        Me.Controls.Add(Me.L2)
        Me.Controls.Add(Me.TUsuario)
        Me.Controls.Add(Me.L1)
        Me.Controls.Add(Me.ListBox)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelEmpresa"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione empresa"
        Me.C1ThemeController1.SetTheme(Me, "ShinyBlue")
        Me.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom
        CType(Me.CmdAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmdCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1ThemeController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TPass As TextBox
    Friend WithEvents L2 As Label
    Friend WithEvents TUsuario As TextBox
    Friend WithEvents L1 As Label
    Friend WithEvents ListBox As ListBox
    Friend WithEvents CmdAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents CmdCancelar As C1.Win.C1Input.C1Button
    Friend WithEvents Label3 As Label
    Friend WithEvents C1ThemeController1 As C1.Win.C1Themes.C1ThemeController
    Friend WithEvents Lt1 As Label
End Class
