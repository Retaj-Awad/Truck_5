Public Class Driver_Page2
    Inherits System.Web.UI.Page

    Dim obj_fuel As New Fuel_Shipment_Class
    Dim obj_city As New City_Class

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GridView1.Rows.Count > 0 Then
            Button1.Visible = False
            Button2.Visible = True
        Else
            Button1.Visible = True
            Button2.Visible = False
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click



        'جلب كود الشحنة التي تتبع السائق
        Dim dt As DataTable = obj_fuel.show_code(TextBox1.Text)
        'جلب موقع الجهاز على الخريطةو تحديت موقع الشحنة على الخريطة
        obj_fuel.updatelaty_lony(dt.Rows(0).Item("shipment_code"), send_laty.Value, send_lony.Value)
        'جلب اقل توقيت متوقع للوصول
        Dim dt_c As DataTable = obj_city.returnminimum_defult_time(dt.Rows(0).Item("city_name"))
        Dim dt_cm As DataTable = obj_city.returnmax_defult_time(dt.Rows(0).Item("city_name"))
        Dim minimum_defult_time As String = dt_c.Rows(0).Item("minimum_defult_time").ToString
        Dim highest_defult_time As String = dt_cm.Rows(0).Item("highest_defult_time").ToString
        Session("count") = 0
        Response.Redirect("~/View/Home/GPS_Page.aspx?defult_time=" + minimum_defult_time + "&max=" + dt_cm.Rows(0).Item("highest_defult_time") + "&code=" + dt.Rows(0).Item("shipment_code").ToString + "&city=" + dt.Rows(0).Item("city_name"))

    End Sub
End Class