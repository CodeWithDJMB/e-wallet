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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";


        protected void Page_Load(object sender, EventArgs e)
        {

            string username = Session["username"].ToString();

            // check if the highest admin logs in then the add admin control will be visible
            if (username == "admin" || username == "ADMIN")
            {
                aAddAdmin.Visible = true;
            }
            else
            {
                aAddAdmin.Visible = false;
            }

            if (!IsPostBack)
            {
                using (var db = new SqlConnection(connStr))
                {
                    db.Open();

                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "SELECT * FROM ADMIN_TBL WHERE ADMIN_USRNME = @username";
                        cmd.Parameters.AddWithValue("username", username);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            // Retrieve the attribute value from the reader and assign it to the label control

                            if (reader["ADMIN_PROFPIC"] != DBNull.Value)
                            {
                                byte[] pic = (byte[])reader["ADMIN_PROFPIC"];
                                string str = Convert.ToBase64String(pic);
                                updtdProfPic.ImageUrl = "data:image/jpeg;base64," + str;
                                dfltProfPic.Visible = false;

                            }
                            else
                            {
                                updtdProfPic.Visible = false;
                                dfltProfPic.Visible = true;
                            }

                            string accNmbr = reader["ADMIN_ID"].ToString();
                            string fName = reader["ADMIN_FNAME"].ToString();
                            string midIntl = reader["ADMIN_MIDINTL"].ToString();
                            string lName = reader["ADMIN_LNAME"].ToString();
                            DateTime dateRgstrd = Convert.ToDateTime(reader["ADMIN_DATE_RGSTRD"]);

                            lblAccNum.Text = accNmbr;
                            lblName.Text = fName + " " + midIntl + ". " + lName;

                            // displays only the date excluding time                         
                            string formattedDateRgstrd = dateRgstrd.ToString("MM-dd-yyyy");
                            lblDateRgstrd.Text = formattedDateRgstrd;

                            // session values for first name, middle initial, last name, date registered
                            Session["accountNumber"] = accNmbr;
                            Session["fullName"] = fName + " " + midIntl + ". " + lName;
                            Session["dateRegistered"] = formattedDateRgstrd;

                        }
                    }
                }
            }
        }

        protected void btnUpdtPrf_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateProfilePicture.aspx");

        }

        protected void btnChngPswrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminChangePassword.aspx");
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("AdminSignIn.aspx");

        }
    }
}