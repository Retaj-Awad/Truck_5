Imports System.Data.SqlClient
Imports System.Data

Public Class Truck_Class
    Sub AddUTruck(ByVal plate_number, ByVal Truck_type, ByVal year_manufacture, ByVal country_manufacture, ByVal Color, ByVal trailer_number, ByVal transport_capacity, ByVal license_number, ByVal user_name)
        Dim cmd As New SqlCommand("insert into Truck (plate_number,Truck_type, year_manufacture,country_manufacture, Color,trailer_number,transport_capacity,license_number,user_name) values (@plate_number,@Truck_type,@year_manufacture,@country_manufacture,@Color,@trailer_number,@transport_capacity,@license_number,@user_name)", con)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        cmd.Parameters.AddWithValue("@Truck_type", Truck_type)
        cmd.Parameters.AddWithValue("@year_manufacture", year_manufacture)
        cmd.Parameters.AddWithValue("@country_manufacture", country_manufacture)
        cmd.Parameters.AddWithValue("@Color", Color)
        cmd.Parameters.AddWithValue("@trailer_number", trailer_number)
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

    Function Show_Truck(ByVal plate_number)
        Dim cmd As New SqlCommand("select * from  Truck  where plate_number=@plate_number", con)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

    Function Show_trailer_number(ByVal trailer_number)
        Dim cmd As New SqlCommand("select * from  Truck  where trailer_number=@trailer_number", con)
        cmd.Parameters.AddWithValue("@trailer_number", trailer_number)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function


    Sub EdieTruck(ByVal plate_number, ByVal Truck_type, ByVal year_manufacture, ByVal country_manufacture, ByVal Color, ByVal trailer_number, ByVal transport_capacity, ByVal license_number)
        Dim cmd As New SqlCommand("update  Truck set Truck_type=@Truck_type,year_manufacture=@year_manufacture,country_manufacture =@country_manufacture,trailer_number=@trailer_number,transport_capacity=@transport_capacity,license_number=@license_number  where plate_number=@plate_number ", con)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        cmd.Parameters.AddWithValue("@Truck_type", Truck_type)
        cmd.Parameters.AddWithValue("@year_manufacture", year_manufacture)
        cmd.Parameters.AddWithValue("@country_manufacture", country_manufacture)
        cmd.Parameters.AddWithValue("@Color", Color)
        cmd.Parameters.AddWithValue("@trailer_number", trailer_number)
        cmd.Parameters.AddWithValue("@transport_capacity", transport_capacity)
        cmd.Parameters.AddWithValue("@license_number", license_number)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Sub DeleteTruck(ByVal plate_number)
        Dim cmd As New SqlCommand("delete from Truck where plate_number=@plate_number ", con)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class
