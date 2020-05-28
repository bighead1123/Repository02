<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRoomType.aspx.cs" Inherits="EditRoomType" MasterPageFile="~/ContentMaster.master" %>
<asp:Content ID="EditRoomType" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style=" height:2px; width:720px;background-image:url(images/limit.jpg); background-repeat:repeat; background-position:center;">
 <div style="height:60px;"></div>
  <table border="2px" cellpadding="2px" cellspacing="2px" style="border-color:#C1C1DB;">
            <tr>
                <td align="right">
                    类型名称：</td>
                <td align="left" >
                    &nbsp;<asp:Label  ID="lblTypeName" runat="server"></asp:Label>
              
                 </td>
            </tr>
            <tr>
                <td  align="right">
                    类型价格：</td>
                <td  align="left">
                    <asp:TextBox ID="txtTypePrice" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTypePrice"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtTypePrice"
                        ErrorMessage="价格必须是数字" MaximumValue="100000000000000000000000" MinimumValue="0"
                        Type="Double"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td  align="right">
                    加床价格：</td>
                <td align="left">
                    <asp:TextBox ID="txtAddBedPrice" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddBedPrice"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtAddBedPrice"
                        ErrorMessage="价格必须是数字" MaximumValue="100000000000000000000000" MinimumValue="0"
                        Type="Double"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td  align="right" >
                    是否加床：</td>
                <td  align="left" >
                    &nbsp;
                    <asp:RadioButtonList ID="rdolstIsAddBed" runat="server" RepeatDirection="Horizontal"
                        Width="231px">
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem Selected="True">否</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td  align="right">
                    备&nbsp; &nbsp;注：</td>
                <td  align="left">
                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Height="93px" Width="322px"></asp:TextBox>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRemark"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
            </tr>
            <tr  align="center">
                <td colspan="2" >
                    <asp:Button ID="tbnSave" runat="server" Text="确   定" Width="120px" style="background-image:url(images/018.gif);" OnClick="tbnSave_Click" /></td>                
            </tr>
            <tr align="center">
                <td colspan="2" >
                    <asp:Label ID="lblResult" runat="server"></asp:Label></td>
            </tr>
        </table>
    
 </div>
</asp:Content>
