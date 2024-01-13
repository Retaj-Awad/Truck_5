Public Class Driver_Page
    Inherits System.Web.UI.Page

 
    Dim obj_driver As New Driver_Class
    Dim path As String

    Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
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
            Label1.Text = "يجب ادخال رفم الرخصة "
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال اسم السائق "
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox3.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال رقم الهاتف "
            TextBox3.Focus()
            Exit Sub
        End If

        If TextBox5.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال العنوان "
            TextBox5.Focus()
            Exit Sub
        End If

        If TextBox6.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب تاريخ الميلاد "
            TextBox6.Focus()
            Exit Sub
        End If


        If FileUpload1.HasFile = True Then
            Dim exe As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If exe = ".jpg" Or exe = ".png" Or exe = ".jpge" Or exe = ".JPG" Or exe = ".PNG" Or exe = ".JPGE" Then
                path = TextBox1.Text + FileUpload1.FileName
                FileUpload1.SaveAs(Server.MapPath("~/Driver_img/") + path)
            Else
                Label1.Visible = True
                Label1.ForeColor = Drawing.Color.Red
                Label1.Text = "لا يمكن تحميل هذا النوع من الملفات "
                Exit Sub
            End If

        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ارفاق صورة شخصية لسائق"
            Exit Sub

        End If

        Dim dt As DataTable = obj_driver.Show_Driver(TextBox1.Text)
        If dt.Rows.Count > 0 Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا رقم الرخصة  مسجل  مسبقا"
            Exit Sub
        End If

        obj_driver.AddDriver(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox6.Text, path, Session("admin"))
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم إضافة  بيانات السائق بنجاح"
        clear()
    End Sub


    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Label1.Visible = False
        Dim dt As DataTable = obj_driver.Show_Driver(TextBox4.Text)
        If dt.Rows.Count > 0 Then
            TextBox1.Text = dt.Rows(0).Item("license_number")
            TextBox2.Text = dt.Rows(0).Item("driver_name")
            TextBox3.Text = dt.Rows(0).Item("phone_number")
            TextBox5.Text = dt.Rows(0).Item("home_adress")
            TextBox6.Text = dt.Rows(0).Item("Birth")
            Label_img.Text = dt.Rows(0).Item("profile_img")
            TextBox1.ReadOnly = True
            LinkButton2.Visible = True
            LinkButton3.Visible = True
            Button1.Visible = False
        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "عفوا رقم الرخصة غير موجود "
            clear()
        End If
    End Sub


    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Label1.Visible = False
        If TextBox1.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال رفم الرخصة "
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال اسم السائق "
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox3.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال رقم الهاتف "
            TextBox3.Focus()
            Exit Sub
        End If

        If TextBox5.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال العنوان "
            TextBox5.Focus()
            Exit Sub
        End If

        If TextBox6.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب تاريخ الميلاد "
            TextBox6.Focus()
            Exit Sub
        End If


        If FileUpload1.HasFile = True Then
            Dim exe As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If exe = ".jpg" Or exe = ".png" Or exe = ".jpge" Or exe = ".JPG" Or exe = ".PNG" Or exe = ".JPGE" Or exe = ".jpeg" Or exe = ".JPEG" Then
                path = TextBox1.Text + FileUpload1.FileName
                FileUpload1.SaveAs(Server.MapPath("~/Driver_img/") + path)
            Else
                Label1.Visible = True
                Label1.ForeColor = Drawing.Color.Red
                Label1.Text = "لا يمكن تحميل هذا النوع من الملفات "
                Exit Sub
            End If

        Else
            path = Label_img.Text
        End If


        obj_driver.Edie_Driver(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox6.Text, path)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم تعديل بيانات السائق بنجاح"
        clear()
    End Sub


    Private Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Label1.Visible = False
        obj_driver.Delete_Driver(TextBox4.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم حذف بيانات السائق بنجاح"
        clear()
    End Sub
End Class