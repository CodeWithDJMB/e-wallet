<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientConfirmWithdraw.aspx.cs" Inherits="E_wallet.E_wallet_Modules.ConfirmWithdraw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    <link rel="stylesheet" href="../Content/index.css" />
</head>
<body class="body-client-confirmation-background">
    <form id="form1" runat="server">
        <center>
            <div class="div-client-confirmation-background">
                <br />
                <br />
                <asp:Label ID="lblCnfrmWthdrwMnyPrmptMssge" Font-Size="X-Large" runat="server" Text="Are you sure you want<br/> to continue?"></asp:Label><br />                
                <br />
                <br />
                <asp:Label ID="lblCnfrmWthdrwMnySucss" CssClass="label-success-transactions" Font-Size="X-Large" runat="server"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="btnYesBfrWthdrw" CssClass="client-buttons" OnClick="btnYesBfrWthdrw_Click" Font-Size="Larger" runat="server" Text="Yes" Width="120px" Height="60" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNoBfrWthdrw" CssClass="client-buttons" OnClick="btnNoBfrWthdrw_Click"  Font-Size="Larger" runat="server" Text="No" Width="120px" Height="60" /><br /><br />
                <asp:Button ID="btnBckBfrWthdrwng" CssClass="client-buttons" OnClick="btnBckBfrWthdrw_Click" Font-Size="Larger" runat="server" Text="Back" Width="120px" Height="60" />
            </div>
        </center>
    </form>
</body>
</html>
