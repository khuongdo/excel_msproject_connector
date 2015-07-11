using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectsLibrary.MSProjectObjects;
using System.Collections.Generic;


namespace UnitTestProject1
{
    [TestClass]
    public class TestMSProjectMethod
    {
        
        [TestMethod]
        public void Verify_CombineTask_Method()
        {
            List<ResourceObj> Res1 = new List<ResourceObj>() 
            {
                new ResourceObj("Gach",11.1, "vien", ResourceType.Material, 12),
                new ResourceObj("Da",12.2, "m3", ResourceType.Material, 14),
            };

            List<ResourceObj> Res2 = new List<ResourceObj>() 
            {
                new ResourceObj("Gach", 20.2, "vien", ResourceType.Material, 12),
                new ResourceObj("Da", 13, "m3", ResourceType.Material, 14),
                new ResourceObj("Cong Nhan", 5, "CN", ResourceType.Work, 10)
            };
            TaskObject Task1 = new TaskObject()
            {
                Name = "Task1",
                Mode = TaskMode.AutoSchedule,
                ID = "AB111",
                DurationInDay = 120,
                TaskNo = 1,
                Resources = Res1,
                Predeccessors = "1",
            };
            TaskObject Task2 = new TaskObject()
            {
                Name = "Task2",
                Mode = TaskMode.AutoSchedule,
                ID = "AF222",
                DurationInDay = 100,
                TaskNo = 2,
                Resources = Res2,
                Predeccessors = "2",
            };
            TaskObject actualvalue = Task1.CombineTask("Combined Task", Task2);
            List<ResourceObj> expRes = new List<ResourceObj>()
            {
                //new ResourceObj("Gach",23.3, "vien", ResourceType.Material, 26),
                //new ResourceObj("Da", 13, "m3", ResourceType.Material, 14),
                //new ResourceObj("Cong Nhan", 5, "CN", ResourceType.Work, 10),
            };
            TaskObject expectedvalue = new TaskObject()
            {
                Name = "Combined Task",
                Mode = TaskMode.AutoSchedule,
                ID = "AB111+AF222",
                DurationInDay = 220,
                TaskNo = 1,
                Resources = Res2,
                Predeccessors = string.Empty,
            };
            Assert.AreEqual(expectedvalue, actualvalue, "Failed");

        }
      
    }
}
