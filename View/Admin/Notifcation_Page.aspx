<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Admin/Admin_Master.Master" CodeBehind="Notifcation_Page.aspx.vb" Inherits="track_web.Notifcation_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
            الاشعارات
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-12">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="shipment_code" DataSourceID="SqlDataSource1" width="1200px" 
                GridLines="None" AllowPaging="True">
              <Columns>
                  <asp:BoundField DataField="shipment_code" HeaderText="كود الشحنة" ReadOnly="True" 
                      SortExpression="shipment_code" InsertVisible="False" />
                  <asp:BoundField DataField="quantity" HeaderText="الكمية" 
                      SortExpression="quantity" />
                  <asp:BoundField DataField="city_name" 
                      HeaderText="المدينة" SortExpression="city_name" />
                  <asp:BoundField DataField="region_name" HeaderText="المنطقة" 
                      SortExpression="region_name" />
                  <asp:BoundField DataField="station_name" HeaderText="المحطة" 
                      SortExpression="station_name" />
                  <asp:BoundField DataField="plate_number" HeaderText="اللوحة" 
                      SortExpression="plate_number" />
                  <asp:BoundField DataField="driver_name" HeaderText=" السائق" 
                      SortExpression="driver_name" />
                  <asp:BoundField DataField="emp" HeaderText="موظف الشركة " 
                      SortExpression="emp" />
                  <asp:BoundField DataField="record_data" HeaderText="تاريخ الاجراء" 
                      SortExpression="record_data" DataFormatString="{0:d}" />
                  <asp:BoundField DataField="record_time" HeaderText="توقيت الاجراء" 
                      SortExpression="record_time" />
                  <asp:BoundField DataField="sec_stat" HeaderText="الاجراء من قبل" 
                      SortExpression="sec_stat" />
                  <asp:BoundField DataField="shipment_status" HeaderText="حالة الشحنة" 
                      SortExpression="shipment_status" />
                  <asp:BoundField DataField="note" HeaderText="ملاحظات" SortExpression="note" />
              </Columns>
            </asp:GridView>
          
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                
                SelectCommand="SELECT Fuel_Shipment.shipment_code, Fuel_Shipment.region_name, Fuel_Shipment.quantity, Fuel_Shipment.plate_number, Stations.station_name, Fuel_Shipment.user_name AS emp, Driver.driver_name, Stations.city_name, Record_fuel.record_data, Record_fuel.record_time, Record_fuel.shipment_status, Record_fuel.note, Record_fuel.user_name AS sec_stat FROM Stations INNER JOIN Fuel_Shipment ON Stations.station_number = Fuel_Shipment.station_number INNER JOIN Truck ON Fuel_Shipment.plate_number = Truck.plate_number INNER JOIN Driver ON Truck.license_number = Driver.license_number INNER JOIN Record_fuel ON Fuel_Shipment.shipment_code = Record_fuel.shipment_code WHERE (Record_fuel.shipment_status &lt;&gt; @shipment_status) ORDER BY Record_fuel.record_data">
                <SelectParameters>
                    <asp:Parameter DefaultValue="قيد التوصيل" Name="shipment_status" />
                </SelectParameters>
            </asp:SqlDataSource>
          
          </div>
        
         </div>
     </div>
  </section>
</asp:Content>
