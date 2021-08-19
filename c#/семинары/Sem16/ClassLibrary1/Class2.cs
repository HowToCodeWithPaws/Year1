using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public class Class2
	{
		public delegate void StringProcDelegate(string input);

		public static void ReportWordsCount(string st)
		{
			string[] strs = st.Split(' ');
			Console.Write("Количество слов в строке: " + strs.Length+Environment.NewLine);
		}


	}
}
