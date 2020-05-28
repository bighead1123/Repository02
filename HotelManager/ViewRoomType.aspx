<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewRoomType.aspx.cs" Inherits="ViewRoomType" MasterPageFile="~/ContentMaster.master" %>
<asp:Content ID="ViewRoomType" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style=" height:2px; width:720px;background-image:url(images/limit.jpg); background-repeat:repeat; background-position:center;"></div>
<div>
        <asp:GridView ID="gvRoomType" runat="server" AutoGenerateColumns="False" DataKeyNames="TypeID" Width="100%" PageSize="17" AllowPaging="true" OnRowDataBound="gvRoomType_RowDataBound" OnRowCommand="gvRoomType_RowCommand" OnPageIndexChanging="gvRoomType_PageIndexChanging">
            <Columns>             
                <asp:TemplateField HeaderText="类型名称">
                    <ItemTemplate>
                        <asp:Label ID="lblTypeName" runat="server" Text=<%#( Eval("TypeName").ToString())%>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="类型价格"  DataField="TypePrice" DataFormatString="{0:C}"/>
                <asp:BoundField HeaderText="加床价格" DataField="AddBedPrice" DataFormatString="{0:C}"/>
                <asp:TemplateField HeaderText="是否加床">
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text=<%#( Eval("IsAddBed").ToString())%>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text=<%#( Eval("Remark").ToString())%>></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>             
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/images/Edit.gif"  AlternateText="编辑" CommandArgument=<%#Eval("TypeID") %> CommandName="Ed" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/images/delete.gif" AlternateText="删除"  CommandArgument=<%#Eval("TypeID") %> CommandName="De" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</div>
</asp:Content>