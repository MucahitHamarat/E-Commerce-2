<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToysEcommerce.WebUI.admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hoşgeldiniz Sayın: <%=Session["AdSoyad"] %></h1>
            <asp:Button ID="ButtonCik" runat="server" Text="Çıkış" OnClick="ButtonCik_Click"/>
        </div>
    </form>
</body>
</html>
