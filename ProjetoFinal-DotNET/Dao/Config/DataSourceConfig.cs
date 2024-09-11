using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoFinal_DotNET.Dao.Config
{
    public static class DataSourceConfig
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConectaCiencia"].ConnectionString;

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}