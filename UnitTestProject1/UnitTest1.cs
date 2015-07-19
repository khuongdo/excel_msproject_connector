using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectsLibrary;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUnit_100m3()
        {
            Unit unit = new Unit("100m3");
            Assert.AreEqual("m3", unit.Name);
            Assert.AreEqual(100, unit.Factor);
        }
        [TestMethod]
        public void TestUnit_m3()
        {
            Unit unit = new Unit("m3");
            Assert.AreEqual("m3", unit.Name);
            Assert.AreEqual(1, unit.Factor);
        }
        [TestMethod]
        public void Test1()
        {
            List<string> list = new List<string>();
            list.Add("Nhân công 3,5/7");
            list.Add("Nhân công 3,0/7");
            list.Add("Nhân công 4,0/7");
            Regex regex = new Regex("[0-9]*,[0-9]*");
            List<string> strlist = new List<string>();
            List<double> dbllist = new List<double>();
            foreach (string item in list)
            {
                Match m = regex.Match(item);
                strlist.Add(m.Value.Replace(',','.'));
            }
            strlist.ForEach(x=>dbllist.Add(Convert.ToDouble(x)));
            double maxvalue = dbllist.Max();
            Assert.AreEqual(4.0, maxvalue);
        }
       
        [TestMethod]
        public void Test_Merge_Task()
        {
            MSPTask Task1 = new MSPTask() 
            {
                DurationInDay = 10,
                ID = "AB.11442",
                Mode = TaskMode.AutoSchedule,
                Name = "Dao mong 1",
                Predeccessors = "1",
                TaskNo = 1,
                unit = new Unit("m3"),
                Value = 12,
            

            };
            Task1.AddResource(
                new MSPResource("NC.0007", "Nhân công bậc 3,0/7 - Nhóm I", 12.48m, "Công", 1.04, ResourceType.Work)
                );
            MSPTask Task2 = new MSPTask() 
            {
                DurationInDay = 20,
                ID = "AB.25422",
                Mode = TaskMode.AutoSchedule,
                Name = "Dao mong 2",
                Predeccessors = "1",
                TaskNo = 2,
                unit = new Unit("100m3"),
                Value = 10,

            };
            Task2.AddResource(
                new MSPResource("NC.0007", "Nhân công bậc 3,5/7 - Nhóm I", 14.22m, "Công", 1.422, ResourceType.Work),
                new MSPResource("MA.0089", "Máy đào 1,25m3", 2.3m, "ca", 0.23, ResourceType.Material),
                new MSPResource("MA.0222", "Máy ủi 108CV", 0.36m, "ca", 0.036, ResourceType.Material));
            MSPTask Task3 = new MSPTask()
            {
                DurationInDay = 25,
                ID = "AB.11111",
                Mode = TaskMode.AutoSchedule,
                Name = "Dao mong 3",
                Predeccessors = "1",
                TaskNo = 2,
                unit = new Unit("100m3"),
                Value = 20,
            };
            Task3.AddResource(
                new MSPResource("NC.0012", "Nhân công bậc 4,0/7 - Nhóm I", 11m, "Công", 1.322, ResourceType.Work),
                new MSPResource("MX","Máy xúc", 10m, "ca", 0.56, ResourceType.Material),
                new MSPResource("MA.0089", "Máy đào 1,25m3", 4m, "ca", 0.5, ResourceType.Material));
            MSPTask actual_value = MSP_Methods.CombineTasks("MergedTask", Task1, Task2,Task3);
            MSPTask expected_value = new MSPTask()
            {
                DurationInDay = 55,
                ID = "AB.11442+AB.25422+AB.11111",
                Mode = TaskMode.AutoSchedule,
                Name = "MergedTask",
                Predeccessors = "",
                TaskNo = 1,
                unit = new Unit("m3"),
                Value = 3012,
            };
            expected_value.AddResource(
                new MSPResource("MA.0089", "Máy đào 1,25m3", 6.3m, "ca", 0.41, ResourceType.Material),
                new MSPResource("MA.0222", "Máy ủi 108CV", 0.36m, "ca", 0.036, ResourceType.Material),
                new MSPResource("MX","Máy xúc", 10m, "ca", 0.56, ResourceType.Material),
                new MSPResource("NC.0012", "Nhân công bậc 4,0/7 - Nhóm I", 37.7m, "Công", Math.Round((12 * 1.04 + 10 * 1.422 * 100 + 20 * 1.322 * 100) / (12 + 10 * 100 + 20 * 100), 5), ResourceType.Work)
                );
            
            Assert.AreEqual(expected_value, actual_value);
            
        }
    }
}
