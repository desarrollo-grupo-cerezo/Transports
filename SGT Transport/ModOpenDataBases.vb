Imports System.Data.SqlClient

Module ModOpenDataBases

    Public Async Function OpenSAEAsync(ByVal fEmpresa) As Threading.Tasks.Task(Of Boolean)
        If Valida_Conexion_SAROCE() Then
        End If
        Try
            Dim SQLstr As String = "SELECT * FROM EMPRESAS WHERE EMPRESA = '" & fEmpresa & "'"
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim Conexion As String = ""

            cmd.Connection = cnSAROCE
            cmd.CommandText = SQLstr
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                Conexion = "server=" & dr("Servidor") & ";uid=" & dr("usuario") & ";password=" & dr("pass") &
                           ";database=" & dr("base") & ";MultipleActiveResultSets=true;Connect Timeout=180"
            End If
            dr.Close()
            If Conexion.Trim.Length > 0 Then
                cnSAE = New SqlConnection(Conexion)
                Await cnSAE.OpenAsync()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function OpenSQLSERVER(ByVal fEmpresa) As Boolean
        If Valida_Conexion_SAROCE() Then
        End If
        Try
            Dim SQLstr As String = "SELECT * FROM EMPRESAS WHERE EMPRESA = '" & fEmpresa & "'"
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim Conexion As String = ""

            cmd.Connection = cnSAROCE
            cmd.CommandText = SQLstr
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                Conexion = "server=" & dr("Servidor") & ";uid=" & dr("usuario") & ";password=" & dr("pass") &
                           ";database=" & dr("base") & ";Persist Security Info=True;MultipleActiveResultSets=true;Encrypt=False;Connect Timeout=180"
            End If
            dr.Close()
            If Conexion.Trim.Length > 0 Then
                cnSAE = New SqlConnection(Conexion)
                cnSAE.Open()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Public Function OpenSAE(fServidor As String, ByVal fBase As String, ByVal fUser As String, ByVal fPass As String) As Boolean
        Dim Conexion As String = ""
        Try
            Conexion = "server=" & fServidor & ";uid=" & fUser & ";password=" & fPass & ";database=" & fBase & ";MultipleActiveResultSets=true"

            cnSQL = New SqlConnection(Conexion)
            cnSQL.Open()
            Return True
        Catch ex As Exception
            Bitacora("3. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & Conexion)
            Return False
        End Try
    End Function
    Public Function Valida_Conexion() As Boolean
        Dim Open_db As Boolean, Hay_Error As Boolean, ConexOK As Boolean

        Try
            Try
                If IsNothing(cnSAE.State) Then
                    ConexOK = False
                    For k = 1 To 6
                        If OpenSQLSERVER(Empresa) Then
                            Threading.Thread.Sleep(k * 1000)
                            ConexOK = True
                            Exit For
                        End If
                    Next
                    If ConexOK Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Catch ex As Exception
                Bitacora("4. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Open_db = True
            Select Case cnSAE.State
                Case ConnectionState.Broken
                    Open_db = False
                    'MsgBox("broken")
                Case ConnectionState.Closed
                    Open_db = False
                    'MsgBox("La basa de datos esta cerrada", , "General 1")
                Case ConnectionState.Connecting
                    'MsgBox("connectiong")
                Case ConnectionState.Executing
                    'MsgBox("executing")
                Case ConnectionState.Fetching
                    'MsgBox("Fetching")
                Case ConnectionState.Open
                    'MsgBox("Open")
            End Select

            If Not Open_db Then
                ConexOK = False
                For k = 1 To 6
                    If OpenSQLSERVER(Empresa) Then
                        Threading.Thread.Sleep(k * 1000)
                        ConexOK = True
                        Exit For
                    End If
                Next
                If ConexOK Then
                    Return True
                Else
                    MsgBox("Imposible conectarse a la base de datos, de la empresa " & Empresa, , "General 2")
                    Return False
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Bitacora("4. " & ex.Message & vbNewLine & ex.StackTrace)
            Hay_Error = True
        End Try

        Try
            If Hay_Error Then
                ConexOK = False
                For k = 1 To 6
                    If OpenSQLSERVER(Empresa) Then
                        Threading.Thread.Sleep(k * 1000)
                        ConexOK = True
                        Exit For
                    End If
                Next
                If ConexOK Then
                    Return True
                Else
                    MsgBox("Imposible conectarse a la base de datos, de la empresa " & Empresa, , "General 2")
                    Return False
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Valida_Conexion_SAROCE() As Boolean
        Dim Open_db As Boolean, ConexOK As Boolean
        Try
            If IsNothing(cnSAROCE.State) Then
                ConexOK = False
                For k = 1 To 5
                    If Not OpenSAROCE(Servidor_SAROCE, Base_SAROCE, Usuario_SAROCE, Pass_SAROCE) Then
                        Threading.Thread.Sleep(3000)
                        ConexOK = True
                        Exit For
                    End If
                Next
                If ConexOK Then
                    Return True
                Else
                    Return False
                End If
            End If

            Open_db = True
            Select Case cnSAROCE.State
                Case ConnectionState.Broken
                    Open_db = False
                    MsgBox("broken SAROCE")
                Case ConnectionState.Closed
                    Open_db = False
                    MsgBox("La basa de datos SAROCE esta cerrada", , "General SAROCE ")
                Case ConnectionState.Connecting
                    'MsgBox("connectiong")
                Case ConnectionState.Executing
                    'MsgBox("executing")
                Case ConnectionState.Fetching
                    MsgBox("Fetching")
                Case ConnectionState.Open
                    'MsgBox("Open")
            End Select

            If Not Open_db Then

                ConexOK = False
                For k = 1 To 5
                    If Not OpenSAROCE(Servidor_SAROCE, Base_SAROCE, Usuario_SAROCE, Pass_SAROCE) Then
                        Threading.Thread.Sleep(3000)
                        ConexOK = True
                        Exit For
                    End If
                Next
                If ConexOK Then
                    Return True
                Else
                    MsgBox("Imposible conectarse a la base de datos SAROCE", , "General 2")
                    Return False
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            Bitacora("4. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try

    End Function

    Public Function OpenGPS(fServidor As String, ByVal fBase As String, ByVal fUser As String, ByVal fPass As String) As Boolean

        Dim Conexion As String = ""
        Try

            Conexion = "server=" & fServidor & ";uid=" & fUser & ";password=" & fPass & ";database=" & fBase & ";MultipleActiveResultSets=true"

            cnGPS = New SqlConnection(Conexion)
            cnGPS.Open()
            Return True
        Catch ex As Exception
            'MsgBox("Imposible conectarse a la base de GPS " & ex.Message & vbNewLine & ex.StackTrace)
            'Bitacora("SAROCE " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function


    Public Function OpenSAROCE(fServidor As String, ByVal fBase As String, ByVal fUser As String, ByVal fPass As String, Optional NoValidaOpen As Boolean = True) As Boolean

        Dim Conexion As String = ""
        Try

            Conexion = "server=" & fServidor & ";uid=" & fUser & ";password=" & fPass & ";database=" & fBase & ";MultipleActiveResultSets=true"

            cnSAROCE = New SqlConnection(Conexion)
            cnSAROCE.Open()
            Return True
        Catch ex As Exception
            If NoValidaOpen Then
                MsgBox("G. Imposible conectarse a la base de configuración " & fBase)
            End If
            Bitacora("SAROCE " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function


    Public Function OpenEmpresa(ByVal fEmpresa) As Boolean
        Try
            Dim SQLstr As String = "SELECT * FROM EMPRESAS WHERE EMPRESA = '" & fEmpresa & "'"
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim Conexion As String = ""
            Dim Conexion2 As String = ""

            cmd.Connection = cnSAROCE
            cmd.CommandText = SQLstr
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                Conexion = "server=" & dr("Servidor") & ";uid=" & dr("usuario") & ";password=" & dr("pass") &
                           ";database=" & dr("base") & ";MultipleActiveResultSets=true;Connect Timeout=120"
            End If
            dr.Close()
            cnEMPRESA = New SqlConnection(Conexion)
            cnEMPRESA.Open()

            Return True
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Sub Close_conexiones()

        Try
            SQLConn.Close()
        Catch ex As Exception
        End Try
        Try
            Select Case cnSAE.State
                Case ConnectionState.Broken
                    'MsgBox("broken")
                Case ConnectionState.Closed
                    'MsgBox("close")
                Case ConnectionState.Connecting
                    'MsgBox("connectiong")
                    cnSAE.Close()
                Case ConnectionState.Executing
                    'MsgBox("executing")
                    cnSAE.Close()
                Case ConnectionState.Fetching
                    'MsgBox("Fetching")
                    cnSAE.Close()
                Case ConnectionState.Open
                    'MsgBox("Open")
                    cnSAE.Close()
            End Select

        Catch ex As Exception
        End Try

        Try
        Catch ex As Exception
        End Try

    End Sub

End Module


Public Module DataReaderExtensions

    ''' <summary>
    ''' Reads fieldName from Data Reader. If fieldName is DbNull, returns String.Empty.
    ''' </summary>
    ''' <returns>Safely returns a string. No need to check for DbNull.</returns>
    <System.Runtime.CompilerServices.Extension()>
    Public Function ReadNullAsEmptyString(ByVal reader As IDataReader, ByVal fieldName As String) As String
        If IsDBNull(reader(fieldName)) Then
            Return String.Empty
        Else
            Return reader(fieldName)
        End If
        Return False
    End Function
    <System.Runtime.CompilerServices.Extension()>
    Public Function ReadNullAsEmptyDecimal(ByVal reader As IDataReader, ByVal fieldName As String) As Decimal
        If IsDBNull(reader(fieldName)) Then
            Return 0
        Else
            Return reader(fieldName)
        End If
        Return False
    End Function
    <System.Runtime.CompilerServices.Extension()>
    Public Function ReadNullAsEmptyInteger(ByVal reader As IDataReader, ByVal fieldName As String) As Integer
        If IsDBNull(reader(fieldName)) Then
            Return 0
        Else
            Return reader(fieldName)
        End If
        Return False
    End Function
    <System.Runtime.CompilerServices.Extension()>
    Public Function ReadNullAsEmptyLong(ByVal reader As IDataReader, ByVal fieldName As String) As Long
        If IsDBNull(reader(fieldName)) Then
            Return 0
        Else
            Return reader(fieldName)
        End If
        Return False
    End Function
    ''' <summary>
    ''' Reads fieldOrdinal from Data Reader. If fieldOrdinal is DbNull, returns String.Empty.
    ''' </summary>
    ''' <returns>Safely returns a string. No need to check for DbNull.</returns>
    <System.Runtime.CompilerServices.Extension()>
    Public Function ReadString(ByVal reader As IDataReader, ByVal fieldOrdinal As Integer) As String
        If IsDBNull(reader(fieldOrdinal)) Then
            Return ""
        Else
            Return reader(fieldOrdinal)
        End If
        Return False
    End Function

End Module
