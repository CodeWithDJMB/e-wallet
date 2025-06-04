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
    public partial class AdminSignIn : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;
            Session["username"] = username;


            if (username != "" && password != "")
            {
                {

                    using (var db = new SqlConnection(connStr))
                    {
                        db.Open();

                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.CommandText = "SELECT COUNT(*) FROM ADMIN_TBL WHERE ADMIN_USRNME = @username";
                            cmd.Parameters.AddWithValue("@username", username);

                            int existingUsrnm = (int)cmd.ExecuteScalar();

                            if (existingUsrnm > 0)  // checks if a username exists
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "SELECT COUNT(*) FROM ADMIN_TBL WHERE ADMIN_USRNME = @username AND ADMIN_PSWRD = @password";
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.Parameters.AddWithValue("@password", password);

                                int matchingPswrd = (int)cmd.ExecuteScalar();

                                if (matchingPswrd > 0) // username is correct, but check if the username matches with the password
                                {
                                    // both username and password are correct
                                    Response.Redirect("AdminDashboard.aspx");
                                }
                                else
                                {
                                    // username is correct, but the password is not
                                    Response.Write("<script>alert('Wrong password!')</script>");
                                }
                            }
                            else
                            {
                                // checks non-registed user 
                                Response.Write("<script>alert('Account does not exist!')</script>");
                            }
                        }

                    }
                }

            }
            else
            {
                Response.Write("<script>alert('Sign in failed! Make sure you fill out all the fields.')</script>");

            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSignUp.aspx");
        }
    }
}