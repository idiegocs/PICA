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
using KallSonysB2C.Logic;
using KallSonysB2C.Models;

namespace KallSonysB2C
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                string IdProducto = (String)HttpContext.Current.Request.RequestContext.RouteData.Values["productId"];
                if (IdProducto != "ShoppingCart")
                {
                    int productId = Convert.ToInt32(IdProducto);
                    cargarProducto(productId);
                }
            }
        }

        void cargarProducto(int productId) 
        {
            List<ProductosDTO> listaProductos = (List<ProductosDTO>)Session["sesListaProductos"];
            List<ProductosDTO> listaPro = new List<ProductosDTO>();
            if (listaProductos != null)
            {
                foreach (var unProducto in listaProductos)
                {
                    if (unProducto.idProducto == productId)
                    {
                        listaPro.Add(unProducto);
                        break;

                    }
                }

                productDetail.DataSource = listaPro.ToList();
                productDetail.DataBind();
            }
        }
       
        protected void lnkAddToCart_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            int idProducto = Convert.ToInt32(link.CommandArgument);

            using (ShoppingCartActions actions = new ShoppingCartActions())
            {
                if (actions.AddToCart(idProducto, "P"))
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