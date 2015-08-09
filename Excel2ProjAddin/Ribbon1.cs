using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;


namespace Excel2ProjAddin
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnCollectData_Click(object sender, RibbonControlEventArgs e)
        {
            Forms.frmMain f = new Forms.frmMain(ExcelModule.CollectTasks());
            f.Show();
        }
    }
}
