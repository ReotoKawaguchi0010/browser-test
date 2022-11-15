using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace CSV
{

    public enum Indexes : int {
        POST_ID=0,
        TITLE=3,
        ITEM_CODE=10,
        ITEM_OPTIONS_START=45,
    }
    public class CSVFile
    {
        public string PostID;
        public string Title;
        public string ItemCode;
        public string[] ItemOptions;

        public CSVFile(string postID, string title, string item_code, string[] item_options) {
            this.PostID = postID;
            this.Title = title;
            this.ItemCode = item_code;
            this.ItemOptions = item_options;
        }
    }
    public class Reader
    {
        public CSVFile[] objects;

       
        public void Open(string csv)
        {
            if (this.isCSVFile(csv)) {
                int counter = 0;
                List<CSVFile> l = new List<CSVFile>();
                foreach (string line in File.ReadLines(csv))
                {
                    if (counter == 0) {
                        counter++;
                        continue;
                    }
                    Regex regex = new Regex(",");
                    string[] array = regex.Split(line);
                    if (array.Length == 0) return;
                    
                    string postID = array[(int)Indexes.POST_ID];
                    string title = array[(int)Indexes.TITLE];
                    string item_code = array[(int)Indexes.ITEM_CODE];
                    List<string> item_options = new List<string>();
                    for (int i = (int)Indexes.ITEM_OPTIONS_START; i < array.Length; i++) {
                        item_options.Add(array[i]);
                    }

                    var ob = new CSVFile(postID, title, item_code, item_options.ToArray());
                    l.Add(ob);
                    counter++;
                }
                this.objects = l.ToArray();
            }
        }

        private bool isCSVFile(string csv) 
        {
            string pattern = @".*\.csv";
            Regex re = new Regex(pattern);
            if (re.Match(csv).Success) {
                return true;
            }
            return false;
        }
        public string toString() 
        {
            return "";
        }

        public bool hasIndex(int index) {
            if (this.objects.Length > index) {
                return true;
            }
            return false;
        }

        public CSVFile Get(int index) {

            if( this.hasIndex(index)) {
                return this.objects[index];
            }
            return null;
        }
    }
}
