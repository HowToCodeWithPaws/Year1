using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using TwitterLib;
using System.Runtime.InteropServices;

namespace подбелсосатб
{
	class Program
	{
		static Random random = new Random();
		public static void PrintInfo(object sender, TwitterArgs args)
		{
			string info = $"New post from {(sender as TwitterUser).NickName} at {args.post.Time} : {args.post.Message}";
			Console.ForegroundColor = args.color;
			Console.WriteLine(info);
			Console.ResetColor();
		}

		public static void Serialize(TwitterUser user)
		{
			using (FileStream fs = new FileStream("posts.xml", FileMode.Create, FileAccess.Write))
			{
				DataContractSerializer s = new DataContractSerializer(typeof(List<TwitterPost>));
				s.WriteObject(fs, user.Posts);

				Console.WriteLine("\nСериализация завершена");
			}
		}

		static void Main(string[] args)
		{
			/// С помощью цикла do while с условием нажатия клавиши Enter
			/// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			/// повторного решения задачи по желанию пользователя.
			do
			{
				string name = "";
				int length = random.Next(1, 21);

				for (int i = 0; i < length; i++)
				{
					name += (char)random.Next('A', 'z' + 1);
				}

				TwitterUser user = new TwitterUser(name);

				user.OnPostAdded += PrintInfo;

				for (int i = 0; i < 50; i++)
				{
					user.GenerateNewPost();
				}

				Console.WriteLine("\nAll posts of this user:\n");

				foreach (TwitterPost post in user)
				{
					Console.WriteLine("\n" + post);
				}

				Serialize(user);

				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					"для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);


		}
	}
}
