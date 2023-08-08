Public Class WaitCursor

    'Inherits IDisposable

    Public Sub New()
        IsWaitCursor = True
    End Sub

    Public Sub Dispose()
        IsWaitCursor = False
    End Sub

    Public Property IsWaitCursor As Boolean
        Get
            Return Application.UseWaitCursor
        End Get
        Set(ByVal value As Boolean)

            If Application.UseWaitCursor <> value Then
                Application.UseWaitCursor = value
                Cursor.Current = If(value, Cursors.WaitCursor, Cursors.[Default])
            End If
        End Set
    End Property
End Class
