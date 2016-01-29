using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KallSonysB2C.Models;
using KB2C.DTO;
using KB2C.Business;
using System.Web.Services;

namespace KallSonysB2C.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaPais();
                //string PayerID = "";
                string retMsg = Session["payment_amt"].ToString();

                Parametros par = new Parametros();
                ddlAnio.DataSource = par.listaAnioVenceTarjeta();
                ddlAnio.DataBind();
                //ddlAnio.Items.Add(new ListItem("[Seleccione]", "-1",true));
                ddlAnio.Items.Insert(0, new ListItem("[Seleccione]","-1"));
                //ddlAnio.SelectedValue = "-1";

                bool ret = true;

                if (ret)
                {
                    //Session["payerId"] = PayerID;
                    var myOrder = new Order();
                    myOrder.OrderDate = new DateTime();
                    myOrder.Username = User.Identity.Name;
                    myOrder.Total = Convert.ToDecimal(retMsg);

                    // Get the shopping cart items and process them.
                    using (KallSonysB2C.Logic.ShoppingCartActions usersShoppingCart = new KallSonysB2C.Logic.ShoppingCartActions())
                    {
                        List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

                        // Display Order information.
                        List<Order> orderList = new List<Order>();
                        orderList.Add(myOrder);
                        ShipInfo.DataSource = orderList;
                        ShipInfo.DataBind();

                        // Display OrderDetails.
                        OrderItemList.DataSource = myOrderList;
                        OrderItemList.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("CheckoutError.aspx?" + retMsg);
                }
            }
        }

        protected void CheckoutConfirm_Click(object sender, EventArgs ev)
        {
            EstadoCompraDTO estadoCompra = null;
            CompraDTO myOrder = new CompraDTO();

            try
            {
                //LLenar todo el objeto de las ordenes.
                // Get the shopping cart items and process them.
                using (KallSonysB2C.Logic.ShoppingCartActions usersShoppingCart = new KallSonysB2C.Logic.ShoppingCartActions())
                {
                    List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

                    myOrder.envioTitular = false;

                    //datos Tarjeta
                    TarjetaDTO tarjeta = new TarjetaDTO();

                    tarjeta.nombreTitular = this.TextBoxnomTJ.Text;
                    long numeroTrajeta = 0;
                    if (TextBoxNumeroTJ != null && TextBoxNumeroTJ.Text != null)
                    {
                        numeroTrajeta = Convert.ToInt64(TextBoxNumeroTJ.Text);
                    }
                    tarjeta.numeroTarjeta = numeroTrajeta;
                    int codSeg = 0;
                    if (TextBoxCodigoVeri != null && TextBoxCodigoVeri.Text != null)
                    {
                        codSeg = Convert.ToInt32(TextBoxCodigoVeri.Text);
                    }
                    tarjeta.codigoSeguridad = codSeg;
                    DateTime fechaExp = new DateTime();

                    try
                    {
                        //jf
                        //String StrFecha = CalendarExp.Text;
                        String StrFecha = "01/" + ddlMes.SelectedItem.Text + "/" + ddlAnio.SelectedItem.Text;
                        fechaExp = DateTime.ParseExact(StrFecha, "dd/MM/yyyy", null);
                    }
                    catch (Exception e)
                    {
                        Console.Write("Error en fecha " + e);

                    }
                    tarjeta.fechaExpiracion = fechaExp;

                    //se asignan los datos de la tarjeta
                    myOrder.tarjeta = tarjeta;

                    //Fin Datos Tarjeta.

                    //datos Usuario Envio
                    ClienteDTO usuarioEnvio = new ClienteDTO();

                    usuarioEnvio.nombreUsuario = null; //usuario no registrado, datos envio
                    usuarioEnvio.nombre = this.TextBoxNombre.Text;
                    usuarioEnvio.apellido = this.TextBoxApellido.Text;
                    usuarioEnvio.tipoDocumento = this.DropDownTipoDoc.SelectedValue;

                    string numDoc = string.Empty;
                    if (TextBoxNoDoc != null && TextBoxNoDoc.Text != null)
                    {
                        numDoc = TextBoxNoDoc.Text.Trim();
                    }
                    usuarioEnvio.numeroDocumento = numDoc;
                    usuarioEnvio.correoElectronico = TextBoxCorreo.Text;
                    usuarioEnvio.telefono = TextBoxTelefono.Text;

                    //datos de la direccion
                    UbicacionDTO ubicacion = new UbicacionDTO();
                    ubicacion.numeroDireccion = TextBoxDireccion.Text;
                    ubicacion.nombreCiudad = ddlCiudad.SelectedItem.Text;
                    ubicacion.idCiudad = Convert.ToInt32(ddlCiudad.SelectedValue);
                    ubicacion.nombreDepartamento = ddlDepartamento.SelectedItem.Text;
                    ubicacion.idDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
                    ubicacion.nombrePais = ddlPais.SelectedItem.Text;
                    ubicacion.idPais = Convert.ToInt32(ddlPais.SelectedValue);
                    usuarioEnvio.ubicacionCliente = ubicacion;
                    myOrder.usuarioEnvio = usuarioEnvio;

                    //Fin datos Usuario Envio

                    //datos  Orden
                    OrdenDTO ordencCompra = new OrdenDTO();
                    if (myOrderList != null)
                    {
                        ordencCompra.numeroItemsOrden = myOrderList.Count;
                    }
                    else
                    {
                        ordencCompra.numeroItemsOrden = 0;
                    }

                    String totalOrdenStr = "";
                    double totalOrden = 0;
                    try
                    {
                        if (Session["payment_amt"] != null)
                        {

                            totalOrdenStr = Session["payment_amt"].ToString();
                        }

                        totalOrden = Convert.ToDouble(totalOrdenStr);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error convertir total orden " + ex.Message);
                    }

                    ordencCompra.totalOrden = totalOrden;
                    ClienteDTO userOrden = new ClienteDTO();
                    if (User != null && User.Identity != null)
                    {
                        userOrden.correoElectronico = User.Identity.Name;
                        userOrden.nombreUsuario = User.Identity.Name;
                    }
                    ordencCompra.usuarioOrden = userOrden;

                    //Fin datos  Orden

                    //datos  Detalle Orden
                    List<ItemOrdenDTO> listaItemsOrden = new List<ItemOrdenDTO>();
                    if (myOrderList != null)
                    {
                        ItemOrdenDTO itemOrden = null;

                        foreach (CartItem cartItem in myOrderList)
                        {
                            itemOrden = new ItemOrdenDTO();
                            itemOrden.cantidadItem = cartItem.Quantity;
                            itemOrden.totalItem = (cartItem.Quantity * cartItem.valorUnitarioItem);
                            if (cartItem.Product != null && cartItem.Product.TipoItem.Equals("C"))
                            {
                                itemOrden.tipo = true;
                                itemOrden.idCampania = cartItem.ProductId;
                            }
                            else
                            {
                                itemOrden.tipo = false;
                            }

                            ProductosDTO unProducto = null;
                            //copia del producto
                            if (cartItem.Product != null)
                            {
                                unProducto = new ProductosDTO();

                                unProducto.codigoProducto = cartItem.Product.codigoProducto;

                                unProducto.descripcionProducto = cartItem.Product.descripcionProducto;
                                unProducto.fabricanteProducto = cartItem.Product.fabricanteProducto;
                                if (cartItem.Product != null && cartItem.Product.TipoItem.Equals("C"))
                                {
                                    unProducto.idProducto = cartItem.ProductId;
                                }
                                else
                                {
                                    unProducto.idProducto = cartItem.Product.idProducto;
                                }
                                unProducto.idSubcategoria = cartItem.Product.idSubcategoria;
                                unProducto.nombreCategoria = cartItem.Product.nombreCategoria;
                                unProducto.nombreImagenProducto = cartItem.Product.nombreImagenProducto;
                                unProducto.nombreProducto = cartItem.Product.nombreProducto;
                                unProducto.nombreSubcategoria = cartItem.Product.nombreSubcategoria;
                                unProducto.precioProducto = cartItem.Product.precioProducto;
                                unProducto.TipoItem = cartItem.Product.TipoItem;
                            }
                            itemOrden.producto = unProducto;
                            // fin  copia producto

                            listaItemsOrden.Add(itemOrden);

                        }//fin for

                    }

                    ordencCompra.listaItemsOrden = listaItemsOrden;
                    // Fin datos  Detalle Orden

                    //Set orden final
                    myOrder.ordenCompra = ordencCompra;

                }// fin using

                CompraBL compraBL = new CompraBL();

                //se llama al servicio.
                estadoCompra = compraBL.registrarCompra(myOrder);

                if (estadoCompra != null && estadoCompra.IdPreOrden != null && estadoCompra.EstadoTarjeta == true)
                {
                    Session["userCheckoutCompleted"] = "true";
                    Session["payerId"] = estadoCompra.IdPreOrden;

                    //se debe borrar la lista del carro.
                    using (KallSonysB2C.Logic.ShoppingCartActions usersShoppingCart = new KallSonysB2C.Logic.ShoppingCartActions())
                    {
                        usersShoppingCart.EmptyCart();
                    }

                    Response.Redirect("~/Checkout/CheckoutComplete.aspx", false);
                }
                else
                {
                    Session["userCheckoutCompleted"] = "false";
                    Session.Remove("payerId");
                    if (estadoCompra != null && estadoCompra.EstadoTarjeta == false)
                    {
                        //mensaje de que no fue exitoso o que la tarjeta es invalida.
                        KallSonysB2C.Logic.MessageBox.Show("Tarjeta de Credito No Valida");
                    }
                    else
                    {
                        KallSonysB2C.Logic.MessageBox.Show("Error Al Registrar Su orden de Compra - Intente Nuevamente");
                    }
                }
            }
            catch (Exception ex)
            {
                Session["userCheckoutCompleted"] = "false";
                Session.Remove("payerId");
                Console.WriteLine("Error CheckoutConfirm_Click" + ex.Message);
                KallSonysB2C.Logic.MessageBox.Show("Error en Registro - Intente Nuevamente");
            }

        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPais.SelectedValue != "-1")
            {
                cargaDepartamento(Convert.ToInt32(ddlPais.SelectedItem.Value));
            }
            else
            {
                ddlDepartamento.Items.Clear();
                ddlDepartamento.Items.Insert(0, new ListItem("[Seleccione]", "-1"));
            }
            ddlCiudad.Items.Clear();
            ddlCiudad.Items.Insert(0, new ListItem("[Seleccione]", "-1"));
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartamento.SelectedValue != "-1")
            {
                cargaCiudad(Convert.ToInt32(ddlDepartamento.SelectedItem.Value));
            }
            else
            {
                ddlCiudad.Items.Clear();
                ddlCiudad.Items.Insert(0, new ListItem("[Seleccione]", "-1"));
            }
        }

        private void cargaPais()
        {
            ParametricaBL pais = new ParametricaBL();
            ddlPais.DataSource = pais.getPais();
            ddlPais.DataBind();
            ddlPais.Items.Insert(0, new ListItem("[Seleccione]", "-1"));
            ddlDepartamento.Items.Insert(0, new ListItem("[Seleccione]", "-1"));
            ddlCiudad.Items.Insert(0, new ListItem("[Seleccione]", "-1"));
        }

        private void cargaDepartamento(int idPais)
        {
            ddlDepartamento.Items.Clear();
            ParametricaBL dep = new ParametricaBL();
            ddlDepartamento.DataSource = dep.getDepartamento(idPais);
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("[Seleccione]", "-1"));
        }

        private void cargaCiudad(int idDepartamento)
        {
            ddlCiudad.Items.Clear();
            ParametricaBL mun = new ParametricaBL();
            ddlCiudad.DataSource = mun.getCiudad(idDepartamento);
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, new ListItem("[Seleccione]", "-1"));
        }

    }
}