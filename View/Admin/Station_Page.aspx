<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Admin/Admin_Master.Master" CodeBehind="Station_Page.aspx.vb" Inherits="track_web.Station_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
           بيانات المحطات
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-6">
          <div>
            <div>
            <br/>
              <asp:TextBox ID="TextBox1" runat="server" placeholder="ادخل اسم المحطة" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>
            <div>
            <h6 class="text-right">المدينة</h6>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    DataSourceID="SqlDataSource2" DataTextField="city_name" class="form-control" 
                    DataValueField="city_name"></asp:DropDownList><a href="City_Page.aspx"><i class="fa fa-plus-circle"> </i></a>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                    SelectCommand="SELECT * FROM [City]"></asp:SqlDataSource>
            </div>
            <br/>
            <div>
             <h6 class="text-right">المنطقة</h6>
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3" 
                    DataTextField="region_name" DataValueField="region_name" class="form-control">
                    </asp:DropDownList><a href="Region_Page.aspx"><i class="fa fa-plus-circle"> </i></a>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                    SelectCommand="SELECT * FROM [Region] WHERE ([city_name] = @city_name)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="city_name" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
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
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="ادخل رقم المحطة" 
                            ForeColor="Black" MaxLength="50" Width="400px"></asp:TextBox>
                        </td>
                    <td>
                     <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success"  Height="50"  Width="200px">عــــرض البيانــــــات <i class="fa fa-search"></i></asp:LinkButton>
                </td>
                </tr>
            </table>



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

            </asp:SqlDataSource>
            
          </div>
         </div>
     </div>
  </section>
</asp:Content>
