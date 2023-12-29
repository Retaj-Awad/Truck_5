Imports System.Data.SqlClient
Imports System.Data


Public Class Region_Class



    Sub AddRegion(ByVal region_name, ByVal city_name)
        Dim cmd As New SqlCommand("insert into Region (region_name,city_name) values (@region_name,@city_name)", con)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Function ShowRegion(ByVal region_name)
        Dim cmd As New SqlCommand("select * from Region where region_name=@region_name", con)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

    Sub EdieRegion(ByVal region_name, ByVal city_name)
        Dim cmd As New SqlCommand("update  Region set city_name=@city_name  where region_name=@region_name ", con)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Sub DeleteRegion(ByVal region_name)
        Dim cmd As New SqlCommand("delete from Region where region_name=@region_name ", con)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Sub DeleteRegion_byCity(ByVal city_name)
        Dim cmd As New SqlCommand("delete from Region where city_name=@city_name ", con)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class
