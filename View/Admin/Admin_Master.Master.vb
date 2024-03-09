Public Class Admin_Master
    Inherits System.Web.UI.MasterPage
    Dim obj As New Record_Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("admin")) = True Then
            Response.Redirect("~/View/Home/Home_Page.aspx")
        End If

        Label2.Text = obj.numbernotifcation()
    End Sub

    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session.RemoveAll()
        Response.Redirect("~/View/Home/Home_Page.aspx")
    End Sub

    Private Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        obj.Updatereadnotifcation()
        Response.Redirect("~/View/Admin/Notifcation_Page.aspx")
    End Sub
End Class