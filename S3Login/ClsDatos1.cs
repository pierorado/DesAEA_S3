using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3Login.modelo;
namespace S3Login
{
    class ClsDatos1
    {
        public SqlConnection leerCadena()
        {
            SqlConnection connection =
             new SqlConnection("Data Source=sql5047.site4now.net;Initial Catalog=DB_A5A76B_RadoTecsup;UID=DB_A5A76B_RadoTecsup_admin;PWD=pierodead1998");
            return connection;
        }
        public Boolean VerificarAcceso(Usuario usu)
        {
            SqlConnection connection = leerCadena();
            connection.Open();
            SqlCommand cmd = new SqlCommand("UspUsuario");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@usuario", usu.Usuarios);
            cmd.Parameters.AddWithValue("@clave", usu.clave);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
