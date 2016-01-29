using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2C.DTO;

namespace B2C.WebApp.App_Start
{
    public class CarroCompras
    
    {
        public List<ProductsInCar> ListaProductos 
        { 
            get; 
            private set; 
        }

        public static CarroCompras CapturarProducto()
        {
            CarroCompras _carrito = (CarroCompras)HttpContext.Current.Session["SesionCarroDeCompras"];
            if (_carrito == null)
            {
                HttpContext.Current.Session["SesionCarroDeCompras"] = _carrito = new CarroCompras();
            }
            return _carrito;
        }

        protected CarroCompras()
        {
            ListaProductos = new List<ProductsInCar>();
        }

        public void Agregar(ProductosDTO pProducto, int Cantidad)
        {
            ProductsInCar NuevoProducto = new ProductsInCar(pProducto);
            if (ListaProductos.Contains(NuevoProducto))
            {
                foreach (ProductsInCar item in ListaProductos)
                {
                    if (item.Equals(NuevoProducto))
                    {
                        item.Cantidad += Cantidad;
                        return;
                    }
                }
            }
            else
            {
                NuevoProducto.Cantidad = Cantidad;
                ListaProductos.Add(NuevoProducto);
            }
        }

        public void EliminarProductos(ProductosDTO pProducto)
        {
            ProductsInCar eliminaritems = new ProductsInCar(pProducto);
            ListaProductos.Remove(eliminaritems);
        }

        public void CantidadDeProductos(ProductosDTO pProducto, int pCantidad)
        {
            if (pCantidad == 0)
            {
                EliminarProductos(pProducto);
                return;
            }

            ProductsInCar updateProductos = new ProductsInCar(pProducto);
            foreach (ProductsInCar item in ListaProductos)
            {
                if (item.Equals(updateProductos))
                {
                    item.Cantidad = pCantidad;
                    return;
                }
            }
        }

        public float SubTotal()
        {
            float subtotal = 0;
            foreach (ProductsInCar item in ListaProductos)
            {
                subtotal += item.Total;
            }
            return subtotal;
        }
    }
}