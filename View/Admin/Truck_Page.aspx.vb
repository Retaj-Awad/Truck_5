Public Class Truck_Page
    Inherits System.Web.UI.Page

    Dim obj_truck As New Truck_Class

    Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        Button1.Visible = True
        LinkButton2.Visible = False
        LinkButton3.Visible = False
        TextBox1.ReadOnly = False
        GridView1.DataBind()
    End Sub


    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Visible = False
        If TextBox1.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال رقم اللوحة "
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال نوع الشاحنة "
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox3.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال سنة الصنع "
            TextBox3.Focus()
            Exit Sub
        End If

        If TextBox5.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال بلد الصنع "
            TextBox5.Focus()
            Exit Sub
        End If

        If TextBox6.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال لون الشاحنة "
            TextBox6.Focus()
            Exit Sub
        End If

        If TextBox7.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال سعة الشاحنة "
            TextBox7.Focus()
            Exit Sub
        End If

        If TextBox8.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال رقم المقطورة "
            TextBox8.Focus()
            Exit Sub
        End If

        Dim dt1 As DataTable = obj_truck.Show_Truck(TextBox1.Text)
        If dt1.Rows.Count > 0 Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا رقم اللوحة  مسجل  مسبقا"
            Exit Sub
        End If


        Dim no As DataTable = obj_truck.Show_trailer_number(TextBox8.Text)
        If no.Rows.Count > 0 Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا رقم المقطورة  مسجل  مسبقا"
            Exit Sub
        End If



        obj_truck.AddUTruck(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox6.Text, TextBox8.Text, TextBox7.Text, DropDownList1.SelectedValue, Session("admin"))
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم إضافة بيانات الشاحنة بنجاح"
        clear()
    End Sub


    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Label1.Visible = False
        Dim dt As DataTable = obj_truck.Show_Truck(TextBox4.Text)
        If dt.Rows.Count > 0 Then
            TextBox1.Text = dt.Rows(0).Item("plate_number")
            TextBox2.Text = dt.Rows(0).Item("Truck_type")
            TextBox3.Text = dt.Rows(0).Item("year_manufacture")
            TextBox5.Text = dt.Rows(0).Item("country_manufacture")
            TextBox6.Text = dt.Rows(0).Item("Color")
            TextBox7.Text = dt.Rows(0).Item("transport_capacity")
            TextBox8.Text = dt.Rows(0).Item("trailer_number")
            DropDownList1.Text = dt.Rows(0).Item("license_number")
            TextBox1.ReadOnly = True
            LinkButton2.Visible = True
            LinkButton3.Visible = True
            Button1.Visible = False
        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا رقم اللوحة غير موجود"
            clear()
        End If
    End Sub


    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Label1.Visible = False
        If TextBox2.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال نوع الشاحنة "
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox3.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال سنة الصنع "
            TextBox3.Focus()
            Exit Sub
        End If

        If TextBox5.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال بلد الصنع "
            TextBox5.Focus()
            Exit Sub
        End If

        If TextBox6.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال لون الشاحنة "
            TextBox6.Focus()
            Exit Sub
        End If

        If TextBox7.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال سعة الشاحنة "
            TextBox7.Focus()
            Exit Sub
        End If

        If TextBox8.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال رقم المقطورة "
            TextBox8.Focus()
            Exit Sub
        End If
        obj_truck.EdieTruck(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox6.Text, TextBox8.Text, TextBox7.Text, DropDownList1.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم تعديل بيانات الشاحنة بنجاح"
        clear()
    End Sub



    Private Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click

        Label1.Visible = False
        obj_truck.DeleteTruck(TextBox4.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم  حذف بيانات الشاحنة بنجاح"
        clear()
    End Sub
End Class