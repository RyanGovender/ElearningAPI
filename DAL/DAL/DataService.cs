using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ElearningProjectDAL.DAL
{
    public class DataService
    {
        private static readonly string _sqlConnection = "Server=(LocalDb)\\MSSQLLocalDB;initial catalog=ElearningDB;Trusted_Connection=True;";

        public static SqlConnection SqlConnection()
        {
            return new SqlConnection(_sqlConnection);
        }
    }
}
