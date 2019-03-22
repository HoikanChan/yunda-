using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace DXApplication1
{
    public class SqliteManager
    {
        // 获取DB41的数据
        public static List<GridState> ReadSqlite()
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString;
            List<GridState> result;
            using (var cnn = new SQLiteConnection(cnnStr))
            {
                var output = cnn.Query<GridState>("select * from DB41");
                result = output.ToList();

            }
            return result;
        }
    }
    public class GridState
    {
        public int Grid { get; set; }
        public int Status { get; set; }
    }
}

