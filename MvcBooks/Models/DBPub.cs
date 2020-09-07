using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace MvcBooks.Models
{
    public class DBPub
    {
        private string connStr =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\OIC\Data\SmallPub.mdf;Integrated Security=True;Connect Timeout=30";
        private IDbConnection conn;
        private IDbCommand cmd;

        public List<string> GetCategories()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connStr;
            cmd = conn.CreateCommand();
            conn.Open();

            cmd.CommandText = "select * from Category";
            IDataReader reader = cmd.ExecuteReader();
            List<string> cats = new List<string>();
            while (reader.Read())
            {
                string cat = string.Format(
                    "{0}, {1}",
                    reader["CategoryId"], reader["Description"]);
                cats.Add(cat);
            }
            conn.Close();
            return cats;
        }
    }
}
