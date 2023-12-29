<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Security/Security_Page.Master" CodeBehind="Truck_Page.aspx.vb" Inherits="track_web.Truck_Page1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
           بيانات الشاحنة
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-12">
             
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" width="1100px" 
                GridLines="None" EmptyDataText="لا يوجد بيانات لعرضها" 
                DataKeyNames="plate_number">
              <Columns>
                  <asp:BoundField DataField="plate_number" HeaderText="رقم اللوحة" ReadOnly="True" 
                      SortExpression="plate_number" />
                  <asp:BoundField DataField="Truck_type" HeaderText="نوع الشاحنة" 
                      SortExpression="Truck_type" />
                  <asp:BoundField DataField="year_manufacture" HeaderText="سنة الصنع" 
                      SortExpression="year_manufacture" />
                  <asp:BoundField DataField="country_manufacture" HeaderText="بلد الصنع" 
                      SortExpression="country_manufacture" />
                  <asp:BoundField DataField="Color" HeaderText="اللون" 
                      SortExpression="Color" />
                  <asp:BoundField DataField="transport_capacity" 
                      HeaderText="سعة الشاحنة" SortExpression="transport_capacity" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                
                
                
                SelectCommand="SELECT * FROM [Truck] WHERE ([plate_number] = @plate_number)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="plate_number" QueryStringField="truck" 
                        Type="String" />
                </SelectParameters>

            </asp:SqlDataSource>
            
          </div>
         </div>
     </div>
     </section>
</asp:Content>
