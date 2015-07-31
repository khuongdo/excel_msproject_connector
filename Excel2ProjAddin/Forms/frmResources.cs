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
        public frmResources(List<MSPResource> ResourcesList)
        {
            InitializeComponent();
            Generator.GenerateColumns(olvResources, typeof(MSPResource), true);
            olvResources.SetObjects(ResourcesList);
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
