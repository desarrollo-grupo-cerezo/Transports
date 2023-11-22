Imports Stimulsoft
Imports Stimulsoft.Base.Design
Imports Stimulsoft.Report

Public Class FrmImpresionReportes
    Dim F1 As String = ""
    Dim F2 As String = ""
    Private CVE_ART1 As String
    Private CVE_ART2 As String
    Private CLIENTE1 As String
    Private CLIENTE2 As String
    Private LINEA1 As String
    Private LINEA2 As String
    Private NameReport As String
    Private _Report As StiReport

    Public Sub New(ByVal PNameReport As String, ByVal PF1 As String, ByVal PF2 As String, PCVE_ART1 As String, PCVE_ART2 As String,
                        PCLIENTE1 As String, PCLIENTE2 As String, PLINEA1 As String, PLINEA2 As String)

        NameReport = PNameReport
        F1 = PF1
        F2 = PF2
        CVE_ART1 = PCVE_ART1
        CVE_ART2 = PCVE_ART2
        CLIENTE1 = PCLIENTE1
        CLIENTE2 = PCLIENTE2
        LINEA1 = PLINEA1
        LINEA2 = PLINEA2

        InitializeComponent()

    End Sub

    Public Sub New(ByVal Reporte As StiReport)
        _Report = Reporte
        InitializeComponent()
    End Sub

    Private Sub FrmImpresionReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Rreporte_MRT As String

        StiViewerControl1.Dock = DockStyle.Fill

        If Not IsNothing(_Report) Then
            StiViewerControl1.Report = _Report
            Return
        End If

        Select Case NameReport

            Case "FrmResumenNotasVentas"

                Dim Report As New StiReport


                Rreporte_MRT = GET_RUTA_FORMATOS() & "\ReportResumenNotasDeVentas" & Empresa & ".mrt"

                If Not IO.File.Exists(Rreporte_MRT) Then

                    Rreporte_MRT = GET_RUTA_FORMATOS() & "\ReportResumenNotasDeVentas.mrt"
                    If Not IO.File.Exists(Rreporte_MRT) Then
                        MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                        Return
                    End If

                End If

                Report.Load(Rreporte_MRT)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                        Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                Report.Dictionary.Databases.Clear()
                Report.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                Report.Compile()
                Report.Dictionary.Synchronize()
                Report.ReportName = Me.Text
                Report("F1") = F1
                Report("F2") = F2

                If CLIENTE1.Trim.Length > 0 And CLIENTE2.Trim.Length > 0 Then
                    Report("CLIENTE1") = CLIENTE1
                    Report("CLIENTE2") = CLIENTE2
                ElseIf CLIENTE1.Trim.Length > 0 And CLIENTE2.Trim.Length = 0 Then
                    Report("CLIENTE1") = CLIENTE1
                    Report("CLIENTE2") = ""
                ElseIf CLIENTE1.Trim.Length = 0 And CLIENTE2.Trim.Length > 0 Then
                    Report("CLIENTE1") = ""
                    Report("CLIENTE2") = CLIENTE2
                Else
                    Report("CLIENTE1") = ""
                    Report("CLIENTE2") = "ZZZZZZZZZZZ"
                End If

                Report.Render()
                'Report.Show()
                StiViewerControl1.Report = Report

        End Select
    End Sub

    Private Sub FrmImpresionReportes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class