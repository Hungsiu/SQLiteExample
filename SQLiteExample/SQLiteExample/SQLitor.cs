using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExample
{
    public class SQLitor
    {
        /*
         *  SQL語法
         *      資料型態
         *      - NULL
         *      - INTEGER
         *      - REAL
         *      - TEXT
         *      - BLOB
         *      - DATETIME
         *  
         *  
         *      建立表格
         *      CREATE TABLE `MyTableName`(
         *          `First Column` Data-Type,
         *          `Second Column` Data-Type,
         *          `Third Column` Data-Type,
         *          .
         *          .
         *          .
         *          .
         *          .
         *          ...
         *      );
         * 
         * 
         *      datetime('now', 'localtime') 
         * 
         */


        protected string DbPath = "Path";
        protected string DbFile = "Data.db";
        protected string TableName = string.Empty;
        protected string commandCreateTable = string.Empty;

        protected SQLiteConnection connection = new SQLiteConnection();

        public SQLitor(string dbPath = "Datas", string dbFile = "Data.db", string tableName = "NewTable")
        {
            DbPath = Environment.CurrentDirectory + "\\" + dbPath;
            DbFile = dbFile;
            TableName = tableName;
            commandCreateTable = "CREATE TABLE IF NOT EXISTS " + TableName + " (_AI INTEGER PRIMARY KEY AUTOINCREMENT,DateTime DATETIME,Topic TEXT,Message TEXT);";

            Setup();
        }

        protected void Setup()
        {
            //  DB目錄不存在就建立一個
            if (!Directory.Exists(DbPath))
                Directory.CreateDirectory(DbPath);

            var dbFilePath = DbPath + "\\" + DbFile;
            //  DB檔案不存在就建立一個
            if (!File.Exists(dbFilePath))
                File.Create(dbFilePath);

            //  SQLite連線
            connection.ConnectionString = "Data source = " + dbFilePath;

            connection.Open();
            CommandExcute(commandCreateTable);
            connection.Close();
        }

        public void CommandExcute(string sqlCommand)
        {
            using (var command = new SQLiteCommand(sqlCommand, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
