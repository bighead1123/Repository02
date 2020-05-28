<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRoom.aspx.cs" Inherits="EditRoom" MasterPageFile="~/ContentMaster.master" %>
<asp:Content ID="EditRoom" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style=" height:2px; width:720px;background-image:url(images/limit.jpg); background-repeat:repeat; background-position:center;">
 <div style="height:60px;"></div>
 <table border="2px" cellpadding="2px" cellspacing="2px" style="border-color:#C1C1DB;">
            <tr>
                <td align="right">
                    房 间 号：</td>
                <td align="left" >
                    &nbsp;<asp:Label  ID="lblRoomNO" runat="server"></asp:Label>
              
                 </td>
            </tr>
            <tr>
                <td  align="right">
                    客房类型：</td>
                <td  align="left">
                    <asp:DropDownList ID="ddlRoomType" runat="server">
                    </asp:DropDownList>
               
                </td>
            </tr>
            <tr>
                <td  align="right">
                    客房状态：</td>
                <td align="left">
                    <asp:DropDownList ID="ddlRoomState" runat="server">
                        <asp:ListItem Value="empty">空闲</asp:ListItem>
                        <asp:ListItem Value="housing">入住</asp:ListItem>
                        <asp:ListItem Value="modify">维修</asp:ListItem>
                        <asp:ListItem Value="helpOneself">自用</asp:ListItem>
                        <asp:ListItem Value="arrive">将到</asp:ListItem>
                        <asp:ListItem Value="leave">将离</asp:ListItem>
                    </asp:DropDownList>
                
                </td>
            </tr>
            <tr>
                <td  align="right">
                    床 位 数：</td>
                <td  align="left">
                    <asp:TextBox ID="txtBedNumber" runat="server"></asp:TextBox>
                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBedNumber"
                        ErrorMessage="*"></asp:RequiredFieldValidator>  <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtBedNumber"
                        ErrorMessage="床位数为0—100的整数" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td  align="right">
                    客 人 数：</td>
                <td align="left">
                    <asp:TextBox ID="txtGuestNumber" runat="server"></asp:TextBox>
                
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGuestNumber"
                        ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtGuestNumber"
                        ErrorMessage="客人数为0-100的正数" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td  align="right">
                    描 &nbsp;  述：</td>
                <td  align="left">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="93px" Width="322px"></asp:TextBox>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDescription"
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