using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem22
{
	class Program
	{
		//LinkedList<T>
		//Node<T>
		//Head
		//работает за н
		//односвязный список - от каждого элемента ссылка на следующий

		//двусвязные списки - с ссылками на предыдущий и на следующий, указатель на хвост
		// удобный доступ к элементам в любом месте списка

		static void Main(string[] args)
		{
			LinkedList<int> test = new LinkedList<int>();

			test.Add(1);
			test.Add(2);
			test.Add(3);

			Console.WriteLine(test.Contains(2));
			Console.WriteLine(test.Contains(5));
			Console.WriteLine(test[0]);
			Console.WriteLine(test[2]);

			ICollection<String> collection = new LinkedList<Object>();
			collection.Add("Hellow");
			Console.WriteLine(collection.GetType());

			IIndex<Object> indexCollection = new LinkedList<String>(); 
			Console.WriteLine(indexCollection[0].GetHashCode());
		}
	}
}
