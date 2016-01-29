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
    public partial class OrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack==false)
            {
                cargarDetalleOrden(Convert.ToInt32(Request.QueryString["idOrden"]));
            }
        }

        void cargarDetalleOrden(int idOrden) 
        {
            List<OrdenDTO> listaOrdenes = new List<OrdenDTO>();
            OrdenBL obj = new OrdenBL();
            List<ItemOrdenDTO> lstItem = new List<ItemOrdenDTO>();

            listaOrdenes = obj.ConsultarOrdenesUsuario(idOrden, null);

            lblTituloDetalle.Text = "Detalle Orden " + idOrden.ToString();

            lblNombreUsuario.Text = listaOrdenes[0].usuarioOrden.correoElectronico;
            lblTipoDocumento.Text = listaOrdenes[0].usuarioOrden.tipoDocumento;
            lblNumeroDocumento.Text = listaOrdenes[0].usuarioOrden.numeroDocumento;

            lblDireccion.Text = listaOrdenes[0].usuarioOrden.ubicacionCliente.numeroDireccion;
            lblCiudad.Text = listaOrdenes[0].usuarioOrden.ubicacionCliente.nombreCiudad;
            lblDepartamento.Text = listaOrdenes[0].usuarioOrden.ubicacionCliente.nombreDepartamento;
            lblTelefono.Text = listaOrdenes[0].usuarioOrden.telefono;

            foreach (var item in listaOrdenes)
            {
                lstItem = item.listaItemsOrden.ToList();
            }

            grvDetalleOrden.DataSource = lstItem.ToList();
            grvDetalleOrden.DataBind();

        }
        
        protected void lnkVolverListaOrdenes_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderList.aspx");
        }
    }
}