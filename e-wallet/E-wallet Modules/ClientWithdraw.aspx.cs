using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace E_wallet.E_wallet_Modules
{
    public partial class Withdraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accNmbr = Session["accountNumber"].ToString();
            string fullName = Session["fullName"].ToString();
            string dateRgstrd = Session["dateRegistered"].ToString();
            string crntBlnce = Session["formattedCurrentBalance"].ToString();
            string totalSntMny = Session["totalSentMoney"].ToString();

            if (!IsPostBack)
            {
                lblAccNum.Text = accNmbr;
                lblName.Text = fullName;
                lblDateRgstrd.Text = dateRgstrd;
                lblCrntBlnce.Text = crntBlnce;
                lblTtlSntMny.Text = totalSntMny;
            }
            else
            {
                lblAccNum.Text = accNmbr;
                lblName.Text = fullName;
                lblDateRgstrd.Text = dateRgstrd;
                lblCrntBlnce.Text = crntBlnce;
                lblTtlSntMny.Text = totalSntMny;
            }
        }
        protected void btnWthdrwMny_Click(object sender, EventArgs e)
        {
            string balance = Session["currentBalance"].ToString();
            int crntBlnce = int.Parse(balance);

            // check if the user entered an amount otherwise display make sure to enter an amount
            if (txtWthdrwMoney.Text != "")
            {
                //if the inputted amount is int, this will execute else prompt invalid amount input
                if (Session["withdrawMoney"] != null && int.TryParse(Session["withdrawMoney"].ToString(), out int wthdrwMnyIntParse) && wthdrwMnyIntParse > 0)
                {
                    if (wthdrwMnyIntParse > 10000)
                    {
                        lblWthdrwAmntInvalid.Text = "Maximum Amount To Be Withdrawn Is ₱10,000.00!";

                        // clears the entered amount after it encounters an invalid amount
                        txtWthdrwMoney.Text = string.Empty;
                    }
                    else if (wthdrwMnyIntParse < 100)
                    {
                        lblWthdrwAmntInvalid.Text = "Minimum Amount To Be Withdrawn Is ₱100.00!";
                        txtWthdrwMoney.Text = string.Empty;

                    }
                    else if (wthdrwMnyIntParse % 100 != 0)
                    {
                        lblWthdrwAmntInvalid.Text = "Amount To Be Withdrawn Must Be Divisible By ₱100.00!";
                        txtWthdrwMoney.Text = string.Empty;

                    }
                    else if (crntBlnce - wthdrwMnyIntParse < 0)
                    {
                        lblWthdrwAmntInvalid.Text = "Insufficent Funds!";
                        txtWthdrwMoney.Text = string.Empty;

                    }
                    else
                    {
                        Response.Redirect("ClientConfirmWithdraw.aspx");

                    }
                }
                else
                {
                    lblWthdrwAmntInvalid.Text = "Please Enter A Valid Amount!";
                    txtWthdrwMoney.Text = string.Empty;

                }
            }
            else
            {
                lblWthdrwAmntInvalid.Text = "Withdrawal failed! Make sure to enter an amount.";
            }

        }
       
        protected void txtWthdrwMoney_TextChanged(object sender, EventArgs e)
        {
            Session["withdrawMoney"] = txtWthdrwMoney.Text;  // gets the not formatted money for it to be converted into int

            if (int.TryParse(txtWthdrwMoney.Text, out int amount))
            {
                txtWthdrwMoney.Text = amount.ToString("N2");
        
            }

            // clears all the error messages when new format for amount is generated or when the user inputs again
            lblWthdrwAmntInvalid.Text = string.Empty;

            // display the updated when the money format is generated
            lblCrntBlnce.Text = Session["formattedCurrentBalance"].ToString();

        }
    }
}