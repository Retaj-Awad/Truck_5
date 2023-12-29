Public Class City_Page
    Inherits System.Web.UI.Page


    Dim obj_city As New City_Class
    Dim obj_r As New Region_Class

    Sub clear()
        TextBox1.Text = ""
        TextBox4.Text = ""
        Button1.Visible = True
        LinkButton3.Visible = False
        GridView1.DataBind()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال اسم المدينة "
            TextBox1.Focus()
            Exit Sub
        End If


        obj_city.AddCity(TextBox1.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم إضافة المدينة  بنجاح"
        clear()
    End Sub


    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Label1.Visible = False
        Dim dt As DataTable = obj_city.ShowCity(TextBox4.Text)
        If dt.Rows.Count > 0 Then
            TextBox1.Text = dt.Rows(0).Item("city_name")
            LinkButton3.Visible = True
            Button1.Visible = False
        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = " عفوا هذه المدينة غير موجودة"
            clear()
        End If
    End Sub


    Private Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        obj_r.DeleteRegion_byCity(TextBox1.Text)
        obj_city.DeleteCity(TextBox1.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Red
        Label1.Text = "تم حذف المدينة بنجاح"
        clear()
    End Sub
End Class