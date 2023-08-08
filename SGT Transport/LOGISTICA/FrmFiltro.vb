Imports C1.Win.C1Themes
Public Class FrmFiltro
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS()
        Me.ResumeLayout()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub FrmFiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
    Sub CARGAR_DATOS()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Try
            F1.Clear()
            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Clear()
            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            FC1.Clear()
            FC1.Value = Date.Today
            FC1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FC1.CustomFormat = "dd/MM/yyyy"
            FC1.CustomFormat = " "
            FC1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FC1.EditFormat.CustomFormat = "dd/MM/yyyy"

            FC2.Value = Date.Today
            FC2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FC2.CustomFormat = "dd/MM/yyyy"
            FC2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FC2.EditFormat.CustomFormat = "dd/MM/yyyy"
            FC2.Clear()

            FD1.Value = Date.Today
            FD1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FD1.CustomFormat = "dd/MM/yyyy"
            FD1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FD1.EditFormat.CustomFormat = "dd/MM/yyyy"
            FD1.Clear()

            FD2.Value = Date.Today
            FD2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FD2.CustomFormat = "dd/MM/yyyy"
            FD2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FD2.EditFormat.CustomFormat = "dd/MM/yyyy"
            FD2.Clear()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmFiltro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub barAceptar_Click(sender As Object, e As EventArgs) Handles barAceptar.Click
        Try
            If F1.Text <> "" Then
                Var2 = " WHERE A.FECHA >= '" & FSQL(F1.Value) & "' AND A.FECHA <= '" & FSQL(F2.Value) & "'"
            End If

            If FC1.Text = "" Then
                Var3 = ""
            Else
                If Var2.Trim.Length = 0 Then
                    Var3 = " WHERE A.FECHA_CARGA >= '" & FSQL(FC1.Value) & "' AND A.FECHA_CARGA <= '" & FSQL(FC2.Value) & "'"
                Else
                    Var3 = " AND A.FECHA_CARGA >= '" & FSQL(FC1.Value) & "' AND A.FECHA_CARGA <= '" & FSQL(FC2.Value) & "'"
                End If
            End If

            If FD1.Text = "" Then
                Var4 = ""
            Else
                If Var3.Trim.Length = 0 Then
                    Var4 = " WHERE A.FECHA_DESCARGA >= '" & FSQL(FD1.Value) & "' AND A.FECHA_DESCARGA <= '" & FSQL(FD2.Value) & "'"
                Else
                    Var4 = " AND A.FECHA_DESCARGA >= '" & FSQL(FD1.Value) & "' AND A.FECHA_DESCARGA <= '" & FSQL(FD2.Value) & "'"
                End If
            End If
            Me.Close()
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
End Class
