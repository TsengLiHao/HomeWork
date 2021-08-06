<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccountingNote.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>起司訂購管理系統</h1>
            初次記帳:
            <asp:Literal ID="ltFirsttime" runat="server"></asp:Literal><br />
            最後記帳:
            <asp:Literal ID="ltLasttime" runat="server"></asp:Literal><br />
            記帳數量:
            <asp:Literal ID="ltValueOfExpense" runat="server"></asp:Literal><br />
            會員數:
            <asp:Literal ID="ltValueOfMember" runat="server"></asp:Literal><br />
            系統描述:
            <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
        </div>
    </form>
</body>
</html>
