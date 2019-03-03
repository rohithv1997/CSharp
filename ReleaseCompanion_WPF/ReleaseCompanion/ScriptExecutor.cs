using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Data.SqlClient;
using System.IO;

namespace ReleaseCompanion
{
    internal class ScriptExecutor
    {
        public static bool ExecuteScript(string _dbServer,string _dbName,string _scriptFilePath, out string _error)
        {
            _error = string.Empty;
            try
            {
                string sqlConnectionString = "data source = " + _dbServer + ";Integrated Security=SSPI ; Initial Catalog = " + _dbName + "; MultipleActiveResultSets = True";
                string script = File.ReadAllText(_scriptFilePath);

                SqlConnection conn = new SqlConnection(sqlConnectionString);
                var server = new Server(new ServerConnection(conn));

                var result = server.ConnectionContext.ExecuteNonQuery(script);

                return true;
            }
            catch (Exception ex)
            {
                _error = ex.Message + (ex.InnerException?.Message ?? string.Empty);
                return false;
            }
        }
    }
}
