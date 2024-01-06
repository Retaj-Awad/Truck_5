<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Security/Security_Page.Master" CodeBehind="Check_Page.aspx.vb" Inherits="track_web.Check_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
            
           بيانات الشحنــــة
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-12">
          
           <table>
                <tr>
                    <td>
                    <br/>
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="ادخل كود الشحنة" 
                            ForeColor="Black" MaxLength="50" Width="800px"></asp:TextBox>
                        </td>
                    <td>
                     <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success"  Height="50"  Width="200px">عــــرض البيانــــــات <i class="fa fa-search"></i></asp:LinkButton>
                </td>
                </tr>
            </table>
            <br/>
            <table>
                <tr>
                    <td>
                     <h5>
            
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; اسم السائق
                    </h5>
                    </td>
                    <td>
                     <h5>
            
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; رقم اللوحة
                    </h5>
                    </td>
                    <td>
                    <h5>
            
           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;المدينة
                    </h5>
                    </td>
                    <td>
                    <h5>
            
         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;المنطقة
                    </h5>
                   </td>
                    <td>
                    <h5>
            
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;المحطة
                    </h5>
                    </td>
                    <td>
                    <h5>
            
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;الكمية
                    </h5>
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:HyperLink ID="HyperLink_driver" runat="server"></asp:HyperLink>
                    </td>
                    <td>
                    <asp:HyperLink ID="HyperLink_truk" runat="server"></asp:HyperLink>
                    </td>
                    <td>
                    <asp:Label ID="Label_city" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="Label_region" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="Label_station" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="Label_cap" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
            <br/>
            <br/>
             <h3 align="right">
            
           سجـــل الشحنــــة
             </h3>
             <br/>


            
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" width="700px" 
                GridLines="None" EmptyDataText="لا يوجد بيانات لعرضها">
              <Columns>
                  <asp:BoundField DataField="record_id" HeaderText="رقم السجل" 
                      SortExpression="record_id" InsertVisible="False" ReadOnly="True" />
                  <asp:BoundField DataField="record_data" HeaderText="التاريخ" 
                      SortExpression="record_data" DataFormatString="{0:d}" />
                  <asp:BoundField DataField="record_time" HeaderText="الوقت" 
                      SortExpression="record_time" />
                  <asp:BoundField DataField="shipment_status" HeaderText="الحالة" 
                      SortExpression="shipment_status" />
                  <asp:BoundField DataField="user_name" HeaderText="اضيف بواسطة" 
                      SortExpression="user_name" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                
                
                
                SelectCommand="SELECT Truck.plate_number, Driver.driver_name, Stations.station_name, Fuel_Shipment.shipment_code, Fuel_Shipment.region_name, Fuel_Shipment.quantity, Stations.city_name, Record_fuel.record_id, Record_fuel.record_data, Record_fuel.record_time, Record_fuel.shipment_status, Record_fuel.user_name FROM Fuel_Shipment INNER JOIN Truck ON Fuel_Shipment.plate_number = Truck.plate_number INNER JOIN Driver ON Truck.license_number = Driver.license_number INNER JOIN Stations ON Fuel_Shipment.station_number = Stations.station_number INNER JOIN Record_fuel ON Fuel_Shipment.shipment_code = Record_fuel.shipment_code WHERE (Fuel_Shipment.shipment_code = @shipment_code)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox4" Name="shipment_code" 
                        PropertyName="Text" />
                </SelectParameters>

            </asp:SqlDataSource>
            
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" width="1100px" 
                GridLines="None" EmptyDataText="لا يوجد بيانات لعرضها" Visible="False">
              <Columns>
                  <asp:BoundField DataField="plate_number" HeaderText="plate_number" 
                      SortExpression="plate_number" />
                  <asp:BoundField DataField="driver_name" HeaderText="driver_name" 
                      SortExpression="driver_name" />
                  <asp:BoundField DataField="station_name" HeaderText="station_name" 
                      SortExpression="station_name" />
                  <asp:BoundField DataField="shipment_code" HeaderText="shipment_code" 
                      SortExpression="shipment_code" InsertVisible="False" ReadOnly="True" />
                  <asp:BoundField DataField="region_name" HeaderText="region_name" 
                      SortExpression="region_name" />
                  <asp:BoundField DataField="quantity" 
                      HeaderText="quantity" SortExpression="quantity" />
                  <asp:BoundField DataField="city_name" HeaderText="city_name" 
                      SortExpression="city_name" />
                  <asp:BoundField DataField="record_id" HeaderText="record_id" 
                      InsertVisible="False" ReadOnly="True" SortExpression="record_id" />
                  <asp:BoundField DataField="record_data" HeaderText="record_data" 
                      SortExpression="record_data" />
                  <asp:BoundField DataField="record_time" HeaderText="record_time" 
                      SortExpression="record_time" />
                  <asp:BoundField DataField="shipment_status" HeaderText="shipment_status" 
                      SortExpression="shipment_status" />
                  <asp:BoundField DataField="user_name" HeaderText="user_name" 
                      SortExpression="user_name" />
              </Columns>
            </asp:GridView>
          </div>
         </div>
     </div>
     </section>
</asp:Content>
