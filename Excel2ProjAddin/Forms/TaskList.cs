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
    public partial class TaskList : Form
    {
        List<MSPTask> list = new List<MSPTask>();
        public TaskList(List<MSPTask> ListTask)
        {
            list = ListTask;
            InitializeComponent();
            dataListView_tasks.DataSource = ListTask;

            
        }

        private void dataListView1_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            
        }

       

        private void dataListView_tasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataListView_Resources.Clear();
            dataListView_Resources.DataSource = list.Single(x=>x.ID == dataListView_tasks.SelectedItem.Text).Resources;
        }

        
    }
   
}
