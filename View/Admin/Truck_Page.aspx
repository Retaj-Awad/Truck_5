<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Admin/Admin_Master.Master" CodeBehind="Truck_Page.aspx.vb" Inherits="track_web.Truck_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
           بيانات الشاحنة
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-6">
          <div>
            <div>
            <br/>
              <asp:TextBox ID="TextBox1" runat="server" placeholder="ادخل رقم اللوحة" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>

             <div>
              <asp:TextBox ID="TextBox2" runat="server" placeholder="ادخل نوع الشاحنة" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>
            <div>
              <asp:TextBox ID="TextBox3" runat="server" placeholder="ادخل سنة الصنع" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>
            <div>
              <asp:TextBox ID="TextBox5" runat="server" placeholder="ادخل بللد الصنع" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>

            <div>
              <asp:TextBox ID="TextBox6" runat="server" placeholder="ادخل لون الشاحنة" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>

             <div>
              <asp:TextBox ID="TextBox7" runat="server" placeholder="ادخل سعة الشاحنة" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>

            <div>
            <h6 class="text-right">سائق الشاحنة</h6>
            <asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="driver_name" class="form-control" 
                    DataValueField="license_number"></asp:DropDownList><a href="Driver_Page.aspx"><i class="fa fa-plus-circle"> </i></a>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                    SelectCommand="SELECT [license_number], [driver_name] FROM [Driver]"></asp:SqlDataSource>
            </div>
            <br/>
           
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
                        <asp:TextBox ID="TextBox4" runat="server" placeholder=" ادخل رقم اللوحة " 
                            ForeColor="Black" MaxLength="50" Width="400px"></asp:TextBox>
                        </td>
                    <td>
                     <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success"  Height="50"  Width="200px">عــــرض البيانــــــات <i class="fa fa-search"></i></asp:LinkButton>
                </td>
                </tr>
            </table>



          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="plate_number" DataSourceID="SqlDataSource1" width="600px" 
                GridLines="None">
              <Columns>
                  <asp:BoundField DataField="plate_number" HeaderText="رقم اللوحة" ReadOnly="True" 
                      SortExpression="plate_number" />
                  <asp:BoundField DataField="Truck_type" HeaderText="نوع الشاحنة" 
                      SortExpression="Truck_type" />
                  <asp:BoundField DataField="Color" HeaderText="اللون" 
                      SortExpression="Color" />
                  <asp:BoundField DataField="transport_capacity" HeaderText="السعة/لتر" 
                      SortExpression="transport_capacity" />
                  <asp:BoundField DataField="license_number" 
                      HeaderText="رقم الرخصة" SortExpression="license_number" />
                  <asp:BoundField DataField="user_name" HeaderText="إضيف بواسطة" 
                      SortExpression="user_name" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                SelectCommand="SELECT * FROM [Truck]">

            </asp:SqlDataSource>
            
          </div>
         </div>
     </div>
     </div>
  </section>
</asp:Content>
