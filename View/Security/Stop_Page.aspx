<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Security/Security_Page.Master" CodeBehind="Stop_Page.aspx.vb" Inherits="track_web.Stop_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
      <div class="heading_container" dir="rtl">
        <h2>
        <br/>
        <br/>
           إيقــاف الشحنــــة
        </h2>
      </div>
      <div class="row" dir="rtl">
        <div class="col-md-12">
          
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="ادخل سبب ايقاف الشحنة" 
                            ForeColor="Black" TextMode="MultiLine" class=" form-control"></asp:TextBox>
                            <br/>
                     <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success"  Height="50"  Width="200px">ارسال البيانــــــات <i class="fa fa-send"></i></asp:LinkButton>
                     <br/>
                     <br/>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            <br/>
          </div>
         </div>
     </div>
</asp:Content>
