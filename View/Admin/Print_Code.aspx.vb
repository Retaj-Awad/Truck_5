Imports Microsoft.Reporting.WebForms

Public Class Print_Code
    Inherits System.Web.UI.Page

    Private Sub Print_Code_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim parameter As New ReportParameter("ReportParameter1", Request.QueryString("code"))
        ReportViewer1.LocalReport.SetParameters(parameter)
        ReportViewer1.LocalReport.Refresh()
    End Sub

End Class