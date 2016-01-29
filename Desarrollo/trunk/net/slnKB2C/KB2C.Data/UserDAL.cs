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
    public class UserDAL
    {
        public void insertUserOracle(string user, string password) 
        {
            Parametros p = new Parametros();
            using (OracleConnection con = new OracleConnection(p.oracleConnString().ToString()))
            {
                con.Open();

                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO USUARIO(IDUSUARIO, EMAIL, PASSWORD, USERNAME, IDCATEGORIA) VALUES(SEQ_CLIENTE.nextval,'" + user + "','" + password + "','" + user + "', 1)";
                cmd.ExecuteNonQuery();

                con.Close();
                con.Dispose();
            }
        }

    }
}
