using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskE
{
	class Program
	{
		/// <summary>
		/// Метод в цикле for считывает по одному номеру, проверяет корректность вводимых данных, если данные неверны - выводит строку wrong, иначе в 
		/// зависимости от того, как этот номер соотносится с другими номерами, по-разному вычисляет число, имеющее этот номер в последовательности
		/// Фибоначчи, а затем выводит полученный результат в консоль.
		/// </summary>
		/// <param name="numberOfNumbers"> Метод принимает на вход количество вводимых номеров. </param>

		static void Fibonacci(ulong numberOfNumbers)
		{
			// Переменные длинного беззнакового типа для хранения текущего и предыдущего номеров в последовательности, предыдущего и текущего чисел 
			// (для изначального входа в метод предыдущий номер равен 0, предыдущее число - нулевое по счету, =0, текущее число - 1, первое в ряду).

			ulong indexNumber, previousIndexNumber = 0, previousNumber = 0, number = 1;

			// Переменная булевого типа для проверки корректности считывания номера числа в последовательности.

			bool readIndex;

			// В цикле for столько раз, какое было введено количество номеров, происходит считывание номера, проверка ввода и решение с ОпТиМиЗаЦиЕй.

			for (ulong i = 0; i < numberOfNumbers; i++)
			{
				// Вызов метода считывания для номера числа в последовательности.

				indexNumber = Read(out readIndex);

				// Проверка корректности входных данных.

				if (readIndex && indexNumber > 0)
				{
					// Далее в зависимости от входящего номера происходит ветвление решения в условном операторе if с целью опТИМиЗаЦиИ.

					if (indexNumber == previousIndexNumber - 1)
					{
						Console.WriteLine($"we are in previous-1");
						// Если вводится номер, на 1 меньше предыдущего введенного номера, выводится число, использованное для рассчета в прошлый раз.

						Console.WriteLine($"{previousNumber}");
						previousIndexNumber = indexNumber;
						previousNumber = number;
					}

					if (indexNumber == previousIndexNumber)
					{
						// Если вводится номер, равный предыдущему вводимому номеру, то выводится число, посчитанное в прошлый раз.

						Console.WriteLine($" we are in = previous\n{number}");

					}

					if (indexNumber > previousIndexNumber)
					{
						Console.WriteLine($" we are in > previous  and prev.number = {previousNumber} and number {number} ");
						for (ulong j =previousIndexNumber; j < indexNumber; j++)
						{
							// Все числа сразу же берутся по mod 2^30, чтобы облегчить вычисления.
				//			Console.WriteLine($"we are into this flawed shit. prev.index = {previousIndexNumber} this index = {indexNumber} prev.number = {previousNumber} prev.tothis.number = {number}");
							ulong saveNumber = (ulong)(number % 1073741824);
							number = (ulong)((number  + previousNumber) % 1073741824);
							previousNumber = saveNumber;
						}
						Console.WriteLine($" we are in > previous  and prev.number = {previousNumber}\n{number} ");

					}
					else {
						if (indexNumber < previousIndexNumber - 1)
						{
							// Если новый введенный номер не равен ни предыдущему, ни предпредыдущему, рассчитывается число с таким номером в последовательности.

							number = 1;
							previousNumber = 1;

							// В цикле for вычисляется число по реккурентному соотношению для последовательности Фибоначчи.

							for (ulong j = 2; j < indexNumber; j++)
							{
								// Все числа сразу же берутся по mod 2^30, чтобы облегчить вычисления.

								ulong saveNumber = (ulong)(number % 1073741824);
								number = (ulong)((number + previousNumber) % 1073741824);
								previousNumber = saveNumber;
							}
							Console.WriteLine($" we are in the most stupid of them all\n{number}");
							previousIndexNumber = indexNumber;
							previousNumber = number;
						}
					}

					

					// Переменная для предыдущего введенного номера приравнивается к введенному только что номеру.


					// Происходит вывод посчитанного ответа.

	//				Console.WriteLine($"{number}");

				}
				else
				{
					// Если данные введены неверно, выводится строка wrong и работа программы завершается.

					Console.WriteLine("wrong");
				}
			}
		}

		/// <summary>
		/// Метод считывает строку и пытается преобразовать ее переменную длинного беззнакового типа
		/// с помощью метода TryParse, возвращает через return значение переменной и через out переменную булевого типа, показывающую,
		/// удалось ли преобразование (корректны ли входные данные).
		/// </summary>
		/// <param name="input"> Считываемая переменная. </param>
		/// <param name="readIn"> Переменная булевого типа, отражающая корректность вводных данных для переменной. </param>
		/// <returns> In - считываемую переменную. /returns>

		static ulong Read(out bool readIn)
		{
			ulong input;
			readIn = ulong.TryParse(Console.ReadLine(), out input);
			return input;
		}

		/// <summary>
		/// 
		/// </summary>

		static void Main(string[] args)
		{
			// Переменная длинного беззнакового типа для количества вводимых номеров.

			ulong numberOfNumbers;

			// Переменная булевого типа для проверки корректности ввода числа номеров.

			bool readNumberOfNumbers;

			// Вызов метода чтения для числа номеров.

			numberOfNumbers = Read(out readNumberOfNumbers);

			// Проверка корректности вводных данных.

			if (readNumberOfNumbers && numberOfNumbers > 0)
			{
				// Если данные верны, вызывается метод, вычисляющий и выводящий число Фибоначчи для каждого введенного далее номера.

				Fibonacci(numberOfNumbers);
			}
			else
			{
				// Если данные неверны, выводится строка wrong и работа программы завершается.

				Console.WriteLine("wrong");
			}
		}
	}
}