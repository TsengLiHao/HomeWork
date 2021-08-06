<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserList" %>

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
                    <asp:Button ID="btnCreate" runat="server" Text="新增會員" OnClick="btnCreate_Click1"/>
                    <asp:GridView ID="gvUserInfoList" runat="server" AutoGenerateColumns="False" onrowta CellPadding="4" ForeColor="#333333" GridLines="None"  >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="使用者" DataField="Name" />
                            <asp:BoundField HeaderText="帳號" DataField="Account" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                            <asp:TemplateField HeaderText="等級">
                                <ItemTemplate>
                                    <%# ((int)Eval("UserLevel") == 0) ? "管理者" : "一般會員" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:TemplateField HeaderText="Act">
                                <ItemTemplate>
                                    <a href="/SystemAdmin/UserDetail.aspx?UID=<%# Eval("UID") %>">Edit</a>
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
                        <p>
                            No User.
                        </p>
                    </asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
