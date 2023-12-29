Public Class Station_Page
    Inherits System.Web.UI.Page


    Dim obj_user As New User_Class
    Dim obj_station As New Station_Class

    Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Button1.Visible = True
        LinkButton2.Visible = False
        LinkButton3.Visible = False
        TextBox1.ReadOnly = False
        GridView1.DataBind()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال اسم المحطة "
            TextBox1.Focus()
            Exit Sub
        End If


        If TextBox2.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال كلمة المرور  "
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox2.Text <> TextBox3.Text Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "كلمة المرور غير متطابقة  "
            TextBox3.Focus()
            Exit Sub
        End If


        If DropDownList1.SelectedValue = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال المدينة   "
            DropDownList1.Focus()
            Exit Sub
        End If


        If DropDownList2.SelectedValue = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال المنطقة   "
            DropDownList2.Focus()
            Exit Sub
        End If

        Dim dt As DataTable = obj_station.ShowStation(TextBox4.Text)
        If dt.Rows.Count > 0 Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا اسم المستخدم  مسجل  مسبقا"
            Exit Sub

        End If
        obj_user.AddUser(TextBox1.Text, TextBox2.Text, "موظف المحطة ", " ")
        obj_station.AddStation(TextBox1.Text, DropDownList2.SelectedValue, DropDownList1.SelectedValue, Date.Today, TextBox1.Text, Session("admin"))
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم إضافة بيانات المحطة بنجاح"
        clear()
    End Sub

    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Label1.Visible = False
        Dim dt As DataTable = obj_station.ShowStation(TextBox4.Text)
        If dt.Rows.Count > 0 Then
            TextBox1.Text = dt.Rows(0).Item("station_name")
            DropDownList1.Text = dt.Rows(0).Item("city_name")
            DropDownList2.Text = dt.Rows(0).Item("region_name")

            Dim dt2 As DataTable = obj_user.ShowUser(TextBox1.Text)
            TextBox2.Text = dt2.Rows(0).Item("user_password")
            TextBox3.Text = dt2.Rows(0).Item("user_password")
            TextBox1.ReadOnly = True
            LinkButton2.Visible = True
            LinkButton3.Visible = True
            Button1.Visible = False



        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = " عفوا رقم المحطة غير موجود"
            LinkButton2.Visible = False
            LinkButton3.Visible = False
            Button1.Visible = True
            clear()


        End If
    End Sub

    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
       
        If TextBox2.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال كلمة المرور  "
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox2.Text <> TextBox3.Text Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "كلمة المرور غير متطابقة  "
            TextBox3.Focus()
            Exit Sub
        End If

        

        obj_user.EdieUserStation(TextBox1.Text, TextBox2.Text)
        obj_station.UpdateStation(TextBox4.Text, DropDownList2.SelectedValue, DropDownList1.SelectedValue, Session("admin"))

        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم تعديل بيانات المحطة بنجاح"
        clear()
    End Sub

    Private Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        obj_user.DeleteUser(TextBox1.Text)
        obj_station.DeleteStation(TextBox4.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Red
        Label1.Text = "تم حذف بيانات المحطة بنجاح"
        clear()
    End Sub
End Class