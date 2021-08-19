using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{
	[DataContract]
	public class TwitterPost
	{
		string message, time;

		[DataMember]
		public string Message
		{
			get => message; set
			{
				if (value.Length >= 1 && value.Length <= 280)
				{
					message = value;
				}
				else throw new TwitterException($"длина {value.Length} не должна" +
					" превышать 280 символов, захлопни варежку");
			}
		}

		[DataMember]
		public string Time
		{
			get => time;
			set
			{
				if (value.Contains(':') && value.Split(':').Length == 2 &&
					int.TryParse(value.Split(':')[0], out int x)
					&& 0 <= x && x <= 23 &&
					int.TryParse(value.Split(':')[1], out int y)
					&& 0 <= y && y <= 59)
				{
					time = value;
				}
				else throw new TwitterException($"формат времени не верный: {value}");
			}
		}

		public TwitterPost(string message_, string time_)
		{
			Message = message_;
			Time = time_;
		}

		public override string ToString()
		{
			return $"{Time}>>{Message}";
		}

		public static explicit operator double(TwitterPost post)
		{
			return post.Message.Length;
		}
	}
}
