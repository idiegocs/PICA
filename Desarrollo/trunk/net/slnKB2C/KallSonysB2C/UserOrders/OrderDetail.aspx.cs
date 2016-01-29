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
    public partial class OrderDetail : System.Web.UI.Page
    {
        [Dependency]
        public IBusiness.IOrdenBL objOrden { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                cargarDetalleOrden(Convert.ToInt32(Request.QueryString["idPreOrden"]));
            }
        }

        void cargarDetalleOrden(int idPreOrden)
        {
            List<OrdenDTO> listaOrdenes = new List<OrdenDTO>();
            //OrdenBL obj = new OrdenBL();
            List<ItemOrdenDTO> lstItem = new List<ItemOrdenDTO>();
            ClienteDTO cliente = new ClienteDTO();
            cliente.nombre = Context.User.Identity.Name;
            cliente.nombreUsuario = Context.User.Identity.Name;
            cliente.correoElectronico = Context.User.Identity.Name;

            //listaOrdenes = obj.ConsultarOrdenesUsuario(idOrden, null);
            listaOrdenes = objOrden.ConsultarOrdenesUsuario(idPreOrden, cliente, "");

            lblTituloDetalle.Text = "Detalle Orden " + idPreOrden.ToString();

            lblNombreUsuario.Text = "";// listaOrdenes[0].usuarioOrden.correoElectronico;
            lblTipoDocumento.Text = "";//listaOrdenes[0].usuarioOrden.tipoDocumento;
            lblNumeroDocumento.Text = "";//listaOrdenes[0].usuarioOrden.numeroDocumento;

            lblDireccion.Text = "";//listaOrdenes[0].usuarioOrden.ubicacionCliente.numeroDireccion;
            lblCiudad.Text = "";//listaOrdenes[0].usuarioOrden.ubicacionCliente.nombreCiudad;
            lblDepartamento.Text = "";//listaOrdenes[0].usuarioOrden.ubicacionCliente.nombreDepartamento;
            lblTelefono.Text = "";//listaOrdenes[0].usuarioOrden.telefono;

            foreach (var orden in listaOrdenes)
            {
                lstItem = orden.listaItemsOrden.ToList();
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