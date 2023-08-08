Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging

Module ModCreateStoreProc

    Public Function CREA_SP_EMPLEADOS() As Boolean

        If Not EXISTE_STORE_PROCEDURE("spInsertEmployees") Then

            SQL = "CREATE TYPE dbo.EmpTableType AS TABLE
                (
                  Id  int, 
                  Name varchar(50),
                  Gender varchar(50)
                )"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                BITACORADB("33. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            SQL = "CREATE PROC spInsertEmployees
                @EmpTableType EmpTableType READONLY
                AS
                BEGIN
                    INSERT INTO Employees SELECT * FROM @EmpTableType
                END"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                BITACORADB("33. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        Return True

    End Function
End Module
