using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
	[DataContract]
	public class DB : IComparable<DB>
	{
		int tablesCount;
		string name;

		[DataMember]
		public virtual int TablesCount
		{
			get => tablesCount; 
			set
			{
				if (value < 0 || value > 100)
				{
					throw new MyDBException("Количество таблиц не может быть отрицательным");
				}

				tablesCount = value;
			}
		}

		[DataMember]
		public string Name
		{
			get => name; 
			set
			{
				if (value.Length < 3 || value.Length > 8 || !value.All(l => 'A' <= l && l <= 'Z' || 'a' <= l && l <= 'z'))
				{
					throw new MyDBException($"Недопустимое имя {value}");
				}

				name = value;
			}
		}

		public DB(string name_, int tables_)
		{
			Name = name_;
			TablesCount = tables_;
		}

		public DB() { }

		public int CompareTo(DB obj) => this.TablesCount.CompareTo(obj.TablesCount);

		public override string ToString() => $"Name: {Name}, " +
			$"TablesCount: {TablesCount}";
	}
}
