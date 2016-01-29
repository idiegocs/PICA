using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KB2C.DTO;
using KB2C.Business.Interface;
using Microsoft.Practices.Unity;

namespace KallSonysB2C.UserOrders
{
    public partial class OrderList : System.Web.UI.Page
    {
        [Dependency]
        public IBusiness.IOrdenBL objOrden { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                loadEstadoOrden();
                //cargarOrdenes();
                txtPreOrden.Focus();
            }
        }

        void cargarOrdenes()
        {
            List<OrdenDTO> listaOrdenes = new List<OrdenDTO>();
            //OrdenBL obj = new OrdenBL();
            ClienteDTO cliente = new ClienteDTO();

            string estadoOrden;
            int idPreOrden;
            cliente.nombre = Context.User.Identity.Name;
            cliente.nombreUsuario = Context.User.Identity.Name;
            cliente.correoElectronico = Context.User.Identity.Name;
            if (rdbPreOrden.Checked)
            {
                idPreOrden = Convert.ToInt32(txtPreOrden.Text);
                estadoOrden = "";
            }
            else
            {
                estadoOrden = ddlEstadoOrden.SelectedItem.Text.Trim();
                idPreOrden = -1;
            }
            try
            {
                //listaOrdenes = obj.ConsultarOrdenesUsuario(-1, cliente);
                listaOrdenes = objOrden.ConsultarOrdenesUsuario(idPreOrden, cliente, estadoOrden);
            }
            catch (Exception e)
            {
                KallSonysB2C.Logic.MessageBox.Show("Error Al Consultar Ordenes - Intente Nuevamente");
            }

            grvOrdenes.DataSource = listaOrdenes;
            grvOrdenes.DataBind();
        }

        private void loadEstadoOrden()
        {
            ddlEstadoOrden.DataSource = Application["EstadoOrden"];
            ddlEstadoOrden.DataBind();
            ddlEstadoOrden.Items.Insert(0, new ListItem("[Seleccione]", "-1"));
        }

        protected void lnkVerDetalle_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                int index = row.RowIndex; //gets the row index selected
            }
            string idPreOrden = row.Cells[0].Text.ToString();
            Response.Redirect("OrderDetail.aspx?idPreOrden=" + idPreOrden);
        }

        protected void btnBuscarOrdenes_Click(object sender, EventArgs e)
        {
            cargarOrdenes();
            habilitarControles();
        }

        void habilitarControles() 
        {
            if (rdbPreOrden.Checked)
            {
                txtPreOrden.Enabled = true;
                ddlEstadoOrden.Enabled = false;
            }
            else 
            {
                txtPreOrden.Enabled = false;
                ddlEstadoOrden.Enabled = true;
            }
        }

    }
}