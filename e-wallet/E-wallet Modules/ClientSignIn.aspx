    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientSignIn.aspx.cs" Inherits="E_wallet.E_wallet_Modules.UserSignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" id="htmlSignIn">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
        <link rel="stylesheet" href="../Content/index.css" />   
</head>
<body>
    <form id="form1" runat="server">
       <div> 
           <div class="client-left-divs">
               <center><asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/djpay-logo.png" Width="200px"/> <br /> <br /> <br />
               <h1 class="h1-client-headers">New Here <i class="fa-solid fa-question fa-bounce "></i></h1><br /> 
               <h3 class="h3-client-notes">Join now and revolutionize your financial transactions with an advanced e-wallet platform. 
                   Experience effortless money transfers. Sign up today! <br /> <br />
              </h3>       
              <asp:Button ID="btnSignUp" CssClass="client-buttons" OnClick="btnSignUp_Click" runat="server" Text="Sign Up" Height="53px" Width="170px"/>    
              </center>
           </div>
           <div class="client-right-divs"><br /><br /><br /><br /><br />
            <center>
                   <p class="p-client-headers">Login to Your Account</p><br />   
                  <i class="fas fa-user fa-xl" style="color: #0D98BA;"></i>
                  <asp:TextBox ID="txtUsrnme" placeholder="Username" Font-Size="Medium" runat="server" Width="250px" Height="30px"></asp:TextBox><br /><br />
                   <i class="fas fa-lock fa-xl" style="color: #0D98BA;"></i>
                  <asp:TextBox ID="txtPassword" placeholder="Password" Font-Size="Medium" TextMode="Password" runat="server" Width="250px" Height="30px"></asp:TextBox><br /><br /><br />        
                  <asp:Button ID="btnSignIn" CssClass="client-buttons" OnClick="btnSignIn_Click" runat="server" Text="Sign In" Height="53px" Width="170px" /><br /><br /><br />      
            </center>                 
           </div>         
       </div>
    </form>
</body>
</html>
    