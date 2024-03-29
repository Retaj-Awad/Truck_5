﻿Imports System.Data.SqlClient
Imports System.Data


Public Class Driver_Class

    Sub AddDriver(ByVal license_number, ByVal driver_name, ByVal phone_number, ByVal home_adress, ByVal Birth, ByVal profile_img, ByVal user_name)
        Dim cmd As New SqlCommand("insert into Driver (license_number,driver_name,phone_number,home_adress,Birth,profile_img,user_name) values (@license_number,@driver_name,@phone_number,@home_adress,@Birth,@profile_img,@user_name)", con)
        cmd.Parameters.AddWithValue("@license_number", license_number)
        cmd.Parameters.AddWithValue("@driver_name", driver_name)
        cmd.Parameters.AddWithValue("@phone_number", phone_number)
        cmd.Parameters.AddWithValue("@home_adress", home_adress)
        cmd.Parameters.AddWithValue("@Birth", Birth)
        cmd.Parameters.AddWithValue("@profile_img", profile_img)
        cmd.Parameters.AddWithValue("@user_name", user_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Function Show_Driver(ByVal license_number)
        Dim cmd As New SqlCommand("select * from  Driver  where license_number=@license_number", con)
        cmd.Parameters.AddWithValue("@license_number", license_number)
        Dim adp As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)
        Return dt
    End Function

    Sub Edie_Driver(ByVal license_number, ByVal driver_name, ByVal phone_number, ByVal home_adress, ByVal Birth, ByVal profile_img)
        Dim cmd As New SqlCommand("update  Driver set driver_name=@driver_name,phone_number=@phone_number,home_adress =@home_adress,Birth=@Birth,profile_img=@profile_img  where license_number=@license_number ", con)
        cmd.Parameters.AddWithValue("@license_number", license_number)
        cmd.Parameters.AddWithValue("@driver_name", driver_name)
        cmd.Parameters.AddWithValue("@phone_number", phone_number)
        cmd.Parameters.AddWithValue("@home_adress", home_adress)
        cmd.Parameters.AddWithValue("@Birth", Birth)
        cmd.Parameters.AddWithValue("@profile_img", profile_img)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub


    Sub Delete_Driver(ByVal license_number)
        Dim cmd As New SqlCommand("delete from Driver where license_number=@license_number ", con)
        cmd.Parameters.AddWithValue("@license_number", license_number)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class
