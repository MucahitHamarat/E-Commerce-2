<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="ToysEcommerce.WebUI.Iletisim" %>

<%@ Register Src="~/SolTaraf.ascx" TagPrefix="UC" TagName="SolTaraf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="soltaraf">
            <UC:SolTaraf ID="SolTaraf" runat="server" />
        </div>
        <div class="form">
            <div class="satir">
                <span>Konu:</span>
                <%-- <select id="selectKonu" runat="server">
                    <option>İstek</option>
                    <option>Öneri</option>
                    <option>Şikayet</option>
                    <option>Diğer</option>
                </select>--%>
                <asp:DropDownList ID="DropDownListKonu" runat="server">
                    <asp:ListItem>İstek</asp:ListItem>
                    <asp:ListItem>Öneri</asp:ListItem>
                    <asp:ListItem>Şikayet</asp:ListItem>
                    <asp:ListItem>Diğer</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="satir">
                <span>Adınız Soyadınız:</span><input type="text" id="textAdSoyad" runat="server" />
                <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
            </div>
            <div class="satir">
                <span>Mail Adresiniz:</span><input type="text" id="textMail" runat="server" />
            </div>
            <div class="satir">
                <span>Sipariş Numarası:</span><input type="text" id="textSiparisNo" runat="server" />
            </div>
            <div class="satir">
                <span>Dosya&Döküman:</span><input type="file" id="fileUploadDosya" runat="server" />
            </div>
            <div class="satir">
                <span>Mesajınız:</span><textarea id="textMesaj" runat="server"></textarea>
            </div>
            <div class="satir">
                <asp:Button ID="ButtonGonder" runat="server" Text="Gönder" OnClick="ButtonGonder_Click" />
            </div>
        </div>
    </div>
</asp:Content>
