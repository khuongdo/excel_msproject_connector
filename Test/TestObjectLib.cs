using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ObjectsLibrary.MSProjectObjects;

namespace Test
{
    [TestFixture]
    public class TestObjectLib
    {
        public class TestDatabase
        {
            public MSPTask Task1 = new MSPTask()
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
            public const MSPTask Task2 = new MSPTask()
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
            
            public const MSPTask expectedvalue1 = new MSPTask()
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
        }
        
        [TestCase(TestDatabase.Task1,TestDatabase.Task2,Result=TestDatabase.expectedvalue1)]
        public void Test_TaskCombine_Method(MSPTask expectedvalue,MSPTask Task1, MSPTask Task2)
        {
            MSPTask actualvalue = Task1.CombineTask("Combined Task", Task2);
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
