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
    public class Predecessor
    {
        public string PrecessorTask { get; set; }
        [OLVColumn("Link Type",ImageAspectName = "LinkType")]
        public MSProject.PjTaskLinkType LinkType { get; set; }
        public int Lag { get; set; }
        public Predecessor(string _Precessor,MSProject.PjTaskLinkType _Type,int _Lag)
        {
            this.PrecessorTask = _Precessor;
            this.LinkType = _Type;
            this.Lag = _Lag;
        }
    }
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
        public override string ToString()
        {
            return this.FullName;
        }
    }
    public enum TaskMode
    {
        AutoSchedule,
        ManuallySchedule,
    }
    [Serializable()]
    public class MSPTask: IComparable<MSPTask>
    {

        
        [OLVColumn(IsVisible = false)]
        public int GroupID { get; set; }
        [OLVColumn("ID",DisplayIndex = 0,Width = 30,IsEditable = false)]
        public int ID {get;set;}
        [OLVColumn("STT", DisplayIndex = 1, Width = 50, TextAlign = HorizontalAlignment.Left, IsEditable = true)]
        public int TaskNo { get; set; }
        [OLVColumn("Mã",DisplayIndex = 2,Width=60,TextAlign=HorizontalAlignment.Left,IsEditable = false)]
        
        public string Code { get; set; }
        [OLVColumn("Tên công tác",DisplayIndex = 3,Width=200,TextAlign=HorizontalAlignment.Left)]
        public string Name { get; set; }
        public Unit unit { get; set; }
        [OLVColumn("ĐV",DisplayIndex = 4,Width = 50,TextAlign = HorizontalAlignment.Center,IsEditable = false)]

        public string UnitDescription { get; set; }
        [OLVColumn("Khối lượng",DisplayIndex = 5,Width=50,TextAlign=HorizontalAlignment.Left,IsEditable = false)]
        public double Value { get; set; }
        [OLVColumn("Predecessors", DisplayIndex = 6, Width = 100)]
        public string Predeccessors { get; set; }

        [OLVColumn("Nhân công",DisplayIndex = 7,Width = 30,IsEditable = true)]
        public int Worker { get; set; }
        [OLVColumn("Thời gian (ngày)",DisplayIndex = 8,Width = 50,IsEditable = false)]
        public double DurationInDay { get; set; }

        
        [OLVColumn(IsVisible=false)]
        public List<MSPResource> Resources { get; set; }
        
      
       

        
       
        [OLVColumn(IsVisible = false)]
        public TaskMode Mode { get; set; }
        public MSPTask(int _ID,string _Code, string _Name,double _value, int _TaskNo, int _Duration,
                             List<MSPResource> _Resources, TaskMode _Mode = TaskMode.AutoSchedule)
        {
            this.Resources = new List<MSPResource>();
            this.ID = _ID;
            this.Code = _Code;
            this.Name = _Name;
            this.TaskNo = _TaskNo;
            this.DurationInDay = _Duration;
            this.Value = _value;
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
               // && this.TaskNo == OtherTask.TaskNo
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
                //&& this.TaskNo == taskobj.TaskNo
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
                //hash = (hash * 23) + (!Object.ReferenceEquals(null, this.TaskNo) ? this.TaskNo.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.DurationInDay) ? this.DurationInDay.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Predeccessors) ? this.Predeccessors.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Mode) ? this.Mode.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Value) ? this.Value.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Code) ? this.Code.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Resources) ? this.Resources.GetHashCode() : 0);
                return hash;
            }
        }
        public int CompareTo(MSPTask other)
        {
            if (this.TaskNo > other.TaskNo)
                return 1;
            else if (this.TaskNo < other.TaskNo)
                return -1;
            else
                return 0;
        }
    }
}
