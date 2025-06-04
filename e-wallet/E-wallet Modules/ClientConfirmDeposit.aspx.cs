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
    public partial class ConfirmDeposit : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // hides the button for back when the initial page is loaded
                btnBckBfrDpstng.Visible = false;
            
         
            }
        }

        protected void btnYesBfrSDpstng_Click(object sender, EventArgs e)
        {
            // hides the button for yes and no when a money deposit is successful
            btnYesBfrDpstng.Visible = false;
            btnNoBfrDpstng.Visible = false;

            // shows the button for back when a money deposit is successful
            btnBckBfrDpstng.Visible = true;

            // retrieves the needed session values like sent money and others from SendMoney page 
            int dpstMny = int.Parse(Session["depositMoney"].ToString());
            int accNmbr = int.Parse(Session["accountNumber"].ToString());
            int crntBlnce = int.Parse(Session["currentBalance"].ToString());

            // updates the current balance
            int updtdCrntBlnce = crntBlnce + dpstMny;
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
                        // date when the money was deposited
                        string dteDpst = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");

                        cmd.Parameters.Clear(); // accNmbr parameter to be used again in part

                        //inserts the deposited money amount of the user
                        cmd.CommandText = "INSERT INTO TRANSACTION_TBL (TRANS_DEPOSIT, TRANS_DATE, CLIENT_ID) " +
                            "VALUES (@dpstMnyIntParse, @dteDpst, @accNmbr)";
                        cmd.Parameters.AddWithValue("@dpstMnyIntParse", dpstMny);
                        cmd.Parameters.AddWithValue("@dteDpst", dteDpst);
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                        cmd.ExecuteNonQuery();

                        lblCnfrmDpstMnySucss.Text = "Successfully deposited money!";

                        // clears the prompt message for "Do you want to continue?" when a money deposit is successful
                        lblCnfrmDpstMnyPrmptMssge.Text = string.Empty;
                    }
                    else
                    {
                        lblCnfrmDpstMnySucss.Text = "Failed to deposit money!";
                    }
                }

            }
        }

            protected void btnBckBfrDpstng_Click(object sender, EventArgs e)
            {
                Response.Redirect("ClientDeposit.aspx");
            }

            protected void btnNoBfrSDpstng_Click(object sender, EventArgs e)
            {
            //removes the value for session depositMoney in order for the current balance not to update when it redirects to SendMoney.aspx
            Session.Remove("depositMoney");
            
            Response.Redirect("ClientDeposit.aspx");
            }
        }
    }