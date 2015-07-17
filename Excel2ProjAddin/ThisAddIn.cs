using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using SoftwareLocker;

namespace Excel2ProjAddin
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            TrialMaker tm = new TrialMaker("Excel2Proj", "C:\\RegFile.reg",
                "C:\\TMSetp.dbf",
                "Summit your ID to email: dohuukhuong@gmail.com \r\n You will receive serial in couple of days",
                7, "123", false);
            byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
            4, 54, 87, 56, 123, 10, 3, 62,
            7, 9, 20, 36, 37, 21, 101, 57};
            tm.TripleDESKey = MyOwnKey;
            TrialMaker.RunTypes RT = tm.ShowDialog();
            if (RT != TrialMaker.RunTypes.Expired)
                return;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
