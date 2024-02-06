Imports System.Data.SqlClient
Imports System.Data


Public Class City_Class


    Sub AddCity(ByVal city_name, ByVal minimum_defult_time, ByVal highest_defult_time)
        Dim cmd As New SqlCommand("insert into City (city_name,minimum_defult_time,highest_defult_time) values (@city_name,@minimum_defult_time,@highest_defult_time)", con)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        cmd.Parameters.AddWithValue("@minimum_defult_time", minimum_defult_time)
        cmd.Parameters.AddWithValue("@highest_defult_time", highest_defult_time)
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


    Sub Edite_City(ByVal city_name, ByVal minimum_defult_time, ByVal highest_defult_time)
        Dim cmd As New SqlCommand("update  City  set minimum_defult_time=@minimum_defult_time,highest_defult_time=@highest_defult_time where city_name=@city_name", con)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        cmd.Parameters.AddWithValue("@minimum_defult_time", minimum_defult_time)
        cmd.Parameters.AddWithValue("@highest_defult_time", highest_defult_time)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub


    Sub DeleteCity(ByVal city_name)
        Dim cmd As New SqlCommand("delete from City where city_name=@city_name", con)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Function returnminimum_defult_time(ByVal city_name)
        Dim cmd As New SqlCommand("select minimum_defult_time from City where city_name=@city_name", con)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

    Function returnmax_defult_time(ByVal city_name)
        Dim cmd As New SqlCommand("select highest_defult_time from City where city_name=@city_name", con)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

End Class
