using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DALConnection
    {
        public SqlConnection SqlConnection { get; set; }
        public string Connection { get; set; } = "Data Source=.;Initial Catalog =CRUD;User Id=sa;Password=sql@123";
        public DALConnection()
        {
            SqlConnection = new SqlConnection(Connection);
            SqlConnection.Open();
        }
    }
}
