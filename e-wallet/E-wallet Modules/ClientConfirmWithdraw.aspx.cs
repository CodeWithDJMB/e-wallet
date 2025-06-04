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
    public partial class ConfirmWithdraw : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // hides the button for back when the initial page is loaded
                btnBckBfrWthdrwng.Visible = false;
            }
        }

        protected void btnYesBfrWthdrw_Click(object sender, EventArgs e)
        {
            // hides the button for yes and no when a money withdrawal is successful
            btnYesBfrWthdrw.Visible = false;
            btnNoBfrWthdrw.Visible = false;

            // shows the button for back when a money withdrawal is successful
            btnBckBfrWthdrwng.Visible = true;

            // retrieves the needed session values like withdrawn money and others from client withdraw page 
            int wthdrwMny = int.Parse(Session["withdrawMoney"].ToString());
            int accNmbr = int.Parse(Session["accountNumber"].ToString());
            int crntBlnce = int.Parse(Session["currentBalance"].ToString());

            // updates the current balance
            int updtdCrntBlnce = crntBlnce - wthdrwMny;
            Session["currentBalance"] = updtdCrntBlnce;
            Session["formattedCurrentBalance"] = "₱" + updtdCrntBlnce.ToString("N2");

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = "UPDATE CLIENT_TBL SET CLIENT_BALANCE = @crntBlnce WHERE CLIENT_ID = @accNmbr";
                    cmd.Parameters.AddWithValue("@crntBlnce", updtdCrntBlnce);
                    cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                    var ctr = cmd.ExecuteNonQuery();

                    if (ctr >= 1)
                    {
                        // date when the money was withdrawn
                        string dteDpst = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");

                        cmd.Parameters.Clear(); // accNmbr parameter to be used again in part

                        //inserts the withdrawn money amount of the user
                        cmd.CommandText = "INSERT INTO TRANSACTION_TBL (TRANS_WITHDRAW, TRANS_DATE, CLIENT_ID) " +
                            "VALUES (@dpstMnyIntParse, @dteDpst, @accNmbr)";
                        cmd.Parameters.AddWithValue("@dpstMnyIntParse", wthdrwMny);
                        cmd.Parameters.AddWithValue("@dteDpst", dteDpst);
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                        cmd.ExecuteNonQuery();

                        lblCnfrmWthdrwMnySucss.Text = "Successfully withdrawn money!";

                        // clears the prompt message for "Do you want to continue?" when a money withdrawal is successful
                        lblCnfrmWthdrwMnyPrmptMssge.Text = string.Empty;
                    }
                    else
                    {
                        lblCnfrmWthdrwMnySucss.Text = "Failed to withdraw money!";
                    }
                }

            }
        }

        protected void btnNoBfrWthdrw_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientWithdraw.aspx");
        }

        protected void btnBckBfrWthdrw_Click(object sender, EventArgs e)
        {
            //removes the value for session withdrawMoney in order for the current balance not to update when it redirects to SendMoney.aspx
            Session.Remove("withdrawMoney");

            Response.Redirect("ClientWithdraw.aspx");
        }
    }
}