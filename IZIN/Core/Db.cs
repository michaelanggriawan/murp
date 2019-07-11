using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System.Windows;

namespace MURP.Core
{
    class Db
    {
        private static MySqlConnection Conn;
        private static MySqlCommand Cmd;
        private static MySqlDataAdapter Da;
        private static DataSet Ds;
        private static DataTable Dt;


        public static bool OpenConn()
        {
            if (Conn != null)
                return true;

            try
            {
                Conn = new MySqlConnection("server=" + Globals.Settings.DbHost + ";"
                                     + "database=" + Globals.Settings.DbName + ";"
                                     + "uid=" + Globals.Settings.DbUser + ";"
                                     + "pwd=" + Globals.Settings.DbPwd + ";"
                                     + "Convert Zero Datetime = True" + ";");
                Conn.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Unable to connect to DB", MessageBoxButton.OK);
                return false;
            }

            if (Conn.State != ConnectionState.Open)
            {
                Console.WriteLine("Failed to open the connection");
                return false;
            }

            Console.WriteLine("Connection opened");
            return true;
        }


        public static void CloseConn()
        {
            if (Conn == null)
                return;

            Conn.Close();
            Console.WriteLine("Connection closed");
            Conn = null;
        }


        public static DataTable ExecuteQuery(string queryString, DataGrid tableName = null)
        {
            if (!OpenConn())
                return null;

            Console.WriteLine(queryString);

            Cmd = new MySqlCommand(queryString, Conn);
            Da = new MySqlDataAdapter(Cmd);
            Ds = new DataSet();
            Da.Fill(Ds);

            DataTable DsToReturn = Ds.Tables[0];
            if (tableName != null)
                tableName.DataContext = DsToReturn.DefaultView;

            Dt = null;
            Ds = null;
            Da = null;
            Cmd = null;
            CloseConn();

            return DsToReturn;
        }


        public static void ExecuteNonQuery(string queryString)
        {
            if (!OpenConn())
                return;

            try
            {
                Cmd = new MySqlCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = queryString;
                Cmd.Connection = Conn;
                Cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + $"\nQuery string: {queryString}", "Database error", MessageBoxButton.OK);
            }

            Cmd = null;
            CloseConn();
        }


        public static void Insert(string tableName, Dictionary<string, object> datas)
        {
            string DataColumns = "(";
            string DataValues = "(";

            foreach (KeyValuePair<string, object> Data in datas)
            {
                DataColumns += Data.Key;
                DataValues += "'" + Data.Value + "'";

                if (Data.Equals(datas.Last()))
                    break;

                DataColumns += ",";
                DataValues += ",";
            }
            DataColumns += ")";
            DataValues += ")";

            string Query = "INSERT INTO " + tableName + DataColumns + " VALUES " + DataValues;
            Console.WriteLine(Query);
            ExecuteNonQuery(Query);
        }


        public static void Update(string tableName, string key, Dictionary<string, object> datas)
        {
            _Update(tableName, new KeyValuePair<string, string>("id", key), datas);
        }

        public static void Update(string tableName, KeyValuePair<string, string> key, Dictionary<string, object> datas)
        {
            _Update(tableName, key, datas);
        }

        private static void _Update(string tableName, KeyValuePair<string, string> key, Dictionary<string, object> datas)
        {
            string UpdateData = "";
            foreach (KeyValuePair<string, object> Data in datas)
            {
                UpdateData += Data.Key + "=" + "'" + Data.Value + "'";
                if (Data.Equals(datas.Last()))
                    break;

                UpdateData += ", ";
            }

            string Query = "UPDATE " + tableName
                                  + " SET " + UpdateData
                                  + " WHERE " + key.Key + "=" + "'" + key.Value + "'";

            Console.WriteLine(Query);
            ExecuteNonQuery(Query);
        }


        public static void Delete(string tableName, string id, string idColumn = "id")
        {
            _Delete(tableName, new KeyValuePair<string, string>(idColumn, id));
        }


        private static void _Delete(string tableName, KeyValuePair<string, string> key)
        {
            string Sql = "DELETE FROM " + tableName + " WHERE " + key.Key + "=" + $"'{key.Value}'";
            ExecuteNonQuery(Sql);
        }
    }
}
