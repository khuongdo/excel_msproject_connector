using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectsLibrary;
using BrightIdeasSoftware;

namespace Excel2ProjAddin.Forms
{
    public partial class frmResources : Form
    {
        public frmResources(MSPTask taskobject)
        {
            InitializeComponent();
            this.Text = string.Format("Công tác: {0}", taskobject.Name);
            Generator.GenerateColumns(olvResources, typeof(MSPResource), true);
            olvResources.SetObjects(taskobject.Resources);
            olvResources.AutoSizeColumns();
        }

        private void frmResources_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void olvResources_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void olvResources_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
    }
}
