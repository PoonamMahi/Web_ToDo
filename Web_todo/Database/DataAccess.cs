using System;
using System.Data.SqlClient;

namespace Web_todo.Database
{
    public class DataAccess
    {
        public static SqlConnection DbAccess()
        {
            return new SqlConnection("Server=localhost;Database=TodoDb;User ID=sa;Password=Admin@123;");

        }
    }
}
