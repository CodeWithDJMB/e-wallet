<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientUpdateProfilePicture.aspx.cs" Inherits="E_wallet.E_wallet_Modules.UpdateProfilePicture" %>

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
               <center><asp:Image class="e-wallet-logo" runat="server" ImageUrl="~/Images/djpay-logo.png" Width="200px"/> <br /><br /><br />
               <h1 class="h1-client-headers">Please complete the required fields.</h1><br />
               <h3 class="h3-client-notes">Once you have finished updating your profile picture, simply click the "Finish" button.<br /><br />
              </h3>       
              <asp:Button ID="btnUpdtPrflFinish" CssClass="client-buttons" OnClick="btnUpdtPrflFinish_Click" runat="server" Text="Finish" Height="53px" Width="170px"/>   
              &nbsp;&nbsp;&nbsp;&nbsp;   
              <asp:Button ID="btnUpdtPfrlBack" CssClass="client-buttons" OnClick="btnUpdtPfrlBack_Click" runat="server" Text="Back" Height="53px" Width="170px"/>  
              </center>
           </div>
               <div class="client-right-divs"><br />
                <center>            
                    <p class="p-client-headers">Update your profile picture</p><br /><br />          
                    <asp:FileUpload ID="fuImgPrfl" CssClass="profile-picture-uploads" runat="server" />
                    <br /><br /><br />
                    <asp:Button ID="btnPrvw" CssClass="client-buttons" runat="server" Text="Preview Profile Picture" OnClick="btnPrvw_Click" /><br /><br /><br /><br />
                    <asp:Image ID="imgPrvw" CssClass="client-preview-profile-picture" runat="server" Visible="false" />
                   <br />
              </center>
               </div>        
           </div>         
    </form>
</body>
</html>
