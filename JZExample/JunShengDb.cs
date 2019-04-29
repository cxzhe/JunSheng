using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

using JZExample.Model;
using SQLite;

namespace JZExample
{
    public static class SQLiteConnectionHelper
    {
        public static bool TableExists<T>(this SQLiteConnection connection)
        {
            const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";
            var cmd = connection.CreateCommand(cmdText, typeof(T).Name);
            return cmd.ExecuteScalar<string>() != null;
        }
    }


    public class JunShengDb : SQLiteConnection
    {
        public static JunShengDb Create()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dir = Path.Combine(dir, "JunSheng");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string fullPath = Path.Combine(dir, _defaultFileNameh);

            var db = new JunShengDb(fullPath);
            if (!db.TableExists<BatchItem>())
            {
                db.CreateTable<BatchItem>();
            }

            if (!db.TableExists<Batch>())
            {
                db.CreateTable<Batch>();
            }
            return db;
        }

        private const string _defaultFileNameh = "JunSheng.db";

        public JunShengDb(string path) : base(path)
        {
        }

        public int InsertBatchInfos(IEnumerable<BatchItem> infos)
        {
            return InsertAll(infos, true);
        }

        //public static int DeleteAllBatchInfos(SQLiteConnection connection)
        //{
        //    return connection.DeleteAll<BatchInfo>();
        //}

        public static IEnumerable<BatchItem> QueryAllBatchInfos(SQLiteConnection connection)
        {
            return connection.Table<BatchItem>();
        }

        public static IEnumerable<BatchItem> QueryBatchInfosByBatch(SQLiteConnection connection, string batchNo)
        {
            return connection.Table<BatchItem>().Where(info => info.BatchNo.Equals(batchNo));
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
