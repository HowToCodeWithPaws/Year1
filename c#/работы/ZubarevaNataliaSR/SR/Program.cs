/// <summary>
/// Самостоятельная работа номер 3.
/// </summary>
/// <remarks>
/// <para>Автор: Зубарева Наталия</para>
/// <para>Группа: БПИ199(2)</para>
/// <para>Дата: 15.10.2019</para>
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SR
{
	class Program
	{
		/// <summary>
		/// Метод осуществляет преобразование массива следующим образом:
		/// для каждого элемента массива его значение умножается на 0 или 1
		/// генерируемые с равной вероятностью методом random.
		/// Альтернативное решение: вместо умножения значения на число можно
		/// было бы в условном операторе if else проверять, сгенерировался 0 или 1,
		/// и в завсисимости от этого либо сохранять значение, либо приравнивать к 0.
		/// </summary>
		/// <param name="data"> В метод передается ссылка на изменяемый массив. </param>
		public static void ThanosSnap(int [] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				data[i] *= random.Next(0, 2);
			}
		}

		/// <summary>
		/// Метод создает и возвращает массив данного размера с элементами лежащими в 
		/// границах данного модуля.
		/// </summary>
		/// <param name="number"> Передаваемое в метод значение количества элементов массива. </param>
		/// <param name="module"> Передаваемое в метод значение границ модуля элементов массива. </param>
		/// <returns> Метод озвращает созданный массив. </returns>
		public static int [] GenerateArray(uint number, uint module)
		{
			int[] array = new int [number];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = random.Next((int)(-module + 1), (int)module);
			}

			return array;
		}

		/// <summary>
		/// Метод выводит сообщение с просьбой ввести данные и осуществляет
		/// считывание переменной указанного типа с использованием метода 
		/// TryParse в цикле do while до тех пор, пока пользователь не введет
		/// данные, для которых осуществится парсинг и которые будут лежать в 
		/// границах возможных значений.
		/// </summary>
		/// <param name="message"> Передаваемое сообщение для вывода. </param>
		/// <param name="line"> Передаваемое значение для границ считываемой переменной. </param>
		/// <returns>Метод возвращает считанные данные, приведенные к требуемому 
		/// типу. </returns>
		public static uint Read(string message, uint line)
		{
			uint input;

			do
			{
				Console.WriteLine(message);
			} while (!uint.TryParse(Console.ReadLine(), out input) || input == 0 || (input>line));

			return input;
		}

		/// <summary>
		/// Метод генерирует случайные числа.
		/// </summary>
		static Random random = new Random();

		/// <summary>
		/// В методе происходит повтор решения, объявление переменных, вызов методов чтения
		/// переменных, метода создания и изменения массива, далее в блоке try catch 
		/// происходит запись данных в файл и обработка возможных исключений.
		/// </summary>
		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				// Переменные целого беззнакового типа для количества элементов массива
				// и модуля границ их величин, натуральные числа меньше 100 и 1000 соответственно.
				uint numberOfData, randomModule;

				// Вызов метода чтения количества чисел в массиве.
				numberOfData = Read("Введите количество элементов в массиве", 99);

				// Вызов метода чтения границ элементов массива.
				randomModule = Read("Введите модуль границ элементов массива", 999);

				// Вызов метода создания массива.
				int[] array = GenerateArray(numberOfData, randomModule);

				// Вызов метода изменения массива.
				ThanosSnap(array);

				/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
				try
				{
					// Очищение или создание файла.
					File.WriteAllText(@"../../../reducedData.txt", "");

					// В цикле к файлу с помощью AppendAllText приписывается по одному элементу массива с новой стоки.
					// Альтернативное решение: можно было разбить массив на элементы с помощью 
					// split и записать в файл с помощью WriteAllText, склеивая элементы на новых строках через 
					// String.Join.
					for (int i = 0; i < array.Length; i++)
					{
						File.AppendAllText(@"../../../reducedData.txt", $"\n{array[i]}");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
