using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2C.WebApp.App_Start;

namespace B2C.WebApp
{
    public partial class VerCarroCompras : System.Web.UI.Page
    {        
              protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }

        protected void BindData()
        {
            gvCaritoCompras.DataSource = CarroCompras.CapturarProducto().ListaProductos;
            gvCaritoCompras.DataBind();
        }

        protected void gvCaritoCompras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "Total: " + CarroCompras.CapturarProducto().SubTotal().ToString("C");
            }
        }

        protected void gvCaritoCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Eliminar")
            //{
            //    int productId = Convert.ToInt32(e.CommandArgument);
            //    CarroCompras.CapturarProducto().EliminarProductos(productId);
            //}
            //BindData();
        }

        protected void btActulizar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCaritoCompras.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        int productoId = Convert.ToInt32(gvCaritoCompras.DataKeys[row.RowIndex].Value);
                        int cantidad = int.Parse(((TextBox)row.Cells[1].FindControl("txtCantidad")).Text);
                        //CarroCompras.CapturarProducto().CantidadDeProductos(productoId, cantidad);
                    }
                    catch (FormatException) { }
                }
            }
            BindData();
        }
            
    }
}