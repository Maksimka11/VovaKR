using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forester
{
    /// <summary>
    /// описание области леса
    /// </summary>
    public class Region
    {
        //Идентификатор
        public int Uid { get; set; }
        //Классификация деревьев
        public string Class { get; set; }
        //Площадь области
        public float Area { get; set; }
        //Средний возраст деревьев
        public int Year { get; set; }
    }
}
