<Serializable>
Public Class ApplicationItem
    Public Property application_id() As String
        Get
            Return m_application_id
        End Get
        Set
            m_application_id = Value
        End Set
    End Property
    Private m_application_id As String
    Public Property application_package() As String
        Get
            Return m_application_package
        End Get
        Set
            m_application_package = Value
        End Set
    End Property
    Private m_application_package As String
End Class
