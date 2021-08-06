<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <table>
            <tr>
                <td colspan="2">
                    <h1>起司訂購管理系統 - 後台</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="UserInfo.aspx">個人資訊</a><br />
                    <a href="UserList.aspx"> 會員管理 </a><br />
                    <a href="AccountingList.aspx"> 收支管理 </a>
                </td>
                <td>
                    <!--這裡放主要內容-->
                    <h3>會員管理</h3>
                    <table border="1">
                        <tr>
                            <th>帳號</th>
                            <td><asp:Literal runat="server" ID="ltAccount"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>名字</th>
                            <td><asp:Literal runat="server" ID="ltName"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>Email</th>
                            <td><asp:Literal runat="server" ID="ltEmail"></asp:Literal></td>
                        </tr>
                    </table><br />
                    <asp:Button runat="server" ID="btnLogout" Text="登出" OnClick="btnLogout_Click"/>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
