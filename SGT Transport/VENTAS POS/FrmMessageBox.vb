
Public Class FrmMessageBox
    Private Sub FrmMessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToParent()

        LtTitulo.Text = Var10
        LtMesage.Text = Var11

        'BtnCerrar.Left = Me.Width - BtnCerrar.Width

        BtnCerrar.FlatStyle = FlatStyle.Flat
        BtnCerrar.FlatAppearance.BorderSize = 0
    End Sub

    Private Sub FrmMessageBox_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Me.Close()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmMessageBox_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.ClientRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        'ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub

    Private Sub BtnOK_Paint(sender As Object, e As PaintEventArgs) Handles BtnOK.Paint
        'ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Transparent, ButtonBorderStyle.None)
    End Sub

    Private Sub FrmMessageBox_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 330
        Me.Height = 160
    End Sub
End Class