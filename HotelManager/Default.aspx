<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default"  MasterPageFile="~/ContentMaster.master"%>
<asp:Content ID="d" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style=" height:2px; width:720px;background-image:url(images/limit.jpg); background-repeat:repeat; background-position:center;"></div>
<div style="width:728px; height:385px;">
    <div style="height:100%; width:150px; float:left; position:relative; border-spacing:3px;text-align:center; background-image:url(images/state.jpg); background-repeat:repeat; background-position:center;">
        <div style="height:5px;"></div>
        <div>类型：<asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
        </asp:DropDownList></div>
        <div style="height:15px;"></div>
        <div style="padding-top:3px;">
            <div >选择房间状态</div>
            <div style="height:5px;"></div>
            <div style="height:280px; float:left; position:relative; width:40%; padding-left:5px; text-align:right; border-spacing:0px; padding-top:0px;">
             <asp:RadioButtonList id="rblRoomState" runat="server" Height="100%"><asp:ListItem Value="empty">空闲</asp:ListItem>
                <asp:ListItem Value="housing">住房</asp:ListItem>
                <asp:ListItem Value="helpOneself">自用</asp:ListItem>
                <asp:ListItem Value="modify">维修</asp:ListItem>
                <asp:ListItem Value="arrive">将到</asp:ListItem>
                <asp:ListItem Value="leave">将离</asp:ListItem>
             </asp:RadioButtonList>
            </div>
            <div style="float:right; position:relative; width:50%;border-spacing:0px; text-align:center; padding-top:8px;">
                <div style="height:43px;"><asp:Image ID="imgEmpty" runat="server" ImageUrl="~/images/RoomState/empty.jpg" /></div>
                <div style="height:45px; padding-top:3px;"><asp:Image ID="imgHousing" runat="server" ImageUrl="~/images/RoomState/housing.jpg" /></div>
                <div style="height:45px; padding-top:3px;"><asp:Image ID="imgHelpOneself" runat="server" ImageUrl="~/images/RoomState/helpOneself.jpg" /></div>
                <div style="height:45px; padding-top:3px;"><asp:Image ID="imgModify" runat="server" ImageUrl="~/images/RoomState/modify.jpg" /></div>
                <div style="height:45px; padding-top:3px;"><asp:Image ID="imgArrive" runat="server" ImageUrl="~/images/RoomState/arrive.jpg" /></div> 
                <div  style="height:45px; padding-top:3px;"><asp:Image ID="imgLeave" runat="server" ImageUrl="~/images/RoomState/leave.jpg" /></div>             
           </div>
        </div>
        <div style="height:15px;"></div>
        <div>
            <asp:Button ID="btnModifyRoomState" runat="server" Text="更     新"  style="background-image:url(images/018.gif);" Width="120px" OnClick="btnModifyRoomState_Click" />
        </div>
    </div>
    <div style="width:578px; float:right; position:relative; border-spacing:0px;height:385px; background-color:#F9FAFB;"> 
        <asp:DataList ID="dlRoomState" runat="server" RepeatDirection="Horizontal" RepeatColumns="17" OnItemCommand="dlRoomState_SelectedIndexChanged" DataKeyField="RoomID">
            <ItemTemplate>
               <div>
                   <asp:ImageButton ID="imgbtnState" runat="server" ImageUrl='<%# GetRoomStateImageUrlByState( Eval("State").ToString() ) %>'  CommandName="modify"  /></div>
               <div><asp:Label ID="lblRoomNumber" runat="server" Text=<%# Eval("Number") %>></asp:Label></div>
            </ItemTemplate>
            
        </asp:DataList>
    </div>   
</div>
</asp:Content>

