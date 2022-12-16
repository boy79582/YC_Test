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
        public Dictionary<string, string> insertData(string JSON_newPersonnel)
        {
            var newPersonnel = JsonConvert.DeserializeObject<personnelMaster>(JSON_newPersonnel);
            var Result = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    string insertSQL = @"
INSERT INTO [dbo].[Table]([ChineseName], [EnglishName], [PhoneNumber], [Birthday]) 
VALUES (@ChineseName, @EnglishName, @PhoneNumber, @Birthday)";

                    var exe_count = conn.Execute(insertSQL, new
                    {
                        newPersonnel.ChineseName,
                        newPersonnel.EnglishName,
                        newPersonnel.PhoneNumber,
                        newPersonnel.Birthday
                    });
                    if (exe_count >= 1)
                    {
                        Result.Add("status", "success");
                        Result.Add("message", "Add success!");
                    }
                    else
                    {
                        Result.Add("status", "fail");
                        Result.Add("message", "Add fail!");
                    }
                }
                catch (Exception ex)
                {
                    Result.Add("status", "fail");
                    Result.Add("message", ex.Message);
                }                    
                return Result;
            }
        }
        public Dictionary<string, string> UpdateData(string JSON_Personnel)
        {
            var Personnel = JsonConvert.DeserializeObject<personnelMaster>(JSON_Personnel);
            var Result = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    string UpdateSQL = @"
UPDATE [dbo].[Table] SET 
[ChineseName] = @ChineseName,
[EnglishName] = @EnglishName,
[Birthday] = @Birthday WHERE [PhoneNumber] = @PhoneNumber";

                    var exe_count = conn.Execute(UpdateSQL, new
                    {
                        Personnel.ChineseName,
                        Personnel.EnglishName,
                        Personnel.PhoneNumber,
                        Personnel.Birthday
                    });

                    if (exe_count >= 1)
                    {
                        Result.Add("status", "success");
                        Result.Add("message", "Update success!");
                    }
                    else
                    {
                        Result.Add("status", "fail");
                        Result.Add("message", "Update fail!");
                    }
                }
                catch (Exception ex)
                {
                    Result.Add("status", "fail");
                    Result.Add("message", ex.Message);
                }
                return Result;            
            }
        }        
        public Dictionary<string, string> removeData(string PhoneNumber)
        {
            var Result = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    string deleteSQL = @"DELETE FROM [dbo].[Table] WHERE PhoneNumber = @PhoneNumber";
                    var exe_count = conn.Execute(deleteSQL, new { PhoneNumber });
                    if (exe_count >= 1)
                    {
                        Result.Add("status", "success");
                        Result.Add("message", "Delete success!");
                    }
                    else
                    {
                        Result.Add("status", "fail");
                        Result.Add("message", "Delete fail!");
                    }
                }
                catch (Exception ex)
                {
                    Result.Add("status", "fail");
                    Result.Add("message", ex.Message);
                }
                return Result;
            }
        }
    }
}