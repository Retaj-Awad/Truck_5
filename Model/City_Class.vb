Imports System.Data.SqlClient
Imports System.Data


Public Class City_Class


    Sub AddCity(ByVal city_name)
        Dim cmd As New SqlCommand("insert into City (city_name) values (@city_name)", con)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Function ShowCity(ByVal city_name)
        Dim cmd As New SqlCommand("select * from City where city_name=@city_name", con)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

    Sub DeleteCity(ByVal city_name)
        Dim cmd As New SqlCommand("delete from City where city_name=@city_name ", con)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub


End Class
