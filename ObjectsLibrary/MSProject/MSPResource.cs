using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
