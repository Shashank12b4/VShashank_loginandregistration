<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginform.aspx.cs" Inherits="WebApplication1.loginform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: right;
            width: 423px;
        }
        .auto-style3 {
            text-align: right;
            width: 423px;
            height: 32px;
        }
        .auto-style4 {
            height: 32px;
        }
        .auto-style5 {
            height: 32px;
            width: 271px;
        }
        .auto-style6 {
            width: 271px;
        }
        .auto-style7 {
            margin-left: 523px;
            margin-top: 34px;
            margin-bottom: 54px;
        }
        .auto-style8 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Username:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxUser" runat="server" Width="260px"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUser" CssClass="auto-style8" ErrorMessage="username is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password" Width="260px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPass" CssClass="auto-style8" ErrorMessage="password is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:Button ID="ButtonSignIn" runat="server" CssClass="auto-style7" OnClick="Button1_Click" Text="Sign In" />
    </form>
</body>
</html>
