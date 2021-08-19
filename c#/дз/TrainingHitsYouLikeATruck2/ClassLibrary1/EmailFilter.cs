using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public class EmailFilter
	{
		public bool Filter(string str)
		{
			if (str == null || str == string.Empty)
			{
				throw new ArgumentOutOfRangeException();
			}

			if (str.IndexOf('@') == -1)
			{
				return false;
			}

			if (str.Substring(str.IndexOf('@') + 1).IndexOf('.') == -1)
			{
				return false;
			}

			if (str.Substring(str.IndexOf('@') + 1).IndexOf('@') != -1)
			{
				return false;
			}

			return true;
		}

	}
}
