
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Windows
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class SQLQ

    Private ReadOnly _ConnStr As String

    Private _QuerySQL As String

    Public WriteOnly Property QuerySQL As String
        Set(ByVal value As String)
            _QuerySQL = value
        End Set
    End Property

    Private _DatosRegresados As DataTable

    Private _showException As Boolean

    Private _DataSetRegresado As DataSet

    Private _ComandoSP As SqlClient.SqlCommand

    Private _error As String

    Public ReadOnly Property [Error] As String
        Get
            Return _error
        End Get
    End Property

    Public WriteOnly Property ShowException As Boolean
        Set(ByVal value As Boolean)
            _showException = value
        End Set
    End Property

    Public Sub New(ByVal connStr As String)
        _ConnStr = connStr
        _showException = False
    End Sub

    Public Sub New()
    End Sub

    Public Function EjecutaSQL(ByVal SQL As String) As Boolean
        Try
            _QuerySQL = SQL

            Dim sqlData As SqlDataAdapter = New SqlDataAdapter(_QuerySQL, cnSAE)
            Dim ds As DataSet = New DataSet()
            Dim cuantas As Integer = sqlData.Fill(ds)
            'Conexion.Close()
            If ds.Tables.Count > 0 Then _DatosRegresados = ds.Tables(0)
        Catch e As Exception
            MessageBox.Show(e.ToString())
        End Try

        Return True
    End Function

    Public ReadOnly Property NumRenglones As Integer
        Get
            If _DatosRegresados Is Nothing Then Return 0
            Return _DatosRegresados.Rows.Count
        End Get
    End Property

    Public ReadOnly Property NumColumnas As Integer
        Get
            If _DatosRegresados Is Nothing Then Return 0
            Return _DatosRegresados.Columns.Count
        End Get
    End Property

    Public ReadOnly Property Tabla As DataTable
        Get
            Return _DatosRegresados
        End Get
    End Property

    Public ReadOnly Property Tablas As DataSet
        Get
            Return _DataSetRegresado
        End Get
    End Property

    Public Sub CreaNuevoSP(ByVal sp As String)
        _ComandoSP = New SqlCommand With {
            .CommandText = sp,
            .CommandType = System.Data.CommandType.StoredProcedure
        }
    End Sub

    Public Sub AgregaParam(ByVal nombre As String, ByVal valor As Object)
        _ComandoSP.Parameters.AddWithValue(nombre, valor)
    End Sub

    Public Sub AgregaParam(ByVal nombre As String, ByVal tipo As SqlDbType, ByVal valor As Object)
        Dim param As SqlParameter = New SqlParameter("?" & nombre, tipo)
        param.Value = valor
        _ComandoSP.Parameters.Add(param)
    End Sub

    Public Sub AgregaParam(ByVal nombre As String, ByVal tipo As DbType, ByVal valor As Object)
        Dim param As SqlParameter = New SqlParameter("?" & nombre, tipo) With {
            .Value = valor
        }
        _ComandoSP.Parameters.Add(param)
    End Sub

    Public Function EjecutaSP() As Boolean
        Dim Conn As SqlConnection = New SqlConnection(_ConnStr)
        Try
            Conn.Open()
            _ComandoSP.Connection = Conn
            Dim sqa As SqlDataAdapter = New SqlDataAdapter(_ComandoSP)
            _DatosRegresados = New DataTable()
            sqa.Fill(_DatosRegresados)
            Conn.Close()
        Catch e As Exception
            If _showException Then MessageBox.Show(e.ToString())
            _error = e.ToString()
            Return False
        End Try

        Return True
    End Function

    Public Function EjecutaSPDataSet() As Boolean
        Dim Conn As SqlConnection = New SqlConnection(_ConnStr)
        Try
            Conn.Open()
            _ComandoSP.Connection = Conn
            Dim sqa As SqlDataAdapter = New SqlDataAdapter(_ComandoSP)
            _DataSetRegresado = New DataSet()
            sqa.Fill(_DataSetRegresado)
            Conn.Close()
        Catch e As Exception
            If _showException Then MessageBox.Show(e.ToString())
            Return False
        End Try

        Return True
    End Function

    Public Function EjecutaSPNonQuery() As Boolean
        Dim Conn As SqlConnection = New SqlConnection(_ConnStr)
        Try
            Conn.Open()
            _ComandoSP.Connection = Conn
            _ComandoSP.ExecuteNonQuery()
            Conn.Close()
        Catch e As Exception
            MessageBox.Show(e.ToString())
            Return False
        End Try

        Return True
    End Function

    Public Sub AgregaParamReturn(ByVal nombre As String)
        _ComandoSP.Parameters.Add("@" & nombre, SqlDbType.Int)
        _ComandoSP.Parameters("@" & nombre).Direction = ParameterDirection.Output
    End Sub

    Public Sub AgregaParamReturn(ByVal nombre As String, ByVal type As SqlDbType)
        _ComandoSP.Parameters.Add("@" & nombre, type)
        _ComandoSP.Parameters("@" & nombre).Direction = ParameterDirection.Output
    End Sub

    Public Function ObtenParam(ByVal nombre As String) As String
        Try
            Return _ComandoSP.Parameters("@" & nombre).Value.ToString()
        Catch __unusedException1__ As Exception
            Return Nothing
        End Try
    End Function

    Public Function StrVal(ByVal col As String) As String
        Return Tabla.Rows(0)(col).ToString()
    End Function

    Public Function StrVal(ByVal index As Integer, ByVal col As String) As String
        Return Tabla.Rows(index)(col).ToString()
    End Function

    Public Function IntVal(ByVal col As String) As Integer
        Dim res As Boolean
        Dim val As Integer
        res = Int32.TryParse(Tabla.Rows(0)(col).ToString(), val)
        If res Then Return val Else Return 0
    End Function

    Public Function IntVal(ByVal index As Integer, ByVal col As String) As Integer
        Dim res As Boolean
        Dim val As Integer
        res = Int32.TryParse(Tabla.Rows(index)(col).ToString(), val)
        If res Then Return val Else Return 0
    End Function

    Public Function LongVal(ByVal col As String) As Long
        Return Long.Parse(Tabla.Rows(0)(col).ToString())
    End Function

    Public Function LongVal(ByVal index As Integer, ByVal col As String) As Long
        Return Long.Parse(Tabla.Rows(index)(col).ToString())
    End Function

    Public Function BoolVal(ByVal col As String) As Boolean
        Return Boolean.Parse(Tabla.Rows(0)(col).ToString())
    End Function

    Public Function BoolVal(ByVal index As Integer, ByVal col As String) As Boolean
        Return Boolean.Parse(Tabla.Rows(index)(col).ToString())
    End Function
End Class

