using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsLibrary;
using MSExcel = Microsoft.Office.Interop.Excel;


namespace Excel2ProjAddin
{
    class ExcelModule
    {
        MSExcel.Workbook xlWB;
        MSExcel.Worksheet xlWS;
        List<MSPTask> TaskCollection = new List<MSPTask>();
        public void CollectTasks()
        {
            var xlApp = Globals.ThisAddIn.Application;
            xlWS = xlApp.Sheets.get_Item("PTVT");
            MSExcel.Range usedRange = xlWS.UsedRange;
            MSExcel.Range usefulRange = usedRange.get_Range("4:" + (usedRange.Row - 1).ToString());
            
            foreach (MSExcel.Range r in usefulRange.Rows)
            {
                MSExcel.Range tempCell = r.get_Item(1);
               
            }

            
            

        }   
    }
}
