<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Brands.aspx.cs" Inherits="ToysEcommerce.WebUI.Brands" %>

<%@ Register Src="~/SolTaraf.ascx" TagPrefix="UC" TagName="SolTaraf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="soltaraf">
            <UC:SolTaraf ID="SolTaraf" runat="server" />
        </div>
        <div class="form">
            <asp:Repeater ID="RepeaterBrand" runat="server">
                <ItemTemplate>
                    <a href="Products.aspx?MarkaID=<%#Eval("ID")%>&MarkaAd=<%#Eval("Name")%>" class="brandName"><%#Eval("Name")%></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:Button ID="ButtonBilgiGonder" runat="server" Text="Bilgi Gönder" OnClick="ButtonBilgiGonder_Click"/>
    </div>

</asp:Content>
