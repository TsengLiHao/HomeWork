<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPassword.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserPassword" %>

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
                    <h3>會員管理</h3>
                    <!--這裡放主要內容-->
                    帳號: 
                        <asp:Literal ID="ltAccount" runat="server" ></asp:Literal>
                    <br />
                    原密碼: 
                        <asp:TextBox ID="txtPWD" runat="server" ></asp:TextBox>
                    <br />
                    確認密碼: 
                        <asp:TextBox ID="txtCheckPWD" runat="server" ></asp:TextBox>
                    <br />
                    新密碼:
                        <asp:TextBox ID="txtNewPWD" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnChangePWD" runat="server" Text="變更密碼" OnClick="btnChangePWD_Click1"/>
                    <br />
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
