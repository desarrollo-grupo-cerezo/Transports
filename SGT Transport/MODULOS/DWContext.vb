Imports System.Data.Entity.Core.EntityClient

Partial Public Class DWContext

    Public Sub New(ByVal nameOrConnectionString As String)
        MyBase.New()
    End Sub

    Public Shared Function Create(ByVal providerConnectionString As String) As DWContext
        Dim entityBuilder = New EntityConnectionStringBuilder With {
            .ProviderConnectionString = providerConnectionString,
            .Provider = "System.Data.SqlClient",
            .Metadata = "res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;" &
                                "provider connection string=data source=" & Servidor & ";initial catalog=" & Base &
                                ";persist security info=True;user id=" & Usuario & ";password=" & Pass & ";MultipleActiveResultSets=True;App=EntityFramework"
        }
        Return New DWContext(entityBuilder.ConnectionString)
    End Function

End Class
