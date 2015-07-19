using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MSProject = Microsoft.Office.Interop.MSProject;

namespace ObjectsLibrary
{
    public enum ResourceType
    {
        Work,
        Material,
    }
    public class MSPResource
    {
        public string ID;
        public ResourceType Type;
        public double Assess;
        public string Unit;
        public string Name;
        public decimal Value;
        public double TaskWaste;
        public int UnitPrice;
        #region # CONSTRUCTOR
        public MSPResource(string _ID,string _Name, decimal _Value, string _Unit,double _Assess,int _UnitPrice, ResourceType _Type)
        {
            this.ID = _ID;
            this.Name = _Name;
            this.Value = _Value;
            this.Unit = _Unit;
            this.UnitPrice = _UnitPrice;
            this.Assess = _Assess;
            this.Type = _Type;
            
        }

        public MSPResource()
        {
            // TODO: Complete member initialization
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
                    && this.ID == resobj.ID
                    && this.Value == resobj.Value
                    && this.Unit == resobj.Unit
                    && this.UnitPrice == resobj.UnitPrice
                    && this.Assess == resobj.Assess
                    && this.TaskWaste == resobj.TaskWaste
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
                    && this.ID == res.ID
                    && this.TaskWaste == res.TaskWaste
                    && this.UnitPrice == res.UnitPrice
                    && this.Assess == res.Assess
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
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.ID) ? this.ID.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.UnitPrice) ? this.UnitPrice.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.Assess) ? this.Assess.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, this.TaskWaste) ? this.TaskWaste.GetHashCode() : 0);
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
                && Res1.ID == Res2.ID
                && Res1.Assess == Res2.Assess
                && Res1.UnitPrice == Res2.UnitPrice
                && Res1.TaskWaste == Res2.TaskWaste
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
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.ID) ? Res.ID.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.Assess) ? Res.Assess.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.UnitPrice) ? Res.UnitPrice.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.Type) ? Res.Type.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.Unit) ? Res.Unit.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.TaskWaste) ? Res.TaskWaste.GetHashCode() : 0);
                hash = (hash * 23) + (!Object.ReferenceEquals(null, Res.Value) ? Res.Value.GetHashCode() : 0);
                return hash;

            }
        }
    }
}
