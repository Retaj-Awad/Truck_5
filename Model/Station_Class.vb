Imports System.Data.SqlClient
Imports System.Data

Public Class Station_Class


    Sub AddStation(ByVal station_name, ByVal region_name, ByVal city_name, ByVal registration_date, ByVal account_name, ByVal add_by)
        Dim cmd As New SqlCommand("insert into Stations (station_name,region_name,city_name,registration_date, account_name, add_by) values (@station_name,@region_name,@city_name,@registration_date,@account_name,@add_by)", con)
        cmd.Parameters.AddWithValue("@station_name", station_name)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        cmd.Parameters.AddWithValue("@registration_date", registration_date)
        cmd.Parameters.AddWithValue("@account_name", account_name)
        cmd.Parameters.AddWithValue("@add_by", add_by)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Function ShowStation(ByVal station_number)
        Dim cmd As New SqlCommand("select * from  Stations where station_number=@station_number", con)
        cmd.Parameters.AddWithValue("@station_number", station_number)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

    Sub UpdateStation(ByVal station_number, ByVal region_name, ByVal city_name, ByVal add_by)
        Dim cmd As New SqlCommand("update  Stations set region_name=@region_name,city_name=@city_name, add_by=@add_by where station_number=@station_number", con)
        cmd.Parameters.AddWithValue("@station_number", station_number)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        cmd.Parameters.AddWithValue("@add_by", add_by)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Sub DeleteStation(ByVal station_number)
        Dim cmd As New SqlCommand("delete from  Stations where station_number=@station_number", con)
        cmd.Parameters.AddWithValue("@station_number", station_number)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class
