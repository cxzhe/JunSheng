using System;
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
            if (!db.TableExists<BatchInfo>())
            {
                db.CreateTable<BatchInfo>();
            }
            return db;
        }

        private const string _defaultFileNameh = "JunSheng.db";

        public JunShengDb(string path) : base(path)
        {
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
