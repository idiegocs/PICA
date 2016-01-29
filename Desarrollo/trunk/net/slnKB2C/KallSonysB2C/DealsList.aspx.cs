using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.ModelBinding;
using System.Web.Routing;
using KB2C.DTO;
using KB2C.Business;
using KallSonysB2C.Models;
using KallSonysB2C.Logic;
using KB2C.Business.Interface;
using Microsoft.Practices.Unity;

namespace KallSonysB2C
{
    public partial class DealsList : System.Web.UI.Page
    {
        [Dependency]
        public IBusiness.ICampaniaBL objCampania { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                cargarCampanias();
            }
        }

        void cargarCampanias()
        {
            //CampaniaBL obj = new CampaniaBL();
            List<CampaniasDTO> lstProdxCamp = new List<CampaniasDTO>();
            try
            {
                //lstProdxCamp = obj.listaCampanias();
                lstProdxCamp = objCampania.listaCampanias();
                lstDealsList.DataSource = lstProdxCamp;
                Session.Add("sesListaCampanias", lstProdxCamp);
                lstDealsList.DataBind();
            }
            catch (Exception e)
            {
                KallSonysB2C.Logic.MessageBox.Show("No hay campañas disponibles..!");
            }
        }

        protected void lnkAddToCart_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            int idCampania = Convert.ToInt32(link.CommandArgument);

            using (ShoppingCartActions actions = new ShoppingCartActions())
            {
                if (actions.AddToCart(idCampania, "C"))
                {
                    Response.Redirect("ShoppingCart.aspx");
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