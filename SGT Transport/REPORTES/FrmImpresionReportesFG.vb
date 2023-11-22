Imports Stimulsoft
Imports Stimulsoft.Base.Design
Imports Stimulsoft.Report

Public Class FrmImpresionReportesFG


    Public Sub New()


        InitializeComponent()

    End Sub


    Private Sub FrmImpresionReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmImpresionReportes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class