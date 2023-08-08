<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTimbrarCdeP
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTimbrarCdeP))
        Me.Lt1 = New System.Windows.Forms.Label()
        Me.LtCP = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LtUSO_CFDI = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LtRegimenReceptor = New System.Windows.Forms.Label()
        Me.LtRegimenEmisor = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LtRFC = New System.Windows.Forms.Label()
        Me.LtNombre = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.Lt2 = New System.Windows.Forms.Label()
        Me.ChImprimir = New C1.Win.C1Input.C1CheckBox()
        Me.ChEnviarXCorreo = New C1.Win.C1Input.C1CheckBox()
        Me.BtnAceptar = New C1.Win.C1Input.C1Button()
        Me.BtnCancelar = New C1.Win.C1Input.C1Button()
        Me.TCORREO3 = New System.Windows.Forms.TextBox()
        Me.TCORREO2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TCORREO1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCORREO_CTE = New System.Windows.Forms.TextBox()
        Me.LtT = New System.Windows.Forms.Label()
        Me.LtCVE_DOC = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.ChImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChEnviarXCorreo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lt1
        '
        Me.Lt1.AutoSize = True
        Me.Lt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt1.Location = New System.Drawing.Point(181, 12)
        Me.Lt1.Name = "Lt1"
        Me.Lt1.Size = New System.Drawing.Size(287, 16)
        Me.Lt1.TabIndex = 0
        Me.Lt1.Text = "TIMBRANDO COMPLEMENTO DE PAGO"
        '
        'LtCP
        '
        Me.LtCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCP.Location = New System.Drawing.Point(362, 100)
        Me.LtCP.Name = "LtCP"
        Me.LtCP.Size = New System.Drawing.Size(53, 20)
        Me.LtCP.TabIndex = 617
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(328, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 16)
        Me.Label9.TabIndex = 616
        Me.Label9.Text = "C.P."
        '
        'LtUSO_CFDI
        '
        Me.LtUSO_CFDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtUSO_CFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtUSO_CFDI.Location = New System.Drawing.Point(493, 100)
        Me.LtUSO_CFDI.Name = "LtUSO_CFDI"
        Me.LtUSO_CFDI.Size = New System.Drawing.Size(82, 20)
        Me.LtUSO_CFDI.TabIndex = 615
        Me.LtUSO_CFDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(423, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 16)
        Me.Label8.TabIndex = 614
        Me.Label8.Text = "Uso CFDI"
        '
        'LtRegimenReceptor
        '
        Me.LtRegimenReceptor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRegimenReceptor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRegimenReceptor.Location = New System.Drawing.Point(493, 126)
        Me.LtRegimenReceptor.Name = "LtRegimenReceptor"
        Me.LtRegimenReceptor.Size = New System.Drawing.Size(82, 20)
        Me.LtRegimenReceptor.TabIndex = 613
        Me.LtRegimenReceptor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LtRegimenEmisor
        '
        Me.LtRegimenEmisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRegimenEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRegimenEmisor.Location = New System.Drawing.Point(180, 126)
        Me.LtRegimenEmisor.Name = "LtRegimenEmisor"
        Me.LtRegimenEmisor.Size = New System.Drawing.Size(82, 20)
        Me.LtRegimenEmisor.TabIndex = 612
        Me.LtRegimenEmisor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(339, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 16)
        Me.Label3.TabIndex = 611
        Me.Label3.Text = "Regimen fiscal receptor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 16)
        Me.Label5.TabIndex = 610
        Me.Label5.Text = "Regimen fiscal emisor"
        '
        'LtRFC
        '
        Me.LtRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtRFC.Location = New System.Drawing.Point(180, 100)
        Me.LtRFC.Name = "LtRFC"
        Me.LtRFC.Size = New System.Drawing.Size(140, 20)
        Me.LtRFC.TabIndex = 609
        '
        'LtNombre
        '
        Me.LtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtNombre.Location = New System.Drawing.Point(180, 74)
        Me.LtNombre.Name = "LtNombre"
        Me.LtNombre.Size = New System.Drawing.Size(396, 20)
        Me.LtNombre.TabIndex = 607
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(133, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 608
        Me.Label4.Text = "R.F.C."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(91, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 16)
        Me.Label6.TabIndex = 606
        Me.Label6.Text = "Razón social"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'StiReport1
        '
        Me.StiReport1.CookieContainer = Nothing
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "77716a4acf9c483d8a0aabd2ab4920e7"
        Me.StiReport1.ReportImage = Nothing
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = Nothing
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Centimeters
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp
        Me.StiReport1.UseProgressInThread = False
        '
        'Lt2
        '
        Me.Lt2.AutoSize = True
        Me.Lt2.BackColor = System.Drawing.Color.Transparent
        Me.Lt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lt2.Location = New System.Drawing.Point(12, 411)
        Me.Lt2.Name = "Lt2"
        Me.Lt2.Size = New System.Drawing.Size(239, 16)
        Me.Lt2.TabIndex = 619
        Me.Lt2.Text = "_____________________________"
        '
        'ChImprimir
        '
        Me.ChImprimir.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChImprimir.Checked = True
        Me.ChImprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChImprimir.Location = New System.Drawing.Point(374, 272)
        Me.ChImprimir.Name = "ChImprimir"
        Me.ChImprimir.Size = New System.Drawing.Size(185, 25)
        Me.ChImprimir.TabIndex = 620
        Me.ChImprimir.Text = "Imprimir"
        Me.ChImprimir.UseVisualStyleBackColor = True
        Me.ChImprimir.Value = True
        '
        'ChEnviarXCorreo
        '
        Me.ChEnviarXCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChEnviarXCorreo.Checked = True
        Me.ChEnviarXCorreo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChEnviarXCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChEnviarXCorreo.Location = New System.Drawing.Point(179, 272)
        Me.ChEnviarXCorreo.Name = "ChEnviarXCorreo"
        Me.ChEnviarXCorreo.Size = New System.Drawing.Size(169, 25)
        Me.ChEnviarXCorreo.TabIndex = 621
        Me.ChEnviarXCorreo.Text = "Enviar por correo"
        Me.ChEnviarXCorreo.UseVisualStyleBackColor = True
        Me.ChEnviarXCorreo.Value = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.Location = New System.Drawing.Point(182, 341)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(128, 31)
        Me.BtnAceptar.TabIndex = 622
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(362, 341)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(128, 31)
        Me.BtnCancelar.TabIndex = 623
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'TCORREO3
        '
        Me.TCORREO3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCORREO3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCORREO3.Location = New System.Drawing.Point(179, 236)
        Me.TCORREO3.MaxLength = 255
        Me.TCORREO3.Name = "TCORREO3"
        Me.TCORREO3.Size = New System.Drawing.Size(396, 22)
        Me.TCORREO3.TabIndex = 627
        '
        'TCORREO2
        '
        Me.TCORREO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCORREO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCORREO2.Location = New System.Drawing.Point(179, 208)
        Me.TCORREO2.MaxLength = 255
        Me.TCORREO2.Name = "TCORREO2"
        Me.TCORREO2.Size = New System.Drawing.Size(396, 22)
        Me.TCORREO2.TabIndex = 626
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(47, 182)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 16)
        Me.Label14.TabIndex = 625
        Me.Label14.Text = "Correos adicionales"
        '
        'TCORREO1
        '
        Me.TCORREO1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCORREO1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCORREO1.Location = New System.Drawing.Point(179, 180)
        Me.TCORREO1.MaxLength = 255
        Me.TCORREO1.Name = "TCORREO1"
        Me.TCORREO1.Size = New System.Drawing.Size(396, 22)
        Me.TCORREO1.TabIndex = 624
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(85, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 628
        Me.Label1.Text = "Correo cliente"
        '
        'TCORREO_CTE
        '
        Me.TCORREO_CTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TCORREO_CTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCORREO_CTE.Location = New System.Drawing.Point(179, 152)
        Me.TCORREO_CTE.MaxLength = 255
        Me.TCORREO_CTE.Name = "TCORREO_CTE"
        Me.TCORREO_CTE.Size = New System.Drawing.Size(396, 22)
        Me.TCORREO_CTE.TabIndex = 629
        '
        'LtT
        '
        Me.LtT.AutoSize = True
        Me.LtT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtT.Location = New System.Drawing.Point(244, 311)
        Me.LtT.Name = "LtT"
        Me.LtT.Size = New System.Drawing.Size(187, 16)
        Me.LtT.TabIndex = 630
        Me.LtT.Text = "DOCUMENTO TIMBRADO"
        Me.LtT.Visible = False
        '
        'LtCVE_DOC
        '
        Me.LtCVE_DOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LtCVE_DOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LtCVE_DOC.Location = New System.Drawing.Point(180, 48)
        Me.LtCVE_DOC.Name = "LtCVE_DOC"
        Me.LtCVE_DOC.Size = New System.Drawing.Size(140, 20)
        Me.LtCVE_DOC.TabIndex = 632
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(100, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 16)
        Me.Label7.TabIndex = 631
        Me.Label7.Text = "Documento"
        '
        'FrmTimbrarCdeP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 436)
        Me.Controls.Add(Me.LtCVE_DOC)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LtT)
        Me.Controls.Add(Me.TCORREO_CTE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TCORREO3)
        Me.Controls.Add(Me.TCORREO2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TCORREO1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.ChEnviarXCorreo)
        Me.Controls.Add(Me.ChImprimir)
        Me.Controls.Add(Me.Lt2)
        Me.Controls.Add(Me.LtCP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LtUSO_CFDI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LtRegimenReceptor)
        Me.Controls.Add(Me.LtRegimenEmisor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LtRFC)
        Me.Controls.Add(Me.LtNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Lt1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTimbrarCdeP"
        Me.ShowInTaskbar = False
        Me.Text = "Timbrar complemento de pago"
        CType(Me.ChImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChEnviarXCorreo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lt1 As Label
    Friend WithEvents LtCP As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LtUSO_CFDI As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LtRegimenReceptor As Label
    Friend WithEvents LtRegimenEmisor As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LtRFC As Label
    Friend WithEvents LtNombre As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents Lt2 As Label
    Friend WithEvents ChImprimir As C1.Win.C1Input.C1CheckBox
    Friend WithEvents ChEnviarXCorreo As C1.Win.C1Input.C1CheckBox
    Friend WithEvents BtnAceptar As C1.Win.C1Input.C1Button
    Friend WithEvents BtnCancelar As C1.Win.C1Input.C1Button
    Private WithEvents TCORREO3 As TextBox
    Private WithEvents TCORREO2 As TextBox
    Private WithEvents Label14 As Label
    Private WithEvents TCORREO1 As TextBox
    Friend WithEvents Label1 As Label
    Private WithEvents TCORREO_CTE As TextBox
    Friend WithEvents LtT As Label
    Friend WithEvents LtCVE_DOC As Label
    Friend WithEvents Label7 As Label
End Class
