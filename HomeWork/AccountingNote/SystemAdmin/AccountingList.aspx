<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>

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
                    <asp:Button ID="btnCreate" runat="server" Text="新增帳單" OnClick="btnCreate_Click"/>
                    &nbsp
                    <asp:Literal ID="ltTotal" runat="server"></asp:Literal>

                    <asp:GridView ID="gvAccountingList" runat="server" AutoGenerateColumns="False"  OnRowDataBound="gvAccountingList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="標題" DataField="Caption" />
                            <asp:BoundField HeaderText="金額" DataField="Amount" />
                            <asp:TemplateField HeaderText="In/Out">
                                <ItemTemplate>
                                    <%--<%# ((int)Eval("ActType") == 0) ? "支出" : "收入" %>--%>
                                    <%--<asp:Literal runat="server" ID="ltActType"></asp:Literal>--%>
                                    <asp:Label runat="server" ID="lblActType"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:TemplateField HeaderText="編輯">
                                <ItemTemplate>
                                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>

                    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color: red">
                            No data in your Accounting Note.
                        </p>
                    </asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
