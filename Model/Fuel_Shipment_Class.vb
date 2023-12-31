Imports System.Data.SqlClient
Imports System.Data


Public Class Fuel_Shipment_Class


    Function AddFuel(ByVal region_name, ByVal quantity, ByVal plate_number, ByVal station_numbre, ByVal shipment_status, ByVal user_name)
        Dim cmd As New SqlCommand("insert into Fuel_Shipment(region_name,quantity,plate_number,station_numbre, shipment_status, user_name) values (@region_name,@quantity,@plate_number,@station_numbre, @shipment_status,@user_name)", con)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        cmd.Parameters.AddWithValue("@quantity", quantity)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        cmd.Parameters.AddWithValue("@station_numbre", station_numbre)
        cmd.Parameters.AddWithValue("@shipment_status", shipment_status)
        cmd.Parameters.AddWithValue("@user_name", user_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        Dim cmd1 As New SqlCommand("select MAX(shipment_code) from Fuel_Shipment", con)
        con.Open()
        Dim max As Integer = cmd1.ExecuteScalar()
        con.Close()
        Return max

    End Function

    Function showFuel(ByVal shipment_code)
        Dim cmd As New SqlCommand("select * from Fuel_Shipment where shipment_code= @shipment_code", con)
        cmd.Parameters.AddWithValue("@shipment_code", shipment_code)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

    Sub updateFuel(ByVal region_name, ByVal plate_number, ByVal station_numbre, ByVal user_name, ByVal shipment_code)
        Dim cmd As New SqlCommand("update  Fuel_Shipment set region_name=@region_name,plate_number=@plate_number,station_numbre=@station_numbre,user_name=@user_name where shipment_code=@shipment_code", con)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        cmd.Parameters.AddWithValue("@station_numbre", station_numbre)
        cmd.Parameters.AddWithValue("@user_name", user_name)
        cmd.Parameters.AddWithValue("@shipment_code", shipment_code)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Sub StopFuel(ByVal reason, ByVal shipment_code)
        Dim cmd As New SqlCommand("update  Fuel_Shipment set shipment_status=@shipment_status,reason=@reason where shipment_code=@shipment_code", con)
        cmd.Parameters.AddWithValue("@shipment_status", "تم ايقاف الشحنة")
        cmd.Parameters.AddWithValue("@reason", reason)
        cmd.Parameters.AddWithValue("@shipment_code", shipment_code)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Function Check_StopFuel(ByVal shipment_code)
        Dim cmd As New SqlCommand("select * from Fuel_Shipment  where shipment_code=@shipment_code and shipment_status=@shipment_status", con)
        cmd.Parameters.AddWithValue("@shipment_status", "تم ايقاف الشحنة")
        cmd.Parameters.AddWithValue("@shipment_code", shipment_code)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function
End Class
