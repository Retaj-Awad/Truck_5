<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Admin/Admin_Master.Master" CodeBehind="Region_Page.aspx.vb" Inherits="track_web.Region_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
           إضافة منطقة 
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-6">
          <div>
            <div>
             <h6 class="text-right">المدينة</h6>
              <asp:DropDownList ID="DropDownList1" runat="server"  class="form-control" 
                    DataSourceID="SqlDataSource2" DataTextField="city_name" 
                    DataValueField="city_name"></asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                    SelectCommand="SELECT * FROM [City]"></asp:SqlDataSource>

              <br/>
              <asp:TextBox ID="TextBox1" runat="server" placeholder="ادخل اسم المنطقة" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>
            </div >

            <div>
              <asp:Button ID="Button1" runat="server" Text="حفــــــظ البيانــــــات" class="btn-primary"></asp:Button>

                <table>
                    <tr>
                        <td>
        
 <asp:LinkButton ID="LinkButton2" runat="server"   Width="275px"  class ="btn btn-info"  Visible="False">تعديــــل البيانــــــات <i class="fa fa-edit"></i></asp:LinkButton>
                          </td>
                        <td>
  <asp:LinkButton ID="LinkButton3" runat="server"   Width="275px"  class="btn btn-danger"  Visible="False">حـــــدف البيانــــــات <i class="fa fa-trash"></i></asp:LinkButton>
                            </td>
                    </tr>
                </table>
              <br/>
              <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
          </div>
        <div class="col-md-6">
            <table>
                <tr>
                    <td>
                    <br/>
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="ادخل اسم المنطقة" 
                            ForeColor="Black" MaxLength="50" Width="400px"></asp:TextBox>
                        </td>
                    <td>
                     <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success"  Height="50"  Width="200px">عــــرض البيانــــــات <i class="fa fa-search"></i></asp:LinkButton>
                </td>
                </tr>
            </table>



          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="region_name" DataSourceID="SqlDataSource1" width="600px" 
                GridLines="None">
              <Columns>
                  <asp:BoundField DataField="city_name" HeaderText="اسم المدينة" 
                      SortExpression="city_name" />
                  <asp:BoundField DataField="region_name" HeaderText="اسم المنطقة" 
                      SortExpression="region_name" ReadOnly="True" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                SelectCommand="SELECT * FROM [Region] ORDER BY [region_name]">

            </asp:SqlDataSource>
            
          </div>
         </div>
     </div>
  </section>
</asp:Content>
