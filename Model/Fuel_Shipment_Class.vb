Imports System.Data.SqlClient
Imports System.Data


Public Class Fuel_Shipment_Class


    Function AddFuel(ByVal region_name, ByVal quantity, ByVal plate_number, ByVal station_number, ByVal user_name)
        Dim cmd As New SqlCommand("insert into Fuel_Shipment(region_name,quantity,plate_number,station_number, user_name) values (@region_name,@quantity,@plate_number,@station_number,@user_name)", con)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        cmd.Parameters.AddWithValue("@quantity", quantity)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        cmd.Parameters.AddWithValue("@station_number", station_number)
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

    Sub updateFuel(ByVal region_name, ByVal plate_number, ByVal station_number, ByVal user_name, ByVal shipment_code)
        Dim cmd As New SqlCommand("update  Fuel_Shipment set region_name=@region_name,plate_number=@plate_number,station_number=@station_number,user_name=@user_name where shipment_code=@shipment_code", con)
        cmd.Parameters.AddWithValue("@region_name", region_name)
        cmd.Parameters.AddWithValue("@plate_number", plate_number)
        cmd.Parameters.AddWithValue("@station_number", station_number)
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

    Function Show_Fuel_Security(ByVal shipment_code)
        Dim cmd As New SqlCommand("select region_name,quantity,plate_number,station_number from Fuel_Shipment  where shipment_code=@shipment_code", con)
        cmd.Parameters.AddWithValue("@shipment_code", shipment_code)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function


    Sub updatelaty_lony(ByVal shipment_code, ByVal laty, ByVal lony)
        Dim cmd As New SqlCommand("update  Fuel_Shipment set laty=@laty,lony=@lony where shipment_code=@shipment_code", con)
        cmd.Parameters.AddWithValue("@laty", laty)
        cmd.Parameters.AddWithValue("@lony", lony)
        cmd.Parameters.AddWithValue("@shipment_code", shipment_code)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub


    Function show_code(ByVal license_number)
        Dim cmd As New SqlCommand("SELECT Fuel_Shipment.shipment_code,Stations.city_name FROM Fuel_Shipment INNER JOIN Truck ON Fuel_Shipment.plate_number = Truck.plate_number INNER JOIN Driver ON Truck.license_number = Driver.license_number INNER JOIN Stations ON Fuel_Shipment.station_number = Stations.station_number INNER JOIN Record_fuel ON Fuel_Shipment.shipment_code = Record_fuel.shipment_code WHERE (Driver.license_number = @license_number) AND (Record_fuel.shipment_status = @shipment_status)", con)
        cmd.Parameters.AddWithValue("@shipment_status", "قيد التوصيل")
        cmd.Parameters.AddWithValue("@license_number", license_number)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

    Function report_by_code(ByVal shipment_code)
        Dim cmd1 As New SqlCommand("SELECT City.city_name,Region.region_name,station_name,driver_name,minimum_defult_time,highest_defult_time from Fuel_Shipment,City,Region,Truck,Driver,Stations where shipment_code=@shipment_code and Fuel_Shipment.region_name=Region.region_name and Region.city_name=City.city_name and Fuel_Shipment.plate_number=Truck.plate_number and Truck.license_number=Driver.license_number and Fuel_Shipment.station_number=Stations.station_number", con)
        cmd1.Parameters.AddWithValue("@shipment_code", shipment_code)
        Dim adp1 As New SqlDataAdapter(cmd1)
        Dim dt1 As New DataTable
        adp1.Fill(dt1)
        Dim dt_gridview As New DataTable
        If dt1.Rows.Count > 0 Then
            Dim minimum_defult_time As Double = dt1.Rows(0).Item("minimum_defult_time")
            Dim highest_defult_time As Double = dt1.Rows(0).Item("highest_defult_time")

            Dim cmd2 As New SqlCommand("SELECT record_time,record_data from Record_fuel where shipment_code=@shipment_code and shipment_status=@shipment_status", con)
            cmd2.Parameters.AddWithValue("@shipment_code", shipment_code)
            cmd2.Parameters.AddWithValue("@shipment_status", "قيد التوصيل")
            Dim adp2 As New SqlDataAdapter(cmd2)
            Dim dt2 As New DataTable
            adp2.Fill(dt2)
            Dim start_time As DateTime = dt2.Rows(0).Item("record_time")
            Dim startTime As String = start_time.ToString("hh:mm:ss tt")
            Dim start_date As Date = dt2.Rows(0).Item("record_data")


            Dim cmd As New SqlCommand("SELECT record_time,record_data from Record_fuel where shipment_code=@shipment_code and shipment_status=@shipment_status", con)
            cmd.Parameters.AddWithValue("@shipment_code", shipment_code)
            cmd.Parameters.AddWithValue("@shipment_status", "تم الاستلام")
            Dim adp As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            adp.Fill(dt)
            Dim end_time As DateTime = dt.Rows(0).Item("record_time")
            Dim endTime As String = end_time.ToString("hh:mm:ss tt")
            Dim end_date As Date = dt.Rows(0).Item("record_data")

            Dim duration As Double = DateDiff(DateInterval.Hour, start_time, end_time)
            Dim days As Integer = 0
            days = DateDiff(DateInterval.Day, start_date, end_date)

            Dim eval As New Label
            If days = 0 Then
                If duration < minimum_defult_time Then
                    eval.Text = "توصيل سريع"
                ElseIf duration > highest_defult_time Then
                    eval.Text = "توصيل بطيئ"
                Else
                    eval.Text = "توصيل طبيعي"
                End If
            Else
                duration = Nothing
                eval.Text = "توصيل بطيئ"
            End If


            Dim c1 = New DataColumn("المدينة", GetType(String))
            Dim c2 = New DataColumn("المنطقة", GetType(String))
            Dim c3 = New DataColumn("المحطة", GetType(String))
            Dim c4 = New DataColumn("السائق", GetType(String))
            Dim c5 = New DataColumn("اقل وقت للوصول", GetType(Double))
            Dim c6 = New DataColumn("اكثر وقت للوصول", GetType(Double))
            Dim c7 = New DataColumn("الانطلاقة", GetType(String))
            Dim c8 = New DataColumn("الوصول", GetType(String))
            Dim c9 = New DataColumn("مدة الرحلة", GetType(Double))
            Dim c10 = New DataColumn("عدد الايام", GetType(Long))
            Dim c11 = New DataColumn("التقييم", GetType(String))
            dt_gridview.Columns.Add(c1)
            dt_gridview.Columns.Add(c2)
            dt_gridview.Columns.Add(c3)
            dt_gridview.Columns.Add(c4)
            dt_gridview.Columns.Add(c5)
            dt_gridview.Columns.Add(c6)
            dt_gridview.Columns.Add(c7)
            dt_gridview.Columns.Add(c8)
            dt_gridview.Columns.Add(c9)
            dt_gridview.Columns.Add(c10)
            dt_gridview.Columns.Add(c11)
            dt_gridview.Rows.Add(dt1.Rows(0).Item(0), dt1.Rows(0).Item(1), dt1.Rows(0).Item(2), dt1.Rows(0).Item(3), dt1.Rows(0).Item(4), dt1.Rows(0).Item(5), startTime, endTime, duration, days, eval.Text)
        End If

        Return dt_gridview
    End Function

    Function report_by_driver(ByVal license_number)
        Dim cmd1 As New SqlCommand("SELECT City.city_name,Region.region_name,station_name,driver_name,minimum_defult_time,highest_defult_time,Fuel_Shipment.shipment_code from Fuel_Shipment,City,Region,Truck,Driver,Stations where Driver.license_number=@license_number and Fuel_Shipment.region_name=Region.region_name and Region.city_name=City.city_name and Fuel_Shipment.plate_number=Truck.plate_number and Truck.license_number=Driver.license_number and Fuel_Shipment.station_number=Stations.station_number", con)
        cmd1.Parameters.AddWithValue("@license_number", license_number)
        Dim adp1 As New SqlDataAdapter(cmd1)
        Dim dt1 As New DataTable
        adp1.Fill(dt1)

        Dim dt_gridview As New DataTable
        Dim c1 = New DataColumn("المدينة", GetType(String))
        Dim c2 = New DataColumn("المنطقة", GetType(String))
        Dim c3 = New DataColumn("المحطة", GetType(String))
        Dim c4 = New DataColumn("السائق", GetType(String))
        Dim c5 = New DataColumn("اقل وقت للوصول", GetType(Double))
        Dim c6 = New DataColumn("اكثر وقت للوصول", GetType(Double))
        Dim c7 = New DataColumn("الانطلاقة", GetType(String))
        Dim c8 = New DataColumn("الوصول", GetType(String))
        Dim c9 = New DataColumn("مدة الرحلة", GetType(Double))
        Dim c10 = New DataColumn("عدد الايام", GetType(Long))
        Dim c11 = New DataColumn("التقييم", GetType(String))
        dt_gridview.Columns.Add(c1)
        dt_gridview.Columns.Add(c2)
        dt_gridview.Columns.Add(c3)
        dt_gridview.Columns.Add(c4)
        dt_gridview.Columns.Add(c5)
        dt_gridview.Columns.Add(c6)
        dt_gridview.Columns.Add(c7)
        dt_gridview.Columns.Add(c8)
        dt_gridview.Columns.Add(c9)
        dt_gridview.Columns.Add(c10)
        dt_gridview.Columns.Add(c11)

        Dim c As Integer = 0
        While c < dt1.Rows.Count

            Dim minimum_defult_time As Double = dt1.Rows(c).Item("minimum_defult_time")
            Dim highest_defult_time As Double = dt1.Rows(c).Item("highest_defult_time")

            Dim cmd2 As New SqlCommand("SELECT record_time,record_data from Record_fuel where shipment_code=@shipment_code and shipment_status=@shipment_status", con)
            cmd2.Parameters.AddWithValue("@shipment_code", dt1.Rows(c).Item("shipment_code"))
            cmd2.Parameters.AddWithValue("@shipment_status", "قيد التوصيل")
            Dim adp2 As New SqlDataAdapter(cmd2)
            Dim dt2 As New DataTable
            adp2.Fill(dt2)
            Dim start_time As DateTime = dt2.Rows(0).Item("record_time")
            Dim startTime As String = start_time.ToString("hh:mm:ss tt")
            Dim start_date As Date = dt2.Rows(0).Item("record_data")


            Dim cmd As New SqlCommand("SELECT record_time,record_data from Record_fuel where shipment_code=@shipment_code and shipment_status=@shipment_status", con)
            cmd.Parameters.AddWithValue("@shipment_code", dt1.Rows(c).Item("shipment_code"))
            cmd.Parameters.AddWithValue("@shipment_status", "تم الاستلام")
            Dim adp As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            adp.Fill(dt)
            Dim end_time As DateTime = dt.Rows(0).Item("record_time")
            Dim endTime As String = end_time.ToString("hh:mm:ss tt")
            Dim end_date As Date = dt.Rows(0).Item("record_data")

            Dim duration As Double = DateDiff(DateInterval.Hour, start_time, end_time)
            Dim days As Integer = 0
            days = DateDiff(DateInterval.Day, start_date, end_date)

            Dim eval As New Label
            If days = 0 Then
                If duration < minimum_defult_time Then
                    eval.Text = "توصيل سريع"
                ElseIf duration > highest_defult_time Then
                    eval.Text = "توصيل بطيئ"
                Else
                    eval.Text = "توصيل طبيعي"
                End If
            Else
                duration = Nothing
                eval.Text = "توصيل بطيئ"
            End If



            dt_gridview.Rows.Add(dt1.Rows(c).Item(0), dt1.Rows(c).Item(1), dt1.Rows(c).Item(2), dt1.Rows(c).Item(3), dt1.Rows(c).Item(4), dt1.Rows(c).Item(5), startTime, endTime, duration, days, eval.Text)
            c = c + 1
        End While
        Return dt_gridview
    End Function
End Class
