<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Application.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MainPage</title>
    <%--CSS from the MainPage.aspx page--%>
    <style>
        .hyper-link {
            position: absolute;
            right: 10px;
            font-size: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--HTML from the MainPage.aspx page--%>
        <div>
            <asp:HyperLink ID="lnkLogout" runat="server" CssClass="hyper-link" Text="Logout" NavigateUrl="Login.aspx"/>
        </div>
    </form>
</body>
</html>
