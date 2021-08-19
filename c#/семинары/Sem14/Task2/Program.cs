using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	class Program
	{
		public static bool Validate(string str)
		{
			// TODO: требуется валидировать строки с заглавные латинскими
			// символами также как верные
			char[] english = new char[27];
			english[0] = ' ';
			for (int i = 1; i < english.Length; i++)
			{
				english[i] = (char)('a' + i);
			}
			if (str.IndexOfAny(english) < 0) return false;
			return true;
		} // end of Validate(string)
		  // получение массива строк
		  // каждый элемент проверен на соответствие формату
		public static string[] ValidatedSplit(string str, char ch)
		{
			string[] output = null;
			output = str.Split(ch);
			foreach (string s in output)
			{
				if (!Validate(s)) return null;
			}
			return output;
		} // end of ValidatdSplit(string, char)

		public static string Shorten(string str)
		{
			// TODO: учесть заглавные гласные
			char[] alph = { 'a', 'e', 'i', 'o', 'u', 'y' };
			int ind = str.IndexOfAny(alph);
			return str.Substring(0, ind + 1);
		} // end of Shorten(string)
		  // Метод создания аббревиатуры для ПОДстроки (в ней много слов)
		public static string Abbrevation(string str)
		{
			string output = String.Empty;
			if (str != String.Empty)
			{
				string[] tmp = str.Split(' ');
				foreach (string s in tmp)
				{
					string shortenS = Shorten(s);
					FirstUpcase(ref shortenS);
					output += shortenS;
				}
			}
			return output;
		} // end of Abbrevation(string)

		public static void FirstUpcase(ref string str)
		{
			// TODO: буквы после первой могут быть не приведены к нижнему
			// регистру
			char[] chars = str.ToCharArray();
			str = str[0].ToString().ToUpper() + str.Substring(1);
		} // end of FirstUpcase(ref string)


		static void Main(string[] args)
		{
		}
	}
}
