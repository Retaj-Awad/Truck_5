<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Admin/Admin_Master.Master" CodeBehind="City_Page.aspx.vb" Inherits="track_web.City_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
          إضافة مدينة
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-6">
          <div>
            <div>
            <br/>
              <asp:TextBox ID="TextBox1" runat="server" placeholder="ادخل اسم المدينة" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>
            </div >

            <div>
              <asp:Button ID="Button1" runat="server" Text="حفــــــظ البيانــــــات" class="btn-primary"></asp:Button>

               
       
  <asp:LinkButton ID="LinkButton3" runat="server"   Width="550px"  class="btn btn-danger"  Visible="False">حـــــدف البيانــــــات <i class="fa fa-trash"></i></asp:LinkButton>
                           
              <br/>
              <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
          </div>
        <div class="col-md-6">
            <table>
                <tr>
                    <td>
                    <br/>
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="ادخل اسم المدينة" 
                            ForeColor="Black" MaxLength="50" Width="400px"></asp:TextBox>
                        </td>
                    <td>
                     <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success"  Height="50"  Width="200px">عــــرض البيانــــــات <i class="fa fa-search"></i></asp:LinkButton>
                </td>
                </tr>
            </table>



          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="city_name" DataSourceID="SqlDataSource1" width="600px" 
                GridLines="None">
              <Columns>
                  <asp:BoundField DataField="city_name" HeaderText="اسم المدينة" ReadOnly="True" 
                      SortExpression="city_name" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                SelectCommand="SELECT * FROM [City] ORDER BY [city_name]">

            </asp:SqlDataSource>
            
          </div>
         </div>
     </div>
  </section>
</asp:Content>
