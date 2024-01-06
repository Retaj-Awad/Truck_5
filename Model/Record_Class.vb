Imports System.Data.SqlClient

Public Class Record_Class

    Sub AddRecord(ByVal shipment_code, ByVal record_data, ByVal record_time, ByVal shipment_status, ByVal note, ByVal user_name)
        Dim cmd As New SqlCommand("insert into Record_fuel (shipment_code,record_data,record_time,shipment_status,note,user_name) values (@shipment_code,@record_data,@record_time,@shipment_status,@note,@user_name)", con)
        cmd.Parameters.AddWithValue("@shipment_code", shipment_code)
        cmd.Parameters.AddWithValue("@record_data", record_data)
        cmd.Parameters.AddWithValue("@record_time", record_time)
        cmd.Parameters.AddWithValue("@shipment_status", shipment_status)
        cmd.Parameters.AddWithValue("@note", note)
        cmd.Parameters.AddWithValue("@user_name", user_name)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

    End Sub
End Class
