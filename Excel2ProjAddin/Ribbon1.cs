using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.ComponentModel;
using System.Windows.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;


namespace Excel2ProjAddin
{
    public partial class Ribbon1
    {

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnCollectData_Click(object sender, RibbonControlEventArgs e)
        {
            MSExcel.Application xlApp = Globals.ThisAddIn.Application;
            MSExcel.Worksheet xlWS;
            try
            {
                xlWS = xlApp.Sheets.get_Item("PTVT");
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy sheet PTVT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Forms.frmMain f = new Forms.frmMain(xlWS);
            f.Show();
        }
       
    }
}
