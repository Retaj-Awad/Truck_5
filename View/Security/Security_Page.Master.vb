Public Class Security_Page
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("security")) = True Then
            Response.Redirect("~/View/Home/Home_Page.aspx")
        End If
    End Sub



    Private Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session.RemoveAll()
        Response.Redirect("~/View/Home/Home_Page.aspx")
    End Sub
End Class