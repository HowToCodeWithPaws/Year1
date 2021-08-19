using System;
using System.Linq;
using System.Windows.Forms;
using GameClassLibrary;

namespace WF
{
	/// <summary>
	/// Первая винформа, в ней пользователи 
	/// вводят имена и выбирают флот.
	/// </summary>
	public partial class Form1 : Form
	{
		/// <summary>
		/// Поля для имен игроков.
		/// </summary>
		string player1Name, player2Name;

		/// <summary>
		/// Поля для массивов кораблей.
		/// </summary>
		Ship[] player1Ships, player2Ships;

		/// <summary>
		/// Поля для флотов.
		/// </summary>
		public FleetArray player1Fleet, player2Fleet;

		/// <summary>
		/// Булевые поля для отслеживания выбора имен,
		/// грузовых кораблеей, флотов, выхода из игры.
		/// </summary>
		bool player1CargoPicked, player2CargoPicked,
			player1NamePicked, player2NamePicked,
			player1FleetPicked, player2FleetPicked;

		/// <summary>
		/// Поля для количества выбранных каждым 
		/// пользователем кораблей.
		/// </summary>
		int player1ArrayIterator, player2ArrayIterator;

		/// <summary>
		/// Конструктор. Происходит инициализация 
		/// элементов, вызов метода начала игры, 
		/// фиксация размеров формы.
		/// </summary>
		public Form1()
		{
			InitializeComponent();

			// Изменять размеры формы нельзя.
			MaximizeBox = false;
			MinimizeBox = false;

			// Вызов метода начала игры.
			Begin();
		}

		/// <summary>
		/// Метод начала игры. Задает начальные значения
		/// всем полям и элементам формы.
		/// </summary>
		public void Begin()
		{
			// Появляется кнопка для начала игры.
			begin.Visible = true;
			bigText.Visible = true;

			player1Info.ReadOnly = false;
			player2Info.ReadOnly = false;

			player1CargoPicked = false;
			player2CargoPicked = false;

			player1NamePicked = false;
			player2NamePicked = false;

			player1FleetPicked = false;
			player2FleetPicked = false;

			playAgain.Visible = false;
			finish.Visible = false;

			player1Ships = new Ship[5];
			player2Ships = new Ship[5];

			player2CurrentChoice.Text = "";
			player1CurrentChoice.Text = "";

			player1Name = "Игрок 1";
			player2Name = "Игрок 2";

			player1ArrayIterator = 0;
			player2ArrayIterator = 0;
		}

		/// <summary>
		/// После нажатия кнопки игроки могут ввести имена.
		/// </summary>
		private void begin_Click(object sender, EventArgs e)
		{
			// Скрываются предыдущие кнопки.
			begin.Visible = false;
			bigText.Visible = false;

			// Открываются элементы для ввода имен.
			player1Message.Visible = true;
			player1Message.Text = "Игрок 1, введите свое имя, максимум 10 букв: ";
			player1Info.Show();
			player1NameChoice.Visible = true;

			player2Message.Visible = true;
			player2Message.Text = "Игрок 2, введите свое имя, максимум 10 букв: ";
			player2Info.Show();
			player2NameChoice.Visible = true;
		}

		/// <summary>
		/// Метод выбора имени с ограничениями на 
		/// значения имен, а также с открытием 
		/// следующей кнопки при условии окончания.
		/// </summary>
		/// <param name="playerNameChoice"> 
		/// Кнопка для сохранения имени. </param>
		/// <param name="nameBox"> 
		/// Поле для ввода имени. </param>
		/// <param name="playerMessage"> 
		/// Сообщение для игрока. </param>
		/// <param name="playerName"> Имя игрока. </param>
		/// <param name="namePicked"> 
		/// Булевый маркер выбора имени. </param>
		private void PickName(Button playerNameChoice,
			TextBox nameBox, Label playerMessage,
			ref string playerName, ref bool namePicked)
		{
			nameBox.ReadOnly = true;

			string tempName = nameBox.Text;

			// Имя не может состоять из пустой строки, 
			// пробелов или символов равных null или быть 
			// длиннее 10 символов.
			if (!(tempName == null || tempName.All(el => el == ' ')
				|| tempName == "" || tempName.Length > 10))
				playerName = tempName;

			playerMessage.Text = $"Ваше имя {playerName}";
			namePicked = true;

			nameBox.Visible = false;
			playerNameChoice.Visible = false;

			// Если оба пользователя ввели имя, 
			// открывается кнопка продолжения.
			if (player1NamePicked && player2NamePicked)
			{
				proceed.Visible = true;
			}
		}

		/// <summary>
		/// При нажатии на кнопку вызывается метод выбора имени.
		/// </summary>
		private void player1NameChoice_Click(object sender, EventArgs e)
		{
			PickName(player1NameChoice, player1Info, player1Message,
				ref player1Name, ref player1NamePicked);
		}

		/// <summary>
		/// При нажатии на кнопку вызывается метод выбора имени.
		/// </summary>
		private void player2NameChoice_Click(object sender, EventArgs e)
		{
			PickName(player2NameChoice, player2Info, player2Message,
				ref player2Name, ref player2NamePicked);
		}

		/// <summary>
		/// При нажатии на кнопку выводится информация 
		/// и начинается выбор кораблей для игроков.
		/// </summary>
		private void proceed_Click(object sender, EventArgs e)
		{
			proceed.Visible = false;

			player1ChoiceMessage.Text =
				"Вам нужно выбрать 5 кораблей для вашего флота" +
				"\nВы можете купить только одно грузовое судно" +
				"\nКаждый корабль стоит 8 монет";

			player2ChoiceMessage.Text =
				"Вам нужно выбрать 5 кораблей для вашего флота" +
				"\nВы можете купить только одно грузовое судно" +
				"\nКаждый корабль стоит 8 монет";

			player1CurrentChoice.Visible = true;
			player1CurrentChoice.Text +=
				$"\nВы выбираете {player1ArrayIterator + 1} " +
				$"корабль\nУ вас осталось " +
				$"{40 - 8 * player1ArrayIterator} монет";

			player2CurrentChoice.Visible = true;
			player2CurrentChoice.Text +=
				$"\nВы выбираете {player2ArrayIterator + 1} " +
				$"корабль\nУ вас осталось " +
				$"{40 - 8 * player2ArrayIterator} монет";

			// Открываются варианты выбора и кнопки 
			// для выбора кораблей.
			player1ChoiceMessage.Visible = true;
			player2ChoiceMessage.Visible = true;

			player1Choice.Visible = true;
			player1Add.Visible = true;

			player2Choice.Visible = true;
			player2Add.Visible = true;
		}

		/// <summary>
		/// Метод выбора позволяет по выбранному
		/// элементу сгенерировать объект типа корабль.
		/// </summary>
		/// <param name="cargoPicked"> Булевый маркер 
		/// выбранности грузового судна. </param>
		/// <param name="choiceBox"> Элемент со 
		/// списком кораблей. </param>
		/// <param name="messageLabel"> 
		/// Сообщение при выборе. </param>
		/// <returns> Метод возвращает сгенерированный
		/// объъект типа коралбь. </returns>
		private Ship Choice(ref bool cargoPicked,
			ListBox choiceBox, Label messageLabel)
		{
			// Ветвление в зависимости от выбора.
			switch (choiceBox.SelectedIndex)
			{
				case 2:
					messageLabel.Text += "\nВы выбрали грузовое судно";
					cargoPicked = true;
					return new CargoShip(
							Utilities.random.Next(1500, 2000)
							+ Utilities.random.NextDouble(),
							Utilities.random.Next(40, 71));
				case 1:
					messageLabel.Text += "\nВы выбрали линкор";
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
				case 0:
					messageLabel.Text += "\nВы выбрали эсминец";
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
					return null;
			}
		}

		/// <summary>
		/// Метод позволяет выбрать 5 кораблей в цикле,
		/// при выборе грузового судна не позволяет выбирать
		/// его впоследствии, после окончания выбора
		/// появляется кнопка для продолжения.
		/// </summary>
		/// <param name="playerChoice"> 
		/// Выбор в листБоксе. </param>
		/// <param name="playerCurrentChoice"> 
		/// Сообщение о текущем выборе. </param>
		/// <param name="playerChoiceMessage"> 
		/// Сообщение при выводе. </param>
		/// <param name="playerAdd"> 
		/// Кнопка для добавления корабля. </param>
		/// <param name="playerArrayIterator"> 
		/// Счетчик выбранных элементов в массиве. </param>
		/// <param name="playerCargoPicked"> 
		/// Булевый маркер выбранности грузового судна. </param>
		/// <param name="playerFleetPicked"> 
		/// Булевый маркер выбранности флота. </param>
		/// <param name="playerName"> Имя игрока. </param>
		/// <param name="playerShips"> Массив кораблей игрока. </param>
		private void Add(ListBox playerChoice, Label playerCurrentChoice,
			Label playerChoiceMessage, Button playerAdd,
			ref int playerArrayIterator, ref bool playerCargoPicked,
			ref bool playerFleetPicked, string playerName,
			ref Ship[] playerShips)
		{
			// Нельзя не выбрать корабль.
			if (playerChoice.SelectedIndex != -1)
			{
				// Если не выбрано грузовое судно, его можно выбрать.
				if (!playerCargoPicked)
				{
					// Блок try catch для обработки возможных исключений 
					// (они не случаются, но все же).
					try
					{
						// Вызов метода выбора корабля в 
						// присваивании кораблю в массиве.
						playerShips[playerArrayIterator] =
							Choice(ref playerCargoPicked,
							playerChoice, playerChoiceMessage);
					}
					catch (IndexOutOfRangeException)
					{

						Console.WriteLine("Произошла ошибка в работе" +
							"с массивом, перезапустите программу.");
					}
					catch (NullReferenceException)
					{
						Console.WriteLine("Произошла ошибка:" +
							" присваивание элемента равного null," +
							" перезагрузите программу.");
					}

					// Увеличение итератора.
					playerArrayIterator++;

					// Если итератор равен 5, выбраны 
					// все корабли, выбор заканчивается.
					if (playerArrayIterator == 5)
					{
						playerCurrentChoice.Text = "Вы выбрали все корабли";
						playerAdd.Visible = false; ;
						playerChoice.Visible = false;
						playerFleetPicked = true;

						// Если оба игрока выбрали корабли, 
						// появляется кнопка для продолжения.
						if (player1FleetPicked && player2FleetPicked)
						{
							battleBegin.Visible = true;
						}

						return;
					}

					// Вывод сообщения о текущем выборе.
					playerCurrentChoice.Text = "Вы выбираете " +
						$"{playerArrayIterator + 1} корабль" +
						$"\nУ вас осталось " +
						$"{40 - 8 * playerArrayIterator} монет ";
				}
				else
				{
					// Если грузовое судно выбрано, 
					// нельзя его выбрать снова (индекс !=2).
					if (playerChoice.SelectedIndex != 2)
					{
						// Блок try catch для обработки возможных исключений 
						// (они не случаются, но все же).
						try
						{
							// Вызов метода выбора корабля в 
							// присваивании кораблю в массиве.
							playerShips[playerArrayIterator] =
								Choice(ref playerCargoPicked,
								playerChoice, playerChoiceMessage);
						}
						catch (IndexOutOfRangeException)
						{

							Console.WriteLine("Произошла ошибка в работе" +
								"с массивом, перезапустите программу.");
						}
						catch (NullReferenceException)
						{
							Console.WriteLine("Произошла ошибка:" +
								" присваивание элемента равного null," +
								" перезагрузите программу.");
						}

						playerArrayIterator++;

						if (playerArrayIterator == 5)
						{
							playerCurrentChoice.Text =
								"Вы выбрали все корабли";
							playerAdd.Visible = false; ;
							playerChoice.Visible = false;
							playerFleetPicked = true;

							if (player1FleetPicked && player2FleetPicked)
							{
								battleBegin.Visible = true;
							}

							return;
						}

						playerCurrentChoice.Text = $"Вы выбираете " +
							$"{playerArrayIterator + 1} корабль" +
							$"\nУ вас осталось " +
							$"{40 - 8 * playerArrayIterator} монет ";
					}
					else
						MessageBox.Show("Вы больше не можете выбрать " +
							"грузовой корабль! Повторите выбор.");
				}
			}
			else
				MessageBox.Show("Вы должны выбрать корабль!" +
					" Повторите выбор.");
		}

		/// <summary>
		/// При нажатии на кнопку выбора вызывается метод выбора.
		/// </summary>
		private void player1Add_Click(object sender, EventArgs e)
		{
			Add(player1Choice, player1CurrentChoice,
				player1ChoiceMessage, player1Add,
				ref player1ArrayIterator, ref player1CargoPicked,
				ref player1FleetPicked, player1Name, ref player1Ships);
		}

		/// <summary>
		/// При нажатии на кнопку выбора вызывается метод выбора.
		/// </summary>
		private void player2Add_Click(object sender, EventArgs e)
		{
			Add(player2Choice, player2CurrentChoice,
				player2ChoiceMessage, player2Add,
				ref player2ArrayIterator, ref player2CargoPicked,
				ref player2FleetPicked, player2Name, ref player2Ships);
		}

		/// <summary>
		/// Формируются флоты как объекты класса флот,
		/// выводится информация о них.
		/// </summary>
		private void battleBegin_Click(object sender, EventArgs e)
		{
			// Инициализация флотов игроков.
			player1Fleet = new FleetArray(player1Name,
				player1CargoPicked, player1Ships);
			player2Fleet = new FleetArray(player2Name,
				player2CargoPicked, player2Ships);

			// Сокрытие предыдущих элементов.
			player1CurrentChoice.Visible = false;
			player2CurrentChoice.Visible = false;
			player1ChoiceMessage.Visible = false;
			player2ChoiceMessage.Visible = false;
			battleBegin.Visible = false;

			// Появление информации.
			player1InfoBox.Visible = true;
			player2InfoBox.Visible = true;
			battle.Visible = true;

			// Информация из метода объекта типа флот.
			player1InfoBox.Text = player1Fleet.GetInfo();
			player2InfoBox.Text = player2Fleet.GetInfo();
		}

		/// <summary>
		/// При нажатии на кнопку происходит сокрытие 
		/// всех предыдущих элементов, появление кнопки 
		/// "играть заново", переход в новую форму для игры.
		/// </summary>
		private void battle_Click(object sender, EventArgs e)
		{
			player1InfoBox.Visible = false;
			player2InfoBox.Visible = false;
			player1Message.Visible = false;
			player2Message.Visible = false;
			battle.Visible = false;

			// Кнопка сыграть заново появится при повторе решения,
			// кнопка выхода может использоваться для выхода из игры.
			playAgain.Visible = true;
			finish.Visible = true;

			// Переход в новую форму для битвы.
			new Form2(this, player1Fleet, player2Fleet).Show();
		}

		/// <summary>
		/// При нажатии на кнопку играть заново вызывается метод, 
		/// начинающий новую игру.
		/// </summary>
		private void playAgain_Click(object sender, EventArgs e)
		{
			Begin();
		}

		/// <summary>
		/// Событие закрытия формы - корректно закрывается приложение.
		/// </summary>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// При нажатии на кнопку происходит выход из игры.
		/// </summary>
		private void finish_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
