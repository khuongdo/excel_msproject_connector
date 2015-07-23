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
      
        public TaskList(List<MSPTask> ListTask)
        {
            InitializeComponent();
            Generator.GenerateColumns(objectListView1,typeof(MSPTask));
            //Generator.GenerateColumns(objectListView1, ListTask);
            objectListView1.SetObjects(ListTask);

           
        }
    }
   
}
