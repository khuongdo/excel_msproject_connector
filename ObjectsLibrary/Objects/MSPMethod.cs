using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ObjectsLibrary
{

    public class MSPMethods
    {
        public static List<MSPResource> CollectResources(List<MSPTask> Tasks)
        {
            List<MSPResource> tempResources = new List<MSPResource>();
            List<string> tempList = new List<string>();
            foreach (MSPTask task in Tasks)
            {
                tempList.AddRange(task.Resources.Select(x => x.Name));
                tempResources.AddRange(task.Resources);
            }
            List<MSPResource> finalRes =  new List<MSPResource>();
            tempList = tempList.Distinct().ToList();
            foreach (string item in tempList)
            {
                finalRes.Add(tempResources.First(x => x.Name == item));
            }
            return finalRes;
            
        }
        public static MSPTask CombineTasks(string NewName, List<MSPTask> Tasks)
        {
            return CombineTasks_Compute(NewName, Tasks.ToArray());
        }
        public static MSPTask CombineTasks(string NewName, params MSPTask[] Tasks)
        {
            return CombineTasks_Compute(NewName, Tasks);
        }
        private static MSPTask CombineTasks_Compute(string NewName, MSPTask[] Tasks)
        {
            // Check whether user inputs one task
            if (Tasks.Count<MSPTask>() == 0)
                return null;
            MSPTask NewTask = new MSPTask();
            //Task Name
            NewTask.Name = NewName;

            //Combine Unit
            List<Unit> UnitFactorList = new List<Unit>();
            Array.ForEach(Tasks, x => UnitFactorList.Add(x.unit));
            NewTask.unit = UnitFactorList.Min();

            //Combine task value multiply with unit factor
            List<string> UnitListInString = new List<string>();
            UnitFactorList.ForEach(x => UnitListInString.Add(x.FullName));
            if (UnitListInString.Distinct().Count() > 1)
                Array.ForEach(Tasks, x => NewTask.Value += x.Value * x.unit.Factor);
            else
                Array.ForEach(Tasks, x => NewTask.Value += x.Value);
            
            //Combine Task Code
            NewTask.Code = Tasks.Select(i => i.Code).Aggregate((i, j) => i + "+" + j);
            
            //duration
            Array.ForEach(Tasks, x => NewTask.DurationInDay += x.DurationInDay);
            
            
            
            
            //NewTask.UnitToString = NewTask.unit.FullName;
            //Combine Resources
            List<MSPResource> newResources = new List<MSPResource>();
            foreach (MSPTask T in Tasks)
            {
                T.Resources.ForEach(x => newResources.Add(x));
            }
            NewTask.Resources =  MergeResources(newResources);

            return NewTask;
        }
        private static List<MSPResource> MergeResources(List<MSPResource> ResourceList)
        {
            List<MSPResource> NewResources = new List<MSPResource>();
            //Check null and empty list
            if (ResourceList == null || ResourceList.Count <= 0) return null;
            if (ResourceList.Count == 1) return ResourceList;

            //1. MERGE MATERIAL RESOURCES
            //filter "Material" resources
            List<MSPResource> MaterialResources = ResourceList.Where(x => x.Type == ResourceType.Material).ToList();
            if (MaterialResources.Count == 0 || MaterialResources == null)
                goto Merge_Work_Resource;
            else if (MaterialResources.Count == 1)
                NewResources.Add(MaterialResources[0]);
            else
            {
                //Filter Distinct resource names
                List<string> MaterialResources_Distinct = MaterialResources.Select(x => x.Name).Distinct().ToList();
                foreach (var item in MaterialResources_Distinct)
                {
                    List<MSPResource> TempList = MaterialResources.Where(x => x.Name == item).ToList();
                    if (TempList.Count == 1)
                        NewResources.Add(TempList[0]);
                    else
                    {
                        
                        MSPResource tempResource = new MSPResource();
                        tempResource.Code = TempList[0].Code;
                        double sumTaskWaste_x_Assess = 0;
                        double sumTaskWaste = 0;
                        foreach (MSPResource r in TempList)
                        {
                            tempResource.Value += r.Value; //-> OK
                            sumTaskWaste += r.TaskWaste;
                            sumTaskWaste_x_Assess += (r.TaskWaste * r.Assess);
                        }
                        tempResource.Assess = Math.Round(sumTaskWaste_x_Assess / sumTaskWaste,5);
                        tempResource.Unit = TempList[0].Unit;

                        // if resource unit contain % character
                        if (TempList[0].Unit.Contains("%"))
                        {
                            double SumCost = 0;
                            TempList.ForEach(x => SumCost += x.TotalCost);
                            tempResource.UnitPrice = SumCost / TempList.Count;
                        }
                        else
                            tempResource.UnitPrice = TempList[0].UnitPrice;

                        tempResource.Name = TempList[0].Name;
                        tempResource.Type = ResourceType.Material;
                        NewResources.Add(tempResource);
                    }
                }
            }

            //2. MERGE WORK RESOURCES
            //Filter Work Resources
            Merge_Work_Resource: //label
            List<MSPResource> WorkResources = ResourceList.Where(x => x.Type == ResourceType.Work).ToList();
            if (WorkResources.Count == 0 || WorkResources == null)
                goto end;
            else if (WorkResources.Count == 1)
                NewResources.Add(WorkResources[0]);
            else
            {
                MSPResource tempResource = new MSPResource();
                double sumTaskWaste_x_Assess = 0;
                double sumTaskWaste = 0;
                List<string> strnameList = new List<string>();
                List<double> dblnameList = new List<double>();
                foreach (MSPResource r in WorkResources)
                {
                    tempResource.Value += r.Value; //-> OK
                    sumTaskWaste += r.TaskWaste;
                    sumTaskWaste_x_Assess += (r.TaskWaste * r.Assess);
                    Regex regex = new Regex("[0-9].[0-9]");
                    Match m = regex.Match(r.Name);
                    strnameList.Add(m.Value.Replace(',','.'));
                }
                tempResource.Assess = Math.Round((sumTaskWaste_x_Assess / sumTaskWaste),5);
                tempResource.Unit = WorkResources[0].Unit;
                strnameList.ForEach(x => dblnameList.Add(Convert.ToDouble(x)));
                double maxValue = dblnameList.Max();
                tempResource.Name = Regex.Replace(WorkResources[0].Name, "[0-9].[0-9]", string.Format("{0:0.0}",maxValue).Replace('/','-'));
                
                MSPResource maxRes = (from MSPResource r in WorkResources
                                   where r.Name == tempResource.Name
                                   select r).First();
                tempResource.Code = maxRes.Code;
                tempResource.UnitPrice = maxRes.UnitPrice;
                tempResource.Type = ResourceType.Work;
                NewResources.Add(tempResource);
            }

            end:
            return NewResources;

        }
      
        
    }
}
