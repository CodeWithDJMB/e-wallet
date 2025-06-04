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
    public partial class AdminChangePassword : System.Web.UI.Page
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
                            cmd.CommandText = "SELECT COUNT(*) FROM ADMIN_TBL WHERE ADMIN_ID = @accNmbr";
                            cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                            int existingAccNum = (int)cmd.ExecuteScalar();

                            if (existingAccNum > 0)  // checks if an account number exists
                            {


                                cmd.CommandText = "SELECT COUNT(*) FROM ADMIN_TBL WHERE ADMIN_USRNME = @username";
                                cmd.Parameters.AddWithValue("@username", username);

                                int existingUser = (int)cmd.ExecuteScalar();

                                if (existingUser > 0)  // checks if a username exists and matches the account number
                                {


                                    cmd.CommandText = "SELECT COUNT(*) FROM ADMIN_TBL WHERE ADMIN_PSWRD = @crntPswrd";
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
                                                cmd.CommandText = "UPDATE ADMIN_TBL SET ADMIN_PSWRD = @newPswrd WHERE ADMIN_ID = @accNmbr";
                                                cmd.Parameters.AddWithValue("@newPswrd", newPswrd);
                                                cmd.Parameters.AddWithValue("@accNmbr", accNmbr);

                                                var ctr = cmd.ExecuteNonQuery();

                                                if (ctr >= 1)
                                                {
                                                    Response.Write("<script>alert('Successfully changed password!')</script>");
                                                }
                                                else
                                                {
                                                    Response.Write("<script>alert('Failed to change password!')</script>");
                                                }
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('confirm new password does not match!')</script>");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('New password must not be the same with the current password!')</script>");
                                        }

                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Wrong current password!')</script>");
                                    }
                                }
                                else
                                {
                                    // username is correct, but the password is not
                                    Response.Write("<script>alert('Username does not exist!')</script>");
                                }
                            }
                            else
                            {
                                // checks non-registered user 
                                Response.Write("<script>alert('Account number does not exist')</script>");
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
                Response.Write("<script>alert('Change password failed! Make sure to fill out all the fields.')</script>");

            }
        }

        protected void btnChangePswrdBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}