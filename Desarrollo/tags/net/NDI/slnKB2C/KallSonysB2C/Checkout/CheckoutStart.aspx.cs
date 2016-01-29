using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KallSonysB2C.Checkout
{
  public partial class CheckoutStart : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //NVPAPICaller payPalCaller = new NVPAPICaller();
        string retMsg = "CheckoutReview.aspx";
     // string token = "";

      if (Session["payment_amt"] != null)
      {
        string amt = Session["payment_amt"].ToString();

       

        Response.Redirect(retMsg);
      }
      else
      {
        Response.Redirect("CheckoutError.aspx?ErrorCode=AmtMissing");
      }
    }
  }
}