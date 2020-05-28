<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/HotelManger.master" %>
<asp:Content  ID="loginContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="height:435px; width:100%;background-image:url(images/login_bg.gif); background-repeat:no-repeat; background-position:center;">
    <div style="height:435px; width:100%; filter:alpha(opacity=70);background:#EFF1F5;">
        <div style=" height:75px; width:20%; float:left; border-spacing:0px; position:relative;"></div>
         <div style=" height:300px; width:60%; float:left; border-spacing:0px; position:relative;">
             <table border="0" cellpadding="0" cellspacing="0" style="left: 16px; position: relative;
                 top: 246px; height: 99px">
                 <tr >
                     <td style="width: 100px; text-align:right;">
                         用户名：</td>
                     <td style="width: 100px">
                         <asp:TextBox ID="txtUserName" runat="server" Width="140px"></asp:TextBox></td>
                     <td style="width: 100px;text-align:left;">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                             ErrorMessage="*"></asp:RequiredFieldValidator></td>
                 </tr>
                 <tr>
                     <td style="width: 100px;text-align:right;">
                         密 &nbsp;码：</td>
                     <td style="width: 100px">
                         <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="140px"></asp:TextBox></td>
                     <td style="width: 100px;text-align:left;">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                             ErrorMessage="*"></asp:RequiredFieldValidator></td>
                 </tr>
                 <tr>                   
                     <td style=" text-align:center;" colspan="3" >
                         <asp:Button ID="btnLogin" runat="server" Text="登   录" style="background-image:url(images/018.gif); " Width="100px" OnClick="btnLogin_Click"/>
                         </td>
                     
                 </tr>
                 <tr>
                     <td colspan="3" style="text-align: center">
                         <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label></td>
                 </tr>
             </table>
             </div>
        <div style=" height:80px; width:20%; float:right; border-spacing:0px; position:relative;"></div>
    </div>
 </div>
</asp:Content>

