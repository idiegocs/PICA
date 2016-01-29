using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KB2C.DTO
{

    public class Parametros
    {
        private const string _sinFiltro = "A";
        private const string _codigo = "C";
        private const string _nombre = "N";
        private const string _descripcion = "D";
        private const string _id = "I";

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
        public string FiltroxId
        {
            get { return _id; }
        }

        public List<int> listaAnioVenceTarjeta()
        {
            int anioVenceInicial = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["anioInicioVenceTarjeta"].ToString());
            int anioVenceFinal = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["anioFinVenceTarjeta"].ToString());

            List<int> lstAnioVenceTarjeta = new List<int>();

            for (int i = anioVenceInicial; i <= anioVenceFinal; i++)
            {
                lstAnioVenceTarjeta.Add(i);
            }

            return lstAnioVenceTarjeta;
        }

        public string oracleConnString() 
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["cnxOracle"].ToString();
        }
    }
}
