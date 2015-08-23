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
        public static void ExportByTask(MSProject.Project CurrPj, MSPTask task)
        {
            MSProject.Task CurrTask = CurrPj.Tasks.Add(task.Name, Type.Missing);
            CurrTask.Duration = task.DurationInDay * 480;
            // Predecessors
            CurrTask.Predecessors = task.PredeccessorsToString;

            CurrTask.Notes = task.Code;
            List<MSProject.Resource> CurrResourcesCollection = CurrPj.Resources.Cast<MSProject.Resource>().ToList();
            foreach (MSPResource r in task.Resources)
            {
                CurrTask.Assignments.Add(CurrTask.ID, CurrResourcesCollection.Single(x => x.Name == r.Name).ID, Type.Missing);
            }
        }
    }
}
