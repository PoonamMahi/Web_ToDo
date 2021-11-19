using System;
using System.Data.SqlClient;

namespace Web_todo.Database
{
    public class DataAccess
    {
        public static SqlConnection DbAccess()
        {
            return new SqlConnection("Databaselink");

        }
    }
}
