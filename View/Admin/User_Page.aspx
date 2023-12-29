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
            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" >
                <asp:ListItem>موظف شركة البريقة</asp:ListItem>
                <asp:ListItem>موظف بوابة</asp:ListItem>
                </asp:DropDownList>
            </div>
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
                GridLines="None">
              <Columns>
                  <asp:BoundField DataField="user_name" HeaderText="اسم المستخدم" ReadOnly="True" 
                      SortExpression="user_name" />
                  <asp:BoundField DataField="user_validity" HeaderText="الصلاحية" 
                      SortExpression="user_validity" />
                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Image ID="Image1" runat="server" Height="100px" 
                              ImageUrl='<%# Eval("user_img","~/User_img/{0}") %>' Width="100px"  class="rounded-circle" AlternateText="لم يتم تحميل صورة"/>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                SelectCommand="SELECT * FROM [Users] WHERE ([user_validity] &lt;&gt; @user_validity)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="موظف المحطة" Name="user_validity" Type="String" />
                </SelectParameters>

            </asp:SqlDataSource>
            
          </div>
         </div>
     </div>
  </section>
</asp:Content>
