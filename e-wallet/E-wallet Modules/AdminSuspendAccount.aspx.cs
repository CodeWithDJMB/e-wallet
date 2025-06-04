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
    public partial class AdminSuspendAccount : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            // sets the suspend account button to disabled
            if (!IsPostBack)
            {
                btnSspndAcc.Enabled = false;
            }
            else
            {
                btnSspndAcc.Enabled = false;
            }
        }

        protected void btnSspndAcc_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminConfirmSuspend.aspx");

        }

        protected void btnSrchAccNmbr_Click(object sender, EventArgs e)
        {
            Session["accountNumber"] = txtAccNmbr.Text;


            if (txtAccNmbr.Text != "")
            {
                // check if the acccount number inputted is only a positive number, not special characters
                if (int.TryParse(Session["accountNumber"].ToString(), out int accNmbr) && accNmbr > 0)
                {
                    using (var db = new SqlConnection(connStr))
                    {
                        db.Open();

                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "SELECT CLIENT_STATUS FROM CLIENT_TBL WHERE " +
                                "CLIENT_ID = @accNmbr";
                            cmd.Parameters.AddWithValue("accNmbr", accNmbr);

                            SqlDataReader reader = cmd.ExecuteReader();

                            if(reader.Read())
                            {
                                

                                string accStats = reader["CLIENT_STATUS"].ToString();


                                if (accStats != "Suspended" && accStats != "Deactivated")
                                {
                                    reader.Close(); // close the reader so that the next SqlDataAdapter will not be affected

                                    cmd.Parameters.Clear();
                                    cmd.CommandText = "SELECT CLIENT_ID, CLIENT_STATUS, CLIENT_FNAME, CLIENT_MIDINTL, CLIENT_LNAME FROM CLIENT_TBL " +
                                        "WHERE CLIENT_ID = @accNmbr AND CLIENT_STATUS = 'Active'";
                                    cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                                    DataTable dt = new DataTable();
                                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                                    sda.Fill(dt);
                                    grdClntRcrds.DataSource = dt;
                                    grdClntRcrds.DataBind();

                                    int ctr = grdClntRcrds.Rows.Count;

                                    if (ctr >= 1)
                                    {
                                        // if the client's account number has been chosen, the button for suspension will be enabled
                                        btnSspndAcc.Enabled = true;

                                        lblInvldAccNmbr.Text = string.Empty;
                                    }

                                    
                                }
                                else if (accStats == "Suspended")
                                {
                                    // clears the displayed table info for client after encountering a non-existing client 
                                    grdClntRcrds.DataSource = null;
                                    grdClntRcrds.DataBind();

                                    // if the client's account number has not been chosen, the button for suspension will be enabled
                                    btnSspndAcc.Enabled = false;
                                    lblInvldAccNmbr.Text = "Account already suspended!";
                                }
                                else if (accStats == "Deactivated")
                                {
                                    // clears the displayed table info for client after encountering a non-existing client 
                                    grdClntRcrds.DataSource = null;
                                    grdClntRcrds.DataBind();

                                    // if the client's account number has not been chosen, the button for suspension will be enabled
                                    btnSspndAcc.Enabled = false;
                                    lblInvldAccNmbr.Text = "Cannot suspend a deactivated account!";
                                }
                            }
                            else
                            {
                                // clears the displayed table info for client after encountering a non - existing client
                                grdClntRcrds.DataSource = null;
                                grdClntRcrds.DataBind();

                                lblInvldAccNmbr.Text = "Account number does not exist!";
                                txtAccNmbr.Text = string.Empty;
                            }

                        }
                    }

                }
                else
                {
                    lblInvldAccNmbr.Text = "Please enter a valid account Number!";

                    // clears the displayed table info for client after encountering an invalid input 
                    grdClntRcrds.DataSource = null;
                    grdClntRcrds.DataBind();
                }

            }
            else
            {
                // clears the displayed table info for client after encountering a no input for client's account number
                grdClntRcrds.DataSource = null;

                grdClntRcrds.DataBind();
                lblInvldAccNmbr.Text = "Search failed! Make sure to enter a client's account number.";
            }
        }

        protected void btnBackSspnd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}