using System;
using System.Windows.Forms;
using GameClassLibrary;

namespace WF
{
	/// <summary>
	/// Вторая форма вызывается из первой, 
	/// в ней происходит сам бой.
	/// </summary>
	public partial class Form2 : Form
	{
		/// <summary>
		/// Поля для флотов двух игроков.
		/// </summary>
		FleetArray attackingFleet, defendingFleet;

		/// <summary>
		/// Поля для атакующего и атакуемого кораблей.
		/// </summary>
		Ship attackingShip, defendingShip;

		/// <summary>
		/// Поле для предыдущей формы.
		/// </summary>
		Form previousForm;

		// Массив булевых знчений, нужен для 
		// запоминания индеков кораблей, которые
		// можно выбрать как атакующие.
		bool[] goodAttackingRem = new bool[5];

		// Число для скрытого индекса и булевый
		// маркер - для ограничения возможности 
		// атаковать грузовое судно.
		int numberHidden = -1;
		bool conceal = false;

		/// <summary>
		/// Конструктор принимает ссылку на 
		/// предыдущую форму, а также два флота.
		/// </summary>
		/// <param name="form"> Предыдущая форма. </param>
		/// <param name="player1Fleet"> 
		/// Флот первого игрока. </param>
		/// <param name="player2Fleet">
		/// Флот второго игрока. </param>
		public Form2(Form form, FleetArray player1Fleet,
			FleetArray player2Fleet)
		{
			InitializeComponent();

			// Сокрытие предыдущей формы.
			previousForm = form;
			previousForm.Hide();

			// Фиксация размеров этой формы.
			MaximizeBox = false;
			MinimizeBox = false;

			// С равной вероятностью первая 
			// очередность хода достается либо 
			// первому, либо второму игроку.
			if (Utilities.random.Next(2) == 0)
			{
				// Блок try catch для обработки возможных исключений 
				// (они не случаются, но все же).
				try
				{
					attackingFleet = player1Fleet;
					defendingFleet = player2Fleet;
				}
				catch (NullReferenceException)
				{
					Console.WriteLine("Произошла ошибка:" +
						" присваивание элемента равного null," +
						" перезагрузите программу.");
				}
			}
			else
			{
				// Блок try catch для обработки возможных исключений 
				// (они не случаются, но все же).
				try
				{
					defendingFleet = player1Fleet;
					attackingFleet = player2Fleet;
				}
				catch (NullReferenceException)
				{
					Console.WriteLine("Произошла ошибка:" +
						" присваивание элемента равного null," +
						" перезагрузите программу.");
				}
			}

			// Вызов метода битвы.
			Fight();
		}

		/// <summary>
		/// В методе атаки происходит подготовка 
		/// к выбору атакующего корабля, он 
		/// запускает процесс атаки.
		/// </summary>
		private void Fight()
		{
			// Изначально все корабли недоступны 
			// для выбора их атакующими, далее 
			// мы выберем подходящие.
			for (int i = 0; i < goodAttackingRem.Length; i++)
			{
				goodAttackingRem[i] = false;
			}

			// Изначально скрываемый индекс 
			// считается равным -1, сокрытие - ложным.
			conceal = false;
			numberHidden = -1;

			// Открываются сообщения о выборе 
			// атакующего корабля.
			moveMessage.Visible = true;
			pickTheAttacking.Visible = true;

			// Вывод сообщения о том, чей ход, заполнение 
			// информации об атакующем флоте и атакуемом флоте.
			moveMessage.Text = $"Ходит игрок " +
				$"{attackingFleet.PlayerName}";

			pickTheAttacking.Text = "Вы должны выбрать," +
				" какой из ваших кораблей вступит в бой." +
				"\nВы не можете выбрать для этого грузовое" +
				" судно или любой потопленный корабль." +
				$"\nВаш флот: " + attackingFleet.GetInfo();

			pickTheDefending.Text = "Вы должны выбрать, " +
				"какой из кораблей противника вы хотите атаковать." +
				"\nВы можете атаковать следующие корабли :"
				+ defendingFleet.GetAttackedInfo(out numberHidden,
				out conceal);

			// В цикле происходит проверка и запоминание, можно ли
			// выбрать корабль из атакующего флота как
			// атакующий: корабль должен быть боевым и живым.
			// Обращаю внимание: можно выбрать корабль с нулевым 
			// количеством припасов, тогда будет наноситься 
			// нулевой урон, это нелогичный ход, но он не запрещен.
			for (int i = 0; i < goodAttackingRem.Length; i++)
			{
				if ((attackingFleet[i] is AttackingShip)
					&& attackingFleet[i].IsAlive())
				{
					goodAttackingRem[i] = true;
				}
			}

			// Открываются варианты выбора возможных 
			// атакующих кораблей и кнопка для подтверждения выбора.
			choiceTheAttacking.Visible = true;
			theAttacking.Visible = true;
		}

		/// <summary>
		/// Метод возвращает индекс выбранного
		/// корабля по выделенной строке ЛистБокс.
		/// </summary>
		/// <param name="box"> ЛистБокс, в 
		/// котором выбирается элемент. </param>
		/// <returns> Метод возвращает 
		/// индекс выранного корабля. </returns>
		private int Choice(ListBox box)
		{
			int index = 0;

			switch (box.SelectedItem)
			{
				case "1":
					index = 0;
					break;
				case "2":
					index = 1;
					break;
				case "3":
					index = 2;
					break;
				case "4":
					index = 3;
					break;
				case "5":
					index = 4;
					break;
			}
			return index;
		}

		/// <summary>
		/// Нажатие на кнопку реализует выбор
		/// атакующего корабля.
		/// </summary>
		private void theAttacking_Click(object sender,
			EventArgs e)
		{

			// Блок try catch для обработки возможных исключений 
			// (они не случаются, но все же).
			try
			{
				// Нельзя не выбрать ничего, а также выбрать индекс, 
				// который не отмечен в массиве подходящих кораблей 
				// как подходящий.
				if (choiceTheAttacking.SelectedIndex != -1 &&
					goodAttackingRem[choiceTheAttacking.SelectedIndex])
				{
					// Атакующий корабль получает ссылку на корабль
					// из флота, выбранный для этого.
					attackingShip =
						attackingFleet[Choice(choiceTheAttacking)];

					// Выводится сообщение о выборе атакующего корабля.
					pickTheAttacking.Text = "Вы атакуете кораблем\n"
						+ attackingShip.GetInfo();

					// Скрываются элементы для выбора.
					theAttacking.Visible = false;
					choiceTheAttacking.Visible = false;

					// Если во флоте есть грузовое судно, живое и с 
					// положительным количеством груза, можно перегрузить
					// груз на атакующий корабль.
					if (attackingFleet.CargoPicked &&
						attackingFleet[attackingFleet.CargoIndex()].IsAlive()
						&& (attackingFleet[attackingFleet.CargoIndex()]
						as CargoShip).Cargo > 0)
					{
						// Открытие сообщений о возможности перемещения груза
						// и элементов для выбора.
						transferChoice.Visible = true;
						transferChoice.Enabled = true;
						transferRefuse.Visible = true;

						// Вывод сообщения.
						transferChoice.Text = "В вашем флоте" +
							" есть грузовое судно. Припасы с него" +
							" можно перегрузить на атакующий корабль. " +
							"Если хотите это сделать, нажмите сюда";
					}
					else
					{
						// Если перемещение невозможно, открывается выбор 
						// атакуемого корабля.
						pickTheDefending.Visible = true;
						choiceTheDefending.Visible = true;
						theDefending.Visible = true;
					}
				}
				else
					MessageBox.Show("Вы выбрали корабль, который " +
						"нельзя выбрать! Повторите выбор.");
			}
			catch (NullReferenceException)
			{
				Console.WriteLine("Произошла ошибка:" +
					" присваивание элемента равного null," +
					" перезагрузите программу.");
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("Произошла ошибка:" +
				" при работе с массивом," +
				" перезагрузите программу.");
			}
		}

		/// <summary>
		/// Нажатие на кнопку реализует
		/// отказ от перемещения груза.
		/// </summary>
		private void transferRefuse_Click(object sender,
			EventArgs e)
		{
			// Сокрытие элементов для перемещения груза.
			transferChoice.Visible = false;
			transferRefuse.Visible = false;

			// Открытие элементов для выбора 
			// атакуемого корабля.
			pickTheDefending.Visible = true;
			choiceTheDefending.Visible = true;
			theDefending.Visible = true;
		}

		/// <summary>
		/// Нажатие на кнопку начинает 
		/// процесс перемещения груза.
		/// </summary>
		private void transferChoice_Click(object sender,
			EventArgs e)
		{
			// Сокрытие кнопки отказа, изменение возможности 
			// нажатия на кнопку согласия.
			transferRefuse.Visible = false;
			transferChoice.Enabled = false;

			// Блок try catch для обработки возможных исключений 
			// (они не случаются, но все же).
			try
			{
				// Вывод текста.
				transferChoice.Text = "Введите количество" +
					" боеприпасов, которые хотите перенести" +
					$" - целое число <= значение груза на " +
					$"вашем грузовом судне: " +
					$"{(attackingFleet[attackingFleet.CargoIndex()] as CargoShip).Cargo}";
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("Произошла ошибка:" +
				" при работе с массивом," +
				" перезагрузите программу.");
			}

			// Открытие поля для ввода количества 
			// груза и кнопки для подтверждения перемещения.
			transferCargo.Visible = true;
			transferConfirm.Visible = true;
		}

		/// <summary>
		/// Нажатие на кнопку подтверждает и 
		/// завершает перемещение груза.
		/// </summary>
		private void transferConfirm_Click(object sender,
			EventArgs e)
		{
			// Переменная для количества груза.
			int transferNumber;

			// Блок try catch для обработки возможных исключений 
			// (они не случаются, но все же).
			try
			{
				// Если введено число находящее в границах
				// допустимых для значения перегружаемого 
				// груза, происходит перемещение.
				if (int.TryParse(transferCargo.Text,
					out transferNumber) && transferNumber
					>= 0 && transferNumber <=
					(attackingFleet[attackingFleet.CargoIndex()]
					as CargoShip).Cargo)
				{
					// Вызов метода перемещения, вывод информации.
					transferChoice.Text =
						attackingFleet.TransferCargo
						((attackingShip as AttackingShip),
						transferNumber);

					// Изменение информации в поле 
					// информации об атакующем корабле.
					pickTheAttacking.Text = attackingShip.GetInfo();

					// Сокрытие элементов для перемещения.
					transferConfirm.Visible = false;
					transferCargo.Visible = false;

					// Открытие элементов для выбора 
					// атакуемого корабля.
					pickTheDefending.Visible = true;
					choiceTheDefending.Visible = true;
					theDefending.Visible = true;
				}
				else
					MessageBox.Show("Вы ввели неправильное число!" +
						" Повторите ввод.");
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("Произошла ошибка:" +
				" при работе с массивом," +
				" перезагрузите программу.");
			}
		}

		/// <summary>
		/// Нажатие на кнопку реализует выбор
		/// атакуемого корабля.
		/// </summary>
		private void theDefending_Click(object sender,
			EventArgs e)
		{
			// Блок try catch для обработки возможных исключений 
			// (они не случаются, но все же).
			try
			{
				// Нельзя не выбрать корабль, также нельзя выбрать
				// корабль по скрытому индексу, если сокрытие не ложно.
				if (choiceTheDefending.SelectedIndex != -1 &&
					(!conceal || choiceTheDefending.SelectedIndex
					!= numberHidden))
				{
					// Атакуемый корабль принимает ссылку на 
					// выбранный корабль из атакуемого флота.
					defendingShip =
						defendingFleet[Choice(choiceTheDefending)];

					// Выводится сообщение о выборе.
					pickTheDefending.Text = "Вы атакуете корабль\n"
						+ defendingShip.GetInfo();

					// Сокрытие элементов для выбора.
					theDefending.Visible = false;
					choiceTheDefending.Visible = false;

					// Открытие кнопки для атаки.
					attack.Visible = true;
				}
				else
					MessageBox.Show("Вы выбрали корабль, который " +
						"нельзя выбрать! Повторите выбор.");
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("Произошла ошибка:" +
				" при работе с массивом," +
				" перезагрузите программу.");
			}
			catch (NullReferenceException)
			{
				Console.WriteLine("Произошла ошибка:" +
					" присваивание элемента равного null," +
					" перезагрузите программу.");
			}
		}

		/// <summary>
		/// Нажатие на кнопку реализует атаку.
		/// </summary>
		private void attack_Click(object sender,
			EventArgs e)
		{
			// Сокрытие всех ранее активных элементов.
			transferChoice.Visible = false;
			attack.Visible = false;

			// Вызов метода атаки с безопасной 
			// проверкой совпадения типов.
			(attackingShip as AttackingShip)?.Attack(defendingShip);

			// Формирование сообщения о результате атаки.
			attackResults.Text = $"{attackingFleet.PlayerName} " +
				$"атаковал {defendingFleet.PlayerName}:" +
			$"\n{attackingShip.RememberedInfo}\n" +
			$"{defendingShip.RememberedInfo}";

			// Обновление информации об атакующем 
			// и атакованном кораблях.
			pickTheAttacking.Text = "Атаковавший корабль:\n"
				+ attackingShip.GetInfo();
			pickTheDefending.Text = "Атакованный корабль:\n"
				+ defendingShip.GetInfo();

			// Открытие сообщения о результатах атаки и кнопки
			// для продолжения.
			attackResults.Visible = true;
			proceed.Visible = true;
		}

		/// <summary>
		/// Нажатие на кнопку подводит итоги хода.
		/// </summary>
		private void proceed_Click(object sender, EventArgs e)
		{
			// Сокрытие информации о кораблях и
			// результатах атаки, кнопки для продолжения.
			pickTheAttacking.Visible = false;
			pickTheDefending.Visible = false;
			proceed.Visible = false;
			attackResults.Visible = false;

			// Если оба флота живы, возможно несколько исходов.
			if (defendingFleet.IsAlive() && attackingFleet.IsAlive())
			{
				// Если оба флота потеряли боеприпасы, игра 
				// завершается ничьей.
				if (!attackingFleet.RemainingAmmo() &&
					!defendingFleet.RemainingAmmo())
				{
					moveMessage.Text = "У всех игроков закончились" +
						" патроны! НИЧЬЯ!!!";

					// Открытие кнопок для повторения игры или выхода.
					exit.Visible = true;
				}

				// Если атакуемый флот потерял боеприпасы, 
				// но атакующий - нет, выводится сообщение 
				// о пропуске хода атакуемым флотом, 
				// игра продолжается.
				if (!defendingFleet.RemainingAmmo() &&
					attackingFleet.RemainingAmmo())
				{
					moveMessage.Text = $"{defendingFleet.PlayerName}," +
					$" \nв вашем флоте не осталось боеприпасов, " +
					"вы не можете больше ходить.";

					// Открытие кнопки для продолжения с пропуском хода
					// атакуемым флотом.
					newMoveWODefending.Visible = true;
				}

				// Если атакующий флот потерял боеприпасы,
				// но атакуемый - нет, выводится сообщение
				// о пропуске хода атакующим флотом,
				// игра продолжается.
				if (defendingFleet.RemainingAmmo() &&
					!attackingFleet.RemainingAmmo())
				{
					moveMessage.Text = $"{attackingFleet.PlayerName}," +
					$" \nв вашем флоте не осталось боеприпасов, " +
					"вы не можете больше ходить.";

					// Открытие кнопки для продолжения с пропуском хода
					// атакующим флотом.
					newMoveWOAttacking.Visible = true;
				}

				// Если у обоих флотов остались боеприпасы, 
				// игра продолжается с переходом хода к противнику.
				if (defendingFleet.RemainingAmmo() &&
					attackingFleet.RemainingAmmo())
				{
					moveMessage.Text = "За этот ход никто не " +
						"победил и не проиграл. " +
						"\nХод переходит к противнику.";

					// Открытие кнопки для продолжения с переходом хода
					// к противнику.
					newMove.Visible = true;
				}
			}

			// Если атакуемый флот погиб, игра завершается 
			// победой атаковавшего игрока.
			if (!defendingFleet.IsAlive())
			{
				moveMessage.Text = $"Флот " +
					$"{defendingFleet.PlayerName} разгромлен!!!" +
					$"\nПобеждает {attackingFleet.PlayerName}!";

				// Открытие кнопок для повторения игры или завершения.
				exit.Visible = true;
			}

			// Если атакующий флот погиб, игра завершается 
			// победой атакованного игрока.
			if (!attackingFleet.IsAlive())
			{
				moveMessage.Text = $"Флот " +
					$"{attackingFleet.PlayerName} разгромлен!!!" +
					$"\nПобеждает {defendingFleet.PlayerName}!";

				// Открытие кнопок для повторения игры или завершения.
				exit.Visible = true;
			}
		}

		/// <summary>
		/// Кнопка для нового хода с переходом
		/// хода к сопернику.
		/// </summary>
		private void newMove_Click(object sender,
			EventArgs e)
		{
			// Сокрытие кнопки и сообщения.
			moveMessage.Visible = false;
			newMove.Visible = false;

			// Флоты меняются местами, за счет чего
			// ход переходит к другому игроку.
			FleetArray temp = attackingFleet;
			attackingFleet = defendingFleet;
			defendingFleet = temp;

			// Вызов метода битвы.
			Fight();
		}

		/// <summary>
		/// Кнопка для нового хода без перехода хода.
		/// Если атакованный флот пропускает ход, то
		/// атакующий так и остается атакующим.
		/// </summary>
		private void newMoveWODefending_Click(object sender,
			EventArgs e)
		{
			// Сокрытие кнопки и сообщения.
			moveMessage.Visible = false;
			newMoveWODefending.Visible = false;

			// Вызов метода битвы.
			Fight();
		}

		/// <summary>
		/// Кнопка для нового хода без перехода хода.
		/// Если атакуемый флот пропускает ход, то 
		/// атакуемый и атакующий флоты меняются местами.
		/// Вероятно это можно было включить в обычный ход
		/// с переходом хода, но так более конкретизированно.
		/// </summary>
		private void newMoveWOAttacking_Click(object sender,
			EventArgs e)
		{
			// Сокрытие кнопки и сообщения.
			moveMessage.Visible = false;
			newMoveWOAttacking.Visible = false;

			// Флоты меняются местами, за счет чего
			// ход переходит к другому игроку.
			FleetArray temp = attackingFleet;
			attackingFleet = defendingFleet;
			defendingFleet = temp;

			// Вызов метода битвы.
			Fight();
		}

		/// <summary>
		/// Нажатие на кнопку реализует повтор игры.
		/// 
		/// </summary>
		private void exit_Click(object sender,
			EventArgs e)
		{
			// Сокрытие кнопки и сообщения.
			exit.Visible = false;
			moveMessage.Visible = false;

			// Закрытие этой формы, открытие 
			// предыдущей формы.
			Hide();
			previousForm.Show();
		}

		/// <summary>
		/// При закрытии формы открывается первая 
		/// форма, которую можно закрыть внутри нее.
		/// </summary>
		private void Form2_FormClosing(object sender,
			FormClosingEventArgs e)
		{
			previousForm.Show();
		}
	}
}
