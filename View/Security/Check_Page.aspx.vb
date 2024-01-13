Public Class Check_Page
    Inherits System.Web.UI.Page

   
    Dim obj_fuel As New Fuel_Shipment_Class
    Dim obj_reg As New Region_Class
    Dim obj_sta As New Station_Class
    Dim obj_trc As New Truck_Class
    Dim obj_dri As New Driver_Class
    Dim obj_rec As New Record_Class


    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Label1.Visible = False
        Label2.Visible = False
        Dim dt As DataTable = obj_fuel.Show_Fuel_Security(TextBox4.Text)
        If dt.Rows.Count > 0 Then
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
            HyperLink_driver.NavigateUrl = "~/View/Security/Driver_Page.aspx?driver=" + dt4.Rows(0).Item("driver_name")
            HyperLink_truk.NavigateUrl = "~/View/Security/Truck_Page.aspx?truck=" + dt.Rows(0).Item("plate_number")
            LinkButton1.Visible = True
        Else
            Label_region.Text = ""
            Label_cap.Text = ""
            HyperLink_truk.Text = ""
            Label_station.Text = ""
            Label_city.Text = ""
            Label_station.Text = ""
            HyperLink_driver.Text = ""
            HyperLink_driver.Text = ""
            HyperLink_driver.NavigateUrl = ""
            HyperLink_truk.NavigateUrl = ""
            LinkButton1.Visible = False
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا كود الشحنة غير موجود"
            TextBox4.Focus()
        End If

    End Sub

   
    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Label1.Visible = False
        Label2.Visible = False
        Dim dt As DataTable = obj_rec.CheckRecord(TextBox4.Text, Session("security"))
        If dt.Rows.Count > 0 Then
            obj_rec.UpdateRecord(TextBox4.Text, Date.Today, Date.Now.TimeOfDay, DropDownList1.Text, TextBox1.Text, Session("security"))
        Else

            obj_rec.AddRecord(TextBox4.Text, Date.Today, Date.Now.TimeOfDay, DropDownList1.Text, TextBox1.Text, Session("security"))
        End If
        Label2.Visible = True
        Label2.ForeColor = Drawing.Color.Green
        Label2.Text = "تم ارسال بيانات الشحنة بنجاح"
        GridView1.DataBind()

    End Sub
End Class