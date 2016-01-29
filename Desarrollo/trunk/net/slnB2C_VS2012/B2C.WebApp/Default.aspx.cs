using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2C.Business;
using B2C.DTO;
using B2C.WebApp.App_Start;

namespace B2C.WebApp
{
    public partial class _Default : Page
    {
        List<ProductosDTO> listaProductos = new List<ProductosDTO>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {                
                CargarRepeater();
            }
        }       

        private void CargarRepeater()
        {
            //List<ProductosDTO> listaProductos = new List<ProductosDTO>();
            ProductoBL obj = new ProductoBL();
            Parametros p = new Parametros();

            listaProductos = obj.listaProductos(p.FiltroxDescripcion, "txtcodigo.text", 1);
            Session.Add("SessionlistaProductos", listaProductos);

            Repeater1.DataSource = listaProductos;
            Repeater1.DataBind();
        }

        public String ConvertirPeso(object Obj)
        {
            try
            {
                Decimal Precio = Convert.ToDecimal(Obj);
                return Precio.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            }
            catch (InvalidCastException e)
            {
                return "$ 0,0"; 
            }             
        }

        protected void ImBtCarrito_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Bt = (ImageButton)sender;
            int Index = Convert.ToInt32(Bt.CommandArgument.ToString());

            TextBox txtBox = (TextBox)Repeater1.Items[Index].FindControl("TbCantidad");
            HiddenField HdIdProducto = (HiddenField)Repeater1.Items[Index].FindControl("HdIdProduct");
            
            int CantidadProducto = Convert.ToInt32(txtBox.Text);
            long IdProducto = Convert.ToInt64(HdIdProducto.Value);
            ProductosDTO ProductoComprado=new ProductosDTO();
            listaProductos = (List<ProductosDTO>)Session["SessionlistaProductos"];            
            ProductoComprado = listaProductos.Find(x => x.idProducto == IdProducto);
            CarroCompras Carrito = CarroCompras.CapturarProducto();
            Carrito.Agregar(ProductoComprado, CantidadProducto);            
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ImageButton b = e.Item.FindControl("ImBtCarrito") as ImageButton;
                b.CommandArgument = e.Item.ItemIndex.ToString();

                TextBox txtBox = (TextBox)e.Item.FindControl("TbCantidad");
                //Attaching an attribute onfocus that is used 
                //attach the validator to the control whenever user set focus on the textbox.
                txtBox.Attributes.Add("onfocus", "AttachValidator(this,'" + ValidatorQnt.ClientID + "')");
            }
        }

        protected void TbCantidad_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            try
            {
                int Cantidad=Convert.ToInt32(txtBox.Text);
                if (Cantidad < 1) 
                {
                    txtBox.Text = "1";
                }

            }
            catch (FormatException ex)
            {
                txtBox.Text = "1";
            }
        }

    }
}