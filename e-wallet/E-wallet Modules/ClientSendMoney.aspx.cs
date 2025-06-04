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
    public partial class SendMoney : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            string accNmbr = Session["accountNumber"].ToString();
            string fullName = Session["fullName"].ToString();
            string dateRgstrd = Session["dateRegistered"].ToString();
            string crntBlnce = Session["formattedCurrentBalance"].ToString();
            string totalSntMny = Session["totalSentMoney"].ToString();



            if (!IsPostBack)  // if the recipient number has not been chosen, the textbox and button for cash will be disabled
            {
                lblAccNum.Text = accNmbr;
                lblName.Text = fullName;
                lblDateRgstrd.Text = dateRgstrd;
                lblCrntBlnce.Text = crntBlnce;
                lblTtlSntMny.Text = totalSntMny;

                txtSndMoney.Enabled = false;
                btnSndMny.Enabled = false;

            }
            else
            {
                lblAccNum.Text = accNmbr;
                lblName.Text = fullName;
                lblDateRgstrd.Text = dateRgstrd;
                lblCrntBlnce.Text = crntBlnce;
                lblTtlSntMny.Text = totalSntMny;
            }
        }
        protected void btnSndMny_Click(object sender, EventArgs e)
        {
            string balance = Session["currentBalance"].ToString();
            int crntBlnce = int.Parse(balance);

            // check if the user entered an amount otherwise display make sure to enter an amount
            if (txtSndMoney.Text != "")
            {
                //if the inputted amount is int, this will execute else prompt invalid amount input
                if (Session["sentMoney"] != null && int.TryParse(Session["sentMoney"].ToString(), out int sndMnyIntParse) && sndMnyIntParse > 0)
                {

                    if (sndMnyIntParse > 50000)
                    {
                        lblSndAmntInvalid.Text = "The Maximum Amount To Be Sent Is ₱10,000.00!";

                        // clears the entered amount after it encounters an invalid amount
                        txtSndMoney.Text = string.Empty;
                    }
                    else if (sndMnyIntParse < 100)
                    {
                        lblSndAmntInvalid.Text = "The Minimum Amount To Be Sent Is ₱100.00!";
                        txtSndMoney.Text = string.Empty;

                    }
                    else if (sndMnyIntParse % 100 != 0)
                    {
                        lblSndAmntInvalid.Text = "The Amount To Be Deposit Must Be Divisible By ₱100.00!";
                        txtSndMoney.Text = string.Empty;

                    }
                    else if (crntBlnce - sndMnyIntParse < 0)
                    {
                        lblSndAmntInvalid.Text = "Insufficient Funds!";
                        txtSndMoney.Text = string.Empty;

                    }
                    else
                    {
                        Response.Redirect("ClientConfirmSendMoney.aspx");
                    }
                }
                else
                {
                    lblSndAmntInvalid.Text = "Please Enter A Valid Amount!";
                    txtSndMoney.Text = string.Empty;

                }
            }
            else
            {
                lblSndAmntInvalid.Text = "Send failed! Make sure to enter an amount.";

            }

        }
        protected void txtSndMoney_TextChanged(object sender, EventArgs e)
        {
            Session["sentMoney"] = txtSndMoney.Text;  // gets the not formatted money for it to be converted into int

            if (int.TryParse(txtSndMoney.Text, out int amount))
            {
                txtSndMoney.Text = amount.ToString("N2");

            }

            // clears all the error messages when new format for amount is generated or when the user inputs again
            lblSndAmntInvalid.Text = string.Empty;

            // display the updated current balance when the money format is generated
            lblCrntBlnce.Text = Session["formattedCurrentBalance"].ToString();
        }

        protected void btnSrchRcpnt_Click(object sender, EventArgs e)
        {
            // clears the error prompt message for not entering an amount after choosing a recipient's account number
            lblSndAmntInvalid.Text = string.Empty;

            lblCrntBlnce.Text = Session["formattedCurrentBalance"].ToString();

            string rcpntAccNmbr = txtRcpntAccNmbr.Text;
            Session["recipientAccountNumber"] = rcpntAccNmbr;
            string accNmbrStr = Session["accountNumber"].ToString();

            // check if the user entered a recipient's account number otherwise display make sure to enter recipient's account number
            if (txtRcpntAccNmbr.Text != "")
            {
                // checks if the recipient number is the not the same as the user's account number
                if (rcpntAccNmbr != accNmbrStr)
                {
                    // checks if the acccount number inputted is only a positive number, not special characters
                    if (int.TryParse(Session["recipientAccountNumber"].ToString(), out int accNmbr) && accNmbr > 0)
                    {
                        using (var db = new SqlConnection(connStr))
                        {
                            db.Open();

                            using (var cmd = db.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;

                                cmd.CommandText = "SELECT * FROM CLIENT_TBL WHERE CLIENT_ID = @rcpntAccNmbr";
                                cmd.Parameters.AddWithValue("@rcpntAccNmbr", rcpntAccNmbr);

                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.Read())
                                {
                                    if (reader["CLIENT_STATUS"].ToString() == "Deactivated")
                                    {
                                        // clears the displayed table info for recipient after encountering a non-existing recipient 
                                        grdRcpntRcrds.DataSource = null;
                                        grdRcpntRcrds.DataBind();

                                        // if the recipient number has not been chosen, the textbox and button for cash will be enabled
                                        txtSndMoney.Enabled = false;
                                        btnSndMny.Enabled = false;

                                        lblInvldRcpnt.Text = "You can't send money to a deactivated account!";
                                    }
                                    else if (reader["CLIENT_STATUS"].ToString() == "Suspended")
                                    {
                                        // clears the displayed table info for recipient after encountering a non-existing recipient 
                                        grdRcpntRcrds.DataSource = null;
                                        grdRcpntRcrds.DataBind();

                                        // if the recipient number has not been chosen, the textbox and button for cash will be enabled
                                        txtSndMoney.Enabled = false;
                                        btnSndMny.Enabled = false;

                                        lblInvldRcpnt.Text = "You can't send money to a suspended account!";
                                    }
                                    else
                                    {
                                        reader.Close();

                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "SELECT CLIENT_ID, CLIENT_FNAME, CLIENT_MIDINTL, CLIENT_LNAME FROM CLIENT_TBL " +
                                         "WHERE CLIENT_ID = @rcpntAccNmbr";
                                        cmd.Parameters.AddWithValue("@rcpntAccNmbr", rcpntAccNmbr);

                                        DataTable dt = new DataTable();
                                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                                        sda.Fill(dt);
                                        grdRcpntRcrds.DataSource = dt;
                                        grdRcpntRcrds.DataBind();

                                        int ctr = grdRcpntRcrds.Rows.Count;

                                        if (ctr >= 1)
                                        {
                                            // if the recipient number has been chosen, the textbox and button for cash will be enabled
                                            txtSndMoney.Enabled = true;
                                            btnSndMny.Enabled = true;

                                            lblInvldRcpnt.Text = string.Empty;
                                        }

                                       
                                    }
                                }
                                else
                                {
                                    // clears the displayed table info for recipient after encountering a non-existing recipient 
                                    grdRcpntRcrds.DataSource = null;
                                    grdRcpntRcrds.DataBind();

                                    // if the recipient number has not been chosen, the textbox and button for cash will be enabled
                                    txtSndMoney.Enabled = false;
                                    btnSndMny.Enabled = false;
                                    lblInvldRcpnt.Text = "Recipient Does Not Exist!";
                                }
                            }
                        }
                    }
                    else
                    {
                        lblInvldRcpnt.Text = "Please enter a valid account Number!";

                        // clears the displayed table info for recipient after encountering an invalid input 
                        grdRcpntRcrds.DataSource = null;
                        grdRcpntRcrds.DataBind();
                    }

                }
                else
                {
                    // clears the displayed table info for recipient after encountering a same recipient's account number of yours
                    grdRcpntRcrds.DataSource = null;
                    grdRcpntRcrds.DataBind();

                    lblInvldRcpnt.Text = "You can't send money to your own account!";
                }
            }
            else
            {
                // clears the displayed table info for recipient after encountering a no input for recipient's account number
                grdRcpntRcrds.DataSource = null;

                grdRcpntRcrds.DataBind();
                lblInvldRcpnt.Text = "Search failed! Make sure to enter a recipient's account number.";
            }

        }

    }
}