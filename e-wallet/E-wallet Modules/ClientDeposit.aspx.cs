using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace E_wallet.E_wallet_Modules
{
    public partial class Deposit : System.Web.UI.Page
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

        protected void btnDpstMny_Click(object sender, EventArgs e)
        {
            string balance = Session["currentBalance"].ToString();
            int crntBlnce = int.Parse(balance);

            // check if the user entered an amount otherwise display make sure to enter an amount
            if (txtDpstMoney.Text != "")
            {
                //if the inputted amount is int, this will execute otherwise prompt invalid amount input
                if (Session["depositMoney"] != null && int.TryParse(Session["depositMoney"].ToString(), out int dpstMnyIntParse) && dpstMnyIntParse > 0)
                {
                    if (dpstMnyIntParse > 50000)
                    {
                        lbldpstAmntInvalid.Text = "Maximum Amount To Be Deposit Is ₱50,000.00!";

                        // clears the entered amount after it encounters an invalid amount
                        txtDpstMoney.Text = string.Empty;
                    }
                    else if (dpstMnyIntParse < 100)
                    {
                        lbldpstAmntInvalid.Text = "Minimum Amount To Be Deposit Is ₱100.00!";
                        txtDpstMoney.Text = string.Empty;
                    }
                    else if (dpstMnyIntParse % 100 != 0)
                    {
                        lbldpstAmntInvalid.Text = "Amount To Be Deposit Must Be Divisible By ₱100.00!";
                        txtDpstMoney.Text = string.Empty;
                    }
                    else if (crntBlnce > 50000)
                    {
                        lbldpstAmntInvalid.Text = "Current Balance Must Not Exceed ₱50,000.00!";
                        txtDpstMoney.Text = string.Empty;
                    }
                    else
                    {
                        Response.Redirect("ClientConfirmDeposit");
                    }
                }
                else
                {
                    lbldpstAmntInvalid.Text = "Please Enter A Valid Amount!";
                    txtDpstMoney.Text = string.Empty;
                }

            }
            else
            {
                lbldpstAmntInvalid.Text = "Deposit failed! Make sure to enter an amount.";
            }


        }


        protected void txtDpstMoney_TextChanged(object sender, EventArgs e) // formats the amount inputted into Php
        {
            Session["depositMoney"] = txtDpstMoney.Text;  // gets the not formatted money for it to be converted into int
            if (int.TryParse(txtDpstMoney.Text, out int amount))
            {
                txtDpstMoney.Text = amount.ToString("N2");
            }
            // clears all the error messages when new format for amount is generated or when the user inputs again
            lbldpstAmntInvalid.Text = string.Empty;

            // display the updated when the money format is generated
            lblCrntBlnce.Text = Session["formattedCurrentBalance"].ToString();

        }
      
    }
}
