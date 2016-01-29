using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Text;
using KB2C.DTO;
using KB2C.Business;
using KallSonysB2C.Models;
using KallSonysB2C.Logic;

namespace KallSonysB2C
{
    public partial class DealsDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                
            }
        }

        public List<CampaniasDTO> GetDeal(
                        [QueryString("dealName")] int? IdCampania,
                        [RouteData] string dealName)
        {

            //Por Session.
            List<CampaniasDTO> listaCampanias = (List<CampaniasDTO>)Session["sesListaCampanias"];
            List<CampaniasDTO> listaCamp = new List<CampaniasDTO>();
            if (listaCampanias != null)
            {
                foreach (var unProducto in listaCampanias)
                {
                    if (unProducto.IdCampania == int.Parse(dealName))
                    {
                        listaCamp.Add(unProducto);
                        break;

                    }
                }
            }

            return listaCamp;
        }

        protected void lnkAddToCart_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            int idCampania = Convert.ToInt32(link.CommandArgument);

            using (ShoppingCartActions actions = new ShoppingCartActions())
            {
                if (actions.AddToCart(idCampania, "C"))
                {
                    Response.Redirect("~/ShoppingCart.aspx");
                }
                else
                {
                    //aca debe colocarse la validación que no se puede agregar más items al carro
                    KallSonysB2C.Logic.MessageBox.Show(actions.msjErrorAddingToCart);
                }
            }
        }
    }
}