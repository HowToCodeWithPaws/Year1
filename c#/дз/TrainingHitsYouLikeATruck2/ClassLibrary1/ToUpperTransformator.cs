using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public class ToUpperTransformator: TransformatorBase
	{
		public override string Transform(string s)
		{
			if (s == null || s == string.Empty)
			{
				throw new ArgumentOutOfRangeException();
			}

			if (s[0] > 'a' && s[0]<'z')
			{
				return char.ToUpper(s[0]) + s.Substring(1);
			}

			return s;
		}
	}
}
