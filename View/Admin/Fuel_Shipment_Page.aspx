<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Admin/Admin_Master.Master" CodeBehind="Fuel_Shipment_Page.aspx.vb" Inherits="track_web.Fuel_Shipment_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact_section layout_padding">
     <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
           بيانات الشحنــــة
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-6">
          <div>
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
                    DataTextField="region_name" DataValueField="region_name" 
                    class="form-control" AutoPostBack="True">
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
            <div>
              <h6 class="text-right"> المحطة</h6>
            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource4" 
                    DataTextField="station_name" DataValueField="station_number" 
                    class="form-control">
                    </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                    
                    SelectCommand="SELECT [station_number], [station_name] FROM [Stations] WHERE ([region_name] = @region_name)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList2" Name="region_name" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <br/>
            <div>
             <h6 class="text-right"> رقم اللوحة</h6>
             <asp:DropDownList ID="DropDownList4" runat="server"  class="form-control" 
                    DataSourceID="SqlDataSource5" DataTextField="plate_number" 
                    DataValueField="plate_number"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                    SelectCommand="SELECT * FROM [Truck]"></asp:SqlDataSource>
            </div>
            <br/>
            </div >
            <br/>
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
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="ادخل كود الشحنة" 
                            ForeColor="Black" MaxLength="50" Width="400px"></asp:TextBox>
                        </td>
                    <td>
                     <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success"  Height="50"  Width="200px">عــــرض البيانــــــات <i class="fa fa-search"></i></asp:LinkButton>
                </td>
                </tr>
            </table>



          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="shipment_code" DataSourceID="SqlDataSource1" width="600px" 
                GridLines="None">
              <Columns>
                  <asp:BoundField DataField="shipment_code" HeaderText="كود الشحنة" ReadOnly="True" 
                      SortExpression="shipment_code" InsertVisible="False" />
                  <asp:BoundField DataField="region_name" HeaderText="المنطقة" 
                      SortExpression="region_name" />
                  <asp:BoundField DataField="quantity" HeaderText="الكمية" 
                      SortExpression="quantity" />
                  <asp:BoundField DataField="plate_number" HeaderText="رقم اللوحة" 
                      SortExpression="plate_number" />
                  <asp:BoundField DataField="user_name" HeaderText="اضيف بواسطة" 
                      SortExpression="user_name" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                SelectCommand="SELECT * FROM [Fuel_Shipment]">

            </asp:SqlDataSource>
            
          </div>
         </div>
     </div>
  </section>
</asp:Content>
