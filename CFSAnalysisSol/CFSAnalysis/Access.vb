Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Autodesk.AutoCAD.ApplicationServices

Namespace DBAccess

    Public Class DAOObject

        Public Sub New()
        End Sub

        Private mCN As String
        Public Sub New(ByVal ConnectionString As String)
            'Allows us to use a CN String Other then the Default
            mCN = ConnectionString
        End Sub

        Protected Function GetConnection() As OleDb.OleDbConnection
            Dim myDir As String = Path.GetDirectoryName(Application.DocumentManager.MdiActiveDocument.Name)
            Dim ret_conn As OleDb.OleDbConnection
            Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & myDir & "\CFSmaster.accdb"
            If mCN = String.Empty Then
                ret_conn = New OleDbConnection(strConn) 'Use Default
            Else
                ret_conn = New OleDbConnection(mCN)
            End If
            ret_conn.Open()
            GetConnection = ret_conn
        End Function

        Protected Sub CloseConnection(ByVal conn As OleDbConnection)
            conn.Close()
            conn = Nothing
        End Sub

        'pass a Stored Procedure Name with parameters - returns a DataReader
        Public Overloads Function RunSPReturnRS(ByVal strSP As String, _
                ByVal ParamArray commandParameters() As OleDbParameter) As OleDbDataReader
            Dim cn As OleDbConnection = GetConnection()
            Dim rdr As OleDbDataReader
            Dim cmd As New OleDbCommand(strSP, cn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim p As OleDbParameter
            For Each p In commandParameters
                p = cmd.Parameters.Add(p)
                p.Direction = ParameterDirection.Input
            Next p
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            cmd.Dispose()
            Return rdr
        End Function

        'pass a Stored Procedure Name without parameters - returns a DataReader
        Public Overloads Function RunSPReturnRS(ByVal strSP As String) As OleDbDataReader
            Dim cn As OleDbConnection = GetConnection()
            Dim rdr As OleDbDataReader
            Dim cmd As New OleDbCommand(strSP, cn)
            cmd.CommandType = CommandType.StoredProcedure
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            cmd.Dispose()
            Return rdr
        End Function

        'run a "Pass Through" query - returns a DataReader
        Public Function RunPassSQL(ByVal strSQL As String) As OleDbDataReader
            Dim cn As OleDbConnection = GetConnection()
            Dim rdr As OleDbDataReader
            Dim cmd As New OleDbCommand(strSQL, cn)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            cmd.Dispose()
            Return rdr
        End Function

        'run an Action query - nothing returned
        Public Sub RunActionQuery(ByVal strSQL As String)
            Dim cn As OleDbConnection = GetConnection()
            Dim cmd As New OleDbCommand(strSQL, cn)
            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Finally
                CloseConnection(cn)
            End Try
        End Sub

        'pass stored procedure with parameters and datatable - returns a Dataset
        Public Overloads Function RunSPReturnDataSet(ByVal strSP As String, ByVal DataTableName As String, _
                        ByVal ParamArray commandParameters() As OleDbParameter) As DataSet
            Dim cn As OleDbConnection = GetConnection()
            Dim ds As New DataSet()
            Dim da As New OleDbDataAdapter(strSP, cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p As OleDbParameter
            For Each p In commandParameters
                da.SelectCommand.Parameters.Add(p)
                p.Direction = ParameterDirection.Input
            Next
            da.Fill(ds, DataTableName)
            CloseConnection(cn)
            da.Dispose()
            Return ds
        End Function

        'pass stored procedure with parameters - returns a Dataset
        Public Overloads Function RunSPReturnDataSet(ByVal strSP As String, _
                        ByVal ParamArray commandParameters() As OleDbParameter) As DataSet
            Dim cn As OleDbConnection = GetConnection()
            Dim ds As New DataSet()
            Dim da As New OleDbDataAdapter(strSP, cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim p As OleDbParameter
            For Each p In commandParameters
                da.SelectCommand.Parameters.Add(p)
                p.Direction = ParameterDirection.Input
            Next
            da.Fill(ds)
            CloseConnection(cn)
            da.Dispose()
            Return ds
        End Function

        'pass stored procedure - returns a Dataset
        Public Overloads Function RunSPReturnDataSet(ByVal strSP As String) As DataSet
            Dim cn As OleDbConnection = GetConnection()
            Dim ds As New DataSet()
            Dim da As New OleDbDataAdapter(strSP, cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(ds)
            CloseConnection(cn)
            da.Dispose()
            Return ds
        End Function

    End Class
End Namespace