using System;
using System.IO;
using System.Globalization;

namespace Log
{
    public class Log
    {
        DateTime localData = DateTime.Now;
        string datetime;
        public int code;
        public string status_text;
        public string message;

        public Log(int code, string status_text, string message)
        {
            string date = localData.Year.ToString() + "/" + localData.Month.ToString() + "/" + localData.Day.ToString();
            string time = localData.Hour.ToString() + ":" + localData.Minute.ToString() + ":" + localData.Second.ToString();
            this.datetime = date + " " + time;
            this.code = code;
            this.status_text = status_text;
            this.message = message;
        }

        public string toString() 
        {
            return this.datetime + " " + this.code.ToString() + " " + this.status_text + " " + this.message;
        }


    }

    public class LogWriter
    {
        string path;
        public LogWriter(string path) 
        {
            if (!File.Exists(path)) 
            {
                File.Create(path);
            }
            this.path = path;
        }

        public void Add(Log log) 
        {
            File.AppendAllText(this.path, log.toString() + "\n");
        }
    }
}
