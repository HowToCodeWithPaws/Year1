using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace TwitterLib
{
	//[DataContract]
	//[KnownType(typeof(TwitterPost))]
	public class TwitterUser : IEnumerable<TwitterPost>
	{
		public event EventHandler<TwitterArgs> OnPostAdded;
		static Random random = new Random();

		string nickname = "Unknown";

		List<TwitterPost> posts = new List<TwitterPost>();

		public string NickName { get => nickname; set => nickname = value; }

		[DataMember]
		public List<TwitterPost> Posts { get => posts; set => posts = value; }

		public void GenerateNewPost()
		{
			string message = "";

			int length = random.Next(-10, 300);

			for (int i = 0; i < length; i++)
			{
				message += (char)random.Next(32, 127);
			}

			string time = random.Next(-10, 50).ToString() + ":" + random.Next(-10, 100);

			try
			{
				TwitterPost post = new TwitterPost(message, time);

				Posts.Add(post);

				OnPostAdded(this, new TwitterArgs(post, (ConsoleColor)random.Next(1, 16)));

			}
			catch (TwitterException e)
			{
				Console.WriteLine("An error occured: " + e.Message);
				GenerateNewPost();
			}

		}

		public IEnumerator<TwitterPost> GetEnumerator() => Posts.GetEnumerator();

		public IEnumerable<TwitterPost> GetPostsAtSomeHour(int hour)
		{
			var postsAtHour = from post in Posts
							  where int.Parse(post.Time.Split(':')[0]) == hour
							  select post;

			foreach (var post in postsAtHour)
			{
				yield return post;
			}
		}

		public override string ToString()
		{
			return NickName;
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		public TwitterUser() { posts = new List<TwitterPost>(); }

		public TwitterUser(string name_) : this() { NickName = name_; }
	}
}
