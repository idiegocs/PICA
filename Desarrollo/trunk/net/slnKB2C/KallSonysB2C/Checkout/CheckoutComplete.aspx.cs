using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KallSonysB2C.Models;

namespace KallSonysB2C.Checkout
{
  public partial class CheckoutComplete : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
       
          this.TransactionIDLabel.Text = Session["payerId"].ToString();
          
      }
    }

    protected void Continue_Click(object sender, EventArgs e)
    {
      Response.Redirect("~/Default.aspx");
    }
  }
}