using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana03
{
    class ClsDatos
    {
        public SqlConnection leerCadena()
        {
            SqlConnection connection =
             new SqlConnection("Data Source=sql5047.site4now.net;Initial Catalog=DB_A5A76B_RadoTecsup;UID=DB_A5A76B_RadoTecsup_admin;PWD=pierodead1998");
            return connection;
        }
        public DataTable ListarPedidoFecha(DateTime x,DateTime y)
        {
            SqlConnection connection = leerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("USP_FECHAFECHA", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@FEC1", x);
            sqlData.SelectCommand.Parameters.AddWithValue("@FEC2", y);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
        public DataTable ListarDetalle(int x)
        {
            SqlConnection connection = leerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("USP_ListarDetalle", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@IdPedido", x);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
        public double PedidoTotal(Int32 idpedido)
        {
            SqlConnection connection = leerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("USP_Total", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@IdPedido", idpedido);
            sqlData.SelectCommand.Parameters.Add("@Total", SqlDbType.Money).Direction = ParameterDirection.Output;
            sqlData.SelectCommand.ExecuteScalar();
            Int32 total = Convert.ToInt32(sqlData.SelectCommand.Parameters["@Total"].Value);
            connection.Close();
            return total;
        }
    }
}
