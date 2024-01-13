Imports System.Data

Public Class User_Page
    Inherits System.Web.UI.Page



    Dim obj_User As New User_Class
    Dim path As String = ""

    Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
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
            Label1.Text = "يجب ادخال اسم المستخدم "
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

        If FileUpload1.HasFile = True Then
            Dim exe As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If exe = ".jpg" Or exe = ".png" Or exe = ".jpge" Or exe = ".JPG" Or exe = ".PNG" Or exe = ".JPGE" Then
                path = TextBox1.Text + FileUpload1.FileName
                FileUpload1.SaveAs(Server.MapPath("~/User_img/") + path)
            Else
                Label1.Visible = True
                Label1.ForeColor = Drawing.Color.Red
                Label1.Text = "لا يمكن تحميل هذا النوع من الملفات "
                Exit Sub

            End If
        End If

        Dim dt As DataTable = obj_User.ShowUser(TextBox1.Text)
        If dt.Rows.Count > 0 Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا اسم المستخدم  مسجل  مسبقا"
            Exit Sub
        End If

        Dim dt2 As DataTable = obj_User.ShowUser_employee_number(TextBox5.Text)
        If dt2.Rows.Count > 0 Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا الرقم الوظيفي  مسجل  مسبقا"
            Exit Sub
        End If

        If TextBox5.ReadOnly = False And TextBox5.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا يجب ادخال الرقم الوظيفي"
            Exit Sub
        End If

        If DropDownList1.Text = "موظف المحطة" Then
            Label2.Text = DropDownList2.SelectedValue
            Dim obj As New Station_Class
            Dim dt1 As DataTable = obj.ShowStation(DropDownList2.SelectedValue)
            Label3.Text = dt1.Rows(0).Item("city_name")
        Else
            Label3.Text = DropDownList3.SelectedValue

        End If

        obj_User.AddUser(TextBox1.Text, TextBox2.Text, DropDownList1.Text, path, TextBox5.Text, Label2.Text, Label3.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم إضافة بيانات المستخدم بنجاح"
        clear()

    End Sub



    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Label1.Visible = False   
        Dim dt As DataTable = obj_User.ShowUser(TextBox4.Text)
        If dt.Rows.Count > 0 Then
            TextBox1.Text = dt.Rows(0).Item("user_name")
            TextBox2.Text = dt.Rows(0).Item("user_password")
            TextBox3.Text = dt.Rows(0).Item("user_password")
            DropDownList1.Text = dt.Rows(0).Item("user_validity")
            Label_img.Text = dt.Rows(0).Item("user_img")
            TextBox5.Text = dt.Rows(0).Item("employee_number")
            TextBox1.ReadOnly = True
            LinkButton2.Visible = True
            LinkButton3.Visible = True
            Button1.Visible = False

            If DropDownList1.Text = "موظف شركة البريقة" Then
                TextBox5.ReadOnly = False
            End If


            If DropDownList1.Text = "موظف المحطة" Then
                DropDownList2.Enabled = True
                DropDownList3.Enabled = False
                DropDownList2.SelectedValue = dt.Rows(0).Item("station_number")
            Else
                DropDownList2.Enabled = False
                DropDownList3.Enabled = True
                DropDownList3.Text = dt.Rows(0).Item("city_name")
            End If
        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا هذا المستخدم غير موجود"
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

        If FileUpload1.HasFile = True Then
            Dim exe As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If exe = ".jpg" Or exe = ".png" Or exe = ".jpge" Or exe = ".jpeg" Or exe = ".JPG" Or exe = ".PNG" Or exe = ".JPGE" Or exe = ".JPEG" Then
                path = TextBox1.Text + FileUpload1.FileName
                FileUpload1.SaveAs(Server.MapPath("~/User_img/") + path)
            Else
                Label1.Visible = True
                Label1.ForeColor = Drawing.Color.Red
                Label1.Text = "لا يمكن تحميل هذا النوع من الملفات "
                Exit Sub

            End If
        Else
            path = Label_img.Text
        End If


        If TextBox5.ReadOnly = False And TextBox5.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا يجب ادخال الرقم الوظيفي"
            Exit Sub
        End If

        If DropDownList1.Text = "موظف المحطة" Then
            Label2.Text = DropDownList2.SelectedValue
        End If
        If DropDownList1.Text = "موظف المحطة" Then
            Label2.Text = DropDownList2.SelectedValue
            Dim obj As New Station_Class
            Dim dt1 As DataTable = obj.ShowStation(DropDownList2.SelectedValue)
            Label3.Text = dt1.Rows(0).Item("city_name")
        Else
            Label3.Text = DropDownList3.SelectedValue

        End If

        Dim dt2 As DataTable = obj_User.ShowUser_employee_number(TextBox5.Text)
        If dt2.Rows.Count > 0 Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا الرقم الوظيفي  مسجل  مسبقا"
            Exit Sub
        End If


        obj_User.EdieUser(TextBox1.Text, TextBox2.Text, DropDownList1.Text, path, TextBox5.Text, Label2.Text, Label3.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم تعديل بيانات المستخدم بنجاح"
        clear()
    End Sub

    Private Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        obj_User.DeleteUser(TextBox1.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Red
        Label1.Text = "تم حذف بيانات المستخدم بنجاح"
        clear()
    End Sub


    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If DropDownList1.Text = "موظف شركة البريقة" Then
            TextBox5.ReadOnly = False
        Else
            TextBox5.ReadOnly = True
        End If
        If DropDownList1.Text = "موظف المحطة" Then
            DropDownList2.Enabled = True
            DropDownList3.Enabled = False

        Else
            DropDownList2.Enabled = False
            DropDownList3.Enabled = True
        End If
    End Sub
End Class