Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Configuration
Public Class C_Consultorio
    Dim oDatabase As Database

    Public Sub New()
        oDatabase = DatabaseFactory.CreateDatabase("Conn")
    End Sub

#Region "combo"
    Public Function ComboTipo() As DataSet
        Try
            Return oDatabase.ExecuteDataSet("ComboTipo")
        Catch ex As System.Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Agregar"
    Public Function Agregar(ByVal Consulta As String, ByVal Dias As Integer, ByVal IdTipo As Integer, ByVal Edad As Integer, ByVal Email As String) As Double
        Return oDatabase.ExecuteScalar("ConsultaAgregar", Consulta, Dias, IdTipo, Edad, Email)
    End Function
#End Region

#Region "BuscarTodos"
    Public Function BuscarTodos() As DataSet
        Return oDatabase.ExecuteDataSet("ConsultaBuscarTodos")
    End Function
#End Region

#Region "BuscarPorID"
    Public Function BuscarPorId(ByVal IdConsulta As Integer) As DataSet
        Return oDatabase.ExecuteDataSet("ConsultaBuscarPorId", IdConsulta)
    End Function
#End Region

#Region "Modificar"
    Public Function Modificar(ByVal IdCaso As Integer, ByVal Consulta As String, ByVal Dias As Integer, ByVal IdTipo As Integer, ByVal Edad As Integer, ByVal Email As String) As Double
        Return oDatabase.ExecuteScalar("ConsutltaModificar", IdCaso, Consulta, Dias, IdTipo, Edad, Email)
    End Function
#End Region

#Region "Eliminar"
    Public Function Eliminar(ByVal IdCaso As Integer) As Double
        Return oDatabase.ExecuteScalar("ConsultaEliminar", IdCaso)
    End Function
#End Region

End Class
