Public Class SesionDocumento
    Public IdControl As Long
    Public IdControlPad As Long
    Public Tbl As String
    Public TblTipo As String
    Public TblID As String
    Public Nombre As String

    Public Sub New()
        IdControl = 0
        IdControlPad = 0
        Tbl = String.Empty
        TblTipo = String.Empty
        TblID = String.Empty
        Nombre = String.Empty
    End Sub
    Public Sub New(pTbl As String, pTblTipo As String, pTblID As String, pNombre As String)
        IdControl = 0
        IdControlPad = 0
        Tbl = pTbl
        TblTipo = pTblTipo
        TblID = pTblID
        Nombre = pNombre
    End Sub

    Public Sub New(pTbl As String, pTblID As String, pNombre As String)
        IdControl = 0
        IdControlPad = 0
        TblTipo = String.Empty
        Tbl = pTbl
        TblID = pTblID
        Nombre = pNombre
    End Sub

    Public Sub New(pIdControlPad As Long, pTbl As String, pTblTipo As String, pTblID As String, pNombre As String)
        IdControl = 0
        IdControlPad = pIdControlPad
        Tbl = pTbl
        TblTipo = pTblTipo
        TblID = pTblID
        Nombre = pNombre
    End Sub


End Class
