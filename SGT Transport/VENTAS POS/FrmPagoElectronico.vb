Public Class FrmPagoElectronico
    Private IMPORTE As Decimal
    Public Sub New(ByVal Parameter1 As Decimal)

        IMPORTE = Parameter1

        InitializeComponent()
    End Sub
    Private Sub FrmPagoElectronico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()
        'Me.ShowInTaskbar = False

        LtImporte.Text = Format(IMPORTE, "###,###,##0.00")

    End Sub
    Private Sub BtnConexionTerminal_Click(sender As Object, e As EventArgs) Handles BtnConexionTerminal.Click

        BtnConexExitosa.Visible = True

    End Sub

    Private Sub BtnConexExitosa_Click(sender As Object, e As EventArgs) Handles BtnConexExitosa.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
End Class