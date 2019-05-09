<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToysEcommerce.WebUI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="slider">
            <div class="owl-carousel sliderOwl">
                <asp:Repeater ID="RepeaterSlider" runat="server">
                    <ItemTemplate>
                        <a href="<%#Eval("Link") %>">
                            <img src="<%#Eval("Picture") %>" alt="<%#Eval("Name") %>" /></a>
                        <%-- <div class="slideitem" style="background-image:url(<%#Eval("Picture") %>)">
                        </div>--%>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="owl-carousel productOwl">
            <asp:Repeater ID="RepeaterProducts" runat="server">
                <ItemTemplate>
                    <div class="productItem">
                        <div>
                            <img src="<%#Eval("Picture") %>" alt="<%#Eval("Name") %>" />
                            <h2><%#Eval("Name") %></h2>
                            <p><%#Eval("Description") %></p>
                            <span><%#Convert.ToInt32(Eval("Stock"))==0?"STOKTA YOK":"STOKTA VAR" %></span>
                            <span><%#Eval("Brand") %></span>
                            <h3><%#Eval("Price") %> TL</h3>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="SEPETE EKLE"></asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
