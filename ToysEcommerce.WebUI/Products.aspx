<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ToysEcommerce.WebUI.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; background-color: #eee">
        <h1 id="h1Baslik" runat="server">TÜM ÜRÜNLER</h1>
        <h3><%=Session["indirim"]%></h3> 

  <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>
          <br/>
          <br/>          
          <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
          <br/>
          <br/>
          <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label><asp:TextBox ID="txtDescripton" runat="server"></asp:TextBox>
          <br/>
          <br/>
          <asp:Label ID="Label4" runat="server" Text="Stock"></asp:Label><asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
          <br/>
          <br/>
          <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
          <br/>
          <br/>
          <asp:Label ID="Label5" runat="server" Text="BrandId"></asp:Label><asp:TextBox ID="txtBrandId" runat="server"></asp:TextBox>
          <br/>
          <br/>
          <asp:Label ID="Label6" runat="server" Text="picture"></asp:Label><asp:TextBox ID="txtPicture" runat="server"></asp:TextBox>
          <br/>
          <br/>
          <asp:Button ID="ButtonEkle" runat="server" Text="EKLE" OnClick="ButtonEkle_Click" />--%>


        <%--2.YOL--%>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <%--  <asp:BoundField DataField="Name" HeaderText="ÜRÜN ADI" />--%>
                <asp:TemplateField HeaderText="Ürün Adı">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" Text='<%#Eval("Name")%>' CommandArgument='<%#Eval("ID")%>' OnClick="LinkButtonEdit_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ürün Fiyatı">
                    <ItemTemplate>
                        <span><%#Eval("Price")%> TL</span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ürün Resmi">
                    <ItemTemplate>
                        <img src="<%#Eval("Picture")%>" alt="<%#Eval("Name")%>" style="height: 60px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marka Adı">
                    <ItemTemplate>
                        <span><%#Eval("Marka")%></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stok Bilgisi">
                    <ItemTemplate>
                        <span><%#Eval("StokBilgi")%></span>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kategorileri">
                    <ItemTemplate>
                        <span><%#Eval("Kategorileri")%></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="ButtonSil" runat="server" CommandArgument='<%#Eval("ID")%>' Text="Sil" OnClick="ButtonSil_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label><asp:TextBox ID="txtName" runat="server" CssClass="txtName"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label><asp:TextBox ID="txtDescripton" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Stock"></asp:Label><asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Brand"></asp:Label><asp:DropDownList ID="DropDownListBrand" runat="server" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
        <br />
        <span>Kategorileri:</span><asp:CheckBoxList ID="CheckBoxListKategori" runat="server" DataTextField="Name" DataValueField="ID"></asp:CheckBoxList>
        <br />
        <img id="imgUrun" runat="server" />
        <asp:Label ID="Label6" runat="server" Text="picture"></asp:Label><input type="file" id="fileUploadDosya" runat="server" />
        <br />
        <br />
        <asp:Button ID="ButtonEkle" runat="server" Text="EKLE" OnClick="ButtonEkle_Click" />
        <asp:Button ID="ButtonGuncelle" runat="server" Text="Güncelle" OnClick="ButtonGuncelle_Click" />
        <asp:Button ID="Button1" runat="server" Text="İletişime Git" OnClick="Button1_Click" />
        <asp:Label ID="LabelUrunID" runat="server"></asp:Label>
        <asp:Label ID="LabelCatID" runat="server"></asp:Label>

    </div>
</asp:Content>
