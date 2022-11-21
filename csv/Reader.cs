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

	public enum FieldTypes : int { 
		SINGLE_SELECT = 0,
		MULTI_SELECT = 1,
		TEXT = 2,
		RADIO_BUTTON = 3,
		CHECKBOX = 4,
		TEXTAREA = 5,
	}

	public class ItemOptions
	{
		public string option_name;
		public int field_type;
		public bool required;
		public string value;

		public ItemOptions(string option_name, string field_type, string required, string value) {
			this.option_name = option_name;
			this.field_type = Convert.ToInt32(field_type);
			this.required = required == "1";
			this.value = value;
		}

	}

	public class CSVFile
	{
		public string PostID;
		public string Title;
		public string ItemCode;
		public ItemOptions[] ItemOptions;

		public CSVFile(string postID, string title, string item_code, string[] item_options) {
			this.PostID = postID;
			this.Title = title;
			this.ItemCode = item_code;
			List<ItemOptions> opts = new List<ItemOptions>();

			int count = 0;
			string option_name = "";
			string field_type = "";
			string required = "";
			string value = "";
			Regex re = new Regex("\"");
			foreach (string option in item_options) {
				if (count == 4) {
					ItemOptions opt = new ItemOptions(option_name, field_type, required, value);
					opts.Add(opt);
					count = 0;
				}
				string replaced_option = re.Replace(option, "");
				switch (count) 
				{
					case 0:
						option_name = replaced_option;
						break;
					case 1:
						field_type = replaced_option;
						break;
					case 2:
						required = replaced_option;
						break;
					case 3:
						value = replaced_option;
						break;
					default:
						break;

				}

				count += 1;
			}
			this.ItemOptions = opts.ToArray();

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
