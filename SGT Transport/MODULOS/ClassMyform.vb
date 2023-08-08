Public Class MyApp

    Public Shared cOpenForms As Collection

    'Place this at the top of your
    'set of Forms, e.g. in your MyApp Class.
    'Place this in the load sequence of MyApp.

    Public Shared Sub SetOpenForm(NamedForm As Form)
        'Saves an Open Form in the Collection of Open Forms
        'Call this every time a New Form is created (if you want to revisit it).
        MyApp.cOpenForms.Add(NamedForm)
    End Sub

    Public Shared Sub RemoveOpenForm(NamedForm As Form)
        'Removes an Open Form in the Collection of Open Forms, if it is present.  
        'Silently ignores Forms that are not in the Collection.
        'Call this every time a Form is finished with, Closed, Disposed.
        If Not IsNothing(NamedForm) Then
            If MyApp.cOpenForms.Contains(NamedForm.Name) Then
                MyApp.cOpenForms.Remove(NamedForm.Name)
            End If
        End If
    End Sub
    Public Shared Function GetOpenForm(FormName As String) As Form
        'Retrieves a Form if it is in the Collection of Open Forms
        'Call this to retrieve Form FormName; then check for IsNothing.
        For Each f As Form In MyApp.cOpenForms
            If f.Name = FormName Then
                Return f
            End If
        Next
        Return Nothing
    End Function
End Class
Public Class MyBackGroundColors
    Public Sub DoSet(ByVal parentCtr As Control)
        Try
            Dim ctr As Control
            For Each ctr In parentCtr.Controls
                AddHandler ctr.LostFocus, AddressOf MeLostFocus
                AddHandler ctr.GotFocus, AddressOf MeGotFocus
                DoSet(ctr)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MeLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            DirectCast(sender, Control).BackColor = Mycolor2 'SystemColors.Window
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MeGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            DirectCast(sender, Control).BackColor = Mycolor1
        Catch ex As Exception
        End Try
    End Sub
End Class
