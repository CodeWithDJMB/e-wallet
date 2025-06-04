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
    public partial class UserSignIn : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsrnme.Text;
            string password = txtPassword.Text;
            Session["username"] = username;
            txtUsrnme.Text = string.Empty;
            txtPassword.Text = string.Empty;

            if (username != "" && password != "") {
                {

                    using (var db = new SqlConnection(connStr))
                    {
                        db.Open();

                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            
                            cmd.CommandText = "SELECT * FROM CLIENT_TBL WHERE CLIENT_USRNME = @username";
                            cmd.Parameters.AddWithValue("@username", username);

                            SqlDataReader reader = cmd.ExecuteReader();

                            // check if the account is Active, Suspended, and Deactivated
                            if (reader.Read())
                            {
                                if (reader["CLIENT_STATUS"].ToString() == "Deactivated")
                                {
                                    Response.Write("<script>alert('Cannot Sign In! Account is deactivated.')</script>");
                                }
                                else if (reader["CLIENT_STATUS"].ToString() == "Suspended")
                                {
                                    Response.Write("<script>alert('Cannot Sign In! Account is suspended.')</script>");
                                }
                                else
                                {
                                    reader.Close();

                                    cmd.Parameters.Clear();
                                    cmd.CommandText = "SELECT COUNT(*) FROM CLIENT_TBL WHERE CLIENT_USRNME = @username";
                                    cmd.Parameters.AddWithValue("@username", username);

                                    int existingUsrnm = (int)cmd.ExecuteScalar();


                                    if (existingUsrnm > 0)  // checks if a username exists
                                    {
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "SELECT COUNT(*) FROM CLIENT_TBL WHERE CLIENT_USRNME = @username AND CLIENT_PSWRD = @password";
                                        cmd.Parameters.AddWithValue("@username", username);
                                        cmd.Parameters.AddWithValue("@password", password);

                                        int matchingPswrd = (int)cmd.ExecuteScalar();

                                        if (matchingPswrd > 0) // username is correct, but check if the username matches with the password
                                        {
                                            // both username and password are correct
                                            Response.Redirect("ClientDashboard.aspx");
                                        }
                                        else
                                        {
                                            // username is correct, but the password is not
                                            Response.Write("<script>alert('Wrong password!')</script>");
                                        }
                                    }
                                    
                                }
                            }
                            else
                            {
                                // checks non-registed user 
                                Response.Write("<script>alert('Account Does Not Exist')</script>");
                            }

                        }

                    }
                }
                
            }
            else
            {
                Response.Write("<script>alert('Sign In Failed! Make Sure You Fill Out All The Fields.')</script>");

            }   
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ClientSignUp.aspx");
        }     
    }
}