<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientChangePassword.aspx.cs" Inherits="E_wallet.E_wallet_Modules.UserChangePassword" %>

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
               <center><asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/djpay-logo.png" Width="200px"/> <br /> <br /> <br />
               <h1 class="h1-client-headers">Please complete the required fields.</h1><br />
               <h3 class="h3-client-notes">Once you have finished changing your password, simply click the "Finish" button.<br /> <br /> <br /> 
              </h3>       
              <asp:Button ID="btnChangePswrdFinish" CssClass="client-buttons" OnClick="btnChangePswrdFinish_Click" runat="server" Text="Finish" Height="53px" Width="170px"/>   
              &nbsp;&nbsp;&nbsp;&nbsp;   
              <asp:Button ID="btnChangePswrdBack" CssClass="client-buttons" runat="server" OnClick="btnChangePswrdBack_Click" Text="Back" Height="53px" Width="170px"/>  
              </center>
           </div>
               <div class="client-right-divs"><br />
                <center>            
                    <p class="p-client-headers">Change your password</p><br /><br />
                    Account Number:&nbsp;&nbsp;
                   <asp:TextBox ID="txtAccNum" MaxLength="70" runat="server" Width="400px" Height="25px" CssClass="auto-style272"></asp:TextBox><br />
                    <br />
                    Username:&nbsp;&nbsp;
                   <asp:TextBox ID="txtUsrnm" MaxLength="70" runat="server" Width="451px" Height="25px" CssClass="auto-style272"></asp:TextBox><br /><br />       
                    Current Password:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCrntPswrd" MaxLength="70" TextMode="Password" runat="server" Width="393px" Height="25px" ></asp:TextBox><br /><br />       
                    New Password:&nbsp;&nbsp;
                   <asp:TextBox ID="txtNewPswrd" MaxLength="70" TextMode="Password" runat="server" Width="419px" Height="25px" ></asp:TextBox><br /><br />        
                    Confirm New Password:&nbsp;&nbsp;
                   <asp:TextBox ID="txtNewPswrdCnfrm" MaxLength="70" TextMode="Password" runat="server" Width="355px" Height="25px" ></asp:TextBox><br />         
                   <br />
              </center>
               </div>        
           </div>         
    </form>
</body>
</html>
