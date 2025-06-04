<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientSignUp.aspx.cs" Inherits="E_wallet.E_wallet_Modules.UserSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    <link rel="stylesheet" href="../Content/index.css" />
    <style type="text/css">
        .auto-style271 {}
        .auto-style272 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <div>   
           <div class="client-left-divs">
               <center><asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/djpay-logo.png" Width="200px"/> <br /> <br /> <br />
               <h1 class="h1-client-headers">Please complete the required fields.</h1><br />
               <h3 class="h3-client-notes">Once you have finished filling out the form, simply click the "Finish" button to submit your information.<br /> <br />
              </h3>       
              <asp:Button ID="btnCreateAccFinish" CssClass="client-buttons" runat="server" Text="Finish" Height="53px" Width="170px" OnClick="btnCreateAccFinish_Click"/>   
              &nbsp;&nbsp;&nbsp;&nbsp;   
              <asp:Button ID="btnCreateAccBack" CssClass="client-buttons" OnClick="btnCreateAccBack_Click" runat="server" Text="Back" Height="53px" Width="170px"/>  
              </center>
           </div>
               <div class="client-right-divs"><br />
                   <center>
                   <p class="p-client-headers">Create Your Account</p>
                   First Name:&nbsp;&nbsp;
                  <asp:TextBox ID="txtCrtFname" MaxLength="70" runat="server" Width="250px" Height="25px"></asp:TextBox>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   Middle Initial:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCrtMidIntl" placeholder ="M" runat="server" Width="83px" Height="25px"></asp:TextBox><br />
                   <br />
                   Family Name:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCrtFamName" MaxLength="70" runat="server" Width="250px" Height="25px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                   Date of Birth:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCrtBirthDt" placeholder="MM-DD-YYYY" runat="server" Width="84px" Height="25px"></asp:TextBox><br />           
                   <br />     
                    Gender:&nbsp;&nbsp;
                   <asp:DropDownList ID="drdCrtGender" runat="server" CssClass="auto-style271" Width="126px" Height="25px">
                    <asp:ListItem Text="--Select Gender--" disabled Selected></asp:ListItem>
                       <asp:ListItem Value="Male">Male</asp:ListItem>
                       <asp:ListItem Value="Female">Female</asp:ListItem>
                  </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                   Phone Number:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCrtPhNum" placeholder="+63" runat="server" Width="166px" Height="25px" CssClass="auto-style272"></asp:TextBox><br /><br />
                    Address:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCrtAdrs" MaxLength="120" runat="server" Width="513px" Height="25px" CssClass="auto-style272"></asp:TextBox><br /><br /> 
                    Email Address:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCrtEmlAdrs" placeholder="e.g. example@yahoo.com/@gmail.com/@ctu.edu.ph" MaxLength="120" runat="server" Width="466px" Height="25px" CssClass="auto-style272"></asp:TextBox><br /><br />
                    Username:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCrtUsrnm" MaxLength="70" runat="server" Width="499px" Height="25px" CssClass="auto-style272"></asp:TextBox><br /><br />       
                    Password:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCrtPswrd" MaxLength="70" TextMode="Password" runat="server" Width="504px" Height="25px" CssClass="auto-style272"></asp:TextBox><br /><br />       
                    Confirm Password:&nbsp;&nbsp;
                   <asp:TextBox ID="txtCnfrmCrtPswrd" MaxLength="70" TextMode="Password" runat="server" Width="440px" Height="25px" CssClass="auto-style272"></asp:TextBox><br />                   
                  
                 
                    <br />
                    <%-- Invalid format input for Middle Initial --%>
                    <asp:RegularExpressionValidator ID="revCntrInvldInptMidIntl" CssClass="input-validators" runat="server" ControlToValidate="txtCrtMidIntl"
                    ErrorMessage="Please enter a valid Middle Initial format <i class='fas fa-exclamation-circle'></i>" 
                        ValidationExpression="^[A-Za-z]{1}$">
                    </asp:RegularExpressionValidator><br />
                     <%--Invalid format input for Date of Birth --%>
                    <asp:RegularExpressionValidator ID="revCntrInvldInptBrthDt" CssClass="input-validators" runat="server" ControlToValidate="txtCrtBirthDt"
                    ErrorMessage="Please enter a valid Date of Birth format <i class='fas fa-exclamation-circle'></i>" 
                        ValidationExpression="^\d{2}-\d{2}-\d{4}$">
                   </asp:RegularExpressionValidator><br />
                   <%-- Invalid format input for Phone Number --%>
                    <asp:RegularExpressionValidator ID="revCntrInvldInptPhNo" CssClass="input-validators" runat="server" ControlToValidate="txtCrtPhNum"
                     ErrorMessage="Please enter a valid Phone Number format <i class='fas fa-exclamation-circle'></i>"
                     ValidationExpression="^9\d{9}$"></asp:RegularExpressionValidator><br />
                  <%-- Invalid format input for Email Address --%>
                    <asp:RegularExpressionValidator ID="revCntrInvldInptEmlAdrs" CssClass="input-validators" runat="server" ControlToValidate="txtCrtEmlAdrs"
                     ErrorMessage="Please enter a valid Email Address format <i class='fas fa-exclamation-circle'></i>"
                     ValidationExpression="^[a-zA-Z0-9._%+-]+@(gmail.com|yahoo.com|ctu.edu.ph)$"></asp:RegularExpressionValidator>
                   </center>
               </div>        
           </div>         
    </form>
</body>
</html>
