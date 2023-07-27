<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationSuccess.aspx.cs" Inherits="Application.RegistrationSuccess" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Success</title>
    <style>
        /* CSS styles from the RegistrationSuccess.aspx page */
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--HTML from the RegistrationSuccess.aspx page--%>  
        <div class="container">
            <h2>User Registered Successfully!</h2>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegisterPage_Click" />
            <br />
            <p>-(or)-</p>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnloginPage_Click" />
        </div>
    </form>
</body>
</html>
