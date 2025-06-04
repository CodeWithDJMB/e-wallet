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
    public partial class ConfirmSendMoney : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  // set the back button when the ClientConfirmSendMoney page is loaded
            {
                btnBckInptPswrdBfrSndng.Visible = false;
                lblCnfrmSndMnyPrmptMssge.Text = "Enter your password to proceed.";
            }
        }

        protected void btnSbmtInptPswrdBfrSndng_Click(object sender, EventArgs e)
        {

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    int accNmbr = int.Parse(Session["accountNumber"].ToString());
                    string clntPswrd = txtInptPswrdBfrSndng.Text;
                    string clntUsrNme = Session["username"].ToString();
                    string rcpntAccNmbrStr = Session["recipientAccountNumber"].ToString();
                    int rcpntAccNmbr = int.Parse(rcpntAccNmbrStr);
                    int sntMny = int.Parse(Session["sentMoney"].ToString());

                    cmd.CommandText = "SELECT COUNT(*) CLIENT_PSWRD FROM CLIENT_TBL " +
                        "WHERE CLIENT_PSWRD = @clntPswrd AND CLIENT_USRNME = @clntUsrNme";
                    cmd.Parameters.AddWithValue("@clntPswrd", clntPswrd);
                    cmd.Parameters.AddWithValue("@clntUsrNme", clntUsrNme);

                    int matchPswrd = (int)cmd.ExecuteScalar();

                    if (matchPswrd > 0) //checks if password matches from the user
                    {
                        cmd.Parameters.Clear(); // rcpntAccNmbr parameter to be used again in part

                        //update the current balance of the receiver
                        cmd.CommandText = "UPDATE CLIENT_TBL SET CLIENT_BALANCE = (CLIENT_BALANCE + @sntMny) WHERE CLIENT_ID = @rcpntAccNmbr";
                        cmd.Parameters.AddWithValue("@sntMny", sntMny);
                        cmd.Parameters.AddWithValue("@rcpntAccNmbr", rcpntAccNmbr);

                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear(); // rcpntAccNmbr parameter to be used again in part

                        //update the current balance of the user
                        cmd.CommandText = "UPDATE CLIENT_TBL SET CLIENT_BALANCE = (CLIENT_BALANCE - @sntMny) WHERE CLIENT_ID = @accNmbr";
                        cmd.Parameters.AddWithValue("@sntMny", sntMny);
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);
                        
                        cmd.ExecuteNonQuery();

                        // date when the money was sent
                        string dteSnt = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");

                        cmd.Parameters.Clear(); // sntMny and dteSnt parameter to be used again in part

                        //inserts the sent money from the user as received money to the recipient
                        cmd.CommandText = "INSERT INTO TRANSACTION_TBL (TRANS_RECEIVE, TRANS_DATE, CLIENT_ID, TRANS_SENDER) " +
                            "VALUES (@sntMny, @dteSnt, @rcpntAccNmbr, @accNmbr)";
                        cmd.Parameters.AddWithValue("@sntMny", sntMny);
                        cmd.Parameters.AddWithValue("@dteSnt", dteSnt);
                        cmd.Parameters.AddWithValue("@rcpntAccNmbr", rcpntAccNmbr);
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);


                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear(); // sntMny parameter to be used again in part

                        //inserts the sent money amount of the user
                        cmd.CommandText = "INSERT INTO TRANSACTION_TBL (TRANS_SENT, TRANS_DATE, CLIENT_ID, TRANS_RECEIVER) " +
                            "VALUES (@sntMny, @dteSnt, @accNmbr, @rcpntAccNmbr)";
                        cmd.Parameters.AddWithValue("@sntMny", sntMny);
                        cmd.Parameters.AddWithValue("@dteSnt", dteSnt);
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);
                        cmd.Parameters.AddWithValue("@rcpntAccNmbr", rcpntAccNmbr);


                        var ctr = cmd.ExecuteNonQuery();

                        if (ctr >= 1)
                        {
                            cmd.Parameters.Clear(); // accNmbr parameter to be used again in part

                            // gets the user's total sent money by joining user and transaction table
                            cmd.CommandText = "SELECT SUM(TRANSACTION_TBL.TRANS_SENT) AS TOTAL_SENT, CLIENT_TBL.CLIENT_BALANCE FROM CLIENT_TBL, TRANSACTION_TBL " +
                           "WHERE CLIENT_TBL.CLIENT_ID = TRANSACTION_TBL.CLIENT_ID AND CLIENT_TBL.CLIENT_ID = @accNmbr " +
                           "GROUP BY CLIENT_TBL.CLIENT_ID, CLIENT_TBL.CLIENT_BALANCE";
                            cmd.Parameters.AddWithValue("accNmbr", accNmbr);

                            SqlDataReader reader = cmd.ExecuteReader();
                           
                            //retrieves the value for the total sent money of a user
                            if (reader.Read())
                            {
                                lblCnfrmSndMnyPrmptMssge.Text = "Succesfully Sent Money!";
                                string totalSntMnyStr = reader["TOTAL_SENT"].ToString();

                                int crntBlnce = int.Parse(reader["CLIENT_BALANCE"].ToString());
                                Session["formattedCurrentBalance"] = crntBlnce.ToString("N2");


                                int totalSntMny = int.Parse(totalSntMnyStr);
                                Session["totalSentMoney"] = "₱" + totalSntMny.ToString("N2");

                                cmd.CommandText = "UPDATE TRANSACTION_TBL SET TRANS_SENT = @sntMny WHERE CLIENT_ID = @rcpntAccNmbr";
                                cmd.Parameters.AddWithValue("@sntMny", sntMny);
                                cmd.Parameters.AddWithValue("@rcpntAccNmbr", rcpntAccNmbr);
                           
                                // visibility for submit and cancel button and password textbox will be set to false when the money was sent successfully 
                                btnSbmtInptPswrdBfrSndng.Visible = false;
                                btnCnclInptPswrdBfrSndng.Visible = false;
                                txtInptPswrdBfrSndng.Visible = false;

                                lblCnfrmSndMnySucss.Text = "Successfully Sent Money!";

                                //  clears the prompt message when the money was sent succesfully
                                lblCnfrmSndMnyPrmptMssge.Text = string.Empty;                     

                                //  clears the error message when money was sent successfully
                                lblInvldInptPswrdBfrSndng.Text = "";

                                // visibility for cancel button and  will be set to true when the money was sent successfully 
                                btnBckInptPswrdBfrSndng.Visible = true;

                            }

                        }
                    }
                    else
                    {
                        lblInvldInptPswrdBfrSndng.Text = "Wrong Password!";
                    }

                }

            }
        }

        protected void btnCnclInptPswrdBfrSndng_Click(object sender, EventArgs e)
        {
            //removes the value for session sendMoney in order for the current balance not to update when it redirects to SendMoney.aspx
            Session.Remove("sentMoney");

            Response.Redirect("ClientSendMoney.aspx");
        }

        protected void btnBckInptPswrdBfrSndng_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientSendMoney.aspx");
        }
    }
}