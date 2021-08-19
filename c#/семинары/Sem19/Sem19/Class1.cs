using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sem19
{
	class StyleEventArgs:EventArgs
	{
		public StyleEventArgs(Color formColor) {
			FormColor = formColor;
		}
		public Color FormColor { get; }
	}
}
