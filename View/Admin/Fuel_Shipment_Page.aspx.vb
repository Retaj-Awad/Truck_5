Public Class Fuel_Shipment_Page
    Inherits System.Web.UI.Page

    Dim obj_fuel As New Fuel_Shipment_Class
    Dim obj_truck As New Truck_Class

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As DataTable = obj_truck.returncapacity(DropDownList4.SelectedValue)
        Dim code_id As Integer = obj_fuel.AddFuel(DropDownList2.SelectedValue, dt.Rows(0).Item("transport_capacity"), DropDownList4.SelectedValue, DropDownList3.SelectedValue, "قيد التوصيل", Session("admin"))
        GridView1.DataBind()
        Response.Redirect("~/View/Admin/Print_Code.aspx?code=" + code_id.ToString)

    End Sub

    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim dt As DataTable = obj_fuel.showFuel(TextBox4.Text)
        If dt.Rows.Count > 0 Then
            Button1.Visible = False
            LinkButton2.Visible = True
            LinkButton3.Visible = True
            DropDownList2.SelectedValue = dt.Rows(0).Item("region_name")
            DropDownList3.SelectedValue = dt.Rows(0).Item("station_numbre")
            DropDownList4.SelectedValue = dt.Rows(0).Item("plate_number")

        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا رقم الشحنة غير موجود"
            TextBox4.Focus()
            Button1.Visible = True
            LinkButton2.Visible = False
            LinkButton3.Visible = False

        End If
    End Sub

    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        obj_fuel.updateFuel(DropDownList2.SelectedValue, DropDownList4.SelectedValue, DropDownList3.SelectedValue, Session("admin"), TextBox4.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم تعديل بيانات الشحنة بنجاح"
        Button1.Visible = True
        LinkButton2.Visible = False
        LinkButton3.Visible = False
        GridView1.DataBind()

    End Sub
End Class