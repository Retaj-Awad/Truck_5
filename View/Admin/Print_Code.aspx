<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print_Code.aspx.vb" Inherits="track_web.Print_Code" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2 class="style1">
    طباعة كود الشحنة
    </h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1000px" 
            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" 
            style="text-align: right">
        <LocalReport ReportPath="View\Admin\Code_Report.rdlc">
        </LocalReport>
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
