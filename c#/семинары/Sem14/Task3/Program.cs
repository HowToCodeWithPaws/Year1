using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	class Program
	{
		static int[] stat = new int[26]; // статистика по лат. буквам
		static void Main(string[] args)
		{
			string tmp;
			int openBrackets = 0; // количество {
			int closedBrackets = 0; // количество }
			int total = 0; // общее количество символов файла

			var In = Console.In; // Запоминаем стандартный входной поток
								 // Создаем файл и текстовый входной поток: 
			StreamReader stream_in = new StreamReader(@"..\..\Program.cs");
			// Настраиваем стандартный входной поток на чтение из файла:
			Console.SetIn(stream_in);
			// чтение из файла
			// восстановление потока

		}
	}
