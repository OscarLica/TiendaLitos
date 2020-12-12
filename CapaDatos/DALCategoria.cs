using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class DALCategoria
    {
        public DALConnection ServiceConnection { get; set; }
        public DALCategoria()
        {
            ServiceConnection = new DALConnection();
        }
        public dynamic GetCategorias() {

            SqlCommand comando = new SqlCommand(
                "SELECT * FROM TbCategoria",
                ServiceConnection.SqlConnection
                ) ;
            var result = comando.ExecuteNonQuery();

            ServiceConnection.SqlConnection.Close();
            return new { };
        }
    }
}
