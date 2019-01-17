using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace JZExample
{
    public static class DatabaseHelper
    {
        private const string _fileName = "junsheng.sqlite";
        private static SQLiteConnection _connection;

        public static void CreateConnection()
        {
            //string cd = Environment.CurrentDirectory;
            //var databasePath = Path.Combine(cd, _fileName);
            try
            {
                if (!File.Exists(_fileName))
                    SQLiteConnection.CreateFile(_fileName);

                _connection = new SQLiteConnection($"data source={_fileName}");
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteDatabase()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
        }

        public static void ConnectionDatabase()
        {
            //_connection.Open;
        }

        public static void CreateCodingTable()
        {
            if (_connection != null)
                _connection = new SQLiteConnection($"data source={_fileName}");

            try
            {
                string sql = "create table coding (批次信息 varchar(20), 打码信息 varchar(20), 打码内容 varchar(20), 打码标志 varchar(20), 对比标志 varchar(20))";
                SQLiteCommand command = new SQLiteCommand(sql, _connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public static void CreateProductTable(string productName)
        {
            if (_connection == null)
                CreateConnection();

            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();

                string sql = $"create table {productName} (no varchar(20), qrcodedata varchar(20))";
                SQLiteCommand command = new SQLiteCommand(sql, _connection);
                var sd = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public static bool DeleteTable(string tableName)
        {
            if (_connection != null)
                CreateConnection();
            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();

                string sql = $"DROP TABLE IF EXISTS {tableName}";
                SQLiteCommand command = new SQLiteCommand(sql, _connection);
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }

            return false;
        }


        public static bool InsertProductRows(string tableName, DataTable dataTable)
        {
            if (_connection != null)
                CreateConnection();
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                string sql = "";
                foreach (var row in dataTable.Rows)
                {
                    if (row is DataRow dataRow)
                    {
                        var ars = dataRow.ItemArray;

                        sql += $"insert into {tableName} (no, qrcodedata) values ('{ars[0].ToString()}', '{ars[1].ToString()}');";

                    }
                }
                //string sql = $"insert into {tableName} (no, qrcodedata) values ('{no}', '{qrcodedata}');";
                SQLiteCommand command = new SQLiteCommand(sql, _connection);
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }

            return false;
        }

        public static bool InsertProductRow(string tableName, string no, string qrcodedata)
        {
            if (_connection != null)
                CreateConnection();
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                string sql = $"insert into {tableName} (no, qrcodedata) values ('{no}', '{qrcodedata}')";
                SQLiteCommand command = new SQLiteCommand(sql, _connection);
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

            }
            finally
            {
                _connection.Close();
            }

            return false;
        }
    }
}
