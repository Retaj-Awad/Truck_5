Public Class Driver_Page
    Inherits System.Web.UI.Page

 
    Dim obj_driver As New Driver_Class
    Dim path As String

     

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Visible = False
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


        obj_driver.AddDriver(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox6.Text, path, Session("admin"))
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم إضافة  بيانات السائق بنجاح"
        GridView1.DataBind()
    End Sub
End Class