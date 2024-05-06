using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
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
         */


        protected string DbPath = "Path";
        protected string DbFile = "Data.db";
        protected string TableName = string.Empty;
        protected string commandCreateTable = string.Empty;

        protected SQLiteConnection connection = new SQLiteConnection();

        public SQLitor(string dbPath = "Datas", string dbFile = "Data.db", string tableName = "NewTable")
        {
            DbPath = Application.StartupPath + "\\" + dbPath;
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

            //  DB檔案不存在就建立一個
            if (!File.Exists(DbFile))
                Directory.CreateDirectory(DbPath + "\\" + DbFile);

            //  SQLite連線處
            var DataSource = DbPath + DbFile;
            connection.ConnectionString = "Data source = " + DataSource;

            connection.Open();
            CommandExcute(commandCreateTable);

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
