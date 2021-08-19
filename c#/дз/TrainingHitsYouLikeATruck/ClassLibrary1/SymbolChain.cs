using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	abstract public class SymbolChain
	{
		protected List<Char> chain;

		protected SymbolChain()
		{
			chain = new List<char>(0);
		}

		public abstract int GetChainLength	{ get; }

		public abstract void AddToChain(char newSymb);
	}
}
