using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace LendingSystem.Data
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString =
            @"Server=localhost;
              Database=LendingSystemDB;
              Integrated Security=True;
              Encrypt=True;
              TrustServerCertificate=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
