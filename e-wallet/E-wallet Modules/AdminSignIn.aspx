<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSignIn.aspx.cs" Inherits="E_wallet.E_wallet_Modules.AdminSignIn" %>

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
               <center><asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/djpay-logo.png" Width="200px"/> <br /> <br /> <br />
               <h1 class="h1-admin-headers">Welcome to the Admin Page!</h1><br /> 
               <h3 class="h3-admin-notes">This page serves as the central hub for managing user accounts and maintaining control over various administrative tasks. 
                   As an administrator, you have the power to oversee and regulate account-related activities within the system.<br /> <br />
              </h3>       
              </center>
           </div>
           <div class="admin-right-divs"><br /><br /><br /><br /><br />
            <center>
                   <p class="p-admin-headers">Login to Your Account</p><br />   
                   <i class="fa-solid fa-user-secret fa-xl" style="color: #0D98BA;"></i>
                  <asp:TextBox ID="txtUser" placeholder="Username" Font-Size="Medium" runat="server" Width="250px" Height="30px"></asp:TextBox><br /><br />
                   <i class="fa-solid fa-key fa-xl" style="color: #0D98BA;"></i>
                  <asp:TextBox ID="txtPassword" placeholder="Password" Font-Size="Medium" TextMode="Password" runat="server" Width="250px" Height="30px"></asp:TextBox><br /><br /><br />        
                  <asp:Button ID="btnSignIn" CssClass="admin-buttons" OnClick="btnSignIn_Click" runat="server" Text="Sign In" Height="53px" Width="170px"/><br /><br /><br />      
            </center>                      
           </div>         
       </div>
    </form>
</body>
</html>
