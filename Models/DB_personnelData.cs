using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using Dapper;
using Newtonsoft.Json;

namespace YC_Test.Models
{
    public class DB_personnelData
    {
        string ConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public DataTable getData()
        {
            var Result = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                string strSql = "Select * from [dbo].[Table]";
                var results = conn.Query(strSql);
                var json = JsonConvert.SerializeObject(results);
                var dt = JsonConvert.DeserializeObject<DataTable>(json);
                return dt;
            }
        }
    }
}