using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using KB2C.DTO;

namespace KB2C.Data
{
    public class ParametricaDAL
    {
        public List<PaisDTO> getPais() 
        {
            List<PaisDTO> lstPais = new List<PaisDTO>();
            Parametros p = new Parametros();
            PaisDTO itemPais;

            using (OracleConnection con = new OracleConnection(p.oracleConnString().ToString()))
            {
                con.Open();

                OracleCommand cmd = con.CreateCommand();                
                cmd.CommandText = "select IDPAIS, NOMBREPAIS from pais";

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itemPais = new PaisDTO();
                        itemPais.idPais = reader.GetInt32(0);
                        itemPais.nombrePais = reader.GetString(1);
                        lstPais.Add(itemPais);
                    }
                }

                con.Close();
                con.Dispose();
            }

            return lstPais;
        }

        public List<DepartamentoDTO> getDepartamento(int idPais = -1)
        {
            List<DepartamentoDTO> lstDepar = new List<DepartamentoDTO>();
            Parametros p = new Parametros();
            DepartamentoDTO itemDep;

            using (OracleConnection con = new OracleConnection(p.oracleConnString().ToString()))
            {
                con.Open();

                OracleCommand cmd = con.CreateCommand();
                
                cmd.CommandText = (idPais != -1) ? "select IDDEPARTAMENTO, IDPAIS, NOMBREDEPARTAMENTO from departamento where IDPAIS = " + idPais.ToString() : "select IDDEPARTAMENTO, IDPAIS, NOMBREDEPARTAMENTO from departamento";

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itemDep = new DepartamentoDTO();
                        itemDep.idDepartamento = reader.GetInt32(0);
                        itemDep.idPais = reader.GetInt32(1);
                        itemDep.nombreDepartamento = reader.GetValue(2).ToString();
                        
                        lstDepar.Add(itemDep);
                    }
                }

                con.Close();
                con.Dispose();
            }

            return lstDepar;
        }

        public List<CiudadDTO> getCiudad(int idDepartamento = -1)
        {
            List<CiudadDTO> lstCiudad = new List<CiudadDTO>();
            Parametros p = new Parametros();
            CiudadDTO itemCiudad;

            using (OracleConnection con = new OracleConnection(p.oracleConnString().ToString()))
            {
                con.Open();

                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = (idDepartamento != -1) ? "select IDCIUDAD, IDDEPARTAMENTO, NOMBRECIUDAD from ciudad where IDDEPARTAMENTO =" + idDepartamento.ToString() : "select IDCIUDAD, IDDEPARTAMENTO, NOMBRECIUDAD from ciudad";

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itemCiudad = new CiudadDTO();
                        itemCiudad.idCiudad = reader.GetInt32(0);
                        itemCiudad.idDepartamento = reader.GetInt32(1);
                        itemCiudad.nombreCiudad = reader.GetValue(2).ToString();
                        lstCiudad.Add(itemCiudad);
                    }
                }

                con.Close();
                con.Dispose();
            }

            return lstCiudad;
        }
    }
}
