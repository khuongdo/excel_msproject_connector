using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ObjectsLibrary;


namespace Test
{
    [TestFixture]
    public class Test_MSP_Method
    {
        public class TestDatabase
        {
            public static MSPTask Task1 = new MSPTask()
            {
                Name = "Task1",
                Mode = TaskMode.AutoSchedule,
                ID = "AB111",
                DurationInDay = 120,
                TaskNo = 1,
                Resources = new List<MSPResource>() 
                {
                    new MSPResource("Gach",11.1, "vien", ResourceType.Material, 12),
                    new MSPResource("Da",12.2, "m3", ResourceType.Material, 14),
                },
                Predeccessors = "1",
            };
            public static MSPTask Task2 = new MSPTask()
            {
                Name = "Task2",
                Mode = TaskMode.AutoSchedule,
                ID = "AF222",
                DurationInDay = 100,
                TaskNo = 2,
                Resources = new List<MSPResource>() { 
                new MSPResource("Gach", 20.2, "vien", ResourceType.Material, 12),
                new MSPResource("Da", 13, "m3", ResourceType.Material, 14),
                new MSPResource("Cong Nhan", 5, "CN", ResourceType.Work, 10)
            },
                Predeccessors = "2",
            };

            public static MSPTask Task3 = new MSPTask()
            {
                Name = "Task3",
                Mode = TaskMode.AutoSchedule,
                ID = "AL212",
                DurationInDay = 130,
                TaskNo = 2,
                Resources = new List<MSPResource>() 
                { 
                    new MSPResource("Gach", 30.3, "vien", ResourceType.Material, 15),
                    new MSPResource("Cong Nhan", 5, "CN", ResourceType.Work, 10)
                },
                Predeccessors = "1",
            };

            public static MSPTask expectedvalue1 = new MSPTask()
            {
                Name = "Combined Task",
                Mode = TaskMode.AutoSchedule,
                ID = "AB111+AF222",
                DurationInDay = 220,
                TaskNo = 1,
                Resources = new List<MSPResource>() { 
                    new MSPResource("Gach",11.1, "vien", ResourceType.Material, 12),
                    new MSPResource("Da",12.2, "m3", ResourceType.Material, 14),
                    new MSPResource("Gach", 20.2, "vien", ResourceType.Material, 12),
                    new MSPResource("Da", 13, "m3", ResourceType.Material, 14),
                    new MSPResource("Cong Nhan", 5, "CN", ResourceType.Work, 10),
                },
                Predeccessors = string.Empty,
            };
            public static MSPTask expectedvalue2 = new MSPTask()
            {
                Name = "Combined Task",
                Mode = TaskMode.AutoSchedule,
                ID = "AB111+AF222+AL212",
                DurationInDay = 350,
                TaskNo = 1,
                Resources = new List<MSPResource>() { 
                    new MSPResource("Gach",11.1, "vien", ResourceType.Material, 12),
                    new MSPResource("Da",12.2, "m3", ResourceType.Material, 14),
                    new MSPResource("Gach", 20.2, "vien", ResourceType.Material, 12),
                    new MSPResource("Da", 13, "m3", ResourceType.Material, 14),
                    new MSPResource("Cong Nhan", 5, "CN", ResourceType.Work, 10),
                    new MSPResource("Gach", 30.3, "vien", ResourceType.Material, 15),
                    new MSPResource("Cong Nhan", 5, "CN", ResourceType.Work, 10),
                },
                Predeccessors = string.Empty,
            };
        }
        static object[] Testcases =
        {
            new object[] {TestDatabase.expectedvalue1,new MSPTask[] {TestDatabase.Task1,TestDatabase.Task2}},
            new object[] {TestDatabase.expectedvalue2,new MSPTask[] {TestDatabase.Task1,TestDatabase.Task2,TestDatabase.Task3}},
           
        };
        [Test, TestCaseSource("Testcases")]
        public void Test_TaskCombine_Method(MSPTask expectedvalue,params MSPTask[] Tasks)
        {
            MSPTask actualvalue = MSP_Methods.CombineTasks("Combined Task", Tasks);
            Assert.AreEqual(expectedvalue, actualvalue);
        }
        
        
        [Test]
        public void Test_Equals_Resource()
        {
            MSPResource res1 = new MSPResource("res", 11, "m3", ResourceType.Material, 10);
            MSPResource res2 = new MSPResource("res", 11, "m3", ResourceType.Material, 10);
            MSPResource res3 = new MSPResource("res1", 11, "m3", ResourceType.Material, 10);
            Assert.AreEqual(res1, res2);
            Assert.AreNotEqual(res1, res3);
        }
    }
}
