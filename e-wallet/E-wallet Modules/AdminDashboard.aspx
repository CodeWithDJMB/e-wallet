<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="E_wallet.E_wallet_Modules.AdminDashboard" %>

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
            <div class="admin-left-divs">
                <center>      
                    <ul class="ul-settings"><li><a><i class="fa-sharp fa-solid fa-bars fa-xl"></i></a>
                        <ul class="ul-button-settings-menu">                                      
                            <li>
                                <asp:Button ID="btnAdminUpdtPrf" OnClick="btnUpdtPrf_Click" runat="server" Text="Update Profile Picture" CssClass="menu-buttons" /></li>
                            <li>
                                <asp:Button ID="btnAdminChngPswrd" OnClick="btnChngPswrd_Click" runat="server" Text="Change Password" CssClass="menu-buttons" /></li>
                            <li>
                                <asp:Button ID="btnAdminSignOut" OnClick="btnSignOut_Click" runat="server" Text="Sign Out" CssClass="menu-buttons"  /></li>   
                        </ul>
                    </li></ul>
                    <br /><br /><br />
                    <div class="div-view-profile picture">
                        <div id="dfltProfPic" runat="server" class="div-admin-default-profile-picture"><i class="fa-sharp fa-solid fa-user-secret"></i></div>
                        <asp:Image ID="updtdProfPic" CssClass="image-admin-updated-profile-picture" runat="server" />
                    </div><br />                               
                    <h1 class="h1-admin-headers">Welcome Master   <i class="fa-solid fa-exclamation fa-beat"></i></h1>
                    <br />  
                 </center> 
                        <br /><br /><br />
                            <p class="p-admin-label-types">
                                Account #:
                               <asp:Label ID="lblAccNum" CssClass="label-texts" runat="server" Text=""></asp:Label><br />
                               Name:
                               <asp:Label ID="lblName" CssClass="label-texts" runat="server" Text=""></asp:Label><br />
                               Date Registered:
                               <asp:Label ID="lblDateRgstrd" CssClass="label-texts" runat="server" Text=""></asp:Label><br />
                            </p>                       
            </div>
            <div class="admin-right-divs">
                <center>
                    <br />
                    <p class="p-admin-headers">Dashboard</p><br />
                    <a href="AdminViewRecords.aspx">
                        <div class="div-admin-menus">
                           <i class="fa-solid fa-clipboard-list fa-xl"></i>     
                            <br />
                            <p class="p-menus-name">View Records</p>
                        </div>
                    </a>
                   <a href="AdminSuspendAccount.aspx">
                        <div class="div-admin-menus">
                            <i class="fa-solid fa-user-slash fa-xl"></i>
                            <br />
                            <p class="p-menus-name">Suspend Account</p>
                        </div>
                    </a>
                    <a id="aAddAdmin" runat="server" href="AdminSignUp.aspx">
                        <div class="div-admin-menus">
                            <i class="fa-solid fa-user-secret fa-xl"></i>+                      
                            <br />
                            <p class="p-menus-name">Add Admin</p>
                        </div>
                    </a>
                </center>
            </div>  
          </div>  
    </form>
</body>
</html>
