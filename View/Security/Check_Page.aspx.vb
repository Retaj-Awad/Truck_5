Public Class Check_Page
    Inherits System.Web.UI.Page

   

    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Dim obj As New Fuel_Shipment_Class
        Dim dt As DataTable = obj.Check_StopFuel(TextBox4.Text)
        If dt.Rows.Count > 0 Then
            GridView1.Visible = False
            GridView2.Visible = True
        Else
            GridView1.Visible = True
            GridView2.Visible = False

        End If
    End Sub
End Class