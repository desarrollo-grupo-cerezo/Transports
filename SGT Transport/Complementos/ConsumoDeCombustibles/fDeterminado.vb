Public Class fDeterminado
    Public Property Determinado As CCDeterminado
        Get
            Return _determinado
        End Get
        Set(value As CCDeterminado)
            _determinado = value
        End Set
    End Property
    Private _determinado As CCDeterminado
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (HayError()) Then Return
        _determinado.impuesto = cbImpuesto.Text
        _determinado.tasaOCuota = nudTasaOCuota.Value
        _determinado.importe = nudImporte.Value
        DialogResult = Windows.Forms.DialogResult.Yes
    End Sub
    Private Function HayError() As Boolean
        If (cbImpuesto.SelectedIndex < 0) Then
            lError.Text = "Elige un impuesto"
            Return True
        End If
        Return False
    End Function
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.No
        'Close()
    End Sub

    Public Sub New()
        _determinado = New CCDeterminado()
        InitializeComponent()
    End Sub
    Public Sub New(determinado As CCDeterminado)
        _determinado = determinado
        InitializeComponent()
        cbImpuesto.Text = determinado.impuesto
        nudImporte.Value = determinado.importe
        nudTasaOCuota.Value = determinado.tasaOCuota
    End Sub
End Class