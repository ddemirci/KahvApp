using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace KahvApp.DAL
{
    public class DatabaseOperations
    {
        private const string conString = "Data Source=KahvAppDatabase.sqlite;Version=3;";
        private readonly string databaseFilePath = Environment.CurrentDirectory + @"\KahvAppDatabase";

    

        public  DatabaseOperations()
        {
            if (!File.Exists(databaseFilePath))
            {
                SQLiteConnection.CreateFile(databaseFilePath);

                string sql = "create table if not exists Gunluk_Gelir_Listesi (Tarih varchar(20), Fiş_Sayısı int, Toplam decimal(6,3))";
                bool b1 = ExecuteSqlQuery(sql);

                sql = "create table if not exists Odenen_Fisler (Tarih varchar(20), Fis_No int, Masa int, Tutar decimal(6,3))";
                b1 = ExecuteSqlQuery(sql);

                sql = "create table if not exists Odenmeyen_Fisler (Tarih varchar(20), Fis_No int, Masa int, Tutar decimal(6,3))";
                b1 = ExecuteSqlQuery(sql);

                sql = "create table if not exists Borclular (Ad varchar(20), Soyad varchar(20), Tarih varchar(20), Tutar decimal(6,3))";
                b1 = ExecuteSqlQuery(sql);
                //CloseConnection();
            }
        }




        public SQLiteConnection OpenSqlConnection()
        {
            SQLiteConnection sqlConn = new SQLiteConnection(conString);

            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            return sqlConn;
        }

        public DataSet ExecuteSqlQueryToDataSet(string commandText)
        {
            SQLiteConnection sqlConn = OpenSqlConnection();
            SQLiteCommand dbCommand;
            try
            {
                DataSet dataSet = new DataSet();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                dbCommand = CreateTextSqlCommand(commandText);
                dbCommand.Connection = sqlConn;
                adapter.SelectCommand = dbCommand;
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            //finally
            //{
            //    if (sqlConn != null)
            //        sqlConn.Close();
            //}
        }

        public SQLiteCommand CreateTextSqlCommand(string query)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(query);
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = CommandType.Text;
            return sqlCommand;

        }

        public bool ExecuteSqlQuery(string preparedStmt)
        {
            SQLiteConnection sqlConnection = null;
            SQLiteCommand command = null;
            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                command = CreateTextSqlCommand(preparedStmt);
                if (command.Connection == null)
                {
                    SQLiteConnection sqlConn = OpenSqlConnection();
                    command.Connection = sqlConn;
                    
                }
                return command.ExecuteNonQuery() >= 0;
            }
            catch (SQLiteException Sqlex)
            {
                throw Sqlex;
            }
            //finally
            //{
            //    CloseConnection(sqlConnection);
            //}
        }

        public bool ExecuteSqlQueryWithParameters(SQLiteCommand Command)
        {
            SQLiteConnection sqlConnection = null;
            //SQLiteCommand command = null;
            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                if (Command.Connection == null)
                {
                    SQLiteConnection sqlConn = OpenSqlConnection();
                    Command.Connection = sqlConn;

                }
                return Command.ExecuteNonQuery() >= 0;
            }
            catch (SQLiteException Sqlex)
            {
                throw Sqlex;
            }
            //finally
            //{
            //    CloseConnection(sqlConnection);
            //}
        }

        public object ExecuteSqlQueryForResult(SQLiteCommand Command)
        {
            SQLiteConnection sqlConnection = null;
            //SQLiteCommand command = null;
            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                if (Command.Connection == null)
                {
                    SQLiteConnection sqlConn = OpenSqlConnection();
                    Command.Connection = sqlConn;

                }
                return Command.ExecuteScalar();
            }
            catch (SQLiteException Sqlex)
            {
                throw Sqlex;
            }
            //finally
            //{
            //    CloseConnection(sqlConnection);
            //}
        }



        public void CloseConnection(SQLiteConnection sqlConn)
        {
            if (sqlConn != null && sqlConn.State == ConnectionState.Open ||
                                  sqlConn.State == ConnectionState.Connecting ||
                                  sqlConn.State == ConnectionState.Executing ||
                                  sqlConn.State == ConnectionState.Fetching)
                sqlConn.Close();
            else;
        }
    }
}
