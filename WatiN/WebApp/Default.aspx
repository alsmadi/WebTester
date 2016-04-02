<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WatiN Test Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>
            Check if a nickname is already used</h2>
        <table>
            <tr>
                <td>
                    Nickname:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtNickName" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button runat="server" ID="btnCheck" Text="Check !!" OnClick="btnCheck_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblResult" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
