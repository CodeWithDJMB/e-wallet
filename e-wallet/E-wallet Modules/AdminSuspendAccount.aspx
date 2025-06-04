<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSuspendAccount.aspx.cs" Inherits="E_wallet.E_wallet_Modules.AdminSuspendAccount" %>

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
               <h1 class="h1-admin-headers">Please complete the required fields.</h1><br /> 
               <h3 class="h3-admin-notes">Once you have finished entering a client's account number, simply click the "Suspend" button to suspend the account.<br /> <br />
              </h3>       
              <asp:Button ID="btnBackSspnd" CssClass="admin-buttons" OnClick="btnBackSspnd_Click" runat="server" Text="Back" Height="53px" Width="170px"/>    
              </center>
           </div>
            <div class="admin-right-divs">
                <br />
                <center>
                    <p class="p-admin-headers">Suspend Account</p>
                    <br /><br />
                    <span id="spanSndAccNmberAndPswrdField">
                        <asp:Button ID="btnSrchAccNmbr" CssClass="admin-buttons" OnClick="btnSrchAccNmbr_Click" runat="server" Text="Search Now" />&nbsp;&nbsp;&nbsp;&nbsp;  
                         <i class="fa-solid fa-hashtag" style="color: #0D98BA;"></i>
                        <asp:TextBox ID="txtAccNmbr" placeholder="Enter Client's Account Number" Font-Size="10" Font-Bold="true" runat="server" Width="223px" Height="31px" CssClass="auto-style272"></asp:TextBox>
                        <br />
                        <br />
                        <br />
                        <asp:GridView ID="grdClntRcrds"  runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="CLIENT_ID" HeaderText="Account #" />
                                <asp:BoundField DataField="CLIENT_STATUS" HeaderText="Account Status" />
                                <asp:BoundField DataField="CLIENT_FNAME" HeaderText="First Name" />
                                <asp:BoundField DataField="CLIENT_MIDINTL" HeaderText="Middle Initial" />
                                <asp:BoundField DataField="CLIENT_LNAME" HeaderText="Last Name" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblInvldAccNmbr" ForeColor="red" Font-Size="Large" runat="server" Text=""></asp:Label><br />
                    </span>
                    <br />
                        <br />
                        <br />
                        <br />
                    <asp:Button ID="btnSspndAcc" CssClass="admin-buttons" OnClick="btnSspndAcc_Click"  runat="server" Text="Suspend" Height="53px" Width="170px" /><br />
                    <br />
                    <br />
                </center>
            </div>
        </div>
    </form>
</body>
</html>
