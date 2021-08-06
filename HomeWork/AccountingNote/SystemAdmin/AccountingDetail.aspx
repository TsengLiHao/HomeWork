<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingDetail" %>

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
                    <h3>收支管理</h3>
                    <!--這裡放主要內容-->
                    In/Out: 
                        <asp:DropDownList ID="ddlActType" runat="server">
                            <asp:ListItem Value="0">支出</asp:ListItem>
                            <asp:ListItem Value="1">收入</asp:ListItem>
                        </asp:DropDownList>
                    <br />
                    金額: 
                        <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox>
                    <br />
                    標題: 
                        <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
                    <br />
                    備註:
                        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
                    &nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click"/>
                    <br />
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
