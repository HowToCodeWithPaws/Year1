using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public class LimitedSymbolChain : SymbolChain
	{
		private int startCode;
		private int endCode;

		public override int GetChainLength
		{
			get
			{
				return chain.Count;
			}
		}

		public override void AddToChain(char newSymb)
		{
			if (newSymb < startCode || newSymb > endCode)
			{
				throw new ArgumentOutOfRangeException();
			}
			else
			{
				chain.Add(newSymb);
			}
		}

		public LimitedSymbolChain(int minVal, int maxVal) : base()
		{
			startCode = minVal;
			endCode = maxVal;
		}

		public override string ToString()
		{
			string total = "";
			foreach (char item in chain)
			{
				total += item.ToString();
			}

			return total;
		}
	}
}
