<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminConfirmSuspend.aspx.cs" Inherits="E_wallet.E_wallet_Modules.ConfirmSuspension" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    <link rel="stylesheet" href="../Content/index.css" />
</head>
<body class="body-suspend-account">
    <form id="form1" runat="server">
        <center>
            <div class="div-prompt-confirmation">
                <br />
                <br />
                <asp:Label ID="lblCnfrmSspndAccPrmptMssge" Font-Size="X-Large" runat="server" Text="Are you sure you want<br/> to continue?"></asp:Label><br />                
                <br />
                <br />
                <asp:Label ID="lblCnfrmSspndAccSucss" Font-Size="X-Large" runat="server"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="btnYesBfrSspnd" CssClass="admin-buttons" OnClick="btnYesBfrSspnd_Click" Font-Size="Larger" runat="server" Text="Yes" Width="120px" Height="60" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNoBfrSspnd" CssClass="admin-buttons" OnClick="btnNoBfrSspnd_Click" Font-Size="Larger" runat="server" Text="No" Width="120px" Height="60" /><br /><br />
                <asp:Button ID="btnBckBfrSspnd" CssClass="admin-buttons" OnClick="btnBckBfrSspnd_Click"  Font-Size="Larger" runat="server" Text="Back" Width="120px" Height="60" />
            </div>
        </center>
    </form>
</body>
</html>
