using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public class EmailTrimTransformator: TransformatorBase
	{
		public override string Transform(string s)
		{
			if (s == null || s == string.Empty)
			{
				throw new ArgumentOutOfRangeException();
			}

			return s.Substring(0, s.IndexOf('@'));
		}

	}
}
