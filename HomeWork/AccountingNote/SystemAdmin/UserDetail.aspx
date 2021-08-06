<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserDetail" %>

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
                        <asp:TextBox ID="txtAccount" runat="server" ></asp:TextBox>
                    <br />
                    名字: 
                        <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                    <br />
                    密碼: 
                        <asp:TextBox ID="txtPWD" runat="server" ></asp:TextBox>
                    <br />
                    Email:
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    <br />
                    會員等級:
                        <asp:DropDownList ID="ddlActType" runat="server" >
                            <asp:ListItem Value="0" Enabled="false">管理者</asp:ListItem>
                            <asp:ListItem Value="1">一般會員</asp:ListItem>
                        </asp:DropDownList>
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="儲存"  OnClick="btnSave_Click" />
                    &nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click"/>
                    &nbsp;
                    <asp:Button ID="btnChangePWD" runat="server" Text="變更密碼" OnClick="btnChangePWD_Click"/>
                    <br />
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
