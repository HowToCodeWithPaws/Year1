using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLib
{
    /// <summary>
    /// Интерфейс, обязующий наследников реализовать
    /// строковое свойство имени и вещественное свойство
    /// массы, а также метод сравнения двух объектов 
    /// этого интерфейса.
    /// </summary>
    public interface IPet:IComparable<IPet>
    {
        string Name { get; set; }

        double Mass { get; set; }
    }
}
