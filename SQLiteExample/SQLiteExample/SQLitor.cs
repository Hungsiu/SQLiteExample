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

        protected bool setuped = false;
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
            {
                Debug.WriteLine("目錄不存在，即將建立新目錄: " + DbPath);
                Directory.CreateDirectory(DbPath);
                Task.Delay(100).Wait();
            }

            var dbFilePath = DbPath + "\\" + DbFile;
            //  DB檔案不存在就建立一個
            if (!File.Exists(dbFilePath))
            {
                Debug.WriteLine("檔案不存在，即將建立新檔: " + dbFilePath);
                SQLiteConnection.CreateFile(dbFilePath);
            }

            //  SQLite連線
            connection.ConnectionString = "Data source = " + dbFilePath;
            Debug.WriteLine("確認資料庫表單是否存在: " + commandCreateTable);
            CommandExcute(commandCreateTable);

            setuped = true;
        }

        public void Insert(string topic, string message)
        {
            if (!setuped)
            {
                return;
            }

            var commandString = "INSERT OR IGNORE INTO `" + TableName + "` VALUES (null ,DATETIME('now', 'localtime') ,'" + topic + "','" + message + "')"; ;
            CommandExcute(commandString);
        }

        public void Select(string topic, string keyword)
        {
            if (!setuped)
            {
                return;
            }

            List<string> topicData = new List<string>();

            var commandString = "SELECT * FROM " + TableName + " WHERE `Topic` =='" + topic + "' AND `Message` LIKE '%" + keyword + "%'";
            Debug.WriteLine("Command : " + commandString);
            var results = CommandExcute(commandString).ExecuteReader();

            while (results.Read())
            {
                var msg = string.Format("{0},{1},{2},{3}",results.GetString(0),results.GetString(1),results.GetString(2),results.GetString(3));
                Debug.WriteLine(msg);
            }
        }

        protected SQLiteCommand CommandExcute(string sqlCommand)
        {
            SQLiteCommand result;

            connection.Open();

            using (var command = new SQLiteCommand(sqlCommand, connection))
            {
                command.ExecuteNonQuery();
                result = command;
            }

            connection.Clone();

            return result;
        }
    }
}
