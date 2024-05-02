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
        protected SQLiteConnection connection = new SQLiteConnection();

        protected string LogPath { get; private set; } = "C:\\Logs";
        protected string LogFile { get; private set; } = "Log.db";

        public void Setup(string logPath="Logs",string logFile="Log.db")
        {
            LogPath = Application.StartupPath + "\\" + logPath;
            LogFile = logFile;

            connection.Open();

        }
    }
}
