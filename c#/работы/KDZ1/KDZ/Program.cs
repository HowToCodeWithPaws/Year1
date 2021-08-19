using System;
using System.Linq;
using GameClassLibrary;


namespace KDZ
{
	class Program
	{
		/// <summary>
		/// Метод выводит сообщение с переданной информацией и осуществляет
		/// считывание переменной указанного типа с использованием метода 
		/// TryParse в цикле do while до тех пор, пока пользователь не введет
		/// данные, для которых осуществится парсинг, также метод принимает
		/// на вход границы значений считываемого числа, соответствие которым
		/// также проверяется внутри условия do while.
		/// </summary>
		/// <param name="message"> Входной параметр выводимого сообщения. </param>
		/// <param name="minvalue"> Входной параметр нижней границы значения 
		/// числа. </param>
		/// <param name="maxvalue"> Входной параметр верхней границы значения
		/// числа. </param>
		/// <returns>Метод возвращает считанные данные, приведенные к требуемому 
		/// типу.</returns>
		public static int Read(string message, int minvalue = int.MinValue,
			int maxvalue = int.MaxValue)
		{
			int input = 0;

			// Блок try catch для обработки возможных исключений 
			// (они не случаются, но все же).
			try
			{
				do
				{
					Console.Write(message);
				} while (!int.TryParse(Console.ReadLine(), out input)
						|| input < minvalue || input > maxvalue);
			}
			catch (OutOfMemoryException)
			{
				Console.WriteLine("Случилось переполнение при вводе, " +
					"перезапустите программу.");
			}
			catch (System.IO.IOException)
			{
				Console.WriteLine("Случилась ошибка ввода, " +
					"перезапустите программу.");
			}

			return input;
		}

		/// <summary>
		/// Метод инициализирует игру, получая имена игроков.
		/// </summary>
		/// <param name="player1Name"> Имя первого игрока. </param>
		/// <param name="player2Name"> Имя второго игрока. </param>
		public static void Initialization(ref string player1Name,
			ref string player2Name)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("\t\t\t\t\t\t\t\t" +
				"~~~~ДОБРО ПОЖАЛОВАТЬ В ИГРУ~~~~");
			Console.ForegroundColor = ConsoleColor.White;

			nameChoice(ref player1Name, 1);
			nameChoice(ref player2Name, 2);
		}

		/// <summary>
		/// Метод позволяет игрокам выбрать имена.
		/// Имя не может состоять из пробелов, пустой строки
		/// или быть длиннее 10 символов.
		/// </summary>
		/// <param name="playerName"> Имя игрока. </param>
		/// <param name="number"> Номер игрока, первый или второй. </param>
		public static void nameChoice(ref string playerName, int number)
		{
			Console.Write($"\n\t\t\t\t\t\t\t\tИгрок {number}," +
				$" введите свое имя, не длиннее 10 букв: ");
			string tempName = Console.ReadLine();
			if (!(tempName == null || tempName.All(e => e == ' ')
				|| tempName == "" || tempName.Length>10))
				playerName = tempName;
			Console.WriteLine($"Ваше имя {playerName}");
		}

		/// <summary>
		/// Метод задает массив кораблей для каждого игрока.
		/// </summary>
		/// <param name="playerName"> Имя игрока. </param>
		/// <returns> Возвращает экземпляр класса 
		/// FleetArray. </returns>
		public static FleetArray PickTheShips(string playerName)
		{
			Ship[] ships = new Ship[5];

			Console.WriteLine($"\n\t\t\t\t\t\t\t{playerName}, " +
				$"вам нужно выбрать 5 кораблей для вашего флота:");

			// Маркер, показывающий, есть ли во флоте грузовое судно.
			bool cargoPicked = false;

			// В цикле 5 раз предлагается выбрать корабль для
			// формирования флота фиксированного размера.
			// Альтернативное решение (who?!): можно было создать
			// список кораблей, имеющий гибкий размер и не выбирать
			// ровно 5, но в таком случае работа с флотом была бы 
			// менее удобной, а так как в условии это не оговорено,
			// будет массив.
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine($"\nУ вас есть {40 - 8 * i} " +
					$"игровых монет\n\nВы можете приобрести:");

				// Блок try catch для обработки возможных исключений 
				// (они не случаются, но все же).
				try
				{
					// Так как грузовое судно можно выбрать только одно,
					// в зависимости от маркера его выбранности 
					// предлагается разное меню выбора.
					if (!cargoPicked)
					{
						Console.WriteLine("\n\t\t\t\t\t" +
							"1. Грузовое судно за 8 монет" +
							"\t\t2. Линкор за 8 монет" +
							"\t\t3. Эсминец за 8 монет");

						ships[i] = Choice(ref cargoPicked);
					}
					else
					{
						Console.WriteLine("\n\t\t\t\t\t" +
							"Грузовое судно выбрать нельзя" +
							"\t\t2. Линкор за 8 монет\t\t3. Эсминец за 8 монет");

						ships[i] = Choice();
					}
				}
				catch (IndexOutOfRangeException)
				{

					Console.WriteLine("Произошла ошибка в работе с " +
						"массивом, перезапустите программу."); ;
				}
			}

			return new FleetArray(playerName, cargoPicked, ships);
		}

		/// <summary>
		/// Метод, с помощью switch case определяющий корабль
		/// по введенному числу. Число вводится с помощью метода
		/// со встроенной проверкой введенных значений, так что 
		/// пункт default - это перестраховка. Данное меню работает,
		/// когда грузовое судно еще не выбрано.
		/// </summary>
		/// <param name="cargoPicked"> Условие невыбранности
		/// грузового судна. </param>
		/// <returns> Метод возвращает экземпляр того или иного
		/// класса - корабля с случайно сгенерированными 
		/// параметрами. </returns>
		public static Ship Choice(ref bool cargoPicked)
		{
			// Ветвление в зависимости от выбора.
			switch (Read("\nВведите цифру 1, 2 или 3 " +
						"- ваш выбор: ", 1, 3))
			{
				case 1:
					Console.WriteLine("Вы выбрали грузовое судно");
					cargoPicked = true;
					return new CargoShip(
						Utilities.random.Next(1500, 2000)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(40, 71));
				case 2:
					Console.WriteLine("Вы выбрали линкор");
					return new Battleship(
						Utilities.random.Next(4500, 5500)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(2000, 2500)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(12, 18),
						Utilities.random.Next(30, 70)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(50, 71),
						Utilities.random.Next(5, 8));
				case 3:
					Console.WriteLine("Вы выбрали эсминец");
					return new Destroyer(
						Utilities.random.Next(3800, 4500)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(1000, 1800)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(15, 23),
						Utilities.random.Next(60, 100)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(50, 71));
				default:
					Console.WriteLine("Вы ввели что-то не то," +
						" пожалуйста, повторите ввод");
					return null;
			}
		}

		/// <summary>
		/// Перегрузка метода выбора, когда грузовое судно
		/// уже выбрано.
		/// </summary>
		/// <returns> Возвращает экземпляр класса корабля
		/// с сгенерированными параметрами. </returns>
		public static Ship Choice()
		{
			switch (Read("\nВведите цифру 2 или 3 " +
						"- ваш выбор: ", 2, 3))
			{
				case 2:
					Console.WriteLine("Вы выбрали линкор");
					return new Battleship(
						Utilities.random.Next(4500, 5500)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(2000, 2500)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(12, 18),
						Utilities.random.Next(30, 70)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(50, 71),
						Utilities.random.Next(5, 8));
				case 3:
					Console.WriteLine("Вы выбрали эсминец");
					return new Destroyer(
						Utilities.random.Next(3800, 4500)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(1000, 1800)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(15, 23),
						Utilities.random.Next(60, 100)
						+ Utilities.random.NextDouble(),
						Utilities.random.Next(50, 71));
				default:
					Console.WriteLine("Вы ввели что-то не то," +
						" пожалуйста, повторите ввод");
					return null;
			}
		}

		/// <summary>
		/// Метод позволяет игроку в свой ход выбрать корабль,
		/// который будет вступать в бой.
		/// </summary>
		/// <param name="attackingFleet"> Метод принимает атакующий
		/// флот. </param>
		/// <returns> Метод возвращает номер выбранного корабля. </returns>
		public static int PickTheAttackingShip(FleetArray attackingFleet)
		{
			Console.Write($"\nВы должны выбрать, какой из ваших кораблей" +
				$" вступит в бой.\nВы не можете выбрать для этого грузовое" +
		$" судно или любой потопленный корабль.{attackingFleet.GetInfo()}\n");

			int choice = Read("\nВведите номер корабля, " +
				"которым вы будете атаковать: ", 1, 5);

			// Блок try catch для обработки возможных исключений 
			// (они не случаются, но все же).
			try
			{
				// Проверка корректности: нельзя выбрать грузовое
				// судно и потопленные корабли.
				while (attackingFleet[choice - 1] is CargoShip ||
					!attackingFleet[choice - 1].IsAlive())
				{
					choice = Read("\nВведите номер корабля, " +
					"которым вы будете атаковать: ", 1, 5);
				}
			}
			catch (IndexOutOfRangeException)
			{

				Console.WriteLine("Произошла ошибка в работе с массивом," +
					"перезапустите программу.");
			}

			return choice;
		}

		/// <summary>
		/// Метод позволяет игроку в свой ход выбрать атакуемый корабль
		/// из флота противника. Для этого выводится информация о 
		/// доступных для атаки кораблях противника, затем считывается 
		/// выбранный номер.
		/// </summary>
		/// <param name="enemyFleet"> Метод принимает на вход флот
		/// противника. </param>
		/// <returns> Метод возвращает выбранный номер. </returns>
		public static int PickTheAttackedShip(FleetArray enemyFleet)
		{
			// Переменные для сокрытия номера грузового корабля, так
			// как грузовой корабль можно выбрать для атаки не всегда.
			int numberHidden;
			bool conceal;

			Console.Write($"\nВы должны выбрать, какой из кораблей " +
				$"противника вы хотите атаковать.\nВы можете атаковать " +
				$"следующие корабли: " +
			$"{enemyFleet.GetAttackedInfo(out numberHidden, out conceal)}\n");

			int choice = Read("\nВведите номер корабля, " +
				"который вы будете атаковать: ", 1, 5);

			// Проверка корректности ввода: если вводят номер скрытого корабля, 
			// ввод повторяется.
			if (conceal)
			{
				while (choice == numberHidden + 1)
				{
					choice = Read("\nВведите номер корабля, " +
						"который вы будете атаковать: ", 1, 5);
				}
			}

			return choice;
		}

		/// <summary>
		/// Метод реализует ход одного игрока: выбор атакующего
		/// корабля, возможность переноса припасов, выбор 
		/// атакуемого корабля, вывод информации.
		/// </summary>
		/// <param name="attackingFleet"> Метод принимает 
		/// атакующий флот. </param>
		/// <param name="defendingFleet"> Метод принимает 
		/// атакуемый флот. </param>
		public static void PlayersMove(FleetArray attackingFleet,
			FleetArray defendingFleet)
		{
			// Проверка того, жив ли флот игрока и есть ли 
			// во флоте припасы. Если нет, ход не начинается.
			if (attackingFleet.IsAlive() &&
				attackingFleet.RemainingAmmo())
			{
				Console.WriteLine($"\n\t\t\t\t\t\t\t\t" +
					$"{attackingFleet.PlayerName}, ваш ход!" +
				$"\nНажмите любую клавишу, чтобы начать атаку");

				Console.ReadKey(true);

				// Переменные для выбранного номера атакующего 
				// и атакуемого кораблей, индекса грузового судна 
				// (дефолтно равен 0, если грузового судна во флоте нет, 
				//поэтому эта переменная будет вызвана только внутри условной
				//проверки).
				int attackingChoice;
				int defendingChoice;
				int cargoIndex = attackingFleet.CargoIndex();

				attackingChoice = PickTheAttackingShip(attackingFleet) - 1;

				// Блок try catch для обработки возможных исключений 
				// (они не случаются, но все же).
				try
				{
					// Проверка наличия и состояния грузового судна.
					if (attackingFleet.CargoPicked && attackingFleet[cargoIndex].IsAlive())
					{
						if ((attackingFleet[cargoIndex] as CargoShip)?.Cargo > 0)
						{
							Console.WriteLine("\nУ вас во флоте есть грузовое судно." +
							"\nВы можете перегрузить часть боеприпасов с него на " +
							"корабль, который вступает в бой. " +
							"\nНажмите Enter, если хотите это сделать, " +
							"иначе нажмите любую другую клавишу.\n");

							// Если игрок хочет, припасы переносятся.
							if (Console.ReadKey(true).Key == ConsoleKey.Enter)
							{
								int numberOfCargo = Read("\nВведите количество " +
									"боеприпасов, которые хотите перенести на другой корабль. " +
									"\nЭто должно быть натуральное число не большее чем " +
									"значение груза на вашем грузовом судне: " +
								   $"{(attackingFleet[cargoIndex] as CargoShip).Cargo}. " +
								   $"\n\nВаш выбор: ",
								   1, (attackingFleet[cargoIndex] as CargoShip).Cargo); ;

								Console.WriteLine(attackingFleet.TransferCargo
									((attackingFleet[attackingChoice]
									as AttackingShip), numberOfCargo)); ;
							}
						}
					}
				}
				catch (IndexOutOfRangeException)
				{

					Console.WriteLine("Произошла ошибка в работе с массивом," +
					"перезапустите программу.");
				}

				Console.WriteLine("\n\t\t\t\t\t\tВсе готово к атаке! " +
					"Нажмите любую клавишу, чтобы продолжить");
				Console.ReadKey(true);

				// Вызов метода выбора атакуемого корабля.
				defendingChoice = PickTheAttackedShip(defendingFleet) - 1;

				// Блок try catch для обработки возможных исключений 
				// (они не случаются, но все же).
				try
				{
					// Вызов метода атаки.
					(attackingFleet[attackingChoice] as
					AttackingShip)?.Attack(defendingFleet[defendingChoice]);

					// Вывод текста о результате атаки.
					Console.WriteLine($"\n\t\t\t\t\t\t\t\t" +
						$"{attackingFleet.PlayerName} атаковал " +
						$"{defendingFleet.PlayerName}:" +
						$"\n{attackingFleet[attackingChoice].RememberedInfo}\n" +
						$"{defendingFleet[defendingChoice].RememberedInfo}\n" +
						$"\nАтакующий корабль после атаки:\n" +
						$"{attackingFleet[attackingChoice].GetInfo()}" +
						$"\n\nАтакованный корабль после атаки:\n" +
						$"{defendingFleet[defendingChoice].GetInfo()}" +
						$"\n\nНажмите любую клавишу, чтобы продолжить.");
				}
				catch (IndexOutOfRangeException)
				{

					Console.WriteLine("Произошла ошибка в работе с массивом," +
					"перезапустите программу.");
				}

				Console.ReadKey(true);
			}
			if (!attackingFleet.RemainingAmmo())
			{
				Console.WriteLine($"\n\t\t\t\t\t{attackingFleet.PlayerName}," +
					$" в вашем флоте не осталось боеприпасов, " +
					$"вы не можете больше ходить.");
			}
		}

		/// <summary>
		/// Метод битвы, в котором в условном операторе 
		/// реализуется вызов метода хода игрока до тех пор, 
		/// пока кто-то не выиграет.
		/// </summary>
		/// <param name="firstFleet"> Метод принимает 
		/// первый флот. </param>
		/// <param name="secondFleet"> Метод приимает 
		/// второй флот. </param>
		/// <returns> Метод возвращает строку с 
		/// исходом битвы. </returns>
		public static string Battle(FleetArray firstFleet,
			FleetArray secondFleet)
		{
			// Ходы игроков продолжаются, пока оба флота живы, 
			// и пока хотя бы в одном из них остались припасы.
			// Это не оговорено в условии, поэтому у меня ничья
			// случается, если у двоих игроков закончились припасы,
			// победителем же игрок становится, если флот противника
			// погиб.
			do
			{
				PlayersMove(firstFleet, secondFleet);
				PlayersMove(secondFleet, firstFleet);
			} while (firstFleet.IsAlive() && secondFleet.IsAlive() &&
				(secondFleet.RemainingAmmo() || firstFleet.RemainingAmmo()));

			// Условия победы того или иного игрока.
			if (!firstFleet.IsAlive())
			{
				return $"\t\t\t\t\t\t\t\t" +
					$"Флот {firstFleet.PlayerName} разгромлен!!!" +
					$"\n\t\t\t\t\t\t\t\tПобеждает " +
					$"{secondFleet.PlayerName}!";
			}

			if (!secondFleet.IsAlive())
			{
				return $"\t\t\t\t\t\t\t" +
					$"Флот {secondFleet.PlayerName} разгромлен!!!" +
					$"\n\t\t\t\t\t\t\t\tПобеждает " +
					$"{firstFleet.PlayerName}!";
			}

			// Условие ничьей.
			if (!firstFleet.RemainingAmmo() && !secondFleet.RemainingAmmo())
			{
				return "\n\t\t\t\t\t\t\t\tУ всех игроков закончились патроны! НИЧЬЯ!!!";
			}

			return "";
		}

		/// <summary>
		/// В методе мейн происходит вызов остальных методов игры.
		/// </summary>
		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется
			// возможность повторения игры по желанию пользователя.
			do
			{
				// Переменные для имен пользователей, объявление
				// экземпляров класса FleetArray - флотов игроков.
				string player1Name = "Игрок 1", player2Name = "Игрок 2";
				FleetArray player1Fleet, player2Fleet;

				// Вызов метода инициализации игры.
				Initialization(ref player1Name, ref player2Name);

				// Вызов метода выбора кораблей для первого игрока
				// и вывод информации о флоте в консоль.
				player1Fleet = PickTheShips(player1Name);
				Console.WriteLine(player1Fleet.GetInfo());
				Console.WriteLine("\nНажмите любую клавишу, " +
					"чтобы продолжить.");
				Console.ReadKey(true);

				// Вызов метода выбора кораблей для второго игрока
				// и вывод информации о флоте в консоль.
				player2Fleet = PickTheShips(player2Name);
				Console.WriteLine(player2Fleet.GetInfo());
				Console.WriteLine("\nНажмите любую клавишу, " +
					"чтобы продолжить.");
				Console.ReadKey(true);

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\n\t\t\t\t\t\t\t\tПРИШЛО ВРЕМЯ ДЛЯ БОЯ");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("\nБросаем монетку чтобы определить, " +
					"кто ходит первым....");

				// Случайным образом определяется правило первого хода.
				if (Utilities.random.Next(0, 2) % 2 == 0)
				{
					Console.WriteLine($"Выпал орел! Первым ходит " +
						$"{player1Fleet.PlayerName}");

					// Вызов метода боя с первым ходом первого игрока.
					Console.WriteLine(Battle(player1Fleet, player2Fleet));
				}
				else
				{
					Console.WriteLine($"Выпала решка! Первым ходит " +
						$"{player2Fleet.PlayerName}");

					// Вызов метода боя с первым ходом второго игрока.
					Console.WriteLine(Battle(player2Fleet, player1Fleet));
				}

				// Завершение игры.
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("\t\t\t\t\t\t\t\t~~~~ИГРА ЗАВЕРШЕНА~~~~");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("\nЧтобы сыграть заново, нажмите Enter, " +
					"для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
