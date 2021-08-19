using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using TwitterLib;

namespace ConsoleApp2
{
	class Program
	{
		public static List<TwitterPost> Deserialize()
		{
			using (FileStream fs = new FileStream("../../../подбелсосатб/bin/Debug/posts.xml", FileMode.Open, FileAccess.Read))
			{
				DataContractSerializer s = new DataContractSerializer(typeof(List<TwitterPost>));

				Console.WriteLine("\nдесериализация завершена");


				return s.ReadObject(fs) as List<TwitterPost>;
			}
		}

		static void Main(string[] args)
		{

			/// С помощью цикла do while с условием нажатия клавиши Enter
			/// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			/// повторного решения задачи по желанию пользователя.
			do
			{
				TwitterUser user = new TwitterUser();

				foreach (var post in Deserialize())
				{
					user.Posts.Add(post);
				}

				Console.WriteLine($"posts of {user.NickName}: ");

				foreach (TwitterPost item in user)
				{
					Console.WriteLine("\n"+item);
				}

				Console.WriteLine("\nposts at 23 hour: ");

				var postsAt23 = from post in user.GetPostsAtSomeHour(23)
								orderby (double)post descending
								select post;

				foreach (var item in postsAt23)
				{
					Console.WriteLine("\n"+item);
				}

				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					"для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);


		}
	}
}
