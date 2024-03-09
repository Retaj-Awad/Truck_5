<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Station_Page.aspx.vb" Inherits="track_web.Station_Page1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <!-- Basic -->
  <meta charset="utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <!-- Mobile Metas -->
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
  <!-- Site Metas -->
  <meta name="keywords" content="" />
  <meta name="description" content="" />
  <meta name="author" content="" />

  <title>Check Page</title>

  <!-- slider stylesheet -->
  <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css" />
  <!-- bootstrap core css -->
  <link rel="stylesheet" type="text/css" href="../../css/bootstrap.css" />
  <!-- font awesome style -->
  <link rel="stylesheet" type="text/css" href="../../css/font-awesome.min.css" />

  <!-- Custom styles for this template -->
  <link href="../../css/style.css" rel="stylesheet" />
  <!-- responsive style -->
  <link href="../../css/responsive.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="hero_area">
    <!-- header section strats -->
    <header class="header_section">
      <div class="header_top">
        <div class="container-fluid">
          <div class="contact_nav">
            <a href="">
              <i class="fa fa-phone" aria-hidden="true"></i>
              <span>
                Call : +01 123455678990
              </span>
            </a>
            <a href="">
              <i class="fa fa-envelope" aria-hidden="true"></i>
              <span>
                Email : demo@gmail.com
              </span>
            </a>
          </div>
        </div>
      </div>
      <div class="header_bottom">
        <div class="container-fluid">
          <nav class="navbar navbar-expand-lg custom_nav-container ">
            <a class="navbar-brand" href="index.html">
              <span>
                <asp:LinkButton ID="LinkButton1" runat="server">تسجيل خروج <i class="fa fa-sign-out"></i></asp:LinkButton>
              </span>
            </a>

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
              <span class=""> </span>
            </button>

            
          </nav>
        </div>
      </div>
    </header>
    <!-- end header section -->
    <!-- slider section -->
    <section class="slider_section ">
      <div class="container ">
        <div class="row">
          <div class="col-md-6 ">
            <div class="detail-box">
              <h1>
                Repair and <br>
                Maintenance <br>
                Services
              </h1>
              <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Qui harum voluptatem adipisci. Quos molestiae saepe dicta nobis pariatur, tempora iusto, ad possimus soluta hic praesentium mollitia consequatur beatae, aspernatur culpa.
              </p>
              <a href="">
                Contact Us
              </a>
            </div>
          </div>
          <div class="col-md-6">
            <div class="img-box">
              <img src="../../images/slider-img.png" alt="">
            </div>
          </div>
        </div>
      </div>
    </section>
    <!-- end slider section -->
  </div>

  
    
  <!-- contact section -->

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
       
            </div >

            <div>
              <asp:Button ID="Button1" runat="server" Text="  عرض الموقع على GPS" class="btn-primary" Visible="False"></asp:Button>
              <asp:Button ID="Button2" runat="server" Text="  عرض بيانات الشحنة" class="btn-primary"></asp:Button>
              <br/>
              <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
          </div>
        </div>
        <br/>
        <div class="row" dir="rtl">
        <div class="col-md-6">
        
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="shipment_code" DataSourceID="SqlDataSource1" width="700px" 
                GridLines="None" Visible="False">
              <Columns>
                  <asp:BoundField DataField="shipment_code" HeaderText="كود الشحنة" ReadOnly="True" 
                      SortExpression="shipment_code" InsertVisible="False" />
                  <asp:BoundField DataField="city_name" HeaderText="المدينة" 
                      SortExpression="city_name" />
                  <asp:BoundField DataField="region_name" HeaderText="المنطقة" 
                      SortExpression="region_name" />
                  <asp:BoundField DataField="station_number" HeaderText="رقم المحطة" 
                      SortExpression="station_number" />
                  <asp:BoundField DataField="station_name" 
                      HeaderText="المحطة" SortExpression="station_name" />
                  <asp:BoundField DataField="quantity" HeaderText="الكمية" 
                      SortExpression="quantity" />
                  <asp:BoundField DataField="plate_number" HeaderText="رقم اللوحة" 
                      SortExpression="plate_number" />
                  <asp:BoundField DataField="driver_name" HeaderText="السائق" 
                      SortExpression="driver_name" />
                  <asp:BoundField DataField="phone_number" HeaderText="هاتف السائق" 
                      SortExpression="phone_number" />
              </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                
                SelectCommand="SELECT Fuel_Shipment.shipment_code, Fuel_Shipment.region_name, Fuel_Shipment.quantity, Fuel_Shipment.plate_number, Stations.station_name, Stations.city_name, Driver.driver_name, Driver.phone_number, Fuel_Shipment.station_number FROM Fuel_Shipment INNER JOIN Stations ON Fuel_Shipment.station_number = Stations.station_number INNER JOIN Truck ON Fuel_Shipment.plate_number = Truck.plate_number INNER JOIN Driver ON Truck.license_number = Driver.license_number WHERE (Fuel_Shipment.shipment_code = @shipment_code) AND (Fuel_Shipment.station_number = @station_number)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="shipment_code" 
                        PropertyName="Text" />
                    <asp:SessionParameter Name="station_number" SessionField="station_number" />
                </SelectParameters>

            </asp:SqlDataSource>
            

            
          </div>
         </div>
          <br/>
           <br/>
           <div class="row" dir="rtl">
           <table>
                <tr>
                    <td>
                   <h4 align="right">حدد حالة الشحنة</h4>
                       <asp:DropDownList ID="DropDownList1" runat="server" class=" form-control"  Height="50"  Width="400px">
                           <asp:ListItem>تم الاستلام</asp:ListItem>
                           <asp:ListItem>تم الرفض</asp:ListItem>
                        </asp:DropDownList> 
                        </td>
                     <td>
                    <br/>
                     <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success"  Height="50"
                     Width="200px" Visible="False">ارســـال البيانــــــات <i class="fa fa-send"></i></asp:LinkButton>
                     <br/>
                     <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                   </td>
                        </tr>
                         <tr>
                      <td>
                      <br/>
                        <asp:TextBox ID="TextBox2" runat="server" placeholder="ملاحظات" 
                            ForeColor="Black" MaxLength="50" Width="400px" TextMode="MultiLine" class=" form-control" ></asp:TextBox>
                    </td>
                    </tr>
            </table>
     </div>
      </div>
  </section>
  <!-- end contact section -->


  <!-- info section -->
  <section class="info_section ">
    <div class="container">
      <h4>
        Get In Touch
      </h4>
      <div class="row">
        <div class="col-lg-10 mx-auto">
          <div class="info_items">
            <div class="row">
              <div class="col-md-4">
                <a href="">
                  <div class="item ">
                    <div class="img-box ">
                      <i class="fa fa-map-marker" aria-hidden="true"></i>
                    </div>
                    <p>
                      Lorem Ipsum is simply dummy text
                    </p>
                  </div>
                </a>
              </div>
              <div class="col-md-4">
                <a href="">
                  <div class="item ">
                    <div class="img-box ">
                      <i class="fa fa-phone" aria-hidden="true"></i>
                    </div>
                    <p>
                      +02 1234567890
                    </p>
                  </div>
                </a>
              </div>
              <div class="col-md-4">
                <a href="">
                  <div class="item ">
                    <div class="img-box">
                      <i class="fa fa-envelope" aria-hidden="true"></i>
                    </div>
                    <p>
                      demo@gmail.com
                    </p>
                  </div>
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="social-box">
      <h4>
        Follow Us
      </h4>
      <div class="box">
        <a href="">
          <i class="fa fa-facebook" aria-hidden="true"></i>
        </a>
        <a href="">
          <i class="fa fa-twitter" aria-hidden="true"></i>
        </a>
        <a href="">
          <i class="fa fa-youtube" aria-hidden="true"></i>
        </a>
        <a href="">
          <i class="fa fa-instagram" aria-hidden="true"></i>
        </a>
      </div>
    </div>
  </section>



  <!-- end info_section -->

  <!-- footer section -->
  <footer class="footer_section">
    <div class="container">
      <p>
        &copy; <span id="displayDateYear"></span> All Rights Reserved By
        <a href="https://html.design/">Free Html Templates</a>
      </p>
    </div>
  </footer>
  <!-- footer section -->

  <script src="../../js/jquery-3.4.1.min.js"></script>
  <script src="../../js/bootstrap.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js">
  </script>
  <script src="../../js/custom.js"></script>
  <!-- Google Map -->
  <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCh39n5U-4IoWpsVGUHWdqB6puEkhRLdmI&callback=myMap"></script>
  <!-- End Google Map -->
    </form>
</body>
</html>
