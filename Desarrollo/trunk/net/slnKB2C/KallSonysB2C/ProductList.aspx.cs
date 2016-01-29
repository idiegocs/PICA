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
using KB2C.Business.Interface;
using KallSonysB2C.Logic;
using KallSonysB2C.Models;
using Microsoft.Practices.Unity;

namespace KallSonysB2C
{
    public partial class ProductList : System.Web.UI.Page
    {
        [Dependency]
        public IBusiness.IProductoBL objProd { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                cargarProductos(false);
            }
        }

        void cargarProductos(Boolean filtro)
        {
            String parametroCategoria = null;

            if (!filtro)
            {
                try
                {
                    //Se toma el parametro de la categoria, si se va a filtrar por categoria
                    parametroCategoria = (String)HttpContext.Current.Request.RequestContext.RouteData.Values["categoryName"];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error cargarProductos " + e.Message);
                    parametroCategoria = null;
                }
            }


            Session.Add("sesListaProductos", GetProducts(null, parametroCategoria));
        }

        public List<ProductosDTO> GetProducts(
                            [QueryString("id")] int? categoryId,
                            [RouteData] string categoryName)
        {
            //ProductoBL obj = new ProductoBL();
            Parametros p = new Parametros();
            List<ProductosDTO> listaProductos = new List<ProductosDTO>();

            try
            {
                if (categoryName == null)
                {
                    string x = ddlTipoFiltro.SelectedItem.Value;
                    string y = txtValorFiltro.Text.Trim();
                    // si se listo producto
                    listaProductos = objProd.listaProductos(x, y, 1);
                    //listaProductos = objProd.ConsultarProductosDetalle(x, y);
                }
                else
                {
                    // si se filtro por categoria
                    listaProductos = objProd.listaProductos("S", categoryName, 1);
                    //listaProductos = objProd.ConsultarProductosDetalle("S", categoryName);
                }
            }
            catch (Exception e)
            {
                KallSonysB2C.Logic.MessageBox.Show("Error Al Consultar Productos - Intente Nuevamente");
            }

            return listaProductos;
        }

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            this.productList.DataSource = Session["sesListaProductos"];
            this.productList.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarProductos(true);
            DataPagerProducts.SetPageProperties(0, DataPagerProducts.MaximumRows, true);
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