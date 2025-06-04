using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace E_wallet.E_wallet_Modules
{
    public partial class UpdateProfilePicture : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrvw_Click(object sender, EventArgs e)
        {
            if (fuImgPrfl.HasFile)
            {
                int fileSizeLimit = 10 * 1024 * 1024; // 10 MB limit
                int maxRequestLength = (int)System.Web.Configuration.WebConfigurationManager.GetSection("system.web/httpRuntime").GetType().GetProperty("MaxRequestLength").GetValue(System.Web.Configuration.WebConfigurationManager.GetSection("system.web/httpRuntime"), null);

                if (fuImgPrfl.FileBytes.Length > fileSizeLimit || fuImgPrfl.PostedFile.ContentLength > maxRequestLength)
                {
                    imgPrvw.Visible = false;
                    Response.Write("<script>alert('File size exceeds the limit! Maximum file size is 10 MB.')</script>");
                    return;
                }

                string fileName = Path.GetFileName(fuImgPrfl.FileName);
                string fileExtension = Path.GetExtension(fileName);
                string fileExtnt = fileExtension.ToLower();

                if (fileExtnt == ".jpg" || fileExtnt == ".jpeg" || fileExtnt == ".png" || fileExtnt == ".gif")
                {
                    // read the uploaded file into a byte array
                    byte[] imageBytes = fuImgPrfl.FileBytes;

                    // convert the byte array to a base64 string
                    string base64String = Convert.ToBase64String(imageBytes);

                    // set the preview image source
                    imgPrvw.Visible = true;
                    imgPrvw.ImageUrl = "data:image/jpeg;base64," + base64String;

                    // stores the converted image which is now base64String in session profilePicture
                    Session["profilePicture"] = base64String;
                }
                else
                {
                    imgPrvw.Visible = false;
                    Response.Write("<script>alert('Not an image file!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please upload an image first!')</script>");

            }
        }


        protected void btnUpdtPrflFinish_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string imgFile = Session["profilePicture"].ToString(); 

            using (var db = new SqlConnection(connStr))
            {
                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    
                    byte[] imageBytes = Convert.FromBase64String(imgFile);
                    
                    cmd.CommandText = "UPDATE CLIENT_TBL SET CLIENT_PROFPIC = @imageBytes WHERE CLIENT_USRNME = @username";
                    cmd.Parameters.AddWithValue("@imageBytes", imageBytes);
                    cmd.Parameters.AddWithValue("@username", username);

                    var ctr = cmd.ExecuteNonQuery();

                    if (ctr > 0)
                    {
                        Response.Write("<script>alert('Succesfully updated profile picture!')</script");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to update profile picture!')</script");

                    }
                }
            }
        }   
            
        protected void btnUpdtPfrlBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientDashboard.aspx");
        }
    }
}