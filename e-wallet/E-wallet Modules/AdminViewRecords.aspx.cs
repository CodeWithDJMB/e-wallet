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
 
    public partial class AdminViewRecords : System.Web.UI.Page
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programming Projects\ASP WEBFORM\e-wallet\e-wallet\App_Data\DJ Pay.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void btnShowDataNow_Click(object sender, EventArgs e)
        {
            string entityType = drdTypesOfEntity.SelectedValue;

            //  check if there's a selected value in drop down list 
            if (entityType == "Admins" || entityType == "Clients" || entityType == "Transactions")
            {
                btnShowDataNow.Enabled = true;
                using (var db = new SqlConnection(connStr))
                {
                    db.Open();

                    using (var cmd = db.CreateCommand())
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);


                        if (entityType == "Admins")
                        {
                            cmd.CommandText = "SELECT ADMIN_ID, ADMIN_USRNME, ADMIN_PSWRD, ADMIN_DATE_RGSTRD, ADMIN_FNAME, ADMIN_MIDINTL, ADMIN_LNAME," +
                                " ADMIN_GENDER, ADMIN_PHNO, ADMIN_ADRS, ADMIN_EMLADRS FROM ADMIN_TBL";

                            sda.Fill(dt);
                            grdAdminData.DataSource = dt;
                            grdAdminData.DataBind();

                            int ctr = grdAdminData.Rows.Count;

                            if (ctr >= 1)
                            {
                                // clears all the displayed table for other entity table when Admin entity type is clicked
                                grdClientData.DataSource = null;
                                grdClientData.DataBind();

                                grdTransactionData.DataSource = null;
                                grdTransactionData.DataBind();

                            }
                            else
                            {
                                Response.Write("<script>alert('No records found!')</script>");
                            }
                        }
                        else if (entityType == "Clients")
                        {
                            cmd.CommandText = "SELECT CLIENT_ID, CLIENT_USRNME, CLIENT_PSWRD, CLIENT_DATE_RGSTRD, CLIENT_BALANCE, CLIENT_STATUS, CLIENT_FNAME, CLIENT_MIDINTL, CLIENT_LNAME," +
                                 " CLIENT_GENDER, CLIENT_PHNUM, CLIENT_ADRS, CLIENT_EMLADRS FROM CLIENT_TBL";

                            sda.Fill(dt);
                            grdClientData.DataSource = dt;
                            grdClientData.DataBind();

                            int ctr = grdClientData.Rows.Count;

                            if (ctr >= 1)
                            {
                                // clears all the displayed table for other entity table when Client entity type is clicked
                                grdAdminData.DataSource = null;
                                grdAdminData.DataBind();

                                grdTransactionData.DataSource = null;
                                grdTransactionData.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>alert('No records found!')</script>");
                            }


                        }
                        else if (entityType == "Transactions")
                        {
                            cmd.CommandText = "SELECT TRANS_ID, TRANS_DEPOSIT, TRANS_WITHDRAW, TRANS_SENT, TRANS_RECEIVE, TRANS_DATE, TRANSACTION_TBL.CLIENT_ID " +
                                 "FROM TRANSACTION_TBL";

                            sda.Fill(dt);
                            grdTransactionData.DataSource = dt;
                            grdTransactionData.DataBind();

                            int ctr = grdTransactionData.Rows.Count;

                            if (ctr >= 1)
                            {
                                // clears all the displayed table for other entity table when Transaction entity type is clicked
                                grdAdminData.DataSource = null;
                                grdAdminData.DataBind();

                                grdClientData.DataSource = null;
                                grdClientData.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>alert('No records found!')</script>");
                            }

                        }

                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Select table first!')</script>");
            }

        }

        protected void btnShowSpcfcRcrd_Click(object sender, EventArgs e)
        {
            string entityType = drdTypesOfEntity.SelectedValue;
            string idStr = txtId.Text;

            //  check if there's a selected value in drop down list 
            if (entityType == "Admin" || entityType == "Client" || entityType == "Transaction")
            {
                if (idStr != "")
                {
                    if (int.TryParse(idStr, out int id) && id > 0)
                    {
                        using (var db = new SqlConnection(connStr))
                        {
                            db.Open();

                            using (var cmd = db.CreateCommand())
                            {
                                DataTable dt = new DataTable();
                                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                                if (entityType == "Admin")
                                {
                                    cmd.CommandText = "SELECT ADMIN_ID, ADMIN_USRNME, ADMIN_PSWRD, ADMIN_DATE_RGSTRD, ADMIN_FNAME, ADMIN_MIDINTL, ADMIN_LNAME," +
                                        " ADMIN_GENDER, ADMIN_PHNO, ADMIN_ADRS, ADMIN_EMLADRS FROM ADMIN_TBL " +
                                        "WHERE ADMIN_ID = @id";
                                    cmd.Parameters.AddWithValue("@id", id);

                                    sda.Fill(dt);
                                    grdAdminData.DataSource = dt;
                                    grdAdminData.DataBind();

                                    int ctr = grdAdminData.Rows.Count;

                                    if (ctr >= 1)
                                    {
                                        // clears all the displayed table for other entity table when Admin entity type is clicked
                                        grdClientData.DataSource = null;
                                        grdClientData.DataBind();

                                        grdTransactionData.DataSource = null;
                                        grdTransactionData.DataBind();

                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('No records found!')</script>");
                                    }
                                }
                                else if (entityType == "Client")
                                {
                                    cmd.Parameters.Clear();
                                    cmd.CommandText = "SELECT CLIENT_ID, CLIENT_USRNME, CLIENT_PSWRD, CLIENT_DATE_RGSTRD, CLIENT_BALANCE, CLIENT_STATUS, CLIENT_FNAME, CLIENT_MIDINTL, CLIENT_LNAME," +
                                         " CLIENT_GENDER, CLIENT_PHNUM, CLIENT_ADRS, CLIENT_EMLADRS FROM CLIENT_TBL " +
                                         "WHERE CLIENT_ID = @id";
                                    cmd.Parameters.AddWithValue("@id", id);

                                    sda.Fill(dt);
                                    grdClientData.DataSource = dt;
                                    grdClientData.DataBind();

                                    int ctr = grdClientData.Rows.Count;

                                    if (ctr >= 1)
                                    {
                                        // clears all the displayed table for other entity table when Client entity type is clicked
                                        grdAdminData.DataSource = null;
                                        grdAdminData.DataBind();

                                        grdTransactionData.DataSource = null;
                                        grdTransactionData.DataBind();
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('No records found!')</script>");
                                    }


                                }
                                else if (entityType == "Transaction")
                                {
                                    cmd.Parameters.Clear();
                                    cmd.CommandText = "SELECT TRANS_ID, TRANS_DEPOSIT, TRANS_WITHDRAW, TRANS_SENT, TRANS_RECEIVE, TRANS_DATE, TRANSACTION_TBL.CLIENT_ID " +
                                         "FROM TRANSACTION_TBL " +
                                    "WHERE TRANS_ID = @id";
                                    cmd.Parameters.AddWithValue("@id", id);

                                    sda.Fill(dt);
                                    grdTransactionData.DataSource = dt;
                                    grdTransactionData.DataBind();

                                    int ctr = grdTransactionData.Rows.Count;

                                    if (ctr >= 1)
                                    {
                                        // clears all the displayed table for other entity table when Transaction entity type is clicked
                                        grdAdminData.DataSource = null;
                                        grdAdminData.DataBind();

                                        grdClientData.DataSource = null;
                                        grdClientData.DataBind();
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('No records found!')</script>");
                                        txtId.Text = String.Empty;
                                    }

                                }

                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please enter a valid ID!')</script>");
                        txtId.Text = String.Empty;
                    }
                }

                else
                {
                    Response.Write("<script>alert('Enter ID first!')</script>");

                }

                
            }
            else
            {
                Response.Write("<script>alert('Select table first!')</script>");

            }


        }
    }
}