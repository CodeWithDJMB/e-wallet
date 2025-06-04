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
    public partial class UserChangePassword : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnChangePswrdFinish_Click(object sender, EventArgs e)
        {
            string accNmbrStr = txtAccNum.Text.ToString();
            string username = txtUsrnm.Text;
            string crntPswrd = txtCrntPswrd.Text;
            string newPswrd = txtNewPswrd.Text;
            string cnfrmNewPswrd = txtNewPswrdCnfrm.Text;

            // checks if the inputted account number is valid 
            if (accNmbrStr != "" && username != "" && crntPswrd != "" && newPswrd != "" && cnfrmNewPswrd != "")
            {
                if (int.TryParse(accNmbrStr, out int accNmbr) && accNmbr > 0)
                {

                    using (var db = new SqlConnection(connStr))
                    {
                        db.Open();

                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "SELECT COUNT(*) FROM CLIENT_TBL WHERE CLIENT_ID = @accNmbr";
                            cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                            int existingAccNum = (int)cmd.ExecuteScalar();

                            if (existingAccNum > 0)  // checks if an account number exists
                            {


                                cmd.CommandText = "SELECT COUNT(*) FROM CLIENT_TBL WHERE CLIENT_USRNME = @username";
                                cmd.Parameters.AddWithValue("@username", username);

                                int existingUser = (int)cmd.ExecuteScalar();

                                if (existingUser > 0)  // checks if a username exists and matches the account number
                                {


                                    cmd.CommandText = "SELECT COUNT(*) FROM CLIENT_TBL WHERE CLIENT_PSWRD = @crntPswrd";
                                    cmd.Parameters.AddWithValue("@crntPswrd", crntPswrd);

                                    int existingPswrd = (int)cmd.ExecuteScalar();

                                    if (existingPswrd > 0)    // checks if a password exists and matches the account number and username
                                    {
                                        if (newPswrd != crntPswrd) // checks if a new password does not matches the current password
                                        {
                                            if (newPswrd == cnfrmNewPswrd)  // checks new password matches confirm new password
                                            {
                                                // update password
                                                cmd.Parameters.Clear(); // Clear the existing parameters before reusing the command for @accNmbr
                                                cmd.CommandText = "UPDATE CLIENT_TBL SET CLIENT_PSWRD = @newPswrd WHERE CLIENT_ID = @accNmbr";
                                                cmd.Parameters.AddWithValue("@newPswrd", newPswrd);
                                                cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                                                var ctr = cmd.ExecuteNonQuery();

                                                if (ctr >= 1)
                                                {
                                                    Response.Write("<script>alert('Successfully Changed Password!')</script>");
                                                }
                                                else
                                                {
                                                    Response.Write("<script>alert('Failed to Change Password!')</script>");
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Confirm New Password Does Not Match!')</script>");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('New Password Must Not Be The Same With The Current Password!')</script>");
                                        }

                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Wrong Current Password!')</script>");
                                    }
                                }
                                else
                                {
                                    // username is correct, but the password is not
                                    Response.Write("<script>alert('Username Does Not Exist!')</script>");
                                }
                            }
                            else
                            {
                                // checks non-registered user 
                                Response.Write("<script>alert('Account Number Does Not Exist')</script>");
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please enter a valid account number.')</script>");

                }

            }
            else
            {
                Response.Write("<script>alert('Change Password Failed! Make Sure You Fill Out All The Fields.')</script>");

            }

        }

        protected void btnChangePswrdBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientDashboard.aspx");
        }
    }
}