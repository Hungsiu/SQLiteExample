using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExample
{
    public class SQLitor
    {
        protected string DbPath = Application.StartupPath;
        protected string DbFile = "Data.db";

        protected SQLiteConnection connection = new SQLiteConnection();
        protected string commandCreateDataBase =
            @"CREATE TABLE IF NOT EXISTS NewDataBase (
				_AI      INTEGER  PRIMARY KEY AUTOINCREMENT,
				DateTime DATETIME,
				Topic    TEXT,
				Message  TEXT
			);";

        public SQLitor(string dbPath = "Datas", string dbFile = "Data.db")
        {
            DbPath = Application.StartupPath + "\\" + dbPath;
            DbFile = dbFile;

            Setup();
        }

        protected void Setup()
        {
            connection.Open();
        }

        public void CommandExcute(string sqlCommand)
        {
            //  DB目錄不存在就建立一個
            if (!Directory.Exists(DbPath))
                Directory.CreateDirectory(DbPath);

            //  DB檔案不存在就建立一個
            if (!File.Exists(DbFile))
                Directory.CreateDirectory(DbPath + "\\" + DbFile);

            var DataSource = DbPath + DbFile;
            connection.ConnectionString = "Data source = " + DataSource;
        }
    }
}
