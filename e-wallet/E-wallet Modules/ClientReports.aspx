<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="E_wallet.E_wallet_Modules.Reports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    <link rel="stylesheet" href="../Content/index.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="client-left-divs">
                <center>
                    <asp:Image class="e-wallet-logo" runat="server" ImageUrl="~/Images/djpay-logo.png" Width="200px" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="div-menu-logo"><i class="fa-solid fa-chart-column"></i></div><br /><br />
                    <p class="p-client-label-types">
                        Account #:
                               <asp:Label ID="lblAccNum" CssClass="label-texts" runat="server" Text=""></asp:Label><br />
                        Name:
                               <asp:Label ID="lblName" CssClass="label-texts" runat="server" Text=""></asp:Label><br />
                        Date Registered:
                               <asp:Label ID="lblDateRgstrd" CssClass="label-texts" runat="server" Text=""></asp:Label><br />
                        Current Balance:
                               <asp:Label ID="lblCrntBlnce" CssClass="label-texts" runat="server" Text=""></asp:Label><br />
                        Total Sent Money:
                               <asp:Label ID="lblTtlSntMny" CssClass="label-texts" runat="server" Text=""></asp:Label><br />
                        <br />
                    </p>
            </div>
            <div class="client-right-div-reports">
                <br />
                <center>
                    <a class="a-back" href="ClientDashboard.aspx"><i class="fa-solid fa-circle-left"></i></a>
                    <p class="p-client-headers">Show report history</p>

                  <%-- history table for all type of values --%>
                    <asp:Button ID="btnShwHstryNow" CssClass="client-buttons" OnClick="btnShwHstryNow_Click" runat="server" Text="Show history" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
                    <i class="fa-solid fa-clock-rotate-left" style="color: #0D98BA;"></i>&nbsp;  
                    <asp:DropDownList ID="drdTypesOfTrans" Font-Size="Medium" Font-Bold="true" runat="server" CssClass="auto-style271" Width="197px" Height="38px">
                        <asp:ListItem Text="--Select Transaction--" disabled Selected></asp:ListItem>
                        <asp:ListItem Value="All">All</asp:ListItem>
                        <asp:ListItem Value="Deposit & Withdrawals">Deposit & Withdrawals</asp:ListItem>
                        <asp:ListItem Value="Sent & Received">Sent & Received</asp:ListItem>
                        <asp:ListItem Value="Deposit">Deposit</asp:ListItem>
                        <asp:ListItem Value="Withdrawals">Withdrawals</asp:ListItem>
                        <asp:ListItem Value="Sent">Sent</asp:ListItem>
                        <asp:ListItem Value="Received">Received</asp:ListItem>
                    </asp:DropDownList><br />
                    <br />
                    <asp:GridView ID="grdTransHstryAll" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="TRANS_DEPOSIT" HeaderText="Deposit" />
                            <asp:BoundField DataField="TRANS_WITHDRAW" HeaderText="Withdrawals" />
                            <asp:BoundField DataField="TRANS_SENT" HeaderText="Sent" />
                            <asp:BoundField DataField="TRANS_RECEIVER" HeaderText="Account # (Receiver)" />
                            <asp:BoundField DataField="TRANS_RECEIVE" HeaderText="Received" />
                            <asp:BoundField DataField="TRANS_SENDER" HeaderText="Account # (Sender)" />
                            <asp:BoundField DataField="TRANS_DATE" HeaderText="Date" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="grdTransHstryDpstAndWthdrwls" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="TRANS_DEPOSIT" HeaderText="Deposit" />
                            <asp:BoundField DataField="TRANS_WITHDRAW" HeaderText="Withdrawals" />
                            <asp:BoundField DataField="TRANS_DATE" HeaderText="Date" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="grdTransHstrySntAndRcvd" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="TRANS_SENT" HeaderText="Sent" />
                            <asp:BoundField DataField="TRANS_RECEIVER" HeaderText="Account # (Receiver)" />
                            <asp:BoundField DataField="TRANS_RECEIVE" HeaderText="Received" />
                            <asp:BoundField DataField="TRANS_SENDER" HeaderText="Account # (Sender)" />
                            <asp:BoundField DataField="TRANS_DATE" HeaderText="Date" />
                        </Columns>
                    </asp:GridView>
                     <asp:GridView ID="grdTransHstryDpst" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="TRANS_DEPOSIT" HeaderText="Deposit" />
                            <asp:BoundField DataField="TRANS_DATE" HeaderText="Date" />
                        </Columns>
                    </asp:GridView>
                     <asp:GridView ID="grdTransHstryWthdrwls" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="TRANS_WITHDRAW" HeaderText="Witdrawals" />
                            <asp:BoundField DataField="TRANS_DATE" HeaderText="Date" />
                        </Columns>
                     </asp:GridView>
                     <asp:GridView ID="grdTransHstrySnt" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="TRANS_SENT" HeaderText="Sent" />
                             <asp:BoundField DataField="TRANS_RECEIVER" HeaderText="Account # (Receiver)" />
                            <asp:BoundField DataField="TRANS_DATE" HeaderText="Date" />
                        </Columns>
                     </asp:GridView>
                     <asp:GridView ID="grdTransHstryRcvd" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="TRANS_RECEIVE" HeaderText="Received" />
                            <asp:BoundField DataField="TRANS_SENDER" HeaderText="Account # (Sender)" />
                            <asp:BoundField DataField="TRANS_DATE" HeaderText="Date" />
                        </Columns>
                     </asp:GridView>
                </center>
            </div>
        </div>
    </form>
</body>
</html>
