using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ElearningProjectDAL.DAL
{
    public class DataService
    {
        //Server= localhost; Database= ElearningDB; Integrated Security=True;//Server=(LocalDb)\\MSSQLLocalDB;initial catalog=ElearningDB;Trusted_Connection=True;
        private static readonly string _sqlConnection = "Server= localhost; Database= ElearningDB; Integrated Security=True;";

        public static SqlConnection SqlConnection()
        {
            return new SqlConnection(_sqlConnection);
        }
    }
}
