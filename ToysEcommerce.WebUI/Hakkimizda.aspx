<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Hakkimizda.aspx.cs" Inherits="ToysEcommerce.WebUI.Hakkimizda" %>

<%@ Register Src="~/SolTaraf.ascx" TagPrefix="UC" TagName="SolTaraf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span>Adı:</span><asp:Label ID="LabelAd" runat="server" Text=""></asp:Label><br />
    <span>Sepet Bilgisi :</span><asp:Label ID="LabelSepet" runat="server" Text=""></asp:Label><br />


    <div class="container">
        <div class="soltaraf">
            <UC:SolTaraf ID="SolTaraf" runat="server" />
        </div>
        <div class="form">
            <h1 id="h1Baslik" runat="server">HAKKKIMIZDA</h1>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataTextField="Name" DataValueField="ID" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"></asp:CheckBoxList>
            
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataTextField="Name" DataValueField="ID"></asp:RadioButtonList>

            <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Name" DataValueField="ID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>

            <asp:Button ID="ButtonGonder" runat="server" Text="Button" OnClick="ButtonGonder_Click" /><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
