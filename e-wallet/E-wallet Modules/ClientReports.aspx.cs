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
    public partial class Reports : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            string accNmbr = Session["accountNumber"].ToString();
            string fullName = Session["fullName"].ToString();
            string dateRgstrd = Session["dateRegistered"].ToString();
            string crntBlnce = Session["formattedCurrentBalance"].ToString();
            string totalSntMny = Session["totalSentMoney"].ToString();

            lblAccNum.Text = accNmbr;
            lblName.Text = fullName;
            lblDateRgstrd.Text = dateRgstrd;
            lblCrntBlnce.Text = crntBlnce;
            lblTtlSntMny.Text = totalSntMny;

   
        }

        protected void btnShwHstryNow_Click(object sender, EventArgs e)
        {
            string transType = drdTypesOfTrans.SelectedValue;
            string accNmbr = Session["accountNumber"].ToString();
            string crntDate = DateTime.Now.ToString("MM-dd-yyyy");

            if (transType != "All" && transType != "Deposit & Withdrawals" && transType != "Sent & Received" 
                && transType != "Deposit" && transType != "Withdrawals" && transType != "Sent" && transType != "Received")
            {

                Response.Write("<script>alert('Select transaction type value first!')</script>");

            }

            using (var db = new SqlConnection(connStr))
            {
                db.Open();
                
                using (var cmd = db.CreateCommand())
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);


                    if (transType == "All")
                    {
                        cmd.CommandText = "SELECT TRANS_DEPOSIT, TRANS_WITHDRAW, TRANS_SENT, TRANS_RECEIVER,  TRANS_RECEIVE, TRANS_SENDER, TRANS_DATE FROM TRANSACTION_TBL, CLIENT_TBL " +
                                   "WHERE CLIENT_TBL.CLIENT_ID = TRANSACTION_TBL.CLIENT_ID AND CLIENT_TBL.CLIENT_ID = @accNmbr AND TRANS_DATE < @crntDate";
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);
                        cmd.Parameters.AddWithValue("@crntDate", crntDate);
                   
                        sda.Fill(dt);
                        grdTransHstryAll.DataSource = dt;
                        grdTransHstryAll.DataBind();

                        int ctr = grdTransHstryAll.Rows.Count;

                        if (ctr >= 1)
                        {
                            // clears all the displayed table for other trans when All type values is clicked
                            grdTransHstryDpstAndWthdrwls.DataSource = null;
                            grdTransHstryDpstAndWthdrwls.DataBind();

                            grdTransHstrySntAndRcvd.DataSource = null;
                            grdTransHstrySntAndRcvd.DataBind();

                            grdTransHstryDpst.DataSource = null;
                            grdTransHstryDpst.DataBind();

                            grdTransHstryWthdrwls.DataSource = null;
                            grdTransHstryWthdrwls.DataBind();

                            grdTransHstrySnt.DataSource = null;
                            grdTransHstrySnt.DataBind();

                            grdTransHstryRcvd.DataSource = null;
                            grdTransHstryRcvd.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('No history records found!')</script>");
                        }
                    }
                    else if (transType == "Deposit & Withdrawals")
                    {
                        cmd.CommandText = "SELECT TRANSACTION_TBL.TRANS_DEPOSIT, TRANSACTION_TBL.TRANS_WITHDRAW, TRANSACTION_TBL.TRANS_DATE FROM TRANSACTION_TBL, CLIENT_TBL " +
                                   "WHERE CLIENT_TBL.CLIENT_ID = TRANSACTION_TBL.CLIENT_ID AND CLIENT_TBL.CLIENT_ID = @accNmbr AND TRANS_DATE < @crntDate " +
                                   "AND TRANS_DEPOSIT != 0 OR TRANS_WITHDRAW != 0";
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);
                        cmd.Parameters.AddWithValue("@crntDate", crntDate);

                        sda.Fill(dt);
                        grdTransHstryDpstAndWthdrwls.DataSource = dt;
                        grdTransHstryDpstAndWthdrwls.DataBind();

                        int ctr = grdTransHstryDpstAndWthdrwls.Rows.Count;

                        if (ctr >= 1)
                        {
                            // clears all the displayed table for other trans when Deposit & Withdrawals type values is clicked
                            grdTransHstryAll.DataSource = null;
                            grdTransHstryAll.DataBind();

                            grdTransHstrySntAndRcvd.DataSource = null;
                            grdTransHstrySntAndRcvd.DataBind();

                            grdTransHstryDpst.DataSource = null;
                            grdTransHstryDpst.DataBind();

                            grdTransHstryWthdrwls.DataSource = null;
                            grdTransHstryWthdrwls.DataBind();

                            grdTransHstrySnt.DataSource = null;
                            grdTransHstrySnt.DataBind();

                            grdTransHstryRcvd.DataSource = null;
                            grdTransHstryRcvd.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('No history records found!')</script>");
                        }


                    }
                    else if (transType == "Sent & Received")
                    {
                        cmd.CommandText = "SELECT TRANSACTION_TBL.TRANS_SENT, TRANS_RECEIVER, TRANSACTION_TBL.TRANS_RECEIVE, TRANS_SENDER, TRANSACTION_TBL.TRANS_DATE FROM TRANSACTION_TBL " +
                     "INNER JOIN CLIENT_TBL ON CLIENT_TBL.CLIENT_ID = TRANSACTION_TBL.CLIENT_ID " +
                     "WHERE CLIENT_TBL.CLIENT_ID = @accNmbr AND TRANS_DATE < @crntDate " +
                     "AND (TRANS_SENT != 0 OR TRANS_RECEIVE != 0)";

                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);
                        cmd.Parameters.AddWithValue("@crntDate", crntDate);

                        sda.Fill(dt);
                        grdTransHstrySntAndRcvd.DataSource = dt;
                        grdTransHstrySntAndRcvd.DataBind();

                        int ctr = grdTransHstrySntAndRcvd.Rows.Count;

                        if (ctr >= 1)
                        {
                            // clears all the displayed table for other trans when Sent & Received type values is clicked
                            grdTransHstryAll.DataSource = null;
                            grdTransHstryAll.DataBind();

                            grdTransHstryDpstAndWthdrwls.DataSource = null;
                            grdTransHstryDpstAndWthdrwls.DataBind();

                            grdTransHstryDpst.DataSource = null;
                            grdTransHstryDpst.DataBind();

                            grdTransHstryWthdrwls.DataSource = null;
                            grdTransHstryWthdrwls.DataBind();

                            grdTransHstrySnt.DataSource = null;
                            grdTransHstrySnt.DataBind();

                            grdTransHstryRcvd.DataSource = null;
                            grdTransHstryRcvd.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('No history records found!')</script>");
                        }
                    }
                    else if (transType == "Deposit")
                    {
                        cmd.CommandText = "SELECT TRANSACTION_TBL.TRANS_DEPOSIT, TRANSACTION_TBL.TRANS_WITHDRAW, TRANSACTION_TBL.TRANS_DATE FROM TRANSACTION_TBL " +
                   "INNER JOIN CLIENT_TBL ON CLIENT_TBL.CLIENT_ID = TRANSACTION_TBL.CLIENT_ID " +
                   "WHERE CLIENT_TBL.CLIENT_ID = @accNmbr AND TRANS_DATE < @crntDate " +
                   "AND (TRANS_DEPOSIT != 0 OR TRANS_WITHDRAW != 0)";

                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);
                        cmd.Parameters.AddWithValue("@crntDate", crntDate);

                        sda.Fill(dt);
                        grdTransHstryDpst.DataSource = dt;
                        grdTransHstryDpst.DataBind();

                        int ctr = grdTransHstryDpst.Rows.Count;

                        if (ctr >= 1)
                        {
                            // clears all the displayed table for other trans when Sent & Received type values is clicked
                            grdTransHstryAll.DataSource = null;
                            grdTransHstryAll.DataBind();

                            grdTransHstryDpstAndWthdrwls.DataSource = null;
                            grdTransHstryDpstAndWthdrwls.DataBind();

                            grdTransHstrySntAndRcvd.DataSource = null;
                            grdTransHstrySntAndRcvd.DataBind();

                            grdTransHstryWthdrwls.DataSource = null;
                            grdTransHstryWthdrwls.DataBind();

                            grdTransHstrySnt.DataSource = null;
                            grdTransHstrySnt.DataBind();

                            grdTransHstryRcvd.DataSource = null;
                            grdTransHstryRcvd.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('No history records found!')</script>");
                        }
                    }
                    else if (transType == "Withdrawals")
                    {
                        cmd.CommandText = "SELECT TRANSACTION_TBL.TRANS_WITHDRAW, TRANSACTION_TBL.TRANS_DATE FROM TRANSACTION_TBL, CLIENT_TBL " +
                                   "WHERE CLIENT_TBL.CLIENT_ID = TRANSACTION_TBL.CLIENT_ID AND CLIENT_TBL.CLIENT_ID = @accNmbr AND TRANS_DATE < @crntDate " +
                                   "AND TRANS_WITHDRAW != 0";
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);
                        cmd.Parameters.AddWithValue("@crntDate", crntDate);

                        sda.Fill(dt);
                        grdTransHstryWthdrwls.DataSource = dt;
                        grdTransHstryWthdrwls.DataBind();

                        int ctr = grdTransHstryWthdrwls.Rows.Count;

                        if (ctr >= 1)
                        {
                            // clears all the displayed table for other trans when Sent & Received type values is clicked
                            grdTransHstryAll.DataSource = null;
                            grdTransHstryAll.DataBind();

                            grdTransHstryDpstAndWthdrwls.DataSource = null;
                            grdTransHstryDpstAndWthdrwls.DataBind();

                            grdTransHstrySntAndRcvd.DataSource = null;
                            grdTransHstrySntAndRcvd.DataBind();

                            grdTransHstryDpst.DataSource = null;
                            grdTransHstryDpst.DataBind();

                            grdTransHstrySnt.DataSource = null;
                            grdTransHstrySnt.DataBind();

                            grdTransHstryRcvd.DataSource = null;
                            grdTransHstryRcvd.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('No history records found!')</script>");
                        }
                    }
                    else if (transType == "Sent")
                    {
                        cmd.CommandText = "SELECT TRANSACTION_TBL.TRANS_SENT, TRANS_RECEIVER, TRANSACTION_TBL.TRANS_DATE FROM TRANSACTION_TBL, CLIENT_TBL " +
                                   "WHERE CLIENT_TBL.CLIENT_ID = TRANSACTION_TBL.CLIENT_ID AND CLIENT_TBL.CLIENT_ID = @accNmbr AND TRANS_DATE < @crntDate " +
                                   "AND TRANS_SENT != 0";
                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);
                        cmd.Parameters.AddWithValue("@crntDate", crntDate);

                        sda.Fill(dt);
                        grdTransHstrySnt.DataSource = dt;
                        grdTransHstrySnt.DataBind();

                        int ctr = grdTransHstrySnt.Rows.Count;

                        if (ctr >= 1)
                        {
                            // clears all the displayed table for other trans when Sent & Received type values is clicked
                            grdTransHstryAll.DataSource = null;
                            grdTransHstryAll.DataBind();

                            grdTransHstryDpstAndWthdrwls.DataSource = null;
                            grdTransHstryDpstAndWthdrwls.DataBind();

                            grdTransHstrySntAndRcvd.DataSource = null;
                            grdTransHstrySntAndRcvd.DataBind();

                            grdTransHstryDpst.DataSource = null;
                            grdTransHstryDpst.DataBind();

                            grdTransHstryWthdrwls.DataSource = null;
                            grdTransHstryWthdrwls.DataBind();

                            grdTransHstryRcvd.DataSource = null;
                            grdTransHstryRcvd.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('No history records found!')</script>");
                        }
                    }
                    else if (transType == "Received")
                    {
                        cmd.CommandText = "SELECT TRANS_DEPOSIT, TRANS_WITHDRAW, TRANS_SENT, TRANS_RECEIVER, TRANS_RECEIVE, TRANS_SENDER, TRANS_DATE FROM TRANSACTION_TBL " +
                    "INNER JOIN CLIENT_TBL ON CLIENT_TBL.CLIENT_ID = TRANSACTION_TBL.CLIENT_ID " +
                    "WHERE CLIENT_TBL.CLIENT_ID = @accNmbr AND TRANS_DATE < @crntDate";

                        cmd.Parameters.AddWithValue("@accNmbr", accNmbr);
                        cmd.Parameters.AddWithValue("@crntDate", crntDate);

                        sda.Fill(dt);
                        grdTransHstryRcvd.DataSource = dt;
                        grdTransHstryRcvd.DataBind();

                        int ctr = grdTransHstryRcvd.Rows.Count;

                        if (ctr >= 1)
                        {
                            // clears all the displayed table for other trans when Sent & Received type values is clicked
                            grdTransHstryAll.DataSource = null;
                            grdTransHstryAll.DataBind();

                            grdTransHstryDpstAndWthdrwls.DataSource = null;
                            grdTransHstryDpstAndWthdrwls.DataBind();

                            grdTransHstrySntAndRcvd.DataSource = null;
                            grdTransHstrySntAndRcvd.DataBind();

                            grdTransHstryDpst.DataSource = null;
                            grdTransHstryDpst.DataBind();

                            grdTransHstryWthdrwls.DataSource = null;
                            grdTransHstryWthdrwls.DataBind();

                            grdTransHstrySnt.DataSource = null;
                            grdTransHstrySnt.DataBind();
                        }
                        else
                        {
                            Response.Write("<script>alert('No history records found!')</script>");
                        }
                    }

                }
            }
            
           

        }
    }
}