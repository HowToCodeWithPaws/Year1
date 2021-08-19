using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem4
{
	class Logger
	{
		Queue<String> logs;

		public Logger()
		{
			logs = new Queue<string>();
		}

		public void Write(string str)
		{
			logs.Enqueue(str);
		}

		public string ReadAll()
		{
			return String.Join(Environment.NewLine,logs.Take(logs.Count));
		}

	}
}
