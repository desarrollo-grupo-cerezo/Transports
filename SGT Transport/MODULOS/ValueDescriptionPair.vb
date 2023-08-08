Public Class ValueDescriptionPair

    Public ValuePair As Object
    Public DescriptionPair As String
    Public ClavePair As String
    Public ClavePair2 As String
    Public cboIndex As Integer

    Public Sub New(ByVal NewValue As Object, ByVal NewDescription As String, ByVal NewClave As String, NewClave2 As String, ByVal newcboIndex As Integer)
        ValuePair = NewValue
        DescriptionPair = NewDescription
        ClavePair = NewClave
        ClavePair2 = NewClave2
        cboIndex = newcboIndex
    End Sub

    Public Overrides Function ToString() As String
        Return DescriptionPair
    End Function

End Class
