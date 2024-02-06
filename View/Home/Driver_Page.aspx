<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Driver_Page.aspx.vb" Inherits="track_web.Driver_Page2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<!-- Basic -->
  <meta charset="utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <!-- Mobile Metas -->
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
  <!-- Site Metas -->
  <meta name="keywords" content="" />
  <meta name="description" content="" />
  <meta name="author" content="" />

  <title>Driver Page</title>

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

<body onload="javascript:geolocate()">
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
                Inance
              </span>
            </a>

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
              <span class=""> </span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent" dir="rtl">
              <ul class="navbar-nav ">
                <li class="nav-item active">
                  <a class="nav-link" href="Home_Page.aspx">الرئيسية <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href=""> حول الموقع</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="">خدماتنا</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="">اتصال بنا</a>
                </li>
                 <li class="nav-item">
                  <a class="nav-link" href="">دخول السائق</a>
                </li>
              </ul>
            </div>
          </nav>
        </div>
      </div>
    </header>
    <!-- end header section -->

  <!-- contact section -->

  <section class="contact_section layout_padding">
    <div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
         بيانــات الســائق
        </h2>
      </div>
      <div class="row" dir="rtl">
      <div class="col-md-3">
          </div>
        <div class="col-md-6">
          <div>
            <div>
              <asp:TextBox ID="TextBox1" runat="server" placeholder="ادخل رقم الرخصة" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </div>
            <div >
              <asp:Button ID="Button1" runat="server" Text="موافــــق" class="btn-primary"></asp:Button>
               <asp:Button ID="Button2" runat="server" Text="بدأ الرحــــلة" class="btn-primary" Visible="False"></asp:Button>
              <br>
              <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
          </div>
        </div>
         <div class="col-md-3">
          </div>

        <div class="col-md-12">
          <div class="map_container">
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                  DataSourceID="SqlDataSource2" 
                  EmptyDataText="لا يوجد شحنة مخصصة لهذا السائق حاليا">
               <Columns>
                   <asp:BoundField DataField="shipment_code" HeaderText="shipment_code" 
                       InsertVisible="False" ReadOnly="True" SortExpression="shipment_code" />
                   <asp:BoundField DataField="region_name" HeaderText="region_name" 
                       SortExpression="region_name" />
                   <asp:BoundField DataField="quantity" HeaderText="quantity" 
                       SortExpression="quantity" />
                   <asp:BoundField DataField="plate_number" HeaderText="plate_number" 
                       SortExpression="plate_number" />
                   <asp:BoundField DataField="driver_name" HeaderText="driver_name" 
                       SortExpression="driver_name" />
                   <asp:BoundField DataField="profile_img" HeaderText="profile_img" 
                       SortExpression="profile_img" />
                   <asp:BoundField DataField="station_name" HeaderText="station_name" 
                       SortExpression="station_name" />
                   <asp:BoundField DataField="city_name" HeaderText="city_name" 
                       SortExpression="city_name" />
                   <asp:BoundField DataField="shipment_status" HeaderText="shipment_status" 
                       SortExpression="shipment_status" />
                   <asp:BoundField DataField="license_number" HeaderText="license_number" 
                       SortExpression="license_number" />
               </Columns>
              </asp:GridView>
              <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                  ConnectionString="<%$ ConnectionStrings:Track_Connection %>" 
                  SelectCommand="SELECT Fuel_Shipment.shipment_code, Fuel_Shipment.region_name, Fuel_Shipment.quantity, Fuel_Shipment.plate_number, Driver.driver_name, Driver.profile_img, Stations.station_name, Stations.city_name, Record_fuel.shipment_status, Driver.license_number FROM Fuel_Shipment INNER JOIN Truck ON Fuel_Shipment.plate_number = Truck.plate_number INNER JOIN Driver ON Truck.license_number = Driver.license_number INNER JOIN Stations ON Fuel_Shipment.station_number = Stations.station_number INNER JOIN Record_fuel ON Fuel_Shipment.shipment_code = Record_fuel.shipment_code WHERE (Driver.license_number = @license_number) AND (Record_fuel.shipment_status = @shipment_status)">
                  <SelectParameters>
                      <asp:ControlParameter ControlID="TextBox1" Name="license_number" 
                          PropertyName="Text" />
                      <asp:Parameter DefaultValue="قيد التوصيل" Name="shipment_status" />
                  </SelectParameters>
              </asp:SqlDataSource>
              <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- end contact section -->


  
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

  <script type="text/javascript">
      function geolocate() {
          if (navigator.geolocation) {
              navigator.geolocation.getCurrentPosition(showPosition);
          }
      }
      function showPosition(position) {
          var location1 = position.coords.latitude;

          var location2 = position.coords.longitude;
          document.getElementById('<%=send_laty.ClientID%>').value = location1
          document.getElementById('<%=send_lony.ClientID%>').value = location2
      }
      
</script>
        <asp:HiddenField ID="send_laty" runat="server" />
        <asp:HiddenField ID="send_lony" runat="server" />
    </form>
</body>
</html>
