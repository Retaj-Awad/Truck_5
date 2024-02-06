Public Class GPS_Page1
    Inherits System.Web.UI.Page

    Dim obj_fual As New Fuel_Shipment_Class
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As DataTable = obj_fual.showFuel(TextBox1.Text)
        If dt.Rows.Count > 0 Then
            Response.Redirect("https://www.google.com/maps/search/" + dt.Rows(0).Item("laty") + " ," + dt.Rows(0).Item("lony"))
        Else
            Label1.Visible = True
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "يوجد خطا في كود الشحنة"
            TextBox1.Focus()
        End If

    End Sub
End Class