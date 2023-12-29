Public Class Stop_Page
    Inherits System.Web.UI.Page

    
    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Dim obj As New Fuel_Shipment_Class
        obj.StopFuel(TextBox4.Text, Request.QueryString("code"))
        Label1.Visible = True
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "تم ارسال سبب الايقاف بنجاح"
    End Sub
End Class