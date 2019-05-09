<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SolTaraf.ascx.cs" Inherits="ToysEcommerce.WebUI.SolTaraf" %>
<h1>Kategori</h1>
<ul>
    <asp:Repeater ID="RepeaterKategori" runat="server">
        <ItemTemplate>
            <li><%#Eval("Name")%></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<h1>Markalar</h1>
<ul>
    <asp:Repeater ID="RepeaterMarka" runat="server">
        <ItemTemplate>
            <li><%#Eval("Name")%></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>

