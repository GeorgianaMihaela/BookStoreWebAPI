using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBStorage
{
    // this is a singleton 
    public class SQLConnectionService 
    {
        private SqlConnection connection;
        private static SQLConnectionService sqlConnectionService;

        private SQLConnectionService()
        {
            connection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=BookStore;Trusted_Connection=true;TrustServerCertificate=true");
            connection.Open(); 

        }

        public static SQLConnectionService GetService()
        {
            if (sqlConnectionService == null)
            {
                sqlConnectionService = new SQLConnectionService();
            }

            return sqlConnectionService;
        }

        public SqlConnection Connection { get { return connection; } }

    }
}
