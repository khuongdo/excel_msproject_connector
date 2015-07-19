using System;
using System.Collections.Generic;
using System.Linq;




namespace ObjectsLibrary
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
        public static MSPResource MergeResources(List<MSPResource> ResourceList)
        {
            //null checking
            if (ResourceList == null) return null;

            


        }
      
    }
}
