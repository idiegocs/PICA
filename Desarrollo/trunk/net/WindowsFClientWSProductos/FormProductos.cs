using System;
using System.Text;
using System.Windows.Forms;

namespace WindowsFClientWSProductos
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

      

        private void consumirWS(object sender, EventArgs e)
        {
            ServiceMierdation.ConsultaProductoEntrada entradaWs = new ServiceMierdation.ConsultaProductoEntrada();
            ServiceMierdation.Filtro filtroWS= new ServiceMierdation.Filtro();
            entradaWs.filtroProducto = filtroWS;

            filtroWS.tipoFiltro = this.tipoFiltroTx.ToString();
            filtroWS.valorFiltro=this.valorFiltroTx.ToString();
            try
            {
                Console.WriteLine("Pagina " + this.paginaTx.Text);
                if (this.paginaTx.Text != null && this.paginaTx.Text != "")
                {
                    filtroWS.pagina = Convert.ToInt16(this.paginaTx.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex "+ex.ToString());
            }

            Console.WriteLine("Filtro DC " + filtroWS.tipoFiltro+ " " + filtroWS.valorFiltro+" " + filtroWS.pagina);

            try
            {
                //consulta del Wenservice de productos
                ServiceMierdation.ProductosPortClient cl = new ServiceMierdation.ProductosPortClient();
                ServiceMierdation.ConsultaProductoSalida salidaWS;
                salidaWS = cl.ConsultarProductos(entradaWs);
                Console.WriteLine("Salida " + salidaWS.respuestaFiltro.pagina);

                

                StringBuilder detalleProductos = new StringBuilder("");
                if (salidaWS != null && salidaWS.listaProductos.producto.Length > 0)
                {
                    for (int i = 0; i < salidaWS.listaProductos.producto.Length; i++)
                    {
                        detalleProductos.Append(
                        "Producto" + (i + 1) + " \n").Append
                        ("ID Producto " + salidaWS.listaProductos.producto[i].idProducto + "\n").Append
                        ("Codigo Producto " + salidaWS.listaProductos.producto[i].codigoProducto + "\n").Append
                        ("Nombre Producto " + salidaWS.listaProductos.producto[i].nombreProducto + "\n").Append
                        ("Descripcion Producto " + salidaWS.listaProductos.producto[i].descripcionProducto + "\n").Append
                         ("Fabricante Producto " + salidaWS.listaProductos.producto[i].fabricanteProducto + "\n").Append
                        ("Nombre Imagen Producto " + salidaWS.listaProductos.producto[i].nombreImagenProducto + "\n").Append
                        ("Precio Producto " + salidaWS.listaProductos.producto[i].precioProducto + "\n").Append
                        ("Categoria Tipo " + salidaWS.listaProductos.producto[i].tipoProducto.categoria.idTipo + "\n").Append
                        ("Categoria Nombre " + salidaWS.listaProductos.producto[i].tipoProducto.categoria.nombreTipo + "\n").Append
                        ("SubCategoria Tipo " + salidaWS.listaProductos.producto[i].tipoProducto.subCategoria.idTipo + "\n").Append
                        ("SubCategoria Nombre " + salidaWS.listaProductos.producto[i].tipoProducto.subCategoria.nombreTipo + "\n").Append
                        ("-------------------------------------------\n");
                    }
                }

                this.respTa.Text =
                    "Total Elementos " + salidaWS.respuestaFiltro.totalElementos + "\n"
                     +"Pagina " + salidaWS.respuestaFiltro.pagina+"\n"
                    +"-----------------------------------------------------------------\n"
                    + "Total Productos " + salidaWS.listaProductos.producto.Length+ "\n"
                    + detalleProductos.ToString()
                    ;

            }
            catch (Exception se)
            {
                Console.WriteLine("Ex " + se.ToString());
                this.respTa.Text = "ERROR";
            }
            

           

        }

        
       
      
    }
}
