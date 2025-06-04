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
    public partial class Dashboard : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the session value is null
                if (Session["username"] == null)
                {
                    // Redirect the user to the login page or perform any other appropriate action
                    Response.Redirect("ClientSignIn.aspx");
                }
                else
                {
                    string username = Session["username"].ToString();
                    // Use the username value as needed

                    using (var db = new SqlConnection(connStr))
                    {
                        db.Open();

                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.CommandText = "SELECT * FROM CLIENT_TBL WHERE CLIENT_USRNME = @username";
                            cmd.Parameters.AddWithValue("username", username);

                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                // Retrieve the attribute value from the reader and assign it to the label control

                                if (reader["CLIENT_PROFPIC"] != DBNull.Value)
                                {
                                    byte[] pic = (byte[])reader["CLIENT_PROFPIC"];
                                    string str = Convert.ToBase64String(pic);
                                    updtdProfPic.ImageUrl = "data:image/jpeg;base64," + str;
                                    dfltProfPic.Visible = false;

                                }
                                else
                                {
                                    updtdProfPic.Visible = false;
                                    dfltProfPic.Visible = true;
                                }

                                string accNmbr = reader["CLIENT_ID"].ToString();
                                string fName = reader["CLIENT_FNAME"].ToString();
                                string midIntl = reader["CLIENT_MIDINTL"].ToString();
                                string lName = reader["CLIENT_LNAME"].ToString();
                                DateTime dateRgstrd = Convert.ToDateTime(reader["CLIENT_DATE_RGSTRD"]);
                                string balanceStr = reader["CLIENT_BALANCE"].ToString();

                                lblAccNum.Text = accNmbr;
                                lblName.Text = fName + " " + midIntl + ". " + lName;

                                // displays only the date excluding time                         
                                string formattedDateRgstrd = dateRgstrd.ToString("MM-dd-yyyy");
                                lblDateRgstrd.Text = formattedDateRgstrd;

                                // convert the balanceStr to int for it to be formatted
                                int balanceInt = int.Parse(balanceStr);
                                lblCrntBlnce.Text = "₱" + balanceInt.ToString("N2");
                                string frmttedCrntBlnce = lblCrntBlnce.Text;

                                // session values for first name, middle initial, last name, date registered, current balance, and formatted current balance
                                Session["accountNumber"] = accNmbr;
                                Session["fullName"] = fName + " " + midIntl + ". " + lName;
                                Session["dateRegistered"] = formattedDateRgstrd;
                                Session["currentBalance"] = balanceInt;
                                Session["formattedCurrentBalance"] = frmttedCrntBlnce;
                            }

                        }


                    }
                    // retrieves the trans_send data in TRANSACTION_TBL table
                    using (var db = new SqlConnection(connStr))
                    {
                        db.Open();


                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;

                            // gets the user's total sent money by joining user and transaction table
                            cmd.CommandText = "SELECT SUM(TRANS_SENT) AS TOTAL_SENT FROM CLIENT_TBL, TRANSACTION_TBL " +
                           "WHERE CLIENT_TBL.CLIENT_ID = TRANSACTION_TBL.CLIENT_ID AND CLIENT_TBL.CLIENT_USRNME = @username " +
                           "GROUP BY CLIENT_TBL.CLIENT_ID";
                            cmd.Parameters.AddWithValue("username", username);

                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                string totalSntMnyStr = reader["TOTAL_SENT"].ToString();

                                int totalSntMny = int.Parse(totalSntMnyStr);
                                Session["totalSentMoney"] = "₱" + totalSntMny.ToString("N2");
                                lblTtlSntMny.Text = Session["totalSentMoney"].ToString();

                            }  //  If there's no data in TRANSACTION_TBL table or the the very 1st creation of the table,
                               //  the total sent money will be set to zero
                            else
                            {
                                int totalSntMny = 0;
                                Session["totalSentMoney"] = "₱" + totalSntMny.ToString("N2");
                                lblTtlSntMny.Text = Session["totalSentMoney"].ToString();
                            }

                        }

                    }

                }
            }


            
        }




        protected void btnClientUpdtPrfPic_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientUpdateProfilePicture.aspx");

        }

        protected void btnClientChngPswrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientChangePassword.aspx");

        }

        protected void btnClientDeactAcc_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientConfirmDeactivate.aspx");

        }

        protected void btnClientSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            // Remove the pages from the history stack
            Response.Clear();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            // Add a JavaScript code to manipulate the browser history
            Response.Write("<script>window.location.replace('ClientSignIn.aspx');</script>");
            Response.End();
        }

    }
}