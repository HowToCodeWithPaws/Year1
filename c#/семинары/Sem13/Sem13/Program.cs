using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem13
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arg = { 0,1,2,3,4,5,6,7,8,9};
			int[][] arr = new int[5][];
			int s = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = arg;
				for (int j = 0; j < arr.Length; j++)
				{
					s += arr[i][j];
				}
				Array.Reverse(arr[i]);
			}
			Console.WriteLine(s);
		}
	}
}
