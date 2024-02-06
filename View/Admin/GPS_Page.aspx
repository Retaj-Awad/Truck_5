<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Admin/Admin_Master.Master" CodeBehind="GPS_Page.aspx.vb" Inherits="track_web.GPS_Page1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
            تتبع شاحنات الوقود GPS 
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-6">
          <div>
            <div>
            <br/>
              <asp:TextBox ID="TextBox1" runat="server" placeholder="ادخل كود الشحنة" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>
       
            <br/>
            </div >

            <div>
              <asp:Button ID="Button1" runat="server" Text="  عرض الموقع على GPS" class="btn-primary"></asp:Button>
              <br/>
              <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
          </div>
        <div class="col-md-6">
         <%--   
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="station_number" DataSourceID="SqlDataSource1" width="600px" 
                GridLines="None">
              <Columns>
                  <asp:BoundField DataField="station_number" HeaderText="رقم المحطة" ReadOnly="True" 
                      SortExpression="station_number" InsertVisible="False" />
                  <asp:BoundField DataField="station_name" HeaderText="اسم المحطة" 
                      SortExpression="station_name" />
                  <asp:BoundField DataField="city_name" HeaderText="المدينة" 
                      SortExpression="city_name" />
                  <asp:BoundField DataField="region_name" HeaderText="المنطقة" 
                      SortExpression="region_name" />
                  <asp:BoundField DataField="registration_date" DataFormatString="{0:d}" 
                      HeaderText="تاريخ التسجيل" SortExpression="registration_date" />
                  <asp:BoundField DataField="add_by" HeaderText="اضيف بواسطة" 
                      SortExpression="add_by" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                SelectCommand="SELECT * FROM [Stations] ORDER BY [station_name]">

            </asp:SqlDataSource>--%>
            
          </div>
         </div>
     </div>
  </section>
</asp:Content>
