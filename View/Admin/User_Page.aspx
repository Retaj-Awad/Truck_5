<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Admin/Admin_Master.Master" CodeBehind="User_Page.aspx.vb" Inherits="track_web.User_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
           بيانات المستخدمين
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-6">
          <div>
            <div>
            <br/>
              <asp:TextBox ID="TextBox1" runat="server" placeholder="ادخل اسم المستخدم" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>
            <div>
              <asp:TextBox ID="TextBox2" runat="server" placeholder="ادخل كلمة المرور" ForeColor="Black" MaxLength="12"></asp:TextBox>
            </div>
              <asp:TextBox ID="TextBox3" runat="server" placeholder="ادخل تأكيد كلمة المرور" ForeColor="Black"  MaxLength="12"></asp:TextBox>
            </div>
            <div>
            <h6 class="text-right">صلاحية المستخدم</h6>
            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" AutoPostBack="True">
                 <asp:ListItem>اختر الصلاحية..</asp:ListItem>
                 <asp:ListItem>موظف بوابة</asp:ListItem>
                <asp:ListItem>موظف شركة البريقة</asp:ListItem>
                 <asp:ListItem>موظف المحطة</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br/>
            <div>
              <asp:TextBox ID="TextBox5" runat="server" placeholder="ادخل الرقم الوظيفي" ForeColor="Black" ReadOnly="True"></asp:TextBox>
            </div>

            <div>
            <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
            <h6 class="text-right">اسم المحطة</h6>
            <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" 
                    AutoPostBack="True" Enabled="False"  DataSourceID="SqlDataSource2" 
                    DataTextField="station_name" DataValueField="station_number">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                    SelectCommand="SELECT [station_number], [station_name] FROM [Stations]">
                </asp:SqlDataSource>
            </div>
            <br/>
            <div>
            <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
            <h6 class="text-right">بوابة مدينة</h6>
            <asp:DropDownList ID="DropDownList3" runat="server" class="form-control" 
                    AutoPostBack="True" Enabled="False" DataSourceID="SqlDataSource4" 
                    DataTextField="city_name" DataValueField="city_name">
                </asp:DropDownList>

            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                SelectCommand="SELECT * FROM [City]"></asp:SqlDataSource>

            </div>
             <br/>
            <div>
            <asp:Label ID="Label_img" runat="server" Text="Label" Visible="False"></asp:Label>
            <h6 class="text-right">صورة المستخدم</h6>
            <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Black"></asp:FileUpload>
            </div>

            <div >
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
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="ادخل اسم المستخدم" 
                            ForeColor="Black" MaxLength="50" Width="400px"></asp:TextBox>
                        </td>
                    <td>
                     <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success"  Height="50"  Width="200px">عــــرض البيانــــــات <i class="fa fa-search"></i></asp:LinkButton>
                </td>
                </tr>
            </table>



          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="user_name" DataSourceID="SqlDataSource1" width="600px" 
                GridLines="None" AllowPaging="True" PageSize="5">
              <Columns>
                  <asp:BoundField DataField="user_name" HeaderText="اسم المستخدم" ReadOnly="True" 
                      SortExpression="user_name" />
                  <asp:BoundField DataField="user_validity" HeaderText="الصلاحية" 
                      SortExpression="user_validity" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                SelectCommand="SELECT * FROM [Users] ">
            </asp:SqlDataSource>
            
          </div>
         </div>
     </div>
  </section>
</asp:Content>
