using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMostCertainlyNotToday
{
	class SeasonEventArgs:EventArgs
	{
		private DateTime day;
		public DateTime Day { get { return day; } }

		public SeasonEventArgs(DateTime day_) {
			day = day_;
		}
	}
}
