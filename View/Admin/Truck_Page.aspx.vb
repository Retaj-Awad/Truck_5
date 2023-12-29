Public Class Truck_Page
    Inherits System.Web.UI.Page

    Dim obj_truck As New Truck_Class



    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        obj_truck.AddUTruck(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, DropDownList1.SelectedValue, Session("admin"))
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم إضافة بيانات الشاحنة بنجاح"
        GridView1.DataBind()
    End Sub
End Class