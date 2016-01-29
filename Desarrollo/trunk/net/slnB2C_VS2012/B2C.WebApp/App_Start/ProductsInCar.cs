using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2C.DTO;

namespace B2C.WebApp.App_Start
{
    public class ProductsInCar : IEquatable<ProductsInCar>
    {
        public int Cantidad { get; set; }
        private long _IdProducto;
        private string _Nombre;
        private float _PrecioUnitario;
        private ProductosDTO _producto = null;

        public long IdProducto
        {
            get { return _IdProducto; }
            set
            {
                _producto = null;
                _IdProducto = value;
            }
        }

        public ProductosDTO Producto
        {
            get
            {
                if (_producto == null)
                {
                    _producto = new ProductosDTO();
                }
                return _producto;
            }
        }

        public string Nombre
        {
            get { return Producto.nombreProducto; }
            set
            {
                _Nombre = null;
                _Nombre = value;
            }
        }

        public float PrecioUnitario
        {
            get { return Producto.precioProducto; }
            set
            {
                _PrecioUnitario = 0;
                _PrecioUnitario = value;
            }
        }

        public float Total
        {
            get { return PrecioUnitario * Cantidad; }
        }

        public ProductsInCar(ProductosDTO Prod)
        {
            Producto.codigoProducto = Prod.codigoProducto;
            Producto.descripcionProducto = Prod.descripcionProducto;
            Producto.fabricanteProducto = Prod.fabricanteProducto;
            Producto.idProducto = Prod.idProducto;
            Producto.idProductoSpecified = Prod.idProductoSpecified;
            Producto.idSubcategoria = Prod.idSubcategoria;
            Producto.nombreCategoria = Prod.nombreCategoria;
            Producto.nombreImagenProducto=Prod.nombreImagenProducto;
            Producto.nombreProducto = Prod.nombreProducto;
            Producto.nombreSubcategoria = Prod.nombreSubcategoria;
            Producto.precioProducto = Prod.precioProducto;
            Producto.precioProductoSpecified = Prod.precioProductoSpecified;

            IdProducto = Prod.idProducto;
            Nombre = Prod.nombreProducto;
            PrecioUnitario = Prod.precioProducto;
        }

        public bool Equals(ProductsInCar pItem)
        {
            return pItem.IdProducto == IdProducto;
        }
    }
}