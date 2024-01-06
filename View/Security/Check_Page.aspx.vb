Public Class Check_Page
    Inherits System.Web.UI.Page

   
    Dim obj_fuel As New Fuel_Shipment_Class
    Dim obj_reg As New Region_Class
    Dim obj_sta As New Station_Class
    Dim obj_trc As New Truck_Class
    Dim obj_dri As New Driver_Class


    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Dim dt As DataTable = obj_fuel.Show_Fuel_Security(TextBox4.Text)
        Label_region.Text = dt.Rows(0).Item("region_name")
        Label_cap.Text = dt.Rows(0).Item("quantity")
        HyperLink_truk.Text = dt.Rows(0).Item("plate_number")
        Label_station.Text = dt.Rows(0).Item("station_number")
        Dim dt1 As DataTable = obj_reg.ShowRegion(Label_region.Text)
        Label_city.Text = dt1.Rows(0).Item("city_name")
        Dim dt2 As DataTable = obj_sta.ShowStation(Label_station.Text)
        Label_station.Text = dt2.Rows(0).Item("station_name")
        Dim dt3 As DataTable = obj_trc.Show_Truck(HyperLink_truk.Text)
        HyperLink_driver.Text = dt3.Rows(0).Item("license_number")
        Dim dt4 As DataTable = obj_dri.Show_Driver(HyperLink_driver.Text)
        HyperLink_driver.Text = dt4.Rows(0).Item("driver_name")

    End Sub
End Class