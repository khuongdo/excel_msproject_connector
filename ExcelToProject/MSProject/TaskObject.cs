using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToProject.MSProject
{
    class TaskObject
    {
        public string Name;
        public int DurationInDay;
        public DateTime Start;
        public string Predeccessors;
        public TaskObject(string _Name, int _Duration, DateTime _Start, string _Predecessors)
        {
            this.Name = _Name;
            this.DurationInDay = _Duration;
            this.Start = _Start;
            this.Predeccessors = _Predecessors;
        }
        
    }
}
