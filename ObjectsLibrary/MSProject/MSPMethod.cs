using System;
using System.Collections.Generic;
using System.Linq;
using ObjectsLibrary.MSProject.Resource;
using ObjectsLibrary.MSProject.Task;


namespace ObjectsLibrary.MSProject.Methods
{
    
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

            var MaterialResources = new List<MSPResource>[] { };
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
    


}
