using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	class VideoFile
	{
		private string _name;
		private int _duration;
		private int _quality;

		public VideoFile(string name, int duration, int quality)
		{
			_name = name;
			_duration = duration;
			_quality = quality;
		}

		public int Size
		{
			get
			{
				return _duration * _quality;
			}
		}

		public override string ToString()
		{
			return $"Имя видеофайла: {_name}\nДлительность: {_duration}\nКачество: {_quality}";
		}

	}
}
