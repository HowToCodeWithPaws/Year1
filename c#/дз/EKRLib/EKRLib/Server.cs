using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
	[DataContract]
	public class Server : DB, IEnumerable<DB>
	{
		List<DB> databases;

		[DataMember]
		public List<DB> Databases { get => databases; set => databases = value; }

		public void Add(DB newDB)
		{
			foreach (DB db in databases)
			{
				if (db.Name == newDB.Name)
				{
					throw new MyDBException($"Неуникальное имя БД {newDB.Name}");
				}
			}

			databases.Add(newDB);
		}

		public DB GetMostComplexDB()
		{
			int max = databases.Max(db => db.TablesCount);
			return databases.Find(db => db.TablesCount == max);
		}

		[DataMember]
		public override int TablesCount
		{
			get => databases.Sum(db => db.TablesCount);
			set { }
		}

		public override string ToString() =>
			"Server " + base.ToString() + ", ("
			+ string.Join(" ,", databases.Select(db => db.Name))
			+ ")";

		public IEnumerator<DB> GetEnumerator() => databases.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		public Server(string name_ = "MyServer")
		{
			Name = name_; databases = new List<DB>();
		}
	}
}