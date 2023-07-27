<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Application.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            max-width: 400px;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        h2 {
            font-size: 20px;
            margin-bottom: 20px;
            color: crimson;
            text-align: center;
        }

        label {
            font-weight: bold;
            font-size: 12px;
        }

        .text-input,
        .password-input {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        input[type="submit"] {
            margin: 20px auto 0;
            width: 100%;
            padding: 10px 20px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

            input[type="submit"]:hover {
                background-color: #45a049;
            }

        p {
            text-align: center;
            margin-top: 20px;
        }

        #btnLogin {
            display: block;
            margin: 0 auto;
            width: 100%;
            background-color: #007BFF;
        }

        #btnRegister {
            background-color: #007BFF;
        }

        .error-message {
            color: red;
            font-size: 14px;
            text-align: center;
        }

        .hyper-link {
            font-size: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Login Here,</h2>

            <label for="txtUsername">UserName</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="text-input" />
            <br />
            <br />

            <label for="txtPassword">Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="password-input" TextMode="Password" />
            <br />
            <br />
            <asp:HyperLink ID="lnkForgotPassword" runat="server" CssClass="hyper-link" Text="Forgot Password?" NavigateUrl="ForgotPassword.aspx"></asp:HyperLink>

            <asp:Label ID="lblMessage" runat="server" CssClass="error-message" Visible="false" />

            <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <p>-(or)-</p>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegisterPage_Click" />

        </div>
    </form>
</body>
</html>
