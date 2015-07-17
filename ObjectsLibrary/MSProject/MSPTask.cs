using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSProject = Microsoft.Office.Interop.MSProject;
using System.Text.RegularExpressions;


namespace ObjectsLibrary
{
    class Unit
    {
        public string FullName;
        public string Name;
        public int Factor;
        public Unit(string _FullName)
        {
            this.FullName = _FullName;
            Match m = Regex.Match(_FullName,"[0-9]");
            this.Factor = Convert.ToInt32(m.Value);
        }
    }
    public enum TaskMode
    {
        AutoSchedule,
        ManuallySchedule,
    }
    public class MSPTask
    {
        public List<MSPResource> Resources;
        public string ID;
        public Unit Unit;
        public int TaskNo;
        public string Name;
        public int DurationInDay;
        public string Predeccessors;
        public TaskMode Mode;
        public MSPTask(string _ID, string _Name, int _TaskNo, int _Duration,
                            string _Predecessors, List<MSPResource> _Resources, TaskMode _Mode = TaskMode.AutoSchedule)
        {
            this.Resources = new List<MSPResource>();
            this.ID = _ID;
            this.Name = _Name;
            this.TaskNo = _TaskNo;
            this.DurationInDay = _Duration;

            this.Predeccessors = _Predecessors;
            this.Resources = _Resources;
            this.Mode = _Mode;

        }
        public MSPTask()
        {
            Resources = new List<MSPResource>();
        }

        #region # Methods

        private List<MSPResource> MergeResource(List<MSPResource> ResList1, List<MSPResource> Reslist2)
        {
            var Merge = ResList1.Union(Reslist2, new ResourceComparer());
            return Merge.ToList<MSPResource>();
        }

        #endregion

        public bool Equals(MSPTask OtherTask)
        {
            if (OtherTask == null)
                return false;
            return this.Name == OtherTask.Name
                && this.ID == OtherTask.ID
                && this.TaskNo == OtherTask.TaskNo
                && this.DurationInDay == OtherTask.DurationInDay
                && this.Predeccessors == OtherTask.Predeccessors
                && this.Mode == OtherTask.Mode
                && this.Resources == OtherTask.Resources;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            MSPTask taskobj = obj as MSPTask;
            if (taskobj == null)
                return false;
            else
                return this.Name == taskobj.Name
                && this.ID == taskobj.ID
                && this.TaskNo == taskobj.TaskNo
                && this.DurationInDay == taskobj.DurationInDay
                && this.Predeccessors == taskobj.Predeccessors
                && this.Mode == taskobj.Mode
                && this.Resources.All(taskobj.Resources.Contains);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Name) ? this.Name.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.ID) ? this.ID.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.TaskNo) ? this.TaskNo.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.DurationInDay) ? this.DurationInDay.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Predeccessors) ? this.Predeccessors.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Mode) ? this.Mode.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Resources) ? this.Resources.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
