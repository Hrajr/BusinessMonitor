using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.DBconnection
{
    public class DB
    {
        public SqlConnection con;
        public string connection;

        public DB()
        {
            connection = "Server=mssql.fhict.local;Database=dbi424119_y;User Id = dbi424119_y; Password=Hrajr123;";
        }

        //public DB()
        //{
        //    var configuration = GetConfiguration();
        //    con = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        //}

        //public IConfigurationRoot GetConfiguration()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    return builder.Build();
        //}
    }
}
