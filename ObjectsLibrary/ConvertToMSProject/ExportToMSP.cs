using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSProject = Microsoft.Office.Interop.MSProject;

namespace ObjectsLibrary
{
    
    public class ExportToMSP
    {
        public static MSProject.Project NewProject()
        {
            MSProject.Application PjApp = new MSProject.Application();
            PjApp.Visible = true;
            MSProject.Project PjProject = PjApp.Projects.Add();
            return PjProject;
        }
        public static MSProject.Project ActiveProject()
        {
            MSProject.Application PjApp = new MSProject.Application();
            PjApp.Visible = true;
            MSProject.Project PjProject = PjApp.ActiveProject;
            return PjProject;
        }
        public static void ExportByTasks(List<MSPTask> Tasks)
        {
            MSProject.Application PjApp = new MSProject.Application();
            PjApp.Visible = true;
            MSProject.Project PjProject = PjApp.Projects.Add();
            Tasks.Sort();
            
            foreach (MSPTask task in Tasks)
            {
                ExportByTask(PjProject,task);
            }

            

        }
        public static void ExportByTask(MSProject.Project CurrPj,MSPTask task)
        {
            MSProject.Task CurrTask = CurrPj.Tasks.Add(task.Name, Type.Missing);
            CurrTask.Duration = task.DurationInDay;
            if (task.Predeccessors != string.Empty && task.Predeccessors != null)
            {
                string[] _predecessorsID = task.Predeccessors.Split(',');
                List<string> _predecessorsNo = new List<string>();
                foreach (string id in _predecessorsID)
                {
                    //_predecessorsNo.Add(Tasks.Single(x => x.ID == Convert.ToInt32(id)).TaskNo.ToString());
                }
                CurrTask.Predecessors = _predecessorsNo.Aggregate((i, j) => i + "," + j);
            }
            CurrTask.Notes = task.Code;

            //foreach (MSPResource r in task.Resources)
            //{
            //    MSProject.Resource CurrRes = CurrTask.Resources.Add(r.Name, Type.Missing);
            //    CurrRes.Code = r.Code;

            //}
        }
    }
}
