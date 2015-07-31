﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ObjectsLibrary;
using Excel = Microsoft.Office.Interop.Excel;


namespace Excel2ProjAddin
{
    public class ExcelModule
    {
        static Excel.Worksheet xlWS;
        public static List<MSPTask> CollectTasks()
        {
            var xlApp = Globals.ThisAddIn.Application;
            xlWS = (Excel.Worksheet)xlApp.Sheets.get_Item("PTVT");
            Excel.Range usedRange = (Excel.Range)xlWS.UsedRange;
            List<MSPTask> ListTasks = new List<MSPTask>();
            MSPTask TaskToAdd = null;
            int id = 0;
            for (int r = 5; r <= usedRange.Rows.Count; r++)
            {
                object TaskNo = usedRange.Value2[r,1];
                object ResourceID = usedRange.Value2[r,2];
                if (TaskNo != null)
                {
                    if (TaskToAdd != null)
                    {
                        ListTasks.Add(TaskToAdd);
                    }
                    TaskToAdd = new MSPTask() 
                    { 
                        ID = id++,
                        TaskNo = Convert.ToInt32(TaskNo),
                        Code = Convert.ToString(((Excel.Range)xlWS.Cells[r, 2]).Value2),
                        Name = Convert.ToString(((Excel.Range)xlWS.Cells[r, 3]).Value2),
                        unit = new Unit(Convert.ToString(((Excel.Range)xlWS.Cells[r, 4]).Value2)),
                        Value = Convert.ToDouble(((Excel.Range)xlWS.Cells[r, 5]).Value2),
                    };
                }
                else if (ResourceID != null)
                {
                    MSPResource ResToAdd = new MSPResource()
                    {
                        Code = Convert.ToString(ResourceID),
                        Name = Convert.ToString(((Excel.Range)xlWS.Cells[r, 3]).Value2),
                        Unit = Convert.ToString(((Excel.Range)xlWS.Cells[r, 4]).Value2),
                        Assess = Convert.ToDouble(((Excel.Range)xlWS.Cells[r, 5]).Value2),
                        Value = Convert.ToDecimal(((Excel.Range)xlWS.Cells[r, 6]).Value2),
                        UnitPrice = Convert.ToInt32(((Excel.Range)xlWS.Cells[r, 7]).Value2),
                    };
                    if (ResToAdd.Unit.ToUpper().Contains("CÔNG")
                        || ResToAdd.Name.ToUpper().Contains("NHÂN CÔNG"))
                        ResToAdd.Type = ResourceType.Work;
                    else
                        ResToAdd.Type = ResourceType.Material;
                    TaskToAdd.AddResource(ResToAdd);
                }
                else continue;
            }
            return ListTasks;
        }   
    }
}