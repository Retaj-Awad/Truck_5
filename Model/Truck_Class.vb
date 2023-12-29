Imports System.Data.SqlClient
Imports System.Data

Public Class Truck_Class
    Sub AddUTruck(ByVal plate_number, ByVal Truck_type, ByVal year_manufacture, ByVal country_manufacture, ByVal Color, ByVal transport_capacity, ByVal license_number, ByVal user_name)
        Dim cmd As New SqlCommand("insert into Truck (plate_number,Truck_type, year_manufacture,country_manufacture, Color,transport_capacity,license_number,user_name) values (@plate_number,@Truck_type,@year_manufacture,@country_manufacture,@Color,@transport_capacity,@license_number,@user_name)", con)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        cmd.Parameters.AddWithValue("@Truck_type", Truck_type)
        cmd.Parameters.AddWithValue("@year_manufacture", year_manufacture)
        cmd.Parameters.AddWithValue("@country_manufacture", country_manufacture)
        cmd.Parameters.AddWithValue("@Color", Color)
        cmd.Parameters.AddWithValue("@transport_capacity", transport_capacity)
        cmd.Parameters.AddWithValue("@license_number", license_number)
        cmd.Parameters.AddWithValue("@user_name", user_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Function returncapacity(ByVal plate_number)
        Dim cmd As New SqlCommand("select transport_capacity from  Truck  where plate_number=@plate_number", con)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function
End Class
