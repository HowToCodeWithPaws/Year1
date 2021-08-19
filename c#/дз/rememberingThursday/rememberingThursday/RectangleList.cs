using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace rememberingThursday
{
	public class RectangleList
	{

		List<string> readings = new List<string>();
		Rectangle[] rectangles;

		int[] ind;

		public RectangleList()
		{
			try
			{
				FileReading();

				CheckValidity();

				ind = new int[rectangles.Length];

				for (int i = 0; i < ind.Length; i++)
				{
					ind[i] = i;
				}

				Order();


			}
			catch (Exception)
			{
				throw;
			}
		}

		void FileReading()
		{
			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				using (StreamReader reader = new StreamReader("../../../Файл_1.txt"))
				{
					while (!reader.EndOfStream)
					{
						readings.Add(reader.ReadLine());
					}
				}
			}
			catch (DirectoryNotFoundException)
			{
				throw new MyException("Директория не существует");
			}
			catch (FileNotFoundException)
			{
				throw new MyException("Файл не существует");
			}
			catch (IOException)
			{
				throw new MyException("Ошибка ввода/вывода");
			}
			catch (UnauthorizedAccessException)
			{
				throw new MyException("Ошибка доступа: у вас нет разрешения на доступ файлу");
			}
			catch (System.Security.SecurityException)
			{
				throw new MyException("Ошибка безопасности");
			}
		}

		void CheckValidity()
		{
			for (int i = 0; i < readings.Count; i++)
			{
				if (string.IsNullOrEmpty(readings[i])
					|| (readings[i].Split(' ')).Length < 2
					|| !uint.TryParse((readings[i].Split(' '))[0], out uint a)
					|| !uint.TryParse((readings[i].Split(' '))[1], out uint b))
				{
					readings.RemoveAt(i);
					--i;
				}
			}

			if (readings.Count < 10)
			{
				throw new MyException("В исходном файле меньше 10 нормальных строк. што вы делоетее");
			}

			rectangles = new Rectangle[readings.Count];

			for (int i = 0; i < rectangles.Length; i++)
			{
				rectangles[i] = new Rectangle(
					uint.Parse((readings[i].Split(' '))[0]),
					uint.Parse((readings[i].Split(' '))[1]));
			}
		}

		void Order()
		{
			for (int i = 0; i < rectangles.Length; i++)
			{
				for (int j = 0; j < rectangles.Length - 1; j++)
				{
					if (rectangles[ind[j]].CompareTo(rectangles[ind[j + 1]]) > 0)
					{
						int temp = ind[j + 1];
						ind[j + 1] = ind[j];
						ind[j] = temp;
					}
				}
			}

		}

		public string OrderedRectangles()
		{
			string info = string.Empty;

			for (int i = 0; i < ind.Length; i++)
			{
				info += $"{rectangles[ind[i]].ToString()}\n";
			}

			return info;
		}

		public override string ToString()
		{
			string info = string.Empty;

			foreach (Rectangle rectangle in rectangles)
			{
				info += $"{rectangle.ToString()}\n";
			}

			return info;
		}
	}
}
