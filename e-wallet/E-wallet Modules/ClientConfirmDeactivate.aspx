<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientConfirmDeactivate.aspx.cs" Inherits="E_wallet.E_wallet_Modules.Deactivate" %>

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
                <asp:Label  ID="lblCnfrmDeactAccPrmptMssge" Font-Size="X-Large" runat="server" Text=""></asp:Label>
                  <br /><br /><br />
               <asp:Label ID="lblCnfrmDeactAccSucss" CssClass="label-success-deactivate" Font-Size="X-Large" runat="server" ><i class="fa-solid fa-lock" style="color:#35D6ED;"></i></asp:Label>
                 
                <asp:TextBox ID="txtInptPswrdBfrDeact" TextMode="Password" Font-Size="Larger" runat="server" Height="31px" Width="295px"></asp:TextBox>
                  <br />
                <br />
                <asp:Label ID="lblInvldInptPswrdBfrDeact" CssClass="label-invalid-input-password" Font-Size="Large" ForeColor="Red" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <br />
                <asp:Button ID="btnSbmtInptPswrdBfrDeact" CssClass="client-buttons" OnClick="btnSbmtInptPswrdBfrDeact_Click"  Font-Size="Larger" runat="server" Text="Submit" Width="120px" Height="60" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCnclInptPswrdBfrDeact" CssClass="client-buttons" OnClick="btnCnclInptPswrdBfrDeact_Click"   Font-Size="Larger" runat="server" Text="Cancel" Width="120px" Height="60" />
                <br />
                <asp:Button ID="btnBckInptPswrdAftrDeact" CssClass="client-buttons" OnClick="btnBckInptPswrdAftrDeact_Click"   Font-Size="Larger" runat="server" Text="Back" Width="120px" Height="60" />
                <br />
                <br />
            </div>    
                </center>   
    </form>
</body>
</html>
