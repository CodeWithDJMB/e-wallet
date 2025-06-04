<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminViewRecords.aspx.cs" Inherits="E_wallet.E_wallet_Modules.AdminViewRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    <link rel="stylesheet" href="../Content/index.css" />
    <style type="text/css">
        .auto-style1 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="div-view-records">
                <br />
                <center>
                    <a class="a-back" href="AdminDashboard.aspx"><i class="fa-solid fa-circle-left"></i></a>
                    <p class="p-admin-headers">Show Data</p>
                    <%-- history table for all type of values --%>
                    <asp:Button ID="btnShowDataNow" OnClick="btnShowDataNow_Click" CssClass="buttons-show-record" runat="server" Text="Show table data" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
                    &nbsp;  
                    <asp:DropDownList ID="drdTypesOfEntity" Font-Size="Medium" Font-Bold="true" runat="server" CssClass="input-table-and-id">
                        <asp:ListItem Text="--Select Table--" disabled Selected></asp:ListItem>
                        <asp:ListItem Value="Admins">Admins</asp:ListItem>
                        <asp:ListItem Value="Clients">Clients</asp:ListItem>
                        <asp:ListItem Value="Transactions">Transactions</asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="btnShowSpcfcRcrd" OnClick="btnShowSpcfcRcrd_Click" CssClass="buttons-show-record" runat="server" Text="Show record" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtId" placeholder="Enter ID(PK) for the selected table" CssClass="input-table-and-id" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <br />

                    <asp:GridView ID="grdAdminData" CssClass="grid-view-data-tables" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="ADMIN_ID" HeaderText="(PK) Account #" />
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%# Eval("ADMIN_FNAME") + " " + Eval("ADMIN_MIDINTL") + ". " + Eval("ADMIN_LNAME") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ADMIN_USRNME" HeaderText="Username" />
                            <asp:BoundField DataField="ADMIN_EMLADRS" HeaderText="Email Address" />
                            <asp:BoundField DataField="ADMIN_PHNO" HeaderText="Phone #" />
                            <asp:BoundField DataField="ADMIN_ADRS" HeaderText="Address" />
                            <asp:BoundField DataField="ADMIN_GENDER" HeaderText="Gender" />
                            <asp:TemplateField HeaderText="Date Registered">
                                <ItemTemplate>
                                    <%# Convert.ToDateTime(Eval("ADMIN_DATE_RGSTRD")).ToString("MM/dd/yyyy") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="grdClientData" CssClass="grid-view-data-tables" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="CLIENT_ID" HeaderText="(PK) Account #" />
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%# Eval("CLIENT_FNAME") + " " + Eval("CLIENT_MIDINTL") + ". " + Eval("CLIENT_LNAME") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CLIENT_USRNME" HeaderText="Username" />
                            <asp:BoundField DataField="CLIENT_EMLADRS" HeaderText="Email Address" />
                            <asp:BoundField DataField="CLIENT_PHNUM" HeaderText="Phone #" />
                            <asp:BoundField DataField="CLIENT_ADRS" HeaderText="Address" />
                            <asp:BoundField DataField="CLIENT_GENDER" HeaderText="Gender" />
                            <asp:BoundField DataField="CLIENT_BALANCE" HeaderText="Balance" />
                            <asp:TemplateField HeaderText="Date Registered">
                                <ItemTemplate>
                                    <%# Convert.ToDateTime(Eval("CLIENT_DATE_RGSTRD")).ToString("MM/dd/yyyy") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CLIENT_STATUS" HeaderText="Account Status" />

                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="grdTransactionData" CssClass="grid-view-data-tables" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="TRANS_ID" HeaderText="(PK) Transaction #" />
                            <asp:BoundField DataField="TRANS_DEPOSIT" HeaderText="Deposit" />
                            <asp:BoundField DataField="TRANS_WITHDRAW" HeaderText="Withdrawals" />
                            <asp:BoundField DataField="TRANS_SENT" HeaderText="Sent" />
                            <asp:BoundField DataField="TRANS_RECEIVE" HeaderText="Received" />

                            <asp:TemplateField HeaderText="Transaction Date">
                                <ItemTemplate>
                                    <%# Convert.ToDateTime(Eval("TRANS_DATE")).ToString("MM/dd/yyyy") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CLIENT_ID" HeaderText="Account #" />
                        </Columns>
                    </asp:GridView>
                </center>
            </div>
        </div>
    </form>
</body>
</html>
