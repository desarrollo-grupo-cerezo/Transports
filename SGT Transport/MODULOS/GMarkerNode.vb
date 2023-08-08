Imports GMap.NET
Imports GMap.NET.WindowsForms

Public Class GMarkerNode

    Inherits GMapMarker
    Public Property Image() As Image

    Public Sub New(ByVal p As PointLatLng, ByVal image1 As Image)
        MyBase.New(p)
        Me.Image = image1
    End Sub

    Public Overrides Sub OnRender(ByVal g As Graphics)
        If Me.Image IsNot Nothing Then
            g.DrawImage(Me.Image, LocalPosition)
        End If
    End Sub
    Public Overrides Sub Dispose()
        MyBase.Dispose()
    End Sub

End Class
