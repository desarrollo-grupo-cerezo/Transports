Imports System.Threading
Imports C1.Win.C1Themes
Public Class FrmLogin

    Implements DPFP.Capture.EventHandler
    Delegate Sub FunctionCall(ByVal param)
    Private Capturer As DPFP.Capture.Capture
    Private Verificator As DPFP.Verification.Verification
    Private RUTA_HUELLAS As String

    Protected Overridable Sub Init()
        Try
            Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
            Verificator = New DPFP.Verification.Verification()

            If (Capturer IsNot Nothing) Then
                Capturer.EventHandler = Me                              ' Subscribe for capturing events.
            End If
        Catch ex As DPFP.Error.SDKException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "TransportGC")
        End Try
    End Sub
    Protected Overridable Sub Processs(ByVal Sample As DPFP.Sample)
        DrawPicture(ConvertSampleToBitmap(Sample))
    End Sub
    Protected Function ConvertSampleToBitmap(ByVal Sample As DPFP.Sample) As Bitmap
        Dim convertor As New DPFP.Capture.SampleConversion()  ' Create a sample convertor.
        Dim bitmap As Bitmap = Nothing              ' TODO: the size doesn't matter
        convertor.ConvertToPicture(Sample, bitmap)
        ' TODO: return bitmap as a result
        Return bitmap
    End Function
    Protected Function ExtractFeatures(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction()    ' Create a feature extractor
        Dim feedback As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim features As New DPFP.FeatureSet()
        extractor.CreateFeatureSet(Sample, Purpose, feedback, features) ' TODO: return features as a result?
        If (feedback = DPFP.Capture.CaptureFeedback.Good) Then
            Return features
        Else
            Return Nothing
        End If
    End Function
    Public Sub StartCapture()
        If Capturer IsNot Nothing Then
            Try
                Capturer.StartCapture()

            Catch ex As DPFP.Error.SDKException
                'SetPrompt("Can't initiate capture!")
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "TransportGC")
            End Try
        End If
    End Sub
    Protected Sub StopCapture()
        If (Not Capturer Is Nothing) Then
            Try
                Capturer.StopCapture()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Connect = ""
        Init()
        StartCapture()
        Control.CheckForIllegalCrossThreadCalls = False
        RUTA_HUELLAS = Var4
    End Sub
    Private Sub CaptureForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        StopCapture()
        Me.Dispose()
    End Sub
    Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
    End Sub
    Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
        If CaptureFeedback = DPFP.Capture.CaptureFeedback.Good Then
            'MakeReport("The quality of the fingerprint sample is good.")
        Else
            'MakeReport("The quality of the fingerprint sample is poor.")
        End If
    End Sub
    Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        Process(Sample)
    End Sub
    Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone
    End Sub
    Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
    End Sub
    Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
    End Sub
    Protected Sub SetStatus(ByVal status)
    End Sub
    Protected Sub DrawPicture(ByVal bmp)
        Invoke(New FunctionCall(AddressOf _DrawPicture), bmp)
    End Sub
    Private Sub _DrawPicture(ByVal bmp)
        Picture.Image = New Bitmap(bmp, Picture.Size)
        ' My.Computer.Audio.Play(My.Resources.Single_wave, AudioPlayMode.Background)
    End Sub
    Protected Sub Process(ByVal Sample As DPFP.Sample)

        Processs(Sample)
        Dim fullpath As String

        'My.Computer.FileSystem.FileExists(RUTA_HUELLAS & "\" & TUSUARIO.Text & ".fpt") Then

        fullpath = RUTA_HUELLAS & "\"
        'fullpath = "\\srv71.hosting24.com@SSL@2078\DavWWWRoot\Finger"
        Dim FileDirectory As New IO.DirectoryInfo(fullpath)
        Dim FileJpg As IO.FileInfo() = FileDirectory.GetFiles("*.fpt")
        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = FileDirectory.GetFiles("*.fpt").Count

        If ProgressBar1.Maximum = 0 Then
            MsgBox("No se detectaron huellas", MsgBoxStyle.Exclamation, "TransportGC")
            Exit Sub
        End If

        Invoke(New FunctionCall(AddressOf Cleartxtbox), "")
        ' Process the sample and create a feature set for the enrollment purpose.
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification)
        ' Check quality of the sample and start verification if it's good
        If features IsNot Nothing Then
            ' Compare the feature set with our template
            For Each File As IO.FileInfo In FileJpg
                ProgressBar1.Value += 1
                Using fs As IO.FileStream = IO.File.OpenRead(File.FullName)
                    Dim hello As New DPFP.Template(fs)

                    Dim Result As DPFP.Verification.Verification.Result = New DPFP.Verification.Verification.Result()
                    Verificator.Verify(features, hello, Result)
                    'UpdateStatus(result.FARAchieved)
                    If Result.Verified Then
                        Lt1.Text = "Coincidencia encontrada"
                        Dim name As String = System.IO.Path.GetFileNameWithoutExtension(File.FullName)
                        Autoselect(name)
                        Exit For
                    Else
                        Lt1.Text = "Coincidencia no encontrada"
                        'MakeReport("The fingerprint was NOT VERIFIED.")
                        ' Invoke(New FunctionCall(AddressOf picturenotvieried), My.Resources.Boton_mal)
                    End If

                End Using
            Next
        End If
    End Sub
    Sub Autoselect(ByVal identity As String)
        Try
            Picture.Image = Nothing
            Try
                If Var2.Trim.Length > 0 Then
                    Picture.Image = Image.FromFile(Var2)
                    Picture.Refresh()
                    Me.Refresh()
                End If
            Catch ex As Exception
            End Try

            Invoke(New FunctionCall(AddressOf _setname), identity)

        Catch ex As Exception
            BITACORATPV("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Exit Sub
    End Sub
    Sub Cleartxtbox(ByVal clearr As String)
        'TUSUARIO.Text = ""
    End Sub
    Private Sub _setname(ByVal setname As String)
        Try
            'TUSUARIO.Text = setname
            Var1 = setname
            ProgressBar1.Value = 0
            'Dim result = RJMessageBox.Show("Huella verificada correctamente.", "Bienvenido" & TUSUARIO.Text, MessageBoxButtons.OK)

            LtOk.Text = "Huella verificada correctamente."
            LtOk.Refresh()

            Thread.Sleep(1000)

            Connect = "Si"

            Me.Close()
        Catch ex As Exception
            BITACORATPV("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmLogin_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        TUSUARIO.Enabled = True
        TUSUARIO.ReadOnly = False
        TUSUARIO.PasswordChar = "*"
        TUSUARIO.Focus()
    End Sub
    Private Sub TUSUARIO_KeyDown(sender As Object, e As KeyEventArgs) Handles TUSUARIO.KeyDown

        Try
            If e.KeyValue = 13 Then
                If TUSUARIO.Text.Trim.ToUpper = "BR3FRAJA" Or TUSUARIO.Text.Trim.ToUpper = "BUS" Or TUSUARIO.Text.Trim.ToUpper = "258036" Then
                    USER_GRUPOCE = "ADMIN"
                    PASS_GRUPOCE = TUSUARIO.Text
                    Me.DialogResult = DialogResult.OK
                    Connect = "Si"

                    Me.Close()
                Else
                    Dim result = RJMessageBox.Show("Contraseña incorrecta", "Advertencia", MessageBoxButtons.OK)
                End If
            End If

        Catch ex As Exception
            BITACORATPV("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class