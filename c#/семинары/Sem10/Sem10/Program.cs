using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Sem10.Program;

// Функционал убогий, зато с душой, sorry, I'm doing my best

namespace Sem10
{
	class Program
	{
		public static Random random = new Random();

		static void Main(string[] args)
		{
			do
			{
				Hero hero = new Hero("Живучее нечто", 100);
				while (hero.IsAlive)
				{
					int probability = random.Next(0, 100);
					if (probability >= 30)
					{
						Console.WriteLine($"{hero.Name} пока живет спокойной жизнью 0v0 .");
						if (probability>=60)
						{
							hero.Heal(probability%4);
						}
					}
					else
					{
						//Mob mob = new Mob(random.Next(5, 16), random.Next(0, 10), random.Next(20, 25));
						//Console.WriteLine($"{hero.Name} вступает в битву / (° O °) /\n\t\tc оружием {hero.UnitsWeapon.Name} \n\t\tс силой {hero.UnitsWeapon.WeaponPower}\n\t\tи hp {hero.HP}. \n{mob.ToString()}");
						//if (hero.Fight(mob))
						//{
						//	Console.WriteLine($"{hero.Name} побеждает в этом сражении. Осталось {hero.HP} hp.");
						//	if (random.Next(0, 100) % 3 == 0)
						//	{
						//		hero.ChangeWeapon();
						//		Console.WriteLine($"Волей судьбы оружие героя сменено на {hero.UnitsWeapon.Name} \n\t\tс силой {hero.UnitsWeapon.WeaponPower}.");
						//	}
						//}
						//else
						//{
						//	Console.WriteLine($"{hero.Name} покидает этот жестокий мир T--T .");
						//}

						MobArmy army = new MobArmy(random.Next(10, 20));
						if (hero.Fight(army))
						{
							Console.WriteLine($"{hero.Name} вышел из схватки победителем, осталось {hero.HP} хп");
						}
						else
						{
							Console.WriteLine($"{hero.Name} трагически погиб");
							return;
						}
					}
					Thread.Sleep(1000);

				}
				Console.WriteLine("\nЕсли хотите сыграть еще раз, нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
