Imports System.Data
Public Class Report_page
    Inherits System.Web.UI.Page

    Dim obj_ful As New Fuel_Shipment_Class



    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton3.Checked = True Then
            Dim dt As DataTable = obj_ful.report_by_code(TextBox1.Text)
            GridView_Code.DataSource = dt
            GridView_Code.DataBind()
            GridView_Code.Visible = True
        Else
            GridView_Code.Visible = False
        End If



        If RadioButton2.Checked = True Then
            Dim dt As DataTable = obj_ful.report_by_driver(DropDownList1.SelectedValue)
            GridView_driver.DataSource = dt
            GridView_driver.DataBind()
            GridView_driver.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label3.Text = dt.Rows.Count()
        Else
            GridView_driver.Visible = False
            Label2.Visible = False
            Label3.Visible = False
        End If

    End Sub

    Private Sub GridView_Code_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView_Code.RowDataBound
        Dim eval As String = e.Row.Cells(10).Text
        If eval = "توصيل بطيئ" Then
            e.Row.BackColor = System.Drawing.Color.Red
        ElseIf eval = "توصيل سريع" Then
            e.Row.BackColor = System.Drawing.Color.Green
        End If



    End Sub

    Private Sub GridView_driver_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView_driver.RowDataBound
        Dim eval As String = e.Row.Cells(10).Text
        If eval = "توصيل بطيئ" Then
            e.Row.BackColor = System.Drawing.Color.Red
        ElseIf eval = "توصيل سريع" Then
            e.Row.BackColor = System.Drawing.Color.Green
        End If
    End Sub
End Class