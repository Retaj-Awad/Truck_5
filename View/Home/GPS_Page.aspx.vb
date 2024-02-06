Public Class GPS_Page
    Inherits System.Web.UI.Page

    'Dim tick As Integer
    Dim obj_fuel As New Fuel_Shipment_Class

    'Private Sub Timer1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Load
    '    If Label_def.Text >= "01:00:00" Then
    '        tick = 15000
    '    Else
    '        tick = 10000
    '    End If
    'End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label_hou.Text = DateTime.Now.Hour.ToString()
        Label_min.Text = DateTime.Now.Minute.ToString()
        Label_sec.Text = DateTime.Now.Second.ToString()


        If Label_sec.Text = 59 Then
            If Label_def.Text >= "01:00:00" Then
                If Session("count") = 15 Then
                    obj_fuel.updatelaty_lony(Request.QueryString("code"), send_laty.Value, send_lony.Value)
                    Session("count") = 0
                Else
                    Session("count") = Session("count") + 1
                End If

            ElseIf   Label_def.Text < "01:00:00" Then
                If Session("count") = 10 Then
                    obj_fuel.updatelaty_lony(Request.QueryString("code"), send_laty.Value, send_lony.Value)
                    Session("count") = 0
                Else
                    Session("count") = Session("count") + 1
                End If
            End If
        End If

    End Sub

    Private Sub GPS_Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Label_def.Text = Request.QueryString("defult_time")
        Label_city.Text = Request.QueryString("city")
        Label_max.Text = Request.QueryString("max")
        Label_mn.Text = Request.QueryString("defult_time")


    End Sub
End Class