using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JZExample.Model;
using SQLite;

namespace JZExample
{
    public class JunShengDb : SQLiteConnection
    {
        public static JunShengDb Create()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullPath = Path.Combine(path, _defaultFileNameh);

            return new JunShengDb(fullPath);
        }

        private const string _defaultFileNameh = "JunSheng.db";

        public JunShengDb(string path = _defaultFileNameh) : base(path)
        {
            if(!File.Exists(path))
            {
                CreateTable<BatchInfo>();
            }
        }

        public int InsertBatchInfos(IEnumerable<BatchInfo> infos)
        {
            return InsertAll(infos, true);
        }

        //public static int DeleteAllBatchInfos(SQLiteConnection connection)
        //{
        //    return connection.DeleteAll<BatchInfo>();
        //}

        public static IEnumerable<BatchInfo> QueryAllBatchInfos(SQLiteConnection connection)
        {
            return connection.Table<BatchInfo>();
        }

        public static IEnumerable<BatchInfo> QueryBatchInfosByBatch(SQLiteConnection connection, string batchNo)
        {
            return connection.Table<BatchInfo>().Where(info => info.BatchNo.Equals(batchNo));
        }

        public static void DeleteDatabase(string path = _defaultFileNameh)
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
