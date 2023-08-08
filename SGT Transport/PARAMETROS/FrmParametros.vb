Public Class FrmParametros
    Private Sub frmParametros_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
    End Sub
    Private Sub barCompras_Click(sender As Object, e As EventArgs) Handles barCompras.Click
        CREA_TAB2(frmParamCompras, "Configuración compras")
    End Sub
    Private Sub barInvent_Click(sender As Object, e As EventArgs) Handles barInvent.Click
        CREA_TAB2(frmParamInvent, "Configuración inventario")
    End Sub
    Private Sub barParamGenerales_Click(sender As Object, e As EventArgs) Handles barParamGenerales.Click
        CREA_TAB2(frmParamGenerales, "Parámetros generales")
    End Sub
    Private Sub barVentas_Click(sender As Object, e As EventArgs) Handles barVentas.Click
        CREA_TAB2(frmParamVentas, "Configuración ventas")
    End Sub
    Private Sub barMontellano_Click(sender As Object, e As EventArgs) Handles barMontellano.Click
        CREA_TAB2(frmParamTransCG, "Parámetros transportCG")
    End Sub

    Private Sub frmParametros_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarSMTP_Click(sender As Object, e As EventArgs) Handles BarSMTP.Click
        frmSMTP.ShowDialog()
    End Sub

    Private Sub BarParamFacturaElec_Click(sender As Object, e As EventArgs) Handles BarParamFacturaElec.Click
        CREA_TAB2(FrmConfiguracionCFDI, "Parámetros factura electrónica")
    End Sub

    Private Sub barClientes_Click(sender As Object, e As EventArgs) Handles barClientes.Click
        CREA_TAB2(FrmParamClientes, "Parámetros clientes")
    End Sub

    Private Sub barDatosEmpresa_Click(sender As Object, e As EventArgs) Handles barDatosEmpresa.Click

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim f As New FrmCFDISeries With {
                .MdiParent = Me.Owner
            }

        f.ShowDialog()
    End Sub
End Class
