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
    public partial class ConfirmSuspension : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            btnBckBfrSspnd.Visible = false;
        }

        protected void btnYesBfrSspnd_Click(object sender, EventArgs e)
        {
            int accNmbr = int.Parse(Session["accountNumber"].ToString());


            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM CLIENT_TBL " +
                        "WHERE CLIENT_ID = @accNmbr";
                    cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                    int existingAccNmbr = (int)cmd.ExecuteScalar();

                    if (existingAccNmbr > 0)  //  check if the account number to be suspended exist
                    {
                        string accStats = "Suspended";

                        cmd.Parameters.Clear();

                        cmd.CommandText = "UPDATE CLIENT_TBL SET CLIENT_STATUS = @accStats " +
                            "WHERE CLIENT_ID = @accNmbr";
                        cmd.Parameters.AddWithValue("@accStats", accStats);
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                        cmd.ExecuteNonQuery();

                        lblCnfrmSspndAccPrmptMssge.Text = String.Empty;
                        
                        btnYesBfrSspnd.Visible = false;
                        btnNoBfrSspnd.Visible = false;
                        btnBckBfrSspnd.Visible = true;

                        lblCnfrmSspndAccSucss.Text = "Account successfully suspended!";

                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to suspend account!')</script>");
                    }
                }
            }
        }

        protected void btnNoBfrSspnd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSuspendAccount.aspx");
        }

        protected void btnBckBfrSspnd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSuspendAccount.aspx");
        }
    }
}