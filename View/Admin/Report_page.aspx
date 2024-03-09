<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Admin/Admin_Master.Master" CodeBehind="Report_page.aspx.vb" Inherits="track_web.Report_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
           تقرير تقييم وصول الشحنات
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-8">
        <div class="row" dir="rtl">
         <div class="col-md-3" align="right">
           <asp:RadioButton ID="RadioButton3" runat="server" Text="البحث حسب الكود"  GroupName="A"></asp:RadioButton>
              <asp:TextBox ID="TextBox1" runat="server"  ForeColor="Black" MaxLength="50"  class=" form-control" ></asp:TextBox>
         </div>

         <div class="col-md-3"  align="right">
            <asp:RadioButton ID="RadioButton2" runat="server" Text="البحث حسب السائق"
              GroupName="A"></asp:RadioButton>
             <asp:DropDownList ID="DropDownList1" runat="server" 
                 DataSourceID="SqlDataSource1" DataTextField="driver_name" 
                 DataValueField="license_number" class=" form-control"></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
               ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                 SelectCommand="SELECT [license_number], [driver_name] FROM [Driver]">
             </asp:SqlDataSource>
         </div>

         <div class="col-md-3"  align="right">
            <asp:RadioButton ID="RadioButton1" runat="server" Text="البحث حسب المحطة"
              GroupName="A"></asp:RadioButton>
            <asp:DropDownList ID="DropDownList2" runat="server" 
                 DataSourceID="SqlDataSource2" DataTextField="station_name" 
                 DataValueField="station_number"  class=" form-control"></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                 SelectCommand="SELECT [station_number], [station_name] FROM [Stations]">
             </asp:SqlDataSource>
         </div>

         <div class="col-md-3">
           <br/>
          
              <asp:Button ID="Button1" runat="server" Text=" عرض التقييم" class="btn-primary" Font-Size="X-Large"></asp:Button>
             
              <br/>
              <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
        
         </div>
      </div>
         </div>
     </div>
     <br/>
      <br/>
       <br/>
     <div class="row" dir="rtl">

     <div class="col-md-1">
      </div>
        <div class="col-md-11" align="right" dir="rtl">

          <asp:GridView ID="GridView_Code" runat="server"  width="1000px" 
                GridLines="None" Visible="False"></asp:GridView>
          <asp:Label ID="Label2" runat="server" Text="عدد الرحلات" Visible="False"></asp:Label>  <asp:Label ID="Label3" runat="server" Text="0" Visible="False"></asp:Label>
          <br />
           <br />
           <asp:GridView ID="GridView_driver" runat="server"  width="1000px" 
                GridLines="None" Visible="False"></asp:GridView>
              
          </div>
           </div>
  </section>
</asp:Content>
