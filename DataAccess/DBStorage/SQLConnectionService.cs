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

        private SQLConnectionService(string connString)
        {
            connection = new SqlConnection(connString);
            connection.Open(); 

        }

        public static SQLConnectionService GetService(string connString)
        {
            if (sqlConnectionService == null)
            {
                sqlConnectionService = new SQLConnectionService(connString);
            }

            return sqlConnectionService;
        }

        public SqlConnection Connection { get { return connection; } }

    }
}
