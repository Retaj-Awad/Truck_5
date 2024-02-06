<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GPS_Page.aspx.vb" Inherits="track_web.GPS_Page" %>

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

  <title>GPS Page</title>

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
    <asp:Label ID="Label_def" runat="server" Text="0" Visible="False"></asp:Label>
    
    <asp:Timer ID="Timer1" runat="server" Interval="1000">
    </asp:Timer>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table align="center" dir="rtl">
            <tr>
                <td>
                <h4 align="center">اقل وقت للوصول&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h4>
                  <asp:Label ID="Label_mn" runat="server" Font-Size="XX-Large"  align="center" ForeColor="#669900"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                <h4 align="center"> اقصى وقت للوصول &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h4>
                  <asp:Label ID="Label_max" runat="server"  Font-Size="XX-Large" align="center" ForeColor="#CC0000"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                <h4 align="center">الوجهة &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h4>
                   <asp:Label ID="Label_city" runat="server" align="center" Font-Size="XX-Large"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>         
            </tr>
    </table>

    </ContentTemplate>
    </asp:UpdatePanel>
    <br/>
    <br/>
    <br/>
    <br/>
    
    
        <table align="center">
            <tr>
             <td>
                 <i class="fa fa-clock-o" style="font-size: xx-large"></i> </td>
                <td>
                  <asp:Label ID="Label_hou" runat="server" Font-Size="XX-Large"></asp:Label></td>
                <td>
                  <asp:Label ID="Label1" runat="server" Text=":"  Font-Size="XX-Large"></asp:Label> </td>
                <td>
                   <asp:Label ID="Label_min" runat="server" Font-Size="XX-Large"></asp:Label> </td>
                <td>
                  <asp:Label ID="Label2" runat="server" Text=":"  Font-Size="XX-Large"></asp:Label> </td>
                <td>
                     <asp:Label ID="Label_sec" runat="server" Font-Size="XX-Large"></asp:Label></td>
               
            </tr>
    </table>

    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick"> 
        </asp:AsyncPostBackTrigger>
    </Triggers>

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
