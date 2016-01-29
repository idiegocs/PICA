using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB2C.DTO;
using KB2C.Business;

namespace KallSonysB2C.UserOrders
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                cargarOrdenes();
            }
        }

        void cargarOrdenes() 
        {
            List<OrdenDTO> listaOrdenes = new List<OrdenDTO>();
            OrdenBL obj = new OrdenBL();
            ClienteDTO cliente = new ClienteDTO();

            cliente.nombre = "pepito";
            try
            {
                listaOrdenes = obj.ConsultarOrdenesUsuario(-1, cliente);
            }
            catch (Exception e)
            {
                KallSonysB2C.Logic.MessageBox.Show("Error Al Consultar Ordenes - Intente Nuevamente");
            }

            grvOrdenes.DataSource = listaOrdenes;
            grvOrdenes.DataBind();
        }

        /*
        protected void grvOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {

            Response.Redirect("OrderDetail.aspx?idOrden=");
        }
        */
        protected void lnkVerDetalle_Click(object sender, EventArgs e) 
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                int index = row.RowIndex; //gets the row index selected
            }
            string idOrden = row.Cells[0].Text.ToString();
            Response.Redirect("OrderDetail.aspx?idOrden=" + idOrden);
        }
        /*
        public List<OrdenDTO> GetUserOrders() 
        {
            List<OrdenDTO> listaOrdenes = new List<OrdenDTO>();
            OrdenBL obj = new OrdenBL();
            ClienteDTO cliente = new ClienteDTO();

            cliente.nombre = "pepito";

            listaOrdenes = obj.ConsultarOrdenesUsuario(-1, cliente);

            return listaOrdenes;
        }
        */
    }
}