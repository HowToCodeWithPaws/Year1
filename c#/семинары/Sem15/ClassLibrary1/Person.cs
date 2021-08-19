using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public abstract class Person
	{
		private string name;
		private string pocket = string.Empty;
		private bool cancel = false;

		public Person(string name_)
		{
			name = name_;
		}

		/// <summary>
		/// Публичное свойство для поля pocket с сеттером и геттером.
		/// </summary>
		public string Pocket
		{
			get { return pocket; }
			set { pocket = value; }
		}

		/// <summary>
		/// Публичное свойство для поля name с сеттером и геттером.
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public virtual bool IsPocketEmpty()
		{
			if (Pocket == string.Empty)
			{
				return true;
			}
			return false;
		}

		virtual public void Receive(string present)
		{
			if (!IsPocketEmpty())
			{
				throw new ArgumentException();
			}
			else
			{
				Pocket = present;
			}
		}

		public override string ToString()
		{
			return Name;
		}

	public bool Cancel
		{
			get { return cancel; }
			set{ cancel = value; }
		}
	}
}
