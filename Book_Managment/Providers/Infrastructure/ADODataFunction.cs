using Book_Managment.API.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Diagnostics;

namespace Book_Managment.API.Providers.Infrastructure
{
    public class ADODataFunction : Disposable
    {
        protected override void DisposeCore()
        {

        }

        private readonly IConfiguration _configuration;
        public ADODataFunction(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ADODataFunction()
        {
        }

        public enum DbContextZoi
        {
            DBContextZoi
        }

        public DataSet ExecuteDataset(string CommandText, SqlParameter[] SqlParameters, CommandType Type = CommandType.StoredProcedure)
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    using (SqlConnection con = new SqlConnection(GetConnectionString()))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(CommandText, con))
                        {
                            if (con.State == ConnectionState.Closed)
                                con.Open();
                            da.SelectCommand.CommandType = Type;
                            da.SelectCommand.CommandTimeout = 0;
                            if (SqlParameters != null)
                                da.SelectCommand.Parameters.AddRange(SqlParameters);
                            da.Fill(ds);
                        }
                    }
                    return ds;
                }
            }
            catch (Exception sqlEx)
            {
                string[] lines = { "Message : " + sqlEx.Message, "Inner Exception : " + sqlEx.InnerException, "ADODataFunction" };
                string baseDirectory = Directory.GetCurrentDirectory();
                string path = Path.Combine(baseDirectory, "ErrorLogs");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                DateTime currentDate = DateTime.Now;

                string formattedDate = currentDate.ToString("yyyyMMdd");
                string formattedTime = currentDate.ToString("HHmmss");

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, formattedDate + "_" + formattedTime + ".Log.txt")))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
                throw sqlEx;
            }
        }

        public string GetConnectionString()
        {
            return GetConnectionString("DefaultConnection");
        }

        public string GetConnectionString(string dbContextKey)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            string ConnectionString = root.GetConnectionString(dbContextKey);
            return ConnectionString;
        }
    }
}



