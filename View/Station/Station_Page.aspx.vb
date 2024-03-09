Public Class Station_Page1
    Inherits System.Web.UI.Page

    Dim obj_fual As New Fuel_Shipment_Class
    Dim obj_record As New Record_Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("employee_station")) = True Then
            Response.Redirect("~/View/Home/Home_Page.aspx")
        End If
    End Sub



    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session.RemoveAll()
        Response.Redirect("~/View/Home/Home_Page.aspx")
    End Sub


    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As DataTable = obj_fual.showFuel(TextBox1.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("station_number") = Session("station_number") Then
                Response.Redirect("https://www.google.com/maps/search/" + dt.Rows(0).Item("laty") + " ," + dt.Rows(0).Item("lony"))
            Else
                Label1.Visible = True
                Label1.ForeColor = Drawing.Color.Red
                Label1.Text = "عفوا هذه الشحنة لا تتبع المحطة الخاصة بك"
                TextBox1.Focus()
            End If
        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يوجد خطا في كود الشحنة"
            TextBox1.Focus()
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dt As DataTable = obj_fual.showFuel(TextBox1.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("station_number") = Session("station_number") Then
                Button1.Visible = True
                GridView1.Visible = True
                Button2.Visible = False
                LinkButton2.Visible = True
            Else
                Button1.Visible = False
                GridView1.Visible = False
                Button2.Visible = True
                Label1.Visible = True
                Label1.ForeColor = Drawing.Color.Red
                Label1.Text = "عفوا هذه الشحنة لا تتبع المحطة الخاصة بك"
                TextBox1.Focus()
            End If
        Else
            Button1.Visible = False
            GridView1.Visible = False
            Button2.Visible = True
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يوجد خطا في كود الشحنة"
            TextBox1.Focus()
        End If


    End Sub

    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Label1.Visible = False
        Label2.Visible = False
        Dim dt As DataTable = obj_record.CheckRecord(TextBox1.Text, Session("employee_station"))
        If dt.Rows.Count > 0 Then
            obj_record.UpdateRecord(TextBox1.Text, Date.Today, Date.Now.TimeOfDay, DropDownList1.Text, TextBox2.Text, Session("employee_station"))
        Else

            obj_record.AddRecord(TextBox1.Text, Date.Today, Date.Now.TimeOfDay, DropDownList1.Text, TextBox2.Text, Session("employee_station"))
        End If
        Label2.Visible = True
        Label2.ForeColor = Drawing.Color.Green
        Label2.Text = "تم ارسال بيانات الشحنة بنجاح"


    End Sub
End Class