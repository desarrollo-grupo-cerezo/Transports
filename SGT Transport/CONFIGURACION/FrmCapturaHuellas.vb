Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmCapturaHuellas
    Implements DPFP.Capture.EventHandler
    Delegate Sub FunctionCall(ByVal param)
    Private Capturer As DPFP.Capture.Capture
    ReadOnly count As Integer
    Public Enroller As DPFP.Processing.Enrollment
    Private Template As DPFP.Template
    Private RUTA_HUELLAS As String, RUTA_FOTOS As String

    Private Sub CaptureForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try
            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                SQL = "SELECT RUTA_HUELLAS, RUTA_FOTOS FROM CONFIG WHERE EMPRESA = '" & Empresa & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        RUTA_HUELLAS = dr.ReadNullAsEmptyString("RUTA_HUELLAS")
                        RUTA_FOTOS = dr.ReadNullAsEmptyString("RUTA_FOTOS")
                    End If
                End Using
            End Using

            Init()
            StartCapture()

            If IO.File.Exists(Var2) Then
                PictureBox5.Image = Image.FromFile(Var2)
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try


    End Sub
    Private Sub OnTemplate(ByVal template)
        Invoke(New FunctionCall(AddressOf _OnTemplate), template)
    End Sub
    Private Sub _OnTemplate(ByVal template)
        Me.Template = template
        If template IsNot Nothing Then

            Savetemplate()
            MsgBox("Huella dactilar exitosa", MsgBoxStyle.Information, "TransportGC")
            Me.Close()
        Else
            MessageBox.Show("La plantilla de huella digital no es válida. Repita el registro de huellas dactilares.", "Inscripción de huellas dactilares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Protected Overridable Sub Init()
        Try
            Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
            Enroller = New DPFP.Processing.Enrollment()
            UpdateStatus()
            If Capturer IsNot Nothing Then
                Capturer.EventHandler = Me                              ' Subscribe for capturing events.
            Else
                SetPrompt("No se puede iniciar la operación de captura!")
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

        Try
            If PictureBox1.Image Is Nothing Then
                Invoke(New FunctionCall(AddressOf _picturebox1draw), bitmap)
            ElseIf PictureBox2.Image Is Nothing Then
                Invoke(New FunctionCall(AddressOf _picturebox2draw), bitmap)
            ElseIf PictureBox3.Image Is Nothing Then
                Invoke(New FunctionCall(AddressOf _picturebox3draw), bitmap)
            ElseIf PictureBox4.Image Is Nothing Then
                Invoke(New FunctionCall(AddressOf _picturebox4draw), bitmap)
            Else
            End If
        Catch ex As Exception
        End Try

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

    Protected Sub StartCapture()
        If (Capturer IsNot Nothing) Then
            Try
                Capturer.StartCapture()
                SetPrompt("Usando el lector de huellas digitales, escanee su huella digital.")
            Catch ex As DPFP.Error.SDKException
                'SetPrompt("Can't initiate capture!")
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "TransportGC")
            End Try
        End If
    End Sub
    Protected Sub StopCapture()
        If Capturer IsNot Nothing Then
            Try
                Capturer.StopCapture()
            Catch ex As Exception
                SetPrompt("No se puede terminar la captura!")
            End Try
        End If
    End Sub
    Private Sub CaptureForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        StopCapture()
        Me.Dispose()
    End Sub
    Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete

        If String.IsNullOrWhiteSpace(TUSUARIO.Text) Then
            MsgBox("No se ha introducido ningún nombre para esta captura.")
        Else
            MakeReport("La muestra de huellas dactilares fue capturada.")
            SetPrompt("Escanea la misma huella dactilar de nuevo.")
            Process(Sample)
        End If
    End Sub
    Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone
        MakeReport("El dedo fue retirado del lector de huellas dactilares.")
    End Sub

    Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
        MakeReport("El lector de huellas digitales fue tocado.")
    End Sub

    Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
        MakeReport("El lector de huellas digitales esta conectado.")
    End Sub

    Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
        MakeReport("El lector de huellas dactilares se desconectó.")
    End Sub

    Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
        If CaptureFeedback = DPFP.Capture.CaptureFeedback.Good Then
            MakeReport("La calidad de la muestra de huellas dactilares es buena.")
        Else
            MakeReport("La calidad de la muestra de huellas dactilares es mala.")
        End If
    End Sub
    Protected Sub SetStatus(ByVal status)
        Invoke(New FunctionCall(AddressOf _SetStatus), status)
    End Sub
    Private Sub _SetStatus(ByVal status)
        StatusLine.Text = status
    End Sub
    Protected Sub SetPrompt(ByVal text)

        Invoke(New FunctionCall(AddressOf _SetPrompt), text)
    End Sub
    Private Sub _SetPrompt(ByVal text)
        Prompt.Text = text
    End Sub
    Protected Sub MakeReport(ByVal status)
        Try
            Invoke(New FunctionCall(AddressOf _MakeReport), status)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub _MakeReport(ByVal status)
        StatusText.AppendText(status + Chr(13) + Chr(10))
    End Sub
    Protected Sub DrawPicture(ByVal bmp)
        Invoke(New FunctionCall(AddressOf _DrawPicture), bmp)
    End Sub
    Private Sub _DrawPicture(ByVal bmp)
        Picture.Image = New Bitmap(bmp, Picture.Size)
        ' My.Computer.Audio.Play(My.Resources.Single_wave, AudioPlayMode.Background)
    End Sub
    Sub _picturebox1draw(ByVal bmp)
        PictureBox1.Image = New Bitmap(bmp, 157, 168)
        ProgressBar1.Value = 25
    End Sub
    Sub _picturebox2draw(ByVal bmp)

        PictureBox2.Image = New Bitmap(bmp, 157, 168)
        ProgressBar1.Value = 50
    End Sub
    Sub _picturebox3draw(ByVal bmp)
        PictureBox3.Image = New Bitmap(bmp, 157, 168)
        ProgressBar1.Value = 75
    End Sub

    Sub _picturebox4draw(ByVal bmp)
        PictureBox4.Image = New Bitmap(bmp, 157, 168)
        ProgressBar1.Value = 100
    End Sub

    Sub pictureboxesclear()
        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
    End Sub

    Protected Sub Process(ByVal Sample As DPFP.Sample)

        Processs(Sample)
        ' Process the sample and create a feature set for the enrollment purpose.
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment)

        ' Check quality of the sample and add to enroller if it's good
        If features IsNot Nothing Then
            Try
                MakeReport("Se creó el conjunto de funciones de huellas dactilares.")
                Enroller.AddFeatures(features)        ' Add feature set to template.
            Finally
                UpdateStatus()
                ' Check if template has been created.
                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready    ' Report success and stop capturing

                        OnTemplate(Enroller.Template)
                        'SetPrompt("Click Close, and then click Fingerprint Verification.")
                        Template = Enroller.Template
                        StopCapture()
                    Case DPFP.Processing.Enrollment.Status.Failed   ' Report failure and restart capturing
                        Enroller.Clear()
                        StopCapture()
                        OnTemplate(Nothing)
                        StartCapture()

                End Select
            End Try
        End If
    End Sub
    Protected Sub UpdateStatus()
        SetStatus(String.Format("Se necesitan muestras de huellas dactilares: {0}", Enroller.FeaturesNeeded))
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Sub Savetemplate()

        If Not Directory.Exists(RUTA_HUELLAS) Then
            Directory.CreateDirectory(RUTA_HUELLAS)
        End If

        If Not Directory.Exists(RUTA_HUELLAS) Then
            Directory.CreateDirectory(RUTA_HUELLAS)
        End If

        If My.Computer.FileSystem.FileExists(RUTA_HUELLAS & "\" & TUSUARIO.Text & ".fpt") Then
            If MessageBox.Show("El usuario ya se ha inscrito", "", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else

                Using fs As IO.FileStream = IO.File.Open(RUTA_HUELLAS & "\" & TUSUARIO.Text & ".fpt", IO.FileMode.Create, IO.FileAccess.Write)
                    Template.Serialize(fs)
                End Using
                'PictureBox5.Image.Save(Application.StartupPath & "\Enrolled_faces\" & TextBox1.Text & ".jpg")
            End If
        Else

            Using fs As IO.FileStream = IO.File.Open(RUTA_HUELLAS & "\" & TUSUARIO.Text & ".fpt", IO.FileMode.Create, IO.FileAccess.Write)
                Template.Serialize(fs)
            End Using

            'PictureBox5.Image.Save(Application.StartupPath & "\Enrolled_faces\" & TextBox1.Text & ".jpg")
        End If
    End Sub


End Class
