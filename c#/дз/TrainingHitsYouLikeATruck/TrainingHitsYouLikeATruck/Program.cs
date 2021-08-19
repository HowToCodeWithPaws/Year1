using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using static ClassLibrary1.Utilities;
using System.IO;

namespace TrainingHitsYouLikeATruck
{
	class Program
	{
		static void FillTheFile()
		{


				byte[] text = new byte[1000];

				for (int i = 0; i < 1000; i++)
				{
					text[i] = (byte)random.Next(0, 128);
				}

				/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
				try
				{
					File.WriteAllText("../../../Project1/data.txt", string.Join(" ", text));
				}
				catch (IOException)
				{
					Console.WriteLine("Ошибка ввода/вывода");
				}
				catch (UnauthorizedAccessException)
				{
					Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла");
				}
				catch (System.Security.SecurityException)
				{
					Console.WriteLine("Ошибка безопасности");
				}
				finally
				{
					Console.WriteLine("Мы закончили работу с файлом");
				}

		}

		static void Main(string[] args)
		{

			FillTheFile();

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				string allData = string.Empty;
				bool proceed = true;

				/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
				try
				{
					allData = File.ReadAllText("../../../Project1/data.txt");
				}
				catch (FileNotFoundException e)
				{
					Console.WriteLine("Файл еще не существует, сначала создайте его " +
						"(для этого, пожалуйста, запустите первый проект в решении)" + e);
					proceed = false;
				}
				catch (IOException e)
				{
					Console.WriteLine("Ошибка ввода/вывода" + e);
					proceed = false;
				}
				catch (UnauthorizedAccessException e)
				{
					Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла" + e);
					proceed = false;
				}
				catch (System.Security.SecurityException e)
				{
					Console.WriteLine("Ошибка безопасности" + e);
					proceed = false;
				}
				finally
				{
					Console.WriteLine("Мы закончили работу с файлом");
				}

				if (proceed)
				{
					LimitedSymbolChain chainLatinSmall = new LimitedSymbolChain('a', 'z');
					LimitedSymbolChain chainNumbers = new LimitedSymbolChain('0','9');
					LimitedSymbolChain chainLatinCapital = new LimitedSymbolChain('A','Z');

					string[] symbols;

					symbols = allData.Split(' ');

				
					byte byteSymb;
					bool isRecognised = false;
					int unrecognized = 0;

					for (int i = 0; i < symbols.Length; i++)
					{
						if (!byte.TryParse(symbols[i], out byteSymb))
						{
							Console.WriteLine("Символ в файле не соответствует формату");
						}
						else
						{
					
							try
							{
								isRecognised = false;

								if (byteSymb >= 'a' && byteSymb <= 'z')
								{
									chainLatinSmall.AddToChain((char)byteSymb);
									isRecognised = true;
								}

								if (byteSymb >= 'A' && byteSymb <= 'Z')
								{
									chainLatinCapital.AddToChain((char)byteSymb);
									isRecognised = true;
								}

								if (byteSymb >= '0' && byteSymb <= '9')
								{
									chainNumbers.AddToChain((char)byteSymb);
									isRecognised = true;
								}

								if (!isRecognised)
								{
									unrecognized++;
								}
							}
							catch (ArgumentOutOfRangeException)
							{
								Console.WriteLine("Символ не соответствует границам");
							}
						}
					}

					Console.WriteLine("Строка прописных латинских букв: " +
						   chainLatinSmall.ToString()
						   + Environment.NewLine +
						   $"Длина строки: {chainLatinSmall.GetChainLength}"
						   + Environment.NewLine +
						   "Строка цифр:" +
						   $"{chainNumbers.ToString()}"
						   + Environment.NewLine +
						   $"Длина строки: {chainNumbers.GetChainLength}"
							+ Environment.NewLine
						   + "Строка заглавных латинских букв: "
						   + chainLatinCapital.ToString() +
						   Environment.NewLine +
						   $"Длина строки: {chainLatinCapital.GetChainLength}" +
						   Environment.NewLine +
						   $"Неопознанных символов: {unrecognized}");

				}

				Console.WriteLine("\nДля повторного решения нажмите Enter," +
					" для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
