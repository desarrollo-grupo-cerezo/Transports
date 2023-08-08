Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Public Class frmGMapNet
    Dim L1 As Decimal, L2 As Decimal, L3 As Decimal, L4 As Decimal
    'Private map As GMapControl
    Private WithEvents route_layer As GMapOverlay
    Dim map_route As MapRoute
    Dim g_route As GMapRoute
    Dim Clave_uni As String
    Private Sub frmGMapNet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Clave_uni = Var1
        'map = New GMapControl()
        'Me.Controls.Add(map)
        Dim overlayOne As New GMapOverlay("OverlayOne")
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
            With MP1
                ' Home sweet home...
                .Position = New PointLatLng(L1, L2)

                .MapProvider = GoogleMapProvider.Instance
                .MinZoom = 3
                .MaxZoom = 30
                .Zoom = 8
                .Manager.Mode = AccessMode.ServerAndCache
                .CanDragMap = True
                .EmptyTileColor = Color.Green
                '.ShowTileGridLines = True
                .ShowCenter = False
                .MarkersEnabled = True
                .DragButton = MouseButtons.Left
                '.Manager.Mode = AccessMode.ServerOnly
                '.MapProvider = BingHybridMapProvider.Instance
                '.SetPositionByKeywords("París, Francia")
                .Overlays.Add(New GMapOverlay("markersOverlay"))
                .Overlays(0).Markers.Add(New GMarkerNode(.Position, Pic.Image))
            End With
            'overlayOne.Markers.Add(New PointLatLng(19.442288, -70.652266))
            MP1.Dock = DockStyle.Fill
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
            MP1.Overlays(0).Markers.Clear()
            'MP1.DisableFocusOnMouseEnter = True
            Y1 = z
            For k = 1 To nRows
                Try
                    Lat1 = frmWebServices.Fg(k, 11)
                    Lon1 = frmWebServices.Fg(k, 12)
                    FechaRuta = frmWebServices.Fg(k, 7)

                    If k = Y1 Then
                        'MP1.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(Lat1, Lon1), Markers.GMarkerGoogleType.arrow))
                        If z = Y1 Then
                            MP1.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(Lat1, Lon1), Markers.GMarkerGoogleType.red_dot))
                            MP1.Overlays(0).Markers(j).ToolTipText = Clave_uni & "  (" & FechaRuta & ")"
                            MP1.Overlays(0).Markers(j).ToolTipMode = MarkerTooltipMode.OnMouseOver ' .Always 'Shows data Label with info - always visible on the map'
                            MP1.Overlays(0).Markers(j).IsVisible = True
                            MP1.Overlays(0).Markers(j).Tag = FechaRuta
                        Else
                            MP1.Overlays(0).Markers(j).ToolTipText = Clave_uni & "  (" & FechaRuta & ")"
                            MP1.Overlays(0).Markers(j).ToolTipMode = MarkerTooltipMode.OnMouseOver ' .Always 'Shows data Label with info - always visible on the map'
                            MP1.Overlays(0).Markers(j).IsVisible = True
                            MP1.Overlays(0).Markers(j).Tag = FechaRuta
                        End If
                        If Y1 < frmWebServices.Fg.Rows.Count - 1 Then
                            MP1.Position = New PointLatLng(Lat1, Lon1)
                            MP1.Overlays(0).Markers.Add(New GMarkerNode(MP1.Position, Pic.Image))
                        End If
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
                MP1.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(Lat1, Lon1), Markers.GMarkerGoogleType.yellow_dot))
                MP1.Overlays(0).Markers(j).ToolTipText = Clave_uni & "(" & FechaRuta & ")"
                MP1.Overlays(0).Markers(j).ToolTipMode = MarkerTooltipMode.Always 'Shows data Label with info - always visible on the map'
                MP1.Overlays(0).Markers(j).IsVisible = True
                MP1.Refresh()
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
        Try

            MP1.Position = New PointLatLng(-25.974134, 32.593042)

            Dim start As PointLatLng = New PointLatLng(-25.974134, 32.593042)
            Dim [end] As PointLatLng = New PointLatLng(-25.959048, 32.592827)
            Dim route As MapRoute = GoogleMapProvider.Instance.GetRoute(start, [end], False, False, 15)

            Dim r As GMapRoute = New GMapRoute(route.Points, "My route")

            Dim routesOverlay As GMapOverlay = New GMapOverlay("routes")
            routesOverlay.Routes.Add(r)
            MP1.Overlays.Add(routesOverlay)

        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barRuta_Click(sender As Object, e As EventArgs) Handles barRuta.Click
        Try
            '3 BOTON RUTA         BOTON RUTA         BOTON RUTA         BOTON RUTA         BOTON RUTA         
            Dim Lat1 As Decimal, Lon1 As Decimal
            Dim Lat2 As Decimal, Lon2 As Decimal

            Dim mOverlayRoutes = New GMapOverlay("Route")
            MP1.Overlays.Add(mOverlayRoutes)
            'map.Position = New PointLatLng(40.654331, -73.917067)
            Lat2 = frmWebServices.Fg(1, 11)
            Lon2 = frmWebServices.Fg(1, 12)
            For k = 1 To frmWebServices.Fg.Rows.Count - 1
                Lat1 = frmWebServices.Fg(k, 11)
                Lon1 = frmWebServices.Fg(k, 12)
                MP1.Position = New PointLatLng(Lat1, Lon1)
                If k = 1 Then
                    MP1.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(Lat1, Lon1), Markers.GMarkerGoogleType.yellow_dot))
                Else
                    If k = frmWebServices.Fg.Rows.Count - 1 Then
                        MP1.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(Lat1, Lon1), Markers.GMarkerGoogleType.red_big_stop))
                    Else
                        MP1.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(Lat1, Lon1), Markers.GMarkerGoogleType.purple_pushpin))
                    End If
                End If
                'MP1.Overlays(0).Markers(k - 1).ToolTipText = k '"aqui"
                MP1.Overlays(0).Markers(k - 1).ToolTipMode = MarkerTooltipMode.Always 'Shows data Label with info - always visible on the map'
                MP1.Overlays(0).Markers(k - 1).IsVisible = True
            Next
            'map.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(40.657161, -73.921079), Markers.GMarkerGoogleType.red_dot))
            'map.Overlays(0).Markers(0).ToolTipText = "aqui"
            'map.Overlays(0).Markers(0).ToolTipMode = MarkerTooltipMode.Always 'Shows data Label with info - always visible on the map'
            'map.Overlays(0).Markers(0).IsVisible = True
            'map.Overlays(0).Markers.Add(New Markers.GMarkerGoogle(New PointLatLng(40.65587, -73.915188), Markers.GMarkerGoogleType.red_dot))
            'map.Overlays(0).Markers(1).ToolTipText = "aqui"
            'map.Overlays(0).Markers(1).ToolTipMode = MarkerTooltipMode.Always 'Shows data Label with info - always visible on the map'
            'map.Overlays(0).Markers(1).IsVisible = True
            Dim RP As RoutingProvider = DirectCast(MP1.MapProvider, RoutingProvider)
            Dim P1 As New PointLatLng(Lat2, Lon2)
            Dim P2 As New PointLatLng(Lat1, Lon1)
            Dim MP As MapRoute = RP.GetRoute(P1, P2, True, True, 35) 'Convert.ToInt32(map.Zoom)
            Dim R As New GMapRoute(MP.Points, "Route")
            Dim SB As New SolidBrush(Color.FromArgb(0, 0, 255, 0))
            R.Stroke = New Pen(SB, 6)
            mOverlayRoutes.Routes.Add(R)
            R.Stroke.Width = 4

            R.Stroke.Color = Color.SeaGreen
            MP1.Refresh()
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub MAP_Load(sender As Object, e As EventArgs) Handles MP1.Load

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

            Dim Lat1 As PointLatLng = New PointLatLng(L1, L2)
            Dim lat2 As PointLatLng = New PointLatLng(L3, L4)
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
                With MP1
                    ' Home sweet home...
                    .Position = New PointLatLng(Lat, Lon)
                    .MapProvider = BingMapProvider.Instance  ' = GoogleMapProvider.Instance
                    .MinZoom = 3
                    .MaxZoom = 17
                    .Zoom = 16
                    .Manager.Mode = AccessMode.ServerAndCache
                End With
                If r1 + 1 < r2 Then
                    frmWebServices.Fg.Row = frmWebServices.Fg.Row + 1
                End If
            End If
            MP1.Refresh()
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

    Private Sub MAP_MouseClick(sender As Object, e As MouseEventArgs) Handles MP1.MouseClick
        Try
            Dim lat As Decimal
            Dim lng As Decimal

            If e.Button = System.Windows.Forms.MouseButtons.Left Then
                lat = MP1.FromLocalToLatLng(e.X, e.Y).Lat
                lng = MP1.FromLocalToLatLng(e.X, e.Y).Lng


                Dim mouseY As Integer
                Dim mouseX As Integer

                lat = MP1.FromLocalToLatLng(e.X, e.Y).Lat
                lng = MP1.FromLocalToLatLng(e.X, e.Y).Lng
                Lt.Text = "lat= " & Convert.ToString(lat) & "   lng= " + Convert.ToString(lng)
                Lt.BackColor = Color.Transparent

                mouseY = e.Location.Y + 25
                mouseX = e.Location.X

                Lt.Location = New Point(mouseX, mouseY + 10)
            End If

        Catch ex As Exception
            Bitacora("4s. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
