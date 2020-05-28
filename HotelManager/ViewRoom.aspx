<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewRoom.aspx.cs" Inherits="ViewRoom" MasterPageFile="~/ContentMaster.master" %>
<asp:Content ID="ViewRoom" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style=" height:2px; width:720px;background-image:url(images/limit.jpg); background-repeat:repeat; background-position:center;"></div>
<div>
        <asp:GridView ID="gvRoom" runat="server" AutoGenerateColumns="False" DataKeyNames="RoomID" Width="100%" PageSize="17" AllowPaging="true" OnRowDataBound="gvRoom_RowDataBound" OnRowCommand="gvRoom_RowCommand" OnPageIndexChanging="gvRoom_PageIndexChanging">
            <Columns>             
                <asp:BoundField HeaderText="房间号"  DataField="Number"/>
                <asp:TemplateField HeaderText="客房类型">
                    <ItemTemplate>
                        <asp:Label ID="lblRoomType" runat="server" Text=<%#GetRoomType( Eval("TypeID").ToString())%>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="床位数"  DataField="BedNumber"/>
                <asp:BoundField HeaderText="客人数" DataField="GuestNumber"/>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text=<%#GetRoomState( Eval("State").ToString())%>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="描述">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text=<%#SubStringDescription( Eval("Description").ToString())%>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>             
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/images/Edit.gif"  AlternateText="编辑" CommandArgument=<%#Eval("RoomID") %> CommandName="Ed" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/images/delete.gif" AlternateText="删除"  CommandArgument=<%#Eval("RoomID") %> CommandName="De" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</div>
</asp:Content>