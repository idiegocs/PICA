Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class ConnectDB


#Region "Atributos"
    Dim oleConnection As OleDbConnection
    Dim oleTransaction As OleDbTransaction

    Private strQuery As String
    Private strMessage As String
#End Region

#Region "Propiedades"
    Public ReadOnly Property GetMenssage() As String
        Get
            Return strMessage
        End Get
    End Property

    ''' <summary>
    ''' Juan Carlos Villero
    ''' 2014-01-24
    ''' Propiedad usada para abrir conexiones a la BD desde la capa DAL
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetOleConnection() As OleDbConnection
        Get
            Return oleConnection
        End Get
    End Property

    ''' <summary>
    ''' Propiedad usada para abrir transacciones a la BD desde la capa DAL
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GetOleTransaction() As OleDbTransaction
        Get
            Return oleTransaction

        End Get
        Set(ByVal Value As OleDbTransaction)
            oleTransaction = Value
        End Set
    End Property

#End Region

#Region "Constructor"
    ''' <summary>
    ''' Constructor de la clase
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        oleConnection = New OleDbConnection()

        oleConnection.ConnectionString = ConfigurationManager.ConnectionStrings("DHLConnectionString").ConnectionString

    End Sub

    ''' <summary>
    ''' Constructor de la clase
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal conexion As String)
        oleConnection = New OleDbConnection()

        oleConnection.ConnectionString = ConfigurationManager.ConnectionStrings(conexion).ConnectionString

    End Sub
#End Region

#Region "Métodos"

    ''' <summary>
    ''' Sentencia que se ejecutará
    ''' </summary>
    ''' <param name="s1">Sentencia SQL</param>
    ''' <remarks></remarks>
    Public Sub SetQuery(ByVal s1 As String)
        strQuery = s1
    End Sub

    ''' <summary>
    ''' Ejecuta una instrucción SQL (INSERT/UPDATE/DELETE) y devuelve el número de filas afectadas ([String])
    ''' </summary>
    ''' <returns>[String]</returns>
    ''' <remarks></remarks>
    Public Function ExecuteNonQuery() As [String]
        Try
            Dim intReturn As Integer
            Dim oleCommand As New System.Data.OleDb.OleDbCommand()
            oleCommand.Connection = oleConnection
            oleCommand.CommandTimeout = 1200
            oleConnection.Open()
            oleTransaction = oleConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Se pasa el nombre de la conexion al Objeto oleCommand
            oleCommand.Connection = oleConnection
            ' SE pasa el nombre de la transaccion al objeto oleCommand
            oleCommand.Transaction = oleTransaction
            oleCommand.CommandText = strQuery
            intReturn = oleCommand.ExecuteNonQuery()
            oleTransaction.Commit()
            ' Dejamos en firme
            Me.strMessage = "0"
            Return intReturn.ToString
        Catch e As Exception
            oleTransaction.Rollback()
            Me.strMessage = "-1"
            If e.Message.Contains("IX_MGP_PERSPECTIVE") Then
                Return "100"
            ElseIf e.Message.Contains("PRIMARY KEY") Then
                Return "101"
            ElseIf e.Message.Contains("REFERENCE") Then
                Return "103"
            ElseIf e.Message.Contains("FOREIGN KEY") Then
                Return "104"
            Else
                Return "-1"
            End If
        Finally
            oleConnection.Close()
        End Try
    End Function

    ''' <summary>
    ''' Ejecuta una instrucción SQL (SELECT) y devuelve un conjunto de datos ([DataSet])
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecuteQuery() As DataSet

        Try
            Dim oleCommand As New OleDbCommand()
            Dim oleAdapter As New OleDbDataAdapter()
            Dim ds As New DataSet
            oleCommand.Connection = oleConnection
            oleCommand.CommandTimeout = 1200
            oleConnection.Open()
            oleTransaction = oleConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Se pasa el nombre de la conexion al Objeto oleCommand
            oleCommand.Connection = oleConnection
            ' SE pasa el nombre de la transaccion al objeto oleCommand
            oleCommand.Transaction = oleTransaction
            oleCommand.CommandText = strQuery
            'oleCommand.ExecuteReader()
            oleAdapter.SelectCommand = oleCommand
            oleAdapter.Fill(ds)
            oleTransaction.Commit()
            ' Dejamos en firme
            Me.strMessage = "0"
            Return ds
        Catch e As Exception
            oleTransaction.Rollback()
            Me.strMessage = "-1"
            Return Nothing
        Finally
            oleConnection.Close()
        End Try
    End Function

    ''' <summary>
    '''  Ejecuta una o mas instrucciones SQL  y devuelve un unico valor (la primera columna de la primera fila de la última sentencia, las demas filas y columnas no se tienen en cuenta)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecuteScalar() As Object
        Try
            Dim oleCommand As New OleDbCommand()

            Dim objReturn As Object

            oleCommand.Connection = oleConnection
            oleCommand.CommandTimeout = 1200
            oleConnection.Open()
            oleTransaction = oleConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Se pasa el nombre de la conexion al Objeto oleCommand
            oleCommand.Connection = oleConnection
            ' SE pasa el nombre de la transaccion al objeto oleCommand
            oleCommand.Transaction = oleTransaction
            oleCommand.CommandText = strQuery
            objReturn = oleCommand.ExecuteScalar()
            oleTransaction.Commit()
            Me.strMessage = "0"
            Return objReturn
        Catch e As Exception
            oleTransaction.Rollback()
            Me.strMessage = "-1"
            Return Nothing
        Finally
            oleConnection.Close()
        End Try
    End Function

    ''' <summary>
    ''' Recibe tabla y envía a storedProcedure, devuelve ([String])
    ''' </summary>
    ''' <returns>[String]</returns>
    ''' <remarks></remarks>
    Public Function ExecuteStoredProcedure(ByRef ds As DataSet, ByVal goType As String, ByVal strTaxonomy As String) As [String]

        Dim strCon As String = ConfigurationManager.ConnectionStrings("DHLConnectionString").ConnectionString.ToString()
        strCon = strCon.Substring(strCon.IndexOf(";") + 1, strCon.Length - strCon.IndexOf(";") - 1)

        Dim sqlCnn As New SqlConnection(strCon)

        Try
            Dim dt As New DataTable()
            ds.Tables(0).Columns.Add("GEOM")
            dt = ds.Tables(0)
            sqlCnn.Open()
            Dim cmd As New SqlCommand("insertHeaderTable", sqlCnn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim tvpParam As SqlParameter = cmd.Parameters.AddWithValue("@DATASET", dt)
            tvpParam.SqlDbType = SqlDbType.Structured

            Dim strParam As SqlParameter = cmd.Parameters.AddWithValue("@GO_TYPE", goType)
            strParam.SqlDbType = SqlDbType.VarChar

            Dim strTax As SqlParameter = cmd.Parameters.AddWithValue("@STR_TAXONOMY", strTaxonomy)
            strTax.SqlDbType = SqlDbType.VarChar

            cmd.ExecuteNonQuery()
            Return "1"
        Catch e As Exception
            Return "-1"
        Finally
            sqlCnn.Close()
        End Try
    End Function
#End Region
End Class
