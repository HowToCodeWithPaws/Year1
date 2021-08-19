using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XORSipher
{
	class Program
	{
		static Random random = new Random();

		//StreamReader, StreamWriter - reading and writing from stream
		// Better than File. as they are faster and the amount of processed symbols can be controlled

		private static string Encrypt(string message, short key)
		{
			string res = string.Empty;

			for (int i = 0; i < message.Length; i++)
			{
				res += (char)(message[i] ^ key);
			}
			return res;
		}

		static void Main(string[] args)
		{
		 // С помощью цикла do while с условием нажатия клавиши Enter
		 // (проверка с помощью метода Console.ReadKey()) реализуется возможность
		 // повторного решения задачи по желанию пользователя.
			do
			{

				/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
				short key;
				try
				{
					byte[] binaryKey = File.ReadAllBytes();
					key = BitConverter.ToInt16(binaryKey, 0);
				}
				catch (Exception e)
				{
					key = (short)random.Next(Int16.MinValue, Int16.MaxValue+1);
				}

				
				Console.WriteLine("Введите строку для шифрования");
				string message = Console.ReadLine();

				string res = Encrypt(message, key);

using (StreamWriter streamWriter = new StreamWriter("../../../encryptedData.txt"))
				{
					streamWriter.WriteLine(key);

				}

				using (StreamReader streamReader = new StreamReader("../../../encryptedData.txt"))
				{

					key = Int16.Parse(streamReader.ReadLine());
				}


				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);

		}
	}
}
