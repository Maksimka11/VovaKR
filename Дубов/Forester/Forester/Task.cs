using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forester
{
    /// <summary>
    /// описание запланированных задач
    /// </summary>
    public class Task
    {
        //Идентификатор
        public int Uid { get; set; }
        //Код области
        public int Region { get; set; }
        //Код ухода
        public int Care { get; set; }
        //Дата выполнения задачи
        public DateTime Date { get; set; }
    }
}
