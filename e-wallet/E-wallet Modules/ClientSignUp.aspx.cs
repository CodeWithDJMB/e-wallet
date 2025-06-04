using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
// we imported this so that we can use .ToTitleCase() method
using System.Globalization;
// we imported this so that we can use filepath
using System.IO;




namespace E_wallet.E_wallet_Modules
{
    public partial class UserSignUp : System.Web.UI.Page
    {
  
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccFinish_Click(object sender, EventArgs e)
        {
            // all uppercase letter cant't be converted to title case that's why we use to lower to convert it into title case
            string fName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCrtFname.Text.ToLower());
            string midIntl = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCrtMidIntl.Text.ToLower());
            string lName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCrtFamName.Text.ToLower());
            string gender = drdCrtGender.SelectedValue;
            string phNo = txtCrtPhNum.Text;
            string adrs = txtCrtAdrs.Text;
            string emlAdrs = txtCrtEmlAdrs.Text;
            string username = txtCrtUsrnm.Text;
            string password = txtCrtPswrd.Text;
            string cnfrmPswrd = txtCnfrmCrtPswrd.Text;
            string dateRgstrd = DateTime.Now.ToString("MM-dd-yyyy");


            if (fName != "" && midIntl != "" && lName != "" && gender != "" && phNo != "" && adrs != "" && emlAdrs != "" && username != "" && password != "" && cnfrmPswrd != "")
            {
                string midIntlWithDot = txtCrtMidIntl.Text + ".";  // automatically add last "." character to inputted Middle Initial 
                string phNoWithZero = "0" + txtCrtPhNum.Text; // automatically add first "0" character to inputted Phone Number 
                int balance = 0;  // automatically sets the balance to 0 after signing up 
                if (password == cnfrmPswrd)
                {
                    using (var db = new SqlConnection(connStr))
                    {
                        db.Open();

                        using (var cmd = db.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "SELECT COUNT(*) FROM CLIENT_TBL WHERE CLIENT_USRNME = @username";
                            cmd.Parameters.AddWithValue("@username", username);

                            int existingUserCount = (int)cmd.ExecuteScalar();

                            if (existingUserCount > 0) // checks for existing username
                            {

                                Response.Write("<script>alert('Username is already in use. Please choose a different username.')</script>");
                                return;
                            }
                            else // insert new user in database
                            {

                                cmd.CommandText = "INSERT INTO CLIENT_TBL (CLIENT_FNAME, CLIENT_MIDINTL, CLIENT_LNAME, CLIENT_GENDER, CLIENT_PHNUM," +
                                                  " CLIENT_ADRS, CLIENT_EMLADRS, CLIENT_USRNME, CLIENT_PSWRD, CLIENT_DATE_RGSTRD, CLIENT_BALANCE)"
                                               + " VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11)";

                                cmd.Parameters.AddWithValue("@1", fName);
                                cmd.Parameters.AddWithValue("@2", midIntlWithDot);
                                cmd.Parameters.AddWithValue("@3", lName);
                                cmd.Parameters.AddWithValue("@4", gender);
                                cmd.Parameters.AddWithValue("@5", phNoWithZero);
                                cmd.Parameters.AddWithValue("@6", adrs);
                                cmd.Parameters.AddWithValue("@7", emlAdrs);
                                cmd.Parameters.AddWithValue("@8", username);
                                cmd.Parameters.AddWithValue("@9", password);
                                cmd.Parameters.AddWithValue("@10", dateRgstrd);
                                cmd.Parameters.AddWithValue("@11", balance);


                                var ctr = cmd.ExecuteNonQuery();
                                if (ctr >= 1)
                                {
                                    Response.Write("<script>alert('Account Succesfully Created!')</script>");

                                }
                                else
                                {
                                    Response.Write("<script>alert('Failed to Create Account!')</script>");

                                }

                            }
                        }

                    }

                }
                else
                {
                    Response.Write("<script>alert('Confirm Password Does Not Match!')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Failed to Create Account! Make Sure You Fill Out All The Fields.')</script>");
            }

        }

        protected void btnCreateAccBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientSignIn.aspx");
        }
    }
}