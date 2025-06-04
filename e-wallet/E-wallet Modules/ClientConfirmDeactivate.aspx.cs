using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace E_wallet.E_wallet_Modules
{
    public partial class Deactivate : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  // set the back button when the ConfirmSendMoney page is loaded
            {
                btnBckInptPswrdAftrDeact.Visible = false;
                lblCnfrmDeactAccPrmptMssge.Text = "Enter your password to proceed.";
            }
        }

        protected void btnSbmtInptPswrdBfrDeact_Click(object sender, EventArgs e)
        {
            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    int accNmbr = int.Parse(Session["accountNumber"].ToString());
                    string clntPswrd = txtInptPswrdBfrDeact.Text;
                    string clntUsrNme = Session["username"].ToString();

                    cmd.CommandText = "SELECT COUNT(*) CLIENT_PSWRD FROM CLIENT_TBL " +
                        "WHERE CLIENT_PSWRD = @clntPswrd AND CLIENT_USRNME = @clntUsrNme";
                    cmd.Parameters.AddWithValue("@clntPswrd", clntPswrd);
                    cmd.Parameters.AddWithValue("@clntUsrNme", clntUsrNme);

                    int matchPswrd = (int)cmd.ExecuteScalar();

                    if (matchPswrd > 0) //checks if password matches from the user
                    {
                        string accStats = "Deactivated";

                        cmd.CommandText = "UPDATE CLIENT_TBL SET CLIENT_STATUS = @accStats " +
                            "WHERE CLIENT_ID = @accNmbr";
                        cmd.Parameters.AddWithValue("@accStats", accStats);
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                        int ctr = cmd.ExecuteNonQuery();
                        
                        if (ctr >= 1) // if password matches from the user then account will be successfully deactivated
                        {
                             // visibility for submit and cancel button and password textbox will be set to false when the deactivation of the account is successful
                        btnSbmtInptPswrdBfrDeact.Visible = false;
                        btnCnclInptPswrdBfrDeact.Visible = false;
                        txtInptPswrdBfrDeact.Visible = false;

                        lblCnfrmDeactAccSucss.Text = "Successfully deactivated account!";

                        //  clears the prompt message when the deactivation of the account is successful
                        lblCnfrmDeactAccPrmptMssge.Text = string.Empty;

                        //  clears the error message when the deactivation of the account is successful
                        lblInvldInptPswrdBfrDeact.Text = "";

                        // visibility for back button and  will be set to true when the deactivation of the account is successful
                        btnBckInptPswrdAftrDeact.Visible = true;
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to deactivate account!')</script>");
                        }                
                    }
                    else
                    {
                        lblInvldInptPswrdBfrDeact.Text = "Wrong Password!";
                    }

                }

            }
        }

        protected void btnCnclInptPswrdBfrDeact_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientDashboard.aspx");
        }

        protected void btnBckInptPswrdAftrDeact_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientSignIn.aspx");
        }
    }
}