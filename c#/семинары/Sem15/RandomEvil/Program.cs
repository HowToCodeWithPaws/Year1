using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using static ClassLibrary1.Utilities;

namespace RandomEvil
{
	class Program
	{
		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				Santa santa = new Santa("Santa");
				SnowMaiden snowMaiden = new SnowMaiden("SnowMaiden");

				List<Person> people = new List<Person>(12);

				people.Add(santa);
				people.Add(snowMaiden);

				santa.Request(snowMaiden, 4);


				for (int i = 0; i < 10; i++)
				{
					people.Add(new Child(((char)random.Next('a', 'z' + 1)).ToString()));
				}

				while (people.ElementAt(0) is Santa && people.Count > 1 && (people.ElementAt(1) 
					is SnowMaiden || !santa.isSackEmpty())) {

					int probability = random.Next(1, 11);
					int personToGive = random.Next(1, people.Count);

					foreach (Person person in people)
					{
						Console.WriteLine(person.ToString());
					}

					if (probability == 7)
					{
						try
						{
							if (people.ElementAt(0) is Santa)
							{
								santa.Give(people.ElementAt(0));
							}

							if (people.ElementAt(0).Cancel)
							{
								Console.WriteLine($"{people.ElementAt(0).ToString()} is cancelled");
								people.RemoveAt(0);
								break;
							}
						}
			               
						
						catch (ArgumentException e)
						{
							Console.WriteLine("something went wrong");
						}

					}
					else
					{
						try
						{
							if (people.ElementAt(0) is Santa && people.ElementAt(personToGive) is Person)
							{

								santa.Give(people.ElementAt(personToGive));

								if (people.ElementAt(personToGive).Cancel)
								{
									Console.WriteLine($"{people.ElementAt(personToGive).ToString()} is cancelled");
									people.RemoveAt(personToGive);
								}

								if ( people.Count >1&&people.ElementAt(1) is SnowMaiden)
								{
									santa.Request(snowMaiden, random.Next(1, 5));
								}
							}
						}
						catch (ArgumentException e)
						{

							Console.WriteLine("что-то еще, ничего ж себе"+e);
						}
					}
				}

				Console.WriteLine("the party is dead");

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
