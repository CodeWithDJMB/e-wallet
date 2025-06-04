<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDeposit.aspx.cs" Inherits="E_wallet.E_wallet_Modules.Deposit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    <link rel="stylesheet" href="../Content/index.css" />
    <style type="text/css">
        .auto-style272 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="client-left-divs">
                <center>
                    <asp:Image class="e-wallet-logo" runat="server" ImageUrl="~/Images/djpay-logo.png"  />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="div-menu-logo"><i class="fa-solid fa-money-bills"></i> +</div><br /><br />
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
                    <p class="p-client-headers">Deposit your money</p><br /><br /><br />                 
                    <div class="div-transaction-fields">
                        ₱&nbsp
                            <asp:TextBox ID="txtDpstMoney" CssClass="transaction-textboxes" Font-Size="23" Font-Bold="true" AutoPostBack="true" OnTextChanged="txtDpstMoney_TextChanged" placeholder="Enter Amount" runat="server" Width="260px" Height="61px" ></asp:TextBox><br /><br /><br />
                        <asp:Label ID="lbldpstAmntInvalid" CssClass="label-invalid-transaction-amounts" runat="server" Text=""></asp:Label><br />       
                    </div><br /><br />                                                  
                    <asp:Button ID="btnDpstMny" CssClass="client-buttons" OnClick="btnDpstMny_Click" runat="server" Text="Deposit" Height="53px" Width="170px"/><br /><br /><br />
                </center>
            </div>
        </div>
    </form>
</body>
</html>
