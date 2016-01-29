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
            ProductoBL objProd = new ProductoBL();
            Parametros p = new Parametros();

            int IdProducto = 0;

            if (listaProductos != null)
            {
                foreach (var unProducto in listaProductos)
                {
                    if (unProducto.idProducto == productId)
                    {
                        listaPro.Add(unProducto);
                        IdProducto = Convert.ToInt32(unProducto.idProducto);
                        break;

                    }
                }

                if (listaPro.Count == 0)
                {
                    StringBuilder vIdProd = new StringBuilder();
                    vIdProd.Append("|");
                    vIdProd.Append(productId.ToString());
                    vIdProd.Append("|");

                    listaPro = objProd.listaProductos(p.FiltroxId, vIdProd.ToString(), 1);
                }

                productDetail.DataSource = listaPro.ToList();
                productDetail.DataBind();
                cargarTop5(productId);
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

        private void cargarTop5(int IdProducto) 
        {
            List<ProductoTop5DTO> listaTop5 = new List<ProductoTop5DTO>();
            List<ProductosDTO> listaProductos = new List<ProductosDTO>();
            Parametros p = new Parametros();
            StringBuilder sbProd = new StringBuilder();
            ProductoBL objTop5 = new ProductoBL();
            ProductoBL objProd = new ProductoBL();

            listaTop5 = objTop5.consultarTop5(IdProducto);
            int cant = listaTop5.Count();
            int index = 0;
            
            if (cant > 0)
            {
                foreach (var item in listaTop5)
	            {
                    sbProd.Append("|");
                    sbProd.Append(item.idProducto.ToString());
                    index++;
	            }
                sbProd.Append("|");
                //debe quedar asi: |prod1|prod2|prod3|
            }
            string vProductos = sbProd.ToString();
            listaProductos = objProd.listaProductos(p.FiltroxId, vProductos, 1);
            listTop5.DataSource = listaProductos.ToList();
            listTop5.DataBind();
        }

        protected void lnkAddToCart5_Click(object sender, EventArgs e)
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