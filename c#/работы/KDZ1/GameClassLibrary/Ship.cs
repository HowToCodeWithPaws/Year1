using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
	/// <summary>
	/// Абстрактный класс, от которого наследуются
	/// все остальные классы кораблей, 
	/// определяет базовый функционал.
	/// </summary>
	public abstract class Ship
	{
		// Защищенные поля здоровья и запомненной
		//информации.
		protected double healthy;
		protected string rememberedInfo;

		/// <summary>
		/// Публичное свойство для поля rememberedInfo с
		/// сеттером и геттером.
		/// </summary>
		public string RememberedInfo
		{
			get { return rememberedInfo; }
			set { rememberedInfo = value; }
		}

		/// <summary>
		/// Публичное свойство для поля healthy с 
		/// сеттером и геттером.
		/// </summary>
		protected double Healthy
		{
			get
			{
				if (healthy > 0)
				{
					return healthy;
				}
				return 0;
			}
			set { healthy = value; }
		}

		/// <summary>
		/// Открытый конструктор, задающий значение
		/// поля здоровья.
		/// </summary>
		/// <param name="_healthy"> Принимает на вход 
		/// значение здоровья. </param>
		public Ship(double _healthy)
		{
			Healthy = _healthy;
		}

		/// <summary>
		/// Метод возвращает true, если здоровье корабля 
		/// >0 и false иначе. Может быть (и будет) переопределен 
		/// в наследниках.
		/// </summary>
		/// <returns> Возвращает, жив ли корабль. </returns>
		public virtual bool IsAlive()
		{
			return Healthy > 0;
		}

		/// <summary>
		/// Открытый метод, очищающий и записывающий или 
		/// дописывающий информацию в поле запоминания.
		/// </summary>
		/// <param name="append"> Принимает на вход булевое
		/// append, в зависимости от которого либо записывает
		/// заново, либо добавляет информацию в конец. </param>
		/// <param name="message"> Принимает строку, которую
		/// надо записать. </param>
		/// <returns> Возвращает строку с запомненной 
		/// информацией. </returns>
		public string Remember(bool append, string message)
		{
			if (append)
			{
				RememberedInfo += message;
			}
			else
			{
				RememberedInfo = message;
			}

			return RememberedInfo;
		}

		/// <summary>
		/// Абстрактный открытый метод, определяющий 
		/// возможность получить урон.
		/// </summary>
		/// <param name="damage"> Принимает на вход 
		/// размер урона. </param>
		public abstract void GetDamage(double damage);

		/// <summary>
		/// Абстрактный открытый метод, определяющий 
		/// возвращающение информации о судне.
		/// </summary>
		/// <returns> Должен возвращать строку. </returns>
		public abstract string GetInfo();
	}
}
