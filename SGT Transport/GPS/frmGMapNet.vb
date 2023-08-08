Public Class frmGMapNet
    Dim L1 As Decimal, L2 As Decimal, L3 As Decimal, L4 As Decimal
    'Private map As GMapControl
    Dim Clave_uni As String
    Private Sub frmGMapNet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Clave_uni = Var1
        'map = New GMapControl()
        'Me.Controls.Add(map)
        Try
            L1 = frmWebServices.Fg(1, 11)
            L2 = frmWebServices.Fg(1, 12)
            L3 = frmWebServices.Fg(frmWebServices.Fg.Rows.Count - 1, 11)
            L4 = frmWebServices.Fg(frmWebServices.Fg.Rows.Count - 1, 12)
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Timer1.Enabled = False
    End Sub
    Private Sub barBuscar_Click(sender As Object, e As EventArgs) Handles barBuscar.Click
        '1. BOTON BUSCA         BOTON BUSCA         BOTON BUSCA         BOTON BUSCA 
        Dim Lat1 As Decimal, Lon1 As Decimal, z As Integer, j As Integer, FechaRuta As String = "", nRows As Integer = 0, Y1 As Integer
        'Dim m_ActiveMarker As GMarkerNode
        Dim m_ActiveImage As Image
        Try
            nRows = frmWebServices.Fg.Rows.Count - 1
            Select Case nRows
                Case 1 To 10
                    z = 1
                Case 11 To 30
                    z = 2
                Case Else
                    z = 2
            End Select
            j = 0
            Lat1 = frmWebServices.Fg(frmWebServices.Fg.Row, 11)
            Lon1 = frmWebServices.Fg(frmWebServices.Fg.Row, 12)
            FechaRuta = ""
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            m_ActiveImage = My.Resources.track29
            Pic.Image = m_ActiveImage
            'MP1.DisableFocusOnMouseEnter = True
            Y1 = z
            For k = 1 To nRows
                Try
                    Lat1 = frmWebServices.Fg(k, 11)
                    Lon1 = frmWebServices.Fg(k, 12)
                    FechaRuta = frmWebServices.Fg(k, 7)

                    If k = Y1 Then
                        'MP1.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(Lat1, Lon1), Markers.GMarkerGoogleType.arrow))
                        j = j + 1
                        Y1 = Y1 + z
                    End If
                Catch ex As Exception
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            'MP1.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(Lat1, Lon1), Markers.GMarkerGoogleType.red_dot))
            'Dim marker As Markers.GMarkerGoogle = New Markers.GMarkerGoogle(New PointLatLng(Lat1, Lon1), New Bitmap(archivo))
            'Try
            'm_ActiveMarker = MP1.Overlays(0).Markers(0)
            'm_ActiveMarker.Image = Pic.Image
            'MP1.Overlays(0).Markers(0) = m_ActiveMarker
            'Catch ex As Exception
            '   Bitacora("9.1. " & ex.Message & vbNewLine & ex.StackTrace)
            'End Try
            Try
            Catch ex As Exception
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barTrace_Click(sender As Object, e As EventArgs) Handles barTrace.Click

        '2. BOTON TRACE      BOTON TRACE      BOTON TRACE      BOTON TRACE      BOTON TRACE      
    End Sub

    Private Sub barRuta_Click(sender As Object, e As EventArgs) Handles barRuta.Click
        Try
            '3 BOTON RUTA         BOTON RUTA         BOTON RUTA         BOTON RUTA         BOTON RUTA         
            Dim Lat1 As Decimal, Lon1 As Decimal
            Dim Lat2 As Decimal, Lon2 As Decimal

            'map.Position = New PointLatLng(40.654331, -73.917067)
            Lat2 = frmWebServices.Fg(1, 11)
            Lon2 = frmWebServices.Fg(1, 12)
            For k = 1 To frmWebServices.Fg.Rows.Count - 1
                Lat1 = frmWebServices.Fg(k, 11)
                Lon1 = frmWebServices.Fg(k, 12)
            Next
            'map.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(40.657161, -73.921079), Markers.GMarkerGoogleType.red_dot))
            'map.Overlays(0).Markers(0).ToolTipText = "aqui"
            'map.Overlays(0).Markers(0).ToolTipMode = MarkerTooltipMode.Always 'Shows data Label with info - always visible on the map'
            'map.Overlays(0).Markers(0).IsVisible = True
            'map.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(40.65587, -73.915188), Markers.GMarkerGoogleType.red_dot))
            'map.Overlays(0).Markers(1).ToolTipText = "aqui"
            'map.Overlays(0).Markers(1).ToolTipMode = MarkerTooltipMode.Always 'Shows data Label with info - always visible on the map'
            'map.Overlays(0).Markers(1).IsVisible = True
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub
    Private Sub barNew1_Click(sender As Object, e As EventArgs) Handles barNew1.Click
        Try
            L1 = frmWebServices.Fg(1, 11)
            L2 = frmWebServices.Fg(1, 12)
            L3 = frmWebServices.Fg(frmWebServices.Fg.Rows.Count - 1, 11)
            L4 = frmWebServices.Fg(frmWebServices.Fg.Rows.Count - 1, 12)

        Catch exception As Exception
            MsgBox("： " & exception.Message, "GMap.NET")
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim Lat As Decimal
            Dim Lon As Decimal
            Dim r1 As Integer
            Dim r2 As Integer

            Timer1.Enabled = False
            r1 = frmWebServices.Fg.Row
            r2 = frmWebServices.Fg.Rows.Count - 1
            If r1 < r2 Then
                Lat = frmWebServices.Fg(frmWebServices.Fg.Row, 11)
                Lon = frmWebServices.Fg(frmWebServices.Fg.Row, 12)
                If r1 + 1 < r2 Then
                    frmWebServices.Fg.Row = frmWebServices.Fg.Row + 1
                End If
            End If
            Timer1.Enabled = True
        Catch ex As Exception
            Timer1.Enabled = True
            MsgBox("3. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("3. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub frmGMapNet_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub

End Class
