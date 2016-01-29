using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C.DTO
{
    public class Parametros
    {
        private const string _sinFiltro = "A";
        private const string _codigo = "C";
        private const string _nombre = "N";
        private const string _descripcion = "D";

        public string FiltroxCodigo 
        {
            get { return _codigo; }
        }
        public string FiltroxNombre
        {
            get { return _nombre; }
        }
        public string FiltroxDescripcion
        {
            get { return _descripcion; }
        }
        public string SinFiltro
        {
            get { return _sinFiltro; }
        }
    }
}
/*
A: todo. Sin filtro.
C: Codigo Producto
N: Nombre Producto
D: Descripcion Producto
 */