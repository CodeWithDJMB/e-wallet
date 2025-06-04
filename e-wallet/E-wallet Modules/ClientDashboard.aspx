<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientDashboard.aspx.cs" Inherits="E_wallet.E_wallet_Modules.Dashboard" %>

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
                   <ul class="ul-settings"><li><a><i class="fa-sharp fa-solid fa-bars fa-xl"></i></a>
                        <ul class="ul-button-settings-menu">                                      
                            <li>
                                <asp:Button ID="btnClientUpdtPrfPic" OnClick="btnClientUpdtPrfPic_Click" runat="server" Text="Update Profile Picture" CssClass="menu-buttons" /></li>
                            <li>
                                <asp:Button ID="btnClientChngPswrd" OnClick="btnClientChngPswrd_Click" runat="server" Text="Change Password" CssClass="menu-buttons" /></li>
                            <li>
                                <asp:Button ID="btnClientDeactAcc" OnClick="btnClientDeactAcc_Click" runat="server" Text="Deactivate Account" CssClass="menu-buttons"  /></li>  
                            <li>
                                <asp:Button ID="btnClientSignOut" OnClick="btnClientSignOut_Click" runat="server" Text="Sign Out" CssClass="menu-buttons"  /></li>   
                        </ul>
                    </li></ul>
                    <br /><br />
                    <div class="div-client-view-profile-picture" runat="server">
                        <div id="dfltProfPic" class="div-client-default-profile-picture" runat="server"><i class="fa-solid fa-circle-user"></i></div>
                        <asp:Image ID="updtdProfPic" CssClass="image-client-updated-profile-picture" runat="server" />
                    </div>                    
                    <h1 class="h1-client-headers">Welcome   <i class="fa-solid fa-exclamation fa-beat"></i></h1>
                    <br /><br /><br />
                 </center> 
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
                               <asp:Label ID="lblTtlSntMny" CssClass="label-texts" runat="server" Text=""></asp:Label><br /><br />
                         </p>
            </div>
            <div class="client-right-divs">
                <center>
                    <br />
                    <p class="p-client-headers">Dashboard</p><br />
                    <a href="ClientDeposit.aspx">
                        <div class="div-client-menus">
                    <i class="fa-solid fa-money-bills"></i> +
                            <br />
                            <p class="p-menus-name">Deposit</p>
                        </div>
                    </a>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="ClientWithdraw.aspx">
                        <div class="div-client-menus">
                            <i class="fa-solid fa-money-bills"></i> -
                            <br />
                            <p class="p-menus-name">Withdraw</p>
                        </div>
                    </a>
                    <br />
                    <br />
                    <br />
                    <br />
                    <a href="ClientSendMoney.aspx">
                        <div class="div-client-menus">
                            <i class="fa-solid fa-money-bill-transfer"></i>
                            <br />
                            <p class="p-menus-name">Send Money</p>
                        </div>
                    </a>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="ClientReports.aspx">
                        <div class="div-client-menus">
                        <i class="fa-solid fa-chart-column"></i>
                            <br />
                            <p class="p-menus-name">Reports</p>
                        </div>
                    </a>
                </center>
            </div>  
          </div>  
    </form>
</body>
</html>
