using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem14
{
	class Program
	{
		static Random gen = new Random();
		// comment - строка-сообщение для получения данных
		public static int GetIntValue(string comment)
		{
			int intVal;
			do Console.Write(comment);
			while (!int.TryParse(Console.ReadLine(), out intVal));
			return intVal;
		}
		// Удалить из строки s1 все символы другой строки s2:
		public static string MoveOff(string s1, string s2)
		{
			string res = s1;
			int index;
			for (int i = 0; i < s2.Length; i++)
				while ((index = res.IndexOf(s2[i])) >= 0)
					res = res.Remove(index, 1);
			return res;
		} // end of MoveOff()
		public static string CreateString(int k, char minChar, char maxChar)
		{
			if (k < 0)
				throw new Exception("Аргумент метода должен быть положительным!");
			// minChar, minChar - границы диапазона символов
			if (maxChar < minChar)
			{
				char c = minChar;
				minChar = maxChar;
				maxChar = c;
			}
			// пустая строка, останется пустой, если символов 0
			string line = String.Empty;
			for (int i = 0; i < k; i++)
				line += (char)gen.Next(minChar, maxChar + 1);
			return line;
		} // end of GetString()

		static void Main(string[] args)
		{
		}
	}
}
