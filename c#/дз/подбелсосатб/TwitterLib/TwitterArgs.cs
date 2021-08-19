using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{
	public class TwitterArgs : EventArgs
	{
		public readonly TwitterPost post;
		public readonly ConsoleColor color;

		public TwitterArgs(TwitterPost post_, ConsoleColor color_)
		{
			post = post_;
			color = color_;
		}
	}
}
