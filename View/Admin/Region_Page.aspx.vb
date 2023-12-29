Public Class Region_Page
    Inherits System.Web.UI.Page

    Dim obj_region As New Region_Class

    Sub clear()
        TextBox1.Text = ""
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
            Label1.Text = "يجب ادخال اسم المنطقة "
            TextBox1.Focus()
            Exit Sub
        End If

        obj_region.AddRegion(TextBox1.Text, DropDownList1.SelectedValue)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم إضافة المنطقة بنجاح"
        clear()
    End Sub



    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Label1.Visible = False
        Dim dt As DataTable = obj_region.ShowRegion(TextBox4.Text)
        If dt.Rows.Count > 0 Then
            TextBox1.Text = dt.Rows(0).Item("region_name")
            DropDownList1.SelectedValue = dt.Rows(0).Item("city_name")
            TextBox1.ReadOnly = True
            LinkButton2.Visible = True
            LinkButton3.Visible = True
            Button1.Visible = False
        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = " عفوا هذه المنطقة غير موجودة"
            clear()
        End If

    End Sub

    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        If TextBox1.Text = "" Then
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يجب ادخال اسم المنطقة "
            TextBox1.Focus()
            Exit Sub
        End If
        obj_region.EdieRegion(TextBox1.Text, DropDownList1.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم تغيير اسم المدينة بنجاح"
        clear()
    End Sub


    Private Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        obj_region.DeleteRegion(TextBox1.Text)
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Red
        Label1.Text = "تم حذف المنطقة بنجاح"
        clear()
    End Sub
End Class