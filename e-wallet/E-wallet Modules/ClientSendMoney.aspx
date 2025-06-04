<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientSendMoney.aspx.cs" Inherits="E_wallet.E_wallet_Modules.SendMoney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    <link rel="stylesheet" href="../Content/index.css" />
    <style type="text/css">
        .auto-style272 {
        }
    </style>
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
                    <div class="div-menu-logo"><i class="fa-solid fa-money-bill-transfer"></i></div>
                    <br />
                    <br />
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
            <div class="client-right-divs">
                <br />
                <center>
                    <a class="a-back" href="ClientDashboard.aspx"><i class="fa-solid fa-circle-left"></i></a>
                    <p class="p-client-headers">Send a money</p>
                    <asp:Button ID="btnSrchRcpnt" CssClass="client-buttons" OnClick="btnSrchRcpnt_Click" runat="server" Text="Search Now" />&nbsp;&nbsp;&nbsp;&nbsp;  
                         <i class="fa-solid fa-hashtag" style="color: #0D98BA;"></i>
                    <asp:TextBox ID="txtRcpntAccNmbr" CssClass="recipient-textbox" placeholder="Enter Recipient's Account Number" Font-Size="10" Font-Bold="true" runat="server" Width="223px" Height="31px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:GridView ID="grdRcpntRcrds" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="CLIENT_ID" HeaderText="Account #" />
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%# Eval("CLIENT_FNAME") + " " + Eval("CLIENT_MIDINTL") + ". " + Eval("CLIENT_LNAME") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblInvldRcpnt" CssClass="label-invalid-recipient-inputs" runat="server" Text=""></asp:Label><br />

                    <br />
                    <div class="div-transaction-fields">
                        ₱&nbsp
                            <asp:TextBox ID="txtSndMoney" CssClass="transaction-textboxes" Font-Size="23" Font-Bold="true" AutoPostBack="true" OnTextChanged="txtSndMoney_TextChanged" placeholder="Enter amount" runat="server" Width="260px" Height="61px"></asp:TextBox><br />
                        <br />
                        <asp:Label ID="lblSndAmntInvalid" CssClass="label-invalid-transaction-amounts" runat="server" Text=""></asp:Label><br />
                        <br />
                    </div>
                    <br />
                    <br />
                    <asp:Button ID="btnSndMny" CssClass="client-buttons" OnClick="btnSndMny_Click" runat="server" Text="Send" Height="53px" Width="170px" /><br />
                    <br />
                    <br />
                </center>
            </div>
        </div>
    </form>
</body>
</html>
