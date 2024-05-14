using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            connection.Open();
            Debug.WriteLine("確認資料庫表單是否存在: " + commandCreateTable);
            CommandExcute(commandCreateTable);

            setuped = true;
        }

        public void Close()
        {
            if (setuped)
            {
                connection.Close();
            }
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

        public Dictionary<string, string>? Select(string topic, List<string> keywords, bool orLogic = false)
        {
            if (!setuped)
            {
                return null;
            }

            Dictionary<string, string> selectData = new Dictionary<string, string>();

            var commandString = "SELECT * FROM " + TableName + " WHERE `Topic` =='" + topic + "' ";

            foreach (var keyword in keywords)
            {
                if (orLogic)
                {
                    commandString += "OR `Message` LIKE '%" + keyword + "%' ";
                }
                else
                {
                    commandString += "AND `Message` LIKE '%" + keyword + "%' ";
                }
            }
            Debug.WriteLine("Command : " + commandString);

            var sqlcommand = new SQLiteCommand(commandString, connection);
            using (SQLiteDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var ai = reader["_AI"].ToString();
                    var messagedata = reader["Message"].ToString();
                    //Debug.WriteLine("Select [{0}]:{1}", topicdata, messagedata);

                    selectData.Add(
                        ai,
                        messagedata
                    );
                }
            }

            return selectData;
        }

        public List<string> GetColumnName()
        {
            List<string> columns = new List<string>();

            var commandString = "PRAGMA table_info('" + TableName + "')";
            var sqlcommand = new SQLiteCommand(commandString, connection);
            using (SQLiteDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    //  0=編號,1=名稱,2=資料型態
                    var name = reader[1].ToString();
                    columns.Add(name);
                }
            }

            return columns;
        }

        public List<string> GetTopicType()
        {
            List<string> topics = new List<string>();
            HashSet<string> uniqueTopic = new HashSet<string>();

            var commandString = "SELECT `Topic` FROM " + TableName;
            var sqlcommand = new SQLiteCommand(commandString, connection);


            using (SQLiteDataReader reader = sqlcommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    //  0=編號,1=名稱,2=資料型態
                    var topic = reader[0].ToString();
                    uniqueTopic.Add(topic);
                }
            }

            foreach (var topic in uniqueTopic)
            {
                //Debug.WriteLine("Topic : " + topic);
                topics.Add(topic);
            }

            return topics;
        }

        protected SQLiteCommand CommandExcute(string sqlCommand)
        {
            SQLiteCommand result;

            //connection.Open();

            using (var command = new SQLiteCommand(sqlCommand, connection))
            {
                command.ExecuteNonQuery();
                result = command;
            }

            //connection.Clone();

            return result;
        }
    }
}
