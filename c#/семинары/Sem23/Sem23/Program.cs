using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace Sem23
{
	[Serializable]
	public class Student
	{

		public string Name { get; set; }
		public Student() { }
		public Student(string name) { Name = name; }

		public override string ToString()
		{
			return $"Studenttt {Name}";
		}
	}

	[Serializable]
	[XmlRoot("GroUp")]
	public class Group
	{
		public string Name { get; set; }
		[XmlArray("StUdENTs")]
		public List<Student> Students { get; }

		public Group()
		{
			Students = new List<Student>();
		}
		public Group(string name, params Student[] students)
		{

			Name = name;
			Students = new List<Student>(students);
		}

		public override string ToString()
		{
			return $"Group {Name}. Students: {string.Join(", ", Students)}";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Group bpi199 = new Group("bpi199", new Student("WOlf"), new Student("Tiger"));

			using (var fs = new FileStream("binSerialized.bin", FileMode.Create, FileAccess.Write))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(fs, bpi199);
			}

			using (var fs = new FileStream("binSerialized.bin", FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				Group desGroup = formatter.Deserialize(fs) as Group;
				Console.WriteLine($"deserialized binary {desGroup}");
			}

			using (var fs = new FileStream("xmlSerialized.xml", FileMode.Create, FileAccess.Write))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(bpi199.GetType());
				xmlSerializer.Serialize(fs, bpi199);
			}

			using (var fs = new FileStream("xmlSerialized.xml", FileMode.Open, FileAccess.Read))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(bpi199.GetType());
				Group group = xmlSerializer.Deserialize(fs) as Group;
				Console.WriteLine($"deserialized xml {group}");
			}

			using (var fs = new StreamWriter("jsSerialized.json"))
			{
				JsonSerializer.Serialize<Group>(bpi199);
				string serializedGroup = JsonSerializer.Serialize<Group>(bpi199);
				fs.Write(serializedGroup);
			}

			using (var fs = new StreamReader("jsSerialized.json"))
			{
				Group deserializedGroup = JsonSerializer.Deserialize<Group>(fs.ReadToEnd());
				Console.WriteLine($"deserialized js {deserializedGroup}");
			}

			using (var fs = new Newtonsoft.Json.JsonTextWriter( new StreamWriter("nsSerialized.json")))
			{
				Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
				jsonSerializer.Serialize(fs, bpi199);
				
			}

			using (var fs =new Newtonsoft.Json.JsonTextReader(new StreamReader("nsSerialized.json")))
			{
				Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
				Group deserializedGroup = jsonSerializer.Deserialize(fs, typeof(Group)) as Group;
				Console.WriteLine($"deserialized newton {deserializedGroup}");
			}



		}
	}
}
