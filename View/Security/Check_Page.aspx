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
                            ForeColor="Black" MaxLength="50" Width="1000px"></asp:TextBox>
                        </td>
                    <td>
                     <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success"  Height="50"  Width="200px">عــــرض البيانــــــات <i class="fa fa-search"></i></asp:LinkButton>
                </td>
                </tr>
            </table>

            
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" width="1100px" 
                GridLines="None" EmptyDataText="لا يوجد بيانات لعرضها" Visible="False">
              <Columns>
                  <asp:BoundField DataField="shipment_code" HeaderText="كود الشحنة" ReadOnly="True" 
                      SortExpression="shipment_code" InsertVisible="False" />
                  <asp:BoundField DataField="station_name" HeaderText="اسم المحطة" 
                      SortExpression="station_name" />
                  <asp:BoundField DataField="city_name" HeaderText="المدينة" 
                      SortExpression="city_name" />
                  <asp:BoundField DataField="region_name" HeaderText="المنطقة" 
                      SortExpression="region_name" />
                  <asp:BoundField DataField="quantity" HeaderText="الكمية" 
                      SortExpression="quantity" />
                  <asp:BoundField DataField="shipment_status" 
                      HeaderText="حالة الشحنة" SortExpression="shipment_status" />
                  <asp:TemplateField HeaderText="السائق">
                      <ItemTemplate>
                          <asp:HyperLink ID="HyperLink2" runat="server" 
                              NavigateUrl='<%# Eval("driver_name","~/View/Security/Driver_Page.aspx?driver={0}") %>' 
                              Text='<%# Eval("driver_name") %>'></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="رقم اللوحة">
                      <ItemTemplate>
                          <asp:HyperLink ID="HyperLink3" runat="server" 
                              NavigateUrl='<%# Eval("plate_number","~/View/Security/Truck_Page.aspx?truck={0}") %>' 
                              Text='<%# Eval("plate_number") %>'></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                      <ItemTemplate>
                 <asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-danger" 
                              Height="50px" Width="200px" ForeColor="White" 
                              NavigateUrl='<%# Eval("shipment_code","~/View/Security/Stop_Page.aspx?code={0}") %>'> ايقــاف شحنــة <i  class="fa fa-warning"></i></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                
                
                SelectCommand="SELECT Truck.plate_number, Driver.driver_name, Stations.station_name, Fuel_Shipment.shipment_code, Fuel_Shipment.region_name, Fuel_Shipment.quantity, Fuel_Shipment.shipment_status, Stations.city_name FROM Fuel_Shipment INNER JOIN Truck ON Fuel_Shipment.plate_number = Truck.plate_number INNER JOIN Driver ON Truck.license_number = Driver.license_number INNER JOIN Stations ON Fuel_Shipment.station_number = Stations.station_number WHERE (Fuel_Shipment.shipment_code = @shipment_code)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox4" Name="shipment_code" 
                        PropertyName="Text" />
                </SelectParameters>

            </asp:SqlDataSource>
            
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" width="1100px" 
                GridLines="None" EmptyDataText="لا يوجد بيانات لعرضها" Visible="False">
              <Columns>
                  <asp:BoundField DataField="shipment_code" HeaderText="كود الشحنة" ReadOnly="True" 
                      SortExpression="shipment_code" InsertVisible="False" />
                  <asp:BoundField DataField="station_name" HeaderText="اسم المحطة" 
                      SortExpression="station_name" />
                  <asp:BoundField DataField="city_name" HeaderText="المدينة" 
                      SortExpression="city_name" />
                  <asp:BoundField DataField="region_name" HeaderText="المنطقة" 
                      SortExpression="region_name" />
                  <asp:BoundField DataField="quantity" HeaderText="الكمية" 
                      SortExpression="quantity" />
                  <asp:BoundField DataField="shipment_status" 
                      HeaderText="حالة الشحنة" SortExpression="shipment_status" />
                  <asp:TemplateField HeaderText="السائق">
                      <ItemTemplate>
                          <asp:HyperLink ID="HyperLink2" runat="server" 
                              NavigateUrl='<%# Eval("driver_name","~/View/Security/Driver_Page.aspx?driver={0}") %>' 
                              Text='<%# Eval("driver_name") %>'></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="رقم اللوحة">
                      <ItemTemplate>
                          <asp:HyperLink ID="HyperLink3" runat="server" 
                              NavigateUrl='<%# Eval("plate_number","~/View/Security/Truck_Page.aspx?truck={0}") %>' 
                              Text='<%# Eval("plate_number") %>'></asp:HyperLink>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" ForeColor="#CC0000" 
                              Text="هذه الشحنة موقوفة"></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
            </asp:GridView>
          </div>
         </div>
     </div>
     </section>
</asp:Content>
