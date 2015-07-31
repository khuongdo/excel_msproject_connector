using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSProject = Microsoft.Office.Interop.MSProject;
using System.Text.RegularExpressions;
using BrightIdeasSoftware;
using System.Windows.Forms;


namespace ObjectsLibrary
{
   [Serializable()]
    public class Unit:IComparable<Unit>
    {
        public string FullName {get;set;}
        public string Name;
        public int Factor;
        public Unit(string _FullName)
        {
            try
            {
                this.FullName = _FullName;
                Regex rg = new Regex("^[0-9]{1,5}");
                Factor = Convert.ToInt32(rg.Match(this.FullName).Value);
                this.Name = _FullName.Remove(0, rg.Match(this.FullName).Length);
            }
            catch
            {
                Factor = 1;
                this.Name = _FullName;
            }
           
        }
        public int CompareTo(Unit unitToCompare)
        {
            if (this.Factor > unitToCompare.Factor)
                return 1;
            else if (this.Factor < unitToCompare.Factor)
                return -1;
            else
                return 0;
        }
    }
    public enum TaskMode
    {
        AutoSchedule,
        ManuallySchedule,
    }
    [Serializable()]
    public class MSPTask
    {
        [OLVColumn(IsVisible = false)]
        public int GroupID { get; set; }
        [OLVColumn("ID",DisplayIndex = 0)]
        public int ID {get;set;}
        [OLVColumn("Mã số",DisplayIndex = 2,Width=50,TextAlign=HorizontalAlignment.Left)]
        public string Code { get; set; }
        [OLVColumn("Tên công tác",DisplayIndex = 3,Width=250,TextAlign=HorizontalAlignment.Left)]
       
        public string Name { get; set; }
        [OLVColumn(IsVisible = false)]
        public Unit unit { get; set; }
        [OLVColumn("Khối lượng",DisplayIndex =4,Width=50,TextAlign=HorizontalAlignment.Left)]
        public double Value { get; set; }
        [OLVColumn(IsVisible=false)]
        public List<MSPResource> Resources { get; set; }
        [OLVColumn("STT",DisplayIndex=1,Width=20,TextAlign=HorizontalAlignment.Left)]
        public int TaskNo { get; set; }
      
        [OLVColumn("Thời gian",DisplayIndex=5,Width=30,TextAlign=HorizontalAlignment.Left)]
        public int DurationInDay { get; set; }
        [OLVColumn(IsVisible=false)]
        public string Predeccessors { get; set; }
        [OLVColumn("Chế độ",DisplayIndex=6,Width=50,TextAlign= HorizontalAlignment.Left)]
        public TaskMode Mode { get; set; }
        public MSPTask(int _ID,string _Code, string _Name,double _value, int _TaskNo, int _Duration,
                            string _Predecessors, List<MSPResource> _Resources, TaskMode _Mode = TaskMode.AutoSchedule)
        {
            this.Resources = new List<MSPResource>();
            this.ID = _ID;
            this.Code = _Code;
            this.Name = _Name;
            this.TaskNo = _TaskNo;
            this.DurationInDay = _Duration;
            this.Value = _value;
            this.Predeccessors = _Predecessors;
            this.Resources = _Resources;
            this.Mode = _Mode;
            
        }
        public MSPTask()
        {
            Resources = new List<MSPResource>();
        }
        public void AddResource(params MSPResource[] resources)
        {
            foreach (MSPResource r in resources)
            {
                r.TaskWaste = this.Value * this.unit.Factor; //Valua = waste
                
                this.Resources.Add(r);
            }
            
        }
        #region # Methods

        

        #endregion

        public bool Equals(MSPTask OtherTask)
        {
            if (OtherTask == null)
                return false;
            return this.Name == OtherTask.Name
                && this.ID == OtherTask.ID
                && this.Code == OtherTask.Code
                && this.TaskNo == OtherTask.TaskNo
                && this.DurationInDay == OtherTask.DurationInDay
                && this.Predeccessors == OtherTask.Predeccessors
                && this.Mode == OtherTask.Mode
                && this.Value == OtherTask.Value
                
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
                && this.Code == taskobj.Code
                && this.TaskNo == taskobj.TaskNo
                && this.DurationInDay == taskobj.DurationInDay
                && this.Predeccessors == taskobj.Predeccessors
                && this.Mode == taskobj.Mode
                && this.Value == taskobj.Value
                
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
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Value) ? this.Value.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Code) ? this.Code.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Resources) ? this.Resources.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
