Imports System.Data.SqlClient
Imports System.Data


Public Class User_Class
 

    Function ShowUser(ByVal user_na)
        Dim cmd As New SqlCommand("select * from Users where user_name=@user_name", con)
        cmd.Parameters.AddWithValue("@user_name", user_na)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

    Sub AddUser(ByVal user_na, ByVal pass, ByVal validity, ByVal img, ByVal employee_number, ByVal station_number, ByVal city_name)
        Dim cmd As New SqlCommand("insert into Users (user_name,user_password,user_img,user_validity,employee_number,station_number,city_name) values (@user_name,@user_password,@user_img,@user_validity,@employee_number,@station_number,@city_name)", con)
        cmd.Parameters.AddWithValue("@user_name", user_na)
        cmd.Parameters.AddWithValue("@user_password", pass)
        cmd.Parameters.AddWithValue("@user_img", img)
        cmd.Parameters.AddWithValue("@user_validity", validity)
        cmd.Parameters.AddWithValue("@employee_number", employee_number)
        cmd.Parameters.AddWithValue("@station_number", station_number)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub


    Sub EdieUser(ByVal user_na, ByVal pass, ByVal validity, ByVal img, ByVal employee_number, ByVal station_number, ByVal city_name)
        Dim cmd As New SqlCommand("update  Users set user_password=@user_password,user_img=@user_img,user_validity =@user_validity,employee_number=@employee_number,station_number=@station_number,city_name=@city_name  where user_name=@user_name ", con)
        cmd.Parameters.AddWithValue("@user_name", user_na)
        cmd.Parameters.AddWithValue("@user_password", pass)
        cmd.Parameters.AddWithValue("@user_img", img)
        cmd.Parameters.AddWithValue("@user_validity", validity)
        cmd.Parameters.AddWithValue("@employee_number", employee_number)
        cmd.Parameters.AddWithValue("@station_number", station_number)
        cmd.Parameters.AddWithValue("@city_name", city_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub



    Sub DeleteUser(ByVal user_na)
        Dim cmd As New SqlCommand("delete from Users where user_name=@user_name ", con)
        cmd.Parameters.AddWithValue("@user_name", user_na)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub


    Sub DeleteUserStation(ByVal station_number)
        Dim cmd As New SqlCommand("delete from Users where station_number=@station_number ", con)
        cmd.Parameters.AddWithValue("@station_number", station_number)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub



End Class
