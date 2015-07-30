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
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Excel2ProjAddin.Forms
{
    public partial class FrmTaskList : Form
    {


        byte[] defaultstate;
        public FrmTaskList(List<MSPTask> ListTask)
        {
            
            InitializeComponent();
            Generator.GenerateColumns(olvTasks, typeof(MSPTask), false);
            olvTasks.SetObjects(ListTask);
            olvTasks.AutoResizeColumns();
            SaveTasks(ListTask);
            defaultstate = olvTasks.SaveState();
            //Resources list
            OLVColumn col = olvTasks.GetColumn(0);
            col.HeaderCheckBox = true;
            Generator.GenerateColumns(olvResources, typeof(MSPResource), false);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvTasks.SelectedIndex > -1)
            {
                List<MSPTask> list = LoadTasks();
                int id = Convert.ToInt32(olvTasks.SelectedItem.Text);
                
                olvResources.SetObjects(list[id].Resources);
                olvResources.AutoResizeColumns();
            }
        }
        private void SaveTasks(List<MSPTask> Tasks)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, Tasks);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                Properties.Settings.Default.TaskList = Convert.ToBase64String(buffer);
                Properties.Settings.Default.Save();
            }
        }
        private List<MSPTask> LoadTasks()
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String
                (Properties.Settings.Default.TaskList)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<MSPTask>)bf.Deserialize(ms);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text != string.Empty)
            {
                olvTasks.OwnerDraw = true;
                TextMatchFilter filter = TextMatchFilter.Contains(olvTasks, tbSearch.Text);
                olvTasks.ModelFilter = filter;
                HighlightTextRenderer hl = new HighlightTextRenderer(filter);
                hl.FillBrush = new SolidBrush(Color.Yellow);
                hl.CornerRoundness = 1.5f;
                hl.FramePen = new Pen(Color.Red);
                
                olvTasks.DefaultRenderer = hl;
            }
            else
            {
                olvTasks.Refresh();
                olvTasks.OwnerDraw = false;
            }
                
        }

        // Context Menu
        private void btnCombine_Click(object sender, EventArgs e)
        {
            
            ListViewItem item = new ListViewItem();
            item.Text = "Nhập tên mới";
            string temp = string.Empty;
            if (olvTasks.CheckedObjects.Count >= 2)
            {
                for (int i = 0; i < olvTasks.CheckedItems.Count; i++)
                    temp += olvTasks.CheckedItems[i].Text + " ";
                item.SubItems.Add(temp);
                OLVListItem olvitem = new OLVListItem(item);
                olv_CombineList.Items.Add(olvitem);
            }
            
        }
        

       

       
        
    }
   
}
