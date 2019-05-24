using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forester
{
    /// <summary>
    /// описание вида ухода
    /// </summary>
    public class KindCare
    {
        //Идентификатор
        public int Uid { get; set; }
        //Название
        public string Name { get; set; }
        //Описание
        public string Opis { get; set; }
        //Государственные затраты
        public float Cost { get; set; }
    }
}
