Imports System.Data.SqlClient

Module Module_con
    Public con As New SqlConnection(ConfigurationManager.ConnectionStrings("Track_Connection").ConnectionString)

End Module
