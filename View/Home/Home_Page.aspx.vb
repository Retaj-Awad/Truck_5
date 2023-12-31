Public Class Home_Page
    Inherits System.Web.UI.Page


    Dim obj As New User_Class

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As DataTable = obj.ShowUser(TextBox1.Text)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("user_password") = TextBox2.Text Then
                If dt.Rows(0).Item("user_validity") = "موظف شركة البريقة" Then
                    Session("admin") = TextBox1.Text
                    Response.Redirect("~/View/Admin/User_Page.aspx")

                ElseIf dt.Rows(0).Item("user_validity") = "موظف بوابة" Then
                    Session("security") = TextBox1.Text
                    Response.Redirect("~/View/Security/Check_Page.aspx")
                Else
                    Label1.Visible = True
                    Label1.Text = " المحطة"
                    Label1.ForeColor = Drawing.Color.Blue
                End If

            Else
                Label1.Visible = True
                Label1.Text = " كلمة المرور غير صحيحة"
                Label1.ForeColor = Drawing.Color.Red

                'this is new comment


            End If

        Else
            Label1.Visible = True
            Label1.Text = "اسم المستخدم غير موجود"
            Label1.ForeColor = Drawing.Color.Red

        End If
    End Sub
End Class