<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Security/Security_Page.Master" CodeBehind="Driver_Page.aspx.vb" Inherits="track_web.Driver_Page1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
           بيانات السائق
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-12">
          
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" width="1100px" 
                GridLines="None"
                DataKeyNames="license_number">
              <Columns>
                  <asp:BoundField DataField="license_number" HeaderText="رقم الرخصة" ReadOnly="True" 
                      SortExpression="license_number" />
                  <asp:BoundField DataField="driver_name" HeaderText="اسم السائق" 
                      SortExpression="driver_name" />
                  <asp:BoundField DataField="phone_number" HeaderText="رقم الهاتف" 
                      SortExpression="phone_number" />
                  <asp:BoundField DataField="home_adress" HeaderText="عنوان السكن" 
                      SortExpression="home_adress" />
                  <asp:BoundField DataField="Birth" HeaderText="تاريخ الميلاد" 
                      SortExpression="Birth" DataFormatString="{0:d}" />
                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Image ID="Image1" runat="server"  Width="100px"  Height="100px" 
                              class="rounded-circle" 
                              ImageUrl='<%# Eval("profile_img","~/Driver_img/{0}") %>' />
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                
                
                
                SelectCommand="SELECT * FROM [Driver] WHERE ([driver_name] = @driver_name)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="driver_name" QueryStringField="driver" 
                        Type="String" />
                </SelectParameters>

            </asp:SqlDataSource>
            
          </div>
         </div>
     </div>
     </section>
</asp:Content>
