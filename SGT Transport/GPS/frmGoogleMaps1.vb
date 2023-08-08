Imports GMap
Imports GMap.NET
Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers

Public Class frmGoogleMaps1
    Dim marker As GMarkerGoogle
    Dim markerOverlay As GMapOverlay
    Dim dt As DataTable
    Dim selection As Integer = 0

    Dim Lat As Double = 18.04173
    Dim Lng As Double = -92.90129

    Private Sub frmGoogleMaps1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt = GetTable()
        For Each dr As DataRow In dt.Rows
            'Tạo marker position map
            markerOverlay = New GMapOverlay(dr.Item("Name"))
            marker = New GMarkerGoogle(New PointLatLng(dr.Item("Lat"), dr.Item("Lng")), GMarkerGoogleType.red_dot)
            markerOverlay.Markers.Add(marker)
            marker.ToolTipMode = MarkerTooltipMode.Always
            marker.ToolTipText = String.Format("{0}" + vbNewLine + " Mapa 1: {1} " + vbNewLine + " Mapa 2: {2}", dr.Item("Name"), dr.Item("Lat"), dr.Item("Lng"))
            GMapControl1.Overlays.Add(markerOverlay)
        Next

        GMapControl1.DragButton = MouseButtons.Left
        GMapControl1.CanDragMap = True
        GMapControl1.MapProvider = GMapProviders.GoogleMap
        GMapControl1.Position = New PointLatLng(Lat, Lng)
        GMapControl1.MinZoom = 0
        GMapControl1.MaxZoom = 24
        GMapControl1.Zoom = 12
        GMapControl1.AutoScroll = True

        CreateCircle(Lat, Lng, 10000)

    End Sub
    Function GetTable() As DataTable
        Dim table As New DataTable

        table.Columns.Add("Name", GetType(String))
        table.Columns.Add("Lat", GetType(Double))
        table.Columns.Add("Lng", GetType(Double))

        table.Rows.Add("Lugar 1 ", 18.90343, -92.90129)
        table.Rows.Add("Lugar 2 ", 18.04173, -92.90194)
        table.Rows.Add("Lugar 3 ", 18.04101, -92.90192)
        table.Rows.Add("Lugar 4 ", 18.04101, -92.90192)
        table.Rows.Add("Lugar 5 ", 18.04099, -92.90193)
        Return table
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GMapControl1.Position = New PointLatLng(Lat, Lng)
        GMapControl1.Zoom = 12

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub GMapControl1_OnMapZoomChanged() Handles GMapControl1.OnMapZoomChanged

    End Sub

    Private Sub CreateCircle(ByVal lat As Double, ByVal lon As Double, ByVal radius As Double)
        Dim point As PointLatLng = New PointLatLng(lat, lon)
        Dim segments As Integer = 1000
        Dim gpollist As List(Of PointLatLng) = New List(Of PointLatLng)()
        For i As Integer = 0 To segments - 1
            gpollist.Add(FindPointAtDistanceFrom(point, i, radius / 1000))
        Next

        Dim gpol As GMapPolygon = New GMapPolygon(gpollist, "Circle")
        Dim polyOverlay As GMapOverlay = New GMapOverlay("Circle")

        gpol.Stroke.DashStyle = Drawing2D.DashStyle.Custom
        gpol.Fill = New SolidBrush(Color.FromArgb(50, Color.Red)) ' Thay màu ở đây
        gpol.Stroke = New Pen(Color.FromArgb(30, Color.Red), 1) ' Thay màu ở đây


        GMapControl1.Overlays.Add(polyOverlay)
        polyOverlay.Polygons.Add(gpol)
    End Sub

    Public Shared Function FindPointAtDistanceFrom(ByVal startPoint As GMap.NET.PointLatLng, ByVal initialBearingRadians As Double, ByVal distanceKilometres As Double) As GMap.NET.PointLatLng
        Const radiusEarthKilometres As Double = 6371.01
        Dim distRatio = distanceKilometres / radiusEarthKilometres
        Dim distRatioSine = Math.Sin(distRatio)
        Dim distRatioCosine = Math.Cos(distRatio)
        Dim startLatRad = DegreesToRadians(startPoint.Lat)
        Dim startLonRad = DegreesToRadians(startPoint.Lng)
        Dim startLatCos = Math.Cos(startLatRad)
        Dim startLatSin = Math.Sin(startLatRad)
        Dim endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)))
        Dim endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos, distRatioCosine - startLatSin * Math.Sin(endLatRads))
        Return New GMap.NET.PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads))
    End Function

    Public Shared Function DegreesToRadians(ByVal degrees As Double) As Double
        Const degToRadFactor As Double = Math.PI / 180
        Return degrees * degToRadFactor
    End Function

    Public Shared Function RadiansToDegrees(ByVal radians As Double) As Double
        Const radToDegFactor As Double = 180 / Math.PI
        Return radians * radToDegFactor
    End Function


End Class
