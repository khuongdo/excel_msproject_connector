using System;
using System.Collections.Generic;
using System.Linq;


namespace ObjectsLibrary.MSProjectObjects
{
    public enum TaskMode
    {
        AutoSchedule,
        ManuallySchedule,
    }
    public class MSPTask
    {
        public List<MSPResource> Resources;
        public string ID;
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
    public class MSP_Methods 
    {
        public static MSPTask CombineTasks(string NewName, params MSPTask[] Tasks)
        {
            // Check whether user inputs one task
            if (Tasks.Count<MSPTask>() == 0)
                return null;
            MSPTask NewTask = new MSPTask();
            //Task Name
            NewTask.Name = NewName;
            //Combine Task ID
            NewTask.ID = Tasks.Select(i => i.ID).Aggregate((i, j) => i + "+" + j);
            //Task No
            NewTask.TaskNo = 1;
            //duration
            Array.ForEach(Tasks, x => NewTask.DurationInDay += x.DurationInDay);
            //Predeccessors
            NewTask.Predeccessors = string.Empty;
            //Combine Resources
            foreach (MSPTask T in Tasks)
            {
                T.Resources.ForEach(x => NewTask.Resources.Add(x));
            }
            
            //
            return NewTask;
        }
        public static MSPResource CombineResources(List<MSPResource> ResourceList)
        {
            //Get list of distinct names
            if (ResourceList == null) return null;
                var DistinctList = ResourceList.Distinct().Select(x => x.Name).ToList();

            var MaterialResources = new List<MSPResource>[]{};
            // Resource Material type
            int i = 0;
            foreach (var item in DistinctList)
            {
                var ListMaterialRes = (from r in ResourceList
                            where r.Name == item && r.Type == ResourceType.Material
                            select r).ToList<MSPResource>();
                if (ListMaterialRes != null)
                {
                    MaterialResources[i] = ListMaterialRes;
                    i++;
                }
            }
            // Resource Work type
            var WorkRes = (from r in ResourceList
                           where r.Type == ResourceType.Work
                           select r).ToList<MSPResource>();
            //Combine Marterial Resources
            //check null
            if (MaterialResources.Length > 0 | MaterialResources != null)
            {
                
            }
            
            
        }
        private static MSPResource MergeResource(IEnumerable<MSPResource> List)
        {
            MSPResource newRes = new MSPResource();
            
        }
    }
    public enum ResourceType
    {
        Work,
        Material,
    }
    public class MSPResource
    {
        public ResourceType Type;
        public double ResWaste;
        public string Unit;
        public string Name;
        public double Value;

        #region # PROPERTY
        public MSPResource(string _Name, double _Value, string _Unit, ResourceType _Type, double _ResWaste)
        {
            this.Name = _Name;
            this.Value = _Value;
            this.Unit = _Unit;
            this.ResWaste = _ResWaste;
            this.Type = _Type;

        }
        #endregion

        public bool Equals(MSPResource another)
        {
            if (another == null)
                return false;
            MSPResource resobj = another as MSPResource;
            if (resobj == null)
                return false;
            else
                return this.Name == resobj.Name
                    && this.Value == resobj.Value
                    && this.Unit == resobj.Unit
                    && this.ResWaste == resobj.ResWaste
                    && this.Type == resobj.Type;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            MSPResource res = obj as MSPResource;
            if (res == null)
                return false;
            else
                return this.Name == res.Name
                && this.ResWaste == res.ResWaste
                && this.Type == res.Type
                && this.Unit == res.Unit
                && this.Value == res.Value;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Name) ? this.Name.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.ResWaste) ? this.ResWaste.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Type) ? this.Type.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Unit) ? this.Unit.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Value) ? this.Value.GetHashCode() : 0);
                return hash;
                
            }
            

        }

    }
    public class ResourceComparer : IEqualityComparer<MSPResource>
    {
        public bool Equals(MSPResource Res1, MSPResource Res2)
        {
            return Res1.Name == Res2.Name
                && Res1.ResWaste == Res2.ResWaste
                && Res1.Type == Res2.Type
                && Res1.Unit == Res2.Unit
                && Res1.Value == Res2.Value;

        }
        public int GetHashCode(MSPResource Res)
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.Name) ? Res.Name.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.ResWaste) ? Res.ResWaste.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.Type) ? Res.Type.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.Unit) ? Res.Unit.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.Value) ? Res.Value.GetHashCode() : 0);
                return hash;

            }
        }
    }


}
