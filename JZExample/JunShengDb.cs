using JZExample.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JZExample
{
    public class JunShengDb : SQLiteConnection
    {
        private const string _defaultDatabaseFilePath = "JunSheng.db";

        public JunShengDb(string path = _defaultDatabaseFilePath) : base(path)
        {
        }

        public static int InsertBatchInfos(SQLiteConnection connection, IEnumerable<BatchInfo> infos)
        {
            return connection.InsertAll(infos, true);
        }

        public static int DeleteAllBatchInfos(SQLiteConnection connection)
        {
            return connection.DeleteAll<BatchInfo>();
        }

        public static IEnumerable<BatchInfo> QueryAllBatchInfos(SQLiteConnection connection)
        {
            return connection.Table<BatchInfo>();
        }

        public static IEnumerable<BatchInfo> QueryBatchInfosByBatch(SQLiteConnection connection, string batchNo)
        {
            return connection.Table<BatchInfo>().Where(info => info.BatchNo.Equals(batchNo));
        }

        public static void DeleteDatabase(string path = _defaultDatabaseFilePath)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
